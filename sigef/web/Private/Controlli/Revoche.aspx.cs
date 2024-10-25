using System;
using System.Linq;
using System.Web.UI.WebControls;
using SiarLibrary;
using SiarLibrary.Web;
using SiarBLL;

namespace web.Private.Controlli
{
    public partial class Revoche : RevochePage
    {
        bool primo_giro = true;
        bool cerca_progetto = false;
        decimal importo_recuperato = 0;
        AttiCollectionProvider atti_provider = new AttiCollectionProvider();
        Atti decreto_selezionato = null;
        Boolean Organismi_intermedi = false;

        protected override void OnPreRender(EventArgs e)
        {
            lstAttoDefinizione.DataBind();
            lstAttoRegistro.DataBind();

            caricaDivRevoca();

            if (Revoca != null)
            {
                caricaProgetto();
                caricaDatiRevoca();
            }
            else
            {
                divMostraPulsanteCreaRecupero.Visible = false;
                divMostraRecuperoAssociato.Visible = false;

                if (Progetto != null)
                {
                    caricaProgetto();
                }
                else
                    svuotaCampiRevoca();
            }
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void caricaProgetto()
        {
            divProgettoPresente.Style.Remove("display");
            ImpresaCollectionProvider impresaCollectionProvider = new ImpresaCollectionProvider();
            ProgettoNaturaSoggettoCollectionProvider progettoNaturaSoggettoCollectionProvider = new ProgettoNaturaSoggettoCollectionProvider();
            ProgettoNaturaSoggettoCollection progettoNaturaSoggettoCollection = new ProgettoNaturaSoggettoCollection();
            ImpresaCollection impresaCollection = new ImpresaCollection();
            ProgettoCollectionProvider progettoCollectionProvider = new ProgettoCollectionProvider();

            if (!cerca_progetto)
                if(Progetto==null)
                    Progetto = progettoCollectionProvider.GetById(Revoca.IdProgetto);
            
            progettoNaturaSoggettoCollection = progettoNaturaSoggettoCollectionProvider.Find(Progetto.IdProgetto, null, null);
            if (progettoNaturaSoggettoCollection.Count == 0)
                impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
            else
            {
                if (progettoNaturaSoggettoCollection[0].TipoNaturaSoggetto == "Singola")
                    impresaCollection.Add(impresaCollectionProvider.GetById(Progetto.IdImpresa));
                else
                {
                    ImpresaAggregazioneCollectionProvider impresaAggregazioneCollectionProvider = new ImpresaAggregazioneCollectionProvider();
                    ImpresaAggregazioneCollection impresaAggregazioneCollection = impresaAggregazioneCollectionProvider.Find(progettoNaturaSoggettoCollection[0].IdAggregazione, null, null, 1, null);
                    foreach (ImpresaAggregazione impresaAgg in impresaAggregazioneCollection)
                    {
                        impresaCollection.Add(impresaCollectionProvider.GetById(impresaAgg.IdImpresa));
                    }
                }
            }
            lstDestinatario.Items.Add(new ListItem("", ""));
            foreach(SiarLibrary.Impresa imp in impresaCollection)
            {
                lstDestinatario.Items.Add(new ListItem(imp.RagioneSociale, imp.IdImpresa));
            }

            txtIdProgetto.Text = Progetto.IdProgetto.ToString();

            if (cerca_progetto|| Revoca == null)
                lstDestinatario.SelectedValue = "";
            else
                lstDestinatario.SelectedValue = Revoca.IdImpresa;

            //calcolo contributo ammissibile progetto
            int? idVariante = null;
            VariantiCollection v_coll = new SiarBLL.VariantiCollectionProvider().Find(null, Progetto.IdProgetto, "VA");
            foreach(Varianti v in v_coll)
            {
                if (v.Approvata == true && v.SegnaturaApprovazione != null)
                    idVariante = v.IdVariante;
            }

            decimal contributo_totale_progetto = new SiarBLL.PianoInvestimentiCollectionProvider().CalcoloContributoInvestimentiProgetto(Progetto.IdProgetto,  true , idVariante);
            txtContributoAmm.Text = string.Format("{0:N2}", contributo_totale_progetto);

            txtStatoProgetto.Text = Progetto.Stato;

            //controllo RUP
            BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
            BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, 1, 1);
            if (bandoResponsabiliCollection.Count != 1)// && Operatore.Utente.Profilo != "Amministratore")//TODO
            {
                btnSalvaRevoca.Enabled = false;
                btnEliminaRevoca.Enabled = false;
            }

            string Str_Organismi_intermedi = "";
            Str_Organismi_intermedi = new BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Progetto.IdBando);
            if (Str_Organismi_intermedi == "True")
                Organismi_intermedi = true;
            if(Organismi_intermedi)
            {
                divAttoOrgInt.Visible = true;
                divAtto.Visible = false;
            }
            else
            {
                divAttoOrgInt.Visible = false;
                divAtto.Visible = true;
            }

        }

