using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace web.Private.IPagamento.IVariante
{
    public partial class PianoInvestimenti : SiarLibrary.Web.IstruttoriaVariantePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SiarLibrary.Web.Button btn2 = new SiarLibrary.Web.Button();
            //btn2.Style.Add("margin-right", "20px");
            //btn2.Text = "Inserisci nuovo investimento";
            //btn2.Width = new Unit(200);
            //btn2.CausesValidation = false;
            //btn2.Modifica = true;
            //string url_New2 = "InvestimentiFondoPerduto.aspx?idpcurrent=" + Progetto.IdProgetto.ToString();
            //btn2.Attributes.Add("onclick", "location='" + url_New2 + "'");
            //btn2.Style.Add("width", "200px");
            //tdButtoniPage.Controls.Add(btn2);

            SiarLibrary.Web.Button btnEstrai = new SiarLibrary.Web.Button();
            btnEstrai.Style.Add("margin-right", "20px");
            btnEstrai.Text = "Estrai in XLS";
            btnEstrai.Width = new Unit(140);
            btnEstrai.CausesValidation = false;
            btnEstrai.Click += new EventHandler(btnEstrai_Click);
            tdButtoniPage.Controls.Add(btnEstrai);

            string nascodiDiv = "";
            nascodiDiv = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_NascondiPInv(Progetto.IdBando);
            if (nascodiDiv == "True")
            {
                PianoInvestimentiAggregazione.Visible = false;
                PianoInvestimentiCodifica.Visible = false;
            }

            int idIntervento = ucPianoInvestimenti.GetIntervento();
            PianoInvestimentiCodifica.id_intervento = idIntervento;
            PianoInvestimentiAggregazione.id_intervento = idIntervento;
            PianoInvestimentiIntervento.id_intervento = idIntervento;
        }

        protected void btnEstrai_Click(object sender, EventArgs e)
        {
            try
            {
                string parametri = "";
                parametri += "IdProgetto=" + Progetto.IdProgetto;
                parametri += "|CodQuery=" + "VARIANTE_ATTUALE";
                parametri += "|IdVarianteAttuale=" + Variante.IdVariante;

                string jsFunction = "SNCVisualizzaReport('rptPianoInvestimenti', 2, '" + parametri + "');";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunction, true);
            }
            catch (Exception ex) { ((SiarLibrary.Web.PrivatePage)Page).ShowError(ex); }
        }

    }
}