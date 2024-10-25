using System;
using System.Web.UI.WebControls;

namespace web.Private.admin
{
    public partial class Comuni : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ComuniCollectionProvider comuni_provider = new SiarBLL.ComuniCollectionProvider();
        SiarLibrary.Comuni comune_selezionato;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gestione_comuni";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            int id_comune;
            if (int.TryParse(hdnIdComune.Value, out id_comune)) comune_selezionato = comuni_provider.GetById(id_comune);
        }
        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbRicerca.Visible = false;
                    lstProvince.DataBind();
                    if (comune_selezionato != null)
                    {
                        txtCodBelfiore.Text = comune_selezionato.CodBelfiore;
                        txtCodBelfiore.ReadOnly = true;
                        txtDenominazione.Text = comune_selezionato.Denominazione;
                        txtCap.Text = comune_selezionato.Cap;
                        lstProvince.SelectedValue = comune_selezionato.CodProvincia;
                        txtIstat.Text = comune_selezionato.Istat;
                        txtTipoArea.Text = comune_selezionato.TipoArea;
                        txtCodRubricaPaleo.Text = comune_selezionato.CodRubricaPaleo;
                        txtStatoComune.Text = comune_selezionato.Attivo ? "Attivo" : "Inattivo dal " + comune_selezionato.DataFineValidita;
                        SiarLibrary.ComuniCollection cc = comuni_provider.Find(comune_selezionato.CodBelfiore, null, null, null, null, null, null, null);
                        dgStoricoComune.DataSource = cc;
                        dgStoricoComune.Titolo = "Elementi trovati: " + cc.Count;
                    }
                    else dgStoricoComune.Titolo = "Selezionare un comune.";
                    dgStoricoComune.DataBind();
                    break;
                default:
                    tbDettaglio.Visible = false;
                    lstRProvince.DataBind();
                    string denominazione = null;
                    if (!string.IsNullOrEmpty(txtRDenominazione.Text)) denominazione = "%" + txtRDenominazione.Text + "%";
                    SiarLibrary.ComuniCollection comuni = comuni_provider.RicercaComune("GESTIONE", null, null, denominazione, lstRProvince.SelectedValue, null,
                        txtRCodBelfiore.Text, chkRAttivi.Checked);
                    dg.DataSource = comuni;
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.Titolo = "Elementi trovati: " + comuni.Count;
                    dg.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Comuni c = (SiarLibrary.Comuni)e.Item.DataItem;
                e.Item.Cells[5].Text = c.CodProvincia + c.Istat;
                //if (!c.Attivo)
                //{
                //    e.Item.Style.Add("background", "#CCCCCC");
                //    e.Item.Cells[2].Text = c.Denominazione; // elimino il link al dettaglio                    
                //}
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dg.SetPageIndex(0);
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                //if (comune_selezionato == null) throw new Exception("Non è stato selezionato nessun comune, impossibile continuare.");

                if (comune_selezionato != null)
                {
                    // storicizzo il record vecchio se è attivo
                    if (comune_selezionato.Attivo)
                    {
                        comune_selezionato.Attivo = false;
                        comune_selezionato.IdOperatoreFine = Operatore.Utente.IdUtente;
                        comune_selezionato.DataFineValidita = DateTime.Now;
                        comuni_provider.Save(comune_selezionato);
                    }
                    // lo ripulisco per reinserirlo
                    comune_selezionato.MarkAsNew();
                    comune_selezionato.IdOperatoreFine = null;
                    comune_selezionato.DataFineValidita = null;
                }
                else comune_selezionato = new SiarLibrary.Comuni();

                comune_selezionato.Denominazione = txtDenominazione.Text;
                comune_selezionato.Cap = txtCap.Text;
                comune_selezionato.CodProvincia = lstProvince.SelectedValue;
                comune_selezionato.Sigla = SiarLibrary.DbStaticProvider.GetSiglaProvinciaByCodice(lstProvince.SelectedValue, null);
                comune_selezionato.CodBelfiore = txtCodBelfiore.Text;
                comune_selezionato.Istat = txtIstat.Text;
                comune_selezionato.TipoArea = txtTipoArea.Text;
                comune_selezionato.CodRubricaPaleo = txtCodRubricaPaleo.Text;
                comune_selezionato.Attivo = true;
                comune_selezionato.DataInizioValidita = DateTime.Now;
                comune_selezionato.IdOperatoreInizio = Operatore.Utente.IdUtente;
                comuni_provider.Save(comune_selezionato);
                hdnIdComune.Value = comune_selezionato.IdComune;
                comune_selezionato = comuni_provider.GetById(comune_selezionato.IdComune);
                ShowMessage("Comune salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDisattiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (comune_selezionato == null) throw new Exception("Per proseguire è necessario selezionare un comune.");
                // storicizzo il record vecchio se è attivo
                if (comune_selezionato.Attivo)
                {
                    comune_selezionato.Attivo = false;
                    comune_selezionato.IdOperatoreFine = Operatore.Utente.IdUtente;
                    comune_selezionato.DataFineValidita = DateTime.Now;
                    comuni_provider.Save(comune_selezionato);
                }
                comune_selezionato = comuni_provider.GetById(comune_selezionato.IdComune);
                ShowMessage("Comune salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
