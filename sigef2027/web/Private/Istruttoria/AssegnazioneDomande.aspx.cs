using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class AssegnazioneDomande : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            controlloOperatore();
            txtNominativo.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstProvincia.DataBind();
            if (!string.IsNullOrEmpty(lstProvincia.SelectedValue)) lstComune.SiglaProvincia = lstProvincia.SelectedValue;
            lstComune.DataBind();

            SiarLibrary.ProgettoCollection progetti = new SiarBLL.ProgettoCollectionProvider()
                .FindProgettiNonAssegnati(Bando.IdBando, lstComune.SelectedValue, lstProvincia.SelectedValue);
            ((SiarLibrary.Web.CheckColumn)dg.Columns[5]).ClearSelected();
            dg.DataSource = progetti;
            if (progetti.Count == 0) dg.Titolo = "Nessun elemento trovato.";
            dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);

            dg.DataBind();
            base.OnPreRender(e);
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto progetto = (SiarLibrary.Progetto)e.Item.DataItem;
                e.Item.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + progetto.AdditionalAttributes["CUAA"]
                    + "<br />Rag.soc:</b> " + progetto.AdditionalAttributes["RagioneSociale"]
                    + "<br /><b>Sede:</b> " + progetto.AdditionalAttributes["SedeLegale"];
                e.Item.Cells[2].Text = progetto.AdditionalAttributes["DATA_PRESENTAZIONE"];
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dg.SetPageIndex(0);
        }

        protected void btnAssegna_Click(object sender, EventArgs e)
        {
            SiarBLL.CollaboratoriXBandoCollectionProvider coll_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider();
            try
            {
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dg.Columns[5]).GetSelected();
                if (selezionati.Length == 0) { ShowError("Selezionare almeno una domanda di aiuto."); return; }
                SiarLibrary.Utenti u = null;
                int id_utente;
                if (int.TryParse(hdnIdUtente.Value, out id_utente)) u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo) throw new Exception("L'operatore selezionato non è attivo. Si richiede di sceglierne un altro.");
                coll_provider.DbProviderObj.BeginTran();
                foreach (string s in selezionati)
                {
                    SiarLibrary.CollaboratoriXBando c = new SiarLibrary.CollaboratoriXBando();
                    c.IdUtente = u.IdUtente;
                    c.IdBando = Bando.IdBando;
                    c.IdProgetto = s;
                    c.Provincia = lstProvincia.SelectedValue;
                    c.OperatoreInserimento = Operatore.Utente.IdUtente;
                    c.DataInserimento = DateTime.Now;
                    c.Attivo = true;
                    coll_provider.Save(c);
                }
                coll_provider.DbProviderObj.Commit();
                ((SiarLibrary.Web.CheckColumn)dg.Columns[5]).ClearSelected();
                ShowMessage("Domande di aiuto assegnate correttamente all`operatore: " + u.Nominativo);
            }
            catch (Exception ex) { coll_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        private void controlloOperatore()
        {
            if (!IsPostBack) lstProvincia.SelectedValue = Operatore.Utente.Provincia;
            if (AbilitaModifica)
            {//la modifica e' abilitata sia per gli istruttori che per i resp di misura che sono responsabili di provincia
                //SiarLibrary.ResponsabiliXBandoCollection responsabili = new SiarBLL.ResponsabiliXBandoCollectionProvider()
                //    .Find(null, Bando.IdBando, Operatore.Utente.CfUtente, null, null);
                SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider()
                    .Find( Bando.IdBando, Operatore.Utente.IdUtente, null, null, true );
                if (responsabili.Count == 0 ||
                    (responsabili[0].Provincia != null &&
                    (lstProvincia.SelectedValue == null ? responsabili.FiltroProvincia(null, true).Count
                    : responsabili.FiltroProvincia(lstProvincia.SelectedValue, null).Count) == 0))
                    AbilitaModifica = false;
            }
        }
    }
}