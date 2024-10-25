using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Trasferimenti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITrasferimentiProvider
    {
        int Save(Trasferimenti TrasferimentiObj);
        int SaveCollection(TrasferimentiCollection collectionObj);
        int Delete(Trasferimenti TrasferimentiObj);
        int DeleteCollection(TrasferimentiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Trasferimenti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Trasferimenti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTrasferimento;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.StringNT _CausaleTrasferimento;
        private NullTypes.IntNT _Operatore;
        private NullTypes.DatetimeNT _DataCreazione;
        private NullTypes.IntNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _Registro;
        private NullTypes.StringNT _CfUtente;
        private NullTypes.StringNT _Nominativo;
        [NonSerialized] private ITrasferimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITrasferimentiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Trasferimenti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:CAUSALE_TRASFERIMENTO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CausaleTrasferimento
        {
            get { return _CausaleTrasferimento; }
            set
            {
                if (CausaleTrasferimento != value)
                {
                    _CausaleTrasferimento = value;
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

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Numero
        {
            get { return _Numero; }
            set
            {
                if (Numero != value)
                {
                    _Numero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Data
        {
            get { return _Data; }
            set
            {
                if (Data != value)
                {
                    _Data = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Registro
        {
            get { return _Registro; }
            set
            {
                if (Registro != value)
                {
                    _Registro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtente
        {
            get { return _CfUtente; }
            set
            {
                if (CfUtente != value)
                {
                    _CfUtente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Nominativo
        {
            get { return _Nominativo; }
            set
            {
                if (Nominativo != value)
                {
                    _Nominativo = value;
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
    /// Summary description for TrasferimentiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TrasferimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TrasferimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Trasferimenti)info.GetValue(i.ToString(), typeof(Trasferimenti)));
            }
        }

        //Costruttore
        public TrasferimentiCollection()
        {
            this.ItemType = typeof(Trasferimenti);
        }

        //Costruttore con provider
        public TrasferimentiCollection(ITrasferimentiProvider providerObj)
        {
            this.ItemType = typeof(Trasferimenti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Trasferimenti this[int index]
        {
            get { return (Trasferimenti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TrasferimentiCollection GetChanges()
        {
            return (TrasferimentiCollection)base.GetChanges();
        }

        [NonSerialized] private ITrasferimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITrasferimentiProvider Provider
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
        public int Add(Trasferimenti TrasferimentiObj)
        {
            if (TrasferimentiObj.Provider == null) TrasferimentiObj.Provider = this.Provider;
            return base.Add(TrasferimentiObj);
        }

        //AddCollection
        public void AddCollection(TrasferimentiCollection TrasferimentiCollectionObj)
        {
            foreach (Trasferimenti TrasferimentiObj in TrasferimentiCollectionObj)
                this.Add(TrasferimentiObj);
        }

        //Insert
        public void Insert(int index, Trasferimenti TrasferimentiObj)
        {
            if (TrasferimentiObj.Provider == null) TrasferimentiObj.Provider = this.Provider;
            base.Insert(index, TrasferimentiObj);
        }

        //CollectionGetById
        public Trasferimenti CollectionGetById(NullTypes.IntNT IdTrasferimentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTrasferimento == IdTrasferimentoValue))
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
        public TrasferimentiCollection SubSelect(NullTypes.IntNT IdTrasferimentoEqualThis, NullTypes.IntNT IdAttoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.DecimalNT ImportoEqualThis, NullTypes.StringNT CausaleTrasferimentoEqualThis, NullTypes.IntNT OperatoreEqualThis,
NullTypes.DatetimeNT DataCreazioneEqualThis)
        {
            TrasferimentiCollection TrasferimentiCollectionTemp = new TrasferimentiCollection();
            foreach (Trasferimenti TrasferimentiItem in this)
            {
                if (((IdTrasferimentoEqualThis == null) || ((TrasferimentiItem.IdTrasferimento != null) && (TrasferimentiItem.IdTrasferimento.Value == IdTrasferimentoEqualThis.Value))) && ((IdAttoEqualThis == null) || ((TrasferimentiItem.IdAtto != null) && (TrasferimentiItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((TrasferimentiItem.IdImpresa != null) && (TrasferimentiItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((ImportoEqualThis == null) || ((TrasferimentiItem.Importo != null) && (TrasferimentiItem.Importo.Value == ImportoEqualThis.Value))) && ((CausaleTrasferimentoEqualThis == null) || ((TrasferimentiItem.CausaleTrasferimento != null) && (TrasferimentiItem.CausaleTrasferimento.Value == CausaleTrasferimentoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((TrasferimentiItem.Operatore != null) && (TrasferimentiItem.Operatore.Value == OperatoreEqualThis.Value))) &&
((DataCreazioneEqualThis == null) || ((TrasferimentiItem.DataCreazione != null) && (TrasferimentiItem.DataCreazione.Value == DataCreazioneEqualThis.Value))))
                {
                    TrasferimentiCollectionTemp.Add(TrasferimentiItem);
                }
            }
            return TrasferimentiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TrasferimentiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TrasferimentiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Trasferimenti TrasferimentiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTrasferimento", TrasferimentiObj.IdTrasferimento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", TrasferimentiObj.IdAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", TrasferimentiObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", TrasferimentiObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "CausaleTrasferimento", TrasferimentiObj.CausaleTrasferimento);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", TrasferimentiObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", TrasferimentiObj.DataCreazione);
        }
        //Insert
        private static int Insert(DbProvider db, Trasferimenti TrasferimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTrasferimentiInsert", new string[] {"IdAtto", "IdImpresa",
"Importo", "CausaleTrasferimento", "Operatore",
"DataCreazione", }, new string[] {"int", "int",
"decimal", "string", "int",
"DateTime", }, "");
                CompileIUCmd(false, insertCmd, TrasferimentiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TrasferimentiObj.IdTrasferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO"]);
                }
                TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiObj.IsDirty = false;
                TrasferimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Trasferimenti TrasferimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTrasferimentiUpdate", new string[] {"IdTrasferimento", "IdAtto", "IdImpresa",
"Importo", "CausaleTrasferimento", "Operatore",
"DataCreazione", }, new string[] {"int", "int", "int",
"decimal", "string", "int",
"DateTime", }, "");
                CompileIUCmd(true, updateCmd, TrasferimentiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiObj.IsDirty = false;
                TrasferimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Trasferimenti TrasferimentiObj)
        {
            switch (TrasferimentiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TrasferimentiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TrasferimentiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TrasferimentiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TrasferimentiCollection TrasferimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTrasferimentiUpdate", new string[] {"IdTrasferimento", "IdAtto", "IdImpresa",
"Importo", "CausaleTrasferimento", "Operatore",
"DataCreazione", }, new string[] {"int", "int", "int",
"decimal", "string", "int",
"DateTime", }, "");
                IDbCommand insertCmd = db.InitCmd("ZTrasferimentiInsert", new string[] {"IdAtto", "IdImpresa",
"Importo", "CausaleTrasferimento", "Operatore",
"DataCreazione", }, new string[] {"int", "int",
"decimal", "string", "int",
"DateTime", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDelete", new string[] { "IdTrasferimento" }, new string[] { "int" }, "");
                for (int i = 0; i < TrasferimentiCollectionObj.Count; i++)
                {
                    switch (TrasferimentiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TrasferimentiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TrasferimentiCollectionObj[i].IdTrasferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TrasferimentiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TrasferimentiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimento", (SiarLibrary.NullTypes.IntNT)TrasferimentiCollectionObj[i].IdTrasferimento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TrasferimentiCollectionObj.Count; i++)
                {
                    if ((TrasferimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TrasferimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TrasferimentiCollectionObj[i].IsDirty = false;
                        TrasferimentiCollectionObj[i].IsPersistent = true;
                    }
                    if ((TrasferimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TrasferimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TrasferimentiCollectionObj[i].IsDirty = false;
                        TrasferimentiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Trasferimenti TrasferimentiObj)
        {
            int returnValue = 0;
            if (TrasferimentiObj.IsPersistent)
            {
                returnValue = Delete(db, TrasferimentiObj.IdTrasferimento);
            }
            TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TrasferimentiObj.IsDirty = false;
            TrasferimentiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTrasferimentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDelete", new string[] { "IdTrasferimento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimento", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TrasferimentiCollection TrasferimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTrasferimentiDelete", new string[] { "IdTrasferimento" }, new string[] { "int" }, "");
                for (int i = 0; i < TrasferimentiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTrasferimento", TrasferimentiCollectionObj[i].IdTrasferimento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TrasferimentiCollectionObj.Count; i++)
                {
                    if ((TrasferimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TrasferimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TrasferimentiCollectionObj[i].IsDirty = false;
                        TrasferimentiCollectionObj[i].IsPersistent = false;
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
        public static Trasferimenti GetById(DbProvider db, int IdTrasferimentoValue)
        {
            Trasferimenti TrasferimentiObj = null;
            IDbCommand readCmd = db.InitCmd("ZTrasferimentiGetById", new string[] { "IdTrasferimento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTrasferimento", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TrasferimentiObj = GetFromDatareader(db);
                TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiObj.IsDirty = false;
                TrasferimentiObj.IsPersistent = true;
            }
            db.Close();
            return TrasferimentiObj;
        }

        //getFromDatareader
        public static Trasferimenti GetFromDatareader(DbProvider db)
        {
            Trasferimenti TrasferimentiObj = new Trasferimenti();
            TrasferimentiObj.IdTrasferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO"]);
            TrasferimentiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            TrasferimentiObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            TrasferimentiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            TrasferimentiObj.CausaleTrasferimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAUSALE_TRASFERIMENTO"]);
            TrasferimentiObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            TrasferimentiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            TrasferimentiObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
            TrasferimentiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            TrasferimentiObj.Registro = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO"]);
            TrasferimentiObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
            TrasferimentiObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TrasferimentiObj.IsDirty = false;
            TrasferimentiObj.IsPersistent = true;
            return TrasferimentiObj;
        }

        //Find Select

        public static TrasferimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTrasferimentoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.StringNT CausaleTrasferimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis)

        {

            TrasferimentiCollection TrasferimentiCollectionObj = new TrasferimentiCollection();

            IDbCommand findCmd = db.InitCmd("Ztrasferimentifindselect", new string[] {"IdTrasferimentoequalthis", "IdAttoequalthis", "IdImpresaequalthis",
"Importoequalthis", "CausaleTrasferimentoequalthis", "Operatoreequalthis",
"DataCreazioneequalthis"}, new string[] {"int", "int", "int",
"decimal", "string", "int",
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTrasferimentoequalthis", IdTrasferimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CausaleTrasferimentoequalthis", CausaleTrasferimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
            Trasferimenti TrasferimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TrasferimentiObj = GetFromDatareader(db);
                TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiObj.IsDirty = false;
                TrasferimentiObj.IsPersistent = true;
                TrasferimentiCollectionObj.Add(TrasferimentiObj);
            }
            db.Close();
            return TrasferimentiCollectionObj;
        }

        //Find Find

        public static TrasferimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

        {

            TrasferimentiCollection TrasferimentiCollectionObj = new TrasferimentiCollection();

            IDbCommand findCmd = db.InitCmd("Ztrasferimentifindfind", new string[] { "IdImpresaequalthis", "Operatoreequalthis" }, new string[] { "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            Trasferimenti TrasferimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TrasferimentiObj = GetFromDatareader(db);
                TrasferimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TrasferimentiObj.IsDirty = false;
                TrasferimentiObj.IsPersistent = true;
                TrasferimentiCollectionObj.Add(TrasferimentiObj);
            }
            db.Close();
            return TrasferimentiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TrasferimentiCollectionProvider:ITrasferimentiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TrasferimentiCollectionProvider : ITrasferimentiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Trasferimenti
        protected TrasferimentiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TrasferimentiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TrasferimentiCollection(this);
        }

        //Costruttore 2: popola la collection
        public TrasferimentiCollectionProvider(IntNT IdimpresaEqualThis, IntNT OperatoreEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdimpresaEqualThis, OperatoreEqualThis);
        }

        //Costruttore3: ha in input trasferimentiCollectionObj - non popola la collection
        public TrasferimentiCollectionProvider(TrasferimentiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TrasferimentiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TrasferimentiCollection(this);
        }

        //Get e Set
        public TrasferimentiCollection CollectionObj
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
        public int SaveCollection(TrasferimentiCollection collectionObj)
        {
            return TrasferimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Trasferimenti trasferimentiObj)
        {
            return TrasferimentiDAL.Save(_dbProviderObj, trasferimentiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TrasferimentiCollection collectionObj)
        {
            return TrasferimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Trasferimenti trasferimentiObj)
        {
            return TrasferimentiDAL.Delete(_dbProviderObj, trasferimentiObj);
        }

        //getById
        public Trasferimenti GetById(IntNT IdTrasferimentoValue)
        {
            Trasferimenti TrasferimentiTemp = TrasferimentiDAL.GetById(_dbProviderObj, IdTrasferimentoValue);
            if (TrasferimentiTemp != null) TrasferimentiTemp.Provider = this;
            return TrasferimentiTemp;
        }

        //Select: popola la collection
        public TrasferimentiCollection Select(IntNT IdtrasferimentoEqualThis, IntNT IdattoEqualThis, IntNT IdimpresaEqualThis,
DecimalNT ImportoEqualThis, StringNT CausaletrasferimentoEqualThis, IntNT OperatoreEqualThis,
DatetimeNT DatacreazioneEqualThis)
        {
            TrasferimentiCollection TrasferimentiCollectionTemp = TrasferimentiDAL.Select(_dbProviderObj, IdtrasferimentoEqualThis, IdattoEqualThis, IdimpresaEqualThis,
ImportoEqualThis, CausaletrasferimentoEqualThis, OperatoreEqualThis,
DatacreazioneEqualThis);
            TrasferimentiCollectionTemp.Provider = this;
            return TrasferimentiCollectionTemp;
        }

        //Find: popola la collection
        public TrasferimentiCollection Find(IntNT IdimpresaEqualThis, IntNT OperatoreEqualThis)
        {
            TrasferimentiCollection TrasferimentiCollectionTemp = TrasferimentiDAL.Find(_dbProviderObj, IdimpresaEqualThis, OperatoreEqualThis);
            TrasferimentiCollectionTemp.Provider = this;
            return TrasferimentiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TRASFERIMENTI>
  <ViewName>vTRASFERIMENTI</ViewName>
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
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <OPERATORE>Equal</OPERATORE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TRASFERIMENTI>
*/
