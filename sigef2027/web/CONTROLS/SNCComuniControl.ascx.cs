using System;

namespace web.CONTROLS
{
    public partial class SNCComuniControl : System.Web.UI.UserControl
    {
        public SiarLibrary.NullTypes.IntNT IdComune
        {
            get { return new SiarLibrary.NullTypes.IntNT(hdnSNCZCIdComune.Value); }
            set { if (value != null) hdnSNCZCIdComune.Value = value; }
        }
        public SiarLibrary.NullTypes.StringNT Denominazione
        {
            get { return txtSNCZCDenominazione.Text; }
            set { txtSNCZCDenominazione.Text = value; }
        }
        public SiarLibrary.NullTypes.StringNT Cap
        {
            get { return txtSNCZCCap.Text; }
            set { txtSNCZCCap.Text = value; }
        }
        public SiarLibrary.NullTypes.StringNT Provincia
        {
            get { return txtSNCZCProvincia.Text; }
            set { txtSNCZCProvincia.Text = value; }
        }
        public bool ReadOnly { set { txtSNCZCDenominazione.ReadOnly = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtSNCZCDenominazione.AddJSAttribute("onkeydown", "apriSNCZoomComuni(this,event);");
        }

        public void ClearSearch()
        {
            hdnSNCZCIdComune.Value = null;
            txtSNCZCDenominazione.Text = null;
            txtSNCZCCap.Text = null;
            txtSNCZCProvincia.Text = null;
        }
    }
}