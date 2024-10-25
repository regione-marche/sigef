using SiarBLL;
using SiarLibrary;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {           
            Application["TotalOnlineUsers"] = 0;  
        }

        protected void Session_Start(object sender, EventArgs e)
        {         
            try
            {
                Application.Lock();
                Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] + 1;
            }
            finally
            {
                Application.UnLock();
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //fixwebservices(); DA USARE IN DEBUG NEL CASO IN CUI DIA PROBLEMI LA CREAZIONE DEL CANALE SSL/TLS
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception ex = HttpContext.Current.Server.GetLastError();
                if (ex != null)
                {
#if(!DEBUG)
                    string testo_email = "Server: " + HttpContext.Current.Server.MachineName;
                    //string db_string = System.Configuration.ConfigurationManager.ConnectionStrings["DB_SIGEF"].ConnectionString;
                    //testo_email += "\nDatabase:" + db_string.Remove(db_string.IndexOf(";password")).Remove(0, db_string.IndexOf("catalog=") + 8).ToUpper();
                    
                    Operatore op = (Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]);
                    if (op != null) 
                        testo_email += "\nUtente: " + op.Utente.Nominativo + " (id:" + op.Utente.IdUtente + ")";
                    
                    if (Session["_azienda"] != null)
                    {
                        Impresa i = (Impresa)Session["_azienda"];
                        testo_email += "\nCuaa: " + i.Cuaa;
                    }
                    
                    if (Session["_progetto"] != null)
                    {
                        Progetto p = (Progetto)Session["_progetto"];
                        testo_email += "\nId Progetto: " + p.IdProgetto;
                    }
                    
                    if (Session["domanda_pagamento"] != null)
                    {
                        DomandaDiPagamento d = (DomandaDiPagamento)Session["domanda_pagamento"];
                        testo_email += "\nId Domanda Pagamento: " + d.IdDomandaPagamento;
                    }
                    
                    if (Session["_variante"] != null)
                    {
                        Varianti v = (Varianti)Session["_variante"];
                        testo_email += "\nId Variante: " + v.IdVariante;
                    }

                    EmailUtility.SendEmailToTeamSigef(ex, "AUTO_ERROR_LOG", testo_email);
#else
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(Request.ApplicationPath) + "\\bin\\SiarLogErrori.txt", true);
                    sw.WriteLine("*************" + DateTime.Now.ToString() + "*******************");
                    sw.WriteLine("");
                    Exception exc = ex;
                    while (exc != null)
                    {
                        sw.WriteLine("Messaggio errore: " + exc.Message);
                        if (exc is SiarException) sw.WriteLine("Custom exception: [Codice: " + ((SiarException)exc).Codice + " ] [Gravità: "
                            + ((SiarException)exc).Gravita + " ]");
                        sw.WriteLine("Source: " + (exc.Source != null ? exc.Source : ""));
                        sw.WriteLine("Target site: " + (exc.TargetSite != null ? exc.TargetSite.ToString() : ""));
                        sw.WriteLine("Stack trace: " + (exc.StackTrace != null ? exc.StackTrace : ""));
                        exc = exc.InnerException;
                        sw.WriteLine("");
                    }
                    sw.WriteLine("*****end*****");
                    sw.WriteLine("");
                    sw.Close();
#endif
                }
            }
            catch { }
        }

        protected void Session_End(object sender, EventArgs e)
        {            
            Application.Lock();
            Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] - 1;
            Application.UnLock();

            //if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            //{
            //    LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();

            //    if (Operatore != null && Operatore.Utente != null && Operatore.Utente.IdUtente != null)
            //    {
            //        var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(Operatore.Utente.IdUtente);

            //        if (accessi_utente_coll.Count > 0)
            //            accessi_provider.RiempiDataLogout(Operatore.Utente.IdUtente);
            //    }

            //}

            var impostazioni_provider = new ImpostazioniCollectionProvider();
            var istanzaSigef = ConfigurationManager.AppSettings["IstanzaSigef"];

            if (impostazioni_provider.GetIngressiContingentatiAbilitati(istanzaSigef)) //if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            {
                LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();

                if (Operatore != null && Operatore.Utente != null && Operatore.Utente.IdUtente != null)
                {
                    var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(istanzaSigef, Operatore.Utente.IdUtente);

                    if (accessi_utente_coll.Count > 0)
                        accessi_provider.RiempiDataLogout(istanzaSigef, Operatore.Utente.IdUtente);
                }

            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            //{
            //    LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();
            //    var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(null);

            //    if (accessi_utente_coll.Count > 0)
            //        accessi_provider.RiempiDataLogout(null);
            //}

            var impostazioni_provider = new ImpostazioniCollectionProvider();
            var istanzaSigef = ConfigurationManager.AppSettings["IstanzaSigef"];

            if (impostazioni_provider.GetIngressiContingentatiAbilitati(istanzaSigef)) //if (ConfigurationManager.AppSettings["IngressiContingentatiAbilitati"] == "true")
            {
                LogAccessiCollectionProvider accessi_provider = new LogAccessiCollectionProvider();
                var accessi_utente_coll = accessi_provider.GetLoginAppesiUtente(istanzaSigef, null);

                if (accessi_utente_coll.Count > 0)
                    accessi_provider.RiempiDataLogout(istanzaSigef, null);
            }
        }

        public Operatore Operatore
        {
            get { return (Operatore)(Session["OperatoreAlias"] ?? Session["Operatore"]); }
        }

        public static void fixwebservices()
        {
            // fix per i certificati dei webservice  

            System.Net.ServicePointManager.Expect100Continue = true;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                            | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls
                            | System.Net.SecurityProtocolType.Ssl3;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                return true;
            };

        }
    }
}