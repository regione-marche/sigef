using System;

namespace web.CONTROLS
{
    public partial class SNCBandoConfigPlurivalore : System.Web.UI.UserControl
    {
        private string _codTipo;
        public string CodTipo { set { _codTipo = value; } }

        public string Valore
        {
            get { return hdnValoreSelezionato.Value; }
            set { hdnValoreSelezionato.Value = value; }
        }

        public string Testo { set { txtSNCTestoPlurivalore.Text = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSNCSelezionaPlurivalore.Src = Request.ApplicationPath + "/images/folderopen.png";
            imgSNCSelezionaPlurivalore.Attributes.Add("onclick", "SNCZoomPlurivalore('" + _codTipo + "','getPlurivaloriBandoConfig',selezionaBCPlurivalore,0);");
            imgSNCDeselezionaPlurivalore.Src = Request.ApplicationPath + "/images/xdel.gif";
            imgSNCDeselezionaPlurivalore.Attributes.Add("onclick", "deselezionaBCPlurivalore('" + _codTipo + "');");
        }
    }
}