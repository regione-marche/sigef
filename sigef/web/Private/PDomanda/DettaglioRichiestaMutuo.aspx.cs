using System;

namespace web.Private.PDomanda
{
    public partial class DettaglioRichiestaMutuo : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;        
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoDettaglioMutuoTip2 ComponenteInvestimento;    

        protected void Page_Load(object sender, EventArgs e)
        {                      
            try
            {
                investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj); 

                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, Progetto.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(true);
                if (mutuocoll.Count > 0)
                {
                    investimento = mutuocoll[0];
                    hdnIdInvestimento.Value = investimento.IdInvestimento;
                    if (investimento.IdProgetto != Progetto.IdProgetto) throw new Exception("L`investimento selezionato non corrisponde alla domanda attualmente in lavorazione. Impossibile continuare.");
                } 

                ComponenteInvestimento = (CONTROLS.InvestimentoDettaglioMutuoTip2)LoadControl(System.Web.HttpRuntime.AppDomainAppVirtualPath
                    + "/controls/InvestimentoDettaglioMutuoTip2.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.Progetto = Progetto;
                ComponenteInvestimento.Fase = "PDOMANDA";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
            }
            catch (Exception ex) { Redirect("BusinessPlan.aspx?show_error=" + ex.Message); }
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                ComponenteInvestimento.CalcolaContributoInvestimento();
                investimento = ComponenteInvestimento.Investimento;
                ProgettoProvider.DbProviderObj.BeginTran();
                investimenti_provider.Save(investimento);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Dati del mutuo salvato correttamente.");
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
