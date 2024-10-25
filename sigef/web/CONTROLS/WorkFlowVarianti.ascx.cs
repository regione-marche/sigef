using System;

namespace web.CONTROLS
{
    public partial class WorkFlowVarianti : System.Web.UI.UserControl
    {
        private SiarLibrary.Progetto Progetto
        {
            get { return ((SiarLibrary.Web.VariantePage)Page).Progetto; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
        }

        private SiarLibrary.Varianti Variante
        {
            get { return ((SiarLibrary.Web.VariantePage)Page).Variante; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            if (Progetto != null)
            {

                lblNumero.Text = Progetto.IdProgetto;
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
                lblDescrizione.Text = Variante.Descrizione;
                lblDescrizione.Text = "<b>" + Variante.TipoVariante.ToString().ToUpper() + ": </b>";
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