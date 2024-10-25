using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class CollaboratoreDettaglio : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }

        SiarBLL.CollaboratoriXBandoCollectionProvider collaboratori_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider();
        SiarLibrary.Utenti istruttore;
        string url_stampa_domanda;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_istruttore;
            if (int.TryParse(Request.QueryString["id"], out id_istruttore))
                istruttore = new SiarBLL.UtentiCollectionProvider().GetById(id_istruttore);
            if (istruttore == null) Redirect("Collaboratori.aspx", "L'operatore selezionato non è valido.", true);
            else
            {
                SiarLibrary.ModelloDomandaCollection modelliDomanda = new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Bando.IdBando, null);
                url_stampa_domanda = "SNCVisualizzaReport('rptModelloDomanda" + modelliDomanda[0].IdDomanda + "',1,'ID_Domanda=";
                controlloOperatore();
            }
        }

        void rblFiltroProvincia_DataBinding(object sender, EventArgs e)
        {
            rblFiltroProvincia.Items.Clear();
            rblFiltroProvincia.Items.Add(new ListItem("Ancona", "AN"));
            rblFiltroProvincia.Items.Add(new ListItem("Ascoli Piceno", "AP"));
            rblFiltroProvincia.Items.Add(new ListItem("Fermo", "FM"));
            rblFiltroProvincia.Items.Add(new ListItem("Macerata", "MC"));
            rblFiltroProvincia.Items.Add(new ListItem("Pesaro-Urbino", "PU"));
            rblFiltroProvincia.Items.Add(new ListItem("Tutte", "tutte"));
            if (!IsPostBack) rblFiltroProvincia.SelectedValue = Request.QueryString["pv"];
            else rblFiltroProvincia.SelectedValue = Request.Form["ctl00$cphContenuto$rblFiltroProvincia"];
            if (string.IsNullOrEmpty(rblFiltroProvincia.SelectedValue)) rblFiltroProvincia.SelectedValue = "tutte";
        }

        void rblProgetti_DataBinding(object sender, EventArgs e)
        {
            rblProgetti.Items.Clear();
            rblProgetti.Items.Add(new ListItem("Assegnate", "T"));
            rblProgetti.Items.Add(new ListItem("Ricevibili", "I"));
            rblProgetti.Items.Add(new ListItem("Non ricevibili", "Q"));
            rblProgetti.Items.Add(new ListItem("Ammissibili", "A"));
            rblProgetti.Items.Add(new ListItem("Non ammissibili", "B"));
            rblProgetti.Items.Add(new ListItem("Istruite da altri", "R"));
            if (IsPostBack) rblProgetti.SelectedValue = Request.Form["ctl00$cphContenuto$rblProgetti"];
            if (string.IsNullOrEmpty(rblProgetti.SelectedValue)) rblProgetti.SelectedValue = "T";
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbAssegnazioniAttuali.Visible = false;
                    lstProvincia.DataBind();
                    if (!string.IsNullOrEmpty(lstProvincia.SelectedValue)) lstComune.SiglaProvincia = lstProvincia.SelectedValue;
                    lstComune.DataBind();

                    //filtro progetti da Assegnare 
                    SiarLibrary.ProgettoCollection progetti = new SiarBLL.ProgettoCollectionProvider()
                      .FindProgettiNonAssegnati(Bando.IdBando, lstComune.SelectedValue, lstProvincia.SelectedValue);
                    dgProgettiDaAssegnare.DataSource = progetti;
                    dgProgettiDaAssegnare.ItemDataBound += new DataGridItemEventHandler(dgProgettiDaAssegnare_ItemDataBound);
                    ((SiarLibrary.Web.CheckColumn)dgProgettiDaAssegnare.Columns[5]).ClearSelected();
                    dgProgettiDaAssegnare.DataBind();
                    btnAssegna.Conferma = "Assegnare le domande selezionate a " + istruttore.Nominativo + "?";
                    tabProgetti.Visible = progetti.Count > 0;
                    lblSearchResult.Text = progetti.Count.ToString();
                    break;
                default:
                    tbNuovaAssegnazione.Visible = false;

                    SiarLibrary.UtentiCollection operatori = new SiarLibrary.UtentiCollection();
                    operatori.Add(istruttore);
                    dgOperatore.DataSource = operatori;
                    dgOperatore.ItemDataBound += new DataGridItemEventHandler(dgOperatore_ItemDataBound);
                    dgOperatore.DataBind();

                    rblProgetti.DataBinding += new EventHandler(rblProgetti_DataBinding);
                    rblProgetti.DataBind();

                    rblFiltroProvincia.DataBinding += new EventHandler(rblFiltroProvincia_DataBinding);
                    rblFiltroProvincia.DataBind();

                    SiarLibrary.CollaboratoriXBandoCollection progetti_assegnati = collaboratori_provider.
                        GetCollabBandoDatiProgettoImpresa(Bando.IdBando, null, istruttore.IdUtente,
                        (rblFiltroProvincia.SelectedValue == "tutte" ? null : rblFiltroProvincia.SelectedValue), null);
                    // filtro stato domande
                    if (rblProgetti.SelectedValue != "T")
                    {
                        SiarLibrary.CollaboratoriXBandoCollection cc_temp = new SiarLibrary.CollaboratoriXBandoCollection();
                        foreach (SiarLibrary.CollaboratoriXBando c in progetti_assegnati)
                        {
                            string cod_stato = c.AdditionalAttributes["COD_STATO"];
                            if ((rblProgetti.SelectedValue == "R" && c.IdUtente != istruttore.IdUtente && cod_stato.FindValueIn("I", "Q", "A", "B")) ||
                                (rblProgetti.SelectedValue == cod_stato)) cc_temp.Add(c);
                        }
                        progetti_assegnati = cc_temp;
                    }
                    dg.DataSource = progetti_assegnati;
                    dg.Titolo = "Elementi trovati:  " + progetti_assegnati.Count.ToString();
                    dg.ItemDataBound += new DataGridItemEventHandler(dg_ItemDataBound);
                    dg.DataBind();
                    lblNumeroProgetti.Text = progetti_assegnati.Count.ToString();
                    lblNumeroPresentati.Text = DomandePresentate;
                    break;
            }
            base.OnPreRender(e);
        }

        void dgOperatore_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].Attributes.Add("align", "center");
                e.Item.Cells[0].Attributes.Add("colspan", "5");
                e.Item.Cells[0].Text = "OPERATORE SELEZIONATO</td></tr><tr class='TESTA'><td>Nominativo";
            }
        }

        void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CollaboratoriXBando c = (SiarLibrary.CollaboratoriXBando)e.Item.DataItem;
                e.Item.Cells[1].Text = "NUMERO: <b>" + c.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + c.AdditionalAttributes["CUAA"]
                    + "<br />Rag.soc:</b> " + c.AdditionalAttributes["RAGIONE_SOCIALE"] + "<br /><b>Sede:</b> " + c.AdditionalAttributes["COMUNE"] + " ("
                    + c.AdditionalAttributes["SIGLA"] + ") - " + c.AdditionalAttributes["CAP"];
                e.Item.Cells[2].Text = "<img src='../../images/acrobat.gif' alt='Visualizza domanda' style='cursor:pointer' onclick=\"" + url_stampa_domanda
                    + c.IdProgetto + "');\" />";
                e.Item.Cells[3].Text = c.AdditionalAttributes["DATA_RILASCIO"];
                e.Item.Cells[4].Text = c.AdditionalAttributes["PROVINCIA_DI_PRESENTAZIONE"];
                e.Item.Cells[5].Text = c.AdditionalAttributes["STATO"];
                if (AbilitaModifica)
                    e.Item.Cells[6].Text = "<a href=\"javascript:eliminaDomanda(" + c.IdCollaboratore + ");\"><img src='../../images/xdel.gif' alt='Disassegna domanda'></a>";
            }
        }

        private void controlloOperatore()
        {
            //if (!IsPostBack) lstProvincia.SelectedValue = operatore.Utente.Provincia;
            if (AbilitaModifica)
            {
                //la modifica e' abilitata sia per gli istruttori che per i resp di misura che sono responsabili di provincia
                SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider()
                   .Find( Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
                //SiarLibrary.ResponsabiliXBandoCollection responsabili = new SiarBLL.ResponsabiliXBandoCollectionProvider()
                //    .Find(null, Bando.IdBando, Operatore.Utente.CfUtente, null, null);
                if (responsabili.Count == 0 || (responsabili[0].Provincia != null &&
                    (rblFiltroProvincia.SelectedValue == null ? responsabili.FiltroProvincia(null, true).Count
                    : responsabili.FiltroProvincia(rblFiltroProvincia.SelectedValue, null).Count) == 0))
                    AbilitaModifica = false;
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e) { }

        protected void btnCerca_Click(object sender, EventArgs e) { }

        void dgProgettiDaAssegnare_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Progetto progetto = (SiarLibrary.Progetto)e.Item.DataItem;
                dgi.Cells[1].Text = "NUMERO: <b>" + progetto.IdProgetto + "</b>&nbsp;&nbsp;-&nbsp;&nbsp; Partita iva/Codice fiscale: <b>" + progetto.AdditionalAttributes["CUAA"]
                    + "<br />Rag.soc:</b> " + progetto.AdditionalAttributes["RagioneSociale"]
                    + "<br /><b>Sede:</b> " + progetto.AdditionalAttributes["SedeLegale"];
            }
        }

        protected void btnAssegna_Click(object sender, EventArgs e)
        {
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgProgettiDaAssegnare.Columns[5]).GetSelected();
            if (selezionati.Length == 0) { ShowError("Selezionare almeno una domanda di aiuto."); return; }
            SiarBLL.CollaboratoriXBandoCollectionProvider coll_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider();
            try
            {
                coll_provider.DbProviderObj.BeginTran();
                foreach (string s in selezionati)
                {
                    SiarLibrary.CollaboratoriXBando collaboratore = new SiarLibrary.CollaboratoriXBando();
                    collaboratore.IdUtente = istruttore.IdUtente;
                    collaboratore.IdBando = Bando.IdBando;
                    collaboratore.IdProgetto = s;
                    collaboratore.Provincia = lstProvincia.SelectedValue;
                    collaboratore.OperatoreInserimento = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                    collaboratore.DataInserimento = DateTime.Now;
                    collaboratore.Attivo = true;
                    coll_provider.Save(collaboratore);
                }
                coll_provider.DbProviderObj.Commit();
                ShowMessage("Domande assegnate correttamente.");
            }
            catch (Exception ex) { coll_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                collaboratori_provider.DbProviderObj.BeginTran();
                foreach (SiarLibrary.CollaboratoriXBando c in collaboratori_provider.Find(Bando.IdBando, null, istruttore.IdUtente, null, true))
                {
                    c.Attivo = false;
                    c.DataFineValidita = DateTime.Now;
                    c.OperatoreFineValidita = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                    collaboratori_provider.Save(c);
                }
                collaboratori_provider.DbProviderObj.Commit();
                Redirect("Collaboratori.aspx", "Operatore disabilitato correttamente.", false);
            }
            catch (Exception ex) { collaboratori_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaDomanda_Click(object sender, EventArgs e)
        {
            try
            {
                int id_progetto;
                if (!int.TryParse(hdnEliminaDomanda.Value, out id_progetto)) throw new Exception("Nessuna domanda di aiuto selezionata.");
                SiarLibrary.CollaboratoriXBando c = collaboratori_provider.GetById(id_progetto);
                if (c == null) throw new Exception("Nessuna domanda di aiuto selezionata.");
                c.Attivo = false;
                c.DataFineValidita = DateTime.Now;
                c.OperatoreFineValidita = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                collaboratori_provider.Save(c);
                ShowMessage("Assegnazione pratica rimossa correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}