using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using SianWebSrv.Logging;
using System.Xml.XPath;
using SianWebSrv.PSR;
using System.Xml;

/// <summary>
/// Contiene le classi necessarie a consultare l'anagrafe tributaria nazionale
/// e il fascicolo delle aziende agricole. Si appoggia ai servizi web AGRISIAN
/// wsAnagrafeAT e wsAGEAtoOpr pubblicati dal portale www.sian.it
/// </summary>
/// <remarks>
/// Tutti i servizi sono acessibili per mezzo delle classi seguenti:
/// <list type="bullet">
/// <item>AnagrafeTributaria che utilizza il Web service wsAnagrafeAT</item>
/// <item>FascicoloAziendale che utilizza il Web service wsAGEAtoOpr</item>
/// </list>
/// </remarks>
namespace SianWebSrv
{
    /// <summary>
    /// Classe astratta che definisce il comportamento di base dei WebService AGEA
    /// </summary>
    /// <remarks>
    /// Questa classe può mantenere un riferimento ai seguenti oggetti:
    /// <list type="bullet">
    /// <item>
    /// un oggetto che implementa l'interfaccia IMethodCallLogger, per la 
    /// registrazione su file o DB Sql Server di tutte le chiamate ai metodi
    /// di consultazione dei web service AGEA.
    /// Per default tutte le registrazioni avvengono su file. Impostando a Null
    /// questo riferimenti si disabilita la relativa funzione di tracciatura.
    /// </item>
    /// <item>
    /// un oggetto che implementa l'interfaccia IErrorLogger, per la registrazione 
    /// su file o DB Sql Server di tutte le eccezioni che si verificano a runtime.
    /// Per default tutte le registrazioni avvengono su file. Impostando a Null
    /// questo riferimenti si disabilita la relativa funzione di tracciatura.
    /// </item>
    /// <item>
    /// un oggetto che implementa l'interfaccia ISoapMsgLogger, per la registrazione 
    /// su file o DB Sql Server dei messaggi SOAP scambiati con il server SIAN.
    /// Per default questo riferimento è impostato a Null, ovvero non viene
    /// regiatrato lo scambio di messaggi.
    /// </item>
    /// </list>
    /// </remarks>
    abstract public class WebSian
    {
        public const int DEFAULT_TIMEOUT = 300000;

        /// <summary>
        /// Struttura per memorizzare i parametri di configurazione degli oggetti
        /// per l'interrogazione dei WebService AGEA.
        /// </summary>
        public struct InitParam
        {
            private int _Timeout;
            private string _WebSrvUser;
            private string _WebSrvPassword;
            private string _Url;

            /// <summary>
            /// Utente che identifica la Regione Marche per l'accesso al servizio WEB.
            /// Vedi anche SianGateway.
            /// </summary>
            public string WebSrvUser
            {
                get { return _WebSrvUser; }
                set
                {
                    if (value.Trim() != "")
                    {
                        _WebSrvUser = value.Trim();
                    }
                    else
                    {
                        throw new Exception("Url non può essere una stringa nulla.");
                    }
                }
            }

            /// <summary>
            /// Password della Regione Marche per l'accesso al servizio WEB.
            /// Vedi anche SianGateway.
            /// </summary>
            public string WebSrvPassword
            {
                get { return _WebSrvPassword; }
                set
                {
                    if (value.Trim() != "")
                    {
                        _WebSrvPassword = value.Trim();
                    }
                    else
                    {
                        throw new Exception("WebSrvPassword non può essere una stringa nulla.");
                    }
                }
            }

            /// <summary>
            /// Indirizzo internet che espone il servizio WEB, si trova nel
            /// ramo <c>soap:address location</c> del file wsdl descriptor del servizio.
            /// Vedi anche SianGateway.
            /// </summary>
            public string Url
            {
                get { return _Url; }
                set
                {
                    if (value.Trim() != "")
                    {
                        _Url = value.Trim();
                    }
                    else
                    {
                        throw new Exception("Url non può essere una stringa nulla.");
                    }
                }
            }

            /// <summary>
            /// Tempo massimo in millesimi di secondo di attesa della risposta
            /// da parte del server SIAN. Per default 30 secondi.
            /// </summary>
            public int Timeout
            {
                get
                {
                    if (_Timeout > 0)
                    {
                        return _Timeout;
                    }
                    else
                    {
                        return DEFAULT_TIMEOUT;
                    }
                }
                set
                {
                    if (value > 0)
                    {
                        _Timeout = value;
                    }
                    else
                    {
                        _Timeout = DEFAULT_TIMEOUT;
                    }
                }
            }
        }

        protected InitParam _Param;
        public InitParam Param
        {
            get { return _Param; }
            set
            {
                _Param = value;
                SianObj.Timeout = _Param.Timeout;
            }
        }

        internal SIANGateway SianObj;

        public ProxyWebConfig Proxy;

        /// <summary>
        /// Permette di gestire la presenza di un eventuale proxy che filtra il traffico
        /// da e verso il server SIAN
        /// </summary>
        public class ProxyWebConfig
        {
            /// <summary>
            /// Nome Host o indirizzo IP del Proxy
            /// </summary>
            public string Host = "";
            /// <summary>
            /// Porta del servizio Proxy 
            /// </summary>
            public int Port = 0;
            /// <summary>
            /// Indica se il proxy è attivo
            /// </summary>
            public bool Active = false;

            /// <summary>
            /// Costruttore di default, legge la configurazione proxy dal file
            /// di configurazione dell'applicazione dal campo UseProxyWsSian e InfoProxyWsSian
            /// </summary>
            public ProxyWebConfig()
            {
                string s = System.Configuration.ConfigurationManager.AppSettings.Get("UseProxyWsSian");
                if (s != null)
                {
                    Active = bool.Parse(s);
                    if (Active)
                    {
                        string[] paramArray = System.Configuration.ConfigurationManager.AppSettings.Get("InfoProxyWsSian").Split('|');
                        Host = paramArray[0];
                        try
                        {
                            Port = System.Convert.ToInt32(paramArray[1]);
                        }
                        catch { Port = 0; }
                    }
                }
                else { Active = false; }
            }
        }

        protected IMethodCallLogger _CallLogger;
        protected IErrorLogger _ErrorLogger;

        /// <summary>
        /// Oggetto che si occupa della registrazione degli accessi da parte degli
        /// utenti, per default gli accessi vengono registrati su un file di 
        /// testo nella stessa directory dell'assembly con nome SianWebSrv.log
        /// </summary>
        public IMethodCallLogger CallLogger
        {
            get { return _CallLogger; }
            set { _CallLogger = value; }
        }
        /// <summary>
        /// Oggetto che si occupa della registrazione delle eccezioni
        /// per default vengono scritte su un file di 
        /// testo nella stessa directory dell'assembly con nome SianWebSrv.err
        /// </summary>
        public IErrorLogger ErrorLogger
        {
            get { return _ErrorLogger; }
            set { _ErrorLogger = value; }
        }

        protected ISoapMsgLogger _SoapRequestLogger;
        protected ISoapMsgLogger _SoapResponseLogger;
        /// <summary>
        /// Oggetto che si occupa di registrare i le richieste SOAP
        /// inviate al server SIAN
        /// </summary>
        public ISoapMsgLogger SoapRequestLogger
        {
            set
            {
                _SoapRequestLogger = value;
                SianObj.SoapRequestLogger = _SoapRequestLogger;
            }
        }
        /// <summary>
        /// Oggetto che si occupa di registrare i le risposte SOAP
        /// ricevute dal server SIAN
        /// </summary>
        public ISoapMsgLogger SoapResponseLogger
        {
            set
            {
                _SoapResponseLogger = value;
                SianObj.SoapResponseLogger = _SoapResponseLogger;
            }
        }


