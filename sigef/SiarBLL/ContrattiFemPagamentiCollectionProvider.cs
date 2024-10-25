using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per ContrattiFemPagamenti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IContrattiFemPagamentiProvider
    {
        int Save(ContrattiFemPagamenti ContrattiFemPagamentiObj);
        int SaveCollection(ContrattiFemPagamentiCollection collectionObj);
        int Delete(ContrattiFemPagamenti ContrattiFemPagamentiObj);
        int DeleteCollection(ContrattiFemPagamentiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for ContrattiFemPagamenti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class ContrattiFemPagamenti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdProgettoContratto;
        private NullTypes.DatetimeNT _DataStipulaContratto;
        private NullTypes.StringNT _SegnaturaContratto;
        private NullTypes.DecimalNT _ImportoContratto;
        private NullTypes.IntNT _IdImpresaContratto;
        private NullTypes.BoolNT _Confidi;
        private NullTypes.IntNT _IdContrattoFemPagamenti;
        private NullTypes.IntNT _IdContrattoFem;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _Estremi;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.IntNT _IdFile;
        private NullTypes.DatetimeNT _DataCreazione;
        private NullTypes.IntNT _OperatoreCreazione;
        private NullTypes.DatetimeNT _DataAggiornamento;
        private NullTypes.IntNT _OperatoreAggiornamento;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.IntNT _IdErogazioneFem;
        private NullTypes.StringNT _ImpresaPagamento;
        private NullTypes.StringNT _CodiceFiscaleImpresaPagamento;
        private NullTypes.StringNT _CuaaImpresaPagamento;
        private NullTypes.StringNT _TipoPagamento;
        [NonSerialized] private IContrattiFemPagamentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IContrattiFemPagamentiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public ContrattiFemPagamenti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:ID_PROGETTO_CONTRATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoContratto
        {
            get { return _IdProgettoContratto; }
            set
            {
                if (IdProgettoContratto != value)
                {
                    _IdProgettoContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_STIPULA_CONTRATTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataStipulaContratto
        {
            get { return _DataStipulaContratto; }
            set
            {
                if (DataStipulaContratto != value)
                {
                    _DataStipulaContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_CONTRATTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaContratto
        {
            get { return _SegnaturaContratto; }
            set
            {
                if (SegnaturaContratto != value)
                {
                    _SegnaturaContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_CONTRATTO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoContratto
        {
            get { return _ImportoContratto; }
            set
            {
                if (ImportoContratto != value)
                {
                    _ImportoContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA_CONTRATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaContratto
        {
            get { return _IdImpresaContratto; }
            set
            {
                if (IdImpresaContratto != value)
                {
                    _IdImpresaContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONFIDI
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Confidi
        {
            get { return _Confidi; }
            set
            {
                if (Confidi != value)
                {
                    _Confidi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CONTRATTO_FEM_PAGAMENTI
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdContrattoFemPagamenti
        {
            get { return _IdContrattoFemPagamenti; }
            set
            {
                if (IdContrattoFemPagamenti != value)
                {
                    _IdContrattoFemPagamenti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CONTRATTO_FEM
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdContrattoFem
        {
            get { return _IdContrattoFem; }
            set
            {
                if (IdContrattoFem != value)
                {
                    _IdContrattoFem = value;
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
        /// Corrisponde al campo:ESTREMI
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Estremi
        {
            get { return _Estremi; }
            set
            {
                if (Estremi != value)
                {
                    _Estremi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Data
        {
            get { return _Data; }
            set
            {
                if (Data != value)
                {
                    _Data = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importo
        {
            get { return _Importo; }
            set
            {
                if (Importo != value)
                {
                    _Importo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFile
        {
            get { return _IdFile; }
            set
            {
                if (IdFile != value)
                {
                    _IdFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CREAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCreazione
        {
            get { return _DataCreazione; }
            set
            {
                if (DataCreazione != value)
                {
                    _DataCreazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_CREAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreCreazione
        {
            get { return _OperatoreCreazione; }
            set
            {
                if (OperatoreCreazione != value)
                {
                    _OperatoreCreazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_AGGIORNAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAggiornamento
        {
            get { return _DataAggiornamento; }
            set
            {
                if (DataAggiornamento != value)
                {
                    _DataAggiornamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_AGGIORNAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreAggiornamento
        {
            get { return _OperatoreAggiornamento; }
            set
            {
                if (OperatoreAggiornamento != value)
                {
                    _OperatoreAggiornamento = value;
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
        /// Corrisponde al campo:IMPORTO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoAmmesso
        {
            get { return _ImportoAmmesso; }
            set
            {
                if (ImportoAmmesso != value)
                {
                    _ImportoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_EROGAZIONE_FEM
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdErogazioneFem
        {
            get { return _IdErogazioneFem; }
            set
            {
                if (IdErogazioneFem != value)
                {
                    _IdErogazioneFem = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPRESA_PAGAMENTO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ImpresaPagamento
        {
            get { return _ImpresaPagamento; }
            set
            {
                if (ImpresaPagamento != value)
                {
                    _ImpresaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_FISCALE_IMPRESA_PAGAMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CodiceFiscaleImpresaPagamento
        {
            get { return _CodiceFiscaleImpresaPagamento; }
            set
            {
                if (CodiceFiscaleImpresaPagamento != value)
                {
                    _CodiceFiscaleImpresaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUAA_IMPRESA_PAGAMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CuaaImpresaPagamento
        {
            get { return _CuaaImpresaPagamento; }
            set
            {
                if (CuaaImpresaPagamento != value)
                {
                    _CuaaImpresaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_PAGAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TipoPagamento
        {
            get { return _TipoPagamento; }
            set
            {
                if (TipoPagamento != value)
                {
                    _TipoPagamento = value;
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
    /// Summary description for ContrattiFemPagamentiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ContrattiFemPagamentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ContrattiFemPagamentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((ContrattiFemPagamenti)info.GetValue(i.ToString(), typeof(ContrattiFemPagamenti)));
            }
        }

        //Costruttore
        public ContrattiFemPagamentiCollection()
        {
            this.ItemType = typeof(ContrattiFemPagamenti);
        }

        //Costruttore con provider
        public ContrattiFemPagamentiCollection(IContrattiFemPagamentiProvider providerObj)
        {
            this.ItemType = typeof(ContrattiFemPagamenti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new ContrattiFemPagamenti this[int index]
        {
            get { return (ContrattiFemPagamenti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ContrattiFemPagamentiCollection GetChanges()
        {
            return (ContrattiFemPagamentiCollection)base.GetChanges();
        }

        [NonSerialized] private IContrattiFemPagamentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IContrattiFemPagamentiProvider Provider
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
        public int Add(ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            if (ContrattiFemPagamentiObj.Provider == null) ContrattiFemPagamentiObj.Provider = this.Provider;
            return base.Add(ContrattiFemPagamentiObj);
        }

        //AddCollection
        public void AddCollection(ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj)
        {
            foreach (ContrattiFemPagamenti ContrattiFemPagamentiObj in ContrattiFemPagamentiCollectionObj)
                this.Add(ContrattiFemPagamentiObj);
        }

        //Insert
        public void Insert(int index, ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            if (ContrattiFemPagamentiObj.Provider == null) ContrattiFemPagamentiObj.Provider = this.Provider;
            base.Insert(index, ContrattiFemPagamentiObj);
        }

        //CollectionGetById
        public ContrattiFemPagamenti CollectionGetById(NullTypes.IntNT IdContrattoFemPagamentiValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdContrattoFemPagamenti == IdContrattoFemPagamentiValue))
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
        public ContrattiFemPagamentiCollection SubSelect(NullTypes.IntNT IdContrattoFemPagamentiEqualThis, NullTypes.IntNT IdContrattoFemEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT EstremiEqualThis, NullTypes.DatetimeNT DataEqualThis,
NullTypes.DecimalNT ImportoEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis,
NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis, NullTypes.IntNT OperatoreAggiornamentoEqualThis,
NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis,
NullTypes.IntNT IdErogazioneFemEqualThis)
        {
            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionTemp = new ContrattiFemPagamentiCollection();
            foreach (ContrattiFemPagamenti ContrattiFemPagamentiItem in this)
            {
                if (((IdContrattoFemPagamentiEqualThis == null) || ((ContrattiFemPagamentiItem.IdContrattoFemPagamenti != null) && (ContrattiFemPagamentiItem.IdContrattoFemPagamenti.Value == IdContrattoFemPagamentiEqualThis.Value))) && ((IdContrattoFemEqualThis == null) || ((ContrattiFemPagamentiItem.IdContrattoFem != null) && (ContrattiFemPagamentiItem.IdContrattoFem.Value == IdContrattoFemEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ContrattiFemPagamentiItem.IdProgetto != null) && (ContrattiFemPagamentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((CodTipoEqualThis == null) || ((ContrattiFemPagamentiItem.CodTipo != null) && (ContrattiFemPagamentiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((EstremiEqualThis == null) || ((ContrattiFemPagamentiItem.Estremi != null) && (ContrattiFemPagamentiItem.Estremi.Value == EstremiEqualThis.Value))) && ((DataEqualThis == null) || ((ContrattiFemPagamentiItem.Data != null) && (ContrattiFemPagamentiItem.Data.Value == DataEqualThis.Value))) &&
((ImportoEqualThis == null) || ((ContrattiFemPagamentiItem.Importo != null) && (ContrattiFemPagamentiItem.Importo.Value == ImportoEqualThis.Value))) && ((IdFileEqualThis == null) || ((ContrattiFemPagamentiItem.IdFile != null) && (ContrattiFemPagamentiItem.IdFile.Value == IdFileEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ContrattiFemPagamentiItem.DataCreazione != null) && (ContrattiFemPagamentiItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) &&
((OperatoreCreazioneEqualThis == null) || ((ContrattiFemPagamentiItem.OperatoreCreazione != null) && (ContrattiFemPagamentiItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((ContrattiFemPagamentiItem.DataAggiornamento != null) && (ContrattiFemPagamentiItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && ((OperatoreAggiornamentoEqualThis == null) || ((ContrattiFemPagamentiItem.OperatoreAggiornamento != null) && (ContrattiFemPagamentiItem.OperatoreAggiornamento.Value == OperatoreAggiornamentoEqualThis.Value))) &&
((IdImpresaEqualThis == null) || ((ContrattiFemPagamentiItem.IdImpresa != null) && (ContrattiFemPagamentiItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((ContrattiFemPagamentiItem.IdDomandaPagamento != null) && (ContrattiFemPagamentiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((ContrattiFemPagamentiItem.ImportoAmmesso != null) && (ContrattiFemPagamentiItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) &&
((IdErogazioneFemEqualThis == null) || ((ContrattiFemPagamentiItem.IdErogazioneFem != null) && (ContrattiFemPagamentiItem.IdErogazioneFem.Value == IdErogazioneFemEqualThis.Value))))
                {
                    ContrattiFemPagamentiCollectionTemp.Add(ContrattiFemPagamentiItem);
                }
            }
            return ContrattiFemPagamentiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ContrattiFemPagamentiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ContrattiFemPagamentiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ContrattiFemPagamenti ContrattiFemPagamentiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdContrattoFemPagamenti", ContrattiFemPagamentiObj.IdContrattoFemPagamenti);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdContrattoFem", ContrattiFemPagamentiObj.IdContrattoFem);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ContrattiFemPagamentiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", ContrattiFemPagamentiObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "Estremi", ContrattiFemPagamentiObj.Estremi);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", ContrattiFemPagamentiObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", ContrattiFemPagamentiObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFile", ContrattiFemPagamentiObj.IdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", ContrattiFemPagamentiObj.DataCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreCreazione", ContrattiFemPagamentiObj.OperatoreCreazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAggiornamento", ContrattiFemPagamentiObj.DataAggiornamento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreAggiornamento", ContrattiFemPagamentiObj.OperatoreAggiornamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ContrattiFemPagamentiObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", ContrattiFemPagamentiObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoAmmesso", ContrattiFemPagamentiObj.ImportoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "IdErogazioneFem", ContrattiFemPagamentiObj.IdErogazioneFem);
        }
        //Insert
        private static int Insert(DbProvider db, ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZContrattiFemPagamentiInsert", new string[] {

"IdContrattoFem",
"IdProgetto", "CodTipo", "Estremi",
"Data", "Importo", "IdFile",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento", "IdImpresa", "IdDomandaPagamento",
"ImportoAmmesso", "IdErogazioneFem", }, new string[] {

"int",
"int", "string", "string",
"DateTime", "decimal", "int",
"DateTime", "int", "DateTime",
"int", "int", "int",
"decimal", "int", }, "");
                CompileIUCmd(false, insertCmd, ContrattiFemPagamentiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ContrattiFemPagamentiObj.IdContrattoFemPagamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM_PAGAMENTI"]);
                }
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZContrattiFemPagamentiUpdate", new string[] {

"IdContrattoFemPagamenti", "IdContrattoFem",
"IdProgetto", "CodTipo", "Estremi",
"Data", "Importo", "IdFile",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento", "IdImpresa", "IdDomandaPagamento",
"ImportoAmmesso", "IdErogazioneFem", }, new string[] {

"int", "int",
"int", "string", "string",
"DateTime", "decimal", "int",
"DateTime", "int", "DateTime",
"int", "int", "int",
"decimal", "int", }, "");
                CompileIUCmd(true, updateCmd, ContrattiFemPagamentiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            switch (ContrattiFemPagamentiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ContrattiFemPagamentiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ContrattiFemPagamentiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ContrattiFemPagamentiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZContrattiFemPagamentiUpdate", new string[] {

"IdContrattoFemPagamenti", "IdContrattoFem",
"IdProgetto", "CodTipo", "Estremi",
"Data", "Importo", "IdFile",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento", "IdImpresa", "IdDomandaPagamento",
"ImportoAmmesso", "IdErogazioneFem", }, new string[] {

"int", "int",
"int", "string", "string",
"DateTime", "decimal", "int",
"DateTime", "int", "DateTime",
"int", "int", "int",
"decimal", "int", }, "");
                IDbCommand insertCmd = db.InitCmd("ZContrattiFemPagamentiInsert", new string[] {

"IdContrattoFem",
"IdProgetto", "CodTipo", "Estremi",
"Data", "Importo", "IdFile",
"DataCreazione", "OperatoreCreazione", "DataAggiornamento",
"OperatoreAggiornamento", "IdImpresa", "IdDomandaPagamento",
"ImportoAmmesso", "IdErogazioneFem", }, new string[] {

"int",
"int", "string", "string",
"DateTime", "decimal", "int",
"DateTime", "int", "DateTime",
"int", "int", "int",
"decimal", "int", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZContrattiFemPagamentiDelete", new string[] { "IdContrattoFemPagamenti" }, new string[] { "int" }, "");
                for (int i = 0; i < ContrattiFemPagamentiCollectionObj.Count; i++)
                {
                    switch (ContrattiFemPagamentiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ContrattiFemPagamentiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ContrattiFemPagamentiCollectionObj[i].IdContrattoFemPagamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM_PAGAMENTI"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ContrattiFemPagamentiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ContrattiFemPagamentiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFemPagamenti", (SiarLibrary.NullTypes.IntNT)ContrattiFemPagamentiCollectionObj[i].IdContrattoFemPagamenti);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ContrattiFemPagamentiCollectionObj.Count; i++)
                {
                    if ((ContrattiFemPagamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContrattiFemPagamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ContrattiFemPagamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ContrattiFemPagamentiCollectionObj[i].IsDirty = false;
                        ContrattiFemPagamentiCollectionObj[i].IsPersistent = true;
                    }
                    if ((ContrattiFemPagamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ContrattiFemPagamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ContrattiFemPagamentiCollectionObj[i].IsDirty = false;
                        ContrattiFemPagamentiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, ContrattiFemPagamenti ContrattiFemPagamentiObj)
        {
            int returnValue = 0;
            if (ContrattiFemPagamentiObj.IsPersistent)
            {
                returnValue = Delete(db, ContrattiFemPagamentiObj.IdContrattoFemPagamenti);
            }
            ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ContrattiFemPagamentiObj.IsDirty = false;
            ContrattiFemPagamentiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdContrattoFemPagamentiValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZContrattiFemPagamentiDelete", new string[] { "IdContrattoFemPagamenti" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFemPagamenti", (SiarLibrary.NullTypes.IntNT)IdContrattoFemPagamentiValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZContrattiFemPagamentiDelete", new string[] { "IdContrattoFemPagamenti" }, new string[] { "int" }, "");
                for (int i = 0; i < ContrattiFemPagamentiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFemPagamenti", ContrattiFemPagamentiCollectionObj[i].IdContrattoFemPagamenti);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ContrattiFemPagamentiCollectionObj.Count; i++)
                {
                    if ((ContrattiFemPagamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContrattiFemPagamentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ContrattiFemPagamentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ContrattiFemPagamentiCollectionObj[i].IsDirty = false;
                        ContrattiFemPagamentiCollectionObj[i].IsPersistent = false;
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
        public static ContrattiFemPagamenti GetById(DbProvider db, int IdContrattoFemPagamentiValue)
        {
            ContrattiFemPagamenti ContrattiFemPagamentiObj = null;
            IDbCommand readCmd = db.InitCmd("ZContrattiFemPagamentiGetById", new string[] { "IdContrattoFemPagamenti" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdContrattoFemPagamenti", (SiarLibrary.NullTypes.IntNT)IdContrattoFemPagamentiValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ContrattiFemPagamentiObj = GetFromDatareader(db);
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
            }
            db.Close();
            return ContrattiFemPagamentiObj;
        }

        //getFromDatareader
        public static ContrattiFemPagamenti GetFromDatareader(DbProvider db)
        {
            ContrattiFemPagamenti ContrattiFemPagamentiObj = new ContrattiFemPagamenti();
            ContrattiFemPagamentiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            ContrattiFemPagamentiObj.IdProgettoContratto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_CONTRATTO"]);
            ContrattiFemPagamentiObj.DataStipulaContratto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_STIPULA_CONTRATTO"]);
            ContrattiFemPagamentiObj.SegnaturaContratto = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_CONTRATTO"]);
            ContrattiFemPagamentiObj.ImportoContratto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_CONTRATTO"]);
            ContrattiFemPagamentiObj.IdImpresaContratto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_CONTRATTO"]);
            ContrattiFemPagamentiObj.Confidi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFIDI"]);
            ContrattiFemPagamentiObj.IdContrattoFemPagamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM_PAGAMENTI"]);
            ContrattiFemPagamentiObj.IdContrattoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM"]);
            ContrattiFemPagamentiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ContrattiFemPagamentiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            ContrattiFemPagamentiObj.Estremi = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESTREMI"]);
            ContrattiFemPagamentiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            ContrattiFemPagamentiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            ContrattiFemPagamentiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            ContrattiFemPagamentiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            ContrattiFemPagamentiObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
            ContrattiFemPagamentiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
            ContrattiFemPagamentiObj.OperatoreAggiornamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_AGGIORNAMENTO"]);
            ContrattiFemPagamentiObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            ContrattiFemPagamentiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            ContrattiFemPagamentiObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
            ContrattiFemPagamentiObj.IdErogazioneFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_EROGAZIONE_FEM"]);
            ContrattiFemPagamentiObj.ImpresaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA_PAGAMENTO"]);
            ContrattiFemPagamentiObj.CodiceFiscaleImpresaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE_IMPRESA_PAGAMENTO"]);
            ContrattiFemPagamentiObj.CuaaImpresaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA_PAGAMENTO"]);
            ContrattiFemPagamentiObj.TipoPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_PAGAMENTO"]);
            ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ContrattiFemPagamentiObj.IsDirty = false;
            ContrattiFemPagamentiObj.IsPersistent = true;
            return ContrattiFemPagamentiObj;
        }

        //Find Select

        public static ContrattiFemPagamentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdContrattoFemPagamentiEqualThis, SiarLibrary.NullTypes.IntNT IdContrattoFemEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT EstremiEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreAggiornamentoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis,
SiarLibrary.NullTypes.IntNT IdErogazioneFemEqualThis)

        {

            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj = new ContrattiFemPagamentiCollection();

            IDbCommand findCmd = db.InitCmd("Zcontrattifempagamentifindselect", new string[] {"IdContrattoFemPagamentiequalthis", "IdContrattoFemequalthis", "IdProgettoequalthis",
"CodTipoequalthis", "Estremiequalthis", "Dataequalthis",
"Importoequalthis", "IdFileequalthis", "DataCreazioneequalthis",
"OperatoreCreazioneequalthis", "DataAggiornamentoequalthis", "OperatoreAggiornamentoequalthis",
"IdImpresaequalthis", "IdDomandaPagamentoequalthis", "ImportoAmmessoequalthis",
"IdErogazioneFemequalthis"}, new string[] {"int", "int", "int",
"string", "string", "DateTime",
"decimal", "int", "DateTime",
"int", "DateTime", "int",
"int", "int", "decimal",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemPagamentiequalthis", IdContrattoFemPagamentiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemequalthis", IdContrattoFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Estremiequalthis", EstremiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreAggiornamentoequalthis", OperatoreAggiornamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErogazioneFemequalthis", IdErogazioneFemEqualThis);
            ContrattiFemPagamenti ContrattiFemPagamentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ContrattiFemPagamentiObj = GetFromDatareader(db);
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
                ContrattiFemPagamentiCollectionObj.Add(ContrattiFemPagamentiObj);
            }
            db.Close();
            return ContrattiFemPagamentiCollectionObj;
        }

        //Find Find

        public static ContrattiFemPagamentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdContrattoFemPagamentiEqualThis, SiarLibrary.NullTypes.IntNT IdContrattoFemEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis)

        {

            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj = new ContrattiFemPagamentiCollection();

            IDbCommand findCmd = db.InitCmd("Zcontrattifempagamentifindfind", new string[] {"IdContrattoFemPagamentiequalthis", "IdContrattoFemequalthis", "IdProgettoequalthis",
"IdImpresaequalthis", "IdDomandaPagamentoequalthis"}, new string[] {"int", "int", "int",
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemPagamentiequalthis", IdContrattoFemPagamentiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemequalthis", IdContrattoFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            ContrattiFemPagamenti ContrattiFemPagamentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ContrattiFemPagamentiObj = GetFromDatareader(db);
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
                ContrattiFemPagamentiCollectionObj.Add(ContrattiFemPagamentiObj);
            }
            db.Close();
            return ContrattiFemPagamentiCollectionObj;
        }

        //Find FindPagamentiErogazione

        public static ContrattiFemPagamentiCollection FindPagamentiErogazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdContrattoFemPagamentiEqualThis, SiarLibrary.NullTypes.IntNT IdContrattoFemEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdErogazioneFemEqualThis,
SiarLibrary.NullTypes.BoolNT ConfidiEqualThis)

        {

            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionObj = new ContrattiFemPagamentiCollection();

            IDbCommand findCmd = db.InitCmd("Zcontrattifempagamentifindfindpagamentierogazione", new string[] {"IdBandoequalthis", "IdContrattoFemPagamentiequalthis", "IdContrattoFemequalthis",
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdErogazioneFemequalthis",
"Confidiequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemPagamentiequalthis", IdContrattoFemPagamentiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemequalthis", IdContrattoFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErogazioneFemequalthis", IdErogazioneFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Confidiequalthis", ConfidiEqualThis);
            ContrattiFemPagamenti ContrattiFemPagamentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ContrattiFemPagamentiObj = GetFromDatareader(db);
                ContrattiFemPagamentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ContrattiFemPagamentiObj.IsDirty = false;
                ContrattiFemPagamentiObj.IsPersistent = true;
                ContrattiFemPagamentiCollectionObj.Add(ContrattiFemPagamentiObj);
            }
            db.Close();
            return ContrattiFemPagamentiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ContrattiFemPagamentiCollectionProvider:IContrattiFemPagamentiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ContrattiFemPagamentiCollectionProvider : IContrattiFemPagamentiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di ContrattiFemPagamenti
        protected ContrattiFemPagamentiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ContrattiFemPagamentiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ContrattiFemPagamentiCollection(this);
        }

        //Costruttore 2: popola la collection
        public ContrattiFemPagamentiCollectionProvider(IntNT IdcontrattofempagamentiEqualThis, IntNT IdcontrattofemEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresaEqualThis, IntNT IddomandapagamentoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdcontrattofempagamentiEqualThis, IdcontrattofemEqualThis, IdprogettoEqualThis,
IdimpresaEqualThis, IddomandapagamentoEqualThis);
        }

        //Costruttore3: ha in input contrattifempagamentiCollectionObj - non popola la collection
        public ContrattiFemPagamentiCollectionProvider(ContrattiFemPagamentiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ContrattiFemPagamentiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ContrattiFemPagamentiCollection(this);
        }

        //Get e Set
        public ContrattiFemPagamentiCollection CollectionObj
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
        public int SaveCollection(ContrattiFemPagamentiCollection collectionObj)
        {
            return ContrattiFemPagamentiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(ContrattiFemPagamenti contrattifempagamentiObj)
        {
            return ContrattiFemPagamentiDAL.Save(_dbProviderObj, contrattifempagamentiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ContrattiFemPagamentiCollection collectionObj)
        {
            return ContrattiFemPagamentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(ContrattiFemPagamenti contrattifempagamentiObj)
        {
            return ContrattiFemPagamentiDAL.Delete(_dbProviderObj, contrattifempagamentiObj);
        }

        //getById
        public ContrattiFemPagamenti GetById(IntNT IdContrattoFemPagamentiValue)
        {
            ContrattiFemPagamenti ContrattiFemPagamentiTemp = ContrattiFemPagamentiDAL.GetById(_dbProviderObj, IdContrattoFemPagamentiValue);
            if (ContrattiFemPagamentiTemp != null) ContrattiFemPagamentiTemp.Provider = this;
            return ContrattiFemPagamentiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ContrattiFemPagamentiCollection Select(IntNT IdcontrattofempagamentiEqualThis, IntNT IdcontrattofemEqualThis, IntNT IdprogettoEqualThis,
StringNT CodtipoEqualThis, StringNT EstremiEqualThis, DatetimeNT DataEqualThis,
DecimalNT ImportoEqualThis, IntNT IdfileEqualThis, DatetimeNT DatacreazioneEqualThis,
IntNT OperatorecreazioneEqualThis, DatetimeNT DataaggiornamentoEqualThis, IntNT OperatoreaggiornamentoEqualThis,
IntNT IdimpresaEqualThis, IntNT IddomandapagamentoEqualThis, DecimalNT ImportoammessoEqualThis,
IntNT IderogazionefemEqualThis)
        {
            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionTemp = ContrattiFemPagamentiDAL.Select(_dbProviderObj, IdcontrattofempagamentiEqualThis, IdcontrattofemEqualThis, IdprogettoEqualThis,
CodtipoEqualThis, EstremiEqualThis, DataEqualThis,
ImportoEqualThis, IdfileEqualThis, DatacreazioneEqualThis,
OperatorecreazioneEqualThis, DataaggiornamentoEqualThis, OperatoreaggiornamentoEqualThis,
IdimpresaEqualThis, IddomandapagamentoEqualThis, ImportoammessoEqualThis,
IderogazionefemEqualThis);
            ContrattiFemPagamentiCollectionTemp.Provider = this;
            return ContrattiFemPagamentiCollectionTemp;
        }

        //Find: popola la collection
        public ContrattiFemPagamentiCollection Find(IntNT IdcontrattofempagamentiEqualThis, IntNT IdcontrattofemEqualThis, IntNT IdprogettoEqualThis,
IntNT IdimpresaEqualThis, IntNT IddomandapagamentoEqualThis)
        {
            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionTemp = ContrattiFemPagamentiDAL.Find(_dbProviderObj, IdcontrattofempagamentiEqualThis, IdcontrattofemEqualThis, IdprogettoEqualThis,
IdimpresaEqualThis, IddomandapagamentoEqualThis);
            ContrattiFemPagamentiCollectionTemp.Provider = this;
            return ContrattiFemPagamentiCollectionTemp;
        }

        //FindPagamentiErogazione: popola la collection
        public ContrattiFemPagamentiCollection FindPagamentiErogazione(IntNT IdbandoEqualThis, IntNT IdcontrattofempagamentiEqualThis, IntNT IdcontrattofemEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IderogazionefemEqualThis,
BoolNT ConfidiEqualThis)
        {
            ContrattiFemPagamentiCollection ContrattiFemPagamentiCollectionTemp = ContrattiFemPagamentiDAL.FindPagamentiErogazione(_dbProviderObj, IdbandoEqualThis, IdcontrattofempagamentiEqualThis, IdcontrattofemEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IderogazionefemEqualThis,
ConfidiEqualThis);
            ContrattiFemPagamentiCollectionTemp.Provider = this;
            return ContrattiFemPagamentiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTRATTI_FEM_PAGAMENTI>
  <ViewName>VCONTRATTI_FEM_PAGAMENTI</ViewName>
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
      <ID_CONTRATTO_FEM_PAGAMENTI>Equal</ID_CONTRATTO_FEM_PAGAMENTI>
      <ID_CONTRATTO_FEM>Equal</ID_CONTRATTO_FEM>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </Find>
    <FindPagamentiErogazione OrderBy="ORDER BY ">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_CONTRATTO_FEM_PAGAMENTI>Equal</ID_CONTRATTO_FEM_PAGAMENTI>
      <ID_CONTRATTO_FEM>Equal</ID_CONTRATTO_FEM>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_EROGAZIONE_FEM>Equal</ID_EROGAZIONE_FEM>
      <CONFIDI>Equal</CONFIDI>
    </FindPagamentiErogazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTRATTI_FEM_PAGAMENTI>
*/
