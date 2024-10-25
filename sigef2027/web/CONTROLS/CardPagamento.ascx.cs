using System;
using System.Web.UI;

namespace web.CONTROLS
{
    public partial class CardPagamento : System.Web.UI.UserControl
    {
        private bool _inIntegrazione = false;
        public bool InIntegrazione
        {
            get { return _inIntegrazione; }
            set { _inIntegrazione = value; }
        }

        public SiarLibrary.Progetto Progetto
        {
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).Progetto; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
            //set { _impresa = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is SiarLibrary.Web.DomandaPagamentoPage)
                loadData();
            else
                ((SiarLibrary.Web.PrivatePage)Page).Redirect("GestioneLavori.aspx", "Workflow procedurale di modifica domanda di pagamento non presente.", true);
        }

        protected override void OnPreRender(EventArgs e)
        {

        }

        private SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get { return ((SiarLibrary.Web.DomandaPagamentoPage)Page).DomandaPagamento; }
        }

        public void loadData()
        {
            lblStatoPagamento.Text = (DomandaPagamento.Annullata ? "ANNULLATA DAL RICHIEDENTE" : (DomandaPagamento.Segnatura == null ? "Provvisoria" : "Rilasciata"));
            lblNumeroPagamento.Text = DomandaPagamento.IdDomandaPagamento;
            lblOperatore.Text = DomandaPagamento.Operatore;
            string modalita = "";
            switch (DomandaPagamento.CodTipo)
            {
                case "ANT":
                    modalita = "Anticipo";
                    break;
                case "SAL":
                    modalita = "Acconto";
                    break;
                case "SLD":
                    modalita = "Saldo";
                    break;
                default:
                    break;
            }
            lblTipoPagamento.Text = modalita; //_workflow[0].TipoPagamento;

            _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            if (_impresa != null)
            {
                lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                lblRagioneSociale.Text = _impresa.RagioneSociale;
            }

            lnkDocumentiBando.HRef = "javascript:mostraPopupDocumentiBando(" + Progetto.IdBando + ")";

            SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);

            lblScadenzaBando.Text = b.DataScadenza;
            if (b.DataScadenza < DateTime.Now) lblScadenzaBando.Style.Add("color", "red");
            lblIdBando.Text = b.IdBando;
            lblDescBando.Text = b.Descrizione;

            lblNumero.Text = Progetto.IdProgetto;
            lblCup.Text = Progetto.CodAgea;
            lblStato.Text = Progetto.Stato;
            SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(Progetto.IdProgetto, "L", null);
            if (ps.Count > 0) ucVPProgetto.Segnatura = ps[0].Segnatura;
            if (DomandaPagamento.Segnatura != null)
            {
                ucVPPagamento.TipoVisualizzazione = web.CONTROLS.SNCOptions.ViewOption.Immagine;
                ucVPPagamento.Segnatura = DomandaPagamento.Segnatura;
                ucVRPagamento.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Immagine;
                ucVRPagamento.ReportParameters = "IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento;
            }
        }
    }
}