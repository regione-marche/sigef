using System;

namespace web.CONTROLS
{
    public partial class SNCBandoConfigMultivalore : System.Web.UI.UserControl
    {
        private string _codTipo;
        public string CodTipo { set { _codTipo = value; } }

        public string Valore
        {
            get { return hdnValoreSelezionato.Value; }
            set { hdnValoreSelezionato.Value = value; }
        }

        public string Testo { set { txtSNCTestoMultivalore.Text = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSNCSelezionaMultivalore.Src = Request.ApplicationPath + "/images/folderopen.png";
            imgSNCSelezionaMultivalore.Attributes.Add("onclick", "SNCZoomMultivalore('" + _codTipo + "', 'getMultivaloriBandoConfig', selezionaBCMultivalore, 0);");
            imgSNCDeselezionaMultivalore.Src = Request.ApplicationPath + "/images/xdel.gif";
            imgSNCDeselezionaMultivalore.Attributes.Add("onclick", "deselezionaBCMultivalore('" + _codTipo + "');");
        }
    }
}