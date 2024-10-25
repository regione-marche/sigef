using System;

namespace web.CONTROLS
{
    public partial class SezioneImpresa : System.Web.UI.UserControl
    {
        public SiarLibrary.Impresa Azienda { get { return ((SiarLibrary.Web.ImpresaPage)Page).Azienda; } }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            lblRagioneSociale.Text = Azienda.RagioneSociale;
            lblCuaa.Text = Azienda.Cuaa;
            lblCodiceFiscale.Text = Azienda.CodiceFiscale;
            base.OnPreRender(e);
        }
    }
}