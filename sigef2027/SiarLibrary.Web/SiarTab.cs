using System;
using System.Web.UI.HtmlControls;

namespace SiarLibrary.Web
{
    public class TabBaseDesigner : System.Web.UI.Design.WebControls.PanelContainerDesigner
    {
        public TabBaseDesigner() : base() { }

        SiarTab tab;
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            tab = (SiarTab)component;
        }
    }

    [System.ComponentModel.Designer(typeof(TabBaseDesigner))]
    public class SiarTab : System.Web.UI.WebControls.Panel
    {
        public SiarTab() : base() { }

        private string _tabs;
        public string Tabs
        {
            get { return _tabs; }
            set { _tabs = value; }
        }
        /// <summary>
        /// ritorna l'indice della tab attiva
        /// </summary>
        private string _tabSelected;
        public string TabSelected
        {
            get { return _tabSelected; }
        }

        private bool _fullValidate;
        [System.ComponentModel.DefaultValue(false)]
        public bool FullValidate
        {
            get { return _fullValidate; }
            set { _fullValidate = value; }
        }

        System.Collections.Queue _tabInvisibili = new System.Collections.Queue();
        public void Hide(int tabIndex)
        {
            _tabInvisibili.Enqueue(tabIndex);
        }

        public void Select(int tabIndex)
        {
            _tabSelected = tabIndex.ToString();
        }

        string nome_hidden;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!DesignMode)
            {
                nome_hidden = "hdn" + this.ID + "_TabSelected";
                foreach (string s in Page.Request.Form.AllKeys)
                    if (s.EndsWith(nome_hidden)) { _tabSelected = Page.Request.Form[s]; break; }
                if (string.IsNullOrEmpty(_tabSelected)) _tabSelected = "0";
                ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("TableTabViewHandle('" + this.ID + "');");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            HtmlInputHidden hdn = new HtmlInputHidden();
            hdn.ID = nome_hidden;
            hdn.Value = _tabSelected;
            this.Controls.AddAt(0, hdn);

            #region tabella header
            HtmlTable ta = new HtmlTable();
            ta.ID = "tab" + this.ID + "_HeaderTab";
            ta.Width = "100%";
            ta.CellPadding = 3;
            ta.CellSpacing = 0;
            ta.Border = 0;

            HtmlTableRow tr = new HtmlTableRow();
            string[] tabArray = _tabs.Split('|');
            object[] invisibili = _tabInvisibili.ToArray();
            for (int i = 0; i < tabArray.Length; i++)
            {
                string istr = i.ToString();
                HtmlTableCell td = new HtmlTableCell();
                td.ID = "td" + this.ID + "_HeaderCells" + istr;
                td.Attributes.Add("class", "normalTab");
                td.Attributes.Add("onclick", "TableTabSwitchHandle('" + this.ID + "'," + istr + ");");
                if (Array.IndexOf(invisibili, i) >= 0) td.Style.Add("display", "none");
                td.InnerText = tabArray[i];
                tr.Cells.Add(td);
            }
            HtmlTableCell tdend = new HtmlTableCell();
            tdend.Attributes.Add("class", "endTab");
            tdend.InnerHtml = "&nbsp;";
            tr.Cells.Add(tdend);

            ta.Rows.Add(tr);
            this.Controls.AddAt(1, ta);
            #endregion
            base.OnPreRender(e);
        }

        bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (value) disabilitaControllo(this);
            }
        }

        void disabilitaControllo(System.Web.UI.Control ctrl)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).ReadOnly = true;
                return;
            }
            if (ctrl is ComboBase)
            {
                ((ComboBase)ctrl).Enabled = false;
                return;
            }
            if (ctrl is Button)
            {
                ((Button)ctrl).Enabled = false;
                return;
            }
            if (ctrl is System.Web.UI.HtmlControls.HtmlImage)
            {
                ctrl.Visible = false;
                return;
            }
            foreach (System.Web.UI.Control child in ctrl.Controls) disabilitaControllo(child);
        }
    }
}
