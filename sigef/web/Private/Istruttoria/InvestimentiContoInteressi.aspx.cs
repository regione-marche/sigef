using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class InvestimentiContoInteressi : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider();
        SiarLibrary.Progetto progetto_integrato, progetto_corrente;
        SiarLibrary.PianoInvestimenti investimento;
        CONTROLS.InvestimentoContoInteressi ComponenteInvestimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
                int id_progetto_corrente;
                if (int.TryParse(Request.QueryString["idpcurrent"], out id_progetto_corrente))
                    progetto_corrente = progetto_provider.GetById(id_progetto_corrente);
                if (progetto_corrente == null) throw new Exception("L`investimento selezionato non è valido.");
                progetto_integrato = progetto_corrente.IdProgIntegrato == null || progetto_corrente.IdProgIntegrato == progetto_corrente.IdProgetto ?
                    progetto_corrente : progetto_provider.GetById(progetto_corrente.IdProgIntegrato);
                ucInfoDomanda.Progetto = progetto_integrato;
                controlloOperatoreStatoProgetto();
                btnIstruttoriaAllegati.Attributes.Add("onclick", "location='allegatiesiti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");
                btnBack.Attributes.Add("onclick", "location='AmmissibilitaPianoInvestimenti.aspx?iddom=" + progetto_integrato.IdProgetto + "'");

                // permetto l'inserimento di un solo mutuo
                SiarLibrary.PianoInvestimentiCollection mutuocoll = investimenti_provider.Find(null, progetto_corrente.IdProgetto, null, null, null, null,
                    null).FiltroTipoInvestimento(2).FiltroInvestimentoOriginale(false);
                if (mutuocoll.Count > 0) investimento = mutuocoll[0];
                if (investimento == null || investimento.IdProgetto != progetto_corrente.IdProgetto || investimento.IdInvestimentoOriginale == null)
                    throw new Exception("L`investimento selezionato non è valido.");
                //if (progetto_integrato.IdFascicolo == null) throw new Exception("L'azienda non è titolare di nessun fascicolo aziendale in corso di validità.");
                ComponenteInvestimento = (CONTROLS.InvestimentoContoInteressi)LoadControl(Request.ApplicationPath + "/controls/InvestimentoContoInteressi.ascx");
                ComponenteInvestimento.Investimento = investimento;
                ComponenteInvestimento.ProgettoCorrelato = progetto_corrente;
                ComponenteInvestimento.Fase = "IDOMANDA";
                tdInvestimentoComponent.Controls.Add(ComponenteInvestimento);
                ucSiarNewToolTip.Codice = "idomanda_invcinteressi_idb" + progetto_corrente.IdBando;
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
                ShowMessage("Dati del mutuo salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}