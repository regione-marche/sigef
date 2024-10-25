using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using SiarLibrary;
using SiarLibrary.Extensions;
using SiarLibrary.Web;
using SiarBLL;
using System.Web.UI;
using FirmaRemotaManager;
using System.IO;

namespace web.Private.PPagamento
{
    public partial class FirmaRichiesta : DomandaPagamentoPage
    {
        DomandaPagamentoAllegatiCollectionProvider allegati_provider;
        PersoneXImprese rlegale;
        DomandaPagamentoAllegati allegato_selezionato;
        Bando Bando = null;
        PagamentiRichiestiCollectionProvider prichiesti_provider;

        IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        IntegrazioniPerDomandaDiPagamento integrazione_selezionata = null;
        IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        IntegrazioneSingolaDiDomanda integrazione_singola_selezionata = null;
        int id_integrazione_di_domanda_singola;

        private bool strumenti_finanziari = false;

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

            Bando = new BandoCollectionProvider().GetById(Progetto.IdBando);
            if (Bando == null) Redirect("../gestionelavori.aspx", "La domanda selezionata non è valida.", true);
            allegati_provider = new DomandaPagamentoAllegatiCollectionProvider();
            prichiesti_provider = new PagamentiRichiestiCollectionProvider(PagamentoProvider.DbProviderObj);
            int idAllegato;
            if (int.TryParse(hdnIdAllegato.Value, out idAllegato)) 
                allegato_selezionato = allegati_provider.GetById(idAllegato);

            if (allegato_selezionato == null && Session["id_allegato_integrazione"] != null)
            {
                allegato_selezionato = allegati_provider.GetById(int.Parse(Session["id_allegato_integrazione"].ToString()));
                Session["id_allegato_integrazione"] = null;
                hdnIdAllegato.Value = allegato_selezionato.IdAllegato;
            }

            var utAppalto = new BandoConfigCollectionProvider().GetBandoConfig_TpAppaltoDescrizione(Progetto.IdBando);
            if (utAppalto != null && utAppalto == "Strumenti finanziari")
                strumenti_finanziari = true;
        }

