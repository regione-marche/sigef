using System;

namespace web.CONTROLS
{
    public partial class SiarNewToolTip : System.Web.UI.UserControl
    {
        private string _testoAlternativo;
        public string TestoAlternativo { set { _testoAlternativo = value; } }

        private string _codice;
        public string Codice { set { _codice = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkSNTTHelp.HRef = "javascript:sntt_click('" + _codice + "');";
            if (string.IsNullOrEmpty(_testoAlternativo)) lnkSNTTHelp.InnerHtml = "<img alt='Mostra pagina di aiuto - Info online' src='" 
                + Request.ApplicationPath + "/images/help.ico' style='height:20px;width:30px' />";
            else lnkSNTTHelp.InnerHtml = _testoAlternativo;
        }
    }
}