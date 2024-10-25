using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class RequisitiMisuraPagamento : System.Web.UI.UserControl
    {
        private SiarLibrary.BandoProgrammazione _disposizioniAttuative;
        public SiarLibrary.BandoProgrammazione DisposizioniAttuative
        {
            get { return _disposizioniAttuative; }
            set { _disposizioniAttuative = value; }
        }

        private SiarLibrary.DomandaDiPagamento _domanda;
        public SiarLibrary.DomandaDiPagamento Domanda
        {
            get { return _domanda; }
            set { _domanda = value; }

        }

        private SiarLibrary.DomandaPagamentoRequisitiCollection _requisitiInseriti;
        public SiarLibrary.DomandaPagamentoRequisitiCollection RequisitiInseriti
        {
            get { return _requisitiInseriti; }
            set { _requisitiInseriti = value; }

        }

        private bool _requisitiObbligatoriInseriti = true;
        public bool RequisitiObbligatoriInseriti { get { return _requisitiObbligatoriInseriti; } }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            if (_disposizioniAttuative != null)
            {
                loadMisura();
                rowMisura.InnerHtml = _disposizioniAttuative.Codice + " \"" + _disposizioniAttuative.Descrizione + "\"";
                hdnIdDisposizioniMisura.Value = _disposizioniAttuative.IdDisposizioniAttuative;
            }
            base.OnPreRender(e);
        }

        public void loadMisura()
        {
            SiarLibrary.BandoRequisitiPagamentoCollection requisiti = new SiarBLL.BandoRequisitiPagamentoCollectionProvider()
                .Find(DisposizioniAttuative.IdDisposizioniAttuative, Domanda.CodTipo, null).FiltroDiInserimento(true);
            dgRequisiti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisiti.DataSource = requisiti;
            if (requisiti.Count == 0) dgRequisiti.Titolo = "Nessun requisito necessario.";
            dgRequisiti.DataBind();
        }

        void dgRequisiti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.BandoRequisitiPagamento requisito = (SiarLibrary.BandoRequisitiPagamento)dgi.DataItem;
                SiarLibrary.DomandaPagamentoRequisiti requisito_inserito = RequisitiInseriti.CollectionGetById(Domanda.IdDomandaPagamento,
                    requisito.IdRequisito);

                if (requisito.Obbligatorio && requisito_inserito == null && requisito.Url == null)
                    _requisitiObbligatoriInseriti = false;

                if (requisito.Plurivalore)
                {
                    System.Web.UI.WebControls.Label lc = new System.Web.UI.WebControls.Label();
                    lc.ID = "lblPlurivaloreSelezionato" + requisito.IdRequisito;
                    if (requisito_inserito != null) lc.Text = requisito_inserito.DescrizioneValore;  // ------> testo da valorizzare se il requisito e' gia' stato salvato
                    e.Item.Cells[4].Controls.Add(lc);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdn = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdn.ID = "hdnPlurivaloreSelezionato" + requisito.IdRequisito;
                    if (requisito_inserito != null) hdn.Value = requisito_inserito.IdValore; // ------>id_valore da valorizzare se il requisito e' gia' stato salvato
                    e.Item.Cells[4].Controls.Add(hdn);
                    System.Web.UI.HtmlControls.HtmlInputHidden hdnIdDispo = new System.Web.UI.HtmlControls.HtmlInputHidden();
                    hdnIdDispo.ID = "hdnPlurivaloreSelezionatoDisposizione" + requisito.IdRequisito;
                    hdnIdDispo.Value = _disposizioniAttuative.IdDisposizioniAttuative;
                    e.Item.Cells[4].Controls.Add(hdnIdDispo);
                    CONTROLS.SNCPlurivalore c = (CONTROLS.SNCPlurivalore)LoadControl("~/controls/SNCPlurivalore.ascx");
                    c.IdRequisito = requisito.IdRequisito;
                    c.SelectJsFunction = "selezionaPlurivalore"; //------> funzione javascript da implementare sulla pagina per gestire il seleziona (il nome e' solo indicativo)
                    c.ClearJsFunction = "deselezionaPlurivalore"; //------> funzione javascript da implementare sulla pagina per gestire il deseleziona (il nome e' solo indicativo)
                    c.SearchFunction = "getPlurivaloriRequisitiPagamento";// ----> funzione latoserver su controls/ajaxrequest.aspx per il recupero dei dati (il nome e' solo indicativo)
                    e.Item.Cells[3].Controls.Add(c);

                }
                else if (requisito.Url != null)
                {
                    e.Item.Cells[3].Text = "";
                    e.Item.Cells[4].Attributes.Add("align", "center");
                    e.Item.Cells[4].Text = "<a href='" + requisito.Url + "'>Vai alla pagina di modifica dei dati >>></a>";
                }
                else if (requisito.Numerico)
                {
                    e.Item.Cells[3].Text = "";
                    string nome_casella = "txtRequisitoNumerico" + requisito.IdRequisito + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack) valore = requisito_inserito.ValNumerico;
                    e.Item.Cells[4].Text = "<span id=\"" + nome_casella + "\" class=\"CurrencyBox\" style=\"display:inline-block;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:right;\" value='" + valore + "'/></span>";
                }
                else if (requisito.Datetime)
                {
                    e.Item.Cells[3].Text = "";
                    string nome_casella = "txtRequisitoDatetime" + requisito.IdRequisito + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack && requisito_inserito.ValData != null) valore = requisito_inserito.ValData.ToString("dd/MM/yyyy");
                    e.Item.Cells[4].Text = "<span id=\"" + nome_casella + "\" class=\"DataBox\" style=\"display:inline-block;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:right;\" value='" + valore + "'/></span>   (click con il destro per il calendario)";
                }
                else if (requisito.TestoSemplice)
                {
                    e.Item.Cells[3].Text = "";
                    string nome_casella = "txtRequisitoTestoSemplice" + requisito.IdRequisito + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack) valore = requisito_inserito.ValTesto;
                    e.Item.Cells[4].Text = "<span id=\"" + nome_casella + "\" class=\"TextBox\" style=\"display:inline-block;\">"
                        + "<input name=\"" + nome_casella + "_text\" type=\"text\" id=\"" + nome_casella
                        + "_text\" style=\"text-align:left;\" value='" + valore + "'/></span>";
                }
                else if (requisito.TestoArea)
                {
                    e.Item.Cells[3].Text = "";
                    string nome_casella = "txtRequisitoTestoArea" + requisito.IdRequisito + "_" + _disposizioniAttuative.IdDisposizioniAttuative;
                    string valore = Request.Form[nome_casella + "_text"];
                    if (requisito_inserito != null && !Page.IsPostBack) valore = requisito_inserito.ValTesto;
                    e.Item.Cells[4].Text = "<span id='" + nome_casella + "' class='TextArea'><textarea id='" + nome_casella + "_text' name='"
                        + nome_casella + "_text' cols='20' rows='3' style='text-align:left;'>" + valore + "</textarea></span>";
                }
                else //checkbox
                {
                    if (!Page.IsPostBack && requisito_inserito != null && requisito_inserito.Selezionato)
                        e.Item.Cells[3].Text = e.Item.Cells[3].Text.Insert(e.Item.Cells[3].Text.IndexOf("type='checkbox'"), "checked ");
                }
            }
        }
    }
}