using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;

namespace web.Private.COVID
{
    public partial class RequisitiCovid : SiarLibrary.Web.PrivatePage
    {
        SiarBLL.BandoProgrammazioneCollectionProvider bp_provider;
        SiarLibrary.BandoProgrammazioneCollection disposizioni_attuative;

        // dichiarazioni
        SiarLibrary.DichiarazioniXDomandaCollection diccoll;
        SiarLibrary.DichiarazioniXProgettoCollection dicXprogettoColl;

        //per la presentazione senza calcolo contributo
        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_provider = new SiarBLL.CovidAutodichiarazioneCollectionProvider();
        SiarLibrary.CovidAutodichiarazione autodic_selezionata = null;
        bool noCalcoloContributo;

        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "autocertificazione_covid";
            base.OnPreInit(e);
        }

        SiarLibrary.Bando bando;
        SiarLibrary.Progetto progetto;
        SiarLibrary.Impresa impresa;
        SiarBLL.ProgettoCollectionProvider ProgettoProvider = new SiarBLL.ProgettoCollectionProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            //  -- -- -- QUI DEVE PRENDERLI DALLA SESSIONE E NON PIU' DALLA QUERYSTRING!!!! -- -- --
            //int id_bando, id_progetto;
            //if (int.TryParse(Request.QueryString["idb"], out id_bando)) bando = new SiarBLL.BandoCollectionProvider().GetById(id_bando);
            //if (int.TryParse(Request.QueryString["iddom"], out id_progetto)) progetto = new SiarBLL.ProgettoCollectionProvider().GetById(id_progetto);
            if (Session["id_bando_covid"] != null) bando = new SiarBLL.BandoCollectionProvider().GetById(Session["id_bando_covid"].ToString());
            if (Session["id_progetto_covid"] != null) progetto = new SiarBLL.ProgettoCollectionProvider().GetById(Session["id_progetto_covid"].ToString());

