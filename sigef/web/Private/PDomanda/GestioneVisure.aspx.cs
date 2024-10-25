using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;

namespace web.Private.PDomanda
{
    public partial class GestioneVisure : ProgettoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Bando.Aggregazione)
            {
                btnPrev.Value = "<<< (2/8)";
                btnCurrent.Value = "(3/8)";
                btnGo.Value = "(4/8) >>>";
            }

            if (!AbilitaModifica)
            {
                divInserimentoVisura.Visible = false;
                ufNuovaVisura.AbilitaModifica = false;
            }
            else
                ufNuovaVisura.AbilitaModifica = true;

            var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();
            //var visuraAttuale = impresaVisuraProvider.GetUltimaVisuraImpresa(Progetto.IdImpresa);

            //if (visuraAttuale != null)
            //    ufVisuraAttuale.ID = visuraAttuale.IdFileVisura;
            //else
            //    divVisuraAttuale.Visible = false;

            var visureCollection = impresaVisuraProvider.FindVisureImpresa(Progetto.IdImpresa);

            if (visureCollection.Count > 0)
            {
                dgElencoVisure.Titolo = "Sono presenti " + visureCollection.Count + " visura/e a sistema per l'impresa.";
                dgElencoVisure.DataSource = visureCollection;
                dgElencoVisure.ItemDataBound += new DataGridItemEventHandler(dgElencoVisure_ItemDataBound);
                dgElencoVisure.DataBind();
            }
            else
                dgElencoVisure.Titolo = "Non sono ancora presenti visure a sistema per l'impresa.";

            // Se è il primo progetto deve avere almeno una visura per poter andare avanti
            var progettoProvider = new ProgettoCollectionProvider();
            var progettiColl = progettoProvider.Select(null, null, null, null, null, null, true, null, null, null, Progetto.IdImpresa, null, null, null, null);
            if (progettiColl.Count == 0 && visureCollection.Count == 0)
            {
                btnGo.Attributes.Add("onclick", "alert('Attenzione! Per proseguire occorre inserire almeno una visura.'); ");
            }

            base.OnPreRender(e);
        }

        void dgElencoVisure_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                var impresaVisura = (ImpresaVisura)dgi.DataItem;

                dgi.Cells[1].Text = "<img src='" + PATH_IMAGES + "acrobat.gif' alt='Visualizza visura' onclick=\"SNCUFVisualizzaFile('" + impresaVisura.IdFileVisura + "');\" style='cursor: pointer;'>";
            }
        }

        protected void btnInserisciVisura_Click(object sender, EventArgs e)
        {
            var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();

            try
            {
                impresaVisuraProvider.DbProviderObj.BeginTran();

                if (Progetto.IdImpresa == null)
                    throw new Exception("Impresa mancante: impossibile inserire la visura");

                if (ufNuovaVisura.IdFile == null)
                    throw new Exception("Visura non caricata correttamente");

                //if (txtDataVisura.Text == null || txtDataVisura.Text == "")
                //    throw new Exception("Data visura non inserita");

                var impresaVisura = new ImpresaVisura();
                impresaVisura.DataInserimento = impresaVisura.DataModifica = DateTime.Now;
                impresaVisura.CfInserimento = impresaVisura.CfModifica = Operatore.Utente.CfUtente;
                impresaVisura.IdImpresa = Progetto.IdImpresa;
                impresaVisura.IdFileVisura = ufNuovaVisura.IdFile;
                impresaVisura.DataVisura = DateTime.Now;
                impresaVisuraProvider.Save(impresaVisura);

                impresaVisuraProvider.DbProviderObj.Commit();
                ShowMessage("Visura caricata correttamente");
            }
            catch (Exception ex)
            {
                impresaVisuraProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }
    }
}