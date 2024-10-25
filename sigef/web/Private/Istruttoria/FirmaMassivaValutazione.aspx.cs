using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirmaRemotaManager;
using SiarBLL;
using SiarLibrary;

namespace web.Private.Istruttoria
{
    public partial class FirmaMassivaValutazione : SiarLibrary.Web.PrivatePage
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

        private BandoValutatoriCollectionProvider valutatori_bando_provider;
        private ProgettoValutatoriCollectionProvider valutatori_progetto_provider;

        //string PATH_ISTRUTTORIA = VirtualPathUtility.ToAbsolute("~/Private/Istruttoria/");

        string nome_documento = "VERBALE_VALUTAZIONE_DOMANDA-";

        #region Indici colonne Datagrid

        private int col_Nr = 0,
            col_IdBando = 1,
            col_DescrizioneBando = 2,
            col_IdDomanda = 3,
            col_Piva = 4,
            col_RagioneSociale = 5,
            col_Sede = 6,
            col_VaiChecklist = 7,
            col_Check = 8;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "firma_massiva_valutazione";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();
            var id_utente = Operatore.Utente.IdUtente;

            #region Metodo 1 -> sbagliato
            /*
            //prendo i progetti assegnati all'istruttore con filtro almeno a "I" (Acquisito, ex ricevibile)
            var progetti_istruttore_list = istruttoria_provider
                .Find(null, null, id_utente, null, null, null, null, "I", null)
                .ToArrayList<VistruttoriaDomande>();

            //cerco le valutazioni che non hanno ancora la segnatura //cerco le valutazioni dell'operatore che non hanno ancora la segnatura
            var valutazioni_list = valutazione_provider
                .Find(null, null, true, null, false)
                .ToArrayList<ProgettoValutazione>()
                .Where(v => v.Segnatura == null);

            //verifico quali valutazioni hanno l'ordine corretto per far firmare l'operatore
            var valutatori_coll = new ProgettoValutatoriCollection();
            foreach (ProgettoValutazione pv in valutazioni_list)
            {
                var val_coll = valutatori_progetto_provider.Find(pv.Id, id_utente);

                if (val_coll.Count > 0)
                {
                    var valutatore = valutatori_coll[0];

                    //lo prendo solamente se è il suo turno di firma
                    if (valutatore.Ordine == pv.OrdineFirma + 1)
                        valutatori_coll.Add(valutatore);
                }
            }
            var valutatori_list = valutatori_coll.ToArrayList<ProgettoValutatori>();

            progetti_istruttore_list = (from p in progetti_istruttore_list
                                        join v in valutazioni_list on p.IdProgetto equals v.IdProgetto
                                        //join u in valutatori_list on v.Id equals u.IdProgettoValutazione
                                        select p)
                                        .ToList<VistruttoriaDomande>();
            */
            #endregion

            #region Metodo 2 -> corretto

            //Prendo tutti i record in cui l'utente è un valutatore di un bando
            var valutatori_bando_coll = valutatori_bando_provider.Find(null, null, id_utente, true, null);

            var istruttoria_domande_coll = new VistruttoriaDomandeCollection();
            var valutazioni_coll = new ProgettoValutazioneCollection();
            var prog_valutatori_coll = new ProgettoValutatoriCollection();

            foreach (BandoValutatori bv in valutatori_bando_coll)
            {
                //cerco tutte le valutazioni in cui è presente l'utente
                var valutatori_progetto_coll = valutatori_progetto_provider.Find(null, bv.IdValutatore);

                if (valutatori_progetto_coll.Count > 0)
                {
                    foreach (ProgettoValutatori pv in valutatori_progetto_coll)
                    {
                        prog_valutatori_coll.Add(pv);

                        //per ogni valutazione non chiusa cerco l'istruttoria di ammissibilità della domanda 
                        var valutazione = valutazione_provider.GetById(pv.IdProgettoValutazione);

                        if (valutazione != null && valutazione.IdVariante == null && valutazione.Segnatura == null) // non devo prendere le valutazioni di varianti
                        {
                            valutazioni_coll.Add(valutazione);

                            var istruttoria_coll = istruttoria_provider.Find(null, valutazione.IdProgetto, null, null, null, null, null, "I", null);

                            if (istruttoria_coll.Count > 0)
                                istruttoria_domande_coll.AddCollection(istruttoria_coll);
                        }
                    }
                }
            }

            var istruttoria_domande_list = istruttoria_domande_coll.ToArrayList<VistruttoriaDomande>();
            var valutazioni_list = valutazioni_coll.ToArrayList<ProgettoValutazione>();
            var prog_valutatori_list = prog_valutatori_coll.ToArrayList<ProgettoValutatori>();

