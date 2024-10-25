using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.Psr.Bandi
{
    public partial class RichiesteProfilazione : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "RichiesteProfilazione";
            base.OnPreInit(e);
        }

        SiarBLL.RichiestaProfilazioneCollectionProvider richieste_prov = new SiarBLL.RichiestaProfilazioneCollectionProvider();
        SiarLibrary.RichiestaProfilazione richiesta_selezionata;

        protected void Page_Load(object sender, EventArgs e)
        {
            ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;
            int id_richiesta;
            if (int.TryParse(hdnIdRichiesta.Value, out id_richiesta))
            {
                richiesta_selezionata = richieste_prov.GetById(id_richiesta);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {

            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    divElencoRichieste.Visible = false;

                    if (richiesta_selezionata != null)
                    {
                        divRichiesta.Visible = true;
                        if (richiesta_selezionata.Definitiva)
                        {
                            if (richiesta_selezionata.Segnatura != null && richiesta_selezionata.Segnatura != "")
                            {
                                lbApprovazione.InnerText = "";
                                tbButton.Visible = false;
                                tbButtonFooter.Visible = false;
                                tbsegnatura.Visible = true;
                                btnSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + richiesta_selezionata.Segnatura.ToString() + "');");
                                txtSegnatura.Text = richiesta_selezionata.Segnatura;
                            }
                            else
                            {
                                if (richiesta_selezionata.Approvata == true)
                                {
                                    lbApprovazione.InnerText = "La domanda è stata approvata, procedere con l'invio al protocollo";
                                    btnInviaProtocollo.Enabled = true;
                                    btnSalva.Enabled = false;
                                    btnSalvaInvia.Enabled = false;
                                    btnElimina.Enabled = false;
                                    Button1.Enabled = false;
                                    Button2.Enabled = false;
                                    Button3.Enabled = false;
                                    tbsegnatura.Visible = false;
                                }
                                else
                                {

                                    tbButton.Visible = false;
                                    tbButtonFooter.Visible = false;
                                    tbsegnatura.Visible = false;
                                    if (richiesta_selezionata.Approvata == false)
                                    {
                                        lbApprovazione.InnerText = "La richiesta NON è stata APPROVATA";
                                        if (richiesta_selezionata.FondiFesr)
                                            lbApprovazione.InnerText += " dall'Autorità di Gestione";
                                        else
                                            lbApprovazione.InnerText += " dalla PF Informatica e Crescita Digitale";
                                        lbApprovazione.InnerText += " con motivazione: " + richiesta_selezionata.MotivazioneRifiuto;
                                    }
                                    else
                                    {
                                        if(richiesta_selezionata.FondiFesr)
                                            lbApprovazione.InnerText = "In attesa dell'approvazione da parte dell'Autorità di Gestione";
                                        else
                                            lbApprovazione.InnerText = "In attesa dell'approvazione da parte della PF Informatica e Crescita Digitale";
                                    }
                                }
                            }
                        }
                        popolaRichiesta();
                    }

                    break;

                default:
                    divRichiesta.Visible = false;
                    int? id_operatore = null;
                    if (Operatore.Utente.Profilo != "Amministratore")
                        id_operatore = Operatore.Utente.IdUtente;

                    //Inviate e approvate
                    SiarLibrary.RichiestaProfilazioneCollection richieste_inviate = richieste_prov.FindDomandeApprovateEInviate(id_operatore);
                    dgRichiesteInviate.DataSource = richieste_inviate;
                    dgRichiesteInviate.SetTitoloNrElementi();
                    //dgRichiesteInviate.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRichiesteInviate_ItemDataBound);
                    dgRichiesteInviate.DataBind();
                    if (richieste_inviate.Count == 0)
                        divRichiesteInviate.Visible = false;

                    //non inviate
                    SiarLibrary.RichiestaProfilazioneCollection richieste_non_inviate = richieste_prov.Find(id_operatore, false, null);
                    dgRichiesteIncomplete.DataSource = richieste_non_inviate;
                    dgRichiesteIncomplete.SetTitoloNrElementi();
                    //dgRichiesteIncomplete.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRichiesteIncomplete_ItemDataBound);
                    dgRichiesteIncomplete.DataBind();
                    if (richieste_non_inviate.Count == 0)
                        divRichiesteIncomplete.Visible = false;

                    //In attesa di approvazione
                    SiarLibrary.RichiestaProfilazioneCollection richieste_inviate_da_Aprrovare = richieste_prov.FindDomandeDaApprovare(id_operatore);
                    dgRichiesteInviateDaApprovare.DataSource = richieste_inviate_da_Aprrovare;
                    dgRichiesteInviateDaApprovare.SetTitoloNrElementi();
                    //dgRichiesteIncomplete.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRichiesteIncomplete_ItemDataBound);
                    dgRichiesteInviateDaApprovare.DataBind();
                    if (richieste_inviate_da_Aprrovare.Count == 0)
                        divRichiesteInviateDaApprovare.Visible = false;

                    //Approvate da inviare 
                    SiarLibrary.RichiestaProfilazioneCollection richieste_Aprrovate_da_inviare = richieste_prov.FindDomandeApprovateDaInviare(id_operatore);
                    dgRichiesteApprovateDaInviare.DataSource = richieste_Aprrovate_da_inviare;
                    dgRichiesteApprovateDaInviare.SetTitoloNrElementi();
                    //dgRichiesteIncomplete.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRichiesteIncomplete_ItemDataBound);
                    dgRichiesteApprovateDaInviare.DataBind();
                    if (richieste_Aprrovate_da_inviare.Count == 0)
                        divRichiesteApprovateDaInviare.Visible = false;

                    //riiutate
                    SiarLibrary.RichiestaProfilazioneCollection richieste_rifiutate = richieste_prov.Find(id_operatore, true, false);
                    dgRichiesteRifiutate.DataSource = richieste_rifiutate;
                    dgRichiesteRifiutate.SetTitoloNrElementi();
                    //dgRichiesteIncomplete.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgRichiesteIncomplete_ItemDataBound);
                    dgRichiesteRifiutate.DataBind();
                    if (richieste_rifiutate.Count == 0)
                        divRichiesteRifiutate.Visible = false;

                    //Approvate e rifiutate come Adg
                    SiarLibrary.RichiestaProfilazioneCollection richieste_adg = richieste_prov.FindDomandeAdg(id_operatore);
                    dgRichiesteAdg.DataSource = richieste_adg;
                    dgRichiesteAdg.SetTitoloNrElementi();
                    dgRichiesteAdg.ItemDataBound += new DataGridItemEventHandler(dgRichiesteAdg_ItemDataBound);
                    dgRichiesteAdg.DataBind();
                    if (richieste_adg.Count == 0)
                        divRichiesteAdg.Visible = false;

                    break;

            }
            base.OnPreRender(e);
        }

        void dgRichiesteAdg_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.RichiestaProfilazione r = (SiarLibrary.RichiestaProfilazione)dgi.DataItem;
                if (r.Approvata)
                    dgi.Cells[5].Text = "APPROVATA";
                else
                    dgi.Cells[5].Text = "RIFIUTATA";
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            
        }

        public void popolaRichiesta()
        {
            int id_utente = richiesta_selezionata.Operatore;
            SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(id_utente);
            txtOperatore.Text = u.Nominativo;
            if(richiesta_selezionata.Servizio != "")
                txtServizio.Text = richiesta_selezionata.Servizio;
            if (richiesta_selezionata.Pf != "")
                txtPF.Text = richiesta_selezionata.Pf;
            if (richiesta_selezionata.Pec != "")
                txtPec.Text = richiesta_selezionata.Pec;
            if (richiesta_selezionata.FondiFesr == true || richiesta_selezionata.FondiFesr == null)
            {
                ddlTipoFondi.SelectedValue = "1"; 
                btnSalvaInvia.Text = "Invia all'approvazione AdG";
            }
            else
            {
                ddlTipoFondi.SelectedValue = "0";
                btnSalvaInvia.Text = "Invia all'approvazione";
            }
                

            if (richiesta_selezionata.Asse != "")
                txtAsse.Text = richiesta_selezionata.Asse;
            if (richiesta_selezionata.Azione != "")
                txtAzione.Text = richiesta_selezionata.Azione;
            if (richiesta_selezionata.ParereAdg != "")
                txtParereAdg.Text = richiesta_selezionata.ParereAdg;
            if (richiesta_selezionata.Multiazione)
                checkMultiazione.Checked = true;
            else
                checkMultiazione.Checked = false;
            if (richiesta_selezionata.Perc10)
                checkPerc10.Checked = true;
            else
                checkPerc10.Checked = false;
            if (richiesta_selezionata.Oggetto != "")
                txtOggetto.Text = richiesta_selezionata.Oggetto;
            if (richiesta_selezionata.Importo != "")
                txtImporto.Text = richiesta_selezionata.Importo;
            if (richiesta_selezionata.Rup != "")
                txtRup.Text = richiesta_selezionata.Rup;
            if (richiesta_selezionata.RupTelefono != "")
                txtRupTelefono.Text = richiesta_selezionata.RupTelefono;
            if (richiesta_selezionata.RupEmail != "")
                txtRupEmail.Text = richiesta_selezionata.RupEmail;
            if (richiesta_selezionata.DataApertura != "")
                txtDataApertura.Text = richiesta_selezionata.DataApertura;
            if (richiesta_selezionata.OraApertura != "")
                txtOraApertura.Text = richiesta_selezionata.OraApertura;
            if (richiesta_selezionata.DataChiusura != "")
                txtDataChiusura.Text = richiesta_selezionata.DataChiusura;
            if (richiesta_selezionata.OraChiusura != "")
                txtOraChiusura.Text = richiesta_selezionata.OraChiusura;
            if (richiesta_selezionata.Decreto != "")
                txtDecreto.Text = richiesta_selezionata.Decreto;
            if (richiesta_selezionata.FascicoloPaleo != "")
                txtFascicolo.Text = richiesta_selezionata.FascicoloPaleo;
            if (richiesta_selezionata.Graduatoria)
                checkGraduatoria.Checked = true;
            else
                checkGraduatoria.Checked = false;
            if (richiesta_selezionata.Sportello)
                checkSportello.Checked = true;
            else
                checkSportello.Checked = true;
            if (richiesta_selezionata.StrumentiFinanziari)
                checkStrumentiFinanz.Checked = true;
            else
                checkStrumentiFinanz.Checked = false;
            if (richiesta_selezionata.FinanziabilitaParziale)
                checkFinanzParz.Checked = true;
            else
                checkFinanzParz.Checked = false;
            if (richiesta_selezionata.TipoProcedura != "")
                txtTipoProcedura.Text = richiesta_selezionata.TipoProcedura;
            if (richiesta_selezionata.MarcaDaBollo)
                checkMarcaDaBollo.Checked = true;
            else
                checkMarcaDaBollo.Checked = false;
            if (richiesta_selezionata.TipoAggregazione != "")
                ddlTipoAggregazione.SelectedValue = richiesta_selezionata.TipoAggregazione;
            if (richiesta_selezionata.Capofila)
                checkCapofila.Checked = true;
            else
                checkCapofila.Checked = false;
            if (richiesta_selezionata.TipoBenificiario != "")
                ddlTipoBeneficiario.SelectedValue = richiesta_selezionata.TipoBenificiario;
            if (richiesta_selezionata.Ateco != "")
                txtAteco.Text = richiesta_selezionata.Ateco;
            if (richiesta_selezionata.NumeroDomande)
                checkNumeroDomande.Checked = true;
            else
                checkNumeroDomande.Checked = false;
            if (richiesta_selezionata.DeMinimis)
                checkDeMinimis.Checked = true;
            else
                checkDeMinimis.Checked = false;
            if (richiesta_selezionata.ContributoUe)
                checkContributoUe.Checked = true;
            else
                checkContributoUe.Checked = false;
            if (richiesta_selezionata.TipoPiano != "")
                txtTipoPiano.Text = richiesta_selezionata.TipoPiano;
            if (richiesta_selezionata.DataAmmissibilita != "")
                txtDataAmmissibile.Text = richiesta_selezionata.DataAmmissibilita;
            if (richiesta_selezionata.CostoMin!= "")
                txtCostoMin.Text = richiesta_selezionata.CostoMin;
            if (richiesta_selezionata.CostoMax != "")
                txtCostoMax.Text = richiesta_selezionata.CostoMax;
            if (richiesta_selezionata.Comitato)
                checkComitato.Checked = true;
            else
                checkComitato.Checked = false;
            if (richiesta_selezionata.PunteggioMin != "")
                txtPunteggioMin.Text = richiesta_selezionata.PunteggioMin;
            if (richiesta_selezionata.Allegati != "")
                txtAllegati.Text = richiesta_selezionata.Allegati;
            if (richiesta_selezionata.Dichiarazioni != "")
                txtDichiarazioni.Text = richiesta_selezionata.Dichiarazioni;
            if (richiesta_selezionata.DichiarazioniOpz != "")
                txtDichiarazioniOpz.Text = richiesta_selezionata.DichiarazioniOpz;
            if (richiesta_selezionata.CupBeni)
                checkCupBeni.Checked = true;
            else
                checkCupBeni.Checked = false;
            if (richiesta_selezionata.CupServizi)
                checkCupServizi.Checked = true;
            else
                checkCupServizi.Checked = false;
            if (richiesta_selezionata.CupLavPub)
                checkCupLavPub.Checked = true;
            else
                checkCupLavPub.Checked = false;
            if (richiesta_selezionata.CupContr)
                checkCupContr.Checked = true;
            else
                checkCupContr.Checked = false;
            if (richiesta_selezionata.CupProd)
                checkCupProd.Checked = true;
            else
                checkCupProd.Checked = false;
            if (richiesta_selezionata.CupCap )
                checkCupCap.Checked = true;
            else
                checkCupCap.Checked = false;
        }

        void dgRichiesteIncomplete_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.RichiestaProfilazione td = (SiarLibrary.RichiestaProfilazione)e.Item.DataItem;
                //SiarLibrary.Bando b = new SiarBLL.BandoCollectionProvider().GetById(td.IdBando);
                //e.Item.Cells[1].Text = b.Descrizione;
                //e.Item.Cells[2].Text = b.Stato;
                //SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(td.Operatore);
                //e.Item.Cells[3].Text = u.Nominativo;
                //e.Item.Cells[7].Text = "<Siar:Button ID='btnModifica' runat='server' Width='183px'  OnClientClick='selezionaRichiesta("+td.IdRichiesta.ToString()+")'  Text = 'Modifica' OnClick = 'btnModifica_Click' CausesValidation = 'false' ></ Siar:Button > ";
            }
        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (richiesta_selezionata == null || richiesta_selezionata.Definitiva)
                    throw new Exception("Errore nella richiesta selezionata!");
                richieste_prov.Delete(richiesta_selezionata);
                hdnIdRichiesta.Value = "";
                richiesta_selezionata = null;
                ShowMessage("Richiesta di profilazione eliminata.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SalvaDati(false);
                ShowMessage("La richiesta di profilazione è stata salvata correttamente!");
            }
            catch (Exception ex) { ShowError(ex); }
        }
        
         protected void btnInviaApprovazione_Click(object sender, EventArgs e)
        {
            try
            {
                SalvaDati(true);
                if(ddlTipoFondi.SelectedValue == "1")
                {
                    SiarLibrary.Email em = new SiarLibrary.Email("Avviso di inoltro per l'approvazione di una richiesta di profilazione SIGEF di una nuova procedura di attivazione (ID_RICHIESTA :" + richiesta_selezionata.IdRichiesta + " )",
                                    "<html><body>Si comunica che è stata inoltrata al dirigente dell'Autorità di Gestione per l'approvazione la Richiesta di Profilazione con ID_RICHIESTA  " + richiesta_selezionata.IdRichiesta
                                + " da " + Operatore.Utente.Nominativo
                                + "<br />Tale richiesta è consultabile all'indirizzo <a href='https://sigef.regione.marche.it/web/private/welcome.aspx' target=_blank>Clicca qui</a> ricercando nel cruscotto la richiesta nella 'Richieste di profilazione nuove procedure di attivazione'"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                    em.SetHtmlBodyMessage(true);
                    string[] destinatari = new string[1];
                    string[] destinatari_cc = new string[2];
                    destinatari[0] = "";
                    destinatari_cc[0] = "";
                    destinatari_cc[1] = "";
                    em.SendNotification(destinatari, destinatari_cc);

                    ShowMessage("La richiesta di profilazione è stata inoltrata all'approvazione dell'Autorita di Gestione.");
                }
                else
                {
                    SiarLibrary.Email em = new SiarLibrary.Email("Avviso di inoltro per l'approvazione di una richiesta di profilazione SIGEF di una nuova procedura di attivazione (ID_RICHIESTA :" + richiesta_selezionata.IdRichiesta + " )",
                                    "<html><body>Si comunica che è stata inoltrata al dirigente della PF Informatica e Crescita Digitale per l'approvazione la Richiesta di Profilazione con ID_RICHIESTA  " + richiesta_selezionata.IdRichiesta
                                + " da " + Operatore.Utente.Nominativo
                                + "<br />Tale richiesta è consultabile all'indirizzo <a href='https://sigef.regione.marche.it/web/private/welcome.aspx' target=_blank>Clicca qui</a> ricercando nel cruscotto la richiesta nella 'Richieste di profilazione nuove procedure di attivazione'"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                    em.SetHtmlBodyMessage(true);
                    string[] destinatari = new string[1];
                    string[] destinatari_cc = new string[1];
                    destinatari[0] = "";
                    destinatari_cc[0] = "";
                    em.SendNotification(destinatari, destinatari_cc);

                    ShowMessage("La richiesta di profilazione è stata inoltrata all'approvazione alla PF Informatica e Crescita Digitale.");
                }
                
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnSalvaInvia_Click(object sender, EventArgs e)
        {
            try
            {
                
                ucFirmaDocumento.FirmaObbligatoria = false;
                ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, richiesta_selezionata.IdRichiesta);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void SalvaDati(bool definitiva)
        {
            try
            {
                if(richiesta_selezionata == null)
                    richiesta_selezionata = new SiarLibrary.RichiestaProfilazione();

                richiesta_selezionata.Operatore = Operatore.Utente.IdUtente;
                richiesta_selezionata.Definitiva = definitiva;
                richiesta_selezionata.LasteditDatetim = DateTime.Now;
                richiesta_selezionata.Servizio = txtServizio.Text ;
                richiesta_selezionata.Pf = txtPF.Text ;
                richiesta_selezionata.Pec =txtPec.Text ;
                if (ddlTipoFondi.SelectedValue == "1")
                    richiesta_selezionata.FondiFesr = true;
                else
                    richiesta_selezionata.FondiFesr = false;
                richiesta_selezionata.Asse = txtAsse.Text;
                richiesta_selezionata.Azione = txtAzione.Text ;
                richiesta_selezionata.ParereAdg = txtParereAdg.Text;
                richiesta_selezionata.Multiazione= checkMultiazione.Checked;
                richiesta_selezionata.Perc10= checkPerc10.Checked;
                richiesta_selezionata.Oggetto= txtOggetto.Text;
                richiesta_selezionata.Importo =  txtImporto.Text;
                richiesta_selezionata.Rup = txtRup.Text;
                richiesta_selezionata.RupTelefono = txtRupTelefono.Text;
                richiesta_selezionata.RupEmail =  txtRupEmail.Text;
                richiesta_selezionata.DataApertura =  txtDataApertura.Text;
                richiesta_selezionata.OraApertura = txtOraApertura.Text;
                richiesta_selezionata.DataChiusura = txtDataChiusura.Text;
                richiesta_selezionata.OraChiusura = txtOraChiusura.Text;
                richiesta_selezionata.Decreto = txtDecreto.Text;
                richiesta_selezionata.FascicoloPaleo = txtFascicolo.Text;
                richiesta_selezionata.Graduatoria = checkGraduatoria.Checked;
                richiesta_selezionata.Sportello = checkSportello.Checked;
                richiesta_selezionata.StrumentiFinanziari = checkStrumentiFinanz.Checked;
                richiesta_selezionata.FinanziabilitaParziale = checkFinanzParz.Checked ;
                richiesta_selezionata.TipoProcedura = txtTipoProcedura.Text;
                richiesta_selezionata.MarcaDaBollo = checkMarcaDaBollo.Checked;
                richiesta_selezionata.TipoAggregazione = ddlTipoAggregazione.SelectedValue;
                richiesta_selezionata.Capofila = checkCapofila.Checked;
                richiesta_selezionata.TipoBenificiario = ddlTipoBeneficiario.SelectedValue;
                richiesta_selezionata.Ateco = txtAteco.Text;
                richiesta_selezionata.NumeroDomande = checkNumeroDomande.Checked;
                richiesta_selezionata.DeMinimis = checkDeMinimis.Checked;
                richiesta_selezionata.ContributoUe = checkContributoUe.Checked;
                richiesta_selezionata.TipoPiano = txtTipoPiano.Text;
                richiesta_selezionata.DataAmmissibilita = txtDataAmmissibile.Text;
                richiesta_selezionata.CostoMin = txtCostoMin.Text;
                richiesta_selezionata.CostoMax =  txtCostoMax.Text;
                richiesta_selezionata.Comitato = checkComitato.Checked;
                richiesta_selezionata.PunteggioMin = txtPunteggioMin.Text;
                richiesta_selezionata.Allegati =  txtAllegati.Text;
                richiesta_selezionata.Dichiarazioni = txtDichiarazioni.Text;
                richiesta_selezionata.DichiarazioniOpz = txtDichiarazioniOpz.Text;
                richiesta_selezionata.CupBeni = checkCupBeni.Checked;
                richiesta_selezionata.CupServizi = checkCupServizi.Checked;
                richiesta_selezionata.CupLavPub = checkCupLavPub.Checked;
                richiesta_selezionata.CupContr = checkCupContr.Checked;
                richiesta_selezionata.CupProd = checkCupProd.Checked;
                richiesta_selezionata.CupCap = checkCupCap.Checked;
                richieste_prov.Save(richiesta_selezionata);
                hdnIdRichiesta.Value = richiesta_selezionata.IdRichiesta.ToString();
            }
            catch (Exception ex) { ShowError(ex); }
            
        }

        protected void btnNuovaRichiesta_Click(object sender, EventArgs e)
        {
            try
            {
                divRichiesta.Visible = true;
                PulisciCampi();
                txtOperatore.Text = Operatore.Utente.Nominativo;
                ucSiarNewTab.TabSelected = 2;
                //ShowMessage("Procedura di attivazione associata corretamente al trasferimento");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void PulisciCampi()
        {
            richiesta_selezionata = null;
            hdnIdRichiesta.Value = "";

            txtServizio.Text = "";
            txtPF.Text = "";
            txtPec.Text = "";
            txtAsse.Text = "";
            txtAzione.Text = "";
            txtParereAdg.Text = "";
            checkMultiazione.Checked = false;
            checkPerc10.Checked = false;
            txtOggetto.Text = "";
            txtImporto.Text = "";
            txtRup.Text = "";
            txtRupTelefono.Text = "";
            txtRupEmail.Text = "";
            txtDataApertura.Text = "";
            txtOraApertura.Text = "";
            txtDataChiusura.Text = "";
            txtOraChiusura.Text = "";
            txtDecreto.Text = "";
            txtFascicolo.Text = "";
            checkGraduatoria.Checked = false;
            checkSportello.Checked = false;
            checkStrumentiFinanz.Checked = false;
            checkFinanzParz.Checked = false;
            txtTipoProcedura.Text = "";
            checkMarcaDaBollo.Checked = false;
            ddlTipoAggregazione.SelectedValue = "";
            checkCapofila.Checked = false;
            ddlTipoBeneficiario.SelectedValue = "";
            txtAteco.Text = "";
            checkNumeroDomande.Checked = false;
            checkDeMinimis.Checked = false;
            checkContributoUe.Checked = false;
            txtTipoPiano.Text = "";
            txtDataAmmissibile.Text = "";
            txtCostoMin.Text = "";
            txtCostoMax.Text = "";
            checkComitato.Checked = false;
            txtPunteggioMin.Text = "";
            txtAllegati.Text = "";
            txtDichiarazioni.Text = "";
            txtDichiarazioniOpz.Text = "";
            checkCupBeni.Checked = false;
            checkCupServizi.Checked = false;
            checkCupLavPub.Checked = false;
            checkCupContr.Checked = false;
            checkCupProd.Checked = false;
            checkCupCap.Checked = false;
        }

        protected void ProtocollaDocFirmatoEvent(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo p = new SiarLibrary.Protocollo("RM_INF");
                //p.setCorrispondente(Operatore.Utente.Nominativo, null, null);
                SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(Operatore.Utente.IdPersonaFisica);
                p.setCorrispondente(pf.Cognome, pf.Nome, null, "mittente");
                p.setDocumento("SchedaProfilazione.pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string oggetto = "Scheda di profilazione Bando SIGEF: ID_RICHIESTA " + richiesta_selezionata.IdRichiesta.ToString();
                string segnatura = p.ProtocolloIngresso(oggetto, System.Configuration.ConfigurationManager.AppSettings["FascicoloRichiesteProfilazione"]);
                
                richiesta_selezionata.Definitiva = true;
                richiesta_selezionata.DataArrivo = DateTime.Today;
                richiesta_selezionata.Segnatura = segnatura;
                richieste_prov.Save(richiesta_selezionata);

                SiarLibrary.Email em = new SiarLibrary.Email("Avviso di ricezione per una richiesta di profilazione di una nuova procedura di attivazione (ID_RICHIESTA :"+richiesta_selezionata.IdRichiesta+" )",
                                    "<html><body>Si comunica che con prot. " + richiesta_selezionata.Segnatura + "<br />è stata ricevuta la Richiesta di Profilazione con ID_RICHIESTA  " + richiesta_selezionata.IdRichiesta
                                + " da "+ Operatore.Utente.Nominativo
                                + "<br />Tale richiesta è consultabile all'indirizzo <a href='https://sigef.regione.marche.it/web/private/psr/bandi/RichiesteProfilazione.aspx' target=_blank>Clicca qui</a> ricercando la richiesta nella 'Sezione Procedura di Attivazione->Richiesta nuova profilazione'"
                                + "<br /><br />Questa è una notifica automatica del sistema " + System.Configuration.ConfigurationManager.AppSettings["APP:NomeCompleto"]
                                + "<br />Si prega di non rispondere a questa email.</body></html>");
                em.SetHtmlBodyMessage(true);
                string[] destinatari = new string[5];
                destinatari[0] = "";
                if (richiesta_selezionata.FondiFesr)
                    { em.SendNotification(destinatari, new string[] { }); }
                else
                {
                    string[] destinatari_cc = new string[2];
                    destinatari_cc[0] = "";                    
                    em.SendNotification(destinatari, destinatari_cc);
                }


                ShowMessage("La richiesta di profilazione è stata salvata ed inviata correttamente al protocollo.");
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}