        /// <summary>
        /// Segnatura del metodo delegato da utilizzare nel caso si voglia analizzare, ed eventualmente
        /// anche modificare, la richiesta SOAP da inviare al server SIAN prima
        /// che questa venga inoltrata al server SIAN.
        /// </summary>
        /// <param name="SoapRequest">Richiesta SOAP che sta per essere inviata</param>
        /// <seealso cref="OnSendSoapRequest"/>
        public delegate void SendSoapRequest(ref string SoapRequest);
        /// <summary>
        /// Segnatura del metodo delegato da utilizzare nel caso si voglia analizzare 
        /// la risposta ricevuta dal server SIAN ed eventualmente modificarla
        /// prima che ne venga eseguito il parsing.
        /// </summary>
        /// <param name="SoapResponse">Testo della risposta ricevuta</param>
        /// <seealso cref="OnReceiveSoapResponse"/>
        /// <remarks>
        /// N.B. la risposta potrebbe essere un errore HTML (es: 500 
        /// Internal server error) e non una risposta SOAP valida
        /// </remarks>
        public delegate void ReceiveSoapResponse(ref string SoapResponse);
        /// <summary>
        /// Metodo delegato che viene chiamato dopo avere preparato la richiesta
        /// Soap, ma prima di inviarla al server SIAN.
        /// </summary>
        public SendSoapRequest OnSendSoapRequest
        {
            set
            {
                SianObj.OnSendSoapRequest = value;
            }
        }
        /// <summary>
        /// Metodo delegato che viene chiamato dopo avere ricevuto la risposta Soap
        /// da SIAN, ma prima di eseguirne il parsing.
        /// </summary>
        public ReceiveSoapResponse OnReceiveSoapResponse
        {
            set
            {
                SianObj.OnReceiveSoapResponse = value;
            }
        }

        private void start()
        {
            _CallLogger = new TxtMethodCallLogger();
            _ErrorLogger = new TxtErrorLogger();
            SianObj = new SIANGateway();
            SoapResponseLogger = null;
            SoapRequestLogger = null;
        }

        public WebSian()
        {
            start();
            _Param.Timeout = DEFAULT_TIMEOUT;
            SianObj.Timeout = _Param.Timeout;
        }

        /// <summary>
        /// Costruttore in overload che permette di definire un insieme di impostazioni
        /// dell'ogetto personalizzate.
        /// </summary>
        /// <param name="Parametri" >Impostazioni personalizzate</param>
        public WebSian(InitParam Parametri)
        {
            start();
            this.Param = Parametri;
        }


        protected Exception AgeaError(string codRet, string msgRet)
        {
            string messaggio;
            switch (codRet.Trim())
            {
                case "016":
                    messaggio = codRet + " - dati non trovati";
                    break;
                case "017":
                    messaggio = codRet + " - identificativo non valido";
                    break;
                case "020":
                    messaggio = codRet + " - campo obbligatori";
                    break;
                case "021":
                    messaggio = codRet + " - parametri non validi o non coerenti";
                    break;
                case "031":
                    messaggio = codRet + " - fascicolo non trovato";
                    break;
                case "076":
                    messaggio = codRet + " - fascicolo non validato";
                    break;
                default:
                    messaggio = msgRet;
                    break;
            }
            Exception ex = new Exception(messaggio);
            ex.Source = "SIAN:" + codRet;
            return ex;
        }

    }

    /// <summary>
    /// Classe per l'accesso al Web Service Anagrafe Tributaria definito
    /// nel WSDL wsAnagrafeAT.wsdl
    /// </summary>
    /// <remarks>
    /// Esempio recupero dati dettaglio di un soggetto con codice fiscale "CCCGDU55S09G005M":
    /// <code>
    /// // istanzia l'oggetto AnagrafeTributaria
    /// AnagrafeTributaria ATObj = new AnagrafeTributaria();
    /// // interroga il web servise wsAnagrafeAT
    /// AnagrafeDettagliata AnagDett = ATObj.getAnagDett("UtenteSiar", "CCCGDU55S09G005M");
    /// // recupera i dati che interessano
    /// string comuneSedeLegale = AnagDett.comuneSedeLegale;
    /// DateTimeNT dataNascita = AnagDett.dataNascita;
    ///   ....
    /// // recupera i dati di una collection es: rappresentantiSocieta 
    /// if (AnagDett.rappresentantiSocieta.Count>=0){
    ///   // estrae i dati che interessano da AnagDett.rappresentantiSocieta 
    ///   RappresentanteSocieta unRappresentante = AnagDett.rappresentantiSocieta.Item(0);
    ///   ....
    /// }
    /// </code>
    /// Esempio disattivazione tracciatura errori, ridirezione Log accessi su DB Sql Server e
    /// aggiunta log dei messaggi SOAP.
    /// <code>
    /// // istanzia oggetto interrogazione anagrafe tributaria
    /// AnagrafeTributaria ATObj = new AnagrafeTributaria();
    /// // disattiva la tracciatura degli errori
    /// ATObj.ErrorLogger = null;
    /// // oppure la attiva su un file diverso quello di default (directory assembly/SianWebSrv.log)
    /// ATObj.ErrorLogger = new TxtLogger("c:\mioFile.log");
    /// // istanzia un oggetto SqlDBConfig per impostare una connessione a DB Sql
    /// SqlDBConfig DBConfig = new SqlDBConfig();
    /// DBConfig.Server = "MioServer";
    /// DBConfig.DBName = "MioDBName";
    /// DBConfig.Login = "MiaLogin";
    /// DBConfig.Password = "MiaPassword";
    /// // in alternativa si può assegnare una stringa di connessione
    /// DBConfig.ConnectionString = "Data Source=MioServer;Initial Catalog=MioDBName;User ID=MiaLogin;Password=MiaPassword";
    /// // istanzia un oggetto SqlMethodCallLogger per mandare su DB Sql Server 
    /// // la tracciatura delle chiamate ai metodi di ATObj (per default su file)
    /// ATObj.CallLogger = new SqlMethodCallLogger(DBConfig);
    /// // specifica un file alternativo in caso di fallimento della tracciature su SQL Server
    /// ATObj.CallLogger.FilePathForSQLFails = "c:\SianWebSrv.log";
    /// // Attiva la registrazione delle richieste SOAP nella directory di default [AssemblyDir/SOAPMessage]
    /// ATObj.SoapRequestLogger = new Logging.TxtSoapMsgLogger();
    /// // Attiva la registrazione delle risposte SOAP in una directory personalizzata
    /// ATObj.SoapResponseLogger = new Logging.TxtSoapMsgLogger("c:\SoapResponseDir");
    /// // continua normalmente...
    /// </code>
    /// </remarks>
    public class AnagrafeTributaria : WebSian
    {
        /// <summary>
        /// Costruttore di default oggetto per l'interrogazione del servizio web  Anagrafe Tributaria.
        /// Utilizza le impostazioni definite in SIANGateway.cs che sono valide per
        /// l'uso in esercizio.
        /// </summary>
        public AnagrafeTributaria()
            : base()
        {
            _Param.Url = SIANGateway.AnagrafeTributariaUrl;
            _Param.WebSrvUser = SIANGateway.AnagrafeTributariaLogin;
            _Param.WebSrvPassword = SIANGateway.AnagrafeTributariaPassword;
        }

        public AnagrafeTributaria(InitParam Parametri) : base(Parametri) { }

        /// <summary>
        /// Interroga l'anagrafe tributaria su un codice fiscale specifico.
        /// </summary>
        /// <param name="Login" >Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA" >Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns>Dati sintetici identificativi azienda: oggetto AnagrafeSintetica</returns>
        /// <seealso cref="getAnagDett"/>
        public AnagrafeSintetica getAnagSint(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "anagraficaSintetica";
                    dett.ServiceName = "wsAnagrafeAT";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                //SIANGateway.SianResult SoapRes = SianObj.getAnagraficaSintetica(this.Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                SIANGateway.SianResult SoapRes = SianObj.getAnagraficaSintetica02(this.Param.WebSrvUser, Param.WebSrvPassword, Login, "", "", CUAA, Param.Url);

                string r = SoapRes.RootXPath;
                SoapRes.RootXPath = "";

                string codRet = SoapRes.getValue(SoapRes.CodRetXPath);

                if (codRet == SIANGateway.retCodeOk)
                {
                    //SoapRes.RootXPath = r;
                    //XPathNavigator dati = SoapRes.getNavigator(r);
                    AnagrafeSintetica AnagSint = new AnagrafeSintetica();
                    SoapRes.RootXPath = r;
                    AnagSint.LoadFromDatiSian(SoapRes);
                    //AnagrafeSintetica AnagSint = new AnagrafeSintetica();
                    //AnagSint.LoadFromSianData(SoapRes.risposta);
                    return AnagSint;
                }
                else
                {
                    string msgRet = SoapRes.getValue(SoapRes.MsgErrPath);
                    throw AgeaError(codRet, msgRet);
                    //throw AgeaError(SoapRes.rispostaType.codRet, SoapRes.rispostaType.msgRet);
                }

            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "getAnagSint(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }

        /// <summary>
        /// Interroga l'anagrafe tributaria su un codice fiscale specifico.
        /// </summary>
        /// <param name="Login" >
        /// Identificativo utente che esegue la richiesta
        /// </param><param name="CUAA" >
        /// Codice fiscale azienda di cui si richiedono i dati
        /// </param>
        /// <returns>Dati completi identificazione azienda: oggetto AnagrafeDettagliata</returns>
        /// <seealso cref="getAnagSint"/>
        public AnagrafeDettagliata getAnagDett(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "anagraficaDettaglio";
                    dett.ServiceName = "wsAnagrafeAT";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                //SIANGateway.soapResult SoapRes = SianObj.getAnagraficaDettagliata(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                SIANGateway.SianResult SianRes = SianObj.getAnagraficaDettagliata02(Param.WebSrvUser, Param.WebSrvPassword, Login, "", "", CUAA, Param.Url);

                string r = SianRes.RootXPath;
                SianRes.RootXPath = "";

                string codRet = SianRes.getValue(SianRes.CodRetXPath);

                if (codRet == SIANGateway.retCodeOk)
                {
                    AnagrafeDettagliata AnagDett = new AnagrafeDettagliata();
                    AnagDett.LoadFromDatiSian(SianRes);
                    return AnagDett;
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath), SianRes.getValue(SianRes.MsgErrPath));
                }

