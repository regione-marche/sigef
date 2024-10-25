using System;
using System.Web;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using System.Web.UI;
using System.Linq;
using SiarLibrary.Extensions;

namespace web.Private.ModificaDati
{
    public partial class VisualizzaModifica : SiarLibrary.Web.ModificaPage
    {
        protected override void OnPreRender(EventArgs e)
        {
            ucVisualizzaModifica.ProgettoProvider = ProgettoProvider;
            ucVisualizzaModifica.ModificaDati = ModificaDati;

            base.OnPreRender(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}