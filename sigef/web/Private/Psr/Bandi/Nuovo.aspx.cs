using System;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class Nuovo : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "bando_nuovo";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Operatore.Utente.CodEnte != "%")
            {
                // commentato: l'inserimento di un nuovo bando sara' a cura degli amministratori
                //lstEnte.SelectedValue = Operatore.Utente.CodEnte;
                //lstEnte.Enabled = false;
                Redirect("ricerca.aspx", "La pagina selezionata è accessibile solo agli operatori di amministrazione.", true);
            }
            txtOraScadenza.Text = "23:59";
            txtResponsabile.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            lstEnte.DataBind();
            lstPsr.DataBind();
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                tbMisura.Visible = true;
                lstProgrammazione.CodicePsr = lstPsr.SelectedValue;
                lstProgrammazione.AttivazioneBandi = true;
                lstProgrammazione.DataBind();

                SiarLibrary.ZpsrAlberoCollection cc = new SiarBLL.ZpsrAlberoCollectionProvider().Find(lstPsr.SelectedValue, null, null,
                    true, null, null, null, null);
                if (cc.Count == 0) ShowError("La programmazione del Psr selezionato non è valida.");
                else
                {
                    lblDefinizioneProgrammazione.Text = cc[0].Descrizione.Value.ToLower();
                    if (!string.IsNullOrEmpty(lstProgrammazione.SelectedValue))
                    {
                        tbInterventi.Visible = true;
                        SiarLibrary.ZprogrammazioneCollection interventi = new SiarBLL.ZprogrammazioneCollectionProvider().
                            GetProgrammazionePsr(lstPsr.SelectedValue, lstProgrammazione.SelectedValue, null, null, null, true, null);
                        dgInterventi.DataSource = interventi;
                        dgInterventi.Titolo = "Elementi trovati: " + interventi.Count;
                        dgInterventi.DataBind();
                    }
                }
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                int id_bando = salva(false);
                Redirect("Dettaglio.aspx?idb=" + id_bando, "Il nuovo bando è stato inserito correttamente, è ora possibile iniziarne la profilazione completa.", false);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDisposizioniAttuative_Click(object sender, EventArgs e)
        {
            try
            {
                int id_bando = salva(true);
                Redirect("Dettaglio.aspx?idb=" + id_bando, "Le nuove disposizioni attuative sono state inserite correttamente, è ora possibile iniziarne la profilazione completa.", false);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private int salva(bool disp_attuativa)
        {
            SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
            SiarBLL.BandoStoricoCollectionProvider storico_provider = new SiarBLL.BandoStoricoCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoIntegrazioniCollectionProvider integrazioni_provider = new SiarBLL.BandoIntegrazioniCollectionProvider(bando_provider.DbProviderObj);
            SiarBLL.BandoProgrammazioneCollectionProvider progbando_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(bando_provider.DbProviderObj);
            try
            {
                string[] interventi_selezionati = ((SiarLibrary.Web.CheckColumn)dgInterventi.Columns[3]).GetSelected();
                if (interventi_selezionati.Length == 0)
                    throw new Exception("Per proseguire è necessario selezionare almeno una tipologia di intervento.");
                bando_provider.DbProviderObj.BeginTran();

                SiarLibrary.Bando b = new SiarLibrary.Bando();
                b.CodEnte = lstEnte.SelectedValue;
                b.Descrizione = txtDescrizione.Text;
                b.DataInserimento = DateTime.Now;
                b.DisposizioniAttuative = disp_attuativa;
                b.IdProgrammazione = lstProgrammazione.SelectedValue;
                b.Multiprogetto = false;
                b.Multimisura = false;
                b.FascicoloRichiesto = false;
                bando_provider.Save(b);
                // storico
                SiarLibrary.BandoStorico s = new SiarLibrary.BandoStorico();
                s.IdBando = b.IdBando;
                s.CodStato = "P";
                s.Data = DateTime.Now;
                s.Operatore = Operatore.Utente.IdUtente;
                storico_provider.Save(s);
                // integrazioni
                SiarLibrary.BandoIntegrazioni i = new SiarLibrary.BandoIntegrazioni();
                i.IdBando = b.IdBando;
                i.Data = DateTime.Now;
                i.Operatore = Operatore.Utente.IdUtente;
                i.DataScadenza = txtDataScadenza.Text;
                string ora_scadenza = txtOraScadenza.Text;
                if (string.IsNullOrEmpty(ora_scadenza)) ora_scadenza = "23:59";
                i.DataScadenza.AddHour(int.Parse(ora_scadenza.Substring(0, 2)), int.Parse(ora_scadenza.Substring(3, 2)), 00);
                i.Importo = txtImporto.Text;
                integrazioni_provider.Save(i);
                // aggiorno
                b.IdIntegrazioneUltima = i.Id;
                b.IdStoricoUltimo = s.Id;
                bando_provider.Save(b);
                // responsabile regionale
                SiarLibrary.BandoResponsabili rr = new SiarLibrary.BandoResponsabili();
                rr.IdBando = b.IdBando;
                int id_utente;
                if (!int.TryParse(hdnIdUtenteResponsabile.Text, out id_utente))
                    throw new Exception("Il responsabile del bando indicato non è valido.");
                rr.IdUtente = id_utente;
                rr.Attivo = true;
                rr.Data = DateTime.Now;
                rr.Operatore = Operatore.Utente.IdUtente;
                new SiarBLL.BandoResponsabiliCollectionProvider(bando_provider.DbProviderObj).Save(rr);

                //responsabile provinciale
                SiarLibrary.BandoResponsabili rr_prov = new SiarLibrary.BandoResponsabili();
                rr_prov.IdUtente = id_utente;
                rr_prov.IdBando = b.IdBando;
                rr_prov.Attivo = true;
                rr_prov.Data = DateTime.Now;
                rr_prov.Operatore = Operatore.Utente.IdUtente;
                rr_prov.Provincia = "AN";
                new SiarBLL.BandoResponsabiliCollectionProvider(bando_provider.DbProviderObj).Save(rr_prov);

                //salvo in programmazione bando
                for (int j = 0; j < interventi_selezionati.Length; j++)
                {
                    SiarLibrary.BandoProgrammazione pb = new SiarLibrary.BandoProgrammazione();
                    pb.IdBando = b.IdBando;
                    pb.IdProgrammazione = interventi_selezionati[j];
                    pb.MisuraPrevalente = true;
                    progbando_provider.Save(pb);
                }
                bando_provider.DbProviderObj.Commit();
                return b.IdBando;
            }
            catch (Exception ex) { bando_provider.DbProviderObj.Rollback(); throw ex; }
        }
    }
}
