using System;

namespace web.Private.IPagamento
{
    public partial class RichiestaCertificazione : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarLibrary.ProgettoComunicazioni com_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idComunicazione;
            try
            {
                if (int.TryParse(Request.QueryString["idcom"], out idComunicazione)) com_selezionata = comunicazioni_provider.GetById(idComunicazione);
                if (com_selezionata != null && com_selezionata.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento) throw new Exception("La comunicazione selezionata non è valida.");
                if (com_selezionata == null || com_selezionata.CodTipo != "RCC" || DomandaPagamento == null) throw new Exception("La comunicazione selezionata non è valida.");

                ucRichiestaDocumentazione.Progetto = Progetto;
                ucRichiestaDocumentazione.DomandaPagamento = DomandaPagamento;
                ucRichiestaDocumentazione.ProgettoComunicazioni = com_selezionata;
            }
            catch (Exception ex) { Redirect("CheckListPagamento.aspx", ex.Message, true); }
        }
    }
}
