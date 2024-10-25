using System;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento.Variante
{
    public partial class InvestimentiContoInteressi : SiarLibrary.Web.VariantePage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoContoInteressi ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
            try
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                int id_progetto_corrente;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                {
                    // se e' integrato tiro su il progetto relativo alla misura selezionata
                    if (id_progetto_corrente == Progetto.IdProgetto) progetto_corrente = Progetto;
                    else progetto_corrente = progetto_provider.GetById(id_progetto_corrente);
                }
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");

                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(false).FiltroVariante(Variante.IdVariante);
                if (mutuocoll.Count > 0) investimento = mutuocoll[0];

                ComponenteInvestimento = (CONTROLS.InvestimentoContoInteressi)LoadControl(Request.ApplicationPath + "/controls/InvestimentoContoInteressi.ascx");
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
            btnSalvaInvestimento.Enabled = AbilitaModifica && investimento.CodVariazione != "A";
            btnAnnullaInvestimento.Enabled = btnRipristina.Enabled = AbilitaModifica && investimento.IdInvestimento != null &&
                investimento.CodVariazione != "A" && Variante.CodTipo == "VA";
            if (Variante.CodTipo == "AT")
            {
                btnAnnullaInvestimento.Visible = false;
                btnRipristina.Visible = false;
            }
            base.OnPreRender(e);
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.CodVariazione == "A") throw new Exception("Non è possibile modificare un investimento annullato.");
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                ShowMessage("Dati del mutuo salvati correttamente.");
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
                    ShowMessage("Mutuo annullato correttamente.");
                }
                else //se e' nuovo lo elimino
                {
                    investimenti_provider.Delete(investimento);
                    VarianteProvider.AggiornaVariante(Variante, Operatore);
                    VarianteProvider.DbProviderObj.Commit();
                    Redirect("PianoInvestimenti.aspx", "Investimento eliminato correttamente.", false);
                }
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRipristinaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento == null || investimento.CodVariazione != "A") throw new Exception("L`investimento selezionato non è valido.");
                VarianteProvider.DbProviderObj.BeginTran();
                investimento.CodVariazione = null;
                investimenti_provider.Save(investimento);
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                VarianteProvider.AggiornaVariante(Variante, Operatore);
                VarianteProvider.DbProviderObj.Commit();
                ShowMessage("Dati ripristinati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}