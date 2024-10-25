using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using System.Collections.Generic;
using System.Linq;
using SiarLibrary.Extensions;
using System.Security.Cryptography;
using System.Text;

namespace web.Private.CertificazioneSpesa
{
    public partial class CertificazioneConti : SiarLibrary.Web.PrivatePage
    {
        CertificazioneContiCollectionProvider conti_provider = new CertificazioneContiCollectionProvider();
        SiarLibrary.CertificazioneConti contiSel = null; 
        CertificazioneContiCollection contiColl = new CertificazioneContiCollection();
        CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
        decimal colonnaATot, colonnaBTot, colonnaCTot, colonnaDTot, colonnaETot, colonnaFTot, colonnaEAdATot, colonnaFAdATot = 0;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "certificazione_conti";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenFields_Valorizza();
        }

        protected override void OnPreRender(EventArgs e)
        {
            VisualizzaElencoCertificazioni();
            AbilitaOggettiLoad();
            base.OnPreRender(e);
        }

        #region Autorizzazioni

        private void AbilitaOggettiLoad()
        {
            // Testa
            var certCheck = conti_provider.FindCertificazioneConti(null, null, null, false);
            if (certCheck.Count > 0)
            {
                lnkNuovaCertificazione.Visible = false;
            }
            else
            {
                lnkNuovaCertificazione.Visible = true;
            }
            btnNuovaCertificazione.Enabled = AbilitaModifica;
            lnkNuovaCertificazione.Enabled = AbilitaModifica;
        }

        private void AbilitaOggettiDettaglio()
        {
            // Dettaglio
            if (contiSel.FlagDefinitivo)
            {
                btnEliminaCertificazione.Visible = false;
                btnSalvaIntestazione.Visible = false;
                btnSalvaDefinitivo.Visible = false;

                btnAggiornaAppendice1.Visible = false;
                btnSalvaAppendice1.Visible = false;

                btnAggiornaAppendice2.Visible = false;
                btnSalvaAppendice2.Visible = false;

                btnAggiornaAppendice3.Visible = false;
                btnSalvaAppendice3.Visible = false;

                btnAggiornaAppendice4.Visible = false;
                btnSalvaAppendice4.Visible = false;

                btnAggiornaAppendice5.Visible = false;
                btnSalvaAppendice5.Visible = false;

                btnAggiornaAppendice6.Visible = false;
                btnSalvaAppendice6.Visible = false;

                btnAggiornaAppendice7.Visible = false;
                btnSalvaAppendice7.Visible = false;

                btnAggiornaAppendice8.Visible = false;
                btnSalvaAppendice8.Visible = false;
                return;
            }

            btnEliminaCertificazione.Enabled = AbilitaModifica;
            btnSalvaIntestazione.Enabled = AbilitaModifica;
            btnSalvaDefinitivo.Enabled = AbilitaModifica;
            btnSalvaAppendice1.Enabled = AbilitaModifica;
            btnSalvaAppendice2.Enabled = AbilitaModifica;
            btnSalvaAppendice3.Enabled = AbilitaModifica;
            btnSalvaAppendice4.Enabled = AbilitaModifica;
            btnSalvaAppendice5.Enabled = AbilitaModifica;

            btnAggiornaAppendice1.Enabled = AbilitaModifica;
            btnSalvaAppendice1.Enabled = AbilitaModifica;

            btnAggiornaAppendice2.Enabled = AbilitaModifica;
            btnSalvaAppendice2.Enabled = AbilitaModifica;

            btnAggiornaAppendice3.Enabled = AbilitaModifica;
            btnSalvaAppendice3.Enabled = AbilitaModifica;

            btnAggiornaAppendice4.Enabled = AbilitaModifica;
            btnSalvaAppendice4.Enabled = AbilitaModifica;

            btnAggiornaAppendice5.Enabled = AbilitaModifica;
            btnSalvaAppendice5.Enabled = AbilitaModifica;

            btnAggiornaAppendice6.Enabled = AbilitaModifica;
            btnSalvaAppendice6.Enabled = AbilitaModifica;

            btnAggiornaAppendice7.Enabled = AbilitaModifica;
            btnSalvaAppendice7.Enabled = AbilitaModifica;

            btnAggiornaAppendice8.Enabled = AbilitaModifica;
            btnSalvaAppendice8.Enabled = AbilitaModifica;
        }

        #endregion


        #region Visualizzazione 

        private void VisualizzaElencoCertificazioni()
        {
            CertificazioneContiCollection certcontis; 

            divContainerElencoCertificazioni.Visible = true;
            divElencoCertificazioni.Visible = true;

            if(contiSel!= null)
            {
                certcontis = new CertificazioneContiCollection();
                certcontis.Add(contiSel);
                dgElencoCertificazioni.Titolo = "Selezionare per tornare all'elenco delle certificazioni";
            }
            else
            {
                certcontis = conti_provider.FindCertificazioneConti(null, null, null, null);
                if (certcontis.Count == 0)
                {
                    dgElencoCertificazioni.Titolo = "Nessuna certificazione presente";
                }
                else
                {
                    dgElencoCertificazioni.Titolo = "Selezionare la certificazione per visualizzare il dettaglio";
                    RemovePeriodiContabili(certcontis);
                }
            }
            
            dgElencoCertificazioni.DataSource = certcontis;
            dgElencoCertificazioni.DataBind();
            VisualizzaDettaglio();
        }

        private void VisualizzaDettaglio()
        {
            const int cIntestazione = 1,
                      cAppendice1 = 2,
                      cAppendice2 = 3,
                      cAppendice3 = 4,
                      cAppendice4 = 5,
                      cAppendice5 = 6,
                      cAppendice6 = 7,
                      cAppendice7 = 8,
                      cAppendice8 = 9,
                      cDecertificazioni = 10;

            if (contiSel == null)
            {
                hdnIdConto.Value = null;
                hdnPeriodoContabile.Value = null;
                divDettaglioCertificazione.Visible = false;

                return;
            }

            AbilitaOggettiDettaglio();

            divDettaglioCertificazione.Visible = true;

            switch (tabDettaglio.TabSelected)
            {
                case cIntestazione:
                    divIntestazione.Visible = true;
                    LoadIntestazione();
                    break;
                case cAppendice1:
                    divAppendice1.Visible = true;
                    LoadDgAppendice1();
                    break;
                case cAppendice2:
                    divAppendice2.Visible = true;
                    LoadDgAppendice2();
                    LoadDettaglioDgAppendice2();
                    break;
                case cAppendice3:
                    divAppendice3.Visible = true;
                    LoadDgAppendice3();
                    LoadDettaglioDgAppendice3();
                    break;
                case cAppendice4:
                    divAppendice4.Visible = true;
                    LoadDgAppendice4();
                    LoadDettaglioDgAppendice4();
                    break;
                case cAppendice5:;
                    divAppendice5.Visible = true;
                    LoadDgAppendice5();
                    break;
                case cAppendice6:
                    divAppendice6.Visible = true;
                    LoadDgAppendice6();
                    break;
                case cAppendice7:
                    divAppendice7.Visible = true;
                    LoadDgAppendice7();
                    break;
                case cAppendice8:
                    divAppendice8.Visible = true;
                    LoadDgAppendice8();
                    break;
                case cDecertificazioni:
                    divDecertificazioni.Visible = true;
                    LoadDecertificazioni();
                    break;
                default:
                    break;
            }
        }

