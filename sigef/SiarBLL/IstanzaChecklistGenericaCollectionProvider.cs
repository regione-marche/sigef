using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per IstanzaChecklistGenerica
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IIstanzaChecklistGenericaProvider
    {
        int Save(IstanzaChecklistGenerica IstanzaChecklistGenericaObj);
        int SaveCollection(IstanzaChecklistGenericaCollection collectionObj);
        int Delete(IstanzaChecklistGenerica IstanzaChecklistGenericaObj);
        int DeleteCollection(IstanzaChecklistGenericaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for IstanzaChecklistGenerica
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class IstanzaChecklistGenerica : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdIstanzaGenerica;
        private NullTypes.IntNT _IdChecklistGenerica;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.BoolNT _FlagTemplate;
        private NullTypes.StringNT _CodFase;
        private NullTypes.IntNT _IdChecklistPadre;
        private NullTypes.IntNT _IdSchedaXChecklist;
        [NonSerialized] private IIstanzaChecklistGenericaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IIstanzaChecklistGenericaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public IstanzaChecklistGenerica()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_ISTANZA_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIstanzaGenerica
        {
            get { return _IdIstanzaGenerica; }
            set
            {
                if (IdIstanzaGenerica != value)
                {
                    _IdIstanzaGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdChecklistGenerica
        {
            get { return _IdChecklistGenerica; }
            set
            {
                if (IdChecklistGenerica != value)
                {
                    _IdChecklistGenerica = value;
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
        /// Corrisponde al campo:CF_INSERIMENTO
        /// Tipo sul db:CHAR(16)
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
        /// Default:(getdate())
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
        /// Tipo sul db:CHAR(16)
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
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                if (Descrizione != value)
                {
                    _Descrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG_TEMPLATE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FlagTemplate
        {
            get { return _FlagTemplate; }
            set
            {
                if (FlagTemplate != value)
                {
                    _FlagTemplate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_FASE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodFase
        {
            get { return _CodFase; }
            set
            {
                if (CodFase != value)
                {
                    _CodFase = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CHECKLIST_PADRE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdChecklistPadre
        {
            get { return _IdChecklistPadre; }
            set
            {
                if (IdChecklistPadre != value)
                {
                    _IdChecklistPadre = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_SCHEDA_X_CHECKLIST
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSchedaXChecklist
        {
            get { return _IdSchedaXChecklist; }
            set
            {
                if (IdSchedaXChecklist != value)
                {
                    _IdSchedaXChecklist = value;
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
    /// Summary description for IstanzaChecklistGenericaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class IstanzaChecklistGenericaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private IstanzaChecklistGenericaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((IstanzaChecklistGenerica)info.GetValue(i.ToString(), typeof(IstanzaChecklistGenerica)));
            }
        }

        //Costruttore
        public IstanzaChecklistGenericaCollection()
        {
            this.ItemType = typeof(IstanzaChecklistGenerica);
        }

        //Costruttore con provider
        public IstanzaChecklistGenericaCollection(IIstanzaChecklistGenericaProvider providerObj)
        {
            this.ItemType = typeof(IstanzaChecklistGenerica);
            this.Provider = providerObj;
        }

        //Get e Set
        public new IstanzaChecklistGenerica this[int index]
        {
            get { return (IstanzaChecklistGenerica)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new IstanzaChecklistGenericaCollection GetChanges()
        {
            return (IstanzaChecklistGenericaCollection)base.GetChanges();
        }

        [NonSerialized] private IIstanzaChecklistGenericaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IIstanzaChecklistGenericaProvider Provider
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
        public int Add(IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            if (IstanzaChecklistGenericaObj.Provider == null) IstanzaChecklistGenericaObj.Provider = this.Provider;
            return base.Add(IstanzaChecklistGenericaObj);
        }

        //AddCollection
        public void AddCollection(IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionObj)
        {
            foreach (IstanzaChecklistGenerica IstanzaChecklistGenericaObj in IstanzaChecklistGenericaCollectionObj)
                this.Add(IstanzaChecklistGenericaObj);
        }

        //Insert
        public void Insert(int index, IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            if (IstanzaChecklistGenericaObj.Provider == null) IstanzaChecklistGenericaObj.Provider = this.Provider;
            base.Insert(index, IstanzaChecklistGenericaObj);
        }

        //CollectionGetById
        public IstanzaChecklistGenerica CollectionGetById(NullTypes.IntNT IdIstanzaGenericaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdIstanzaGenerica == IdIstanzaGenericaValue))
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
        public IstanzaChecklistGenericaCollection SubSelect(NullTypes.IntNT IdIstanzaGenericaEqualThis, NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.StringNT CodFaseEqualThis, NullTypes.IntNT IdChecklistPadreEqualThis, NullTypes.IntNT IdSchedaXChecklistEqualThis)
        {
            IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionTemp = new IstanzaChecklistGenericaCollection();
            foreach (IstanzaChecklistGenerica IstanzaChecklistGenericaItem in this)
            {
                if (((IdIstanzaGenericaEqualThis == null) || ((IstanzaChecklistGenericaItem.IdIstanzaGenerica != null) && (IstanzaChecklistGenericaItem.IdIstanzaGenerica.Value == IdIstanzaGenericaEqualThis.Value))) && ((IdChecklistGenericaEqualThis == null) || ((IstanzaChecklistGenericaItem.IdChecklistGenerica != null) && (IstanzaChecklistGenericaItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((IstanzaChecklistGenericaItem.DataInserimento != null) && (IstanzaChecklistGenericaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((IstanzaChecklistGenericaItem.CfInserimento != null) && (IstanzaChecklistGenericaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((IstanzaChecklistGenericaItem.DataModifica != null) && (IstanzaChecklistGenericaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((IstanzaChecklistGenericaItem.CfModifica != null) && (IstanzaChecklistGenericaItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((CodFaseEqualThis == null) || ((IstanzaChecklistGenericaItem.CodFase != null) && (IstanzaChecklistGenericaItem.CodFase.Value == CodFaseEqualThis.Value))) && ((IdChecklistPadreEqualThis == null) || ((IstanzaChecklistGenericaItem.IdChecklistPadre != null) && (IstanzaChecklistGenericaItem.IdChecklistPadre.Value == IdChecklistPadreEqualThis.Value))) && ((IdSchedaXChecklistEqualThis == null) || ((IstanzaChecklistGenericaItem.IdSchedaXChecklist != null) && (IstanzaChecklistGenericaItem.IdSchedaXChecklist.Value == IdSchedaXChecklistEqualThis.Value))))
                {
                    IstanzaChecklistGenericaCollectionTemp.Add(IstanzaChecklistGenericaItem);
                }
            }
            return IstanzaChecklistGenericaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for IstanzaChecklistGenericaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class IstanzaChecklistGenericaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IstanzaChecklistGenerica IstanzaChecklistGenericaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdIstanzaGenerica", IstanzaChecklistGenericaObj.IdIstanzaGenerica);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistGenerica", IstanzaChecklistGenericaObj.IdChecklistGenerica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", IstanzaChecklistGenericaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", IstanzaChecklistGenericaObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", IstanzaChecklistGenericaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", IstanzaChecklistGenericaObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CodFase", IstanzaChecklistGenericaObj.CodFase);
            DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistPadre", IstanzaChecklistGenericaObj.IdChecklistPadre);
            DbProvider.SetCmdParam(cmd, firstChar + "IdSchedaXChecklist", IstanzaChecklistGenericaObj.IdSchedaXChecklist);
        }
        //Insert
        private static int Insert(DbProvider db, IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZIstanzaChecklistGenericaInsert", new string[] {"IdChecklistGenerica", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"CodFase",
"IdChecklistPadre", "IdSchedaXChecklist"}, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"string",
"int", "int"}, "");
                CompileIUCmd(false, insertCmd, IstanzaChecklistGenericaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    IstanzaChecklistGenericaObj.IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
                    IstanzaChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    IstanzaChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IstanzaChecklistGenericaObj.IsDirty = false;
                IstanzaChecklistGenericaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZIstanzaChecklistGenericaUpdate", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"CodFase",
"IdChecklistPadre", "IdSchedaXChecklist"}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"string",
"int", "int"}, "");
                CompileIUCmd(true, updateCmd, IstanzaChecklistGenericaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    IstanzaChecklistGenericaObj.DataModifica = d;
                }
                IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IstanzaChecklistGenericaObj.IsDirty = false;
                IstanzaChecklistGenericaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            switch (IstanzaChecklistGenericaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, IstanzaChecklistGenericaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, IstanzaChecklistGenericaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, IstanzaChecklistGenericaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZIstanzaChecklistGenericaUpdate", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"CodFase",
"IdChecklistPadre", "IdSchedaXChecklist"}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"string",
"int", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZIstanzaChecklistGenericaInsert", new string[] {"IdChecklistGenerica", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"CodFase",
"IdChecklistPadre", "IdSchedaXChecklist"}, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"string",
"int", "int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZIstanzaChecklistGenericaDelete", new string[] { "IdIstanzaGenerica" }, new string[] { "int" }, "");
                for (int i = 0; i < IstanzaChecklistGenericaCollectionObj.Count; i++)
                {
                    switch (IstanzaChecklistGenericaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, IstanzaChecklistGenericaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    IstanzaChecklistGenericaCollectionObj[i].IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
                                    IstanzaChecklistGenericaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    IstanzaChecklistGenericaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, IstanzaChecklistGenericaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    IstanzaChecklistGenericaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (IstanzaChecklistGenericaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIstanzaGenerica", (SiarLibrary.NullTypes.IntNT)IstanzaChecklistGenericaCollectionObj[i].IdIstanzaGenerica);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < IstanzaChecklistGenericaCollectionObj.Count; i++)
                {
                    if ((IstanzaChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IstanzaChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        IstanzaChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        IstanzaChecklistGenericaCollectionObj[i].IsDirty = false;
                        IstanzaChecklistGenericaCollectionObj[i].IsPersistent = true;
                    }
                    if ((IstanzaChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        IstanzaChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        IstanzaChecklistGenericaCollectionObj[i].IsDirty = false;
                        IstanzaChecklistGenericaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, IstanzaChecklistGenerica IstanzaChecklistGenericaObj)
        {
            int returnValue = 0;
            if (IstanzaChecklistGenericaObj.IsPersistent)
            {
                returnValue = Delete(db, IstanzaChecklistGenericaObj.IdIstanzaGenerica);
            }
            IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            IstanzaChecklistGenericaObj.IsDirty = false;
            IstanzaChecklistGenericaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdIstanzaGenericaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZIstanzaChecklistGenericaDelete", new string[] { "IdIstanzaGenerica" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIstanzaGenerica", (SiarLibrary.NullTypes.IntNT)IdIstanzaGenericaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZIstanzaChecklistGenericaDelete", new string[] { "IdIstanzaGenerica" }, new string[] { "int" }, "");
                for (int i = 0; i < IstanzaChecklistGenericaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIstanzaGenerica", IstanzaChecklistGenericaCollectionObj[i].IdIstanzaGenerica);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < IstanzaChecklistGenericaCollectionObj.Count; i++)
                {
                    if ((IstanzaChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IstanzaChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        IstanzaChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        IstanzaChecklistGenericaCollectionObj[i].IsDirty = false;
                        IstanzaChecklistGenericaCollectionObj[i].IsPersistent = false;
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
        public static IstanzaChecklistGenerica GetById(DbProvider db, int IdIstanzaGenericaValue)
        {
            IstanzaChecklistGenerica IstanzaChecklistGenericaObj = null;
            IDbCommand readCmd = db.InitCmd("ZIstanzaChecklistGenericaGetById", new string[] { "IdIstanzaGenerica" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdIstanzaGenerica", (SiarLibrary.NullTypes.IntNT)IdIstanzaGenericaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                IstanzaChecklistGenericaObj = GetFromDatareader(db);
                IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IstanzaChecklistGenericaObj.IsDirty = false;
                IstanzaChecklistGenericaObj.IsPersistent = true;
            }
            db.Close();
            return IstanzaChecklistGenericaObj;
        }

        //getFromDatareader
        public static IstanzaChecklistGenerica GetFromDatareader(DbProvider db)
        {
            IstanzaChecklistGenerica IstanzaChecklistGenericaObj = new IstanzaChecklistGenerica();
            IstanzaChecklistGenericaObj.IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
            IstanzaChecklistGenericaObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
            IstanzaChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            IstanzaChecklistGenericaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            IstanzaChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            IstanzaChecklistGenericaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            IstanzaChecklistGenericaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            IstanzaChecklistGenericaObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
            IstanzaChecklistGenericaObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
            IstanzaChecklistGenericaObj.IdChecklistPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_PADRE"]);
            IstanzaChecklistGenericaObj.IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
            IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            IstanzaChecklistGenericaObj.IsDirty = false;
            IstanzaChecklistGenericaObj.IsPersistent = true;
            return IstanzaChecklistGenericaObj;
        }

        //Find Select

        public static IstanzaChecklistGenericaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis)

        {

            IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionObj = new IstanzaChecklistGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Zistanzachecklistgenericafindselect", new string[] {"IdIstanzaGenericaequalthis", "IdChecklistGenericaequalthis", "DataInserimentoequalthis",
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis",
"CodFaseequalthis", "IdChecklistPadreequalthis", "IdSchedaXChecklistequalthis"}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"string", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
            IstanzaChecklistGenerica IstanzaChecklistGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                IstanzaChecklistGenericaObj = GetFromDatareader(db);
                IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IstanzaChecklistGenericaObj.IsDirty = false;
                IstanzaChecklistGenericaObj.IsPersistent = true;
                IstanzaChecklistGenericaCollectionObj.Add(IstanzaChecklistGenericaObj);
            }
            db.Close();
            return IstanzaChecklistGenericaCollectionObj;
        }

        //Find Find

        public static IstanzaChecklistGenericaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis,
SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis)

        {

            IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionObj = new IstanzaChecklistGenericaCollection();

            IDbCommand findCmd = db.InitCmd("Zistanzachecklistgenericafindfind", new string[] {"IdIstanzaGenericaequalthis", "IdChecklistGenericaequalthis", "CodFaseequalthis",
"IdChecklistPadreequalthis", "IdSchedaXChecklistequalthis"}, new string[] {"int", "int", "string",
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
            IstanzaChecklistGenerica IstanzaChecklistGenericaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                IstanzaChecklistGenericaObj = GetFromDatareader(db);
                IstanzaChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IstanzaChecklistGenericaObj.IsDirty = false;
                IstanzaChecklistGenericaObj.IsPersistent = true;
                IstanzaChecklistGenericaCollectionObj.Add(IstanzaChecklistGenericaObj);
            }
            db.Close();
            return IstanzaChecklistGenericaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for IstanzaChecklistGenericaCollectionProvider:IIstanzaChecklistGenericaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class IstanzaChecklistGenericaCollectionProvider : IIstanzaChecklistGenericaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di IstanzaChecklistGenerica
        protected IstanzaChecklistGenericaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public IstanzaChecklistGenericaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new IstanzaChecklistGenericaCollection(this);
        }

        //Costruttore 2: popola la collection
        public IstanzaChecklistGenericaCollectionProvider(IntNT IdistanzagenericaEqualThis, IntNT IdchecklistgenericaEqualThis, StringNT CodfaseEqualThis,
IntNT IdchecklistpadreEqualThis, IntNT IdschedaxchecklistEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdistanzagenericaEqualThis, IdchecklistgenericaEqualThis, CodfaseEqualThis,
IdchecklistpadreEqualThis, IdschedaxchecklistEqualThis);
        }

        //Costruttore3: ha in input istanzachecklistgenericaCollectionObj - non popola la collection
        public IstanzaChecklistGenericaCollectionProvider(IstanzaChecklistGenericaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public IstanzaChecklistGenericaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new IstanzaChecklistGenericaCollection(this);
        }

        //Get e Set
        public IstanzaChecklistGenericaCollection CollectionObj
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
        public int SaveCollection(IstanzaChecklistGenericaCollection collectionObj)
        {
            return IstanzaChecklistGenericaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(IstanzaChecklistGenerica istanzachecklistgenericaObj)
        {
            return IstanzaChecklistGenericaDAL.Save(_dbProviderObj, istanzachecklistgenericaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(IstanzaChecklistGenericaCollection collectionObj)
        {
            return IstanzaChecklistGenericaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(IstanzaChecklistGenerica istanzachecklistgenericaObj)
        {
            return IstanzaChecklistGenericaDAL.Delete(_dbProviderObj, istanzachecklistgenericaObj);
        }

        //getById
        public IstanzaChecklistGenerica GetById(IntNT IdIstanzaGenericaValue)
        {
            IstanzaChecklistGenerica IstanzaChecklistGenericaTemp = IstanzaChecklistGenericaDAL.GetById(_dbProviderObj, IdIstanzaGenericaValue);
            if (IstanzaChecklistGenericaTemp != null) IstanzaChecklistGenericaTemp.Provider = this;
            return IstanzaChecklistGenericaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public IstanzaChecklistGenericaCollection Select(IntNT IdistanzagenericaEqualThis, IntNT IdchecklistgenericaEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis,
StringNT CodfaseEqualThis, IntNT IdchecklistpadreEqualThis, IntNT IdschedaxchecklistEqualThis)
        {
            IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionTemp = IstanzaChecklistGenericaDAL.Select(_dbProviderObj, IdistanzagenericaEqualThis, IdchecklistgenericaEqualThis, DatainserimentoEqualThis,
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis,
CodfaseEqualThis, IdchecklistpadreEqualThis, IdschedaxchecklistEqualThis);
            IstanzaChecklistGenericaCollectionTemp.Provider = this;
            return IstanzaChecklistGenericaCollectionTemp;
        }

        //Find: popola la collection
        public IstanzaChecklistGenericaCollection Find(IntNT IdistanzagenericaEqualThis, IntNT IdchecklistgenericaEqualThis, StringNT CodfaseEqualThis,
IntNT IdchecklistpadreEqualThis, IntNT IdschedaxchecklistEqualThis)
        {
            IstanzaChecklistGenericaCollection IstanzaChecklistGenericaCollectionTemp = IstanzaChecklistGenericaDAL.Find(_dbProviderObj, IdistanzagenericaEqualThis, IdchecklistgenericaEqualThis, CodfaseEqualThis,
IdchecklistpadreEqualThis, IdschedaxchecklistEqualThis);
            IstanzaChecklistGenericaCollectionTemp.Provider = this;
            return IstanzaChecklistGenericaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ISTANZA_CHECKLIST_GENERICA>
  <ViewName>VISTANZA_CHECKLIST_GENERICA</ViewName>
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
      <ID_ISTANZA_GENERICA>Equal</ID_ISTANZA_GENERICA>
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <COD_FASE>Equal</COD_FASE>
      <ID_CHECKLIST_PADRE>Equal</ID_CHECKLIST_PADRE>
      <ID_SCHEDA_X_CHECKLIST>Equal</ID_SCHEDA_X_CHECKLIST>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ISTANZA_CHECKLIST_GENERICA>
*/
