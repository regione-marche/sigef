using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using RnaManager;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.Web;
using SiarLibrary.NullTypes;

namespace web.CONTROLS
{
    public partial class ucProcureSpeciali : System.Web.UI.UserControl
    {

        SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider procure_provider = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider();

        private Progetto _progetto;
        public Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            caricaDgProcure();

            base.OnPreRender(e);
        }

        private void caricaDgProcure()
        {
            SiarLibrary.RichiestaConsulenteProcuraXBandoCollection rich_coll_proc_inv = procure_provider.Find(null, null, Progetto.IdImpresa, null, Progetto.IdBando, true, true, true, true);
            dgMandatiProcura.DataSource = rich_coll_proc_inv;
            dgMandatiProcura.ItemDataBound += new DataGridItemEventHandler(dgRichiesteInviateProcura_ItemDataBound);
            if (rich_coll_proc_inv.Count == 0) dgMandatiProcura.Titolo = "Nessuna procura presente.";
            dgMandatiProcura.DataBind();
        }

        void dgRichiesteInviateProcura_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RichiestaConsulenteProcuraXBando m = (SiarLibrary.RichiestaConsulenteProcuraXBando)e.Item.DataItem;
                SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().Find(null, m.IdConsulente, null, null, null, null, 1)[0];
                e.Item.Cells[1].Text = u.CfUtente;
                e.Item.Cells[2].Text = u.Nominativo;
                e.Item.Cells[3].Text = new SiarBLL.BandoCollectionProvider().GetById(m.IdBando).Descrizione;
                if (m.Attivo) e.Item.Cells[4].Text = "Si";
                else
                {
                    e.Item.Cells[4].Text = "SCADUTO/REVOCATO";
                    e.Item.BackColor = System.Drawing.Color.FromArgb(204, 204, 179);
                }
                if (m.Segnatura != null)
                    e.Item.Cells[5].Text = "<svg class='icon m-1' style='cursor:pointer;' alt='Domanda'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + m.Segnatura + "');\" style='cursor: pointer;'><use href='/web/bootstrap-italia/svg/sprites.svg#it-print'></use></svg>";
            }
        }
    }
}