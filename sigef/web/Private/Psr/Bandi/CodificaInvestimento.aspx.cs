using System;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
namespace web.Private.Psr.Bandi
{
    /// <summary>
    /// Summary description for CodificaInvestimento. 
    /// </summary>
    public partial class CodificaInvestimento : SiarLibrary.Web.BandoPage
    {
        SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider;
        SiarLibrary.CodificaInvestimentoCollection codifica_investimenti;
        SiarBLL.DettaglioInvestimentiCollectionProvider dettaglio_provider;
        SiarBLL.SpecificaInvestimentiCollectionProvider specifica_provider;
        SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider;
        SiarLibrary.RnaComponentiXCodificaCollection rnaComponentiXCodificaCollection;
        SiarBLL.BandoComunicazioniCollectionProvider bconfig;
        bool AltreFonti;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "riepilogo_bando";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(BandoProvider.DbProviderObj);
            AbilitaModifica = AbilitaModifica && TipoModifica == 2;
        }
        private void disabilitaTabs()
        {
            tbCodifica.Visible = false;
            tbDettaglio.Visible = false;
            tbSpecifica.Visible = false;
            tbQuery.Visible = false;
            tbAltreFonti.Visible = false;
            tbCodificaRNA.Visible = false;
            tbRegolamentiRNA.Visible = false;
            tbStrumentiRNA.Visible = false;
            tbBandoRNA.Visible = false;
        }
        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    disabilitaTabs();
                    tbDettaglio.Visible = true;
                    lstUdmDettaglio.DataBind();
                    int id_dettaglio;
                    btnEliminaDettaglio.Enabled = AbilitaModifica && int.TryParse(hdnIdDettaglioInvestimento.Value, out id_dettaglio);
                    lstCodificaInvestimenti.IdBando = Bando.IdBando;
                    lstCodificaInvestimenti.DataBind();
                    lstCodificaInvestimenti.Attributes.Add("onchange", "pulisciCampiDettaglio();");
                    if (dettaglio_provider == null) dettaglio_provider = new SiarBLL.DettaglioInvestimentiCollectionProvider();
                    SiarLibrary.DettaglioInvestimentiCollection dettaglio_investimenti = dettaglio_provider.FindByIdBando(Bando.IdBando,
                        lstCodificaInvestimenti.SelectedValue);
                    dgDettaglio.DataSource = dettaglio_investimenti;
                    dgDettaglio.ItemDataBound += new DataGridItemEventHandler(dgDettaglio_ItemDataBound);
                    dgDettaglio.SetTitoloNrElementi();
                    dgDettaglio.DataBind();
                    break;
                case 3:
                    disabilitaTabs();
                    tbSpecifica.Visible = true;
                    lstGroupSpecificaInvestimenti.IdBando = Bando.IdBando;
                    lstGroupSpecificaInvestimenti.DataBind();
                    lstGroupSpecificaInvestimenti.Attributes.Add("onchange", "pulisciCampiSpecifica();");
                    int id_specifica;
                    btnEliminaSpecifica.Enabled = AbilitaModifica && int.TryParse(hdnIdSpecificaInvestimento.Value, out id_specifica);

                    if (specifica_provider == null) specifica_provider = new SiarBLL.SpecificaInvestimentiCollectionProvider();
                    SiarLibrary.SpecificaInvestimentiCollection specifica_investimenti = specifica_provider.FindByIdBando(Bando.IdBando,
                        lstGroupSpecificaInvestimenti.SelectedValue);
                    dgSpecifica.DataSource = specifica_investimenti;
                    dgSpecifica.SetTitoloNrElementi();
                    dgSpecifica.DataBind();
                    break;
                case 4:
                    disabilitaTabs();
                    tbQuery.Visible = true;
                    ComboCodificaInvestimenti.IdBando = Bando.IdBando;
                    ComboCodificaInvestimenti.DataBind();
                    ComboCodificaInvestimenti.Attributes.Add("onchange", "pulisciCampiDettaglioQuery();");
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.CodificaInvestimento codifica_investimento;
                    if (ComboCodificaInvestimenti.SelectedValue != null)
                    {
                        codifica_investimento = codifica_provider.GetById(ComboCodificaInvestimenti.SelectedValue);
                        txtQuerySQL.Text = codifica_investimento.QuerySql;
                        hdnIdCodificaInvestimentoXQuery.Value = ComboCodificaInvestimenti.SelectedValue.ToString();
                    }
                    else
                        hdnIdCodificaInvestimentoXQuery.Value = null;
                    BandoProvider.DbProviderObj.Commit();
                    break;
                case 5:
                    disabilitaTabs();
                    tbAltreFonti.Visible = true;
                    string UtStrumFin = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_UtStrumFin(Bando.IdBando);
                    if (UtStrumFin == "True") AltreFonti = true;
                    else
                        AltreFonti = false;
                    ComboCodificaInvestimentiAltreFonti.IdBando = Bando.IdBando;
                    ComboCodificaInvestimentiAltreFonti.DataBind();
                    ComboCodificaInvestimentiAltreFonti.Attributes.Add("onchange", "pulisciCampiDettaglioAltreFonti();");
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.CodificaInvestimento codifica_investimento_altr;
                    if (ComboCodificaInvestimentiAltreFonti.SelectedValue != null)
                    {
                        codifica_investimento_altr = codifica_provider.GetById(ComboCodificaInvestimentiAltreFonti.SelectedValue);
                        txtQuerySQLAltreFonti.Text = codifica_investimento_altr.QuerySqlAltrefonti;
                        txtContributoAltreFonti.Text = codifica_investimento_altr.AiutoMinimoAltrefonti;
                        hdnIdCodificaInvestimentoAltreFonti.Value = ComboCodificaInvestimentiAltreFonti.SelectedValue.ToString();
                    }
                    else
                        hdnIdCodificaInvestimentoAltreFonti.Value = null;
                    BandoProvider.DbProviderObj.Commit();

