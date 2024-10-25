using System;
using System.Data;

namespace web.Private.PDomanda
{
    public partial class InvestimentiFondoPerduto : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente = null;
        SiarLibrary.PianoInvestimenti investimento = null;
        CONTROLS.InvestimentoFondoPerduto ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            try
            {
                int id_progetto_corrente, id_investimento;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (id_progetto_corrente == Progetto.IdProgetto) progetto_corrente = Progetto;
                    else progetto_corrente = ProgettoProvider.GetById(id_progetto_corrente);
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento) || int.TryParse(hdnIdInvestimento.Value, out id_investimento))
                {
                    hdnIdInvestimento.Value = id_investimento.ToString();
                    investimento = investimenti_provider.GetById(id_investimento);
                    if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto)
                        throw new Exception("L`investimento selezionato non è valido.");
                }
                if (Progetto.IdFascicolo == null && Bando.FascicoloRichiesto) throw new Exception("L'azienda non è titolare di nessun fascicolo aziendale in corso di validità.");
                ComponenteInvestimento = (CONTROLS.InvestimentoFondoPerduto)LoadControl(Request.ApplicationPath + "/controls/InvestimentoFondoPerduto.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "PDOMANDA";
                if (Progetto.IdFascicolo != null) ComponenteInvestimento.IdFascicolo = Progetto.IdFascicolo;
                
                System.Reflection.PropertyInfo fasei = ComponenteInvestimento.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(ComponenteInvestimento, false, null);
                
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
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Investimento salvato correttamente.");
            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
            Session.Remove("IdInvestimento");
            Redirect("InvestimentiFondoPerduto.aspx?idpcurrent=" + progetto_corrente.IdProgetto);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                investimento = ComponenteInvestimento.Investimento;
                if (investimento == null || investimento.IdInvestimento == null) throw new Exception("L'investimento selezionato non è valido.");
                ProgettoProvider.DbProviderObj.BeginTran();
                //priorita x investimento
                SiarBLL.PrioritaXInvestimentiCollectionProvider pxiprovider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                pxiprovider.DeleteCollection(pxiprovider.Find(null, investimento.IdInvestimento, null, null));
                investimenti_provider.Delete(investimento);
                ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                ProgettoProvider.DbProviderObj.Commit();

                //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
                Session.Remove("IdInvestimento");
                
                Redirect("PianoInvestimenti.aspx", "Investimento eliminato correttamente.", false);

            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
            Session.Remove("IdInvestimento");
            Redirect("PianoInvestimenti.aspx");
        }
    }
}

