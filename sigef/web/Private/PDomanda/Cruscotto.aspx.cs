using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PDomanda
{
    public partial class Cruscotto : SiarLibrary.Web.PrivatePage
    {

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "cruscotto";
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
    }

}
