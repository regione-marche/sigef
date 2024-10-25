using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary.Extensions;

namespace web.CONTROLS
{
    public partial class ucRichiestaDocumentazione : System.Web.UI.UserControl
    {
        public SiarLibrary.Operatore Operatore { get { return ((SiarLibrary.Web.PrivatePage)Page).Operatore; } }
        public bool AbilitaModifica { get { return ((SiarLibrary.Web.PrivatePage)Page).AbilitaModifica; } }
        private SiarBLL.ProgettoCollectionProvider _progettoProvider;
        public SiarBLL.ProgettoCollectionProvider ProgettoProvider
        {
            get
            {
                if (_progettoProvider == null) _progettoProvider = new SiarBLL.ProgettoCollectionProvider();
                return _progettoProvider;
            }
            set { _progettoProvider = value; }
        }
        private SiarLibrary.Progetto _progetto;
        public SiarLibrary.Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }
        private SiarLibrary.Varianti _variante;
        public SiarLibrary.Varianti Variante
        {
            get { return _variante; }
            set { _variante = value; }
        }
        private SiarLibrary.DomandaDiPagamento _domandaPagamento;
        public SiarLibrary.DomandaDiPagamento DomandaPagamento
        {
            get { return _domandaPagamento; }
            set { _domandaPagamento = value; }
        }

        private SiarLibrary.ProgettoComunicazioni _progettocomunicazioni;
        public SiarLibrary.ProgettoComunicazioni ProgettoComunicazioni
        {
            get { return _progettocomunicazioni; }
            set { _progettocomunicazioni = value; }
        }
        private string _tipoComunicazione;
        public string TipoComunicazione
        {
            get { return _tipoComunicazione; }
            set { _tipoComunicazione = value; }
        }


        SiarBLL.ProgettoComunicazioniCollectionProvider comunicazioni_provider = new SiarBLL.ProgettoComunicazioniCollectionProvider();
        SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider pcdocumenti_provider;
        SiarBLL.NoteCollectionProvider note_provider;
        SiarLibrary.ProgettoComunicazioniDocumentiCollection comunicazione_documenti;
        string tipo_richiesta;
        bool responsabileAbilitato = false, istruttoreAbilitato = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (_progettocomunicazioni == null) throw new Exception("La comunicazione selezionata non è valida.");

