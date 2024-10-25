using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;

namespace web.Private.PDomanda
{
    public partial class Comunicazioni : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.ProgettoComunicazioneCollectionProvider ComunicazioneCollectionProvider = new SiarBLL.ProgettoComunicazioneCollectionProvider();
        SiarBLL.NoteCollectionProvider note_provider = new SiarBLL.NoteCollectionProvider();
        SiarLibrary.ProgettoComunicazioneAllegato allegato_selezionato = null;
        SiarBLL.ProgettoComunicazioneAllegatoCollectionProvider allegati_provider;
        int id_comunicazione;
        SiarLibrary.PersoneXImprese rlegale = null;
        bool isPresentatoreAbilitato = false;
        bool isConsulente = false;
        bool isIstruttoreAssegnato = false;
        bool isRup = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = btnInviaComunicazione_Click;
            allegati_provider = new SiarBLL.ProgettoComunicazioneAllegatoCollectionProvider();
            int id_axp;
            if (int.TryParse(hdnAllegatoSelezionato.Value, out id_axp)) allegato_selezionato = allegati_provider.GetById(id_axp);

            if (Progetto.CodStato == "P")
                Redirect("DatiGenerali.aspx", "La domanda di aiuto selezionata si trova in uno stato per cui non è possibile inviare nessuna comunicazione.", true);

            AbilitaModifica = false;

            SiarBLL.PersoneXImpreseCollectionProvider pxi_provider = new SiarBLL.PersoneXImpreseCollectionProvider();
            SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider rcp_provider = new SiarBLL.RichiestaConsulenteProcuraXBandoCollectionProvider();
            rlegale = pxi_provider.GetById(Azienda.IdRapprlegaleUltimo);
            if (rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
            {
                // controllo se l'operatore è nella compagine aziendale ed è abilitato alla firma
                SiarLibrary.PersoneXImpreseCollection cc = pxi_provider.Find(Operatore.Utente.IdPersonaFisica, null, Azienda.IdImpresa, null, true, true);
                if (cc.Count > 0)
                {
                    isPresentatoreAbilitato = true;
                    AbilitaModifica = true;
                }

                //controllo se l'operatore ha procura speciale per il bando
                SiarLibrary.RichiestaConsulenteProcuraXBandoCollection rcp = rcp_provider.Find(null, null, Azienda.IdImpresa, Operatore.Utente.IdPersonaFisica, Progetto.IdBando, null, null, true, true);
                if (rcp.Count > 0)
                {
                    if (rcp[0].DataInizio < DateTime.Now && rcp[0].DataFine > DateTime.Now)
                    {
                        isPresentatoreAbilitato = true;
                        AbilitaModifica = true;
                    }
                }
            }
            else
            {
                isPresentatoreAbilitato = true;
                AbilitaModifica = true;
            }

            SiarLibrary.CollaboratoriXBandoCollection collaboratore = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, Progetto.IdProgetto, null, null, true);
            if (collaboratore.Count > 0)
            {
                foreach (SiarLibrary.CollaboratoriXBando c in collaboratore)
                {
                    if (collaboratore[0].IdUtente == Operatore.Utente.IdUtente)
                    {
                        isIstruttoreAssegnato = true;
                        AbilitaModifica = true;
                    }
                }
            }

