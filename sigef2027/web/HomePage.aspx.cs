using System;
using System.Configuration;
using System.Web.UI.WebControls;

namespace web
{
    public partial class HomePage : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "Pagina_iniziale";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (ConfigurationManager.AppSettings["SignatureType"] == "applet")
            {
                linkTestFirmaDigitale.HRef = "../Public/Download/TestFirmaDigitale.html";
            }
            else
            {
                linkTestFirmaDigitale.HRef = "~/Public/Download/TestFirmaDigitaleCalamaio.aspx";
            }

            linkTestFirmaDigitaleRemota.HRef = "~/Public/Download/TestFirmaDigitaleRemota.aspx";
        }       
    }
}
