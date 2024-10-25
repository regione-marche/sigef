using System;
using System.Web.UI.WebControls;

namespace web.Private.Impresa
{
    public partial class SelezioneDomande : SiarLibrary.Web.ImpresaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "impresa_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider();
        SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();
        SiarLibrary.Bando bando = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Azienda != null) Azienda = ImpresaProvider.GetImpresaAbilitataById(Operatore.Utente.IdUtente, Azienda.IdImpresa, "PSR");
            if (Azienda == null) Redirect("impresafind.aspx", "L`operatore non è abilitato a presentare domanda per l`impresa selezionata.", true);
            else
            {
                int id_bando;
                if (int.TryParse(Request.QueryString["idb"], out id_bando)) bando = new SiarBLL.BandoCollectionProvider().GetById(id_bando);
                if (bando == null) Redirect("impresadomande.aspx", "Per proseguire è necessario selezionare il bando desiderato.", true);
                else
                {
                    if (bando.DataScadenza < DateTime.Now) AbilitaModifica = false;
                    SiarLibrary.BandoCollection bandi = new SiarLibrary.BandoCollection();
                    bandi.Add(bando);
                    dgBandi.DataSource = bandi;
                    dgBandi.DataBind();

                    dgProgetti.DataSource = progprovider.Find(bando.IdBando, Azienda.IdImpresa, null, null, null, false, null);
                    dgProgetti.ItemDataBound += new DataGridItemEventHandler(dgProgetti_ItemDataBound);
                    dgProgetti.Titolo = "Elementi trovati: " + ((SiarLibrary.CustomCollection)dgProgetti.DataSource).Count;
                    dgProgetti.DataBind();
                }
            }
        }

        void dgProgetti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)e.Item.DataItem;
                string operatore = p.Nominativo, ente = p.Ente; SiarLibrary.NullTypes.DatetimeNT data_rilascio = null;
                if (p.CodStato != "P")
                {
                    if (p.OrdineFase != null && p.OrdineFase > 3 && p.CodStato != "N" && p.CodStato != "R")
                        e.Item.Cells[5].Text = "<input style='width:110px' type=button class=ButtonGrid value='Gestione lavori' onclick=\"location='../PPagamento/GestioneLavori.aspx?iddom="
                            + p.IdProgetto + "';\" />";

                    SiarLibrary.ProgettoStoricoCollection cc = storico_provider.Find(p.IdProgetto, "L", null);
                    if (cc.Count > 0)
                    {
                        operatore = cc[0].Nominativo;
                        ente = cc[0].Ente;
                        data_rilascio = cc[0].Data;
                    }
                }
                e.Item.Cells[2].Text = operatore + (string.IsNullOrEmpty(ente) ? "" : " (" + ente + ")");
                e.Item.Cells[3].Text = data_rilascio;
            }
        }

        protected void btnNuovaDomanda_Click(object sender, EventArgs e)
        {
            InserisciDomanda();
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
                Redirect("../pdomanda/DatiGenerali.aspx?iddom=" + p.IdProgetto, "Domanda di aiuto inserita correttamente. Ora e' possibile cominciare la modifica dei dati.", false);
            }
            catch (Exception ex) { progprovider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}
