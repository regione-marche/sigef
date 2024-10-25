using System;
using System.Web.UI.WebControls;

namespace web.Private.regione
{
    public partial class Priorita : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.PrioritaCollectionProvider prioritaProvider = new SiarBLL.PrioritaCollectionProvider();
        SiarBLL.ValoriPrioritaCollectionProvider valoriprovider = new SiarBLL.ValoriPrioritaCollectionProvider();
        int id_priorita, id_valore_priorita;
        #region Page Events

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "catalogo_priorita";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbNuovaPriorita.Visible = true;
                    //ucSiarNewTab.Width = tbNuovaPriorita.Width;
                    lstLivPriorita.DataBind();
                    if (!string.IsNullOrEmpty(hdnIdPriorita.Value) && !int.TryParse(hdnIdPriorita.Value, out id_priorita)) ShowError("La priorita selezionata non è valida. Impossibile continuare.");
                    else
                    {
                        SiarLibrary.Priorita priorita = prioritaProvider.GetById(id_priorita);
                        SiarLibrary.SchedaXPrioritaCollection schedaXprioColl = new SiarBLL.SchedaXPrioritaCollectionProvider().Find(null, id_priorita, null, null, null);
                        if (schedaXprioColl.Count > 0)
                        {
                            AbilitaModifica = false;
                            ShowMessage("Impossibile modificare la priorita poichè è stata associata alla scheda di valutazione.");
                        }
                        btnSalva.Enabled = AbilitaModifica;
                        SiarLibrary.ValoriPrioritaCollection valoricoll = new SiarLibrary.ValoriPrioritaCollection();
                        if (priorita != null) valoricoll = valoriprovider.Find(null, priorita.IdPriorita, null);
                        btnEliminaPriorita.Enabled = btnAssociaValoreMultiplo.Enabled = btnSalvaQueryPlurivalore.Enabled = AbilitaModifica && priorita != null;
                        btnEliminaValore.Enabled = AbilitaModifica && !string.IsNullOrEmpty(hdnIdValoreMultiplo.Value);

                        if (cbPlurivalore.Checked) TABLE4.Visible = true;
                        if (cbPlurivaloreQuery.Checked) tablePlurivaloreDinamico.Visible = true;
                        dgValoriMultipli.DataSource = valoricoll;
                        dgValoriMultipli.DataBind();

                    }
                    break;

