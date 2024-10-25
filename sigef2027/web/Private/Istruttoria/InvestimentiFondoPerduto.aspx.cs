using System;
using System.Data;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class InvestimentiFondoPerduto : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarLibrary.Progetto progetto_integrato, progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoFondoPerduto ComponenteInvestimento;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                int id_progetto_corrente, id_investimento;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                    progetto_corrente = progetto_provider.GetById(id_progetto_corrente);
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");
                progetto_integrato = progetto_corrente.IdProgIntegrato == null || progetto_corrente.IdProgIntegrato == progetto_corrente.IdProgetto ?
                    progetto_corrente : progetto_provider.GetById(progetto_corrente.IdProgIntegrato);
                ucInfoDomanda.Progetto = progetto_integrato;
                controlloOperatoreStatoProgetto();
                btnIstruttoriaAllegati.Attributes.Add("onclick", "location='allegatiesiti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");
                btnBack.Attributes.Add("onclick", "location='AmmissibilitaPianoInvestimenti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");
                btnBackDown.Attributes.Add("onclick", "location='AmmissibilitaPianoInvestimenti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");
                string url_indietro = "ChecklistAmmissibilita.aspx?iddom=" + progetto_integrato.IdProgetto.ToString();
                linkBreadcrumb.Attributes.Add("onclick", "location='" + url_indietro + "'");
                linkBreadcrumb2.Attributes.Add("onclick", "location='AmmissibilitaPianoInvestimenti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");

                if (int.TryParse(Request.QueryString["idinv"], out id_investimento) || int.TryParse(hdnIdInvestimento.Value, out id_investimento))
                {
                    hdnIdInvestimento.Value = id_investimento.ToString();
                    investimento = investimenti_provider.GetById(id_investimento);
                }
                if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto) throw new Exception("L`investimento selezionato non è valido.");
                //if (progetto_integrato.IdFascicolo == null) throw new Exception("L'azienda non è titolare di nessun fascicolo aziendale in corso di validità.");
                ComponenteInvestimento = (CONTROLS.InvestimentoFondoPerduto)LoadControl(Request.ApplicationPath + "/controls/InvestimentoFondoPerduto.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "IDOMANDA";
                //ComponenteInvestimento.IdFascicolo = progetto_integrato.IdFascicolo;
                
                System.Reflection.PropertyInfo fasei = ComponenteInvestimento.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(ComponenteInvestimento, true, null);

                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
                //ucSiarNewToolTip.Codice = "idomanda_invfperduto_idb" + progetto_corrente.IdBando;
            }
            catch (Exception ex) { Redirect("AmmissibilitaPianoInvestimenti.aspx", ex.Message, true); }
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                ComponenteInvestimento.CalcolaContributoInvestimento(true);
                investimento = ComponenteInvestimento.Investimento;
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Investimento salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDeleteDuplicato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (investimento.IdInvestimentoOriginale == null || investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    investimento.IdInvestimentoOriginale).Count < 2) throw new Exception("Non è stato trovato nessun duplicato da eliminare.");
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(investimenti_provider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(investimenti_provider.DbProviderObj);
                investimenti_provider.DbProviderObj.BeginTran();
                //localizzazione_provider.DeleteCollection(localizzazione_provider.Find(null, investimento.IdInvestimento, null, null));
                priorita_provider.DeleteCollection(priorita_provider.Find(null, investimento.IdInvestimento, null, null));
                investimenti_provider.Delete(investimento);
                investimenti_provider.DbProviderObj.Commit();
                Redirect("AmmissibilitaPianoInvestimenti.aspx?iddom=" + progetto_integrato.IdProgetto, "Investimento eliminato correttamente.", false);
            }
            catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnDuplica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(investimento.IdInvestimentoOriginale);
                if (investimento_originale == null) throw new Exception("Investimento originale non presente.");
                if (investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    investimento.IdInvestimentoOriginale).Count > 1) throw new Exception("Non è possibile creare più di un duplicato ad uno stesso investimento.");

                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(investimenti_provider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(investimenti_provider.DbProviderObj);
                SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_provider.Find(null, investimento_originale.IdInvestimento, null, null);
                //SiarLibrary.LocalizzazioneInvestimentoCollection localizzazione = localizzazione_provider.Find(null, investimento_originale.IdInvestimento, null, null);

                investimenti_provider.DbProviderObj.BeginTran();
                investimento_originale.MarkAsNew();
                investimento_originale.IdInvestimentoOriginale = investimento_originale.IdInvestimento;
                investimento_originale.Ammesso = false;
                investimento.DataValutazione = DateTime.Now;
                investimento.Istruttore = Operatore.Utente.CfUtente;
                investimento_originale.IdInvestimento = null;
                // lo impongo per non superare il costo dell'investimento originale
                decimal costo = investimento_originale.CostoInvestimento - investimento.CostoInvestimento;
                investimento_originale.CostoInvestimento = (costo < 0 ? 0 : costo);
                decimal spese = investimento_originale.SpeseGenerali - investimento.SpeseGenerali;
                investimento_originale.SpeseGenerali = (spese < 0 ? 0 : spese);
                //lo impongo cosi' perche' senno' potrebbe sforare i limiti del contributo sulle max spese
                //decimal contributo = investimento_originale.ContributoRichiesto - investimento.ContributoRichiesto;
                investimento_originale.ContributoRichiesto = 0;//null (contributo < 0 ? 0 : contributo);
                investimenti_provider.Save(investimento_originale);

                foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                {
                    pr.MarkAsNew();
                    pr.IdInvestimento = investimento_originale.IdInvestimento;
                    priorita_provider.Save(pr);
                }

                //foreach (SiarLibrary.LocalizzazioneInvestimento l in localizzazione)
                //{
                //    l.MarkAsNew();
                //    l.IdInvestimento = investimento_originale.IdInvestimento;
                //    localizzazione_provider.Save(l);
                //}

                investimenti_provider.DbProviderObj.Commit();
                Redirect("InvestimentiFondoPerduto.aspx?idpcurrent=" + progetto_corrente.IdProgetto + "&idinv="
                    + investimento_originale.IdInvestimento);
            }
            catch (Exception ex) { investimenti_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRicarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (investimento.IdInvestimentoOriginale == null) throw new Exception("I dati originali dell'investimento non sono stati trovati.");
                SiarLibrary.PianoInvestimenti investimento_originale = investimenti_provider.GetById(investimento.IdInvestimentoOriginale);
                if (investimento_originale == null) throw new Exception("I dati originali dell'investimento non sono stati trovati.");
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
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}
