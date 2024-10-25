using System;

namespace web.CONTROLS
{
    public partial class IDomandaPagamento : System.Web.UI.UserControl
    {

        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get
            {
                if (_progetto != null)
                    return _progetto;
                return (SiarLibrary.Progetto)Session["_progetto"];
            }
            set { _progetto = value; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
            //set { _impresa = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private SiarLibrary.DomandaDiPagamento _domanda;
        public SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get
            {
                if (_domanda != null)
                    return _domanda;
                return (SiarLibrary.DomandaDiPagamento)Session["domanda_pagamento"];
            }
            set { _domanda = value; }
        }

        public void loadData()
        {
            lblTipoPagamento.Text = DomandaPagamento.Descrizione;
            lblStatoPagamento.Text = (DomandaPagamento.Segnatura == null ? "Provvisoria" : "Rilasciata");
            lblOperatore.Text = DomandaPagamento.Operatore;
            lblNumero.Text = Progetto.IdProgetto;
            lblStato.Text = Progetto.Stato;
            _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            if (_impresa != null)
            {
                lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                lblRagioneSociale.Text = _impresa.RagioneSociale;
            }
            SiarLibrary.ProgettoStoricoCollection ps = new SiarBLL.ProgettoStoricoCollectionProvider().Find(Progetto.IdProgetto, "L", null);
            if (ps.Count > 0) ucSNCVPPDomanda.Segnatura = ps[0].Segnatura;
            ucSNCVPPagamento.Segnatura = DomandaPagamento.Segnatura;
            ucVRPDomandaAttuale.ReportName = "rptModelloDomanda" + new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null)[0].IdDomanda;
            ucVRPDomandaAttuale.ReportParameters = "ID_Domanda=" + Progetto.IdProgetto;
            ucVRRicevutaProtocollazione.ReportParameters = "IdDomandaPagamento=" + DomandaPagamento.IdDomandaPagamento;
        }
    }
}