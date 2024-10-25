using System;
using System.Web.UI.WebControls;

namespace web.Private.Istruttoria
{
    public partial class AmmissibilitaBilancioAgricolo : SiarLibrary.Web.IstruttoriaPage
    {
        SiarBLL.BilancioAgricoloCollectionProvider bilancio_Agricolo_provider = new SiarBLL.BilancioAgricoloCollectionProvider();
        SiarLibrary.BilancioAgricolo bil_Agricolo = new SiarLibrary.BilancioAgricolo();
        SiarLibrary.BilancioAgricoloCollection bil_Agricolo_col = new SiarLibrary.BilancioAgricoloCollection();
        SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();
        SiarLibrary.Progetto Progetto;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "ammissibilita_domande";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int iddomanda;
            if (!int.TryParse(Request.QueryString["iddom"], out iddomanda)) Redirect("Ammissibilita.aspx");
            Progetto = new SiarBLL.ProgettoCollectionProvider().GetById(iddomanda);
            impresa = new SiarBLL.ImpresaCollectionProvider().GetById(Progetto.IdImpresa);
            ucInfoDomanda.Progetto = Progetto;
            controlloOperatoreStatoProgetto();
            bil_Agricolo_col = bilancio_Agricolo_provider.Find(null, null, Progetto.IdProgetto, null, null, true);

        }

