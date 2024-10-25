using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using SiarLibrary.Extensions;
using SiarLibrary;
using SiarBLL;
using System.Linq;

namespace web.Private.PPagamento
{
    public partial class SpeseSostenute : SiarLibrary.Web.DomandaPagamentoPage
    {
        SpeseSostenuteCollectionProvider spese_provider;
        GiustificativiCollectionProvider giustificativi_provider;
        SiarLibrary.SpeseSostenute spesa_selezionata;
        bool spese_presenti = false;

        IntegrazioniPerDomandaDiPagamentoCollectionProvider integrazione_provider;
        IntegrazioniPerDomandaDiPagamento integrazione_selezionata = null;
        IntegrazioneSingolaDiDomandaCollectionProvider integrazione_singola_provider;
        IntegrazioneSingolaDiDomanda integrazione_singola_selezionata = null;
        int id_integrazione_di_domanda_singola;
        bool bloccaRimuovi = false;

        SpeseSostenuteFileCollectionProvider file_spesa_provider;
        SpeseSostenuteFile file_spesa;

        PianoInvestimentiCollectionProvider investimenti_provider;

        protected void Page_Load(object sender, EventArgs e)
        {
            spese_provider = new SpeseSostenuteCollectionProvider(PagamentoProvider.DbProviderObj);
            giustificativi_provider = new GiustificativiCollectionProvider(PagamentoProvider.DbProviderObj);
            investimenti_provider = new PianoInvestimentiCollectionProvider(PagamentoProvider.DbProviderObj);

            ucZoomLoaderGiustificativo.KeySearch += "|IdProgetto:" + DomandaPagamento.IdProgetto + ":h";
            AbilitaModifica = AbilitaModifica && DomandaPagamento.IdFidejussione == null;
            ufGiustificativo.AbilitaModifica = ufPagamento.AbilitaModifica = AbilitaModifica;

            if (Session["id_spesa_integrazione"] != null || Session["id_giustificativo_integrazione"] != null)
                ucSiarNewTab.TabSelected = 2;
        }