        private void caricaDivRevoca()
        {
            imgMostraRevoca.Attributes.Add("src", PATH_IMAGES + "ArrowUpSolid.png");
            //lstOrigine.Items.Add(new ListItem("", ""));
            //lstOrigine.Items.Add(new ListItem("Irregolarità", "Irregolarita"));
            //lstOrigine.Items.Add(new ListItem("Rinuncia", "Rinuncia"));
            //lstOrigine.Items.Add(new ListItem("Errore", "Errore"));
            //lstOrigine.Items.Add(new ListItem("Minor Rendicontazione", "Minor_Rendicontazione"));
            //lstOrigine.SelectedIndex = 0;

            lstRevocaTotale.Items.Add(new ListItem("NO", "NO"));
            lstRevocaTotale.Items.Add(new ListItem("SI", "SI"));
            lstRevocaTotale.SelectedIndex = 0;

            //lstRevocare.Items.Add(new ListItem("NO", "NO"));
            //lstRevocare.Items.Add(new ListItem("SI", "SI"));
            //lstRevocare.SelectedIndex = 0;
        }

        private void svuotaCampiRevoca()
        {
            txtIdRevoca.Text = "";
            txtIdProgetto.Text = "";
            lstDestinatario.SelectedValue = "";
            //lstOrigine.SelectedValue = "";
            txtAreaNote.Text = "";
            txtImporto.Text = "";
            txtAttoNumero.Text = "";
            txtAttoData.Text = "";
            txtAttoDataOrgInt.Text = "";
            txtAttoNumeroOrgInt.Text = "";
            txtDescrAttoOrgInt.Text = "";
            txtLinkEstOrgInt.Text = "";
            chkDaRecuperare.Checked = false;
            lstRevocaTotale.SelectedIndex = 0;
            lstRevocaTotale.Enabled = true;
            //lstRevocare.SelectedIndex = 0;
        }

