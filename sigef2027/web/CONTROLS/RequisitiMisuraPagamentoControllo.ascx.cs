using System;
using System.Web.UI.WebControls;

namespace web.CONTROLS
{
    public partial class RequisitiMisuraPagamentoControllo : System.Web.UI.UserControl
    {
        private SiarLibrary.BandoProgrammazione _disposizioniAttuative;
        public SiarLibrary.BandoProgrammazione DisposizioniAttuative
        {
            get { return _disposizioniAttuative; }
            set { _disposizioniAttuative = value; }
        }

        public SiarLibrary.DomandaDiPagamento Domanda { get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).DomandaPagamento; } }
        private SiarLibrary.DbProvider dbProvider { get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).PagamentoProvider.DbProviderObj; } }

        private SiarLibrary.DomandaPagamentoRequisitiCollection _requisitiInseriti;
        public SiarLibrary.DomandaPagamentoRequisitiCollection RequisitiInseriti
        {
            get { return _requisitiInseriti; }
            set { _requisitiInseriti = value; }
        }

        private bool _requisitiObbligatoriVerificati = true;
        public bool RequisitiObbligatoriVerificati { get { return _requisitiObbligatoriVerificati; } }

        private bool _verificaRequisiti = false;
        public bool VerificaRequisiti
        {
            set { _verificaRequisiti = value; }
        }

        SiarBLL.DomandaPagamentoRequisitiCollectionProvider requisiti_domanda_provider = new SiarBLL.DomandaPagamentoRequisitiCollectionProvider();


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
                .Find(DisposizioniAttuative.IdDisposizioniAttuative, Domanda.CodTipo, null).FiltroDiControllo(true);
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
                SiarLibrary.DomandaPagamentoRequisiti requisito_domanda = RequisitiInseriti.CollectionGetById(Domanda.IdDomandaPagamento,
                    requisito.IdRequisito);
                if (_verificaRequisiti) VerificaRequisito(requisito, ref requisito_domanda);
                if (_requisitiObbligatoriVerificati && requisito.Obbligatorio &&
                    (requisito_domanda == null || requisito_domanda.Esito == null || requisito_domanda.Esito != "SI"))
                    _requisitiObbligatoriVerificati = false;
                if (requisito_domanda != null)
                {
                    RequisitiInseriti.Remove(requisito_domanda);
                    if (requisito_domanda.Esito == "SI") dgi.Cells[3].Style.Add("color", "#0b9007");
                    else dgi.Cells[3].Style.Add("color", "#be0202");
                    dgi.Cells[3].Text = requisito_domanda.Esito;
                    if (requisito_domanda.Esito == "ER")
                        dgi.Cells[3].Text = "Attenzione! Errore nella esecuzione della verifica, si prega di contattare l'helpdesk.";
                }
            }
        }

        private void VerificaRequisito(SiarLibrary.BandoRequisitiPagamento requisito, ref SiarLibrary.DomandaPagamentoRequisiti requisito_domanda)
        {
            string esito;
            try { esito = (VerificaStepAutomatico(requisito) ? "SI" : "NO"); }
            catch { esito = "ER"; }
            if (requisito_domanda == null)
            {
                requisito_domanda = new SiarLibrary.DomandaPagamentoRequisiti();
                requisito_domanda.IdDomandaPagamento = Domanda.IdDomandaPagamento;
                requisito_domanda.IdRequisito = requisito.IdRequisito;
            }
            requisito_domanda.Esito = esito;
            requisito_domanda.DataEsito = DateTime.Now;
            requisiti_domanda_provider.Save(requisito_domanda);
        }

        private bool VerificaStepAutomatico(SiarLibrary.BandoRequisitiPagamento requisito)
        {
            int queryResult = 0;
            System.Data.IDbCommand cmd = dbProvider.GetCommand();
            cmd.CommandText = requisito.QueryEval;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", Domanda.IdDomandaPagamento.Value));
            dbProvider.InitDatareader(cmd);
            if (dbProvider.DataReader.Read())
                int.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);

            // Possono essere ritornati più recordset -> L'ultimo rappresenta il risultato dello Step
            while (dbProvider.DataReader.NextResult())
            {
                if (dbProvider.DataReader.Read())
                    int.TryParse(dbProvider.DataReader.GetValue(0).ToString(), out queryResult);
            }
            dbProvider.Close();
            return queryResult == 1;
        }
    }
}