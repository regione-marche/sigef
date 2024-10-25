using System;

namespace web.CONTROLS
{
    public partial class CardVariantiIstruttoria : System.Web.UI.UserControl
    {
        private SiarLibrary.Progetto Progetto
        {
            get { return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Progetto; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
        }

        private SiarLibrary.Varianti Variante
        {
            get { return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Variante; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            if (Progetto != null)
            {
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
                if(ps.Count >0)ucSNCVPPDomanda.Segnatura = ps[0].Segnatura;
                _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                if (_impresa != null)
                {
                    lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                    lblRagioneSociale.Text = _impresa.RagioneSociale;
                }
                lblApprovazione.Text = Variante.Annullata ? "<B>ANNULLATA DAL RICHIEDENTE</B>" : (Variante.Approvata == null ? null :
                                    (Variante.Approvata ? "SI" : "NO"));
                lblNumeroVariante.Text = Variante.IdVariante;
                lblOperatore.Text = Variante.Operatore;
                //lblDescrizione.Text = Variante.Descrizione;
                lblDescrizione.Text = Variante.TipoVariante.ToString().ToUpper();
                if (Variante.Descrizione != null)
                {
                    string descrizione = Variante.Descrizione;
                    if (descrizione.Length > 120) descrizione = descrizione.Substring(0, 120) + "...";
                    lblDescrizione.Text += descrizione;
                }
                if (Variante.Segnatura != null)
                {
                    // LE VARIANTI DI TIPO 'AR','VI' NON HANNO SEGNATURA
                    ucSNCVPVariante.TipoVisualizzazione = web.CONTROLS.SNCOptions.ViewOption.Immagine;
                    ucSNCVPVariante.Segnatura = Variante.Segnatura;
                    ucVRRicevutaProtocollazione.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Immagine;
                    ucVRRicevutaProtocollazione.ReportParameters = "IdVariante=" + Variante.IdVariante;
                }
            }
        }
    }
}