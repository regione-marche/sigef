using System;

namespace web.Private.Istruttoria
{
    public partial class InvestimentiDettaglioRichiestaMutuo : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarLibrary.Progetto progetto;
        SiarLibrary.PianoInvestimenti investimento, investimento_originale;
        CONTROLS.InvestimentoDettaglioMutuoTip2 ComponenteInvestimento;    

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_progetto;
            if (int.TryParse(Request.QueryString["iddom"], out id_progetto))
            {
                progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
                btnBack.Attributes.Add("onclick", "location='ChecklistAmmissibilita.aspx?iddom=" + progetto.IdProgetto + "'");
                ucInfoDomanda.Progetto = progetto;
                controlloOperatoreStatoProgetto();
                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, progetto.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(false);
                if (mutuocoll.Count > 0)
                {
                    investimento = mutuocoll[0];
                    hdnIdInvestimento.Value = investimento.IdInvestimento;
                    investimento_originale = investimenti_provider.GetById(investimento.IdInvestimentoOriginale);
                    if (investimento.IdInvestimentoOriginale == null || investimento_originale == null)
                        ShowError("Si sta tentando di modificare l`investimento originale inserito dal beneficiario. Impossibile continuare.");

                    ComponenteInvestimento = (CONTROLS.InvestimentoDettaglioMutuoTip2)LoadControl(System.Web.HttpRuntime.AppDomainAppVirtualPath
                        + "/controls/InvestimentoDettaglioMutuoTip2.ascx");
                    ComponenteInvestimento.Investimento = investimento;
                    ComponenteInvestimento.InvestimentoOriginale = investimento_originale;
                    ComponenteInvestimento.Progetto = progetto;
                    ComponenteInvestimento.Fase = "IDOMANDA";
                    tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
                }
            }
        }

        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }

        protected void btnSalvaInvestimento_Click(object sender, EventArgs e)
        {
            try
            {
                if (investimento == null) throw new Exception("Nessun dato valido trovato. Impossibile continuare.");
                ComponenteInvestimento.CalcolaContributoInvestimento();
                investimento = ComponenteInvestimento.Investimento;                
                controlloModificaInvestimento();
                investimento.Ammesso = true;
                investimento.DataValutazione = DateTime.Now;
                investimento.Istruttore = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente;
                investimenti_provider.Save(investimento);  
                hdnIdInvestimento.Value = investimento.IdInvestimento;
                ShowMessage("Dati del mutuo salvati correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void controlloModificaInvestimento()
        {
            if (investimento.IdInvestimentoOriginale == null || investimento_originale == null)
                throw new Exception("Si sta tentando di modificare l`investimento originale inserito dal beneficiario. Impossibile continuare.");
            //if (investimento_originale.CostoInvestimento < investimento.CostoInvestimento)
            //    throw new Exception("Non è possibile aumentare l`ammontare del mutuo.");
            //if (investimento_originale.SpeseGenerali < investimento.SpeseGenerali)
            //    throw new Exception("Non è possibile aumentare l`ammontare dell`investimento per cui si richiede il mutuo.");
            if (string.IsNullOrEmpty(investimento.ValutazioneInvestimento) &&
                (investimento_originale.IdProgrammazione != investimento.IdProgrammazione
                    || investimento_originale.Descrizione != investimento.Descrizione
                    || investimento_originale.Quantita != investimento.Quantita
                    || investimento_originale.CostoInvestimento != investimento.CostoInvestimento
                    || investimento_originale.SpeseGenerali != investimento.SpeseGenerali
                    || investimento_originale.ContributoRichiesto != investimento.ContributoRichiesto
                    || investimento_originale.QuotaContributoRichiesto != investimento.QuotaContributoRichiesto
                    || investimento_originale.IdObiettivoMisura != investimento.IdObiettivoMisura
                    || investimento_originale.IdCodificaInvestimento != investimento.IdCodificaInvestimento))
                throw new Exception("E` obbligatorio inserire la valutazione dell`investimento perchè differisce dall`originale.");

        }
    }
}
