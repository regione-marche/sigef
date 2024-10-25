using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ZprogrammazioneSanzioni
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IZprogrammazioneSanzioniProvider
    {
        int Save(ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj);
        int SaveCollection(ZprogrammazioneSanzioniCollection collectionObj);
        int Delete(ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj);
        int DeleteCollection(ZprogrammazioneSanzioniCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ZprogrammazioneSanzioni
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ZprogrammazioneSanzioni : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.StringNT _CodSanzione;
        private NullTypes.BoolNT _Attiva;
        private NullTypes.DatetimeNT _DataInizio;
        private NullTypes.IntNT _OperatoreInizio;
        private NullTypes.DatetimeNT _DataFine;
        private NullTypes.IntNT _OperatoreFine;
        private NullTypes.IntNT _Ordine;
        private NullTypes.StringNT _SanzioneTitolo;
        private NullTypes.StringNT _SanzioneDescrizione;
        private NullTypes.StringNT _OpinizioNominativo;
        private NullTypes.StringNT _OpfineNominativo;
        [NonSerialized]
        private IZprogrammazioneSanzioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZprogrammazioneSanzioniProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ZprogrammazioneSanzioni()
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
        /// Corrisponde al campo:ID_PROGRAMMAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazione
        {
            get { return _IdProgrammazione; }
            set
            {
                if (IdProgrammazione != value)
                {
                    _IdProgrammazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_SANZIONE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodSanzione
        {
            get { return _CodSanzione; }
            set
            {
                if (CodSanzione != value)
                {
                    _CodSanzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Attiva
        {
            get { return _Attiva; }
            set
            {
                if (Attiva != value)
                {
                    _Attiva = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizio
        {
            get { return _DataInizio; }
            set
            {
                if (DataInizio != value)
                {
                    _DataInizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_INIZIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreInizio
        {
            get { return _OperatoreInizio; }
            set
            {
                if (OperatoreInizio != value)
                {
                    _OperatoreInizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFine
        {
            get { return _DataFine; }
            set
            {
                if (DataFine != value)
                {
                    _DataFine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_FINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreFine
        {
            get { return _OperatoreFine; }
            set
            {
                if (OperatoreFine != value)
                {
                    _OperatoreFine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Ordine
        {
            get { return _Ordine; }
            set
            {
                if (Ordine != value)
                {
                    _Ordine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SANZIONE_TITOLO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT SanzioneTitolo
        {
            get { return _SanzioneTitolo; }
            set
            {
                if (SanzioneTitolo != value)
                {
                    _SanzioneTitolo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SANZIONE_DESCRIZIONE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT SanzioneDescrizione
        {
            get { return _SanzioneDescrizione; }
            set
            {
                if (SanzioneDescrizione != value)
                {
                    _SanzioneDescrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPINIZIO_NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT OpinizioNominativo
        {
            get { return _OpinizioNominativo; }
            set
            {
                if (OpinizioNominativo != value)
                {
                    _OpinizioNominativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPFINE_NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT OpfineNominativo
        {
            get { return _OpfineNominativo; }
            set
            {
                if (OpfineNominativo != value)
                {
                    _OpfineNominativo = value;
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
    /// Summary description for ZprogrammazioneSanzioniCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZprogrammazioneSanzioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ZprogrammazioneSanzioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ZprogrammazioneSanzioni)info.GetValue(i.ToString(), typeof(ZprogrammazioneSanzioni)));
            }
        }

        //Costruttore
        public ZprogrammazioneSanzioniCollection()
        {
            this.ItemType = typeof(ZprogrammazioneSanzioni);
        }

        //Costruttore con provider
        public ZprogrammazioneSanzioniCollection(IZprogrammazioneSanzioniProvider providerObj)
        {
            this.ItemType = typeof(ZprogrammazioneSanzioni);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ZprogrammazioneSanzioni this[int index]
        {
            get { return (ZprogrammazioneSanzioni)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ZprogrammazioneSanzioniCollection GetChanges()
        {
            return (ZprogrammazioneSanzioniCollection)base.GetChanges();
        }

        [NonSerialized]
        private IZprogrammazioneSanzioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZprogrammazioneSanzioniProvider Provider
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
        public int Add(ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            if (ZprogrammazioneSanzioniObj.Provider == null) ZprogrammazioneSanzioniObj.Provider = this.Provider;
            return base.Add(ZprogrammazioneSanzioniObj);
        }

        //AddCollection
        public void AddCollection(ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionObj)
        {
            foreach (ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj in ZprogrammazioneSanzioniCollectionObj)
                this.Add(ZprogrammazioneSanzioniObj);
        }

        //Insert
        public void Insert(int index, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            if (ZprogrammazioneSanzioniObj.Provider == null) ZprogrammazioneSanzioniObj.Provider = this.Provider;
            base.Insert(index, ZprogrammazioneSanzioniObj);
        }

        //CollectionGetById
        public ZprogrammazioneSanzioni CollectionGetById(NullTypes.IntNT IdValue)
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
        public ZprogrammazioneSanzioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.StringNT CodSanzioneEqualThis,
NullTypes.BoolNT AttivaEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.IntNT OperatoreInizioEqualThis,
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OperatoreFineEqualThis, NullTypes.IntNT OrdineEqualThis)
        {
            ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionTemp = new ZprogrammazioneSanzioniCollection();
            foreach (ZprogrammazioneSanzioni ZprogrammazioneSanzioniItem in this)
            {
                if (((IdEqualThis == null) || ((ZprogrammazioneSanzioniItem.Id != null) && (ZprogrammazioneSanzioniItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZprogrammazioneSanzioniItem.IdProgrammazione != null) && (ZprogrammazioneSanzioniItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((CodSanzioneEqualThis == null) || ((ZprogrammazioneSanzioniItem.CodSanzione != null) && (ZprogrammazioneSanzioniItem.CodSanzione.Value == CodSanzioneEqualThis.Value))) &&
((AttivaEqualThis == null) || ((ZprogrammazioneSanzioniItem.Attiva != null) && (ZprogrammazioneSanzioniItem.Attiva.Value == AttivaEqualThis.Value))) && ((DataInizioEqualThis == null) || ((ZprogrammazioneSanzioniItem.DataInizio != null) && (ZprogrammazioneSanzioniItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((OperatoreInizioEqualThis == null) || ((ZprogrammazioneSanzioniItem.OperatoreInizio != null) && (ZprogrammazioneSanzioniItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) &&
((DataFineEqualThis == null) || ((ZprogrammazioneSanzioniItem.DataFine != null) && (ZprogrammazioneSanzioniItem.DataFine.Value == DataFineEqualThis.Value))) && ((OperatoreFineEqualThis == null) || ((ZprogrammazioneSanzioniItem.OperatoreFine != null) && (ZprogrammazioneSanzioniItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))) && ((OrdineEqualThis == null) || ((ZprogrammazioneSanzioniItem.Ordine != null) && (ZprogrammazioneSanzioniItem.Ordine.Value == OrdineEqualThis.Value))))
                {
                    ZprogrammazioneSanzioniCollectionTemp.Add(ZprogrammazioneSanzioniItem);
                }
            }
            return ZprogrammazioneSanzioniCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ZprogrammazioneSanzioniDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ZprogrammazioneSanzioniDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ZprogrammazioneSanzioniObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgrammazione", ZprogrammazioneSanzioniObj.IdProgrammazione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodSanzione", ZprogrammazioneSanzioniObj.CodSanzione);
            DbProvider.SetCmdParam(cmd, firstChar + "Attiva", ZprogrammazioneSanzioniObj.Attiva);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizio", ZprogrammazioneSanzioniObj.DataInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInizio", ZprogrammazioneSanzioniObj.OperatoreInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFine", ZprogrammazioneSanzioniObj.DataFine);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreFine", ZprogrammazioneSanzioniObj.OperatoreFine);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", ZprogrammazioneSanzioniObj.Ordine);
        }
        //Insert
        private static int Insert(DbProvider db, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZZprogrammazioneSanzioniInsert", new string[] {"IdProgrammazione", "CodSanzione", 
"Attiva", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Ordine", 
}, new string[] {"int", "string", 
"bool", "DateTime", "int", 
"DateTime", "int", "int", 
}, "");
                CompileIUCmd(false, insertCmd, ZprogrammazioneSanzioniObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ZprogrammazioneSanzioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                    ZprogrammazioneSanzioniObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
                }
                ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneSanzioniObj.IsDirty = false;
                ZprogrammazioneSanzioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZprogrammazioneSanzioniUpdate", new string[] {"Id", "IdProgrammazione", "CodSanzione", 
"Attiva", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Ordine", 
}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"DateTime", "int", "int", 
}, "");
                CompileIUCmd(true, updateCmd, ZprogrammazioneSanzioniObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneSanzioniObj.IsDirty = false;
                ZprogrammazioneSanzioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            switch (ZprogrammazioneSanzioniObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ZprogrammazioneSanzioniObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ZprogrammazioneSanzioniObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ZprogrammazioneSanzioniObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZprogrammazioneSanzioniUpdate", new string[] {"Id", "IdProgrammazione", "CodSanzione", 
"Attiva", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Ordine", 
}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"DateTime", "int", "int", 
}, "");
                IDbCommand insertCmd = db.InitCmd("ZZprogrammazioneSanzioniInsert", new string[] {"IdProgrammazione", "CodSanzione", 
"Attiva", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Ordine", 
}, new string[] {"int", "string", 
"bool", "DateTime", "int", 
"DateTime", "int", "int", 
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneSanzioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZprogrammazioneSanzioniCollectionObj.Count; i++)
                {
                    switch (ZprogrammazioneSanzioniCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ZprogrammazioneSanzioniCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ZprogrammazioneSanzioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                    ZprogrammazioneSanzioniCollectionObj[i].Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ZprogrammazioneSanzioniCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ZprogrammazioneSanzioniCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZprogrammazioneSanzioniCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ZprogrammazioneSanzioniCollectionObj.Count; i++)
                {
                    if ((ZprogrammazioneSanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneSanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZprogrammazioneSanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ZprogrammazioneSanzioniCollectionObj[i].IsDirty = false;
                        ZprogrammazioneSanzioniCollectionObj[i].IsPersistent = true;
                    }
                    if ((ZprogrammazioneSanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ZprogrammazioneSanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZprogrammazioneSanzioniCollectionObj[i].IsDirty = false;
                        ZprogrammazioneSanzioniCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj)
        {
            int returnValue = 0;
            if (ZprogrammazioneSanzioniObj.IsPersistent)
            {
                returnValue = Delete(db, ZprogrammazioneSanzioniObj.Id);
            }
            ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ZprogrammazioneSanzioniObj.IsDirty = false;
            ZprogrammazioneSanzioniObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneSanzioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneSanzioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZprogrammazioneSanzioniCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ZprogrammazioneSanzioniCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ZprogrammazioneSanzioniCollectionObj.Count; i++)
                {
                    if ((ZprogrammazioneSanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneSanzioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZprogrammazioneSanzioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZprogrammazioneSanzioniCollectionObj[i].IsDirty = false;
                        ZprogrammazioneSanzioniCollectionObj[i].IsPersistent = false;
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
        public static ZprogrammazioneSanzioni GetById(DbProvider db, int IdValue)
        {
            ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj = null;
            IDbCommand readCmd = db.InitCmd("ZZprogrammazioneSanzioniGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ZprogrammazioneSanzioniObj = GetFromDatareader(db);
                ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneSanzioniObj.IsDirty = false;
                ZprogrammazioneSanzioniObj.IsPersistent = true;
            }
            db.Close();
            return ZprogrammazioneSanzioniObj;
        }

        //getFromDatareader
        public static ZprogrammazioneSanzioni GetFromDatareader(DbProvider db)
        {
            ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj = new ZprogrammazioneSanzioni();
            ZprogrammazioneSanzioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ZprogrammazioneSanzioniObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            ZprogrammazioneSanzioniObj.CodSanzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SANZIONE"]);
            ZprogrammazioneSanzioniObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
            ZprogrammazioneSanzioniObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
            ZprogrammazioneSanzioniObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
            ZprogrammazioneSanzioniObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
            ZprogrammazioneSanzioniObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
            ZprogrammazioneSanzioniObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            ZprogrammazioneSanzioniObj.SanzioneTitolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["SANZIONE_TITOLO"]);
            ZprogrammazioneSanzioniObj.SanzioneDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SANZIONE_DESCRIZIONE"]);
            ZprogrammazioneSanzioniObj.OpinizioNominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPINIZIO_NOMINATIVO"]);
            ZprogrammazioneSanzioniObj.OpfineNominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPFINE_NOMINATIVO"]);
            ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ZprogrammazioneSanzioniObj.IsDirty = false;
            ZprogrammazioneSanzioniObj.IsPersistent = true;
            return ZprogrammazioneSanzioniObj;
        }

        //Find Select

        public static ZprogrammazioneSanzioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodSanzioneEqualThis,
SiarLibrary.NullTypes.BoolNT AttivaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)
        {

            ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionObj = new ZprogrammazioneSanzioniCollection();

            IDbCommand findCmd = db.InitCmd("Zzprogrammazionesanzionifindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "CodSanzioneequalthis", 
"Attivaequalthis", "DataInizioequalthis", "OperatoreInizioequalthis", 
"DataFineequalthis", "OperatoreFineequalthis", "Ordineequalthis"}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"DateTime", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodSanzioneequalthis", CodSanzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivaequalthis", AttivaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZprogrammazioneSanzioniObj = GetFromDatareader(db);
                ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneSanzioniObj.IsDirty = false;
                ZprogrammazioneSanzioniObj.IsPersistent = true;
                ZprogrammazioneSanzioniCollectionObj.Add(ZprogrammazioneSanzioniObj);
            }
            db.Close();
            return ZprogrammazioneSanzioniCollectionObj;
        }

        //Find GetByIdProgrammazione

        public static ZprogrammazioneSanzioniCollection GetByIdProgrammazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis)
        {

            ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionObj = new ZprogrammazioneSanzioniCollection();

            IDbCommand findCmd = db.InitCmd("Zzprogrammazionesanzionifindgetbyidprogrammazione", new string[] { "IdProgrammazioneequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            ZprogrammazioneSanzioni ZprogrammazioneSanzioniObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZprogrammazioneSanzioniObj = GetFromDatareader(db);
                ZprogrammazioneSanzioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneSanzioniObj.IsDirty = false;
                ZprogrammazioneSanzioniObj.IsPersistent = true;
                ZprogrammazioneSanzioniCollectionObj.Add(ZprogrammazioneSanzioniObj);
            }
            db.Close();
            return ZprogrammazioneSanzioniCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ZprogrammazioneSanzioniCollectionProvider:IZprogrammazioneSanzioniProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZprogrammazioneSanzioniCollectionProvider : IZprogrammazioneSanzioniProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ZprogrammazioneSanzioni
        protected ZprogrammazioneSanzioniCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ZprogrammazioneSanzioniCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ZprogrammazioneSanzioniCollection(this);
        }

        //Costruttore 2: popola la collection
        public ZprogrammazioneSanzioniCollectionProvider(IntNT IdprogrammazioneEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = GetByIdProgrammazione(IdprogrammazioneEqualThis);
        }

        //Costruttore3: ha in input zprogrammazionesanzioniCollectionObj - non popola la collection
        public ZprogrammazioneSanzioniCollectionProvider(ZprogrammazioneSanzioniCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ZprogrammazioneSanzioniCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ZprogrammazioneSanzioniCollection(this);
        }

        //Get e Set
        public ZprogrammazioneSanzioniCollection CollectionObj
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
        public int SaveCollection(ZprogrammazioneSanzioniCollection collectionObj)
        {
            return ZprogrammazioneSanzioniDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ZprogrammazioneSanzioni zprogrammazionesanzioniObj)
        {
            return ZprogrammazioneSanzioniDAL.Save(_dbProviderObj, zprogrammazionesanzioniObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ZprogrammazioneSanzioniCollection collectionObj)
        {
            return ZprogrammazioneSanzioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ZprogrammazioneSanzioni zprogrammazionesanzioniObj)
        {
            return ZprogrammazioneSanzioniDAL.Delete(_dbProviderObj, zprogrammazionesanzioniObj);
        }

        //getById
        public ZprogrammazioneSanzioni GetById(IntNT IdValue)
        {
            ZprogrammazioneSanzioni ZprogrammazioneSanzioniTemp = ZprogrammazioneSanzioniDAL.GetById(_dbProviderObj, IdValue);
            if (ZprogrammazioneSanzioniTemp != null) ZprogrammazioneSanzioniTemp.Provider = this;
            return ZprogrammazioneSanzioniTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ZprogrammazioneSanzioniCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, StringNT CodsanzioneEqualThis,
BoolNT AttivaEqualThis, DatetimeNT DatainizioEqualThis, IntNT OperatoreinizioEqualThis,
DatetimeNT DatafineEqualThis, IntNT OperatorefineEqualThis, IntNT OrdineEqualThis)
        {
            ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionTemp = ZprogrammazioneSanzioniDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, CodsanzioneEqualThis,
AttivaEqualThis, DatainizioEqualThis, OperatoreinizioEqualThis,
DatafineEqualThis, OperatorefineEqualThis, OrdineEqualThis);
            ZprogrammazioneSanzioniCollectionTemp.Provider = this;
            return ZprogrammazioneSanzioniCollectionTemp;
        }

        //GetByIdProgrammazione: popola la collection
        public ZprogrammazioneSanzioniCollection GetByIdProgrammazione(IntNT IdprogrammazioneEqualThis)
        {
            ZprogrammazioneSanzioniCollection ZprogrammazioneSanzioniCollectionTemp = ZprogrammazioneSanzioniDAL.GetByIdProgrammazione(_dbProviderObj, IdprogrammazioneEqualThis);
            ZprogrammazioneSanzioniCollectionTemp.Provider = this;
            return ZprogrammazioneSanzioniCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPROGRAMMAZIONE_SANZIONI>
  <ViewName>vzPROGRAMMAZIONE_SANZIONI</ViewName>
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
    <GetByIdProgrammazione OrderBy="ORDER BY Cod_Sanzione">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
    </GetByIdProgrammazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPROGRAMMAZIONE_SANZIONI>
*/
