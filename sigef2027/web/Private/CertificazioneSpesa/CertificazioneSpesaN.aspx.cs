using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarBLL.AttiwebService;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarLibrary.Web;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneSpesaN : SiarLibrary.Web.PrivatePage
    {
        // Programmazione
        ZprogrammazioneCollection Programmazione = new ZprogrammazioneCollection();
        ZprogrammazioneCollectionProvider ProgrammazioneProvider = new ZprogrammazioneCollectionProvider();
        // CertSp_Testa
        CertspTestaCollectionProvider tstProv = new CertspTestaCollectionProvider();
        CertspTesta tstSel = null;
        // CertSp_Dettaglio
        CertspDettaglioCollectionProvider detProv = new CertspDettaglioCollectionProvider();
        CertspDettaglio detSel = null;
        CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
        CertDecertificazioneCollection certDecertificazioneCollection;
        IrregolaritaCollectionProvider irregolaritaCollectionProvider = new IrregolaritaCollectionProvider();
        ErroreCollectionProvider erroreCollectionProvider = new ErroreCollectionProvider();
        TestataControlliLocoCollectionProvider testataControlliLocoCollectionProvider = new TestataControlliLocoCollectionProvider();
        // const int colCheck = 16;
        const int colCheck = 17;
        const int cCheckFieldDecert = 5;
        const string frmMoney = "{0:c}";
        List<int> lstProgettiRitirati = new List<int>();
        List<int> lstProgettiRitirabili = new List<int>();
        List<int> lstProgettiChecklistControlliLoco = new List<int>();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "certificazione_spesaN";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] sel = ((CheckColumn)dgDecertificazioni.Columns[cCheckFieldDecert]).GetSelected();
            sel = ((CheckColumn)dgDettaglio.Columns[17]).GetSelected();
            AbilitaOggettiLoad();
            HiddenFields_Valorizza();
            ucFirmaDocumento.DocumentoFirmatoEvent = firmaPost;
            sel = ((CheckColumn)dgDecertificazioni.Columns[cCheckFieldDecert]).GetSelected();
        }
        
        protected override void OnPreRender(EventArgs e)
        {
            string[] sel = ((CheckColumn)dgDecertificazioni.Columns[cCheckFieldDecert]).GetSelected();
            VisualizzaProgramma();
            visualizzaTesta();
            visualizzaDettaglio();
            visualizzaSingolo();
            sel = ((CheckColumn)dgDecertificazioni.Columns[cCheckFieldDecert]).GetSelected();
            base.OnPreRender(e);
        }

        private void HiddenFields_Valorizza()
        {            
            // hdnIdCertSp
            int idCertSp;
            tstSel = null;
            if (int.TryParse(hdnIdCertSp.Value, out idCertSp))
            {
                tstSel = tstProv.GetById(idCertSp);
                var cert_provider = new CertspDettaglioCollectionProvider();
                hdnDataFinaleComplessivi.Value = cert_provider.getDataInizioPrimoLottoDefinitivi(tstSel.Codpsr).ToString("dd/MM/yyyy");
                hdnDataFinale.Value = cert_provider.getDataUltimoFinale_ByDataLotto(tstSel.Datafine, tstSel.Codpsr).ToString("dd/MM/yyyy");
                hdnDataLotto.Value = tstSel.Datafine;
            }

            // hdnIdProgettto
            int idProgetto;
            detSel = null;
            if (int.TryParse(hdnIdProgetto.Value, out idProgetto) && tstSel != null)
            {
                detSel = detProv.getPrjBy_IdProgetto(idProgetto, tstSel.Datafine, tstSel.Codpsr);
            }

            // Combo Programmazione
            if (lstPsr.SelectedValue != hdnCodPsr.Value)
            {
                tstSel = null;
                detSel = null;
                hdnIdCertSp.Value = null;
                hdnIdProgetto.Value = null;
                hdnCodPsr.Value = lstPsr.SelectedValue;
            }
        }

        #region Autorizzazioni

        private void AbilitaOggettiLoad()
        {
            // Testa
            btnCreaLotto.Enabled = AbilitaModifica;

            // Lotti

            // Dettaglio
            btnCancella.Enabled = AbilitaModifica;
            btnDefinitivo.Enabled = AbilitaModifica;
            btnSalvaElenco.Enabled = AbilitaModifica;
            ufTstChecklist.AbilitaModifica = this.AbilitaModifica;
            ufDetChecklist.AbilitaModifica = this.AbilitaModifica;
        }

        private void AbilitaOggettiDettaglio()
        {
            // Dettaglio
            if (tstSel.Definitivo)
            {
                btnCancella.Enabled = false;
                btnDefinitivo.Enabled = false;
                btnSalvaElenco.Enabled = false;
                ufTstChecklist.AbilitaModifica = false;
                ufDetChecklist.AbilitaModifica = false;
            }
            
            CertspTestaCollectionProvider provider = new CertspTestaCollectionProvider();
            CertspTesta ct = provider.GetById(Convert.ToInt32(hdnIdCertSp.Value));
            if (ct.Segnatura != null && ct.Segnatura != "")
            {
                txtSegnaturaVerbale.Text = ct.Segnatura;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + ct.Segnatura + "');");
                imgSegnaturaVerbale.Style.Add("cursor", "pointer");
            }
            if (ct.SegnaturaCertificazione != null && ct.SegnaturaCertificazione != "")
            {
                txtSegnaturaCertificazione.Text = ct.SegnaturaCertificazione;
                imgSegnaturaCertificazione.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + ct.SegnaturaCertificazione + "');");
                imgSegnaturaCertificazione.Style.Add("cursor", "pointer");
            }
        }

        #endregion

        #region Button events

        protected void btnPost_Click(object sender, EventArgs e) {}

        protected void btnVisualizza_CreaLotto_Click(object sender, EventArgs e)
        {
            //VisualizzaTesta_CreaLotto();
        }

        protected void btnVisualizza_tstChecklist_Click(object sender, EventArgs e)
        {
            Visualizza_ChecklistTesta();
        }

        protected void btnCreaLotto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue) && !string.IsNullOrEmpty(txtDataFine.Text))
            {
                string codPsr = lstPsr.SelectedValue;
                DatetimeNT dataInizio = txtDataInizio.Text;
                DatetimeNT dataFine = txtDataFine.Text;

                if (!tstProv.noTemporaryLot(codPsr))
                {
                    ShowError("Può essere presente 1 solo lotto non definitivo");
                    return;
                }
                try
                {
                    if (dataInizio == null)
                    {
                        hdnIdCertSp.Value = tstProv.creaLotto(codPsr, dataFine, ddlTipo.SelectedValue, Operatore.Utente.IdUtente).ToString();
                    }
                    else
                    {
                        hdnIdCertSp.Value = tstProv.creaLotto(codPsr, dataInizio, dataFine, ddlTipo.SelectedValue, Operatore.Utente.IdUtente).ToString();
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Si è verificato un errore in fase di creazione del lotto di certificazione di spesa"); //, ex.ToString());
                }

                ShowMessage("Lotto di certificazione di spesa creati correttamente");
            }
            hdnIdCertSp.Value = null;
            hdnIdProgetto.Value = null;
            HiddenFields_Valorizza();
            txtDataFine.Text = null;
        }

        protected void btnDefinitivo_Click(object sender, EventArgs e)
        {
            firmaDocumento();
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            int idCertSp = tstSel.Idcertsp;
            CancellaLotto();
            
        }

        protected void btnSalvaElenco_Click(object sender, EventArgs e)
        {
            SalvaTesta();
            SalvaDettaglioElenco();
            ShowMessage("Dati salvati");
        }

        protected void btnSalvaSingolo_Click(object sender, EventArgs e)
        {
            SalvaSingolo();
            ShowMessage("Dati salvati");
        }

        #endregion

        #region Visualizza Programma

        private void VisualizzaProgramma()
        {
            lstPsr.DataBind();

            if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                Programmazione = ProgrammazioneProvider.GetProgrammazionePsr(lstPsr.SelectedValue, null, null, null, null, null, null);
            }
        }

        #endregion

        #region Visualizzazione Testa

        private void visualizzaTesta()
        {    
            // Nessun programma selezionato: pulizia variabili e a video
            if (string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                dgTesta.DataSource = null;
                divTesta.Visible = false;
                divTestaElenco.Visible = false;
                hdnIdCertSp.Value = null;
                tstSel = null;

                return;
            }
            divTesta.Visible = true;

            visualizzaTestaElenco();
        }

        private void visualizzaTestaElenco()
        {
            //imgDettaglioNuovi.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgDettaglio.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgLegenda.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //imgRiepilogoPrevisioneProgettiCertificabili.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");

            CertspTestaCollection tsts;

            divTestaElenco.Visible = true;
            if (tstSel != null)
            {
                tsts = new CertspTestaCollection();
                tsts.Add(tstSel);
                dgTesta.Titolo = "Selezionare per ritornare all'elenco delle certificazioni";
            }
            else
            {
                tsts = tstProv.getBy_CodPsr(lstPsr.SelectedValue);
                if (tsts.Count == 0)
                {
                    dgTesta.Titolo = "Nessuna certificazione presente per la programmazione selezionata";
                }
                else
                {
                    dgTesta.Titolo = "Selezionare la certificazione per visualizzare il dettaglio";
                }
            }

            dgTesta.DataSource = tsts;
            dgTesta.DataBind();

            var riepilogoPrevisioneProgettiCertificabiliList = new CertspDettaglioCollectionProvider().GetRiepilogoPrevisioneProgettiCertificabili("%", lstPsr.SelectedValue);
            dgRiepilogoPrevisioneProgettiCertificabili.ItemDataBound += new DataGridItemEventHandler(dgRiepilogoPrevisioneProgettiCertificabili_ItemDataBound);
            dgRiepilogoPrevisioneProgettiCertificabili.DataSource = riepilogoPrevisioneProgettiCertificabiliList;
            dgRiepilogoPrevisioneProgettiCertificabili.MostraTotale("DataField", 1, 2, 3); 
            dgRiepilogoPrevisioneProgettiCertificabili.DataBind();
        }

        private void VisualizzaTesta_CreaLotto()
        {
            if (string.IsNullOrEmpty(hdnCreaLotto.Value))
            {
                hdnCreaLotto.Value = "false";
            }

            if (hdnCreaLotto.Value == "false")
            {
                hdnCreaLotto.Value = "true";
                //divCreaLotto.Visible = true; ;
                //btnVisualizza_CreaLotto.Text = "Nascondi crea lotto";
            }
            else
            {
                hdnCreaLotto.Value = "false";
                //divCreaLotto.Visible = false;
                //btnVisualizza_CreaLotto.Text = "Visualizza crea lotto";
            }
        }

        #endregion

        #region Visualizzazione Dettaglio
        
        private void visualizzaDettaglio()
        {
            const int cElenco = 1,
                      cDati = 2,
                      cProgramma = 3,
                      cDatiProvv = 4,
                      cProgrammaProvv = 5,
                      cDecertificazioni = 6;

            if (tstSel == null)
            {
                hdnIdProgetto.Value = null;
                dgDettaglio.DataSource = null;
                divDettaglio.Visible = false;

                return;
            }
            //divDettaglio.Visible = true;
            ufTstChecklist.IdFile = tstSel.IdFile; 
            AbilitaOggettiDettaglio();

            divDettaglio.Visible = true;
            divDettaglioElenco.Visible = false;
            divDettaglioDati.Visible = false;
            divDettaglioProgramma.Visible = false;
            divDettaglioDatiProvv.Visible = false;
            divTabDecertificazioni.Visible = false;

            switch (tabDettaglio.TabSelected)
            {
                case cElenco:
                    visualizzaDettaglioElenco();
                    break;
                case cDati:
                    detSel = null;
                    visualizzaDettaglioDati();
                    break;
                case cProgramma:
                    detSel = null;
                    visualizzaDettaglioProgramma();
                    break;
                case cDatiProvv:
                    detSel = null;
                    visualizzaDettaglioDatiProvv();
                    break;
                case cProgrammaProvv:
                    detSel = null;
                    visualizzaDettaglioProgrammaProvv();
                    break;
                case cDecertificazioni:
                    detSel = null;
                    visualizzaTabDecertificazioni();
                    break;
                //case cDecertPassate:
                //    detSel = null;
                //    visualizzaDecertificazioniPassate();
                //    break;
            }
        }

        private void visualizzaDettaglioElenco()
        {
            //var certspTeste = tstProv.getAll().ToArrayList<CertspTesta>().OrderByDescending(x => x.Idcertsp).ToList<CertspTesta>();
            var certspTeste = tstProv.getBy_CodPsr(tstSel.Codpsr).ToArrayList<CertspTesta>().OrderByDescending(x => x.Idcertsp).ToList<CertspTesta>();
            List<int> certificazioni_precedenti = new List<int>();
            foreach(CertspTesta cer in certspTeste)
            {
                if (cer.Tipo == "I")
                    certificazioni_precedenti.Add(cer.Idcertsp);
                else
                    break;
            }

            certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, null, null, tstSel.Idcertsp);//quelle assegnate in questa certificazione
            foreach(int idCert in certificazioni_precedenti)
            {
                certDecertificazioneCollection.AddCollection(certDecertificazioneCollectionProvider.Find(null, null, null, null, null, idCert, null, null, true, null, null, null));//appartenente ad una certificazione precedente e definitiva
            }

            if (certDecertificazioneCollection.Count != 0)
            {
                var certDecertificazioneList = certDecertificazioneCollection.ToArrayList<CertDecertificazione>();

                foreach (CertDecertificazione certDecertificazione in certDecertificazioneList)
                {
                    if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Irregolarita.ToString())
                    {
                        var irregolarita = irregolaritaCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                        if (irregolarita != null 
                            && (irregolarita.AzioneCertificazione == "Ritiro" 
                                || irregolarita.AzioneCertificazione == "Decurtazione"))
                            lstProgettiRitirati.Add(certDecertificazione.IdProgetto);
                    } 
                    else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Errore.ToString())
                    {
                        var errore = erroreCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                        if (errore != null 
                            && (errore.AzioneCertificazione == "Ritiro" 
                                || errore.AzioneCertificazione == "Decurtazione"))
                            lstProgettiRitirati.Add(certDecertificazione.IdProgetto);
                    }
                    else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Rinuncia.ToString())
                    {
                        lstProgettiRitirati.Add(certDecertificazione.IdProgetto);
                    }
                }

                //lstProgettiRitirati = certDecertificazioneCollection.ToArrayList<CertDecertificazione>().Select(x => int.Parse(x.IdProgetto)).Distinct().ToList();
                lstProgettiRitirati = lstProgettiRitirati.Distinct().ToList();
            }

            certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, true, true, null);
            if (certDecertificazioneCollection.Count != 0)
            {
                var certDecertificazioneList = certDecertificazioneCollection.ToArrayList<CertDecertificazione>();

                foreach (CertDecertificazione certDecertificazione in certDecertificazioneList)
                {
                    if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Irregolarita.ToString())
                    {
                        var irregolarita = irregolaritaCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                        if (irregolarita != null 
                            && (irregolarita.AzioneCertificazione == "Ritiro"
                                || irregolarita.AzioneCertificazione == "Decurtazione"))
                            lstProgettiRitirabili.Add(certDecertificazione.IdProgetto);
                    }
                    else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Errore.ToString())
                    {
                        var errore = erroreCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                        if (errore != null 
                            && (errore.AzioneCertificazione == "Ritiro"
                                || errore.AzioneCertificazione == "Decurtazione"))
                            lstProgettiRitirabili.Add(certDecertificazione.IdProgetto);
                    }
                    else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Rinuncia.ToString())
                    {
                        lstProgettiRitirabili.Add(certDecertificazione.IdProgetto);
                    }
                }

                //lstProgettiRitirabili = certDecertificazioneCollection.ToArrayList<CertDecertificazione>().Select(x => int.Parse(x.IdProgetto)).Distinct().ToList();
                lstProgettiRitirabili = lstProgettiRitirabili.Distinct().ToList();
            }

            CertspDettaglioCollection dets = getDettaglio_dets();
            var detsNuovi = new CertspDettaglioCollection();
            var detsPresenti = new CertspDettaglioCollection();
            for (int i = 0; i < dets.Count; i++)
            {
                var certspDettaglio = dets[i];

                //non ho bisogno di filtrare per l'esito perché se sono arrivati alla certificazione è per forza positivo
                TestataControlliLocoCollection checkControlliLocoCollection = new TestataControlliLocoCollection();
                if (dets.Count == 1)
                {
                    var dettagliCollection = detProv.getBy_IdProgetto(certspDettaglio.IdProgetto, tstSel.Datafine, tstSel.Codpsr);
                    foreach (CertspDettaglio dettaglio in dettagliCollection)
                    {
                        checkControlliLocoCollection.AddCollection(
                            testataControlliLocoCollectionProvider.Find(null, null, null, null, null, dettaglio.IdDomandaPagamento, null)
                            );
                    }
                }
                else
                {
                    if (certspDettaglio.AdditionalAttributes["IdTestataControlliLoco"] != null
                        && certspDettaglio.AdditionalAttributes["IdTestataControlliLoco"] != "")
                    {
                        lstProgettiChecklistControlliLoco.Add(certspDettaglio.IdProgetto);
                    }
                }

                if (checkControlliLocoCollection.Count > 0)
                    lstProgettiChecklistControlliLoco.Add(certspDettaglio.IdProgetto);

                if (hdnIdCertSp.Value != null && hdnIdCertSp.Value != ""
                    && hdnIdCertSp.Value == certspDettaglio.Idcertsp)
                    detsNuovi.Add(certspDettaglio);
                else
                    detsPresenti.Add(certspDettaglio);
            }
            lstProgettiChecklistControlliLoco = lstProgettiChecklistControlliLoco.Distinct().ToList();

            lblNrRecordTotale.Text = string.Format("Visualizzate {0} righe totali", (dets.Count).ToString());

            lblNrRecordNuovi.Text = string.Format("Visualizzate {0} righe", detsNuovi.Count.ToString());
            dgDettaglioNuovi.ItemDataBound += new DataGridItemEventHandler(dgDettaglio_ItemDataBound);
            dgDettaglioNuovi.DataSource = detsNuovi;
            dgDettaglioNuovi.DataBind();

            lblNrRecord.Text = string.Format("Visualizzate {0} righe", detsPresenti.Count.ToString());
            dgDettaglio.ItemDataBound += new DataGridItemEventHandler(dgDettaglio_ItemDataBound);
            dgDettaglio.DataSource = detsPresenti;
            dgDettaglio.DataBind();

            divDettaglioElenco.Visible = true;

            #region Legenda
             
            List<Legenda> legendaList = new List<Legenda>();
            
            Legenda legendaVerde = new Legenda(Color.LightGreen, "Progetti provenienti da chiusura checklist controlli in loco");
            Legenda legendaGiallo = new Legenda(Color.LightYellow, "Progetti con ritiri o decurtazioni associabili");
            Legenda legendaRosso = new Legenda(Color.LightCoral, "Progetti con ritiri o decurtazioni associati");
            
            legendaList.Add(legendaVerde);
            legendaList.Add(legendaGiallo);
            legendaList.Add(legendaRosso);

            dgLegenda.ItemDataBound += new DataGridItemEventHandler(dgLegenda_ItemDataBound);
            dgLegenda.DataSource = legendaList;
            dgLegenda.DataBind();

            #endregion Legenda
        }

        private void visualizzaDettaglioDati()
        {
            TimeSpan giorno = new TimeSpan(1, 0, 0, 0);
            DatiLotto_Titolo.Text = string.Format("Dati lotto definitivi - Periodo dal {0} al {1}",
                                                  new CertspDettaglioCollectionProvider().getDataUltimoFinale_ByDataLotto(tstSel.Datafine, tstSel.Codpsr).Add(giorno).ToString("dd/MM/yyyy"),
                                                  tstSel.Datafine.ToString("dd/MM/yyyy"));

            GrigliaSpesa(tblDettaglioDati, true, false);

            divDettaglioDati.Visible = true;
        }

        private void visualizzaDettaglioDatiProvv()
        {
            TimeSpan giorno = new TimeSpan(1, 0, 0, 0);
            DatiLottoProvv_Titolo.Text = string.Format("Dati lotto NON definitivi - Periodo dal {0} al {1}",
                                                       new CertspDettaglioCollectionProvider().getDataUltimoFinale_ByDataLotto(tstSel.Datafine, tstSel.Codpsr).Add(giorno).ToString("dd/MM/yyyy"),
                                                       tstSel.Datafine.ToString("dd/MM/yyyy"));

            GrigliaSpesa(tblDettaglioDatiProvv, false, false);
            divDettaglioDatiProvv.Visible = true;
        }

        private void visualizzaDettaglioProgramma()
        {
            DatiProgramma_Titolo.Text = string.Format(@"Dati definitivi programma '{0}' dall'inizio fino al {1} incluso",
                                                      lstPsr.SelectedItem.Text,
                                                      tstSel.Datafine.ToString("dd/MM/yyyy"));
            GrigliaStrumentiFinanziari(tblStrumentiFi, true);
            GrigliaAnticipi(tblAnticipi, true);
            GrigliaSpesa(tblDettaglioDatiComplessivi, true, true);

            divDettaglioProgramma.Visible = true;
        }


        private void visualizzaDettaglioProgrammaProvv()
        {
            DatiProgrammaProvv_Titolo.Text = string.Format(@"Dati NON definitivi programma '{0}' dall'inizio fino al {1} incluso",
                                                      lstPsr.SelectedItem.Text,
                                                      tstSel.Datafine.ToString("dd/MM/yyyy"));
            GrigliaStrumentiFinanziari(tblStrumentiFiProvv, false);
            GrigliaAnticipi(tblAnticipiProvv, false);
            GrigliaSpesa(tblDettaglioDatiComplessiviProvv, false, true);

            divDettaglioProgrammaProvv.Visible = true;
        }

        private void visualizzaTabDecertificazioni()
        {
            if (tstSel != null)
            {
                divTabDecertificazioni.Visible = true;

                if (tstSel.Definitivo == true)
                    btnSalvaTabDecert.Enabled = false;

                var decertificazioneCollection = certDecertificazioneCollectionProvider.GetDecertificazioniPerCertificazioneSpesa(tstSel.Idcertsp, tstSel.Definitivo, tstSel.Codpsr);

                dgTabDecertificazioni.DataSource = decertificazioneCollection;
                dgTabDecertificazioni.ItemDataBound += new DataGridItemEventHandler(dgTabDecertificazione_ItemDataBound);
                dgTabDecertificazioni.DataBind();
                dgTabDecertificazioni.Visible = true;
                
                if (decertificazioneCollection.Count == 0)
                    divContenutoTabDecert.Visible = false;
                else
                    lblTabDecertificazioni.Visible = false;
            }
        }

        //private void visualizzaDecertificazioniPassate()
        //{
        //    divDecPassate.Visible = true;

        //    caricaDecertificazioniPassate();
        //    var prova = new CertDecertificazione();

        //    //dgDecPassate
        //}

        //private void caricaDecertificazioniPassate()
        //{
        //    CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
        //    CertDecertificazioneCollection certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, true, true, null);
        //    CertspDettaglioCollection dets = getDettaglio_Passate();
        //    int cert_selezionata= tstSel.Idcertsp;
        //    dgProgettiDecPassate.DataSource = dets;
        //    dgProgettiDecPassate.DataBind();


        //}
        private CertspDettaglioCollection getDettaglio_Passate()
        {
            string codPsr = lstPsr.SelectedValue;
            CertspDettaglioCollection dets = null;
            CertspDettaglioCollectionProvider.TipoDomande filtroValue = getDdlFiltro();

            if (detSel != null)
            {
                dets = new CertspDettaglioCollection();
                dets.Add(detSel);
            }
            else
            {
                dets = detProv.getPrjBy_DataFine(codPsr, tstSel.Datafine, filtroValue);
            }

            return dets;
        }

        private void Visualizza_ChecklistTesta()
        {
            if (string.IsNullOrEmpty(hdnTstCheck.Value))
            {
                hdnTstCheck.Value = "false";
            }

            if (hdnTstCheck.Value == "false")
            {
                hdnTstCheck.Value = "true";
                divCaricaTstCheck.Visible = true;
                btnVisualizza_tstChecklist.Text = "Nascondi checklist";
            }
            else
            {
                hdnTstCheck.Value = "false";
                divCaricaTstCheck.Visible = false;
                btnVisualizza_tstChecklist.Text = "Checklist lotto";
            }
        }

        private CertspDettaglioCollectionProvider.TipoDomande getDdlFiltro()
        {
            CertspDettaglioCollectionProvider.TipoDomande filtroValue = CertspDettaglioCollectionProvider.TipoDomande.Tutte;
            int ddlFiltroSelezionato = 0;
            int hdnDdlFiltroApp;

            int.TryParse(ddlFiltro.SelectedValue, out ddlFiltroSelezionato);
            int.TryParse(hdnDdlFiltro.Value, out hdnDdlFiltroApp);

            switch (ddlFiltroSelezionato)
            {
                case 1:
                    filtroValue = CertspDettaglioCollectionProvider.TipoDomande.Tutte;
                    break;
                case 2:
                    filtroValue = CertspDettaglioCollectionProvider.TipoDomande.SelezionateSi;
                    break;
                case 3:
                    filtroValue = CertspDettaglioCollectionProvider.TipoDomande.SelezionateNo;
                    break;
                case 4:
                    filtroValue = CertspDettaglioCollectionProvider.TipoDomande.ChecklistSi;
                    break;
                case 5:
                    filtroValue = CertspDettaglioCollectionProvider.TipoDomande.ChecklistNo;
                    break;
            }

            if (ddlFiltroSelezionato != hdnDdlFiltroApp)
            {
                detSel = null;
                hdnDdlFiltro.Value = ddlFiltroSelezionato.ToString();
            }

            return filtroValue;
        }

        #endregion

        #region Visualizza griglie riassuntive

        private void GrigliaStrumentiFinanziari(System.Web.UI.HtmlControls.HtmlTable tabellaStrumenti, bool soloDefinitivi)
        {
            decimal CompTot = 0,
                    Spe1Tot = 0,
                    ErogTot = 0,
                    Spe2Tot = 0;
            int i = 0;

            System.Web.UI.HtmlControls.HtmlTableRow newRow;
            System.Web.UI.HtmlControls.HtmlTableCell clAsse;
            System.Web.UI.HtmlControls.HtmlTableCell clComp;
            System.Web.UI.HtmlControls.HtmlTableCell clSpe1;
            System.Web.UI.HtmlControls.HtmlTableCell clErog;
            System.Web.UI.HtmlControls.HtmlTableCell clSpe2;
            CertspDettaglioCollectionProvider.RigaStrumentiFinanziari rigaStrFin;

            List<CertspDettaglioCollectionProvider.RigaStrumentiFinanziari> datiGriglia = datiGriglia = detProv.GrigliaStrumentiFinanziari_Dati(lstPsr.SelectedValue, tstSel.Datafine, soloDefinitivi);

            foreach (Zprogrammazione prg in Programmazione)
            {
                if (prg.Livello > 1)
                {
                    continue;
                }
                i++;

                newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
                clComp = new System.Web.UI.HtmlControls.HtmlTableCell();
                clSpe1 = new System.Web.UI.HtmlControls.HtmlTableCell();
                clErog = new System.Web.UI.HtmlControls.HtmlTableCell();
                clSpe2 = new System.Web.UI.HtmlControls.HtmlTableCell();

                clAsse.Align = "Center";
                clComp.Align = "Center";
                clSpe1.Align = "Center";
                clErog.Align = "Center";
                clSpe2.Align = "Center";

                clAsse.InnerText = "Asse " + prg.Codice;
                clComp.InnerText = string.Format(frmMoney, 0);
                clSpe1.InnerText = string.Format(frmMoney, 0);
                clErog.InnerText = string.Format(frmMoney, 0);
                clSpe2.InnerText = string.Format(frmMoney, 0);

                if (i % 2 == 0)
                {
                    newRow.Attributes.Add("Class", "DataGridRow");
                }
                else
                {
                    newRow.Attributes.Add("Class", "DataGridRowAlt");
                }

                rigaStrFin = datiGriglia.Find(x => x.Asse == prg.Codice);
                if (rigaStrFin != null)
                {
                    clComp.InnerText = string.Format(frmMoney, rigaStrFin.ImportoComplessivoContributi);
                    clSpe1.InnerText = string.Format(frmMoney, rigaStrFin.ImportoSpesaPubblica1);
                    clErog.InnerText = string.Format(frmMoney, rigaStrFin.ImportoContributiErogati);
                    //clSpe2.InnerText = string.Format(frmMoney, rigaStrFin.ImportoSpesaPubblica2);
                    clSpe2.InnerText = string.Format(frmMoney, rigaStrFin.ImportoContributiErogati);

                    CompTot += rigaStrFin.ImportoComplessivoContributi;
                    Spe1Tot += rigaStrFin.ImportoSpesaPubblica1;
                    ErogTot += rigaStrFin.ImportoContributiErogati;
                    //Spe2Tot += rigaStrFin.ImportoSpesaPubblica2;
                    Spe2Tot += rigaStrFin.ImportoContributiErogati;
                }
                newRow.Cells.Add(clAsse);
                newRow.Cells.Add(clComp);
                newRow.Cells.Add(clSpe1);
                newRow.Cells.Add(clErog);
                newRow.Cells.Add(clSpe2);
                tabellaStrumenti.Rows.Add(newRow);
            }

            // Totali
            newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
            clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
            clComp = new System.Web.UI.HtmlControls.HtmlTableCell();
            clSpe1 = new System.Web.UI.HtmlControls.HtmlTableCell();
            clErog = new System.Web.UI.HtmlControls.HtmlTableCell();
            clSpe2 = new System.Web.UI.HtmlControls.HtmlTableCell();

            newRow.Attributes.Add("Class", "TotaliFooter");
            clAsse.Align = "Center";
            clComp.Align = "Right";
            clSpe1.Align = "Right";
            clErog.Align = "Right";
            clSpe2.Align = "Right";

            clAsse.InnerText = "Totale";
            clComp.InnerText = string.Format(frmMoney, CompTot);
            clSpe1.InnerText = string.Format(frmMoney, Spe1Tot);
            clErog.InnerText = string.Format(frmMoney, ErogTot);
            clSpe2.InnerText = string.Format(frmMoney, Spe2Tot);

            newRow.Cells.Add(clAsse);
            newRow.Cells.Add(clComp);
            newRow.Cells.Add(clSpe1);
            newRow.Cells.Add(clErog);
            newRow.Cells.Add(clSpe2);

            tabellaStrumenti.Rows.Add(newRow);
        }


        private void GrigliaSpesa(System.Web.UI.HtmlControls.HtmlTable tabellaDettaglioDati, bool soloDefinitivi, bool complessivi)
        {
            decimal AmmiTot = 0,
                    ContTot = 0,
                    BeneTot = 0;
            int i = 0;

            System.Web.UI.HtmlControls.HtmlTableRow newRow;
            System.Web.UI.HtmlControls.HtmlTableCell clAsse;
            System.Web.UI.HtmlControls.HtmlTableCell clBase;
            System.Web.UI.HtmlControls.HtmlTableCell clAmmi;
            System.Web.UI.HtmlControls.HtmlTableCell clCont;
            System.Web.UI.HtmlControls.HtmlTableCell clBene;
            CertspDettaglioCollectionProvider.RigaSpesa rigaSpesa;

            List<CertspDettaglioCollectionProvider.RigaSpesa> datiGriglia = detProv.GrigliaSpesa_Dati(lstPsr.SelectedValue, tstSel.Datafine, soloDefinitivi, complessivi);

            foreach (Zprogrammazione prg in Programmazione)
            {
                if (prg.Livello > 1)
                {
                    continue;
                }
                i++;
                newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
                clBase = new System.Web.UI.HtmlControls.HtmlTableCell();
                clAmmi = new System.Web.UI.HtmlControls.HtmlTableCell();
                clCont = new System.Web.UI.HtmlControls.HtmlTableCell();
                clBene = new System.Web.UI.HtmlControls.HtmlTableCell();

                clAsse.Align = "Center";
                clBase.Align = "Center";
                clAmmi.Align = "Center";
                clCont.Align = "Center";
                clBene.Align = "Center";

                clAsse.InnerText = "Asse " + prg.Codice;
                clBase.InnerText = "Pubblico";
                clAmmi.InnerText = string.Format(frmMoney, 0);
                clCont.InnerText = string.Format(frmMoney, 0);
                clBene.InnerText = string.Format(frmMoney, 0);

                if (i % 2 == 0)
                {
                    newRow.Attributes.Add("Class", "DataGridRow");
                }
                else
                {
                    newRow.Attributes.Add("Class", "DataGridRowAlt");
                }
                rigaSpesa = datiGriglia.Find(x => x.Asse == prg.Codice);
                if (rigaSpesa != null)
                {
                    clAmmi.InnerText = string.Format(frmMoney, rigaSpesa.ImportoContributo);
                    clCont.InnerText = string.Format(frmMoney, rigaSpesa.ImportoContributo);
                    clBene.InnerText = string.Format(frmMoney, rigaSpesa.ImportoRendicontato);
                    AmmiTot += rigaSpesa.ImportoContributo;
                    ContTot += rigaSpesa.ImportoContributo;
                    BeneTot += rigaSpesa.ImportoRendicontato;
                }
                newRow.Cells.Add(clAsse);
                newRow.Cells.Add(clBase);
                newRow.Cells.Add(clAmmi);
                newRow.Cells.Add(clCont);
                newRow.Cells.Add(clBene);
                tabellaDettaglioDati.Rows.Add(newRow);
            }

            // Totali
            newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
            clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
            clBase = new System.Web.UI.HtmlControls.HtmlTableCell();
            clAmmi = new System.Web.UI.HtmlControls.HtmlTableCell();
            clCont = new System.Web.UI.HtmlControls.HtmlTableCell();
            clBene = new System.Web.UI.HtmlControls.HtmlTableCell();

            newRow.Attributes.Add("Class", "TotaliFooter");
            clAsse.Align = "Center";
            clBase.Align = "Center";
            clAmmi.Align = "Center";
            clCont.Align = "Center";
            clBene.Align = "Center";

            clAsse.InnerText = "Totale";
            clBase.InnerText = "";
            clAmmi.InnerText = string.Format(frmMoney, AmmiTot);
            clCont.InnerText = string.Format(frmMoney, ContTot);
            clBene.InnerText = string.Format(frmMoney, BeneTot);

            newRow.Cells.Add(clAsse);
            newRow.Cells.Add(clBase);
            newRow.Cells.Add(clAmmi);
            newRow.Cells.Add(clCont);
            newRow.Cells.Add(clBene);

            tabellaDettaglioDati.Rows.Add(newRow);
        }


        private void GrigliaAnticipi(System.Web.UI.HtmlControls.HtmlTable tabellaAnticipi, bool soloDefinitivi)
        {
            decimal ContTot = 0,
                    CopeTot = 0,
                    OltrTot = 0;
            int i = 0;

            System.Web.UI.HtmlControls.HtmlTableRow newRow;
            System.Web.UI.HtmlControls.HtmlTableCell clAsse;
            System.Web.UI.HtmlControls.HtmlTableCell clCont;
            System.Web.UI.HtmlControls.HtmlTableCell clCope;
            System.Web.UI.HtmlControls.HtmlTableCell clOltr;
            CertspDettaglioCollectionProvider.RigaAnticipi rigaAnticipi;

            List<CertspDettaglioCollectionProvider.RigaAnticipi> datiGriglia = detProv.GrigliaAnticipi_Dati(lstPsr.SelectedValue, tstSel.Datafine, soloDefinitivi);
            foreach (Zprogrammazione prg in Programmazione)
            {
                if (prg.Livello > 1)
                {
                    continue;
                }
                i++;
                newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
                clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
                clCont = new System.Web.UI.HtmlControls.HtmlTableCell();
                clCope = new System.Web.UI.HtmlControls.HtmlTableCell();
                clOltr = new System.Web.UI.HtmlControls.HtmlTableCell();

                clAsse.Align = "Center";
                clCont.Align = "Center";
                clCope.Align = "Center";
                clOltr.Align = "Center";

                clAsse.InnerText = "Asse " + prg.Codice;
                clCont.InnerText = string.Format(frmMoney, 0);
                clCope.InnerText = string.Format(frmMoney, 0);
                clOltr.InnerText = string.Format(frmMoney, 0);

                if (i % 2 == 0)
                {
                    newRow.Attributes.Add("Class", "DataGridRow");
                }
                else
                {
                    newRow.Attributes.Add("Class", "DataGridRowAlt");
                }
                rigaAnticipi = datiGriglia.Find(x => x.Asse == prg.Codice);
                if (rigaAnticipi != null)
                {
                    clCont.InnerText = string.Format(frmMoney, rigaAnticipi.ContributoRendicontato);
                    clCope.InnerText = string.Format(frmMoney, rigaAnticipi.ImportoCoperto3Anni);
                    clOltr.InnerText = string.Format(frmMoney, rigaAnticipi.ImportoOltre3Anni);
                    ContTot += rigaAnticipi.ContributoRendicontato;
                    CopeTot += rigaAnticipi.ImportoCoperto3Anni;
                    OltrTot += rigaAnticipi.ImportoOltre3Anni;
                }
                newRow.Cells.Add(clAsse);
                newRow.Cells.Add(clCont);
                newRow.Cells.Add(clCope);
                newRow.Cells.Add(clOltr);

                tabellaAnticipi.Rows.Add(newRow);
            }

            // Totali
            newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
            newRow = new System.Web.UI.HtmlControls.HtmlTableRow();
            clAsse = new System.Web.UI.HtmlControls.HtmlTableCell();
            clCont = new System.Web.UI.HtmlControls.HtmlTableCell();
            clCope = new System.Web.UI.HtmlControls.HtmlTableCell();
            clOltr = new System.Web.UI.HtmlControls.HtmlTableCell();

            newRow.Attributes.Add("Class", "TotaliFooter");
            clAsse.Align = "Center";
            clCont.Align = "Right";
            clCope.Align = "Right";
            clOltr.Align = "Right";

            clAsse.InnerText = "Totale";
            clCont.InnerText = string.Format(frmMoney, ContTot);
            clCope.InnerText = string.Format(frmMoney, CopeTot);
            clOltr.InnerText = string.Format(frmMoney, OltrTot);

            newRow.Cells.Add(clAsse);
            newRow.Cells.Add(clCont);
            newRow.Cells.Add(clCope);
            newRow.Cells.Add(clOltr);

            tabellaAnticipi.Rows.Add(newRow);
        }

        #endregion

        #region Visualizzazione Singolo

        private void visualizzaSingolo()
        {
            int idFile;

            int idDomandaSelezionata;

            if (detSel == null)
            {
                dgSingolo.DataSource = null;
                divSingolo.Visible = false;

                return;
            }

            dgSingolo.ItemDataBound += new DataGridItemEventHandler(dgSingolo_ItemDataBound);
            CertspDettaglioCollection sngs = new CertspDettaglioCollection();

            sngs = detProv.getBy_IdProgetto(detSel.IdProgetto, tstSel.Datafine, tstSel.Codpsr);
            dgSingolo.DataSource = sngs;

            if (int.TryParse(hdnDomandaSelezionata.Value, out idDomandaSelezionata))
            {
                var lstSngs = sngs.ToArrayList<CertspDettaglio>().Where(x => x.IdDomandaPagamento == idDomandaSelezionata).ToList();
                dgSingolo.DataSource = lstSngs;
            }

            dgSingolo.DataBind();

            NoteDomanda.Text = detProv.GetNote_ByIdProgetto(tstSel.Idcertsp, detSel.IdProgetto);
            idFile = detProv.GetIdFile_ByIdProgetto(tstSel.Idcertsp, detSel.IdProgetto);
            if (idFile != 0)
            {
                ufDetChecklist.IdFile = idFile;
            }

            divSingolo.Visible = true;
            visualizzaDecertificazioni();
        }

        #endregion

        #region Datagrid Events

        void dgDettaglio_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            // Gestione colonna selezione
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CertspDettaglio d = (CertspDettaglio)e.Item.DataItem;
                if (d.Selezionata == true)
                {
                    e.Item.Cells[colCheck].Text = e.Item.Cells[colCheck].Text.Replace("<input ", "<input checked ");
                }
                else
                {
                    e.Item.Cells[colCheck].Text = e.Item.Cells[colCheck].Text.Replace("checked", "");
                }

                if (tstSel.Definitivo)
                {
                    e.Item.Cells[colCheck].Text = e.Item.Cells[colCheck].Text.Replace(">", "disabled='disabled'>");
                }

                foreach (int idProg in lstProgettiRitirati)
                {
                    if (d.IdProgetto == idProg)
                        e.Item.BackColor = Color.LightCoral;
                }

                foreach (int idProg in lstProgettiRitirabili)
                {
                    if(e.Item.BackColor != Color.LightCoral)
                        if (d.IdProgetto == idProg)
                            e.Item.BackColor = Color.LightYellow;
                }

                foreach (int idProg in lstProgettiChecklistControlliLoco)
                {
                    if (e.Item.BackColor != Color.LightCoral
                        && e.Item.BackColor != Color.LightYellow)
                        if (d.IdProgetto == idProg)
                            e.Item.BackColor = Color.LightGreen;
                }
            }
        }

        void dgSingolo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int sngChk = 9;

            //// Gestione colonna selezione
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    SiarLibrary.CertspDettaglio d = (SiarLibrary.CertspDettaglio)e.Item.DataItem;
            //    if (d.Selezionata == true)
            //    {
            //        e.Item.Cells[sngChk].Text = e.Item.Cells[sngChk].Text.Replace("<input ", "<input checked ");
            //    }
            //    else
            //    {
            //        e.Item.Cells[sngChk].Text = e.Item.Cells[sngChk].Text.Replace("checked", "");
            //    };
            //    if (tstSel.Definitivo)
            //    {
            //        e.Item.Cells[sngChk].Text = e.Item.Cells[sngChk].Text.Replace(">", "disabled='disabled'>");
            //    }
            //}
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CertspDettaglio d = (CertspDettaglio)e.Item.DataItem;
                certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, d.IdDomandaPagamento, null, null, null, null, null, null, null, null, tstSel.Idcertsp);
                //var certspTeste = tstProv.getAll().ToArrayList<CertspTesta>().OrderByDescending(x => x.Idcertsp).ToList<CertspTesta>();
                var certspTeste = tstProv.getBy_CodPsr(tstSel.Codpsr).ToArrayList<CertspTesta>().OrderByDescending(x => x.Idcertsp).ToList<CertspTesta>();
                List<int> certificazioni_precedenti = new List<int>();
                foreach (CertspTesta cer in certspTeste)
                {
                    if (cer.Tipo == "I")
                        certificazioni_precedenti.Add(cer.Idcertsp);
                    else
                        break;
                }

                foreach (int idCert in certificazioni_precedenti)
                {
                    certDecertificazioneCollection.AddCollection(certDecertificazioneCollectionProvider.Find(null, null, d.IdDomandaPagamento, null, null, idCert, null, null, null, true, null, null));
                }

                if (certDecertificazioneCollection.Count != 0)
                {
                    foreach (CertDecertificazione certDecertificazione in certDecertificazioneCollection)
                    {
                        if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Irregolarita.ToString())
                        {
                            var irregolarita = irregolaritaCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                            if (irregolarita != null 
                                && (irregolarita.AzioneCertificazione == "Ritiro" 
                                    || irregolarita.AzioneCertificazione == "Decurtazione"))
                                e.Item.BackColor = Color.LightCoral;
                        }
                        else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Errore.ToString())
                        {
                            var errore = erroreCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                            if (errore != null 
                                && (errore.AzioneCertificazione == "Ritiro"
                                    || errore.AzioneCertificazione == "Decurtazione"))
                                e.Item.BackColor = Color.LightCoral;
                        }
                        else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Rinuncia.ToString())
                        {
                            e.Item.BackColor = Color.LightCoral;
                        }
                    }
                }
                else
                {
                    certDecertificazioneCollection.AddCollection(certDecertificazioneCollectionProvider.Find(null, d.IdProgetto, null, null, null, null, null, null, null, true, true, null));
                    if (certDecertificazioneCollection.Count != 0)
                    {
                        foreach (CertDecertificazione certDecertificazione in certDecertificazioneCollection)
                        {
                            if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Irregolarita.ToString())
                            {
                                var irregolarita = irregolaritaCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                                if (irregolarita != null 
                                    && (irregolarita.AzioneCertificazione == "Ritiro" 
                                        || irregolarita.AzioneCertificazione == "Decurtazione"))
                                    e.Item.BackColor = Color.LightYellow;
                            }
                            else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Errore.ToString())
                            {
                                var errore = erroreCollectionProvider.GetById(certDecertificazione.IdDecertificazione);
                                if (errore != null 
                                    && (errore.AzioneCertificazione == "Ritiro" 
                                        || errore.AzioneCertificazione == "Decurtazione"))
                                    e.Item.BackColor = Color.LightYellow;
                            }
                            else if (certDecertificazione.TipoDecertificazione == tipoDecertificazione.Rinuncia.ToString())
                            {
                                e.Item.BackColor = Color.LightYellow;
                            }
                        }
                    }
                }

                foreach (int idProg in lstProgettiChecklistControlliLoco)
                {
                    if (e.Item.BackColor != Color.LightCoral
                        && e.Item.BackColor != Color.LightYellow)
                        if (d.IdProgetto == idProg)
                        {
                            e.Item.BackColor = Color.LightGreen;
                            e.Item.Cells[6].Text = "";
                        }
                }
            }
        }

        void dgLegenda_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Legenda l = (Legenda)e.Item.DataItem;
                e.Item.BackColor = l.Colore;
            }
            else
                e.Item.Visible = false;
        }

        void dgTabDecertificazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            e.Item.Cells[8].Style.Add("display", "none");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CertDecertificazione d = (CertDecertificazione)e.Item.DataItem;
                
                if (d.Assegnata == true)
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input ", "<input checked ");
                else
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("checked", "");

                if (tstSel.Definitivo == true)
                    e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace("<input ", "<input disabled ");
            }
        }

        void dgRiepilogoPrevisioneProgettiCertificabili_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RiepilogoPrevisioneProgettiCertificabili r = (RiepilogoPrevisioneProgettiCertificabili)e.Item.DataItem;

                //e.Item.Cells[0].Text = r.Asse.ToString();
                //e.Item.Cells[1].Text = r.DaIstruire.ToString();
                //e.Item.Cells[2].Text = r.DaValidare.ToString();
                //e.Item.Cells[3].Text = r.DaCertificare.ToString();
            }
        }

        #endregion

        #region Data access

        private void CancellaLotto()
        {
            if (tstSel.Definitivo == true)
            {
                ShowError("Non è possibile cancellare un lotto definitivo");
                return;
            }
            tstProv.CancellaLotto(tstSel.Idcertsp);
            eliminaDecertificazioniLotto(tstSel.Idcertsp);
            ShowMessage("Lotto cancellato correttamente");

            hdnIdCertSp.Value = null;
            hdnIdProgetto.Value = null;
            HiddenFields_Valorizza();
        }

        private void SalvaTesta()
        {
            //tstSel.IdFile = ufTstChecklist.IdFile; // Sembra non debba più servire la checklist
            tstProv.Save(tstSel);
        }

        private void SalvaDettaglioElenco()
        {
            CertspDettaglioCollection dets = getDettaglio_dets();
            string[] sel = ((CheckColumn)dgDettaglio.Columns[colCheck]).GetSelected();
            bool isSelect;

            foreach (CertspDettaglio det in dets)
            {
                isSelect = false;
                foreach (string s in sel)
                {
                    if (det.IdProgetto.ToString() == s)
                    {
                        isSelect = true;
                    }
                }

                detProv.SelezioneCambia_ByIdProgetto(tstSel.Idcertsp, det.IdProgetto, isSelect);
            }
        }

        private void Lotto_RendiDefinitivo()
        {
            // Sembra non debba più servire la checklist
            //if (tstSel.IdFile == null)
            //{
            //    ShowError("Per rendere definitivo un lotto è necessario caricare una checklist");
            //    return;
            //}

            tstProv.RendiDefinitivo(tstSel.Idcertsp);
            rendiDefinitiveDecertificazioni(tstSel.Idcertsp);
            ShowMessage("Certificazione firmata e salvata con successo. Lotto marcato come Definitivo");
        }

        private CertspDettaglioCollection getDettaglio_dets()
        {
            string codPsr = lstPsr.SelectedValue;
            CertspDettaglioCollection dets = null;
            CertspDettaglioCollectionProvider.TipoDomande filtroValue = getDdlFiltro();

            if (detSel != null)
            {
                dets = new CertspDettaglioCollection();
                dets.Add(detSel);
            }
            else
            {
                dets = detProv.getPrjBy_DataFine(codPsr, tstSel.Datafine, filtroValue);
            }

            return dets;
        }

        private void SalvaSingolo()
        {
            detProv.SalvaNote_ByIdProgetto(tstSel.Idcertsp, detSel.IdProgetto, NoteDomanda.Text);
            detProv.SalvaFile_ByIdProgetto(tstSel.Idcertsp, detSel.IdProgetto, ufDetChecklist.IdFile);
        }

        #endregion

        #region Segnatura

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                int idCertSp;
                CertspTestaCollectionProvider provider = new CertspTestaCollectionProvider();
                if (hdnIdCertSp.Value != "" && hdnIdCertSp.Value != null)
                {
                    idCertSp = Convert.ToInt32(hdnIdCertSp.Value);
                    CertspTesta ct = provider.GetById(idCertSp);
                    if (ct.Datasegnatura == null)
                        txtData.Text = "";
                    else
                        txtData.Text = ct.Datasegnatura;
                    if (ct.Segnatura == null)
                        txtSegnatura.Text = "";
                    else
                    {
                        txtSegnatura.Text = ct.Segnatura;
                        imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + txtSegnatura.Text + "');");
                        imgSegnatura.Style.Add("cursor", "pointer");
                    }
                }
                RegisterClientScriptBlock("mostraPopupTemplate('divSegnatura','divBKGMessaggio');");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                int idCertSp;
                CertspTestaCollectionProvider provider = new CertspTestaCollectionProvider();
                if (hdnIdCertSp.Value == "" || hdnIdCertSp.Value == null)
                    throw new Exception("ID della certificazione non trovata!");
                else
                    idCertSp = Convert.ToInt32(hdnIdCertSp.Value);
                if ((txtData.Text == "" || txtData.Text == null) && (txtSegnatura.Text == null || txtSegnatura.Text == "")) throw new Exception("Inserire la data e la segnatura");
                if (!new Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                CertspTesta ct = provider.GetById(idCertSp);
                ct.Datasegnatura = txtData.Text;
                ct.Segnatura = txtSegnatura.Text;
                provider.Save(ct);
                txtSegnaturaVerbale.Text = ct.Segnatura;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + ct.Segnatura + "');");
                imgSegnaturaVerbale.Style.Add("cursor", "pointer");
                RegisterClientScriptBlock("chiudiPopupTemplate();");
            }
            catch (Exception ex)
            {
                string messaggio = "Attenzione! " + ex.Message;
                btnInserisciSegnatura_Click(sender, e);
                RegisterClientScriptBlock("alert('" + messaggio + "');");

            }
        }

        protected void firmaPost(object sender, EventArgs e)
        {
            try
            {
                int idCertSp;
                SiarBLL.CertspTestaCollectionProvider provider = new SiarBLL.CertspTestaCollectionProvider();
                if (hdnIdCertSp.Value == "" || hdnIdCertSp.Value == null)
                    throw new Exception("ID della certificazione non trovata!");
                else
                    idCertSp = Convert.ToInt32(hdnIdCertSp.Value);
                string periodoContabile = provider.GetPeriodoContabileCertificazione(idCertSp);

                string fascicolo = hdnFascicolo.Value;
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");
                Protocollo p = new Protocollo(hdnFascicolo.Value.Split('/')[2]);
                p.setCorrispondente("di Certificazione", "Autorità ", null, "mittente");
                p.setDocumento("Comunicazione_Certificazione_Lotto_" + hdnIdCertSp.Value + ".pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));
                string oggetto = "Trasmissione dati certificazione PR Marche FESR 2021-2027";
                oggetto += " Lotto ID " + hdnIdCertSp.Value;
                oggetto += " Periodo Contabile " +  periodoContabile;

                p.SetTrasmissioneRuolo(hdnStrutturaAudit.Value, "protocollista", "inoltro_a_ruolo");

                System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                Dictionary<string, object> allegatoProtocollo = new Dictionary<string, object>();

                //Recupero il report da allegare
                string[] parametriReport = new string[] { "DataFinale=" + hdnDataFinale.Value,
                                                      "DataLotto=" + hdnDataLotto.Value,
                                                      "CodPsr=" + lstPsr.SelectedValue,
                                                      "Filtro=" + hdnDdlFiltro.Value };

                ReportTemplates rt = new ReportTemplates();
                byte[] report;
                report = rt.getReportByName("rptCertificazioneSpesaDettaglio", 2, parametriReport);

                //allego il report
                all = new SiarBLL.paleoWebService.Allegato();
                all.Descrizione = "Certificazione_Spesa_Dettaglio.xls";
                all.Documento = new SiarBLL.paleoWebService.File();
                all.Documento.NomeFile = "Certificazione_Spesa_Dettaglio.xls";
                all.Documento.Stream = report;
                allegatoProtocollo = new Dictionary<string, object>();
                allegatoProtocollo.Add("allegato", all);
                allegatoProtocollo.Add("id_file", -1);
                allegatoProtocollo.Add("tipo_origine", "comunicazione");
                allegatoProtocollo.Add("id_origine", "-1");
                allegatiProtocollo.Add(allegatoProtocollo);

                p.addAllegato("Certificazione_Spesa_Dettaglio.xls", p.GetSHA256(report));

                string segnatura = p.ProtocolloIngresso(oggetto, fascicolo);

                //allego gli allegati
                p.addAllegatiProtocollo(allegatiProtocollo, segnatura);


                //salvo la CertSp_testa
               

                if (!new Protocollo().ProtocolloEsistente(segnatura))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);
                CertspTesta ct = provider.GetById(idCertSp);
                ct.SegnaturaCertificazione = segnatura;
                provider.Save(ct);
                txtSegnaturaCertificazione.Text = ct.SegnaturaCertificazione;
                imgSegnaturaCertificazione.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + ct.SegnaturaCertificazione + "');");
                imgSegnaturaCertificazione.Style.Add("cursor", "pointer");

                Lotto_RendiDefinitivo();

            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        #endregion

        private void firmaDocumento()
        {
            // Sembra non debba più servire la checklist
            //if (tstSel.IdFile == null)
            //{
            //    ShowError("Per rendere definitivo un lotto è necessario caricare una checklist");
            //    return;
            //}
            string df = hdnDataFinale.Value;
            string dt = hdnDataLotto.Value;
            string dataFine = string.Format("{0}/{1}/{2}", df.Substring(3, 2), df.Substring(0, 2), df.Substring(6, 4));
            string dataLotto = string.Format("{0}/{1}/{2}", dt.Substring(3, 2), dt.Substring(0, 2), dt.Substring(6, 4));
            string[] parametri = new string[] { dataFine,
                                                dataLotto,
                                                hdnCodPsr.Value,
                                                hdnIdCertSp.Value};
            ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, parametri);
        }

        protected void btnSalvaDecertificazioni_Click(object sender, EventArgs e)
        {
            string[] sel = hdnDecertSelezionate.Value.Split('|');
            int idDomandaPagamento = int.Parse(hdnDomandaSelezionata.Value);
            int idProgetto = int.Parse(hdnIdProgetto.Value);
            List<int> decertificazioni_aggiunte = new List<int>();
            List<int> decertificazioni_disassociate = new List<int>();
            CertspDettaglioCollectionProvider certspDettaglioCollectionProvider = new CertspDettaglioCollectionProvider();
            CertDecertificazioneCollection decertificazioneCollection = new CertDecertificazioneCollection();
            decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, idProgetto, null, null, null, null, null, null, null, true, true, null);
            var appDecertificazioni = certDecertificazioneCollectionProvider.Find(null, idProgetto, idDomandaPagamento, null, null, null, null, null, null, null, null, tstSel.Idcertsp);

            //Creo l'elenco di cosa è cambiato rispetto a prima (Aggiunti e tolti)
            bool trovata = false;
            for (int i = 0; i < sel.Length - 1; i++)
            {
                foreach (CertDecertificazione d in appDecertificazioni)
                    if (d.IdCertDecertificazione == int.Parse(sel[i]))
                        trovata = true;
                if (!trovata)
                    decertificazioni_aggiunte.Add(int.Parse(sel[i]));
                trovata = false;
            }

            foreach (CertDecertificazione d in appDecertificazioni)
            {
                for (int i = 0; i < sel.Length - 1; i++)
                    if (d.IdCertDecertificazione == int.Parse(sel[i]))
                        trovata = true;
                if (!trovata)
                    decertificazioni_disassociate.Add(d.IdCertDecertificazione);
                trovata = false;
            }

            if (appDecertificazioni.Count != 0)
                foreach (CertDecertificazione d in appDecertificazioni)
                    decertificazioneCollection.Add(d);
            CertspDettaglio certspDettaglio = certspDettaglioCollectionProvider
                .Select(null, null, idDomandaPagamento, null, null, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null)
                .ToArrayList<CertspDettaglio>()
                .OrderByDescending(c => c.IdcertspDettaglio)
                .FirstOrDefault();

            if (certspDettaglio == null || certspDettaglio.IdcertspDettaglio == null)
                throw new Exception("La domanda che si vuole decertificare probabilmente non è selezionata: selezionare la domanda e riprovare");

            //sommo le decertificazioni disassociate (prima che siano disassociate)
            foreach (int idCertDecert in decertificazioni_disassociate)
            {
                var decertificazione = certDecertificazioneCollectionProvider.GetById(idCertDecert);
                if (decertificazione.Definitiva != true)
                {
                    tstProv.Somma_importi_decertificati(null, certspDettaglio.IdcertspDettaglio, decertificazione.IdCertDecertificazione);
                    tstProv.Somma_importi_decertificati_domande_successive(null, decertificazione.IdProgetto, certspDettaglio.IdcertspDettaglio, decertificazione.IdCertDecertificazione);
                    tstProv.Calcola_quote(null, decertificazione.IdDomandaPagamento, decertificazione.IdCertificazioneSpesaEffettiva, decertificazione.IdCertDecertificazione);
                }
            }

            foreach (CertDecertificazione d in decertificazioneCollection)
            {
                d.Assegnata = false;
                d.IdCertificazioneSpesa = null;
                d.IdDomandaPagamento = null;
                d.IdCertificazioneSpesaEffettiva = null;
                for (int i = 0; i < sel.Length - 1; i++)
                {
                    if(d.IdCertDecertificazione == int.Parse(sel[i]))
                    {
                        d.Assegnata = 1;
                        d.IdCertificazioneSpesa = certspDettaglio.Idcertsp;
                        d.IdDomandaPagamento = idDomandaPagamento;
                        d.IdCertificazioneSpesaEffettiva = tstSel.Idcertsp;
                    }
                }  
            }
            certDecertificazioneCollectionProvider.SaveCollection(decertificazioneCollection);
            //detraggo le certificazioni aggiunte 
            foreach (int idCertDecert in decertificazioni_aggiunte)
            {
                var decertificazione = certDecertificazioneCollectionProvider.GetById(idCertDecert);
                if (decertificazione.Definitiva != true)
                {
                    tstProv.Sottrai_importi_decertificati(null, certspDettaglio.IdcertspDettaglio, decertificazione.IdCertDecertificazione);
                    tstProv.Sottrai_importi_decertificati_domande_successive(null, decertificazione.IdProgetto, certspDettaglio.IdcertspDettaglio, decertificazione.IdCertDecertificazione);
                    tstProv.Calcola_quote(null, decertificazione.IdDomandaPagamento, decertificazione.IdCertificazioneSpesaEffettiva, decertificazione.IdCertDecertificazione);
                }
            }

        }

        protected void btnSelezionaDomanda_Click(object sender, EventArgs e)
        {
            if (hdnDomandaSelezionata.Value != "")
            {
                //int idProgetto = int.Parse(hdnIdProgetto.Value);
                //int idDomanda = int.Parse(hdnIdDomanda.Value);
                //hdnDomandaSelezionata.Value = idDomanda.ToString();
                //TODO: Controllo reale
                //if (tstSel.Definitivo)
                //{
                //    //Prendo quelle assegnate a quella domanda in quella certificazione
                //    decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, idProgetto, idDomanda, null, null, tstSel.Idcertsp, null, null, null, null, true);
                //    btnSalvaDecertificazioni.Visible = false;
                //}
                //else
                //{
                //    //prendo quelle assegnate a quella domanda in quella certificazione
                //    decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, idProgetto, idDomanda, null, null, tstSel.Idcertsp, null, null, null, null, true);
                //    //più tutte quelle di quel progetto non assegnate a nessuna certificazione
                //    decertificazioneCollection.AddCollection(certDecertificazioneCollectionProvider.Find(null, idProgetto, null, null, null, null, null, null, null, true, true));
                //    btnSalvaDecertificazioni.Visible = true;
                //}
                
            }
            else
            {
                //hdnDomandaSelezionata.Value = "";
                //divDecertificazioni.Visible = false;
            }
        }
        private void visualizzaDecertificazioni()
        {
            if (hdnDomandaSelezionata.Value != "")
            {
                int idDomandaPagamento = int.Parse(hdnDomandaSelezionata.Value);
                int idProgetto = int.Parse(hdnIdProgetto.Value);
                CertDecertificazioneCollection decertificazioneCollection = new CertDecertificazioneCollection();
                if (tstSel.Definitivo == true)
                    btnSalvaDecertificazioni.Enabled = false;
                else
                    decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, idProgetto, null, null, null, null, null, null, null, true, true, null);//Tutte quelle del progetto non assegnate a nessuna certificazione
                var appDecertificazioni = certDecertificazioneCollectionProvider.Find(null, idProgetto, idDomandaPagamento, null, null, null, null, null, null, null, null, tstSel.Idcertsp);//quelle decertificate in questo lotto
                if (appDecertificazioni.Count != 0)
                    foreach (CertDecertificazione d in appDecertificazioni)
                        decertificazioneCollection.Add(d);
                var decertificazioniDg = decertificazioneCollection.ToArrayList<CertDecertificazione>().OrderBy(x => x.IdCertDecertificazione).ToList<CertDecertificazione>();

                decertificazioneCollection.Clear();
                var appDecertificazioniPrecedenti = certDecertificazioneCollectionProvider.Find(null, idProgetto, idDomandaPagamento, null, null, null, null, null, null, null, null, null);
                if (appDecertificazioniPrecedenti.Count != 0)
                    foreach (CertDecertificazione d in appDecertificazioniPrecedenti)
                        if(d.IdCertificazioneSpesaEffettiva != tstSel.Idcertsp && d.IdCertificazioneSpesaEffettiva != null)//tutte quelle associate ad una certificazone precedente
                            decertificazioneCollection.Add(d);
                decertificazioniDg.AddRange(decertificazioneCollection.ToArrayList<CertDecertificazione>().OrderBy(x => x.IdCertDecertificazione).ToList<CertDecertificazione>());
                dgDecertificazioni.DataSource = decertificazioniDg;
                dgDecertificazioni.ItemDataBound += new DataGridItemEventHandler(dgDecertificazione_ItemDataBound);
                dgDecertificazioni.DataBind();
                divDecertificazioni.Visible = true;
                if(decertificazioniDg.Count==0)
                {
                    btnSalvaDecertificazioni.Visible = false;
                    lblNessunaDecert.Visible = true;
                }
                
            }
            else
                divDecertificazioni.Visible = false;
        }
        private void rendiDefinitiveDecertificazioni(int Idcertsp)
        {
            CertDecertificazioneCollection decertificazioneCollection = new CertDecertificazioneCollection();
            decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, null, null, Idcertsp);
            foreach (CertDecertificazione d in decertificazioneCollection)
                d.Definitiva = 1;
            certDecertificazioneCollectionProvider.SaveCollection(decertificazioneCollection);
        }

        void dgDecertificazione_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            int cHdnField = 6;
            
            e.Item.Cells[cHdnField].Style.Add("display", "none");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CertDecertificazione d = (CertDecertificazione)e.Item.DataItem;
                if (d.Assegnata == true)
                    e.Item.Cells[cCheckFieldDecert].Text = e.Item.Cells[cCheckFieldDecert].Text.Replace("<input ", "<input checked ");
                else
                    e.Item.Cells[cCheckFieldDecert].Text = e.Item.Cells[cCheckFieldDecert].Text.Replace("checked", "");
                
                if(tstSel.Definitivo == true)//TODO: Se saranno visibili anche le precedenti il controllo sarà da fare anche sui lotti precedenti
                    e.Item.Cells[cCheckFieldDecert].Text = e.Item.Cells[cCheckFieldDecert].Text.Replace("<input ", "<input disabled ");
                
                if (d.Definitiva == true)//TODO: Se saranno visibili anche le precedenti il controllo sarà da fare anche sui lotti precedenti
                    e.Item.Cells[cCheckFieldDecert].Text = e.Item.Cells[cCheckFieldDecert].Text.Replace("<input ", "<input disabled ");
            }
        }

        protected void btnIndietroDecertificazioni_Click(object sender, EventArgs e)
        {
            hdnDomandaSelezionata.Value = "";
        }

        private void eliminaDecertificazioniLotto(int idCertSpesa)
        {
            CertDecertificazioneCollection certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, null, null, idCertSpesa);
            if (certDecertificazioneCollection.Count != 0)
            {
                foreach (CertDecertificazione decert in certDecertificazioneCollection)
                {
                    decert.Assegnata = 0;
                    decert.Definitiva = 0;
                    decert.IdCertificazioneSpesa = null;
                    decert.IdCertificazioneSpesaEffettiva = null;
                    decert.IdDomandaPagamento = null;
                }
                certDecertificazioneCollectionProvider.SaveCollection(certDecertificazioneCollection);
            }
        }

        protected void btnSalvaTabDecert_Click(object sender, EventArgs e)
        {
            var decertificazioneSpesaProvider = new AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider();

            try
            {
                decertificazioneSpesaProvider.DbProviderObj.BeginTran();
                certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);
                detProv = new CertspDettaglioCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);

                //1) Disassocio le decertificazioni
                var decertificazioniPresentiCollection = decertificazioneSpesaProvider.GetDecertificazioniSuFittizi(tstSel.Idcertsp);
                foreach (CertDecertificazione decertificazione in decertificazioniPresentiCollection)
                {
                    decertificazione.Assegnata = false;
                    decertificazione.Definitiva = false;
                    decertificazione.IdDomandaPagamento = null;
                    decertificazione.IdCertificazioneSpesa = null;
                    decertificazione.IdCertificazioneSpesaEffettiva = null;
                    certDecertificazioneCollectionProvider.Save(decertificazione);
                }

                //2) Elimino tutte le certificazioni spesa dettaglio fittizie negative
                var dettagliDaEliminareCollecion = decertificazioneSpesaProvider.GetDettagliFittiziDaEliminare(tstSel.Idcertsp);
                detProv.DeleteCollection(dettagliDaEliminareCollecion);

                //3) Elimino le associazioni decertificazioni di spesa
                var decertificazioneSpesaDaEliminareCollection = decertificazioneSpesaProvider.FindByLottoCertificazioneSpesa(tstSel.Idcertsp, null, null, null);
                decertificazioneSpesaProvider.DeleteCollection(decertificazioneSpesaDaEliminareCollection);

                //4) Creo le righe dettaglio fittizie negative nuove in base ai selezionati
                string[] sel = hdnTabDecertSelezionate.Value.Split('|');
                sel = sel.Take(sel.Count() - 1).ToArray(); //rimuovo l'ultimo elemento che è vuoto
                List<int> idDecertificazioniNuoveList = sel.Select(int.Parse).ToList();
                List<CertDecertificazione> decertificazioniList = new List<CertDecertificazione>();

                //prendo l'elenco delle decertificazioni, prendo la distinct degli idProgetto e su quelli creo una riga
                // fittizia per ogni progetto
                foreach (int idDecertificazioniNuove in idDecertificazioniNuoveList)
                {
                    var decertificazione = certDecertificazioneCollectionProvider.GetById(idDecertificazioniNuove);
                    decertificazioniList.Add(decertificazione);
                }

                var idProgettiDecertList = decertificazioniList
                    .Select(d => d.IdProgetto)
                    .Distinct()
                    .ToList();

                foreach(int idProgetto in idProgettiDecertList)
                {
                    var certSpDettaglioPrecedenteCollection = detProv.Select(null, null, null, idProgetto, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                    var domandeCollection = new DomandaDiPagamentoCollection();
                    int idDomandaPagamentoPerRigaFittizia;
                    var certSpDettaglioNuovo = new CertspDettaglio();

                    //Se presente uso l'ultima domanda di pagamento presente in certificazione, altrimenti uso la prima domanda di pagamento possibile con gli importi a 0
                    if (certSpDettaglioPrecedenteCollection.Count == 0)
                    {
                        var domandaPagamentoCollectionProvider = new DomandaDiPagamentoCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);
                        var progettoCollectionProvider = new ProgettoCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);
                        var impresaCollectionProvider = new ImpresaCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);

                        domandeCollection = domandaPagamentoCollectionProvider.Find(null, null, idProgetto, null);

                        if (domandeCollection.Count == 0)
                            throw new Exception("Errore nel recuperare i dati per la domanda di aiuto " + idProgetto);

                        var domandaDaUsare = domandeCollection
                            .ToArrayList<DomandaDiPagamento>()
                            .OrderBy(d => d.IdDomandaPagamento)
                            .ToList<DomandaDiPagamento>()[0];
                        idDomandaPagamentoPerRigaFittizia = domandaDaUsare.IdDomandaPagamento;
                        var progettoDaUsare = progettoCollectionProvider.GetById(domandaDaUsare.IdProgetto);
                        var impresaDaUsare = impresaCollectionProvider.GetById(progettoDaUsare.IdImpresa);

                        certSpDettaglioNuovo.IdDomandaPagamento = domandaDaUsare.IdDomandaPagamento;
                        certSpDettaglioNuovo.IdProgetto = domandaDaUsare.IdProgetto;
                        certSpDettaglioNuovo.Asse = "32"; //DA MODIFICARE
                        certSpDettaglioNuovo.Costototale = 0.00;
                        certSpDettaglioNuovo.Beneficiario = impresaDaUsare.RagioneSociale;
                        certSpDettaglioNuovo.SpesaammessaIncrementale = 0.00;
                    }
                    else
                    {
                        var certSpDettaglioPrecedentiList = certSpDettaglioPrecedenteCollection
                            .ToArrayList<CertspDettaglio>()
                            .OrderByDescending(c => c.IdcertspDettaglio)
                            .ToList<CertspDettaglio>();
                        var certSpDettaglioPrecedente = certSpDettaglioPrecedentiList[0];
                        idDomandaPagamentoPerRigaFittizia = certSpDettaglioPrecedente.IdDomandaPagamento;

                        certSpDettaglioNuovo.IdDomandaPagamento = certSpDettaglioPrecedente.IdDomandaPagamento;
                        certSpDettaglioNuovo.IdProgetto = certSpDettaglioPrecedente.IdProgetto;
                        certSpDettaglioNuovo.Asse = certSpDettaglioPrecedente.Asse;
                        certSpDettaglioNuovo.Costototale = certSpDettaglioPrecedente.Costototale;
                        certSpDettaglioNuovo.Beneficiario = certSpDettaglioPrecedente.Beneficiario;
                        certSpDettaglioNuovo.SpesaammessaIncrementale = certSpDettaglioPrecedente.SpesaammessaIncrementale;
                    }

                    certSpDettaglioNuovo.Idcertsp = tstSel.Idcertsp;
                    certSpDettaglioNuovo.Selezionata = true;
                    certSpDettaglioNuovo.Importoconcesso = 0.00;
                    certSpDettaglioNuovo.Spesaammessa = 0.00;
                    certSpDettaglioNuovo.Importocontributopubblico = 0.00;
                    certSpDettaglioNuovo.ImportocontributopubblicoIncrementale = 0.00;
                    certSpDettaglioNuovo.Operatore = Operatore.Utente.CfUtente;
                    certSpDettaglioNuovo.Datainserimento = DateTime.Now;
                    certSpDettaglioNuovo.Datamodifica = DateTime.Now;
                    certSpDettaglioNuovo.Quotaue = 0.00;
                    certSpDettaglioNuovo.Quotastato = 0.00;
                    certSpDettaglioNuovo.Quotaregione = 0.00;
                    certSpDettaglioNuovo.Quotaprivato = 0.00;
                    detProv.Save(certSpDettaglioNuovo);

                    var decertProgettoList = decertificazioniList
                        .Where(d => d.IdProgetto == idProgetto)
                        .ToList();

                    foreach (CertDecertificazione decertificazione in decertProgettoList)
                    {
                        if (decertificazione.Definitiva != true)
                        {
                            tstProv.Sottrai_importi_decertificati(decertificazioneSpesaProvider.DbProviderObj, idDomandaPagamentoPerRigaFittizia, tstSel.Idcertsp, decertificazione.IdCertDecertificazione);
                            tstProv.Calcola_quote(decertificazioneSpesaProvider.DbProviderObj, idDomandaPagamentoPerRigaFittizia, tstSel.Idcertsp, decertificazione.IdCertDecertificazione);
                        }

                        //5) Creo le righe associazione decertificazione di spesa
                        var decertificazioniCertificazioneSpesa = new AssociazioneDecertificazioniCertificazioneSpesaFittizie();
                        decertificazioniCertificazioneSpesa.IdcertspDettaglio = certSpDettaglioNuovo.IdcertspDettaglio;
                        decertificazioniCertificazioneSpesa.IdCertDecertificazione = decertificazione.IdCertDecertificazione;
                        decertificazioniCertificazioneSpesa.OperatoreInserimento = Operatore.Utente.CfUtente;
                        decertificazioniCertificazioneSpesa.DataInserimento = DateTime.Now;
                        decertificazioniCertificazioneSpesa.OperatoreModifica = Operatore.Utente.CfUtente;
                        decertificazioniCertificazioneSpesa.DataModifica = DateTime.Now;
                        decertificazioneSpesaProvider.Save(decertificazioniCertificazioneSpesa);

                        //6) Associo le decertificazioni alle righe fittizie
                        decertificazione.Assegnata = true;
                        decertificazione.IdDomandaPagamento = idDomandaPagamentoPerRigaFittizia;
                        decertificazione.Definitiva = false;
                        decertificazione.IdCertificazioneSpesa = tstSel.Idcertsp;
                        decertificazione.IdCertificazioneSpesaEffettiva = tstSel.Idcertsp;
                        certDecertificazioneCollectionProvider.Save(decertificazione);
                    }
                }

                /*  //OLD
                //var certSpDettaglioNuoveCollection = new CertspDettaglioCollection();
                foreach (int idDecertificazioniNuove in idDecertificazioniNuoveList)
                {
                    var decertificazione = certDecertificazioneCollectionProvider.GetById(idDecertificazioniNuove);
                    var certSpDettaglioPrecedenteCollection = detProv.Select(null, null, null, decertificazione.IdProgetto, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                    var domandeCollection = new DomandaDiPagamentoCollection();
                    int idDomandaPagamentoPerRigaFittizia;
                    var certSpDettaglioNuovo = new CertspDettaglio();

                    //Se presente uso l'ultima domanda di pagamento presente in certificazione, altrimenti uso la prima domanda di pagamento possibile con gli importi a 0
                    if (certSpDettaglioPrecedenteCollection.Count == 0)
                    {
                        var domandaPagamentoCollectionProvider = new DomandaDiPagamentoCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);
                        var progettoCollectionProvider = new ProgettoCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);
                        var impresaCollectionProvider = new ImpresaCollectionProvider(decertificazioneSpesaProvider.DbProviderObj);

                        domandeCollection = domandaPagamentoCollectionProvider.Find(null, null, decertificazione.IdProgetto, null);

                        if (domandeCollection.Count == 0)
                            throw new Exception("Errore nel recuperare i dati per la domanda di aiuto " + decertificazione.IdProgetto);

                        var domandaDaUsare = domandeCollection
                            .ToArrayList<DomandaDiPagamento>()
                            .OrderBy(d => d.IdDomandaPagamento)
                            .ToList<DomandaDiPagamento>()[0];
                        idDomandaPagamentoPerRigaFittizia = domandaDaUsare.IdDomandaPagamento;
                        var progettoDaUsare = progettoCollectionProvider.GetById(domandaDaUsare.IdProgetto);
                        var impresaDaUsare = impresaCollectionProvider.GetById(progettoDaUsare.IdImpresa);

                        certSpDettaglioNuovo.IdDomandaPagamento = domandaDaUsare.IdDomandaPagamento;
                        certSpDettaglioNuovo.IdProgetto = domandaDaUsare.IdProgetto;
                        certSpDettaglioNuovo.Asse = "32"; //DA MODIFICARE
                        certSpDettaglioNuovo.Costototale = 0.00;
                        certSpDettaglioNuovo.Beneficiario = impresaDaUsare.RagioneSociale;
                        certSpDettaglioNuovo.SpesaammessaIncrementale = 0.00;
                    }
                    else
                    {
                        var certSpDettaglioPrecedentiList = certSpDettaglioPrecedenteCollection
                        .ToArrayList<CertspDettaglio>()
                        .OrderByDescending(c => c.IdcertspDettaglio)
                        .ToList<CertspDettaglio>();
                        var certSpDettaglioPrecedente = certSpDettaglioPrecedentiList[0];
                        idDomandaPagamentoPerRigaFittizia = certSpDettaglioPrecedente.IdDomandaPagamento;

                        certSpDettaglioNuovo.IdDomandaPagamento = certSpDettaglioPrecedente.IdDomandaPagamento;
                        certSpDettaglioNuovo.IdProgetto = certSpDettaglioPrecedente.IdProgetto;
                        certSpDettaglioNuovo.Asse = certSpDettaglioPrecedente.Asse;
                        certSpDettaglioNuovo.Costototale = certSpDettaglioPrecedente.Costototale;
                        certSpDettaglioNuovo.Beneficiario = certSpDettaglioPrecedente.Beneficiario;
                        certSpDettaglioNuovo.SpesaammessaIncrementale = certSpDettaglioPrecedente.SpesaammessaIncrementale;
                    }

                    certSpDettaglioNuovo.Idcertsp = tstSel.Idcertsp;
                    certSpDettaglioNuovo.Selezionata = true;
                    certSpDettaglioNuovo.Importoconcesso = 0.00;
                    certSpDettaglioNuovo.Spesaammessa = 0.00;
                    certSpDettaglioNuovo.Importocontributopubblico = 0.00;
                    certSpDettaglioNuovo.ImportocontributopubblicoIncrementale = 0.00;
                    certSpDettaglioNuovo.Operatore = Operatore.Utente.CfUtente;
                    certSpDettaglioNuovo.Datainserimento = DateTime.Now;
                    certSpDettaglioNuovo.Datamodifica = DateTime.Now;
                    certSpDettaglioNuovo.Quotaue = 0.00;
                    certSpDettaglioNuovo.Quotastato = 0.00;
                    certSpDettaglioNuovo.Quotaregione = 0.00;
                    certSpDettaglioNuovo.Quotaprivato = 0.00;
                    detProv.Save(certSpDettaglioNuovo);
                    //certSpDettaglioNuoveCollection.Add(certSpDettaglioNuovo);

                    if (decertificazione.Definitiva != true)
                    {
                        tstProv.Sottrai_importi_decertificati(decertificazioneSpesaProvider.DbProviderObj, idDomandaPagamentoPerRigaFittizia, tstSel.Idcertsp, decertificazione.IdCertDecertificazione);
                        tstProv.Calcola_quote(decertificazioneSpesaProvider.DbProviderObj, idDomandaPagamentoPerRigaFittizia, tstSel.Idcertsp, decertificazione.IdCertDecertificazione);
                    }

                    //5) Creo le righe associazione decertificazione di spesa
                    var decertificazioniCertificazioneSpesa = new AssociazioneDecertificazioniCertificazioneSpesaFittizie();
                    decertificazioniCertificazioneSpesa.IdcertspDettaglio = certSpDettaglioNuovo.IdcertspDettaglio;
                    decertificazioniCertificazioneSpesa.IdCertDecertificazione = decertificazione.IdCertDecertificazione;
                    decertificazioniCertificazioneSpesa.OperatoreInserimento = Operatore.Utente.CfUtente;
                    decertificazioniCertificazioneSpesa.DataInserimento = DateTime.Now;
                    decertificazioniCertificazioneSpesa.OperatoreModifica = Operatore.Utente.CfUtente;
                    decertificazioniCertificazioneSpesa.DataModifica = DateTime.Now;
                    decertificazioneSpesaProvider.Save(decertificazioniCertificazioneSpesa);

                    //6) Associo le decertificazioni alle righe fittizie
                    decertificazione.Assegnata = true;
                    decertificazione.IdDomandaPagamento = idDomandaPagamentoPerRigaFittizia;
                    decertificazione.Definitiva = false;
                    decertificazione.IdCertificazioneSpesa = tstSel.Idcertsp;
                    decertificazione.IdCertificazioneSpesaEffettiva = tstSel.Idcertsp;
                    certDecertificazioneCollectionProvider.Save(decertificazione);
                }
                */

                //detProv.SaveCollection(certSpDettaglioNuoveCollection); //potrebber non essere necessario

                decertificazioneSpesaProvider.DbProviderObj.Commit();
                ShowMessage("Decertificazioni salvate correttamente");
            }
            catch (Exception ex)
            {
                decertificazioneSpesaProvider.DbProviderObj.Rollback();
                ShowError("Non è stato possibile salvare le decertificazioni, errore: " + ex.Message);
            }
        }
    }
}