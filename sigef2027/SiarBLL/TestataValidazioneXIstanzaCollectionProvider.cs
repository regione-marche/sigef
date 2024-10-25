using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TestataValidazioneXIstanza
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITestataValidazioneXIstanzaProvider
    {
        int Save(TestataValidazioneXIstanza TestataValidazioneXIstanzaObj);
        int SaveCollection(TestataValidazioneXIstanzaCollection collectionObj);
        int Delete(TestataValidazioneXIstanza TestataValidazioneXIstanzaObj);
        int DeleteCollection(TestataValidazioneXIstanzaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TestataValidazioneXIstanza
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TestataValidazioneXIstanza : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTestataValidazioneXIstanza;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.IntNT _IdTestataValidazione;
        private NullTypes.IntNT _IdIstanzaChecklistGenerica;
        private NullTypes.IntNT _Ordine;
        private NullTypes.StringNT _Note;
        private NullTypes.BoolNT _Autovalutazione;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.DatetimeNT _DataValidazione;
        private NullTypes.StringNT _CfValidatore;
        private NullTypes.StringNT _NominativoValidatore;
        private NullTypes.IntNT _IdChecklistGenerica;
        private NullTypes.StringNT _CodFaseIstanza;
        private NullTypes.StringNT _DescrizioneChecklist;
        private NullTypes.BoolNT _FlagTemplateChecklist;
        private NullTypes.StringNT _IdFiltroChecklist;
        private NullTypes.IntNT _IdTipoChecklist;
        [NonSerialized] private ITestataValidazioneXIstanzaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataValidazioneXIstanzaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TestataValidazioneXIstanza()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_TESTATA_VALIDAZIONE_X_ISTANZA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTestataValidazioneXIstanza
        {
            get { return _IdTestataValidazioneXIstanza; }
            set
            {
                if (IdTestataValidazioneXIstanza != value)
                {
                    _IdTestataValidazioneXIstanza = value;
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
        /// Corrisponde al campo:ID_TESTATA_VALIDAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTestataValidazione
        {
            get { return _IdTestataValidazione; }
            set
            {
                if (IdTestataValidazione != value)
                {
                    _IdTestataValidazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ISTANZA_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIstanzaChecklistGenerica
        {
            get { return _IdIstanzaChecklistGenerica; }
            set
            {
                if (IdIstanzaChecklistGenerica != value)
                {
                    _IdIstanzaChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE
        /// Tipo sul db:INT
        /// Default:((1))
        /// </summary>
        public NullTypes.IntNT Ordine
        {
            get { return _Ordine; }
            set
            {
                if (Ordine != value)
                {
                    _Ordine = value;
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
        /// Corrisponde al campo:AUTOVALUTAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Autovalutazione
        {
            get { return _Autovalutazione; }
            set
            {
                if (Autovalutazione != value)
                {
                    _Autovalutazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:APPROVATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Approvata
        {
            get { return _Approvata; }
            set
            {
                if (Approvata != value)
                {
                    _Approvata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VALIDAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataValidazione
        {
            get { return _DataValidazione; }
            set
            {
                if (DataValidazione != value)
                {
                    _DataValidazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_VALIDATORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfValidatore
        {
            get { return _CfValidatore; }
            set
            {
                if (CfValidatore != value)
                {
                    _CfValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_VALIDATORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoValidatore
        {
            get { return _NominativoValidatore; }
            set
            {
                if (NominativoValidatore != value)
                {
                    _NominativoValidatore = value;
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
        /// Corrisponde al campo:COD_FASE_ISTANZA
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodFaseIstanza
        {
            get { return _CodFaseIstanza; }
            set
            {
                if (CodFaseIstanza != value)
                {
                    _CodFaseIstanza = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_CHECKLIST
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneChecklist
        {
            get { return _DescrizioneChecklist; }
            set
            {
                if (DescrizioneChecklist != value)
                {
                    _DescrizioneChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG_TEMPLATE_CHECKLIST
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FlagTemplateChecklist
        {
            get { return _FlagTemplateChecklist; }
            set
            {
                if (FlagTemplateChecklist != value)
                {
                    _FlagTemplateChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILTRO_CHECKLIST
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT IdFiltroChecklist
        {
            get { return _IdFiltroChecklist; }
            set
            {
                if (IdFiltroChecklist != value)
                {
                    _IdFiltroChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_CHECKLIST
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoChecklist
        {
            get { return _IdTipoChecklist; }
            set
            {
                if (IdTipoChecklist != value)
                {
                    _IdTipoChecklist = value;
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
    /// Summary description for TestataValidazioneXIstanzaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataValidazioneXIstanzaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TestataValidazioneXIstanzaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TestataValidazioneXIstanza)info.GetValue(i.ToString(), typeof(TestataValidazioneXIstanza)));
            }
        }

        //Costruttore
        public TestataValidazioneXIstanzaCollection()
        {
            this.ItemType = typeof(TestataValidazioneXIstanza);
        }

        //Costruttore con provider
        public TestataValidazioneXIstanzaCollection(ITestataValidazioneXIstanzaProvider providerObj)
        {
            this.ItemType = typeof(TestataValidazioneXIstanza);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TestataValidazioneXIstanza this[int index]
        {
            get { return (TestataValidazioneXIstanza)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TestataValidazioneXIstanzaCollection GetChanges()
        {
            return (TestataValidazioneXIstanzaCollection)base.GetChanges();
        }

        [NonSerialized] private ITestataValidazioneXIstanzaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataValidazioneXIstanzaProvider Provider
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
        public int Add(TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            if (TestataValidazioneXIstanzaObj.Provider == null) TestataValidazioneXIstanzaObj.Provider = this.Provider;
            return base.Add(TestataValidazioneXIstanzaObj);
        }

        //AddCollection
        public void AddCollection(TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionObj)
        {
            foreach (TestataValidazioneXIstanza TestataValidazioneXIstanzaObj in TestataValidazioneXIstanzaCollectionObj)
                this.Add(TestataValidazioneXIstanzaObj);
        }

        //Insert
        public void Insert(int index, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            if (TestataValidazioneXIstanzaObj.Provider == null) TestataValidazioneXIstanzaObj.Provider = this.Provider;
            base.Insert(index, TestataValidazioneXIstanzaObj);
        }

        //CollectionGetById
        public TestataValidazioneXIstanza CollectionGetById(NullTypes.IntNT IdTestataValidazioneXIstanzaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTestataValidazioneXIstanza == IdTestataValidazioneXIstanzaValue))
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
        public TestataValidazioneXIstanzaCollection SubSelect(NullTypes.IntNT IdTestataValidazioneXIstanzaEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdTestataValidazioneEqualThis,
NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.StringNT NoteEqualThis)
        {
            TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionTemp = new TestataValidazioneXIstanzaCollection();
            foreach (TestataValidazioneXIstanza TestataValidazioneXIstanzaItem in this)
            {
                if (((IdTestataValidazioneXIstanzaEqualThis == null) || ((TestataValidazioneXIstanzaItem.IdTestataValidazioneXIstanza != null) && (TestataValidazioneXIstanzaItem.IdTestataValidazioneXIstanza.Value == IdTestataValidazioneXIstanzaEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((TestataValidazioneXIstanzaItem.CfInserimento != null) && (TestataValidazioneXIstanzaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TestataValidazioneXIstanzaItem.DataInserimento != null) && (TestataValidazioneXIstanzaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((TestataValidazioneXIstanzaItem.CfModifica != null) && (TestataValidazioneXIstanzaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((TestataValidazioneXIstanzaItem.DataModifica != null) && (TestataValidazioneXIstanzaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdTestataValidazioneEqualThis == null) || ((TestataValidazioneXIstanzaItem.IdTestataValidazione != null) && (TestataValidazioneXIstanzaItem.IdTestataValidazione.Value == IdTestataValidazioneEqualThis.Value))) &&
((IdIstanzaChecklistGenericaEqualThis == null) || ((TestataValidazioneXIstanzaItem.IdIstanzaChecklistGenerica != null) && (TestataValidazioneXIstanzaItem.IdIstanzaChecklistGenerica.Value == IdIstanzaChecklistGenericaEqualThis.Value))) && ((OrdineEqualThis == null) || ((TestataValidazioneXIstanzaItem.Ordine != null) && (TestataValidazioneXIstanzaItem.Ordine.Value == OrdineEqualThis.Value))) && ((NoteEqualThis == null) || ((TestataValidazioneXIstanzaItem.Note != null) && (TestataValidazioneXIstanzaItem.Note.Value == NoteEqualThis.Value))))
                {
                    TestataValidazioneXIstanzaCollectionTemp.Add(TestataValidazioneXIstanzaItem);
                }
            }
            return TestataValidazioneXIstanzaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TestataValidazioneXIstanzaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TestataValidazioneXIstanzaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTestataValidazioneXIstanza", TestataValidazioneXIstanzaObj.IdTestataValidazioneXIstanza);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", TestataValidazioneXIstanzaObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", TestataValidazioneXIstanzaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", TestataValidazioneXIstanzaObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", TestataValidazioneXIstanzaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTestataValidazione", TestataValidazioneXIstanzaObj.IdTestataValidazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIstanzaChecklistGenerica", TestataValidazioneXIstanzaObj.IdIstanzaChecklistGenerica);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", TestataValidazioneXIstanzaObj.Ordine);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", TestataValidazioneXIstanzaObj.Note);
        }
        //Insert
        private static int Insert(DbProvider db, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTestataValidazioneXIstanzaInsert", new string[] {"CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdTestataValidazione",
"IdIstanzaChecklistGenerica", "Ordine", "Note",


}, new string[] {"string", "DateTime",
"string", "DateTime", "int",
"int", "int", "string",


}, "");
                CompileIUCmd(false, insertCmd, TestataValidazioneXIstanzaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TestataValidazioneXIstanzaObj.IdTestataValidazioneXIstanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE_X_ISTANZA"]);
                    TestataValidazioneXIstanzaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    TestataValidazioneXIstanzaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
                }
                TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneXIstanzaObj.IsDirty = false;
                TestataValidazioneXIstanzaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataValidazioneXIstanzaUpdate", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdTestataValidazione",
"IdIstanzaChecklistGenerica", "Ordine", "Note",


}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "string",


}, "");
                CompileIUCmd(true, updateCmd, TestataValidazioneXIstanzaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    TestataValidazioneXIstanzaObj.DataModifica = d;
                }
                TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneXIstanzaObj.IsDirty = false;
                TestataValidazioneXIstanzaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            switch (TestataValidazioneXIstanzaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TestataValidazioneXIstanzaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TestataValidazioneXIstanzaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TestataValidazioneXIstanzaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataValidazioneXIstanzaUpdate", new string[] {"IdTestataValidazioneXIstanza", "CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdTestataValidazione",
"IdIstanzaChecklistGenerica", "Ordine", "Note",


}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "string",


}, "");
                IDbCommand insertCmd = db.InitCmd("ZTestataValidazioneXIstanzaInsert", new string[] {"CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdTestataValidazione",
"IdIstanzaChecklistGenerica", "Ordine", "Note",


}, new string[] {"string", "DateTime",
"string", "DateTime", "int",
"int", "int", "string",


}, "");
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneXIstanzaDelete", new string[] { "IdTestataValidazioneXIstanza" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataValidazioneXIstanzaCollectionObj.Count; i++)
                {
                    switch (TestataValidazioneXIstanzaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TestataValidazioneXIstanzaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TestataValidazioneXIstanzaCollectionObj[i].IdTestataValidazioneXIstanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE_X_ISTANZA"]);
                                    TestataValidazioneXIstanzaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    TestataValidazioneXIstanzaCollectionObj[i].Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TestataValidazioneXIstanzaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    TestataValidazioneXIstanzaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TestataValidazioneXIstanzaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanza", (SiarLibrary.NullTypes.IntNT)TestataValidazioneXIstanzaCollectionObj[i].IdTestataValidazioneXIstanza);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TestataValidazioneXIstanzaCollectionObj.Count; i++)
                {
                    if ((TestataValidazioneXIstanzaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneXIstanzaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataValidazioneXIstanzaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TestataValidazioneXIstanzaCollectionObj[i].IsDirty = false;
                        TestataValidazioneXIstanzaCollectionObj[i].IsPersistent = true;
                    }
                    if ((TestataValidazioneXIstanzaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TestataValidazioneXIstanzaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataValidazioneXIstanzaCollectionObj[i].IsDirty = false;
                        TestataValidazioneXIstanzaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TestataValidazioneXIstanza TestataValidazioneXIstanzaObj)
        {
            int returnValue = 0;
            if (TestataValidazioneXIstanzaObj.IsPersistent)
            {
                returnValue = Delete(db, TestataValidazioneXIstanzaObj.IdTestataValidazioneXIstanza);
            }
            TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TestataValidazioneXIstanzaObj.IsDirty = false;
            TestataValidazioneXIstanzaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTestataValidazioneXIstanzaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneXIstanzaDelete", new string[] { "IdTestataValidazioneXIstanza" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanza", (SiarLibrary.NullTypes.IntNT)IdTestataValidazioneXIstanzaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneXIstanzaDelete", new string[] { "IdTestataValidazioneXIstanza" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataValidazioneXIstanzaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanza", TestataValidazioneXIstanzaCollectionObj[i].IdTestataValidazioneXIstanza);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TestataValidazioneXIstanzaCollectionObj.Count; i++)
                {
                    if ((TestataValidazioneXIstanzaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneXIstanzaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataValidazioneXIstanzaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataValidazioneXIstanzaCollectionObj[i].IsDirty = false;
                        TestataValidazioneXIstanzaCollectionObj[i].IsPersistent = false;
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
        public static TestataValidazioneXIstanza GetById(DbProvider db, int IdTestataValidazioneXIstanzaValue)
        {
            TestataValidazioneXIstanza TestataValidazioneXIstanzaObj = null;
            IDbCommand readCmd = db.InitCmd("ZTestataValidazioneXIstanzaGetById", new string[] { "IdTestataValidazioneXIstanza" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanza", (SiarLibrary.NullTypes.IntNT)IdTestataValidazioneXIstanzaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TestataValidazioneXIstanzaObj = GetFromDatareader(db);
                TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneXIstanzaObj.IsDirty = false;
                TestataValidazioneXIstanzaObj.IsPersistent = true;
            }
            db.Close();
            return TestataValidazioneXIstanzaObj;
        }

        //getFromDatareader
        public static TestataValidazioneXIstanza GetFromDatareader(DbProvider db)
        {
            TestataValidazioneXIstanza TestataValidazioneXIstanzaObj = new TestataValidazioneXIstanza();
            TestataValidazioneXIstanzaObj.IdTestataValidazioneXIstanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE_X_ISTANZA"]);
            TestataValidazioneXIstanzaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            TestataValidazioneXIstanzaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            TestataValidazioneXIstanzaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            TestataValidazioneXIstanzaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            TestataValidazioneXIstanzaObj.IdTestataValidazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA_VALIDAZIONE"]);
            TestataValidazioneXIstanzaObj.IdIstanzaChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_CHECKLIST_GENERICA"]);
            TestataValidazioneXIstanzaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            TestataValidazioneXIstanzaObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            TestataValidazioneXIstanzaObj.Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
            TestataValidazioneXIstanzaObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            TestataValidazioneXIstanzaObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
            TestataValidazioneXIstanzaObj.CfValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_VALIDATORE"]);
            TestataValidazioneXIstanzaObj.NominativoValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_VALIDATORE"]);
            TestataValidazioneXIstanzaObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
            TestataValidazioneXIstanzaObj.CodFaseIstanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE_ISTANZA"]);
            TestataValidazioneXIstanzaObj.DescrizioneChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST"]);
            TestataValidazioneXIstanzaObj.FlagTemplateChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE_CHECKLIST"]);
            TestataValidazioneXIstanzaObj.IdFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_CHECKLIST"]);
            TestataValidazioneXIstanzaObj.IdTipoChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CHECKLIST"]);
            TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TestataValidazioneXIstanzaObj.IsDirty = false;
            TestataValidazioneXIstanzaObj.IsPersistent = true;
            return TestataValidazioneXIstanzaObj;
        }

        //Find Select

        public static TestataValidazioneXIstanzaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataValidazioneXIstanzaEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTestataValidazioneEqualThis,
SiarLibrary.NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis)

        {

            TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionObj = new TestataValidazioneXIstanzaCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatavalidazionexistanzafindselect", new string[] {"IdTestataValidazioneXIstanzaequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis",
"CfModificaequalthis", "DataModificaequalthis", "IdTestataValidazioneequalthis",
"IdIstanzaChecklistGenericaequalthis", "Ordineequalthis", "Noteequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanzaequalthis", IdTestataValidazioneXIstanzaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataValidazioneequalthis", IdTestataValidazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaChecklistGenericaequalthis", IdIstanzaChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            TestataValidazioneXIstanza TestataValidazioneXIstanzaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataValidazioneXIstanzaObj = GetFromDatareader(db);
                TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneXIstanzaObj.IsDirty = false;
                TestataValidazioneXIstanzaObj.IsPersistent = true;
                TestataValidazioneXIstanzaCollectionObj.Add(TestataValidazioneXIstanzaObj);
            }
            db.Close();
            return TestataValidazioneXIstanzaCollectionObj;
        }

        //Find Find

        public static TestataValidazioneXIstanzaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataValidazioneXIstanzaEqualThis, SiarLibrary.NullTypes.IntNT IdTestataValidazioneEqualThis, SiarLibrary.NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis,
SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis)

        {

            TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionObj = new TestataValidazioneXIstanzaCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatavalidazionexistanzafindfind", new string[] {"IdTestataValidazioneXIstanzaequalthis", "IdTestataValidazioneequalthis", "IdIstanzaChecklistGenericaequalthis",
"IdChecklistGenericaequalthis", "Autovalutazioneequalthis"}, new string[] {"int", "int", "int",
"int", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataValidazioneXIstanzaequalthis", IdTestataValidazioneXIstanzaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataValidazioneequalthis", IdTestataValidazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaChecklistGenericaequalthis", IdIstanzaChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
            TestataValidazioneXIstanza TestataValidazioneXIstanzaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataValidazioneXIstanzaObj = GetFromDatareader(db);
                TestataValidazioneXIstanzaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneXIstanzaObj.IsDirty = false;
                TestataValidazioneXIstanzaObj.IsPersistent = true;
                TestataValidazioneXIstanzaCollectionObj.Add(TestataValidazioneXIstanzaObj);
            }
            db.Close();
            return TestataValidazioneXIstanzaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TestataValidazioneXIstanzaCollectionProvider:ITestataValidazioneXIstanzaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataValidazioneXIstanzaCollectionProvider : ITestataValidazioneXIstanzaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TestataValidazioneXIstanza
        protected TestataValidazioneXIstanzaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TestataValidazioneXIstanzaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TestataValidazioneXIstanzaCollection(this);
        }

        //Costruttore 2: popola la collection
        public TestataValidazioneXIstanzaCollectionProvider(IntNT IdtestatavalidazionexistanzaEqualThis, IntNT IdtestatavalidazioneEqualThis, IntNT IdistanzachecklistgenericaEqualThis,
IntNT IdchecklistgenericaEqualThis, BoolNT AutovalutazioneEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdtestatavalidazionexistanzaEqualThis, IdtestatavalidazioneEqualThis, IdistanzachecklistgenericaEqualThis,
IdchecklistgenericaEqualThis, AutovalutazioneEqualThis);
        }

        //Costruttore3: ha in input testatavalidazionexistanzaCollectionObj - non popola la collection
        public TestataValidazioneXIstanzaCollectionProvider(TestataValidazioneXIstanzaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TestataValidazioneXIstanzaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TestataValidazioneXIstanzaCollection(this);
        }

        //Get e Set
        public TestataValidazioneXIstanzaCollection CollectionObj
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
        public int SaveCollection(TestataValidazioneXIstanzaCollection collectionObj)
        {
            return TestataValidazioneXIstanzaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TestataValidazioneXIstanza testatavalidazionexistanzaObj)
        {
            return TestataValidazioneXIstanzaDAL.Save(_dbProviderObj, testatavalidazionexistanzaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TestataValidazioneXIstanzaCollection collectionObj)
        {
            return TestataValidazioneXIstanzaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TestataValidazioneXIstanza testatavalidazionexistanzaObj)
        {
            return TestataValidazioneXIstanzaDAL.Delete(_dbProviderObj, testatavalidazionexistanzaObj);
        }

        //getById
        public TestataValidazioneXIstanza GetById(IntNT IdTestataValidazioneXIstanzaValue)
        {
            TestataValidazioneXIstanza TestataValidazioneXIstanzaTemp = TestataValidazioneXIstanzaDAL.GetById(_dbProviderObj, IdTestataValidazioneXIstanzaValue);
            if (TestataValidazioneXIstanzaTemp != null) TestataValidazioneXIstanzaTemp.Provider = this;
            return TestataValidazioneXIstanzaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public TestataValidazioneXIstanzaCollection Select(IntNT IdtestatavalidazionexistanzaEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdtestatavalidazioneEqualThis,
IntNT IdistanzachecklistgenericaEqualThis, IntNT OrdineEqualThis, StringNT NoteEqualThis)
        {
            TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionTemp = TestataValidazioneXIstanzaDAL.Select(_dbProviderObj, IdtestatavalidazionexistanzaEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis,
CfmodificaEqualThis, DatamodificaEqualThis, IdtestatavalidazioneEqualThis,
IdistanzachecklistgenericaEqualThis, OrdineEqualThis, NoteEqualThis);
            TestataValidazioneXIstanzaCollectionTemp.Provider = this;
            return TestataValidazioneXIstanzaCollectionTemp;
        }

        //Find: popola la collection
        public TestataValidazioneXIstanzaCollection Find(IntNT IdtestatavalidazionexistanzaEqualThis, IntNT IdtestatavalidazioneEqualThis, IntNT IdistanzachecklistgenericaEqualThis,
IntNT IdchecklistgenericaEqualThis, BoolNT AutovalutazioneEqualThis)
        {
            TestataValidazioneXIstanzaCollection TestataValidazioneXIstanzaCollectionTemp = TestataValidazioneXIstanzaDAL.Find(_dbProviderObj, IdtestatavalidazionexistanzaEqualThis, IdtestatavalidazioneEqualThis, IdistanzachecklistgenericaEqualThis,
IdchecklistgenericaEqualThis, AutovalutazioneEqualThis);
            TestataValidazioneXIstanzaCollectionTemp.Provider = this;
            return TestataValidazioneXIstanzaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TESTATA_VALIDAZIONE_X_ISTANZA>
  <ViewName>VTESTATA_VALIDAZIONE_X_ISTANZA</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE ">
      <ID_TESTATA_VALIDAZIONE_X_ISTANZA>Equal</ID_TESTATA_VALIDAZIONE_X_ISTANZA>
      <ID_TESTATA_VALIDAZIONE>Equal</ID_TESTATA_VALIDAZIONE>
      <ID_ISTANZA_CHECKLIST_GENERICA>Equal</ID_ISTANZA_CHECKLIST_GENERICA>
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <AUTOVALUTAZIONE>Equal</AUTOVALUTAZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TESTATA_VALIDAZIONE_X_ISTANZA>
*/