                /*
                if (SoapRes.codRet == SIANGateway.retCodeOk)
                {
                    AnagrafeDettagliata AnagDett = new AnagrafeDettagliata();
                    AnagDett.LoadFromSianData(SoapRes.xmlData);
                    return AnagDett;
                }
                else
                {
                    throw AgeaError(SoapRes.codRet, SoapRes.msgRet);
                }
                 */
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "getAnagDett(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }

        public void getAnagDettEdit(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "anagraficaDettaglio";
                    dett.ServiceName = "wsAnagrafeAT";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                //SIANGateway.soapResult SoapRes = SianObj.getAnagraficaDettagliata(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                SIANGateway.SianResult SianRes = SianObj.getAnagraficaDettagliata02(Param.WebSrvUser, Param.WebSrvPassword, Login, "", "", CUAA, Param.Url);

                string r = SianRes.RootXPath;
                SianRes.RootXPath = "";

                string codRet = SianRes.getValue(SianRes.CodRetXPath);

                if (codRet == SIANGateway.retCodeOk)
                {
                    AnagrafeDettagliata AnagDett = new AnagrafeDettagliata();
                    AnagDett.LoadFromDatiSian(SianRes);

                    string pec_impresa = null, iscrizione_rea = null, iscrizione_registro_imprese = null, codice_inps = null;

                    SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
                    impresa_provider.DbProviderObj.BeginTran();
                    SiarLibrary.Impresa impresa = ScriviDatiAziendaFromSian(ref AnagDett, ref impresa_provider);

                    // da qui occorre capire se serve aggiungere altri oggetti (rappresentante legale ecc.... RIPRENDERE DA QUI

                    //  NB per i dati rapp legale prima faceva una seconda chiamata che eventualmente va fatta qui (??)


                    //int id_storico_ultimo = AggiornaStoricoImpresa(ref anag, impresa.IdImpresa, iscrizione_rea, iscrizione_registro_imprese, codice_inps, impresa_provider.DbProviderObj);
                    //int id_sede_legale_ultima = AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "S", impresa_provider.DbProviderObj);
                    //AggiornaSedeImpresa(ref anag, impresa.IdImpresa, "D", impresa_provider.DbProviderObj);
                    //int id_rapprlegale_ultimo = AggiornaPersonaXImpresa(ref anagRapprLegale, impresa.IdImpresa, "R", impresa_provider.DbProviderObj);

                    impresa.DataInizioAttivita = DateTime.Now;
                    impresa_provider.Save(impresa);

                    impresa_provider.DbProviderObj.Commit();
                }
                else
                {
                    ScriviDatiAziendaEdit(CUAA);
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "getAnagDett(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;

            }
        }

        private SiarLibrary.Impresa ScriviDatiAziendaEdit(string codice_fiscale)
        {
            SiarBLL.ImpresaCollectionProvider impresa_provider = new SiarBLL.ImpresaCollectionProvider();
            SiarLibrary.Impresa impresa = new SiarLibrary.Impresa();

            impresa.CodiceFiscale = codice_fiscale;
            impresa.Cuaa = codice_fiscale;
            impresa.DataInizioAttivita = DateTime.Now;
            impresa_provider.Save(impresa);

            return impresa;
        }

        private SiarLibrary.Impresa ScriviDatiAziendaFromSian(ref AnagrafeDettagliata anagrafe, ref SiarBLL.ImpresaCollectionProvider impresa_provider)
        {
            SiarLibrary.ImpresaCollection ic = impresa_provider.GetImpresaSenzaStoricoByCuaa(anagrafe.codiceFiscale);
            SiarLibrary.Impresa impresa = null;
            foreach (SiarLibrary.Impresa i in ic)
            {
                if (anagrafe.codiceFiscale == i.Cuaa && (anagrafe.partitaIva == i.CodiceFiscale || i.CodiceFiscale == "00000000000"))
                {
                    if (i.CodiceFiscale == "00000000000")
                    {
                        i.CodiceFiscale = anagrafe.partitaIva;
                        impresa_provider.Save(i);
                    }
                    impresa = i;
                    break;
                }
            }
            //se non trovo impresa la cerco per partita iva
            if (impresa == null)
            {
                SiarLibrary.ImpresaCollection ic_pi = impresa_provider.GetImpresaSenzaStoricoByCuaa(anagrafe.partitaIva);
                //SiarLibrary.Impresa impresa = null;
                foreach (SiarLibrary.Impresa i in ic_pi)
                {
                    if ((anagrafe.codiceFiscale == i.Cuaa || anagrafe.partitaIva == i.Cuaa) && (anagrafe.partitaIva == i.CodiceFiscale || i.CodiceFiscale == "00000000000"))
                    {
                        if (i.CodiceFiscale == "00000000000")
                        {
                            i.CodiceFiscale = anagrafe.partitaIva;
                            impresa_provider.Save(i);
                        }
                        impresa = i;
                        break;
                    }
                }
            }


            if (impresa == null)
            {
                impresa = new SiarLibrary.Impresa();
            }
            impresa.CodiceFiscale = (string.IsNullOrEmpty(anagrafe.partitaIva) ? anagrafe.codiceFiscale : anagrafe.partitaIva);
            impresa.Cuaa = anagrafe.codiceFiscale;
            impresa.DataInizioAttivita = anagrafe.dataInizioAttivita;
            impresa_provider.Save(impresa);

            return impresa;
        }
    }

    /// <summary>
    /// Classe per l'accesso al Web Service Fascicolo Aziendale definito
    /// nel WSDL wsAgeaToOpr.wsdl
    /// </summary>
    /// <remarks>
    /// Esempio recupero dati anagrafici soggetto con codice fiscale "xxxxxxxxxxxxxxxx":
    /// <code>
    /// // istanzia l'oggetto FascicoloAziendale
    /// FascicoloAziendale Fascicolo = new FascicoloAziendale();
    /// // interroga il web servise wsAgeaToOpr
    /// RespAnagFascicolo AngrafeFascicolo = Fascicolo.trovaFascicolo("UtenteSiar", "xxxxxxxxxxxxxxxx");
    /// // recupera i dati 
    /// string CodComuNasc = AngrafeFascicolo.comuneNascitaPF;
    /// string RagioneSociale = AnagDett.denominazione;
    /// </code>
    /// Esempio recupero terreni azienda con codice fiscale "CCCGDU55S09G005M":
    /// <code>
    /// // istanzia l'oggetto FascicoloAziendale
    /// FascicoloAziendale Fascicolo = new FascicoloAziendale();
    /// // interroga il web servise wsAgeaToOpr
    /// CollOfTerritorio Terreni = Fascicolo.leggiTerritorio("UtenteSiar", "CCCGDU55S09G005M");
    /// // se vi sono terreni li legge in sequenza 
    /// int Superficie;
    /// if (Terreni.count > 0){
    ///   for(int i=0; i<=Terreni.count-1; i++){
    ///     Territorio Appezzamento = Terreni.Item(i);
    ///     Superficie = Appezzamento.SuperficieCondotta;
    ///     // fai qualcosa con Superficie
    ///   }
    /// }
    /// </code>
    /// Esempio disattivazione tracciatura errori, ridirezione Log accessi su DB Sql Server e
    /// aggiunta log dei messaggi SOAP.
    /// <code>
    /// // istanzia oggetto interrogazione Fascicolo
    /// AnagrafeTributaria ATObj = new FascicoloAziendale();
    /// // disattiva la tracciatura degli errori
    /// ATObj.ErrorLogger = null;
    /// // oppure la attiva su un file diverso quello di default (directory assembly/SianWebSrv.log)
    /// ATObj.ErrorLogger = new TxtLogger("c:\mioFile.log");
    /// // istanzia un oggetto SqlDBConfig per impostare una connessione a DB Sql
    /// SqlDBConfig DBConfig = new SqlDBConfig();
    /// DBConfig.Server = "MioServer";
    /// DBConfig.DBName = "MioDBName";
    /// DBConfig.Login = "MiaLogin";
    /// DBConfig.Password = "MiaPassword";
    /// // in alternativa si può assegnare una stringa di connessione
    /// DBConfig.ConnectionString = "Data Source=MioServer;Initial Catalog=MioDBName;User ID=MiaLogin;Password=MiaPassword";
    /// // istanzia un oggetto SqlMethodCallLogger per mandare su DB Sql Server 
    /// // la tracciatura delle chiamate ai metodi di ATObj (per default su file)
    /// ATObj.CallLogger = new SqlMethodCallLogger(DBConfig);
    /// // specifica un file alternativo in caso di fallimento della tracciature su SQL Server
    /// ATObj.CallLogger.FilePathForSQLFails = "c:\SianWebSrv.log";
    /// // Attiva la registrazione delle richieste SOAP nella directory di default [AssemblyDir/SOAPMessage]
    /// ATObj.SoapRequestLogger = new Logging.TxtSoapMsgLogger();
    /// // Attiva la registrazione delle risposte SOAP in una directory personalizzata
    /// ATObj.SoapResponseLogger = new Logging.TxtSoapMsgLogger("c:\SoapResponseDir");
    /// // continua normalmente...
    /// </code>
    /// </remarks>
    public class FascicoloAziendale : WebSian
    {
        private InitParam ParamAllevamenti;

