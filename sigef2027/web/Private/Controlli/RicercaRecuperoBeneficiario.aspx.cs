using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using SiarLibrary.NullTypes;

namespace web.Private.Controlli
{
    public partial class RicercaRecuperoBeneficiario : RecuperoBeneficiarioPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            CaricaRevoche();
            base.OnPreRender(e);
        }

        private void CaricaRevoche()
        {
            RecuperoBeneficiarioCollectionProvider recuperoProvider = new RecuperoBeneficiarioCollectionProvider();
            RecuperoBeneficiarioCollection recuperoCollection = new RecuperoBeneficiarioCollection();
            recuperoCollection = recuperoProvider.Find(null, null, null, null, null, null);
            dgRecuperi.DataSource = recuperoCollection;
            dgRecuperi.ItemDataBound += new DataGridItemEventHandler(dgRevoche_ItemDataBound);
            dgRecuperi.DataBind();
            if (recuperoCollection.Count == 0)
                lblNumRecuperi.Text = "Non ci sono recuperi da visualizzare";
            else
                lblNumRecuperi.Text = "Revoche visualizzate: " + recuperoCollection.Count.ToString();
        }

        protected void btnVisualizzaRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperoBeneficiarioCollectionProvider recuperoProvider = new RecuperoBeneficiarioCollectionProvider();
                int idRecupero;
                if (int.TryParse(hdnIdRecupero.Value, out idRecupero))
                {
                    var recupero = recuperoProvider.GetById(idRecupero);
                    Session["_recuperoBeneficiario"] = recupero;

                    Redirect(PATH_CONTROLLI + "RecuperoBeneficiario.aspx");
                }
                else
                    throw new Exception("Nessuna revoca selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        protected void btnNuovoRecupero_Click(object sender, EventArgs e)
        {
            Session["_recuperoBeneficiario"] = null;
            Session["_progetto"] = null;
            Redirect(PATH_CONTROLLI + "RecuperoBeneficiario.aspx");
        }

        void dgRevoche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var recupero = (SiarLibrary.RecuperoBeneficiario)e.Item.DataItem;
                SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();
                ImpresaCollectionProvider impresaCollectionProvider = new ImpresaCollectionProvider();
                impresa = impresaCollectionProvider.GetById(int.Parse(dgi.Cells[2].Text));
                dgi.Cells[2].Text = impresa.RagioneSociale;
                if (recupero.Definitivo != null)
                    if (recupero.Definitivo)
                        dgi.Cells[3].Text = dgi.Cells[3].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[3].Text = dgi.Cells[3].Text.Replace("checked", "");
            }
        }
    }
}