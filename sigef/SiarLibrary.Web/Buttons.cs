using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiarLibrary.Web
{
    public class Button : System.Web.UI.WebControls.Button
    {
        private string _conferma;
        public Button()
            : base()
        {
            _conferma = "";
            base.EnableViewState = false;
        }

        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }

        public string AdditionalStyles
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] stili = value.Split(';');
                    foreach (string s in stili)
                    {
                        string[] keyvalues = s.Split(':');
                        if (keyvalues.Length == 2) base.Style.Add(keyvalues[0], keyvalues[1]);
                    }
                }
            }
        }

        //indica se un pulsante e' di modifica dei dati
        private bool _modifica;
        public bool Modifica
        {
            get { return _modifica; }
            set { _modifica = value; }
        }

        /// <summary>
        /// Se indicato, è il messaggio di conferma per il window.confirm
        /// </summary>
        public string Conferma
        {
            get { return _conferma; }
            set
            {
#if(DEBUG)
                _conferma = value.Replace("'", "`");
#else
				_conferma=value;
#endif
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            System.Reflection.PropertyInfo pi = Page.GetType().GetProperty("AbilitaModifica");
            if (pi != null && _modifica) Enabled = (bool)pi.GetValue(Page, null);
            base.OnLoad(e);
        }

        public event EventHandler ClickBeforeLoad
        {
            add
            {
                if (Page.Request.Form[this.UniqueID] != null)
                    value.DynamicInvoke(new object[] { null, null });
            }
            remove { }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            CssClass = "Button";
#if(DEBUG)
            if ((Site != null) && (Site.DesignMode))
            {
                base.Render(writer);
                return;
            }
#endif
            if (!string.IsNullOrEmpty(_conferma)) //Attributes.Add("message", _conferma);
                Attributes.Add("onclick", "if(!confirm('" + _conferma + "'))return stopEvent(event);");

            if (CausesValidation) Attributes.Add("causevalidation", "True");

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            //base.Render(writer);
            // *** store to a string
            //string PageResult = sb.ToString();
            // *** Write it back to the server
            //writer.Write(PageResult);
            //false


            base.Render(writer);
        }
    }

    public class ImgButtons : System.Web.UI.Control
    {
        public ImgButtons()
            : base()
        {
            defaultpath = "http://localhost/Siar/web";
            searcImg = "/images/lente.gif";
            clearImg = "/images/xdel.gif";
        }
        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }

        protected string searcImg, clearImg, defaultpath;

        string
            _searchFunction,
            _clearFunction,
            _searchText,
            _clearText;
        bool
            _showSearch,
            _showClear;

        public string SearchFunction
        {
            get { return _searchFunction; }
            set { _searchFunction = value; }
        }

        public string ClearFunction
        {
            get { return _clearFunction; }
            set { _clearFunction = value; }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

        public string ClearText
        {
            get { return _clearText; }
            set { _clearText = value; }
        }

        public bool ShowSearch
        {
            get { return _showSearch; }
            set { _showSearch = value; }
        }

        public bool ShowClear
        {
            get { return _showClear; }
            set { _showClear = value; }
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            string path;
            if (Site != null && Site.DesignMode)
                path = defaultpath;
            else
                path = Page.Request.ApplicationPath;

            base.Render(writer);
            if (_showSearch)
            {
                writer.Write("<img src=\"" + path + searcImg + "\" id=\"" + UniqueID + "_Search\" style=\"CURSOR: hand\" onclick=\"" + _searchFunction + "\" alt=\"" + _searchText + "\" />");
                if (_showClear)
                    writer.Write("&nbsp;");
            }
            if (_showClear)
                writer.Write("<img src=\"" + path + clearImg + "\" id=\"" + UniqueID + "_Clear\" style=\"CURSOR: hand\" onclick=\"" + _clearFunction + "\" alt=\"" + _clearText + "\" />");
        }
    }

    //public class ImgCFButtons : ImgButtons
    //{
    //    public ImgCFButtons()
    //        : base()
    //    {
    //        defaultpath = "http://localhost/Siar/web";
    //        searcImg = "/images/codicefiscale.gif";
    //        clearImg = "/images/xdel.gif";
    //    }
    //}

    //public class ImgButtonsSmall : ImgButtons
    //{
    //    public ImgButtonsSmall()
    //        : base()
    //    {
    //        defaultpath = "http://localhost/Siar/web";
    //        searcImg = "/images/folderopen.png";
    //        clearImg = "/images/xdel.gif";
    //    }
    //}


    [System.Web.UI.ValidationProperty("Text")]
    public class Hidden : System.Web.UI.Control
    {
        public Hidden() : base() { }
        string _text;

        private string _dataColumn;
        [System.ComponentModel.DefaultValue("")]
        public string DataColumn
        {
            get { return _dataColumn; }
            set { _dataColumn = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private bool _obbligatorio = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool Obbligatorio
        {
            get { return _obbligatorio; }
            set { _obbligatorio = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            base.EnableViewState = false;
            if (Page.IsPostBack)
                _text = Page.Request.Form[this.UniqueID];
        }

        string _nomeCampo;
        [System.ComponentModel.DefaultValue("")]
        public string NomeCampo
        {
            get { return _nomeCampo; }
            set { _nomeCampo = value; }
        }

        [System.ComponentModel.Browsable(false)]
        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_obbligatorio)
            {
                System.Web.UI.WebControls.RequiredFieldValidator rfv = new System.Web.UI.WebControls.RequiredFieldValidator();
                rfv.ID = this.ID + "_req";
                rfv.ControlToValidate = this.ID;
                rfv.Text = " *";
                rfv.ErrorMessage = _nomeCampo + " obbligatorio";
                rfv.EnableViewState = false;
                Controls.Add(rfv);
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            if (_dataColumn == null)
                return;

            object o = BindValue();
            if (o == DBNull.Value)
                _text = "";
            else
                _text = getString(o);
            base.OnDataBinding(e);
        }

        protected object BindValue()
        {
            Page lp = (SiarLibrary.Web.Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            return (lp.DataSource).GetType().GetProperty(DataColumn).GetValue(lp.DataSource, null);//.ToString();
        }

        protected virtual string getString(object str)
        {
            if (str is string)
                return (string)str;
            if (str is DateTime)
                return ((DateTime)str).ToString("dd/MM/yyyy");
            return Convert.ToString(str);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("hidden:");
                writer.Write(_dataColumn == null ? "UNBINDED" : _dataColumn);
                return;
            }
            writer.Write("<input type='hidden' name='" + this.UniqueID + "' id='" + this.UniqueID.Replace("$", "_") + "' value=\"" + _text + "\">");
            RenderChildren(writer);
        }


        //// Defines the Click event.
        //public event EventHandler TextChange;

        ////Invoke delegates registered with the Click event.
        //protected virtual void OnTextChange(EventArgs e)
        //{
        //    //if (TextChange != null)
        //    //{
        //    TextChange(this, e);                
        //    //}
        //}


        //// Define the method of IPostBackEventHandler that raises change events.
        //public void RaisePostBackEvent(string eventArgument)
        //{
        //    OnTextChange(new EventArgs());
        //}
    }

    public class Label : System.Web.UI.Control
    {
        public Label() : base() { }

        string _text;
        private string _dataColumn, _currencyFormat;
        [System.ComponentModel.DefaultValue("")]
        public string DataColumn
        {
            get { return _dataColumn; }
            set { _dataColumn = value; }
        }

        public string CurrencyFormat
        {
            get { return _currencyFormat; }
            set { _currencyFormat = value; }
        }

        public string Text
        {
            get { return (_text == "" ? null : _text); }
            set { _text = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            base.EnableViewState = false;
            if (Page.IsPostBack)
                _text = Page.Request.Form[this.UniqueID];
        }

        [System.ComponentModel.Browsable(false)]
        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            if (_dataColumn == null)
                return;

            object o = BindValue();
            if (o == DBNull.Value)
                _text = "";
            else if (!string.IsNullOrEmpty(_currencyFormat))
                _text = string.Format(_currencyFormat, o);
            //else if(_currencyFormat=="{0:N}")
            //    _text=getCurrencyFormat(o);
            else _text = getString(o);
            base.OnDataBinding(e);
        }

        protected object BindValue()
        {
            SiarLibrary.Web.Page lp = (SiarLibrary.Web.Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }

        protected virtual string getString(object str)
        {
            if (str is string)
                return (string)str;
            if (str is DateTime)
                return ((DateTime)str).ToString("dd/MM/yyyy");
            return Convert.ToString(str);
        }

        //protected string getCurrencyFormat(object str)
        //{
        //    string s,r="";			
        //    s=str.ToString();
        //    if(s.Length==s.LastIndexOf(',')+3)
        //    {
        //        r=s.Substring(s.Length-3);
        //        s=s.Substring(0,s.Length-3);

        //        while(((decimal)s.Length/3)>1)
        //        {
        //            r="."+s.Substring(s.Length-3)+r;
        //            s=s.Substring(0,s.Length-3);									
        //        }
        //    }
        //    return Convert.ToString(s+r);
        //}

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write(_dataColumn == null ? "UNBINDED" : _dataColumn);
                return;
            }
            writer.Write("<input type='hidden' name='" + this.UniqueID + "' value=\"" + _text + "\"><span ID=\"" + this.UniqueID + "_text\">" + _text + "</span>");
        }
    }

    public class CheckBoxList : System.Web.UI.WebControls.CheckBoxList
    {
        public override string SelectedValue
        {
            get
            {
                string retval = "", pattern = this.UniqueID + "_chkli_";
                foreach (string s in Page.Request.Form.AllKeys)
                    if (s.Contains(pattern)) retval += s.Substring(s.IndexOf(pattern) + pattern.Length) + "|";
                if (retval.Length > 0) retval = retval.Substring(0, retval.Length - 1);
                return retval;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    foreach (string s in value.Split('|'))
                    {
                        ListItem li = Items.FindByValue(s);
                        if (li != null) li.Selected = true;
                    }
                }
            }
        }

        public void BindItems(System.Collections.Generic.Dictionary<string, string> dict)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, string> d in dict)
                Items.Add(new ListItem(d.Key, d.Value));
        }

        protected override void RenderItem(ListItemType itemType, int repeatIndex, RepeatInfo repeatInfo, HtmlTextWriter writer)
        {
            CheckBox cb = new CheckBox();
            cb.Page = Page;
            cb.ID = UniqueID + "_chkli_" + this.Items[repeatIndex].Value;
            cb.Text = Items[repeatIndex].Text;
            //cb.Attributes["value"] = Items[repeatIndex].Value;
            cb.Checked = Items[repeatIndex].Selected;
            cb.TextAlign = TextAlign;
            //cb.AutoPostBack = AutoPostBack;
            //cb.TabIndex = TabIndex;
            cb.Enabled = Enabled;
            //cb.EnableViewState = EnableViewState;
            cb.Style.Add("padding", "2px");
            cb.RenderControl(writer);
        }
    }
}