                tipo_richiesta = (DomandaPagamento == null ? Variante.TipoVariante : DomandaPagamento.Descrizione);
                if (_progettocomunicazioni.CodTipo.FindValueIn("DNT", "DPT"))
                {
                    ucFirmaDocumento.Titolo = "PAGINA DI FIRMA DELLA RICHIESTA DI DOCUMENTAZIONE INTEGRATIVA";
                    ucFirmaDocumento.TipoDocumento = "RICHIESTA_DOCUMENTAZIONE_INTEGRATIVA";
                    btnNADettaglio.Visible = true;
                    tbRichiestaCertificazione.Visible = false;
                    tbRichiestaCertificazioneRisposta.Visible = false;
                }
                ucFirmaDocumento.DocumentoFirmatoEvent = btnFirmaPost_Click;
                pcdocumenti_provider = new SiarBLL.ProgettoComunicazioniDocumentiCollectionProvider(comunicazioni_provider.DbProviderObj);
                note_provider = new SiarBLL.NoteCollectionProvider(comunicazioni_provider.DbProviderObj);
                controlloOperatore();
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            int counter = 1, id_comune = 0;
            string cod_ente_amministrazione = "", cod_tipo_ente = "", ente = "";
            comunicazione_documenti = pcdocumenti_provider.Find(_progettocomunicazioni.Id, null, null, null); // da cambiare
            Literal l = new Literal();
            l.Text = "<br /><div class=dgTitolo>Nr. documenti richiesti: " + comunicazione_documenti.Count + "</div>";
            tdDocumenti.Controls.Add(l);
            foreach (SiarLibrary.ProgettoComunicazioniDocumenti pcd in comunicazione_documenti)
            {
                if (id_comune == 0) id_comune = pcd.IdComune ?? 0;
                if (string.IsNullOrEmpty(cod_ente_amministrazione)) cod_ente_amministrazione = pcd.CodEnteEmettitore ?? "";

                CONTROLS.ucRichiestaDocumentoPagamento c = (CONTROLS.ucRichiestaDocumentoPagamento)LoadControl("ucRichiestaDocumentoPagamento.ascx");
                c.ID = "ucRichiestaDocumentoPagamento" + pcd.Id;
                c.Documento = pcd;
                c.Width = 800;
                c.NrDoc = counter++;
                c.EliminaDocumentoAbilitato = istruttoreAbilitato && !_progettocomunicazioni.PredispostaAllaFirma;
                tdDocumenti.Controls.Add(c);
            }
            #region  richiesta certificazione ente
            if (_tipoComunicazione == "RCC")
            {
                hdnCodEnte.Value = _progettocomunicazioni.IdComune.IsNullAlt(_progettocomunicazioni.CodEnteEmettitore);
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
                    cod_tipo_ente = _progettocomunicazioni.IdComune != null ? "CM" : _progettocomunicazioni.CodTipoEnte.Value;
                    ente = _progettocomunicazioni.Ente;
                }
                lstTipoEnte.SelectedValue = cod_tipo_ente;
                txtEnte.Text = ente;
                lstTipoEnte.Attributes.Add("onchange", "lstTipoEnte_changed();");
                txtEnte.AddJSAttribute("onkeydown", "tipo='P';SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");
                lstTipoEnteRisposta.Attributes.Add("onchange", "lstTipoEnteRisposta_changed();");
                txtEnteRisposta.AddJSAttribute("onkeydown", "tipo='A';SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");
                btnSalva.OnClientClick = "return ctrlCampiEnte(event);";
                btnSalvaRisposta.OnClientClick = "return ctrlCampiEnteRisposta(event);";
            }
            #endregion
            btnPredisponi.OnClientClick = "return ctrlPredisponi(event, " + _progettocomunicazioni.PredispostaAllaFirma.ToString().ToLower() + ", '" + _tipoComunicazione + "');";

            btnNADettaglio.Enabled = btnSalva.Enabled = btnElimina.Enabled = istruttoreAbilitato && !_progettocomunicazioni.PredispostaAllaFirma;
            btnPredisponi.Enabled = istruttoreAbilitato && _progettocomunicazioni.Segnatura == null && comunicazione_documenti.Count > 0;

            if (_progettocomunicazioni.PredispostaAllaFirma) btnPredisponi.Text = "Annulla predisposizione";

            btnFirma.Enabled = responsabileAbilitato && _progettocomunicazioni.PredispostaAllaFirma && _progettocomunicazioni.Segnatura == null;
            if (_progettocomunicazioni.Segnatura != null)
            {
                btnStampaRichiesta.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + _progettocomunicazioni.Segnatura + "');");
                btnStampaRichiesta.Disabled = false;
                btnSalvaRisposta.Enabled = istruttoreAbilitato || responsabileAbilitato;
                SiarLibrary.ProgettoComunicazioniCollection risp_coll = comunicazioni_provider.FindComunicazioneRiferimento(_progettocomunicazioni.Id);
                if (risp_coll.Count > 0)
                {
                    hdnCodEnteRisposta.Value = risp_coll[0].IdComune.IsNullAlt(risp_coll[0].CodEnteEmettitore);
                    lstTipoEnteRisposta.SelectedValue = risp_coll[0].IdComune != null ? "CM" : (risp_coll[0].CodEnteEmettitore != null ? "PR" : "");
                    txtEnteRisposta.Text = risp_coll[0].Ente;

                    txtSegnaturaRisposta.Text = risp_coll[0].Segnatura;
                    if (risp_coll[0].IdNote != null) txtNoteRisposta.Text = note_provider.GetById(risp_coll[0].IdNote).Testo;
                }
                else
                {
                    hdnCodEnteRisposta.Value = _progettocomunicazioni.IdComune.IsNullAlt(_progettocomunicazioni.CodEnteEmettitore);
                    lstTipoEnteRisposta.SelectedValue = _progettocomunicazioni.IdComune != null ? "CM" : (_progettocomunicazioni.CodEnteEmettitore != null ? "PR" : "");
                    txtEnteRisposta.Text = _progettocomunicazioni.Ente;
                }
            }
            base.OnPreRender(e);
        }
        void controlloOperatore()
        {
            if (AbilitaModifica)
                istruttoreAbilitato = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Progetto.IdBando,
                    Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0;

            responsabileAbilitato = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente,
                 Progetto.ProvinciaDiPresentazione, null, true).Count > 0;

        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SiarLibrary.Comuni comune_selezionato = null; int id_comune;
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (_progettocomunicazioni.PredispostaAllaFirma || _progettocomunicazioni.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");
                if (_progettocomunicazioni.CodTipo.FindValueIn("RCC", "PCC"))
                {
                    if (string.IsNullOrEmpty(hdnCodEnte.Value)) throw new Exception("E` obbligatorio specificare l'amministrazione destinataria.");
                    if (lstTipoEnte.SelectedValue == "CM")
                    {
                        if (int.TryParse(hdnCodEnte.Value, out id_comune)) comune_selezionato = new SiarBLL.ComuniCollectionProvider().GetById(id_comune);
                        if (comune_selezionato == null) throw new Exception("Il comune selezionato non è valido.");
                        _progettocomunicazioni.IdComune = comune_selezionato.IdComune;
                        _progettocomunicazioni.CodEnteEmettitore = null;
                    }
                    if (comune_selezionato == null)
                    {
                        _progettocomunicazioni.CodEnteEmettitore = hdnCodEnte.Value;
                        _progettocomunicazioni.IdComune = null;
                    }
                }

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioniDocumentiCollection progetto_documenti = pcdocumenti_provider.Find(_progettocomunicazioni.Id, null, null, null);
                if (progetto_documenti.Count == 0) throw new Exception("Non è stato specificato nessun documento da richiedere, impossibile continuare.");
                foreach (SiarLibrary.ProgettoComunicazioniDocumenti pcd in progetto_documenti)
                {
                    foreach (string s in Request.Form.AllKeys)
                        if (s.EndsWith("ucRichiestaDocumentoPagamento" + pcd.Id + "$txtNoteIstruttore_text"))
                        {
                            string note = Request.Form[s];
                            if (string.IsNullOrEmpty(note)) pcd.IdNoteComunicazione = null;
                            else
                            {
                                SiarLibrary.Note n = null;
                                if (pcd.IdNoteComunicazione != null) n = note_provider.GetById(pcd.IdNoteComunicazione);
                                if (n == null) n = new SiarLibrary.Note();
                                n.Testo = note;
                                note_provider.Save(n);
                                pcd.IdNoteComunicazione = n.Id;
                            }
                            break;
                        }
                    pcdocumenti_provider.Save(pcd);
                }

                _progettocomunicazioni.Data = DateTime.Now;
                _progettocomunicazioni.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(_progettocomunicazioni);
                comunicazioni_provider.DbProviderObj.Commit();
                _progettocomunicazioni = comunicazioni_provider.GetById(_progettocomunicazioni.Id);
                ((SiarLibrary.Web.Page)Page).ShowMessage("Richiesta salvata correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (_progettocomunicazioni.PredispostaAllaFirma || _progettocomunicazioni.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");
                comunicazioni_provider.DbProviderObj.BeginTran();
                pcdocumenti_provider.DeleteCollection(pcdocumenti_provider.Find(_progettocomunicazioni.Id, null, null, null));
                comunicazioni_provider.Delete(_progettocomunicazioni);
                comunicazioni_provider.DbProviderObj.Commit();
                if (DomandaPagamento != null)
                    ((SiarLibrary.Web.Page)Page).Redirect("IstruttoriaAllegati.aspx?iddom=" + Progetto.IdProgetto + "idpag=" + DomandaPagamento.IdDomandaPagamento,
                        "Richiesta di certificazione eliminata correttamente.", false);
                else ((SiarLibrary.Web.Page)Page).Redirect("Allegati.aspx?iddom=" + Progetto.IdProgetto + "idvar=" + Variante.IdVariante,
                   "Richiesta di certificazione eliminata correttamente.", false);
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }
        protected void btnNADettaglio_Click(object sender, EventArgs e)
        {
            try
            {
                lstNACategoria.CommandText = @"SELECT CODICE , '('+FORMATO+') ' + SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE, FORMATO 
                                            FROM TIPO_DOCUMENTO WHERE ATTIVO =1 AND FORMATO = 'D' ORDER BY CODICE DESC,DESCRIZIONE";
                lstNACategoria.DataBind();
                ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("mostraPopupTemplate('divSchedaForm','divBKGMessaggio');");
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }

        protected void btnEliminaAllegato_Click(object sender, EventArgs e)
        {
            SiarLibrary.ProgettoComunicazioniDocumenti c = null;
            int id_pcallegato;
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (_progettocomunicazioni.PredispostaAllaFirma || _progettocomunicazioni.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");

                if (int.TryParse(hdnIdPCAllegato.Value, out id_pcallegato)) c = pcdocumenti_provider.GetById(id_pcallegato);
                if (c == null || c.IdComunicazione != _progettocomunicazioni.Id) throw new Exception("Per continuare è obbligatorio selezionare il documento da escludere.");

                comunicazioni_provider.DbProviderObj.BeginTran();
                pcdocumenti_provider.Delete(c);
                _progettocomunicazioni.Data = DateTime.Now;
                _progettocomunicazioni.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(_progettocomunicazioni);
                comunicazioni_provider.DbProviderObj.Commit();
                ((SiarLibrary.Web.Page)Page).ShowMessage("Documento eliminato correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }
        protected void btnNASalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (_progettocomunicazioni.PredispostaAllaFirma || _progettocomunicazioni.Segnatura != null) throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(lstNACategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioniDocumenti d = new SiarLibrary.ProgettoComunicazioniDocumenti();
                d.IdComunicazione = _progettocomunicazioni.Id;
                d.CodTipoDocumento = lstNACategoria.SelectedValue;
                if (!string.IsNullOrEmpty(txtNADescrizioneBreve.Text))
                {
                    SiarLibrary.Note n = new SiarLibrary.Note();
                    n.Testo = txtNADescrizioneBreve.Text;
                    note_provider.Save(n);
                    d.IdNoteComunicazione = n.Id;
                }
                pcdocumenti_provider.Save(d);
                _progettocomunicazioni.Data = DateTime.Now;
                _progettocomunicazioni.Operatore = Operatore.Utente.IdUtente;
                comunicazioni_provider.Save(_progettocomunicazioni);
                comunicazioni_provider.DbProviderObj.Commit();
                ((SiarLibrary.Web.Page)Page).RegisterClientScriptBlock("chiudiPopup();");
                ((SiarLibrary.Web.Page)Page).ShowMessage("Documento aggiunto correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }

        protected void btnPredisponi_Click(object sender, EventArgs e)
        {
            try
            {
                bool predisponi = !_progettocomunicazioni.PredispostaAllaFirma;
                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della presente richiesta.");
                _progettocomunicazioni.PredispostaAllaFirma = predisponi;
                _progettocomunicazioni.Operatore = Operatore.Utente.IdUtente;
                _progettocomunicazioni.Data = DateTime.Now;
                comunicazioni_provider.Save(_progettocomunicazioni);
                string messaggio = "Predisposizione alla firma effettuata correttamente.";
                if (!predisponi) messaggio = "Predisposizione alla firma rimossa correttamente.";
                ((SiarLibrary.Web.Page)Page).ShowMessage(messaggio);
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }
        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
                if (!_progettocomunicazioni.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
                if (_progettocomunicazioni.Segnatura != null) throw new Exception("La richiesta è già stata inviata, impossibile continuare.");
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, _progettocomunicazioni.Id);
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }
        protected void btnFirmaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (!responsabileAbilitato) throw new Exception("La firma della richiesta di documentazione è di spettanza del responsabile provinciale.");
                if (!_progettocomunicazioni.PredispostaAllaFirma) throw new Exception("La richiesta non è ancora stata predisposta alla firma, impossibile continuare.");
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato)) throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                SiarLibrary.Bando bando = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(bando.CodEnte);
                string oggetto;
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(bando.IdBando, Progetto.ProvinciaDiPresentazione);
                if (_progettocomunicazioni.CodTipo.FindValueIn("DNT", "DPT"))
                {
                    protocollo.setCorrispondente(impresa,Progetto.IdProgetto, "destinatario");
                    protocollo.setDocumento("richiesta_documentazione_integrativa_per_" + tipo_richiesta + "_domanda_"
                          + Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                    oggetto = "Richiesta di documentazione integrativa per la richiesta di " + tipo_richiesta + " per la domanda di aiuto nr. " + Progetto.IdProgetto
                        + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                        + bando.DataScadenza + "\n" + ss[3] + "\nPartita iva/Codice fiscale: " + impresa.Cuaa;
                }
                else
                {
                    if (_progettocomunicazioni.IdComune == null) throw new Exception("L'amministrazione destinataria della presente richiesta non è valida, impossibile continuare.");
                    string[] suap = comunicazioni_provider.GetPecSuap(_progettocomunicazioni.IdComune);
                    if (string.IsNullOrEmpty(suap[1])) throw new Exception("Indirizzo Pec non trovato, impossibile continuare.");
                    protocollo.setCorrispondente(_progettocomunicazioni.Ente, null, suap[1], "destinatario");
                    protocollo.setDocumento("richiesta_certificazione_per_" + tipo_richiesta + "_domanda_"
                        + Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                    oggetto = "Richiesta di certificazione all'ente " + _progettocomunicazioni.Ente + " per la domanda di aiuto nr. " + Progetto.IdProgetto
                        + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: "
                        + bando.DataScadenza + "\n" + ss[3] 
                        + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                        + "\n Ragione sociale: " + impresa.RagioneSociale;
                }

                string segnatura = protocollo.ProtocolloUscita(oggetto, ss[4], true);
                try
                {
                    comunicazioni_provider.DbProviderObj.BeginTran();
                    _progettocomunicazioni.Segnatura = segnatura;
                    _progettocomunicazioni.Operatore = Operatore.Utente.IdUtente;
                    _progettocomunicazioni.Data = DateTime.Now;
                    comunicazioni_provider.Save(_progettocomunicazioni);
                    comunicazioni_provider.DbProviderObj.Commit();
                }
                catch (Exception exc)
                {
                    comunicazioni_provider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore nella richiesta di certificazione per il " + tipo_richiesta + " della domanda  n. " + Progetto.IdProgetto;
                    string testEmail = "\nSegnatura documento interno protocollato: " + segnatura +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
                btnFirma.Enabled = false;
                ((SiarLibrary.Web.Page)Page).ShowMessage("Richiesta  firmata e inviata correttamente.");
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }
        protected void btnSalvaRisposta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!istruttoreAbilitato && !responsabileAbilitato) throw new Exception("L'operatore non è abilitato alla modifica della richiesta.");
                if (_progettocomunicazioni.Segnatura == null) throw new Exception("La comunicazione selezionata non è valida.");
                if (string.IsNullOrEmpty(txtSegnaturaRisposta.Text)) throw new Exception("E' necessario specificare la segnatura del protocollo in ingresso.");
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaRisposta.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                if (_tipoComunicazione == "RCC") if (string.IsNullOrEmpty(hdnCodEnteRisposta.Value)) throw new Exception("E` obbligatorio specificare l'amministrazione mittente della documentazione.");
                SiarLibrary.Comuni comune_selezionato = null;
                int id_comune;
                if (lstTipoEnteRisposta.SelectedValue == "CM")
                {
                    if (int.TryParse(hdnCodEnteRisposta.Value, out id_comune)) comune_selezionato = new SiarBLL.ComuniCollectionProvider().GetById(id_comune);
                    if (comune_selezionato == null) throw new Exception("Il comune selezionato non è valido.");
                }

                comunicazioni_provider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazioni pc = new SiarLibrary.ProgettoComunicazioni();
                SiarLibrary.ProgettoComunicazioniCollection cc = comunicazioni_provider.FindComunicazioneRiferimento(_progettocomunicazioni.Id);
                if (cc.Count > 0) pc = cc[0];
                pc.IdProgetto = Progetto.IdProgetto;
                if (DomandaPagamento != null) pc.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                if (Variante != null) pc.IdVariante = Variante.IdVariante;
                pc.CodTipo = "PCC"; // cambiare in base al tipo di comunicazione 
                if (_tipoComunicazione.FindValueIn("DNT", "DPT")) pc.CodTipo = "DPT";
                pc.PredispostaAllaFirma = false;
                pc.Direzione = "A";
                pc.Data = DateTime.Now;
                pc.Operatore = Operatore.Utente.IdUtente;
                pc.IdComunicazioneRiferimento = _progettocomunicazioni.Id;
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
                ((SiarLibrary.Web.Page)Page).ShowMessage("Documentazione in risposta registrata correttamente.");
            }
            catch (Exception ex) { comunicazioni_provider.DbProviderObj.Rollback(); ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }

    }
}