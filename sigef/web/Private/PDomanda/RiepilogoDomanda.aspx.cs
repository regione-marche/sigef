using SiarBLL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using FirmaRemotaManager;
using System.IO;
using SiarLibrary;
using System.Security.Cryptography;

namespace web.Private.PDomanda
{
    public partial class RiepilogoDomanda : SiarLibrary.Web.ProgettoPage
    {
        SiarLibrary.StepCollection passiFondamentali = new SiarLibrary.StepCollection();
        SiarLibrary.PersoneXImprese rlegale = null;
        web.CONTROLS.DatiDomanda ucDatiDomanda = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;
            modaleFirmaEsterna.ScaricaDocumentoFirmato = btnScaricaDocumento_Click;
            modaleFirmaEsterna.DocumentoFirmatoEvent = btnFirmaEsternaProtocolla_Click;

            if (IsPostBack)
            {
                //in base al pulsante che premo nascondo il control della firma esterna o quello di Calamaio
                Control control = null;
                string controlName = Page.Request.Params["__EVENTTARGET"];
                if (!String.IsNullOrEmpty(controlName))
                {
                    control = Page.FindControl(controlName);
                }
                else
                {
                    string controlId;
                    Control foundControl;
                    foreach (string ctl in Page.Request.Form)
                    {
                        if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                        {
                            controlId = ctl.Substring(0, ctl.Length - 2);
                            foundControl = Page.FindControl(controlId);
                        }
                        else
                        {
                            foundControl = Page.FindControl(ctl);
                        }
                        if (!(foundControl is Button || foundControl is ImageButton)) 
                            continue;
                        control = foundControl;
                        break;
                    }
                }
                if (control != null && control.ClientID != null)
                {
                    string CtrlID = control.ClientID.Replace('_', '$');

                    //Se premo il pulsante di presentazione domanda o della firma digitale tolgo la firma esterna
                    if (CtrlID == btnPresenta.UniqueID
                        || CtrlID.Contains("ucFirmaDocumentoCalamaio") //Firma remota
                        || CtrlID.Contains("btnFirma2")) //Firma token
                    {
                        modaleFirmaEsterna.Visible = false;
                        modaleFirmaEsterna.Dispose();
                    }

                    if (CtrlID == btnFirmaEsterna.UniqueID
                        || CtrlID.Contains("btnFirmaEsternaVerifica")) 
                    {
                        ucFirmaDocumento.Visible = false;
                        ucFirmaDocumento.Dispose();

                        if (CtrlID == btnFirmaEsterna.UniqueID)
                            ScaricaDocumento();
                    }
                }
            }

            ucDatiDomanda = (web.CONTROLS.DatiDomanda)this.Master.FindControl("cphContenuto").Controls[0];
            if (!Bando.FirmaRichiesta) trPredisposizione.Visible = false;
            SiarBLL.PersoneXImpreseCollectionProvider pxi_provider = new SiarBLL.PersoneXImpreseCollectionProvider();

            // aggiunto controllo per bando energia
            if (Azienda.IdRapprlegaleUltimo == null)
                Redirect("Anagrafica.aspx", "Non sono stati salvati i dati anagrafici per l'impresa, la sede legale e il legale rappresentante. Prima di proseguire è necessario compilarli.", true);