        protected override void OnPreRender(EventArgs e)
        {
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbBilancio.Visible = true;
                    ucSiarNewTab.Width = tbBilancio.Width;
                    txtAnno.AddJSAttribute("onblur", "ControlloAnno(event)");
                    #region onblur stato patrimoniale
                    txtCFCFterreni.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFCFimpianti.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFCFpiantagioni.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFCFmiglioramenti.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFCAmacchine.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFCAbestiame.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCFIFpartecipazioni.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCCDFrimanenza.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCCDFanticipazioni.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCCLDCrediti.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCCLIbanca.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtCCLIcassa.AddJSAttribute("onblur", " StatoPatrimoniale()");

                    txtFFPCdebitibreve.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFPCfornitori.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFPCdebitilungo.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFPCmutui.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFMPcapitalenetto.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFMPriserve.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    txtFFMPutile.AddJSAttribute("onblur", " StatoPatrimoniale()");
                    #endregion
                    #region conto economico
                    txtPLVricaviNetti.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPLVRicaviattivita.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPLVrimanenzefinali.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPLVrimanenzeiniziali.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAcostimaterie.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAcostiattivita.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAnoleggi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAmanutenzioni.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAspesegenerali.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAaffitti.AddJSAttribute("onblur", " ContoEconomico()");
                    txtVAaltricosti.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPNmacchine.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPNfabbricati.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPNpiantagioni.AddJSAttribute("onblur", " ContoEconomico()");
                    txtROsalari.AddJSAttribute("onblur", " ContoEconomico()");
                    txtROoneri.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACricavi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACcosti.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACproventi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACperdite.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACinteressiattivi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACinteressipassivi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACimposte.AddJSAttribute("onblur", " ContoEconomico()");
                    txtPACcontributi.AddJSAttribute("onblur", " ContoEconomico()");
                    txtMNLredditifam.AddJSAttribute("onblur", " ContoEconomico()");
                    txtMNLrimborso.AddJSAttribute("onblur", " ContoEconomico()");
                    txtMNLprelievi.AddJSAttribute("onblur", " ContoEconomico()");
                    #endregion

                    if (string.IsNullOrEmpty(hdnId.Value)) btnElimina.Enabled = false;
                    if (bil_Agricolo.IdBilancioAgricolo == null) bil_Agricolo = bil_Agricolo_col.CollectionGetById(hdnId.Value);
                    btnElimina.Enabled = AbilitaModifica;
                    btnSalva.Enabled = AbilitaModifica;
                    break;
                default:
                    tbRiepilogoBilanci.Visible = true;
                    ucSiarNewTab.Width = tbRiepilogoBilanci.Width;
                    dgBilancio.DataSource = bil_Agricolo_col;
                    lblRisultato.Text = bil_Agricolo_col.Count.ToString();
                    if (bil_Agricolo_col.Count == 0) dgBilancio.Titolo = "Nessun bilancio inserito per l'impresa specificata.";
                    dgBilancio.ItemDataBound += new DataGridItemEventHandler(dgBilancio_ItemDataBound);
                    dgBilancio.DataBind();
                    hdnId.Value = string.Empty;
                    break;

            }

      
            base.OnPreRender(e);
        }
        private void controlloOperatoreStatoProgetto()
        {
            if (AbilitaModifica)
            {
                if (ucInfoDomanda.Progetto.CodStato != "I" && !ucInfoDomanda.DomandaInRiesame && !ucInfoDomanda.DomandaInRevisione
                    && !ucInfoDomanda.DomandaInRicorso) AbilitaModifica = false;
                else if (new SiarBLL.CollaboratoriXBandoCollectionProvider().Find(Bando.IdBando, ucInfoDomanda.Progetto.IdProgetto,
                        ((SiarLibrary.Web.MasterPage)Master).Operatore.Utente.IdUtente, null, true).Count == 0) AbilitaModifica = false;
            }
        }



        void dgBilancio_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BilancioAgricolo bp = (SiarLibrary.BilancioAgricolo)dgi.DataItem;
                dgi.Cells[0].Text = " Bilancio  d'esercizio  del " + bp.DataBilancio.ToFullYearString();
                e.Item.Cells[2].Text = "<input type='button' style='width:70px' class='ButtonGrid' value='Dettaglio' onclick='dettaglioBil("
                    + bp.IdBilancioAgricolo + ")' />";
            }
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bilancio_Agricolo_provider = new SiarBLL.BilancioAgricoloCollectionProvider();
            bil_Agricolo = new SiarLibrary.BilancioAgricolo();
            try
            {
                int anno, idBilancio; DateTime data_bilancio;
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(txtAnno.Text, out anno) || txtAnno.Text.Length != 4) throw new Exception("L'anno indicato non è corretto.");
                if (anno < DateTime.Now.Year) throw new Exception("Attenzione l'anno inserito non è corretto. Il bilancio deve riferirsi ad un anno successivo il " + DateTime.Now.Year);
                if (!DateTime.TryParse(txtDataBilancio.Text, out data_bilancio)) throw new Exception("Attenzione la data inserita non è corretta.");

                bilancio_Agricolo_provider.DbProviderObj.BeginTran();
                if (!string.IsNullOrEmpty(hdnId.Value))
                {
                    if (!int.TryParse(hdnId.Value, out idBilancio)) throw new Exception("Attenzione! Il bilancio selezionato non è valido.");
                    foreach (SiarLibrary.BilancioAgricolo b in bil_Agricolo_col)
                        if (b.Anno == anno && b.IdBilancioAgricolo != idBilancio) throw new Exception("Attenzione! Il bilancio, per l'anno indicato, è già stato inserito.");
                    bil_Agricolo = bilancio_Agricolo_provider.GetById(idBilancio);
                }
                else
                {
                    foreach (SiarLibrary.BilancioAgricolo b in bil_Agricolo_col)
                        if (b.Anno == anno) throw new Exception("Attenzione! Il bilancio, per l'anno indicato, è già stato inserito.");
                    bil_Agricolo.Provider = bilancio_Agricolo_provider;
                    bil_Agricolo.IdProgetto = Progetto.IdProgetto;
                    bil_Agricolo.Previsionale = true;
                }
                bil_Agricolo.Anno = anno;
                bil_Agricolo.DataBilancio = data_bilancio;
                bil_Agricolo.DataModifica = DateTime.Now;

                //Stato Patrimoniale
                bil_Agricolo.CfCfTerreni = txtCFCFterreni.Text;
                bil_Agricolo.CfCfImpianti = txtCFCFimpianti.Text;
                bil_Agricolo.CfCfPiantagioni = txtCFCFpiantagioni.Text;
                bil_Agricolo.CfCfMiglioramenti = txtCFCFmiglioramenti.Text;

                bil_Agricolo.CfCaMacchine = txtCFCAmacchine.Text;
                bil_Agricolo.CfCaBestiame = txtCFCAbestiame.Text;
                bil_Agricolo.CfIfPartecipazioni = txtCFIFpartecipazioni.Text;

                bil_Agricolo.CcDfRimanenze = txtCCDFrimanenza.Text;
                bil_Agricolo.CcDfAnticipazioni = txtCCDFanticipazioni.Text;
                bil_Agricolo.CcLdCrediti = txtCCLDCrediti.Text;
                bil_Agricolo.CcLiBanca = txtCCLIbanca.Text;
                bil_Agricolo.CcLiCassa = txtCCLIcassa.Text;

                bil_Agricolo.FfPcDebitiBreveTermine = txtFFPCdebitibreve.Text;
                bil_Agricolo.FfPcFornitori = txtFFPCfornitori.Text;
                bil_Agricolo.FfPcDebiti = txtFFPCdebitilungo.Text;
                bil_Agricolo.FfPcMutui = txtFFPCmutui.Text;
                bil_Agricolo.FfMpCapitale = txtFFMPcapitalenetto.Text;
                bil_Agricolo.FfMpRiserve = txtFFMPriserve.Text;
                bil_Agricolo.FfMpUtile = txtFFMPutile.Text;

                //ContoEconomico
                bil_Agricolo.PlvRicaviAttivita = txtPLVRicaviattivita.Text;
                bil_Agricolo.PlvRicaviNetti = txtPLVricaviNetti.Text;
                bil_Agricolo.PlvRimanenzeFinali = txtPLVrimanenzefinali.Text;
                bil_Agricolo.PlvRimanenzeIniziali = txtPLVrimanenzeiniziali.Text;

                bil_Agricolo.VaCostiMatPrime = txtVAcostimaterie.Text;
                bil_Agricolo.VaCostiAttConnesse = txtVAcostiattivita.Text;
                bil_Agricolo.VaNoleggi = txtVAnoleggi.Text;
                bil_Agricolo.VaManutenzioni = txtVAmanutenzioni.Text;
                bil_Agricolo.VaSpeseGenerali = txtVAspesegenerali.Text;
                bil_Agricolo.VaAffitti = txtVAaffitti.Text;
                bil_Agricolo.VaAltriCosti = txtVAaltricosti.Text;

                bil_Agricolo.PnAmmMacchine = txtPNmacchine.Text;
                bil_Agricolo.PnAmmFabbricati = txtPNfabbricati.Text;
                bil_Agricolo.PnAmmPiantagioni = txtPNpiantagioni.Text;

                bil_Agricolo.RoSalari = txtROsalari.Text;
                bil_Agricolo.RoOneri = txtROoneri.Text;

                bil_Agricolo.RnPacRicavi = txtPACricavi.Text;
                bil_Agricolo.RnPacCosti = txtPACcosti.Text;
                bil_Agricolo.RnPacProventi = txtPACproventi.Text;
                bil_Agricolo.RnPacPerdite = txtPACperdite.Text;
                bil_Agricolo.RnPacInteressiAttivi = txtPACinteressiattivi.Text;
                bil_Agricolo.RnPacInteressiPassivi = txtPACinteressipassivi.Text;
                bil_Agricolo.RnPacImposte = txtPACimposte.Text;
                bil_Agricolo.RnPacContributiPac = txtPACcontributi.Text;

                bil_Agricolo.MnlRedditiFam = txtMNLredditifam.Text;
                bil_Agricolo.MnlRimborso = txtMNLrimborso.Text;
                bil_Agricolo.MnlPrelievi = txtMNLprelievi.Text;

                bilancio_Agricolo_provider.Save(bil_Agricolo);
                bilancio_Agricolo_provider.DbProviderObj.Commit();

                ShowMessage("Bilancio salvato correttamente");

                if (string.IsNullOrEmpty(hdnId.Value)) bil_Agricolo_col.Add(bil_Agricolo);
                else
                {
                    bil_Agricolo_col.Remove(bil_Agricolo_col.CollectionGetById(hdnId.Value));
                    bil_Agricolo_col.Add(bil_Agricolo);

                }
                hdnId.Value = bil_Agricolo.IdBilancioAgricolo;
                VisualizzaBilancio(bil_Agricolo.IdBilancioAgricolo, bil_Agricolo);
            }
            catch (Exception ex)
            {
                bilancio_Agricolo_provider.DbProviderObj.Rollback(); ShowError(ex);
            }
        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_bil;
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(hdnId.Value, out id_bil)) throw new Exception("Nessun dato selezionato.");

                bilancio_Agricolo_provider.Delete(bilancio_Agricolo_provider.GetById(hdnId.Value));
                ShowMessage("Bilancio eliminato correttamente.");
                bil_Agricolo_col.Remove(bil_Agricolo_col.CollectionGetById(hdnId.Value));
                Nuovo_bilancio();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally { ucSiarNewTab.TabSelected = 1; }

        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            int id_bil;
            SiarLibrary.BilancioAgricolo bil_Agricolo;
            if (!int.TryParse(hdnId.Value, out id_bil)) { ShowError("Nessun dato selezionato."); ucSiarNewTab.TabSelected = 1; }
            else
            {
                bil_Agricolo = bil_Agricolo_col.CollectionGetById(id_bil);
                VisualizzaBilancio(id_bil, bil_Agricolo);
                ucSiarNewTab.TabSelected = 2;
            }

        }
        protected void btnNuovo_Click(object sender, EventArgs e) { Nuovo_bilancio(); }
        private void VisualizzaBilancio(int IdBilancio, SiarLibrary.BilancioAgricolo bil_Agricolo)
        {
            hdnId.Value = IdBilancio.ToString();
            _dataSource = bil_Agricolo;
            tbBilancio.DataBind();

            txtDataBilancio.Text = bil_Agricolo.DataBilancio.ToFullYearString();

            decimal CF_CF = valore(bil_Agricolo.CfCfTerreni) + valore(bil_Agricolo.CfCfImpianti)
                            + valore(bil_Agricolo.CfCfPiantagioni) + valore(bil_Agricolo.CfCfMiglioramenti);
            lblCapitaleFondiario.Text = CF_CF.ToString();

            decimal CF_CA = valore(bil_Agricolo.CfCaMacchine) + valore(bil_Agricolo.CfCaBestiame);
            lblCapitaleAgrario.Text = CF_CA.ToString();

            lblImmFinanziarie.Text = bil_Agricolo.CfIfPartecipazioni;
            lblCapitaleFisso.Text = Convert.ToString(CF_CF + CF_CA + valore(bil_Agricolo.CfIfPartecipazioni));

            decimal CCDF = valore(bil_Agricolo.CcDfRimanenze) + valore(bil_Agricolo.CcDfAnticipazioni);
            lblDispFinan.Text = CCDF.ToString();

            lblLiqDifferenti.Text = bil_Agricolo.CcLdCrediti;

            decimal CC_LI = valore(bil_Agricolo.CcLiBanca) + valore(bil_Agricolo.CcLiCassa);
            lblLiqImmediate.Text = CC_LI.ToString();

            lblCapitaleCircolante.Text = Convert.ToString(CCDF + valore(bil_Agricolo.CcLdCrediti) + CC_LI);
            lblTotImpieghi.Text = Convert.ToString(CF_CF + CF_CA + valore(bil_Agricolo.CfIfPartecipazioni) + CCDF + valore(bil_Agricolo.CcLdCrediti) + CC_LI);

            decimal FF_PC = valore(bil_Agricolo.FfPcDebitiBreveTermine) + valore(bil_Agricolo.FfPcFornitori);
            lblPassCorrenti.Text = FF_PC.ToString();

            decimal FF_PConso = valore(bil_Agricolo.FfPcDebiti) + valore(bil_Agricolo.FfPcMutui);
            lblPassConsolidate.Text = FF_PConso.ToString();

            decimal FF_MP = valore(bil_Agricolo.FfMpCapitale) + valore(bil_Agricolo.FfMpRiserve) + valore(bil_Agricolo.FfMpUtile);
            lblMezziPropri.Text = FF_MP.ToString();

            lblFontiFinanziamento.Text = Convert.ToString(FF_PC + FF_PConso + FF_MP);

            //Conto Economico 
            decimal PLV = valore(bil_Agricolo.PlvRicaviNetti) + valore(bil_Agricolo.PlvRicaviAttivita) + valore(bil_Agricolo.PlvRimanenzeFinali) - valore(bil_Agricolo.PlvRimanenzeIniziali);
            lblPLV.Text = PLV.ToString();

            decimal VA = PLV - valore(bil_Agricolo.VaCostiMatPrime) - valore(bil_Agricolo.VaCostiAttConnesse) - valore(bil_Agricolo.VaNoleggi) - valore(bil_Agricolo.VaManutenzioni) - valore(bil_Agricolo.VaSpeseGenerali) - valore(bil_Agricolo.VaAffitti) - valore(bil_Agricolo.VaAltriCosti);
            lblVA.Text = VA.ToString();

            decimal PN = VA - valore(bil_Agricolo.PnAmmFabbricati) - valore(bil_Agricolo.PnAmmMacchine) - valore(bil_Agricolo.PnAmmPiantagioni);
            lblPN.Text = PN.ToString();

            decimal RO = PN - valore(bil_Agricolo.RoSalari) - valore(bil_Agricolo.RoOneri);
            lblRO.Text = RO.ToString();

            decimal RN_PAC = RO + valore(bil_Agricolo.RnPacRicavi) - valore(bil_Agricolo.RnPacCosti) + valore(bil_Agricolo.RnPacProventi) - valore(bil_Agricolo.RnPacPerdite) + valore(bil_Agricolo.RnPacInteressiAttivi) - valore(bil_Agricolo.RnPacInteressiPassivi) - valore(bil_Agricolo.RnPacImposte) + valore(bil_Agricolo.RnPacContributiPac);
            lblRNPAC.Text = RN_PAC.ToString();

            decimal CASH = RN_PAC + valore(bil_Agricolo.PnAmmFabbricati) + valore(bil_Agricolo.PnAmmMacchine) + valore(bil_Agricolo.PnAmmPiantagioni);
            lblCash.Text = CASH.ToString();
            decimal MNL = CASH + valore(bil_Agricolo.MnlRedditiFam) - valore(bil_Agricolo.MnlRimborso) - valore(bil_Agricolo.MnlPrelievi);
            lblMNL.Text = MNL.ToString();




        }

        private decimal valore(SiarLibrary.NullTypes.DecimalNT val)
        {
            if (val != null)
                return val;
            else return 0;
        }
        private void Nuovo_bilancio()
        {

            hdnId.Value = string.Empty;
            _dataSource = null;
            tbBilancio.DataBind();
            txtDataBilancio.Text = string.Empty;
            lblCash.Text = string.Empty;
            lblMNL.Text = string.Empty;
            lblPLV.Text = string.Empty;
            lblPN.Text = string.Empty;
            lblRNPAC.Text = string.Empty;
            lblRO.Text = string.Empty;
            lblVA.Text = string.Empty;
            lblCapitaleAgrario.Text = string.Empty;
            lblCapitaleCircolante.Text = string.Empty;
            lblCapitaleFisso.Text = string.Empty;
            lblCapitaleFondiario.Text = string.Empty;
            lblDispFinan.Text = string.Empty;
            lblFontiFinanziamento.Text = string.Empty;
            lblImmFinanziarie.Text = string.Empty;
            lblLiqDifferenti.Text = string.Empty;
            lblLiqImmediate.Text = string.Empty;
            lblMezziPropri.Text = string.Empty;
            lblPassConsolidate.Text = string.Empty;
            lblPassCorrenti.Text = string.Empty;
            lblTotImpieghi.Text = string.Empty;

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Redirect("ChecklistAmmissibilita.aspx?iddom=" + ucInfoDomanda.Progetto.IdProgetto);
        }
    }
}
