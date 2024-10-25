using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TestataValidazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITestataValidazioneProvider
    {
        int Save(TestataValidazione TestataValidazioneObj);
        int SaveCollection(TestataValidazioneCollection collectionObj);
        int Delete(TestataValidazione TestataValidazioneObj);
        int DeleteCollection(TestataValidazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TestataValidazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TestataValidazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTestata;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.StringNT _TipoDomandaPagamento;
        private NullTypes.StringNT _CodFase;
        private NullTypes.DatetimeNT _DataPresentazioneDomandaPagamento;
        private NullTypes.BoolNT _DomandaApprovata;
        private NullTypes.StringNT _SegnaturaApprovazioneDomanda;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdLotto;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfValidatore;
        private NullTypes.StringNT _NominativoValidatore;
        private NullTypes.BoolNT _SelezionataXRevisione;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.IntNT _NumeroEstrazione;
        private NullTypes.IntNT _Ordine;
        private NullTypes.StringNT _SegnaturaRevisione;
        private NullTypes.StringNT _SegnaturaSecondaRevisione;
        private NullTypes.DatetimeNT _DataValidazione;
        private NullTypes.BoolNT _Autovalutazione;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _ProvinciaDiPresentazione;
        [NonSerialized] private ITestataValidazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataValidazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TestataValidazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_TESTATA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTestata
        {
            get { return _IdTestata; }
            set
            {
                if (IdTestata != value)
                {
                    _IdTestata = value;
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
        /// Corrisponde al campo:TIPO_DOMANDA_PAGAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TipoDomandaPagamento
        {
            get { return _TipoDomandaPagamento; }
            set
            {
                if (TipoDomandaPagamento != value)
                {
                    _TipoDomandaPagamento = value;
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
        /// Corrisponde al campo:DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPresentazioneDomandaPagamento
        {
            get { return _DataPresentazioneDomandaPagamento; }
            set
            {
                if (DataPresentazioneDomandaPagamento != value)
                {
                    _DataPresentazioneDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DOMANDA_APPROVATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT DomandaApprovata
        {
            get { return _DomandaApprovata; }
            set
            {
                if (DomandaApprovata != value)
                {
                    _DomandaApprovata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_APPROVAZIONE_DOMANDA
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaApprovazioneDomanda
        {
            get { return _SegnaturaApprovazioneDomanda; }
            set
            {
                if (SegnaturaApprovazioneDomanda != value)
                {
                    _SegnaturaApprovazioneDomanda = value;
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
        /// Corrisponde al campo:SELEZIONATA_X_REVISIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT SelezionataXRevisione
        {
            get { return _SelezionataXRevisione; }
            set
            {
                if (SelezionataXRevisione != value)
                {
                    _SelezionataXRevisione = value;
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
        /// Corrisponde al campo:NUMERO_ESTRAZIONE
        /// Tipo sul db:INT
        /// Default:((0))
        /// </summary>
        public NullTypes.IntNT NumeroEstrazione
        {
            get { return _NumeroEstrazione; }
            set
            {
                if (NumeroEstrazione != value)
                {
                    _NumeroEstrazione = value;
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
        /// Corrisponde al campo:SEGNATURA_REVISIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaRevisione
        {
            get { return _SegnaturaRevisione; }
            set
            {
                if (SegnaturaRevisione != value)
                {
                    _SegnaturaRevisione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_SECONDA_REVISIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaSecondaRevisione
        {
            get { return _SegnaturaSecondaRevisione; }
            set
            {
                if (SegnaturaSecondaRevisione != value)
                {
                    _SegnaturaSecondaRevisione = value;
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
        /// Corrisponde al campo:AUTOVALUTAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
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
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT CodTipo
        {
            get { return _CodTipo; }
            set
            {
                if (CodTipo != value)
                {
                    _CodTipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_APPROVAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataApprovazione
        {
            get { return _DataApprovazione; }
            set
            {
                if (DataApprovazione != value)
                {
                    _DataApprovazione = value;
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
        /// Corrisponde al campo:PROVINCIA_DI_PRESENTAZIONE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT ProvinciaDiPresentazione
        {
            get { return _ProvinciaDiPresentazione; }
            set
            {
                if (ProvinciaDiPresentazione != value)
                {
                    _ProvinciaDiPresentazione = value;
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
    /// Summary description for TestataValidazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataValidazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TestataValidazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TestataValidazione)info.GetValue(i.ToString(), typeof(TestataValidazione)));
            }
        }

        //Costruttore
        public TestataValidazioneCollection()
        {
            this.ItemType = typeof(TestataValidazione);
        }

        //Costruttore con provider
        public TestataValidazioneCollection(ITestataValidazioneProvider providerObj)
        {
            this.ItemType = typeof(TestataValidazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TestataValidazione this[int index]
        {
            get { return (TestataValidazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TestataValidazioneCollection GetChanges()
        {
            return (TestataValidazioneCollection)base.GetChanges();
        }

        [NonSerialized] private ITestataValidazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataValidazioneProvider Provider
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
        public int Add(TestataValidazione TestataValidazioneObj)
        {
            if (TestataValidazioneObj.Provider == null) TestataValidazioneObj.Provider = this.Provider;
            return base.Add(TestataValidazioneObj);
        }

        //AddCollection
        public void AddCollection(TestataValidazioneCollection TestataValidazioneCollectionObj)
        {
            foreach (TestataValidazione TestataValidazioneObj in TestataValidazioneCollectionObj)
                this.Add(TestataValidazioneObj);
        }

        //Insert
        public void Insert(int index, TestataValidazione TestataValidazioneObj)
        {
            if (TestataValidazioneObj.Provider == null) TestataValidazioneObj.Provider = this.Provider;
            base.Insert(index, TestataValidazioneObj);
        }

        //CollectionGetById
        public TestataValidazione CollectionGetById(NullTypes.IntNT IdTestataValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdTestata == IdTestataValue))
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
        public TestataValidazioneCollection SubSelect(NullTypes.IntNT IdTestataEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdLottoEqualThis,
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT CfValidatoreEqualThis, NullTypes.BoolNT SelezionataXRevisioneEqualThis,
NullTypes.BoolNT ApprovataEqualThis, NullTypes.IntNT NumeroEstrazioneEqualThis, NullTypes.IntNT OrdineEqualThis,
NullTypes.StringNT SegnaturaRevisioneEqualThis, NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, NullTypes.DatetimeNT DataValidazioneEqualThis,
NullTypes.BoolNT AutovalutazioneEqualThis)
        {
            TestataValidazioneCollection TestataValidazioneCollectionTemp = new TestataValidazioneCollection();
            foreach (TestataValidazione TestataValidazioneItem in this)
            {
                if (((IdTestataEqualThis == null) || ((TestataValidazioneItem.IdTestata != null) && (TestataValidazioneItem.IdTestata.Value == IdTestataEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((TestataValidazioneItem.CfInserimento != null) && (TestataValidazioneItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TestataValidazioneItem.DataInserimento != null) && (TestataValidazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((TestataValidazioneItem.CfModifica != null) && (TestataValidazioneItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((TestataValidazioneItem.DataModifica != null) && (TestataValidazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdLottoEqualThis == null) || ((TestataValidazioneItem.IdLotto != null) && (TestataValidazioneItem.IdLotto.Value == IdLottoEqualThis.Value))) &&
((IdDomandaPagamentoEqualThis == null) || ((TestataValidazioneItem.IdDomandaPagamento != null) && (TestataValidazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((CfValidatoreEqualThis == null) || ((TestataValidazioneItem.CfValidatore != null) && (TestataValidazioneItem.CfValidatore.Value == CfValidatoreEqualThis.Value))) && ((SelezionataXRevisioneEqualThis == null) || ((TestataValidazioneItem.SelezionataXRevisione != null) && (TestataValidazioneItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) &&
((ApprovataEqualThis == null) || ((TestataValidazioneItem.Approvata != null) && (TestataValidazioneItem.Approvata.Value == ApprovataEqualThis.Value))) && ((NumeroEstrazioneEqualThis == null) || ((TestataValidazioneItem.NumeroEstrazione != null) && (TestataValidazioneItem.NumeroEstrazione.Value == NumeroEstrazioneEqualThis.Value))) && ((OrdineEqualThis == null) || ((TestataValidazioneItem.Ordine != null) && (TestataValidazioneItem.Ordine.Value == OrdineEqualThis.Value))) &&
((SegnaturaRevisioneEqualThis == null) || ((TestataValidazioneItem.SegnaturaRevisione != null) && (TestataValidazioneItem.SegnaturaRevisione.Value == SegnaturaRevisioneEqualThis.Value))) && ((SegnaturaSecondaRevisioneEqualThis == null) || ((TestataValidazioneItem.SegnaturaSecondaRevisione != null) && (TestataValidazioneItem.SegnaturaSecondaRevisione.Value == SegnaturaSecondaRevisioneEqualThis.Value))) && ((DataValidazioneEqualThis == null) || ((TestataValidazioneItem.DataValidazione != null) && (TestataValidazioneItem.DataValidazione.Value == DataValidazioneEqualThis.Value))) &&
((AutovalutazioneEqualThis == null) || ((TestataValidazioneItem.Autovalutazione != null) && (TestataValidazioneItem.Autovalutazione.Value == AutovalutazioneEqualThis.Value))))
                {
                    TestataValidazioneCollectionTemp.Add(TestataValidazioneItem);
                }
            }
            return TestataValidazioneCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public TestataValidazioneCollection FiltroAssegnate(NullTypes.IntNT IdLottoEqualThis)
        {
            TestataValidazioneCollection TestataValidazioneCollectionTemp = new TestataValidazioneCollection();
            foreach (TestataValidazione TestataValidazioneItem in this)
            {
                if (((IdLottoEqualThis == null) || ((TestataValidazioneItem.IdLotto != null) && (TestataValidazioneItem.IdLotto.Value == IdLottoEqualThis.Value))))
                {
                    TestataValidazioneCollectionTemp.Add(TestataValidazioneItem);
                }
            }
            return TestataValidazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TestataValidazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TestataValidazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TestataValidazione TestataValidazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTestata", TestataValidazioneObj.IdTestata);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", TestataValidazioneObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdLotto", TestataValidazioneObj.IdLotto);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", TestataValidazioneObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", TestataValidazioneObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", TestataValidazioneObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", TestataValidazioneObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfValidatore", TestataValidazioneObj.CfValidatore);
            DbProvider.SetCmdParam(cmd, firstChar + "SelezionataXRevisione", TestataValidazioneObj.SelezionataXRevisione);
            DbProvider.SetCmdParam(cmd, firstChar + "Approvata", TestataValidazioneObj.Approvata);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroEstrazione", TestataValidazioneObj.NumeroEstrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", TestataValidazioneObj.Ordine);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaRevisione", TestataValidazioneObj.SegnaturaRevisione);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaSecondaRevisione", TestataValidazioneObj.SegnaturaSecondaRevisione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataValidazione", TestataValidazioneObj.DataValidazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Autovalutazione", TestataValidazioneObj.Autovalutazione);
        }
        //Insert
        private static int Insert(DbProvider db, TestataValidazione TestataValidazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTestataValidazioneInsert", new string[] {"IdDomandaPagamento",

"IdLotto",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "CfValidatore",
"SelezionataXRevisione", "Approvata", "NumeroEstrazione",
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione",
"DataValidazione", "Autovalutazione", }, new string[] {"int",

"int",
"string", "DateTime", "string",
"DateTime", "string",
"bool", "bool", "int",
"int", "string", "string",
"DateTime", "bool", }, "");
                CompileIUCmd(false, insertCmd, TestataValidazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TestataValidazioneObj.IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
                    TestataValidazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    TestataValidazioneObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
                    TestataValidazioneObj.NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
                    TestataValidazioneObj.Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
                }
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TestataValidazione TestataValidazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataValidazioneUpdate", new string[] {"IdTestata", "IdDomandaPagamento",

"IdLotto",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "CfValidatore",
"SelezionataXRevisione", "Approvata", "NumeroEstrazione",
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione",
"DataValidazione", "Autovalutazione", }, new string[] {"int", "int",

"int",
"string", "DateTime", "string",
"DateTime", "string",
"bool", "bool", "int",
"int", "string", "string",
"DateTime", "bool", }, "");
                CompileIUCmd(true, updateCmd, TestataValidazioneObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    TestataValidazioneObj.DataModifica = d;
                }
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TestataValidazione TestataValidazioneObj)
        {
            switch (TestataValidazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TestataValidazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TestataValidazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TestataValidazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TestataValidazioneCollection TestataValidazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataValidazioneUpdate", new string[] {"IdTestata", "IdDomandaPagamento",

"IdLotto",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "CfValidatore",
"SelezionataXRevisione", "Approvata", "NumeroEstrazione",
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione",
"DataValidazione", "Autovalutazione", }, new string[] {"int", "int",

"int",
"string", "DateTime", "string",
"DateTime", "string",
"bool", "bool", "int",
"int", "string", "string",
"DateTime", "bool", }, "");
                IDbCommand insertCmd = db.InitCmd("ZTestataValidazioneInsert", new string[] {"IdDomandaPagamento",

"IdLotto",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "CfValidatore",
"SelezionataXRevisione", "Approvata", "NumeroEstrazione",
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione",
"DataValidazione", "Autovalutazione", }, new string[] {"int",

"int",
"string", "DateTime", "string",
"DateTime", "string",
"bool", "bool", "int",
"int", "string", "string",
"DateTime", "bool", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataValidazioneCollectionObj.Count; i++)
                {
                    switch (TestataValidazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TestataValidazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TestataValidazioneCollectionObj[i].IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
                                    TestataValidazioneCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    TestataValidazioneCollectionObj[i].SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
                                    TestataValidazioneCollectionObj[i].NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
                                    TestataValidazioneCollectionObj[i].Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TestataValidazioneCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    TestataValidazioneCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TestataValidazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)TestataValidazioneCollectionObj[i].IdTestata);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TestataValidazioneCollectionObj.Count; i++)
                {
                    if ((TestataValidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataValidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TestataValidazioneCollectionObj[i].IsDirty = false;
                        TestataValidazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((TestataValidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TestataValidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataValidazioneCollectionObj[i].IsDirty = false;
                        TestataValidazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TestataValidazione TestataValidazioneObj)
        {
            int returnValue = 0;
            if (TestataValidazioneObj.IsPersistent)
            {
                returnValue = Delete(db, TestataValidazioneObj.IdTestata);
            }
            TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TestataValidazioneObj.IsDirty = false;
            TestataValidazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTestataValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)IdTestataValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TestataValidazioneCollection TestataValidazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataValidazioneDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataValidazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", TestataValidazioneCollectionObj[i].IdTestata);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TestataValidazioneCollectionObj.Count; i++)
                {
                    if ((TestataValidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataValidazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataValidazioneCollectionObj[i].IsDirty = false;
                        TestataValidazioneCollectionObj[i].IsPersistent = false;
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
        public static TestataValidazione GetById(DbProvider db, int IdTestataValue)
        {
            TestataValidazione TestataValidazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZTestataValidazioneGetById", new string[] { "IdTestata" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)IdTestataValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TestataValidazioneObj = GetFromDatareader(db);
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
            }
            db.Close();
            return TestataValidazioneObj;
        }

        //getFromDatareader
        public static TestataValidazione GetFromDatareader(DbProvider db)
        {
            TestataValidazione TestataValidazioneObj = new TestataValidazione();
            TestataValidazioneObj.IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
            TestataValidazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            TestataValidazioneObj.TipoDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA_PAGAMENTO"]);
            TestataValidazioneObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
            TestataValidazioneObj.DataPresentazioneDomandaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO"]);
            TestataValidazioneObj.DomandaApprovata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA_APPROVATA"]);
            TestataValidazioneObj.SegnaturaApprovazioneDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE_DOMANDA"]);
            TestataValidazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            TestataValidazioneObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
            TestataValidazioneObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            TestataValidazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            TestataValidazioneObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            TestataValidazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            TestataValidazioneObj.CfValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_VALIDATORE"]);
            TestataValidazioneObj.NominativoValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_VALIDATORE"]);
            TestataValidazioneObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
            TestataValidazioneObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            TestataValidazioneObj.NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
            TestataValidazioneObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            TestataValidazioneObj.SegnaturaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_REVISIONE"]);
            TestataValidazioneObj.SegnaturaSecondaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_REVISIONE"]);
            TestataValidazioneObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
            TestataValidazioneObj.Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
            TestataValidazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            TestataValidazioneObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            TestataValidazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            TestataValidazioneObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
            TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TestataValidazioneObj.IsDirty = false;
            TestataValidazioneObj.IsPersistent = true;
            return TestataValidazioneObj;
        }

        //Find Select

        public static TestataValidazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CfValidatoreEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis,
SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT NumeroEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaRevisioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValidazioneEqualThis,
SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis)

        {

            TestataValidazioneCollection TestataValidazioneCollectionObj = new TestataValidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatavalidazionefindselect", new string[] {"IdTestataequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis",
"CfModificaequalthis", "DataModificaequalthis", "IdLottoequalthis",
"IdDomandaPagamentoequalthis", "CfValidatoreequalthis", "SelezionataXRevisioneequalthis",
"Approvataequalthis", "NumeroEstrazioneequalthis", "Ordineequalthis",
"SegnaturaRevisioneequalthis", "SegnaturaSecondaRevisioneequalthis", "DataValidazioneequalthis",
"Autovalutazioneequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "int",
"int", "string", "bool",
"bool", "int", "int",
"string", "string", "DateTime",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataequalthis", IdTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfValidatoreequalthis", CfValidatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroEstrazioneequalthis", NumeroEstrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaRevisioneequalthis", SegnaturaRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaSecondaRevisioneequalthis", SegnaturaSecondaRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataValidazioneequalthis", DataValidazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
            TestataValidazione TestataValidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataValidazioneObj = GetFromDatareader(db);
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
                TestataValidazioneCollectionObj.Add(TestataValidazioneObj);
            }
            db.Close();
            return TestataValidazioneCollectionObj;
        }

        //Find FindRevisione

        public static TestataValidazioneCollection FindRevisione(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis,
SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneDomandaNotEqualThis, SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis)

        {

            TestataValidazioneCollection TestataValidazioneCollectionObj = new TestataValidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatavalidazionefindfindrevisione", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "SelezionataXRevisioneequalthis",
"Approvataequalthis", "IdBandoequalthis", "ProvinciaDiPresentazioneequalthis",
"SegnaturaApprovazioneDomandanotequalthis", "Autovalutazioneequalthis"}, new string[] {"int", "int", "bool",
"bool", "int", "string",
"string", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProvinciaDiPresentazioneequalthis", ProvinciaDiPresentazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaApprovazioneDomandanotequalthis", SegnaturaApprovazioneDomandaNotEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
            TestataValidazione TestataValidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataValidazioneObj = GetFromDatareader(db);
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
                TestataValidazioneCollectionObj.Add(TestataValidazioneObj);
            }
            db.Close();
            return TestataValidazioneCollectionObj;
        }

        //Find FindAutovalutazione

        public static TestataValidazioneCollection FindAutovalutazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis)

        {

            TestataValidazioneCollection TestataValidazioneCollectionObj = new TestataValidazioneCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatavalidazionefindfindautovalutazione", new string[] {"IdTestataequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis",
"Autovalutazioneequalthis"}, new string[] {"int", "int", "int",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataequalthis", IdTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
            TestataValidazione TestataValidazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataValidazioneObj = GetFromDatareader(db);
                TestataValidazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataValidazioneObj.IsDirty = false;
                TestataValidazioneObj.IsPersistent = true;
                TestataValidazioneCollectionObj.Add(TestataValidazioneObj);
            }
            db.Close();
            return TestataValidazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TestataValidazioneCollectionProvider:ITestataValidazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataValidazioneCollectionProvider : ITestataValidazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TestataValidazione
        protected TestataValidazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TestataValidazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TestataValidazioneCollection(this);
        }

        //Costruttore 2: popola la collection
        public TestataValidazioneCollectionProvider(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT SelezionataxrevisioneEqualThis,
BoolNT ApprovataEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciadipresentazioneEqualThis,
StringNT SegnaturaapprovazionedomandaNotEqualThis, BoolNT AutovalutazioneEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindRevisione(IdlottoEqualThis, IddomandapagamentoEqualThis, SelezionataxrevisioneEqualThis,
ApprovataEqualThis, IdbandoEqualThis, ProvinciadipresentazioneEqualThis,
SegnaturaapprovazionedomandaNotEqualThis, AutovalutazioneEqualThis);
        }

        //Costruttore3: ha in input testatavalidazioneCollectionObj - non popola la collection
        public TestataValidazioneCollectionProvider(TestataValidazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TestataValidazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TestataValidazioneCollection(this);
        }

        //Get e Set
        public TestataValidazioneCollection CollectionObj
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
        public int SaveCollection(TestataValidazioneCollection collectionObj)
        {
            return TestataValidazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TestataValidazione testatavalidazioneObj)
        {
            return TestataValidazioneDAL.Save(_dbProviderObj, testatavalidazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TestataValidazioneCollection collectionObj)
        {
            return TestataValidazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TestataValidazione testatavalidazioneObj)
        {
            return TestataValidazioneDAL.Delete(_dbProviderObj, testatavalidazioneObj);
        }

        //getById
        public TestataValidazione GetById(IntNT IdTestataValue)
        {
            TestataValidazione TestataValidazioneTemp = TestataValidazioneDAL.GetById(_dbProviderObj, IdTestataValue);
            if (TestataValidazioneTemp != null) TestataValidazioneTemp.Provider = this;
            return TestataValidazioneTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public TestataValidazioneCollection Select(IntNT IdtestataEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdlottoEqualThis,
IntNT IddomandapagamentoEqualThis, StringNT CfvalidatoreEqualThis, BoolNT SelezionataxrevisioneEqualThis,
BoolNT ApprovataEqualThis, IntNT NumeroestrazioneEqualThis, IntNT OrdineEqualThis,
StringNT SegnaturarevisioneEqualThis, StringNT SegnaturasecondarevisioneEqualThis, DatetimeNT DatavalidazioneEqualThis,
BoolNT AutovalutazioneEqualThis)
        {
            TestataValidazioneCollection TestataValidazioneCollectionTemp = TestataValidazioneDAL.Select(_dbProviderObj, IdtestataEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis,
CfmodificaEqualThis, DatamodificaEqualThis, IdlottoEqualThis,
IddomandapagamentoEqualThis, CfvalidatoreEqualThis, SelezionataxrevisioneEqualThis,
ApprovataEqualThis, NumeroestrazioneEqualThis, OrdineEqualThis,
SegnaturarevisioneEqualThis, SegnaturasecondarevisioneEqualThis, DatavalidazioneEqualThis,
AutovalutazioneEqualThis);
            TestataValidazioneCollectionTemp.Provider = this;
            return TestataValidazioneCollectionTemp;
        }

        //FindRevisione: popola la collection
        public TestataValidazioneCollection FindRevisione(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT SelezionataxrevisioneEqualThis,
BoolNT ApprovataEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciadipresentazioneEqualThis,
StringNT SegnaturaapprovazionedomandaNotEqualThis, BoolNT AutovalutazioneEqualThis)
        {
            TestataValidazioneCollection TestataValidazioneCollectionTemp = TestataValidazioneDAL.FindRevisione(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, SelezionataxrevisioneEqualThis,
ApprovataEqualThis, IdbandoEqualThis, ProvinciadipresentazioneEqualThis,
SegnaturaapprovazionedomandaNotEqualThis, AutovalutazioneEqualThis);
            TestataValidazioneCollectionTemp.Provider = this;
            return TestataValidazioneCollectionTemp;
        }

        //FindAutovalutazione: popola la collection
        public TestataValidazioneCollection FindAutovalutazione(IntNT IdtestataEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis,
BoolNT AutovalutazioneEqualThis)
        {
            TestataValidazioneCollection TestataValidazioneCollectionTemp = TestataValidazioneDAL.FindAutovalutazione(_dbProviderObj, IdtestataEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis,
AutovalutazioneEqualThis);
            TestataValidazioneCollectionTemp.Provider = this;
            return TestataValidazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TESTATA_VALIDAZIONE>
  <ViewName>VTESTATA_VALIDAZIONE</ViewName>
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
    <FindRevisione OrderBy="ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
      <APPROVATA>Equal</APPROVATA>
      <ID_BANDO>Equal</ID_BANDO>
      <PROVINCIA_DI_PRESENTAZIONE>Equal</PROVINCIA_DI_PRESENTAZIONE>
      <SEGNATURA_APPROVAZIONE_DOMANDA>NotEqual</SEGNATURA_APPROVAZIONE_DOMANDA>
      <AUTOVALUTAZIONE>Equal</AUTOVALUTAZIONE>
    </FindRevisione>
    <FindAutovalutazione OrderBy="ORDER BY ORDINE">
      <ID_TESTATA>Equal</ID_TESTATA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <AUTOVALUTAZIONE>Equal</AUTOVALUTAZIONE>
    </FindAutovalutazione>
  </Finds>
  <Filters>
    <FiltroAssegnate>
      <ID_LOTTO>Equal</ID_LOTTO>
    </FiltroAssegnate>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TESTATA_VALIDAZIONE>
*/
