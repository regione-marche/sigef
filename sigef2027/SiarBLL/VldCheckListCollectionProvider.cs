using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per VldCheckList
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IVldCheckListProvider
    {
        int Save(VldCheckList VldCheckListObj);
        int SaveCollection(VldCheckListCollection collectionObj);
        int Delete(VldCheckList VldCheckListObj);
        int DeleteCollection(VldCheckListCollection collectionObj);
    }
    /// <summary>
    /// Summary description for VldCheckList
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VldCheckList : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _CodTipoDpagamento;
        private NullTypes.StringNT _Tpappalto;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.IntNT _Operatore;
        [NonSerialized] private IVldCheckListProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVldCheckListProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public VldCheckList()
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
        /// Corrisponde al campo:COD_TIPO_DPAGAMENTO
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT CodTipoDpagamento
        {
            get { return _CodTipoDpagamento; }
            set
            {
                if (CodTipoDpagamento != value)
                {
                    _CodTipoDpagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TPAPPALTO
        /// Tipo sul db:VARCHAR(5)
        /// </summary>
        public NullTypes.StringNT Tpappalto
        {
            get { return _Tpappalto; }
            set
            {
                if (Tpappalto != value)
                {
                    _Tpappalto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
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
        /// Corrisponde al campo:OPERATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Operatore
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
    /// Summary description for VldCheckListCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VldCheckListCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VldCheckListCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VldCheckList)info.GetValue(i.ToString(), typeof(VldCheckList)));
            }
        }

        //Costruttore
        public VldCheckListCollection()
        {
            this.ItemType = typeof(VldCheckList);
        }

        //Costruttore con provider
        public VldCheckListCollection(IVldCheckListProvider providerObj)
        {
            this.ItemType = typeof(VldCheckList);
            this.Provider = providerObj;
        }

        //Get e Set
        public new VldCheckList this[int index]
        {
            get { return (VldCheckList)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VldCheckListCollection GetChanges()
        {
            return (VldCheckListCollection)base.GetChanges();
        }

        [NonSerialized] private IVldCheckListProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVldCheckListProvider Provider
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
        public int Add(VldCheckList VldCheckListObj)
        {
            if (VldCheckListObj.Provider == null) VldCheckListObj.Provider = this.Provider;
            return base.Add(VldCheckListObj);
        }

        //AddCollection
        public void AddCollection(VldCheckListCollection VldCheckListCollectionObj)
        {
            foreach (VldCheckList VldCheckListObj in VldCheckListCollectionObj)
                this.Add(VldCheckListObj);
        }

        //Insert
        public void Insert(int index, VldCheckList VldCheckListObj)
        {
            if (VldCheckListObj.Provider == null) VldCheckListObj.Provider = this.Provider;
            base.Insert(index, VldCheckListObj);
        }

        //CollectionGetById
        public VldCheckList CollectionGetById(NullTypes.IntNT IdValue)
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
        public VldCheckListCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodTipoDpagamentoEqualThis,
NullTypes.StringNT TpappaltoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT OperatoreEqualThis)
        {
            VldCheckListCollection VldCheckListCollectionTemp = new VldCheckListCollection();
            foreach (VldCheckList VldCheckListItem in this)
            {
                if (((IdEqualThis == null) || ((VldCheckListItem.Id != null) && (VldCheckListItem.Id.Value == IdEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VldCheckListItem.Descrizione != null) && (VldCheckListItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodTipoDpagamentoEqualThis == null) || ((VldCheckListItem.CodTipoDpagamento != null) && (VldCheckListItem.CodTipoDpagamento.Value == CodTipoDpagamentoEqualThis.Value))) &&
((TpappaltoEqualThis == null) || ((VldCheckListItem.Tpappalto != null) && (VldCheckListItem.Tpappalto.Value == TpappaltoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VldCheckListItem.DataModifica != null) && (VldCheckListItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VldCheckListItem.Operatore != null) && (VldCheckListItem.Operatore.Value == OperatoreEqualThis.Value))))
                {
                    VldCheckListCollectionTemp.Add(VldCheckListItem);
                }
            }
            return VldCheckListCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VldCheckListDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VldCheckListDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VldCheckList VldCheckListObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", VldCheckListObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", VldCheckListObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipoDpagamento", VldCheckListObj.CodTipoDpagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "Tpappalto", VldCheckListObj.Tpappalto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VldCheckListObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", VldCheckListObj.Operatore);
        }
        //Insert
        private static int Insert(DbProvider db, VldCheckList VldCheckListObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZVldCheckListInsert", new string[] {"Descrizione", "CodTipoDpagamento",
"Tpappalto", "DataModifica", "Operatore"}, new string[] {"string", "string",
"string", "DateTime", "int"}, "");
                CompileIUCmd(false, insertCmd, VldCheckListObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    VldCheckListObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VldCheckListObj.IsDirty = false;
                VldCheckListObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, VldCheckList VldCheckListObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVldCheckListUpdate", new string[] {"Id", "Descrizione", "CodTipoDpagamento",
"Tpappalto", "DataModifica", "Operatore"}, new string[] {"int", "string", "string",
"string", "DateTime", "int"}, "");
                CompileIUCmd(true, updateCmd, VldCheckListObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    VldCheckListObj.DataModifica = d;
                }
                VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VldCheckListObj.IsDirty = false;
                VldCheckListObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, VldCheckList VldCheckListObj)
        {
            switch (VldCheckListObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, VldCheckListObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, VldCheckListObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, VldCheckListObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, VldCheckListCollection VldCheckListCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVldCheckListUpdate", new string[] {"Id", "Descrizione", "CodTipoDpagamento",
"Tpappalto", "DataModifica", "Operatore"}, new string[] {"int", "string", "string",
"string", "DateTime", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZVldCheckListInsert", new string[] {"Descrizione", "CodTipoDpagamento",
"Tpappalto", "DataModifica", "Operatore"}, new string[] {"string", "string",
"string", "DateTime", "int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZVldCheckListDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < VldCheckListCollectionObj.Count; i++)
                {
                    switch (VldCheckListCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, VldCheckListCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    VldCheckListCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, VldCheckListCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    VldCheckListCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (VldCheckListCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)VldCheckListCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < VldCheckListCollectionObj.Count; i++)
                {
                    if ((VldCheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldCheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VldCheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        VldCheckListCollectionObj[i].IsDirty = false;
                        VldCheckListCollectionObj[i].IsPersistent = true;
                    }
                    if ((VldCheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        VldCheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VldCheckListCollectionObj[i].IsDirty = false;
                        VldCheckListCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, VldCheckList VldCheckListObj)
        {
            int returnValue = 0;
            if (VldCheckListObj.IsPersistent)
            {
                returnValue = Delete(db, VldCheckListObj.Id);
            }
            VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            VldCheckListObj.IsDirty = false;
            VldCheckListObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVldCheckListDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, VldCheckListCollection VldCheckListCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVldCheckListDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < VldCheckListCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", VldCheckListCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < VldCheckListCollectionObj.Count; i++)
                {
                    if ((VldCheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldCheckListCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VldCheckListCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VldCheckListCollectionObj[i].IsDirty = false;
                        VldCheckListCollectionObj[i].IsPersistent = false;
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
        public static VldCheckList GetById(DbProvider db, int IdValue)
        {
            VldCheckList VldCheckListObj = null;
            IDbCommand readCmd = db.InitCmd("ZVldCheckListGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                VldCheckListObj = GetFromDatareader(db);
                VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VldCheckListObj.IsDirty = false;
                VldCheckListObj.IsPersistent = true;
            }
            db.Close();
            return VldCheckListObj;
        }

        //getFromDatareader
        public static VldCheckList GetFromDatareader(DbProvider db)
        {
            VldCheckList VldCheckListObj = new VldCheckList();
            VldCheckListObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            VldCheckListObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            VldCheckListObj.CodTipoDpagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DPAGAMENTO"]);
            VldCheckListObj.Tpappalto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TPAPPALTO"]);
            VldCheckListObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            VldCheckListObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VldCheckListObj.IsDirty = false;
            VldCheckListObj.IsPersistent = true;
            return VldCheckListObj;
        }

        //Find Select

        public static VldCheckListCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoDpagamentoEqualThis,
SiarLibrary.NullTypes.StringNT TpappaltoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

        {

            VldCheckListCollection VldCheckListCollectionObj = new VldCheckListCollection();

            IDbCommand findCmd = db.InitCmd("Zvldchecklistfindselect", new string[] {"Idequalthis", "Descrizioneequalthis", "CodTipoDpagamentoequalthis",
"Tpappaltoequalthis", "DataModificaequalthis", "Operatoreequalthis"}, new string[] {"int", "string", "string",
"string", "DateTime", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoDpagamentoequalthis", CodTipoDpagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tpappaltoequalthis", TpappaltoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            VldCheckList VldCheckListObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VldCheckListObj = GetFromDatareader(db);
                VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VldCheckListObj.IsDirty = false;
                VldCheckListObj.IsPersistent = true;
                VldCheckListCollectionObj.Add(VldCheckListObj);
            }
            db.Close();
            return VldCheckListCollectionObj;
        }

        //Find Find

        public static VldCheckListCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoDpagamentoEqualThis, SiarLibrary.NullTypes.StringNT TpappaltoEqualThis)

        {

            VldCheckListCollection VldCheckListCollectionObj = new VldCheckListCollection();

            IDbCommand findCmd = db.InitCmd("Zvldchecklistfindfind", new string[] { "CodTipoDpagamentoequalthis", "Tpappaltoequalthis" }, new string[] { "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoDpagamentoequalthis", CodTipoDpagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tpappaltoequalthis", TpappaltoEqualThis);
            VldCheckList VldCheckListObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VldCheckListObj = GetFromDatareader(db);
                VldCheckListObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VldCheckListObj.IsDirty = false;
                VldCheckListObj.IsPersistent = true;
                VldCheckListCollectionObj.Add(VldCheckListObj);
            }
            db.Close();
            return VldCheckListCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VldCheckListCollectionProvider:IVldCheckListProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VldCheckListCollectionProvider : IVldCheckListProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VldCheckList
        protected VldCheckListCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VldCheckListCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VldCheckListCollection(this);
        }

        //Costruttore 2: popola la collection
        public VldCheckListCollectionProvider(StringNT CodtipodpagamentoEqualThis, StringNT TpappaltoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodtipodpagamentoEqualThis, TpappaltoEqualThis);
        }

        //Costruttore3: ha in input vldchecklistCollectionObj - non popola la collection
        public VldCheckListCollectionProvider(VldCheckListCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VldCheckListCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VldCheckListCollection(this);
        }

        //Get e Set
        public VldCheckListCollection CollectionObj
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
        public int SaveCollection(VldCheckListCollection collectionObj)
        {
            return VldCheckListDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(VldCheckList vldchecklistObj)
        {
            return VldCheckListDAL.Save(_dbProviderObj, vldchecklistObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(VldCheckListCollection collectionObj)
        {
            return VldCheckListDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(VldCheckList vldchecklistObj)
        {
            return VldCheckListDAL.Delete(_dbProviderObj, vldchecklistObj);
        }

        //getById
        public VldCheckList GetById(IntNT IdValue)
        {
            VldCheckList VldCheckListTemp = VldCheckListDAL.GetById(_dbProviderObj, IdValue);
            if (VldCheckListTemp != null) VldCheckListTemp.Provider = this;
            return VldCheckListTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public VldCheckListCollection Select(IntNT IdEqualThis, StringNT DescrizioneEqualThis, StringNT CodtipodpagamentoEqualThis,
StringNT TpappaltoEqualThis, DatetimeNT DatamodificaEqualThis, IntNT OperatoreEqualThis)
        {
            VldCheckListCollection VldCheckListCollectionTemp = VldCheckListDAL.Select(_dbProviderObj, IdEqualThis, DescrizioneEqualThis, CodtipodpagamentoEqualThis,
TpappaltoEqualThis, DatamodificaEqualThis, OperatoreEqualThis);
            VldCheckListCollectionTemp.Provider = this;
            return VldCheckListCollectionTemp;
        }

        //Find: popola la collection
        public VldCheckListCollection Find(StringNT CodtipodpagamentoEqualThis, StringNT TpappaltoEqualThis)
        {
            VldCheckListCollection VldCheckListCollectionTemp = VldCheckListDAL.Find(_dbProviderObj, CodtipodpagamentoEqualThis, TpappaltoEqualThis);
            VldCheckListCollectionTemp.Provider = this;
            return VldCheckListCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VLD_CHECK_LIST>
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
      <COD_TIPO_DPAGAMENTO>Equal</COD_TIPO_DPAGAMENTO>
      <TPAPPALTO>Equal</TPAPPALTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VLD_CHECK_LIST>
*/
