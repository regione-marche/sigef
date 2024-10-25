﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;

namespace web.CONTROLS
{
    public partial class FirmaDocumentoCalamaio : System.Web.UI.UserControl //, IFirmaDocumento
    {
        //public string capability { get; set; }

        protected string dataToSign { get; set; }

        //public EventHandler DocumentoFirmatoEvent { get; set; }
        public bool DoppiaFirma { get; set; }
        public string FileFirmato { get; set; }
        public bool FirmaObbligatoria { get; set; }
        public int IdFileFirmato { get; set; }

        public string TipoDocumento { get; set; }
        //public string Titolo { get; set; }
        public string Titolo
        {
            get { return lblTitolo.Text; }
            set { lblTitolo.Text = value; }
        }
        public bool Preview { get; set; }

        private EventHandler _documentoFirmatoEvent;
        public EventHandler DocumentoFirmatoEvent
        {
            get { return this._documentoFirmatoEvent; }
            set { _documentoFirmatoEvent = value; }
        }

        private DatiFirmaJson _datiFirma;
        public class DatiFirmaJson
        {
            public bool DoppiaFirma = false, FirmaObbligatoria = true;
            public string ContenutoFile, CfFirmatario;
            public int StepFirma = 0; // 0: non firmato, 1: prima firma eseguita; 2: seconda firma eseguita/firme completate                
        }

        System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = 9999999 };