        public FascicoloAziendale()
            : base()
        {
            _Param.Url = SIANGateway.Fascicolo20Url;
            _Param.WebSrvUser = SIANGateway.Fascicolo20Login;
            _Param.WebSrvPassword = SIANGateway.Fascicolo20Password;
            // gli allevamenti stanno da un'altra parte
            ParamAllevamenti.Url = SIANGateway.InterscambioWSUrl;
            ParamAllevamenti.WebSrvUser = SIANGateway.InterscambioWSLogin;
            ParamAllevamenti.WebSrvPassword = SIANGateway.InterscambioWSPassword;
        }

        public FascicoloAziendale(InitParam Parametri)
            : base(Parametri)
        {
            ParamAllevamenti = Parametri;
        }

        public FascicoloAziendale(InitParam Parametri, InitParam ParametriAllevamenti)
            : base(Parametri)
        {
            ParamAllevamenti = ParametriAllevamenti;
        }

        /// <summary>
        /// Restituisce la sezione anagrafica del fascicolo SIAN
        /// </summary>
        /// <param name="Login" >Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA" >Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns>Dati angarafici presenti nel fascolo: oggetto RespAnagFascicolo</returns>
        /// <seealso cref="RespAnagFascicolo"/>
        public RespAnagFascicolo trovaFascicolo(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "TrovaFascicolo";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.TrovaFascicolo20(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);

                //SIANGateway.soapResult SoapRes = SianObj.trovaFascicolo(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new RespAnagFascicolo(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath), SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                if (_ErrorLogger != null)
                {
                    string note = "trovaFascicolo(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                throw e;
            }
        }

        /// <summary>
        /// Restituisce la sezione anagrafica del fascicolo SIAN versione Aggiornata il 24/3/2009,
        /// se il fascicolo non è validato restitutisce un errore
        /// </summary>
        /// <param name="Login" >Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA" >Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns>Dati angarafici presenti nel fascolo: oggetto RespAnagFascicolo</returns>
        /// <seealso cref="RespAnagFascicolo"/>
        public RespAnagFascicolo2 AnagraficaAziendaFS10(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "AnagraficaAziendaFS10";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.AnagraficaAziendaFS10(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);

                //SIANGateway.soapResult SoapRes = SianObj.trovaFascicolo(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new RespAnagFascicolo2(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath), SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                if (_ErrorLogger != null)
                {
                    string note = "AnagraficaAziendaFS10(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                throw e;
            }
        }

