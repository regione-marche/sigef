using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per RegistroModificheAutorizzate
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IRegistroModificheAutorizzateProvider
    {
        int Save(RegistroModificheAutorizzate RegistroModificheAutorizzateObj);
        int SaveCollection(RegistroModificheAutorizzateCollection collectionObj);
        int Delete(RegistroModificheAutorizzate RegistroModificheAutorizzateObj);
        int DeleteCollection(RegistroModificheAutorizzateCollection collectionObj);
    }
    /// <summary>
    /// Summary description for RegistroModificheAutorizzate
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class RegistroModificheAutorizzate : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdModifica;
        private NullTypes.IntNT _OperatoreInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.IntNT _IdTipoModifica;
        private NullTypes.StringNT _RiferimentoPass;
        private NullTypes.StringNT _SegnaturaRichiesta;
        private NullTypes.IntNT _IdRiferimentoPrincipale;
        private NullTypes.BoolNT _IgnoraControlli;
        private NullTypes.StringNT _Note;
        private NullTypes.StringNT _Esito;
        private NullTypes.StringNT _DescrizioneModifica;
        private NullTypes.StringNT _OperatoreInserimentoNominativo;
        [NonSerialized] private IRegistroModificheAutorizzateProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroModificheAutorizzateProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public RegistroModificheAutorizzate()
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
        /// Corrisponde al campo:OPERATORE_INSERIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreInserimento
        {
            get { return _OperatoreInserimento; }
            set
            {
                if (OperatoreInserimento != value)
                {
                    _OperatoreInserimento = value;
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
        /// Corrisponde al campo:ID_TIPO_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoModifica
        {
            get { return _IdTipoModifica; }
            set
            {
                if (IdTipoModifica != value)
                {
                    _IdTipoModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RIFERIMENTO_PASS
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT RiferimentoPass
        {
            get { return _RiferimentoPass; }
            set
            {
                if (RiferimentoPass != value)
                {
                    _RiferimentoPass = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_RICHIESTA
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT SegnaturaRichiesta
        {
            get { return _SegnaturaRichiesta; }
            set
            {
                if (SegnaturaRichiesta != value)
                {
                    _SegnaturaRichiesta = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_RIFERIMENTO_PRINCIPALE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRiferimentoPrincipale
        {
            get { return _IdRiferimentoPrincipale; }
            set
            {
                if (IdRiferimentoPrincipale != value)
                {
                    _IdRiferimentoPrincipale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IGNORA_CONTROLLI
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IgnoraControlli
        {
            get { return _IgnoraControlli; }
            set
            {
                if (IgnoraControlli != value)
                {
                    _IgnoraControlli = value;
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
        /// Corrisponde al campo:ESITO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Esito
        {
            get { return _Esito; }
            set
            {
                if (Esito != value)
                {
                    _Esito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_MODIFICA
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT DescrizioneModifica
        {
            get { return _DescrizioneModifica; }
            set
            {
                if (DescrizioneModifica != value)
                {
                    _DescrizioneModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_INSERIMENTO_NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT OperatoreInserimentoNominativo
        {
            get { return _OperatoreInserimentoNominativo; }
            set
            {
                if (OperatoreInserimentoNominativo != value)
                {
                    _OperatoreInserimentoNominativo = value;
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
    /// Summary description for RegistroModificheAutorizzateCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroModificheAutorizzateCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private RegistroModificheAutorizzateCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((RegistroModificheAutorizzate)info.GetValue(i.ToString(), typeof(RegistroModificheAutorizzate)));
            }
        }

        //Costruttore
        public RegistroModificheAutorizzateCollection()
        {
            this.ItemType = typeof(RegistroModificheAutorizzate);
        }

        //Costruttore con provider
        public RegistroModificheAutorizzateCollection(IRegistroModificheAutorizzateProvider providerObj)
        {
            this.ItemType = typeof(RegistroModificheAutorizzate);
            this.Provider = providerObj;
        }

        //Get e Set
        public new RegistroModificheAutorizzate this[int index]
        {
            get { return (RegistroModificheAutorizzate)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new RegistroModificheAutorizzateCollection GetChanges()
        {
            return (RegistroModificheAutorizzateCollection)base.GetChanges();
        }

        [NonSerialized] private IRegistroModificheAutorizzateProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroModificheAutorizzateProvider Provider
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
        public int Add(RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            if (RegistroModificheAutorizzateObj.Provider == null) RegistroModificheAutorizzateObj.Provider = this.Provider;
            return base.Add(RegistroModificheAutorizzateObj);
        }

        //AddCollection
        public void AddCollection(RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionObj)
        {
            foreach (RegistroModificheAutorizzate RegistroModificheAutorizzateObj in RegistroModificheAutorizzateCollectionObj)
                this.Add(RegistroModificheAutorizzateObj);
        }

        //Insert
        public void Insert(int index, RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            if (RegistroModificheAutorizzateObj.Provider == null) RegistroModificheAutorizzateObj.Provider = this.Provider;
            base.Insert(index, RegistroModificheAutorizzateObj);
        }

        //CollectionGetById
        public RegistroModificheAutorizzate CollectionGetById(NullTypes.IntNT IdModificaValue)
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
        public RegistroModificheAutorizzateCollection SubSelect(NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.IntNT IdTipoModificaEqualThis, NullTypes.StringNT RiferimentoPassEqualThis, NullTypes.StringNT SegnaturaRichiestaEqualThis,
NullTypes.IntNT IdRiferimentoPrincipaleEqualThis, NullTypes.BoolNT IgnoraControlliEqualThis, NullTypes.StringNT NoteEqualThis,
NullTypes.StringNT EsitoEqualThis)
        {
            RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionTemp = new RegistroModificheAutorizzateCollection();
            foreach (RegistroModificheAutorizzate RegistroModificheAutorizzateItem in this)
            {
                if (((IdModificaEqualThis == null) || ((RegistroModificheAutorizzateItem.IdModifica != null) && (RegistroModificheAutorizzateItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((RegistroModificheAutorizzateItem.OperatoreInserimento != null) && (RegistroModificheAutorizzateItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RegistroModificheAutorizzateItem.DataInserimento != null) && (RegistroModificheAutorizzateItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((IdTipoModificaEqualThis == null) || ((RegistroModificheAutorizzateItem.IdTipoModifica != null) && (RegistroModificheAutorizzateItem.IdTipoModifica.Value == IdTipoModificaEqualThis.Value))) && ((RiferimentoPassEqualThis == null) || ((RegistroModificheAutorizzateItem.RiferimentoPass != null) && (RegistroModificheAutorizzateItem.RiferimentoPass.Value == RiferimentoPassEqualThis.Value))) && ((SegnaturaRichiestaEqualThis == null) || ((RegistroModificheAutorizzateItem.SegnaturaRichiesta != null) && (RegistroModificheAutorizzateItem.SegnaturaRichiesta.Value == SegnaturaRichiestaEqualThis.Value))) &&
((IdRiferimentoPrincipaleEqualThis == null) || ((RegistroModificheAutorizzateItem.IdRiferimentoPrincipale != null) && (RegistroModificheAutorizzateItem.IdRiferimentoPrincipale.Value == IdRiferimentoPrincipaleEqualThis.Value))) && ((IgnoraControlliEqualThis == null) || ((RegistroModificheAutorizzateItem.IgnoraControlli != null) && (RegistroModificheAutorizzateItem.IgnoraControlli.Value == IgnoraControlliEqualThis.Value))) && ((NoteEqualThis == null) || ((RegistroModificheAutorizzateItem.Note != null) && (RegistroModificheAutorizzateItem.Note.Value == NoteEqualThis.Value))) &&
((EsitoEqualThis == null) || ((RegistroModificheAutorizzateItem.Esito != null) && (RegistroModificheAutorizzateItem.Esito.Value == EsitoEqualThis.Value))))
                {
                    RegistroModificheAutorizzateCollectionTemp.Add(RegistroModificheAutorizzateItem);
                }
            }
            return RegistroModificheAutorizzateCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for RegistroModificheAutorizzateDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class RegistroModificheAutorizzateDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RegistroModificheAutorizzate RegistroModificheAutorizzateObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", RegistroModificheAutorizzateObj.IdModifica);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", RegistroModificheAutorizzateObj.OperatoreInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", RegistroModificheAutorizzateObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoModifica", RegistroModificheAutorizzateObj.IdTipoModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "RiferimentoPass", RegistroModificheAutorizzateObj.RiferimentoPass);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaRichiesta", RegistroModificheAutorizzateObj.SegnaturaRichiesta);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRiferimentoPrincipale", RegistroModificheAutorizzateObj.IdRiferimentoPrincipale);
            DbProvider.SetCmdParam(cmd, firstChar + "IgnoraControlli", RegistroModificheAutorizzateObj.IgnoraControlli);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", RegistroModificheAutorizzateObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "Esito", RegistroModificheAutorizzateObj.Esito);
        }
        //Insert
        private static int Insert(DbProvider db, RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZRegistroModificheAutorizzateInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"IdTipoModifica", "RiferimentoPass", "SegnaturaRichiesta",
"IdRiferimentoPrincipale", "IgnoraControlli", "Note",
"Esito"}, new string[] {"int", "DateTime",
"int", "string", "string",
"int", "bool", "string",
"string"}, "");
                CompileIUCmd(false, insertCmd, RegistroModificheAutorizzateObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    RegistroModificheAutorizzateObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
                }
                RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroModificheAutorizzateObj.IsDirty = false;
                RegistroModificheAutorizzateObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroModificheAutorizzateUpdate", new string[] {"IdModifica", "OperatoreInserimento", "DataInserimento",
"IdTipoModifica", "RiferimentoPass", "SegnaturaRichiesta",
"IdRiferimentoPrincipale", "IgnoraControlli", "Note",
"Esito"}, new string[] {"int", "int", "DateTime",
"int", "string", "string",
"int", "bool", "string",
"string"}, "");
                CompileIUCmd(true, updateCmd, RegistroModificheAutorizzateObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroModificheAutorizzateObj.IsDirty = false;
                RegistroModificheAutorizzateObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            switch (RegistroModificheAutorizzateObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, RegistroModificheAutorizzateObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, RegistroModificheAutorizzateObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, RegistroModificheAutorizzateObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroModificheAutorizzateUpdate", new string[] {"IdModifica", "OperatoreInserimento", "DataInserimento",
"IdTipoModifica", "RiferimentoPass", "SegnaturaRichiesta",
"IdRiferimentoPrincipale", "IgnoraControlli", "Note",
"Esito"}, new string[] {"int", "int", "DateTime",
"int", "string", "string",
"int", "bool", "string",
"string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZRegistroModificheAutorizzateInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"IdTipoModifica", "RiferimentoPass", "SegnaturaRichiesta",
"IdRiferimentoPrincipale", "IgnoraControlli", "Note",
"Esito"}, new string[] {"int", "DateTime",
"int", "string", "string",
"int", "bool", "string",
"string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZRegistroModificheAutorizzateDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroModificheAutorizzateCollectionObj.Count; i++)
                {
                    switch (RegistroModificheAutorizzateCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, RegistroModificheAutorizzateCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    RegistroModificheAutorizzateCollectionObj[i].IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, RegistroModificheAutorizzateCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (RegistroModificheAutorizzateCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)RegistroModificheAutorizzateCollectionObj[i].IdModifica);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < RegistroModificheAutorizzateCollectionObj.Count; i++)
                {
                    if ((RegistroModificheAutorizzateCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroModificheAutorizzateCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroModificheAutorizzateCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        RegistroModificheAutorizzateCollectionObj[i].IsDirty = false;
                        RegistroModificheAutorizzateCollectionObj[i].IsPersistent = true;
                    }
                    if ((RegistroModificheAutorizzateCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        RegistroModificheAutorizzateCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroModificheAutorizzateCollectionObj[i].IsDirty = false;
                        RegistroModificheAutorizzateCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, RegistroModificheAutorizzate RegistroModificheAutorizzateObj)
        {
            int returnValue = 0;
            if (RegistroModificheAutorizzateObj.IsPersistent)
            {
                returnValue = Delete(db, RegistroModificheAutorizzateObj.IdModifica);
            }
            RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            RegistroModificheAutorizzateObj.IsDirty = false;
            RegistroModificheAutorizzateObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdModificaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroModificheAutorizzateDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)IdModificaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroModificheAutorizzateDelete", new string[] { "IdModifica" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroModificheAutorizzateCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdModifica", RegistroModificheAutorizzateCollectionObj[i].IdModifica);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < RegistroModificheAutorizzateCollectionObj.Count; i++)
                {
                    if ((RegistroModificheAutorizzateCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroModificheAutorizzateCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroModificheAutorizzateCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroModificheAutorizzateCollectionObj[i].IsDirty = false;
                        RegistroModificheAutorizzateCollectionObj[i].IsPersistent = false;
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
        public static RegistroModificheAutorizzate GetById(DbProvider db, int IdModificaValue)
        {
            RegistroModificheAutorizzate RegistroModificheAutorizzateObj = null;
            IDbCommand readCmd = db.InitCmd("ZRegistroModificheAutorizzateGetById", new string[] { "IdModifica" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdModifica", (SiarLibrary.NullTypes.IntNT)IdModificaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                RegistroModificheAutorizzateObj = GetFromDatareader(db);
                RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroModificheAutorizzateObj.IsDirty = false;
                RegistroModificheAutorizzateObj.IsPersistent = true;
            }
            db.Close();
            return RegistroModificheAutorizzateObj;
        }

        //getFromDatareader
        public static RegistroModificheAutorizzate GetFromDatareader(DbProvider db)
        {
            RegistroModificheAutorizzate RegistroModificheAutorizzateObj = new RegistroModificheAutorizzate();
            RegistroModificheAutorizzateObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            RegistroModificheAutorizzateObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
            RegistroModificheAutorizzateObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            RegistroModificheAutorizzateObj.IdTipoModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_MODIFICA"]);
            RegistroModificheAutorizzateObj.RiferimentoPass = new SiarLibrary.NullTypes.StringNT(db.DataReader["RIFERIMENTO_PASS"]);
            RegistroModificheAutorizzateObj.SegnaturaRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RICHIESTA"]);
            RegistroModificheAutorizzateObj.IdRiferimentoPrincipale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RIFERIMENTO_PRINCIPALE"]);
            RegistroModificheAutorizzateObj.IgnoraControlli = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IGNORA_CONTROLLI"]);
            RegistroModificheAutorizzateObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            RegistroModificheAutorizzateObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
            RegistroModificheAutorizzateObj.DescrizioneModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_MODIFICA"]);
            RegistroModificheAutorizzateObj.OperatoreInserimentoNominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO_NOMINATIVO"]);
            RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            RegistroModificheAutorizzateObj.IsDirty = false;
            RegistroModificheAutorizzateObj.IsPersistent = true;
            return RegistroModificheAutorizzateObj;
        }

        //Find Select

        public static RegistroModificheAutorizzateCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdTipoModificaEqualThis, SiarLibrary.NullTypes.StringNT RiferimentoPassEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRichiestaEqualThis,
SiarLibrary.NullTypes.IntNT IdRiferimentoPrincipaleEqualThis, SiarLibrary.NullTypes.BoolNT IgnoraControlliEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis,
SiarLibrary.NullTypes.StringNT EsitoEqualThis)

        {

            RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionObj = new RegistroModificheAutorizzateCollection();

            IDbCommand findCmd = db.InitCmd("Zregistromodificheautorizzatefindselect", new string[] {"IdModificaequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis",
"IdTipoModificaequalthis", "RiferimentoPassequalthis", "SegnaturaRichiestaequalthis",
"IdRiferimentoPrincipaleequalthis", "IgnoraControlliequalthis", "Noteequalthis",
"Esitoequalthis"}, new string[] {"int", "int", "DateTime",
"int", "string", "string",
"int", "bool", "string",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoModificaequalthis", IdTipoModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RiferimentoPassequalthis", RiferimentoPassEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaRichiestaequalthis", SegnaturaRichiestaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRiferimentoPrincipaleequalthis", IdRiferimentoPrincipaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IgnoraControlliequalthis", IgnoraControlliEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
            RegistroModificheAutorizzate RegistroModificheAutorizzateObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroModificheAutorizzateObj = GetFromDatareader(db);
                RegistroModificheAutorizzateObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroModificheAutorizzateObj.IsDirty = false;
                RegistroModificheAutorizzateObj.IsPersistent = true;
                RegistroModificheAutorizzateCollectionObj.Add(RegistroModificheAutorizzateObj);
            }
            db.Close();
            return RegistroModificheAutorizzateCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for RegistroModificheAutorizzateCollectionProvider:IRegistroModificheAutorizzateProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroModificheAutorizzateCollectionProvider : IRegistroModificheAutorizzateProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di RegistroModificheAutorizzate
        protected RegistroModificheAutorizzateCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public RegistroModificheAutorizzateCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new RegistroModificheAutorizzateCollection(this);
        }

        //Costruttore3: ha in input registromodificheautorizzateCollectionObj - non popola la collection
        public RegistroModificheAutorizzateCollectionProvider(RegistroModificheAutorizzateCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public RegistroModificheAutorizzateCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new RegistroModificheAutorizzateCollection(this);
        }

        //Get e Set
        public RegistroModificheAutorizzateCollection CollectionObj
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
        public int SaveCollection(RegistroModificheAutorizzateCollection collectionObj)
        {
            return RegistroModificheAutorizzateDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(RegistroModificheAutorizzate registromodificheautorizzateObj)
        {
            return RegistroModificheAutorizzateDAL.Save(_dbProviderObj, registromodificheautorizzateObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(RegistroModificheAutorizzateCollection collectionObj)
        {
            return RegistroModificheAutorizzateDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(RegistroModificheAutorizzate registromodificheautorizzateObj)
        {
            return RegistroModificheAutorizzateDAL.Delete(_dbProviderObj, registromodificheautorizzateObj);
        }

        //getById
        public RegistroModificheAutorizzate GetById(IntNT IdModificaValue)
        {
            RegistroModificheAutorizzate RegistroModificheAutorizzateTemp = RegistroModificheAutorizzateDAL.GetById(_dbProviderObj, IdModificaValue);
            if (RegistroModificheAutorizzateTemp != null) RegistroModificheAutorizzateTemp.Provider = this;
            return RegistroModificheAutorizzateTemp;
        }

        //Select: popola la collection
        public RegistroModificheAutorizzateCollection Select(IntNT IdmodificaEqualThis, IntNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
IntNT IdtipomodificaEqualThis, StringNT RiferimentopassEqualThis, StringNT SegnaturarichiestaEqualThis,
IntNT IdriferimentoprincipaleEqualThis, BoolNT IgnoracontrolliEqualThis, StringNT NoteEqualThis,
StringNT EsitoEqualThis)
        {
            RegistroModificheAutorizzateCollection RegistroModificheAutorizzateCollectionTemp = RegistroModificheAutorizzateDAL.Select(_dbProviderObj, IdmodificaEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis,
IdtipomodificaEqualThis, RiferimentopassEqualThis, SegnaturarichiestaEqualThis,
IdriferimentoprincipaleEqualThis, IgnoracontrolliEqualThis, NoteEqualThis,
EsitoEqualThis);
            RegistroModificheAutorizzateCollectionTemp.Provider = this;
            return RegistroModificheAutorizzateCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REGISTRO_MODIFICHE_AUTORIZZATE>
  <ViewName>VREGISTRO_MODIFICHE_AUTORIZZATE</ViewName>
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
</REGISTRO_MODIFICHE_AUTORIZZATE>
*/
