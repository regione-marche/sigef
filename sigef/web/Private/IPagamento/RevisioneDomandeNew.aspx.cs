using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarLibrary;
using System.Linq;
using SiarBLL;
using SiarLibrary.Web;

namespace web.Private.IPagamento
{
    public partial class RevisioneDomandeNew : SiarLibrary.Web.ControlliValidazionePagePage
    {
        TestataValidazioneCollectionProvider testata_validazione_provider;
        IstanzaChecklistGenericaCollectionProvider istanza_provider;
        TestataValidazioneXIstanzaCollectionProvider testata_x_istanza_provider;
        ArchivioFileCollectionProvider archivio_file_provider;
        BandoCollectionProvider bando_provider;
        BandoResponsabiliCollectionProvider bando_responsabili_provider;
        BandoValidatoriCollectionProvider bandoValidatoriCollectionProvider;

        TestataValidazione testata_selezionata;
        TestataValidazioneXIstanza testata_istanza_selezionata;
        IstanzaChecklistGenerica istanza_generica_selezionata;
        BandoResponsabili rup;

        #region Indici colonne Datagrid

        //Indici colonne testate validazione
        private int col_Testata_IdTestata = 0,
            col_Testata_IdProgetto = 1,
            col_Testata_IdDomandaPagamento = 2,
            col_Testata_TipoDomandaPagamento = 3,
            col_Testata_DataPresentazioneDomandaPagamento = 4,
            col_Testata_NominativoValidatore = 5,
            col_Testata_DataInserimento = 6,
            col_Testata_DataValidazione = 7,
            col_Testata_Approvata = 8,
            col_Testata_Protocollo = 9,
            col_Testata_SelezionaTestata = 10;

        //Indici colonne testate validazione x istanza
        private int col_Istanza_IdTestataValidazioneXIstanza = 0,
            col_Istanza_Descrizione = 1,
            col_Istanza_Note = 2,
            col_Istanza_Seleziona = 3,
            col_Elimina_Istanza = 4;

        #endregion

        bool domanda_aiuti = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            InizializzaProvider();
            lstEsitoValidazione.DataBind();
            ControllaAggiungiRevisione();
            ucFirmaRevisione.DocumentoFirmatoEvent = btnPostBackFirma_Click;

            int id_testata;
            if (int.TryParse(hdnIdTestata.Value, out id_testata))
                testata_selezionata = testata_validazione_provider.GetById(id_testata);
            else
                testata_selezionata = null;

            var testate_collection = new TestataValidazioneCollection();
            if (testata_selezionata != null)
            {
                // VERIFICO SE LA DOMANDA E' UN AIUTO
                var dati_monitoraggio = new DatiMonitoraggioFESRCollectionProvider().Find(null, testata_selezionata.IdProgetto)[0];
                if (dati_monitoraggio.IdCUPNatura == "06" || dati_monitoraggio.IdCUPNatura == "07")
                    domanda_aiuti = true;

                Session["idBandoValidazione"] = testata_selezionata.IdBando.Value;

                ControllaModifica();
                CaricaValidazioniPrecedenti();
                MostraCambioValidatore();
                //RevisionePrima();
                //RevisioneSeconda();
                testate_collection.Add(testata_selezionata);
                divSelezioneIstanza.Visible = true;

                int id_istanza;
                if (int.TryParse(hdnIdTestataXIstanza.Value, out id_istanza))
                    testata_istanza_selezionata = testata_x_istanza_provider.GetById(id_istanza);
                else
                    testata_istanza_selezionata = null;

                var istanze_testata_collection = testata_x_istanza_provider.Find(null, testata_selezionata.IdTestata, null, null, false);
                var istanze_testate_collection = new TestataValidazioneXIstanzaCollection();
                if (testata_istanza_selezionata != null)
                {
                    istanze_testate_collection.Add(testata_istanza_selezionata);
                    MostraChecklistIstanza();
                }
                else
                    istanze_testate_collection.AddCollection(istanze_testata_collection);

                dgIstanze.DataSource = istanze_testate_collection;
                dgIstanze.ItemDataBound += new DataGridItemEventHandler(dgIstanze_ItemDataBound);
                dgIstanze.DataBind();

                //se la domanda è aiuti non devo far cancellare la checklist o aggiungerne di nuove
                if (domanda_aiuti)
                {
                    btnAggiungiChecklist.Visible = false;
                    dgIstanze.Columns[col_Elimina_Istanza].Visible = false;

                    //se non è ancora stata firmata posso copiare gli esiti da altri aiuti
                    if (testata_selezionata.SegnaturaRevisione == null)
                    {
                        //se siamo gli amministratori o il rup del bando o il validatore 
                        if (Operatore.Utente.Profilo.Equals("Amministratore")
                            || (rup != null && Operatore.Utente.IdUtente == rup.IdUtente)
                            || Operatore.Utente.CfUtente == testata_selezionata.CfValidatore)
                        {
                            divCopiaEsitiAiuti.Visible = true;
                            btnCopiaEsiti.Enabled = true;
                        }
                    }
                }

                //se la domanda ha una vecchia checklist non gli permetto di aggiungere quelle nuove o di cancellarla in autonomia
                foreach (TestataValidazioneXIstanza tvi in istanze_testata_collection)
                {
                    if (tvi.DescrizioneChecklist.StartsWith("Revisione_Old"))
                    {
                        btnAggiungiChecklist.Visible = false;
                        dgIstanze.Columns[col_Elimina_Istanza].Visible = false;
                    }
                }

            }
            else
                testate_collection.AddCollection(testata_validazione_provider.FindRevisione(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, null, false));