            rlegale = pxi_provider.GetById(Azienda.IdRapprlegaleUltimo);
            if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
            {
                // controllo se l'operatore è nella compagine aziendale ed è abilitato alla firma
                SiarLibrary.PersoneXImpreseCollection cc = pxi_provider.Find(Operatore.Utente.IdPersonaFisica, null, Azienda.IdImpresa, null, true, true);
                if (cc.Count > 0) rlegale = cc[0];
            }
            if (rlegale == null) Redirect("RicercaDomanda.aspx", "L'impresa non ha un rappresentante legale valido. Impossibile continuare.", true);
            if (Bando.Aggregazione)
            {
                btnPrev.Value = "<<< (7/8)";
                btnCurrent.Value = "(8/8)";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            #region passifondamentali
            SiarLibrary.Step Allegati = new SiarLibrary.Step();
            Allegati.IdStep = 3;
            Allegati.Descrizione = "Allegati";
            Allegati.Url = "AllegatiDomanda.aspx";
            passiFondamentali.Add(Allegati);

            SiarLibrary.Step Dichiarazioni = new SiarLibrary.Step();
            Dichiarazioni.IdStep = 4;
            Dichiarazioni.Descrizione = "Dichiarazioni";
            Dichiarazioni.Url = "Dichiarazioni.aspx";
            passiFondamentali.Add(Dichiarazioni);

            SiarLibrary.Step Requisiti = new SiarLibrary.Step();
            Requisiti.IdStep = 5;
            Requisiti.Descrizione = "Checklist Presentazione Domanda";
            Requisiti.Url = "ChecklistPresentazione.aspx";
            passiFondamentali.Add(Requisiti);
            #endregion

            dg.DataSource = passiFondamentali;
            dg.DataBind();

            bool Pregresso = false;
            string StPregresso = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_PregressoDomanda(Progetto.IdBando);
            if (StPregresso == "True")
                Pregresso = true;

            if (!Pregresso)
            {
                if (Progetto.CodStato != "P")
                {
                    btnRicevuta.Disabled = false;
                    btnRicevuta.Attributes.Add("onclick", "SNCVisualizzaReport('rptFrontespizio',1,'ID_Domanda=" + Progetto.IdProgetto + "');");
                    btnFirmaEsterna.Enabled = false;

                    //SiarLibrary.ProgettoAllegatiCollection allegati = new ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
                    //int numeroAllegati = allegati.Count;

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, Progetto.Segnatura);
                    bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, Progetto.IdProgetto, Progetto.Segnatura);

                    if (!allegatiProtocollatiOk)
                    {
                        rowProtocolliAllegati.Visible = true;
                        btnProtocollaAllegati.Enabled = ((Progetto.CodStato == "L") || (Progetto.CodStato == "I")) && (Progetto.OperatoreCreazione == Operatore.Utente.IdUtente || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica);
                    }
                    else
                    {
                        rowProtocolliAllegati.Visible = false;
                        btnProtocollaAllegati.Enabled = false;
                    }
                }
                else
                {
                    if (Bando.DataScadenza <= DateTime.Now) ShowError("Sono scaduti i termini per la presentazione della domanda.");
                    else
                    {

                        if (Progetto.FirmaPredisposta)
                        {
                            btnPredisponi.Text = "Annulla predisposizione";
                            btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
                        }
                        btnPredisponi.Enabled = TipoModifica == 2;
                        btnFirmaEsterna.Enabled =
                            btnPresenta.Enabled = (!Progetto.FirmaPredisposta && TipoModifica == 2)
                                                || (Progetto.FirmaPredisposta && rlegale.IdPersona == Operatore.Utente.IdPersonaFisica);

                        //se rappresentante legale nascondo predisposizione
                        if (rlegale.IdPersona == Operatore.Utente.IdPersonaFisica)
                            trPredisposizione.Visible = false;
                    }
                }
            }
            else
            {
                if (Progetto.CodStato == "P" && (Progetto.OperatoreCreazione == Operatore.Utente.IdUtente || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica))
                    btnInserisciSegnatura.Enabled = true;
                else
                    btnInserisciSegnatura.Enabled = false;
                trPredisposizione.Visible = false;
                trPulsanti.Visible = false;
                trPulsantiPregresso.Visible = true;

                ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
                //imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + txtSegnatura.Text + "');");
                //imgSegnatura.Style.Add("cursor", "pointer");
            }
            
            if (!Bando.FirmaRichiesta)
                btnFirmaEsterna.Visible = false;
            else
            {
                modaleFirmaEsterna.TxtButton = "Presenta domanda";
                modaleFirmaEsterna.Conferma = "Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di aiuto. Continuare?";
            }

