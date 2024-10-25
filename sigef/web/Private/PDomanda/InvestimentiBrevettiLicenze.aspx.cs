using System;

namespace web.Private.PDomanda
{
    public partial class InvestimentiBrevettiLicenze : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoBrevettoLicenza ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            try
            {
                int id_progetto_corrente, id_investimento;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (IsProgettoIntegrato) progetto_corrente = ProgettoProvider.GetById(id_progetto_corrente);
                    else progetto_corrente = Progetto;
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento) || int.TryParse(hdnIdInvestimento.Value, out id_investimento))
                {
                    hdnIdInvestimento.Value = id_investimento.ToString();
                    investimento = investimenti_provider.GetById(id_investimento);
                    if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto) throw new Exception("L`investimento selezionato non è valido.");
                }

                ComponenteInvestimento = (CONTROLS.InvestimentoBrevettoLicenza)LoadControl(System.Web.HttpRuntime.AppDomainAppVirtualPath
                    + "/controls/InvestimentoBrevettoLicenza.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "PDOMANDA";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnDelete.Enabled = AbilitaModifica && investimento != null && investimento.IdInvestimento != null;
            if (AbilitaModifica)
            {
                btnNuovo.Disabled = false;
                btnNuovo.Attributes.Add("onclick", "location='InvestimentiBrevettiLicenze.aspx?idpcurrent=" + progetto_corrente.IdProgetto + "'");
            }
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
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Spesa per brevetti/licenze salvata correttamente.");
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
