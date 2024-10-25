using System;
using System.Data;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento.Variante
{
    public partial class InvestimentiFondoPerduto : SiarLibrary.Web.VariantePage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoFondoPerduto ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
            try
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                int id_progetto_corrente, id_investimento;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (id_progetto_corrente == Progetto.IdProgetto) progetto_corrente = Progetto;
                    else progetto_corrente = progetto_provider.GetById(id_progetto_corrente);
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");
                if (int.TryParse(Request.QueryString["idinv"], out id_investimento) || int.TryParse(hdnIdInvestimento.Value, out id_investimento))
                {
                    hdnIdInvestimento.Value = id_investimento.ToString();
                    investimento = investimenti_provider.GetById(id_investimento);
                    if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto)
                        throw new Exception("L`investimento selezionato non è valido.");
                }
                ComponenteInvestimento = (CONTROLS.InvestimentoFondoPerduto)LoadControl(Request.ApplicationPath + "/controls/InvestimentoFondoPerduto.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "PVARIANTE";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (investimento == null) investimento = ComponenteInvestimento.Investimento;
            btnNuovo.Enabled = AbilitaModifica && Variante.CodTipo == "VA";
            btnAnnullaInvestimento.Enabled = AbilitaModifica && investimento.IdInvestimento != null && investimento.CodVariazione != "A" && Variante.CodTipo == "VA";
            btnRipristina.Enabled = AbilitaModifica && investimento.IdInvestimento != null && investimento.CodVariazione == "A";
            btnSalva.Enabled = AbilitaModifica && investimento.CodVariazione != "A";
            if (Variante.CodTipo == "AT")
            {
                btnAnnullaInvestimento.Visible = false;
                btnNuovo.Visible = false;
                btnRipristina.Visible = false;
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento != null && investimento.CodVariazione == "A") throw new Exception("Non è possibile modificare un investimento annullato.");
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Investimento salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAnnullaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento == null || investimento.CodVariazione == "A") throw new Exception("L`investimento selezionato non è valido.");
                if (investimenti_provider.GetContributoPagamentiRichiestiInvestimento(investimento.IdInvestimento, null) > 0)
                    throw new Exception("Impossibile annullare l`investimento perchè è già stato rendicontato in precedenti domande di pagamento.");
                VarianteProvider.DbProviderObj.BeginTran();
                if (investimento.CodVariazione != "N")
                {
                    investimento.CodVariazione = "A";
                    investimento.DataVariazione = DateTime.Now;
                    investimento.OperatoreVariazione = Operatore.Utente.CfUtente;
                    investimenti_provider.Save(investimento);
                    VarianteProvider.AggiornaVariante(Variante, Operatore);
                    VarianteProvider.DbProviderObj.Commit();

                    //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
                    Session.Remove("IdInvestimento");

                    ShowMessage("Investimento annullato correttamente.");
                    hdnIdInvestimento.Value = investimento.IdInvestimento;
                }
                else //se e' nuovo lo elimino
                {
                    //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(VarianteProvider.DbProviderObj);
                    SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
                    //localizzazione_provider.DeleteCollection(localizzazione_provider.Find(null, investimento.IdInvestimento, null, null));
                    priorita_provider.DeleteCollection(priorita_provider.Find(null, investimento.IdInvestimento, null, null));
                    investimenti_provider.Delete(investimento);
                    VarianteProvider.AggiornaVariante(Variante, Operatore);
                    VarianteProvider.DbProviderObj.Commit();

                    //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
                    Session.Remove("IdInvestimento");

                    Redirect("PianoInvestimenti.aspx", "Investimento eliminato correttamente.", false);
                }
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnNuovoInvestimento_Click(object sender, EventArgs e)
        {
            if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
            if (Variante.CodTipo == "AT") ShowError("Funzionalità non disponibile per un adeguamento tecnico.");
            else
            {
                //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
                Session.Remove("IdInvestimento");
                Redirect("InvestimentiFondoPerduto.aspx?idpcurrent=" + progetto_corrente.IdProgetto);
            }
        }

        protected void btnRipristinaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento == null || investimento.CodVariazione != "A") throw new Exception("L`investimento selezionato non è valido.");
                VarianteProvider.DbProviderObj.BeginTran();
                investimento.CodVariazione = null;
                // a quanto pare salva l'investimento due volte e va in timeout
                // investimenti_provider.Save(investimento);
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                VarianteProvider.AggiornaVariante(Variante, Operatore);
                VarianteProvider.DbProviderObj.Commit();
                
                //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
                Session.Remove("IdInvestimento");

                ShowMessage("Investimento ripristinato correttamente.");
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
            Session.Remove("IdInvestimento");
            Redirect("PianoInvestimenti.aspx");
        }

    }
}