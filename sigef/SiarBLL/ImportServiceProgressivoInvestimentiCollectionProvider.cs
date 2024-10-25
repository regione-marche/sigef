using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ImportServiceProgressivoInvestimenti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IImportServiceProgressivoInvestimentiProvider
    {
        int Save(ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj);
        int SaveCollection(ImportServiceProgressivoInvestimentiCollection collectionObj);
        int Delete(ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj);
        int DeleteCollection(ImportServiceProgressivoInvestimentiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ImportServiceProgressivoInvestimenti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ImportServiceProgressivoInvestimenti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdProgressivoInvestimento;
        private NullTypes.IntNT _Progressivo;
        private NullTypes.IntNT _IdInvestimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataAggiornamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Codice;
        [NonSerialized] private IImportServiceProgressivoInvestimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImportServiceProgressivoInvestimentiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ImportServiceProgressivoInvestimenti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_PROGRESSIVO_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgressivoInvestimento
        {
            get { return _IdProgressivoInvestimento; }
            set
            {
                if (IdProgressivoInvestimento != value)
                {
                    _IdProgressivoInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROGRESSIVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Progressivo
        {
            get { return _Progressivo; }
            set
            {
                if (Progressivo != value)
                {
                    _Progressivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdInvestimento
        {
            get { return _IdInvestimento; }
            set
            {
                if (IdInvestimento != value)
                {
                    _IdInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
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
        /// Corrisponde al campo:DATA_AGGIORNAMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
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
        /// Corrisponde al campo:CODICE
        /// Tipo sul db:VARCHAR(20)
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
    /// Summary description for ImportServiceProgressivoInvestimentiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImportServiceProgressivoInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ImportServiceProgressivoInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ImportServiceProgressivoInvestimenti)info.GetValue(i.ToString(), typeof(ImportServiceProgressivoInvestimenti)));
            }
        }

        //Costruttore
        public ImportServiceProgressivoInvestimentiCollection()
        {
            this.ItemType = typeof(ImportServiceProgressivoInvestimenti);
        }

        //Costruttore con provider
        public ImportServiceProgressivoInvestimentiCollection(IImportServiceProgressivoInvestimentiProvider providerObj)
        {
            this.ItemType = typeof(ImportServiceProgressivoInvestimenti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ImportServiceProgressivoInvestimenti this[int index]
        {
            get { return (ImportServiceProgressivoInvestimenti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ImportServiceProgressivoInvestimentiCollection GetChanges()
        {
            return (ImportServiceProgressivoInvestimentiCollection)base.GetChanges();
        }

        [NonSerialized] private IImportServiceProgressivoInvestimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImportServiceProgressivoInvestimentiProvider Provider
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
        public int Add(ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            if (ImportServiceProgressivoInvestimentiObj.Provider == null) ImportServiceProgressivoInvestimentiObj.Provider = this.Provider;
            return base.Add(ImportServiceProgressivoInvestimentiObj);
        }

        //AddCollection
        public void AddCollection(ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionObj)
        {
            foreach (ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj in ImportServiceProgressivoInvestimentiCollectionObj)
                this.Add(ImportServiceProgressivoInvestimentiObj);
        }

        //Insert
        public void Insert(int index, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            if (ImportServiceProgressivoInvestimentiObj.Provider == null) ImportServiceProgressivoInvestimentiObj.Provider = this.Provider;
            base.Insert(index, ImportServiceProgressivoInvestimentiObj);
        }

        //CollectionGetById
        public ImportServiceProgressivoInvestimenti CollectionGetById(NullTypes.IntNT IdProgressivoInvestimentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdProgressivoInvestimento == IdProgressivoInvestimentoValue))
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
        public ImportServiceProgressivoInvestimentiCollection SubSelect(NullTypes.IntNT IdProgressivoInvestimentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT ProgressivoEqualThis,
NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis)
        {
            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionTemp = new ImportServiceProgressivoInvestimentiCollection();
            foreach (ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiItem in this)
            {
                if (((IdProgressivoInvestimentoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.IdProgressivoInvestimento != null) && (ImportServiceProgressivoInvestimentiItem.IdProgressivoInvestimento.Value == IdProgressivoInvestimentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.IdProgetto != null) && (ImportServiceProgressivoInvestimentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((ProgressivoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.Progressivo != null) && (ImportServiceProgressivoInvestimentiItem.Progressivo.Value == ProgressivoEqualThis.Value))) &&
((IdInvestimentoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.IdInvestimento != null) && (ImportServiceProgressivoInvestimentiItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.DataInserimento != null) && (ImportServiceProgressivoInvestimentiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.DataAggiornamento != null) && (ImportServiceProgressivoInvestimentiItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))))
                {
                    ImportServiceProgressivoInvestimentiCollectionTemp.Add(ImportServiceProgressivoInvestimentiItem);
                }
            }
            return ImportServiceProgressivoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public ImportServiceProgressivoInvestimentiCollection Filter(NullTypes.IntNT ProgressivoEqualThis)
        {
            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionTemp = new ImportServiceProgressivoInvestimentiCollection();
            foreach (ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiItem in this)
            {
                if (((ProgressivoEqualThis == null) || ((ImportServiceProgressivoInvestimentiItem.Progressivo != null) && (ImportServiceProgressivoInvestimentiItem.Progressivo.Value == ProgressivoEqualThis.Value))))
                {
                    ImportServiceProgressivoInvestimentiCollectionTemp.Add(ImportServiceProgressivoInvestimentiItem);
                }
            }
            return ImportServiceProgressivoInvestimentiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ImportServiceProgressivoInvestimentiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ImportServiceProgressivoInvestimentiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdProgressivoInvestimento", ImportServiceProgressivoInvestimentiObj.IdProgressivoInvestimento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Progressivo", ImportServiceProgressivoInvestimentiObj.Progressivo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdInvestimento", ImportServiceProgressivoInvestimentiObj.IdInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ImportServiceProgressivoInvestimentiObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAggiornamento", ImportServiceProgressivoInvestimentiObj.DataAggiornamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ImportServiceProgressivoInvestimentiObj.IdProgetto);
        }
        //Insert
        private static int Insert(DbProvider db, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiInsert", new string[] {"Progressivo", "IdInvestimento",
"DataInserimento", "DataAggiornamento", "IdProgetto", }, new string[] {"int", "int",
"DateTime", "DateTime", "int", }, "");
                CompileIUCmd(false, insertCmd, ImportServiceProgressivoInvestimentiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ImportServiceProgressivoInvestimentiObj.IdProgressivoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRESSIVO_INVESTIMENTO"]);
                    ImportServiceProgressivoInvestimentiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    ImportServiceProgressivoInvestimentiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
                }
                ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImportServiceProgressivoInvestimentiObj.IsDirty = false;
                ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiUpdate", new string[] {"IdProgressivoInvestimento", "Progressivo", "IdInvestimento",
"DataInserimento", "DataAggiornamento", "IdProgetto", }, new string[] {"int", "int", "int",
"DateTime", "DateTime", "int", }, "");
                CompileIUCmd(true, updateCmd, ImportServiceProgressivoInvestimentiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImportServiceProgressivoInvestimentiObj.IsDirty = false;
                ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            switch (ImportServiceProgressivoInvestimentiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ImportServiceProgressivoInvestimentiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ImportServiceProgressivoInvestimentiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ImportServiceProgressivoInvestimentiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiUpdate", new string[] {"IdProgressivoInvestimento", "Progressivo", "IdInvestimento",
"DataInserimento", "DataAggiornamento", "IdProgetto", }, new string[] {"int", "int", "int",
"DateTime", "DateTime", "int", }, "");
                IDbCommand insertCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiInsert", new string[] {"Progressivo", "IdInvestimento",
"DataInserimento", "DataAggiornamento", "IdProgetto", }, new string[] {"int", "int",
"DateTime", "DateTime", "int", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiDelete", new string[] { "IdProgressivoInvestimento" }, new string[] { "int" }, "");
                for (int i = 0; i < ImportServiceProgressivoInvestimentiCollectionObj.Count; i++)
                {
                    switch (ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ImportServiceProgressivoInvestimentiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ImportServiceProgressivoInvestimentiCollectionObj[i].IdProgressivoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRESSIVO_INVESTIMENTO"]);
                                    ImportServiceProgressivoInvestimentiCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    ImportServiceProgressivoInvestimentiCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ImportServiceProgressivoInvestimentiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ImportServiceProgressivoInvestimentiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgressivoInvestimento", (SiarLibrary.NullTypes.IntNT)ImportServiceProgressivoInvestimentiCollectionObj[i].IdProgressivoInvestimento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ImportServiceProgressivoInvestimentiCollectionObj.Count; i++)
                {
                    if ((ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsDirty = false;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsPersistent = true;
                    }
                    if ((ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsDirty = false;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj)
        {
            int returnValue = 0;
            if (ImportServiceProgressivoInvestimentiObj.IsPersistent)
            {
                returnValue = Delete(db, ImportServiceProgressivoInvestimentiObj.IdProgressivoInvestimento);
            }
            ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ImportServiceProgressivoInvestimentiObj.IsDirty = false;
            ImportServiceProgressivoInvestimentiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdProgressivoInvestimentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiDelete", new string[] { "IdProgressivoInvestimento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgressivoInvestimento", (SiarLibrary.NullTypes.IntNT)IdProgressivoInvestimentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiDelete", new string[] { "IdProgressivoInvestimento" }, new string[] { "int" }, "");
                for (int i = 0; i < ImportServiceProgressivoInvestimentiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgressivoInvestimento", ImportServiceProgressivoInvestimentiCollectionObj[i].IdProgressivoInvestimento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ImportServiceProgressivoInvestimentiCollectionObj.Count; i++)
                {
                    if ((ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImportServiceProgressivoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsDirty = false;
                        ImportServiceProgressivoInvestimentiCollectionObj[i].IsPersistent = false;
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
        public static ImportServiceProgressivoInvestimenti GetById(DbProvider db, int IdProgressivoInvestimentoValue)
        {
            ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj = null;
            IDbCommand readCmd = db.InitCmd("ZImportServiceProgressivoInvestimentiGetById", new string[] { "IdProgressivoInvestimento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdProgressivoInvestimento", (SiarLibrary.NullTypes.IntNT)IdProgressivoInvestimentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ImportServiceProgressivoInvestimentiObj = GetFromDatareader(db);
                ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImportServiceProgressivoInvestimentiObj.IsDirty = false;
                ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
            }
            db.Close();
            return ImportServiceProgressivoInvestimentiObj;
        }

        //getFromDatareader
        public static ImportServiceProgressivoInvestimenti GetFromDatareader(DbProvider db)
        {
            ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj = new ImportServiceProgressivoInvestimenti();
            ImportServiceProgressivoInvestimentiObj.IdProgressivoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRESSIVO_INVESTIMENTO"]);
            ImportServiceProgressivoInvestimentiObj.Progressivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGRESSIVO"]);
            ImportServiceProgressivoInvestimentiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
            ImportServiceProgressivoInvestimentiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ImportServiceProgressivoInvestimentiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
            ImportServiceProgressivoInvestimentiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ImportServiceProgressivoInvestimentiObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
            ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ImportServiceProgressivoInvestimentiObj.IsDirty = false;
            ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
            return ImportServiceProgressivoInvestimentiObj;
        }

        //Find Select

        public static ImportServiceProgressivoInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgressivoInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT ProgressivoEqualThis,
SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis)

        {

            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionObj = new ImportServiceProgressivoInvestimentiCollection();

            IDbCommand findCmd = db.InitCmd("Zimportserviceprogressivoinvestimentifindselect", new string[] {"IdProgressivoInvestimentoequalthis", "IdProgettoequalthis", "Progressivoequalthis",
"IdInvestimentoequalthis", "DataInserimentoequalthis", "DataAggiornamentoequalthis"}, new string[] {"int", "int", "int",
"int", "DateTime", "DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgressivoInvestimentoequalthis", IdProgressivoInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
            ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImportServiceProgressivoInvestimentiObj = GetFromDatareader(db);
                ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImportServiceProgressivoInvestimentiObj.IsDirty = false;
                ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
                ImportServiceProgressivoInvestimentiCollectionObj.Add(ImportServiceProgressivoInvestimentiObj);
            }
            db.Close();
            return ImportServiceProgressivoInvestimentiCollectionObj;
        }

        //Find Find

        public static ImportServiceProgressivoInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT ProgressivoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodiceEqualThis)

        {

            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionObj = new ImportServiceProgressivoInvestimentiCollection();

            IDbCommand findCmd = db.InitCmd("Zimportserviceprogressivoinvestimentifindfind", new string[] {"Progressivoequalthis", "IdInvestimentoequalthis", "IdProgettoequalthis",
"Codiceequalthis"}, new string[] {"int", "int", "int",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
            ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImportServiceProgressivoInvestimentiObj = GetFromDatareader(db);
                ImportServiceProgressivoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImportServiceProgressivoInvestimentiObj.IsDirty = false;
                ImportServiceProgressivoInvestimentiObj.IsPersistent = true;
                ImportServiceProgressivoInvestimentiCollectionObj.Add(ImportServiceProgressivoInvestimentiObj);
            }
            db.Close();
            return ImportServiceProgressivoInvestimentiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ImportServiceProgressivoInvestimentiCollectionProvider:IImportServiceProgressivoInvestimentiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImportServiceProgressivoInvestimentiCollectionProvider : IImportServiceProgressivoInvestimentiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ImportServiceProgressivoInvestimenti
        protected ImportServiceProgressivoInvestimentiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ImportServiceProgressivoInvestimentiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ImportServiceProgressivoInvestimentiCollection(this);
        }

        //Costruttore 2: popola la collection
        public ImportServiceProgressivoInvestimentiCollectionProvider(IntNT ProgressivoEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodiceEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(ProgressivoEqualThis, IdinvestimentoEqualThis, IdprogettoEqualThis,
CodiceEqualThis);
        }

        //Costruttore3: ha in input importserviceprogressivoinvestimentiCollectionObj - non popola la collection
        public ImportServiceProgressivoInvestimentiCollectionProvider(ImportServiceProgressivoInvestimentiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ImportServiceProgressivoInvestimentiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ImportServiceProgressivoInvestimentiCollection(this);
        }

        //Get e Set
        public ImportServiceProgressivoInvestimentiCollection CollectionObj
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
        public int SaveCollection(ImportServiceProgressivoInvestimentiCollection collectionObj)
        {
            return ImportServiceProgressivoInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ImportServiceProgressivoInvestimenti importserviceprogressivoinvestimentiObj)
        {
            return ImportServiceProgressivoInvestimentiDAL.Save(_dbProviderObj, importserviceprogressivoinvestimentiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ImportServiceProgressivoInvestimentiCollection collectionObj)
        {
            return ImportServiceProgressivoInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ImportServiceProgressivoInvestimenti importserviceprogressivoinvestimentiObj)
        {
            return ImportServiceProgressivoInvestimentiDAL.Delete(_dbProviderObj, importserviceprogressivoinvestimentiObj);
        }

        //getById
        public ImportServiceProgressivoInvestimenti GetById(IntNT IdProgressivoInvestimentoValue)
        {
            ImportServiceProgressivoInvestimenti ImportServiceProgressivoInvestimentiTemp = ImportServiceProgressivoInvestimentiDAL.GetById(_dbProviderObj, IdProgressivoInvestimentoValue);
            if (ImportServiceProgressivoInvestimentiTemp != null) ImportServiceProgressivoInvestimentiTemp.Provider = this;
            return ImportServiceProgressivoInvestimentiTemp;
        }

        //Select: popola la collection
        public ImportServiceProgressivoInvestimentiCollection Select(IntNT IdprogressivoinvestimentoEqualThis, IntNT IdprogettoEqualThis, IntNT ProgressivoEqualThis,
IntNT IdinvestimentoEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis)
        {
            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionTemp = ImportServiceProgressivoInvestimentiDAL.Select(_dbProviderObj, IdprogressivoinvestimentoEqualThis, IdprogettoEqualThis, ProgressivoEqualThis,
IdinvestimentoEqualThis, DatainserimentoEqualThis, DataaggiornamentoEqualThis);
            ImportServiceProgressivoInvestimentiCollectionTemp.Provider = this;
            return ImportServiceProgressivoInvestimentiCollectionTemp;
        }

        //Find: popola la collection
        public ImportServiceProgressivoInvestimentiCollection Find(IntNT ProgressivoEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodiceEqualThis)
        {
            ImportServiceProgressivoInvestimentiCollection ImportServiceProgressivoInvestimentiCollectionTemp = ImportServiceProgressivoInvestimentiDAL.Find(_dbProviderObj, ProgressivoEqualThis, IdinvestimentoEqualThis, IdprogettoEqualThis,
CodiceEqualThis);
            ImportServiceProgressivoInvestimentiCollectionTemp.Provider = this;
            return ImportServiceProgressivoInvestimentiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPORT_SERVICE_PROGRESSIVO_INVESTIMENTI>
  <ViewName>vIMPORT_SERVICE_PROGRESSIVO_INVESTIMENTI</ViewName>
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
      <PROGRESSIVO>Equal</PROGRESSIVO>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <PROGRESSIVO>Equal</PROGRESSIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</IMPORT_SERVICE_PROGRESSIVO_INVESTIMENTI>
*/
