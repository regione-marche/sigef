using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarLibrary.Web;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace web.Private.Controlli
{
    public partial class LottiVerificheAmministrative : PrivatePage
    {
        VerificaAmministrativaTestaCollectionProvider testaProvider = new VerificaAmministrativaTestaCollectionProvider();
        VerificaAmministrativaTesta testaSelezionata = null;
        VerificaAmministrativaDettaglioCollectionProvider dettaglioProvider = new VerificaAmministrativaDettaglioCollectionProvider();
        VerificaAmministrativaDettaglio dettaglioSelezionato = new VerificaAmministrativaDettaglio();

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "lotti_veriche_amministrative";

            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AbilitaOggettiLoad();
            HiddenFields_Valorizza();
            RegisterClientScriptBlock("abilitaScroll();");
        }

        protected override void OnPreRender(EventArgs e)
        {
            lstPsr.DataBind();
            VisualizzaTesta();
            VisualizzaDettaglio();
            VisualizzaSingolo();

            base.OnPreRender(e);
        }

        #region Autorizzazioni

        private void AbilitaOggettiLoad()
        {
            // Testa
            btnCreaLotto.Enabled = AbilitaModifica;

            // Dettaglio
            btnSelezionaAuto.Enabled = AbilitaModifica;
            btnDefinitivo.Enabled = AbilitaModifica;
            btnCancella.Enabled = AbilitaModifica;
            btnInserisciSegnatura.Enabled = AbilitaModifica;
            //btnInserisciSegnatura.Disabled = !AbilitaModifica;
        }

        private void AbilitaOggettiDettaglio()
        {
            if (testaSelezionata.Definitivo)
            {
                btnSelezionaAuto.Enabled = false;
                btnDefinitivo.Enabled = false;
                btnCancella.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
                //btnInserisciSegnatura.Disabled = true;
                txtSegnaturaVerbale.Visible = true;
                txtSegnaturaVerbale.Text = testaSelezionata.Segnatura;
                imgSegnaturaVerbale.Visible = true;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + testaSelezionata.Segnatura + "');");
                imgSegnaturaVerbale.Style.Add("cursor", "pointer");
            }
            else
            {
                txtSegnaturaVerbale.Visible = false;
                imgSegnaturaVerbale.Visible = false;
            }
        }

        #endregion

        #region Visualizza Dati riassuntivi

        private void VisualizzaDettaglioDati()
        {
            PopolaGrigliaImporti();
            PopolaGrigliaPercentuali();

            divDettaglioElenco.Visible = false;
            divDettaglioDati.Visible = true;
        }


        private void PopolaGrigliaImporti()
        {
            List<RigaGrigliaImporti> TotaleImporti = dettaglioProvider.GetTotaleImportiGriglia(testaSelezionata.IdLotto);
            dgDettaglioDati.DataSource = TotaleImporti;
            dgDettaglioDati.ItemDataBound += new DataGridItemEventHandler(dgDettaglioDati_ItemDataBound);
            dgDettaglioDati.DataBind();
        }

        public void PopolaGrigliaPercentuali()
        {
            List<RigaGrigliaPercentuali> percentualiRiassuntive = dettaglioProvider.GetTotaliPercentualiGriglia(testaSelezionata.IdLotto);
            dgPercentuali.DataSource = percentualiRiassuntive;
            dgPercentuali.ItemDataBound += new DataGridItemEventHandler(dgPercentuali_ItemDataBound);
            dgPercentuali.DataBind();
        }

        #endregion

        #region Eventi griglia

        void dgTesta_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                VerificaAmministrativaTesta testa = (VerificaAmministrativaTesta)dgi.DataItem;
                
                if (testa.Definitivo != null && testa.Definitivo)
                    dgi.Cells[3].Text = "Sì";
                else
                    dgi.Cells[3].Text = "No";
            }
        }

        void dgDettaglio_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                VerificaAmministrativaDettaglio dett = (VerificaAmministrativaDettaglio)dgi.DataItem;

                if (dett.Selezionata != null && dett.Selezionata)
                    dgi.Cells[18].Text = "Sì";
                else
                    dgi.Cells[18].Text = "No";

                if (string.IsNullOrEmpty(dett.Esclusione))
                {
                    dgi.Cells[23].Text = string.Format("<input type=button value='Escludi' onclick='mostraDivEscludi({0});' class='ButtonGrid' style='width:90px'", dgi.Cells[0].Text);
                }
            }
        }

        void dgDettaglioDati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RigaGrigliaImporti riga = (RigaGrigliaImporti)dgi.DataItem;
                dgi.Cells[1].Text = string.Format("{0:c}", riga.Tutte);
                dgi.Cells[2].Text = string.Format("{0:c}", riga.Incluse);
                dgi.Cells[3].Text = string.Format("{0:c}", riga.Escluse);
                dgi.Cells[4].Text = string.Format("{0:c}", riga.Alto);
                dgi.Cells[5].Text = string.Format("{0:c}", riga.Medio);
                dgi.Cells[6].Text = string.Format("{0:c}", riga.Basso);
            }
        }

        void dgPercentuali_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RigaGrigliaPercentuali riga = (RigaGrigliaPercentuali)dgi.DataItem;
                dgi.Cells[1].Text = string.Format("{0:c}", riga.Teorico);
                dgi.Cells[2].Text = string.Format("{0:c}", riga.Selezionato);
                dgi.Cells[3].Text = string.Format("{0:c}", riga.Definitivo);
            }
        }

        #endregion

        #region Dati webform

        private VerificaAmministrativaDettaglioCollectionProvider.TipoDomande GetDdlFiltro()
        {
            VerificaAmministrativaDettaglioCollectionProvider.TipoDomande ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Tutte;
            int selectedValue = 0;
            int hdnDdlFiltroApp;

            int.TryParse(ddlFiltro.SelectedValue, out selectedValue);
            int.TryParse(hdnDdlFiltro.Value, out hdnDdlFiltroApp);

            switch (selectedValue)
            {
                case 1:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Tutte;
                    break;
                case 2:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Incluse;
                    break;
                case 3:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Escluse;
                    break;
                case 4:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Sempre;
                    break;
                case 5:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Alta;
                    break;
                case 6:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Media;
                    break;
                case 7:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Bassa;
                    break;
                case 8:
                    ret = VerificaAmministrativaDettaglioCollectionProvider.TipoDomande.Selezionate;
                    break;
            }

            if (selectedValue != hdnDdlFiltroApp)
            {
                dettaglioSelezionato = null;
                hdnDdlFiltro.Value = selectedValue.ToString();
            }

            return ret;
        }

        #endregion

        #region Visualizza div webform

        private void VisualizzaCreaLotto()
        {
            if (string.IsNullOrEmpty(hdnCreaLotto.Value))
            {
                hdnCreaLotto.Value = "false";
            }

            if (hdnCreaLotto.Value == "false")
            {
                hdnCreaLotto.Value = "true";
            }
            else
            {
                hdnCreaLotto.Value = "false";
            }
        }

        private void VisualizzaTesta()
        {
            VerificaAmministrativaTestaCollection tsts;

            if (string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                dgTesta.DataSource = null;
                divTesta.Visible = false;
                hdnIdLotto.Value = null;
                testaSelezionata = null;

                return;
            }

            divTesta.Visible = true;

            if (testaSelezionata != null)
            {
                tsts = new VerificaAmministrativaTestaCollection();
                tsts.Add(testaSelezionata);
                dgTesta.Titolo = "Selezionare per ritornare all'elenco dei lotti";
            }
            else
            {
                tsts = testaProvider.GetByCodPsr(lstPsr.SelectedValue);
                
                if (tsts.Count == 0)
                {
                    dgTesta.Titolo = "Nessun lotto presente per la programmazione selezionata";
                }
                else
                {
                    dgTesta.Titolo = "Selezionare il lotto per visualizzare il dettaglio";
                }
            }

            dgTesta.DataSource = tsts;
            dgTesta.ItemDataBound += new DataGridItemEventHandler(dgTesta_ItemDataBound);
            dgTesta.DataBind();
        }

        private void VisualizzaDettaglio()
        {
            const int cElenco = 1,
                      cDati = 2;

            if (testaSelezionata == null)
            {
                dgDettaglio.DataSource = null;
                divDettaglio.Visible = false;
                hdnIdLottoDett = null;

                return;
            }
            divDettaglio.Visible = true;
            AbilitaOggettiDettaglio();

            switch (tabDettaglio.TabSelected)
            {
                case cElenco:
                    VisualizzaDettaglioElenco();
                    break;
                case cDati:
                    dettaglioSelezionato = null;
                    VisualizzaDettaglioDati();
                    break;
            }
        }

        private void VisualizzaDettaglioElenco()
        {
            VerificaAmministrativaDettaglioCollectionProvider.TipoDomande filtroValue = GetDdlFiltro();
            VerificaAmministrativaDettaglioCollection dets = GetDettaglioDets();

            dgDettaglio.ItemDataBound += new DataGridItemEventHandler(dgDettaglio_ItemDataBound);

            lblNrRecord.Text = string.Format("Visualizzate {0} righe", dets.Count.ToString());
            dgDettaglio.DataSource = dets;

            dgDettaglio.DataBind();

            divDettaglioElenco.Visible = true;
            divDettaglioDati.Visible = false;
            if (testaSelezionata.Definitivo)
                dgDettaglio.Columns[22].Visible = false;
        }

        private void VisualizzaSingolo()
        {
            if (dettaglioSelezionato == null)
            {
                dgSingolo.DataSource = null;
                divSingolo.Visible = false;

                return;
            }

            VerificaAmministrativaDettaglioCollection sngs = dettaglioProvider.GetBy_IdProgetto(testaSelezionata.IdLotto, dettaglioSelezionato.IdProgetto);

            dgSingolo.DataSource = sngs;
            dgSingolo.DataBind();

            divSingolo.Visible = true;
        }

        #endregion

        private VerificaAmministrativaDettaglioCollection GetDettaglioDets()
        {
            VerificaAmministrativaDettaglioCollection dets = null;
            VerificaAmministrativaDettaglioCollectionProvider.TipoDomande filtroValue = GetDdlFiltro();

            if (dettaglioSelezionato != null)
            {
                dets = new VerificaAmministrativaDettaglioCollection();
                dets.Add(dettaglioSelezionato);
            }
            else
            {
                dets = dettaglioProvider.GetPrjBy_IdLottoTipoDomanda(testaSelezionata.IdLotto, filtroValue, false);
            }

            return dets;
        }

        private void HiddenFields_Valorizza()
        {
            // hdnIdLotto
            int idLotto;
            testaSelezionata = null;
            if (int.TryParse(hdnIdLotto.Value, out idLotto))
            {
                testaSelezionata = testaProvider.GetById(idLotto);
            }

            // hdnIdProgetto
            int idProgetto;
            dettaglioSelezionato = null;
            if (int.TryParse(hdnIdProgetto.Value, out idProgetto) && testaSelezionata != null)
            {
                dettaglioSelezionato = dettaglioProvider.GetPrjBy_IdProgetto(testaSelezionata.IdLotto, idProgetto);
            }

            // Combo Programmazione
            if (lstPsr.SelectedValue != hdnCodPsr.Value)
            {
                testaSelezionata = null;
                dettaglioSelezionato = null;
                hdnIdLotto.Value = null;
                hdnIdProgetto.Value = null;
                hdnCodPsr.Value = lstPsr.SelectedValue;
            }
        }

        protected void btnCreaLotto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue) && !string.IsNullOrEmpty(txtDataFine.Text))
            {
                string codPsr = lstPsr.SelectedValue;
                DatetimeNT dataInizio = txtDataInizio.Text;
                DatetimeNT dataFine = txtDataFine.Text;
                CntrlocoTestaCollectionProvider controlliLocoTestaProvider = new CntrlocoTestaCollectionProvider();
                IntNT idLottoVerificheAmministrative = null;
                IntNT idLottoControlliLoco = null;

                if (testaProvider.LottiNonDefinitiviPresenti(codPsr))
                {
                    ShowError("Può essere presente un solo lotto non definitivo");
                    return;
                }

                try
                {
                    if (dataInizio == null)
                    {
                        idLottoVerificheAmministrative = testaProvider.CreaLotto(codPsr, dataFine, Operatore.Utente.CfUtente).ToString();
                        hdnIdLotto.Value = idLottoVerificheAmministrative;
                        idLottoControlliLoco = controlliLocoTestaProvider.CreaLocoConVerificheAmministrative(codPsr, idLottoVerificheAmministrative, dataFine, Operatore.Utente.IdUtente);
                    }
                    else
                    {
                        idLottoVerificheAmministrative = testaProvider.CreaLotto(codPsr, dataInizio, dataFine, Operatore.Utente.CfUtente).ToString();
                        hdnIdLotto.Value = idLottoVerificheAmministrative;
                        idLottoControlliLoco = controlliLocoTestaProvider.CreaLocoConVerificheAmministrative(codPsr, idLottoVerificheAmministrative, dataInizio, dataFine, Operatore.Utente.IdUtente);
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Si è verificato un errore in fase di creazione del lotto delle verifiche amministrative");
                }

                if (idLottoControlliLoco == null)
                    throw new Exception("Non sono riuscito a creare il lotto delle verifiche in loco");

                ShowMessage("Lotto verifiche amministrative e loco creati correttamente, id lotto amministrativo: " + hdnIdLotto.Value + " - id lotto loco: " + idLottoControlliLoco);
            }
            else
                ShowError("Programma non selezionato o data di fine non inserita");

            hdnIdLotto.Value = null;
            hdnIdLottoDett.Value = null;
            HiddenFields_Valorizza();
            txtDataInizio.Text = null;
            txtDataFine.Text = null;
        }

        protected void btnSelezionaAuto_Click(object sender, EventArgs e)
        {
            if (testaSelezionata.Definitivo)
            {
                ShowError("Non è possibile cancellare un lotto di verifiche amministrative definitivo");
                return;
            }

            try
            {
                //Solo per la prima certificazione dovranno essere tutte selezionate
                dettaglioProvider.SelezionaTutteDomande(testaSelezionata.IdLotto, Operatore.Utente.CfUtente);
                //dettaglioProvider.SelezionaDomande(testaSelezionata.IdLotto, Operatore.Utente.CfUtente);
                ShowMessage("Domande selezionate con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.ToString());
            }
        }

        protected void btnDefinitivo_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaAmministrativaTesta ct = testaProvider.GetById(testaSelezionata.IdLotto);
                if (ct.DataSegnatura == null || ct.Segnatura == null)
                {
                    throw new Exception("La data e segnatura del verbale non sono stati inseriti!");
                }
                testaProvider.RendiDefinitivoLotto(testaSelezionata.IdLotto, Operatore.Utente.CfUtente);
                btnSelezionaAuto.Enabled = false;
                btnDefinitivo.Enabled = false;
                btnCancella.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
                //btnInserisciSegnatura.Disabled = true;
                txtSegnaturaVerbale.Visible = true;
                txtSegnaturaVerbale.Text = ct.Segnatura;
                imgSegnaturaVerbale.Visible = true;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + ct.Segnatura + "');");
                imgSegnaturaVerbale.Style.Add("cursor", "pointer");
                ShowMessage("Lotto marcato come Definitivo");
            }
            catch (Exception ex)
            {
                string messaggio = "Attenzione! " + ex.Message;
                //RegisterClientScriptBlock("alert('" + messaggio + "');");
                ShowError(messaggio);
            }
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e) { }

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                int idLotto;
                if (hdnIdLotto.Value != "" && hdnIdLotto.Value != null)
                {
                    idLotto = Convert.ToInt32(hdnIdLotto.Value);
                    VerificaAmministrativaTesta ct = testaProvider.GetById(idLotto);
                    txtData.Text = ct.DataSegnatura == null ? "" : ct.DataSegnatura.ToStringAgid();
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

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            if (testaSelezionata.Definitivo)
            {
                ShowError("Non è possibile cancellare un lotto di verifiche amministrative definitivo");
                return;
            }

            try
            {
                CntrlocoTestaCollectionProvider controlliLocoTestaProvider = new CntrlocoTestaCollectionProvider();
                var controlliLocoTestaCollection = controlliLocoTestaProvider.Select(null, testaSelezionata.Codpsr, testaSelezionata.DataInizio, testaSelezionata.DataFine, null, null, null, null, null, null, null);
                if (controlliLocoTestaCollection.Count > 0)
                {
                    // dovrei averne solo uno ma nel dubbio li cancello tutti
                    foreach (CntrlocoTesta cntrlocoTesta in controlliLocoTestaCollection)
                    {
                        controlliLocoTestaProvider.CancellaLoco(cntrlocoTesta.Idloco);
                    }
                }
                else
                    throw new Exception("Lotto delle verifiche in loco con lo stesso periodo delle verifiche amministrative non trovato");

                testaProvider.CancellaLotto(testaSelezionata.IdLotto);

                ShowMessage("Lotti verifiche amministrative e verifiche in loco cancellati con successo");
            }
            catch (SiarException ex)
            {
                ShowError(ex.Message);
                return;
            }

            hdnIdLotto.Value = null;
            hdnIdLottoDett.Value = null;
            HiddenFields_Valorizza();
        }

        protected void btnSalvaSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                int idLotto;
                if (hdnIdLotto.Value == "" || hdnIdLotto.Value == null)
                    throw new Exception("ID delle verifiche amministrative non creato!");
                else
                    idLotto = Convert.ToInt32(hdnIdLotto.Value);
                
                if ((txtData.Text == "" || txtData.Text == null) 
                    && (txtSegnatura.Text == null || txtSegnatura.Text == "")) 
                    throw new Exception("Inserire la data e la segnatura");
                
                if (!new Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);

                VerificaAmministrativaTesta ct = testaProvider.GetById(idLotto);
                ct.DataSegnatura = txtData.Text;
                ct.Segnatura = txtSegnatura.Text;
                ct.DataModifica = DateTime.Now;
                ct.OperatoreModifica = Operatore.Utente.CfUtente;
                testaProvider.Save(ct);
                
                ShowMessage("La data e la segnatura sono state salvate correttamente.");
            }
            catch (Exception ex)
            {
                string messaggio = "Attenzione! " + ex.Message;
                //btnInserisciSegnatura_Click(sender, e);
                //RegisterClientScriptBlock("alert('" + messaggio + "');");
                ShowError(messaggio);
            }
            finally
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
            }
        }

        protected void btnEscludi_Click(object sender, EventArgs e)
        {
            int idProgetto = int.Parse(hdnIdDomandaDaEscludere.Value);
            string motivoEsclusione = txtMotivoEsclusione.Text;
            int idLotto = testaSelezionata.IdLotto;
            var dettList = dettaglioProvider
                .GetBy_IdProgetto(idLotto, idProgetto)
                .ToArrayList<VerificaAmministrativaDettaglio>();
            
            foreach (var dettaglio in dettList)
            {
                if (dettaglio.TipoDomanda != "Sempre")
                {
                    dettaglio.Esclusione = motivoEsclusione;
                    dettaglio.OperatoreModifica = Operatore.Utente.CfUtente;
                    dettaglio.DataModifica = DateTime.Now;
                    dettaglioProvider.Save(dettaglio);
                }
            }
            ShowMessage(string.Format("Domanda {0} esclusa con successo (se non sottoposta a controlli al 100%).", hdnIdDomandaDaEscludere.Value.ToString()));
        }
    }
}