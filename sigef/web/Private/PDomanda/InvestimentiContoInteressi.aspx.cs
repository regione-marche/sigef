using System;

namespace web.Private.PDomanda
{
    public partial class InvestimentiContoInteressi : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoContoInteressi ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            try
            {
                int id_progetto_corrente;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (IsProgettoIntegrato) progetto_corrente = ProgettoProvider.GetById(id_progetto_corrente);
                    else progetto_corrente = Progetto;
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");

                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(true);
                if (mutuocoll.Count > 0) investimento = mutuocoll[0];

                ComponenteInvestimento = (CONTROLS.InvestimentoContoInteressi)LoadControl(Request.ApplicationPath + "/controls/InvestimentoContoInteressi.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "PDOMANDA";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (investimento == null) investimento = ComponenteInvestimento.Investimento;
            btnDelete.Enabled = AbilitaModifica && investimento.IdInvestimento != null;
            base.OnPreRender(e);
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                ProgettoProvider.DbProviderObj.BeginTran();
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();
                investimento = ComponenteInvestimento.Investimento;
                ShowMessage("Dati del mutuo salvati correttamente.");
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                investimento = ComponenteInvestimento.Investimento;
                if (investimento.IdInvestimento == null) throw new Exception("L'investimento selezionato non è valido.");
                ProgettoProvider.DbProviderObj.BeginTran();
                investimenti_provider.Delete(investimento);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();
                Redirect("PianoInvestimenti.aspx", "Investimento eliminato correttamente.", false);
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}