            var progetti_istruttore_list = (from u in prog_valutatori_list
                                            join v in valutazioni_list on u.IdProgettoValutazione equals v.Id
                                            join i in istruttoria_domande_list on v.IdProgetto equals i.IdProgetto
                                            where u.Ordine == (v.OrdineFirma + 1)
                                            select i)
                                        .ToList<VistruttoriaDomande>();

            #endregion

            dgFirmeValutazione.Titolo = "Elenco delle domande in valutazione di competenza dell'operatore: " + progetti_istruttore_list.Count.ToString();
            dgFirmeValutazione.DataSource = progetti_istruttore_list;
            dgFirmeValutazione.DataBind();

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

            valutatori_bando_provider = new BandoValutatoriCollectionProvider();
            valutatori_progetto_provider = new ProgettoValutatoriCollectionProvider();
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
            //Se li ho selezionati fanno già parte di quelli che non sono in un comitato di valutazione
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
            byte[] report;

            //Cerco la valutazione del progetto: 
            //se c'è già un file presente recupero quello che è già firmato dai valutatori precedenti
            //altrimenti lo creo nuovo dal report
            var valutazioni = valutazione_provider
                .Find(idProgetto, null, true, null, false)
                .ToArrayList<ProgettoValutazione>()
                .Where(v => v.Segnatura == null);

            if (valutazioni.Count() == 1)
            {
                var valutazione_progetto = valutazioni.ElementAt(0);

                if (valutazione_progetto.IdFile != null)
                {
                    var file_provider = new ArchivioFileCollectionProvider();
                    var af = file_provider.GetById(valutazione_progetto.IdFile);

                    report = af.Contenuto;
                }
                else
                {
                    SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                    string[] tmp_parametri = new string[] { "IdProgetto=" + idProgetto };
                    string nome_file = "";

                    report = rt.getReportByName("rptVerbaleValutazioneDomanda", tmp_parametri);
                    rt.Dispose();
                    nome_file = nome_documento + String.Join("-", tmp_parametri).Replace('=', '_');
                }
            }
            else
                throw new Exception("- La domanda <b>" + idProgetto + "</b> è stata elaborata <b>non correttamente</b> perchè manca la valutazione </br>");

