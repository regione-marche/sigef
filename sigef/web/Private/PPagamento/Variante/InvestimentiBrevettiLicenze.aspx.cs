using System;
using SiarLibrary.Extensions;

namespace web.Private.PPagamento.Variante
{
    public partial class InvestimentiBrevettiLicenze : SiarLibrary.Web.VariantePage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider;
        SiarLibrary.Progetto progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoBrevettoLicenza ComponenteInvestimento;

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
                    if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto) throw new Exception("L`investimento selezionato non è valido.");
                }

                ComponenteInvestimento = (CONTROLS.InvestimentoBrevettoLicenza)LoadControl(Request.ApplicationPath + "/controls/InvestimentoBrevettoLicenza.ascx");
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
            btnNuovo.Disabled = !AbilitaModifica || Variante.CodTipo == "AT";
            btnSalva.Enabled = AbilitaModifica && investimento.CodVariazione != "A";
            btnAnnullaInvestimento.Enabled = btnSalva.Enabled && investimento.IdInvestimento != null && Variante.CodTipo != "AT";
            btnRipristina.Enabled = AbilitaModifica && investimento.IdInvestimento != null && investimento.CodVariazione == "A";

            if (Variante.CodTipo == "AT")
            {
                btnAnnullaInvestimento.Visible = false;
                btnNuovo.Visible = false;
                btnRipristina.Visible = false;
                btnNuovo.Attributes.Add("onclick", "alert('Attenzione! Funzionalità non disponibile per un adeguamento tecnico.');");
            }
            else btnNuovo.Attributes.Add("onclick", "location='InvestimentiBrevettiLicenze.aspx?idpcurrent=" + progetto_corrente.IdProgetto + "'");
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.CodVariazione == "A") throw new Exception("Non è possibile modificare un investimento annullato.");
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Spesa per brevetti/licenze salvata correttamente.");
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
                    ShowMessage("Investimento annullato correttamente.");
                    hdnIdInvestimento.Value = investimento.IdInvestimento;
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
                ShowMessage("Investimento ripristinato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}