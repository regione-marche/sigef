using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Zdimensioni
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IZdimensioniProvider
    {
        int Save(Zdimensioni ZdimensioniObj);
        int SaveCollection(ZdimensioniCollection collectionObj);
        int Delete(Zdimensioni ZdimensioniObj);
        int DeleteCollection(ZdimensioniCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Zdimensioni
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Zdimensioni : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _Codice;
        private NullTypes.StringNT _CodDim;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _Metodo;
        private NullTypes.DecimalNT _Valore;
        private NullTypes.StringNT _Richiedibile;
        private NullTypes.StringNT _Um;
        private NullTypes.StringNT _ProceduraCalcolo;
        private NullTypes.IntNT _Ordine;
        private NullTypes.DecimalNT _ValoreBase;
        private NullTypes.StringNT _DesDim;
        [NonSerialized]
        private IZdimensioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZdimensioniProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Zdimensioni()
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
        /// Corrisponde al campo:CODICE
        /// Tipo sul db:VARCHAR(50)
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
        /// Corrisponde al campo:COD_DIM
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT CodDim
        {
            get { return _CodDim; }
            set
            {
                if (CodDim != value)
                {
                    _CodDim = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(1000)
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
        /// Corrisponde al campo:METODO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Metodo
        {
            get { return _Metodo; }
            set
            {
                if (Metodo != value)
                {
                    _Metodo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Valore
        {
            get { return _Valore; }
            set
            {
                if (Valore != value)
                {
                    _Valore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICHIEDIBILE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT Richiedibile
        {
            get { return _Richiedibile; }
            set
            {
                if (Richiedibile != value)
                {
                    _Richiedibile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:UM
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Um
        {
            get { return _Um; }
            set
            {
                if (Um != value)
                {
                    _Um = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROCEDURA_CALCOLO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ProceduraCalcolo
        {
            get { return _ProceduraCalcolo; }
            set
            {
                if (ProceduraCalcolo != value)
                {
                    _ProceduraCalcolo = value;
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
        /// Corrisponde al campo:VALORE_BASE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreBase
        {
            get { return _ValoreBase; }
            set
            {
                if (ValoreBase != value)
                {
                    _ValoreBase = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DES_DIM
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DesDim
        {
            get { return _DesDim; }
            set
            {
                if (DesDim != value)
                {
                    _DesDim = value;
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
    /// Summary description for ZdimensioniCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZdimensioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ZdimensioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Zdimensioni)info.GetValue(i.ToString(), typeof(Zdimensioni)));
            }
        }

        //Costruttore
        public ZdimensioniCollection()
        {
            this.ItemType = typeof(Zdimensioni);
        }

        //Costruttore con provider
        public ZdimensioniCollection(IZdimensioniProvider providerObj)
        {
            this.ItemType = typeof(Zdimensioni);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Zdimensioni this[int index]
        {
            get { return (Zdimensioni)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ZdimensioniCollection GetChanges()
        {
            return (ZdimensioniCollection)base.GetChanges();
        }

        [NonSerialized]
        private IZdimensioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZdimensioniProvider Provider
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
        public int Add(Zdimensioni ZdimensioniObj)
        {
            if (ZdimensioniObj.Provider == null) ZdimensioniObj.Provider = this.Provider;
            return base.Add(ZdimensioniObj);
        }

        //AddCollection
        public void AddCollection(ZdimensioniCollection ZdimensioniCollectionObj)
        {
            foreach (Zdimensioni ZdimensioniObj in ZdimensioniCollectionObj)
                this.Add(ZdimensioniObj);
        }

        //Insert
        public void Insert(int index, Zdimensioni ZdimensioniObj)
        {
            if (ZdimensioniObj.Provider == null) ZdimensioniObj.Provider = this.Provider;
            base.Insert(index, ZdimensioniObj);
        }

        //CollectionGetById
        public Zdimensioni CollectionGetById(NullTypes.IntNT IdValue)
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
        public ZdimensioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT CodDimEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT MetodoEqualThis, NullTypes.DecimalNT ValoreEqualThis,
NullTypes.StringNT RichiedibileEqualThis, NullTypes.StringNT UmEqualThis, NullTypes.StringNT ProceduraCalcoloEqualThis,
NullTypes.IntNT OrdineEqualThis, NullTypes.DecimalNT ValoreBaseEqualThis)
        {
            ZdimensioniCollection ZdimensioniCollectionTemp = new ZdimensioniCollection();
            foreach (Zdimensioni ZdimensioniItem in this)
            {
                if (((IdEqualThis == null) || ((ZdimensioniItem.Id != null) && (ZdimensioniItem.Id.Value == IdEqualThis.Value))) && ((CodiceEqualThis == null) || ((ZdimensioniItem.Codice != null) && (ZdimensioniItem.Codice.Value == CodiceEqualThis.Value))) && ((CodDimEqualThis == null) || ((ZdimensioniItem.CodDim != null) && (ZdimensioniItem.CodDim.Value == CodDimEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((ZdimensioniItem.Descrizione != null) && (ZdimensioniItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((MetodoEqualThis == null) || ((ZdimensioniItem.Metodo != null) && (ZdimensioniItem.Metodo.Value == MetodoEqualThis.Value))) && ((ValoreEqualThis == null) || ((ZdimensioniItem.Valore != null) && (ZdimensioniItem.Valore.Value == ValoreEqualThis.Value))) &&
((RichiedibileEqualThis == null) || ((ZdimensioniItem.Richiedibile != null) && (ZdimensioniItem.Richiedibile.Value == RichiedibileEqualThis.Value))) && ((UmEqualThis == null) || ((ZdimensioniItem.Um != null) && (ZdimensioniItem.Um.Value == UmEqualThis.Value))) && ((ProceduraCalcoloEqualThis == null) || ((ZdimensioniItem.ProceduraCalcolo != null) && (ZdimensioniItem.ProceduraCalcolo.Value == ProceduraCalcoloEqualThis.Value))) &&
((OrdineEqualThis == null) || ((ZdimensioniItem.Ordine != null) && (ZdimensioniItem.Ordine.Value == OrdineEqualThis.Value))) && ((ValoreBaseEqualThis == null) || ((ZdimensioniItem.ValoreBase != null) && (ZdimensioniItem.ValoreBase.Value == ValoreBaseEqualThis.Value))))
                {
                    ZdimensioniCollectionTemp.Add(ZdimensioniItem);
                }
            }
            return ZdimensioniCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ZdimensioniDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ZdimensioniDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Zdimensioni ZdimensioniObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ZdimensioniObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Codice", ZdimensioniObj.Codice);
            DbProvider.SetCmdParam(cmd, firstChar + "CodDim", ZdimensioniObj.CodDim);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ZdimensioniObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Metodo", ZdimensioniObj.Metodo);
            DbProvider.SetCmdParam(cmd, firstChar + "Valore", ZdimensioniObj.Valore);
            DbProvider.SetCmdParam(cmd, firstChar + "Richiedibile", ZdimensioniObj.Richiedibile);
            DbProvider.SetCmdParam(cmd, firstChar + "Um", ZdimensioniObj.Um);
            DbProvider.SetCmdParam(cmd, firstChar + "ProceduraCalcolo", ZdimensioniObj.ProceduraCalcolo);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", ZdimensioniObj.Ordine);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreBase", ZdimensioniObj.ValoreBase);
        }
        //Insert
        private static int Insert(DbProvider db, Zdimensioni ZdimensioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZZdimensioniInsert", new string[] {"Codice", "CodDim", 
"Descrizione", "Metodo", "Valore", 
"Richiedibile", "Um", "ProceduraCalcolo", 
"Ordine", "ValoreBase"}, new string[] {"string", "string", 
"string", "string", "decimal", 
"string", "string", "string", 
"int", "decimal"}, "");
                CompileIUCmd(false, insertCmd, ZdimensioniObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ZdimensioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniObj.IsDirty = false;
                ZdimensioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Zdimensioni ZdimensioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZdimensioniUpdate", new string[] {"Id", "Codice", "CodDim", 
"Descrizione", "Metodo", "Valore", 
"Richiedibile", "Um", "ProceduraCalcolo", 
"Ordine", "ValoreBase"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"string", "string", "string", 
"int", "decimal"}, "");
                CompileIUCmd(true, updateCmd, ZdimensioniObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniObj.IsDirty = false;
                ZdimensioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Zdimensioni ZdimensioniObj)
        {
            switch (ZdimensioniObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ZdimensioniObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ZdimensioniObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ZdimensioniObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ZdimensioniCollection ZdimensioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZdimensioniUpdate", new string[] {"Id", "Codice", "CodDim", 
"Descrizione", "Metodo", "Valore", 
"Richiedibile", "Um", "ProceduraCalcolo", 
"Ordine", "ValoreBase"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"string", "string", "string", 
"int", "decimal"}, "");
                IDbCommand insertCmd = db.InitCmd("ZZdimensioniInsert", new string[] {"Codice", "CodDim", 
"Descrizione", "Metodo", "Valore", 
"Richiedibile", "Um", "ProceduraCalcolo", 
"Ordine", "ValoreBase"}, new string[] {"string", "string", 
"string", "string", "decimal", 
"string", "string", "string", 
"int", "decimal"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZdimensioniCollectionObj.Count; i++)
                {
                    switch (ZdimensioniCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ZdimensioniCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ZdimensioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ZdimensioniCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ZdimensioniCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZdimensioniCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ZdimensioniCollectionObj.Count; i++)
                {
                    if ((ZdimensioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZdimensioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ZdimensioniCollectionObj[i].IsDirty = false;
                        ZdimensioniCollectionObj[i].IsPersistent = true;
                    }
                    if ((ZdimensioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ZdimensioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZdimensioniCollectionObj[i].IsDirty = false;
                        ZdimensioniCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Zdimensioni ZdimensioniObj)
        {
            int returnValue = 0;
            if (ZdimensioniObj.IsPersistent)
            {
                returnValue = Delete(db, ZdimensioniObj.Id);
            }
            ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ZdimensioniObj.IsDirty = false;
            ZdimensioniObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ZdimensioniCollection ZdimensioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZdimensioniCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ZdimensioniCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ZdimensioniCollectionObj.Count; i++)
                {
                    if ((ZdimensioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZdimensioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZdimensioniCollectionObj[i].IsDirty = false;
                        ZdimensioniCollectionObj[i].IsPersistent = false;
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
        public static Zdimensioni GetById(DbProvider db, int IdValue)
        {
            Zdimensioni ZdimensioniObj = null;
            IDbCommand readCmd = db.InitCmd("ZZdimensioniGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ZdimensioniObj = GetFromDatareader(db);
                ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniObj.IsDirty = false;
                ZdimensioniObj.IsPersistent = true;
            }
            db.Close();
            return ZdimensioniObj;
        }

        //getFromDatareader
        public static Zdimensioni GetFromDatareader(DbProvider db)
        {
            Zdimensioni ZdimensioniObj = new Zdimensioni();
            ZdimensioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ZdimensioniObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
            ZdimensioniObj.CodDim = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DIM"]);
            ZdimensioniObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            ZdimensioniObj.Metodo = new SiarLibrary.NullTypes.StringNT(db.DataReader["METODO"]);
            ZdimensioniObj.Valore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE"]);
            ZdimensioniObj.Richiedibile = new SiarLibrary.NullTypes.StringNT(db.DataReader["RICHIEDIBILE"]);
            ZdimensioniObj.Um = new SiarLibrary.NullTypes.StringNT(db.DataReader["UM"]);
            ZdimensioniObj.ProceduraCalcolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROCEDURA_CALCOLO"]);
            ZdimensioniObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            ZdimensioniObj.ValoreBase = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_BASE"]);
            ZdimensioniObj.DesDim = new SiarLibrary.NullTypes.StringNT(db.DataReader["DES_DIM"]);
            ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ZdimensioniObj.IsDirty = false;
            ZdimensioniObj.IsPersistent = true;
            return ZdimensioniObj;
        }

        //Find Select

        public static ZdimensioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodDimEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT MetodoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreEqualThis,
SiarLibrary.NullTypes.StringNT RichiedibileEqualThis, SiarLibrary.NullTypes.StringNT UmEqualThis, SiarLibrary.NullTypes.StringNT ProceduraCalcoloEqualThis,
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreBaseEqualThis)
        {

            ZdimensioniCollection ZdimensioniCollectionObj = new ZdimensioniCollection();

            IDbCommand findCmd = db.InitCmd("Zzdimensionifindselect", new string[] {"Idequalthis", "Codiceequalthis", "CodDimequalthis", 
"Descrizioneequalthis", "Metodoequalthis", "Valoreequalthis", 
"Richiedibileequalthis", "Umequalthis", "ProceduraCalcoloequalthis", 
"Ordineequalthis", "ValoreBaseequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"string", "string", "string", 
"int", "decimal"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodDimequalthis", CodDimEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Metodoequalthis", MetodoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Richiedibileequalthis", RichiedibileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Umequalthis", UmEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProceduraCalcoloequalthis", ProceduraCalcoloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreBaseequalthis", ValoreBaseEqualThis);
            Zdimensioni ZdimensioniObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZdimensioniObj = GetFromDatareader(db);
                ZdimensioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniObj.IsDirty = false;
                ZdimensioniObj.IsPersistent = true;
                ZdimensioniCollectionObj.Add(ZdimensioniObj);
            }
            db.Close();
            return ZdimensioniCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ZdimensioniCollectionProvider:IZdimensioniProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZdimensioniCollectionProvider : IZdimensioniProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Zdimensioni
        protected ZdimensioniCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ZdimensioniCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ZdimensioniCollection(this);
        }

        //Costruttore3: ha in input zdimensioniCollectionObj - non popola la collection
        public ZdimensioniCollectionProvider(ZdimensioniCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ZdimensioniCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ZdimensioniCollection(this);
        }

        //Get e Set
        public ZdimensioniCollection CollectionObj
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
        public int SaveCollection(ZdimensioniCollection collectionObj)
        {
            return ZdimensioniDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Zdimensioni zdimensioniObj)
        {
            return ZdimensioniDAL.Save(_dbProviderObj, zdimensioniObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ZdimensioniCollection collectionObj)
        {
            return ZdimensioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Zdimensioni zdimensioniObj)
        {
            return ZdimensioniDAL.Delete(_dbProviderObj, zdimensioniObj);
        }

        //getById
        public Zdimensioni GetById(IntNT IdValue)
        {
            Zdimensioni ZdimensioniTemp = ZdimensioniDAL.GetById(_dbProviderObj, IdValue);
            if (ZdimensioniTemp != null) ZdimensioniTemp.Provider = this;
            return ZdimensioniTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ZdimensioniCollection Select(IntNT IdEqualThis, StringNT CodiceEqualThis, StringNT CoddimEqualThis,
StringNT DescrizioneEqualThis, StringNT MetodoEqualThis, DecimalNT ValoreEqualThis,
StringNT RichiedibileEqualThis, StringNT UmEqualThis, StringNT ProceduracalcoloEqualThis,
IntNT OrdineEqualThis, DecimalNT ValorebaseEqualThis)
        {
            ZdimensioniCollection ZdimensioniCollectionTemp = ZdimensioniDAL.Select(_dbProviderObj, IdEqualThis, CodiceEqualThis, CoddimEqualThis,
DescrizioneEqualThis, MetodoEqualThis, ValoreEqualThis,
RichiedibileEqualThis, UmEqualThis, ProceduracalcoloEqualThis,
OrdineEqualThis, ValorebaseEqualThis);
            ZdimensioniCollectionTemp.Provider = this;
            return ZdimensioniCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zDIMENSIONI>
  <ViewName>vzDIMENSIONI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
</zDIMENSIONI>
*/
