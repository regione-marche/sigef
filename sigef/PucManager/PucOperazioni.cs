using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using Ionic.Zip;

namespace PucManager
{
    public partial class PucOperazioni
    {
        private string _IdSistema { get; set;}
        private string _IdAmministrazione { get; set; }

        private const string sharp = "#";
        private const string pipe = "|";

        public PucOperazioni()
        {
            _IdSistema = ConfigurationManager.AppSettings["IgrueIdSistema"].ToString();
            _IdAmministrazione = ConfigurationManager.AppSettings["IgrueIdAmministrazione"].ToString();

        }

        //public string GetCodProceduraAttivazione(int IdBando)
        public ResultInfoAssegnazione GetCodProceduraAttivazione(int IdBando)
        {
            try
            {
                string codice = string.Empty;
                var result = new ResultInfoAssegnazione();
                var ws = new CallWS();
                //codice = ws.GetCodProceduraAttivazioneWs();
                result = ws.GetCodProceduraAttivazioneWs();
                //return codice;
                return result;
            }
            catch (Exception ex)
            {               
                throw ex;
            }

        }

        internal string GetHeaderRow(int records)
        {
            string header = "HH" + sharp + "0" + sharp + _IdSistema + _IdAmministrazione + sharp + "PUC" + sharp + records.ToString() + sharp;
            return header;
        }

        internal string GetFooterRow(int records)
        {
            records++;
            string footer = "FF" + sharp + records.ToString() + sharp;
            return footer;
        }

        public ResultInfo InviaMonitoraggio(DateTime? DataDa, DateTime? DataA, string NomeFile, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = DataDa;
                    invio.DATA_A = DataA;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = NomeFile;
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);

                    //Inserisco i dati di monitoraggio nelle tabelle lanciando le sp passando ID_INVIO
                    dal.InsertDatiMonitoraggio(invio.DATA_DA, invio.DATA_A, NomeFile, invio.ID_INVIO, null, CodiceFondo);

                    //Recupero i dati dalla tabella con lo specifico ID_INVIO
                    var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);
                    
                    //Creo il file di invio                   
                    var rowCount = 0;
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    string row = "";
                    //creo il file solo se il numero di record > 0
                    if (dtable.Rows.Count > 0)
                    {
                        var last = dtable.Columns.IndexOf("FLG_CANCELLAZIONE") < 0 ? dtable.Columns.IndexOf("OPERAZIONE")-1 : dtable.Columns.IndexOf("FLG_CANCELLAZIONE");
                        foreach (System.Data.DataRow item in dtable.Rows)
                        {
                            rowCount++;
                            if (!NomeFile.StartsWith("TR"))
                            {
                                row = NomeFile + sharp;
                                row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp;
                                for (int i = 1; i <= last; i++)
                                {
                                    row += item[i] + pipe;
                                }
                            }
                            else
                            {
                                row = NomeFile + sharp;
                                row += item["NR_RIGA_INVIO"].ToString() + sharp + item[0] + sharp + item[1] + sharp + item[2] + sharp;
                                for (int i = 3; i <= last; i++)
                                {
                                    row += FileUtility.NormalizzaDato(item[i]) + pipe;
                                }
                            }
                            recBuilder.AppendLine(row.Remove(row.Length - 1, 1) + sharp);
                            row = "";
                        }
                        fileBuilder.AppendLine(GetHeaderRow(rowCount));
                        fileBuilder.Append(recBuilder.ToString());
                        fileBuilder.Append(GetFooterRow(rowCount));

                        //Zippo il file di invio
                        var expfile = "igrue_" + NomeFile + "_" + invio.ID_INVIO.ToString() + ".txt";
                        var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                        invio.FILE_INVIO = t;

                        //aggiorno il record di invio inserendo in db il file compresso
                        dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                        //Invoco il ws di prenotazione e invio
                        var ws = new CallWS();
                        result = ws.SendFile(t);

                        //recupero il ticket e aggiorno il record di invio 
                        invio.CODICE_ESITO = result.CodiceEsito;
                        invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                        invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                        invio.ID_TICKET = ws.Ticket;
                        invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                        invio.ID_OPERATORE = 0;
                        dal.UpdateInvioMonitoraggio(invio);
                    }
                    
