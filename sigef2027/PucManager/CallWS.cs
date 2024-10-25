using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ServiceModel;

namespace PucManager
{
    internal partial class CallWS
    {
        public string Ticket { get; set; }
        private svcIgrueTrasmissione.Ticket IgrueTicket { get; set; }
        private svcIgrueEsitoElaborazione.Ticket ElaborazioneTicket { get; set; }
        private svcIgrueTrasmissione.Credenziali _CredenzialiTrasmissione { get; set; }
        private svcIgrueEsitoElaborazione.Credenziali _CredenzialiElaborazione { get; set; }
        private string _IdSistema { get; set; }
        private string _IdAmministrazione { get; set; }
        private string _password { get; set; }

        public CallWS()
        {
            _IdSistema = ConfigurationManager.AppSettings["IgrueIdSistema"].ToString();
            _IdAmministrazione = ConfigurationManager.AppSettings["IgrueIdAmministrazione"].ToString();
            _password = ConfigurationManager.AppSettings["IgruePassword"].ToString();

            _CredenzialiTrasmissione = new PucManager.svcIgrueTrasmissione.Credenziali();
            _CredenzialiTrasmissione.idAmministrazione = _IdAmministrazione;
            _CredenzialiTrasmissione.idSistema = int.Parse(_IdSistema);
            _CredenzialiTrasmissione.password = _password;

            _CredenzialiElaborazione = new PucManager.svcIgrueEsitoElaborazione.Credenziali();
            _CredenzialiElaborazione.idSistema = int.Parse(_IdSistema);
            _CredenzialiElaborazione.idAmministrazione = _IdAmministrazione;
            _CredenzialiElaborazione.password = _password;
        }


        //Metodo per richiedere ticket operazione
        internal string GetTicketWs()
        {
            try
            {
                var client = new svcIgrueTrasmissione.TrasmissioneClient("svcIgrue.Trasmissione");
                var msg = new svcIgrueTrasmissione.PrenotazioneTrasmissioneIn();
                var credenziali = new PucManager.svcIgrueTrasmissione.Credenziali();
                msg.credenziali = _CredenzialiTrasmissione;
                var response = client.prenotazioneTrasmissione(msg);
                if (response.esitoOperazione != null)
                {
                    IgrueTicket = response.ticket;
                    IgrueTicket.dataFineTrasmissione = response.ticket.dataAssegnazione;
                    Ticket = response.ticket.idTicket.ToString();
                }
                return Ticket;
            }
            catch (Exception ex)
            {               
                throw ex;
            }            
        }


