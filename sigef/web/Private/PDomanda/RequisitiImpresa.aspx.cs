﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.PDomanda
{
    public partial class RequisitiImpresa : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.BandoProgrammazioneCollectionProvider bp_provider;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;
        SiarBLL.ProgettoNaturaSoggettoCollectionProvider natura_prov = new SiarBLL.ProgettoNaturaSoggettoCollectionProvider();
        SiarLibrary.ProgettoNaturaSoggetto NaturaSoggetto = null;
        SiarBLL.AggregazioneCollectionProvider aggr_prov = new SiarBLL.AggregazioneCollectionProvider();
        SiarLibrary.Aggregazione aggregazione_selezionata = null;
        SiarBLL.ImpresaAggregazioneCollectionProvider aggr_imp_prov = new SiarBLL.ImpresaAggregazioneCollectionProvider();
        SiarBLL.PrioritaXImpresaCollectionProvider p_x_i_prov = new SiarBLL.PrioritaXImpresaCollectionProvider();
        SiarBLL.ImpresaCollectionProvider imp_prov = new SiarBLL.ImpresaCollectionProvider();

        public System.Collections.ArrayList PrioritaImpresa
        {
            get
            {
                System.Collections.ArrayList priorita_buffer = new System.Collections.ArrayList();
                foreach (string s in ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[2]).GetSelected())
                {
                    priorita_buffer.Add("c|" + s);
                }

                foreach (string s in Request.Form.AllKeys)
                {
                    // priorita x impresa con combo a piu' valori
                    if (s.StartsWith("hdnValoriPriorita") && !s.Contains("Sql"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()) && int.Parse(Request.Form[s]) > 0)
                        {
                            string hdn = s.Replace("hdnValoriPriorita", "hdnPriorita");
                            int idpriorita;
                            if (int.TryParse(Request.Form[hdn], out idpriorita))
                            {
                                priorita_buffer.Add("z|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    // priorita x impresa con combo a piu' valori dinamica con query sql
                    if (s.StartsWith("hdnValoriPrioritaSql"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            string hdn = s.Replace("hdnValoriPrioritaSql", "hdnPrioritaSql");
                            int idpriorita;
                            if (int.TryParse(Request.Form[hdn], out idpriorita))
                            {
                                priorita_buffer.Add("q|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    //  priorita ad input numerico
                    if (s.StartsWith("txtPrioritaNumerica") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaNumerica", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("n|" + idpriorita.ToString() + "|" + Request.Form[s].Replace(".", ""));
                            }
                        }
                    }
                    // priorita data
                    if (s.StartsWith("txtPrioritaDatetime") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaDatetime", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("d|" + idpriorita.ToString() + "|" + Request.Form[s]);
                            }
                        }
                    }
                    // priorita testo
                    if (s.StartsWith("txtPrioritaTestoSemplice") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaTestoSemplice", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("t|" + idpriorita.ToString() + "|" + Request.Form[s].Replace("|", " "));
                            }
                        }
                    }
                    // priorita text area
                    if (s.StartsWith("txtPrioritaTestoArea") && s.EndsWith("_text"))
                    {
                        if (!string.IsNullOrEmpty(Request.Form[s].Trim()))
                        {
                            int idpriorita;
                            if (int.TryParse(s.Replace("txtPrioritaTestoArea", "").Replace("_text", ""), out idpriorita))
                            {
                                priorita_buffer.Add("a|" + idpriorita.ToString() + "|" + Request.Form[s].Replace(".", "").Replace("|", ""));
                            }
                        }
                    }
                }
                return priorita_buffer;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bp_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarLibrary.ProgettoNaturaSoggettoCollection natura_coll = natura_prov.Find(Progetto.IdProgetto, null, null);
            if(natura_coll.Count>0)
            {
                NaturaSoggetto = natura_coll[0];
                hdnIdProgettoNaturaSoggetto.Value = NaturaSoggetto.IdProgettoNaturaSoggetto;
                if (NaturaSoggetto.IdAggregazione != null)
                { 
                    aggregazione_selezionata = aggr_prov.GetById(NaturaSoggetto.IdAggregazione);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if(NaturaSoggetto == null)
            {
                DivAggregazione.Visible = false;
            }
            else
            {
                ddlFormaNaturaSoggetto.SelectedValue = NaturaSoggetto.TipoNaturaSoggetto;
                if (NaturaSoggetto.TipoNaturaSoggetto == "Aggregata")
                {
                    DivAggregazione.Visible = true;
                    //aggregata
                    ddlAggregazione.IdImpresa = Progetto.IdImpresa;
                    ddlAggregazione.DataBind();
                    
                    if (NaturaSoggetto.IdAggregazione != null)
                    { 
                        ddlAggregazione.SelectedValue = NaturaSoggetto.IdAggregazione;
                        DivImprese.Visible = true;
                        SiarLibrary.ImpresaAggregazioneCollection impresecoll = aggr_imp_prov.Find(NaturaSoggetto.IdAggregazione, null, null, true, null);
                        dgImpreseAggregazione.DataSource = impresecoll;
                        dgImpreseAggregazione.ItemDataBound += new DataGridItemEventHandler(dgImpreseAggregazione_ItemDataBound);
                        dgImpreseAggregazione.DataBind();
                        int id_impresa_selezionata;
                        if (int.TryParse(hdnIdImpresaAggregazione.Value, out id_impresa_selezionata))
                        {
                            divPriorita.Visible = true;
                            SiarLibrary.Impresa imp = imp_prov.GetById(id_impresa_selezionata);
                            txtRagSociale.Text = imp.RagioneSociale;
                            txtCFPIVA.Text = imp.CodiceFiscale;
                            ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[2]).ClearSelected();
                            SiarLibrary.SchedaXPrioritaCollection priorita_impresa = new SiarBLL.SchedaXPrioritaCollectionProvider().
                            GetPrioritaXImpresa(Bando.IdSchedaValutazione, id_impresa_selezionata , Progetto.IdProgetto);
                            dgPriorita.DataSource = priorita_impresa;
                            if (priorita_impresa.Count == 0)
                            {
                                dgPriorita.Titolo = "Nessun elemento trovato.";
                            }
                            else
                            {
                                dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
                            }
                            dgPriorita.DataBind();
                        }
                    }
                }
                else
                {
                    //singola
                    DivAggregazione.Visible = false;
                    hdnIdImpresaAggregazione.Value = Progetto.IdImpresa.ToString();
                    divPriorita.Visible = true;
                    SiarLibrary.Impresa imp = imp_prov.GetById(Progetto.IdImpresa);
                    txtRagSociale.Text = imp.RagioneSociale;
                    txtCFPIVA.Text = imp.CodiceFiscale;
                    ((SiarLibrary.Web.CheckColumn)dgPriorita.Columns[2]).ClearSelected();
                    SiarLibrary.SchedaXPrioritaCollection priorita_impresa = new SiarBLL.SchedaXPrioritaCollectionProvider().
                    GetPrioritaXImpresa(Bando.IdSchedaValutazione, Progetto.IdImpresa , Progetto.IdProgetto);
                    dgPriorita.DataSource = priorita_impresa;
                    if (priorita_impresa.Count == 0)
                    {
                        dgPriorita.Titolo = "Nessun elemento trovato.";
                    }
                    else
                    {
                        dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
                    }
                    dgPriorita.DataBind();
                }
            }
            base.OnPreRender(e);
        }

        void dgImpreseAggregazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.ImpresaAggregazione impresa_aggregazione = (SiarLibrary.ImpresaAggregazione)dgi.DataItem;
                e.Item.Cells[3].Text = impresa_aggregazione.RuoloAggregazione;
            }
        }

        protected void btnSalvaNaturaSoggetto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlFormaNaturaSoggetto.SelectedValue == "")
                    throw new Exception("Selezionare la tipologia di presentazione della domanda");
                if (NaturaSoggetto == null)
                {
                    NaturaSoggetto = new SiarLibrary.ProgettoNaturaSoggetto();
                    NaturaSoggetto.IdProgetto = Progetto.IdProgetto;
                    NaturaSoggetto.TipoNaturaSoggetto = ddlFormaNaturaSoggetto.SelectedValue;
                }
                else
                {
                    if(NaturaSoggetto.TipoNaturaSoggetto != ddlFormaNaturaSoggetto.SelectedValue)
                    {


                        NaturaSoggetto.TipoNaturaSoggetto = ddlFormaNaturaSoggetto.SelectedValue;
                        if (ddlFormaNaturaSoggetto.SelectedValue == "Singola")
                        {
                            //verifico che non siano gia state assegnati gli investimenti alle imprese
                            SiarLibrary.PianoInvestimentiCollection piano_col = new SiarBLL.PianoInvestimentiCollectionProvider().Find(null, Progetto.IdProgetto, null, null, null, null, null);
                            foreach(SiarLibrary.PianoInvestimenti inv in piano_col)
                            {
                                if(inv.IdInvestimentoOriginale == null && inv.IdImpresaAggregazione != null)
                                {
                                    throw new Exception("Impossibile continuare, ci sono investimenti collegati alle imprese dell'aggregazione precedentemente selezionata. per continuare eliminare le voci del piano investimenti!");
                                    //foreach (SiarLibrary.ImpresaAggregazione imp in imprese_col)
                                    //{
                                    //    if(inv.IdImpresaAggregazione == imp.IdImpresa)
                                    //        throw new Exception("Impossibile continuare, una impresa dell'aggregazione ");
                                    //}
                                }
                            }

                            NaturaSoggetto.IdAggregazione = null;
                            // se ho cambiato tipo natura soggetto elimino le priorita_x_impresa tranne
                            //dell'impresa che presenta la domamda  
                            SiarLibrary.PrioritaXImpresaCollection p_x_i_coll = p_x_i_prov.Find(null, null, Progetto.IdProgetto, null, null);
                            foreach(SiarLibrary.PrioritaXImpresa pxi in p_x_i_coll)
                            {
                                if (pxi.IdImpresa != Progetto.IdImpresa)
                                    p_x_i_prov.Delete(pxi);
                            }
                        }


                    }
                }
                natura_prov.Save(NaturaSoggetto);
            }
            catch (Exception exc) {  ShowError(exc); }
        }

        
        protected void btnSalvaAggregazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAggregazione.SelectedValue == "" || ddlAggregazione.SelectedValue == null)
                    throw new Exception("Selezionare l'aggregazione");
                //Verifico se si sta cambiano aggregaziomne e se non ci sono vocid el piano investimenti con imprese di una vecchia agrgegazione
                if(NaturaSoggetto.IdAggregazione != null  && NaturaSoggetto.IdAggregazione != ddlAggregazione.SelectedValue)
                {
                    SiarLibrary.ImpresaAggregazioneCollection imprese_col = new SiarBLL.ImpresaAggregazioneCollectionProvider().Find(NaturaSoggetto.IdAggregazione, null, null, null, null);
                    SiarLibrary.PianoInvestimentiCollection piano_col = new SiarBLL.PianoInvestimentiCollectionProvider().Find(null, Progetto.IdProgetto, null, null, null, null, null);
                    foreach (SiarLibrary.PianoInvestimenti inv in piano_col)
                    {
                        if (inv.IdInvestimentoOriginale == null && inv.IdImpresaAggregazione != null)
                        {
                            foreach (SiarLibrary.ImpresaAggregazione imp in imprese_col)
                            {
                                if(inv.IdImpresaAggregazione == imp.IdImpresa)
                                    throw new Exception("Impossibile continuare, una impresa dell'aggregazione precedentemente selezionata ha in carico una voce del piano investimenti, eliminare la voce per poter continuare.");
                            }
                        }
                    }
                }


                NaturaSoggetto.IdAggregazione = ddlAggregazione.SelectedValue;
                natura_prov.Save(NaturaSoggetto);
                if (ddlFormaNaturaSoggetto.SelectedValue == "Singola")
                    hdnIdImpresaAggregazione.Value = Progetto.IdImpresa.ToString();
                else
                    hdnIdImpresaAggregazione.Value = "";
            }
            catch (Exception exc) { ShowError(exc); }
        }

        protected void btnPostImpresaAggregazione_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalvaPriorita_Click(object sender, EventArgs e)
        {
            // priorita x impresa
            int IdImpresaPriorita = Convert.ToInt32(hdnIdImpresaAggregazione.Value);
            p_x_i_prov.DeleteCollection(p_x_i_prov.Find(null, IdImpresaPriorita, Progetto.IdProgetto, null, null));
            foreach (string s in PrioritaImpresa)
            {
                string[] valori_priorita = s.Split('|');
                SiarLibrary.PrioritaXImpresa pxi = new SiarLibrary.PrioritaXImpresa();
                pxi.IdImpresa = IdImpresaPriorita;
                pxi.IdProgetto = Progetto.IdProgetto;
                pxi.IdPriorita = valori_priorita[1];
                if (valori_priorita[0] == "z") pxi.IdValore = valori_priorita[2];
                else if (valori_priorita[0] == "q") pxi.ValTesto = valori_priorita[2];
                else if (valori_priorita[0] == "n") pxi.Valore = valori_priorita[2];
                else if (valori_priorita[0] == "d") pxi.ValData = valori_priorita[2];
                else if (valori_priorita[0] == "t") pxi.ValTesto = valori_priorita[2];
                else if (valori_priorita[0] == "a") pxi.ValTesto = valori_priorita[2];
                else pxi.Scelto = true;
                p_x_i_prov.Save(pxi);
            }
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                bool _fase_istruttoria = false;
                SiarLibrary.SchedaXPriorita sxp = (SiarLibrary.SchedaXPriorita)dgi.DataItem;
                if (sxp.PluriValore)
                {
                    string hdn = "hdnPriorita" + sxp.IdPriorita;
                    string hdnval = "hdnValoriPriorita" + sxp.IdPriorita;
                    string lbl = "labelValoriPriorita" + sxp.IdPriorita;

                    SiarLibrary.NullTypes.IntNT ValorePriorita = new SiarLibrary.NullTypes.IntNT(Request.Form[hdnval]);
                    SiarLibrary.NullTypes.StringNT TestoPriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[lbl]);
                    //if (!IsPostBack)
                    //{
                        int id_valore;
                        if (int.TryParse(sxp.AdditionalAttributes["IdValore"], out id_valore))
                        {
                            ValorePriorita = id_valore;
                            TestoPriorita = sxp.AdditionalAttributes["PlurivaloreDescrizione"];
                        }
                        else
                        {
                            ValorePriorita = null;
                            TestoPriorita = null;
                        }
                    //}
                    e.Item.Cells[2].Text = "<img src='" + Request.ApplicationPath +
                        "/images/folderopen.png' style='cursor:pointer' onclick=\"SNCZoomPlurivalore(" + sxp.IdPriorita
                        + ",'getPlurivaloriRequisitiDomanda',selezionaPlurivalore,0);\" alt='Apri il popup di selezione del valore' />&nbsp;&nbsp;" +
                        "<img src='" + Request.ApplicationPath + "/images/xdel.gif' style='cursor:pointer' onclick='deselezionaPlurivalore("
                        + sxp.IdPriorita + ");' alt='Deseleziona' />";
                    e.Item.Cells[3].Text = "<input type='hidden' id='" + hdn + "' name='" + hdn + "' value='" + sxp.IdPriorita + "' />" +
                        "<input type='hidden' id='" + hdnval + "' name='" + hdnval + "' value='" + ValorePriorita + " ' />" +
                        "<input type='hidden' id='" + lbl + "' name='" + lbl + "' value=\"" + TestoPriorita + "\">" +
                        "<span id='" + lbl + "_text' name='" + lbl + "_text' style='font-weight:bold'>" + TestoPriorita + "</span>";
                }
                else if (sxp.PluriValoreSql)
                {
                    string hdn = "hdnPrioritaSql" + sxp.IdPriorita;
                    string hdnval = "hdnValoriPrioritaSql" + sxp.IdPriorita;
                    string lbl = "labelValoriPrioritaSql" + sxp.IdPriorita;

                    SiarLibrary.NullTypes.StringNT ValorePriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[hdnval]);
                    SiarLibrary.NullTypes.StringNT TestoPriorita = new SiarLibrary.NullTypes.StringNT(Request.Form[lbl]);
                    //bool deleted = false;
                    if (IsPostBack )
                    {
                        if (!string.IsNullOrEmpty(sxp.AdditionalAttributes["ValTesto"]))
                        {
                            ValorePriorita = sxp.AdditionalAttributes["ValTesto"];
                            SiarLibrary.ValoriPrioritaCollection cc = new SiarBLL.ValoriPrioritaCollectionProvider().GetValoriPrioritaSql(Progetto.IdProgetto, 
                                _fase_istruttoria, sxp.IdPriorita, ValorePriorita);
                            if (cc.Count > 0) TestoPriorita = cc[0].Descrizione;  // ------> testo da valorizzare se il requisito e' gia' stato salvato
                            else
                            {
                                ValorePriorita = null;
                                TestoPriorita = null;
                            }
                        }
                    }

                    //id_progetto, fase_istruttoria, id_requisito,search_method,select_js_method,page_index
                    e.Item.Cells[2].Text = "<img src='" + Request.ApplicationPath +
                        "/images/folderopen.png' style='cursor:pointer' onclick=\"SNCZoomPlurivaloreSql(" + (Progetto.IdProgetto)
                        + ", " + _fase_istruttoria.ToString().ToLower() + " ," + sxp.IdPriorita
                        + ",'getPlurivaloriSql',selezionaPlurivaloreSql,0);\" alt='Apri il popup di selezione del valore' />&nbsp;&nbsp;" +
                        "<img src='" + Request.ApplicationPath + "/images/xdel.gif' style='cursor:pointer' onclick='deselezionaPlurivaloreSql("
                        + sxp.IdPriorita + ");' alt='Deseleziona' />";
                    e.Item.Cells[3].Text = "<input type='hidden' id='" + hdn + "' name='" + hdn + "' value='" + sxp.IdPriorita + "' />" +
                        "<input type='hidden' id='" + hdnval + "' name='" + hdnval + "' value='" + ValorePriorita + "' />" +
                        "<input type='hidden' id='" + lbl + "' name='" + lbl + "' value=\"" + TestoPriorita + "\">" +
                        "<span id='" + lbl + "_text' name='" + lbl + "_text' style='font-weight:bold'>" + TestoPriorita + "</span>";
                }
                else if (sxp.InputNumerico)
                {
                    string nome_casella = "txtPrioritaNumerica" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || !string.IsNullOrEmpty(sxp.AdditionalAttributes["Valore"])) valore = sxp.AdditionalAttributes["Valore"];
                    else valore = null;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" style=\"display:inline-block;width:124px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:right;WIDTH:100px;\" value='" + valore + "'/></span>";
                }
                else if (sxp.Datetime)
                {
                    string nome_casella = "txtPrioritaDatetime" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || !string.IsNullOrEmpty(sxp.AdditionalAttributes["ValData"])) valore = sxp.AdditionalAttributes["ValData"];
                    else valore = null;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" style=\"display:inline-block;width:124px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:right;WIDTH:100px;\" value='" + valore + "'/></span>";
                }
                else if (sxp.TestoSemplice)
                {
                    string nome_casella = "txtPrioritaTestoSemplice" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || !string.IsNullOrEmpty(sxp.AdditionalAttributes["ValTesto"])) valore = sxp.AdditionalAttributes["ValTesto"];
                    else valore = null;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" style=\"display:inline-block;width:300px;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:left;WIDTH:300px;\" value='" + valore + "'/></span>";
                }
                else if (sxp.TestoArea)
                {
                    string nome_casella = "txtPrioritaTestoArea" + sxp.IdPriorita;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (!IsPostBack || !string.IsNullOrEmpty(sxp.AdditionalAttributes["ValTesto"])) valore = sxp.AdditionalAttributes["ValTesto"];
                    else valore = null;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3' style='text-align:left;width:320px'>" + valore + "</textarea></span>";
                }
                else
                {
                    int id_impresa;
                    if ( int.TryParse(sxp.AdditionalAttributes["IdImpresa"], out id_impresa))
                        e.Item.Cells[2].Text = e.Item.Cells[2].Text.Replace("<input", "<input checked");
                }
            }
        }
    }
}