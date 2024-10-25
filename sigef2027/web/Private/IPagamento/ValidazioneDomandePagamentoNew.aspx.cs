using SiarLibrary.NullTypes;
using System;
using SiarLibrary;
using SiarBLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class ValidazioneDomandePagamentoNew : SiarLibrary.Web.PrivatePage
    {
        BandoValidatoriCollectionProvider validatoriProvider = new BandoValidatoriCollectionProvider();
        TestataValidazioneXIstanzaCollectionProvider testataXIstanzaProvider = new TestataValidazioneXIstanzaCollectionProvider();
        bool isValidatore = false;
        bool isRup = false;

        #region Indici colonne datagrid

        //dgDomandeDaAssegnare
        private int
            col_DaAssegnare_Associa = 0,
            col_DaAssegnare_Num = 1,
            col_DaAssegnare_Bando = 2,
            col_DaAssegnare_IdProgetto = 3,
            col_DaAssegnare_IdDomanda = 4,
            col_DaAssegnare_TipoDomanda = 5,
            col_DaAssegnare_Istruttore = 6;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "validazione_domanda_pagamento";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            isRup = new BandoResponsabiliCollectionProvider().Find(null, Operatore.Utente.IdUtente, null, true, true).Count > 0;

            AbilitaModifica = AbilitaModifica && isRup;

            isValidatore = validatoriProvider.Find(null, Operatore.Utente.IdUtente, null, true).Count > 0;

            if (isValidatore && !isRup)
            {
                tabControlli.Visible = false;
                lblInfoDomandeAssegnate.Text = "Elenco delle domande di pagamento che ti sono state assegnate per la validazione";
            }
            else if (isRup)
            {
                tabControlli.Visible = true;
                lblInfoDomandeAssegnate.Text = "Elenco delle domande già assegnate a un validatore dei tuoi bandi";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            var testataValidazioneProvider = new TestataValidazioneCollectionProvider();

            IntNT nr_pag_pervenute = 0, nr_pag_istruite = 0, nr_pag_validate = 0,
                nr_lotti = 0, nr_lotti_campionati = 0, nr_lotti_conclusi = 0;
            new LottoDiRevisioneCollectionProvider().GetRevisioneRiepilogoRup(Operatore.Utente.IdUtente, null, ref nr_pag_pervenute, ref nr_pag_istruite,
                    ref nr_pag_validate, ref nr_lotti, ref nr_lotti_campionati, ref nr_lotti_conclusi);

            txtNrPagPervenute.Text = nr_pag_pervenute;
            txtNrPagIstruite.Text = nr_pag_istruite;
            txtNrPagValidate.Text = nr_pag_validate;
            txtNrLottiTotali.Text = nr_lotti;
            txtNrLottiEstratti.Text = nr_lotti_campionati;
            txtNrLottiConclusi.Text = nr_lotti_conclusi;

            txtValidatore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            BandoValidatoriCollection operatori = validatoriProvider.GetValidatoriRup(Operatore.Utente.IdUtente, null);
            dgOperatoriValidazione.DataSource = operatori;
            dgOperatoriValidazione.ItemDataBound += new DataGridItemEventHandler(dgOperatoriValidazione_ItemDataBound);
            dgOperatoriValidazione.SetTitoloNrElementi();
            dgOperatoriValidazione.DataBind();

            TestataValidazioneCollection domande;

            int idProgetto = 0;
            int idDomandaPagamento = 0;
            if (!string.IsNullOrEmpty(txtIdProgetto.Text))
                int.TryParse(txtIdProgetto.Text, out idProgetto);
            if (!string.IsNullOrEmpty(txtIdDomanda.Text))
                int.TryParse(txtIdDomanda.Text, out idDomandaPagamento);

            IntNT idProg = null;
            IntNT idDom = null;

            if (idProgetto != 0)
                idProg = idProgetto;
            if (idDomandaPagamento != 0)
                idDom = idDomandaPagamento;

            if (Operatore.Utente.Profilo == "Amministratore")
                domande = testataValidazioneProvider.GetTestataValidazioneGenerico(idProg, idDom);
            else if (isValidatore && !isRup)
                domande = testataValidazioneProvider.GetTestataValidazioneValidatore(Operatore.Utente.CfUtente, null, idProg, idDom);
            else if (isRup && !isValidatore)
                domande = testataValidazioneProvider.GetRevisioneDomandeRup(Operatore.Utente.IdUtente, null, idProg, idDom);
            else if (isRup && isValidatore)
            {
                domande = testataValidazioneProvider.GetTestataValidazioneValidatore(Operatore.Utente.CfUtente, null, idProg, idDom);
                var domandeRup = testataValidazioneProvider.GetRevisioneDomandeRup(Operatore.Utente.IdUtente, null, idProg, idDom);
                domande.AddCollection(domandeRup);

                var domandeList = domande.ToArrayList<TestataValidazione>();

                domande = new TestataValidazioneCollection();
                foreach (TestataValidazione testataList in domandeList)
                {
                    bool trovato = false;

                    foreach (TestataValidazione testataSelezionata in domande)
                    {
                        if (testataSelezionata.IdTestata == testataList.IdTestata)
                            trovato = true;
                    }

                    if (!trovato)
                        domande.Add(testataList);
                }
            }
            else
                domande = new TestataValidazioneCollectionProvider().GetTestataValidazioneGenerico(idProg, idDom);

            dgDomande.DataSource = domande;
            dgDomande.SetTitoloNrElementi();
            dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
            dgDomande.DataBind();

            lstBandiRup.IdRup = Operatore.Utente.IdUtente;
            lstBandiRup.DataBind();

            lstBandiRupValidatore.IdRup = Operatore.Utente.IdUtente;
            lstBandiRupValidatore.DataBind();

            if (!string.IsNullOrEmpty(lstBandiRupValidatore.SelectedValue))
            {
                lstValidatoriBandoRup.IdBando = lstBandiRupValidatore.SelectedValue;
                lstValidatoriBandoRup.DataBind();

                DomandaDiPagamentoCollection domandeDaValidare = new DomandaDiPagamentoCollectionProvider()
                    .GetDomandePerRevisione(Operatore.Utente.IdUtente, lstBandiRupValidatore.SelectedValue);
                dgDomandeDaAssegnare.DataSource = domandeDaValidare;
                dgDomandeDaAssegnare.ItemDataBound += new DataGridItemEventHandler(dgDomandeDaAssegnare_ItemDataBound);
                dgDomandeDaAssegnare.SetTitoloNrElementi();
                dgDomandeDaAssegnare.DataBind();
            }
            else
            {
                lstValidatoriBandoRup.IdBando = "-1";
                lstValidatoriBandoRup.DataBind();

                DomandaDiPagamentoCollection domandeDaValidare = new DomandaDiPagamentoCollectionProvider()
                    .GetDomandePerRevisione(Operatore.Utente.IdUtente, null);
                dgDomandeDaAssegnare.DataSource = domandeDaValidare;
                dgDomandeDaAssegnare.ItemDataBound += new DataGridItemEventHandler(dgDomandeDaAssegnare_ItemDataBound);
                dgDomandeDaAssegnare.SetTitoloNrElementi();
                dgDomandeDaAssegnare.DataBind();
            }

            base.OnPreRender(e);
        }

        void dgOperatoriValidazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BandoValidatori v = (BandoValidatori)e.Item.DataItem;
                e.Item.Cells[1].Text = v.AdditionalAttributes["DESCRIZIONE"];
                e.Item.Cells[5].Text = "<input type=button class=ButtonGrid value=Disabilita style='width:120px' onclick='disabilitaValidatore(" + v.Id + ");' />";
                if (v.Attivo && AbilitaModifica)
                    e.Item.Cells[5].Text = "<input type=button class=ButtonGrid value=Disabilita style='width:120px' onclick='disabilitaValidatore(" + v.Id + ");' />";
                if (!v.Attivo) e.Item.Cells[5].Text = "Disabilitato";
            }
        }

        void dgDomandeDaAssegnare_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DomandaDiPagamento v = (DomandaDiPagamento)e.Item.DataItem;

                e.Item.Cells[col_DaAssegnare_Bando].Text = v.AdditionalAttributes["DESCRIZIONE_BANDO"];

                Utenti istruttore = new UtentiCollectionProvider().Find(v.CfIstruttore, null, null, null, null, null, null)[0];
                e.Item.Cells[col_DaAssegnare_Istruttore].Text = istruttore.Nominativo;
            }
        }

        protected void btnSalvaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                int IdBando = 0;
                if (string.IsNullOrEmpty(lstBandiRup.SelectedValue))
                    throw new Exception("Selezionare un bando dalla lista per salvare un nuovo validatore.");
                else
                    int.TryParse(lstBandiRup.SelectedValue, out IdBando);

                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_utente;
                if (!int.TryParse(hdnIdUtenteSelezionato.Value, out id_utente))
                    throw new Exception("Per continuare si richiede di specificare un operatore.");

                Utenti u = new UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo)
                    throw new Exception("L`operatore selezionato non è valido.");

                // verifico che il dirigente della pf del bando non venga inserito come validatore
                ProfiliCollection profiloDirigente = new ProfiliCollectionProvider().Find(null, "Dirigente della P.F.", null, null, true);
                if (profiloDirigente.Count > 0)
                {
                    var dirigente = profiloDirigente[0];

                    var uStorico = new UtentiStoricoCollectionProvider().Find(u.IdUtente, null, null, true);
                    var b = new BandoCollectionProvider().GetById(IdBando);

                    foreach (UtentiStorico us in uStorico)
                    {
                        if (us.CodEnte == b.CodEnte && us.IdProfilo == dirigente.IdProfilo)
                            throw new Exception("Il dirigente della P.F. non può essere validatore per il bando.");
                    }
                }

                if (validatoriProvider.Find(IdBando, id_utente, null, true).Count > 0)
                    throw new Exception("L`operatore selezionato è già stato nominato.");

                BandoValidatori v = new BandoValidatori();
                v.IdBando = IdBando;
                v.IdUtente = id_utente;
                v.Responsabile = chkResponsabile.Checked;
                v.Attivo = true;
                v.DataInizio = DateTime.Now;
                v.OperatoreInizio = Operatore.Utente.IdUtente;
                validatoriProvider.Save(v);

                ShowMessage("Operatore di validazione nominato correttamente.");
                txtValidatore.Text = hdnIdUtenteSelezionato.Value = "";
                chkResponsabile.Checked = false;
                lstBandiRup.SelectedIndex = -1;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var rev = (TestataValidazione)dgi.DataItem;

                if (rev.SelezionataXRevisione)
                {
                    var istanze_checklist_coll = testataXIstanzaProvider.Find(null, rev.IdTestata, null, null, false);
                    if (istanze_checklist_coll.Count > 0) //if (rev.IdIstanzaChecklistGenerica != null)
                    {
                        dgi.Cells[7].Text = "<input type=button onclick=\"location='RevisioneDomandeNew.aspx?idpag=" + rev.IdDomandaPagamento
                            + "'\" value='Prosegui >>' style='width:130px' class='ButtonGrid'/>";
                    }
                    else
                    {
                        dgi.Cells[7].Text = "Niente istanza";

                        //throw new Exception("Dovrei avere già l'istanza!");

                        /*
                        //chiedo di generare la checklist
                        //e.Item.Cells[7].Text = "<input type=button onclick='MostraModale(" + rev.IdDomandaPagamento + ");' value='Scegli checklist' style='width:130px;' class='ButtonGrid'/>";
                        */

                        /*
                        //devo generare la checklist a partire dall'autovalutazione
                        var errore = new SiarBLL.TestataValidazioneCollectionProvider().GeneraChecklistDaAutovalutazione(null, ref rev, Operatore.Utente.CfUtente, rev.IdLotto, rev.Ordine, rev.CfValidatore);
                        if (errore == null || errore != "")
                            throw new Exception(errore);

                        dgi.Cells[7].Text = "<input type=button onclick=\"location='RevisioneDomandeNew.aspx?idpag=" + rev.IdDomandaPagamento
                            + "'\" value='Prosegui >>' style='width:130px' class='ButtonGrid'/>";
                        */
                    }
                }
                else
                    dgi.Cells[7].Text = "Domanda non selezionata per la revisione.";

                if (rev.SegnaturaRevisione != null)
                    dgi.Cells[6].Text = "<img src='" + Page.ResolveUrl(PATH_IMAGES + "print_ico.gif") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + rev.SegnaturaRevisione + "');\" style='cursor: pointer;'>";
                else
                    dgi.Cells[6].Text = "";
            }
        }

        protected void btnAssegnaDomande_Click(object sender, EventArgs e)
        {
            LottoDiRevisioneCollectionProvider lottoProvider = new LottoDiRevisioneCollectionProvider();
            var testataValidazioneProvider = new TestataValidazioneCollectionProvider(lottoProvider.DbProviderObj);
            var testataXIstanzaProviderAssegna = new TestataValidazioneXIstanzaCollectionProvider(lottoProvider.DbProviderObj);

            try
            {
                lottoProvider.DbProviderObj.BeginTran();
                int IdBando = 0;
                if (string.IsNullOrEmpty(lstBandiRupValidatore.SelectedValue))
                    throw new Exception("Selezionare un bando dalla lista per salvare un nuovo validatore.");
                else
                    int.TryParse(lstBandiRup.SelectedValue, out IdBando);
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstValidatoriBandoRup.SelectedValue))
                    throw new Exception("Per continuare si richiede di specificare un operatore.");

                LottoDiRevisione l = new LottoDiRevisione();
                l.IdBando = lstBandiRupValidatore.SelectedValue;
                l.Provincia = "AN";
                l.DataCreazione = DateTime.Now;
                l.DataModifica = DateTime.Now;
                l.CfOperatore = Operatore.Utente.CfUtente;
                l.NumeroEstrazioni = 0;
                l.RevisioneConclusa = false;
                lottoProvider.Save(l);
                //LottoDiRevisione lottoCreato = lottoProvider.GetById(l.IdLotto);

                string[] domandeSelezionate = ((SiarLibrary.Web.CheckColumn)dgDomandeDaAssegnare.Columns[col_DaAssegnare_Associa]).GetSelected();

                int counter = 1;
                int counterErr = 0;
                if (domandeSelezionate.Count() == 0)
                    throw new Exception("Selezionare almeno una domanda dalla lista.");

                foreach (string id in domandeSelezionate)
                {
                    DomandaDiPagamento d = new DomandaDiPagamentoCollectionProvider().GetById(id);
                    if (d.CfIstruttore != lstValidatoriBandoRup.SelectedValue)
                    {
                        var t = new TestataValidazione();
                        t.IdLotto = l.IdLotto;
                        t.IdProgetto = d.IdProgetto;
                        t.IdDomandaPagamento = id;
                        t.DataInserimento = DateTime.Now;
                        t.CfInserimento = Operatore.Utente.CfUtente;
                        t.DataModifica = DateTime.Now;
                        t.CfModifica = Operatore.Utente.CfUtente;
                        t.CfValidatore = lstValidatoriBandoRup.SelectedValue;
                        t.SelezionataXRevisione = true;
                        t.NumeroEstrazione = 1;
                        t.Ordine = counter;
                        t.SegnaturaRevisione = null;
                        t.SegnaturaSecondaRevisione = null;
                        testataValidazioneProvider.Save(t);
                        counter++;

                        string errore = null;
                        var dati_monitoraggio = new DatiMonitoraggioFESRCollectionProvider().Find(null, d.IdProgetto)[0];

                        // Se è Aiuti genero la checklist, altrimenti devo generare la checklist a partire dall'autovalutazione
                        if (dati_monitoraggio.IdCUPNatura == "06" || dati_monitoraggio.IdCUPNatura == "07")
                            errore = testataValidazioneProvider.GeneraChecklistValidazioneAiuti(lottoProvider.DbProviderObj, ref t, Operatore.Utente.CfUtente);
                        else
                        {
                            //Se è presente l'autovalutazione e una o più istanze creo la checklist da essa, altrimenti senza
                            var progetto = new ProgettoCollectionProvider().GetById(t.IdProgetto);
                            var autovalutazioniColl = testataValidazioneProvider.FindAutovalutazione(null, t.IdProgetto, t.IdDomandaPagamento, true);

                            if (autovalutazioniColl.Count == 1)
                            {
                                var autovalutazione = autovalutazioniColl[0];
                                var autovalutazione_istanze_coll = testataXIstanzaProviderAssegna.Find(null, autovalutazione.IdTestata, null, null, true);

                                if (autovalutazione_istanze_coll.Count > 0)
                                    errore = testataValidazioneProvider.GeneraChecklistDaAutovalutazione(lottoProvider.DbProviderObj, ref t, Operatore.Utente.CfUtente, l.IdLotto, counter, lstValidatoriBandoRup.SelectedValue);
                                else
                                    errore = testataValidazioneProvider.GeneraChecklistSenzaAutovalutazione(lottoProvider.DbProviderObj, ref t, Operatore.Utente.CfUtente, l.IdLotto, counter, lstValidatoriBandoRup.SelectedValue);
                            }
                            else
                                errore = testataValidazioneProvider.GeneraChecklistSenzaAutovalutazione(lottoProvider.DbProviderObj, ref t, Operatore.Utente.CfUtente, l.IdLotto, counter, lstValidatoriBandoRup.SelectedValue);
                        }

                        if (errore == null || errore != "")
                            throw new Exception(errore);
                    }
                    else
                        counterErr++;
                }

                lottoProvider.DbProviderObj.Commit();

                if (counterErr == 0)
                    ShowMessage("Domande correttamente selezionate per la revisione.");
                else
                    ShowMessage("Domande correttamente selezionate per la revisione. Non è stato possibile selezionare " + counterErr + " domande perchè il validatore corrispondeva con l'istruttore");
            }
            catch (Exception ex) { lottoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnDisabilitaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                int id_validatore;
                if (!int.TryParse(hdnIdValidatore.Value, out id_validatore))
                    throw new Exception("Per continuare si richiede di specificare un operatore.");

                BandoValidatori v = validatoriProvider.GetById(id_validatore);
                if (v == null || !v.Attivo)
                    throw new Exception("L`operatore selezionato non è valido.");

                v.Attivo = false;
                v.DataFine = DateTime.Now;
                v.OperatoreFine = Operatore.Utente.IdUtente;
                validatoriProvider.Save(v);
                ShowMessage("Operatore di validazione disabilitato correttamente.");
                hdnIdValidatore.Value = "";
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {

        }

        protected void btnMostraModaleScelta_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterClientScriptBlock(modaleSceltaChecklist.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopup();");
                ShowError(ex.Message);
            }
        }
    }
}