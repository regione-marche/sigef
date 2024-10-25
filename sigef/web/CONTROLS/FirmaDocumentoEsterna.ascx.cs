using FirmaRemotaManager;
using SiarLibrary.Web;
using System;

namespace web.CONTROLS
{
    public partial class FirmaDocumentoEsterna : SigefUserControl
    {
        private string _mostra;
        public string Mostra
        {
            get { return _mostra; }
        }

        public byte[] FileCertificatoServer { get; set; }

        public string TipoDocumento { get; set; }

        public SNCUploadFileControl FileCaricato
        {
            get { return ufDocumentoFirmaEsterna; }
        }

        public string Conferma { get; set; }
        public string TxtButton { get; set; }
        public string TitoloControllo { get; set; }

        private EventHandler _documentoFirmatoEvent;
        public EventHandler DocumentoFirmatoEvent
        {
            get { return this._documentoFirmatoEvent; }
            set { _documentoFirmatoEvent = value; }
        }

        private EventHandler _scaricaDocumentoFirmato;
        public EventHandler ScaricaDocumentoFirmato
        {
            get { return this._scaricaDocumentoFirmato; }
            set { _scaricaDocumentoFirmato = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divFirmaEsternaAruba.UniqueID.Replace('$', '_') + "','divBKGMessaggio');";
            btnScaricaDocumentoFirmaEsterna.Click += new EventHandler(_scaricaDocumentoFirmato);
            btnFirmaEsternaVerifica.Click += new EventHandler(_documentoFirmatoEvent);
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnFirmaEsternaVerifica.Text = TxtButton ?? "Appoggio";
            btnFirmaEsternaVerifica.Conferma = Conferma ?? "Appoggio";
            lblTitolo.Text = TitoloControllo ?? "FIRMA DIGITALE ESTERNA";

            base.OnPreRender(e);
        }

        public void ChiudiModale()
        {
            ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopupTemplate();");
        }

        public void loadDocumento(string _cf_firmatario, params string[] _parametri)
        {
            //_datiFirma = new DatiFirmaJson();
            //_datiFirma.DoppiaFirma = DoppiaFirma;
            //_datiFirma.FirmaObbligatoria = FirmaObbligatoria;
            //_datiFirma.CfFirmatario = _cf_firmatario;

            //byte[] doc = null;
            //if (IdFileFirmato > 0)
            //{
            //    // file firmato parzialmente, lo recupero da archivio file
            //    SiarLibrary.ArchivioFile f = new ArchivioFileCollectionProvider().GetById(IdFileFirmato);
            //    if (f != null) doc = f.Contenuto;
            //    hdnNomeFile.Value = "IdFileFirmato-" + IdFileFirmato.ToString();
            //}
            //else doc = getDocumentoFromServer(_parametri);
            //if (doc == null || doc.Length == 0) 
            //    throw new Exception("Non è stato possibile generare il documento richiesto.");
            //_datiFirma.ContenutoFile = Convert.ToBase64String(doc);
            //FileFirmato = doc;

            byte[] doc = getDocumentoFromServer(_parametri);
            if (doc == null || doc.Length == 0)
                throw new Exception("Non è stato possibile generare il documento richiesto.");
            FileCertificatoServer = doc;
        }

        private byte[] getDocumentoFromServer(params string[] parametri)
        {
            ReportTemplates rt = new ReportTemplates();
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
                    tmp_parametri = new string[] { "IdTestata=" + parametri[0] };
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
                    tmp_parametri = new string[] { "dataFine=" + parametri[0], "dataLotto=" + parametri[1], "codPsr=" + parametri[2], "idLotto=" + parametri[3] };
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

        public void LogSign(LogInfo logInfo)
        {
            try
            {
                var logger = new Logger();
                logger.SaveLogFirma(logInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}