        protected override void OnPreRender(EventArgs e)
        {
            AbilitaModifica = AbilitaModifica && DomandaPagamento.Segnatura == null;
            SpeseSostenuteCollection spese = spese_provider.GetSpeseSostenuteDomandaPagamento(DomandaPagamento.IdDomandaPagamento, null, null);
            spese_presenti = spese.Count > 0;
            switch (ucSiarNewTab.TabSelected)
            {
                case 2:
                    tbElenco.Visible = false;
                    lnkGiustificativo.HRef = "javascript:" + (AbilitaModifica ? ucZoomLoaderGiustificativo.SearchFunction : "alert('Non è possibile apportare modifiche alla domanda di pagamento.');");
                    lstPagamento.DataBind();
                    lstTipoGiustificativo.DataBind();
                    if (AbilitaModifica)
                    {
                        Session["id_progetto"] = Progetto.IdProgetto.Value;
                        txtPivaFornitore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this, event, 'SNCVZCercaFornitoriProgetto');");
                        txtImportoLordoPagamento.AddJSAttribute("onblur", "return validaImporti(true, event);");
                        txtPivaFornitore.AddJSAttribute("onblur", "stopcf=false; setTimeout(function(){ if (!stopcf) ctrlCF();},300);");
                    }
                    caricaSpesaSelezionata();
                    break;
                default:
                    tbNuovaSpesa.Visible = false;
                    ucSiarNewTab.Width = tbElenco.Width;
                    hdnIdGiustificativo.Value = "";
                    ucZoomLoaderGiustificativo.SelectedValue = null;
                    ucZoomLoaderGiustificativo.SelectedText = null;
                    btnStampa.Attributes.Add("onclick", "SNCVisualizzaReport('rptIstruttoriaSpeseSostenute',2,'IdDomandaPagamento="
                        + DomandaPagamento.IdDomandaPagamento + "');");

                    // filtro
                    bool? ckIntegraz = null;
                    if (ckInintegrazione.Checked)
                        ckIntegraz = true;
                    lstFiltroTipoGiustificativo.DataBind();
                    spese = spese.FiltraPerDatiGiustificativoIstruttoriaSpeseSostenute(txtFiltroNumero.Text, txtFiltroData.Text, lstFiltroTipoGiustificativo.SelectedValue,
                        txtFiltroOggetto.Text, ckIntegraz);
                    dgSpese.DataSource = spese;
                    lblNrRecord.Text = spese.Count.ToString();
                    dgSpese.ItemDataBound += new DataGridItemEventHandler(dgSpese_ItemDataBound);
                    //dgSpese.Titolo = "&nbsp;&nbsp;<b><em>Elementi trovati: " + ((CustomCollection)dgSpese.DataSource).Count.ToString() + "</em></b>";
                    //dgSpese.MostraTotale("DataField", 7, 8);
                    dgSpese.DataBind();
                    if (DomandaPagamento.InIntegrazione == null || DomandaPagamento.InIntegrazione == false)
                        dgSpese.Columns[10].Visible = false;
                    break;
            }

            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione)
                riempiCampiIntegrazione();

            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            if (!spese_presenti && !DomandaPagamento.TpAppaltoStrumentiFinanziari)
            {
                ucWorkflowPagamento.ProseguiMessaggio = "Attenzione! Per proseguire occorre inserire almeno una voce di pagamento.";
                ucWorkflowPagamento.ProseguiAbilitato = false;
            }
            base.OnPreRenderComplete(e);            
        }

        private void riempiCampiIntegrazione()
        {
            integrazione_provider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();

            if (Session["id_integrazione_domanda"] != null)
                integrazione_selezionata = integrazione_provider.GetById(int.Parse(Session["id_integrazione_domanda"].ToString()));
            else
            {
                var integrazioni_collection = integrazione_provider.Find(null, DomandaPagamento.IdDomandaPagamento, false, null);
                integrazione_selezionata = integrazioni_collection[0];
            }

            integrazione_selezionata = integrazione_provider.GetById(integrazione_selezionata.IdIntegrazioneDomandaDiPagamento);

            if(integrazione_selezionata.SegnaturaIstruttore == null)
                Redirect(PATH_PPAGAMENTO + "GestioneLavori.aspx", "L'istruttore sta preparando una richiesta di integrazioni, impossibile accedere", true);

            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            var integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, null, null, null, null);
            var integrazioni_singole_list = integrazioni_singole_collection.ToArrayList<IntegrazioneSingolaDiDomanda>();

            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "ALL")
                    .Count() < 1)
                btnAllegati.Visible = false;
            if (integrazioni_singole_list
                    .Where(i => i.CodTipoIntegrazione == "INV")
                    .Count() < 1)
                btnInvestimenti.Visible = false;

            integrazioni_singole_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "GIU", null, null, null);
            integrazioni_singole_collection.AddCollection(integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "PAG", null, null, null));
            if (integrazione_singola_selezionata != null)
            {
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                integrazioni_singole_collection = integrazioni_singole_collection.SubSelect(id_integrazione_di_domanda_singola, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                trDettaglioIntegrazioneSingolaSelezionata.Visible = true;
                riempiCampiIntegrazioneSingola();
            }

            dgIntegrazioni.DataSource = integrazioni_singole_collection;
            dgIntegrazioni.SetTitoloNrElementi();
            dgIntegrazioni.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgIntegrazioni_ItemDataBound);
            dgIntegrazioni.DataBind();

            abilitaComponentiIntegrazione();
        }

        protected void abilitaComponentiIntegrazione()
        {
            ucWorkflowPagamento.InIntegrazione = true;
            trIntegrazioniRichieste.Visible = true;

            if (integrazione_selezionata.SegnaturaBeneficiario == null)
                abilitaComponentiIntegrazione(false);
            else
                abilitaComponentiIntegrazione(true);

            /*
            //Giustificativo
            if (integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "GIU", null, null, null).Count > 0)
            {
                int idgiustificativo;
                if (int.TryParse(hdnIdGiustificativo.Value, out idgiustificativo))
                {
                    giustificativi_provider = new GiustificativiCollectionProvider();
                    var giustificativo_selezionato = giustificativi_provider.GetById(idgiustificativo);
                    if (giustificativo_selezionato.InIntegrazione != null && giustificativo_selezionato.InIntegrazione)
                    {
                        tdRichiestaIntegrazioneGiustificativo.Visible = true;
                        ufGiustificativo.AbilitaModifica = true;
                        btnCerca.Enabled = true;

                        btnSalva.Enabled = true;
                    }
                }
            }

            //Pagamento
            if (integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "PAG", null, null, null).Count > 0)
            {
                int idspesa;
                if (int.TryParse(hdnIdSpesaSostenuta.Value, out idspesa))
                {
                    spese_provider = new SpeseSostenuteCollectionProvider();
                    var spesa_selezionata = spese_provider.GetById(idspesa);
                    if (spesa_selezionata.InIntegrazione != null && spesa_selezionata.InIntegrazione)
                    {
                        tdRichiestaIntegrazionePagamento.Visible = true;
                        ufPagamento.AbilitaModifica = true;

                        btnSalva.Enabled = true;
                    }
                }
            }
            */
        }

        protected void abilitaComponentiIntegrazione(bool segnatura)
        {
            //if (!segnatura)
            //{
            var modifica_giustificativo = verificaAbilitaComponentiIntegrazioneGiustificativo(segnatura);
            var modifica_spesa = verificaAbilitaComponentiIntegrazionePagamento(segnatura);

            if (modifica_giustificativo || modifica_spesa)
                btnSalva.Enabled = true;
            else
                btnSalva.Enabled = false;
            //}
        }

        protected bool verificaAbilitaComponentiIntegrazioneGiustificativo(bool segnatura)
        {
            //Verifico se esistono integrazioni richieste di tipo giustificativo
            var integrazione_singola_collection = integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "GIU", null, null, null);
            if (integrazione_singola_collection.Count > 0)
            {
                int idgiustificativo;
                if (int.TryParse(hdnIdGiustificativo.Value, out idgiustificativo))
                {
                    giustificativi_provider = new GiustificativiCollectionProvider();
                    var giustificativo_selezionato = giustificativi_provider.GetById(idgiustificativo);

                    if (!segnatura)
                    {
                        //Se non è stata ancora protocollata la risposta ed è richiesta un integrazione su questo giustificativo posso modificarlo
                        if (giustificativo_selezionato.InIntegrazione != null && giustificativo_selezionato.InIntegrazione)
                        {
                            tdRichiestaIntegrazioneGiustificativo.Visible = true;
                            ufGiustificativo.AbilitaModifica = true;
                            btnCerca.Enabled = true;
                            btnScaricaFornitore.Enabled = true;

                            return true;
                        }
                    }
                    else
                    {
                        //Se è stata protocollata la risposta, è richiesta un integrazione su questo giustificativo ma non risulta completata posso modificarlo
                        if (giustificativo_selezionato.InIntegrazione != null && giustificativo_selezionato.InIntegrazione)
                        {
                            //IntegrazioneSingolaDiDomanda integrazione_sing = integrazione_singola_provider.GetByIdGiustificativo(giustificativo_selezionato.IdGiustificativo, null, null, false)[0];
                            if (integrazione_singola_provider.GetByIdGiustificativo(giustificativo_selezionato.IdGiustificativo, true, true, false).Count > 0) //if (integrazione_sing.SingolaIntegrazioneCompletataBeneficiario && integrazione_sing.SingolaIntegrazioneCompletataIstruttore)
                                return false;

                            tdRichiestaIntegrazioneGiustificativo.Visible = true;
                            ufGiustificativo.AbilitaModifica = true;
                            btnCerca.Enabled = true;
                            btnScaricaFornitore.Enabled = true;

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected bool verificaAbilitaComponentiIntegrazionePagamento(bool segnatura)
        {
            //Verifico se esistono integrazioni richieste di tipo pagamento
            if (integrazione_singola_provider.Find(null, integrazione_selezionata.IdIntegrazioneDomandaDiPagamento, "PAG", null, null, null).Count > 0)
            {
                if (spesa_selezionata == null)
                {
                    int idspesa;
                    if (int.TryParse(hdnIdSpesaSostenuta.Value, out idspesa))
                    {
                        spese_provider = new SpeseSostenuteCollectionProvider();
                        spesa_selezionata = spese_provider.GetById(idspesa);
                    }
                }

                if (spesa_selezionata != null)
                {
                    if (!segnatura)
                    {
                        //Se non è stata ancora protocollata la risposta ed è richiesta un integrazione su questo pagamento posso modificarlo
                        if (spesa_selezionata.InIntegrazione != null && spesa_selezionata.InIntegrazione)
                        {
                            tdRichiestaIntegrazionePagamento.Visible = true;
                            ufPagamento.AbilitaModifica = true;
                            ufFileSpesaSostenuta.AbilitaModifica = true;
                            btnAssociaFileSpesa.Enabled = true;

                            return true;
                        }
                    }
                    else
                    {
                        //Se è stata protocollata la risposta, è richiesta un integrazione su questo pagamento ma non risulta completata posso modificarlo
                        if (spesa_selezionata.InIntegrazione != null && spesa_selezionata.InIntegrazione)
                        {
                            //IntegrazioneSingolaDiDomanda integrazione_sing = integrazione_singola_provider.GetByIdSpesa(spesa_selezionata.IdSpesa, null, null, false)[0];
                            if (integrazione_singola_provider.GetByIdSpesa(spesa_selezionata.IdSpesa, true, true, false).Count > 0)
                            {
                                divInserimentoFileSpese.Visible = false;
                                bloccaRimuovi = true;
                                return false;
                            }

                            tdRichiestaIntegrazionePagamento.Visible = true;
                            ufPagamento.AbilitaModifica = true;
                            ufFileSpesaSostenuta.AbilitaModifica = true;

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected void riempiCampiIntegrazioneSingola()
        {
            //Campi istruttore
            txtDataRichiesta.Text = integrazione_singola_selezionata.DataRichiestaIntegrazioneIstruttore;
            txtTipoIntegrazione.Text = integrazione_singola_selezionata.DescrizioneTipoIntegrazione;
            txtNoteSingolaIntegrazioneIstruttore.Text = integrazione_singola_selezionata.NoteIntegrazioneIstruttore;
            comboCompletataSingolaIntegrazioneDomandaIstruttore.ClearSelection();
            string val_istruttore = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
                val_istruttore = "true";
            comboCompletataSingolaIntegrazioneDomandaIstruttore.Items.FindByValue(val_istruttore).Selected = true;

            //Campi beneficiario
            if (integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario == null)
                txtDataRilascio.Text = new SiarLibrary.NullTypes.DatetimeNT(DateTime.Now);
            else
                txtDataRilascio.Text = integrazione_singola_selezionata.DataRilascioIntegrazioneBeneficiario;
            txtNoteSingolaIntegrazioneBeneficiario.Text = integrazione_singola_selezionata.NoteIntegrazioneBeneficiario;
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClearSelection();
            string val_beneficario = "false";
            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataBeneficiario)
                val_beneficario = "true";
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.Items.FindByValue(val_beneficario).Selected = true;

            if (integrazione_singola_selezionata.DescrizioneTipoIntegrazione != null && integrazione_singola_selezionata.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo"))
            {
                var giustificativo = new GiustificativiCollectionProvider().GetById(integrazione_singola_selezionata.IdGiustificativo);
                txtNumGiustificativoDgIntegrazione.Text = giustificativo.Numero;
                txtDataGiustificativoDgIntegrazione.Text = giustificativo.Data;
                txtRSFornitoreDgIntegrazione.Text = giustificativo.DescrizioneFornitore;
                txtDescGiustificativoDgIntegrazione.Text = giustificativo.Descrizione;
            }
            else if (integrazione_singola_selezionata.DescrizioneTipoIntegrazione != null && integrazione_singola_selezionata.DescrizioneTipoIntegrazione.Equals("Spese sostenute pagamento"))
            {
                var spesa = new SpeseSostenuteCollectionProvider().GetById(integrazione_singola_selezionata.IdSpesa);
                txtNumGiustificativoDgIntegrazione.Text = spesa.Numero;
                txtDataGiustificativoDgIntegrazione.Text = spesa.Data;
                txtRSFornitoreDgIntegrazione.Text = spesa.DescrizioneFornitore;
                txtDescGiustificativoDgIntegrazione.Text = spesa.Descrizione;
                txtTipoPagamentoDgIntegrazione.Text = spesa.TipoPagamento;
                txtEstremiPagamentoDgIntegrazione.Text = spesa.Estremi;
            }
            else
                tbInformazioniAggiuntive.Visible = false;

            if (integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore != null && integrazione_singola_selezionata.SingolaIntegrazioneCompletataIstruttore)
            {
                txtDataRilascio.Enabled = false;
                txtNoteSingolaIntegrazioneBeneficiario.Enabled = false;
                btnSalvaSingolaIntegrazione.Enabled = false;
                comboCompletataSingolaIntegrazioneDomandaBeneficiario.Enabled = false;
            }
        }

        protected void gestisciFileSpesaSostenuta()
        {
            SpeseSostenuteFileCollection file_spesa_collection = null;
            file_spesa_provider = new SpeseSostenuteFileCollectionProvider();
            gestisciFileSingoloSpesaSostenuta();

            try
            {
                if (file_spesa != null)
                {
                    file_spesa_collection = new SpeseSostenuteFileCollection();
                    file_spesa_collection.Add(file_spesa);
                }
                else
                    file_spesa_collection = file_spesa_provider.GetByIdSpesa(spesa_selezionata.IdSpesa, null);
            }
            catch (Exception ex) { ShowError(ex.ToString()); }

            if (file_spesa_collection.Count > 0
                || (DomandaPagamento != null && DomandaPagamento.InIntegrazione &&
                    spesa_selezionata.InIntegrazione != null && spesa_selezionata.InIntegrazione))
            {
                integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                if (integrazione_singola_provider.GetByIdSpesa(spesa_selezionata.IdSpesa, true, true, false).Count > 0)
                    bloccaRimuovi = true;

                trFileSpesaSostenuta.Visible = true;
                dgFileSpeseSostenute.DataSource = file_spesa_collection;
                dgFileSpeseSostenute.SetTitoloNrElementi();
                dgFileSpeseSostenute.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(dgFileSpeseSostenute_ItemDataBound);
                dgFileSpeseSostenute.DataBind();
            }
        }

        protected void gestisciFileSingoloSpesaSostenuta()
        {
            int id_file_spesa;
            if (int.TryParse(hdnIdFileSpesaSostenuta.Value, out id_file_spesa))
                file_spesa = new SpeseSostenuteFileCollectionProvider().GetById(id_file_spesa);

            if (file_spesa != null)
            {
                txtDescrizioneFile.Text = file_spesa.Descrizione;
                ufFileSpesaSostenuta.IdFile = file_spesa.IdFile;
            }
            else
            {
                txtDescrizioneFile.Text = null;
                ufFileSpesaSostenuta.IdFile = null;
            }
        }

        private void caricaSpesaSelezionata()
        {
            int id_spesa;
            if (spesa_selezionata == null && int.TryParse(hdnIdSpesaSostenuta.Value, out id_spesa))
                spesa_selezionata = spese_provider.GetById(id_spesa);

            if (spesa_selezionata == null && Session["id_spesa_integrazione"] != null)
            {
                spesa_selezionata = spese_provider.GetById(int.Parse(Session["id_spesa_integrazione"].ToString()));
                Session["id_spesa_integrazione"] = null;
                hdnIdSpesaSostenuta.Value = spesa_selezionata.IdSpesa;
            }

            if (spesa_selezionata == null && Session["id_giustificativo_integrazione"] != null)
            {
                var spese_collection = spese_provider.GetSpeseModificateIntegrazione(DomandaPagamento.IdDomandaPagamento, int.Parse(Session["id_giustificativo_integrazione"].ToString()), DomandaPagamento.IdProgetto, null, null);
                if (spese_collection.Count > 0)
                {
                    spesa_selezionata = spese_collection[0];
                    hdnIdSpesaSostenuta.Value = spesa_selezionata.IdSpesa;
                }
                Session["id_giustificativo_integrazione"] = null;
            }

            if (spesa_selezionata != null)
            {
                hdnIdGiustificativo.Value = spesa_selezionata.IdGiustificativo;
                txtDataDocTrasporto.Text = spesa_selezionata.DataDoctrasporto;
                txtDataGiustificativo.Text = spesa_selezionata.DataGiustificativo;
                txtDataPagamento.Text = spesa_selezionata.Data;
                txtDescGiustificativo.Text = spesa_selezionata.Descrizione;
                txtEstremi.Text = spesa_selezionata.Estremi;
                txtImportoGiustificativo.Text = spesa_selezionata.Imponibile;
                txtImportoLordoPagamento.Text = spesa_selezionata.Importo;
                //16-02-2023 Aggiunto inizializzazione del valore netto PASS#187931
                txtImportoNettoPagamento.Text = spesa_selezionata.Netto;
                txtIva.Text = spesa_selezionata.Iva;
                txtNumDocTrasporto.Text = spesa_selezionata.NumeroDoctrasporto;
                txtNumGiustificativo.Text = spesa_selezionata.Numero;

                SiarLibrary.Impresa impresa_cercata = null;
                int id_impresa;
                if (int.TryParse(hdnIdImpresaFornitoreCercato.Value, out id_impresa))
                    impresa_cercata = new ImpresaCollectionProvider().GetById(id_impresa);

                if (impresa_cercata != null)
                {
                    txtPivaFornitore.Text = impresa_cercata.CodiceFiscale;
                    txtRSFornitore.Text = impresa_cercata.RagioneSociale;
                    hdnIdImpresaFornitoreCercato.Value = null;
                }
                else
                {
                    txtPivaFornitore.Text = spesa_selezionata.CfFornitore;
                    txtRSFornitore.Text = spesa_selezionata.DescrizioneFornitore;
                }

                lstPagamento.SelectedValue = spesa_selezionata.CodTipo;
                lstTipoGiustificativo.SelectedValue = spesa_selezionata.CodTipoGiustificativo;
                chkNonRecuperabile.Checked = spesa_selezionata.IvaNonRecuperabile;
                ufGiustificativo.IdFile = spesa_selezionata.IdFileGiustificativo;
                ufPagamento.IdFile = spesa_selezionata.IdFile;
                gestisciFileSpesaSostenuta();

                //Carico datagrid piano investimenti
                SiarLibrary.PianoInvestimentiCollection investimenti = investimenti_provider.GetPianoInvestimentiGiustificativo( DomandaPagamento.IdDomandaPagamento  ,spesa_selezionata.IdGiustificativo);
                if(investimenti.Count>0)
                {
                    divElencoPianoInv.Visible = true;
                    dgInvestimenti.DataSource = investimenti;
                    dgInvestimenti.ItemDataBound += new DataGridItemEventHandler(dgInvestimenti_ItemDataBound);
                    dgInvestimenti.DataBind();
                }
                
                //RegisterClientScriptBlock("return validaImporti(true,null);");
            }
        }

        private void caricaGiustificativo(Giustificativi g)
        {
            if (g != null)
            {
                hdnIdGiustificativo.Value = g.IdGiustificativo;
                lstTipoGiustificativo.SelectedValue = g.CodTipo;
                lstTipoGiustificativo.Enabled = false;
                txtNumGiustificativo.Text = g.Numero;
                txtNumGiustificativo.Enabled = false;
                txtDataGiustificativo.Text = g.Data;
                txtDataGiustificativo.Enabled = false;
                txtNumDocTrasporto.Text = g.NumeroDoctrasporto;
                txtNumDocTrasporto.Enabled = false;
                txtDataDocTrasporto.Text = g.DataDoctrasporto;
                txtDataDocTrasporto.Enabled = false;
                txtImportoGiustificativo.Text = g.Imponibile;
                txtImportoGiustificativo.Enabled = false;
                txtIva.Text = g.Iva;
                txtIva.Enabled = false;
                chkNonRecuperabile.Checked = g.IvaNonRecuperabile;
                chkNonRecuperabile.Enabled = false;
                txtDescGiustificativo.Text = g.Descrizione;
                txtDescGiustificativo.Enabled = false;
                txtPivaFornitore.Text = g.CfFornitore;
                txtPivaFornitore.Enabled = false;
                txtRSFornitore.Text = g.DescrizioneFornitore;
                txtRSFornitore.Enabled = false;
                btnScaricaFornitore.Enabled = false;
                ufGiustificativo.IdFile = g.IdFile;
                ufGiustificativo.AbilitaModifica = false;
            }
        }

        protected void controlloCampiGiustificativo(ref Giustificativi giustificativo, int idSpesa)
        {
            SpeseSostenuteCollection spese = spese_provider.Find(null, giustificativo.IdGiustificativo, null);
            decimal totaleSpeseNette = 0;
            foreach (SiarLibrary.SpeseSostenute s in spese)
            {
                if (!s.DomandaPagamentoAnnullata && s.IdSpesa != idSpesa) totaleSpeseNette += s.Netto.Value;

            }

            if (totaleSpeseNette > giustificativo.Imponibile)
                throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare.");

            //decimal somma = giustificativo.Imponibile - decimal.Parse(txtImportoNettoPagamento.Text);
            //foreach (SiarLibrary.SpeseSostenute s in spese)
            //{
            //    if (!s.DomandaPagamentoAnnullata && s.IdSpesa != idSpesa) somma -= s.Netto.Value;
            //    if (somma < 0)
            //        throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare.");
            //}
        }

        protected void riempiCampiGiustificativo(ref Giustificativi giustificativo)
        {
            giustificativo.IdProgetto = Progetto.IdProgetto;
            giustificativo.CodTipo = lstTipoGiustificativo.Text;
            giustificativo.Data = txtDataGiustificativo.Text;
            giustificativo.Numero = txtNumGiustificativo.Text;
            giustificativo.NumeroDoctrasporto = txtNumDocTrasporto.Text;
            giustificativo.DataDoctrasporto = txtDataDocTrasporto.Text;
            giustificativo.Imponibile = txtImportoGiustificativo.Text;
            //if (txtIva.Text == null || txtIva.Text.Equals(""))
            //    throw new Exception("Iva del giustificativo non valida.");
            giustificativo.Iva = txtIva.Text;
            giustificativo.Descrizione = CleanInput(txtDescGiustificativo.Text);
            giustificativo.CfFornitore = txtPivaFornitore.Text.ToUpper();
            if (txtRSFornitore.Text == null || txtRSFornitore.Text.Equals(""))
            {
                ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
                SiarLibrary.Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);
                if (i != null)
                    txtRSFornitore.Text = i.RagioneSociale;
            }
            giustificativo.DescrizioneFornitore = txtRSFornitore.Text;
            giustificativo.IvaNonRecuperabile = chkNonRecuperabile.Checked;
            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione
                && giustificativo.IdFile != null && !giustificativo.IdFile.GetHashCode().Equals(ufGiustificativo.IdFile.GetHashCode()))
                giustificativo.IdFileModificatoIntegrazione = true;
            giustificativo.IdFile = ufGiustificativo.IdFile;
        }

        protected void riempiCampiSpesaSostenuta(ref SiarLibrary.SpeseSostenute spesa)
        {
            spesa.IdDomandaPagamento = DomandaPagamento.IdDomandaPagamento;
            spesa.Estremi = txtEstremi.Text;
            spesa.Data = txtDataPagamento.Text;
            spesa.CodTipo = lstPagamento.Text;
            spesa.Importo = txtImportoLordoPagamento.Text;
            spesa.Netto = txtImportoNettoPagamento.Text;
            if (DomandaPagamento.InIntegrazione != null && DomandaPagamento.InIntegrazione
                && spesa.IdFile != null && !spesa.IdFile.GetHashCode().Equals(ufPagamento.IdFile.GetHashCode()))
                spesa.IdFileModificatoIntegrazione = true;
            spesa.IdFile = ufPagamento.IdFile;
        }

        private void clearAllFields()
        {
            spesa_selezionata = null;
            hdnIdGiustificativo.Value = "";
            hdnIdSpesaSostenuta.Value = "";
            txtDataDocTrasporto.Text = null;
            txtDataGiustificativo.Text = null;
            txtDataPagamento.Text = null;
            txtDescGiustificativo.Text = null;
            txtEstremi.Text = null;
            txtImportoGiustificativo.Text = null;
            txtIva.Text = null;
            txtImportoLordoPagamento.Text = null;
            txtImportoNettoPagamento.Text = null;
            txtNumDocTrasporto.Text = null;
            txtNumGiustificativo.Text = null;
            txtPivaFornitore.Text = null;
            txtRSFornitore.Text = null;
            lstTipoGiustificativo.ClearSelection();
            lstPagamento.ClearSelection();
            ufPagamento.IdFile = ufGiustificativo.IdFile = null;
        }

        private string CleanInput(string strIn)
        {
            StringBuilder sb = new StringBuilder(strIn.Length);
            foreach (char c in strIn)
            {
                var num_c = (int)c;

                if (num_c >= 131  && num_c <= 146) 
                    continue;
                if (num_c >= 149 && num_c <= 162)  
                    continue;
                if (num_c >= 164 && num_c <= 223)
                    continue;

                sb.Append(c);
            }
            return sb.ToString();
        }

        #region Button_Click

        protected void btnPost_Click(object sender, EventArgs e)
        {
            dgIntegrazioni.SetPageIndex(0);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (ufPagamento.IdFile == null || ufGiustificativo.IdFile == null)
                    throw new Exception("E` necessario caricare il documento digitale sia del giustificativo che del pagamento.");
                PagamentoProvider.DbProviderObj.BeginTran();
                Giustificativi giustificativo;
                SiarLibrary.SpeseSostenute spesa;
                int idSpesaSostenuta;
                if (int.TryParse(hdnIdSpesaSostenuta.Value, out idSpesaSostenuta))
                {
                    //MODIFICA DELLA SPESA
                    spesa = spese_provider.GetById(idSpesaSostenuta);
                    giustificativo = giustificativi_provider.GetById(spesa.IdGiustificativo);
                    if (spesa == null || giustificativo == null) throw new SiarException(TextErrorCodes.GenericoConLink);

                    //controllo se si sta modificando il giustificativo con uno gia esistente 
                    if (giustificativi_provider.GiustificativoEsistente(spesa.IdGiustificativo, Progetto.IdProgetto, lstTipoGiustificativo.Text, txtNumGiustificativo.Text, txtDataGiustificativo.Text, txtPivaFornitore.Text))
                        throw new Exception("Si sta provando a modificare il giustificativo con un'altro già esistente, selezionarlo dalla funzione 'Richiama un giustificativo precedentemente inserito'.");

                    riempiCampiGiustificativo(ref giustificativo);
                    riempiCampiSpesaSostenuta(ref spesa);

                    //16-02-2023 Commentato controllo campi giustificativi per PASS#187931
                    //controlloCampiGiustificativo(ref giustificativo, idSpesaSostenuta);

                    if ((giustificativo.InIntegrazione != null && giustificativo.InIntegrazione) || DomandaPagamento.Segnatura == null)
                        giustificativi_provider.Save(giustificativo);

                    if ((spesa.InIntegrazione != null && spesa.InIntegrazione) || DomandaPagamento.Segnatura == null)
                        spese_provider.Save(spesa);

                }
                else
                {
                    //INSERIMENTO NUOVA
                    int idGiustificativo;
                    if (int.TryParse(hdnIdGiustificativo.Value, out idGiustificativo))
                    {
                        giustificativo = giustificativi_provider.GetById(idGiustificativo);
                        if (giustificativo == null) throw new Exception("Giustificativo ricercato non valido, impossibile continuare.");
                        controlloCampiGiustificativo(ref giustificativo, -1);
                    }
                    else
                    {
                        giustificativo = new Giustificativi();
                        //controllo se il giustificativo non sia già presente in database
                        if (giustificativi_provider.GiustificativoEsistente(0, Progetto.IdProgetto, lstTipoGiustificativo.Text, txtNumGiustificativo.Text, txtDataGiustificativo.Text, txtPivaFornitore.Text))
                            throw new Exception("Giustificativo già inserito, selezionarlo dalla funzione 'Richiama un giustificativo precedentemente inserito'.");
                        riempiCampiGiustificativo(ref giustificativo);
                        giustificativi_provider.Save(giustificativo);
                    }

                    spesa = new SiarLibrary.SpeseSostenute();
                    riempiCampiSpesaSostenuta(ref spesa);
                    spesa.IdGiustificativo = giustificativo.IdGiustificativo;
                    spese_provider.Save(spesa);
                }

                if (DomandaPagamento.InIntegrazione == null || DomandaPagamento.InIntegrazione == false)
                    PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, ((SiarLibrary.Web.MasterPage)Master).Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Spesa registrata correttamente.");
                spesa_selezionata = spese_provider.GetById(spesa.IdSpesa);                
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }

        protected void btnSalvaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            integrazione_singola_provider = new IntegrazioneSingolaDiDomandaCollectionProvider();
            if (int.TryParse(hdnIdIntegrazioneSingolaSelezionata.Value, out id_integrazione_di_domanda_singola))
                integrazione_singola_selezionata = integrazione_singola_provider.GetById(id_integrazione_di_domanda_singola);

            if (integrazione_singola_selezionata != null)
            {
                SiarLibrary.NullTypes.BoolNT newValue = comboCompletataSingolaIntegrazioneDomandaBeneficiario.SelectedValue;
                string messaggio = IntegrazioniDomandaPagamentoUtility.salvaSingolaIntegrazioneBeneficiario(integrazione_singola_selezionata, newValue, txtNoteSingolaIntegrazioneBeneficiario.Text, txtDataRilascio.Text);

                if (messaggio.StartsWith("Integrazione"))
                    ShowMessage(messaggio);
                else
                    ShowError(messaggio);
            }
        }

        protected void btnRimuoviFileSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                file_spesa_provider = new SpeseSostenuteFileCollectionProvider();
                spese_provider = new SpeseSostenuteCollectionProvider();

                int id_file_spesa;
                if (int.TryParse(hdnIdFileSpesaSostenuta.Value, out id_file_spesa))
                {
                    file_spesa = file_spesa_provider.GetById(id_file_spesa);
                    file_spesa_provider.Delete(file_spesa);
                    ShowMessage("File rimosso.");
                    hdnIdFileSpesaSostenuta.Value = null;
                    file_spesa = null;
                }
                else
                    ShowError("Non è stato possibile rimuovere il file.");
            }
            catch (Exception ex) { ShowError(ex.ToString()); }
        }

        protected void btnAssociaFileSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                file_spesa_provider = new SpeseSostenuteFileCollectionProvider();
                spese_provider = new SpeseSostenuteCollectionProvider();

                if (ufFileSpesaSostenuta.IdFile == null 
                    || txtDescrizioneFile.Text == null || txtDescrizioneFile.Text.Equals(""))
                    ShowError("File non caricato o descrizione mancante.");
                else
                {
                    int id_file_spesa;
                    if (int.TryParse(hdnIdFileSpesaSostenuta.Value, out id_file_spesa))
                        file_spesa = file_spesa_provider.GetById(id_file_spesa);

                    if (file_spesa != null)
                    {
                        file_spesa.Descrizione = txtDescrizioneFile.Text;
                        file_spesa.IdFile = ufFileSpesaSostenuta.IdFile;
                        file_spesa.CfModifica = Operatore.Utente.CfUtente;
                        file_spesa.DataModifica = DateTime.Now;
                        file_spesa.InIntegrazione = true;
                        file_spesa_provider.Save(file_spesa);

                        hdnIdFileSpesaSostenuta.Value = null;
                        file_spesa = null;

                        ShowMessage("File salvato correttamente.");
                    }
                    else
                    {
                        int id_spesa;
                        if (int.TryParse(hdnIdSpesaSostenuta.Value, out id_spesa))
                            spesa_selezionata = spese_provider.GetById(id_spesa);

                        if (spesa_selezionata != null)
                        {
                            file_spesa = new SpeseSostenuteFile();
                            file_spesa.IdSpesa = spesa_selezionata.IdSpesa;
                            file_spesa.Descrizione = txtDescrizioneFile.Text;
                            file_spesa.IdFile = ufFileSpesaSostenuta.IdFile;
                            file_spesa.DataInserimento = DateTime.Now;
                            file_spesa.CfInserimento = Operatore.Utente.CfUtente;
                            file_spesa.CfModifica = Operatore.Utente.CfUtente;
                            file_spesa.DataModifica = DateTime.Now;
                            file_spesa.InIntegrazione = true;
                            file_spesa_provider.Save(file_spesa);

                            hdnIdFileSpesaSostenuta.Value = null;
                            file_spesa = null;

                            ShowMessage("File salvato correttamente.");
                        }
                        else
                            ShowError("Errore durante l'associazione del file alla spesa.");
                    }
                }
            }
            catch (Exception ex) { ShowError(ex.Message); }

        }

        protected void btnCaricaSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                int id_spesa;
                if (int.TryParse(hdnIdSpesaSostenuta.Value, out id_spesa)) spesa_selezionata = spese_provider.GetById(id_spesa);
                if (spesa_selezionata == null) throw new Exception("Nessuna spesa selezionata.");
                ucSiarNewTab.TabSelected = 2;
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnCaricaGiustificativo_Click(object sender, EventArgs e)
        {
            try
            {
                Giustificativi g = null;
                int id_giustificativo;
                if (int.TryParse(hdnIdGiustificativo.Value, out id_giustificativo)) g = giustificativi_provider.GetById(id_giustificativo);
                if (g == null) throw new Exception("Nessuna spesa selezionata.");
                caricaGiustificativo(g);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnRendicontazioneVeloce_Click(object sender, EventArgs e)
        {
            try
            {
                //int idspesa;
                //if (!int.TryParse(hdnIdSpesaSostenuta.Text, out idspesa)) throw new Exception("Nessuna spesa selezionata.");
                //SpeseSostenute spesa = spese_provider.GetById(idspesa);
                //if (spesa == null) throw new Exception("Nessuna spesa selezionata.");
                //Session["siar_rendicontazione_veloce_spesa_selezionata"] = spesa;
                //Redirect("RendicontazioneVeloce.aspx");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                int id_spesa;
                if (!int.TryParse(hdnIdSpesaSostenuta.Value, out id_spesa)) throw new Exception("Nessuna spesa selezionata.");
                spesa_selezionata = spese_provider.GetById(id_spesa);
                if (spesa_selezionata == null) throw new Exception("Nessuna spesa selezionata.");

                PagamentoProvider.DbProviderObj.BeginTran();
                spese_provider.Delete(spesa_selezionata);
                PagamentoProvider.AggiornaDomandaDiPagamento(DomandaPagamento, Operatore);
                PagamentoProvider.DbProviderObj.Commit();
                ShowMessage("Spesa eliminata correttamente.");
            }
            catch (Exception ex) { PagamentoProvider.DbProviderObj.Rollback(); ShowError(ex); }
            finally { clearAllFields(); }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            dgSpese.SetPageIndex(0);
        }

        protected void btnScaricaFornitore_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(txtPivaFornitore.Text) || !txtPivaFornitore.Text.Length.FindValueIn(11, 16))
                //    throw new Exception("Il C.F./P.Iva del fornitore non è valido.");
                ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
                SiarLibrary.Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);

                //if (i == null)
                //{
                //    SianWebSrv.TraduzioneSianToSiar tr = new SianWebSrv.TraduzioneSianToSiar();
                //    tr.ScaricaDatiAzienda(txtPivaFornitore.Text, null, Operatore.Utente.CfUtente);
                //    i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);
                //}

                if (i == null)
                {
                    txtRSFornitore.ReadOnly = false;
                    throw new Exception("Partita Iva del fornitore non presente nel nostro database, si prega di inserire manualmente la ragione sociale");
                }

                hdnIdImpresaFornitoreCercato.Value = i.IdImpresa;
                txtPivaFornitore.Text = i.CodiceFiscale.Value.ToUpper();
                txtRSFornitore.Text = i.RagioneSociale;
                RegisterClientScriptBlock("return SNCVZCloseDiv();"); 
            }
            catch (Exception ex) 
            { 
                ShowError(ex); 
            }
        }

        protected void btnNuovaSpesa_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        protected void btnAllegati_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "FirmaRichiesta.aspx");
        }

        protected void btnInvestimenti_Click(object sender, EventArgs e)
        {
            Redirect(PATH_PPAGAMENTO + "PianoInvestimenti.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["id_integrazione_domanda"] = null;
            Redirect(PATH_PPAGAMENTO + "IntegrazioniDomandaPagamento.aspx");
        }

        #endregion

        #region ItemDataBound

        void dgSpese_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].RowSpan = 2;
                dgi.Cells[1].ColumnSpan = 6;
                dgi.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[1].Text = "Dati giustificativo</td><td colspan=3 align=center>Dati pagamento</td><td></td></tr><tr class='TESTA'><td>";
            }
            else if (e.Item.ItemType != ListItemType.Footer)
            {
                SiarLibrary.SpeseSostenute spesa = (SiarLibrary.SpeseSostenute)dgi.DataItem;
                dgi.Cells[1].Text = "Numero: <b>" + spesa.Numero + "</b><br />Data: <b>" + spesa.DataGiustificativo + "</b><br />Tipo: <b>"
                    + spesa.TipoGiustificativo + "</b>";

                dgi.Cells[5].Text = string.Format("{0:c}", decimal.Parse(spesa.AdditionalAttributes["ImportoRichiesto"]));
                dgi.Cells[6].Text = string.Format("{0:c}", decimal.Parse(spesa.AdditionalAttributes["ImportoAmmesso"]));
                dgi.Cells[7].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;

                GiustificativiCollectionProvider giustificativi_provider = new GiustificativiCollectionProvider();
                Giustificativi giustificativo = giustificativi_provider.GetById(spesa.IdGiustificativo);
                if ((spesa.InIntegrazione == null || spesa.InIntegrazione == false)
                    && (giustificativo.InIntegrazione == null || giustificativo.InIntegrazione == false))
                    dgi.Cells[10].Text = "";

                decimal importo_lordo_giustificativo = spesa.Imponibile + (spesa.Imponibile * spesa.Iva / 100);
                dgi.Cells[3].Text = string.Format("{0:c}", importo_lordo_giustificativo);
                //dgi.Cells[9].Text = "<input type=button class='ButtonGrid' value='Dettaglio' style='width:60px' onclick=\"caricaSpesa("
                //    + spesa.IdSpesa + ");\" />";
            }
        }

        void dgIntegrazioni_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            int col_Id = 0,
                col_DataRichiesta = 1,
                col_TipoIntegrazione = 2,
                col_CompletataIntegrazione = 3,
                col_DataRilascioBeneficiario = 4,
                col_CompletataBeneficiario = 5,
                col_DatiGiustificativo = 6,
                col_DatiPagamento = 7,
                col_Apri = 8;

            var dgi = e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var d = (IntegrazioneSingolaDiDomanda)dgi.DataItem;

                if (d.SingolaIntegrazioneCompletataIstruttore != null && d.SingolaIntegrazioneCompletataIstruttore == true)
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataIntegrazione].Text = "<div class=\"negativo\">NO</div>";

                if (d.SingolaIntegrazioneCompletataBeneficiario != null && d.SingolaIntegrazioneCompletataBeneficiario == true)
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"positivo\">SI</div>";
                else
                    dgi.Cells[col_CompletataBeneficiario].Text = "<div class=\"negativo\">NO</div>";

                if ((d.DescrizioneTipoIntegrazione != null)
                    && (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo") || d.DescrizioneTipoIntegrazione.Equals("Spese sostenute pagamento")))
                {
                    if (d.DescrizioneTipoIntegrazione.Equals("Spese sostenute giustificativo"))
                    {
                        var giustificativo = new GiustificativiCollectionProvider().GetById(d.IdGiustificativo);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + giustificativo.Numero + "<br /><b>Data:</b> " + giustificativo.Data + "<br /><b>Ragione sociale:</b> " + giustificativo.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + giustificativo.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "";
                    }
                    else
                    {
                        var spesa = new SpeseSostenuteCollectionProvider().GetById(d.IdSpesa);
                        dgi.Cells[col_DatiGiustificativo].Text = "<b>Numero:</b> " + spesa.Numero + "<br /><b>Data:</b> " + spesa.Data + "<br /><b>Ragione sociale:</b> " + spesa.DescrizioneFornitore + "<br /><b>Oggetto:</b> " + spesa.Descrizione;
                        dgi.Cells[col_DatiPagamento].Text = "<b>Tipo:</b> " + spesa.TipoPagamento + "<br /><b>Estremi:</b> " + spesa.Estremi;
                    }
                }
                else
                {
                    dgi.Cells[col_DatiGiustificativo].Text = "";
                    dgi.Cells[col_DatiPagamento].Text = "";
                }

                if (integrazione_singola_selezionata != null && d.IdSingolaIntegrazione == integrazione_singola_selezionata.IdSingolaIntegrazione)
                    dgi.Cells[col_Apri].Text = dgi.Cells[col_Apri].Text.Replace("Apri", "Torna elenco");
            }
        }

        void dgFileSpeseSostenute_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var d = (SpeseSostenuteFile)e.Item.DataItem;

                if (spesa_selezionata.InIntegrazione == null || !spesa_selezionata.InIntegrazione)
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace(" onclick", "disabled=\"disabled\" onclick");
                else
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace("disabled=\"disabled\"", "");
            }

            if (bloccaRimuovi)
                e.Item.Cells[3].Visible = false;
        }

        void dgInvestimenti_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (e.Item.ItemType == ListItemType.Header)
            {
                dgi.Cells[0].ColumnSpan = 3;
                dgi.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                dgi.Cells[0].Text = "Piano Investimenti</td><td colspan=4 align=center>Dati Giustificativo</td><td></td></tr><tr class='TESTA'><td>Descrizione";
            }
            else if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                SiarLibrary.PianoInvestimenti f = (SiarLibrary.PianoInvestimenti)dgi.DataItem;
                dgi.Cells[0].Text = "<b>Codifica:</b> " + f.CodificaInvestimento + "<br /><b>Dettaglio:</b> " + f.DettaglioInvestimenti
                                    + "<br /><b>Descrizione:</b> " + f.Descrizione;
                //Aggregazione 
                string[] Aggregazione = new string[2];
                Aggregazione = investimenti_provider.GetImpresaAggregazioneInvestimento(f.IdInvestimento);
                if (Aggregazione[0] != null && Aggregazione[1] != null && Aggregazione[0] != "" && Aggregazione[1] != "")
                {
                    dgi.Cells[0].Text += "<br /><b>Impresa: </b>" + Aggregazione[0] + " - " + Aggregazione[1];
                    SiarLibrary.Impresa impresa = new ImpresaCollectionProvider().GetByCuaa(Aggregazione[0]);
                    if (impresa.CodAteco2007 != null && impresa.CodAteco2007 != "")
                        dgi.Cells[0].Text += " - Ateco: " + impresa.CodAteco2007;
                }

                //Personalizzazione bando 6.2 
                if (Progetto.IdBando == 39)
                {
                    string linea_intervento = "";
                    linea_intervento = investimenti_provider.GetLineaInterventoInvestimento(f.IdInvestimento);
                    if (linea_intervento != null && linea_intervento != "")
                        dgi.Cells[0].Text += "<br /><b>" + linea_intervento + "</b>";
                }

                decimal importo_giu_richiesti, contributo_giu_richiesto, importo_giu_ammesso , contributo_giu_ammesso;
                
                decimal.TryParse(f.AdditionalAttributes["ImportoGiustificativoRichiesto"], out importo_giu_richiesti);
                decimal.TryParse(f.AdditionalAttributes["ContributoGiustificativoRichiesto"], out contributo_giu_richiesto);
                dgi.Cells[3].Text = string.Format("{0:c}", importo_giu_richiesti);
                dgi.Cells[4].Text = string.Format("{0:c}", contributo_giu_richiesto);

                if (decimal.TryParse(f.AdditionalAttributes["ImportoGiustificativoAmmesso"], out importo_giu_ammesso))
                    dgi.Cells[5].Text = string.Format("{0:c}", importo_giu_ammesso);
                if(decimal.TryParse(f.AdditionalAttributes["ContributoGiustificativoAmmesso"], out contributo_giu_ammesso))
                    dgi.Cells[6].Text = string.Format("{0:c}", contributo_giu_ammesso);
            }
        }

        #endregion
    }
}