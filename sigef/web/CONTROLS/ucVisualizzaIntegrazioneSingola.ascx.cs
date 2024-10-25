using System;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarBLL;
using SiarLibrary.Web;
using SiarLibrary.NullTypes;
using SiarLibrary.Extensions;
using System.Text;

namespace web.CONTROLS
{
    public partial class ucVisualizzaIntegrazioneSingola : SigefUserControl
    {
        private IntegrazioneSingolaDiDomanda _integrazioneSingola;
        public IntegrazioneSingolaDiDomanda IntegrazioneSingola
        {
            get { return _integrazioneSingola; }
            set { _integrazioneSingola = value; }
        }

        private bool _perBeneficiario;
        public bool PerBeneficiario
        {
            get { return _perBeneficiario; }
            set { _perBeneficiario = value; }
        }

        private DomandaDiPagamento _domandaDiPagamento;
        private DomandaPagamentoAllegati _allegato_selezionato;
        private Giustificativi _giustificativo_selezionato;
        private SpeseSostenute _spesa_selezionata;
        private SpeseSostenuteFile _file_spesa;
        private IntegrazioniPerDomandaDiPagamento _integrazione_domanda_pagamento;
        private bool bloccaRimuovi = false;

        private IntegrazioniPerDomandaDiPagamentoCollectionProvider _integrazioniPerDomandaDiPagamentoCollectionProvider;
        private IntegrazioneSingolaDiDomandaCollectionProvider _integrazioneSingolaDiDomandaCollectionProvider;
        private DomandaDiPagamentoCollectionProvider _domandaDiPagamentoCollectionProvider;
        private DomandaPagamentoAllegatiCollectionProvider _allegatiCollectionProvider;
        private GiustificativiCollectionProvider _giustificativiCollectionProvider;
        private SpeseSostenuteCollectionProvider _speseSostenuteCollectionProvider;
        private SpeseSostenuteFileCollectionProvider _speseSostenuteFileCollectionProvider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_integrazioneSingola != null && _integrazioneSingola.IdDomandaPagamento != null)
            {
                InizializzaProvider(false);
                CaricaDatiIntegrazioneSingola();
                AbilitaComponenti();
                ValorizzaCampiNascosti();
            }
            else
                divContenitore.Visible = false;

