using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DomandaPagamentoLiquidazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDomandaPagamentoLiquidazioneProvider
    {
        int Save(DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj);
        int SaveCollection(DomandaPagamentoLiquidazioneCollection collectionObj);
        int Delete(DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj);
        int DeleteCollection(DomandaPagamentoLiquidazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DomandaPagamentoLiquidazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DomandaPagamentoLiquidazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdImpresaBeneficiaria;
        private NullTypes.IntNT _IdDecreto;
        private NullTypes.DecimalNT _RichiestaMandatoImporto;
        private NullTypes.StringNT _RichiestaMandatoSegnatura;
        private NullTypes.DatetimeNT _RichiestaMandatoData;
        private NullTypes.StringNT _MandatoNumero;
        private NullTypes.DatetimeNT _MandatoData;
        private NullTypes.DecimalNT _MandatoImporto;
        private NullTypes.IntNT _MandatoIdFile;
        private NullTypes.DatetimeNT _QuietanzaData;
        private NullTypes.DecimalNT _QuietanzaImporto;
        private NullTypes.BoolNT _Liquidato;
        [NonSerialized]
        private IDomandaPagamentoLiquidazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaPagamentoLiquidazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DomandaPagamentoLiquidazione()
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
        /// Corrisponde al campo:ID_IMPRESA_BENEFICIARIA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaBeneficiaria
        {
            get { return _IdImpresaBeneficiaria; }
            set
            {
                if (IdImpresaBeneficiaria != value)
                {
                    _IdImpresaBeneficiaria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DECRETO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDecreto
        {
            get { return _IdDecreto; }
            set
            {
                if (IdDecreto != value)
                {
                    _IdDecreto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICHIESTA_MANDATO_IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT RichiestaMandatoImporto
        {
            get { return _RichiestaMandatoImporto; }
            set
            {
                if (RichiestaMandatoImporto != value)
                {
                    _RichiestaMandatoImporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICHIESTA_MANDATO_SEGNATURA
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT RichiestaMandatoSegnatura
        {
            get { return _RichiestaMandatoSegnatura; }
            set
            {
                if (RichiestaMandatoSegnatura != value)
                {
                    _RichiestaMandatoSegnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RICHIESTA_MANDATO_DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT RichiestaMandatoData
        {
            get { return _RichiestaMandatoData; }
            set
            {
                if (RichiestaMandatoData != value)
                {
                    _RichiestaMandatoData = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MANDATO_NUMERO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT MandatoNumero
        {
            get { return _MandatoNumero; }
            set
            {
                if (MandatoNumero != value)
                {
                    _MandatoNumero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MANDATO_DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT MandatoData
        {
            get { return _MandatoData; }
            set
            {
                if (MandatoData != value)
                {
                    _MandatoData = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MANDATO_IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT MandatoImporto
        {
            get { return _MandatoImporto; }
            set
            {
                if (MandatoImporto != value)
                {
                    _MandatoImporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MANDATO_ID_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT MandatoIdFile
        {
            get { return _MandatoIdFile; }
            set
            {
                if (MandatoIdFile != value)
                {
                    _MandatoIdFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUIETANZA_DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT QuietanzaData
        {
            get { return _QuietanzaData; }
            set
            {
                if (QuietanzaData != value)
                {
                    _QuietanzaData = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUIETANZA_IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT QuietanzaImporto
        {
            get { return _QuietanzaImporto; }
            set
            {
                if (QuietanzaImporto != value)
                {
                    _QuietanzaImporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LIQUIDATO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Liquidato
        {
            get { return _Liquidato; }
            set
            {
                if (Liquidato != value)
                {
                    _Liquidato = value;
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
    /// Summary description for DomandaPagamentoLiquidazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaPagamentoLiquidazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DomandaPagamentoLiquidazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DomandaPagamentoLiquidazione)info.GetValue(i.ToString(), typeof(DomandaPagamentoLiquidazione)));
            }
        }

        //Costruttore
        public DomandaPagamentoLiquidazioneCollection()
        {
            this.ItemType = typeof(DomandaPagamentoLiquidazione);
        }

        //Costruttore con provider
        public DomandaPagamentoLiquidazioneCollection(IDomandaPagamentoLiquidazioneProvider providerObj)
        {
            this.ItemType = typeof(DomandaPagamentoLiquidazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DomandaPagamentoLiquidazione this[int index]
        {
            get { return (DomandaPagamentoLiquidazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DomandaPagamentoLiquidazioneCollection GetChanges()
        {
            return (DomandaPagamentoLiquidazioneCollection)base.GetChanges();
        }

        [NonSerialized]
        private IDomandaPagamentoLiquidazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaPagamentoLiquidazioneProvider Provider
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
        public int Add(DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            if (DomandaPagamentoLiquidazioneObj.Provider == null) DomandaPagamentoLiquidazioneObj.Provider = this.Provider;
            return base.Add(DomandaPagamentoLiquidazioneObj);
        }

        //AddCollection
        public void AddCollection(DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj)
        {
            foreach (DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj in DomandaPagamentoLiquidazioneCollectionObj)
                this.Add(DomandaPagamentoLiquidazioneObj);
        }

        //Insert
        public void Insert(int index, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            if (DomandaPagamentoLiquidazioneObj.Provider == null) DomandaPagamentoLiquidazioneObj.Provider = this.Provider;
            base.Insert(index, DomandaPagamentoLiquidazioneObj);
        }

        //CollectionGetById
        public DomandaPagamentoLiquidazione CollectionGetById(NullTypes.IntNT IdValue)
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
        public DomandaPagamentoLiquidazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdImpresaBeneficiariaEqualThis, NullTypes.IntNT IdDecretoEqualThis, NullTypes.DecimalNT RichiestaMandatoImportoEqualThis,
NullTypes.StringNT RichiestaMandatoSegnaturaEqualThis, NullTypes.DatetimeNT RichiestaMandatoDataEqualThis, NullTypes.StringNT MandatoNumeroEqualThis,
NullTypes.DatetimeNT MandatoDataEqualThis, NullTypes.DecimalNT MandatoImportoEqualThis, NullTypes.IntNT MandatoIdFileEqualThis,
NullTypes.DatetimeNT QuietanzaDataEqualThis, NullTypes.DecimalNT QuietanzaImportoEqualThis, NullTypes.BoolNT LiquidatoEqualThis)
        {
            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionTemp = new DomandaPagamentoLiquidazioneCollection();
            foreach (DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneItem in this)
            {
                if (((IdEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.Id != null) && (DomandaPagamentoLiquidazioneItem.Id.Value == IdEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.IdDomandaPagamento != null) && (DomandaPagamentoLiquidazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.IdProgetto != null) && (DomandaPagamentoLiquidazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdImpresaBeneficiariaEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.IdImpresaBeneficiaria != null) && (DomandaPagamentoLiquidazioneItem.IdImpresaBeneficiaria.Value == IdImpresaBeneficiariaEqualThis.Value))) && ((IdDecretoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.IdDecreto != null) && (DomandaPagamentoLiquidazioneItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && ((RichiestaMandatoImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.RichiestaMandatoImporto != null) && (DomandaPagamentoLiquidazioneItem.RichiestaMandatoImporto.Value == RichiestaMandatoImportoEqualThis.Value))) &&
((RichiestaMandatoSegnaturaEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.RichiestaMandatoSegnatura != null) && (DomandaPagamentoLiquidazioneItem.RichiestaMandatoSegnatura.Value == RichiestaMandatoSegnaturaEqualThis.Value))) && ((RichiestaMandatoDataEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.RichiestaMandatoData != null) && (DomandaPagamentoLiquidazioneItem.RichiestaMandatoData.Value == RichiestaMandatoDataEqualThis.Value))) && ((MandatoNumeroEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.MandatoNumero != null) && (DomandaPagamentoLiquidazioneItem.MandatoNumero.Value == MandatoNumeroEqualThis.Value))) &&
((MandatoDataEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.MandatoData != null) && (DomandaPagamentoLiquidazioneItem.MandatoData.Value == MandatoDataEqualThis.Value))) && ((MandatoImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.MandatoImporto != null) && (DomandaPagamentoLiquidazioneItem.MandatoImporto.Value == MandatoImportoEqualThis.Value))) && ((MandatoIdFileEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.MandatoIdFile != null) && (DomandaPagamentoLiquidazioneItem.MandatoIdFile.Value == MandatoIdFileEqualThis.Value))) &&
((QuietanzaDataEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.QuietanzaData != null) && (DomandaPagamentoLiquidazioneItem.QuietanzaData.Value == QuietanzaDataEqualThis.Value))) && ((QuietanzaImportoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.QuietanzaImporto != null) && (DomandaPagamentoLiquidazioneItem.QuietanzaImporto.Value == QuietanzaImportoEqualThis.Value))) && ((LiquidatoEqualThis == null) || ((DomandaPagamentoLiquidazioneItem.Liquidato != null) && (DomandaPagamentoLiquidazioneItem.Liquidato.Value == LiquidatoEqualThis.Value))))
                {
                    DomandaPagamentoLiquidazioneCollectionTemp.Add(DomandaPagamentoLiquidazioneItem);
                }
            }
            return DomandaPagamentoLiquidazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DomandaPagamentoLiquidazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DomandaPagamentoLiquidazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", DomandaPagamentoLiquidazioneObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DomandaPagamentoLiquidazioneObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DomandaPagamentoLiquidazioneObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresaBeneficiaria", DomandaPagamentoLiquidazioneObj.IdImpresaBeneficiaria);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDecreto", DomandaPagamentoLiquidazioneObj.IdDecreto);
            DbProvider.SetCmdParam(cmd, firstChar + "RichiestaMandatoImporto", DomandaPagamentoLiquidazioneObj.RichiestaMandatoImporto);
            DbProvider.SetCmdParam(cmd, firstChar + "RichiestaMandatoSegnatura", DomandaPagamentoLiquidazioneObj.RichiestaMandatoSegnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "RichiestaMandatoData", DomandaPagamentoLiquidazioneObj.RichiestaMandatoData);
            DbProvider.SetCmdParam(cmd, firstChar + "MandatoNumero", DomandaPagamentoLiquidazioneObj.MandatoNumero);
            DbProvider.SetCmdParam(cmd, firstChar + "MandatoData", DomandaPagamentoLiquidazioneObj.MandatoData);
            DbProvider.SetCmdParam(cmd, firstChar + "MandatoImporto", DomandaPagamentoLiquidazioneObj.MandatoImporto);
            DbProvider.SetCmdParam(cmd, firstChar + "MandatoIdFile", DomandaPagamentoLiquidazioneObj.MandatoIdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "QuietanzaData", DomandaPagamentoLiquidazioneObj.QuietanzaData);
            DbProvider.SetCmdParam(cmd, firstChar + "QuietanzaImporto", DomandaPagamentoLiquidazioneObj.QuietanzaImporto);
            DbProvider.SetCmdParam(cmd, firstChar + "Liquidato", DomandaPagamentoLiquidazioneObj.Liquidato);
        }
        //Insert
        private static int Insert(DbProvider db, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", 
"IdImpresaBeneficiaria", "IdDecreto", "RichiestaMandatoImporto", 
"RichiestaMandatoSegnatura", "RichiestaMandatoData", "MandatoNumero", 
"MandatoData", "MandatoImporto", "MandatoIdFile", 
"QuietanzaData", "QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", 
"int", "int", "decimal", 
"string", "DateTime", "string", 
"DateTime", "decimal", "int", 
"DateTime", "decimal", "bool"}, "");
                CompileIUCmd(false, insertCmd, DomandaPagamentoLiquidazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DomandaPagamentoLiquidazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                    DomandaPagamentoLiquidazioneObj.Liquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LIQUIDATO"]);
                }
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneUpdate", new string[] {"Id", "IdDomandaPagamento", "IdProgetto", 
"IdImpresaBeneficiaria", "IdDecreto", "RichiestaMandatoImporto", 
"RichiestaMandatoSegnatura", "RichiestaMandatoData", "MandatoNumero", 
"MandatoData", "MandatoImporto", "MandatoIdFile", 
"QuietanzaData", "QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"string", "DateTime", "string", 
"DateTime", "decimal", "int", 
"DateTime", "decimal", "bool"}, "");
                CompileIUCmd(true, updateCmd, DomandaPagamentoLiquidazioneObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            switch (DomandaPagamentoLiquidazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DomandaPagamentoLiquidazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DomandaPagamentoLiquidazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DomandaPagamentoLiquidazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneUpdate", new string[] {"Id", "IdDomandaPagamento", "IdProgetto", 
"IdImpresaBeneficiaria", "IdDecreto", "RichiestaMandatoImporto", 
"RichiestaMandatoSegnatura", "RichiestaMandatoData", "MandatoNumero", 
"MandatoData", "MandatoImporto", "MandatoIdFile", 
"QuietanzaData", "QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"string", "DateTime", "string", 
"DateTime", "decimal", "int", 
"DateTime", "decimal", "bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", 
"IdImpresaBeneficiaria", "IdDecreto", "RichiestaMandatoImporto", 
"RichiestaMandatoSegnatura", "RichiestaMandatoData", "MandatoNumero", 
"MandatoData", "MandatoImporto", "MandatoIdFile", 
"QuietanzaData", "QuietanzaImporto", "Liquidato"}, new string[] {"int", "int", 
"int", "int", "decimal", 
"string", "DateTime", "string", 
"DateTime", "decimal", "int", 
"DateTime", "decimal", "bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaPagamentoLiquidazioneCollectionObj.Count; i++)
                {
                    switch (DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DomandaPagamentoLiquidazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DomandaPagamentoLiquidazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                    DomandaPagamentoLiquidazioneCollectionObj[i].Liquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LIQUIDATO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DomandaPagamentoLiquidazioneCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DomandaPagamentoLiquidazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoLiquidazioneCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DomandaPagamentoLiquidazioneCollectionObj.Count; i++)
                {
                    if ((DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsDirty = false;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsDirty = false;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj)
        {
            int returnValue = 0;
            if (DomandaPagamentoLiquidazioneObj.IsPersistent)
            {
                returnValue = Delete(db, DomandaPagamentoLiquidazioneObj.Id);
            }
            DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DomandaPagamentoLiquidazioneObj.IsDirty = false;
            DomandaPagamentoLiquidazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaPagamentoLiquidazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", DomandaPagamentoLiquidazioneCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DomandaPagamentoLiquidazioneCollectionObj.Count; i++)
                {
                    if ((DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaPagamentoLiquidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsDirty = false;
                        DomandaPagamentoLiquidazioneCollectionObj[i].IsPersistent = false;
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
        public static DomandaPagamentoLiquidazione GetById(DbProvider db, int IdValue)
        {
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZDomandaPagamentoLiquidazioneGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DomandaPagamentoLiquidazioneObj = GetFromDatareader(db);
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
            }
            db.Close();
            return DomandaPagamentoLiquidazioneObj;
        }

        //getFromDatareader
        public static DomandaPagamentoLiquidazione GetFromDatareader(DbProvider db)
        {
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj = new DomandaPagamentoLiquidazione();
            DomandaPagamentoLiquidazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            DomandaPagamentoLiquidazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DomandaPagamentoLiquidazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DomandaPagamentoLiquidazioneObj.IdImpresaBeneficiaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_BENEFICIARIA"]);
            DomandaPagamentoLiquidazioneObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
            DomandaPagamentoLiquidazioneObj.RichiestaMandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RICHIESTA_MANDATO_IMPORTO"]);
            DomandaPagamentoLiquidazioneObj.RichiestaMandatoSegnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["RICHIESTA_MANDATO_SEGNATURA"]);
            DomandaPagamentoLiquidazioneObj.RichiestaMandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["RICHIESTA_MANDATO_DATA"]);
            DomandaPagamentoLiquidazioneObj.MandatoNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["MANDATO_NUMERO"]);
            DomandaPagamentoLiquidazioneObj.MandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["MANDATO_DATA"]);
            DomandaPagamentoLiquidazioneObj.MandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MANDATO_IMPORTO"]);
            DomandaPagamentoLiquidazioneObj.MandatoIdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["MANDATO_ID_FILE"]);
            DomandaPagamentoLiquidazioneObj.QuietanzaData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["QUIETANZA_DATA"]);
            DomandaPagamentoLiquidazioneObj.QuietanzaImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUIETANZA_IMPORTO"]);
            DomandaPagamentoLiquidazioneObj.Liquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LIQUIDATO"]);
            DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DomandaPagamentoLiquidazioneObj.IsDirty = false;
            DomandaPagamentoLiquidazioneObj.IsPersistent = true;
            return DomandaPagamentoLiquidazioneObj;
        }

        //Find Select

        public static DomandaPagamentoLiquidazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaBeneficiariaEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, SiarLibrary.NullTypes.DecimalNT RichiestaMandatoImportoEqualThis,
SiarLibrary.NullTypes.StringNT RichiestaMandatoSegnaturaEqualThis, SiarLibrary.NullTypes.DatetimeNT RichiestaMandatoDataEqualThis, SiarLibrary.NullTypes.StringNT MandatoNumeroEqualThis,
SiarLibrary.NullTypes.DatetimeNT MandatoDataEqualThis, SiarLibrary.NullTypes.DecimalNT MandatoImportoEqualThis, SiarLibrary.NullTypes.IntNT MandatoIdFileEqualThis,
SiarLibrary.NullTypes.DatetimeNT QuietanzaDataEqualThis, SiarLibrary.NullTypes.DecimalNT QuietanzaImportoEqualThis, SiarLibrary.NullTypes.BoolNT LiquidatoEqualThis)
        {

            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj = new DomandaPagamentoLiquidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoliquidazionefindselect", new string[] {"Idequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis", 
"IdImpresaBeneficiariaequalthis", "IdDecretoequalthis", "RichiestaMandatoImportoequalthis", 
"RichiestaMandatoSegnaturaequalthis", "RichiestaMandatoDataequalthis", "MandatoNumeroequalthis", 
"MandatoDataequalthis", "MandatoImportoequalthis", "MandatoIdFileequalthis", 
"QuietanzaDataequalthis", "QuietanzaImportoequalthis", "Liquidatoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "decimal", 
"string", "DateTime", "string", 
"DateTime", "decimal", "int", 
"DateTime", "decimal", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaBeneficiariaequalthis", IdImpresaBeneficiariaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RichiestaMandatoImportoequalthis", RichiestaMandatoImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RichiestaMandatoSegnaturaequalthis", RichiestaMandatoSegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RichiestaMandatoDataequalthis", RichiestaMandatoDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MandatoNumeroequalthis", MandatoNumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MandatoDataequalthis", MandatoDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MandatoImportoequalthis", MandatoImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MandatoIdFileequalthis", MandatoIdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuietanzaDataequalthis", QuietanzaDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuietanzaImportoequalthis", QuietanzaImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Liquidatoequalthis", LiquidatoEqualThis);
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoLiquidazioneObj = GetFromDatareader(db);
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
                DomandaPagamentoLiquidazioneCollectionObj.Add(DomandaPagamentoLiquidazioneObj);
            }
            db.Close();
            return DomandaPagamentoLiquidazioneCollectionObj;
        }

        //Find FindByDecreto

        public static DomandaPagamentoLiquidazioneCollection FindByDecreto(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaBeneficiariaEqualThis,
SiarLibrary.NullTypes.BoolNT LiquidatoEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis)
        {

            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj = new DomandaPagamentoLiquidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoliquidazionefindfindbydecreto", new string[] {"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "IdImpresaBeneficiariaequalthis", 
"Liquidatoequalthis", "IdDecretoequalthis"}, new string[] {"int", "int", "int", 
"bool", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaBeneficiariaequalthis", IdImpresaBeneficiariaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Liquidatoequalthis", LiquidatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoLiquidazioneObj = GetFromDatareader(db);
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
                DomandaPagamentoLiquidazioneCollectionObj.Add(DomandaPagamentoLiquidazioneObj);
            }
            db.Close();
            return DomandaPagamentoLiquidazioneCollectionObj;
        }

        //Find Find

        public static DomandaPagamentoLiquidazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaBeneficiariaEqualThis,
SiarLibrary.NullTypes.BoolNT LiquidatoEqualThis)
        {

            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionObj = new DomandaPagamentoLiquidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoliquidazionefindfind", new string[] {"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "IdImpresaBeneficiariaequalthis", 
"Liquidatoequalthis"}, new string[] {"int", "int", "int", 
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaBeneficiariaequalthis", IdImpresaBeneficiariaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Liquidatoequalthis", LiquidatoEqualThis);
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoLiquidazioneObj = GetFromDatareader(db);
                DomandaPagamentoLiquidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoLiquidazioneObj.IsDirty = false;
                DomandaPagamentoLiquidazioneObj.IsPersistent = true;
                DomandaPagamentoLiquidazioneCollectionObj.Add(DomandaPagamentoLiquidazioneObj);
            }
            db.Close();
            return DomandaPagamentoLiquidazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DomandaPagamentoLiquidazioneCollectionProvider:IDomandaPagamentoLiquidazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaPagamentoLiquidazioneCollectionProvider : IDomandaPagamentoLiquidazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DomandaPagamentoLiquidazione
        protected DomandaPagamentoLiquidazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DomandaPagamentoLiquidazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DomandaPagamentoLiquidazioneCollection(this);
        }

        //Costruttore 2: popola la collection
        public DomandaPagamentoLiquidazioneCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresabeneficiariaEqualThis,
BoolNT LiquidatoEqualThis, IntNT IddecretoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindByDecreto(IddomandapagamentoEqualThis, IdprogettoEqualThis, IdimpresabeneficiariaEqualThis,
LiquidatoEqualThis, IddecretoEqualThis);
        }

        //Costruttore3: ha in input domandapagamentoliquidazioneCollectionObj - non popola la collection
        public DomandaPagamentoLiquidazioneCollectionProvider(DomandaPagamentoLiquidazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DomandaPagamentoLiquidazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DomandaPagamentoLiquidazioneCollection(this);
        }

        //Get e Set
        public DomandaPagamentoLiquidazioneCollection CollectionObj
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
        public int SaveCollection(DomandaPagamentoLiquidazioneCollection collectionObj)
        {
            return DomandaPagamentoLiquidazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DomandaPagamentoLiquidazione domandapagamentoliquidazioneObj)
        {
            return DomandaPagamentoLiquidazioneDAL.Save(_dbProviderObj, domandapagamentoliquidazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DomandaPagamentoLiquidazioneCollection collectionObj)
        {
            return DomandaPagamentoLiquidazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DomandaPagamentoLiquidazione domandapagamentoliquidazioneObj)
        {
            return DomandaPagamentoLiquidazioneDAL.Delete(_dbProviderObj, domandapagamentoliquidazioneObj);
        }

        //getById
        public DomandaPagamentoLiquidazione GetById(IntNT IdValue)
        {
            DomandaPagamentoLiquidazione DomandaPagamentoLiquidazioneTemp = DomandaPagamentoLiquidazioneDAL.GetById(_dbProviderObj, IdValue);
            if (DomandaPagamentoLiquidazioneTemp != null) DomandaPagamentoLiquidazioneTemp.Provider = this;
            return DomandaPagamentoLiquidazioneTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public DomandaPagamentoLiquidazioneCollection Select(IntNT IdEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresabeneficiariaEqualThis, IntNT IddecretoEqualThis, DecimalNT RichiestamandatoimportoEqualThis,
StringNT RichiestamandatosegnaturaEqualThis, DatetimeNT RichiestamandatodataEqualThis, StringNT MandatonumeroEqualThis,
DatetimeNT MandatodataEqualThis, DecimalNT MandatoimportoEqualThis, IntNT MandatoidfileEqualThis,
DatetimeNT QuietanzadataEqualThis, DecimalNT QuietanzaimportoEqualThis, BoolNT LiquidatoEqualThis)
        {
            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionTemp = DomandaPagamentoLiquidazioneDAL.Select(_dbProviderObj, IdEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis,
IdimpresabeneficiariaEqualThis, IddecretoEqualThis, RichiestamandatoimportoEqualThis,
RichiestamandatosegnaturaEqualThis, RichiestamandatodataEqualThis, MandatonumeroEqualThis,
MandatodataEqualThis, MandatoimportoEqualThis, MandatoidfileEqualThis,
QuietanzadataEqualThis, QuietanzaimportoEqualThis, LiquidatoEqualThis);
            DomandaPagamentoLiquidazioneCollectionTemp.Provider = this;
            return DomandaPagamentoLiquidazioneCollectionTemp;
        }

        //FindByDecreto: popola la collection
        public DomandaPagamentoLiquidazioneCollection FindByDecreto(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresabeneficiariaEqualThis,
BoolNT LiquidatoEqualThis, IntNT IddecretoEqualThis)
        {
            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionTemp = DomandaPagamentoLiquidazioneDAL.FindByDecreto(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis, IdimpresabeneficiariaEqualThis,
LiquidatoEqualThis, IddecretoEqualThis);
            DomandaPagamentoLiquidazioneCollectionTemp.Provider = this;
            return DomandaPagamentoLiquidazioneCollectionTemp;
        }

        //Find: popola la collection
        public DomandaPagamentoLiquidazioneCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresabeneficiariaEqualThis,
BoolNT LiquidatoEqualThis)
        {
            DomandaPagamentoLiquidazioneCollection DomandaPagamentoLiquidazioneCollectionTemp = DomandaPagamentoLiquidazioneDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis, IdimpresabeneficiariaEqualThis,
LiquidatoEqualThis);
            DomandaPagamentoLiquidazioneCollectionTemp.Provider = this;
            return DomandaPagamentoLiquidazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_LIQUIDAZIONE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <FindByDecreto OrderBy="ORDER BY ID">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA_BENEFICIARIA>Equal</ID_IMPRESA_BENEFICIARIA>
      <LIQUIDATO>Equal</LIQUIDATO>
      <ID_DECRETO>Equal</ID_DECRETO>
    </FindByDecreto>
    <Find OrderBy="ORDER BY ID">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA_BENEFICIARIA>Equal</ID_IMPRESA_BENEFICIARIA>
      <LIQUIDATO>Equal</LIQUIDATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_LIQUIDAZIONE>
*/
