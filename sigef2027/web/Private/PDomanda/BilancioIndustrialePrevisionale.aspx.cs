using System;
using System.Web.UI.WebControls;

namespace web.Private.PDomanda
{
    public partial class BilancioIndustrialePrevisionale : SiarLibrary.Web.ProgettoPage
    {
        SiarBLL.BilancioIndustrialeCollectionProvider bilancio_Industriale_provider = new SiarBLL.BilancioIndustrialeCollectionProvider();
        SiarLibrary.BilancioIndustriale bil_Industriale = new SiarLibrary.BilancioIndustriale();
        SiarLibrary.BilancioIndustrialeCollection bil_Industriale_col = new SiarLibrary.BilancioIndustrialeCollection();
        SiarLibrary.ImpresaStorico impresa = new SiarLibrary.ImpresaStorico();

        protected void Page_Load(object sender, EventArgs e)
        {
            bil_Industriale_col = bilancio_Industriale_provider.Find(null, null, Progetto.IdProgetto, null, null, true);

        }


        protected override void OnPreRender(EventArgs e)
        {

            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbBilancio.Visible = true;
                    ucSiarNewTab.Width = tbBilancio.Width;
                    txtAnno.AddJSAttribute("onblur", "ControlloAnno(event)");
                    if (string.IsNullOrEmpty(hdnId.Value)) btnElimina.Enabled = false;
                    if (bil_Industriale.IdBilancioIndustriale == null) bil_Industriale = bil_Industriale_col.CollectionGetById(hdnId.Value);
                    #region onblur Patrimoniale
                    txtTACrediti.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtImmImmateriali.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtImmMateriali.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtImmPartecipazioni.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtImmCrediti.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtACRimanenze.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtACClienti.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtACaltri.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtACDepPostale.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtACDispoLiquide.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtTARatei.AddJSAttribute("onblur", "PatrimonialeAttivo()");
                    txtTPCapitale.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPRiserve.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPriserveRival.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPRisLegale.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPazioniproprie.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPRiserva904.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTpAltreRiserveStat.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPaltreRiserve.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPutilePrecedenti.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPutiliesercizio.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPFondi.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPFineRapp.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPdebBanche.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPdebfinanziatori.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPdebFornitori.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPdebPrevidenziali.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPAltriDebiti.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    txtTPRateiRisconti.AddJSAttribute("onblur", "PatrimonialePassivo()");
                    #endregion
                    #region onblur ContoEconomico
                    txtPLVricaviVendite.AddJSAttribute("onblur", "ContoEconomico()");
                    txtPLValtriRicavi.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPmaterieprime.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPservizi.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPbeniterzi.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPersonale.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPammortamenti.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPvarRimanenze.AddJSAttribute("onblur", "ContoEconomico()");
                    txtCPoneri.AddJSAttribute("onblur", "ContoEconomico()");
                    txtPOFaltriproventi.AddJSAttribute("onblur", "ContoEconomico()");
                    txtPOFinteressi.AddJSAttribute("onblur", "ContoEconomico()");
                    txtRettAttFin.AddJSAttribute("onblur", "ContoEconomico()");
                    txtPOSProventiStraor.AddJSAttribute("onblur", "ContoEconomico()");
                    txtPOSoneri.AddJSAttribute("onblur", "ContoEconomico()");
                    txtTotImposte.AddJSAttribute("onblur", "ContoEconomico()");
                    #endregion

                    btnElimina.Enabled = AbilitaModifica;
                    btnSalva.Enabled = AbilitaModifica;
                    break;
                default:
                    tbRiepilogoBilanci.Visible = true;
                    hdnId.Value = string.Empty;
                    ucSiarNewTab.Width = tbRiepilogoBilanci.Width;
                    dgBilancio.DataSource = bil_Industriale_col;
                    if (bil_Industriale_col.Count == 0)
                        dgBilancio.Titolo = "Nessun bilancio inserito per l'impresa specificata.";
                    dgBilancio.ItemDataBound += new DataGridItemEventHandler(dgBilancio_ItemDataBound);
                    dgBilancio.DataBind();
                    break;
            }
            base.OnPreRender(e);
        }
        void dgBilancio_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                SiarLibrary.BilancioIndustriale bi = (SiarLibrary.BilancioIndustriale)dgi.DataItem;
                dgi.Cells[0].Text = " Bilancio  d'esercizio  del " + bi.DataBilancio.ToFullYearString();
                e.Item.Cells[2].Text = "<input type='button' style='width:70px' class='ButtonGrid' value='Dettaglio' onclick='dettaglioBil("
                    + bi.IdBilancioIndustriale + ")' />";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int idB;
            if (!int.TryParse(hdnId.Value, out idB)) ShowError("Il bilancio selzionato non è valido. ");
            else { ucSiarNewTab.TabSelected = 2; VisualizzaBilancio(idB); }
        }

        protected void btnNuovo_Click(object sender, EventArgs e)
        {

            Nuovo_bilancio();
        }
        private void VisualizzaBilancio(int IdBilancio)
        {
            SiarLibrary.BilancioIndustriale bil_Industriale = bil_Industriale_col.CollectionGetById(IdBilancio);

            hdnId.Value = IdBilancio.ToString();
            _dataSource = bil_Industriale;
            tbBilancio.DataBind();

            txtDataBilancio.Text = bil_Industriale.DataBilancio.ToFullYearString();

            //Stato Patrimoniale - ATTIVO
            decimal TotImmFinan = valore(bil_Industriale.TaImmPartecipazioni) + valore(bil_Industriale.TaImmCrediti);
            lblTaImmFinanziarie.Text = "€  " + TotImmFinan.ToString();

            decimal TotImmob = valore(bil_Industriale.TaImmImmateriali) + valore(bil_Industriale.TaImmobMateriali) + valore(bil_Industriale.TaImmPartecipazioni) + valore(bil_Industriale.TaImmCrediti);
            lblTAtotImm.Text = "€  " + TotImmob.ToString();

            decimal AcCreditoVerso = valore(bil_Industriale.TaAcCreditiClienti) + valore(bil_Industriale.TaAcCreditiAltri);
            lblACTotCreditiVerso.Text = "€  " + AcCreditoVerso.ToString();
            decimal TotAttivoCirc = valore(bil_Industriale.TaAcRimanenze) + valore(bil_Industriale.TaAcDepPostali) + valore(bil_Industriale.TaAcDispoLiquide) + AcCreditoVerso;
            lblTotAttCirc.Text = "€  " + TotAttivoCirc.ToString();

            lblTotaleAttivo.Text = "€  " + Convert.ToString(valore(bil_Industriale.TaCreditiSoci) + TotImmob + TotAttivoCirc + valore(bil_Industriale.TaRateiRisconti));
            //Stato Patrimoniale - PASSIVO
            decimal TotRiserveStatut = valore(bil_Industriale.TpPnRiserva904) + valore(bil_Industriale.TpPnRiserveStatutarie);
            lblTPtotriserveStat.Text = "€  " + TotRiserveStatut.ToString();
            decimal TotPatrimonioNetto = valore(bil_Industriale.TpPnCapitale) + valore(bil_Industriale.TpPnSovrapAzioni) + valore(bil_Industriale.TpPnRisRivalutazione) + valore(bil_Industriale.TpPnRisLegale) + valore(bil_Industriale.TpPnAzioniProprie) + valore(bil_Industriale.TpPnAltreRiserve) + TotRiserveStatut + valore(bil_Industriale.TpPnUtiliPrecedenti) + valore(bil_Industriale.TpPnUtiliEsercizio);
            lblTPTotPatrNetto.Text = "€  " + TotPatrimonioNetto.ToString();

            decimal TotDebiti = valore(bil_Industriale.TpDebitiBanche) + valore(bil_Industriale.TpDebitiFinanziatori) + valore(bil_Industriale.TpDebitiFornitori) + valore(bil_Industriale.TpDebitiIstPrevid) + valore(bil_Industriale.TpAltriDebiti);
            lblTPDebiti.Text = "€  " + TotDebiti.ToString();

            lblTotalePassivo.Text = "€  " + Convert.ToString(TotPatrimonioNetto + valore(bil_Industriale.TpFondiRischiOneri) + valore(bil_Industriale.TpFineRapporto) + TotDebiti + valore(bil_Industriale.TpRateiRisconti));

            //Conto Economico 

            decimal PLV = valore(bil_Industriale.PlvRicaviVendita) + valore(bil_Industriale.PlvAltriRicavi);
            lblPLV.Text = "€  " + PLV.ToString();

            decimal TotCostiProduzione = valore(bil_Industriale.CpMateriePrime) + valore(bil_Industriale.CpServizi) + valore(bil_Industriale.CpBeniTerzi) + valore(bil_Industriale.CpPersonale) + valore(bil_Industriale.CpAmmSvalutazioni) + valore(bil_Industriale.CpVarRimanenze) + valore(bil_Industriale.CpOneri);
            lblCPtotale.Text = "€  " + TotCostiProduzione.ToString();

            decimal DiffPlvCp = PLV - TotCostiProduzione;
            lblDiffPlvCp.Text = "€  " + DiffPlvCp.ToString();

            decimal DiffProventiOneri = valore(bil_Industriale.PofAltriProventi) - valore(bil_Industriale.PofInteressiOneri);
            lblPOFtotale.Text = "€  " + DiffProventiOneri.ToString();

            decimal TotPartstraordinarie = valore(bil_Industriale.PosProventiStraord) - valore(bil_Industriale.PosOneriStraord);
            lblPOStotale.Text = "€  " + TotPartstraordinarie.ToString();

            // decimal TotPrimaImposte = PLV - TotCostiProduzione + DiffProventiOneri + valore(bil_Industriale.RettValAttFinanziarie) + TotPartstraordinarie;
            lblTotPrimaImposte.Text = "€  " + valore(bil_Industriale.TotPrimaImposte);


            decimal RisultatoEsercizio = valore(bil_Industriale.TotPrimaImposte) - valore(bil_Industriale.ImposteReddito);
            lblRisutatoEsercizio.Text = "€  " + RisultatoEsercizio.ToString();
            lblUtileEsercizio.Text = "€  " + RisultatoEsercizio.ToString();
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
            txtAnno.Text = string.Empty;
            txtDataBilancio.Text = string.Empty;
            lblACTotCreditiVerso.Text = string.Empty;
            lblCPtotale.Text = string.Empty;
            lblDiffPlvCp.Text = string.Empty;
            lblPLV.Text = string.Empty;
            lblPOFtotale.Text = string.Empty;
            lblPOStotale.Text = string.Empty;
            lblRisutatoEsercizio.Text = string.Empty;
            lblTaImmFinanziarie.Text = string.Empty;
            lblTAtotImm.Text = string.Empty;
            lblTotaleAttivo.Text = string.Empty;
            lblTotalePassivo.Text = string.Empty;
            lblTotAttCirc.Text = string.Empty;
            lblTotPrimaImposte.Text = string.Empty;
            lblTPDebiti.Text = string.Empty;
            lblTPTotPatrNetto.Text = string.Empty;
            lblTPtotriserveStat.Text = string.Empty;
            lblUtileEsercizio.Text = string.Empty;

        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bilancio_Industriale_provider = new SiarBLL.BilancioIndustrialeCollectionProvider();
            bil_Industriale = new SiarLibrary.BilancioIndustriale();
            try
            {

                int anno, idBilancio;
                DateTime data_bilancio;
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(txtAnno.Text, out anno) || txtAnno.Text.Length != 4) throw new Exception("L'anno indicato non è corretto.");
                if (anno < DateTime.Now.Year) throw new Exception("Attenzione l'anno inserito non è corretto. Il bilancio deve riferirsi ad un anno successivo il " + DateTime.Now.Year);
                if (!DateTime.TryParse(txtDataBilancio.Text, out data_bilancio)) throw new Exception("Attenzione la data inserita non è corretta.");

                bilancio_Industriale_provider.DbProviderObj.BeginTran();
                if (!string.IsNullOrEmpty(hdnId.Value))
                {
                    if (!int.TryParse(hdnId.Value, out idBilancio)) throw new Exception("Attenzione! Il bilancio selezionato non è valido.");
                    bil_Industriale = bilancio_Industriale_provider.GetById(hdnId.Value);
                }
                else
                {
                    foreach (SiarLibrary.BilancioIndustriale b in bil_Industriale_col)
                        if (b.Anno == anno) throw new Exception("Attenzione! Il bilancio, per l'anno indicato, è già stato inserito.");
                    bil_Industriale.Provider = bilancio_Industriale_provider;
                    bil_Industriale.IdProgetto = Progetto.IdProgetto;
                    bil_Industriale.Previsionale = true;

                }
                bil_Industriale.Anno = txtAnno.Text;
                bil_Industriale.DataBilancio = data_bilancio;
                bil_Industriale.DataModifica = DateTime.Now;
                //Stato Patrimoniale - Attivo
                bil_Industriale.TaCreditiSoci = txtTACrediti.Text;
                bil_Industriale.TaImmImmateriali = txtImmImmateriali.Text;
                bil_Industriale.TaImmobMateriali = txtImmMateriali.Text;
                bil_Industriale.TaImmPartecipazioni = txtImmPartecipazioni.Text;
                bil_Industriale.TaImmCrediti = txtImmCrediti.Text;

                bil_Industriale.TaAcRimanenze = txtACRimanenze.Text;
                bil_Industriale.TaAcCreditiClienti = txtACClienti.Text;
                bil_Industriale.TaAcCreditiAltri = txtACaltri.Text;

                bil_Industriale.TaAcDepPostali = txtACDepPostale.Text;
                bil_Industriale.TaAcDispoLiquide = txtACDispoLiquide.Text;
                bil_Industriale.TaRateiRisconti = txtTARatei.Text;

                //Stato Patrimoniale - Passivo
                bil_Industriale.TpPnCapitale = txtTPCapitale.Text;
                bil_Industriale.TpPnSovrapAzioni = txtTPRiserve.Text;
                bil_Industriale.TpPnRisRivalutazione = txtTPriserveRival.Text;
                bil_Industriale.TpPnRisLegale = txtTPRisLegale.Text;
                bil_Industriale.TpPnAzioniProprie = txtTPazioniproprie.Text;

                bil_Industriale.TpPnRiserva904 = txtTPRiserva904.Text;
                bil_Industriale.TpPnRiserveStatutarie = txtTpAltreRiserveStat.Text;
                bil_Industriale.TpPnAltreRiserve = txtTPaltreRiserve.Text;
                bil_Industriale.TpPnUtiliPrecedenti = txtTPutilePrecedenti.Text;
                bil_Industriale.TpPnUtiliEsercizio = txtTPutiliesercizio.Text;

                bil_Industriale.TpFondiRischiOneri = txtTPFondi.Text;
                bil_Industriale.TpFineRapporto = txtTPFineRapp.Text;

                bil_Industriale.TpDebitiBanche = txtTPdebBanche.Text;
                bil_Industriale.TpDebitiFinanziatori = txtTPdebfinanziatori.Text;
                bil_Industriale.TpDebitiFornitori = txtTPdebFornitori.Text;
                bil_Industriale.TpDebitiIstPrevid = txtTPdebPrevidenziali.Text;
                bil_Industriale.TpAltriDebiti = txtTPAltriDebiti.Text;

                bil_Industriale.TpRateiRisconti = txtTPRateiRisconti.Text;

                //CONTO ECONOMICO
                bil_Industriale.PlvAltriRicavi = txtPLValtriRicavi.Text;
                bil_Industriale.PlvRicaviVendita = txtPLVricaviVendite.Text;
                bil_Industriale.CpMateriePrime = txtCPmaterieprime.Text;
                bil_Industriale.CpServizi = txtCPservizi.Text;
                bil_Industriale.CpBeniTerzi = txtCPbeniterzi.Text;
                bil_Industriale.CpPersonale = txtCPersonale.Text;
                bil_Industriale.CpAmmSvalutazioni = txtCPammortamenti.Text;
                bil_Industriale.CpVarRimanenze = txtCPvarRimanenze.Text;
                bil_Industriale.CpOneri = txtCPoneri.Text;

                bil_Industriale.PofAltriProventi = txtPOFaltriproventi.Text;
                bil_Industriale.PofInteressiOneri = txtPOFinteressi.Text;

                bil_Industriale.RettValAttFinanziarie = txtRettAttFin.Text;
                bil_Industriale.PosOneriStraord = txtPOSoneri.Text;
                bil_Industriale.PosProventiStraord = txtPOSProventiStraor.Text;


                bil_Industriale.TotPrimaImposte = (valore(bil_Industriale.PlvAltriRicavi) + valore(bil_Industriale.PlvRicaviVendita)) - (valore(bil_Industriale.CpMateriePrime) +
               valore(bil_Industriale.CpServizi) + valore(bil_Industriale.CpBeniTerzi) + valore(bil_Industriale.CpPersonale) +
                valore(bil_Industriale.CpAmmSvalutazioni) + valore(bil_Industriale.CpVarRimanenze) + valore(bil_Industriale.CpOneri)) + valore(bil_Industriale.PofAltriProventi)
                - valore(bil_Industriale.PofInteressiOneri) + valore(bil_Industriale.RettValAttFinanziarie) - valore(bil_Industriale.PosOneriStraord) +
                valore(bil_Industriale.PosProventiStraord);


                bil_Industriale.ImposteReddito = txtTotImposte.Text;

                bilancio_Industriale_provider.Save(bil_Industriale);
                new SiarBLL.ProgettoCollectionProvider(bilancio_Industriale_provider.DbProviderObj).AggiornaProgetto(Progetto, Operatore.Utente.IdUtente);
                bilancio_Industriale_provider.DbProviderObj.Commit();
                ShowMessage("Bilancio salvato correttamente");
                if (string.IsNullOrEmpty(hdnId.Value))
                    bil_Industriale_col.Add(bil_Industriale);
                else
                {
                    bil_Industriale_col.Remove(bil_Industriale_col.CollectionGetById(hdnId.Value));
                    bil_Industriale_col.Add(bil_Industriale);

                }
                hdnId.Value = bil_Industriale.IdBilancioIndustriale;
                VisualizzaBilancio(bil_Industriale.IdBilancioIndustriale);
            }
            catch (Exception ex)
            {
                bilancio_Industriale_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_bil;
                if (!AbilitaModifica) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.ModificaDisabilitata);
                if (!int.TryParse(hdnId.Value, out id_bil))
                    throw new Exception("Nessun dato selezionato.");
                bilancio_Industriale_provider.Delete(bilancio_Industriale_provider.GetById(id_bil));
                ShowMessage("Bilancio eliminato correttamente.");
                bil_Industriale_col.Remove(bil_Industriale_col.CollectionGetById(id_bil));
                Nuovo_bilancio();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally { ucSiarNewTab.TabSelected = 1; }
        }
    }
}
