using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ProgettoAttiAffidamento
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IProgettoAttiAffidamentoProvider
    {
        int Save(ProgettoAttiAffidamento ProgettoAttiAffidamentoObj);
        int SaveCollection(ProgettoAttiAffidamentoCollection collectionObj);
        int Delete(ProgettoAttiAffidamento ProgettoAttiAffidamentoObj);
        int DeleteCollection(ProgettoAttiAffidamentoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ProgettoAttiAffidamento
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ProgettoAttiAffidamento : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdProgettoAttiAffidamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CfFornitore;
        private NullTypes.StringNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.IntNT _OperatoreCreazione;
        private NullTypes.DatetimeNT _DataCreazione;
        private NullTypes.IntNT _OperatoreModifica;
        private NullTypes.DatetimeNT _DataModifica;
        [NonSerialized] private IProgettoAttiAffidamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoAttiAffidamentoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ProgettoAttiAffidamento()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_ATTI_AFFIDAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoAttiAffidamento
        {
            get { return _IdProgettoAttiAffidamento; }
            set
            {
                if (IdProgettoAttiAffidamento != value)
                {
                    _IdProgettoAttiAffidamento = value;
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
        /// Corrisponde al campo:CF_FORNITORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfFornitore
        {
            get { return _CfFornitore; }
            set
            {
                if (CfFornitore != value)
                {
                    _CfFornitore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:VARCHAR(250)
        /// </summary>
        public NullTypes.StringNT Numero
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
        /// Corrisponde al campo:OPERATORE_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreModifica
        {
            get { return _OperatoreModifica; }
            set
            {
                if (OperatoreModifica != value)
                {
                    _OperatoreModifica = value;
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
    /// Summary description for ProgettoAttiAffidamentoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoAttiAffidamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ProgettoAttiAffidamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ProgettoAttiAffidamento)info.GetValue(i.ToString(), typeof(ProgettoAttiAffidamento)));
            }
        }

        //Costruttore
        public ProgettoAttiAffidamentoCollection()
        {
            this.ItemType = typeof(ProgettoAttiAffidamento);
        }

        //Costruttore con provider
        public ProgettoAttiAffidamentoCollection(IProgettoAttiAffidamentoProvider providerObj)
        {
            this.ItemType = typeof(ProgettoAttiAffidamento);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ProgettoAttiAffidamento this[int index]
        {
            get { return (ProgettoAttiAffidamento)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ProgettoAttiAffidamentoCollection GetChanges()
        {
            return (ProgettoAttiAffidamentoCollection)base.GetChanges();
        }

        [NonSerialized] private IProgettoAttiAffidamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IProgettoAttiAffidamentoProvider Provider
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
        public int Add(ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            if (ProgettoAttiAffidamentoObj.Provider == null) ProgettoAttiAffidamentoObj.Provider = this.Provider;
            return base.Add(ProgettoAttiAffidamentoObj);
        }

        //AddCollection
        public void AddCollection(ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionObj)
        {
            foreach (ProgettoAttiAffidamento ProgettoAttiAffidamentoObj in ProgettoAttiAffidamentoCollectionObj)
                this.Add(ProgettoAttiAffidamentoObj);
        }

        //Insert
        public void Insert(int index, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            if (ProgettoAttiAffidamentoObj.Provider == null) ProgettoAttiAffidamentoObj.Provider = this.Provider;
            base.Insert(index, ProgettoAttiAffidamentoObj);
        }

        //CollectionGetById
        public ProgettoAttiAffidamento CollectionGetById(NullTypes.IntNT IdProgettoAttiAffidamentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdProgettoAttiAffidamento == IdProgettoAttiAffidamentoValue))
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
        public ProgettoAttiAffidamentoCollection SubSelect(NullTypes.IntNT IdProgettoAttiAffidamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CfFornitoreEqualThis,
NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreModificaEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis)
        {
            ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionTemp = new ProgettoAttiAffidamentoCollection();
            foreach (ProgettoAttiAffidamento ProgettoAttiAffidamentoItem in this)
            {
                if (((IdProgettoAttiAffidamentoEqualThis == null) || ((ProgettoAttiAffidamentoItem.IdProgettoAttiAffidamento != null) && (ProgettoAttiAffidamentoItem.IdProgettoAttiAffidamento.Value == IdProgettoAttiAffidamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoAttiAffidamentoItem.IdProgetto != null) && (ProgettoAttiAffidamentoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CfFornitoreEqualThis == null) || ((ProgettoAttiAffidamentoItem.CfFornitore != null) && (ProgettoAttiAffidamentoItem.CfFornitore.Value == CfFornitoreEqualThis.Value))) &&
((NumeroEqualThis == null) || ((ProgettoAttiAffidamentoItem.Numero != null) && (ProgettoAttiAffidamentoItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoAttiAffidamentoItem.Data != null) && (ProgettoAttiAffidamentoItem.Data.Value == DataEqualThis.Value))) && ((ImportoEqualThis == null) || ((ProgettoAttiAffidamentoItem.Importo != null) && (ProgettoAttiAffidamentoItem.Importo.Value == ImportoEqualThis.Value))) &&
((OperatoreCreazioneEqualThis == null) || ((ProgettoAttiAffidamentoItem.OperatoreCreazione != null) && (ProgettoAttiAffidamentoItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ProgettoAttiAffidamentoItem.DataCreazione != null) && (ProgettoAttiAffidamentoItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((ProgettoAttiAffidamentoItem.OperatoreModifica != null) && (ProgettoAttiAffidamentoItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((ProgettoAttiAffidamentoItem.DataModifica != null) && (ProgettoAttiAffidamentoItem.DataModifica.Value == DataModificaEqualThis.Value))))
                {
                    ProgettoAttiAffidamentoCollectionTemp.Add(ProgettoAttiAffidamentoItem);
                }
            }
            return ProgettoAttiAffidamentoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ProgettoAttiAffidamentoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ProgettoAttiAffidamentoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoAttiAffidamento", ProgettoAttiAffidamentoObj.IdProgettoAttiAffidamento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ProgettoAttiAffidamentoObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "CfFornitore", ProgettoAttiAffidamentoObj.CfFornitore);
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", ProgettoAttiAffidamentoObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", ProgettoAttiAffidamentoObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", ProgettoAttiAffidamentoObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreCreazione", ProgettoAttiAffidamentoObj.OperatoreCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", ProgettoAttiAffidamentoObj.DataCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", ProgettoAttiAffidamentoObj.OperatoreModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ProgettoAttiAffidamentoObj.DataModifica);
        }
        //Insert
        private static int Insert(DbProvider db, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZProgettoAttiAffidamentoInsert", new string[] {"IdProgetto", "CfFornitore",
"Numero", "Data", "Importo",
"OperatoreCreazione", "DataCreazione", "OperatoreModifica",
"DataModifica"}, new string[] {"int", "string",
"string", "DateTime", "decimal",
"int", "DateTime", "int",
"DateTime"}, "");
                CompileIUCmd(false, insertCmd, ProgettoAttiAffidamentoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ProgettoAttiAffidamentoObj.IdProgettoAttiAffidamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO"]);
                }
                ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoAttiAffidamentoObj.IsDirty = false;
                ProgettoAttiAffidamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoAttiAffidamentoUpdate", new string[] {"IdProgettoAttiAffidamento", "IdProgetto", "CfFornitore",
"Numero", "Data", "Importo",
"OperatoreCreazione", "DataCreazione", "OperatoreModifica",
"DataModifica"}, new string[] {"int", "int", "string",
"string", "DateTime", "decimal",
"int", "DateTime", "int",
"DateTime"}, "");
                CompileIUCmd(true, updateCmd, ProgettoAttiAffidamentoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ProgettoAttiAffidamentoObj.DataModifica = d;
                }
                ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoAttiAffidamentoObj.IsDirty = false;
                ProgettoAttiAffidamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            switch (ProgettoAttiAffidamentoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ProgettoAttiAffidamentoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ProgettoAttiAffidamentoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettoAttiAffidamentoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZProgettoAttiAffidamentoUpdate", new string[] {"IdProgettoAttiAffidamento", "IdProgetto", "CfFornitore",
"Numero", "Data", "Importo",
"OperatoreCreazione", "DataCreazione", "OperatoreModifica",
"DataModifica"}, new string[] {"int", "int", "string",
"string", "DateTime", "decimal",
"int", "DateTime", "int",
"DateTime"}, "");
                IDbCommand insertCmd = db.InitCmd("ZProgettoAttiAffidamentoInsert", new string[] {"IdProgetto", "CfFornitore",
"Numero", "Data", "Importo",
"OperatoreCreazione", "DataCreazione", "OperatoreModifica",
"DataModifica"}, new string[] {"int", "string",
"string", "DateTime", "decimal",
"int", "DateTime", "int",
"DateTime"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZProgettoAttiAffidamentoDelete", new string[] { "IdProgettoAttiAffidamento" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoAttiAffidamentoCollectionObj.Count; i++)
                {
                    switch (ProgettoAttiAffidamentoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ProgettoAttiAffidamentoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ProgettoAttiAffidamentoCollectionObj[i].IdProgettoAttiAffidamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ProgettoAttiAffidamentoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ProgettoAttiAffidamentoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ProgettoAttiAffidamentoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAttiAffidamento", (SiarLibrary.NullTypes.IntNT)ProgettoAttiAffidamentoCollectionObj[i].IdProgettoAttiAffidamento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ProgettoAttiAffidamentoCollectionObj.Count; i++)
                {
                    if ((ProgettoAttiAffidamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAttiAffidamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoAttiAffidamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ProgettoAttiAffidamentoCollectionObj[i].IsDirty = false;
                        ProgettoAttiAffidamentoCollectionObj[i].IsPersistent = true;
                    }
                    if ((ProgettoAttiAffidamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ProgettoAttiAffidamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoAttiAffidamentoCollectionObj[i].IsDirty = false;
                        ProgettoAttiAffidamentoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ProgettoAttiAffidamento ProgettoAttiAffidamentoObj)
        {
            int returnValue = 0;
            if (ProgettoAttiAffidamentoObj.IsPersistent)
            {
                returnValue = Delete(db, ProgettoAttiAffidamentoObj.IdProgettoAttiAffidamento);
            }
            ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ProgettoAttiAffidamentoObj.IsDirty = false;
            ProgettoAttiAffidamentoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdProgettoAttiAffidamentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoAttiAffidamentoDelete", new string[] { "IdProgettoAttiAffidamento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAttiAffidamento", (SiarLibrary.NullTypes.IntNT)IdProgettoAttiAffidamentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZProgettoAttiAffidamentoDelete", new string[] { "IdProgettoAttiAffidamento" }, new string[] { "int" }, "");
                for (int i = 0; i < ProgettoAttiAffidamentoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAttiAffidamento", ProgettoAttiAffidamentoCollectionObj[i].IdProgettoAttiAffidamento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ProgettoAttiAffidamentoCollectionObj.Count; i++)
                {
                    if ((ProgettoAttiAffidamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAttiAffidamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ProgettoAttiAffidamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ProgettoAttiAffidamentoCollectionObj[i].IsDirty = false;
                        ProgettoAttiAffidamentoCollectionObj[i].IsPersistent = false;
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
        public static ProgettoAttiAffidamento GetById(DbProvider db, int IdProgettoAttiAffidamentoValue)
        {
            ProgettoAttiAffidamento ProgettoAttiAffidamentoObj = null;
            IDbCommand readCmd = db.InitCmd("ZProgettoAttiAffidamentoGetById", new string[] { "IdProgettoAttiAffidamento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdProgettoAttiAffidamento", (SiarLibrary.NullTypes.IntNT)IdProgettoAttiAffidamentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ProgettoAttiAffidamentoObj = GetFromDatareader(db);
                ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoAttiAffidamentoObj.IsDirty = false;
                ProgettoAttiAffidamentoObj.IsPersistent = true;
            }
            db.Close();
            return ProgettoAttiAffidamentoObj;
        }

        //getFromDatareader
        public static ProgettoAttiAffidamento GetFromDatareader(DbProvider db)
        {
            ProgettoAttiAffidamento ProgettoAttiAffidamentoObj = new ProgettoAttiAffidamento();
            ProgettoAttiAffidamentoObj.IdProgettoAttiAffidamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ATTI_AFFIDAMENTO"]);
            ProgettoAttiAffidamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ProgettoAttiAffidamentoObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
            ProgettoAttiAffidamentoObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            ProgettoAttiAffidamentoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            ProgettoAttiAffidamentoObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            ProgettoAttiAffidamentoObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
            ProgettoAttiAffidamentoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            ProgettoAttiAffidamentoObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
            ProgettoAttiAffidamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ProgettoAttiAffidamentoObj.IsDirty = false;
            ProgettoAttiAffidamentoObj.IsPersistent = true;
            return ProgettoAttiAffidamentoObj;
        }

        //Find Select

        public static ProgettoAttiAffidamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoAttiAffidamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CfFornitoreEqualThis,
SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

        {

            ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionObj = new ProgettoAttiAffidamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zprogettoattiaffidamentofindselect", new string[] {"IdProgettoAttiAffidamentoequalthis", "IdProgettoequalthis", "CfFornitoreequalthis",
"Numeroequalthis", "Dataequalthis", "Importoequalthis",
"OperatoreCreazioneequalthis", "DataCreazioneequalthis", "OperatoreModificaequalthis",
"DataModificaequalthis"}, new string[] {"int", "int", "string",
"string", "DateTime", "decimal",
"int", "DateTime", "int",
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoAttiAffidamentoequalthis", IdProgettoAttiAffidamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfFornitoreequalthis", CfFornitoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            ProgettoAttiAffidamento ProgettoAttiAffidamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ProgettoAttiAffidamentoObj = GetFromDatareader(db);
                ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoAttiAffidamentoObj.IsDirty = false;
                ProgettoAttiAffidamentoObj.IsPersistent = true;
                ProgettoAttiAffidamentoCollectionObj.Add(ProgettoAttiAffidamentoObj);
            }
            db.Close();
            return ProgettoAttiAffidamentoCollectionObj;
        }

        //Find Find

        public static ProgettoAttiAffidamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CfFornitoreEqualThis)

        {

            ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionObj = new ProgettoAttiAffidamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zprogettoattiaffidamentofindfind", new string[] { "IdProgettoequalthis", "CfFornitoreequalthis" }, new string[] { "int", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfFornitoreequalthis", CfFornitoreEqualThis);
            ProgettoAttiAffidamento ProgettoAttiAffidamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ProgettoAttiAffidamentoObj = GetFromDatareader(db);
                ProgettoAttiAffidamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ProgettoAttiAffidamentoObj.IsDirty = false;
                ProgettoAttiAffidamentoObj.IsPersistent = true;
                ProgettoAttiAffidamentoCollectionObj.Add(ProgettoAttiAffidamentoObj);
            }
            db.Close();
            return ProgettoAttiAffidamentoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ProgettoAttiAffidamentoCollectionProvider:IProgettoAttiAffidamentoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ProgettoAttiAffidamentoCollectionProvider : IProgettoAttiAffidamentoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ProgettoAttiAffidamento
        protected ProgettoAttiAffidamentoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ProgettoAttiAffidamentoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ProgettoAttiAffidamentoCollection(this);
        }

        //Costruttore 2: popola la collection
        public ProgettoAttiAffidamentoCollectionProvider(IntNT IdprogettoEqualThis, StringNT CffornitoreEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis, CffornitoreEqualThis);
        }

        //Costruttore3: ha in input progettoattiaffidamentoCollectionObj - non popola la collection
        public ProgettoAttiAffidamentoCollectionProvider(ProgettoAttiAffidamentoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ProgettoAttiAffidamentoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ProgettoAttiAffidamentoCollection(this);
        }

        //Get e Set
        public ProgettoAttiAffidamentoCollection CollectionObj
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
        public int SaveCollection(ProgettoAttiAffidamentoCollection collectionObj)
        {
            return ProgettoAttiAffidamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ProgettoAttiAffidamento progettoattiaffidamentoObj)
        {
            return ProgettoAttiAffidamentoDAL.Save(_dbProviderObj, progettoattiaffidamentoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ProgettoAttiAffidamentoCollection collectionObj)
        {
            return ProgettoAttiAffidamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ProgettoAttiAffidamento progettoattiaffidamentoObj)
        {
            return ProgettoAttiAffidamentoDAL.Delete(_dbProviderObj, progettoattiaffidamentoObj);
        }

        //getById
        public ProgettoAttiAffidamento GetById(IntNT IdProgettoAttiAffidamentoValue)
        {
            ProgettoAttiAffidamento ProgettoAttiAffidamentoTemp = ProgettoAttiAffidamentoDAL.GetById(_dbProviderObj, IdProgettoAttiAffidamentoValue);
            if (ProgettoAttiAffidamentoTemp != null) ProgettoAttiAffidamentoTemp.Provider = this;
            return ProgettoAttiAffidamentoTemp;
        }

        //Select: popola la collection
        public ProgettoAttiAffidamentoCollection Select(IntNT IdprogettoattiaffidamentoEqualThis, IntNT IdprogettoEqualThis, StringNT CffornitoreEqualThis,
StringNT NumeroEqualThis, DatetimeNT DataEqualThis, DecimalNT ImportoEqualThis,
IntNT OperatorecreazioneEqualThis, DatetimeNT DatacreazioneEqualThis, IntNT OperatoremodificaEqualThis,
DatetimeNT DatamodificaEqualThis)
        {
            ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionTemp = ProgettoAttiAffidamentoDAL.Select(_dbProviderObj, IdprogettoattiaffidamentoEqualThis, IdprogettoEqualThis, CffornitoreEqualThis,
NumeroEqualThis, DataEqualThis, ImportoEqualThis,
OperatorecreazioneEqualThis, DatacreazioneEqualThis, OperatoremodificaEqualThis,
DatamodificaEqualThis);
            ProgettoAttiAffidamentoCollectionTemp.Provider = this;
            return ProgettoAttiAffidamentoCollectionTemp;
        }

        //Find: popola la collection
        public ProgettoAttiAffidamentoCollection Find(IntNT IdprogettoEqualThis, StringNT CffornitoreEqualThis)
        {
            ProgettoAttiAffidamentoCollection ProgettoAttiAffidamentoCollectionTemp = ProgettoAttiAffidamentoDAL.Find(_dbProviderObj, IdprogettoEqualThis, CffornitoreEqualThis);
            ProgettoAttiAffidamentoCollectionTemp.Provider = this;
            return ProgettoAttiAffidamentoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_ATTI_AFFIDAMENTO>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <CF_FORNITORE>Equal</CF_FORNITORE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_ATTI_AFFIDAMENTO>
*/
