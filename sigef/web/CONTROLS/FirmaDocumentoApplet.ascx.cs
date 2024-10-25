using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class FirmaDocumentoApplet : System.Web.UI.UserControl
    {

        public string Titolo
        {
            get { return lblTitolo.Text; }
            set { lblTitolo.Text = value; }
        }

        private string _tipoDocumento;
        public string TipoDocumento
        {
            get { return this._tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        private bool _doppiaFirma = false;
        public bool DoppiaFirma
        {
            get { return this._doppiaFirma; }
            set { _doppiaFirma = value; }
        }

        private int _idFileFirmato = 0;
        public int IdFileFirmato
        {
            get { return this._idFileFirmato; }
            set { _idFileFirmato = value; }
        }

        private bool _firmaObbligatoria = true;
        public bool FirmaObbligatoria
        {
            get { return this._firmaObbligatoria; }
            set { _firmaObbligatoria = value; }
        }

        private bool _preview = false;
        public bool Preview
        {
            get { return this._preview; }
            set { _preview = value; }
        }


        public string FileFirmato { get; set; }

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

        System.Web.Script.Serialization.JavaScriptSerializer jsser = new System.Web.Script.Serialization.JavaScriptSerializer() {MaxJsonLength = 9999999 };

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
                    btnPostFirmaDocumento.Click += new EventHandler(_documentoFirmatoEvent);
                }
            }

        }

        public void loadDocumentoSenzaFirma(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            byte[] doc = null;
            if (_idFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(_idFileFirmato);
                if (f != null) doc = f.Contenuto;
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
        }

        public void loadDocumento(string _cf_firmatario, params string[] _parametri)
        {
            _datiFirma = new DatiFirmaJson();
            _datiFirma.DoppiaFirma = _doppiaFirma;
            _datiFirma.FirmaObbligatoria = _firmaObbligatoria;
            _datiFirma.CfFirmatario = _cf_firmatario;
            byte[] doc = null;
            if (_idFileFirmato > 0)
            {
                // file firmato parzialmente, lo recupero da archivio file
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(_idFileFirmato);
                if (f != null) doc = f.Contenuto;
            }
            else doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0) throw new Exception("Non è stato possibile generare il documento richiesto.");
            _datiFirma.ContenutoFile = Convert.ToBase64String(doc);
            completePageRender();
        }

        private byte[] getDocumentoFromServer(params string[] parametri)
        {
            SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
            byte[] report;

            switch (_tipoDocumento)
            {
                #region definisco il tipo
                case "PDOMANDA":
                    report = rt.getReportByName("rptModelloDomanda" + parametri[1], new string[] { "ID_Domanda=" + parametri[0] });
                    break;
                case "CHECKLIST":
                    report = rt.getReportByName("rptChecklist", new string[] { "IdProgetto=" + parametri[0], "fase=" + parametri[1] });
                    break;
                case "NON_RICEVIBILITA":
                    report = rt.getReportByName("rptNonRicevibilita", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "NON_AMMISSIBILITA_PROV":
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilita", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "NON_AMMISSIBILITA_DEF":
                    report = rt.getReportByName("rptProvvedimentoNonAmmissibilita", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "RAPPORTO_ISTRUTTORIO":
                    report = rt.getReportByName("rptRapportoIstruttorio", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "ESITO_ISTRUTTORIO":
                    report = rt.getReportByName("rptEsitoIstruttorio", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_ESITO_ISTRUTTORIO":
                    report = rt.getReportByName("rptComunicazioneEsitoIstruttorio", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "CKL_REVISIONE":
                    report = rt.getReportByName("rptChecklistRevisione", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "GRADUATORIA":
                    report = rt.getReportByName("rptGraduatoria", new string[] { "IdBando=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_FINANZIABILITA":
                    report = rt.getReportByName("rptComunicazioneFinanziabilita", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_NON_FINANZIABILITA":
                    report = rt.getReportByName("rptComunicazioneNonFinanziabilita", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "RICHIESTA_CERTIFICAZIONE":
                    report = rt.getReportByName("rptRichiestaCertificazione", new string[] { "IdComunicazione=" + parametri[0] });
                    break;
                case "RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA":
                    report = rt.getReportByName("rptRichiestaDocumentazioneIntegrativa", new string[] { "IdComunicazione=" + parametri[0] });
                    break;

                //case "COMUNICAZIONE_AVVIO_LAVORI":
                //    report = rt.getReportByName("rptComunicazioneAvvioLavori", new string[] { "IdProgetto=" + Request.QueryString["iddom"] });
                //    break;
                case "DOMPAGAMENTO":
                    var idDomandaPagamento = int.Parse(parametri[0]);
                    var dom_pag = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(idDomandaPagamento);
                    var prog = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag.IdProgetto);

                    string utAppalto = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog.IdBando);
                    if (utAppalto != null && utAppalto == "Strumenti finanziari")
                        report = rt.getReportByName("rptDomandaPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptDomandaPagamento", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    break;
                case "VARIANTE":
                    report = rt.getReportByName("rptVariante", new string[] { "IdVariante=" + parametri[0] });
                    break;
                case "CKL_PAGAMENTO":
                    var idDomandaPagamentoChecklist = int.Parse(parametri[0]);
                    var dom_pag_checklist = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(idDomandaPagamentoChecklist);
                    var prog_checklist = new SiarBLL.ProgettoCollectionProvider().GetById(dom_pag_checklist.IdProgetto);

                    var utAppalto_checklist = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(prog_checklist.IdBando);
                    if (utAppalto_checklist != null && utAppalto_checklist == "Strumenti finanziari")
                        report = rt.getReportByName("rptChecklistPagamentoFem", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    else
                        report = rt.getReportByName("rptChecklistPagamento", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    break;
                case "CKL_REVISIONE_PAGAMENTO":
                    report = rt.getReportByName("rptChecklistRevisionePagamento", new string[] { "IdDomandaPagamento=" + parametri[0], "IdTestataValidazione=" + parametri[1] });
                    break;
                case "CKL_VARIANTE":
                    report = rt.getReportByName("rptIstruttoriaVariante", new string[] { "IdVariante=" + parametri[0] });
                    break;
                case "CKL_VARIANTE_AR":
                    report = rt.getReportByName("rptAcquisizioneEsitoRicorso", new string[] { "IdVariante=" + parametri[0] });
                    break;
                case "ELENCO_PAGAMENTO_PROVINCIALE":
                    report = rt.getReportByName("rptElencoPagamentoProvinciale", new string[] { "IdElencoPagamento=" + parametri[0] });
                    break;
                case "ELENCO_PAGAMENTO_REGIONALE":
                    report = rt.getReportByName("rptElencoPagamentoRegionale", new string[] { "IdElencoPagamento=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_VARIANTE":
                    report = rt.getReportByName("rptComunicazioneVariante", new string[] { "IdVariante=" + parametri[0], "IdProgetto=" + parametri[1] });
                    break;
                case "MANIFESTAZIONE_DI_INTERESSE":
                    report = rt.getReportByName("rptManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "CHECKLIST_RICEVIBILITA_MANIFESTAZIONE":
                    report = rt.getReportByName("rptChecklistRicevibilitaManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "CHECKLIST_AMMISSIBILITA_MANIFESTAZIONE":
                    report = rt.getReportByName("rptChecklistAmmissibilitaManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "NON_RICEVIBILITA_MANIFESTAZIONE":
                    report = rt.getReportByName("rptComunicazioneNonRicevibilitaManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "NON_AMMISSIBILITA_MANIFESTAZIONE":
                    report = rt.getReportByName("rptComunicazioneNonAmmissibilitaManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "AMMISSIBILITA_MANIFESTAZIONE":
                    report = rt.getReportByName("rptComunicazioneAmmissibilitaManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "RAPPORTO_ISTRUTTORIO_MANIFESTAZIONE":
                    report = rt.getReportByName("rptRapportoIstruttorioManifestazione", new string[] { "IdManifestazione=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_PAGAMENTO":
                    report = rt.getReportByName("rptComunicazioneDomandaPagamento", new string[] { "IdDomandaPagamento=" + parametri[0] });
                    break;
                case "VERBALE_VALUTAZIONE_DOMANDA":
                    report = rt.getReportByName("rptVerbaleValutazioneDomanda", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "VERBALE_VALUTAZIONE_VARIANTE":
                    report = rt.getReportByName("rptVerbaleValutazioneVariante", new string[] { "IdProgetto=" + parametri[0], "IdVariante=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_RICHIESTA_INTEGRAZIONI_DOMANDA":
                    report = rt.getReportByName("rptComunicazioneRichiestaIntegrazioniDomandaDiPagamento", new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_RISPOSTA_INTEGRAZIONI_DOMANDA":
                    report = rt.getReportByName("rptComunicazioneRispostaIntegrazioniDomandaDiPagamento", new string[] { "IdProgetto=" + parametri[0], "IdIntegrazioneDomandaDiPagamento=" + parametri[1] });
                    break;
                case "CKL_CONTROLLI_LOCO":
                    report = rt.getReportByName("rptChecklistControlliLoco", new string[] { "IdTestata=" + parametri[0] });
                    break;
                case "COMUNICAZIONE_GENERICA":
                    report = rt.getReportByName("rptComunicazionGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_GENERICA_BENEFICIARIO":
                    report = rt.getReportByName("rptComunicazionGenericaBeneficiario", new string[] { "IdComunicazione=" + parametri[0], "IdProgetto=" + parametri[1], "Autocertificazione=" + parametri[2] });
                    break;
                case "COMUNICAZIONE_MASSIVA_GENERICA":
                    report = rt.getReportByName("rptComunicazioneMassivaGenerica", new string[] { "IdComunicazione=" + parametri[0], "IdBando=" + parametri[1] });
                    break;
                case "COMUNICAZIONE_CERTIFICAZIONE":
                    report = rt.getReportByName("rptComunicazioneCertificazione", new string[] { "dataFine=" + parametri[0], "dataLotto=" + parametri[1], "codPsr=" + parametri[2], "idLotto=" + parametri[3] });
                    break;
                case "RICHIESTA_PROF":
                    report = rt.getReportByName("rptRichiestaProfilazione", new string[] { "IdRichiesta=" + parametri[0]  });
                    break;
                case "RICHIESTA_CONS":
                    report = rt.getReportByName("rptRichiestaConsulente", new string[] { "IdRichiesta=" + parametri[0] });
                    break;
                case "RICHIESTA_PROC":
                    report = rt.getReportByName("rptRichiestaProcura", new string[] { "Id=" + parametri[0] });
                    break;
                case "RICHIESTA_PROC_APPROVA_RIFIUTA":
                    report = rt.getReportByName("rptGestioneRichiestaProcura", new string[] { "IdRichiesta=" + parametri[0], "IdBando=" + parametri[1], });
                    break;
                case "COVID_DOMANDA":
                    report = rt.getReportByName("rptCovidDomanda", new string[] { "IdProgetto=" + parametri[0] });
                    break;
                case "RICHIESTA_CONS_APPROVA_RIFIUTA":
                    report = rt.getReportByName("rptGestioneRichiestaConsulente", new string[] { "IdRichiesta=" + parametri[0] });
                    break;
                case "EROGAZIONE":
                    report = rt.getReportByName("rptErogazioneFem", new string[] { "IdErogazione=" + parametri[0] });
                    break;
                default:
                    throw new Exception("Tipo di documento non specificato. Impossibile continuare.");
                    #endregion
            }
            rt.Dispose();
            return report;
        }

        private void completePageRender()
        {
            //metto in sessione il report per riprenderlo dalla pagina di visualizzazione
            Session.Add("doc", Convert.FromBase64String(_datiFirma.ContenutoFile));
            //mostro l'applet con il pulsante firma
            createTagHTMLFirma();
            hdnJsonDatiFirma.Value = jsser.Serialize(_datiFirma);
            ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("initFirmaDocumentoControl();");
        }

        private void createTagHTMLFirma()
        {
            string testo_cella = "";
            if (_firmaObbligatoria)
            {
                if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")
                    testo_cella += "<OBJECT CODE='it.unicam.cs.sign.SignApplet.class' ARCHIVE='" + System.Configuration.ConfigurationManager.AppSettings["DownloadDir"] + "SignApplet.jar' id='siarSignApplet' height='1px' width='1px'>"
                        + "<PARAM name='java_arguments' value='-Xmx2048m'>" // <!-- Necessario per firmare file grandi richiede java > 1.6u10 -->
                        + "<PARAM name='PathDll' value='PKCS11.dll%inp11lib.dll%bit4xpki.dll%incryptoki2.dll%bit4ipki.dll%bit4opki.dll%OCSCryptoki.dll%asepkcs.dll%SI_PKCS11.dll%cmP11.dll%bit4cpki.dll%bit4p11.dll%asepkcs.dll%libbit4opki.so%libbit4spki.so%libbit4p11.so%libbit4ipki.so%opensc-pkcs11.so%libopensc.dylib%libbit4xpki.dylib%libbit4ipki.dylib%libbit4opki.dylib%libASEP11.dylib'>" // <!-- Librerie PKCS11 da usare. Si può inserire o solo il nome o, in caso non venisse trovata, tutto il percorso. Vanno separate con % ; Se nessuna libreria viene specificata o il parametro non è presente verrà chiesto di scegliere la libreria da utilizzare direttamente dall'applet nel pc dell'utente -->
                        + "<PARAM name='SalvataggioLocale' value='no'>" // <!-- se si verrà chiesto dove salvare il file firmato nel pc, altrimenti verrà richiamata la funzione PassaFileFirmato dove in caso si firmassero piu files, la variabile StringaFilePdf sarà dello stesso formato del parametro DataToSign; se il parametro è vuoto o non presente il valore di default è no-->
                        + "<PARAM name='FirmaPDFComeP7m' value='no'>" //<!-- se impostata su si firmerà i pdf in formato P7M, quindi la firma non verrà integrata nel PDF e i parametri FirmaVisibile e NumeroPagina non verranno considerati. Impostando no la firma verrà integrata nel pdf cercando di non sovrapporsi alle firme precedenti qualora ci siano ; se il parametro è vuoto o non presente il valore di default è no -->
                        + "<PARAM name='FirmaVisibile' value='si'>"// <!-- Se si viene mostrata la firma nel pdf ; se il parametro è vuoto o non presente il valore di default è no-->
                        + "<PARAM name='NumeroPagina' value=''>" // <!-- se impostata seleziona il numero di pagina su cui applicare la firma se questa è visibile; se il parametro è vuoto o non presente o = -1 e la firma è visibile allora questa viene applicata all'ultima pagina -->
                        + "<PARAM name='PosizioneFirma' value='" + (_datiFirma.StepFirma == 0 ? "DESTRA" : "SINISTRA") + "'>"// <!-- se impostato può assumere valore "SINISTRA" o "DESTRA" ed indica la posizione della firma nel pdf nella pagina specificata precedentemente, qualora la firma sia visible. Se vuoto, non presente, o conentente un altro valore la posizione della firma nei pdf verrà calcolata cercando di non sovrapporsi alle firme esistenti -->
                        + "<PARAM name='ControlloCodiceFiscaleFirmatario' value=''>"// <!-- se impostato permette di limitare la firma al solo utente con codice fiscale specificato -->
                        + "<PARAM name='TimeServerUrl' value='" + System.Configuration.ConfigurationManager.AppSettings["CohesionUrl"] + "/SignApplet/TimeService.aspx'>"// <!-- Indirizzo della pagina certificata da cui prendere la data da impostare sulla firma; la pagina controlla anche che l'host su cui è caricata l'applet sia censito ed abilitato all'utilizzo -->
                        + "<PARAM name='SignButtonText' value=''>"// <!-- Testo da mostrare nel bottone di firma; se il parametro è vuoto o non presente il bottone non sarà visibile-->
                        + "<PARAM name='UploadButtonText' value=''>" //<!-- Testo da mostrare nel bottone per il caricamento di documenti già firmati; se il parametro è vuoto o non presente il bottone non sarà visibile. Il bottone permette di caricare documenti già firmati e passarli alla funzione PassaFileFirmato secondo il formato usato dalla funzione di firma dell'applet -->
                        + "<PARAM name='MostraTuttiICertificati' value='no'>"// <!-- Se impostato a si, l'applet mostrerà tutti i certificati abilitati alla firma (includendo anche quelli di autenticazione), altrimenti da priorità ai certificati di "Non ripudio"; se il parametro è vuoto o non presente il valore di default è no -->
                                                                             //+ "<PARAM name='DisabilitaControlloHost' value='si'>"
                        + "</OBJECT>";
                else
                    testo_cella += "<embed id='siarSignApplet' code='it.unicam.cs.sign.SignApplet.class' archive='"
                        + System.Configuration.ConfigurationManager.AppSettings["DownloadDir"] + "SignApplet.jar' type='application/x-java-applet;version=1.8' "
                        + "height='1px' width='1px' java_arguments='-Xmx2048m' PathDll='PKCS11.dll%inp11lib.dll%bit4xpki.dll%incryptoki2.dll%bit4ipki.dll%bit4opki.dll%OCSCryptoki.dll%asepkcs.dll%SI_PKCS11.dll%cmP11.dll%bit4cpki.dll%bit4p11.dll%asepkcs.dll%libbit4opki.so%libbit4spki.so%libbit4p11.so%libbit4ipki.so%opensc-pkcs11.so%libopensc.dylib%libbit4xpki.dylib%libbit4ipki.dylib%libbit4opki.dylib%libASEP11.dylib' "
                        + "SalvataggioLocale='no' FirmaPDFComeP7m='no' FirmaVisibile='si' NumeroPagina='' PosizioneFirma='" + (_datiFirma.StepFirma == 0 ? "DESTRA" : "SINISTRA") + "' "
                        + "ControlloCodiceFiscaleFirmatario='' TimeServerUrl='" + System.Configuration.ConfigurationManager.AppSettings["CohesionUrl"]
                        + "/SignApplet/TimeService.aspx' SignButtonText='' UploadButtonText='' MostraTuttiICertificati='no' />";

            }
            divAppletFirma.InnerHtml = testo_cella;
        }

        public string GetFileFirmato()
        {
            string result = "";
            try { result = jsser.Deserialize<DatiFirmaJson>(hdnJsonDatiFirma.Value).ContenutoFile; }
            catch { result = ""; }
            return result;
        }
    }
}