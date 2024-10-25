using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.Private.Istruttoria
{
    public partial class RichiestaDocumentiIntegrativi : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider pcallegati_provider;
        SiarBLL.NoteCollectionProvider note_provider;
        SiarLibrary.ProgettoComunicazioniAllegatiCollection comunicazione_allegati;
        SiarLibrary.ProgettoComunicazioni com_selezionata;

        bool responsabileAbilitato = false, istruttoreAbilitato = false;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int idComunicazione;
                if (int.TryParse(Request.QueryString["idcom"], out idComunicazione)) com_selezionata = comunicazioni_provider.GetById(idComunicazione);
                if (com_selezionata != null) ucInfoDomanda.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(com_selezionata.IdProgetto);
                if (com_selezionata == null || com_selezionata.CodTipo != "DNT" || ucInfoDomanda.Progetto == null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                controlloOperatore();
                ucInfoDomanda.Visible = true;
                ucInfoDomanda.loadData();
                ucFirmaDocumento.DocumentoFirmatoEvent = btnFirmaPost_Click;
                pcallegati_provider = new SiarBLL.ProgettoComunicazioniAllegatiCollectionProvider(comunicazioni_provider.DbProviderObj);
                note_provider = new SiarBLL.NoteCollectionProvider(comunicazioni_provider.DbProviderObj);
            }
            catch (Exception ex) { Redirect("Ammissibilita.aspx", ex.Message, true); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            comunicazione_allegati = pcallegati_provider.Find(com_selezionata.Id, null, null);
            Literal l = new Literal();
            l.Text = "<br /><div class=dgTitolo>Nr. documenti richiesti: " + comunicazione_allegati.Count + "</div>";
            tdDocumenti.Controls.Add(l);
            int counter = 1;
            foreach (SiarLibrary.ProgettoComunicazioniAllegati a in comunicazione_allegati)
            {
                CONTROLS.ucRichiestaDocumento c = (CONTROLS.ucRichiestaDocumento)LoadControl("../../controls/ucRichiestaDocumento.ascx");
                c.ID = "ucRichiestaDocumento" + a.Id;
                c.Allegato = a;
                c.Width = 800;
                c.NrDoc = counter++;
                c.EliminaDocumentoAbilitato = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma;
                tdDocumenti.Controls.Add(c);
            }

            btnNADettaglio.Enabled = btnSalva.Enabled = btnElimina.Enabled = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma;
            btnPredisponi.Enabled = istruttoreAbilitato && com_selezionata.Segnatura == null;
            if (com_selezionata.PredispostaAllaFirma)
            {
                btnPredisponi.Text = "Annulla predisposizione";
                btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
            }
            btnFirma.Enabled = responsabileAbilitato && com_selezionata.PredispostaAllaFirma && com_selezionata.Segnatura == null;
            if (com_selezionata.Segnatura != null)
            {
                btnStampaRichiesta.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + com_selezionata.Segnatura + "');");
                btnStampaRichiesta.Disabled = false;
                btnSalvaSegnaturaRisposta.Enabled = istruttoreAbilitato || responsabileAbilitato;
                SiarLibrary.ProgettoComunicazioniCollection risp_coll = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
                if (risp_coll.Count > 0)
                {
                    txtSegnaturaRisposta.Text = risp_coll[0].Segnatura;
                    if (risp_coll[0].IdNote != null) txtNoteRisposta.Text = note_provider.GetById(risp_coll[0].IdNote).Testo;
                }
            }
            base.OnPreRender(e);
        }

        void controlloOperatore()
        {
            SiarLibrary.ProgettoStoricoCollection StoricoProgetto = new SiarBLL.ProgettoStoricoCollectionProvider().Find(ucInfoDomanda.Progetto.IdProgetto, null, "A");
            SiarLibrary.ProgettoSegnatureCollection SegnatureProgetto = new SiarBLL.ProgettoSegnatureCollectionProvider().Find(ucInfoDomanda.Progetto.IdProgetto, null, null, null);
            SiarLibrary.ProgettoSegnatureCollection riesami = SegnatureProgetto.FiltroLikeTipoSegnatura("RID");
            bool domandaInRiesame = (ucInfoDomanda.Progetto.CodFase == "A" && riesami.Count > 0 && riesami[0].RiapriDomanda &&
                StoricoProgetto.FiltroRevisioneRiesameRicorso(null, true, null).Count == 0);

            // I -> Ricevibile
            // A -> Ammissibile
            // L -> Rilasciato/Definitivo
            if (AbilitaModifica && (ucInfoDomanda.Progetto.CodStato.FindValueIn("I", "A", "L") || domandaInRiesame))
            {
                istruttoreAbilitato = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando,
                    ucInfoDomanda.Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0;
                responsabileAbilitato = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente,
                    null, //ucInfoDomanda.Progetto.ProvinciaDiPresentazione, 
                    null, true).Count > 0;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                comunicazioni_provider.DbProviderObj.BeginTran();
                foreach (SiarLibrary.ProgettoComunicazioniAllegati ca in pcallegati_provider.Find(com_selezionata.Id, null, null))
                {
                    foreach (string s in Request.Form.AllKeys)
                        if (s.EndsWith("ucRichiestaDocumento" + ca.Id + "$txtNoteIstruttore_text"))
                        {
                            string note = Request.Form[s];
                            if (string.IsNullOrEmpty(note)) ca.IdNote = null;
                            else
                            {
                                SiarLibrary.Note n = null;
                                if (ca.IdNote != null) n = note_provider.GetById(ca.IdNote);
                                if (n == null) n = new SiarLibrary.Note();
                                n.Testo = note;
                                note_provider.Save(n);
                                ca.IdNote = n.Id;
                            }
                            break;
                        }
                    pcallegati_provider.Save(ca);
                }
                com_selezionata.Data = DateTime.Now;
                com_selezionata.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(com_selezionata);
                comunicazioni_provider.DbProviderObj.Commit();
                ShowMessage("Richiesta salvata correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                comunicazioni_provider.DbProviderObj.BeginTran();
                pcallegati_provider.DeleteCollection(pcallegati_provider.Find(com_selezionata.Id, null, null));
                comunicazioni_provider.Delete(com_selezionata);
                comunicazioni_provider.DbProviderObj.Commit();
                Redirect("allegatiesiti.aspx?stato=" + ucInfoDomanda.Progetto.CodStato + "&iddom=" + ucInfoDomanda.Progetto.IdProgetto,
                    "Richiesta documentale eliminata correttamente.", false);
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnNADettaglio_Click(object sender, EventArgs e)
        {
            try
            {
                lstNACategoria.CommandText = @"SELECT ID_ALLEGATO,'('+COD_TIPO+') '+SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE,COD_TIPO FROM vALLEGATI_x_DOMANDA
                    WHERE ID_DOMANDA=" + Bando.IdModelloDomanda + " AND COD_TIPO='D' ORDER BY COD_TIPO DESC,DESCRIZIONE";
                lstNACategoria.DataBind();
                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNASalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(lstNACategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioniAllegati a = new SiarLibrary.ProgettoComunicazioniAllegati();
                a.IdComunicazione = com_selezionata.Id;
                a.IdAllegato = lstNACategoria.SelectedValue;
                if (!string.IsNullOrEmpty(txtNADescrizioneBreve.Text))
                {
                    SiarLibrary.Note n = new SiarLibrary.Note();
                    n.Testo = txtNADescrizioneBreve.Text;
                    note_provider.Save(n);
                    a.IdNote = n.Id;
                }
                pcallegati_provider.Save(a);
                com_selezionata.Data = DateTime.Now;
                com_selezionata.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(com_selezionata);
                comunicazioni_provider.DbProviderObj.Commit();
                RegisterClientScriptBlock("chiudiPopup();");
                ShowMessage("Documento aggiunto correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                SiarLibrary.ProgettoComunicazioniAllegati a = null;
                int id_pcallegato;
                if (int.TryParse(hdnIdPCAllegato.Value, out id_pcallegato)) a = pcallegati_provider.GetById(id_pcallegato);
                if (a == null || a.IdComunicazione != com_selezionata.Id)
                    throw new Exception("Per continuare è obbligatorio selezionare il documento da escludere.");

                comunicazioni_provider.DbProviderObj.BeginTran();
                pcallegati_provider.Delete(a);
                com_selezionata.Data = DateTime.Now;
                com_selezionata.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(com_selezionata);
                comunicazioni_provider.DbProviderObj.Commit();
                ShowMessage("Documento eliminato correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPredisponi_Click(object sender, EventArgs e)
        {
            try
            {
                bool predisponi = !com_selezionata.PredispostaAllaFirma;
                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della presente richiesta.");
                com_selezionata.PredispostaAllaFirma = predisponi;
                com_selezionata.Operatore = Operatore.Utente.IdUtente;
                com_selezionata.Data = DateTime.Now;
                comunicazioni_provider.Save(com_selezionata);
                string messaggio = "Predisposizione alla firma effettuata correttamente.";
                if (!predisponi) messaggio = "Predisposizione alla firma rimossa correttamente.";
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
                if (!com_selezionata.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, com_selezionata.Id);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFirmaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
                if (!com_selezionata.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(Bando.CodEnte);
                protocollo.setCorrispondente(ucInfoDomanda.Impresa, ucInfoDomanda.Progetto.IdProgetto, "destinatario");
                protocollo.setDocumento("richiesta_documentazione_integrativa_"
                      + ucInfoDomanda.Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, ucInfoDomanda.Progetto.ProvinciaDiPresentazione);
                string oggetto = "Richiesta di documentazione integrativa per la domanda di aiuto nr. " + ucInfoDomanda.Progetto.IdProgetto
                    + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                    + Bando.DataScadenza + "\n" + ss[3] 
                    + "\n Partita iva/Codice fiscale: " + ucInfoDomanda.Impresa.Cuaa
                    + "\n Ragione sociale: " + ucInfoDomanda.Impresa.RagioneSociale;
                string segnatura = protocollo.ProtocolloUscita(oggetto, ss[4], true);
                try
                {
                    comunicazioni_provider.DbProviderObj.BeginTran();
                    com_selezionata.Segnatura = segnatura;
                    com_selezionata.Operatore = Operatore.Utente.IdUtente;
                    com_selezionata.Data = DateTime.Now;
                    comunicazioni_provider.Save(com_selezionata);
                    comunicazioni_provider.DbProviderObj.Commit();
                }
                catch (Exception exc)
                {
                    comunicazioni_provider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore nella richiesta di documentazione integrativa per la domanda n. " + ucInfoDomanda.Progetto.IdProgetto;
                    string testEmail = "\nSegnatura documento interno protocollato: " + segnatura +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
                btnFirma.Enabled = false;
                ShowMessage("Richiesta di documentazione integrativa firmata e inviata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        protected void btnSalvaSegnaturaRisposta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.Segnatura == null) throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(txtSegnaturaRisposta.Text)) throw new Exception("E' necessario specificare la segnatura del protocollo in ingresso.");
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaRisposta.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                SiarLibrary.ProgettoComunicazioniCollection cc = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
                if (cc.Count > 0) pc = cc[0];
                pc.IdProgetto = ucInfoDomanda.Progetto.IdProgetto;
                pc.CodTipo = "DPT";
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "A";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                pc.IdComunicazioneRiferimento = com_selezionata.Id;
                pc.Segnatura = txtSegnaturaRisposta.Text;
                if (string.IsNullOrEmpty(txtNoteRisposta.Text)) pc.IdNote = null;
                else
                {
                    SiarLibrary.Note n = null;
                    if (pc.IdNote != null) n = note_provider.GetById(pc.IdNote);
                    if (n == null) n = new SiarLibrary.Note();
                    n.Testo = txtNoteRisposta.Text;
                    note_provider.Save(n);
                    pc.IdNote = n.Id;
                }
                comunicazioni_provider.Save(pc);
                comunicazioni_provider.DbProviderObj.Commit();
                ShowMessage("Documentazione in risposta registrata correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }
    }
}