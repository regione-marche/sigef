using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace web.Private.VisitaAziendale
{
    public partial class VisitaInItinere : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "visita_aziendale";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    ComboCFAbilitati();           
        //    base.OnPreRender(e);
        //}

                protected void btnCerca_Click(object sender, EventArgs e)
        {

        }

        protected void lstCF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}
}
