using System;

namespace web.Public
{
    public partial class Manuali : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "public_manuali";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlLink link = new System.Web.UI.HtmlControls.HtmlLink();
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            link.Href = "https://sigef.regione.marche.it/Public/Manuali/video-js.css";
            //Page.Header.Controls.Add(link);
            Page.Controls.Add(link);
        }
    }
}
