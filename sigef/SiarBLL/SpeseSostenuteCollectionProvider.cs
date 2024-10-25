using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per SpeseSostenute
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ISpeseSostenuteProvider
    {
        int Save(SpeseSostenute SpeseSostenuteObj);
        int SaveCollection(SpeseSostenuteCollection collectionObj);
        int Delete(SpeseSostenute SpeseSostenuteObj);
        int DeleteCollection(SpeseSostenuteCollection collectionObj);
    }
    /// <summary>
    /// Summary description for SpeseSostenute
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class SpeseSostenute : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdSpesa;
        private NullTypes.IntNT _IdGiustificativo;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _Estremi;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.DecimalNT _Netto;
        private NullTypes.StringNT _TipoPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Numero;
        private NullTypes.StringNT _CodTipoGiustificativo;
        private NullTypes.DatetimeNT _DataGiustificativo;
        private NullTypes.StringNT _NumeroDoctrasporto;
        private NullTypes.DatetimeNT _DataDoctrasporto;
        private NullTypes.DecimalNT _Imponibile;
        private NullTypes.DecimalNT _Iva;
        private NullTypes.DecimalNT _AltriOneri;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _CfFornitore;
        private NullTypes.StringNT _DescrizioneFornitore;
        private NullTypes.StringNT _TipoGiustificativo;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.BoolNT _IvaNonRecuperabile;
        private NullTypes.BoolNT _DomandaPagamentoAnnullata;
        private NullTypes.BoolNT _DomandaPagamentoApprovata;
        private NullTypes.BoolNT _Ammesso;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.IntNT _OperatoreApprovazione;
        private NullTypes.IntNT _IdFile;
        private NullTypes.IntNT _IdFileGiustificativo;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.BoolNT _IdFileModificatoIntegrazione;
        [NonSerialized]
        private ISpeseSostenuteProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISpeseSostenuteProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public SpeseSostenute()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_SPESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSpesa
        {
            get { return _IdSpesa; }
            set
            {
                if (IdSpesa != value)
                {
                    _IdSpesa = value;
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
        /// Corrisponde al campo:NETTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Netto
        {
            get { return _Netto; }
            set
            {
                if (Netto != value)
                {
                    _Netto = value;
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
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT Numero
        {
            get { return _Numero; }
            set
            {
                if (Numero != value)
                {
                    _Numero = value;
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
        /// Corrisponde al campo:NUMERO_DOCTRASPORTO
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT NumeroDoctrasporto
        {
            get { return _NumeroDoctrasporto; }
            set
            {
                if (NumeroDoctrasporto != value)
                {
                    _NumeroDoctrasporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_DOCTRASPORTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataDoctrasporto
        {
            get { return _DataDoctrasporto; }
            set
            {
                if (DataDoctrasporto != value)
                {
                    _DataDoctrasporto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPONIBILE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Imponibile
        {
            get { return _Imponibile; }
            set
            {
                if (Imponibile != value)
                {
                    _Imponibile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IVA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Iva
        {
            get { return _Iva; }
            set
            {
                if (Iva != value)
                {
                    _Iva = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ALTRI_ONERI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AltriOneri
        {
            get { return _AltriOneri; }
            set
            {
                if (AltriOneri != value)
                {
                    _AltriOneri = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                if (Descrizione != value)
                {
                    _Descrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_FORNITORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfFornitore
        {
            get { return _CfFornitore; }
            set
            {
                if (CfFornitore != value)
                {
                    _CfFornitore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_FORNITORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DescrizioneFornitore
        {
            get { return _DescrizioneFornitore; }
            set
            {
                if (DescrizioneFornitore != value)
                {
                    _DescrizioneFornitore = value;
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
        /// Corrisponde al campo:IVA_NON_RECUPERABILE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IvaNonRecuperabile
        {
            get { return _IvaNonRecuperabile; }
            set
            {
                if (IvaNonRecuperabile != value)
                {
                    _IvaNonRecuperabile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DOMANDA_PAGAMENTO_ANNULLATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT DomandaPagamentoAnnullata
        {
            get { return _DomandaPagamentoAnnullata; }
            set
            {
                if (DomandaPagamentoAnnullata != value)
                {
                    _DomandaPagamentoAnnullata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DOMANDA_PAGAMENTO_APPROVATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT DomandaPagamentoApprovata
        {
            get { return _DomandaPagamentoApprovata; }
            set
            {
                if (DomandaPagamentoApprovata != value)
                {
                    _DomandaPagamentoApprovata = value;
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
        /// Corrisponde al campo:OPERATORE_APPROVAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OperatoreApprovazione
        {
            get { return _OperatoreApprovazione; }
            set
            {
                if (OperatoreApprovazione != value)
                {
                    _OperatoreApprovazione = value;
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
        /// Corrisponde al campo:IN_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT InIntegrazione
        {
            get { return _InIntegrazione; }
            set
            {
                if (InIntegrazione != value)
                {
                    _InIntegrazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_MODIFICATO_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IdFileModificatoIntegrazione
        {
            get { return _IdFileModificatoIntegrazione; }
            set
            {
                if (IdFileModificatoIntegrazione != value)
                {
                    _IdFileModificatoIntegrazione = value;
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
    /// Summary description for SpeseSostenuteCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SpeseSostenuteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private SpeseSostenuteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((SpeseSostenute)info.GetValue(i.ToString(), typeof(SpeseSostenute)));
            }
        }

        //Costruttore
        public SpeseSostenuteCollection()
        {
            this.ItemType = typeof(SpeseSostenute);
        }

        //Costruttore con provider
        public SpeseSostenuteCollection(ISpeseSostenuteProvider providerObj)
        {
            this.ItemType = typeof(SpeseSostenute);
            this.Provider = providerObj;
        }

        //Get e Set
        public new SpeseSostenute this[int index]
        {
            get { return (SpeseSostenute)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new SpeseSostenuteCollection GetChanges()
        {
            return (SpeseSostenuteCollection)base.GetChanges();
        }

        [NonSerialized]
        private ISpeseSostenuteProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ISpeseSostenuteProvider Provider
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
        public int Add(SpeseSostenute SpeseSostenuteObj)
        {
            if (SpeseSostenuteObj.Provider == null) SpeseSostenuteObj.Provider = this.Provider;
            return base.Add(SpeseSostenuteObj);
        }

        //AddCollection
        public void AddCollection(SpeseSostenuteCollection SpeseSostenuteCollectionObj)
        {
            foreach (SpeseSostenute SpeseSostenuteObj in SpeseSostenuteCollectionObj)
                this.Add(SpeseSostenuteObj);
        }

        //Insert
        public void Insert(int index, SpeseSostenute SpeseSostenuteObj)
        {
            if (SpeseSostenuteObj.Provider == null) SpeseSostenuteObj.Provider = this.Provider;
            base.Insert(index, SpeseSostenuteObj);
        }

        //CollectionGetById
        public SpeseSostenute CollectionGetById(NullTypes.IntNT IdSpesaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdSpesa == IdSpesaValue))
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
        public SpeseSostenuteCollection SubSelect(NullTypes.IntNT IdSpesaEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis,
NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT EstremiEqualThis, NullTypes.DatetimeNT DataEqualThis,
NullTypes.DecimalNT ImportoEqualThis, NullTypes.DecimalNT NettoEqualThis, NullTypes.BoolNT AmmessoEqualThis,
NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.IntNT OperatoreApprovazioneEqualThis, NullTypes.IntNT IdFileEqualThis,
NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.BoolNT IdFileModificatoIntegrazioneEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = new SpeseSostenuteCollection();
            foreach (SpeseSostenute SpeseSostenuteItem in this)
            {
                if (((IdSpesaEqualThis == null) || ((SpeseSostenuteItem.IdSpesa != null) && (SpeseSostenuteItem.IdSpesa.Value == IdSpesaEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((SpeseSostenuteItem.IdDomandaPagamento != null) && (SpeseSostenuteItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((SpeseSostenuteItem.IdGiustificativo != null) && (SpeseSostenuteItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) &&
((CodTipoEqualThis == null) || ((SpeseSostenuteItem.CodTipo != null) && (SpeseSostenuteItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((EstremiEqualThis == null) || ((SpeseSostenuteItem.Estremi != null) && (SpeseSostenuteItem.Estremi.Value == EstremiEqualThis.Value))) && ((DataEqualThis == null) || ((SpeseSostenuteItem.Data != null) && (SpeseSostenuteItem.Data.Value == DataEqualThis.Value))) &&
((ImportoEqualThis == null) || ((SpeseSostenuteItem.Importo != null) && (SpeseSostenuteItem.Importo.Value == ImportoEqualThis.Value))) && ((NettoEqualThis == null) || ((SpeseSostenuteItem.Netto != null) && (SpeseSostenuteItem.Netto.Value == NettoEqualThis.Value))) && ((AmmessoEqualThis == null) || ((SpeseSostenuteItem.Ammesso != null) && (SpeseSostenuteItem.Ammesso.Value == AmmessoEqualThis.Value))) &&
((DataApprovazioneEqualThis == null) || ((SpeseSostenuteItem.DataApprovazione != null) && (SpeseSostenuteItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((OperatoreApprovazioneEqualThis == null) || ((SpeseSostenuteItem.OperatoreApprovazione != null) && (SpeseSostenuteItem.OperatoreApprovazione.Value == OperatoreApprovazioneEqualThis.Value))) && ((IdFileEqualThis == null) || ((SpeseSostenuteItem.IdFile != null) && (SpeseSostenuteItem.IdFile.Value == IdFileEqualThis.Value))) &&
((InIntegrazioneEqualThis == null) || ((SpeseSostenuteItem.InIntegrazione != null) && (SpeseSostenuteItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((IdFileModificatoIntegrazioneEqualThis == null) || ((SpeseSostenuteItem.IdFileModificatoIntegrazione != null) && (SpeseSostenuteItem.IdFileModificatoIntegrazione.Value == IdFileModificatoIntegrazioneEqualThis.Value))))
                {
                    SpeseSostenuteCollectionTemp.Add(SpeseSostenuteItem);
                }
            }
            return SpeseSostenuteCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public SpeseSostenuteCollection FiltraPerDatiGiustificativo(NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataGiustificativoEqualThis, NullTypes.StringNT CodTipoGiustificativoEqualThis,
NullTypes.StringNT DescrizioneLike, NullTypes.BoolNT InIntegrazioneEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = new SpeseSostenuteCollection();
            foreach (SpeseSostenute SpeseSostenuteItem in this)
            {
                if (((NumeroEqualThis == null) || ((SpeseSostenuteItem.Numero != null) && (SpeseSostenuteItem.Numero.Value == NumeroEqualThis.Value))) && ((DataGiustificativoEqualThis == null) || ((SpeseSostenuteItem.DataGiustificativo != null) && (SpeseSostenuteItem.DataGiustificativo.Value == DataGiustificativoEqualThis.Value))) && ((CodTipoGiustificativoEqualThis == null) || ((SpeseSostenuteItem.CodTipoGiustificativo != null) && (SpeseSostenuteItem.CodTipoGiustificativo.Value == CodTipoGiustificativoEqualThis.Value))) &&
((DescrizioneLike == null) || ((SpeseSostenuteItem.Descrizione != null) && (SpeseSostenuteItem.Descrizione.Like(DescrizioneLike.Value)))) && ((InIntegrazioneEqualThis == null) || ((SpeseSostenuteItem.InIntegrazione != null) && (SpeseSostenuteItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))))
                {
                    SpeseSostenuteCollectionTemp.Add(SpeseSostenuteItem);
                }
            }
            return SpeseSostenuteCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for SpeseSostenuteDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class SpeseSostenuteDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SpeseSostenute SpeseSostenuteObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdSpesa", SpeseSostenuteObj.IdSpesa);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativo", SpeseSostenuteObj.IdGiustificativo);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", SpeseSostenuteObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "Estremi", SpeseSostenuteObj.Estremi);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", SpeseSostenuteObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", SpeseSostenuteObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "Netto", SpeseSostenuteObj.Netto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", SpeseSostenuteObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "Ammesso", SpeseSostenuteObj.Ammesso);
            DbProvider.SetCmdParam(cmd, firstChar + "DataApprovazione", SpeseSostenuteObj.DataApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreApprovazione", SpeseSostenuteObj.OperatoreApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFile", SpeseSostenuteObj.IdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", SpeseSostenuteObj.InIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFileModificatoIntegrazione", SpeseSostenuteObj.IdFileModificatoIntegrazione);
        }
        //Insert
        private static int Insert(DbProvider db, SpeseSostenute SpeseSostenuteObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZSpeseSostenuteInsert", new string[] {"IdGiustificativo", "CodTipo", 
"Estremi", "Data", "Importo", 
"Netto", 




"IdDomandaPagamento", 
"Ammesso", "DataApprovazione", 
"OperatoreApprovazione", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "string", 
"string", "DateTime", "decimal", 
"decimal", 




"int", 
"bool", "DateTime", 
"int", "int", 
"bool", "bool"}, "");
                CompileIUCmd(false, insertCmd, SpeseSostenuteObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    SpeseSostenuteObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
                    SpeseSostenuteObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                    SpeseSostenuteObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                }
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, SpeseSostenute SpeseSostenuteObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSpeseSostenuteUpdate", new string[] {"IdSpesa", "IdGiustificativo", "CodTipo", 
"Estremi", "Data", "Importo", 
"Netto", 




"IdDomandaPagamento", 
"Ammesso", "DataApprovazione", 
"OperatoreApprovazione", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "int", "string", 
"string", "DateTime", "decimal", 
"decimal", 




"int", 
"bool", "DateTime", 
"int", "int", 
"bool", "bool"}, "");
                CompileIUCmd(true, updateCmd, SpeseSostenuteObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, SpeseSostenute SpeseSostenuteObj)
        {
            switch (SpeseSostenuteObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, SpeseSostenuteObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, SpeseSostenuteObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, SpeseSostenuteObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, SpeseSostenuteCollection SpeseSostenuteCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZSpeseSostenuteUpdate", new string[] {"IdSpesa", "IdGiustificativo", "CodTipo", 
"Estremi", "Data", "Importo", 
"Netto", 




"IdDomandaPagamento", 
"Ammesso", "DataApprovazione", 
"OperatoreApprovazione", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "int", "string", 
"string", "DateTime", "decimal", 
"decimal", 




"int", 
"bool", "DateTime", 
"int", "int", 
"bool", "bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZSpeseSostenuteInsert", new string[] {"IdGiustificativo", "CodTipo", 
"Estremi", "Data", "Importo", 
"Netto", 




"IdDomandaPagamento", 
"Ammesso", "DataApprovazione", 
"OperatoreApprovazione", "IdFile", 
"InIntegrazione", "IdFileModificatoIntegrazione"}, new string[] {"int", "string", 
"string", "DateTime", "decimal", 
"decimal", 




"int", 
"bool", "DateTime", 
"int", "int", 
"bool", "bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteDelete", new string[] { "IdSpesa" }, new string[] { "int" }, "");
                for (int i = 0; i < SpeseSostenuteCollectionObj.Count; i++)
                {
                    switch (SpeseSostenuteCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, SpeseSostenuteCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    SpeseSostenuteCollectionObj[i].IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
                                    SpeseSostenuteCollectionObj[i].Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                                    SpeseSostenuteCollectionObj[i].InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, SpeseSostenuteCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (SpeseSostenuteCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSpesa", (SiarLibrary.NullTypes.IntNT)SpeseSostenuteCollectionObj[i].IdSpesa);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < SpeseSostenuteCollectionObj.Count; i++)
                {
                    if ((SpeseSostenuteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpeseSostenuteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SpeseSostenuteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        SpeseSostenuteCollectionObj[i].IsDirty = false;
                        SpeseSostenuteCollectionObj[i].IsPersistent = true;
                    }
                    if ((SpeseSostenuteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        SpeseSostenuteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SpeseSostenuteCollectionObj[i].IsDirty = false;
                        SpeseSostenuteCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, SpeseSostenute SpeseSostenuteObj)
        {
            int returnValue = 0;
            if (SpeseSostenuteObj.IsPersistent)
            {
                returnValue = Delete(db, SpeseSostenuteObj.IdSpesa);
            }
            SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            SpeseSostenuteObj.IsDirty = false;
            SpeseSostenuteObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdSpesaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteDelete", new string[] { "IdSpesa" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSpesa", (SiarLibrary.NullTypes.IntNT)IdSpesaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, SpeseSostenuteCollection SpeseSostenuteCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteDelete", new string[] { "IdSpesa" }, new string[] { "int" }, "");
                for (int i = 0; i < SpeseSostenuteCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSpesa", SpeseSostenuteCollectionObj[i].IdSpesa);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < SpeseSostenuteCollectionObj.Count; i++)
                {
                    if ((SpeseSostenuteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpeseSostenuteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        SpeseSostenuteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        SpeseSostenuteCollectionObj[i].IsDirty = false;
                        SpeseSostenuteCollectionObj[i].IsPersistent = false;
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
        public static SpeseSostenute GetById(DbProvider db, int IdSpesaValue)
        {
            SpeseSostenute SpeseSostenuteObj = null;
            IDbCommand readCmd = db.InitCmd("ZSpeseSostenuteGetById", new string[] { "IdSpesa" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdSpesa", (SiarLibrary.NullTypes.IntNT)IdSpesaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                SpeseSostenuteObj = GetFromDatareader(db);
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
            }
            db.Close();
            return SpeseSostenuteObj;
        }

        //getFromDatareader
        public static SpeseSostenute GetFromDatareader(DbProvider db)
        {
            SpeseSostenute SpeseSostenuteObj = new SpeseSostenute();
            SpeseSostenuteObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
            SpeseSostenuteObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
            SpeseSostenuteObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            SpeseSostenuteObj.Estremi = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESTREMI"]);
            SpeseSostenuteObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            SpeseSostenuteObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            SpeseSostenuteObj.Netto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["NETTO"]);
            SpeseSostenuteObj.TipoPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_PAGAMENTO"]);
            SpeseSostenuteObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            SpeseSostenuteObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            SpeseSostenuteObj.CodTipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_GIUSTIFICATIVO"]);
            SpeseSostenuteObj.DataGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GIUSTIFICATIVO"]);
            SpeseSostenuteObj.NumeroDoctrasporto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO"]);
            SpeseSostenuteObj.DataDoctrasporto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO"]);
            SpeseSostenuteObj.Imponibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE"]);
            SpeseSostenuteObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
            SpeseSostenuteObj.AltriOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI"]);
            SpeseSostenuteObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            SpeseSostenuteObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
            SpeseSostenuteObj.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
            SpeseSostenuteObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
            SpeseSostenuteObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            SpeseSostenuteObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
            SpeseSostenuteObj.DomandaPagamentoAnnullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA_PAGAMENTO_ANNULLATA"]);
            SpeseSostenuteObj.DomandaPagamentoApprovata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA_PAGAMENTO_APPROVATA"]);
            SpeseSostenuteObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
            SpeseSostenuteObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            SpeseSostenuteObj.OperatoreApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_APPROVAZIONE"]);
            SpeseSostenuteObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            SpeseSostenuteObj.IdFileGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_GIUSTIFICATIVO"]);
            SpeseSostenuteObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            SpeseSostenuteObj.IdFileModificatoIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ID_FILE_MODIFICATO_INTEGRAZIONE"]);
            SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            SpeseSostenuteObj.IsDirty = false;
            SpeseSostenuteObj.IsPersistent = true;
            return SpeseSostenuteObj;
        }

        //Find Select

        public static SpeseSostenuteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis,
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT EstremiEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DecimalNT NettoEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreApprovazioneEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis,
SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.BoolNT IdFileModificatoIntegrazioneEqualThis)
        {

            SpeseSostenuteCollection SpeseSostenuteCollectionObj = new SpeseSostenuteCollection();

            IDbCommand findCmd = db.InitCmd("Zspesesostenutefindselect", new string[] {"IdSpesaequalthis", "IdDomandaPagamentoequalthis", "IdGiustificativoequalthis", 
"CodTipoequalthis", "Estremiequalthis", "Dataequalthis", 
"Importoequalthis", "Nettoequalthis", "Ammessoequalthis", 
"DataApprovazioneequalthis", "OperatoreApprovazioneequalthis", "IdFileequalthis", 
"InIntegrazioneequalthis", "IdFileModificatoIntegrazioneequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "DateTime", 
"decimal", "decimal", "bool", 
"DateTime", "int", "int", 
"bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Estremiequalthis", EstremiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Nettoequalthis", NettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreApprovazioneequalthis", OperatoreApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileModificatoIntegrazioneequalthis", IdFileModificatoIntegrazioneEqualThis);
            SpeseSostenute SpeseSostenuteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SpeseSostenuteObj = GetFromDatareader(db);
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
                SpeseSostenuteCollectionObj.Add(SpeseSostenuteObj);
            }
            db.Close();
            return SpeseSostenuteCollectionObj;
        }

        //Find Find

        public static SpeseSostenuteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
        {

            SpeseSostenuteCollection SpeseSostenuteCollectionObj = new SpeseSostenuteCollection();

            IDbCommand findCmd = db.InitCmd("Zspesesostenutefindfind", new string[] { "IdDomandaPagamentoequalthis", "IdGiustificativoequalthis", "IdProgettoequalthis" }, new string[] { "int", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            SpeseSostenute SpeseSostenuteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SpeseSostenuteObj = GetFromDatareader(db);
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
                SpeseSostenuteCollectionObj.Add(SpeseSostenuteObj);
            }
            db.Close();
            return SpeseSostenuteCollectionObj;
        }

        //Find GetSpeseModificateIntegrazione

        public static SpeseSostenuteCollection GetSpeseModificateIntegrazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.BoolNT IdFileModificatoIntegrazioneEqualThis)
        {

            SpeseSostenuteCollection SpeseSostenuteCollectionObj = new SpeseSostenuteCollection();

            IDbCommand findCmd = db.InitCmd("Zspesesostenutefindgetspesemodificateintegrazione", new string[] {"IdDomandaPagamentoequalthis", "IdGiustificativoequalthis", "IdProgettoequalthis", 
"InIntegrazioneequalthis", "IdFileModificatoIntegrazioneequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileModificatoIntegrazioneequalthis", IdFileModificatoIntegrazioneEqualThis);
            SpeseSostenute SpeseSostenuteObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                SpeseSostenuteObj = GetFromDatareader(db);
                SpeseSostenuteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                SpeseSostenuteObj.IsDirty = false;
                SpeseSostenuteObj.IsPersistent = true;
                SpeseSostenuteCollectionObj.Add(SpeseSostenuteObj);
            }
            db.Close();
            return SpeseSostenuteCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for SpeseSostenuteCollectionProvider:ISpeseSostenuteProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class SpeseSostenuteCollectionProvider : ISpeseSostenuteProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di SpeseSostenute
        protected SpeseSostenuteCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public SpeseSostenuteCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new SpeseSostenuteCollection(this);
        }

        //Costruttore 2: popola la collection
        public SpeseSostenuteCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IddomandapagamentoEqualThis, IdgiustificativoEqualThis, IdprogettoEqualThis);
        }

        //Costruttore3: ha in input spesesostenuteCollectionObj - non popola la collection
        public SpeseSostenuteCollectionProvider(SpeseSostenuteCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public SpeseSostenuteCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new SpeseSostenuteCollection(this);
        }

        //Get e Set
        public SpeseSostenuteCollection CollectionObj
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
        public int SaveCollection(SpeseSostenuteCollection collectionObj)
        {
            return SpeseSostenuteDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(SpeseSostenute spesesostenuteObj)
        {
            return SpeseSostenuteDAL.Save(_dbProviderObj, spesesostenuteObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(SpeseSostenuteCollection collectionObj)
        {
            return SpeseSostenuteDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(SpeseSostenute spesesostenuteObj)
        {
            return SpeseSostenuteDAL.Delete(_dbProviderObj, spesesostenuteObj);
        }

        //getById
        public SpeseSostenute GetById(IntNT IdSpesaValue)
        {
            SpeseSostenute SpeseSostenuteTemp = SpeseSostenuteDAL.GetById(_dbProviderObj, IdSpesaValue);
            if (SpeseSostenuteTemp != null) SpeseSostenuteTemp.Provider = this;
            return SpeseSostenuteTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public SpeseSostenuteCollection Select(IntNT IdspesaEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis,
StringNT CodtipoEqualThis, StringNT EstremiEqualThis, DatetimeNT DataEqualThis,
DecimalNT ImportoEqualThis, DecimalNT NettoEqualThis, BoolNT AmmessoEqualThis,
DatetimeNT DataapprovazioneEqualThis, IntNT OperatoreapprovazioneEqualThis, IntNT IdfileEqualThis,
BoolNT InintegrazioneEqualThis, BoolNT IdfilemodificatointegrazioneEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = SpeseSostenuteDAL.Select(_dbProviderObj, IdspesaEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis,
CodtipoEqualThis, EstremiEqualThis, DataEqualThis,
ImportoEqualThis, NettoEqualThis, AmmessoEqualThis,
DataapprovazioneEqualThis, OperatoreapprovazioneEqualThis, IdfileEqualThis,
InintegrazioneEqualThis, IdfilemodificatointegrazioneEqualThis);
            SpeseSostenuteCollectionTemp.Provider = this;
            return SpeseSostenuteCollectionTemp;
        }

        //Find: popola la collection
        public SpeseSostenuteCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdprogettoEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = SpeseSostenuteDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdgiustificativoEqualThis, IdprogettoEqualThis);
            SpeseSostenuteCollectionTemp.Provider = this;
            return SpeseSostenuteCollectionTemp;
        }

        //GetSpeseModificateIntegrazione: popola la collection
        public SpeseSostenuteCollection GetSpeseModificateIntegrazione(IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdprogettoEqualThis,
BoolNT InintegrazioneEqualThis, BoolNT IdfilemodificatointegrazioneEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = SpeseSostenuteDAL.GetSpeseModificateIntegrazione(_dbProviderObj, IddomandapagamentoEqualThis, IdgiustificativoEqualThis, IdprogettoEqualThis,
InintegrazioneEqualThis, IdfilemodificatointegrazioneEqualThis);
            SpeseSostenuteCollectionTemp.Provider = this;
            return SpeseSostenuteCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SPESE_SOSTENUTE>
  <ViewName>vSPESE_SOSTENUTE</ViewName>
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
    <Find OrderBy="ORDER BY ID_GIUSTIFICATIVO, ID_SPESA">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
    <GetSpeseModificateIntegrazione OrderBy="ORDER BY ID_GIUSTIFICATIVO, ID_SPESA">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <IN_INTEGRAZIONE>Equal</IN_INTEGRAZIONE>
      <ID_FILE_MODIFICATO_INTEGRAZIONE>Equal</ID_FILE_MODIFICATO_INTEGRAZIONE>
    </GetSpeseModificateIntegrazione>
  </Finds>
  <Filters>
    <FiltraPerDatiGiustificativo>
      <NUMERO>Equal</NUMERO>
      <DATA_GIUSTIFICATIVO>Equal</DATA_GIUSTIFICATIVO>
      <COD_TIPO_GIUSTIFICATIVO>Equal</COD_TIPO_GIUSTIFICATIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <IN_INTEGRAZIONE>Equal</IN_INTEGRAZIONE>
    </FiltraPerDatiGiustificativo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</SPESE_SOSTENUTE>
*/
