using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class Autocertificazione : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarLibrary.Impresa impresa_selezionata = null;
        SiarBLL.ProgettoCollectionProvider progetto_provider = new SiarBLL.ProgettoCollectionProvider();
        SiarLibrary.Progetto progetto_selezionato = null;
        SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
        SiarLibrary.Bando bando_selezionato = null;


        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_prov = new SiarBLL.CovidAutodichiarazioneCollectionProvider();
        SiarBLL.CovidAutodichiarazioneRequisitiCollectionProvider covid_req_prov = new SiarBLL.CovidAutodichiarazioneRequisitiCollectionProvider();
        SiarLibrary.CovidAutodichiarazione autocertificazione_selezionata = null;
        bool NoLocalizzazione = false;

        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "autocertificazione_covid";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_bando_covid"] != null)
            {
                //int id_bando = Convert.ToInt32()
                bando_selezionato = bando_provider.GetById(Convert.ToInt32((string)Session["id_bando_covid"]));
                NoLocalizzazione = bando_provider.HasCovidNoLocalizazione(bando_selezionato.IdBando);
                if (NoLocalizzazione)
                    hdnNoLocal.Value = "1";
                else
                    hdnNoLocal.Value = "0";
            }

            else
                //pagina elenco bandi
                Redirect("BandiCovidPreDomanda.aspx", "Nessun bando selezionato!", true);
            if (Session["id_progetto_covid"] != null)
            {
                progetto_selezionato = progetto_provider.GetById(Convert.ToInt32((string)Session["id_progetto_covid"]));
                SiarLibrary.CovidAutodichiarazioneCollection auto_coll = covid_prov.Find(null, progetto_selezionato.IdProgetto, progetto_selezionato.IdBando,
                    progetto_selezionato.IdImpresa, null, null, null);
                autocertificazione_selezionata = auto_coll[0];
                impresa_selezionata = impresa_provider.GetById(progetto_selezionato.IdImpresa);
            }

            txtCuaaRicerca.AddJSAttribute("onblur", "ctrlCuaaDitta();");
            ((SiarLibrary.Web.PrivatePage)Page).RegisterClientScriptBlock(@"
                $('ctl00_cphContenuto_cmbComune_text').impostaAutoComplete('getComuniMarche', 0, 3, 22, [['" + IdComuneHide.ClientID + @"', 'codice'], ['" + txtProv.ClientID + @"', 'prov'], ['" + txtCAP.ClientID + @"', 'cap']], 'Comuni');
            ");

        }

        protected override void OnPreRender(EventArgs e)
        {

            //lstFormaGiuridica.DataBind();
            lstDimensione.DataBind();
            btnSalva.Enabled = AbilitaModifica;
            btnElimina.Enabled = AbilitaModifica;

            lstComboAteco.IdBando = bando_selezionato.IdBando;
            if(NoLocalizzazione)
            {
                trLocalTitolo.Visible = false;
                trLocal.Visible = false;
            }



            if (autocertificazione_selezionata != null)
            {
                PulisciCampi();
                divCampi.Visible = true;
                divBoxRicerca.Visible = false;
                PopolaCampi(autocertificazione_selezionata);
                if (autocertificazione_selezionata.Definitiva != null && autocertificazione_selezionata.Definitiva)
                {
                    btnSalva.Enabled = false;
                    btnElimina.Enabled = false;
                }

                if (Operatore.Utente.CodEnte == "%")
                {
                    divButtonAmm.Visible = true;
                    btnSalva.Enabled = false;
                    btnElimina.Enabled = false;
                }

            }
            lstFormaGiuridica.DataBind();
            lstComboAteco.DataBind();


            base.OnPreRender(e);
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            try
            {
                PulisciCampi();
                string CF_RUP = "";
                SiarBLL.BandoResponsabiliCollectionProvider bandoResponsabiliCollectionProvider = new SiarBLL.BandoResponsabiliCollectionProvider();
                SiarLibrary.BandoResponsabiliCollection responsabili = bandoResponsabiliCollectionProvider.Find(bando_selezionato.IdBando, null, null, true, true);
                foreach (SiarLibrary.BandoResponsabili r in responsabili)
                {
                    if (r.Provincia == null)
                    {
                        SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(r.IdUtente);
                        CF_RUP = u.CfUtente;
                    }
                }

                SiarLibrary.ImpresaCollection imp_coll = impresa_provider.RicercaImpresa(Operatore.Utente.IdUtente, null, txtCuaaRicerca.Text, null, null);
                if (imp_coll.Count == 0)
                {
                    //scarico dati anagrafici da anagrafe tributaria
                    if (string.IsNullOrEmpty(txtCuaaRicerca.Text)) ShowError("Inserire una Partita iva/Codice fiscale valida per la ricerca.");
                    else
                    {
                        string cuaa_selezionato = txtCuaaRicerca.Text;

                        // : modificato per far operare i consulenti ed i rappresentanti legali non abilitati ad anagrafe tributaria
                        // a) possono fare solo il primo scaricamento, nel caso in cui l'impresa non sia già nel DB
                        // se: 
                        //    utente cerca in anagrafe tributaria per una sepcifica P.IVA
                        //    utente corrente è un consulente oppure utente singolo
                        //    SE ho impresa nel DB locale --> non faccio nulla
                        //    ELSE -->  scarica dati usando CF impostato nel web.config con parametro ScaricaImpresa_CFOperatore
                        //string CFScaricaDatiAnagrafe = ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente;
                        //string[] profiliPrimaVolta = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_ProfiliPrimavolta"].Split(new char[] { ',' });
                        //if (!string.IsNullOrEmpty(cuaa_selezionato) && Array.IndexOf(profiliPrimaVolta, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.IdProfilo.ToString()) >= 0)
                        //{
                        //    // devo poter scaricare imprese la prima volta
                        //    SiarLibrary.Impresa impresaPerPIVA = impresa_provider.GetByCuaa(cuaa_selezionato);
                        //    // se non ho impresa in DB --> la scarico, ovvero uso CF che può leggere tutte le imprese
                        //    if (impresaPerPIVA == null)
                        //        CFScaricaDatiAnagrafe = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                        //    else
                        //    {
                        //        ShowError("Ricerca in anagrafe tributaria non eseguita: impresa già presente nel DB locale.");
                        //        CFScaricaDatiAnagrafe = "";
                        //    }
                        //}
                        // : fine parte aggiunta 
                        string CFScaricaDatiAnagrafe = CF_RUP;
                        SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();
                        try
                        {
                            // : aggiunto if
                            if (!string.IsNullOrEmpty(CFScaricaDatiAnagrafe))
                            {
                                // : sostituita la riga
                                //traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, ((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.CfUtente);
                                traduzione.ScaricaDatiAzienda(cuaa_selezionato, null, CFScaricaDatiAnagrafe);
                                SiarLibrary.ImpresaCollection imprese = impresa_provider.RicercaImpresa(((SiarLibrary.Web.MasterPage)Page.Master).Operatore.Utente.IdUtente, null, cuaa_selezionato, null, null);
                                if (imprese.Count == 0)
                                {
                                    // qui prima faccio vedere e accettare la dichiarazione inizialmente invisibile. Se accette e clicca il bottone faccio la find
                                    divOperatoreNonAutorizzato.Visible = true;
                                    hdnEvilUser.Value = Operatore.Utente.IdUtente;
                                    //ShowError("L`operatore non è abilitato a lavorare per l`impresa selezionata. Controllare di aver inserito il CF corretto.");
                                    //impresa_selezionata = null;
                                }
                                else
                                {
                                    divOperatoreNonAutorizzato.Visible = false;
                                    hdnEvilUser.Value = string.Empty;
                                    impresa_selezionata = imprese[0];
                                    ShowMessage("Dati anagrafici scaricati correttamente.");
                                }
                            }
                        }
                        catch (Exception ex) { ShowError(ex); }
                    }
                }
                else
                {
                    impresa_selezionata = imp_coll[0];
                    //aggiorno i dati dall'anagrafe tributaria
                    SianWebSrv.TraduzioneSianToSiar traduzione = new SianWebSrv.TraduzioneSianToSiar();

                    //se l'utente è un consulente e vede l'impresa puo aggiornare i dati, imposto il cf abilitato da web.config
                    //string CFScaricaDatiAnagrafeAbilitato = System.Configuration.ConfigurationManager.AppSettings["ScaricaImpresa_CFOperatore"];
                    string CFScaricaDatiAnagrafeAbilitato = CF_RUP;

                    traduzione.ScaricaDatiAzienda(impresa_selezionata.Cuaa, null, CFScaricaDatiAnagrafeAbilitato);
                    //((SiarLibrary.Web.Page)Page).ShowMessage("Aggiornamento dati anagrafici completato.");
                    impresa_selezionata = new SiarBLL.ImpresaCollectionProvider().GetById(impresa_selezionata.IdImpresa);
                }
                if (impresa_selezionata != null)
                {
                    ControllaImpresa();

                    ////Controllo se l'impresa ha gia domanda iniziata e nel caso la carico, o se gia inviata bloccoinserimento 
                    //SiarLibrary.CovidAutodichiarazioneCollection autocert_coll = covid_prov.Find(null, null, bando_selezionato.IdBando, impresa_selezionata.IdImpresa, impresa_selezionata.Cuaa, impresa_selezionata.CodiceFiscale, null);
                    //if (autocert_coll.Count == 0)
                    //{
                    //    //se prima domanda popolo i dati da impresa del sigef
                    //    PopolaCampiSigef(impresa_selezionata);
                    //    divCampi.Visible = true;

                    //}
                    //else
                    //{
                    //    if (autocert_coll[0].OperatoreInserimento != Operatore.Utente.IdUtente)
                    //        throw new Exception("L'impresa selezionata ha già una pre domanda inserita da un altro utente");
                    //    //se impresa ha gia presentato blocco inserimento
                    //    if (autocert_coll[0].Definitiva)
                    //    {
                    //        throw new Exception("L'impresa selezionata ha già una pre domanda resa definitiva");
                    //    }
                    //    else
                    //    {
                    //        //Se impresa ha gia una domanda iniziata Popola i campi da nuova tabella COVID_AUTODICHIARAZIONE
                    //        autocertificazione_selezionata = autocert_coll[0];
                    //        Session.Add("id_progetto_covid", autocertificazione_selezionata.IdProgetto.ToString());
                    //    }
                    //}
                }
            }
            catch (Exception ex) { ShowError(ex); }


        }

        protected void btnAccetta_Click(object sender, EventArgs e)
        {
            try
            {
                AccettaProseguiOperatoreNonAutorizzato(txtCuaaRicerca.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }


        public void AccettaProseguiOperatoreNonAutorizzato(string piva)
        {
            SiarLibrary.Impresa findImpresa = new SiarBLL.ImpresaCollectionProvider().GetByCuaa(piva);
            if (findImpresa != null)
            {
                impresa_selezionata = findImpresa;
                ControllaImpresa();
                ShowMessage("Dati anagrafici scaricati correttamente.");
            }
            else
                throw new Exception("Impossibile trovare l'impresa selezionata.");
        }

        public void ControllaImpresa()
        {
            //Controllo se l'impresa ha gia domanda iniziata e nel caso la carico, o se gia inviata bloccoinserimento 
            SiarLibrary.CovidAutodichiarazioneCollection autocert_coll = covid_prov.Find(null, null, bando_selezionato.IdBando, impresa_selezionata.IdImpresa, impresa_selezionata.Cuaa, impresa_selezionata.CodiceFiscale, null);
            if (autocert_coll.Count == 0)
            {
                //se prima domanda popolo i dati da impresa del sigef
                PopolaCampiSigef(impresa_selezionata);
                divCampi.Visible = true;

            }
            else
            {
                if (autocert_coll[0].OperatoreInserimento != Operatore.Utente.IdUtente)
                    throw new Exception("L'impresa selezionata ha già una pre domanda inserita da un altro utente");
                //se impresa ha gia presentato blocco inserimento
                if (autocert_coll[0].Definitiva)
                {
                    throw new Exception("L'impresa selezionata ha già una pre domanda resa definitiva");
                }
                else
                {
                    //Se impresa ha gia una domanda iniziata Popola i campi da nuova tabella COVID_AUTODICHIARAZIONE
                    autocertificazione_selezionata = autocert_coll[0];
                    Session.Add("id_progetto_covid", autocertificazione_selezionata.IdProgetto.ToString());
                }
            }
        }

        public void PopolaCampi(SiarLibrary.CovidAutodichiarazione autocertificazione)
        {
            txtCompilatore.Text = Operatore.Utente.CfUtente + " - " + Operatore.Utente.Nominativo;

            txtCuaa.Text = autocertificazione.CodiceFiscale;
            txtPiva.Text = autocertificazione.PartitaIva;
            txtDataInizioAttivita.Text = autocertificazione.DataInizioAttivita;
            txtRagioneSociale.Text = autocertificazione.RagioneSociale;
            txtNumeroRegistroImprese.Text = autocertificazione.NumeroRegistroImprese;
            txtNumeroRea.Text = autocertificazione.NumeroRea;
            txtAnnoRea.Text = autocertificazione.AnnoRea;
            lstDimensione.SelectedValue = autocertificazione.DimensioneImpresa;
            //foreach (ListItem l in lstFormaGiuridica.Items) if (l.Value == autocertificazione.FormaGiuridica) { l.Selected = true; break; }
            //lstFormaGiuridica.DataBind();
            lstFormaGiuridica.SelectedValue = autocertificazione.FormaGiuridica;
            lstComboAteco.SelectedValue = autocertificazione.CodiceAteco;
            //ComboAteco.SelectedValue = autocertificazione.CodiceAteco;
            txtSLIndirizzo.Text = autocertificazione.IndirizzoSedeLegale;
            txtSLComune.Text = autocertificazione.DenominazioneComune;
            txtSLProv.Text = autocertificazione.Provincia;
            txtSLCap.Text = autocertificazione.Cap;
            txtSLTelefono.Text = autocertificazione.Telefono;
            txtSLEmail.Text = autocertificazione.Email;
            txtSLPec.Text = autocertificazione.Pec;
            txtRLNominativo.Text = autocertificazione.NominativoRappresentanteLegale;
            txtRLCFiscale.Text = autocertificazione.CfRappresentanteLegale;
            txtRLDataNascita.Text = autocertificazione.DataDiNascitaRappresentanteLegale.ToFullYearString();
            txtRLComuneNascita.Text = autocertificazione.DenominazioneComuneNascitaRappresentanteLegale;
            txtRLProvNascita.Text = autocertificazione.ProvinciaNascitaRappresentanteLegale;
            txtRLCapNascita.Text = autocertificazione.CapComuneNascitaRappresentanteLegale;
            txtCodiceIntero.Value = autocertificazione.Iban;

            string iban = "";
            if (autocertificazione.Iban != null && autocertificazione.Iban != "")
            {
                iban = autocertificazione.Iban.ToString();

                txtCodPaese.Text = iban.Substring(0, 2);
                txtCINeuro.Text = iban.Substring(2, 2);
                txtCin.Text = iban.Substring(4, 1);
                txtABI.Text = iban.Substring(5, 5);
                txtCAB.Text = iban.Substring(10, 5);
                txtNumeroConto.Text = iban.Substring(15, 12);
            }

            SiarBLL.ContoCorrenteCollectionProvider conto_prov = new SiarBLL.ContoCorrenteCollectionProvider();
            SiarLibrary.Impresa impresa = impresa_provider.GetByCuaa(txtPiva.Text);
            SiarLibrary.ContoCorrenteCollection conto_coll = conto_prov.Find(null, impresa.IdImpresa, null, null, null, null);
            if (autocertificazione.Iban != null && autocertificazione.Iban != "")
                conto_coll = conto_coll.SubSelect(null, impresa.IdImpresa, null, iban.Substring(0, 2), iban.Substring(2, 2),
                iban.Substring(4, 1), iban.Substring(5, 5), iban.Substring(10, 5),
                iban.Substring(15, 12), null, null, null, null, null, null);
            if (conto_coll.Count > 0)
            {
                txtIstituto.Text = conto_coll[0].Istituto;
                txtAgenzia.Text = conto_coll[0].Agenzia;
                ucSiarNewComuniControl.IdComune = conto_coll[0].IdComune;
                SiarLibrary.Comuni comune_banca = new SiarBLL.ComuniCollectionProvider().GetById(conto_coll[0].IdComune);
                ucSiarNewComuniControl.Denominazione = comune_banca.Denominazione;
                ucSiarNewComuniControl.Cap = comune_banca.Cap;
                ucSiarNewComuniControl.Provincia = comune_banca.Sigla;
            }

            txtContattoNominativo.Text = autocertificazione_selezionata.ContattoNominativo;
            txtTelefonoContatto.Text = autocertificazione_selezionata.ContattoTelefono;
            txtEmailContatto.Text = autocertificazione_selezionata.ContattoEmail;
            txtPecContatto.Text = autocertificazione_selezionata.ContattoPec;

            if(!NoLocalizzazione)
            {
                IdComuneHide.Value = autocertificazione_selezionata.LocalizzazioneComune;
                txtCAP.Text = autocertificazione_selezionata.LocalizzazioneCap;
                txtProv.Text = autocertificazione_selezionata.LocalizzazioneProvincia;
                txtVia.Text = autocertificazione_selezionata.LocalizzazioneVia;
            }

            if (autocertificazione_selezionata.LocalizzazioneComune != null)
            {
                SiarLibrary.Comuni c = new SiarBLL.ComuniCollectionProvider().GetById(autocertificazione_selezionata.LocalizzazioneComune);
                cmbComune.Text = c.Denominazione;
            }
        }

        public void PopolaCampiSigef(SiarLibrary.Impresa _impresa)
        {
            //popola 
            //btnSalva.Enabled = _abilitaModifica;
            txtCompilatore.Text = Operatore.Utente.CfUtente + " - " + Operatore.Utente.Nominativo;

            txtCuaa.Text = _impresa.Cuaa;
            txtPiva.Text = _impresa.CodiceFiscale;
            txtDataInizioAttivita.Text = _impresa.DataInizioAttivita;
            txtRagioneSociale.Text = _impresa.RagioneSociale;
            txtNumeroRegistroImprese.Text = _impresa.RegistroImpreseNumero;
            txtNumeroRea.Text = _impresa.ReaNumero;
            txtAnnoRea.Text = _impresa.ReaAnno;
            lstDimensione.SelectedValue = _impresa.IdDimensione;
            lstFormaGiuridica.SelectedValue = _impresa.CodFormaGiuridica;
            lstComboAteco.SelectedValue = _impresa.CodAteco2007;
            //ComboAteco.SelectedValue = _impresa.CodAteco2007;


            //Indirizzo Sede Legale
            if (_impresa.IdSedelegaleUltimo != null)
            {
                SiarLibrary.Indirizzario sede_legale = new SiarBLL.IndirizzarioCollectionProvider().GetById(_impresa.IdSedelegaleUltimo);
                if (sede_legale != null)
                {
                    txtSLIndirizzo.Text = sede_legale.Via;
                    txtSLComune.Text = sede_legale.Comune;
                    txtSLProv.Text = sede_legale.Sigla;
                    txtSLCap.Text = sede_legale.Cap;
                    txtSLTelefono.Text = sede_legale.Telefono;
                    txtSLEmail.Text = sede_legale.Email;
                    txtSLPec.Text = sede_legale.Pec;
                }
            }
            if (_impresa.IdRapprlegaleUltimo != null)
            {
                SiarLibrary.PersoneXImprese rlegale = new SiarBLL.PersoneXImpreseCollectionProvider().GetById(_impresa.IdRapprlegaleUltimo);
                if (rlegale != null)
                {
                    txtRLNominativo.Text = rlegale.Nome + " " + rlegale.Cognome;
                    txtRLCFiscale.Text = rlegale.CodiceFiscale;
                    txtRLDataNascita.Text = rlegale.DataNascita.ToFullYearString();
                    txtRLComuneNascita.Text = rlegale.Comune;
                    txtRLProvNascita.Text = rlegale.Sigla;
                    txtRLCapNascita.Text = rlegale.Cap;
                }
            }

            trCC1.Visible = true;
            trCC2.Visible = true;

            //btnSalva.OnClientClick = "return ICtrlControlloDatiCC(event);";
            SiarLibrary.ContoCorrente cc = null;
            if (_impresa.IdContoCorrenteUltimo != null)
                cc = new SiarBLL.ContoCorrenteCollectionProvider().GetById(_impresa.IdContoCorrenteUltimo);
            if (cc != null)
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
            }

            if (_impresa.CodFormaGiuridica != null && _impresa.CodFormaGiuridica != "")
            {
                Boolean EntePubblico = new SiarBLL.ImpresaCollectionProvider().VerificaBeneficiarioEntePubblico(_impresa.IdImpresa);
                if (EntePubblico)
                {
                    trImpresaDim.Visible = false;
                    trImpresaRea.Visible = false;
                    trImpresaTit.Visible = false;
                }
            }
        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (autocertificazione_selezionata != null && autocertificazione_selezionata.Definitiva)
                    throw new Exception("L'autodichiarazione è già stata resa definitiva, impossibile continuare");

                ////Verifica se ateco è presente su bando_ateco
                //int result = bando_provider.VerificaAtecoBando(bando_selezionato.IdBando, ComboAteco.SelectedValue);
                //if (result == 0)
                //    throw new Exception("Il codice ateco del beneficiario non è abilitato a presentare la pre domanda");

                SalvaDati(false);
                Redirect("RequisitiCovid.aspx", "Sezione anagrafica salvata correttamente.", false);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                covid_prov.DbProviderObj.BeginTran();

                if (autocertificazione_selezionata == null)
                    throw new Exception("Impossibile trovare l'autodichiarazione selezionata");
                if (autocertificazione_selezionata != null && autocertificazione_selezionata.Definitiva)
                    throw new Exception("L'autodichiarazione è già stata resa definitiva, impossibile continuare");
                

                // devo eliminare il progetto, i requisiti dell'autocertificazione, il piano investimenti  e l'autocertificazione
                SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider(covid_prov.DbProviderObj);
                SiarLibrary.Progetto p = progprovider.GetById(autocertificazione_selezionata.IdProgetto);

                progprovider.DeleteProgetto(p, covid_prov.DbProviderObj);

                covid_prov.Delete(autocertificazione_selezionata);
                covid_prov.DbProviderObj.Commit();

                Redirect("RichiestePredomanda.aspx", "Domanda eliminata correttamente.", false);
            }
            catch (Exception ex)
            {
                covid_prov.DbProviderObj.Rollback();
                Redirect("RichiestePredomanda.aspx", ex.Message, true);
            }
            finally
            {
                Session["id_bando_covid"] = null;
                Session["id_progetto_covid"] = null;
            }
        }

        public void SalvaDati(bool definitiva)
        {
            try
            {
                covid_prov.DbProviderObj.BeginTran();

                if (autocertificazione_selezionata == null)
                {

                    autocertificazione_selezionata = new SiarLibrary.CovidAutodichiarazione();
                    autocertificazione_selezionata.OperatoreInserimento = Operatore.Utente.IdUtente;
                    autocertificazione_selezionata.DataInserimento = DateTime.Now;
                    autocertificazione_selezionata.CodiceFiscale = txtCuaa.Text;
                    autocertificazione_selezionata.PartitaIva = txtPiva.Text;
                    autocertificazione_selezionata.Definitiva = false;
                    autocertificazione_selezionata.RagioneSociale = txtRagioneSociale.Text;
                    autocertificazione_selezionata.DataInizioAttivita = txtDataInizioAttivita.Text;
                    if (hdnEvilUser.Value != string.Empty)
                        autocertificazione_selezionata.FlagDelegatoAbilitatoSigef = false;
                    else
                        autocertificazione_selezionata.FlagDelegatoAbilitatoSigef = true;

                    covid_prov.Save(autocertificazione_selezionata);

                    SiarLibrary.ImpresaCollection imp_coll = impresa_provider.Find(txtCuaa.Text, txtPiva.Text, txtRagioneSociale.Text);
                    SiarLibrary.Impresa imp = imp_coll[0];
                    SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider(covid_prov.DbProviderObj);
                    SiarLibrary.Progetto p = new SiarLibrary.Progetto();
                    p.FlagDefinitivo = false;
                    p.FlagPreadesione = false;
                    p.IdImpresa = imp.IdImpresa;
                    p.IdBando = bando_selezionato.IdBando;
                    p.DataCreazione = DateTime.Now;
                    p.OperatoreCreazione = Operatore.Utente.IdUtente;
                    progprovider.Save(p);

                    SiarLibrary.ProgettoStorico s = new SiarLibrary.ProgettoStorico();
                    s.IdProgetto = p.IdProgetto;
                    s.CodStato = "P";
                    s.Data = DateTime.Now;
                    s.Operatore = Operatore.Utente.IdUtente;
                    new SiarBLL.ProgettoStoricoCollectionProvider(covid_prov.DbProviderObj).Save(s);

                    p.IdStoricoUltimo = s.Id;
                    progprovider.Save(p);

                    autocertificazione_selezionata.IdProgetto = p.IdProgetto;
                    autocertificazione_selezionata.IdBando = bando_selezionato.IdBando;
                    autocertificazione_selezionata.IdImpresa = p.IdImpresa;
                }



                autocertificazione_selezionata.NumeroRegistroImprese = txtNumeroRegistroImprese.Text;
                autocertificazione_selezionata.NumeroRea = txtNumeroRea.Text;
                autocertificazione_selezionata.AnnoRea = txtAnnoRea.Text;
                autocertificazione_selezionata.DimensioneImpresa = lstDimensione.SelectedValue;
                autocertificazione_selezionata.FormaGiuridica = lstFormaGiuridica.SelectedValue;
                autocertificazione_selezionata.CodiceAteco = lstComboAteco.SelectedValue;
                //autocertificazione_selezionata.CodiceAteco = ComboAteco.SelectedValue;
                autocertificazione_selezionata.IndirizzoSedeLegale = txtSLIndirizzo.Text;

                //id comune
                SiarBLL.ComuniCollectionProvider comuni_provider = new SiarBLL.ComuniCollectionProvider(covid_prov.DbProviderObj);

                if (txtSLProv.Text == "PS") txtSLProv.Text = "PU";
                SiarLibrary.ComuniCollection cc_1 = comuni_provider.RicercaComune("DENOMINAZIONE", txtSLProv.Text, txtSLCap.Text, txtSLComune.Text,
                    null, null, null, null);
                if (cc_1.Count > 0)
                    autocertificazione_selezionata.Comune = cc_1[0].IdComune;
                autocertificazione_selezionata.DenominazioneComune = txtSLComune.Text;
                autocertificazione_selezionata.Provincia = txtSLProv.Text;
                autocertificazione_selezionata.Cap = txtSLCap.Text;
                autocertificazione_selezionata.Telefono = txtSLTelefono.Text;
                autocertificazione_selezionata.Email = txtSLEmail.Text;
                autocertificazione_selezionata.Pec = txtSLPec.Text;
                autocertificazione_selezionata.NominativoRappresentanteLegale = txtRLNominativo.Text;
                autocertificazione_selezionata.CfRappresentanteLegale = txtRLCFiscale.Text;
                autocertificazione_selezionata.DataDiNascitaRappresentanteLegale = txtRLDataNascita.Text;

                //id comune
                if (txtRLProvNascita.Text == "PS") txtRLProvNascita.Text = "PU";
                SiarLibrary.ComuniCollection cc_2 = comuni_provider.RicercaComune("DENOMINAZIONE", txtRLProvNascita.Text, txtRLCapNascita.Text, txtRLComuneNascita.Text,
                    null, null, null, null);
                if (cc_2.Count > 0)
                    autocertificazione_selezionata.ComuneNascitaRappresentanteLegale = cc_2[0].IdComune;
                autocertificazione_selezionata.DenominazioneComuneNascitaRappresentanteLegale = txtRLComuneNascita.Text;
                autocertificazione_selezionata.ProvinciaNascitaRappresentanteLegale = txtRLProvNascita.Text;
                autocertificazione_selezionata.CapComuneNascitaRappresentanteLegale = txtRLCapNascita.Text;
                autocertificazione_selezionata.Iban = txtCodPaese.Text + txtCINeuro.Text + txtCin.Text + txtABI.Text + txtCAB.Text + txtNumeroConto.Text;
                SiarBLL.ImpresaCollectionProvider impresa_provider_trans = new SiarBLL.ImpresaCollectionProvider(covid_prov.DbProviderObj);
                SiarLibrary.Impresa impresa = impresa_provider_trans.GetByCuaa(txtPiva.Text);
                //Salvo iban anche su IMPRESA
                try
                {
                    SiarBLL.ContoCorrenteCollectionProvider cc_provider = new SiarBLL.ContoCorrenteCollectionProvider(covid_prov.DbProviderObj);
                    SiarLibrary.ContoCorrente cc = null;
                    if (impresa.IdContoCorrenteUltimo == null)
                    {
                        cc = new SiarLibrary.ContoCorrente();
                        cc.IdImpresa = impresa.IdImpresa;
                    }
                    else
                    {
                        cc = cc_provider.GetById(impresa.IdContoCorrenteUltimo);
                        if (cc.CodPaese != txtCodPaese.Text || cc.CinEuro != txtCINeuro.Text || cc.Cin != txtCin.Text || cc.Abi != txtABI.Text || cc.Cab != txtCAB.Text ||
                            cc.Numero != txtNumeroConto.Text || cc.Istituto != txtIstituto.Text || cc.Agenzia != txtAgenzia.Text || cc.IdComune != ucSiarNewComuniControl.IdComune)
                        {
                            cc.DataFineValidita = DateTime.Now;
                            cc_provider.Save(cc);
                            cc.MarkAsNew();
                            cc.DataInizioValidita = null;
                            cc.DataFineValidita = null;
                        }
                    }
                    cc.CodPaese = txtCodPaese.Text;
                    cc.CinEuro = txtCINeuro.Text;
                    cc.Cin = txtCin.Text;
                    cc.Abi = txtABI.Text;
                    cc.Cab = txtCAB.Text;
                    cc.Numero = txtNumeroConto.Text;
                    cc.Note = null;
                    cc.Istituto = txtIstituto.Text;
                    cc.Agenzia = txtAgenzia.Text;
                    cc.IdComune = ucSiarNewComuniControl.IdComune;
                    cc_provider.Save(cc);
                    impresa.IdContoCorrenteUltimo = cc.IdContoCorrente;
                    impresa_provider_trans.Save(impresa);
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile salvare le informazioni relative al conto corrente. Contattare l'help desk.");
                }

                autocertificazione_selezionata.ContattoNominativo = txtContattoNominativo.Text;
                autocertificazione_selezionata.ContattoTelefono = txtTelefonoContatto.Text;
                autocertificazione_selezionata.ContattoEmail = txtEmailContatto.Text;
                autocertificazione_selezionata.ContattoPec = txtPecContatto.Text;

                if(!NoLocalizzazione)
                {
                    autocertificazione_selezionata.LocalizzazioneComune = IdComuneHide.Value;
                    autocertificazione_selezionata.LocalizzazioneCap = txtCAP.Text;
                    autocertificazione_selezionata.LocalizzazioneProvincia = txtProv.Text;
                    autocertificazione_selezionata.LocalizzazioneVia = txtVia.Text;
                }
                

                if (definitiva)
                    autocertificazione_selezionata.Definitiva = true;
                else
                    autocertificazione_selezionata.Definitiva = false;

                covid_prov.Save(autocertificazione_selezionata);
                covid_prov.DbProviderObj.Commit();
                //hdnIdAutocert.Value = autocertificazione_selezionata.Id;

                Session.Add("id_progetto_covid", autocertificazione_selezionata.IdProgetto.ToString());
                progetto_selezionato = progetto_provider.GetById(autocertificazione_selezionata.IdProgetto);

            }
            catch (Exception ex) 
            { 
                covid_prov.DbProviderObj.Rollback(); 
                autocertificazione_selezionata = null;
                throw ex; 
            }
        }

        protected void btnNuova2_Click(object sender, EventArgs e)
        {
            try
            {
                Session["id_progetto_covid"] = null;
                Session["id_bando_covid"] = null;

                //redirect pagina bandi
                Redirect("Autocertificazione.aspx");
            }
            catch (Exception ex) { ShowError(ex); }
        }

        public void PulisciCampi()
        {
            try
            {
                //txtCuaaRicerca.Text = "";
                txtCuaa.Text = "";
                txtPiva.Text = "";
                txtDataInizioAttivita.Text = "";
                txtRagioneSociale.Text = "";
                lstDimensione.SelectedValue = "";
                lstFormaGiuridica.SelectedValue = "";
                //ComboAteco.SelectedValue = "";
                lstComboAteco.SelectedValue = "";
                txtNumeroRea.Text = "";
                txtNumeroRegistroImprese.Text = "";
                txtAnnoRea.Text = "";
                txtSLIndirizzo.Text = "";
                txtSLComune.Text = "";
                txtSLProv.Text = "";
                txtSLCap.Text = "";
                txtSLTelefono.Text = "";
                txtSLEmail.Text = "";
                txtSLPec.Text = "";
                txtRLNominativo.Text = "";
                txtRLDataNascita.Text = "";
                txtRLCFiscale.Text = "";
                txtRLComuneNascita.Text = "";
                txtRLProvNascita.Text = "";
                txtRLCapNascita.Text = "";
                txtCodiceIntero.Value = "";
                txtCodPaese.Text = "";
                txtCINeuro.Text = "";
                txtCin.Text = "";
                txtABI.Text = "";
                txtCAB.Text = "";
                txtNumeroConto.Text = "";
                txtIstituto.Text = "";
                txtAgenzia.Text = "";
                ucSiarNewComuniControl.IdComune = null;
                ucSiarNewComuniControl.Denominazione = "";
                ucSiarNewComuniControl.Provincia = "";
                ucSiarNewComuniControl.Cap = "";
                txtTelefonoContatto.Text = "";
                txtEmailContatto.Text = "";
                txtPecContatto.Text = "";
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }
    }
}