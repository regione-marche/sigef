using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using System.Collections.Generic;
using SiarBLL;

namespace web.Private.Istruttoria
{
    public partial class RichiestaCertificazione : SiarLibrary.Web.IstruttoriaPage
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
                if (com_selezionata == null || com_selezionata.CodTipo != "RCC" || ucInfoDomanda.Progetto == null)
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
            int id_comune = 0;
            string cod_ente_amministrazione = "";
            foreach (SiarLibrary.ProgettoComunicazioniAllegati a in comunicazione_allegati)
            {
                if (id_comune == 0) id_comune = a.IdComune ?? 0;
                if (string.IsNullOrEmpty(cod_ente_amministrazione)) cod_ente_amministrazione = a.CodEnteEmettitore ?? "";

                CONTROLS.ucRichiestaDocumento c = (CONTROLS.ucRichiestaDocumento)LoadControl("../../controls/ucRichiestaDocumento.ascx");
                c.ID = "ucRichiestaDocumento" + a.Id;
                c.Allegato = a;
                c.Width = 800;
                c.NrDoc = counter++;
                c.EliminaDocumentoAbilitato = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma;
                tdDocumenti.Controls.Add(c);
            }

            hdnCodEnte.Value = com_selezionata.IdComune.IsNullAlt(com_selezionata.CodEnteEmettitore);
            string cod_tipo_ente = "", ente = "";
            if (string.IsNullOrEmpty(hdnCodEnte.Value))
            {
                if (id_comune > 0)
                {
                    SiarLibrary.Comuni c = new SiarBLL.ComuniCollectionProvider().GetById(id_comune);
                    if (c != null)
                    {
                        cod_tipo_ente = "CM";
                        hdnCodEnte.Value = c.IdComune;
                        ente = c.Denominazione + " (" + c.Sigla + ")";
                    }
                }
                else if (!string.IsNullOrEmpty(cod_ente_amministrazione))
                {
                    SiarLibrary.Ente en = new SiarBLL.EnteCollectionProvider().GetById(cod_ente_amministrazione);
                    if (en != null)
                    {
                        cod_tipo_ente = en.CodTipoEnte;
                        hdnCodEnte.Value = en.CodEnte;
                        ente = en.Descrizione;
                    }
                }
            }
            else
            {
                cod_tipo_ente = com_selezionata.IdComune != null ? "CM" : com_selezionata.CodTipoEnte.Value;
                ente = com_selezionata.Ente;
            }
            lstTipoEnte.SelectedValue = cod_tipo_ente;
            txtEnte.Text = ente;

            lstTipoEnte.Attributes.Add("onchange", "lstTipoEnte_changed();");
            txtEnte.AddJSAttribute("onkeydown", "tipo='P';SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");
            lstTipoEnteRisposta.Attributes.Add("onchange", "lstTipoEnteRisposta_changed();");
            txtEnteRisposta.AddJSAttribute("onkeydown", "tipo='A';SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");

