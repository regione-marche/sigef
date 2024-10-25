using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per GraduatoriaProgettiAtti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IGraduatoriaProgettiAttiProvider
    {
        int Save(GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj);
        int SaveCollection(GraduatoriaProgettiAttiCollection collectionObj);
        int Delete(GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj);
        int DeleteCollection(GraduatoriaProgettiAttiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for GraduatoriaProgettiAtti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class GraduatoriaProgettiAtti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdGraduatoriaProgettiAtti;
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.BoolNT _FinanziabilitaTotale;
        private NullTypes.DatetimeNT _DataCreazione;
        private NullTypes.IntNT _OperatoreCreazione;
        private NullTypes.DatetimeNT _DataAggiornamento;
        private NullTypes.IntNT _OperatoreAggiornamento;
        [NonSerialized] private IGraduatoriaProgettiAttiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGraduatoriaProgettiAttiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public GraduatoriaProgettiAtti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_GRADUATORIA_PROGETTI_ATTI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdGraduatoriaProgettiAtti
        {
            get { return _IdGraduatoriaProgettiAtti; }
            set
            {
                if (IdGraduatoriaProgettiAtti != value)
                {
                    _IdGraduatoriaProgettiAtti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdBando
        {
            get { return _IdBando; }
            set
            {
                if (IdBando != value)
                {
                    _IdBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgetto
        {
            get { return _IdProgetto; }
            set
            {
                if (IdProgetto != value)
                {
                    _IdProgetto = value;
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
        /// Corrisponde al campo:IMPORTO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT Importo
        {
            get { return _Importo; }
            set
            {
                if (Importo != value)
                {
                    _Importo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FINANZIABILITA_TOTALE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FinanziabilitaTotale
        {
            get { return _FinanziabilitaTotale; }
            set
            {
                if (FinanziabilitaTotale != value)
                {
                    _FinanziabilitaTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CREAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCreazione
        {
            get { return _DataCreazione; }
            set
            {
                if (DataCreazione != value)
                {
                    _DataCreazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_CREAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreCreazione
        {
            get { return _OperatoreCreazione; }
            set
            {
                if (OperatoreCreazione != value)
                {
                    _OperatoreCreazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_AGGIORNAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAggiornamento
        {
            get { return _DataAggiornamento; }
            set
            {
                if (DataAggiornamento != value)
                {
                    _DataAggiornamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_AGGIORNAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreAggiornamento
        {
            get { return _OperatoreAggiornamento; }
            set
            {
                if (OperatoreAggiornamento != value)
                {
                    _OperatoreAggiornamento = value;
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
    /// Summary description for GraduatoriaProgettiAttiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GraduatoriaProgettiAttiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private GraduatoriaProgettiAttiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((GraduatoriaProgettiAtti)info.GetValue(i.ToString(), typeof(GraduatoriaProgettiAtti)));
            }
        }

        //Costruttore
        public GraduatoriaProgettiAttiCollection()
        {
            this.ItemType = typeof(GraduatoriaProgettiAtti);
        }

        //Costruttore con provider
        public GraduatoriaProgettiAttiCollection(IGraduatoriaProgettiAttiProvider providerObj)
        {
            this.ItemType = typeof(GraduatoriaProgettiAtti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new GraduatoriaProgettiAtti this[int index]
        {
            get { return (GraduatoriaProgettiAtti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new GraduatoriaProgettiAttiCollection GetChanges()
        {
            return (GraduatoriaProgettiAttiCollection)base.GetChanges();
        }

        [NonSerialized] private IGraduatoriaProgettiAttiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IGraduatoriaProgettiAttiProvider Provider
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
        public int Add(GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            if (GraduatoriaProgettiAttiObj.Provider == null) GraduatoriaProgettiAttiObj.Provider = this.Provider;
            return base.Add(GraduatoriaProgettiAttiObj);
        }

        //AddCollection
        public void AddCollection(GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionObj)
        {
            foreach (GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj in GraduatoriaProgettiAttiCollectionObj)
                this.Add(GraduatoriaProgettiAttiObj);
        }

        //Insert
        public void Insert(int index, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            if (GraduatoriaProgettiAttiObj.Provider == null) GraduatoriaProgettiAttiObj.Provider = this.Provider;
            base.Insert(index, GraduatoriaProgettiAttiObj);
        }

        //CollectionGetById
        public GraduatoriaProgettiAtti CollectionGetById(NullTypes.IntNT IdGraduatoriaProgettiAttiValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdGraduatoriaProgettiAtti == IdGraduatoriaProgettiAttiValue))
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
        public GraduatoriaProgettiAttiCollection SubSelect(NullTypes.IntNT IdGraduatoriaProgettiAttiEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdAttoEqualThis, NullTypes.DecimalNT ImportoEqualThis, NullTypes.BoolNT FinanziabilitaTotaleEqualThis,
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis,
NullTypes.IntNT OperatoreAggiornamentoEqualThis)
        {
            GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionTemp = new GraduatoriaProgettiAttiCollection();
            foreach (GraduatoriaProgettiAtti GraduatoriaProgettiAttiItem in this)
            {
                if (((IdGraduatoriaProgettiAttiEqualThis == null) || ((GraduatoriaProgettiAttiItem.IdGraduatoriaProgettiAtti != null) && (GraduatoriaProgettiAttiItem.IdGraduatoriaProgettiAtti.Value == IdGraduatoriaProgettiAttiEqualThis.Value))) && ((IdBandoEqualThis == null) || ((GraduatoriaProgettiAttiItem.IdBando != null) && (GraduatoriaProgettiAttiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((GraduatoriaProgettiAttiItem.IdProgetto != null) && (GraduatoriaProgettiAttiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdAttoEqualThis == null) || ((GraduatoriaProgettiAttiItem.IdAtto != null) && (GraduatoriaProgettiAttiItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((ImportoEqualThis == null) || ((GraduatoriaProgettiAttiItem.Importo != null) && (GraduatoriaProgettiAttiItem.Importo.Value == ImportoEqualThis.Value))) && ((FinanziabilitaTotaleEqualThis == null) || ((GraduatoriaProgettiAttiItem.FinanziabilitaTotale != null) && (GraduatoriaProgettiAttiItem.FinanziabilitaTotale.Value == FinanziabilitaTotaleEqualThis.Value))) &&
((DataCreazioneEqualThis == null) || ((GraduatoriaProgettiAttiItem.DataCreazione != null) && (GraduatoriaProgettiAttiItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((GraduatoriaProgettiAttiItem.OperatoreCreazione != null) && (GraduatoriaProgettiAttiItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((GraduatoriaProgettiAttiItem.DataAggiornamento != null) && (GraduatoriaProgettiAttiItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) &&
((OperatoreAggiornamentoEqualThis == null) || ((GraduatoriaProgettiAttiItem.OperatoreAggiornamento != null) && (GraduatoriaProgettiAttiItem.OperatoreAggiornamento.Value == OperatoreAggiornamentoEqualThis.Value))))
                {
                    GraduatoriaProgettiAttiCollectionTemp.Add(GraduatoriaProgettiAttiItem);
                }
            }
            return GraduatoriaProgettiAttiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for GraduatoriaProgettiAttiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class GraduatoriaProgettiAttiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdGraduatoriaProgettiAtti", GraduatoriaProgettiAttiObj.IdGraduatoriaProgettiAtti);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdBando", GraduatoriaProgettiAttiObj.IdBando);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", GraduatoriaProgettiAttiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", GraduatoriaProgettiAttiObj.IdAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", GraduatoriaProgettiAttiObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "FinanziabilitaTotale", GraduatoriaProgettiAttiObj.FinanziabilitaTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", GraduatoriaProgettiAttiObj.DataCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreCreazione", GraduatoriaProgettiAttiObj.OperatoreCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAggiornamento", GraduatoriaProgettiAttiObj.DataAggiornamento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreAggiornamento", GraduatoriaProgettiAttiObj.OperatoreAggiornamento);
        }
        //Insert
        private static int Insert(DbProvider db, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZGraduatoriaProgettiAttiInsert", new string[] {"IdBando", "IdProgetto",
"IdAtto", "Importo", "FinanziabilitaTotale",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento"}, new string[] {"int", "int",
"int", "decimal", "bool",
"DateTime", "int", "DateTime",
"int"}, "");
                CompileIUCmd(false, insertCmd, GraduatoriaProgettiAttiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    GraduatoriaProgettiAttiObj.IdGraduatoriaProgettiAtti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_ATTI"]);
                }
                GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GraduatoriaProgettiAttiObj.IsDirty = false;
                GraduatoriaProgettiAttiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGraduatoriaProgettiAttiUpdate", new string[] {"IdGraduatoriaProgettiAtti", "IdBando", "IdProgetto",
"IdAtto", "Importo", "FinanziabilitaTotale",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento"}, new string[] {"int", "int", "int",
"int", "decimal", "bool",
"DateTime", "int", "DateTime",
"int"}, "");
                CompileIUCmd(true, updateCmd, GraduatoriaProgettiAttiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GraduatoriaProgettiAttiObj.IsDirty = false;
                GraduatoriaProgettiAttiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            switch (GraduatoriaProgettiAttiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, GraduatoriaProgettiAttiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, GraduatoriaProgettiAttiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, GraduatoriaProgettiAttiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZGraduatoriaProgettiAttiUpdate", new string[] {"IdGraduatoriaProgettiAtti", "IdBando", "IdProgetto",
"IdAtto", "Importo", "FinanziabilitaTotale",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento"}, new string[] {"int", "int", "int",
"int", "decimal", "bool",
"DateTime", "int", "DateTime",
"int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZGraduatoriaProgettiAttiInsert", new string[] {"IdBando", "IdProgetto",
"IdAtto", "Importo", "FinanziabilitaTotale",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento"}, new string[] {"int", "int",
"int", "decimal", "bool",
"DateTime", "int", "DateTime",
"int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZGraduatoriaProgettiAttiDelete", new string[] { "IdGraduatoriaProgettiAtti" }, new string[] { "int" }, "");
                for (int i = 0; i < GraduatoriaProgettiAttiCollectionObj.Count; i++)
                {
                    switch (GraduatoriaProgettiAttiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, GraduatoriaProgettiAttiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    GraduatoriaProgettiAttiCollectionObj[i].IdGraduatoriaProgettiAtti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_ATTI"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, GraduatoriaProgettiAttiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (GraduatoriaProgettiAttiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGraduatoriaProgettiAtti", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiAttiCollectionObj[i].IdGraduatoriaProgettiAtti);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < GraduatoriaProgettiAttiCollectionObj.Count; i++)
                {
                    if ((GraduatoriaProgettiAttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiAttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GraduatoriaProgettiAttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        GraduatoriaProgettiAttiCollectionObj[i].IsDirty = false;
                        GraduatoriaProgettiAttiCollectionObj[i].IsPersistent = true;
                    }
                    if ((GraduatoriaProgettiAttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        GraduatoriaProgettiAttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GraduatoriaProgettiAttiCollectionObj[i].IsDirty = false;
                        GraduatoriaProgettiAttiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj)
        {
            int returnValue = 0;
            if (GraduatoriaProgettiAttiObj.IsPersistent)
            {
                returnValue = Delete(db, GraduatoriaProgettiAttiObj.IdGraduatoriaProgettiAtti);
            }
            GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            GraduatoriaProgettiAttiObj.IsDirty = false;
            GraduatoriaProgettiAttiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdGraduatoriaProgettiAttiValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGraduatoriaProgettiAttiDelete", new string[] { "IdGraduatoriaProgettiAtti" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGraduatoriaProgettiAtti", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiAttiValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZGraduatoriaProgettiAttiDelete", new string[] { "IdGraduatoriaProgettiAtti" }, new string[] { "int" }, "");
                for (int i = 0; i < GraduatoriaProgettiAttiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdGraduatoriaProgettiAtti", GraduatoriaProgettiAttiCollectionObj[i].IdGraduatoriaProgettiAtti);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < GraduatoriaProgettiAttiCollectionObj.Count; i++)
                {
                    if ((GraduatoriaProgettiAttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiAttiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        GraduatoriaProgettiAttiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        GraduatoriaProgettiAttiCollectionObj[i].IsDirty = false;
                        GraduatoriaProgettiAttiCollectionObj[i].IsPersistent = false;
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
        public static GraduatoriaProgettiAtti GetById(DbProvider db, int IdGraduatoriaProgettiAttiValue)
        {
            GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj = null;
            IDbCommand readCmd = db.InitCmd("ZGraduatoriaProgettiAttiGetById", new string[] { "IdGraduatoriaProgettiAtti" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdGraduatoriaProgettiAtti", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiAttiValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                GraduatoriaProgettiAttiObj = GetFromDatareader(db);
                GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GraduatoriaProgettiAttiObj.IsDirty = false;
                GraduatoriaProgettiAttiObj.IsPersistent = true;
            }
            db.Close();
            return GraduatoriaProgettiAttiObj;
        }

        //getFromDatareader
        public static GraduatoriaProgettiAtti GetFromDatareader(DbProvider db)
        {
            GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj = new GraduatoriaProgettiAtti();
            GraduatoriaProgettiAttiObj.IdGraduatoriaProgettiAtti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_ATTI"]);
            GraduatoriaProgettiAttiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            GraduatoriaProgettiAttiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            GraduatoriaProgettiAttiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            GraduatoriaProgettiAttiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            GraduatoriaProgettiAttiObj.FinanziabilitaTotale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FINANZIABILITA_TOTALE"]);
            GraduatoriaProgettiAttiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            GraduatoriaProgettiAttiObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
            GraduatoriaProgettiAttiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
            GraduatoriaProgettiAttiObj.OperatoreAggiornamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_AGGIORNAMENTO"]);
            GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            GraduatoriaProgettiAttiObj.IsDirty = false;
            GraduatoriaProgettiAttiObj.IsPersistent = true;
            return GraduatoriaProgettiAttiObj;
        }

        //Find Select

        public static GraduatoriaProgettiAttiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaProgettiAttiEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.BoolNT FinanziabilitaTotaleEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreAggiornamentoEqualThis)

        {

            GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionObj = new GraduatoriaProgettiAttiCollection();

            IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettiattifindselect", new string[] {"IdGraduatoriaProgettiAttiequalthis", "IdBandoequalthis", "IdProgettoequalthis",
"IdAttoequalthis", "Importoequalthis", "FinanziabilitaTotaleequalthis",
"DataCreazioneequalthis", "OperatoreCreazioneequalthis", "DataAggiornamentoequalthis",
"OperatoreAggiornamentoequalthis"}, new string[] {"int", "int", "int",
"int", "decimal", "bool",
"DateTime", "int", "DateTime",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGraduatoriaProgettiAttiequalthis", IdGraduatoriaProgettiAttiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FinanziabilitaTotaleequalthis", FinanziabilitaTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreAggiornamentoequalthis", OperatoreAggiornamentoEqualThis);
            GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GraduatoriaProgettiAttiObj = GetFromDatareader(db);
                GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GraduatoriaProgettiAttiObj.IsDirty = false;
                GraduatoriaProgettiAttiObj.IsPersistent = true;
                GraduatoriaProgettiAttiCollectionObj.Add(GraduatoriaProgettiAttiObj);
            }
            db.Close();
            return GraduatoriaProgettiAttiCollectionObj;
        }

        //Find Find

        public static GraduatoriaProgettiAttiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis,
SiarLibrary.NullTypes.BoolNT FinanziabilitaTotaleEqualThis)

        {

            GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionObj = new GraduatoriaProgettiAttiCollection();

            IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettiattifindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdAttoequalthis",
"FinanziabilitaTotaleequalthis"}, new string[] {"int", "int", "int",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FinanziabilitaTotaleequalthis", FinanziabilitaTotaleEqualThis);
            GraduatoriaProgettiAtti GraduatoriaProgettiAttiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                GraduatoriaProgettiAttiObj = GetFromDatareader(db);
                GraduatoriaProgettiAttiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                GraduatoriaProgettiAttiObj.IsDirty = false;
                GraduatoriaProgettiAttiObj.IsPersistent = true;
                GraduatoriaProgettiAttiCollectionObj.Add(GraduatoriaProgettiAttiObj);
            }
            db.Close();
            return GraduatoriaProgettiAttiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for GraduatoriaProgettiAttiCollectionProvider:IGraduatoriaProgettiAttiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class GraduatoriaProgettiAttiCollectionProvider : IGraduatoriaProgettiAttiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di GraduatoriaProgettiAtti
        protected GraduatoriaProgettiAttiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public GraduatoriaProgettiAttiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new GraduatoriaProgettiAttiCollection(this);
        }

        //Costruttore 2: popola la collection
        public GraduatoriaProgettiAttiCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdattoEqualThis,
BoolNT FinanziabilitatotaleEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdattoEqualThis,
FinanziabilitatotaleEqualThis);
        }

        //Costruttore3: ha in input graduatoriaprogettiattiCollectionObj - non popola la collection
        public GraduatoriaProgettiAttiCollectionProvider(GraduatoriaProgettiAttiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public GraduatoriaProgettiAttiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new GraduatoriaProgettiAttiCollection(this);
        }

        //Get e Set
        public GraduatoriaProgettiAttiCollection CollectionObj
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
        public int SaveCollection(GraduatoriaProgettiAttiCollection collectionObj)
        {
            return GraduatoriaProgettiAttiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(GraduatoriaProgettiAtti graduatoriaprogettiattiObj)
        {
            return GraduatoriaProgettiAttiDAL.Save(_dbProviderObj, graduatoriaprogettiattiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(GraduatoriaProgettiAttiCollection collectionObj)
        {
            return GraduatoriaProgettiAttiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(GraduatoriaProgettiAtti graduatoriaprogettiattiObj)
        {
            return GraduatoriaProgettiAttiDAL.Delete(_dbProviderObj, graduatoriaprogettiattiObj);
        }

        //getById
        public GraduatoriaProgettiAtti GetById(IntNT IdGraduatoriaProgettiAttiValue)
        {
            GraduatoriaProgettiAtti GraduatoriaProgettiAttiTemp = GraduatoriaProgettiAttiDAL.GetById(_dbProviderObj, IdGraduatoriaProgettiAttiValue);
            if (GraduatoriaProgettiAttiTemp != null) GraduatoriaProgettiAttiTemp.Provider = this;
            return GraduatoriaProgettiAttiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public GraduatoriaProgettiAttiCollection Select(IntNT IdgraduatoriaprogettiattiEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdattoEqualThis, DecimalNT ImportoEqualThis, BoolNT FinanziabilitatotaleEqualThis,
DatetimeNT DatacreazioneEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DataaggiornamentoEqualThis,
IntNT OperatoreaggiornamentoEqualThis)
        {
            GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionTemp = GraduatoriaProgettiAttiDAL.Select(_dbProviderObj, IdgraduatoriaprogettiattiEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
IdattoEqualThis, ImportoEqualThis, FinanziabilitatotaleEqualThis,
DatacreazioneEqualThis, OperatorecreazioneEqualThis, DataaggiornamentoEqualThis,
OperatoreaggiornamentoEqualThis);
            GraduatoriaProgettiAttiCollectionTemp.Provider = this;
            return GraduatoriaProgettiAttiCollectionTemp;
        }

        //Find: popola la collection
        public GraduatoriaProgettiAttiCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdattoEqualThis,
BoolNT FinanziabilitatotaleEqualThis)
        {
            GraduatoriaProgettiAttiCollection GraduatoriaProgettiAttiCollectionTemp = GraduatoriaProgettiAttiDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdattoEqualThis,
FinanziabilitatotaleEqualThis);
            GraduatoriaProgettiAttiCollectionTemp.Provider = this;
            return GraduatoriaProgettiAttiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_ATTI>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ATTO>Equal</ID_ATTO>
      <FINANZIABILITA_TOTALE>Equal</FINANZIABILITA_TOTALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_ATTI>
*/
