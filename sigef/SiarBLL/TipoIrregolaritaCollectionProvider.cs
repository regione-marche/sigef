using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TipoIrregolarita
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITipoIrregolaritaProvider
    {
        int Save(TipoIrregolarita TipoIrregolaritaObj);
        int SaveCollection(TipoIrregolaritaCollection collectionObj);
        int Delete(TipoIrregolarita TipoIrregolaritaObj);
        int DeleteCollection(TipoIrregolaritaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TipoIrregolarita
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TipoIrregolarita : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTipo;
        private NullTypes.StringNT _Tipo;
        private NullTypes.BoolNT _Attivo;
        [NonSerialized] private ITipoIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITipoIrregolaritaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TipoIrregolarita()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_TIPO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipo
        {
            get { return _IdTipo; }
            set
            {
                if (IdTipo != value)
                {
                    _IdTipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Tipo
        {
            get { return _Tipo; }
            set
            {
                if (Tipo != value)
                {
                    _Tipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVO
        /// Tipo sul db:BIT
        /// Default:((1))
        /// </summary>
        public NullTypes.BoolNT Attivo
        {
            get { return _Attivo; }
            set
            {
                if (Attivo != value)
                {
                    _Attivo = value;
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
    /// Summary description for TipoIrregolaritaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TipoIrregolaritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TipoIrregolaritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TipoIrregolarita)info.GetValue(i.ToString(), typeof(TipoIrregolarita)));
            }
        }

        //Costruttore
        public TipoIrregolaritaCollection()
        {
            this.ItemType = typeof(TipoIrregolarita);
        }

        //Costruttore con provider
        public TipoIrregolaritaCollection(ITipoIrregolaritaProvider providerObj)
        {
            this.ItemType = typeof(TipoIrregolarita);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TipoIrregolarita this[int index]
        {
            get { return (TipoIrregolarita)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TipoIrregolaritaCollection GetChanges()
        {
            return (TipoIrregolaritaCollection)base.GetChanges();
        }

        [NonSerialized] private ITipoIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITipoIrregolaritaProvider Provider
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
        public int Add(TipoIrregolarita TipoIrregolaritaObj)
        {
            if (TipoIrregolaritaObj.Provider == null) TipoIrregolaritaObj.Provider = this.Provider;
            return base.Add(TipoIrregolaritaObj);
        }

        //AddCollection
        public void AddCollection(TipoIrregolaritaCollection TipoIrregolaritaCollectionObj)
        {
            foreach (TipoIrregolarita TipoIrregolaritaObj in TipoIrregolaritaCollectionObj)
                this.Add(TipoIrregolaritaObj);
        }

        //Insert
        public void Insert(int index, TipoIrregolarita TipoIrregolaritaObj)
        {
            if (TipoIrregolaritaObj.Provider == null) TipoIrregolaritaObj.Provider = this.Provider;
            base.Insert(index, TipoIrregolaritaObj);
        }

        //CollectionGetById
        public TipoIrregolarita CollectionGetById(NullTypes.IntNT IdTipoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTipo == IdTipoValue))
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
        public TipoIrregolaritaCollection SubSelect(NullTypes.IntNT IdTipoEqualThis, NullTypes.StringNT TipoEqualThis, NullTypes.BoolNT AttivoEqualThis)
        {
            TipoIrregolaritaCollection TipoIrregolaritaCollectionTemp = new TipoIrregolaritaCollection();
            foreach (TipoIrregolarita TipoIrregolaritaItem in this)
            {
                if (((IdTipoEqualThis == null) || ((TipoIrregolaritaItem.IdTipo != null) && (TipoIrregolaritaItem.IdTipo.Value == IdTipoEqualThis.Value))) && ((TipoEqualThis == null) || ((TipoIrregolaritaItem.Tipo != null) && (TipoIrregolaritaItem.Tipo.Value == TipoEqualThis.Value))) && ((AttivoEqualThis == null) || ((TipoIrregolaritaItem.Attivo != null) && (TipoIrregolaritaItem.Attivo.Value == AttivoEqualThis.Value))))
                {
                    TipoIrregolaritaCollectionTemp.Add(TipoIrregolaritaItem);
                }
            }
            return TipoIrregolaritaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TipoIrregolaritaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TipoIrregolaritaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoIrregolarita TipoIrregolaritaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTipo", TipoIrregolaritaObj.IdTipo);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Tipo", TipoIrregolaritaObj.Tipo);
            DbProvider.SetCmdParam(cmd, firstChar + "Attivo", TipoIrregolaritaObj.Attivo);
        }
        //Insert
        private static int Insert(DbProvider db, TipoIrregolarita TipoIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTipoIrregolaritaInsert", new string[] { "Tipo", "Attivo" }, new string[] { "string", "bool" }, "");
                CompileIUCmd(false, insertCmd, TipoIrregolaritaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TipoIrregolaritaObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
                    TipoIrregolaritaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
                }
                TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoIrregolaritaObj.IsDirty = false;
                TipoIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TipoIrregolarita TipoIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTipoIrregolaritaUpdate", new string[] { "IdTipo", "Tipo", "Attivo" }, new string[] { "int", "string", "bool" }, "");
                CompileIUCmd(true, updateCmd, TipoIrregolaritaObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoIrregolaritaObj.IsDirty = false;
                TipoIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TipoIrregolarita TipoIrregolaritaObj)
        {
            switch (TipoIrregolaritaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TipoIrregolaritaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TipoIrregolaritaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TipoIrregolaritaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TipoIrregolaritaCollection TipoIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTipoIrregolaritaUpdate", new string[] { "IdTipo", "Tipo", "Attivo" }, new string[] { "int", "string", "bool" }, "");
                IDbCommand insertCmd = db.InitCmd("ZTipoIrregolaritaInsert", new string[] { "Tipo", "Attivo" }, new string[] { "string", "bool" }, "");
                IDbCommand deleteCmd = db.InitCmd("ZTipoIrregolaritaDelete", new string[] { "IdTipo" }, new string[] { "int" }, "");
                for (int i = 0; i < TipoIrregolaritaCollectionObj.Count; i++)
                {
                    switch (TipoIrregolaritaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TipoIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TipoIrregolaritaCollectionObj[i].IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
                                    TipoIrregolaritaCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TipoIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TipoIrregolaritaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)TipoIrregolaritaCollectionObj[i].IdTipo);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TipoIrregolaritaCollectionObj.Count; i++)
                {
                    if ((TipoIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TipoIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TipoIrregolaritaCollectionObj[i].IsDirty = false;
                        TipoIrregolaritaCollectionObj[i].IsPersistent = true;
                    }
                    if ((TipoIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TipoIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TipoIrregolaritaCollectionObj[i].IsDirty = false;
                        TipoIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TipoIrregolarita TipoIrregolaritaObj)
        {
            int returnValue = 0;
            if (TipoIrregolaritaObj.IsPersistent)
            {
                returnValue = Delete(db, TipoIrregolaritaObj.IdTipo);
            }
            TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TipoIrregolaritaObj.IsDirty = false;
            TipoIrregolaritaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTipoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTipoIrregolaritaDelete", new string[] { "IdTipo" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)IdTipoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TipoIrregolaritaCollection TipoIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTipoIrregolaritaDelete", new string[] { "IdTipo" }, new string[] { "int" }, "");
                for (int i = 0; i < TipoIrregolaritaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipo", TipoIrregolaritaCollectionObj[i].IdTipo);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TipoIrregolaritaCollectionObj.Count; i++)
                {
                    if ((TipoIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TipoIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TipoIrregolaritaCollectionObj[i].IsDirty = false;
                        TipoIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static TipoIrregolarita GetById(DbProvider db, int IdTipoValue)
        {
            TipoIrregolarita TipoIrregolaritaObj = null;
            IDbCommand readCmd = db.InitCmd("ZTipoIrregolaritaGetById", new string[] { "IdTipo" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)IdTipoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TipoIrregolaritaObj = GetFromDatareader(db);
                TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoIrregolaritaObj.IsDirty = false;
                TipoIrregolaritaObj.IsPersistent = true;
            }
            db.Close();
            return TipoIrregolaritaObj;
        }

        //getFromDatareader
        public static TipoIrregolarita GetFromDatareader(DbProvider db)
        {
            TipoIrregolarita TipoIrregolaritaObj = new TipoIrregolarita();
            TipoIrregolaritaObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
            TipoIrregolaritaObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
            TipoIrregolaritaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
            TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TipoIrregolaritaObj.IsDirty = false;
            TipoIrregolaritaObj.IsPersistent = true;
            return TipoIrregolaritaObj;
        }

        //Find Select

        public static TipoIrregolaritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

        {

            TipoIrregolaritaCollection TipoIrregolaritaCollectionObj = new TipoIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Ztipoirregolaritafindselect", new string[] { "IdTipoequalthis", "Tipoequalthis", "Attivoequalthis" }, new string[] { "int", "string", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            TipoIrregolarita TipoIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TipoIrregolaritaObj = GetFromDatareader(db);
                TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoIrregolaritaObj.IsDirty = false;
                TipoIrregolaritaObj.IsPersistent = true;
                TipoIrregolaritaCollectionObj.Add(TipoIrregolaritaObj);
            }
            db.Close();
            return TipoIrregolaritaCollectionObj;
        }

        //Find Find

        public static TipoIrregolaritaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

        {

            TipoIrregolaritaCollection TipoIrregolaritaCollectionObj = new TipoIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Ztipoirregolaritafindfind", new string[] { "Tipoequalthis", "Attivoequalthis" }, new string[] { "string", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            TipoIrregolarita TipoIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TipoIrregolaritaObj = GetFromDatareader(db);
                TipoIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoIrregolaritaObj.IsDirty = false;
                TipoIrregolaritaObj.IsPersistent = true;
                TipoIrregolaritaCollectionObj.Add(TipoIrregolaritaObj);
            }
            db.Close();
            return TipoIrregolaritaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TipoIrregolaritaCollectionProvider:ITipoIrregolaritaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TipoIrregolaritaCollectionProvider : ITipoIrregolaritaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TipoIrregolarita
        protected TipoIrregolaritaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TipoIrregolaritaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TipoIrregolaritaCollection(this);
        }

        //Costruttore 2: popola la collection
        public TipoIrregolaritaCollectionProvider(StringNT TipoEqualThis, BoolNT AttivoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(TipoEqualThis, AttivoEqualThis);
        }

        //Costruttore3: ha in input tipoirregolaritaCollectionObj - non popola la collection
        public TipoIrregolaritaCollectionProvider(TipoIrregolaritaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TipoIrregolaritaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TipoIrregolaritaCollection(this);
        }

        //Get e Set
        public TipoIrregolaritaCollection CollectionObj
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
        public int SaveCollection(TipoIrregolaritaCollection collectionObj)
        {
            return TipoIrregolaritaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TipoIrregolarita tipoirregolaritaObj)
        {
            return TipoIrregolaritaDAL.Save(_dbProviderObj, tipoirregolaritaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TipoIrregolaritaCollection collectionObj)
        {
            return TipoIrregolaritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TipoIrregolarita tipoirregolaritaObj)
        {
            return TipoIrregolaritaDAL.Delete(_dbProviderObj, tipoirregolaritaObj);
        }

        //getById
        public TipoIrregolarita GetById(IntNT IdTipoValue)
        {
            TipoIrregolarita TipoIrregolaritaTemp = TipoIrregolaritaDAL.GetById(_dbProviderObj, IdTipoValue);
            if (TipoIrregolaritaTemp != null) TipoIrregolaritaTemp.Provider = this;
            return TipoIrregolaritaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public TipoIrregolaritaCollection Select(IntNT IdtipoEqualThis, StringNT TipoEqualThis, BoolNT AttivoEqualThis)
        {
            TipoIrregolaritaCollection TipoIrregolaritaCollectionTemp = TipoIrregolaritaDAL.Select(_dbProviderObj, IdtipoEqualThis, TipoEqualThis, AttivoEqualThis);
            TipoIrregolaritaCollectionTemp.Provider = this;
            return TipoIrregolaritaCollectionTemp;
        }

        //Find: popola la collection
        public TipoIrregolaritaCollection Find(StringNT TipoEqualThis, BoolNT AttivoEqualThis)
        {
            TipoIrregolaritaCollection TipoIrregolaritaCollectionTemp = TipoIrregolaritaDAL.Find(_dbProviderObj, TipoEqualThis, AttivoEqualThis);
            TipoIrregolaritaCollectionTemp.Provider = this;
            return TipoIrregolaritaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_IRREGOLARITA>
  <ViewName>VTIPO_IRREGOLARITA</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <TIPO>Equal</TIPO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_IRREGOLARITA>
*/
