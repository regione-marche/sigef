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

namespace web.Private.Controlli
{
    public partial class ParametriRischio : SiarLibrary.Web.ControlliLocoPage
    {
        SiarBLL.ControlliParametriDiRischioCollectionProvider parametri_provider = new SiarBLL.ControlliParametriDiRischioCollectionProvider();

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
            const int colAssPunt  = 2,
                      colModifica = 3,
                      colElimina  = 4;
            
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                if (AbilitaModifica)
                {
                    DataGridItem dgi = (DataGridItem)e.Item;
                    SiarLibrary.ControlliParametriDiRischio param = (SiarLibrary.ControlliParametriDiRischio)dgi.DataItem;
                    if (param.Manuale)
                    {
                        dgi.Cells[colAssPunt].Text = "Manuale";
                    }
                    else
                    {
                        dgi.Cells[colAssPunt].Text = "Automatica";
                    }
                    dgi.Cells[colModifica].Text = "<input type='button' class='ButtonGrid' onclick=\"modificaParametro(" + 
                                                  param.IdParametro + 
                                                  ")\" style='width:100px' value='Modifica' />";
                    dgi.Cells[colElimina].Text = "<input type='button' class='ButtonGrid' onclick=\"eliminaParametro(" + 
                                                 param.IdParametro + 
                                                 ")\" style='width:100px' value='Elimina' />";
                }
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SiarLibrary.ControlliParametriDiRischio param;
            int id_parametro;
            string url = "Parametro inserito correttamente.";

            try
            {
                if (int.TryParse(hdnIdParametro.Text, out id_parametro))
                {
                    param = parametri_provider.GetById(id_parametro);
                    if (new SiarBLL.ControlliParametriXDomandaCollectionProvider().Find(null, param.IdParametro, null, null).Count > 0)
                    {
                        throw new Exception("Impossibile modificare il parametro perchè utilizzato in un lotto di controllo.");
                    }
                    url = "Parametro modificato correttamente.";
                }
                else
                {
                    param = new SiarLibrary.ControlliParametriDiRischio();
                }

                param.Descrizione = txtDescrizione.Text;
                param.Manuale = chkManuale.Checked;
                //param.Peso = txtPeso.Text;
                parametri_provider.Save(param);
                hdnIdParametro.Text = param.IdParametro;
                ShowMessage(url);
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            int id_parametro;

            if (!int.TryParse(hdnIdParametro.Text, out id_parametro))
            {
                ShowError("Parametro inesistente. Impossibile continuare.");
                return;
            }

            try
            {
                SiarLibrary.ControlliParametriDiRischio param = parametri_provider.GetById(id_parametro);
                if (param == null)
                {
                    ShowError("Parametro inesistente. Impossibile continuare.");
                    return;
                }
                txtDescrizione.Text = param.Descrizione;
                //txtPeso.Text = param.Peso;
                txtQueryParametro.Text = param.QuerySql;
                chkManuale.Checked = param.Manuale;
                
                ShowMessage("Parametro caricato correttamente e pronto per la modifica.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            int id_parametro;

            try
            {
                if (!int.TryParse(hdnIdParametro.Text, out id_parametro))
                {
                    ShowError("Parametro inesistente. Impossibile continuare.");
                    return;
                }

                SiarLibrary.ControlliParametriDiRischio param = parametri_provider.GetById(id_parametro);
                if (param == null)
                {
                    ShowError("Parametro inesistente. Impossibile continuare.");
                    return;
                }

                if (new SiarBLL.ControlliParametriXLottoCollectionProvider().Find(null, param.IdParametro, null, null).Count > 0)
                {
                    throw new Exception("Impossibile eliminare il parametro perchè utilizzato in un lotto di controllo.");
                }
                parametri_provider.Delete(param);
                ShowMessage("Parametro eliminato correttamente.");

                hdnIdParametro.Text = null;
                txtQueryParametro.Text = null;
                txtDescrizione.Text = null;
                chkManuale.Checked = false;
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }
    }
}