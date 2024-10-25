using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using FirmaRemotaManager;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;

namespace web.Private.Istruttoria
{
    public partial class FirmaMassivaAmmissibilita : SiarLibrary.Web.PrivatePage
    {
        protected string dataToSign { get; set; }

        private VistruttoriaDomandeCollectionProvider istruttoria_provider;
        private BandoCollectionProvider bando_provider;
        private ProgettoCollectionProvider progetto_provider;
        private ProgettoValutazioneCollectionProvider valutazione_provider;
        private IterProgettoCollectionProvider iter_provider;
        private ImpresaCollectionProvider impresa_provider;
        private ProgettoSegnatureCollectionProvider progetto_segnature_provider;
        private ProgettoStoricoCollectionProvider progetto_storico_provider;
        private ProgettoAllegatiIstruttoriaCollectionProvider progetto_allegati_istruttoria_provider;

        string nome_documento = "ESITO_ISTRUTTORIO-";

        #region Indici colonne Datagrid

        private int col_Nr = 0,
            col_IdBando = 1,
            col_DescrizioneBando = 2,
            col_IdDomanda = 3,
            col_Piva = 4,
            col_RagioneSociale = 5,
            col_Sede = 6,
            col_EsitoRequisiti = 7,
            col_VaiChecklist = 8,
            col_Check = 9;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "firma_massiva_ammissibilita";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            //prendo i progetti assegnati all'istruttore con filtro almeno a "I" (Acquisito, ex ricevibile)
            var progetti_istruttore_list = istruttoria_provider
                .Find(null, null, Operatore.Utente.IdUtente, null, null, null, null, "I", null)
                .ToArrayList<VistruttoriaDomande>();

            //filtro per lo stato "I" 
            progetti_istruttore_list = (from dom in progetti_istruttore_list
                                        where dom.CodStato == "I"
                                        select dom)
                                        .ToList<VistruttoriaDomande>();

            //cerco eventuali valutazioni collegate ai progetti 
            var valutazioni_progetti_coll = new ProgettoValutazioneCollection();
            foreach (VistruttoriaDomande istruttoria in progetti_istruttore_list)
            {
                var valutazioni_coll = valutazione_provider
                    .Find(istruttoria.IdProgetto, null, true, null, false);

                if (valutazioni_coll.Count > 0)
                    valutazioni_progetti_coll.AddCollection(valutazioni_coll);
            }

            //se ho trovato valutazioni, tolgo dai progetti quelli in valutazione con segnatura assente
            if (valutazioni_progetti_coll.Count > 0)
            {
                var valutazioni_progetti_list = valutazioni_progetti_coll
                    .ToArrayList<ProgettoValutazione>()
                    .Where(v => v.Segnatura == null);

                if (valutazioni_progetti_list.Count() > 0)
                {
                    //prendo solo i progetti non in valutazione progetti_istruttore_list
                    var xx = (from p in progetti_istruttore_list
                              join v in valutazioni_progetti_list on p.IdProgetto equals v.IdProgetto into pxv
                              from pv in pxv.DefaultIfEmpty()
                              select new { Istruttoria = p, Valutazione = pv });

                    progetti_istruttore_list = (from x in xx
                                                where x.Valutazione == null
                                                select x.Istruttoria)
                                               .ToList<VistruttoriaDomande>();
                }
            }

            // escludo i progetti che hanno allegati in istruttoria ammissibilità
            if (progetti_istruttore_list.Count > 0)
            {
                var id_progetti_list = (from p in progetti_istruttore_list
                                        select p.IdProgetto)
                                    .ToList<IntNT>();

                var progetti_con_allegati = progetto_allegati_istruttoria_provider.GetProgettiConAllegatiInIdProgetti(id_progetti_list);

                var xy = (from p in progetti_istruttore_list
                          join a in progetti_con_allegati on p.IdProgetto equals a.IdProgetto into pxa
                          from pa in pxa.DefaultIfEmpty()
                          select new { Progetto = p, Allegati = pa });

                progetti_istruttore_list = (from x in xy
                                            where x.Allegati == null
                                            select x.Progetto)
                                                   .ToList<VistruttoriaDomande>();
            }

