using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Fem
{
    public partial class ValidazioneDomandeFem : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "validazione_domanda_pagamento_fem";
            base.OnPreInit(e);
        }

        SiarBLL.BandoValidatoriCollectionProvider validatori_provider = new SiarBLL.BandoValidatoriCollectionProvider();
        bool isValidatore = false;
        bool isRup = false;

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
            SiarLibrary.NullTypes.IntNT nr_pag_pervenute = 0, nr_pag_istruite = 0, nr_pag_validate = 0,
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
            dgOperatoriValidazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgOperatoriValidazione_ItemDataBound);
            dgOperatoriValidazione.SetTitoloNrElementi();
            dgOperatoriValidazione.DataBind();

            SiarLibrary.RevisioneDomandaPagamentoCollection domande;

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

            if (isValidatore && !isRup)
                domande = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider().GetRevisioneDomandeValidatoreFem(Operatore.Utente.CfUtente, null, idProg, idDom);
            else if (isRup && !isValidatore)
                domande = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider().GetRevisioneDomandeRupFem(Operatore.Utente.IdUtente, null, idProg, idDom);
            else
                domande = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider().GetRevisioneDomandeGenericoFem(idProg, idDom);

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
                e.Item.Cells[1].Text = v.AdditionalAttributes["DESCRIZIONE_BANDO"];

                SiarLibrary.Utenti istruttore = new SiarBLL.UtentiCollectionProvider().Find(v.CfIstruttore, null, null, null, null, null, null)[0];

                e.Item.Cells[4].Text = istruttore.Nominativo;
            }
        }

        protected void btnSalvaValidatore_Click(object sender, EventArgs e)
        {
            try
            {
                int IdBando = 0;
                if (string.IsNullOrEmpty(lstBandiRup.SelectedValue)) throw new Exception("Selezionare un bando dalla lista per salvare un nuovo validatore.");
                else
                    int.TryParse(lstBandiRup.SelectedValue, out IdBando);
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_utente;
                if (!int.TryParse(hdnIdUtenteSelezionato.Value, out id_utente)) throw new Exception("Per continuare si richiede di specificare un operatore.");
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo) throw new Exception("L`operatore selezionato non è valido.");

                // verifico che il dirigente della pf del bando non venga inserito come validatore
                SiarLibrary.ProfiliCollection profiloDirigente = new SiarBLL.ProfiliCollectionProvider().Find(null, "Dirigente della P.F.", null, null, true);
                if (profiloDirigente.Count > 0)
                {
                    SiarLibrary.Profili dirigente = profiloDirigente[0];

                    SiarLibrary.UtentiStoricoCollection uStorico = new SiarBLL.UtentiStoricoCollectionProvider().Find(u.IdUtente, null, null, true);

                    SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(IdBando);

                    foreach (SiarLibrary.UtentiStorico us in uStorico)
                    {
                        if (us.CodEnte == b.CodEnte && us.IdProfilo == dirigente.IdProfilo) throw new Exception("Il dirigente della P.F. non può essere validatore per il bando.");
                    }
                }

                if (validatori_provider.Find(IdBando, id_utente, null, true).Count > 0) throw new Exception("L`operatore selezionato è già stato nominato.");
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RevisioneDomandaPagamento rev = (SiarLibrary.RevisioneDomandaPagamento)e.Item.DataItem;
                //int id_domanda;
                //if (int.TryParse(txtNumeroDomanda.Text, out id_domanda) && rev.IdProgetto == id_domanda &&
                //    (string.IsNullOrEmpty(lstTipoPagamento.SelectedValue) || rev.CodTipo == lstTipoPagamento.SelectedValue))
                //    e.Item.Cells[0].Style.Add("color", "#ff0000");  //System.Drawing.Color.FromArgb(220, 80, 80));
                if (rev.SelezionataXRevisione)
                {
                    SiarLibrary.Utenti validatore = new SiarBLL.UtentiCollectionProvider().Find(rev.CfOperatore, null, null, null, null, null, null)[0];

                    e.Item.Cells[4].Text = validatore.Nominativo;

                    e.Item.Cells[6].Text = "<input type=button onclick=\"location='"+PATH_IPAGAMENTO+"RevisioneDomande.aspx?idpag=" + rev.IdDomandaPagamento
                        + "'\" value='Prosegui >>' style='width:130px' class='ButtonGrid'/>";
                }
            }
        }

        protected void btnAssegnaDomande_Click(object sender, EventArgs e)
        {
            SiarBLL.LottoDiRevisioneCollectionProvider lotto_provider = new SiarBLL.LottoDiRevisioneCollectionProvider();
            SiarBLL.RevisioneDomandaPagamentoCollectionProvider revisione_provider = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider(lotto_provider.DbProviderObj);
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


                string[] domande_selezionate = ((SiarLibrary.Web.CheckColumn)dgDomandeDaAssegnare.Columns[5]).GetSelected();

                int counter = 1;
                int counterErr = 0;
                if (domande_selezionate.Count() == 0) throw new Exception("Selezionare almeno una domanda dalla lista.");
                foreach (string id in domande_selezionate)
                {
                    SiarLibrary.DomandaDiPagamento d = new SiarBLL.DomandaDiPagamentoCollectionProvider().GetById(id);
                    if (d.CfIstruttore != lstValidatoriBandoRup.SelectedValue)
                    {
                        SiarLibrary.RevisioneDomandaPagamento r = new SiarLibrary.RevisioneDomandaPagamento();
                        r.IdLotto = l.IdLotto;
                        r.IdDomandaPagamento = id;
                        r.DataInserimento = DateTime.Now;
                        r.DataModifica = DateTime.Now;
                        r.CfOperatore = lstValidatoriBandoRup.SelectedValue;
                        r.SelezionataXRevisione = true;
                        r.NumeroEstrazione = 1;
                        r.Ordine = counter;
                        r.SegnaturaRevisione = null;
                        r.SegnaturaSecondaRevisione = null;
                        revisione_provider.Save(r);
                        counter++;
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
    }
}