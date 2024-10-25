using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ModificaDatiGenerale
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IModificaDatiGeneraleProvider
    {
        int Save(ModificaDatiGenerale ModificaDatiGeneraleObj);
        int SaveCollection(ModificaDatiGeneraleCollection collectionObj);
        int Delete(ModificaDatiGenerale ModificaDatiGeneraleObj);
        int DeleteCollection(ModificaDatiGeneraleCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ModificaDatiGenerale
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ModificaDatiGenerale : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdModifica;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomanda;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.IntNT _IdUtenteModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.IntNT _CodTipoModifica;
        private NullTypes.StringNT _Note;
        private NullTypes.StringNT _IstanzaPrecedente;
        private NullTypes.StringNT _IstanzaNuovo;
        private NullTypes.StringNT _Target;
        private NullTypes.StringNT _TipoModifica;
        private NullTypes.BoolNT _TipoModificaAttivo;
        private NullTypes.StringNT _UtenteModifica;
        private NullTypes.StringNT _CfUtenteModifica;
        [NonSerialized] private IModificaDatiGeneraleProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IModificaDatiGeneraleProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ModificaDatiGenerale()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:ID_DOMANDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomanda
        {
            get { return _IdDomanda; }
            set
            {
                if (IdDomanda != value)
                {
                    _IdDomanda = value;
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
        /// Corrisponde al campo:ID_UTENTE_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtenteModifica
        {
            get { return _IdUtenteModifica; }
            set
            {
                if (IdUtenteModifica != value)
                {
                    _IdUtenteModifica = value;
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
        /// Corrisponde al campo:COD_TIPO_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT CodTipoModifica
        {
            get { return _CodTipoModifica; }
            set
            {
                if (CodTipoModifica != value)
                {
                    _CodTipoModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Note
        {
            get { return _Note; }
            set
            {
                if (Note != value)
                {
                    _Note = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTANZA_PRECEDENTE
        /// Tipo sul db:XML
        /// </summary>
        public NullTypes.StringNT IstanzaPrecedente
        {
            get { return _IstanzaPrecedente; }
            set
            {
                if (IstanzaPrecedente != value)
                {
                    _IstanzaPrecedente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTANZA_NUOVO
        /// Tipo sul db:XML
        /// </summary>
        public NullTypes.StringNT IstanzaNuovo
        {
            get { return _IstanzaNuovo; }
            set
            {
                if (IstanzaNuovo != value)
                {
                    _IstanzaNuovo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TARGET
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Target
        {
            get { return _Target; }
            set
            {
                if (Target != value)
                {
                    _Target = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_MODIFICA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT TipoModifica
        {
            get { return _TipoModifica; }
            set
            {
                if (TipoModifica != value)
                {
                    _TipoModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_MODIFICA_ATTIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT TipoModificaAttivo
        {
            get { return _TipoModificaAttivo; }
            set
            {
                if (TipoModificaAttivo != value)
                {
                    _TipoModificaAttivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:UTENTE_MODIFICA
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT UtenteModifica
        {
            get { return _UtenteModifica; }
            set
            {
                if (UtenteModifica != value)
                {
                    _UtenteModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE_MODIFICA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtenteModifica
        {
            get { return _CfUtenteModifica; }
            set
            {
                if (CfUtenteModifica != value)
                {
                    _CfUtenteModifica = value;
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
    /// Summary description for ModificaDatiGeneraleCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ModificaDatiGeneraleCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ModificaDatiGeneraleCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ModificaDatiGenerale)info.GetValue(i.ToString(), typeof(ModificaDatiGenerale)));
            }
        }

        //Costruttore
        public ModificaDatiGeneraleCollection()
        {
            this.ItemType = typeof(ModificaDatiGenerale);
        }

        //Costruttore con provider
        public ModificaDatiGeneraleCollection(IModificaDatiGeneraleProvider providerObj)
        {
            this.ItemType = typeof(ModificaDatiGenerale);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ModificaDatiGenerale this[int index]
        {
            get { return (ModificaDatiGenerale)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ModificaDatiGeneraleCollection GetChanges()
        {
            return (ModificaDatiGeneraleCollection)base.GetChanges();
        }

        [NonSerialized] private IModificaDatiGeneraleProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IModificaDatiGeneraleProvider Provider
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
        public int Add(ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            if (ModificaDatiGeneraleObj.Provider == null) ModificaDatiGeneraleObj.Provider = this.Provider;
            return base.Add(ModificaDatiGeneraleObj);
        }

        //AddCollection
        public void AddCollection(ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionObj)
        {
            foreach (ModificaDatiGenerale ModificaDatiGeneraleObj in ModificaDatiGeneraleCollectionObj)
                this.Add(ModificaDatiGeneraleObj);
        }

        //Insert
        public void Insert(int index, ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            if (ModificaDatiGeneraleObj.Provider == null) ModificaDatiGeneraleObj.Provider = this.Provider;
            base.Insert(index, ModificaDatiGeneraleObj);
        }

        //CollectionGetById
        public ModificaDatiGenerale CollectionGetById(NullTypes.IntNT IdModificaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdModifica == IdModificaValue))
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
        public ModificaDatiGeneraleCollection SubSelect(NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaEqualThis,
NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdUtenteModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.IntNT CodTipoModificaEqualThis, NullTypes.StringNT NoteEqualThis)
        {
            ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionTemp = new ModificaDatiGeneraleCollection();
            foreach (ModificaDatiGenerale ModificaDatiGeneraleItem in this)
            {
                if (((IdModificaEqualThis == null) || ((ModificaDatiGeneraleItem.IdModifica != null) && (ModificaDatiGeneraleItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ModificaDatiGeneraleItem.IdProgetto != null) && (ModificaDatiGeneraleItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaEqualThis == null) || ((ModificaDatiGeneraleItem.IdDomanda != null) && (ModificaDatiGeneraleItem.IdDomanda.Value == IdDomandaEqualThis.Value))) &&
((IdVarianteEqualThis == null) || ((ModificaDatiGeneraleItem.IdVariante != null) && (ModificaDatiGeneraleItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdUtenteModificaEqualThis == null) || ((ModificaDatiGeneraleItem.IdUtenteModifica != null) && (ModificaDatiGeneraleItem.IdUtenteModifica.Value == IdUtenteModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ModificaDatiGeneraleItem.DataModifica != null) && (ModificaDatiGeneraleItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CodTipoModificaEqualThis == null) || ((ModificaDatiGeneraleItem.CodTipoModifica != null) && (ModificaDatiGeneraleItem.CodTipoModifica.Value == CodTipoModificaEqualThis.Value))) && ((NoteEqualThis == null) || ((ModificaDatiGeneraleItem.Note != null) && (ModificaDatiGeneraleItem.Note.Value == NoteEqualThis.Value))))
                {
                    ModificaDatiGeneraleCollectionTemp.Add(ModificaDatiGeneraleItem);
                }
            }
            return ModificaDatiGeneraleCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ModificaDatiGeneraleDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ModificaDatiGeneraleDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ModificaDatiGenerale ModificaDatiGeneraleObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", ModificaDatiGeneraleObj.IdModifica);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ModificaDatiGeneraleObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomanda", ModificaDatiGeneraleObj.IdDomanda);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", ModificaDatiGeneraleObj.IdVariante);
            DbProvider.SetCmdParam(cmd, firstChar + "IdUtenteModifica", ModificaDatiGeneraleObj.IdUtenteModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ModificaDatiGeneraleObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipoModifica", ModificaDatiGeneraleObj.CodTipoModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", ModificaDatiGeneraleObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "IstanzaPrecedente", ModificaDatiGeneraleObj.IstanzaPrecedente);
            DbProvider.SetCmdParam(cmd, firstChar + "IstanzaNuovo", ModificaDatiGeneraleObj.IstanzaNuovo);
        }
        //Insert
        private static int Insert(DbProvider db, ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZModificaDatiGeneraleInsert", new string[] {"IdProgetto", "IdDomanda",
"IdVariante", "IdUtenteModifica", "DataModifica",
"CodTipoModifica", "Note", "IstanzaPrecedente",
"IstanzaNuovo", }, new string[] {"int", "int",
"int", "int", "DateTime",
"int", "string", "string",
"string", }, "");
                CompileIUCmd(false, insertCmd, ModificaDatiGeneraleObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ModificaDatiGeneraleObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
                    ModificaDatiGeneraleObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ModificaDatiGeneraleObj.IsDirty = false;
                ModificaDatiGeneraleObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZModificaDatiGeneraleUpdate", new string[] {"IdModifica", "IdProgetto", "IdDomanda",
"IdVariante", "IdUtenteModifica", "DataModifica",
"CodTipoModifica", "Note", "IstanzaPrecedente",
"IstanzaNuovo", }, new string[] {"int", "int", "int",
"int", "int", "DateTime",
"int", "string", "string",
"string", }, "");
                CompileIUCmd(true, updateCmd, ModificaDatiGeneraleObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ModificaDatiGeneraleObj.DataModifica = d;
                }
                ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ModificaDatiGeneraleObj.IsDirty = false;
                ModificaDatiGeneraleObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            switch (ModificaDatiGeneraleObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ModificaDatiGeneraleObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ModificaDatiGeneraleObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ModificaDatiGeneraleObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZModificaDatiGeneraleUpdate", new string[] {"IdModifica", "IdProgetto", "IdDomanda",
"IdVariante", "IdUtenteModifica", "DataModifica",
"CodTipoModifica", "Note", "IstanzaPrecedente",
"IstanzaNuovo", }, new string[] {"int", "int", "int",
"int", "int", "DateTime",
"int", "string", "string",
"string", }, "");
                IDbCommand insertCmd = db.InitCmd("ZModificaDatiGeneraleInsert", new string[] {"IdProgetto", "IdDomanda",
"IdVariante", "IdUtenteModifica", "DataModifica",
"CodTipoModifica", "Note", "IstanzaPrecedente",
"IstanzaNuovo", }, new string[] {"int", "int",
"int", "int", "DateTime",
"int", "string", "string",
"string", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZModificaDatiGeneraleDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < ModificaDatiGeneraleCollectionObj.Count; i++)
                {
                    switch (ModificaDatiGeneraleCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ModificaDatiGeneraleCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ModificaDatiGeneraleCollectionObj[i].IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
                                    ModificaDatiGeneraleCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ModificaDatiGeneraleCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ModificaDatiGeneraleCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ModificaDatiGeneraleCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)ModificaDatiGeneraleCollectionObj[i].IdModifica);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ModificaDatiGeneraleCollectionObj.Count; i++)
                {
                    if ((ModificaDatiGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ModificaDatiGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ModificaDatiGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ModificaDatiGeneraleCollectionObj[i].IsDirty = false;
                        ModificaDatiGeneraleCollectionObj[i].IsPersistent = true;
                    }
                    if ((ModificaDatiGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ModificaDatiGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ModificaDatiGeneraleCollectionObj[i].IsDirty = false;
                        ModificaDatiGeneraleCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ModificaDatiGenerale ModificaDatiGeneraleObj)
        {
            int returnValue = 0;
            if (ModificaDatiGeneraleObj.IsPersistent)
            {
                returnValue = Delete(db, ModificaDatiGeneraleObj.IdModifica);
            }
            ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ModificaDatiGeneraleObj.IsDirty = false;
            ModificaDatiGeneraleObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdModificaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZModificaDatiGeneraleDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)IdModificaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZModificaDatiGeneraleDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < ModificaDatiGeneraleCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", ModificaDatiGeneraleCollectionObj[i].IdModifica);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ModificaDatiGeneraleCollectionObj.Count; i++)
                {
                    if ((ModificaDatiGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ModificaDatiGeneraleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ModificaDatiGeneraleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ModificaDatiGeneraleCollectionObj[i].IsDirty = false;
                        ModificaDatiGeneraleCollectionObj[i].IsPersistent = false;
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
        public static ModificaDatiGenerale GetById(DbProvider db, int IdModificaValue)
        {
            ModificaDatiGenerale ModificaDatiGeneraleObj = null;
            IDbCommand readCmd = db.InitCmd("ZModificaDatiGeneraleGetById", new string[] { "IdModifica" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)IdModificaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ModificaDatiGeneraleObj = GetFromDatareader(db);
                ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ModificaDatiGeneraleObj.IsDirty = false;
                ModificaDatiGeneraleObj.IsPersistent = true;
            }
            db.Close();
            return ModificaDatiGeneraleObj;
        }

        //getFromDatareader
        public static ModificaDatiGenerale GetFromDatareader(DbProvider db)
        {
            ModificaDatiGenerale ModificaDatiGeneraleObj = new ModificaDatiGenerale();
            ModificaDatiGeneraleObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            ModificaDatiGeneraleObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ModificaDatiGeneraleObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
            ModificaDatiGeneraleObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            ModificaDatiGeneraleObj.IdUtenteModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_MODIFICA"]);
            ModificaDatiGeneraleObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ModificaDatiGeneraleObj.CodTipoModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_MODIFICA"]);
            ModificaDatiGeneraleObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            ModificaDatiGeneraleObj.IstanzaPrecedente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_PRECEDENTE"]);
            ModificaDatiGeneraleObj.IstanzaNuovo = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_NUOVO"]);
            ModificaDatiGeneraleObj.Target = new SiarLibrary.NullTypes.StringNT(db.DataReader["TARGET"]);
            ModificaDatiGeneraleObj.TipoModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_MODIFICA"]);
            ModificaDatiGeneraleObj.TipoModificaAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TIPO_MODIFICA_ATTIVO"]);
            ModificaDatiGeneraleObj.UtenteModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["UTENTE_MODIFICA"]);
            ModificaDatiGeneraleObj.CfUtenteModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_MODIFICA"]);
            ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ModificaDatiGeneraleObj.IsDirty = false;
            ModificaDatiGeneraleObj.IsPersistent = true;
            return ModificaDatiGeneraleObj;
        }

        //Find Select

        public static ModificaDatiGeneraleCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis,
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.IntNT CodTipoModificaEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis)

        {

            ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionObj = new ModificaDatiGeneraleCollection();

            IDbCommand findCmd = db.InitCmd("Zmodificadatigeneralefindselect", new string[] {"IdModificaequalthis", "IdProgettoequalthis", "IdDomandaequalthis",
"IdVarianteequalthis", "IdUtenteModificaequalthis", "DataModificaequalthis",
"CodTipoModificaequalthis", "Noteequalthis"}, new string[] {"int", "int", "int",
"int", "int", "DateTime",
"int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteModificaequalthis", IdUtenteModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoModificaequalthis", CodTipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            ModificaDatiGenerale ModificaDatiGeneraleObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ModificaDatiGeneraleObj = GetFromDatareader(db);
                ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ModificaDatiGeneraleObj.IsDirty = false;
                ModificaDatiGeneraleObj.IsPersistent = true;
                ModificaDatiGeneraleCollectionObj.Add(ModificaDatiGeneraleObj);
            }
            db.Close();
            return ModificaDatiGeneraleCollectionObj;
        }

        //Find Find

        public static ModificaDatiGeneraleCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis,
SiarLibrary.NullTypes.IntNT CodTipoModificaEqualThis, SiarLibrary.NullTypes.StringNT TipoModificaEqualThis, SiarLibrary.NullTypes.BoolNT TipoModificaAttivoEqualThis)

        {

            ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionObj = new ModificaDatiGeneraleCollection();

            IDbCommand findCmd = db.InitCmd("Zmodificadatigeneralefindfind", new string[] {"IdProgettoequalthis", "IdDomandaequalthis", "IdVarianteequalthis",
"CodTipoModificaequalthis", "TipoModificaequalthis", "TipoModificaAttivoequalthis"}, new string[] {"int", "int", "int",
"int", "string", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoModificaequalthis", CodTipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoModificaequalthis", TipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoModificaAttivoequalthis", TipoModificaAttivoEqualThis);
            ModificaDatiGenerale ModificaDatiGeneraleObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ModificaDatiGeneraleObj = GetFromDatareader(db);
                ModificaDatiGeneraleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ModificaDatiGeneraleObj.IsDirty = false;
                ModificaDatiGeneraleObj.IsPersistent = true;
                ModificaDatiGeneraleCollectionObj.Add(ModificaDatiGeneraleObj);
            }
            db.Close();
            return ModificaDatiGeneraleCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ModificaDatiGeneraleCollectionProvider:IModificaDatiGeneraleProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ModificaDatiGeneraleCollectionProvider : IModificaDatiGeneraleProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ModificaDatiGenerale
        protected ModificaDatiGeneraleCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ModificaDatiGeneraleCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ModificaDatiGeneraleCollection(this);
        }

        //Costruttore 2: popola la collection
        public ModificaDatiGeneraleCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandaEqualThis, IntNT IdvarianteEqualThis,
IntNT CodtipomodificaEqualThis, StringNT TipomodificaEqualThis, BoolNT TipomodificaattivoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdprogettoEqualThis, IddomandaEqualThis, IdvarianteEqualThis,
CodtipomodificaEqualThis, TipomodificaEqualThis, TipomodificaattivoEqualThis);
        }

        //Costruttore3: ha in input modificadatigeneraleCollectionObj - non popola la collection
        public ModificaDatiGeneraleCollectionProvider(ModificaDatiGeneraleCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ModificaDatiGeneraleCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ModificaDatiGeneraleCollection(this);
        }

        //Get e Set
        public ModificaDatiGeneraleCollection CollectionObj
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
        public int SaveCollection(ModificaDatiGeneraleCollection collectionObj)
        {
            return ModificaDatiGeneraleDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ModificaDatiGenerale modificadatigeneraleObj)
        {
            return ModificaDatiGeneraleDAL.Save(_dbProviderObj, modificadatigeneraleObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ModificaDatiGeneraleCollection collectionObj)
        {
            return ModificaDatiGeneraleDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ModificaDatiGenerale modificadatigeneraleObj)
        {
            return ModificaDatiGeneraleDAL.Delete(_dbProviderObj, modificadatigeneraleObj);
        }

        //getById
        public ModificaDatiGenerale GetById(IntNT IdModificaValue)
        {
            ModificaDatiGenerale ModificaDatiGeneraleTemp = ModificaDatiGeneraleDAL.GetById(_dbProviderObj, IdModificaValue);
            if (ModificaDatiGeneraleTemp != null) ModificaDatiGeneraleTemp.Provider = this;
            return ModificaDatiGeneraleTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ModificaDatiGeneraleCollection Select(IntNT IdmodificaEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandaEqualThis,
IntNT IdvarianteEqualThis, IntNT IdutentemodificaEqualThis, DatetimeNT DatamodificaEqualThis,
IntNT CodtipomodificaEqualThis, StringNT NoteEqualThis)
        {
            ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionTemp = ModificaDatiGeneraleDAL.Select(_dbProviderObj, IdmodificaEqualThis, IdprogettoEqualThis, IddomandaEqualThis,
IdvarianteEqualThis, IdutentemodificaEqualThis, DatamodificaEqualThis,
CodtipomodificaEqualThis, NoteEqualThis);
            ModificaDatiGeneraleCollectionTemp.Provider = this;
            return ModificaDatiGeneraleCollectionTemp;
        }

        //Find: popola la collection
        public ModificaDatiGeneraleCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandaEqualThis, IntNT IdvarianteEqualThis,
IntNT CodtipomodificaEqualThis, StringNT TipomodificaEqualThis, BoolNT TipomodificaattivoEqualThis)
        {
            ModificaDatiGeneraleCollection ModificaDatiGeneraleCollectionTemp = ModificaDatiGeneraleDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandaEqualThis, IdvarianteEqualThis,
CodtipomodificaEqualThis, TipomodificaEqualThis, TipomodificaattivoEqualThis);
            ModificaDatiGeneraleCollectionTemp.Provider = this;
            return ModificaDatiGeneraleCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<MODIFICA_DATI_GENERALE>
  <ViewName>VMODIFICA_DATI_GENERALE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA ASC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO_MODIFICA>Equal</COD_TIPO_MODIFICA>
      <TIPO_MODIFICA>Equal</TIPO_MODIFICA>
      <TIPO_MODIFICA_ATTIVO>Equal</TIPO_MODIFICA_ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</MODIFICA_DATI_GENERALE>
*/
