using System;
using System.Data;
using SiarLibrary.Extensions;

namespace web.Private.IPagamento.IVariante
{
    public partial class InvestimentiFondoPerduto : SiarLibrary.Web.IstruttoriaVariantePage
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
                ComponenteInvestimento.Fase = "IVARIANTE";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
                //ucSiarNewToolTip.Codice = "idomanda_invfperduto_idb" + progetto_corrente.IdBando;
            }
            catch (Exception ex) { Redirect("PianoInvestimenti.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            btnSalva.Enabled = AbilitaModifica && investimento.CodVariazione != "A";
            btnRicarica.Enabled = btnSalva.Enabled && investimento.IdInvestimentoOriginale != null;
            btnDuplica.Enabled = btnSalva.Enabled && investimento.CodVariazione != "D";
            btnDeleteDuplicato.Enabled = btnSalva.Enabled && investimento.CodVariazione == "D";
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
                ShowMessage("Investimento salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }


        protected void btnDuplica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.CodVariazione == "A") throw new Exception("Non è possibile duplicare un investimento annullato.");
                if (investimento.CodVariazione == "D") throw new Exception("L`investimento è già un duplicato. Impossibile continuare.");
                // blocco sulla proliferazione investimenti duplicati solo se non e' acquisizione esito ricorso o modifica
                if (Variante.CodTipo != "AR")
                {
                    if (investimento.IdInvestimentoOriginale != null && investimenti_provider.Find(null, investimento.IdProgetto, null, null, null, null,
                        investimento.IdInvestimentoOriginale).FiltroCodiceVariazione("D", null).FiltroVariante(Variante.IdVariante).Count > 0)
                        throw new Exception("L`investimento è già stato duplicato. Impossibile continuare.");
                }

                VarianteProvider.DbProviderObj.BeginTran();
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(VarianteProvider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);
                SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_provider.Find(null, investimento.IdInvestimento, null, null);
                //SiarLibrary.LocalizzazioneInvestimentoCollection particelle = localizzazione_provider.Find(null, investimento.IdInvestimento, null, null);

                investimento.MarkAsNew();
                investimento.Ammesso = false;
                investimento.IdInvestimento = null;
                investimento.ValutazioneInvestimento = null;
                investimento.CodVariazione = "D";
                investimento.CostoInvestimento = 0;
                investimento.SpeseGenerali = 0;
                investimento.ContributoRichiesto = 0;
                investimenti_provider.Save(investimento);

                foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                {
                    pr.MarkAsNew();
                    pr.IdInvestimento = investimento.IdInvestimento;
                    priorita_provider.Save(pr);
                }

                //foreach (SiarLibrary.LocalizzazioneInvestimento particella in particelle)
                //{
                //    particella.MarkAsNew();
                //    particella.IdInvestimento = investimento.IdInvestimento;
                //    localizzazione_provider.Save(particella);
                //}
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);
                VarianteProvider.DbProviderObj.Commit();
                Redirect("InvestimentiFondoPerduto.aspx?idpcurrent=" + progetto_corrente.IdProgetto + "&idinv=" + investimento.IdInvestimento,
                    "Investimento duplicato correttamente, ora è possibile iniziare la modifica.", false);
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnDeleteDuplicato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.CodVariazione != "D") throw new Exception("L`investimento non è un duplicato di un'altro investimento. Impossibile continuare.");
                SiarBLL.CorrettivaRendicontazioneSpostamentiCollectionProvider correttiva_spostamenti_provider = new SiarBLL.CorrettivaRendicontazioneSpostamentiCollectionProvider();
                if (correttiva_spostamenti_provider.Find(null, investimento.IdInvestimento, null, null, null).Count > 0 ||
                    correttiva_spostamenti_provider.Find(null, null, investimento.IdInvestimento, null, null).Count > 0)
                    throw new Exception("L`investimento è interessato da almeno una correttiva di rendicontazione, non è possibile eliminarlo.");
                VarianteProvider.DbProviderObj.BeginTran();
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(VarianteProvider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(VarianteProvider.DbProviderObj);

                //localizzazione_provider.DeleteCollection(localizzazione_provider.Find(null, investimento.IdInvestimento, null, null));
                priorita_provider.DeleteCollection(priorita_provider.Find(null, investimento.IdInvestimento, null, null));
                investimenti_provider.Delete(investimento);
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);
                VarianteProvider.DbProviderObj.Commit();
                Redirect("PianoInvestimenti.aspx", "Investimento eliminato correttamente.", false);
            }
            catch (Exception ex) { VarianteProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRicarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (investimento.IdInvestimentoOriginale == null) throw new Exception("Investimento originale non presente.");
                SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(investimento.IdInvestimentoOriginale);
                if (investimento_originale == null) throw new Exception("Investimento originale non presente.");
                investimento.IdProgrammazione = investimento_originale.IdProgrammazione;
                investimento.Descrizione = investimento_originale.Descrizione;
                investimento.CodStp = investimento_originale.CodStp;
                investimento.CodTipoInvestimento = investimento_originale.CodTipoInvestimento;
                investimento.IdUnitaMisura = investimento_originale.IdUnitaMisura;
                investimento.Quantita = investimento_originale.Quantita;
                investimento.CostoInvestimento = investimento_originale.CostoInvestimento;
                investimento.SpeseGenerali = investimento_originale.SpeseGenerali;
                investimento.ContributoRichiesto = investimento_originale.ContributoRichiesto;
                investimento.QuotaContributoRichiesto = investimento_originale.QuotaContributoRichiesto;
                investimento.IdSettoreProduttivo = investimento_originale.IdSettoreProduttivo;
                investimento.IdPrioritaSettoriale = investimento_originale.IdPrioritaSettoriale;
                investimento.IdObiettivoMisura = investimento_originale.IdObiettivoMisura;
                investimento.IdCodificaInvestimento = investimento_originale.IdCodificaInvestimento;
                investimento.IdDettaglioInvestimento = investimento_originale.IdDettaglioInvestimento;
                investimento.IdSpecificaInvestimento = investimento_originale.IdSpecificaInvestimento;
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.RicaricaInvestimento = true;
                ShowMessage("Investimento originale caricato correttamente.");
                //ComponenteInvestimento.CalcolaContributoInvestimento();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            //Rimuovo la variabile in sessione creata nel controls/InvestimentoFondoPerduto
            Session.Remove("IdInvestimento");
            Redirect("PianoInvestimenti.aspx");
        }
    }
}