using System;


namespace web.Private.IPagamento.IVariante
{
    public partial class RichiestaCertificazioneVariante : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarLibrary.ProgettoComunicazioni com_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idComunicazione;
            try
            {
                if (int.TryParse(Request.QueryString["idcom"], out idComunicazione)) com_selezionata = comunicazioni_provider.GetById(idComunicazione);
                if (com_selezionata != null && com_selezionata.IdVariante != Variante.IdVariante) throw new Exception("La comunicazione selezionata non è valida.");
                if (com_selezionata == null || com_selezionata.CodTipo != "RCC" || Variante == null) throw new Exception("La comunicazione selezionata non è valida.");
                ucRichiestaDocumentazione.Progetto = Progetto;
                ucRichiestaDocumentazione.Variante = Variante;
                ucRichiestaDocumentazione.ProgettoComunicazioni = com_selezionata;
            }
            catch (Exception ex) { Redirect("Allegati.aspx", ex.Message, true); }
        }

    }
}
