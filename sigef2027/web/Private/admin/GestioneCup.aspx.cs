using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SiarLibrary.Extensions;
using web.CONTROLS;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace web.Private.admin
{
    public partial class GestioneCup : SiarLibrary.Web.PrivatePage
    {

        SiarLibrary.DatiMonitoraggioFESR m_MonFESRclss = null;
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "gestione-cup";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Form.DefaultButton = btnCerca.UniqueID;
            Form.DefaultFocus = txtNumDomanda.ClientID;
            cmbTemaPrior.DataBind();
            cmbAttivitaEcon.DataBind();
            cmbCPTSettore.DataBind();
            cmbCUPDimensioneTerr.DataBind();
            ucCmbTipoOper.DataBind();
            ucSiarNewTab.Visible = false;
            int id_progetto;
            if (int.TryParse(txtNumDomanda.Text, out id_progetto))
            {
                SiarBLL.ProgettoCollectionProvider progProvider = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.Progetto p = null;
                try
                {
                    p = progProvider.GetById(id_progetto);
                    if (p != null && p.IdProgIntegrato != null && p.IdProgIntegrato != p.IdProgetto)
                        p = progProvider.GetById(p.IdProgIntegrato);
                    if (p == null || p.FlagPreadesione) throw new Exception("Nessuna domanda trovata. Il codice inserito potrebbe essere errato.");
                    string idbando = p.IdBando;

                    if (Operatore.Utente.CodTipoEnte.FindValueIn("RM", "%", "AdC"))
                    {
                        switch (ucSiarNewTab.TabSelected)
                        {
                            case 1:
                                break;

                            case 2:
                                int iCombochanged;
                                if (!int.TryParse(hdnSaveDatiMonitoraggio.Value, out iCombochanged))
                                    CaricaDatiMonitoraggio(p);
                                break;

                            case 3:
                                int id_localizzazione;
                                if (int.TryParse(hdnIdLocalizzazioneSelezionata.Value, out id_localizzazione))
                                {
                                    isUpdating = true;
                                    localizzazione_selezionata = localizzazioneProvider.GetById(id_localizzazione);
                                }
                                break;

                            case 4:
                                ucImpresaControl.AbilitaModifica = AbilitaModifica;
                                ucImpresaControl.Impresa = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
                                ucImpresaControl.Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(p.IdProgetto);
                                ucImpresaControl.AnagrafeEdit = true;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex); Session.Remove("_progetto");
                    tdDomanda.InnerHtml = "<div class=testo_pagina><b>" + ex.Message + "</b></div>";
                }
            }
        }
        SiarLibrary.LocalizzazioneProgetto localizzazione_selezionata;
        SiarBLL.LocalizzazioneProgettoCollectionProvider localizzazioneProvider = new SiarBLL.LocalizzazioneProgettoCollectionProvider();
        public bool isUpdating = false;
        protected override void OnPreRender(EventArgs e)
        {
            int id_progetto;
            //tdDomanda.InnerHtml = "<div class=testo_pagina><b>Ricercare una domanda.</b></div>";

            if (int.TryParse(txtNumDomanda.Text, out id_progetto))
            {
                SiarBLL.ProgettoCollectionProvider progProvider = new SiarBLL.ProgettoCollectionProvider();
                SiarLibrary.Progetto p = null;
                try
                {
                    p = progProvider.GetById(id_progetto);
                    if (p != null && p.IdProgIntegrato != null && p.IdProgIntegrato != p.IdProgetto)
                        p = progProvider.GetById(p.IdProgIntegrato);
                    if (p == null || p.FlagPreadesione) throw new Exception("Nessuna domanda trovata. Il codice inserito potrebbe essere errato.");
                    string idbando = p.IdBando;
                    ucSiarNewTab.Visible = true;
                    if (!string.IsNullOrEmpty(p.CodAgea))
                    {
                        txtCodAgea.Text = p.CodAgea;
                        btnSalvaCUP.Enabled = false;
                        btnSalvaLocalizzazione.Enabled = false;
                        btnSalvaMonitoraggio.Enabled = false;
                        btnElimina.Enabled = false;
                    }
                    else
                    {
                        txtCodAgea.Text = "";
                    }
                        int id_localizzazione;
                    if (int.TryParse(hdnIdLocalizzazioneSelezionata.Value, out id_localizzazione))
                    {
                        isUpdating = true;
                        localizzazione_selezionata = localizzazioneProvider.GetById(id_localizzazione);
                    }
                    // controllo i permessi dell'operatore
                    int risultato = SiarLibrary.DbStaticProvider.GetPermessiOperatoreSuProgetto(p.IdProgetto, Operatore.Utente.IdUtente,
                        progProvider.DbProviderObj);
                    if (risultato == 0) throw new Exception("Nessuna domanda trovata. Il codice inserito potrebbe essere errato.");

                    AbilitaModifica = (risultato == 2);
                    //if (p.Segnatura == null && risultato == 1) ShowError("L'utente è abilitato alla sola visualizzazione della domanda.");
                    SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(p.IdBando);

                    Control c = LoadControl("../../CONTROLS/DatiDomanda.ascx");
                    System.Type t = c.GetType();
                    tdDomanda.InnerHtml = "<div></div>";
                    t.GetProperty("Progetto").SetValue(c, p, null);
                    t.GetProperty("Bando").SetValue(c, b, null);
                    tdDomanda.Controls.Add(c);
                    Session["_progetto"] = p;
                    Session["_bando"] = b;
                    // per controllare gli allegati devo prendere la segnatura della firma di presentazione
                    SiarLibrary.ProgettoStoricoCollection psc = new SiarBLL.ProgettoStoricoCollectionProvider().Find(p.IdProgetto, "L", null);

                    bool allegatiProtocollatiOk = true;

                    if (psc.Count > 0)
                    {
                        SiarLibrary.ProgettoStorico s = psc[0];
                        //SiarLibrary.AllegatiProtocollatiCollection allegati = new SiarBLL.AllegatiProtocollatiCollectionProvider().Find(p.IdProgetto, null, null, null, null, null, null, null);
                        //int numeroAllegati = allegati.Count;
                        //allegatiProtocollatiOk = checkAllegatiProtocollati(s, numeroAllegati);
                        allegatiProtocollatiOk = new SiarBLL.AllegatiProtocollatiCollectionProvider().CheckAllegatiProtocollati(SiarBLL.AllegatiProtocollatiCollectionProvider.TipoCheck.Progetto, p.IdProgetto, s.Segnatura);
                    }

                    if (Operatore.Utente.CodTipoEnte.FindValueIn("RM", "%", "AdC"))
                    {
                        if (IsPostBack)
                        {
                            tabCUP.Visible = true;
                            tabMonitoraggioFesr.Visible = false;
                            tabLocalizzazioneInterventi.Visible = false;
                            switch (ucSiarNewTab.TabSelected)
                            {
                                case 1:
                                    tabCUP.Visible = true;
                                    tabMonitoraggioFesr.Visible = false;
                                    tabLocalizzazioneInterventi.Visible = false;
                                    tabDatiAnagraficiImpresa.Style["display"] = "none";
                                    break;

                                case 2:
                                    tabCUP.Visible = false;
                                    tabMonitoraggioFesr.Visible = true;
                                    tabLocalizzazioneInterventi.Visible = false;
                                    //tabDatiAnagraficiImpresa.Visible = false;
                                    tabDatiAnagraficiImpresa.Style["display"] = "none";
                                    break;

                                case 3:
                                    tabCUP.Visible = false;
                                    tabMonitoraggioFesr.Visible = false;
                                    tabLocalizzazioneInterventi.Visible = true;
                                    tabDatiAnagraficiImpresa.Style["display"] = "none";

                                    SiarLibrary.LocalizzazioneProgettoCollection localizzazioni = localizzazioneProvider.Find(null, p.IdProgetto, null, null);
                                    dgLocalizzazioni.ItemDataBound += new DataGridItemEventHandler(dgLocalizzazioni_ItemDataBound);
                                    dgLocalizzazioni.DataSource = localizzazioni;
                                    dgLocalizzazioni.Titolo = "<br /><br /><em>Elementi trovati: " + localizzazioni.Count.ToString() + "</em>";
                                    dgLocalizzazioni.DataBind();


                                    SiarLibrary.Comuni currComune = null;
                                    if (localizzazione_selezionata != null && isUpdating)
                                    {

                                        ucIndirizzo.Progetto = p;
                                        if (localizzazione_selezionata.IdComune != null && localizzazione_selezionata.IdComune > 0)
                                        {
                                            currComune = new SiarBLL.ComuniCollectionProvider().GetById(localizzazione_selezionata.IdComune);

                                        }
                                        ucIndirizzo.loadLocalizzazione(localizzazione_selezionata, currComune);
                                        RicercaImpresa.IdImpresa = localizzazione_selezionata.IdImpresa;
                                    }
                                    break;

                                case 4:
                                    tabCUP.Visible = false;
                                    tabMonitoraggioFesr.Visible = false;
                                    tabLocalizzazioneInterventi.Visible = false;
                                    tabDatiAnagraficiImpresa.Style["display"] = "";
                                    break;
                            }
                        }
                     }
                 }
                catch (Exception ex)
                {
                    ShowError(ex); Session.Remove("_progetto");
                    tdDomanda.InnerHtml = "<div class=testo_pagina><b>" + ex.Message + "</b></div>";
                }
            }
            base.OnPreRender(e);
        }
        void dgLocalizzazioni_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.LocalizzazioneProgetto lp = (SiarLibrary.LocalizzazioneProgetto)e.Item.DataItem;
                SiarBLL.ImpresaCollectionProvider impresaProvider = new SiarBLL.ImpresaCollectionProvider();
                e.Item.Cells[1].Text = impresaProvider.GetById(lp.IdImpresa).RagioneSociale;

                SiarBLL.ComuniCollectionProvider comuniProvider = new SiarBLL.ComuniCollectionProvider();
                e.Item.Cells[2].Text = comuniProvider.GetById(lp.IdComune).Denominazione;
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e) {

            //senza impostare TabSelected = 1 potrebbe comparir il messaggio relativo a  campi obbligatorio (vedi campi obbligatori  dati monitoraggio).
            ucSiarNewTab.TabSelected = 1;


        }

        protected void btnSalvaCUP_Click(object sender, EventArgs e)
        {
            int id_progetto;
            try
            {
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);


                if (int.TryParse(txtNumDomanda.Text, out id_progetto))
                {
                    SiarBLL.ProgettoCollectionProvider progProvider = new SiarBLL.ProgettoCollectionProvider();
                    SiarLibrary.Progetto p = null;
                    {
                        p = progProvider.GetById(id_progetto);
                        if (p != null && p.IdProgIntegrato != null && p.IdProgIntegrato != p.IdProgetto)
                            p = progProvider.GetById(p.IdProgIntegrato);
                        p.CodAgea = txtCodAgea.Text;
                        p.Save();
                        ShowMessage("Codice CUP salvato correttamente.");
                    }
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }
        protected void btnNuovo_Click(object sender, EventArgs e)
        {
            PulisciCampi();
        }

        public void btnSelezionaLocalizzazione_Click(object sender, EventArgs e)
        {

        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)(Session["_progetto"]);
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (localizzazione_selezionata == null || localizzazione_selezionata.IdProgetto != p.IdProgetto) throw new Exception("Nessuna localizzazione selezionata, impossibile eliminare.");
                localizzazioneProvider.Delete(localizzazione_selezionata);
                ShowMessage("Localizzazione eliminata correttamente.");
                RegisterClientScriptBlock("pulisciCampi();");
                PulisciCampi();
            }
            catch (Exception ex) { ShowError(ex); }
        }
        private void PulisciCampi()
        {
            RicercaImpresa.IdImpresa = null;
            ucIndirizzo.clearForm();
            hdnIdLocalizzazioneSelezionata.Value = string.Empty;
        }
        public void btnSalvaLocalizzazione_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.Progetto p = (SiarLibrary.Progetto)(Session["_progetto"]);
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);

                if (localizzazione_selezionata == null)
                {
                    localizzazione_selezionata = new SiarLibrary.LocalizzazioneProgetto();
                    localizzazione_selezionata.IdProgetto = p.IdProgetto;
                }

                if (string.IsNullOrEmpty(ucIndirizzo.inputComuneId) || string.IsNullOrEmpty(ucIndirizzo.inputCAP) || ucIndirizzo.inputDUG == 0 || string.IsNullOrEmpty(ucIndirizzo.inputVia) || string.IsNullOrEmpty(ucIndirizzo.inputNum))
                    throw new Exception("Inserire tutti i valori della localizzazione.");

                if (RicercaImpresa.IdImpresa != null)
                    localizzazione_selezionata.IdImpresa = RicercaImpresa.IdImpresa;
                else
                    localizzazione_selezionata.IdImpresa = p.IdImpresa;
                localizzazione_selezionata.IdComune = ucIndirizzo.inputComuneId;
                localizzazione_selezionata.Cap = ucIndirizzo.inputCAP;
                if (ucIndirizzo.inputDUG > 0) localizzazione_selezionata.Dug = ucIndirizzo.inputDUG.ToString();
                else localizzazione_selezionata.Dug = null;
                localizzazione_selezionata.Via = ucIndirizzo.inputVia;
                localizzazione_selezionata.Num = ucIndirizzo.inputNum;
                SiarBLL.LocalizzazioneProgettoCollectionProvider dbProvider = new SiarBLL.LocalizzazioneProgettoCollectionProvider();
                dbProvider.Save(localizzazione_selezionata);
                ShowMessage("Localizzazione salvata correttamente.");
            }
            catch (Exception ex) { ShowError(ex); }

        }

        protected void btnSalvaMonitoraggio_Click(object sender, EventArgs e)
        {
            try
            {

                SiarLibrary.Progetto p = (SiarLibrary.Progetto)(Session["_progetto"]);
                SiarLibrary.DatiMonitoraggioFESRCollection monitColl = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Select(null, p.IdProgetto);
                if (monitColl.Count > 0)
                    m_MonFESRclss = monitColl[0];

                m_MonFESRclss.IdCUPCategoria = ucCUPCategoria.IdCategoriaSelezionato;
                m_MonFESRclss.IdCUPCategoriaSoggetto = ucCUPCategoriaSoggetto.IdCategoriaSelezionato;
                if (!String.IsNullOrEmpty(selAteco2007.IdAteco2007Selezionato))
                    m_MonFESRclss.IdAteco2007 = selAteco2007.IdAteco2007Selezionato;
                else
                    throw new Exception("Inserire un Codice Ateco valido.");
                m_MonFESRclss.IdTemaPrioritario = cmbTemaPrior.SelectedValue;
                m_MonFESRclss.IdAttivitaEcon = cmbAttivitaEcon.SelectedValue;
                m_MonFESRclss.IdCPTSettore = cmbCPTSettore.SelectedValue;
                m_MonFESRclss.IdDimensioneTerr = cmbCUPDimensioneTerr.SelectedValue;
                //m_MonFESRclss = cmbCUPNatura.SelectedValue;
                if (string.IsNullOrEmpty(ucCmbTipoOper.SelectedValue))
                {
                    m_MonFESRclss.IdCUPNatura = "";
                }
                else
                {
                    m_MonFESRclss.IdCUPNatura = ucCmbTipoOper.SelectedValue.Substring(0, 2);
                }
                m_MonFESRclss.IdCUPCategoriaTipoOperazione = ucCmbTipoOper.SelectedValue;
                new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Save(m_MonFESRclss);

                ShowMessage("Dati di Monitoraggio salvati correttamente.");

            }
            catch (Exception ex) { ShowError(ex); }
        }
        private void CaricaDatiMonitoraggio(SiarLibrary.Progetto p)
        {
            SiarLibrary.DatiMonitoraggioFESRCollection monitColl = new SiarBLL.DatiMonitoraggioFESRCollectionProvider().Select(null, p.IdProgetto);
            if (monitColl.Count > 0)
                m_MonFESRclss = monitColl[0];

            //-----------
            SiarLibrary.CUPCategoria CUPCategClss = null;
            SiarLibrary.CUPCategoriaSoggetto CUPCategSoggClss = null;
            SiarLibrary.Ateco2007 AtecoClss = null;
            if (m_MonFESRclss != null)
            {
                if (m_MonFESRclss.IdCUPCategoria != null && m_MonFESRclss.IdCUPCategoria != "")
                {
                    CUPCategClss = new SiarBLL.CUPCategoriaCollectionProvider().GetById(m_MonFESRclss.IdCUPCategoria);
                    if (CUPCategClss != null)
                        ucCUPCategoria.CUPCategoriaCurrent = CUPCategClss;
                }
                if (m_MonFESRclss.IdCUPCategoriaSoggetto != null && m_MonFESRclss.IdCUPCategoriaSoggetto != "")
                {
                    CUPCategSoggClss = new SiarBLL.CUPCategoriaSoggettoCollectionProvider().GetById(m_MonFESRclss.IdCUPCategoriaSoggetto);
                    if (CUPCategSoggClss != null)
                        ucCUPCategoriaSoggetto.CUPCategoriaCurrent = CUPCategSoggClss;
                }

                if (m_MonFESRclss.IdAteco2007 != null && m_MonFESRclss.IdAteco2007 != "")
                {
                    AtecoClss = new SiarBLL.Ateco2007CollectionProvider().GetById(m_MonFESRclss.IdAteco2007);
                    if (AtecoClss != null)
                        selAteco2007.AtecoCurrent = AtecoClss;

                }


                if (m_MonFESRclss.IdTemaPrioritario != null && m_MonFESRclss.IdTemaPrioritario != "")
                    cmbTemaPrior.SelectedValue = m_MonFESRclss.IdTemaPrioritario;
                if (m_MonFESRclss.IdAttivitaEcon != null && m_MonFESRclss.IdAttivitaEcon != "")
                    cmbAttivitaEcon.SelectedValue = m_MonFESRclss.IdAttivitaEcon;
                if (m_MonFESRclss.IdCPTSettore != null && m_MonFESRclss.IdCPTSettore != "")
                    cmbCPTSettore.SelectedValue = m_MonFESRclss.IdCPTSettore;
                if (m_MonFESRclss.IdDimensioneTerr != null && m_MonFESRclss.IdDimensioneTerr != "")
                    cmbCUPDimensioneTerr.SelectedValue = m_MonFESRclss.IdDimensioneTerr;
                //if (m_MonFESRclss.IdCUPNatura != null && m_MonFESRclss.IdCUPNatura != "")
                //    cmbCUPNatura.SelectedValue = m_MonFESRclss.IdCUPNatura;
                if (m_MonFESRclss.IdCUPCategoriaTipoOperazione != null && m_MonFESRclss.IdCUPCategoriaTipoOperazione != "")
                    ucCmbTipoOper.SelectedValue = m_MonFESRclss.IdCUPCategoriaTipoOperazione;


            }
            else
            {
                //cerco codice ateco su anagrafica impresa
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(p.IdImpresa);
                if (impresa != null)
                    selAteco2007.AtecoCurrent = new SiarBLL.Ateco2007CollectionProvider().GetById(impresa.CodAteco2007);

            }

        }
    }

    }
    