            dgFirmeAmmissibilita.Titolo = "Elenco delle domande di competenza dell'operatore: " + progetti_istruttore_list.Count.ToString();
            dgFirmeAmmissibilita.DataSource = progetti_istruttore_list;
            dgFirmeAmmissibilita.DataBind();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            istruttoria_provider = new VistruttoriaDomandeCollectionProvider();
            bando_provider = new BandoCollectionProvider();
            progetto_provider = new ProgettoCollectionProvider();
            valutazione_provider = new ProgettoValutazioneCollectionProvider();
            iter_provider = new IterProgettoCollectionProvider();
            impresa_provider = new ImpresaCollectionProvider();
            progetto_segnature_provider = new ProgettoSegnatureCollectionProvider();
            progetto_storico_provider = new ProgettoStoricoCollectionProvider();
            progetto_allegati_istruttoria_provider = new ProgettoAllegatiIstruttoriaCollectionProvider();
        }

        private void SvuotaCampiHidden()
        {
            hdnJsonDatiFirma.Value = null;
            hdnDataToSign.Value = null;
            hdnSignedData.Value = null;
            hdnIdProgettiFirma.Value = null;
        }

        private string VerificaChecklist(Progetto _progetto)
        {
            try
            {
                //if (Progetto.CodFase != _Fase) throw new Exception("La domanda di aiuto non si trova nello stato procedurale per il controllo di questi requisiti.");
                //var esiti_progetto = new SiarLibrary.NotAutogeneratedClasses.EsitiChecklistProgettoCollection(_progetto.IdProgetto, _progetto.Fase);
                //if (esiti_progetto.Count == 0)
                //    return "Il bando non prevede la compilazione di una checklist di controllo"; //throw new Exception("Il bando non prevede la compilazione di una checklist di controllo per la fase selezionata, impossibile continuare.");
               
                //Non posso salvare gli step manuali
                #region salvo gli step manuali
                /*
                foreach (SiarLibrary.NotAutogeneratedClasses.EsitiChecklistProgetto e in esiti_progetto)
                {
                    if (!e.Automatico && string.IsNullOrEmpty(e.CodeMethod))
                    {
                        string esito_step = null;
                        //cerco l'hidden che come valore ha l'uniqueid della combo corrispondente allo step
                        string nome_hidden = "hdnEsitoStep" + e.IdStep;
                        foreach (string s in Request.Form.AllKeys)
                        {
                            if (s.EndsWith(nome_hidden))
                            {
                                //trovo il valore selezionato della combo 
                                string id_combo = Request.Form[s];
                                esito_step = Request.Form[id_combo];
                                break;
                            }
                        }
                        saveIterProgetto(e, esito_step);
                    }
                    // se le note sono visibili le salvo anche per gli altri step
                    else if (NoteColumnVisible) saveIterProgetto(e, null);
                }
                */
                #endregion

                var esito = iter_provider.VerificaCheckListDomandaDiAiuto(_progetto.IdProgetto, null, "A", Operatore.Utente.CfUtente);

                return esito;
            }
            catch (Exception ex) { return ex.Message; }
        }

        private string VerificaChecklistSelezionati(List<int> id_progetti_list)
        {
            int esiti_positivi = 0;
            int esiti_negativi = 0;
            int senza_checklist = 0;

            //Dei progetti assegnati all'istruttore prendo solo quelli selezionati
            var progetti_istruttore_list = istruttoria_provider
                .Find(null, null, Operatore.Utente.IdUtente, null, null, null, null, "I", null)
                .ToArrayList<VistruttoriaDomande>();

            var progetti_verifica_list = progetti_istruttore_list
                .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

            foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
            {
                var prog = progetto_provider.GetById(istruttoria.IdProgetto);
                string sing_esito = VerificaChecklist(prog);

                switch (sing_esito)
                {
                    case "SI":
                        esiti_positivi++;
                        break;
                    case "NO":
                        esiti_negativi++;
                        break;
                    default:
                        senza_checklist++;
                        break;
                }
            }

            string esito = @"Riepilogo della verifica delle domande selezionate: <br/>" +
                "- " + esiti_positivi + " domande hanno avuto esito positivo; <br/>" +
                "- " + esiti_negativi + " domande hanno avuto esito negativo; <br/>" +
                "- " + senza_checklist + " domande non hanno una checklist associata. <br/>";

            return esito;
        }

