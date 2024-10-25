using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DomandaDiPagamento
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDomandaDiPagamentoProvider
    {
        int Save(DomandaDiPagamento DomandaDiPagamentoObj);
        int SaveCollection(DomandaDiPagamentoCollection collectionObj);
        int Delete(DomandaDiPagamento DomandaDiPagamentoObj);
        int DeleteCollection(DomandaDiPagamentoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DomandaDiPagamento
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DomandaDiPagamento : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _CodFase;
        private NullTypes.StringNT _Fase;
        private NullTypes.IntNT _Ordine;
        private NullTypes.IntNT _IdFidejussione;
        private NullTypes.StringNT _Operatore;
        private NullTypes.StringNT _CfOperatore;
        private NullTypes.StringNT _SegnaturaAllegati;
        private NullTypes.DatetimeNT _DataCertificazioneAntimafia;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.StringNT _SegnaturaApprovazione;
        private NullTypes.StringNT _CfIstruttore;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.StringNT _SegnaturaSecondaApprovazione;
        private NullTypes.BoolNT _Annullata;
        private NullTypes.StringNT _SegnaturaAnnullamento;
        private NullTypes.StringNT _CfOperatoreAnnullamento;
        private NullTypes.DatetimeNT _DataAnnullamento;
        private NullTypes.BoolNT _ValiditaVersioneAdc;
        private NullTypes.IntNT _IdVariazioneAccertata;
        private NullTypes.BoolNT _PredispostaAControllo;
        private NullTypes.StringNT _VisitaInsituEsito;
        private NullTypes.StringNT _VisitaInsituNote;
        private NullTypes.StringNT _ControlloInlocoEsito;
        private NullTypes.StringNT _ControlloInlocoNote;
        private NullTypes.StringNT _ValutazioneIstruttore;
        private NullTypes.StringNT _VerificaPagamentiEsito;
        private NullTypes.StringNT _VerificaPagamentiMessaggio;
        private NullTypes.DatetimeNT _VerificaPagamentiData;
        private NullTypes.DatetimeNT _DataPredisposizioneAControllo;
        private NullTypes.StringNT _NominativoOperatoreAnnullamento;
        private NullTypes.StringNT _Istruttore;
        private NullTypes.BoolNT _FirmaPredisposta;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.BoolNT _FirmaPredispostaRup;
        [NonSerialized]
        private IDomandaDiPagamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaDiPagamentoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DomandaDiPagamento()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:COD_ENTE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnte
        {
            get { return _CodEnte; }
            set
            {
                if (CodEnte != value)
                {
                    _CodEnte = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA
        /// Tipo sul db:VARCHAR(100)
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
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(100)
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
        /// Corrisponde al campo:FASE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Fase
        {
            get { return _Fase; }
            set
            {
                if (Fase != value)
                {
                    _Fase = value;
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
        /// Corrisponde al campo:ID_FIDEJUSSIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFidejussione
        {
            get { return _IdFidejussione; }
            set
            {
                if (IdFidejussione != value)
                {
                    _IdFidejussione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Operatore
        {
            get { return _Operatore; }
            set
            {
                if (Operatore != value)
                {
                    _Operatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_OPERATORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfOperatore
        {
            get { return _CfOperatore; }
            set
            {
                if (CfOperatore != value)
                {
                    _CfOperatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_ALLEGATI
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaAllegati
        {
            get { return _SegnaturaAllegati; }
            set
            {
                if (SegnaturaAllegati != value)
                {
                    _SegnaturaAllegati = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CERTIFICAZIONE_ANTIMAFIA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCertificazioneAntimafia
        {
            get { return _DataCertificazioneAntimafia; }
            set
            {
                if (DataCertificazioneAntimafia != value)
                {
                    _DataCertificazioneAntimafia = value;
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
        /// Corrisponde al campo:SEGNATURA_APPROVAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaApprovazione
        {
            get { return _SegnaturaApprovazione; }
            set
            {
                if (SegnaturaApprovazione != value)
                {
                    _SegnaturaApprovazione = value;
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
        /// Corrisponde al campo:SEGNATURA_SECONDA_APPROVAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaSecondaApprovazione
        {
            get { return _SegnaturaSecondaApprovazione; }
            set
            {
                if (SegnaturaSecondaApprovazione != value)
                {
                    _SegnaturaSecondaApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ANNULLATA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Annullata
        {
            get { return _Annullata; }
            set
            {
                if (Annullata != value)
                {
                    _Annullata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaAnnullamento
        {
            get { return _SegnaturaAnnullamento; }
            set
            {
                if (SegnaturaAnnullamento != value)
                {
                    _SegnaturaAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_OPERATORE_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfOperatoreAnnullamento
        {
            get { return _CfOperatoreAnnullamento; }
            set
            {
                if (CfOperatoreAnnullamento != value)
                {
                    _CfOperatoreAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ANNULLAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAnnullamento
        {
            get { return _DataAnnullamento; }
            set
            {
                if (DataAnnullamento != value)
                {
                    _DataAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALIDITA_VERSIONE_ADC
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT ValiditaVersioneAdc
        {
            get { return _ValiditaVersioneAdc; }
            set
            {
                if (ValiditaVersioneAdc != value)
                {
                    _ValiditaVersioneAdc = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VARIAZIONE_ACCERTATA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVariazioneAccertata
        {
            get { return _IdVariazioneAccertata; }
            set
            {
                if (IdVariazioneAccertata != value)
                {
                    _IdVariazioneAccertata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PREDISPOSTA_A_CONTROLLO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT PredispostaAControllo
        {
            get { return _PredispostaAControllo; }
            set
            {
                if (PredispostaAControllo != value)
                {
                    _PredispostaAControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VISITA_INSITU_ESITO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT VisitaInsituEsito
        {
            get { return _VisitaInsituEsito; }
            set
            {
                if (VisitaInsituEsito != value)
                {
                    _VisitaInsituEsito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VISITA_INSITU_NOTE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT VisitaInsituNote
        {
            get { return _VisitaInsituNote; }
            set
            {
                if (VisitaInsituNote != value)
                {
                    _VisitaInsituNote = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTROLLO_INLOCO_ESITO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT ControlloInlocoEsito
        {
            get { return _ControlloInlocoEsito; }
            set
            {
                if (ControlloInlocoEsito != value)
                {
                    _ControlloInlocoEsito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTROLLO_INLOCO_NOTE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ControlloInlocoNote
        {
            get { return _ControlloInlocoNote; }
            set
            {
                if (ControlloInlocoNote != value)
                {
                    _ControlloInlocoNote = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALUTAZIONE_ISTRUTTORE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ValutazioneIstruttore
        {
            get { return _ValutazioneIstruttore; }
            set
            {
                if (ValutazioneIstruttore != value)
                {
                    _ValutazioneIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VERIFICA_PAGAMENTI_ESITO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT VerificaPagamentiEsito
        {
            get { return _VerificaPagamentiEsito; }
            set
            {
                if (VerificaPagamentiEsito != value)
                {
                    _VerificaPagamentiEsito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VERIFICA_PAGAMENTI_MESSAGGIO
        /// Tipo sul db:VARCHAR(3000)
        /// </summary>
        public NullTypes.StringNT VerificaPagamentiMessaggio
        {
            get { return _VerificaPagamentiMessaggio; }
            set
            {
                if (VerificaPagamentiMessaggio != value)
                {
                    _VerificaPagamentiMessaggio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VERIFICA_PAGAMENTI_DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT VerificaPagamentiData
        {
            get { return _VerificaPagamentiData; }
            set
            {
                if (VerificaPagamentiData != value)
                {
                    _VerificaPagamentiData = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PREDISPOSIZIONE_A_CONTROLLO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPredisposizioneAControllo
        {
            get { return _DataPredisposizioneAControllo; }
            set
            {
                if (DataPredisposizioneAControllo != value)
                {
                    _DataPredisposizioneAControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_OPERATORE_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoOperatoreAnnullamento
        {
            get { return _NominativoOperatoreAnnullamento; }
            set
            {
                if (NominativoOperatoreAnnullamento != value)
                {
                    _NominativoOperatoreAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUTTORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Istruttore
        {
            get { return _Istruttore; }
            set
            {
                if (Istruttore != value)
                {
                    _Istruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FIRMA_PREDISPOSTA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT FirmaPredisposta
        {
            get { return _FirmaPredisposta; }
            set
            {
                if (FirmaPredisposta != value)
                {
                    _FirmaPredisposta = value;
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
        /// Corrisponde al campo:FIRMA_PREDISPOSTA_RUP
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FirmaPredispostaRup
        {
            get { return _FirmaPredispostaRup; }
            set
            {
                if (FirmaPredispostaRup != value)
                {
                    _FirmaPredispostaRup = value;
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
    /// Summary description for DomandaDiPagamentoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaDiPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DomandaDiPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DomandaDiPagamento)info.GetValue(i.ToString(), typeof(DomandaDiPagamento)));
            }
        }

        //Costruttore
        public DomandaDiPagamentoCollection()
        {
            this.ItemType = typeof(DomandaDiPagamento);
        }

        //Costruttore con provider
        public DomandaDiPagamentoCollection(IDomandaDiPagamentoProvider providerObj)
        {
            this.ItemType = typeof(DomandaDiPagamento);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DomandaDiPagamento this[int index]
        {
            get { return (DomandaDiPagamento)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DomandaDiPagamentoCollection GetChanges()
        {
            return (DomandaDiPagamentoCollection)base.GetChanges();
        }

        [NonSerialized]
        private IDomandaDiPagamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaDiPagamentoProvider Provider
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
        public int Add(DomandaDiPagamento DomandaDiPagamentoObj)
        {
            if (DomandaDiPagamentoObj.Provider == null) DomandaDiPagamentoObj.Provider = this.Provider;
            return base.Add(DomandaDiPagamentoObj);
        }

        //AddCollection
        public void AddCollection(DomandaDiPagamentoCollection DomandaDiPagamentoCollectionObj)
        {
            foreach (DomandaDiPagamento DomandaDiPagamentoObj in DomandaDiPagamentoCollectionObj)
                this.Add(DomandaDiPagamentoObj);
        }

        //Insert
        public void Insert(int index, DomandaDiPagamento DomandaDiPagamentoObj)
        {
            if (DomandaDiPagamentoObj.Provider == null) DomandaDiPagamentoObj.Provider = this.Provider;
            base.Insert(index, DomandaDiPagamentoObj);
        }

        //CollectionGetById
        public DomandaDiPagamento CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue))
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
        public DomandaDiPagamentoCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT SegnaturaAllegatiEqualThis,
NullTypes.IntNT IdFidejussioneEqualThis, NullTypes.DatetimeNT DataCertificazioneAntimafiaEqualThis, NullTypes.BoolNT ApprovataEqualThis,
NullTypes.StringNT SegnaturaApprovazioneEqualThis, NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis, NullTypes.StringNT CfIstruttoreEqualThis,
NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.BoolNT AnnullataEqualThis, NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.BoolNT ValiditaVersioneAdcEqualThis,
NullTypes.IntNT IdVariazioneAccertataEqualThis, NullTypes.BoolNT PredispostaAControlloEqualThis, NullTypes.DatetimeNT DataPredisposizioneAControlloEqualThis,
NullTypes.StringNT VisitaInsituEsitoEqualThis, NullTypes.StringNT ControlloInlocoEsitoEqualThis, NullTypes.StringNT VerificaPagamentiEsitoEqualThis,
NullTypes.StringNT VerificaPagamentiMessaggioEqualThis, NullTypes.DatetimeNT VerificaPagamentiDataEqualThis, NullTypes.BoolNT FirmaPredispostaEqualThis,
NullTypes.BoolNT FirmaPredispostaRupEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis)
        {
            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionTemp = new DomandaDiPagamentoCollection();
            foreach (DomandaDiPagamento DomandaDiPagamentoItem in this)
            {
                if (((IdDomandaPagamentoEqualThis == null) || ((DomandaDiPagamentoItem.IdDomandaPagamento != null) && (DomandaDiPagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((DomandaDiPagamentoItem.CodTipo != null) && (DomandaDiPagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaDiPagamentoItem.IdProgetto != null) && (DomandaDiPagamentoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((DomandaDiPagamentoItem.DataInserimento != null) && (DomandaDiPagamentoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((DomandaDiPagamentoItem.CfOperatore != null) && (DomandaDiPagamentoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((DataModificaEqualThis == null) || ((DomandaDiPagamentoItem.DataModifica != null) && (DomandaDiPagamentoItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CodEnteEqualThis == null) || ((DomandaDiPagamentoItem.CodEnte != null) && (DomandaDiPagamentoItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((DomandaDiPagamentoItem.Segnatura != null) && (DomandaDiPagamentoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaAllegatiEqualThis == null) || ((DomandaDiPagamentoItem.SegnaturaAllegati != null) && (DomandaDiPagamentoItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) &&
((IdFidejussioneEqualThis == null) || ((DomandaDiPagamentoItem.IdFidejussione != null) && (DomandaDiPagamentoItem.IdFidejussione.Value == IdFidejussioneEqualThis.Value))) && ((DataCertificazioneAntimafiaEqualThis == null) || ((DomandaDiPagamentoItem.DataCertificazioneAntimafia != null) && (DomandaDiPagamentoItem.DataCertificazioneAntimafia.Value == DataCertificazioneAntimafiaEqualThis.Value))) && ((ApprovataEqualThis == null) || ((DomandaDiPagamentoItem.Approvata != null) && (DomandaDiPagamentoItem.Approvata.Value == ApprovataEqualThis.Value))) &&
((SegnaturaApprovazioneEqualThis == null) || ((DomandaDiPagamentoItem.SegnaturaApprovazione != null) && (DomandaDiPagamentoItem.SegnaturaApprovazione.Value == SegnaturaApprovazioneEqualThis.Value))) && ((SegnaturaSecondaApprovazioneEqualThis == null) || ((DomandaDiPagamentoItem.SegnaturaSecondaApprovazione != null) && (DomandaDiPagamentoItem.SegnaturaSecondaApprovazione.Value == SegnaturaSecondaApprovazioneEqualThis.Value))) && ((CfIstruttoreEqualThis == null) || ((DomandaDiPagamentoItem.CfIstruttore != null) && (DomandaDiPagamentoItem.CfIstruttore.Value == CfIstruttoreEqualThis.Value))) &&
((DataApprovazioneEqualThis == null) || ((DomandaDiPagamentoItem.DataApprovazione != null) && (DomandaDiPagamentoItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((AnnullataEqualThis == null) || ((DomandaDiPagamentoItem.Annullata != null) && (DomandaDiPagamentoItem.Annullata.Value == AnnullataEqualThis.Value))) && ((SegnaturaAnnullamentoEqualThis == null) || ((DomandaDiPagamentoItem.SegnaturaAnnullamento != null) && (DomandaDiPagamentoItem.SegnaturaAnnullamento.Value == SegnaturaAnnullamentoEqualThis.Value))) &&
((CfOperatoreAnnullamentoEqualThis == null) || ((DomandaDiPagamentoItem.CfOperatoreAnnullamento != null) && (DomandaDiPagamentoItem.CfOperatoreAnnullamento.Value == CfOperatoreAnnullamentoEqualThis.Value))) && ((DataAnnullamentoEqualThis == null) || ((DomandaDiPagamentoItem.DataAnnullamento != null) && (DomandaDiPagamentoItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((ValiditaVersioneAdcEqualThis == null) || ((DomandaDiPagamentoItem.ValiditaVersioneAdc != null) && (DomandaDiPagamentoItem.ValiditaVersioneAdc.Value == ValiditaVersioneAdcEqualThis.Value))) &&
((IdVariazioneAccertataEqualThis == null) || ((DomandaDiPagamentoItem.IdVariazioneAccertata != null) && (DomandaDiPagamentoItem.IdVariazioneAccertata.Value == IdVariazioneAccertataEqualThis.Value))) && ((PredispostaAControlloEqualThis == null) || ((DomandaDiPagamentoItem.PredispostaAControllo != null) && (DomandaDiPagamentoItem.PredispostaAControllo.Value == PredispostaAControlloEqualThis.Value))) && ((DataPredisposizioneAControlloEqualThis == null) || ((DomandaDiPagamentoItem.DataPredisposizioneAControllo != null) && (DomandaDiPagamentoItem.DataPredisposizioneAControllo.Value == DataPredisposizioneAControlloEqualThis.Value))) &&
((VisitaInsituEsitoEqualThis == null) || ((DomandaDiPagamentoItem.VisitaInsituEsito != null) && (DomandaDiPagamentoItem.VisitaInsituEsito.Value == VisitaInsituEsitoEqualThis.Value))) && ((ControlloInlocoEsitoEqualThis == null) || ((DomandaDiPagamentoItem.ControlloInlocoEsito != null) && (DomandaDiPagamentoItem.ControlloInlocoEsito.Value == ControlloInlocoEsitoEqualThis.Value))) && ((VerificaPagamentiEsitoEqualThis == null) || ((DomandaDiPagamentoItem.VerificaPagamentiEsito != null) && (DomandaDiPagamentoItem.VerificaPagamentiEsito.Value == VerificaPagamentiEsitoEqualThis.Value))) &&
((VerificaPagamentiMessaggioEqualThis == null) || ((DomandaDiPagamentoItem.VerificaPagamentiMessaggio != null) && (DomandaDiPagamentoItem.VerificaPagamentiMessaggio.Value == VerificaPagamentiMessaggioEqualThis.Value))) && ((VerificaPagamentiDataEqualThis == null) || ((DomandaDiPagamentoItem.VerificaPagamentiData != null) && (DomandaDiPagamentoItem.VerificaPagamentiData.Value == VerificaPagamentiDataEqualThis.Value))) && ((FirmaPredispostaEqualThis == null) || ((DomandaDiPagamentoItem.FirmaPredisposta != null) && (DomandaDiPagamentoItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))) &&
((FirmaPredispostaRupEqualThis == null) || ((DomandaDiPagamentoItem.FirmaPredispostaRup != null) && (DomandaDiPagamentoItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((DomandaDiPagamentoItem.InIntegrazione != null) && (DomandaDiPagamentoItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))))
                {
                    DomandaDiPagamentoCollectionTemp.Add(DomandaDiPagamentoItem);
                }
            }
            return DomandaDiPagamentoCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public DomandaDiPagamentoCollection FiltroApprovata(NullTypes.BoolNT ApprovataEqualThis)
        {
            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionTemp = new DomandaDiPagamentoCollection();
            foreach (DomandaDiPagamento DomandaDiPagamentoItem in this)
            {
                if (((ApprovataEqualThis == null) || ((DomandaDiPagamentoItem.Approvata != null) && (DomandaDiPagamentoItem.Approvata.Value == ApprovataEqualThis.Value))))
                {
                    DomandaDiPagamentoCollectionTemp.Add(DomandaDiPagamentoItem);
                }
            }
            return DomandaDiPagamentoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DomandaDiPagamentoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DomandaDiPagamentoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaDiPagamento DomandaDiPagamentoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DomandaDiPagamentoObj.IdDomandaPagamento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", DomandaDiPagamentoObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DomandaDiPagamentoObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", DomandaDiPagamentoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", DomandaDiPagamentoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", DomandaDiPagamentoObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", DomandaDiPagamentoObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFidejussione", DomandaDiPagamentoObj.IdFidejussione);
            DbProvider.SetCmdParam(cmd, firstChar + "CfOperatore", DomandaDiPagamentoObj.CfOperatore);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAllegati", DomandaDiPagamentoObj.SegnaturaAllegati);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCertificazioneAntimafia", DomandaDiPagamentoObj.DataCertificazioneAntimafia);
            DbProvider.SetCmdParam(cmd, firstChar + "Approvata", DomandaDiPagamentoObj.Approvata);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaApprovazione", DomandaDiPagamentoObj.SegnaturaApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "CfIstruttore", DomandaDiPagamentoObj.CfIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataApprovazione", DomandaDiPagamentoObj.DataApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaSecondaApprovazione", DomandaDiPagamentoObj.SegnaturaSecondaApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Annullata", DomandaDiPagamentoObj.Annullata);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAnnullamento", DomandaDiPagamentoObj.SegnaturaAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfOperatoreAnnullamento", DomandaDiPagamentoObj.CfOperatoreAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAnnullamento", DomandaDiPagamentoObj.DataAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "ValiditaVersioneAdc", DomandaDiPagamentoObj.ValiditaVersioneAdc);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariazioneAccertata", DomandaDiPagamentoObj.IdVariazioneAccertata);
            DbProvider.SetCmdParam(cmd, firstChar + "PredispostaAControllo", DomandaDiPagamentoObj.PredispostaAControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "VisitaInsituEsito", DomandaDiPagamentoObj.VisitaInsituEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "VisitaInsituNote", DomandaDiPagamentoObj.VisitaInsituNote);
            DbProvider.SetCmdParam(cmd, firstChar + "ControlloInlocoEsito", DomandaDiPagamentoObj.ControlloInlocoEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "ControlloInlocoNote", DomandaDiPagamentoObj.ControlloInlocoNote);
            DbProvider.SetCmdParam(cmd, firstChar + "ValutazioneIstruttore", DomandaDiPagamentoObj.ValutazioneIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiEsito", DomandaDiPagamentoObj.VerificaPagamentiEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiMessaggio", DomandaDiPagamentoObj.VerificaPagamentiMessaggio);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiData", DomandaDiPagamentoObj.VerificaPagamentiData);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPredisposizioneAControllo", DomandaDiPagamentoObj.DataPredisposizioneAControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredisposta", DomandaDiPagamentoObj.FirmaPredisposta);
            DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", DomandaDiPagamentoObj.InIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredispostaRup", DomandaDiPagamentoObj.FirmaPredispostaRup);
        }
        //Insert
        private static int Insert(DbProvider db, DomandaDiPagamento DomandaDiPagamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDomandaDiPagamentoInsert", new string[] {"CodTipo", "IdProgetto", 
"DataInserimento", "DataModifica", "CodEnte", 
"Segnatura", 
"IdFidejussione", 
"CfOperatore", "SegnaturaAllegati", 
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione", 
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione", 
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento", 
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata", 
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote", 
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore", 
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData", 
"DataPredisposizioneAControllo", 
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup"}, new string[] {"string", "int", 
"DateTime", "DateTime", "string", 
"string", 
"int", 
"string", "string", 
"DateTime", "bool", "string", 
"string", "DateTime", "string", 
"bool", "string", "string", 
"DateTime", "bool", "int", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"DateTime", 
"bool", "bool", "bool"}, "");
                CompileIUCmd(false, insertCmd, DomandaDiPagamentoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DomandaDiPagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
                    DomandaDiPagamentoObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
                    DomandaDiPagamentoObj.ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
                    DomandaDiPagamentoObj.PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
                    DomandaDiPagamentoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
                    DomandaDiPagamentoObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                }
                DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoObj.IsDirty = false;
                DomandaDiPagamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DomandaDiPagamento DomandaDiPagamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaDiPagamentoUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto", 
"DataInserimento", "DataModifica", "CodEnte", 
"Segnatura", 
"IdFidejussione", 
"CfOperatore", "SegnaturaAllegati", 
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione", 
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione", 
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento", 
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata", 
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote", 
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore", 
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData", 
"DataPredisposizioneAControllo", 
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup"}, new string[] {"int", "string", "int", 
"DateTime", "DateTime", "string", 
"string", 
"int", 
"string", "string", 
"DateTime", "bool", "string", 
"string", "DateTime", "string", 
"bool", "string", "string", 
"DateTime", "bool", "int", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"DateTime", 
"bool", "bool", "bool"}, "");
                CompileIUCmd(true, updateCmd, DomandaDiPagamentoObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoObj.IsDirty = false;
                DomandaDiPagamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DomandaDiPagamento DomandaDiPagamentoObj)
        {
            switch (DomandaDiPagamentoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DomandaDiPagamentoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DomandaDiPagamentoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DomandaDiPagamentoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DomandaDiPagamentoCollection DomandaDiPagamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaDiPagamentoUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto", 
"DataInserimento", "DataModifica", "CodEnte", 
"Segnatura", 
"IdFidejussione", 
"CfOperatore", "SegnaturaAllegati", 
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione", 
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione", 
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento", 
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata", 
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote", 
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore", 
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData", 
"DataPredisposizioneAControllo", 
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup"}, new string[] {"int", "string", "int", 
"DateTime", "DateTime", "string", 
"string", 
"int", 
"string", "string", 
"DateTime", "bool", "string", 
"string", "DateTime", "string", 
"bool", "string", "string", 
"DateTime", "bool", "int", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"DateTime", 
"bool", "bool", "bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZDomandaDiPagamentoInsert", new string[] {"CodTipo", "IdProgetto", 
"DataInserimento", "DataModifica", "CodEnte", 
"Segnatura", 
"IdFidejussione", 
"CfOperatore", "SegnaturaAllegati", 
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione", 
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione", 
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento", 
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata", 
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote", 
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore", 
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData", 
"DataPredisposizioneAControllo", 
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup"}, new string[] {"string", "int", 
"DateTime", "DateTime", "string", 
"string", 
"int", 
"string", "string", 
"DateTime", "bool", "string", 
"string", "DateTime", "string", 
"bool", "string", "string", 
"DateTime", "bool", "int", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"DateTime", 
"bool", "bool", "bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoDelete", new string[] { "IdDomandaPagamento" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaDiPagamentoCollectionObj.Count; i++)
                {
                    switch (DomandaDiPagamentoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DomandaDiPagamentoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DomandaDiPagamentoCollectionObj[i].IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
                                    DomandaDiPagamentoCollectionObj[i].Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
                                    DomandaDiPagamentoCollectionObj[i].ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
                                    DomandaDiPagamentoCollectionObj[i].PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
                                    DomandaDiPagamentoCollectionObj[i].FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
                                    DomandaDiPagamentoCollectionObj[i].InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DomandaDiPagamentoCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DomandaDiPagamentoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)DomandaDiPagamentoCollectionObj[i].IdDomandaPagamento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DomandaDiPagamentoCollectionObj.Count; i++)
                {
                    if ((DomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoCollectionObj[i].IsPersistent = true;
                    }
                    if ((DomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DomandaDiPagamento DomandaDiPagamentoObj)
        {
            int returnValue = 0;
            if (DomandaDiPagamentoObj.IsPersistent)
            {
                returnValue = Delete(db, DomandaDiPagamentoObj.IdDomandaPagamento);
            }
            DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DomandaDiPagamentoObj.IsDirty = false;
            DomandaDiPagamentoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdDomandaPagamentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoDelete", new string[] { "IdDomandaPagamento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DomandaDiPagamentoCollection DomandaDiPagamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoDelete", new string[] { "IdDomandaPagamento" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaDiPagamentoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDomandaPagamento", DomandaDiPagamentoCollectionObj[i].IdDomandaPagamento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DomandaDiPagamentoCollectionObj.Count; i++)
                {
                    if ((DomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoCollectionObj[i].IsPersistent = false;
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
        public static DomandaDiPagamento GetById(DbProvider db, int IdDomandaPagamentoValue)
        {
            DomandaDiPagamento DomandaDiPagamentoObj = null;
            IDbCommand readCmd = db.InitCmd("ZDomandaDiPagamentoGetById", new string[] { "IdDomandaPagamento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DomandaDiPagamentoObj = GetFromDatareader(db);
                DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoObj.IsDirty = false;
                DomandaDiPagamentoObj.IsPersistent = true;
            }
            db.Close();
            return DomandaDiPagamentoObj;
        }

        //getFromDatareader
        public static DomandaDiPagamento GetFromDatareader(DbProvider db)
        {
            DomandaDiPagamento DomandaDiPagamentoObj = new DomandaDiPagamento();
            DomandaDiPagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DomandaDiPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            DomandaDiPagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DomandaDiPagamentoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            DomandaDiPagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            DomandaDiPagamentoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            DomandaDiPagamentoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            DomandaDiPagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            DomandaDiPagamentoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
            DomandaDiPagamentoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
            DomandaDiPagamentoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            DomandaDiPagamentoObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
            DomandaDiPagamentoObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
            DomandaDiPagamentoObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
            DomandaDiPagamentoObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            DomandaDiPagamentoObj.DataCertificazioneAntimafia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_ANTIMAFIA"]);
            DomandaDiPagamentoObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            DomandaDiPagamentoObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
            DomandaDiPagamentoObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
            DomandaDiPagamentoObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            DomandaDiPagamentoObj.SegnaturaSecondaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE"]);
            DomandaDiPagamentoObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            DomandaDiPagamentoObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
            DomandaDiPagamentoObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
            DomandaDiPagamentoObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
            DomandaDiPagamentoObj.ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
            DomandaDiPagamentoObj.IdVariazioneAccertata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIAZIONE_ACCERTATA"]);
            DomandaDiPagamentoObj.PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
            DomandaDiPagamentoObj.VisitaInsituEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_ESITO"]);
            DomandaDiPagamentoObj.VisitaInsituNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_NOTE"]);
            DomandaDiPagamentoObj.ControlloInlocoEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_ESITO"]);
            DomandaDiPagamentoObj.ControlloInlocoNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_NOTE"]);
            DomandaDiPagamentoObj.ValutazioneIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_ISTRUTTORE"]);
            DomandaDiPagamentoObj.VerificaPagamentiEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_ESITO"]);
            DomandaDiPagamentoObj.VerificaPagamentiMessaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_MESSAGGIO"]);
            DomandaDiPagamentoObj.VerificaPagamentiData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VERIFICA_PAGAMENTI_DATA"]);
            DomandaDiPagamentoObj.DataPredisposizioneAControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PREDISPOSIZIONE_A_CONTROLLO"]);
            DomandaDiPagamentoObj.NominativoOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_ANNULLAMENTO"]);
            DomandaDiPagamentoObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            DomandaDiPagamentoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            DomandaDiPagamentoObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            DomandaDiPagamentoObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
            DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DomandaDiPagamentoObj.IsDirty = false;
            DomandaDiPagamentoObj.IsPersistent = true;
            return DomandaDiPagamentoObj;
        }

        //Find Select

        public static DomandaDiPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis,
SiarLibrary.NullTypes.IntNT IdFidejussioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificazioneAntimafiaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT CfIstruttoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
SiarLibrary.NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.BoolNT ValiditaVersioneAdcEqualThis,
SiarLibrary.NullTypes.IntNT IdVariazioneAccertataEqualThis, SiarLibrary.NullTypes.BoolNT PredispostaAControlloEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPredisposizioneAControlloEqualThis,
SiarLibrary.NullTypes.StringNT VisitaInsituEsitoEqualThis, SiarLibrary.NullTypes.StringNT ControlloInlocoEsitoEqualThis, SiarLibrary.NullTypes.StringNT VerificaPagamentiEsitoEqualThis,
SiarLibrary.NullTypes.StringNT VerificaPagamentiMessaggioEqualThis, SiarLibrary.NullTypes.DatetimeNT VerificaPagamentiDataEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis,
SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis)
        {

            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionObj = new DomandaDiPagamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandadipagamentofindselect", new string[] {"IdDomandaPagamentoequalthis", "CodTipoequalthis", "IdProgettoequalthis", 
"DataInserimentoequalthis", "CfOperatoreequalthis", "DataModificaequalthis", 
"CodEnteequalthis", "Segnaturaequalthis", "SegnaturaAllegatiequalthis", 
"IdFidejussioneequalthis", "DataCertificazioneAntimafiaequalthis", "Approvataequalthis", 
"SegnaturaApprovazioneequalthis", "SegnaturaSecondaApprovazioneequalthis", "CfIstruttoreequalthis", 
"DataApprovazioneequalthis", "Annullataequalthis", "SegnaturaAnnullamentoequalthis", 
"CfOperatoreAnnullamentoequalthis", "DataAnnullamentoequalthis", "ValiditaVersioneAdcequalthis", 
"IdVariazioneAccertataequalthis", "PredispostaAControlloequalthis", "DataPredisposizioneAControlloequalthis", 
"VisitaInsituEsitoequalthis", "ControlloInlocoEsitoequalthis", "VerificaPagamentiEsitoequalthis", 
"VerificaPagamentiMessaggioequalthis", "VerificaPagamentiDataequalthis", "FirmaPredispostaequalthis", 
"FirmaPredispostaRupequalthis", "InIntegrazioneequalthis"}, new string[] {"int", "string", "int", 
"DateTime", "string", "DateTime", 
"string", "string", "string", 
"int", "DateTime", "bool", 
"string", "string", "string", 
"DateTime", "bool", "string", 
"string", "DateTime", "bool", 
"int", "bool", "DateTime", 
"string", "string", "string", 
"string", "DateTime", "bool", 
"bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFidejussioneequalthis", IdFidejussioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCertificazioneAntimafiaequalthis", DataCertificazioneAntimafiaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaApprovazioneequalthis", SegnaturaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaSecondaApprovazioneequalthis", SegnaturaSecondaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfIstruttoreequalthis", CfIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAnnullamentoequalthis", SegnaturaAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreAnnullamentoequalthis", CfOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValiditaVersioneAdcequalthis", ValiditaVersioneAdcEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVariazioneAccertataequalthis", IdVariazioneAccertataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PredispostaAControlloequalthis", PredispostaAControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPredisposizioneAControlloequalthis", DataPredisposizioneAControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VisitaInsituEsitoequalthis", VisitaInsituEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ControlloInlocoEsitoequalthis", ControlloInlocoEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiEsitoequalthis", VerificaPagamentiEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiMessaggioequalthis", VerificaPagamentiMessaggioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiDataequalthis", VerificaPagamentiDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DomandaDiPagamento DomandaDiPagamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaDiPagamentoObj = GetFromDatareader(db);
                DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoObj.IsDirty = false;
                DomandaDiPagamentoObj.IsPersistent = true;
                DomandaDiPagamentoCollectionObj.Add(DomandaDiPagamentoObj);
            }
            db.Close();
            return DomandaDiPagamentoCollectionObj;
        }

        //Find Find

        public static DomandaDiPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT CodFaseEqualThis)
        {

            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionObj = new DomandaDiPagamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandadipagamentofindfind", new string[] {"IdDomandaPagamentoequalthis", "CodTipoequalthis", "IdProgettoequalthis", 
"CodFaseequalthis"}, new string[] {"int", "string", "int", 
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
            DomandaDiPagamento DomandaDiPagamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaDiPagamentoObj = GetFromDatareader(db);
                DomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoObj.IsDirty = false;
                DomandaDiPagamentoObj.IsPersistent = true;
                DomandaDiPagamentoCollectionObj.Add(DomandaDiPagamentoObj);
            }
            db.Close();
            return DomandaDiPagamentoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DomandaDiPagamentoCollectionProvider:IDomandaDiPagamentoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaDiPagamentoCollectionProvider : IDomandaDiPagamentoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DomandaDiPagamento
        protected DomandaDiPagamentoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DomandaDiPagamentoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DomandaDiPagamentoCollection(this);
        }

        //Costruttore 2: popola la collection
        public DomandaDiPagamentoCollectionProvider(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodfaseEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IddomandapagamentoEqualThis, CodtipoEqualThis, IdprogettoEqualThis,
CodfaseEqualThis);
        }

        //Costruttore3: ha in input domandadipagamentoCollectionObj - non popola la collection
        public DomandaDiPagamentoCollectionProvider(DomandaDiPagamentoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DomandaDiPagamentoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DomandaDiPagamentoCollection(this);
        }

        //Get e Set
        public DomandaDiPagamentoCollection CollectionObj
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
        public int SaveCollection(DomandaDiPagamentoCollection collectionObj)
        {
            return DomandaDiPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DomandaDiPagamento domandadipagamentoObj)
        {
            return DomandaDiPagamentoDAL.Save(_dbProviderObj, domandadipagamentoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DomandaDiPagamentoCollection collectionObj)
        {
            return DomandaDiPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DomandaDiPagamento domandadipagamentoObj)
        {
            return DomandaDiPagamentoDAL.Delete(_dbProviderObj, domandadipagamentoObj);
        }

        //getById
        public DomandaDiPagamento GetById(IntNT IdDomandaPagamentoValue)
        {
            DomandaDiPagamento DomandaDiPagamentoTemp = DomandaDiPagamentoDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue);
            if (DomandaDiPagamentoTemp != null) DomandaDiPagamentoTemp.Provider = this;
            return DomandaDiPagamentoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public DomandaDiPagamentoCollection Select(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CfoperatoreEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT CodenteEqualThis, StringNT SegnaturaEqualThis, StringNT SegnaturaallegatiEqualThis,
IntNT IdfidejussioneEqualThis, DatetimeNT DatacertificazioneantimafiaEqualThis, BoolNT ApprovataEqualThis,
StringNT SegnaturaapprovazioneEqualThis, StringNT SegnaturasecondaapprovazioneEqualThis, StringNT CfistruttoreEqualThis,
DatetimeNT DataapprovazioneEqualThis, BoolNT AnnullataEqualThis, StringNT SegnaturaannullamentoEqualThis,
StringNT CfoperatoreannullamentoEqualThis, DatetimeNT DataannullamentoEqualThis, BoolNT ValiditaversioneadcEqualThis,
IntNT IdvariazioneaccertataEqualThis, BoolNT PredispostaacontrolloEqualThis, DatetimeNT DatapredisposizioneacontrolloEqualThis,
StringNT VisitainsituesitoEqualThis, StringNT ControlloinlocoesitoEqualThis, StringNT VerificapagamentiesitoEqualThis,
StringNT VerificapagamentimessaggioEqualThis, DatetimeNT VerificapagamentidataEqualThis, BoolNT FirmapredispostaEqualThis,
BoolNT FirmapredispostarupEqualThis, BoolNT InintegrazioneEqualThis)
        {
            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionTemp = DomandaDiPagamentoDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, CodtipoEqualThis, IdprogettoEqualThis,
DatainserimentoEqualThis, CfoperatoreEqualThis, DatamodificaEqualThis,
CodenteEqualThis, SegnaturaEqualThis, SegnaturaallegatiEqualThis,
IdfidejussioneEqualThis, DatacertificazioneantimafiaEqualThis, ApprovataEqualThis,
SegnaturaapprovazioneEqualThis, SegnaturasecondaapprovazioneEqualThis, CfistruttoreEqualThis,
DataapprovazioneEqualThis, AnnullataEqualThis, SegnaturaannullamentoEqualThis,
CfoperatoreannullamentoEqualThis, DataannullamentoEqualThis, ValiditaversioneadcEqualThis,
IdvariazioneaccertataEqualThis, PredispostaacontrolloEqualThis, DatapredisposizioneacontrolloEqualThis,
VisitainsituesitoEqualThis, ControlloinlocoesitoEqualThis, VerificapagamentiesitoEqualThis,
VerificapagamentimessaggioEqualThis, VerificapagamentidataEqualThis, FirmapredispostaEqualThis,
FirmapredispostarupEqualThis, InintegrazioneEqualThis);
            DomandaDiPagamentoCollectionTemp.Provider = this;
            return DomandaDiPagamentoCollectionTemp;
        }

        //Find: popola la collection
        public DomandaDiPagamentoCollection Find(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis,
StringNT CodfaseEqualThis)
        {
            DomandaDiPagamentoCollection DomandaDiPagamentoCollectionTemp = DomandaDiPagamentoDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, CodtipoEqualThis, IdprogettoEqualThis,
CodfaseEqualThis);
            DomandaDiPagamentoCollectionTemp.Provider = this;
            return DomandaDiPagamentoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO>
  <ViewName>vDOMANDA_DI_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroApprovata>
      <APPROVATA>Equal</APPROVATA>
    </FiltroApprovata>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO>
*/
