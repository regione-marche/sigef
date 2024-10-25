using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class RequisitiMisura : System.Web.UI.UserControl
    {
        private bool _fase_istruttoria = false;
        public bool fase_istruttoria
        {
            set { _fase_istruttoria = value; }
        }
        private SiarLibrary.BandoProgrammazione _disposizioniAttuative;
        public SiarLibrary.BandoProgrammazione DisposizioniAttuative
        {
            get { return _disposizioniAttuative; }
            set { _disposizioniAttuative = value; }
        }

        private SiarLibrary.NullTypes.IntNT _idProgIntegrato;
        public SiarLibrary.NullTypes.IntNT IdProgIntegrato { set { _idProgIntegrato = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_disposizioniAttuative != null) loadMisura();
            base.OnPreRender(e);
        }

        public void loadMisura()
        {
            rowMisura.InnerHtml = _disposizioniAttuative.Codice + " - " + _disposizioniAttuative.Descrizione;
            hdnIdDisposizioniMisura.Value = _disposizioniAttuative.IdDisposizioniAttuative;
            SiarLibrary.PrioritaXProgettoCollection priorita = new SiarBLL.PrioritaXProgettoCollectionProvider()
                .GetPrioritaDisposizioniAttuative(_disposizioniAttuative.IdDisposizioniAttuative, "D",
                _disposizioniAttuative.AdditionalAttributes["IdProgetto"]);
            dgPriorita.DataSource = priorita;
            if (priorita.Count == 0) dgPriorita.Titolo = "Nessun requisito previsto dal bando di riferimento.";
            else dgPriorita.ItemDataBound += new DataGridItemEventHandler(dgPriorita_ItemDataBound);
            dgPriorita.DataBind();
        }

        void dgPriorita_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PrioritaXProgetto pp = (SiarLibrary.PrioritaXProgetto)e.Item.DataItem;
                if (pp.PluriValore)
                {
                    System.Web.UI.WebControls.Label lc = new System.Web.UI.WebControls.Label();
                    lc.ID = "lblPlurivaloreSelezionato" + pp.IdPriorita;
                    lc.Text = pp.ValoreDesc;  // ------> testo da valorizzare se il requisito e' gia' stato salvato
                    e.Item.Cells[3].Controls.Add(lc);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdn = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdn.ID = "hdnPlurivaloreSelezionato" + pp.IdPriorita;
                    hdn.Value = pp.IdValore; // ------>id_valore da valorizzare se il requisito e' gia' stato salvato
                    e.Item.Cells[3].Controls.Add(hdn);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdnIdDispo = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdnIdDispo.ID = "hdnPlurivaloreSelezionatoDisposizione" + pp.IdPriorita;
                    hdnIdDispo.Value = _disposizioniAttuative.IdDisposizioniAttuative;
                    e.Item.Cells[3].Controls.Add(hdnIdDispo);
                    CONTROLS.SNCPlurivalore c = (CONTROLS.SNCPlurivalore)LoadControl("~/controls/SNCPlurivalore.ascx");
                    c.IdRequisito = pp.IdPriorita;
                    c.SelectJsFunction = "selezionaPlurivalore"; //------> funzione javascript da implementare sulla pagina per gestire il seleziona (il nome e' solo indicativo)
                    c.ClearJsFunction = "deselezionaPlurivalore"; //------> funzione javascript da implementare sulla pagina per gestire il deseleziona (il nome e' solo indicativo)
                    c.SearchFunction = "getPlurivaloriRequisitiDomanda";// ----> funzione latoserver su controls/ajaxrequest.aspx per il recupero dei dati (il nome e' solo indicativo)
                    e.Item.Cells[2].Controls.Add(c);

                    //Control c = LoadControl("~/controls/SiarNewZoomRequisitoPriorita.ascx");
                    //SiarLibrary.ValoriPriorita v = new SiarLibrary.ValoriPriorita();
                    //v.IdPriorita = pp.IdPriorita;
                    //v.AdditionalAttributes.Add("IdDisposizioniAttuative", _disposizioniAttuative.IdDisposizioniAttuative);

                    //c.GetType().GetProperty("ValoreSelezionato").SetValue(c, v, null);
                    //e.Item.Cells[2].Controls.Add(c);
                    //e.Item.Cells[3].ID = "tdZoomTestoValorePriorita" + pp.IdPriorita;
                }
                else if (pp.PluriValoreSql)
                {
                    System.Web.UI.WebControls.Label lc = new System.Web.UI.WebControls.Label();
                    lc.ID = "lblPlurivaloreSelezionatoSql" + pp.IdPriorita;
                    bool deleted = false;
                    if (_idProgIntegrato == null)
                        _idProgIntegrato = pp.IdProgetto;
                    if (!string.IsNullOrEmpty(pp.ValTesto))
                    {
                        SiarLibrary.ValoriPrioritaCollection cc = new SiarBLL.ValoriPrioritaCollectionProvider().GetValoriPrioritaSql(_idProgIntegrato,
                            _fase_istruttoria, pp.IdPriorita, pp.ValTesto);
                        if (cc.Count > 0) lc.Text = cc[0].Descrizione;  // ------> testo da valorizzare se il requisito e' gia' stato salvato
                        else
                        {
                            deleted = true;
                            lc.Text = string.Empty;
                        }
                    }
                    e.Item.Cells[3].Controls.Add(lc);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdn = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdn.ID = "hdnPlurivaloreSelezionatoSql" + pp.IdPriorita;
                    if (!deleted)
                        hdn.Value = pp.ValTesto; // ------>id_valore da valorizzare se il requisito e' gia' stato salvato. Se ho cancellato il record non valorizzo il valore salvato
                    else
                        hdn.Value = string.Empty;
                    e.Item.Cells[3].Controls.Add(hdn);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdnIdDispo = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdnIdDispo.ID = "hdnPlurivaloreSelezionatoDisposizioneSql" + pp.IdPriorita;
                    hdnIdDispo.Value = _disposizioniAttuative.IdDisposizioniAttuative;
                    e.Item.Cells[3].Controls.Add(hdnIdDispo);
                    CONTROLS.SNCPlurivaloreSql c = (CONTROLS.SNCPlurivaloreSql)LoadControl("~/controls/SNCPlurivaloreSql.ascx");
                    c.IdProgetto = _idProgIntegrato;
                    c.FaseIstruttoria = _fase_istruttoria;
                    c.IdRequisito = pp.IdPriorita;
                    c.SelectJsFunction = "selezionaPlurivaloreSql"; //------> funzione javascript da implementare sulla pagina per gestire il seleziona (il nome e' solo indicativo)
                    c.ClearJsFunction = "deselezionaPlurivaloreSql"; //------> funzione javascript da implementare sulla pagina per gestire il deseleziona (il nome e' solo indicativo)
                    c.SearchFunction = "getPlurivaloriSql";// ----> funzione latoserver su controls/ajaxrequest.aspx per il recupero dei dati (il nome e' solo indicativo)
                    e.Item.Cells[2].Controls.Add(c);
                }
                else if (pp.InputNumerico)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.Valore != null && !Page.IsPostBack) valore = pp.Valore;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (pp.Datetime)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValData != null && !Page.IsPostBack) valore = pp.ValData.ToString("dd/MM/yyyy");
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (pp.TestoSemplice)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValTesto != null && !Page.IsPostBack) valore = pp.ValTesto;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" value='" + valore + "'/></span>";
                }
                else if (pp.TestoArea)
                {
                    string nome_casella = "txtPriorita" + pp.IdPriorita + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (pp.ValTesto != null && !Page.IsPostBack) valore = pp.ValTesto;
                    e.Item.Cells[2].Text = "";
                    e.Item.Cells[3].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3'>" + valore + "</textarea></span>";

                }
                else if (pp.IdProgetto != null)
                {
                    string testo_check = e.Item.Cells[2].Text.Replace("<input type='checkbox'", "<input type='checkbox' checked");
                    e.Item.Cells[2].Text = testo_check;
                }
            }
        }
    }
}