                default:
                    tbPriorita.Visible = true;
                    //ucSiarNewTab.Width = tbPriorita.Width;
                    hdnIdPriorita.Value = string.Empty;
                    hdnIdValoreMultiplo.Value = string.Empty;
                    string ricerca_descrizione = (!string.IsNullOrEmpty(txtFiltroDescrizione.Text) ? "%" + txtFiltroDescrizione.Text + "%" : null),
                           ricerca_misura = (!string.IsNullOrEmpty(txtFiltroMisura.Text) ? "%" + txtFiltroMisura.Text + "%" : null);
                    SiarLibrary.PrioritaCollection prioritaColl = prioritaProvider.Find(null, null, null, null, null, null, null, ricerca_descrizione, ricerca_misura);
                    dgPriorita.Titolo = "Elementi trovati: " + prioritaColl.Count;
                    dgPriorita.DataSource = prioritaColl;
                    dgPriorita.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        #endregion
        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
            if (!int.TryParse(hdnIdPriorita.Value, out id_priorita)) ShowError("La priorita selezionata non è valida. Impossibile continuare.");
            SiarLibrary.Priorita priorita = prioritaProvider.GetById(id_priorita);
            if (priorita != null)
            {
                txtDescrizionePrioritaMedia.Text = priorita.Descrizione;
                txtMisura.Text = priorita.Misura;
                txtQueryLungaSQL.Text = priorita.Eval;
                lstLivPriorita.SelectedValue = priorita.CodLivello;
                cbPlurivalore.Checked = priorita.PluriValore;
                cbManuale.Checked = priorita.FlagManuale;
                cbNumerico.Checked = priorita.InputNumerico;
                cbDatetime.Checked = priorita.Datetime;
                cbTestoSemplice.Checked = priorita.TestoSemplice;
                cbTestoArea.Checked = priorita.TestoArea;
                cbPlurivaloreQuery.Checked = priorita.PluriValoreSql;
                txtQueryPlurivalore.Text = priorita.QueryPlurivalore;
            }
        }

        protected void btnEditPlurivalore_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(hdnIdValoreMultiplo.Value, out id_valore_priorita)) ShowError("Il valore selezionat non è valido. Impossibile continuare.");
            SiarLibrary.ValoriPriorita valpriorita = new SiarBLL.ValoriPrioritaCollectionProvider().GetById(id_valore_priorita);
            if (valpriorita != null)
            {
                txtdescValoreMultiplo.Text = valpriorita.Descrizione;
                txtCodiceValoreMupltiplo.Text = valpriorita.Codice;
                txtPunteggioPluri.Text = valpriorita.Punteggio;
            }
        }

        #region BL Methods

        /// <summary>
        /// Predispone per l'inserimento di una nuova priorità
        /// </summary>
        private void NewPriorita()
        {
            txtDescrizionePrioritaMedia.Text = string.Empty;
            txtQueryLungaSQL.Text = string.Empty;
            hdnIdPriorita.Value = string.Empty;
            txtMisura.Text = string.Empty;
            lstLivPriorita.SelectedValue = "";
            cbPlurivalore.Checked = false;
            cbManuale.Checked = false;
            cbNumerico.Checked = false;
            cbDatetime.Checked = false;
            cbTestoSemplice.Checked = false;
            cbTestoArea.Checked = false;
            cbPlurivaloreQuery.Checked = false;

            TABLE4.Visible = false;
            tablePlurivaloreDinamico.Visible = false;
            btnEliminaPriorita.Enabled = false;
        }
        private void DeletePriorita(SiarLibrary.NullTypes.IntNT ID_Priorita)
        {
            try
            {
                // 1. Controllo se la priorità è associata ad una scheda di valutazione
                SiarBLL.SchedaXPrioritaCollectionProvider schedaXPrioritaCollectionProvider = new SiarBLL.SchedaXPrioritaCollectionProvider();
                SiarLibrary.SchedaXPrioritaCollection schedaXPrioritaCollection = schedaXPrioritaCollectionProvider.Find(null, ID_Priorita, null, null, null);

                if (schedaXPrioritaCollection.Count > 0) throw new Exception("Questa priorità è associata ad almeno una scheda di valutazione. Impossibile eliminare la priorità.");
                prioritaProvider.DbProviderObj.BeginTran();
                valoriprovider = new SiarBLL.ValoriPrioritaCollectionProvider(prioritaProvider.DbProviderObj);
                valoriprovider.DeleteCollection(valoriprovider.Find(null, ID_Priorita, null));
                prioritaProvider.Delete(prioritaProvider.GetById(ID_Priorita));
                prioritaProvider.DbProviderObj.Commit();
                ShowMessage("Priorità eliminata correttamente.");
                NewPriorita();
            }
            catch (Exception ex) { ShowError(ex); prioritaProvider.DbProviderObj.Rollback(); }
            finally { ucSiarNewTab.TabSelected = 1; }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Priorita priorita = new SiarLibrary.Priorita();
                if (!string.IsNullOrEmpty(hdnIdPriorita.Value))
                {
                    if (!int.TryParse(hdnIdPriorita.Value, out id_priorita)) ShowError("La priorita selezionata non è valida. Impossibile continuare.");
                    priorita = prioritaProvider.GetById(id_priorita);
                }

                priorita.CodLivello = lstLivPriorita.SelectedValue;
                priorita.Misura = txtMisura.Text;
                priorita.Descrizione = txtDescrizionePrioritaMedia.Text;
                priorita.PluriValore = cbPlurivalore.Checked;
                priorita.FlagManuale = cbManuale.Checked;
                priorita.InputNumerico = cbNumerico.Checked;
                priorita.Datetime = cbDatetime.Checked;
                priorita.TestoSemplice = cbTestoSemplice.Checked;
                priorita.TestoArea = cbTestoArea.Checked;
                priorita.PluriValoreSql = cbPlurivaloreQuery.Checked;

                priorita.Eval = txtQueryLungaSQL.Text.Replace("`", "\'");
                prioritaProvider.Save(priorita);
                hdnIdPriorita.Value = priorita.IdPriorita.Value.ToString();
                ShowMessage("Priorità salvata correttamente.");

            }
            catch (Exception ex) { ShowError(ex.Message, ex.ToString()); }
        }
        protected void NewPrioritySB_Click(object sender, EventArgs e)
        {
            NewPriorita();
        }

        protected void btnEliminaPriorita_Click(object sender, EventArgs e)
        {
            DeletePriorita(hdnIdPriorita.Value);
        }

        #endregion
        protected void btnAssociaValoreMultiplo_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.ValoriPriorita valoripri;
                if (!int.TryParse(hdnIdPriorita.Value, out id_priorita)) throw new Exception("La priorita selezionata non è valida. Impossibile continuare.");
                if (string.IsNullOrEmpty(hdnIdValoreMultiplo.Value))
                {
                    valoripri = new SiarLibrary.ValoriPriorita();
                    valoripri.IdPriorita = id_priorita;
                }
                else
                {
                    if (!int.TryParse(hdnIdValoreMultiplo.Value, out id_valore_priorita)) throw new Exception("Il plurivalore selezionato non è corretto. Impossibile continuare.");
                    else valoripri = valoriprovider.GetById(id_valore_priorita);
                }

                valoripri.Descrizione = txtdescValoreMultiplo.Text;
                valoripri.Codice = txtCodiceValoreMupltiplo.Text;
                valoripri.Punteggio = txtPunteggioPluri.Text;
                valoriprovider.Save(valoripri);
                ShowMessage("Salvataggio completato correttamente");
                btnNewValoriMultiplo_Click(sender, e);
            }
            catch (Exception ex) { ShowError(ex); }
        }
        protected void btnNewValoriMultiplo_Click(object sender, EventArgs e)
        {
            hdnIdValoreMultiplo.Value = string.Empty;
            txtCodiceValoreMupltiplo.Text = string.Empty;
            txtdescValoreMultiplo.Text = string.Empty;
            txtPunteggioPluri.Text = string.Empty;
        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(hdnIdValoreMultiplo.Value, out id_valore_priorita)) ShowError("Il plurivalore selezionato non è valido. Impossibile continuare.");
                valoriprovider.Delete(valoriprovider.GetById(id_valore_priorita));
                ShowMessage("Eliminazione eseguita correttamente");
            }
            catch (Exception ex) { ShowError(ex); }
            finally
            {
                hdnIdValoreMultiplo.Value = string.Empty;
                txtCodiceValoreMupltiplo.Text = string.Empty;
                txtdescValoreMultiplo.Text = string.Empty;
                txtPunteggioPluri.Text = string.Empty;
            }
        }

        protected void btnSalvaQueryPlurivalore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(hdnIdPriorita.Value, out id_priorita)) throw new Exception("La priorita selezionata non è valida. Impossibile continuare.");
                SiarLibrary.Priorita p = prioritaProvider.GetById(id_priorita);
                p.QueryPlurivalore = txtQueryPlurivalore.Text.Replace("`", "\'");
                prioritaProvider.Save(p);
                ShowMessage("Query salvata correttamente");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