        protected void Page_Load(object sender, EventArgs e)
        {
            jsser.MaxJsonLength = 9999999; // massima lunghezza del file
            if (!string.IsNullOrEmpty(hdnJsonDatiFirma.Value))
                try { _datiFirma = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value); }
                catch { hdnJsonDatiFirma.Value = ""; }
            if (_datiFirma != null)
            {
                if (_datiFirma.StepFirma < 2) completePageRender();
                else
                {
                    hdnJsonDatiFirma.Value = ""; // pulisco l'hidden
                    hdnSignedData.Value = "";
                    hdnDataToSign.Value = "";
                    hdnNomeFile.Value = "";
                    btnPostFirmaDocumento.Click += new EventHandler(_documentoFirmatoEvent);
                }
            }
        }

        public void loadDocumentoSenzaFirma(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            byte[] doc = null;
            if (IdFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(IdFileFirmato);
                if (f != null) doc = f.Contenuto;
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
        }

        public void loadDocumento(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            _datiFirma.DoppiaFirma = DoppiaFirma;
            _datiFirma.FirmaObbligatoria = FirmaObbligatoria;
            _datiFirma.CfFirmatario = _cf_firmatario;
            txtUsernameRS.Value = _cf_firmatario;
            
            byte[] doc = null;
            if (IdFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(IdFileFirmato);
                if (f != null) doc = f.Contenuto;
                hdnNomeFile.Value = "IdFileFirmato-" + IdFileFirmato.ToString();
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
            completePageRender();
        }

        private void completePageRender()
        {
            //metto in sessione il report per riprenderlo dalla pagina di visualizzazione
            Session.Add("doc", Convert.FromBase64String(_datiFirma.ContenutoFile));
            dataToSign = CalamaioUtility.GetDataToSign(Convert.FromBase64String(_datiFirma.ContenutoFile), _datiFirma.CfFirmatario, hdnNomeFile.Value);
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
            hdnDataToSign.Value = Convert.ToBase64String(byt);
            hdnJsonDatiFirma.Value = jsser.Serialize(_datiFirma);
            ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("initFirmaDocumentoControl();");
        }

        private byte[] getDocumentoFromServer(params string[] parametri)
        {
            SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
            byte[] report;
            string[] tmp_parametri = null;
            string nome_file = "";

            switch (TipoDocumento)
            {
                #region definisco il tipo
                case "PDOMANDA":
                    tmp_parametri = new string[] { "ID_Domanda=" + parametri[0] };
                    report = rt.getReportByName("rptModelloDomanda" + parametri[1], tmp_parametri);
                    break;
                case "CHECKLIST":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "fase=" + parametri[1] };
                    report = rt.getReportByName("rptChecklist", tmp_parametri);
                    break;
                case "NON_RICEVIBILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptNonRicevibilita", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_PROV":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilita", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_DEF":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptProvvedimentoNonAmmissibilita", tmp_parametri);
                    break;
                case "RAPPORTO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptRapportoIstruttorio", tmp_parametri);
                    break;
                case "ESITO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptEsitoIstruttorio", tmp_parametri);
                    break;
                case "COMUNICAZIONE_ESITO_ISTRUTTORIO":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneEsitoIstruttorio", tmp_parametri);
                    break;
                case "CKL_REVISIONE":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistRevisione", tmp_parametri);
                    break;
                case "GRADUATORIA":
                    tmp_parametri = new string[] { "IdBando=" + parametri[0] };
                    report = rt.getReportByName("rptGraduatoria", tmp_parametri);
                    break;
                case "COMUNICAZIONE_FINANZIABILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneFinanziabilita", tmp_parametri);
                    break;
                case "COMUNICAZIONE_NON_FINANZIABILITA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonFinanziabilita", tmp_parametri);
                    break;
                case "RICHIESTA_CERTIFICAZIONE":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaCertificazione", tmp_parametri);
                    break;
                case "RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaDocumentazioneIntegrativa", tmp_parametri);
                    break;

                //case "COMUNICAZIONE_AVVIO_LAVORI":
                //    report = rt.getReportByName("rptComunicazioneAvvioLavori", new string[] { "IdProgetto=" + Request.QueryString["iddom"] });
                //    break;
                case "DOMPAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    var dom_pag = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(int.Parse(parametri[0]));
                    var prog = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag.IdProgetto);

                    var utAppalto = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog.IdBando);
                    if (utAppalto != null && utAppalto == "Strumenti finanziari")
                        report = rt.getReportByName("rptDomandaPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptDomandaPagamento", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    break;
                case "VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptVariante", tmp_parametri);
                    break;
                case "CKL_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    var dom_pag_checklist = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(int.Parse(parametri[0]));
                    var prog_checklist = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag_checklist.IdProgetto);

                    var utAppalto_checklist = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog_checklist.IdBando);
                    if (utAppalto_checklist != null && utAppalto_checklist == "Strumenti finanziari")
                        report = rt.getReportByName("rptChecklistPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptChecklistPagamento", tmp_parametri);
                    break;
                case "CKL_PAGAMENTO_RETTIFICA_SALDO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistPagamentoRettificaSaldo", tmp_parametri);
                    break;
                case "CKL_REVISIONE_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0], "IdTestataValidazione=" + parametri[1] };
                    report = rt.getReportByName("rptChecklistRevisionePagamento", tmp_parametri);
                    break;
                case "CKL_VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptIstruttoriaVariante", tmp_parametri);
                    break;
                case "CKL_VARIANTE_AR":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0] };
                    report = rt.getReportByName("rptAcquisizioneEsitoRicorso", tmp_parametri);
                    break;
                case "ELENCO_PAGAMENTO_PROVINCIALE":
                    tmp_parametri = new string[] { "IdElencoPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptElencoPagamentoProvinciale", tmp_parametri);
                    break;
                case "ELENCO_PAGAMENTO_REGIONALE":
                    tmp_parametri = new string[] { "IdElencoPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptElencoPagamentoRegionale", tmp_parametri);
                    break;
                case "COMUNICAZIONE_VARIANTE":
                    tmp_parametri = new string[] { "IdVariante=" + parametri[0], "IdProgetto=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneVariante", tmp_parametri);
                    break;
                case "MANIFESTAZIONE_DI_INTERESSE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptManifestazione", tmp_parametri);
                    break;
                case "CHECKLIST_RICEVIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistRicevibilitaManifestazione", tmp_parametri);
                    break;
                case "CHECKLIST_AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptChecklistAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "NON_RICEVIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonRicevibilitaManifestazione", tmp_parametri);
                    break;
                case "NON_AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "AMMISSIBILITA_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneAmmissibilitaManifestazione", tmp_parametri);
                    break;
                case "RAPPORTO_ISTRUTTORIO_MANIFESTAZIONE":
                    tmp_parametri = new string[] { "IdManifestazione=" + parametri[0] };
                    report = rt.getReportByName("rptRapportoIstruttorioManifestazione", tmp_parametri);
                    break;
                case "COMUNICAZIONE_PAGAMENTO":
                    tmp_parametri = new string[] { "IdDomandaPagamento=" + parametri[0] };
                    report = rt.getReportByName("rptComunicazioneDomandaPagamento", tmp_parametri);
                    break;
                case "VERBALE_VALUTAZIONE_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptVerbaleValutazioneDomanda", tmp_parametri);
                    break;
                case "VERBALE_VALUTAZIONE_VARIANTE":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdVariante=" + parametri[1] };
                    report = rt.getReportByName("rptVerbaleValutazioneVariante", tmp_parametri);
                    break;
                case "COMUNICAZIONE_RICHIESTA_INTEGRAZIONI_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneRichiestaIntegrazioniDomandaDiPagamento", tmp_parametri);
                    break;
                case "COMUNICAZIONE_RISPOSTA_INTEGRAZIONI_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneRispostaIntegrazioniDomandaDiPagamento", tmp_parametri);
                    break;
                case "CKL_CONTROLLI_LOCO":
                    tmp_parametri = new string[] { "IdTestata=" + parametri[0]};
                    report = rt.getReportByName("rptChecklistControlliLoco", new string[] { "IdTestata=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_GENERICA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazionGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_GENERICA_BENEFICIARIO":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1], "Autocertificazione=" + parametri[2] };
                    report = rt.getReportByName("rptComunicazionGenericaBeneficiario", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1], "Autocertificazione=" + parametri[2] });
                    break;
                case "COMUNICAZIONE_MASSIVA_GENERICA":
                    tmp_parametri = new string[] { "IdComunicazione=" + parametri[0], "IdBando=" + parametri[1] };
                    report = rt.getReportByName("rptComunicazioneMassivaGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdBando=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_CERTIFICAZIONE":
                    tmp_parametri = new string[] { "dataFine="+parametri[0], "dataLotto="+parametri[1], "codPsr="+parametri[2], "idLotto="+parametri[3] };
                    report = rt.getReportByName("rptComunicazioneCertificazione", tmp_parametri);
                    break;
                case "RICHIESTA_PROF":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaProfilazione", tmp_parametri);
                    break;
                case "RICHIESTA_CONS":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaConsulente", tmp_parametri);
                    break;
                case "RICHIESTA_CONS_APPROVA_RIFIUTA":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptGestioneRichiestaConsulente", tmp_parametri);
                    break;
                case "RICHIESTA_PROC":
                    tmp_parametri = new string[] { "Id=" + parametri[0] };
                    report = rt.getReportByName("rptRichiestaProcura", new string[] { "Id=" + parametri[0] });
                    break;
                case "RICHIESTA_PROC_APPROVA_RIFIUTA":
                    tmp_parametri = new string[] { "IdRichiesta=" + parametri[0] };
                    report = rt.getReportByName("rptGestioneRichiestaProcura", new string[] { "IdRichiesta=" + parametri[0], "IdBando=" + parametri[1], });
                    break;
                case "COVID_DOMANDA":
                    tmp_parametri = new string[] { "IdProgetto=" + parametri[0] };
                    report = rt.getReportByName("rptCovidDomanda", tmp_parametri);
                    break;
                case "EROGAZIONE":
                    tmp_parametri = new string[] { "IdErogazione=" + parametri[0] };
                    report = rt.getReportByName("rptErogazioneFem", tmp_parametri);
                    break;
                default:
                    throw new Exception("Tipo di documento non specificato. Impossibile continuare.");
                    #endregion
            }
            rt.Dispose();
            nome_file = TipoDocumento + "-" + String.Join("-", tmp_parametri).Replace('=', '_');
            hdnNomeFile.Value = nome_file;
            return report;
        }

        public string GetFileFirmato()
        {
            string result = "";
            try
            {
                if (hdnJsonDatiFirma.Value != null && hdnJsonDatiFirma.Value != "")
                    result = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value).ContenutoFile;
            }
            catch { result = ""; }
            return result;
        }

        protected void btnFirmaRemota_Click(object sender, EventArgs e)
        {
            var rsclient = new FirmaRemotaManager.FirmaRemotaOperazioni();
            var request = new FirmaRemotaManager.FirmaRemotaRequest();
            var logInfo = new FirmaRemotaManager.LogInfo();
            string esito = "OK"; 
            string dettaglioEsito = string.Empty;
            request.CfFirmatario = txtUsernameRS.Value;
            request.Pin = txtPasswordRS.Value;
            request.Otp = txtOtpRS.Value;
            //request.IdFile = IdFileFirmato;


            if(!string.IsNullOrEmpty(txtDominio.Value) || !string.IsNullOrWhiteSpace(txtDominio.Value))
            {
                request.Domain = txtDominio.Value;
            }

            try
            {
                var file = Convert.FromBase64String(_datiFirma.ContenutoFile);
                if (file == null || file.Length == 0) throw new Exception("Il documento da firmare non è presente");
                request.File = file;

                //dati log
                string tipoDocumento = hdnNomeFile.Value.Substring(0, hdnNomeFile.Value.IndexOf("-"));
                string parametriDocumento = hdnNomeFile.Value.Substring(hdnNomeFile.Value.IndexOf("-") + 1);
                logInfo.Operatore = txtUsernameRS.Value;
                logInfo.TipoFirma = "remota";
                logInfo.DominioFirma = request.Domain;
                logInfo.TipoDocumento = tipoDocumento;
                logInfo.ParametriDocumento = parametriDocumento;

                var response = rsclient.ArubaSingleRemoteSign(request);


                if (!string.IsNullOrEmpty(response.ErrorCode))
                {
                    ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("switchSign('r');");
                    esito = "KO";
                    dettaglioEsito = "errore codice: " + response.ErrorCode + ": " + response.ErrorDescription;
                    throw new Exception(dettaglioEsito);
                }

                dettaglioEsito = "firma effettuata con successo";               
                var json = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value);
                json.ContenutoFile = Convert.ToBase64String(response.SignedFile);
                json.StepFirma = 2;
                hdnJsonDatiFirma.Value = jsser.Serialize(json);
                Session["doc"] = null;
                ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("closeRS();");

            }
            catch (Exception ex)
            {
                esito = "KO";
                dettaglioEsito = ex.Message;
                ShowError(ex.Message);

            }
            finally
            {
                logInfo.Esito = esito;
                logInfo.DataFirma = System.DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                LogSign(logInfo);
            }
        }

        private void ShowError(string message)
        {
            ((SiarLibrary.Web.Page)Page).ShowError(message);
        }

        private void LogSign(FirmaRemotaManager.LogInfo logInfo)
        {
            try
            {
                var logger = new FirmaRemotaManager.Logger();
                logger.SaveLogFirma(logInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}