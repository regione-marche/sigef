using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;
using SiarBLL;

namespace web.Private.IPagamento.IVariante
{
    public partial class FirmaRichiesta : SiarLibrary.Web.IstruttoriaVariantePage
    {
        SiarLibrary.VariantiEsitiRequisitiCollection esiti_requisiti;
        SiarBLL.VariantiEsitiRequisitiCollectionProvider esiti_provider = new SiarBLL.VariantiEsitiRequisitiCollectionProvider();
        SiarBLL.ProgettoValutazioneCollectionProvider valutazione_provider = new SiarBLL.ProgettoValutazioneCollectionProvider();
        SiarLibrary.ProgettoValutazioneCollection valutazione_progetto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //AbilitaModifica = AbilitaModifica && TipoModifica == 3;
            btnPunteggio.Attributes.Add("onclick", ucSiarNewZoomPunteggio.GetOpenZoomVarianteJsFunction(Variante.IdProgetto, Variante.IdVariante));

            ucFirmaDocumento.DocumentoFirmatoEvent = btnPost_Click;
            ucFirmaDocumento.TipoDocumento = "CKL_VARIANTE" + (Variante.CodTipo == "AR" ? "_AR" : "");
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (valutazione_progetto == null) valutazione_progetto = valutazione_provider.Find(Variante.IdProgetto, Variante.IdVariante, null, null, false);
            if (valutazione_progetto != null && valutazione_progetto.Count > 0)
            {
                btnPredisponiValutazione.Text = "Comitato di valutazione";
                btnPredisponiValutazione.Enabled = true;
                btnPunteggio.Disabled = true;
            }

            esiti_requisiti = esiti_provider.Find(Variante.IdVariante, null);

            SiarLibrary.BandoRequisitiVarianteCollection requisiti = new SiarBLL.BandoRequisitiVarianteCollectionProvider()
                .Find(Progetto.IdBando, Variante.CodTipo).FiltroProcedura(null, true);
            dgRequisiti.DataSource = requisiti;
            dgRequisiti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            if (requisiti.Count == 0)
            {
                dgRequisiti.Titolo = "<b><em> - NESSUN REQUISITO DI CONTROLLO ASSOCIATO AL BANDO.</em></b>";
                ShowError("Impossibile istruire la richiesta. Non sono stati associati i requisiti di controllo.");
                btnVerifica.Enabled = false;
            }
            dgRequisiti.DataBind();

            txtIstruttore.Text = Variante.NominativoIstruttore;
            txtSegnatura.Text = Variante.SegnaturaApprovazione;
            txtValutazioneLunga.Text = Variante.NoteIstruttore;
            if (Variante.SegnaturaApprovazione != null) btnStampa.Enabled = true;
            if (Variante.CodTipo == "VI")
            {
                btnFirma.Enabled = false;
                btnFirma.Visible = false;
                btnStampa.Enabled = false;
                btnBackToPagamento.Visible = true;
                foreach (SiarLibrary.DomandaDiPagamento d in new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, null, Variante.IdProgetto, null))
                {
                    if (d.IdVariazioneAccertata != null && d.IdVariazioneAccertata == Variante.IdVariante)
                    {
                        btnBackToPagamento.Attributes.Add("onclick", "location='../ChecklistPagamento.aspx?idpag=" + d.IdDomandaPagamento + "'");
                        break;
                    }
                }
            }

            //Gestione pulsante predisponi alla firma
            if (Variante.SegnaturaApprovazione == null)
            {
                if (Variante.FirmaPredispostaRup != null && Variante.FirmaPredispostaRup)
                {
                    btnPredisponiFirma.Text = "Annulla predisposizione";
                    btnPredisponiFirma.Conferma = "Annullare la predisposizione alla firma?";
                    //btnVerifica.Enabled = false;
                }
                else
                {
                    //btnVerifica.Enabled = true;
                }
                btnPredisponiFirma.Enabled = TipoModifica == 3;

                //se l'istruttore coincide con il RUP nascondo la predisposizione alla firma
                if ((new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0)
                       && new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Progetto.IdBando, Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0)
                    trPredisposizione.Visible = false;
                else
                    trPredisposizione.Visible = true;

                //
                //SiarBLL.BandoResponsabiliCollectionProvider resp_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
                //SiarLibrary.BandoResponsabiliCollection resp_coll = resp_provider.Find(Progetto.IdBando, null, null, null, true);
                //if(DomandaPagamento.FirmaPredispostaRup)
                //    btnFirma.Enabled = (DomandaPagamento.FirmaPredispostaRup && resp_coll[0].IdUtente == Operatore.Utente.IdUtente);
            }
            else
                trPredisposizione.Visible = false;

