using System;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class ValidazioneLotti : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "selezione_domande_rendicontazione";
            base.OnPreInit(e);
        }

        SiarBLL.LottoDiRevisioneCollectionProvider lotto_provider = new SiarBLL.LottoDiRevisioneCollectionProvider();
        SiarBLL.TestataValidazioneCollectionProvider testata_validazione_provider;
        SiarLibrary.LottoDiRevisione lotto_selezionato;

        protected void Page_Load(object sender, EventArgs e)
        {
            AbilitaModifica = AbilitaModifica 
                && new SiarBLL.BandoValidatoriCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true).Count > 0;
            testata_validazione_provider = new SiarBLL.TestataValidazioneCollectionProvider(lotto_provider.DbProviderObj);
            int id_lotto;
            if (!IsPostBack && int.TryParse(Request.QueryString["idlt"], out id_lotto)) hdnIdLotto.Value = id_lotto.ToString();
            if (int.TryParse(hdnIdLotto.Value, out id_lotto)) lotto_selezionato = lotto_provider.GetById(id_lotto);
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstTipoPagamento.DataBind();
            SiarLibrary.LottoDiRevisioneCollection lotti;
            if (lotto_selezionato != null)
            {
                lotti = new SiarLibrary.LottoDiRevisioneCollection();
                lotti.Add(lotto_selezionato);
                ((SiarLibrary.Web.CheckColumn)dgLotti.Columns[9]).SetSelected(new string[] { lotto_selezionato.IdLotto });

                var domande = testata_validazione_provider.FindRevisione(lotto_selezionato.IdLotto, null, null, null, null, null, null, false);
                dgDomande.DataSource = domande;
                dgDomande.SetTitoloNrElementi();
                dgDomande.ItemDataBound += new DataGridItemEventHandler(dgDomande_ItemDataBound);
                dgDomande.DataBind();

                // abilita modifica controlli
                tabDomande.Visible = tdPulsanti.Visible = true;
                btnSelezioneDomande.Enabled = btnDel.Enabled = AbilitaModifica && !lotto_selezionato.RevisioneConclusa && lotto_selezionato.NumeroEstrazioni == 0;
                btnEstrai.Enabled = AbilitaModifica && !lotto_selezionato.RevisioneConclusa && lotto_selezionato.NumeroEstrazioni == 0 && domande.Count > 0;
                btnVerifica.Enabled = AbilitaModifica && !lotto_selezionato.RevisioneConclusa && lotto_selezionato.NumeroEstrazioni > 0;
            }
            else lotti = lotto_provider.Find(null, Bando.IdBando, null, null, null);
            dgLotti.DataSource = lotti;
            dgLotti.SetTitoloNrElementi();
            dgLotti.DataBind();
            base.OnPreRender(e);
        }

        void dgDomande_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var rev = (SiarLibrary.TestataValidazione)e.Item.DataItem;

                int id_domanda;
                if (int.TryParse(txtNumeroDomanda.Text, out id_domanda) 
                        && rev.IdProgetto == id_domanda 
                        && (string.IsNullOrEmpty(lstTipoPagamento.SelectedValue) || rev.CodTipo == lstTipoPagamento.SelectedValue))
                    e.Item.Cells[0].Style.Add("color", "#ff0000");  //System.Drawing.Color.FromArgb(220, 80, 80));

                if (rev.SelezionataXRevisione)
                {
                    e.Item.Cells[6].Text = "<input type=button onclick=\"location='RevisioneDomande.aspx?idpag=" + rev.IdDomandaPagamento
                        + "'\" value='Prosegui >>' style='width:130px' class='ButtonGrid'/>";
                }
            }
        }

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnFiltra_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                int.TryParse(txtNumeroDomanda.Text, out id_progetto);
                int id_lotto = lotto_provider.FiltroLottiRevisionePagamento(Bando.IdBando, id_progetto, lstTipoPagamento.SelectedValue);
                if (id_lotto > 0)
                {
                    hdnIdLotto.Value = id_lotto.ToString();
                    lotto_selezionato = lotto_provider.GetById(id_lotto);
                }
                else
                {
                    hdnIdLotto.Value = "";
                    lotto_selezionato = null;
                    ShowError("Nessun elemento trovato con i parametri selezionati.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAzzeraRicerca_Click(object sender, EventArgs e)
        {
            lstTipoPagamento.SelectedValue = txtNumeroDomanda.Text = hdnIdLotto.Value = "";
            dgLotti.SetPageIndex(0);
        }

        protected void btnCreaLotto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.LottoDiRevisione l = new SiarLibrary.LottoDiRevisione();
                l.IdBando = Bando.IdBando;
                l.Provincia = "AN";
                l.DataCreazione = DateTime.Now;
                l.DataModifica = DateTime.Now;
                l.CfOperatore = Operatore.Utente.CfUtente;
                l.NumeroEstrazioni = 0;
                l.RevisioneConclusa = false;
                lotto_provider.Save(l);
                lotto_selezionato = lotto_provider.GetById(l.IdLotto);
                hdnIdLotto.Value = l.IdLotto;
                int nr_domande = SelezioneDomandeXLotto();
                ShowMessage("Lotto di controllo creato correttamente, nr. " + nr_domande + " domande di pagamento associate.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSelezioneDomande_Click(object sender, EventArgs e)
        {
            try
            {
                int nr_domande = SelezioneDomandeXLotto();
                ShowMessage("Nr. " + nr_domande + " domande di pagamento associate al lotto selezionato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private int SelezioneDomandeXLotto()
        {
            if (lotto_selezionato == null)
            {
                throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");
            }
            return lotto_provider.SelezioneDomandeXLottoRevisione(lotto_selezionato.IdLotto, Operatore.Utente.CfUtente);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lotto_selezionato == null)
                {
                    throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");
                }
                if (!AbilitaModifica || lotto_selezionato.RevisioneConclusa || lotto_selezionato.NumeroEstrazioni > 0)
                {
                    throw new Exception("Il lotto di controllo selezionato non può essere eliminato.");
                }

                lotto_provider.DbProviderObj.BeginTran();
                testata_validazione_provider.DeleteCollection(testata_validazione_provider.FindRevisione(lotto_selezionato.IdLotto, null, null, null, null, null, null, false));
                lotto_provider.Delete(lotto_selezionato);
                lotto_provider.DbProviderObj.Commit();
                
                lotto_selezionato = null;
                hdnIdLotto.Value = "";
                ShowMessage("Lotto di controllo eliminato correttamente.");
            }
            catch (Exception ex) 
            { 
                lotto_provider.DbProviderObj.Rollback(); ShowError(ex); 
            }
        }

        protected void btnEstrai_Click(object sender, EventArgs e)
        {
            try
            {
                if (lotto_selezionato == null)
                {
                    throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");
                }
                if (!AbilitaModifica || lotto_selezionato.RevisioneConclusa || lotto_selezionato.NumeroEstrazioni > 0)
                {
                    throw new Exception("Non è possibire eseguire l'estrazione del campione per il lotto selezionato.");
                }
                int numero_estratte = lotto_provider.EstraiCampioneDomandeXRevisionePagamenti(lotto_selezionato.IdLotto, Operatore.Utente.CfUtente);
                
                lotto_selezionato.CfOperatore = Operatore.Utente.CfUtente;
                lotto_selezionato.NumeroEstrazioni = lotto_selezionato.NumeroEstrazioni + 1;
                lotto_selezionato.DataModifica = DateTime.Now;
                lotto_provider.Save(lotto_selezionato);
                lotto_selezionato.NumeroDomandeEstratte += numero_estratte;
                
                ShowMessage("Campione estratto correttamente: n." + numero_estratte.ToString() + " domande estratte.");
            }
            catch (Exception ex) 
            {
                ShowError(ex); 
            }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaLotto(false);
                ShowMessage("I controlli di validazione del lotto sono completi, ora è possibile creare l'elenco di pagamento.");
                btnChiudiControllo.Enabled = true;
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        private void VerificaLotto(bool chiudi_lotto)
        {
            if (lotto_selezionato == null)
            {
                throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");
            }
            if (!AbilitaModifica || lotto_selezionato.RevisioneConclusa)
            {
                throw new Exception("Il lotto di controllo selezionato non è valido.");
            }
            int esito = lotto_provider.VerificaCompletamentoRevisione(lotto_selezionato.IdLotto);
            if (esito > 0)
            {
                throw new Exception("Controllo non ancora concluso: risultano ancora " + esito + " domande da validare.");
            }

            lotto_selezionato.RevisioneConclusa = chiudi_lotto;
            lotto_selezionato.DataModifica = DateTime.Now;
            lotto_selezionato.CfOperatore = Operatore.Utente.CfUtente;
            lotto_provider.Save(lotto_selezionato);
        }

        protected void btnChiudiControllo_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaLotto(true);
                ShowMessage("I controlli di validazione del lotto sono completi, ora è possibile mandare le domande in pagamento.");
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }
    }
}
