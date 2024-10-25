using SiarLibrary;
using SiarBLL;
using System;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;
using web.CONTROLS;

namespace web.Private.Controlli
{
    public partial class ChecklistControlliLoco : SiarLibrary.Web.PrivatePage
    {
        // Cntr_Loco_Testa
        CntrlocoTestaCollectionProvider tstProv;
        CntrlocoTesta tstSel = null;
        // Cntr_Loco_Dettaglio
        CntrlocoDettaglioCollectionProvider detProv;
        CntrlocoDettaglio detSel = null;
        // Testata controlli in loco
        TestataControlliLocoCollectionProvider testata_provider;
        TestataControlliLoco testata_selezionata = null;
        //Istanza checklist generica
        IstanzaChecklistGenericaCollectionProvider istanza_generica_provider;
        IstanzaChecklistGenerica istanza_generica_selezionata = null;
        // Checklist generica
        ChecklistGenericaCollectionProvider checklist_generica_provider;
        ChecklistGenerica checklist_generica = null;
        // Utenti
        UtentiCollectionProvider utenti_provider;
        IrregolaritaCollectionProvider irregolarita_provider;

        String codPsr;
        int idLocoDettaglio;
        Boolean esitoVerifica;

        const int tabElencoRicerca = 1, tabChecklistDomanda = 2;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "checklist_controlli_loco";
            base.OnPreInit(e);
        }

        #region Indici dgDettaglio

        int col_IdProgetto = 0,
            col_Beneficiario = 1,
            col_Asse = 2,
            col_Azione = 3,
            col_Intervento = 4,
            col_NOperazioniBenef = 5,
            col_CostoInvestimentoRichiesto = 6,
            col_CostoInvestimentoAmmesso = 7,
            col_ContributoConcesso = 8,
            col_ImportoRendicontatoAmmessoTotale = 9,
            col_ContributoRendicontatoConcessoTotale = 10,
            col_ImportoRendicontantoAmmessoDelta = 11,
            col_ContributoRendicontatoConcessoDelta = 12,
            col_ImportoRendicontatoAmmessoRegolareTotale = 13,
            col_ContributoRendicontatoConcessoRegolareTotale = 14,
            col_ImportoRendicontatoAmmessoRegolareDelta = 15,
            col_ContributoRendicontatoConcessoRegolareDelta = 16,
            col_Selezionata = 17,
            col_Esclusione = 18,
            col_RischioIR = 19,
            col_RischioCR = 20,
            col_RischioComplessivo = 21,
            col_EsitoChecklist = 22;

        #endregion Indici dgDettaglio

