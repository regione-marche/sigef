using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DomandaDiPagamentoModifiche
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDomandaDiPagamentoModificheProvider
    {
        int Save(DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj);
        int SaveCollection(DomandaDiPagamentoModificheCollection collectionObj);
        int Delete(DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj);
        int DeleteCollection(DomandaDiPagamentoModificheCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DomandaDiPagamentoModifiche
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DomandaDiPagamentoModifiche : BaseObject
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
        private NullTypes.IntNT _Id;
        private NullTypes.IntNT _IdModifica;
        [NonSerialized] private IDomandaDiPagamentoModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaDiPagamentoModificheProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DomandaDiPagamentoModifiche()
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
        /// Corrisponde al campo:ID_MODIFICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdModifica
        {
            get { return _IdModifica; }
            set
            {
                if (IdModifica != value)
                {
                    _IdModifica = value;
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
    /// Summary description for DomandaDiPagamentoModificheCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaDiPagamentoModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DomandaDiPagamentoModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DomandaDiPagamentoModifiche)info.GetValue(i.ToString(), typeof(DomandaDiPagamentoModifiche)));
            }
        }

        //Costruttore
        public DomandaDiPagamentoModificheCollection()
        {
            this.ItemType = typeof(DomandaDiPagamentoModifiche);
        }

        //Costruttore con provider
        public DomandaDiPagamentoModificheCollection(IDomandaDiPagamentoModificheProvider providerObj)
        {
            this.ItemType = typeof(DomandaDiPagamentoModifiche);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DomandaDiPagamentoModifiche this[int index]
        {
            get { return (DomandaDiPagamentoModifiche)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DomandaDiPagamentoModificheCollection GetChanges()
        {
            return (DomandaDiPagamentoModificheCollection)base.GetChanges();
        }

        [NonSerialized] private IDomandaDiPagamentoModificheProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaDiPagamentoModificheProvider Provider
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
        public int Add(DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            if (DomandaDiPagamentoModificheObj.Provider == null) DomandaDiPagamentoModificheObj.Provider = this.Provider;
            return base.Add(DomandaDiPagamentoModificheObj);
        }

        //AddCollection
        public void AddCollection(DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionObj)
        {
            foreach (DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj in DomandaDiPagamentoModificheCollectionObj)
                this.Add(DomandaDiPagamentoModificheObj);
        }

        //Insert
        public void Insert(int index, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            if (DomandaDiPagamentoModificheObj.Provider == null) DomandaDiPagamentoModificheObj.Provider = this.Provider;
            base.Insert(index, DomandaDiPagamentoModificheObj);
        }

        //CollectionGetById
        public DomandaDiPagamentoModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
        public DomandaDiPagamentoModificheCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CodEnteEqualThis,
NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodFaseEqualThis,
NullTypes.StringNT FaseEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.IntNT IdFidejussioneEqualThis,
NullTypes.StringNT OperatoreEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.StringNT SegnaturaAllegatiEqualThis,
NullTypes.DatetimeNT DataCertificazioneAntimafiaEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.StringNT SegnaturaApprovazioneEqualThis,
NullTypes.StringNT CfIstruttoreEqualThis, NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis,
NullTypes.BoolNT AnnullataEqualThis, NullTypes.StringNT SegnaturaAnnullamentoEqualThis, NullTypes.StringNT CfOperatoreAnnullamentoEqualThis,
NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.BoolNT ValiditaVersioneAdcEqualThis, NullTypes.IntNT IdVariazioneAccertataEqualThis,
NullTypes.BoolNT PredispostaAControlloEqualThis, NullTypes.StringNT VisitaInsituEsitoEqualThis, NullTypes.StringNT ControlloInlocoEsitoEqualThis,
NullTypes.StringNT VerificaPagamentiEsitoEqualThis, NullTypes.StringNT VerificaPagamentiMessaggioEqualThis, NullTypes.DatetimeNT VerificaPagamentiDataEqualThis,
NullTypes.DatetimeNT DataPredisposizioneAControlloEqualThis, NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis, NullTypes.StringNT IstruttoreEqualThis,
NullTypes.BoolNT FirmaPredispostaEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.BoolNT FirmaPredispostaRupEqualThis,
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
        {
            DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionTemp = new DomandaDiPagamentoModificheCollection();
            foreach (DomandaDiPagamentoModifiche DomandaDiPagamentoModificheItem in this)
            {
                if (((IdDomandaPagamentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.IdDomandaPagamento != null) && (DomandaDiPagamentoModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((DomandaDiPagamentoModificheItem.CodTipo != null) && (DomandaDiPagamentoModificheItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaDiPagamentoModificheItem.IdProgetto != null) && (DomandaDiPagamentoModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataInserimento != null) && (DomandaDiPagamentoModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataModifica != null) && (DomandaDiPagamentoModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CodEnteEqualThis == null) || ((DomandaDiPagamentoModificheItem.CodEnte != null) && (DomandaDiPagamentoModificheItem.CodEnte.Value == CodEnteEqualThis.Value))) &&
((SegnaturaEqualThis == null) || ((DomandaDiPagamentoModificheItem.Segnatura != null) && (DomandaDiPagamentoModificheItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.Descrizione != null) && (DomandaDiPagamentoModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodFaseEqualThis == null) || ((DomandaDiPagamentoModificheItem.CodFase != null) && (DomandaDiPagamentoModificheItem.CodFase.Value == CodFaseEqualThis.Value))) &&
((FaseEqualThis == null) || ((DomandaDiPagamentoModificheItem.Fase != null) && (DomandaDiPagamentoModificheItem.Fase.Value == FaseEqualThis.Value))) && ((OrdineEqualThis == null) || ((DomandaDiPagamentoModificheItem.Ordine != null) && (DomandaDiPagamentoModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((IdFidejussioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.IdFidejussione != null) && (DomandaDiPagamentoModificheItem.IdFidejussione.Value == IdFidejussioneEqualThis.Value))) &&
((OperatoreEqualThis == null) || ((DomandaDiPagamentoModificheItem.Operatore != null) && (DomandaDiPagamentoModificheItem.Operatore.Value == OperatoreEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((DomandaDiPagamentoModificheItem.CfOperatore != null) && (DomandaDiPagamentoModificheItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((SegnaturaAllegatiEqualThis == null) || ((DomandaDiPagamentoModificheItem.SegnaturaAllegati != null) && (DomandaDiPagamentoModificheItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) &&
((DataCertificazioneAntimafiaEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataCertificazioneAntimafia != null) && (DomandaDiPagamentoModificheItem.DataCertificazioneAntimafia.Value == DataCertificazioneAntimafiaEqualThis.Value))) && ((ApprovataEqualThis == null) || ((DomandaDiPagamentoModificheItem.Approvata != null) && (DomandaDiPagamentoModificheItem.Approvata.Value == ApprovataEqualThis.Value))) && ((SegnaturaApprovazioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.SegnaturaApprovazione != null) && (DomandaDiPagamentoModificheItem.SegnaturaApprovazione.Value == SegnaturaApprovazioneEqualThis.Value))) &&
((CfIstruttoreEqualThis == null) || ((DomandaDiPagamentoModificheItem.CfIstruttore != null) && (DomandaDiPagamentoModificheItem.CfIstruttore.Value == CfIstruttoreEqualThis.Value))) && ((DataApprovazioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataApprovazione != null) && (DomandaDiPagamentoModificheItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((SegnaturaSecondaApprovazioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.SegnaturaSecondaApprovazione != null) && (DomandaDiPagamentoModificheItem.SegnaturaSecondaApprovazione.Value == SegnaturaSecondaApprovazioneEqualThis.Value))) &&
((AnnullataEqualThis == null) || ((DomandaDiPagamentoModificheItem.Annullata != null) && (DomandaDiPagamentoModificheItem.Annullata.Value == AnnullataEqualThis.Value))) && ((SegnaturaAnnullamentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.SegnaturaAnnullamento != null) && (DomandaDiPagamentoModificheItem.SegnaturaAnnullamento.Value == SegnaturaAnnullamentoEqualThis.Value))) && ((CfOperatoreAnnullamentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.CfOperatoreAnnullamento != null) && (DomandaDiPagamentoModificheItem.CfOperatoreAnnullamento.Value == CfOperatoreAnnullamentoEqualThis.Value))) &&
((DataAnnullamentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataAnnullamento != null) && (DomandaDiPagamentoModificheItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((ValiditaVersioneAdcEqualThis == null) || ((DomandaDiPagamentoModificheItem.ValiditaVersioneAdc != null) && (DomandaDiPagamentoModificheItem.ValiditaVersioneAdc.Value == ValiditaVersioneAdcEqualThis.Value))) && ((IdVariazioneAccertataEqualThis == null) || ((DomandaDiPagamentoModificheItem.IdVariazioneAccertata != null) && (DomandaDiPagamentoModificheItem.IdVariazioneAccertata.Value == IdVariazioneAccertataEqualThis.Value))) &&
((PredispostaAControlloEqualThis == null) || ((DomandaDiPagamentoModificheItem.PredispostaAControllo != null) && (DomandaDiPagamentoModificheItem.PredispostaAControllo.Value == PredispostaAControlloEqualThis.Value))) && ((VisitaInsituEsitoEqualThis == null) || ((DomandaDiPagamentoModificheItem.VisitaInsituEsito != null) && (DomandaDiPagamentoModificheItem.VisitaInsituEsito.Value == VisitaInsituEsitoEqualThis.Value))) && ((ControlloInlocoEsitoEqualThis == null) || ((DomandaDiPagamentoModificheItem.ControlloInlocoEsito != null) && (DomandaDiPagamentoModificheItem.ControlloInlocoEsito.Value == ControlloInlocoEsitoEqualThis.Value))) &&
((VerificaPagamentiEsitoEqualThis == null) || ((DomandaDiPagamentoModificheItem.VerificaPagamentiEsito != null) && (DomandaDiPagamentoModificheItem.VerificaPagamentiEsito.Value == VerificaPagamentiEsitoEqualThis.Value))) && ((VerificaPagamentiMessaggioEqualThis == null) || ((DomandaDiPagamentoModificheItem.VerificaPagamentiMessaggio != null) && (DomandaDiPagamentoModificheItem.VerificaPagamentiMessaggio.Value == VerificaPagamentiMessaggioEqualThis.Value))) && ((VerificaPagamentiDataEqualThis == null) || ((DomandaDiPagamentoModificheItem.VerificaPagamentiData != null) && (DomandaDiPagamentoModificheItem.VerificaPagamentiData.Value == VerificaPagamentiDataEqualThis.Value))) &&
((DataPredisposizioneAControlloEqualThis == null) || ((DomandaDiPagamentoModificheItem.DataPredisposizioneAControllo != null) && (DomandaDiPagamentoModificheItem.DataPredisposizioneAControllo.Value == DataPredisposizioneAControlloEqualThis.Value))) && ((NominativoOperatoreAnnullamentoEqualThis == null) || ((DomandaDiPagamentoModificheItem.NominativoOperatoreAnnullamento != null) && (DomandaDiPagamentoModificheItem.NominativoOperatoreAnnullamento.Value == NominativoOperatoreAnnullamentoEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((DomandaDiPagamentoModificheItem.Istruttore != null) && (DomandaDiPagamentoModificheItem.Istruttore.Value == IstruttoreEqualThis.Value))) &&
((FirmaPredispostaEqualThis == null) || ((DomandaDiPagamentoModificheItem.FirmaPredisposta != null) && (DomandaDiPagamentoModificheItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((DomandaDiPagamentoModificheItem.InIntegrazione != null) && (DomandaDiPagamentoModificheItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((FirmaPredispostaRupEqualThis == null) || ((DomandaDiPagamentoModificheItem.FirmaPredispostaRup != null) && (DomandaDiPagamentoModificheItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))) &&
((IdEqualThis == null) || ((DomandaDiPagamentoModificheItem.Id != null) && (DomandaDiPagamentoModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((DomandaDiPagamentoModificheItem.IdModifica != null) && (DomandaDiPagamentoModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
                {
                    DomandaDiPagamentoModificheCollectionTemp.Add(DomandaDiPagamentoModificheItem);
                }
            }
            return DomandaDiPagamentoModificheCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DomandaDiPagamentoModificheDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DomandaDiPagamentoModificheDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", DomandaDiPagamentoModificheObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DomandaDiPagamentoModificheObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", DomandaDiPagamentoModificheObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DomandaDiPagamentoModificheObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", DomandaDiPagamentoModificheObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", DomandaDiPagamentoModificheObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", DomandaDiPagamentoModificheObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", DomandaDiPagamentoModificheObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", DomandaDiPagamentoModificheObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodFase", DomandaDiPagamentoModificheObj.CodFase);
            DbProvider.SetCmdParam(cmd, firstChar + "Fase", DomandaDiPagamentoModificheObj.Fase);
            DbProvider.SetCmdParam(cmd, firstChar + "Ordine", DomandaDiPagamentoModificheObj.Ordine);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFidejussione", DomandaDiPagamentoModificheObj.IdFidejussione);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", DomandaDiPagamentoModificheObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "CfOperatore", DomandaDiPagamentoModificheObj.CfOperatore);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAllegati", DomandaDiPagamentoModificheObj.SegnaturaAllegati);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCertificazioneAntimafia", DomandaDiPagamentoModificheObj.DataCertificazioneAntimafia);
            DbProvider.SetCmdParam(cmd, firstChar + "Approvata", DomandaDiPagamentoModificheObj.Approvata);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaApprovazione", DomandaDiPagamentoModificheObj.SegnaturaApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "CfIstruttore", DomandaDiPagamentoModificheObj.CfIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataApprovazione", DomandaDiPagamentoModificheObj.DataApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaSecondaApprovazione", DomandaDiPagamentoModificheObj.SegnaturaSecondaApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Annullata", DomandaDiPagamentoModificheObj.Annullata);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAnnullamento", DomandaDiPagamentoModificheObj.SegnaturaAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfOperatoreAnnullamento", DomandaDiPagamentoModificheObj.CfOperatoreAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAnnullamento", DomandaDiPagamentoModificheObj.DataAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "ValiditaVersioneAdc", DomandaDiPagamentoModificheObj.ValiditaVersioneAdc);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariazioneAccertata", DomandaDiPagamentoModificheObj.IdVariazioneAccertata);
            DbProvider.SetCmdParam(cmd, firstChar + "PredispostaAControllo", DomandaDiPagamentoModificheObj.PredispostaAControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "VisitaInsituEsito", DomandaDiPagamentoModificheObj.VisitaInsituEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "VisitaInsituNote", DomandaDiPagamentoModificheObj.VisitaInsituNote);
            DbProvider.SetCmdParam(cmd, firstChar + "ControlloInlocoEsito", DomandaDiPagamentoModificheObj.ControlloInlocoEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "ControlloInlocoNote", DomandaDiPagamentoModificheObj.ControlloInlocoNote);
            DbProvider.SetCmdParam(cmd, firstChar + "ValutazioneIstruttore", DomandaDiPagamentoModificheObj.ValutazioneIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiEsito", DomandaDiPagamentoModificheObj.VerificaPagamentiEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiMessaggio", DomandaDiPagamentoModificheObj.VerificaPagamentiMessaggio);
            DbProvider.SetCmdParam(cmd, firstChar + "VerificaPagamentiData", DomandaDiPagamentoModificheObj.VerificaPagamentiData);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPredisposizioneAControllo", DomandaDiPagamentoModificheObj.DataPredisposizioneAControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "NominativoOperatoreAnnullamento", DomandaDiPagamentoModificheObj.NominativoOperatoreAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruttore", DomandaDiPagamentoModificheObj.Istruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredisposta", DomandaDiPagamentoModificheObj.FirmaPredisposta);
            DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", DomandaDiPagamentoModificheObj.InIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredispostaRup", DomandaDiPagamentoModificheObj.FirmaPredispostaRup);
            DbProvider.SetCmdParam(cmd, firstChar + "IdModifica", DomandaDiPagamentoModificheObj.IdModifica);
        }
        //Insert
        private static int Insert(DbProvider db, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDomandaDiPagamentoModificheInsert", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto",
"DataInserimento", "DataModifica", "CodEnte",
"Segnatura", "Descrizione", "CodFase",
"Fase", "Ordine", "IdFidejussione",
"Operatore", "CfOperatore", "SegnaturaAllegati",
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione",
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione",
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento",
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata",
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote",
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore",
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData",
"DataPredisposizioneAControllo", "NominativoOperatoreAnnullamento", "Istruttore",
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup",
"IdModifica"}, new string[] {"int", "string", "int",
"DateTime", "DateTime", "string",
"string", "string", "string",
"string", "int", "int",
"string", "string", "string",
"DateTime", "bool", "string",
"string", "DateTime", "string",
"bool", "string", "string",
"DateTime", "bool", "int",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"DateTime", "string", "string",
"bool", "bool", "bool",
"int"}, "");
                CompileIUCmd(false, insertCmd, DomandaDiPagamentoModificheObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DomandaDiPagamentoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoModificheObj.IsDirty = false;
                DomandaDiPagamentoModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaDiPagamentoModificheUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto",
"DataInserimento", "DataModifica", "CodEnte",
"Segnatura", "Descrizione", "CodFase",
"Fase", "Ordine", "IdFidejussione",
"Operatore", "CfOperatore", "SegnaturaAllegati",
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione",
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione",
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento",
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata",
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote",
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore",
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData",
"DataPredisposizioneAControllo", "NominativoOperatoreAnnullamento", "Istruttore",
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup",
"Id", "IdModifica"}, new string[] {"int", "string", "int",
"DateTime", "DateTime", "string",
"string", "string", "string",
"string", "int", "int",
"string", "string", "string",
"DateTime", "bool", "string",
"string", "DateTime", "string",
"bool", "string", "string",
"DateTime", "bool", "int",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"DateTime", "string", "string",
"bool", "bool", "bool",
"int", "int"}, "");
                CompileIUCmd(true, updateCmd, DomandaDiPagamentoModificheObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    DomandaDiPagamentoModificheObj.DataModifica = d;
                }
                DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoModificheObj.IsDirty = false;
                DomandaDiPagamentoModificheObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            switch (DomandaDiPagamentoModificheObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DomandaDiPagamentoModificheObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DomandaDiPagamentoModificheObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DomandaDiPagamentoModificheObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaDiPagamentoModificheUpdate", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto",
"DataInserimento", "DataModifica", "CodEnte",
"Segnatura", "Descrizione", "CodFase",
"Fase", "Ordine", "IdFidejussione",
"Operatore", "CfOperatore", "SegnaturaAllegati",
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione",
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione",
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento",
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata",
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote",
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore",
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData",
"DataPredisposizioneAControllo", "NominativoOperatoreAnnullamento", "Istruttore",
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup",
"Id", "IdModifica"}, new string[] {"int", "string", "int",
"DateTime", "DateTime", "string",
"string", "string", "string",
"string", "int", "int",
"string", "string", "string",
"DateTime", "bool", "string",
"string", "DateTime", "string",
"bool", "string", "string",
"DateTime", "bool", "int",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"DateTime", "string", "string",
"bool", "bool", "bool",
"int", "int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZDomandaDiPagamentoModificheInsert", new string[] {"IdDomandaPagamento", "CodTipo", "IdProgetto",
"DataInserimento", "DataModifica", "CodEnte",
"Segnatura", "Descrizione", "CodFase",
"Fase", "Ordine", "IdFidejussione",
"Operatore", "CfOperatore", "SegnaturaAllegati",
"DataCertificazioneAntimafia", "Approvata", "SegnaturaApprovazione",
"CfIstruttore", "DataApprovazione", "SegnaturaSecondaApprovazione",
"Annullata", "SegnaturaAnnullamento", "CfOperatoreAnnullamento",
"DataAnnullamento", "ValiditaVersioneAdc", "IdVariazioneAccertata",
"PredispostaAControllo", "VisitaInsituEsito", "VisitaInsituNote",
"ControlloInlocoEsito", "ControlloInlocoNote", "ValutazioneIstruttore",
"VerificaPagamentiEsito", "VerificaPagamentiMessaggio", "VerificaPagamentiData",
"DataPredisposizioneAControllo", "NominativoOperatoreAnnullamento", "Istruttore",
"FirmaPredisposta", "InIntegrazione", "FirmaPredispostaRup",
"IdModifica"}, new string[] {"int", "string", "int",
"DateTime", "DateTime", "string",
"string", "string", "string",
"string", "int", "int",
"string", "string", "string",
"DateTime", "bool", "string",
"string", "DateTime", "string",
"bool", "string", "string",
"DateTime", "bool", "int",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"DateTime", "string", "string",
"bool", "bool", "bool",
"int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaDiPagamentoModificheCollectionObj.Count; i++)
                {
                    switch (DomandaDiPagamentoModificheCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DomandaDiPagamentoModificheCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DomandaDiPagamentoModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DomandaDiPagamentoModificheCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    DomandaDiPagamentoModificheCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DomandaDiPagamentoModificheCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)DomandaDiPagamentoModificheCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DomandaDiPagamentoModificheCollectionObj.Count; i++)
                {
                    if ((DomandaDiPagamentoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaDiPagamentoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DomandaDiPagamentoModificheCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoModificheCollectionObj[i].IsPersistent = true;
                    }
                    if ((DomandaDiPagamentoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DomandaDiPagamentoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaDiPagamentoModificheCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoModificheCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj)
        {
            int returnValue = 0;
            if (DomandaDiPagamentoModificheObj.IsPersistent)
            {
                returnValue = Delete(db, DomandaDiPagamentoModificheObj.Id);
            }
            DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DomandaDiPagamentoModificheObj.IsDirty = false;
            DomandaDiPagamentoModificheObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaDiPagamentoModificheDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaDiPagamentoModificheCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", DomandaDiPagamentoModificheCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DomandaDiPagamentoModificheCollectionObj.Count; i++)
                {
                    if ((DomandaDiPagamentoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaDiPagamentoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaDiPagamentoModificheCollectionObj[i].IsDirty = false;
                        DomandaDiPagamentoModificheCollectionObj[i].IsPersistent = false;
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
        public static DomandaDiPagamentoModifiche GetById(DbProvider db, int IdValue)
        {
            DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj = null;
            IDbCommand readCmd = db.InitCmd("ZDomandaDiPagamentoModificheGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DomandaDiPagamentoModificheObj = GetFromDatareader(db);
                DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoModificheObj.IsDirty = false;
                DomandaDiPagamentoModificheObj.IsPersistent = true;
            }
            db.Close();
            return DomandaDiPagamentoModificheObj;
        }

        //getFromDatareader
        public static DomandaDiPagamentoModifiche GetFromDatareader(DbProvider db)
        {
            DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj = new DomandaDiPagamentoModifiche();
            DomandaDiPagamentoModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DomandaDiPagamentoModificheObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            DomandaDiPagamentoModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DomandaDiPagamentoModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            DomandaDiPagamentoModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            DomandaDiPagamentoModificheObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            DomandaDiPagamentoModificheObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            DomandaDiPagamentoModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            DomandaDiPagamentoModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
            DomandaDiPagamentoModificheObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
            DomandaDiPagamentoModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            DomandaDiPagamentoModificheObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
            DomandaDiPagamentoModificheObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
            DomandaDiPagamentoModificheObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
            DomandaDiPagamentoModificheObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            DomandaDiPagamentoModificheObj.DataCertificazioneAntimafia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_ANTIMAFIA"]);
            DomandaDiPagamentoModificheObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            DomandaDiPagamentoModificheObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
            DomandaDiPagamentoModificheObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
            DomandaDiPagamentoModificheObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            DomandaDiPagamentoModificheObj.SegnaturaSecondaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE"]);
            DomandaDiPagamentoModificheObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            DomandaDiPagamentoModificheObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
            DomandaDiPagamentoModificheObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
            DomandaDiPagamentoModificheObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
            DomandaDiPagamentoModificheObj.ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
            DomandaDiPagamentoModificheObj.IdVariazioneAccertata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIAZIONE_ACCERTATA"]);
            DomandaDiPagamentoModificheObj.PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
            DomandaDiPagamentoModificheObj.VisitaInsituEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_ESITO"]);
            DomandaDiPagamentoModificheObj.VisitaInsituNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_NOTE"]);
            DomandaDiPagamentoModificheObj.ControlloInlocoEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_ESITO"]);
            DomandaDiPagamentoModificheObj.ControlloInlocoNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_NOTE"]);
            DomandaDiPagamentoModificheObj.ValutazioneIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_ISTRUTTORE"]);
            DomandaDiPagamentoModificheObj.VerificaPagamentiEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_ESITO"]);
            DomandaDiPagamentoModificheObj.VerificaPagamentiMessaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_MESSAGGIO"]);
            DomandaDiPagamentoModificheObj.VerificaPagamentiData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VERIFICA_PAGAMENTI_DATA"]);
            DomandaDiPagamentoModificheObj.DataPredisposizioneAControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PREDISPOSIZIONE_A_CONTROLLO"]);
            DomandaDiPagamentoModificheObj.NominativoOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_ANNULLAMENTO"]);
            DomandaDiPagamentoModificheObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            DomandaDiPagamentoModificheObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            DomandaDiPagamentoModificheObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            DomandaDiPagamentoModificheObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
            DomandaDiPagamentoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            DomandaDiPagamentoModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
            DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DomandaDiPagamentoModificheObj.IsDirty = false;
            DomandaDiPagamentoModificheObj.IsPersistent = true;
            return DomandaDiPagamentoModificheObj;
        }

        //Find Select

        public static DomandaDiPagamentoModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis,
SiarLibrary.NullTypes.StringNT FaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.IntNT IdFidejussioneEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataCertificazioneAntimafiaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneEqualThis,
SiarLibrary.NullTypes.StringNT CfIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis,
SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAnnullamentoEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreAnnullamentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.BoolNT ValiditaVersioneAdcEqualThis, SiarLibrary.NullTypes.IntNT IdVariazioneAccertataEqualThis,
SiarLibrary.NullTypes.BoolNT PredispostaAControlloEqualThis, SiarLibrary.NullTypes.StringNT VisitaInsituEsitoEqualThis, SiarLibrary.NullTypes.StringNT ControlloInlocoEsitoEqualThis,
SiarLibrary.NullTypes.StringNT VerificaPagamentiEsitoEqualThis, SiarLibrary.NullTypes.StringNT VerificaPagamentiMessaggioEqualThis, SiarLibrary.NullTypes.DatetimeNT VerificaPagamentiDataEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataPredisposizioneAControlloEqualThis, SiarLibrary.NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis,
SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis,
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

        {

            DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionObj = new DomandaDiPagamentoModificheCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandadipagamentomodifichefindselect", new string[] {"IdDomandaPagamentoequalthis", "CodTipoequalthis", "IdProgettoequalthis",
"DataInserimentoequalthis", "DataModificaequalthis", "CodEnteequalthis",
"Segnaturaequalthis", "Descrizioneequalthis", "CodFaseequalthis",
"Faseequalthis", "Ordineequalthis", "IdFidejussioneequalthis",
"Operatoreequalthis", "CfOperatoreequalthis", "SegnaturaAllegatiequalthis",
"DataCertificazioneAntimafiaequalthis", "Approvataequalthis", "SegnaturaApprovazioneequalthis",
"CfIstruttoreequalthis", "DataApprovazioneequalthis", "SegnaturaSecondaApprovazioneequalthis",
"Annullataequalthis", "SegnaturaAnnullamentoequalthis", "CfOperatoreAnnullamentoequalthis",
"DataAnnullamentoequalthis", "ValiditaVersioneAdcequalthis", "IdVariazioneAccertataequalthis",
"PredispostaAControlloequalthis", "VisitaInsituEsitoequalthis", "ControlloInlocoEsitoequalthis",
"VerificaPagamentiEsitoequalthis", "VerificaPagamentiMessaggioequalthis", "VerificaPagamentiDataequalthis",
"DataPredisposizioneAControlloequalthis", "NominativoOperatoreAnnullamentoequalthis", "Istruttoreequalthis",
"FirmaPredispostaequalthis", "InIntegrazioneequalthis", "FirmaPredispostaRupequalthis",
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "string", "int",
"DateTime", "DateTime", "string",
"string", "string", "string",
"string", "int", "int",
"string", "string", "string",
"DateTime", "bool", "string",
"string", "DateTime", "string",
"bool", "string", "string",
"DateTime", "bool", "int",
"bool", "string", "string",
"string", "string", "DateTime",
"DateTime", "string", "string",
"bool", "bool", "bool",
"int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Faseequalthis", FaseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFidejussioneequalthis", IdFidejussioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCertificazioneAntimafiaequalthis", DataCertificazioneAntimafiaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaApprovazioneequalthis", SegnaturaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfIstruttoreequalthis", CfIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaSecondaApprovazioneequalthis", SegnaturaSecondaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAnnullamentoequalthis", SegnaturaAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreAnnullamentoequalthis", CfOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValiditaVersioneAdcequalthis", ValiditaVersioneAdcEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVariazioneAccertataequalthis", IdVariazioneAccertataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PredispostaAControlloequalthis", PredispostaAControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VisitaInsituEsitoequalthis", VisitaInsituEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ControlloInlocoEsitoequalthis", ControlloInlocoEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiEsitoequalthis", VerificaPagamentiEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiMessaggioequalthis", VerificaPagamentiMessaggioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "VerificaPagamentiDataequalthis", VerificaPagamentiDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPredisposizioneAControlloequalthis", DataPredisposizioneAControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoOperatoreAnnullamentoequalthis", NominativoOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
            DomandaDiPagamentoModifiche DomandaDiPagamentoModificheObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaDiPagamentoModificheObj = GetFromDatareader(db);
                DomandaDiPagamentoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaDiPagamentoModificheObj.IsDirty = false;
                DomandaDiPagamentoModificheObj.IsPersistent = true;
                DomandaDiPagamentoModificheCollectionObj.Add(DomandaDiPagamentoModificheObj);
            }
            db.Close();
            return DomandaDiPagamentoModificheCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DomandaDiPagamentoModificheCollectionProvider:IDomandaDiPagamentoModificheProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaDiPagamentoModificheCollectionProvider : IDomandaDiPagamentoModificheProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DomandaDiPagamentoModifiche
        protected DomandaDiPagamentoModificheCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DomandaDiPagamentoModificheCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DomandaDiPagamentoModificheCollection(this);
        }

        //Costruttore3: ha in input domandadipagamentomodificheCollectionObj - non popola la collection
        public DomandaDiPagamentoModificheCollectionProvider(DomandaDiPagamentoModificheCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DomandaDiPagamentoModificheCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DomandaDiPagamentoModificheCollection(this);
        }

        //Get e Set
        public DomandaDiPagamentoModificheCollection CollectionObj
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
        public int SaveCollection(DomandaDiPagamentoModificheCollection collectionObj)
        {
            return DomandaDiPagamentoModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DomandaDiPagamentoModifiche domandadipagamentomodificheObj)
        {
            return DomandaDiPagamentoModificheDAL.Save(_dbProviderObj, domandadipagamentomodificheObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DomandaDiPagamentoModificheCollection collectionObj)
        {
            return DomandaDiPagamentoModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DomandaDiPagamentoModifiche domandadipagamentomodificheObj)
        {
            return DomandaDiPagamentoModificheDAL.Delete(_dbProviderObj, domandadipagamentomodificheObj);
        }

        //getById
        public DomandaDiPagamentoModifiche GetById(IntNT IdValue)
        {
            DomandaDiPagamentoModifiche DomandaDiPagamentoModificheTemp = DomandaDiPagamentoModificheDAL.GetById(_dbProviderObj, IdValue);
            if (DomandaDiPagamentoModificheTemp != null) DomandaDiPagamentoModificheTemp.Provider = this;
            return DomandaDiPagamentoModificheTemp;
        }

        //Select: popola la collection
        public DomandaDiPagamentoModificheCollection Select(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, IntNT IdprogettoEqualThis,
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CodenteEqualThis,
StringNT SegnaturaEqualThis, StringNT DescrizioneEqualThis, StringNT CodfaseEqualThis,
StringNT FaseEqualThis, IntNT OrdineEqualThis, IntNT IdfidejussioneEqualThis,
StringNT OperatoreEqualThis, StringNT CfoperatoreEqualThis, StringNT SegnaturaallegatiEqualThis,
DatetimeNT DatacertificazioneantimafiaEqualThis, BoolNT ApprovataEqualThis, StringNT SegnaturaapprovazioneEqualThis,
StringNT CfistruttoreEqualThis, DatetimeNT DataapprovazioneEqualThis, StringNT SegnaturasecondaapprovazioneEqualThis,
BoolNT AnnullataEqualThis, StringNT SegnaturaannullamentoEqualThis, StringNT CfoperatoreannullamentoEqualThis,
DatetimeNT DataannullamentoEqualThis, BoolNT ValiditaversioneadcEqualThis, IntNT IdvariazioneaccertataEqualThis,
BoolNT PredispostaacontrolloEqualThis, StringNT VisitainsituesitoEqualThis, StringNT ControlloinlocoesitoEqualThis,
StringNT VerificapagamentiesitoEqualThis, StringNT VerificapagamentimessaggioEqualThis, DatetimeNT VerificapagamentidataEqualThis,
DatetimeNT DatapredisposizioneacontrolloEqualThis, StringNT NominativooperatoreannullamentoEqualThis, StringNT IstruttoreEqualThis,
BoolNT FirmapredispostaEqualThis, BoolNT InintegrazioneEqualThis, BoolNT FirmapredispostarupEqualThis,
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
        {
            DomandaDiPagamentoModificheCollection DomandaDiPagamentoModificheCollectionTemp = DomandaDiPagamentoModificheDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, CodtipoEqualThis, IdprogettoEqualThis,
DatainserimentoEqualThis, DatamodificaEqualThis, CodenteEqualThis,
SegnaturaEqualThis, DescrizioneEqualThis, CodfaseEqualThis,
FaseEqualThis, OrdineEqualThis, IdfidejussioneEqualThis,
OperatoreEqualThis, CfoperatoreEqualThis, SegnaturaallegatiEqualThis,
DatacertificazioneantimafiaEqualThis, ApprovataEqualThis, SegnaturaapprovazioneEqualThis,
CfistruttoreEqualThis, DataapprovazioneEqualThis, SegnaturasecondaapprovazioneEqualThis,
AnnullataEqualThis, SegnaturaannullamentoEqualThis, CfoperatoreannullamentoEqualThis,
DataannullamentoEqualThis, ValiditaversioneadcEqualThis, IdvariazioneaccertataEqualThis,
PredispostaacontrolloEqualThis, VisitainsituesitoEqualThis, ControlloinlocoesitoEqualThis,
VerificapagamentiesitoEqualThis, VerificapagamentimessaggioEqualThis, VerificapagamentidataEqualThis,
DatapredisposizioneacontrolloEqualThis, NominativooperatoreannullamentoEqualThis, IstruttoreEqualThis,
FirmapredispostaEqualThis, InintegrazioneEqualThis, FirmapredispostarupEqualThis,
IdEqualThis, IdmodificaEqualThis);
            DomandaDiPagamentoModificheCollectionTemp.Provider = this;
            return DomandaDiPagamentoModificheCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO_MODIFICHE>
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
</DOMANDA_DI_PAGAMENTO_MODIFICHE>
*/
