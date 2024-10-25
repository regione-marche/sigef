using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per AllegatiProtocollatiModifiche
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IAllegatiProtocollatiModificheProvider
    {
        int Save(AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj);
        int SaveCollection(AllegatiProtocollatiModificheCollection collectionObj);
        int Delete(AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj);
        int DeleteCollection(AllegatiProtocollatiModificheCollection collectionObj);
    }
    /// <summary>
    /// Summary description for AllegatiProtocollatiModifiche
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class AllegatiProtocollatiModifiche : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdModifica;
        private NullTypes.IntNT _IdAllegatoProtocollato;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.IntNT _IdIntegrazione;
        private NullTypes.IntNT _IdComunicazione;
        private NullTypes.IntNT _IdFile;
        private NullTypes.BoolNT _Protocollato;
        private NullTypes.StringNT _Protocollo;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        [NonSerialized] private IAllegatiProtocollatiModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IAllegatiProtocollatiModificheProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public AllegatiProtocollatiModifiche()
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
        /// Corrisponde al campo:ID_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdModifica
        {
            get { return _IdModifica; }
            set
            {
                if (IdModifica != value)
                {
                    _IdModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ALLEGATO_PROTOCOLLATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAllegatoProtocollato
        {
            get { return _IdAllegatoProtocollato; }
            set
            {
                if (IdAllegatoProtocollato != value)
                {
                    _IdAllegatoProtocollato = value;
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
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamento
        {
            get { return _IdDomandaPagamento; }
            set
            {
                if (IdDomandaPagamento != value)
                {
                    _IdDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VARIANTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVariante
        {
            get { return _IdVariante; }
            set
            {
                if (IdVariante != value)
                {
                    _IdVariante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_INTEGRAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIntegrazione
        {
            get { return _IdIntegrazione; }
            set
            {
                if (IdIntegrazione != value)
                {
                    _IdIntegrazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_COMUNICAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdComunicazione
        {
            get { return _IdComunicazione; }
            set
            {
                if (IdComunicazione != value)
                {
                    _IdComunicazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFile
        {
            get { return _IdFile; }
            set
            {
                if (IdFile != value)
                {
                    _IdFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROTOCOLLATO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Protocollato
        {
            get { return _Protocollato; }
            set
            {
                if (Protocollato != value)
                {
                    _Protocollato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROTOCOLLO
        /// Tipo sul db:NVARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Protocollo
        {
            get { return _Protocollo; }
            set
            {
                if (Protocollo != value)
                {
                    _Protocollo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInserimento
        {
            get { return _DataInserimento; }
            set
            {
                if (DataInserimento != value)
                {
                    _DataInserimento = value;
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
    /// Summary description for AllegatiProtocollatiModificheCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class AllegatiProtocollatiModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private AllegatiProtocollatiModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((AllegatiProtocollatiModifiche)info.GetValue(i.ToString(), typeof(AllegatiProtocollatiModifiche)));
            }
        }

        //Costruttore
        public AllegatiProtocollatiModificheCollection()
        {
            this.ItemType = typeof(AllegatiProtocollatiModifiche);
        }

        //Costruttore con provider
        public AllegatiProtocollatiModificheCollection(IAllegatiProtocollatiModificheProvider providerObj)
        {
            this.ItemType = typeof(AllegatiProtocollatiModifiche);
            this.Provider = providerObj;
        }

        //Get e Set
        public new AllegatiProtocollatiModifiche this[int index]
        {
            get { return (AllegatiProtocollatiModifiche)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new AllegatiProtocollatiModificheCollection GetChanges()
        {
            return (AllegatiProtocollatiModificheCollection)base.GetChanges();
        }

        [NonSerialized] private IAllegatiProtocollatiModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IAllegatiProtocollatiModificheProvider Provider
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
        public int Add(AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            if (AllegatiProtocollatiModificheObj.Provider == null) AllegatiProtocollatiModificheObj.Provider = this.Provider;
            return base.Add(AllegatiProtocollatiModificheObj);
        }

        //AddCollection
        public void AddCollection(AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionObj)
        {
            foreach (AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj in AllegatiProtocollatiModificheCollectionObj)
                this.Add(AllegatiProtocollatiModificheObj);
        }

        //Insert
        public void Insert(int index, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            if (AllegatiProtocollatiModificheObj.Provider == null) AllegatiProtocollatiModificheObj.Provider = this.Provider;
            base.Insert(index, AllegatiProtocollatiModificheObj);
        }

        //CollectionGetById
        public AllegatiProtocollatiModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
        public AllegatiProtocollatiModificheCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdAllegatoProtocollatoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdVarianteEqualThis,
NullTypes.IntNT IdIntegrazioneEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdFileEqualThis,
NullTypes.BoolNT ProtocollatoEqualThis, NullTypes.StringNT ProtocolloEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis)
        {
            AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionTemp = new AllegatiProtocollatiModificheCollection();
            foreach (AllegatiProtocollatiModifiche AllegatiProtocollatiModificheItem in this)
            {
                if (((IdEqualThis == null) || ((AllegatiProtocollatiModificheItem.Id != null) && (AllegatiProtocollatiModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdModifica != null) && (AllegatiProtocollatiModificheItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdAllegatoProtocollatoEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdAllegatoProtocollato != null) && (AllegatiProtocollatiModificheItem.IdAllegatoProtocollato.Value == IdAllegatoProtocollatoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdProgetto != null) && (AllegatiProtocollatiModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdDomandaPagamento != null) && (AllegatiProtocollatiModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdVariante != null) && (AllegatiProtocollatiModificheItem.IdVariante.Value == IdVarianteEqualThis.Value))) &&
((IdIntegrazioneEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdIntegrazione != null) && (AllegatiProtocollatiModificheItem.IdIntegrazione.Value == IdIntegrazioneEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdComunicazione != null) && (AllegatiProtocollatiModificheItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdFileEqualThis == null) || ((AllegatiProtocollatiModificheItem.IdFile != null) && (AllegatiProtocollatiModificheItem.IdFile.Value == IdFileEqualThis.Value))) &&
((ProtocollatoEqualThis == null) || ((AllegatiProtocollatiModificheItem.Protocollato != null) && (AllegatiProtocollatiModificheItem.Protocollato.Value == ProtocollatoEqualThis.Value))) && ((ProtocolloEqualThis == null) || ((AllegatiProtocollatiModificheItem.Protocollo != null) && (AllegatiProtocollatiModificheItem.Protocollo.Value == ProtocolloEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((AllegatiProtocollatiModificheItem.DataInserimento != null) && (AllegatiProtocollatiModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((AllegatiProtocollatiModificheItem.DataModifica != null) && (AllegatiProtocollatiModificheItem.DataModifica.Value == DataModificaEqualThis.Value))))
                {
                    AllegatiProtocollatiModificheCollectionTemp.Add(AllegatiProtocollatiModificheItem);
                }
            }
            return AllegatiProtocollatiModificheCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for AllegatiProtocollatiModificheDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class AllegatiProtocollatiModificheDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", AllegatiProtocollatiModificheObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", AllegatiProtocollatiModificheObj.IdModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAllegatoProtocollato", AllegatiProtocollatiModificheObj.IdAllegatoProtocollato);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", AllegatiProtocollatiModificheObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", AllegatiProtocollatiModificheObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", AllegatiProtocollatiModificheObj.IdVariante);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIntegrazione", AllegatiProtocollatiModificheObj.IdIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdComunicazione", AllegatiProtocollatiModificheObj.IdComunicazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFile", AllegatiProtocollatiModificheObj.IdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "Protocollato", AllegatiProtocollatiModificheObj.Protocollato);
            DbProvider.SetCmdParam(cmd, firstChar + "Protocollo", AllegatiProtocollatiModificheObj.Protocollo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", AllegatiProtocollatiModificheObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", AllegatiProtocollatiModificheObj.DataModifica);
        }
        //Insert
        private static int Insert(DbProvider db, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZAllegatiProtocollatiModificheInsert", new string[] {"IdModifica", "IdAllegatoProtocollato",
"IdProgetto", "IdDomandaPagamento", "IdVariante",
"IdIntegrazione", "IdComunicazione", "IdFile",
"Protocollato", "Protocollo", "DataInserimento",
"DataModifica"}, new string[] {"int", "int",
"int", "int", "int",
"int", "int", "int",
"bool", "string", "DateTime",
"DateTime"}, "");
                CompileIUCmd(false, insertCmd, AllegatiProtocollatiModificheObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    AllegatiProtocollatiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AllegatiProtocollatiModificheObj.IsDirty = false;
                AllegatiProtocollatiModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZAllegatiProtocollatiModificheUpdate", new string[] {"Id", "IdModifica", "IdAllegatoProtocollato",
"IdProgetto", "IdDomandaPagamento", "IdVariante",
"IdIntegrazione", "IdComunicazione", "IdFile",
"Protocollato", "Protocollo", "DataInserimento",
"DataModifica"}, new string[] {"int", "int", "int",
"int", "int", "int",
"int", "int", "int",
"bool", "string", "DateTime",
"DateTime"}, "");
                CompileIUCmd(true, updateCmd, AllegatiProtocollatiModificheObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    AllegatiProtocollatiModificheObj.DataModifica = d;
                }
                AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AllegatiProtocollatiModificheObj.IsDirty = false;
                AllegatiProtocollatiModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            switch (AllegatiProtocollatiModificheObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, AllegatiProtocollatiModificheObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, AllegatiProtocollatiModificheObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, AllegatiProtocollatiModificheObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZAllegatiProtocollatiModificheUpdate", new string[] {"Id", "IdModifica", "IdAllegatoProtocollato",
"IdProgetto", "IdDomandaPagamento", "IdVariante",
"IdIntegrazione", "IdComunicazione", "IdFile",
"Protocollato", "Protocollo", "DataInserimento",
"DataModifica"}, new string[] {"int", "int", "int",
"int", "int", "int",
"int", "int", "int",
"bool", "string", "DateTime",
"DateTime"}, "");
                IDbCommand insertCmd = db.InitCmd("ZAllegatiProtocollatiModificheInsert", new string[] {"IdModifica", "IdAllegatoProtocollato",
"IdProgetto", "IdDomandaPagamento", "IdVariante",
"IdIntegrazione", "IdComunicazione", "IdFile",
"Protocollato", "Protocollo", "DataInserimento",
"DataModifica"}, new string[] {"int", "int",
"int", "int", "int",
"int", "int", "int",
"bool", "string", "DateTime",
"DateTime"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZAllegatiProtocollatiModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < AllegatiProtocollatiModificheCollectionObj.Count; i++)
                {
                    switch (AllegatiProtocollatiModificheCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, AllegatiProtocollatiModificheCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    AllegatiProtocollatiModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, AllegatiProtocollatiModificheCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    AllegatiProtocollatiModificheCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (AllegatiProtocollatiModificheCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)AllegatiProtocollatiModificheCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < AllegatiProtocollatiModificheCollectionObj.Count; i++)
                {
                    if ((AllegatiProtocollatiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiProtocollatiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        AllegatiProtocollatiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        AllegatiProtocollatiModificheCollectionObj[i].IsDirty = false;
                        AllegatiProtocollatiModificheCollectionObj[i].IsPersistent = true;
                    }
                    if ((AllegatiProtocollatiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        AllegatiProtocollatiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        AllegatiProtocollatiModificheCollectionObj[i].IsDirty = false;
                        AllegatiProtocollatiModificheCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj)
        {
            int returnValue = 0;
            if (AllegatiProtocollatiModificheObj.IsPersistent)
            {
                returnValue = Delete(db, AllegatiProtocollatiModificheObj.Id);
            }
            AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            AllegatiProtocollatiModificheObj.IsDirty = false;
            AllegatiProtocollatiModificheObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZAllegatiProtocollatiModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZAllegatiProtocollatiModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < AllegatiProtocollatiModificheCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", AllegatiProtocollatiModificheCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < AllegatiProtocollatiModificheCollectionObj.Count; i++)
                {
                    if ((AllegatiProtocollatiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiProtocollatiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        AllegatiProtocollatiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        AllegatiProtocollatiModificheCollectionObj[i].IsDirty = false;
                        AllegatiProtocollatiModificheCollectionObj[i].IsPersistent = false;
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
        public static AllegatiProtocollatiModifiche GetById(DbProvider db, int IdValue)
        {
            AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj = null;
            IDbCommand readCmd = db.InitCmd("ZAllegatiProtocollatiModificheGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                AllegatiProtocollatiModificheObj = GetFromDatareader(db);
                AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AllegatiProtocollatiModificheObj.IsDirty = false;
                AllegatiProtocollatiModificheObj.IsPersistent = true;
            }
            db.Close();
            return AllegatiProtocollatiModificheObj;
        }

        //getFromDatareader
        public static AllegatiProtocollatiModifiche GetFromDatareader(DbProvider db)
        {
            AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj = new AllegatiProtocollatiModifiche();
            AllegatiProtocollatiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            AllegatiProtocollatiModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            AllegatiProtocollatiModificheObj.IdAllegatoProtocollato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO_PROTOCOLLATO"]);
            AllegatiProtocollatiModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            AllegatiProtocollatiModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            AllegatiProtocollatiModificheObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            AllegatiProtocollatiModificheObj.IdIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE"]);
            AllegatiProtocollatiModificheObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
            AllegatiProtocollatiModificheObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            AllegatiProtocollatiModificheObj.Protocollato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROTOCOLLATO"]);
            AllegatiProtocollatiModificheObj.Protocollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROTOCOLLO"]);
            AllegatiProtocollatiModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            AllegatiProtocollatiModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            AllegatiProtocollatiModificheObj.IsDirty = false;
            AllegatiProtocollatiModificheObj.IsPersistent = true;
            return AllegatiProtocollatiModificheObj;
        }

        //Find Select

        public static AllegatiProtocollatiModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoProtocollatoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis,
SiarLibrary.NullTypes.IntNT IdIntegrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis,
SiarLibrary.NullTypes.BoolNT ProtocollatoEqualThis, SiarLibrary.NullTypes.StringNT ProtocolloEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

        {

            AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionObj = new AllegatiProtocollatiModificheCollection();

            IDbCommand findCmd = db.InitCmd("Zallegatiprotocollatimodifichefindselect", new string[] {"Idequalthis", "IdModificaequalthis", "IdAllegatoProtocollatoequalthis",
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdVarianteequalthis",
"IdIntegrazioneequalthis", "IdComunicazioneequalthis", "IdFileequalthis",
"Protocollatoequalthis", "Protocolloequalthis", "DataInserimentoequalthis",
"DataModificaequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int",
"int", "int", "int",
"bool", "string", "DateTime",
"DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAllegatoProtocollatoequalthis", IdAllegatoProtocollatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIntegrazioneequalthis", IdIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Protocollatoequalthis", ProtocollatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Protocolloequalthis", ProtocolloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            AllegatiProtocollatiModifiche AllegatiProtocollatiModificheObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                AllegatiProtocollatiModificheObj = GetFromDatareader(db);
                AllegatiProtocollatiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                AllegatiProtocollatiModificheObj.IsDirty = false;
                AllegatiProtocollatiModificheObj.IsPersistent = true;
                AllegatiProtocollatiModificheCollectionObj.Add(AllegatiProtocollatiModificheObj);
            }
            db.Close();
            return AllegatiProtocollatiModificheCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for AllegatiProtocollatiModificheCollectionProvider:IAllegatiProtocollatiModificheProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class AllegatiProtocollatiModificheCollectionProvider : IAllegatiProtocollatiModificheProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di AllegatiProtocollatiModifiche
        protected AllegatiProtocollatiModificheCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public AllegatiProtocollatiModificheCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new AllegatiProtocollatiModificheCollection(this);
        }

        //Costruttore3: ha in input allegatiprotocollatimodificheCollectionObj - non popola la collection
        public AllegatiProtocollatiModificheCollectionProvider(AllegatiProtocollatiModificheCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public AllegatiProtocollatiModificheCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new AllegatiProtocollatiModificheCollection(this);
        }

        //Get e Set
        public AllegatiProtocollatiModificheCollection CollectionObj
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
        public int SaveCollection(AllegatiProtocollatiModificheCollection collectionObj)
        {
            return AllegatiProtocollatiModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(AllegatiProtocollatiModifiche allegatiprotocollatimodificheObj)
        {
            return AllegatiProtocollatiModificheDAL.Save(_dbProviderObj, allegatiprotocollatimodificheObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(AllegatiProtocollatiModificheCollection collectionObj)
        {
            return AllegatiProtocollatiModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(AllegatiProtocollatiModifiche allegatiprotocollatimodificheObj)
        {
            return AllegatiProtocollatiModificheDAL.Delete(_dbProviderObj, allegatiprotocollatimodificheObj);
        }

        //getById
        public AllegatiProtocollatiModifiche GetById(IntNT IdValue)
        {
            AllegatiProtocollatiModifiche AllegatiProtocollatiModificheTemp = AllegatiProtocollatiModificheDAL.GetById(_dbProviderObj, IdValue);
            if (AllegatiProtocollatiModificheTemp != null) AllegatiProtocollatiModificheTemp.Provider = this;
            return AllegatiProtocollatiModificheTemp;
        }

        //Select: popola la collection
        public AllegatiProtocollatiModificheCollection Select(IntNT IdEqualThis, IntNT IdmodificaEqualThis, IntNT IdallegatoprotocollatoEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis,
IntNT IdintegrazioneEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IdfileEqualThis,
BoolNT ProtocollatoEqualThis, StringNT ProtocolloEqualThis, DatetimeNT DatainserimentoEqualThis,
DatetimeNT DatamodificaEqualThis)
        {
            AllegatiProtocollatiModificheCollection AllegatiProtocollatiModificheCollectionTemp = AllegatiProtocollatiModificheDAL.Select(_dbProviderObj, IdEqualThis, IdmodificaEqualThis, IdallegatoprotocollatoEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis,
IdintegrazioneEqualThis, IdcomunicazioneEqualThis, IdfileEqualThis,
ProtocollatoEqualThis, ProtocolloEqualThis, DatainserimentoEqualThis,
DatamodificaEqualThis);
            AllegatiProtocollatiModificheCollectionTemp.Provider = this;
            return AllegatiProtocollatiModificheCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ALLEGATI_PROTOCOLLATI_MODIFICHE>
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
</ALLEGATI_PROTOCOLLATI_MODIFICHE>
*/
