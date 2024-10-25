using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Configuration;
using System.Web.Configuration;
namespace SiarLibrary
{
    public class DbProvider : IDisposable
    {
        public enum DbChoice { SqlServer, Oracle }
        private DbChoice _type;
        public DbChoice Type { get { return _type; } set { _type = value; } }

        public enum DbNames { SIGEF, ATTIWEB, NORMEMARCHE, LOG }
        private DbNames _dbSelezionato;
        public DbNames DbSelezionato { get { return _dbSelezionato; } set { _dbSelezionato = value; } }

        private Guid _guid = System.Guid.NewGuid();

        private string _commandFirstChar = "@";
        public string CommandFirstChar { get { return _commandFirstChar; } }

        private string _connectionString;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }
        //public static ConnectionStringSettings DefaultConnectionStringSetting;

        private int _commandTimeout = -1;
        public int CommandTimeout { get { return _commandTimeout; } set { _commandTimeout = value; } }

        private IDataReader _dataReader;
        public IDataReader DataReader { get { return _dataReader; } }

        private IDbTransaction _mainTransaction;
        private System.Collections.Stack _transactionStack = new System.Collections.Stack();
        private int _newTranNumber = 0;
        private IDbConnection _connection;

        public IDbCommand GetCommand()
        {
            IDbCommand oc = null;
            switch (Type)
            {
                case DbChoice.SqlServer: oc = new SqlCommand();
                    break;
                case DbChoice.Oracle: oc = new OracleCommand();
                    break;
                default: oc = null;
                    break;
            }
            if (_commandTimeout >= 0) oc.CommandTimeout = _commandTimeout;
            return oc;
        }

        public IDataParameter GetParameter()
        {
            IDataParameter op = null;
            switch (Type)
            {
                case DbChoice.SqlServer: op = new SqlParameter();
                    break;
                case DbChoice.Oracle: op = new OracleParameter();
                    break;
                default: op = null;
                    break;
            }
            return op;
        }

        // costruttori
        public DbProvider(DbChoice type, DbNames db)
        {
            LoadConfig(type, db);
        }

        // costruttore che prende dai default
        public DbProvider()
        {
            LoadConfig(DbChoice.SqlServer, DbNames.SIGEF);
        }

        public DbProvider(DbNames db)
        {
            LoadConfig(DbChoice.SqlServer, db);
        }

        private void LoadConfig(DbChoice type, DbNames db)
        {
            LoadDb(db);
            Type = type;
            if (Type == DbChoice.Oracle) _commandFirstChar = "";
        }

