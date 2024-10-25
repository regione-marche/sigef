using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class CessazioneAttivita : SiarLibrary.Web.ImpresaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            lstMotivazione.Items.Clear();
            lstMotivazione.Items.Add(new ListItem("", ""));
            lstMotivazione.Items.Add(new ListItem("Cessazione attività","C"));
            lstMotivazione.Items.Add(new ListItem("Decesso titolare dell`impresa", "D"));

            base.OnPreRender(e);
        }
    }
}
