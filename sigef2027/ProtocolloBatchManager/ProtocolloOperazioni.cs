using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiarLibrary;
using System.Xml.Linq;
using System.Configuration;

namespace ProtocolloBatchManager
{
    public partial class ProtocolloOperazioni
    {
        private DALClass _dal { get; set; }
        private Logger _logger { get; set; }

        public ProtocolloOperazioni()
        {
            _dal = new DALClass();
            _logger = new Logger(_dal);
        }

        public List<ProgettoProtocollabile> GetProgettiProtocollabili(int idBando)
        {
            try
            {
                var result = _dal.GetProgettiProtocollabili(idBando);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Istanza GetIstanzaById(int idProgetto)
        {
            try
            {
                var result = _dal.GetProgettoById(idProgetto);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Bando> GetBandi()
        {
            try
            {
                var result = _dal.GetBandi();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResultInfo ProtocollaDocumento(Istanza istanza)
        {
            var result = new ResultInfo();
            result.IdIstanza = istanza.IdIstanza;
            result.IdProgetto = istanza.IdProgetto;

            try
            {
                Protocollo protocollo = new Protocollo(istanza.CodiceEnte);

                Progetto p = new SiarBLL.ProgettoCollectionProvider().GetById(istanza.IdProgetto);
                Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
                PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(i.IdRapprlegaleUltimo);

                protocollo.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");

                if (istanza.FileDocumento == null)
                {
                    result.Esito = "KO";
                    result.DescrizioneEsito = "Nessun documento associato alla domanda";
                    result.DataRisposta = DateTime.Now;
                    return result;
                }

                protocollo.setDocumento("doc_principale_domanda.pdf", istanza.FileDocumento);             

                string oggetto = "Domanda di adesione al bando: " + istanza.DescrizioneBando + " del " + istanza.DataAtto.ToString("dd/MM/yyyy") + " con scadenza: " + istanza.DataScadenza.ToString("dd/MM/yyyy") + "\n Rif." + istanza.NumeroAtto + "\n N° Domanda: "
                    + istanza.IdIstanza.ToString() + "\n Impresa: " + istanza.PartitaIva + " " + istanza.RagioneSociale;

                string tokenChoesion= "<?xml version=\"1.0\"?>" + istanza.TokenCohesion;

                protocollo.addAllegato("Autenticazione_Operatore.xml", protocollo.GetSHA256(System.Text.Encoding.Unicode.GetBytes(tokenChoesion)));
                string segnatura = protocollo.ProtocolloIngresso(oggetto, istanza.Fascicolo);

                if (string.IsNullOrEmpty(segnatura))
                {
                    result.Esito = "KO";
                    result.DescrizioneEsito = "Nessuna segnatura restituita dal servizio";
                    result.DataRisposta = DateTime.Now;
                    return result;
                }

                //Allegato
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();

                all.Descrizione = "Autenticazione_Operatore.xml";
                all.Documento = new SiarBLL.paleoWebService.File();
                all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(tokenChoesion);
                Dictionary<string, object> allegatoProtocollo = new Dictionary<string, object>
                {
                    { "allegato", all },
                    { "id_file", -1 },
                    { "tipo_origine", "progetto" },
                    { "id_origine", istanza.IdProgetto }
                };

                allegatiProtocollo.Add(allegatoProtocollo);

                protocollo.addAllegatiProtocollo(allegatiProtocollo, segnatura);
                result.DataRisposta = DateTime.Now;


                result.Esito = "OK";
                result.DescrizioneEsito = "Acquisita segnatura ";
                result.Segnatura = segnatura;
                return result;
            }
            catch (Exception ex)
            {
                result.Esito = "KO";
                result.DescrizioneEsito = ex.Message;
                result.DataRisposta = DateTime.Now;
                throw ex;
            }
            finally
            {

            }

            
        }


        public void AggiornaSegnaturaProgetto(int idProgetto, string segnatura)
        {
            try
            {
                _dal.InsertSegnaturaProgetto(idProgetto, segnatura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void InsertLog(ProtocolloLog protocolloLog)
        {
            try
            {
                _logger.InsertLogProtocollo(protocolloLog);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         
    }
}
