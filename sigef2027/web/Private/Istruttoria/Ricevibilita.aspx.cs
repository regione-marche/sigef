using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class Ricevibilita : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.VistruttoriaDomandeCollectionProvider istruttoria_provider = new SiarBLL.VistruttoriaDomandeCollectionProvider();

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ricevibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFiltroRicercaDomande.IdBando = Bando.IdBando;
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("", ""));
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("Acquisito", "I"));
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("Non ricevibile", "Q"));
            ucFiltroRicercaDomande.ValoriStato.Add(new ListItem("Rinuncia", "R"));
        }

        protected override void OnPreRender(EventArgs e)
        {
            SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider()
                .Find(Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
            if (responsabili.Count > 0)
            {
                //se e' reponsabile provinciale di una sola provincia preimposto e disabilito la combo relativa
                if (responsabili.FiltroProvincia(null, true).Count == 0 && responsabili.FiltroProvincia(null, false).Count == 1)
                {
                    ucFiltroRicercaDomande.Provincia = responsabili[0].Provincia;
                    ucFiltroRicercaDomande.ProvinciaEnabled = false;
                }
            }
            else
            {
                if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, null, Operatore.Utente.IdUtente, null, true).Count > 0)
                {
                    ucFiltroRicercaDomande.Operatore = Operatore.Utente.IdUtente;
                    ucFiltroRicercaDomande.OperatoreEnabled = false;
                }
            }
            SiarLibrary.VistruttoriaDomandeCollection progetti_istruttore = istruttoria_provider.Find(Bando.IdBando,
                 ucFiltroRicercaDomande.IdProgetto, ucFiltroRicercaDomande.Operatore, ucFiltroRicercaDomande.Provincia, null,
                (ucFiltroRicercaDomande.Cuaa != null ? ucFiltroRicercaDomande.Cuaa + "%" : null),
                (ucFiltroRicercaDomande.RagioneSociale != null ? "%" + ucFiltroRicercaDomande.RagioneSociale + "%" : null),
                (ucFiltroRicercaDomande.StatoDomanda == null ? "L" : ucFiltroRicercaDomande.StatoDomanda.Value), null);
            dg.Titolo = "Elenco delle domande di competenza dell'operatore: " + progetti_istruttore.Count.ToString();
            dg.DataSource = progetti_istruttore;
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
                //dgi.Cells[5].Text = "<a href='ChecklistRicevibilita.aspx?iddom=" + progetto.IdProgetto 
                //    + "'><img src='../../images/domande.ico' alt='Vai alla ricevibilita della domanda' /></a>";
                //dgi.Cells[6].Text = "<a href='MonitoraggioStatoProgetto.aspx?iddom=" + progetto.IdProgetto + "'>Visualizza</a>";
            }
        }
    }
}