                    ts.Complete();
                }

                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ResultInfo InviaMonitoraggio(DateTime? DataDa, DateTime? DataA, string[] Files, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = DataDa;
                    invio.DATA_A = DataA;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = string.Join(",", Files);
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    var lfiles = Files.ToList();
                    int records = 0;
                    foreach (string NomeFile in lfiles)
                    {
                        //Inserisco i dati di monitoraggio nelle tabelle lanciando le sp passando ID_INVIO
                        int filerecords = dal.InsertDatiMonitoraggio(invio.DATA_DA, invio.DATA_A, NomeFile, invio.ID_INVIO, records, CodiceFondo);

                        records = filerecords > 0 ? filerecords : records;

                        //Recupero i dati dalla tabella con lo specifico ID_INVIO
                        var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);

                        //var file = FileUtility.GeneraFileNoHF(dtable,NomeFile);
                        var file = FileUtility.GeneraFile(dtable, NomeFile, false);
                        if (!string.IsNullOrEmpty(file))
                        {
                            recBuilder.Append(file);
                        }
                    }
                    
                    fileBuilder.AppendLine(FileUtility.GetHeaderRow(records));
                    fileBuilder.Append(recBuilder.ToString());
                    fileBuilder.Append(FileUtility.GetFooterRow(records));

                    //Zippo il file di invio
                    var expfile = "igrue_XX_" + invio.ID_INVIO.ToString() + ".txt";
                    var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                    invio.FILE_INVIO = t;

                    //aggiorno il record di invio inserendo in db il file compresso
                    dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                    //Invoco il ws di prenotazione e invio
                    var ws = new CallWS();
                    result = ws.SendFile(t);

                    //recupero il ticket e aggiorno il record di invio 
                    invio.CODICE_ESITO = result.CodiceEsito;
                    invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                    invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                    invio.ID_TICKET = ws.Ticket;
                    invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                    invio.ID_OPERATORE = 0;
                    dal.UpdateInvioMonitoraggio(invio);
                
                    ts.Complete();                    
                }

                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ResultInfo InviaMonitoraggio(DateTime? DataDa, DateTime? DataA, string[] Files, string IdProgetti, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = DataDa;
                    invio.DATA_A = DataA;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = string.Join(",", Files);
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    var lfiles = Files.ToList();
                    int records = 0;
                    foreach (string NomeFile in lfiles)
                    {
                        //Inserisco i dati di monitoraggio nelle tabelle lanciando le sp passando ID_INVIO
                        int filerecords = dal.InsertDatiMonitoraggio(invio.DATA_DA, invio.DATA_A, NomeFile, invio.ID_INVIO, records, IdProgetti, CodiceFondo);

                        records = filerecords > 0 ? filerecords : records;

                        //Recupero i dati dalla tabella con lo specifico ID_INVIO
                        var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);

                        //var file = FileUtility.GeneraFileNoHF(dtable,NomeFile);
                        var file = FileUtility.GeneraFile(dtable, NomeFile, false);
                        if (!string.IsNullOrEmpty(file))
                        {
                            recBuilder.Append(file);
                        }
                    }

                    fileBuilder.AppendLine(FileUtility.GetHeaderRow(records));
                    fileBuilder.Append(recBuilder.ToString());
                    fileBuilder.Append(FileUtility.GetFooterRow(records));                   

                    //Zippo il file di invio
                    var expfile = "igrue_Singolo_" + invio.ID_INVIO.ToString() + ".txt";
                    var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                    invio.FILE_INVIO = t;

                    //aggiorno il record di invio inserendo in db il file compresso
                    dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                    //Invoco il ws di prenotazione e invio
                    var ws = new CallWS();

                    result = ws.SendFile(t);

                    ////utilizzare questa sezione per testare il metodo e bypassare la chiamata al ws (commentare la riga sopra che invoca SendFile(file))
                    //result.CodiceEsito = 0;
                    //result.DescrizioneEsito = "OK";
                    //result.DettaglioEsito = "ID Salvataggio: 999999";
                    //ws.Ticket = "999999";
                    //result.TimeStampEsito = System.DateTime.Now;

                    //recupero il ticket e aggiorno il record di invio 
                    invio.CODICE_ESITO = result.CodiceEsito;
                    invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                    invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                    invio.ID_TICKET = ws.Ticket;
                    invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                    invio.ID_OPERATORE = 0;
                    dal.UpdateInvioMonitoraggio(invio);

                    ts.Complete();
                }

                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ResultInfo GetLogErrori(string IdTicket, string CodiceFondo)
        {
            var dal = new DALClass();
            var resultInfo = new ResultInfo();
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    var invio = dal.GetInvioMonitoraggioByIdTicket(IdTicket);
                    var idInvio = invio.ID_INVIO;
                    var logErrori = new IgrueLogErrori();
                    logErrori.DATA_RICHIESTA = DateTime.Now;
                    var ws = new CallWS();
                    
                    var file = ws.GetLogErrori(IdTicket, ref resultInfo);
                    
                    if (file != null)
                    {
                        string log = FileUtility.ZipArrayToString(file);                                              
                        var xml = LogParser.GetXmlString(log, idInvio, CodiceFondo);
                        logErrori.ISTANZA_ERRORI = xml;
                    }
                   

                    logErrori.ID_TICKET = IdTicket;
                    logErrori.FILE_ERRORI = file;
                    logErrori.ID_INVIO = idInvio;
                    logErrori.ID_OPERATORE = null;
                    logErrori.CODICE_ESITO = resultInfo.CodiceEsito;
                    logErrori.DESCRIZIONE_ESITO = resultInfo.DescrizioneEsito;
                    logErrori.DETTAGLIO_ESITO = resultInfo.DettaglioEsito;
                    logErrori.TIMESTAMP_ESITO = resultInfo.TimeStampEsito;
                    logErrori.TIPO_FILE = invio.TIPO_FILE;
                    logErrori.CODICE_FONDO = invio.CODICE_FONDO;
                    var t = dal.GetLogErroriByIdTicket(IdTicket);
                    if(t != null)
                    {
                        logErrori.ID_IGRUE_LOG_ERRORI = t.ID_IGRUE_LOG_ERRORI;
                        dal.UpdateLogErrori(logErrori);
                    }
                    else
                    {
                        dal.InsertLogErrori(logErrori);
                    }
                   
                    ts.Complete();
                }
                return resultInfo;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void InsertCodProceduraAttivazione(int IdBando, string CodProceduraAttivazione, DateTime? DataAssegnazione)
        {
            try
            {
                var dal = new DALClass();
                dal.InsertCodProceduraAttivazione(IdBando, CodProceduraAttivazione, DataAssegnazione);
            }
            catch (Exception ex)
            {                
                throw ex;
            }          
        }

        public byte[] GetFileInvio(int IdInvio)
        {
            try
            {
                byte[] result = null;
                var dal = new DALClass();
                var invio = dal.GetInvioMonitoraggioById(IdInvio);
                result = invio.FILE_INVIO;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public byte[] GetFileInvio(string IdTicket)
        {
            try
            {
                byte[] result = null;
                var dal = new DALClass();
                var invio = dal.GetInvioMonitoraggioByIdTicket(IdTicket);
                result = invio.FILE_INVIO;
                return result;
            }
            catch (Exception ex)
            {               
                throw ex;
            }

        }

        public byte[] GetFileLogErrori(int IdLogErrori)
        {
            try
            {
                byte[] result = null;
                var dal = new DALClass();
                var log = dal.GetLogErroriById(IdLogErrori);
                result = log.FILE_ERRORI;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public byte[] GetFileLogErrori(string IdTicket)
        {
            try
            {
                byte[] result = null;
                var dal = new DALClass();
                var log = dal.GetLogErroriByIdTicket(IdTicket);
                result = log.FILE_ERRORI;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetXmlLogErrori(int IdLogErrori)
        {
            try
            {
                string result = string.Empty;
                var dal = new DALClass();
                var log = dal.GetLogErroriById(IdLogErrori);
                result = log.ISTANZA_ERRORI;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetXmlLogErrori(string IdTicket)
        {
            try
            {
                string result = string.Empty;
                var dal = new DALClass();
                var log = dal.GetLogErroriByIdTicket(IdTicket);
                result = log.ISTANZA_ERRORI;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ResultInfo SendProgettiDelete(string[] Files, int IdInvioDelete, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = null;
                    invio.DATA_A = null;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = string.Join(",", Files);
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    var lfiles = Files.ToList();
                    int records = 0;
                    foreach (string NomeFile in lfiles)
                    {
                        //Inserisco i dati di monitoraggio nelle tabelle lanciando la query passando ID_INVIO e l'invio del record originale che ho inviato in BDU 
                        records = dal.InsertProgettiCancellazione(invio.ID_INVIO, NomeFile, IdInvioDelete, records);

                        //Recupero i dati dalla tabella con lo specifico ID_INVIO
                        var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);

                        //var file = FileUtility.GeneraFileNoHF(dtable,NomeFile);
                        var file = FileUtility.GeneraFile(dtable, NomeFile, false);
                        if (!string.IsNullOrEmpty(file))
                        {
                            recBuilder.Append(file);
                        }
                    }

                    fileBuilder.AppendLine(FileUtility.GetHeaderRow(records));
                    fileBuilder.Append(recBuilder.ToString());
                    fileBuilder.Append(FileUtility.GetFooterRow(records));


                    //Zippo il file di invio
                    var expfile = "igrue_XX_S_" + invio.ID_INVIO.ToString() + ".txt";
                    var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                    invio.FILE_INVIO = t;

                    //aggiorno il record di invio inserendo in db il file compresso
                    dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                    //Invoco il ws di prenotazione e invio
                    var ws = new CallWS();
                    result = ws.SendFile(t);

                    //recupero il ticket e aggiorno il record di invio 
                    invio.CODICE_ESITO = result.CodiceEsito;
                    invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                    invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                    invio.ID_TICKET = ws.Ticket;
                    invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                    invio.ID_OPERATORE = 0;
                    dal.UpdateInvioMonitoraggio(invio);

                    ts.Complete();
                }
                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultInfo SendProgettiDelete(string NomeFile, int IdInvioDelete, string[] IdProgetti, string[] RowNumbers, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = null;
                    invio.DATA_A = null;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = NomeFile;
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    int records = 0;

                    //Inserisco i dati di monitoraggio nelle tabelle lanciando la query passando ID_INVIO e l'invio del record originale che ho inviato in BDU 
                    if (RowNumbers == null)
                    {
                        records = dal.InsertProgettiCancellazione(invio.ID_INVIO, NomeFile, IdInvioDelete, IdProgetti, records);
                    }
                    else
                    {
                        records = dal.InsertProgettiCancellazione(invio.ID_INVIO, NomeFile, IdInvioDelete, IdProgetti, RowNumbers, records);
                    }

                    //Recupero i dati dalla tabella con lo specifico ID_INVIO
                    var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);

                    //var file = FileUtility.GeneraFileNoHF(dtable,NomeFile);
                    var file = FileUtility.GeneraFile(dtable, NomeFile, false);
                    if (!string.IsNullOrEmpty(file))
                    {
                        recBuilder.Append(file);
                    }

                    fileBuilder.AppendLine(FileUtility.GetHeaderRow(records));
                    fileBuilder.Append(recBuilder.ToString());
                    fileBuilder.Append(FileUtility.GetFooterRow(records));


                    //Zippo il file di invio
                    var expfile = "igrue_" + NomeFile + "_S_" + invio.ID_INVIO.ToString() + ".txt";
                    var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                    invio.FILE_INVIO = t;

                    //aggiorno il record di invio inserendo in db il file compresso
                    dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                    //Invoco il ws di prenotazione e invio
                    var ws = new CallWS();
                    result = ws.SendFile(t);//new ResultInfo();//

                    //recupero il ticket e aggiorno il record di invio 
                    invio.CODICE_ESITO = result.CodiceEsito;
                    invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                    invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                    invio.ID_TICKET = ws.Ticket;
                    invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                    invio.ID_OPERATORE = 0;
                    dal.UpdateInvioMonitoraggio(invio);

                    ts.Complete();
                }
                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultInfo SendProgettiDelete(string NomeFile, int IdInvioDelete, string FilterClause, string CodiceFondo)
        {
            var dal = new DALClass();
            string expFile = string.Empty; //da utilizzare per il risultato del metodo GeneraFile in FileUtility
            ResultInfo result = new ResultInfo();

            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = null;
                    invio.DATA_A = null;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = NomeFile;
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);
                    var recBuilder = new StringBuilder();
                    var fileBuilder = new StringBuilder();
                    int records = 0;

                    //Inserisco i dati di monitoraggio nelle tabelle lanciando la query passando ID_INVIO e l'invio del record originale che ho inviato in BDU 
                    records = dal.InsertProgettiCancellazione(invio.ID_INVIO, NomeFile, IdInvioDelete, FilterClause, records);

                    //Recupero i dati dalla tabella con lo specifico ID_INVIO
                    var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);

                    //var file = FileUtility.GeneraFileNoHF(dtable,NomeFile);
                    var file = FileUtility.GeneraFile(dtable, NomeFile, false);
                    if (!string.IsNullOrEmpty(file))
                    {
                        recBuilder.Append(file);
                    }

                    fileBuilder.AppendLine(FileUtility.GetHeaderRow(records));
                    fileBuilder.Append(recBuilder.ToString());
                    fileBuilder.Append(FileUtility.GetFooterRow(records));


                    //Zippo il file di invio
                    var expfile = "igrue_" + NomeFile + "_S_" + invio.ID_INVIO.ToString() + ".txt";
                    var t = FileUtility.StringToZipArray(expfile, fileBuilder.ToString());
                    invio.FILE_INVIO = t;

                    //aggiorno il record di invio inserendo in db il file compresso
                    dal.UpdateFileInvioMonitoraggio(t, invio.ID_INVIO);

                    //Invoco il ws di prenotazione e invio
                    var ws = new CallWS();
                    result = ws.SendFile(t);//new ResultInfo();//

                    //recupero il ticket e aggiorno il record di invio 
                    invio.CODICE_ESITO = result.CodiceEsito;
                    invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                    invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                    invio.ID_TICKET = ws.Ticket;
                    invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                    invio.ID_OPERATORE = 0;
                    dal.UpdateInvioMonitoraggio(invio);

                    ts.Complete();
                }
                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BandoInfo> CheckBandiAttivazione(string CodiceFondo)
        {
            var dal = new DALClass();
            List<BandoInfo> lresult = new List<BandoInfo>();
            try
            {
                lresult = dal.CheckBandiAttivazione(CodiceFondo);
                return lresult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region metodi di get esiti elaborazione

        public byte[] GetEsitoElaborazione(string IdTicket)
        {
            byte[] payload = null;
            var resultInfo = new ResultInfo();
            var svc = new CallWS();

            payload = svc.GetEsitoElaborazione(IdTicket, ref resultInfo);

            return payload;

        }


        public byte[] GetStatisticheScarti(string IdTicket)
        {
            byte[] payload = null;
            var resultInfo = new ResultInfo();
            var svc = new CallWS();

            payload = svc.GetStatisticheScarti(IdTicket, ref resultInfo);

            return payload;

        }


        public byte[] GetStatisticheElaborazioni(string IdTicket)
        {
            byte[] payload = null;
            var resultInfo = new ResultInfo();
            var svc = new CallWS();

            payload = svc.GetStatisticheElaborazioni(IdTicket, ref resultInfo);

            return payload;

        }

        #endregion

        #region Metodi di test

        public void TestScritturaEstrazioneFileZip(string IdTicket)
        {
            var dal = new DALClass();
            var file = dal.GetInvioMonitoraggioByIdTicket(IdTicket).FILE_INVIO;
            string result = FileUtility.ZipArrayToString(file);
            System.IO.File.WriteAllText(@"" + IdTicket + ".txt", result, Encoding.Default);
        }


        public void TestScritturaFilePA00(int IdInvio)
        {
            var dal = new DALClass();
            var result = dal.GetIgruePA00(IdInvio);
            var builder = new StringBuilder();
            builder.AppendLine(GetHeaderRow(result.Count));
            foreach (IgruePA00 item in result)
            {
                var record = "PA00" + sharp + item.NR_RIGA_INVIO + sharp + "PRATT187" + sharp + item.COD_PROC_ATT_LOCALE + pipe + item.COD_AIUTO_RNA + pipe + item.TIP_PROCEDURA_ATT + pipe + item.FLAG_AIUTI + pipe + item.DESCR_PROCEDURA_ATT + pipe + item.COD_TIPO_RESP_PROC + pipe + item.DENOM_RESP_PROC + pipe + item.DATA_AVVIO_PROCEDURA + pipe + item.DATA_FINE_PROCEDURA + pipe + item.FLG_CANCELLAZIONE + pipe;
                builder.AppendLine(record);
            }
            builder.AppendLine(GetFooterRow(result.Count));
            System.IO.File.WriteAllText(@"" + Convert.ToString(IdInvio) + ".txt", builder.ToString());
        }


        public bool TestScritturaFile(string NomeFile, string CodiceFondo)
        {
            var dal = new DALClass();

            DateTime DataDa = DateTime.ParseExact("01/01/2016", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime DataA = DateTime.ParseExact("01/10/2016", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //Inserisco i dati di testa dell'invio e recupero ID_INVIO
            var invio = new IgrueInvio();
            invio.DATA_DA = DataDa;
            invio.DATA_A = DataA;
            invio.ID_OPERATORE = null;
            invio.FILE_INVIO = null;
            invio.TIPO_FILE = NomeFile;
            invio.CODICE_FONDO = CodiceFondo;
            dal.InsertInvioMonitoraggio(invio);
            
            //Inserisco i dati di monitoraggio nelle tabelle lanciando le sp passando ID_INVIO
            dal.InsertDatiMonitoraggio(invio.DATA_DA, invio.DATA_A, NomeFile, invio.ID_INVIO, null, CodiceFondo);

            //Recupero i dati dalla tabella con lo specifico ID_INVIO
            var dtable = dal.GetDatiTabellaIgrue(NomeFile, invio.ID_INVIO, CodiceFondo);
            var result = FileUtility.GeneraFile(dtable, NomeFile, true);
            System.IO.File.WriteAllText(@"" + NomeFile + ".txt", result);
            return true;
        }


        public ResultInfo TestInvioFileGlobale(string CodiceFondo)
        {
            var dal = new DALClass();
            var result = new ResultInfo();
            DateTime data_da = DateTime.ParseExact("01/01/2016", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime data_a = DateTime.ParseExact("01/10/2016", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            byte[] test = System.IO.File.ReadAllBytes(@"");
            try
            {
            using (var ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
                {
                    //Inserisco i dati di testa dell'invio e recupero ID_INVIO
                    var invio = new IgrueInvio();
                    invio.DATA_DA = data_da;
                    invio.DATA_A = data_a;
                    invio.ID_OPERATORE = null;
                    invio.FILE_INVIO = null;
                    invio.TIPO_FILE = "XX";
                    invio.CODICE_FONDO = CodiceFondo;
                    dal.InsertInvioMonitoraggio(invio);

                    //Inserisco i dati di monitoraggio nelle tabelle lanciando le sp passando ID_INVIO
                    //dal.InsertDatiMonitoraggio(invio.DATA_DA, invio.DATA_A, "XX", invio.ID_INVIO);

                    invio.FILE_INVIO = test;

                        //aggiorno il record di invio inserendo in db il file compresso
                        dal.UpdateFileInvioMonitoraggio(test, invio.ID_INVIO);

                        //Invoco il ws di prenotazione e invio
                        var ws = new CallWS();
                        result = ws.SendFile(test);

                        //recupero il ticket e aggiorno il record di invio 
                        //dal.UpdateTicketInvioMonitoraggio(ws.Ticket, invio.ID_INVIO);
                        invio.CODICE_ESITO = result.CodiceEsito;
                        invio.DESCRIZIONE_ESITO = result.DescrizioneEsito;
                        invio.DETTAGLIO_ESITO = result.DettaglioEsito;
                        invio.ID_TICKET = ws.Ticket;
                        invio.TIMESTAMP_ESITO = result.TimeStampEsito;
                        invio.ID_OPERATORE = 0;
                        dal.UpdateInvioMonitoraggio(invio);
                        //if (result.CodiceEsito >= 0)
                        //{
                        //    esito = true;
                        //}
                        //esito = true;
                    
                    
                    ts.Complete();
                }

                return result;//esito;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //var ws = new CallWS();
            //var result = ws.SendFile(test);
            //return result;
        }


        #endregion
    }
}
