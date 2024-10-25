using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace web.Private.regione
{
    public partial class CatalogoQuadriDomanda : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.QuadroDomandaCollectionProvider qdprov = new SiarBLL.QuadroDomandaCollectionProvider();
        SiarBLL.QuadriXDomandaCollectionProvider qdxdomprov = new SiarBLL.QuadriXDomandaCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Quadri";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            caricaQuadro();
            SiarLibrary.QuadroDomandaCollection qdcoll = qdprov.Find(null);
            dg.DataSource = qdcoll;
            dg.Titolo = "Elementi trovati: " + qdcoll.Count;
            dg.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.QuadroDomanda q = (SiarLibrary.QuadroDomanda)e.Item.DataItem;
                e.Item.Cells[3].Text = "<input type='button' style='width:80px' class='ButtonGrid' value='Seleziona' onclick='caricaQuadro(" + q.IdQuadro + ")' />";
                int idQuadroTmp;
                if (hdnQuadro.Text != null && q.IdQuadro == int.TryParse(hdnQuadro.Text, out idQuadroTmp))
                {
                    for (int i = 0; i <= (e.Item.Cells.Count - 1); i++)
                    {
                        e.Item.Cells[i].Style.Add("background-color", "#FFFF33");
                    }
                }
            }
        }

        protected void btnSalva_Click(object sender, System.EventArgs e)
        {
            try
            {
                SiarLibrary.QuadroDomanda q;
                int id_quadro;
                if (int.TryParse(hdnQuadro.Text, out id_quadro))
                    q = qdprov.GetById(id_quadro);
                else
                    q = new SiarLibrary.QuadroDomanda();
                q.Denominazione = txtDenominazione.Text;
                q.Descrizione = txtDescrizione.Text;
                qdprov.Save(q);
                ShowMessage("Salvataggio completato");
            }
            catch (Exception ex) { this.ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_quadro;
                if (int.TryParse(hdnQuadro.Text, out id_quadro))
                {
                    SiarLibrary.QuadroDomanda q = qdprov.GetById(id_quadro);
                    if (q == null) throw new Exception("Nessun Quadro selezionato. Impossibile continuare.");                
                    if (qdxdomprov.Find(q.IdQuadro, null, null).Count > 0)
                        throw new Exception("Impossibile eliminare il Quadro selezionato perchè esistono domande che lo utilizzano.");
                    qdprov.Delete(q);
                    hdnQuadro.Text = null;
                    ShowMessage("Quadro eliminato correttamente.");
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void caricaQuadro()
        {
            try
            {
                int id_quadro;
                if (int.TryParse(hdnQuadro.Text, out id_quadro))
                {
                    SiarLibrary.QuadroDomanda q = qdprov.GetById(id_quadro);
                    if (q == null) ShowError("Nessun Quadro selezionato. Impossibile continuare.");
                    else
                    {
                        txtDenominazione.Text = q.Denominazione;
                        txtDescrizione.Text = q.Descrizione;
                    }
                }
                else
                {
                    txtDenominazione.Text = null;
                    txtDescrizione.Text = null;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
