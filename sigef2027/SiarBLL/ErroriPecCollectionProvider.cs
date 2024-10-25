using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ErroriPec
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IErroriPecProvider
    {
        int Save(ErroriPec ErroriPecObj);
        int SaveCollection(ErroriPecCollection collectionObj);
        int Delete(ErroriPec ErroriPecObj);
        int DeleteCollection(ErroriPecCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ErroriPec
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ErroriPec : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _OperatoreInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _OperatoreModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.IntNT _IdStato;
        private NullTypes.StringNT _Stato;
        private NullTypes.StringNT _Destinatario;
        private NullTypes.StringNT _EmailDestinatario;
        private NullTypes.IntNT _IdProgettoStorico;
        private NullTypes.IntNT _IdProgettoComunicazione;
        private NullTypes.IntNT _IdProgettoComunicazioni;
        private NullTypes.IntNT _IdProgettoSegnature;
        private NullTypes.IntNT _IdDomandaIntegrazioni;
        private NullTypes.IntNT _IdProgettoDomanda;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdDomandaPagamentoSegnature;
        private NullTypes.IntNT _IdVariante;
        [NonSerialized] private IErroriPecProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IErroriPecProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ErroriPec()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Id
        {
            get { return _Id; }
            set
            {
                if (Id != value)
                {
                    _Id = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_INSERIMENTO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT OperatoreInserimento
        {
            get { return _OperatoreInserimento; }
            set
            {
                if (OperatoreInserimento != value)
                {
                    _OperatoreInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataInserimento
        {
            get { return _DataInserimento; }
            set
            {
                if (DataInserimento != value)
                {
                    _DataInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_MODIFICA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT OperatoreModifica
        {
            get { return _OperatoreModifica; }
            set
            {
                if (OperatoreModifica != value)
                {
                    _OperatoreModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataModifica
        {
            get { return _DataModifica; }
            set
            {
                if (DataModifica != value)
                {
                    _DataModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Segnatura
        {
            get { return _Segnatura; }
            set
            {
                if (Segnatura != value)
                {
                    _Segnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStato
        {
            get { return _IdStato; }
            set
            {
                if (IdStato != value)
                {
                    _IdStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Stato
        {
            get { return _Stato; }
            set
            {
                if (Stato != value)
                {
                    _Stato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESTINATARIO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Destinatario
        {
            get { return _Destinatario; }
            set
            {
                if (Destinatario != value)
                {
                    _Destinatario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:EMAIL_DESTINATARIO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT EmailDestinatario
        {
            get { return _EmailDestinatario; }
            set
            {
                if (EmailDestinatario != value)
                {
                    _EmailDestinatario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_STORICO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoStorico
        {
            get { return _IdProgettoStorico; }
            set
            {
                if (IdProgettoStorico != value)
                {
                    _IdProgettoStorico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_COMUNICAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoComunicazione
        {
            get { return _IdProgettoComunicazione; }
            set
            {
                if (IdProgettoComunicazione != value)
                {
                    _IdProgettoComunicazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_COMUNICAZIONI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoComunicazioni
        {
            get { return _IdProgettoComunicazioni; }
            set
            {
                if (IdProgettoComunicazioni != value)
                {
                    _IdProgettoComunicazioni = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_SEGNATURE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoSegnature
        {
            get { return _IdProgettoSegnature; }
            set
            {
                if (IdProgettoSegnature != value)
                {
                    _IdProgettoSegnature = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DOMANDA_INTEGRAZIONI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaIntegrazioni
        {
            get { return _IdDomandaIntegrazioni; }
            set
            {
                if (IdDomandaIntegrazioni != value)
                {
                    _IdDomandaIntegrazioni = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_DOMANDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoDomanda
        {
            get { return _IdProgettoDomanda; }
            set
            {
                if (IdProgettoDomanda != value)
                {
                    _IdProgettoDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamento
        {
            get { return _IdDomandaPagamento; }
            set
            {
                if (IdDomandaPagamento != value)
                {
                    _IdDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_SEGNATURE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamentoSegnature
        {
            get { return _IdDomandaPagamentoSegnature; }
            set
            {
                if (IdDomandaPagamentoSegnature != value)
                {
                    _IdDomandaPagamentoSegnature = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VARIANTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVariante
        {
            get { return _IdVariante; }
            set
            {
                if (IdVariante != value)
                {
                    _IdVariante = value;
                    SetDirtyFlag();
                }
            }
        }



        public int Save()
        {
            if (this.IsDirty)
            {
                return _provider.Save(this);
            }
            else
            {
                return 0;
            }
        }

        public int Delete()
        {
            return _provider.Delete(this);
        }

        //Get e Set dei campi 'aggiuntivi'

    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for ErroriPecCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ErroriPecCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {

        //Serializzazione xml
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_count", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue(i.ToString(), this[i]);
            }
        }
        private ErroriPecCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ErroriPec)info.GetValue(i.ToString(), typeof(ErroriPec)));
            }
        }

        //Costruttore
        public ErroriPecCollection()
        {
            this.ItemType = typeof(ErroriPec);
        }

        //Costruttore con provider
        public ErroriPecCollection(IErroriPecProvider providerObj)
        {
            this.ItemType = typeof(ErroriPec);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ErroriPec this[int index]
        {
            get { return (ErroriPec)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ErroriPecCollection GetChanges()
        {
            return (ErroriPecCollection)base.GetChanges();
        }

        [NonSerialized] private IErroriPecProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IErroriPecProvider Provider
        {
            get { return _provider; }
            set
            {
                _provider = value;
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].Provider = value;
                }
            }
        }

        public int SaveCollection()
        {
            return _provider.SaveCollection(this);
        }
        public int DeleteCollection()
        {
            return _provider.DeleteCollection(this);
        }
        //Add
        public int Add(ErroriPec ErroriPecObj)
        {
            if (ErroriPecObj.Provider == null) ErroriPecObj.Provider = this.Provider;
            return base.Add(ErroriPecObj);
        }

        //AddCollection
        public void AddCollection(ErroriPecCollection ErroriPecCollectionObj)
        {
            foreach (ErroriPec ErroriPecObj in ErroriPecCollectionObj)
                this.Add(ErroriPecObj);
        }

        //Insert
        public void Insert(int index, ErroriPec ErroriPecObj)
        {
            if (ErroriPecObj.Provider == null) ErroriPecObj.Provider = this.Provider;
            base.Insert(index, ErroriPecObj);
        }

        //CollectionGetById
        public ErroriPec CollectionGetById(NullTypes.IntNT IdValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Id == IdValue))
                    find = true;
                else
                    i++;
            }
            if (find)
                return this[i];
            else
                return null;
        }
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public ErroriPecCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT SegnaturaEqualThis,
NullTypes.IntNT IdStatoEqualThis, NullTypes.StringNT StatoEqualThis, NullTypes.StringNT DestinatarioEqualThis,
NullTypes.StringNT EmailDestinatarioEqualThis)
        {
            ErroriPecCollection ErroriPecCollectionTemp = new ErroriPecCollection();
            foreach (ErroriPec ErroriPecItem in this)
            {
                if (((IdEqualThis == null) || ((ErroriPecItem.Id != null) && (ErroriPecItem.Id.Value == IdEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((ErroriPecItem.OperatoreInserimento != null) && (ErroriPecItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ErroriPecItem.DataInserimento != null) && (ErroriPecItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((OperatoreModificaEqualThis == null) || ((ErroriPecItem.OperatoreModifica != null) && (ErroriPecItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ErroriPecItem.DataModifica != null) && (ErroriPecItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ErroriPecItem.Segnatura != null) && (ErroriPecItem.Segnatura.Value == SegnaturaEqualThis.Value))) &&
((IdStatoEqualThis == null) || ((ErroriPecItem.IdStato != null) && (ErroriPecItem.IdStato.Value == IdStatoEqualThis.Value))) && ((StatoEqualThis == null) || ((ErroriPecItem.Stato != null) && (ErroriPecItem.Stato.Value == StatoEqualThis.Value))) && ((DestinatarioEqualThis == null) || ((ErroriPecItem.Destinatario != null) && (ErroriPecItem.Destinatario.Value == DestinatarioEqualThis.Value))) &&
((EmailDestinatarioEqualThis == null) || ((ErroriPecItem.EmailDestinatario != null) && (ErroriPecItem.EmailDestinatario.Value == EmailDestinatarioEqualThis.Value))))
                {
                    ErroriPecCollectionTemp.Add(ErroriPecItem);
                }
            }
            return ErroriPecCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ErroriPecDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ErroriPecDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ErroriPec ErroriPecObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ErroriPecObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", ErroriPecObj.OperatoreInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ErroriPecObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", ErroriPecObj.OperatoreModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ErroriPecObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", ErroriPecObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStato", ErroriPecObj.IdStato);
            DbProvider.SetCmdParam(cmd, firstChar + "Stato", ErroriPecObj.Stato);
            DbProvider.SetCmdParam(cmd, firstChar + "Destinatario", ErroriPecObj.Destinatario);
            DbProvider.SetCmdParam(cmd, firstChar + "EmailDestinatario", ErroriPecObj.EmailDestinatario);
        }
        //Insert
        private static int Insert(DbProvider db, ErroriPec ErroriPecObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZErroriPecInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "Segnatura",
"IdStato", "Stato", "Destinatario",
"EmailDestinatario",

}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"int", "string", "string",
"string",

}, "");
                CompileIUCmd(false, insertCmd, ErroriPecObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ErroriPecObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                    ErroriPecObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    ErroriPecObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ErroriPec ErroriPecObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZErroriPecUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "Segnatura",
"IdStato", "Stato", "Destinatario",
"EmailDestinatario",

}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "string", "string",
"string",

}, "");
                CompileIUCmd(true, updateCmd, ErroriPecObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ErroriPecObj.DataModifica = d;
                }
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ErroriPec ErroriPecObj)
        {
            switch (ErroriPecObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ErroriPecObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ErroriPecObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ErroriPecObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ErroriPecCollection ErroriPecCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZErroriPecUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "Segnatura",
"IdStato", "Stato", "Destinatario",
"EmailDestinatario",

}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "string", "string",
"string",

}, "");
                IDbCommand insertCmd = db.InitCmd("ZErroriPecInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "Segnatura",
"IdStato", "Stato", "Destinatario",
"EmailDestinatario",

}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"int", "string", "string",
"string",

}, "");
                IDbCommand deleteCmd = db.InitCmd("ZErroriPecDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ErroriPecCollectionObj.Count; i++)
                {
                    switch (ErroriPecCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ErroriPecCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ErroriPecCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                    ErroriPecCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    ErroriPecCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ErroriPecCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ErroriPecCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ErroriPecCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ErroriPecCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ErroriPecCollectionObj.Count; i++)
                {
                    if ((ErroriPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroriPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ErroriPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ErroriPecCollectionObj[i].IsDirty = false;
                        ErroriPecCollectionObj[i].IsPersistent = true;
                    }
                    if ((ErroriPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ErroriPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ErroriPecCollectionObj[i].IsDirty = false;
                        ErroriPecCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //Delete
        public static int Delete(DbProvider db, ErroriPec ErroriPecObj)
        {
            int returnValue = 0;
            if (ErroriPecObj.IsPersistent)
            {
                returnValue = Delete(db, ErroriPecObj.Id);
            }
            ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ErroriPecObj.IsDirty = false;
            ErroriPecObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZErroriPecDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ErroriPecCollection ErroriPecCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZErroriPecDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ErroriPecCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ErroriPecCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ErroriPecCollectionObj.Count; i++)
                {
                    if ((ErroriPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroriPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ErroriPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ErroriPecCollectionObj[i].IsDirty = false;
                        ErroriPecCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //getById
        public static ErroriPec GetById(DbProvider db, int IdValue)
        {
            ErroriPec ErroriPecObj = null;
            IDbCommand readCmd = db.InitCmd("ZErroriPecGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ErroriPecObj = GetFromDatareader(db);
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
            }
            db.Close();
            return ErroriPecObj;
        }

        //getFromDatareader
        public static ErroriPec GetFromDatareader(DbProvider db)
        {
            ErroriPec ErroriPecObj = new ErroriPec();
            ErroriPecObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ErroriPecObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
            ErroriPecObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ErroriPecObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
            ErroriPecObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ErroriPecObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            ErroriPecObj.IdStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STATO"]);
            ErroriPecObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            ErroriPecObj.Destinatario = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESTINATARIO"]);
            ErroriPecObj.EmailDestinatario = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL_DESTINATARIO"]);
            ErroriPecObj.IdProgettoStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_STORICO"]);
            ErroriPecObj.IdProgettoComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_COMUNICAZIONE"]);
            ErroriPecObj.IdProgettoComunicazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_COMUNICAZIONI"]);
            ErroriPecObj.IdProgettoSegnature = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_SEGNATURE"]);
            ErroriPecObj.IdDomandaIntegrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_INTEGRAZIONI"]);
            ErroriPecObj.IdProgettoDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_DOMANDA"]);
            ErroriPecObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            ErroriPecObj.IdDomandaPagamentoSegnature = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_SEGNATURE"]);
            ErroriPecObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ErroriPecObj.IsDirty = false;
            ErroriPecObj.IsPersistent = true;
            return ErroriPecObj;
        }

        //Find Select

        public static ErroriPecCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis,
SiarLibrary.NullTypes.IntNT IdStatoEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.StringNT DestinatarioEqualThis,
SiarLibrary.NullTypes.StringNT EmailDestinatarioEqualThis)

        {

            ErroriPecCollection ErroriPecCollectionObj = new ErroriPecCollection();

            IDbCommand findCmd = db.InitCmd("Zerroripecfindselect", new string[] {"Idequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis",
"OperatoreModificaequalthis", "DataModificaequalthis", "Segnaturaequalthis",
"IdStatoequalthis", "Statoequalthis", "Destinatarioequalthis",
"EmailDestinatarioequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "string", "string",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStatoequalthis", IdStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Destinatarioequalthis", DestinatarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EmailDestinatarioequalthis", EmailDestinatarioEqualThis);
            ErroriPec ErroriPecObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ErroriPecObj = GetFromDatareader(db);
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
                ErroriPecCollectionObj.Add(ErroriPecObj);
            }
            db.Close();
            return ErroriPecCollectionObj;
        }

        //Find FindErroriPec

        public static ErroriPecCollection FindErroriPec(DbProvider db, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdStatoEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis,
SiarLibrary.NullTypes.StringNT DestinatarioEqualThis, SiarLibrary.NullTypes.StringNT EmailDestinatarioEqualThis)

        {

            ErroriPecCollection ErroriPecCollectionObj = new ErroriPecCollection();

            IDbCommand findCmd = db.InitCmd("Zerroripecfindfinderroripec", new string[] {"Segnaturaequalthis", "IdStatoequalthis", "Statoequalthis",
"Destinatarioequalthis", "EmailDestinatarioequalthis"}, new string[] {"string", "int", "string",
"string", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStatoequalthis", IdStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Destinatarioequalthis", DestinatarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EmailDestinatarioequalthis", EmailDestinatarioEqualThis);
            ErroriPec ErroriPecObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ErroriPecObj = GetFromDatareader(db);
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
                ErroriPecCollectionObj.Add(ErroriPecObj);
            }
            db.Close();
            return ErroriPecCollectionObj;
        }

        //Find FindErroriPecNonCorretti

        public static ErroriPecCollection FindErroriPecNonCorretti(DbProvider db, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdStatoLessThanThis, SiarLibrary.NullTypes.StringNT DestinatarioEqualThis,
SiarLibrary.NullTypes.StringNT EmailDestinatarioEqualThis)

        {

            ErroriPecCollection ErroriPecCollectionObj = new ErroriPecCollection();

            IDbCommand findCmd = db.InitCmd("Zerroripecfindfinderroripecnoncorretti", new string[] {"Segnaturaequalthis", "IdStatolessthanthis", "Destinatarioequalthis",
"EmailDestinatarioequalthis"}, new string[] {"string", "int", "string",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStatolessthanthis", IdStatoLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Destinatarioequalthis", DestinatarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EmailDestinatarioequalthis", EmailDestinatarioEqualThis);
            ErroriPec ErroriPecObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ErroriPecObj = GetFromDatareader(db);
                ErroriPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroriPecObj.IsDirty = false;
                ErroriPecObj.IsPersistent = true;
                ErroriPecCollectionObj.Add(ErroriPecObj);
            }
            db.Close();
            return ErroriPecCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ErroriPecCollectionProvider:IErroriPecProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ErroriPecCollectionProvider : IErroriPecProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ErroriPec
        protected ErroriPecCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ErroriPecCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ErroriPecCollection(this);
        }

        //Costruttore 2: popola la collection
        public ErroriPecCollectionProvider(StringNT SegnaturaEqualThis, IntNT IdstatoEqualThis, StringNT StatoEqualThis,
StringNT DestinatarioEqualThis, StringNT EmaildestinatarioEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindErroriPec(SegnaturaEqualThis, IdstatoEqualThis, StatoEqualThis,
DestinatarioEqualThis, EmaildestinatarioEqualThis);
        }

        //Costruttore3: ha in input erroripecCollectionObj - non popola la collection
        public ErroriPecCollectionProvider(ErroriPecCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ErroriPecCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ErroriPecCollection(this);
        }

        //Get e Set
        public ErroriPecCollection CollectionObj
        {
            get
            {
                return _CollectionObj;
            }
            set
            {
                _CollectionObj = value;
            }
        }

        public DbProvider DbProviderObj
        {
            get
            {
                return _dbProviderObj;
            }
            set
            {
                _dbProviderObj = value;
            }
        }

        //Operazioni

        //Save1: registra l'intera collection
        public int SaveCollection()
        {
            return SaveCollection(_CollectionObj);
        }

        //Save2: registra una collection
        public int SaveCollection(ErroriPecCollection collectionObj)
        {
            return ErroriPecDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ErroriPec erroripecObj)
        {
            return ErroriPecDAL.Save(_dbProviderObj, erroripecObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ErroriPecCollection collectionObj)
        {
            return ErroriPecDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ErroriPec erroripecObj)
        {
            return ErroriPecDAL.Delete(_dbProviderObj, erroripecObj);
        }

        //getById
        public ErroriPec GetById(IntNT IdValue)
        {
            ErroriPec ErroriPecTemp = ErroriPecDAL.GetById(_dbProviderObj, IdValue);
            if (ErroriPecTemp != null) ErroriPecTemp.Provider = this;
            return ErroriPecTemp;
        }

        //Select: popola la collection
        public ErroriPecCollection Select(IntNT IdEqualThis, StringNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, StringNT SegnaturaEqualThis,
IntNT IdstatoEqualThis, StringNT StatoEqualThis, StringNT DestinatarioEqualThis,
StringNT EmaildestinatarioEqualThis)
        {
            ErroriPecCollection ErroriPecCollectionTemp = ErroriPecDAL.Select(_dbProviderObj, IdEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis,
OperatoremodificaEqualThis, DatamodificaEqualThis, SegnaturaEqualThis,
IdstatoEqualThis, StatoEqualThis, DestinatarioEqualThis,
EmaildestinatarioEqualThis);
            ErroriPecCollectionTemp.Provider = this;
            return ErroriPecCollectionTemp;
        }

        //FindErroriPec: popola la collection
        public ErroriPecCollection FindErroriPec(StringNT SegnaturaEqualThis, IntNT IdstatoEqualThis, StringNT StatoEqualThis,
StringNT DestinatarioEqualThis, StringNT EmaildestinatarioEqualThis)
        {
            ErroriPecCollection ErroriPecCollectionTemp = ErroriPecDAL.FindErroriPec(_dbProviderObj, SegnaturaEqualThis, IdstatoEqualThis, StatoEqualThis,
DestinatarioEqualThis, EmaildestinatarioEqualThis);
            ErroriPecCollectionTemp.Provider = this;
            return ErroriPecCollectionTemp;
        }

        //FindErroriPecNonCorretti: popola la collection
        public ErroriPecCollection FindErroriPecNonCorretti(StringNT SegnaturaEqualThis, IntNT IdstatoLessThanThis, StringNT DestinatarioEqualThis,
StringNT EmaildestinatarioEqualThis)
        {
            ErroriPecCollection ErroriPecCollectionTemp = ErroriPecDAL.FindErroriPecNonCorretti(_dbProviderObj, SegnaturaEqualThis, IdstatoLessThanThis, DestinatarioEqualThis,
EmaildestinatarioEqualThis);
            ErroriPecCollectionTemp.Provider = this;
            return ErroriPecCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ERRORI_PEC>
  <ViewName>VERRORI_PEC</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <FindErroriPec OrderBy="ORDER BY ">
      <SEGNATURA>Equal</SEGNATURA>
      <ID_STATO>Equal</ID_STATO>
      <STATO>Equal</STATO>
      <DESTINATARIO>Equal</DESTINATARIO>
      <EMAIL_DESTINATARIO>Equal</EMAIL_DESTINATARIO>
    </FindErroriPec>
    <FindErroriPecNonCorretti OrderBy="ORDER BY ">
      <SEGNATURA>Equal</SEGNATURA>
      <ID_STATO>LessThan</ID_STATO>
      <DESTINATARIO>Equal</DESTINATARIO>
      <EMAIL_DESTINATARIO>Equal</EMAIL_DESTINATARIO>
    </FindErroriPecNonCorretti>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ERRORI_PEC>
*/
