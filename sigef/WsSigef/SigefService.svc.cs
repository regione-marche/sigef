using SiarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsSigef
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SigefService : ISigefService
    {
        private SigefServiceOperazioni op { get; set; }
        private ImportServiceLogBando logBando { get; set; }
        private ImportServiceLogProgetto logProgetto { get; set; }
        private ImportServiceLogDomandaPagamento logDomandaPagamento { get; set; }
        private ImportServiceLogVariante logDomandaVariante { get; set; }

        public SigefService() 
        {
            op = new SigefServiceOperazioni();
            logProgetto = new ImportServiceLogProgetto();
            logBando = new ImportServiceLogBando();
            logDomandaPagamento = new ImportServiceLogDomandaPagamento();
            logDomandaVariante = new ImportServiceLogVariante();
        }

        public ProgettoResultInfo InviaProgetto(ProgettoIn progetto)
        {
            ProgettoResultInfo result;
            try
            {
                string istanza = Encoding.UTF8.GetString(Convert.FromBase64String(progetto.IstanzaProgetto));
                logProgetto.SistemaMittente = progetto.SistemaMittente;
                logProgetto.IstanzaRichiesta = istanza;
                logProgetto.DataRichiesta = DateTime.Now;

                op.InsertImportServiceLogProgetti(logProgetto);
                result = op.ValidateDatiProgetto(istanza);
                result.IdTicketProgetto = logProgetto.IdImportServiceLogProgetto;

                if(result.Esito == "OK")
                {
                    logProgetto.Esito = "OK";
                    logProgetto.DataAcquisizione = DateTime.Now;
                    logProgetto.DataRisposta = DateTime.Now;
                    logProgetto.IdProgetto = result.IdProgetto;
                    logProgetto.Importato = true;
                }
                else
                {
                    logProgetto.Esito = "KO";
                    logProgetto.DataAcquisizione = DateTime.Now;
                    logProgetto.DataRisposta = DateTime.Now;
                    logProgetto.Errore = result.Errors;
                    result.Errors = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Errors));
                }

                OperationContext.Current.IncomingMessageProperties["logProgettoObj"] = logProgetto;               
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ProceduraAttivazioneResultInfo InviaProceduraAttivazione(ProceduraAttivazioneIn proceduraAttivazione)
        {
            ProceduraAttivazioneResultInfo result;
            try
            {
                string istanza = Encoding.UTF8.GetString(Convert.FromBase64String(proceduraAttivazione.IstanzaProceduraAttivazione));
                logBando.SistemaMittente = proceduraAttivazione.SistemaMittente;
                logBando.IstanzaRichiesta = istanza;
                logBando.DataRichiesta = DateTime.Now;

                op.InsertImportServiceLogBandi(logBando);
                result = op.ValidateDatiProceduraAttivazione(istanza);
                result.IdTicketProceduraAttivazione = logBando.IdImportServiceLogBando;

                if (result.Esito == "OK")
                {
                    logBando.Esito = "OK";
                    logBando.DataAcquisizione = DateTime.Now;
                    logBando.DataRisposta = DateTime.Now;
                    logBando.IdBando = result.IdProceduraAttivazione;
                    logBando.Importato = true;
                }
                else
                {
                    logBando.Esito = "KO";
                    logBando.DataAcquisizione = DateTime.Now;
                    logBando.DataRisposta = DateTime.Now;
                    logBando.Errore = result.Errors;
                    result.Errors = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Errors));
                }

                OperationContext.Current.IncomingMessageProperties["logBandoObj"] = logBando;              
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DomandaPagamentoResultInfo InviaDomandaPagamento(DomandaPagamentoIn domandaPagamento)
        {
            DomandaPagamentoResultInfo result;
            try
            {
                string istanza = Encoding.UTF8.GetString(Convert.FromBase64String(domandaPagamento.IstanzaDomandaPagamento));
                logDomandaPagamento.SistemaMittente = domandaPagamento.SistemaMittente;
                logDomandaPagamento.IstanzaRichiesta = istanza;
                logDomandaPagamento.DataRichiesta = DateTime.Now;

                op.InsertImportServiceLogDomandePagamento(logDomandaPagamento);
                result = op.ValidateDatiDomandaPagamento(istanza);
                result.IdTicketDomandaPagamento = logDomandaPagamento.IdImportServiceLogDomandaPagamento;

                if (result.Esito == "OK")
                {
                    logDomandaPagamento.Esito = "OK";
                    logDomandaPagamento.DataAcquisizione = DateTime.Now;
                    logDomandaPagamento.DataRisposta = DateTime.Now;
                    logDomandaPagamento.IdDomandaPagamento = result.IdDomandaPagamento;
                    logDomandaPagamento.Importato = true;
                }
                else
                {
                    logDomandaPagamento.Esito = "KO";
                    logDomandaPagamento.DataAcquisizione = DateTime.Now;
                    logDomandaPagamento.DataRisposta = DateTime.Now;
                    logDomandaPagamento.Errore = result.Errors;
                    result.Errors = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Errors));
                }

                OperationContext.Current.IncomingMessageProperties["logDomandaPagamentoObj"] = logDomandaPagamento;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DomandaPagamentoResultInfo InviaDomandaAnticipo(DomandaAnticipoIn domandaAnticipo)
        {
            DomandaPagamentoResultInfo result;
            try
            {
                string istanza = Encoding.UTF8.GetString(Convert.FromBase64String(domandaAnticipo.IstanzaDomandaAnticipo));
                logDomandaPagamento.SistemaMittente = domandaAnticipo.SistemaMittente;
                logDomandaPagamento.IstanzaRichiesta = istanza;
                logDomandaPagamento.DataRichiesta = DateTime.Now;

                op.InsertImportServiceLogDomandePagamento(logDomandaPagamento);
                result = op.ValidateDatiDomandaAnticipo(istanza);
                result.IdTicketDomandaPagamento = logDomandaPagamento.IdImportServiceLogDomandaPagamento;

                if (result.Esito == "OK")
                {
                    logDomandaPagamento.Esito = "OK";
                    logDomandaPagamento.DataAcquisizione = DateTime.Now;
                    logDomandaPagamento.DataRisposta = DateTime.Now;
                    logDomandaPagamento.IdDomandaPagamento = result.IdDomandaPagamento;
                    logDomandaPagamento.Importato = true;
                }
                else
                {
                    logDomandaPagamento.Esito = "KO";
                    logDomandaPagamento.DataAcquisizione = DateTime.Now;
                    logDomandaPagamento.DataRisposta = DateTime.Now;
                    logDomandaPagamento.Errore = result.Errors;
                    result.Errors = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Errors));
                }

                OperationContext.Current.IncomingMessageProperties["logDomandaAnticipoObj"] = logDomandaPagamento;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DomandaVarianteResultInfo InviaDomandaVariante(DomandaVarianteIn domandaVariante)
        {
            DomandaVarianteResultInfo result;
            try
            {
                string istanza = Encoding.UTF8.GetString(Convert.FromBase64String(domandaVariante.IstanzaDomandaVariante));
                logDomandaVariante.SistemaMittente = domandaVariante.SistemaMittente;
                logDomandaVariante.IstanzaRichiesta = istanza;
                logDomandaVariante.DataRichiesta = DateTime.Now;

                op.InsertImportServiceLogVarianti(logDomandaVariante);
                result = op.ValidateDatiDomandaVariante(istanza);
                result.IdTicketDomandaVariante = logDomandaVariante.IdImportServiceLogVariante;

                if (result.Esito == "OK")
                {
                    logDomandaVariante.Esito = "OK";
                    logDomandaVariante.DataAcquisizione = DateTime.Now;
                    logDomandaVariante.DataRisposta = DateTime.Now;
                    logDomandaVariante.IdVariante = result.IdVariante;
                    logDomandaVariante.Importato = true;
                }
                else
                {
                    logDomandaVariante.Esito = "KO";
                    logDomandaVariante.DataAcquisizione = DateTime.Now;
                    logDomandaVariante.DataRisposta = DateTime.Now;
                    logDomandaVariante.Errore = result.Errors;
                    result.Errors = Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Errors));
                }

                OperationContext.Current.IncomingMessageProperties["logDomandaVarianteObj"] = logDomandaVariante;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ConfigureService(ServiceConfiguration config)
        {
            var behavior = new XmlLoggingServiceBehavior();
            config.Description.Behaviors.Add(behavior);
        }
     


    }
}
