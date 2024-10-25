using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class RichiesteCovid : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        //SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider covid_auto_prog_provider = new SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider();
        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_provider = new SiarBLL.CovidAutodichiarazioneCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "richieste_covid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            
            SiarLibrary.CovidAutodichiarazioneCollection coll_appoggio = new SiarLibrary.CovidAutodichiarazioneCollection();
            SiarLibrary.CovidAutodichiarazioneCollection coll = covid_provider.Find(Operatore.Utente.IdUtente,null,null,null,null,null,true);
            foreach(SiarLibrary.CovidAutodichiarazione c in coll) 
            {
                SiarLibrary.Progetto p = progetto_provider.GetById(c.IdProgetto);
                if (p.CodStato != "P")
                    coll_appoggio.Add(c);
            }
            dgElenco.DataSource = coll_appoggio;
            dgElenco.SetTitoloNrElementi();
            dgElenco.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgElenco_ItemDataBound);
            dgElenco.DataBind();

            base.OnPreRender(e);
        }

        void dgElenco_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_id= 0,
                
                col_Piva = 1,

                col_RagSoc = 2,

                col_bando = 3,

                col_data = 4,

                col_Segnatura = 5,

                col_Ricevuta = 6;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CovidAutodichiarazione c = (SiarLibrary.CovidAutodichiarazione)e.Item.DataItem;
                SiarLibrary.Impresa i = impresa_provider.GetById(c.IdImpresa);
                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(c.IdBando);

                e.Item.Cells[col_Piva].Text = i.CodiceFiscale;
                e.Item.Cells[col_RagSoc].Text = i.RagioneSociale;
                e.Item.Cells[col_bando].Text = b.Descrizione;

                SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(c.IdProgetto, "L", null);

                e.Item.Cells[col_data].Text = ps[0].Data.ToString("dd/MM/yyyy H:mm:ss");

                if (ps[0].Segnatura != "" && ps[0].Segnatura != null)
                {
                    e.Item.Cells[col_Segnatura].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"sncAjaxCallVisualizzaProtocollo('" + ps[0].Segnatura + "');\" style='cursor: pointer;'>";
                    e.Item.Cells[col_Ricevuta].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"ApriRicevuta(" + c.IdProgetto + ");\" style='cursor: pointer;'>";
                }
                else
                {
                    e.Item.Cells[col_Segnatura].Text = "<img src='" + Page.ResolveUrl("~/images/lente24.png") + "' alt='File'  onclick=\"ApriReportDomnanda(" + c.IdFileDomanda + ");\" style='cursor: pointer;'>";
                    e.Item.Cells[col_Ricevuta].Text = "In elaborazione";
                }
                    

                

            }
        }
    }
}