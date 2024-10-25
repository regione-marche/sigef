using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ImpresaDichiarazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IImpresaDichiarazioneProvider
    {
        int Save(ImpresaDichiarazione ImpresaDichiarazioneObj);
        int SaveCollection(ImpresaDichiarazioneCollection collectionObj);
        int Delete(ImpresaDichiarazione ImpresaDichiarazioneObj);
        int DeleteCollection(ImpresaDichiarazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ImpresaDichiarazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ImpresaDichiarazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdImpresaDichiarazione;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _CfUtenteDichiarazione;
        private NullTypes.StringNT _RagioneSociale;
        private NullTypes.StringNT _Cuaa;
        private NullTypes.StringNT _CodiceFiscale;
        private NullTypes.StringNT _NominativoDichiarazione;
        [NonSerialized] private IImpresaDichiarazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaDichiarazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ImpresaDichiarazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA_DICHIARAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaDichiarazione
        {
            get { return _IdImpresaDichiarazione; }
            set
            {
                if (IdImpresaDichiarazione != value)
                {
                    _IdImpresaDichiarazione = value;
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
        /// Tipo sul db:VARCHAR(100)
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
        /// Tipo sul db:VARCHAR(100)
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
        /// Corrisponde al campo:CF_UTENTE_DICHIARAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT CfUtenteDichiarazione
        {
            get { return _CfUtenteDichiarazione; }
            set
            {
                if (CfUtenteDichiarazione != value)
                {
                    _CfUtenteDichiarazione = value;
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
        /// Corrisponde al campo:NOMINATIVO_DICHIARAZIONE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoDichiarazione
        {
            get { return _NominativoDichiarazione; }
            set
            {
                if (NominativoDichiarazione != value)
                {
                    _NominativoDichiarazione = value;
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
    /// Summary description for ImpresaDichiarazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaDichiarazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ImpresaDichiarazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ImpresaDichiarazione)info.GetValue(i.ToString(), typeof(ImpresaDichiarazione)));
            }
        }

        //Costruttore
        public ImpresaDichiarazioneCollection()
        {
            this.ItemType = typeof(ImpresaDichiarazione);
        }

        //Costruttore con provider
        public ImpresaDichiarazioneCollection(IImpresaDichiarazioneProvider providerObj)
        {
            this.ItemType = typeof(ImpresaDichiarazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ImpresaDichiarazione this[int index]
        {
            get { return (ImpresaDichiarazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ImpresaDichiarazioneCollection GetChanges()
        {
            return (ImpresaDichiarazioneCollection)base.GetChanges();
        }

        [NonSerialized] private IImpresaDichiarazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaDichiarazioneProvider Provider
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
        public int Add(ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            if (ImpresaDichiarazioneObj.Provider == null) ImpresaDichiarazioneObj.Provider = this.Provider;
            return base.Add(ImpresaDichiarazioneObj);
        }

        //AddCollection
        public void AddCollection(ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionObj)
        {
            foreach (ImpresaDichiarazione ImpresaDichiarazioneObj in ImpresaDichiarazioneCollectionObj)
                this.Add(ImpresaDichiarazioneObj);
        }

        //Insert
        public void Insert(int index, ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            if (ImpresaDichiarazioneObj.Provider == null) ImpresaDichiarazioneObj.Provider = this.Provider;
            base.Insert(index, ImpresaDichiarazioneObj);
        }

        //CollectionGetById
        public ImpresaDichiarazione CollectionGetById(NullTypes.IntNT IdImpresaDichiarazioneValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdImpresaDichiarazione == IdImpresaDichiarazioneValue))
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
        public ImpresaDichiarazioneCollection SubSelect(NullTypes.IntNT IdImpresaDichiarazioneEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdBandoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CfUtenteDichiarazioneEqualThis)
        {
            ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionTemp = new ImpresaDichiarazioneCollection();
            foreach (ImpresaDichiarazione ImpresaDichiarazioneItem in this)
            {
                if (((IdImpresaDichiarazioneEqualThis == null) || ((ImpresaDichiarazioneItem.IdImpresaDichiarazione != null) && (ImpresaDichiarazioneItem.IdImpresaDichiarazione.Value == IdImpresaDichiarazioneEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ImpresaDichiarazioneItem.DataInserimento != null) && (ImpresaDichiarazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((ImpresaDichiarazioneItem.CfInserimento != null) && (ImpresaDichiarazioneItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((ImpresaDichiarazioneItem.DataModifica != null) && (ImpresaDichiarazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((ImpresaDichiarazioneItem.CfModifica != null) && (ImpresaDichiarazioneItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ImpresaDichiarazioneItem.IdBando != null) && (ImpresaDichiarazioneItem.IdBando.Value == IdBandoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((ImpresaDichiarazioneItem.IdProgetto != null) && (ImpresaDichiarazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaDichiarazioneItem.IdImpresa != null) && (ImpresaDichiarazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CfUtenteDichiarazioneEqualThis == null) || ((ImpresaDichiarazioneItem.CfUtenteDichiarazione != null) && (ImpresaDichiarazioneItem.CfUtenteDichiarazione.Value == CfUtenteDichiarazioneEqualThis.Value))))
                {
                    ImpresaDichiarazioneCollectionTemp.Add(ImpresaDichiarazioneItem);
                }
            }
            return ImpresaDichiarazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ImpresaDichiarazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ImpresaDichiarazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaDichiarazione ImpresaDichiarazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdImpresaDichiarazione", ImpresaDichiarazioneObj.IdImpresaDichiarazione);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ImpresaDichiarazioneObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", ImpresaDichiarazioneObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ImpresaDichiarazioneObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", ImpresaDichiarazioneObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdBando", ImpresaDichiarazioneObj.IdBando);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ImpresaDichiarazioneObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ImpresaDichiarazioneObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "CfUtenteDichiarazione", ImpresaDichiarazioneObj.CfUtenteDichiarazione);
        }
        //Insert
        private static int Insert(DbProvider db, ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZImpresaDichiarazioneInsert", new string[] {"DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdBando",
"IdProgetto", "IdImpresa", "CfUtenteDichiarazione",
}, new string[] {"DateTime", "string",
"DateTime", "string", "int",
"int", "int", "string",
}, "");
                CompileIUCmd(false, insertCmd, ImpresaDichiarazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ImpresaDichiarazioneObj.IdImpresaDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_DICHIARAZIONE"]);
                }
                ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaDichiarazioneObj.IsDirty = false;
                ImpresaDichiarazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaDichiarazioneUpdate", new string[] {"IdImpresaDichiarazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdBando",
"IdProgetto", "IdImpresa", "CfUtenteDichiarazione",
}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"int", "int", "string",
}, "");
                CompileIUCmd(true, updateCmd, ImpresaDichiarazioneObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ImpresaDichiarazioneObj.DataModifica = d;
                }
                ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaDichiarazioneObj.IsDirty = false;
                ImpresaDichiarazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            switch (ImpresaDichiarazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ImpresaDichiarazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ImpresaDichiarazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ImpresaDichiarazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaDichiarazioneUpdate", new string[] {"IdImpresaDichiarazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdBando",
"IdProgetto", "IdImpresa", "CfUtenteDichiarazione",
}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"int", "int", "string",
}, "");
                IDbCommand insertCmd = db.InitCmd("ZImpresaDichiarazioneInsert", new string[] {"DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdBando",
"IdProgetto", "IdImpresa", "CfUtenteDichiarazione",
}, new string[] {"DateTime", "string",
"DateTime", "string", "int",
"int", "int", "string",
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDichiarazioneDelete", new string[] { "IdImpresaDichiarazione" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaDichiarazioneCollectionObj.Count; i++)
                {
                    switch (ImpresaDichiarazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ImpresaDichiarazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ImpresaDichiarazioneCollectionObj[i].IdImpresaDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_DICHIARAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ImpresaDichiarazioneCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ImpresaDichiarazioneCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ImpresaDichiarazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaDichiarazione", (SiarLibrary.NullTypes.IntNT)ImpresaDichiarazioneCollectionObj[i].IdImpresaDichiarazione);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ImpresaDichiarazioneCollectionObj.Count; i++)
                {
                    if ((ImpresaDichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaDichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaDichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ImpresaDichiarazioneCollectionObj[i].IsDirty = false;
                        ImpresaDichiarazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((ImpresaDichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ImpresaDichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaDichiarazioneCollectionObj[i].IsDirty = false;
                        ImpresaDichiarazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ImpresaDichiarazione ImpresaDichiarazioneObj)
        {
            int returnValue = 0;
            if (ImpresaDichiarazioneObj.IsPersistent)
            {
                returnValue = Delete(db, ImpresaDichiarazioneObj.IdImpresaDichiarazione);
            }
            ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ImpresaDichiarazioneObj.IsDirty = false;
            ImpresaDichiarazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdImpresaDichiarazioneValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDichiarazioneDelete", new string[] { "IdImpresaDichiarazione" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaDichiarazione", (SiarLibrary.NullTypes.IntNT)IdImpresaDichiarazioneValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaDichiarazioneDelete", new string[] { "IdImpresaDichiarazione" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaDichiarazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaDichiarazione", ImpresaDichiarazioneCollectionObj[i].IdImpresaDichiarazione);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ImpresaDichiarazioneCollectionObj.Count; i++)
                {
                    if ((ImpresaDichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaDichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaDichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaDichiarazioneCollectionObj[i].IsDirty = false;
                        ImpresaDichiarazioneCollectionObj[i].IsPersistent = false;
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
        public static ImpresaDichiarazione GetById(DbProvider db, int IdImpresaDichiarazioneValue)
        {
            ImpresaDichiarazione ImpresaDichiarazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZImpresaDichiarazioneGetById", new string[] { "IdImpresaDichiarazione" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdImpresaDichiarazione", (SiarLibrary.NullTypes.IntNT)IdImpresaDichiarazioneValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ImpresaDichiarazioneObj = GetFromDatareader(db);
                ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaDichiarazioneObj.IsDirty = false;
                ImpresaDichiarazioneObj.IsPersistent = true;
            }
            db.Close();
            return ImpresaDichiarazioneObj;
        }

        //getFromDatareader
        public static ImpresaDichiarazione GetFromDatareader(DbProvider db)
        {
            ImpresaDichiarazione ImpresaDichiarazioneObj = new ImpresaDichiarazione();
            ImpresaDichiarazioneObj.IdImpresaDichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_DICHIARAZIONE"]);
            ImpresaDichiarazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ImpresaDichiarazioneObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            ImpresaDichiarazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ImpresaDichiarazioneObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            ImpresaDichiarazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            ImpresaDichiarazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ImpresaDichiarazioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            ImpresaDichiarazioneObj.CfUtenteDichiarazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_DICHIARAZIONE"]);
            ImpresaDichiarazioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
            ImpresaDichiarazioneObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
            ImpresaDichiarazioneObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
            ImpresaDichiarazioneObj.NominativoDichiarazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_DICHIARAZIONE"]);
            ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ImpresaDichiarazioneObj.IsDirty = false;
            ImpresaDichiarazioneObj.IsPersistent = true;
            return ImpresaDichiarazioneObj;
        }

        //Find Select

        public static ImpresaDichiarazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaDichiarazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CfUtenteDichiarazioneEqualThis)

        {

            ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionObj = new ImpresaDichiarazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresadichiarazionefindselect", new string[] {"IdImpresaDichiarazioneequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis",
"DataModificaequalthis", "CfModificaequalthis", "IdBandoequalthis",
"IdProgettoequalthis", "IdImpresaequalthis", "CfUtenteDichiarazioneequalthis"}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"int", "int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaDichiarazioneequalthis", IdImpresaDichiarazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfUtenteDichiarazioneequalthis", CfUtenteDichiarazioneEqualThis);
            ImpresaDichiarazione ImpresaDichiarazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaDichiarazioneObj = GetFromDatareader(db);
                ImpresaDichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaDichiarazioneObj.IsDirty = false;
                ImpresaDichiarazioneObj.IsPersistent = true;
                ImpresaDichiarazioneCollectionObj.Add(ImpresaDichiarazioneObj);
            }
            db.Close();
            return ImpresaDichiarazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ImpresaDichiarazioneCollectionProvider:IImpresaDichiarazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaDichiarazioneCollectionProvider : IImpresaDichiarazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ImpresaDichiarazione
        protected ImpresaDichiarazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ImpresaDichiarazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ImpresaDichiarazioneCollection(this);
        }

        //Costruttore3: ha in input impresadichiarazioneCollectionObj - non popola la collection
        public ImpresaDichiarazioneCollectionProvider(ImpresaDichiarazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ImpresaDichiarazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ImpresaDichiarazioneCollection(this);
        }

        //Get e Set
        public ImpresaDichiarazioneCollection CollectionObj
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
        public int SaveCollection(ImpresaDichiarazioneCollection collectionObj)
        {
            return ImpresaDichiarazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ImpresaDichiarazione impresadichiarazioneObj)
        {
            return ImpresaDichiarazioneDAL.Save(_dbProviderObj, impresadichiarazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ImpresaDichiarazioneCollection collectionObj)
        {
            return ImpresaDichiarazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ImpresaDichiarazione impresadichiarazioneObj)
        {
            return ImpresaDichiarazioneDAL.Delete(_dbProviderObj, impresadichiarazioneObj);
        }

        //getById
        public ImpresaDichiarazione GetById(IntNT IdImpresaDichiarazioneValue)
        {
            ImpresaDichiarazione ImpresaDichiarazioneTemp = ImpresaDichiarazioneDAL.GetById(_dbProviderObj, IdImpresaDichiarazioneValue);
            if (ImpresaDichiarazioneTemp != null) ImpresaDichiarazioneTemp.Provider = this;
            return ImpresaDichiarazioneTemp;
        }

        //Select: popola la collection
        public ImpresaDichiarazioneCollection Select(IntNT IdimpresadichiarazioneEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, StringNT CfutentedichiarazioneEqualThis)
        {
            ImpresaDichiarazioneCollection ImpresaDichiarazioneCollectionTemp = ImpresaDichiarazioneDAL.Select(_dbProviderObj, IdimpresadichiarazioneEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis,
DatamodificaEqualThis, CfmodificaEqualThis, IdbandoEqualThis,
IdprogettoEqualThis, IdimpresaEqualThis, CfutentedichiarazioneEqualThis);
            ImpresaDichiarazioneCollectionTemp.Provider = this;
            return ImpresaDichiarazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_DICHIARAZIONE>
  <ViewName>VIMPRESA_DICHIARAZIONE</ViewName>
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
</IMPRESA_DICHIARAZIONE>
*/
