using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiarLibrary.Web
{
    public class MasterPage : System.Web.UI.MasterPage
    {
        public SiarLibrary.Operatore Operatore
        {
            get { return (SiarLibrary.Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }

        public void SetOperatoreAlias(SiarLibrary.Utenti u)
        {
            if (u == null) throw new Exception("L'operatore selezionato non è valido.");
            Operatore o = new Operatore();
            o.Utente = u;
            Session["OperatoreAlias"] = o;
        }

        public void SetOperatoreRuolo(SiarLibrary.Utenti u)
        {
            if (u == null) throw new Exception("L'operatore selezionato non è valido.");
            Operatore o = new Operatore();
            o.Utente = u;
            Session["OperatoreAlias"] = null;
            Session["Operatore"] = o;
        }

        public void SetOperatore(SiarLibrary.NullTypes.IntNT idprofilo)
        {
            bool isAuthForte = false;
            SiarLibrary.Operatore op = new SiarLibrary.Operatore();
            string cf_utente = null;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
#if (DEBUG)
            {
                cf_utente = System.Configuration.ConfigurationManager.AppSettings["CF_LOGIN"];
                if (string.IsNullOrEmpty(cf_utente)) cf_utente = "";
                isAuthForte = true;
            }
#else
            {
            object sessione_cohesion = Session["COHESION_TOKEN"];
            if (sessione_cohesion == null || string.IsNullOrEmpty(sessione_cohesion.ToString()))
                throw new Exception("La sessione di lavoro è scaduta, è necessario effettuare di nuovo l'autenticazione.");
            doc.LoadXml(sessione_cohesion.ToString());
            System.Xml.XmlNodeList nl = doc.GetElementsByTagName("tipo_autenticazione");
            // controllo che l'accesso sia in modalità "forte"
            if (nl.Count == 0 || string.IsNullOrEmpty(nl[0].InnerText) || nl[0].InnerText == "PW")
                throw new Exception("L'accesso a questa sezione è consentito solo tramite l'utilizzo dell'autenticazione forte (Smart Card, Pin Raffaello, Accesso a dominio per rete interna).");
            else
                isAuthForte = true;
            nl = doc.GetElementsByTagName("codice_fiscale");
            if (nl.Count > 0) cf_utente = nl[0].InnerText;
            //doc = null;
            }
#endif
            if (string.IsNullOrEmpty(cf_utente) || cf_utente.Length != 16)
                throw new Exception("L'utente non è un operatore valido per questo portale. Impossibile continuare.");
            SiarLibrary.UtentiCollection uc = new SiarBLL.UtentiCollectionProvider().Find(cf_utente, null, null, null, idprofilo, null, true);
            if (uc.Count == 0 && isAuthForte && System.Configuration.ConfigurationManager.AppSettings["AutoInsertUser"] == "1")
            {
                SiarLibrary.Utenti userNew = GeneraUtenteAutomatico(cf_utente, doc);
                if (userNew != null && userNew.CfUtente == cf_utente) uc.Add(userNew);
            }
            if (uc.Count == 0) throw new Exception("L'utente non è un operatore valido per questo portale. Impossibile continuare.");
            op.Utente = uc[0];
#if (!DEBUG)
            try
            {   // scrivo nel log
                SiarLibrary.DbStaticProvider.WriteLogAccessi(op.Utente.IdUtente, Request.Browser.Browser, Request.Browser.Version,
                    Request.Browser.Platform, Request.ServerVariables["REMOTE_ADDR"], Request.Url.Host);
            }
            catch (Exception ex) { new SiarLibrary.Email("Errore nel log accessi", "Messaggio errore:\n" + ex.Message).SendAlert(); }
#endif
            Session["Operatore"] = op;
        }

        // : attivazione automatica utenti
        private SiarLibrary.Utenti GeneraUtenteAutomatico(string insCF, System.Xml.XmlDocument doc)
        {
            SiarLibrary.Utenti retUsr = null;
            try
            {
                int defaultProfilo = -1;
                if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["AutoInsertUser_Profilo"], out defaultProfilo))
                    throw new Exception("Profilo utente per l'inserimento non impostato correttamente nel sistema.");
                int defaultOperatoreInsID = -1;
                if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["AutoInsertUser_Operatore"], out defaultOperatoreInsID))
                    throw new Exception("ID operatore di inserimento non impostato correttamente nel sistema.");
                string defaultEnte = System.Configuration.ConfigurationManager.AppSettings["AutoInsertUser_IDEnte"];
                string defaultOperatoreInsCF = System.Configuration.ConfigurationManager.AppSettings["AutoInsertUser_CFOperatore"];

                SiarLibrary.PersonaFisica pf = null;
                SiarBLL.PersonaFisicaCollectionProvider pfCollProv = new SiarBLL.PersonaFisicaCollectionProvider();
                SiarLibrary.PersonaFisicaCollection pfColl = pfCollProv.Find(insCF);
                SianWebSrv.TraduzioneSianToSiar trad = new SianWebSrv.TraduzioneSianToSiar();
                if (pfColl.Count > 0 && pfColl[0].Nome != null) pf = pfColl[0];
                else
                {
                    // questo servio non funziona più
                    //pf = trad.ScaricaDatiPersonaFisica(insCF, defaultOperatoreInsCF);
                    pf = ScaricaDatiDaToken(doc);

                }
                if (pf != null)
                    retUsr = new SiarBLL.UtentiCollectionProvider().NuovoUtente(pf.IdPersona, defaultProfilo, defaultEnte, null, defaultOperatoreInsID);
            }
            catch (Exception exInt) { }
            return retUsr;
        }

        private PersonaFisica ScaricaDatiDaToken(System.Xml.XmlDocument doc)
        {
            SiarBLL.PersonaFisicaCollectionProvider pfprov = new SiarBLL.PersonaFisicaCollectionProvider();

            try
            {

                System.Xml.XmlNodeList nlCodiceFiscale = doc.GetElementsByTagName("codice_fiscale");
                System.Xml.XmlNodeList nlNome = doc.GetElementsByTagName("nome");
                System.Xml.XmlNodeList nlCognome = doc.GetElementsByTagName("cognome");
                System.Xml.XmlNodeList nlSesso = doc.GetElementsByTagName("sesso");
                System.Xml.XmlNodeList nlLocNascita = doc.GetElementsByTagName("localita_nascita");
                System.Xml.XmlNodeList nlProvNascita = doc.GetElementsByTagName("provincia_nascita");
                System.Xml.XmlNodeList nlDataNascita = doc.GetElementsByTagName("data_nascita");
                //System.Xml.XmlNodeList nlEmail = doc.GetElementsByTagName("email");
                System.Xml.XmlNodeList nlIndirizzoResidenza = doc.GetElementsByTagName("indirizzo_residenza");                

                pfprov.DbProviderObj.BeginTran();

                SiarLibrary.PersonaFisica pf = new PersonaFisica();

                pf.Nome = nlNome[0].InnerText;
                pf.Cognome = nlCognome[0].InnerText;
                if (nlSesso[0] != null)
                    pf.Sesso = nlSesso[0].InnerText;
                else
                    pf.Sesso = getSessoFromCf(nlCodiceFiscale[0].InnerText);
                pf.DataNascita = nlDataNascita[0].InnerText;                
                if (nlLocNascita[0] != null)
                {
                    string provinciaNascita = null;
                    if (nlProvNascita[0] != null)
                        provinciaNascita = nlProvNascita[0].InnerText;

                    string localitaNascita = nlLocNascita[0].InnerText;
                    if (localitaNascita.Contains("("))
                        localitaNascita = localitaNascita.Substring(0, localitaNascita.IndexOf("(")).TrimEnd();

                    int idComune;
                    try
                    {
                        idComune = TrovaComune("DENOMINAZIONE", provinciaNascita, null, nlLocNascita[0].InnerText, null, null);
                        pf.IdComuneNascita = idComune;
                    }
                    catch (Exception ex)
                    {
                        Comuni c = getComuneFromCf(nlCodiceFiscale[0].InnerText);
                        if (c != null)
                        {
                            idComune = c.IdComune;
                            pf.IdComuneNascita = idComune;
                        } 
                    }
                }
                else
                {
                    SiarLibrary.Comuni c = getComuneFromCf(nlCodiceFiscale[0].InnerText);
                    if (c!= null)
                        pf.IdComuneNascita = c.IdComune;                    
                }
                pf.CodiceFiscale = nlCodiceFiscale[0].InnerText.ToString().ToUpper();
                pfprov.Save(pf);

                SiarBLL.IndirizzoCollectionProvider indirizzo_provider = new SiarBLL.IndirizzoCollectionProvider(pfprov.DbProviderObj);

                SiarLibrary.Indirizzo i = new Indirizzo();
                if (nlIndirizzoResidenza[0] != null)
                    i.Via = nlIndirizzoResidenza[0].InnerText;
                else
                    i.Via = "n.d.";
                indirizzo_provider.Save(i);

                SiarBLL.IndirizzarioCollectionProvider indirizzario_provider = new SiarBLL.IndirizzarioCollectionProvider(pfprov.DbProviderObj);
                SiarLibrary.Indirizzario sede = new Indirizzario();

                sede.IdPersona = pf.IdPersona;
                sede.IdIndirizzo = i.IdIndirizzo;
                sede.CodTipoSede = "R";
                sede.FlagAttivo = true;
                indirizzario_provider.Save(sede);

                pfprov.DbProviderObj.Commit();

                return pf;
            }
            catch (Exception ex)
            {
                pfprov.DbProviderObj.Rollback(); 
                throw ex;
            }
        }

        private int TrovaComune(string tipo_ricerca, string sigla_provincia, string cap_comune, string denominazione_comune,
            string cod_provincia, string istat_comune)
        {
            SiarBLL.ComuniCollectionProvider comuni_provider = new SiarBLL.ComuniCollectionProvider();
            if (sigla_provincia == "PS") sigla_provincia = "PU";
            SiarLibrary.ComuniCollection cc = comuni_provider.RicercaComune(tipo_ricerca, sigla_provincia, cap_comune, denominazione_comune,
                cod_provincia, istat_comune, null, null);
            if (cc.Count == 0) 
                throw new Exception("Comune non trovato.");
            return cc[0].IdComune;
        }

        private string getSessoFromCf(string cf)
        {
            int result;
            if (int.TryParse(cf.Substring(9, 2), out result))
            {
                if (result > 40)
                    return "F";
                else
                    return "M";
            }
            else return "";
        }

        private Comuni getComuneFromCf(string cf)
        {
            string belfiore = cf.Substring(11, 4);

            SiarBLL.ComuniCollectionProvider comuni_provider = new SiarBLL.ComuniCollectionProvider();

            SiarLibrary.ComuniCollection cc = comuni_provider.Find(belfiore, null, null, null, null, null, null, null);
            if (cc.Count == 0)
                return null;
            else
            {
                var comuneAttivo = cc.ToArrayList<Comuni>().Where(c => c.Attivo == true).FirstOrDefault<Comuni>();
                if (comuneAttivo != null)
                    return comuneAttivo;
                else
                    return cc[0];
            }
        }
    }
}
