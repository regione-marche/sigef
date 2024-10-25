using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarBLL;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarLibrary.Web;

namespace web.CONTROLS
{
    public partial class ImpresaControl : UserControl
    {
        private Impresa _impresa;
        private Progetto _progetto;

        public Impresa Impresa
        {
            get { return _impresa; }
            set { _impresa = value; }
        }

        public Progetto Progetto
        {
            get { return _progetto; }
            set { _progetto = value; }
        }

        private bool _datiCaricati = false;
        public bool DatiCaricati
        {
            get { return _datiCaricati; }
            set { _datiCaricati = value; }
        }

        private bool _datiSalvati = false;
        public bool DatiSalvati
        {
            get { return _datiSalvati; }
            set { _datiSalvati = value; }
        }

        private bool _classificazioneUmaVisibile = false;
        public bool ClassificazioneUmaVisibile
        {
            get { return _classificazioneUmaVisibile; }
            set { _classificazioneUmaVisibile = value; }
        }

        private bool _contoCorrenteVisibile = false;
        public bool ContoCorrenteVisibile
        {
            get { return _contoCorrenteVisibile; }
            set { _contoCorrenteVisibile = value; }
        }

        private bool _salvaIstruttoria = false;
        public bool SalvaIstruttoria
        {
            get { return _salvaIstruttoria; }
            set { _salvaIstruttoria = value; }
        }

        private bool _inserisciImpresaPerPresentazioneDomanda = false;
        public bool InserisciImpresaPerPresentazioneDomanda
        {
            get { return _inserisciImpresaPerPresentazioneDomanda; }
            set { _inserisciImpresaPerPresentazioneDomanda = value; }
        }

        private bool _abilitaModifica = false;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }

        public bool AnagrafeEdit
        {
            get; set;
        } = false;

        public bool ContoCorrenteObbligatorio
        {
            get; set;
        } = false;