        internal ResultInfoAssegnazione GetCodProceduraAttivazioneWs()
        {
            try
            {
                var result = new ResultInfoAssegnazione();
                string codice = string.Empty;
                var client = new svcIgrueTrasmissione.TrasmissioneClient("svcIgrue.Trasmissione");
                var msg = new svcIgrueTrasmissione.AssegnazioneCodProcAttIn();
                msg.credenziali = _CredenzialiTrasmissione;
                msg.protocollo = "10"; //Vedi doc. Protocollo di colloquio applicativo ver 3.1 pag. 29

                var response = client.assegnazioneCodProcAtt(msg);

                //L'oggetto contenente l'esito non è istanziato; per ora mi limito a reperire il codice di ritorno 
                //senza verificare il risultato della chiamata
                //if (response.esitoOperazione.descrizioneEsito == "OK") 
                //{
                //    codice = response.codiceProceduraAttivazione.idProceduraAttivazione;
                //}

                //result.Esito.CodiceEsito = response.esitoOperazione.codiceEsito;
                //result.Esito.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                //result.Esito.DettaglioEsito = response.esitoOperazione.dettaglio;
                //result.Esito.TimeStampEsito = response.esitoOperazione.timeStamp;
                //result.IdProceduraAttivazione = response.codiceProceduraAttivazione.idProceduraAttivazione;
                //result.DataAssegnazione = response.codiceProceduraAttivazione.dataAssegnazione;
                //result.IdAmministrazione = response.codiceProceduraAttivazione.idAmministrazione;
                //result.IdSistema = response.codiceProceduraAttivazione.idSistema;

                //codice = response.codiceProceduraAttivazione.idProceduraAttivazione;
                result.IdProceduraAttivazione = response.codiceProceduraAttivazione.idProceduraAttivazione;
                result.DataAssegnazione = response.codiceProceduraAttivazione.dataAssegnazione;
                result.IdAmministrazione = response.codiceProceduraAttivazione.idAmministrazione;
                result.IdSistema = response.codiceProceduraAttivazione.idSistema;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Metodo per l'invio dei file del protocollo di colloquio
        internal ResultInfo SendFile(byte[] file)
        {
            try
            {
                var client = new svcIgrueTrasmissione.TrasmissioneClient("svcIgrue.InvioFile");
                var msg = new svcIgrueTrasmissione.InviaFileIn();
                var response = new svcIgrueTrasmissione.InviaFileOut();
                string esito = string.Empty;
                ResultInfo result = new ResultInfo();
                msg.credenziali = _CredenzialiTrasmissione;
                GetTicketWs();
                msg.ticket = IgrueTicket;

                using (OperationContextScope Scope = new OperationContextScope(client.InnerChannel))
                {
                    svcIgrueTrasmissione.Content emptyContent = new svcIgrueTrasmissione.Content();
                    OperationContext.Current.OutgoingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty] = file;
                    response = client.inviaFile(msg, emptyContent);
                }

                if (response.esitoOperazione != null)
                {
                    result.CodiceEsito = response.esitoOperazione.codiceEsito;
                    result.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                    result.DettaglioEsito = response.esitoOperazione.dettaglio;
                    result.TimeStampEsito = response.esitoOperazione.timeStamp.HasValue ? response.esitoOperazione.timeStamp.Value.ToLocalTime() : (DateTime?)null;
                    esito = response.esitoOperazione.descrizioneEsito;
                }                 
                return result;
            }
            catch (Exception ex)
            {               
                throw ex;
            }
        }


        //Metodo per il download del log errori
        internal byte[] GetLogErrori(string IdTicketRef, ref ResultInfo result)
        {
            try
            {
                var client = new svcIgrueEsitoElaborazione.EsitoElaborazioneClient("svcIgrueEsitoElaborazione.LogErrori");
                var msg = new svcIgrueEsitoElaborazione.LogErroriIn();
                var response = new svcIgrueEsitoElaborazione.LogErroriOut();
                var ticket = new svcIgrueEsitoElaborazione.Ticket();
                byte[] log = null;
                msg.credenziali = _CredenzialiElaborazione;
                ticket.idTicket = long.Parse(IdTicketRef);
                ticket.idSistema = int.Parse(_IdSistema);
                ticket.idAmministrazione = _IdAmministrazione;
                ticket.dataAssegnazione = DateTime.Now;
                ticket.dataFineTrasmissione = DateTime.Now;
                msg.ticket = ticket;

                svcIgrueEsitoElaborazione.Content content = new PucManager.svcIgrueEsitoElaborazione.Content();
                using (OperationContextScope Scope = new OperationContextScope(client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty] = new byte[]{};
                    response = client.logErrori(msg, ref content);
                    if (response != null)
                    {
                        if (response.esitoOperazione != null)
                        {
                            result.CodiceEsito = response.esitoOperazione.codiceEsito;
                            result.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                            result.DettaglioEsito = response.esitoOperazione.dettaglio;
                            result.TimeStampEsito = response.esitoOperazione.timeStamp.HasValue ? response.esitoOperazione.timeStamp.Value.ToLocalTime() : (DateTime?)null;

                            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty))
                            {
                                log = (byte[])OperationContext.Current.IncomingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty];
                            }
                        }
                    }
                }
                return log;
            }
            catch (Exception ex)
            {               
                throw ex;
            }
        }


        internal byte[] GetStatisticheScarti(string IdTicketRef, ref ResultInfo result)
        {
            try
            {
                var client = new svcIgrueEsitoElaborazione.EsitoElaborazioneClient("svcIgrueEsitoElaborazione.LogErrori");
                var msg = new svcIgrueEsitoElaborazione.StatisticheScartiInAsAttachment();
                var response = new svcIgrueEsitoElaborazione.StatisticheScartiOutAsAttachment();
                var ticket = new svcIgrueEsitoElaborazione.Ticket();
                byte[] log = null;
                msg.credenziali = _CredenzialiElaborazione;
                ticket.idTicket = long.Parse(IdTicketRef);
                ticket.idSistema = int.Parse(_IdSistema);
                ticket.idAmministrazione = _IdAmministrazione;
                msg.ticket = ticket;

                svcIgrueEsitoElaborazione.Content content = new PucManager.svcIgrueEsitoElaborazione.Content();
                using (OperationContextScope Scope = new OperationContextScope(client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty] = new byte[] { };
                    response = client.statisticheScartiAsAttachment(msg, ref content);
                    if (response != null)
                    {
                        if (response.esitoOperazione != null)
                        {
                            result.CodiceEsito = response.esitoOperazione.codiceEsito;
                            result.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                            result.DettaglioEsito = response.esitoOperazione.dettaglio;
                            result.TimeStampEsito = response.esitoOperazione.timeStamp.HasValue ? response.esitoOperazione.timeStamp.Value.ToLocalTime() : (DateTime?)null;

                            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty))
                            {
                                log = (byte[])OperationContext.Current.IncomingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty];
                            }
                        }
                    }
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal byte[] GetStatisticheElaborazioni(string IdTicketRef, ref ResultInfo result)
        {
            try
            {
                var client = new svcIgrueEsitoElaborazione.EsitoElaborazioneClient("svcIgrueEsitoElaborazione.LogErrori");
                var msg = new svcIgrueEsitoElaborazione.StatisticheElaborazioniInAsAttachments();
                var response = new svcIgrueEsitoElaborazione.StatisticheElaborazioniOutAsAttachment();
                var ticket = new svcIgrueEsitoElaborazione.Ticket();
                byte[] log = null;
                msg.credenziali = _CredenzialiElaborazione;
                ticket.idTicket = long.Parse(IdTicketRef);
                ticket.idSistema = int.Parse(_IdSistema);
                ticket.idAmministrazione = _IdAmministrazione;
                msg.ticket = ticket;

                svcIgrueEsitoElaborazione.Content content = new PucManager.svcIgrueEsitoElaborazione.Content();
                using (OperationContextScope Scope = new OperationContextScope(client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty] = new byte[] { };
                    response = client.statisticheElaborazioniAsAttachment(msg, ref content);
                    if (response != null)
                    {
                        if (response.esitoOperazione != null)
                        {
                            result.CodiceEsito = response.esitoOperazione.codiceEsito;
                            result.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                            result.DettaglioEsito = response.esitoOperazione.dettaglio;
                            result.TimeStampEsito = response.esitoOperazione.timeStamp.HasValue ? response.esitoOperazione.timeStamp.Value.ToLocalTime() : (DateTime?)null;

                            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty))
                            {
                                log = (byte[])OperationContext.Current.IncomingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty];
                            }
                        }
                    }
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo per il download degli esiti elaborazione
        internal byte[] GetEsitoElaborazione(string IdTicketRef, ref ResultInfo result)
        {
            try
            {
                var client = new svcIgrueEsitoElaborazione.EsitoElaborazioneClient("svcIgrueEsitoElaborazione.LogErrori");
                var msg = new svcIgrueEsitoElaborazione.EsitoAnagraficaRiferimentoIn();
                var response = new svcIgrueEsitoElaborazione.EsitoAnagraficaRiferimentoOut();
                var ticket = new svcIgrueEsitoElaborazione.Ticket();
                byte[] log = null;
                msg.credenziali = _CredenzialiElaborazione;
                ticket.idTicket = long.Parse(IdTicketRef);
                ticket.idSistema = int.Parse(_IdSistema);
                ticket.idAmministrazione = _IdAmministrazione;
                msg.ticket = ticket;

                svcIgrueEsitoElaborazione.Content content = new PucManager.svcIgrueEsitoElaborazione.Content();
                using (OperationContextScope Scope = new OperationContextScope(client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty] = new byte[] { };
                    response = client.esitoAnagraficaRiferimento(msg, ref content);
                    if (response != null)
                    {
                        if (response.esitoOperazione != null)
                        {
                            result.CodiceEsito = response.esitoOperazione.codiceEsito;
                            result.DescrizioneEsito = response.esitoOperazione.descrizioneEsito;
                            result.DettaglioEsito = response.esitoOperazione.dettaglio;
                            result.TimeStampEsito = response.esitoOperazione.timeStamp.HasValue ? response.esitoOperazione.timeStamp.Value.ToLocalTime() : (DateTime?)null;

                            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty))
                            {
                                log = (byte[])OperationContext.Current.IncomingMessageProperties[WcfHelpers.SoapWithAttachments.SwaEncoderConstants.AttachmentProperty];
                            }
                        }
                    }
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
