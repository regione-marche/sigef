using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class ValidazioneDomandeFemNew : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.BandoValidatoriCollectionProvider validatori_provider = new SiarBLL.BandoValidatoriCollectionProvider();
        SiarBLL.TestataValidazioneXIstanzaCollectionProvider testata_x_istanza_provider = new SiarBLL.TestataValidazioneXIstanzaCollectionProvider();
        bool isValidatore = false;
        bool isRup = false;

        #region Indici colonne datagrid

        //dgDomandeDaAssegnare
        private int col_DaAssegnare_Num = 0,
            col_DaAssegnare_Bando = 1,
            col_DaAssegnare_IdProgetto = 2,
            col_DaAssegnare_IdDomanda = 3,
            col_DaAssegnare_TipoDomanda = 4,
            col_DaAssegnare_Istruttore = 5,
            col_DaAssegnare_Associa = 6;

        #endregion

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "validazione_domanda_pagamento_fem";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            isRup = new SiarBLL.BandoResponsabiliCollectionProvider().Find(null, Operatore.Utente.IdUtente,
                null, true, true).Count > 0;

            AbilitaModifica = AbilitaModifica && isRup;

            isValidatore = validatori_provider.Find(null, Operatore.Utente.IdUtente, null, true).Count > 0;

            if (isValidatore && !isRup)
            {
                tabControlli.Visible = false;
                lblInfoDomandeAssegnate.Text = "Elenco delle domande di pagamento che ti sono state assegnate per la validazione:";
            }
            else if (isRup)
            {
                tabControlli.Visible = true;
                lblInfoDomandeAssegnate.Text = "Elenco delle domande già assegnate a un validatore dei tuoi bandi:";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            var testata_validazione_provider = new SiarBLL.TestataValidazioneCollectionProvider();

            IntNT nr_pag_pervenute = 0, nr_pag_istruite = 0, nr_pag_validate = 0,
                nr_lotti = 0, nr_lotti_campionati = 0, nr_lotti_conclusi = 0;
            new SiarBLL.LottoDiRevisioneCollectionProvider().GetRevisioneRiepilogoRup(Operatore.Utente.IdUtente, null, ref nr_pag_pervenute, ref nr_pag_istruite,
                    ref nr_pag_validate, ref nr_lotti, ref nr_lotti_campionati, ref nr_lotti_conclusi);

            txtNrPagPervenute.Text = nr_pag_pervenute;
            txtNrPagIstruite.Text = nr_pag_istruite;
            txtNrPagValidate.Text = nr_pag_validate;
            txtNrLottiTotali.Text = nr_lotti;
            txtNrLottiEstratti.Text = nr_lotti_campionati;
            txtNrLottiConclusi.Text = nr_lotti_conclusi;

            txtValidatore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            SiarLibrary.BandoValidatoriCollection operatori = validatori_provider.GetValidatoriRupFem(Operatore.Utente.IdUtente, null);
            dgOperatoriValidazione.DataSource = operatori;
            dgOperatoriValidazione.ItemDataBound += new DataGridItemEventHandler(dgOperatoriValidazione_ItemDataBound);
            dgOperatoriValidazione.SetTitoloNrElementi();
            dgOperatoriValidazione.DataBind();

            SiarLibrary.TestataValidazioneCollection domande;

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
                domande = testata_validazione_provider.GetTestataValidazioneGenericoFem(idProg, idDom);
            else if (isValidatore && !isRup)
                domande = testata_validazione_provider.GetTestataValidazioneValidatoreFem(Operatore.Utente.CfUtente, null, idProg, idDom);
            else if (isRup && !isValidatore)
                domande = testata_validazione_provider.GetRevisioneDomandeRupFem(Operatore.Utente.IdUtente, null, idProg, idDom);
            else
                domande = testata_validazione_provider.GetTestataValidazioneGenericoFem(idProg, idDom);

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

                SiarLibrary.DomandaDiPagamentoCollection domandeDaValidare = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetDomandePerRevisioneFem(Operatore.Utente.IdUtente, lstBandiRupValidatore.SelectedValue);
                dgDomandeDaAssegnare.DataSource = domandeDaValidare;
                dgDomandeDaAssegnare.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDomandeDaAssegnare_ItemDataBound);
                dgDomandeDaAssegnare.SetTitoloNrElementi();
                dgDomandeDaAssegnare.DataBind();
            }
            else
            {
                lstValidatoriBandoRup.IdBando = "-1";
                lstValidatoriBandoRup.DataBind();

                SiarLibrary.DomandaDiPagamentoCollection domandeDaValidare = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetDomandePerRevisioneFem(Operatore.Utente.IdUtente, null);
                dgDomandeDaAssegnare.DataSource = domandeDaValidare;
                dgDomandeDaAssegnare.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDomandeDaAssegnare_ItemDataBound);
                dgDomandeDaAssegnare.SetTitoloNrElementi();
                dgDomandeDaAssegnare.DataBind();
            }

            base.OnPreRender(e);
        }

        void dgOperatoriValidazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoValidatori v = (SiarLibrary.BandoValidatori)e.Item.DataItem;
                e.Item.Cells[1].Text = v.AdditionalAttributes["DESCRIZIONE"];
                e.Item.Cells[5].Text = "<input type=button class=ButtonGrid value=Disabilita style='width:120px' onclick='disabilitaValidatore(" + v.Id + ");' />";
                if (v.Attivo && AbilitaModifica)
                    e.Item.Cells[5].Text = "<input type=button class=ButtonGrid value=Disabilita style='width:120px' onclick='disabilitaValidatore(" + v.Id + ");' />";
                if (!v.Attivo) e.Item.Cells[5].Text = "Disabilitato";
            }
        }

        void dgDomandeDaAssegnare_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.DomandaDiPagamento v = (SiarLibrary.DomandaDiPagamento)e.Item.DataItem;

                e.Item.Cells[col_DaAssegnare_Bando].Text = v.AdditionalAttributes["DESCRIZIONE_BANDO"];

                SiarLibrary.Utenti istruttore = new SiarBLL.UtentiCollectionProvider().Find(v.CfIstruttore, null, null, null, null, null, null)[0];
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
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                int id_utente;
                if (!int.TryParse(hdnIdUtenteSelezionato.Value, out id_utente))
                    throw new Exception("Per continuare si richiede di specificare un operatore.");

                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo)
                    throw new Exception("L`operatore selezionato non è valido.");

                // verifico che il dirigente della pf del bando non venga inserito come validatore
                SiarLibrary.ProfiliCollection profiloDirigente = new SiarBLL.ProfiliCollectionProvider().Find(null, "Dirigente della P.F.", null, null, true);
                if (profiloDirigente.Count > 0)
                {
                    var dirigente = profiloDirigente[0];

                    var uStorico = new SiarBLL.UtentiStoricoCollectionProvider().Find(u.IdUtente, null, null, true);
                    var b = new SiarBLL.BandoCollectionProvider().GetById(IdBando);

                    foreach (SiarLibrary.UtentiStorico us in uStorico)
                    {
                        if (us.CodEnte == b.CodEnte && us.IdProfilo == dirigente.IdProfilo)
                            throw new Exception("Il dirigente della P.F. non può essere validatore per il bando.");
                    }
                }

                if (validatori_provider.Find(IdBando, id_utente, null, true).Count > 0)
                    throw new Exception("L`operatore selezionato è già stato nominato.");

                SiarLibrary.BandoValidatori v = new SiarLibrary.BandoValidatori();
                v.IdBando = IdBando;
                v.IdUtente = id_utente;
                v.Responsabile = chkResponsabile.Checked;
                v.Attivo = true;
                v.DataInizio = DateTime.Now;
                v.OperatoreInizio = Operatore.Utente.IdUtente;
                validatori_provider.Save(v);

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
                var rev = (SiarLibrary.TestataValidazione)dgi.DataItem;

                if (rev.SelezionataXRevisione)
                {
                    var istanze_checklist_coll = testata_x_istanza_provider.Find(null, rev.IdTestata, null, null, false);
                    if (istanze_checklist_coll.Count > 0) //if (rev.IdIstanzaChecklistGenerica != null)
                    {
                        dgi.Cells[7].Text = "<input type=button onclick=\"location='RevisioneDomandeFemNew.aspx?idpag=" + rev.IdDomandaPagamento
                            + "'\" value='Prosegui >>' style='width:130px' class='ButtonGrid'/>";
                    }
                    else
                    {
                        dgi.Cells[7].Text = "Niente istanza";
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
            SiarBLL.LottoDiRevisioneCollectionProvider lotto_provider = new SiarBLL.LottoDiRevisioneCollectionProvider();
            var testata_validazione_provider = new SiarBLL.TestataValidazioneCollectionProvider(lotto_provider.DbProviderObj);

            try
            {
                lotto_provider.DbProviderObj.BeginTran();
                int IdBando = 0;
                if (string.IsNullOrEmpty(lstBandiRupValidatore.SelectedValue)) throw new Exception("Selezionare un bando dalla lista per salvare un nuovo validatore.");
                else
                    int.TryParse(lstBandiRup.SelectedValue, out IdBando);
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstValidatoriBandoRup.SelectedValue)) throw new Exception("Per continuare si richiede di specificare un operatore.");

                SiarLibrary.LottoDiRevisione l = new SiarLibrary.LottoDiRevisione();
                l.IdBando = lstBandiRupValidatore.SelectedValue;
                l.Provincia = "AN";
                l.DataCreazione = DateTime.Now;
                l.DataModifica = DateTime.Now;
                l.CfOperatore = Operatore.Utente.CfUtente;
                l.NumeroEstrazioni = 0;
                l.RevisioneConclusa = false;
                lotto_provider.Save(l);
                SiarLibrary.LottoDiRevisione lotto_creato = lotto_provider.GetById(l.IdLotto);

                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumn)dgDomandeDaAssegnare.Columns[col_DaAssegnare_Associa]).GetSelected();

                int counter = 1;
                int counterErr = 0;
                if (domande_selezionate.Count() == 0)
                    throw new Exception("Selezionare almeno una domanda dalla lista.");

                foreach (string id in domande_selezionate)
                {
                    SiarLibrary.DomandaDiPagamento d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(id);
                    if (d.CfIstruttore != lstValidatoriBandoRup.SelectedValue)
                    {
                        var t = new SiarLibrary.TestataValidazione();
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
                        testata_validazione_provider.Save(t);
                        counter++;

                        string errore = null;
                        var dati_monitoraggio = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Find(null, d.IdProgetto)[0];

                        // Per gli strumenti finanziari c'è la distinzione solamente per tipologia di domanda come prima -> la controllo nel metodo
                        errore = testata_validazione_provider.GeneraChecklistValidazioneStrumentiFinanziari(lotto_provider.DbProviderObj, ref t, Operatore.Utente.CfUtente, d.CodTipo);

                        if (errore == null || errore != "")
                            throw new Exception(errore);
                    }
                    else
                        counterErr++;
                }

                lotto_provider.DbProviderObj.Commit();

                if (counterErr == 0)
                    ShowMessage("Domande correttamente selezionate per la revisione.");
                else
                    ShowMessage("Domande correttamente selezionate per la revisione. Non è stato possibile selezionare " + counterErr + " domande perchè il validatore corrispondeva con l'istruttore");
            }
            catch (Exception ex) { lotto_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnDisabilitaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_validatore;
                if (!int.TryParse(hdnIdValidatore.Value, out id_validatore)) throw new Exception("Per continuare si richiede di specificare un operatore.");
                SiarLibrary.BandoValidatori v = validatori_provider.GetById(id_validatore);
                if (v == null || !v.Attivo) throw new Exception("L`operatore selezionato non è valido.");
                v.Attivo = false;
                v.DataFine = DateTime.Now;
                v.OperatoreFine = Operatore.Utente.IdUtente;
                validatori_provider.Save(v);
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