using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace web.CONTROLS
{
    public partial class ZoomLoader : UserControl
    {
        //-------------------------------------------
        //properties da valorizzare nella pagina aspx
        //(*=obbligatori)

        private string _searchMethod; //(*)
        public string SearchMethod
        {
            get { return _searchMethod; }
            set { _searchMethod = value; }
        }

        private string _columnsToBind; //(*)
        public string ColumnsToBind
        {
            get { return _columnsToBind; }
            set { _columnsToBind = value; }
        }

        /// <summary>
        /// default key value
        /// </summary>
        private string _keyValue; //(*)
        public string KeyValue
        {
            get { return _keyValue; }
            set { _keyValue = value; }
        }

        /// <summary>
        /// default key text
        /// </summary>
        private string _keyText; //(*)
        public string KeyText
        {
            get { return _keyText; }
            set { _keyText = value; }
        }
        /// <summary>
        /// string che definisce i parametri di ricerca, vengono bindati automaticamente
        /// se non valorizzata avvia la ricerca automatica
        /// </summary>
        private string _keySearch;
        public string KeySearch
        {
            get { return _keySearch; }
            set { _keySearch = value; }
        }

        private bool _automaticSearch = false;
        public bool AutomaticSearch
        {
            get { return _automaticSearch; }
            set { _automaticSearch = value; }
        }

        private bool _abilitaModifica = true;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }

        //da valorizzare solo se Obbligatorio=true
        public string Name { set { hdnSNZSelectedValue.NomeCampo = value; } }

        public bool Obbligatorio
        {
            get { return hdnSNZSelectedValue.Obbligatorio; }
            set { hdnSNZSelectedValue.Obbligatorio = value; }
        }

        private string _width;
        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private bool _iconaPiccola = false;
        public bool IconaPiccola { set { _iconaPiccola = value; } }

        private bool _visible = true;
        public new bool Visible { set { _visible = value; } }

        /// <summary>
        /// nasconde il pulsante cancella selezione
        /// </summary>
        private bool _noClear = true;
        public string NoClear { set { bool.TryParse(value, out _noClear); } }

        /// <summary>
        /// nasconde il pulsante cerca
        /// </summary>
        private bool _noSearch = false;
        public bool NoSearch { set { _noSearch = value; } }

        private string _titoloFinestra;
        public string TitoloFinestra { set { _titoloFinestra = value; } }

        private string _searchFunction;
        public string SearchFunction { get { return _searchFunction; } }

        //gestore evento item selezionato nello zoom se non valorizzato prende il comportamento di default
        private string _jsSelectedItemHandler;
        public string JsSelectedItemHandler
        {
            get { return _jsSelectedItemHandler; }
            set { _jsSelectedItemHandler = value; }
        }

        //-----------------------------------output
        public string SelectedValue  //valori
        {
            get { return hdnSNZSelectedValue.Text; }
            set { hdnSNZSelectedValue.Text = value; }
        }
        public string SelectedText
        {
            get { return hdnSNZSelectedText.Text; }
            set { hdnSNZSelectedText.Text = value; lblSNZSelectedText.Text = value; }
        }
        public string SelectedValueControl { get { return hdnSNZSelectedValue.UniqueID.Replace('$', '_'); } }//controlli
        public string SelectedTextControl { get { return hdnSNZSelectedText.UniqueID.Replace('$', '_'); } }
        //---------------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            initZoomSessionParameter();
            _searchFunction = _abilitaModifica ? "mostraPopupTemplate('" + tbZoomMain.UniqueID.Replace('$', '_') + "','divBKGMessaggio');"
                + (_automaticSearch ? "runZoomSearch('" + this.ID + "',0);" : "") : "alert('Attenzione! La modifica dei dati è disabilitata.');";
            if (_noSearch) imgZApri.Style.Add("display", "none");
            else
            {
                if (_iconaPiccola) imgZApri.Src = "~/images/folderopen.png";
                else imgZApri.Src = "~/images/lente.gif";
                imgZApri.Attributes.Add("onclick", _searchFunction);
            }

            if (_noClear) imgZChiudi.Style.Add("display", "none");
            else
            {
                imgZChiudi.Src = "~/images/xdel.gif";
                imgZChiudi.Attributes.Add("onclick", _abilitaModifica ? "zoomUnSelectItem('" + this.ID + "'," + (string.IsNullOrEmpty(_jsSelectedItemHandler) ? "null" :
                    _jsSelectedItemHandler) + ");" : "alert('Attenzione! La modifica dei dati è disabilitata.');");
            }
            tbZoomMain.Width = string.IsNullOrEmpty(_width) ? "500px" : _width;
            btnCerca.Attributes.Add("onclick", _abilitaModifica ? "runZoomSearch('" + this.ID + "',0)" : "alert('Attenzione! La modifica dei dati è disabilitata.');");
            CaricaTableParametri();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_unselectItem)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "jspost" + this.ID + "handlerscript", "zoomUnSelectItem('" + this.ID
                    + "'," + (string.IsNullOrEmpty(_jsSelectedItemHandler) ? "null" : _jsSelectedItemHandler) + ");", true);
            }
            else if (!string.IsNullOrEmpty(hdnSNZSelectedText.Text))
            {
                //la label non mantiene lo stato dopo un postback devo riscriverla
                if (string.IsNullOrEmpty(_jsSelectedItemHandler)) lblSNZSelectedText.Text = hdnSNZSelectedText.Text;
                // commentata per ora non ce n'e' bisogno
                //else ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "jspost" + this.ID + "handlerscript", _jsSelectedItemHandler + "('"
                //    + hdnSNZSelectedValue.Text + "','" + hdnSNZSelectedText.Text + "',false);", true);
            }
            if (!_visible) { imgZApri.Style.Add("display", "none"); imgZChiudi.Style.Add("display", "none"); }
            if (!string.IsNullOrEmpty(_titoloFinestra)) tdZLTitolo.InnerText = _titoloFinestra;
            base.OnPreRender(e);
        }

        private void initZoomSessionParameter()
        {
            ZoomSessionParameter zsp = new ZoomSessionParameter();
            zsp.ColumnsToBind = _columnsToBind.Split('|');
            zsp.KeyValue = _keyValue.Split('|');
            zsp.KeyText = _keyText.Split('|');
            zsp.SearchMethod = _searchMethod;
            if (!string.IsNullOrEmpty(_keySearch)) zsp.KeySearch = _keySearch.Split('|');
            zsp.JsSelectedItemHandler = _jsSelectedItemHandler;
            Session["zsp_session_object_" + this.ID] = zsp;
        }

        private void CaricaTableParametri()
        {
            bool mostra_pulsante_cerca = false;
            if (!string.IsNullOrEmpty(_keySearch))
            {
                HtmlTable tb = new HtmlTable();
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                td.InnerHtml = "&nbsp;";
                td.ColSpan = 2;
                tr.Cells.Add(td);
                tb.Rows.Add(tr);

                HtmlTableCell td_nome, td_controllo;
                string testo_parametro, chiave_parametro, tipo_parametro, nome_combo = null;
                foreach (string parametro in _keySearch.Split('|'))
                {
                    string[] dati_parametro = parametro.Split(':');
                    testo_parametro = dati_parametro[0];
                    chiave_parametro = dati_parametro.Length > 1 ? dati_parametro[1] : dati_parametro[0];
                    tipo_parametro = dati_parametro.Length > 2 ? dati_parametro[2] : null;
                    if (dati_parametro.Length > 3) nome_combo = dati_parametro[3];
                    if (tipo_parametro == "h")
                    {
                        HtmlInputHidden hdn = new HtmlInputHidden();
                        hdn.ID = testo_parametro;
                        hdn.Value = chiave_parametro;
                        hdn.Attributes.Add("keyValueSearchGroup", this.ID);
                        hdn.Attributes.Add("keyValueSearch", testo_parametro);
                        td.Controls.Add(hdn);
                    }
                    else
                    {
                        //testo parametro
                        tr = new HtmlTableRow();
                        td_nome = new HtmlTableCell();
                        td_nome.InnerHtml = dati_parametro[0] + ":";
                        tr.Cells.Add(td_nome);

                        #region textbox parametro
                        td_controllo = new HtmlTableCell();
                        string id_controllo = this.ID + "KParam" + chiave_parametro;
                        switch (tipo_parametro)
                        {
                            case "i":
                                SiarLibrary.Web.IntegerTextBox ibox = new SiarLibrary.Web.IntegerTextBox();
                                ibox.ID = "txt" + id_controllo;
                                ibox.NoCurrency = true;
                                ibox.Width = new System.Web.UI.WebControls.Unit(100);
                                ibox.AddInnerAttribute("keyValueSearchGroup", this.ID);
                                ibox.AddInnerAttribute("keyValueSearch", chiave_parametro);
                                td_controllo.Controls.Add(ibox);
                                break;
                            case "d":
                                SiarLibrary.Web.DateTextBox dbox = new SiarLibrary.Web.DateTextBox();
                                dbox.ID = "txt" + id_controllo;
                                dbox.Width = new System.Web.UI.WebControls.Unit(100);
                                dbox.AddInnerAttribute("keyValueSearchGroup", this.ID);
                                dbox.AddInnerAttribute("keyValueSearch", chiave_parametro);
                                td_controllo.Controls.Add(dbox);
                                td_controllo.Controls.Add(new LiteralControl("(click con il destro per il calendario)"));
                                break;
                            //case "s":
                            //    SiarLibrary.Web.TextBox sbox = new SiarLibrary.Web.TextBox();
                            //    sbox.ID = "txt" + id_controllo;
                            //    sbox.Width = new System.Web.UI.WebControls.Unit(100);
                            //    sbox.Attributes.Add("keyValueSearchGroup", this.ID);
                            //    sbox.Attributes.Add("keyValueSearch", chiave_parametro);
                            //    td_controllo.Controls.Add(sbox);
                            //    break;
                            case "lst":
                                object combo = System.Activator.CreateInstance("SiarLibrary.Web", "SiarLibrary.Web." + nome_combo).Unwrap();
                                combo.GetType().GetMethod("DataBind").Invoke(combo, null);
                                ((System.Web.UI.WebControls.WebControl)combo).Attributes.Add("keyValueSearchGroup", this.ID);
                                ((System.Web.UI.WebControls.WebControl)combo).Attributes.Add("keyValueSearch", chiave_parametro);
                                td_controllo.Controls.Add((System.Web.UI.WebControls.WebControl)combo);
                                break;
                            default:
                                SiarLibrary.Web.TextBox defbox = new SiarLibrary.Web.TextBox();
                                defbox.ID = "txt" + id_controllo;
                                defbox.Width = new System.Web.UI.WebControls.Unit(100);
                                defbox.AddInnerAttribute("keyValueSearchGroup", this.ID);
                                defbox.AddInnerAttribute("keyValueSearch", chiave_parametro);
                                td_controllo.Controls.Add(defbox);
                                break;
                        }
                        #endregion

                        tr.Cells.Add(td_controllo);
                        tb.Rows.Add(tr);
                        mostra_pulsante_cerca = true;
                    }
                }
                tdParametri.Controls.Add(tb);
            }
            btnCerca.Visible = mostra_pulsante_cerca;
        }

        private bool _unselectItem = false;
        public void UnselectItem() { _unselectItem = true; }
    }

    public class ZoomSessionParameter
    {
        private string _searchMethod;
        public string SearchMethod
        {
            get { return _searchMethod; }
            set { _searchMethod = value; }
        }
        private string[] _columnsToBind;
        public string[] ColumnsToBind
        {
            get { return _columnsToBind; }
            set { _columnsToBind = value; }
        }

        private string[] _keyValue;
        public string[] KeyValue
        {
            get { return _keyValue; }
            set { _keyValue = value; }
        }

        private string[] _keyText;
        public string[] KeyText
        {
            get { return _keyText; }
            set { _keyText = value; }
        }

        private string[] _keySearch;
        public string[] KeySearch
        {
            get { return _keySearch; }
            set { _keySearch = value; }
        }
        private string _jsSelectedItemHandler;
        public string JsSelectedItemHandler
        {
            get { return _jsSelectedItemHandler; }
            set { _jsSelectedItemHandler = value; }
        }
    }
}