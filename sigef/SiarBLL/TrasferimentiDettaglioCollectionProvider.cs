using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TrasferimentiDettaglio
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITrasferimentiDettaglioProvider
    {
        int Save(TrasferimentiDettaglio TrasferimentiDettaglioObj);
        int SaveCollection(TrasferimentiDettaglioCollection collectionObj);
        int Delete(TrasferimentiDettaglio TrasferimentiDettaglioObj);
        int DeleteCollection(TrasferimentiDettaglioCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TrasferimentiDettaglio
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TrasferimentiDettaglio : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTrasferimentoDettaglio;
        private NullTypes.IntNT _IdTrasferimento;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _Operatore;
        private NullTypes.DatetimeNT _DataCreazione;
        [NonSerialized] private ITrasferimentiDettaglioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITrasferimentiDettaglioProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TrasferimentiDettaglio()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_TRASFERIMENTO_DETTAGLIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTrasferimentoDettaglio
        {
            get { return _IdTrasferimentoDettaglio; }
            set
            {
                if (IdTrasferimentoDettaglio != value)
                {
                    _IdTrasferimentoDettaglio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TRASFERIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTrasferimento
        {
            get { return _IdTrasferimento; }
            set
            {
                if (IdTrasferimento != value)
                {
                    _IdTrasferimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
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
    /// Summary description for TrasferimentiDettaglioCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TrasferimentiDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TrasferimentiDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TrasferimentiDettaglio)info.GetValue(i.ToString(), typeof(TrasferimentiDettaglio)));
            }
        }

        //Costruttore
        public TrasferimentiDettaglioCollection()
        {
            this.ItemType = typeof(TrasferimentiDettaglio);
        }

        //Costruttore con provider
        public TrasferimentiDettaglioCollection(ITrasferimentiDettaglioProvider providerObj)
        {
            this.ItemType = typeof(TrasferimentiDettaglio);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TrasferimentiDettaglio this[int index]
        {
            get { return (TrasferimentiDettaglio)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TrasferimentiDettaglioCollection GetChanges()
        {
            return (TrasferimentiDettaglioCollection)base.GetChanges();
        }

        [NonSerialized] private ITrasferimentiDettaglioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITrasferimentiDettaglioProvider Provider
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
        public int Add(TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            if (TrasferimentiDettaglioObj.Provider == null) TrasferimentiDettaglioObj.Provider = this.Provider;
            return base.Add(TrasferimentiDettaglioObj);
        }

        //AddCollection
        public void AddCollection(TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionObj)
        {
            foreach (TrasferimentiDettaglio TrasferimentiDettaglioObj in TrasferimentiDettaglioCollectionObj)
                this.Add(TrasferimentiDettaglioObj);
        }

        //Insert
        public void Insert(int index, TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            if (TrasferimentiDettaglioObj.Provider == null) TrasferimentiDettaglioObj.Provider = this.Provider;
            base.Insert(index, TrasferimentiDettaglioObj);
        }

        //CollectionGetById
        public TrasferimentiDettaglio CollectionGetById(NullTypes.IntNT IdTrasferimentoDettaglioValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTrasferimentoDettaglio == IdTrasferimentoDettaglioValue))
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
        public TrasferimentiDettaglioCollection SubSelect(NullTypes.IntNT IdTrasferimentoDettaglioEqualThis, NullTypes.IntNT IdTrasferimentoEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT OperatoreEqualThis,
NullTypes.DatetimeNT DataCreazioneEqualThis)
        {
            TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionTemp = new TrasferimentiDettaglioCollection();
            foreach (TrasferimentiDettaglio TrasferimentiDettaglioItem in this)
            {
                if (((IdTrasferimentoDettaglioEqualThis == null) || ((TrasferimentiDettaglioItem.IdTrasferimentoDettaglio != null) && (TrasferimentiDettaglioItem.IdTrasferimentoDettaglio.Value == IdTrasferimentoDettaglioEqualThis.Value))) && ((IdTrasferimentoEqualThis == null) || ((TrasferimentiDettaglioItem.IdTrasferimento != null) && (TrasferimentiDettaglioItem.IdTrasferimento.Value == IdTrasferimentoEqualThis.Value))) && ((ImportoEqualThis == null) || ((TrasferimentiDettaglioItem.Importo != null) && (TrasferimentiDettaglioItem.Importo.Value == ImportoEqualThis.Value))) &&
((IdBandoEqualThis == null) || ((TrasferimentiDettaglioItem.IdBando != null) && (TrasferimentiDettaglioItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((TrasferimentiDettaglioItem.IdProgetto != null) && (TrasferimentiDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((TrasferimentiDettaglioItem.Operatore != null) && (TrasferimentiDettaglioItem.Operatore.Value == OperatoreEqualThis.Value))) &&
((DataCreazioneEqualThis == null) || ((TrasferimentiDettaglioItem.DataCreazione != null) && (TrasferimentiDettaglioItem.DataCreazione.Value == DataCreazioneEqualThis.Value))))
                {
                    TrasferimentiDettaglioCollectionTemp.Add(TrasferimentiDettaglioItem);
                }
            }
            return TrasferimentiDettaglioCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TrasferimentiDettaglioDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TrasferimentiDettaglioDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TrasferimentiDettaglio TrasferimentiDettaglioObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTrasferimentoDettaglio", TrasferimentiDettaglioObj.IdTrasferimentoDettaglio);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdTrasferimento", TrasferimentiDettaglioObj.IdTrasferimento);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", TrasferimentiDettaglioObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdBando", TrasferimentiDettaglioObj.IdBando);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", TrasferimentiDettaglioObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", TrasferimentiDettaglioObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", TrasferimentiDettaglioObj.DataCreazione);
        }
        //Insert
        private static int Insert(DbProvider db, TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTrasferimentiDettaglioInsert", new string[] {"IdTrasferimento", "Importo",
"IdBando", "IdProgetto", "Operatore",
"DataCreazione"}, new string[] {"int", "decimal",
"int", "int", "int",
"DateTime"}, "");
                CompileIUCmd(false, insertCmd, TrasferimentiDettaglioObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TrasferimentiDettaglioObj.IdTrasferimentoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_DETTAGLIO"]);
                }
                TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiDettaglioObj.IsDirty = false;
                TrasferimentiDettaglioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTrasferimentiDettaglioUpdate", new string[] {"IdTrasferimentoDettaglio", "IdTrasferimento", "Importo",
"IdBando", "IdProgetto", "Operatore",
"DataCreazione"}, new string[] {"int", "int", "decimal",
"int", "int", "int",
"DateTime"}, "");
                CompileIUCmd(true, updateCmd, TrasferimentiDettaglioObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiDettaglioObj.IsDirty = false;
                TrasferimentiDettaglioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            switch (TrasferimentiDettaglioObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TrasferimentiDettaglioObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TrasferimentiDettaglioObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TrasferimentiDettaglioObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTrasferimentiDettaglioUpdate", new string[] {"IdTrasferimentoDettaglio", "IdTrasferimento", "Importo",
"IdBando", "IdProgetto", "Operatore",
"DataCreazione"}, new string[] {"int", "int", "decimal",
"int", "int", "int",
"DateTime"}, "");
                IDbCommand insertCmd = db.InitCmd("ZTrasferimentiDettaglioInsert", new string[] {"IdTrasferimento", "Importo",
"IdBando", "IdProgetto", "Operatore",
"DataCreazione"}, new string[] {"int", "decimal",
"int", "int", "int",
"DateTime"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDettaglioDelete", new string[] { "IdTrasferimentoDettaglio" }, new string[] { "int" }, "");
                for (int i = 0; i < TrasferimentiDettaglioCollectionObj.Count; i++)
                {
                    switch (TrasferimentiDettaglioCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TrasferimentiDettaglioCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TrasferimentiDettaglioCollectionObj[i].IdTrasferimentoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_DETTAGLIO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TrasferimentiDettaglioCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TrasferimentiDettaglioCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimentoDettaglio", (SiarLibrary.NullTypes.IntNT)TrasferimentiDettaglioCollectionObj[i].IdTrasferimentoDettaglio);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TrasferimentiDettaglioCollectionObj.Count; i++)
                {
                    if ((TrasferimentiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TrasferimentiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TrasferimentiDettaglioCollectionObj[i].IsDirty = false;
                        TrasferimentiDettaglioCollectionObj[i].IsPersistent = true;
                    }
                    if ((TrasferimentiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TrasferimentiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TrasferimentiDettaglioCollectionObj[i].IsDirty = false;
                        TrasferimentiDettaglioCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TrasferimentiDettaglio TrasferimentiDettaglioObj)
        {
            int returnValue = 0;
            if (TrasferimentiDettaglioObj.IsPersistent)
            {
                returnValue = Delete(db, TrasferimentiDettaglioObj.IdTrasferimentoDettaglio);
            }
            TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TrasferimentiDettaglioObj.IsDirty = false;
            TrasferimentiDettaglioObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTrasferimentoDettaglioValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDettaglioDelete", new string[] { "IdTrasferimentoDettaglio" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimentoDettaglio", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoDettaglioValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDettaglioDelete", new string[] { "IdTrasferimentoDettaglio" }, new string[] { "int" }, "");
                for (int i = 0; i < TrasferimentiDettaglioCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimentoDettaglio", TrasferimentiDettaglioCollectionObj[i].IdTrasferimentoDettaglio);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TrasferimentiDettaglioCollectionObj.Count; i++)
                {
                    if ((TrasferimentiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TrasferimentiDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TrasferimentiDettaglioCollectionObj[i].IsDirty = false;
                        TrasferimentiDettaglioCollectionObj[i].IsPersistent = false;
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
        public static TrasferimentiDettaglio GetById(DbProvider db, int IdTrasferimentoDettaglioValue)
        {
            TrasferimentiDettaglio TrasferimentiDettaglioObj = null;
            IDbCommand readCmd = db.InitCmd("ZTrasferimentiDettaglioGetById", new string[] { "IdTrasferimentoDettaglio" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTrasferimentoDettaglio", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoDettaglioValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TrasferimentiDettaglioObj = GetFromDatareader(db);
                TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiDettaglioObj.IsDirty = false;
                TrasferimentiDettaglioObj.IsPersistent = true;
            }
            db.Close();
            return TrasferimentiDettaglioObj;
        }

        //getFromDatareader
        public static TrasferimentiDettaglio GetFromDatareader(DbProvider db)
        {
            TrasferimentiDettaglio TrasferimentiDettaglioObj = new TrasferimentiDettaglio();
            TrasferimentiDettaglioObj.IdTrasferimentoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_DETTAGLIO"]);
            TrasferimentiDettaglioObj.IdTrasferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO"]);
            TrasferimentiDettaglioObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            TrasferimentiDettaglioObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            TrasferimentiDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            TrasferimentiDettaglioObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            TrasferimentiDettaglioObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TrasferimentiDettaglioObj.IsDirty = false;
            TrasferimentiDettaglioObj.IsPersistent = true;
            return TrasferimentiDettaglioObj;
        }

        //Find Select

        public static TrasferimentiDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTrasferimentoDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdTrasferimentoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis)

        {

            TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionObj = new TrasferimentiDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Ztrasferimentidettagliofindselect", new string[] {"IdTrasferimentoDettaglioequalthis", "IdTrasferimentoequalthis", "Importoequalthis",
"IdBandoequalthis", "IdProgettoequalthis", "Operatoreequalthis",
"DataCreazioneequalthis"}, new string[] {"int", "int", "decimal",
"int", "int", "int",
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTrasferimentoDettaglioequalthis", IdTrasferimentoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTrasferimentoequalthis", IdTrasferimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
            TrasferimentiDettaglio TrasferimentiDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TrasferimentiDettaglioObj = GetFromDatareader(db);
                TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiDettaglioObj.IsDirty = false;
                TrasferimentiDettaglioObj.IsPersistent = true;
                TrasferimentiDettaglioCollectionObj.Add(TrasferimentiDettaglioObj);
            }
            db.Close();
            return TrasferimentiDettaglioCollectionObj;
        }

        //Find Find

        public static TrasferimentiDettaglioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTrasferimentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

        {

            TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionObj = new TrasferimentiDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Ztrasferimentidettagliofindfind", new string[] {"IdTrasferimentoequalthis", "IdBandoequalthis", "IdProgettoequalthis",
"Operatoreequalthis"}, new string[] {"int", "int", "int",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTrasferimentoequalthis", IdTrasferimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            TrasferimentiDettaglio TrasferimentiDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TrasferimentiDettaglioObj = GetFromDatareader(db);
                TrasferimentiDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiDettaglioObj.IsDirty = false;
                TrasferimentiDettaglioObj.IsPersistent = true;
                TrasferimentiDettaglioCollectionObj.Add(TrasferimentiDettaglioObj);
            }
            db.Close();
            return TrasferimentiDettaglioCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TrasferimentiDettaglioCollectionProvider:ITrasferimentiDettaglioProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TrasferimentiDettaglioCollectionProvider : ITrasferimentiDettaglioProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TrasferimentiDettaglio
        protected TrasferimentiDettaglioCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TrasferimentiDettaglioCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TrasferimentiDettaglioCollection(this);
        }

        //Costruttore 2: popola la collection
        public TrasferimentiDettaglioCollectionProvider(IntNT IdtrasferimentoEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
IntNT OperatoreEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdtrasferimentoEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
OperatoreEqualThis);
        }

        //Costruttore3: ha in input trasferimentidettaglioCollectionObj - non popola la collection
        public TrasferimentiDettaglioCollectionProvider(TrasferimentiDettaglioCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TrasferimentiDettaglioCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TrasferimentiDettaglioCollection(this);
        }

        //Get e Set
        public TrasferimentiDettaglioCollection CollectionObj
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
        public int SaveCollection(TrasferimentiDettaglioCollection collectionObj)
        {
            return TrasferimentiDettaglioDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TrasferimentiDettaglio trasferimentidettaglioObj)
        {
            return TrasferimentiDettaglioDAL.Save(_dbProviderObj, trasferimentidettaglioObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TrasferimentiDettaglioCollection collectionObj)
        {
            return TrasferimentiDettaglioDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TrasferimentiDettaglio trasferimentidettaglioObj)
        {
            return TrasferimentiDettaglioDAL.Delete(_dbProviderObj, trasferimentidettaglioObj);
        }

        //getById
        public TrasferimentiDettaglio GetById(IntNT IdTrasferimentoDettaglioValue)
        {
            TrasferimentiDettaglio TrasferimentiDettaglioTemp = TrasferimentiDettaglioDAL.GetById(_dbProviderObj, IdTrasferimentoDettaglioValue);
            if (TrasferimentiDettaglioTemp != null) TrasferimentiDettaglioTemp.Provider = this;
            return TrasferimentiDettaglioTemp;
        }

        //Select: popola la collection
        public TrasferimentiDettaglioCollection Select(IntNT IdtrasferimentodettaglioEqualThis, IntNT IdtrasferimentoEqualThis, DecimalNT ImportoEqualThis,
IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT OperatoreEqualThis,
DatetimeNT DatacreazioneEqualThis)
        {
            TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionTemp = TrasferimentiDettaglioDAL.Select(_dbProviderObj, IdtrasferimentodettaglioEqualThis, IdtrasferimentoEqualThis, ImportoEqualThis,
IdbandoEqualThis, IdprogettoEqualThis, OperatoreEqualThis,
DatacreazioneEqualThis);
            TrasferimentiDettaglioCollectionTemp.Provider = this;
            return TrasferimentiDettaglioCollectionTemp;
        }

        //Find: popola la collection
        public TrasferimentiDettaglioCollection Find(IntNT IdtrasferimentoEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
IntNT OperatoreEqualThis)
        {
            TrasferimentiDettaglioCollection TrasferimentiDettaglioCollectionTemp = TrasferimentiDettaglioDAL.Find(_dbProviderObj, IdtrasferimentoEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
OperatoreEqualThis);
            TrasferimentiDettaglioCollectionTemp.Provider = this;
            return TrasferimentiDettaglioCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TRASFERIMENTI_DETTAGLIO>
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
      <ID_TRASFERIMENTO>Equal</ID_TRASFERIMENTO>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TRASFERIMENTI_DETTAGLIO>
*/
