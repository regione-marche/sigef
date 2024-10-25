using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class Collaboratori : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "collaboratori_istruttoria";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstProvincia.DataBind();
            controlloOperatore();
            btnNuovo.Disabled = !AbilitaModifica;

            txtNominativo.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
        }

        protected void btnAssegna_Click(object sender, EventArgs e)
        {
            SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider coll_provider = new SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider();
            try
            {
                SiarLibrary.Utenti u = null;
                int id_utente;
                if (int.TryParse(hdnIdUtente.Value, out id_utente)) u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
                if (u == null || !u.Attivo) throw new Exception("L'operatore selezionato non è attivo. Si richiede di sceglierne un altro.");
                coll_provider.DbProviderObj.BeginTran();

                if (coll_provider.Find(Bando.IdBando, hdnIdUtente.Value, true).Count > 0)
                    throw new Exception("Il collaboratore selezionato è già attivo. Si richiede di sceglierne un altro.");

                SiarLibrary.CollaboratoriXBandoCollection collaboratori = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, null, u.IdUtente, null, true);

                if (collaboratori.Count > 0)
                    throw new Exception("Il collaboratore selezionato è già nella lista dei funzionari istruttori del bando, cosa che gli precluderebbe la firma delle istruttorie. Si richiede di sceglierne un altro.");

                SiarLibrary.CollaboratoriIstruttoriaBando c = new SiarLibrary.CollaboratoriIstruttoriaBando();
                c.IdUtente = u.IdUtente;
                c.IdBando = Bando.IdBando;
                c.IdOperatoreInserimento = Operatore.Utente.IdUtente;
                c.DataInizio = DateTime.Now;
                c.Attivo = true;
                coll_provider.Save(c);

                coll_provider.DbProviderObj.Commit();
                ShowMessage("Collaboratore all'istruttoria " + u.Nominativo + " correttamente aggiunto alla lista.");

                loadCollaboratori();
            }
            catch (Exception ex) { coll_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (hdnVisualizzaListaIstruttori.Value == "S")
            {
                SiarLibrary.CollaboratoriXBandoCollection collaboratori = new SiarBLL.CollaboratoriXBandoCollectionProvider().
                    GetRiepilogoXBando(Bando.IdBando, lstProvincia.SelectedValue);
                dgIstruttori.DataSource = collaboratori;
                dgIstruttori.ItemDataBound += new DataGridItemEventHandler(dgIstruttori_ItemDataBound);
                if (collaboratori.Count == 0) dgIstruttori.Titolo = "Nessun istruttore trovato.";
                dgIstruttori.DataBind();

            }
            lblDomandePresentate.Text = DomandePresentate;
            lblDomande.Text = BandoProvider.GetDomandeNonAssegnate(Bando.IdBando).ToString();

            loadCollaboratori();

            base.OnPreRender(e);
        }

        public void loadCollaboratori()
        {
            SiarLibrary.CollaboratoriIstruttoriaBandoCollection collaboratoriIstruttoria = new SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider().
        Find(Bando.IdBando, null, true);
            dgCollaboratoriIstruttoriaBando.DataSource = collaboratoriIstruttoria;
            if (collaboratoriIstruttoria.Count == 0) dgCollaboratoriIstruttoriaBando.Titolo = "Nessun istruttore trovato.";
            dgCollaboratoriIstruttoriaBando.DataBind();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider collabotatoriProvider = new SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider();
            int id_collabotatore;
            if (!int.TryParse(hdnIdCollaboratorePost.Value, out id_collabotatore)) ShowError("Il collaboratore selezionato non è valido. Impossibile continuare.");
            SiarLibrary.CollaboratoriIstruttoriaBando collabotatore = collabotatoriProvider.GetById(id_collabotatore);
            if (collabotatore != null)
            {
                if (!collabotatore.Attivo)
                    ShowError("Non si può selezionare un collaboratore non più attivo.");
                else
                {
                    txtNominativo.Text = collabotatore.Nominativo;
                    hdnIdUtente.Value = collabotatore.IdUtente;
                }
            }
        }

        protected void btnEliminaCollaboratore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hdnIdCollaboratorePost.Value))
            {
                DeleteMembro(int.Parse(hdnIdCollaboratorePost.Value));
            }
            else
                ShowError("Per eliminare un collaboratore è necessario prima selezionarlo dalla lista.");

        }

        private void DeleteMembro(int idCollaboratore)
        {
            SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider collaboratoriProvider = new SiarBLL.CollaboratoriIstruttoriaBandoCollectionProvider();
            try
            {
                collaboratoriProvider.DbProviderObj.BeginTran();
                SiarLibrary.CollaboratoriIstruttoriaBando v = collaboratoriProvider.GetById(idCollaboratore);
                v.Attivo = false;
                v.DataFine = DateTime.Now;
                collaboratoriProvider.Save(v);


                collaboratoriProvider.DbProviderObj.Commit();
                ShowMessage("Valutatore eliminato correttamente.");
                NewMembro();
            }
            catch (Exception ex) { ShowError(ex); collaboratoriProvider.DbProviderObj.Rollback(); }
        }

        protected void btnNewCollaboratore_Click(object sender, EventArgs e)
        {
            NewMembro();
        }

        private void NewMembro()
        {
            hdnIdCollaboratorePost.Value = string.Empty;
            txtNominativo.Text = string.Empty;
            hdnIdUtente.Value = string.Empty;
        }

        int tot_assegnati = 0, tot_ricevibili = 0, tot_non_ricevibili = 0, tot_ammissibili = 0, tot_non_ammissibili = 0, tot_altri = 0/*, tot_tot = 0*/;
        void dgIstruttori_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.Cells[0].Text = "TOTALE";
                e.Item.Attributes.Add("class", "TESTA1");
                e.Item.Attributes.Add("align", "center");
                e.Item.Cells[2].Text = string.Format("{0:N0}", tot_assegnati);
                e.Item.Cells[3].Text = string.Format("{0:N0}", tot_ricevibili);
                e.Item.Cells[4].Text = string.Format("{0:N0}", tot_non_ricevibili);
                e.Item.Cells[5].Text = string.Format("{0:N0}", tot_ammissibili);
                e.Item.Cells[6].Text = string.Format("{0:N0}", tot_non_ammissibili);
                e.Item.Cells[7].Text = string.Format("{0:N0}", tot_altri);
                //e.Item.Cells[8].Text = string.Format("{0:N0}", tot_tot);

            }
            else if (e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.CollaboratoriXBando c = (SiarLibrary.CollaboratoriXBando)e.Item.DataItem;
                if (AbilitaModifica && c.Provincia != null)
                {
                    e.Item.Cells[0].Text = c.Nominativo + "<span id='link' style='DISPLAY:none;'> CollaboratoreDettaglio.aspx?id=" + c.IdUtente + "</span>";
                    //  ((SiarLibrary.Web.ColonnaLink)dgIstruttori.Columns[0]).LinkFormat = "CollaboratoreDettaglio.aspx";
                }

                int nr_assegnati, nr_ricevibili, nr_non_ricevibili, nr_ammissibili, nr_non_ammissibili, nr_altri/*, tot*/;
                int.TryParse(c.AdditionalAttributes["PROGETTI_ASSEGNATI"], out nr_assegnati);
                int.TryParse(c.AdditionalAttributes["PROGETTI_RICEVIBILI"], out nr_ricevibili);
                int.TryParse(c.AdditionalAttributes["PROGETTI_NON_RICEVIBILI"], out nr_non_ricevibili);
                int.TryParse(c.AdditionalAttributes["PROGETTI_AMMISSIBILI"], out nr_ammissibili);
                int.TryParse(c.AdditionalAttributes["PROGETTI_NON_AMMISSIBILI"], out nr_non_ammissibili);
                int.TryParse(c.AdditionalAttributes["PROGETTI_ISTRUITI_DA_ALTRI"], out nr_altri);

                tot_assegnati += nr_assegnati;
                tot_ricevibili += nr_ricevibili;
                tot_non_ricevibili += nr_non_ricevibili;
                tot_ammissibili += nr_ammissibili;
                tot_non_ammissibili += nr_non_ammissibili;
                tot_altri += nr_altri;
                //tot = nr_assegnati + nr_ricevibili + nr_non_ricevibili + nr_ammissibili + nr_non_ammissibili + nr_altri;
                //tot_tot += tot;

                e.Item.Cells[2].Text = nr_assegnati.ToString();
                e.Item.Cells[3].Text = nr_ricevibili.ToString();
                e.Item.Cells[4].Text = nr_non_ricevibili.ToString();
                e.Item.Cells[5].Text = nr_ammissibili.ToString();
                e.Item.Cells[6].Text = nr_non_ammissibili.ToString();
                e.Item.Cells[7].Text = nr_altri.ToString();
                //e.Item.Cells[8].Text = tot.ToString();
                /*
                dgi.Cells[3].Text = "<a href='CollaboratoreDettaglio.aspx?action=I&id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>" + rcxb.ProgettiRicevibili + "</a>";
                dgi.Cells[4].Text = "<a href='CollaboratoreDettaglio.aspx?action=Q&id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>" + rcxb.ProgettiNonRicevibili + "</a>";
                dgi.Cells[5].Text = "<a href='CollaboratoreDettaglio.aspx?action=A&id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>" + rcxb.ProgettiAmmissibili + "</a>";
                dgi.Cells[6].Text = "<a href='CollaboratoreDettaglio.aspx?action=B&id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>" + rcxb.ProgettiNonAmmissibili + "</a>";
                dgi.Cells[7].Text = "<a href='CollaboratoreDettaglio.aspx?action=altri&id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>" + rcxb.ProgettiIstruitiDaAltri + "</a>";
                dgi.Cells[8].Text = "<a href='CollaboratoreDettaglio.aspx?id=" + rcxb.IdUtente + "&pv=" + rcxb.Provincia + "' target='_self'>modifica -></a>";*/
            }
        }

        private void controlloOperatore()
        {
            if (Operatore.Utente.CodEnte == "%") { AbilitaModifica = true; return; }
            if (!IsPostBack) lstProvincia.SelectedValue = Operatore.Utente.Provincia;
            if (AbilitaModifica)
            {
                //la modifica e' abilitata sia per gli istruttori che per i resp di misura che sono responsabili di provincia
                SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider()
                   .Find(Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
                //SiarLibrary.ResponsabiliXBandoCollection responsabili = new SiarBLL.ResponsabiliXBandoCollectionProvider()
                //    .Find(null, Bando.IdBando, Operatore.Utente.CfUtente, null, null);
                if (responsabili.Count == 0 || (responsabili[0].Provincia != null &&
                    (lstProvincia.SelectedValue == null ? responsabili.FiltroProvincia(null, true).Count
                    : responsabili.FiltroProvincia(lstProvincia.SelectedValue, null).Count) == 0))
                    AbilitaModifica = false;
            }
        }

        protected void btnVisualizzaListaIstruttori_Click(object sender, EventArgs e)
        {
            hdnVisualizzaListaIstruttori.Value = "S";
        }
    }
}