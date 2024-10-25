using SiarBLL;
using SiarLibrary.NullTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Private.COVID
{
    public partial class SelezionaAutocertificazione : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.FunzioneMenu = "bandi_covid";
            base.OnPreInit(e);
        }

        SiarLibrary.Bando bando;
        SiarBLL.BandoCollectionProvider bando_provider = new SiarBLL.BandoCollectionProvider();
        SiarBLL.CovidAutodichiarazioneCollectionProvider covid_prov = new SiarBLL.CovidAutodichiarazioneCollectionProvider();
        SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
        SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider prog_covid_prov = new SiarBLL.CovidProgettoAutodichiarazioneCollectionProvider();
        SiarBLL.ProgettoCollectionProvider progprovider = new SiarBLL.ProgettoCollectionProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_bando;
            if (Session["id_bando_covid"] != null)
            {
                //int id_bando = Convert.ToInt32()
                bando = bando_provider.GetById(Convert.ToInt32((string)Session["id_bando_covid"]));
            }
            else
                Redirect("BandiCovid.aspx", "Nessun bando selezionato!", true);
            
            //ucFirmaDocumento.DocumentoFirmatoEvent = ProtocollaDocFirmatoEvent;
            ucFirmaDocumentoCovid.DocumentoFirmatoEvent = ProtocollaDocCovidEvent;
        }


        protected override void OnPreRender(EventArgs e)
        {
            lstAutodichiarazione.IdUtente = Operatore.Utente.IdUtente;
            lstAutodichiarazione.IdBando = bando.IdBando;
            lstAutodichiarazione.DataBind();
            SiarLibrary.CovidAutodichiarazioneCollection autocert_coll = covid_prov.Find(Operatore.Utente.IdUtente,null,bando.IdBando,null ,null, null, null);
            if(autocert_coll.Count == 0)
            {
                lstAutodichiarazione.Visible = false;
                lbNoFound.Visible = true;
                btnSalva.Enabled = false;
            }
            base.OnPreRender(e);
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.CovidAutodichiarazione autocert = covid_prov.GetById(lstAutodichiarazione.SelectedValue);
                //ucFirmaDocumento.DoppiaFirma = false;
                //ucFirmaDocumento.FirmaObbligatoria = bando.FirmaRichiesta;
                //ucFirmaDocumento.loadDocumento(Operatore.Utente.CfUtente, autocert.IdProgetto);
                ucFirmaDocumentoCovid.DoppiaFirma = false;
                ucFirmaDocumentoCovid.FirmaObbligatoria = bando.FirmaRichiesta;
                ucFirmaDocumentoCovid.loadDocumento(Operatore.Utente.CfUtente, autocert.IdProgetto);

            }
            catch (Exception ex) { progprovider.DbProviderObj.Rollback(); ShowError(ex); }
        }


        protected void ProtocollaDocCovidEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SiarBLL.ProgettoCollectionProvider ProgettoProvider = new SiarBLL.ProgettoCollectionProvider();
            SiarBLL.ArchivioFileCollectionProvider fileProvider = new SiarBLL.ArchivioFileCollectionProvider(ProgettoProvider.DbProviderObj);
            SiarBLL.CovidAutodichiarazioneCollectionProvider autoDicProvider = new SiarBLL.CovidAutodichiarazioneCollectionProvider(ProgettoProvider.DbProviderObj);

            SiarLibrary.CovidAutodichiarazione autocert = autoDicProvider.GetById(lstAutodichiarazione.SelectedValue);
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
                var doc = ucFirmaDocumentoCovid.getDocumentoFromServer(idProgetto);
                
                
                //inizio transazione
                ProgettoProvider.DbProviderObj.BeginTran();



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

        protected void ProtocollaDocFirmatoEvent(object sender, EventArgs e)
        {
            try
            {
                SiarLibrary.CovidAutodichiarazione autocert = covid_prov.GetById(lstAutodichiarazione.SelectedValue);
                SiarLibrary.Progetto progetto = new SiarBLL.ProgettoCollectionProvider().GetById(autocert.IdProgetto);
                SiarLibrary.Impresa impresa = new SiarBLL.ImpresaCollectionProvider().GetById(progetto.IdImpresa);
                SiarBLL.ProgettoCollectionProvider ProgettoProvider = new SiarBLL.ProgettoCollectionProvider();

                if (progetto.CodStato != "P") throw new Exception("La domanda di aiuto selezionata non è valida. Impossibile continuare.");
                //if (string.IsNullOrEmpty(ucFirmaDocumento.FileFirmato))
                //    throw new Exception("Si è verificato un errore sul server. Si prega di contattare l`helpdesk e segnalare il problema.");

                SiarLibrary.Protocollo p = new SiarLibrary.Protocollo(bando.CodEnte);

                SiarLibrary.PersonaFisica pf = new SiarBLL.PersonaFisicaCollectionProvider().GetById(Operatore.Utente.IdPersonaFisica);
                p.setCorrispondente(pf.Cognome, pf.Nome, null, "mittente");

                //p.setDocumento("doc_principale_domanda.pdf", Convert.FromBase64String(ucFirmaDocumento.FileFirmato));

                string[] ss = new SiarBLL.BandoCollectionProvider().GetDatiXProtocollazione(progetto.IdBando, progetto.ProvinciaDiPresentazione);
                string oggetto = "Domanda di adesione al bando: " + ss[0] + " del " + ss[1] + " con scadenza: " + ss[2] + "\nRif." + ss[3] + "\nN° Domanda: "
                    + progetto.IdProgetto + "\nImpresa: " + impresa.CodiceFiscale + " " + impresa.RagioneSociale;


                //// carico gli allegati su paleo
                //SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
                ////Dichiarazione nome e hash degli allegati per l'impronta
                //foreach (SiarLibrary.ProgettoAllegati allegato in allegati)
                //{
                //    try
                //    {
                //        if (allegato.IdFile != null)
                //        {
                //            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(allegato.IdFile);
                //            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                //            p.addAllegato(f.NomeFile, f.HashCode);
                //        }
                //    }
                //    catch (Exception ex) { }
                //}

                //se il bando non prevede la firma dichiaro anche l'allegato con il token Cohesion
                if (!bando.FirmaRichiesta)
                {
                    object sessione_cohesion = Session["COHESION_TOKEN"];
                    if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                        throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                    p.addAllegato("Autenticazione_Operatore.xml", p.GetSHA256(System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString())));
                }

                string segnatura = p.ProtocolloIngresso(oggetto, ss[4]);

                SiarBLL.PianoInvestimentiCollectionProvider investimentiprovider = new SiarBLL.PianoInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarBLL.PrioritaXInvestimentiCollectionProvider priorita_provider = new SiarBLL.PrioritaXInvestimentiCollectionProvider(ProgettoProvider.DbProviderObj);
                SiarBLL.GraduatoriaProgettiCollectionProvider graduatoria_provider = new SiarBLL.GraduatoriaProgettiCollectionProvider(ProgettoProvider.DbProviderObj);
                //SiarBLL.LocalizzazioneInvestimentoCollectionProvider localizzazione_provider = new SiarBLL.LocalizzazioneInvestimentoCollectionProvider(ProgettoProvider.DbProviderObj);                
                try
                {
                    //rendo definitivo tutto
                    ProgettoProvider.DbProviderObj.BeginTran();
                    //stessa procedura sia se integrato che altrimenti
                    //SiarLibrary.ProgettoCollection progettiCorrelati = ProgettoProvider.Find(null, null, progetto.IdProgetto, null, null, null, null);
                    ////se non e' multimisura occorre che aggiungo il progetto
                    //if (progettiCorrelati.Count == 0) progettiCorrelati.Add(progetto);

                    if (bando.FascicoloRichiesto && progetto.IdFascicolo == null)
                        throw new Exception("Il fascicolo aziendale dell'impresa non è stato trovato. Occorre scaricarlo per continuare.");

                    // per le domande con la predisposizione alla firma impongo l'operatore di rilascio=operatore di modifica
                    // per compatibilità con le successive regole di accesso alla domanda
                    SiarLibrary.Operatore op_rilascio = Operatore;
                    //if (Progetto.FirmaPredisposta)
                    //{
                    //    SiarLibrary.Utenti u = new SiarBLL.UtentiCollectionProvider().GetById(Progetto.Operatore);
                    //    if (u != null) op_rilascio.Utente = u;
                    //}

                    //foreach (SiarLibrary.Progetto prog in progettiCorrelati)
                    //{
                    //duplico gli investimenti per permettere l'istruttoria
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
                    //salvo la provincia e operatore di presentazione per ogni progetto correlato
                    progetto.ProvinciaDiPresentazione = progetto.ProvinciaDiPresentazione;
                    progetto.FlagDefinitivo = true;
                    //ProgettoProvider.Save(prog); non necessario

                    ProgettoProvider.CambioStatoProgetto(progetto, "L", segnatura, op_rilascio);
                    ProgettoProvider.CambioStatoProgetto(progetto, "I", segnatura, op_rilascio);
                    ProgettoProvider.CambioStatoProgetto(progetto, "A", segnatura, op_rilascio);

                    //}

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

                    ProgettoProvider.DbProviderObj.Commit();

                    //aggiorno la sessione
                    progetto = ProgettoProvider.GetById(progetto.IdProgetto);
                    //btnSalva.Enabled = false;
                    
                    
                    //ucDatiDomanda.ForzaCaricamentoDati = true;
                    //ucDatiDomanda.loadData();

                    System.Collections.ArrayList allegatiProtocollo = new System.Collections.ArrayList();

                    if (!bando.FirmaRichiesta)
                    {
                        // carico il token di cohesion come allegato alla domanda
                        object sessione_cohesion = Session["COHESION_TOKEN"];
                        if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                            throw new Exception("Non è stata trovata nessuna informazione sull'operatore di rilascio, impossibile continuare.");
                        //p.addAllegato("Autenticazione_Operatore.xml", System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString()), "xml");

                        SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();

                        all.Descrizione = "Autenticazione_Operatore.xml";
                        all.Documento = new SiarBLL.paleoWebService.File();
                        all.Documento.NomeFile = "Autenticazione_Operatore.xml";
                        all.Documento.Stream = System.Text.Encoding.Unicode.GetBytes(sessione_cohesion.ToString());
                        //a.Documento.Estensione = estensione;
                        //a.NumeroPagine = 1;
                        System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                        allegatoProtocollo.Add("allegato", all);
                        allegatoProtocollo.Add("id_file", -1);
                        allegatoProtocollo.Add("tipo_origine", "progetto");
                        allegatoProtocollo.Add("id_origine", progetto.IdProgetto);
                        allegatiProtocollo.Add(allegatoProtocollo);
                    }

                    // carico gli allegati su paleo /// spostato sopra riga 205 il 16/09/2019 per aggiornamento paleo 
                    //SiarLibrary.ProgettoAllegatiCollection allegati = new SiarBLL.ProgettoAllegatiCollectionProvider().Find(Progetto.IdProgetto, null);
                    //int numeroAllegati = 0;
                    //SiarBLL.AllegatiProtocollatiCollectionProvider allegatiProtocollatiProvider = new SiarBLL.AllegatiProtocollatiCollectionProvider();
                    //foreach (SiarLibrary.ProgettoAllegati a in allegati)
                    //{
                    //    try
                    //    {
                    //        if (a.IdFile != null)
                    //        {
                    //            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(a.IdFile);
                    //            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");

                    //            SiarLibrary.AllegatiProtocollatiCollection exist = allegatiProtocollatiProvider.Find(Progetto.IdProgetto, null, null, null, null, f.Id, null, null);
                    //            if (exist.Count == 0)
                    //            {
                    //                SiarLibrary.AllegatiProtocollati ap = new SiarLibrary.AllegatiProtocollati();
                    //                ap.IdVariante = DBNull.Value;
                    //                ap.IdProgetto = Progetto.IdProgetto;
                    //                ap.IdDomandaPagamento = DBNull.Value;
                    //                ap.IdIntegrazione = DBNull.Value;
                    //                ap.IdFile = f.Id;
                    //                ap.Protocollato = false;
                    //                allegatiProtocollatiProvider.Save(ap);
                    //                numeroAllegati++;
                    //            }
                    //        }
                    //    }
                    //    catch (Exception ex) { }
                    //}

                    //foreach (SiarLibrary.ProgettoAllegati x in allegati)
                    //{
                    //    try
                    //    {
                    //        if (x.IdFile != null)
                    //        {
                    //            SiarLibrary.ArchivioFile f = new SiarBLL.ArchivioFileCollectionProvider().GetById(x.IdFile);
                    //            if (f == null) throw new Exception("Almeno uno dei documenti allegati alla presente domanda non è valido.");
                    //            string estensione = null;
                    //            if (f.Tipo != null) estensione = f.Tipo.Value.Substring(f.Tipo.Value.LastIndexOf("/") + 1);
                    //            //p.addAllegato(f.NomeFile, f.Contenuto, estensione);
                    //            SiarBLL.paleoWebService.Allegato all = new SiarBLL.paleoWebService.Allegato();
                    //            all.Descrizione = f.NomeFile;
                    //            all.Documento = new SiarBLL.paleoWebService.File();
                    //            all.Documento.Nome = f.NomeFile;

                    //            System.Collections.Generic.Dictionary<string, object> allegatoProtocollo = new System.Collections.Generic.Dictionary<string, object>();
                    //            allegatoProtocollo.Add("allegato", all);
                    //            allegatoProtocollo.Add("id_file", f.Id);
                    //            allegatoProtocollo.Add("tipo_origine", "progetto");
                    //            allegatoProtocollo.Add("id_origine", Progetto.IdProgetto);
                    //            allegatiProtocollo.Add(allegatoProtocollo);
                    //        }
                    //    }
                    //    catch (Exception ex) { }
                    //}

                    SiarLibrary.Protocollo protocolloAll = new SiarLibrary.Protocollo(bando.CodEnte);

                    protocolloAll.addAllegatiProtocollo(allegatiProtocollo, segnatura);

                    //bool allegatiProtocollatiOk = checkAllegatiProtocollati(numeroAllegati, segnatura); 

                    //if (allegatiProtocollatiOk) ShowMessage("Domanda di aiuto presentata e protocollata correttamente.");
                    //else ShowError("Domanda di aiuto presentata e protocollata correttamente. Attenzione: non tutti gli allegati sono stati inviati al protocollo, riprovare ad inviare tramite l'apposito pulsante.");

                    //ShowMessage("Richiesta di contributo presentata e protocollata correttamente. ");
                    Redirect("RichiesteCovid.aspx", "Richiesta di contributo presentata e protocollata correttamente. ", false);
                }
                catch (Exception ex)
                {
                    ProgettoProvider.DbProviderObj.Rollback();
                    string oggettoEmail = "Errore durante la presentazione domanda di aiuto";
                    string testEmail = "Domanda di aiuto: " + progetto.IdProgetto + "\nSegnatura: " + segnatura + "\nOperatore: " +
                            Operatore.Utente.CfUtente + " - " + Operatore.Utente.Nominativo
                            + "\nOperatore: " + Operatore.Utente.Profilo + " - " + Operatore.Utente.Ente + "\n\n" + ex.Message;
                    EmailUtility.SendEmailToTeamSigef(ex, oggettoEmail, testEmail);
                    ShowError(ex);
                }
            }
            catch (Exception ex) { ShowError(ex); }
        }
    }
}