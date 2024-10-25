using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ScaricamentoFirmaEsterna
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IScaricamentoFirmaEsternaProvider
    {
        int Save(ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj);
        int SaveCollection(ScaricamentoFirmaEsternaCollection collectionObj);
        int Delete(ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj);
        int DeleteCollection(ScaricamentoFirmaEsternaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ScaricamentoFirmaEsterna
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ScaricamentoFirmaEsterna : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _OperatoreInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _OperatoreModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _HashCodeFileConSigillo;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdVariante;
        [NonSerialized] private IScaricamentoFirmaEsternaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IScaricamentoFirmaEsternaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ScaricamentoFirmaEsterna()
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
        /// Corrisponde al campo:OPERATORE_INSERIMENTO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT OperatoreInserimento
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
        /// Corrisponde al campo:OPERATORE_MODIFICA
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT OperatoreModifica
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

        /// <summary>
        /// Corrisponde al campo:HASH_CODE_FILE_CON_SIGILLO
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT HashCodeFileConSigillo
        {
            get { return _HashCodeFileConSigillo; }
            set
            {
                if (HashCodeFileConSigillo != value)
                {
                    _HashCodeFileConSigillo = value;
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
    /// Summary description for ScaricamentoFirmaEsternaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ScaricamentoFirmaEsternaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ScaricamentoFirmaEsternaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ScaricamentoFirmaEsterna)info.GetValue(i.ToString(), typeof(ScaricamentoFirmaEsterna)));
            }
        }

        //Costruttore
        public ScaricamentoFirmaEsternaCollection()
        {
            this.ItemType = typeof(ScaricamentoFirmaEsterna);
        }

        //Costruttore con provider
        public ScaricamentoFirmaEsternaCollection(IScaricamentoFirmaEsternaProvider providerObj)
        {
            this.ItemType = typeof(ScaricamentoFirmaEsterna);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ScaricamentoFirmaEsterna this[int index]
        {
            get { return (ScaricamentoFirmaEsterna)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ScaricamentoFirmaEsternaCollection GetChanges()
        {
            return (ScaricamentoFirmaEsternaCollection)base.GetChanges();
        }

        [NonSerialized] private IScaricamentoFirmaEsternaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IScaricamentoFirmaEsternaProvider Provider
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
        public int Add(ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            if (ScaricamentoFirmaEsternaObj.Provider == null) ScaricamentoFirmaEsternaObj.Provider = this.Provider;
            return base.Add(ScaricamentoFirmaEsternaObj);
        }

        //AddCollection
        public void AddCollection(ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionObj)
        {
            foreach (ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj in ScaricamentoFirmaEsternaCollectionObj)
                this.Add(ScaricamentoFirmaEsternaObj);
        }

        //Insert
        public void Insert(int index, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            if (ScaricamentoFirmaEsternaObj.Provider == null) ScaricamentoFirmaEsternaObj.Provider = this.Provider;
            base.Insert(index, ScaricamentoFirmaEsternaObj);
        }

        //CollectionGetById
        public ScaricamentoFirmaEsterna CollectionGetById(NullTypes.IntNT IdValue)
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
        public ScaricamentoFirmaEsternaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT HashCodeFileConSigilloEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdVarianteEqualThis)
        {
            ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionTemp = new ScaricamentoFirmaEsternaCollection();
            foreach (ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaItem in this)
            {
                if (((IdEqualThis == null) || ((ScaricamentoFirmaEsternaItem.Id != null) && (ScaricamentoFirmaEsternaItem.Id.Value == IdEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((ScaricamentoFirmaEsternaItem.OperatoreInserimento != null) && (ScaricamentoFirmaEsternaItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ScaricamentoFirmaEsternaItem.DataInserimento != null) && (ScaricamentoFirmaEsternaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((OperatoreModificaEqualThis == null) || ((ScaricamentoFirmaEsternaItem.OperatoreModifica != null) && (ScaricamentoFirmaEsternaItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ScaricamentoFirmaEsternaItem.DataModifica != null) && (ScaricamentoFirmaEsternaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((HashCodeFileConSigilloEqualThis == null) || ((ScaricamentoFirmaEsternaItem.HashCodeFileConSigillo != null) && (ScaricamentoFirmaEsternaItem.HashCodeFileConSigillo.Value == HashCodeFileConSigilloEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((ScaricamentoFirmaEsternaItem.IdProgetto != null) && (ScaricamentoFirmaEsternaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((ScaricamentoFirmaEsternaItem.IdDomandaPagamento != null) && (ScaricamentoFirmaEsternaItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((ScaricamentoFirmaEsternaItem.IdVariante != null) && (ScaricamentoFirmaEsternaItem.IdVariante.Value == IdVarianteEqualThis.Value))))
                {
                    ScaricamentoFirmaEsternaCollectionTemp.Add(ScaricamentoFirmaEsternaItem);
                }
            }
            return ScaricamentoFirmaEsternaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ScaricamentoFirmaEsternaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ScaricamentoFirmaEsternaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ScaricamentoFirmaEsternaObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", ScaricamentoFirmaEsternaObj.OperatoreInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ScaricamentoFirmaEsternaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", ScaricamentoFirmaEsternaObj.OperatoreModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ScaricamentoFirmaEsternaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "HashCodeFileConSigillo", ScaricamentoFirmaEsternaObj.HashCodeFileConSigillo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ScaricamentoFirmaEsternaObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", ScaricamentoFirmaEsternaObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", ScaricamentoFirmaEsternaObj.IdVariante);
        }
        //Insert
        private static int Insert(DbProvider db, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZScaricamentoFirmaEsternaInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "HashCodeFileConSigillo",
"IdProgetto", "IdDomandaPagamento", "IdVariante"}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"int", "int", "int"}, "");
                CompileIUCmd(false, insertCmd, ScaricamentoFirmaEsternaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ScaricamentoFirmaEsternaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ScaricamentoFirmaEsternaObj.IsDirty = false;
                ScaricamentoFirmaEsternaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZScaricamentoFirmaEsternaUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "HashCodeFileConSigillo",
"IdProgetto", "IdDomandaPagamento", "IdVariante"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "int", "int"}, "");
                CompileIUCmd(true, updateCmd, ScaricamentoFirmaEsternaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ScaricamentoFirmaEsternaObj.DataModifica = d;
                }
                ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ScaricamentoFirmaEsternaObj.IsDirty = false;
                ScaricamentoFirmaEsternaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            switch (ScaricamentoFirmaEsternaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ScaricamentoFirmaEsternaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ScaricamentoFirmaEsternaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ScaricamentoFirmaEsternaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZScaricamentoFirmaEsternaUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "HashCodeFileConSigillo",
"IdProgetto", "IdDomandaPagamento", "IdVariante"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "int", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZScaricamentoFirmaEsternaInsert", new string[] {"OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica", "HashCodeFileConSigillo",
"IdProgetto", "IdDomandaPagamento", "IdVariante"}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"int", "int", "int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZScaricamentoFirmaEsternaDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ScaricamentoFirmaEsternaCollectionObj.Count; i++)
                {
                    switch (ScaricamentoFirmaEsternaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ScaricamentoFirmaEsternaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ScaricamentoFirmaEsternaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ScaricamentoFirmaEsternaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ScaricamentoFirmaEsternaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ScaricamentoFirmaEsternaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ScaricamentoFirmaEsternaCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ScaricamentoFirmaEsternaCollectionObj.Count; i++)
                {
                    if ((ScaricamentoFirmaEsternaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ScaricamentoFirmaEsternaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ScaricamentoFirmaEsternaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsDirty = false;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsPersistent = true;
                    }
                    if ((ScaricamentoFirmaEsternaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ScaricamentoFirmaEsternaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsDirty = false;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj)
        {
            int returnValue = 0;
            if (ScaricamentoFirmaEsternaObj.IsPersistent)
            {
                returnValue = Delete(db, ScaricamentoFirmaEsternaObj.Id);
            }
            ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ScaricamentoFirmaEsternaObj.IsDirty = false;
            ScaricamentoFirmaEsternaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZScaricamentoFirmaEsternaDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZScaricamentoFirmaEsternaDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ScaricamentoFirmaEsternaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ScaricamentoFirmaEsternaCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ScaricamentoFirmaEsternaCollectionObj.Count; i++)
                {
                    if ((ScaricamentoFirmaEsternaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ScaricamentoFirmaEsternaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ScaricamentoFirmaEsternaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsDirty = false;
                        ScaricamentoFirmaEsternaCollectionObj[i].IsPersistent = false;
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
        public static ScaricamentoFirmaEsterna GetById(DbProvider db, int IdValue)
        {
            ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj = null;
            IDbCommand readCmd = db.InitCmd("ZScaricamentoFirmaEsternaGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ScaricamentoFirmaEsternaObj = GetFromDatareader(db);
                ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ScaricamentoFirmaEsternaObj.IsDirty = false;
                ScaricamentoFirmaEsternaObj.IsPersistent = true;
            }
            db.Close();
            return ScaricamentoFirmaEsternaObj;
        }

        //getFromDatareader
        public static ScaricamentoFirmaEsterna GetFromDatareader(DbProvider db)
        {
            ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj = new ScaricamentoFirmaEsterna();
            ScaricamentoFirmaEsternaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ScaricamentoFirmaEsternaObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
            ScaricamentoFirmaEsternaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ScaricamentoFirmaEsternaObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
            ScaricamentoFirmaEsternaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ScaricamentoFirmaEsternaObj.HashCodeFileConSigillo = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE_FILE_CON_SIGILLO"]);
            ScaricamentoFirmaEsternaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ScaricamentoFirmaEsternaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            ScaricamentoFirmaEsternaObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ScaricamentoFirmaEsternaObj.IsDirty = false;
            ScaricamentoFirmaEsternaObj.IsPersistent = true;
            return ScaricamentoFirmaEsternaObj;
        }

        //Find Select

        public static ScaricamentoFirmaEsternaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT HashCodeFileConSigilloEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis)

        {

            ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionObj = new ScaricamentoFirmaEsternaCollection();

            IDbCommand findCmd = db.InitCmd("Zscaricamentofirmaesternafindselect", new string[] {"Idequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis",
"OperatoreModificaequalthis", "DataModificaequalthis", "HashCodeFileConSigilloequalthis",
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdVarianteequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"int", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "HashCodeFileConSigilloequalthis", HashCodeFileConSigilloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ScaricamentoFirmaEsternaObj = GetFromDatareader(db);
                ScaricamentoFirmaEsternaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ScaricamentoFirmaEsternaObj.IsDirty = false;
                ScaricamentoFirmaEsternaObj.IsPersistent = true;
                ScaricamentoFirmaEsternaCollectionObj.Add(ScaricamentoFirmaEsternaObj);
            }
            db.Close();
            return ScaricamentoFirmaEsternaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ScaricamentoFirmaEsternaCollectionProvider:IScaricamentoFirmaEsternaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ScaricamentoFirmaEsternaCollectionProvider : IScaricamentoFirmaEsternaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ScaricamentoFirmaEsterna
        protected ScaricamentoFirmaEsternaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ScaricamentoFirmaEsternaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ScaricamentoFirmaEsternaCollection(this);
        }

        //Costruttore3: ha in input scaricamentofirmaesternaCollectionObj - non popola la collection
        public ScaricamentoFirmaEsternaCollectionProvider(ScaricamentoFirmaEsternaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ScaricamentoFirmaEsternaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ScaricamentoFirmaEsternaCollection(this);
        }

        //Get e Set
        public ScaricamentoFirmaEsternaCollection CollectionObj
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
        public int SaveCollection(ScaricamentoFirmaEsternaCollection collectionObj)
        {
            return ScaricamentoFirmaEsternaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ScaricamentoFirmaEsterna scaricamentofirmaesternaObj)
        {
            return ScaricamentoFirmaEsternaDAL.Save(_dbProviderObj, scaricamentofirmaesternaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ScaricamentoFirmaEsternaCollection collectionObj)
        {
            return ScaricamentoFirmaEsternaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ScaricamentoFirmaEsterna scaricamentofirmaesternaObj)
        {
            return ScaricamentoFirmaEsternaDAL.Delete(_dbProviderObj, scaricamentofirmaesternaObj);
        }

        //getById
        public ScaricamentoFirmaEsterna GetById(IntNT IdValue)
        {
            ScaricamentoFirmaEsterna ScaricamentoFirmaEsternaTemp = ScaricamentoFirmaEsternaDAL.GetById(_dbProviderObj, IdValue);
            if (ScaricamentoFirmaEsternaTemp != null) ScaricamentoFirmaEsternaTemp.Provider = this;
            return ScaricamentoFirmaEsternaTemp;
        }

        //Select: popola la collection
        public ScaricamentoFirmaEsternaCollection Select(IntNT IdEqualThis, StringNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, StringNT HashcodefileconsigilloEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis)
        {
            ScaricamentoFirmaEsternaCollection ScaricamentoFirmaEsternaCollectionTemp = ScaricamentoFirmaEsternaDAL.Select(_dbProviderObj, IdEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis,
OperatoremodificaEqualThis, DatamodificaEqualThis, HashcodefileconsigilloEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis);
            ScaricamentoFirmaEsternaCollectionTemp.Provider = this;
            return ScaricamentoFirmaEsternaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCARICAMENTO_FIRMA_ESTERNA>
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
</SCARICAMENTO_FIRMA_ESTERNA>
*/
