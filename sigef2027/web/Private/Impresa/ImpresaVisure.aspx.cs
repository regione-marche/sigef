using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using System;
using System.Web.UI.WebControls;
using web.CONTROLS;

namespace web.Private.Impresa
{
    public partial class ImpresaVisure : ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_anagrafe";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!AbilitaModifica)
            {
                divInserimentoVisura.Visible = false;
                ufNuovaVisura.AbilitaModifica = false;
            }
            else
                ufNuovaVisura.AbilitaModifica = true;

            var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();
            //var visuraAttuale = impresaVisuraProvider.GetUltimaVisuraImpresa(Azienda.IdImpresa);

            //if (visuraAttuale != null)
            //    ufVisuraAttuale.ID = visuraAttuale.IdFileVisura;
            //else
            //    divVisuraAttuale.Visible = false;

            var visureCollection = impresaVisuraProvider.FindVisureImpresa(Azienda.IdImpresa);

            if (visureCollection.Count > 0)
            {
                dgElencoVisure.Titolo = "Sono presenti " + visureCollection.Count + " visura/e a sistema per l'impresa.";
                dgElencoVisure.DataSource = visureCollection;
                dgElencoVisure.ItemDataBound += new DataGridItemEventHandler(dgElencoVisure_ItemDataBound);
                dgElencoVisure.DataBind();
            }
            else
                dgElencoVisure.Titolo = "Non sono ancora presenti visure a sistema per l'impresa. Inserirne una per proseguire.";

            base.OnPreRender(e);
        }

        void dgElencoVisure_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                var impresaVisura = (ImpresaVisura)dgi.DataItem;

                //dgi.Cells[2].Text = "<img src='../../images/acrobat.gif' alt='Visualizza documento' title='Visualizza documento'"
                //+ "style='cursor:pointer' onclick=\"" + (pag.IdFile == null ? "SNCVisualizzaReport('rptGiustificativo',1,'IdGiustificativo=" + pag.IdGiustificativo + "');"
                //: "SNCUFVisualizzaFile(" + pag.IdFile + ");") + "\" />";

                //dgi.Cells[2].Text = "<img src='../../images/acrobat.gif' alt='Visualizza visura' title='Visualizza visura'"
                //    + "style='cursor:pointer' onclick=\"SNCUFVisualizzaFile(" + impresaVisura.IdFileVisura + ");" ;

                dgi.Cells[1].Text = "<img src='" + PATH_IMAGES + "acrobat.gif' alt='Visualizza visura' onclick=\"SNCUFVisualizzaFile('" + impresaVisura.IdFileVisura + "');\" style='cursor: pointer;'>";
            }
        }

        protected void btnInserisciVisura_Click(object sender, EventArgs e)
        {
            var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();

            try
            {
                impresaVisuraProvider.DbProviderObj.BeginTran();

                if (Azienda == null || Azienda.IdImpresa == null)
                    throw new Exception("Impresa mancante: impossibile inserire la visura");

                if (ufNuovaVisura.IdFile == null)
                    throw new Exception("Visura non caricata correttamente");

                //if (txtDataVisura.Text == null || txtDataVisura.Text == "")
                //    throw new Exception("Data visura non inserita");

                var impresaVisura = new ImpresaVisura();
                impresaVisura.DataInserimento = impresaVisura.DataModifica = DateTime.Now;
                impresaVisura.CfInserimento = impresaVisura.CfModifica = Operatore.Utente.CfUtente;
                impresaVisura.IdImpresa = Azienda.IdImpresa;
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