using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaAnagraficaVisura : IstruttoriaPage
    {
        Progetto p;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProgetto;

            if (!int.TryParse(Request.QueryString["iddom"], out idProgetto)) 
                Redirect("Ammissibilita.aspx");
            else
            {
                p = new ProgettoCollectionProvider().GetById(idProgetto);

                ucInfoDomanda.Progetto = p;
                string idbando = p.IdBando;

                ucImpresaControl.AbilitaModifica = AbilitaModifica;
                ucImpresaControl.Impresa = new ImpresaCollectionProvider().GetById(p.IdImpresa);
                if (AbilitaModifica)
                    ucImpresaControl.AnagrafeEdit = true;

                var visureCollection = new ImpresaVisuraCollectionProvider().FindVisureImpresa(p.IdImpresa);

                if (visureCollection.Count > 0)
                {
                    dgElencoVisure.Titolo = "Sono presenti " + visureCollection.Count + " visura/e a sistema per l'impresa.";
                    dgElencoVisure.DataSource = visureCollection;
                    dgElencoVisure.ItemDataBound += new DataGridItemEventHandler(dgElencoVisure_ItemDataBound);
                    dgElencoVisure.DataBind();
                }
                else
                    dgElencoVisure.Titolo = "Non sono ancora presenti visure a sistema per l'impresa.";
            }

            controlloOperatoreStatoProgetto();
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnAmmissibilita.Attributes.Add("onclick", "location='checklistammissibilita.aspx?iddom="
                + p.IdProgetto + "'");
            btnAmmissibilitaDown.Attributes.Add("onclick", "location='checklistammissibilita.aspx?iddom="
                + p.IdProgetto + "'");

            base.OnPreRender(e);
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) 
                    AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) 
                    AbilitaModifica = false;
            }
        }

        void dgElencoVisure_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                var impresaVisura = (ImpresaVisura)dgi.DataItem;

                dgi.Cells[1].Text = "<img src='" + PATH_IMAGES + "acrobat.gif' alt='Visualizza visura' onclick=\"SNCUFVisualizzaFile('" + impresaVisura.IdFileVisura + "');\" style='cursor: pointer;'>";

                if (impresaVisura.Istruita != null && impresaVisura.Istruita)
                    dgi.Cells[3].Text = "Sì";
                else
                    dgi.Cells[3].Text = "No";
            }
        }
    }
}