using System;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class VisualizzaReport : System.Web.UI.UserControl
    {
        private string _reportName;
        public string ReportName
        {
            set { _reportName = value; }
        }

        private SiarLibrary.Web.ReportFormat _reportFormat;
        public SiarLibrary.Web.ReportFormat ReportFormat
        {
            set { _reportFormat = value; }
        }

        private SNCOptions.ViewOption _reportViewOptions;
        public SNCOptions.ViewOption ReportViewOptions
        {
            set { _reportViewOptions = value; }
        }

        private string _reportParametersFunction;
        public string ReportParametersFunction
        {
            set { _reportParametersFunction = value; }
        }

        private string _reportParameters;
        public string ReportParameters
        {
            set { _reportParameters = value; }
        }

        private string _text = "Visualizza documento";
        public string Text
        {
            set { _text = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_reportViewOptions != web.CONTROLS.SNCOptions.ViewOption.Invisibile)
            {
                HtmlControl c = null;
                switch (_reportViewOptions)
                {
                    case web.CONTROLS.SNCOptions.ViewOption.Bottone:
                        c = new HtmlInputButton();
                        c.Attributes.Add("class", "Button");
                        c.Attributes.Add("Value", _text);
                        break;
                    case web.CONTROLS.SNCOptions.ViewOption.BottoneGriglia:
                        c = new HtmlInputButton();
                        c.Attributes.Add("class", "ButtonGrid");
                        c.Attributes.Add("Value", _text);
                        break;
                    default:
                        //c = new HtmlImage();
                        //c.Attributes.Add("src", Request.ApplicationPath + "/images/print_ico.gif");
                        //c.Attributes.Add("alt", _text);
                        //c.Attributes.Add("onmouseover", "this.style.cursor='pointer';");
                        c = new HtmlGenericControl("a");
                        HtmlGenericControl svg = new HtmlGenericControl("svg");
                        svg.Attributes.Add("class", "icon");
                        HtmlGenericControl use = new HtmlGenericControl("use");
                        use.Attributes.Add("href", Request.ApplicationPath + "/bootstrap-italia/svg/sprites.svg#it-print");
                        svg.Controls.Add(use);
                        c.Controls.Add(svg);
                        break;
                }
                c.Attributes.Add("onclick", "SNCVisualizzaReport('" + _reportName + "'," + ((int)_reportFormat).ToString() + ","
                    + (!string.IsNullOrEmpty(_reportParametersFunction) ? _reportParametersFunction : "'" + _reportParameters + "'")
                        + ");");
                divReport.Controls.Add(c);
            }
            base.OnPreRender(e);
        }
    }
}