        /// <summary>
        /// DEPRECATO Restituisce la lista dei terreni dell'azienda presenti nel fascicolo SIAN
        /// </summary>
        /// <param name="Login" >
        /// Identificativo utente che esegue la richiesta
        /// </param><param name="CUAA" >
        /// Codice fiscale azienda di cui si richiedono i dati
        /// </param>
        /// <returns>
        /// Elenco dei terreni dell'azienda e relativi utilizzi
        /// </returns>
        public CollOfTerritorio leggiTerritorio(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiTerritorio";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiTerritorio20(Param.WebSrvUser, Param.WebSrvPassword, CUAA, Param.Url);
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new CollOfTerritorio(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "leggiTerritorio(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }

        /// <summary>
        /// Restituisce gli allevamenti presenti nel fascicolo SIAN
        /// </summary>
        /// <param name="Login" >
        /// Identificativo utente che esegue la richiesta
        /// </param>
        /// <param name="CUAA" >
        /// Codice fiscale azienda di cui si richiedono i dati
        /// </param>
        /// <returns>
        /// Elenco degli allevamenti presenti nel fascolo
        /// </returns>
        public CollOfAllevamento leggiAllevamenti(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiAllevamenti";
                    dett.ServiceName = "InterscambioWS";
                    dett.Params = "CUAA=" + CUAA + "; Data=" + DateTime.Now.ToString("dd/MM/yyyy"); ;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.leggiAllevamenti2(
                       ParamAllevamenti.WebSrvUser,
                       ParamAllevamenti.WebSrvPassword,
                       CUAA,
                       DateTime.Now,
                       ParamAllevamenti.Url
                    );
                // controllo se c'è un errore
                string ErrCode = SianRes.getValue(SianRes.CodRetXPath, false);
                string ErrMessage = SianRes.getValue(SianRes.MsgErrPath, false);

                if ((ErrCode != "") || (ErrMessage != ""))
                {
                    throw AgeaError(ErrCode, ErrMessage);
                }
                else
                {
                    SianRes.RootXPath = SIANGateway.XPathInterscambioWS.Response.Root +
                                          SIANGateway.XPathInterscambioWS.Response.Warning.Root +
                                          SIANGateway.XPathInterscambioWS.Response.Warning.Error.Root
                                          ;
                    SianRes.CodRetXPath = SIANGateway.XPathInterscambioWS.Response.Warning.Error.id;
                    SianRes.MsgErrPath = SIANGateway.XPathInterscambioWS.Response.Warning.Error.des;
                    try
                    {
                        ErrCode = SianRes.getValue(SianRes.CodRetXPath);
                        ErrMessage = SianRes.getValue(SianRes.MsgErrPath);
                    }
                    catch
                    {
                        throw AgeaError("00", "[leggiAllevamenti] La risposta del server SIAN non ha il formato previsto.");
                    }
                    if ((ErrCode == "") && (ErrMessage == ""))
                    {
                        SianRes.RootXPath = SIANGateway.XPathInterscambioWS.Response.Root;
                        return new CollOfAllevamento(SianRes);
                    }
                    else
                    {
                        throw AgeaError(ErrCode, ErrMessage);
                    }
                }

                /*
                SIANGateway.soapResult SoapRes = SianObj.leggiAllevamenti(
                       ParamAllevamenti.WebSrvUser,
                       ParamAllevamenti.WebSrvPassword,
                       CUAA,
                       ParamAllevamenti.Url
                    );
                if (SoapRes.codRet == SIANGateway.retCodeOk)
                {
                    return new CollOfAllevamento(SoapRes.xmlData);
                }
                else
                {
                    throw AgeaError(SoapRes.codRet, SoapRes.msgRet);
                }
                */
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "LeggiAllevamenti(" + Login + "," + CUAA +
                                  "," + DateTime.Now.ToString("dd/MM/yyyy") + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }

        /// <summary>
        /// Restituisce le quote latte della'zienda registrate nel fascicolo SIAN
        /// </summary>
        /// <param name="Login" >
        /// Identificativo utente che esegue la richiesta
        /// </param>
        /// <param name="CUAA" >
        /// Codice fiscale azienda di cui si richiedono i dati
        /// </param>
        /// <param name="Anno" >
        /// Anno riferimento campagna lattiera
        /// </param>
        /// <returns>
        /// Elenco quote latte dell'azienda
        /// </returns>
        public CollOfQuoteLatte quoteLatte(string Login, string CUAA, int Anno)
        {
            try
            {
                #region Rregistrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "quoteLatte";
                    dett.ServiceName = "wsAgeaToOpr";
                    dett.Params = "CUAA=" + CUAA + "; ANNO=" + System.Convert.ToString(Anno);
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                String _Anno = System.Convert.ToString(Anno);
                SIANGateway.soapResult SoapRes = SianObj.quoteLatte(Param.WebSrvUser, Param.WebSrvPassword, CUAA, _Anno, Param.Url);
                if (SoapRes.codRet == SIANGateway.retCodeOk)
                {
                    return new CollOfQuoteLatte(SoapRes.xmlData);
                }
                else
                {
                    throw AgeaError(SoapRes.codRet, SoapRes.msgRet);
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "quoteLatte(" + Login + "," + CUAA + "," +
                                  System.Convert.ToString(Anno) + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }
        /// <summary>
        /// Restituisce la lista delle particelle catasttali utilizzate dall'azienda
        /// con l'indicazione del macrouso. Sostituisce LeggiConsistenzaFS20.
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TConsistenza LeggiConsistenzaFS50(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiConsistenzaFS5.0";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiConsistenzaFS50(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TConsistenza(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiConsistenzaFS5.0(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle particelle catasttali utilizzate dall'azienda
        /// con l'indicazione del macrouso. Sostituisce leggiTerritorio.
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TConsistenza LeggiConsistenzaFS20(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiConsistenzaFS2.0";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiConsistenzaFS20(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TConsistenza(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiConsistenzaFS2.0(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle particelle catasttali utilizzate dall'azienda
        /// con l'indicazione del macrouso. Sostituisce LeggiConsistenzaFS20, ma non capisco che differenza c'è.
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TConsistenza ConsistenzaFS10(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "ConsistenzaFS1.0";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.ConsistenzaAziendaFS10(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TConsistenza(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "ConsistenzaFS10(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle particelle catasttali utilizzate dall'azienda
        /// con l'indicazione del macrouso, ma solo se il fascicolo è validato
        /// altrimenti restituisce un errore.
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TConsistenza ConsistenzaAziendaFS10(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "ConsistenzaAziendaFS1.0";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.ConsistenzaAziendaFS10(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TConsistenza(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "ConsistenzaAziendaFS1.0(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }



        /// <summary>
        /// Restituisce la lista delle particelle catasttali utilizzate dall'azienda
        /// con l'indicazione del dettaglio della/delle colture. Sostituisce leggiTerritorio.
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <param name="Anno">Anno agrario di riferimento</param>
        /// <returns></returns>
        public TPianoColturale LeggiPianoColturale(string Login, string CUAA, int Anno)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiPianoColturale";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA + "; Anno=" + Anno.ToString();
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiPianoColturale(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Anno.ToString(),
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TPianoColturale(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiPianoColturale(" + Login + "," + CUAA + "," + Anno.ToString() + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }


        /// <summary>
        /// Restituisce i dati completi della particella catastale richiesta 
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="ISTATProv">ISTAT provincia</param>
        /// <param name="ISTATCom">ISTAT comune</param>
        /// <param name="sezione">sezione catastale, non obbligatorio</param>
        /// <param name="foglio">foglio catastale</param>
        /// <param name="particella">foglio catastale</param>
        /// <param name="subalterno">foglio catastale, non obbligatorio</param>
        /// <returns></returns>
        public Territorio TrovaParticella(string Login
                    , string ISTATProv, string ISTATCom, string sezione, string foglio
                    , string particella, string subalterno)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "TrovaParticella";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "ISTATProv=" + ISTATProv + "; ISTATCom=" + ISTATCom +
                                  "sezione=" + sezione + "; foglio=" + foglio +
                                  "; particella=" + particella + "; subalterno=" + subalterno;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.TrovaParticella(
                         Param.WebSrvUser, Param.WebSrvPassword, Param.Url
                       , ISTATProv, ISTATCom, sezione, foglio, particella, subalterno
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    SianRes.RootXPath = SIANGateway.XPathFascicolo20.Root;

                    XPathNodeIterator Terreno = SianRes.getIterator(SIANGateway.XPathFascicolo20.risposta2.Root);
                    Terreno.MoveNext();
                    return new Territorio(SianRes, Terreno, true);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "TrovaParticella(" + Login + "," + ISTATProv + "," + ISTATCom +
                                  "," + sezione + "," + foglio + "," + particella +
                                  "," + subalterno + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle macchine presenti nel fascicolo
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TMacchine LeggiMacchine(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiMacchine";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiMacchine(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TMacchine(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiMacchine(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista dei fabbricati presenti nel fascicolo
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TFabbricati LeggiFabbricati(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiFabbricati";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiFabbricati(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TFabbricati(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiFabbricati(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle tipologie di manodopera utilizzate
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TClassiManodopera LeggiManodopera(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiManodopera";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiManodopera(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TClassiManodopera(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiManodopera(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista degli impegni cui è sottoposta l'azienda
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TCondizionalita LeggiCondizionalita(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiCondizionalita";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiCondizionalita(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TCondizionalita(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiCondizionalita(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce la lista delle anomalie segnalate da SIAN
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public TSegnalazioni LeggiSegnalazioni(string Login, string CUAA)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiSegnalazioni";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiSegnalazioni(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    return new TSegnalazioni(SianRes);
                }
                else
                {
                    throw AgeaError(SianRes.getValue(SianRes.CodRetXPath),
                                    SianRes.getValue(SianRes.MsgErrPath));
                }
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtim
                if (_ErrorLogger != null)
                {
                    string note = "LeggiSegnalazioni(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }

        }

        /// <summary>
        /// Restituisce l'elenco dei conti correnti dell'impresa
        /// creata il 17/09/2014
        /// </summary>
        /// <param name="Login">Identificativo utente che esegue la richiesta</param>
        /// <param name="CUAA">Codice fiscale azienda di cui si richiedono i dati</param>
        /// <returns></returns>
        public SiarLibrary.ContoCorrenteCollection LeggiContiCorrenti(string Login, string CUAA)
        {
            try
            {
                SiarLibrary.ContoCorrenteCollection cc = new SiarLibrary.ContoCorrenteCollection();
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "LeggiContiCorrenti";
                    dett.ServiceName = "OprFascicolo.wsdl";
                    dett.Params = "CUAA=" + CUAA;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }
                SIANGateway.SianResult SianRes = SianObj.LeggiContiCorrenti(
                        Param.WebSrvUser,
                        Param.WebSrvPassword,
                        CUAA,
                        Param.Url
                    );
                if (SianRes.getValue(SianRes.CodRetXPath) == SIANGateway.retCodeOk)
                {
                    XPathNodeIterator ni = SianRes.getIterator(SIANGateway.XPathFascicolo20.ISWSContoCorrente.Root);
                    for (int i = 1; i <= ni.Count; ++i)
                    {
                        ni.MoveNext();
                        SiarLibrary.ContoCorrente c = new SiarLibrary.ContoCorrente();
                        string conto_raw = SianRes.getValue(SIANGateway.XPathFascicolo20.ISWSContoCorrente.ContoCorrente, ni, false);
                        if (string.IsNullOrEmpty(conto_raw) || conto_raw.Length < 18)
                            throw AgeaError("ContoCorrente", "Almeno uno dei conti correnti dell'impresa non è valido.");
                        c.CodPaese = conto_raw.Substring(0, 2);
                        c.CinEuro = conto_raw.Substring(2, 2);
                        c.Cin = conto_raw.Substring(4, 1);
                        c.Abi = conto_raw.Substring(5, 5);
                        c.Cab = conto_raw.Substring(10, 5);
                        c.Numero = conto_raw.Substring(15);
                        c.DataInizioValidita = DateTime.Now;
                        c.Note = "SCARICATO_DA_AGEA";
                        c.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(SianRes.getValue(SIANGateway.XPathFascicolo20.ISWSContoCorrente.Data_fine, ni, false));
                        cc.Add(c);
                    }
                }
                else throw AgeaError(SianRes.getValue(SianRes.CodRetXPath), SianRes.getValue(SianRes.MsgErrPath));
                return cc;
            }
            catch (Exception e)
            {
                #region Registrazione errori a runtime
                if (_ErrorLogger != null)
                {
                    string note = "LeggiContiCorrenti(" + Login + "," + CUAA + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                #endregion
                throw e;
            }
        }
    }

    /// <summary>
    /// Classe per l'invio di richieste SOAP ai web service AGEA
    /// </summary>
    public class PostinoSOAP : WebSian
    {
        public PostinoSOAP() : base() { }

        /// <summary>
        /// Struttura delle segnalazioni di errore restituite dal web service OCM Zucchero 2009
        /// </summary>
        public struct Z2009Errore
        {
            /// Oggetto SOAP su cui si è verificato l'errore
            public string NomeOggetto;
            /// Nome del campo su cui si è verificato l'errore
            public string CampoErrato;
            /// Codice/Tipo dell'errore
            public string TipoErrore;
            /// descrizione estesa dell'errore
            public string DescErrore;
        }

        public class Z2009ErroriList : System.Collections.CollectionBase
        {
            public void Add(Z2009Errore Errore)
            {
                List.Add(Errore);
            }
            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                    throw new System.Exception("Collection index out of range");
                }
                else
                {
                    List.RemoveAt(index);
                }
            }
            public Z2009Errore Item(int Index)
            {
                return (Z2009Errore)List[Index];
            }
        }

        /// <summary>
        /// Struttura della risposta del Web Service OCM Zucchero 2009
        /// </summary>
        public struct Z2009Risposta
        {
            /// CUAA domanda inviata
            public string cuaa;
            /// Codice assegnato alla domanda dall'organismo pagatore (Codice AGEA)
            public string IdDomaOp;
            /// codice a barre della domanda 
            public string CodiBarrCode;
            /// aggiunto versione 2.0
            public string TotaImpoRich;
            /// aggiunto versione 2.0
            public string TotaImpoConcIstr;
            /// aggiunto versione 2.0
            public string TotaImpoConcRevi;
            // /// esito dell'invio dati
            // public string esito; lo hanno eliminato versione 2.0
            /// lista dlle segnalazioni di errore
            public Z2009ErroriList Errori;
            /// documento Xml contenente la risposta SOAP restituita dal server AGEA
            public XmlDocument RispostaSOAP;
        }

        /// <summary>
        /// Metodo di invio dati al Web Service OCM Zucchero, con parametri preimpostati per server AGEA di esercizio
        /// </summary>
        /// <param name="Domanda">stringa XML da inserire nel SOAP envelope da inviare al web service</param>
        /// <param name="UtenteSiar">Login utente per LOG</param>
        /// <returns>Restituisce un oggetto contenente l'esito dell'operazione ed eventuali segnalazioni di errore <seealso cref="Z2009Risposta"/></returns>
        /// <example>
        /// PostinoSOAP Z2009 = new PostinoSOAP();
        /// // se serve creo un proxy per uscire su Internet
        /// Z2009.Proxy = new WebSian.ProxyWebConfig();
        /// Z2009.Proxy.Host = "proxisa";
        /// Z2009.Proxy.Port = 8080;
        /// Z2009.Proxy.Active = true;
        /// // se serve attiva la registrazione dei messaggi SOAP su file
        /// SianObj.SoapResponseLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// SianObj.SoapRequestLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// // invia la richiesta al server AGEA
        /// PostinoSOAP.Z2009Risposta Risultato = Z2009.SpedisciDomandaZucchero2009(DomandaXml, "XXXXXXnnXnnXnnnX");
        /// </example>
        public Z2009Risposta SpedisciDomandaZucchero2009(string Domanda, string UtenteSiar)
        {
            InitParam paramDefault = new InitParam();
            paramDefault.Url = SIANGateway.ZuccheroUrl;
            paramDefault.WebSrvUser = SIANGateway.ZuccheroLogin;
            paramDefault.WebSrvPassword = SIANGateway.ZuccheroPassword;
            return SpedisciDomandaZucchero2009(Domanda, UtenteSiar, paramDefault);
        }

        /// <summary>
        /// Metodo di invio dati al Web Service OCM Zucchero, richiede i parametri utente/password/url server AGEA
        /// </summary>
        /// <param name="Domanda">stringa XML da inserire nel SOAP envelope da inviare al web service</param>
        /// <param name="UtenteSiar">Login utente per LOG</param>
        /// <param name="Parametri">Oggetto contenente utente/password/url per invio richiesta SOAP</param>
        /// <returns>Restituisce un oggetto contenente l'esito dell'operazione ed eventuali segnalazioni di errore <seealso cref="Z2009Risposta"/></returns>
        /// <example>
        /// PostinoSOAP Z2009 = new PostinoSOAP();
        /// // se serve creo un proxy per uscire su Internet
        /// Z2009.Proxy = new WebSian.ProxyWebConfig();
        /// Z2009.Proxy.Host = "proxisa";
        /// Z2009.Proxy.Port = 8080;
        /// Z2009.Proxy.Active = true;
        /// // impostare parametri ad esempoio per ambiente di test
        /// SianWebSrv.WebSian.InitParam Param = new WebSian.InitParam();
        /// Param.Url = "http://andromeda.sian.it/wspdd/services/WSZuccheroASZ";
        /// Param.WebSrvUser = "regimarche";
        /// Param.WebSrvPassword = "1rrmrc1";
        /// // se serve attiva la registrazione dei messaggi SOAP su file
        /// SianObj.SoapResponseLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// SianObj.SoapRequestLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// // invia la richiesta al server AGEA
        /// PostinoSOAP.Z2009Risposta Risultato = Z2009.SpedisciDomandaZucchero2009(DomandaXml, "UtenteInChiaroPerLog", Param);
        /// </example>
        public Z2009Risposta SpedisciDomandaZucchero2009(string Domanda, string UtenteSiar, InitParam Parametri)
        {
            XmlDocument Risposta = SpedisciDomanda(Domanda, UtenteSiar, Parametri, "ScambiaDomandaAiutoASZ", "WSZuccheroASZ");
            //XmlDocument Risposta = SpedisciDomanda(Domanda, UtenteSiar, Parametri, "ScambiaDomandaZuccheroASZ", "WSZuccheroASZ");
            // creo gli elementi che mi servono per esplorare la risposta SOAP
            XPathNavigator Navigator = Risposta.CreateNavigator();
            XPathExpression XPathExpr;

            #region vedo se c'è un elemento fault
            // carico i name space di default Zucchero2009
            XmlNamespaceManager nsManagerFault = new XmlNamespaceManager(Risposta.NameTable);
            System.Collections.Specialized.StringDictionary NameSpaceListFault = SIANGateway.XpathZucchero2009.Fault.GetNameSpaceList();
            foreach (System.Collections.DictionaryEntry Entry in NameSpaceListFault)
            {
                nsManagerFault.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }
            //  
            XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.Fault.Root, nsManagerFault);
            XPathNodeIterator FaultNi = Navigator.Select(XPathExpr);
            if (FaultNi.Count == 1)
            {
                string faultcode, faultstring, faultactor;
                // estraggo i valori
                FaultNi.MoveNext();
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.Fault.faultcode, nsManagerFault);
                XPathNodeIterator xpnfaultcode = FaultNi.Current.Select(XPathExpr);
                if (xpnfaultcode.Count == 1)
                {
                    xpnfaultcode.MoveNext();
                    faultcode = xpnfaultcode.Current.Value;
                }
                else
                {
                    throw new Exception("SOFITER ha restituito un elemento Fault contenente più di un elemento faultcode");
                }
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.Fault.faultstring, nsManagerFault);
                XPathNodeIterator xpnfaultstring = FaultNi.Current.Select(XPathExpr);
                if (xpnfaultstring.Count == 1)
                {
                    xpnfaultstring.MoveNext();
                    faultstring = xpnfaultstring.Current.Value;
                }
                else
                {
                    throw new Exception("SOFITER ha restituito un elemento Fault contenente più di un elemento faultstring");
                }
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.Fault.faultactor, nsManagerFault);
                XPathNodeIterator xpnfaultactor = FaultNi.Current.Select(XPathExpr);
                if (xpnfaultactor.Count == 1)
                {
                    xpnfaultactor.MoveNext();
                    faultactor = xpnfaultactor.Current.Value;
                }
                else
                {
                    throw new Exception("SOFITER ha restituito un elemento Fault contenente più di un elemento faultactor");
                }
                // trovato elemento fault regolare con codice e descrizione AGEA
                throw AgeaError(faultcode, faultstring + "; faultactor=" + faultactor);
            }
            if (FaultNi.Count > 1)
            {
                throw new Exception("SOFITER ha restituito più di un elemento Fault");
            }
            #endregion

            Z2009Risposta Risultato = new Z2009Risposta();

            #region vedo se c'è un elemento ResponseASRDomanda
            XmlNamespaceManager nsManagerResponseASR = new XmlNamespaceManager(Risposta.NameTable);
            System.Collections.Specialized.StringDictionary NameSpaceListResponseASR = SIANGateway.XpathZucchero2009.ResponseASRDomanda.GetNameSpaceList();
            foreach (System.Collections.DictionaryEntry Entry in NameSpaceListResponseASR)
            {
                nsManagerResponseASR.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }
            //  
            XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.Root, nsManagerResponseASR);
            XPathNodeIterator ResponseASRNi = Navigator.Select(XPathExpr);
            if (ResponseASRNi.Count == 1)
            {
                // si dovrebbe verificare solo per errori gravi... forse!3
                ResponseASRNi.MoveNext();
                Risultato.RispostaSOAP = Risposta;
                // CUAA
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.CUAAType.Root + "/" + SIANGateway.XpathZucchero2009.ResponseASRDomanda.CUAAType.CodiceFiscalePersonaFisica, nsManagerResponseASR);
                XPathNodeIterator xpCuaaPF = ResponseASRNi.Current.Select(XPathExpr);
                if (xpCuaaPF.Count == 1)
                {
                    xpCuaaPF.MoveNext();
                    Risultato.cuaa = xpCuaaPF.Current.Value;
                    // se non c'è chi se ne frega
                }
                // IdDoma
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.IdDomaOp, nsManagerResponseASR);
                XPathNodeIterator xpIdDomaOp = ResponseASRNi.Current.Select(XPathExpr);
                if (xpIdDomaOp.Count == 1)
                {
                    xpIdDomaOp.MoveNext();
                    Risultato.IdDomaOp = xpIdDomaOp.Current.Value;
                    // se non c'è chi se ne frega
                }
                // errori 
                Risultato.Errori = new Z2009ErroriList();
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.ISWSErroriASZ.Root, nsManagerResponseASR);
                XPathNodeIterator xpErrori = ResponseASRNi.Current.Select(XPathExpr);
                XPathExpression XPathExprNomeOggetto = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.ISWSErroriASZ.NomeOggetto, nsManagerResponseASR);
                XPathExpression XPathExprCampoErrato = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.ISWSErroriASZ.CampoErrato, nsManagerResponseASR);
                XPathExpression XPathExprTipoErrore = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.ISWSErroriASZ.TipoErrore, nsManagerResponseASR);
                XPathExpression XPathExprDescErrore = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ResponseASRDomanda.ISWSErroriASZ.DescErrore, nsManagerResponseASR);
                XPathNodeIterator NiNomeOggetto;
                XPathNodeIterator NiCampoErrato;
                XPathNodeIterator NiTipoErrore;
                XPathNodeIterator NiDescErrore;
                if (xpErrori.Count >= 1)
                {
                    Z2009Errore ErroreCorrene;
                    for (int i = 1; i <= xpErrori.Count; ++i)
                    {
                        ErroreCorrene = new Z2009Errore();
                        xpErrori.MoveNext();
                        NiNomeOggetto = xpErrori.Current.Select(XPathExprNomeOggetto);
                        if (NiNomeOggetto.Count == 1)
                        {
                            NiNomeOggetto.MoveNext();
                            ErroreCorrene.NomeOggetto = NiNomeOggetto.Current.Value;
                        }
                        NiCampoErrato = xpErrori.Current.Select(XPathExprCampoErrato);
                        if (NiCampoErrato.Count == 1)
                        {
                            NiCampoErrato.MoveNext();
                            ErroreCorrene.CampoErrato = NiCampoErrato.Current.Value;
                        }
                        NiTipoErrore = xpErrori.Current.Select(XPathExprTipoErrore);
                        if (NiTipoErrore.Count == 1)
                        {
                            NiTipoErrore.MoveNext();
                            ErroreCorrene.TipoErrore = NiTipoErrore.Current.Value;
                        }
                        NiDescErrore = xpErrori.Current.Select(XPathExprDescErrore);
                        if (NiDescErrore.Count == 1)
                        {
                            NiDescErrore.MoveNext();
                            ErroreCorrene.DescErrore = NiDescErrore.Current.Value;
                        }
                        Risultato.Errori.Add(ErroreCorrene);
                    }
                }
                return Risultato;
            }
            if (ResponseASRNi.Count > 1)
            {
                throw new Exception("SOFITER ha restituito più di un elemento ResponseASR");
            }
            #endregion

            #region Risposta standard zucchero
            XmlNamespaceManager nsManagerResponseASZ = new XmlNamespaceManager(Risposta.NameTable);
            System.Collections.Specialized.StringDictionary NameSpaceListResponseASZ = SIANGateway.XpathZucchero2009.ISWSResponseASZ.GetNameSpaceList();
            foreach (System.Collections.DictionaryEntry Entry in NameSpaceListResponseASZ)
            {
                nsManagerResponseASZ.AddNamespace(Entry.Key.ToString(), Entry.Value.ToString());
            }
            //  
            XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.Root, nsManagerResponseASZ);
            XPathNodeIterator ResponseASZNi = Navigator.Select(XPathExpr);
            if (ResponseASZNi.Count == 1)
            {
                // estraggo i valori
                ResponseASZNi.MoveNext();
                Risultato.RispostaSOAP = Risposta;
                // CUAA
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.CUAAType.Root + "/" + SIANGateway.XpathZucchero2009.ISWSResponseASZ.CUAAType.CodiceFiscalePersonaFisica, nsManagerResponseASZ);
                XPathNodeIterator xpCuaaPF = ResponseASZNi.Current.Select(XPathExpr);
                if (xpCuaaPF.Count == 1)
                {
                    xpCuaaPF.MoveNext();
                    Risultato.cuaa = xpCuaaPF.Current.Value;
                }
                else
                {
                    XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.CUAAType.Root + "/" + SIANGateway.XpathZucchero2009.ISWSResponseASZ.CUAAType.CodiceFiscalePersonaGiuridica, nsManagerResponseASZ);
                    XPathNodeIterator xpCuaaPG = ResponseASZNi.Current.Select(XPathExpr);
                    if (xpCuaaPG.Count == 1)
                    {
                        xpCuaaPG.MoveNext();
                        Risultato.cuaa = xpCuaaPG.Current.Value;
                    }
                    //else
                    //{
                    //    throw new Exception("SOFITER ha restituito un elemento ResponseASZ che non contiene il CUAA nel formato corretto");
                    //}
                }
                // IdDoma
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.IdDomaOp, nsManagerResponseASZ);
                XPathNodeIterator xpIdDomaOp = ResponseASZNi.Current.Select(XPathExpr);
                if (xpIdDomaOp.Count == 1)
                {
                    xpIdDomaOp.MoveNext();
                    Risultato.IdDomaOp = xpIdDomaOp.Current.Value;
                }
                //else
                //{
                //    throw new Exception("SOFITER ha restituito un elemento ResponseASZ che non contiene IdDomaOp nel formato corretto");
                //}
                // CodiBarrCode 
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.CodiBarrCode, nsManagerResponseASZ);
                XPathNodeIterator xpCodiBarrCode = ResponseASZNi.Current.Select(XPathExpr);
                if (xpCodiBarrCode.Count == 1)
                {
                    xpCodiBarrCode.MoveNext();
                    Risultato.CodiBarrCode = xpCodiBarrCode.Current.Value;
                }
                else
                {
                    Risultato.CodiBarrCode = ""; // se non c'è lo ignoro e amen
                }

                // TotaImpoRich  aggiunto in versione 2.0
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.TotaImpoRich, nsManagerResponseASZ);
                XPathNodeIterator xpTotaImpoRich = ResponseASZNi.Current.Select(XPathExpr);
                if (xpTotaImpoRich.Count == 1)
                {
                    xpTotaImpoRich.MoveNext();
                    Risultato.TotaImpoRich = xpTotaImpoRich.Current.Value;
                }
                else
                {
                    Risultato.TotaImpoRich = ""; // se non c'è lo ignoro e amen
                }
                // TotaImpoConcIstr  aggiunto in versione 2.0
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.TotaImpoConcIstr, nsManagerResponseASZ);
                XPathNodeIterator xpTotaImpoConcIstr = ResponseASZNi.Current.Select(XPathExpr);
                if (xpTotaImpoConcIstr.Count == 1)
                {
                    xpTotaImpoConcIstr.MoveNext();
                    Risultato.TotaImpoConcIstr = xpTotaImpoConcIstr.Current.Value;
                }
                else
                {
                    Risultato.TotaImpoConcIstr = ""; // se non c'è lo ignoro e amen
                }
                // TotaImpoConcRevi  aggiunto in versione 2.0
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.TotaImpoConcRevi, nsManagerResponseASZ);
                XPathNodeIterator xpTotaImpoConcRevi = ResponseASZNi.Current.Select(XPathExpr);
                if (xpTotaImpoConcRevi.Count == 1)
                {
                    xpTotaImpoConcRevi.MoveNext();
                    Risultato.TotaImpoConcRevi = xpTotaImpoConcRevi.Current.Value;
                }
                else
                {
                    Risultato.TotaImpoConcRevi = ""; // se non c'è lo ignoro e amen
                }