            string errore = new SiarBLL.DomandaDiPagamentoCollectionProvider().ControlloVarianteRilasciabile(Progetto.IdProgetto, true, false);
            if (errore != null)
            {
                btnFirma.Enabled = false;
                btnFirma.ToolTip = errore;
            }

            base.OnPreRender(e);
        }

        void dgRequisiti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.BandoRequisitiVariante requisito = (SiarLibrary.BandoRequisitiVariante)dgi.DataItem;
                SiarLibrary.VariantiEsitiRequisiti requisito_variante = esiti_requisiti.CollectionGetById(Variante.IdVariante,
                    requisito.IdRequisito);
                SiarLibrary.Web.ComboSiNo comboEsitoRequisito = (SiarLibrary.Web.ComboSiNo)dgi.Cells[3].FindControl("lstEsitoRequisito");
                if (comboEsitoRequisito != null && !requisito.Automatico)
                {
                    #region hidden con nome combo
                    HtmlInputHidden hdn = new HtmlInputHidden();
                    //hdn.Attributes.Add("runat", "server");
                    hdn.ID = "hdnEsitoRequisito" + requisito.IdRequisito;
                    hdn.Value = comboEsitoRequisito.UniqueID;
                    dgi.Cells[3].Controls.Add(hdn);
                    #endregion
                }
                SiarLibrary.NullTypes.StringNT note = string.Empty;
                if (requisito_variante != null)
                {
                    esiti_requisiti.Remove(requisito_variante);

                    if (requisito.Automatico)
                    {
                        #region Requisito Automatico

                        if (requisito_variante.CodEsitoIstruttore == "SI") dgi.Cells[3].Style.Add("color", "#0b9007");
                        else dgi.Cells[3].Style.Add("color", "#be0202");

                        dgi.Cells[3].Text = requisito_variante.CodEsitoIstruttore;
                        if (requisito_variante.CodEsitoIstruttore == "ER")
                            dgi.Cells[3].Text = "Attenzione! Errore nella esecuzione della verifica, si prega di contattare l'helpdesk.";
                        #endregion
                    }
                    else
                    {
                        #region Manuale - Combo
                        if (requisito_variante.CodEsitoIstruttore != null && comboEsitoRequisito != null)
                        {
                            ListItem li = comboEsitoRequisito.Items.FindByValue(requisito_variante.CodEsitoIstruttore);
                            if (li != null) li.Selected = true;
                        }
                        #endregion
                    }
                    note = requisito_variante.Note;
                }
                else if (requisito.Automatico) dgi.Cells[3].Text = "";
                dgi.Cells[4].Text = "<span id='txtAreaLungaCKL" + requisito.IdRequisito + "' class='TextArea'><textarea id='txtAreaLungaCKL"
                    + requisito.IdRequisito + "_text' name='txtAreaLungaCKL" + requisito.IdRequisito + "_text' cols='20' rows='3' style='text-align:left;width:360px'>"
                    + note + "</textarea></span>";
            }
        }

        private void VerificaRequisito(SiarLibrary.BandoRequisitiVariante requisito, ref SiarLibrary.VariantiEsitiRequisiti requisito_variante)
        {
            string esito;
            try
            {
                if (requisito.Automatico) esito = (VerificaStepAutomatico(ref requisito) ? "SI" : "NO");
                else
                {
                    string retval = null; //= requisito_variante.CodEsitoIstruttore;
                    //cerco l'hidden che come valore ha l'uniqueid della combo corrispondente allo step
                    string nome_hidden = "hdnEsitoRequisito" + requisito.IdRequisito;
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith(nome_hidden))
                        {
                            //trovo il valore selezionato della combo 
                            string id_combo = Request.Form[s];
                            retval = Request.Form[id_combo];
                            break;
                        }
                    }
                    esito = retval;

                }
            }
            catch { esito = "ER"; }
            if (requisito_variante == null)
            {
                requisito_variante = new SiarLibrary.VariantiEsitiRequisiti();
                requisito_variante.IdVariante = Variante.IdVariante;
                requisito_variante.IdRequisito = requisito.IdRequisito;
            }
            requisito_variante.CodEsitoIstruttore = esito;
            requisito_variante.DataValutazione = DateTime.Now;
            requisito_variante.Istruttore = ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.CfUtente;
            requisito_variante.Note = Request.Form["txtAreaLungaCKL" + requisito_variante.IdRequisito + "_text"];
            esiti_provider.Save(requisito_variante);

        }

        private bool VerificaStepAutomatico(ref SiarLibrary.BandoRequisitiVariante requisito)
        {
            decimal queryResult = -1000000000;
            System.Data.IDbCommand cmd = VarianteProvider.DbProviderObj.GetCommand();
            cmd.CommandText = requisito.QueryEval;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_VARIANTE", Variante.IdVariante.Value));
            VarianteProvider.DbProviderObj.InitDatareader(cmd);
            if (VarianteProvider.DbProviderObj.DataReader.Read())
                decimal.TryParse(VarianteProvider.DbProviderObj.DataReader.GetValue(0).ToString(), out queryResult);

            // Possono essere ritornati più recordset -> L'ultimo rappresenta il risultato dello Step
            while (VarianteProvider.DbProviderObj.DataReader.NextResult())
            {
                if (VarianteProvider.DbProviderObj.DataReader.Read())
                    decimal.TryParse(VarianteProvider.DbProviderObj.DataReader.GetValue(0).ToString(), out queryResult);
            }
            VarianteProvider.DbProviderObj.Close();
            bool minimo_verificato = false, massimo_verificato = false;
            massimo_verificato = requisito.ValMassimo == null || (requisito.ValMassimo != null && queryResult <= requisito.ValMassimo.Value);
            minimo_verificato = requisito.ValMinimo == null || (requisito.ValMinimo != null && queryResult >= requisito.ValMinimo.Value);
            return minimo_verificato && massimo_verificato;
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variante.SegnaturaApprovazione != null) throw new Exception("L'istruttoria è stata firmata e protocollata. Impossibile continuare.");
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(b.CodEnte);
                documento_interno.setDocumento("checklist_istruttoria_" + Variante.TipoVariante + "_domanda_"
                    + Variante.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                string oggetto = "Checklist di istruttoria " + Variante.TipoVariante.Value.ToUpper() + " per il bando: "
                    + ss[0] + " del " + ss[1] + " con scadenza " + ss[2] + " \n" + ss[3] + "\nAnno: " + DateTime.Now.Year 
                    + "\n Partita iva/Codice fiscale: " + ucVariantiControl.Impresa.Cuaa
                    + "\n Ragione sociale: " + ucVariantiControl.Impresa.RagioneSociale
                    + "\n N° Domanda: " + Progetto.IdProgetto;

                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);
                VarianteProvider.DbProviderObj.BeginTran();
                try
                {
                    //Aggiorno la variante
                    Variante.SegnaturaApprovazione = identificativo_paleo;
                    VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);

                    SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(VarianteProvider.DbProviderObj);
                    if (Variante.Approvata && Variante.CuaaEntrante != null) //cambio beneficiario al progetto
                    {
                        string id_impresa_entrante = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(Variante.CuaaEntrante).IdImpresa;
                        Progetto.IdImpresa = id_impresa_entrante;
                        Progetto.IdFascicolo = Variante.IdFascicoloEntrante;
                        progetto_provider.Save(Progetto);
                    }
                    // salvo il punteggio istruito (QUESTA COSA NON SERVE E COSì NON VA BENE PERCHè AZZERA I PUNTEGGI)
                    // meglio fare un controllo che se il punteggio è zero allora si manda un'eccezione piuttosto che ricalcolare senza mandare i punteggi manuali.
                    // progetto_provider.CalcoloPunteggioDomandaDiAiuto(Progetto.IdProgetto, Variante.IdVariante, null, true, Operatore.Utente.CfUtente);

                    SiarLibrary.Bando bando = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                    if (bando.AbilitaValutazione)
                    {
                        SiarLibrary.VariantiXPrioritaCollection vpc = new SiarBLL.VariantiXPrioritaCollectionProvider().Find(Variante.IdVariante, null);
                        if (vpc.Count == 0) throw new Exception("Non sono stati calcolati i punteggi della variante.");
                    }


                    VarianteProvider.DbProviderObj.Commit();

                    ShowMessage("Checklist di istruttoria domanda di " + Variante.TipoVariante + " firmata e protocollata correttamente.");
                    Variante = VarianteProvider.GetById(Variante.IdVariante);
                    btnVerifica.Enabled = false;
                }
                catch (Exception exc)
                {
                    VarianteProvider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore nell'istruttoria della variante nr " + Variante.IdVariante + " Domanda di aiuto: " + Progetto.IdProgetto;
                    string testEmail = "Segnatura doumento interno protocollato: " + identificativo_paleo +
                        "\nErrore: " + exc.Message;
                    EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                    ShowError(exc);
                }
                ucFirmaDocumento.FileFirmato = null;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variante.SegnaturaApprovazione != null) throw new Exception("L'istruttoria è stata firmata e protocollata. Impossibile continuare.");
                if (Variante.CuaaEntrante != null)
                    if (Variante.CuaaEntrante != null) SiarLibrary.DbStaticProvider.ControlloCambioBeneficiarioVariante(Variante.IdVariante,
                        false, VarianteProvider.DbProviderObj);

                bool approvata = VerificaRequisitiVariante();
                Variante.Approvata = null;
                Variante.NoteIstruttore = txtValutazioneLunga.Text;
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, Operatore);

                if (!approvata) ShowError("Almeno uno tra i requisiti obbligatori imposti per il controllo non risulta verificato. La richiesta NON verrà APPROVATA.");
                else ShowMessage("Requisiti verificati correttamente. La " + Variante.TipoVariante + " soddisfa tutti i requisiti necessari per essere APPROVATA.");
                Variante.Approvata = approvata;
                btnFirma.Enabled = true;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private SiarLibrary.NullTypes.BoolNT VerificaRequisitiVariante()
        {
            bool RequisitiVerificati = true;
            SiarLibrary.BandoRequisitiVarianteCollection bando_requisiti_coll = new SiarLibrary.BandoRequisitiVarianteCollection();
            bando_requisiti_coll = new SiarBLL.BandoRequisitiVarianteCollectionProvider().Find(Progetto.IdBando, Variante.CodTipo).FiltroProcedura(null, true);
            esiti_requisiti = new SiarLibrary.VariantiEsitiRequisitiCollection();
            esiti_requisiti = esiti_provider.Find(Variante.IdVariante, null);
            foreach (SiarLibrary.BandoRequisitiVariante requisito in bando_requisiti_coll)
            {
                SiarLibrary.VariantiEsitiRequisiti requisito_variante = esiti_requisiti.CollectionGetById(Variante.IdVariante,
                        requisito.IdRequisito);
                VerificaRequisito(requisito, ref requisito_variante);
                if (RequisitiVerificati && requisito.Obbligatorio &&
                    (requisito_variante == null || requisito_variante.CodEsitoIstruttore == "NO" || requisito_variante.CodEsitoIstruttore == null))
                    RequisitiVerificati = false;
            }
            return RequisitiVerificati;
        }

        protected void btnStampa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Variante.SegnaturaApprovazione)) throw new Exception("La variante non è stata firmata. Impossibile continuare.");
                SiarLibrary.Protocollo doc = new SiarLibrary.Protocollo();
                byte[] b = doc.RicercaProtocollo(Variante.SegnaturaApprovazione, false);
                Session.Add("doc", b);
                RegisterClientScriptBlock("window.open('../../../VisualizzaDocumento.aspx');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                string errore = new SiarBLL.DomandaDiPagamentoCollectionProvider().ControlloVarianteRilasciabile(Progetto.IdProgetto, true, false);
                if (errore != null)
                    throw new Exception(errore);

                Variante.NoteIstruttore = txtValutazioneLunga.Text;
                VarianteProvider.AggiornaVarianteIstruttoria(Variante, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                SiarLibrary.CollaboratoriXBandoCollection istruttori_assegnati = new SiarBLL.CollaboratoriXBandoCollectionProvider()
                    .Find(Progetto.IdBando, Progetto.IdProgetto, null, null, true);
                if (istruttori_assegnati.Count == 0) throw new Exception("Nessun operatore abilitato alla firma dell'istruttoria. Impossibile continuare.");
                string cf_firmatario = new SiarBLL.UtentiCollectionProvider().GetById(istruttori_assegnati[0].IdUtente).CfUtente;
                ucFirmaDocumento.loadDocumento(cf_firmatario, Variante.IdVariante);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPredisponiValutazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variante.Annullata) throw new Exception("La variante è chiusa.");

                //if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarBLL.ProgettoValutatoriCollectionProvider valutatori_provider = new SiarBLL.ProgettoValutatoriCollectionProvider(valutazione_provider.DbProviderObj);
                SiarBLL.BandoValutatoriCollectionProvider bando_valutatori_provider = new SiarBLL.BandoValutatoriCollectionProvider(valutazione_provider.DbProviderObj);

                SiarLibrary.BandoValutatoriCollection bando_valutatori = bando_valutatori_provider.Find(null, Progetto.IdBando, null, true, null);
                if (bando_valutatori.Count == 0) throw new Exception("Non sono stati definiti valutatori per il bando.");


                valutazione_progetto = valutazione_provider.Find(Variante.IdProgetto, Variante.IdVariante, null, null, false);

                if (valutazione_progetto.Count == 0)
                {
                    valutazione_provider.DbProviderObj.BeginTran();
                    SiarLibrary.ProgettoValutazione v = new SiarLibrary.ProgettoValutazione();
                    v.IdProgetto = Variante.IdProgetto;
                    v.IdVariante = Variante.IdVariante;
                    v.OrdineFirma = 0;
                    v.DataModifica = DateTime.Now;
                    v.Operatore = Operatore.Utente.IdUtente;
                    v.IdNote = null;
                    v.Annullato = false;
                    valutazione_provider.Save(v);

                    valutazione_progetto.Add(v);

                    int i = 1;
                    foreach (SiarLibrary.BandoValutatori bv in bando_valutatori)
                    {
                        SiarLibrary.ProgettoValutatori pv = new SiarLibrary.ProgettoValutatori();
                        pv.IdProgettoValutazione = v.Id;
                        pv.IdValutatore = bv.IdValutatore;
                        pv.Ordine = i;
                        pv.Presente = true;
                        valutatori_provider.Save(pv);
                        i++;
                    }

                    valutazione_provider.DbProviderObj.Commit();
                    ShowMessage("Variante correttamente predisposta alla valutazione;");
                }
                else Response.Redirect("Valutazione.aspx");
            }
            catch (Exception ex) { valutazione_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPredisponiFirma_Click(object sender, EventArgs e)
        {

            try
            {
                string messaggio = "";
                if (!Variante.FirmaPredispostaRup)
                {
                    messaggio += " Variante / variazione finanziaria predisposta correttamente alla firma del Responsabile di Misura.";

                    try
                    {
                        // invio la notifica del rilascio al responsabile del bando e a quello provinciale                
                        SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
                        System.Collections.ArrayList destinatari = new System.Collections.ArrayList();
                        foreach (SiarLibrary.BandoResponsabili r in new SiarBLL.BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                        {
                            SiarLibrary.Utenti u = utenti_provider.GetById(r.IdUtente);
                            if (u != null && u.Email != null) destinatari.Add(u.Email.Value);
                        }
                        if (destinatari.Count > 0)
                        {
                            SiarLibrary.Impresa impresa_var = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                            SiarLibrary.Bando bando_var = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
                            SiarLibrary.Email em = new SiarLibrary.Email("Avviso di inoltro alla Firma dell'istruttoria per la Richiesta di Variante/Variazione finanziaria"

                            + " (Progetto: " + Progetto.IdProgetto + ")",
                                "<html><body>Si comunica che l'istruttore " + Operatore.Utente.Nominativo + "<br />ha predisposto alla sua firma, come Responsabile del Bando, la Richiesta di Variante/Variazione finanziaria"
                            + " per il Progetto ID: " + Progetto.IdProgetto + "."
                            + "<br /><ul><li style='width:650px'>Bando: " + bando_var.Descrizione + "</li><li>Scadenza: " + bando_var.DataScadenza + "</li><br />"
                            + "<li>CF/P.Ia: " + impresa_var.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                            + impresa_var.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                            + "<br />Tale istanza è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                            + "/private/ppagamento/gestionelavori.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                            + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                            + "<br />Si prega di non rispondere a questa email.</body></html>");
                            em.SetHtmlBodyMessage(true);
                            em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                        }
                    }
                    catch { /* per il momento non faccio nulla */}

                }
                else
                    messaggio = "Predisposizione alla firma annullata correttamente, è ora possibile riprendere la modifica dei dati dell'istruttoria della variante/ variazione finanziaria.";
                PredisponiAllaFirma(Variante.FirmaPredispostaRup);

                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void PredisponiAllaFirma(bool annulla_predisposizione)
        {
            SiarBLL.VariantiCollectionProvider Var_prov = new SiarBLL.VariantiCollectionProvider();
            SiarLibrary.Varianti var = Var_prov.GetById(Variante.IdVariante);
            var.FirmaPredispostaRup = !annulla_predisposizione;
            Var_prov.Save(var);
            Variante = var;

            //DomandaPagamento.FirmaPredispostaRup = !annulla_predisposizione;
            //new SiarBLL.DomandaDiPagamentoCollectionProvider().Save(DomandaPagamento);
            //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);

        }

    }
}