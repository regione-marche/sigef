using System;
using System.Web.UI.WebControls;
namespace web.Private.admin
{
    public partial class StepQuery : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "step_query";
            base.OnPreInit(e);
        }
        SiarBLL.ZquerySqlCollectionProvider zquery_provider;
        SiarLibrary.ZquerySqlCollection zquery_coll;
        SiarLibrary.ZquerySql zquery;
        protected void Page_Load(object sender, EventArgs e)
        {
            zquery_provider = new SiarBLL.ZquerySqlCollectionProvider();
            zquery_coll = new SiarLibrary.ZquerySqlCollection();
            zquery = new SiarLibrary.ZquerySql();
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    int id_zq;
                    tdDettaglioStep.Visible = true;
                    //ucSiarNewTab.Width = tdDettaglioStep.Width;
                    if (int.TryParse(hdnIdControllo.Value, out id_zq))
                    {
                        zquery = zquery_provider.GetById(id_zq);
                        txtNome.Text = zquery.Nome;
                        txtQueryLungaSQL.Text = zquery.Testo;
                        SiarLibrary.CheckListXStepCollection sc = new SiarBLL.CheckListXStepCollectionProvider().GetStepByCodiceQuery(zquery.Nome);
                        dgStepAssociati.DataSource = sc;
                        dgStepAssociati.DataBind();
                    }
                    break;
                default:
                    tdElencoStep.Visible = true;
                    //ucSiarNewTab.Width = tdElencoStep.Width;
                    zquery_coll = zquery_provider.Find("%" + txtFiltroNome.Text + "%");
                    dgControlli.DataSource = zquery_coll;
                    dgControlli.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgControlli_ItemDataBound);
                    dgControlli.DataBind();

                    break;
            }
            base.OnPreRender(e);
        }

        void dgControlli_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.ZquerySql zq = (SiarLibrary.ZquerySql)e.Item.DataItem;
                e.Item.Cells[2].Text = "<input type=button class='btn btn-secondary py-1' value='Seleziona' onclick=\"selezionaControllo('" + zq.Id + "');\" />";
            }
        }
        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtNome.Text)) throw new Exception("Inserire il Nome del controllo");
                if (int.TryParse(hdnIdControllo.Value, out id))
                    zquery = zquery_provider.GetById(id);
                else zquery = new SiarLibrary.ZquerySql();
                zquery.Nome = txtNome.Text;
                zquery.Testo = txtQueryLungaSQL.Text.Replace("`", "'");
                zquery_provider.Save(zquery);
                hdnIdControllo.Value = zquery.Id;
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
