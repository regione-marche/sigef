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

namespace web.Private.admin
{
    public partial class RicercaFiltroChecklistVoce : FiltroChecklistVoceClassPage
    {
        FiltroChecklistVoceCollectionProvider filtri_provider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            InizializzaProvider();

            CaricaFiltri();

            base.OnPreRender(e);
        }

        private void InizializzaProvider()
        {
            filtri_provider = new FiltroChecklistVoceCollectionProvider();
        }

        private void CaricaFiltri()
        {
            var filtri_coll = filtri_provider.FindFiltro(null, null, null);

            if (filtri_coll.Count > 0)
            {
                lblNumFiltri.Text = string.Format("Visualizzate {0} righe", filtri_coll.Count.ToString());

                dgFiltri.DataSource = filtri_coll;
                dgFiltri.ItemDataBound += new DataGridItemEventHandler(dgFiltri_ItemDataBound);
                dgFiltri.DataBind();
            }
            else
            {
                lblNumFiltri.Text = "Nessun filtro trovato";
            }
        }

        #region ButtonClick

        protected void btnInserisciFiltro_Click(object sender, EventArgs e)
        {
            InizializzaProvider();

            try
            {
                FiltroChecklistVoce = null;
                Redirect(PATH_ADMIN + "FiltroChecklistVocePage.aspx");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSelezionaFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdFiltro.Value != null && hdnIdFiltro.Value != "")
                {
                    string id_filtro = hdnIdFiltro.Value;
                    var filtro = new FiltroChecklistVoceCollectionProvider().FindFiltro(id_filtro, null, null);

                    FiltroChecklistVoce = filtro.Count > 0 ? filtro[0] : throw new Exception("Filtro non esistente");
                    Redirect(PATH_ADMIN + "FiltroChecklistVocePage.aspx");
                }
                else
                    throw new Exception("Voce checklist generica non selezionata");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        #endregion

        #region ItemDataBound

        void dgFiltri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int col_IdFiltro = 0,
                col_Descrizione = 1,
                col_Ordine = 2,
                col_Seleziona = 3;

            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var filtro = (FiltroChecklistVoce)dgi.DataItem;
            }
        }

        #endregion
    }
}