        protected byte[] GetDocumentoSingoloFromServer(int idProgetto)
        {
            SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
            string[] tmp_parametri = new string[] { "IdProgetto=" + idProgetto };
            string nome_file = "";
            
            var report = rt.getReportByName("rptEsitoIstruttorio", tmp_parametri);
            rt.Dispose();
            nome_file = nome_documento + String.Join("-", tmp_parametri).Replace('=', '_');
            
            return report;
        }

        private string ProtocollaSingoloDocumento(byte[] file_firmato, int id_progetto)
        {
            try
            {
                var progetto = progetto_provider.GetById(id_progetto);
                var bando = bando_provider.GetById(progetto.IdBando);

                var documento_interno = new Protocollo(bando.CodEnte);
                documento_interno.setDocumento("checklist_ammissibilita_domanda_" + id_progetto + ".pdf", file_firmato); //Convert.FromBase64String(file_firmato));

                string[] ss = bando_provider.GetDatiXProtocollazione(bando.IdBando, progetto.ProvinciaDiPresentazione);
                var impresa = impresa_provider.GetById(progetto.IdImpresa);
                string oggetto = "Checklist AMMISSIBILITA per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                    + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                    + "\n Ragione sociale: " + impresa.RagioneSociale
                    + "\n N° Domanda: " + id_progetto;

                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                try
                {
                    var segnatureProgetto = progetto_segnature_provider.Find(progetto.IdProgetto, null, null, null);
                    var storicoProgetto = progetto_storico_provider.Find(progetto.IdProgetto, null, "A");

                    var riesami = segnatureProgetto.FiltroLikeTipoSegnatura("RID");
                    var domandaInRiesame = (progetto.CodFase == "A" && riesami.Count > 0 && riesami[0].RiapriDomanda && storicoProgetto.FiltroRevisioneRiesameRicorso(null, true, null).Count == 0);

                    var revisioni = segnatureProgetto.FiltroLikeTipoSegnatura("REV");
                    var domandaInRevisione = (progetto.CodFase == "A" && revisioni.Count > 0 && revisioni[0].RiapriDomanda && storicoProgetto.FiltroRevisioneRiesameRicorso(true, null, null).Count == 0);

                    var ricorsi = segnatureProgetto.FiltroLikeTipoSegnatura("RIC");
                    var domandaInRicorso = (progetto.CodFase == "A" && ricorsi.Count > 0 && storicoProgetto.FiltroRevisioneRiesameRicorso(null, null, true).Count == 0);

                    if (test_locale.Value != "true")
                    {
                        progetto_provider.DbProviderObj.BeginTran();
                        progetto_provider.CambioStatoProgetto(progetto, "A", identificativo_paleo, null, Operatore, domandaInRiesame, domandaInRevisione, domandaInRicorso);

                        if (progetto.IdProgIntegrato != null)
                        {
                            var progetti_correlati = progetto_provider.Find(null, null, progetto.IdProgIntegrato, null, null, false, true);

                            foreach (Progetto p in progetti_correlati)
                                if (p.IdProgetto != p.IdProgIntegrato)
                                    progetto_provider.CambioStatoProgetto(p, "A", Operatore, domandaInRiesame, domandaInRevisione, domandaInRicorso);
                        }

                        progetto_provider.DbProviderObj.Commit();
                    }

                    return "- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>correttamente</b> con segnatura " + identificativo_paleo + "<br/>";
                }
                catch (Exception exc)
                {
                    progetto_provider.DbProviderObj.Rollback();
                    return "- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>non correttamente</b>, errore: + " + exc.Message + "<br/>";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void LogSign(LogInfo logInfo)
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

        protected void dgFirmeAmmissibilita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Header)
            {
                dgi.CssClass = "TESTA1";
                dgi.Cells[col_Nr].ColumnSpan = 1;
                dgi.Cells[col_Nr].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[col_Nr].Text = "</td><td colspan=2 align=center>BANDO</td><td colspan=4 align=center>DOMANDA DI AIUTO</td><td></td><td></td><td></td></tr><tr class='TESTA'><td>Nr.";
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var istruttoria = (VistruttoriaDomande)dgi.DataItem;
                var bando = bando_provider.GetById(istruttoria.IdBando);
                var progetto = progetto_provider.GetById(istruttoria.IdProgetto);

                dgi.Cells[col_DescrizioneBando].Text = bando.Descrizione;
                dgi.Cells[col_Piva].Text = istruttoria.Cuaa;
                dgi.Cells[col_RagioneSociale].Text = istruttoria.RagioneSociale;
                dgi.Cells[col_Sede].Text = istruttoria.Comune + " (" + istruttoria.Sigla + ") - " + istruttoria.Cap;

                var esito = VerificaChecklist(progetto);
                dgi.Cells[col_EsitoRequisiti].Text = esito;
                if (esito == "SI")
                    dgi.Cells[col_EsitoRequisiti].ForeColor = System.Drawing.Color.Green;
                else if (esito == "NO")
                    dgi.Cells[col_EsitoRequisiti].ForeColor = System.Drawing.Color.Red;
            }
        }

        #region Button Click

        protected void btnVerificaRequisiti_Click(object sender, EventArgs e)
        {
            InizializzaProvider();
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeAmmissibilita.Columns[col_Check]).GetSelected();

            if (selezionati.Length > 0)
            {
                List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();

                string esito = VerificaChecklistSelezionati(id_progetti_list);

                ShowMessage(esito);
            }
            else
                ShowError("Nessuna domanda selezionata.");
        }

