using System;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class SNCVisualizzaProtocollo : System.Web.UI.UserControl
    {
        private bool _visualizzaMenu = false;
        public bool VisualizzaMenu { set { _visualizzaMenu = value; } }

        private SNCOptions.ViewOption _tipoVisualizzazione = SNCOptions.ViewOption.Immagine;
        public SNCOptions.ViewOption TipoVisualizzazione { set { _tipoVisualizzazione = value; } }

        private string _segnatura;
        public string Segnatura { set { _segnatura = value; } }

        private bool _enabled = true;
        public bool Enabled { set { _enabled = value; } }

        public string ViewDocFunction
        {
            get
            {
                if (_enabled)
                {
                    //if (_visualizzaMenu) return "sncVisualizzaMenuProtocollo('" + _segnatura + "');";
                    return "sncAjaxCallVisualizzaProtocollo('" + _segnatura + "');";
                }
                return "alert('Non si è abilitati alla visualizzazione del documento selezionato.');";
            }
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            if (string.IsNullOrEmpty(_segnatura)) _tipoVisualizzazione = web.CONTROLS.SNCOptions.ViewOption.Invisibile;
            switch (_tipoVisualizzazione)
            {
                case SNCOptions.ViewOption.Immagine:
                    HtmlGenericControl c = new HtmlGenericControl("a");
                    HtmlGenericControl svg = new HtmlGenericControl("svg");
                    svg.Attributes.Add("class", "icon");
                    HtmlGenericControl use = new HtmlGenericControl("use");
                    use.Attributes.Add("href", Request.ApplicationPath + "/bootstrap-italia/svg/sprites.svg#it-print");
                    svg.Controls.Add(use);
                    c.Attributes.Add("onclick", ViewDocFunction);
                    c.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                    c.Controls.Add(svg);
                    divSNCVisualizzaProtocollo.Controls.Add(c);
                    break;
                case SNCOptions.ViewOption.Bottone:
                    break;
                case SNCOptions.ViewOption.BottoneGriglia:
                    break;
                default:
                    divSNCVisualizzaProtocollo.Attributes.Add("style", "display:none");
                    break;
            }
            base.OnPreRender(e);
        }
    }
}