using SiarBLL;
using SiarLibrary;
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class ChecklistAmmissibilita : SiarLibrary.Web.IstruttoriaPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        SiarBLL.ProgettoStoricoCollectionProvider storico_provider = new SiarBLL.ProgettoStoricoCollectionProvider();
        SiarBLL.BandoResponsabiliCollectionProvider responsabili_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
        SiarBLL.ProgettoValutazioneCollectionProvider valutazione_provider = new SiarBLL.ProgettoValutazioneCollectionProvider();
        SiarBLL.ProgettoAllegatiIstruttoriaCollectionProvider allegati_provider = new SiarBLL.ProgettoAllegatiIstruttoriaCollectionProvider();
        SiarLibrary.ProgettoAllegatiIstruttoria allegato_selezionato = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiarLibrary.Progetto p = null;
            int id_progetto;
            if (int.TryParse(Request.QueryString["iddom"], out id_progetto))
            {
                p = progetto_provider.GetById(id_progetto);
                Session["_progetto"] = p;
            }
            if (p == null || ((p.IdProgIntegrato != null && p.IdProgIntegrato != p.IdProgetto)))
                Redirect("Ammissibilita.aspx", "La domanda di aiuto selezionata non è valida.", true);
            else
            {
                ucChecklist.Progetto = ucInfoDomanda.Progetto = p;
                controlloOperatoreStatoProgetto();
                //ucTooltip.Codice = "idomanda_ammissibilita_idb" + Bando.IdBando;
                ucFirmaAmmissibilita.DocumentoFirmatoEvent = btnProtocolla_Click;
                ucVisure.Progetto = p;
                ProcureSpeciali.Progetto = p;
            }
            int id_axp;
            if (int.TryParse(hdnIdProgettoAllegatiIstruttoria.Value, out id_axp)) allegato_selezionato = allegati_provider.GetById(id_axp);
        }

        private void controlloOperatoreStatoProgetto()
        {
            AbilitaModifica = AbilitaModifica && (ucInfoDomanda.Progetto.CodStato == "I" || ucInfoDomanda.DomandaInRiesame ||
                ucInfoDomanda.DomandaInRevisione || ucInfoDomanda.DomandaInRicorso || ucInfoDomanda.DomandaInIstruttoriaProvinciale);
            var collaboratore = new CollaboratoriXBandoCollectionProvider().
                Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto, null, null, true);
            if (collaboratore.Count > 0)
            {
                txtIstruttore.Text = collaboratore[0].Nominativo;
                if (collaboratore[0].IdUtente != Operatore.Utente.IdUtente) 
                    AbilitaModifica = false;
            }
            else { txtIstruttore.Text = "Nessun istruttore assegnato."; AbilitaModifica = false; }
            // controllo il responsabile del bando e provinciale
            SiarLibrary.BandoResponsabiliCollection responsabili = responsabili_provider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
            if (responsabili.FiltroProvincia(ucChecklist.Progetto.ProvinciaDiPresentazione, null).Count > 0 || responsabili.FiltroProvincia(null, true).Count > 0)
                btnRiapri.Enabled = true;

            // se sono il rup e il progetto è in stato acquisito posso assegnarmi la pratica
            var responsabileDiMisura = new BandoCollectionProvider().GetResponsabileDiMisuraBando(Bando.IdBando);
            if (responsabileDiMisura != null
                && responsabileDiMisura.IdUtente == Operatore.Utente.IdUtente
                && ucInfoDomanda.Progetto.CodStato == "I")
            {
                btnAssegnaRup.Modifica = false;
                btnAssegnaRup.Enabled = true;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //btnPunteggio.Disabled = !(ucInfoDomanda.Progetto.OrdineFase > 2 && ucInfoDomanda.Progetto.OrdineFase < 90 &&
            //    ucInfoDomanda.Progetto.OrdineStato == 1);
            btnPunteggio.Attributes.Add("onclick", ucSiarNewZoomPunteggio.GetOpenZoomJsFunction(ucInfoDomanda.Progetto.IdProgetto));

            //pregresso
            bool Pregresso = false;
            string StPregresso = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_PregressoAmmissibilita( Bando.IdBando);
            if (StPregresso == "True")
                Pregresso = true;

            if (!Pregresso)
            {
                // se la domanda è stata già predisposta alla valutazione disabilito il bottone
                if (Bando.AbilitaValutazione)
                {
                    SiarLibrary.ProgettoValutazione v = valutazione_provider.GetById(ucChecklist.Progetto.IdProgetto);
                    if (v != null)
                        btnPredisponiValutazione.Modifica = false;
                }
                else
                {
                    btnPredisponiValutazione.Modifica = false;
                    btnPredisponiValutazione.Visible = false;
                }
                btnInserisciSegnatura.Visible = false;
            }
            else
            {
                btnInserisciSegnatura.Visible = true;
                btnPredisponiValutazione.Visible = false;
                btnRendiDefinitiva.Visible = false;
                ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
            }


            ArrayList link_veloci = ucChecklist.StepDiReindirizzamento;
            if (link_veloci.Count == 0) tbLinkVeloci.Visible = false;
            else
            {
                foreach (string url in link_veloci)
                {
                    string testo_bottone = url.Substring(url.LastIndexOf("/") + 1);
                    testo_bottone = testo_bottone.Remove(testo_bottone.LastIndexOf(".")).Replace("Istruttoria", "").Replace("Ammissibilita", "");
                    string button = "<input type=button class='btn btn-secondary py-1 m-1' value='" + testo_bottone + "' onclick=\"location='" +
                        url.Replace("~", HttpContext.Current.Request.ApplicationPath) + "&iddom=" + ucInfoDomanda.Progetto.IdProgetto + "'\" />";
                    tbLinkVeloci.Controls.Add(new LiteralControl(button));
                }
            }

            SiarLibrary.ProgettoStoricoCollection storico = storico_provider.Find(ucChecklist.Progetto.IdProgetto, null, "A");
            if (storico.Count > 0)
            {
                string btn_js_code = "";
                if (string.IsNullOrEmpty(storico[0].Segnatura))
                {
                    string errore = "La checklist di ammissibilità non e' stata protocollata correttamente. Si prega di contattare l'helpdesk per risolvere il problema.";
                    if (!IsPostBack) ShowError(errore);
                    btn_js_code = "alert('" + errore + "');";
                }
                else
                {
                    txtSegnatura.Text = storico[0].Segnatura;
                    btn_js_code = "sncAjaxCallVisualizzaProtocollo('" + storico[0].Segnatura + "');";
                }
                btnStampa.Disabled = false;
                btnStampa.Attributes.Add("onclick", btn_js_code);
            }

            ufcNAAllegato.AbilitaModifica = AbilitaModifica;
            if (allegato_selezionato != null)
            {
                hdnIdProgettoAllegatiIstruttoria.Value = allegato_selezionato.IdProgettoAllegatiIstruttoria;
                txtNADescrizioneBreve.Text = allegato_selezionato.DescrizioneBreve;
                ufcNAAllegato.IdFile = allegato_selezionato.IdFile;
            }

            SiarLibrary.ProgettoAllegatiIstruttoriaCollection allegati_domanda = allegati_provider.Find(null, ucInfoDomanda.Progetto.IdProgetto, null);
            dgAllegati.DataSource = allegati_domanda;
            //dgAllegati.Titolo = "Elementi trovati: " + allegati_domanda.Count;
            dgAllegati.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgAllegati_ItemDataBound);
            dgAllegati.DataBind();
            if (allegati_domanda.Count > 0) divDimTotAllegati.InnerText = "Dimensione totale degli allegati: " + string.Format("{0:N0}", dimensione_totale_allegati) + " Kb";

            base.OnPreRender(e);
        }

        int dimensione_totale_allegati = 0;
        void dgAllegati_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.ProgettoAllegatiIstruttoria a = (SiarLibrary.ProgettoAllegatiIstruttoria)e.Item.DataItem;
                SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a.IdFile);
                
                e.Item.Cells[2].Text = Convert.ToString( Convert.ToInt32( f.Dimensione / 1024));

                dimensione_totale_allegati += (f.Dimensione / 1024);
            }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string esito = ucChecklist.VerificaChecklist();
                switch (esito)
                {
                    case "SI":
                        ShowMessage("Checklist verificata correttamente. La domanda soddisfa tutti i requisiti necessari per essere AMMISSIBILE.");
                        btnRendiDefinitiva.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        break;
                    case "NO":
                        ShowError("La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist.");
                        btnRendiDefinitiva.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        break;
                    default:
                        ShowError(esito);
                        break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRendiDefinitiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                ucFirmaAmmissibilita.loadDocumento(Operatore.Utente.CfUtente, ucInfoDomanda.Progetto.IdProgetto);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnProtocolla_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(ucFirmaAmmissibilita.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk per segnalare il problema.");

                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);

                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                documento_interno.setDocumento("checklist_ammissibilita_domanda_" + ucChecklist.Progetto.IdProgetto + ".pdf",
                    Convert.FromBase64String(ucFirmaAmmissibilita.FileFirmato));

                string[] ss = BandoProvider.GetDatiXProtocollazione(Bando.IdBando, ucChecklist.Progetto.ProvinciaDiPresentazione);
                var impresa = new SiarBLL.ImpresaCollectionProvider().GetById(ucChecklist.Progetto.IdImpresa);
                string oggetto = "Checklist AMMISSIBILITA per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                    + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                    + "\n Ragione sociale: " + impresa.RagioneSociale
                    + "\n N° Domanda: " + ucChecklist.Progetto.IdProgetto;

                // carico gli allegati su paleo
                SiarLibrary.ProgettoAllegatiIstruttoriaCollection allegati = allegati_provider.Find(null,ucInfoDomanda.Progetto.IdProgetto, null);
                //Dichiarazione nome e hash degli allegati per l'impronta
                foreach (SiarLibrary.ProgettoAllegatiIstruttoria a in allegati)
                {
                    try
                    {
                        if (a.IdFile != null)
                        {
                            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a.IdFile);
                            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                            documento_interno.addAllegato(f.NomeFile, f.HashCode);
                        }
                    }
                    catch (Exception ex) { }
                }

                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                progetto_provider.DbProviderObj.BeginTran();
                try
                {
                    string stato = (esito == "SI" ? "A" : "B");
                    progetto_provider.CambioStatoProgetto(ucChecklist.Progetto, stato, identificativo_paleo, null, Operatore, ucInfoDomanda.DomandaInRiesame,
                        ucInfoDomanda.DomandaInRevisione, ucInfoDomanda.DomandaInRicorso);
                    if (ucChecklist.Progetto.IdProgIntegrato != null)
                    {
                        SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, ucChecklist.Progetto.IdProgIntegrato, null, null, false, true);
                        foreach (SiarLibrary.Progetto p in progetti_correlati)
                            if (p.IdProgetto != p.IdProgIntegrato)
                                progetto_provider.CambioStatoProgetto(p, stato, Operatore, ucInfoDomanda.DomandaInRiesame, ucInfoDomanda.DomandaInRevisione, ucInfoDomanda.DomandaInRicorso);
                    }

                    if(allegati.Count > 0)
                    {

                        // carico gli allegati su paleo /// spostato sopra riga 205 il 16/09/2019 per aggiornamento paleo 
                        //SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
                        System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                        foreach (SiarLibrary.ProgettoAllegatiIstruttoria x in allegati)
                        {
                            try
                            {
                                if (x.IdFile != null)
                                {
                                    SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(x.IdFile);
                                    if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                                    string estensione = null;
                                    if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                                    //p.addAllegato(f.NomeFile, f.Contenuto, estensione);
                                    SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                    all.Descrizione = f.NomeFile;
                                    all.Documento = new SiarBLL.paleoWebService.File();
                                    all.Documento.NomeFile = f.NomeFile;

                                    System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                    allegatoProtocollo.Add("allegato", all);
                                    allegatoProtocollo.Add("id_file", f.Id);
                                    allegatoProtocollo.Add("tipo_origine", "istruttoria");
                                    allegatoProtocollo.Add("id_origine", ucInfoDomanda.Progetto.IdProgetto);
                                    allegatiProtocollo.Add(allegatoProtocollo);
                                }
                            }
                            catch (Exception ex) { }
                        }

                        SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);

                        string[] doc_number = identificativo_paleo.Split('|');

                        protocolloAll.addAllegatiDocInterno(allegatiProtocollo, identificativo_paleo,  doc_number[0]);
                    }


                    progetto_provider.DbProviderObj.Commit();
                    ucChecklist.Progetto = ucInfoDomanda.Progetto = progetto_provider.GetById(ucChecklist.Progetto.IdProgetto);
                    //bindControlli(ucChecklist.Progetto.IdProgetto);
                    ucInfoDomanda.loadData();
                    btnVerifica.Enabled = false;
                    //if (stato == "A")
                    //    btnPunteggio.Disabled = false;
                    ShowMessage("Checklist di ammissibilità firmata e protocollata correttamente.<br /> La domanda è ora " +
                        ucChecklist.Progetto.Stato.Value.ToUpper());
                }
                catch (Exception exc)
                {
                    progetto_provider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore nel cambio di stato del progetto nr." + ucChecklist.Progetto.IdProgetto;
                    string testEmail = "Segnatura documento interno protocollato: " + identificativo_paleo +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    throw;
                }
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaAmmissibilita.FileFirmato = null; }
        }

        protected void btnRiapri_Click(object sender, EventArgs e)
        {
            SiarBLL.ProgettoSegnatureCollectionProvider segnature_provider = new SiarBLL.ProgettoSegnatureCollectionProvider();
            SiarLibrary.CollaboratoriXBando istruttore = new SiarLibrary.CollaboratoriXBando();
            try
            {
                SiarLibrary.BandoResponsabiliCollection responsabili = responsabili_provider.Find(Bando.IdBando, Operatore.Utente.IdUtente, null, null, true);
                if (responsabili.FiltroProvincia(ucChecklist.Progetto.ProvinciaDiPresentazione, null).Count == 0 && responsabili.FiltroProvincia(null, true).Count == 0)
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (ucInfoDomanda.Progetto.CodFase != "A") throw new Exception("La domanda deve essere stata istruita in ammissibilità per effettuare la riapertura");
                SiarLibrary.ProgettoSegnature revisione = segnature_provider.GetById(ucChecklist.Progetto.IdProgetto, "REV");
                if (revisione != null && revisione.RiapriDomanda)
                    throw new Exception("La domanda è stata già riaperta per la REVISIONE. Operazione annullata.");
                SiarLibrary.ProgettoSegnature riesame = segnature_provider.GetById(ucChecklist.Progetto.IdProgetto, "RID");
                if (riesame != null && riesame.RiapriDomanda) throw new Exception("La domanda è stata già riaperta per la RIESAME. Operazione annullata.");
                SiarLibrary.ProgettoStorico storico_attuale = storico_provider.GetById(ucChecklist.Progetto.IdStoricoUltimo);
                storico_provider.DbProviderObj.BeginTran();

                //storico_attuale 
                storico_attuale.RiaperturaProvinciale = true;
                storico_attuale.OperatoreRi = Operatore.Utente.IdUtente;
                storico_attuale.DataRi = DateTime.Now;
                storico_provider.Save(storico_attuale);
                //controllo la graduato
                SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider(storico_provider.DbProviderObj);
                graduatoria_provider.DeleteCollection(graduatoria_provider.Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto, null));
                //nuovo collaboratore
                SiarBLL.CollaboratoriXBandoCollectionProvider collaboratori_provider = new SiarBLL.CollaboratoriXBandoCollectionProvider(storico_provider.DbProviderObj);
                SiarLibrary.CollaboratoriXBandoCollection c = collaboratori_provider.Find(Bando.IdBando, ucChecklist.Progetto.IdProgetto, null, null, true);
                if (c.Count > 0)
                {
                    istruttore = c[0];
                    istruttore.Attivo = false;
                    istruttore.DataFineValidita = DateTime.Now;
                    istruttore.OperatoreFineValidita = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                    collaboratori_provider.Save(istruttore);
                }
                istruttore = new SiarLibrary.CollaboratoriXBando();
                istruttore.IdUtente = Operatore.Utente.IdUtente;
                istruttore.IdBando = Bando.IdBando;
                istruttore.IdProgetto = ucChecklist.Progetto.IdProgetto;
                istruttore.Provincia = ucChecklist.Progetto.ProvinciaDiPresentazione; //lstProvincia.SelectedValue;
                istruttore.OperatoreInserimento = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente;
                istruttore.DataInserimento = DateTime.Now;
                istruttore.Attivo = true;
                collaboratori_provider.Save(istruttore);

                storico_provider.DbProviderObj.Commit();
                btnRiapri.Enabled = false;
                controlloOperatoreStatoProgetto();
            }
            catch (Exception ex) { storico_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPredisponiValutazione_Click(object sender, EventArgs e)
        {
            try
            {
                valutazione_provider.DbProviderObj.BeginTran();
                SiarBLL.ProgettoValutatoriCollectionProvider valutatori_provider = new SiarBLL.ProgettoValutatoriCollectionProvider(valutazione_provider.DbProviderObj);
                SiarBLL.BandoValutatoriCollectionProvider bando_valutatori_provider = new SiarBLL.BandoValutatoriCollectionProvider(valutazione_provider.DbProviderObj);
                if (ucInfoDomanda.Progetto.CodStato != "I" &&
                ucInfoDomanda.DomandaInRiesame == false &&
                ucInfoDomanda.DomandaInRevisione == false &&
                ucInfoDomanda.DomandaInRicorso == false &&
                ucInfoDomanda.DomandaInIstruttoriaProvinciale == false) throw new Exception("La domanda non risulta ancora ricevibile.");
                SiarLibrary.ProgettoValutazioneCollection vCollection = valutazione_provider.Find(ucChecklist.Progetto.IdProgetto,null, true, null, false);

                if (vCollection.Count == 0)
                {
                    SiarLibrary.ProgettoValutazione v = new SiarLibrary.ProgettoValutazione();
                    v.IdProgetto = ucChecklist.Progetto.IdProgetto;
                    v.OrdineFirma = 0;
                    v.DataModifica = DateTime.Now;
                    v.Operatore = Operatore.Utente.IdUtente;
                    v.IdNote = null;
                    v.Annullato = false;
                    valutazione_provider.Save(v);

                    SiarLibrary.BandoValutatoriCollection bando_valutatori = bando_valutatori_provider.Find(null, Bando.IdBando, null, true, null);

                    if (bando_valutatori.Count == 0)
                        throw new Exception("Non sono stati definiti valutatori per il bando.");
                    else
                    {
                        int i = 1;
                        foreach (SiarLibrary.BandoValutatori bv in bando_valutatori)
                        {
                            SiarLibrary.ProgettoValutatori pv = new SiarLibrary.ProgettoValutatori();
                            pv.IdProgettoValutazione = v.Id;
                            pv.IdValutatore = bv.IdValutatore;
                            pv.Presente = true;
                            pv.Ordine = i;
                            valutatori_provider.Save(pv);
                            i++;
                        }
                    }

                    valutazione_provider.DbProviderObj.Commit();
                    ShowMessage("Progetto correttamente predisposto alla valutazione;");
                }
                else
                    throw new Exception("La domanda è stata già predisposta alla valutazione.");
            }
            catch (Exception ex) { valutazione_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnaturaIns.Text == null || txtSegnaturaIns.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaIns.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }
                
                string esito = ucChecklist.VerificaChecklist();
                if (esito != "SI" && esito != "NO") throw new Exception(esito);

                string stato = (esito == "SI" ? "A" : "B");

                progetto_provider.CambioStatoProgettoPregresso(ucChecklist.Progetto, stato, ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, ucInfoDomanda.DomandaInRiesame,
                    ucInfoDomanda.DomandaInRevisione, ucInfoDomanda.DomandaInRicorso);
                
                if (ucChecklist.Progetto.IdProgIntegrato != null)
                {
                    SiarLibrary.ProgettoCollection progetti_correlati = progetto_provider.Find(null, null, ucChecklist.Progetto.IdProgIntegrato, null, null, false, true);
                    foreach (SiarLibrary.Progetto p in progetti_correlati)
                        if (p.IdProgetto != p.IdProgIntegrato)
                            progetto_provider.CambioStatoProgettoPregresso(p, stato, null, Convert.ToDateTime(txtData.Text), Operatore, ucInfoDomanda.DomandaInRiesame,
                                ucInfoDomanda.DomandaInRevisione, ucInfoDomanda.DomandaInRicorso);
          
                }
                progetto_provider.DbProviderObj.Commit();
                ucChecklist.Progetto = ucInfoDomanda.Progetto = progetto_provider.GetById(ucChecklist.Progetto.IdProgetto);
                //bindControlli(ucChecklist.Progetto.IdProgetto);
                ucInfoDomanda.loadData();
                btnVerifica.Enabled = false;
                //btnPunteggio.Disabled = false;
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura dell'istruttoria di ammissibilità sono state salvate correttamente.<br /> La domanda è ora " +
                    ucChecklist.Progetto.Stato.Value.ToUpper());

            }
            catch (Exception ex)
            {
                btnInserisciSegnatura_Click(sender, e);
                ShowError("Attenzione! " + ex.Message);
            }
        }

        protected void btnNuovoPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegato.IdFile = null;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {

                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (ufcNAAllegato.IdFile == null)
                    throw new Exception("Attenzione! Nessun documento caricato. Ricordarsi di cliccare il tasto 'Carica' dopo aver effettuato l' upload del file!");

                if (allegato_selezionato == null)
                {
                    allegato_selezionato = new SiarLibrary.ProgettoAllegatiIstruttoria();
                    allegato_selezionato.IdProgetto = ucInfoDomanda.Progetto.IdProgetto;
                    allegato_selezionato.OperatoreInserimento = Operatore.Utente.IdUtente;
                    allegato_selezionato.DataInserimento = DateTime.Now;
                }
                allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                allegato_selezionato.DescrizioneBreve = txtNADescrizioneBreve.Text;
                allegato_selezionato.OperatoreModifica = Operatore.Utente.IdUtente;
                allegato_selezionato.DataModifica = DateTime.Now;
                allegati_provider.Save(allegato_selezionato);
            
                allegato_selezionato = allegati_provider.GetById(allegato_selezionato.IdProgettoAllegatiIstruttoria);
                ShowMessage("Allegato salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (allegato_selezionato == null || allegato_selezionato.IdProgetto != ucInfoDomanda.Progetto.IdProgetto) throw new Exception("L'allegato selezionato non è valido.");
                allegati_provider.Delete(allegato_selezionato);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnDettaglioAllegatoPost_Click(object sender, EventArgs e) { }

        protected void btnAssegnaRup_Click(object sender, EventArgs e) 
        {
            var collaboratoriProvider = new CollaboratoriXBandoCollectionProvider();

            try
            {
                collaboratoriProvider.DbProviderObj.BeginTran();

                var bandoProvider = new BandoCollectionProvider(collaboratoriProvider.DbProviderObj);
                var responsabileDiMisura = bandoProvider.GetResponsabileDiMisuraBando(Bando.IdBando);

                if (responsabileDiMisura == null)
                    throw new Exception("Non è stato trovato il responsabile di misura del bando. Contattare l'helpdesk");

                int idProgetto = ucInfoDomanda.Progetto.IdProgetto;

                // se trovo l'istruttore devo disabilitarlo
                var collaboratoreList = collaboratoriProvider
                    .Find(Bando.IdBando, idProgetto, null, null, true)
                    .ToArrayList<CollaboratoriXBando>();

                foreach(CollaboratoriXBando collaboratore in collaboratoreList)
                {
                    collaboratore.OperatoreFineValidita = Operatore.Utente.IdUtente;
                    collaboratore.DataFineValidita = DateTime.Now;
                    collaboratore.Attivo = 0;
                    collaboratoriProvider.Save(collaboratore);
                }

                // Assegno poi il rup come istruttore
                var rupCollaboratore = new CollaboratoriXBando();
                rupCollaboratore.IdBando = Bando.IdBando;
                rupCollaboratore.IdProgetto = idProgetto;
                rupCollaboratore.IdUtente = responsabileDiMisura.IdUtente;
                rupCollaboratore.Provincia = responsabileDiMisura.Provincia != null ? responsabileDiMisura.Provincia : new SiarLibrary.NullTypes.StringNT("AN");
                rupCollaboratore.OperatoreInserimento = Operatore.Utente.IdUtente;
                rupCollaboratore.DataInserimento = DateTime.Now;
                rupCollaboratore.Attivo = 1;
                collaboratoriProvider.Save(rupCollaboratore);

                collaboratoriProvider.DbProviderObj.Commit();

                Redirect("ChecklistAmmissibilita.aspx?iddom=" + idProgetto, "Pratica assegnata al responsabile di misura correttamente.", false);
            }
            catch (Exception ex) 
            {
                collaboratoriProvider.DbProviderObj.Rollback();
                ShowError(ex); 
            }
        }
    }
}
