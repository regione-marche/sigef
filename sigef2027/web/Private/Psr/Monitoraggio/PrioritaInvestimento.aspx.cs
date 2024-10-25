using System;
using System.Web.UI.WebControls;
using SiarBLL;
using System.Data;
using System.Data.SqlClient;

namespace web.Private.Psr.Programmazione
{
    public partial class PrioritaInvestimento : SiarLibrary.Web.PrivatePage
    {
        const int    chkbox_pro = 4;
        const int    chkbox_pi = 3;
        const string _codDim   = "PI";

        // ZProgrammazione
        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.Zprogrammazione prog_selezionata = null;
        
        // zDimensioni (Solo per priorità investimento)
        SiarBLL.ZdimensioniCollectionProvider dim_provider = new ZdimensioniCollectionProvider();
        SiarLibrary.Zdimensioni dim_selezionata = null;
        
        // zDimensioni_X_Programmazione
        SiarBLL.ZdimensioniXProgrammazioneCollectionProvider dxp_provider = new SiarBLL.ZdimensioniXProgrammazioneCollectionProvider();
        SiarLibrary.ZdimensioniXProgrammazione dxp_selezionata = new SiarLibrary.ZdimensioniXProgrammazione(); 


        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "psr_mon_prioritaInv";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenFields_Valorizza();
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                // dgPI
                SiarLibrary.ZdimensioniCollection dims;
                
                if (dim_selezionata != null)
                {
                    dims = new SiarLibrary.ZdimensioniCollection();
                    dims.Add(dim_selezionata);
                }
                else
                {
                    dims = dim_provider.GetByCodDim(_codDim);
                }

                if (dims.Count == 0)
                {
                    dgPI.Titolo = "Nessuna dimensione di tipo 'PI' disponibile";
                }
                else
                {
                    dgPI.Titolo = "Selezionare la Priorità di Investimento";
                    dgPI.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgPI_ItemDataBound);
                }
                dgPI.DataSource = dims;
                dgPI.DataBind();


                // dgProgrammazione
                SiarLibrary.ZdimensioniXProgrammazioneCollection dxps = null;
                if (dims.Count == 1)
                {
                    dxps = dxp_provider.GetByCodPsr(lstPsr.SelectedValue, dim_selezionata.Id);
                    dgProgrammazione.Titolo = "Selezionare l`elemento di programmazione da colleagare alla Priorità di Investimento";
                    dgProgrammazione.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgProgrammazione_ItemDataBound);
                    tbDettaglio.Visible = true;
                }
                else
                {
                    hdnIdProgrammazione.Value = null;
                    tbDettaglio.Visible = false;
                }

                dgProgrammazione.DataSource = dxps;
                dgProgrammazione.DataBind();
            }

            base.OnPreRender(e);
        }


        private void HiddenFields_Valorizza()
        {
            // hdnIdProgrammazione
            int id_programmazione;
            if (int.TryParse(hdnIdProgrammazione.Value, out id_programmazione))
            {
                prog_selezionata = prog_provider.GetById(id_programmazione);
            }

            // hdnPI
            int id_dimensione;
            if (int.TryParse(hdnPI.Value, out id_dimensione))
            {
                dim_selezionata = dim_provider.GetById(id_dimensione);
            }
        }


        #region Eventi griglia

        void dgPI_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (dim_selezionata != null)
                {
                    SiarLibrary.Zdimensioni d = (SiarLibrary.Zdimensioni)e.Item.DataItem;
                    if (d.Id == dim_selezionata.Id)
                    {
                        e.Item.Cells[chkbox_pi].Text = e.Item.Cells[chkbox_pi].Text.Replace("<input ", "<input checked ");
                    }
                }
                else
                {
                    e.Item.Cells[chkbox_pi].Text = e.Item.Cells[chkbox_pi].Text.Replace("checked", "");
                }
            }
        }

        void dgProgrammazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    SiarLibrary.ZdimensioniXProgrammazione dxp = (SiarLibrary.ZdimensioniXProgrammazione)e.Item.DataItem;
                    if (dxp.IdDimXProgrammazione != null)
                    {
                        e.Item.Cells[chkbox_pro].Text = e.Item.Cells[chkbox_pro].Text.Replace("<input ", "<input checked ");
                    }
                }
            }
        }

        #endregion


        #region Button event

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            Salva();
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {
        }

        #endregion


        #region Salva / Cancella
        
        private void Salva()
        {
            // Cancellazione delle registrazione legate a :
            // - Programmazione selezionta
            // - Dimensione selezionta

            SiarLibrary.ZdimensioniXProgrammazione dxpnew;
            dxp_provider.DbProviderObj.BeginTran();
            try
            {
                dxp_provider.DeleteByCodPsr(lstPsr.SelectedValue, dim_selezionata.Id);


                string[] proSel = ((SiarLibrary.Web.CheckColumnAgid)dgProgrammazione.Columns[chkbox_pro]).GetSelected();
                foreach (string p in proSel)
                {
                    int idprog;
                    int iddim;

                    dxpnew = new SiarLibrary.ZdimensioniXProgrammazione();
                    iddim = dim_selezionata.Id;

                    if (int.TryParse(p, out idprog))
                    {
                        dxpnew.IdProgrammazione = idprog;
                        dxpnew.IdDimensione = iddim;
                        dxpnew.MarkAsNew();

                        dxp_provider.Save(dxpnew);
                    }
                }
                dxp_provider.DbProviderObj.Commit();
                ShowMessage("Dati salvati correttamente.");
            }
            catch
            {
                dxp_provider.DbProviderObj.Rollback();
                ShowError("Errore nel salvataggio: i dati sono stati ripristinati alla situazione precedente.");
                //ShowMessage("Errore nel salvataggio: i dati sono stati ripristinati alla situazione precedente.");
            }

        }

        #endregion
    }
}
