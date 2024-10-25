using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per CntrlocoTesta
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ICntrlocoTestaProvider
    {
        int Save(CntrlocoTesta CntrlocoTestaObj);
        int SaveCollection(CntrlocoTestaCollection collectionObj);
        int Delete(CntrlocoTesta CntrlocoTestaObj);
        int DeleteCollection(CntrlocoTestaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for CntrlocoTesta
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class CntrlocoTesta : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Idloco;
        private NullTypes.StringNT _Codpsr;
        private NullTypes.DatetimeNT _Datainizio;
        private NullTypes.DatetimeNT _Datafine;
        private NullTypes.StringNT _Note;
        private NullTypes.BoolNT _Definitivo;
        private NullTypes.DatetimeNT _Datainserimento;
        private NullTypes.DatetimeNT _Datamodifica;
        private NullTypes.StringNT _Operatore;
        private NullTypes.DatetimeNT _Datasegnatura;
        private NullTypes.StringNT _Segnatura;
        [NonSerialized]
        private ICntrlocoTestaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICntrlocoTestaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public CntrlocoTesta()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:IdLoco
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Idloco
        {
            get { return _Idloco; }
            set
            {
                if (Idloco != value)
                {
                    _Idloco = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CodPsr
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Codpsr
        {
            get { return _Codpsr; }
            set
            {
                if (Codpsr != value)
                {
                    _Codpsr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataInizio
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datainizio
        {
            get { return _Datainizio; }
            set
            {
                if (Datainizio != value)
                {
                    _Datainizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataFine
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datafine
        {
            get { return _Datafine; }
            set
            {
                if (Datafine != value)
                {
                    _Datafine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Note
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT Note
        {
            get { return _Note; }
            set
            {
                if (Note != value)
                {
                    _Note = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Definitivo
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Definitivo
        {
            get { return _Definitivo; }
            set
            {
                if (Definitivo != value)
                {
                    _Definitivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataInserimento
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datainserimento
        {
            get { return _Datainserimento; }
            set
            {
                if (Datainserimento != value)
                {
                    _Datainserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataModifica
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datamodifica
        {
            get { return _Datamodifica; }
            set
            {
                if (Datamodifica != value)
                {
                    _Datamodifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Operatore
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Operatore
        {
            get { return _Operatore; }
            set
            {
                if (Operatore != value)
                {
                    _Operatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DataSegnatura
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Datasegnatura
        {
            get { return _Datasegnatura; }
            set
            {
                if (Datasegnatura != value)
                {
                    _Datasegnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Segnatura
        /// Tipo sul db:VARCHAR(100)
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


        //Get e Set dei campi 'ForeignKey'

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
    /// Summary description for CntrlocoTestaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CntrlocoTestaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private CntrlocoTestaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((CntrlocoTesta)info.GetValue(i.ToString(), typeof(CntrlocoTesta)));
            }
        }

        //Costruttore
        public CntrlocoTestaCollection()
        {
            this.ItemType = typeof(CntrlocoTesta);
        }

        //Costruttore con provider
        public CntrlocoTestaCollection(ICntrlocoTestaProvider providerObj)
        {
            this.ItemType = typeof(CntrlocoTesta);
            this.Provider = providerObj;
        }

        //Get e Set
        public new CntrlocoTesta this[int index]
        {
            get { return (CntrlocoTesta)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new CntrlocoTestaCollection GetChanges()
        {
            return (CntrlocoTestaCollection)base.GetChanges();
        }

        [NonSerialized]
        private ICntrlocoTestaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICntrlocoTestaProvider Provider
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
        public int Add(CntrlocoTesta CntrlocoTestaObj)
        {
            if (CntrlocoTestaObj.Provider == null) CntrlocoTestaObj.Provider = this.Provider;
            return base.Add(CntrlocoTestaObj);
        }

        //AddCollection
        public void AddCollection(CntrlocoTestaCollection CntrlocoTestaCollectionObj)
        {
            foreach (CntrlocoTesta CntrlocoTestaObj in CntrlocoTestaCollectionObj)
                this.Add(CntrlocoTestaObj);
        }

        //Insert
        public void Insert(int index, CntrlocoTesta CntrlocoTestaObj)
        {
            if (CntrlocoTestaObj.Provider == null) CntrlocoTestaObj.Provider = this.Provider;
            base.Insert(index, CntrlocoTestaObj);
        }

        //CollectionGetById
        public CntrlocoTesta CollectionGetById(NullTypes.IntNT IdlocoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Idloco == IdlocoValue))
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
        public CntrlocoTestaCollection SubSelect(NullTypes.IntNT IdlocoEqualThis, NullTypes.StringNT CodpsrEqualThis, NullTypes.DatetimeNT DatainizioEqualThis,
NullTypes.DatetimeNT DatafineEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.BoolNT DefinitivoEqualThis,
NullTypes.DatetimeNT DatainserimentoEqualThis, NullTypes.DatetimeNT DatamodificaEqualThis, NullTypes.StringNT OperatoreEqualThis,
NullTypes.DatetimeNT DatasegnaturaEqualThis, NullTypes.StringNT SegnaturaEqualThis)
        {
            CntrlocoTestaCollection CntrlocoTestaCollectionTemp = new CntrlocoTestaCollection();
            foreach (CntrlocoTesta CntrlocoTestaItem in this)
            {
                if (((IdlocoEqualThis == null) || ((CntrlocoTestaItem.Idloco != null) && (CntrlocoTestaItem.Idloco.Value == IdlocoEqualThis.Value))) && ((CodpsrEqualThis == null) || ((CntrlocoTestaItem.Codpsr != null) && (CntrlocoTestaItem.Codpsr.Value == CodpsrEqualThis.Value))) && ((DatainizioEqualThis == null) || ((CntrlocoTestaItem.Datainizio != null) && (CntrlocoTestaItem.Datainizio.Value == DatainizioEqualThis.Value))) &&
((DatafineEqualThis == null) || ((CntrlocoTestaItem.Datafine != null) && (CntrlocoTestaItem.Datafine.Value == DatafineEqualThis.Value))) && ((NoteEqualThis == null) || ((CntrlocoTestaItem.Note != null) && (CntrlocoTestaItem.Note.Value == NoteEqualThis.Value))) && ((DefinitivoEqualThis == null) || ((CntrlocoTestaItem.Definitivo != null) && (CntrlocoTestaItem.Definitivo.Value == DefinitivoEqualThis.Value))) &&
((DatainserimentoEqualThis == null) || ((CntrlocoTestaItem.Datainserimento != null) && (CntrlocoTestaItem.Datainserimento.Value == DatainserimentoEqualThis.Value))) && ((DatamodificaEqualThis == null) || ((CntrlocoTestaItem.Datamodifica != null) && (CntrlocoTestaItem.Datamodifica.Value == DatamodificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CntrlocoTestaItem.Operatore != null) && (CntrlocoTestaItem.Operatore.Value == OperatoreEqualThis.Value))) &&
((DatasegnaturaEqualThis == null) || ((CntrlocoTestaItem.Datasegnatura != null) && (CntrlocoTestaItem.Datasegnatura.Value == DatasegnaturaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((CntrlocoTestaItem.Segnatura != null) && (CntrlocoTestaItem.Segnatura.Value == SegnaturaEqualThis.Value))))
                {
                    CntrlocoTestaCollectionTemp.Add(CntrlocoTestaItem);
                }
            }
            return CntrlocoTestaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for CntrlocoTestaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class CntrlocoTestaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CntrlocoTesta CntrlocoTestaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Idloco", CntrlocoTestaObj.Idloco);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Codpsr", CntrlocoTestaObj.Codpsr);
            DbProvider.SetCmdParam(cmd, firstChar + "Datainizio", CntrlocoTestaObj.Datainizio);
            DbProvider.SetCmdParam(cmd, firstChar + "Datafine", CntrlocoTestaObj.Datafine);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", CntrlocoTestaObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "Definitivo", CntrlocoTestaObj.Definitivo);
            DbProvider.SetCmdParam(cmd, firstChar + "Datainserimento", CntrlocoTestaObj.Datainserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "Datamodifica", CntrlocoTestaObj.Datamodifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", CntrlocoTestaObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "Datasegnatura", CntrlocoTestaObj.Datasegnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", CntrlocoTestaObj.Segnatura);
        }
        //Insert
        private static int Insert(DbProvider db, CntrlocoTesta CntrlocoTestaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZCntrlocoTestaInsert", new string[] {"Codpsr", "Datainizio", 
"Datafine", "Note", "Definitivo", 
"Datainserimento", "Datamodifica", "Operatore", 
"Datasegnatura", "Segnatura"}, new string[] {"string", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string"}, "");
                CompileIUCmd(false, insertCmd, CntrlocoTestaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    CntrlocoTestaObj.Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
                }
                CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CntrlocoTestaObj.IsDirty = false;
                CntrlocoTestaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, CntrlocoTesta CntrlocoTestaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCntrlocoTestaUpdate", new string[] {"Idloco", "Codpsr", "Datainizio", 
"Datafine", "Note", "Definitivo", 
"Datainserimento", "Datamodifica", "Operatore", 
"Datasegnatura", "Segnatura"}, new string[] {"int", "string", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string"}, "");
                CompileIUCmd(true, updateCmd, CntrlocoTestaObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CntrlocoTestaObj.IsDirty = false;
                CntrlocoTestaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, CntrlocoTesta CntrlocoTestaObj)
        {
            switch (CntrlocoTestaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, CntrlocoTestaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, CntrlocoTestaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, CntrlocoTestaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, CntrlocoTestaCollection CntrlocoTestaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCntrlocoTestaUpdate", new string[] {"Idloco", "Codpsr", "Datainizio", 
"Datafine", "Note", "Definitivo", 
"Datainserimento", "Datamodifica", "Operatore", 
"Datasegnatura", "Segnatura"}, new string[] {"int", "string", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZCntrlocoTestaInsert", new string[] {"Codpsr", "Datainizio", 
"Datafine", "Note", "Definitivo", 
"Datainserimento", "Datamodifica", "Operatore", 
"Datasegnatura", "Segnatura"}, new string[] {"string", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZCntrlocoTestaDelete", new string[] { "Idloco" }, new string[] { "int" }, "");
                for (int i = 0; i < CntrlocoTestaCollectionObj.Count; i++)
                {
                    switch (CntrlocoTestaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, CntrlocoTestaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    CntrlocoTestaCollectionObj[i].Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, CntrlocoTestaCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (CntrlocoTestaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Idloco", (SiarLibrary.NullTypes.IntNT)CntrlocoTestaCollectionObj[i].Idloco);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < CntrlocoTestaCollectionObj.Count; i++)
                {
                    if ((CntrlocoTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CntrlocoTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CntrlocoTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        CntrlocoTestaCollectionObj[i].IsDirty = false;
                        CntrlocoTestaCollectionObj[i].IsPersistent = true;
                    }
                    if ((CntrlocoTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        CntrlocoTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CntrlocoTestaCollectionObj[i].IsDirty = false;
                        CntrlocoTestaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, CntrlocoTesta CntrlocoTestaObj)
        {
            int returnValue = 0;
            if (CntrlocoTestaObj.IsPersistent)
            {
                returnValue = Delete(db, CntrlocoTestaObj.Idloco);
            }
            CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            CntrlocoTestaObj.IsDirty = false;
            CntrlocoTestaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdlocoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCntrlocoTestaDelete", new string[] { "Idloco" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Idloco", (SiarLibrary.NullTypes.IntNT)IdlocoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, CntrlocoTestaCollection CntrlocoTestaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCntrlocoTestaDelete", new string[] { "Idloco" }, new string[] { "int" }, "");
                for (int i = 0; i < CntrlocoTestaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Idloco", CntrlocoTestaCollectionObj[i].Idloco);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < CntrlocoTestaCollectionObj.Count; i++)
                {
                    if ((CntrlocoTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CntrlocoTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CntrlocoTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CntrlocoTestaCollectionObj[i].IsDirty = false;
                        CntrlocoTestaCollectionObj[i].IsPersistent = false;
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
        public static CntrlocoTesta GetById(DbProvider db, int IdlocoValue)
        {
            CntrlocoTesta CntrlocoTestaObj = null;
            IDbCommand readCmd = db.InitCmd("ZCntrlocoTestaGetById", new string[] { "Idloco" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Idloco", (SiarLibrary.NullTypes.IntNT)IdlocoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                CntrlocoTestaObj = GetFromDatareader(db);
                CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CntrlocoTestaObj.IsDirty = false;
                CntrlocoTestaObj.IsPersistent = true;
            }
            db.Close();
            return CntrlocoTestaObj;
        }

        //getFromDatareader
        public static CntrlocoTesta GetFromDatareader(DbProvider db)
        {
            CntrlocoTesta CntrlocoTestaObj = new CntrlocoTesta();
            CntrlocoTestaObj.Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
            CntrlocoTestaObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPsr"]);
            CntrlocoTestaObj.Datainizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInizio"]);
            CntrlocoTestaObj.Datafine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataFine"]);
            CntrlocoTestaObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["Note"]);
            CntrlocoTestaObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Definitivo"]);
            CntrlocoTestaObj.Datainserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInserimento"]);
            CntrlocoTestaObj.Datamodifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataModifica"]);
            CntrlocoTestaObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Operatore"]);
            CntrlocoTestaObj.Datasegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataSegnatura"]);
            CntrlocoTestaObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["Segnatura"]);
            CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CntrlocoTestaObj.IsDirty = false;
            CntrlocoTestaObj.IsPersistent = true;
            return CntrlocoTestaObj;
        }

        //Find Select

        public static CntrlocoTestaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdlocoEqualThis, SiarLibrary.NullTypes.StringNT CodpsrEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainizioEqualThis,
SiarLibrary.NullTypes.DatetimeNT DatafineEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DatainserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatamodificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DatasegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis)
        {

            CntrlocoTestaCollection CntrlocoTestaCollectionObj = new CntrlocoTestaCollection();

            IDbCommand findCmd = db.InitCmd("Zcntrlocotestafindselect", new string[] {"Idlocoequalthis", "Codpsrequalthis", "Datainizioequalthis", 
"Datafineequalthis", "Noteequalthis", "Definitivoequalthis", 
"Datainserimentoequalthis", "Datamodificaequalthis", "Operatoreequalthis", 
"Datasegnaturaequalthis", "Segnaturaequalthis"}, new string[] {"int", "string", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string", 
"DateTime", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idlocoequalthis", IdlocoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codpsrequalthis", CodpsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datainizioequalthis", DatainizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datafineequalthis", DatafineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datainserimentoequalthis", DatainserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datamodificaequalthis", DatamodificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Datasegnaturaequalthis", DatasegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            CntrlocoTesta CntrlocoTestaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CntrlocoTestaObj = GetFromDatareader(db);
                CntrlocoTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CntrlocoTestaObj.IsDirty = false;
                CntrlocoTestaObj.IsPersistent = true;
                CntrlocoTestaCollectionObj.Add(CntrlocoTestaObj);
            }
            db.Close();
            return CntrlocoTestaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for CntrlocoTestaCollectionProvider:ICntrlocoTestaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CntrlocoTestaCollectionProvider : ICntrlocoTestaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di CntrlocoTesta
        protected CntrlocoTestaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public CntrlocoTestaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new CntrlocoTestaCollection(this);
        }

        //Costruttore3: ha in input cntrlocotestaCollectionObj - non popola la collection
        public CntrlocoTestaCollectionProvider(CntrlocoTestaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public CntrlocoTestaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new CntrlocoTestaCollection(this);
        }

        //Get e Set
        public CntrlocoTestaCollection CollectionObj
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
        public int SaveCollection(CntrlocoTestaCollection collectionObj)
        {
            return CntrlocoTestaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(CntrlocoTesta cntrlocotestaObj)
        {
            return CntrlocoTestaDAL.Save(_dbProviderObj, cntrlocotestaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(CntrlocoTestaCollection collectionObj)
        {
            return CntrlocoTestaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(CntrlocoTesta cntrlocotestaObj)
        {
            return CntrlocoTestaDAL.Delete(_dbProviderObj, cntrlocotestaObj);
        }

        //getById
        public CntrlocoTesta GetById(IntNT IdlocoValue)
        {
            CntrlocoTesta CntrlocoTestaTemp = CntrlocoTestaDAL.GetById(_dbProviderObj, IdlocoValue);
            if (CntrlocoTestaTemp != null) CntrlocoTestaTemp.Provider = this;
            return CntrlocoTestaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public CntrlocoTestaCollection Select(IntNT IdlocoEqualThis, StringNT CodpsrEqualThis, DatetimeNT DatainizioEqualThis,
DatetimeNT DatafineEqualThis, StringNT NoteEqualThis, BoolNT DefinitivoEqualThis,
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT OperatoreEqualThis,
DatetimeNT DatasegnaturaEqualThis, StringNT SegnaturaEqualThis)
        {
            CntrlocoTestaCollection CntrlocoTestaCollectionTemp = CntrlocoTestaDAL.Select(_dbProviderObj, IdlocoEqualThis, CodpsrEqualThis, DatainizioEqualThis,
DatafineEqualThis, NoteEqualThis, DefinitivoEqualThis,
DatainserimentoEqualThis, DatamodificaEqualThis, OperatoreEqualThis,
DatasegnaturaEqualThis, SegnaturaEqualThis);
            CntrlocoTestaCollectionTemp.Provider = this;
            return CntrlocoTestaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CntrLoco_Testa>
  <ViewName>
  </ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CntrLoco_Testa>
*/