            btnSalva.Enabled = btnElimina.Enabled = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma;
            btnPredisponi.Enabled = istruttoreAbilitato && com_selezionata.Segnatura == null;
            if (com_selezionata.PredispostaAllaFirma)
            {
                btnPredisponi.Text = "Annulla predisposizione";
                //btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
                btnPredisponi.OnClientClick = "return ctrlPredisponi(event, true);";
            }
            btnFirma.Enabled = responsabileAbilitato && com_selezionata.PredispostaAllaFirma && com_selezionata.Segnatura == null;
            if (com_selezionata.Segnatura != null)
            {
                btnStampaRichiesta.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + com_selezionata.Segnatura + "');");
                btnStampaRichiesta.Disabled = false;
                btnSalvaRisposta.Enabled = istruttoreAbilitato || responsabileAbilitato;
                SiarLibrary.ProgettoComunicazioniCollection risp_coll = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
                if (risp_coll.Count > 0)
                {
                    hdnCodEnteRisposta.Value = risp_coll[0].IdComune.IsNullAlt(risp_coll[0].CodEnteEmettitore);
                    lstTipoEnteRisposta.SelectedValue = risp_coll[0].IdComune != null ? "CM" : (risp_coll[0].CodEnteEmettitore != null ? "PR" : "");
                    txtSegnaturaRisposta.Text = risp_coll[0].Segnatura;
                    txtEnteRisposta.Text = risp_coll[0].Ente;
                    if (risp_coll[0].IdNote != null) txtNoteRisposta.Text = note_provider.GetById(risp_coll[0].IdNote).Testo;
                }
                else
                {
                    hdnCodEnteRisposta.Value = com_selezionata.IdComune.IsNullAlt(com_selezionata.CodEnteEmettitore);
                    lstTipoEnteRisposta.SelectedValue = com_selezionata.IdComune != null ? "CM" : (com_selezionata.CodEnteEmettitore != null ? "PR" : "");
                    txtEnteRisposta.Text = com_selezionata.Ente;
                }
            }
            base.OnPreRender(e);
        }

        void controlloOperatore()
        {
            if (AbilitaModifica && ucInfoDomanda.Progetto.CodStato.FindValueIn("I", "A"))
            {
                istruttoreAbilitato = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando,
                    ucInfoDomanda.Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0;
                responsabileAbilitato = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente,
                    ucInfoDomanda.Progetto.ProvinciaDiPresentazione, null, true).Count > 0;
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
                    throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(hdnCodEnte.Value)) throw new Exception("E` obbligatorio specificare l'amministrazione destinataria.");
                SiarLibrary.Comuni comune_selezionato = null;
                int id_comune;
                if (lstTipoEnte.SelectedValue == "CM")
                {
                    if (int.TryParse(hdnCodEnte.Value, out id_comune)) comune_selezionato = new SiarBLL.ComuniCollectionProvider().GetById(id_comune);
                    if (comune_selezionato == null) throw new Exception("Il comune selezionato non è valido.");
                }
                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioniAllegatiCollection docs = pcallegati_provider.Find(com_selezionata.Id, null, null);
                if (docs.Count == 0) throw new Exception("Non è stato specificato nessun documento da richiedere, impossibile continuare.");
                foreach (SiarLibrary.ProgettoComunicazioniAllegati ca in docs)
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

                if (comune_selezionato != null)
                {
                    com_selezionata.IdComune = comune_selezionato.IdComune;
                    com_selezionata.CodEnteEmettitore = null;
                }
                else
                {
                    com_selezionata.CodEnteEmettitore = hdnCodEnte.Value;
                    com_selezionata.IdComune = null;
                }
                com_selezionata.Data = DateTime.Now;
                com_selezionata.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(com_selezionata);
                comunicazioni_provider.DbProviderObj.Commit();
                com_selezionata = comunicazioni_provider.GetById(com_selezionata.Id);
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
                    "Richiesta di certificazione eliminata correttamente.", false);
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
                if (com_selezionata.Segnatura != null) throw new Exception("La richiesta è già stata inviata, impossibile continuare.");
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
                if (com_selezionata.IdComune == null) throw new Exception("L'amministrazione destinataria della presente richiesta non è valida, impossibile continuare.");
                string[] suap = comunicazioni_provider.GetPecSuap(com_selezionata.IdComune);
                if (string.IsNullOrEmpty(suap[1])) throw new Exception("Indirizzo Pec non trovato, impossibile continuare.");

                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(Bando.CodEnte);
                protocollo.setCorrispondente(com_selezionata.Ente, null, suap[1], "destinatario");
                protocollo.setDocumento("richiesta_certificazione_domanda_"
                      + ucInfoDomanda.Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, ucInfoDomanda.Progetto.ProvinciaDiPresentazione);
                string oggetto = "Richiesta di certificazione all'ente " + com_selezionata.Ente + " per la domanda di aiuto nr. " + ucInfoDomanda.Progetto.IdProgetto
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
                    string oggettoEmail = "Errore nella richiesta di  certificazione per la domanda n. " + ucInfoDomanda.Progetto.IdProgetto;
                    string testEmail = "\nSegnatura documento interno protocollato: " + segnatura +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
                btnFirma.Enabled = false;
                ShowMessage("Richiesta di certificazione firmata e inviata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        protected void btnSalvaRisposta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (com_selezionata.Segnatura == null) throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(txtSegnaturaRisposta.Text)) throw new Exception("E' necessario specificare la segnatura del protocollo in ingresso.");
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaRisposta.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

                if (string.IsNullOrEmpty(hdnCodEnteRisposta.Value)) throw new Exception("E` obbligatorio specificare l'amministrazione mittente della documentazione.");
                SiarLibrary.Comuni comune_selezionato = null;
                int id_comune;
                if (lstTipoEnteRisposta.SelectedValue == "CM")
                {
                    if (int.TryParse(hdnCodEnteRisposta.Value, out id_comune)) comune_selezionato = new SiarBLL.ComuniCollectionProvider().GetById(id_comune);
                    if (comune_selezionato == null) throw new Exception("Il comune selezionato non è valido.");
                }

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                SiarLibrary.ProgettoComunicazioniCollection cc = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
                if (cc.Count > 0) pc = cc[0];
                pc.IdProgetto = ucInfoDomanda.Progetto.IdProgetto;
                pc.CodTipo = "PCC"; // cambiare in base al tipo di comunicazione 
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "A";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                pc.IdComunicazioneRiferimento = com_selezionata.Id;
                pc.Segnatura = txtSegnaturaRisposta.Text;

                if (comune_selezionato != null)
                {
                    pc.IdComune = comune_selezionato.IdComune;
                    pc.CodEnteEmettitore = null;
                }
                else
                {
                    pc.CodEnteEmettitore = hdnCodEnteRisposta.Value;
                    pc.IdComune = null;
                }

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