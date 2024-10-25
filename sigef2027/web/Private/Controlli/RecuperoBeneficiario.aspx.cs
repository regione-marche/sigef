using System;
using System.Linq;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;
using System.Collections.Generic;

namespace web.Private.Controlli
{
    public partial class RecuperoBeneficiario : RecuperoBeneficiarioPage
    {
        ImpresaCollectionProvider impresaCollectionProvider;
        ProgettoNaturaSoggettoCollectionProvider progettoNaturaSoggettoCollectionProvider;
        ProgettoCollectionProvider progettoCollectionProvider;
        ImpresaAggregazioneCollectionProvider impresaAggregazioneCollectionProvider;
        RecuperoBeneficiarioOrdinativoIncassoCollectionProvider ordinativiProvider;
        RecuperoBeneficiarioCollectionProvider recuperoCollectionProvider;
        ArchivioFileCollectionProvider fileProvider;
        ProfiloXFunzioniCollectionProvider profiloXFunzioniCollectionProvider;
        BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider;
        CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider;
        IrregolaritaCollectionProvider irregolaritaProvider;
        ErroreCollectionProvider erroreProvider;
        RevocaCollectionProvider revocaProvider;
        AttiCollectionProvider attiProvider;
        Atti atto = null;

        bool cerca_progetto = false;
        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                InizializzaProvider();
                if(RecuperoBeneficiario==null)
                {
                    btnEliminaRecupero.Visible = false;
                    btnRendiDefinitivo.Visible = false;
                }
                caricaDivRecupero();
                ufOrdinativo.AbilitaModifica = true;
                var a = ufOrdinativo.IdFile;
                if (RecuperoBeneficiario != null)
                {
                    caricaProgetto();
                    caricaDatiRecupero();
                }
                else
                {
                    if (Progetto != null)
                    {
                        caricaProgetto();
                    }
                    else
                        svuotaCampiRevoca();
                }
                base.OnPreRender(e);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InizializzaProvider()
        {
            impresaCollectionProvider = new ImpresaCollectionProvider();
            progettoNaturaSoggettoCollectionProvider = new ProgettoNaturaSoggettoCollectionProvider();
            progettoCollectionProvider = new ProgettoCollectionProvider();
            impresaAggregazioneCollectionProvider = new ImpresaAggregazioneCollectionProvider();
            ordinativiProvider = new RecuperoBeneficiarioOrdinativoIncassoCollectionProvider();
            recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider();
            fileProvider = new ArchivioFileCollectionProvider();
            profiloXFunzioniCollectionProvider = new ProfiloXFunzioniCollectionProvider();
            bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
            certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
            attiProvider = new AttiCollectionProvider();
            irregolaritaProvider = new IrregolaritaCollectionProvider();
            erroreProvider = new ErroreCollectionProvider();
            revocaProvider = new RevocaCollectionProvider();
        }

        private void InizializzaProvider(DbProvider dbProviderObj)
        {
            impresaCollectionProvider = new ImpresaCollectionProvider(dbProviderObj);
            progettoNaturaSoggettoCollectionProvider = new ProgettoNaturaSoggettoCollectionProvider(dbProviderObj);
            progettoCollectionProvider = new ProgettoCollectionProvider(dbProviderObj);
            impresaAggregazioneCollectionProvider = new ImpresaAggregazioneCollectionProvider(dbProviderObj);
            ordinativiProvider = new RecuperoBeneficiarioOrdinativoIncassoCollectionProvider(dbProviderObj);
            recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider(dbProviderObj);
            fileProvider = new ArchivioFileCollectionProvider(dbProviderObj);
            profiloXFunzioniCollectionProvider = new ProfiloXFunzioniCollectionProvider(dbProviderObj);
            bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider(dbProviderObj);
            certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider(dbProviderObj);
            attiProvider = new AttiCollectionProvider(dbProviderObj);
            irregolaritaProvider = new IrregolaritaCollectionProvider(dbProviderObj);
            erroreProvider = new ErroreCollectionProvider(dbProviderObj);
            revocaProvider = new RevocaCollectionProvider(dbProviderObj);
        }

        private void caricaDivRecupero()
        {
            //imgSegnatura.Attributes.Add("src", PATH_IMAGES + "lente.png");
            //lstOrigine.Items.Add(new ListItem("", ""));
            //lstOrigine.Items.Add(new ListItem("Recupero", "Recupero"));
            //lstOrigine.Items.Add(new ListItem("Rinuncia", "Rinuncia"));
            //lstOrigine.Items.Add(new ListItem("Errore", "Errore"));
            //lstOrigine.Items.Add(new ListItem("Ritiro", "Ritiro"));
            //lstOrigine.SelectedIndex = 0;
            lstStato.Items.Add(new ListItem("", ""));
            lstStato.Items.Add(new ListItem("Avviato", "Avviato"));
            lstStato.Items.Add(new ListItem("Recuperato", "Recuperato"));
            lstStato.Items.Add(new ListItem("Irrecuperabile", "Irrecuperabile"));
            lstStato.SelectedIndex = 0;
            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();
        }

