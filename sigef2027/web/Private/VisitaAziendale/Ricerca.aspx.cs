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
    public partial class Ricerca : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "visita_aziendale";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            bindCombo();
            base.OnPreRender(e);
        }

        private void bindCombo()
        {
            lstTipoPagamento.Items.Clear();
            lstTipoPagamento.Items.Add(new ListItem("", ""));
            lstTipoPagamento.Items.Add(new ListItem("SAL", "SAL"));
            lstTipoPagamento.Items.Add(new ListItem("SALDO", "SLD"));
            foreach (ListItem li in lstTipoPagamento.Items)
                if (li.Value == lstTipoPagamento.SelectedValue) li.Selected = true;
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
}
}
