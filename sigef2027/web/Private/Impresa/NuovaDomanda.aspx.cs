using System;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class NuovaDomanda : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider();
        SiarLibrary.Bando bando = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Azienda == null) 
                Redirect("impresafind.aspx", "L`operatore non è abilitato a presentare domanda per l`impresa selezionata.", true);
            else
            {
                int id_bando;
                if (int.TryParse(Request.QueryString["idb"], out id_bando)) 
                    bando = new SiarBLL.BandoCollectionProvider().GetById(id_bando);
                if (bando == null) 
                    Redirect("impresadomande.aspx", "Per proseguire è necessario selezionare il bando desiderato.", true);
                else
                {
                    SiarLibrary.BandoCollection bandi = new SiarLibrary.BandoCollection();
                    bandi.Add(bando);
                    dgBandi.DataSource = bandi;
                    dgBandi.DataBind();
                }
            }
        }

        protected void btnConferma_Click(object sender, EventArgs e)
        {
            try
            {
                //se il bando è a quota fissa controllo che l'azienda si trovi nell'elenco di quelle che possono presentare la domanda

                SiarLibrary.BandoImpreseQuotaFissaCollection bqf = new SiarBLL.BandoImpreseQuotaFissaCollectionProvider().Find(bando.IdBando, null, null, true);
                if (bqf.Count > 0)
                {
                    bqf = bqf.SubSelect(null, null, Azienda.IdImpresa, null, null, null, null, true);
                    if (bqf.Count == 0) throw new SiarLibrary.SiarException("Non è possibile presentare la domanda per questo bando.");
                }
                //cerco se esiste gia' una domanda per l'azienda
                SiarLibrary.ProgettoCollection domande = progprovider.Find(bando.IdBando, Azienda.IdImpresa, null, null, null, null, null);
                if (domande.Count > 0 && bando.Multiprogetto) Redirect("selezionedomande.aspx?idb=" + bando.IdBando);
                else InserisciDomanda();
            }
            catch (Exception ex) { ShowError(ex); }
        }        

        private void InserisciDomanda()
        {
            try
            {
                progprovider.ControlloAziendaAbilitataXPresentazioneDomanda(bando.IdBando, Azienda.IdImpresa, Operatore.Utente.IdUtente);

                progprovider.DbProviderObj.BeginTran();
                SiarLibrary.Progetto p = new SiarLibrary.Progetto();
                p.FlagDefinitivo = false;
                p.FlagPreadesione = false;
                p.IdImpresa = Azienda.IdImpresa;
                p.IdBando = bando.IdBando;
                p.DataCreazione = DateTime.Now;
                p.OperatoreCreazione = Operatore.Utente.IdUtente;
                progprovider.Save(p);

                SiarLibrary.ProgettoStorico s = new SiarLibrary.ProgettoStorico();
                s.IdProgetto = p.IdProgetto;
                s.CodStato = "P";
                s.Data = DateTime.Now;
                s.Operatore = Operatore.Utente.IdUtente;
                new SiarBLL.ProgettoStoricoCollectionProvider(progprovider.DbProviderObj).Save(s);

                //se il bando ha piu' misure lo etichetto come progetto integrato
                if (bando.Multimisura) p.IdProgIntegrato = p.IdProgetto;
                p.IdStoricoUltimo = s.Id;
                progprovider.Save(p);
                progprovider.DbProviderObj.Commit();
                Redirect("../pdomanda/datigenerali.aspx?iddom=" + p.IdProgetto, "Domanda di aiuto inserita correttamente. Ora e' possibile cominciare la modifica dei dati.", false);
            }
            catch (Exception ex) { progprovider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
