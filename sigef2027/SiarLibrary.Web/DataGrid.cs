using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace SiarLibrary.Web
{
    public class DataGrid : System.Web.UI.WebControls.DataGrid
    {
        public DataGrid()
            : base()
        {
            HeaderStyle.CssClass = "TESTA1";
            ItemStyle.CssClass = "DataGridRow";
            AlternatingItemStyle.CssClass = "DataGridRowAlt";
            PagerStyle.CssClass = "coda";
            base.EnableViewState = false;
        }

        Button btnDGPagingPost;
        HiddenField hdnNewPageIndex;
        private bool pageIndexSetted = false;
        public void SetPageIndex(int i)
        {
            if (this.AllowPaging)
            {
                CurrentPageIndex = i;
                pageIndexSetted = true;
            }
        }

        public override void DataBind()
        {
            if (!this.DesignMode && this.AllowPaging)
            {
                int new_index;
                if (!pageIndexSetted)
                {
                    foreach (string s in Page.Request.Form.AllKeys)
                        if (s != null && s.EndsWith("hdn" + this.ID + "NewPageIndex"))
                        {
                            int.TryParse(Page.Request.Form[s], out new_index);
                            CurrentPageIndex = new_index;
                        }
                }
            }
            try { base.DataBind(); }
            catch(Exception e) { string app = e.Message;  CurrentPageIndex = 0; base.DataBind(); }
        }

        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }

        private bool _nrColumnSearch = false;
        public bool NrColumnSearch
        {
            set { _nrColumnSearch = value; }
            get { return _nrColumnSearch; }
        }

        protected override void OnInit(EventArgs e)
        {
            /*if (this.AllowPaging)
            {
                string s = Page.Request.Form[UniqueID + "_pag"];
                if (s != null)
                    this.CurrentPageIndex = int.Parse(s) - 1;
            }*/
            if (_footerText != null)
            {
                base.ShowFooter = true;
                base.ItemDataBound += new DataGridItemEventHandler(TemplateDatagrid_ItemDataBound);
            }

            base.OnInit(e);
            this.ItemDataBound += new DataGridItemEventHandler(MostraTotale_ItemDataBound);
        }

        private string _path;
        /// <summary>
        /// Percorso in cui si trova la pagina (serve per il path delle immagini)
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _footerText;
        /// <summary>
        /// testo che deve mettere in fondo
        /// </summary>
        public string FooterText
        {
            get { return _footerText; }
            set { _footerText = value; }
        }

        //private bool _showShadow = true;
        ///// <summary>
        ///// Indica se mostrare o meno l'ombra
        ///// </summary>
        //[System.ComponentModel.DefaultValue(true)]
        //public bool ShowShadow
        //{
        //    get { return _showShadow; }
        //    set { _showShadow = value; }
        //}

        string _titolo;
        /// <summary>
        /// Titolo della tabella
        /// </summary>
        public string Titolo
        {
            get { return _titolo; }
            set { _titolo = value; }
        }

        public void SetTitoloNrElementi() { _titolo = "Elementi trovati: " + string.Format("{0:N0}", ((CustomCollection)DataSource).Count); }

        protected override void InitializePager(DataGridItem item, int columnSpan, PagedDataSource pagedDataSource)
        {
            #region old
            /*TableCell cell1;
            DataGridPagerStyle style1;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            Literal button3;
            int num8;
            string text1;
            System.Web.UI.WebControls.Label label3;
            int num9;
            cell1 = new TableCell();
            cell1.ColumnSpan = columnSpan;
            style1 = this.PagerStyle;
            num1 = pagedDataSource.PageCount;
            num2 = (pagedDataSource.CurrentPageIndex + 1);
            num3 = style1.PageButtonCount;
            num4 = num3;
            if (num1 < num4)
            {
                num4 = num1;

            }
            num5 = 1;
            num6 = num4;
            if (num2 > num6)
            {
                num7 = (pagedDataSource.CurrentPageIndex / num3);
                num5 = ((num7 * num3) + 1);
                num6 = ((num5 + num3) - 1);
                if (num6 > num1)
                {
                    num6 = num1;

                }
                if (((num6 - num5) + 1) < num3)
                {
                    num5 = Math.Max(1, ((num6 - num3) + 1));

                }

            }
            if (num5 != 1)
            {
                button3 = new Literal();
                num9 = (num5 - 2);
                button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, num9.ToString()) + "\">...</a>";
                cell1.Controls.Add(button3);
                cell1.Controls.Add(new LiteralControl(" "));


            }
            for (num8 = num5; (num8 <= num6); num8 = (num8 + 1))
            {
                text1 = num8.ToString();
                if (num8 == num2)
                {
                    label3 = new System.Web.UI.WebControls.Label();
                    label3.Text = text1 + "<input type=hidden name='" + this.UniqueID + "_pag' value='" + text1 + "'>";
                    cell1.Controls.Add(label3);
                    #region per check
                    foreach (DataGridColumn dgc in this.Columns)
                        if (dgc is IValoriImpaginati)
                            ((IValoriImpaginati)dgc).AddHiddenValue(cell1);
                    #endregion
                }
                else
                {
                    button3 = new Literal();
                    button3.Text = text1;
                    button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, (num8 - 1).ToString()) + "\">" + text1 + "</a>";
                    cell1.Controls.Add(button3);

                }
                if (num8 < num6)
                {
                    cell1.Controls.Add(new LiteralControl(" "));
                }
            }
            if (num1 > num6)
            {
                cell1.Controls.Add(new LiteralControl(" "));
                button3 = new Literal();
                button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, num6.ToString()) + "\">...</a>";
                cell1.Controls.Add(button3);
            }

            item.Cells.Add(cell1);*/
            #endregion
            if (CurrentPageIndex > pagedDataSource.Count) CurrentPageIndex = 0;

            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = columnSpan;
            btnDGPagingPost = new Button();
            btnDGPagingPost.CausesValidation = false;
            btnDGPagingPost.Style.Add("display", "none");
            btnDGPagingPost.ID = "btn" + this.ID + "PagingPost";
            hdnNewPageIndex = new HiddenField();
            hdnNewPageIndex.ID = "hdn" + this.ID + "NewPageIndex";
            cell1.Controls.Add(hdnNewPageIndex);
            cell1.Controls.Add(btnDGPagingPost);

            DataGridPagerStyle style1 = this.PagerStyle;
            int num1, num2, num3, num4, num5, num6, num7, num8, num9;
            Literal button3;
            System.Web.UI.WebControls.Label label3;
            string text1;
            num1 = pagedDataSource.PageCount;
            num2 = (pagedDataSource.CurrentPageIndex + 1);
            num3 = style1.PageButtonCount;
            num4 = num3;
            if (num1 < num4) num4 = num1;
            num5 = 1;
            num6 = num4;
            if (num2 > num6)
            {
                num7 = (pagedDataSource.CurrentPageIndex / num3);
                num5 = ((num7 * num3) + 1);
                num6 = ((num5 + num3) - 1);
                if (num6 > num1) num6 = num1;
                if (((num6 - num5) + 1) < num3) num5 = Math.Max(1, ((num6 - num3) + 1));
            }
            if (num5 != 1)
            {
                button3 = new Literal();
                num9 = (num5 - 2);
                button3.Text = "<a href=\"javascript:$('[id$=hdn" + this.ID + "NewPageIndex]').val(" + num9.ToString()
                    + ");$('[id$=btn" + this.ID + "PagingPost]')[0].click();\">...</a>";
                cell1.Controls.Add(button3);
                cell1.Controls.Add(new LiteralControl(" "));
            }
            for (num8 = num5; (num8 <= num6); num8++)
            {
                text1 = num8.ToString();
                if (num8 == num2)
                {
                    hdnNewPageIndex.Value = CurrentPageIndex.ToString();
                    label3 = new System.Web.UI.WebControls.Label();
                    label3.Text = text1;// +"<input type=hidden name='" + this.UniqueID + "_pag' value='" + text1 + "'>";
                    cell1.Controls.Add(label3);
                    // per check
                    foreach (DataGridColumn dgc in this.Columns) if (dgc is IValoriImpaginati) ((IValoriImpaginati)dgc).AddHiddenValue(cell1);
                }
                else
                {
                    button3 = new Literal();
                    button3.Text = text1;
                    button3.Text = "<a href=\"javascript:$('[id$=hdn" + this.ID + "NewPageIndex]').val(" + (num8 - 1).ToString()
                        + ");$('[id$=btn" + this.ID + "PagingPost]')[0].click();\">" + text1 + "</a>";
                    cell1.Controls.Add(button3);

                }
                if (num8 < num6) cell1.Controls.Add(new LiteralControl(" "));
            }
            if (num1 > num6)
            {
                cell1.Controls.Add(new LiteralControl(" "));
                button3 = new Literal();
                button3.Text = "<a href=\"javascript:$('[id$=hdn" + this.ID + "NewPageIndex]').val(" + num6.ToString()
                    + ");$('[id$=btn" + this.ID + "PagingPost]')[0].click();\">...</a>";
                cell1.Controls.Add(button3);
            }
            cell1.Style.Add("padding-left", "5px");
            item.Cells.Add(cell1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.PagerStyle.PageButtonCount = 25;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
#if(DEBUG)
            //if ((this.Site != null) && (this.Site.DesignMode))
            if (this.DesignMode)
            {
                base.Render(writer);
                return;
            }
#endif
            if (!string.IsNullOrEmpty(_titolo))
                writer.Write("<div class='dgTitolo'>" + _titolo + "</div>");
            if (Items.Count == 0) return;
            writer.Write("<table cellspacing='0' cellpadding='0' border='0' width=" + Width + ">\n" +
                "<tr>\n<td valign='top'>\n");
            base.Render(writer);
            writer.Write("</td>\n</tr>\n</table>\n");
        }

        private void TemplateDatagrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                TableCell td = e.Item.Cells[0];
                int nCol = base.Columns.Count;
                td.ColumnSpan = nCol;
                td.CssClass = "coda";
                td.Text = _footerText;
                for (int i = 1; i < nCol; i++)
                    e.Item.Cells.RemoveAt(1);
            }
        }

        #region mostra totali
        public string[] DataFieldNames = null;
        private bool abilita_totali_footer = false;
        private bool is_totale_punteggio = false;

        /*public void MostraTotale(string[] DataColumn, params  int[] IndexColumn)
        {
            abilita_totali_footer = true;
            if (IndexColumn.Length != DataColumn.Length) throw new Exception("Parametri non corretti.");
            for (int i = 0; i < IndexColumn.Length; i++) MostraTotale(IndexColumn[i], DataColumn[i]);
        }*/

        public void MostraTotalePunteggio(string DataField, params  int[] IndexColumn)
        {
            is_totale_punteggio = true;
            abilita_totali_footer = true;
            for (int i = 0; i < IndexColumn.Length; i++)
            {
                System.Type tipoColonna = (Columns[IndexColumn[i]]).GetType();
                MostraTotale(IndexColumn[i], tipoColonna.GetProperty(DataField).GetValue(Columns[IndexColumn[i]], null).ToString());
            }
        }

        public void MostraTotale(string DataField, params  int[] IndexColumn)
        {
            abilita_totali_footer = true;
            for (int i = 0; i < IndexColumn.Length; i++)
            {
                System.Type tipoColonna = (Columns[IndexColumn[i]]).GetType();
                MostraTotale(IndexColumn[i], tipoColonna.GetProperty(DataField).GetValue(Columns[IndexColumn[i]], null).ToString());
            }
        }

        public void MostraTotale(int IndexColumn, string DataColumn)
        {
            abilita_totali_footer = true;
            if (DataFieldNames == null)
            {
                FooterStyle.CssClass = "TotaliFooter";
                DataFieldNames = new string[Columns.Count];
            }
            DataFieldNames[IndexColumn] = DataColumn;
        }

        private void MostraTotale_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (abilita_totali_footer && e.Item.ItemType != ListItemType.Header)
            {
                if (DataFieldNames == null) DataFieldNames = new string[Columns.Count];
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    if (FooterText == null) e.Item.Cells[0].Text = "TOTALE";
                    //Modifica 24/09/2018 ridichiaro cc ed eseguo una prova di cast per poter utilizzare anche le Generics oltre che le CustomCollection
                    //In caso di problemi ripristinare la riga commentata e commentare dalla riga successiva fino a fine modifica
                    //CustomCollection cc = (CustomCollection)DataSource;
                    System.Collections.IList cc;
                    cc = DataSource as CustomCollection;
                    if(cc == null)
                    {
                        cc = (System.Collections.IList)DataSource;
                    }
                    //Fine modifica 24/09/2018
                    if (cc == null || cc.Count == 0) return;
                    System.Type tipo = cc[0].GetType();
                    for (int counter = 0; counter < Columns.Count; counter++)
                    {
                        if (!string.IsNullOrEmpty(DataFieldNames[counter]))
                        {
                            ShowFooter = true;
                            decimal somma = 0, valore;
                            for (int i = 0; i < cc.Count; i++)
                            {
                                object o = tipo.GetProperty(DataFieldNames[counter]).GetValue(cc[i], null);
                                if (o != null)
                                {
                                    decimal.TryParse(o.ToString(), out valore);
                                    somma += valore;
                                }
                            }
                            string formato = "";
                            if ((Columns[counter]).GetType().Name != "TemplateColumn")
                                formato = ((System.Web.UI.WebControls.BoundColumn)(Columns[counter])).DataFormatString;
                            e.Item.Cells[counter].Attributes.Add("id", this.UniqueID.Replace('$', '_') + "_tdTotalFooter" + counter);
                            if (is_totale_punteggio)
                                e.Item.Cells[counter].Text = string.Format((string.IsNullOrEmpty(formato) ? "{0:#,0.000}" : formato), somma);
                            else
                                e.Item.Cells[counter].Text = string.Format((string.IsNullOrEmpty(formato) ? "{0:N}" : formato), somma);
                        }
                    }
                }
                else
                {
                    for (int counter = 0; counter < Columns.Count; counter++)
                    {
                        if (!string.IsNullOrEmpty(DataFieldNames[counter]))
                        {
                            string testo_cella = e.Item.Cells[counter].Text.Replace("<input", "<input onblur=\"cm_setTotalFooter(this,'"
                                + this.UniqueID.Replace('$', '_') + "_tdTotalFooter" + counter + "');\"");
                            e.Item.Cells[counter].Text = testo_cella;
                        }
                    }
                }
            }
        }
        #endregion
    }

    //non usata controlla se eliminare
    public class ZoomDataGrid : DataGrid, IPostBackEventHandler
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.AllowPaging)
            {
                string s = Page.Request.Form[UniqueID + "_pag"];
                if (s != null)
                    this.CurrentPageIndex = int.Parse(s) - 1;
            }
            base.OnInit(e);
        }

        public override void DataBind()
        {
            try { base.DataBind(); }
            catch { this.CurrentPageIndex = 0; base.DataBind(); }
        }

        protected override void InitializePager(DataGridItem item, int columnSpan, PagedDataSource pagedDataSource)
        {
            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = columnSpan;
            DataGridPagerStyle style1 = this.PagerStyle;
            Literal button3;
            string text1;
            System.Web.UI.WebControls.Label label3;
            int num1, num2, num3, num4, num5, num6, num7, num8, num9;
            num1 = pagedDataSource.PageCount;
            num2 = (pagedDataSource.CurrentPageIndex + 1);
            num3 = style1.PageButtonCount;
            num4 = num3;
            if (num1 < num4) num4 = num1;
            num5 = 1;
            num6 = num4;
            if (num2 > num6)
            {
                num7 = (pagedDataSource.CurrentPageIndex / num3);
                num5 = ((num7 * num3) + 1);
                num6 = ((num5 + num3) - 1);
                if (num6 > num1) num6 = num1;
                if (((num6 - num5) + 1) < num3) num5 = Math.Max(1, ((num6 - num3) + 1));
            }
            if (num5 != 1)
            {
                button3 = new Literal();
                num9 = (num5 - 2);
                button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, num9.ToString()) + "\">...</a>";
                cell1.Controls.Add(button3);
                cell1.Controls.Add(new LiteralControl(" "));
            }
            for (num8 = num5; (num8 <= num6); num8 = (num8 + 1))
            {
                text1 = num8.ToString();
                if (num8 == num2)
                {
                    label3 = new System.Web.UI.WebControls.Label();
                    label3.Text = text1 + "<input type=hidden name='" + this.UniqueID + "_pag' value='" + text1 + "'>";
                    cell1.Controls.Add(label3);
                    #region per check
                    foreach (DataGridColumn dgc in this.Columns)
                        if (dgc is IValoriImpaginati)
                            ((IValoriImpaginati)dgc).AddHiddenValue(cell1);
                    #endregion
                }
                else
                {
                    button3 = new Literal();
                    button3.Text = text1;
                    button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, (num8 - 1).ToString()) + "\">" + text1 + "</a>";
                    cell1.Controls.Add(button3);
                }
                if (num8 < num6) cell1.Controls.Add(new LiteralControl(" "));
            }
            if (num1 > num6)
            {
                cell1.Controls.Add(new LiteralControl(" "));
                button3 = new Literal();
                button3.Text = "<a href=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, num6.ToString()) + "\">...</a>";
                cell1.Controls.Add(button3);
            }
            cell1.Style.Add("padding-left", "5px");
            item.Cells.Add(cell1);
        }

        #region IPostBackEventHandler Members

        public new DataGridPageChangedEventHandler PageIndexChanged;
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            CurrentPageIndex = int.Parse(eventArgument);
            if (PageIndexChanged != null) this.PageIndexChanged(this, new DataGridPageChangedEventArgs(this, CurrentPageIndex));
        }

        #endregion
    }

    public class NumberColumn : DataGridColumn
    {
        int n;
        public NumberColumn()
            : base()
        {
#if(DEBUG)
            this.HeaderText = "Nr.";
#endif
            this.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        public override void Initialize()
        {
            base.Initialize();
            n = Owner.CurrentPageIndex * Owner.PageSize + 1;
        }

        public override void InitializeCell(TableCell cell, int columnIndex, ListItemType itemType)
        {
            switch (itemType)
            {
                case ListItemType.Header:
                    if (Owner is DataGrid && ((DataGrid)Owner).NrColumnSearch)
                    {
                        cell.Style.Add("text-decoration", "underline");
                        cell.Style.Add("cursor", "pointer");
                        cell.Attributes.Add("onclick", "sjsDgNrColSearch(this);");
                    }
                    cell.Text = "Nr.";
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                case ListItemType.EditItem:
                    if (Owner is DataGrid && ((DataGrid)Owner).NrColumnSearch)
                        cell.Text = "<a id='nrColRow" + n.ToString() + "'>" + n.ToString() + "</a>";
                    else cell.Text = n.ToString();
                    n++;
                    break;
                default: break;
            }
        }
    }

    /// <summary>
    /// Crea una colonna col link adatto per l'htc
    /// </summary>
    public class ColonnaLink : BoundColumn
    {
        string _linkFields;
        /// <summary>
        /// Campi che verranno messi nel link, divisi da |
        /// </summary>
        public string LinkFields
        {
            get { return _linkFields; }
            set { _linkFields = value; }
        }

        /// <summary>
        /// funzione che indica se mettere o meno il link. Va aggiunta dalla pagina
        /// </summary>
        public ColonnaLink.checkRow checkRiga;
        public ColonnaLink.setLinkRow setLinkRiga;
        protected string linkstring;

        public delegate bool checkRow(DataGridItem dataGridItem, System.Data.DataRow riga);

        public delegate string setLinkRow(DataGridItem dataGridItem, System.Data.DataRow riga);

        bool _isJS;
        /// <summary>
        /// Indica se il link è un link vero e proprio o un javascript da eseguire
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool IsJavascript
        {
            get { return _isJS; }
            set { _isJS = value; }
        }

        string _linkFormat;
        /// <summary>
        /// Formato del link (o del javascript)
        /// </summary>
        public string LinkFormat
        {
            get { return _linkFormat; }
            set { _linkFormat = value; }
        }

        bool _mettiApiciInLinkFields;
        /// <summary>
        /// Indica se bisogna aggiungere un apice prima e dopo del LinkFields
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool MettiApiciInLinkFields
        {
            get { return _mettiApiciInLinkFields; }
            set { _mettiApiciInLinkFields = value; }
        }

        protected override string FormatDataValue(object dataValue)
        {
#if(DEBUG)
            if ((Owner.Site != null) && (Owner.Site.DesignMode))
                return base.FormatDataValue(dataValue);
#endif
            return base.FormatDataValue(dataValue) + linkstring;
        }

        public override void InitializeCell(System.Web.UI.WebControls.TableCell cell, int columnIndex, System.Web.UI.WebControls.ListItemType itemType)
        {

#if(DEBUG)
            if ((Owner.Site != null) && (Owner.Site.DesignMode))
            {
                base.InitializeCell(cell, columnIndex, itemType);
                return;
            }
#endif
            if (Owner.Parent.Page.Site == null) cell.DataBinding += new EventHandler(cell_DataBinding);
            base.InitializeCell(cell, columnIndex, itemType);
        }

        private void cell_DataBinding(object sender, EventArgs e)
        {
            DataGridItem dgi = (DataGridItem)((Control)sender).NamingContainer;
            object dataitem = dgi.DataItem;
            if (dataitem == null)
                return;
            System.Type tipo = dataitem.GetType();

            //tiro su i dati
            string[] campi = LinkFields.Split('|');
            object[] dati = new object[campi.Length];
            for (int i = 0; i < campi.Length; i++)
            {
                // se errore: e' sbagliato il campo DataField della colonna, scrivilo bene 
                dati[i] = tipo.GetProperty(campi[i]).GetValue(dataitem, null);
                
                if (MettiApiciInLinkFields)
                    dati[i] = "'" + dati[i] + "'";
            }

            //e scrivo il link
            if (IsJavascript)
                linkstring = "<span id='link' style='DISPLAY:none;' javascript>" + string.Format(LinkFormat, dati) + "</span>";
            else
                linkstring = "<span id='link' style='DISPLAY:none;'>" + string.Format(LinkFormat, dati) + "</span>";
            //se valorizzato mostra la descrizione nel popup
            //if(_showPopup!=""&&_showPopup!=null) base.linkstring+="<span id='showPopup' style='DISPLAY:none;'>"+_showPopup+"</span>";
        }
    }

    //public class BoundColumn : System.Web.UI.WebControls.BoundColumn
    //{
    //    public BoundColumn() : base() { }

    //    public override string DataField
    //    {
    //        get
    //        {
    //            return base.DataField;
    //        }
    //        set
    //        {
    //            base.DataField = value;
    //        }
    //    }

    //private string _unitaDiMisura="";
    //public string UnitaDiMisura
    //{
    //    //get {}
    //    set { _unitaDiMisura = value; }
    //}

    //protected override string FormatDataValue(object dataValue)
    //{
    //    string retVal = base.FormatDataValue(dataValue); switch (DataFormatString)
    //    {
    //        case "{0:N}":
    //            retVal = DataGrid.getCurrencyFormat(retVal);
    //            break;
    //        case "{0:d}":
    //            retVal = (new SiarLibrary.NullTypes.DatetimeNT(retVal)).ToFullYearString();
    //            break;
    //        default:
    //            break;
    //    }
    //    return retVal;
    //}

    //public override string ToString()
    //{
    //    if (DataFormatString == "{0:N}") return "ciao";
    //    return base.ToString();
    //}
    //}


    public class TextColumn : BoundColumn, IValoriImpaginati
    {
        public TextColumn() : base() { }

        protected System.Collections.Hashtable _dati;
        protected bool DatiSettati = false;

        private int _width = 150;
        public int Width { set { _width = value; } }

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('TextBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptTextBox", "$(document).ready(function(){addEventHandlersByClass('TextBox');});", true);
            base.Initialize();
        }

        public void Set_dati()
        {
            if (Testo != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Testo).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }

            //if (this.Owner != null && this.Owner.Page != null)
            //{
            //    if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addPValue('TextBox');");
            //    else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scpttextbox",
            //        "$(document).ready(function(){addPValue('TextBox');});", true);
            //}
            //return "<span id='" + nome + "' class='TextBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\"" + valore
            //    + "\" style='text-align:left;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "")
            //    + " onblur='tb_blur($(this));' onfocus='tb_focus($(this));' onkeypress='tb_keypress($(this),event);' /></span>";

            return "<span id='" + nome + "' class='TextBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\"" + valore
                + "\" style='text-align:left;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "") + " /></span>";
        }

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName)) return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _testo;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            foreach (object key in _dati.Keys)
            {
                object[] o = (object[])(_dati[key]);
                if (o[1].Equals(false))
                {
                    Literal check = new Literal();
                    check.EnableViewState = false;
                    check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? string.Empty : o[0].ToString()) + "' />";
                    cell.Controls.Add(check);
                }
            }
        }

        #endregion
    }

    public class TextAreaColumn : BoundColumn, IValoriImpaginati
    {
        public TextAreaColumn() : base() { }

        protected System.Collections.Hashtable _dati;
        protected bool DatiSettati = false;

        private int _width = 400;
        public int Width { set { _width = value; } }

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('TextArea');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptTextArea", "$(document).ready(function(){addEventHandlersByClass('TextArea');});", true);
            base.Initialize();
        }

        public void Set_dati()
        {
            if (Testo != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Testo).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='TextArea'><textarea id='" + nome + "_text' name='" + nome
                + "_text' cols='20' rows='3' style='text-align:left;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "")
                + " >" + valore + "</textarea></span>";
        }


        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _testo;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? string.Empty : o[0].ToString())
                            + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion
    }

    public class NewTextAreaColumn : BoundColumn, IValoriImpaginati
    {
        public NewTextAreaColumn() : base() { }

        protected System.Collections.Hashtable _dati;
        protected bool DatiSettati = false;

        private int _width = 400;
        public int Width { set { _width = value; } }

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('TextArea');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptTextArea", "$(document).ready(function(){addEventHandlersByClass('TextArea');});", true);
            base.Initialize();
        }

        public void Set_dati()
        {
            if (Testo != null)
            {
                var cc = (System.Collections.IList)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Testo).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='TextArea'><textarea id='" + nome + "_text' name='" + nome
                + "_text' cols='20' rows='3' style='text-align:left;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "")
                + " >" + valore + "</textarea></span>";
        }


        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _testo;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? string.Empty : o[0].ToString())
                            + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion
    }

    public class IntegerColumn : BoundColumn, IValoriImpaginati
    {
        public IntegerColumn() : base() { }

        private bool _showTotalFooter;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowTotalFooter
        {
            get { return _showTotalFooter; }
            set { _showTotalFooter = value; }
        }

        private int _width = 60;
        public int Width { set { _width = value; } }

        private bool _noCurrency = true;
        public bool NoCurrency { set { _noCurrency = value; } }

        protected System.Collections.Hashtable _dati;

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('IntegerBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptIntegerBox", "$(document).ready(function(){addEventHandlersByClass('IntegerBox');});", true);
            base.Initialize();
        }

        protected bool DatiSettati = false;
        public void Set_dati()
        {
            if (Valore != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        //if (tipo.GetProperty(DataField).GetValue(cc[i], null)!=null)
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Valore).GetValue(cc[i], null), false });
                        //else _dati.Add(
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='IntegerBox' nocurrency='" + _noCurrency.ToString().ToLower() + "'><input type='text' id='" + nome
                + "_text' name='" + nome + "_text' value=\"" + valore + "\" style='text-align:right;width:" + _width.ToString() + "px' "
                + (ReadOnly ? "disabled=disabled" : "") + " /></span>";
        }

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _valore;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Valore
        {
            get { return _valore; }
            set { _valore = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='"
                            + (o[0] == null ? string.Empty : o[0].ToString()) + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion

    }

    public class DatetimeColumn : BoundColumn, IValoriImpaginati
    {
        public DatetimeColumn() : base() { }

        private int _width = 80;
        public int Width { set { _width = value; } }

        System.Collections.Hashtable _dati;

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('DataBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptDataBox", "$(document).ready(function(){addEventHandlersByClass('DataBox');});", true);
            base.Initialize();
        }

        public void Set_dati()
        {
            if (Data != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        //if (tipo.GetProperty(DataField).GetValue(cc[i], null)!=null)
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Data).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString().Substring(0, 10);
                o[1] = true;
            }
            return "<span id='" + nome + "' class='DataBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\""
                + valore + "\" style='text-align:right;width:" + _width.ToString() + "px' "
                + (ReadOnly ? "disabled=disabled" : "") + " /></span>";

        }

        protected bool DatiSettati = false;

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _data;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected() { return null; }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            foreach (object key in _dati.Keys)
            {
                object[] o = (object[])(_dati[key]);
                if (o[1].Equals(false))
                {
                    Literal check = new Literal();
                    check.EnableViewState = false;
                    check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == DBNull.Value ? string.Empty : o[0].ToString()) + "' />";
                    cell.Controls.Add(check);
                }
            }
        }

        #endregion
    }

    public class PercentualeColumn : BoundColumn, IValoriImpaginati, ITotalFooter
    {
        public PercentualeColumn() : base() { }

        private bool _showTotalFooter;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowTotalFooter
        {
            get { return _showTotalFooter; }
            set { _showTotalFooter = value; }
        }

        private int _width = 50;
        public int Width { set { _width = value; } }

        string ITotalFooter.Valore { get { return Quota; } }

        protected System.Collections.Hashtable _dati;

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('QuotaBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptQuotaBox", "$(document).ready(function(){addEventHandlersByClass('QuotaBox');});", true);
            base.Initialize();
        }

        protected bool DatiSettati = false;
        public void Set_dati()
        {
            if (Quota != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(),
                            new object[] { tipo.GetProperty(Quota).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];
            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='QuotaBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\"" + valore
                + "\" style='text-align:right;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "") + " /></span>";
        }

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _quota;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Quota
        {
            get { return _quota; }
            set { _quota = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)  // da' errore. da modificare 
        {
            if (DesignMode) return;

            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? 0 : o[0].ToString() == "" ? 0 : decimal.Parse(o[0].ToString())) + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion
    }

    public class ImportoColumn : BoundColumn, IValoriImpaginati, ITotalFooter
    {
        public ImportoColumn() : base() { }

        private bool _showTotalFooter;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowTotalFooter
        {
            get { return _showTotalFooter; }
            set { _showTotalFooter = value; }
        }

        private int _width = 100;
        public int Width
        { set { _width = value; } }

        string ITotalFooter.Valore { get { return Importo; } }

        protected System.Collections.Hashtable _dati;

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('CurrencyBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptCurrencyBox", "$(document).ready(function(){addEventHandlersByClass('CurrencyBox');});", true);
            base.Initialize();
        }

        protected bool DatiSettati = false;
        public void Set_dati()
        {
            if (Importo != null)
            {
                CustomCollection cc = (CustomCollection)this.Owner.DataSource;
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(), new object[] { tipo.GetProperty(Importo).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='CurrencyBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\"" + valore
                + "\" style='text-align:right;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "") + " /></span>";
        }

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _importo;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? 0 : o[0].ToString() == "" ? 0 : decimal.Parse(o[0].ToString())) + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion
    }

    public class NewImportoColumn : BoundColumn, IValoriImpaginati, ITotalFooter
    {
        public NewImportoColumn() : base() { }

        private bool _showTotalFooter;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowTotalFooter
        {
            get { return _showTotalFooter; }
            set { _showTotalFooter = value; }
        }

        private int _width = 100;
        public int Width
        { set { _width = value; } }

        string ITotalFooter.Valore { get { return Importo; } }

        protected System.Collections.Hashtable _dati;

        public override void Initialize()
        {
#if (DEBUG)
            if (DesignMode) { base.Initialize(); return; }
#endif
            Set_dati();
            //if (this.Owner.Page is SiarLibrary.Web.Page) ((SiarLibrary.Web.Page)this.Owner.Page).RegisterClientScriptBlock("addEventHandlersByClass('CurrencyBox');");
            //else this.Owner.Page.ClientScript.RegisterClientScriptBlock(this.Owner.Page.GetType(), "scptCurrencyBox", "$(document).ready(function(){addEventHandlersByClass('CurrencyBox');});", true);
            base.Initialize();
        }

        protected bool DatiSettati = false;


        public void Set_dati()
        {
            if (Importo != null)
            {

                var cc = (System.Collections.IList)this.Owner.DataSource;
                
                if (cc.Count > 0)
                {
                    System.Type tipo = cc[0].GetType();
                    _dati = new System.Collections.Hashtable(cc.Count);
                    for (int i = 0; i < cc.Count; i++)
                    {
                        _dati.Add(tipo.GetProperty(DataField).GetValue(cc[i], null).ToString(), new object[] { tipo.GetProperty(Importo).GetValue(cc[i], null), false });
                    }
                }
                DatiSettati = true;
            }
            else _dati = new System.Collections.Hashtable(0);
        }

        protected override string FormatDataValue(object dataValue)
        {
#if (DEBUG)
            if (DesignMode) return base.FormatDataValue(dataValue);
#endif
            string val = base.FormatDataValue(dataValue);
            string df = dataValue.ToString();
            string nome = _name + df;
            object[] o = (object[])_dati[df];

            string valore = string.Empty;
            if (_dati.Count > 0)
            {
                if (o[0] != null) valore = o[0].ToString();
                o[1] = true;
            }
            return "<span id='" + nome + "' class='CurrencyBox'><input type='text' id='" + nome + "_text' name='" + nome + "_text' value=\"" + valore
                + "\" style='text-align:right;width:" + _width.ToString() + "px' " + (ReadOnly ? "disabled=disabled" : "") + " /></span>";
        }

        public string this[string keyName]
        {
            get
            {
                if (_dati.ContainsKey(keyName))
                    return (string)(((object[])_dati[keyName])[0]);
                return null;
            }
        }

        string _name, _importo;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }

        #region IValoriImpaginati Members

        public string[] GetSelected()
        {
            return null;
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (DesignMode) return;
            if (_dati != null)
            {
                foreach (object key in _dati.Keys)
                {
                    object[] o = (object[])(_dati[key]);
                    if (o[1].Equals(false))
                    {
                        Literal check = new Literal();
                        check.EnableViewState = false;
                        check.Text = "<input type='hidden' name='" + _name + ((string)key) + "_text' value='" + (o[0] == null ? 0 : o[0].ToString() == "" ? 0 : decimal.Parse(o[0].ToString())) + "' />";
                        cell.Controls.Add(check);
                    }
                }
            }
        }

        #endregion
    }

    public class CheckColumn : BoundColumn, IValoriImpaginati
    {
        protected string[] _selected;
        protected bool _valueSetted = false;
        protected bool[] _visibile;
        string[] _disabled = new string[0];
        public CheckColumn()
            : base()
        {
        }

        public virtual void ClearSelected()
        {
            _selected = new string[0];
            _visibile = new bool[0];
        }

        public void AddHiddenValue(TableCell cell)
        {
            int n = _selected.Length;
            for (int i = 0; i < n; i++)
            {
                if (!this._visibile[i])
                {
                    Literal check = new Literal();
                    check.EnableViewState = false;
                    check.Text = "<input type='checkbox' id='" + _name + "' name='" + _name + "' value=\"" + _selected[i] + "\" checked style='DISPLAY:NONE'>";
                    cell.Controls.Add(check);
                }
            }
        }

        public string[] GetSelected()
        {
            if (_selected == null)
                Initialize();
            return _selected;
        }

        private bool _readOnly = false;
        public override bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }

        private bool _headerSelectAll;
        public bool HeaderSelectAll { set { _headerSelectAll = value; } }
        public bool HeaderSelectAllFireClickEvent { get; set; }

        private string _OnHeaderCheckClick;
        public string OnHeaderCheckClick
        {
            get { return _OnHeaderCheckClick; }
            set { _OnHeaderCheckClick = value; }
        }

        private string _OnCheckClick;
        public string OnCheckClick
        {
            get { return _OnCheckClick; }
            set { _OnCheckClick = value; }
        }

        public void SetDisabled(string[] disabilitati)
        {
            _disabled = disabilitati;
        }

        public void SetSelected(string[] selezionati)
        {
            _selected = selezionati;
            _visibile = new bool[_selected.Length];
            _valueSetted = true;
        }

        public void SetSelected(System.Collections.ArrayList lista_selezionati)
        {
            string[] selezionati = new string[lista_selezionati.Count];
            for (int i = 0; i < lista_selezionati.Count; i++)
                selezionati[i] = lista_selezionati[i].ToString();
            SetSelected(selezionati);
        }

        public void SelectAll()
        {
            CustomCollection cc = (CustomCollection)this.Owner.DataSource;
            int n = cc.Count;
            if (n > 0)
            {
                _selected = new string[n];
                _visibile = new bool[n];
                System.Type tipo = cc[0].GetType();
                for (int i = 0; i < n; i++)
                    _selected[i] = tipo.GetProperty(DataField).GetValue(cc[i], null).ToString();
                _valueSetted = true;
            }
        }
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        bool initCalled = false;
        public override void Initialize()
        {
            if (initCalled) return;

            initCalled = true;

            base.Initialize();

            if (_valueSetted)
                return;

            System.Web.UI.Page p = Owner.Page;
            if (p.IsPostBack)
            {
                string form = p.Request.Form[_name];
                if (form == null)
                {
                    if (_selected == null)
                    {
                        _selected = new string[0];
                        _visibile = new bool[0];
                    }
                }
                else
                {
                    if (_selected == null)
                    {
                        _selected = p.Request.Form[_name].Split(',');
                        _visibile = new bool[_selected.Length];
                    }
                }
            }
            else
            {
                if (_selected == null)
                {
                    _selected = new string[0];
                    _visibile = new bool[0];
                }
            }
        }

        public override void InitializeCell(TableCell cell, int columnIndex, ListItemType itemType)
        {
#if(DEBUG)
            if (DesignMode) { base.InitializeCell(cell, columnIndex, itemType); return; }
#endif
            cell.Attributes.Add("align", "center");
            if (itemType == ListItemType.Header)
            {
                string testo_cella = HeaderText;
                if (_headerSelectAll)
                    testo_cella += (!string.IsNullOrEmpty(testo_cella) ? "<br />" : "")
                        + "<input id='" + _name + "HeaderCheck' runat='server' type='checkbox' onclick=\"dgCheckColumnSelectAll(this,'" + _name + "'," + HeaderSelectAllFireClickEvent.ToString().ToLower() + " ); " + OnHeaderCheckClick + "\" />";
                else if (string.IsNullOrEmpty(testo_cella))
                    testo_cella = "<img src='" + System.Web.HttpContext.Current.Request.ApplicationPath + "/images/check.bmp'>";
                cell.Text = testo_cella;
            }
            else base.InitializeCell(cell, columnIndex, itemType);
        }

        protected override string FormatDataValue(object dataValue)
        {
            string val = base.FormatDataValue(dataValue);
            string testo = "<span class='check'><input type='checkbox' id='" + _name + "' name='" + _name + "' value=\"" + val + "\"";

            int index = Array.IndexOf(_disabled, val);
            if (index >= 0)
                testo += " disabled checked";
            else
            {
                if (_readOnly) { testo += " disabled"; }
                index = Array.IndexOf(_selected, val);
                if (index >= 0)
                {
                    testo += " checked";
                    _visibile[index] = true;
                }
                if (!string.IsNullOrEmpty(_OnCheckClick))
                    testo += " onclick=\"" + _OnCheckClick + "\"";
            }

            testo += "></span>";
            return testo;
        }
    }

    public class ComboColumn : BoundColumn, IValoriImpaginati
    {
        #region Private Members

        private Dictionary<string, string> _comboValues = null;
        private Dictionary<string, string> _selectedValues = null;
        private Dictionary<string, string> _visibleValues = null;
        private string[] _disabledCombos = null;
        private bool _noBlankItem = true;
        private bool _readOnly = false;
        private string _name = null;
        private bool _initCalled = false;
        private string _commandText = null;
        private string _dataTextField = null;
        private string _dataValueField = null;

        #endregion

        /// <summary>
        /// If True, the combo won't render the blank item
        /// </summary>
        public bool NoBlankItem
        {
            get { return _noBlankItem; }
            set { _noBlankItem = value; }
        }

        /// <summary>
        /// SQL command text that populates the combo
        /// </summary>
        public string CommandText
        {
            get { return _commandText; }
            set { _commandText = value; }
        }

        public string DataTextField
        {
            get { return _dataTextField; }
            set { _dataTextField = value; }
        }

        public string DataValueField
        {
            get { return _dataValueField; }
            set { _dataValueField = value; }
        }

        public override bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public ComboColumn() : base() { }

        public override void Initialize()
        {
            if (_initCalled) return;
            else _initCalled = true;

            base.Initialize();

            _comboValues = new Dictionary<string, string>();
            _selectedValues = new Dictionary<string, string>();
            _visibleValues = new Dictionary<string, string>();

            #region Populate Combo Values

            if (!_noBlankItem) _comboValues.Add(string.Empty, string.Empty);

            SiarLibrary.DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandText = _commandText;
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                _comboValues.Add(db.DataReader[_dataValueField].ToString(), db.DataReader[_dataTextField].ToString());
            }
            db.Close();

            #endregion

            #region Page PostBack

            System.Web.UI.Page p = Owner.Page;
            if (p.IsPostBack)
            {
                foreach (string key in p.Request.Form.AllKeys)
                {
                    if (key.StartsWith(_name + "$"))
                    {
                        _selectedValues.Add(key.Substring(key.LastIndexOf('$') + 1), p.Request.Form[key]);
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// Sets the Combo's selected values
        /// </summary>
        /// <param name="selectedValues">Key: ObjectId, Value: Combo SelectedValue</param>
        public void SetSelected(Dictionary<string, string> selectedValues)
        {
            if (_selectedValues == null) Initialize();
            if (selectedValues != null)
            {
                foreach (string key in selectedValues.Keys)
                {
                    if (_selectedValues.ContainsKey(key)) _selectedValues[key] = selectedValues[key];
                    else _selectedValues.Add(key, selectedValues[key]);
                }
            }
        }

        /// <summary>
        /// Gets the Combo's selected values
        /// </summary>
        /// <returns>Key: ObjectId, Value: Combo SelectedValue</returns>
        public Dictionary<string, string> GetSelected()
        {
            if (_selectedValues == null) Initialize();
            return _selectedValues;
        }

        /// <summary>
        /// Clears the Combo selections
        /// </summary>
        public virtual void ClearSelected()
        {
            _selectedValues = null;
        }

        /// <summary>
        /// Sets Combos to be disabled
        /// </summary>
        /// <param name="disabledCombos">Array containing the ObjectIds that identify the combo</param>
        public void SetDisabled(string[] disabledCombos)
        {
            _disabledCombos = disabledCombos;
        }

        #region IValoriImpaginati Members

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void AddHiddenValue(TableCell cell)
        {
            if (_visibleValues != null && _selectedValues != null)
            {
                foreach (string key in _selectedValues.Keys)
                {
                    if (!_visibleValues.ContainsKey(key))
                    {
                        Literal hiddenField = new Literal();
                        hiddenField.EnableViewState = false;
                        hiddenField.Text = "<input type=\"hidden\" id=\"" + _name + "$" + key + "\" name=\"" + _name + "$" + key + "\" value=\"" + _selectedValues[key] + "\" />";
                        cell.Controls.Add(hiddenField);
                    }
                }
            }
        }

        #endregion

        protected override string FormatDataValue(object dataValue)
        {
            string data_value = base.FormatDataValue(dataValue);

            string html = "<select id=\"" + _name + "$" + data_value + "\" name=\"" + _name + "$" + data_value + "\"";

            if (_readOnly) { html += " disabled=\"disabled\""; }
            else if (_disabledCombos != null && Array.IndexOf(_disabledCombos, data_value) >= 0) html += " disabled=\"disabled\"";

            html += ">";

            if (_comboValues != null && _comboValues.Count > 0)
            {
                foreach (string key in _comboValues.Keys)
                {
                    if (_selectedValues != null &&
                        _selectedValues.ContainsKey(data_value) &&
                        key == _selectedValues[data_value])
                    {
                        html += " <option selected=\"selected\" value=\"" + key + "\">" + _comboValues[key] + "</option>";
                        _visibleValues.Add(data_value, key);
                    }
                    else html += " <option value=\"" + key + "\">" + _comboValues[key] + "</option>";
                }
            }

            html += "</select>";
            return html;
        }

        public override void InitializeCell(TableCell cell, int columnIndex, ListItemType itemType)
        {
#if(DEBUG)
            if ((Owner.Site != null) && (Owner.Site.DesignMode))
            {
                base.InitializeCell(cell, columnIndex, itemType);
                return;
            }
#endif

            cell.Attributes.Add("style", "text-align:center;");
            if (itemType == ListItemType.Header)
            {
                if (!string.IsNullOrEmpty(HeaderText)) cell.Text = HeaderText;
            }
            else base.InitializeCell(cell, columnIndex, itemType);
        }
    }

    public enum JsButtonColumnType { TextButton, ImageButton }
    public class JsButtonColumn : BoundColumn
    {
        private string _arguments;
        public string Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

        private string _jsFunction;
        public string JsFunction
        {
            get { return _jsFunction; }
            set { _jsFunction = value; }
        }

        private JsButtonColumnType _buttonType;
        public JsButtonColumnType ButtonType
        {
            get { return _buttonType; }
            set { _buttonType = value; }
        }

        private string _buttonText = "button";
        public string ButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }

        private string _buttonImage;
        public string ButtonImage
        {
            get { return _buttonImage; }
            set { _buttonImage = value; }
        }

        private bool _abilitaModifica = true;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }

        public override void InitializeCell(System.Web.UI.WebControls.TableCell cell, int columnIndex, System.Web.UI.WebControls.ListItemType itemType)
        {
            if (Owner.Site == null && _abilitaModifica) cell.DataBinding += new EventHandler(cell_DataBinding);
            base.InitializeCell(cell, columnIndex, itemType);
        }

        //private string cell_html = "button";
        private void cell_DataBinding(object sender, EventArgs e)
        {
            DataGridItem dgi = (DataGridItem)((Control)sender).NamingContainer;
            object dataitem = dgi.DataItem;
            if (dataitem == null) return;
            System.Type tipo = dataitem.GetType();

            string fn = _jsFunction + "(";
            if (Owner.Site == null)
            {
                if (!string.IsNullOrEmpty(_arguments))
                {
                    // se asterisco passo l'intero oggetto in formato json
                    if (_arguments == "*") fn += ((BaseObject)dataitem).ConvertToJSonObject();
                    else
                    {
                        //tiro su i dati
                        string[] campi = _arguments.Split('|');
                        foreach (string s in _arguments.Split('|'))
                        {
                            object val = null;
                            System.Reflection.PropertyInfo pi = tipo.GetProperty(s);
                            if (pi != null) val = pi.GetValue(dataitem, null);
                            else val = new NullTypes.StringNT(((BaseObject)dataitem).AdditionalAttributes[s]);
                            fn += (val == null ? "null" : ((NullTypes.NullType)(val)).ToJsonString()) + ",";
                        }
                    }
                }
            }
            fn += "this);";
            int width = 100;
            if (!ItemStyle.Width.IsEmpty && ItemStyle.Width.Type == UnitType.Pixel) width = (int)ItemStyle.Width.Value - 20;
            // scrivo l'html
            string html = "";
            if (_buttonType == JsButtonColumnType.ImageButton) html = "<img src=\"" + Owner.Page.Request.ApplicationPath + "/images/" + _buttonImage
                + "\" style='width:20px;height:20px;cursor:pointer;' title=\"" + _buttonText + "\" onclick=\"" + fn + "\"/>";
            else html = "<input type=button class=ButtonGrid value='" + _buttonText + "' onclick=\"" + fn + "\" style='width:" + width.ToString()
                + "px;margin-left:10px;margin-right:10px;' />";
            ((System.Web.UI.WebControls.TableCell)(sender)).Text = html;
        }
    }

    #region interfacce

    interface IValoriImpaginati
    {
        string Name { get; set; }//nome da usare sulla pagina
        //string[] GetSelected();//valori selezionati
        void AddHiddenValue(TableCell cell);
    }

    public interface ITotalFooter
    {
        string Valore
        { get; }

        bool ShowTotalFooter
        {
            get;
            set;
        }
    }

    #endregion
}