            bp_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);

            if (bando == null || progetto == null) Redirect("Autocertificazione.aspx", "Per proseguire è necessario selezionare il bando desiderato.", true);
            impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);

            if (bando.IdModelloDomanda != null)
            {
                diccoll = new SiarBLL.DichiarazioniXDomandaCollectionProvider().Find(null, bando.IdModelloDomanda);
                diccoll.Sort("Ordine, Misura, Descrizione");
            }

            SiarLibrary.CovidAutodichiarazioneCollection auto_coll = covid_provider.Find(null,
                    progetto.IdProgetto, progetto.IdBando, progetto.IdImpresa, null, null, null);
            autodic_selezionata = auto_coll[0];

            ucFirmaDocumentoCovid.DocumentoFirmatoEvent = ProtocollaDocCovidEvent;

        }

        protected override void OnPreRender(EventArgs e)
        {
            //if (progetto.CodStato == "P")
            //    btnPresenta.Enabled = true;
            //else
            //{

            //    btnPresenta.Enabled = false;
            //    btnRicevuta.Disabled = false;
            //    btnRicevuta.Attributes.Add("onclick", "SNCVisualizzaReport('rptFrontespizio',1,'ID_Domanda=" + progetto.IdProgetto + "');");
            //}
            if (Session["id_bando_covid"] != null) noCalcoloContributo = new SiarBLL.BandoCollectionProvider().HasCovidNoCalcoloPredomanda(Session["id_bando_covid"].ToString());
            if (noCalcoloContributo)
            {
                btnGo.Visible = false;
                //btnPresenta.Visible = true;
            }


            SiarLibrary.CovidAutodichiarazione autodichiarazione_selezionata = new SiarBLL.CovidAutodichiarazioneCollectionProvider().Find(null, progetto.IdProgetto, progetto.IdBando, null, null, null, null)[0];

            if (autodichiarazione_selezionata != null && autodichiarazione_selezionata.Definitiva)
            { 
                btnSalva.Enabled = false;
                btnGo.Enabled = false;
                //btnPresenta.Enabled = false;
                btnElimina.Enabled = false;
                btnInviaRichiesta.Enabled = false;
            }

            if (progetto.CodStato != "P")
            {
                btnSalva.Enabled = false;
                //btnPresenta.Enabled = false;
                btnElimina.Enabled = false;
                btnInviaRichiesta.Enabled = false;
            }              


            disposizioni_attuative = bp_provider.GetDispAttuativeBando(progetto.IdBando, progetto.IdProgetto);
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                Control c = LoadControl("~/CONTROLS/RequisitiMisura.ascx");
                System.Reflection.PropertyInfo progi = c.GetType().GetProperty("IdProgIntegrato");
                progi.SetValue(c, progetto.IdProgetto, null);
                System.Reflection.PropertyInfo pi = c.GetType().GetProperty("DisposizioniAttuative");
                pi.SetValue(c, d, null);
                System.Reflection.PropertyInfo fasei = c.GetType().GetProperty("fase_istruttoria");
                fasei.SetValue(c, false, null);
                tdControls.Controls.Add(c);
            }
            //btnGo non funzionerà più con la querystring ma deve essere un controllo lato server e caricare una pagina 
            //btnGo.Attributes.Add("onclick", "location='ProgettoCovid.aspx?iddom="+progetto.IdProgetto + "&idb=" + progetto.IdBando+"'");

            //Dichiarazioni
            if (diccoll != null)
            {
                dgObbligatorie.DataSource = diccoll.FiltroObbligatorio(true);
                dgObbligatorie.DataBind();
                dgFacoltative.DataSource = diccoll.FiltroObbligatorio(false);
            }

            dicXprogettoColl = new SiarBLL.DichiarazioniXProgettoCollectionProvider().Find(null, progetto.IdProgetto);
            string[] sel = new string[dicXprogettoColl.Count];
            for (int i = 0; i < dicXprogettoColl.Count; i++)
            {
                sel[i] = dicXprogettoColl[i].IdDichiarazione.ToString();
            }
            ((SiarLibrary.Web.CheckColumn)dgFacoltative.Columns[2]).SetSelected(sel);
            dgFacoltative.DataBind();
            if(diccoll.FiltroObbligatorio(false).Count == 0 )
            {
                divDgFac.Visible = false;
                divLbFac.Visible = false;
            }


            if (Operatore.Utente.CodEnte == "%")
            {
                divButtonAmm.Visible = true;
                btnSalva.Enabled = false;
                btnElimina.Enabled = false;
                btnPresenta.Enabled = false;
            }

            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                salvaRequisitiDichiarazioni();
                ShowMessage("Requisiti e dichiarazioni salvati correttamente.");
                if (Session["id_bando_covid"] != null) noCalcoloContributo = new SiarBLL.BandoCollectionProvider().HasCovidNoCalcoloPredomanda(Session["id_bando_covid"].ToString());
                if (noCalcoloContributo)
                {
                    btnPresenta.Enabled = true;
                    btnElimina.Enabled = true;
                }
            }
            catch (Exception exc) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(exc); }
        }

        private void salvaRequisitiDichiarazioni()
        {
            disposizioni_attuative = bp_provider.GetDispAttuativeBando(progetto.IdBando, progetto.IdProgetto);

            SiarBLL.PrioritaXProgettoCollectionProvider priorita_provider = new SiarBLL.PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj);

            ProgettoProvider.DbProviderObj.BeginTran();

            ListItemCollection licoll = new ListItemCollection();
            foreach (SiarLibrary.BandoProgrammazione d in disposizioni_attuative)
            {
                SiarLibrary.NullTypes.IntNT IdProgetto = new SiarLibrary.NullTypes.IntNT(d.AdditionalAttributes["IdProgetto"]);
                priorita_provider.DeleteCollection(priorita_provider.Find(IdProgetto, null, null));

                SiarLibrary.PrioritaXProgettoCollection priorita_progetto = priorita_provider.GetPrioritaDisposizioniAttuative(
                    d.IdDisposizioniAttuative, "D", IdProgetto);

                foreach (SiarLibrary.PrioritaXProgetto pp in priorita_progetto)
                {
                    if (pp.InputNumerico)
                    {
                        decimal valore;
                        if (decimal.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], out valore))
                        {
                            SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                            pp_new.IdProgetto = IdProgetto;
                            pp_new.IdPriorita = pp.IdPriorita;
                            pp_new.Valore = valore;
                            priorita_provider.Save(pp_new);
                        }
                    }
                    else if (pp.PluriValore)
                    {
                        int id_valore_priorita, id_disposizione_attuativa_check;
                        foreach (string s in Request.Form.AllKeys)
                        {
                            if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizione" + pp.IdPriorita) && int.TryParse(Request.Form[s],
                                out id_disposizione_attuativa_check) && id_disposizione_attuativa_check == d.IdDisposizioniAttuative &&
                                int.TryParse(Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizione", "hdnPlurivaloreSelezionato")], out id_valore_priorita))
                            {
                                SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                pp_new.IdProgetto = IdProgetto;
                                pp_new.IdPriorita = pp.IdPriorita;
                                pp_new.IdValore = id_valore_priorita;
                                priorita_provider.Save(pp_new);
                                break;
                            }
                        }
                    }
                    else if (pp.PluriValoreSql)
                    {
                        int id_disposizione_attuativa_check;
                        foreach (string s in Request.Form.AllKeys)
                        {
                            if (s.EndsWith("hdnPlurivaloreSelezionatoDisposizioneSql" + pp.IdPriorita) &&
                                int.TryParse(Request.Form[s], out id_disposizione_attuativa_check) &&
                                id_disposizione_attuativa_check == d.IdDisposizioniAttuative)
                            {
                                string id_valore_priorita = Request.Form[s.Replace("hdnPlurivaloreSelezionatoDisposizioneSql", "hdnPlurivaloreSelezionatoSql")];
                                if (!string.IsNullOrEmpty(id_valore_priorita))
                                {
                                    SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                    pp_new.IdProgetto = IdProgetto;
                                    pp_new.IdPriorita = pp.IdPriorita;
                                    pp_new.ValTesto = id_valore_priorita;
                                    priorita_provider.Save(pp_new);
                                    break;
                                }
                            }
                        }
                    }
                    else if (pp.Datetime)
                    {
                        DateTime data;
                        if (DateTime.TryParse(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"], out data))
                        {
                            SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                            pp_new.IdProgetto = IdProgetto;
                            pp_new.IdPriorita = pp.IdPriorita;
                            pp_new.ValData = data;
                            priorita_provider.Save(pp_new);
                        }

                    }
                    else if (pp.TestoSemplice || pp.TestoArea)
                    {
                        string testoIn = Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"];
                        if (!string.IsNullOrEmpty(Request.Form["txtPriorita" + pp.IdPriorita + "_" + d.IdDisposizioniAttuative + "_text"]))
                        {
                            SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                            pp_new.IdProgetto = IdProgetto;
                            pp_new.IdPriorita = pp.IdPriorita;
                            pp_new.ValTesto = testoIn;
                            priorita_provider.Save(pp_new);
                        }

                    }
                    else if (!string.IsNullOrEmpty(Request.Form["chkPriorita"]))
                    {
                        string[] priorita_selezionate = Request.Form["chkPriorita"].Split(',');
                        foreach (string s in priorita_selezionate)
                        {
                            if (pp.IdPriorita == int.Parse(s))
                            {
                                SiarLibrary.PrioritaXProgetto pp_new = new SiarLibrary.PrioritaXProgetto();
                                pp_new.IdProgetto = IdProgetto;
                                pp_new.IdPriorita = pp.IdPriorita;
                                priorita_provider.Save(pp_new);
                                break;
                            }
                        }
                    }
                }
            }
            ProgettoProvider.AggiornaProgetto(progetto, Operatore.Utente.IdUtente);

            AccettaDichiarazioni(ProgettoProvider.DbProviderObj);

            creaVociInvestimento(ProgettoProvider);

            ProgettoProvider.DbProviderObj.Commit();
        }

        public void AccettaDichiarazioni(SiarLibrary.DbProvider dbProviderObject)
        {
            SiarBLL.DichiarazioniXProgettoCollectionProvider dichXprogettoPro = new SiarBLL.DichiarazioniXProgettoCollectionProvider(dbProviderObject);
            SiarLibrary.DichiarazioniXProgetto dichiarazioniProgetto;

            //dichXprogettoPro.DbProviderObj.BeginTran();
            dichXprogettoPro.DeleteCollection(dichXprogettoPro.Find(null, progetto.IdProgetto));

            //dichiarazioni obbligatorie
            foreach (SiarLibrary.DichiarazioniXDomanda dXd in diccoll.FiltroObbligatorio(true))
            {
                dichiarazioniProgetto = new SiarLibrary.DichiarazioniXProgetto();
                dichiarazioniProgetto.Provider = dichXprogettoPro;
                dichiarazioniProgetto.IdDichiarazione = dXd.IdDichiarazione;
                dichiarazioniProgetto.IdProgetto = progetto.IdProgetto;
                dichXprogettoPro.Save(dichiarazioniProgetto);
            }

            //Dichiarazioni Facoltative
            string[] selezionati = ((SiarLibrary.Web.CheckColumn)dgFacoltative.Columns[2]).GetSelected();
            foreach (string s in selezionati)
            {
                dichiarazioniProgetto = new SiarLibrary.DichiarazioniXProgetto();
                dichiarazioniProgetto.Provider = dichXprogettoPro;
                dichiarazioniProgetto.IdDichiarazione = s;
                dichiarazioniProgetto.IdProgetto = progetto.IdProgetto;
                dichXprogettoPro.Save(dichiarazioniProgetto);
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            SiarLibrary.CovidAutodichiarazione autodichiarazione_selezionata = new SiarBLL.CovidAutodichiarazioneCollectionProvider().Find(null, progetto.IdProgetto, progetto.IdBando, null, null, null, null)[0];

            try
            {
                covid_provider.DbProviderObj.BeginTran();

                if (autodichiarazione_selezionata == null)
                    throw new Exception("Impossibile trovare l'autodichiarazione selezionata");
                if (autodichiarazione_selezionata != null && autodichiarazione_selezionata.Definitiva)
                    throw new Exception("L'autodichiarazione è già stata resa definitiva, impossibile continuare");

                // devo eliminare il progetto, i requisiti dell'autocertificazione, il piano investimenti  e l'autocertificazione
                SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider(covid_provider.DbProviderObj);
                SiarLibrary.Progetto p = progprovider.GetById(autodichiarazione_selezionata.IdProgetto);

                progprovider.DeleteProgetto(p, covid_provider.DbProviderObj);

                covid_provider.Delete(autodichiarazione_selezionata);
                covid_provider.DbProviderObj.Commit();

                Redirect("RichiestePredomanda.aspx", "Domanda eliminata correttamente.", false);
            }
            catch (Exception ex) 
            { 
                covid_provider.DbProviderObj.Rollback();
                Redirect("RichiestePredomanda.aspx", ex.Message, true);
            }
            finally
            {
                Session["id_bando_covid"] = null;
                Session["id_progetto_covid"] = null;
            }
        }

        protected void btnProsegui_Click(object sender, EventArgs e)
        {
            try
            {
                salvaRequisitiDichiarazioni();
                string verifica = ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaCovid(progetto.IdProgetto);
                if (string.IsNullOrEmpty(verifica))
                {
                    //da qui si prosegue!
                    Redirect("ProgettoCovid.aspx");
                }
            }
            catch (Exception ex) { ShowErrorFull(ex); }
        }

        protected void btnPresenta_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (autodic_selezionata.Definitiva)
                    throw new Exception("La Domanda è già stata resa definitiva!");

                salvaRequisitiDichiarazioni();
                string verifica = ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaCovid(progetto.IdProgetto);
                if (string.IsNullOrEmpty(verifica))
                {
                    autodic_selezionata.DataDefinitiva = DateTime.Now;
                    autodic_selezionata.Definitiva = true;
                    covid_provider.Save(autodic_selezionata);
                    creaVociInvestimento();
                    //ShowMessage("La Pre Domanda è stata resa definitiva!");
                    Redirect("RichiestePredomanda.aspx", "La Domanda è stata resa definitiva!", false);
                }

            }
            catch (Exception ex)
            {

                ShowError(ex);
            }

        }

        private void creaVociInvestimento(SiarBLL.ProgettoCollectionProvider ProgettoProvider)
        {
            SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarLibrary.BandoProgrammazione programmazionebando = programmazione_provider.GetProgrammazioneBando(bando.IdBando, false)[0];
            SiarLibrary.CodificaInvestimentoCollection codifica_investimenti = new SiarLibrary.CodificaInvestimentoCollection();
            SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider(ProgettoProvider.DbProviderObj);
            codifica_investimenti = codifica_provider.Find(bando.IdBando, null);
            SiarLibrary.DettaglioInvestimenti dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj).FindByIdBando(bando.IdBando, codifica_investimenti[0].IdCodificaInvestimento)[0];
            //codifica_investimenti = codifica_provider.Find(Bando.IdBando);//leva
            SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarLibrary.CodificaInvestimento cod_inv = new SiarBLL.CodificaInvestimentoCollectionProvider(ProgettoProvider.DbProviderObj).GetById(codifica_investimenti[0].IdCodificaInvestimento);
            SiarLibrary.ZpsrAlbero zpsrAlbero = new SiarBLL.ZpsrAlberoCollectionProvider(ProgettoProvider.DbProviderObj).GetById(programmazionebando.CodTipo);

            //SiarLibrary.CovidProgettoAutodichiarazione covidProgettoAutodichiarazione = new SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider().Find(null, Progetto.IdProgetto, Bando.IdBando, null, null)[0];
            //SiarLibrary.CovidAutodichiarazioneRequisiti covidAutodichiarazioneRequisiti = new SiarBLL.CovidAutodichiarazioneRequisitiCollectionProvider().Find(covidProgettoAutodichiarazione.IdAutodichiarazione, "1", null)[0];
            SiarLibrary.Priorita priorita;
            SiarBLL.PrioritaCollectionProvider prioritaCollectionProvider = new SiarBLL.PrioritaCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarLibrary.PrioritaXProgettoCollection prioritaXProgettoCollection = new SiarBLL.PrioritaXProgettoCollectionProvider(ProgettoProvider.DbProviderObj).Find(progetto.IdProgetto, null, null);
            SiarBLL.ValoriPrioritaCollectionProvider valoriPrioritaCollectionProvider = new SiarBLL.ValoriPrioritaCollectionProvider(ProgettoProvider.DbProviderObj);
            if (prioritaXProgettoCollection.Count == 0)
                throw new Exception("Nessuna priorità è stata selezionata");

            double contributo_richiesto = 0;
            foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
            {
                priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                if (priorita.Eval == "Importo_Contributo_Covid")
                {
                    var valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                    contributo_richiesto += double.Parse(valoriPriorita.Punteggio);
                }
                else if(priorita.Eval == "Importo_Contributo_Ventilazione")
                {
                    var num_aule = double.Parse(pp.Valore);
                    var valoriPriorita = valoriPrioritaCollectionProvider.Find(null, priorita.IdPriorita, null);
                    if (valoriPriorita != null)
                        contributo_richiesto += num_aule * double.Parse(valoriPriorita[0].Punteggio);
                }
            }
            string[] cod_investimenti = new string[0];
            foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
            {
                priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                if (priorita.Eval == "Criterio_Contributo_Covid")
                {
                    SiarLibrary.ValoriPriorita valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                    if (valoriPriorita.Codice != null)
                    {
                        string codici = valoriPriorita.Codice;
                        cod_investimenti = codici.Split('|');
                    }
                }
            }

            SiarLibrary.PianoInvestimentiCollection investimentiDaSalvare = new SiarLibrary.PianoInvestimentiCollection();


            if (cod_investimenti.Length == 0)
            {
                SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                {
                    IdProgetto = progetto.IdProgetto,
                    IdProgrammazione = programmazionebando.IdProgrammazione,
                    Descrizione = codifica_investimenti[0].Descrizione,
                    CodTipoInvestimento = 1,
                    CodStp = "00",
                    IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                    Quantita = 1,
                    CostoInvestimento = contributo_richiesto,
                    SpeseGenerali = 0,
                    ContributoRichiesto = contributo_richiesto,
                    QuotaContributoRichiesto = 100.00,
                    IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                    IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                    DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                    CodificaInvestimento = cod_inv.Descrizione,
                    NonCofinanziato = 0,
                    Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                };
                investimentiDaSalvare.Add(inv);
            }
            else
            {
                foreach (string cod_investimento in cod_investimenti)
                {
                    cod_inv = codifica_investimenti.ToArrayList<SiarLibrary.CodificaInvestimento>().SingleOrDefault(o => o.Codice == cod_investimento);
                    dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj).FindByIdBando(bando.IdBando, cod_inv.IdCodificaInvestimento)[0];
                    SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                    {
                        IdProgetto = progetto.IdProgetto,
                        IdProgrammazione = programmazionebando.IdProgrammazione,
                        Descrizione = cod_inv.Descrizione,
                        CodTipoInvestimento = 1,
                        CodStp = "00",
                        IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                        Quantita = 1,
                        CostoInvestimento = contributo_richiesto,
                        SpeseGenerali = 0,
                        ContributoRichiesto = contributo_richiesto,
                        QuotaContributoRichiesto = 100.00,
                        IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                        IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                        DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                        CodificaInvestimento = cod_inv.Descrizione,
                        NonCofinanziato = 0,
                        Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                    };
                    investimentiDaSalvare.Add(inv);
                }
            }

            try
            {
                investimenti_provider.DbProviderObj.BeginTran();
                SiarLibrary.PianoInvestimentiCollection pianoInvestimentiCollection = investimenti_provider.Find(null, progetto.IdProgetto, null, null, null, null, null);
                investimenti_provider.DeleteCollection(pianoInvestimentiCollection);
                foreach (SiarLibrary.PianoInvestimenti investimento in investimentiDaSalvare)
                    investimenti_provider.Save(investimento);
                investimenti_provider.DbProviderObj.Commit();
            }

            catch (Exception ex)
            {
                investimenti_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        private void creaVociInvestimento()
        {
            SiarBLL.BandoProgrammazioneCollectionProvider programmazione_provider = new SiarBLL.BandoProgrammazioneCollectionProvider();
            SiarLibrary.BandoProgrammazione programmazionebando = programmazione_provider.GetProgrammazioneBando(bando.IdBando, false)[0];
            SiarLibrary.CodificaInvestimentoCollection codifica_investimenti = new SiarLibrary.CodificaInvestimentoCollection();
            SiarBLL.CodificaInvestimentoCollectionProvider codifica_provider = new SiarBLL.CodificaInvestimentoCollectionProvider();
            codifica_investimenti = codifica_provider.Find(bando.IdBando, null);
            SiarLibrary.DettaglioInvestimenti dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider().FindByIdBando(bando.IdBando, codifica_investimenti[0].IdCodificaInvestimento)[0];
            //codifica_investimenti = codifica_provider.Find(Bando.IdBando);//leva
            SiarBLL.PianoInvestimentiCollectionProvider investimenti_provider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarLibrary.CodificaInvestimento cod_inv = new SiarBLL.CodificaInvestimentoCollectionProvider().GetById(codifica_investimenti[0].IdCodificaInvestimento);
            SiarLibrary.ZpsrAlbero zpsrAlbero = new SiarBLL.ZpsrAlberoCollectionProvider().GetById(programmazionebando.CodTipo);

            //SiarLibrary.CovidProgettoAutodichiarazione covidProgettoAutodichiarazione = new SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider().Find(null, Progetto.IdProgetto, Bando.IdBando, null, null)[0];
            //SiarLibrary.CovidAutodichiarazioneRequisiti covidAutodichiarazioneRequisiti = new SiarBLL.CovidAutodichiarazioneRequisitiCollectionProvider().Find(covidProgettoAutodichiarazione.IdAutodichiarazione, "1", null)[0];
            SiarLibrary.Priorita priorita;
            SiarBLL.PrioritaCollectionProvider prioritaCollectionProvider = new SiarBLL.PrioritaCollectionProvider();
            SiarLibrary.PrioritaXProgettoCollection prioritaXProgettoCollection = new SiarBLL.PrioritaXProgettoCollectionProvider().Find(progetto.IdProgetto, null, null);
            SiarBLL.ValoriPrioritaCollectionProvider valoriPrioritaCollectionProvider = new SiarBLL.ValoriPrioritaCollectionProvider();
            if (prioritaXProgettoCollection.Count == 0)
                throw new Exception("Nessuna priorità è stata selezionata");

            double contributo_richiesto = 0;
            foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
            {
                priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                if (priorita.Eval == "Importo_Contributo_Covid")
                {
                    SiarLibrary.ValoriPriorita valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                    contributo_richiesto += double.Parse(valoriPriorita.Punteggio);
                }
                else if (priorita.Eval == "Importo_Contributo_Ventilazione")
                {
                    var num_aule = double.Parse(pp.Valore);
                    var valoriPriorita = valoriPrioritaCollectionProvider.Find(null, priorita.IdPriorita, null);
                    if (valoriPriorita != null)
                        contributo_richiesto += num_aule * double.Parse(valoriPriorita[0].Punteggio);
                }
            }
            string[] cod_investimenti = new string[0];
            foreach (SiarLibrary.PrioritaXProgetto pp in prioritaXProgettoCollection)
            {
                priorita = prioritaCollectionProvider.GetById(pp.IdPriorita);
                if (priorita.Eval == "Criterio_Contributo_Covid")
                {
                    SiarLibrary.ValoriPriorita valoriPriorita = valoriPrioritaCollectionProvider.GetById(pp.IdValore);
                    if (valoriPriorita.Codice != null)
                    {
                        string codici = valoriPriorita.Codice;
                        cod_investimenti = codici.Split('|');
                    }
                }
            }

            SiarLibrary.PianoInvestimentiCollection investimentiDaSalvare = new SiarLibrary.PianoInvestimentiCollection();


            if (cod_investimenti.Length == 0)
            {
                SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                {
                    IdProgetto = progetto.IdProgetto,
                    IdProgrammazione = programmazionebando.IdProgrammazione,
                    Descrizione = codifica_investimenti[0].Descrizione,
                    CodTipoInvestimento = 1,
                    CodStp = "00",
                    IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                    Quantita = 1,
                    CostoInvestimento = contributo_richiesto,
                    SpeseGenerali = 0,
                    ContributoRichiesto = contributo_richiesto,
                    QuotaContributoRichiesto = 100.00,
                    IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                    IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                    DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                    CodificaInvestimento = cod_inv.Descrizione,
                    NonCofinanziato = 0,
                    Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                };
                investimentiDaSalvare.Add(inv);
            }
            else
            {
                foreach (string cod_investimento in cod_investimenti)
                {
                    cod_inv = codifica_investimenti.ToArrayList<SiarLibrary.CodificaInvestimento>().SingleOrDefault(o => o.Codice == cod_investimento);
                    dettaglioInvestimenti = new SiarBLL.DettaglioInvestimentiCollectionProvider().FindByIdBando(bando.IdBando, cod_inv.IdCodificaInvestimento)[0];
                    SiarLibrary.PianoInvestimenti inv = new SiarLibrary.PianoInvestimenti
                    {
                        IdProgetto = progetto.IdProgetto,
                        IdProgrammazione = programmazionebando.IdProgrammazione,
                        Descrizione = cod_inv.Descrizione,
                        CodTipoInvestimento = 1,
                        CodStp = "00",
                        IdUnitaMisura = dettaglioInvestimenti.IdUdm,
                        Quantita = 1,
                        CostoInvestimento = contributo_richiesto,
                        SpeseGenerali = 0,
                        ContributoRichiesto = contributo_richiesto,
                        QuotaContributoRichiesto = 100.00,
                        IdCodificaInvestimento = cod_inv.IdCodificaInvestimento,
                        IdDettaglioInvestimento = dettaglioInvestimenti.IdDettaglioInvestimento,
                        DettaglioInvestimenti = dettaglioInvestimenti.Descrizione,
                        CodificaInvestimento = cod_inv.Descrizione,
                        NonCofinanziato = 0,
                        Misura = zpsrAlbero.Descrizione + " " + programmazionebando.Codice
                    };
                    investimentiDaSalvare.Add(inv);
                }
            }

            try
            {
                investimenti_provider.DbProviderObj.BeginTran();
                SiarLibrary.PianoInvestimentiCollection pianoInvestimentiCollection = investimenti_provider.Find(null, progetto.IdProgetto, null, null, null, null, null);
                investimenti_provider.DeleteCollection(pianoInvestimentiCollection);
                foreach (SiarLibrary.PianoInvestimenti investimento in investimentiDaSalvare)
                    investimenti_provider.Save(investimento);
                investimenti_provider.DbProviderObj.Commit();
            }

            catch (Exception ex) 
            { 
                investimenti_provider.DbProviderObj.Rollback();
                ShowError(ex);
            }
        }

        protected void btnInviaRichiesta_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.CovidAutodichiarazioneCollection auto_coll = covid_provider.Find(Operatore.Utente.IdUtente,
                    progetto.IdProgetto, progetto.IdBando, progetto.IdImpresa, null, null, null);
                autodic_selezionata = auto_coll[0];
                //SiarLibrary.CovidAutodichiarazione autocert = covid_provider.GetById(autodic_selezionata.Id);

                if (autodic_selezionata.Definitiva)
                    throw new Exception("La Domanda è già stata resa definitiva!");

                salvaRequisitiDichiarazioni();
                string verifica = ProgettoProvider.VerificaCondizioniGeneraliPresentazioneDomandaCovid(progetto.IdProgetto);
                if (string.IsNullOrEmpty(verifica))
                {
                    //autodic_selezionata.DataDefinitiva = DateTime.Now;
                    //autodic_selezionata.Definitiva = true;
                    //covid_provider.Save(autodic_selezionata);
                    //creaVociInvestimento();
                    //ShowMessage("La Pre Domanda è stata resa definitiva!");
                    //Redirect("RichiestePredomanda.aspx", "La Pre Domanda è stata resa definitiva!", false);

                    ucFirmaDocumentoCovid.DoppiaFirma = false;
                    ucFirmaDocumentoCovid.FirmaObbligatoria = bando.FirmaRichiesta;
                    ucFirmaDocumentoCovid.loadDocumento(Operatore.Utente.CfUtente, autodic_selezionata.IdProgetto, autodic_selezionata.IdBando);
                }

            }
            catch (Exception ex) { ProgettoProvider.DbProviderObj.Rollback(); ShowError(ex); }
        }


        protected void ProtocollaDocCovidEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SiarBLL.ProgettoCollectionProvider ProgettoProvider = new SiarBLL.ProgettoCollectionProvider();
            SiarBLL.ArchivioFileCollectionProvider fileProvider = new SiarBLL.ArchivioFileCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarBLL.CovidAutodichiarazioneCollectionProvider autoDicProvider = new SiarBLL.CovidAutodichiarazioneCollectionProvider(ProgettoProvider.DbProviderObj);


            SiarLibrary.CovidAutodichiarazione autocert = autoDicProvider.GetById(autodic_selezionata.Id);
            SiarLibrary.Progetto progetto = ProgettoProvider.GetById(autocert.IdProgetto);

            SiarLibrary.Operatore op_rilascio = Operatore;

            SiarBLL.PianoInvestimentiCollectionProvider investimentiprovider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);

            try
            {
                progetto.ProvinciaDiPresentazione = "AN";

                if (progetto.CodStato != "P") throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");

                IntNT idProgetto = progetto.IdProgetto;

                ProgettoProvider.CambioStatoProgetto(progetto, "L", "", op_rilascio);
                progetto = ProgettoProvider.GetById(idProgetto);

                //Prendo il report aggiornato con la data
                var doc = ucFirmaDocumentoCovid.getDocumentoFromServer(idProgetto,autocert.IdBando);


                //inizio transazione
                ProgettoProvider.DbProviderObj.BeginTran();

                //Rendo definitiva la domanda
                autocert.DataDefinitiva = DateTime.Now;
                autocert.Definitiva = true;
                autoDicProvider.Save(autodic_selezionata);
                creaVociInvestimento(ProgettoProvider);

                SiarLibrary.PianoInvestimentiCollection investcoll = investimentiprovider.Find(null, progetto.IdProgetto, null, null, null, null, null);
                if (investcoll.FiltroInvestimentoOriginale(false).Count <= 0)
                {//se non ci sono investimenti clonati allora li clono
                    foreach (SiarLibrary.PianoInvestimenti invest in investcoll)
                    {
                        invest.MarkAsNew();
                        invest.IdInvestimentoOriginale = invest.IdInvestimento;
                        invest.Ammesso = false;
                        invest.IdInvestimento = null;
                        investimentiprovider.Save(invest);

                        SiarLibrary.PrioritaXInvestimentiCollection priorita = priorita_provider.Find(null, invest.IdInvestimentoOriginale, null, null);
                        foreach (SiarLibrary.PrioritaXInvestimenti pr in priorita)
                        {
                            pr.MarkAsNew();
                            pr.IdInvestimento = invest.IdInvestimento;
                            priorita_provider.Save(pr);
                        }
                    }
                }

                //Cambio stato progetto
                ProgettoProvider.CambioStatoProgetto(progetto, "I", "", op_rilascio);
                ProgettoProvider.CambioStatoProgetto(progetto, "A", "", op_rilascio);


                // Controllo la riga su graduatoria progetto ALTRIMENTI LA CREO
                SiarLibrary.GraduatoriaProgetti graduatoria = null;
                SiarLibrary.GraduatoriaProgettiCollection grad_coll = graduatoria_provider.Find(progetto.IdBando, progetto.IdProgetto, null);
                if (grad_coll.Count > 0)
                    graduatoria = grad_coll[0];
                else
                    graduatoria = new SiarLibrary.GraduatoriaProgetti();
                graduatoria.IdBando = bando.IdBando;
                graduatoria.IdProgetto = progetto.IdProgetto;
                graduatoria.Punteggio = 0;
                graduatoria.DataValutazione = DateTime.Today;
                graduatoria.Operatore = Operatore.Utente.CfUtente;
                graduatoria_provider.Save(graduatoria);


                var file = new SiarLibrary.ArchivioFile();

                file.Tipo = "application/pdf";
                file.NomeCompleto = "IdDomanda_" + idProgetto + ".pdf";
                file.NomeFile = "IdDomanda_" + idProgetto + ".pdf";
                file.Dimensione = doc.Length;
                file.Contenuto = doc;


                System.Security.Cryptography.HashAlgorithm alg = System.Security.Cryptography.HashAlgorithm.Create("SHA256");
                byte[] fileHashValue = alg.ComputeHash(doc);
                string hash_code = ucFirmaDocumentoCovid.BinaryToHex(fileHashValue);
                file.HashCode = hash_code;

                fileProvider.Save(file);



                //Salvo il token Cohesion
                object sessione_cohesion = Session["COHESION_TOKEN"];
                if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                    throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                //object sessione_cohesion = @"<test_cohesion>test token</test_cohesion>";

                //aggiorno la predomanda
                autocert.IdFileDomanda = file.Id;
                autocert.TokenCohesion = sessione_cohesion.ToString();

                autoDicProvider.Save(autocert);

                progetto.FlagDefinitivo = true;
                ProgettoProvider.Save(progetto);

                ProgettoProvider.DbProviderObj.Commit();


                Redirect("RichiesteCovid.aspx", "Richiesta di contributo presentata correttamente. ", false, false);

            }
            catch (Exception ex)
            {
                ProgettoProvider.DbProviderObj.Rollback();
                progetto = ProgettoProvider.GetById(progetto.IdProgetto);
                ProgettoProvider.AnnullaUltimoCambioStatoProgetto(progetto, false);
                //ProgettoProvider.AnnullaUltimoCambioStatoProgetto(progetto, false, ProgettoProvider.DbProviderObj);
                ShowError(ex); ;
            }
        }
    }
}