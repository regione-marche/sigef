using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Public
{
    public partial class AssistenzaUtenti : SiarLibrary.Web.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "public_assistenza";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
