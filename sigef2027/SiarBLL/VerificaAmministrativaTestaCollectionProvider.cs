using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per VerificaAmministrativaTesta
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IVerificaAmministrativaTestaProvider
    {
        int Save(VerificaAmministrativaTesta VerificaAmministrativaTestaObj);
        int SaveCollection(VerificaAmministrativaTestaCollection collectionObj);
        int Delete(VerificaAmministrativaTesta VerificaAmministrativaTestaObj);
        int DeleteCollection(VerificaAmministrativaTestaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for VerificaAmministrativaTesta
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VerificaAmministrativaTesta : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdLotto;
        private NullTypes.StringNT _Codpsr;
        private NullTypes.StringNT _OperatoreInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _OperatoreModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.DatetimeNT _DataInizio;
        private NullTypes.DatetimeNT _DataFine;
        private NullTypes.StringNT _Note;
        private NullTypes.BoolNT _Definitivo;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.DatetimeNT _DataSegnatura;
        [NonSerialized] private IVerificaAmministrativaTestaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVerificaAmministrativaTestaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public VerificaAmministrativaTesta()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_LOTTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdLotto
        {
            get { return _IdLotto; }
            set
            {
                if (IdLotto != value)
                {
                    _IdLotto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODPSR
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Codpsr
        {
            get { return _Codpsr; }
            set
            {
                if (Codpsr != value)
                {
                    _Codpsr = value;
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
        /// Corrisponde al campo:DATA_INIZIO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizio
        {
            get { return _DataInizio; }
            set
            {
                if (DataInizio != value)
                {
                    _DataInizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFine
        {
            get { return _DataFine; }
            set
            {
                if (DataFine != value)
                {
                    _DataFine = value;
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
        /// Corrisponde al campo:DEFINITIVO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Definitivo
        {
            get { return _Definitivo; }
            set
            {
                if (Definitivo != value)
                {
                    _Definitivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Segnatura
        {
            get { return _Segnatura; }
            set
            {
                if (Segnatura != value)
                {
                    _Segnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SEGNATURA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataSegnatura
        {
            get { return _DataSegnatura; }
            set
            {
                if (DataSegnatura != value)
                {
                    _DataSegnatura = value;
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
    /// Summary description for VerificaAmministrativaTestaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VerificaAmministrativaTestaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VerificaAmministrativaTestaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VerificaAmministrativaTesta)info.GetValue(i.ToString(), typeof(VerificaAmministrativaTesta)));
            }
        }

        //Costruttore
        public VerificaAmministrativaTestaCollection()
        {
            this.ItemType = typeof(VerificaAmministrativaTesta);
        }

        //Costruttore con provider
        public VerificaAmministrativaTestaCollection(IVerificaAmministrativaTestaProvider providerObj)
        {
            this.ItemType = typeof(VerificaAmministrativaTesta);
            this.Provider = providerObj;
        }

        //Get e Set
        public new VerificaAmministrativaTesta this[int index]
        {
            get { return (VerificaAmministrativaTesta)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VerificaAmministrativaTestaCollection GetChanges()
        {
            return (VerificaAmministrativaTestaCollection)base.GetChanges();
        }

        [NonSerialized] private IVerificaAmministrativaTestaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVerificaAmministrativaTestaProvider Provider
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
        public int Add(VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            if (VerificaAmministrativaTestaObj.Provider == null) VerificaAmministrativaTestaObj.Provider = this.Provider;
            return base.Add(VerificaAmministrativaTestaObj);
        }

        //AddCollection
        public void AddCollection(VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj)
        {
            foreach (VerificaAmministrativaTesta VerificaAmministrativaTestaObj in VerificaAmministrativaTestaCollectionObj)
                this.Add(VerificaAmministrativaTestaObj);
        }

        //Insert
        public void Insert(int index, VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            if (VerificaAmministrativaTestaObj.Provider == null) VerificaAmministrativaTestaObj.Provider = this.Provider;
            base.Insert(index, VerificaAmministrativaTestaObj);
        }

        //CollectionGetById
        public VerificaAmministrativaTesta CollectionGetById(NullTypes.IntNT IdLottoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdLotto == IdLottoValue))
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
        public VerificaAmministrativaTestaCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.StringNT CodpsrEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, NullTypes.StringNT NoteEqualThis,
NullTypes.BoolNT DefinitivoEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.DatetimeNT DataSegnaturaEqualThis)
        {
            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionTemp = new VerificaAmministrativaTestaCollection();
            foreach (VerificaAmministrativaTesta VerificaAmministrativaTestaItem in this)
            {
                if (((IdLottoEqualThis == null) || ((VerificaAmministrativaTestaItem.IdLotto != null) && (VerificaAmministrativaTestaItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((CodpsrEqualThis == null) || ((VerificaAmministrativaTestaItem.Codpsr != null) && (VerificaAmministrativaTestaItem.Codpsr.Value == CodpsrEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((VerificaAmministrativaTestaItem.OperatoreInserimento != null) && (VerificaAmministrativaTestaItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VerificaAmministrativaTestaItem.DataInserimento != null) && (VerificaAmministrativaTestaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((VerificaAmministrativaTestaItem.OperatoreModifica != null) && (VerificaAmministrativaTestaItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VerificaAmministrativaTestaItem.DataModifica != null) && (VerificaAmministrativaTestaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((DataInizioEqualThis == null) || ((VerificaAmministrativaTestaItem.DataInizio != null) && (VerificaAmministrativaTestaItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((VerificaAmministrativaTestaItem.DataFine != null) && (VerificaAmministrativaTestaItem.DataFine.Value == DataFineEqualThis.Value))) && ((NoteEqualThis == null) || ((VerificaAmministrativaTestaItem.Note != null) && (VerificaAmministrativaTestaItem.Note.Value == NoteEqualThis.Value))) &&
((DefinitivoEqualThis == null) || ((VerificaAmministrativaTestaItem.Definitivo != null) && (VerificaAmministrativaTestaItem.Definitivo.Value == DefinitivoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VerificaAmministrativaTestaItem.Segnatura != null) && (VerificaAmministrativaTestaItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((DataSegnaturaEqualThis == null) || ((VerificaAmministrativaTestaItem.DataSegnatura != null) && (VerificaAmministrativaTestaItem.DataSegnatura.Value == DataSegnaturaEqualThis.Value))))
                {
                    VerificaAmministrativaTestaCollectionTemp.Add(VerificaAmministrativaTestaItem);
                }
            }
            return VerificaAmministrativaTestaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VerificaAmministrativaTestaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VerificaAmministrativaTestaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VerificaAmministrativaTesta VerificaAmministrativaTestaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdLotto", VerificaAmministrativaTestaObj.IdLotto);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Codpsr", VerificaAmministrativaTestaObj.Codpsr);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", VerificaAmministrativaTestaObj.OperatoreInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", VerificaAmministrativaTestaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", VerificaAmministrativaTestaObj.OperatoreModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VerificaAmministrativaTestaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizio", VerificaAmministrativaTestaObj.DataInizio);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFine", VerificaAmministrativaTestaObj.DataFine);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", VerificaAmministrativaTestaObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "Definitivo", VerificaAmministrativaTestaObj.Definitivo);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", VerificaAmministrativaTestaObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSegnatura", VerificaAmministrativaTestaObj.DataSegnatura);
        }
        //Insert
        private static int Insert(DbProvider db, VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZVerificaAmministrativaTestaInsert", new string[] {"Codpsr", "OperatoreInserimento",
"DataInserimento", "OperatoreModifica", "DataModifica",
"DataInizio", "DataFine", "Note",
"Definitivo", "Segnatura", "DataSegnatura"}, new string[] {"string", "string",
"DateTime", "string", "DateTime",
"DateTime", "DateTime", "string",
"bool", "string", "DateTime"}, "");
                CompileIUCmd(false, insertCmd, VerificaAmministrativaTestaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    VerificaAmministrativaTestaObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
                    VerificaAmministrativaTestaObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
                }
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVerificaAmministrativaTestaUpdate", new string[] {"IdLotto", "Codpsr", "OperatoreInserimento",
"DataInserimento", "OperatoreModifica", "DataModifica",
"DataInizio", "DataFine", "Note",
"Definitivo", "Segnatura", "DataSegnatura"}, new string[] {"int", "string", "string",
"DateTime", "string", "DateTime",
"DateTime", "DateTime", "string",
"bool", "string", "DateTime"}, "");
                CompileIUCmd(true, updateCmd, VerificaAmministrativaTestaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    VerificaAmministrativaTestaObj.DataModifica = d;
                }
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            switch (VerificaAmministrativaTestaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, VerificaAmministrativaTestaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, VerificaAmministrativaTestaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, VerificaAmministrativaTestaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVerificaAmministrativaTestaUpdate", new string[] {"IdLotto", "Codpsr", "OperatoreInserimento",
"DataInserimento", "OperatoreModifica", "DataModifica",
"DataInizio", "DataFine", "Note",
"Definitivo", "Segnatura", "DataSegnatura"}, new string[] {"int", "string", "string",
"DateTime", "string", "DateTime",
"DateTime", "DateTime", "string",
"bool", "string", "DateTime"}, "");
                IDbCommand insertCmd = db.InitCmd("ZVerificaAmministrativaTestaInsert", new string[] {"Codpsr", "OperatoreInserimento",
"DataInserimento", "OperatoreModifica", "DataModifica",
"DataInizio", "DataFine", "Note",
"Definitivo", "Segnatura", "DataSegnatura"}, new string[] {"string", "string",
"DateTime", "string", "DateTime",
"DateTime", "DateTime", "string",
"bool", "string", "DateTime"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaTestaDelete", new string[] { "IdLotto" }, new string[] { "int" }, "");
                for (int i = 0; i < VerificaAmministrativaTestaCollectionObj.Count; i++)
                {
                    switch (VerificaAmministrativaTestaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, VerificaAmministrativaTestaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    VerificaAmministrativaTestaCollectionObj[i].IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
                                    VerificaAmministrativaTestaCollectionObj[i].Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, VerificaAmministrativaTestaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    VerificaAmministrativaTestaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (VerificaAmministrativaTestaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)VerificaAmministrativaTestaCollectionObj[i].IdLotto);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < VerificaAmministrativaTestaCollectionObj.Count; i++)
                {
                    if ((VerificaAmministrativaTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VerificaAmministrativaTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VerificaAmministrativaTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        VerificaAmministrativaTestaCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaTestaCollectionObj[i].IsPersistent = true;
                    }
                    if ((VerificaAmministrativaTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        VerificaAmministrativaTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VerificaAmministrativaTestaCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaTestaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, VerificaAmministrativaTesta VerificaAmministrativaTestaObj)
        {
            int returnValue = 0;
            if (VerificaAmministrativaTestaObj.IsPersistent)
            {
                returnValue = Delete(db, VerificaAmministrativaTestaObj.IdLotto);
            }
            VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            VerificaAmministrativaTestaObj.IsDirty = false;
            VerificaAmministrativaTestaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdLottoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaTestaDelete", new string[] { "IdLotto" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaTestaDelete", new string[] { "IdLotto" }, new string[] { "int" }, "");
                for (int i = 0; i < VerificaAmministrativaTestaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLotto", VerificaAmministrativaTestaCollectionObj[i].IdLotto);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < VerificaAmministrativaTestaCollectionObj.Count; i++)
                {
                    if ((VerificaAmministrativaTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VerificaAmministrativaTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VerificaAmministrativaTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VerificaAmministrativaTestaCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaTestaCollectionObj[i].IsPersistent = false;
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
        public static VerificaAmministrativaTesta GetById(DbProvider db, int IdLottoValue)
        {
            VerificaAmministrativaTesta VerificaAmministrativaTestaObj = null;
            IDbCommand readCmd = db.InitCmd("ZVerificaAmministrativaTestaGetById", new string[] { "IdLotto" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                VerificaAmministrativaTestaObj = GetFromDatareader(db);
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
            }
            db.Close();
            return VerificaAmministrativaTestaObj;
        }

        //getFromDatareader
        public static VerificaAmministrativaTesta GetFromDatareader(DbProvider db)
        {
            VerificaAmministrativaTesta VerificaAmministrativaTestaObj = new VerificaAmministrativaTesta();
            VerificaAmministrativaTestaObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
            VerificaAmministrativaTestaObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODPSR"]);
            VerificaAmministrativaTestaObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
            VerificaAmministrativaTestaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            VerificaAmministrativaTestaObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
            VerificaAmministrativaTestaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            VerificaAmministrativaTestaObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
            VerificaAmministrativaTestaObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
            VerificaAmministrativaTestaObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            VerificaAmministrativaTestaObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
            VerificaAmministrativaTestaObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            VerificaAmministrativaTestaObj.DataSegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNATURA"]);
            VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VerificaAmministrativaTestaObj.IsDirty = false;
            VerificaAmministrativaTestaObj.IsPersistent = true;
            return VerificaAmministrativaTestaObj;
        }

        //Find Select

        public static VerificaAmministrativaTestaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.StringNT CodpsrEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis,
SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnaturaEqualThis)

        {

            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj = new VerificaAmministrativaTestaCollection();

            IDbCommand findCmd = db.InitCmd("Zverificaamministrativatestafindselect", new string[] {"IdLottoequalthis", "Codpsrequalthis", "OperatoreInserimentoequalthis",
"DataInserimentoequalthis", "OperatoreModificaequalthis", "DataModificaequalthis",
"DataInizioequalthis", "DataFineequalthis", "Noteequalthis",
"Definitivoequalthis", "Segnaturaequalthis", "DataSegnaturaequalthis"}, new string[] {"int", "string", "string",
"DateTime", "string", "DateTime",
"DateTime", "DateTime", "string",
"bool", "string", "DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codpsrequalthis", CodpsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSegnaturaequalthis", DataSegnaturaEqualThis);
            VerificaAmministrativaTesta VerificaAmministrativaTestaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VerificaAmministrativaTestaObj = GetFromDatareader(db);
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
                VerificaAmministrativaTestaCollectionObj.Add(VerificaAmministrativaTestaObj);
            }
            db.Close();
            return VerificaAmministrativaTestaCollectionObj;
        }

        //Find FindDefinitivo

        public static VerificaAmministrativaTestaCollection FindDefinitivo(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.StringNT CodpsrEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis)

        {

            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj = new VerificaAmministrativaTestaCollection();

            IDbCommand findCmd = db.InitCmd("Zverificaamministrativatestafindfinddefinitivo", new string[] { "IdLottoequalthis", "Codpsrequalthis", "Definitivoequalthis" }, new string[] { "int", "string", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codpsrequalthis", CodpsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
            VerificaAmministrativaTesta VerificaAmministrativaTestaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VerificaAmministrativaTestaObj = GetFromDatareader(db);
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
                VerificaAmministrativaTestaCollectionObj.Add(VerificaAmministrativaTestaObj);
            }
            db.Close();
            return VerificaAmministrativaTestaCollectionObj;
        }

        //Find GetByCodPsr

        public static VerificaAmministrativaTestaCollection GetByCodPsr(DbProvider db, SiarLibrary.NullTypes.StringNT CodpsrEqualThis)

        {

            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionObj = new VerificaAmministrativaTestaCollection();

            IDbCommand findCmd = db.InitCmd("Zverificaamministrativatestafindgetbycodpsr", new string[] { "Codpsrequalthis" }, new string[] { "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codpsrequalthis", CodpsrEqualThis);
            VerificaAmministrativaTesta VerificaAmministrativaTestaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VerificaAmministrativaTestaObj = GetFromDatareader(db);
                VerificaAmministrativaTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaTestaObj.IsDirty = false;
                VerificaAmministrativaTestaObj.IsPersistent = true;
                VerificaAmministrativaTestaCollectionObj.Add(VerificaAmministrativaTestaObj);
            }
            db.Close();
            return VerificaAmministrativaTestaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VerificaAmministrativaTestaCollectionProvider:IVerificaAmministrativaTestaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VerificaAmministrativaTestaCollectionProvider : IVerificaAmministrativaTestaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VerificaAmministrativaTesta
        protected VerificaAmministrativaTestaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VerificaAmministrativaTestaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VerificaAmministrativaTestaCollection(this);
        }

        //Costruttore 2: popola la collection
        public VerificaAmministrativaTestaCollectionProvider(IntNT IdlottoEqualThis, StringNT CodpsrEqualThis, BoolNT DefinitivoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindDefinitivo(IdlottoEqualThis, CodpsrEqualThis, DefinitivoEqualThis);
        }

        //Costruttore3: ha in input verificaamministrativatestaCollectionObj - non popola la collection
        public VerificaAmministrativaTestaCollectionProvider(VerificaAmministrativaTestaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VerificaAmministrativaTestaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VerificaAmministrativaTestaCollection(this);
        }

        //Get e Set
        public VerificaAmministrativaTestaCollection CollectionObj
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
        public int SaveCollection(VerificaAmministrativaTestaCollection collectionObj)
        {
            return VerificaAmministrativaTestaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(VerificaAmministrativaTesta verificaamministrativatestaObj)
        {
            return VerificaAmministrativaTestaDAL.Save(_dbProviderObj, verificaamministrativatestaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(VerificaAmministrativaTestaCollection collectionObj)
        {
            return VerificaAmministrativaTestaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(VerificaAmministrativaTesta verificaamministrativatestaObj)
        {
            return VerificaAmministrativaTestaDAL.Delete(_dbProviderObj, verificaamministrativatestaObj);
        }

        //getById
        public VerificaAmministrativaTesta GetById(IntNT IdLottoValue)
        {
            VerificaAmministrativaTesta VerificaAmministrativaTestaTemp = VerificaAmministrativaTestaDAL.GetById(_dbProviderObj, IdLottoValue);
            if (VerificaAmministrativaTestaTemp != null) VerificaAmministrativaTestaTemp.Provider = this;
            return VerificaAmministrativaTestaTemp;
        }

        //Select: popola la collection
        public VerificaAmministrativaTestaCollection Select(IntNT IdlottoEqualThis, StringNT CodpsrEqualThis, StringNT OperatoreinserimentoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis,
DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, StringNT NoteEqualThis,
BoolNT DefinitivoEqualThis, StringNT SegnaturaEqualThis, DatetimeNT DatasegnaturaEqualThis)
        {
            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionTemp = VerificaAmministrativaTestaDAL.Select(_dbProviderObj, IdlottoEqualThis, CodpsrEqualThis, OperatoreinserimentoEqualThis,
DatainserimentoEqualThis, OperatoremodificaEqualThis, DatamodificaEqualThis,
DatainizioEqualThis, DatafineEqualThis, NoteEqualThis,
DefinitivoEqualThis, SegnaturaEqualThis, DatasegnaturaEqualThis);
            VerificaAmministrativaTestaCollectionTemp.Provider = this;
            return VerificaAmministrativaTestaCollectionTemp;
        }

        //FindDefinitivo: popola la collection
        public VerificaAmministrativaTestaCollection FindDefinitivo(IntNT IdlottoEqualThis, StringNT CodpsrEqualThis, BoolNT DefinitivoEqualThis)
        {
            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionTemp = VerificaAmministrativaTestaDAL.FindDefinitivo(_dbProviderObj, IdlottoEqualThis, CodpsrEqualThis, DefinitivoEqualThis);
            VerificaAmministrativaTestaCollectionTemp.Provider = this;
            return VerificaAmministrativaTestaCollectionTemp;
        }

        //GetByCodPsr: popola la collection
        public VerificaAmministrativaTestaCollection GetByCodPsr(StringNT CodpsrEqualThis)
        {
            VerificaAmministrativaTestaCollection VerificaAmministrativaTestaCollectionTemp = VerificaAmministrativaTestaDAL.GetByCodPsr(_dbProviderObj, CodpsrEqualThis);
            VerificaAmministrativaTestaCollectionTemp.Provider = this;
            return VerificaAmministrativaTestaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VERIFICA_AMMINISTRATIVA_TESTA>
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
    <FindDefinitivo OrderBy="ORDER BY ">
      <ID_LOTTO>Equal</ID_LOTTO>
      <CODPSR>Equal</CODPSR>
      <DEFINITIVO>Equal</DEFINITIVO>
    </FindDefinitivo>
    <GetByCodPsr OrderBy="ORDER BY DATA_FINE DESC">
      <CODPSR>Equal</CODPSR>
    </GetByCodPsr>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VERIFICA_AMMINISTRATIVA_TESTA>
*/
