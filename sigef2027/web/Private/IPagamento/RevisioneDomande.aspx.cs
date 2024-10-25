using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarLibrary;
using SiarBLL;

namespace web.Private.IPagamento
{
    public partial class RevisioneDomande : SiarLibrary.Web.ControlliValidazionePagePage
    {
        SiarBLL.RevisioneDomandaPagamentoCollectionProvider rev_provider = new SiarBLL.RevisioneDomandaPagamentoCollectionProvider();
        SiarLibrary.LottoDiRevisione lotto;
        SiarLibrary.RevisioneDomandaPagamento DomandaPagamentoPerCopia_selezionata;
        SiarLibrary.Progetto progettoCopia_selezionato;

        SiarLibrary.RevisioneDpagamentoEsitoCollection RDPagamentoC;
        SiarBLL.RevisioneDpagamentoEsitoCollectionProvider RDP_Prov = new SiarBLL.RevisioneDpagamentoEsitoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Controlla_RevisioneDomandaPagamento())
            {
                DatiCarica();
                Controlla_Modifica();
                btnBack.Attributes.Add("onclick", "location='ValidazioneDomandePagamento.aspx'");
                btnFirmaRevisione.Enabled = false;
                ucFirmaRevisione.DocumentoFirmatoEvent = btnPostBack_Click;
                
                int idProgettoCopia;
                if(int.TryParse(txtNumDomanda.Text, out idProgettoCopia))
                {
                    progettoCopia_selezionato = new SiarBLL.ProgettoCollectionProvider().GetById(idProgettoCopia);
                    if (progettoCopia_selezionato != null)
                    {
                        int IdDomandaPagamentoInv_selezionata;
                        if (int.TryParse(hdnIdDomandaPagamentoInv.Value, out IdDomandaPagamentoInv_selezionata))
                        {
                            SiarLibrary.RevisioneDomandaPagamentoCollection rev_coll = rev_provider.Find(null, IdDomandaPagamentoInv_selezionata, null, true, null, null);
                            if (rev_coll.Count > 0)
                                DomandaPagamentoPerCopia_selezionata = rev_coll[0];
                        }
                    } 
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            RevisionePrima();
            RevisioneSeconda();
            dgStepsSetup();
            if (RevisioneDomandaPagamento.Approvata == null || RevisioneDomandaPagamento.Approvata == false)
            {
                if (DomandaPagamentoPerCopia_selezionata != null)
                {
                    DomandaDiPagamentoCollection domPagamento = new DomandaDiPagamentoCollection();
                    domPagamento.Add(DomandaPagamentoPerCopia_selezionata);
                    ((SiarLibrary.Web.CheckColumn)dgDomande.Columns[4]).SetSelected(new string[] { DomandaPagamentoPerCopia_selezionata.IdDomandaPagamento });
                    dgDomande.DataSource = domPagamento;
                    dgDomande.DataBind();
                    TbValidazioneInviate.Visible = true;
                    trBtnCopia.Visible = true;
                }
                else
                {
                    if (progettoCopia_selezionato != null)
                    {
                        //controllo se il progetto selezionato per la copia ha la checklist compatibile con la domanda di pagamento
                        string tipoAppaltoCopia = getTipoAppalto(progettoCopia_selezionato.IdBando);
                        string tipoAppalto = getTipoAppalto(Bando.IdBando);

                        if (tipoAppalto == tipoAppaltoCopia)
                        {
                            trBtnCopia.Visible = false;
                            SiarLibrary.RevisioneDomandaPagamentoCollection DomandaPagamento_LottoGrid = new RevisioneDomandaPagamentoCollection();

                            SiarLibrary.DomandaDiPagamentoCollection dp_coll = new SiarBLL.DomandaDiPagamentoCollectionProvider().Find(null, DomandaPagamento.CodTipo, progettoCopia_selezionato.IdProgetto, null);
                            foreach (SiarLibrary.DomandaDiPagamento dp in dp_coll)
                            {
                                SiarLibrary.RevisioneDomandaPagamentoCollection DomandaPagamento_Lotto = rev_provider.Find(null, dp.IdDomandaPagamento, null, true, null, null);

                                foreach (SiarLibrary.RevisioneDomandaPagamento rdp in DomandaPagamento_Lotto)
                                {
                                    DomandaPagamento_LottoGrid.Add(rdp);
                                }
                            }
                            if (DomandaPagamento_LottoGrid.Count > 0)
                            {
                                TbValidazioneInviate.Visible = true;
                            }
                            else
                                tdNessunProg.Visible = true;
                            dgDomande.DataSource = DomandaPagamento_LottoGrid;
                            dgDomande.DataBind();
                        }
                    }

                }
            }
            else
                tbInsProg.Visible = false;
            base.OnPreRender(e);
        }

        private bool GetEsitoCheckList(bool chiudi_checklist)
        {
            bool approvata = true;
            foreach (SiarLibrary.RevisioneDpagamentoEsito esito in RDPagamentoC)
            {
                if (esito.EsitoPositivo == false || esito.CodEsito == null)
                {
                    approvata = false;
                    break;
                }
            }
            if (RevisioneDomandaPagamento.SegnaturaRevisione != null && !approvata)
            {
                throw new Exception("La valutazione salvata non conferma ancora l'istruttoria della domanda, impossibile chiudere la checklist.");
            }
            return approvata;
        }
                
        #region Eventi Button
        
        // Evento collegato a ucFirmaRevisione
        protected void btnPostBack_Click(object sender, EventArgs e)
        {
            RevisioneDomandaPagamentoSalva();
        }

        protected void btnFirmaRevisione_Click(object sender, EventArgs e)
        {
            // Richiama ucFirmaRevisione
            try
            {
                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }
                if (txtDataValidazione.Text == null)
                {
                    throw new SiarLibrary.SiarException("Compilare la Data Validazione");
                }
                GetEsitoCheckList(true);
                ucFirmaRevisione.loadDocumento(Operatore.Utente.CfUtente, DomandaPagamento.IdDomandaPagamento);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DatiSalva();
        }

        protected void btnCopia_Click(object sender, EventArgs e)
        {
            SiarBLL.RevisioneDpagamentoEsitoCollectionProvider revP = new SiarBLL.RevisioneDpagamentoEsitoCollectionProvider();

            if (RDPagamentoC != null && RDPagamentoC.Count > 0)
            {
                foreach (SiarLibrary.RevisioneDpagamentoEsito esito in RDPagamentoC)
                {
                    SiarLibrary.RevisioneDpagamentoEsitoCollection esitoCopiaColl = revP.Select(null, null, DomandaPagamentoPerCopia_selezionata.IdDomandaPagamento, esito.IdVldStep, null, null, null, null, null);
                    if(esitoCopiaColl.Count>0)
                    {
                        SiarLibrary.RevisioneDpagamentoEsito esitoCopia = esitoCopiaColl[0];
                        esito.CodEsito = esitoCopia.CodEsito;
                        esito.Note = esitoCopia.Note;
                        esito.EscludiDaComunicazione = esitoCopia.EscludiDaComunicazione;
                        esito.EsitoPositivo = esitoCopia.EsitoPositivo;
                    }
                }
                //RDP_Prov.SaveCollection(RDPagamentoC);
                dgSteps.DataSource = RDPagamentoC;
                dgSteps.SetTitoloNrElementi();
                dgSteps.DataBind();
            }
        }

        protected void btnPost_Click(object sender, EventArgs e) { }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            try
            {

                hdnIdDomandaPagamentoInv.Value = null;
                DomandaPagamentoPerCopia_selezionata = null;
                if (progettoCopia_selezionato == null)
                    throw new Exception("il progetto selezionato non è valido!");
                //controllo se il progetto selezionato per la copia ha la checklist compatibile con la domanda di pagamento
                string tipoAppaltoCopia = getTipoAppalto(progettoCopia_selezionato.IdBando);
                string tipoAppalto = getTipoAppalto(Bando.IdBando);

                if (tipoAppalto != tipoAppaltoCopia)
                    throw new Exception("il progetto selezionato non ha una checklist compatibile con la domanda di pagamento che si sta validando!");

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region Revisioni

        private bool Controlla_RevisioneDomandaPagamento()
        {
            bool DomandaOk = true;
            if (RevisioneDomandaPagamento == null || RevisioneDomandaPagamento.IdLotto == null)
            {
                Redirect("validazionelotti.aspx", "La domanda di pagamento selezionata non è ancora stata inclusa in un lotto di validazione.", true);
                DomandaOk = false;
            }
            else if (!RevisioneDomandaPagamento.SelezionataXRevisione)
            {
                Redirect("validazionelotti.aspx", "La domanda di pagamento non è stata estratta a controllo.", true);
                DomandaOk = false;
            }
            return DomandaOk;
        }

        private void RevisionePrima()
        {
            if (RevisioneDomandaPagamento.SegnaturaRevisione != null)
            {
                txtEsitoPrimaRevisione.Text = (RevisioneDomandaPagamento.Approvata ? "Positivo" : "Negativo");
                imgSegnatura.Disabled = false;
                imgSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + RevisioneDomandaPagamento.SegnaturaRevisione + "');");
                imgSegnatura.Style.Add("cursor", "pointer");
                if (RevisioneDomandaPagamento.Approvata)
                {
                    TbValidazioneInviate.Visible = false;
                }
            }
        }

        private void RevisioneSeconda()
        {
            if (RevisioneDomandaPagamento.SegnaturaSecondaRevisione != null)
            {
                txtEsitoPrimaRevisione.Text = "Negativo";
                txtEsitoSecondaRevisione.Text = (RevisioneDomandaPagamento.Approvata ? "Positivo" : "Negativo");
                imgSecondaSegnatura.Disabled = false;
                imgSecondaSegnatura.Attributes.Add("onclick", "sncAjaxCallVisualizzaProtocollo('" + RevisioneDomandaPagamento.SegnaturaSecondaRevisione + "');");
                imgSecondaSegnatura.Style.Add("cursor", "pointer");
                if (RevisioneDomandaPagamento.Approvata)
                {
                    TbValidazioneInviate.Visible = false;
                }
            }
        }

        #endregion
        
        #region Data access

        private void DatiCarica()
        {
            RDPagamentoC = DatiCarica_RevisioneDPagamento();
            if (RDPagamentoC == null)
            {
                RDPagamentoC = DatiCarica_Vld_ChecklistStep();
            }

            if (txtDataValidazione.Text == null)
            {
                txtDataValidazione.Text = RevisioneDomandaPagamento.DataValidazione;
            }
        }

        private void Controlla_Modifica()
        {
            SiarLibrary.BandoValidatoriCollection vv;
            vv = new SiarBLL.BandoValidatoriCollectionProvider().Find(Bando.IdBando, Operatore.Utente.IdUtente, null, true);
            DateTime oggi = DateTime.Now;            

            AbilitaModifica = vv.Count > 0 && (RevisioneDomandaPagamento.SegnaturaRevisione == null ||
                                               DomandaPagamento.SegnaturaSecondaApprovazione != null &&
                                               RevisioneDomandaPagamento.SegnaturaSecondaRevisione == null) && RevisioneDomandaPagamento.CfOperatore == Operatore.Utente.CfUtente;
            txtDataValidazione.ReadOnly = true;
            if (AbilitaModifica)
            {
                txtDataValidazione.ReadOnly = false;
            }
            if (txtDataValidazione.Text == null && AbilitaModifica && !IsPostBack)
            {
                txtDataValidazione.Text = oggi.ToShortDateString();
            }
        }

        private RevisioneDpagamentoEsitoCollection DatiCarica_RevisioneDPagamento()
        {
            SiarBLL.RevisioneDpagamentoEsitoCollectionProvider revP = new SiarBLL.RevisioneDpagamentoEsitoCollectionProvider();
            SiarBLL.VldCheckListStepCollectionProvider clsP = new SiarBLL.VldCheckListStepCollectionProvider();            
            RevisioneDpagamentoEsitoCollection revs;

            string _tpAppalto = clsP.Get_TpAppalto(Bando.IdBando);
            lotto = new SiarBLL.LottoDiRevisioneCollectionProvider().GetById(RevisioneDomandaPagamento.IdLotto);
            revs = revP.getBy_Id_LottoDomanda(lotto.IdLotto, DomandaPagamento.IdDomandaPagamento, DomandaPagamento.CodTipo, _tpAppalto);

            if (revs.Count == 0)
            {
                revs = null;
            }

            return revs;
        }


        private RevisioneDpagamentoEsitoCollection DatiCarica_Vld_ChecklistStep()
        {
            SiarBLL.VldCheckListStepCollectionProvider clsP = new SiarBLL.VldCheckListStepCollectionProvider();
            VldCheckListStepCollection clsS;
            RevisioneDpagamentoEsitoCollection revs = new RevisioneDpagamentoEsitoCollection();
            RevisioneDpagamentoEsito rev;

            clsS = clsP.GetBy_TipoPubblico(DomandaPagamento.CodTipo, clsP.Get_TpAppalto(Bando.IdBando));
            foreach (VldCheckListStep cls in clsS)
            {
                rev = new RevisioneDpagamentoEsito();
                rev.IdLotto = lotto.IdLotto;
                rev.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
                rev.IdVldStep = cls.IdVldStep;
                rev.Descrizione = cls.Descrizione;
                rev.Automatico = cls.Automatico;
                rev.Ordine = cls.Ordine;
                revs.Add(rev);
            }
            return revs;
        }

        private void DatiSalva()
        {
            bool approvata;
            try
            {
                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }
                if (RDPagamentoC != null && RDPagamentoC.Count > 0)
                {
                    foreach (SiarLibrary.RevisioneDpagamentoEsito esito in RDPagamentoC)
                    {
                        string hdn = "hdnEsitoStep" + esito.IdVldStep;
                        foreach (string s in Request.Form.AllKeys)
                        {
                            if (s.EndsWith(hdn))
                            {
                                string nome_combo = Request.Form[s];
                                esito.CodEsito = Request.Form[nome_combo];
                                if (esito.CodEsito == "SI" || esito.CodEsito == "ND")
                                {
                                    esito.EsitoPositivo = true;
                                }
                                else
                                {
                                    esito.EsitoPositivo = false;
                                }
                                break;
                            }
                        }
                        esito.Note = leggiNote(esito.IdVldStep);
                        esito.Operatore = Operatore.Utente.IdUtente;
                        esito.Data = DateTime.Now;
                        esito.IdDomandaPagamento = RevisioneDomandaPagamento.IdDomandaPagamento;
                        esito.IdLotto = lotto.IdLotto;
                    }
                    // Revisione_DPagamento_Esito
                    RDP_Prov.SaveCollection(RDPagamentoC);
                }
                approvata = GetEsitoCheckList(false);
                ShowMessage("Checklist salvata correttamente, il controllo sarà chiuso con esito " + (approvata ? "POSITIVO" : "NEGATIVO") + ".");
                btnFirmaRevisione.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void RevisioneDomandaPagamentoSalva()
        {
            try
            {
                if (!AbilitaModifica)
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                }
                if (string.IsNullOrEmpty(ucFirmaRevisione.FileFirmato))
                {
                    throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
                }
                if (txtDataValidazione.Text == null)
                {
                    throw new SiarLibrary.SiarException("Compilare la Data Validazione");
                }
                bool approvata = GetEsitoCheckList(true);
                SiarLibrary.Protocollo revisione = new SiarLibrary.Protocollo(Bando.CodEnte);
                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(Bando.IdBando, lotto.Provincia);
                if (RevisioneDomandaPagamento.SegnaturaRevisione == null)
                {
                    revisione.setDocumento("checklist_validazione_" + 
                                             DomandaPagamento.Descrizione.Value.ToUpper() + 
                                             "_domanda_nr_" + 
                                             DomandaPagamento.IdProgetto + 
                                             ".pdf",
                                           Convert.FromBase64String(ucFirmaRevisione.FileFirmato));
                    string oggetto = "Checklist di validazione istruttoria della domanda di pagamento modalità " + 
                                        DomandaPagamento.Descrizione.Value.ToUpper() + 
                                        " della domanda di aiuto nr. " + 
                                        Progetto.IdProgetto + 
                                        " in risposta al bando: " + 
                                        ss[0] + 
                                        " del " + 
                                        ss[1] + 
                                        " con scadenza: " + 
                                        Bando.DataScadenza + 
                                        "\n" + 
                                        ss[3] + "\n CF: " + 
                                        ucIDomandaPagamento.Impresa.CodiceFiscale
                                        + "\n Ragione sociale: " + ucIDomandaPagamento.Impresa.RagioneSociale;
                    string identificativo_paleo = revisione.DocumentoInterno(oggetto, ss[4]);
                    try
                    {
                        RevisioneDomandaPagamento.Approvata = approvata;
                        RevisioneDomandaPagamento.SegnaturaRevisione = identificativo_paleo;
                        RevisioneDomandaPagamento.DataModifica = DateTime.Now;
                        RevisioneDomandaPagamento.DataValidazione = Convert.ToDateTime(txtDataValidazione.Text);
                        RevisioneDomandaPagamento.CfOperatore = Operatore.Utente.CfUtente;
                        rev_provider.Save(RevisioneDomandaPagamento);

                        VerificaLotto();

                        ShowMessage("Checklist di validazione firmata e protocollata correttamente. " + 
                                    (approvata ? "La checklist salvata conferma tutti gli esiti dell'istruttore, la domanda non verrà reistruita." : 
                                                 "La domanda è stata riaperta in istruttoria per la modifica dei dati.")
                                    );
                    }
                    catch (Exception ex)
                    {
                        string oggettoEmail = "Errore in checklist di validazione domande di pagamento";
                        string testEmail = "Domanda: " +
                                                Progetto.IdProgetto +
                                                "\nModalità: " +
                                                DomandaPagamento.Descrizione +
                                                "\nSegnatura: " +
                                                identificativo_paleo +
                                                "\n\n" +
                                                ex.Message;
                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                        ShowError(ex);
                    }
                    btnFirmaRevisione.Enabled = false;
                    btnSave.Enabled = false;
                }
                else if (RevisioneDomandaPagamento.SegnaturaSecondaRevisione == null)
                {
                    revisione.setDocumento("checklist_conferma_validazione_" +
                                             DomandaPagamento.Descrizione.Value.ToUpper() +
                                             "_domanda_nr_" +
                                             DomandaPagamento.IdProgetto +
                                             ".pdf",
                                           Convert.FromBase64String(ucFirmaRevisione.FileFirmato));
                    string oggetto = "Checklist di conferma della validazione istruttoria della domanda di pagamento modalità " +
                                       DomandaPagamento.Descrizione.Value.ToUpper() +
                                       " della domanda di aiuto nr. " +
                                       Progetto.IdProgetto +
                                       " in risposta al bando: " +
                                       ss[0] +
                                       " del " +
                                       ss[1] +
                                       " con scadenza: " +
                                       Bando.DataScadenza +
                                       "\n" +
                                       ss[3] +
                                       "\n CF: " +
                                       ucIDomandaPagamento.Impresa.CodiceFiscale
                                       + "\n Ragione sociale: " + ucIDomandaPagamento.Impresa.RagioneSociale;
                    string identificativo_paleo = revisione.DocumentoInterno(oggetto, ss[4]);

                    try
                    {
                        RevisioneDomandaPagamento.Approvata = approvata;
                        RevisioneDomandaPagamento.SegnaturaSecondaRevisione = identificativo_paleo;
                        RevisioneDomandaPagamento.DataModifica = DateTime.Now;
                        RevisioneDomandaPagamento.DataValidazione = Convert.ToDateTime(txtDataValidazione.Text);
                        RevisioneDomandaPagamento.CfOperatore = Operatore.Utente.CfUtente;
                        rev_provider.Save(RevisioneDomandaPagamento);

                        VerificaLotto();

                        ShowMessage("Checklist di conferma della validazione firmata e protocollata correttamente. Istruttoria conclusa.");
                    }
                    catch (Exception ex)
                    {
                        string oggettoEmail = "Errore in checklist di conferma validazione domande di pagamento";
                        string testEmail = "Domanda: " +
                                                Progetto.IdProgetto +
                                                "\nModalità: " +
                                                DomandaPagamento.Descrizione +
                                                "\nSegnatura: " +
                                                identificativo_paleo +
                                                "\n\n" +
                                                ex.Message;
                        EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                        ShowError(ex);
                    }
                    btnFirmaRevisione.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    ShowError("La validazione di istruttoria della domanda di pagamento è già stata effettuata. Operazione annullata.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                ucFirmaRevisione.FileFirmato = null;
            }
        }


        private void VerificaLotto()
        {
            SiarBLL.LottoDiRevisioneCollectionProvider lotto_provider = new SiarBLL.LottoDiRevisioneCollectionProvider();

            if (lotto == null)
            {
                throw new Exception("Per proseguire è necessario selezionare un lotto di controllo.");
            }
            if (!AbilitaModifica || lotto.RevisioneConclusa)
            {
                throw new Exception("Il lotto di controllo selezionato non è valido.");
            }
            int esito = lotto_provider.VerificaCompletamentoRevisione(lotto.IdLotto);

            bool chiudi_lotto = false;

            if (esito == 0)
            {
                chiudi_lotto = true;
            }

            lotto.RevisioneConclusa = chiudi_lotto;
            lotto.DataModifica = DateTime.Now;
            lotto.CfOperatore = Operatore.Utente.CfUtente;
            lotto_provider.Save(lotto);
        }

        private string getTipoAppalto(int id_bando )
        {
            SiarBLL.BandoConfigCollectionProvider bndP = new SiarBLL.BandoConfigCollectionProvider();
            string valore;
            string tpa = string.Empty;
            valore = bndP.GetBandoConfig_TpAppalto(progettoCopia_selezionato.IdBando);

            if (valore == string.Empty)     // Aiuti
            {
                tpa = "AIUTI";
            }
            else if (valore == "01" ||      // Appalti
                     valore == "02" ||
                     valore == "03")
            {
                tpa = "APPAL";
            }
            else                            // Strumenti finanziari
            {
                tpa = "STRFI";
            }
            return tpa;
        }

        #endregion

        #region dgStep

        private void dgStepsSetup()
        {
            dgSteps.DataSource = RDPagamentoC;
            dgSteps.SetTitoloNrElementi();
            dgSteps.DataBind();
        }

        protected void dgSteps_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            const int cEsito = 2;
            const int cNote = 3;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.RevisioneDpagamentoEsito esito = (SiarLibrary.RevisioneDpagamentoEsito)dgi.DataItem;
                // Esito
                SiarLibrary.Web.ComboSiNo comboEsitoStep = (SiarLibrary.Web.ComboSiNo)dgi.Cells[cEsito].FindControl("lstEsitoStep");
                if (comboEsitoStep != null)
                {
                    HtmlInputHidden hdn = new HtmlInputHidden();
                    hdn.ID = "hdnEsitoStep" + esito.IdVldStep;
                    hdn.Value = comboEsitoStep.UniqueID;
                    dgi.Cells[cEsito].Controls.Add(hdn);
                    if (esito.CodEsito != null)
                    {
                        ListItem li = comboEsitoStep.Items.FindByValue(esito.CodEsito);
                        if (li != null)
                        {
                            li.Selected = true;
                        }
                    }
                    else
                    {
                        ListItem li = comboEsitoStep.Items.FindByValue("ND");
                        if (li != null)
                        {
                            li.Selected = true;
                        }
                    }
                }
                // Note
                dgi.Cells[cNote].Text = dgi.Cells[cNote].Text.Replace("></textarea>", ">" + esito.Note + "</textarea>");
            }
        }

        private string leggiNote(int idVldStep)
        {
            string vGriglia;
            string vOutput = null;
            vGriglia = Request.Form["txtNote" + idVldStep + "_text"];
            if (vGriglia != string.Empty)
            {
                vOutput = vGriglia;
            }
            return vOutput;
        }

        #endregion

    }
}