        private bool _proseguiAbilitato = true;
        public bool ProseguiAbilitato
        {
            get { return _proseguiAbilitato; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + txtRLComuneResidenza.ClientID + @"_text').impostaAutoComplete('getComuniAttivi', 0, 3, 30, [['" + IdRLComuneResidenzaHide.ClientID + @"', 'codice'], ['" + txtRLComuneResidenza.ClientID + @"', 'denominazione'], ['" + txtRLProvinciaResidenza.ClientID + @"', 'prov'], ['" + txtRLCapResidenza.ClientID + @"', 'cap']], 'Comuni');
            ");

            ((PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + txtRLComuneNascita.ClientID + @"_text').impostaAutoComplete('getComuniAttiviENon', 0, 3, 70, [['" + IdRLComuneNascitaHide.ClientID + @"', 'codice'], ['" + txtRLComuneNascita.ClientID + @"', 'denominazione'], ['" + txtRLProvinciaNascita.ClientID + @"', 'prov'], ['" + txtRLCapNascita.ClientID + @"', 'cap']], 'Comuni');
            ");

            ((PrivatePage)Page).RegisterClientScriptBlock(@"
                $('" + txtSLComune.ClientID + @"_text').impostaAutoComplete('getComuniAttivi', 0, 3, 30, [['" + IdSLComuneHide.ClientID + @"', 'codice'], ['" + txtSLComune.ClientID + @"', 'denominazione'], ['" + txtSLProvincia.ClientID + @"', 'prov'], ['" + txtSLCap.ClientID + @"', 'cap']], 'Comuni');
            ");

            ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
            bool entePubblico = false;
            if (_impresa != null)
                entePubblico = impresa_provider.VerificaBeneficiarioEntePubblico(_impresa.IdImpresa);
            setControlliObbligatori(impresa_provider, entePubblico);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected void ControllaControlli(Control c)
        {
            if (c.Controls.Count > 0)
            {
                foreach (Control cSotto in c.Controls)
                    ControllaControlli(cSotto);
            }

            if (c.ID != null && c.ID.Contains("_req"))
            {
                RequiredFieldValidator campoObbligatorio = (RequiredFieldValidator)c;
                campoObbligatorio.ValidationGroup = "ValidazioneImpresa";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //assegno il validation group
            foreach (Control c in tableImpresaControl.Controls)
            {
                ControllaControlli(c);
            }

            if (Progetto != null && Progetto.IdBando != null)
            {
                string parametroEdit = new BandoConfigCollectionProvider().GetBandoConfig_EditImpresa(Progetto.IdBando);

                AnagrafeEdit = AnagrafeEdit || !string.IsNullOrEmpty(parametroEdit) && bool.Parse(parametroEdit) && Progetto.CodStato == "P";
            }

            //spostato if per usare il controllo senza progetto
            if (AnagrafeEdit)
            {
                // se  è editabile i controlli dovranno essere non readonly
                setControlliReadOnly(false);
            }

            if (!_datiCaricati)
                loadData();
            lstFormaGiuridica.DataBind();
            lstDimensione.DataBind();
            btnSalva.Enabled = AbilitaModifica;
            btnScaricaAT.Enabled = AbilitaModifica;

            if (_salvaIstruttoria)
            {
                btnSalva.Visible = false;
                btnSalvaIstruttoria.Visible = true;
            }

            if (_inserisciImpresaPerPresentazioneDomanda)
            {
                btnSalva.Visible = false;
                btnSalvaConDichiarazione.Visible = true;
            }

            ComboAteco.Items.Clear();
            ComboAteco.Items.Add("");
            TipoAteco2007CollectionProvider ateco_prov = new TipoAteco2007CollectionProvider();
            TipoAteco2007Collection ateco = ateco_prov.Find(null);
            foreach (TipoAteco2007 a in ateco)
                ComboAteco.Items.Add(new ListItem(a.Sottocategoria + " - " + a.Descrizione, a.CodTipoAteco2007));
            foreach (ListItem li in ComboAteco.Items)
                if (li.Value == ComboAteco.SelectedValue) { li.Selected = true; break; }

            //se inserisco l'impresa riduco i controlli
            if (_impresa == null)
            {
                btnSalva.ValidationGroup = null;
                btnSalva.CausesValidation = false;
            }
            else
            {
                if (_impresa.IdImpresa != null)
                {
                    var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();
                    var impresaVisura = impresaVisuraProvider.GetUltimaVisuraImpresa(_impresa.IdImpresa);

                    if (impresaVisura != null && impresaVisura.IdFileVisura != null)
                    {
                        btnUltimaVisura.Visible = true;
                        btnUltimaVisura.OnClientClick = "SNCUFVisualizzaFile(" + impresaVisura.IdFileVisura + ");";
                    }
                }
            }

            base.OnPreRender(e);
        }

        private void setControlliReadOnly(bool isEdit)
        {
            txtRagioneSociale.ReadOnly = isEdit;
            txtCuaa.ReadOnly = isEdit;
            txtPiva.ReadOnly = isEdit;
            txtDataInizioAttivita.ReadOnly = isEdit;
            txtAnnoRea.ReadOnly = isEdit;
            txtNumeroRea.ReadOnly = isEdit;
            txtNumeroRegistroImprese.ReadOnly = isEdit;
            txtSLIndirizzo.ReadOnly = isEdit;
            txtSLComune.ReadOnly = isEdit;
            //txtSLCap.ReadOnly = isEdit;
            txtRLNome.ReadOnly = isEdit;
            txtRLCognome.ReadOnly = isEdit;
            txtRLCFiscale.ReadOnly = isEdit;
            txtRLDataNascita.ReadOnly = isEdit;
            txtRLComuneNascita.ReadOnly = isEdit;
            //txtRLCapNascita.ReadOnly = isEdit;
            txtRLIndirizzoResidenza.ReadOnly = isEdit;
            txtRLComuneResidenza.ReadOnly = isEdit;
            //txtRLCapResidenza.ReadOnly = isEdit;
        }

        private void setControlliObbligatori(ImpresaCollectionProvider impresa_provider, bool entePubblico)
        {
            bool impresaNuova = false;


            //if (!(txtCuaa.Style["display"] == "none"))
            //{
            if (_impresa == null)
            {
                var impresaRicercata = impresa_provider.GetByCuaa(txtPiva.Text);
                if (impresaRicercata == null)
                    impresaNuova = true;
            }

            // QUESTI SONO SEMPRE OBBLIGATORI, sotto verifico altre casistiche

            //Generalità del benficiario
            txtCuaa.Obbligatorio = true;
            txtPiva.Obbligatorio = true;
            txtDataInizioAttivita.Obbligatorio = true;
            txtRagioneSociale.Obbligatorio = true;

            //Sede legale
            txtSLIndirizzo.Obbligatorio = true;
            txtSLComune.Obbligatorio = true;
            txtSLPec.Obbligatorio = true;

            //Rappresentante legale
            txtRLNome.Obbligatorio = true;
            txtRLCognome.Obbligatorio = true;
            txtRLCFiscale.Obbligatorio = true;
            txtRLDataNascita.Obbligatorio = true;
            txtRLComuneNascita.Obbligatorio = true;
            txtRLIndirizzoResidenza.Obbligatorio = true;
            txtRLComuneResidenza.Obbligatorio = true;

            if (InserisciImpresaPerPresentazioneDomanda)
            {
                //In questo caso tutti i campi sono obbligatori

                //Generalità del beneficiario
                lstFormaGiuridica.Obbligatorio = true;
                ComboAteco.Obbligatorio = true;

                //Per beneficiari tipo impresa
                if (!entePubblico)
                {
                    lstDimensione.Obbligatorio = true;
                    txtNumeroRegistroImprese.Obbligatorio = true;
                    txtNumeroRea.Obbligatorio = true;
                    txtAnnoRea.Obbligatorio = true;
                }

                //Sede legale
                txtSLTelefono.Obbligatorio = true;
                txtSLEmail.Obbligatorio = true;

                //Conto corrente
                txtCodiceIntero.Obbligatorio = true;
                txtCAB.Obbligatorio = true;
            }
            else
            {
                if (!impresaNuova)
                {
                    //Generalità del beneficiario
                    lstFormaGiuridica.Obbligatorio = true;
                    ComboAteco.Obbligatorio = true;

                    //Per beneficiari tipo impresa
                    if (!entePubblico)
                        lstDimensione.Obbligatorio = true;

                    //Sede legale
                    txtSLTelefono.Obbligatorio = true;
                    txtSLEmail.Obbligatorio = true;
                }

                //Conto corrente
                if (ContoCorrenteObbligatorio)
                {
                    txtNumeroConto.Obbligatorio = true;
                    txtCAB.Obbligatorio = true;
                }
            }
            //}
        }

        private string verificaControlliObbligatori(ImpresaCollectionProvider impresa_provider, bool entePubblico)
        {
            string errore = "";
            bool impresaNuova = false;

            //sostituita quella presente nell'ascx con una presa con ChatGpt
            var regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"); 

            if (_impresa == null)
            {
                var impresaRicercata = impresa_provider.GetByCuaa(txtPiva.Text);
                if (impresaRicercata != null)
                    throw new Exception("Esiste già un impresa con partita iva o codice fiscale " + txtPiva.Text + " con ragione sociale " + impresaRicercata.RagioneSociale + " nel database!");

                impresaNuova = true;
                _impresa = new Impresa();
            }

            // QUESTI SONO SEMPRE OBBLIGATORI, sotto verifico altre casistiche

            //Generalità del benficiario
            if (string.IsNullOrEmpty(txtCuaa.Text))
                errore += "Inserire un codice fiscale valido; <br />";
            if (!string.IsNullOrEmpty(txtCuaa.Text) && (txtCuaa.Text.Length > 16 || txtCuaa.Text.Length < 11))
                errore += "Codice fiscale di lughezza sbagliata; <br />";
            if (string.IsNullOrEmpty(txtPiva.Text))
                errore += "Inserire una piva valida; <br />";
            if (!string.IsNullOrEmpty(txtPiva.Text) && !VerificaPartitaIvaBase(txtPiva.Text))
                errore += "Piva di lunghezza sbagliata; <br />";
            if (string.IsNullOrEmpty(txtDataInizioAttivita.Text))
                errore += "Inserire una data di inizio attività; <br />";
            if (string.IsNullOrEmpty(txtRagioneSociale.Text))
                errore += "Inserire una ragione sociale; <br />";
            if (!string.IsNullOrEmpty(txtRagioneSociale.Text) && txtRagioneSociale.Text == " ")
                errore += "Inserire una ragione sociale non vuota; <br />";

            //Sede legale
            if (string.IsNullOrEmpty(txtSLIndirizzo.Text))
                errore += "Inserire un indirizzo per la sede legale; <br />";
            if (string.IsNullOrEmpty(txtSLComune.Text))
                errore += "Inserire un comune per la sede legale; <br />";
            if (string.IsNullOrEmpty(txtSLPec.Text))
                errore += "Pec obbligatoria. <br/>";


            if (!regexEmail.IsMatch(txtSLPec.Text))
                errore += "Inserire una pec valida. <br/>";

            //Rappresentante legale
            if (string.IsNullOrEmpty(txtRLNome.Text))
                errore += "Inserire un nome per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLCognome.Text))
                errore += "Inserire un cognome per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLCFiscale.Text))
                errore += "Inserire un codice fiscale valido per il rappresentante legale; <br />";
            if (!string.IsNullOrEmpty(txtRLCFiscale.Text) && txtRLCFiscale.Text.Length != 16)
                errore += "Codice fiscale di lughezza sbagliata per il legale rappresentante; <br />";
            if (string.IsNullOrEmpty(txtRLDataNascita.Text))
                errore += "Inserire una data di nascita per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLComuneNascita.Text))
                errore += "inserire un comune di nascita per il rappresentante legale; <br />";

            if (InserisciImpresaPerPresentazioneDomanda)
            {
                //In questo caso tutti i campi sono obbligatori

                //Generalità del beneficiario
                if (string.IsNullOrEmpty(lstFormaGiuridica.SelectedValue))
                    errore += "Forma giuridica obbligatoria. <br/>";
                if (string.IsNullOrEmpty(ComboAteco.SelectedValue))
                    errore += "Codice ATECO obbligatorio. <br/>";

                //Per beneficiari tipo impresa
                if (!entePubblico)
                {
                    if (string.IsNullOrEmpty(lstDimensione.SelectedValue))
                        errore += "Dimensione impresa obbligatoria. <br/>";
                    if (string.IsNullOrEmpty(txtNumeroRegistroImprese.Text))
                        errore += "Numero registro imprese obbligatoria. <br/>";
                    if (string.IsNullOrEmpty(txtNumeroRea.Text))
                        errore += "Numero REA obbligatoria. <br/>";
                    if (string.IsNullOrEmpty(txtAnnoRea.Text))
                        errore += "Anno iscrizione REA obbligatoria. <br/>";
                }

                //Sede legale
                if (string.IsNullOrEmpty(txtSLTelefono.Text))
                    errore += "Telefono sede legale obbligatorio. <br/>";
                if (string.IsNullOrEmpty(txtSLEmail.Text))
                    errore += "Email obbligatoria. <br/>";

                if (!regexEmail.IsMatch(txtSLEmail.Text))
                    errore += "Inserire una email valida. <br/>";

                //Rappresentante legale
                if (string.IsNullOrEmpty(txtRLIndirizzoResidenza.Text))
                    errore += "Indirizzo residenza rappresentante legale obbligatoria. <br/>";
                if (string.IsNullOrEmpty(txtRLComuneResidenza.Text))
                    errore += "Comune di residenza rappresentante legale obbligatoria. <br/>";

                //Conto corrente
                if (string.IsNullOrEmpty(txtCodiceIntero.Text))
                    errore += "IBAN obbligatorio. <br/>";
                if (string.IsNullOrEmpty(txtCAB.Text))
                    errore += "IBAN non controllato. <br/>";
            }
            else
            {
                if (!impresaNuova)
                {
                    //Generalità del beneficiario
                    if (string.IsNullOrEmpty(lstFormaGiuridica.SelectedValue))
                        errore += "Forma giuridica obbligatoria. <br/>";
                    if (string.IsNullOrEmpty(ComboAteco.SelectedValue))
                        errore += "Codice ATECO obbligatorio. <br/>";

                    //Per beneficiari tipo impresa
                    if (!entePubblico && string.IsNullOrEmpty(lstDimensione.SelectedValue))
                        errore += "Dimensione impresa obbligatoria per enti privati. <br/>";

                    //Sede legale
                    if (string.IsNullOrEmpty(txtSLTelefono.Text))
                        errore += "Telefono obbligatorio. <br/>";
                    if (string.IsNullOrEmpty(txtSLEmail.Text))
                        errore += "Email obbligatoria. <br/>";

                    if (!regexEmail.IsMatch(txtSLEmail.Text))
                        errore += "Inserire una email valida. <br/>";
                }

                //Conto corrente
                if (ContoCorrenteObbligatorio && string.IsNullOrEmpty(txtNumeroConto.Text))
                {
                    if (string.IsNullOrEmpty(txtCodiceIntero.Text))
                        errore += "IBAN obbligatorio. <br/>";
                    if (string.IsNullOrEmpty(txtCAB.Text))
                        errore += "IBAN non controllato. <br/>";
                }
            }

            if (entePubblico && Progetto != null && txtPecUfficio.Text != "")
            {
                if (!regexEmail.IsMatch(txtPecUfficio.Text))
                    errore += "Inserire una PEC per l'ufficio valida. <br/>";
            }

            return errore;
        }

        public void loadData()
        {
            if (_impresa == null) _proseguiAbilitato = false;
            else
            {
                btnSalva.Enabled = _abilitaModifica;
                txtCuaa.Text = _impresa.Cuaa;
                txtPiva.Text = _impresa.CodiceFiscale;
                txtDataInizioAttivita.Text = _impresa.DataInizioAttivita;
                txtRagioneSociale.Text = _impresa.RagioneSociale;
                txtNumeroRegistroImprese.Text = _impresa.RegistroImpreseNumero;
                txtNumeroRea.Text = _impresa.ReaNumero;
                txtAnnoRea.Text = _impresa.ReaAnno;
                lstDimensione.SelectedValue = _impresa.IdDimensione;
                lstFormaGiuridica.SelectedValue = _impresa.CodFormaGiuridica;
                ComboAteco.SelectedValue = _impresa.CodAteco2007;

                if (_impresa.IdDimensione == null || _impresa.CodFormaGiuridica == null || _impresa.CodAteco2007 == null || (_classificazioneUmaVisibile == true &&
                    (_impresa.RegistroImpreseNumero == null || _impresa.ReaNumero == null || _impresa.ReaAnno == null || _impresa.CodClassificazioneUma == null)))
                    _proseguiAbilitato = false;

                //Indirizzo Sede Legale
                if (_impresa.IdSedelegaleUltimo != null)
                {
                    Indirizzario sede_legale = new IndirizzarioCollectionProvider().GetById(_impresa.IdSedelegaleUltimo);
                    if (sede_legale == null) _proseguiAbilitato = false;
                    else
                    {
                        txtSLIndirizzo.Text = sede_legale.Via;
                        txtSLComune.Text = sede_legale.Comune;
                        txtSLProvincia.Text = sede_legale.Sigla;
                        txtSLCap.Text = sede_legale.Cap;
                        txtSLTelefono.Text = sede_legale.Telefono;
                        txtSLEmail.Text = sede_legale.Email;
                        txtSLPec.Text = sede_legale.Pec;
                        if (sede_legale.Telefono == null || sede_legale.Email == null) _proseguiAbilitato = false;
                    }
                }
                if (_impresa.IdRapprlegaleUltimo != null)
                {
                    PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(_impresa.IdRapprlegaleUltimo);
                    if (rlegale == null) _proseguiAbilitato = false;
                    else
                    {
                        txtRLNome.Text = rlegale.Nome;
                        txtRLCognome.Text = rlegale.Cognome;
                        txtRLCFiscale.Text = rlegale.CodiceFiscale;
                        if (rlegale.DataNascita != null)
                            txtRLDataNascita.Text = rlegale.DataNascita.ToFullYearString();
                        txtRLComuneNascita.Text = rlegale.Comune;
                        txtRLProvinciaNascita.Text = rlegale.Sigla;
                        txtRLCapNascita.Text = rlegale.Cap;

                        var indirizzoResidenzaColl = new IndirizzarioCollectionProvider().Find(null, rlegale.IdPersona, null, null, null, null);
                        if (indirizzoResidenzaColl.Count > 0)
                        {
                            var indirizzoResidenzaList = indirizzoResidenzaColl.ToArrayList<Indirizzario>();
                            var indirizzoResidenza = indirizzoResidenzaList
                                .Where(i => i.FlagAttivo)
                                .OrderByDescending(i => i.IdIndirizzario)
                                .FirstOrDefault();

                            if (indirizzoResidenza != null)
                            {
                                txtRLIndirizzoResidenza.Text = indirizzoResidenza.Via;
                                txtRLComuneResidenza.Text = indirizzoResidenza.Comune;
                                txtRLProvinciaResidenza.Text = indirizzoResidenza.Sigla;
                                txtRLCapResidenza.Text = indirizzoResidenza.Cap;
                            }
                        }
                    }
                }

                trCC1.Visible = _contoCorrenteVisibile;
                trCC2.Visible = _contoCorrenteVisibile;
                if (_contoCorrenteVisibile)
                {
                    btnSalva.OnClientClick = "return ICtrlControlloDatiCC(event);";
                    ContoCorrente cc = null;
                    if (_impresa.IdContoCorrenteUltimo != null)
                        cc = new ContoCorrenteCollectionProvider().GetById(_impresa.IdContoCorrenteUltimo);
                    if (cc == null)
                    {
                        _proseguiAbilitato = false;
                        btnCopiaIban.Visible = false;
                    }
                    else
                    {
                        txtCodPaese.Text = cc.CodPaese;
                        txtCINeuro.Text = cc.CinEuro;
                        txtCin.Text = cc.Cin;
                        txtABI.Text = cc.Abi;
                        txtCAB.Text = cc.Cab;
                        txtNumeroConto.Text = cc.Numero;
                        txtIstituto.Text = cc.Istituto;
                        txtAgenzia.Text = cc.Agenzia;
                        ucSiarNewComuniControl.IdComune = cc.IdComune;
                        ucSiarNewComuniControl.Denominazione = cc.Comune;
                        ucSiarNewComuniControl.Cap = cc.Cap;
                        ucSiarNewComuniControl.Provincia = cc.Sigla;
                        //if (cc.Note == "SCARICATO_DA_AGEA")  // imposto sul designer sempre disabilitato
                        //    ucSiarNewComuniControl.ReadOnly = true;

                        hdnIbanImpresa.Value = cc.CodPaese + cc.CinEuro + cc.Cin + cc.Abi + cc.Cab + cc.Numero;
                    }
                }

                if (_impresa.CodFormaGiuridica != null && _impresa.CodFormaGiuridica != "")
                {
                    Boolean EntePubblico = new ImpresaCollectionProvider().VerificaBeneficiarioEntePubblico(_impresa.IdImpresa);
                    if (EntePubblico)
                    {
                        trImpresaDim.Visible = false;
                        trImpresaRea.Visible = false;
                        trImpresaTit.Visible = false;
                        if (Progetto != null)
                        {
                            trPecUfficio.Visible = true;
                            ProgettoPecCollectionProvider pec_prov = new ProgettoPecCollectionProvider();
                            ProgettoPecCollection pec_coll = pec_prov.Find(null, Progetto.IdProgetto, null);
                            if (pec_coll.Count > 0)
                                txtPecUfficio.Text = pec_coll[0].Pec;
                        }

                    }
                }

            }
            _datiCaricati = true;
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            SalvaImpresa();
        }

        protected void btnSalvaIstruttoria_Click(object sender, EventArgs e)
        {
            string esito = SalvaImpresa();

            if (esito == "OK")
            {
                var impresaVisuraProvider = new ImpresaVisuraCollectionProvider();
                var impresaVisura = impresaVisuraProvider.GetUltimaVisuraImpresa(_impresa.IdImpresa);

                if (impresaVisura != null && impresaVisura.IdFileVisura != null)
                {
                    impresaVisura.CfIstruttore = impresaVisura.CfModifica = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                    impresaVisura.Istruita = true;
                    impresaVisura.DataIstruttoria = impresaVisura.DataModifica = DateTime.Now;
                    impresaVisuraProvider.Save(impresaVisura);
                }
            }
        }

        protected void btnSalvaConDichiarazione_Click(object sender, EventArgs e)
        {
            string esito = SalvaImpresa();

            if (esito == "OK")
            {
                var impresaDichiarazioneProvider = new ImpresaDichiarazioneCollectionProvider();

                var impresaDichiarazione = new ImpresaDichiarazione();
                impresaDichiarazione.DataInserimento = impresaDichiarazione.DataModifica = DateTime.Now;
                impresaDichiarazione.CfInserimento = impresaDichiarazione.CfModifica = impresaDichiarazione.CfUtenteDichiarazione = ((PrivatePage)Page).Operatore.Utente.CfUtente;
                impresaDichiarazione.IdImpresa = _impresa.IdImpresa;
                if (Progetto != null && Progetto.IdProgetto != null)
                {
                    impresaDichiarazione.IdProgetto = Progetto.IdProgetto;
                    impresaDichiarazione.IdBando = Progetto.IdBando;
                }
                else
                {
                    int id_bando;
                    Bando bando = null;
                    if (int.TryParse(Request.QueryString["idb"], out id_bando))
                        bando = new BandoCollectionProvider().GetById(id_bando);
                    if (bando != null)
                        impresaDichiarazione.IdBando = bando.IdBando;
                }

                impresaDichiarazioneProvider.Save(impresaDichiarazione);
            }
        }

        private string SalvaImpresa()
        {
            string esito = "OK";
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
                bool entePubblico = false;
                if (_impresa != null)
                    entePubblico = impresa_provider.VerificaBeneficiarioEntePubblico(_impresa.IdImpresa);
                string errore = verificaControlliObbligatori(impresa_provider, entePubblico);
                if (errore != null && errore != "")
                    throw new Exception(errore);

                if (Progetto != null && Progetto.IdBando != null)
                {
                    string parametroEdit = new BandoConfigCollectionProvider().GetBandoConfig_EditImpresa(Progetto.IdBando);

                    AnagrafeEdit = AnagrafeEdit || !string.IsNullOrEmpty(parametroEdit) && bool.Parse(parametroEdit) && Progetto.CodStato == "P";
                }

                if (AnagrafeEdit)
                    salvaDatiImpresa(_impresa);
                else
                {
                    impresa_provider.AggiornaAnagraficaImpresa(_impresa, lstFormaGiuridica.SelectedValue, lstDimensione.SelectedValue,
                        null, txtSLTelefono.Text, txtSLEmail.Text, txtSLPec.Text, txtNumeroRegistroImprese.Text, txtNumeroRea.Text,
                        txtAnnoRea.Text, txtCodPaese.Text, txtCINeuro.Text, txtCin.Text, txtABI.Text, txtCAB.Text, txtNumeroConto.Text, txtIstituto.Text,
                        txtAgenzia.Text, ucSiarNewComuniControl.IdComune, ComboAteco.SelectedValue);
                }
                _impresa = impresa_provider.GetById(_impresa.IdImpresa);

                //bool EntePubblico = new ImpresaCollectionProvider().VerificaBeneficiarioEntePubblico(_impresa.IdImpresa);
                if (entePubblico && Progetto != null && txtPecUfficio.Text != "")
                {
                    ProgettoPecCollectionProvider pec_prov = new ProgettoPecCollectionProvider();
                    ProgettoPecCollection pec_coll = pec_prov.Find(null, Progetto.IdProgetto, null);
                    ProgettoPec pec = null;
                    if (pec_coll.Count == 0)
                    {
                        pec = new ProgettoPec();
                        pec.IdProgetto = Progetto.IdProgetto;
                        pec.OperatoreCreazione = ((PrivatePage)Page).Operatore.Utente.IdUtente;
                        pec.DataCreazione = DateTime.Now;
                        pec.Pec = txtPecUfficio.Text;
                        pec_prov.Save(pec);
                    }
                    else
                    {
                        pec = pec_coll[0];
                        if (pec.Pec != txtPecUfficio.Text)
                        {
                            pec.Pec = txtPecUfficio.Text;
                            pec.OperatoreModifica = ((PrivatePage)Page).Operatore.Utente.IdUtente;
                            pec.DataModifica = DateTime.Now;
                            pec_prov.Save(pec);
                        }
                    }
                }
                _datiSalvati = true;
                ((SiarLibrary.Web.Page)Page).ShowMessage("Dati anagrafici salvati correttamente.");
            }
            catch (Exception ex)
            {
                esito = "NOT OK";
                ((SiarLibrary.Web.Page)Page).ShowError(ex);
            }

            return esito;
        }

        private string ControllaCampiEdit(bool impresaNuova)
        {
            string risultato = "";
            if (string.IsNullOrEmpty(txtCuaa.Text))
                risultato += "inserire un codice fiscale valido; <br />";
            if (!string.IsNullOrEmpty(txtCuaa.Text) && (txtCuaa.Text.Length > 16 || txtCuaa.Text.Length < 11))
                risultato += "codice fiscale di lughezza sbagliata; <br />";
            if (string.IsNullOrEmpty(txtPiva.Text))
                risultato += "inserire una piva valida; <br />";
            if (!string.IsNullOrEmpty(txtPiva.Text) && !VerificaPartitaIvaBase(txtPiva.Text))
                risultato += "piva di lunghezza sbagliata; <br />";
            if (string.IsNullOrEmpty(txtDataInizioAttivita.Text))
                risultato += "inserire una data di inizio attività; <br />";
            if (string.IsNullOrEmpty(txtRagioneSociale.Text))
                risultato += "inserire una ragione sociale; <br />";
            if (!string.IsNullOrEmpty(txtRagioneSociale.Text) && txtRagioneSociale.Text == " ")
                risultato += "inserire una ragione sociale; <br />";
            if (string.IsNullOrEmpty(txtSLIndirizzo.Text))
                risultato += "inserire un indirizzo per la sede legale; <br />";
            if (string.IsNullOrEmpty(txtSLComune.Text))
                risultato += "inserire un comune per la sede legale; <br />";
            if (string.IsNullOrEmpty(txtSLCap.Text))
                risultato += "inserire un cap per la sede legale; <br />";
            if (!string.IsNullOrEmpty(txtSLCap.Text) && !int.TryParse(txtSLCap.Text, out int cap))
                risultato += "inserire un cap valido per la sede legale; <br />";
            if (string.IsNullOrEmpty(txtRLNome.Text))
                risultato += "inserire un nome per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLCognome.Text))
                risultato += "inserire un cognome per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLCFiscale.Text))
                risultato += "inserire un codice fiscale valido per il rappresentante legale; <br />";
            if (!string.IsNullOrEmpty(txtRLCFiscale.Text) && txtRLCFiscale.Text.Length != 16)
                risultato += "codice fiscale di lughezza sbagliata per il legale rappresentante; <br />";
            if (string.IsNullOrEmpty(txtRLDataNascita.Text))
                risultato += "inserire una data di nascita per il rappresentante legale; <br />";
            if (string.IsNullOrEmpty(txtRLComuneNascita.Text))
                risultato += "inserire un comune di nascita per il rappresentante legale; <br />";
            //if (string.IsNullOrEmpty(txtRLCapNascita.Text))
            //    risultato += "inserire un cap per il comune di nascita del rappresentante legale; <br />";
            //if (!string.IsNullOrEmpty(txtRLCapNascita.Text) && !int.TryParse(txtRLCapNascita.Text, out int capN))
            //    risultato += "inserire un cap valido per il comune di nascita del rappresentante legale; <br />";
            if (ContoCorrenteObbligatorio && string.IsNullOrEmpty(txtNumeroConto.Text))
                risultato += "inserire un IBAN; <br />";
            if (!impresaNuova
                && string.IsNullOrEmpty(txtRLIndirizzoResidenza.Text))
                risultato += "inserire un indirizzo di residenza per il rappresentante legale; <br />";
            if (!impresaNuova
                && string.IsNullOrEmpty(txtRLComuneResidenza.Text))
                risultato += "inserire un comune di residenza per il rappresentante legale; <br />";
            if (!impresaNuova
                && string.IsNullOrEmpty(txtRLCapResidenza.Text))
                risultato += "inserire un cap per il comune di residenza del rappresentante legale; <br />";

            return risultato;
        }

        //Parzialmente ricavata dal controllo presente sul Main.js, controlla solo se la piva è estera o lunga 11 o 16
        private static bool VerificaPartitaIvaBase(string piva)
        {
            if (VerificaPartitaIvaEstera(piva))
                return true;

            if (piva.Length == 11
                || piva.Length == 16)
                return true;
            else
                return false;
        }

        private static bool VerificaPartitaIvaEstera(string piva)
        {
            if (piva.Length < 9)
                return false;

            var ctrlPE = piva.Substring(0, 3);

            if (ctrlPE == "DE "
                || ctrlPE == "GB "
                || ctrlPE == "FR "
                || ctrlPE == "BE "
                || ctrlPE == "AT "
                || ctrlPE == "NL "
                || ctrlPE == "DK "
                || ctrlPE == "ES "
                || ctrlPE == "CH "
                || ctrlPE == "IE "
                || ctrlPE == "CZ "
                || ctrlPE == "PL "
                || ctrlPE == "HU "
                || ctrlPE == "BE "
                || ctrlPE == "MT "
                || ctrlPE == "RO ")
                return true;

            return false;
        }

        private void salvaDatiImpresa(Impresa azienda)
        {
            ImpresaCollectionProvider impresa_provider = new ImpresaCollectionProvider();
            try
            {
                impresa_provider.DbProviderObj.BeginTran();

                //Controlli spostati sul metodo verificaControlliObbligatori()
                //string risultato = ControllaCampiEdit(impresaNuova);                
                //if (!string.IsNullOrEmpty(risultato))
                //    throw new Exception(risultato);

                azienda.CodiceFiscale = txtPiva.Text.Trim();
                azienda.Cuaa = txtCuaa.Text.Trim();
                azienda.DataInizioAttivita = txtDataInizioAttivita.Text;

                impresa_provider.Save(azienda);

                ImpresaStoricoCollectionProvider storico_provider = new ImpresaStoricoCollectionProvider(impresa_provider.DbProviderObj);

                // o editiamo la riga di storico sbagliata oppure ne mettiamo una nuova per avere un record che ci ricorda che è stata aggiunta manualmente

                ImpresaStorico impresaStorico = new ImpresaStorico();

                //ImpresaStorico impresaStorico = storico_provider.GetById(azienda.IdStoricoUltimo);

                impresaStorico.RagioneSociale = txtRagioneSociale.Text.Trim();
                impresaStorico.DataInizioValidita = azienda.DataInizioValidita;
                impresaStorico.IdImpresa = azienda.IdImpresa;

                storico_provider.Save(impresaStorico);

                azienda.IdStoricoUltimo = impresaStorico.IdStoricoImpresa;

                impresa_provider.Save(azienda);

                int id_sede_legale_ultima = AggiornaSedeImpresa(azienda.IdImpresa, "S", impresa_provider.DbProviderObj);
                AggiornaSedeImpresa(azienda.IdImpresa, "D", impresa_provider.DbProviderObj);
                int id_rapprlegale_ultimo = AggiornaPersonaXImpresa(azienda.IdImpresa, "R", impresa_provider.DbProviderObj);
                if (!string.IsNullOrEmpty(txtRLCFiscale.Text)
                    && !string.IsNullOrEmpty(txtRLComuneResidenza.Text))
                {
                    AggiornaPersonaXImpresa(azienda.IdImpresa, "D", impresa_provider.DbProviderObj);
                }

                azienda.IdSedelegaleUltimo = id_sede_legale_ultima;
                azienda.IdRapprlegaleUltimo = id_rapprlegale_ultimo;
                impresa_provider.Save(azienda);

                impresa_provider.AggiornaAnagraficaImpresa(azienda, lstFormaGiuridica.SelectedValue, lstDimensione.SelectedValue,
                    null,
                    txtSLTelefono.Text != null ? txtSLTelefono.Text.Trim() : txtSLTelefono.Text,
                    txtSLEmail.Text != null ? txtSLEmail.Text.Trim() : txtSLEmail.Text,
                    txtSLPec.Text != null ? txtSLPec.Text.Trim() : txtSLPec.Text,
                    txtNumeroRegistroImprese.Text != null ? txtNumeroRegistroImprese.Text.Trim() : txtNumeroRegistroImprese.Text,
                    txtNumeroRea.Text != null ? txtNumeroRea.Text.Trim() : txtNumeroRea.Text,
                    txtAnnoRea.Text != null ? txtAnnoRea.Text.Trim() : txtAnnoRea.Text,
                    txtCodPaese.Text,
                    txtCINeuro.Text, txtCin.Text, txtABI.Text, txtCAB.Text, txtNumeroConto.Text, txtIstituto.Text,
                    txtAgenzia.Text, ucSiarNewComuniControl.IdComune, ComboAteco.SelectedValue, impresa_provider.DbProviderObj);

                impresa_provider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                impresa_provider.DbProviderObj.Rollback();
                throw ex;
            }
        }

        private int AggiornaPersonaXImpresa(IntNT idimpresa, string ruolo, DbProvider dbObj)
        {
            SiarBLL.PersoneXImpreseCollectionProvider pxi_provider = new PersoneXImpreseCollectionProvider(dbObj);
            int id_persona_fisica = AggiornaPersonaFisica(dbObj);
            PersoneXImpreseCollection pxicoll = pxi_provider.Find(null, null, idimpresa, ruolo, true, null);
            PersoneXImprese persona_impresa;
            if (pxicoll.Count == 0)
            {
                persona_impresa = new PersoneXImprese();
                persona_impresa.IdImpresa = idimpresa;
                persona_impresa.IdPersona = id_persona_fisica;
                persona_impresa.CodRuolo = ruolo;
                persona_impresa.DataInizio = DateTime.Now;
                persona_impresa.Attivo = true;
                pxi_provider.Save(persona_impresa);
            }
            else
            {
                persona_impresa = pxicoll[0];
                if (persona_impresa.CodiceFiscale != txtRLCFiscale.Text || persona_impresa.IdPersona != id_persona_fisica || !persona_impresa.Attivo)
                {
                    //storicizzo il vecchio  
                    persona_impresa.DataFine = DateTime.Now;
                    persona_impresa.Attivo = false;
                    pxi_provider.Save(persona_impresa);
                    // e ne creo uno nuovo 
                    persona_impresa.MarkAsNew();
                    persona_impresa.IdPersona = id_persona_fisica;
                    persona_impresa.DataFine = null;
                    persona_impresa.DataInizio = DateTime.Now;
                    persona_impresa.Attivo = true;
                    pxi_provider.Save(persona_impresa);
                }
            }
            return persona_impresa.IdPersoneXImprese;
        }

        private int AggiornaPersonaFisica(DbProvider dbObj)
        {
            PersonaFisicaCollectionProvider pf_provider = new PersonaFisicaCollectionProvider(dbObj);
            PersonaFisicaCollection persone = pf_provider.Find(txtRLCFiscale.Text);
            PersonaFisica persona;
            if (persone.Count == 0) persona = InserisciPersonaFisica(ref pf_provider);
            else persona = persone[0];
            //if (persona.Nome == null) 
            ModificaPersonaFisica(ref pf_provider, ref persona);

            IndirizzoCollectionProvider indirizzo_provider = new IndirizzoCollectionProvider(dbObj);
            IntNT idindirizzo = null;
            if (!string.IsNullOrEmpty(txtRLComuneResidenza.Text))
                idindirizzo = AggiornaIndirizzo("R", ref indirizzo_provider);
            if (idindirizzo != null)
            {
                IndirizzarioCollectionProvider indirizzario_provider = new IndirizzarioCollectionProvider(dbObj);
                IndirizzarioCollection sedi = indirizzario_provider.Find(null, persona.IdPersona, null, "R", null, null);
                Indirizzario sede;
                if (sedi.Count == 0)
                {
                    sede = new Indirizzario();
                    sede.IdPersona = persona.IdPersona;
                    sede.IdIndirizzo = idindirizzo;
                    sede.CodTipoSede = "R";
                    sede.FlagAttivo = true;
                    indirizzario_provider.Save(sede);
                }
                else
                {
                    //Prima setto tutti gli indirizzari a 
                    foreach (Indirizzario sedeVecchia in sedi)
                    {
                        if (sedeVecchia.FlagAttivo)
                        {
                            sedeVecchia.DataFineValidita = DateTime.Now;
                            sedeVecchia.FlagAttivo = false;
                            indirizzario_provider.Save(sedeVecchia);
                        }
                    }

                    //poi creo la sede nuova attiva
                    sede = new Indirizzario();
                    sede.IdPersona = persona.IdPersona;
                    sede.IdIndirizzo = idindirizzo;
                    sede.CodTipoSede = "R";
                    sede.DataInizioValidita = DateTime.Now;
                    sede.FlagAttivo = true;
                    indirizzario_provider.Save(sede);
                }
            }

            return persona.IdPersona;
        }

        private PersonaFisica InserisciPersonaFisica(ref PersonaFisicaCollectionProvider pfprov)
        {
            PersonaFisica pf = new PersonaFisica();
            pf.CodiceFiscale = txtRLCFiscale.Text.ToUpper();
            ModificaPersonaFisica(ref pfprov, ref pf);
            return pf;
        }

        private void ModificaPersonaFisica(ref PersonaFisicaCollectionProvider pfprov, ref PersonaFisica pf)
        {
            string sesso = "M";
            if (int.Parse(txtRLCFiscale.Text.Substring(9, 2)) > 40)
                sesso = "F";

            pf.Nome = txtRLNome.Text.ToUpper();
            pf.Cognome = txtRLCognome.Text.ToUpper();
            pf.Sesso = sesso;
            pf.DataNascita = txtRLDataNascita.Text;
            Comuni c = new Comuni();
            c.Denominazione = txtRLComuneNascita.Text;
            pf.IdComuneNascita = TrovaComune("DENOMINAZIONE", null, null, txtRLComuneNascita.Text, null, null);
            pfprov.Save(pf);
        }

        private int AggiornaSedeImpresa(int id_impresa, string tipo_sede, DbProvider db)
        {
            IndirizzoCollectionProvider indirizzo_provider = new IndirizzoCollectionProvider(db);
            IntNT idindirizzo = AggiornaIndirizzo(tipo_sede, ref indirizzo_provider);
            IndirizzarioCollectionProvider indirizzario_provider = new IndirizzarioCollectionProvider(db);
            IndirizzarioCollection sedi = indirizzario_provider.Find(null, null, id_impresa, tipo_sede, null, null);
            Indirizzario sede;
            if (sedi.Count == 0)
            {
                sede = new Indirizzario();
                sede.IdImpresa = id_impresa;
                sede.IdIndirizzo = idindirizzo;
                sede.CodTipoSede = tipo_sede;
                sede.FlagAttivo = true;
                indirizzario_provider.Save(sede);
            }
            else
            {
                sede = sedi[0];
                if (sede.DataFineValidita != null || sede.IdIndirizzo != idindirizzo)
                {
                    //storicizzo il vecchio indirizzario 
                    sede.DataFineValidita = DateTime.Now;
                    sede.FlagAttivo = false;
                    indirizzario_provider.Save(sede);
                    // e ne creo uno nuovo 
                    sede.MarkAsNew();
                    sede.IdIndirizzo = idindirizzo;
                    sede.DataFineValidita = null;
                    sede.DataInizioValidita = DateTime.Now;
                    sede.FlagAttivo = true;
                    indirizzario_provider.Save(sede);
                }
            }
            return sede.IdIndirizzario;
        }

        private IntNT AggiornaIndirizzo(string tipo_sede, ref IndirizzoCollectionProvider indirizzo_provider)
        {
            SiarLibrary.Indirizzo indirizzo = new SiarLibrary.Indirizzo();
            switch (tipo_sede)
            {
                case "D":
                    #region domicilio 
                    if (string.IsNullOrEmpty(txtSLComune.Text))
                        throw new Exception("Comune del domicilio fiscale non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", null,
                        txtSLCap.Text, txtSLComune.Text, null, null);
                    indirizzo.Via = txtSLIndirizzo.Text;
                    #endregion
                    break;
                case "S":
                    #region sede legale 
                    if (string.IsNullOrEmpty(txtSLComune.Text))
                        throw new Exception("Comune della sede legale non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", null,
                        txtSLCap.Text, txtSLComune.Text, null, null);
                    indirizzo.Via = txtSLIndirizzo.Text;
                    #endregion
                    break;
                case "R":
                    #region residenza 
                    if (string.IsNullOrEmpty(txtRLComuneResidenza.Text))
                        throw new Exception("Comune di residenza non presente in anagrafe tributaria. Impossibile continuare.");
                    indirizzo.IdComune = TrovaComune("DENOMINAZIONE", null,
                        txtRLCapResidenza.Text, txtRLComuneResidenza.Text, null, null);
                    indirizzo.Via = txtRLIndirizzoResidenza.Text;
                    #endregion
                    break;
            }
            indirizzo = TrovaIndirizzo(indirizzo, indirizzo_provider);
            indirizzo_provider.Save(indirizzo);
            return indirizzo.IdIndirizzo;
        }

        private int TrovaComune(string tipo_ricerca, string sigla_provincia, string cap_comune, string denominazione_comune,
            string cod_provincia, string istat_comune)
        {
            ComuniCollectionProvider comuni_provider = new ComuniCollectionProvider();
            if (!string.IsNullOrEmpty(sigla_provincia) && sigla_provincia == "PS") sigla_provincia = "PU";
            ComuniCollection cc = comuni_provider.RicercaComune(tipo_ricerca, null, cap_comune, denominazione_comune,
                cod_provincia, istat_comune, null, null);
            if (cc.Count == 0) throw new Exception("Comune non trovato.");
            return cc[0].IdComune;
        }

        private SiarLibrary.Indirizzo TrovaIndirizzo(SiarLibrary.Indirizzo i, IndirizzoCollectionProvider indirizzo_provider)
        {
            IndirizzoCollection icoll = indirizzo_provider.Find(null, i.IdComune, i.Via);
            if (icoll.Count > 0) i = icoll[0];
            return i;
        }

        protected void btnScaricaAT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) throw new SiarException(TextErrorCodes.ModificaDisabilitata);
                SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();
                traduzione.ScaricaDatiAzienda(_impresa.Cuaa, null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                ((SiarLibrary.Web.Page)Page).ShowMessage("Aggiornamento dati anagrafici completato.");
                _impresa = new ImpresaCollectionProvider().GetById(_impresa.IdImpresa);
                _datiSalvati = true;
            }
            catch (Exception ex) { ((SiarLibrary.Web.Page)Page).ShowError(ex); }
        }
    }
}