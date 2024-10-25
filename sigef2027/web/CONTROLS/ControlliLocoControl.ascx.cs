using System;
using System.Web.UI;

namespace web.CONTROLS
{
    public partial class ControlliLocoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock("highlightTdMenu();");
        }
    }
}