        private void LoadDb(DbNames db)
        {
            try
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["DB_" + db.ToString()];
#if(DEBUG)                
                    _connectionString = cs.ConnectionString;                
#else
                try { _connectionString = System.Text.Encoding.UTF8.GetString(DecryptString("df_5OFI*xcI,", Convert.FromBase64String(cs.ConnectionString))); }
                catch { _connectionString = cs.ConnectionString; }
#endif
                int ctimeout;
                if (int.TryParse(ConfigurationSettings.AppSettings["DB_" + db.ToString() + ".CommandTimeout"], out ctimeout))
                    _commandTimeout = ctimeout;
            }
            catch (Exception ex) { throw ex; }
        }

        public static byte[] DecryptString(string PASSWORD, byte[] encryptedBytes)
        {
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider des = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                des.IV = new byte[8];
                System.Security.Cryptography.PasswordDeriveBytes pdb = new System.Security.Cryptography.PasswordDeriveBytes(PASSWORD, new byte[0]);
                des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
                //string prova=Encoding.ASCII.GetString(des.Key);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(encryptedBytes.Length);
                System.Security.Cryptography.CryptoStream decStream = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                decStream.FlushFinalBlock();
                byte[] plainBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(plainBytes, 0, (int)ms.Length);
                decStream.Close();
                return plainBytes;
            }
            catch { throw new Exception("Password errata."); }
        }


        //open?

        // ATTENZIONE! CODICE SPERIMENTALE! INIZIO
        private static object _lockobj = new object();
        private static string _lockConnectionString = "";
        private static IDbConnection _lockConnection;
        private void Open()
        {
            if (_connection == null && DbProvider._lockConnectionString != ConnectionString)
            {	//se la connessione non è disponibile provo ad aspettare alcuni millisecondi.
                System.Threading.Thread.Sleep(50);
            }

            if (_connection == null && DbProvider._lockConnectionString == ConnectionString)
            {	// provo a prenderla da _lockConnection
                lock (DbProvider._lockobj)
                {
                    if (DbProvider._lockConnectionString == ConnectionString)
                    {
                        _connection = DbProvider._lockConnection; // la prendo

                        // metto tutto a vuoto
                        DbProvider._lockConnection = null;
                        DbProvider._lockConnectionString = "";
                        //_connection.Open();
                    }
                }// rilascio il lock
            }
            if (_connection == null) // se non sono riuscito a prenderla.
            {
                switch (Type)
                {
                    case DbChoice.SqlServer: _connection = new SqlConnection(ConnectionString);
                        break;
                    case DbChoice.Oracle: _connection = new OracleConnection(ConnectionString);
                        break;
                }
            }
            if (_connection.State != System.Data.ConnectionState.Open) _connection.Open();

        }
        //Fine codice sperimentale

        /*
                private void Open()
                {
                    if (_connection == null)
                    {
                        switch (Type)
                        {
                            case DbChoice.SqlServer : _connection = new SqlConnection(ConnectionString);
                                break;
                            case DbChoice.Oracle : _connection = new OracleConnection(ConnectionString);
                                break;
                        }
                        _connection.Open();
                    }
                }
        */
        public void BeginTran()
        {
            Open();
            _transactionStack.Push(_guid.ToString().Substring(0, 10) + _newTranNumber.ToString());
            if (_transactionStack.Count == 1)  //era =0 sbagliato
            {	//transazione principale
                _mainTransaction = _connection.BeginTransaction();
            }
            else
            {	// transazione interna virtuale tramite savepoint
                switch (Type)
                {
                    case DbChoice.SqlServer: ((SqlTransaction)_mainTransaction).Save((string)_transactionStack.Peek());
                        break;
                    case DbChoice.Oracle: new OracleCommand("SAVEPOINT " + (string)_transactionStack.Peek(), (OracleConnection)_mainTransaction.Connection,
                                              (OracleTransaction)_mainTransaction).ExecuteNonQuery();
                        break;
                }
            }
            _newTranNumber++;
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.StringNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.IntNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.Int64NT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.BoolNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.DecimalNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                // tutto 'sto pappardone è per eliminare un paio di cifre decimali, visto che 
                // con sqlserver 2005 e il massimo di cifre decimali consentite da .net va in errore.
                decimal d = ParameterValue.Value;
                d = decimal.Round(d, 26 - (Math.Abs(d) < 1 ? 0 : (int)Math.Log10(Convert.ToDouble(Math.Abs(d)))));
                ((IDataParameter)Command.Parameters[ParameterName]).Value = d;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.DatetimeNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, SiarLibrary.NullTypes.FloatNT ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue.Value;
            }
        }

        public static void SetCmdParam(IDbCommand Command, string ParameterName, Byte[] ParameterValue)
        {
            if (ParameterValue == null)
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)Command.Parameters[ParameterName]).Value = ParameterValue;
            }
        }
        //commit
        public void Commit()
        {
            if (_mainTransaction != null)
            {
                _transactionStack.Pop();
                if (_transactionStack.Count == 0)
                { // chiudo la transizione vera esterna
                    CommitAll();
                }
            }
            // altrimenti non faccio nulla.
        }
        public void CommitAll()
        {
            if (_mainTransaction != null)
            {
                _mainTransaction.Commit();
                _mainTransaction = null;
                _transactionStack.Clear();
            }
            Dispose();
        }
        //rollback
        public void Rollback()
        {
            if (_mainTransaction != null)
            {
                if (_transactionStack.Count == 1) // == 0 era sbagliato
                { // chiudo la transizione vera esterna
                    RollbackAll();
                }
                else
                {	// transazione interna virtuale tramite savepoint
                    switch (Type)
                    {
                        case DbChoice.SqlServer: ((SqlTransaction)_mainTransaction).Rollback((string)_transactionStack.Peek());
                            break;
                        case DbChoice.Oracle: new OracleCommand("ROLLBACK TO SAVEPOINT " + _transactionStack.Peek(), (OracleConnection)_mainTransaction.Connection,
                                                  (OracleTransaction)_mainTransaction).ExecuteNonQuery();
                            break;
                    }
                    _transactionStack.Pop();
                }

            }
            // altrimenti non faccio nulla.
        }
        public void RollbackAll()
        {
            if (_connection != null)
            {

                CloseDatareader();
                if (_mainTransaction != null)
                {
                    _mainTransaction.Rollback();
                    _mainTransaction.Dispose();
                    _mainTransaction = null;
                }
                // SPERIMENTALE
                if (DbProvider._lockConnectionString != ConnectionString)
                {	// provo a metterla in _lockConnection
                    lock (DbProvider._lockobj)
                    {
                        if (DbProvider._lockConnectionString != ConnectionString)
                        {
                            if (DbProvider._lockConnection != null)
                            {
                                DbProvider._lockConnection.Close();
                                DbProvider._lockConnection.Dispose();
                                DbProvider._lockConnection = null;
                            }
                            DbProvider._lockConnection = _connection; // la metto
                            DbProvider._lockConnectionString = ConnectionString;
                            // metto connection a vuoto
                            _connection = null;
                        }
                    }// rilascio il lock
                }
                if (_connection != null) // se non sono riuscito a metterla.
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
                if (_lastCommandProcedureName != "")
                {
                    _lastCommand.Connection = null;
                    _lastCommand.Transaction = null;
                    _commandCache[_lastCommandProcedureName] = _lastCommand;
                }
                _lastCommand = null;
                _lastCommandProcedureName = "";

                // FINE SPERIMENTALE

            }
            _transactionStack.Clear();
            _newTranNumber = 0;
        }


        //execute command
        public int Execute(IDbCommand myCommand)
        {
            Open();
            int i;
            try
            {
                myCommand.Connection = _connection;
                myCommand.Transaction = _mainTransaction;
                i = myCommand.ExecuteNonQuery();
            }
            catch
            {
                DestroyClose();
                throw;
            }
            Close();
            return i;
        }

        public object ExecuteScalar(IDbCommand myCommand)
        {
            Open();
            object o;
            try
            {
                myCommand.Connection = _connection;
                myCommand.Transaction = _mainTransaction;
                o = myCommand.ExecuteScalar();
            }
            catch
            {
                DestroyClose();
                throw;
            }
            Close();
            return o;
        }

        //initDatareader
        public void InitDatareader(IDbCommand myCommand)
        {
            Open();
            try
            {
                myCommand.Connection = _connection;
                myCommand.Transaction = _mainTransaction;
                //agg
                if (_type == DbChoice.Oracle && !myCommand.Parameters.Contains("RC1"))
                {
                    System.Data.OracleClient.OracleParameter oa = new OracleParameter("RC1", System.Data.OracleClient.OracleType.Cursor);
                    oa.Direction = System.Data.ParameterDirection.Output;
                    myCommand.Parameters.Add(oa);
                }
                //fine
                _dataReader = myCommand.ExecuteReader();
            }
            catch
            {
                DestroyClose();
                throw;
            }
        }

        private void CloseDatareader()
        {
            if (_dataReader != null)
            {
                if (!_dataReader.IsClosed) _dataReader.Close();
                _dataReader = null;
            }
        }
        public void Close()
        {
            CloseDatareader();
            if (_transactionStack.Count == 0)
            {
                // forse è meglio fare RollBackAll???
                if (_connection != null)
                {
                    RollbackAll();
                    //_connection.Close();
                    //_connection = null;
                }
            }
        }

        private void DestroyClose()
        {
            CloseDatareader();
            if (_transactionStack.Count == 0)
            {
                if (_connection != null)
                {
                    _connection.Close();
                    _connection = null;
                    _lastCommand = null;
                    _lastCommandProcedureName = "";
                }
            }
        }

        private System.Collections.Hashtable _commandCache = new System.Collections.Hashtable();

        private IDbCommand _lastCommand;
        private string _lastCommandProcedureName = "";

        public IDbCommand InitCmd(string procedureName, string[] parameterName, string[] parameterType, string outputParameter)
        {
            // cache dei comandi
            if (_commandCache.Contains(procedureName))
            {
                _lastCommand = (IDbCommand)_commandCache[procedureName];
                //_commandCache[procedureName] = null;
                _commandCache.Remove(procedureName);
                _lastCommandProcedureName = procedureName;
                return _lastCommand;
            }

            IDbCommand cmd;
            cmd = GetCommand();
            //cmd.Connection=db;
            //cmd.Transaction=tran;  
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Parameters.Clear();
            IDataParameter p;
            for (int i = 0; i < parameterName.Length; i++)
            {
                p = GetParameter();
                p.Direction = (parameterName[i] == outputParameter) ? ParameterDirection.Output : ParameterDirection.Input;
                p.ParameterName = _commandFirstChar + parameterName[i];
                if (Type == DbChoice.SqlServer)
                { // tipi per sqlserver
                    switch (parameterType[i])
                    {
                        case "string":
                            p.DbType = System.Data.DbType.String;
                            break;
                        case "bool":
                            p.DbType = System.Data.DbType.Boolean;
                            break;
                        case "float":
                            p.DbType = System.Data.DbType.Decimal;
                            break;
                        case "int":
                            p.DbType = System.Data.DbType.Int32;
                            break;
                        case "datetime":
                            p.DbType = System.Data.DbType.Time;
                            break;
                        case "byte[]":
                            p.DbType = System.Data.DbType.Binary;
                            break;
                    }
                }
                else
                { // tipi per **oracle**
                    switch (parameterType[i])
                    {
                        case "string":
                            p.DbType = System.Data.DbType.String; //System.Data.OracleClient.OracleType.NVarChar;
                            break;
                        case "bool":
                            p.DbType = System.Data.DbType.Boolean;
                            break;
                        case "float":
                            p.DbType = System.Data.DbType.Decimal;
                            break;
                        case "int":
                            p.DbType = System.Data.DbType.Int32;
                            break;
                        case "datetime":
                            p.DbType = System.Data.DbType.Time;
                            break;
                        case "byte[]":
                            p.DbType = System.Data.DbType.Binary;
                            break;
                    }
                }
                cmd.Parameters.Add(p);
            }

            _lastCommandProcedureName = procedureName;
            _lastCommand = cmd;
            return cmd;
        }

        #region IDisposable Members

        public void Dispose()
        {
            RollbackAll();
        }
        #endregion
    }

}
