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
    public partial class RicercaRevoche : RevochePage
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
            RevocaCollectionProvider revocaProvider = new RevocaCollectionProvider();
            RevocaCollection revocaCollection = new RevocaCollection();
            int? id_progetto = null;
            if (txtIdProgettoF.Text != null && txtIdProgettoF.Text != "")
                id_progetto = Convert.ToInt32(txtIdProgettoF.Text);
            revocaCollection = revocaProvider.Find(null, id_progetto, null);
            dgRevoche.DataSource = revocaCollection;
            dgRevoche.ItemDataBound += new DataGridItemEventHandler(dgRevoche_ItemDataBound);
            dgRevoche.DataBind();
            if (revocaCollection.Count == 0)
                lblNumRevoche.Text = "Non ci sono revoche da visualizzare";
            else
                lblNumRevoche.Text = "Revoche visualizzate: " + revocaCollection.Count.ToString();
        }

        protected void btnVisualizzaRevoca_Click(object sender, EventArgs e)
        {
            try
            {
                RevocaCollectionProvider revocaCollectionProvider = new RevocaCollectionProvider();
                int idRevoca;
                if (int.TryParse(hdnIdRevoca.Value, out idRevoca))
                {
                    var revoca = revocaCollectionProvider.GetById(idRevoca);
                    Session["_revoca"] = revoca;

                    Redirect(PATH_CONTROLLI + "Revoche.aspx");
                }
                else
                    throw new Exception("Nessuna revoca selezionata.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        protected void btnNuovaRevoca_Click(object sender, EventArgs e)
        {
            Session["_revoca"] = null;
            Session["_progetto"] = null;
            Redirect(PATH_CONTROLLI + "Revoche.aspx");

        }

        protected void btnFiltra_Click(object sender, EventArgs e) { dgRevoche.SetPageIndex(0); }

        void dgRevoche_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {

                var revoca = (Revoca)e.Item.DataItem;
                SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();
                ImpresaCollectionProvider impresaCollectionProvider = new ImpresaCollectionProvider();
                impresa = impresaCollectionProvider.GetById(int.Parse(dgi.Cells[2].Text));
                dgi.Cells[2].Text = impresa.RagioneSociale;
            }
        }
    }
}