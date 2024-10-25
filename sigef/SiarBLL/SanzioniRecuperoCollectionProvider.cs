using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per SanzioniRecupero
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ISanzioniRecuperoProvider
    {
        int Save(SanzioniRecupero SanzioniRecuperoObj);
        int SaveCollection(SanzioniRecuperoCollection collectionObj);
        int Delete(SanzioniRecupero SanzioniRecuperoObj);
        int DeleteCollection(SanzioniRecuperoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for SanzioniRecupero
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class SanzioniRecupero : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdSanzioneRecupero;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.IntNT _IdRegistroRecupero;
        private NullTypes.IntNT _IdCategoriaSanzione;
        private NullTypes.IntNT _IdTipoSanzione;
        private NullTypes.DecimalNT _ImportoSanzione;
        private NullTypes.DatetimeNT _DataConclusione;
        private NullTypes.IntNT _IdStatoSanzione;
        private NullTypes.IntNT _IdRegistroIrregolarita;
        [NonSerialized]
        private ISanzioniRecuperoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISanzioniRecuperoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public SanzioniRecupero()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_SANZIONE_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSanzioneRecupero
        {
            get { return _IdSanzioneRecupero; }
            set
            {
                if (IdSanzioneRecupero != value)
                {
                    _IdSanzioneRecupero = value;
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
        /// Corrisponde al campo:CF_INSERIMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfInserimento
        {
            get { return _CfInserimento; }
            set
            {
                if (CfInserimento != value)
                {
                    _CfInserimento = value;
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

        /// <summary>
        /// Corrisponde al campo:CF_MODIFICA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfModifica
        {
            get { return _CfModifica; }
            set
            {
                if (CfModifica != value)
                {
                    _CfModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_REGISTRO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRegistroRecupero
        {
            get { return _IdRegistroRecupero; }
            set
            {
                if (IdRegistroRecupero != value)
                {
                    _IdRegistroRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CATEGORIA_SANZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdCategoriaSanzione
        {
            get { return _IdCategoriaSanzione; }
            set
            {
                if (IdCategoriaSanzione != value)
                {
                    _IdCategoriaSanzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_SANZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoSanzione
        {
            get { return _IdTipoSanzione; }
            set
            {
                if (IdTipoSanzione != value)
                {
                    _IdTipoSanzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SANZIONE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSanzione
        {
            get { return _ImportoSanzione; }
            set
            {
                if (ImportoSanzione != value)
                {
                    _ImportoSanzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CONCLUSIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataConclusione
        {
            get { return _DataConclusione; }
            set
            {
                if (DataConclusione != value)
                {
                    _DataConclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STATO_SANZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStatoSanzione
        {
            get { return _IdStatoSanzione; }
            set
            {
                if (IdStatoSanzione != value)
                {
                    _IdStatoSanzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_REGISTRO_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRegistroIrregolarita
        {
            get { return _IdRegistroIrregolarita; }
            set
            {
                if (IdRegistroIrregolarita != value)
                {
                    _IdRegistroIrregolarita = value;
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
    /// Summary description for SanzioniRecuperoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SanzioniRecuperoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private SanzioniRecuperoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((SanzioniRecupero)info.GetValue(i.ToString(), typeof(SanzioniRecupero)));
            }
        }

        //Costruttore
        public SanzioniRecuperoCollection()
        {
            this.ItemType = typeof(SanzioniRecupero);
        }

        //Costruttore con provider
        public SanzioniRecuperoCollection(ISanzioniRecuperoProvider providerObj)
        {
            this.ItemType = typeof(SanzioniRecupero);
            this.Provider = providerObj;
        }

        //Get e Set
        public new SanzioniRecupero this[int index]
        {
            get { return (SanzioniRecupero)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new SanzioniRecuperoCollection GetChanges()
        {
            return (SanzioniRecuperoCollection)base.GetChanges();
        }

        [NonSerialized]
        private ISanzioniRecuperoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISanzioniRecuperoProvider Provider
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
        public int Add(SanzioniRecupero SanzioniRecuperoObj)
        {
            if (SanzioniRecuperoObj.Provider == null) SanzioniRecuperoObj.Provider = this.Provider;
            return base.Add(SanzioniRecuperoObj);
        }

        //AddCollection
        public void AddCollection(SanzioniRecuperoCollection SanzioniRecuperoCollectionObj)
        {
            foreach (SanzioniRecupero SanzioniRecuperoObj in SanzioniRecuperoCollectionObj)
                this.Add(SanzioniRecuperoObj);
        }

        //Insert
        public void Insert(int index, SanzioniRecupero SanzioniRecuperoObj)
        {
            if (SanzioniRecuperoObj.Provider == null) SanzioniRecuperoObj.Provider = this.Provider;
            base.Insert(index, SanzioniRecuperoObj);
        }

        //CollectionGetById
        public SanzioniRecupero CollectionGetById(NullTypes.IntNT IdSanzioneRecuperoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdSanzioneRecupero == IdSanzioneRecuperoValue))
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
        public SanzioniRecuperoCollection SubSelect(NullTypes.IntNT IdSanzioneRecuperoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdRegistroRecuperoEqualThis,
NullTypes.IntNT IdCategoriaSanzioneEqualThis, NullTypes.IntNT IdTipoSanzioneEqualThis, NullTypes.DecimalNT ImportoSanzioneEqualThis,
NullTypes.DatetimeNT DataConclusioneEqualThis, NullTypes.IntNT IdStatoSanzioneEqualThis)
        {
            SanzioniRecuperoCollection SanzioniRecuperoCollectionTemp = new SanzioniRecuperoCollection();
            foreach (SanzioniRecupero SanzioniRecuperoItem in this)
            {
                if (((IdSanzioneRecuperoEqualThis == null) || ((SanzioniRecuperoItem.IdSanzioneRecupero != null) && (SanzioniRecuperoItem.IdSanzioneRecupero.Value == IdSanzioneRecuperoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((SanzioniRecuperoItem.DataInserimento != null) && (SanzioniRecuperoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((SanzioniRecuperoItem.CfInserimento != null) && (SanzioniRecuperoItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((SanzioniRecuperoItem.DataModifica != null) && (SanzioniRecuperoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((SanzioniRecuperoItem.CfModifica != null) && (SanzioniRecuperoItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdRegistroRecuperoEqualThis == null) || ((SanzioniRecuperoItem.IdRegistroRecupero != null) && (SanzioniRecuperoItem.IdRegistroRecupero.Value == IdRegistroRecuperoEqualThis.Value))) &&
((IdCategoriaSanzioneEqualThis == null) || ((SanzioniRecuperoItem.IdCategoriaSanzione != null) && (SanzioniRecuperoItem.IdCategoriaSanzione.Value == IdCategoriaSanzioneEqualThis.Value))) && ((IdTipoSanzioneEqualThis == null) || ((SanzioniRecuperoItem.IdTipoSanzione != null) && (SanzioniRecuperoItem.IdTipoSanzione.Value == IdTipoSanzioneEqualThis.Value))) && ((ImportoSanzioneEqualThis == null) || ((SanzioniRecuperoItem.ImportoSanzione != null) && (SanzioniRecuperoItem.ImportoSanzione.Value == ImportoSanzioneEqualThis.Value))) &&
((DataConclusioneEqualThis == null) || ((SanzioniRecuperoItem.DataConclusione != null) && (SanzioniRecuperoItem.DataConclusione.Value == DataConclusioneEqualThis.Value))) && ((IdStatoSanzioneEqualThis == null) || ((SanzioniRecuperoItem.IdStatoSanzione != null) && (SanzioniRecuperoItem.IdStatoSanzione.Value == IdStatoSanzioneEqualThis.Value))))
                {
                    SanzioniRecuperoCollectionTemp.Add(SanzioniRecuperoItem);
                }
            }
            return SanzioniRecuperoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for SanzioniRecuperoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class SanzioniRecuperoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SanzioniRecupero SanzioniRecuperoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdSanzioneRecupero", SanzioniRecuperoObj.IdSanzioneRecupero);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", SanzioniRecuperoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", SanzioniRecuperoObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", SanzioniRecuperoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", SanzioniRecuperoObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRegistroRecupero", SanzioniRecuperoObj.IdRegistroRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCategoriaSanzione", SanzioniRecuperoObj.IdCategoriaSanzione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoSanzione", SanzioniRecuperoObj.IdTipoSanzione);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSanzione", SanzioniRecuperoObj.ImportoSanzione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataConclusione", SanzioniRecuperoObj.DataConclusione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStatoSanzione", SanzioniRecuperoObj.IdStatoSanzione);
        }
        //Insert
        private static int Insert(DbProvider db, SanzioniRecupero SanzioniRecuperoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZSanzioniRecuperoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdRegistroRecupero", 
"IdCategoriaSanzione", "IdTipoSanzione", "ImportoSanzione", 
"DataConclusione", "IdStatoSanzione"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"int", "int", "decimal", 
"DateTime", "int"}, "");
                CompileIUCmd(false, insertCmd, SanzioniRecuperoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    SanzioniRecuperoObj.IdSanzioneRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE_RECUPERO"]);
                }
                SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SanzioniRecuperoObj.IsDirty = false;
                SanzioniRecuperoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, SanzioniRecupero SanzioniRecuperoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSanzioniRecuperoUpdate", new string[] {"IdSanzioneRecupero", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdRegistroRecupero", 
"IdCategoriaSanzione", "IdTipoSanzione", "ImportoSanzione", 
"DataConclusione", "IdStatoSanzione"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"int", "int", "decimal", 
"DateTime", "int"}, "");
                CompileIUCmd(true, updateCmd, SanzioniRecuperoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    SanzioniRecuperoObj.DataModifica = d;
                }
                SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SanzioniRecuperoObj.IsDirty = false;
                SanzioniRecuperoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, SanzioniRecupero SanzioniRecuperoObj)
        {
            switch (SanzioniRecuperoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, SanzioniRecuperoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, SanzioniRecuperoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, SanzioniRecuperoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, SanzioniRecuperoCollection SanzioniRecuperoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSanzioniRecuperoUpdate", new string[] {"IdSanzioneRecupero", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdRegistroRecupero", 
"IdCategoriaSanzione", "IdTipoSanzione", "ImportoSanzione", 
"DataConclusione", "IdStatoSanzione"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"int", "int", "decimal", 
"DateTime", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZSanzioniRecuperoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdRegistroRecupero", 
"IdCategoriaSanzione", "IdTipoSanzione", "ImportoSanzione", 
"DataConclusione", "IdStatoSanzione"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"int", "int", "decimal", 
"DateTime", "int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZSanzioniRecuperoDelete", new string[] { "IdSanzioneRecupero" }, new string[] { "int" }, "");
                for (int i = 0; i < SanzioniRecuperoCollectionObj.Count; i++)
                {
                    switch (SanzioniRecuperoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, SanzioniRecuperoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    SanzioniRecuperoCollectionObj[i].IdSanzioneRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE_RECUPERO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, SanzioniRecuperoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    SanzioniRecuperoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (SanzioniRecuperoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSanzioneRecupero", (SiarLibrary.NullTypes.IntNT)SanzioniRecuperoCollectionObj[i].IdSanzioneRecupero);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < SanzioniRecuperoCollectionObj.Count; i++)
                {
                    if ((SanzioniRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SanzioniRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SanzioniRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        SanzioniRecuperoCollectionObj[i].IsDirty = false;
                        SanzioniRecuperoCollectionObj[i].IsPersistent = true;
                    }
                    if ((SanzioniRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        SanzioniRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SanzioniRecuperoCollectionObj[i].IsDirty = false;
                        SanzioniRecuperoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, SanzioniRecupero SanzioniRecuperoObj)
        {
            int returnValue = 0;
            if (SanzioniRecuperoObj.IsPersistent)
            {
                returnValue = Delete(db, SanzioniRecuperoObj.IdSanzioneRecupero);
            }
            SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            SanzioniRecuperoObj.IsDirty = false;
            SanzioniRecuperoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdSanzioneRecuperoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSanzioniRecuperoDelete", new string[] { "IdSanzioneRecupero" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSanzioneRecupero", (SiarLibrary.NullTypes.IntNT)IdSanzioneRecuperoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, SanzioniRecuperoCollection SanzioniRecuperoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSanzioniRecuperoDelete", new string[] { "IdSanzioneRecupero" }, new string[] { "int" }, "");
                for (int i = 0; i < SanzioniRecuperoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSanzioneRecupero", SanzioniRecuperoCollectionObj[i].IdSanzioneRecupero);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < SanzioniRecuperoCollectionObj.Count; i++)
                {
                    if ((SanzioniRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SanzioniRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SanzioniRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SanzioniRecuperoCollectionObj[i].IsDirty = false;
                        SanzioniRecuperoCollectionObj[i].IsPersistent = false;
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
        public static SanzioniRecupero GetById(DbProvider db, int IdSanzioneRecuperoValue)
        {
            SanzioniRecupero SanzioniRecuperoObj = null;
            IDbCommand readCmd = db.InitCmd("ZSanzioniRecuperoGetById", new string[] { "IdSanzioneRecupero" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdSanzioneRecupero", (SiarLibrary.NullTypes.IntNT)IdSanzioneRecuperoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                SanzioniRecuperoObj = GetFromDatareader(db);
                SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SanzioniRecuperoObj.IsDirty = false;
                SanzioniRecuperoObj.IsPersistent = true;
            }
            db.Close();
            return SanzioniRecuperoObj;
        }

        //getFromDatareader
        public static SanzioniRecupero GetFromDatareader(DbProvider db)
        {
            SanzioniRecupero SanzioniRecuperoObj = new SanzioniRecupero();
            SanzioniRecuperoObj.IdSanzioneRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SANZIONE_RECUPERO"]);
            SanzioniRecuperoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            SanzioniRecuperoObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            SanzioniRecuperoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            SanzioniRecuperoObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            SanzioniRecuperoObj.IdRegistroRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_RECUPERO"]);
            SanzioniRecuperoObj.IdCategoriaSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CATEGORIA_SANZIONE"]);
            SanzioniRecuperoObj.IdTipoSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_SANZIONE"]);
            SanzioniRecuperoObj.ImportoSanzione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SANZIONE"]);
            SanzioniRecuperoObj.DataConclusione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE"]);
            SanzioniRecuperoObj.IdStatoSanzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STATO_SANZIONE"]);
            SanzioniRecuperoObj.IdRegistroIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_IRREGOLARITA"]);
            SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            SanzioniRecuperoObj.IsDirty = false;
            SanzioniRecuperoObj.IsPersistent = true;
            return SanzioniRecuperoObj;
        }

        //Find Select

        public static SanzioniRecuperoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSanzioneRecuperoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroRecuperoEqualThis,
SiarLibrary.NullTypes.IntNT IdCategoriaSanzioneEqualThis, SiarLibrary.NullTypes.IntNT IdTipoSanzioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSanzioneEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataConclusioneEqualThis, SiarLibrary.NullTypes.IntNT IdStatoSanzioneEqualThis)
        {

            SanzioniRecuperoCollection SanzioniRecuperoCollectionObj = new SanzioniRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zsanzionirecuperofindselect", new string[] {"IdSanzioneRecuperoequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "IdRegistroRecuperoequalthis", 
"IdCategoriaSanzioneequalthis", "IdTipoSanzioneequalthis", "ImportoSanzioneequalthis", 
"DataConclusioneequalthis", "IdStatoSanzioneequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"int", "int", "decimal", 
"DateTime", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSanzioneRecuperoequalthis", IdSanzioneRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroRecuperoequalthis", IdRegistroRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCategoriaSanzioneequalthis", IdCategoriaSanzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoSanzioneequalthis", IdTipoSanzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSanzioneequalthis", ImportoSanzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataConclusioneequalthis", DataConclusioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStatoSanzioneequalthis", IdStatoSanzioneEqualThis);
            SanzioniRecupero SanzioniRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SanzioniRecuperoObj = GetFromDatareader(db);
                SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SanzioniRecuperoObj.IsDirty = false;
                SanzioniRecuperoObj.IsPersistent = true;
                SanzioniRecuperoCollectionObj.Add(SanzioniRecuperoObj);
            }
            db.Close();
            return SanzioniRecuperoCollectionObj;
        }

        //Find GetByRegistroRecupero

        public static SanzioniRecuperoCollection GetByRegistroRecupero(DbProvider db, SiarLibrary.NullTypes.IntNT IdRegistroRecuperoEqualThis)
        {

            SanzioniRecuperoCollection SanzioniRecuperoCollectionObj = new SanzioniRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zsanzionirecuperofindgetbyregistrorecupero", new string[] { "IdRegistroRecuperoequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroRecuperoequalthis", IdRegistroRecuperoEqualThis);
            SanzioniRecupero SanzioniRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SanzioniRecuperoObj = GetFromDatareader(db);
                SanzioniRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SanzioniRecuperoObj.IsDirty = false;
                SanzioniRecuperoObj.IsPersistent = true;
                SanzioniRecuperoCollectionObj.Add(SanzioniRecuperoObj);
            }
            db.Close();
            return SanzioniRecuperoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for SanzioniRecuperoCollectionProvider:ISanzioniRecuperoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SanzioniRecuperoCollectionProvider : ISanzioniRecuperoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di SanzioniRecupero
        protected SanzioniRecuperoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public SanzioniRecuperoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new SanzioniRecuperoCollection(this);
        }

        //Costruttore 2: popola la collection
        public SanzioniRecuperoCollectionProvider(IntNT IdregistrorecuperoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = GetByRegistroRecupero(IdregistrorecuperoEqualThis);
        }

        //Costruttore3: ha in input sanzionirecuperoCollectionObj - non popola la collection
        public SanzioniRecuperoCollectionProvider(SanzioniRecuperoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public SanzioniRecuperoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new SanzioniRecuperoCollection(this);
        }

        //Get e Set
        public SanzioniRecuperoCollection CollectionObj
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
        public int SaveCollection(SanzioniRecuperoCollection collectionObj)
        {
            return SanzioniRecuperoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(SanzioniRecupero sanzionirecuperoObj)
        {
            return SanzioniRecuperoDAL.Save(_dbProviderObj, sanzionirecuperoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(SanzioniRecuperoCollection collectionObj)
        {
            return SanzioniRecuperoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(SanzioniRecupero sanzionirecuperoObj)
        {
            return SanzioniRecuperoDAL.Delete(_dbProviderObj, sanzionirecuperoObj);
        }

        //getById
        public SanzioniRecupero GetById(IntNT IdSanzioneRecuperoValue)
        {
            SanzioniRecupero SanzioniRecuperoTemp = SanzioniRecuperoDAL.GetById(_dbProviderObj, IdSanzioneRecuperoValue);
            if (SanzioniRecuperoTemp != null) SanzioniRecuperoTemp.Provider = this;
            return SanzioniRecuperoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public SanzioniRecuperoCollection Select(IntNT IdsanzionerecuperoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdregistrorecuperoEqualThis,
IntNT IdcategoriasanzioneEqualThis, IntNT IdtiposanzioneEqualThis, DecimalNT ImportosanzioneEqualThis,
DatetimeNT DataconclusioneEqualThis, IntNT IdstatosanzioneEqualThis)
        {
            SanzioniRecuperoCollection SanzioniRecuperoCollectionTemp = SanzioniRecuperoDAL.Select(_dbProviderObj, IdsanzionerecuperoEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis,
DatamodificaEqualThis, CfmodificaEqualThis, IdregistrorecuperoEqualThis,
IdcategoriasanzioneEqualThis, IdtiposanzioneEqualThis, ImportosanzioneEqualThis,
DataconclusioneEqualThis, IdstatosanzioneEqualThis);
            SanzioniRecuperoCollectionTemp.Provider = this;
            return SanzioniRecuperoCollectionTemp;
        }

        //GetByRegistroRecupero: popola la collection
        public SanzioniRecuperoCollection GetByRegistroRecupero(IntNT IdregistrorecuperoEqualThis)
        {
            SanzioniRecuperoCollection SanzioniRecuperoCollectionTemp = SanzioniRecuperoDAL.GetByRegistroRecupero(_dbProviderObj, IdregistrorecuperoEqualThis);
            SanzioniRecuperoCollectionTemp.Provider = this;
            return SanzioniRecuperoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SANZIONI_RECUPERO>
  <ViewName>VSANZIONI_RECUPERO</ViewName>
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
    <GetByRegistroRecupero OrderBy="ORDER BY ">
      <ID_REGISTRO_RECUPERO>Equal</ID_REGISTRO_RECUPERO>
    </GetByRegistroRecupero>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SANZIONI_RECUPERO>
*/
