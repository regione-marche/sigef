using System.Data.SqlClient;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Runtime.Remoting.Messaging;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

namespace WsSigef
{
    public class XmlLoggingMessageInspector : IDispatchMessageInspector
    {

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (IsWsdlRequest(HttpContext.Current.Request.Url))
            {
                // se è una wsdl request salto la logica
                return;
            }

            var requestProperty = OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
            if (requestProperty is HttpRequestMessageProperty httpRequest && !string.IsNullOrEmpty(httpRequest.Method))
            {
                // Controllo se la request è per una operazione soap del servizio 
                if (!string.IsNullOrEmpty(httpRequest.Headers["SOAPAction"]))
                {
                    // estraggo il contenuto XML dal body della response
                    var buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                    var reader = buffer.CreateMessage().GetReaderAtBodyContents();

                    var xmlFragment = reader.ReadOuterXml();
                    reply = buffer.CreateMessage();
                    buffer.Close();


                    string actionUri = OperationContext.Current.IncomingMessageHeaders.Action;
                    var operationName = actionUri != null ? actionUri.Substring(actionUri.LastIndexOf("/") + 1) : actionUri;

                    if (operationName == "InviaProceduraAttivazione" || operationName == "InviaProgetto" || operationName == "InviaDomandaPagamento" || operationName == "InviaDomandaAnticipo" || operationName == "InviaDomandaVariante")
                    {
                        switch (operationName)
                        {
                            case "InviaProceduraAttivazione":
                                ImportServiceLogBando logBando = OperationContext.Current.IncomingMessageProperties["logBandoObj"] as ImportServiceLogBando;
                                if (logBando != null)
                                {
                                    // Aggiorno il log dei bandi con il body della response
                                    logBando.IstanzaRisposta = xmlFragment;
                                    UpdateLogProceduraAttivazione(logBando);
                                }
                                break;

                            case "InviaProgetto":
                                ImportServiceLogProgetto logProgetto = OperationContext.Current.IncomingMessageProperties["logProgettoObj"] as ImportServiceLogProgetto;

                                if (logProgetto != null)
                                {
                                    // Aggiorno il log dei progetti con il body della response
                                    logProgetto.IstanzaRisposta = xmlFragment;
                                    UpdateLogProgetto(logProgetto);
                                }
                                break;

                            case "InviaDomandaPagamento":
                                ImportServiceLogDomandaPagamento logDomandaPagamento = OperationContext.Current.IncomingMessageProperties["logDomandaPagamentoObj"] as ImportServiceLogDomandaPagamento;

                                if (logDomandaPagamento != null)
                                {
                                    // Aggiorno il log delle domande pagamento con il body della response
                                    logDomandaPagamento.IstanzaRisposta = xmlFragment;
                                    UpdateLogDomandaPagamento(logDomandaPagamento);
                                }
                                break;

                            case "InviaDomandaAnticipo":
                                ImportServiceLogDomandaPagamento logDomandaAnticipo = OperationContext.Current.IncomingMessageProperties["logDomandaAnticipoObj"] as ImportServiceLogDomandaPagamento;

                                if (logDomandaAnticipo != null)
                                {
                                    // Aggiorno il log delle domande pagamento anticipo con il body della response
                                    logDomandaAnticipo.IstanzaRisposta = xmlFragment;
                                    UpdateLogDomandaPagamento(logDomandaAnticipo);
                                }
                                break;

                            case "InviaDomandaVariante":
                                ImportServiceLogVariante logVariante = OperationContext.Current.IncomingMessageProperties["logDomandaVarianteObj"] as ImportServiceLogVariante;

                                if (logVariante != null)
                                {
                                    // Aggiorno il log delle varianti con il body della response
                                    logVariante.IstanzaRisposta = xmlFragment;
                                    UpdateLogVariante(logVariante);
                                }
                                break;
                            default:

                                break;
                        }
                    }
                }
            }    
        }

        private void UpdateLogProgetto(ImportServiceLogProgetto logProgetto)
        {
            var op = new SigefServiceOperazioni();
            op.UpdateImportServiceLogProgetti(logProgetto);
        }

        private void UpdateLogProceduraAttivazione(ImportServiceLogBando logBando)
        {
            var op = new SigefServiceOperazioni();
            op.UpdateImportServiceLogBandi(logBando);
        }

        private void UpdateLogDomandaPagamento(ImportServiceLogDomandaPagamento logDomandaPagamento)
        {
            var op = new SigefServiceOperazioni();
            op.UpdateImportServiceLogDomandePagamento(logDomandaPagamento);
        }

        private void UpdateLogVariante(ImportServiceLogVariante logVariante)
        {
            var op = new SigefServiceOperazioni();
            op.UpdateImportServiceLogVarianti(logVariante);
        }

        private bool IsWsdlRequest(Uri requestUri)
        {
            if (requestUri != null && requestUri.Query != null)
            {
                string query = requestUri.Query.ToLowerInvariant();
                if (query.Contains("wsdl") || query.Contains("singlewsdl") || query.Contains("xsd"))
                {
                    return true;
                }
            }

            return false;
        }

    }
}