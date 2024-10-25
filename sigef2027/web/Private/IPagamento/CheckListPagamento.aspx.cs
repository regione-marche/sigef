using SiarBLL;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace web.Private.IPagamento
{
    public partial class CheckListPagamento : SiarLibrary.Web.IstruttoriaPagamentoPage
    {
        SiarLibrary.SanzioniCollection sanzioni;
        SiarBLL.SanzioniCollectionProvider sanzioni_provider = new SiarBLL.SanzioniCollectionProvider();

        bool strumenti_finanziari = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //aggiorno la domanda di pagamento in sessione per evitare possibili bug di integrazione o altri dati non aggiornati
            DomandaPagamento = new DomandaDiPagamentoCollectionProvider().GetById(DomandaPagamento.IdDomandaPagamento);

            ucChecklist.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
            ucChecklist.Fase = DomandaPagamento.CodFase;
            ucChecklist.Progetto = Progetto;
            ucFirmaDocumento.DocumentoFirmatoEvent = btnFirmaPost_Click;

            //btnCorrettivaRendicontazione.Disabled = DomandaPagamento.CodTipo == "ANT";
            txtSegnaturaAllegati.ReadOnly = DomandaPagamento.CodTipo != "ANT";
            if (DomandaPagamento.CodTipo == "SLD")
            {
                //btnAmmRenContainer.Visible = true;
                btnAmmissibilitaRendicontazione.Disabled = false;
                btnAmmissibilitaRendicontazione.Attributes.Add("onclick", "mostraEsitoVerificaRendicontazione();");
                if (string.IsNullOrEmpty(DomandaPagamento.VerificaPagamentiEsito)) txtEsitoDettaglioLunga.Text = "NON ESEGUITO.";
                else
                {
                    txtEsitoDettaglioLunga.Text = DomandaPagamento.VerificaPagamentiMessaggio;
                    txtEsitoDettaglioLunga.Text = txtEsitoDettaglioLunga.Text.Replace("<BR />", "\n\n");
                    txtEsitoData.Text = DomandaPagamento.VerificaPagamentiData;
                    txtEsito.Text = (DomandaPagamento.VerificaPagamentiEsito == "S" ? "POSITIVO" : "NEGATIVO");
                }
            }

            string TpAppalto = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(new SiarBLL.ProgettoCollectionProvider().GetById(DomandaPagamento.IdProgetto).IdBando);
            if (TpAppalto != null && TpAppalto == "Strumenti finanziari")
                strumenti_finanziari = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            System.Collections.ArrayList link_veloci = ucChecklist.StepDiReindirizzamento;

            if (link_veloci.Count == 0)
                tbLinkVeloci.Visible = false;
            else
            {
                foreach (string url in link_veloci)
                {
                    string urlLink = url;
                    string testo_bottone = url.Substring(url.LastIndexOf("/") + 1).Replace(".aspx?", "").Replace("Istruttoria", "");

                    string button = "<input type=button class='btn btn-secondary py-1 m-1' value='" + testo_bottone + "' onclick=\"location='" +
                        urlLink.Replace("~", HttpContext.Current.Request.ApplicationPath) + "&iddom=" + DomandaPagamento.IdProgetto + "'\" />";
                    tbLinkVeloci.Controls.Add(new LiteralControl(button));
                }

                if (strumenti_finanziari)
                {
                    string testo_bottone = "ContrattiEPagamenti";
                    string urlLink = "~/private/IPagamento/IstruttoriaContrattiEPagamenti.aspx?";

                    string button = "<input type=button class='btn btn-secondary py-1 m-1' value='" + testo_bottone + "' onclick=\"location='" +
                        urlLink.Replace("~", HttpContext.Current.Request.ApplicationPath) + "&iddom=" + DomandaPagamento.IdProgetto + "'\" />";
                    tbLinkVeloci.Controls.Add(new LiteralControl(button));
                }

                //if (DomandaPagamento.RichiedeAutovalutazione //se è attivo il flag per l'autovalutazione nel bando
                //        && !(DomandaPagamento.NaturaCup == "06" || DomandaPagamento.NaturaCup == "07")) //e se NON è un aiuto
                //{
                //    string testo_bottone = "Autovalutazione";
                //    string urlLink = "~/private/IPagamento/Autovalutazione.aspx?";

                //    string button = "<input type=button class=ButtonGrid style='margin:3px' value='" + testo_bottone + "' onclick=\"location='" +
                //        urlLink.Replace("~", HttpContext.Current.Request.ApplicationPath) + "&iddom=" + DomandaPagamento.IdProgetto + "'\" />";
                //    tbLinkVeloci.Rows[0].Cells[1].Controls.Add(new LiteralControl(button));
                //}

            }

            if (TipoModifica == 3)
                txtIstruttore.Text = Operatore.Utente.Nominativo;
            else
            {
                SiarLibrary.CollaboratoriXBandoCollection istruttori = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(
                    Bando.IdBando, Progetto.IdProgetto, null, null, true);
                if (istruttori.Count > 0) txtIstruttore.Text = istruttori[0].Nominativo;
                else txtIstruttore.Text = "Non ancora assegnato.";
            }

            if (sanzioni == null) sanzioni = sanzioni_provider.RilevaSanzioniXDomandaPagamento(DomandaPagamento.IdDomandaPagamento);
            if (sanzioni.Count == 0)
            {
                tableSanzioni.Rows[0].Cells[0].InnerHtml = "<p style='margin:20px;font-weight:bold;font-style:italic'>Nessuna sanzione rilevata. "
                    + (DomandaPagamento.CodTipo != "ANT" && AbilitaModifica ? "<a style='margin-left:20px' href=\"javascript:document.getElementById('ctl00_cphContenuto_btnNuovaSanzione').click();\">[NUOVA SANZIONE]</a>" : "") + "</p>";
                tableSanzioni.Rows[0].Cells[1].InnerHtml = "";
                tableSanzioni.Rows[1].Style.Add("display", "none");
            }
            else
            {
                foreach (SiarLibrary.Sanzioni s in sanzioni)
                    if (!s.Automatico && s.Ammontare == null)
                    {
                        btnVerifica.OnClientClick = "alert('Attenzione! Almeno una sanzione assegnata non risulta calcolata. Impossibile continuare.');return stopEvent(event);";
                        break;
                    }
                dgSanzioni.ItemDataBound += new DataGridItemEventHandler(dgSanzioni_ItemDataBound);
                dgSanzioni.MostraTotale(3, "Ammontare");
            }
            dgSanzioni.DataSource = sanzioni;
            dgSanzioni.DataBind();

            // step visite in azienda
            if (DomandaPagamento.PredispostaAControllo)
            {
                tableControlli.Visible = true;
                lstEsitoStep.DataBind();
                lstEsitoStep.SelectedValue = DomandaPagamento.VisitaInsituEsito;
                txtNoteVisitaInSitu.Text = DomandaPagamento.VisitaInsituNote;
                //txtNoteControlloInLoco.Text = DomandaPagamento.ControlloInlocoNote;
                //if (DomandaPagamento.ControlloInlocoEsito == "SI") tdEsitoControlloInLoco.InnerHtml = "<span style=\"color: #0b9007;\">SI</span>";
                //else if (DomandaPagamento.ControlloInlocoEsito == "NO") tdEsitoControlloInLoco.InnerHtml = "<span style=\"color: #be0202;\">NO</span>";
            }

            txtValutazioneLunga.Text = DomandaPagamento.ValutazioneIstruttore;
            if (DomandaPagamento.SegnaturaApprovazione != null)
            {
                txtSegnatura.Text = DomandaPagamento.SegnaturaApprovazione;
                //imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + DomandaPagamento.SegnaturaApprovazione + "');");
                imgSegnatura.Attributes.Add("onclick", "MostraProtocolloNew('" + DomandaPagamento.SegnaturaApprovazione + "');");
                imgSegnatura.Style.Add("cursor", "pointer");


            }
            if (DomandaPagamento.SegnaturaSecondaApprovazione != null)
            {
                txtSegnaturaSeconda.Text = DomandaPagamento.SegnaturaSecondaApprovazione;
                //imgSecondaSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + DomandaPagamento.SegnaturaSecondaApprovazione + "');");
                imgSecondaSegnatura.Attributes.Add("onclick", "MostraProtocolloNew('" + DomandaPagamento.SegnaturaSecondaApprovazione + "');");
                imgSecondaSegnatura.Style.Add("cursor", "pointer");
            }
            txtSegnaturaAllegati.Text = DomandaPagamento.SegnaturaAllegati;
            txtDataAntimafia.Text = DomandaPagamento.DataCertificazioneAntimafia;

            //pregresso
            bool Pregresso = false;
            string StPregresso = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_PregressoIDomandaPag(Bando.IdBando);
            if (StPregresso == "True")
                Pregresso = true;
            if (Pregresso)
            {
                btnInserisciSegnatura.Visible = true;
                btnFirma.Visible = false;
                ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
            }
            else
            {
                btnInserisciSegnatura.Visible = false;
                btnFirma.Visible = true;
            }

            //Gestione pulsante predisponi alla firma
            if (DomandaPagamento.SegnaturaApprovazione == null)
            {
                if (DomandaPagamento.FirmaPredispostaRup != null && DomandaPagamento.FirmaPredispostaRup)
                {
                    btnPredisponi.Text = "Annulla predisposizione";
                    btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
                    //btnVerifica.Enabled = false;
                }
                else
                {
                    //btnVerifica.Enabled = true;
                }
                btnPredisponi.Enabled = TipoModifica == 3;

                //se l'istruttore coincide con il RUP nascondo la predisposizione alla firma
                if ((new SiarBLL.BandoResponsabiliCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true, true).Count > 0)
                       && new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, Progetto.IdProgetto, Operatore.Utente.IdUtente, null, true).Count > 0)
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

            //controlli per richiesta integrazioni
            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
            {
                btnFirma.Enabled = false;
                btnFirma.ToolTip = "Non è possibile firmare e inviare al protocollo perchè sono presenti delle richieste integrazioni non risolte.";
                pInIntegrazione.Visible = true;
            }

            base.OnPreRender(e);
        }

        void dgSanzioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.Sanzioni s = (SiarLibrary.Sanzioni)e.Item.DataItem;
                //ho memorizzato il numero di investimenti in cui ho rilevato la sanzione nel campo idinvestimento
                //per non dover definire un altro campo
                if (s.Livello == "O") e.Item.Cells[2].Text = "nr. " + s.IdInvestimento + " investimenti interessati";
                else if (!s.Automatico) e.Item.Cells[2].Text = "<input type='button' style='width:100px' class='ButtonGrid' value='" + (AbilitaModifica ? "Modifica" : "Visualizza")
                    + "' onclick=\"modificaSanzione('" + s.CodTipo + "')\" />";
            }
        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                DomandaPagamento = PagamentoProvider.GetById(DomandaPagamento.IdDomandaPagamento);
                DomandaPagamento.SegnaturaAllegati = txtSegnaturaAllegati.Text;
                DomandaPagamento.DataCertificazioneAntimafia = txtDataAntimafia.Text;
                DomandaPagamento.ValutazioneIstruttore = txtValutazioneLunga.Text;
                if (DomandaPagamento.PredispostaAControllo) VerificaRequisitiVisiteAziendali();
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);

                string esito = ucChecklist.VerificaChecklist();
                bool istruttoria_variazione_positiva = VerificaRequisitiVariazioneAccertata(ref esito);
                PagamentoProvider.DeterminaImportoErogabileDomandaPagamento(DomandaPagamento, esito == "SI", Operatore);

                SiarLibrary.CollaboratoriXBandoCollection istruttori = new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(
                    Bando.IdBando, Progetto.IdProgetto, null, null, true);
                int idIstruttoreAssegato = 0;
                if (istruttori.Count > 0)
                    idIstruttoreAssegato = istruttori[0].IdUtente;
                else txtIstruttore.Text = "Non ancora assegnato.";

                switch (esito)
                {
                    case "SI":
                        btnFirma.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        if (!DomandaPagamento.PredispostaAControllo)
                        {
                            btnPredisponiAControllo.Enabled = true;
                            btnFirma.Enabled = false;
                            btnInserisciSegnatura.Enabled = false;
                        }
                        else if (DomandaPagamento.VisitaInsituEsito != "SI" && DomandaPagamento.VisitaInsituEsito != "ND")
                        {
                            btnInserisciSegnatura.Enabled = false;
                            btnFirma.Enabled = false;
                            ShowError("La domanda non soddisfa i requisiti obbligatori riguardanti le visite di controllo in azienda. Impossibile continuare.");
                            return;
                        }
                        // se l'operatore non è il funzionario istruttore ma un collaboratore il bottone firma deve restare disabilitato
                        if (this.Operatore.Utente.IdUtente != idIstruttoreAssegato)
                            btnFirma.Enabled = TipoModifica == 3;
                        ShowMessage("Checklist verificata correttamente. La domanda soddisfa tutti i requisiti obbligatori imposti dalla checklist.");
                        break;
                    case "NO":
                        if (!istruttoria_variazione_positiva)
                            ShowError("La variazione accertata non soddisfa tutti i requisiti obbligatori imposti dalla checklist, la domanda di aiuto verrà a DECADERE e il suo stato sarà impostata su ESCLUSA.");
                        else if (DomandaPagamento.CodTipo == "SLD") ShowError("La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist, la domanda di aiuto verrà a DECADERE e il suo stato sarà impostata su ESCLUSA.");
                        else ShowError("La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist.");
                        btnFirma.Enabled = true;
                        btnInserisciSegnatura.Enabled = true;
                        break;
                    default: ShowError(esito); break;
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private bool VerificaRequisitiVariazioneAccertata(ref string esito)
        {
            //esito istruttoria varianzione accertata in fase di istruttoria
            bool istruttoria_variazione_positiva = true;
            SiarLibrary.BandoRequisitiVarianteCollection bando_requisiti_variante;
            SiarLibrary.VariantiEsitiRequisitiCollection requisiti_variante_istruttore;
            if (DomandaPagamento.IdVariazioneAccertata != null)
            {
                bando_requisiti_variante = new SiarBLL.BandoRequisitiVarianteCollectionProvider().Find(Progetto.IdBando, "VI");
                requisiti_variante_istruttore = new SiarBLL.VariantiEsitiRequisitiCollectionProvider().Find(DomandaPagamento.IdVariazioneAccertata, null);
                if (requisiti_variante_istruttore.Count == 0 || bando_requisiti_variante.Count == 0)
                    throw new Exception("Non sono stati verificati tutti i requisiti imposti dalla checklist di istruttoria della variazione degli investimenti accertata. Impossibile continuare.");
                else
                {
                    foreach (SiarLibrary.BandoRequisitiVariante r in bando_requisiti_variante)
                    {
                        SiarLibrary.VariantiEsitiRequisiti v = requisiti_variante_istruttore.CollectionGetById(DomandaPagamento.IdVariazioneAccertata, r.IdRequisito);
                        if (r.Obbligatorio && (v == null || v.EsitoPositivoIstruttore == null || !v.EsitoPositivoIstruttore))
                        {
                            esito = "NO";
                            istruttoria_variazione_positiva = false;
                            break;
                        }
                    }
                }
            }
            return istruttoria_variazione_positiva;
        }

        private void VerificaRequisitiVisiteAziendali()
        {
            DomandaPagamento.VisitaInsituEsito = lstEsitoStep.SelectedValue;
            //controllo sulla correttezza dello step visita in situ
            SiarLibrary.VisiteAziendaliCollection visite_in_situ = new SiarBLL.VisiteAziendaliCollectionProvider().Find(null,
                DomandaPagamento.IdDomandaPagamento, ucIDomandaPagamento.Impresa.IdImpresa, "VIS", Progetto.IdProgetto, null);
            if (visite_in_situ.Count > 0)
            {
                if (visite_in_situ[0].ControlloConcluso) DomandaPagamento.VisitaInsituEsito = "SI";
                else DomandaPagamento.VisitaInsituEsito = "NO";
                lstEsitoStep.Enabled = false;
            }
            else if (lstEsitoStep.SelectedValue == "SI") DomandaPagamento.VisitaInsituEsito = "NO";

            DomandaPagamento.VisitaInsituNote = txtNoteVisitaInSitu.Text;
            //DomandaPagamento.ControlloInlocoNote = txtNoteControlloInLoco.Text;
            //DomandaPagamento.ControlloInlocoEsito = PagamentoProvider.StepControlliInLocoDomandaPagamento(DomandaPagamento.IdDomandaPagamento);
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            // i collaboratori all'istruttoria non possono firmare l'istruttoria.
            if (TipoModifica != 3)
            {
                ShowError("Solo il funzionario istruttore può firmare l'istruttoria.");
                return;
            }
            if (new SiarBLL.CorrettivaRendicontazioneCollectionProvider().Find(DomandaPagamento.IdDomandaPagamento, false, false).Count > 0)
                ShowError("La correttiva di rendicontazione per la presente domanda di pagamento ha uno o più spostamenti ancora IN LAVORAZIONE, impossibile continuare.");
            else ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
        }


        protected void btnFirmaPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                string esito = ucChecklist.VerificaChecklist();
                bool istruttoria_variazione_positiva = VerificaRequisitiVariazioneAccertata(ref esito);
                SiarBLL.VariantiCollectionProvider variante_provider = new SiarBLL.VariantiCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarLibrary.Varianti variazione_accertata = null;
                if (DomandaPagamento.IdVariazioneAccertata != null)
                    variazione_accertata = variante_provider.GetById(DomandaPagamento.IdVariazioneAccertata);

                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                SiarLibrary.Protocollo documento_interno = new SiarLibrary.Protocollo(Bando.CodEnte);
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                documento_interno.setDocumento("checklist_istruttoria_" + DomandaPagamento.Descrizione + "_domanda_"
                      + ucIDomandaPagamento.Progetto.IdProgetto + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                string oggetto = "Checklist di istruttoria " + DomandaPagamento.Descrizione.Value.ToUpper()
                        + " per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita iva/Codice fiscale: " + ucIDomandaPagamento.Impresa.Cuaa 
                        + "\n Ragione sociale: " + ucIDomandaPagamento.Impresa.RagioneSociale
                        + "\n N° Domanda: " + Progetto.IdProgetto;
                string identificativo_paleo = documento_interno.DocumentoInterno(oggetto, ss[4]);

                SiarLibrary.VstatiProceduraliCollection stati = new SiarBLL.VstatiProceduraliCollectionProvider().
                    Find(null, DomandaPagamento.CodFase, null/*Progetto.Ordine*/);
                if (stati.Count == 0) throw new Exception("si è verificato un errore sul server. Impossibile continuare");
                if (DomandaPagamento.SegnaturaApprovazione == null)
                {
                    try
                    {
                        PagamentoProvider.DbProviderObj.BeginTran();
                        DomandaPagamento.Approvata = esito == "SI";
                        DomandaPagamento.SegnaturaApprovazione = identificativo_paleo.Replace("ID:", "").Trim();
                        DomandaPagamento.CfIstruttore = Operatore.Utente.CfUtente;
                        DomandaPagamento.DataApprovazione = DateTime.Now;
                        PagamentoProvider.Save(DomandaPagamento);

                        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj);
                        if (esito == "SI")
                        {
                            progetto_provider.CambioStatoProgetto(Progetto, stati[0].CodStato, identificativo_paleo, Operatore);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto) progetto_provider.CambioStatoProgetto(p, stati[0].CodStato, Operatore);
                            }
                            if (variazione_accertata != null && istruttoria_variazione_positiva)
                            {
                                variazione_accertata.Approvata = true;
                                variante_provider.Save(variazione_accertata);
                            }
                        }
                        else
                        {
                            // cambio stato alla domanda di aiuto la metto esclusa
                            if (DomandaPagamento.CodTipo == "SLD" || !istruttoria_variazione_positiva)
                            {
                                progetto_provider.CambioStatoProgetto(Progetto, "E", identificativo_paleo, Operatore);
                                if (Progetto.IdProgIntegrato != null)
                                {
                                    foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                        if (p.IdProgetto != Progetto.IdProgetto) progetto_provider.CambioStatoProgetto(p, "E", Operatore);
                                }
                                if (variazione_accertata != null)
                                {
                                    variazione_accertata.Approvata = false;
                                    variante_provider.Save(variazione_accertata);
                                }
                            }
                        }
                        PagamentoProvider.DbProviderObj.Commit();
                        Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                        ucIDomandaPagamento.loadData();
                        
                    }
                    catch (Exception exc)
                    {
                        PagamentoProvider.DbProviderObj.Rollback();
                        string oggettoEmail = "Errore nel cambio di stato del progetto nr." + Progetto.IdProgetto;
                        string testEmail = "Segnatura documento interno protocollato: " + identificativo_paleo +
                            "\nErrore: " + exc.Message;
                        EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                        throw;
                    }
                }
                else if (DomandaPagamento.SegnaturaSecondaApprovazione == null)
                {
                    try
                    {
                        PagamentoProvider.DbProviderObj.BeginTran();
                        DomandaPagamento.Approvata = esito == "SI";
                        DomandaPagamento.SegnaturaSecondaApprovazione = identificativo_paleo;
                        DomandaPagamento.CfIstruttore = Operatore.Utente.CfUtente;
                        DomandaPagamento.DataApprovazione = DateTime.Now;
                        PagamentoProvider.Save(DomandaPagamento);

                        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj);
                        if (esito == "SI")
                        {
                            progetto_provider.CambioStatoProgetto(Progetto, stati[0].CodStato, identificativo_paleo, null, Operatore, false, true, false);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto)
                                        progetto_provider.CambioStatoProgetto(p, stati[0].CodStato, Operatore, false, true, false);
                            }
                            if (variazione_accertata != null && istruttoria_variazione_positiva)
                            {
                                variazione_accertata.Approvata = true;
                                variante_provider.Save(variazione_accertata);
                            }
                        }
                        else
                        {
                            progetto_provider.AnnullaUltimoCambioStatoProgetto(Progetto, false);
                            Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto) progetto_provider.AnnullaUltimoCambioStatoProgetto(p, false);
                            }
                            // cambio stato alla domanda di aiuto la metto esclusa
                            if (DomandaPagamento.CodTipo == "SLD" || !istruttoria_variazione_positiva)
                            {
                                progetto_provider.CambioStatoProgetto(Progetto, "E", identificativo_paleo, Operatore);
                                if (Progetto.IdProgIntegrato != null)
                                {
                                    foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                        if (p.IdProgetto != Progetto.IdProgetto) progetto_provider.CambioStatoProgetto(p, "E", Operatore);
                                }
                                if (variazione_accertata != null)
                                {
                                    variazione_accertata.Approvata = false;
                                    variante_provider.Save(variazione_accertata);
                                }
                            }
                        }
                        PagamentoProvider.DbProviderObj.Commit();
                        Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                        ucIDomandaPagamento.loadData();
                    }
                    catch (Exception exc)
                    {
                        PagamentoProvider.DbProviderObj.Rollback();
                        string oggettoEmail = "Errore nel cambio di stato del progetto nr." + Progetto.IdProgetto;
                        string testEmail = "Segnatura documento interno protocollato: " + identificativo_paleo +
                            "\nErrore: " + exc.Message;
                        EmailUtility.SendEmailToTeamSigef(exc, oggettoEmail, testEmail);
                        throw;
                    }
                }
                btnVerifica.Enabled = false;
                ShowMessage("Checklist di istruttoria domanda di " + DomandaPagamento.Descrizione + " firmata e protocollata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }
            finally { ucFirmaDocumento.FileFirmato = null; }
        }

        protected void btnPredisponiAControllo_Click(object sender, EventArgs e)
        {
            try
            {
                DomandaPagamento.DataPredisposizioneAControllo = DateTime.Now;
                DomandaPagamento.PredispostaAControllo = true;
                PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (new SiarBLL.CorrettivaRendicontazioneCollectionProvider().Find(DomandaPagamento.IdDomandaPagamento, false, false).Count > 0)
                    ShowError("La correttiva di rendicontazione per la presente domanda di pagamento ha uno o più spostamenti ancora IN LAVORAZIONE, impossibile continuare.");
                else  RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnaturaIns.Text == null || txtSegnaturaIns.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new SiarLibrary.Protocollo().ProtocolloEsistente(txtSegnaturaIns.Text))
                        throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.DocumentoNonValido);
                }

                string esito = ucChecklist.VerificaChecklist();
                bool istruttoria_variazione_positiva = VerificaRequisitiVariazioneAccertata(ref esito);
                SiarBLL.VariantiCollectionProvider variante_provider = new SiarBLL.VariantiCollectionProvider(PagamentoProvider.DbProviderObj);
                SiarLibrary.Varianti variazione_accertata = null;
                if (DomandaPagamento.IdVariazioneAccertata != null)
                    variazione_accertata = variante_provider.GetById(DomandaPagamento.IdVariazioneAccertata);
                if (esito != "SI" && esito != "NO") throw new Exception(esito);
                SiarLibrary.VstatiProceduraliCollection stati = new SiarBLL.VstatiProceduraliCollectionProvider().
                    Find(null, DomandaPagamento.CodFase, null/*Progetto.Ordine*/);
                if (stati.Count == 0) throw new Exception("si è verificato un errore sul server. Impossibile continuare");
                if (DomandaPagamento.SegnaturaApprovazione == null)
                {
                    try
                    {
                        PagamentoProvider.DbProviderObj.BeginTran();
                        DomandaPagamento.Approvata = esito == "SI";
                        DomandaPagamento.SegnaturaApprovazione = ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text;
                        DomandaPagamento.CfIstruttore = Operatore.Utente.CfUtente;
                        DomandaPagamento.DataApprovazione = Convert.ToDateTime(txtData.Text);
                        PagamentoProvider.Save(DomandaPagamento);

                        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj);
                        if (esito == "SI")
                        {
                            progetto_provider.CambioStatoProgettoPregresso(Progetto, stati[0].CodStato, ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto) 
                                        progetto_provider.CambioStatoProgettoPregresso(p, stati[0].CodStato, null, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                            } 
                            if (variazione_accertata != null && istruttoria_variazione_positiva)
                            {
                                variazione_accertata.Approvata = true;
                                variante_provider.Save(variazione_accertata);
                            }
                        }
                        else
                        {
                            // cambio stato alla domanda di aiuto la metto esclusa
                            if (DomandaPagamento.CodTipo == "SLD" || !istruttoria_variazione_positiva)
                            {
                                progetto_provider.CambioStatoProgettoPregresso(Progetto, "E", ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                                if (Progetto.IdProgIntegrato != null)
                                {
                                    foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                        if (p.IdProgetto != Progetto.IdProgetto) 
                                            progetto_provider.CambioStatoProgettoPregresso(p, "E", null , Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                                }
                                if (variazione_accertata != null)
                                {
                                    variazione_accertata.Approvata = false;
                                    variante_provider.Save(variazione_accertata);
                                }
                            }
                        }
                        PagamentoProvider.DbProviderObj.Commit();
                        Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                        ucIDomandaPagamento.loadData();
                    }
                    catch (Exception exc)
                    {
                        PagamentoProvider.DbProviderObj.Rollback();
                        ShowError(exc); 
                    }
                }
                else if (DomandaPagamento.SegnaturaSecondaApprovazione == null)
                {
                    try
                    {
                        PagamentoProvider.DbProviderObj.BeginTran();
                        DomandaPagamento.Approvata = esito == "SI";
                        DomandaPagamento.SegnaturaSecondaApprovazione = ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text;
                        DomandaPagamento.CfIstruttore = Operatore.Utente.CfUtente;
                        DomandaPagamento.DataApprovazione = Convert.ToDateTime(txtData.Text);
                        PagamentoProvider.Save(DomandaPagamento);

                        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider(PagamentoProvider.DbProviderObj);
                        if (esito == "SI")
                        {
                            progetto_provider.CambioStatoProgettoPregresso(Progetto, stati[0].CodStato, ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto)
                                        progetto_provider.CambioStatoProgettoPregresso(p, stati[0].CodStato, null, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                            }
                            if (variazione_accertata != null && istruttoria_variazione_positiva)
                            {
                                variazione_accertata.Approvata = true;
                                variante_provider.Save(variazione_accertata);
                            }
                        }
                        else
                        {
                            progetto_provider.AnnullaUltimoCambioStatoProgetto(Progetto, false);
                            Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                            if (Progetto.IdProgIntegrato != null)
                            {
                                foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                    if (p.IdProgetto != Progetto.IdProgetto) progetto_provider.AnnullaUltimoCambioStatoProgetto(p, false);
                            }
                            // cambio stato alla domanda di aiuto la metto esclusa
                            if (DomandaPagamento.CodTipo == "SLD" || !istruttoria_variazione_positiva)
                            {
                                progetto_provider.CambioStatoProgettoPregresso(Progetto, "E", ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text, Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                                if (Progetto.IdProgIntegrato != null)
                                {
                                    foreach (SiarLibrary.Progetto p in progetto_provider.Find(null, null, Progetto.IdProgetto, null, null, null, null))
                                        if (p.IdProgetto != Progetto.IdProgetto) 
                                            progetto_provider.CambioStatoProgettoPregresso(p, "E", null , Convert.ToDateTime(txtData.Text), Operatore, false, false, false);
                                }
                                if (variazione_accertata != null)
                                {
                                    variazione_accertata.Approvata = false;
                                    variante_provider.Save(variazione_accertata);
                                }
                            }
                        }
                        PagamentoProvider.DbProviderObj.Commit();
                        Progetto = progetto_provider.GetById(Progetto.IdProgetto);
                        ucIDomandaPagamento.loadData();
                    }
                    catch (Exception exc)
                    {
                        PagamentoProvider.DbProviderObj.Rollback();
                        ShowError(exc); 
                    }
                }
                btnVerifica.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura dell'istruttoria della domanda di pagamento sono state salvate correttamente.");
                AbilitaModifica = false;
                btnFirma.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
            }
            catch (Exception ex)
            {
                btnInserisciSegnatura_Click(sender, e);
                ShowError("Attenzione! " + ex.Message);
            }
        }



        #region sanzioni

        protected void btnAssegnaSanzioni_Click(object sender, EventArgs e)
        {
            try
            {
                int num_sanzioni_comminate = 0, num_sanzioni_esistenti = 0, num_misure_non_attive = 0, num_pagamenti_non_richiesti = 0;
                string[] sanzioni_selezionate = ((SiarLibrary.Web.CheckColumn)dgNuovaSanzione.Columns[3]).GetSelected();
                if (sanzioni_selezionate.Length == 0) throw new Exception("Selezionare almeno una sanzione.");
                foreach (string s in sanzioni_selezionate)
                {
                    int retval = sanzioni_provider.AssegnaSanzioneDomandaPagamento(DomandaPagamento.IdDomandaPagamento, s, Operatore);
                    switch (retval)
                    {
                        case 0:
                            num_sanzioni_esistenti++;
                            break;
                        case -1:
                            num_misure_non_attive++;
                            break;
                        case -2:
                            num_pagamenti_non_richiesti++;
                            break;
                        default:
                            num_sanzioni_comminate++;
                            break;
                    }
                }
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("Sanzioni comminate: " + num_sanzioni_comminate.ToString()
                    + ".<br />Sanzioni non comminate perchè già assegnate: " + num_sanzioni_esistenti.ToString()
                    + (num_misure_non_attive > 0 ? ".<br />Sanzioni non comminate perchè la domanda di aiuto non attiva le misure interessate: " + num_misure_non_attive.ToString() : "")
                    + (num_pagamenti_non_richiesti > 0 ? ".<br />Sanzioni non comminate perchè nessun pagamento richiesto per le misure interessate: " + num_pagamenti_non_richiesti.ToString() : ""));

            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopupTemplate();"); ShowError(ex); }
        }

        protected void btnNuovaSanzione_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.SanzioniCollection sanzioni = sanzioni_provider.GetProgrammazioneSanzioni(Bando.IdProgrammazione, "D");
                if (sanzioni.Count == 0) dgNuovaSanzione.Titolo = "Non ci sono sanzioni da comminare a livello di domanda.";
                else dgNuovaSanzione.DataSource = sanzioni;
                dgNuovaSanzione.DataBind();
                RegisterClientScriptBlock("mostraPopupTemplate('divNuovaSanzione','divBackGroundForm');");
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopupTemplate();"); ShowError(ex); }
        }

        protected void btnCalcolaSanzione_Click(object sender, EventArgs e)
        {
            string messaggio = "Sanzione calcolata correttamente.";
            try
            {
                string codTipo = hdnModificaSanzione.Text;
                if (codTipo == null || codTipo.Length > 10) throw new Exception("Sanzione selezionata non valida.");
                SiarLibrary.SanzioniCollection sanzioni_da_calcolare = sanzioni_provider.Find(null, codTipo, DomandaPagamento.IdDomandaPagamento, null, null, "D");
                if (sanzioni_da_calcolare.Count < 1) throw new Exception("Nessuna sanzione selezionata.");
                else
                {
                    sanzioni_provider.DbProviderObj.BeginTran();
                    SiarLibrary.SanzioniCollection sanzioni_calcolate = new SiarLibrary.SanzioniCollection();
                    try
                    {
                        foreach (SiarLibrary.Sanzioni sanzione in sanzioni_da_calcolare)
                        {
                            if (string.IsNullOrEmpty(sanzione.QuerySql))
                                throw new Exception("La procedura di calcolo della sanzione selezionata non è stata configurata. Impossibile continuare.");
                            sanzione.Motivazione = txtModificaSanzioneMotivazioni.Text;

                            #region parametri
                            if (sanzione.DurataSelezionato)
                            {
                                if (sanzione.DurataNumerico)
                                {
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("txtDurataNumerico" + sanzione.CodTipo + "_text"))
                                        {
                                            sanzione.ValoreDurata = new SiarLibrary.NullTypes.DecimalNT(Request.Form[s]);
                                        }
                                }
                                else
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("hdnValoreParametroD" + sanzione.CodTipo) && !string.IsNullOrEmpty(Request.Form[s]))
                                            sanzione.Durata = new SiarLibrary.NullTypes.IntNT(Request.Form[s]);
                            }
                            if (sanzione.GravitaSelezionato)
                            {
                                if (sanzione.GravitaNumerico)
                                {
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("txtGravitaNumerico" + sanzione.CodTipo + "_text"))
                                        {
                                            sanzione.ValoreGravita = new SiarLibrary.NullTypes.DecimalNT(Request.Form[s]);
                                        }
                                }
                                else
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("hdnValoreParametroG" + sanzione.CodTipo) && !string.IsNullOrEmpty(Request.Form[s]))
                                            sanzione.Gravita = new SiarLibrary.NullTypes.IntNT(Request.Form[s]);
                            }
                            if (sanzione.EntitaSelezionato)
                            {
                                if (sanzione.EntitaNumerico)
                                {
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("txtEntitaNumerico" + sanzione.CodTipo + "_text"))
                                        {
                                            sanzione.ValoreEntita = new SiarLibrary.NullTypes.DecimalNT(Request.Form[s]);
                                        }
                                }
                                else
                                    foreach (string s in Request.Form.AllKeys)
                                        if (s.EndsWith("hdnValoreParametroE" + sanzione.CodTipo) && !string.IsNullOrEmpty(Request.Form[s]))
                                            sanzione.Entita = new SiarLibrary.NullTypes.IntNT(Request.Form[s]);
                            }
                            #endregion

                            sanzioni_calcolate.Add(sanzioni_provider.CalcoloSanzionePagamento(sanzione));
                        }
                        sanzioni_provider.DbProviderObj.Commit();
                    }
                    catch (Exception ex)
                    {
                        sanzioni_provider.DbProviderObj.Rollback();
                        RegisterClientScriptBlock("chiudiPopupTemplate();");
                        switch (ex.Message)
                        {
                            case "INPUT_ERROR":
                                messaggio = "Attenzione! Il calcolo di questa sanzione richiede dei parametri in ingresso che non sono stati specificati.";
                                break;
                            case "SPESA_FINANZIATA_ERROR":
                                messaggio = "Attenzione! Spesa totale finanziata per la domanda di aiuto non valida.";
                                break;
                            case "PAGAMENTO_NON_ISTRUITO_ERROR":
                                messaggio = "Attenzione! Importo totale ammesso a pagamento non valido.";
                                break;
                            default:
                                messaggio = ex.Message;
                                break;
                        }
                        sanzioni_calcolate = sanzioni_da_calcolare;
                    }
                    ModificaSanzione(sanzioni_calcolate, messaggio);
                }
            }
            catch (Exception exc) { ShowError(exc); }
        }

        protected void btnModificaSanzionePost_Click(object sender, EventArgs e)
        {
            string codTipo = hdnModificaSanzione.Text;
            if (codTipo == null || codTipo.Length > 10) { ShowError("Sanzione selezionata non valida."); return; }
            try
            {
                SiarLibrary.SanzioniCollection sanzioni_da_modificare = sanzioni_provider.Find(null, codTipo, DomandaPagamento.IdDomandaPagamento, null, null, "D");
                if (sanzioni_da_modificare.Count < 1) throw new Exception("Nessuna sanzione selezionata.");
                else ModificaSanzione(sanzioni_da_modificare, null);
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopupTemplate();"); ShowError(ex); }
        }

        private void ModificaSanzione(SiarLibrary.SanzioniCollection ss, string messaggio)
        {
            SiarLibrary.Sanzioni sanzione = ss[0];
            txtModificaSanzioneDescrizione.Text = sanzione.Titolo;
            txtModificaSanzioneMotivazioni.Text = sanzione.Motivazione;
            if (ss.Count > 1)
            {
                decimal ammontare = 0;
                foreach (SiarLibrary.Sanzioni s in ss)
                    if (s.Ammontare != null) ammontare += s.Ammontare;
                sanzione.Ammontare = ammontare;
                ss = new SiarLibrary.SanzioniCollection();
                ss.Add(sanzione);
            }
            txtImportoSanzione.Text = sanzione.Ammontare;
            dgModificaSanzione.DataSource = ss;
            dgModificaSanzione.ItemDataBound += new DataGridItemEventHandler(dgModificaSanzione_ItemDataBound);
            dgModificaSanzione.DataBind();
            RegisterClientScriptBlock("mostraPopupTemplate('divModificaSanzione','divBackGroundForm');"
                + (!string.IsNullOrEmpty(messaggio) ? "alert('" + messaggio + "');" : ""));
        }

        void dgModificaSanzione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                SiarLibrary.Sanzioni s = (SiarLibrary.Sanzioni)e.Item.DataItem;
                if (s.DurataSelezionato)
                {
                    if (s.DurataNumerico)
                    {
                        HtmlTable tbl = new HtmlTable();
                        tbl.Width = "120px";
                        tbl.CellPadding = 0;
                        tbl.CellSpacing = 0;
                        HtmlTableRow tr = new HtmlTableRow();
                        HtmlTableCell tdi = new HtmlTableCell();
                        tdi.Style.Add("border", "0");
                        tdi.Width = "20px";
                        tdi.InnerHtml = "&nbsp;";
                        if (s.DurataTooltip != null) tdi.InnerHtml = "<a href=\"javascript:alert('" + s.DurataTooltip
                                 + "')\"><img src='../../images/info.ico' style='width:20px;height:20px' /></a>";
                        tr.Cells.Add(tdi);
                        HtmlTableCell td = new HtmlTableCell();
                        td.Align = "center";
                        td.Style.Add("border", "0");
                        SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                        cb.ID = "txtDurataNumerico" + s.CodTipo;
                        if (s.ValoreDurata != null) cb.Text = string.Format("{0:N}", s.ValoreDurata.Value);
                        cb.Width = new Unit(100);
                        td.Controls.Add(cb);
                        tr.Cells.Add(td);
                        tbl.Rows.Add(tr);
                        e.Item.Cells[2].Controls.Add(tbl);
                    }
                    else
                    {
                        e.Item.Cells[2].Attributes.Add("id", "tdSelParDurata");
                        HyperLink lnk = new HyperLink();
                        lnk.NavigateUrl = "javascript:sceltaParametroSanzione(" + s.IdSanzione + ",'" + s.CodTipo + "','D','tdSelParDurata')";
                        HtmlImage img = new HtmlImage();
                        img.Src = "../../images/folderopen.png";
                        img.Alt = "Scelta dei valori del parametro";
                        lnk.Controls.Add(img);
                        e.Item.Cells[2].Controls.Add(lnk);

                        SiarLibrary.Web.Hidden hdn = new SiarLibrary.Web.Hidden();
                        hdn.ID = "hdnValoreParametroD" + s.CodTipo;
                        hdn.Text = s.Durata;
                        e.Item.Cells[2].Controls.Add(hdn);

                        Label lbl = new Label();
                        lbl.ID = "lblValoreParametroD" + s.CodTipo;
                        lbl.Text = "  " + s.DescrizioneDurata;
                        e.Item.Cells[2].Controls.Add(lbl);
                    }
                }
                else e.Item.Cells[2].Text = s.DescrizioneDurata;

                if (s.GravitaSelezionato)
                {
                    if (s.GravitaNumerico)
                    {
                        HtmlTable tbl = new HtmlTable();
                        tbl.Width = "120px";
                        tbl.CellPadding = 0;
                        tbl.CellSpacing = 0;
                        HtmlTableRow tr = new HtmlTableRow();
                        HtmlTableCell tdi = new HtmlTableCell();
                        tdi.Style.Add("border", "0");
                        tdi.Width = "20px";
                        tdi.InnerHtml = "&nbsp;";
                        if (s.GravitaTooltip != null) tdi.InnerHtml = "<a href=\"javascript:alert('" + s.GravitaTooltip
                                 + "')\"><img src='../../images/info.ico' style='width:20px;height:20px' /></a>";
                        tr.Cells.Add(tdi);
                        HtmlTableCell td = new HtmlTableCell();
                        td.Align = "center";
                        td.Style.Add("border", "0");
                        SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                        cb.ID = "txtGravitaNumerico" + s.CodTipo;
                        if (s.ValoreGravita != null) cb.Text = string.Format("{0:N}", s.ValoreGravita.Value);
                        cb.Width = new Unit(100);
                        td.Controls.Add(cb);
                        tr.Cells.Add(td);
                        tbl.Rows.Add(tr);
                        e.Item.Cells[1].Controls.Add(tbl);
                    }
                    else
                    {
                        e.Item.Cells[1].Attributes.Add("id", "tdSelParGravita");
                        HyperLink lnk = new HyperLink();
                        lnk.NavigateUrl = "javascript:sceltaParametroSanzione(" + s.IdSanzione + ",'" + s.CodTipo + "','G','tdSelParGravita')";
                        HtmlImage img = new HtmlImage();
                        img.Src = "../../images/folderopen.png";
                        img.Alt = "Scelta dei valori del parametro";
                        lnk.Controls.Add(img);
                        e.Item.Cells[1].Controls.Add(lnk);

                        SiarLibrary.Web.Hidden hdn = new SiarLibrary.Web.Hidden();
                        hdn.ID = "hdnValoreParametroG" + s.CodTipo;
                        hdn.Text = s.Gravita;
                        e.Item.Cells[1].Controls.Add(hdn);

                        Label lbl = new Label();
                        lbl.ID = "lblValoreParametroG" + s.CodTipo;
                        lbl.Text = "  " + s.DescrizioneGravita;
                        e.Item.Cells[1].Controls.Add(lbl);
                    }
                }
                else e.Item.Cells[1].Text = s.DescrizioneGravita;

                if (s.EntitaSelezionato)
                {
                    if (s.EntitaNumerico)
                    {
                        HtmlTable tbl = new HtmlTable();
                        tbl.Width = "120px";
                        tbl.CellPadding = 0;
                        tbl.CellSpacing = 0;
                        HtmlTableRow tr = new HtmlTableRow();
                        HtmlTableCell tdi = new HtmlTableCell();
                        tdi.Style.Add("border", "0");
                        tdi.Width = "20px";
                        tdi.InnerHtml = "&nbsp;";
                        if (s.EntitaTooltip != null) tdi.InnerHtml = "<a href=\"javascript:alert('" + s.EntitaTooltip
                                 + "')\"><img src='../../images/info.ico' style='width:20px;height:20px' /></a>";
                        tr.Cells.Add(tdi);
                        HtmlTableCell td = new HtmlTableCell();
                        td.Align = "center";
                        td.Style.Add("border", "0");
                        SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                        cb.ID = "txtEntitaNumerico" + s.CodTipo;
                        if (s.ValoreEntita != null) cb.Text = string.Format("{0:N}", s.ValoreEntita.Value);
                        cb.Width = new Unit(100);
                        td.Controls.Add(cb);
                        tr.Cells.Add(td);
                        tbl.Rows.Add(tr);
                        e.Item.Cells[0].Controls.Add(tbl);
                    }
                    else
                    {
                        e.Item.Cells[0].Attributes.Add("id", "tdSelParEntita");
                        HyperLink lnk = new HyperLink();
                        lnk.NavigateUrl = "javascript:sceltaParametroSanzione(" + s.IdSanzione + ",'" + s.CodTipo + "','E','tdSelParEntita');";
                        HtmlImage img = new HtmlImage();
                        img.Src = "../../images/folderopen.png";
                        img.Alt = "Scelta dei valori del parametro";
                        lnk.Controls.Add(img);
                        e.Item.Cells[0].Controls.Add(lnk);

                        SiarLibrary.Web.Hidden hdn = new SiarLibrary.Web.Hidden();
                        hdn.ID = "hdnValoreParametroE" + s.CodTipo;
                        hdn.Text = s.Entita;
                        e.Item.Cells[0].Controls.Add(hdn);

                        Label lbl = new Label();
                        lbl.ID = "lblValoreParametroE" + s.CodTipo;
                        lbl.Text = "  " + s.DescrizioneEntita;
                        e.Item.Cells[0].Controls.Add(lbl);
                    }
                }
                else e.Item.Cells[0].Text = s.DescrizioneEntita;
            }
        }

        protected void btnEliminaSanzione_Click(object sender, EventArgs e)
        {
            string codTipo = hdnModificaSanzione.Text;
            if (codTipo == null || codTipo.Length > 10) { ShowError("Sanzione selezionata non valida."); return; }
            try
            {
                SiarLibrary.SanzioniCollection sanzioni_da_eliminare = sanzioni_provider.Find(null, codTipo, DomandaPagamento.IdDomandaPagamento, null, null, "D");
                if (sanzioni_da_eliminare.Count < 1) ShowError("Nessuna sanzione selezionata.");
                else
                {
                    sanzioni_provider.DeleteCollection(sanzioni_da_eliminare);
                    ShowMessage("Sanzione eliminata correttamente.");
                }
            }
            catch (Exception ex) { RegisterClientScriptBlock("chiudiPopupTemplate();"); ShowError(ex); }
        }

        #endregion

        protected void btnPredisponi_Click(object sender, EventArgs e)
        {

            try
            {
                string messaggio="";
                if (!DomandaPagamento.FirmaPredispostaRup)
                {
                    //if (DomandaPagamento.PredispostaAControllo) VerificaRequisitiVisiteAziendali();
                    //PagamentoProvider.AggiornaDomandaDiPagamentoIstruttore(DomandaPagamento, Operatore);

                    //string esito = ucChecklist.VerificaChecklist();
                    //bool istruttoria_variazione_positiva = VerificaRequisitiVariazioneAccertata(ref esito);
                    //PagamentoProvider.DeterminaImportoErogabileDomandaPagamento(DomandaPagamento, esito == "SI", Operatore);
                    //switch (esito)
                    //{
                    //    case "SI":
                    //        if (!DomandaPagamento.PredispostaAControllo)
                    //        {
                    //            throw new Exception("La domanda non è stata predisposta alle visite di controllo in azienda. Impossibile continuare.");
                    //        }
                    //        else if (DomandaPagamento.VisitaInsituEsito != "SI" && DomandaPagamento.VisitaInsituEsito != "ND")
                    //        {
                    //            throw new Exception("La domanda non soddisfa i requisiti obbligatori riguardanti le visite di controllo in azienda. Impossibile continuare.");

                    //        }
                    //        messaggio += "Checklist verificata correttamente. La domanda soddisfa tutti i requisiti obbligatori imposti dalla checklist.";
                    //        break;
                    //    case "NO":
                    //        if (!istruttoria_variazione_positiva)
                    //            messaggio += "La variazione accertata non soddisfa tutti i requisiti obbligatori imposti dalla checklist, la domanda di aiuto verrà a DECADERE e il suo stato sarà impostata su ESCLUSA.";
                    //        else if (DomandaPagamento.CodTipo == "SLD") messaggio += "La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist, la domanda di aiuto verrà a DECADERE e il suo stato sarà impostata su ESCLUSA.";
                    //        else messaggio += "La domanda non soddisfa tutti i requisiti obbligatori imposti dalla checklist.";
                    //        break;
                    //    default: ShowError(esito); break;
                    //}
                    messaggio += " Domanda di pagamento predisposta correttamente alla firma del Responsabile di Misura.";

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
                            SiarLibrary.Email em = new SiarLibrary.Email("Avviso di inoltro alla Firma dell'istruttoria per la Richiesta di"
                            +(DomandaPagamento.InIntegrazione!= null && DomandaPagamento.InIntegrazione == true ? " integrazione della domanda di" : "" ) 
                            +" "+ DomandaPagamento.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                                "<html><body>Si comunica che l'istruttore " + Operatore.Utente.Nominativo + "<br />ha predisposto alla sua firma, come Responsabile del Bando, la Richiesta di " + (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione == true ? "integrazione della domanda di " : "") + DomandaPagamento.Descrizione
                            + " per il Progetto ID: " + Progetto.IdProgetto + "."
                            + "<br /><ul><li style='width:650px'>Bando: " + Bando.Descrizione + "</li><li>Scadenza: " + Bando.DataScadenza + "</li><br />"
                            + "<li>CF/P.Ia: " + ucIDomandaPagamento.Impresa.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                            + ucIDomandaPagamento.Impresa.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
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
                    messaggio = "Predisposizione alla firma annullata correttamente, è ora possibile riprendere la modifica dei dati della domanda di pagamento.";
                PredisponiAllaFirma(DomandaPagamento.FirmaPredispostaRup);

                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void PredisponiAllaFirma(bool annulla_predisposizione)
        {
            SiarBLL.DomandaDiPagamentoCollectionProvider domapag_prov = new SiarBLL.DomandaDiPagamentoCollectionProvider();
            SiarLibrary.DomandaDiPagamento domPag = domapag_prov.GetById(DomandaPagamento.IdDomandaPagamento);
            domPag.FirmaPredispostaRup = !annulla_predisposizione;
            domapag_prov.Save(domPag);
            DomandaPagamento = domPag;

            //DomandaPagamento.FirmaPredispostaRup = !annulla_predisposizione;
            //new SiarBLL.DomandaDiPagamentoCollectionProvider().Save(DomandaPagamento);
            //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);

        }

        protected void btnMostraProtocollo_Click(object sender, EventArgs e)
        {
            try
            {
                string segnatura = hdnSegnatura.Value;
                if (string.IsNullOrEmpty(segnatura) || segnatura == "undefined")
                    throw new Exception("Segnatura vuota");

                modaleMostraProtocollo.Segnatura = segnatura;
                RegisterClientScriptBlock(modaleMostraProtocollo.Mostra);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex.Message);
            }
        }
    }
}