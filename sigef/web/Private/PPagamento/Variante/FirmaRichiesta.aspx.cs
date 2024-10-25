using System;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Linq;
using FirmaRemotaManager;
using SiarBLL;
using System.IO;
using SiarLibrary;
using System.Security.Cryptography;

namespace web.Private.PPagamento.Variante
{
    public partial class FirmaRichiesta : SiarLibrary.Web.VariantePage
    {
        bool VerificaRequisiti = false;
        bool RequisitiVerificati = true;
        SiarLibrary.PersoneXImprese rlegale;
        SiarLibrary.VariantiEsitiRequisitiCollection esiti_requisiti;
        SiarBLL.VariantiEsitiRequisitiCollectionProvider esiti_provider = new SiarBLL.VariantiEsitiRequisitiCollectionProvider();
        SiarLibrary.Bando Bando = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = btnPost_Click;
            modaleFirmaEsterna.ScaricaDocumentoFirmato = btnScaricaDocumento_Click;
            modaleFirmaEsterna.DocumentoFirmatoEvent = btnFirmaEsternaProtocolla_Click;

            if (IsPostBack)
            {
                //in base al pulsante che premo nascondo il control della firma esterna o quello di Calamaio
                Control control = null;
                string controlName = Page.Request.Params["__EVENTTARGET"];
                if (!String.IsNullOrEmpty(controlName))
                {
                    control = Page.FindControl(controlName);
                }
                else
                {
                    string controlId;
                    Control foundControl;
                    foreach (string ctl in Page.Request.Form)
                    {
                        if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                        {
                            controlId = ctl.Substring(0, ctl.Length - 2);
                            foundControl = Page.FindControl(controlId);
                        }
                        else
                        {
                            foundControl = Page.FindControl(ctl);
                        }
                        if (!(foundControl is System.Web.UI.WebControls.Button || foundControl is ImageButton))
                            continue;
                        control = foundControl;
                        break;
                    }
                }
                if (control != null && control.ClientID != null)
                {
                    string CtrlID = control.ClientID.Replace('_', '$');

                    //Se premo il pulsante di presentazione domanda o della firma digitale tolgo la firma esterna
                    if (CtrlID == btnFirma.UniqueID
                        || CtrlID.Contains("ucFirmaDocumentoCalamaio") //Firma remota
                        || CtrlID.Contains("btnFirma2")) //Firma token
                    {
                        modaleFirmaEsterna.Visible = false;
                        modaleFirmaEsterna.Dispose();
                    }

                    if (CtrlID == btnFirmaEsterna.UniqueID
                        || CtrlID.Contains("btnFirmaEsternaVerifica"))
                    {
                        ucFirmaDocumento.Visible = false;
                        ucFirmaDocumento.Dispose();

                        if (CtrlID == btnFirmaEsterna.UniqueID)
                            ScaricaDocumento();
                    }
                }
            }

            Bando = new SiarBLL.BandoCollectionProvider().GetById(Progetto.IdBando);
            if (Bando == null) Redirect("../gestionelavori.aspx", "La domanda selezionata non è valida.", true);
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!IsPostBack && AbilitaModifica) VerificaRequisiti = true;
            esiti_requisiti = esiti_provider.Find(Variante.IdVariante, null);
            SiarLibrary.BandoRequisitiVarianteCollection requisiti = new SiarBLL.BandoRequisitiVarianteCollectionProvider()
                .Find(Progetto.IdBando, Variante.CodTipo).FiltroProcedura(true, null);
            dgRequisiti.DataSource = requisiti;
            if (requisiti.Count == 0) dgRequisiti.Titolo = "NESSUN REQUISITO DI CONTROLLO RICHIESTO DAL BANDO.";
            else dgRequisiti.ItemDataBound += new DataGridItemEventHandler(dgRequisiti_ItemDataBound);
            dgRequisiti.DataBind();

            if (Request.Form[btnVerifica.UniqueID] != null)
            {
                if (RequisitiVerificati) ShowMessage("Checklist verificata. Ora è possibile rendere definitiva la richiesta.");
                else ShowError("Checklist di presentazione non verificata. Impossibile rilasciare la richiesta.");
            }
            //btnFirma.Disabled = !AbilitaModifica || !RequisitiVerificati || !IsPostBack;
            //if (!btnFirma.Disabled)
            //{
            //    if (rlegale == null) rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(ucWorkFlowVarianti.Impresa.IdRapprlegaleUltimo);
            //    if (rlegale == null) btnFirma.Attributes.Add("onclick", "alert('Attenzione! I dati anagrafici dell`azienda non sono validi. Si prega di contattare l`helpdesk.');");
            //    else btnFirma.Attributes.Add("onclick", "firmaDocumento('../../../FirmaDocumento.htm?type=VARIANTE&idvar="
            //            + Variante.IdVariante + "&firmatario=" + rlegale.CodiceFiscale + "');");
            //}