            return report;
        }

        protected string ProtocollaSingoloDocumento(byte[] file_firmato, int id_progetto)
        {
            try
            {
                valutazione_provider.DbProviderObj.BeginTran();

                var progetto = progetto_provider.GetById(id_progetto);
                var bando = bando_provider.GetById(progetto.IdBando);
                var impresa = impresa_provider.GetById(progetto.IdImpresa);
                
                BandoValutatori operatore_valutazione = null;
                ProgettoValutatori progetto_valutatore = null;
                var cerca_valutazione = valutazione_provider
                    .Find(id_progetto, null, true, null, false)
                    .ToArrayList<ProgettoValutazione>()
                    .Where(v => v.Segnatura == null);

                if (cerca_valutazione.Count() == 0)
                    throw new Exception("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>non correttamente</b> perchè manca la valutazione </br>");

                var valutazione = cerca_valutazione.ElementAt(0);

                var bando_valutatori = valutatori_bando_provider.Find(null, progetto.IdBando, null, null, null);
                var progetto_valutatori = valutatori_progetto_provider.Find(valutazione.Id, null);
                var bvc = bando_valutatori.SubSelect(null, progetto.IdBando,
                        Operatore.Utente.IdUtente, null, null, null, null, null);

                var segnatureProgetto = progetto_segnature_provider.Find(progetto.IdProgetto, null, null, null);
                var storicoProgetto = progetto_storico_provider.Find(progetto.IdProgetto, null, "A");

                var riesami = segnatureProgetto.FiltroLikeTipoSegnatura("RID");
                var domandaInRiesame = (progetto.CodFase == "A" 
                    && riesami.Count > 0 
                    && riesami[0].RiapriDomanda 
                    && storicoProgetto.FiltroRevisioneRiesameRicorso(null, true, null).Count == 0);

                var revisioni = segnatureProgetto.FiltroLikeTipoSegnatura("REV");
                var domandaInRevisione = (progetto.CodFase == "A" 
                    && revisioni.Count > 0 
                    && revisioni[0].RiapriDomanda 
                    && storicoProgetto.FiltroRevisioneRiesameRicorso(true, null, null).Count == 0);

                var ricorsi = segnatureProgetto.FiltroLikeTipoSegnatura("RIC");
                var domandaInRicorso = (progetto.CodFase == "A" 
                    && ricorsi.Count > 0 
                    && storicoProgetto.FiltroRevisioneRiesameRicorso(null, null, true).Count == 0);

                var domandaInIstruttoriaProvinciale = progetto.CodFase == "A" && progetto.RiaperturaProvinciale;

                if (progetto.CodStato != "I" &&
                    domandaInRiesame == false &&
                    domandaInRevisione == false &&
                    domandaInRicorso == false &&
                    domandaInIstruttoriaProvinciale == false)
                    throw new Exception("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>non correttamente</b> perchè non si trova nello stato procedurale corretto<br/>");

                if (bvc.Count > 0)
                {
                    operatore_valutazione = bvc[0];
                    var v_coll = progetto_valutatori.SubSelect(null, null, operatore_valutazione.IdValutatore, true, null);

                    if (v_coll.Count > 0)
                        progetto_valutatore = v_coll[0];

                    if (progetto_valutatore.Ordine == valutazione.OrdineFirma + 1)
                    {
                        valutazione.OrdineFirma += 1;
                        valutazione.DataModifica = DateTime.Now;
                        valutazione.Operatore = Operatore.Utente.IdUtente;

                        var file_provider = new ArchivioFileCollectionProvider(valutazione_provider.DbProviderObj);
                        ArchivioFile af = null;

                        if (valutazione.IdFile != null)
                            af = file_provider.GetById(valutazione.IdFile);
                        else
                        {
                            af = new ArchivioFile();
                            af.Tipo = "application/pdf";
                            af.NomeFile = "valutazione_" + valutazione.IdProgetto + ".pdf";
                            af.NomeCompleto = "valutazione progetto " + valutazione.IdProgetto + ".pdf";
                        }

                        af.Contenuto = file_firmato; 
                        af.Dimensione = file_firmato.Length; 

                        file_provider.Save(af);
                        valutazione.IdFile = af.Id;
                    }
                    else
                        throw new Exception("Non è il turno di firma di questo operatore per la domanda " + id_progetto + ".");

                    string identificativo_paleo = "";
                    if (valutazione.OrdineFirma == progetto_valutatori.SubSelect(null, null, null, true, null).Count)
                    {
                        try
                        {
                            Protocollo documento_interno = new Protocollo(bando.CodEnte);
                            documento_interno.setDocumento("valutazione_domanda_" + progetto.IdProgetto + ".pdf", file_firmato); //Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                            string[] ss = bando_provider.GetDatiXProtocollazione(bando.IdBando, progetto.ProvinciaDiPresentazione);
                            string oggetto = "Checklist VALUTAZIONE per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                                + "\n Partita IVA: " + impresa.Cuaa 
                                + "\n Ragione sociale: " + impresa.RagioneSociale
                                + "\n N° Domanda SIGEF: " + progetto.IdProgetto;

                            SiarLibrary.ArchivioFileCollection ff = valutazione_provider.GetFileXProtocollazioneNoStreamValutazione(valutazione.Id);

                            System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                            foreach (SiarLibrary.ArchivioFile f in ff)
                            {
                                try
                                {
                                    SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                    all.Descrizione = f.NomeCompleto;
                                    all.Documento = new SiarBLL.paleoWebService.File();
                                    all.Documento.NomeFile = f.NomeFile;

                                    System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                    allegatoProtocollo.Add("allegato", all);
                                    allegatoProtocollo.Add("id_file", f.Id);
                                    allegatoProtocollo.Add("tipo_origine", "valutazione");
                                    allegatoProtocollo.Add("id_origine", valutazione.Id);
                                    allegatiProtocollo.Add(allegatoProtocollo);

                                }
                                catch (Exception ex) { }
                            }

                            foreach (SiarLibrary.ArchivioFile f in ff)
                            {
                                try
                                {
                                    documento_interno.addAllegato(f.NomeFile, f.HashCode);
                                }
                                catch (Exception ex) { }
                            }

                            identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);
                            valutazione.Segnatura = identificativo_paleo;

                            string[] doc_number_array;
                            string doc_number = null;

                            doc_number_array = identificativo_paleo.Split('|');
                            doc_number = doc_number_array[0];

                            documento_interno.addAllegatiDocInterno(allegatiProtocollo, identificativo_paleo, doc_number);
                        }
                        catch (Exception exc)
                        {
                            throw new Exception("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>non correttamente</b>, errore " + exc.Message +  "<br/>");
                        }
                    }

                    if (test_locale.Value != "true")
                    {
                        valutazione_provider.Save(valutazione);
                        valutazione_provider.DbProviderObj.Commit();
                    }

                    string successo = "- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>correttamente</b>";
                    if (identificativo_paleo != "")
                        successo += " con segnatura " + identificativo_paleo + " <br/>";
                    else
                        successo += " <br/>";

                    return successo;
                }
                else
                    throw new Exception ("- La domanda <b>" + id_progetto + "</b> è stata elaborata <b>non correttamente</b> perchè non è stato trovato il valutatore del bando <br/>"); //throw new Exception("Valutatore bando non trovato.");
            }
            catch (Exception ex)
            {
                valutazione_provider.DbProviderObj.Rollback();
                return (ex.Message);
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

        protected void dgFirmeValutazione_ItemDataBound(object sender, DataGridItemEventArgs e)
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
            }
        }

        #region Button Click

        protected void btnVerificaRequisiti_Click(object sender, EventArgs e)
        {
            InizializzaProvider();
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

            if (selezionati.Length > 0)
            {
                List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();

                string esito = VerificaChecklistSelezionati(id_progetti_list);

                ShowMessage(esito);
            }
            else
                ShowError("Nessuna domanda selezionata.");
        }

        protected void btnFirmaMassivaValutazione_Click(object sender, EventArgs e)
        {
            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di valutazione alla volta.");

                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();

                    //Prendo le istruttorie delle domande selezionate, non devono necessariamente istruite dall'operatore
                    var progetti_istruttore_list = istruttoria_provider
                        .Find(null, null, null, null, null, null, null, "I", null)
                        .ToArrayList<VistruttoriaDomande>();

                    var progetti_verifica_list = progetti_istruttore_list
                        .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

                    foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
                    {
                        var prog = progetto_provider.GetById(istruttoria.IdProgetto);

                        //Sulla valutazione non controllo l'esito della checkllist
                        progetti_firma_list.Add(prog);
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
                            //_datiFirma.ContenutoFile = Convert.ToBase64String(doc);
                            //completePageRender();
                            reportCompilati.Add(report);
                            identificativi_file.Add(nome_documento + prog.IdProgetto); 
                        }

                        if (esito != "")
                            throw new Exception(esito);

                        if (reportCompilati.Count == 0)
                            throw new Exception("Nessun report compilato correttamente");

                        hdnIdProgettiFirma.Value = string.Join("|", identificativi_file.ToArray());

                        var dataToSign = CalamaioUtility.GetDataToSign(reportCompilati, Operatore.Utente.CfUtente, identificativi_file);
                        byte[] byt = System.Text.Encoding.UTF8.GetBytes(dataToSign);
                        hdnDataToSign.Value = Convert.ToBase64String(byt);

                        //ShowMessage("Posso firmare " + progetti_firma_list.Count + " domande");
                        RegisterClientScriptBlock("btnFirmaClick(); return false;");
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

        protected void btnFirmaMassivaRemotaValutazione_Click(object sender, EventArgs e)
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
            logInfo.TipoDocumento = "FirmaMassivaValutazione";
            
            string esito_firma = "OK";
            string dettaglioEsito = "firma effettuata con successo";

            try
            {
                InizializzaProvider();
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFirmeValutazione.Columns[col_Check]).GetSelected();

                if (selezionati.Length > 0)
                {
                    int maxDocumentiFirma = 0;
                    int.TryParse(hdnMaxDocumentiFirma.Value, out maxDocumentiFirma);

                    if (selezionati.Length > maxDocumentiFirma)
                        throw new Exception("E' possibile firmare massivamente al massimo " + maxDocumentiFirma + " istruttorie di valutazione alla volta.");

                    List<int> id_progetti_list = selezionati.Select(int.Parse).ToList();
                    var progetti_firma_list = new List<Progetto>();

                    //Prendo le istruttorie delle domande selezionate, non devono necessariamente istruite dall'operatore
                    var progetti_istruttore_list = istruttoria_provider
                        .Find(null, null, null, null, null, null, null, "I", null)
                        .ToArrayList<VistruttoriaDomande>();

                    var progetti_verifica_list = progetti_istruttore_list
                        .Where(p => id_progetti_list.Any(id => id == p.IdProgetto));

                    foreach (VistruttoriaDomande istruttoria in progetti_verifica_list)
                    {
                        var prog = progetto_provider.GetById(istruttoria.IdProgetto);

                        //Sulla valutazione non controllo l'esito della checkllist
                        progetti_firma_list.Add(prog);
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
                                esito += "Non è stato possibile generare il documento richiesto per il progetto " + prog.IdProgetto + "<br/>";
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

                        ShowMessage("Esito della protocollazione di " + response_list.Count + " valutazione ammissibilità:<br/><br/>" + esito);
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
                logInfo.Esito = esito_firma;
                logInfo.DataFirma = DateTime.Now;
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
                        esito += "- Domanda " + id_progetto + " elaborata_correttamente <br/>";
                    }
                }

                ShowMessage("Esito della firma di " + signedFile.Count + " valutazione ammissibilità:<br/><br/>" + esito);
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
                    {
                        //Session["_bando"] = bando;
                        Redirect(PATH_ISTRUTTORIA + "Valutazione.aspx?iddom=" + id_progetto + "&idb=" + bando.IdBando);
                    }
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