        protected void btnFirmaMassivaAmmissibilita_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeAmmissibilita.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di ammissibilità alla volta.");

                    int esiti_positivi = 0;
                    int esiti_negativi = 0;
                    int senza_checklist = 0;
                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();

                    //Dei progetti assegnati all'istruttore prendo solo quelli selezionati
                    var progetti_istruttore_list = istruttoria_provider
                        .Find(null, null, Operatore.Utente.IdUtente, null, null, null, null, "I", null)
                        .ToArrayList<VistruttoriaDomande>();

                    var progetti_verifica_list = progetti_istruttore_list
                        .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

                    foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
                    {
                        var prog = progetto_provider.GetById(istruttoria.IdProgetto);
                        string sing_esito = VerificaChecklist(prog);

                        switch (sing_esito)
                        {
                            case "SI":
                                esiti_positivi++;
                                progetti_firma_list.Add(prog);
                                break;
                            case "NO":
                                esiti_negativi++;
                                break;
                            default:
                                senza_checklist++;
                                progetti_firma_list.Add(prog);
                                break;
                        }
                    }

                    if (progetti_firma_list.Count > 0)
                    {
                        var reportCompilati = new List<byte[]>();
                        var identificativi_file = new List<string>();
                        string esito = "";

                        foreach (Progetto prog in progetti_firma_list)
                        {
                            var report = GetDocumentoSingoloFromServer(prog.IdProgetto);
                            if (report == null || report.Length == 0)
                            {
                                esito += "Non è stato possibile generare il documento richiesto per il progetto " + prog.IdProgetto + "<br/>";
                                continue;
                            }
                            reportCompilati.Add(report);
                            identificativi_file.Add("ESITO_ISTRUTTORIO-" + prog.IdProgetto);
                        }

                        if (esito != "")
                            throw new Exception(esito);

                        if (reportCompilati.Count == 0)
                            throw new Exception("Nessun report compilato correttamente");

                        hdnIdProgettiFirma.Value = string.Join("|", identificativi_file.ToArray());

                        var dataToSign = CalamaioUtility.GetDataToSign(reportCompilati, Operatore.Utente.CfUtente, identificativi_file);
                        byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
                        hdnDataToSign.Value = Convert.ToBase64String(byt);

                        RegisterClientScriptBlock("btnFirmaClick(" + reportCompilati.Count + "); return false;");
                    }
                    else
                        ShowError("Nessuna domanda ha superato la checklist: impossibile continuare.");
                }
                else
                    ShowError("Nessuna domanda selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnFirmaMassivaRemotaAmmissibilita_Click(object sender, EventArgs e)
        {
            var logInfo = new LogInfo();
            string username_firma = txtUsernameRS.Value;
            string pin_firma = txtPasswordRS.Value;
            string otp_firma = txtOtpRS.Value;
            string dominio_firma = txtDominioRS.Value;
            if (!string.IsNullOrEmpty(dominio_firma) || !string.IsNullOrWhiteSpace(dominio_firma))
                logInfo.DominioFirma = dominio_firma;
            else
                logInfo.DominioFirma = "frRegioneMarche";
            logInfo.Operatore = username_firma;
            logInfo.TipoFirma = "remota";
            logInfo.TipoDocumento = "FirmaMassivaAmmissibilita";
            
            string esito_firma = "OK";
            string dettaglioEsito = "firma effettuata con successo";

            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeAmmissibilita.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di ammissibilità alla volta.");

                    int esiti_positivi = 0;
                    int esiti_negativi = 0;
                    int senza_checklist = 0;
                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();

                    //Dei progetti assegnati all'istruttore prendo solo quelli selezionati
                    var progetti_istruttore_list = istruttoria_provider
                        .Find(null, null, Operatore.Utente.IdUtente, null, null, null, null, "I", null)
                        .ToArrayList<VistruttoriaDomande>();

                    var progetti_verifica_list = progetti_istruttore_list
                        .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

                    foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
                    {
                        var prog = progetto_provider.GetById(istruttoria.IdProgetto);
                        string sing_esito = VerificaChecklist(prog);

                        switch (sing_esito)
                        {
                            case "SI":
                                esiti_positivi++;
                                progetti_firma_list.Add(prog);
                                break;
                            case "NO":
                                esiti_negativi++;
                                break;
                            default:
                                senza_checklist++;
                                progetti_firma_list.Add(prog);
                                break;
                        }
                    }

                    if (progetti_firma_list.Count > 0)
                    {
                        var reportCompilati = new List<byte[]>();
                        var identificativi_file = new List<string>();
                        string esito = "";
                        var rsclient = new FirmaRemotaOperazioni();
                        var request_list = new List<FirmaRemotaRequest>();

                        foreach (Progetto prog in progetti_firma_list)
                        {
                            var report = GetDocumentoSingoloFromServer(prog.IdProgetto);
                            if (report == null || report.Length == 0)
                            {
                                esito += "- Non è stato possibile generare il documento richiesto per la domanda " + prog.IdProgetto + "<br/>";
                                continue;
                            }

                            reportCompilati.Add(report);
                            identificativi_file.Add(nome_documento + prog.IdProgetto);

                            var request = new FirmaRemotaRequest();
                            request.CfFirmatario = username_firma;
                            request.Pin = pin_firma;
                            request.Otp = otp_firma;
                            if (!string.IsNullOrEmpty(dominio_firma) || !string.IsNullOrWhiteSpace(dominio_firma))
                                request.Domain = dominio_firma;

                            request.IdFile = prog.IdProgetto;
                            request.NomeFile = nome_documento + prog.IdProgetto;
                            request.File = report;
                            request_list.Add(request);
                        }

                        //dati log 
                        string parametriDocumento = string.Join("|", identificativi_file.ToArray());
                        logInfo.ParametriDocumento = parametriDocumento;

                        if (esito != "")
                            throw new Exception(esito);

                        if (reportCompilati.Count == 0)
                            throw new Exception("Nessun report compilato correttamente");

                        var response_list = rsclient.ArubaMultiRemoteSignWs(request_list); 
                        foreach (FirmaRemotaResponse response in response_list)
                        {
                            int id_progetto = response.IdSignedFile ?? default(int);

                            if (string.IsNullOrEmpty(response.ErrorCode))
                            {
                                if (test_locale.Value != "true")
                                {
                                    esito += ProtocollaSingoloDocumento(response.SignedFile, id_progetto);
                                }
                                else
                                {
                                    File.WriteAllBytes(@"C:\test\" + response.NomeFile + "_firmato.pdf", response.SignedFile);
                                    esito += "- Domanda " + id_progetto + " elaborata_correttamente <br/>";
                                }                                
                            }
                            else
                            {
                                esito += "- Errore domanda " + id_progetto + " con codice: " + response.ErrorCode + ": " + response.ErrorDescription + "<br/>";
                                dettaglioEsito = "Errore domanda " + id_progetto + " con codice: " + response.ErrorCode + ": " + response.ErrorDescription + "|";
                            } 
                        }

                        ShowMessage("Esito della protocollazione di " + response_list.Count + " ammissibilità:<br/><br/>" + esito);
                    }
                    else
                    {
                        esito_firma = "KO";
                        dettaglioEsito = "Nessuna domanda ha superato la checklist: impossibile continuare.";
                        ShowError("Nessuna domanda ha superato la checklist: impossibile continuare.");
                    }
                }
                else
                {
                    esito_firma = "KO";
                    dettaglioEsito = "Nessuna domanda selezionata.";
                    ShowError("Nessuna domanda selezionata.");
                }
            }
            catch (Exception ex)
            {
                esito_firma = "KO";
                dettaglioEsito = ex.Message;
                ShowError(ex.Message);
            }
            finally
            {
                logInfo.DataFirma = DateTime.Now;
                logInfo.Esito = esito_firma;
                logInfo.DettaglioEsito = dettaglioEsito;
                LogSign(logInfo);
            }
        }

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlstring = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(hdnSignedData.Value));
                var signedFile = CalamaioUtility.ExtractSignedDataCalamaio1(xmlstring);
                string esito = "";

                foreach (SignInfo data in signedFile)
                {
                    InizializzaProvider();

                    var singolo_documento = Convert.FromBase64String(data.SignedData);
                    int id_progetto = int.Parse(data.DocumentIdentifier.Substring(nome_documento.Length));

                    if (test_locale.Value != "true")
                    {
                        esito += ProtocollaSingoloDocumento(singolo_documento, id_progetto);
                    }
                    else
                    {
                        File.WriteAllBytes(@"C:\test\" + data.DocumentIdentifier + "_firmato.pdf", singolo_documento);
                        esito += "- Domanda " + id_progetto + " elaborata_correttamente";
                    }
                }

                ShowMessage("Esito della protocollazione di " + signedFile.Count + " ammissibilità:<br/><br/>" + esito);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                SvuotaCampiHidden();
            }
        }

        protected void btnVaiAChecklist_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            int id_progetto;
            if (int.TryParse(hdnIdProgetto.Value, out id_progetto))
            {
                var progetto = progetto_provider.GetById(id_progetto);

                if (progetto != null)
                {
                    var bando = bando_provider.GetById(progetto.IdBando);

                    if (bando != null)
                        Redirect(PATH_ISTRUTTORIA + "ChecklistAmmissibilita.aspx?iddom=" + id_progetto + "&idb=" + bando.IdBando);
                    else
                        ShowError("Bando non trovato");
                }
                else
                    ShowError("Progetto non trovato");
                
            }
            else
                ShowError("Nessuna domanda selezionata");
        }

        #endregion
    }
}