        private void caricaDatiRevoca()
        {
            if (Revoca.IdProgetto != null)
                divProgettoPresente.Style.Remove("display");

            ProgettoCollectionProvider progettoCollectionProvider = new ProgettoCollectionProvider();
            //area Revoca
            txtIdRevoca.Text = Revoca.IdRevoca.ToString();
            //lstOrigine.SelectedValue = Revoca.Origine;
            txtAreaNote.Text = Revoca.Note;
            txtImporto.Text = Revoca.ImportoRevoca;

            if(Revoca.IdAtto != null)
            {
                Atti atto = new AttiCollectionProvider().GetById(Revoca.IdAtto);
                if (!Organismi_intermedi)
                {
                    txtAttoData.Text = atto.Data;
                    txtAttoNumero.Text = atto.Numero;
                    //lstAttoRegistro.SelectedValue = atto.Registro;
                    foreach (ListItem l in lstAttoRegistro.Items) if (l.Value.StartsWith(atto.Registro)) { l.Selected = true; break; }

                    lstAttoDefinizione.SelectedValue = atto.CodDefinizione;

                    btnVisualizzaDecreto.Disabled = false;
                    btnVisualizzaDecreto.Attributes.Add("onclick", "visualizzaAtto(" + atto.IdAtto + ");");

                }
                else
                {
                    txtAttoDataOrgInt.Text = atto.Data;
                    txtAttoNumeroOrgInt.Text = atto.Numero;
                    txtDescrAttoOrgInt.Text = atto.Descrizione;
                    txtLinkEstOrgInt.Text = atto.LinkEsterno;
                    btnVisualizzaDecretoOrgInt.Disabled = false;
                    btnVisualizzaDecretoOrgInt.Attributes.Add("onclick", "location.href='" + atto.LinkEsterno + "';");
                }
                
            }

            //txtNumeroAtto.Text = Revoca.NumeroAtto;
            //txtDataAtto.Text = Revoca.DataAtto;
            chkDaRecuperare.Checked = Revoca.RecuperoBeneficiario ?? false;
            //lstRevocare.SelectedIndex = Revoca.RevocaContributo ? 1 : 0;
            //area Beneficiario

            if (Progetto.CodStato == "Y")
            { 
                lstRevocaTotale.SelectedValue = "SI";
                lstRevocaTotale.Enabled = false;
            }

            if (Revoca.RecuperoBeneficiario != null && Revoca.RecuperoBeneficiario)
            {
                var recuperoProvider = new RecuperoBeneficiarioCollectionProvider();
                var recuperoCollection = recuperoProvider.Find(null, Revoca.IdProgetto, null, null, Revoca.IdRevoca, null);

                if (recuperoCollection.Count > 0)
                {
                    divMostraPulsanteCreaRecupero.Visible = false;

                    dgRecuperi.DataSource = recuperoCollection;
                    dgRecuperi.ItemDataBound += new DataGridItemEventHandler(dgRecuperi_ItemDataBound);
                    dgRecuperi.DataBind();
                }
                else
                {
                    divMostraRecuperoAssociato.Visible = false;
                }
            }
            else
            {
                divMostraPulsanteCreaRecupero.Visible = false;
                divMostraRecuperoAssociato.Visible = false;
            }
        }
        protected void btnSalvaRevoca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProgetto.Text) || string.IsNullOrEmpty(lstDestinatario.SelectedValue))
                {
                    ShowError("Per salvare è necessario inserire Progetto e Beneficiario");
                    Session["_revoca"] = null;
                    Session["_progetto"] = null;
                }
                else
                {
                    string Str_Organismi_intermedi = "";
                    Str_Organismi_intermedi = new BandoConfigCollectionProvider().GetBandoConfig_OrganismiIntermedi(Progetto.IdBando);
                    if (Str_Organismi_intermedi == "True")
                        Organismi_intermedi = true;
                    if (!Organismi_intermedi)
                    {
                        if (txtAttoData.Text == "" || txtAttoNumero.Text == "" || lstAttoRegistro.SelectedValue == "" || lstAttoDefinizione.SelectedValue == "" || txtAttoData.Text == null || txtAttoNumero.Text == null || lstAttoRegistro.SelectedValue == null || lstAttoDefinizione.SelectedValue == null)
                            throw new Exception("Per proseguire è necessario inserire il numero, data, registro e tipo dell atto o decreto.");

                        //Ricerco il decreto
                        int numero;
                        int.TryParse(txtAttoNumero.Text, out numero);
                        DateTime data;
                        DateTime.TryParse(txtAttoData.Text, out data);
                        string registro = lstAttoRegistro.SelectedValue;
                        if (!string.IsNullOrEmpty(lstAttoRegistro.SelectedValue) && lstAttoRegistro.SelectedValue.IndexOf("|") > 0)
                            registro = lstAttoRegistro.SelectedValue.Substring(0, lstAttoRegistro.SelectedValue.IndexOf("|"));
                        // controllo che l'atto sia registrato su db, altrimenti lo importo
                        AttiCollection atti_trovati = atti_provider.Find(numero, data, lstAttoDefinizione.SelectedValue, registro);
                        if (atti_trovati.Count == 0)
                        {
                            atti_trovati = atti_provider.ImportaAtto(numero, data, lstAttoDefinizione.SelectedValue, lstAttoRegistro.SelectedValue);
                            if (atti_trovati.Count > 0) atti_provider.Save(atti_trovati[0]);
                        }
                        if (atti_trovati.Count > 0)
                        {
                            decreto_selezionato = atti_trovati[0];
                        }
                        else throw new Exception("Non è stato trovato nessun decreto/atto con i parametri inseriti. Impossibile continuare.");
                    }
                    else
                    {
                        if (txtAttoDataOrgInt.Text == "" || txtAttoNumeroOrgInt.Text == "" || txtDescrAttoOrgInt.Text == "" || txtLinkEstOrgInt.Text == "" || txtAttoDataOrgInt.Text == null || txtAttoNumeroOrgInt.Text == null || txtDescrAttoOrgInt.Text == null || txtLinkEstOrgInt.Text == null)
                            throw new Exception("Per proseguire è necessario inserire il numero, data, descrizione e link esterno.");
                        decreto_selezionato = new Atti();
                        decreto_selezionato.CodTipo = "L";
                        decreto_selezionato.CodDefinizione = "D";
                        decreto_selezionato.CodOrganoIstituzionale = "OI";
                        decreto_selezionato.Numero = new SiarLibrary.NullTypes.IntNT(txtAttoNumeroOrgInt.Text);
                        decreto_selezionato.Data = txtAttoDataOrgInt.Text;
                        decreto_selezionato.Descrizione = txtDescrAttoOrgInt.Text;
                        decreto_selezionato.LinkEsterno = txtLinkEstOrgInt.Text;
                        atti_provider.Save(decreto_selezionato);
                    }
                    


                    BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
                    BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, 1, 1);
                    if (bandoResponsabiliCollection.Count != 1)
                    {
                        ShowError("Per salvare è necessario essere il responsabile del bando");
                        Session["_revoca"] = null;
                        Session["_progetto"] = null;
                    }
                    else
                    {

                        importo_recuperato = 0;
                        if (Revoca == null)
                            Revoca = new Revoca();
                        else
                        {
                            RevocaOrdinativoIncassoCollectionProvider revocaOrdinativoIncassoCollectionProvider = new RevocaOrdinativoIncassoCollectionProvider();
                            RevocaOrdinativoIncassoCollection revocaOrdinativoIncassoCollection = new RevocaOrdinativoIncassoCollection();
                            revocaOrdinativoIncassoCollection = revocaOrdinativoIncassoCollectionProvider.Select(null, Revoca.IdRevoca, null, null, null, null);
                            foreach (RevocaOrdinativoIncasso ord in revocaOrdinativoIncassoCollection)
                                importo_recuperato += ord.ImportoOrdinativo;
                        }

                        //controllo che non hanno cambiato l'id progetto senza premere il tasto cerca
                        ProgettoNaturaSoggettoCollection progettoNaturaSoggettoCollection = new ProgettoNaturaSoggettoCollection();
                        ProgettoNaturaSoggettoCollectionProvider progettoNaturaSoggettoCollectionProvider = new ProgettoNaturaSoggettoCollectionProvider();
                        ImpresaCollectionProvider impresaCollectionProvider = new ImpresaCollectionProvider();

                        ImpresaCollection impresaCollection = new ImpresaCollection();
                        ProgettoCollectionProvider progettoCollectionProvider = new ProgettoCollectionProvider();

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
                                ImpresaAggregazioneCollectionProvider impresaAggregazioneCollectionProvider = new ImpresaAggregazioneCollectionProvider();
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
                        RevocaCollectionProvider revocaCollectionProvider = new RevocaCollectionProvider();
                        if (impresa_trovata)
                        {
                            //area Revoca
                            Progetto = progettoCollectionProvider.GetById(int.Parse(txtIdProgetto.Text));
                            Revoca.IdProgetto = Progetto.IdProgetto;
                            Revoca.IdImpresa = int.Parse(lstDestinatario.SelectedValue);
                            //Revoca.Origine = lstOrigine.SelectedValue;
                            Revoca.Note = txtAreaNote.Text;
                            Revoca.ImportoRevoca = Convert.ToDecimal(txtImporto.Text);
                            Revoca.IdAtto = decreto_selezionato.IdAtto;
                            //Revoca.NumeroAtto = txtNumeroAtto.Text;
                            //Revoca.DataAtto = txtDataAtto.Text;
                            Revoca.RecuperoBeneficiario = chkDaRecuperare.Checked;
                            //Revoca.RevocaContributo = lstRevocare.SelectedValue == "SI" ? true : false;
                            revocaCollectionProvider.Save(Revoca);

                            //se selezionata revoca totale cambio stato al progetto
                            SiarBLL.ProgettoCollectionProvider prog_prov = new SiarBLL.ProgettoCollectionProvider();
                            if (Progetto.CodStato != "Y" && lstRevocaTotale.SelectedValue == "SI")
                            {
                                prog_prov.CambioStatoProgetto(Progetto, "Y", decreto_selezionato.IdAtto , Operatore);
                                Progetto = prog_prov.GetById(Progetto.IdProgetto);
                            }


                            //Salvo la decertificazione associata
                            CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
                            CertDecertificazione certDecertificazione = certDecertificazioneCollectionProvider.Find(null, null, null, Revoca.IdRevoca, tipoDecertificazione.Revoca.ToString(), null, null, null, null, null, null, null).ToArrayList<CertDecertificazione>().FirstOrDefault();
                            if (certDecertificazione == null)
                                certDecertificazione = new CertDecertificazione();
                            certDecertificazione.IdProgetto = Revoca.IdProgetto;
                            certDecertificazione.IdDecertificazione = Revoca.IdRevoca;
                            certDecertificazione.TipoDecertificazione = tipoDecertificazione.Revoca.ToString();
                            certDecertificazione.ImportoDecertificazioneAmmesso = Revoca.Totale;
                            certDecertificazione.ImportoDecertificazioneConcesso = Revoca.Totale;
                            certDecertificazione.DataConstatazioneAmministrativa = Revoca.DataAtto;
                            certDecertificazioneCollectionProvider.Save(certDecertificazione);

                            ShowMessage("Revoca salvata con successo");
                        }
                        else
                        {
                            ShowError("Per cambiare progetto è necessario premere il tasto cerca.");
                        }
                        importo_recuperato = 0;
                    }
                }
            }
            catch (Exception ex) { ShowError(ex); }


        }
        protected void btnEliminaRevoca_Click(object sender, EventArgs e)
        {
            BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
            BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, 1, 1);
            if (bandoResponsabiliCollection.Count != 1)
                ShowError("Per modificare la revoca occorre essere il responsabile del bando");
            else
            {
                if(Progetto.CodStato == "Y")
                    ShowError("Impossibile eliminare la revoca. Il progetto si trova nello stato 'Revocato'. Contattare l'helpdesk.");
                else
                {
                    RevocaCollectionProvider revocaCollectionProvider = new RevocaCollectionProvider();
                    if (Revoca != null)
                    {
                        RevocaOrdinativoIncassoCollectionProvider revocaOrdinativoIncassoCollectionProvider = new RevocaOrdinativoIncassoCollectionProvider();
                        RevocaOrdinativoIncassoCollection revocaOrdinativoIncassoCollection = new RevocaOrdinativoIncassoCollection();
                        revocaOrdinativoIncassoCollection = revocaOrdinativoIncassoCollectionProvider.Select(null, Revoca.IdRevoca, null, null, null, null);
                        foreach (RevocaOrdinativoIncasso ord in revocaOrdinativoIncassoCollection)
                            revocaOrdinativoIncassoCollectionProvider.Delete(ord);

                        //elimino la decertificazione associata
                        CertDecertificazioneCollectionProvider certDecertificazioneCollectionProvider = new CertDecertificazioneCollectionProvider();
                        var decert_col = certDecertificazioneCollectionProvider.Find(null, null, null, Revoca.IdRevoca, tipoDecertificazione.Revoca.ToString(), null, null, null, null, null, null, null);
                        if (decert_col.Count != 0)
                            certDecertificazioneCollectionProvider.Delete(decert_col[0]);

                        revocaCollectionProvider.Delete(Revoca);
                    }
                    Session["_revoca"] = null;
                    Session["_progetto"] = null;
                    ShowMessage("Revoca Eliminata con successo");
                }
            }
        }
        protected void btnCercaProgetto_Click(object sender, EventArgs e)
        {
            ProgettoCollectionProvider progettoCollectionProvider = new ProgettoCollectionProvider();
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
        }


        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            Session["_revoca"] = null;
            Session["_progetto"] = null;
            Redirect(PATH_CONTROLLI + "RicercaRevoche.aspx");
        }

        protected void btnVisualizzaRecupero_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperoBeneficiarioCollectionProvider recuperoProvider = new RecuperoBeneficiarioCollectionProvider();
                int idRecupero;
                if (int.TryParse(hdnIdRecupero.Value, out idRecupero))
                {
                    var recupero = recuperoProvider.GetById(idRecupero);
                    Session["_recuperoBeneficiario"] = recupero;

                    Redirect(PATH_CONTROLLI + "RecuperoBeneficiario.aspx");
                }
                else
                    throw new Exception("Nessun recupero selezionato.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void btnCreaRecuperoDaRevoca_Click(object sender, EventArgs e)
        {
            RecuperoBeneficiarioCollectionProvider recuperoProvider = new RecuperoBeneficiarioCollectionProvider();

            try
            {
                SiarLibrary.RecuperoBeneficiario recupero = new SiarLibrary.RecuperoBeneficiario();
                recupero.IdProgetto = Revoca.IdProgetto;
                recupero.IdRevoca = Revoca.IdRevoca;
                recupero.Definitivo = false;
                recupero.FlagImportoIrrecuperabile = false;

                recuperoProvider.DbProviderObj.Commit();
                Session["_recuperoBeneficiario"] = recupero;
                Redirect(PATH_CONTROLLI + "RecuperoBeneficiario.aspx", "Recupero associato alla revoca creato con successo, si prega di completare le informazioni del recupero", false);
            }
            catch (Exception ex)
            {
                recuperoProvider.DbProviderObj.Rollback();
                ShowError(ex.Message);
            }
        }

        void dgOrdinativi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {

                var ordinativo = (RevocaOrdinativoIncasso)e.Item.DataItem;
                dgi.Cells[0].Text = Revoca.NumeroAtto;
                dgi.Cells[1].Text = Revoca.DataAtto;
                dgi.Cells[2].Text = Revoca.ImportoRevoca + " €";
                dgi.Cells[5].Text += "€";

                if(ordinativo.ImportoOrdinativo!=null)
                    importo_recuperato += ordinativo.ImportoOrdinativo;

                if (primo_giro)
                {
                    RevocaOrdinativoIncassoCollectionProvider revocaOrdinativoIncassoCollectionProvider = new RevocaOrdinativoIncassoCollectionProvider();
                    RevocaOrdinativoIncassoCollection revocaOrdinativoIncassoCollection = new RevocaOrdinativoIncassoCollection();
                    revocaOrdinativoIncassoCollection = revocaOrdinativoIncassoCollectionProvider.Select(null, Revoca.IdRevoca, null, null, null, null);
                    dgi.Cells[0].RowSpan = revocaOrdinativoIncassoCollection.Count;
                    dgi.Cells[1].RowSpan = revocaOrdinativoIncassoCollection.Count;
                    dgi.Cells[2].RowSpan = revocaOrdinativoIncassoCollection.Count;
                    BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
                    BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, 1, 1);
                    if (bandoResponsabiliCollection.Count != 1)// && Operatore.Utente.Profilo != "Amministratore")//TODO
                        dgi.Cells[6].Text = dgi.Cells[6].Text.Replace("button", "button disabled = disabled");
                    primo_giro = false;
                }
                else
                {
                    dgi.Cells[0].Visible = false;
                    dgi.Cells[1].Visible = false;
                    dgi.Cells[2].Visible = false;
                    BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new BandoResponsabiliCollectionProvider();
                    BandoResponsabiliCollection bandoResponsabiliCollection = bandoResponsabiliCollectionProvider.Find(Progetto.IdBando, Operatore.Utente.IdUtente, null, 1, 1);
                    if (bandoResponsabiliCollection.Count != 1)// && Operatore.Utente.Profilo != "Amministratore")//TODO
                        dgi.Cells[6].Text = dgi.Cells[6].Text.Replace("button", "button disabled = disabled");
                }
            }
            else if (dgi.ItemType == ListItemType.Footer)
            {
                dgi.Cells[0].Text = "";
                dgi.Cells[4].Text = "";
                dgi.Cells[5].Text = "Importo Recuperato: " + importo_recuperato.ToString() + "€";
                dgi.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        void dgRecuperi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataGridItem dgi = (DataGridItem)e.Item;
            if (dgi.ItemType == ListItemType.Item || dgi.ItemType == ListItemType.AlternatingItem)
            {
                var recupero = (SiarLibrary.RecuperoBeneficiario)e.Item.DataItem;
                if (recupero.Definitivo != null)
                    if (recupero.Definitivo)
                        dgi.Cells[3].Text = dgi.Cells[3].Text.Replace("<input", "<input checked");
                    else
                        dgi.Cells[3].Text = dgi.Cells[3].Text.Replace("checked", "");
            }
        }
    }
}