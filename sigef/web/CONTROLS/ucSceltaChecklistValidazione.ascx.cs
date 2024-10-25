using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;

namespace web.CONTROLS
{
    public partial class ucSceltaChecklistValidazione : SigefUserControl
    {
        #region Indici colonne

        private int col_IdChecklist = 0,
            col_Ordina = 1,
            col_Descrizione = 2,
            col_Includi = 3,
            col_Conteggio = 4;

        #endregion

        private class SchedaDatagrid
        {
            public int _id_checklist;
            public int IdChecklist
            {
                get { return _id_checklist; }
                set { _id_checklist = value; }
            }

            private string _descrizione;
            public string Descrizione
            {
                get { return _descrizione; }
                set { _descrizione = value; }
            }

            public bool _includi;
            public bool Includi
            {
                get { return _includi; }
                set { _includi = value; }
            }

            public int _conteggio;
            public int Conteggio
            {
                get { return _conteggio; }
                set { _conteggio = value; }
            }

            public SchedaDatagrid(int id_checklist, string desc, bool inc)
            {
                this.IdChecklist = id_checklist;
                this.Descrizione = desc;
                this.Includi = inc;
                this.Conteggio = 1;
            }

            public SchedaDatagrid(int id_checklist, string desc, bool inc, int count)
            {
                this.IdChecklist = id_checklist;
                this.Descrizione = desc;
                this.Includi = inc;
                this.Conteggio = count;
            }
        }

        private string _mostra;
        public string Mostra
        {
            get { return _mostra; }
            //set { _mostra = value; }
        }

        private ChecklistGenerica _checklist;
        public ChecklistGenerica ChecklistGenerica
        {
            get { return _checklist; }
            set { _checklist = value; }
        }

        private DomandaDiPagamento _domanda;
        public DomandaDiPagamento DomandaPagamento
        {
            get { return _domanda; }
            set { _domanda = value; }
        }

        private bool _crea_autovalutazione;
        public bool CreaAutovalutazione
        {
            get { return _crea_autovalutazione; }
            set { _crea_autovalutazione = value; }
        }

        private TestataValidazione _testata_autovalutazione_validazione;
        public TestataValidazione TestataAutovalutazioneValidazione
        {
            get { return _testata_autovalutazione_validazione; }
            set { _testata_autovalutazione_validazione = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _mostra = "mostraPopupTemplate('" + divSceltaChecklistValidazione.UniqueID.Replace('$', '_') + "','divBKGMessaggio');";
        }

        protected override void OnPreRender(EventArgs e)
        {
            PopolaHidden();
            PopolaDataGrid();

            base.OnPreRender(e);
        }

        private void PopolaDataGrid()
        {
            if (_crea_autovalutazione)
            {
                pTitolo.InnerText = "Scelta lavori per autovalutazione";
                divValidatore.Visible = false;
                PopolaDataGridAutovalutazione();
            }
            else
            {
                divBeneficiario.Visible = false;
                PopolaDataGridValidatore();
            }
        }

        private void PopolaDataGridAutovalutazione()
        {
            var checklist_collection = new TestataValidazioneCollectionProvider().GetSchedeAutovalutazione();
            if (checklist_collection.Count != 12)
                throw new Exception("Trovate " + checklist_collection.Count + " schede per checklist appalti invece di 12");
            var checklist_list = checklist_collection.ToArrayList<ChecklistGenerica>();

            var schede_pubblici_collection = new List<SchedaDatagrid>();

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 1 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 1 - LAVORI%")).First<ChecklistGenerica>().Descrizione, 
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 2 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 2 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 3 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 3 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 4 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 4 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 5 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 5 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 6 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 6 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 7 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 7 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 8 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 8 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 9 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 9 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 10 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 10 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 11 - IN HOUSE%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 11 - IN HOUSE%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda procedura 12 - Ex D. LGS 163/2006%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda procedura 12 - Ex D. LGS 163/2006%")).First<ChecklistGenerica>().Descrizione,
                false));

            dgBeneficiario.DataSource = schede_pubblici_collection;
            dgBeneficiario.ItemDataBound += new DataGridItemEventHandler(dgBeneficiario_ItemDataBound);
            dgBeneficiario.DataBind();
        }

