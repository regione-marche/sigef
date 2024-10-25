using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Contiene le classi necessarie a registrare su vari tipi di supporto
/// (file, DB SQL ecc.) gli accessi alle funzioni Web e gli errori.
/// </summary>
namespace SianWebSrv.Logging
{
    static class Utils
    {
        static public string CheckEmptyString(string PropertyName, string PropertyValue)
        {
            if (PropertyValue.Trim() == "")
            {
                throw new Exception(PropertyName + " non può essere una stringa nulla");
            }
            else { return PropertyValue.Trim(); }
        }
        static public string getAssemblyPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }
        public const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";
    }
    public enum SoapMessageType { request, response };

    /// <summary>
    /// Classe che gestisce le informazioni necessarie al controllo degli accessi richiesto da AGEA
    /// </summary>
    /// <remarks>
    /// Questa classe viene istanziata all'interno del metodo che richiede la
    /// registrazione e passata ad una classe che implementa l'interfaccia
    /// IMethodCallLogger es:
    /// <code>
    /// // istanzia un oggetto CallDetails e lo riempie
    /// CallDetails CallDett = new CallDetails();
    /// CallDett.IdUser = "Rossi Mario";
    /// CallDett.MehodName = "anagraficaSintetica";
    /// CallDett.ServiceName = "wsAnagrafeAT";
    /// CallDett.Params = "CUAA=ABCXDS75D23Z145R";
    /// // istanzia un oggetto TxtMethodCallLogger
    /// TxtMethodCallLogger CallLogger = new TxtMethodCallLogger();
    /// // esegue la registrazione su file
    /// CallLogger.LogMethodCall(CallDett);
    /// </code>
    /// Normalmente non è necessario istanziare questa classe per registrare
    /// le chiamate ai Web Service AGEA, dato che le classi che offrono
    /// il supporto per l'accesso ad essi si occupano già di questo.
    /// </remarks>
    public class CallDetails
    {
        private string _MehodName;
        private string _IdUser;
        private string _Params;
        private string _ServiceName;

        public bool Success;

        public string MehodName
        {
            get { return Utils.CheckEmptyString("MehodName", _MehodName); }
            set { _MehodName = Utils.CheckEmptyString("MehodName", value); }
        }
        public string IdUser
        {
            get { return Utils.CheckEmptyString("IdUser", _IdUser); }
            set { _IdUser = Utils.CheckEmptyString("IdUser", value); }
        }
        public string Params
        {
            get { return Utils.CheckEmptyString("Params", _Params); }
            set { _Params = Utils.CheckEmptyString("Params", value); }
        }
        public string ServiceName
        {
            get { return Utils.CheckEmptyString("Params", _ServiceName); }
            set { _ServiceName = Utils.CheckEmptyString("Params", value); }
        }
    }

    /// <summary>
    /// Interfaccia che deve essere suportata dalle classi che si intende
    /// utilizzare per la registrazione degli errori
    /// </summary>
    public interface IErrorLogger
    {
        /// <summary>
        /// Esegue la registrazione dei dettagli di un'eccezione
        /// </summary>
        /// <param name="IdUser">Identificativo utente connesso al momento dell'errore</param>
        /// <param name="Note">Annotazioni extra</param>
        /// <param name="Exc">Eccezione da registrare</param>
        /// <returns>Data e ora esecuzione chiamata</returns>
        DateTime LogError(string IdUser, string Note, Exception Exc);
    }

    /// <summary>
    /// Interfaccia che deve essere suportata dalle classi che si intende
    /// utilizzare per la registrazione degli accessi alle funzioni AGEA
    /// </summary>
    public interface IMethodCallLogger
    {
        /// <summary>
        /// Esegue la registrazione della chiamata a un metodo Web pubblicato da AGEA
        /// </summary>
        /// <param name="evt">Dettagli della chiamata di metodo</param>
        /// <returns>Data e ora esecuzione chiamata</returns>
        DateTime LogMethodCall(CallDetails evt);
    }

    /// <summary>
    /// Interfaccia che deve essere suportata dalle classi che si intende
    /// utilizzare per la registrazione dei messaggi SOAP scambiati con il server AGEA
    /// </summary>
    public interface ISoapMsgLogger
    {
        /// <summary>
        /// Esegue la registrazione dei messagi SOAP scambiati con il server SIAN
        /// </summary>
        /// <param name="SoapMessage">Messaggio SOAP da registrare.</param>
        /// <param name="RequestGuid">GUID che identifica la coppia richiesta/risposta SOAP.</param>
        /// <param name="MessageType">Indica se il messaggio è una richiesta o una risposta SOAP.</param>
        void LogSoapMsg(string SoapMessage, Guid RequestGuid, SoapMessageType MessageType);
    }


    /// <summary>
    /// Classe che raccoglie le informazioni necessarie alla connessione a un DB SQL Server
    /// </summary>
    /// <remarks>
    /// Questa classe va istanziata se si vuole personalizzare la connessione al DB
    /// utilizzata da un oggetto di classe SqlErrorLogger o SqlMethodCallLogger es:
    /// <code>
    /// // istanzia un oggetto SqlDBConfig e lo imposta
    /// SqlDBConfig DBConfig = new SqlDBConfig();
    /// DBConfig.Server = "mioServer";
    /// DBConfig.DBName = "LogDb";
    /// DBConfig.Login = "administrator";
    /// DBConfig.Password = "xxxxxx";
    /// // istanzia un oggetto SqlMethodCallLogger con parametri di 
    /// // connessione al DB personalizzati
    /// SqlMethodCallLogger sqlLog = new SqlMethodCallLogger(DBConfig);
    /// // ... utilizza l'oggetto sqlLog
    /// </code>
    /// </remarks>
    public class SqlDBConfig
    {
        # region Default values
        public const string SERVER = "localhost";
        public const string DBNAME = "SIGEF";
        public const string LOGIN = "sa";
        public const string PASSWORD = "sa";
        # endregion

        private string _Server = SERVER;
        private string _DBName = DBNAME;
        private string _Login = LOGIN;

        public string Password = PASSWORD;
        public bool UseLibDbmssocn = true;
        public bool PersistSecurityInfo = false;

        public string Server
        {
            get { return _Server; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("Server non può essere una stringa nulla");
                }
                else { _Server = value.Trim(); }
            }
        }
        public string DBName
        {
            get { return _DBName; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("DBName non può essere una stringa nulla");
                }
                else { _DBName = value.Trim(); }
            }
        }
        public string Login
        {
            get { return _Login; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("Login non può essere una stringa nulla");
                }
                else { _Login = value.Trim(); }
            }
        }

        /// <summary>
        /// Restituisce la stringa di connessione costruita in base ai parametri di 
        /// connessione specificati, o imposta i parametri di connessione leggendo
        /// una stringa di connessione
        /// </summary>
        public string ConnectionString
        {
            get
            {
                string strConn = "Data Source=" + _Server +
                                 ";Initial Catalog=" + _DBName +
                                 ";User ID=" + _Login +
                                 ";Password=" + Password;
                if (UseLibDbmssocn)
                {
                    strConn = strConn + ";Network Library=dbmssocn";
                }
                if (PersistSecurityInfo)
                {
                    strConn = strConn + ";Persist Security Info=True";
                }
                else
                {
                    strConn = strConn + ";Persist Security Info=False";
                }
                return strConn;
            }
            set
            {
                string KeyName, KeyValue;
                string[] Param;

                this.UseLibDbmssocn = false;
                this.PersistSecurityInfo = false;

                string[] ParamArray = value.Split(';');
                int nItem = ParamArray.GetLength(0);
                for (int i = 1; i <= nItem; i++)
                {
                    Param = ParamArray[i - 1].Split('=');
                    KeyName = Param[0];
                    KeyValue = Param[1];

                    if (KeyName.ToUpper() == "DATA SOURCE")
                    {
                        this.Server = KeyValue;
                    }
                    if (KeyName.ToUpper() == "INITIAL CATALOG")
                    {
                        this.DBName = KeyValue;
                    }
                    if (KeyName.ToUpper() == "USER ID")
                    {
                        this.Login = KeyValue;
                    }
                    if (KeyName.ToUpper() == "PASSWORD")
                    {
                        this.Password = KeyValue;
                    }
                    if (KeyName.ToUpper() == "PERSIST SECURITY INFO")
                    {
                        this.PersistSecurityInfo = (KeyValue.ToUpper() == "TRUE");
                    }
                    if (KeyName.ToUpper() == "NETWORK LIBRARY")
                    {
                        this.UseLibDbmssocn = (KeyValue.ToUpper() == "DBMSSOCN");
                    }
                }
            }
        }

        /// <summary>
        /// Istanzia un oggetto SqlConnection utilizzando i parametri di connessione correnti
        /// </summary>
        public SqlConnection getConnection()
        {
            SqlConnection DBConn = new SqlConnection(ConnectionString);
            DBConn.Open();
            return DBConn;
        }

    }

    /// <summary>
    /// Implementa la registrazione su DB Sql Server delle eccezioni verificatesi in esecuzione.
    /// </summary>
    public class SqlErrorLogger : IErrorLogger
    {
        /// <summary>
        /// Informazioni sulla struttura della tabella SQL Server destinata alla registrazione degli errori
        /// </summary>
        public class TableDefinition
        {
            #region Default values
            private string _TableName = "LOG_SIGEF_ERRORI";
            private string _DataFldName = "Data";
            private string _IdUserFldName = "IdUser";
            private int MaxLenIdUser = 50;
            private string _MessageFldName = "Message";
            private int MaxLenMessage = 255;
            private string _TargetSiteFldName = "TargetSite";
            private int MaxLenTargetSite = 255;
            private string _StackTraceFldName = "StackTrace";
            private int MaxLenStackTrace = 1024;
            private string _AssemblyFldName = "Assembly";
            private int MaxLenAssembly = 255;
            private string _NoteFldName = "Note";
            private int MaxLenNote = 1024;
            #endregion

            /// <summary>
            /// Nome della tabella da utilizzare per la registrazione degli errori (default Errori)
            /// </summary>
            public string TableName
            {
                get { return _TableName; }
                set { _TableName = Utils.CheckEmptyString("TableName", value); }
            }
            /// <summary>
            /// Nome del campo DateTime in cui registrare la data e ore in cui
            /// si è verificato l'errore (default Data)
            /// </summary>
            public string DataFldName
            {
                get { return _DataFldName; }
                set { _DataFldName = Utils.CheckEmptyString("DataFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare l'identificativo dell'utente connesso
            /// al momento dell'errore (default IdUser)
            /// </summary>
            public string IdUserFldName
            {
                get { return _IdUserFldName; }
                set { _IdUserFldName = Utils.CheckEmptyString("IdUserFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare il messagio di errore (default Message)
            /// </summary>
            public string MessageFldName
            {
                get { return _MessageFldName; }
                set { _MessageFldName = Utils.CheckEmptyString("MessageFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare il nome del metodo in cui si è verificato
            /// l'errore (default TargetSite)
            /// </summary>
            public string TargetSiteFldName
            {
                get { return _TargetSiteFldName; }
                set { _TargetSiteFldName = Utils.CheckEmptyString("TargetSiteFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare lo stack delle chiamate al momento
            /// dell'errore (default StackTrace)
            /// </summary>
            public string StackTraceFldName
            {
                get { return _StackTraceFldName; }
                set { _StackTraceFldName = Utils.CheckEmptyString("StackTraceFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare il path completo dell'assembly in cui
            /// si è generato l'errore (default Assembly)
            /// </summary>
            public string AssemblyFldName
            {
                get { return _AssemblyFldName; }
                set { _AssemblyFldName = Utils.CheckEmptyString("AssemblyFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare annotazioni aggiuntive (default note)
            /// </summary>
            public string NoteFldName
            {
                get { return _NoteFldName; }
                set { _NoteFldName = Utils.CheckEmptyString("NoteFldName", value); }
            }

            internal string CheckIdUser(string IdUser)
            {
                string _IdUser = Utils.CheckEmptyString("IdUser", IdUser);
                if (_IdUser.Length > MaxLenIdUser)
                {
                    return _IdUser.Substring(0, MaxLenIdUser);
                }
                else { return _IdUser; }
            }
            internal string CheckMessage(Exception exc)
            {
                if (exc.Message.Length > MaxLenMessage)
                {
                    return exc.Message.Substring(0, MaxLenMessage);
                }
                else { return exc.Message; }
            }
            internal string CheckTargetSite(Exception exc)
            {
                string strVal;
                if (exc.TargetSite == null)
                { strVal = ""; }
                else { strVal = exc.TargetSite.Name; }
                if (strVal.Length > MaxLenTargetSite)
                {
                    return strVal.Substring(0, MaxLenTargetSite);
                }
                else { return strVal; }
            }
            internal string CheckStackTrace(Exception exc)
            {
                string strVal;
                if (exc.StackTrace == null)
                { strVal = ""; }
                else { strVal = exc.StackTrace; }
                if (strVal.Length > MaxLenStackTrace)
                {
                    return strVal.Substring(0, MaxLenStackTrace);
                }
                else { return strVal; }
            }
            internal string CheckAssembly(string Assembly)
            {
                if (Assembly.Length > MaxLenAssembly)
                {
                    return Assembly.Substring(0, MaxLenAssembly);
                }
                else { return Assembly; }
            }
            internal string CheckNote(string Note)
            {
                if (Note.Trim().Length > MaxLenNote)
                {
                    return Note.Trim().Substring(0, MaxLenNote);
                }
                else { return Note.Trim(); }
            }
        }

        private SqlDBConfig _DBConfig;
        private TableDefinition _TableDef;

        /// <summary>
        /// Path completo del file da usare per la registrazione degli errori nel caso di fallimento della 
        /// registrazione su SQL Server, se non impostato verrà creato un oggetto TxtErrorLogger
        /// con le impostazioni di default
        /// </summary>
        /// <seealso cref="TxtErrorLogger"/>
        public string FilePathForSQLFails;

        /// <summary>
        /// Costruttore di default. Utilizza connessione DB Sql Server locale e 
        /// struttura Tabella Errori di default
        /// </summary>
        public SqlErrorLogger()
        {
            _DBConfig = new SqlDBConfig();
            _TableDef = new TableDefinition();
        }

        /// <summary>
        /// Costruttore in overload, che utilzza connessione DB specificata e 
        /// struttura Tabella Errori di default
        /// </summary>
        public SqlErrorLogger(SqlDBConfig DBConfig)
        {
            _DBConfig = DBConfig;
            _TableDef = new TableDefinition();
        }

        /// <summary>
        /// Costruttore in overload, che utilzza connessione DB specificata e 
        /// struttura Tabella Errori personalizzata
        /// </summary>
        public SqlErrorLogger(SqlDBConfig DBConfig, TableDefinition TableDef)
        {
            _DBConfig = DBConfig;
            _TableDef = TableDef;
        }

        #region IErrorLogger Members
        public DateTime LogError(string IdUser, string Note, Exception Exc)
        {
            DateTime adesso = DateTime.Now;
            try
            {
                SqlConnection DBConn = _DBConfig.getConnection();
                SqlCommand LogCmd = DBConn.CreateCommand();

                LogCmd.CommandText =
                    "INSERT INTO [" + _TableDef.TableName + "] " +
                    "(" + _TableDef.DataFldName + "," + _TableDef.IdUserFldName +
                    "," + _TableDef.MessageFldName + "," + _TableDef.TargetSiteFldName +
                    "," + _TableDef.StackTraceFldName + "," + _TableDef.AssemblyFldName +
                    "," + _TableDef.NoteFldName + ")" +
                    " values (@Data, @IdUser, @Message, @TargetSite, @StackTrace" +
                    ", @Assembly, @Note )";

                LogCmd.Parameters.Add("@Data", System.Data.SqlDbType.DateTime);
                LogCmd.Parameters["@Data"].Value = adesso;

                LogCmd.Parameters.Add("@IdUser", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@IdUser"].Value = _TableDef.CheckIdUser(IdUser); ;

                LogCmd.Parameters.Add("@Message", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@Message"].Value = _TableDef.CheckMessage(Exc);

                LogCmd.Parameters.Add("@TargetSite", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@TargetSite"].Value = _TableDef.CheckTargetSite(Exc);

                LogCmd.Parameters.Add("@StackTrace", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@StackTrace"].Value = _TableDef.CheckStackTrace(Exc);

                LogCmd.Parameters.Add("@Assembly", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@Assembly"].Value = _TableDef.CheckAssembly(Utils.getAssemblyPath());

                LogCmd.Parameters.Add("@Note", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@Note"].Value = _TableDef.CheckNote(Note);

                LogCmd.ExecuteNonQuery();

                return adesso;
            }
            catch (Exception e)
            {
                // qualcosa non va sul DB provo su file con config di default
                TxtErrorLogger FileErr;
                if (FilePathForSQLFails != null && FilePathForSQLFails.Trim() != "")
                {
                    FileErr = new TxtErrorLogger(FilePathForSQLFails);
                }
                else
                {
                    FileErr = new TxtErrorLogger();
                }
                return FileErr.LogError(IdUser, "Registrazione errore su DB Fallita. " + Note, e);
            }
        }
        #endregion
    }

    /// <summary>
    /// Implementa la registrazione su DB Sql Server degli accessi alle funzioni Web.
    /// </summary>
    public class SqlMethodCallLogger : IMethodCallLogger
    {
        /// <summary>
        /// Informazioni sulla struttura della tabella SQL Server destinata
        /// alla registrazione della chiamata di metodo
        /// </summary>
        public class TableDefinition
        {
            #region Default values
            private string _TableName = "LOG_SIGEF_SIAN_WS";
            private string _DataFldName = "Data";
            private string _IdUserFldName = "IdUser";
            private int MaxLenIdUser = 50;
            private string _WebServiceFldName = "WebService";
            private int MaxLenWebService = 50;
            private string _WebMethodFldName = "WebMethod";
            private int MaxLenWebMethod = 50;
            private string _ParamsFldName = "Params";
            private int MaxLenParams = 1024;
            #endregion

            /// <summary>
            /// Nome della tabella da utilizzare per la registrazione (default LogSianWebSrv)
            /// </summary>
            public string TableName
            {
                get { return _TableName; }
                set { _TableName = Utils.CheckEmptyString("Table", value); }
            }
            /// <summary>
            /// Nome del campo DateTime in cui registrare data e ora dell'accesso (default Data)
            /// </summary>
            public string DataFldName
            {
                get { return _DataFldName; }
                set { _DataFldName = Utils.CheckEmptyString("Data", value); }
            }
            /// <summary>
            /// Nome del campo in cui registrare l'identificativo dell'utente connesso
            /// al momento della chiamata (default IdUser)
            /// </summary>
            public string IdUserFldName
            {
                get { return _IdUserFldName; }
                set { _IdUserFldName = Utils.CheckEmptyString("IdUser", value); }
            }
            /// <summary>
            /// Nome del campo in cui regisrare il nome del servizio WEB chiamato (default WebService)
            /// </summary>
            public string WebServiceFldName
            {
                get { return _WebServiceFldName; }
                set { _WebServiceFldName = Utils.CheckEmptyString("WebServiceFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui regisrare il nome del metodo chiamato (default WebMethod)
            /// </summary>
            public string WebMethodFldName
            {
                get { return _WebMethodFldName; }
                set { _WebMethodFldName = Utils.CheckEmptyString("WebMethodFldName", value); }
            }
            /// <summary>
            /// Nome del campo in cui regisrare una stringa contenente la lista dei parametri
            /// di chiamata (default Param)
            /// </summary>
            public string ParamsFldName
            {
                get { return _ParamsFldName; }
                set { _ParamsFldName = Utils.CheckEmptyString("ParamsFldName", value); }
            }

            internal string CheckIdUser(string IdUser)
            {
                string _IdUser = Utils.CheckEmptyString("IdUser", IdUser);
                if (_IdUser.Length > MaxLenIdUser)
                {
                    return _IdUser.Substring(0, MaxLenIdUser);
                }
                else { return _IdUser; }
            }
            internal string CheckWebService(string WebService)
            {
                string _WebService = Utils.CheckEmptyString("WebService", WebService);
                if (WebService.Length > MaxLenWebService)
                {
                    return _WebService.Substring(0, MaxLenWebService);
                }
                else { return _WebService; }
            }
            internal string CheckWebMethod(string WebMethod)
            {
                string _WebMethod = Utils.CheckEmptyString("WebMethod", WebMethod);
                if (WebMethod.Length > MaxLenWebMethod)
                {
                    return _WebMethod.Substring(0, MaxLenWebMethod);
                }
                else { return _WebMethod; }
            }
            internal string CheckParams(string Params)
            {
                string _Params = Utils.CheckEmptyString("Params", Params);
                if (Params.Length > MaxLenParams)
                {
                    return _Params.Substring(0, MaxLenParams);
                }
                else { return _Params; }
            }

        }

        /// <summary>
        /// Path completo del file da usare per la registrazione degli accessi nel caso di fallimento della 
        /// registrazione su SQL Server, se non impostato verrà creato un oggetto TxtMethodCallLogger
        /// con le impostazioni di default
        /// </summary>
        /// <seealso cref="TxtMethodCallLogger"/>
        public string FilePathForSQLFails;

        private SqlDBConfig _DBConfig;
        private TableDefinition _TableDef;

        /// <summary>
        /// Costruttore di default. Utilzza connessione DB Sql Server locale e 
        /// struttura Tabella registrazione accessi di default
        /// </summary>
        /// <remarks>
        /// Script creazione tabella di default:
        /// <code>
        /// CREATE TABLE [dbo].[LogSianWebSrv] (
        /// [Data] [datetime] NOT NULL ,
        /// [IdUser] [varchar] (50) NOT NULL ,
        /// [WebService] [nvarchar] (50) NOT NULL ,
        /// [WebMethod] [nvarchar] (50) NOT NULL ,
        /// [Params] [nvarchar] (1024) NOT NULL ) ON [PRIMARY]
        /// </code>
        /// </remarks>
        public SqlMethodCallLogger()
        {
            _DBConfig = new SqlDBConfig();
            _TableDef = new TableDefinition();
        }
        /// <summary>
        /// Costruttore in overload, che utilzza connessione DB specificata e 
        /// struttura Tabella registrazione di default
        /// </summary>
        public SqlMethodCallLogger(SqlDBConfig DBConfig)
        {
            _DBConfig = DBConfig;
            _TableDef = new TableDefinition();
        }
        /// <summary>
        /// Costruttore in overload, che utilzza connessione DB specificata e 
        /// struttura Tabella registrazione personalizzata
        /// </summary>
        public SqlMethodCallLogger(SqlDBConfig DBConfig, TableDefinition TableDef)
        {
            _DBConfig = DBConfig;
            _TableDef = TableDef;
        }


        #region IMethodCallLogger Members
        public DateTime LogMethodCall(CallDetails evt)
        {
            DateTime adesso = DateTime.Now;
            try
            {
                SqlConnection DBConn = _DBConfig.getConnection();
                SqlCommand LogCmd = DBConn.CreateCommand();

                LogCmd.CommandText =
                    "INSERT INTO [" + _TableDef.TableName + "] " +
                    "(" + _TableDef.DataFldName + "," + _TableDef.IdUserFldName +
                    "," + _TableDef.WebServiceFldName + "," + _TableDef.WebMethodFldName +
                    "," + _TableDef.ParamsFldName + ")" +
                    " values (@Data, @IdUser, @WebService, @WebMethod, @Params)";

                LogCmd.Parameters.Add("@Data", System.Data.SqlDbType.DateTime);
                LogCmd.Parameters["@Data"].Value = adesso;

                LogCmd.Parameters.Add("@IdUser", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@IdUser"].Value = _TableDef.CheckIdUser(evt.IdUser); ;

                LogCmd.Parameters.Add("@WebService", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@WebService"].Value = _TableDef.CheckWebService(evt.ServiceName);

                LogCmd.Parameters.Add("@WebMethod", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@WebMethod"].Value = _TableDef.CheckWebMethod(evt.MehodName);

                LogCmd.Parameters.Add("@Params", System.Data.SqlDbType.NVarChar);
                LogCmd.Parameters["@Params"].Value = _TableDef.CheckParams(evt.Params);

                LogCmd.ExecuteNonQuery();

                return adesso;

            }
            catch (Exception e1)
            {
                string noteDett;
                try
                {
                    TxtMethodCallLogger File;
                    if (FilePathForSQLFails != null && FilePathForSQLFails.Trim() != "")
                    {
                        File = new TxtMethodCallLogger(FilePathForSQLFails);
                    }
                    else
                    {
                        File = new TxtMethodCallLogger();
                    }
                    File.LogMethodCall(evt);
                    TxtErrorLogger FileErr = new TxtErrorLogger();
                    noteDett = "Registrazione accesso su SQL server fallita. " +
                               "Eseguita registrazione su file. ";
                    return FileErr.LogError(evt.IdUser, noteDett, e1);
                }
                catch (Exception e2)
                {
                    TxtErrorLogger FileErr = new TxtErrorLogger();
                    noteDett = "Registrazione accesso su SQL server fallita. " +
                               "Registrazione accesso su file fallita. " +
                               "Servizio=" + evt.ServiceName + "; Metodo=" + evt.MehodName +
                               "Parametri=" + evt.Params;
                    return FileErr.LogError(evt.IdUser, noteDett, e2);
                }

            }
        }
        #endregion
    }

    /// <summary>
    /// Classe base per la registrazione su file. 
    /// </summary>
    /// <remarks>
    /// E' parzialmente "thread safe": <br>
    /// il metodo per la gestione della concorrenza è un po' rudimentale. 
    /// Se la risorsa file viene assegnata al thread, ma l'operazione di scrittura
    /// non viene mai completata e non si genera un'eccezione, il thread corrente
    /// non molla mai la risorsa file! quindi tutte le richieste di scrittura 
    /// sul file restano in attesa...
    /// per fare meglio dovrei da qui creare un nuovo thread da cui gestire la scrittura
    /// sul file e quindi potrei terminarlo se non risponde in un tempo ragionevole
    /// lo farò forse un giorno...
    /// </remarks>
    public class TxtLogger
    {
        public bool AutoCreateDirectory = true;

        public string FullFileName
        {
            get
            {
                return _OuputDir +
                System.Convert.ToString(System.IO.Path.DirectorySeparatorChar) +
                _FileName;
            }
        }

        protected string _OuputDir;
        public string OuputDir
        {
            set
            {
                System.IO.DirectoryInfo DirInfo = new System.IO.DirectoryInfo(value);
                if (!DirInfo.Exists && this.AutoCreateDirectory)
                {
                    try
                    {
                        DirInfo.Create();
                    }
                    catch (System.ArgumentException)
                    {
                        throw new InvalidOperationException("Il percorso [" + value + "] contiene caratteri non ammessi in un path di una directory.");
                    }
                    catch (System.IO.PathTooLongException)
                    {
                        throw new InvalidOperationException("Il percorso [" + value + "] è troppo lungo.");
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("Il percorso [" + value + "] non è valido: " + e.Message);
                    }
                }
                else
                {
                    throw new Exception("La directory [" + value + "] non esiste");
                }
                _OuputDir = value;
            }
            get { return _OuputDir; }
        }

        protected string _FileName;
        public string FileName
        {
            get { return _FileName; }
        }

        public TxtLogger()
        {
            string pathCompleto = System.Reflection.Assembly.GetExecutingAssembly().Location;
            _OuputDir = System.IO.Path.GetDirectoryName(pathCompleto);
            _FileName = System.IO.Path.GetFileName(pathCompleto);
        }

        public TxtLogger(string pathCompleto)
        {
            try
            {
                this.OuputDir = System.IO.Path.GetDirectoryName(pathCompleto);
                this._FileName = System.IO.Path.GetFileName(pathCompleto);
            }
            catch (System.ArgumentException)
            {
                throw new InvalidOperationException("Il percorso [" + pathCompleto + "] contiene caratteri non ammessi in un path di un file.");
            }
            catch (System.IO.PathTooLongException)
            {
                throw new InvalidOperationException("Il percorso [" + pathCompleto + "] è troppo lungo.");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Il percorso [" + pathCompleto + "] non è valido: " + e.Message);
            }
        }

        protected void write(string Intestazione, string NewLine, string MutexName)
        {
            System.Threading.Mutex fileOwnership = new System.Threading.Mutex(false, MutexName);
            fileOwnership.WaitOne();
            try
            {
                System.IO.StreamWriter StreamFile;
                if (System.IO.File.Exists(FullFileName))
                {
                    StreamFile = System.IO.File.AppendText(FullFileName);
                }
                else
                {
                    StreamFile = System.IO.File.CreateText(FullFileName);
                    StreamFile.WriteLine(Intestazione);
                }
                StreamFile.WriteLine(NewLine);
                StreamFile.Close();
            }
            finally
            {
                fileOwnership.ReleaseMutex();
            }
        }
    }

    /// <summary>
    /// Implementa la registrazione su file degli errori.
    /// </summary>
    public class TxtErrorLogger : TxtLogger, IErrorLogger
    {
        /// <summary>
        /// Nome file di log di default
        /// </summary>
        public const string DEFAULT_FILE_NAME = "SianWebSrv.err";

        /// <summary>
        /// Costruttore di default: utilizza il path dell'assembly e il nome di default
        /// </summary>
        public TxtErrorLogger()
        {
            this._FileName = DEFAULT_FILE_NAME;
        }

        public TxtErrorLogger(string FileFullName) : base(FileFullName) { }

        #region IErrorLogger Members
        public DateTime LogError(string IdUser, string Note, Exception Exc)
        {
            DateTime adesso = DateTime.Now;
            string Data = adesso.ToString(Utils.DATE_FORMAT);
            string TargetSite;
            if (Exc.TargetSite == null)
            {
                TargetSite = "";
            }
            else
            {
                TargetSite = Exc.TargetSite.Name;
            }
            string StackTrace;
            if (Exc.StackTrace == null)
            {
                StackTrace = "";
            }
            else
            {
                StackTrace = Exc.StackTrace;
            }
            string Intestazione = "Data|IdUser|Message|TargetSite|StackTrace|Assembly|Note";
            string NewLine = Data + "|" + IdUser + "|" + Exc.Message + "|" +
                             TargetSite.Replace("\r\n", "") + "|" + StackTrace.Replace("\r\n", "") + "|" +
                             Utils.getAssemblyPath() + "|" + Note;

            base.write(Intestazione, NewLine, DEFAULT_FILE_NAME);

            return adesso;
        }
        #endregion
    }

    /// <summary>
    /// Implementa la registrazione su file degli accessi alle funzioni Web.
    /// </summary>
    public class TxtMethodCallLogger : TxtLogger, IMethodCallLogger
    {
        /// <summary>
        /// Nome file di log di default
        /// </summary>
        public const string DEFAULT_FILE_NAME = "SianWebSrv.log";

        /// <summary>
        /// Costruttore di default: utilizza il path dell'assembly e il nome di default
        /// </summary>
        public TxtMethodCallLogger()
        {
            this._FileName = DEFAULT_FILE_NAME;
        }

        public TxtMethodCallLogger(string FileFullPath) : base(FileFullPath) { }

        #region IMethodCallLogger Members
        public DateTime LogMethodCall(CallDetails evt)
        {
            DateTime adesso = DateTime.Now;
            string Data = adesso.ToString(Utils.DATE_FORMAT);

            string Intestazione = "Data|IdUser|WebService|WebMethod|Params";
            string NewLine = Data + "|" + evt.IdUser + "|" + evt.ServiceName + "|" +
                             evt.MehodName + "|" + evt.Params;

            base.write(Intestazione, NewLine, DEFAULT_FILE_NAME);

            return adesso;
        }
        #endregion
    }

    /// <summary>
    /// Implementa la registrazine di un messaggio SOAP su file.
    /// </summary>
    /// <remarks>
    /// Ogni richiesta o risposta viene salvata in un file separato. 
    /// Il nome è un GUID seguito da Request.xml per le richieste o Response.xml per le risposte.
    /// </remarks>
    public class TxtSoapMsgLogger : ISoapMsgLogger
    {
        public const string DEF_REQUEST_EXT = "Request.xml";
        public const string DEF_RESPONSE_EXT = "Response.xml";
        public const string DEF_DIR = "SOAPMessage";

        private string _FullFileName;
        public string FullFileName
        {
            get { return _FullFileName; }
        }
        private string _DestinationDir;

        private string DirSepChar = System.Convert.ToString(System.IO.Path.DirectorySeparatorChar);

        /// <summary>
        /// Costruttore di default, registra i messaggi nella directory SOAPMessage
        /// all'interno della stessa directory dell'assembly, se non esiste la crea.
        /// </summary>
        public TxtSoapMsgLogger()
        {
            _DestinationDir = System.IO.Directory.GetCurrentDirectory() +
                              DirSepChar + DEF_DIR;
            if (!System.IO.Directory.Exists(_DestinationDir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_DestinationDir);
                }
                catch (Exception e)
                {
                    _DestinationDir = "";
                    TxtErrorLogger ErrLog = new TxtErrorLogger();
                    ErrLog.LogError("", "", e);
                    throw new Exception("Si è verificato un problema nella registrazione dei messaggi SOAP: " + e.Message);
                }
            }
        }
        /// <summary>
        /// Costruttore in overolad, registra i messaggi nella directory DestinationDir.
        /// </summary>
        public TxtSoapMsgLogger(string DestinationDir)
        {
            if (!System.IO.Directory.Exists(DestinationDir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(DestinationDir);
                }
                catch (Exception e)
                {
                    TxtErrorLogger ErrLog = new TxtErrorLogger();
                    ErrLog.LogError("", "", e);
                    throw new Exception("Si è verificato un problema nella registrazione dei messaggi SOAP: " + e.Message);
                }
            }
            _DestinationDir = DestinationDir;
        }

        #region ISoapMsgLogger Members

        public void LogSoapMsg(string SoapMessage, Guid RequestGuid, SoapMessageType MessageType)
        {
            switch (MessageType)
            {
                case SoapMessageType.request:
                    _FullFileName = _DestinationDir + DirSepChar + RequestGuid.ToString() + DEF_REQUEST_EXT;
                    break;
                case SoapMessageType.response:
                    _FullFileName = _DestinationDir + DirSepChar + RequestGuid.ToString() + DEF_RESPONSE_EXT;
                    break;
            }

            System.IO.FileStream NewFile = new System.IO.FileStream(FullFileName, System.IO.FileMode.Create);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] ByteToWrite = encoding.GetBytes(SoapMessage);
            int NumByte = encoding.GetByteCount(SoapMessage);
            NewFile.Write(ByteToWrite, 0, NumByte);
            NewFile.Close();

        }

        #endregion
    }
}
