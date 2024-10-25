using System;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento
{
    public partial class VerificaFinaleRendicontazione : SiarLibrary.Web.DomandaPagamentoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiarLibrary.VworkflowPagamentoCollection workflow = new SiarBLL.VworkflowPagamentoCollectionProvider().Find(null, "PINVE", null, null);
            ucWorkflowPagamento.WorkflowCorrente = workflow[0];            
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (string.IsNullOrEmpty(DomandaPagamento.VerificaPagamentiEsito)) txtEsitoDettaglioLunga.Text = "NON ANCORA ESEGUITO.";
            else
            {
                txtEsitoDettaglioLunga.Text = DomandaPagamento.VerificaPagamentiMessaggio;
                txtEsitoDettaglioLunga.Text = txtEsitoDettaglioLunga.Text.Replace("<BR />", "\n\n");
                txtEsitoData.Text = DomandaPagamento.VerificaPagamentiData;
                txtEsito.Text = (DomandaPagamento.VerificaPagamentiEsito == "S" ? "POSITIVO" : "NEGATIVO"); 
            }
            base.OnPreRender(e);
        }

        protected void btnVerificaPagamenti_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
                string[] result=investimenti_provider.VerificaRendicontazionePagamentoSaldo(DomandaPagamento.IdDomandaPagamento);
                DomandaPagamento.VerificaPagamentiData = DateTime.Now;
                DomandaPagamento.VerificaPagamentiEsito = result[0];
                DomandaPagamento.VerificaPagamentiMessaggio = result[1];
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                if (result[0] == "N") ShowError("La verifica di ammissibilità ha dato esito negativo. Controllare i dettagli negli appositi campi di testo.");
                else ShowMessage(result[1]);
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
