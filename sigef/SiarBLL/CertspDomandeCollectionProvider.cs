using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per CertspDomande
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ICertspDomandeProvider
    {
        int Save(CertspDomande CertspDomandeObj);
        int SaveCollection(CertspDomandeCollection collectionObj);
        int Delete(CertspDomande CertspDomandeObj);
        int DeleteCollection(CertspDomandeCollection collectionObj);
    }
    /// <summary>
    /// Summary description for CertspDomande
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class CertspDomande : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdDomanda;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.DatetimeNT _DataPres;
        private NullTypes.DecimalNT _SpeseAmm;
        private NullTypes.DecimalNT _SpesaPubb;
        private NullTypes.DecimalNT _SfTot;
        private NullTypes.DecimalNT _SfSpesaPubb;
        private NullTypes.DecimalNT _SfSpeseAmm;
        private NullTypes.DecimalNT _SfSpesaPubbAmm;
        private NullTypes.DecimalNT _AsTot;
        private NullTypes.DecimalNT _AsCoperto;
        private NullTypes.DecimalNT _AsNonCoperto;
        [NonSerialized]
        private ICertspDomandeProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICertspDomandeProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public CertspDomande()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_DOMANDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomanda
        {
            get { return _IdDomanda; }
            set
            {
                if (IdDomanda != value)
                {
                    _IdDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAtto
        {
            get { return _IdAtto; }
            set
            {
                if (IdAtto != value)
                {
                    _IdAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PRES
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPres
        {
            get { return _DataPres; }
            set
            {
                if (DataPres != value)
                {
                    _DataPres = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESE_AMM
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpeseAmm
        {
            get { return _SpeseAmm; }
            set
            {
                if (SpeseAmm != value)
                {
                    _SpeseAmm = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESA_PUBB
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaPubb
        {
            get { return _SpesaPubb; }
            set
            {
                if (SpesaPubb != value)
                {
                    _SpesaPubb = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SF_TOT
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SfTot
        {
            get { return _SfTot; }
            set
            {
                if (SfTot != value)
                {
                    _SfTot = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SF_SPESA_PUBB
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SfSpesaPubb
        {
            get { return _SfSpesaPubb; }
            set
            {
                if (SfSpesaPubb != value)
                {
                    _SfSpesaPubb = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SF_SPESE_AMM
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SfSpeseAmm
        {
            get { return _SfSpeseAmm; }
            set
            {
                if (SfSpeseAmm != value)
                {
                    _SfSpeseAmm = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SF_SPESA_PUBB_AMM
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SfSpesaPubbAmm
        {
            get { return _SfSpesaPubbAmm; }
            set
            {
                if (SfSpesaPubbAmm != value)
                {
                    _SfSpesaPubbAmm = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AS_TOT
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AsTot
        {
            get { return _AsTot; }
            set
            {
                if (AsTot != value)
                {
                    _AsTot = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AS_COPERTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AsCoperto
        {
            get { return _AsCoperto; }
            set
            {
                if (AsCoperto != value)
                {
                    _AsCoperto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AS_NON_COPERTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AsNonCoperto
        {
            get { return _AsNonCoperto; }
            set
            {
                if (AsNonCoperto != value)
                {
                    _AsNonCoperto = value;
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
    /// Summary description for CertspDomandeCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CertspDomandeCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private CertspDomandeCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((CertspDomande)info.GetValue(i.ToString(), typeof(CertspDomande)));
            }
        }

        //Costruttore
        public CertspDomandeCollection()
        {
            this.ItemType = typeof(CertspDomande);
        }

        //Costruttore con provider
        public CertspDomandeCollection(ICertspDomandeProvider providerObj)
        {
            this.ItemType = typeof(CertspDomande);
            this.Provider = providerObj;
        }

        //Get e Set
        public new CertspDomande this[int index]
        {
            get { return (CertspDomande)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new CertspDomandeCollection GetChanges()
        {
            return (CertspDomandeCollection)base.GetChanges();
        }

        [NonSerialized]
        private ICertspDomandeProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICertspDomandeProvider Provider
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
        public int Add(CertspDomande CertspDomandeObj)
        {
            if (CertspDomandeObj.Provider == null) CertspDomandeObj.Provider = this.Provider;
            return base.Add(CertspDomandeObj);
        }

        //AddCollection
        public void AddCollection(CertspDomandeCollection CertspDomandeCollectionObj)
        {
            foreach (CertspDomande CertspDomandeObj in CertspDomandeCollectionObj)
                this.Add(CertspDomandeObj);
        }

        //Insert
        public void Insert(int index, CertspDomande CertspDomandeObj)
        {
            if (CertspDomandeObj.Provider == null) CertspDomandeObj.Provider = this.Provider;
            base.Insert(index, CertspDomandeObj);
        }

        //CollectionGetById
        public CertspDomande CollectionGetById(NullTypes.IntNT IdDomandaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdDomanda == IdDomandaValue))
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
        public CertspDomandeCollection SubSelect(NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT IdAttoEqualThis, NullTypes.DatetimeNT DataPresEqualThis,
NullTypes.DecimalNT SpeseAmmEqualThis, NullTypes.DecimalNT SpesaPubbEqualThis, NullTypes.DecimalNT SfTotEqualThis,
NullTypes.DecimalNT SfSpesaPubbEqualThis, NullTypes.DecimalNT SfSpeseAmmEqualThis, NullTypes.DecimalNT SfSpesaPubbAmmEqualThis,
NullTypes.DecimalNT AsTotEqualThis, NullTypes.DecimalNT AsCopertoEqualThis, NullTypes.DecimalNT AsNonCopertoEqualThis)
        {
            CertspDomandeCollection CertspDomandeCollectionTemp = new CertspDomandeCollection();
            foreach (CertspDomande CertspDomandeItem in this)
            {
                if (((IdDomandaEqualThis == null) || ((CertspDomandeItem.IdDomanda != null) && (CertspDomandeItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((IdAttoEqualThis == null) || ((CertspDomandeItem.IdAtto != null) && (CertspDomandeItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((DataPresEqualThis == null) || ((CertspDomandeItem.DataPres != null) && (CertspDomandeItem.DataPres.Value == DataPresEqualThis.Value))) &&
((SpeseAmmEqualThis == null) || ((CertspDomandeItem.SpeseAmm != null) && (CertspDomandeItem.SpeseAmm.Value == SpeseAmmEqualThis.Value))) && ((SpesaPubbEqualThis == null) || ((CertspDomandeItem.SpesaPubb != null) && (CertspDomandeItem.SpesaPubb.Value == SpesaPubbEqualThis.Value))) && ((SfTotEqualThis == null) || ((CertspDomandeItem.SfTot != null) && (CertspDomandeItem.SfTot.Value == SfTotEqualThis.Value))) &&
((SfSpesaPubbEqualThis == null) || ((CertspDomandeItem.SfSpesaPubb != null) && (CertspDomandeItem.SfSpesaPubb.Value == SfSpesaPubbEqualThis.Value))) && ((SfSpeseAmmEqualThis == null) || ((CertspDomandeItem.SfSpeseAmm != null) && (CertspDomandeItem.SfSpeseAmm.Value == SfSpeseAmmEqualThis.Value))) && ((SfSpesaPubbAmmEqualThis == null) || ((CertspDomandeItem.SfSpesaPubbAmm != null) && (CertspDomandeItem.SfSpesaPubbAmm.Value == SfSpesaPubbAmmEqualThis.Value))) &&
((AsTotEqualThis == null) || ((CertspDomandeItem.AsTot != null) && (CertspDomandeItem.AsTot.Value == AsTotEqualThis.Value))) && ((AsCopertoEqualThis == null) || ((CertspDomandeItem.AsCoperto != null) && (CertspDomandeItem.AsCoperto.Value == AsCopertoEqualThis.Value))) && ((AsNonCopertoEqualThis == null) || ((CertspDomandeItem.AsNonCoperto != null) && (CertspDomandeItem.AsNonCoperto.Value == AsNonCopertoEqualThis.Value))))
                {
                    CertspDomandeCollectionTemp.Add(CertspDomandeItem);
                }
            }
            return CertspDomandeCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for CertspDomandeDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class CertspDomandeDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspDomande CertspDomandeObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdDomanda", CertspDomandeObj.IdDomanda);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", CertspDomandeObj.IdAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPres", CertspDomandeObj.DataPres);
            DbProvider.SetCmdParam(cmd, firstChar + "SpeseAmm", CertspDomandeObj.SpeseAmm);
            DbProvider.SetCmdParam(cmd, firstChar + "SpesaPubb", CertspDomandeObj.SpesaPubb);
            DbProvider.SetCmdParam(cmd, firstChar + "SfTot", CertspDomandeObj.SfTot);
            DbProvider.SetCmdParam(cmd, firstChar + "SfSpesaPubb", CertspDomandeObj.SfSpesaPubb);
            DbProvider.SetCmdParam(cmd, firstChar + "SfSpeseAmm", CertspDomandeObj.SfSpeseAmm);
            DbProvider.SetCmdParam(cmd, firstChar + "SfSpesaPubbAmm", CertspDomandeObj.SfSpesaPubbAmm);
            DbProvider.SetCmdParam(cmd, firstChar + "AsTot", CertspDomandeObj.AsTot);
            DbProvider.SetCmdParam(cmd, firstChar + "AsCoperto", CertspDomandeObj.AsCoperto);
            DbProvider.SetCmdParam(cmd, firstChar + "AsNonCoperto", CertspDomandeObj.AsNonCoperto);
        }
        //Insert
        private static int Insert(DbProvider db, CertspDomande CertspDomandeObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZCertspDomandeInsert", new string[] {"IdAtto", "DataPres", 
"SpeseAmm", "SpesaPubb", "SfTot", 
"SfSpesaPubb", "SfSpeseAmm", "SfSpesaPubbAmm", 
"AsTot", "AsCoperto", "AsNonCoperto"}, new string[] {"int", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                CompileIUCmd(false, insertCmd, CertspDomandeObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    CertspDomandeObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
                }
                CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspDomandeObj.IsDirty = false;
                CertspDomandeObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, CertspDomande CertspDomandeObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCertspDomandeUpdate", new string[] {"IdDomanda", "IdAtto", "DataPres", 
"SpeseAmm", "SpesaPubb", "SfTot", 
"SfSpesaPubb", "SfSpeseAmm", "SfSpesaPubbAmm", 
"AsTot", "AsCoperto", "AsNonCoperto"}, new string[] {"int", "int", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                CompileIUCmd(true, updateCmd, CertspDomandeObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspDomandeObj.IsDirty = false;
                CertspDomandeObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, CertspDomande CertspDomandeObj)
        {
            switch (CertspDomandeObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, CertspDomandeObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, CertspDomandeObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, CertspDomandeObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, CertspDomandeCollection CertspDomandeCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCertspDomandeUpdate", new string[] {"IdDomanda", "IdAtto", "DataPres", 
"SpeseAmm", "SpesaPubb", "SfTot", 
"SfSpesaPubb", "SfSpeseAmm", "SfSpesaPubbAmm", 
"AsTot", "AsCoperto", "AsNonCoperto"}, new string[] {"int", "int", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                IDbCommand insertCmd = db.InitCmd("ZCertspDomandeInsert", new string[] {"IdAtto", "DataPres", 
"SpeseAmm", "SpesaPubb", "SfTot", 
"SfSpesaPubb", "SfSpeseAmm", "SfSpesaPubbAmm", 
"AsTot", "AsCoperto", "AsNonCoperto"}, new string[] {"int", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZCertspDomandeDelete", new string[] { "IdDomanda" }, new string[] { "int" }, "");
                for (int i = 0; i < CertspDomandeCollectionObj.Count; i++)
                {
                    switch (CertspDomandeCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, CertspDomandeCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    CertspDomandeCollectionObj[i].IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, CertspDomandeCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (CertspDomandeCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)CertspDomandeCollectionObj[i].IdDomanda);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < CertspDomandeCollectionObj.Count; i++)
                {
                    if ((CertspDomandeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDomandeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CertspDomandeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        CertspDomandeCollectionObj[i].IsDirty = false;
                        CertspDomandeCollectionObj[i].IsPersistent = true;
                    }
                    if ((CertspDomandeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        CertspDomandeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CertspDomandeCollectionObj[i].IsDirty = false;
                        CertspDomandeCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, CertspDomande CertspDomandeObj)
        {
            int returnValue = 0;
            if (CertspDomandeObj.IsPersistent)
            {
                returnValue = Delete(db, CertspDomandeObj.IdDomanda);
            }
            CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            CertspDomandeObj.IsDirty = false;
            CertspDomandeObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdDomandaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCertspDomandeDelete", new string[] { "IdDomanda" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, CertspDomandeCollection CertspDomandeCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCertspDomandeDelete", new string[] { "IdDomanda" }, new string[] { "int" }, "");
                for (int i = 0; i < CertspDomandeCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomanda", CertspDomandeCollectionObj[i].IdDomanda);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < CertspDomandeCollectionObj.Count; i++)
                {
                    if ((CertspDomandeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDomandeCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CertspDomandeCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CertspDomandeCollectionObj[i].IsDirty = false;
                        CertspDomandeCollectionObj[i].IsPersistent = false;
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
        public static CertspDomande GetById(DbProvider db, int IdDomandaValue)
        {
            CertspDomande CertspDomandeObj = null;
            IDbCommand readCmd = db.InitCmd("ZCertspDomandeGetById", new string[] { "IdDomanda" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                CertspDomandeObj = GetFromDatareader(db);
                CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspDomandeObj.IsDirty = false;
                CertspDomandeObj.IsPersistent = true;
            }
            db.Close();
            return CertspDomandeObj;
        }

        //getFromDatareader
        public static CertspDomande GetFromDatareader(DbProvider db)
        {
            CertspDomande CertspDomandeObj = new CertspDomande();
            CertspDomandeObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
            CertspDomandeObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            CertspDomandeObj.DataPres = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRES"]);
            CertspDomandeObj.SpeseAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_AMM"]);
            CertspDomandeObj.SpesaPubb = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_PUBB"]);
            CertspDomandeObj.SfTot = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SF_TOT"]);
            CertspDomandeObj.SfSpesaPubb = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SF_SPESA_PUBB"]);
            CertspDomandeObj.SfSpeseAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SF_SPESE_AMM"]);
            CertspDomandeObj.SfSpesaPubbAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SF_SPESA_PUBB_AMM"]);
            CertspDomandeObj.AsTot = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AS_TOT"]);
            CertspDomandeObj.AsCoperto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AS_COPERTO"]);
            CertspDomandeObj.AsNonCoperto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AS_NON_COPERTO"]);
            CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CertspDomandeObj.IsDirty = false;
            CertspDomandeObj.IsPersistent = true;
            return CertspDomandeObj;
        }

        //Find Select

        public static CertspDomandeCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPresEqualThis,
SiarLibrary.NullTypes.DecimalNT SpeseAmmEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaPubbEqualThis, SiarLibrary.NullTypes.DecimalNT SfTotEqualThis,
SiarLibrary.NullTypes.DecimalNT SfSpesaPubbEqualThis, SiarLibrary.NullTypes.DecimalNT SfSpeseAmmEqualThis, SiarLibrary.NullTypes.DecimalNT SfSpesaPubbAmmEqualThis,
SiarLibrary.NullTypes.DecimalNT AsTotEqualThis, SiarLibrary.NullTypes.DecimalNT AsCopertoEqualThis, SiarLibrary.NullTypes.DecimalNT AsNonCopertoEqualThis)
        {

            CertspDomandeCollection CertspDomandeCollectionObj = new CertspDomandeCollection();

            IDbCommand findCmd = db.InitCmd("Zcertspdomandefindselect", new string[] {"IdDomandaequalthis", "IdAttoequalthis", "DataPresequalthis", 
"SpeseAmmequalthis", "SpesaPubbequalthis", "SfTotequalthis", 
"SfSpesaPubbequalthis", "SfSpeseAmmequalthis", "SfSpesaPubbAmmequalthis", 
"AsTotequalthis", "AsCopertoequalthis", "AsNonCopertoequalthis"}, new string[] {"int", "int", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPresequalthis", DataPresEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpeseAmmequalthis", SpeseAmmEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaPubbequalthis", SpesaPubbEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SfTotequalthis", SfTotEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SfSpesaPubbequalthis", SfSpesaPubbEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SfSpeseAmmequalthis", SfSpeseAmmEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SfSpesaPubbAmmequalthis", SfSpesaPubbAmmEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AsTotequalthis", AsTotEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AsCopertoequalthis", AsCopertoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AsNonCopertoequalthis", AsNonCopertoEqualThis);
            CertspDomande CertspDomandeObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CertspDomandeObj = GetFromDatareader(db);
                CertspDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspDomandeObj.IsDirty = false;
                CertspDomandeObj.IsPersistent = true;
                CertspDomandeCollectionObj.Add(CertspDomandeObj);
            }
            db.Close();
            return CertspDomandeCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for CertspDomandeCollectionProvider:ICertspDomandeProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CertspDomandeCollectionProvider : ICertspDomandeProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di CertspDomande
        protected CertspDomandeCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public CertspDomandeCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new CertspDomandeCollection(this);
        }

        //Costruttore3: ha in input certspdomandeCollectionObj - non popola la collection
        public CertspDomandeCollectionProvider(CertspDomandeCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public CertspDomandeCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new CertspDomandeCollection(this);
        }

        //Get e Set
        public CertspDomandeCollection CollectionObj
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
        public int SaveCollection(CertspDomandeCollection collectionObj)
        {
            return CertspDomandeDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(CertspDomande certspdomandeObj)
        {
            return CertspDomandeDAL.Save(_dbProviderObj, certspdomandeObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(CertspDomandeCollection collectionObj)
        {
            return CertspDomandeDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(CertspDomande certspdomandeObj)
        {
            return CertspDomandeDAL.Delete(_dbProviderObj, certspdomandeObj);
        }

        //getById
        public CertspDomande GetById(IntNT IdDomandaValue)
        {
            CertspDomande CertspDomandeTemp = CertspDomandeDAL.GetById(_dbProviderObj, IdDomandaValue);
            if (CertspDomandeTemp != null) CertspDomandeTemp.Provider = this;
            return CertspDomandeTemp;
        }

        //Select: popola la collection
        public CertspDomandeCollection Select(IntNT IddomandaEqualThis, IntNT IdattoEqualThis, DatetimeNT DatapresEqualThis,
DecimalNT SpeseammEqualThis, DecimalNT SpesapubbEqualThis, DecimalNT SftotEqualThis,
DecimalNT SfspesapubbEqualThis, DecimalNT SfspeseammEqualThis, DecimalNT SfspesapubbammEqualThis,
DecimalNT AstotEqualThis, DecimalNT AscopertoEqualThis, DecimalNT AsnoncopertoEqualThis)
        {
            CertspDomandeCollection CertspDomandeCollectionTemp = CertspDomandeDAL.Select(_dbProviderObj, IddomandaEqualThis, IdattoEqualThis, DatapresEqualThis,
SpeseammEqualThis, SpesapubbEqualThis, SftotEqualThis,
SfspesapubbEqualThis, SfspeseammEqualThis, SfspesapubbammEqualThis,
AstotEqualThis, AscopertoEqualThis, AsnoncopertoEqualThis);
            CertspDomandeCollectionTemp.Provider = this;
            return CertspDomandeCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_DOMANDE>
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
</CERTSP_DOMANDE>
*/