        protected void Page_Load(object sender, EventArgs e)
        {
            lstPsr.DataBind();
            txtOperatoreCompilatore.AddJSAttribute("onkeydown", "tb_corrente='Compilatore';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            txtOperatoreValidatore.AddJSAttribute("onkeydown", "tb_corrente='Validatore';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
            ucFirmaDocumento.DocumentoFirmatoEvent = btnFirmaProtocolloPost_Click;
            Session["evita_controllo_date_sessione"] = "true";

            //verifico se popolare la checklist
            if (int.TryParse(hdnIdLocoDett.Value, out idLocoDettaglio))
            {
                istanziaProvider();
                popolaCampiNascosti();
                visualizzaCheckList();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            istanziaProvider();
            popolaCampiNascosti();
            visualizzaLotti();

            if(tstSel != null)
            {
                divDettaglio.Visible = true;

                switch (tabDettaglio.TabSelected)
                {
                    case tabElencoRicerca:
                        popolaRicerca();
                        break;
                    case tabChecklistDomanda:
                        //visualizzaCheckList(); viene lanciata dal controllo nel Page_Load per caricare correttamente le checklist
                        popolaFormTestata();
                        break;
                }
            }

            base.OnPreRender(e);
        }

        protected void istanziaProvider()
        {
            detProv = new CntrlocoDettaglioCollectionProvider();
            testata_provider = new TestataControlliLocoCollectionProvider();
            istanza_generica_provider = new IstanzaChecklistGenericaCollectionProvider();
            checklist_generica_provider = new ChecklistGenericaCollectionProvider();
            tstProv = new CntrlocoTestaCollectionProvider();
            utenti_provider = new UtentiCollectionProvider();
            irregolarita_provider = new IrregolaritaCollectionProvider();
        }

        protected void popolaCampiNascosti()
        {
            // hdnIdLoco
            int idLoco;
            tstSel = null;
            if (int.TryParse(hdnIdLoco.Value, out idLoco))
                tstSel = tstProv.GetById(idLoco);

            if (lstPsr.SelectedValue != hdnCodPsr.Value)
            {
                hdnCodPsr.Value = lstPsr.SelectedValue;
                codPsr = lstPsr.SelectedValue;
            }

            if (int.TryParse(hdnIdLocoDett.Value, out idLocoDettaglio))
                detSel = detProv.GetById(idLocoDettaglio);
            else
                idLocoDettaglio = 0;

            int idTestata;
            if(int.TryParse(hdnIdTestata.Value, out idTestata))
                testata_selezionata = testata_provider.GetById(idTestata);

            if (Boolean.TryParse(hdnVerificaRequisiti.Value, out esitoVerifica)
                    && txtOperatoreCompilatore.Text != null
                    && txtOperatoreValidatore.Text != null)
                btnFirmaProtocollo.Enabled = esitoVerifica;
        }

        private void visualizzaLotti()
        {
            CntrlocoTestaCollection tsts;

            if (string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                dgLotti.DataSource = null;
                divLotti.Visible = false;
                hdnIdLoco.Value = null;
                tstSel = null;

                return;
            }

            if (tstSel != null)
            {
                tsts = new CntrlocoTestaCollection();
                tsts.Add(tstSel);
                dgLotti.Titolo = "Selezionare per ritornare all'elenco dei lotti";
            }
            else
            {
                tsts = tstProv.getBy_CodPsr(lstPsr.SelectedValue);
                if (tsts.Count == 0)
                    dgLotti.Titolo = "Nessuna lotto presente per la programmazione selezionata";
                else
                    dgLotti.Titolo = "Selezionare il lotto per visualizzare il dettaglio";
            }

            dgLotti.DataSource = tsts;
            dgLotti.DataBind();
        }

        protected void popolaRicerca()
        {
            hdnIdTestata.Value = null;
            hdnIdLocoDett.Value = null;
            hdnVerificaRequisiti.Value = null;
            divElencoRicerca.Visible = true;
            divChecklistDomanda.Visible = false;

            var collection_dettaglio = detProv.FindConEsitoChecklistCntrLoco(tstSel.Idloco, true); // su sviluppo non ci sono quelle selezionate -> ultimo parametro a false per vedere qualcosa
            lblNrRecord.Text = string.Format("Visualizzate {0} righe", collection_dettaglio.Count.ToString());

            dgDettaglio.DataSource = collection_dettaglio;
            dgDettaglio.ItemDataBound += new DataGridItemEventHandler(dgDettaglio_ItemDataBound);
            dgDettaglio.DataBind();
        }

        protected void visualizzaCheckList()
        {
            divElencoRicerca.Visible = false;
            divChecklistDomanda.Visible = true;
            popolaFormCheckList();
        }

        protected void popolaFormCheckList()
        {
            if (detSel != null && detSel.IdlocoDettaglio != null)
            {
                var testata_collection = testata_provider.Find(null, null, detSel.IdlocoDettaglio, null, null, null, null);
                if (testata_collection.Count > 0) 
                    testata_selezionata = testata_collection[0];

                if (testata_selezionata == null || testata_selezionata.IdTestata == null)
                    testata_selezionata = testata_provider.generaTestataEChecklistPerDettaglio(detSel, Operatore.Utente.CfUtente); 

                if (testata_selezionata != null && testata_selezionata.IdTestata != null)
                {
                    hdnIdTestata.Value = testata_selezionata.IdTestata;
                    istanza_generica_selezionata = istanza_generica_provider.GetById(testata_selezionata.IdIstanzaChecklistGenerica);

                    ucChecklistGenerica.IdDomandaPagamento = detSel.IdDomandaPagamento;
                    ucChecklistGenerica.Progetto = new ProgettoCollectionProvider().GetById(detSel.IdProgetto);
                    ucChecklistGenerica.ButtonSalvaSchedaVisibile = false;
                    ucChecklistGenerica.IdTestataChecklist = testata_selezionata.IdTestata;
                    ucChecklistGenerica.IstanzaCheckListGenerica = istanza_generica_selezionata;
                    ucChecklistGenerica.Fase = istanza_generica_selezionata.CodFase;
                }
                else
                {
                    VldCheckListStepCollectionProvider clsP = new VldCheckListStepCollectionProvider();
                    var progetto = new ProgettoCollectionProvider().GetById(detSel.IdProgetto);
                    string tpAppalto = clsP.Get_TpAppalto(progetto.IdBando);

                    if (tpAppalto.Equals("STRFI"))
                        ShowError("Strumenti finanziari non ancora gestiti");
                    else
                        ShowError("Generazione checklist non riuscita");

                    hdnIdLocoDett.Value = null;
                }
            }
        }

        protected void popolaFormTestata()
        {
            if (testata_selezionata != null)
            {
                txtDataSopralluogo.Text = testata_selezionata.DataSopralluogo;
                txtLuogoSopralluogo.Text = testata_selezionata.LuogoSopralluogo;
                ufVerbale.IdFile = testata_selezionata.IdFileVerbale;
                ufAttestazione.IdFile = testata_selezionata.IdFileAttestazione;
                txtDataAttestazione.Text = testata_selezionata.DataAttestazione;
                txtDataVerbale.Text = testata_selezionata.DataVerbale;

                if (testata_selezionata.IdUtenteCompilatore != null)
                {
                    var operatoreCompilatore = utenti_provider.GetById(testata_selezionata.IdUtenteCompilatore);
                    txtOperatoreCompilatore.Text = operatoreCompilatore.Nominativo;
                    hdnIdUtenteCompilatore.Value = operatoreCompilatore.IdUtente;
                }
                if (testata_selezionata.IdUtenteValidatore != null)
                {
                    var operatoreValidatore = utenti_provider.GetById(testata_selezionata.IdUtenteValidatore);
                    txtOperatoreValidatore.Text = operatoreValidatore.Nominativo;
                    hdnIdUtenteValidatore.Value = operatoreValidatore.IdUtente;
                }

                if (testata_selezionata.SegnaturaTestata != null)
                {
                    btnSalvaChecklist.Enabled = false;
                    btnSalvaChecklist.ToolTip = "Non è più possibile modificare le informazioni o verificare i requisiti in quanto la checklist è già protocollata";
                    btnFirmaProtocollo.Enabled = false;

                    txtSegnaturaChecklist.Text = testata_selezionata.SegnaturaTestata;
                    imgSegnaturaChecklist.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + testata_selezionata.SegnaturaTestata + "');");
                    imgSegnaturaChecklist.Style.Add("cursor", "pointer");
                }
                else
                {
                    txtSegnaturaChecklist.Text = null;
                }
            }
        }

        protected void popolaCampiTestata()
        {
            if (testata_selezionata != null)
            {
                testata_selezionata.DataSopralluogo = txtDataSopralluogo.Text;
                testata_selezionata.LuogoSopralluogo = txtLuogoSopralluogo.Text;
                testata_selezionata.IdFileVerbale = ufVerbale.IdFile;
                testata_selezionata.IdFileAttestazione = ufAttestazione.IdFile;
                testata_selezionata.DataAttestazione = txtDataAttestazione.Text;
                testata_selezionata.DataVerbale = txtDataVerbale.Text;

                int idUtenteValidatore;
                if (int.TryParse(hdnIdUtenteValidatore.Value, out idUtenteValidatore))
                    testata_selezionata.IdUtenteValidatore = idUtenteValidatore;
                
                int idUtenteCompilatore;
                if (int.TryParse(hdnIdUtenteCompilatore.Value, out idUtenteCompilatore))
                    testata_selezionata.IdUtenteCompilatore = idUtenteCompilatore;
            }
        }

        protected bool verificaSeNegativeSoloVociIrregolarita()
        {
            bool parzialmente_negativo = false;
            var esiti_negativi_collection = new EsitoIstanzaChecklistGenericoCollectionProvider().Find(testata_selezionata.IdIstanzaChecklistGenerica, null, "NO", null, null);

            if(esiti_negativi_collection.Count == 0)
            {
                ShowError("Dovresti usare questo metodo solo se l'esito è negativo!");
                return false;
            }
            else if (esiti_negativi_collection.Count == 1)
            {
                if (esiti_negativi_collection[0].DescrizioneVoceGenerica.Like("%Il progetto è regolare?%"))
                    return true;
                else
                    return false;
            }
            else if (esiti_negativi_collection.Count == 2)
            {
                string descrizione_esito_zero = esiti_negativi_collection[0].DescrizioneVoceGenerica;
                string descrizione_esito_uno = esiti_negativi_collection[1].DescrizioneVoceGenerica;

                if (((descrizione_esito_zero.Contains("Il progetto è regolare?")) || (descrizione_esito_uno.Contains("Il progetto è regolare?")))
                    && (((descrizione_esito_zero.Contains("Importo non concesso irregolare")) || (descrizione_esito_uno.Contains("Importo non concesso irregolare")))
                        || ((descrizione_esito_zero.Contains("Importo non ammesso irregolare")) || (descrizione_esito_uno.Contains("Importo non ammesso irregolare")))))
                    return true;
                else
                    return false;
            }
            else if (esiti_negativi_collection.Count == 3)
            {
                string descrizione_esito_zero = esiti_negativi_collection[0].DescrizioneVoceGenerica;
                string descrizione_esito_uno = esiti_negativi_collection[1].DescrizioneVoceGenerica;
                string descrizione_esito_due = esiti_negativi_collection[2].DescrizioneVoceGenerica;

                if (((descrizione_esito_zero.Contains("Il progetto è regolare?")) || (descrizione_esito_uno.Contains("Il progetto è regolare?")) || (descrizione_esito_due.Contains("Il progetto è regolare?")))
                    && (((descrizione_esito_zero.Contains("Importo non concesso irregolare")) || (descrizione_esito_uno.Contains("Importo non concesso irregolare")) || (descrizione_esito_due.Contains("Importo non concesso irregolare")))
                        || ((descrizione_esito_zero.Contains("Importo non ammesso irregolare")) || (descrizione_esito_uno.Contains("Importo non ammesso irregolare")) || (descrizione_esito_due.Contains("Importo non ammesso irregolare")))))
                    return true;
                else
                    return false;
            }

            return parzialmente_negativo;
        }

        protected void verificaRequisiti()
        {
            try
            {
                istanziaProvider();
                popolaCampiNascosti();
                if (testata_selezionata != null)
                {
                    string esito = ucChecklistGenerica.VerificaChecklist();
                    string test_esito = "Checklist verificata correttamente. La domanda soddisfa tutti i requisiti obbligatori imposti dalla checklist.";

                    if (esito.Equals("NO"))
                        if (verificaSeNegativeSoloVociIrregolarita())
                        {
                            test_esito = "Checklist verificata correttamente. La domanda contiene delle irregolarità.";
                            esito = "SI";
                        }
                        else
                            test_esito = "La domanda non soddisfa i requisiti obbligatori richiesti.";

                    hdnVerificaRequisiti.Value = "true";
                    txtEsitoVerifica.Text = test_esito;
                    ShowMessage(test_esito);
                }
                else
                    ShowError("Nessuna domanda selezionata.");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnFirmaProtocolloPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                istanziaProvider();
                popolaCampiNascosti();
                string esito = ucChecklistGenerica.VerificaChecklist();

                if (esito.Equals("NO"))
                    if (verificaSeNegativeSoloVociIrregolarita())
                        esito = "SI";

                bool esito_bool = esito.Equals("SI") ? true : false;

                try
                {
                    var progetto = new ProgettoCollectionProvider().GetById(testata_selezionata.IdProgetto);
                    SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                    var bando = new BandoCollectionProvider().GetById(progetto.IdBando);
                    var domanda_pagamento = new DomandaDiPagamentoCollectionProvider().GetById(testata_selezionata.IdDomandaPagamento);
                    PersoneXImprese rlegale = new PersoneXImpreseCollectionProvider().GetById(impresa.IdRapprlegaleUltimo);
                    ArchivioFileCollectionProvider af_provider = new ArchivioFileCollectionProvider();
                    ArchivioFileCollection af_collection = new ArchivioFileCollection();

                    Protocollo protocollo = new Protocollo(bando.CodEnte);
                    protocollo.setCorrispondente(rlegale.Cognome, rlegale.Nome, null, "mittente");
                    protocollo.setDocumento("checklist_controlli_loco_" + domanda_pagamento.Descrizione + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                    ArchivioFile af_verbale = af_provider.GetById(testata_selezionata.IdFileVerbale);
                    ArchivioFile af_attestazione = af_provider.GetById(testata_selezionata.IdFileAttestazione);

                    af_collection.Add(af_verbale);
                    protocollo.addAllegato(af_verbale.NomeFile, af_verbale.HashCode);
                    
                    af_collection.Add(af_attestazione);
                    protocollo.addAllegato(af_attestazione.NomeFile, af_attestazione.HashCode);

                    string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(bando.IdBando, progetto.ProvinciaDiPresentazione);
                    string oggetto = "Checklist dei controlli in loco " + domanda_pagamento.Descrizione.Value.ToUpper()
                        + " per il bando: " + ss[0] + " del " + ss[1] + "\n" + ss[3] + "\nAnno: " + DateTime.Now.Year
                        + "\n Partita iva/Codice fiscale: " + impresa.Cuaa
                        + "\n Ragione sociale: " + impresa.RagioneSociale
                        + "\n N° Domanda: " + progetto.IdProgetto;

                    string segnatura = protocollo.ProtocolloIngresso(oggetto, ss[4]);
                    protocollo.addAllegatiProtocollo(af_collection, segnatura);

                    try
                    {
                        testata_selezionata.SegnaturaTestata = segnatura;
                        testata_selezionata.EsitoTestata = esito_bool;
                        testata_selezionata.DataSegnatura = DateTime.Now;
                        testata_selezionata.DataModifica = DateTime.Now;
                        testata_selezionata.CfModifica = Operatore.Utente.CfUtente;
                        testata_provider.Save(testata_selezionata);
                    }
                    catch (Exception ex) { ShowError(ex.ToString()); }
                }
                catch (Exception ex) { ShowError(ex.ToString()); }
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        #region Button Event

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnCaricaDettaglio_Click(object sender, EventArgs e) 
        {
            tabDettaglio.TabSelected = tabChecklistDomanda;
        }

        protected void btnSalvaChecklist_Click(object sender, EventArgs e)
        {
            try
            {
                istanziaProvider();
                popolaCampiNascosti();
                popolaCampiTestata();
                if (testata_selezionata != null)
                {
                    testata_selezionata.DataModifica = DateTime.Now;
                    testata_selezionata.CfModifica = Operatore.Utente.CfUtente;
                    testata_provider.Save(testata_selezionata);
                    verificaRequisiti();
                    //ShowMessage("Checklist salvata correttamente.");
                }
                else
                    ShowError("Nessuna domanda selezionata.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnVerificaRequisiti_Click(object sender, EventArgs e)
        {
            verificaRequisiti();
        }

        protected void btnFirmaProtocollo_Click(object sender, EventArgs e)
        {
            istanziaProvider();
            popolaCampiNascosti();

            if (testata_selezionata != null && testata_selezionata.IdUtenteValidatore != null && testata_selezionata.IdUtenteCompilatore != null)
                if (testata_selezionata.IdUtenteValidatore == Operatore.Utente.IdUtente)
                    if (testata_selezionata.IdFileAttestazione != null && testata_selezionata.IdFileVerbale != null)
                        ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, testata_selezionata.IdTestata);
                    else
                        if (testata_selezionata.IdFileVerbale == null)
                            ShowError("File verbale mancante.");
                        else if (testata_selezionata.IdFileAttestazione == null)
                            ShowError("File attestazione mancante.");
                        else
                            ShowError("Errore sui file da allegare");
                else
                    ShowError("Solamente il validatore può firmare e protocollare il documento");
            else
                if (testata_selezionata == null)
                    ShowError("Informazioni non corrette.");
                else if (testata_selezionata.IdUtenteValidatore == null)
                    ShowError("Validatore mancante");
                else if (testata_selezionata.IdUtenteCompilatore == null)
                    ShowError("Compilatore mancante");
                else
                    ShowError("Errore generico");

        }

        #endregion

        #region ItemDataBound

        void dgDettaglio_ItemDataBound(object sender, DataGridItemEventArgs e) 
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            {
                CntrlocoDettaglio cntrLocoDettaglio = (CntrlocoDettaglio)dgi.DataItem;

                if (cntrLocoDettaglio != null)
                {
                    dgi.Cells[col_ImportoRendicontatoAmmessoRegolareTotale].Text = String.Format("{0:c}",
                        new DecimalNT(
                            (cntrLocoDettaglio.Importoconcesso ?? new DecimalNT(0.00))
                                - (new DecimalNT(cntrLocoDettaglio.AdditionalAttributes["ImportoIrregolareAmmesso"]))
                            )
                        );
                    dgi.Cells[col_ContributoRendicontatoConcessoRegolareTotale].Text = String.Format("{0:c}",
                        new DecimalNT(
                            (cntrLocoDettaglio.Importocontributopubblico ?? new DecimalNT(0.00))
                                - (new DecimalNT(cntrLocoDettaglio.AdditionalAttributes["ImportoIrregolareConcesso"]))
                            )
                        );
                    dgi.Cells[col_ImportoRendicontatoAmmessoRegolareDelta].Text = String.Format("{0:c}",
                        new DecimalNT(
                            (cntrLocoDettaglio.Spesaammessa ?? new DecimalNT(0.00))
                                - (new DecimalNT(cntrLocoDettaglio.AdditionalAttributes["ImportoIrregolareAmmesso"]))
                            )
                        );
                    dgi.Cells[col_ContributoRendicontatoConcessoRegolareDelta].Text = String.Format("{0:c}",
                        new DecimalNT(
                            (cntrLocoDettaglio.ImportocontributopubblicoIncrementale ?? new DecimalNT(0.00)) 
                                - (new DecimalNT(cntrLocoDettaglio.AdditionalAttributes["ImportoIrregolareConcesso"]))
                            )
                        );

                    var esito = cntrLocoDettaglio.AdditionalAttributes["EsitoChecklist"];
                    dgi.Cells[col_EsitoChecklist].Text = esito;
                    if (esito == "Parzialmente negativo")
                        e.Item.BackColor = System.Drawing.Color.LightYellow;
                    else if (esito == "Negativo")
                        e.Item.BackColor = System.Drawing.Color.LightCoral;
                }
                else
                    dgi.Cells[col_EsitoChecklist].Text = "";
            }
        }

        #endregion
    }
}
