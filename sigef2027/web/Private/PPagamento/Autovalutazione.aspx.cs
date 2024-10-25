using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;

namespace web.Private.PPagamento
{
    public partial class Autovalutazione : DomandaPagamentoPage
    {
        TestataValidazioneCollectionProvider testata_provider;
        TestataValidazioneXIstanzaCollectionProvider testata_x_istanza_provider;
        IstanzaChecklistGenericaCollectionProvider istanza_provider;
        ArchivioFileCollectionProvider archivio_file_provider;

        TestataValidazione _testata;
        TestataValidazioneXIstanza _autovalutazione_selezionata;

        #region Indici colonne 

        //dgAutovalutazione
        private int col_IdTestataValidazioneXIstanza = 0,
            col_Descrizione = 1,
            col_Note = 2,
            col_Seleziona = 3,
            col_Elimina = 4;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InizializzaProvider();
            CaricaTestata();
            CaricaAutovalutazioniPrecedenti();
            CaricaAutovalutazioni();
        }

        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            bool primo=false,problemi = false;
            List<string> id_errori = new List<string>();

            //Verifico che il beneficiario abbia compilato almeno un autovalutazione con tutti gli esiti
            if (_testata == null || _testata.IdTestata == null)
            {
                problemi = true;
                primo = true;
            }
            else
            {
                var istanze_testate_collection = testata_x_istanza_provider.Find(null, _testata.IdTestata, null, null, true);

                if (istanze_testate_collection.Count == 0)
                    problemi = true;
                else
                {
                    var checklist_provider = new ChecklistGenericaCollectionProvider();
                    var schede_x_checklist_provider = new SchedaXChecklistCollectionProvider();
                    var voci_x_checklist_provider = new VoceXChecklistGenericaCollectionProvider();
                    var esiti_provider = new EsitoIstanzaChecklistGenericoCollectionProvider();

                    foreach (TestataValidazioneXIstanza istanza_testata in istanze_testate_collection)
                    {
                        var istanza_checklist_padre = istanza_provider.GetById(istanza_testata.IdIstanzaChecklistGenerica);
                        var checklist_padre = checklist_provider.GetById(istanza_testata.IdChecklistGenerica);

                        if (istanza_checklist_padre == null || checklist_padre == null)
                        {
                            problemi = true;
                            break;
                        }

                        var schede_x_checklist_collection = schede_x_checklist_provider.Find(null, checklist_padre.IdChecklistGenerica, null);
                        if (schede_x_checklist_collection.Count == 0)
                        {
                            problemi = true;
                            break;
                        }

                        foreach (SchedaXChecklist scheda_x_checklist in schede_x_checklist_collection)
                        {
                            var checklist_figlio = checklist_provider.GetById(scheda_x_checklist.IdChecklistFiglio);
                            var istanza_checklist_figlio = istanza_provider.Find(null, checklist_figlio.IdChecklistGenerica, null, checklist_padre.IdChecklistGenerica, scheda_x_checklist.IdSchedaXChecklist)[0];

                            var voci_x_check_figlio_collection = voci_x_checklist_provider.GetStepByChecklist(checklist_figlio.IdChecklistGenerica, null);
                            var voci_x_check_figlio_list = voci_x_check_figlio_collection.ToArrayList<VoceXChecklistGenerica>();
                            voci_x_check_figlio_list = voci_x_check_figlio_list.Where(p => p.TitoloVoce == false).ToList<VoceXChecklistGenerica>();
                            var esiti_collection = esiti_provider.FindEsitiSenzaTitoli(istanza_checklist_figlio.IdIstanzaGenerica, null, null, null, null);

                            //Se non ho esiti o se il numero di voci della checklist è diverso dal numero di esiti sicuramente non hanno compilato qualcosa
                            if (esiti_collection.Count == 0
                                || voci_x_check_figlio_list.Count != esiti_collection.Count)
                            {
                                id_errori.Add(istanza_testata.IdTestataValidazioneXIstanza.ToString());
                                problemi = true;
                                break;
                            }

                            //Verifico inoltre che tutti gli esiti siano valorizzati correttamente e non lasciati vuoti
                            foreach (EsitoIstanzaChecklistGenerico esito in esiti_collection)
                            {
                                if (esito.CodEsito == null || esito.CodEsito == "")
                                {
                                    problemi = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // se la domanda non è già stata presentata e non è stata annullata 
            // ma l'autovalutazione non è stata completata
            // allora non permetto l'avanzamento all'utente
            if (problemi
                && DomandaPagamento.Segnatura == null 
                && !DomandaPagamento.Annullata)
            {
                if (primo)
                    ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! Per proseguire occorre inserire almeno un autovalutazione";
                else
                    ucWorkflowPagamento.ProseguiMessaggio = $"Attenzione! Le valutazioni con ID: {String.Join(" ",id_errori.ToArray())} non sono compilate o completate correttamente. Per proseguire è necessario ultimarne la compilazione";
                ucWorkflowPagamento.ProseguiAbilitato = false;
            }

            base.OnPreRenderComplete(e);
        }

        protected void InizializzaProvider()
        {
            testata_provider = new TestataValidazioneCollectionProvider();
            testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider();
            istanza_provider = new IstanzaChecklistGenericaCollectionProvider();
            archivio_file_provider = new ArchivioFileCollectionProvider();
        }

        protected void CaricaTestata()
        {
            var testate_coll = testata_provider.FindAutovalutazione(null, null, DomandaPagamento.IdDomandaPagamento, true);
            if (testate_coll.Count > 0)
            {
                _testata = testate_coll[0];
            }
            else
            {
                if (DomandaPagamento.Segnatura == null
                    && !DomandaPagamento.Annullata) // se la domanda non è già stata presentata e non è annullata creo la struttura base 
                    _testata = testata_provider.GeneraTestataAutovalutazione(DomandaPagamento.IdDomandaPagamento, Operatore.Utente.CfUtente);
                else //altrimenti non ha senso crearla
                    _testata = null;
            }
                
            if (_testata != null)
            {
                var file_autovalutazione_coll = archivio_file_provider.Find(null, "Autovalutazione" + _testata.IdDomandaPagamento + ".pdf", null);
                if (file_autovalutazione_coll.Count > 0)
                    btnVisualizzaAutovalutazione.Attributes.Add("onclick", "SNCUFVisualizzaFile(" + file_autovalutazione_coll[0].Id + ");");
                else
                    btnVisualizzaAutovalutazione.Visible = false;
            } 
            else
                btnVisualizzaAutovalutazione.Visible = false;
        }

        protected void CaricaAutovalutazioniPrecedenti()
        {
            if (_testata != null && _testata.IdTestata != null)
            {
                var testate_precedenti_list = testata_provider
                    .FindAutovalutazione(null, Progetto.IdProgetto, null, true)
                    .ToArrayList<TestataValidazione>();

                if (testate_precedenti_list.Count > 0 && AbilitaModifica)
                {
                    //carico le autovalutazioni precedenti solo se le domande sono state già istruite
                    testate_precedenti_list = testate_precedenti_list 
                        .Where(t => t.IdDomandaPagamento < _testata.IdDomandaPagamento)
                        .Where(t => t.SegnaturaApprovazioneDomanda != null)
                        .Where(t => t.DomandaApprovata)
                        .ToList<TestataValidazione>();

                    if (testate_precedenti_list.Count > 0)
                    {
                        dgAutovalutazioniPrecedenti.DataSource = testate_precedenti_list;
                        dgAutovalutazioniPrecedenti.ItemDataBound += new DataGridItemEventHandler(dgAutovalutazioniPrecedenti_ItemDataBound);
                        dgAutovalutazioniPrecedenti.DataBind();
                    }
                    else
                        divAutovalutazioniPrecedenti.Visible = false;
                }
                else
                    divAutovalutazioniPrecedenti.Visible = false;
            }
            else
            {
                if (DomandaPagamento.Segnatura == null
                    && !DomandaPagamento.Annullata)
                    ShowError("Testata non trovata!");
            }
                
        }

        protected void CaricaAutovalutazioni()
        {
            if (_testata != null && _testata.IdTestata != null)
            {
                TestataValidazioneXIstanzaCollection autovalutazioni_coll = new TestataValidazioneXIstanzaCollection();

                int id_autovalutazione;
                if (int.TryParse(hdnIdAutovalutazione.Value, out id_autovalutazione))
                {
                    _autovalutazione_selezionata = testata_x_istanza_provider.GetById(id_autovalutazione);
                    autovalutazioni_coll.Add(_autovalutazione_selezionata);
                    MostraDettaglioAutovalutazione();
                }
                else
                {
                    _autovalutazione_selezionata = null;
                    autovalutazioni_coll = testata_x_istanza_provider.Find(null, _testata.IdTestata, null, null, true);
                    NascondiDettaglioAutovalutazione();
                }

                dgAutovalutazioni.DataSource = autovalutazioni_coll;
                dgAutovalutazioni.ItemDataBound += new DataGridItemEventHandler(dgAutovalutazioni_ItemDataBound);
                dgAutovalutazioni.DataBind();
            }
            else
            {
                if (DomandaPagamento.Segnatura == null
                    && !DomandaPagamento.Annullata)
                    ShowError("Testata non trovata!");
            }
        }

        protected void MostraDettaglioAutovalutazione()
        {
            divDettaglioAutovalutazione.Visible = true;

            var istanza_generica_selezionata = istanza_provider.GetById(_autovalutazione_selezionata.IdIstanzaChecklistGenerica);

            ucChecklistGenerica.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
            ucChecklistGenerica.Progetto = new ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto);
            ucChecklistGenerica.IdTestataChecklist = _autovalutazione_selezionata.IdTestataValidazione;
            ucChecklistGenerica.ButtonSalvaSchedaVisibile = true;
            ucChecklistGenerica.IstanzaCheckListGenerica = istanza_generica_selezionata;
            ucChecklistGenerica.IstanzaCheckListPadre = istanza_generica_selezionata;
            ucChecklistGenerica.Fase = istanza_generica_selezionata.CodFase;
            ucChecklistGenerica.MostraOperazioniMassive = true;

            if (txtNoteAutovalutazione.Text == null || txtNoteAutovalutazione.Text == "") //se c'è scritto qualcosa sto salvando le note
                txtNoteAutovalutazione.Text = _autovalutazione_selezionata.Note;
        }

        protected void NascondiDettaglioAutovalutazione()
        {
            divDettaglioAutovalutazione.Visible = false;
            txtNoteAutovalutazione.Text = null;
        }

        #region Button event

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnAggiungiAutovalutazione_Click(object sender, EventArgs e)
        {
            try
            {
                modaleSceltaChecklist.TestataAutovalutazioneValidazione = _testata;
                modaleSceltaChecklist.CreaAutovalutazione = true;
                modaleSceltaChecklist.DomandaPagamento = DomandaPagamento;
                RegisterClientScriptBlock(modaleSceltaChecklist.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAutovalutazione_Click(object sender, EventArgs e)
        {
            try
            {
                testata_x_istanza_provider = new TestataValidazioneXIstanzaCollectionProvider();
                testata_x_istanza_provider.DbProviderObj.BeginTran();

                int id_autovalutazione;
                if (int.TryParse(hdnIdAutovalutazione.Value, out id_autovalutazione))
                    _autovalutazione_selezionata = testata_x_istanza_provider.GetById(id_autovalutazione);
                else
                    throw new Exception("Nessuna autovalutazione selezionata");

                string esito = ucChecklistGenerica.VerificaChecklistDiSchede();
                _autovalutazione_selezionata.Note = txtNoteAutovalutazione.Text;
                testata_x_istanza_provider.Save(_autovalutazione_selezionata);

                testata_x_istanza_provider.DbProviderObj.Commit();
                //ShowMessage("Autovalutazione salvata correttamente.");
                Redirect("Autovalutazione.aspx", "Autovalutazione salvata correttamente.", false);
            }
            catch (Exception ex)
            {
                testata_x_istanza_provider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnEliminaAutovalutazione_Click(object sender, EventArgs e)
        {
            try
            {
                int id_autovalutazione;
                if (int.TryParse(hdnIdAutovalutazione.Value, out id_autovalutazione))
                    _autovalutazione_selezionata = testata_x_istanza_provider.GetById(id_autovalutazione);
                else
                    throw new Exception("Nessuna autovalutazione selezionata");

                string esito = new TestataValidazioneXIstanzaCollectionProvider().EliminaIstanzaACascata(null, ref _autovalutazione_selezionata, null);
                if (esito == null || esito != "")
                    throw new Exception(esito);

                hdnIdAutovalutazione.Value = null;
                Redirect("Autovalutazione.aspx", "Autovalutazione eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnPostElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_autovalutazione;
                if (int.TryParse(hdnIdAutovalutazioneEliminazione.Value, out id_autovalutazione))
                    _autovalutazione_selezionata = testata_x_istanza_provider.GetById(id_autovalutazione);
                else
                    throw new Exception("Nessuna autovalutazione selezionata");

                string esito = new TestataValidazioneXIstanzaCollectionProvider().EliminaIstanzaACascata(null, ref _autovalutazione_selezionata, null);
                if (esito == null || esito != "")
                    throw new Exception(esito);

                hdnIdAutovalutazione.Value = null;
                hdnIdAutovalutazioneEliminazione.Value = null;
                hdnIdAutovalutazioneCopia = null;
                Redirect("Autovalutazione.aspx", "Autovalutazione eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnPostCopia_Click(object sender, EventArgs e)
        {
            try
            {
                TestataValidazione testata_precedente = null;
                int id_autovalutazione;
                if (int.TryParse(hdnIdAutovalutazioneCopia.Value, out id_autovalutazione))
                    testata_precedente = testata_provider.GetById(id_autovalutazione);
                else
                    throw new Exception("Nessuna autovalutazione selezionata");

                if (testata_precedente == null)
                    throw new Exception("Nessuna autovalutazione selezionata");

                if (testata_precedente.IdProgetto == null)
                    throw new Exception("L'autovalutazione selezionata non ha una domanda di aiuto associata: contattare l'helpdesk");

                if (testata_precedente.IdProgetto != Progetto.IdProgetto)
                    throw new Exception("L'autovalutazione selezionata è di un altra domanda di aiuto: impossibile associarla");

                string esito = new TestataValidazioneCollectionProvider().GeneraTestataDaPrecedente(null, testata_precedente, ref _testata, Operatore.Utente.CfUtente, true, true);
                if (esito == null || esito != "")
                    throw new Exception(esito);

                hdnIdAutovalutazione.Value = null;
                hdnIdAutovalutazioneEliminazione.Value = null;
                hdnIdAutovalutazioneCopia = null;
                Redirect("Autovalutazione.aspx", "Autovalutazione copiata correttamente.", false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion

        #region ItemDatabound

        void dgAutovalutazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var tv = (TestataValidazioneXIstanza)e.Item.DataItem;

                if (_autovalutazione_selezionata != null && _autovalutazione_selezionata.IdTestataValidazioneXIstanza == tv.IdTestataValidazioneXIstanza)
                    dgi.Cells[col_Seleziona].Text = dgi.Cells[col_Seleziona].Text.Replace("Seleziona autovalutazione", "Torna elenco");

                if (!AbilitaModifica)
                    dgi.Cells[col_Elimina].Text = "";
            }
        }

        void dgAutovalutazioniPrecedenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var tv = (TestataValidazione)e.Item.DataItem;
            }
        }

        #endregion

    }
}