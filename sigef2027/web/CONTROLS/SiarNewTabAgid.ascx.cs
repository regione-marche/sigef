using System;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class SiarNewTabAgid : System.Web.UI.UserControl
    {
        private string _tabNames;
        public string TabNames
        {
            set { _tabNames = value; }
        }

        private string _tabClickEvents = "";
        public string TabClickEvents
        {
            set { _tabClickEvents = value; }
        }

        public int TabSelected
        {
            get { int val; int.TryParse(hdnTabSelected.Value, out val); return val < 1 ? 1 : val; }
            set { hdnTabSelected.Value = value.ToString(); }
        }

        public string Width
        {
            set { tableMain.Style.Add("width", value); }
            get { return tableMain.Style["width"]; }
        }

        private string _titolo;
        public string Titolo { set { _titolo = value; } }

        private int _tab_per_riga;
        public int TabPerRiga
        {
            get { return _tab_per_riga; }
            set { _tab_per_riga = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            int indice = 1;

            foreach (string s in _tabNames.Split('|'))
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "nav-item");

                HtmlGenericControl a = new HtmlGenericControl("a");                
                a.InnerText = s;

                if (indice == TabSelected)
                    a.Attributes.Add("class", "nav-link active");
                else
                {
                    a.Attributes.Add("class", "nav-link");
                    a.Attributes.Add("onclick", (_tabClickEvents != "" ? _tabClickEvents : "")
                                                    + " swapTab(" + indice.ToString() + ");");
                }
                li.Controls.Add(a);
                
                tableMain.Controls.Add(li);

                indice++;
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// l'evento si scatena quando l'utente clicca su una tab e fa postback
        /// </summary>
        public event System.EventHandler TabClicked;


        protected void btnPostTabSelect_Click(object sender, EventArgs e)
        {
            // era già tutto fatto bastava scatenare l'evento.
            if (this.TabClicked != null)
            {
                this.TabClicked(this, new EventArgs());
            }
        }
    }
}