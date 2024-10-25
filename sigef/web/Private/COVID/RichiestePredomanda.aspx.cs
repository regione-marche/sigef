using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class RichiestePredomanda : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_prov = new SiarBLL.CovidAutodichiarazioneCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "autocertificazione_covid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_progetto_covid"] = null;
            Session["id_bando_covid"] = null;
        }

        protected override void OnPreRender(EventArgs e)
        {

            SiarLibrary.CovidAutodichiarazioneCollection autocert_coll = covid_prov.Find(Operatore.Utente.IdUtente, null, null, null, null, null, false);
            dgElenco.DataSource = autocert_coll;
            dgElenco.SetTitoloNrElementi();
            dgElenco.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgElenco_ItemDataBound);
            dgElenco.DataBind();

            

            base.OnPreRender(e);
        }

        void dgElenco_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_ID = 0,

                col_Piva = 1,

                col_RagSoc = 2,

                col_bando = 3,

                col_Button = 4,

                col_Definitiva = 5;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CovidAutodichiarazione autocert = (SiarLibrary.CovidAutodichiarazione)e.Item.DataItem;

                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(autocert.IdBando);
                e.Item.Cells[col_bando].Text = b.Descrizione;


                if (autocert.Definitiva)
                {
                    //e.Item.Cells[col_Button].Text = e.Item.Cells[col_Button].Text.Replace("Modifica", "Visualizza");
                    e.Item.Cells[col_Definitiva].Text = "<img src='" + Request.ApplicationPath + "/images/visto.gif'>";
                    string _buttonText = "Stampa";
                    string fn = "StampaDomanda(" + autocert.Id.ToString() + ")";
                    e.Item.Cells[col_Button].Text = "<input type=button class=ButtonGrid value='" + _buttonText + "' onclick=\"" + fn + "\" style='width:100px;margin-left:10px;margin-right:10px;' />";
                }
            }
        }

        protected void btnNuova_Click(object sender, EventArgs e)
        {
            Session["id_progetto_covid"] = null;
            Session["id_bando_covid"] = null;

            //redirect pagina bandi
            Redirect("BandiCovidPreDomanda.aspx");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int IdAutocert;
            if (int.TryParse(hdnIdAutocert.Value, out IdAutocert))
            {
                SiarLibrary.CovidAutodichiarazione aut = covid_prov.GetById(IdAutocert);

                // metto in sessione il progetto
                //Session.Add("id_bando_covid", Convert.ToInt32(aut.IdBando));
                Session.Add("id_bando_covid", aut.IdBando.ToString());
                Session.Add("id_progetto_covid", aut.IdProgetto.ToString());
                //Session["id_progetto_covid"] = aut.IdProgetto;
                //Session["id_bando_covid"] = aut.IdBando;
                //redirect alla pagina della predomanda
                Redirect("Autocertificazione.aspx");
            }
        }
    }
}