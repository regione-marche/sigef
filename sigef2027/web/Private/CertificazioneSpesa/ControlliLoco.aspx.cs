using System;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using System.Collections.Generic;
using SiarLibrary.NullTypes;

namespace web.Private.CertificazioneSpesa
{
    public partial class ControlliLoco: SiarLibrary.Web.PrivatePage
    {
        // Cntr_Loco_Testa
        CntrlocoTestaCollectionProvider tstProv = new CntrlocoTestaCollectionProvider();
        CntrlocoTesta tstSel = null;
        // Cntr_Loco_Dettaglio
        CntrlocoDettaglioCollectionProvider detProv = new CntrlocoDettaglioCollectionProvider();
        CntrlocoDettaglio detSel = new CntrlocoDettaglio();

        enum RigaTbl { pari, dispari };
        const string frmMoney = "{0:c}";

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "controlli_in_locoN";
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
            visualizzaTesta();
            visualizzaDettaglio();
            visualizzaSingolo();

            base.OnPreRender(e);
        }

        private void HiddenFields_Valorizza()
        {
            // hdnIdLoco
            int idLoco;
            tstSel = null;
            if (int.TryParse(hdnIdLoco.Value, out idLoco))
            {
                tstSel = tstProv.GetById(idLoco);
            }

            // hdnIdProgetto
            int idProgetto;
            detSel = null;
            if (int.TryParse(hdnIdProgetto.Value, out idProgetto) && tstSel != null)
            {
                detSel = detProv.getPrjBy_IdProgetto(tstSel.Idloco, idProgetto);
            }

            // Combo Programmazione
            if (lstPsr.SelectedValue != hdnCodPsr.Value)
            {
                tstSel = null;
                detSel = null;
                hdnIdLoco.Value = null;
                hdnIdProgetto.Value = null;
                hdnCodPsr.Value = lstPsr.SelectedValue;
            }
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
        }