                    if (AltreFonti && AbilitaModifica)
                    {
                        btnSalvaCodificaAltreFonti.Enabled = true;
                    }
                    else
                    {
                        ShowMessage("Il bando non è predisposto per l'utilizzo di altre fonti finanziari oppure la modifica dei dati è disabilitata");
                        btnSalvaCodificaAltreFonti.Enabled = false;
                    }
                    break;
                case 6:
                    disabilitaTabs();
                    tbBandoRNA.Visible = true;
                    PopolaComboBandoConfigRna();
                    SiarBLL.RnaBandoConfigCollectionProvider rnaBandoConfigCollectionProvider = new SiarBLL.RnaBandoConfigCollectionProvider();
                    SiarLibrary.RnaBandoConfigCollection rnaBandoConfigCollection = rnaBandoConfigCollectionProvider.Select(null, Bando.IdBando, null, null, null,null, null);
                    if(rnaBandoConfigCollection.Count!=0)
                    {
                        datiBandoRNA.Style.Remove("display");
                        if (!string.IsNullOrEmpty(rnaBandoConfigCollection[0].CodBandoRna))
                        {
                            lblCodBandoRNA.Text = rnaBandoConfigCollection[0].CodBandoRna.ToString();
                            txtCodiceBandoRNA.Text = rnaBandoConfigCollection[0].CodBandoRna.ToString();
                        }
                        if (!string.IsNullOrEmpty(rnaBandoConfigCollection[0].CodBandoRnaCollaudo))
                        {
                            lblCodiceBandoRnaCollaudo.Text = rnaBandoConfigCollection[0].CodBandoRnaCollaudo.ToString();
                            txtCodiceBandoRnaCollaudo.Text = rnaBandoConfigCollection[0].CodBandoRnaCollaudo.ToString();
                        }
                        if(rnaBandoConfigCollection[0].DataPrevistaConcessione!=null)
                        {
                            lblDataConcessione.Text = rnaBandoConfigCollection[0].DataPrevistaConcessione.ToString();
                            txtDataConcessione.Text = rnaBandoConfigCollection[0].DataPrevistaConcessione;
                        }
                        lblCumulabilita.Text = rnaBandoConfigCollection[0].Cumulabilita == "1" ? "Sì" : "No";
                        comboCumulabilita.SelectedIndex = rnaBandoConfigCollection[0].Cumulabilita == "1" ? 0 : 1;
                        
                        if (rnaBandoConfigCollection[0].IdRnaEnte != null)//TODO USA ID
                        {                         
                            lblDataConcessione.Text = rnaBandoConfigCollection[0].DataPrevistaConcessione;
                            txtDataConcessione.Text = rnaBandoConfigCollection[0].DataPrevistaConcessione;
                        }
                        if (rnaBandoConfigCollection[0].IdRnaEnte != null)
                        {
                            cmbEnteAccount.SelectedValue = rnaBandoConfigCollection[0].IdRnaEnte;
                            var enteRna = new SiarBLL.RnaEntiCollectionProvider().Select(rnaBandoConfigCollection[0].IdRnaEnte, null, null, null, null, null, null, null, null);
                            lblDescrizioneEnte.Text = enteRna[0].DescrizioneAccount;
                        }
                            salvaDatiBandoRna.Text = "Modifica";
                    }
                    break;
                case 7:
                    disabilitaTabs();
                    tbCodificaRNA.Visible = true;
                    lstCodificaInvestimentiCosti.IdBando = Bando.IdBando;
                    lstCodificaInvestimentiCosti.DataBind();
                    lstCostiRNA.DataBind();
                    SiarBLL.VrnaCostiXCodificaCollectionProvider vrnaCostiXCodificaCollectionProvider = new SiarBLL.VrnaCostiXCodificaCollectionProvider();
                    SiarLibrary.VrnaCostiXCodificaCollection vrnaCostiXCodificaCollection = vrnaCostiXCodificaCollectionProvider.Select(null, null, null, Bando.IdBando, null, null);
                    dgCostixCodifica.DataSource = vrnaCostiXCodificaCollection;
                    dgCostixCodifica.DataBind();
                    break;
                case 8:
                    disabilitaTabs();
                    tbRegolamentiRNA.Visible = true;
                    lstCodificaInvestimentiRegolamenti.IdBando = Bando.IdBando;
                    lstCodificaInvestimentiRegolamenti.DataBind();
                    if (lstCodificaInvestimentiRegolamenti.SelectedIndex != -1)
                    {
                        SiarBLL.RnaComponentiXCodificaCollectionProvider rnaComponentiXCodificaCollectionProvider = new SiarBLL.RnaComponentiXCodificaCollectionProvider();
                        SiarBLL.RnaProcedimentiERegolamentiCollectionProvider rnaProcedimentiERegolamentiCollectionProvider = new SiarBLL.RnaProcedimentiERegolamentiCollectionProvider();
                        SiarLibrary.RnaProcedimentiERegolamentiCollection rnaProcedimentiERegolamentiCollection = rnaProcedimentiERegolamentiCollectionProvider.Select(null, null, null, null, null, null, null);
                        string idInvestimentoRegolamenti = lstCodificaInvestimentiRegolamenti.SelectedValue;
                        rnaComponentiXCodificaCollection = rnaComponentiXCodificaCollectionProvider.Select(null, idInvestimentoRegolamenti, null, null);

                        dgRegolamentiRNA.DataSource = rnaProcedimentiERegolamentiCollection;
                        dgRegolamentiRNA.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRegolamenti_ItemDataBound);
                        dgRegolamentiRNA.DataBind();
                    }
                    break;
                case 9:
                    disabilitaTabs();
                    tbStrumentiRNA.Visible = true;
                    lstCodificaInvestimentiStrumenti.IdBando = Bando.IdBando;
                    lstCodificaInvestimentiStrumenti.DataBind();
                    lstCodificaInvestimentiStrumenti.Attributes.Add("onchange", "pulisciCampiStrumentiRNA();");
                    SiarBLL.VrnaComponentiXCodificaCollectionProvider vrnaComponentiXCodificaCollectionProvider = new SiarBLL.VrnaComponentiXCodificaCollectionProvider();
                    SiarLibrary.VrnaComponentiXCodificaCollection vrnaComponentiXCodificaCollection = new SiarLibrary.VrnaComponentiXCodificaCollection();
                    string idInvestimento = lstCodificaInvestimentiStrumenti.SelectedValue;
                    if (!string.IsNullOrEmpty(idInvestimento))
                        vrnaComponentiXCodificaCollection = vrnaComponentiXCodificaCollectionProvider.Select(hdnIdComponenteSelezionata.Value, null, null, idInvestimento, null, null, null, null);
                    dgRegolamentiXStrumentiRNA.DataSource = vrnaComponentiXCodificaCollection;
                    dgRegolamentiXStrumentiRNA.DataBind();
                    lstStrumentiRNA.DataBind();
                    if (vrnaComponentiXCodificaCollection.Count == 0 || string.IsNullOrEmpty(hdnIdComponenteSelezionata.Value))
                    {
                        trHideStrumentiRNA1.Style.Add("display", "none");
                        trHideStrumentiRNA2.Style.Add("display", "none");
                        trHideStrumentiRNA3.Style.Add("display", "none");
                        trHideStrumentiRNA4.Style.Add("display", "none");
                        trHideStrumentiRNA5.Style.Add("display", "none");
                    }
                    else
                    {
                        trHideStrumentiRNA1.Style.Remove("display");
                        trHideStrumentiRNA2.Style.Remove("display");
                        trHideStrumentiRNA3.Style.Remove("display");
                        trHideStrumentiRNA4.Style.Remove("display");
                        trHideStrumentiRNA5.Style.Remove("display");
                        SiarBLL.VrnaStrumentiXComponentiCollectionProvider vrnaStrumentiXComponentiCollectionProvider = new SiarBLL.VrnaStrumentiXComponentiCollectionProvider();
                        SiarLibrary.VrnaStrumentiXComponentiCollection vrnaStrumentiXComponentiCollection = new SiarLibrary.VrnaStrumentiXComponentiCollection();
                        vrnaStrumentiXComponentiCollection = vrnaStrumentiXComponentiCollectionProvider.Select(idInvestimento, hdnIdComponenteSelezionata.Value, null, null, null, null, null, null, null, null, null, null);
                        dgStrumentiAssociati.DataSource = vrnaStrumentiXComponentiCollection;
                        dgStrumentiAssociati.DataBind();
                    }
                    break;
                default:
                    disabilitaTabs();
                    tbCodifica.Visible = true;
                    int id_codifica;
                    btnEliminaCodifica.Enabled = AbilitaModifica && int.TryParse(hdnIdCodificaInvestimento.Value, out id_codifica);

                    lstInterventiBando.IdBando = Bando.IdBando;
                    lstInterventiBando.DataBind();

                    ///// -- cambiare la COMBO TP (richiama il COD_OBIETTIVO) 
                    //SiarLibrary.ProgrammazioneBando programmazionebando = new SiarBLL.ProgrammazioneBandoCollectionProvider().Find(Bando.IdBando, null)
                    //    .FiltroMisuraPrevalente(true)[0];
                    SiarLibrary.BandoProgrammazione programmazionebando = programmazione_provider.GetProgrammazioneBando(Bando.IdBando, false)[0];
                    //lstTipologiaProgetto.IdPsr = programmazionebando.CodPsr;
                    //lstTipologiaProgetto.CodObiettivo = programmazionebando.;
                    //lstTipologiaProgetto.CodAsse = programmazionebando.CodAsse;
                    //lstTipologiaProgetto.CodMisura = programmazionebando.CodMisura;
                    //lstTipologiaProgetto.idProgrammazione = Bando.IdProgrammazione;
                    //lstTipologiaProgetto.DataBind();

                    if (codifica_provider == null) codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider();
                    codifica_investimenti = codifica_provider.Find(Bando.IdBando, null);
                    dgCodificaInvestimento.DataSource = codifica_investimenti;
                    dgCodificaInvestimento.ItemDataBound += new DataGridItemEventHandler(dgCodificaInvestimento_ItemDataBound);
                    dgCodificaInvestimento.SetTitoloNrElementi();
                    dgCodificaInvestimento.DataBind();
                    break;
            }
            base.OnPreRender(e);

        }

        #region codifica

        void dgCodificaInvestimento_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.CodificaInvestimento pr = (SiarLibrary.CodificaInvestimento)e.Item.DataItem;
                SiarLibrary.Zprogrammazione intervento = new SiarBLL.ZprogrammazioneCollectionProvider().GetById(pr.IdIntervento);
                e.Item.Cells[1].Text = intervento.Codice;
            }
        }
        protected void btnSalvaCodifica_Click(object sender, EventArgs e)
        {
            try
            {
                codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.CodificaInvestimento codifica_investimento;
                int id_codifica;
                if (int.TryParse(hdnIdCodificaInvestimento.Value, out id_codifica)) codifica_investimento = codifica_provider.GetById(id_codifica);
                else codifica_investimento = new SiarLibrary.CodificaInvestimento();
                codifica_investimento.IdBando = Bando.IdBando;
                codifica_investimento.IdIntervento = lstInterventiBando.SelectedValue;
                codifica_investimento.Descrizione = txtDescrizione.Text;
                codifica_investimento.Codice = txtCodice.Text;
                codifica_investimento.AiutoMinimo = txtValMinimo.Text;

                codifica_investimento.CodTp = null;
                //codifica_investimento.CodTp = lstTipologiaProgetto.SelectedValue;

                codifica_investimento.IsMax = chkIsMax.Checked;
                codifica_provider.Save(codifica_investimento);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                txtDescrizione.Text = "";
                txtCodice.Text = "";
                hdnIdCodificaInvestimento.Value = "";
                txtValMinimo.Text = "";
                lstInterventiBando.SelectedIndex = -1;
                //lstTipologiaProgetto.ClearSelection();
                ShowMessage("Codifica investimento salvata correttamente.");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaCodifica_Click(object sender, EventArgs e)
        {
            int id_codifica;
            if (!int.TryParse(hdnIdCodificaInvestimento.Value, out id_codifica)) ShowError("Nessuna codifica selezionata.");
            else
            {
                try
                {
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.CodificaInvestimento codifica_investimento = codifica_provider.GetById(id_codifica);
                    if (codifica_investimento == null) throw new Exception("Nessuna codifica selezionata.");
                    // controllo se ha dei dettagli associati
                    else if (new SiarBLL.DettaglioInvestimentiCollectionProvider(BandoProvider.DbProviderObj).Find(id_codifica, null).Count > 0)
                        throw new Exception("Impossibile eliminare la codifica. Eliminare prima i dettagli dell'investimento associati.");
                    codifica_provider.Delete(codifica_investimento);
                    AggiornaLogModifica(null);
                    BandoProvider.DbProviderObj.Commit();
                    txtDescrizione.Text = "";
                    txtCodice.Text = "";
                    hdnIdCodificaInvestimento.Value = "";
                    txtValMinimo.Text = "";
                    lstInterventiBando.SelectedIndex = -1;
                    //lstTipologiaProgetto.ClearSelection();
                    ShowMessage("Codifica investimento eliminata correttamente.");
                }
                catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            }
        }

        protected void btnCaricaCodifica_Click(object sender, EventArgs e)
        {
            int id_codifica;
            if (!int.TryParse(hdnIdCodificaInvestimento.Value, out id_codifica)) ShowError("Nessuna codifica selezionata.");
            else
            {
                try
                {
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider();
                    SiarLibrary.CodificaInvestimento codifica_investimento = codifica_provider.GetById(id_codifica);
                    if (codifica_investimento == null) ShowError("Nessuna codifica selezionata.");
                    else
                    {
                        txtDescrizione.Text = codifica_investimento.Descrizione;
                        txtCodice.Text = codifica_investimento.Codice;
                        txtValMinimo.Text = codifica_investimento.AiutoMinimo;
                        lstInterventiBando.SelectedValue = codifica_investimento.IdIntervento;
                        //if (!string.IsNullOrEmpty(codifica_investimento.CodTp)) lstTipologiaProgetto.SelectedValue = codifica_investimento.CodTp;
                        //else lstTipologiaProgetto.SelectedIndex = -1;
                        chkIsMax.Checked = codifica_investimento.IsMax;
                    }
                }
                catch (Exception ex) { ShowError(ex); }
            }
        }

        #endregion

        #region dettaglio

        void dgDettaglio_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.DettaglioInvestimenti c = (SiarLibrary.DettaglioInvestimenti)e.Item.DataItem;
                e.Item.Cells[3].Text = c.AdditionalAttributes["UNITA_DI_MISURA"];
            }
        }

        protected void btnSalvaDettaglio_Click(object sender, EventArgs e)
        {
            try
            {
                dettaglio_provider = new SiarBLL.DettaglioInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.DettaglioInvestimenti dettaglio_investimento = null;
                int id_dettaglio;
                if (int.TryParse(hdnIdDettaglioInvestimento.Value, out id_dettaglio)) dettaglio_investimento = dettaglio_provider.GetById(id_dettaglio);
                if (dettaglio_investimento == null)
                {
                    dettaglio_investimento = new SiarLibrary.DettaglioInvestimenti();
                    dettaglio_investimento.IdCodificaInvestimento = lstCodificaInvestimenti.SelectedValue;
                }
                dettaglio_investimento.CodDettaglio = txtCodDettaglio.Text;
                dettaglio_investimento.Descrizione = txtDescrizioneDettaglio.Text;
                //dettaglio_investimento.QuotaSpeseGenerali = txtPercSpeseGenerali.Text;
                dettaglio_investimento.QuotaSpeseGenerali = 0;
                dettaglio_investimento.IdUdm = lstUdmDettaglio.SelectedValue;
                dettaglio_investimento.Mobile = true;
                //dettaglio_investimento.Mobile = chkMobile.Checked;
                dettaglio_investimento.RichiediParticella = chkParticella.Checked;
                dettaglio_provider.Save(dettaglio_investimento);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Dettaglio di investimento salvato correttamente.");
                RegisterClientScriptBlock("pulisciCampiDettaglio();");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaDettaglio_Click(object sender, EventArgs e)
        {
            int id_dettaglio;
            if (!int.TryParse(hdnIdDettaglioInvestimento.Value, out id_dettaglio)) ShowError("Nessun dettaglio di investimento selezionato.");
            else
            {
                try
                {
                    dettaglio_provider = new SiarBLL.DettaglioInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.DettaglioInvestimenti dettaglio_investimento = dettaglio_provider.GetById(id_dettaglio);
                    if (dettaglio_investimento == null) throw new Exception("Nessun dettaglio di investimento selezionato.");
                    else if (new SiarBLL.SpecificaInvestimentiCollectionProvider(BandoProvider.DbProviderObj).Find(id_dettaglio, null).Count > 0)
                        throw new Exception("Impossibile eliminare il dettaglio selezionato. Eliminare prima le specifiche di investimento associate.");
                    dettaglio_provider.Delete(dettaglio_investimento);
                    AggiornaLogModifica(null);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Dettaglio di investimento eliminato corettamente.");
                    RegisterClientScriptBlock("pulisciCampiDettaglio();");
                }
                catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            }
        }

        protected void btnCaricaDettaglio_Click(object sender, EventArgs e)
        {
            int id_dettaglio;
            if (!int.TryParse(hdnIdDettaglioInvestimento.Value, out id_dettaglio)) ShowError("Nessun dettaglio di investimento selezionato.");
            else
            {
                try
                {
                    dettaglio_provider = new SiarBLL.DettaglioInvestimentiCollectionProvider();
                    SiarLibrary.DettaglioInvestimenti dettaglio_investimento = dettaglio_provider.GetById(id_dettaglio);
                    if (dettaglio_investimento == null) ShowError("Nessun dettaglio di investimento selezionato.");
                    else
                    {
                        lstCodificaInvestimenti.SelectedValue = dettaglio_investimento.IdCodificaInvestimento;
                        txtCodDettaglio.Text = dettaglio_investimento.CodDettaglio;
                        txtDescrizioneDettaglio.Text = dettaglio_investimento.Descrizione;
                        //txtPercSpeseGenerali.Text = dettaglio_investimento.QuotaSpeseGenerali;
                        chkMobile.Checked = dettaglio_investimento.Mobile;
                        chkParticella.Checked = dettaglio_investimento.RichiediParticella;
                        if (dettaglio_investimento.IdUdm == null) lstUdmDettaglio.ClearSelection();
                        else lstUdmDettaglio.SelectedValue = dettaglio_investimento.IdUdm;
                    }
                }
                catch (Exception ex) { ShowError(ex); }
            }
        }

        #endregion

        #region specifica

        protected void btnSalvaSpecifica_Click(object sender, EventArgs e)
        {
            try
            {
                specifica_provider = new SiarBLL.SpecificaInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                BandoProvider.DbProviderObj.BeginTran();
                SiarLibrary.SpecificaInvestimenti specifica_investimento;
                int id_specifica;
                if (int.TryParse(hdnIdSpecificaInvestimento.Value, out id_specifica)) specifica_investimento = specifica_provider.GetById(id_specifica);
                else
                {
                    specifica_investimento = new SiarLibrary.SpecificaInvestimenti();
                    specifica_investimento.IdDettaglioInvestimento = lstGroupSpecificaInvestimenti.SelectedValue;
                }
                specifica_investimento.CodSpecifica = txtCodiceSpecifica.Text;
                specifica_investimento.Descrizione = txtDescrizioneSpecifica.Text;
                specifica_provider.Save(specifica_investimento);
                AggiornaLogModifica(null);
                BandoProvider.DbProviderObj.Commit();
                ShowMessage("Specifica di investimento salvata correttamente.");
                RegisterClientScriptBlock("pulisciCampiSpecifica();");
            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaSpecifica_Click(object sender, EventArgs e)
        {
            int id_specifica;
            if (!int.TryParse(hdnIdSpecificaInvestimento.Value, out id_specifica)) ShowError("Nessuna specifica di investimento selezionata.");
            else
            {
                try
                {
                    specifica_provider = new SiarBLL.SpecificaInvestimentiCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.SpecificaInvestimenti specifica_investimento = specifica_provider.GetById(id_specifica);
                    if (specifica_investimento == null) throw new Exception("Nessuna specifica di investimento selezionata.");
                    specifica_provider.Delete(specifica_investimento);
                    AggiornaLogModifica(null);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Specifica di investimento eliminata corettamente.");
                    RegisterClientScriptBlock("pulisciCampiSpecifica();");
                }
                catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            }
        }

        protected void btnCaricaSpecifica_Click(object sender, EventArgs e)
        {
            int id_specifica;
            if (!int.TryParse(hdnIdSpecificaInvestimento.Value, out id_specifica)) ShowError("Nessuna specifica selezionata.");
            else
            {
                try
                {
                    specifica_provider = new SiarBLL.SpecificaInvestimentiCollectionProvider();
                    SiarLibrary.SpecificaInvestimenti specifica_investimento = specifica_provider.GetById(id_specifica);
                    if (specifica_investimento == null) ShowError("Nessuna specifica selezionata.");
                    else
                    {
                        txtDescrizioneSpecifica.Text = specifica_investimento.Descrizione;
                        txtCodiceSpecifica.Text = specifica_investimento.CodSpecifica;
                        lstGroupSpecificaInvestimenti.SelectedValue = specifica_investimento.IdDettaglioInvestimento;
                    }
                }
                catch (Exception ex) { ShowError(ex); }
            }
        }

        #endregion

        #region QueryCodifica

        protected void btnSalvaCodificaQuery_Click(object sender, EventArgs e)
        {
            try
            {
                int id_codifica;
                if (!int.TryParse(hdnIdCodificaInvestimentoXQuery.Value, out id_codifica)) ShowError("Nessuna codifica selezionata.");
                else
                {
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.CodificaInvestimento codifica_investimento;
                    codifica_investimento = new SiarLibrary.CodificaInvestimento();
                    codifica_investimento = codifica_provider.GetById(id_codifica);
                    if (txtQuerySQL.Text != "" && txtQuerySQL.Text != null)
                        codifica_investimento.QuerySql = txtQuerySQL.Text.Replace("`", "'");
                    else
                        codifica_investimento.QuerySql = null;
                    codifica_provider.Save(codifica_investimento);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Query SQL salvata correttamente.");
                }

            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        #endregion

        #region CodificaAltreFotni

        protected void btnSalvaCodificaAltreFonti_Click(object sender, EventArgs e)
        {
            try
            {
                int id_codifica;
                if (!int.TryParse(hdnIdCodificaInvestimentoAltreFonti.Value, out id_codifica)) ShowError("Nessuna codifica selezionata.");
                else
                {
                    codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(BandoProvider.DbProviderObj);
                    BandoProvider.DbProviderObj.BeginTran();
                    SiarLibrary.CodificaInvestimento codifica_investimento;
                    codifica_investimento = new SiarLibrary.CodificaInvestimento();
                    codifica_investimento = codifica_provider.GetById(id_codifica);
                    if (txtContributoAltreFonti.Text != "" && txtContributoAltreFonti.Text != null)
                        codifica_investimento.AiutoMinimoAltrefonti = txtContributoAltreFonti.Text;
                    else
                        codifica_investimento.AiutoMinimoAltrefonti = null;
                    if (txtQuerySQLAltreFonti.Text != "" && txtQuerySQLAltreFonti.Text != null)
                        codifica_investimento.QuerySqlAltrefonti = txtQuerySQLAltreFonti.Text;
                    else
                        codifica_investimento.QuerySqlAltrefonti = null;
                    codifica_provider.Save(codifica_investimento);
                    BandoProvider.DbProviderObj.Commit();
                    ShowMessage("Codifica Altre Fonti salvata correttamente.");
                }

            }
            catch (Exception ex) { BandoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        #endregion

        #region costiRNA
        protected void btnSalvaCosto_Click(object sender, EventArgs e)
        {
            SiarBLL.RnaCostiXCodificaCollectionProvider rnaCostiXCodificaCollectionProvider = new SiarBLL.RnaCostiXCodificaCollectionProvider();
            try
            {
                rnaCostiXCodificaCollectionProvider.DbProviderObj.BeginTran();
                var appoggio = rnaCostiXCodificaCollectionProvider.Select(null, lstCodificaInvestimentiCosti.SelectedValue, null);
                SiarLibrary.RnaCostiXCodifica rnaCostiXCodifica = rnaCostiXCodificaCollectionProvider.Select(null, lstCodificaInvestimentiCosti.SelectedValue, null).Count == 0 ? null : rnaCostiXCodificaCollectionProvider.Select(null, lstCodificaInvestimentiCosti.SelectedValue, null)[0];
                if (rnaCostiXCodifica == null)
                {
                    rnaCostiXCodifica = new SiarLibrary.RnaCostiXCodifica();
                    rnaCostiXCodifica.IdCodificaInvestimento = lstCodificaInvestimentiCosti.SelectedValue;
                    rnaCostiXCodifica.CodTipoSpesa = lstCostiRNA.SelectedValue;
                    rnaCostiXCodificaCollectionProvider.Save(rnaCostiXCodifica);
                }
                else
                {
                    rnaCostiXCodifica.IdCodificaInvestimento = lstCodificaInvestimentiCosti.SelectedValue;
                    rnaCostiXCodifica.CodTipoSpesa = lstCostiRNA.SelectedValue;
                    rnaCostiXCodificaCollectionProvider.Save(rnaCostiXCodifica);
                }
                rnaCostiXCodificaCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Costo salvato correttamente");
            }
            catch(Exception ex) { rnaCostiXCodificaCollectionProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnEliminaCosto_Click(object sender, EventArgs e) {
            try
            {
                SiarBLL.RnaCostiXCodificaCollectionProvider rnaCostiXCodificaCollectionProvider = new SiarBLL.RnaCostiXCodificaCollectionProvider();
                SiarLibrary.RnaCostiXCodifica rnaCostiXCodifica = rnaCostiXCodificaCollectionProvider.Select(null, lstCodificaInvestimentiCosti.SelectedValue, lstCostiRNA.SelectedValue)[0];
                if (rnaCostiXCodifica != null)
                    rnaCostiXCodificaCollectionProvider.Delete(rnaCostiXCodifica);
                ShowMessage("Costo eliminato correttamente");
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }
        #endregion

        #region RegolamentiRNA
        private void dgRegolamenti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            string idInvestimento = lstCodificaInvestimentiRegolamenti.SelectedValue;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string codRegolamento = dgi.Cells[1].Text;
                string idRegolamento = dgi.Cells[6].Text;
                SiarBLL.RnaObiettiviCollectionProvider rnaObiettiviCollectionProvider = new SiarBLL.RnaObiettiviCollectionProvider();
                SiarLibrary.RnaObiettiviCollection rnaObiettiviCollection = new SiarLibrary.RnaObiettiviCollection();
                rnaObiettiviCollection = rnaObiettiviCollectionProvider.Find(codRegolamento, null);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<select style=\"width: 300px\" name=\"idObiettivo_{0}\"><option value=\"\"><//option>", idRegolamento);
                SiarLibrary.RnaComponentiXCodificaCollection subRnaComponentiXCodificaCollection = rnaComponentiXCodificaCollection.SubSelect(null, null, idRegolamento, null);
                SiarLibrary.RnaComponentiXCodifica rnaComponentiXCodifica = subRnaComponentiXCodificaCollection.Count != 0 ? subRnaComponentiXCodificaCollection[0] : null;
                dgi.Cells[5].Text = dgi.Cells[5].Text.Replace("checked", "");
                foreach (SiarLibrary.RnaObiettivi elem in rnaObiettiviCollection)
                {
                    if (rnaComponentiXCodifica != null && elem.IdObiettivo == rnaComponentiXCodifica.IdRnaObiettivo)
                    {
                        sb.AppendFormat("<option selected = \"selected\" value=\"{0}\">{1}<//option>", elem.IdObiettivo, elem.Obiettivo);
                        dgi.Cells[5].Text=dgi.Cells[5].Text.Replace("<input", "<input checked");
                    }
                    else
                    {
                        sb.AppendFormat("<option value=\"{0}\">{1}<//option>", elem.IdObiettivo, elem.Obiettivo);
                    }
                }
                sb.Append("<//select>");
                dgi.Cells[4].Text = sb.ToString();
            }
        }

        protected void btnSalvaRegolamento_Click(object sender, EventArgs e)
        {
            SiarBLL.RnaComponentiXCodificaCollectionProvider rnaComponentiXCodificaCollectionProvider = new SiarBLL.RnaComponentiXCodificaCollectionProvider();
            try
            {
                string idInvestimento = lstCodificaInvestimentiRegolamenti.SelectedValue;
                if (!string.IsNullOrEmpty(idInvestimento))
                {
                    var idRegolamentiSel = ((SiarLibrary.Web.CheckColumn)dgRegolamentiRNA.Columns[5]).GetSelected();
                    rnaComponentiXCodificaCollection = rnaComponentiXCodificaCollectionProvider.Select(null, idInvestimento, null, null);
                    SiarLibrary.RnaComponentiXCodificaCollection componentiDaEliminare = new SiarLibrary.RnaComponentiXCodificaCollection();
                    foreach (SiarLibrary.RnaComponentiXCodifica componente in rnaComponentiXCodificaCollection)
                    {
                        bool daEliminare = true;
                        foreach (string idRegolamento in idRegolamentiSel)
                        {
                            if (idRegolamento == componente.IdRnaProcedimentiERegolamenti.ToString())
                                daEliminare = false;
                        }
                        if (daEliminare)
                            componentiDaEliminare.Add(componente);
                    }

                    rnaComponentiXCodificaCollectionProvider.DbProviderObj.BeginTran();
                    foreach(SiarLibrary.RnaComponentiXCodifica componente in componentiDaEliminare)
                    {
                        SiarBLL.RnaStrumentiXComponentiCollectionProvider rnaStrumentiXComponentiCollectionProvider = new SiarBLL.RnaStrumentiXComponentiCollectionProvider();
                        SiarLibrary.RnaStrumentiXComponentiCollection rnaStrumentiXComponentiCollection = rnaStrumentiXComponentiCollectionProvider.Select(null, componente.IdComponentiXCodifica, null, null);
                        rnaStrumentiXComponentiCollectionProvider.DeleteCollection(rnaStrumentiXComponentiCollection);
                    }

                    rnaComponentiXCodificaCollectionProvider.DeleteCollection(componentiDaEliminare);
                    
                    foreach (string chk in idRegolamentiSel)
                    {
                        var idObiettivo = Request.Form["idObiettivo_" + chk];
                        if (string.IsNullOrEmpty(idObiettivo))
                            throw new Exception("Selezionare un obiettivo per ogni voce selezionata");
                        rnaComponentiXCodificaCollection = rnaComponentiXCodificaCollectionProvider.Select(null, idInvestimento, chk, null);
                        if (rnaComponentiXCodificaCollection.Count == 0)
                        {
                            SiarLibrary.RnaComponentiXCodifica rnaComponentiXCodifica = new SiarLibrary.RnaComponentiXCodifica();
                            rnaComponentiXCodifica.IdCodificaInvestimento = idInvestimento;
                            rnaComponentiXCodifica.IdRnaObiettivo = idObiettivo;
                            rnaComponentiXCodifica.IdRnaProcedimentiERegolamenti = int.Parse(chk);
                            rnaComponentiXCodificaCollectionProvider.Save(rnaComponentiXCodifica);
                        }
                        else
                        {
                            SiarLibrary.RnaComponentiXCodifica rnaComponentiXCodifica = rnaComponentiXCodificaCollection[0];
                            rnaComponentiXCodifica.IdRnaObiettivo = idObiettivo;
                            rnaComponentiXCodificaCollectionProvider.Save(rnaComponentiXCodifica);
                        }
                    }
                    rnaComponentiXCodificaCollectionProvider.DbProviderObj.Commit();
                    ShowMessage("Componenti salvate correttamente");
                }
            }
            catch (Exception ex) { rnaComponentiXCodificaCollectionProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }
        protected void btnEliminaRegolamento_Click(object sender, EventArgs e)
        {
            try
            {
                SiarBLL.RnaComponentiXCodificaCollectionProvider rnaComponentiXCodificaCollectionProvider = new SiarBLL.RnaComponentiXCodificaCollectionProvider();
                SiarLibrary.RnaComponentiXCodificaCollection rnaComponentiXCodificaCollection = new SiarLibrary.RnaComponentiXCodificaCollection();
                string idInvestimento = lstCodificaInvestimentiRegolamenti.SelectedValue;
                if(!string.IsNullOrEmpty(idInvestimento))
                {
                    rnaComponentiXCodificaCollection = rnaComponentiXCodificaCollectionProvider.Select(null, idInvestimento, null, null);
                    foreach(SiarLibrary.RnaComponentiXCodifica elem in rnaComponentiXCodificaCollection)
                        rnaComponentiXCodificaCollectionProvider.Delete(elem);
                }
                else
                {
                    ShowError("Selezionare un investimento");
                }
            }
            catch(Exception ex)
            { ShowError(ex); }
        }
        #endregion
       
        #region StrumentiRNA
        
        protected void btnSalvaStrumento_Click(object sender, EventArgs e)
        {
            SiarBLL.RnaStrumentiXComponentiCollectionProvider rnaStrumentiXComponentiCollectionProvider = new SiarBLL.RnaStrumentiXComponentiCollectionProvider();
            SiarLibrary.RnaStrumentiXComponentiCollection rnaStrumentiXComponentiCollection = new SiarLibrary.RnaStrumentiXComponentiCollection();
            rnaStrumentiXComponentiCollection = rnaStrumentiXComponentiCollectionProvider.Select(null, hdnIdComponenteSelezionata.Value, lstStrumentiRNA.SelectedValue, null);
            if (rnaStrumentiXComponentiCollection.Count == 0)
            {
                SiarLibrary.RnaStrumentiXComponenti rnaStrumentiXComponenti = new SiarLibrary.RnaStrumentiXComponenti();
                rnaStrumentiXComponenti.CodTipoStrumentoAiuto = lstStrumentiRNA.SelectedValue;
                rnaStrumentiXComponenti.IntensitaStrumento = percStrumentiRNA.Text;
                rnaStrumentiXComponenti.IdComponentiXCodifica = hdnIdComponenteSelezionata.Value;
                rnaStrumentiXComponentiCollectionProvider.Save(rnaStrumentiXComponenti);
                ShowMessage("Strumento salvato correttamente");
            }
            else
            {
                rnaStrumentiXComponentiCollectionProvider.Delete(rnaStrumentiXComponentiCollection[0]);
                SiarLibrary.RnaStrumentiXComponenti rnaStrumentiXComponenti = new SiarLibrary.RnaStrumentiXComponenti();
                rnaStrumentiXComponenti.CodTipoStrumentoAiuto = lstStrumentiRNA.SelectedValue;
                rnaStrumentiXComponenti.IntensitaStrumento = percStrumentiRNA.Text;
                rnaStrumentiXComponenti.IdComponentiXCodifica = hdnIdComponenteSelezionata.Value;
                rnaStrumentiXComponentiCollectionProvider.Save(rnaStrumentiXComponenti);
                ShowMessage("Strumento modificato correttamente");
            }
        }

        protected void btnEliminaStrumento_Click(object sender, EventArgs e)
        {
            SiarBLL.RnaStrumentiXComponentiCollectionProvider rnaStrumentiXComponentiCollectionProvider = new SiarBLL.RnaStrumentiXComponentiCollectionProvider();
            SiarLibrary.RnaStrumentiXComponentiCollection rnaStrumentiXComponentiCollection = new SiarLibrary.RnaStrumentiXComponentiCollection();
            rnaStrumentiXComponentiCollection = rnaStrumentiXComponentiCollectionProvider.Select(null, hdnIdComponenteSelezionata.Value, lstStrumentiRNA.SelectedValue, null);
            if (rnaStrumentiXComponentiCollection.Count == 0)
                ShowError("Strumento d'aiuto non trovato");
            else
            {
                rnaStrumentiXComponentiCollectionProvider.Delete(rnaStrumentiXComponentiCollection[0]);
                ShowMessage("Strumento eliminato correttamente");
            }
        }
        protected void btnSalvaDatiBandoRna_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodiceBandoRNA.Text))
                    ShowError("Il Codice Bando RNA non può essere vuoto");
                else
                {
                    SiarBLL.RnaBandoConfigCollectionProvider rnaBandoConfigCollectionProvider = new SiarBLL.RnaBandoConfigCollectionProvider();
                    SiarLibrary.RnaBandoConfigCollection rnaBandoConfigCollection = rnaBandoConfigCollectionProvider.Select(null, Bando.IdBando, null, null, null, null, null);
                    if (rnaBandoConfigCollection.Count == 0)
                    {
                        SiarLibrary.RnaBandoConfig rnaBandoConfig = new SiarLibrary.RnaBandoConfig
                        {
                            IdBando = Bando.IdBando,
                            CodBandoRna = txtCodiceBandoRNA.Text,
                            Cumulabilita = comboCumulabilita.SelectedValue,
                            CodBandoRnaCollaudo = txtCodiceBandoRnaCollaudo.Text,
                            DataPrevistaConcessione = txtDataConcessione.Text,
                            IdRnaEnte = cmbEnteAccount.SelectedValue
                        };
                        rnaBandoConfigCollectionProvider.Save(rnaBandoConfig);
                    }
                    else
                    {
                        SiarLibrary.RnaBandoConfig rnaBandoConfig = rnaBandoConfigCollection[0];

                        rnaBandoConfig.CodBandoRna = txtCodiceBandoRNA.Text;
                        rnaBandoConfig.Cumulabilita = comboCumulabilita.SelectedValue;
                        rnaBandoConfig.CodBandoRnaCollaudo = txtCodiceBandoRnaCollaudo.Text;
                        rnaBandoConfig.DataPrevistaConcessione = txtDataConcessione.Text;
                        rnaBandoConfig.IdRnaEnte = cmbEnteAccount.SelectedValue;
                        rnaBandoConfigCollectionProvider.Save(rnaBandoConfig);
                    } 
                        
                    ShowMessage("Dati salvati correttamente");
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
        //Popola combo
        private void PopolaComboBandoConfigRna()
        {
            comboCumulabilita.Items.Add(new ListItem() { Text = "Si", Value = "1" });
            comboCumulabilita.Items.Add(new ListItem() { Text = "No", Value = "0" });
            var entiAcc = new SiarBLL.RnaEntiCollectionProvider().FindCodEnte(Bando.CodEnte);
            foreach (SiarLibrary.RnaEnti ente in entiAcc)
                cmbEnteAccount.Items.Add(new ListItem() { Text = ente.DescrizioneAccount, Value = ente.IdRnaEnte });
        }
        protected void btnProgrammazionePost_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}

