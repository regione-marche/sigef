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

namespace web.CONTROLS
{
    public partial class FiltroRicercaComunicazioni : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {        }

        public SiarLibrary.NullTypes.IntNT IdProgetto
        {
            get { return new SiarLibrary.NullTypes.IntNT(txtNumero.Text); }
        }
        public SiarLibrary.NullTypes.StringNT TipoDocumento
        {
            get { return lstTipoDocumento.SelectedValue; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstTipoDocumento.DataBinding += new EventHandler(lstTipoDocumento_DataBinding);
            lstTipoDocumento.DataBind();
            base.OnPreRender(e);
        }

        void lstTipoDocumento_DataBinding(object sender, EventArgs e)
        {
            lstTipoDocumento.Items.Clear();
            lstTipoDocumento.Items.Add(new ListItem("", ""));
            lstTipoDocumento.Items.Add(new ListItem("Documenti di integrazione", "DNT"));
            lstTipoDocumento.Items.Add(new ListItem("Richiesta di riesame", "RID"));
            lstTipoDocumento.Items.Add(new ListItem("Comunicazione di rinuncia", "RIN"));
            lstTipoDocumento.Items.Add(new ListItem("Esito del ricorso", "RIC"));
            foreach (ListItem li in lstTipoDocumento.Items)
                if (li.Value == lstTipoDocumento.SelectedValue) li.Selected = true;
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
}
}
