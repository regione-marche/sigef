using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Data;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class ZoomRequest : System.Web.UI.Page
    {
        string returnMessage = "";
        string[] parametri;
        private ZoomSessionParameter zsp;
        private SiarLibrary.CustomCollection cc;
        ZoomDataGrid dg;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            ctrlRequest();
            Response.Write(returnMessage);
            Response.End();
        }

        private void ctrlRequest()
        {
            try
            {
                if (Session["Operatore"] == null) throw new Exception("Attenzione! Operatore non abilitato.");
                string idZoomLoader = Request.Params["idZL"];
                if (string.IsNullOrEmpty(idZoomLoader)) throw new Exception("Attenzione! Metodo non specificato.");
                parametri = Request.Params["KVList"].Split('|');
                zsp = (ZoomSessionParameter)Session["zsp_session_object_" + idZoomLoader];
                typeof(ZoomRequest).GetMethod(zsp.SearchMethod).Invoke(this, new object[0]);
                RenderDataGrid();
            }
            catch (Exception ex) { returnMessage = ex.Message; }
        }

        private void RenderDataGrid()
        {
            dg = new ZoomDataGrid();
            dg.IdZoomLoader = Request.Params["idZL"];
            dg.zsp = zsp;
            dg.CurrentPageIndex = int.Parse(Request.Params["pIndex"]);
            DGBindColumn();
            dg.DataSource = cc;
            if (cc.Count > 0) dg.DataBind();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            htw.Write("<p style='font-weight:bold'>Elementi trovati: " + cc.Count.ToString() + "</p>");
            dg.RenderControl(htw);
            returnMessage = sb.ToString();
        }

        private void DGBindColumn()
        {
            foreach (string colonna_aggiuntiva in zsp.ColumnsToBind)
            {
                if (colonna_aggiuntiva == "nr")
                {
                    SiarLibrary.Web.NumberColumn nr = new SiarLibrary.Web.NumberColumn();
                    nr.ItemStyle.Width = new Unit(30);
                    dg.Columns.Add(nr);
                }
                else
                {
                    string[] dati_colonna = colonna_aggiuntiva.Split(':');
                    BoundColumn bc = new BoundColumn();
                    bc.HeaderText = dati_colonna[0];
                    bc.DataField = (dati_colonna.Length == 1 || string.IsNullOrEmpty(dati_colonna[1]) ? dati_colonna[0] : dati_colonna[1]);
                    if (dati_colonna.Length > 2)
                    {
                        switch (dati_colonna[2])
                        {
                            case "id":
                                bc.ItemStyle.Width = new Unit(100);
                                bc.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                break;
                            case "c":
                                bc.DataFormatString = "{0:c}";
                                bc.ItemStyle.Width = new Unit(100);
                                bc.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                break;
                            case "n":
                                bc.DataFormatString = "{0:n}";
                                bc.ItemStyle.Width = new Unit(100);
                                bc.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                                break;
                            case "d":
                                bc.ItemStyle.Width = new Unit(100);
                                bc.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                break;
                            case "b":
                                bc.DataFormatString = "{0:SI|NO}";
                                bc.ItemStyle.Width = new Unit(80);
                                bc.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                break;
                        }
                    }
                    dg.Columns.Add(bc);
                }
            }
        }

        #region metodi

        //public void GetProgetti()
        //{
        //    string id_progetto = null, cuaa = null;
        //    if (parametri.Length == 2)
        //    {
        //        id_progetto = parametri[0].Split(':')[1];
        //        cuaa = parametri[1].Split(':')[1];
        //    }
        //    cc = new SiarBLL.ProgettoCollectionProvider().Find(id_progetto, null, null, null, cuaa, null, null);
        //}

        //public void GetAtti()
        //{
        //    string numero = null, data = null, tipo = null;
        //    if (parametri.Length == 3)
        //    {
        //        numero = parametri[0].Split(':')[1];
        //        data = parametri[1].Split(':')[1];
        //        tipo = parametri[2].Split(':')[1];
        //    }
        //    cc = new SiarBLL.AttiCollectionProvider().Find(numero, data, tipo, null);
        //}

        public void GetDecreti()
        {
            string numero = null, data = null, tipo = null;//, registro = null;
            if (parametri.Length == 3)
            {
                numero = parametri[0].Split(':')[1];
                data = parametri[1].Split(':')[1];
                tipo = parametri[2].Split(':')[1];
                //registro = parametri[3].Split(':')[1];
            }
            cc = new SiarBLL.AttiCollectionProvider().Find(numero, data, tipo, null);
        }

        public void GetSportelliCAA()
        {
            string cod_ente = null, codiceProvincia = null;
            if (parametri.Length == 2)
            {
                cod_ente = parametri[0].Split(':')[1];
                codiceProvincia = parametri[1].Split(':')[1];
            }
            cc = new SiarBLL.CaaSportelloCollectionProvider().Find(null, cod_ente, null, codiceProvincia, null);
        }

        public void GetBandi()
        {
            string parole_chiave = null,data_scadenza_Mag =null, data_scadenza = null, id_programmazione = null, descrizione = null, id_bando =null;
            switch (parametri.Length)
            {
                case 1:
                    id_programmazione = parametri[0].Split(':')[1];
                    cc = new SiarBLL.BandoCollectionProvider().Find(null, null, null, new SiarLibrary.NullTypes.DatetimeNT(data_scadenza), id_programmazione, null, null, false,
                        (string.IsNullOrEmpty(parole_chiave) ? null : "%" + parole_chiave + "%"));
                    break;
                case 2:
                    data_scadenza = parametri[0].Split(':')[1];
                    parole_chiave = parametri[1].Split(':')[1];
                    cc = new SiarBLL.BandoCollectionProvider().Find(null, null, null, new SiarLibrary.NullTypes.DatetimeNT(data_scadenza), id_programmazione, null, null, false,
                        (string.IsNullOrEmpty(parole_chiave) ? null : "%" + parole_chiave + "%"));
                    break;
                case 4:
                    data_scadenza = parametri[0].Split(':')[1];
                    data_scadenza_Mag = parametri[1].Split(':')[1];
                    parole_chiave = parametri[2].Split(':')[1];
                    descrizione = parametri[3].Split(':')[1];
                    cc = new SiarBLL.BandoCollectionProvider().RicercaBandoFiltraDescrizione(descrizione, data_scadenza,
                        data_scadenza_Mag, parole_chiave,null);
                    break;

                case 5:
                    data_scadenza = parametri[0].Split(':')[1];
                    data_scadenza_Mag = parametri[1].Split(':')[1];
                    parole_chiave = parametri[2].Split(':')[1];
                    descrizione = parametri[3].Split(':')[1];
                    id_bando = parametri[4].Split(':')[1];
                    cc = new SiarBLL.BandoCollectionProvider().RicercaBandoFiltraDescrizione(descrizione, data_scadenza,
                        data_scadenza_Mag, parole_chiave,(string.IsNullOrEmpty(id_bando) ? null :id_bando));
                    break;
            }
            //if (parametri.Length == 1) id_programmazione = parametri[0].Split(':')[1];
            //if (parametri.Length == 2)
            //{
            //    data_scadenza = parametri[0].Split(':')[1];
            //    parole_chiave = parametri[1].Split(':')[1];
            //}
            //cc = new SiarBLL.BandoCollectionProvider().Find(null, null, null, new SiarLibrary.NullTypes.DatetimeNT(data_scadenza), id_programmazione, null, null, false,
            //    (string.IsNullOrEmpty(parole_chiave) ? null : "%" + parole_chiave + "%"));
        }

        public void GetDisposizioniAttuative()
        {
            string id_programmazione = null;
            if (parametri.Length == 1) id_programmazione = parametri[0].Split(':')[1];
            cc = new SiarBLL.BandoCollectionProvider().Find(null, null, null, null, id_programmazione, null, null, true, null);
        }

        public void GetUtenti()
        {
            string nominativo = null, cod_ente = null, provincia = null;
            if (parametri.Length == 3)
            {
                nominativo = parametri[0].Split(':')[1];
                cod_ente = parametri[1].Split(':')[1];
                provincia = parametri[2].Split(':')[1];
            }
            cc = new SiarBLL.UtentiCollectionProvider().Find(null, null, "%" + nominativo + "%", cod_ente, null, provincia, null);
        }

        //public void GetInterventiBando()
        //{
        //    string[] bando = parametri[0].Split(':');
        //    SiarLibrary.ProgrammazioneBando p = new SiarBLL.ProgrammazioneBandoCollectionProvider().Find(bando[1], null).FiltroMisuraPrevalente(true)[0];
        //    cc = new SiarBLL.VinterventoCollectionProvider().Find(null, p.IdPsr, p.CodObiettivo, p.CodAsse, p.CodMisura, null, null, null, null, null);
        //}

        //public void GetDisposizioniAttuative()
        //{
        //    string misura = string.Join("|", parametri);
        //    string[] misura_pulita = misura.Split(':');
        //    cc = new SiarBLL.BandoCollectionProvider().RicercaBando(true, null, null, null, null, misura_pulita[1], null, false, false);
        //}

        public void GetSettoriProduttivi()
        {
            string descrizione = parametri[0].Split(':')[1];
            cc = new SiarBLL.SettoriProduttiviCollectionProvider().Find(null, descrizione + "%");
        }

        public void GetPrioritaSettoriali()
        {
            string descrizione = parametri[0].Split(':')[1];
            cc = new SiarBLL.PrioritaSettorialiCollectionProvider().Find(null, descrizione + "%");
        }

        public void GetGiustificativiProgetto()
        {
            string[] id = parametri[0].Split(':');
            string[] numero = parametri[1].Split(':');
            string[] data = parametri[2].Split(':');
            cc = new SiarBLL.GiustificativiCollectionProvider().Find(id[1], null, numero[1], data[1]);
        }

        public void GetRegistroIrregolaritaProgetto()
        {
            string[] id = parametri[0].Split(':');
            cc = new SiarBLL.RegistroIrregolaritaCollectionProvider().Find(null, id[1], null);
        }

        public void GetRegistroRecuperoProgetto()
        {
            string[] id = parametri[0].Split(':');
            cc = new SiarBLL.RegistroRecuperoCollectionProvider().GetByIdProgetto(id[1], false);
        }

        /// <summary>
        /// utilizzato nello zoom per il pagamento investimento 
        /// la query ricerca i giustificativi "pagati" nella domanda di pagamento
        /// </summary>
        public void GetGiustificativiDomandaPagamento()
        {
            string[] id = parametri[0].Split(':');
            string[] numero = parametri[1].Split(':');
            string[] data = parametri[2].Split(':');
            cc = new SiarBLL.GiustificativiCollectionProvider().GetGiustificativiDomandaPagamento(id[1], numero[1], data[1]);
        }

        public void GetComuni()
        {
            string prov = null, comune = null;
            if (parametri.Length > 0)
            {
                prov = parametri[0].Split(':')[1];
                comune = parametri[1].Split(':')[1];
            }
            if (!string.IsNullOrEmpty(comune)) comune = comune + "%";
            cc = new SiarBLL.ComuniCollectionProvider().Find(null, null, null, prov, null, null, null, comune);
        }

        /// <summary>
        /// utilizzato nello zoom per il pagamento investimento 
        /// la query ricerca i contratti fem nella domanda di pagamento
        /// </summary>
        public void GetContrattiDomandaPagamento()
        {
            string[] id = parametri[0].Split(':');
            string[] segnatura = parametri[1].Split(':');
            string[] data = parametri[2].Split(':');

            cc = new SiarBLL.ContrattiFemCollectionProvider().GetContrattiDomandaPagamento(id[1], segnatura[1], data[1]);
        }

        #endregion
    }

    public class ZoomDataGrid : DataGrid
    {
        private string _idZoomLoader;
        public string IdZoomLoader { set { _idZoomLoader = value; } }
        public ZoomSessionParameter zsp;

        public ZoomDataGrid()
        {
            AllowPaging = true;
            PageSize = 10;
            AutoGenerateColumns = false;
            HeaderStyle.CssClass = "TESTA1";
            ItemStyle.CssClass = "DataGridRow";
            AlternatingItemStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 210);
            AlternatingItemStyle.CssClass = "DataGridRow";
            PagerStyle.CssClass = "coda";
            EnableViewState = false;
            Style.Add("width", "100%");
            ItemDataBound += new DataGridItemEventHandler(ZoomDataGrid_ItemDataBound);
        }

        void ZoomDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                foreach (TableCell td in e.Item.Cells)
                {
                    if (td.Text.Length > 250)
                    {
                        string new_text = td.Text.Substring(0, 250) + "...";
                        td.Text = new_text;
                    }
                }
                //string out_value = "", out_text = "";
                //int counter_v = 1, counter_t = 1;
                //foreach (string v in zsp.KeyValue)
                //{
                //    if (counter_v > 1) out_value += "##";
                //    PropertyInfo piValue = e.Item.DataItem.GetType().GetProperty(v);
                //    out_value += piValue.GetValue(e.Item.DataItem, null);
                //    counter_v++;
                //}
                //foreach (string t in zsp.KeyText)
                //{
                //    if (counter_t > 1) out_text += "##";
                //    PropertyInfo piText = e.Item.DataItem.GetType().GetProperty(t);
                //    out_text += piText.GetValue(e.Item.DataItem, null);
                //    counter_t++;
                //}
                //e.Item.Attributes.Add("onclick", "zoomSelectItem('" + _idZoomLoader + "','" + out_value + "','" + out_text.Replace("\r", string.Empty).
                //    Replace("\n", string.Empty) + "'," + (string.IsNullOrEmpty(zsp.JsSelectedItemHandler) ? "null" : zsp.JsSelectedItemHandler) + ");");
                //e.Item.Attributes.Add("onmouseover", "selectRow(this,'#fefeee');");
                //e.Item.Attributes.Add("onmouseout", "unselectRow(this);");

                string json_object = "";
                // creo oggetto json valore
                foreach (PropertyInfo v in e.Item.DataItem.GetType().GetProperties())
                {
                    string valore = "'" + v.Name + "':'";
                    try
                    {
                        valore += v.GetValue(e.Item.DataItem, null).ToCleanJsString();
                    }
                    catch { }
                    json_object += valore + "',";
                }
                //aggancio proprieta json per il default value
                string value = "";
                foreach (string s in zsp.KeyValue)
                {
                    if (!string.IsNullOrEmpty(value)) value += "|";
                    try
                    {
                        value += e.Item.DataItem.GetType().GetProperty(s).GetValue(e.Item.DataItem, null).ToCleanJsString();
                    }
                    catch { }
                }
                json_object += "'default_value':'" + value + "',";
                //aggancio proprieta json per il default text
                string testo = "";
                foreach (string s in zsp.KeyText)
                {
                    if (!string.IsNullOrEmpty(testo)) testo += " - ";
                    try
                    {
                        testo += e.Item.DataItem.GetType().GetProperty(s).GetValue(e.Item.DataItem, null).ToCleanJsString();
                    }
                    catch { }
                }
                json_object += "'default_text':'" + testo + "'";
                //rimuovo l'ultima virgola se ce ne fosse il bisogno
                if (json_object.EndsWith(",")) json_object = json_object.Substring(0, json_object.Length - 1);
                //aggancio gli eventi
                e.Item.Attributes.Add("onclick", "zoomSelectItem('" + _idZoomLoader + "',{" + json_object + "}," +
                    (string.IsNullOrEmpty(zsp.JsSelectedItemHandler) ? "null" : zsp.JsSelectedItemHandler) + ");");
                e.Item.Attributes.Add("onmouseover", "selectRow(this,'#fefeee');");
                e.Item.Attributes.Add("onmouseout", "unselectRow(this);");
            }
        }

        protected override void InitializePager(DataGridItem item, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (CurrentPageIndex > pagedDataSource.Count) CurrentPageIndex = 0;
            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = columnSpan;
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
                button3.Text = "<a href=\"javascript:runZoomSearch('" + _idZoomLoader + "', " + num9.ToString() + ");\">...</a>";
                cell1.Controls.Add(button3);
                cell1.Controls.Add(new LiteralControl(" "));
            }
            for (num8 = num5; (num8 <= num6); num8++)
            {
                text1 = num8.ToString();
                if (num8 == num2)
                {
                    label3 = new Label();
                    label3.Text = text1;
                    cell1.Controls.Add(label3);
                }
                else
                {
                    button3 = new Literal();
                    button3.Text = text1;
                    button3.Text = "<a href=\"javascript:runZoomSearch('" + _idZoomLoader + "', " + (num8 - 1).ToString() + ");\">" + text1 + "</a>";
                    cell1.Controls.Add(button3);

                }
                if (num8 < num6) cell1.Controls.Add(new LiteralControl(" "));
            }
            if (num1 > num6)
            {
                cell1.Controls.Add(new LiteralControl(" "));
                button3 = new Literal();
                button3.Text = "<a href=\"javascript:runZoomSearch('" + _idZoomLoader + "', " + num6.ToString() + ");\">...</a>";
                cell1.Controls.Add(button3);
            }
            cell1.Style.Add("padding-left", "5px");
            item.Cells.Add(cell1);
        }
    }
}