            base.OnPreRender(e);
        }

        protected void InizializzaProvider(bool perTransazione)
        {
            if (!perTransazione)
            {
                _integrazioneSingolaDiDomandaCollectionProvider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                _integrazioniPerDomandaDiPagamentoCollectionProvider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider();
                _domandaDiPagamentoCollectionProvider = new DomandaDiPagamentoCollectionProvider();
                _allegatiCollectionProvider = new DomandaPagamentoAllegatiCollectionProvider();
                _giustificativiCollectionProvider = new GiustificativiCollectionProvider();
                _speseSostenuteCollectionProvider = new SpeseSostenuteCollectionProvider();
                _speseSostenuteFileCollectionProvider = new SpeseSostenuteFileCollectionProvider();
            }
            else
            {
                _integrazioneSingolaDiDomandaCollectionProvider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                _integrazioniPerDomandaDiPagamentoCollectionProvider = new IntegrazioniPerDomandaDiPagamentoCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
                _domandaDiPagamentoCollectionProvider = new DomandaDiPagamentoCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
                _allegatiCollectionProvider = new DomandaPagamentoAllegatiCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
                _giustificativiCollectionProvider = new GiustificativiCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
                _speseSostenuteCollectionProvider = new SpeseSostenuteCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
                _speseSostenuteFileCollectionProvider = new SpeseSostenuteFileCollectionProvider(_integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj);
            }
        }

        protected void ValorizzaCampiNascosti()
        {
            if (_integrazioneSingola != null && _integrazioneSingola.IdSingolaIntegrazione != null)
            {
                hdnIdIntegrazioneSingola.Value = _integrazioneSingola.IdSingolaIntegrazione;
                hdnPerBeneficiario.Value = _perBeneficiario.ToString();

                StringNT descrizioneTipoIntegrazione = _integrazioneSingola.DescrizioneTipoIntegrazione;
                switch (descrizioneTipoIntegrazione)
                {
                    case "Allegati":
                        hdnIdAllegato.Value = _integrazioneSingola.IdAllegato;
                        break;
                    case "Spese sostenute giustificativo":
                        hdnIdGiustificativo.Value = _integrazioneSingola.IdGiustificativo;
                        break;
                    case "Spese sostenute pagamento":
                        hdnIdSpesaSostenuta.Value = _integrazioneSingola.IdSpesa;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void RicaricaDaCampiNascosti(bool perTransazione)
        {
            InizializzaProvider(perTransazione);

            int idIntegrazioneSingola;
            if (int.TryParse(hdnIdIntegrazioneSingola.Value, out idIntegrazioneSingola))
            {
                _integrazioneSingola = _integrazioneSingolaDiDomandaCollectionProvider.GetById(idIntegrazioneSingola);
                _integrazione_domanda_pagamento = _integrazioniPerDomandaDiPagamentoCollectionProvider.GetById(_integrazioneSingola.IdIntegrazioneDomanda);
                _domandaDiPagamento = _domandaDiPagamentoCollectionProvider.GetById(_integrazioneSingola.IdDomandaPagamento);

                bool perBeneficiario;
                if (bool.TryParse(hdnPerBeneficiario.Value, out perBeneficiario)) 
                    _perBeneficiario = perBeneficiario;

                StringNT descrizioneTipoIntegrazione = _integrazioneSingola.DescrizioneTipoIntegrazione;
                switch (descrizioneTipoIntegrazione)
                {
                    case "Allegati":
                        int idAllegato;
                        if (int.TryParse(hdnIdAllegato.Value, out idAllegato))
                            _allegato_selezionato = _allegatiCollectionProvider.GetById(idAllegato);
                        break;
                    case "Spese sostenute giustificativo":
                        int idGiustificativo;
                        if (int.TryParse(hdnIdGiustificativo.Value, out idGiustificativo))
                            _giustificativo_selezionato = _giustificativiCollectionProvider.GetById(idGiustificativo);
                        break;
                    case "Spese sostenute pagamento":
                        int idSpesa;
                        if (int.TryParse(hdnIdSpesaSostenuta.Value, out idSpesa))
                            _spesa_selezionata = _speseSostenuteCollectionProvider.GetById(idSpesa);

                        int idFileSpesa;
                        if (int.TryParse(hdnIdFileSpesaSostenuta.Value, out idFileSpesa))
                            _file_spesa = _speseSostenuteFileCollectionProvider.GetById(idFileSpesa);
                        break;
                    default:
                        break;
                }
            }
        }

        protected void SvuotaCampiNascosti()
        {
            hdnIdIntegrazioneSingola.Value = null;
            hdnPerBeneficiario.Value = null;
            hdnIdGiustificativo.Value = null;
            hdnIdSpesaSostenuta.Value = null;
            hdnIdFileSpesaSostenuta.Value = null;
        }

        protected void CaricaDatiIntegrazioneSingola()
        {
            if (_integrazioneSingola != null && _integrazioneSingola.IdDomandaPagamento != null)
                _domandaDiPagamento = _domandaDiPagamentoCollectionProvider.GetById(_integrazioneSingola.IdDomandaPagamento);
            else
                throw new Exception("Integrazione caricata in maniera sbagliata. Contattare l'helpdesk.");

            _integrazione_domanda_pagamento = _integrazioniPerDomandaDiPagamentoCollectionProvider.GetById(_integrazioneSingola.IdIntegrazioneDomanda);

            //Campi istruttore
            txtDataRichiesta.Text = _integrazioneSingola.DataRichiestaIntegrazioneIstruttore;
            txtTipoIntegrazione.Text = _integrazioneSingola.DescrizioneTipoIntegrazione;
            txtNoteSingolaIntegrazioneIstruttore.Text = _integrazioneSingola.NoteIntegrazioneIstruttore;
            comboCompletataSingolaIntegrazioneDomandaIstruttore.ClearSelection();
            string val_istruttore = "false";
            if (_integrazioneSingola.SingolaIntegrazioneCompletataIstruttore != null && _integrazioneSingola.SingolaIntegrazioneCompletataIstruttore)
                val_istruttore = "true";
            comboCompletataSingolaIntegrazioneDomandaIstruttore.Items.FindByValue(val_istruttore).Selected = true;
            txtDataConclusioneRichiesta.Text = _integrazioneSingola.DataConclusioneIstruttore != null
                ? _integrazioneSingola.DataConclusioneIstruttore
                : new DatetimeNT(DateTime.Now);
            if (_integrazioneSingola != null && _integrazioneSingola.SegnaturaIstruttore != null)
                btnEliminaSingolaIntegrazione.Enabled = false;

            //Campi beneficiario
            if (PerBeneficiario)
            {
                if (_integrazioneSingola.DataRilascioIntegrazioneBeneficiario == null)
                    txtDataRilascio.Text = new DatetimeNT(DateTime.Now);
                else
                    txtDataRilascio.Text = _integrazioneSingola.DataRilascioIntegrazioneBeneficiario;
            }
            else
            {
                txtDataRilascio.Text = _integrazioneSingola.DataRilascioIntegrazioneBeneficiario;
            }
            txtNoteSingolaIntegrazioneBeneficiario.Text = _integrazioneSingola.NoteIntegrazioneBeneficiario;
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.ClearSelection();
            string val_beneficario = "false";
            if (_integrazioneSingola.SingolaIntegrazioneCompletataBeneficiario != null && _integrazioneSingola.SingolaIntegrazioneCompletataBeneficiario)
                val_beneficario = "true";
            comboCompletataSingolaIntegrazioneDomandaBeneficiario.Items.FindByValue(val_beneficario).Selected = true;

            StringNT descrizioneTipoIntegrazione = _integrazioneSingola.DescrizioneTipoIntegrazione;
            switch(descrizioneTipoIntegrazione)
            {
                case "Allegati":
                    GestisciIntegrazioneAllegato();
                    break;
                case "Spese sostenute giustificativo":
                    GestisciIntegrazioneGiustificativo();
                    break;
                case "Spese sostenute pagamento":
                    GestisciIntegrazionePagamento();
                    break;
                default:
                    break;
            }
        }

        protected void GestisciIntegrazioneAllegato()
        {
            if (_perBeneficiario)
            {
                divInformazioniAggiuntiveAllegati.Visible = true;

                lstNATipoEnte.Attributes.Add("onchange", "lstNATipoEnte_changed();");
                lstCategoriaAllegato.Attributes.Add("onchange", "lstCategoriaAllegato_changed();");
                lstCategoriaAllegato.CommandText = @"SELECT CODICE , '('+FORMATO+') ' + SUBSTRING(DESCRIZIONE,0,100) AS DESCRIZIONE, FORMATO FROM TIPO_DOCUMENTO WHERE ATTIVO =1 ORDER BY CODICE DESC,DESCRIZIONE";
                lstCategoriaAllegato.DataBind();
                ufcNAAllegato.AbilitaModifica = AbilitaModifica;
                txtNAEnte.AddJSAttribute("onkeydown", "SNCVolatileZoom(this,event,'SNCVZCercaAmministrazione');");

                if (_integrazioneSingola.IdAllegato != null)
                {
                    hdnIdAllegato.Value = _integrazioneSingola.IdAllegato;
                    _allegato_selezionato = _allegatiCollectionProvider.GetById(_integrazioneSingola.IdAllegato);
                    lstCategoriaAllegato.SelectedValue = _allegato_selezionato.CodTipoDocumento;
                    txtDescrizione.Text = _allegato_selezionato.Descrizione;
                    if (_allegato_selezionato.Formato == "S")
                    {
                        divDichiarazioneSostitutiva.Style.Remove("display"); //necessario per rimediare alla mancanza del funziomento di RegisterClientScriptBlock
                        hdnCodEnte.Value = _allegato_selezionato.IdComune.IsNullAlt(_allegato_selezionato.CodEnteEmettitore);
                        lstNATipoEnte.SelectedValue = _allegato_selezionato.IdComune != null ? "CM" : (_allegato_selezionato.CodEnteEmettitore != null ? "PR" : "");
                        txtNAEnte.Text = _allegato_selezionato.Ente;
                        txtNANumeroDoc.Text = _allegato_selezionato.Numero;
                        txtNADatadoc.Text = _allegato_selezionato.Data;
                    }
                    else if (_allegato_selezionato.Formato == "D")
                    {
                        divUploadFileAllegato.Style.Remove("display"); //necessario per rimediare alla mancanza del funziomento di RegisterClientScriptBlock
                        ufcNAAllegato.IdFile = _allegato_selezionato.IdFile;
                    }
                }
                else
                    txtDescrizione.Text = "Allegato aggiunto per integrazione id " + _integrazioneSingola.IdSingolaIntegrazione;

                //PagePrivate.RegisterClientScriptBlock("lstCategoriaAllegato_changed();"); //non va per qualche motivo
            }
            else
            {
                divInformazioniAggiuntiveAllegatiIstruttore.Visible = true;
                var allegatiCollection = new DomandaPagamentoAllegatiCollection();

                if (_integrazioneSingola.IdAllegato != null)
                {
                    _allegato_selezionato = _allegatiCollectionProvider.GetById(_integrazioneSingola.IdAllegato);
                    allegatiCollection.Add(_allegato_selezionato);
                }

                dgAllegati.DataSource = allegatiCollection;
                if (allegatiCollection.Count == 0)
                    btnAmmettiAllegato.Enabled = false;
                dgAllegati.ItemDataBound += new DataGridItemEventHandler(dgAllegati_ItemDataBound);
                dgAllegati.SetTitoloNrElementi();
                dgAllegati.DataBind();
            }
        }

        protected void GestisciIntegrazioneGiustificativo()
        {
            divInformazioniAggiuntiveGiustificativiSpese.Visible = true;

            lstTipoGiustificativo.DataBind();
            if (AbilitaModifica)
            {
                Session["id_progetto"] = _domandaDiPagamento.IdProgetto.Value;
                txtPivaFornitore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this, event, 'SNCVZCercaFornitoriProgetto');");
                txtPivaFornitore.AddJSAttribute("onblur", "stopcf=false; setTimeout(function(){ if (!stopcf) ctrlCF();},300);");
            }

            _giustificativo_selezionato = _giustificativiCollectionProvider.GetById(_integrazioneSingola.IdGiustificativo);
            txtNumGiustificativo.Text = _giustificativo_selezionato.Numero;
            txtDataGiustificativo.Text = _giustificativo_selezionato.Data;
            txtRSFornitore.Text = _giustificativo_selezionato.DescrizioneFornitore;
            txtDescGiustificativo.Text = _giustificativo_selezionato.Descrizione;
            lstTipoGiustificativo.SelectedValue = _giustificativo_selezionato.CodTipo;
            chkNonRecuperabile.Checked = _giustificativo_selezionato.IvaNonRecuperabile;
            ufGiustificativo.IdFile = _giustificativo_selezionato.IdFile;
            txtImportoGiustificativo.Text = _giustificativo_selezionato.Imponibile;
            txtIva.Text = _giustificativo_selezionato.Iva;

            Impresa impresa_cercata = null;
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
                txtPivaFornitore.Text = _giustificativo_selezionato.CfFornitore;
                txtRSFornitore.Text = _giustificativo_selezionato.DescrizioneFornitore;
            }
        }

        protected void GestisciIntegrazionePagamento()
        {
            divInformazioniAggiuntiveGiustificativiSpese.Visible = true;
            divInformazioniAggiuntiveSpese.Visible = true;

            lstTipoGiustificativo.DataBind();
            lstPagamento.DataBind();
            if (AbilitaModifica)
            {
                Session["id_progetto"] = _domandaDiPagamento.IdProgetto.Value;
                txtPivaFornitore.AddJSAttribute("onkeydown", "SNCVolatileZoom(this, event, 'SNCVZCercaFornitoriProgetto');");
                txtPivaFornitore.AddJSAttribute("onblur", "stopcf=false; setTimeout(function(){ if (!stopcf) ctrlCF();},300);");
                txtImportoLordoPagamento.AddJSAttribute("onblur", "return validaImporti(true, event);");
            }

            _spesa_selezionata = _speseSostenuteCollectionProvider.GetById(_integrazioneSingola.IdSpesa);
            if (_spesa_selezionata != null)
            {
                txtDataGiustificativo.Text = _spesa_selezionata.DataGiustificativo;
                txtDataPagamento.Text = _spesa_selezionata.Data;
                txtDescGiustificativo.Text = _spesa_selezionata.Descrizione;
                txtEstremi.Text = _spesa_selezionata.Estremi;
                txtImportoGiustificativo.Text = _spesa_selezionata.Imponibile;
                txtImportoLordoPagamento.Text = _spesa_selezionata.Importo;
                txtImportoNettoPagamento.Text = _spesa_selezionata.Netto;
                txtIva.Text = _spesa_selezionata.Iva;
                //txtNumDocTrasporto.Text = _spesa_selezionata.NumeroDoctrasporto;
                //txtDataDocTrasporto.Text = _spesa_selezionata.DataDoctrasporto;
                txtNumGiustificativo.Text = _spesa_selezionata.Numero;

                Impresa impresa_cercata = null;
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
                    txtPivaFornitore.Text = _spesa_selezionata.CfFornitore;
                    txtRSFornitore.Text = _spesa_selezionata.DescrizioneFornitore;
                }

                lstPagamento.SelectedValue = _spesa_selezionata.CodTipo;
                lstTipoGiustificativo.SelectedValue = _spesa_selezionata.CodTipoGiustificativo;
                chkNonRecuperabile.Checked = _spesa_selezionata.IvaNonRecuperabile;
                ufGiustificativo.IdFile = _spesa_selezionata.IdFileGiustificativo;
                ufPagamento.IdFile = _spesa_selezionata.IdFile;
                GestisciFileSpesaSostenuta();

                //PagePrivate.RegisterClientScriptBlock("return validaImporti(true,null);");
            }
        }

        protected void GestisciFileSpesaSostenuta()
        {
            SpeseSostenuteFileCollection file_spesa_collection = null;
            GestisciFileSingoloSpesaSostenuta();

            try
            {
                if (_file_spesa != null)
                {
                    file_spesa_collection = new SpeseSostenuteFileCollection();
                    file_spesa_collection.Add(_file_spesa);
                }
                else
                    file_spesa_collection = _speseSostenuteFileCollectionProvider.GetByIdSpesa(_spesa_selezionata.IdSpesa, null);
            }
            catch (Exception ex) 
            { 
                PagePrivate.ShowError(ex.ToString()); 
            }

            if (file_spesa_collection.Count > 0
                || (_domandaDiPagamento != null && _domandaDiPagamento.InIntegrazione &&
                    _spesa_selezionata.InIntegrazione != null && _spesa_selezionata.InIntegrazione))
            {
                _integrazioneSingolaDiDomandaCollectionProvider = new IntegrazioneSingolaDiDomandaCollectionProvider();
                if (_integrazioneSingolaDiDomandaCollectionProvider.GetByIdSpesa(_spesa_selezionata.IdSpesa, true, true, false).Count > 0)
                    bloccaRimuovi = true;

                divFileSpesaSostenuta.Visible = true;
                dgFileSpeseSostenute.DataSource = file_spesa_collection;
                dgFileSpeseSostenute.SetTitoloNrElementi();
                dgFileSpeseSostenute.ItemDataBound += new DataGridItemEventHandler(dgFileSpeseSostenute_ItemDataBound);
                dgFileSpeseSostenute.DataBind();
            }
        }

        protected void GestisciFileSingoloSpesaSostenuta()
        {
            int id_file_spesa;
            if (int.TryParse(hdnIdFileSpesaSostenuta.Value, out id_file_spesa))
                _file_spesa = new SpeseSostenuteFileCollectionProvider().GetById(id_file_spesa);

            if (_file_spesa != null)
            {
                txtDescrizioneFile.Text = _file_spesa.Descrizione;
                ufFileSpesaSostenuta.IdFile = _file_spesa.IdFile;
            }
            else
            {
                txtDescrizioneFile.Text = null;
                ufFileSpesaSostenuta.IdFile = null;
            }
        }

        protected void riempiCampiGiustificativo(ref Giustificativi giustificativo)
        {
            giustificativo.IdProgetto = _domandaDiPagamento.IdProgetto;
            giustificativo.CodTipo = lstTipoGiustificativo.Text;
            giustificativo.Data = txtDataGiustificativo.Text;
            giustificativo.Numero = txtNumGiustificativo.Text;
            giustificativo.NumeroDoctrasporto = null;
            giustificativo.DataDoctrasporto = null;
            giustificativo.Imponibile = txtImportoGiustificativo.Text;
            //if (txtIva.Text == null || txtIva.Text.Equals(""))
            //    throw new Exception("Iva del giustificativo non valida.");
            giustificativo.Iva = txtIva.Text;
            giustificativo.Descrizione = CleanInput(txtDescGiustificativo.Text);
            giustificativo.CfFornitore = txtPivaFornitore.Text.ToUpper();
            if (txtRSFornitore.Text == null || txtRSFornitore.Text.Equals(""))
            {
                ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
                Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);
                if (i != null)
                    txtRSFornitore.Text = i.RagioneSociale;
            }
            giustificativo.DescrizioneFornitore = txtRSFornitore.Text;
            giustificativo.IvaNonRecuperabile = chkNonRecuperabile.Checked;
            if (_domandaDiPagamento.InIntegrazione != null && _domandaDiPagamento.InIntegrazione
                && giustificativo.IdFile != null && !giustificativo.IdFile.GetHashCode().Equals(ufGiustificativo.IdFile.GetHashCode()))
                giustificativo.IdFileModificatoIntegrazione = true;
            giustificativo.IdFile = ufGiustificativo.IdFile;
        }

        protected void riempiCampiSpesaSostenuta(ref SpeseSostenute spesa)
        {
            spesa.IdDomandaPagamento = _domandaDiPagamento.IdDomandaPagamento;
            spesa.Estremi = txtEstremi.Text;
            spesa.Data = txtDataPagamento.Text;
            spesa.CodTipo = lstPagamento.Text;
            spesa.Importo = txtImportoLordoPagamento.Text;
            spesa.Netto = txtImportoNettoPagamento.Text;
            if (_domandaDiPagamento.InIntegrazione != null && _domandaDiPagamento.InIntegrazione
                && spesa.IdFile != null && !spesa.IdFile.GetHashCode().Equals(ufPagamento.IdFile.GetHashCode()))
                spesa.IdFileModificatoIntegrazione = true;
            spesa.IdFile = ufPagamento.IdFile;

            if (!_perBeneficiario)
            {
                spesa.Ammesso = true;
                spesa.DataApprovazione = DateTime.Now;
                spesa.OperatoreApprovazione = _operatore.Utente.IdUtente;
            }
        }

        protected void controlloCampiGiustificativo(ref Giustificativi giustificativo, int idSpesa)
        {
            SpeseSostenuteCollection spese = _speseSostenuteCollectionProvider.Find(null, giustificativo.IdGiustificativo, null);
            decimal totaleSpeseNette = 0;
            foreach (SpeseSostenute s in spese)
            {
                if (!s.DomandaPagamentoAnnullata && s.IdSpesa != idSpesa) 
                    totaleSpeseNette += s.Netto.Value;
            }

            if (totaleSpeseNette > giustificativo.Imponibile)
                throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare.");

            //decimal somma = giustificativo.Imponibile - decimal.Parse(txtImportoNettoPagamento.Text); 
            //foreach (SpeseSostenute s in spese) 
            //{ 
            //    if (!s.DomandaPagamentoAnnullata && s.IdSpesa != idSpesa) somma -= s.Netto.Value; 
            //    if (somma < 0) 
            //        throw new Exception("L`importo netto dei pagamenti riferiti al giustificativo selezionato supera l'ammontare del giustificativo. Impossibile continuare."); 
            //} 
        }

        private string CleanInput(string strIn)
        {
            StringBuilder sb = new StringBuilder(strIn.Length);
            foreach (char c in strIn)
            {
                var num_c = (int)c;

                if (num_c >= 131 && num_c <= 146)
                    continue;
                if (num_c >= 149 && num_c <= 162)
                    continue;
                if (num_c >= 164 && num_c <= 223)
                    continue;

                sb.Append(c);
            }
            return sb.ToString();
        }

        protected void AbilitaComponenti()
        {
            if (_integrazione_domanda_pagamento.IntegrazioneCompleta != null && _integrazione_domanda_pagamento.IntegrazioneCompleta)
            {
                AbilitaModifica = false;
                btnSalvaSingolaIntegrazione.Enabled = false;
                btnSalvaAllegato.Enabled = false;
                btnSalvaGiustificativiSpesa.Enabled = false;
                btnAmmettiAllegato.Enabled = false;
                btnEliminaAllegato.Enabled = false;
                btnEliminaSingolaIntegrazione.Enabled = false;
                divInserimentoFileSpese.Visible = false;
            }
            else
            {
                var tipoIntegrazione = _integrazioneSingola.DescrizioneTipoIntegrazione;

                //Abilito i componenti in base a dove uso lo user control (beneficiario o istuttore) 
                if (_perBeneficiario)
                {
                    btnVisualizzaIntegrazione.Text = "Vai all'integrazione";

                    //Se sono beneficiario disabilito tutti i componenti dell'istruttore
                    btnEliminaSingolaIntegrazione.Visible = false;
                    txtDataConclusioneRichiesta.ReadOnly = true;
                    comboCompletataSingolaIntegrazioneDomandaIstruttore.Enabled = false;
                    txtNoteSingolaIntegrazioneIstruttore.ReadOnly = true;

                    //In base al tipo e allo stato dell'integrazione abilito o meno le varie parti del beneficiario
                    if (_integrazioneSingola.SegnaturaBeneficiario == null)
                    {
                        btnVisualizzaIntegrazione.Enabled = true;
                        btnSalvaSingolaIntegrazione.Enabled = true;
                        divDataConclusioneRichiesta.Visible = false;

                        switch (tipoIntegrazione)
                        {
                            case "Allegati":
                                AbilitaComponentiIntegrazioneAllegato(false);
                                break;
                            case "Spese sostenute giustificativo":
                                AbilitaComponentiIntegrazioneGiustificativiSpese(false);
                                break;
                            case "Spese sostenute pagamento":
                                AbilitaComponentiIntegrazioneGiustificativiSpese(false);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoIntegrazione)
                        {
                            case "Allegati":
                                AbilitaComponentiIntegrazioneAllegato(true);
                                break;
                            case "Spese sostenute giustificativo":
                                AbilitaComponentiIntegrazioneGiustificativiSpese(true);
                                break;
                            case "Spese sostenute pagamento":
                                AbilitaComponentiIntegrazioneGiustificativiSpese(true);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    //Se sono istruttore disabilito tutti i componenti del beneficiario
                    txtDataRilascio.ReadOnly = true;
                    comboCompletataSingolaIntegrazioneDomandaBeneficiario.Enabled = false;
                    txtNoteSingolaIntegrazioneBeneficiario.ReadOnly = true;

                    //In base al tipo e allo stato dell'integrazione abilito o meno le varie parti dell'istruttore
                    switch (tipoIntegrazione)
                    {
                        case "Allegati":
                            AbilitaComponentiIntegrazioneAllegatoIstruttore();
                            break;
                        case "Spese sostenute giustificativo":
                            AbilitaComponentiIntegrazioneGiustificativiSpese(false);
                            break;
                        case "Spese sostenute pagamento":
                            AbilitaComponentiIntegrazioneGiustificativiSpese(false);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void AbilitaComponentiIntegrazioneAllegato(bool segnatura)
        {
            if (!segnatura)
            {
                btnSalvaAllegato.Enabled = true;
                btnEliminaAllegato.Enabled = true;

                lstCategoriaAllegato.Enabled = true;
                ufcNAAllegato.AbilitaModifica = true;
                txtDescrizione.Enabled = true;
            }
            else
            {
                //Se è stata protocollata la risposta, è richiesta un integrazione su questo allegato ma non risulta completata posso modificarlo
                if (_integrazioneSingola != null 
                    && _integrazioneSingola.IdAllegato != null
                    && _integrazioneSingolaDiDomandaCollectionProvider.GetByIdAllegato(_integrazioneSingola.IdAllegato, true, true, false).Count > 0)
                {
                    btnVisualizzaIntegrazione.Enabled = false;
                    btnSalvaSingolaIntegrazione.Enabled = false;
                    btnSalvaAllegato.Enabled = false;
                    btnEliminaAllegato.Enabled = false;

                    lstCategoriaAllegato.Enabled = false;
                    ufcNAAllegato.AbilitaModifica = false;
                    txtDescrizione.Enabled = false;
                }
                else
                {
                    btnVisualizzaIntegrazione.Enabled = true;
                    btnSalvaSingolaIntegrazione.Enabled = true;
                    btnSalvaAllegato.Enabled = true;
                    btnEliminaAllegato.Enabled = true;

                    lstCategoriaAllegato.Enabled = true;
                    ufcNAAllegato.AbilitaModifica = true;
                    txtDescrizione.Enabled = true;
                }
        }
        }

        protected void AbilitaComponentiIntegrazioneGiustificativiSpese(bool segnatura)
        {
            var modifica_giustificativo = VerificaAbilitaComponentiIntegrazioneGiustificativo(segnatura);
            var modifica_spesa = VerificaAbilitaComponentiIntegrazionePagamento(segnatura);

            if (modifica_giustificativo || modifica_spesa)
                btnSalvaGiustificativiSpesa.Enabled = true;
            else
                btnSalvaGiustificativiSpesa.Enabled = false;
        }

        protected bool VerificaAbilitaComponentiIntegrazioneGiustificativo(bool segnatura)
        {
            //Verifico se esistono integrazioni richieste di tipo giustificativo
            var integrazione_singola_collection = _integrazioneSingolaDiDomandaCollectionProvider.Find(null, _integrazioneSingola.IdIntegrazioneDomanda, "GIU", null, null, null);
            if (integrazione_singola_collection.Count > 0)
            {
                if (_giustificativo_selezionato != null)
                {
                    if (!segnatura)
                    {
                        //Se non è stata ancora protocollata la risposta ed è richiesta un integrazione su questo giustificativo posso modificarlo
                        if (_giustificativo_selezionato.InIntegrazione != null && _giustificativo_selezionato.InIntegrazione)
                        {
                            ufGiustificativo.AbilitaModifica = true;
                            btnScaricaFornitore.Enabled = true;

                            return true;
                        }
                        else
                        {
                            lstTipoGiustificativo.Enabled = false;
                            txtNumGiustificativo.ReadOnly = true;
                            txtDataGiustificativo.ReadOnly = true;
                            txtImportoGiustificativo.ReadOnly = true;
                            txtIva.ReadOnly = true;
                            chkNonRecuperabile.Enabled = false;
                            txtDescGiustificativo.ReadOnly = true;
                            txtPivaFornitore.ReadOnly = true;
                            ufGiustificativo.AbilitaModifica = false;
                        }
                    }
                    else
                    {
                        //Se è stata protocollata la risposta, è richiesta un integrazione su questo giustificativo ma non risulta completata posso modificarlo
                        if (_giustificativo_selezionato.InIntegrazione != null && _giustificativo_selezionato.InIntegrazione)
                        {
                            if (_integrazioneSingolaDiDomandaCollectionProvider.GetByIdGiustificativo(_giustificativo_selezionato.IdGiustificativo, true, true, false).Count > 0) 
                                return false;

                            ufGiustificativo.AbilitaModifica = true;
                            btnScaricaFornitore.Enabled = true;

                            return true;
                        }
                        else
                        {
                            lstTipoGiustificativo.Enabled = false;
                            txtNumGiustificativo.ReadOnly = true;
                            txtDataGiustificativo.ReadOnly = true;
                            txtImportoGiustificativo.ReadOnly = true;
                            txtIva.ReadOnly = true;
                            chkNonRecuperabile.Enabled = false;
                            txtDescGiustificativo.ReadOnly = true;
                            txtPivaFornitore.ReadOnly = true;
                            ufGiustificativo.AbilitaModifica = false;
                        }
                    }
                }
                else
                {
                    lstTipoGiustificativo.Enabled = false;
                    txtNumGiustificativo.ReadOnly = true;
                    txtDataGiustificativo.ReadOnly = true;
                    txtImportoGiustificativo.ReadOnly = true;
                    txtIva.ReadOnly = true;
                    chkNonRecuperabile.Enabled = false;
                    txtDescGiustificativo.ReadOnly = true;
                    txtPivaFornitore.ReadOnly = true;
                    ufGiustificativo.AbilitaModifica = false;
                }
            }

            return false;
        }

        protected bool VerificaAbilitaComponentiIntegrazionePagamento(bool segnatura)
        {
            if (!_perBeneficiario)
            {
                divInserimentoFileSpese.Visible = false;
            }

            //Verifico se esistono integrazioni richieste di tipo pagamento
            if (_integrazioneSingolaDiDomandaCollectionProvider.Find(null, _integrazioneSingola.IdIntegrazioneDomanda, "PAG", null, null, null).Count > 0)
            {
                if (_spesa_selezionata != null)
                {
                    if (!segnatura)
                    {
                        //Se non è stata ancora protocollata la risposta ed è richiesta un integrazione su questo pagamento posso modificarlo
                        if (_spesa_selezionata.InIntegrazione != null && _spesa_selezionata.InIntegrazione)
                        {
                            ufPagamento.AbilitaModifica = true;
                            ufFileSpesaSostenuta.AbilitaModifica = true;
                            btnAssociaFileSpesa.Enabled = true;

                            return true;
                        }
                        else
                        {
                            lstPagamento.Enabled = false;
                            txtDataPagamento.ReadOnly = true;
                            txtImportoLordoPagamento.ReadOnly = true;
                            txtImportoNettoPagamento.ReadOnly = true;
                            txtEstremi.ReadOnly = true;
                            ufPagamento.AbilitaModifica = false;
                        }
                    }
                    else
                    {
                        //Se è stata protocollata la risposta, è richiesta un integrazione su questo pagamento ma non risulta completata posso modificarlo
                        if (_spesa_selezionata.InIntegrazione != null && _spesa_selezionata.InIntegrazione)
                        {
                            if (_integrazioneSingolaDiDomandaCollectionProvider.GetByIdSpesa(_spesa_selezionata.IdSpesa, true, true, false).Count > 0)
                            {
                                divInserimentoFileSpese.Visible = false;
                                bloccaRimuovi = true;
                                return false;
                            }

                            ufPagamento.AbilitaModifica = true;
                            ufFileSpesaSostenuta.AbilitaModifica = true;

                            return true;
                        }
                        else
                        {
                            lstPagamento.Enabled = false;
                            txtDataPagamento.ReadOnly = true;
                            txtImportoLordoPagamento.ReadOnly = true;
                            txtImportoNettoPagamento.ReadOnly = true;
                            txtEstremi.ReadOnly = true;
                            ufPagamento.AbilitaModifica = false;
                        }
                    }
                }
                else
                {
                    lstPagamento.Enabled = false;
                    txtDataPagamento.ReadOnly = true;
                    txtImportoLordoPagamento.ReadOnly = true;
                    txtImportoNettoPagamento.ReadOnly = true;
                    txtEstremi.ReadOnly = true;
                    ufPagamento.AbilitaModifica = false;
                }
            }

            return false;
        }

        protected void AbilitaComponentiIntegrazioneAllegatoIstruttore() { }

        #region Button_Click

        protected void btnSalvaAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(true);

                if (!AbilitaModifica && _domandaDiPagamento.InIntegrazione != null && !_domandaDiPagamento.InIntegrazione) 
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                if (string.IsNullOrEmpty(lstCategoriaAllegato.SelectedValue)) 
                    throw new Exception("E' obbligatorio selezionare la categoria del documento.");
                TipoDocumento tipologia = new TipoDocumentoCollectionProvider().GetById(lstCategoriaAllegato.SelectedValue);
                if (tipologia == null) 
                    throw new Exception("La tipologia di documento selezionata non è valida.");

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                if (_allegato_selezionato == null)
                {
                    _allegato_selezionato = new DomandaPagamentoAllegati();
                    _allegato_selezionato.IdDomandaPagamento = _domandaDiPagamento.IdDomandaPagamento;
                    _allegato_selezionato.DataInserimento = DateTime.Now;
                    _allegato_selezionato.CfInserimento = _operatore.Utente.CfUtente;
                }
                _allegato_selezionato.CodTipoDocumento = lstCategoriaAllegato.SelectedValue;
                if (tipologia.Formato == "C") 
                    throw new Exception("La tipologia di documento selezionata non è più valida.");
                else if (tipologia.Formato == "S")
                {
                    if (string.IsNullOrEmpty(lstNATipoEnte.SelectedValue) || string.IsNullOrEmpty(hdnCodEnte.Value)
                        || string.IsNullOrEmpty(txtNADatadoc.Text) || string.IsNullOrEmpty(txtNANumeroDoc.Text))
                        throw new Exception("Specificare tutti i campi previsti per l'identificazione del documento.");
                    //if (ente.CodTipoEnte == null) throw new Exception("Non è stata specificata l'amministrazione emettitrice del documento selezionato.");
                    if (lstNATipoEnte.SelectedValue == "CM")
                    {
                        int id_comune;
                        if (!int.TryParse(hdnCodEnte.Value, out id_comune)) throw new Exception("Non è stato specificato il comune emettitore del documento selezionato.");
                        _allegato_selezionato.IdComune = id_comune;
                        _allegato_selezionato.CodEnteEmettitore = null;
                    }
                    else
                    {
                        _allegato_selezionato.CodEnteEmettitore = hdnCodEnte.Value;
                        _allegato_selezionato.IdComune = null;
                    }
                    _allegato_selezionato.Numero = txtNANumeroDoc.Text;
                    _allegato_selezionato.Data = txtNADatadoc.Text;
                    _allegato_selezionato.IdFile = null;
                }
                else
                {
                    if (ufcNAAllegato.IdFile == null) 
                        throw new Exception("La categoria di documento selezionata richiede di caricare il documento digitale.");
                    _allegato_selezionato.IdFile = ufcNAAllegato.IdFile;
                    _allegato_selezionato.CodEnteEmettitore = null;
                    _allegato_selezionato.IdComune = null;
                    _allegato_selezionato.Numero = null;
                    _allegato_selezionato.Data = null;
                }

                _allegato_selezionato.Descrizione = txtDescrizione.Text;
                _allegato_selezionato.DataModifica = DateTime.Now;
                _allegato_selezionato.CfModifica = _operatore.Utente.CfUtente;
                _allegato_selezionato.InIntegrazione = true;

                _allegatiCollectionProvider.Save(_allegato_selezionato);
                _integrazioneSingola.IdAllegato = _allegato_selezionato.IdAllegato;
                _integrazioneSingola.DataModifica = DateTime.Now;
                _integrazioneSingolaDiDomandaCollectionProvider.Save(_integrazioneSingola); 
                _allegato_selezionato = _allegatiCollectionProvider.GetById(_allegato_selezionato.IdAllegato);
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
                PagePrivate.ShowMessage("Allegato salvato correttamente.");
            }
            catch (Exception ex) 
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback();
                PagePrivate.ShowError(ex.Message); 
            }
        }

        protected void btnEliminaAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica && _domandaDiPagamento.InIntegrazione != null && !_domandaDiPagamento.InIntegrazione) 
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                RicaricaDaCampiNascosti(true);

                if (_allegato_selezionato == null) 
                    throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                if (_allegato_selezionato == null || _allegato_selezionato.IdDomandaPagamento != _domandaDiPagamento.IdDomandaPagamento)
                    throw new Exception("Errore nella selezione dell`allegato. Impossibile continuare.");
                _allegatiCollectionProvider.Delete(_allegato_selezionato);
                _integrazioneSingola.IdAllegato = null;
                _integrazioneSingolaDiDomandaCollectionProvider.Save(_integrazioneSingola);
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
                PagePrivate.ShowMessage("Allegato eliminato correttamente.");
                PagePrivate.RegisterClientScriptBlock("pulisciCampi();");
            }
            catch (Exception ex) 
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback();
                PagePrivate.ShowError(ex); 
            }
        }

        protected void btnVisualizzaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(false);

                string pagina_risoluzione, link_spese_sostenute, link_piano_investimenti, link_allegati;
                if (PerBeneficiario)
                {
                    pagina_risoluzione = PATH_PPAGAMENTO;
                    link_spese_sostenute = "SpeseSostenute.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                    link_piano_investimenti = "PianoInvestimenti.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                    link_allegati = "FirmaRichiesta.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                }
                else
                {
                    pagina_risoluzione = PATH_IPAGAMENTO;
                    link_spese_sostenute = "IstruttoriaSpeseSostenute.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                    link_piano_investimenti = "IstruttoriaPianoInvestimenti.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                    link_allegati = "IstruttoriaAllegati.aspx?idpag=" + _integrazioneSingola.IdDomandaPagamento;
                }

                switch (_integrazioneSingola.DescrizioneTipoIntegrazione)
                {
                    case "Spese sostenute pagamento":
                        pagina_risoluzione += link_spese_sostenute;
                        Session["id_spesa_integrazione"] = _integrazioneSingola.IdSpesa;
                        break;
                    case "Spese sostenute giustificativo":
                        pagina_risoluzione += link_spese_sostenute;
                        Session["id_giustificativo_integrazione"] = _integrazioneSingola.IdGiustificativo;
                        break;
                    case "Piano investimenti":
                        pagina_risoluzione += link_piano_investimenti;
                        break;
                    case "Allegati":
                        pagina_risoluzione += link_allegati;
                        Session["id_allegato_integrazione"] = _integrazioneSingola.IdAllegato;
                        break;
                    default: throw new Exception("Errore di tipologia");
                }

                Session["id_integrazione_domanda"] = _integrazioneSingola.IdIntegrazioneDomanda;
                Response.Redirect(pagina_risoluzione);
            }
            catch (Exception ex) 
            { 
                PagePrivate.ShowError(ex); 
            }
        }

        protected void btnSalvaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(false);

                if (PerBeneficiario)
                {
                    BoolNT newValue = comboCompletataSingolaIntegrazioneDomandaBeneficiario.SelectedValue;
                    string messaggio = IntegrazioniDomandaPagamentoUtility.salvaSingolaIntegrazioneBeneficiario(_integrazioneSingola, newValue, txtNoteSingolaIntegrazioneBeneficiario.Text, txtDataRilascio.Text);

                    if (messaggio.StartsWith("Integrazione"))
                        PagePrivate.ShowMessage(messaggio);
                    else
                        PagePrivate.ShowError(messaggio);
                }
                else
                {
                    BoolNT newValueIstruttore = comboCompletataSingolaIntegrazioneDomandaIstruttore.SelectedValue;
                    BoolNT newValueBeneficiario = comboCompletataSingolaIntegrazioneDomandaBeneficiario.SelectedValue;
                    string message = IntegrazioniDomandaPagamentoUtility.salvaSingolaIntegrazioneIstruttore(_integrazioneSingola, newValueIstruttore, newValueBeneficiario,
                        txtNoteSingolaIntegrazioneIstruttore.Text, txtDataConclusioneRichiesta.Text);

                    var domanda_provider = new DomandaDiPagamentoCollectionProvider();
                    _domandaDiPagamento = domanda_provider.GetById(_integrazioneSingola.IdDomandaPagamento); 
                    //tentativo di fix per domande che rimangono in integrazione
                    if (Session["domanda_pagamento"] != null)
                        Session["domanda_pagamento"] = _domandaDiPagamento;

                    if (message.StartsWith("Integrazione"))
                        PagePrivate.ShowMessage(message);
                    else
                        PagePrivate.ShowError(message);
                }
            }
            catch(Exception ex)
            {
                PagePrivate.ShowError(ex.Message);
            }
        }

        protected void btnEliminaSingolaIntegrazione_Click(object sender, EventArgs e)
        {
            var domanda_provider = new DomandaDiPagamentoCollectionProvider();
            DomandaDiPagamento domanda_integrazione = null;
            int? id_domanda_pagamento = null;
            if (_integrazioneSingola != null && _integrazioneSingola.IdDomandaPagamento != null)
            {
                id_domanda_pagamento = _integrazioneSingola.IdDomandaPagamento;
                domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
            }

            string message = IntegrazioniDomandaPagamentoUtility.eliminaIntegrazioneSingola(_integrazioneSingola);

            if (message.StartsWith("Integrazione"))
            {
                PagePrivate.ShowMessage(message);
                //hdnIdIntegrazioneSingolaSelezionata = null;
                _integrazioneSingola = null;

                //Aggiorno la domanda pagamento in sessione
                if (id_domanda_pagamento != null)
                {
                    domanda_integrazione = domanda_provider.GetById(id_domanda_pagamento);
                    _domandaDiPagamento = domanda_integrazione;
                }
            }
            else
                PagePrivate.ShowError(message);
        }

        protected void btnScaricaFornitore_Click(object sender, EventArgs e)
        {
            try
            {
                ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
                Impresa i = impresa_provider.GetByCuaa(txtPivaFornitore.Text);

                if (i == null)
                {
                    txtRSFornitore.ReadOnly = false;
                    throw new Exception("Partita Iva del fornitore non presente nel nostro database, si prega di inserire manualmente la ragione sociale");
                }

                hdnIdImpresaFornitoreCercato.Value = i.IdImpresa;
                txtPivaFornitore.Text = i.CodiceFiscale.Value.ToUpper();
                txtRSFornitore.Text = i.RagioneSociale;
                PagePrivate.RegisterClientScriptBlock("return SNCVZCloseDiv();");
            }
            catch (Exception ex)
            {
                PagePrivate.ShowError(ex);
            }
        }

        protected void btnRimuoviFileSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(true);

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                if (_file_spesa != null)
                {
                    _speseSostenuteFileCollectionProvider.Delete(_file_spesa);
                    PagePrivate.ShowMessage("File rimosso.");
                    hdnIdFileSpesaSostenuta.Value = null;
                    _file_spesa = null;
                }
                else
                    PagePrivate.ShowError("Non è stato possibile rimuovere il file.");

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex) 
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback();
                PagePrivate.ShowError(ex.ToString()); 
            }
        }

        protected void btnAssociaFileSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(true);

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                if (ufFileSpesaSostenuta.IdFile == null
                    || txtDescrizioneFile.Text == null || txtDescrizioneFile.Text.Equals(""))
                    throw new Exception("File non caricato o descrizione mancante.");
                else
                {
                    if (_file_spesa != null)
                    {
                        _file_spesa.Descrizione = txtDescrizioneFile.Text;
                        _file_spesa.IdFile = ufFileSpesaSostenuta.IdFile;
                        _file_spesa.CfModifica = _operatore.Utente.CfUtente;
                        _file_spesa.DataModifica = DateTime.Now;
                        _file_spesa.InIntegrazione = true;
                        _speseSostenuteFileCollectionProvider.Save(_file_spesa);

                        hdnIdFileSpesaSostenuta.Value = null;
                        _file_spesa = null;
                    }
                    else
                    {
                        if (_spesa_selezionata != null)
                        {
                            _file_spesa = new SpeseSostenuteFile();
                            _file_spesa.IdSpesa = _spesa_selezionata.IdSpesa;
                            _file_spesa.Descrizione = txtDescrizioneFile.Text;
                            _file_spesa.IdFile = ufFileSpesaSostenuta.IdFile;
                            _file_spesa.DataInserimento = DateTime.Now;
                            _file_spesa.CfInserimento = _operatore.Utente.CfUtente;
                            _file_spesa.CfModifica = _operatore.Utente.CfUtente;
                            _file_spesa.DataModifica = DateTime.Now;
                            _file_spesa.InIntegrazione = true;
                            _speseSostenuteFileCollectionProvider.Save(_file_spesa);

                            hdnIdFileSpesaSostenuta.Value = null;
                            _file_spesa = null;
                        }
                        else
                            throw new Exception("Errore durante l'associazione del file alla spesa.");
                    }
                }

                PagePrivate.ShowMessage("File salvato correttamente.");
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex) 
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback();
                PagePrivate.ShowError(ex.Message); 
            }
        }

        protected void btnSalvaGiustificativiSpesa_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(true);

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                if (_spesa_selezionata != null) //MODIFICA DELLA SPESA
                {
                    var giustificativo = _giustificativiCollectionProvider.GetById(_spesa_selezionata.IdGiustificativo);
                    if (_spesa_selezionata == null || giustificativo == null) 
                        throw new SiarException(TextErrorCodes.GenericoConLink);

                    if (ufPagamento.IdFile == null || ufGiustificativo.IdFile == null)
                        throw new Exception("E` necessario caricare il documento digitale sia del giustificativo che del pagamento.");

                    //riempiCampiGiustificativo(ref giustificativo);
                    riempiCampiSpesaSostenuta(ref _spesa_selezionata);
                    
                    //pre modifica 16-02-2023 Commentato controllo campi giustificativi per PASS#187931
                    //controlloCampiGiustificativo(ref giustificativo, _spesa_selezionata.IdSpesa);
                    //post modifica 16-02-2023 Commentato controllo campi giustificativi per PASS#187931 
                    ////controlloCampiGiustificativo(ref giustificativo, _spesa_selezionata.IdSpesa); //dopo la modifica non serve più fare il controllo

                    //if ((giustificativo.InIntegrazione != null && giustificativo.InIntegrazione) || _domandaDiPagamento.Segnatura == null)
                    //    _giustificativiCollectionProvider.Save(giustificativo);

                    if ((_spesa_selezionata.InIntegrazione != null && _spesa_selezionata.InIntegrazione) || _domandaDiPagamento.Segnatura == null)
                        _speseSostenuteCollectionProvider.Save(_spesa_selezionata);
                }
                else //MODIFICA DEL GIUSTIFICATIVO
                {
                    if (_giustificativo_selezionato != null)
                    {
                        if (ufGiustificativo.IdFile == null)
                            throw new Exception("E` necessario caricare il documento digitale del giustificativo.");

                        riempiCampiGiustificativo(ref _giustificativo_selezionato);
                        //controlloCampiGiustificativo(ref _giustificativo_selezionato, -1);
                    }
                    else
                    {
                        throw new SiarException("Giustificativo non trovato");
                    }

                    //riempiCampiSpesaSostenuta(ref spesa);
                    //spesa.IdGiustificativo = giustificativo.IdGiustificativo;
                    //_speseSostenuteCollectionProvider.Save(spesa);

                    if ((_giustificativo_selezionato.InIntegrazione != null && _giustificativo_selezionato.InIntegrazione) || _domandaDiPagamento.Segnatura == null)
                        _giustificativiCollectionProvider.Save(_giustificativo_selezionato);
                }

                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
                PagePrivate.ShowMessage("Modifiche salvate correttamente.");
            }
            catch (Exception ex) 
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback(); 
                PagePrivate.ShowError(ex); 
            }
        }

        protected void btnPostFileSpesa_Click(object sender, EventArgs e) 
        {
            try
            {
                RicaricaDaCampiNascosti(false);
            }
            catch (Exception ex)
            {
                PagePrivate.ShowError(ex);
            }
        }

        protected void btnAmmettiAllegato_Click(object sender, EventArgs e)
        {
            try
            {
                RicaricaDaCampiNascosti(true);
                
                if (_allegato_selezionato != null)
                {
                    _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.BeginTran();

                    //aggiorno la segnatura
                    //DomandaPagamento.SegnaturaAllegati = txtNumProtocollo.Text;
                    //PagamentoProvider.Save(DomandaPagamento);
                    //salvo le valutazioni

                    string codEsito = null, note = null;
                    foreach (string s in Request.Form.AllKeys)
                    {
                        if (s.EndsWith("lstEsito" + _allegato_selezionato.IdAllegato)) 
                            codEsito = Request.Form[s];
                        else if (s.EndsWith("txtNote" + _allegato_selezionato.IdAllegato + "_text")) 
                            note = Request.Form[s];
                    }
                    _allegato_selezionato.CodEsito = codEsito;
                    _allegato_selezionato.NoteIstruttore = note;
                    _allegato_selezionato.CfModifica = _operatore.Utente.CfUtente;
                    _allegato_selezionato.DataModifica = DateTime.Now;
                    _allegatiCollectionProvider.Save(_allegato_selezionato);

                    _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Commit();
                    PagePrivate.ShowMessage("Valutazione degli allegati salvata corettamente.");
                }
                else
                {
                    throw new Exception("Allegato non trovato");
                }
            }
            catch (Exception ex)
            {
                _integrazioneSingolaDiDomandaCollectionProvider.DbProviderObj.Rollback();
                PagePrivate.ShowError(ex);
            }
        }

        #endregion Button_Click

        #region DataGridDatabound

        void dgFileSpeseSostenute_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var d = (SpeseSostenuteFile)e.Item.DataItem;

                if (_spesa_selezionata.InIntegrazione == null || !_spesa_selezionata.InIntegrazione)
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace(" onclick", "disabled=\"disabled\" onclick");
                else
                    e.Item.Cells[3].Text = e.Item.Cells[3].Text.Replace("disabled=\"disabled\"", "");
            }

            if (!_perBeneficiario || bloccaRimuovi)
                e.Item.Cells[3].Visible = false;
        }

        void dgAllegati_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataGridItem dgi = (DataGridItem)e.Item;
                DomandaPagamentoAllegati allegato = (DomandaPagamentoAllegati)dgi.DataItem;

                switch (allegato.Formato.Value)
                {
                    case "C":
                        e.Item.Cells[2].Text += "<b>Breve descrizione:</b> " + allegato.Descrizione;
                        if (allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        e.Item.Cells[3].Text = "";

                        break;
                    case "D":
                        e.Item.Cells[2].Text +=
                            "<b>Categoria:</b> " + allegato.TipologiaDocumento
                            + "<br><b>Breve descrizione:</b> " + allegato.Descrizione;
                        if (allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        break;
                    case "S":
                        e.Item.Cells[2].Text +=
                            "<b>Categoria:</b> " + allegato.TipologiaDocumento
                            + "<br><b>Estremi documento:</b> "
                            + "<br /><b>Nr.</b> " + allegato.Numero + " <b>del</b> " + allegato.Data
                            + "<br /><b>Presso:</b> " + allegato.Ente
                            + "<br /><b>Descrizione:</b> " + allegato.Descrizione;
                        if (allegato.DataInserimento != null)
                            e.Item.Cells[2].Text += "<br><b>Data inserimento:</b> " + allegato.DataInserimento;

                        e.Item.Cells[3].Text = "";
                        break;
                }
                //Formato allegato
                HiddenField hd = new HiddenField();
                hd.ID = "hdnFormato" + allegato.IdAllegato;
                hd.Value = allegato.Formato.Value;
                dgi.Cells[4].Controls.Add(hd);
                //ComboEsitoStep
                ComboEsiti cb = new ComboEsiti();
                cb.ID = "lstEsito" + allegato.IdAllegato;
                cb.DataBind();
                cb.SelectedValue = allegato.CodEsito;
                dgi.Cells[4].Controls.Add(cb);

                //testo area
                TextArea ta = new TextArea();
                ta.Rows = 3;
                ta.Width = new Unit(360);
                ta.ID = "txtNote" + allegato.IdAllegato;
                ta.Text = allegato.NoteIstruttore;
                dgi.Cells[5].Controls.Add(ta);
            }
        }

        #endregion DataGridDatabound
    }
}