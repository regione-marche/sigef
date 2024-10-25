using System;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.UI;
using System.Collections.Generic;
using TelegramBot;
using System.Threading;
using System.Linq;

namespace web.Private.Psr.Bandi
{
    public partial class Dettaglio : SiarLibrary.Web.BandoPage
    {
        SiarBLL.BandoResponsabiliCollectionProvider responsabili_provider = new SiarBLL.BandoResponsabiliCollectionProvider();
        SiarBLL.BandoValutatoriCollectionProvider valutatori_provider = new SiarBLL.BandoValutatoriCollectionProvider();
        SiarBLL.BandoStoricoCollectionProvider storico_provider;
        SiarBLL.BandoIntegrazioniCollectionProvider integrazioni_provider;
        SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider;
        SiarBLL.BandoConfigCollectionProvider bconfig_provider;
        SiarBLL.AttiCollectionProvider atti_provider = new SiarBLL.AttiCollectionProvider();
        SiarLibrary.Zprogrammazione misura_bando = null;
        Boolean Organismi_intermedi = false;

        // multiprogrammazione
        SiarBLL.ZprogrammazioneCollectionProvider prog_provider = new SiarBLL.ZprogrammazioneCollectionProvider();
        SiarLibrary.ZprogrammazioneCollection progs;
        const int chkBoxInterventi = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            integrazioni_provider = new SiarBLL.BandoIntegrazioniCollectionProvider(BandoProvider.DbProviderObj);
            storico_provider = new SiarBLL.BandoStoricoCollectionProvider(BandoProvider.DbProviderObj);
            programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(BandoProvider.DbProviderObj);
            misura_bando = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(Bando.IdProgrammazione);
            AbilitaModifica = AbilitaModifica && TipoModifica == 2;
            zmlDisposizioniAttuative.AbilitaModifica = !Bando.DisposizioniAttuative && Bando.CodStato == "P";
            string Str_Organismi_intermedi = "";
            Str_Organismi_intermedi = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Bando.IdBando);
            if (Str_Organismi_intermedi == "True")
                Organismi_intermedi = true;
        }

        private enum Dimensioni
        {
            IOC,
            IOS,
            D1,
            D2,
            D3,
            D6,
            RG
        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:

                    // multiprogrammazione
                    int iAzione;

                    lstPsr.DataBind();

                    if (!string.IsNullOrEmpty(lstPsr.SelectedValue))
                    {
                        tbAzioni.Visible = true;

                        lstAzione.CodicePsr = lstPsr.SelectedValue;
                        lstAzione.AttivazioneBandi = true;
                        lstAzione.DataBind();

                        // Selezione Azione
                        if (!string.IsNullOrEmpty(lstAzione.SelectedValue))
                        {
                            int.TryParse(lstAzione.SelectedValue, out iAzione);

                            progs = prog_provider.GetProgrammazionePsr(lstPsr.SelectedValue, lstAzione.SelectedValue, null, null, null, true, null);

                            if (!(progs.Count == 0))
                            {
                                foreach (SiarLibrary.Zprogrammazione d in progs)
                                {
                                    ListItem a = new ListItem();
                                    a.Text = d.Codice + " " + d.Descrizione;
                                    a.Value = d.Id;
                                    ddlInterventi.Items.Add(a);
                                }
                            }

                            ddlInterventi.DataBind();
                            if (hdnIdIntervento.Value != null && hdnIdIntervento.Value != "")
                                ddlInterventi.SelectedValue = hdnIdIntervento.Value;
                            btnAddProgrammazione.Visible = true;
                        }
                    }


                    tbProgrammazione.Visible = true;
                    txtPRGPREVCodice.Text = misura_bando.Tipo + " " + misura_bando.Codice;
                    txtPRGPREVDescrizione.Text = misura_bando.Descrizione;

                    //SiarLibrary.BandoProgrammazioneCollection interventi = programmazione_provider.GetProgrammazioneBando(Bando.IdBando, false);

                    SiarLibrary.BandoProgrammazioneCollection interventi = programmazione_provider.Find(Bando.IdBando, null, null, null);

                    dgPRGPREVInterventi.DataSource = interventi;
                    dgPRGPREVInterventi.ItemDataBound += new DataGridItemEventHandler(dgPRGPREVInterventi_ItemDataBound);
                    dgPRGPREVInterventi.DataBind();

                    if (!Bando.DisposizioniAttuative)
                    {
                        ((SiarLibrary.Web.JsButtonColumn)dgPRGDispAttuative.Columns[4]).AbilitaModifica = Bando.CodStato == "P";
                        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative = programmazione_provider.GetProgrammazioneBando(Bando.IdBando, true);
                        dgPRGDispAttuative.DataSource = disposizioni_attuative;
                        dgPRGDispAttuative.Titolo = "Elementi trovati: " + disposizioni_attuative.Count;
                        dgPRGDispAttuative.ItemDataBound += new DataGridItemEventHandler(dgPRGDispAttuative_ItemDataBound);
                        dgPRGDispAttuative.DataBind();
                        tbsubDisposizioniAttuative.Visible = true;
                    }
                    break;
                case 3:
                    tbFinanziario.Visible = true;

                    SiarLibrary.BandoTipoInvestimentiCollection tipo_investimenti = new SiarBLL.BandoTipoInvestimentiCollectionProvider().GetTipoInvestimentiBando(Bando.IdBando);
                    dgFINTipoInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgFINTipoInvestimenti_ItemDataBound);
                    dgFINTipoInvestimenti.DataSource = tipo_investimenti;
                    dgFINTipoInvestimenti.DataBind();

                    SiarLibrary.BandoMassimaliCollection massimali = new SiarBLL.BandoMassimaliCollectionProvider().GetMassimaliBandoInterventi(Bando.IdBando);
                    dgFINMassimali.ItemDataBound += new DataGridItemEventHandler(dgFINMassimali_ItemDataBound);
                    dgFINMassimali.DataSource = massimali;
                    dgFINMassimali.DataBind();
                    break;
                case 4:
                    tbBusinessPlan.Visible = true;

                    SiarLibrary.BusinessPlanCollection bp = new SiarBLL.BusinessPlanCollectionProvider().GetBusinessPlanBando(Bando.IdBando);
                    dgBPQuadri.DataSource = bp;
                    dgBPQuadri.ItemDataBound += new DataGridItemEventHandler(dgBPQuadri_ItemDataBound);
                    dgBPQuadri.DataBind();
                    break;
                case 5:
                    tbRelazioneTecnica.Visible = true;
                    SiarBLL.BandoRelazioneTecnicaCollectionProvider relazione_provider = new SiarBLL.BandoRelazioneTecnicaCollectionProvider();
                    SiarLibrary.BandoRelazioneTecnica rl = null;
                    int id_paragrafo;
                    if (int.TryParse(hdnIdParagrafo.Value, out id_paragrafo)) rl = relazione_provider.GetById(id_paragrafo);
                    if (rl == null)
                    {
                        rl = new SiarLibrary.BandoRelazioneTecnica();
                        btnRELParagrafoElimina.Enabled = false;
                    }
                    txtRELTitolo.Text = rl.Titolo ?? "";
                    txtRELDescrizione.Text = rl.Descrizione ?? "";
                    txtRELOrdine.Text = rl.Ordine ?? "";

                    SiarLibrary.BandoRelazioneTecnicaCollection paragrafi = relazione_provider.Find(Bando.IdBando);
                    dgRELParagrafi.DataSource = paragrafi;
                    dgRELParagrafi.Titolo = "Elementi trovati: " + paragrafi.Count;
                    dgRELParagrafi.ItemDataBound += new DataGridItemEventHandler(dgRELParagrafi_ItemDataBound);
                    dgRELParagrafi.DataBind();
                    break;
                case 6:
                    tbAvanzate.Visible = true;
                    btnSalvaConfig.Enabled = Operatore.Utente.CodEnte == "%" && Operatore.Utente.Profilo == "Amministratore";
                    if (bconfig_provider == null) bconfig_provider = new SiarBLL.BandoConfigCollectionProvider();
                    SiarLibrary.BandoConfigCollection cc = bconfig_provider.GetBandoConfig(Bando.IdBando);
                    dgBandoConfig.DataSource = cc;
                    dgBandoConfig.ItemDataBound += new DataGridItemEventHandler(dgBandoConfig_ItemDataBound);
                    dgBandoConfig.DataBind();
                    break;
                default:
                    tbDatiGenerali.Visible = true;
                    btnRiaperturaBando.Enabled = btnEliminaIntegrazione.Enabled = TipoModifica == 3;
                    btnAggiungiIntegrazione.Disabled = TipoModifica != 3;
                    if (TipoModifica == 3)
                    {
                        if (!Organismi_intermedi)
                            btnAggiungiIntegrazione.Attributes.Add("onclick", "aggiungiIntegrazione('" + zmlDecretoBando.UniqueID.Replace("$", "_") + "');");
                        else
                        {
                            btnAggiungiIntegrazioneOrgInt.Visible = true;
                            btnAggiungiIntegrazione.Attributes.Add("onclick", "mostraPopupTemplate('divDecretoOrgInt','divBKGMessaggio');");
                        }
                    }

                    btnSalvaResponsabili.Enabled = (AbilitaModifica || TipoModifica == 3);

                    txtAperturaData.Text = Bando.DataApertura;
                    if (Bando.DataApertura != null) txtAperturaOra.Text = Bando.DataApertura.Value.Hour + ":" + Bando.DataApertura.Value.Minute;
                    txtScadenzaData.Text = Bando.DataScadenza;
                    txtScadenzaOra.Text = Bando.DataScadenza.Value.Hour + ":" + Bando.DataScadenza.Value.Minute;
                    txtImportoTotale.Text = Bando.Importo;
                    txtImportoMisura.Text = Bando.ImportoDiMisura;
                    txtQuotaRiserva.Text = Bando.QuotaRiserva;
                    txtDescrizione.Text = Bando.Descrizione;
                    txtParoleChiave.Text = Bando.ParoleChiave;
                    chkMultiProgetto.Checked = Bando.Multiprogetto;
                    chkRichiediFascicolo.Checked = Bando.FascicoloRichiesto;
                    chkDispAttuative.Checked = Bando.DisposizioniAttuative;
                    chkAbilitaAggregazioni.Checked = Bando.Aggregazione;
                    if (Bando.DisposizioniAttuative) chkMultiProgetto.Enabled = chkRichiediFascicolo.Enabled = false;
                    chkManifInteresse.Checked = Bando.InteresseFiliera;
                    chkMultiMisura.Checked = Bando.Multimisura;
                    chkAbilitaValutazione.Checked = Bando.AbilitaValutazione;
                    if (misura_bando != null)
                    {
                        txtProgrammazioneCodice.Text = misura_bando.Tipo + " " + misura_bando.Codice;
                        txtProgrammazioneDescrizione.Text = misura_bando.Descrizione;
                    }

                    if (Bando.CodEnte != null)
                    {
                        txtCodEnteEmettitore.Text = Bando.CodEnte;
                        txtEnteEmettitore.Text = Bando.Ente;
                    }

                    //gestione Codice Procedura Attivazione IGRUE
                    string codAttivazione = BandoProvider.GetCodAttivazioneBando(Bando.IdBando);
                    txtCodAttivazione.Text = codAttivazione;
                    btnCodAttivazione.Visible = CheckAbilitaCodAttivazione(Bando.IdBando, codAttivazione);

                    if (!Organismi_intermedi)
                    {
                        SiarLibrary.BandoStoricoCollection storico_documentale = BandoProvider.GetStoricoDocumentale(Bando.IdBando);
                        dgDocumenti.Titolo = "Elementi trovati: " + storico_documentale.Count;
                        dgDocumenti.DataSource = storico_documentale;
                        dgDocumenti.DataBind();
                    }
                    else
                    {
                        //pulsanti
                        //btnPubblica.Visible = false;
                        //btnPubblicaOrgInt.Visible = true;

                        //storico documentale
                        trDocumentale.Visible = false;
                        trDocumentaleOrganismi_inter.Visible = true;
                        SiarLibrary.AttiCollection atti_coll = atti_provider.SpPsrGetDocumentiBandoOrganismiInter(Bando.IdBando);
                        dgDocumentiOrganismi_inter.Titolo = "Elementi trovati: " + atti_coll.Count;
                        dgDocumentiOrganismi_inter.ItemDataBound += new DataGridItemEventHandler(dgDocumentiOrganismi_inter_itemDataBound);
                        dgDocumentiOrganismi_inter.DataSource = atti_coll;
                        dgDocumentiOrganismi_inter.DataBind();
                    }


                    if (AbilitaModifica || TipoModifica == 3)
                    {
                        txtResponsabileBando.AddJSAttribute("onkeydown", "pv_corrente='Bando';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        txtResponsabileAN.AddJSAttribute("onkeydown", "pv_corrente='AN';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        txtResponsabileAP.AddJSAttribute("onkeydown", "pv_corrente='AP';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        txtResponsabileMC.AddJSAttribute("onkeydown", "pv_corrente='MC';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        txtResponsabilePU.AddJSAttribute("onkeydown", "pv_corrente='PU';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        txtResponsabileFM.AddJSAttribute("onkeydown", "pv_corrente='FM';tipo='resp';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                    }
                    SiarLibrary.BandoResponsabiliCollection responsabili = responsabili_provider.Find(Bando.IdBando, null, null, null, true);

                    int idResponsabile = 0;

                    foreach (SiarLibrary.BandoResponsabili r in responsabili)
                    {
                        if (r.Provincia == null)
                        {
                            idResponsabile = r.IdUtente;
                            txtResponsabileBando.Text = r.Nominativo;
                            hdnIdResponsabileBando.Value = r.IdUtente;
                            continue;
                        }
                        switch (r.Provincia.Value)
                        {
                            case "AN": txtResponsabileAN.Text = r.Nominativo; hdnIdResponsabileAN.Value = r.IdUtente; break;
                            case "AP": txtResponsabileAP.Text = r.Nominativo; hdnIdResponsabileAP.Value = r.IdUtente; break;
                            case "MC": txtResponsabileMC.Text = r.Nominativo; hdnIdResponsabileMC.Value = r.IdUtente; break;
                            case "PU": txtResponsabilePU.Text = r.Nominativo; hdnIdResponsabilePU.Value = r.IdUtente; break;
                            case "FM": txtResponsabileFM.Text = r.Nominativo; hdnIdResponsabileFM.Value = r.IdUtente; break;
                        }
                    }

                    if (Bando.AbilitaValutazione)
                    {
                        bool abilitato = checkStatoBando(idResponsabile);
                        //btnSalvaValutatori.Enabled = abilitato;
                        btnAggiungiMembro.Enabled = abilitato;
                        btnEliminaMembro.Enabled = abilitato && !string.IsNullOrEmpty(hdnIdValutatorePost.Value);
                        btnNewMembro.Enabled = abilitato;

                        // sezione valutatori
                        if (abilitato)
                        {
                            //int pv_corrente = 1;
                            txtValutatore.AddJSAttribute("onkeydown", "tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                            //txtValutatore1.AddJSAttribute("onkeydown", "pv_corrente='1';tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                            //txtValutatore2.AddJSAttribute("onkeydown", "pv_corrente='2';tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                            //txtValutatore3.AddJSAttribute("onkeydown", "pv_corrente='3';tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                            //txtValutatore4.AddJSAttribute("onkeydown", "pv_corrente='4';tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                            //txtValutatore5.AddJSAttribute("onkeydown", "pv_corrente='5';tipo='val';SNCVolatileZoom(this,event,'SNCVZCercaUtenti');");
                        }

                        tdValutatori.Visible = true;
                        SiarLibrary.BandoValutatoriCollection valutatori = valutatori_provider.Find(null, Bando.IdBando, null, true, null);
                        //foreach (SiarLibrary.BandoValutatori v in valutatori)
                        //{
                        //    SiarBLL.UtentiCollectionProvider utenti_provider = new SiarBLL.UtentiCollectionProvider();
                        //    switch (v.Ordine.Value)
                        //    {
                        //        case 1: txtValutatore1.Text = v.Nominativo; hdnIdValutatore1.Value = v.IdUtente; break;
                        //        case 2: txtValutatore2.Text = v.Nominativo; hdnIdValutatore2.Value = v.IdUtente; break;
                        //        case 3: txtValutatore3.Text = v.Nominativo; hdnIdValutatore3.Value = v.IdUtente; break;
                        //        case 4: txtValutatore4.Text = v.Nominativo; hdnIdValutatore4.Value = v.IdUtente; break;
                        //        case 5: txtValutatore5.Text = v.Nominativo; hdnIdValutatore5.Value = v.IdUtente; break;
                        //    }
                        //}
                        dgValutatori.Titolo = "Elementi trovati: " + valutatori.Count.ToString();
                        dgValutatori.DataSource = valutatori;
                        dgValutatori.DataBind();
                    }
                    else
                        tdValutatori.Visible = false;

                    //Fascicolo 
                    string[] ss = BandoProvider.GetFascicolo(Bando.IdBando);
                    if (ss[1] != null && ss[1] != "")
                        txtFascicoloPaleo.Text = ss[1];
                    break;
            }
            base.OnPreRender(e);
        }

        #region Organismi_intermedi
        void dgDocumentiOrganismi_inter_itemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;

            if (dgi.ItemType != ListItemType.Header && dgi.ItemType != ListItemType.Footer)
            {
                SiarLibrary.Atti atto = (SiarLibrary.Atti)dgi.DataItem;
                e.Item.Cells[4].Text = "<a href = '" + atto.LinkEsterno + "' target='_blank'><img title ='Atto estern' src='" + Request.ApplicationPath + "/images/lente.png' /></a>";
            }
        }

        protected void btnSalvaDescretoOrg_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            try
            {
                if (txtDataDecreto.Text == "" || txtDataDecreto.Text == null
                    || txtNumeroDecreto.Text == "" || txtNumeroDecreto.Text == null
                    || txtDescrizioneDecreto.Text == "" || txtDescrizioneDecreto.Text == null
                    || txtLinkEst.Text == "" || txtLinkEst.Text == null)
                    throw new Exception("Informazioni mancanti. Inserire tutti i dati relativi al Decreto/Atto.");
                btnPubblicazioneBando_Click(sender, e);
            }
            catch (Exception ex)
            {
                messaggio = "Attenzione! " + ex.Message;
                btnPubblica_Click(sender, e);
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }
        protected void btnAggiungiIntegrazioneOrgInt_Click(object sender, EventArgs e)
        {
            string messaggio = "";
            try
            {
                if (txtDataDecreto.Text == "" || txtDataDecreto.Text == null
                    || txtNumeroDecreto.Text == "" || txtNumeroDecreto.Text == null
                    || txtDescrizioneDecreto.Text == "" || txtDescrizioneDecreto.Text == null
                    || txtLinkEst.Text == "" || txtLinkEst.Text == null)
                    throw new Exception("Informazioni mancanti. Inserire tutti i dati relativi al Decreto/Atto.");
                btnIntegrazione_Click(sender, e);
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                messaggio = "Attenzione! " + ex.Message;
                RegisterClientScriptBlock("alert('" + messaggio + "');");
            }
        }

        #endregion

        protected void btnAddProgrammazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdIntervento.Value != "" && hdnIdIntervento.Value != "-1")
                {
                    if (programmazione_provider.Find(Bando.IdBando, hdnIdIntervento.Value, null, null).Count > 0)
                        throw new Exception("L'intervento è stato già aggiunto al bando, selezionarne un'altro.");
                    SiarLibrary.BandoProgrammazione p = new SiarLibrary.BandoProgrammazione();
                    p.IdBando = Bando.IdBando;
                    p.IdProgrammazione = hdnIdIntervento.Value;
                    p.MisuraPrevalente = false;
                    programmazione_provider.Save(p);
                }
                else
                {
                    throw new Exception("Selezionare un intervento valido");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        void dgBandoConfig_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoConfig c = (SiarLibrary.BandoConfig)e.Item.DataItem;

                switch (c.Formato)
                {
                    case "bool":
                        CheckBox chk = new CheckBox();
                        chk.ID = "dgBandoConfigValore" + c.CodTipo;
                        bool b = false;
                        if (c.Valore != null) bool.TryParse(c.Valore.ToString(), out b);
                        chk.Checked = b;
                        e.Item.Cells[5].Controls.Add(chk);
                        break;
                    case "date":
                        SiarLibrary.Web.DateTextBox dt = new SiarLibrary.Web.DateTextBox();
                        dt.ID = "dgBandoConfigValore" + c.CodTipo;
                        dt.Width = new Unit(120);
                        if (c.Valore != null) dt.Text = c.Valore;
                        e.Item.Cells[5].Controls.Add(dt);
                        break;
                    case "number":
                        SiarLibrary.Web.CurrencyBox cb = new SiarLibrary.Web.CurrencyBox();
                        cb.ID = "dgBandoConfigValore" + c.CodTipo;
                        cb.Width = new Unit(120);
                        if (c.Valore != null) cb.Text = c.Valore;
                        e.Item.Cells[5].Controls.Add(cb);
                        break;
                    case "text":
                        SiarLibrary.Web.TextBox tb = new SiarLibrary.Web.TextBox();
                        tb.ID = "dgBandoConfigValore" + c.CodTipo;
                        tb.Width = new Unit(250);
                        if (c.Valore != null) tb.Text = c.Valore;
                        e.Item.Cells[5].Controls.Add(tb);
                        break;
                    case "plurivalore":
                        Control ctrl = LoadControl("~/CONTROLS/SNCBandoConfigPlurivalore.ascx");
                        ctrl.ID = "dgBandoConfigValore" + c.CodTipo;
                        ctrl.GetType().GetProperty("CodTipo").SetValue(ctrl, c.CodTipo.Value, null);
                        if (c.Valore != null) ctrl.GetType().GetProperty("Valore").SetValue(ctrl, c.Valore.Value, null);
                        if (c.ValoreDescrizione != null) ctrl.GetType().GetProperty("Testo").SetValue(ctrl, c.ValoreDescrizione.Value, null);
                        e.Item.Cells[5].Controls.Add(ctrl);
                        break;
                    case "multivalore":
                        Control ctrlMulti = LoadControl("~/CONTROLS/SNCBandoConfigMultivalore.ascx");
                        ctrlMulti.ID = "dgBandoConfigValore" + c.CodTipo;
                        ctrlMulti.GetType().GetProperty("CodTipo").SetValue(ctrlMulti, c.CodTipo.Value, null);
                        if (c.Valore != null)
                            ctrlMulti.GetType().GetProperty("Valore").SetValue(ctrlMulti, c.Valore.Value, null);
                        if (c.Id != null && c.MultiValoreDescrizione() != null)
                            ctrlMulti.GetType().GetProperty("Testo").SetValue(ctrlMulti, c.MultiValoreDescrizione().Replace(";", ";\n"), null);
                        e.Item.Cells[5].Controls.Add(ctrlMulti);
                        break;
                    default: e.Item.Cells[5].Text = "<span style='color:red'>Formato non riconosciuto</span>"; break;
                }
            }
        }

        private bool checkStatoBando(int idResponsabile)
        {
            bool enabled = false;

            if ((Operatore.Utente.IdUtente == idResponsabile || Operatore.Utente.CodEnte == "%") && Bando.OrdineStato < 5)
                enabled = true;
            return enabled;
        }

        void dgFINTipoInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoTipoInvestimenti b = (SiarLibrary.BandoTipoInvestimenti)e.Item.DataItem;
                if (b.IdBando != null) e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace("<input ", "<input checked ");
            }
        }

        void dgBPQuadri_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BusinessPlan b = (SiarLibrary.BusinessPlan)e.Item.DataItem;
                if (b.IdBando != null) e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace("<input ", "<input checked ");
            }
        }

        void dgRELParagrafi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoRelazioneTecnica rt = (SiarLibrary.BandoRelazioneTecnica)e.Item.DataItem;
                e.Item.Cells[1].Text = "<b>" + rt.Titolo + "</b><br/>" + rt.Descrizione;
            }
        }

        void dgFINMassimali_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoMassimali p = (SiarLibrary.BandoMassimali)e.Item.DataItem;
                e.Item.Cells[1].Text = "<b>" + p.Codice + "</b> - " + p.Descrizione;
                if (p.Id != null) e.Item.Cells[4].Text = e.Item.Cells[4].Text.Replace("<input ", "<input checked ");
            }
        }

        void dgPRGDispAttuative_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoProgrammazione p = (SiarLibrary.BandoProgrammazione)e.Item.DataItem;
                e.Item.Cells[1].Text = p.AdditionalAttributes["PADRE"];
                e.Item.Cells[2].Text = "<b>Codice:</b> " + p.Codice + "<br /><b>Descrizione:</b> " + p.Descrizione;
            }
        }

        void dgPRGPREVInterventi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int cChkBox = 4;
            //const int cSottoc = 3;
            const int cDatiCa = 3;
            const int cDel = 5;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.BandoProgrammazione p = (SiarLibrary.BandoProgrammazione)e.Item.DataItem;
                if (p.MisuraPrevalente)
                {
                    e.Item.Cells[cChkBox].Text = e.Item.Cells[cChkBox].Text.Replace("<input ", "<input disabled='disabled' checked ");
                }
                else
                {
                    e.Item.Cells[cChkBox].Text = e.Item.Cells[cChkBox].Text.Replace("<input ", "<input disabled='disabled' ");
                    e.Item.Cells[cDel].Text = "<input type='Button' class='ButtonGrid' value='Elimina' onclick='eliminaIntervento(" + p.Id + ");' />";
                }
                //e.Item.Cells[cSottoc].Text = p.AdditionalAttributes["PADRE"];
                e.Item.Cells[cDatiCa].Text = leggiCategorieIntervento(p.IdProgrammazione);
            }

        }

        protected void btnEliminaIntervento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.BandoProgrammazione b = programmazione_provider.GetById(hdnIdInterventoDel.Value);
                SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider();
                if (codifica_provider.Find(Bando.IdBando, b.IdProgrammazione).Count > 0) throw new Exception("L'intervento è associato ad almeno una codifica investimento, impossibile eliminare.");
                programmazione_provider.Delete(b);
                ShowMessage("Intervento eliminato con successo.");
            }
            catch (Exception Ex)
            {
                ShowError(Ex.Message);
            }
        }

        private string leggiCategorieIntervento(int IdProgrammazione)
        {
            int cCodDim = 0;
            int cDescri = 1;

            string datiHtml = "";
            string[,] dimensioni = new string[,] { { "D1", "Campo di intervento" },
                                                   { "D2", "Forme di finanziamento"},
                                                   { "D3", "Tipo di territorio"},
                                                   { "D6", "Meccanismi di attuazione"}
                                                 };

            SiarBLL.ZdimensioniCollectionProvider dimPro = new SiarBLL.ZdimensioniCollectionProvider();
            SiarLibrary.ZdimensioniCollection dims = null;


            SiarLibrary.Zprogrammazione prg = new SiarLibrary.Zprogrammazione();
            SiarBLL.ZprogrammazioneCollectionProvider prgPro = new SiarBLL.ZprogrammazioneCollectionProvider();

            // Obbiettivo Tematico
            prg = prgPro.GetById(IdProgrammazione);
            while (prg.Livello > 1)
            {
                prg = prgPro.GetById(prg.IdPadre);
            }
            dims = dimPro.GetByIdProgramCodTipo(prg.Id, "OT");
            if (dims.Count > 0)
            {
                foreach (SiarLibrary.Zdimensioni dim in dims)
                {
                    // datiHtml += string.Format("<strong>{0}</strong><br>", dim.Codice);
                    datiHtml += string.Format("{0}<br>", dim.Codice);
                }
            }

            // Dimensione 1, 2, 3, 6
            for (int i = 0; i < dimensioni.GetLength(0); i++)
            {
                dims = dimPro.GetByIdProgramCodTipo(IdProgrammazione, dimensioni[i, cCodDim]);
                if (dims.Count > 0)
                {
                    datiHtml += string.Format("<strong>{0}</strong><br>", dimensioni[i, cDescri]);
                    foreach (SiarLibrary.Zdimensioni dim in dims)
                    {
                        datiHtml += string.Format("{0} - {1}<br>", dim.Codice, dim.Descrizione);
                    }
                }
            }

            return datiHtml;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                BandoProvider.DbProviderObj.BeginTran();
                Bando.Descrizione = txtDescrizione.Text;
                Bando.ParoleChiave = txtParoleChiave.Text;
                Bando.Multiprogetto = chkMultiProgetto.Checked;
                Bando.FascicoloRichiesto = chkRichiediFascicolo.Checked;
                Bando.AbilitaValutazione = chkAbilitaValutazione.Checked;
                Bando.Aggregazione = chkAbilitaAggregazioni.Checked;
                Bando.DataApertura = txtAperturaData.Text + " " + txtAperturaOra.Text;

                // se disabilito la valutazione tolgo tutti i valutatori (attivo = false)
                if (chkAbilitaValutazione.Checked == false)
                {
                    valutatori_provider = new SiarBLL.BandoValutatoriCollectionProvider(BandoProvider.DbProviderObj);
                    foreach (SiarLibrary.BandoValutatori v in valutatori_provider.Find(null, Bando.IdBando, null, true, null))
                    {
                        v.Attivo = false;
                        v.DataFine = DateTime.Now;
                        valutatori_provider.Save(v);
                    }
                }
                BandoProvider.Save(Bando);

                SiarLibrary.BandoIntegrazioni ib = integrazioni_provider.GetById(Bando.IdIntegrazioneUltima);
                if (ib == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                ib.Data = DateTime.Now;
                ib.Operatore = Operatore.Utente.IdUtente;
                string ora_scadenza = "23:59";
                if (!string.IsNullOrEmpty(txtScadenzaOra.Text) && txtScadenzaOra.Text.Length == 5) ora_scadenza = txtScadenzaOra.Text;
                ib.DataScadenza = txtScadenzaData.Text + " " + ora_scadenza;
                ib.Importo = txtImportoTotale.Text;
                ib.ImportoDiMisura = txtImportoMisura.Text;
                ib.QuotaRiserva = txtQuotaRiserva.Text;
                integrazioni_provider.Save(ib);

                //Fascicolo 
                if (txtFascicoloPaleo.Text != "" && txtFascicoloPaleo.Text != null)
                {
                    SiarBLL.FascicoloPaleoCollectionProvider fasc_prov = new SiarBLL.FascicoloPaleoCollectionProvider();
                    string[] ss = BandoProvider.GetFascicolo(Bando.IdBando);
                    if (ss[0] != null && ss[0] != "")
                    {

                        SiarLibrary.FascicoloPaleo Fascicolo = fasc_prov.GetById(Convert.ToInt32(ss[0]));
                        if (Fascicolo != null)
                        {
                            Fascicolo.Fascicolo = txtFascicoloPaleo.Text;
                            fasc_prov.Save(Fascicolo);
                        }
                    }
                    else
                    {
                        SiarLibrary.FascicoloPaleo Fascicolo = new SiarLibrary.FascicoloPaleo();
                        Fascicolo.Anno = DateTime.Today.Year;
                        SiarLibrary.Zprogrammazione progr = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(Bando.IdProgrammazione);
                        Fascicolo.CodTipo = progr.CodTipo + " " + progr.Codice + " " + Bando.IdBando.ToString();
                        Fascicolo.Fascicolo = txtFascicoloPaleo.Text;
                        Fascicolo.Provincia = "AN";
                        Fascicolo.CodEnte = Bando.CodEnte;
                        Fascicolo.Attivo = true;
                        Fascicolo.DataInizioValidita = DateTime.Parse(Convert.ToString(DateTime.Today.Year) + "-01-01");
                        fasc_prov.Save(Fascicolo);
                    }
                }

                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Bando salvato correttamente.");
                Bando = BandoProvider.GetById(Bando.IdBando);
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                BandoProvider.DbProviderObj.BeginTran();
                // responsabili
                SiarBLL.BandoResponsabiliCollectionProvider responsabili_provider = new SiarBLL.BandoResponsabiliCollectionProvider(BandoProvider.DbProviderObj);
                responsabili_provider.DeleteCollection(responsabili_provider.Find(Bando.IdBando, null, null, null, null));

                // programmazione
                SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(BandoProvider.DbProviderObj);
                programmazione_provider.DeleteCollection(programmazione_provider.Find(Bando.IdBando, null, null, null));

                // massimali
                SiarBLL.BandoMassimaliCollectionProvider massimali_provider = new SiarBLL.BandoMassimaliCollectionProvider(BandoProvider.DbProviderObj);
                massimali_provider.DeleteCollection(massimali_provider.Find(Bando.IdBando, null));

                //tipo investimenti bando
                SiarBLL.BandoTipoInvestimentiCollectionProvider tipo_investimenti_provider = new SiarBLL.BandoTipoInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                tipo_investimenti_provider.DeleteCollection(tipo_investimenti_provider.Find(Bando.IdBando, null, null));

                //Relazione Tecnica
                SiarBLL.BandoRelazioneTecnicaCollectionProvider brtPro = new SiarBLL.BandoRelazioneTecnicaCollectionProvider(BandoProvider.DbProviderObj);
                brtPro.DeleteCollection(brtPro.Find(Bando.IdBando));

                //quadri di business plan
                SiarBLL.BusinessPlanCollectionProvider bp_provider = new SiarBLL.BusinessPlanCollectionProvider(BandoProvider.DbProviderObj);
                bp_provider.DeleteCollection(bp_provider.Find(Bando.IdBando));

                //codifica - dettaglio - specifica
                SiarBLL.CodificaInvestimentoCollectionProvider codificaprovider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.DettaglioInvestimentiCollectionProvider dettaglioprovider = new SiarBLL.DettaglioInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                SiarBLL.SpecificaInvestimentiCollectionProvider specificaprovider = new SiarBLL.SpecificaInvestimentiCollectionProvider(BandoProvider.DbProviderObj);

                SiarLibrary.CodificaInvestimentoCollection codificacoll = codificaprovider.Find(Bando.IdBando, null);
                foreach (SiarLibrary.CodificaInvestimento codifica in codificacoll)
                {
                    SiarLibrary.DettaglioInvestimentiCollection dettagliocollection = dettaglioprovider.Find(codifica.IdCodificaInvestimento, null);
                    foreach (SiarLibrary.DettaglioInvestimenti dettaglio in dettagliocollection)
                        specificaprovider.DeleteCollection(specificaprovider.Find(dettaglio.IdDettaglioInvestimento, null));
                    dettaglioprovider.DeleteCollection(dettagliocollection);
                }
                codificaprovider.DeleteCollection(codificacoll);

                // settori produttivi e Priorita settoriali
                SiarBLL.BandoXSettoreProduttivoCollectionProvider settori_provider = new SiarBLL.BandoXSettoreProduttivoCollectionProvider(BandoProvider.DbProviderObj);
                settori_provider.DeleteCollection(settori_provider.Find(Bando.IdBando, null, null));

                // step x bando
                SiarBLL.StepXBandoCollectionProvider sp = new SiarBLL.StepXBandoCollectionProvider(BandoProvider.DbProviderObj);
                sp.DeleteCollection(sp.Find(Bando.IdBando, null, null, null));

                // modello domanda
                if (Bando.IdModelloDomanda != null)
                {
                    //allegati x domanda
                    SiarBLL.AllegatiXDomandaCollectionProvider allprov = new SiarBLL.AllegatiXDomandaCollectionProvider(BandoProvider.DbProviderObj);
                    allprov.DeleteCollection(allprov.Find(null, Bando.IdModelloDomanda, null));
                    //quadri x domanda
                    SiarBLL.QuadriXDomandaCollectionProvider quadprov = new SiarBLL.QuadriXDomandaCollectionProvider(BandoProvider.DbProviderObj);
                    quadprov.DeleteCollection(quadprov.Find(null, Bando.IdModelloDomanda, null));
                    //dichiarazioni x domanda
                    SiarBLL.DichiarazioniXDomandaCollectionProvider dichprov = new SiarBLL.DichiarazioniXDomandaCollectionProvider(BandoProvider.DbProviderObj);
                    dichprov.DeleteCollection(dichprov.Find(null, Bando.IdModelloDomanda));
                }

                // Elimino i requisiti di variante agganciati al bando
                SiarBLL.BandoRequisitiVarianteCollectionProvider bandoReqVarProv = new SiarBLL.BandoRequisitiVarianteCollectionProvider(BandoProvider.DbProviderObj);
                bandoReqVarProv.DeleteCollection(bandoReqVarProv.Find(Bando.IdBando, null));
                // elimino le tipologie di variante agganciate al bando
                SiarBLL.BandoTipoVariantiCollectionProvider bandoVarProv = new SiarBLL.BandoTipoVariantiCollectionProvider(BandoProvider.DbProviderObj);
                bandoVarProv.DeleteCollection(bandoVarProv.Find(Bando.IdBando, null));

                // Elimimo prima i requisiti di pagamento agganciati al bando
                SiarBLL.BandoRequisitiPagamentoCollectionProvider bandoReqPagProv = new SiarBLL.BandoRequisitiPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                bandoReqPagProv.DeleteCollection(bandoReqPagProv.Find(Bando.IdBando, null, null));
                // Poi elimino le tipologie di pagamento agganciate al bando 
                SiarBLL.BandoTipoPagamentoCollectionProvider bandoPagProv = new SiarBLL.BandoTipoPagamentoCollectionProvider(BandoProvider.DbProviderObj);
                bandoPagProv.DeleteCollection(bandoPagProv.Find(Bando.IdBando, null, null));

                // Elimino i valutatori agganciati al bando
                SiarBLL.BandoValutatoriCollectionProvider bandoValutatori = new SiarBLL.BandoValutatoriCollectionProvider(BandoProvider.DbProviderObj);
                bandoValutatori.DeleteCollection(bandoValutatori.Find(null, Bando.IdBando, null, null, null));
                // Elimino bando config
                SiarBLL.BandoConfigCollectionProvider config_provider = new SiarBLL.BandoConfigCollectionProvider(BandoProvider.DbProviderObj);
                config_provider.DeleteCollection(config_provider.Find(Bando.IdBando, null, null, null, null));
                // integrazioni
                integrazioni_provider.Delete(integrazioni_provider.GetById(Bando.IdIntegrazioneUltima));
                // storico
                storico_provider.Delete(storico_provider.GetById(Bando.IdStoricoUltimo));
                // bando
                BandoProvider.Delete(Bando);
                //modello domanda
                if (Bando.IdModelloDomanda != null)
                {
                    SiarBLL.ModelloDomandaCollectionProvider modello_provider = new SiarBLL.ModelloDomandaCollectionProvider(BandoProvider.DbProviderObj);
                    modello_provider.Delete(modello_provider.GetById(Bando.IdModelloDomanda));
                }
                BandoProvider.DbProviderObj.Commit();
                Redirect("ricerca.aspx", "Bando eliminato correttamente.", false);
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoModifica != 3) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_atto = 0;
                if (!Organismi_intermedi)
                {
                    if (!int.TryParse(hdnIdAtto.Value, out id_atto)) throw new Exception("Per proseguire è necessario selezionare l'atto di riferimento.");
                }
                else
                {
                    SiarLibrary.Atti atto = new SiarLibrary.Atti();
                    atto.CodTipo = "A";
                    atto.CodDefinizione = "D";
                    atto.CodOrganoIstituzionale = "OI";
                    atto.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecreto.Text);
                    atto.Data = txtDataDecreto.Text;
                    atto.Descrizione = txtDescrizioneDecreto.Text;
                    atto.LinkEsterno = txtLinkEst.Text;
                    atti_provider.Save(atto);
                    id_atto = atto.IdAtto;
                }


                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoIntegrazioni i = new SiarLibrary.BandoIntegrazioni();
                i.IdBando = Bando.IdBando;
                string ora_scadenza = "23:59";
                if (!string.IsNullOrEmpty(txtScadenzaOra.Text) && txtScadenzaOra.Text.Length == 5) ora_scadenza = txtScadenzaOra.Text;
                i.DataScadenza = txtScadenzaData.Text + " " + ora_scadenza;
                i.Importo = txtImportoTotale.Text;
                i.ImportoDiMisura = txtImportoMisura.Text;
                i.QuotaRiserva = txtQuotaRiserva.Text;
                i.IdAtto = id_atto;
                i.Data = DateTime.Now;
                i.Operatore = Operatore.Utente.IdUtente;
                integrazioni_provider.Save(i);

                Bando.IdIntegrazioneUltima = i.Id;
                BandoProvider.Save(Bando);

                BandoProvider.DbProviderObj.Commit();
                Bando = BandoProvider.GetById(Bando.IdBando);
                if (Organismi_intermedi)
                {
                    RegisterClientScriptBlock("chiudiPopupTemplate();");
                    txtNumeroDecreto.Text = "";
                    txtDataDecreto.Text = "";
                    txtDescrizioneDecreto.Text = "";
                    txtLinkEst.Text = "";
                }

                ShowMessage("Integrazione al bando salvata correttamente.");
            }
            catch (Exception ex)
            {
                BandoProvider.DbProviderObj.Rollback();
                RegisterClientScriptBlock("chiudiPopupTemplate();");
                ShowError(ex);
            }
        }

        protected void btnEliminaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoModifica != 3) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.BandoIntegrazioniCollection integrazioni_bando = integrazioni_provider.Find(Bando.IdBando);
                if (integrazioni_bando.Count < 2) throw new Exception("Il bando non possiede nessuna integrazione, impossibile continuare.");
                BandoProvider.DbProviderObj.BeginTran();
                Bando.IdIntegrazioneUltima = integrazioni_bando[1].Id;
                BandoProvider.Save(Bando);
                integrazioni_provider.Delete(integrazioni_bando[0]);
                BandoProvider.DbProviderObj.Commit();
                Bando = BandoProvider.GetById(Bando.IdBando);
                ShowMessage("Integrazione al bando eliminata correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRiaperturaBando_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoModifica != 3) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.Bando bn = BandoProvider.RiapriBando(Bando.IdBando, Operatore.Utente.IdUtente);
                Redirect("Dettaglio.aspx?idb=" + bn.IdBando, "Il nuovo bando è stato inserito correttamente, è ora possibile iniziarne la profilazione completa.", false);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnPubblica_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarLibrary.Web.ReportTemplates rt = new SiarLibrary.Web.ReportTemplates();
                bool modello_creato = rt.ModelloDomandaReportExists(Bando.IdModelloDomanda);
                rt.Dispose();
                if (!modello_creato) throw new Exception("Non è stato salvato il report del modello di domanda, controllare la pagina di definizione del Modello di Domanda.");

                bool isPorFesr = new SiarBLL.ZprogrammazioneCollectionProvider().isPorFesr(Bando.IdProgrammazione);

                if (isPorFesr && !checkPagamentiAnticipi()) throw new Exception("La natura cup del bando non permette di salvare la configurazione degli anticipi attuale.");
                string messaggio = BandoProvider.VerificaCondizioniPubblicazioneBando(Bando.IdBando);
                if (!Organismi_intermedi)
                    RegisterClientScriptBlock("selezioneAtto('" + zmlDecretoBando.UniqueID.Replace("$", "_") + "','" + messaggio + "','P');");
                else
                    RegisterClientScriptBlock("mostraPopupTemplate('divDecretoOrgInt','divBKGMessaggio');");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        public bool checkPagamentiAnticipi()
        {
            bool ok = true;
            SiarLibrary.BandoTipoPagamentoCollection tipi_pagamento = new SiarBLL.BandoTipoPagamentoCollectionProvider().FindByIdBando(Bando.IdBando);

            SiarBLL.BandoConfigCollectionProvider bandoConfigCollectionProvider = new SiarBLL.BandoConfigCollectionProvider();
            List<string> naturaCup = bandoConfigCollectionProvider.GetBandoConfig_NaturaCupList(Bando.IdBando);

            foreach (SiarLibrary.BandoTipoPagamento tipo in tipi_pagamento)
            {
                if (!SiarLibrary.ControlliNaturaCup.ControllaTipoDomandePagamentoByNaturaCupBando(naturaCup, tipo.QuotaMax, tipo.CodTipoPolizza, tipo))
                {
                    ok = false;
                }
            }

            return ok;
        }

        protected async void btnPubblicazioneBando_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_atto = 0;
                if (!Organismi_intermedi)
                {
                    if (!int.TryParse(hdnIdAtto.Value, out id_atto))
                        throw new Exception("Per proseguire è necessario selezionare l'atto di riferimento.");
                }
                else
                {
                    SiarLibrary.Atti atto = new SiarLibrary.Atti();
                    atto.CodTipo = "A";
                    atto.CodDefinizione = "D";
                    atto.CodOrganoIstituzionale = "OI";
                    atto.Numero = new SiarLibrary.NullTypes.IntNT(txtNumeroDecreto.Text);
                    atto.Data = txtDataDecreto.Text;
                    atto.Descrizione = txtDescrizioneDecreto.Text;
                    atto.LinkEsterno = txtLinkEst.Text;
                    atti_provider.Save(atto);
                    id_atto = atto.IdAtto;
                }

                //  TODO: Creo fascicolo in Paleo e lo inserisco nelle configurazioni del Bando
                //string paleoFascicolo = string.Empty;
                //SiarLibrary.Protocollo p = new SiarLibrary.Protocollo();
                //paleoFascicolo = p.CreaFascicolo(ctrlPaleoFascicoloDescr.Text, ctrlPaleoClassifica.Text, "", "", "Protocollista", "");
                //if (string.IsNullOrEmpty(paleoFascicolo))
                //    throw new Exception("Erore nella creazione del fascicolo in Paleo.");
                //else { 
                //    // scrivi fascicolo in BANDO_CONFIG
                //    ctrlPaleoFascicolo.Text = paleoFascicolo; 
                //}

                BandoProvider.DbProviderObj.BeginTran();
                // storico
                SiarLibrary.BandoStorico s = new SiarLibrary.BandoStorico();
                s.IdBando = Bando.IdBando;
                s.CodStato = "L";
                s.Data = DateTime.Now;
                s.Operatore = Operatore.Utente.IdUtente;
                s.IdAtto = id_atto;
                storico_provider.Save(s);

                Bando.IdStoricoUltimo = s.Id;
                //Bando.DataApertura = DateTime.Now;
                Bando.DataApertura = Bando.DataApertura;
                BandoProvider.Save(Bando);

                // anche le disposizioni
                SiarLibrary.Bando dispo = new SiarLibrary.Bando();
                SiarLibrary.BandoIntegrazioni bi = new SiarLibrary.BandoIntegrazioni();
                SiarLibrary.BandoProgrammazioneCollection bpcol = programmazione_provider.GetProgrammazioneBando(Bando.IdBando, true);
                foreach (SiarLibrary.BandoProgrammazione bp in bpcol)
                {
                    s = new SiarLibrary.BandoStorico();
                    s.IdBando = bp.IdBando;
                    s.CodStato = "L";
                    s.Data = DateTime.Now;
                    s.Operatore = Operatore.Utente.IdUtente;
                    s.IdAtto = id_atto;
                    storico_provider.Save(s);

                    dispo = BandoProvider.GetById(bp.IdBando);
                    dispo.IdStoricoUltimo = s.Id;
                    dispo.DataApertura = Bando.DataApertura;//DateTime.Now;
                    BandoProvider.Save(dispo);

                    bi = integrazioni_provider.GetById(dispo.IdIntegrazioneUltima);
                    bi.DataScadenza = Bando.DataScadenza;
                    integrazioni_provider.Save(bi);

                }
                BandoProvider.DbProviderObj.Commit();
                Bando = BandoProvider.GetById(Bando.IdBando);
                //ShowMessage("Bando pubblicato correttamente.");
                var codAttivazione = BandoProvider.GetCodAttivazioneBando(Bando.IdBando);
                string igrue_result = "";
                if ((Bando.IdBando != null) && CheckAbilitaCodAttivazione(Bando.IdBando, codAttivazione))
                {
                    try
                    {
                        var puc = new PucManager.PucOperazioni();
                        int idbando = Bando.IdBando;
                        var result = puc.GetCodProceduraAttivazione(idbando);
                        puc.InsertCodProceduraAttivazione(idbando, result.IdProceduraAttivazione, result.DataAssegnazione);
                        igrue_result = " Codice Procedura Attivazione IGRUE: " + result.IdProceduraAttivazione;
                    }
                    catch (Exception ex)
                    {
                        igrue_result = " Richiesta Codice Procedura Attivazione IGRUE non riuscita: " + ex.Message;
                    }
                }
                if (Organismi_intermedi)
                {
                    RegisterClientScriptBlock("chiudiPopupTemplate();");
                    txtNumeroDecreto.Text = "";
                    txtDataDecreto.Text = "";
                    txtDescrizioneDecreto.Text = "";
                    txtLinkEst.Text = "";
                }

                if (Bando.InviaMessaggioTelegram)
                {
                    string messaggio = "<b>PUBBLICATO NUOVO BANDO</b> \n\n"
                    + "<i>Data apertura:</i> " + Bando.DataApertura + " " + txtAperturaOra.Text + "\n"
                    + "<i>Data scadenza:</i> " + Bando.DataScadenza + " " + txtScadenzaOra.Text + "\n"
                    + "<i>Importo totale:</i> " + Bando.Importo + " € \n\n"
                    + Bando.Descrizione + "\n\n"
                    + "Per ulteriori informazioni e per presentare una domanda: <a> https://sigef.regione.marche.it/web/Public/Bandi.aspx </a>";

                    var esitoTelegram = await new TelegramBotClass().SendMessageAsync(Operatore.Utente.CfUtente, null, messaggio);

                    if (esitoTelegram == "")
                        Redirect(PATH_PSR_BANDI + "dettaglio.aspx?idb=" + Bando.IdBando,
                            "Bando pubblicato correttamente e notifica Telegram inviata. " + igrue_result,
                            false);
                    else
                        Redirect(PATH_PSR_BANDI + "dettaglio.aspx?idb=" + Bando.IdBando,
                                "Bando pubblicato correttamente, ma la notifica Telegram NON è stata inviata. Errore: " + esitoTelegram + " " + igrue_result,
                                false);
                }
                else
                    Redirect(PATH_PSR_BANDI + "dettaglio.aspx?idb=" + Bando.IdBando,
                        "Bando pubblicato correttamente. " + igrue_result,
                        false);

            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort(); //evita solo il blocco del codice nel caso non si dovesse inviare il messaggio Telegram
            }
            catch (Exception ex)
            {
                BandoProvider.DbProviderObj.Rollback();
                ShowError(ex);
                if (Organismi_intermedi)
                    btnPubblica_Click(sender, e);
            }
        }

        protected void btnSalvaResponsabili_Click(object sender, EventArgs e)
        {
            try
            {
                responsabili_provider.DbProviderObj.BeginTran();
                SiarLibrary.BandoResponsabiliCollection responsabili = responsabili_provider.Find(Bando.IdBando, null, null, null, true);
                int id_resp;
                if (!int.TryParse(hdnIdResponsabileBando.Value, out id_resp))
                    throw new Exception("E' obbligatorio specificare il responsabile del bando.");
                SiarLibrary.BandoResponsabili resp = null;
                foreach (SiarLibrary.BandoResponsabili r in responsabili)
                    if (r.Provincia == null) { resp = r; break; }
                if (resp.IdUtente.Value != id_resp)
                {
                    resp.Attivo = false;
                    responsabili_provider.Save(resp);
                    NuovoResponsabile(id_resp, null);
                }
                //int.TryParse(hdnIdResponsabileAN.Value, out id_resp);
                SalvaResponsabileProvinciale(id_resp, "AN", responsabili.SubSelect(null, null, null, "AN", null, null, null));
                //int.TryParse(hdnIdResponsabileAP.Value, out id_resp);
                //SalvaResponsabileProvinciale(id_resp, "AP", responsabili.SubSelect(null, null, null, "AP", null, null, null));
                //int.TryParse(hdnIdResponsabileMC.Value, out id_resp);
                //SalvaResponsabileProvinciale(id_resp, "MC", responsabili.SubSelect(null, null, null, "MC", null, null, null));
                //int.TryParse(hdnIdResponsabilePU.Value, out id_resp);
                //SalvaResponsabileProvinciale(id_resp, "PU", responsabili.SubSelect(null, null, null, "PU", null, null, null));
                //int.TryParse(hdnIdResponsabileFM.Value, out id_resp);
                //SalvaResponsabileProvinciale(id_resp, "FM", responsabili.SubSelect(null, null, null, "FM", null, null, null));
                responsabili_provider.DbProviderObj.Commit();
                ShowMessage("Organigramma salvato correttamente.");
            }
            catch (Exception ex) { responsabili_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            int id_valutatore;
            if (!int.TryParse(hdnIdValutatorePost.Value, out id_valutatore)) ShowError("Il valutatore selezionato non è valido. Impossibile continuare.");
            SiarLibrary.BandoValutatori valutatore = valutatori_provider.GetById(id_valutatore);
            if (valutatore != null)
            {
                txtValutatore.Text = valutatore.Nominativo;
                hdnIdValutatore.Value = valutatore.IdUtente;
                chkPresidente.Checked = valutatore.Presidente;
            }
        }

        protected void btnEliminaMembro_Click(object sender, EventArgs e)
        {
            DeleteMembro(int.Parse(hdnIdValutatorePost.Value));
        }

        private void DeleteMembro(int idValutatore)
        {
            try
            {
                valutatori_provider.DbProviderObj.BeginTran();
                SiarLibrary.BandoValutatoriCollection valutatori_bando = valutatori_provider.Find(null, Bando.IdBando, null, true, null);
                SiarLibrary.BandoValutatori v = valutatori_provider.GetById(idValutatore);
                v.Attivo = false;
                v.DataFine = DateTime.Now;
                valutatori_provider.Save(v);

                // devo aggiornare tutti i valutatori che hanno ordine maggiore
                foreach (SiarLibrary.BandoValutatori x in valutatori_bando)
                {
                    if (x.Ordine > v.Ordine)
                    {
                        x.Ordine = x.Ordine - 1;
                        valutatori_provider.Save(x);
                    }
                }

                valutatori_provider.DbProviderObj.Commit();
                ShowMessage("Valutatore eliminato correttamente.");
                NewMembro();
            }
            catch (Exception ex) { ShowError(ex); valutatori_provider.DbProviderObj.Rollback(); }
        }

        protected void btnNewMembro_Click(object sender, EventArgs e)
        {
            NewMembro();
        }

        private void NewMembro()
        {
            hdnIdValutatorePost.Value = string.Empty;
            txtValutatore.Text = string.Empty;
            hdnIdValutatore.Value = string.Empty;
            chkPresidente.Checked = false;
            SiarLibrary.BandoValutatoriCollection valutatori = valutatori_provider.Find(null, Bando.IdBando, null, true, null);
            dgValutatori.DataSource = valutatori;
            dgValutatori.DataBind();
        }


        protected void btnAggiungiMembro_Click(object sender, EventArgs e)
        {
            try
            {
                valutatori_provider.DbProviderObj.BeginTran();

                SiarLibrary.BandoValutatori v;

                bool isNew = true;
                if (string.IsNullOrEmpty(hdnIdValutatorePost.Value))
                    v = new SiarLibrary.BandoValutatori();
                else
                {
                    v = valutatori_provider.GetById(int.Parse(hdnIdValutatorePost.Value));
                    isNew = false;
                }
                v.IdBando = Bando.IdBando;
                v.IdUtente = hdnIdValutatore.Value;
                if (isNew)
                    v.Ordine = getLastOrdine();
                v.Presidente = chkPresidente.Checked;
                v.Attivo = true;
                v.DataInizio = DateTime.Now;
                valutatori_provider.Save(v);

                valutatori_provider.DbProviderObj.Commit();
                if (chkPresidente.Checked)
                    ShowMessage("Presidente aggiunto correttamente.");
                else
                    ShowMessage("Valutatore aggiunto correttamente.");

                NewMembro();

            }
            catch (Exception ex) { valutatori_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        public int getLastOrdine()
        {
            SiarLibrary.BandoValutatoriCollection valutatori = valutatori_provider.Find(null, Bando.IdBando, null, true, null);

            if (valutatori.Count == 0)
            {
                return 1;
            }
            int maxOrdine = int.MinValue;
            foreach (SiarLibrary.BandoValutatori v in valutatori)
            {
                if (v.Ordine > maxOrdine)
                {
                    maxOrdine = v.Ordine;
                }
            }
            return maxOrdine + 1;
        }

        //protected void btnSalvaValutatori_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string[] values = new string[5];
        //        values[0] = hdnIdValutatore1.Value;
        //        values[1] = hdnIdValutatore2.Value;
        //        values[2] = hdnIdValutatore3.Value;
        //        values[3] = hdnIdValutatore4.Value;
        //        values[4] = hdnIdValutatore5.Value;

        //        if (ContainsDuplicates(values))
        //            throw new Exception("Sono stati inseriti due valutatori uguali.");

        //        valutatori_provider.DbProviderObj.BeginTran();
        //        SiarLibrary.BandoValutatoriCollection valutatori = valutatori_provider.Find(null, Bando.IdBando, null, true, null);
        //        int id_val;
        //        int.TryParse(hdnIdValutatore1.Value, out id_val);
        //        SalvaValutatore(id_val, 1, valutatori.SubSelect(null, null, null, null, true, null, null, 1));
        //        int.TryParse(hdnIdValutatore2.Value, out id_val);
        //        SalvaValutatore(id_val, 2, valutatori.SubSelect(null, null, null, null, true, null, null, 2));
        //        int.TryParse(hdnIdValutatore3.Value, out id_val);
        //        SalvaValutatore(id_val, 3, valutatori.SubSelect(null, null, null, null, true, null, null, 3));
        //        int.TryParse(hdnIdValutatore4.Value, out id_val);
        //        SalvaValutatore(id_val, 4, valutatori.SubSelect(null, null, null, null, true, null, null, 4));
        //        int.TryParse(hdnIdValutatore5.Value, out id_val);
        //        SalvaValutatore(id_val, 5, valutatori.SubSelect(null, null, null, null, true, null, null, 5));
        //        valutatori_provider.DbProviderObj.Commit();
        //        ShowMessage("Valutatori salvati correttamente.");
        //    }
        //    catch (Exception ex) { valutatori_provider.DbProviderObj.Rollback(); ShowError(ex); }
        //}

        //public static bool ContainsDuplicates(string[] a)
        //{
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        for (int j = i + 1; j < a.Length; j++)
        //        {
        //            if (a[i] == a[j] && !string.IsNullOrEmpty(a[i]) && !string.IsNullOrEmpty(a[j])) return true;
        //        }
        //    }
        //    return false;
        //}

        private void SalvaResponsabileProvinciale(int id_resp, string pv, SiarLibrary.BandoResponsabiliCollection cc)
        {
            SiarLibrary.BandoResponsabili old_resp = null;
            if (cc.Count > 0) old_resp = cc[0];
            if (id_resp <= 0)
            {
                if (old_resp != null)
                {
                    old_resp.Attivo = false;
                    responsabili_provider.Save(old_resp);
                }
            }
            else
            {
                if (old_resp == null) NuovoResponsabile(id_resp, pv);
                else if (old_resp.IdUtente.Value != id_resp)
                {
                    old_resp.Attivo = false;
                    responsabili_provider.Save(old_resp);
                    NuovoResponsabile(id_resp, pv);
                }
            }
        }

        //private void SalvaValutatore(int id_val, int ordine, SiarLibrary.BandoValutatoriCollection bvc)
        //{
        //    SiarLibrary.BandoValutatori old_val = null;
        //    if (bvc.Count > 0) old_val = bvc[0];
        //    if (id_val <= 0)
        //    {
        //        if (old_val != null)
        //        {
        //            old_val.Attivo = false;
        //            old_val.DataFine = DateTime.Now;
        //            valutatori_provider.Save(old_val);
        //        }
        //    }
        //    else
        //    {
        //        if (old_val == null)
        //            NuovoValutatore(id_val, ordine);
        //        else if (old_val.IdUtente.Value != id_val)
        //        {
        //            old_val.Attivo = false;
        //            old_val.DataFine = DateTime.Now;
        //            valutatori_provider.Save(old_val);
        //            NuovoValutatore(id_val, ordine);
        //        }
        //    }

        //}

        //private void NuovoValutatore(int id_val, int ordine)
        //{
        //    SiarLibrary.BandoValutatori v = new SiarLibrary.BandoValutatori();
        //    v.IdBando = Bando.IdBando;
        //    v.IdUtente = id_val;
        //    v.Ordine = ordine;
        //    if (ordine == 1)
        //        v.Presidente = true;
        //    else
        //        v.Presidente = false;
        //    v.Attivo = true;
        //    v.DataInizio = DateTime.Now;
        //    valutatori_provider.Save(v);
        //}

        private void NuovoResponsabile(int id_resp, string pv)
        {
            SiarLibrary.BandoResponsabili rn = new SiarLibrary.BandoResponsabili();
            rn.IdBando = Bando.IdBando;
            rn.IdUtente = id_resp;
            rn.Provincia = pv;
            rn.Attivo = true;
            rn.Data = DateTime.Now;
            rn.Operatore = Operatore.Utente.IdUtente;
            responsabili_provider.Save(rn);
        }

        //protected void btnPRGPRELSalva_Click(object sender, EventArgs e)
        //{
        //    const int cCheck = 5;
        //    try
        //    {
        //        if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P")
        //        {
        //            throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
        //        }
        //        string[] interventi_selezionati = ((SiarLibrary.Web.CheckColumn)dgPRGPREVInterventi.Columns[cCheck]).GetSelected();
        //        if (interventi_selezionati.Length == 0)
        //        {
        //            throw new Exception("E' obbligatorio selezionare almeno una tipologia di intervento.");
        //        }

        //        BandoProvider.DbProviderObj.BeginTran();
        //        programmazione_provider.DeleteCollection(programmazione_provider.Find(Bando.IdBando, null, true, null));

        //        foreach (string s in interventi_selezionati)
        //        {
        //            SiarLibrary.BandoProgrammazione p = new SiarLibrary.BandoProgrammazione();
        //            p.IdBando = Bando.IdBando;
        //            p.IdProgrammazione = s;
        //            p.MisuraPrevalente = true;
        //            programmazione_provider.Save(p);
        //        }
        //        AggiornaLogModifica(null);
        //        BandoProvider.DbProviderObj.Commit();
        //        ShowMessage("Programmazione principale salvata correttamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        BandoProvider.DbProviderObj.Rollback(); ShowError(ex);
        //    }
        //}

        protected void btnPRGDISPATTAssocia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_disp_attuativa; SiarLibrary.Bando disp_attuativa = null;
                if (int.TryParse(hdnIdDisposizioneAttuativa.Value, out id_disp_attuativa)) disp_attuativa = BandoProvider.GetById(id_disp_attuativa);
                if (disp_attuativa == null || !disp_attuativa.DisposizioniAttuative || disp_attuativa.IdBando == Bando.IdBando)
                    throw new Exception("La disposizione attuativa selezionata non è valida.");
                if (disp_attuativa.IdProgrammazione == Bando.IdProgrammazione)
                    throw new Exception("La disposizione attuativa selezionata fa riferimento agli stessi elementi di programmazione del presente bando.");
                if (programmazione_provider.Find(Bando.IdBando, null, false, disp_attuativa.IdBando).Count > 0)
                    throw new Exception("La disposizione attuativa selezionata è già associata al presente bando.");
                SiarLibrary.BandoProgrammazioneCollection interventi_da = programmazione_provider.Find(id_disp_attuativa, null, true, null);
                if (interventi_da.Count == 0) throw new Exception("La disposizione attuativa selezionata non ha associato nessun intervento, impossibile continuare.");

                BandoProvider.DbProviderObj.BeginTran();
                foreach (SiarLibrary.BandoProgrammazione i in interventi_da)
                {
                    SiarLibrary.BandoProgrammazione bp = new SiarLibrary.BandoProgrammazione();
                    bp.IdBando = Bando.IdBando;
                    bp.IdProgrammazione = i.IdProgrammazione;
                    bp.MisuraPrevalente = false;
                    bp.IdDisposizioniAttuative = disp_attuativa.IdBando;
                    programmazione_provider.Save(bp);
                }
                Bando.Multimisura = true;
                BandoProvider.Save(Bando);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Disposizione attuativa associata correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnPRGDISPATTElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                int id_disp_attuativa; SiarLibrary.Bando disp_attuativa = null;
                if (int.TryParse(hdnIdDisposizioneAttuativa.Value, out id_disp_attuativa)) disp_attuativa = BandoProvider.GetById(id_disp_attuativa);
                if (disp_attuativa == null || !disp_attuativa.DisposizioniAttuative || disp_attuativa.IdBando == Bando.IdBando)
                    throw new Exception("La disposizione attuativa selezionata non è valida.");
                if (disp_attuativa.IdProgrammazione == Bando.IdProgrammazione)
                    throw new Exception("La disposizione attuativa selezionata fa riferimento agli stessi elementi di programmazione del presente bando.");
                SiarLibrary.BandoProgrammazioneCollection interventi_da = programmazione_provider.Find(Bando.IdBando, null, false, disp_attuativa.IdBando);
                if (interventi_da.Count == 0) throw new Exception("La disposizione attuativa selezionata non è valida.");

                BandoProvider.DbProviderObj.BeginTran();
                programmazione_provider.DeleteCollection(interventi_da);
                Bando.Multimisura = programmazione_provider.Find(Bando.IdBando, null, false, null).Count > 0;
                BandoProvider.Save(Bando);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Disposizione attuativa eliminata correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnFINTipoInvSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFINTipoInvestimenti.Columns[5]).GetSelected();
                SiarBLL.BandoTipoInvestimentiCollectionProvider tipo_investimenti_provider = new SiarBLL.BandoTipoInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                tipo_investimenti_provider.DeleteCollection(tipo_investimenti_provider.Find(Bando.IdBando, null, null));
                foreach (string s in selezionati)
                {
                    SiarLibrary.BandoTipoInvestimenti t = new SiarLibrary.BandoTipoInvestimenti();
                    t.IdBando = Bando.IdBando;
                    t.CodTipoInvestimento = s;
                    t.ImportoMax = new SiarLibrary.NullTypes.DecimalNT(Request.Form["ImportoMax" + s + "_text"]);
                    t.ImportoMin = new SiarLibrary.NullTypes.DecimalNT(Request.Form["ImportoMin" + s + "_text"]);
                    if (t.ImportoMax != null && t.ImportoMin != null && t.ImportoMax > 0 && t.ImportoMax < t.ImportoMin)
                        throw new Exception("L`importo massimo non può essere minore del minimo.");
                    t.Note = Request.Form["Note" + s + "_text"];
                    t.QuotaMax = new SiarLibrary.NullTypes.DecimalNT(Request.Form["QuotaMax" + s + "_text"]);
                    t.Premio = false;
                    tipo_investimenti_provider.Save(t);
                }
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Dettagli finanziari salvati correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnFINMassimaliSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFINMassimali.Columns[4]).GetSelected();
                SiarBLL.BandoMassimaliCollectionProvider massimali_provider = new SiarBLL.BandoMassimaliCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                massimali_provider.DeleteCollection(massimali_provider.Find(Bando.IdBando, null));
                foreach (string s in selezionati)
                {
                    decimal importo, quota;
                    decimal.TryParse(Request.Form["dgtxtImportoMax" + s + "_text"], out importo);
                    decimal.TryParse(Request.Form["dgtxtQuotaMax" + s + "_text"], out quota);
                    if (importo < 0 || quota < 0) throw new Exception("Non è possibile specificare importi negativi per i massimali.");
                    if (importo + quota <= 0) throw new Exception("Per ogni massimale è obbligatorio specificare almeno una voce tra importo e quota.");
                    SiarLibrary.BandoMassimali m = new SiarLibrary.BandoMassimali();
                    m.IdBando = Bando.IdBando;
                    m.IdProgrammazione = s;
                    m.Importo = new SiarLibrary.NullTypes.DecimalNT(Request.Form["dgtxtImportoMax" + s + "_text"]);
                    m.Quota = new SiarLibrary.NullTypes.DecimalNT(Request.Form["dgtxtQuotaMax" + s + "_text"]);
                    massimali_provider.Save(m);
                }
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Massimali di aiuto salvati correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnBPSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgBPQuadri.Columns[3]).GetSelected();
                if (selezionati.Length == 0) throw new Exception("Selezionare almeno un quadro da associare.");

                SiarBLL.BusinessPlanCollectionProvider bp_provider = new SiarBLL.BusinessPlanCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                bp_provider.DeleteCollection(bp_provider.Find(Bando.IdBando));
                int counter = 1;
                foreach (string s in selezionati)
                {
                    SiarLibrary.BusinessPlan b = new SiarLibrary.BusinessPlan();
                    b.IdBando = Bando.IdBando;
                    b.IdQuadro = s;
                    b.Ordine = counter++;
                    bp_provider.Save(b);
                }
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Quadri di Business Plan salvati correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRELParagrafoSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarBLL.BandoRelazioneTecnicaCollectionProvider relazione_provider = new SiarBLL.BandoRelazioneTecnicaCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoRelazioneTecnica r = null;
                int id_paragrafo;
                if (int.TryParse(hdnIdParagrafo.Value, out id_paragrafo)) r = relazione_provider.GetById(id_paragrafo);
                if (r == null)
                {
                    r = new SiarLibrary.BandoRelazioneTecnica();
                    r.IdBando = Bando.IdBando;
                }
                r.Descrizione = txtRELDescrizione.Text;
                r.Titolo = txtRELTitolo.Text;
                r.Ordine = txtRELOrdine.Text;
                relazione_provider.Save(r);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Paragrafo descrittivo salvato correttamente.");
                hdnIdParagrafo.Value = r.IdParagrafo;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnRELParagrafoElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica || TipoModifica != 2 || Bando.CodStato != "P") throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                SiarBLL.BandoRelazioneTecnicaCollectionProvider relazione_provider = new SiarBLL.BandoRelazioneTecnicaCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.BandoRelazioneTecnica r = null;
                int id_paragrafo;
                if (int.TryParse(hdnIdParagrafo.Value, out id_paragrafo)) r = relazione_provider.GetById(id_paragrafo);
                if (r == null) throw new Exception("Per proseguire è necessario selezionare un paragrafo.");
                relazione_provider.Delete(r);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Paragrafo descrittivo eliminato correttamente.");
                hdnIdParagrafo.Value = null;
                btnRELParagrafoElimina.Enabled = false;
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(Operatore.Utente.CodEnte == "%" && Operatore.Utente.Profilo == "Amministratore"))
                    throw new Exception("Questa funzionalità è abilitata sono agli amministratori di sistema, impossibile continuare.");
                bconfig_provider = new SiarBLL.BandoConfigCollectionProvider();
                bconfig_provider.DbProviderObj.BeginTran();
                // disattivo i valori precedentemente salvati                
                foreach (SiarLibrary.BandoConfig c in bconfig_provider.Find(Bando.IdBando, null, null, true, null))
                {
                    c.Attivo = false;
                    c.DataFine = DateTime.Now;
                    c.OperatoreFine = Operatore.Utente.IdUtente;
                    bconfig_provider.Save(c);
                }
                // salvo i nuovi valori
                foreach (SiarLibrary.BandoConfig c in bconfig_provider.GetBandoConfig(Bando.IdBando))
                {
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.Contains("dgBandoConfigValore" + c.CodTipo))
                        {
                            string valore = Request.Form[s];

                            if (c.Formato == "plurivalore" && !s.Contains("hdnValoreSelezionato"))
                                continue;

                            if (c.Formato == "multivalore" && !s.Contains("hdnValoreSelezionato"))
                                continue;

                            if (!string.IsNullOrEmpty(valore))
                            {
                                switch (c.Formato)
                                {
                                    case "bool":
                                        if (valore == "on")
                                            c.Valore = true.ToString();
                                        break;
                                    case "date":
                                        DateTime d = new DateTime();
                                        if (!DateTime.TryParse(valore, out d))
                                            throw new Exception("Formato della data per il codice " + c.CodTipo + " non valido.");
                                        c.Valore = valore;
                                        break;
                                    case "number":
                                    case "plurivalore":
                                    case "multivalore":
                                        if (c.CodTipo.Equals("NATURACUP")
                                            && (valore == null || valore.Length <= 1))
                                            throw new Exception("Selezionare almeno una Natura CUP per il bando.");
                                        c.Valore = valore;
                                        break;
                                    case "text":
                                        c.Valore = valore;
                                        break;
                                }

                                c.MarkAsNew();
                                c.IdBando = Bando.IdBando;
                                c.Attivo = true;
                                c.DataInizio = DateTime.Now;
                                c.OperatoreInizio = Operatore.Utente.IdUtente;
                                bconfig_provider.Save(c);
                            }
                            else
                            {
                                switch (c.Formato)
                                {
                                    case "multivalore":
                                        if (c.CodTipo.Equals("NATURACUP")
                                            && (valore == null || valore.Length <= 1))
                                            throw new Exception("Selezionare almeno una Natura CUP per il bando.");
                                        break;
                                    default:
                                        continue;
                                }
                            }
                        }
                    }
                }
                bconfig_provider.DbProviderObj.Commit();
                ShowMessage("Configurazioni avanzate del bando salvate correttamente.");
            }
            catch (Exception ex) { bconfig_provider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnCodAttivazione_Click(object Sender, EventArgs e)
        {
            string igrue_result = "";
            if ((Bando.IdBando != null) && (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] == "Produzione"))
            {
                try
                {
                    var puc = new PucManager.PucOperazioni();
                    int idbando = Bando.IdBando;
                    var result = puc.GetCodProceduraAttivazione(idbando);
                    puc.InsertCodProceduraAttivazione(idbando, result.IdProceduraAttivazione, result.DataAssegnazione);
                    igrue_result = " Codice Procedura Attivazione IGRUE: " + result.IdProceduraAttivazione;
                }
                catch (Exception ex)
                {
                    igrue_result = " Richiesta Codice Procedura Attivazione IGRUE non riuscita: " + ex.Message;
                }
            }
            ShowMessage(igrue_result);
        }

        protected bool CheckAbilitaCodAttivazione(int idBando, string codAttivazione)
        {
            bool result = false;
            //if (BandoProvider.IsFesr(Bando.IdBando) && (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] == "Produzione") && (Bando.CodStato != "P") && string.IsNullOrEmpty(codAttivazione)) 
            //{
            //    result = true;
            //}
            if ((BandoProvider.IsFesr(Bando.IdBando) || BandoProvider.HasCodiceAttivazione(Bando.IdBando, "ITIAILS20142020") || BandoProvider.HasCodiceAttivazione(Bando.IdBando, "PSCMARCHE") || BandoProvider.HasCodiceAttivazione(Bando.IdBando, "POC20142020")) && (System.Configuration.ConfigurationManager.AppSettings["APP:TipoInstallazione"] == "Produzione") && (Bando.CodStato != "P") && string.IsNullOrEmpty(codAttivazione))
            {
                result = true;
            }
            return result;
        }
    }
}