        private void caricaProgetto()
        {
            try
            {
                divProgettoPresente.Style.Remove("display");
                ProgettoNaturaSoggettoCollection progettoNaturaSoggettoCollection;
                ImpresaCollection impresaCollection = new ImpresaCollection();


                if (!cerca_progetto && RecuperoBeneficiario != null)
                    Progetto = progettoCollectionProvider.GetById(RecuperoBeneficiario.IdProgetto);
                if (Progetto != null)
                {
                    progettoNaturaSoggettoCollection = progettoNaturaSoggettoCollectionProvider.Find(Progetto.IdProgetto, null, null);
                    if (progettoNaturaSoggettoCollection.Count == 0)
                        impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
                    else
                    {
                        if (progettoNaturaSoggettoCollection[0].TipoNaturaSoggetto == "Singola")
                            impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
                        else
                        {
                            ImpresaAggregazioneCollection impresaAggregazioneCollection = impresaAggregazioneCollectionProvider.Find(progettoNaturaSoggettoCollection[0].IdAggregazione, null, null, 1, null);
                            foreach (ImpresaAggregazione impresaAgg in impresaAggregazioneCollection)
                            {
                                impresaCollection.Add(impresaCollectionProvider.GetById(impresaAgg.IdImpresa));
                            }
                        }

                    }

                    lstDestinatario.Items.Add(new ListItem("", ""));
                    foreach (SiarLibrary.Impresa imp in impresaCollection)
                    {
                        lstDestinatario.Items.Add(new ListItem(imp.RagioneSociale, imp.IdImpresa));
                    }

                    txtIdProgetto.Text = Progetto.IdProgetto.ToString();

                    if (cerca_progetto || RecuperoBeneficiario == null)
                        lstDestinatario.SelectedValue = "";
                    else
                        lstDestinatario.SelectedValue = RecuperoBeneficiario.IdImpresa;
                }
                //controllo RUP
                abilitatoModifica();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void caricaDatiRecupero()
        {
            try
            {
                divOrdinativi.Style.Remove("display");
                divAttiRecupero.Style.Remove("display");
                divOrigineRecupero.Style.Remove("display");
                if (RecuperoBeneficiario.IdProgetto != null)
                    divProgettoPresente.Style.Remove("display");
                lblOrdinativi.Visible = false;

                //area 
                txtIdRecupero.Text = RecuperoBeneficiario.IdRecuperoBeneficiario.ToString();
                lstStato.SelectedValue = RecuperoBeneficiario.Stato;
                txtDataInizioRateizzazione.Text = RecuperoBeneficiario.DataInizioRateizzazione;
                txtDataFineRateizzazione.Text = RecuperoBeneficiario.DataFineRateizzazione;
                //lstOrigine.SelectedValue = RecuperoBeneficiario.Origine;
                //txtNumeroAtto.Text = RecuperoBeneficiario.DecretoRecuperoNumero;
                //txtDataAtto.Text = RecuperoBeneficiario.DecretoRecuperoData;
                txtDataAvvioRecupero.Text = RecuperoBeneficiario.DataAvvioRecupero;
                //txtSegnatura.Text = RecuperoBeneficiario.SegnaturaPaleoComunicazioneBeneficiario;
                txtContributo.Text = RecuperoBeneficiario.Contributo;
                txtInteressi.Text = RecuperoBeneficiario.Interessi;
                txtSpese.Text = RecuperoBeneficiario.Spese;
                txtSanzioni.Text = RecuperoBeneficiario.Sanzioni;
                txtTotale.Text = RecuperoBeneficiario.TotaleDaRecuperare;
                txtAreaNote.Text = RecuperoBeneficiario.Note;
                txtImportoRecuperato.Text = RecuperoBeneficiario.ImportoRecuperato;
                txtImportoIrrecuperabile.Text = RecuperoBeneficiario.ImportoIrrecuperabile;
                //chkImportoIrrecuperabile.Checked = RecuperoBeneficiario.FlagImportoIrrecuperabile ?? false;
                //chkRecuperoCompleto.Checked = RecuperoBeneficiario.Definitivo ?? false;
                //Carico Ordinativi Salvati
                RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = new RecuperoBeneficiarioOrdinativoIncassoCollection();
                ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                dgOrdinativi.DataSource = ordinativiCollection;
                dgOrdinativi.ItemDataBound += new DataGridItemEventHandler(dgOrdinativi_ItemDataBound);
                dgOrdinativi.DataBind();

                // evento ricerca
                int id_decreto;
                if (atto == null && int.TryParse(hdnIdAtto.Value, out id_decreto))
                    atto = attiProvider.GetById(id_decreto);
                // bind dei campi
                if (atto != null)
                {
                    hdnIdAtto.Value = atto.IdAtto;

                    txtAttoData.Text = atto.Data;
                    txtAttoNumero.Text = atto.Numero;
                    txtAttoDescrizione.Text = atto.Descrizione;
                }

                AttiCollection attiCollection = new AttiCollection();
                if (RecuperoBeneficiario.IdAttoRecupero != null)
                    attiCollection.Add(attiProvider.GetById(RecuperoBeneficiario.IdAttoRecupero));
                if (RecuperoBeneficiario.IdAttoRateizzazione != null)
                    attiCollection.Add(attiProvider.GetById(RecuperoBeneficiario.IdAttoRateizzazione));
                if (attiCollection.Count > 0)
                {
                    dgAttiRecupero.DataSource = attiCollection;
                    dgAttiRecupero.ItemDataBound += new DataGridItemEventHandler(dgAttiRecupero_ItemDataBound);
                    dgAttiRecupero.DataBind();
                }

                //Gestisco le origini possibili
                List<OrigineRecuperoBeneficiario> origineList = new List<OrigineRecuperoBeneficiario>();

                var irregolaritaList = irregolaritaProvider
                    .GetIrregolaritaDaRecuperarePerProgetto(RecuperoBeneficiario.IdProgetto)
                    .ToArrayList<Irregolarita>();
                foreach (Irregolarita irr in irregolaritaList)
                {
                    var origine = new OrigineRecuperoBeneficiario();
                    origine.Id = irr.IdIrregolarita;
                    origine.Tipologia = "Irregolarità";
                    origine.IdETipologia = origine.Id + "|" + origine.Tipologia;
                    origine.Origine = irr.DescrizioneControlloOrigine;
                    origine.Importo = irr.ContributoPubblico;
                    origine.Selezionato = false;
                    if (RecuperoBeneficiario.IdIrregolarita != null && RecuperoBeneficiario.IdIrregolarita == irr.IdIrregolarita)
                        origine.Selezionato = true;
                    origineList.Add(origine);
                }

                var erroriList = erroreProvider
                    .GetErroriDaRecuperarePerProgetto(RecuperoBeneficiario.IdProgetto)
                    .ToArrayList<Errore>();
                foreach (Errore err in erroriList)
                {
                    var origine = new OrigineRecuperoBeneficiario();
                    origine.Id = err.IdErrore;
                    origine.Tipologia = "Errore";
                    origine.IdETipologia = origine.Id + "|" + origine.Tipologia;
                    origine.Origine = err.SoggettoRilevazione;
                    origine.Importo = err.ContributoPubblicoErrore;
                    origine.Selezionato = false;
                    if (RecuperoBeneficiario.IdErrore != null && RecuperoBeneficiario.IdErrore == err.IdErrore)
                        origine.Selezionato = true;
                    origineList.Add(origine);
                }

                var revocheList = revocaProvider
                    .GetRevocheDaRecuperarePerProgetto(RecuperoBeneficiario.IdProgetto)
                    .ToArrayList<Revoca>();
                foreach (Revoca rev in revocheList)
                {
                    var origine = new OrigineRecuperoBeneficiario();
                    origine.Id = rev.IdRevoca;
                    origine.Tipologia = "Revoca";
                    origine.IdETipologia = origine.Id + "|" + origine.Tipologia;
                    origine.Origine = rev.Origine;
                    origine.Importo = rev.ImportoRevoca;
                    origine.Selezionato = false;
                    if (RecuperoBeneficiario.IdRevoca != null && RecuperoBeneficiario.IdRevoca == rev.IdRevoca)
                        origine.Selezionato = true;
                    origineList.Add(origine);
                }

                dgOrigine.DataSource = origineList;
                dgOrigine.ItemDataBound += new DataGridItemEventHandler(dgOrigine_ItemDataBound);
                dgOrigine.DataBind();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void svuotaCampiRevoca()
        {
            txtIdProgetto.Text = "";
            txtIdRecupero.Text = "";
            //lstOrigine.SelectedValue = "";
            //txtNumeroAtto.Text = "";
            //txtDataAtto.Text = "";
            txtDataAvvioRecupero.Text = "";
            txtDataInizioRateizzazione.Text = "";
            txtDataFineRateizzazione.Text = "";
            //txtSegnatura.Text = "";
            txtContributo.Text = "";
            txtInteressi.Text = "";
            txtSpese.Text = "";
            txtSanzioni.Text = "";
            txtTotale.Text = "";
            txtAreaNote.Text = "";
            txtImportoRecuperato.Text = "";
            txtImportoIrrecuperabile.Text = "";
            txtAttoNumero.Text = "";
            txtAttoData.Text = "";
            //chkRecuperoCompleto.Checked = false;    
            //chkImportoIrrecuperabile.Checked = false;
        }

        protected void btnCercaProgetto_Click(object sender, EventArgs e)
        {
            try
            {
                progettoCollectionProvider = new ProgettoCollectionProvider();
                InizializzaProvider(progettoCollectionProvider.DbProviderObj);
                progettoCollectionProvider.DbProviderObj.BeginTran();
                
                cerca_progetto = true;
                int id_progetto;
                if (int.TryParse(txtIdProgetto.Text, out id_progetto))
                {
                    Progetto = progettoCollectionProvider.GetById(id_progetto);
                    if (Progetto == null)
                        ShowError("Progetto non trovato");
                }
                else
                    ShowError("Inserire un id progetto valido");
                progettoCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                progettoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnSalvaRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider();
                InizializzaProvider(recuperoCollectionProvider.DbProviderObj);
                recuperoCollectionProvider.DbProviderObj.BeginTran();

                if (string.IsNullOrEmpty(txtIdProgetto.Text) || string.IsNullOrEmpty(lstDestinatario.SelectedValue))
                {
                    ShowError("Per salvare è necessario inserire Progetto e Beneficiario");
                }
                else
                {
                    if (RecuperoBeneficiario == null)
                        RecuperoBeneficiario = new SiarLibrary.RecuperoBeneficiario();

                    if (!abilitatoModifica())
                    {
                        ShowError("Per salvare è necessario essere un responsabile di misura");
                    }
                    else
                    {
                        //controllo che non hanno cambiato l'id progetto senza premere il tasto cerca
                        ProgettoNaturaSoggettoCollection progettoNaturaSoggettoCollection;
                        ImpresaCollection impresaCollection = new ImpresaCollection();

                        Progetto = progettoCollectionProvider.GetById(txtIdProgetto.Text);

                        progettoNaturaSoggettoCollection = progettoNaturaSoggettoCollectionProvider.Find(Progetto.IdProgetto, null, null);
                        if (progettoNaturaSoggettoCollection.Count == 0)
                            impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
                        else
                        {
                            if (progettoNaturaSoggettoCollection[0].TipoNaturaSoggetto == "Singola")
                                impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
                            else
                            {
                                ImpresaAggregazioneCollection impresaAggregazioneCollection = impresaAggregazioneCollectionProvider.Find(progettoNaturaSoggettoCollection[0].IdAggregazione, null, null, 1, null);
                                foreach (ImpresaAggregazione impresaAgg in impresaAggregazioneCollection)
                                {
                                    impresaCollection.Add(impresaCollectionProvider.GetById(impresaAgg.IdImpresa));
                                }
                            }
                        }
                        bool impresa_trovata = false;
                        foreach (SiarLibrary.Impresa imp in impresaCollection)
                        {
                            if (imp.IdImpresa == int.Parse(lstDestinatario.SelectedValue))
                                impresa_trovata = true;
                        }

                        if (impresa_trovata)
                        {
                            Progetto = progettoCollectionProvider.GetById(int.Parse(txtIdProgetto.Text));
                            //area Recupero
                            RecuperoBeneficiario.IdProgetto = Progetto.IdProgetto;
                            RecuperoBeneficiario.IdImpresa = int.Parse(lstDestinatario.SelectedValue);
                            RecuperoBeneficiario.IdRecuperoBeneficiario = txtIdRecupero.Text;
                            RecuperoBeneficiario.Stato = lstStato.SelectedValue;
                            RecuperoBeneficiario.DataInizioRateizzazione = txtDataInizioRateizzazione.Text;
                            RecuperoBeneficiario.DataFineRateizzazione = txtDataFineRateizzazione.Text;
                            //RecuperoBeneficiario.Origine = lstOrigine.SelectedValue;
                            //RecuperoBeneficiario.DecretoRecuperoNumero = txtNumeroAtto.Text;
                            //RecuperoBeneficiario.DecretoRecuperoData = txtDataAtto.Text;
                            RecuperoBeneficiario.DataAvvioRecupero = txtDataAvvioRecupero.Text;
                            //RecuperoBeneficiario.SegnaturaPaleoComunicazioneBeneficiario = txtSegnatura.Text;
                            RecuperoBeneficiario.Contributo = txtContributo.Text;
                            RecuperoBeneficiario.Interessi = txtInteressi.Text;
                            RecuperoBeneficiario.Spese = txtSpese.Text;
                            RecuperoBeneficiario.Sanzioni = txtSanzioni.Text;
                            RecuperoBeneficiario.TotaleDaRecuperare = txtTotale.Text;
                            RecuperoBeneficiario.Note = txtAreaNote.Text;
                            //RecuperoBeneficiario.FlagImportoIrrecuperabile = chkImportoIrrecuperabile.Checked;
                            //RecuperoBeneficiario.Definitivo = chkRecuperoCompleto.Checked;

                            decimal importoRecuperato = 0;
                            decimal importoIrrecuperabile = 0;
                            var totaleDaRecuperare = decimal.Parse(txtTotale.Text);
                            if (RecuperoBeneficiario.IdRecuperoBeneficiario != null)
                            {
                                RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                                foreach (RecuperoBeneficiarioOrdinativoIncasso ord in ordinativiCollection)
                                {
                                    importoRecuperato += ord.Quietanza;
                                }

                                importoIrrecuperabile = totaleDaRecuperare - importoRecuperato;
                            }
                            RecuperoBeneficiario.ImportoRecuperato = importoRecuperato;
                            RecuperoBeneficiario.ImportoIrrecuperabile = importoIrrecuperabile;

                            recuperoCollectionProvider.Save(RecuperoBeneficiario);

                            //Salvo la decertificazione associata
                            CertDecertificazione certDecertificazione = certDecertificazioneCollectionProvider.Find(null, null, null, RecuperoBeneficiario.IdRecuperoBeneficiario, tipoDecertificazione.RecuperoBeneficiario.ToString(), null, null, null, null, null, null, null).ToArrayList<CertDecertificazione>().FirstOrDefault();
                            if (certDecertificazione == null)
                                certDecertificazione = new CertDecertificazione();
                            certDecertificazione.IdProgetto = RecuperoBeneficiario.IdProgetto;
                            certDecertificazione.IdDecertificazione = RecuperoBeneficiario.IdRecuperoBeneficiario;
                            certDecertificazione.TipoDecertificazione = tipoDecertificazione.RecuperoBeneficiario.ToString();
                            certDecertificazione.ImportoDecertificazioneAmmesso = RecuperoBeneficiario.TotaleDaRecuperare;
                            certDecertificazione.ImportoDecertificazioneConcesso = RecuperoBeneficiario.TotaleDaRecuperare;
                            certDecertificazione.DataConstatazioneAmministrativa = RecuperoBeneficiario.DecretoRecuperoData;
                            certDecertificazioneCollectionProvider.Save(certDecertificazione);
                           
                            ShowMessage("Recupero salvato con successo");
                            recuperoCollectionProvider.DbProviderObj.Commit();
                        }
                        else
                        {
                            ShowError("Per cambiare progetto è necessario premere il tasto cerca.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                recuperoCollectionProvider.DbProviderObj.Rollback();
            }
        }

        protected void btnEliminaRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider();
                InizializzaProvider(recuperoCollectionProvider.DbProviderObj);
                recuperoCollectionProvider.DbProviderObj.BeginTran();

                if (!abilitatoModifica())
                    ShowError("Per modificare il recupero occorre essere un responsabile di misura");
                else
                {
                    if (RecuperoBeneficiario != null)
                    {
                        RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                        foreach (RecuperoBeneficiarioOrdinativoIncasso ord in ordinativiCollection)
                        {
                            ordinativiProvider.Delete(ord);

                        }
                    }

                    //elimino la decertificazione associata
                    var decert_col = certDecertificazioneCollectionProvider.Find(null, null, null, RecuperoBeneficiario.IdRecuperoBeneficiario, tipoDecertificazione.RecuperoBeneficiario.ToString(), null, null, null, null, null, null, null);
                    if (decert_col.Count != 0)
                        certDecertificazioneCollectionProvider.Delete(decert_col[0]);

                    recuperoCollectionProvider.Delete(RecuperoBeneficiario);
                    recuperoCollectionProvider.DbProviderObj.Commit();
                    Session["_recuperoBeneficiario"] = null;
                    Session["_progetto"] = null;
                    ShowMessage("Recupero Eliminato con successo");
                }
            }
            catch (Exception ex)
            {
                recuperoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            Session["_recuperoBeneficiario"] = null;
            Session["_progetto"] = null;
            Redirect(PATH_CONTROLLI + "RicercaRecuperoBeneficiario.aspx");
        }

        protected void btnSalvaOrdinativo_Click(object sender, EventArgs e)
        {
            InizializzaProvider();
            try
            {
                ordinativiProvider = new RecuperoBeneficiarioOrdinativoIncassoCollectionProvider();
                InizializzaProvider(ordinativiProvider.DbProviderObj);
                ordinativiProvider.DbProviderObj.BeginTran();

                if (!abilitatoModifica())
                    ShowError("Per modificare il recupero occorre essere un responsabile di misura");
                else if (ufOrdinativo.IdFile == null)
                    ShowError("Per inserire il documento è necessario premere su Carica.");
                else if (string.IsNullOrEmpty(txtNumeroOrdinativo.Text) || string.IsNullOrEmpty(txtDataOrdinativo.Text) || string.IsNullOrEmpty(txtImportoOrdinativo.Text) || string.IsNullOrEmpty(txtQuietanzaOrdinativo.Text))
                    ShowError("Per inserire un ordinativo è necessario riempire tutti i campi.");
                else
                {
                    RecuperoBeneficiarioOrdinativoIncasso ordinativo = new RecuperoBeneficiarioOrdinativoIncasso
                    {
                        IdRecuperoBeneficiario = RecuperoBeneficiario.IdRecuperoBeneficiario,
                        IdFileMandato = ufOrdinativo.IdFile,
                        Numero = txtNumeroOrdinativo.Text,
                        Data = txtDataOrdinativo.Text,
                        Importo = txtImportoOrdinativo.Text,
                        Quietanza = txtQuietanzaOrdinativo.Text
                    };

                    ordinativiProvider.Save(ordinativo);
                    ordinativiProvider.DbProviderObj.Commit();
                    ufOrdinativo.IdFile = null;
                    txtNumeroOrdinativo.Text = "";
                    txtDataOrdinativo.Text = "";
                    txtImportoOrdinativo.Text = "";
                    txtQuietanzaOrdinativo.Text = "";
                    //ricalcolo gli importi recuperati e irrecuperabili
                    if (RecuperoBeneficiario != null)
                    {
                        var totaleDaRecuperare = RecuperoBeneficiario.TotaleDaRecuperare;
                        decimal importoRecuperato = 0;
                        decimal importoIrrecuperabile;

                        recuperoCollectionProvider.DbProviderObj.BeginTran();
                        RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                        foreach (RecuperoBeneficiarioOrdinativoIncasso ord in ordinativiCollection)
                        {
                            importoRecuperato += ord.Quietanza;
                        }

                        importoIrrecuperabile = totaleDaRecuperare - importoRecuperato;
                        RecuperoBeneficiario.ImportoRecuperato = importoRecuperato;
                        RecuperoBeneficiario.ImportoIrrecuperabile = importoIrrecuperabile;
                    }
                    recuperoCollectionProvider.Save(RecuperoBeneficiario);
                    recuperoCollectionProvider.DbProviderObj.Commit();
                    ShowMessage("Ordinativo salvato con successo");
                }
                ufOrdinativo.IdFile = null;
            }
            catch (Exception ex)
            {
                ordinativiProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        void dgOrdinativi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {

                var ordinativo = (RecuperoBeneficiarioOrdinativoIncasso)e.Item.DataItem;
                dgi.Cells[2].Text += "€";
                dgi.Cells[3].Text += "€";
                    if (!abilitatoModifica())
                        dgi.Cells[5].Text = dgi.Cells[5].Text.Replace("button", "button disabled = disabled");
                    //else
                    //    dgi.Cells[5].Text = dgi.Cells[5].Text.Replace("button", "button OnClientClick = \"if(!confermaEliminaOrdinativo()) return false;\"");

            }
            //else if (dgi.ItemType == ListItemType.Footer)
            //{
            //    dgi.Cells[0].Text = "";
            //    dgi.Cells[4].Text = "";
            //    dgi.Cells[5].Text = "Importo Recuperato: " + importo_recuperato.ToString() + "€";
            //    dgi.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //}
        }

        void dgAttiRecupero_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var atto = (Atti)e.Item.DataItem;

                var dec = atto.Numero.ToString() + '|' + atto.Data + '|' + atto.Registro;
                e.Item.Cells[0].Text = "<a href=\"javascript:visualizzaAtto(" + atto.IdAtto + ");\">" + dec + "</a>";

                if (RecuperoBeneficiario.IdAttoRecupero == atto.IdAtto
                    && RecuperoBeneficiario.IdAttoRateizzazione == atto.IdAtto)
                    dgi.Cells[2].Text = "Atto recupero e rateizzazione";
                else if (RecuperoBeneficiario.IdAttoRecupero == atto.IdAtto)
                    dgi.Cells[2].Text = "Atto recupero";
                else if (RecuperoBeneficiario.IdAttoRateizzazione == atto.IdAtto)
                    dgi.Cells[2].Text = "Atto rateizzazione";
                else
                    dgi.Cells[2].Text = "";
            }
        }

        void dgOrigine_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var origine = (OrigineRecuperoBeneficiario)e.Item.DataItem;

                if (origine.Importo != null)
                    dgi.Cells[3].Text = string.Format("{0:c}", origine.Importo);

                if (origine.Selezionato)
                    dgi.Cells[4].Text = "Selezionato";
            }
        }

        protected void btnEliminaOrdinativo_Click(object sender, EventArgs e)
        {
            try
            {
                ordinativiProvider = new RecuperoBeneficiarioOrdinativoIncassoCollectionProvider();
                InizializzaProvider(ordinativiProvider.DbProviderObj);
                ordinativiProvider.DbProviderObj.BeginTran();

                if (!abilitatoModifica())
                    ShowError("Per modificare il recupero occorre essere un responsabile di misura");
                else
                {
                    if (string.IsNullOrEmpty(hdnIdOrdinativo.Value))
                        ShowError("Selezionare un ordinativo da salvare");
                    RecuperoBeneficiarioOrdinativoIncasso ordinativo = ordinativiProvider.GetById(int.Parse(hdnIdOrdinativo.Value));

                    ordinativiProvider.Delete(ordinativo);
                    ordinativiProvider.DbProviderObj.Commit();
                    
                    ShowMessage("Ordinativo eliminato con successo");
                }
                
                //Aggiorno i valori Recuperato e Irrecuperabile
                if (RecuperoBeneficiario != null)
                {
                    var totaleDaRecuperare = RecuperoBeneficiario.TotaleDaRecuperare;
                    decimal importoRecuperato = 0;
                    decimal importoIrrecuperabile;

                    recuperoCollectionProvider.DbProviderObj.BeginTran();
                    RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                    foreach (RecuperoBeneficiarioOrdinativoIncasso ord in ordinativiCollection)
                    {
                        importoRecuperato += ord.Quietanza;
                    }

                    importoIrrecuperabile = totaleDaRecuperare - importoRecuperato;
                    RecuperoBeneficiario.ImportoRecuperato = importoRecuperato;
                    RecuperoBeneficiario.ImportoIrrecuperabile = importoIrrecuperabile;
                }
                recuperoCollectionProvider.Save(RecuperoBeneficiario);
                recuperoCollectionProvider.DbProviderObj.Commit();
            }
            catch (Exception ex)
            {
                ordinativiProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnDisassociaAtto_Click(object sender, EventArgs e)
        {
            try
            {
                ordinativiProvider = new RecuperoBeneficiarioOrdinativoIncassoCollectionProvider();
                InizializzaProvider(ordinativiProvider.DbProviderObj);
                ordinativiProvider.DbProviderObj.BeginTran();

                if (!abilitatoModifica())
                    ShowError("Per modificare il recupero occorre essere un responsabile di misura");
                else
                {
                    if (string.IsNullOrEmpty(hdnIdAttoDisassocia.Value))
                        ShowError("Selezionare un atto da disassociare");
                    var idAtto = int.Parse(hdnIdAttoDisassocia.Value);

                    if (RecuperoBeneficiario.IdAttoRecupero == idAtto)
                        RecuperoBeneficiario.IdAttoRecupero = null;
                    if (RecuperoBeneficiario.IdAttoRateizzazione == idAtto)
                        RecuperoBeneficiario.IdAttoRateizzazione = null;
                }

                recuperoCollectionProvider.Save(RecuperoBeneficiario);
                recuperoCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Atto disassociato con successo");
            }
            catch (Exception ex)
            {
                ordinativiProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        protected void btnRendiDefinitivo_Click(object sender, EventArgs e)
        {
            try
            {
                recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider();
                InizializzaProvider(recuperoCollectionProvider.DbProviderObj);
                recuperoCollectionProvider.DbProviderObj.BeginTran();

                if (!abilitatoModifica())
                    ShowError("Per modificare il recupero occorre essere un responsabile di misura");
                else
                {
                    if (RecuperoBeneficiario != null)
                    {
                        var totaleDaRecuperare = RecuperoBeneficiario.TotaleDaRecuperare;
                        decimal importoRecuperato = 0;
                        decimal importoIrrecuperabile;
                        RecuperoBeneficiarioOrdinativoIncassoCollection ordinativiCollection = ordinativiProvider.Select(null, RecuperoBeneficiario.IdRecuperoBeneficiario, null, null, null, null, null);
                        foreach (RecuperoBeneficiarioOrdinativoIncasso ord in ordinativiCollection)
                        {
                            importoRecuperato += ord.Quietanza;
                        }

                        importoIrrecuperabile = totaleDaRecuperare - importoRecuperato;
                        RecuperoBeneficiario.Definitivo = 1;
                        RecuperoBeneficiario.ImportoRecuperato = importoRecuperato;
                        RecuperoBeneficiario.ImportoIrrecuperabile = importoIrrecuperabile;
                    }
                    recuperoCollectionProvider.Save(RecuperoBeneficiario);
                    recuperoCollectionProvider.DbProviderObj.Commit();
                }
            }
            catch (Exception ex)
            {
                recuperoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        private bool abilitatoModifica()
        {
            try
            {
                bool abilitato = false;
                var funzioni_profilo_coll = profiloXFunzioniCollectionProvider.Find(Operatore.Utente.IdProfilo, null, null, "RecuperoBeneficiario", null, null, null, null);

                if (Operatore.Utente.Profilo == "Amministratore")
                    abilitato = true;
                else if (Operatore.Utente.Profilo == "Responsabile di misura")
                {
                    // come da richiesta su pass Supporto #205182 è sufficiente essere un rup
                    //BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, null, 1);
                    //if (bandoResponsabiliCollection.Count > 0)
                        abilitato = true;
                }
                else if (funzioni_profilo_coll.Count > 0)
                {
                    var funzione = funzioni_profilo_coll[0];
                    if (!(funzione.Modifica == null || funzione.Modifica == false))
                    {
                        abilitato = true;
                    }
                }
                //if (RecuperoBeneficiario != null)
                //    if (RecuperoBeneficiario.Definitivo == true)
                //        abilitato = false;
                if(!abilitato)
                {
                    btnSalvaOrdinativo.Enabled = false;
                    btnSalvaRecupero.Enabled = false;
                    btnEliminaOrdinativo.Enabled = false;
                    btnEliminaRecupero.Enabled = false;
                    btnRendiDefinitivo.Enabled = false;
                    btnCercaProgetto.Enabled = false;
                    ufOrdinativo.AbilitaModifica = false;
                    btnCercaDecreto.Enabled = false;
                    btnAssociaAttoRateizzazione.Enabled = false;
                    btnAssociaAttoRecupero.Enabled = false;
                }
                return abilitato;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return false;
            }
        }

        protected void btnCercaDecreto_Click(object sender, EventArgs e)
        {
            try
            {
                int numero;
                int.TryParse(txtAttoNumero.Text, out numero);
                DateTime data;
                DateTime.TryParse(txtAttoData.Text, out data);
                string registro = lstAttoRegistro.SelectedValue;
                if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                    registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));

                InizializzaProvider();

                // controllo che l'atto sia registrato su db, altrimenti lo importo
                var atti_trovati = attiProvider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                if (atti_trovati.Count == 0)
                {
                    atti_trovati = attiProvider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                    if (atti_trovati.Count > 0) 
                        attiProvider.Save(atti_trovati[0]);
                }

                if (atti_trovati.Count > 0)
                {
                    atto = atti_trovati[0];
                    hdnIdAtto.Value = null;
                }
                else 
                    ShowError("La ricerca non ha prodotto nessun risultato.");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        protected void btnAssociaAttoRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica) 
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                progettoCollectionProvider = new ProgettoCollectionProvider();
                InizializzaProvider(progettoCollectionProvider.DbProviderObj);
                progettoCollectionProvider.DbProviderObj.BeginTran();

                int id_decreto;
                if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                    atto = attiProvider.GetById(id_decreto);
                if (atto == null) 
                    throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");

                if (RecuperoBeneficiario != null)
                {
                    RecuperoBeneficiario.IdAttoRecupero = atto.IdAtto;
                    recuperoCollectionProvider.Save(RecuperoBeneficiario);
                }
                
                progettoCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Atto del recupero associato correttamente");
            }
            catch (Exception ex) 
            {
                progettoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
            finally
            {
                hdnIdAtto.Value = null;
            }
        }

        protected void btnAssociaAttoRateizzazione_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                progettoCollectionProvider = new ProgettoCollectionProvider();
                InizializzaProvider(progettoCollectionProvider.DbProviderObj);
                progettoCollectionProvider.DbProviderObj.BeginTran();

                int id_decreto;
                if (int.TryParse(hdnIdAtto.Value, out id_decreto))
                    atto = attiProvider.GetById(id_decreto);
                if (atto == null)
                    throw new Exception("Per proseguire è necessario specificare l'atto di riferimento.");

                if (RecuperoBeneficiario != null)
                {
                    RecuperoBeneficiario.IdAttoRateizzazione = atto.IdAtto;
                    recuperoCollectionProvider.Save(RecuperoBeneficiario);
                }

                progettoCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Atto della rateizzazzione associato correttamente");
            }
            catch (Exception ex)
            {
                progettoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
            finally
            {
                hdnIdAtto.Value = null;
            }
        }

        protected void btnAssociaOrigine_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AbilitaModifica)
                    throw new SiarException(TextErrorCodes.ModificaDisabilitata);

                recuperoCollectionProvider = new RecuperoBeneficiarioCollectionProvider();
                recuperoCollectionProvider.DbProviderObj.BeginTran();                
                string origine = hdnOrigine.Value.ToString();

                if (RecuperoBeneficiario != null)
                {
                    RecuperoBeneficiario.IdErrore = null;
                    RecuperoBeneficiario.IdIrregolarita = null;
                    RecuperoBeneficiario.IdRevoca = null;

                    var origineSplit = origine.Split('|');
                    int id = int.Parse(origineSplit[0]);
                    string tipologia = origineSplit[1];

                    switch (tipologia)
                    {
                        case "Irregolarità":
                            RecuperoBeneficiario.IdIrregolarita = id;
                            break;
                        case "Errore":
                            RecuperoBeneficiario.IdErrore = id;
                            break;
                        case "Revoca":
                            RecuperoBeneficiario.IdRevoca = id;
                            break;
                        default:
                            throw new Exception("Tipologia " + tipologia + " non gestita, verificare con l'helpdesk");
                    }
                    recuperoCollectionProvider.Save(RecuperoBeneficiario);
                }

                recuperoCollectionProvider.DbProviderObj.Commit();
                ShowMessage("Origine del recupero associata correttamente");
            }
            catch (Exception ex)
            {
                recuperoCollectionProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
            finally
            {
                hdnOrigine.Value = null;
            }
        }
    }
}