using System;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class SiarNewTab : System.Web.UI.UserControl
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
            if (string.IsNullOrEmpty(_titolo)) _titolo = "SCHEDE:";
            tdSNTTitolo.InnerHtml = "<nobr>" + _titolo + "</nobr>";
            int indice = 1;

            if (TabPerRiga == 0)
            {
                foreach (string s in _tabNames.Split('|'))
                {
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<nobr>" + s + "</nobr>";
                    int w = s.Length * 6 + 50;
                    td.Width = w.ToString() + "px";
                    if (indice == TabSelected) 
                        td.Attributes.Add("class", "SNTSelected");
                    else
                    {
                        td.Attributes.Add("class", "SNTUnselected");
                        td.Attributes.Add("onclick", (_tabClickEvents != "" ? _tabClickEvents : "") 
                                                        + " swapTab(" + indice.ToString() + ");");
                    }
                    rowTab.Cells.Insert(indice++, td);
                }
            }
            else
            {
                HtmlTableRow tr = new HtmlTableRow();
                var elenco_tab = _tabNames.Split('|');

                for (int i = 1; i <= elenco_tab.Length; i++)
                {
                    var s = elenco_tab[i - 1];
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<nobr>" + s + "</nobr>";
                    int w = s.Length * 6 + 50;
                    td.Width = w.ToString() + "px";
                    if (indice == TabSelected)
                        td.Attributes.Add("class", "SNTSelected");
                    else
                    {
                        td.Attributes.Add("class", "SNTUnselected");
                        td.Attributes.Add("onclick", (_tabClickEvents != "" ? _tabClickEvents : "")
                                                        + " swapTab(" + indice.ToString() + ");");
                    }

                    tr.Cells.Add(td);
                    indice++;

                    if (i % TabPerRiga == 0)
                    {
                        tableMain.Rows.Add(tr);
                        tr = new HtmlTableRow();
                    }
                }

                tableMain.Rows.Add(tr);
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