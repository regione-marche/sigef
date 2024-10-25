using System;

namespace web.Private.IPagamento
{
    public partial class RichiestaDocumentiIntegrativi : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarLibrary.ProgettoComunicazioni com_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idComunicazione;
            try
            {
                if (int.TryParse(Request.QueryString["idcom"], out idComunicazione)) com_selezionata = comunicazioni_provider.GetById(idComunicazione);
                if (com_selezionata != null && com_selezionata.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento) throw new Exception("La comunicazione selezionata non è valida.");
                if (com_selezionata == null || com_selezionata.CodTipo != "DNT" || DomandaPagamento == null) throw new Exception("La comunicazione selezionata non è valida.");
                ucRichiestaDocumentazione.Progetto = Progetto;
                ucRichiestaDocumentazione.DomandaPagamento = DomandaPagamento;
                ucRichiestaDocumentazione.ProgettoComunicazioni = com_selezionata;
            }
            catch (Exception ex) { Redirect("CheckListPagamento.aspx", ex.Message, true); }
        }

        //        protected override void OnPreRender(EventArgs e)
        //        {
        //            comunicazione_documenti = pcdocumenti_provider.Find(com_selezionata.Id, null, null, null); // da cambiare
        //            Literal l = new Literal();
        //            l.Text = "<br /><div class=dgTitolo>Nr. documenti richiesti: " + comunicazione_documenti.Count + "</div>";
        //            tdDocumenti.Controls.Add(l);
        //            int counter = 1;
        //            foreach (SiarLibrary.ProgettoComunicazioniDocumenti pcd in comunicazione_documenti)
        //            {
        //                CONTROLS.ucRichiestaDocumentoPagamento c = (CONTROLS.ucRichiestaDocumentoPagamento)LoadControl("../../CONTROLS/ucRichiestaDocumentoPagamento.ascx");
        //                c.ID = "ucRichiestaDocumentoPagamento" + pcd.Id;
        //                c.Documento = pcd;
        //                c.Width = 800;
        //                c.NrDoc = counter++;
        //                c.EliminaDocumentoAbilitato = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma;
        //                tdDocumenti.Controls.Add(c);
        //            }

        //            btnNADettaglio.Enabled = btnSalva.Enabled = btnElimina.Enabled = istruttoreAbilitato && !com_selezionata.PredispostaAllaFirma && comunicazione_documenti.Count >0;
        //            btnPredisponi.Enabled = istruttoreAbilitato && com_selezionata.Segnatura == null && comunicazione_documenti.Count > 0;
        //            if (com_selezionata.PredispostaAllaFirma)
        //            {
        //                btnPredisponi.Text = "Annulla predisposizione";
        //                btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
        //            }
        //            btnFirma.Enabled = responsabileAbilitato && com_selezionata.PredispostaAllaFirma && com_selezionata.Segnatura == null;
        //            if (com_selezionata.Segnatura != null)
        //            {
        //                btnStampaRichiesta.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + com_selezionata.Segnatura + "');");
        //                btnStampaRichiesta.Disabled = false;
        //                btnSalvaSegnaturaRisposta.Enabled = istruttoreAbilitato || responsabileAbilitato;
        //                SiarLibrary.ProgettoComunicazioniCollection risp_coll = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
        //                if (risp_coll.Count > 0)
        //                {
        //                    txtSegnaturaRisposta.Text = risp_coll[0].Segnatura;
        //                    if (risp_coll[0].IdNote != null) txtNoteRisposta.Text = note_provider.GetById(risp_coll[0].IdNote).Testo;
        //                }
        //            }
        //            base.OnPreRender(e);
        //        }
        //        void controlloOperatore()
        //        {
        //            if (AbilitaModifica)
        //            {
        //                istruttoreAbilitato = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando,
        //                    Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0;
        //                responsabileAbilitato = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente,
        //                    Progetto.ProvinciaDiPresentazione, null, true).Count > 0;
        //            }
        //        }

        //        protected void btnSalva_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
        //                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");
        //                comunicazioni_provider.DbProviderObj.BeginTran();

        //                SiarLibrary.ProgettoComunicazioniDocumentiCollection progetto_documenti = pcdocumenti_provider.Find(com_selezionata.Id, null, null, null);
        //                //  if (progetto_documenti.Count == 0) throw new Exception("Non è stato specificato nessun documento da richiedere, impossibile continuare.");
        //                foreach (SiarLibrary.ProgettoComunicazioniDocumenti pcd in progetto_documenti)
        //                {
        //                    foreach (string s in Request.Form.AllKeys)
        //                        if (s.EndsWith("ucRichiestaDocumentoPagamento" + pcd.Id + "$txtNoteIstruttore_text"))
        //                        {
        //                            string note = Request.Form[s];
        //                            if (string.IsNullOrEmpty(note)) pcd.IdNoteComunicazione = null;
        //                            else
        //                            {
        //                                SiarLibrary.Note n = null;
        //                                if (pcd.IdNoteComunicazione != null) n = note_provider.GetById(pcd.IdNoteComunicazione);
        //                                if (n == null) n = new SiarLibrary.Note();
        //                                n.Testo = note;
        //                                note_provider.Save(n);
        //                                pcd.IdNoteComunicazione = n.Id;
        //                            }
        //                            break;
        //                        }
        //                    pcdocumenti_provider.Save(pcd);
        //                }
        //                com_selezionata.Data = DateTime.Now;
        //                com_selezionata.Operatore = Operatore.Utente.IdUtente;
        //                comunicazioni_provider.Save(com_selezionata);
        //                comunicazioni_provider.DbProviderObj.Commit();
        //                ShowMessage("Richiesta salvata correttamente.");
        //            }
        //            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //        }
        //        protected void btnElimina_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
        //                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null)
        //                    throw new Exception("La comunicazione selezionata non è valida.");
        //                comunicazioni_provider.DbProviderObj.BeginTran();
        //                pcdocumenti_provider.DeleteCollection(pcdocumenti_provider.Find(com_selezionata.Id, null, null, null));
        //                comunicazioni_provider.Delete(com_selezionata);
        //                comunicazioni_provider.DbProviderObj.Commit();
        //                Redirect("IstruttoriaAllegati.aspx?iddom=" + Progetto.IdProgetto + "idpag=" + DomandaPagamento.IdDomandaPagamento,
        //               "Richiesta documentale eliminata correttamente.", false);
        //            }
        //            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //        }

        //        protected void btnNADettaglio_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                lstNACategoria.CommandText = @"SELECT CODICE , '('+FORMATO+') ' + SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE, FORMATO 
        //                                            FROM TIPO_DOCUMENTO WHERE ATTIVO =1 ORDER BY CODICE DESC,DESCRIZIONE";
        //                lstNACategoria.DataBind();
        //                RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
        //            }
        //            catch (Exception ex) { ShowError(ex); }
        //        }

        //        protected void btnNASalva_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
        //                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");
        //                if (string.IsNullOrEmpty(lstNACategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");

        //                comunicazioni_provider.DbProviderObj.BeginTran();
        //                SiarLibrary.ProgettoComunicazioniDocumenti d = new SiarLibrary.ProgettoComunicazioniDocumenti();
        //                d.IdComunicazione = com_selezionata.Id;
        //                d.CodTipoDocumento = lstNACategoria.SelectedValue;
        //                if (!string.IsNullOrEmpty(txtNADescrizioneBreve.Text))
        //                {
        //                    SiarLibrary.Note n = new SiarLibrary.Note();
        //                    n.Testo = txtNADescrizioneBreve.Text;
        //                    note_provider.Save(n);
        //                    d.IdNoteComunicazione = n.Id;
        //                }
        //                pcdocumenti_provider.Save(d);
        //                com_selezionata.Data = DateTime.Now;
        //                com_selezionata.Operatore = Operatore.Utente.IdUtente;
        //                comunicazioni_provider.Save(com_selezionata);
        //                comunicazioni_provider.DbProviderObj.Commit();
        //                RegisterClientScriptBlock("chiudiPopup();");
        //                ShowMessage("Documento aggiunto correttamente.");
        //            }
        //            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //        }

        //        protected void btnEliminaAllegato_Click(object sender, EventArgs e)
        //        {
        //            SiarLibrary.ProgettoComunicazioniDocumenti doc = null;
        //            int id_pcallegato;
        //            try
        //            {
        //                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
        //                if (com_selezionata.PredispostaAllaFirma || com_selezionata.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");

        //                if (int.TryParse(hdnIdPCAllegato.Value, out id_pcallegato)) doc = pcdocumenti_provider.GetById(id_pcallegato);
        //                if (doc == null || doc.IdComunicazione != com_selezionata.Id) throw new Exception("Per continuare è obbligatorio selezionare il documento da escludere.");

        //                comunicazioni_provider.DbProviderObj.BeginTran();
        //                pcdocumenti_provider.Delete(doc);
        //                com_selezionata.Data = DateTime.Now;
        //                com_selezionata.Operatore = Operatore.Utente.IdUtente;
        //                comunicazioni_provider.Save(com_selezionata);
        //                comunicazioni_provider.DbProviderObj.Commit();
        //                ShowMessage("Documento eliminato correttamente.");
        //            }
        //            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //        }

        //        protected void btnPredisponi_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                bool predisponi = !com_selezionata.PredispostaAllaFirma;
        //                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della presente richiesta.");
        //                com_selezionata.PredispostaAllaFirma = predisponi;
        //                com_selezionata.Operatore = Operatore.Utente.IdUtente;
        //                com_selezionata.Data = DateTime.Now;
        //                comunicazioni_provider.Save(com_selezionata);
        //                string messaggio = "Predisposizione alla firma effettuata correttamente.";
        //                if (!predisponi) messaggio = "Predisposizione alla firma rimossa correttamente.";
        //                ShowMessage(messaggio);
        //            }
        //            catch (Exception ex) { ShowError(ex); }
        //        }

        //        protected void btnFirma_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
        //                if (!com_selezionata.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
        //                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, com_selezionata.Id);
        //            }
        //            catch (Exception ex) { ShowError(ex); }
        //        }

        //        protected void btnFirmaPost_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
        //                if (!com_selezionata.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
        //                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
        //                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);   
        //                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo();
        //                protocollo.setCorrispondente(impresa, false);
        //                protocollo.setDocumento("richiesta_documentazione_integrativa_per_" + DomandaPagamento.Descrizione + "_domanda_" 
        //                      +  Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
        //                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, Progetto.ProvinciaDiPresentazione);
        //                string oggetto = "Richiesta di documentazione integrativa per la richiesta di " + DomandaPagamento.Descrizione + " per la domanda di aiuto nr. " + Progetto.IdProgetto
        //                    + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
        //                    + Bando.DataScadenza + "\n" + ss[3] + "\nCUAA: " + impresa.Cuaa;
        //                string segnatura = protocollo.ProtocolloUscita(oggetto, ss[4], true);
        //                try
        //                {
        //                    comunicazioni_provider.DbProviderObj.BeginTran();
        //                    com_selezionata.Segnatura = segnatura;
        //                    com_selezionata.Operatore = Operatore.Utente.IdUtente;
        //                    com_selezionata.Data = DateTime.Now;
        //                    comunicazioni_provider.Save(com_selezionata);
        //                    comunicazioni_provider.DbProviderObj.Commit();
        //                }
        //                catch (Exception exc)
        //                {
        //                    comunicazioni_provider.DbProviderObj.Rollback();
        //                    new SiarLibrary.Email("Errore nella richiesta di documentazione integrativa per la richiesta di "+DomandaPagamento.Descrizione +" per la domanda n. " + Progetto.IdProgetto,
        //                        "\nSegnatura documento interno protocollato: " + segnatura +
        //                        "\nErrore: " + exc.Message).SendAlert();
        //                    throw;
        //                }
        //                btnFirma.Enabled = false;
        //                ShowMessage("Richiesta di documentazione integrativa firmata e inviata correttamente.");
        //            }
        //            catch (Exception ex) { ShowError(ex); }
        //            finally { ucFirmaDocumento.FileFirmato = null; }
        //        }

        //        protected void btnSalvaSegnaturaRisposta_Click(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
        //                if (com_selezionata.Segnatura == null) throw new Exception("La comunicazione selezionata non è valida.");
        //                if (string.IsNullOrEmpty(txtSegnaturaRisposta.Text)) throw new Exception("E' necessario specificare la segnatura del protocollo in ingresso.");
        //                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaRisposta.Text))
        //                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);

        //                comunicazioni_provider.DbProviderObj.BeginTran();
        //                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
        //                SiarLibrary.ProgettoComunicazioniCollection cc = comunicazioni_provider.FindComunicazioneRiferimento(com_selezionata.Id);
        //                if (cc.Count > 0) pc = cc[0];
        //                pc.IdProgetto = Progetto.IdProgetto;
        //                pc.CodTipo = "DPT";
        //                pc.PredispostaAllaFirma = false;
        //                pc.Direzione = "A";
        //                pc.Data = DateTime.Now;
        //                pc.Operatore = Operatore.Utente.IdUtente;
        //                pc.IdComunicazioneRiferimento = com_selezionata.Id;
        //                pc.Segnatura = txtSegnaturaRisposta.Text;
        //                if (string.IsNullOrEmpty(txtNoteRisposta.Text)) pc.IdNote = null;
        //                else
        //                {
        //                    SiarLibrary.Note n = null;
        //                    if (pc.IdNote != null) n = note_provider.GetById(pc.IdNote);
        //                    if (n == null) n = new SiarLibrary.Note();
        //                    n.Testo = txtNoteRisposta.Text;
        //                    note_provider.Save(n);
        //                    pc.IdNote = n.Id;
        //                }
        //                comunicazioni_provider.Save(pc);
        //                comunicazioni_provider.DbProviderObj.Commit();
        //                ShowMessage("Documentazione in risposta registrata correttamente.");
        //            }
        //            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //        }
    }
}
