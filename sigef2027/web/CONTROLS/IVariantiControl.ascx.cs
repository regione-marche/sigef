using System;
using System.Web.UI;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class IVariantiControl : System.Web.UI.UserControl
    {
        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get
            {
                if (_progetto != null)
                    return _progetto;
                return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Progetto;
            }
            set { _progetto = value; }
        }

        private SiarLibrary.Impresa _impresa;
        public SiarLibrary.Impresa Impresa
        {
            get { return _impresa; }
        }

        private SiarLibrary.Varianti _variante;
        public SiarLibrary.Varianti Variante
        {
            get
            {
                if (_variante != null)
                    return _variante;
                return ((SiarLibrary.Web.IstruttoriaVariantePage)Page).Variante;
            }
            set { _variante = value; }
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
                if (ps.Count > 0) ucSNCVPPDomanda.Segnatura = ps[0].Segnatura;
                lblApprovazione.Text = Variante.Annullata ? "<B>ANNULLATA DAL RICHIEDENTE</B>" : (Variante.Approvata == null ? null :
                    (Variante.Approvata ? "SI" : "NO"));
                lblDescrizione.Text = "<b>" + Variante.TipoVariante.ToString().ToUpper() + ": </b>";
                if (Variante.Descrizione != null)
                {
                    string descrizione = Variante.Descrizione.Value;
                    if (descrizione.Length > 120) descrizione = descrizione.Substring(0, 120) + "...";
                    lblDescrizione.Text += descrizione;
                }
                _impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                if (_impresa != null)
                {
                    lblCodiceFiscale.Text = _impresa.CodiceFiscale;
                    lblRagioneSociale.Text = _impresa.RagioneSociale;
                }
                if (Variante.Segnatura == null)
                {
                    // LE VARIANTI DI TIPO 'AR','VI' NON HANNO SEGNATURA
                    ucSNCVPVariante.TipoVisualizzazione = web.CONTROLS.SNCOptions.ViewOption.Invisibile;
                    ucVRRicevutaProtocollazione.ReportViewOptions = web.CONTROLS.SNCOptions.ViewOption.Invisibile;
                }
                else
                {
                    ucSNCVPVariante.Segnatura = Variante.Segnatura;
                    ucVRRicevutaProtocollazione.ReportParameters = "IdVariante=" + Variante.IdVariante;
                }
            }
        }
    }
}