            SiarLibrary.BandoResponsabiliCollection responsabili = new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, null, null, true, true);
            if (responsabili.Count > 0)
            {
                if (responsabili[0].IdUtente == Operatore.Utente.IdUtente)
                {
                    isRup = true;
                    AbilitaModifica = true;
                }
            }

            SiarLibrary.MandatiImpresaCollection consulenti = new SiarBLL.MandatiImpresaCollectionProvider().Find(Progetto.IdImpresa, null, null, null, Operatore.Utente.IdUtente, null, null, null, true);
            if (consulenti.Count > 0)
            {
                isConsulente = true;
                AbilitaModifica = true;
            }

            if ((isIstruttoreAssegnato && ! chkSegnaturaEsterna.Checked) || isConsulente)
                btnPredisponiFirma.Enabled = true;
            else
                btnPredisponiFirma.Enabled = false;
        }

        protected void PopolaCampi()
        {
            if((isPresentatoreAbilitato || isConsulente) && (isIstruttoreAssegnato || isRup))
            {
                if(Operatore.Utente.Profilo == "Consulente" || Operatore.Utente.Profilo == "Utente singolo")
                {
                    cmbSelTipoComunicazione.inEntrata = true;
                    trAutocerticazioneFlag.Visible = true;
                    trIsSegnaturaEsterna.Visible = false;
                }
                else 
                {
                    cmbSelTipoComunicazione.inUscita = true;
                    trAutocerticazioneFlag.Visible = false;
                    trIsSegnaturaEsterna.Visible = true;
                }
            }
            else if (isPresentatoreAbilitato || isConsulente)
            {
                cmbSelTipoComunicazione.inEntrata = true;
                trAutocerticazioneFlag.Visible = true;
                trIsSegnaturaEsterna.Visible = false;
            }
            else if (isIstruttoreAssegnato || isRup)
            {
                cmbSelTipoComunicazione.inUscita = true;
                trAutocerticazioneFlag.Visible = false;
                trIsSegnaturaEsterna.Visible = true;
            }
            cmbSelTipoComunicazione.DataBind();
            if (!string.IsNullOrEmpty(hdnIdComunicazioneRiferimento.Value))
            {
                rowRisposta.Visible = true;
                SiarLibrary.ProgettoComunicazione pc = ComunicazioneCollectionProvider.GetById(hdnIdComunicazioneRiferimento.Value);
                lblRisposta.Text = " " + pc.Descrizione + " - " + pc.Oggetto;
            }
            else
            {
                rowRisposta.Visible = false;
                lblRisposta.Text = string.Empty;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    PopolaCampi();
                    tbNuovaComunicazione.Visible = true;
                    if (!string.IsNullOrEmpty(hdnIdComunicazione.Value))
                    {
                        int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);

                        tbFile.Visible = true;

                        SiarLibrary.ProgettoComunicazione comunicazione = ComunicazioneCollectionProvider.GetById(id_comunicazione);
                        if (comunicazione != null)
                        {
                            cmbSelTipoComunicazione.SelectedValue = comunicazione.CodTipo;
                            txtTesto.Text = comunicazione.Testo;
                            txtOggetto.Text = comunicazione.Oggetto;
                            if (comunicazione.SegnaturaEsterna != null && comunicazione.SegnaturaEsterna)
                            {
                                chkSegnaturaEsterna.Checked = true;
                                trSegnaturaEsterna.Visible = true;
                                txtSegnatura.Text = comunicazione.Segnatura;
                            }
                            if (comunicazione.IdNote != null)
                            {
                                SiarLibrary.Note n = note_provider.GetById(comunicazione.IdNote);
                                txtNote.Text = n.Testo;
                            }

                            if (comunicazione.IdComunicazioneRef != null)
                                hdnIdComunicazioneRiferimento.Value = comunicazione.IdComunicazioneRef;


                            if (comunicazione.PredispostaAllaFirma != null && comunicazione.PredispostaAllaFirma)
                            {
                                btnPredisponiFirma.Text = "Togli predisposizione alla firma";
                                btnPredisponiFirma.Width = 200;
                            }
                            else
                                btnPredisponiFirma.Text = "Predisponi alla firma";

                            if (((isIstruttoreAssegnato && !chkSegnaturaEsterna.Checked) || isConsulente) && !isRup && !isPresentatoreAbilitato)
                            {
                                btnInviaComunicazione.Enabled = false;

                                if (comunicazione.PredispostaAllaFirma != null && comunicazione.PredispostaAllaFirma)
                                {
                                    btnSalvaComunicazione.Enabled = false;
                                    btnEliminaComunicazione.Enabled = false;
                                    btnSalvaAllegato.Enabled = false;
                                    btnElimina.Enabled = false;
                                }
                                else
                                {
                                    btnSalvaComunicazione.Enabled = true;
                                    btnEliminaComunicazione.Enabled = true;
                                    btnSalvaAllegato.Enabled = true;
                                    btnElimina.Enabled = true;
                                }
                            }

                        }

                        SiarLibrary.ProgettoComunicazioneAllegatoCollection allegati_domanda = allegati_provider.Find(hdnIdComunicazione.Value, Progetto.IdProgetto, null);
                        dgAllegatiComunicazioni.DataSource = allegati_domanda;
                        dgAllegatiComunicazioni.Titolo = "Elementi trovati: " + allegati_domanda.Count;
                        dgAllegatiComunicazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAllegatiComunicazioni_ItemDataBound);
                        dgAllegatiComunicazioni.DataBind();

                        if (!string.IsNullOrEmpty(comunicazione.Segnatura))
                        {
                            SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(null, null, null, null, comunicazione.IdComunicazione, null, null, null);
                            int numeroAllegati = allegati.Count;

                            //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, comunicazione.Segnatura); 
                            //int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);
                            bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Comunicazione, id_comunicazione, comunicazione.Segnatura);

                            if (!allegatiProtocollatiOk)
                            {
                                rowProtocolliAllegati.Visible = true;
                                btnProtocollaAllegati.Enabled = comunicazione.Operatore == Operatore.Utente.IdUtente || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica;
                            }
                            else
                            {
                                rowProtocolliAllegati.Visible = false;
                                btnProtocollaAllegati.Enabled = false;
                            }

                            btnSalvaAllegato.Enabled = false;
                            btnElimina.Enabled = false;
                            btnSalvaComunicazione.Enabled = false;
                            btnEliminaComunicazione.Visible = true;
                            btnInviaComunicazione.Enabled = false;
                        }
                    }
                    else
                    {
                        tbFile.Visible = false;
                        btnEliminaComunicazione.Visible = false;
                    }
                    mostraSegnatura();
                    if (allegato_selezionato != null)
                    {
                        txtNADescrizioneBreve.Text = allegato_selezionato.Descrizione;
                        ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
                    }
                    break;
                default:
                    hdnIdComunicazione.Value = "";
                    tbComunicazioni.Visible = true;
                    SiarLibrary.ProgettoComunicazioneCollection comunicazioni = ComunicazioneCollectionProvider.GetComunicazioniOrdinate(Progetto.IdProgetto);
                    dgComunicazioni.DataSource = comunicazioni;
                    dgComunicazioni.ItemDataBound += new DataGridItemEventHandler(dgComunicazioni_ItemDataBound);
                    if (comunicazioni.Count == 0) dgComunicazioni.Titolo = "&nbsp;&nbsp;&nbsp;<em><b>Nessuna comunicazione effettuata.</b></em>";
                    dgComunicazioni.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }

        void dgComunicazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.ProgettoComunicazione c = (SiarLibrary.ProgettoComunicazione)dgi.DataItem;
                e.Item.Cells[5].Text = new SiarBLL.UtentiCollectionProvider().GetById(c.Operatore).Nominativo;
                if (c.IdComunicazioneRef != null)
                {
                    e.Item.CssClass = "collapse-" + c.IdComunicazioneRef + "-" + c.IdComunicazione + " DataGridRow";
                    e.Item.Cells[1].Text = "<img title='Visualizza le risposte' class='" + "btn-collapse-" + c.IdComunicazioneRef + "-" + c.IdComunicazione + "' src='../../images/Arrow-down-Right-icon.png'>";
                }
                else
                {
                    e.Item.Cells[1].Text = "<img title='Visualizza le risposte' class='" + "root-" + c.IdComunicazione + "' src='../../images/Down_Arrow_Icon.png'>";
                }

                if (c.Segnatura != null)
                    e.Item.Cells[6].Text = "<input type=button class='btn btn-secondary py-1' value='" + c.Segnatura + "' style='width:370px' onclick=\"sncAjaxCallVisualizzaProtocollo('" + c.Segnatura + "')\" />";
                else
                    e.Item.Cells[6].Text = "comunicazione non ancora inviata";
                if (c.InEntrata)
                    e.Item.Cells[7].Text = "<img title='Messaggio in entrata' class='message-icon' src='../../images/inbox-icon.png'>";
                else
                    e.Item.Cells[7].Text = "<img title='Messaggio in uscita' class='message-icon' src='../../images/outbox-icon.png'>";
                if (isPresentatoreAbilitato || isIstruttoreAssegnato || isRup || isConsulente)
                {
                    //bool documentiVarianteOk = checkAllegatiProtocollatiComunicazione(c);
                    bool documentiVarianteOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Comunicazione, c.IdComunicazione, c.Segnatura);

                    if (c.InEntrata)
                    {
                        if (c.Segnatura != null && (c.SegnaturaEsterna || (isIstruttoreAssegnato || isRup)) && !isConsulente && documentiVarianteOk)
                            e.Item.Cells[8].Text = "<input type=button class=ButtonGrid value='Rispondi' style='width:130px' onclick=\"rispondiComunicazione(" + c.IdComunicazione + ")\" />";
                        else if (c.Segnatura != null && (c.Operatore == Operatore.Utente.IdUtente || isConsulente || isPresentatoreAbilitato) && !documentiVarianteOk)
                            e.Item.Cells[9].Text = "<input type=button class=ButtonGrid value='Protocolla allegati' style='width:130px' onclick=\"selezionaComunicazione(" + c.IdComunicazione + ")\" />";
                        else if (c.Segnatura == null && (c.Operatore == Operatore.Utente.IdUtente || isConsulente || isPresentatoreAbilitato))
                            e.Item.Cells[9].Text = "<input type=button class=ButtonGrid value='Seleziona' style='width:130px' onclick=\"selezionaComunicazione(" + c.IdComunicazione + ")\" />";
                    }
                    else
                    {
                        if (c.Segnatura != null && (c.Operatore != Operatore.Utente.IdUtente || isConsulente) && !isRup && !isIstruttoreAssegnato && documentiVarianteOk)
                            e.Item.Cells[8].Text = "<input type=button class=ButtonGrid value='Rispondi' style='width:130px' onclick=\"rispondiComunicazione(" + c.IdComunicazione + ")\" />";
                        else if (c.Segnatura != null && (isRup || isIstruttoreAssegnato) && !documentiVarianteOk)
                            e.Item.Cells[9].Text = "<input type=button class=ButtonGrid value='Protocolla allegati' style='width:130px' onclick=\"selezionaComunicazione(" + c.IdComunicazione + ")\" />";
                        else if (c.Segnatura == null && (isRup || isIstruttoreAssegnato))
                            e.Item.Cells[9].Text = "<input type=button class=ButtonGrid value='Seleziona' style='width:130px' onclick=\"selezionaComunicazione(" + c.IdComunicazione + ")\" />";
                        if (c.CodTipo == "PAR" && c.Segnatura != null)
                        {
                            SiarLibrary.ProgettoComunicazioneAllegato a = new SiarBLL.ProgettoComunicazioneAllegatoCollectionProvider().Find(c.IdComunicazione, c.IdProgetto, null)[0];
                            e.Item.Cells[9].Text = "<input type=button class=ButtonGrid value='Visualizza allegato' style='width:130px' onclick=\"SNCUFVisualizzaFile(" + a.IdFile + ", this)\" />";
                        }
                    }
                }
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            ucSiarNewTab.TabSelected = 2;
            if (!int.TryParse(hdnIdComunicazione.Value, out id_comunicazione)) ShowError("La comunicazione selezionata non è valida. Impossibile continuare.");
        }

        protected void btnPostRispondi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(hdnIdComunicazioneRiferimento.Value))
                {
                    SiarLibrary.ProgettoComunicazione pc = ComunicazioneCollectionProvider.GetById(hdnIdComunicazioneRiferimento.Value);
                    if (pc.Operatore == Operatore.Utente.IdUtente) throw new SiarLibrary.SiarException("Un operatore non può rispodondere ad una comunicazione che è stata creata da lui stesso, impossibile continuare.");
                }
                ucSiarNewTab.TabSelected = 2;
                if (!int.TryParse(hdnIdComunicazioneRiferimento.Value, out id_comunicazione)) throw new SiarLibrary.SiarException("La comunicazione selezionata non è valida. Impossibile rispondere.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null)
                    allegato_selezionato = new SiarLibrary.ProgettoComunicazioneAllegato();
                if (ufcNAAllegato.IdFile == null) throw new Exception("Nessun allegato inserito. Impossibile continuare.");
                allegato_selezionato.Descrizione = txtNADescrizioneBreve.Text;
                allegato_selezionato.IdComunicazione = hdnIdComunicazione.Value;
                allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                allegato_selezionato.IdProgetto = Progetto.IdProgetto;
                allegati_provider.Save(allegato_selezionato);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPredisponiFirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdnIdComunicazione.Value)) throw new Exception("Comunicazione non valida, impossibile continuare.");
            SiarLibrary.ProgettoComunicazione comunicazione = ComunicazioneCollectionProvider.GetById(hdnIdComunicazione.Value);

            try
            {
                ComunicazioneCollectionProvider.DbProviderObj.BeginTran();
                string message;
                if (comunicazione.PredispostaAllaFirma == null || (comunicazione.PredispostaAllaFirma != null && !comunicazione.PredispostaAllaFirma))
                {
                    comunicazione.PredispostaAllaFirma = true;
                    message = "Comunicazione correttamente predisposta alla firma";

                    if (isIstruttoreAssegnato && !isRup)
                    {
                        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
                        System.Collections.ArrayList destinatari = new System.Collections.ArrayList();
                        foreach (SiarLibrary.BandoResponsabili r in new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                        {
                            SiarLibrary.Utenti u = utenti_provider.GetById(r.IdUtente);
                            if (u != null && u.Email != null) destinatari.Add(u.Email.Value);
                        }
                        if (destinatari.Count > 0)
                        {

                            SiarLibrary.Email em = new SiarLibrary.Email("Avviso di inoltro alla Firma della comunicazione con oggetto"
                            + comunicazione.Oggetto + " (Progetto: " + Progetto.IdProgetto + ")",
                                "<html><body>Si comunica che l'istruttore " + Operatore.Utente.Nominativo + "<br />ha predisposto alla sua firma, come Responsabile del Bando, la comunicazione con oggetto" + comunicazione.Oggetto
                            + " per il Progetto ID: " + Progetto.IdProgetto + "."
                            + "<br /><ul><li style='width:650px'>Bando: " + Bando.Descrizione + "</li><li>Scadenza: " + Bando.DataScadenza + "</li><br />"
                            + "<li>CF/P.Ia: " + Azienda.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                            + Azienda.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                            + "<br />Tale istanza è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                            + "/private/pdomanda/comunicazioni.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                            + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                            + "<br />Si prega di non rispondere a questa email.</body></html>");
                            em.SetHtmlBodyMessage(true);
                            em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                        }
                    }
                }
                else
                {
                    comunicazione.PredispostaAllaFirma = false;
                    message = "Predisposizione alla firma annullata per la comunicazione";
                }
                ComunicazioneCollectionProvider.Save(comunicazione);
                ComunicazioneCollectionProvider.DbProviderObj.Commit();
                ShowMessage(message);

            }
            catch (Exception ex)
            {
                ShowError(ex);
                ComunicazioneCollectionProvider.DbProviderObj.Rollback();
            }

        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkSegnaturaEsterna.Checked)
                {
                    Session["evita_controllo_date_sessione"] = "true";
                    //ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Progetto.IdProgetto);
                    SiarLibrary.ModelloDomandaCollection cc = new SiarBLL.ModelloDomandaCollectionProvider().Find(null, Progetto.IdBando, null);

                    if (isPresentatoreAbilitato)
                    {
                        ucFirmaDocumento.TipoDocumento = "COMUNICAZIONE_GENERICA_BENEFICIARIO";
                    }
                    else if (isIstruttoreAssegnato || isRup)
                    {
                        ucFirmaDocumento.TipoDocumento = "COMUNICAZIONE_GENERICA";
                    }

                    ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, hdnIdComunicazione.Value, Progetto.IdProgetto, chkAutocertificazone.Checked.ToString());
                }
                else
                {
                    inviaComunicazione();
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void verificaSegnatura()
        {
            try
            {
                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(txtSegnatura.Text)) throw new Exception("Non è stata inserita alcuna Segnatura. Impossibile continuare.");
                //SiarLibrary.Protocollo richiesta = new SiarLibrary.Protocollo();
                //byte[] doc = richiesta.RicercaProtocollo(txtSegnatura.Text, true);
                if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                ShowMessage("La segnatura risulta corretta.");
            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                verificaSegnatura();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void inviaComunicazione()
        {
            try
            {
                if (string.IsNullOrEmpty(hdnIdComunicazione.Value)) throw new Exception("Comunicazione non valida, impossibile continuare.");
                SiarLibrary.ProgettoComunicazione comunicazione = ComunicazioneCollectionProvider.GetById(hdnIdComunicazione.Value);

                if (comunicazione.CodTipo == "RAT")
                {
                    SiarLibrary.ProgettoValutazioneCollection valutazioni = new SiarBLL.ProgettoValutazioneCollectionProvider().Find(comunicazione.IdProgetto, null, true, null, false);
                    if (valutazioni == null || valutazioni.Count == 0 || valutazioni[0].Segnatura == null)
                        throw new Exception("Nessuna valutazione per il progetto selezionato.");
                }

                // carico gli allegati su paleo
                SiarLibrary.ArchivioFileCollection ff = ComunicazioneCollectionProvider.GetFileXProtocollazioneNoStream(comunicazione.IdComunicazione, Progetto.IdProgetto);
                int numeroAllegati = 0;
                SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
                foreach (SiarLibrary.ArchivioFile f in ff)
                {
                    try
                    {
                        //protocollo.addAllegato(f.NomeFile + "." + f.Tipo, f.Contenuto, f.Tipo);
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                        all.Descrizione = f.NomeCompleto;
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = f.NomeFile;

                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", f.Id);
                        allegatoProtocollo.Add("tipo_origine", "comunicazione");
                        allegatoProtocollo.Add("id_origine", comunicazione.IdComunicazione);
                        allegatiProtocollo.Add(allegatoProtocollo);

                        SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(null, null, null, null, comunicazione.IdComunicazione, f.Id, null, null);
                        if (exist.Count == 0)
                        {
                            SiarLibrary.AllegatiProtocollati ap = new SiarLibrary.AllegatiProtocollati();
                            ap.IdVariante = DBNull.Value;
                            ap.IdProgetto = DBNull.Value;
                            ap.IdComunicazione = comunicazione.IdComunicazione;
                            ap.IdIntegrazione = DBNull.Value;
                            ap.IdFile = f.Id;
                            ap.Protocollato = false;
                            allegatiProtocollatiProvider.Save(ap);
                            numeroAllegati++;
                        }
                    }
                    catch (Exception ex) { }
                }

                string identificativo_paleo = "";

                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(Bando.CodEnte);

                //aggiungo nome e hash del file per impronta


                SiarLibrary.Impresa i = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);

                if (!chkSegnaturaEsterna.Checked)
                {
                    if (isPresentatoreAbilitato)
                        protocollo.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                    else if (isIstruttoreAssegnato || isRup)
                        protocollo.setCorrispondente(i, Progetto.IdProgetto, "destinatario");

                    protocollo.setDocumento("comunicazione_progetto_" + Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, Progetto.ProvinciaDiPresentazione);
                    string oggetto = "COMUNICAZIONI per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita IVA: " + i.Cuaa 
                        + "\n Ragione sociale: " + i.RagioneSociale
                        + "\n N° Domanda SIGEF: " + Progetto.IdProgetto;

                    foreach (SiarLibrary.ArchivioFile f in ff)
                    {
                        try
                        {
                            protocollo.addAllegato(f.NomeFile, f.HashCode);
                        }
                        catch (Exception ex) { }
                    }

                    if (isPresentatoreAbilitato)
                        identificativo_paleo = protocollo.ProtocolloIngresso(oggetto, ss[4]);
                    else if (isIstruttoreAssegnato || isRup)
                        identificativo_paleo = protocollo.ProtocolloUscita(oggetto, ss[4], false);


                }
                else
                {
                    verificaSegnatura();
                    identificativo_paleo = txtSegnatura.Text;
                }

                ComunicazioneCollectionProvider.DbProviderObj.BeginTran();

                comunicazione.CodTipo = cmbSelTipoComunicazione.SelectedValue;
                comunicazione.DataInserimento = DateTime.Now;
                int idComunicazioneRef = 0;
                if (!string.IsNullOrEmpty(hdnIdComunicazioneRiferimento.Value))
                {
                    int.TryParse(hdnIdComunicazioneRiferimento.Value, out idComunicazioneRef);
                    comunicazione.IdComunicazioneRef = idComunicazioneRef;
                }
                else
                    comunicazione.IdComunicazioneRef = DBNull.Value;
                comunicazione.IdProgetto = Progetto.IdProgetto;
                comunicazione.InEntrata = isPresentatoreAbilitato || chkSegnaturaEsterna.Checked;
                comunicazione.Operatore = Operatore.Utente.IdUtente;
                comunicazione.Segnatura = identificativo_paleo;

                comunicazione.SegnaturaEsterna = chkSegnaturaEsterna.Checked;
                comunicazione.Segnatura = identificativo_paleo;

                comunicazione.Oggetto = txtOggetto.Text;
                comunicazione.Testo = txtTesto.Text;

                if (string.IsNullOrEmpty(txtNote.Text)) comunicazione.IdNote = DBNull.Value;
                else
                {
                    SiarLibrary.Note n = new SiarLibrary.Note();
                    n.Testo = txtNote.Text;
                    note_provider.Save(n);
                    comunicazione.IdNote = n.Id;
                }

                ComunicazioneCollectionProvider.Save(comunicazione);
                ComunicazioneCollectionProvider.DbProviderObj.Commit();

                try
                {
                    // invio la notifica del rilascio al responsabile del bando         
                    SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
                    System.Collections.ArrayList destinatari = new System.Collections.ArrayList();
                    foreach (SiarLibrary.BandoResponsabili r in new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                    {
                        SiarLibrary.Utenti u = utenti_provider.GetById(r.IdUtente);
                        if (u != null && u.Email != null)
                            destinatari.Add(u.Email.Value);
                    }

                    // invio la notifica del rilascio all'istruttore del progetto se non è rup  
                    foreach (SiarLibrary.CollaboratoriXBando istr in new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, Progetto.IdProgetto, null, null, true))
                    {
                        if (new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, istr.IdUtente, null, true, true).Count == 0)
                        {
                            SiarLibrary.Utenti u = utenti_provider.GetById(istr.IdUtente);
                            if (u != null && u.Email != null)
                                destinatari.Add(u.Email.Value);
                        }
                    }

                    if (destinatari.Count > 0)
                    {
                        SiarBLL.BandoCollectionProvider bandoProvider = new SiarBLL.BandoCollectionProvider();
                        SiarLibrary.Bando b = bandoProvider.GetById(Progetto.IdBando);
                        SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione Comunicazione di " + comunicazione.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                            "<html><body>Si comunica che con prot. " + identificativo_paleo + "<br />è stata presentata la Comunicazione di " + comunicazione.Descrizione
                        + " per il Progetto ID: " + Progetto.IdProgetto + "."
                        + "<br /><ul><li style='width:650px'>Bando: " + b.Descrizione + "</li><li>Scadenza: " + b.DataScadenza + "</li><br />"
                        + "<li>CF/P.Iva: " + i.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                        + i.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                        + "<br />Tale comunicazione è consultabile all'indirizzo <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "' target=_blank>Clicca qui</a> ricercando la domanda nella sezione Ricerca e navigando nella sezione comunicazione"
                        + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                        + "<br />Si prega di non rispondere a questa email.</body></html>");
                        em.SetHtmlBodyMessage(true);
                        em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                    }
                }
                catch (Exception exy) { ShowError(exy.ToString()); }

                protocollo.addAllegatiProtocollo(allegatiProtocollo, identificativo_paleo);

                //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, identificativo_paleo); 
                //int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);
                bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Comunicazione, id_comunicazione, identificativo_paleo);

                if (allegatiProtocollatiOk)
                {
                    ShowMessage("Comunicazione inviata correttamente.");

                    bool Organismi_intermedi = false;
                    bool OrganismoConPec = false;

                    string Str_Organismi_intermedi = "";
                    Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Bando.IdBando);
                    if (Str_Organismi_intermedi == "True")
                        Organismi_intermedi = true;

                    string Str_Organismi_intermedi_pec = "";
                    Str_Organismi_intermedi_pec = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermediPec(Bando.IdBando);
                    if (Str_Organismi_intermedi_pec == "True")
                        OrganismoConPec = true;

                    if (OrganismoConPec && !chkSegnaturaEsterna.Checked)
                        protocollo.SpedisciViaPec(identificativo_paleo);
                    else
                    {
                        if (!Organismi_intermedi && !chkSegnaturaEsterna.Checked)
                            protocollo.SpedisciViaPec(identificativo_paleo);
                        else
                        {
                            try
                            {
                                // invio la notifica del rilascio all'email della sede legale dell'azienda   
                                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                                SiarLibrary.Indirizzario indirizzarioImpresaSedeLegaleUltimo = new SiarBLL.IndirizzarioCollectionProvider().GetById(impresa.IdSedelegaleUltimo);

                                if (indirizzarioImpresaSedeLegaleUltimo != null && indirizzarioImpresaSedeLegaleUltimo.Email != null)
                                {
                                    SiarBLL.BandoCollectionProvider bandoProvider = new SiarBLL.BandoCollectionProvider();
                                    SiarLibrary.Bando b = bandoProvider.GetById(Progetto.IdBando);
                                    SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione Comunicazione di " + comunicazione.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                                        "<html><body>Si comunica che con prot. " + identificativo_paleo + "<br />è stata ricevuta la Comunicazione di " + comunicazione.Descrizione
                                    + " per il Progetto ID: " + Progetto.IdProgetto + "."
                                    + "<br /><ul><li style='width:650px'>Bando: " + b.Descrizione + "</li><li>Scadenza: " + b.DataScadenza + "</li><br />"
                                    + "<li>CF/P.Iva: " + i.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                                    + i.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                                    + "<br />Tale comunicazione è consultabile all'indirizzo <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "' target=_blank>Clicca qui</a> ricercando la propria domanda nella sezione Ricerca e navigando nella sezione comunicazione"
                                    + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                    + "<br />Si prega di non rispondere a questa email.</body></html>");
                                    em.SetHtmlBodyMessage(true);

                                    em.SendNotification(indirizzarioImpresaSedeLegaleUltimo.Email, new string[] { });
                                }
                            }
                            catch (Exception exy)
                            {
                                ShowError(exy.ToString());
                            }
                        }
                    }
                }
                else ShowError("Comunicazione presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

            }
            catch (Exception ex)
            {
                ShowError(ex);
                ComunicazioneCollectionProvider.DbProviderObj.Rollback();
            }
        }

        protected void btnInviaComunicazione_Click(object sender, EventArgs e)
        {
            inviaComunicazione();
        }

        protected void ucSiarNewTab_TabClicked()
        {
            hdnIdComunicazione.Value = "";
        }

        protected void btnSalvaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (chkSegnaturaEsterna.Checked)
                {
                    //SiarLibrary.Protocollo richiesta = new SiarLibrary.Protocollo();
                    //byte[] doc = richiesta.RicercaProtocollo(txtSegnatura.Text, true);                    
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }
                ComunicazioneCollectionProvider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazione comunicazione = new SiarLibrary.ProgettoComunicazione();

                if (!string.IsNullOrEmpty(hdnIdComunicazione.Value))
                    comunicazione = ComunicazioneCollectionProvider.GetById(hdnIdComunicazione.Value);

                comunicazione.CodTipo = cmbSelTipoComunicazione.SelectedValue;
                int idComunicazioneRef = 0;
                if (!string.IsNullOrEmpty(hdnIdComunicazioneRiferimento.Value))
                {
                    int.TryParse(hdnIdComunicazioneRiferimento.Value, out idComunicazioneRef);
                    comunicazione.IdComunicazioneRef = idComunicazioneRef;
                }
                else
                    comunicazione.IdComunicazioneRef = DBNull.Value;

                comunicazione.IdProgetto = Progetto.IdProgetto;
                comunicazione.InEntrata = isPresentatoreAbilitato || isConsulente;
                comunicazione.Operatore = Operatore.Utente.IdUtente;
                comunicazione.PredispostaAllaFirma = false;

                comunicazione.Testo = txtTesto.Text;
                comunicazione.Oggetto = txtOggetto.Text;

                if (string.IsNullOrEmpty(txtNote.Text)) comunicazione.IdNote = DBNull.Value;
                else
                {
                    SiarLibrary.Note n = new SiarLibrary.Note();
                    n.Testo = txtNote.Text;
                    note_provider.Save(n);
                    comunicazione.IdNote = n.Id;
                }

                ComunicazioneCollectionProvider.Save(comunicazione);
                ComunicazioneCollectionProvider.DbProviderObj.Commit();
                hdnIdComunicazione.Value = comunicazione.IdComunicazione;
                ShowMessage("Comunicazione salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnEliminaComunicazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                ComunicazioneCollectionProvider.DbProviderObj.BeginTran();
                SiarLibrary.ProgettoComunicazione comunicazione = new SiarLibrary.ProgettoComunicazione();

                if (!string.IsNullOrEmpty(hdnIdComunicazione.Value))
                    comunicazione = ComunicazioneCollectionProvider.GetById(hdnIdComunicazione.Value);

                SiarBLL.ArchivioFileCollectionProvider archivio_file_provider = new SiarBLL.ArchivioFileCollectionProvider();
                SiarLibrary.ProgettoComunicazioneAllegatoCollection allegati_domanda = allegati_provider.Find(hdnIdComunicazione.Value, Progetto.IdProgetto, null);
                SiarLibrary.ArchivioFile archivio_file_obj = new SiarLibrary.ArchivioFile();

                foreach (SiarLibrary.ProgettoComunicazioneAllegato pca in allegati_domanda)
                {
                    archivio_file_obj = archivio_file_provider.GetById(pca.IdFile);
                    archivio_file_provider.Delete(archivio_file_obj);
                    allegati_provider.Delete(pca);
                }

                if (comunicazione.IdNote != DBNull.Value)
                {
                    SiarLibrary.Note Nota = new SiarLibrary.Note();
                    Nota = note_provider.GetById(comunicazione.IdNote);
                    note_provider.Delete(Nota);
                }

                ComunicazioneCollectionProvider.Delete(comunicazione);
                ComunicazioneCollectionProvider.DbProviderObj.Commit();
                cmbSelTipoComunicazione.SelectedIndex = -1;
                chkAutocertificazone.Checked = false;
                txtTesto.Text = "";
                txtOggetto.Text = "";
                txtSegnatura.Text = "";
                txtNote.Text = "";
                hdnIdComunicazioneRiferimento.Value = "";
                hdnIdComunicazione.Value = "";
                ShowMessage("Comunicazione Eliminata.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        void dgAllegatiComunicazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoComunicazioneAllegato a = (SiarLibrary.ProgettoComunicazioneAllegato)e.Item.DataItem;
                if (a.IdFile == null) e.Item.Cells[2].Text = "";
            }
        }

        protected void btnMostraSegnaturaPost_Click(object sender, EventArgs e)
        {
            mostraSegnatura();
        }

        public void mostraSegnatura()
        {
            // se mostro una segnatura esterna tolgo la predisposizione alla firma in ogni caso
            if (chkSegnaturaEsterna.Checked)
                trSegnaturaEsterna.Visible = true;
            else
            {
                trSegnaturaEsterna.Visible = false;
                txtSegnatura.Text = string.Empty;
            }
        }

        protected void btnDettaglioAllegatoPost_Click(object sender, EventArgs e) { }

        protected void btnViewProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo(Bando.CodEnte);
                byte[] report = doc.RicercaProtocollo(hdnSegnatura.Text, true);
                Session["doc"] = report;
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegato.IdFile = null;
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null || allegato_selezionato.IdProgetto != Progetto.IdProgetto) throw new Exception("L'allegato selezionato non è valido.");
                allegati_provider.Delete(allegato_selezionato);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);

            SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);
            System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
            // cerco gli allegati non protocollati
            SiarBLL.ArchivioFileCollectionProvider ff = new SiarBLL.ArchivioFileCollectionProvider();
            SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
            SiarLibrary.AllegatiProtocollatiCollection apc = allegatiProtocollatiProvider.Find(null, null, null, null, id_comunicazione, null, false, null);
            foreach (SiarLibrary.AllegatiProtocollati a in apc)
            {
                SiarLibrary.ArchivioFile f = ff.GetById(a.IdFile);
                //protocollo.addAllegato(f.NomeFile + "." + f.Tipo, f.Contenuto, f.Tipo);
                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                all.Descrizione = f.NomeFile;
                all.Documento = new SiarBLL.paleoWebService.File();
                all.Documento.NomeFile = f.NomeFile;

                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                allegatoProtocollo.Add("allegato", all);
                allegatoProtocollo.Add("id_file", f.Id);
                allegatoProtocollo.Add("tipo_origine", "comunicazione");
                allegatoProtocollo.Add("id_origine", id_comunicazione);
                allegatiProtocollo.Add(allegatoProtocollo);
            }

            string segnatura = ComunicazioneCollectionProvider.GetById(id_comunicazione).Segnatura;

            protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

            //SiarLibrary.AllegatiProtocollatiCollection allegatiDomanda = allegatiProtocollatiProvider.Find(null, null, null, null, id_comunicazione, null, null, null);

            //bool allegatiProtocollatiOk = checkAllegatiProtocollati(allegatiDomanda.Count, segnatura);
            //int.TryParse(hdnIdComunicazione.Value, out id_comunicazione);
            bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Comunicazione, id_comunicazione, segnatura);

            if (allegatiProtocollatiOk) 
                ShowMessage("Comunicazione firmata e protocollata correttamente.");
            else 
                ShowError("Comunicazione presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

        }
    }
}