            var testate_list = testate_collection.ToArrayList<TestataValidazione>().OrderByDescending(t => t.DataInserimento);

            dgTestateValidazioni.DataSource = testate_list;
            dgTestateValidazioni.ItemDataBound += new DataGridItemEventHandler(dgTestateValidazioni_ItemDataBound);
            dgTestateValidazioni.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (testata_selezionata != null)
                ControllaTestata();

            if (testata_istanza_selezionata != null && testata_istanza_selezionata.Note != null)
                txtNoteChecklist.Text = testata_istanza_selezionata.Note;

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            testata_validazione_provider = new TestataValidazioneCollectionProvider();
            istanza_provider = new IstanzaChecklistGenericaCollectionProvider();
            testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider();
            archivio_file_provider = new ArchivioFileCollectionProvider();
            bando_provider = new BandoCollectionProvider();
            bando_responsabili_provider = new BandoResponsabiliCollectionProvider();
            bandoValidatoriCollectionProvider = new BandoValidatoriCollectionProvider();
        }

        private void ControllaTestata()
        {
            //if (testata_selezionata.Approvata != null)
            //    btnFirmaRevisione.Enabled = true;
            //else
            //    btnFirmaRevisione.Enabled = false;

            var file_autovalutazione_coll = archivio_file_provider.Find(null, "Autovalutazione" + testata_selezionata.IdDomandaPagamento + ".pdf", null);
            if (file_autovalutazione_coll.Count > 0)
                btnVisualizzaAutovalutazione.Attributes.Add("onclick", "SNCUFVisualizzaFile(" + file_autovalutazione_coll[0].Id + ");");
            else
                btnVisualizzaAutovalutazione.Visible = false;

            if (testata_selezionata.DataValidazione != null)
                txtDataValidazione.Text = testata_selezionata.DataValidazione;
            else if (AbilitaModifica)
                txtDataValidazione.Text = DateTime.Now.ToShortDateString();
            else
                txtDataValidazione.Text = null;

            if (testata_selezionata.Approvata != null && testata_selezionata.Approvata)
                lstEsitoValidazione.SelectedValue = "SI";
            else if (testata_selezionata.Approvata != null && !testata_selezionata.Approvata)
                lstEsitoValidazione.SelectedValue = "NO";
            else
                lstEsitoValidazione.SelectedValue = null;
        }

        private void ControllaAggiungiRevisione()
        {
            var vv = bandoValidatoriCollectionProvider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true);

