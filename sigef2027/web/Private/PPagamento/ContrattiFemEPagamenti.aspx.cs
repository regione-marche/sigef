using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.PPagamento
{
    public partial class ContrattiFemEPagamenti : SiarLibrary.Web.DomandaPagamentoPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucContrattiFemEPagamenti.Domanda = DomandaPagamento;
            ucContrattiFemEPagamenti.Utente = Operatore.Utente;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            //if (!spese_presenti)
            //{
            //    ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! Per proseguire occorre inserire almeno una voce di pagamento.";
            //    ucWorkflowPagamento.ProseguiAbilitato = false;
            //}
            base.OnPreRenderComplete(e);
        }
    }
}