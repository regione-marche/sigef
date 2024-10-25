using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace web.Private.CertificazioneSpesa
{
    public partial class ParametriRischio : SiarLibrary.Web.CertificazioneSpesaPage
    {
        SiarBLL.CertspParametriDiRischioCollectionProvider parametri_provider = new SiarBLL.CertspParametriDiRischioCollectionProvider();

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            dgParametri.DataSource = parametri_provider.Find(null, null, null);
            dgParametri.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgParametri.DataSource).Count.ToString();
            dgParametri.ItemDataBound += new DataGridItemEventHandler(dgParametri_ItemDataBound);
            dgParametri.DataBind();
            base.OnPreRender(e);
        }

        void dgParametri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                if (AbilitaModifica)
                {
                    DataGridItem dgi = (DataGridItem)e.Item;
                    SiarLibrary.CertspParametriDiRischio param = (SiarLibrary.CertspParametriDiRischio)dgi.DataItem;
                    if (param.Manuale) dgi.Cells[2].Text = "Manuale";
                    else dgi.Cells[2].Text = "Automatica";
                    dgi.Cells[3].Text = "<input type='button' class='ButtonGrid' onclick=\"modificaParametro(" + param.Id
                        + ")\" style='width:100px' value='Modifica' />";
                    dgi.Cells[4].Text = "<input type='button' class='ButtonGrid' onclick=\"eliminaParametro(" + param.Id
                        + ")\" style='width:100px' value='Elimina' />";
                }
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.CertspParametriDiRischio param;
                int id_parametro;
                string url = "Parametro inserito correttamente.";
                if (int.TryParse(hdnIdParametro.Text, out id_parametro))
                {
                    param = parametri_provider.GetById(id_parametro);
                    if (new SiarBLL.CertspParametriXDomandaCollectionProvider().Find(null, param.Id, null, null).Count > 0)
                        throw new Exception("Impossibile modificare il parametro perchè utilizzato in un lotto di controllo.");
                    url = "Parametro modificato correttamente.";
                }
                else param = new SiarLibrary.CertspParametriDiRischio();
                param.Descrizione = txtDescrizione.Text;
                param.Manuale = chkManuale.Checked;
                //param.Peso = txtPeso.Text;
                parametri_provider.Save(param);
                hdnIdParametro.Text = param.Id;
                ShowMessage(url);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            int id_parametro;
            if (int.TryParse(hdnIdParametro.Text, out id_parametro))
            {
                try
                {
                    SiarLibrary.CertspParametriDiRischio param = parametri_provider.GetById(id_parametro);
                    if (param != null)
                    {
                        txtDescrizione.Text = param.Descrizione;
                        //txtPeso.Text = param.Peso;
                        txtQueryParametro.Text = param.QuerySql;
                        chkManuale.Checked = param.Manuale;
                        ShowMessage("Parametro caricato correttamente e pronto per la modifica.");
                    }
                    else ShowError("Parametro inesistente. Impossibile continuare.");
                }
                catch (Exception ex) { ShowError(ex); }
            }
            else ShowError("Parametro inesistente. Impossibile continuare.");

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_parametro;
                if (int.TryParse(hdnIdParametro.Text, out id_parametro))
                {
                    SiarLibrary.CertspParametriDiRischio param = parametri_provider.GetById(id_parametro);
                    if (param != null)
                    {
                        if (new SiarBLL.CertspParametriXLottoCollectionProvider().Find(null, param.Id, null, null).Count > 0)
                            throw new Exception("Impossibile eliminare il parametro perchè utilizzato in un lotto di controllo.");
                        parametri_provider.Delete(param);
                        ShowMessage("Parametro eliminato correttamente.");
                    }
                    else ShowError("Parametro inesistente. Impossibile continuare.");
                }
                else ShowError("Parametro inesistente. Impossibile continuare.");
                hdnIdParametro.Text = null;
                txtQueryParametro.Text = null;
                txtDescrizione.Text = null;
                chkManuale.Checked = false;
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