            btnFirmaEsterna.Enabled = 
                btnFirma.Enabled = AbilitaModifica 
                                    && RequisitiVerificati 
                                    && Variante.Segnatura == null 
                                    && IsPostBack;

            //Gestione pulsante predisponi firma
            if (Variante.FirmaPredisposta)
            {
                btnPredisponi.Text = "Annulla predisposizione";
                btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
            }
            btnPredisponi.Enabled = TipoModifica == 2 && Variante.Segnatura == null;
            rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(ucWorkFlowVarianti.Impresa.IdRapprlegaleUltimo);
            btnFirmaEsterna.Enabled = 
                btnFirma.Enabled = Variante.Segnatura == null 
                                    && ((!Variante.FirmaPredisposta && TipoModifica == 2) 
                                        || (Variante.FirmaPredisposta && rlegale.IdPersona == Operatore.Utente.IdPersonaFisica));

            //se rappresentante legale nascondo predisposizione
            if (rlegale.IdPersona == Operatore.Utente.IdPersonaFisica)
                trPredisposizione.Visible = false;


            if (Variante.Segnatura != null)
            {
                btnStampaRicevuta.Disabled = false;
                btnStampaRicevuta.Attributes.Add("onclick", "SNCVisualizzaReport('rptRicevutaProtocollazioneVariante',1,'IdVariante="
                    + Variante.IdVariante + "');");

                //SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(null, null, Variante.IdVariante, null, null, null, null, null);
                //int numeroAllegati = allegati.Count;

                //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, Variante.Segnatura);
                bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Variante, Variante.IdVariante, Variante.Segnatura);