        private void AbilitaOggettiDettaglio()
        {
            if (tstSel.Definitivo)
            {
                btnSelezionaAuto.Enabled = false;
                btnDefinitivo.Enabled = false;
                btnCancella.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
                txtSegnaturaVerbale.Visible = true;
                txtSegnaturaVerbale.Text = tstSel.Segnatura;
                imgSegnaturaVerbale.Visible = true;
                imgSegnaturaVerbale.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + tstSel.Segnatura + "');");
                imgSegnaturaVerbale.Style.Add("cursor", "pointer");
            }
            else
            {
                txtSegnaturaVerbale.Visible = false;
                imgSegnaturaVerbale.Visible = false;
            }

        }

        #endregion

        #region Dati webform

        private CntrlocoDettaglioCollectionProvider.TipoDomande getDdlFiltro()
        {
            CntrlocoDettaglioCollectionProvider.TipoDomande ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Tutte;
            int selectedValue = 0;
            int hdnDdlFiltroApp;

            int.TryParse(ddlFiltro.SelectedValue, out selectedValue);
            int.TryParse(hdnDdlFiltro.Value, out hdnDdlFiltroApp);

            switch (selectedValue)
            {
                case 1:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Tutte;
                    break;
                case 2:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Incluse;
                    break;
                case 3:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Escluse;
                    break;
                case 4:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Alta;
                    break;
                case 5:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Media;
                    break;
                case 6:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Bassa;
                    break;
                case 7:
                    ret = CntrlocoDettaglioCollectionProvider.TipoDomande.Selezionate;
                    break;
            }

            if (selectedValue != hdnDdlFiltroApp)
            {
                detSel = null;
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

        private void visualizzaTesta()
        {
            CntrlocoTestaCollection tsts;

            if (string.IsNullOrEmpty(lstPsr.SelectedValue))
            {
                dgTesta.DataSource = null;
                divTesta.Visible = false;
                hdnIdLoco.Value = null;
                tstSel = null;

                return;
            }

            divTesta.Visible = true;

            if (tstSel != null)
            {
                tsts = new CntrlocoTestaCollection();
                tsts.Add(tstSel);
                dgTesta.Titolo = "Selezionare per ritornare all'elenco dei lotti";
            }
            else
            {
                tsts = tstProv.getBy_CodPsr(lstPsr.SelectedValue);
                if (tsts.Count == 0)
                {
                    dgTesta.Titolo = "Nessuna lotto presente per la programmazione selezionata";
                }
                else
                {
                    dgTesta.Titolo = "Selezionare il lotto per visualizzare il dettaglio";
                }
            }

            dgTesta.DataSource = tsts;
            dgTesta.DataBind();
        }

        private void visualizzaDettaglio()
        {
            const int cElenco = 1,
                      cDati = 2;

            if (tstSel == null)
            {
                dgDettaglio.DataSource = null;
                divDettaglio.Visible = false;
                hdnIdLocoDett = null;

                return;
            }
            divDettaglio.Visible = true;
            AbilitaOggettiDettaglio();

            switch (tabDettaglio.TabSelected)
            {
                case cElenco:
                    visualizzaDettaglioElenco();
                    break;
                case cDati:
                    detSel = null;
                    visualizzaDettaglioDati();
                    break;
            }
        }

        private void visualizzaDettaglioElenco()
        {
            CntrlocoDettaglioCollectionProvider.TipoDomande filtroValue = getDdlFiltro();
            //dets = detProv.getBy_IdLocoTipoDomanda(tstSel.Idloco, filtroValue, false);
            //dets = detProv.getPrjBy_IdLocoTipoDomanda(tstSel.Idloco, filtroValue, false);
            CntrlocoDettaglioCollection dets = getDettaglio_dets();

            dgDettaglio.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgDettaglio_ItemDataBound);

            lblNrRecord.Text = string.Format("Visualizzate {0} righe", dets.Count.ToString());
            dgDettaglio.DataSource = dets;

            dgDettaglio.DataBind();

            divDettaglioElenco.Visible = true;
            divDettaglioDati.Visible = false;
            if (tstSel.Definitivo)
                dgDettaglio.Columns[22].Visible = false;
        }

        private void visualizzaSingolo()
        {
            if (detSel == null)
            {
                dgSingolo.DataSource = null;
                divSingolo.Visible = false;

                return;
            }

            //dgSingolo.ItemDataBound += new DataGridItemEventHandler(dgSingolo_ItemDataBound);

            CntrlocoDettaglioCollection sngs = detProv.getBy_IdProgetto(tstSel.Idloco, detSel.IdProgetto);

            dgSingolo.DataSource = sngs;
            dgSingolo.DataBind();

            divSingolo.Visible = true;
        }

        #endregion

        #region Visualizza Dati riassuntivi

        private void visualizzaDettaglioDati()
        {
            GrigliaImporti_Popola();
            GrigliaPercentuali_Popola();

            divDettaglioElenco.Visible = false;
            divDettaglioDati.Visible = true;
        }


        private void GrigliaImporti_Popola()
        {
            List<RigaGrigliaImporti> TotaleImporti = detProv.Get_Totale_Importi_griglia(tstSel.Idloco);
            dgDettaglioDati.DataSource = TotaleImporti;
            dgDettaglioDati.ItemDataBound += new DataGridItemEventHandler(dgDettaglioDati_ItemDataBound);
            dgDettaglioDati.DataBind();
        }
        public void GrigliaPercentuali_Popola()
        {
            List<RigaGrigliaPercentuali> percentualiRiassuntive = detProv.Get_Totali_Percentuali_Griglia(tstSel.Idloco);
            dgPercentuali.DataSource = percentualiRiassuntive;
            dgPercentuali.ItemDataBound += new DataGridItemEventHandler(dgPercentuali_ItemDataBound);
            dgPercentuali.DataBind();
        }
        #endregion

        #region Eventi griglia

        void dgDettaglio_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CntrlocoDettaglio dett = (CntrlocoDettaglio)dgi.DataItem;
                if (string.IsNullOrEmpty(dett.Esclusione))
                {
                    dgi.Cells[23].Text = string.Format("<input type=button value='Escludi' onclick='mostraDivEscludi({0});' class='ButtonGrid' style='width:90px'",dgi.Cells[0].Text);
                }
            }
        }

        void dgDettaglioDati_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

        void dgPercentuali_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

        #region Button event

        protected void btnVisualizza_CreaLotto_Click(object sender, EventArgs e)
        {
            VisualizzaCreaLotto();
        }

        protected void btnCreaLotto_Click(object sender, EventArgs e)
        {
            CreaLotto();
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            CancellaLoco();
        }

        protected void btnSelezionaAuto_Click(object sender, EventArgs e)
        {
            if (tstSel.Definitivo.Value == true)
            {
                ShowError("Non è possibile cancellare un lotto di verifiche in loco definitivo");
                return;
            }
            try
            {
                detProv.SelezionaDomande(tstSel.Idloco);
                ShowMessage("Domande selezionate con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.ToString());
            }
        }

        protected void btnDefinitivo_Click(object sender, EventArgs e)
        {
            RendiDefinitivo();
        }

        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {
        }

        protected void btnEscludi_Click(object sender, EventArgs e)
        {
            int idProgetto = int.Parse(hdnIdDomandaDaEscludere.Value);
            string motivoEsclusione = txtMotivoEsclusione.Text;
            int idLoco = tstSel.Idloco;
            detProv.EscludiDomanda(idLoco, idProgetto, motivoEsclusione);
            ShowMessage(string.Format("Domanda {0} esclusa con successo.", hdnIdDomandaDaEscludere.Value.ToString()));
        }


        #endregion

        #region Data access

        private void CancellaLoco()
        {
            if (tstSel.Definitivo == true)
            {
                ShowError("Non è possibile cancellare un lotto di verifiche in loco definitivo");
                return;
            }
            try
            {
                tstProv.CancellaLoco(tstSel.Idloco);
                ShowMessage("Lotto cancellato con successo");
            }
            catch (SiarException ex)
            {
                ShowError(ex.Message);
                return;
            }

            hdnIdLoco.Value = null;
            hdnIdLocoDett.Value = null;
            HiddenFields_Valorizza();
        }

        private void CreaLotto()
        {
            if (!string.IsNullOrEmpty(lstPsr.SelectedValue) && !string.IsNullOrEmpty(txtDataFine.Text))
            {
                string codPsr = lstPsr.SelectedValue;
                DatetimeNT dataInizio = null;
                if (!string.IsNullOrEmpty(txtDataInizio.Text))
                {
                    DateTime dInizio = DateTime.ParseExact(txtDataInizio.Text,
                    "yyyy-MM-dd",
                    null);
                    dataInizio = new DatetimeNT(dInizio);
                }

                DateTime dFine = DateTime.ParseExact(txtDataFine.Text,
                    "yyyy-MM-dd",
                    null);
                DatetimeNT dataFine = new DatetimeNT(dFine);

                if (!tstProv.noTemporaryLot(codPsr))
                {
                    ShowError("Può essere presente 1 solo lotto non definitivo");
                    return;
                }
                try
                {
                    if (dataInizio == null)
                    {
                        hdnIdLoco.Value = tstProv.creaLoco(codPsr, dataFine, Operatore.Utente.IdUtente).ToString();
                    }
                    else
                    {
                        hdnIdLoco.Value = tstProv.creaLoco(codPsr, dataInizio, dataFine, Operatore.Utente.IdUtente).ToString();
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Si è verificato un errore in fase di creazione del lotto delle verifiche in loco"); //, ex.ToString());
                }
            }
            hdnIdLoco.Value = null;
            hdnIdLocoDett.Value = null;
            HiddenFields_Valorizza();
            txtDataInizio.Text = null;
            txtDataFine.Text = null;

        }

        private CntrlocoDettaglioCollection getDettaglio_dets()
        {
            CntrlocoDettaglioCollection dets = null;
            CntrlocoDettaglioCollectionProvider.TipoDomande filtroValue = getDdlFiltro();

            if (detSel != null)
            {
                dets = new CntrlocoDettaglioCollection();
                dets.Add(detSel);
            }
            else
            {
                dets = detProv.getPrjBy_IdLocoTipoDomanda(tstSel.Idloco, filtroValue, false);
            }

            return dets;
        }

        private void RendiDefinitivo()
        {
            try
            {
                SiarBLL.CntrlocoTestaCollectionProvider provider = new SiarBLL.CntrlocoTestaCollectionProvider();
                SiarLibrary.CntrlocoTesta ct = provider.GetById(tstSel.Idloco);
                if (ct.Datasegnatura == null || ct.Segnatura == null)
                {
                    throw new Exception("La data e segnatura del verbale non sono stati inseriti!");
                }
                tstProv.RendiDefinitivoLoco(tstSel.Idloco);
                btnSelezionaAuto.Enabled = false;
                btnDefinitivo.Enabled = false;
                btnCancella.Enabled = false;
                btnInserisciSegnatura.Enabled = false;
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
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        #endregion

        #region Segnatura

        protected void btnInserisciSegnatura_Click(object sender, EventArgs e)
        {
            try
            {
                int idLoco;
                CntrlocoTestaCollectionProvider provider = new CntrlocoTestaCollectionProvider();
                if (hdnIdLoco.Value != "" && hdnIdLoco.Value != null)
                {
                    idLoco = Convert.ToInt32(hdnIdLoco.Value);
                    CntrlocoTesta ct = provider.GetById(idLoco);
                    txtData.Text = ct.Datasegnatura == null ? "" : ct.Datasegnatura.ToStringAgid();
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
                int idLoco;
                CntrlocoTestaCollectionProvider provider = new CntrlocoTestaCollectionProvider();
                if (hdnIdLoco.Value == "" || hdnIdLoco.Value == null)
                    throw new Exception("ID del controllo in loco non creato!");
                else
                    idLoco = Convert.ToInt32(hdnIdLoco.Value);
                if ((txtData.Text == "" || txtData.Text == null) 
                    && (txtSegnatura.Text == null || txtSegnatura.Text == "")) 
                    throw new Exception("Inserire la data e la segnatura");

                if (!new Protocollo().ProtocolloEsistente(txtSegnatura.Text))
                    throw new SiarException(TextErrorCodes.DocumentoNonValido);

                CntrlocoTesta ct = provider.GetById(idLoco);
                ct.Datasegnatura = txtData.Text;
                ct.Segnatura = txtSegnatura.Text;
                provider.Save(ct);
                
                ShowMessage("La Data e la segnatura sono state salvate correttamente.");

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
        #endregion
    }
}
