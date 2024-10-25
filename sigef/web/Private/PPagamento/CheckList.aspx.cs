using System;
using System.Data;
using System.Web.UI;

namespace web.Private.PPagamento
{
    public partial class CheckList : SiarLibrary.Web.DomandaPagamentoPage
    {
        SiarLibrary.DomandaPagamentoRequisitiCollection requisiti_domanda = new SiarLibrary.DomandaPagamentoRequisitiCollection();
        private bool VerificaRequisiti = false;
        SiarBLL.BandoProgrammazioneCollectionProvider bp_provider;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        protected void Page_Load(object sender, EventArgs e)
        {
            bp_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(PagamentoProvider.DbProviderObj);
            disposizioni_attuative = bp_provider.GetDispAttuativeBando(Progetto.IdBando, Progetto.IdProgetto);
            AbilitaModifica = AbilitaModifica && DomandaPagamento.IdFidejussione == null;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!IsPostBack && DomandaPagamento.Segnatura == null) VerificaRequisiti = true; // imposto la verifica all'apertura della pagina            
            if (requisiti_domanda.Count == 0) requisiti_domanda = new SiarBLL.DomandaPagamentoRequisitiCollectionProvider()
                 .Find(DomandaPagamento.IdDomandaPagamento, null, null);

            // controllo massimali di pagamento solo saldo e sal
            if (DomandaPagamento.CodTipo != "ANT")
            {
                string errore = PagamentoProvider.ControlloMassimaliDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
                if (!string.IsNullOrEmpty(errore))
                {
                    ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! " + errore;
                    ucWorkflowPagamento.ProseguiAbilitato = false;
                    ShowError(errore);
                    VerificaRequisiti = false;
                }
            }
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl("~/CONTROLS/RequisitiMisuraPagamentoControllo.ascx");
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                pi = c.GetType().GetProperty("RequisitiInseriti");
                pi.SetValue(c, requisiti_domanda, null);
                pi = c.GetType().GetProperty("VerificaRequisiti");
                pi.SetValue(c, VerificaRequisiti, null);
                tdControls.Controls.Add(c);
            }
            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            bool AbilitaProsegui = true;
            ControlCollection requisiti_misure = tdControls.Controls;
            foreach (Control c in requisiti_misure)
            {
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("RequisitiObbligatoriVerificati");
                if (pi != null)
                {
                    AbilitaProsegui = (bool)pi.GetValue(c, null);
                    if (!AbilitaProsegui) break;
                }
            }
            if (!AbilitaProsegui)
            {
                ucWorkflowPagamento.ProseguiMessaggio = "Per proseguire è necessario soddisfare positivamente tutti i requisiti OBBLIGATORI.";
                ucWorkflowPagamento.ProseguiAbilitato = false;
            }
            base.OnPreRenderComplete(e);
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                // abilita la verifica dei requisiti sui misura controls al momento del databind
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                VerificaRequisiti = true;
            }
            catch (Exception ex) { ShowError(ex); }

        }
    }
}