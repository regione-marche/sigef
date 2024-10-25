using System;
using System.Web;
using System.Web.UI;

namespace web.Public
{
    public partial class SupportoFirmaDigitale : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "supporto_firma_digitale";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
        }
    }
}
