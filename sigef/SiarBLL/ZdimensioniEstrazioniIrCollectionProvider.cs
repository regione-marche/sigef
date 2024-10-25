using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ZdimensioniEstrazioniIr
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IZdimensioniEstrazioniIrProvider
    {
        int Save(ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj);
        int SaveCollection(ZdimensioniEstrazioniIrCollection collectionObj);
        int Delete(ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj);
        int DeleteCollection(ZdimensioniEstrazioniIrCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ZdimensioniEstrazioniIr
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ZdimensioniEstrazioniIr : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdEstrazioneIr;
        private NullTypes.StringNT _CodicePsr;
        private NullTypes.IntNT _IdDimensione;
        private NullTypes.DatetimeNT _DataInizio;
        private NullTypes.DatetimeNT _DataFine;
        private NullTypes.DecimalNT _ValoreBase;
        private NullTypes.DecimalNT _ValoreObbiettivo;
        private NullTypes.DecimalNT _ValoreRealizzato;
        private NullTypes.StringNT _Um;
        private NullTypes.StringNT _CodiceObmisura;
        private NullTypes.StringNT _DimensioneCodice;
        private NullTypes.StringNT _DimensioneDescrizione;
        private NullTypes.IntNT _DimensioneOrdine;
        private NullTypes.IntNT _Anno;
        [NonSerialized]
        private IZdimensioniEstrazioniIrProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZdimensioniEstrazioniIrProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ZdimensioniEstrazioniIr()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_ESTRAZIONE_IR
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdEstrazioneIr
        {
            get { return _IdEstrazioneIr; }
            set
            {
                if (IdEstrazioneIr != value)
                {
                    _IdEstrazioneIr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_PSR
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT CodicePsr
        {
            get { return _CodicePsr; }
            set
            {
                if (CodicePsr != value)
                {
                    _CodicePsr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DIMENSIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDimensione
        {
            get { return _IdDimensione; }
            set
            {
                if (IdDimensione != value)
                {
                    _IdDimensione = value;
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
        /// Corrisponde al campo:VALORE_OBBIETTIVO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreObbiettivo
        {
            get { return _ValoreObbiettivo; }
            set
            {
                if (ValoreObbiettivo != value)
                {
                    _ValoreObbiettivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALORE_REALIZZATO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ValoreRealizzato
        {
            get { return _ValoreRealizzato; }
            set
            {
                if (ValoreRealizzato != value)
                {
                    _ValoreRealizzato = value;
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
        /// Corrisponde al campo:CODICE_OBMISURA
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodiceObmisura
        {
            get { return _CodiceObmisura; }
            set
            {
                if (CodiceObmisura != value)
                {
                    _CodiceObmisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DIMENSIONE_CODICE
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT DimensioneCodice
        {
            get { return _DimensioneCodice; }
            set
            {
                if (DimensioneCodice != value)
                {
                    _DimensioneCodice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DIMENSIONE_DESCRIZIONE
        /// Tipo sul db:VARCHAR(1000)
        /// </summary>
        public NullTypes.StringNT DimensioneDescrizione
        {
            get { return _DimensioneDescrizione; }
            set
            {
                if (DimensioneDescrizione != value)
                {
                    _DimensioneDescrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DIMENSIONE_ORDINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT DimensioneOrdine
        {
            get { return _DimensioneOrdine; }
            set
            {
                if (DimensioneOrdine != value)
                {
                    _DimensioneOrdine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ANNO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Anno
        {
            get { return _Anno; }
            set
            {
                if (Anno != value)
                {
                    _Anno = value;
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
    /// Summary description for ZdimensioniEstrazioniIrCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZdimensioniEstrazioniIrCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ZdimensioniEstrazioniIrCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ZdimensioniEstrazioniIr)info.GetValue(i.ToString(), typeof(ZdimensioniEstrazioniIr)));
            }
        }

        //Costruttore
        public ZdimensioniEstrazioniIrCollection()
        {
            this.ItemType = typeof(ZdimensioniEstrazioniIr);
        }

        //Costruttore con provider
        public ZdimensioniEstrazioniIrCollection(IZdimensioniEstrazioniIrProvider providerObj)
        {
            this.ItemType = typeof(ZdimensioniEstrazioniIr);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ZdimensioniEstrazioniIr this[int index]
        {
            get { return (ZdimensioniEstrazioniIr)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ZdimensioniEstrazioniIrCollection GetChanges()
        {
            return (ZdimensioniEstrazioniIrCollection)base.GetChanges();
        }

        [NonSerialized]
        private IZdimensioniEstrazioniIrProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZdimensioniEstrazioniIrProvider Provider
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
        public int Add(ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            if (ZdimensioniEstrazioniIrObj.Provider == null) ZdimensioniEstrazioniIrObj.Provider = this.Provider;
            return base.Add(ZdimensioniEstrazioniIrObj);
        }

        //AddCollection
        public void AddCollection(ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionObj)
        {
            foreach (ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj in ZdimensioniEstrazioniIrCollectionObj)
                this.Add(ZdimensioniEstrazioniIrObj);
        }

        //Insert
        public void Insert(int index, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            if (ZdimensioniEstrazioniIrObj.Provider == null) ZdimensioniEstrazioniIrObj.Provider = this.Provider;
            base.Insert(index, ZdimensioniEstrazioniIrObj);
        }

        //CollectionGetById
        public ZdimensioniEstrazioniIr CollectionGetById(NullTypes.IntNT IdEstrazioneIrValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdEstrazioneIr == IdEstrazioneIrValue))
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
        public ZdimensioniEstrazioniIrCollection SubSelect(NullTypes.IntNT IdEstrazioneIrEqualThis, NullTypes.StringNT CodicePsrEqualThis, NullTypes.IntNT IdDimensioneEqualThis,
NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, NullTypes.DecimalNT ValoreBaseEqualThis,
NullTypes.DecimalNT ValoreObbiettivoEqualThis, NullTypes.DecimalNT ValoreRealizzatoEqualThis, NullTypes.StringNT UmEqualThis,
NullTypes.StringNT CodiceObmisuraEqualThis)
        {
            ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionTemp = new ZdimensioniEstrazioniIrCollection();
            foreach (ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrItem in this)
            {
                if (((IdEstrazioneIrEqualThis == null) || ((ZdimensioniEstrazioniIrItem.IdEstrazioneIr != null) && (ZdimensioniEstrazioniIrItem.IdEstrazioneIr.Value == IdEstrazioneIrEqualThis.Value))) && ((CodicePsrEqualThis == null) || ((ZdimensioniEstrazioniIrItem.CodicePsr != null) && (ZdimensioniEstrazioniIrItem.CodicePsr.Value == CodicePsrEqualThis.Value))) && ((IdDimensioneEqualThis == null) || ((ZdimensioniEstrazioniIrItem.IdDimensione != null) && (ZdimensioniEstrazioniIrItem.IdDimensione.Value == IdDimensioneEqualThis.Value))) &&
((DataInizioEqualThis == null) || ((ZdimensioniEstrazioniIrItem.DataInizio != null) && (ZdimensioniEstrazioniIrItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((ZdimensioniEstrazioniIrItem.DataFine != null) && (ZdimensioniEstrazioniIrItem.DataFine.Value == DataFineEqualThis.Value))) && ((ValoreBaseEqualThis == null) || ((ZdimensioniEstrazioniIrItem.ValoreBase != null) && (ZdimensioniEstrazioniIrItem.ValoreBase.Value == ValoreBaseEqualThis.Value))) &&
((ValoreObbiettivoEqualThis == null) || ((ZdimensioniEstrazioniIrItem.ValoreObbiettivo != null) && (ZdimensioniEstrazioniIrItem.ValoreObbiettivo.Value == ValoreObbiettivoEqualThis.Value))) && ((ValoreRealizzatoEqualThis == null) || ((ZdimensioniEstrazioniIrItem.ValoreRealizzato != null) && (ZdimensioniEstrazioniIrItem.ValoreRealizzato.Value == ValoreRealizzatoEqualThis.Value))) && ((UmEqualThis == null) || ((ZdimensioniEstrazioniIrItem.Um != null) && (ZdimensioniEstrazioniIrItem.Um.Value == UmEqualThis.Value))) &&
((CodiceObmisuraEqualThis == null) || ((ZdimensioniEstrazioniIrItem.CodiceObmisura != null) && (ZdimensioniEstrazioniIrItem.CodiceObmisura.Value == CodiceObmisuraEqualThis.Value))))
                {
                    ZdimensioniEstrazioniIrCollectionTemp.Add(ZdimensioniEstrazioniIrItem);
                }
            }
            return ZdimensioniEstrazioniIrCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ZdimensioniEstrazioniIrDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ZdimensioniEstrazioniIrDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdEstrazioneIr", ZdimensioniEstrazioniIrObj.IdEstrazioneIr);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CodicePsr", ZdimensioniEstrazioniIrObj.CodicePsr);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDimensione", ZdimensioniEstrazioniIrObj.IdDimensione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizio", ZdimensioniEstrazioniIrObj.DataInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFine", ZdimensioniEstrazioniIrObj.DataFine);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreBase", ZdimensioniEstrazioniIrObj.ValoreBase);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreObbiettivo", ZdimensioniEstrazioniIrObj.ValoreObbiettivo);
            DbProvider.SetCmdParam(cmd, firstChar + "ValoreRealizzato", ZdimensioniEstrazioniIrObj.ValoreRealizzato);
            DbProvider.SetCmdParam(cmd, firstChar + "Um", ZdimensioniEstrazioniIrObj.Um);
            DbProvider.SetCmdParam(cmd, firstChar + "CodiceObmisura", ZdimensioniEstrazioniIrObj.CodiceObmisura);
        }
        //Insert
        private static int Insert(DbProvider db, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZZdimensioniEstrazioniIrInsert", new string[] {"CodicePsr", "IdDimensione", 
"DataInizio", "DataFine", "ValoreBase", 
"ValoreObbiettivo", "ValoreRealizzato", "Um", 
"CodiceObmisura", }, new string[] {"string", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "string", 
"string", }, "");
                CompileIUCmd(false, insertCmd, ZdimensioniEstrazioniIrObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ZdimensioniEstrazioniIrObj.IdEstrazioneIr = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IR"]);
                }
                ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniEstrazioniIrObj.IsDirty = false;
                ZdimensioniEstrazioniIrObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZdimensioniEstrazioniIrUpdate", new string[] {"IdEstrazioneIr", "CodicePsr", "IdDimensione", 
"DataInizio", "DataFine", "ValoreBase", 
"ValoreObbiettivo", "ValoreRealizzato", "Um", 
"CodiceObmisura", }, new string[] {"int", "string", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "string", 
"string", }, "");
                CompileIUCmd(true, updateCmd, ZdimensioniEstrazioniIrObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniEstrazioniIrObj.IsDirty = false;
                ZdimensioniEstrazioniIrObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            switch (ZdimensioniEstrazioniIrObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ZdimensioniEstrazioniIrObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ZdimensioniEstrazioniIrObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ZdimensioniEstrazioniIrObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZdimensioniEstrazioniIrUpdate", new string[] {"IdEstrazioneIr", "CodicePsr", "IdDimensione", 
"DataInizio", "DataFine", "ValoreBase", 
"ValoreObbiettivo", "ValoreRealizzato", "Um", 
"CodiceObmisura", }, new string[] {"int", "string", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "string", 
"string", }, "");
                IDbCommand insertCmd = db.InitCmd("ZZdimensioniEstrazioniIrInsert", new string[] {"CodicePsr", "IdDimensione", 
"DataInizio", "DataFine", "ValoreBase", 
"ValoreObbiettivo", "ValoreRealizzato", "Um", 
"CodiceObmisura", }, new string[] {"string", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "string", 
"string", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniEstrazioniIrDelete", new string[] { "IdEstrazioneIr" }, new string[] { "int" }, "");
                for (int i = 0; i < ZdimensioniEstrazioniIrCollectionObj.Count; i++)
                {
                    switch (ZdimensioniEstrazioniIrCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ZdimensioniEstrazioniIrCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ZdimensioniEstrazioniIrCollectionObj[i].IdEstrazioneIr = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IR"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ZdimensioniEstrazioniIrCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ZdimensioniEstrazioniIrCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEstrazioneIr", (SiarLibrary.NullTypes.IntNT)ZdimensioniEstrazioniIrCollectionObj[i].IdEstrazioneIr);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ZdimensioniEstrazioniIrCollectionObj.Count; i++)
                {
                    if ((ZdimensioniEstrazioniIrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniIrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZdimensioniEstrazioniIrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsDirty = false;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsPersistent = true;
                    }
                    if ((ZdimensioniEstrazioniIrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ZdimensioniEstrazioniIrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsDirty = false;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj)
        {
            int returnValue = 0;
            if (ZdimensioniEstrazioniIrObj.IsPersistent)
            {
                returnValue = Delete(db, ZdimensioniEstrazioniIrObj.IdEstrazioneIr);
            }
            ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ZdimensioniEstrazioniIrObj.IsDirty = false;
            ZdimensioniEstrazioniIrObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdEstrazioneIrValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniEstrazioniIrDelete", new string[] { "IdEstrazioneIr" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEstrazioneIr", (SiarLibrary.NullTypes.IntNT)IdEstrazioneIrValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZdimensioniEstrazioniIrDelete", new string[] { "IdEstrazioneIr" }, new string[] { "int" }, "");
                for (int i = 0; i < ZdimensioniEstrazioniIrCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdEstrazioneIr", ZdimensioniEstrazioniIrCollectionObj[i].IdEstrazioneIr);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ZdimensioniEstrazioniIrCollectionObj.Count; i++)
                {
                    if ((ZdimensioniEstrazioniIrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniIrCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZdimensioniEstrazioniIrCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsDirty = false;
                        ZdimensioniEstrazioniIrCollectionObj[i].IsPersistent = false;
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
        public static ZdimensioniEstrazioniIr GetById(DbProvider db, int IdEstrazioneIrValue)
        {
            ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj = null;
            IDbCommand readCmd = db.InitCmd("ZZdimensioniEstrazioniIrGetById", new string[] { "IdEstrazioneIr" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdEstrazioneIr", (SiarLibrary.NullTypes.IntNT)IdEstrazioneIrValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ZdimensioniEstrazioniIrObj = GetFromDatareader(db);
                ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniEstrazioniIrObj.IsDirty = false;
                ZdimensioniEstrazioniIrObj.IsPersistent = true;
            }
            db.Close();
            return ZdimensioniEstrazioniIrObj;
        }

        //getFromDatareader
        public static ZdimensioniEstrazioniIr GetFromDatareader(DbProvider db)
        {
            ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj = new ZdimensioniEstrazioniIr();
            ZdimensioniEstrazioniIrObj.IdEstrazioneIr = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IR"]);
            ZdimensioniEstrazioniIrObj.CodicePsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_PSR"]);
            ZdimensioniEstrazioniIrObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
            ZdimensioniEstrazioniIrObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
            ZdimensioniEstrazioniIrObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
            ZdimensioniEstrazioniIrObj.ValoreBase = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_BASE"]);
            ZdimensioniEstrazioniIrObj.ValoreObbiettivo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_OBBIETTIVO"]);
            ZdimensioniEstrazioniIrObj.ValoreRealizzato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_REALIZZATO"]);
            ZdimensioniEstrazioniIrObj.Um = new SiarLibrary.NullTypes.StringNT(db.DataReader["UM"]);
            ZdimensioniEstrazioniIrObj.CodiceObmisura = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_OBMISURA"]);
            ZdimensioniEstrazioniIrObj.DimensioneCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIMENSIONE_CODICE"]);
            ZdimensioniEstrazioniIrObj.DimensioneDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIMENSIONE_DESCRIZIONE"]);
            ZdimensioniEstrazioniIrObj.DimensioneOrdine = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_ORDINE"]);
            ZdimensioniEstrazioniIrObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
            ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ZdimensioniEstrazioniIrObj.IsDirty = false;
            ZdimensioniEstrazioniIrObj.IsPersistent = true;
            return ZdimensioniEstrazioniIrObj;
        }

        //Find Select

        public static ZdimensioniEstrazioniIrCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEstrazioneIrEqualThis, SiarLibrary.NullTypes.StringNT CodicePsrEqualThis, SiarLibrary.NullTypes.IntNT IdDimensioneEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreBaseEqualThis,
SiarLibrary.NullTypes.DecimalNT ValoreObbiettivoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreRealizzatoEqualThis, SiarLibrary.NullTypes.StringNT UmEqualThis,
SiarLibrary.NullTypes.StringNT CodiceObmisuraEqualThis)
        {

            ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionObj = new ZdimensioniEstrazioniIrCollection();

            IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazioniirfindselect", new string[] {"IdEstrazioneIrequalthis", "CodicePsrequalthis", "IdDimensioneequalthis", 
"DataInizioequalthis", "DataFineequalthis", "ValoreBaseequalthis", 
"ValoreObbiettivoequalthis", "ValoreRealizzatoequalthis", "Umequalthis", 
"CodiceObmisuraequalthis"}, new string[] {"int", "string", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "string", 
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdEstrazioneIrequalthis", IdEstrazioneIrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodicePsrequalthis", CodicePsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDimensioneequalthis", IdDimensioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreBaseequalthis", ValoreBaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreObbiettivoequalthis", ValoreObbiettivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreRealizzatoequalthis", ValoreRealizzatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Umequalthis", UmEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceObmisuraequalthis", CodiceObmisuraEqualThis);
            ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZdimensioniEstrazioniIrObj = GetFromDatareader(db);
                ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniEstrazioniIrObj.IsDirty = false;
                ZdimensioniEstrazioniIrObj.IsPersistent = true;
                ZdimensioniEstrazioniIrCollectionObj.Add(ZdimensioniEstrazioniIrObj);
            }
            db.Close();
            return ZdimensioniEstrazioniIrCollectionObj;
        }

        //Find Find

        public static ZdimensioniEstrazioniIrCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodicePsrEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis)
        {

            ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionObj = new ZdimensioniEstrazioniIrCollection();

            IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazioniirfindfind", new string[] { "CodicePsrequalthis", "Annoequalthis" }, new string[] { "string", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodicePsrequalthis", CodicePsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
            ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZdimensioniEstrazioniIrObj = GetFromDatareader(db);
                ZdimensioniEstrazioniIrObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZdimensioniEstrazioniIrObj.IsDirty = false;
                ZdimensioniEstrazioniIrObj.IsPersistent = true;
                ZdimensioniEstrazioniIrCollectionObj.Add(ZdimensioniEstrazioniIrObj);
            }
            db.Close();
            return ZdimensioniEstrazioniIrCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ZdimensioniEstrazioniIrCollectionProvider:IZdimensioniEstrazioniIrProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZdimensioniEstrazioniIrCollectionProvider : IZdimensioniEstrazioniIrProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ZdimensioniEstrazioniIr
        protected ZdimensioniEstrazioniIrCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ZdimensioniEstrazioniIrCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ZdimensioniEstrazioniIrCollection(this);
        }

        //Costruttore 2: popola la collection
        public ZdimensioniEstrazioniIrCollectionProvider(StringNT CodicepsrEqualThis, IntNT AnnoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodicepsrEqualThis, AnnoEqualThis);
        }

        //Costruttore3: ha in input zdimensioniestrazioniirCollectionObj - non popola la collection
        public ZdimensioniEstrazioniIrCollectionProvider(ZdimensioniEstrazioniIrCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ZdimensioniEstrazioniIrCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ZdimensioniEstrazioniIrCollection(this);
        }

        //Get e Set
        public ZdimensioniEstrazioniIrCollection CollectionObj
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
        public int SaveCollection(ZdimensioniEstrazioniIrCollection collectionObj)
        {
            return ZdimensioniEstrazioniIrDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ZdimensioniEstrazioniIr zdimensioniestrazioniirObj)
        {
            return ZdimensioniEstrazioniIrDAL.Save(_dbProviderObj, zdimensioniestrazioniirObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ZdimensioniEstrazioniIrCollection collectionObj)
        {
            return ZdimensioniEstrazioniIrDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ZdimensioniEstrazioniIr zdimensioniestrazioniirObj)
        {
            return ZdimensioniEstrazioniIrDAL.Delete(_dbProviderObj, zdimensioniestrazioniirObj);
        }

        //getById
        public ZdimensioniEstrazioniIr GetById(IntNT IdEstrazioneIrValue)
        {
            ZdimensioniEstrazioniIr ZdimensioniEstrazioniIrTemp = ZdimensioniEstrazioniIrDAL.GetById(_dbProviderObj, IdEstrazioneIrValue);
            if (ZdimensioniEstrazioniIrTemp != null) ZdimensioniEstrazioniIrTemp.Provider = this;
            return ZdimensioniEstrazioniIrTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ZdimensioniEstrazioniIrCollection Select(IntNT IdestrazioneirEqualThis, StringNT CodicepsrEqualThis, IntNT IddimensioneEqualThis,
DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, DecimalNT ValorebaseEqualThis,
DecimalNT ValoreobbiettivoEqualThis, DecimalNT ValorerealizzatoEqualThis, StringNT UmEqualThis,
StringNT CodiceobmisuraEqualThis)
        {
            ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionTemp = ZdimensioniEstrazioniIrDAL.Select(_dbProviderObj, IdestrazioneirEqualThis, CodicepsrEqualThis, IddimensioneEqualThis,
DatainizioEqualThis, DatafineEqualThis, ValorebaseEqualThis,
ValoreobbiettivoEqualThis, ValorerealizzatoEqualThis, UmEqualThis,
CodiceobmisuraEqualThis);
            ZdimensioniEstrazioniIrCollectionTemp.Provider = this;
            return ZdimensioniEstrazioniIrCollectionTemp;
        }

        //Find: popola la collection
        public ZdimensioniEstrazioniIrCollection Find(StringNT CodicepsrEqualThis, IntNT AnnoEqualThis)
        {
            ZdimensioniEstrazioniIrCollection ZdimensioniEstrazioniIrCollectionTemp = ZdimensioniEstrazioniIrDAL.Find(_dbProviderObj, CodicepsrEqualThis, AnnoEqualThis);
            ZdimensioniEstrazioniIrCollectionTemp.Provider = this;
            return ZdimensioniEstrazioniIrCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zDIMENSIONI_ESTRAZIONI_IR>
  <ViewName>vzDIMENSIONI_ESTRAZIONI_IR</ViewName>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <CODICE_PSR>Equal</CODICE_PSR>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zDIMENSIONI_ESTRAZIONI_IR>
*/
