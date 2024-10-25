using System;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;


namespace web.Private.regione
{
    public partial class Allegati : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.AllegatiCollectionProvider allegati_provider = new SiarBLL.AllegatiCollectionProvider();
        SiarLibrary.Allegati allegato_selezionato = null;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Allegati";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_allegato;
            if (int.TryParse(hdnIdAllegato.Value, out id_allegato))
                allegato_selezionato = allegati_provider.GetById(id_allegato);
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbDettaglio.Visible = true;
                    lstTipoAllegato.DataBind();
                    lstTipoAllegato.Attributes.Add("onchange", "checkEnteEmettitore(this);");
                    //ucSiarNewTab.Width = tbDettaglio.Width;
                    if (allegato_selezionato != null)
                    {
                        txtMisura.Text = allegato_selezionato.Misura;
                        txtDescrizione.Text = allegato_selezionato.Descrizione;
                        lstTipoAllegato.SelectedValue = allegato_selezionato.CodTipo;
                        lstTipoEnte.Enabled = allegato_selezionato.CodTipo == "S";
                        lstTipoEnte.SelectedValue = allegato_selezionato.CodTipoEnteEmettitore;
                    }
                    break;
                default:
                    tbElenco.Visible = true;
                    //ucSiarNewTab.Width = tbElenco.Width;

                    lstCercaTipoDocumento.DataBind();
                    string misura = null;
                    string descrizione = null;
                    if (!string.IsNullOrEmpty(txtCercaMisura.Text)) misura = txtCercaMisura.Text + "%";
                    if (!string.IsNullOrEmpty(txtCercaDescrizione.Text)) descrizione = "%" + txtCercaDescrizione.Text + "%";
                    SiarLibrary.AllegatiCollection allcoll = allegati_provider.Find(lstCercaTipoDocumento.SelectedValue, descrizione, misura);
                    dg.DataSource = allcoll;
                    dg.Titolo = "Elementi trovati: " + allcoll.Count;
                    dg.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null) allegato_selezionato = new SiarLibrary.Allegati();
                else if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(allegato_selezionato.IdAllegato, null, null).Count > 0)
                    throw new Exception("Non è possibile modificare l'allegato selezionato perché già utilizzato nei bandi.");
                if (string.IsNullOrEmpty(lstTipoAllegato.SelectedValue)) throw new Exception("E' obbligatorio specificare il tipo di documento.");
                if (lstTipoAllegato.SelectedValue == "C") throw new Exception("Il tipo di documento selezionato non è più valido.");
                else if (lstTipoAllegato.SelectedValue == "S" && string.IsNullOrEmpty(lstTipoEnte.SelectedValue))
                    throw new Exception("Per le dichiarazioni sostitutive è necessario specificare la categoria di ente emettitore del documento.");
                allegato_selezionato.Misura = txtMisura.Text;
                allegato_selezionato.Descrizione = txtDescrizione.Text;
                allegato_selezionato.CodTipo = lstTipoAllegato.SelectedValue;
                if (allegato_selezionato.CodTipo == "S") allegato_selezionato.CodTipoEnteEmettitore = lstTipoEnte.SelectedValue;
                allegati_provider.Save(allegato_selezionato);
                ShowMessage("Allegato salvato correttamente.");
                hdnIdAllegato.Value = allegato_selezionato.IdAllegato;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null) throw new Exception("Nessun allegato selezionato, impossibile continuare.");
                if (new SiarBLL.AllegatiXDomandaCollectionProvider().Find(allegato_selezionato.IdAllegato, null, null).Count > 0)
                    throw new Exception("Non è possibile eliminare l'allegato selezionato perché già utilizzato nei bandi.");
                allegati_provider.Delete(allegato_selezionato);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
                allegato_selezionato = null;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e) { }
    }
}