            if (vv.Count > 0)
                btnAggiungiRevisione.Enabled = true;
            else
                btnAggiungiRevisione.Enabled = false;
        }

        private void ControllaModifica()
        {
            var vv = bandoValidatoriCollectionProvider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true);
            var ultima_testata_valida = testata_validazione_provider.GetTestataValidazioneDaCte(testata_selezionata.IdDomandaPagamento);

            if (ultima_testata_valida == null)
                throw new Exception("Non è stata trovata la validazione valida per la domanda di pagamento " + testata_selezionata.IdDomandaPagamento);

            AbilitaModifica = vv.Count > 0 //se l'utente è un validatore
                && (testata_selezionata.SegnaturaRevisione == null
                    || (DomandaPagamento.SegnaturaSecondaApprovazione != null && testata_selezionata.SegnaturaSecondaRevisione == null)) //non è stata ancora firmata
                && testata_selezionata.IdTestata == ultima_testata_valida.IdTestata //verifico anche se la testata è l'ultima valida
                && testata_selezionata.CfValidatore == Operatore.Utente.CfUtente;  //e l'utente è il validatore

            if (AbilitaModifica)
            {
                txtDataValidazione.ReadOnly = false;
                lstEsitoValidazione.Enabled = true;
            }
            else
            {
                txtDataValidazione.ReadOnly = true;
                lstEsitoValidazione.Enabled = false;
                btnAggiungiChecklist.Enabled = false;
            }
        }

        private void MostraChecklistIstanza()
        {
            divDettaglioValidazione.Visible = true;

            /*
            var istanze_checklist_coll = testata_x_istanza_provider.Find(null, testata_selezionata.IdTestata, null, null, false);
            if (istanze_checklist_coll.Count > 0) //if(testata_selezionata.IdIstanzaChecklistGenerica == null)
            {
                var dati_monitoraggio = new DatiMonitoraggioFESRCollectionProvider().Find(null, Progetto.IdProgetto)[0];

                if (dati_monitoraggio.IdCUPNatura == "06" || dati_monitoraggio.IdCUPNatura == "07") // Aiuti
                {
                    string errore = testata_validazione_provider.GeneraChecklistValidazioneAiuti(null, ref testata_selezionata, Operatore.Utente.CfUtente);
                    if (errore == null || errore != "")
                        throw new Exception(errore);
                }
                else  // deve scegliere la checklist
                {
                    throw new Exception("Appalti pubblici");
                }
            }
            */
            
            istanza_generica_selezionata = istanza_provider.GetById(testata_istanza_selezionata.IdIstanzaChecklistGenerica); 

            ucChecklistGenerica.IdDomandaPagamento = testata_selezionata.IdDomandaPagamento;
            ucChecklistGenerica.Progetto = new ProgettoCollectionProvider().GetById(testata_selezionata.IdProgetto);
            ucChecklistGenerica.IdTestataChecklist = testata_selezionata.IdTestata;
            ucChecklistGenerica.ButtonSalvaSchedaVisibile = true;
            ucChecklistGenerica.IstanzaCheckListGenerica = istanza_generica_selezionata;
            ucChecklistGenerica.IstanzaCheckListPadre = istanza_generica_selezionata;
            ucChecklistGenerica.Fase = istanza_generica_selezionata.CodFase;
            ucChecklistGenerica.MostraOperazioniMassive = true;
        }

        protected void CaricaValidazioniPrecedenti()
        {
            if (testata_selezionata != null && testata_selezionata.IdTestata != null)
            {
                var testate_precedenti_list = testata_validazione_provider
                    .GetRevisioniProgettoValide(testata_selezionata.IdProgetto)
                    .ToArrayList<TestataValidazione>();

                if (testate_precedenti_list.Count > 0 && AbilitaModifica)
                {
                    testate_precedenti_list = testate_precedenti_list
                        .Where(t => t.IdDomandaPagamento < testata_selezionata.IdDomandaPagamento)
                        .ToList<TestataValidazione>();

                    if (testate_precedenti_list.Count > 0)
                    {
                        // se la la revisione precedente è fatta con le vecchie checklist non devo mostrarla
                        for (int i = testate_precedenti_list.Count - 1; i >= 0; i-- )
                        {
                            var tes = testate_precedenti_list[i];
                            var istanze_coll = testata_x_istanza_provider.Find(null, tes.IdTestata, null, null, false);

                            foreach (TestataValidazioneXIstanza ist in istanze_coll)
                            {
                                if (ist.DescrizioneChecklist.StartsWith("Revisione_Old"))
                                    testate_precedenti_list.RemoveAt(i);
                            }
                        }

                        if (testate_precedenti_list.Count == 0)
                            divValidazioniPrecedenti.Visible = false;
                        else
                        {
                            dgValidazioniPrecedenti.DataSource = testate_precedenti_list;
                            dgValidazioniPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgValidazioniPrecedenti_ItemDataBound);
                            dgValidazioniPrecedenti.DataBind();
                        }                        
                    }
                    else
                        divValidazioniPrecedenti.Visible = false;
                }
                else
                    divValidazioniPrecedenti.Visible = false;
            }
            else
                ShowError("Testata non trovata!");
        }

        private void VerificaLotto()
        {
            var lotto_provider = new LottoDiRevisioneCollectionProvider();
            var lotto = lotto_provider.GetById(testata_selezionata.IdLotto);

            if (lotto == null)
                throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");

            if (!AbilitaModifica || lotto.RevisioneConclusa)
                throw new Exception("Il lotto di controllo selezionato non è valido.");

            int esito = lotto_provider.VerificaCompletamentoRevisione(lotto.IdLotto);

            bool chiudi_lotto = false;

            if (esito == 0)
                chiudi_lotto = true;

            lotto.RevisioneConclusa = chiudi_lotto;
            lotto.DataModifica = DateTime.Now;
            lotto.CfOperatore = Operatore.Utente.CfUtente;
            lotto_provider.Save(lotto);
        }

        protected void AggiornaCampiTestata()
        {
            if (testata_selezionata == null)
                throw new Exception("Testata non selezionata");

            if (testata_selezionata.IdTestata == null)
                throw new Exception("Testata non salvata");

            if (lstEsitoValidazione.SelectedValue != null && lstEsitoValidazione.SelectedValue == "SI")
                testata_selezionata.Approvata = true;
            else if (lstEsitoValidazione.SelectedValue != null && lstEsitoValidazione.SelectedValue == "NO")
                testata_selezionata.Approvata = false;
            else
                testata_selezionata.Approvata = null;

            testata_selezionata.DataValidazione = txtDataValidazione.Text;

            testata_selezionata.DataModifica = DateTime.Now;
            testata_selezionata.CfModifica = Operatore.Utente.CfUtente;
        }

        protected void MostraCambioValidatore()
        {
            var ultima_testata_valida = testata_validazione_provider.GetTestataValidazioneDaCte(testata_selezionata.IdDomandaPagamento);

            if (ultima_testata_valida == null)
                throw new Exception("Non è stata trovata la validazione valida per la domanda di pagamento " + testata_selezionata.IdDomandaPagamento);

            if (testata_selezionata.SegnaturaRevisione == null //se non è stata firmata
                && testata_selezionata.IdTestata == ultima_testata_valida.IdTestata) //e sto lavorando l'ultima testata valida
            {
                var bando = bando_provider.GetById(testata_selezionata.IdBando);
                BandoResponsabiliCollection responsabili = bando_responsabili_provider.Find(Bando.IdBando, null, null, true, true);

                if (responsabili.Count == 1)
                {
                    rup = responsabili[0];

                    if (Operatore.Utente.Profilo.Equals("Amministratore") //se siamo gli amministratori o il rup del bando 
                        || Operatore.Utente.IdUtente == rup.IdUtente)
                    {
                        divCambioValidatore.Visible = true;
                        txtOperatoreValidatore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaValidatori');");
                    }
                }
                else
                {
                    throw new Exception("Non ho trovato il responsabile del bando con id " + bando.IdBando);
                }
            }
        }

        #region Eventi Button

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                testata_validazione_provider = new TestataValidazioneCollectionProvider();
                string esito = ucChecklistGenerica.VerificaChecklistDiSchede();

                AggiornaCampiTestata();
                testata_validazione_provider.Save(testata_selezionata);

                string esito_validazione = null;
                if (lstEsitoValidazione.SelectedValue != null)
                {
                    esito_validazione = lstEsitoValidazione.SelectedValue;
                    btnFirmaRevisione.Enabled = true;
                }

                if (esito_validazione != null && esito_validazione == "SI")
                    ShowMessage("Revisione salvata correttamente con esito positivo");
                else if (esito_validazione != null && esito_validazione == "NO")
                    ShowMessage("Revisione salvata correttamente con esito negativo");
                else
                    ShowMessage("Revisione salvata correttamente");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnCopia_Click(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnAggiungiRevisione_Click(object sender, EventArgs e)
        {
            try
            {
                testata_validazione_provider = new TestataValidazioneCollectionProvider();
                testata_validazione_provider.DbProviderObj.BeginTran();

                var testate_precedenti_coll = testata_validazione_provider.GetUltimaRevisioneDomandaValida(DomandaPagamento.IdDomandaPagamento);
                if (testate_precedenti_coll.Count > 0)
                {
                    var testata_precedente = testate_precedenti_coll[0];

                    var t = new TestataValidazione();
                    t.IdLotto = testata_precedente.IdLotto;
                    t.IdProgetto = testata_precedente.IdProgetto;
                    t.IdDomandaPagamento = testata_precedente.IdDomandaPagamento;
                    t.DataInserimento = DateTime.Now;
                    t.CfInserimento = Operatore.Utente.CfUtente;
                    t.DataModifica = DateTime.Now;
                    t.CfModifica = Operatore.Utente.CfUtente;
                    t.CfValidatore = testata_precedente.CfValidatore;
                    t.SelezionataXRevisione = true;
                    t.NumeroEstrazione = 1;
                    t.Ordine = testata_precedente.Ordine + 1;
                    t.SegnaturaRevisione = null;
                    t.SegnaturaSecondaRevisione = null;
                    testata_validazione_provider.Save(t);

                    var errore = testata_validazione_provider.GeneraTestataDaPrecedente(testata_validazione_provider.DbProviderObj, testata_precedente, ref t, Operatore.Utente.CfUtente, false, false);

                    //NON SI USA PIU' QUESTO METODO PERCHE' VORRANNO RIVERIFICARE LE VECCHIE CONDIZIONI
                    //string errore = null;
                    //var dati_monitoraggio = new DatiMonitoraggioFESRCollectionProvider().Find(null, testata_precedente.IdProgetto)[0];

                    //// Se è Aiuti genero la checklist, altrimenti devo generare la checklist a partire dall'autovalutazione
                    //if (dati_monitoraggio.IdCUPNatura == "06" || dati_monitoraggio.IdCUPNatura == "07")
                    //    errore = testata_validazione_provider.GeneraChecklistValidazioneAiuti(testata_validazione_provider.DbProviderObj, ref t, Operatore.Utente.CfUtente);
                    //else
                    //    errore = testata_validazione_provider.GeneraChecklistDaAutovalutazione(testata_validazione_provider.DbProviderObj, ref t, Operatore.Utente.CfUtente, testata_precedente.IdLotto, testata_precedente.Ordine + 1, testata_precedente.CfValidatore);

                    if (errore == null || errore != "")
                        throw new Exception(errore);

                    testata_validazione_provider.DbProviderObj.Commit();
                    
                    Redirect(PATH_IPAGAMENTO + "RevisioneDomandeNew.aspx?idpag" + DomandaPagamento.IdDomandaPagamento, "Nuova revisione creata correttamente", false);
                }
                else
                    throw new Exception("Non ho trovato altre revisioni valide.");
            }
            catch (Exception ex)
            {
                testata_validazione_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnFirmaRevisione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                if (txtDataValidazione.Text == null)
                    throw new Exception("Compilare la Data Validazione");

                if (lstEsitoValidazione.SelectedValue == null || lstEsitoValidazione.SelectedValue == "")
                    throw new SiarException("Compilare l'esito validazione");

                //GetEsitoCheckList(true);
                System.Collections.ArrayList parametri = new System.Collections.ArrayList();
                parametri.Add(DomandaPagamento.IdDomandaPagamento.ToString());
                parametri.Add(testata_selezionata.IdTestata.ToString());
                ucFirmaRevisione.loadDocumento(Operatore.Utente.CfUtente, (string[])parametri.ToArray(typeof(string)));
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        // Evento collegato a ucFirmaRevisione
        protected void btnPostBackFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                if (string.IsNullOrEmpty(ucFirmaRevisione.FileFirmato))
                    throw new SiarException(TextErrorCodes.GenericoConLink);

                if (txtDataValidazione.Text == null)
                    throw new SiarException("Compilare la data validazione");

                if (lstEsitoValidazione.SelectedValue == null || lstEsitoValidazione.SelectedValue == "")
                    throw new SiarException("Compilare l'esito validazione");

                testata_validazione_provider = new TestataValidazioneCollectionProvider();
                testata_validazione_provider.DbProviderObj.BeginTran();

                string esito = ucChecklistGenerica.VerificaChecklistDiSchede();
                bool approvata = false;
                if (lstEsitoValidazione.SelectedValue != null && lstEsitoValidazione.SelectedValue == "SI")
                    approvata = true;
                else if (lstEsitoValidazione.SelectedValue != null && lstEsitoValidazione.SelectedValue == "NO")
                    approvata = false;

                var lotto = new LottoDiRevisioneCollectionProvider().GetById(testata_selezionata.IdLotto);
                string identificativo_paleo, messaggio = "";
                Protocollo revisione = new Protocollo(Bando.CodEnte);
                string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, lotto.Provincia);
                if (testata_selezionata.SegnaturaRevisione == null)
                {
                    revisione.setDocumento("checklist_validazione_" +
                                             DomandaPagamento.Descrizione.Value.ToUpper() +
                                             "_domanda_nr_" +
                                             DomandaPagamento.IdProgetto +
                                             ".pdf",
                                           Convert.FromBase64String(ucFirmaRevisione.FileFirmato));

                    string oggetto = "Checklist di validazione istruttoria della domanda di pagamento modalità " +
                                        DomandaPagamento.Descrizione.Value.ToUpper() +
                                        " della domanda di aiuto nr. " +
                                        Progetto.IdProgetto +
                                        " in risposta al bando: " +
                                        ss[0] +
                                        " del " +
                                        ss[1] +
                                        " con scadenza: " +
                                        Bando.DataScadenza +
                                        "\n" +
                                        ss[3] + "\n CF: " +
                                        ucIDomandaPagamento.Impresa.CodiceFiscale
                                        + "\n Ragione sociale: " + ucIDomandaPagamento.Impresa.RagioneSociale; 

                    identificativo_paleo = revisione.DocumentoInterno(oggetto, ss[4]);
                    testata_selezionata.SegnaturaRevisione = identificativo_paleo;

                    messaggio = "Checklist di validazione prima revisione firmata e protocollata correttamente. " +
                                    (approvata ? "La checklist è stata salvata con esito positivo. " 
                                               : "La checklist è stata salvata con esito negativo. ");
                }
                else if (testata_selezionata.SegnaturaSecondaRevisione == null)
                {
                    revisione.setDocumento("checklist_conferma_validazione_" +
                                             DomandaPagamento.Descrizione.Value.ToUpper() +
                                             "_domanda_nr_" +
                                             DomandaPagamento.IdProgetto +
                                             ".pdf",
                                           Convert.FromBase64String(ucFirmaRevisione.FileFirmato));

                    string oggetto = "Checklist di conferma della validazione istruttoria della domanda di pagamento modalità " +
                                       DomandaPagamento.Descrizione.Value.ToUpper() +
                                       " della domanda di aiuto nr. " +
                                       Progetto.IdProgetto +
                                       " in risposta al bando: " +
                                       ss[0] +
                                       " del " +
                                       ss[1] +
                                       " con scadenza: " +
                                       Bando.DataScadenza +
                                       "\n" +
                                       ss[3] +
                                       "\n CF: " +
                                       ucIDomandaPagamento.Impresa.CodiceFiscale
                                       + "\n Ragione sociale: " + ucIDomandaPagamento.Impresa.RagioneSociale; 

                    identificativo_paleo = revisione.DocumentoInterno(oggetto, ss[4]);
                    testata_selezionata.SegnaturaSecondaRevisione = identificativo_paleo;

                    messaggio = "Checklist di validazione seconda revisione firmata e protocollata correttamente. " +
                                    (approvata ? "La checklist è stata salvata con esito positivo. "
                                               : "La checklist è stata salvata con esito negativo. ");
                }

                AggiornaCampiTestata();
                testata_validazione_provider.Save(testata_selezionata);
                testata_validazione_provider.DbProviderObj.Commit();

                //VerificaLotto();
                Redirect("RevisioneDomandeNew.aspx", messaggio, false);
            }
            catch (Exception ex)
            {
                testata_validazione_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaChecklist_Click(object sender, EventArgs e) 
        { 
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                testata_x_istanza_provider.DbProviderObj.BeginTran();

                if (testata_istanza_selezionata != null)
                {
                    testata_istanza_selezionata.Note = txtNoteChecklist.Text;
                    testata_istanza_selezionata.DataModifica = DateTime.Now;
                    testata_istanza_selezionata.CfModifica = Operatore.Utente.CfUtente;

                    testata_x_istanza_provider.Save(testata_istanza_selezionata);
                    testata_x_istanza_provider.DbProviderObj.Commit();
                    ShowMessage("Checklist salvata correttamente");
                }
                else
                    throw new Exception("Checklist non selezionata");
            }
            catch (Exception ex)
            {
                testata_x_istanza_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnAggiungiChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                modaleSceltaChecklist.TestataAutovalutazioneValidazione = testata_selezionata;
                modaleSceltaChecklist.CreaAutovalutazione = false;
                modaleSceltaChecklist.DomandaPagamento = DomandaPagamento;
                RegisterClientScriptBlock(modaleSceltaChecklist.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex.Message);
            }
        }

        protected void btnPostEliminaIstanza_Click(object sender, EventArgs e)
        {
            try
            {
                TestataValidazioneXIstanza istanza_eliminazione = null;

                int id_istanza;
                if (int.TryParse(hdnIdIstanzaEliminazione.Value, out id_istanza))
                    istanza_eliminazione = testata_x_istanza_provider.GetById(id_istanza);
                else
                    throw new Exception("Nessuna checklist selezionata");

                if (istanza_eliminazione == null)
                    throw new Exception("Nessuna checklist selezionata");

                string esito = new TestataValidazioneXIstanzaCollectionProvider().EliminaIstanzaACascata(null, ref istanza_eliminazione, null);
                if (esito == null || esito != "")
                    throw new Exception(esito);

                hdnIdIstanzaEliminazione.Value = null;
                hdnIdTestataXIstanza.Value = null;
                Redirect("RevisioneDomandeNew.aspx", "Checklist eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnPostCopiaValidazione_Click(object sender, EventArgs e)
        {
            try
            {
                TestataValidazione testata_precedente = null;
                var testata_provider = new TestataValidazioneCollectionProvider();

                int id_validazione;
                if (int.TryParse(hdnIdValidazioneCopia.Value, out id_validazione))
                    testata_precedente = testata_provider.GetById(id_validazione);
                else
                    throw new Exception("Nessuna validazione selezionata");

                if (testata_precedente == null)
                    throw new Exception("Nessuna validazione selezionata");

                string esito = testata_provider.GeneraTestataDaPrecedente(null, testata_precedente, ref testata_selezionata, Operatore.Utente.CfUtente, true, false);
                if (esito == null || esito != "")
                    throw new Exception(esito);

                hdnIdIstanzaEliminazione.Value = null;
                hdnIdTestataXIstanza.Value = null;
                hdnIdValidazioneCopia = null;
                Redirect("RevisioneDomandeNew.aspx", "Validazione copiata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnCopiaEsiti_Click(object sender, EventArgs e)
        {
            try
            {
                int idDomandaDaCopiare;
                if (!int.TryParse(txtIdDomandaPagamentoDaCopiare.Text, out idDomandaDaCopiare))
                    throw new Exception("Id domanda di pagamento da copiare non valido: inserire solo numeri");

                var errore = testata_validazione_provider.CopiaValidazioneAiuti(null, idDomandaDaCopiare, ref testata_selezionata, Operatore.Utente.CfUtente);

                if (errore == null || errore != "")
                    throw new Exception(errore);

                Redirect("RevisioneDomandeNew.aspx", "Esiti e note copiate correttamente", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                testata_validazione_provider.DbProviderObj.BeginTran();

                if (hdnIdUtenteValidatore.Value == null)
                    throw new Exception("Nuovo validatore non selezionato");
                Utenti nuovoValidatore = new UtentiCollectionProvider().GetById(hdnIdUtenteValidatore.Value);

                if (testata_selezionata != null && nuovoValidatore != null)
                {
                    testata_selezionata.DataModifica = DateTime.Now;
                    testata_selezionata.CfModifica = Operatore.Utente.CfUtente;
                    testata_selezionata.CfValidatore = nuovoValidatore.CfUtente;

                    testata_validazione_provider.Save(testata_selezionata);
                    testata_validazione_provider.DbProviderObj.Commit();
                    Redirect(PATH_IPAGAMENTO + "RevisioneDomandeNew.aspx?idpag" + DomandaPagamento.IdDomandaPagamento, "Validatore assegnato correttamente", false);
                }
                else
                    throw new Exception("Validazione non selezionata o validatore non trovato");
            }
            catch (Exception ex)
            {
                testata_validazione_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        #endregion

        #region ItemDataBound

        void dgTestateValidazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var rev = (TestataValidazione)e.Item.DataItem;

                if (rev.SegnaturaRevisione != null)
                    dgi.Cells[col_Testata_Protocollo].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + rev.SegnaturaRevisione + "');\" style='cursor: pointer;'>";
                else
                    dgi.Cells[col_Testata_Protocollo].Text = "";

                if (testata_selezionata != null)
                    dgi.Cells[col_Testata_SelezionaTestata].Text = dgi.Cells[col_Testata_SelezionaTestata].Text.Replace("Seleziona validazione", "Torna elenco");
            }
        }

        void dgIstanze_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var tv = (TestataValidazioneXIstanza)e.Item.DataItem;

                if (testata_istanza_selezionata != null && testata_istanza_selezionata.IdTestataValidazioneXIstanza == tv.IdTestataValidazioneXIstanza)
                    dgi.Cells[col_Istanza_Seleziona].Text = dgi.Cells[col_Istanza_Seleziona].Text.Replace("Seleziona checklist", "Torna elenco");

                if (!AbilitaModifica)
                    dgi.Cells[col_Elimina_Istanza].Text = "";
            }
        }

        void dgValidazioniPrecedenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var tv = (TestataValidazione)e.Item.DataItem;
            }
        }

        #endregion

        #region Revisioni

        private bool Controlla_RevisioneDomandaPagamento()
        {
            bool DomandaOk = true;
            if (testata_selezionata == null || testata_selezionata.IdLotto == null)
            {
                Redirect("validazionelotti.aspx", "La domanda di pagamento selezionata non è ancora stata inclusa in un lotto di validazione.", true);
                DomandaOk = false;
            }
            else if (!testata_selezionata.SelezionataXRevisione)
            {
                Redirect("validazionelotti.aspx", "La domanda di pagamento non è stata estratta a controllo.", true);
                DomandaOk = false;
            }
            return DomandaOk;
        }

        //private void RevisionePrima()
        //{
        //    if (testata_selezionata.SegnaturaRevisione != null)
        //    {
        //        txtEsitoPrimaRevisione.Text = (testata_selezionata.Approvata ? "Positivo" : "Negativo");
        //        imgSegnatura.Disabled = false;
        //        imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + testata_selezionata.SegnaturaRevisione + "');");
        //        imgSegnatura.Style.Add("cursor", "pointer");

        //        if (testata_selezionata.Approvata)
        //            divValidazioneInviate.Visible = false;
        //    }
        //}

        //private void RevisioneSeconda()
        //{
        //    if (testata_selezionata.SegnaturaSecondaRevisione != null)
        //    {
        //        txtEsitoPrimaRevisione.Text = "Negativo";
        //        txtEsitoSecondaRevisione.Text = (testata_selezionata.Approvata ? "Positivo" : "Negativo");
        //        imgSecondaSegnatura.Disabled = false;
        //        imgSecondaSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + testata_selezionata.SegnaturaSecondaRevisione + "');");
        //        imgSecondaSegnatura.Style.Add("cursor", "pointer");

        //        if (testata_selezionata.Approvata)
        //            divValidazioneInviate.Visible = false;
        //    }
        //}

        #endregion

    }
}