        protected override void OnPreRender(EventArgs e)
        {

            //pregresso
            bool Pregresso = false;
            string StPregresso = new BandoConfigCollectionProvider().GetBandoConfig_PregressoPDomandaPag(Bando.IdBando);
            if (StPregresso == "True")
                Pregresso = true;

            if (rlegale == null) rlegale = new PersoneXImpreseCollectionProvider().GetById(ucWorkflowPagamento.Impresa.IdRapprlegaleUltimo);
            //if (rRapprlegale == null) rRapprlegale = new PersoneXImpreseCollectionProvider().GetById(Azi);
            if (DomandaPagamento.CodTipo != "")
            {
                tbAllegati.Visible = true;
                lstNATipoEnte.Attributes.Add("onchange", "lstNATipoEnte_changed();");
                lstCategoria.Attributes.Add("onchange", "lstCategoria_changed();");
                lstCategoria.CommandText = @"SELECT CODICE , '('+FORMATO+') ' + SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE, FORMATO FROM TIPO_DOCUMENTO WHERE ATTIVO =1 ORDER BY CODICE DESC,DESCRIZIONE";
                lstCategoria.DataBind();
                ufcNAAllegato.AbilitaModifica = AbilitaModifica;
                txtNAEnte.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");
                if (allegato_selezionato != null)
                {
                    hdnIdAllegato.Value = allegato_selezionato.IdAllegato;
                    lstCategoria.SelectedValue = allegato_selezionato.CodTipoDocumento;
                    txtDescrizione.Text = allegato_selezionato.Descrizione;
                    if (allegato_selezionato.Formato == "S")
                    {
                        hdnCodEnte.Value = allegato_selezionato.IdComune.IsNullAlt(allegato_selezionato.CodEnteEmettitore);
                        lstNATipoEnte.SelectedValue = allegato_selezionato.IdComune != null ? "CM" : (allegato_selezionato.CodEnteEmettitore != null ? "PR" : "");
                        txtNAEnte.Text = allegato_selezionato.Ente;
                        txtNANumeroDoc.Text = allegato_selezionato.Numero;
                        txtNADatadoc.Text = allegato_selezionato.Data;
                    }
                    else if (allegato_selezionato.Formato == "D") ufcNAAllegato.IdFile = allegato_selezionato.IdFile;

                }
                RegisterClientScriptBlock("lstCategoria_changed();");
                DomandaPagamentoAllegatiCollection allegati = allegati_provider.Find(DomandaPagamento.IdDomandaPagamento, null, null);
                dgAllegati.DataSource = allegati;
                dgAllegati.SetTitoloNrElementi();
                dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
                dgAllegati.DataBind();
                if (allegati.Count > 0)
                {
                    int dimensione_totale_allegati = 0;
                    foreach (DomandaPagamentoAllegati a in allegati) dimensione_totale_allegati += a.DimensioneFile ?? 0;
                    divDimTotAllegati.InnerText = "Dimensione totale degli allegati: " + string.Format("{0:N0}", dimensione_totale_allegati) + " Kb";
                }

                // controllo massimali di pagamento solo saldo e sal
                string errore = PagamentoProvider.ControlloMassimaliDomandaPagamento(Progetto.IdProgetto, DomandaPagamento.IdDomandaPagamento);
                if (!string.IsNullOrEmpty(errore))
                {
                    ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! " + errore;
                    ucWorkflowPagamento.ProseguiAbilitato = false;
                    ShowError(errore);
                    AbilitaModifica = false;
                }

                if (Pregresso)
                {
                    tableRilascioDomandaPagamento.Visible = false;
                    tableRilascioDomandaPagamentoPregressa.Visible = true;
                    if (TipoModifica == 2 || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica)
                        btnInserisciSegnatura.Enabled = true;
                    ckAttivo.Attributes.Add("onchange", "DisabilitaLabel();");
                }
                else
                {
                    tableRilascioDomandaPagamento.Visible = true;
                    tableRilascioDomandaPagamentoPregressa.Visible = false;
                    if (DomandaPagamento.FirmaPredisposta != null && DomandaPagamento.FirmaPredisposta)
                    {
                        btnPredisponi.Text = "Annulla predisposizione";
                        btnPredisponi.Conferma = "Annullare la predisposizione alla firma?";
                    }
                    btnPredisponi.Enabled = TipoModifica == 2;
                    btnFirmaEsterna.Enabled 
                        = btnFirma.Enabled = (!DomandaPagamento.FirmaPredisposta && TipoModifica == 2) 
                                                || (DomandaPagamento.FirmaPredisposta && rlegale.IdPersona == Operatore.Utente.IdPersonaFisica);
                }
            }
            if (DomandaPagamento.Segnatura != null)
            {
                tableRilascioDomandaPagamento.Visible = true;
                tableRilascioDomandaPagamentoPregressa.Visible = false;

                btnPredisponi.Enabled = false;
                btnFirma.Enabled = false;
                btnFirmaEsterna.Enabled = false;
                btnStampaRicevuta.Disabled = false;
                btnStampaRicevuta.Attributes.Add("onclick", "SNCVisualizzaReport('rptRicevutaProtocollazioneDomandaPagamento',1,'IdDomandaPagamento="
                    + DomandaPagamento.IdDomandaPagamento + "');");

                if (!Pregresso)
                {
                    //AllegatiProtocollatiCollection allegati = new AllegatiProtocollatiCollectionProvider().Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, null, null);
                    //int numeroAllegati = allegati.Count;

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, DomandaPagamento.Segnatura);
                    bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.DomandaDiPagamento, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.Segnatura);

                    if (!allegatiProtocollatiOk)
                    {
                        rowProtocolliAllegati.Visible = true;
                        btnProtocollaAllegati.Enabled = DomandaPagamento.CfOperatore == Operatore.Utente.CfUtente || rlegale.IdPersona == Operatore.Utente.IdPersonaFisica;
                    }
                    else
                    {
                        rowProtocolliAllegati.Visible = false;
                        btnProtocollaAllegati.Enabled = false;
                    }
                }
                else
                {
                    tableRilascioDomandaPagamento.Visible = false;
                    tableRilascioDomandaPagamentoPregressa.Visible = true;
                    btnInserisciSegnatura.Enabled = false;
                }

            }
            else
            {
                modaleFirmaEsterna.TxtButton = "Presenta domanda";
                modaleFirmaEsterna.Conferma = "Attenzione, rendere la domanda di pagamento definitiva? Non sarà più possibile modificare i dati";
            }

            if (!Bando.FirmaRichiesta)
                btnFirmaEsterna.Visible = false;

            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                riempiCampiIntegrazione();

            base.OnPreRender(e);
        }

        private void riempiCampiIntegrazione()
        {
            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();

            if (Session["id_integrazione_domanda"] != null)
                integrazione_selezionata = integrazione_provider.GetById(int.Parse(Session["id_integrazione_domanda"].ToString()));
            else
            {
                var integrazioni_collection = integrazione_provider.Find(null, DomandaPagamento.IdDomandaPagamento, false, null);
                integrazione_selezionata = integrazioni_collection[0];
            }

            integrazione_selezionata = integrazione_provider.GetById(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento);

            if (integrazione_selezionata.SegnaturaIstruttore == null)
                Redirect(PATH_PPAGAMENTO + "GestioneLavori.aspx", "L'istruttore sta preparando una richiesta di integrazioni, impossibile accedere", true);

            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
            var integrazioni_singole_list = integrazioni_singole_collection.ToArrayList<IntegrazioneSingolaDiDomanda>();

            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "INV")
                    .Count() < 1)
                btnInvestimenti.Visible = false;
            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "GIU")
                    .Count() < 1
                    && integrazioni_singole_list
                        .Where(i => i.CodTipoIntegrazione == "PAG")
                        .Count() < 1)
                btnSpese.Visible = false;
            
            //var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "ALL", null, null, null);
            integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(null, null, "ALL", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            if (integrazione_singola_selezionata != null)
            {
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(id_integrazione_di_domanda_singola, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                riempiCampiIntegrazioneSingola();
            }

            dgIntegrazioni.DataSource = integrazioni_singole_collection;
            dgIntegrazioni.SetTitoloNrElementi();
            dgIntegrazioni.ItemDataBound += new DataGridItemEventHandler(dgIntegrazioni_ItemDataBound);
            dgIntegrazioni.DataBind();

            abilitaComponentiIntegrazione();
        }

        protected void abilitaComponentiIntegrazione()
        {
            ucWorkflowPagamento.InIntegrazione = true;
            trIntegrazioniRichieste.Visible = true;
            btnElimina.Enabled = false;
            tableRilascioDomandaPagamento.Visible = false;

            if (allegato_selezionato != null)
                abilitaCompontentiIntegrazione(false);
            else if (integrazione_selezionata.SegnaturaBeneficiario == null)
                abilitaCompontentiIntegrazione(true);
            else
            {
                var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "ALL", false, false, null);
                if (integrazioni_singole_collection.Count > 0)
                    abilitaCompontentiIntegrazione(true);
                else
                    abilitaCompontentiIntegrazione(false);
            }
        }

        protected void abilitaCompontentiIntegrazione(bool abilitazione)
        {
            btnSalva.Enabled = abilitazione;
            ufcNAAllegato.AbilitaModifica = abilitazione;
        }

        protected void riempiCampiIntegrazioneSingola()
        {
            //Campi istruttore
            txtDataRichiesta.Text = integrazione_singola_selezionata.DataRichiestaIntegrazioneIstruttore;
            txtTipoIntegrazione.Text = integrazione_singola_selezionata.DescrizioneTipoIntegrazione;
            txtNoteSingolaIntegrazioneIstruttore.Text = integrazione_singola_selezionata.NoteIntegrazioneIstruttore;
            comboCompletataSingolaIntegrazioneDomandaIstruttore.ClearSelection();
            string val_istruttore = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
                val_istruttore = "true";
            comboCompletataSingolaIntegrazioneDomandaIstruttore.Items.FindByValue(val_istruttore).Selected = true;

            //Campi beneficiario
            if (integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario == null)
                txtDataRilascio.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);
            else
                txtDataRilascio.Text = integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario;
            txtNoteSingolaIntegrazioneBeneficiario.Text = integrazione_singola_selezionata.NoteIntegrazioneBeneficiario;
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClearSelection();
            string val_beneficario = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario)
                val_beneficario = "true";
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.Items.FindByValue(val_beneficario).Selected = true;

            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
            {
                txtDataRilascio.Enabled = false;
                txtNoteSingolaIntegrazioneBeneficiario.Enabled = false;
                btnSalvaSingolaIntegrazione.Enabled = false;
                comboCompletataSingolaIntegrazioneDomandaBeneficiario.Enabled = false;
            }
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DomandaPagamentoAllegati allegato = (DomandaPagamentoAllegati)e.Item.DataItem;

                if (allegato.Formato == "S")
                    e.Item.Cells[3].Text = "<b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data + "<br /><b>Presso:</b> " + allegato.Ente
                    + "<br /><b>Descrizione:</b> " + e.Item.Cells[3].Text;

                if (allegato.IdFile == null)
                    e.Item.Cells[6].Text = "";
            }
        }
        protected void btnDettaglioPost_Click(object sender, EventArgs e) { }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                var filePrincipale = Convert.FromBase64String(ucFirmaDocumento.FileFirmato);
                ProtocollaDomandaDiPagamento(filePrincipale);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnProtocollaAllegati_Click(object sender, EventArgs e)
        {
            /*
            Protocollo protocolloAll = new Protocollo(Bando.CodEnte);
            ArrayList allegatiProtocollo = new ArrayList();
            // cerco gli allegati non protocollati
            ArchivioFileCollectionProvider ff = new ArchivioFileCollectionProvider();
            AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new AllegatiProtocollatiCollectionProvider();
            AllegatiProtocollatiCollection apc = allegatiProtocollatiProvider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, false, null);
            foreach (AllegatiProtocollati a in apc)
            {
                ArchivioFile f = ff.GetById(a.IdFile);
                //protocollo.addAllegato(f.NomeFile + "." + f.Tipo, f.Contenuto, f.Tipo);
                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                all.Descrizione = f.NomeFile;
                all.Documento = new SiarBLL.paleoWebService.File();
                all.Documento.Nome = f.NomeFile;

                Dictionary<string, object> allegatoProtocollo = new Dictionary<string, object>();
                allegatoProtocollo.Add("allegato", all);
                allegatoProtocollo.Add("id_file", f.Id);
                allegatoProtocollo.Add("tipo_origine", "pagamento");
                allegatoProtocollo.Add("id_origine", DomandaPagamento.IdDomandaPagamento);
                allegatiProtocollo.Add(allegatoProtocollo);
            }

            protocolloAll.addAllegatiProtocollo(allegatiProtocollo, DomandaPagamento.Segnatura);

            //AllegatiProtocollatiCollection allegatiDomanda = allegatiProtocollatiProvider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, null, null);

            //bool allegatiProtocollatiOk = checkAllegatiProtocollati(allegatiDomanda.Count, DomandaPagamento.Segnatura);
            var allegatiProtocollatiOk = allegatiProtocollatiProvider.CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.DomandaDiPagamento, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.Segnatura);
            */
            object tokenCohesion = null;
            if (!Bando.FirmaRichiesta)
            {
                tokenCohesion = Session["COHESION_TOKEN"];
                if (tokenCohesion == null || string.IsNullOrEmpty(tokenCohesion.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
            }

            bool allegatiProtocollatiOk = new AllegatiProtocollatiCollectionProvider()
                .ProtocollaAllegatiSegnatura(AllegatiProtocollatiCollectionProvider.TipoCheck.DomandaDiPagamento,
                    DomandaPagamento.IdDomandaPagamento,
                    DomandaPagamento.Segnatura,
                    tokenCohesion);

            if (allegatiProtocollatiOk) 
                ShowMessage("Domanda di " + DomandaPagamento.Descrizione.Value.ToUpper() + " firmata e protocollata correttamente.");
            else 
                ShowError("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int idallegato;
            try
            {
                if (!AbilitaModifica && DomandaPagamento.InIntegrazione != null && !DomandaPagamento.InIntegrazione) throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                if (!int.TryParse(hdnIdAllegato.Value, out idallegato)) throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");
                DomandaPagamentoAllegati allegato = allegati_provider.GetById(idallegato);
                if (allegato == null || allegato.IdDomandaPagamento != DomandaPagamento.IdDomandaPagamento)
                    throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");
                allegati_provider.Delete(allegato);
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                ShowMessage("Allegato eliminato correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica && DomandaPagamento.InIntegrazione != null && !DomandaPagamento.InIntegrazione) throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstCategoria.SelectedValue)) throw new Exception("E' obbligatorio selezionare la categoria del documento.");
                TipoDocumento tipologia = new TipoDocumentoCollectionProvider().GetById(lstCategoria.SelectedValue);
                if (tipologia == null) throw new Exception("La tipologia di documento selezionata non è valida.");
                if (allegato_selezionato == null)
                {
                    allegato_selezionato = new DomandaPagamentoAllegati();
                    allegato_selezionato.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                    allegato_selezionato.DataInserimento = DateTime.Now;
                    allegato_selezionato.CfInserimento = Operatore.Utente.CfUtente;
                }
                allegato_selezionato.CodTipoDocumento = lstCategoria.SelectedValue;
                if (tipologia.Formato == "C") throw new Exception("La tipologia di documento selezionata non è più valida.");
                else if (tipologia.Formato == "S")
                {
                    if (string.IsNullOrEmpty(lstNATipoEnte.SelectedValue) || string.IsNullOrEmpty(hdnCodEnte.Value)
                        || string.IsNullOrEmpty(txtNADatadoc.Text) || string.IsNullOrEmpty(txtNANumeroDoc.Text))
                        throw new Exception("Specificare tutti i campi previsti per l'identificazione del documento.");
                    //if (ente.CodTipoEnte == null) throw new Exception("Non è stata specificata l'amministrazione emettitrice del documento selezionato.");
                    if (lstNATipoEnte.SelectedValue == "CM")
                    {
                        int id_comune;
                        if (!int.TryParse(hdnCodEnte.Value, out id_comune)) throw new Exception("Non è stato specificato il comune emettitore del documento selezionato.");
                        allegato_selezionato.IdComune = id_comune;
                        allegato_selezionato.CodEnteEmettitore = null;
                    }
                    else
                    {
                        allegato_selezionato.CodEnteEmettitore = hdnCodEnte.Value;
                        allegato_selezionato.IdComune = null;
                    }
                    allegato_selezionato.Numero = txtNANumeroDoc.Text;
                    allegato_selezionato.Data = txtNADatadoc.Text;
                    allegato_selezionato.IdFile = null;
                }
                else
                {
                    if (ufcNAAllegato.IdFile == null) throw new Exception("La categoria di documento selezionata richiede di caricare il documento digitale.");
                    allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                    allegato_selezionato.CodEnteEmettitore = null;
                    allegato_selezionato.IdComune = null;
                    allegato_selezionato.Numero = null;
                    allegato_selezionato.Data = null;
                }

                allegato_selezionato.Descrizione = txtDescrizione.Text;
                allegato_selezionato.DataModifica = DateTime.Now;
                allegato_selezionato.CfModifica = Operatore.Utente.CfUtente;

                if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                    allegato_selezionato.InIntegrazione = true;
                else
                    allegato_selezionato.InIntegrazione = false;

                allegati_provider.Save(allegato_selezionato);
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                allegato_selezionato = allegati_provider.GetById(allegato_selezionato.IdAllegato);
                ShowMessage("Allegato salvato correttamente.");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnFirma_Click(object sender, EventArgs e)
        {
            try
            {
                ControlliPreFirma();
                ucFirmaDocumento.FirmaObbligatoria = Bando.FirmaRichiesta;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
            }
            catch (Exception ex) { ShowError(ex.Message); }
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

        protected void btnScaricaDocumento_Click(object sender, EventArgs e)
        {
            ScaricaDocumento();
            RegisterClientScriptBlock(modaleFirmaEsterna.Mostra);
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
                logInfo.ParametriDocumento = "IdDomandaPagamento_" + DomandaPagamento.IdDomandaPagamento;
                logInfo.DownloadDocumentoCertificato = true;

                //nuovi dati per firma esterna
                datiScaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);
                if (datiScaricamento == null)
                {
                    datiScaricamento = new ScaricamentoFirmaEsterna();
                    datiScaricamento.OperatoreInserimento = Operatore.Utente.CfUtente;
                    datiScaricamento.DataInserimento = DateTime.Now;
                    datiScaricamento.IdProgetto = DomandaPagamento.IdProgetto;
                    datiScaricamento.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                }

                modaleFirmaEsterna.loadDocumento(Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
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
                RegisterClientScriptBlock("window.open('../../VisualizzaDocumento.aspx');");

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
                logInfo.ParametriDocumento = "IdDomandaPagamento_" + DomandaPagamento.IdDomandaPagamento;
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
                    var scaricamento = scaricamentoFirmaEsternaProvider.GetUltimoScaricamentoFile(DomandaPagamento.IdProgetto, DomandaPagamento.IdDomandaPagamento, null);
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
                    ProtocollaDomandaDiPagamento(file.Contenuto);
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

        protected void ControlliPreFirma()
        {
            try
            {
                rlegale = new PersoneXImpreseCollectionProvider().GetById(ucWorkflowPagamento.Impresa.IdRapprlegaleUltimo);
                if (rlegale == null)
                    throw new Exception("L'impresa non ha un rappresentante legale valido. Impossibile continuare.");

                if (!DomandaPagamento.FirmaPredisposta && rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                {
                    if (!AbilitaModifica)
                        throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                }
                //// controllo l'avvio lavori se il flag su bando config e' spuntato
                //BandoConfigCollection cc = new BandoConfigCollectionProvider().Find(Progetto.IdBando, "RICAVVLAV", null, true, null);
                //if (cc.Count > 0 && bool.Parse(cc[0].Valore))
                //{
                //    ProgettoComunicazioniCollection pc = new ProgettoComunicazioniCollectionProvider().Find(Progetto.IdBando, Progetto.IdProgetto, null, null, "CAL", null);
                //    if (pc.Count == 0 || pc[0].Segnatura == null)
                //        throw new Exception("Il bando di riferimento richiede di specificare l'avvio dei lavori prima del rilascio di una qualsiasi domanda di pagamento.");
                //}

                if (DomandaPagamento.RichiedeAutovalutazione //se è attivo il flag per l'autovalutazione nel bando
                    && !(DomandaPagamento.NaturaCup == "06" || DomandaPagamento.NaturaCup == "07")) //e se NON è un aiuto
                {
                    var testate_coll = new TestataValidazioneCollectionProvider().FindAutovalutazione(null, null, DomandaPagamento.IdDomandaPagamento, true);
                    if (testate_coll.Count == 0)
                        throw new Exception("Autovalutazione non inserita.");

                    var testata = testate_coll[0];
                    var autovalutazioni_coll = new TestataValidazioneXIstanzaCollectionProvider().Find(null, testata.IdTestata, null, null, null);
                    if (autovalutazioni_coll.Count == 0)
                        throw new Exception("Autovalutazione non compilata: è necessario inserire almeno un autovalutazione.");
                }

                if (DomandaPagamento.CodTipo != "ANT")
                {
                    if (!strumenti_finanziari)
                    {
                        PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, null, null, DomandaPagamento.IdDomandaPagamento);
                        if (prichiesti.Count == 0)
                            throw new Exception("Non è stato collegato nessun giustificativo a nessuna voce di spesa. Impossibile continuare.");
                    }
                    else
                    {
                        PagamentiRichiestiFemCollection prichiestifem = new PagamentiRichiestiFemCollectionProvider().Find(null, null, null, null, DomandaPagamento.IdDomandaPagamento, null);
                        if (prichiestifem.Count == 0)
                            throw new Exception("Non è stato collegato nessun contratto a nessuna voce di spesa. Impossibile continuare.");
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        protected void ProtocollaDomandaDiPagamento(byte[] fileDaProtocollare)
        {
            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                dgIntegrazioni.SetPageIndex(0);
            else
            {
                string segnaturaPrincipale = null;

                try
                {
                    rlegale = new PersoneXImpreseCollectionProvider().GetById(ucWorkflowPagamento.Impresa.IdRapprlegaleUltimo);
                    if (rlegale == null)
                        throw new Exception("I dati anagrafici dell`azienda non sono validi. Si prega di contattare l`helpdesk.");

                    if (!DomandaPagamento.FirmaPredisposta && rlegale.IdPersona != Operatore.Utente.IdPersonaFisica)
                    {
                        if (!AbilitaModifica)
                            throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                    }

                    if (fileDaProtocollare == null) 
                        throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                    if (DomandaPagamento.Segnatura != null)
                        throw new Exception("La domanda di pagamento è già stata resa definitiva. Impossibile continuare.");

                    List<Protocollo> protocolli = new List<Protocollo>();
                    List<string> segnature = new List<string>();
                    List<string> docNumbers = new List<string>();
                    var idImpresaRegioneMarche = int.Parse(System.Configuration.ConfigurationManager.AppSettings["IdImpresaRegioneMarche"]);
                    var segnatureMultipleCollectionProvider = new SegnatureMultipleCollectionProvider();

                    Protocollo protocollo = new Protocollo(Bando.CodEnte);
                    var filePrincipale = fileDaProtocollare;
                    var nomeFilePrincipale = "domanda_di_pagamento_x_dom_aiuto_nr_" + Progetto.IdProgetto + ".pdf";
                    protocollo.setDocumento(nomeFilePrincipale, filePrincipale);
                    protocolli.Add(protocollo);

                    string[] ss = new BandoCollectionProvider().GetDatiXProtocollazione(Progetto.IdBando, Progetto.ProvinciaDiPresentazione);
                    string oggetto = "Domanda di pagamento (" + DomandaPagamento.Descrizione + ") per la domanda di aiuto nr. " + Progetto.IdProgetto
                        + " in risposta al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\n" + ss[3] + "\n P.Iva: " + ucWorkflowPagamento.Impresa.CodiceFiscale
                        + "\n Ragione sociale: " + ucWorkflowPagamento.Impresa.RagioneSociale;

                    //prendo l'elenco dei file che dovrò caricare su Paleo
                    ArchivioFileCollection ff = PagamentoProvider.GetFileXProtocollazioneDomandaPagamentoNoStream(DomandaPagamento.IdDomandaPagamento);

                    //INIZIO NUOVA GESTIONE ALLEGATI PROTOCOLLO

                    //se il bando non prevede la firma aggiungo anche l'allegato con il token Cohesion
                    byte[] fileTokenCohesion = null;
                    if (!Bando.FirmaRichiesta)
                    {
                        object sessione_cohesion = Session["COHESION_TOKEN"];
                        if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                            throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");

                        fileTokenCohesion = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                        var af = new ArchivioFile();
                        af.Id = -1;
                        af.Tipo = "application/xml";
                        af.NomeCompleto = af.NomeFile = "Autenticazione_Operatore.xml";
                        af.Contenuto = fileTokenCohesion;
                        af.Dimensione = fileTokenCohesion.Length;
                        af.HashCode = protocollo.GetSHA256(fileTokenCohesion);

                        ff.Insert(0, af); // lo inserisco all'inizio così da andare nella segnatura principale
                    }

                    //verifico se devo aggiungere anche l'autovalutazione
                    ArchivioFile autovalutazione = null;
                    if (DomandaPagamento.RichiedeAutovalutazione //se è attivo il flag per l'autovalutazione nel bando
                        && !(DomandaPagamento.NaturaCup == "06" || DomandaPagamento.NaturaCup == "07")) //e se NON è un aiuto
                    {
                        var testate_coll = new TestataValidazioneCollectionProvider().FindAutovalutazione(null, null, DomandaPagamento.IdDomandaPagamento, true);
                        if (testate_coll.Count == 0)
                            throw new Exception("Autovalutazione non inserita.");

                        var testata = testate_coll[0];
                        var autovalutazioni_coll = new TestataValidazioneXIstanzaCollectionProvider().Find(null, testata.IdTestata, null, null, null);
                        if (autovalutazioni_coll.Count == 0)
                            throw new Exception("Autovalutazione non compilata: è necessario inserire almeno un autovalutazione.");

                        //aggiungo l'autovalutazione o se necessario la sovrascrivo
                        var rptAutovalutazione = GetAutovalutazione(testata.IdTestata);

                        var archivio_provider = new ArchivioFileCollectionProvider();

                        var aut_coll = archivio_provider.Find(null, "Autovalutazione" + testata.IdDomandaPagamento + ".pdf", null);
                        if (aut_coll.Count == 1)
                            autovalutazione = aut_coll[0];
                        else
                        {
                            autovalutazione = new ArchivioFile();
                            autovalutazione.Tipo = "application/pdf";
                            autovalutazione.NomeFile = "Autovalutazione" + testata.IdDomandaPagamento + ".pdf";
                            autovalutazione.NomeCompleto = "Autovalutazione" + testata.IdDomandaPagamento + ".pdf";
                        }

                        autovalutazione.Contenuto = rptAutovalutazione;
                        autovalutazione.Dimensione = rptAutovalutazione.Length;

                        // genero l'hash
                        HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                        byte[] fileHashValue = alg.ComputeHash(rptAutovalutazione);
                        string hash_code = BinaryToHex(fileHashValue);
                        autovalutazione.HashCode = hash_code;
                        archivio_provider.Save(autovalutazione);

                        ff.Insert(0, autovalutazione); // lo inserisco all'inizio così da andare nella segnatura principale
                    }

                    //Dichiarazione nome e hash degli allegati per l'impronta
                    for (int i = 0; i < ff.Count; i++)
                    {
                        if (i != 0 && i % (Protocollo.LimiteAllegatiPaleo + 1) == 0) //se supero il limite massimo degli allegati creo un nuovo protocollo
                        {
                            protocollo = new Protocollo(Bando.CodEnte);
                            protocollo.setDocumento(nomeFilePrincipale, filePrincipale);
                            protocolli.Add(protocollo);
                        }

                        ArchivioFile f = ff[i];

                        try
                        {
                            if (f == null)
                                throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");

                            protocollo.addAllegato(f.NomeFile, f.HashCode);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }
                    }

                    //prendo la segnatura per ogni protocollo e gestisco il salvataggio delle segnature multiple
                    try
                    {
                        for (int i = 0; i < protocolli.Count; i++)
                        {
                            var p = protocolli[i];

                            string segnatura = "";
                            string[] doc_number_array;
                            string doc_number = null;
                            string nuovo_oggetto = oggetto + "\n Protocollo " + (i + 1) + " di " + (protocolli.Count);
                            if (Progetto.IdImpresa == idImpresaRegioneMarche)
                            {
                                segnatura = p.DocumentoInterno(nuovo_oggetto, ss[4]);
                                doc_number_array = segnatura.Split('|');
                                doc_number = doc_number_array[0];
                                docNumbers.Add(doc_number);
                            }
                            else
                            {
                                p.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                                segnatura = p.ProtocolloIngresso(nuovo_oggetto, ss[4]);
                            }

                            segnature.Add(segnatura);

                            if (i == 0)
                            {
                                segnaturaPrincipale = segnatura;

                                DomandaPagamento.Segnatura = segnatura;
                                DomandaPagamento.DataModifica = DateTime.Now;

                                string cf_operatore = Operatore.Utente.CfUtente;
                                if (DomandaPagamento.FirmaPredisposta)
                                    cf_operatore = DomandaPagamento.CfOperatore;

                                DomandaPagamento.CfOperatore = cf_operatore;
                                DomandaPagamento.CodEnte = Operatore.Utente.CodEnte;
                                PagamentoProvider.Save(DomandaPagamento);
                            }
                            else
                            {
                                var segnaturaMultipla = new SegnatureMultiple();
                                segnaturaMultipla.SegnaturaPrincipale = segnaturaPrincipale;
                                segnaturaMultipla.SegnaturaSecondaria = segnatura;
                                segnaturaMultipla.Ordine = i;
                                segnaturaMultipla.Tipo = "DomandaDiPagamento";
                                segnaturaMultipla.IdRiferimento = DomandaPagamento.IdDomandaPagamento;
                                segnaturaMultipla.DataInserimento = segnaturaMultipla.DataModifica = DateTime.Now;
                                segnaturaMultipla.OperatoreInserimento = segnaturaMultipla.OperatoreModifica = Operatore.Utente.CfUtente;
                                segnatureMultipleCollectionProvider.Save(segnaturaMultipla);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    try
                    {
                        try
                        {
                            // invio la notifica del rilascio al responsabile del bando e a quello provinciale                
                            UtentiCollectionProvider utenti_provider = new UtentiCollectionProvider();
                            var destinatari = new ArrayList();
                            foreach (BandoResponsabili r in new BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                            {
                                Utenti u = utenti_provider.GetById(r.IdUtente);
                                if (u != null && u.Email != null) destinatari.Add(u.Email.Value);
                            }
                            if (destinatari.Count > 0)
                            {
                                Email em = new Email("Avviso di ricezione Richiesta di " + DomandaPagamento.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                                    "<html><body>Si comunica che con prot. " + DomandaPagamento.Segnatura + "<br />è stata presentata la Richiesta di " + DomandaPagamento.Descrizione
                                + " per il Progetto ID: " + Progetto.IdProgetto + "."
                                + "<br /><ul><li style='width:650px'>Bando: " + Bando.Descrizione + "</li><li>Scadenza: " + Bando.DataScadenza + "</li><br />"
                                + "<li>CF/P.Iva: " + ucWorkflowPagamento.Impresa.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                                + ucWorkflowPagamento.Impresa.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                                + "<br />Tale istanza è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                                + "/private/ppagamento/gestionelavori.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                                em.SetHtmlBodyMessage(true);
                                em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                            }
                        }
                        catch { /* per il momento non faccio nulla */}

                        ucWorkflowPagamento.loadData();
                        ucFirmaDocumento.FileFirmato = null;
                        AbilitaModifica = false;
                        btnSalva.Enabled = false;
                        btnElimina.Enabled = false;
                        btnFirma.Enabled = false;
                        btnFirmaEsterna.Enabled = false;

                        // prima di caricare gli allegati su Paleo elimino i record di AllegatiProtocollati per eventuali riaperture domanda
                        AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new AllegatiProtocollatiCollectionProvider();
                        var allegatiProtocollatiVecchiCollection = allegatiProtocollatiProvider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, null, null, null);
                        if (allegatiProtocollatiVecchiCollection.Count > 0)
                            allegatiProtocollatiProvider.DeleteCollection(allegatiProtocollatiVecchiCollection);

                        // carico gli allegati su paleo 
                        //List<ArrayList> allegatiProtocolloList = new List<ArrayList>();
                        ArrayList allegatiProtocollo = new ArrayList();

                        //int numeroAllegati = 0;
                        bool allegatiProtocollatiOk = true;

                        for (int i = 0; i < ff.Count; i++)
                        {
                            ArchivioFile f = ff[i];

                            if (i != 0 && i % (Protocollo.LimiteAllegatiPaleo + 1) == 0) //se supero il limite massimo degli allegati creo un nuovo allegati protocollo
                            {
                                allegatiProtocollo = new ArrayList();
                                //allegatiProtocolloList.Add(allegatiProtocollo);
                                //numeroAllegati = 0; //reset del numero allegati per protocollo
                            }

                            try
                            {
                                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                                all.Descrizione = f.NomeCompleto;
                                all.Documento = new SiarBLL.paleoWebService.File();
                                all.Documento.NomeFile = f.NomeFile;
                                all.Documento.Stream = f.Contenuto;
                                if (f.Id == null || f.Id == -1)
                                    all.Documento.Impronta = new Protocollo().GetSHA256(f.Contenuto);
                                else
                                    all.Documento.Impronta = f.HashCode;

                                Dictionary<string, object> allegatoProtocollo = new Dictionary<string, object>();
                                allegatoProtocollo.Add("allegato", all);
                                allegatoProtocollo.Add("id_file", f.Id != null ? f.Id.Value : -1); //aggiunto controllo per file token cohesion che non ha id
                                allegatoProtocollo.Add("tipo_origine", "pagamento");
                                allegatoProtocollo.Add("id_origine", DomandaPagamento.IdDomandaPagamento);
                                allegatiProtocollo.Add(allegatoProtocollo);

                                AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(null, DomandaPagamento.IdDomandaPagamento, null, null, null, f.Id, null, null);
                                if (exist.Count == 0)
                                {
                                    AllegatiProtocollati ap = new AllegatiProtocollati();
                                    ap.IdVariante = DBNull.Value;
                                    ap.IdProgetto = DBNull.Value;
                                    ap.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                                    ap.IdIntegrazione = DBNull.Value;
                                    ap.IdFile = f.Id != null ? f.Id.Value : -1; //aggiunto controllo per file token cohesion che non ha id
                                    ap.Protocollato = false;
                                    allegatiProtocollatiProvider.Save(ap);
                                    //numeroAllegati++;
                                }
                            }
                            catch (Exception ex) { }

                            //se raggiungo il limite o sono all'ultimo allegato allego il blocco degli allegati alla segnatura
                            if (i != 0 && i % Protocollo.LimiteAllegatiPaleo == 0)
                            {
                                Protocollo protocolloAll = new Protocollo(Bando.CodEnte);

                                var segnatura = segnature[(int)Math.Truncate((decimal)(i / Protocollo.LimiteAllegatiPaleo)) - 1]; //trovo il protocollo in base al numero dell'allegato in cui sto ciclando

                                if (Progetto.IdImpresa == idImpresaRegioneMarche)
                                {
                                    var doc_number = docNumbers[(int)Math.Truncate((decimal)(i / Protocollo.LimiteAllegatiPaleo)) - 1];
                                    protocolloAll.addAllegatiDocInterno(allegatiProtocollo, segnatura, doc_number);
                                }
                                else
                                    protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                                //var esito = checkAllegatiProtocollati(numeroAllegati, segnatura);
                                var esito = allegatiProtocollatiProvider.CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.DomandaDiPagamento, DomandaPagamento.IdDomandaPagamento, segnatura);
                                if (!esito)
                                    allegatiProtocollatiOk = false;
                            }

                            //se sono all'ultimo allegato allego il blocco degli allegati all'ultima segnatura
                            if (i == (ff.Count - 1))
                            {
                                Protocollo protocolloAll = new Protocollo(Bando.CodEnte);

                                var segnatura = segnature.Last();

                                if (Progetto.IdImpresa == idImpresaRegioneMarche)
                                {
                                    var doc_number = docNumbers.Last();
                                    protocolloAll.addAllegatiDocInterno(allegatiProtocollo, segnatura, doc_number);
                                }
                                else
                                    protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                                //var esito = checkAllegatiProtocollati(numeroAllegati, segnatura);
                                var esito = allegatiProtocollatiProvider.CheckAllegatiProtocollati(AllegatiProtocollatiCollectionProvider.TipoCheck.DomandaDiPagamento, DomandaPagamento.IdDomandaPagamento, segnatura);
                                if (!esito)
                                    allegatiProtocollatiOk = false;
                            }
                        }

                        if (allegatiProtocollatiOk)
                            ShowMessage("Domanda di " + DomandaPagamento.Descrizione.Value.ToUpper() + " firmata e protocollata correttamente.");
                        else
                            ShowError("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
                    }
                    catch (Exception ex)
                    {
                        string oggettoEmail = "Errore durante la protocollazione della domanda di " + DomandaPagamento.Descrizione.Value.ToUpper();
                        string testEmail = "Domanda di aiuto: " + Progetto.IdProgetto + "\nSegnatura: " + segnaturaPrincipale + "\n\n" + ex.Message;
                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);

                        if (!string.IsNullOrEmpty(segnaturaPrincipale))
                            throw new Exception("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");
                        else
                            throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex) { throw ex; } //faccio gestire gli errori dai metodi chiamanti
            }
        }

        protected void btnNuovoAllegatoPost_Click(object sender, EventArgs e)
        {
            ufcNAAllegato.IdFile = null;
        }

        protected void btnPredisponi_Click(object sender, EventArgs e)
        {
            try
            {
                if (DomandaPagamento.CodTipo != "ANT")
                {
                    if (!strumenti_finanziari)
                    {
                        PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, null, null, DomandaPagamento.IdDomandaPagamento);
                        if (prichiesti.Count == 0)
                            throw new Exception("Non è stato collegato nessun giustificativo a nessuna voce di spesa. Impossibile continuare.");
                    }
                    else
                    {
                        PagamentiRichiestiFemCollection prichiestifem = new PagamentiRichiestiFemCollectionProvider().Find(null, null, null, null, DomandaPagamento.IdDomandaPagamento, null);
                        if (prichiestifem.Count == 0)
                            throw new Exception("Non è stato collegato nessun contratto a nessuna voce di spesa. Impossibile continuare.");
                    }
                }
            
                PredisponiAllaFirma(DomandaPagamento.FirmaPredisposta);
                string messaggio = "Domanda di aiuto predisposta correttamente alla firma.";
                if (!DomandaPagamento.FirmaPredisposta) messaggio = "Predisposizione alla firma annullata correttamente, è ora possibile riprendere la modifica dei dati della domanda.";
                ShowMessage(messaggio);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void PredisponiAllaFirma(bool annulla_predisposizione)
        {
            DomandaPagamento.FirmaPredisposta = !annulla_predisposizione;
            new DomandaDiPagamentoCollectionProvider().Save(DomandaPagamento);
            //ProgettoProvider.AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);

        }

        private byte[] GetAutovalutazione(int id_testata)
        {
            ReportTemplates rt = new ReportTemplates();
            byte[] report;
            string[] tmp_parametri = null;

            tmp_parametri = new string[] { "IdTestataValidazione=" + id_testata };

            report = rt.getReportByName("rptAutovalutazioneValidazione", tmp_parametri);
            rt.Dispose();

            return report;
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

        protected void btnSalvaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            if (integrazione_singola_selezionata != null)
            {
                SiarLibrary.NullTypes.BoolNT newValue = comboCompletataSingolaIntegrazioneDomandaBeneficiario.SelectedValue;
                string messaggio = IntegrazioniDomandaPagamentoUtility.salvaSingolaIntegrazioneBeneficiario(integrazione_singola_selezionata, newValue, txtNoteSingolaIntegrazioneBeneficiario.Text, txtDataRilascio.Text);

                if (messaggio.StartsWith("Integrazione"))
                    ShowMessage(messaggio);
                else
                    ShowError(messaggio);
            }
        }

        void dgIntegrazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_DataRichiesta = 1,
                col_TipoIntegrazione = 2,
                col_NoteIstruttore = 3,
                col_CompletataIntegrazioneIstruttore = 4,
                col_DataRilascioBeneficiario = 5,
                col_NoteBeneficiario = 6,
                col_CompletataBeneficiario = 7,
                col_Apri = 8;

            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioneSingolaDiDomanda)dgi.DataItem;

                if (d.SingolaIntegrazioneCompletataIstruttore != null && d.SingolaIntegrazioneCompletataIstruttore == true)
                    dgi.Cells[col_CompletataIntegrazioneIstruttore].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataIntegrazioneIstruttore].Text = "<div class=\"negativo\">NO</div>";

                if (d.SingolaIntegrazioneCompletataBeneficiario != null && d.SingolaIntegrazioneCompletataBeneficiario == true)
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"negativo\">NO</div>";

                if (integrazione_singola_selezionata != null && d.IdSingolaIntegrazione == integrazione_singola_selezionata.IdSingolaIntegrazione)
                    dgi.Cells[col_Apri].Text = dgi.Cells[col_Apri].Text.Replace("Apri", "Torna elenco");
            }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (((txtData.Text == "" || txtData.Text == null) && (txtSegnaturaIns.Text == null || txtSegnaturaIns.Text == "")) || ((txtData.Text == "" || txtData.Text == null) && !ckAttivo.Checked)) throw new Exception("Inserire la data e la segnatura se disponibile");
                if (!ckAttivo.Checked)
                {
                    if (!new Protocollo().ProtocolloEsistente(txtSegnaturaIns.Text))
                        throw new SiarException(TextErrorCodes.DocumentoNonValido);
                }
                if (DomandaPagamento.Segnatura != null) throw new Exception("La domanda di pagamento è già stata resa definitiva. Impossibile continuare.");
                DomandaPagamento.Segnatura = ckAttivo.Checked ? "ND" : txtSegnaturaIns.Text;
                DomandaPagamento.DataModifica = Convert.ToDateTime(txtData.Text);
                DomandaPagamento.CfOperatore = Operatore.Utente.CfUtente;
                DomandaPagamento.CodEnte = Operatore.Utente.CodEnte;
                PagamentoProvider.Save(DomandaPagamento);

                // invio la notifica del rilascio al responsabile del bando e a quello provinciale                
                UtentiCollectionProvider utenti_provider = new UtentiCollectionProvider();
                ArrayList destinatari = new ArrayList();
                foreach (BandoResponsabili r in new BandoResponsabiliCollectionProvider().Find(Progetto.IdBando, null, null, true, true))
                {
                    Utenti u = utenti_provider.GetById(r.IdUtente);
                    if (u != null && u.Email != null) destinatari.Add(u.Email.Value);
                }
                if (destinatari.Count > 0)
                {
                    Email em = new Email("Avviso di ricezione Richiesta di " + DomandaPagamento.Descrizione + " (Progetto: " + Progetto.IdProgetto + ")",
                        "<html><body>Si comunica che con prot. " + DomandaPagamento.Segnatura + "<br />è stata presentata la Richiesta di " + DomandaPagamento.Descrizione
                    + " per il Progetto ID: " + Progetto.IdProgetto + "."
                    + "<br /><ul><li style='width:650px'>Bando: " + Bando.Descrizione + "</li><li>Scadenza: " + Bando.DataScadenza + "</li><br />"
                    + "<li>CF/P.Iva: " + ucWorkflowPagamento.Impresa.CodiceFiscale + "</li><li style='width:650px'>Ragione sociale: "
                    + ucWorkflowPagamento.Impresa.RagioneSociale + "</li><br />" + "<li>Stato progetto: " + Progetto.Stato + "</li></ul>"
                    + "<br />Tale istanza è consultabile all'indirizzo: <a href='" + Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath
                    + "/private/ppagamento/gestionelavori.aspx?iddom=" + Progetto.IdProgetto + "' target=_blank>Clicca qui</a>"
                    + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                    + "<br />Si prega di non rispondere a questa email.</body></html>");
                    em.SetHtmlBodyMessage(true);
                    em.SendNotification((string[])destinatari.ToArray(typeof(string)), new string[] { });
                }

                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowMessage("La Data e la segnatura della domanda di pagamento sono state salvate correttamente.");
                ucWorkflowPagamento.loadData();
                AbilitaModifica = false;
                btnSalva.Enabled = false;
                btnElimina.Enabled = false;
                btnFirma.Enabled = false;
                btnFirmaEsterna.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
            }
            catch (Exception ex)
            {
                btnInserisciSegnatura_Click(sender, e);
                ShowError("Attenzione! " + ex.Message);
            }
        }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                if (DomandaPagamento.CodTipo != "ANT")
                {
                    if (!strumenti_finanziari)
                    {
                        PagamentiRichiestiCollection prichiesti = prichiesti_provider.Find(null, null, null, DomandaPagamento.IdDomandaPagamento);
                        if (prichiesti.Count == 0)
                            throw new Exception("Non è stato collegato nessun giustificativo a nessuna voce di spesa. Impossibile continuare.");
                    }
                    else
                    {
                        PagamentiRichiestiFemCollection prichiestifem = new PagamentiRichiestiFemCollectionProvider().Find(null, null, null, null, DomandaPagamento.IdDomandaPagamento, null);
                        if (prichiestifem.Count == 0)
                            throw new Exception("Non è stato collegato nessun contratto a nessuna voce di spesa. Impossibile continuare.");
                    }
                }
                RegisterClientScriptBlock("mostraPopupTemplate('divPregresso','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex.Message); }

        }

        protected void btnSpese_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "SpeseSostenute.aspx");
        }

        protected void btnInvestimenti_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "PianoInvestimenti.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id_integrazione_domanda"] = null;
            Redirect(PATH_PPAGAMENTO + "IntegrazioniDomandaPagamento.aspx");
        }
    }
}