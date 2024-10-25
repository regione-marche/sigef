using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace web.Private.PPagamento.Variante
{
    public partial class PianoInvestimenti : SiarLibrary.Web.VariantePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn2.CausesValidation = false;
           
            string url_New2 = "InvestimentiFondoPerduto.aspx?idpcurrent=" + Progetto.IdProgetto.ToString();
            btn2.Attributes.Add("onclick", "location='" + url_New2 + "'");
        
            btnEstrai.CausesValidation = false;
            btnEstrai.Click += new EventHandler(btnEstrai_Click);
           

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