using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per PagamentiRichiestiFem
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IPagamentiRichiestiFemProvider
    {
        int Save(PagamentiRichiestiFem PagamentiRichiestiFemObj);
        int SaveCollection(PagamentiRichiestiFemCollection collectionObj);
        int Delete(PagamentiRichiestiFem PagamentiRichiestiFemObj);
        int DeleteCollection(PagamentiRichiestiFemCollection collectionObj);
    }
    /// <summary>
    /// Summary description for PagamentiRichiestiFem
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class PagamentiRichiestiFem : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdPagamentoRichiestoFem;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.IntNT _IdContratto;
        private NullTypes.IntNT _IdInvestimento;
        private NullTypes.DecimalNT _ImportoRichiesto;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.BoolNT _Ammesso;
        private NullTypes.StringNT _CfIstruttore;
        private NullTypes.DatetimeNT _DataValutazione;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.StringNT _NoteIstruttore;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdGiustificativo;
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdImpresaContratto;
        private NullTypes.StringNT _ImpresaContratto;
        private NullTypes.DecimalNT _ImportoContratto;
        private NullTypes.StringNT _SegnaturaContratto;
        private NullTypes.DatetimeNT _DataContratto;
        private NullTypes.StringNT _NumeroGiustificativo;
        private NullTypes.StringNT _CodTipoGiustificativo;
        private NullTypes.StringNT _TipoGiustificativo;
        private NullTypes.DatetimeNT _DataGiustificativo;
        private NullTypes.DecimalNT _ImponibileGiustificativo;
        private NullTypes.DecimalNT _IvaGiustificativo;
        private NullTypes.StringNT _DescrizioneGiustificativo;
        private NullTypes.StringNT _CfFornitoreGiustificativo;
        private NullTypes.StringNT _DescrizioneFornitoreGiustificativo;
        private NullTypes.BoolNT _IvaNonRecuperabileGiustificativo;
        private NullTypes.IntNT _IdFileGiustificativo;
        private NullTypes.BoolNT _InIntegrazioneGiustificativo;
        private NullTypes.BoolNT _IdFileModificatoIntegrazioneGiustificativo;
        [NonSerialized] private IPagamentiRichiestiFemProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPagamentiRichiestiFemProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public PagamentiRichiestiFem()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_PAGAMENTO_RICHIESTO_FEM
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPagamentoRichiestoFem
        {
            get { return _IdPagamentoRichiestoFem; }
            set
            {
                if (IdPagamentoRichiestoFem != value)
                {
                    _IdPagamentoRichiestoFem = value;
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
        /// Corrisponde al campo:ID_CONTRATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdContratto
        {
            get { return _IdContratto; }
            set
            {
                if (IdContratto != value)
                {
                    _IdContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdInvestimento
        {
            get { return _IdInvestimento; }
            set
            {
                if (IdInvestimento != value)
                {
                    _IdInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRichiesto
        {
            get { return _ImportoRichiesto; }
            set
            {
                if (ImportoRichiesto != value)
                {
                    _ImportoRichiesto = value;
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
        /// Corrisponde al campo:AMMESSO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Ammesso
        {
            get { return _Ammesso; }
            set
            {
                if (Ammesso != value)
                {
                    _Ammesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_ISTRUTTORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfIstruttore
        {
            get { return _CfIstruttore; }
            set
            {
                if (CfIstruttore != value)
                {
                    _CfIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VALUTAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataValutazione
        {
            get { return _DataValutazione; }
            set
            {
                if (DataValutazione != value)
                {
                    _DataValutazione = value;
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
        /// Corrisponde al campo:NOTE_ISTRUTTORE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT NoteIstruttore
        {
            get { return _NoteIstruttore; }
            set
            {
                if (NoteIstruttore != value)
                {
                    _NoteIstruttore = value;
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
        /// Corrisponde al campo:ID_GIUSTIFICATIVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdGiustificativo
        {
            get { return _IdGiustificativo; }
            set
            {
                if (IdGiustificativo != value)
                {
                    _IdGiustificativo = value;
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
        /// Corrisponde al campo:IMPRESA_CONTRATTO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ImpresaContratto
        {
            get { return _ImpresaContratto; }
            set
            {
                if (ImpresaContratto != value)
                {
                    _ImpresaContratto = value;
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
        /// Corrisponde al campo:DATA_CONTRATTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataContratto
        {
            get { return _DataContratto; }
            set
            {
                if (DataContratto != value)
                {
                    _DataContratto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_GIUSTIFICATIVO
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT NumeroGiustificativo
        {
            get { return _NumeroGiustificativo; }
            set
            {
                if (NumeroGiustificativo != value)
                {
                    _NumeroGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO_GIUSTIFICATIVO
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT CodTipoGiustificativo
        {
            get { return _CodTipoGiustificativo; }
            set
            {
                if (CodTipoGiustificativo != value)
                {
                    _CodTipoGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_GIUSTIFICATIVO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TipoGiustificativo
        {
            get { return _TipoGiustificativo; }
            set
            {
                if (TipoGiustificativo != value)
                {
                    _TipoGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_GIUSTIFICATIVO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataGiustificativo
        {
            get { return _DataGiustificativo; }
            set
            {
                if (DataGiustificativo != value)
                {
                    _DataGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPONIBILE_GIUSTIFICATIVO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImponibileGiustificativo
        {
            get { return _ImponibileGiustificativo; }
            set
            {
                if (ImponibileGiustificativo != value)
                {
                    _ImponibileGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IVA_GIUSTIFICATIVO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT IvaGiustificativo
        {
            get { return _IvaGiustificativo; }
            set
            {
                if (IvaGiustificativo != value)
                {
                    _IvaGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_GIUSTIFICATIVO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneGiustificativo
        {
            get { return _DescrizioneGiustificativo; }
            set
            {
                if (DescrizioneGiustificativo != value)
                {
                    _DescrizioneGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_FORNITORE_GIUSTIFICATIVO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfFornitoreGiustificativo
        {
            get { return _CfFornitoreGiustificativo; }
            set
            {
                if (CfFornitoreGiustificativo != value)
                {
                    _CfFornitoreGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_FORNITORE_GIUSTIFICATIVO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneFornitoreGiustificativo
        {
            get { return _DescrizioneFornitoreGiustificativo; }
            set
            {
                if (DescrizioneFornitoreGiustificativo != value)
                {
                    _DescrizioneFornitoreGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IVA_NON_RECUPERABILE_GIUSTIFICATIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IvaNonRecuperabileGiustificativo
        {
            get { return _IvaNonRecuperabileGiustificativo; }
            set
            {
                if (IvaNonRecuperabileGiustificativo != value)
                {
                    _IvaNonRecuperabileGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_GIUSTIFICATIVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFileGiustificativo
        {
            get { return _IdFileGiustificativo; }
            set
            {
                if (IdFileGiustificativo != value)
                {
                    _IdFileGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IN_INTEGRAZIONE_GIUSTIFICATIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT InIntegrazioneGiustificativo
        {
            get { return _InIntegrazioneGiustificativo; }
            set
            {
                if (InIntegrazioneGiustificativo != value)
                {
                    _InIntegrazioneGiustificativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IdFileModificatoIntegrazioneGiustificativo
        {
            get { return _IdFileModificatoIntegrazioneGiustificativo; }
            set
            {
                if (IdFileModificatoIntegrazioneGiustificativo != value)
                {
                    _IdFileModificatoIntegrazioneGiustificativo = value;
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
    /// Summary description for PagamentiRichiestiFemCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PagamentiRichiestiFemCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private PagamentiRichiestiFemCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((PagamentiRichiestiFem)info.GetValue(i.ToString(), typeof(PagamentiRichiestiFem)));
            }
        }

        //Costruttore
        public PagamentiRichiestiFemCollection()
        {
            this.ItemType = typeof(PagamentiRichiestiFem);
        }

        //Costruttore con provider
        public PagamentiRichiestiFemCollection(IPagamentiRichiestiFemProvider providerObj)
        {
            this.ItemType = typeof(PagamentiRichiestiFem);
            this.Provider = providerObj;
        }

        //Get e Set
        public new PagamentiRichiestiFem this[int index]
        {
            get { return (PagamentiRichiestiFem)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new PagamentiRichiestiFemCollection GetChanges()
        {
            return (PagamentiRichiestiFemCollection)base.GetChanges();
        }

        [NonSerialized] private IPagamentiRichiestiFemProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPagamentiRichiestiFemProvider Provider
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
        public int Add(PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            if (PagamentiRichiestiFemObj.Provider == null) PagamentiRichiestiFemObj.Provider = this.Provider;
            return base.Add(PagamentiRichiestiFemObj);
        }

        //AddCollection
        public void AddCollection(PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionObj)
        {
            foreach (PagamentiRichiestiFem PagamentiRichiestiFemObj in PagamentiRichiestiFemCollectionObj)
                this.Add(PagamentiRichiestiFemObj);
        }

        //Insert
        public void Insert(int index, PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            if (PagamentiRichiestiFemObj.Provider == null) PagamentiRichiestiFemObj.Provider = this.Provider;
            base.Insert(index, PagamentiRichiestiFemObj);
        }

        //CollectionGetById
        public PagamentiRichiestiFem CollectionGetById(NullTypes.IntNT IdPagamentoRichiestoFemValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdPagamentoRichiestoFem == IdPagamentoRichiestoFemValue))
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
        public PagamentiRichiestiFemCollection SubSelect(NullTypes.IntNT IdPagamentoRichiestoFemEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis,
NullTypes.IntNT IdContrattoEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.DecimalNT ImportoRichiestoEqualThis,
NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.BoolNT AmmessoEqualThis, NullTypes.StringNT CfIstruttoreEqualThis,
NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.StringNT NoteIstruttoreEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis)
        {
            PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionTemp = new PagamentiRichiestiFemCollection();
            foreach (PagamentiRichiestiFem PagamentiRichiestiFemItem in this)
            {
                if (((IdPagamentoRichiestoFemEqualThis == null) || ((PagamentiRichiestiFemItem.IdPagamentoRichiestoFem != null) && (PagamentiRichiestiFemItem.IdPagamentoRichiestoFem.Value == IdPagamentoRichiestoFemEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((PagamentiRichiestiFemItem.DataInserimento != null) && (PagamentiRichiestiFemItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((PagamentiRichiestiFemItem.CfInserimento != null) && (PagamentiRichiestiFemItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) &&
((IdContrattoEqualThis == null) || ((PagamentiRichiestiFemItem.IdContratto != null) && (PagamentiRichiestiFemItem.IdContratto.Value == IdContrattoEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PagamentiRichiestiFemItem.IdInvestimento != null) && (PagamentiRichiestiFemItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((ImportoRichiestoEqualThis == null) || ((PagamentiRichiestiFemItem.ImportoRichiesto != null) && (PagamentiRichiestiFemItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) &&
((ImportoAmmessoEqualThis == null) || ((PagamentiRichiestiFemItem.ImportoAmmesso != null) && (PagamentiRichiestiFemItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PagamentiRichiestiFemItem.Ammesso != null) && (PagamentiRichiestiFemItem.Ammesso.Value == AmmessoEqualThis.Value))) && ((CfIstruttoreEqualThis == null) || ((PagamentiRichiestiFemItem.CfIstruttore != null) && (PagamentiRichiestiFemItem.CfIstruttore.Value == CfIstruttoreEqualThis.Value))) &&
((DataValutazioneEqualThis == null) || ((PagamentiRichiestiFemItem.DataValutazione != null) && (PagamentiRichiestiFemItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((DataModificaEqualThis == null) || ((PagamentiRichiestiFemItem.DataModifica != null) && (PagamentiRichiestiFemItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((PagamentiRichiestiFemItem.CfModifica != null) && (PagamentiRichiestiFemItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((NoteIstruttoreEqualThis == null) || ((PagamentiRichiestiFemItem.NoteIstruttore != null) && (PagamentiRichiestiFemItem.NoteIstruttore.Value == NoteIstruttoreEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((PagamentiRichiestiFemItem.IdDomandaPagamento != null) && (PagamentiRichiestiFemItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((PagamentiRichiestiFemItem.IdGiustificativo != null) && (PagamentiRichiestiFemItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))))
                {
                    PagamentiRichiestiFemCollectionTemp.Add(PagamentiRichiestiFemItem);
                }
            }
            return PagamentiRichiestiFemCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for PagamentiRichiestiFemDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class PagamentiRichiestiFemDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PagamentiRichiestiFem PagamentiRichiestiFemObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdPagamentoRichiestoFem", PagamentiRichiestiFemObj.IdPagamentoRichiestoFem);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", PagamentiRichiestiFemObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", PagamentiRichiestiFemObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdContratto", PagamentiRichiestiFemObj.IdContratto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdInvestimento", PagamentiRichiestiFemObj.IdInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRichiesto", PagamentiRichiestiFemObj.ImportoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoAmmesso", PagamentiRichiestiFemObj.ImportoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "Ammesso", PagamentiRichiestiFemObj.Ammesso);
            DbProvider.SetCmdParam(cmd, firstChar + "CfIstruttore", PagamentiRichiestiFemObj.CfIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataValutazione", PagamentiRichiestiFemObj.DataValutazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", PagamentiRichiestiFemObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", PagamentiRichiestiFemObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteIstruttore", PagamentiRichiestiFemObj.NoteIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", PagamentiRichiestiFemObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativo", PagamentiRichiestiFemObj.IdGiustificativo);
        }
        //Insert
        private static int Insert(DbProvider db, PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZPagamentiRichiestiFemInsert", new string[] {"DataInserimento", "CfInserimento",
"IdContratto", "IdInvestimento", "ImportoRichiesto",
"ImportoAmmesso", "Ammesso", "CfIstruttore",
"DataValutazione", "DataModifica", "CfModifica",
"NoteIstruttore", "IdDomandaPagamento", "IdGiustificativo",





}, new string[] {"DateTime", "string",
"int", "int", "decimal",
"decimal", "bool", "string",
"DateTime", "DateTime", "string",
"string", "int", "int",





}, "");
                CompileIUCmd(false, insertCmd, PagamentiRichiestiFemObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    PagamentiRichiestiFemObj.IdPagamentoRichiestoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO_FEM"]);
                    PagamentiRichiestiFemObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                    PagamentiRichiestiFemObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiFemObj.IsDirty = false;
                PagamentiRichiestiFemObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPagamentiRichiestiFemUpdate", new string[] {"IdPagamentoRichiestoFem", "DataInserimento", "CfInserimento",
"IdContratto", "IdInvestimento", "ImportoRichiesto",
"ImportoAmmesso", "Ammesso", "CfIstruttore",
"DataValutazione", "DataModifica", "CfModifica",
"NoteIstruttore", "IdDomandaPagamento", "IdGiustificativo",





}, new string[] {"int", "DateTime", "string",
"int", "int", "decimal",
"decimal", "bool", "string",
"DateTime", "DateTime", "string",
"string", "int", "int",





}, "");
                CompileIUCmd(true, updateCmd, PagamentiRichiestiFemObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    PagamentiRichiestiFemObj.DataModifica = d;
                }
                PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiFemObj.IsDirty = false;
                PagamentiRichiestiFemObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            switch (PagamentiRichiestiFemObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, PagamentiRichiestiFemObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, PagamentiRichiestiFemObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, PagamentiRichiestiFemObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPagamentiRichiestiFemUpdate", new string[] {"IdPagamentoRichiestoFem", "DataInserimento", "CfInserimento",
"IdContratto", "IdInvestimento", "ImportoRichiesto",
"ImportoAmmesso", "Ammesso", "CfIstruttore",
"DataValutazione", "DataModifica", "CfModifica",
"NoteIstruttore", "IdDomandaPagamento", "IdGiustificativo",





}, new string[] {"int", "DateTime", "string",
"int", "int", "decimal",
"decimal", "bool", "string",
"DateTime", "DateTime", "string",
"string", "int", "int",





}, "");
                IDbCommand insertCmd = db.InitCmd("ZPagamentiRichiestiFemInsert", new string[] {"DataInserimento", "CfInserimento",
"IdContratto", "IdInvestimento", "ImportoRichiesto",
"ImportoAmmesso", "Ammesso", "CfIstruttore",
"DataValutazione", "DataModifica", "CfModifica",
"NoteIstruttore", "IdDomandaPagamento", "IdGiustificativo",





}, new string[] {"DateTime", "string",
"int", "int", "decimal",
"decimal", "bool", "string",
"DateTime", "DateTime", "string",
"string", "int", "int",





}, "");
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiFemDelete", new string[] { "IdPagamentoRichiestoFem" }, new string[] { "int" }, "");
                for (int i = 0; i < PagamentiRichiestiFemCollectionObj.Count; i++)
                {
                    switch (PagamentiRichiestiFemCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, PagamentiRichiestiFemCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    PagamentiRichiestiFemCollectionObj[i].IdPagamentoRichiestoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO_FEM"]);
                                    PagamentiRichiestiFemCollectionObj[i].Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                                    PagamentiRichiestiFemCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, PagamentiRichiestiFemCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    PagamentiRichiestiFemCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (PagamentiRichiestiFemCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiestoFem", (SiarLibrary.NullTypes.IntNT)PagamentiRichiestiFemCollectionObj[i].IdPagamentoRichiestoFem);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < PagamentiRichiestiFemCollectionObj.Count; i++)
                {
                    if ((PagamentiRichiestiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiRichiestiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PagamentiRichiestiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        PagamentiRichiestiFemCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiFemCollectionObj[i].IsPersistent = true;
                    }
                    if ((PagamentiRichiestiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        PagamentiRichiestiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PagamentiRichiestiFemCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiFemCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, PagamentiRichiestiFem PagamentiRichiestiFemObj)
        {
            int returnValue = 0;
            if (PagamentiRichiestiFemObj.IsPersistent)
            {
                returnValue = Delete(db, PagamentiRichiestiFemObj.IdPagamentoRichiestoFem);
            }
            PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            PagamentiRichiestiFemObj.IsDirty = false;
            PagamentiRichiestiFemObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdPagamentoRichiestoFemValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiFemDelete", new string[] { "IdPagamentoRichiestoFem" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiestoFem", (SiarLibrary.NullTypes.IntNT)IdPagamentoRichiestoFemValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiFemDelete", new string[] { "IdPagamentoRichiestoFem" }, new string[] { "int" }, "");
                for (int i = 0; i < PagamentiRichiestiFemCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiestoFem", PagamentiRichiestiFemCollectionObj[i].IdPagamentoRichiestoFem);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < PagamentiRichiestiFemCollectionObj.Count; i++)
                {
                    if ((PagamentiRichiestiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiRichiestiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PagamentiRichiestiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PagamentiRichiestiFemCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiFemCollectionObj[i].IsPersistent = false;
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
        public static PagamentiRichiestiFem GetById(DbProvider db, int IdPagamentoRichiestoFemValue)
        {
            PagamentiRichiestiFem PagamentiRichiestiFemObj = null;
            IDbCommand readCmd = db.InitCmd("ZPagamentiRichiestiFemGetById", new string[] { "IdPagamentoRichiestoFem" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdPagamentoRichiestoFem", (SiarLibrary.NullTypes.IntNT)IdPagamentoRichiestoFemValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                PagamentiRichiestiFemObj = GetFromDatareader(db);
                PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiFemObj.IsDirty = false;
                PagamentiRichiestiFemObj.IsPersistent = true;
            }
            db.Close();
            return PagamentiRichiestiFemObj;
        }

        //getFromDatareader
        public static PagamentiRichiestiFem GetFromDatareader(DbProvider db)
        {
            PagamentiRichiestiFem PagamentiRichiestiFemObj = new PagamentiRichiestiFem();
            PagamentiRichiestiFemObj.IdPagamentoRichiestoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO_FEM"]);
            PagamentiRichiestiFemObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            PagamentiRichiestiFemObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            PagamentiRichiestiFemObj.IdContratto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO"]);
            PagamentiRichiestiFemObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
            PagamentiRichiestiFemObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
            PagamentiRichiestiFemObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
            PagamentiRichiestiFemObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
            PagamentiRichiestiFemObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
            PagamentiRichiestiFemObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
            PagamentiRichiestiFemObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            PagamentiRichiestiFemObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            PagamentiRichiestiFemObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
            PagamentiRichiestiFemObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            PagamentiRichiestiFemObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            PagamentiRichiestiFemObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            PagamentiRichiestiFemObj.IdImpresaContratto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_CONTRATTO"]);
            PagamentiRichiestiFemObj.ImpresaContratto = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA_CONTRATTO"]);
            PagamentiRichiestiFemObj.ImportoContratto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_CONTRATTO"]);
            PagamentiRichiestiFemObj.SegnaturaContratto = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_CONTRATTO"]);
            PagamentiRichiestiFemObj.DataContratto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONTRATTO"]);
            PagamentiRichiestiFemObj.NumeroGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.CodTipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.DataGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.ImponibileGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.IvaGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.DescrizioneGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.CfFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.DescrizioneFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.IvaNonRecuperabileGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.IdFileGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.InIntegrazioneGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.IdFileModificatoIntegrazioneGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO"]);
            PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            PagamentiRichiestiFemObj.IsDirty = false;
            PagamentiRichiestiFemObj.IsPersistent = true;
            return PagamentiRichiestiFemObj;
        }

        //Find Select

        public static PagamentiRichiestiFemCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoFemEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdContrattoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, SiarLibrary.NullTypes.StringNT CfIstruttoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.StringNT NoteIstruttoreEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis)

        {

            PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionObj = new PagamentiRichiestiFemCollection();

            IDbCommand findCmd = db.InitCmd("Zpagamentirichiestifemfindselect", new string[] {"IdPagamentoRichiestoFemequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis",
"IdContrattoequalthis", "IdInvestimentoequalthis", "ImportoRichiestoequalthis",
"ImportoAmmessoequalthis", "Ammessoequalthis", "CfIstruttoreequalthis",
"DataValutazioneequalthis", "DataModificaequalthis", "CfModificaequalthis",
"NoteIstruttoreequalthis", "IdDomandaPagamentoequalthis", "IdGiustificativoequalthis"}, new string[] {"int", "DateTime", "string",
"int", "int", "decimal",
"decimal", "bool", "string",
"DateTime", "DateTime", "string",
"string", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPagamentoRichiestoFemequalthis", IdPagamentoRichiestoFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoequalthis", IdContrattoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfIstruttoreequalthis", CfIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NoteIstruttoreequalthis", NoteIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            PagamentiRichiestiFem PagamentiRichiestiFemObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PagamentiRichiestiFemObj = GetFromDatareader(db);
                PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiFemObj.IsDirty = false;
                PagamentiRichiestiFemObj.IsPersistent = true;
                PagamentiRichiestiFemCollectionObj.Add(PagamentiRichiestiFemObj);
            }
            db.Close();
            return PagamentiRichiestiFemCollectionObj;
        }

        //Find Find

        public static PagamentiRichiestiFemCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoFemEqualThis, SiarLibrary.NullTypes.IntNT IdContrattoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis)

        {

            PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionObj = new PagamentiRichiestiFemCollection();

            IDbCommand findCmd = db.InitCmd("Zpagamentirichiestifemfindfind", new string[] {"IdPagamentoRichiestoFemequalthis", "IdContrattoequalthis", "IdInvestimentoequalthis",
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdGiustificativoequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPagamentoRichiestoFemequalthis", IdPagamentoRichiestoFemEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoequalthis", IdContrattoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            PagamentiRichiestiFem PagamentiRichiestiFemObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PagamentiRichiestiFemObj = GetFromDatareader(db);
                PagamentiRichiestiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiFemObj.IsDirty = false;
                PagamentiRichiestiFemObj.IsPersistent = true;
                PagamentiRichiestiFemCollectionObj.Add(PagamentiRichiestiFemObj);
            }
            db.Close();
            return PagamentiRichiestiFemCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for PagamentiRichiestiFemCollectionProvider:IPagamentiRichiestiFemProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PagamentiRichiestiFemCollectionProvider : IPagamentiRichiestiFemProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di PagamentiRichiestiFem
        protected PagamentiRichiestiFemCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public PagamentiRichiestiFemCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new PagamentiRichiestiFemCollection(this);
        }

        //Costruttore 2: popola la collection
        public PagamentiRichiestiFemCollectionProvider(IntNT IdpagamentorichiestofemEqualThis, IntNT IdcontrattoEqualThis, IntNT IdinvestimentoEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdpagamentorichiestofemEqualThis, IdcontrattoEqualThis, IdinvestimentoEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis);
        }

        //Costruttore3: ha in input pagamentirichiestifemCollectionObj - non popola la collection
        public PagamentiRichiestiFemCollectionProvider(PagamentiRichiestiFemCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public PagamentiRichiestiFemCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new PagamentiRichiestiFemCollection(this);
        }

        //Get e Set
        public PagamentiRichiestiFemCollection CollectionObj
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
        public int SaveCollection(PagamentiRichiestiFemCollection collectionObj)
        {
            return PagamentiRichiestiFemDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(PagamentiRichiestiFem pagamentirichiestifemObj)
        {
            return PagamentiRichiestiFemDAL.Save(_dbProviderObj, pagamentirichiestifemObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(PagamentiRichiestiFemCollection collectionObj)
        {
            return PagamentiRichiestiFemDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(PagamentiRichiestiFem pagamentirichiestifemObj)
        {
            return PagamentiRichiestiFemDAL.Delete(_dbProviderObj, pagamentirichiestifemObj);
        }

        //getById
        public PagamentiRichiestiFem GetById(IntNT IdPagamentoRichiestoFemValue)
        {
            PagamentiRichiestiFem PagamentiRichiestiFemTemp = PagamentiRichiestiFemDAL.GetById(_dbProviderObj, IdPagamentoRichiestoFemValue);
            if (PagamentiRichiestiFemTemp != null) PagamentiRichiestiFemTemp.Provider = this;
            return PagamentiRichiestiFemTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public PagamentiRichiestiFemCollection Select(IntNT IdpagamentorichiestofemEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis,
IntNT IdcontrattoEqualThis, IntNT IdinvestimentoEqualThis, DecimalNT ImportorichiestoEqualThis,
DecimalNT ImportoammessoEqualThis, BoolNT AmmessoEqualThis, StringNT CfistruttoreEqualThis,
DatetimeNT DatavalutazioneEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis,
StringNT NoteistruttoreEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis)
        {
            PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionTemp = PagamentiRichiestiFemDAL.Select(_dbProviderObj, IdpagamentorichiestofemEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis,
IdcontrattoEqualThis, IdinvestimentoEqualThis, ImportorichiestoEqualThis,
ImportoammessoEqualThis, AmmessoEqualThis, CfistruttoreEqualThis,
DatavalutazioneEqualThis, DatamodificaEqualThis, CfmodificaEqualThis,
NoteistruttoreEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis);
            PagamentiRichiestiFemCollectionTemp.Provider = this;
            return PagamentiRichiestiFemCollectionTemp;
        }

        //Find: popola la collection
        public PagamentiRichiestiFemCollection Find(IntNT IdpagamentorichiestofemEqualThis, IntNT IdcontrattoEqualThis, IntNT IdinvestimentoEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis)
        {
            PagamentiRichiestiFemCollection PagamentiRichiestiFemCollectionTemp = PagamentiRichiestiFemDAL.Find(_dbProviderObj, IdpagamentorichiestofemEqualThis, IdcontrattoEqualThis, IdinvestimentoEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis);
            PagamentiRichiestiFemCollectionTemp.Provider = this;
            return PagamentiRichiestiFemCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGAMENTI_RICHIESTI_FEM>
  <ViewName>VPAGAMENTI_RICHIESTI_FEM</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INSERIMENTO DESC">
      <ID_PAGAMENTO_RICHIESTO_FEM>Equal</ID_PAGAMENTO_RICHIESTO_FEM>
      <ID_CONTRATTO>Equal</ID_CONTRATTO>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PAGAMENTI_RICHIESTI_FEM>
*/