                // Esito questo è stato eliminato nella versione 2.0
                /*
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.Esito, nsManagerResponseASZ);
                XPathNodeIterator xpEsito = ResponseASZNi.Current.Select(XPathExpr);
                if (xpEsito.Count == 1)
                {
                    xpEsito.MoveNext();
                    Risultato.esito = xpEsito.Current.Value;
                }
                else
                {
                    throw new Exception("SOFITER ha restituito un elemento ResponseASZ che non contiene Esito nel formato corretto");
                }
                 */

                // errori 
                Risultato.Errori = new Z2009ErroriList();
                XPathExpr = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.ISWSErroriASZ.Root, nsManagerResponseASZ);
                XPathNodeIterator xpErrori = ResponseASZNi.Current.Select(XPathExpr);
                XPathExpression XPathExprNomeOggetto = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.ISWSErroriASZ.NomeOggetto, nsManagerResponseASZ);
                XPathExpression XPathExprCampoErrato = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.ISWSErroriASZ.CampoErrato, nsManagerResponseASZ);
                XPathExpression XPathExprTipoErrore = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.ISWSErroriASZ.TipoErrore, nsManagerResponseASZ);
                XPathExpression XPathExprDescErrore = XPathExpression.Compile(SIANGateway.XpathZucchero2009.ISWSResponseASZ.ISWSErroriASZ.DescErrore, nsManagerResponseASZ);
                XPathNodeIterator NiNomeOggetto;
                XPathNodeIterator NiCampoErrato;
                XPathNodeIterator NiTipoErrore;
                XPathNodeIterator NiDescErrore;
                if (xpErrori.Count >= 1)
                {
                    Z2009Errore ErroreCorrene;
                    for (int i = 1; i <= xpErrori.Count; ++i)
                    {
                        ErroreCorrene = new Z2009Errore();
                        xpErrori.MoveNext();
                        NiNomeOggetto = xpErrori.Current.Select(XPathExprNomeOggetto);
                        if (NiNomeOggetto.Count == 1)
                        {
                            NiNomeOggetto.MoveNext();
                            ErroreCorrene.NomeOggetto = NiNomeOggetto.Current.Value;
                        }
                        //else
                        //{
                        //    throw new Exception("SOFITER ha restituito un elemento Errore senza NomeOggetto corretto");
                        //}
                        NiCampoErrato = xpErrori.Current.Select(XPathExprCampoErrato);
                        if (NiCampoErrato.Count == 1)
                        {
                            NiCampoErrato.MoveNext();
                            ErroreCorrene.CampoErrato = NiCampoErrato.Current.Value;
                        }
                        //else
                        //{
                        //    throw new Exception("SOFITER ha restituito un elemento Errore senza CampoErrato corretto");
                        //}
                        NiTipoErrore = xpErrori.Current.Select(XPathExprTipoErrore);
                        if (NiTipoErrore.Count == 1)
                        {
                            NiTipoErrore.MoveNext();
                            ErroreCorrene.TipoErrore = NiTipoErrore.Current.Value;
                        }
                        //else
                        //{
                        //    throw new Exception("SOFITER ha restituito un elemento Errore senza TipoErrore corretto");
                        //}
                        NiDescErrore = xpErrori.Current.Select(XPathExprDescErrore);
                        if (NiDescErrore.Count == 1)
                        {
                            NiDescErrore.MoveNext();
                            ErroreCorrene.DescErrore = NiDescErrore.Current.Value;
                        }
                        //else
                        //{
                        //    throw new Exception("SOFITER ha restituito un elemento Errore senza DescErrore corretto");
                        //}

                        Risultato.Errori.Add(ErroreCorrene);
                    }
                }
            }
            else if (ResponseASZNi.Count == 0)
            {
                throw new Exception("SOFITER non ha restituito nessun elemento ResponseASZ");
            }
            else
            {
                throw new Exception("SOFITER ha restituito più di un elemento ResponseASZ");
            }
            #endregion
            return Risultato;
        }

        /// <summary>
        /// Metodo geenrico valido per chiamare qualsiasi web service AGEA
        /// </summary>
        /// <param name="XmlDaSpedire">stringa XML da inserire nel SOAP envelope da inviare al web service</param>
        /// <param name="UtenteSiar">Login utente per LOG</param>
        /// <param name="Parametri">Oggetto contenente utente/password/url per invio richiesta SOAP</param>
        /// <param name="NomeMetodo">Nome del metodo esposto dal web service</param>
        /// <param name="NomeServizio">Nome del web service</param>
        /// <returns>Risposta SOAP restituita dal Web service</returns>
        /// <example>
        /// PostinoSOAP WsAGEA = new PostinoSOAP();
        /// // se serve creo un proxy per uscire su Internet
        /// WsAGEA.Proxy = new WebSian.ProxyWebConfig();
        /// WsAGEA.Proxy.Host = "proxisa";
        /// WsAGEA.Proxy.Port = 8080;
        /// WsAGEA.Proxy.Active = true;
        /// // impostare parametri ad esempoio per ambiente di test
        /// SianWebSrv.WebSian.InitParam Param = new WebSian.InitParam();
        /// Param.Url = "http://andromeda.sian.it/wspdd/services/WSZuccheroASZ";
        /// Param.WebSrvUser = "regimarche";
        /// Param.WebSrvPassword = "1rrmrc1";
        /// // se serve attiva la registrazione dei messaggi SOAP su file
        /// SianObj.SoapResponseLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// SianObj.SoapRequestLogger = new SianWebSrv.Logging.TxtSoapMsgLogger("c:/LogDir");
        /// // invia la richiesta al server AGEA
        /// XmlDocument Risultato = WsAGEA.SpedisciDomanda(DomandaXml, "UtenteInChiaroPerLog", Param, "ScambiaDomandaZuccheroASZ", "WSZuccheroASZ");
        /// </example>
        public XmlDocument SpedisciDomanda(string XmlDaSpedire, string UtenteSiar, InitParam Parametri, string NomeMetodo, string NomeServizio)
        {
            _Param.Url = Parametri.Url;
            _Param.WebSrvUser = Parametri.WebSrvUser;
            _Param.WebSrvPassword = Parametri.WebSrvPassword;
            SianObj.Timeout = Parametri.Timeout;

            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = UtenteSiar;
                    dett.MehodName = NomeMetodo;
                    dett.ServiceName = NomeServizio;
                    if (XmlDaSpedire.Length > 100)
                    {
                        dett.Params = XmlDaSpedire.Substring(1, 100);
                    }
                    else
                    {
                        dett.Params = XmlDaSpedire;
                    }
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                if (Proxy != null)
                {
                    SianObj.Proxy = Proxy;
                }

                string risposta = SianObj.SpedisciSoapEnv(XmlDaSpedire, _Param.Url, NomeMetodo, _Param.WebSrvUser, _Param.WebSrvPassword);

                XmlDocument rispostaXml = new XmlDocument();
                rispostaXml.LoadXml(risposta);

                return rispostaXml;

            }
            catch (Exception e)
            {
                if (_ErrorLogger != null)
                {
                    _ErrorLogger.LogError(UtenteSiar, XmlDaSpedire.Substring(1, 100), e);
                }
                throw e;
            }

        }

    }


    public class DomandePSR : WebSian
    {
        public DomandePSR()
            : base()
        {
            _Param.Url = SIANGateway.DomandaPSRUrl;
            _Param.WebSrvUser = SIANGateway.DomandaPSRLogin;
            _Param.WebSrvPassword = SIANGateway.DomandaPSRPassword;
        }

        public DomandePSR(InitParam Parametri) : base(Parametri) { }

        public Domanda DownloadDomanda(string Login, string CodBarre)
        {
            try
            {
                #region Registrazione accessi
                if (_CallLogger != null)
                {
                    Logging.CallDetails dett = new CallDetails();
                    dett.IdUser = Login;
                    dett.MehodName = "ScaricoDomandaOnlineASR";
                    dett.ServiceName = "WSAcquisizioneDomandaASR";
                    dett.Params = "CodBarre=" + CodBarre;
                    _CallLogger.LogMethodCall(dett);
                }
                #endregion

                SIANGateway.SianResult risultato = SianObj.ScaricoDomandaOnlineASR(Param.WebSrvUser, Param.WebSrvPassword, CodBarre, Param.Url);

                Domanda Domanda = new SianWebSrv.PSR.Domanda(risultato);

                return Domanda;
            }
            catch (Exception e)
            {
                if (_ErrorLogger != null)
                {
                    string note = "DownloadDomanda(" + Login + "," + CodBarre + ")";
                    _ErrorLogger.LogError(Login, note, e);
                }
                throw e;
            }

        }
    }
}
