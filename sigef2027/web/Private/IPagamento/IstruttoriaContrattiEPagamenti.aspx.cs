using System;
using System.Collections;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento
{
    public partial class IstruttoriaContrattiEPagamenti : SiarLibrary.Web.IstruttoriaPagamentoPage
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

    }
}