                if (!allegatiProtocollatiOk)
                {
                    if (rlegale == null) rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(ucWorkFlowVarianti.Impresa.IdRapprlegaleUltimo);
                    rowProtocolliAllegati.Visible = true;
                    btnProtocollaAllegati.Enabled = Variante.Operatore.Value == Operatore.Utente.CfUtente || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica; ;
                }
                else
                {
                    rowProtocolliAllegati.Visible = false;
                    btnProtocollaAllegati.Enabled = false;
                }
            }

            if (!Bando.FirmaRichiesta)
                btnFirmaEsterna.Visible = false;
            else
            {
                modaleFirmaEsterna.TxtButton = "Firma la richiesta";
                modaleFirmaEsterna.Conferma = "Attenzione, rendere la richiesta definitiva? Non sarà più possibile modificare i dati";
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
                if (VerificaRequisiti) VerificaRequisito(ref requisito, ref requisito_variante);
                if (RequisitiVerificati && requisito.Obbligatorio &&
                    (requisito_variante == null || requisito_variante.Esito == null || requisito_variante.Esito != "SI"))
                    RequisitiVerificati = false;
                if (requisito_variante != null)
                {
                    esiti_requisiti.Remove(requisito_variante);
                    if (requisito_variante.Esito == "SI") dgi.Cells[3].Style.Add("color", "#0b9007");
                    else dgi.Cells[3].Style.Add("color", "#be0202");
                    dgi.Cells[3].Text = requisito_variante.Esito;
                    if (requisito_variante.Esito == "ER")
                        dgi.Cells[3].Text = "Attenzione! Errore nella esecuzione della verifica, si prega di contattare l'helpdesk.";
                }
            }
        }

        private void VerificaRequisito(ref SiarLibrary.BandoRequisitiVariante requisito, ref SiarLibrary.VariantiEsitiRequisiti requisito_variante)
        {
            string esito;
            try { esito = VerificaStepAutomatico(ref requisito) ? "SI" : "NO"; }
            catch { esito = "ER"; }
            if (requisito_variante == null)
            {
                requisito_variante = new SiarLibrary.VariantiEsitiRequisiti();
                requisito_variante.IdVariante = Variante.IdVariante;
                requisito_variante.IdRequisito = requisito.IdRequisito;
            }
            requisito_variante.CodEsito = esito;
            requisito_variante.Data = DateTime.Now;
            requisito_variante.CfOperatore = Operatore.Utente.CfUtente;
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
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                var filePrincipale = Convert.FromBase64String(ucFirmaDocumento.FileFirmato);
                ProtocollaVariante(filePrincipale);
                ucFirmaDocumento.FileFirmato = null;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);
            System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
            // cerco gli allegati non protocollati
            SiarBLL.ArchivioFileCollectionProvider ff = new SiarBLL.ArchivioFileCollectionProvider();
            SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
            SiarLibrary.AllegatiProtocollatiCollection apc = allegatiProtocollatiProvider.Find(null, null, Variante.IdVariante, null, null, null, false, null);
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
                allegatoProtocollo.Add("tipo_origine", "variante");
                allegatoProtocollo.Add("id_origine", Variante.IdVariante);
                allegatiProtocollo.Add(allegatoProtocollo);
            }

            protocolloAll.addAllegatiProtocollo(allegatiProtocollo, Variante.Segnatura);

            //SiarLibrary.AllegatiProtocollatiCollection allegatiVariante = allegatiProtocollatiProvider.Find(null, null, Variante.IdVariante, null, null, null, null, null);

            //bool allegatiProtocollatiOk = checkAllegatiProtocollati(allegatiVariante.Count, Variante.Segnatura);
            bool allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Variante, Variante.IdVariante, Variante.Segnatura);


            if (allegatiProtocollatiOk) ShowMessage("Richiesta di " + Variante.TipoVariante + " firmata e protocollata correttamente.");
            else ShowError("Richiesta di " + Variante.TipoVariante + " firmata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitiVerificati = true;
                VerificaRequisiti = true;
                if (Variante.CuaaEntrante != null) SiarLibrary.DbStaticProvider.ControlloCambioBeneficiarioVariante(Variante.IdVariante,
                    false, VarianteProvider.DbProviderObj);
            }
            catch (Exception ex) { RequisitiVerificati = false; VerificaRequisiti = false; ShowError(ex); }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                ControlliPreFirma();
                ucFirmaDocumento.FirmaObbligatoria = Bando.FirmaRichiesta;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, Variante.IdVariante);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void ControlliPreFirma()
        {
            string errore = new DomandaDiPagamentoCollectionProvider().ControlloVarianteRilasciabile(Progetto.IdProgetto, false, false);
            if (errore != null)
                throw new Exception(errore);

            rlegale = new PersoneXImpreseCollectionProvider().GetById(ucWorkFlowVarianti.Impresa.IdRapprlegaleUltimo);
            if (rlegale == null) 
                throw new Exception("L'impresa non ha un rappresentante legale valido. Impossibile continuare.");
        }

        
        protected void btnPredisponi_Click(object sender, EventArgs e)
        {
            try
            {
                Variante.FirmaPredisposta = !Variante.FirmaPredisposta;
                VarianteProvider.Save(Variante);
                ucWorkFlowVarianti.loadData();
                //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                string messaggio = "Domanda di aiuto predisposta correttamente alla firma.";
                if (!Variante.FirmaPredisposta) messaggio = "Predisposizione alla firma annullata correttamente, è ora possibile riprendere la modifica dei dati della domanda.";
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void ProtocollaVariante(byte[] fileDaProtocollare)
        {
            try
            {
                if (fileDaProtocollare == null)
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                rlegale = new PersoneXImpreseCollectionProvider().GetById(ucWorkFlowVarianti.Impresa.IdRapprlegaleUltimo);
                if (rlegale == null) throw new Exception("I dati anagrafici dell`azienda non sono validi. Si prega di contattare l`helpdesk.");

                SiarLibrary.Protocollo protocollo = new SiarLibrary.Protocollo(Bando.CodEnte);
                protocollo.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                protocollo.setDocumento("richiesta_di_variante_" + Variante.CodTipo + "_domanda_nr_" + Progetto.IdProgetto + ".pdf", fileDaProtocollare);

                string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                string oggetto = "Richiesta di " + Variante.TipoVariante.Value.Trim() + " per la domanda di aiuto nr. " + Progetto.IdProgetto
                    + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\n" + ss[3] + "\n Partita iva/Codice fiscale: " + ucWorkFlowVarianti.Impresa.Cuaa
                    + "\n Ragione sociale: " + ucWorkFlowVarianti.Impresa.RagioneSociale;

                // carico gli allegati su paleo 
                SiarLibrary.VariantiAllegatiCollection allegati = new VariantiAllegatiCollectionProvider().Find(Variante.IdVariante, null, null);
                foreach (SiarLibrary.VariantiAllegati a in allegati)
                {
                    try
                    {
                        if (a.IdFile != null)
                        {
                            SiarLibrary.ArchivioFile f = new ArchivioFileCollectionProvider().GetById(a.IdFile);
                            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                            protocollo.addAllegato(f.NomeFile, f.HashCode);
                        }
                    }
                    catch (Exception ex) { }
                }

                if (!Bando.FirmaRichiesta)
                {
                    object sessione_cohesion = Session["COHESION_TOKEN"];
                    if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                        throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                    protocollo.addAllegato("Autenticazione_Operatore.xml", protocollo.GetSHA256(System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString())));
                }

                string segnatura = protocollo.ProtocolloIngresso(oggetto, ss[4]);

                try
                {
                    int nr_investimenti_contributo_duplicato = VarianteProvider.DuplicaContributoInvestimentiVariante(Variante.IdVariante);
                    if (nr_investimenti_contributo_duplicato <= 0) throw new Exception("Si è verificato un errore (codice DPLCNTR) nella procedura. Impossibile continuare.");
                    Variante.Segnatura = segnatura;
                    Variante.DataModifica = DateTime.Now;
                    Variante.Operatore = Operatore.Utente.CfUtente;
                    Variante.CodEnte = Operatore.Utente.CodEnte;
                    VarianteProvider.Save(Variante);

                    // punteggio "dichiarato" per controllo che in istruttoria non venga aumentato
                    new ProgettoCollectionProvider().CalcoloPunteggioDomandaDiAiuto(Progetto.IdProgetto, Variante.IdVariante, null, false, Operatore.Utente.CfUtente);

                    try
                    {
                        if (Variante.CodTipo.FindValueIn("AT", "VA"))
                        {
                            SiarLibrary.Impresa Impresa = new ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
                            UtentiCollectionProvider utenti_provider = new UtentiCollectionProvider();
                            System.Collections.ArrayList destinatari = new System.Collections.ArrayList();
                            foreach (SiarLibrary.BandoResponsabili r in new BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                            {
                                SiarLibrary.Utenti u = utenti_provider.GetById(r.IdUtente);
                                if (u != null && u.Email != null) destinatari.Add(u.Email.Value);
                            }
                            if (destinatari.Count > 0)
                            {
                                //string s = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
                                SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione Richiesta di " + Variante.TipoVariante + " (Progetto: " + Progetto.IdProgetto + ")",
                                    "<html><body>Si comunica che con prot. " + Variante.Segnatura + "<br />è stata presentata la Richiesta di " + Variante.TipoVariante
                                + " per il Progetto ID: " + Progetto.IdProgetto + "."
                                + "<br /><ul><li style='width:650px'>Bando: " + Bando.Descrizione + "</li><li>Scadenza: " + Bando.DataScadenza + "</li><br />"
                                + "<li>CF/P.Iva: " + Impresa.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: " + Impresa.RagioneSociale + "</li><br />"
                                + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                                + "<br />Tale istanza è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                                + "/private/ppagamento/gestionelavori.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                                em.SetHtmlBodyMessage(true);
                                em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                            }
                        }
                    }
                    catch { }

                    System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();
                    if (!Bando.FirmaRichiesta)
                    {
                        // carico il token di cohesion come allegato alla domanda
                        object sessione_cohesion = Session["COHESION_TOKEN"];
                        if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                            throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                        //protocollo.addAllegato("Autenticazione_Operatore.xml", System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString()), "xml");
                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();

                        all.Descrizione = "Autenticazione_Operatore.xml";
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                        all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                        //a.Documento.Estensione = estensione;
                        //a.NumeroPagine = 1;
                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", -1);
                        allegatoProtocollo.Add("tipo_origine", "variante");
                        allegatoProtocollo.Add("id_origine", Variante.IdVariante);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }

                    // carico gli allegati su paleo /// spostato sopra riga 176 il 16/09/2019 per aggiornamento paleo 
                    //SiarLibrary.VariantiAllegatiCollection allegati = new SiarBLL.VariantiAllegatiCollectionProvider().Find(Variante.IdVariante, null, null);
                    //int numeroAllegati = 0;
                    SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
                    foreach (SiarLibrary.VariantiAllegati a in allegati)
                    {
                        try
                        {
                            if (a.IdFile != null)
                            {
                                SiarLibrary.ArchivioFile f = new ArchivioFileCollectionProvider().GetById(a.IdFile);
                                if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                                string estensione = null;
                                if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                                //protocollo.addAllegato(f.NomeFile, f.Contenuto, estensione);
                                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                all.Descrizione = f.NomeFile;
                                all.Documento = new SiarBLL.paleoWebService.File();
                                all.Documento.NomeFile = f.NomeFile;

                                System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                                allegatoProtocollo.Add("allegato", all);
                                allegatoProtocollo.Add("id_file", f.Id);
                                allegatoProtocollo.Add("tipo_origine", "variante");
                                allegatoProtocollo.Add("id_origine", Variante.IdVariante);
                                allegatiProtocollo.Add(allegatoProtocollo);

                                SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(null, null, Variante.IdVariante, null, null, f.Id, null, null);
                                if (exist.Count == 0)
                                {
                                    SiarLibrary.AllegatiProtocollati ap = new SiarLibrary.AllegatiProtocollati();
                                    ap.IdVariante = Variante.IdVariante;
                                    ap.IdProgetto = DBNull.Value;
                                    ap.IdDomandaPagamento = DBNull.Value;
                                    ap.IdIntegrazione = DBNull.Value;
                                    ap.IdFile = f.Id;
                                    ap.Protocollato = false;
                                    allegatiProtocollatiProvider.Save(ap);
                                    //numeroAllegati++;
                                }
                            }
                        }
                        catch (Exception ex) { }
                    }

                    SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(Bando.CodEnte);

                    protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, segnatura);
                    bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.Variante, Variante.IdVariante, segnatura);

                    if (allegatiProtocollatiOk) ShowMessage("Richiesta di " + Variante.TipoVariante + " firmata e protocollata correttamente.");
                    else ShowError("Richiesta di " + Variante.TipoVariante + " firmata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
                    btnVerifica.Enabled = false;
                }
                catch (Exception ex)
                {
                    string oggettoEmail = "Errore durante la protocollazione della richiesta di " + Variante.TipoVariante.Value.Trim();
                    string testEmail = "Domanda di aiuto: " + Progetto.IdProgetto + "\nSegnatura: " + segnatura + "\n\n" + ex.Message;
                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);

                    if (!string.IsNullOrEmpty(segnatura))
                        ShowError("Richiesta di " + Variante.TipoVariante + " firmata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
                    else
                        ShowError(ex);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void btnFirmaEsterna_Click(object sender, EventArgs e)
        {
            try
            {
                ControlliPreFirma();
                RegisterClientScriptBlock(modaleFirmaEsterna.Mostra);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private string BinaryToHex(byte[] data)
        {
            char[] hex = new char[data.Length * 2];

            for (int iter = 0; iter < data.Length; iter++)
            {
                byte hexChar = ((byte)(data[iter] >> 4));
                hex[iter * 2] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
                hexChar = ((byte)(data[iter] & 0xF));
                hex[(iter * 2) + 1] = (char)(hexChar > 9 ? hexChar + 0x37 : hexChar + 0x30);
            }
            return new string(hex);
        }

        protected void ScaricaDocumento()
        {
            var logInfo = new LogInfo();
            string esito = "OK";
            string dettaglioEsito = "File scaricato correttamente";
            ScaricamentoFirmaEsterna datiScaricamento = null;
            var scaricamentoFirmaEsternaProvider = new ScaricamentoFirmaEsternaCollectionProvider();

            try
            {
                //dati log
                logInfo.Operatore = Operatore.Utente.CfUtente;
                logInfo.TipoFirma = "esterna";
                logInfo.TipoDocumento = modaleFirmaEsterna.TipoDocumento;
                logInfo.ParametriDocumento = "IdVariante_" + Variante.IdVariante;
                logInfo.DownloadDocumentoCertificato = true;

                //nuovi dati per firma esterna 
                datiScaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(Variante.IdProgetto, null, Variante.IdVariante);
                if (datiScaricamento == null)
                {
                    datiScaricamento = new ScaricamentoFirmaEsterna();
                    datiScaricamento.OperatoreInserimento = Operatore.Utente.CfUtente;
                    datiScaricamento.DataInserimento = DateTime.Now;
                    datiScaricamento.IdProgetto = Variante.IdProgetto;
                    datiScaricamento.IdVariante = Variante.IdVariante;
                }

                modaleFirmaEsterna.loadDocumento(Operatore.Utente.CfUtente, Variante.IdVariante);
                var firmaEsternaAruba = new FirmaEsternaAruba();
                var file = modaleFirmaEsterna.FileCertificatoServer;
                var file_restituito = firmaEsternaAruba.FirmaAutomaticaProd(file);

                // genero l'hash
                HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                byte[] fileHashValue = alg.ComputeHash(file_restituito);
                string hash_code = BinaryToHex(fileHashValue);
                datiScaricamento.HashCodeFileConSigillo = hash_code;
                datiScaricamento.OperatoreModifica = Operatore.Utente.CfUtente;
                datiScaricamento.DataModifica = DateTime.Now;

                Session["doc"] = file_restituito;
                RegisterClientScriptBlock("window.open('../../../VisualizzaDocumento.aspx');");

                ShowMessage("File scaricato correttamente. Firmare esclusivamente questo documento e caricarlo.");
            }
            catch (Exception ex)
            {
                esito = "KO";
                dettaglioEsito = ex.Message;
                ShowError(ex.Message);
            }
            finally
            {
                logInfo.Esito = esito;
                logInfo.DataFirma = DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                modaleFirmaEsterna.LogSign(logInfo);
                scaricamentoFirmaEsternaProvider.Save(datiScaricamento);
            }
        }

        protected void btnScaricaDocumento_Click(object sender, EventArgs e)
        {
            ScaricaDocumento();
            RegisterClientScriptBlock(modaleFirmaEsterna.Mostra);
        }

        protected void btnFirmaEsternaProtocolla_Click(object sender, EventArgs e)
        {
            var logInfo = new LogInfo();
            string esito = "OK";
            string dettaglioEsito = "firma effettuata con successo";

            try
            {
                //dati log
                logInfo.Operatore = Operatore.Utente.CfUtente;
                logInfo.TipoFirma = "esterna";
                logInfo.TipoDocumento = modaleFirmaEsterna.TipoDocumento;
                logInfo.ParametriDocumento = "IdVariante_" + Variante.IdVariante;
                logInfo.DownloadDocumentoCertificato = false;

                if (modaleFirmaEsterna.FileCaricato.IdFile == null)
                    throw new Exception("Caricare prima il file");

                var logger = new Logger();
                var countOk = logger.CountLogDocumentoScaricatoOk(logInfo.TipoDocumento, logInfo.ParametriDocumento);

                if (countOk <= 0)
                    throw new Exception("Non è mai stato scaricato il documento con il certificato, impossibile accettare il file");

                var firmaEsternaAruba = new FirmaEsternaAruba();
                var file = new ArchivioFileCollectionProvider().GetById(modaleFirmaEsterna.FileCaricato.IdFile);
                string esitoVerifica;
                var estensione_file = Path.GetExtension(file.NomeFile);
                if (estensione_file == ".pdf")
                {
                    //nuovi controlli verifica file 
                    var scaricamentoFirmaEsternaProvider = new ScaricamentoFirmaEsternaCollectionProvider();
                    var scaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(Variante.IdProgetto, null, Variante.IdVariante);
                    if (scaricamento == null)
                        throw new Exception("Non è mai stato scaricato il documento con il certificato, impossibile accettare il file");

                    //verifico se l'hash del file caricato è uguale a quello scaricato
                    CryptoUtility crypto = new CryptoUtility();
                    HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                    var result = crypto.RemoveSignedDocument(file.Contenuto);
                    byte[] fileHashValue = alg.ComputeHash(result);
                    string hash_code = BinaryToHex(fileHashValue);

                    //Se voglio verificare il file con il sigillo
                    //Session["doc"] = result;
                    //RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

                    if (hash_code != scaricamento.HashCodeFileConSigillo)
                        throw new Exception("Il file caricato non è l'ultima versione del documento prodotto. Firmare l'ultimo documento scaricato e caricarlo.");

                    esitoVerifica = firmaEsternaAruba.VerificaFileFirmatoUtentePostFirmaAutomaticaProd(file.Contenuto, file.NomeFile);
                }
                else
                    throw new Exception("Estensione file " + estensione_file + " non accettata, si accettano solo file .pdf");

                if (esitoVerifica == "OK")
                    ProtocollaVariante(file.Contenuto);
                else
                    throw new Exception(esitoVerifica);
            }
            catch (Exception ex)
            {
                esito = "KO";
                dettaglioEsito = ex.Message;
                ShowError(ex.Message);
            }
            finally
            {
                logInfo.Esito = esito;
                logInfo.DataFirma = DateTime.Now;
                logInfo.DettaglioEsito = dettaglioEsito;
                modaleFirmaEsterna.LogSign(logInfo);
                modaleFirmaEsterna.FileCaricato.IdFile = null;
                modaleFirmaEsterna.ChiudiModale();
            }
        }
    }
}