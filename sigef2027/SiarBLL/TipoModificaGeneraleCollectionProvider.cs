using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TipoModificaGenerale
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITipoModificaGeneraleProvider
    {
        int Save(TipoModificaGenerale TipoModificaGeneraleObj);
        int SaveCollection(TipoModificaGeneraleCollection collectionObj);
        int Delete(TipoModificaGenerale TipoModificaGeneraleObj);
        int DeleteCollection(TipoModificaGeneraleCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TipoModificaGenerale
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TipoModificaGenerale : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTipoModifica;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.BoolNT _Attivo;
        [NonSerialized] private ITipoModificaGeneraleProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITipoModificaGeneraleProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TipoModificaGenerale()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_TIPO_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoModifica
        {
            get { return _IdTipoModifica; }
            set
            {
                if (IdTipoModifica != value)
                {
                    _IdTipoModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                if (Descrizione != value)
                {
                    _Descrizione = value;
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
    /// Summary description for TipoModificaGeneraleCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TipoModificaGeneraleCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TipoModificaGeneraleCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TipoModificaGenerale)info.GetValue(i.ToString(), typeof(TipoModificaGenerale)));
            }
        }

        //Costruttore
        public TipoModificaGeneraleCollection()
        {
            this.ItemType = typeof(TipoModificaGenerale);
        }

        //Costruttore con provider
        public TipoModificaGeneraleCollection(ITipoModificaGeneraleProvider providerObj)
        {
            this.ItemType = typeof(TipoModificaGenerale);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TipoModificaGenerale this[int index]
        {
            get { return (TipoModificaGenerale)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TipoModificaGeneraleCollection GetChanges()
        {
            return (TipoModificaGeneraleCollection)base.GetChanges();
        }

        [NonSerialized] private ITipoModificaGeneraleProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITipoModificaGeneraleProvider Provider
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
        public int Add(TipoModificaGenerale TipoModificaGeneraleObj)
        {
            if (TipoModificaGeneraleObj.Provider == null) TipoModificaGeneraleObj.Provider = this.Provider;
            return base.Add(TipoModificaGeneraleObj);
        }

        //AddCollection
        public void AddCollection(TipoModificaGeneraleCollection TipoModificaGeneraleCollectionObj)
        {
            foreach (TipoModificaGenerale TipoModificaGeneraleObj in TipoModificaGeneraleCollectionObj)
                this.Add(TipoModificaGeneraleObj);
        }

        //Insert
        public void Insert(int index, TipoModificaGenerale TipoModificaGeneraleObj)
        {
            if (TipoModificaGeneraleObj.Provider == null) TipoModificaGeneraleObj.Provider = this.Provider;
            base.Insert(index, TipoModificaGeneraleObj);
        }

        //CollectionGetById
        public TipoModificaGenerale CollectionGetById(NullTypes.IntNT IdTipoModificaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTipoModifica == IdTipoModificaValue))
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
        public TipoModificaGeneraleCollection SubSelect(NullTypes.IntNT IdTipoModificaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AttivoEqualThis)
        {
            TipoModificaGeneraleCollection TipoModificaGeneraleCollectionTemp = new TipoModificaGeneraleCollection();
            foreach (TipoModificaGenerale TipoModificaGeneraleItem in this)
            {
                if (((IdTipoModificaEqualThis == null) || ((TipoModificaGeneraleItem.IdTipoModifica != null) && (TipoModificaGeneraleItem.IdTipoModifica.Value == IdTipoModificaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoModificaGeneraleItem.Descrizione != null) && (TipoModificaGeneraleItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AttivoEqualThis == null) || ((TipoModificaGeneraleItem.Attivo != null) && (TipoModificaGeneraleItem.Attivo.Value == AttivoEqualThis.Value))))
                {
                    TipoModificaGeneraleCollectionTemp.Add(TipoModificaGeneraleItem);
                }
            }
            return TipoModificaGeneraleCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TipoModificaGeneraleDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TipoModificaGeneraleDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoModificaGenerale TipoModificaGeneraleObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTipoModifica", TipoModificaGeneraleObj.IdTipoModifica);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", TipoModificaGeneraleObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Attivo", TipoModificaGeneraleObj.Attivo);
        }
        //Insert
        private static int Insert(DbProvider db, TipoModificaGenerale TipoModificaGeneraleObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTipoModificaGeneraleInsert", new string[] { "Descrizione", "Attivo" }, new string[] { "string", "bool" }, "");
                CompileIUCmd(false, insertCmd, TipoModificaGeneraleObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TipoModificaGeneraleObj.IdTipoModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_MODIFICA"]);
                    TipoModificaGeneraleObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
                }
                TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoModificaGeneraleObj.IsDirty = false;
                TipoModificaGeneraleObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TipoModificaGenerale TipoModificaGeneraleObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTipoModificaGeneraleUpdate", new string[] { "IdTipoModifica", "Descrizione", "Attivo" }, new string[] { "int", "string", "bool" }, "");
                CompileIUCmd(true, updateCmd, TipoModificaGeneraleObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoModificaGeneraleObj.IsDirty = false;
                TipoModificaGeneraleObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TipoModificaGenerale TipoModificaGeneraleObj)
        {
            switch (TipoModificaGeneraleObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TipoModificaGeneraleObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TipoModificaGeneraleObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TipoModificaGeneraleObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TipoModificaGeneraleCollection TipoModificaGeneraleCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTipoModificaGeneraleUpdate", new string[] { "IdTipoModifica", "Descrizione", "Attivo" }, new string[] { "int", "string", "bool" }, "");
                IDbCommand insertCmd = db.InitCmd("ZTipoModificaGeneraleInsert", new string[] { "Descrizione", "Attivo" }, new string[] { "string", "bool" }, "");
                IDbCommand deleteCmd = db.InitCmd("ZTipoModificaGeneraleDelete", new string[] { "IdTipoModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < TipoModificaGeneraleCollectionObj.Count; i++)
                {
                    switch (TipoModificaGeneraleCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TipoModificaGeneraleCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TipoModificaGeneraleCollectionObj[i].IdTipoModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_MODIFICA"]);
                                    TipoModificaGeneraleCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TipoModificaGeneraleCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TipoModificaGeneraleCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipoModifica", (SiarLibrary.NullTypes.IntNT)TipoModificaGeneraleCollectionObj[i].IdTipoModifica);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TipoModificaGeneraleCollectionObj.Count; i++)
                {
                    if ((TipoModificaGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoModificaGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TipoModificaGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TipoModificaGeneraleCollectionObj[i].IsDirty = false;
                        TipoModificaGeneraleCollectionObj[i].IsPersistent = true;
                    }
                    if ((TipoModificaGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TipoModificaGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TipoModificaGeneraleCollectionObj[i].IsDirty = false;
                        TipoModificaGeneraleCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TipoModificaGenerale TipoModificaGeneraleObj)
        {
            int returnValue = 0;
            if (TipoModificaGeneraleObj.IsPersistent)
            {
                returnValue = Delete(db, TipoModificaGeneraleObj.IdTipoModifica);
            }
            TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TipoModificaGeneraleObj.IsDirty = false;
            TipoModificaGeneraleObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTipoModificaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTipoModificaGeneraleDelete", new string[] { "IdTipoModifica" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipoModifica", (SiarLibrary.NullTypes.IntNT)IdTipoModificaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TipoModificaGeneraleCollection TipoModificaGeneraleCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTipoModificaGeneraleDelete", new string[] { "IdTipoModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < TipoModificaGeneraleCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTipoModifica", TipoModificaGeneraleCollectionObj[i].IdTipoModifica);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TipoModificaGeneraleCollectionObj.Count; i++)
                {
                    if ((TipoModificaGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoModificaGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TipoModificaGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TipoModificaGeneraleCollectionObj[i].IsDirty = false;
                        TipoModificaGeneraleCollectionObj[i].IsPersistent = false;
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
        public static TipoModificaGenerale GetById(DbProvider db, int IdTipoModificaValue)
        {
            TipoModificaGenerale TipoModificaGeneraleObj = null;
            IDbCommand readCmd = db.InitCmd("ZTipoModificaGeneraleGetById", new string[] { "IdTipoModifica" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTipoModifica", (SiarLibrary.NullTypes.IntNT)IdTipoModificaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TipoModificaGeneraleObj = GetFromDatareader(db);
                TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoModificaGeneraleObj.IsDirty = false;
                TipoModificaGeneraleObj.IsPersistent = true;
            }
            db.Close();
            return TipoModificaGeneraleObj;
        }

        //getFromDatareader
        public static TipoModificaGenerale GetFromDatareader(DbProvider db)
        {
            TipoModificaGenerale TipoModificaGeneraleObj = new TipoModificaGenerale();
            TipoModificaGeneraleObj.IdTipoModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_MODIFICA"]);
            TipoModificaGeneraleObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            TipoModificaGeneraleObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
            TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TipoModificaGeneraleObj.IsDirty = false;
            TipoModificaGeneraleObj.IsPersistent = true;
            return TipoModificaGeneraleObj;
        }

        //Find Select

        public static TipoModificaGeneraleCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoModificaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

        {

            TipoModificaGeneraleCollection TipoModificaGeneraleCollectionObj = new TipoModificaGeneraleCollection();

            IDbCommand findCmd = db.InitCmd("Ztipomodificageneralefindselect", new string[] { "IdTipoModificaequalthis", "Descrizioneequalthis", "Attivoequalthis" }, new string[] { "int", "string", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoModificaequalthis", IdTipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            TipoModificaGenerale TipoModificaGeneraleObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TipoModificaGeneraleObj = GetFromDatareader(db);
                TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoModificaGeneraleObj.IsDirty = false;
                TipoModificaGeneraleObj.IsPersistent = true;
                TipoModificaGeneraleCollectionObj.Add(TipoModificaGeneraleObj);
            }
            db.Close();
            return TipoModificaGeneraleCollectionObj;
        }

        //Find Find

        public static TipoModificaGeneraleCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoModificaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

        {

            TipoModificaGeneraleCollection TipoModificaGeneraleCollectionObj = new TipoModificaGeneraleCollection();

            IDbCommand findCmd = db.InitCmd("Ztipomodificageneralefindfind", new string[] { "IdTipoModificaequalthis", "Descrizioneequalthis", "Attivoequalthis" }, new string[] { "int", "string", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoModificaequalthis", IdTipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            TipoModificaGenerale TipoModificaGeneraleObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TipoModificaGeneraleObj = GetFromDatareader(db);
                TipoModificaGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TipoModificaGeneraleObj.IsDirty = false;
                TipoModificaGeneraleObj.IsPersistent = true;
                TipoModificaGeneraleCollectionObj.Add(TipoModificaGeneraleObj);
            }
            db.Close();
            return TipoModificaGeneraleCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TipoModificaGeneraleCollectionProvider:ITipoModificaGeneraleProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TipoModificaGeneraleCollectionProvider : ITipoModificaGeneraleProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TipoModificaGenerale
        protected TipoModificaGeneraleCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TipoModificaGeneraleCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TipoModificaGeneraleCollection(this);
        }

        //Costruttore 2: popola la collection
        public TipoModificaGeneraleCollectionProvider(IntNT IdtipomodificaEqualThis, StringNT DescrizioneEqualThis, BoolNT AttivoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdtipomodificaEqualThis, DescrizioneEqualThis, AttivoEqualThis);
        }

        //Costruttore3: ha in input tipomodificageneraleCollectionObj - non popola la collection
        public TipoModificaGeneraleCollectionProvider(TipoModificaGeneraleCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TipoModificaGeneraleCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TipoModificaGeneraleCollection(this);
        }

        //Get e Set
        public TipoModificaGeneraleCollection CollectionObj
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
        public int SaveCollection(TipoModificaGeneraleCollection collectionObj)
        {
            return TipoModificaGeneraleDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TipoModificaGenerale tipomodificageneraleObj)
        {
            return TipoModificaGeneraleDAL.Save(_dbProviderObj, tipomodificageneraleObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TipoModificaGeneraleCollection collectionObj)
        {
            return TipoModificaGeneraleDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TipoModificaGenerale tipomodificageneraleObj)
        {
            return TipoModificaGeneraleDAL.Delete(_dbProviderObj, tipomodificageneraleObj);
        }

        //getById
        public TipoModificaGenerale GetById(IntNT IdTipoModificaValue)
        {
            TipoModificaGenerale TipoModificaGeneraleTemp = TipoModificaGeneraleDAL.GetById(_dbProviderObj, IdTipoModificaValue);
            if (TipoModificaGeneraleTemp != null) TipoModificaGeneraleTemp.Provider = this;
            return TipoModificaGeneraleTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public TipoModificaGeneraleCollection Select(IntNT IdtipomodificaEqualThis, StringNT DescrizioneEqualThis, BoolNT AttivoEqualThis)
        {
            TipoModificaGeneraleCollection TipoModificaGeneraleCollectionTemp = TipoModificaGeneraleDAL.Select(_dbProviderObj, IdtipomodificaEqualThis, DescrizioneEqualThis, AttivoEqualThis);
            TipoModificaGeneraleCollectionTemp.Provider = this;
            return TipoModificaGeneraleCollectionTemp;
        }

        //Find: popola la collection
        public TipoModificaGeneraleCollection Find(IntNT IdtipomodificaEqualThis, StringNT DescrizioneEqualThis, BoolNT AttivoEqualThis)
        {
            TipoModificaGeneraleCollection TipoModificaGeneraleCollectionTemp = TipoModificaGeneraleDAL.Find(_dbProviderObj, IdtipomodificaEqualThis, DescrizioneEqualThis, AttivoEqualThis);
            TipoModificaGeneraleCollectionTemp.Provider = this;
            return TipoModificaGeneraleCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_MODIFICA_GENERALE>
  <ViewName>VTIPO_MODIFICA_GENERALE</ViewName>
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
      <ID_TIPO_MODIFICA>Equal</ID_TIPO_MODIFICA>
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_MODIFICA_GENERALE>
*/
