using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Zpsr
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IZpsrProvider
    {
        int Save(Zpsr ZpsrObj);
        int SaveCollection(ZpsrCollection collectionObj);
        int Delete(Zpsr ZpsrObj);
        int DeleteCollection(ZpsrCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Zpsr
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Zpsr : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.StringNT _Codice;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.IntNT _AnnoDa;
        private NullTypes.IntNT _AnnoA;
        private NullTypes.IntNT _ProfonditaAlbero;
        private NullTypes.StringNT _Cci;
        [NonSerialized]
        private IZpsrProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZpsrProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Zpsr()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:CODICE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Codice
        {
            get { return _Codice; }
            set
            {
                if (Codice != value)
                {
                    _Codice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(255)
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
        /// Corrisponde al campo:ANNO_DA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AnnoDa
        {
            get { return _AnnoDa; }
            set
            {
                if (AnnoDa != value)
                {
                    _AnnoDa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ANNO_A
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AnnoA
        {
            get { return _AnnoA; }
            set
            {
                if (AnnoA != value)
                {
                    _AnnoA = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROFONDITA_ALBERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT ProfonditaAlbero
        {
            get { return _ProfonditaAlbero; }
            set
            {
                if (ProfonditaAlbero != value)
                {
                    _ProfonditaAlbero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CCI
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Cci
        {
            get { return _Cci; }
            set
            {
                if (Cci != value)
                {
                    _Cci = value;
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
    /// Summary description for ZpsrCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZpsrCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ZpsrCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Zpsr)info.GetValue(i.ToString(), typeof(Zpsr)));
            }
        }

        //Costruttore
        public ZpsrCollection()
        {
            this.ItemType = typeof(Zpsr);
        }

        //Costruttore con provider
        public ZpsrCollection(IZpsrProvider providerObj)
        {
            this.ItemType = typeof(Zpsr);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Zpsr this[int index]
        {
            get { return (Zpsr)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ZpsrCollection GetChanges()
        {
            return (ZpsrCollection)base.GetChanges();
        }

        [NonSerialized]
        private IZpsrProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZpsrProvider Provider
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
        public int Add(Zpsr ZpsrObj)
        {
            if (ZpsrObj.Provider == null) ZpsrObj.Provider = this.Provider;
            return base.Add(ZpsrObj);
        }

        //AddCollection
        public void AddCollection(ZpsrCollection ZpsrCollectionObj)
        {
            foreach (Zpsr ZpsrObj in ZpsrCollectionObj)
                this.Add(ZpsrObj);
        }

        //Insert
        public void Insert(int index, Zpsr ZpsrObj)
        {
            if (ZpsrObj.Provider == null) ZpsrObj.Provider = this.Provider;
            base.Insert(index, ZpsrObj);
        }

        //CollectionGetById
        public Zpsr CollectionGetById(NullTypes.StringNT CodiceValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Codice == CodiceValue))
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
        public ZpsrCollection SubSelect(NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT AnnoDaEqualThis,
NullTypes.IntNT AnnoAEqualThis, NullTypes.IntNT ProfonditaAlberoEqualThis, NullTypes.StringNT CciEqualThis)
        {
            ZpsrCollection ZpsrCollectionTemp = new ZpsrCollection();
            foreach (Zpsr ZpsrItem in this)
            {
                if (((CodiceEqualThis == null) || ((ZpsrItem.Codice != null) && (ZpsrItem.Codice.Value == CodiceEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ZpsrItem.Descrizione != null) && (ZpsrItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AnnoDaEqualThis == null) || ((ZpsrItem.AnnoDa != null) && (ZpsrItem.AnnoDa.Value == AnnoDaEqualThis.Value))) &&
((AnnoAEqualThis == null) || ((ZpsrItem.AnnoA != null) && (ZpsrItem.AnnoA.Value == AnnoAEqualThis.Value))) && ((ProfonditaAlberoEqualThis == null) || ((ZpsrItem.ProfonditaAlbero != null) && (ZpsrItem.ProfonditaAlbero.Value == ProfonditaAlberoEqualThis.Value))) && ((CciEqualThis == null) || ((ZpsrItem.Cci != null) && (ZpsrItem.Cci.Value == CciEqualThis.Value))))
                {
                    ZpsrCollectionTemp.Add(ZpsrItem);
                }
            }
            return ZpsrCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ZpsrDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ZpsrDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Zpsr ZpsrObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Codice", ZpsrObj.Codice);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ZpsrObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "AnnoDa", ZpsrObj.AnnoDa);
            DbProvider.SetCmdParam(cmd, firstChar + "AnnoA", ZpsrObj.AnnoA);
            DbProvider.SetCmdParam(cmd, firstChar + "ProfonditaAlbero", ZpsrObj.ProfonditaAlbero);
            DbProvider.SetCmdParam(cmd, firstChar + "Cci", ZpsrObj.Cci);
        }
        //Insert
        private static int Insert(DbProvider db, Zpsr ZpsrObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZZpsrInsert", new string[] {"Codice", "Descrizione", "AnnoDa", 
"AnnoA", "ProfonditaAlbero", "Cci"}, new string[] {"string", "string", "int", 
"int", "int", "string"}, "");
                CompileIUCmd(false, insertCmd, ZpsrObj, db.CommandFirstChar);
                i = db.Execute(insertCmd);
                ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZpsrObj.IsDirty = false;
                ZpsrObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Zpsr ZpsrObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZpsrUpdate", new string[] {"Codice", "Descrizione", "AnnoDa", 
"AnnoA", "ProfonditaAlbero", "Cci"}, new string[] {"string", "string", "int", 
"int", "int", "string"}, "");
                CompileIUCmd(true, updateCmd, ZpsrObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZpsrObj.IsDirty = false;
                ZpsrObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Zpsr ZpsrObj)
        {
            switch (ZpsrObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ZpsrObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ZpsrObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ZpsrObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ZpsrCollection ZpsrCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZpsrUpdate", new string[] {"Codice", "Descrizione", "AnnoDa", 
"AnnoA", "ProfonditaAlbero", "Cci"}, new string[] {"string", "string", "int", 
"int", "int", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZZpsrInsert", new string[] {"Codice", "Descrizione", "AnnoDa", 
"AnnoA", "ProfonditaAlbero", "Cci"}, new string[] {"string", "string", "int", 
"int", "int", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZZpsrDelete", new string[] { "Codice" }, new string[] { "string" }, "");
                for (int i = 0; i < ZpsrCollectionObj.Count; i++)
                {
                    switch (ZpsrCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ZpsrCollectionObj[i], db.CommandFirstChar);
                                returnValue += db.Execute(insertCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ZpsrCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ZpsrCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)ZpsrCollectionObj[i].Codice);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ZpsrCollectionObj.Count; i++)
                {
                    if ((ZpsrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZpsrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZpsrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ZpsrCollectionObj[i].IsDirty = false;
                        ZpsrCollectionObj[i].IsPersistent = true;
                    }
                    if ((ZpsrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ZpsrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZpsrCollectionObj[i].IsDirty = false;
                        ZpsrCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Zpsr ZpsrObj)
        {
            int returnValue = 0;
            if (ZpsrObj.IsPersistent)
            {
                returnValue = Delete(db, ZpsrObj.Codice);
            }
            ZpsrObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ZpsrObj.IsDirty = false;
            ZpsrObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, string CodiceValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZpsrDelete", new string[] { "Codice" }, new string[] { "string" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ZpsrCollection ZpsrCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZpsrDelete", new string[] { "Codice" }, new string[] { "string" }, "");
                for (int i = 0; i < ZpsrCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Codice", ZpsrCollectionObj[i].Codice);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ZpsrCollectionObj.Count; i++)
                {
                    if ((ZpsrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZpsrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZpsrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZpsrCollectionObj[i].IsDirty = false;
                        ZpsrCollectionObj[i].IsPersistent = false;
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
        public static Zpsr GetById(DbProvider db, string CodiceValue)
        {
            Zpsr ZpsrObj = null;
            IDbCommand readCmd = db.InitCmd("ZZpsrGetById", new string[] { "Codice" }, new string[] { "string" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ZpsrObj = GetFromDatareader(db);
                ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZpsrObj.IsDirty = false;
                ZpsrObj.IsPersistent = true;
            }
            db.Close();
            return ZpsrObj;
        }

        //getFromDatareader
        public static Zpsr GetFromDatareader(DbProvider db)
        {
            Zpsr ZpsrObj = new Zpsr();
            ZpsrObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
            ZpsrObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            ZpsrObj.AnnoDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_DA"]);
            ZpsrObj.AnnoA = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_A"]);
            ZpsrObj.ProfonditaAlbero = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROFONDITA_ALBERO"]);
            ZpsrObj.Cci = new SiarLibrary.NullTypes.StringNT(db.DataReader["CCI"]);
            ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ZpsrObj.IsDirty = false;
            ZpsrObj.IsPersistent = true;
            return ZpsrObj;
        }

        //Find Select

        public static ZpsrCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT AnnoDaEqualThis,
SiarLibrary.NullTypes.IntNT AnnoAEqualThis, SiarLibrary.NullTypes.IntNT ProfonditaAlberoEqualThis, SiarLibrary.NullTypes.StringNT CciEqualThis)
        {

            ZpsrCollection ZpsrCollectionObj = new ZpsrCollection();

            IDbCommand findCmd = db.InitCmd("Zzpsrfindselect", new string[] {"Codiceequalthis", "Descrizioneequalthis", "AnnoDaequalthis", 
"AnnoAequalthis", "ProfonditaAlberoequalthis", "Cciequalthis"}, new string[] {"string", "string", "int", 
"int", "int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoDaequalthis", AnnoDaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoAequalthis", AnnoAEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProfonditaAlberoequalthis", ProfonditaAlberoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Cciequalthis", CciEqualThis);
            Zpsr ZpsrObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZpsrObj = GetFromDatareader(db);
                ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZpsrObj.IsDirty = false;
                ZpsrObj.IsPersistent = true;
                ZpsrCollectionObj.Add(ZpsrObj);
            }
            db.Close();
            return ZpsrCollectionObj;
        }

        //Find Find

        public static ZpsrCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.IntNT AnnoDaEqualThis, SiarLibrary.NullTypes.IntNT AnnoAEqualThis)
        {

            ZpsrCollection ZpsrCollectionObj = new ZpsrCollection();

            IDbCommand findCmd = db.InitCmd("Zzpsrfindfind", new string[] { "Descrizionelikethis", "AnnoDaequalthis", "AnnoAequalthis" }, new string[] { "string", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoDaequalthis", AnnoDaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AnnoAequalthis", AnnoAEqualThis);
            Zpsr ZpsrObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZpsrObj = GetFromDatareader(db);
                ZpsrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZpsrObj.IsDirty = false;
                ZpsrObj.IsPersistent = true;
                ZpsrCollectionObj.Add(ZpsrObj);
            }
            db.Close();
            return ZpsrCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ZpsrCollectionProvider:IZpsrProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZpsrCollectionProvider : IZpsrProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Zpsr
        protected ZpsrCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ZpsrCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ZpsrCollection(this);
        }

        //Costruttore 2: popola la collection
        public ZpsrCollectionProvider(StringNT DescrizioneLikeThis, IntNT AnnodaEqualThis, IntNT AnnoaEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(DescrizioneLikeThis, AnnodaEqualThis, AnnoaEqualThis);
        }

        //Costruttore3: ha in input zpsrCollectionObj - non popola la collection
        public ZpsrCollectionProvider(ZpsrCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ZpsrCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ZpsrCollection(this);
        }

        //Get e Set
        public ZpsrCollection CollectionObj
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
        public int SaveCollection(ZpsrCollection collectionObj)
        {
            return ZpsrDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Zpsr zpsrObj)
        {
            return ZpsrDAL.Save(_dbProviderObj, zpsrObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ZpsrCollection collectionObj)
        {
            return ZpsrDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Zpsr zpsrObj)
        {
            return ZpsrDAL.Delete(_dbProviderObj, zpsrObj);
        }

        //getById
        public Zpsr GetById(StringNT CodiceValue)
        {
            Zpsr ZpsrTemp = ZpsrDAL.GetById(_dbProviderObj, CodiceValue);
            if (ZpsrTemp != null) ZpsrTemp.Provider = this;
            return ZpsrTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ZpsrCollection Select(StringNT CodiceEqualThis, StringNT DescrizioneEqualThis, IntNT AnnodaEqualThis,
IntNT AnnoaEqualThis, IntNT ProfonditaalberoEqualThis, StringNT CciEqualThis)
        {
            ZpsrCollection ZpsrCollectionTemp = ZpsrDAL.Select(_dbProviderObj, CodiceEqualThis, DescrizioneEqualThis, AnnodaEqualThis,
AnnoaEqualThis, ProfonditaalberoEqualThis, CciEqualThis);
            ZpsrCollectionTemp.Provider = this;
            return ZpsrCollectionTemp;
        }

        //Find: popola la collection
        public ZpsrCollection Find(StringNT DescrizioneLikeThis, IntNT AnnodaEqualThis, IntNT AnnoaEqualThis)
        {
            ZpsrCollection ZpsrCollectionTemp = ZpsrDAL.Find(_dbProviderObj, DescrizioneLikeThis, AnnodaEqualThis, AnnoaEqualThis);
            ZpsrCollectionTemp.Provider = this;
            return ZpsrCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPSR>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <DESCRIZIONE>Like</DESCRIZIONE>
      <ANNO_DA>Equal</ANNO_DA>
      <ANNO_A>Equal</ANNO_A>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPSR>
*/