            base.OnPreRender(e);
        }

        protected void btnPredisponi_Click(object sender, EventArgs e)
        {
            try
            {
                string verifica = "";
                if(!Progetto.FirmaPredisposta)
                    ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaAiuto(Progetto.IdProgetto);
                if (!string.IsNullOrEmpty(verifica)) RegisterClientScriptBlock("predisposizione_warnings('" + verifica + "');");
                else btnPredisponiPost_Click(sender, e);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPredisponiPost_Click(object sender, EventArgs e)
        {
            try
            {
                PredisponiAllaFirma(Progetto.FirmaPredisposta);
                string messaggio = "Domanda di aiuto predisposta correttamente alla firma.";
                if (!Progetto.FirmaPredisposta) messaggio = "Predisposizione alla firma annullata correttamente, è ora possibile riprendere la modifica dei dati della domanda.";
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void PredisponiAllaFirma(bool annulla_predisposizione)
        {
            Progetto.FirmaPredisposta = !annulla_predisposizione;
            ProgettoProvider.Save(Progetto);
            ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
            ucDatiDomanda.ForzaCaricamentoDati = true;
            ucDatiDomanda.loadData();
        }

        private string ControlliPreFirma()
        {
            if (Bando == null)
                throw new Exception("Bando non trovato");
            var bando_covid_coll = new BandoConfigCollectionProvider().Find(Bando.IdBando, "BANDOCOVID", null, true, true);
            if (bando_covid_coll.Count > 0)
                Redirect(PATH_COVID + "RichiestePredomanda.aspx", "Per richiedere un contributo è necessario completare la richiesta nella sezione apposita.", true);

            // Se è il primo progetto deve avere almeno una visura per poter andare avanti 
            var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();
            var visureCollection = impresaVisuraProvider.FindVisureImpresa(Progetto.IdImpresa);

            var progettoProvider = new ProgettoCollectionProvider();
            var progettiColl = progettoProvider.Select(null, null, null, null, null, null, true, null, null, null, Progetto.IdImpresa, null, null, null, null);

            if (progettiColl.Count == 0 && visureCollection.Count == 0)
                Redirect(PATH_PDOMANDA + "GestioneVisure.aspx", "Attenzione! Per presentare la domanda occorre inserire almeno una visura.", true);

            Progetto.ProvinciaDiPresentazione = "AN";
            ProgettoProvider.Save(Progetto);
            //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente); non aggiorno piu' l'operatore (a questo punto puo' essere solo il rapp legale) perche altrimenti perdo il dato di chi l'ha compilata 
            // verifica 
            return ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaAiuto(Progetto.IdProgetto);
        }

        protected void btnPresenta_Click(object sender, EventArgs e)
        {
            try
            {
                string verifica = ControlliPreFirma();
                if (!string.IsNullOrEmpty(verifica))
                    RegisterClientScriptBlock("presentazione_warnings('" + verifica + "');");
                else
                    presentaPost(); // btnPresentaPost_Click(sender, e);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPresentaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (Progetto.CodStato != "P") throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                SiarLibrary.ModelloDomandaCollection cc = new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null);
                if (cc.Count == 0) throw new Exception("Nessun modello di documento digitale definito per il presente bando, impossibile continuare.");
                ucFirmaDocumento.DoppiaFirma = ProgettoProvider.AbilitaDoppiaFirmaDomandaAiuto(Progetto.IdProgetto, false);
                ucFirmaDocumento.FirmaObbligatoria = Bando.FirmaRichiesta;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Progetto.IdProgetto, cc[0].IdDomanda);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void presentaPost()
        {
            try
            {
                if (Progetto.CodStato != "P") throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                SiarLibrary.ModelloDomandaCollection cc = new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null);
                if (cc.Count == 0) throw new Exception("Nessun modello di documento digitale definito per il presente bando, impossibile continuare.");
                ucFirmaDocumento.DoppiaFirma = ProgettoProvider.AbilitaDoppiaFirmaDomandaAiuto(Progetto.IdProgetto, false);
                ucFirmaDocumento.FirmaObbligatoria = Bando.FirmaRichiesta;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Progetto.IdProgetto, cc[0].IdDomanda);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void ProtocollaDomandaDiAiuto(byte[] fileDaProtocollare)
        {
            try
            {
                if (Progetto.CodStato != "P")
                    throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                if (fileDaProtocollare == null)
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo p = new SiarLibrary.Protocollo(Bando.CodEnte);
                //p.setCorrispondente(rlegale.Cognome + " " + rlegale.Nome, null, null); 
                p.setDocumento("doc_principale_domanda.pdf", fileDaProtocollare);

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                string oggetto = "Domanda di adesione al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\nRif." + ss[3] + "\nN° Domanda: "
                    + Progetto.IdProgetto
                    + "\n Impresa: " + ucDatiDomanda.Impresa.CodiceFiscale + " " + ucDatiDomanda.Impresa.RagioneSociale;

                // carico gli allegati su paleo 
                SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
                //Dichiarazione nome e hash degli allegati per l'impronta 
                foreach (SiarLibrary.ProgettoAllegati allegato in allegati)
                {
                    try
                    {
                        if (allegato.IdFile != null)
                        {
                            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(allegato.IdFile);
                            if (f == null)
                                throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                            p.addAllegato(f.NomeFile, f.HashCode);
                        }
                    }
                    catch (Exception ex) { }
                }

                //se il bando non prevede la firma dichiaro anche l'allegato con il token Cohesion 
                if (!Bando.FirmaRichiesta)
                {
                    object sessione_cohesion = Session["COHESION_TOKEN"];
                    if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                        throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                    p.addAllegato("Autenticazione_Operatore.xml", p.GetSHA256(System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString())));
                }

                string segnatura = "";
                string[] doc_number_array;
                string doc_number = null;
                if (Azienda.IdImpresa == int.Parse(ConfigurationManager.AppSettings["IdImpresaRegioneMarche"]))
                {
                    segnatura = p.DocumentoInterno(oggetto, ss[4]);
                    doc_number_array = segnatura.Split('|');
                    doc_number = doc_number_array[0];
                }
                else
                {
                    p.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                    segnatura = p.ProtocolloIngresso(oggetto, ss[4]);
                }

                PianoInvestimentiCollectionProvider investimentiprovider = new PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                PrioritaXInvestimentiCollectionProvider priorita_provider = new PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                GraduatoriaProgettiCollectionProvider graduatoria_provider = new GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);
                //LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new LocalizzazioneInvestimentoCollectionProvider(ProgettoProvider.DbProviderObj);                 
                try
                {
                    //rendo definitivo tutto 
                    ProgettoProvider.DbProviderObj.BeginTran();
                    //stessa procedura sia se integrato che altrimenti 
                    SiarLibrary.ProgettoCollection progettiCorrelati = ProgettoProvider.Find(null, null, Progetto.IdProgetto, null, null, null, null);
                    //se non e' multimisura occorre che aggiungo il progetto 
                    if (progettiCorrelati.Count == 0) progettiCorrelati.Add(Progetto);

                    if (Bando.FascicoloRichiesto && Progetto.IdFascicolo == null)
                        throw new Exception("Il fascicolo aziendale dell'impresa non è stato trovato. Occorre scaricarlo per continuare.");

                    // per le domande con la predisposizione alla firma impongo l'operatore di rilascio=operatore di modifica 
                    // per compatibilità con le successive regole di accesso alla domanda 
                    SiarLibrary.Operatore op_rilascio = Operatore;
                    if (Progetto.FirmaPredisposta)
                    {
                        SiarLibrary.Utenti u = new UtentiCollectionProvider().GetById(Progetto.Operatore);
                        if (u != null) op_rilascio.Utente = u;
                    }

                    foreach (SiarLibrary.Progetto prog in progettiCorrelati)
                    {
                        //duplico gli investimenti per permettere l'istruttoria 
                        SiarLibrary.PianoInvestimentiCollection investcoll = investimentiprovider.Find(null, prog.IdProgetto, null, null, null, null, null);
                        if (investcoll.FiltroInvestimentoOriginale(false).Count <= 0)
                        {//se non ci sono investimenti clonati allora li clono 
                            foreach (SiarLibrary.PianoInvestimenti invest in investcoll)
                            {
                                invest.MarkAsNew();
                                invest.IdInvestimentoOriginale = invest.IdInvestimento;
                                invest.Ammesso = false;
                                invest.IdInvestimento = null;
                                investimentiprovider.Save(invest);

                                SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_provider.Find(null, invest.IdInvestimentoOriginale, null, null);
                                foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                                {
                                    pr.MarkAsNew();
                                    pr.IdInvestimento = invest.IdInvestimento;
                                    priorita_provider.Save(pr);
                                }
                            }
                        }
                        //salvo la provincia e operatore di presentazione per ogni progetto correlato 
                        prog.ProvinciaDiPresentazione = Progetto.ProvinciaDiPresentazione;
                        prog.FlagDefinitivo = true;
                        //ProgettoProvider.Save(prog); non necessario 

                        if (prog.IdProgetto == prog.IdProgIntegrato || prog.IdProgIntegrato == null)
                        {
                            ProgettoProvider.CambioStatoProgetto(prog, "L", segnatura, op_rilascio);
                            ProgettoProvider.CambioStatoProgetto(prog, "I", segnatura, op_rilascio);
                        }
                        else
                        {
                            ProgettoProvider.CambioStatoProgetto(prog, "L", op_rilascio);
                            ProgettoProvider.CambioStatoProgetto(prog, "I", op_rilascio);
                        }
                    }

                    // Controllo la riga su graduatoria progetto ALTRIMENTI LA CREO 
                    SiarLibrary.GraduatoriaProgetti graduatoria = null;
                    SiarLibrary.GraduatoriaProgettiCollection grad_coll = graduatoria_provider.Find(Progetto.IdBando, Progetto.IdProgetto, null);
                    if (grad_coll.Count > 0)
                        graduatoria = grad_coll[0];
                    else
                        graduatoria = new SiarLibrary.GraduatoriaProgetti();
                    graduatoria.IdBando = Bando.IdBando;
                    graduatoria.IdProgetto = Progetto.IdProgetto;
                    graduatoria.Punteggio = 0;
                    graduatoria.DataValutazione = DateTime.Today;
                    graduatoria.Operatore = Operatore.Utente.CfUtente;
                    graduatoria_provider.Save(graduatoria);

                    ProgettoProvider.DbProviderObj.Commit();
                    //aggiorno la sessione 
                    Progetto = ProgettoProvider.GetById(Progetto.IdProgetto);
                    btnPresenta.Enabled = false;
                    btnFirmaEsterna.Enabled = false;
                    ucDatiDomanda.ForzaCaricamentoDati = true;
                    ucDatiDomanda.loadData();

                    System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                    if (!Bando.FirmaRichiesta)
                    {
                        // carico il token di cohesion come allegato alla domanda 
                        object sessione_cohesion = Session["COHESION_TOKEN"];
                        if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                            throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                        //p.addAllegato("Autenticazione_Operatore.xml", System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString()), "xml"); 

                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();

                        all.Descrizione = "Autenticazione_Operatore.xml";
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                        all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                        //a.Documento.Estensione = estensione; 
                        //a.NumeroPagine = 1; 
                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", -1);
                        allegatoProtocollo.Add("tipo_origine", "progetto");
                        allegatoProtocollo.Add("id_origine", Progetto.IdProgetto);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }

                    // carico gli allegati su paleo /// spostato sopra riga 205 il 16/09/2019 per aggiornamento paleo  
                    //SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null); 
                    //int numeroAllegati = 0; 
                    SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
                    foreach (SiarLibrary.ProgettoAllegati a in allegati)
                    {
                        try
                        {
                            if (a.IdFile != null)
                            {
                                SiarLibrary.ArchivioFile f = new ArchivioFileCollectionProvider().GetById(a.IdFile);
                                if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");

                                SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, f.Id, null, null);
                                if (exist.Count == 0)
                                {
                                    SiarLibrary.AllegatiProtocollati ap = new SiarLibrary.AllegatiProtocollati();
                                    ap.IdVariante = DBNull.Value;
                                    ap.IdProgetto = Progetto.IdProgetto;
                                    ap.IdDomandaPagamento = DBNull.Value;
                                    ap.IdIntegrazione = DBNull.Value;
                                    ap.IdFile = f.Id;
                                    ap.Protocollato = false;
                                    allegatiProtocollatiProvider.Save(ap);
                                    //numeroAllegati++; 
                                }
                            }
                        }
                        catch (Exception ex) { }
                    }

                    foreach (SiarLibrary.ProgettoAllegati x in allegati)
                    {
                        try
                        {
                            if (x.IdFile != null)
                            {
                                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(x.IdFile);
                                if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                                string estensione = null;
                                if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                                //p.addAllegato(f.NomeFile, f.Contenuto, estensione); 
                                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                all.Descrizione = f.NomeFile;
                                all.Documento = new SiarBLL.paleoWebService.File();
                                all.Documento.NomeFile = f.NomeFile;

                                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                allegatoProtocollo.Add("allegato", all);
                                allegatoProtocollo.Add("id_file", f.Id);
                                allegatoProtocollo.Add("tipo_origine", "progetto");
                                allegatoProtocollo.Add("id_origine", Progetto.IdProgetto);
                                allegatiProtocollo.Add(allegatoProtocollo);
                            }
                        }
                        catch (Exception ex) { }
                    }

                    SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);

                    if (Azienda.IdImpresa == int.Parse(System.Configuration.ConfigurationManager.AppSettings["IdImpresaRegioneMarche"]))
                        protocolloAll.addAllegatiDocInterno(allegatiProtocollo, segnatura, doc_number);
                    else
                        protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);
                    //protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura); 

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, segnatura); 
                    bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, Progetto.IdProgetto, segnatura);

                    if (allegatiProtocollatiOk)
                        //Redirect(PATH_PDOMANDA + "RiepilogoDomanda.aspx", "Domanda di aiuto presentata e protocollata correttamente.", false);
                        ShowMessage("Domanda di aiuto presentata e protocollata correttamente."); 
                    else
                        //Redirect(PATH_PDOMANDA + "RiepilogoDomanda.aspx", "Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.", true);
                        ShowError("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante."); 
                }
                catch (Exception ex)
                {
                    ProgettoProvider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore durante la presentazione domanda di aiuto";
                    string testEmail = "Domanda di aiuto: " + Progetto.IdProgetto + "\nSegnatura: " + segnatura + "\nOperatore: " +
                            Operatore.Utente.CfUtente + " - " + Operatore.Utente.Nominativo
                            + "\nOperatore: " + Operatore.Utente.Profilo + " - " + Operatore.Utente.Ente + "\n\n" + ex.Message;
                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                    throw ex;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void ProtocollaDocFirmatoEvent(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                var filePrincipale = Convert.FromBase64String(ucFirmaDocumento.FileFirmato);
                ProtocollaDomandaDiAiuto(filePrincipale);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);
            System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

            // controllo se ci sono allegati non inseriti nella tabella allegati protocollati e li inserisco
            SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
            SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
            SiarLibrary.AllegatiProtocollatiCollection apc = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, null, null, null);

            if (allegati.Count != apc.Count)
            {
                foreach (SiarLibrary.ProgettoAllegati a in allegati)
                {
                    try
                    {
                        if (!Bando.FirmaRichiesta)
                        {
                            SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, "-1", null, null);

                            if (exist.Count == 0)
                            {
                                // carico il token di cohesion come allegato alla domanda
                                object sessione_cohesion = Session["COHESION_TOKEN"];
                                if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                                //p.addAllegato("Autenticazione_Operatore.xml", System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString()), "xml");

                                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();

                                all.Descrizione = "Autenticazione_Operatore.xml";
                                all.Documento = new SiarBLL.paleoWebService.File();
                                all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                                all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                                //a.Documento.Estensione = estensione;
                                //a.NumeroPagine = 1;
                                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                allegatoProtocollo.Add("allegato", all);
                                allegatoProtocollo.Add("id_file", -1);
                                allegatoProtocollo.Add("tipo_origine", "progetto");
                                allegatoProtocollo.Add("id_origine", Progetto.IdProgetto);
                                allegatiProtocollo.Add(allegatoProtocollo);
                            }
                        }

                        if (a.IdFile != null)
                        {
                            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a.IdFile);
                            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");

                            SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, f.Id, null, null);
                            if (exist.Count == 0)
                            {
                                SiarLibrary.AllegatiProtocollati ap = new SiarLibrary.AllegatiProtocollati();
                                ap.IdVariante = DBNull.Value;
                                ap.IdProgetto = Progetto.IdProgetto;
                                ap.IdDomandaPagamento = DBNull.Value;
                                ap.IdIntegrazione = DBNull.Value;
                                ap.IdFile = f.Id;
                                ap.Protocollato = false;
                                allegatiProtocollatiProvider.Save(ap);
                            }
                        }
                    }
                    catch (Exception ex) { }
                }

            }
            // cerco gli allegati non protocollati
            SiarBLL.ArchivioFileCollectionProvider ff = new SiarBLL.ArchivioFileCollectionProvider();

            apc = apc.SubSelect(null, Progetto.IdProgetto, null, null, null, null, null, false, null, null, null);

            foreach (SiarLibrary.AllegatiProtocollati a in apc)
            {
                SiarLibrary.ArchivioFile f = ff.GetById(a.IdFile);
                //protocollo.addAllegato(f.NomeFile + "." + f.Tipo, f.Contenuto, f.Tipo);
                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                all.Descrizione = f.NomeFile;
                all.Documento = new SiarBLL.paleoWebService.File();
                all.Documento.NomeFile = f.NomeFile;

                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                allegatoProtocollo.Add("allegato", all);
                allegatoProtocollo.Add("id_file", f.Id);
                allegatoProtocollo.Add("tipo_origine", "progetto");
                allegatoProtocollo.Add("id_origine", Progetto.IdProgetto);
                allegatiProtocollo.Add(allegatoProtocollo);
            }

            protocolloAll.addAllegatiProtocollo(allegatiProtocollo, Progetto.Segnatura);

            //SiarLibrary.AllegatiProtocollatiCollection allegatiDomanda = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, null, null, null);

            //bool allegatiProtocollatiOk = checkAllegatiProtocollati(allegatiDomanda.Count, Progetto.Segnatura);
            bool allegatiProtocollatiOk = allegatiProtocollatiProvider.CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, Progetto.IdProgetto, Progetto.Segnatura);

            if (allegatiProtocollatiOk) ShowMessage("Domanda di aiuto presentata e protocollata correttamente.");
            else ShowError("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

        }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                Progetto.ProvinciaDiPresentazione = "AN";
                ProgettoProvider.Save(Progetto);
                //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente); non aggiorno piu' l'operatore (a questo punto puo' essere solo il rapp legale) perche altrimenti perdo il dato di chi l'ha compilata
                // verifica
                string verifica = ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaAiuto(Progetto.IdProgetto);
                if (!string.IsNullOrEmpty(verifica)) RegisterClientScriptBlock("presentazione_warningsPregresso('" + verifica + "');");
                else btnInserisciSegnaturaPost_Click(sender, e);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInserisciSegnaturaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (Progetto.CodStato != "P") throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }

        }
        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            try
            {
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnatura.Text == null || txtSegnatura.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }

                SiarBLL.PianoInvestimentiCollectionProvider investimentiprovider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(ProgettoProvider.DbProviderObj);                

                //rendo definitivo tutto
                ProgettoProvider.DbProviderObj.BeginTran();
                //stessa procedura sia se integrato che altrimenti
                SiarLibrary.ProgettoCollection progettiCorrelati = ProgettoProvider.Find(null, null, Progetto.IdProgetto, null, null, null, null);
                //se non e' multimisura occorre che aggiungo il progetto
                if (progettiCorrelati.Count == 0) progettiCorrelati.Add(Progetto);

                if (Bando.FascicoloRichiesto && Progetto.IdFascicolo == null)
                    throw new Exception("Il fascicolo aziendale dell'impresa non è stato trovato. Occorre scaricarlo per continuare.");

                // per le domande con la predisposizione alla firma impongo l'operatore di rilascio=operatore di modifica
                // per compatibilità con le successive regole di accesso alla domanda
                SiarLibrary.Operatore op_rilascio = Operatore;
                if (Progetto.FirmaPredisposta)
                {
                    SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(Progetto.Operatore);
                    if (u != null) op_rilascio.Utente = u;
                }

                foreach (SiarLibrary.Progetto prog in progettiCorrelati)
                {
                    //duplico gli investimenti per permettere l'istruttoria
                    SiarLibrary.PianoInvestimentiCollection investcoll = investimentiprovider.Find(null, prog.IdProgetto, null, null, null, null, null);
                    if (investcoll.FiltroInvestimentoOriginale(false).Count <= 0)
                    {//se non ci sono investimenti clonati allora li clono
                        foreach (SiarLibrary.PianoInvestimenti invest in investcoll)
                        {
                            invest.MarkAsNew();
                            invest.IdInvestimentoOriginale = invest.IdInvestimento;
                            invest.Ammesso = false;
                            invest.IdInvestimento = null;
                            investimentiprovider.Save(invest);

                            SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_provider.Find(null, invest.IdInvestimentoOriginale, null, null);
                            foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                            {
                                pr.MarkAsNew();
                                pr.IdInvestimento = invest.IdInvestimento;
                                priorita_provider.Save(pr);
                            }
                        }
                    }
                    //salvo la provincia e operatore di presentazione per ogni progetto correlato
                    prog.ProvinciaDiPresentazione = Progetto.ProvinciaDiPresentazione;
                    prog.FlagDefinitivo = true;
                    //ProgettoProvider.Save(prog); non necessario


                    if (prog.IdProgetto == prog.IdProgIntegrato || prog.IdProgIntegrato == null)
                    {
                        ProgettoProvider.CambioStatoProgettoPregresso(prog, "L", ckAttivo.Checked ? "ND" : txtSegnatura.Text, Convert.ToDateTime(txtData.Text), op_rilascio, false, false, false);
                        ProgettoProvider.CambioStatoProgettoPregresso(prog, "I", ckAttivo.Checked ? "ND" : txtSegnatura.Text, Convert.ToDateTime(txtData.Text), op_rilascio, false, false, false);
                    }
                    else
                    {
                        ProgettoProvider.CambioStatoProgettoPregresso(prog, "L", null, Convert.ToDateTime(txtData.Text), op_rilascio, false, false, false);
                        ProgettoProvider.CambioStatoProgettoPregresso(prog, "I", null, Convert.ToDateTime(txtData.Text), op_rilascio, false, false, false);
                    }

                }

                // Controllo la riga su graduatoria progetto ALTRIMENTI LA CREO
                SiarLibrary.GraduatoriaProgetti graduatoria = null;
                SiarLibrary.GraduatoriaProgettiCollection grad_coll = graduatoria_provider.Find(Progetto.IdBando, Progetto.IdProgetto, null);
                if (grad_coll.Count > 0)
                    graduatoria = grad_coll[0];
                else
                    graduatoria = new SiarLibrary.GraduatoriaProgetti();
                graduatoria.IdBando = Bando.IdBando;
                graduatoria.IdProgetto = Progetto.IdProgetto;
                graduatoria.Punteggio = 0;
                graduatoria.DataValutazione = DateTime.Today;
                graduatoria.Operatore = Operatore.Utente.CfUtente;
                graduatoria_provider.Save(graduatoria);

                ProgettoProvider.DbProviderObj.Commit();
                //aggiorno la sessione
                Progetto = ProgettoProvider.GetById(Progetto.IdProgetto);
                btnInserisciSegnatura.Enabled = false;
                ucDatiDomanda.ForzaCaricamentoDati = true;
                ucDatiDomanda.loadData();
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura della domanda d'aiuto sono state salvate correttamente.");


            }
            catch (Exception ex)
            {
                messaggio = "Attenzione! " + ex.Message;
                btnInserisciSegnaturaPost_Click(sender, e);
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        protected void btnFirmaEsterna_Click(object sender, EventArgs e)
        {
            try
            {
                string verifica = ControlliPreFirma();
                if (!string.IsNullOrEmpty(verifica))
                    RegisterClientScriptBlock("presentazione_warnings('" + verifica + "');");
                else
                    RegisterClientScriptBlock(modaleFirmaEsterna.Mostra);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[(iter * 2) + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }

        protected void ScaricaDocumento()
        {
            var logInfo = new LogInfo();
            string esito = "OK";
            string dettaglioEsito = "File scaricato correttamente";
            ScaricamentoFirmaEsterna datiScaricamento = null;
            var scaricamentoFirmaEsternaProvider = new ScaricamentoFirmaEsternaCollectionProvider();

            try
            {
                //dati log 
                logInfo.Operatore = Operatore.Utente.CfUtente;
                logInfo.TipoFirma = "esterna";
                logInfo.TipoDocumento = modaleFirmaEsterna.TipoDocumento;
                logInfo.ParametriDocumento = "ID_Domanda_" + Progetto.IdProgetto;
                logInfo.DownloadDocumentoCertificato = true;

                if (Progetto.CodStato != "P")
                    throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                SiarLibrary.ModelloDomandaCollection cc = new ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null);
                if (cc.Count == 0)
                    throw new Exception("Nessun modello di documento digitale definito per il presente bando, impossibile continuare.");

                //nuovi dati per firma esterna 
                datiScaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(Progetto.IdProgetto, null, null);
                if (datiScaricamento == null)
                {
                    datiScaricamento = new ScaricamentoFirmaEsterna();
                    datiScaricamento.OperatoreInserimento = Operatore.Utente.CfUtente;
                    datiScaricamento.DataInserimento = DateTime.Now;
                    datiScaricamento.IdProgetto = Progetto.IdProgetto;
                }

                modaleFirmaEsterna.loadDocumento(Operatore.Utente.CfUtente, Progetto.IdProgetto, cc[0].IdDomanda);
                var firmaEsternaAruba = new FirmaEsternaAruba();
                var file = modaleFirmaEsterna.FileCertificatoServer;
                var file_restituito = firmaEsternaAruba.FirmaAutomaticaProd(file);

                // genero l'hash
                HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                byte[] fileHashValue = alg.ComputeHash(file_restituito);
                string hash_code = BinaryToHex(fileHashValue);
                datiScaricamento.HashCodeFileConSigillo = hash_code;
                datiScaricamento.OperatoreModifica = Operatore.Utente.CfUtente;
                datiScaricamento.DataModifica = DateTime.Now;

                Session["doc"] = file_restituito;
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

                ShowMessage("File scaricato correttamente. Firmare esclusivamente questo documento e caricarlo.");
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
                logInfo.DataFirma = DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                modaleFirmaEsterna.LogSign(logInfo);
                scaricamentoFirmaEsternaProvider.Save(datiScaricamento);
            }
        }

        protected void btnScaricaDocumento_Click(object sender, EventArgs e)
        {
            ScaricaDocumento();
            RegisterClientScriptBlock(modaleFirmaEsterna.Mostra);
        }

        protected void btnFirmaEsternaProtocolla_Click(object sender, EventArgs e)
        {
            var logInfo = new LogInfo();
            string esito = "OK";
            string dettaglioEsito = "firma effettuata con successo";

            try
            {
                //dati log 
                logInfo.Operatore = Operatore.Utente.CfUtente;
                logInfo.TipoFirma = "esterna";
                logInfo.TipoDocumento = modaleFirmaEsterna.TipoDocumento;
                logInfo.ParametriDocumento = "ID_Domanda_" + Progetto.IdProgetto;
                logInfo.DownloadDocumentoCertificato = false;

                if (modaleFirmaEsterna.FileCaricato.IdFile == null)
                    throw new Exception("Caricare prima il file");

                var logger = new Logger();
                var countOk = logger.CountLogDocumentoScaricatoOk(logInfo.TipoDocumento, logInfo.ParametriDocumento);

                if (countOk <= 0)
                    throw new Exception("Non è mai stato scaricato il documento con il certificato, impossibile accettare il file");

                var firmaEsternaAruba = new FirmaEsternaAruba();
                var file = new ArchivioFileCollectionProvider().GetById(modaleFirmaEsterna.FileCaricato.IdFile);
                string esitoVerifica;
                var estensione_file = Path.GetExtension(file.NomeFile);
                if (estensione_file == ".pdf")
                {
                    //nuovi controlli verifica file
                    var scaricamentoFirmaEsternaProvider = new ScaricamentoFirmaEsternaCollectionProvider();
                    var scaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(Progetto.IdProgetto, null, null);
                    if (scaricamento == null)
                        throw new Exception("Non è mai stato scaricato il documento con il certificato, impossibile accettare il file");

                    //verifico se l'hash del file caricato è uguale a quello scaricato
                    CryptoUtility crypto = new CryptoUtility();
                    HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                    var result = crypto.RemoveSignedDocument(file.Contenuto);
                    byte[] fileHashValue = alg.ComputeHash(result);
                    string hash_code = BinaryToHex(fileHashValue);

                    //Se voglio verificare il file con il sigillo
                    //Session["doc"] = result;
                    //RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

                    if (hash_code != scaricamento.HashCodeFileConSigillo)
                        throw new Exception("Il file caricato non è l'ultima versione del documento prodotto. Firmare l'ultimo documento scaricato e caricarlo.");

                    esitoVerifica = firmaEsternaAruba.VerificaFileFirmatoUtentePostFirmaAutomaticaProd(file.Contenuto, file.NomeFile);
                }
                else
                    throw new Exception("Estensione file " + estensione_file + " non accettata, si accettano solo file .pdf");

                if (esitoVerifica == "OK")
                    ProtocollaDomandaDiAiuto(file.Contenuto);
                else
                    throw new Exception(esitoVerifica);
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
                logInfo.DataFirma = DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                modaleFirmaEsterna.LogSign(logInfo);
                modaleFirmaEsterna.FileCaricato.IdFile = null;
                modaleFirmaEsterna.ChiudiModale();
            }
        }
    }
}