        private void PopolaDataGridValidatore()
        {
            var checklist_collection = new TestataValidazioneCollectionProvider().GetSchedeChecklistAppalti();
            if (checklist_collection.Count != 17)
                throw new Exception("Trovate " + checklist_collection.Count + " schede per checklist appalti invece di 17");
            var checklist_list = checklist_collection.ToArrayList<ChecklistGenerica>();

            var schede_pubblici_collection = new List<SchedaDatagrid>();

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Ambiente%")).First<ChecklistGenerica>().IdChecklistGenerica,
                "Scheda Ambiente",
                true)); //deve essere inclusa e obbligatoria per indicazione su pass

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Rapporto%")).First<ChecklistGenerica>().IdChecklistGenerica,
                "Scheda Rapporto",
                true)); //deve essere inclusa e obbligatoria per indicazione su pass

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 1 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 1 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 2 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 2 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 3 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 3 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 4 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 4 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 5 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 5 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 6 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 6 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 7 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 7 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 8 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 8 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 9 - LAVORI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 9 - LAVORI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 10 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 10 - FORNITURE E SERVIZI%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 11 - IN HOUSE%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda Procedura 11 - IN HOUSE%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Scheda procedura 12 - Ex D. LGS 163/2006%")).First<ChecklistGenerica>().IdChecklistGenerica,
                checklist_list.Where(c => c.Descrizione.Like("%Scheda procedura 12 - Ex D. LGS 163/2006%")).First<ChecklistGenerica>().Descrizione,
                false));

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Ammissibilità%")).First<ChecklistGenerica>().IdChecklistGenerica,
                "Scheda Ammissibilità",
                true)); //deve essere inclusa e obbligatoria per indicazione su pass

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Pagamenti Fattura%")).First<ChecklistGenerica>().IdChecklistGenerica,
                "Scheda Pagamenti Fattura",
                true)); //deve essere inclusa e obbligatoria per indicazione su pass

            schede_pubblici_collection.Add(new SchedaDatagrid(
                checklist_list.Where(c => c.Descrizione.Like("%Pubblicità%")).First<ChecklistGenerica>().IdChecklistGenerica,
                "Scheda Pubblicità",
                true)); //deve essere inclusa e obbligatoria per indicazione su pass

            dgValidatore.DataSource = schede_pubblici_collection;
            dgValidatore.ItemDataBound += new DataGridItemEventHandler(dgValidatore_ItemDataBound);
            dgValidatore.DataBind();
        }

        private void PopolaHidden()
        {
            hdnIdTestata.Value = _testata_autovalutazione_validazione != null ? _testata_autovalutazione_validazione.IdTestata : null;
            hdnCreaAutovalutazione.Value = _crea_autovalutazione ? "true" : "false";
        }

        private void SvuotaHidden()
        {
            hdnIdTestata.Value = null;
            hdnCreaAutovalutazione.Value = "false";
        }

        private void CaricaHidden()
        {
            int id_testata;
            if (int.TryParse(hdnIdTestata.Value, out id_testata))
                _testata_autovalutazione_validazione = new TestataValidazioneCollectionProvider().GetById(id_testata);

            if (hdnCreaAutovalutazione.Value != null && hdnCreaAutovalutazione.Value == "true")
                _crea_autovalutazione = true;
            else
                _crea_autovalutazione = false;
        }

        #region Button Click

        protected void btnCreaAutovalutazioneBeneficiario_Click(object sender, EventArgs e)
        {
            CaricaHidden();
            var checklist_provider = new ChecklistGenericaCollectionProvider();

            try
            {
                if (_testata_autovalutazione_validazione == null || _testata_autovalutazione_validazione.IdTestata == null)
                    throw new Exception("Testata autovalutazione non selezionata");

                var schede_x_check_provider = new SchedaXChecklistCollectionProvider(checklist_provider.DbProviderObj);
                var istanza_check_provider = new IstanzaChecklistGenericaCollectionProvider(checklist_provider.DbProviderObj);
                var testata_provider = new TestataValidazioneCollectionProvider();
                var istanza_testata_provider = new TestataValidazioneXIstanzaCollectionProvider(checklist_provider.DbProviderObj);
                checklist_provider.DbProviderObj.BeginTran();

                //Creo la checklist di schede 
                var checklist = new ChecklistGenerica();
                checklist.CfInserimento = checklist.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                checklist.DataInserimento = checklist.DataModifica = DateTime.Now;
                checklist.IdTipo = 3;
                checklist.FlagTemplate = 0;
                checklist_provider.Save(checklist);

                string[] schede_selezionate = ((CheckColumn)dgBeneficiario.Columns[col_Includi]).GetSelected();

                int ordine = 1;

                //per ogni scheda selezionata creo la scheda e la relativa istanza e l'associo alla checklist
                //inoltre preparo la descrizione della checklist
                if (schede_selezionate.Length > 0)
                {
                    string descrizione_checklist = "Domanda aiuto " + _testata_autovalutazione_validazione.IdProgetto + " - Domanda pagamento " + _testata_autovalutazione_validazione.IdDomandaPagamento + " - "; 

                    for (int i = 0; i < schede_selezionate.Length; i++)
                    {
                        var id_scheda = int.Parse(schede_selezionate[i]);
                        var checklist_scheda_selezionata = checklist_provider.GetById(id_scheda);
                        descrizione_checklist += testata_provider.GetDescrizioneSchedaXAutovalutazione(checklist_scheda_selezionata.Descrizione);

                        var conteggio_text = Request.Form["ConteggioBeneficiario" + id_scheda + "_text"];
                        var conteggio = (conteggio_text == null || conteggio_text == "") ? 0 : decimal.Parse(conteggio_text);

                        //creo la stessa scheda per il numero di volte che mi specifica l'utente
                        for (int y = 0; y < conteggio; y++)
                        {
                            var scheda_x_checklist = new SchedaXChecklist();
                            scheda_x_checklist.CfInserimento = scheda_x_checklist.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                            scheda_x_checklist.DataInserimento = scheda_x_checklist.DataModifica = DateTime.Now;
                            scheda_x_checklist.Ordine = ordine;
                            ordine++;
                            scheda_x_checklist.IdChecklistPadre = checklist.IdChecklistGenerica;
                            scheda_x_checklist.IdChecklistFiglio = id_scheda;
                            schede_x_check_provider.Save(scheda_x_checklist);

                            var istanza_generica_scheda = new IstanzaChecklistGenerica();
                            istanza_generica_scheda.CfInserimento = istanza_generica_scheda.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                            istanza_generica_scheda.DataInserimento = istanza_generica_scheda.DataModifica = DateTime.Now;
                            istanza_generica_scheda.IdChecklistGenerica = checklist_scheda_selezionata.IdChecklistGenerica;
                            istanza_generica_scheda.IdChecklistPadre = checklist.IdChecklistGenerica;
                            istanza_generica_scheda.IdSchedaXChecklist = scheda_x_checklist.IdSchedaXChecklist;
                            istanza_check_provider.Save(istanza_generica_scheda);
                        }
                    }

                    checklist.Descrizione = descrizione_checklist.Substring(0, descrizione_checklist.Length - 2); //rimuovo la virgola e lo spazio finale
                    checklist_provider.Save(checklist);
                }
                else
                    throw new Exception("E' necessario selezionare almeno una scheda");

                //creo l'istanza della checklist di schede
                var nuova_istanza_generica = new IstanzaChecklistGenerica();
                nuova_istanza_generica.CfInserimento = nuova_istanza_generica.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                nuova_istanza_generica.DataInserimento = nuova_istanza_generica.DataModifica = DateTime.Now;
                nuova_istanza_generica.IdChecklistGenerica = checklist.IdChecklistGenerica;
                istanza_check_provider.Save(nuova_istanza_generica);

                //creo l'istanza per la testata validazione e associo l'istanza della checklist
                var istanza_testata = new TestataValidazioneXIstanza();
                istanza_testata.CfInserimento = istanza_testata.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                istanza_testata.DataInserimento = istanza_testata.DataModifica = DateTime.Now;
                istanza_testata.IdTestataValidazione = _testata_autovalutazione_validazione.IdTestata;
                istanza_testata.IdIstanzaChecklistGenerica = nuova_istanza_generica.IdIstanzaGenerica;
                istanza_testata.Ordine = istanza_testata_provider.GetProssimoOrdineXTestata(_testata_autovalutazione_validazione.IdTestata);
                istanza_testata_provider.Save(istanza_testata);

                checklist_provider.DbProviderObj.Commit();
                ((PrivatePage)Page).ShowMessage("Autovalutazione creata correttamente");
            }
            catch (Exception ex)
            {
                checklist_provider.DbProviderObj.Rollback();
                ((PrivatePage)Page).ShowError(ex.Message);
            }
            finally
            {
                ((PrivatePage)Page).RegisterClientScriptBlock(Mostra);
                //((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopupTemplate();");
            }
        }

        protected void btnCreaChecklistValidatore_Click(object sender, EventArgs e)
        {
            CaricaHidden();
            var checklist_provider = new ChecklistGenericaCollectionProvider();

            try
            {
                if (_testata_autovalutazione_validazione == null || _testata_autovalutazione_validazione.IdTestata == null)
                    throw new Exception("Testata validazione non selezionata");

                var schede_x_check_provider = new SchedaXChecklistCollectionProvider(checklist_provider.DbProviderObj);
                var istanza_check_provider = new IstanzaChecklistGenericaCollectionProvider(checklist_provider.DbProviderObj);
                var testata_provider = new TestataValidazioneCollectionProvider();
                var istanza_testata_provider = new TestataValidazioneXIstanzaCollectionProvider(checklist_provider.DbProviderObj);
                checklist_provider.DbProviderObj.BeginTran();

                //Creo la checklist di schede 
                var checklist = new ChecklistGenerica();
                checklist.CfInserimento = checklist.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                checklist.DataInserimento = checklist.DataModifica = DateTime.Now;
                checklist.IdTipo = 3;
                checklist.FlagTemplate = 0;
                checklist_provider.Save(checklist);

                string[] schede_selezionate = ((CheckColumn)dgValidatore.Columns[col_Includi]).GetSelected();

                int ordine = 1;

                //per ogni scheda selezionata creo la scheda e la relativa istanza e l'associo alla checklist
                //inoltre preparo la descrizione della checklist
                if (schede_selezionate.Length > 0)
                {
                    string descrizione_checklist = "Domanda aiuto " + _testata_autovalutazione_validazione.IdProgetto + " - Domanda pagamento " + _testata_autovalutazione_validazione.IdDomandaPagamento + " - ";

                    for (int i = 0; i < schede_selezionate.Length; i++)
                    {
                        var id_scheda = int.Parse(schede_selezionate[i]);
                        var checklist_scheda_selezionata = checklist_provider.GetById(id_scheda);
                        descrizione_checklist += testata_provider.GetDescrizioneSchedaXAutovalutazione(checklist_scheda_selezionata.Descrizione);

                        var conteggio_text = Request.Form["ConteggioValidatore" + id_scheda + "_text"];
                        var conteggio = (conteggio_text == null || conteggio_text == "") ? 0 : decimal.Parse(conteggio_text);

                        //creo la stesssa scheda per il numero di volte che mi specifica l'utente
                        for (int y = 0; y < conteggio; y++)
                        {
                            var scheda_x_checklist = new SchedaXChecklist();
                            scheda_x_checklist.CfInserimento = scheda_x_checklist.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                            scheda_x_checklist.DataInserimento = scheda_x_checklist.DataModifica = DateTime.Now;
                            scheda_x_checklist.Ordine = ordine;
                            ordine++;
                            scheda_x_checklist.IdChecklistPadre = checklist.IdChecklistGenerica;
                            scheda_x_checklist.IdChecklistFiglio = id_scheda;
                            schede_x_check_provider.Save(scheda_x_checklist);

                            var istanza_generica_scheda = new IstanzaChecklistGenerica();
                            istanza_generica_scheda.CfInserimento = istanza_generica_scheda.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                            istanza_generica_scheda.DataInserimento = istanza_generica_scheda.DataModifica = DateTime.Now;
                            istanza_generica_scheda.IdChecklistGenerica = checklist_scheda_selezionata.IdChecklistGenerica;
                            istanza_generica_scheda.IdChecklistPadre = checklist.IdChecklistGenerica;
                            istanza_generica_scheda.IdSchedaXChecklist = scheda_x_checklist.IdSchedaXChecklist;
                            istanza_check_provider.Save(istanza_generica_scheda);
                        }
                    }

                    checklist.Descrizione = descrizione_checklist.Substring(0, descrizione_checklist.Length - 2); //rimuovo la virgola e lo spazio finale
                    checklist_provider.Save(checklist);
                }
                else
                    throw new Exception("E' necessario selezionare almeno una scheda");

                //creo l'istanza della checklist di schede
                var nuova_istanza_generica = new IstanzaChecklistGenerica();
                nuova_istanza_generica.CfInserimento = nuova_istanza_generica.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                nuova_istanza_generica.DataInserimento = nuova_istanza_generica.DataModifica = DateTime.Now;
                nuova_istanza_generica.IdChecklistGenerica = checklist.IdChecklistGenerica;
                istanza_check_provider.Save(nuova_istanza_generica);

                //creo l'istanza per la testata validazione e associo l'istanza della checklist
                var istanza_testata = new TestataValidazioneXIstanza();
                istanza_testata.CfInserimento = istanza_testata.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                istanza_testata.DataInserimento = istanza_testata.DataModifica = DateTime.Now;
                istanza_testata.IdTestataValidazione = _testata_autovalutazione_validazione.IdTestata;
                istanza_testata.IdIstanzaChecklistGenerica = nuova_istanza_generica.IdIstanzaGenerica;
                istanza_testata.Ordine = istanza_testata_provider.GetProssimoOrdineXTestata(_testata_autovalutazione_validazione.IdTestata);
                istanza_testata_provider.Save(istanza_testata);

                checklist_provider.DbProviderObj.Commit();
                ((PrivatePage)Page).ShowMessage("Checklist creata correttamente");
            }
            catch (Exception ex)
            {
                checklist_provider.DbProviderObj.Rollback();
                ((PrivatePage)Page).ShowError(ex.Message);
            }
            finally
            {
                ((PrivatePage)Page).RegisterClientScriptBlock(Mostra);
            }
        }

        protected void btnChiudi_Click(object sender, EventArgs e)
        {
            ((PrivatePage)Page).RegisterClientScriptBlock("chiudiPopupTemplate();");
            SvuotaHidden();
        }

        #endregion

        #region ItemDatabound

        void dgBeneficiario_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var s = (SchedaDatagrid)e.Item.DataItem;

                if (s.Includi)
                    dgi.Cells[col_Includi].Text = dgi.Cells[col_Includi].Text.Replace("<input", "<input disabled='true' checked ");
                else
                    dgi.Cells[col_Includi].Text = dgi.Cells[col_Includi].Text.Replace("checked", "");

                dgi.Cells[col_Conteggio].Text = @"<span id='spanConteggioBeneficiario" + s.IdChecklist + "' class='IntegerBox' nocurrency='true'><input type='text' id='ConteggioBeneficiario" + s.IdChecklist + "_text' name='ConteggioBeneficiario" + s.IdChecklist + "_text' value='" + s.Conteggio + "' style='text-align:right;width:60px' class=''></span>";
            }
        }

        void dgValidatore_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            var dgi = e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var s = (SchedaDatagrid)e.Item.DataItem;

                if (s.Includi) //se incluse di default non permetto di deselezionarle e deve essercene una
                {
                    dgi.Cells[col_Includi].Text = dgi.Cells[col_Includi].Text.Replace("<input", "<input disabled='true' checked ");

                    dgi.Cells[col_Conteggio].Text = @"<span id='spanConteggioValidatore" + s.IdChecklist + "' class='IntegerBox' nocurrency='true'><input type='text' id='ConteggioValidatore" + s.IdChecklist + "_text' name='ConteggioValidatore" + s.IdChecklist + "_text' value='" + s.Conteggio + "' style='text-align:right;width:60px' disabled='true' class=''></span>";
                }
                else
                {
                    dgi.Cells[col_Includi].Text = dgi.Cells[col_Includi].Text.Replace("checked", "");

                    dgi.Cells[col_Conteggio].Text = @"<span id='spanConteggioValidatore" + s.IdChecklist + "' class='IntegerBox' nocurrency='true'><input type='text' id='ConteggioValidatore" + s.IdChecklist + "_text' name='ConteggioValidatore" + s.IdChecklist + "_text' value='" + s.Conteggio + "' style='text-align:right;width:60px' class=''></span>";
                }
            }
        }

        #endregion
    }
}