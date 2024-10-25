using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SiarLibrary.Web
{
    /// <summary>
    /// Summary description for SiarTextBox.
    /// </summary>
    public class TextBox : TextBoxBase
    {    
        public string TextAlign
        {
            set { _tb.Style["text-align"] = value; }
        }

        public TextBox() 
            : base("Text") 
        {
            //base.CssClass = "rounded";

        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }

        protected override void Render(HtmlTextWriter writer)
        {            
            base.Render(writer);
        }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        //if (ReadOnly) AddJSAttribute("disabled", "disabled");
        //        //AddJSAttribute("onblur", "tb_blur($(this));");
        //        //AddJSAttribute("onfocus", "tb_focus($(this));");
        //        //AddJSAttribute("onkeypress", "tb_keypress($(this),event);");
        //        //if (Page != null)
        //        //{
        //        //    if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addPValue('TextBox');");
        //        //    else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scpttextbox", "$(document).ready(function(){addPValue('TextBox');});", true);
        //        //}

        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('TextBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptTextBox", "$(document).ready(function(){addEventHandlersByClass('TextBox');});", true);
        //    }
        //    base.OnInit(e);
        //}
    }

    public class TextArea : TextBase
    {
        public TextArea() : base("TextArea") { Rows = 3; }

        public override string Text
        {
            get { return Page.Server.HtmlDecode(_ta.Value); }
            set { _ta.Value = value; }
        }

        public new int MaxLength { set { _ta.Attributes.Add("maxlen", value.ToString()); } }

        [DefaultValue(-1)]
        public int Rows
        {
            get { return _ta.Rows; }
            set { _ta.Rows = value; }
        }

        private int _expandableRows;
        public int ExpandableRows
        {
            set { _expandableRows = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }

        HtmlTextArea _ta;
        protected override void initInput()
        {
            _ta = new HtmlTextArea();
            tb = _ta;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (_expandableRows > 0)
                writer.Write("<div class='textAreaButton'><input type=button class='btn btn-secondary py-0' "
                    + "value='Espandi ▼' onclick=\"TAExpand(this," + _expandableRows + ",true);\" /><input type=button class='btn btn-secondary py-0' "
                    + "value='Riduci ▲' onclick=\"TAExpand(this," + _expandableRows + ",false);\" /></div>");
        }
    }

    public class IntegerTextBox : TextBoxBase
    {
        private bool _noCurrency = false;
        public bool NoCurrency
        {
            get { return _noCurrency; }
            set { _noCurrency = value; }
        }

        private int _minValue = 0, _maxValue = 999999999;
        public int MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        public IntegerTextBox() : base("IntegerBox") { _tb.Style.Add("text-align", "right"); }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('IntegerBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptIntegerBox", "$(document).ready(function(){addEventHandlersByClass('IntegerBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = _noCurrency ? _maxValue.ToString() : string.Format("{0:N0}", _maxValue);
            rv.MinimumValue = _noCurrency ? _minValue.ToString() : string.Format("{0:N0}", _minValue);
            rv.ErrorMessage = NomeCampo + " non corretto (intervallo consentito: " + rv.MinimumValue + " - " + rv.MaximumValue + ")";
            rv.Text = " #";
            if (_noCurrency) rv.Type = ValidationDataType.Integer;
            else rv.Type = ValidationDataType.Currency;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return (Convert.ToInt32(str)).ToString();
        }

        protected override void OnPreRender(EventArgs e)
        {
            _tb.Attributes.Add("noCurrency", _noCurrency.ToString().ToLower());
            base.OnPreRender(e);
        }
    }

    public class AnnoTextBox : IntegerTextBox
    {
        private int _annoDa = 1900, _annoA = 2200;
        public int AnnoDa
        {
            get { return _annoDa; }
            set { _annoDa = value; }
        }
        public int AnnoA
        {
            get { return _annoA; }
            set { _annoA = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = _annoA.ToString();
            rv.MinimumValue = "0";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Integer;
            Controls.Add(rv);
        }
    }

    public class LatitudeBox : TextBoxBase
    {
        public LatitudeBox() : base("LatitudeBox") { _tb.Style.Add("text-align", "right"); }

        public override string Text
        {
            get
            {
                bool negativo = base.Text.IndexOf("S") > 0;
                string retval = base.Text.Replace("°", "").Replace("`", "").Replace("N", "").Replace("S", "");
                return (negativo ? "-" : "") + retval;
            }
            set
            {
                base.Text = value;
            }
        }
    }

    public class LongitudeBox : TextBoxBase
    {
        public LongitudeBox() : base("LongitudeBox") { _tb.Style.Add("text-align", "right"); }

        public override string Text
        {
            get
            {
                bool negativo = base.Text.IndexOf("W") > 0;
                string retval = base.Text.Replace("°", "").Replace("`", "").Replace("E", "").Replace("W", "");
                return (negativo ? "-" : "") + retval;
            }
            set
            {
                base.Text = value;
            }
        }
    }

    public class HaBox : TextBoxBase
    {
        public HaBox() : base("HaBox") { _tb.Style.Add("text-align", "right"); }

        public override string Text
        {
            get
            {
                return base.Text.Replace(".", "");
            }
            set
            {
                base.Text = value;
            }
        }
    }

    public class DateTextBoxAgid : TextBoxBase
    {
        public DateTextBoxAgid() : base("DataBoxAgid") {
            base.MaxLength = 10;
            _tb.Style.Add("text-align", "right");
            _tb.Attributes.Add("TextMode", "Date");
            _tb.Attributes.Add("Type", "Date");
        }

        public override int MaxLength { get { return 10; } }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('DataBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptDataBox", "$(document).ready(function(){addEventHandlersByClass('DataBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Width = new Unit(Width.Value - 10);
            //Controls.AddAt(1,new LiteralControl("<span style='width:10px;background-color:black'>C</span>"));

            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "2050-12-31";
            rv.MinimumValue = "1900-01-01";
            rv.Text = " #";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Type = ValidationDataType.Date;
            Controls.Add(rv);

            //			in sviluppo
            //HtmlGenericControl c = new HtmlGenericControl();
            //c.ID = this.ID + "_cal";
            //c.Style.Add("POSITION", "ABSOLUTE");
            //Controls.Add(c);
        }
        protected override string getString(object str)
        {
            try
            {
                return ((DateTime)str).ToString("yyyy-MM-dd");
            }
            catch
            {
                return str.ToString();
            }
        }
        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            if (o == null) return "";
            NullTypes.DatetimeNT dt = new NullTypes.DatetimeNT(DateTime.Parse(o.ToString()));
            return dt.ToFullYearString();
            //return (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null).ToString();
        }
    }

    public class DateTextBox : TextBoxBase
    {
        public DateTextBox() : base("DataBox") { base.MaxLength = 10; _tb.Style.Add("text-align", "right"); }

        public override int MaxLength { get { return 10; } }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('DataBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptDataBox", "$(document).ready(function(){addEventHandlersByClass('DataBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Width = new Unit(Width.Value - 10);
            //Controls.AddAt(1,new LiteralControl("<span style='width:10px;background-color:black'>C</span>"));

            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "31/12/2050";
            rv.MinimumValue = "01/01/1900";
            rv.Text = " #";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Type = ValidationDataType.Date;
            Controls.Add(rv);

            //			in sviluppo
            //HtmlGenericControl c = new HtmlGenericControl();
            //c.ID = this.ID + "_cal";
            //c.Style.Add("POSITION", "ABSOLUTE");
            //Controls.Add(c);
        }
        protected override string getString(object str)
        {
            try
            {
                return ((DateTime)str).ToString("dd/MM/yyyy");
            }
            catch
            {
                return str.ToString();
            }
        }
        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            if (o == null) return "";
            NullTypes.DatetimeNT dt = new NullTypes.DatetimeNT(DateTime.Parse(o.ToString()));
            return dt.ToFullYearString();
            //return (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null).ToString();
        }
    }

    public class ClockBox : TextBoxBase
    {
        public ClockBox()
            : base("ClockBox")
        {
            _tb.Style.Add("text-align", "right");

        }
        public override string Text
        {
            get
            {
                return base.Text.Replace(".", "");
            }
            set
            {
                base.Text = value;
            }
        }
    }

    public class DecimalBox : TextBoxBase
    {
        public DecimalBox() : base("DecimalBox") { _tb.Style.Add("text-align", "right"); }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('DecimalBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptDecimalBox", "$(document).ready(function(){addEventHandlersByClass('DecimalBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "9999999999,99";
            rv.MinimumValue = "0";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Currency;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string)
                return base.getString(str);
            return Convert.ToString(str);
        }

        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value.Replace(".", "")); }
            set { _tb.Value = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class QuotaBox : TextBoxBase
    {
        public QuotaBox() : base("QuotaBox") { _tb.Style.Add("text-align", "right"); }

        private int _nrDecimali = 2;
        public int NrDecimali
        {
            get { return _nrDecimali; }
            set { _nrDecimali = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "100";
            rv.MinimumValue = "0";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Double;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return Convert.ToString(str);
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class CurrencyBox : TextBoxBase
    {
        public CurrencyBox() : base("CurrencyBox") { _tb.Style.Add("text-align", "right"); }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('CurrencyBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptCurrencyBox", "$(document).ready(function(){addEventHandlersByClass('CurrencyBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "9999999999,99";
            rv.MinimumValue = "-9999999999,99";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Currency;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return Convert.ToString(str);
        }
        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value.Replace(".", "")); }
            set { _tb.Value = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class PercentageBox : TextBoxBase
    {
        public PercentageBox() : base("PercentageBox") { _tb.Style.Add("text-align", "right"); }

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!DesignMode)
        //    {
        //        if (Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("addEventHandlersByClass('PercentageBox');");
        //        else Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scptPercentageBox", "$(document).ready(function(){addEventHandlersByClass('PercentageBox');});", true);
        //    }
        //    base.OnInit(e);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "9999999999,999999999999";
            rv.MinimumValue = "-9999999999,999999999999";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Double;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return Convert.ToString(str);
        }
        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value.Replace(".", "")); }
            set { _tb.Value = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class PunteggioBox : TextBoxBase
    {
        public PunteggioBox() : base("PunteggioBox") { _tb.Style.Add("text-align", "right"); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "9999999999,999999";
            rv.MinimumValue = "-9999999999,999999";

            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Double;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return Convert.ToString(str);
        }
        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value.Replace(".", "")); }
            set { _tb.Value = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class PlvBox : TextBoxBase
    {
        public PlvBox() : base("PlvBox") { _tb.Style.Add("text-align", "right"); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RangeValidator rv = new RangeValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_ran";
            rv.MaximumValue = "99999999,9999";
            rv.MinimumValue = "0";
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            rv.Type = ValidationDataType.Double;
            Controls.Add(rv);
        }

        protected override string getString(object str)
        {
            if (str is string) return base.getString(str);
            return Convert.ToString(str);
        }
        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value.Replace(".", "")); }
            set { _tb.Value = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    public class RegExpTextBox : TextBox
    {
        public RegExpTextBox() : base() { }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegularExpressionValidator rv = new RegularExpressionValidator();
            rv.ControlToValidate = this.ID + "_text";
            rv.ID = this.ID + "_reg";
            rv.ValidationExpression = _valExpr;
            rv.ErrorMessage = NomeCampo + " non corretto";
            rv.Text = " #";
            Controls.Add(rv);
        }

        private string _valExpr;
        [System.ComponentModel.Editor("System.Web.UI.Design.WebControls.RegexTypeEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public string ValidationExpression
        {
            get { return _valExpr; }
            set { _valExpr = value; }
        }

        protected override object BindValue()
        {
            Page lp = (Page)this.Page;
            if (null == lp.DataSource) return DBNull.Value;
            object o = (lp.DataSource).GetType().GetProperty(base.DataColumn).GetValue(lp.DataSource, null);
            return (o == null ? "" : o.ToString());
        }
    }

    #region base

    [ValidationProperty("Text")]
    public class TextBase : WebControl
    {
        private string _label;
        [System.ComponentModel.DefaultValue("")]
        public string Label
        {
            get { return _label; }
            set { _label = value; }

        }


        protected HtmlControl tb;
        string _cssClass, _nomeCampo, _dataColumn;

        protected TextBase(string cssClass)
            : base()
        {
            //_cssClass = string.Join(" ", cssClass, "rounded");
           
            _cssClass = cssClass;
            initInput();
            tb.EnableViewState = false;
            base.EnableViewState = false;
        }

        //// modifiche agid
        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{            
        //    base.RenderBeginTag(writer);
        //    writer.Write("<label for='" + this.ClientID + "' class='active'>" + _label + "</label>");
        //}

        //// modifiche agid
        //public override void RenderEndTag(HtmlTextWriter writer)
        //{
        //    writer.Write("");
        //}

        protected virtual void initInput()
        {
        }

        public override bool EnableViewState
        {
            get { return false; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            tb.ID = base.ID + "_text";
            //tb.Attributes.Add("placeholder", _label);
            tb.Attributes.Add("class", "form-control rounded");
            HtmlGenericControl label = new HtmlGenericControl("label");
            label.Attributes.Add("for", base.ClientID + "_text");            
            label.Attributes.Add("class", "active");
            if (_obbligatorio)
                label.InnerText = "(*) " + _label;
            else
                label.InnerText = _label;
            Controls.Add(label);
            Controls.Add(tb);
        }

        public void AddJSAttribute(string key, string script)
        {
            string old_script = tb.Attributes[key];
            tb.Attributes.Add(key, old_script + script + (script.Substring(script.Length - 1, 1) != ";" ? ";" : ""));
        }

        public void AddInnerAttribute(string key, string value)
        {
            tb.Attributes.Add(key, value);
        }


        protected override void OnLoad(EventArgs e)
        {
            if (_obbligatorio)
            {
                RequiredFieldValidator rfv = new RequiredFieldValidator();
                rfv.ID = this.ID + "_req";
                rfv.ControlToValidate = tb.ID;
                //rfv.Text = " *";
                rfv.ErrorMessage = _nomeCampo + " obbligatorio";
                rfv.Display = ValidatorDisplay.Dynamic;
                rfv.Attributes.Add("class", "form-feedback just-validate-error-label");
                rfv.EnableViewState = false;
                Controls.Add(rfv);
                //				if(!Page.IsPostBack)
                //					rfv.Validate();
            }
            base.OnLoad(e);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
//#if(DEBUG)
//            if (DesignMode)
//            {
//                writer.Write("<input type=text value=\"" + (ReadOnly ? "ro|" : "") + (_obbligatorio ? "ob|" : "") + _dataColumn + "\" style=\"WIDTH:" + Width.ToString() + "\">");
//                return;
//            }
//#endif
            //int nVal = Controls.Count - 1;
            //tb.Style.Add("WIDTH", Width.ToString());
            //if (ReadOnly) tb.Style.Add("background-color", "#dddddd");
            //this.Width = Unit.Pixel((int)(Width.Value + nVal * 20));
            this.Attributes.Add("class", _cssClass);
            base.Render(writer);
        }

        public virtual string Text
        {
            get { return null; }
            set { }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return tb.Attributes["ReadOnly"] != null; }
            set
            {
                if (value)
                {
                    if (tb.Attributes["ReadOnly"] == null)
                        tb.Attributes.Add("ReadOnly", string.Empty);
                }
                else
                    tb.Attributes.Remove("ReadOnly");
            }
        }

        private bool _obbligatorio = false;
        [DefaultValue(false)]
        public bool Obbligatorio
        {
            get { return _obbligatorio; }
            set { _obbligatorio = value; }
        }

        [DefaultValue(-1)]
        public virtual int MaxLength
        {
            get { return -1; }
            set { }
        }

        [DefaultValue("")]
        public string DataColumn
        {
            get { return _dataColumn; }
            set { _dataColumn = value; }
        }

        [DefaultValue("")]
        public string NomeCampo
        {
            get { return _nomeCampo; }
            set { _nomeCampo = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            if (_dataColumn == null) return;
            object o = BindValue();
            if (o == DBNull.Value) Text = "";
            else Text = getString(o);
        }

        protected virtual string getString(object str)
        {
            return (string)str;
        }

        protected virtual object BindValue()
        {
            return "";
        }
    }

    public class TextBoxBase : TextBase
    {
        string _css;
        public TextBoxBase(string cssClass) : base(cssClass) { _css = cssClass; }

        protected HtmlInputText _tb;
        protected override void initInput()
        {
            _tb = new HtmlInputText();
            tb = _tb;
        }

        protected void AggiungiAttributo(string key, string suffissoFunction)
        {
            _tb.Attributes.Add(key, _css + suffissoFunction);
        }

        public override string Text
        {
            get { return (_tb.Value == "" ? null : _tb.Value); }
            set { _tb.Value = value; }
        }

        public override int MaxLength
        {
            get { return _tb.MaxLength; }
            set { _tb.MaxLength = value; }
        }
    }

    #endregion
}