        private void RemovePeriodiContabili(CertificazioneContiCollection conti)
        {
            foreach(SiarLibrary.CertificazioneConti cert in conti)
            {
                if (cert.FlagDefinitivo)
                {
                    string periodo = cert.AnnoContabileDa.ToFullYearString() + " - " + cert.AnnoContabileA.ToFullYearString();
                    cmbAnniContabili.Items.Remove(cmbAnniContabili.Items.FindByValue(periodo));
                }
            }
        }

        #endregion

        #region caricamento dettagli

        private void LoadIntestazione()
        {
            var app = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TestataCertificazioneConti;
            SiarLibrary.NullTypes.DatetimeNT data = app.DataPresentazioneConti;
            txtDataCertificazione.Text = data;
        }

        private void LoadDgAppendice1()
        {
            if (contiSel != null)
            {      
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice1.UniqueID)
                        {
                            List<RecordAppendice1Type> app = new List<RecordAppendice1Type>();
                            var appendice1_list = conti_provider.GrigliaAppendice1Conti(contiSel.AnnoContabileA);
                            if (appendice1_list.Count > 0)
                            {

                                foreach (var appendice1_asse in appendice1_list)
                                {
                                    var item = new RecordAppendice1Type();
                                    item.IdAsse = appendice1_asse.IdAsse;
                                    item.Asse = appendice1_asse.Asse;
                                    item.ImportoTotaleSpeseAdCToCommissione = appendice1_asse.ImportoA;
                                    item.ImportoTotaleSpesaPubblica = appendice1_asse.ImportoB;
                                    item.ImportoTotaleSpesaPubblicaErogataBeneficiari = appendice1_asse.ImportoC;
                                    item.ImportoTotaleSpeseAdCToCommissioneAdA = appendice1_asse.ImportoAAdA;
                                    item.ImportoTotaleSpesaPubblicaAdA = appendice1_asse.ImportoBAdA;

                                    app.Add(item);
                                }

                                dgAppendice1.DataSource = app;
                                dgAppendice1.MostraTotale("Importo", 1, 2, 3, 4, 5);
                                dgAppendice1.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 7 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice1.RecordAppendice1;
                        dgAppendice1.DataSource = app2;
                        dgAppendice1.MostraTotale("Importo", 1, 2, 3, 4, 5);
                        dgAppendice1.DataBind();
                    }
                }
            }
        }

        private void LoadDgAppendice2()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice2.UniqueID)
                        {
                            List<RecordAppendice2Type> app = new List<RecordAppendice2Type>();
                            var appendice2_list = conti_provider.GrigliaAppendice2Conti(contiSel.AnnoContabileA);
                            if (appendice2_list.Count > 0)
                            {

                                foreach (var appendice2_asse in appendice2_list)
                                {
                                    var item = new RecordAppendice2Type();
                                    item.IdAsse = appendice2_asse.IdAsse;
                                    item.Asse = appendice2_asse.Asse;
                                    item.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = appendice2_asse.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                                    item.ImportoSpesaPubblicaCorrispondenteRitiri = appendice2_asse.ImportoSpesaPubblicaCorrispondenteRitiri;
                                    item.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = appendice2_asse.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                                    item.ImportoSpesaPubblicaCorrispondenteRecuperi = appendice2_asse.ImportoSpesaPubblicaCorrispondenteRecuperi;

                                    app.Add(item);
                                }

                                dgAppendice2.DataSource = app;
                                dgAppendice2.ItemDataBound += new DataGridItemEventHandler(dgAppendice2_ItemDataBound);
                                dgAppendice2.MostraTotale("Importo", 1, 2, 3);
                                dgAppendice2.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 2 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice2.RecordAppendice2;
                        dgAppendice2.DataSource = app2;
                        dgAppendice2.ItemDataBound += new DataGridItemEventHandler(dgAppendice2_ItemDataBound);
                        dgAppendice2.MostraTotale("Importo", 1, 2, 3);
                        dgAppendice2.DataBind();
                    }
                }
            }
        }

        private void LoadDettaglioDgAppendice2()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice2.UniqueID)
                        {
                            List<RecordDettaglioAppendice2Type> app = new List<RecordDettaglioAppendice2Type>();
                            var dAppendice2_list = conti_provider.GrigliaAppendice2ContiDettaglio(contiSel.AnnoContabileA);
                            if (dAppendice2_list.Count > 0)
                            {
                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice2.RecordDettaglioAppendice2;
                                foreach (var riga_istanza in app2)
                                {
                                    riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = 0;
                                    riga_istanza.ImportoSpesaPubblicaCorrispondenteRitiri = 0;
                                    riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = 0;
                                    riga_istanza.ImportoSpesaPubblicaCorrispondenteRecuperi = 0;
                                }
                                foreach (var dAppendice2_record in dAppendice2_list)
                                {
                                    foreach (var riga_istanza in app2)
                                    {
                                        if(riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice2_record.Anno)
                                        {
                                            riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri += dAppendice2_record.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                                            riga_istanza.ImportoSpesaPubblicaCorrispondenteRitiri += dAppendice2_record.ImportoSpesaPubblicaCorrispondenteRitiri;
                                            riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi += dAppendice2_record.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                                            riga_istanza.ImportoSpesaPubblicaCorrispondenteRecuperi += dAppendice2_record.ImportoSpesaPubblicaCorrispondenteRecuperi;
                                        }
                                    }
                                }

                                dgDettaglioAppendice2.DataSource = app2;
                                dgDettaglioAppendice2.ItemDataBound += new DataGridItemEventHandler(dgDettaglioAppendice2_ItemDataBound);
                                dgDettaglioAppendice2.MostraTotale("Importo", 1, 2, 3, 4);
                                dgDettaglioAppendice2.DataBind();
                            }
                            else
                            {
                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice2.RecordDettaglioAppendice2;
                                dgDettaglioAppendice2.DataSource = app2;
                                dgDettaglioAppendice2.ItemDataBound += new DataGridItemEventHandler(dgDettaglioAppendice2_ItemDataBound);
                                dgDettaglioAppendice2.MostraTotale("Importo", 1, 2, 3, 4);
                                dgDettaglioAppendice2.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 2 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice2.RecordDettaglioAppendice2;
                        dgDettaglioAppendice2.DataSource = app2;
                        dgDettaglioAppendice2.ItemDataBound += new DataGridItemEventHandler(dgDettaglioAppendice2_ItemDataBound);
                        dgDettaglioAppendice2.MostraTotale("Importo", 1, 2, 3, 4);
                        dgDettaglioAppendice2.DataBind();
                    }
                }
            }
        }

        private void LoadDgAppendice3()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice3.UniqueID)
                        {
                            List<RecordAppendice3Type> app = new List<RecordAppendice3Type>();
                            var appendice3_list = conti_provider.GrigliaAppendice3Conti(contiSel.AnnoContabileA);
                            if (appendice3_list.Count > 0)
                            {
                                foreach (var appendice3_asse in appendice3_list)
                                {
                                    var item = new RecordAppendice3Type();
                                    item.IdAsse = appendice3_asse.IdAsse;
                                    item.Asse = appendice3_asse.Asse;
                                    item.ImportoTotaleAmmissibileSpese = appendice3_asse.ImportoTotaleAmmissibileSpese;
                                    item.ImportoSpesaPubblicaCorrispondente = appendice3_asse.ImportoSpesaPubblicaCorrispondente;
                                    app.Add(item);
                                }

                                dgAppendice3.DataSource = app;
                                dgAppendice3.MostraTotale("Importo", 1, 2);
                                dgAppendice3.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 3 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice3.RecordAppendice3;
                        dgAppendice3.DataSource = app2;
                        dgAppendice3.MostraTotale("Importo", 1, 2);
                        dgAppendice3.DataBind();
                    }
                }
            }
        }

        private void LoadDettaglioDgAppendice3()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice3.UniqueID)
                        {
                            List<RecordDettaglioAppendice3Type> app = new List<RecordDettaglioAppendice3Type>();
                            var dAppendice3_list = conti_provider.GrigliaAppendice3ContiDettaglio(contiSel.AnnoContabileA);
                            if (dAppendice3_list.Count > 0)
                            {


                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice3.RecordDettaglioAppendice3;
                                foreach (var riga_istanza in app2)
                                {
                                    riga_istanza.ImportoTotaleAmmissibileSpese = 0;
                                    riga_istanza.ImportoSpesaPubblicaCorrispondente = 0;
                                }
                                foreach (var dAppendice3_record in dAppendice3_list)
                                {
                                    foreach (var riga_istanza in app2)
                                    {
                                        if (riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice3_record.Anno)
                                        {
                                            riga_istanza.ImportoTotaleAmmissibileSpese += dAppendice3_record.ImportoTotaleAmmissibileSpese;
                                            riga_istanza.ImportoSpesaPubblicaCorrispondente = dAppendice3_record.ImportoSpesaPubblicaCorrispondente;
                                        }
                                    }
                                }

                                dgDettaglioAppendice3.DataSource = app2;
                                dgDettaglioAppendice3.MostraTotale("Importo", 1, 2);
                                dgDettaglioAppendice3.DataBind();
                            }
                            else
                            {
                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice3.RecordDettaglioAppendice3;
                                dgDettaglioAppendice3.DataSource = app2;
                                dgDettaglioAppendice3.MostraTotale("Importo", 1, 2);
                                dgDettaglioAppendice3.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 3 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice3.RecordDettaglioAppendice3;
                        dgDettaglioAppendice3.DataSource = app2;
                        dgDettaglioAppendice3.MostraTotale("Importo", 1, 2);
                        dgDettaglioAppendice3.DataBind();
                    }
                }
            }
        }

        private void LoadDgAppendice4()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice4.UniqueID)
                        {
                            List<RecordAppendice4Type> app = new List<RecordAppendice4Type>();
                            var appendice4_list = conti_provider.GrigliaAppendice4Conti(contiSel.AnnoContabileA);
                            if (appendice4_list.Count > 0)
                            {

                                foreach (var appendice4_asse in appendice4_list)
                                {
                                    var item = new RecordAppendice4Type();
                                    item.IdAsse = appendice4_asse.IdAsse;
                                    item.Asse = appendice4_asse.Asse;
                                    item.ImportoTotaleAmmissibileSpeseRecuperi = appendice4_asse.ImportoTotaleAmmissibileSpeseRecuperi;
                                    item.ImportoSpesaPubblicaCorrispondenteRecuperi = appendice4_asse.ImportoSpesaPubblicaCorrispondenteRecuperi;
                                    app.Add(item);
                                }

                                dgAppendice4.DataSource = app;
                                dgAppendice4.MostraTotale("Importo", 1, 2);
                                dgAppendice4.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 4 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice4.RecordAppendice4;
                        dgAppendice4.DataSource = app2;
                        dgAppendice4.MostraTotale("Importo", 1, 2);
                        dgAppendice4.DataBind();
                    }
                }
            }
        }

        

        private void LoadDettaglioDgAppendice4()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice4.UniqueID)
                        {
                            List<RecordDettaglioAppendice4Type> app = new List<RecordDettaglioAppendice4Type>();
                            var dAppendice4_list = conti_provider.GrigliaAppendice4ContiDettaglio(contiSel.AnnoContabileA);
                            if (dAppendice4_list.Count > 0)
                            {

                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice4.RecordDettaglioAppendice4;
                                foreach (var riga_istanza in app2)
                                {
                                    riga_istanza.ImportoTotaleAmmissibileSpese = 0;
                                    riga_istanza.ImportoSpesaPubblicaCorrispondente = 0;
                                }
                                foreach (var dAppendice4_record in dAppendice4_list)
                                {
                                    foreach (var riga_istanza in app2)
                                    {
                                        if (riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice4_record.Anno)
                                        {
                                            riga_istanza.ImportoTotaleAmmissibileSpese += dAppendice4_record.ImportoTotaleAmmissibileSpese;
                                            riga_istanza.ImportoSpesaPubblicaCorrispondente += dAppendice4_record.ImportoSpesaPubblicaCorrispondente;
                                        }
                                    }
                                }

                                dgDettaglioAppendice4.DataSource = app2;
                                dgDettaglioAppendice4.MostraTotale("Importo", 1, 2);
                                dgDettaglioAppendice4.DataBind();
                            }
                            else
                            {
                                var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice4.RecordDettaglioAppendice4;
                                dgDettaglioAppendice4.DataSource = app2;
                                dgDettaglioAppendice4.MostraTotale("Importo", 1, 2);
                                dgDettaglioAppendice4.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 4 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaDettaglioAppendice4.RecordDettaglioAppendice4;
                        dgDettaglioAppendice4.DataSource = app2;
                        dgDettaglioAppendice4.MostraTotale("Importo", 1, 2);
                        dgDettaglioAppendice4.DataBind();
                    }
                }
            }
        }

        private void LoadDgAppendice5()
        {
            if (contiSel != null)
            {
                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice5.UniqueID)
                        {
                            List<RecordAppendice5Type> app = new List<RecordAppendice5Type>();
                            var appendice5_list = conti_provider.GrigliaAppendice5Conti(contiSel.AnnoContabileA);
                            if (appendice5_list.Count > 0)
                            {

                                foreach (var appendice5_asse in appendice5_list)
                                {
                                    var item = new RecordAppendice5Type();
                                    item.IdAsse = appendice5_asse.IdAsse;
                                    item.Asse = appendice5_asse.Asse;
                                    item.ImportoTotaleAmmissibileSpeseIrrecuperabili = appendice5_asse.ImportoTotaleAmmissibileSpeseIrrecuperabili;
                                    item.ImportoSpesaPubblicaCorrispondenteIrrecuperabili = appendice5_asse.ImportoSpesaPubblicaCorrispondenteIrrecuperabili;
                                    item.Osservazioni = appendice5_asse.Osservazioni;
                                    app.Add(item);
                                }

                                dgAppendice5.DataSource = app;
                                dgAppendice5.ItemDataBound += new DataGridItemEventHandler(dgAppendice5_ItemDataBound);
                                dgAppendice5.MostraTotale("Importo", 1, 2);
                                dgAppendice5.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 5 non trovati");
                    }
                    else
                    {
                        var app2 = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice5.RecordAppendice5;
                        dgAppendice5.DataSource = app2;
                        dgAppendice5.ItemDataBound += new DataGridItemEventHandler(dgAppendice5_ItemDataBound);
                        dgAppendice5.MostraTotale("Importo", 1, 2);
                        dgAppendice5.DataBind();
                    }
                }
            }
        }

        private void dgAppendice5_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "Priorità (Assi)</td><td colspan='3' style='text-align:center;'>IMPORTI IRRECUPERABILI</td></tr><tr class='TESTA1'>";
            }
        }

        private void LoadDgAppendice6()
        {
            if (contiSel != null)
            {
                List<RecordAppendice6Type> app = new List<RecordAppendice6Type>();

                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice6.UniqueID)
                        {
                            var appendice6_list = conti_provider.GrigliaAppendice6Conti(contiSel.AnnoContabileA);

                            if (appendice6_list.Count > 0)
                            {
                                foreach (var appendice6_asse in appendice6_list)
                                {
                                    var item = new RecordAppendice6Type();
                                    item.IdAsse = appendice6_asse.IdAsse;
                                    item.Asse = appendice6_asse.Asse;
                                    item.ImportoErogatoContributiStrumentiFinanziari = appendice6_asse.ImportoErogatoContributiStrumentiFinanziari;
                                    item.ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = appendice6_asse.ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente;
                                    item.ImportoErogatoSpesaStrumentiFinanziari = appendice6_asse.ImportoErogatoSpesaStrumentiFinanziari;
                                    item.ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = appendice6_asse.ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente;

                                    app.Add(item);
                                }

                                dgAppendice6.DataSource = app;
                                dgAppendice6.ItemDataBound += new DataGridItemEventHandler(dgAppendice6_ItemDataBound);
                                dgAppendice6.MostraTotale("Importo", 1, 2, 3, 4);
                                dgAppendice6.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 6 non trovati");
                    }
                }

                app = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice6.RecordAppendice6;
                dgAppendice6.DataSource = app;
                dgAppendice6.ItemDataBound += new DataGridItemEventHandler(dgAppendice6_ItemDataBound);
                dgAppendice6.MostraTotale("Importo", 1, 2, 3, 4);
                dgAppendice6.DataBind();
            }
        }

        private void dgAppendice6_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "Priorità (Assi)</td><td colspan='2' style='text-align:center;'>Importi dei contributi per programma erogati agli strumenti finanziari e inclusi nelle domande di pagamento</td><td colspan='2' style='text-align:center;'>Importi erogati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013</td></tr><tr class='TESTA1'>";
            }
        }

        private void LoadDgAppendice7()
        {
            if (contiSel != null)
            {
                List<RecordAppendice7Type> app = new List<RecordAppendice7Type>();

                if (IsPostBack)
                {
                    string CtrlID = string.Empty;

                    if (Request.Form[hidSourceID.UniqueID] != null &&
                        Request.Form[hidSourceID.UniqueID] != string.Empty)
                    {
                        CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                    }
                    if (CtrlID != null && CtrlID != string.Empty)
                    {
                        if (CtrlID == btnAggiornaAppendice7.UniqueID)
                        {
                            var appendice7_list = conti_provider.GrigliaAppendice7Conti(contiSel.AnnoContabileA); 

                            if (appendice7_list.Count > 0)
                            {

                                foreach (var appendice7_asse in appendice7_list)
                                {
                                    var item = new RecordAppendice7Type();
                                    item.IdAsse = appendice7_asse.IdAsse;
                                    item.Asse = appendice7_asse.Asse;
                                    item.ImportoComplessivoVersatoAnticipi = appendice7_asse.ImportoComplessivoVersatoAnticipi;
                                    item.ImportoCopertoAnticipiEntro = appendice7_asse.ImportoCopertoAnticipiEntro;
                                    item.ImportoNonCopertoAnticipiEntro = appendice7_asse.ImportoNonCopertoAnticipiEntro;

                                    app.Add(item);
                                }

                                dgAppendice7.DataSource = app;
                                dgAppendice7.MostraTotale("Importo", 1, 2, 3);
                                dgAppendice7.DataBind();
                            }

                            var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                            RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                            return;
                        }
                        else
                            throw new Exception("Dati appendice 7 non trovati");
                    }
                }

                app = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice7.RecordAppendice7;
                dgAppendice7.DataSource = app;
                dgAppendice7.MostraTotale("Importo", 1, 2, 3);
                dgAppendice7.DataBind();
            }
        }

        private void LoadDgAppendice8()
        {
            try
            {
                if (contiSel != null)
                {
                    List<RecordAppendice8Type> app = new List<RecordAppendice8Type>();

                    if (IsPostBack)
                    {
                        string CtrlID = string.Empty;

                        if (Request.Form[hidSourceID.UniqueID] != null &&
                            Request.Form[hidSourceID.UniqueID] != string.Empty)
                        {
                            CtrlID = Request.Form[hidSourceID.UniqueID].Replace('_', '$');
                        }
                        if (CtrlID != null && CtrlID != string.Empty)
                        {
                            if (CtrlID == btnAggiornaAppendice8.UniqueID)
                            {
                                string codPsr = "POR20142020";
                                DateTime dataLotto = contiSel.AnnoContabileA;

                                var appendice8_list = conti_provider.GrigliaAppendice8Conti(codPsr, dataLotto, contiSel.IstanzaCertificazioneConti);

                                if (appendice8_list.Count > 0)
                                {
                                    colonnaATot = appendice8_list.Sum(a => a.ImportoTotaleSpeseAmmissibiliBeneficiari);
                                    colonnaBTot = appendice8_list.Sum(a => a.ImportoTotaleSpesaPubblica);
                                    colonnaCTot = appendice8_list.Sum(a => a.ImportoTotaleSpeseAmmissibiliAdC);
                                    colonnaDTot = appendice8_list.Sum(a => a.ImportoTotaleSpesaPubblicaAdC);
                                    colonnaETot = appendice8_list.Sum(a => a.DifferenzaSpesaAmmissibile);
                                    colonnaFTot = appendice8_list.Sum(a => a.DifferenzaSpesaPubblicaAdC);
                                    colonnaEAdATot = appendice8_list.Sum(a => a.DifferenzaSpesaAmmissibileAdA);
                                    colonnaFAdATot = appendice8_list.Sum(a => a.DifferenzaSpesaPubblicaAdCAdA);

                                    foreach (var appendice8_asse in appendice8_list)
                                    {
                                        var item = new RecordAppendice8Type();
                                        item.IdAsse = appendice8_asse.IdAsse;
                                        item.Asse = appendice8_asse.Asse;
                                        item.ImportoTotaleSpeseAmmissibiliBeneficiari = appendice8_asse.ImportoTotaleSpeseAmmissibiliBeneficiari;
                                        item.ImportoTotaleSpesaPubblica = appendice8_asse.ImportoTotaleSpesaPubblica;
                                        item.ImportoTotaleSpeseAmmissibiliAdC = appendice8_asse.ImportoTotaleSpeseAmmissibiliAdC;
                                        item.ImportoTotaleSpesaPubblicaAdC = appendice8_asse.ImportoTotaleSpesaPubblicaAdC;
                                        item.DifferenzaSpesaAmmissibile = appendice8_asse.DifferenzaSpesaAmmissibile;
                                        item.DifferenzaSpesaPubblicaAdC = appendice8_asse.DifferenzaSpesaPubblicaAdC;
                                        item.Osservazioni = appendice8_asse.Osservazioni;
                                        item.DifferenzaSpesaAmmissibileAdA = appendice8_asse.DifferenzaSpesaAmmissibileAdA;
                                        item.DifferenzaSpesaPubblicaAdCAdA = appendice8_asse.DifferenzaSpesaPubblicaAdCAdA;

                                        app.Add(item);
                                    }

                                    dgAppendice8.DataSource = app;
                                    dgAppendice8.ItemDataBound += new DataGridItemEventHandler(dgAppendice8_ItemDataBound);
                                    dgAppendice8.ShowFooter = true;
                                    dgAppendice8.DataBind();
                                }

                                var messaggio = "Dati calcolati correttamente. E' possibile confermarli e salvarli con l'apposito pulsante.";
                                RegisterClientScriptBlock("EmpySource(); mostraPopupMessaggio('" + messaggio.ToCleanJsString() + "',0);");

                                return;
                            }
                            else
                                throw new Exception("Dati appendice 8 non trovati");
                        }
                    }

                    app = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TabellaAppendice8.RecordAppendice8;
                    colonnaATot = app.Sum(a => a.ImportoTotaleSpeseAmmissibiliBeneficiari);
                    colonnaBTot = app.Sum(a => a.ImportoTotaleSpesaPubblica);
                    colonnaCTot = app.Sum(a => a.ImportoTotaleSpeseAmmissibiliAdC);
                    colonnaDTot = app.Sum(a => a.ImportoTotaleSpesaPubblicaAdC);
                    colonnaETot = app.Sum(a => a.DifferenzaSpesaAmmissibile);
                    colonnaFTot = app.Sum(a => a.DifferenzaSpesaPubblicaAdC);
                    colonnaEAdATot = app.Sum(a => a.DifferenzaSpesaAmmissibileAdA);
                    colonnaFAdATot = app.Sum(a => a.DifferenzaSpesaPubblicaAdCAdA);

                    dgAppendice8.DataSource = app;
                    dgAppendice8.ItemDataBound += new DataGridItemEventHandler(dgAppendice8_ItemDataBound);
                    dgAppendice8.ShowFooter = true;
                    dgAppendice8.DataBind();
                }
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        void dgAppendice8_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "Priorità (Assi)</td><td colspan='2'>Spesa totale ammissibile inclusa nelle domande di pagamento presentate alla Commissione</td><td colspan='2'>Spesa dichiarata conformemente all'articolo 137, paragrafo 1, lettera a), del regolamento (UE) n. 1303/2013</td><td colspan='2' style='text-align:center;'>Differenza</td><td>&nbsp;</td><td colspan='2' class='nascondi' style='text-align:center;'>Differenza AdA</td></tr><tr class='TESTA1'>";
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                //gestisco totali controlli AdA e totali manualmente per la doppia riga
                TableCell td = e.Item.Cells[0];
                td.Text =
                    "</tr>"
                    + "<tr class='coda'>"
                        + "<td>TOTALI</td>"
                        + "<td align='right'>" + colonnaATot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaBTot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaCTot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaDTot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaETot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaFTot.ToString("n") + "</td>"
                        + "<td></td>" //colonna osservazioni
                        + "<td class='nascondi'></td>"
                        + "<td class='nascondi'></td>"
                    + "</tr>"
                    + "<tr class='coda'>"
                        + "<td colspan=5>Di cui importi rettificati nei conti del periodo corrente in seguito ad audit relativi alle operazioni effettuati a norma dell'articolo 127, paragrafo 1, del regolamento (UE) n. 1303/2013 </td>"
                        + "<td align='right'>" + colonnaEAdATot.ToString("n") + "</td>"
                        + "<td align='right'>" + colonnaFAdATot.ToString("n") + "</td>"
                        + "<td></td>" //colonna osservazioni
                        + "<td class='nascondi'></td>"
                        + "<td class='nascondi'></td>"
                    + "</tr>";
                td.CssClass = "coda";

            }
        }

        void dgDettaglioAppendice2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "&nbsp;</td><td colspan='2' style='text-align:center;'>RITIRI</td><td colspan='2' style='text-align:center;'>RECUPERI</td></tr><tr class='TESTA1'>";
            }
        }

        void dgAppendice2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "Priorità (Assi)</td><td colspan='2' style='text-align:center;'>RITIRI</td><td colspan='2' style='text-align:center;'>RECUPERI</td></tr><tr class='TESTA1'>";
            }
        }

        private void dgAppendice4_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                //dgi.Cells[1].ColumnSpan = 1;
                dgi.Cells[0].Text = "Priorità (Assi)</td><td colspan='2' style='text-align:center;'>RECUPERI</td></tr><tr class='TESTA1'>";
            }
        }

        #endregion

        private void LoadDecertificazioni()
        {
            if (contiSel != null)
            {
                if (contiSel.FlagDefinitivo == true)
                    btnSalvaDecert.Enabled = false;

                var decertificazioneCollection = certDecertificazioneCollectionProvider.GetDecertificazioniPerCertificazioneConti(contiSel.IdCertificazioneConti, contiSel.FlagDefinitivo);

                dgDecertificazioni.DataSource = decertificazioneCollection;
                dgDecertificazioni.ItemDataBound += new DataGridItemEventHandler(dgDecertificazione_ItemDataBound);
                dgDecertificazioni.DataBind();
                divDecertificazioni.Visible = true;

                if (decertificazioneCollection.Count == 0)
                    divContenutoDecert.Visible = false;
                else
                    lblDecertificazioni.Visible = false;
            }
        }
        protected void btnSalvaDecert_Click(object sender, EventArgs e)
        {
            string[] sel = hdnDecertSelezionate.Value.Split('|');
            CertspDettaglioCollectionProvider certspDettaglioCollectionProvider = new CertspDettaglioCollectionProvider();
            CertDecertificazioneCollection decertificazioneCollection;
            decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, null, null, null, true, true, null);
            var appDecertificazioni = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, contiSel.IdCertificazioneConti, null, null, null, null, null);
            if (appDecertificazioni.Count != 0)
                foreach (CertDecertificazione d in appDecertificazioni)
                    decertificazioneCollection.Add(d);
            foreach (CertDecertificazione d in decertificazioneCollection)
            {
                d.Assegnata = false;
                d.IdCertificazioneConti = null;

                for (int i = 0; i < sel.Length - 1; i++)
                {
                    if (d.IdCertDecertificazione == int.Parse(sel[i]))
                    {
                        d.Assegnata = 1;
                        d.IdCertificazioneConti = contiSel.IdCertificazioneConti;
                    }
                }
            }
            certDecertificazioneCollectionProvider.SaveCollection(decertificazioneCollection);
        }
        void dgDecertificazione_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            e.Item.Cells[7].Style.Add("display", "none");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                 
                CertDecertificazione d = (CertDecertificazione)e.Item.DataItem;
                if (d.Assegnata == true)
                {
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input ", "<input checked ");
                }
                else
                {
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("checked", "");
                }
                if(contiSel.FlagDefinitivo == true)
                {
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace("<input ", "<input disabled ");
                }
            }
        }
        private void rendiDefinitiveDecertificazioni(int idCertConti)
        {
            CertDecertificazioneCollection decertificazioneCollection;
            decertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, idCertConti, null, null, null, null, null);
            foreach (CertDecertificazione d in decertificazioneCollection)
                d.Definitiva = 1;
            certDecertificazioneCollectionProvider.SaveCollection(decertificazioneCollection);
        }

        protected void lnkNuovaCertificazione_Click(object sender, EventArgs e)
        {
            //Inserire logica per visualizzare solo gli anni contabili non registrati
            divTestataNuovaCertificazione.Visible = true;
        }

        protected void btnNuovaCertificazione_Click(object sender, EventArgs e)
        {
            //logica per la creazione di una istanza vuota della certificazione
            string annoContabile = cmbAnniContabili.SelectedValue;
            string annoDa = annoContabile.Substring(0, 10);
            string annoA = annoContabile.Substring(13, 10);
            CreateNewInstance(annoDa, annoA);
        }

        private void CreateNewInstance(string annoDa, string annoA)
        {
            try
            {
                string anno = annoA.Substring(6, 4);

                IstanzaCertificazioneConti istanza = new IstanzaCertificazioneConti();

                istanza.TestataCertificazioneConti.PeriodoContabile = annoDa + " - " + annoA;
                istanza.TestataCertificazioneConti.FlagDefinitivo = false;

                ZprogrammazioneCollectionProvider progProv = new ZprogrammazioneCollectionProvider();
                var assi = progProv.Find(null, "POR20142020L1", "POR20142020", null, null, 0);
                var assiL = assi.ToArrayList<Zprogrammazione>();

                contiColl = conti_provider.FindCertificazioneConti(null, null, null, true);

                var dett2 = new List<RecordDettaglioAppendice2Type>();
                var dett3 = new List<RecordDettaglioAppendice3Type>();
                var dett4 = new List<RecordDettaglioAppendice4Type>();

                if (contiColl.Count > 0)
                {
                    contiColl.Sort("AnnoContabileA DESC");
                    var dett = contiColl[0];

                    dett2 = IstanzaCertificazioneConti.Deserialize(dett.IstanzaCertificazioneConti).TabellaDettaglioAppendice2.RecordDettaglioAppendice2;
                    dett3 = IstanzaCertificazioneConti.Deserialize(dett.IstanzaCertificazioneConti).TabellaDettaglioAppendice3.RecordDettaglioAppendice3;
                    dett4 = IstanzaCertificazioneConti.Deserialize(dett.IstanzaCertificazioneConti).TabellaDettaglioAppendice4.RecordDettaglioAppendice4;

                }
                //Aggiungo righe vuote del corrente anno contabile
                //Dettaglio Appendice 2
                dett2.Add(new RecordDettaglioAppendice2Type()
                {
                    IdRecord = dett2.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = false
                });
                dett2.Add(new RecordDettaglioAppendice2Type()
                {
                    IdRecord = dett2.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = true
                });
                //Dettaglio Appendice 3
                dett3.Add(new RecordDettaglioAppendice3Type()
                {
                    IdRecord = dett3.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = false
                });
                dett3.Add(new RecordDettaglioAppendice3Type()
                {
                    IdRecord = dett3.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = true
                });
                //Dettaglio Appendice 4
                dett4.Add(new RecordDettaglioAppendice4Type()
                {
                    IdRecord = dett4.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = false
                });
                dett4.Add(new RecordDettaglioAppendice4Type()
                {
                    IdRecord = dett4.Count + 1,
                    Anno = anno,
                    FlagImportiRettificati = true
                });


                foreach (Zprogrammazione asse in assiL)
                {
                    string cod_asse = "Asse " + asse.Codice;

                    //popolamento appendice 1
                    var recordAppendice1 = new RecordAppendice1Type();
                    recordAppendice1.IdAsse = asse.Id;
                    recordAppendice1.Asse = cod_asse;
                    istanza.TabellaAppendice1.RecordAppendice1.Add(recordAppendice1);

                    //popolamento appendice 2
                    var recordAppendice2 = new RecordAppendice2Type();
                    recordAppendice2.IdAsse = asse.Id;
                    recordAppendice2.Asse = cod_asse;
                    istanza.TabellaAppendice2.RecordAppendice2.Add(recordAppendice2);

                    //Popolamento dettaglio Appendice2
                    istanza.TabellaDettaglioAppendice2.RecordDettaglioAppendice2 = dett2;

                    //popolamento appendice 3
                    var recordAppendice3 = new RecordAppendice3Type();
                    recordAppendice3.IdAsse = asse.Id;
                    recordAppendice3.Asse = cod_asse;
                    istanza.TabellaAppendice3.RecordAppendice3.Add(recordAppendice3);

                    //Popolamento dettaglio Appendice3
                    istanza.TabellaDettaglioAppendice3.RecordDettaglioAppendice3 = dett3;

                    //popolamento appendice 4
                    var recordAppendice4 = new RecordAppendice4Type();
                    recordAppendice4.IdAsse = asse.Id;
                    recordAppendice4.Asse = cod_asse;
                    istanza.TabellaAppendice4.RecordAppendice4.Add(recordAppendice4);

                    //Popolamento dettaglio Appendice4
                    istanza.TabellaDettaglioAppendice4.RecordDettaglioAppendice4 = dett4;

                    //popolamento appendice 5
                    var recordAppendice5 = new RecordAppendice5Type();
                    recordAppendice5.IdAsse = asse.Id;
                    recordAppendice5.Asse = cod_asse;
                    istanza.TabellaAppendice5.RecordAppendice5.Add(recordAppendice5);

                    //popolamento appendice 6
                    var recordAppendice6 = new RecordAppendice6Type();
                    recordAppendice6.IdAsse = asse.Id;
                    recordAppendice6.Asse = cod_asse;
                    istanza.TabellaAppendice6.RecordAppendice6.Add(recordAppendice6);

                    //popolamento appendice 7
                    var recordAppendice7 = new RecordAppendice7Type();
                    recordAppendice7.IdAsse = asse.Id;
                    recordAppendice7.Asse = cod_asse;
                    istanza.TabellaAppendice7.RecordAppendice7.Add(recordAppendice7);

                    //popolamento appendice 8
                    var recordAppendice8 = new RecordAppendice8Type();
                    recordAppendice8.IdAsse = asse.Id;
                    recordAppendice8.Asse = cod_asse;
                    istanza.TabellaAppendice8.RecordAppendice8.Add(recordAppendice8);
                }

                var certProv = new CertificazioneContiCollectionProvider();
                var cert = new SiarLibrary.CertificazioneConti(); ;
                cert.FlagDefinitivo = false;
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.AnnoContabileDa = DateTime.Parse(annoDa);
                cert.AnnoContabileA = DateTime.Parse(annoA);
                cert.DataPresentazioneConti = null;
                cert.Provider = certProv;
                cert.Save();
                istanza.TestataCertificazioneConti.IdCertificazioneConti = cert.IdCertificazioneConti;
                cert.IstanzaCertificazioneConti = istanza.Serialize();

                cert.Save();
                ShowMessage("Certificazione creata con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void HiddenFields_Valorizza()
        {
            int idConto;

            if (int.TryParse(hdnIdConto.Value, out idConto))
            {
                contiSel = conti_provider.GetById(idConto);
                hdnPeriodoContabile.Value = IstanzaCertificazioneConti.Deserialize(contiSel.IstanzaCertificazioneConti).TestataCertificazioneConti.PeriodoContabile;
            }
        }

        private void HiddenFields_Pulisci()
        {
            hdnIdConto.Value = null;
            hdnPeriodoContabile.Value = null;
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

        protected void btnPost_Click(object sender, EventArgs e)
        {

        }

        #region

        protected void btnCalcolaAppendice1_Click(object sender, EventArgs e)
        {
        }
        protected void btnCalcolaAppendice2_Click(object sender, EventArgs e)
        {
        }
        protected void btnCalcolaAppendice3_Click(object sender, EventArgs e)
        {
        }
        protected void btnCalcolaAppendice4_Click(object sender, EventArgs e)
        {
        }
        protected void btnCalcolaAppendice5_Click(object sender, EventArgs e)
        {
        }
        protected void btnCalcolaAppendice6_Click(object sender, EventArgs e)
        {
        }

        protected void btnCalcolaAppendice7_Click(object sender, EventArgs e)
        {
        }

        protected void btnCalcolaAppendice8_Click(object sender, EventArgs e)
        {
        }

        #endregion


        #region salvataggi

        protected void btnSalvaAppendice1_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice1Type rec in istanza.TabellaAppendice1.RecordAppendice1)
                {
                    rec.ImportoTotaleSpesaPubblicaErogataBeneficiari = Convert.ToDecimal(Request.Form["A1ImportoTotaleSpesaPubblicaErogataBeneficiari" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpesaPubblica = Convert.ToDecimal(Request.Form["A1ImportoTotaleSpesaPubblica" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpeseAdCToCommissione = Convert.ToDecimal(Request.Form["A1ImportoTotaleSpeseAdCToCommissione" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpeseAdCToCommissioneAdA = Convert.ToDecimal(Request.Form["A1ImportoTotaleSpeseAdCToCommissioneAdA" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpesaPubblicaAdA = Convert.ToDecimal(Request.Form["A1ImportoTotaleSpesaPubblicaAdA" + rec.IdAsse.ToString() + "_text"]);
                }
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            
        }

        protected void btnSalvaAppendice2_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice2Type rec in istanza.TabellaAppendice2.RecordAppendice2)
                {
                    rec.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(Request.Form["A2ImportoSpesaPubblicaCorrispondenteRecuperi" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(Request.Form["A2ImportoSpesaPubblicaCorrispondenteRitiri" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(Request.Form["A2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(Request.Form["A2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" + rec.IdAsse.ToString() + "_text"]);
                }

                foreach(RecordDettaglioAppendice2Type rec in istanza.TabellaDettaglioAppendice2.RecordDettaglioAppendice2)
                {
                    rec.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(Request.Form["AD2ImportoSpesaPubblicaCorrispondenteRecuperi" + rec.IdRecord.ToString() + "_text"]);
                    rec.ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(Request.Form["AD2ImportoSpesaPubblicaCorrispondenteRitiri" + rec.IdRecord.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(Request.Form["AD2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi" + rec.IdRecord.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(Request.Form["AD2ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri" + rec.IdRecord.ToString() + "_text"]);
                }
            
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice3_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice3Type rec in istanza.TabellaAppendice3.RecordAppendice3)
                {
                    rec.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(Request.Form["A3ImportoSpesaPubblicaCorrispondente" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(Request.Form["A3ImportoTotaleAmmissibileSpese" + rec.IdAsse.ToString() + "_text"]);
                }

                foreach (RecordDettaglioAppendice3Type rec in istanza.TabellaDettaglioAppendice3.RecordDettaglioAppendice3)
                {
                    rec.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(Request.Form["AD3ImportoSpesaPubblicaCorrispondente" + rec.IdRecord.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(Request.Form["AD3ImportoTotaleAmmissibileSpese" + rec.IdRecord.ToString() + "_text"]);
                }

                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice4_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice4Type rec in istanza.TabellaAppendice4.RecordAppendice4)
                {
                    rec.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(Request.Form["A4ImportoSpesaPubblicaCorrispondenteRecuperi" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseRecuperi = Convert.ToDecimal(Request.Form["A4ImportoTotaleAmmissibileSpeseRecuperi" + rec.IdAsse.ToString() + "_text"]);
                }

                foreach (RecordDettaglioAppendice4Type rec in istanza.TabellaDettaglioAppendice4.RecordDettaglioAppendice4)
                {
                    rec.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(Request.Form["AD4ImportoSpesaPubblicaCorrispondente" + rec.IdRecord.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(Request.Form["AD4ImportoTotaleAmmissibileSpese" + rec.IdRecord.ToString() + "_text"]);
                }

                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice5_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice5Type rec in istanza.TabellaAppendice5.RecordAppendice5)
                {
                    rec.ImportoSpesaPubblicaCorrispondenteIrrecuperabili = Convert.ToDecimal(Request.Form["A5ImportoSpesaPubblicaCorrispondenteIrrecuperabili" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleAmmissibileSpeseIrrecuperabili = Convert.ToDecimal(Request.Form["A5ImportoTotaleAmmissibileSpeseIrrecuperabili" + rec.IdAsse.ToString() + "_text"]);
                    rec.Osservazioni = Request.Form["A5Osservazioni" + rec.IdAsse.ToString() + "_text"];
                }
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice6_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice6Type rec in istanza.TabellaAppendice6.RecordAppendice6)
                {
                    rec.ImportoErogatoContributiStrumentiFinanziari = Convert.ToDecimal(Request.Form["A6ImportoErogatoContributiStrumentiFinanziari" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(Request.Form["A6ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoErogatoSpesaStrumentiFinanziari= Convert.ToDecimal(Request.Form["A6ImportoErogatoSpesaStrumentiFinanziari" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(Request.Form["A6ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente" + rec.IdAsse.ToString() + "_text"]);
                }
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice7_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice7Type rec in istanza.TabellaAppendice7.RecordAppendice7)
                {
                    rec.ImportoComplessivoVersatoAnticipi = Convert.ToDecimal(Request.Form["A7ImportoComplessivoVersatoAnticipi" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoCopertoAnticipiEntro = Convert.ToDecimal(Request.Form["A7ImportoCopertoAnticipiEntro" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoNonCopertoAnticipiEntro = Convert.ToDecimal(Request.Form["A7ImportoNonCopertoAnticipiEntro" + rec.IdAsse.ToString() + "_text"]);
                }
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaAppendice8_Click(object sender, EventArgs e)
        {
            try
            {
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                foreach (RecordAppendice8Type rec in istanza.TabellaAppendice8.RecordAppendice8)
                {
                    rec.DifferenzaSpesaAmmissibile = Convert.ToDecimal(Request.Form["A8DifferenzaSpesaAmmissibile" + rec.IdAsse.ToString() + "_text"]);
                    rec.DifferenzaSpesaPubblicaAdC = Convert.ToDecimal(Request.Form["A8DifferenzaSpesaPubblicaAdC" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpesaPubblica = Convert.ToDecimal(Request.Form["A8ImportoTotaleSpesaPubblica" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpesaPubblicaAdC = Convert.ToDecimal(Request.Form["A8ImportoTotaleSpesaPubblicaAdC" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpeseAmmissibiliAdC = Convert.ToDecimal(Request.Form["A8ImportoTotaleSpeseAmmissibiliAdC" + rec.IdAsse.ToString() + "_text"]);
                    rec.ImportoTotaleSpeseAmmissibiliBeneficiari = Convert.ToDecimal(Request.Form["A8ImportoTotaleSpeseAmmissibiliBeneficiari" + rec.IdAsse.ToString() + "_text"]);
                    rec.DifferenzaSpesaAmmissibileAdA = Convert.ToDecimal(Request.Form["A8DifferenzaSpesaAmmissibileAdA" + rec.IdAsse.ToString() + "_text"]);
                    rec.DifferenzaSpesaPubblicaAdCAdA = Convert.ToDecimal(Request.Form["A8DifferenzaSpesaPubblicaAdCAdA" + rec.IdAsse.ToString() + "_text"]);
                    rec.Osservazioni = Request.Form["A8Osservazioni" + rec.IdAsse.ToString() + "_text"];
                }
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaIntestazione_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? data_cert = null; 
                if (!string.IsNullOrEmpty(txtDataCertificazione.Text))
                {
                    data_cert = DateTime.Parse(txtDataCertificazione.Text);
                }
                    
                var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
                var xmlCert = cert.IstanzaCertificazioneConti;
                var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
                istanza.TestataCertificazioneConti.DataPresentazioneConti = data_cert;
                cert.IstanzaCertificazioneConti = istanza.Serialize();
                cert.DataPresentazioneConti = data_cert;
                cert.CfOperatore = this.Operatore.Utente.CfUtente;
                cert.Provider = conti_provider;
                cert.Save();
                contiSel = cert;
                VisualizzaDettaglio();
                ShowMessage("Salvataggio avvenuto con successo");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaDefinitivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDataCertificazione.Text))
            {
                ShowError("La data di presentazione dei Conti è obbligatoria per la conferma");
                return;
            }

            var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
            var xmlCert = cert.IstanzaCertificazioneConti;
            var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
            cert.FlagDefinitivo = true;
            cert.DataPresentazioneConti = txtDataCertificazione.Text;
            istanza.TestataCertificazioneConti.FlagDefinitivo = true;
            istanza.TestataCertificazioneConti.DataPresentazioneConti = DateTime.Parse(txtDataCertificazione.Text);
            xmlCert = istanza.Serialize();
            cert.IstanzaCertificazioneConti = xmlCert;
            cert.CfOperatore = this.Operatore.Utente.CfUtente;
            cert.Provider = conti_provider;
            cert.Save();
            contiSel = cert;

            string messaggio = "Certificazione confermata con successo";
            try
            {
                string codPsr = "POR20142020";
                HashAlgorithm alg = HashAlgorithm.Create("SHA256");
                var conti_calcolata_provider = new CertificazioneContiCalcolataCollectionProvider();
                var conti_calcolata = new CertificazioneContiCalcolata();

                conti_calcolata.IdCertificazioneConti = cert.IdCertificazioneConti;
                conti_calcolata.CfOperatoreInserimento = conti_calcolata.CfOperatoreModifica = Operatore.Utente.CfUtente;
                conti_calcolata.DataInserimento = conti_calcolata.DataModifica = DateTime.Now;

                conti_calcolata.IstanzaCertificazioneConti = xmlCert;
                byte[] fileHashValue = alg.ComputeHash(Encoding.Unicode.GetBytes(xmlCert));
                string hash_code = BinaryToHex(fileHashValue);
                conti_calcolata.HashCodeIstanzaCertificazioneConti = hash_code;

                conti_calcolata.IstanzaCertificazioneContiCalcolata = conti_provider.GeneraIstanzaCalcolata(codPsr, cert);
                byte[] fileHashValue_calc = alg.ComputeHash(Encoding.Unicode.GetBytes(conti_calcolata.IstanzaCertificazioneContiCalcolata));
                string hash_code_calc = BinaryToHex(fileHashValue_calc);
                conti_calcolata.HashCodeIstanzaCertificazioneContiCalcolata = hash_code_calc;

                conti_calcolata.Differenti = conti_calcolata.HashCodeIstanzaCertificazioneConti != conti_calcolata.HashCodeIstanzaCertificazioneContiCalcolata;

                conti_calcolata_provider.Save(conti_calcolata);
                rendiDefinitiveDecertificazioni(cert.IdCertificazioneConti);
            }
            catch(Exception ex)
            {
                messaggio += ", ma è stato rilevato il seguente errore nella creazione dello storico: " + ex.Message;
            }
            finally
            {
                VisualizzaDettaglio();
                HiddenFields_Pulisci();
                ShowMessage(messaggio);
            }
        }

        protected void btnEliminaCertificazione_Click(object sender, EventArgs e)
        {
            var cert = conti_provider.GetById(contiSel.IdCertificazioneConti);
            cert.Provider = conti_provider;
            cert.Delete();
            eliminaDecertificazioni(contiSel.IdCertificazioneConti);
            contiSel = null;
            VisualizzaDettaglio();
            HiddenFields_Pulisci();
            ShowMessage("Certificazione eliminata con successo");
        }

        private void eliminaDecertificazioni(int idCertConti)
        {
            CertDecertificazioneCollection certDecertificazioneCollection = certDecertificazioneCollectionProvider.Find(null, null, null, null, null, null, idCertConti, null, null, null, null, null);
            if (certDecertificazioneCollection.Count != 0)
            {
                foreach (CertDecertificazione decert in certDecertificazioneCollection)
                {
                    decert.Assegnata = 0;
                    decert.Definitiva = 0;
                    decert.IdCertificazioneConti = null;
                }
                certDecertificazioneCollectionProvider.SaveCollection(certDecertificazioneCollection);
            }
        }

        #endregion
    }
}
