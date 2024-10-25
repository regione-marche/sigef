using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ImpresaAggregazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IImpresaAggregazioneProvider
    {
        int Save(ImpresaAggregazione ImpresaAggregazioneObj);
        int SaveCollection(ImpresaAggregazioneCollection collectionObj);
        int Delete(ImpresaAggregazione ImpresaAggregazioneObj);
        int DeleteCollection(ImpresaAggregazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ImpresaAggregazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ImpresaAggregazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdAggregazione;
        private NullTypes.StringNT _CodRuolo;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.DecimalNT _Percentuale;
        private NullTypes.DatetimeNT _DataInizio;
        private NullTypes.IntNT _OperatoreInizio;
        private NullTypes.BoolNT _Attivo;
        private NullTypes.DatetimeNT _DataFine;
        private NullTypes.IntNT _OperatoreFine;
        private NullTypes.StringNT _Cuaa;
        private NullTypes.StringNT _CodiceFiscale;
        private NullTypes.StringNT _RagioneSociale;
        private NullTypes.StringNT _Denominazione;
        private NullTypes.StringNT _RuoloAggregazione;
        private NullTypes.StringNT _CodAteco2007;
        [NonSerialized] private IImpresaAggregazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaAggregazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ImpresaAggregazione()
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
        /// Corrisponde al campo:ID_AGGREGAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAggregazione
        {
            get { return _IdAggregazione; }
            set
            {
                if (IdAggregazione != value)
                {
                    _IdAggregazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_RUOLO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodRuolo
        {
            get { return _CodRuolo; }
            set
            {
                if (CodRuolo != value)
                {
                    _CodRuolo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresa
        {
            get { return _IdImpresa; }
            set
            {
                if (IdImpresa != value)
                {
                    _IdImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PERCENTUALE
        /// Tipo sul db:DECIMAL(10,4)
        /// </summary>
        public NullTypes.DecimalNT Percentuale
        {
            get { return _Percentuale; }
            set
            {
                if (Percentuale != value)
                {
                    _Percentuale = value;
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
        /// Corrisponde al campo:ATTIVO
        /// Tipo sul db:BIT
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
        /// Corrisponde al campo:CUAA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Cuaa
        {
            get { return _Cuaa; }
            set
            {
                if (Cuaa != value)
                {
                    _Cuaa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_FISCALE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CodiceFiscale
        {
            get { return _CodiceFiscale; }
            set
            {
                if (CodiceFiscale != value)
                {
                    _CodiceFiscale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGIONE_SOCIALE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagioneSociale
        {
            get { return _RagioneSociale; }
            set
            {
                if (RagioneSociale != value)
                {
                    _RagioneSociale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DENOMINAZIONE
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Denominazione
        {
            get { return _Denominazione; }
            set
            {
                if (Denominazione != value)
                {
                    _Denominazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RUOLO_AGGREGAZIONE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RuoloAggregazione
        {
            get { return _RuoloAggregazione; }
            set
            {
                if (RuoloAggregazione != value)
                {
                    _RuoloAggregazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ATECO2007
        /// Tipo sul db:CHAR(9)
        /// </summary>
        public NullTypes.StringNT CodAteco2007
        {
            get { return _CodAteco2007; }
            set
            {
                if (CodAteco2007 != value)
                {
                    _CodAteco2007 = value;
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
    /// Summary description for ImpresaAggregazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaAggregazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ImpresaAggregazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ImpresaAggregazione)info.GetValue(i.ToString(), typeof(ImpresaAggregazione)));
            }
        }

        //Costruttore
        public ImpresaAggregazioneCollection()
        {
            this.ItemType = typeof(ImpresaAggregazione);
        }

        //Costruttore con provider
        public ImpresaAggregazioneCollection(IImpresaAggregazioneProvider providerObj)
        {
            this.ItemType = typeof(ImpresaAggregazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ImpresaAggregazione this[int index]
        {
            get { return (ImpresaAggregazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ImpresaAggregazioneCollection GetChanges()
        {
            return (ImpresaAggregazioneCollection)base.GetChanges();
        }

        [NonSerialized] private IImpresaAggregazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaAggregazioneProvider Provider
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
        public int Add(ImpresaAggregazione ImpresaAggregazioneObj)
        {
            if (ImpresaAggregazioneObj.Provider == null) ImpresaAggregazioneObj.Provider = this.Provider;
            return base.Add(ImpresaAggregazioneObj);
        }

        //AddCollection
        public void AddCollection(ImpresaAggregazioneCollection ImpresaAggregazioneCollectionObj)
        {
            foreach (ImpresaAggregazione ImpresaAggregazioneObj in ImpresaAggregazioneCollectionObj)
                this.Add(ImpresaAggregazioneObj);
        }

        //Insert
        public void Insert(int index, ImpresaAggregazione ImpresaAggregazioneObj)
        {
            if (ImpresaAggregazioneObj.Provider == null) ImpresaAggregazioneObj.Provider = this.Provider;
            base.Insert(index, ImpresaAggregazioneObj);
        }

        //CollectionGetById
        public ImpresaAggregazione CollectionGetById(NullTypes.IntNT IdValue)
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
        public ImpresaAggregazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdAggregazioneEqualThis, NullTypes.StringNT CodRuoloEqualThis,
NullTypes.IntNT IdImpresaEqualThis, NullTypes.DecimalNT PercentualeEqualThis, NullTypes.DatetimeNT DataInizioEqualThis,
NullTypes.IntNT OperatoreInizioEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataFineEqualThis,
NullTypes.IntNT OperatoreFineEqualThis)
        {
            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionTemp = new ImpresaAggregazioneCollection();
            foreach (ImpresaAggregazione ImpresaAggregazioneItem in this)
            {
                if (((IdEqualThis == null) || ((ImpresaAggregazioneItem.Id != null) && (ImpresaAggregazioneItem.Id.Value == IdEqualThis.Value))) && ((IdAggregazioneEqualThis == null) || ((ImpresaAggregazioneItem.IdAggregazione != null) && (ImpresaAggregazioneItem.IdAggregazione.Value == IdAggregazioneEqualThis.Value))) && ((CodRuoloEqualThis == null) || ((ImpresaAggregazioneItem.CodRuolo != null) && (ImpresaAggregazioneItem.CodRuolo.Value == CodRuoloEqualThis.Value))) &&
((IdImpresaEqualThis == null) || ((ImpresaAggregazioneItem.IdImpresa != null) && (ImpresaAggregazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((PercentualeEqualThis == null) || ((ImpresaAggregazioneItem.Percentuale != null) && (ImpresaAggregazioneItem.Percentuale.Value == PercentualeEqualThis.Value))) && ((DataInizioEqualThis == null) || ((ImpresaAggregazioneItem.DataInizio != null) && (ImpresaAggregazioneItem.DataInizio.Value == DataInizioEqualThis.Value))) &&
((OperatoreInizioEqualThis == null) || ((ImpresaAggregazioneItem.OperatoreInizio != null) && (ImpresaAggregazioneItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) && ((AttivoEqualThis == null) || ((ImpresaAggregazioneItem.Attivo != null) && (ImpresaAggregazioneItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataFineEqualThis == null) || ((ImpresaAggregazioneItem.DataFine != null) && (ImpresaAggregazioneItem.DataFine.Value == DataFineEqualThis.Value))) &&
((OperatoreFineEqualThis == null) || ((ImpresaAggregazioneItem.OperatoreFine != null) && (ImpresaAggregazioneItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))))
                {
                    ImpresaAggregazioneCollectionTemp.Add(ImpresaAggregazioneItem);
                }
            }
            return ImpresaAggregazioneCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public ImpresaAggregazioneCollection Filter(NullTypes.IntNT IdAggregazioneEqualThis, NullTypes.StringNT CodRuoloEqualThis, NullTypes.IntNT IdImpresaEqualThis)
        {
            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionTemp = new ImpresaAggregazioneCollection();
            foreach (ImpresaAggregazione ImpresaAggregazioneItem in this)
            {
                if (((IdAggregazioneEqualThis == null) || ((ImpresaAggregazioneItem.IdAggregazione != null) && (ImpresaAggregazioneItem.IdAggregazione.Value == IdAggregazioneEqualThis.Value))) && ((CodRuoloEqualThis == null) || ((ImpresaAggregazioneItem.CodRuolo != null) && (ImpresaAggregazioneItem.CodRuolo.Value == CodRuoloEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaAggregazioneItem.IdImpresa != null) && (ImpresaAggregazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))))
                {
                    ImpresaAggregazioneCollectionTemp.Add(ImpresaAggregazioneItem);
                }
            }
            return ImpresaAggregazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ImpresaAggregazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ImpresaAggregazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaAggregazione ImpresaAggregazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ImpresaAggregazioneObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdAggregazione", ImpresaAggregazioneObj.IdAggregazione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodRuolo", ImpresaAggregazioneObj.CodRuolo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ImpresaAggregazioneObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "Percentuale", ImpresaAggregazioneObj.Percentuale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizio", ImpresaAggregazioneObj.DataInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInizio", ImpresaAggregazioneObj.OperatoreInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "Attivo", ImpresaAggregazioneObj.Attivo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFine", ImpresaAggregazioneObj.DataFine);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreFine", ImpresaAggregazioneObj.OperatoreFine);
        }
        //Insert
        private static int Insert(DbProvider db, ImpresaAggregazione ImpresaAggregazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZImpresaAggregazioneInsert", new string[] {"IdAggregazione", "CodRuolo",
"IdImpresa", "Percentuale", "DataInizio",
"OperatoreInizio", "Attivo", "DataFine",
"OperatoreFine",
}, new string[] {"int", "string",
"int", "decimal", "DateTime",
"int", "bool", "DateTime",
"int",
}, "");
                CompileIUCmd(false, insertCmd, ImpresaAggregazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ImpresaAggregazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaAggregazioneObj.IsDirty = false;
                ImpresaAggregazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ImpresaAggregazione ImpresaAggregazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaAggregazioneUpdate", new string[] {"Id", "IdAggregazione", "CodRuolo",
"IdImpresa", "Percentuale", "DataInizio",
"OperatoreInizio", "Attivo", "DataFine",
"OperatoreFine",
}, new string[] {"int", "int", "string",
"int", "decimal", "DateTime",
"int", "bool", "DateTime",
"int",
}, "");
                CompileIUCmd(true, updateCmd, ImpresaAggregazioneObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaAggregazioneObj.IsDirty = false;
                ImpresaAggregazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ImpresaAggregazione ImpresaAggregazioneObj)
        {
            switch (ImpresaAggregazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ImpresaAggregazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ImpresaAggregazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ImpresaAggregazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ImpresaAggregazioneCollection ImpresaAggregazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaAggregazioneUpdate", new string[] {"Id", "IdAggregazione", "CodRuolo",
"IdImpresa", "Percentuale", "DataInizio",
"OperatoreInizio", "Attivo", "DataFine",
"OperatoreFine",
}, new string[] {"int", "int", "string",
"int", "decimal", "DateTime",
"int", "bool", "DateTime",
"int",
}, "");
                IDbCommand insertCmd = db.InitCmd("ZImpresaAggregazioneInsert", new string[] {"IdAggregazione", "CodRuolo",
"IdImpresa", "Percentuale", "DataInizio",
"OperatoreInizio", "Attivo", "DataFine",
"OperatoreFine",
}, new string[] {"int", "string",
"int", "decimal", "DateTime",
"int", "bool", "DateTime",
"int",
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZImpresaAggregazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaAggregazioneCollectionObj.Count; i++)
                {
                    switch (ImpresaAggregazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ImpresaAggregazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ImpresaAggregazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ImpresaAggregazioneCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ImpresaAggregazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ImpresaAggregazioneCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ImpresaAggregazioneCollectionObj.Count; i++)
                {
                    if ((ImpresaAggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaAggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaAggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ImpresaAggregazioneCollectionObj[i].IsDirty = false;
                        ImpresaAggregazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((ImpresaAggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ImpresaAggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaAggregazioneCollectionObj[i].IsDirty = false;
                        ImpresaAggregazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ImpresaAggregazione ImpresaAggregazioneObj)
        {
            int returnValue = 0;
            if (ImpresaAggregazioneObj.IsPersistent)
            {
                returnValue = Delete(db, ImpresaAggregazioneObj.Id);
            }
            ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ImpresaAggregazioneObj.IsDirty = false;
            ImpresaAggregazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaAggregazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ImpresaAggregazioneCollection ImpresaAggregazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaAggregazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaAggregazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ImpresaAggregazioneCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ImpresaAggregazioneCollectionObj.Count; i++)
                {
                    if ((ImpresaAggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaAggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaAggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaAggregazioneCollectionObj[i].IsDirty = false;
                        ImpresaAggregazioneCollectionObj[i].IsPersistent = false;
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
        public static ImpresaAggregazione GetById(DbProvider db, int IdValue)
        {
            ImpresaAggregazione ImpresaAggregazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZImpresaAggregazioneGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ImpresaAggregazioneObj = GetFromDatareader(db);
                ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaAggregazioneObj.IsDirty = false;
                ImpresaAggregazioneObj.IsPersistent = true;
            }
            db.Close();
            return ImpresaAggregazioneObj;
        }

        //getFromDatareader
        public static ImpresaAggregazione GetFromDatareader(DbProvider db)
        {
            ImpresaAggregazione ImpresaAggregazioneObj = new ImpresaAggregazione();
            ImpresaAggregazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ImpresaAggregazioneObj.IdAggregazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AGGREGAZIONE"]);
            ImpresaAggregazioneObj.CodRuolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO"]);
            ImpresaAggregazioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            ImpresaAggregazioneObj.Percentuale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE"]);
            ImpresaAggregazioneObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
            ImpresaAggregazioneObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
            ImpresaAggregazioneObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
            ImpresaAggregazioneObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
            ImpresaAggregazioneObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
            ImpresaAggregazioneObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
            ImpresaAggregazioneObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
            ImpresaAggregazioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
            ImpresaAggregazioneObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
            ImpresaAggregazioneObj.RuoloAggregazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO_AGGREGAZIONE"]);
            ImpresaAggregazioneObj.CodAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ATECO2007"]);
            ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ImpresaAggregazioneObj.IsDirty = false;
            ImpresaAggregazioneObj.IsPersistent = true;
            return ImpresaAggregazioneObj;
        }

        //Find Select

        public static ImpresaAggregazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdAggregazioneEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DecimalNT PercentualeEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis)

        {

            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionObj = new ImpresaAggregazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresaaggregazionefindselect", new string[] {"Idequalthis", "IdAggregazioneequalthis", "CodRuoloequalthis",
"IdImpresaequalthis", "Percentualeequalthis", "DataInizioequalthis",
"OperatoreInizioequalthis", "Attivoequalthis", "DataFineequalthis",
"OperatoreFineequalthis"}, new string[] {"int", "int", "string",
"int", "decimal", "DateTime",
"int", "bool", "DateTime",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAggregazioneequalthis", IdAggregazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodRuoloequalthis", CodRuoloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Percentualeequalthis", PercentualeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
            ImpresaAggregazione ImpresaAggregazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaAggregazioneObj = GetFromDatareader(db);
                ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaAggregazioneObj.IsDirty = false;
                ImpresaAggregazioneObj.IsPersistent = true;
                ImpresaAggregazioneCollectionObj.Add(ImpresaAggregazioneObj);
            }
            db.Close();
            return ImpresaAggregazioneCollectionObj;
        }

        //Find Find

        public static ImpresaAggregazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAggregazioneEqualThis, SiarLibrary.NullTypes.StringNT CodRuoloEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis)

        {

            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionObj = new ImpresaAggregazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresaaggregazionefindfind", new string[] {"IdAggregazioneequalthis", "CodRuoloequalthis", "IdImpresaequalthis",
"Attivoequalthis", "Cuaaequalthis"}, new string[] {"int", "string", "int",
"bool", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAggregazioneequalthis", IdAggregazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodRuoloequalthis", CodRuoloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
            ImpresaAggregazione ImpresaAggregazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaAggregazioneObj = GetFromDatareader(db);
                ImpresaAggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaAggregazioneObj.IsDirty = false;
                ImpresaAggregazioneObj.IsPersistent = true;
                ImpresaAggregazioneCollectionObj.Add(ImpresaAggregazioneObj);
            }
            db.Close();
            return ImpresaAggregazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ImpresaAggregazioneCollectionProvider:IImpresaAggregazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaAggregazioneCollectionProvider : IImpresaAggregazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ImpresaAggregazione
        protected ImpresaAggregazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ImpresaAggregazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ImpresaAggregazioneCollection(this);
        }

        //Costruttore 2: popola la collection
        public ImpresaAggregazioneCollectionProvider(IntNT IdaggregazioneEqualThis, StringNT CodruoloEqualThis, IntNT IdimpresaEqualThis,
BoolNT AttivoEqualThis, StringNT CuaaEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdaggregazioneEqualThis, CodruoloEqualThis, IdimpresaEqualThis,
AttivoEqualThis, CuaaEqualThis);
        }

        //Costruttore3: ha in input impresaaggregazioneCollectionObj - non popola la collection
        public ImpresaAggregazioneCollectionProvider(ImpresaAggregazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ImpresaAggregazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ImpresaAggregazioneCollection(this);
        }

        //Get e Set
        public ImpresaAggregazioneCollection CollectionObj
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
        public int SaveCollection(ImpresaAggregazioneCollection collectionObj)
        {
            return ImpresaAggregazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ImpresaAggregazione impresaaggregazioneObj)
        {
            return ImpresaAggregazioneDAL.Save(_dbProviderObj, impresaaggregazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ImpresaAggregazioneCollection collectionObj)
        {
            return ImpresaAggregazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ImpresaAggregazione impresaaggregazioneObj)
        {
            return ImpresaAggregazioneDAL.Delete(_dbProviderObj, impresaaggregazioneObj);
        }

        //getById
        public ImpresaAggregazione GetById(IntNT IdValue)
        {
            ImpresaAggregazione ImpresaAggregazioneTemp = ImpresaAggregazioneDAL.GetById(_dbProviderObj, IdValue);
            if (ImpresaAggregazioneTemp != null) ImpresaAggregazioneTemp.Provider = this;
            return ImpresaAggregazioneTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ImpresaAggregazioneCollection Select(IntNT IdEqualThis, IntNT IdaggregazioneEqualThis, StringNT CodruoloEqualThis,
IntNT IdimpresaEqualThis, DecimalNT PercentualeEqualThis, DatetimeNT DatainizioEqualThis,
IntNT OperatoreinizioEqualThis, BoolNT AttivoEqualThis, DatetimeNT DatafineEqualThis,
IntNT OperatorefineEqualThis)
        {
            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionTemp = ImpresaAggregazioneDAL.Select(_dbProviderObj, IdEqualThis, IdaggregazioneEqualThis, CodruoloEqualThis,
IdimpresaEqualThis, PercentualeEqualThis, DatainizioEqualThis,
OperatoreinizioEqualThis, AttivoEqualThis, DatafineEqualThis,
OperatorefineEqualThis);
            ImpresaAggregazioneCollectionTemp.Provider = this;
            return ImpresaAggregazioneCollectionTemp;
        }

        //Find: popola la collection
        public ImpresaAggregazioneCollection Find(IntNT IdaggregazioneEqualThis, StringNT CodruoloEqualThis, IntNT IdimpresaEqualThis,
BoolNT AttivoEqualThis, StringNT CuaaEqualThis)
        {
            ImpresaAggregazioneCollection ImpresaAggregazioneCollectionTemp = ImpresaAggregazioneDAL.Find(_dbProviderObj, IdaggregazioneEqualThis, CodruoloEqualThis, IdimpresaEqualThis,
AttivoEqualThis, CuaaEqualThis);
            ImpresaAggregazioneCollectionTemp.Provider = this;
            return ImpresaAggregazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_AGGREGAZIONE>
  <ViewName>vIMPRESA_AGGREGAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, DATA_FINE, RAGIONE_SOCIALE">
      <ID_AGGREGAZIONE>Equal</ID_AGGREGAZIONE>
      <COD_RUOLO>Equal</COD_RUOLO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ATTIVO>Equal</ATTIVO>
      <CUAA>Equal</CUAA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_AGGREGAZIONE>Equal</ID_AGGREGAZIONE>
      <COD_RUOLO>Equal</COD_RUOLO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</IMPRESA_AGGREGAZIONE>
*/
