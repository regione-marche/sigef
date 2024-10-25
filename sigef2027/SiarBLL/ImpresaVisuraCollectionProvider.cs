using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ImpresaVisura
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IImpresaVisuraProvider
    {
        int Save(ImpresaVisura ImpresaVisuraObj);
        int SaveCollection(ImpresaVisuraCollection collectionObj);
        int Delete(ImpresaVisura ImpresaVisuraObj);
        int DeleteCollection(ImpresaVisuraCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ImpresaVisura
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ImpresaVisura : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdImpresaVisura;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.IntNT _IdFileVisura;
        private NullTypes.DatetimeNT _DataVisura;
        private NullTypes.BoolNT _Istruita;
        private NullTypes.StringNT _CfIstruttore;
        private NullTypes.DatetimeNT _DataIstruttoria;
        private NullTypes.StringNT _RagioneSociale;
        private NullTypes.StringNT _Cuaa;
        private NullTypes.StringNT _CodiceFiscale;
        private NullTypes.StringNT _TipoFile;
        private NullTypes.StringNT _NomeFile;
        private NullTypes.StringNT _NominativoInserimento;
        private NullTypes.StringNT _NominativoIstruttore;
        [NonSerialized] private IImpresaVisuraProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaVisuraProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ImpresaVisura()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA_VISURA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaVisura
        {
            get { return _IdImpresaVisura; }
            set
            {
                if (IdImpresaVisura != value)
                {
                    _IdImpresaVisura = value;
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
        /// Corrisponde al campo:ID_FILE_VISURA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFileVisura
        {
            get { return _IdFileVisura; }
            set
            {
                if (IdFileVisura != value)
                {
                    _IdFileVisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VISURA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataVisura
        {
            get { return _DataVisura; }
            set
            {
                if (DataVisura != value)
                {
                    _DataVisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUITA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Istruita
        {
            get { return _Istruita; }
            set
            {
                if (Istruita != value)
                {
                    _Istruita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_ISTRUTTORE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT CfIstruttore
        {
            get { return _CfIstruttore; }
            set
            {
                if (CfIstruttore != value)
                {
                    _CfIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ISTRUTTORIA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataIstruttoria
        {
            get { return _DataIstruttoria; }
            set
            {
                if (DataIstruttoria != value)
                {
                    _DataIstruttoria = value;
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
        /// Corrisponde al campo:TIPO_FILE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TipoFile
        {
            get { return _TipoFile; }
            set
            {
                if (TipoFile != value)
                {
                    _TipoFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOME_FILE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT NomeFile
        {
            get { return _NomeFile; }
            set
            {
                if (NomeFile != value)
                {
                    _NomeFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_INSERIMENTO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoInserimento
        {
            get { return _NominativoInserimento; }
            set
            {
                if (NominativoInserimento != value)
                {
                    _NominativoInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_ISTRUTTORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoIstruttore
        {
            get { return _NominativoIstruttore; }
            set
            {
                if (NominativoIstruttore != value)
                {
                    _NominativoIstruttore = value;
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
    /// Summary description for ImpresaVisuraCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaVisuraCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ImpresaVisuraCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ImpresaVisura)info.GetValue(i.ToString(), typeof(ImpresaVisura)));
            }
        }

        //Costruttore
        public ImpresaVisuraCollection()
        {
            this.ItemType = typeof(ImpresaVisura);
        }

        //Costruttore con provider
        public ImpresaVisuraCollection(IImpresaVisuraProvider providerObj)
        {
            this.ItemType = typeof(ImpresaVisura);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ImpresaVisura this[int index]
        {
            get { return (ImpresaVisura)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ImpresaVisuraCollection GetChanges()
        {
            return (ImpresaVisuraCollection)base.GetChanges();
        }

        [NonSerialized] private IImpresaVisuraProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IImpresaVisuraProvider Provider
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
        public int Add(ImpresaVisura ImpresaVisuraObj)
        {
            if (ImpresaVisuraObj.Provider == null) ImpresaVisuraObj.Provider = this.Provider;
            return base.Add(ImpresaVisuraObj);
        }

        //AddCollection
        public void AddCollection(ImpresaVisuraCollection ImpresaVisuraCollectionObj)
        {
            foreach (ImpresaVisura ImpresaVisuraObj in ImpresaVisuraCollectionObj)
                this.Add(ImpresaVisuraObj);
        }

        //Insert
        public void Insert(int index, ImpresaVisura ImpresaVisuraObj)
        {
            if (ImpresaVisuraObj.Provider == null) ImpresaVisuraObj.Provider = this.Provider;
            base.Insert(index, ImpresaVisuraObj);
        }

        //CollectionGetById
        public ImpresaVisura CollectionGetById(NullTypes.IntNT IdImpresaVisuraValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdImpresaVisura == IdImpresaVisuraValue))
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
        public ImpresaVisuraCollection SubSelect(NullTypes.IntNT IdImpresaVisuraEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.IntNT IdFileVisuraEqualThis, NullTypes.DatetimeNT DataVisuraEqualThis, NullTypes.BoolNT IstruitaEqualThis,
NullTypes.StringNT CfIstruttoreEqualThis, NullTypes.DatetimeNT DataIstruttoriaEqualThis)
        {
            ImpresaVisuraCollection ImpresaVisuraCollectionTemp = new ImpresaVisuraCollection();
            foreach (ImpresaVisura ImpresaVisuraItem in this)
            {
                if (((IdImpresaVisuraEqualThis == null) || ((ImpresaVisuraItem.IdImpresaVisura != null) && (ImpresaVisuraItem.IdImpresaVisura.Value == IdImpresaVisuraEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaVisuraItem.IdImpresa != null) && (ImpresaVisuraItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ImpresaVisuraItem.DataInserimento != null) && (ImpresaVisuraItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((ImpresaVisuraItem.CfInserimento != null) && (ImpresaVisuraItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ImpresaVisuraItem.DataModifica != null) && (ImpresaVisuraItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((ImpresaVisuraItem.CfModifica != null) && (ImpresaVisuraItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((IdFileVisuraEqualThis == null) || ((ImpresaVisuraItem.IdFileVisura != null) && (ImpresaVisuraItem.IdFileVisura.Value == IdFileVisuraEqualThis.Value))) && ((DataVisuraEqualThis == null) || ((ImpresaVisuraItem.DataVisura != null) && (ImpresaVisuraItem.DataVisura.Value == DataVisuraEqualThis.Value))) && ((IstruitaEqualThis == null) || ((ImpresaVisuraItem.Istruita != null) && (ImpresaVisuraItem.Istruita.Value == IstruitaEqualThis.Value))) &&
((CfIstruttoreEqualThis == null) || ((ImpresaVisuraItem.CfIstruttore != null) && (ImpresaVisuraItem.CfIstruttore.Value == CfIstruttoreEqualThis.Value))) && ((DataIstruttoriaEqualThis == null) || ((ImpresaVisuraItem.DataIstruttoria != null) && (ImpresaVisuraItem.DataIstruttoria.Value == DataIstruttoriaEqualThis.Value))))
                {
                    ImpresaVisuraCollectionTemp.Add(ImpresaVisuraItem);
                }
            }
            return ImpresaVisuraCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ImpresaVisuraDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ImpresaVisuraDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaVisura ImpresaVisuraObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdImpresaVisura", ImpresaVisuraObj.IdImpresaVisura);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ImpresaVisuraObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ImpresaVisuraObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", ImpresaVisuraObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ImpresaVisuraObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", ImpresaVisuraObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFileVisura", ImpresaVisuraObj.IdFileVisura);
            DbProvider.SetCmdParam(cmd, firstChar + "DataVisura", ImpresaVisuraObj.DataVisura);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruita", ImpresaVisuraObj.Istruita);
            DbProvider.SetCmdParam(cmd, firstChar + "CfIstruttore", ImpresaVisuraObj.CfIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataIstruttoria", ImpresaVisuraObj.DataIstruttoria);
        }
        //Insert
        private static int Insert(DbProvider db, ImpresaVisura ImpresaVisuraObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZImpresaVisuraInsert", new string[] {"IdImpresa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"IdFileVisura", "DataVisura", "Istruita",
"CfIstruttore", "DataIstruttoria",
}, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"int", "DateTime", "bool",
"string", "DateTime",
}, "");
                CompileIUCmd(false, insertCmd, ImpresaVisuraObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ImpresaVisuraObj.IdImpresaVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_VISURA"]);
                }
                ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaVisuraObj.IsDirty = false;
                ImpresaVisuraObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ImpresaVisura ImpresaVisuraObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaVisuraUpdate", new string[] {"IdImpresaVisura", "IdImpresa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"IdFileVisura", "DataVisura", "Istruita",
"CfIstruttore", "DataIstruttoria",
}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"int", "DateTime", "bool",
"string", "DateTime",
}, "");
                CompileIUCmd(true, updateCmd, ImpresaVisuraObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ImpresaVisuraObj.DataModifica = d;
                }
                ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaVisuraObj.IsDirty = false;
                ImpresaVisuraObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ImpresaVisura ImpresaVisuraObj)
        {
            switch (ImpresaVisuraObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ImpresaVisuraObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ImpresaVisuraObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ImpresaVisuraObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ImpresaVisuraCollection ImpresaVisuraCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZImpresaVisuraUpdate", new string[] {"IdImpresaVisura", "IdImpresa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"IdFileVisura", "DataVisura", "Istruita",
"CfIstruttore", "DataIstruttoria",
}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"int", "DateTime", "bool",
"string", "DateTime",
}, "");
                IDbCommand insertCmd = db.InitCmd("ZImpresaVisuraInsert", new string[] {"IdImpresa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"IdFileVisura", "DataVisura", "Istruita",
"CfIstruttore", "DataIstruttoria",
}, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"int", "DateTime", "bool",
"string", "DateTime",
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZImpresaVisuraDelete", new string[] { "IdImpresaVisura" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaVisuraCollectionObj.Count; i++)
                {
                    switch (ImpresaVisuraCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ImpresaVisuraCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ImpresaVisuraCollectionObj[i].IdImpresaVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_VISURA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ImpresaVisuraCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ImpresaVisuraCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ImpresaVisuraCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaVisura", (SiarLibrary.NullTypes.IntNT)ImpresaVisuraCollectionObj[i].IdImpresaVisura);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ImpresaVisuraCollectionObj.Count; i++)
                {
                    if ((ImpresaVisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaVisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaVisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ImpresaVisuraCollectionObj[i].IsDirty = false;
                        ImpresaVisuraCollectionObj[i].IsPersistent = true;
                    }
                    if ((ImpresaVisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ImpresaVisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaVisuraCollectionObj[i].IsDirty = false;
                        ImpresaVisuraCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ImpresaVisura ImpresaVisuraObj)
        {
            int returnValue = 0;
            if (ImpresaVisuraObj.IsPersistent)
            {
                returnValue = Delete(db, ImpresaVisuraObj.IdImpresaVisura);
            }
            ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ImpresaVisuraObj.IsDirty = false;
            ImpresaVisuraObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdImpresaVisuraValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaVisuraDelete", new string[] { "IdImpresaVisura" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaVisura", (SiarLibrary.NullTypes.IntNT)IdImpresaVisuraValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ImpresaVisuraCollection ImpresaVisuraCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZImpresaVisuraDelete", new string[] { "IdImpresaVisura" }, new string[] { "int" }, "");
                for (int i = 0; i < ImpresaVisuraCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdImpresaVisura", ImpresaVisuraCollectionObj[i].IdImpresaVisura);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ImpresaVisuraCollectionObj.Count; i++)
                {
                    if ((ImpresaVisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaVisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ImpresaVisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ImpresaVisuraCollectionObj[i].IsDirty = false;
                        ImpresaVisuraCollectionObj[i].IsPersistent = false;
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
        public static ImpresaVisura GetById(DbProvider db, int IdImpresaVisuraValue)
        {
            ImpresaVisura ImpresaVisuraObj = null;
            IDbCommand readCmd = db.InitCmd("ZImpresaVisuraGetById", new string[] { "IdImpresaVisura" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdImpresaVisura", (SiarLibrary.NullTypes.IntNT)IdImpresaVisuraValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ImpresaVisuraObj = GetFromDatareader(db);
                ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaVisuraObj.IsDirty = false;
                ImpresaVisuraObj.IsPersistent = true;
            }
            db.Close();
            return ImpresaVisuraObj;
        }

        //getFromDatareader
        public static ImpresaVisura GetFromDatareader(DbProvider db)
        {
            ImpresaVisura ImpresaVisuraObj = new ImpresaVisura();
            ImpresaVisuraObj.IdImpresaVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_VISURA"]);
            ImpresaVisuraObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            ImpresaVisuraObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ImpresaVisuraObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            ImpresaVisuraObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ImpresaVisuraObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            ImpresaVisuraObj.IdFileVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_VISURA"]);
            ImpresaVisuraObj.DataVisura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VISURA"]);
            ImpresaVisuraObj.Istruita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ISTRUITA"]);
            ImpresaVisuraObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
            ImpresaVisuraObj.DataIstruttoria = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ISTRUTTORIA"]);
            ImpresaVisuraObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
            ImpresaVisuraObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
            ImpresaVisuraObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
            ImpresaVisuraObj.TipoFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_FILE"]);
            ImpresaVisuraObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
            ImpresaVisuraObj.NominativoInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_INSERIMENTO"]);
            ImpresaVisuraObj.NominativoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_ISTRUTTORE"]);
            ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ImpresaVisuraObj.IsDirty = false;
            ImpresaVisuraObj.IsPersistent = true;
            return ImpresaVisuraObj;
        }

        //Find Select

        public static ImpresaVisuraCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaVisuraEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.IntNT IdFileVisuraEqualThis, SiarLibrary.NullTypes.DatetimeNT DataVisuraEqualThis, SiarLibrary.NullTypes.BoolNT IstruitaEqualThis,
SiarLibrary.NullTypes.StringNT CfIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataIstruttoriaEqualThis)

        {

            ImpresaVisuraCollection ImpresaVisuraCollectionObj = new ImpresaVisuraCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresavisurafindselect", new string[] {"IdImpresaVisuraequalthis", "IdImpresaequalthis", "DataInserimentoequalthis",
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis",
"IdFileVisuraequalthis", "DataVisuraequalthis", "Istruitaequalthis",
"CfIstruttoreequalthis", "DataIstruttoriaequalthis"}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"int", "DateTime", "bool",
"string", "DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaVisuraequalthis", IdImpresaVisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileVisuraequalthis", IdFileVisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataVisuraequalthis", DataVisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruitaequalthis", IstruitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfIstruttoreequalthis", CfIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIstruttoriaequalthis", DataIstruttoriaEqualThis);
            ImpresaVisura ImpresaVisuraObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaVisuraObj = GetFromDatareader(db);
                ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaVisuraObj.IsDirty = false;
                ImpresaVisuraObj.IsPersistent = true;
                ImpresaVisuraCollectionObj.Add(ImpresaVisuraObj);
            }
            db.Close();
            return ImpresaVisuraCollectionObj;
        }

        //Find FindVisureImpresa

        public static ImpresaVisuraCollection FindVisureImpresa(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

        {

            ImpresaVisuraCollection ImpresaVisuraCollectionObj = new ImpresaVisuraCollection();

            IDbCommand findCmd = db.InitCmd("Zimpresavisurafindfindvisureimpresa", new string[] { "IdImpresaequalthis" }, new string[] { "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            ImpresaVisura ImpresaVisuraObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ImpresaVisuraObj = GetFromDatareader(db);
                ImpresaVisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ImpresaVisuraObj.IsDirty = false;
                ImpresaVisuraObj.IsPersistent = true;
                ImpresaVisuraCollectionObj.Add(ImpresaVisuraObj);
            }
            db.Close();
            return ImpresaVisuraCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ImpresaVisuraCollectionProvider:IImpresaVisuraProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ImpresaVisuraCollectionProvider : IImpresaVisuraProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ImpresaVisura
        protected ImpresaVisuraCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ImpresaVisuraCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ImpresaVisuraCollection(this);
        }

        //Costruttore 2: popola la collection
        public ImpresaVisuraCollectionProvider(IntNT IdimpresaEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindVisureImpresa(IdimpresaEqualThis);
        }

        //Costruttore3: ha in input impresavisuraCollectionObj - non popola la collection
        public ImpresaVisuraCollectionProvider(ImpresaVisuraCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ImpresaVisuraCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ImpresaVisuraCollection(this);
        }

        //Get e Set
        public ImpresaVisuraCollection CollectionObj
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
        public int SaveCollection(ImpresaVisuraCollection collectionObj)
        {
            return ImpresaVisuraDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ImpresaVisura impresavisuraObj)
        {
            return ImpresaVisuraDAL.Save(_dbProviderObj, impresavisuraObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ImpresaVisuraCollection collectionObj)
        {
            return ImpresaVisuraDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ImpresaVisura impresavisuraObj)
        {
            return ImpresaVisuraDAL.Delete(_dbProviderObj, impresavisuraObj);
        }

        //getById
        public ImpresaVisura GetById(IntNT IdImpresaVisuraValue)
        {
            ImpresaVisura ImpresaVisuraTemp = ImpresaVisuraDAL.GetById(_dbProviderObj, IdImpresaVisuraValue);
            if (ImpresaVisuraTemp != null) ImpresaVisuraTemp.Provider = this;
            return ImpresaVisuraTemp;
        }

        //Select: popola la collection
        public ImpresaVisuraCollection Select(IntNT IdimpresavisuraEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis,
IntNT IdfilevisuraEqualThis, DatetimeNT DatavisuraEqualThis, BoolNT IstruitaEqualThis,
StringNT CfistruttoreEqualThis, DatetimeNT DataistruttoriaEqualThis)
        {
            ImpresaVisuraCollection ImpresaVisuraCollectionTemp = ImpresaVisuraDAL.Select(_dbProviderObj, IdimpresavisuraEqualThis, IdimpresaEqualThis, DatainserimentoEqualThis,
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis,
IdfilevisuraEqualThis, DatavisuraEqualThis, IstruitaEqualThis,
CfistruttoreEqualThis, DataistruttoriaEqualThis);
            ImpresaVisuraCollectionTemp.Provider = this;
            return ImpresaVisuraCollectionTemp;
        }

        //FindVisureImpresa: popola la collection
        public ImpresaVisuraCollection FindVisureImpresa(IntNT IdimpresaEqualThis)
        {
            ImpresaVisuraCollection ImpresaVisuraCollectionTemp = ImpresaVisuraDAL.FindVisureImpresa(_dbProviderObj, IdimpresaEqualThis);
            ImpresaVisuraCollectionTemp.Provider = this;
            return ImpresaVisuraCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_VISURA>
  <ViewName>VIMPRESA_VISURA</ViewName>
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
    <FindVisureImpresa OrderBy="ORDER BY DATA_VISURA DESC">
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </FindVisureImpresa>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_VISURA>
*/
