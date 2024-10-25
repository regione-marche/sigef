using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per SchedaXChecklist
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ISchedaXChecklistProvider
    {
        int Save(SchedaXChecklist SchedaXChecklistObj);
        int SaveCollection(SchedaXChecklistCollection collectionObj);
        int Delete(SchedaXChecklist SchedaXChecklistObj);
        int DeleteCollection(SchedaXChecklistCollection collectionObj);
    }
    /// <summary>
    /// Summary description for SchedaXChecklist
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class SchedaXChecklist : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdSchedaXChecklist;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.IntNT _IdChecklistPadre;
        private NullTypes.IntNT _IdChecklistFiglio;
        private NullTypes.IntNT _Ordine;
        private NullTypes.BoolNT _Obbligatorio;
        private NullTypes.DecimalNT _Peso;
        private NullTypes.StringNT _DescrizioneChecklist;
        private NullTypes.BoolNT _FlagTemplateChecklist;
        private NullTypes.IntNT _IdTipoChecklist;
        private NullTypes.StringNT _DescrizioneTipoChecklist;
        private NullTypes.BoolNT _ContieneVociChecklist;
        private NullTypes.BoolNT _SchedaChecklist;
        private NullTypes.StringNT _IdFiltroChecklist;
        private NullTypes.StringNT _DescrizioneFiltroChecklist;
        private NullTypes.IntNT _OrdineFiltroChecklist;
        private NullTypes.IntNT _IdTipoScheda;
        private NullTypes.StringNT _DescrizioneTipoScheda;
        private NullTypes.BoolNT _ContieneVociScheda;
        private NullTypes.BoolNT _SchedaScheda;
        private NullTypes.StringNT _IdFiltroScheda;
        private NullTypes.StringNT _DescrizioneFiltroScheda;
        private NullTypes.IntNT _OrdineFiltroScheda;
        [NonSerialized] private ISchedaXChecklistProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISchedaXChecklistProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public SchedaXChecklist()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:ID_CHECKLIST_FIGLIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdChecklistFiglio
        {
            get { return _IdChecklistFiglio; }
            set
            {
                if (IdChecklistFiglio != value)
                {
                    _IdChecklistFiglio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE
        /// Tipo sul db:INT
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
        /// Corrisponde al campo:OBBLIGATORIO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Obbligatorio
        {
            get { return _Obbligatorio; }
            set
            {
                if (Obbligatorio != value)
                {
                    _Obbligatorio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PESO
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT Peso
        {
            get { return _Peso; }
            set
            {
                if (Peso != value)
                {
                    _Peso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_CHECKLIST
        /// Tipo sul db:VARCHAR(-1)
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

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_TIPO_CHECKLIST
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DescrizioneTipoChecklist
        {
            get { return _DescrizioneTipoChecklist; }
            set
            {
                if (DescrizioneTipoChecklist != value)
                {
                    _DescrizioneTipoChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTIENE_VOCI_CHECKLIST
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT ContieneVociChecklist
        {
            get { return _ContieneVociChecklist; }
            set
            {
                if (ContieneVociChecklist != value)
                {
                    _ContieneVociChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SCHEDA_CHECKLIST
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SchedaChecklist
        {
            get { return _SchedaChecklist; }
            set
            {
                if (SchedaChecklist != value)
                {
                    _SchedaChecklist = value;
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
        /// Corrisponde al campo:DESCRIZIONE_FILTRO_CHECKLIST
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DescrizioneFiltroChecklist
        {
            get { return _DescrizioneFiltroChecklist; }
            set
            {
                if (DescrizioneFiltroChecklist != value)
                {
                    _DescrizioneFiltroChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_FILTRO_CHECKLIST
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineFiltroChecklist
        {
            get { return _OrdineFiltroChecklist; }
            set
            {
                if (OrdineFiltroChecklist != value)
                {
                    _OrdineFiltroChecklist = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_SCHEDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoScheda
        {
            get { return _IdTipoScheda; }
            set
            {
                if (IdTipoScheda != value)
                {
                    _IdTipoScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_TIPO_SCHEDA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DescrizioneTipoScheda
        {
            get { return _DescrizioneTipoScheda; }
            set
            {
                if (DescrizioneTipoScheda != value)
                {
                    _DescrizioneTipoScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTIENE_VOCI_SCHEDA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT ContieneVociScheda
        {
            get { return _ContieneVociScheda; }
            set
            {
                if (ContieneVociScheda != value)
                {
                    _ContieneVociScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SCHEDA_SCHEDA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SchedaScheda
        {
            get { return _SchedaScheda; }
            set
            {
                if (SchedaScheda != value)
                {
                    _SchedaScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILTRO_SCHEDA
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT IdFiltroScheda
        {
            get { return _IdFiltroScheda; }
            set
            {
                if (IdFiltroScheda != value)
                {
                    _IdFiltroScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_FILTRO_SCHEDA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DescrizioneFiltroScheda
        {
            get { return _DescrizioneFiltroScheda; }
            set
            {
                if (DescrizioneFiltroScheda != value)
                {
                    _DescrizioneFiltroScheda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_FILTRO_SCHEDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineFiltroScheda
        {
            get { return _OrdineFiltroScheda; }
            set
            {
                if (OrdineFiltroScheda != value)
                {
                    _OrdineFiltroScheda = value;
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
    /// Summary description for SchedaXChecklistCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SchedaXChecklistCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private SchedaXChecklistCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((SchedaXChecklist)info.GetValue(i.ToString(), typeof(SchedaXChecklist)));
            }
        }

        //Costruttore
        public SchedaXChecklistCollection()
        {
            this.ItemType = typeof(SchedaXChecklist);
        }

        //Costruttore con provider
        public SchedaXChecklistCollection(ISchedaXChecklistProvider providerObj)
        {
            this.ItemType = typeof(SchedaXChecklist);
            this.Provider = providerObj;
        }

        //Get e Set
        public new SchedaXChecklist this[int index]
        {
            get { return (SchedaXChecklist)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new SchedaXChecklistCollection GetChanges()
        {
            return (SchedaXChecklistCollection)base.GetChanges();
        }

        [NonSerialized] private ISchedaXChecklistProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISchedaXChecklistProvider Provider
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
        public int Add(SchedaXChecklist SchedaXChecklistObj)
        {
            if (SchedaXChecklistObj.Provider == null) SchedaXChecklistObj.Provider = this.Provider;
            return base.Add(SchedaXChecklistObj);
        }

        //AddCollection
        public void AddCollection(SchedaXChecklistCollection SchedaXChecklistCollectionObj)
        {
            foreach (SchedaXChecklist SchedaXChecklistObj in SchedaXChecklistCollectionObj)
                this.Add(SchedaXChecklistObj);
        }

        //Insert
        public void Insert(int index, SchedaXChecklist SchedaXChecklistObj)
        {
            if (SchedaXChecklistObj.Provider == null) SchedaXChecklistObj.Provider = this.Provider;
            base.Insert(index, SchedaXChecklistObj);
        }

        //CollectionGetById
        public SchedaXChecklist CollectionGetById(NullTypes.IntNT IdSchedaXChecklistValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdSchedaXChecklist == IdSchedaXChecklistValue))
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
        public SchedaXChecklistCollection SubSelect(NullTypes.IntNT IdSchedaXChecklistEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdChecklistPadreEqualThis,
NullTypes.IntNT IdChecklistFiglioEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT ObbligatorioEqualThis,
NullTypes.DecimalNT PesoEqualThis)
        {
            SchedaXChecklistCollection SchedaXChecklistCollectionTemp = new SchedaXChecklistCollection();
            foreach (SchedaXChecklist SchedaXChecklistItem in this)
            {
                if (((IdSchedaXChecklistEqualThis == null) || ((SchedaXChecklistItem.IdSchedaXChecklist != null) && (SchedaXChecklistItem.IdSchedaXChecklist.Value == IdSchedaXChecklistEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((SchedaXChecklistItem.CfInserimento != null) && (SchedaXChecklistItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((SchedaXChecklistItem.DataInserimento != null) && (SchedaXChecklistItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((SchedaXChecklistItem.CfModifica != null) && (SchedaXChecklistItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((SchedaXChecklistItem.DataModifica != null) && (SchedaXChecklistItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdChecklistPadreEqualThis == null) || ((SchedaXChecklistItem.IdChecklistPadre != null) && (SchedaXChecklistItem.IdChecklistPadre.Value == IdChecklistPadreEqualThis.Value))) &&
((IdChecklistFiglioEqualThis == null) || ((SchedaXChecklistItem.IdChecklistFiglio != null) && (SchedaXChecklistItem.IdChecklistFiglio.Value == IdChecklistFiglioEqualThis.Value))) && ((OrdineEqualThis == null) || ((SchedaXChecklistItem.Ordine != null) && (SchedaXChecklistItem.Ordine.Value == OrdineEqualThis.Value))) && ((ObbligatorioEqualThis == null) || ((SchedaXChecklistItem.Obbligatorio != null) && (SchedaXChecklistItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) &&
((PesoEqualThis == null) || ((SchedaXChecklistItem.Peso != null) && (SchedaXChecklistItem.Peso.Value == PesoEqualThis.Value))))
                {
                    SchedaXChecklistCollectionTemp.Add(SchedaXChecklistItem);
                }
            }
            return SchedaXChecklistCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for SchedaXChecklistDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class SchedaXChecklistDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SchedaXChecklist SchedaXChecklistObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdSchedaXChecklist", SchedaXChecklistObj.IdSchedaXChecklist);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", SchedaXChecklistObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", SchedaXChecklistObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", SchedaXChecklistObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", SchedaXChecklistObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistPadre", SchedaXChecklistObj.IdChecklistPadre);
            DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistFiglio", SchedaXChecklistObj.IdChecklistFiglio);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", SchedaXChecklistObj.Ordine);
            DbProvider.SetCmdParam(cmd, firstChar + "Obbligatorio", SchedaXChecklistObj.Obbligatorio);
            DbProvider.SetCmdParam(cmd, firstChar + "Peso", SchedaXChecklistObj.Peso);
        }
        //Insert
        private static int Insert(DbProvider db, SchedaXChecklist SchedaXChecklistObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZSchedaXChecklistInsert", new string[] {"CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdChecklistPadre",
"IdChecklistFiglio", "Ordine", "Obbligatorio",
"Peso",



}, new string[] {"string", "DateTime",
"string", "DateTime", "int",
"int", "int", "bool",
"decimal",



}, "");
                CompileIUCmd(false, insertCmd, SchedaXChecklistObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    SchedaXChecklistObj.IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
                    SchedaXChecklistObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    SchedaXChecklistObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
                }
                SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SchedaXChecklistObj.IsDirty = false;
                SchedaXChecklistObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, SchedaXChecklist SchedaXChecklistObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSchedaXChecklistUpdate", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdChecklistPadre",
"IdChecklistFiglio", "Ordine", "Obbligatorio",
"Peso",



}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "bool",
"decimal",



}, "");
                CompileIUCmd(true, updateCmd, SchedaXChecklistObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    SchedaXChecklistObj.DataModifica = d;
                }
                SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SchedaXChecklistObj.IsDirty = false;
                SchedaXChecklistObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, SchedaXChecklist SchedaXChecklistObj)
        {
            switch (SchedaXChecklistObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, SchedaXChecklistObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, SchedaXChecklistObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, SchedaXChecklistObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, SchedaXChecklistCollection SchedaXChecklistCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSchedaXChecklistUpdate", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdChecklistPadre",
"IdChecklistFiglio", "Ordine", "Obbligatorio",
"Peso",



}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "bool",
"decimal",



}, "");
                IDbCommand insertCmd = db.InitCmd("ZSchedaXChecklistInsert", new string[] {"CfInserimento", "DataInserimento",
"CfModifica", "DataModifica", "IdChecklistPadre",
"IdChecklistFiglio", "Ordine", "Obbligatorio",
"Peso",



}, new string[] {"string", "DateTime",
"string", "DateTime", "int",
"int", "int", "bool",
"decimal",



}, "");
                IDbCommand deleteCmd = db.InitCmd("ZSchedaXChecklistDelete", new string[] { "IdSchedaXChecklist" }, new string[] { "int" }, "");
                for (int i = 0; i < SchedaXChecklistCollectionObj.Count; i++)
                {
                    switch (SchedaXChecklistCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, SchedaXChecklistCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    SchedaXChecklistCollectionObj[i].IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
                                    SchedaXChecklistCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    SchedaXChecklistCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, SchedaXChecklistCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    SchedaXChecklistCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (SchedaXChecklistCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSchedaXChecklist", (SiarLibrary.NullTypes.IntNT)SchedaXChecklistCollectionObj[i].IdSchedaXChecklist);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < SchedaXChecklistCollectionObj.Count; i++)
                {
                    if ((SchedaXChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SchedaXChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        SchedaXChecklistCollectionObj[i].IsDirty = false;
                        SchedaXChecklistCollectionObj[i].IsPersistent = true;
                    }
                    if ((SchedaXChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        SchedaXChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SchedaXChecklistCollectionObj[i].IsDirty = false;
                        SchedaXChecklistCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, SchedaXChecklist SchedaXChecklistObj)
        {
            int returnValue = 0;
            if (SchedaXChecklistObj.IsPersistent)
            {
                returnValue = Delete(db, SchedaXChecklistObj.IdSchedaXChecklist);
            }
            SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            SchedaXChecklistObj.IsDirty = false;
            SchedaXChecklistObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdSchedaXChecklistValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSchedaXChecklistDelete", new string[] { "IdSchedaXChecklist" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSchedaXChecklist", (SiarLibrary.NullTypes.IntNT)IdSchedaXChecklistValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, SchedaXChecklistCollection SchedaXChecklistCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSchedaXChecklistDelete", new string[] { "IdSchedaXChecklist" }, new string[] { "int" }, "");
                for (int i = 0; i < SchedaXChecklistCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSchedaXChecklist", SchedaXChecklistCollectionObj[i].IdSchedaXChecklist);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < SchedaXChecklistCollectionObj.Count; i++)
                {
                    if ((SchedaXChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SchedaXChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SchedaXChecklistCollectionObj[i].IsDirty = false;
                        SchedaXChecklistCollectionObj[i].IsPersistent = false;
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
        public static SchedaXChecklist GetById(DbProvider db, int IdSchedaXChecklistValue)
        {
            SchedaXChecklist SchedaXChecklistObj = null;
            IDbCommand readCmd = db.InitCmd("ZSchedaXChecklistGetById", new string[] { "IdSchedaXChecklist" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdSchedaXChecklist", (SiarLibrary.NullTypes.IntNT)IdSchedaXChecklistValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                SchedaXChecklistObj = GetFromDatareader(db);
                SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SchedaXChecklistObj.IsDirty = false;
                SchedaXChecklistObj.IsPersistent = true;
            }
            db.Close();
            return SchedaXChecklistObj;
        }

        //getFromDatareader
        public static SchedaXChecklist GetFromDatareader(DbProvider db)
        {
            SchedaXChecklist SchedaXChecklistObj = new SchedaXChecklist();
            SchedaXChecklistObj.IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
            SchedaXChecklistObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            SchedaXChecklistObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            SchedaXChecklistObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            SchedaXChecklistObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            SchedaXChecklistObj.IdChecklistPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_PADRE"]);
            SchedaXChecklistObj.IdChecklistFiglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_FIGLIO"]);
            SchedaXChecklistObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            SchedaXChecklistObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
            SchedaXChecklistObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
            SchedaXChecklistObj.DescrizioneChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST"]);
            SchedaXChecklistObj.FlagTemplateChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE_CHECKLIST"]);
            SchedaXChecklistObj.IdTipoChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CHECKLIST"]);
            SchedaXChecklistObj.DescrizioneTipoChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_CHECKLIST"]);
            SchedaXChecklistObj.ContieneVociChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_CHECKLIST"]);
            SchedaXChecklistObj.SchedaChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_CHECKLIST"]);
            SchedaXChecklistObj.IdFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_CHECKLIST"]);
            SchedaXChecklistObj.DescrizioneFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_CHECKLIST"]);
            SchedaXChecklistObj.OrdineFiltroChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_CHECKLIST"]);
            SchedaXChecklistObj.IdTipoScheda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_SCHEDA"]);
            SchedaXChecklistObj.DescrizioneTipoScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_SCHEDA"]);
            SchedaXChecklistObj.ContieneVociScheda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_SCHEDA"]);
            SchedaXChecklistObj.SchedaScheda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_SCHEDA"]);
            SchedaXChecklistObj.IdFiltroScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_SCHEDA"]);
            SchedaXChecklistObj.DescrizioneFiltroScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_SCHEDA"]);
            SchedaXChecklistObj.OrdineFiltroScheda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_SCHEDA"]);
            SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            SchedaXChecklistObj.IsDirty = false;
            SchedaXChecklistObj.IsPersistent = true;
            return SchedaXChecklistObj;
        }

        //Find Select

        public static SchedaXChecklistCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis,
SiarLibrary.NullTypes.IntNT IdChecklistFiglioEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis,
SiarLibrary.NullTypes.DecimalNT PesoEqualThis)

        {

            SchedaXChecklistCollection SchedaXChecklistCollectionObj = new SchedaXChecklistCollection();

            IDbCommand findCmd = db.InitCmd("Zschedaxchecklistfindselect", new string[] {"IdSchedaXChecklistequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis",
"CfModificaequalthis", "DataModificaequalthis", "IdChecklistPadreequalthis",
"IdChecklistFiglioequalthis", "Ordineequalthis", "Obbligatorioequalthis",
"Pesoequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "int", "bool",
"decimal"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistFiglioequalthis", IdChecklistFiglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
            SchedaXChecklist SchedaXChecklistObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SchedaXChecklistObj = GetFromDatareader(db);
                SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SchedaXChecklistObj.IsDirty = false;
                SchedaXChecklistObj.IsPersistent = true;
                SchedaXChecklistCollectionObj.Add(SchedaXChecklistObj);
            }
            db.Close();
            return SchedaXChecklistCollectionObj;
        }

        //Find Find

        public static SchedaXChecklistCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistFiglioEqualThis)

        {

            SchedaXChecklistCollection SchedaXChecklistCollectionObj = new SchedaXChecklistCollection();

            IDbCommand findCmd = db.InitCmd("Zschedaxchecklistfindfind", new string[] { "IdSchedaXChecklistequalthis", "IdChecklistPadreequalthis", "IdChecklistFiglioequalthis" }, new string[] { "int", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistFiglioequalthis", IdChecklistFiglioEqualThis);
            SchedaXChecklist SchedaXChecklistObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SchedaXChecklistObj = GetFromDatareader(db);
                SchedaXChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SchedaXChecklistObj.IsDirty = false;
                SchedaXChecklistObj.IsPersistent = true;
                SchedaXChecklistCollectionObj.Add(SchedaXChecklistObj);
            }
            db.Close();
            return SchedaXChecklistCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for SchedaXChecklistCollectionProvider:ISchedaXChecklistProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SchedaXChecklistCollectionProvider : ISchedaXChecklistProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di SchedaXChecklist
        protected SchedaXChecklistCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public SchedaXChecklistCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new SchedaXChecklistCollection(this);
        }

        //Costruttore 2: popola la collection
        public SchedaXChecklistCollectionProvider(IntNT IdschedaxchecklistEqualThis, IntNT IdchecklistpadreEqualThis, IntNT IdchecklistfiglioEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdschedaxchecklistEqualThis, IdchecklistpadreEqualThis, IdchecklistfiglioEqualThis);
        }

        //Costruttore3: ha in input schedaxchecklistCollectionObj - non popola la collection
        public SchedaXChecklistCollectionProvider(SchedaXChecklistCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public SchedaXChecklistCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new SchedaXChecklistCollection(this);
        }

        //Get e Set
        public SchedaXChecklistCollection CollectionObj
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
        public int SaveCollection(SchedaXChecklistCollection collectionObj)
        {
            return SchedaXChecklistDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(SchedaXChecklist schedaxchecklistObj)
        {
            return SchedaXChecklistDAL.Save(_dbProviderObj, schedaxchecklistObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(SchedaXChecklistCollection collectionObj)
        {
            return SchedaXChecklistDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(SchedaXChecklist schedaxchecklistObj)
        {
            return SchedaXChecklistDAL.Delete(_dbProviderObj, schedaxchecklistObj);
        }

        //getById
        public SchedaXChecklist GetById(IntNT IdSchedaXChecklistValue)
        {
            SchedaXChecklist SchedaXChecklistTemp = SchedaXChecklistDAL.GetById(_dbProviderObj, IdSchedaXChecklistValue);
            if (SchedaXChecklistTemp != null) SchedaXChecklistTemp.Provider = this;
            return SchedaXChecklistTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public SchedaXChecklistCollection Select(IntNT IdschedaxchecklistEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdchecklistpadreEqualThis,
IntNT IdchecklistfiglioEqualThis, IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis,
DecimalNT PesoEqualThis)
        {
            SchedaXChecklistCollection SchedaXChecklistCollectionTemp = SchedaXChecklistDAL.Select(_dbProviderObj, IdschedaxchecklistEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis,
CfmodificaEqualThis, DatamodificaEqualThis, IdchecklistpadreEqualThis,
IdchecklistfiglioEqualThis, OrdineEqualThis, ObbligatorioEqualThis,
PesoEqualThis);
            SchedaXChecklistCollectionTemp.Provider = this;
            return SchedaXChecklistCollectionTemp;
        }

        //Find: popola la collection
        public SchedaXChecklistCollection Find(IntNT IdschedaxchecklistEqualThis, IntNT IdchecklistpadreEqualThis, IntNT IdchecklistfiglioEqualThis)
        {
            SchedaXChecklistCollection SchedaXChecklistCollectionTemp = SchedaXChecklistDAL.Find(_dbProviderObj, IdschedaxchecklistEqualThis, IdchecklistpadreEqualThis, IdchecklistfiglioEqualThis);
            SchedaXChecklistCollectionTemp.Provider = this;
            return SchedaXChecklistCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCHEDA_X_CHECKLIST>
  <ViewName>VSCHEDA_X_CHECKLIST</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_SCHEDA_X_CHECKLIST>Equal</ID_SCHEDA_X_CHECKLIST>
      <ID_CHECKLIST_PADRE>Equal</ID_CHECKLIST_PADRE>
      <ID_CHECKLIST_FIGLIO>Equal</ID_CHECKLIST_FIGLIO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SCHEDA_X_CHECKLIST>
*/
