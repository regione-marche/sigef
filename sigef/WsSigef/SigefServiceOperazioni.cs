using SiarBLL;
using SiarLibrary;
using SiarLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WsSigef
{
    internal class SigefServiceOperazioni
    {
        private DALClass _dal { get; set; }
        private string XsdProcedurePath { get; set; }
        private string XsdProgettiPath { get; set; }
        private string XsdDomandePagamentoPath { get; set; }
        private string XsdDomandeAnticipoPath { get; set; }
        private string XsdDomandeVariantePath { get; set; }
        internal SigefServiceOperazioni()
        {
            _dal = new DALClass();

            if (ConfigurationManager.AppSettings["progetto_schema_dir"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["progetto_schema_dir"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                XsdProgettiPath = rootPath;
            }

            if (ConfigurationManager.AppSettings["bando_schema_dir"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["bando_schema_dir"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                XsdProcedurePath = rootPath;
            }

            if (ConfigurationManager.AppSettings["domanda_pagamento_schema_dir"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["domanda_pagamento_schema_dir"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                XsdDomandePagamentoPath = rootPath;
            }

            if (ConfigurationManager.AppSettings["domanda_anticipo_schema_dir"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["domanda_anticipo_schema_dir"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                XsdDomandeAnticipoPath = rootPath;
            }

            if (ConfigurationManager.AppSettings["domanda_variante_schema_dir"] != null)
            {
                string relativePath = ConfigurationManager.AppSettings["domanda_variante_schema_dir"].ToString();
                string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                XsdDomandeVariantePath = rootPath;
            }
        }
        

        #region metodi per log progetti
        internal ResultInfoLogProgetti InsertImportServiceLogProgetti(ImportServiceLogProgetto importServiceLogProgetto) 
        {
            ResultInfoLogProgetti result = new ResultInfoLogProgetti();
            try
            {
                _dal.InsertImportServiceLogProgetti(importServiceLogProgetto);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogProgetto = importServiceLogProgetto.IdImportServiceLogProgetto;
                result.DataOperazione = importServiceLogProgetto.DataRichiesta;
                result.IdProgetto = importServiceLogProgetto.IdProgetto;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogProgetti UpdateImportServiceLogProgetti(ImportServiceLogProgetto importServiceLogProgetto)
        {
            ResultInfoLogProgetti result = new ResultInfoLogProgetti();
            try
            {
                _dal.UpdateImportServiceLogProgetti(importServiceLogProgetto);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogProgetto = importServiceLogProgetto.IdImportServiceLogProgetto;
                result.DataOperazione = importServiceLogProgetto.DataRichiesta;
                result.IdProgetto = importServiceLogProgetto.IdProgetto;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogProgetti DeleteImportServiceLogProgetti(int idProgetto)
        {
            ResultInfoLogProgetti result = new ResultInfoLogProgetti();
            try
            {
                _dal.DeleteImportServiceLogProgetti(idProgetto);
                result.Esito = "OK";
                result.DescrizioneEsito = "Record eliminato correttamente";
                result.IdImportServiceLogProgetto = null;
                result.DataOperazione = DateTime.Now;
                result.IdProgetto = null;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ImportServiceLogProgetto GetImportServiceLogProgettiById(int idImportServiceLogProgetto, bool getXmlRequest, bool getXmlResponse)
        {
            ImportServiceLogProgetto result = new ImportServiceLogProgetto();
            try
            {
                result = _dal.GetLogProgettoById(idImportServiceLogProgetto, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal List<ImportServiceLogProgetto> GetImportServiceLogProgettiByIdProgetto(int idProgetto, bool getXmlRequest, bool getXmlResponse)
        {
            List<ImportServiceLogProgetto> result = new List<ImportServiceLogProgetto>();
            try
            {
                result = _dal.GetLogProgettoByIdProgetto(idProgetto, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region metodi per log bandi

        internal ResultInfoLogBandi InsertImportServiceLogBandi(ImportServiceLogBando importServiceLogBando)
        {
            ResultInfoLogBandi result = new ResultInfoLogBandi();
            try
            {
                _dal.InsertImportServiceLogBandi(importServiceLogBando);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogBando = importServiceLogBando.IdImportServiceLogBando;
                result.DataOperazione = importServiceLogBando.DataRichiesta;
                result.IdBando = importServiceLogBando.IdBando;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogBandi UpdateImportServiceLogBandi(ImportServiceLogBando importServiceLogBando)
        {
            ResultInfoLogBandi result = new ResultInfoLogBandi();
            try
            {
                _dal.UpdateImportServiceLogBandi(importServiceLogBando);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogBando = importServiceLogBando.IdImportServiceLogBando;
                result.DataOperazione = importServiceLogBando.DataRichiesta;
                result.IdBando = importServiceLogBando.IdBando;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogBandi DeleteImportServiceLogBandi(int idBando)
        {
            ResultInfoLogBandi result = new ResultInfoLogBandi();
            try
            {
                _dal.DeleteImportServiceLogBandi(idBando);
                result.Esito = "OK";
                result.DescrizioneEsito = "Record eliminato correttamente";
                result.IdImportServiceLogBando = null;
                result.DataOperazione = DateTime.Now;
                result.IdBando = null;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ImportServiceLogBando GetImportServiceLogBandiById(int idImportServiceLogBando, bool getXmlRequest, bool getXmlResponse)
        {
            ImportServiceLogBando result = new ImportServiceLogBando();
            try
            {
                result = _dal.GetLogBandoById(idImportServiceLogBando, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal List<ImportServiceLogBando> GetImportServiceLogBandiByIdBando(int idBando, bool getXmlRequest, bool getXmlResponse)
        {
            List<ImportServiceLogBando> result = new List<ImportServiceLogBando>();
            try
            {
                result = _dal.GetLogBandoByIdBando(idBando, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region metodi per log domande di pagamento

        internal ResultInfoLogDomandePagamento InsertImportServiceLogDomandePagamento(ImportServiceLogDomandaPagamento importServiceLogDomandaPagamento)
        {
            ResultInfoLogDomandePagamento result = new ResultInfoLogDomandePagamento();
            try
            {
                _dal.InsertImportServiceLogDomandePagamento(importServiceLogDomandaPagamento);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogDomandaPagamento = importServiceLogDomandaPagamento.IdImportServiceLogDomandaPagamento;
                result.DataOperazione = importServiceLogDomandaPagamento.DataRichiesta;
                result.IdDomandaPagamento = importServiceLogDomandaPagamento.IdDomandaPagamento;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogDomandePagamento UpdateImportServiceLogDomandePagamento(ImportServiceLogDomandaPagamento importServiceLogDomandaPagamento)
        {
            ResultInfoLogDomandePagamento result = new ResultInfoLogDomandePagamento();
            try
            {
                _dal.UpdateImportServiceLogDomandePagamento(importServiceLogDomandaPagamento);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogDomandaPagamento = importServiceLogDomandaPagamento.IdImportServiceLogDomandaPagamento;
                result.DataOperazione = importServiceLogDomandaPagamento.DataRichiesta;
                result.IdDomandaPagamento = importServiceLogDomandaPagamento.IdDomandaPagamento;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogDomandePagamento DeleteImportServiceLogDomandePagamento(int idDomandaPagamento)
        {
            ResultInfoLogDomandePagamento result = new ResultInfoLogDomandePagamento();
            try
            {
                _dal.DeleteImportServiceLogDomandePagamento(idDomandaPagamento);
                result.Esito = "OK";
                result.DescrizioneEsito = "Record eliminato correttamente";
                result.IdImportServiceLogDomandaPagamento = null;
                result.DataOperazione = DateTime.Now;
                result.IdDomandaPagamento = null;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        #endregion


        #region metodi per log varianti
        internal ResultInfoLogVarianti InsertImportServiceLogVarianti(ImportServiceLogVariante importServiceLogVariante)
        {
            ResultInfoLogVarianti result = new ResultInfoLogVarianti();
            try
            {
                _dal.InsertImportServiceLogVarianti(importServiceLogVariante);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogVariante = importServiceLogVariante.IdImportServiceLogVariante;
                result.DataOperazione = importServiceLogVariante.DataRichiesta;
                result.IdVariante = importServiceLogVariante.IdVariante;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogVarianti UpdateImportServiceLogVarianti(ImportServiceLogVariante importServiceLogVariante)
        {
            ResultInfoLogVarianti result = new ResultInfoLogVarianti();
            try
            {
                _dal.UpdateImportServiceLogVarianti(importServiceLogVariante);
                result.Esito = "OK";
                result.DescrizioneEsito = "Salvataggio avvenuto correttamente";
                result.IdImportServiceLogVariante = importServiceLogVariante.IdImportServiceLogVariante;
                result.DataOperazione = importServiceLogVariante.DataRichiesta;
                result.IdVariante = importServiceLogVariante.IdVariante;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ResultInfoLogVarianti DeleteImportServiceLogVarianti(int idVariante)
        {
            ResultInfoLogVarianti result = new ResultInfoLogVarianti();
            try
            {
                _dal.DeleteImportServiceLogVarianti(idVariante);
                result.Esito = "OK";
                result.DescrizioneEsito = "Record eliminato correttamente";
                result.IdImportServiceLogVariante = null;
                result.DataOperazione = DateTime.Now;
                result.IdVariante = null;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataOperazione = DateTime.Now;
                throw ex;
            }
        }

        internal ImportServiceLogVariante GetImportServiceLogVariantiById(int idImportServiceLogVariante, bool getXmlRequest, bool getXmlResponse)
        {
            ImportServiceLogVariante result = new ImportServiceLogVariante();
            try
            {
                result = _dal.GetLogVarianteById(idImportServiceLogVariante, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal List<ImportServiceLogVariante> GetImportServiceLogVariantiByIdVariante(int idVariante, bool getXmlRequest, bool getXmlResponse)
        {
            List<ImportServiceLogVariante> result = new List<ImportServiceLogVariante>();
            try
            {
                result = _dal.GetLogVarianteByIdVariante(idVariante, getXmlRequest, getXmlResponse);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region commons

        internal readonly Dictionary<string, string> CodiciErrore = new Dictionary<string, string>()
        {
            {"1000", "Validazione tracciato xml del bando non riuscita: "},
            {"1010", "Il SistemaMittente non è tra i sistemi censiti o non è abilitato"},
            {"1020", "Codice Struttura non esistente in SIGEF"},
            {"1030", "DataApertura maggiore della DataScadenza"},
            {"1040", "Codice Programmazione non presente in Sigef"},
            {"1050", "Codice Intervento non presente in Sigef"},
            {"1060", "Dati Protocollo: CodiceStruttura non presente in Sigef"},
            {"1070", "CodiceFiscaleResponsabile non presente in banca dati Sigef"},
            {"1080", "Investimenti: codici Intervento non congruenti con Codici Intervento configurati nella procedura di attivazione"},
            {"1200", "Validazione tracciato xml del progetto non riuscita: "},
            {"1210", "Il SistemaMittente non è tra i sistemi censiti o non è abilitato"},
            {"1220", "Id della procedura di Attivazione Sigef non presente tra le procedure importate"},
            {"1230", "DataPresentazione non coerente con date di apertura e chiusura della procedura di attivazione"},
            {"1240", "Nessun beneficiario presente nel tracciato"},
            {"1250", "RelazioneTecnica: titolo e descrizione paragrafi non coerente con elenco della procedura di attivazione"},
            {"1260", "PianoInvestimenti: codici intervento programmazione non coerenti con quelli presenti nella procedura di attivazione"},
            {"1270", "PianoInvestimenti: codice investimento non presente nella procedura di attivazione"},
            {"1280", "DatiMonitoraggio: ATECO2007 non presente tra i codici ammessi nella procedura di attivazione"},
            {"1290", "RequisitiProgetto: ChiaveDescrizione non presenti nell'elenco della procedura di attivazione"},
            {"1300", "DescrizioneDichiarazione non coerente con l'elenco delle dichiarazioni della procedura di attivazione"},
            {"1310", "AllegatiProgetto: categoria e descrizione non presenti nell'elenco della procedura di attivazione"},
            {"1500", "Validazione tracciato xml della domanda pagamento non riuscita: "},
            {"1510", "Id del progetto associato alla domanda di pagamento non presente in banca dati"},
            {"1520", "Il progetto associato alla domanda di pagamento non è in stato finanziabile"},
            {"1530", "Nessuna voce di rendicontazione presente nel tracciato"},
            {"1540", "Non è possibile presentare una domanda di anticipo se è già presente un Sal o un Saldo"},
            {"1600", "Id del progetto associato alla variante non presente in banca dati"},
            {"1610", "Il progetto associato alla variante non è in stato finanziabile"},
            {"1620", "La variante non è importabile per il seguente motivo: "},
            {"9000", "Si è verificato un errore nella deserializzazione dell'istanza: " },
            {"9999", "Si è verificato il seguente errore durante la procedura di inserimento in banca dati: " }
        };

        internal ImportServiceSistemaCensito GetImportServiceSistemaCensitoByCodice(string codiceSistema)
        {
            ImportServiceSistemaCensito result = new ImportServiceSistemaCensito();
            try
            {
                result = _dal.GetSistemaCensitoByCodice(codiceSistema);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal XDocument GetXDocument(string istanza) 
        {
            try
            {
                return XDocument.Parse(istanza);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal ErroreType SetError(string codErrore, string message)
        {
            ErroreType error = new ErroreType();
            error.Codice = codErrore;
            error.DescrizioneErrore = CodiciErrore[codErrore];
            error.Messaggio = message;
            return error;
        }

        internal ErroreType SetError(string codErrore)
        {
            ErroreType error = new ErroreType();
            error.Codice = codErrore;
            error.DescrizioneErrore = CodiciErrore[codErrore];
            error.Messaggio = null;
            return error;
        }

        internal string ValidateSchema(XDocument istanza, string schema)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            bool errors = false;
            string errorMessage = string.Empty;

            schemas.Add(null, schema);
            istanza.Validate(schemas, (o, e) =>
            {
                errorMessage += e.Exception.Message + "|";
                errors = true;
            });
            return errors ? errorMessage: "OK";
        }

        internal AuthInfo GetCredentials(string username, string password)
        {
            AuthInfo authInfo = new AuthInfo();
            authInfo = _dal.GetCredentials(username, password);
            return authInfo;
        }
        
        #endregion


        #region validazione istanze bandi 
        
        // Validazione istanza del bando secondo lo schema 
        internal string ValidateIstanzaBando(XDocument istanza)
        {
            //try
            //{
            //    return ValidateSchema(istanza, XsdProcedurePath);
            //}
            //catch (Exception ex)
            //{
            //    string msg = "ERR 1000: validazione del tracciato xml non riuscita: " + ex.Message;
            //    throw new Exception(msg, ex);
            //}
            return ValidateSchema(istanza, XsdProcedurePath);

        }

        internal ProceduraAttivazioneResultInfo ValidateDatiProceduraAttivazione(string istanza)
        {
            ProceduraAttivazioneResultInfo result = new ProceduraAttivazioneResultInfo();
            string errors = string.Empty;
            Errori errori = new Errori();        
            
            try
            {
                //{ "ERR 1000", "validazione del tracciato xml non riuscita"},
                string msg = ValidateIstanzaBando(GetXDocument(istanza));
                if (msg != "OK")
                {
                    errori.Errore.Add(SetError("1000", msg));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                var proceduraAttivazione = new ProceduraAttivazione();
                var deserializeException = new Exception();

                bool canDeserialize = ProceduraAttivazione.Deserialize(istanza, out proceduraAttivazione, out deserializeException);
                if (!canDeserialize)
                {
                    errori.Errore.Add(SetError("9000", deserializeException.Message));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                
                //{ "ERR 1010", "Il SistemaMittente non è tra i sistemi censiti o non è abilitato"},
                ImportServiceSistemaCensito sistema = GetImportServiceSistemaCensitoByCodice(proceduraAttivazione.DatiGenerali.SistemaMittente);
                if(sistema == null)
                {
                    errori.Errore.Add(SetError("1010"));
                }


                //{ "ERR 1020", "Codice Struttura non esistente in SIGEF"},
                EnteCollectionProvider entiProv = new EnteCollectionProvider();
                var enti = entiProv.Find(proceduraAttivazione.DatiGenerali.CodiceStruttura, null, true);
                
                if (enti != null)
                {
                    if(enti.Count == 0)
                    {
                        errori.Errore.Add(SetError("1020"));
                    }
                }

                //{ "ERR 1030", "DataApertura maggiore della DataScadenza"},
                if(proceduraAttivazione.DatiGenerali.DataOraApertura > proceduraAttivazione.DatiGenerali.DataOraScadenza)
                {
                    errori.Errore.Add(SetError("1030"));
                }

                //{ "ERR 1040", "Codice Programmazione non presente in Sigef"},
                ZpsrCollectionProvider programmiProv = new ZpsrCollectionProvider();
                var programmi = programmiProv.Select(proceduraAttivazione.DatiGenerali.Programmazione.Fondo, null, null, null, null, null);
                if (programmi != null)
                {
                    if(programmi.Count == 0)
                    {
                        errori.Errore.Add(SetError("1040"));
                    }
                }

                //{ "ERR 1050", "Codice Intervento non presente in Sigef"},
                string fondo = proceduraAttivazione.DatiGenerali.Programmazione.Fondo;
                ZprogrammazioneCollectionProvider interventiProv = new ZprogrammazioneCollectionProvider();
                var interventiSigef = new ZprogrammazioneCollection();
                foreach(InterventoType i in proceduraAttivazione.DatiGenerali.Programmazione.Interventi.Intervento)
                {
                    interventiSigef = interventiProv.Find(i.CodiceIntervento, null, fondo, null, null, null);
                    if(interventiSigef != null)
                    {
                        if(interventiSigef.Count == 0)
                        {
                            errori.Errore.Add(SetError("1050"));
                        }
                    }
                }

                //{ "ERR 1060", "Dati Protocollo: CodiceStruttura non presente in Sigef"},
                var entiProt = entiProv.Find(proceduraAttivazione.DatiGenerali.DatiProtocollo.Atto.CodiceStruttura, null, true);

                if (entiProt != null)
                {
                    if (entiProt.Count == 0)
                    {
                        errori.Errore.Add(SetError("1060"));
                    }
                }

                //{ "ERR 1070", "CodiceFiscaleResponsabile non presente in banca dati Sigef"},
                UtentiCollectionProvider utentiProv = new UtentiCollectionProvider();
                var utenti = utentiProv.Find(proceduraAttivazione.DatiGenerali.CodiceFiscaleResponsabileProcedura, null, null, null, null, null, true);
                if(utenti != null)
                {
                    if(utenti.Count == 0)
                    {
                        errori.Errore.Add(SetError("1070"));
                    }
                }

                //{ "ERR 1080", "Investimenti: codici Intervento non congruenti con Codici Intervento configurati nella procedura di attivazione"}
                ErroreType er1080 = new ErroreType();


                if(errori.Errore.Count == 0)
                {
                    result.Esito = "OK";
                    //inserimento procedura di attivazione in banca dati
                    try
                    {
                        //inserimento dati
                        result.IdProceduraAttivazione = _dal.InsertProceduraAttivazioneByService(proceduraAttivazione);
                    }
                    catch (Exception ex)
                    {

                        result.Esito = "KO";
                        errori.Errore.Add(SetError("9999", ex.Message));
                        result.Errors = errori.Serialize();
                    }
                }
                else
                {
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region validazione istanze progetti 

        // Validazione istanza del progetto secondo lo schema 
        private string ValidateIstanzaProgetto(XDocument istanza)
        {
            try
            {
                return ValidateSchema(istanza, XsdProgettiPath);
            }
            catch (Exception ex)
            {
                string msg = "ERR 1200: validazione del tracciato xml non riuscita: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

        internal ProgettoResultInfo ValidateDatiProgetto(string istanza)
        {
            ProgettoResultInfo result = new ProgettoResultInfo();
            string errors = string.Empty;
            Errori errori = new Errori();
            //Progetto progetto = new Progetto();
            
            try
            {
                //{ "ERR 1200", "validazione del tracciato xml non riuscita"},
                string msg = ValidateIstanzaProgetto(GetXDocument(istanza));
                if (msg != "OK")
                {
                    errori.Errore.Add(SetError("1200", msg));
                }


                var progetto = new Progetto();
                var deserializeException = new Exception();

                bool canDeserialize = Progetto.Deserialize(istanza, out progetto, out deserializeException);
                if (!canDeserialize)
                {
                    errori.Errore.Add(SetError("9000", deserializeException.Message));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                int idBandoSigef = progetto.DatiGenerali.IdBandoSigef;

                //{ "ERR 1210", "Il SistemaMittente non è tra i sistemi censiti"},
                ImportServiceSistemaCensito sistema = GetImportServiceSistemaCensitoByCodice(progetto.DatiGenerali.SistemaMittente);
                if (sistema == null)
                {
                    errori.Errore.Add(SetError("1210"));
                }

                //{ "ERR 1220", "Id della procedura di Attivazione Sigef non presente tra le procedure importate"},
                var log = GetImportServiceLogBandiByIdBando(idBandoSigef, false, false);
                if (log == null)
                {
                    errori.Errore.Add(SetError("1220"));
                }

                //{ "ERR 1230", "DataPresentazione non coerente con date di apertura e chiusura della procedura di attivazione"},
                BandoCollectionProvider bandoProv = new BandoCollectionProvider();
                Bando bando = bandoProv.GetById(idBandoSigef);
                if (bando != null)
                {
                    if((progetto.DatiGenerali.DataPresentazione < bando.DataApertura) || (progetto.DatiGenerali.DataPresentazione > bando.DataScadenza))
                    {
                        errori.Errore.Add(SetError("1230"));
                    }
                }

                //{ "ERR 1240", "Nessun beneficiario presente nel tracciato"},
                if((progetto.Beneficiari == null) || (progetto.Beneficiari != null && progetto.Beneficiari.Beneficiario.Count == 0))
                {
                    errori.Errore.Add(SetError("1240"));
                }

                //{ "ERR 1250", "RelazioneTecnica: titolo e descrizione paragrafi non coerente con elenco della procedura di attivazione"},
                BandoRelazioneTecnicaCollectionProvider relazioneProv = new BandoRelazioneTecnicaCollectionProvider();
                List<BandoRelazioneTecnica> paragrafi = relazioneProv.Find(idBandoSigef).ToArrayList<BandoRelazioneTecnica>();
                int er = 0;
                if(paragrafi != null && paragrafi.Count > 0)
                {
                    if(paragrafi.Count != progetto.RelazioneTecnica.Compilazione.Count)
                    {
                        er++;
                    }
                    foreach(ProgettoRelazioneTecnicaCompilazione item in progetto.RelazioneTecnica.Compilazione)
                    {
                        if(paragrafi.FindAll(x => x.Titolo == item.Paragrafo.Titolo && x.Descrizione == item.Paragrafo.Descrizione).Count == 0)
                        {
                            er++;
                        }
                    }
                }
                if (er > 0)
                {
                    errori.Errore.Add(SetError("1250"));
                }

                //{ "ERR 1260", "PianoInvestimenti: codici intervento programmazione non coerenti con quelli presenti nella procedura di attivazione"},
                BandoProgrammazioneCollectionProvider bandoProgProv = new BandoProgrammazioneCollectionProvider();
                List<BandoProgrammazione> bandoProg = bandoProgProv.Find(idBandoSigef, null,null,null).ToArrayList<BandoProgrammazione>();
                List<string> interventi = progetto.PianoInvestimenti.Investimento.Select(x => x.CodiceProgrammazione).Distinct().ToList();
                er = 0;
                if (bandoProg != null && bandoProg.Count > 0)
                {
                    foreach(string item in interventi)
                    {
                        if(bandoProg.FindAll(x => x.Codice == item).Count == 0) 
                        { 
                            er++;
                        }
                    }
                }
                if (er > 0)
                {
                    errori.Errore.Add(SetError("1260"));
                }

                //{ "ERR 1270", "PianoInvestimenti: codice investimento non presente nella procedura di attivazione"},
                CodificaInvestimentoCollectionProvider codInvestimentiProv = new CodificaInvestimentoCollectionProvider();
                List<CodificaInvestimento> codInvestimenti = codInvestimentiProv.Find(idBandoSigef, null).ToArrayList<CodificaInvestimento>();
                er = 0;
                if (codInvestimenti != null && codInvestimenti.Count > 0)
                {
                    List<string> codici = codInvestimenti.Select(x => x.Codice.ToString()).ToList();
                    foreach(InvestimentoType item in progetto.PianoInvestimenti.Investimento)
                    {
                        string t = item.CodiceInvestimento;
                        var res = codici.FindAll(x => x.Trim() == item.CodiceInvestimento);
                        if (codici.FindAll(x => x.Trim() == item.CodiceInvestimento).Count == 0)
                        {
                            er++;
                        }
                    }
                }
                if (er > 0)
                {
                    errori.Errore.Add(SetError("1270"));
                }

                //{ "ERR 1280", "DatiMonitoraggio: ATECO2007 non presente tra i codici ammessi nella procedura di attivazione"},
                BandoAteco2007CollectionProvider bandoAtecoProv = new BandoAteco2007CollectionProvider();
                List<BandoAteco2007> ateco = bandoAtecoProv.Find(idBandoSigef, null).ToArrayList<BandoAteco2007>();
                if (ateco != null && ateco.Count > 0)
                {
                    if(ateco.FindAll(x => x.IdAteco2007 == progetto.DatiMonitoraggio.CodiceATECO2007).Count() == 0) 
                    {
                        errori.Errore.Add(SetError("1280"));
                    }
                }

                //{ "ERR 1290", "RequisitiProgetto: ChiaveDescrizione non presenti nell'elenco della procedura di attivazione"},


                //{ "ERR 1300", "DescrizioneDichiarazione non coerente con l'elenco delle dichiarazioni della procedura di attivazione"},
                DichiarazioniXDomandaCollectionProvider dicProv = new DichiarazioniXDomandaCollectionProvider();
                ModelloDomandaCollectionProvider modelProv = new ModelloDomandaCollectionProvider();
                List<ModelloDomanda> modelloDomanda = modelProv.Find(null, idBandoSigef, null).ToArrayList<ModelloDomanda>();
                er = 0;
                if (modelloDomanda != null && modelloDomanda.Count > 0)
                {
                    List<DichiarazioniXDomanda> dichiarazioniDomanda = dicProv.Find(null, modelloDomanda.First().IdDomanda).ToArrayList<DichiarazioniXDomanda>();
                    foreach (string item in progetto.DichiarazioniProgetto.DescrizioneDichiarazione)
                    {
                        if(dichiarazioniDomanda.FindAll(x => x.Descrizione == item).Count == 0)
                        {
                            er++;
                        }
                    }
                }
                if (er > 0)
                {
                    errori.Errore.Add(SetError("1300"));
                }

                //{ "ERR 1310", "AllegatiProgetto: categoria e descrizione non presenti nell'elenco della procedura di attivazione"}



                //Verifica finale e inserimento in banca dati
                if (errori.Errore.Count == 0)
                {
                    result.Esito = "OK";
                    //inserimento progetto in banca dati
                    try
                    {
                        //inserimento dati
                        result.IdProgetto = _dal.InsertProgettoByService(progetto);
                    }
                    catch (Exception ex)
                    {

                        result.Esito = "KO";
                        errori.Errore.Add(SetError("9999", ex.Message));
                        result.Errors = errori.Serialize();
                    }
                }
                else
                {
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                }
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region validazione istanze domande di pagamento

        private string ValidateIstanzaDomandaPagamento(XDocument istanza)
        {
            try
            {
                return ValidateSchema(istanza, XsdDomandePagamentoPath);
            }
            catch (Exception ex)
            {
                string msg = "ERR 1500: validazione del tracciato xml non riuscita: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

        internal DomandaPagamentoResultInfo ValidateDatiDomandaPagamento(string istanza)
        {
            DomandaPagamentoResultInfo result = new DomandaPagamentoResultInfo();
            string errors = string.Empty;
            Errori errori = new Errori();

            try
            {

                //{ "ERR 1500", "validazione del tracciato xml non riuscita"},
                string msg = ValidateIstanzaDomandaPagamento(GetXDocument(istanza));
                if (msg != "OK")
                {
                    errori.Errore.Add(SetError("1500", msg));
                }

                var domandaPagamento = new DomandaPagamento();
                var deserializeException = new Exception();

                bool canDeserialize = DomandaPagamento.Deserialize(istanza, out domandaPagamento, out deserializeException);
                if (!canDeserialize)
                {
                    errori.Errore.Add(SetError("9000", deserializeException.Message));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                int idProgettoSigef = domandaPagamento.DatiGenerali.IdProgettoSigef;
                                
                //{ "ERR 1210", "Il SistemaMittente non è tra i sistemi censiti"},
                ImportServiceSistemaCensito sistema = GetImportServiceSistemaCensitoByCodice(domandaPagamento.DatiGenerali.SistemaMittente);
                if (sistema == null)
                {
                    errori.Errore.Add(SetError("1210"));
                }

                //{ "1510", "Id del progetto associato alla domanda di pagamento non presente in banca dati"},
                var progetto = new ProgettoCollectionProvider().GetById(idProgettoSigef);
                if (progetto == null)
                {
                    errori.Errore.Add(SetError("1510"));
                }

                //{ "1520", "Il progetto associato alla domanda di pagamento non è in stato finanziabile"},
                if (progetto != null)
                {
                    if(progetto.OrdineFase < 4)
                        errori.Errore.Add(SetError("1520"));
                }

                //{ "1530", "Nessuna voce di rendicontazione presente nel tracciato"},
                if((domandaPagamento.Rendicontazione.VoceSpesa == null) || ((domandaPagamento.Rendicontazione.VoceSpesa != null) &&(domandaPagamento.Rendicontazione.VoceSpesa.Count == 0)))
                {
                    errori.Errore.Add(SetError("1530"));
                }

                //{"1540", "Non è possibile presentare una domanda di anticipo se è già presente un Sal o un Saldo"},
                if (Enum.GetName(typeof(DatiGeneraliDomandaPagamentoTypeTipoDomanda), domandaPagamento.DatiGenerali.TipoDomanda) == "ANT" && progetto.OrdineFase > 5)
                {
                    errori.Errore.Add(SetError("1540"));
                }


                if (errori.Errore.Count == 0)
                {
                    result.Esito = "OK";
                    //inserimento domanda pagamento in banca dati
                    try
                    {
                        //inserimento dati
                        result.IdDomandaPagamento = _dal.InsertDomandaPagamentoByService(domandaPagamento);
                    }
                    catch (Exception ex)
                    {

                        result.Esito = "KO";
                        errori.Errore.Add(SetError("9999", ex.Message));
                        result.Errors = errori.Serialize();
                    }
                }
                else
                {
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region validazione istanze domande di anticipo

        private string ValidateIstanzaDomandaAnticipo(XDocument istanza)
        {
            try
            {
                return ValidateSchema(istanza, XsdDomandeAnticipoPath);
            }
            catch (Exception ex)
            {
                string msg = "ERR 1500: validazione del tracciato xml non riuscita: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

        internal DomandaPagamentoResultInfo ValidateDatiDomandaAnticipo(string istanza)
        {
            DomandaPagamentoResultInfo result = new DomandaPagamentoResultInfo();
            string errors = string.Empty;
            Errori errori = new Errori();

            try
            {

                //{ "ERR 1500", "validazione del tracciato xml non riuscita"},
                string msg = ValidateIstanzaDomandaAnticipo(GetXDocument(istanza));
                if (msg != "OK")
                {
                    errori.Errore.Add(SetError("1500", msg));
                }

                var domandaAnticipo = new DomandaAnticipo();
                var deserializeException = new Exception();

                bool canDeserialize = DomandaAnticipo.Deserialize(istanza, out domandaAnticipo, out deserializeException);
                if (!canDeserialize)
                {
                    errori.Errore.Add(SetError("9000", deserializeException.Message));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                int idProgettoSigef = domandaAnticipo.DatiGenerali.IdProgettoSigef;

                //{ "ERR 1210", "Il SistemaMittente non è tra i sistemi censiti"},
                ImportServiceSistemaCensito sistema = GetImportServiceSistemaCensitoByCodice(domandaAnticipo.DatiGenerali.SistemaMittente);
                if (sistema == null)
                {
                    errori.Errore.Add(SetError("1210"));
                }

                //{ "1510", "Id del progetto associato alla domanda di pagamento non presente in banca dati"},
                var progetto = new ProgettoCollectionProvider().GetById(idProgettoSigef);
                if (progetto == null)
                {
                    errori.Errore.Add(SetError("1510"));
                }

                //{ "1520", "Il progetto associato alla domanda di pagamento non è in stato finanziabile"},
                if (progetto != null)
                {
                    if (progetto.OrdineFase < 4)
                        errori.Errore.Add(SetError("1520"));
                }

                

                //{"1540", "Non è possibile presentare una domanda di anticipo se è già presente un Sal o un Saldo"},
                if (progetto.OrdineFase > 5)
                {
                    errori.Errore.Add(SetError("1540"));
                }


                if (errori.Errore.Count == 0)
                {
                    result.Esito = "OK";
                    //inserimento domanda pagamento in banca dati
                    try
                    {
                        //inserimento dati
                        result.IdDomandaPagamento = _dal.InsertDomandaPagamentoAnticipoByService(domandaAnticipo);
                    }
                    catch (Exception ex)
                    {

                        result.Esito = "KO";
                        errori.Errore.Add(SetError("9999", ex.Message));
                        result.Errors = errori.Serialize();
                    }
                }
                else
                {
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region validazione istanze domande di variante

        private string ValidateIstanzaDomandaVariante(XDocument istanza)
        {
            try
            {
                return ValidateSchema(istanza, XsdDomandeVariantePath);
            }
            catch (Exception ex)
            {
                string msg = "ERR 1500: validazione del tracciato xml non riuscita: " + ex.Message;
                throw new Exception(msg, ex);
            }
        }

        internal DomandaVarianteResultInfo ValidateDatiDomandaVariante(string istanza)
        {
            DomandaVarianteResultInfo result = new DomandaVarianteResultInfo();
            string errors = string.Empty;
            Errori errori = new Errori();

            try
            {

                //{ "ERR 1500", "validazione del tracciato xml non riuscita"},
                string msg = ValidateIstanzaDomandaVariante(GetXDocument(istanza));
                if (msg != "OK")
                {
                    errori.Errore.Add(SetError("1500", msg));
                }

                var variante = new Variante();
                var deserializeException = new Exception();

                bool canDeserialize = Variante.Deserialize(istanza, out variante, out deserializeException);
                if (!canDeserialize)
                {
                    errori.Errore.Add(SetError("9000", deserializeException.Message));
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                    return result;
                }

                int idProgettoSigef = variante.DatiGenerali.IdProgettoSigef;

                //{ "ERR 1210", "Il SistemaMittente non è tra i sistemi censiti"},
                ImportServiceSistemaCensito sistema = GetImportServiceSistemaCensitoByCodice(variante.DatiGenerali.SistemaMittente);
                if (sistema == null)
                {
                    errori.Errore.Add(SetError("1210"));
                }

                //{"1600", "Id del progetto associato alla variante non presente in banca dati"},
                var progetto = new ProgettoCollectionProvider().GetById(idProgettoSigef);
                if (progetto == null)
                {
                    errori.Errore.Add(SetError("1600"));
                }

                //{"1610", "Il progetto associato alla variante non è in stato finanziabile"},
                if (progetto != null)
                {
                    if (progetto.OrdineFase < 4)
                        errori.Errore.Add(SetError("1610"));
                }



                //{"1620", "La variante non è importabile per il seguente motivo: "},
                string errore = new SiarBLL.DomandaDiPagamentoCollectionProvider().ControlloVarianteRilasciabile(progetto.IdProgetto, true, true);
                if (!string.IsNullOrEmpty(errore))
                {
                    errori.Errore.Add(SetError("1620", errore));
                }


                if (errori.Errore.Count == 0)
                {
                    result.Esito = "OK";
                    //inserimento variante in banca dati
                    try
                    {
                        //inserimento dati
                        result.IdVariante = _dal.InsertDomandaVarianteByService(variante);
                    }
                    catch (Exception ex)
                    {

                        result.Esito = "KO";
                        errori.Errore.Add(SetError("9999", ex.Message));
                        result.Errors = errori.Serialize();
                    }
                }
                else
                {
                    result.Esito = "KO";
                    result.Errors = errori.Serialize();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}