using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class RevisioneDomande : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "revisione_domande";
            base.OnPreInit(e);
        }
        SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();
        SiarBLL.ProgettoSegnatureCollectionProvider progetto_segnature = new SiarBLL.ProgettoSegnatureCollectionProvider();
        SiarLibrary.BandoResponsabiliCollection responsabili;
        SiarLibrary.VistruttoriaDomandeCollection progetti_bando;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFiltroRicercaDomande.IdBando = Bando.IdBando;
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("", ""));
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("Ammissibile", "A"));
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("Non ammissibile", "B"));

            responsabili = new SiarBLL.BandoResponsabiliCollectionProvider()
               .Find(Bando.IdBando,  Operatore.Utente.IdUtente, null, null,true );
            //responsabili = new SiarBLL.ResponsabiliXBandoCollectionProvider()
            //    .Find(null, Bando.IdBando, ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente, null, null);
            progetti_bando = new SiarBLL.VistruttoriaDomandeCollectionProvider()
                .Find(Bando.IdBando, null, null, null, null, null, null, null, true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            #region controllo utente revisore
            btnCalcola.Enabled = false;
            foreach (SiarLibrary.BandoResponsabili r in responsabili)
            {
                if (r.Provincia != null && progetti_bando.FiltroIstruttoria(null, null, r.Provincia, null, null, null).Count == 0)
                    btnCalcola.Enabled = true;
            }
            #endregion

            SiarLibrary.VistruttoriaDomandeCollection progetti_istruttore = progetti_bando
                .FiltroIstruttoria(ucFiltroRicercaDomande.IdProgetto, ucFiltroRicercaDomande.Operatore,
                ucFiltroRicercaDomande.Provincia, (ucFiltroRicercaDomande.StatoDomanda == null ? "I" : ucFiltroRicercaDomande.StatoDomanda.Value),
                (ucFiltroRicercaDomande.Cuaa != null ? ucFiltroRicercaDomande.Cuaa + "%" : null),
                (ucFiltroRicercaDomande.RagioneSociale != null ? "%" + ucFiltroRicercaDomande.RagioneSociale + "%" : null));
            lblElementi.Text = "Elementi trovati: " + progetti_istruttore.Count.ToString();
            dg.DataSource = progetti_istruttore;
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
            dg.DataBind();
            base.OnPreRender(e);
        }

        protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.VistruttoriaDomande progetto = (SiarLibrary.VistruttoriaDomande)dgi.DataItem;
                dgi.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + progetto.Cuaa
                    + "<br />Rag.soc:</b> " + progetto.RagioneSociale + "<br /><b>Sede:</b> " + progetto.Comune + " ("
                    + progetto.Sigla + ") - " + progetto.Cap;
                dgi.Cells[5].Text = "<a href='ChecklistRevisione.aspx?iddom=" + progetto.IdProgetto
                    + @"'><img src='../../images/domande.ico' alt='Revisione step di ammissibilita della domanda' /></a>";

                SiarLibrary.ProgettoSegnature revisione = progetto_segnature.GetById(progetto.IdProgetto, "REV");
                if (revisione != null)
                {
                    if (!revisione.RiapriDomanda) dgi.Cells[6].Text = "Confermata la checklist dell'istruttore.";
                    else
                    {
                        if (storico_provider.Find(progetto.IdProgetto, null, "A").FiltroRevisioneRiesameRicorso(true, null, null).Count > 0)
                            dgi.Cells[6].Text = "Terminata";
                        else dgi.Cells[6].Text = "In corso";
                    }
                }
                else dgi.Cells[6].Text = "Da avviare";
                dgi.Cells[7].Text = "<a href='MonitoraggioStatoProgetto.aspx?iddom=" + progetto.IdProgetto + "'>Visualizza</a>";
            }
        }

        protected void btnCalcola_Click(object sender, EventArgs e)
        {
            SiarLibrary.DbProvider db = new SiarLibrary.DbProvider();
            try
            {
                db.BeginTran();
                int numero_domande = 0;
                SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
                foreach (SiarLibrary.BandoResponsabili r in responsabili)
                {
                    if (r.Provincia != null && progetti_bando.FiltroIstruttoria(null, null, r.Provincia, null, null, null).Count == 0)
                    {
                        int id_revisore = r.IdUtente; //utenti_provider.Find(r.CfUtente, null, null, null, null, null, null)[0].IdUtente;
                        int nr_domande_temp = SiarLibrary.DbStaticProvider.EstraiCampioneDomandeXRevisione(Bando.IdBando, id_revisore, r.Provincia, db);
                        switch (nr_domande_temp)
                        {
                            case -1:
                                throw new Exception("Sussistono ancona domande di aiuto con istruttoria aperta per una o più delle province di competenza.");
                            case -2:
                                throw new Exception("Sussistono ancona domande di aiuto non assegnate ad alcun funzionario istruttore per una o più delle province di competenza.");
                            default:
                                if (numero_domande < 0) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                                else numero_domande += nr_domande_temp;
                                break;
                        }
                    }
                }
                db.Commit();
                if (numero_domande == 0) ShowError("Nessuna domanda estratta per il campione da sottoporre a revisione.");
                ShowMessage("Nr. " + numero_domande.ToString() + " domande estratte a campione per le province assegnate.");
                progetti_bando = new SiarBLL.VistruttoriaDomandeCollectionProvider()
                    .Find(Bando.IdBando, null, null, null, null, null, null, null, true);
            }
            catch (Exception ex) { db.Rollback(); ShowError(ex); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {

        }
    }
}