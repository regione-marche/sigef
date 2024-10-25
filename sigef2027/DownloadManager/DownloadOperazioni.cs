using System;
using System.Collections.Generic;
using SiarLibrary;
using System.Configuration;

namespace DownloadManager
{
    public partial class DownloadOperazioni
    {
        private DALClass _dal { get; set; }
        private IOHelper _io { get; set; }

        public DownloadOperazioni()
        {
            _dal = new DALClass();
            _io = new IOHelper();
        }

        public DownloadRequest GetDownloadByTicket(int idTicket)
        {
            try
            {
                var result = _dal.GetDownloadRequest(idTicket);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DownloadRequest> GetOpenDownloadRequests()
        {
            try
            {
                var result = _dal.GetOpenDownloadRequests();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultInfo GetUnitaDocumentale(DownloadRequest request, out ArchivioFileCollection docs)
        {
            ResultInfo result = new ResultInfo();
            string instanceType = (request.IdIntegrazione == null && request.IdDomandaPagamento == null) ? "ID Progetto: " : request.IdDomandaPagamento == null ? "ID Integrazione: " : "ID Domanda Pagamento: ";
            int? instanceID = request.IdIntegrazione ?? request.IdDomandaPagamento ?? request.IdProgetto;

            try
            {
                Protocollo protocollo = new Protocollo();
                docs =  protocollo.AF_RicercaProtocollo(request.Segnatura, true);
                string msg = "Ricevuto elenco documenti per la segnatura: ";
                msg += request.Segnatura + "; ID Progetto: " + request.IdProgetto.ToString() + "; ";
                msg += instanceType + instanceID.ToString();
                msg += "; Nr. documenti: " + docs.Count.ToString();
                result.Esito = "OK";
                result.DescrizioneEsito = msg;
                result.DataRisposta = DateTime.Now;
                result.NrDocumenti = docs.Count;

            }
            catch (Exception ex)
            {

                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataRisposta = DateTime.Now;
                throw ex;
            }
            
            return result;
        }


        public byte[] GetFileStreamProtocollo(string segnatura, ArchivioFile doc)
        {
            try
            {
                Protocollo protocollo = new Protocollo();
                byte[] result = protocollo.AF_RicercaFile(segnatura, doc.Id);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        public WriteResult WriteFileToDirectory(ArchivioFile doc, int idTicket, string segnatura)
        {
            var result = new WriteResult();
            string path = "";
            try
            {
                 path = _io.CreateTicketDirectory(idTicket);
                string fileDir = path + "\\" + doc.NomeCompleto;
                var fileStream = this.GetFileStreamProtocollo(segnatura, doc);
                _io.WriteFileToDirectory(fileStream, fileDir);
                result.Esito = "OK";
                result.DescrizioneEsito = "file " + doc.NomeCompleto + " scaricato correttamente nella directory " + idTicket.ToString();
                return result; 
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = "Errore nel download del documento " + doc.NomeCompleto + ";  ERR:" + ex.Message;
                throw ex;
            }
            finally
            {
                
            }
        }

        public void UpdateTicketStatus(int idTicket, DateTime? dataInizioEstrazione, decimal size)
        {
            try
            {
                _dal.UpdateTicketStatus(idTicket, dataInizioEstrazione, size);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal CreateZipFile(int idTicket, bool deleteDirectory)
        {
            try
            {
                decimal size = _io.CreateZipFile(idTicket, deleteDirectory);
                return size;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<int> DeleteOldArchives()
        {
            int days = int.Parse(ConfigurationManager.AppSettings["daysToRetain"].ToString());
            try
            {
                var tickets = _dal.GetOldArchives(days);
                if((tickets != null) && (tickets.Count > 0))
                {
                    foreach (int ticket in tickets)
                    {
                        _io.DeleteZipFile(ticket);
                        _dal.UpdateDeletedStatus(ticket);
                    }
                }
                
                return tickets;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
