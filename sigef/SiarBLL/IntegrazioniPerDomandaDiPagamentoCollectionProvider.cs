using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per IntegrazioniPerDomandaDiPagamento
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IIntegrazioniPerDomandaDiPagamentoProvider
    {
        int Save(IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj);
        int SaveCollection(IntegrazioniPerDomandaDiPagamentoCollection collectionObj);
        int Delete(IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj);
        int DeleteCollection(IntegrazioniPerDomandaDiPagamentoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for IntegrazioniPerDomandaDiPagamento
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class IntegrazioniPerDomandaDiPagamento : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdIntegrazioneDomandaDiPagamento;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _IstanzaDomandaPagamento;
        private NullTypes.BoolNT _IntegrazioneCompleta;
        private NullTypes.StringNT _NoteIntegrazioneDomanda;
        private NullTypes.StringNT _CfIstruttore;
        private NullTypes.DatetimeNT _DataRichiestaIntegrazioneDomanda;
        private NullTypes.StringNT _SegnaturaIstruttore;
        private NullTypes.StringNT _CfBenficiario;
        private NullTypes.StringNT _SegnaturaBeneficiario;
        private NullTypes.DatetimeNT _DataConclusioneIntegrazione;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.DatetimeNT _DataInserimentoDomanda;
        private NullTypes.StringNT _CfOperatoreDomanda;
        private NullTypes.DatetimeNT _DataModificaDomanda;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.StringNT _SegnaturaAllegati;
        private NullTypes.IntNT _IdFidejussione;
        private NullTypes.DatetimeNT _DataCertificazioneAntimafia;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.StringNT _SegnaturaApprovazione;
        private NullTypes.StringNT _SegnaturaSecondaApprovazione;
        private NullTypes.StringNT _CfIstruttoreDomanda;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.StringNT _ValutazioneIstruttore;
        private NullTypes.BoolNT _Annullata;
        private NullTypes.StringNT _SegnaturaAnnullamento;
        private NullTypes.StringNT _CfOperatoreAnnullamento;
        private NullTypes.DatetimeNT _DataAnnullamento;
        private NullTypes.BoolNT _ValiditaVersioneAdc;
        private NullTypes.IntNT _IdVariazioneAccertata;
        private NullTypes.BoolNT _PredispostaAControllo;
        private NullTypes.DatetimeNT _DataPredisposizioneAControllo;
        private NullTypes.StringNT _VisitaInsituEsito;
        private NullTypes.StringNT _VisitaInsituNote;
        private NullTypes.StringNT _ControlloInlocoEsito;
        private NullTypes.StringNT _ControlloInlocoNote;
        private NullTypes.StringNT _VerificaPagamentiEsito;
        private NullTypes.StringNT _VerificaPagamentiMessaggio;
        private NullTypes.DatetimeNT _VerificaPagamentiData;
        private NullTypes.BoolNT _FirmaPredisposta;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.IntNT _IdDomandaPagamentoDomanda;
        [NonSerialized]
        private IIntegrazioniPerDomandaDiPagamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IIntegrazioniPerDomandaDiPagamentoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public IntegrazioniPerDomandaDiPagamento()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIntegrazioneDomandaDiPagamento
        {
            get { return _IdIntegrazioneDomandaDiPagamento; }
            set
            {
                if (IdIntegrazioneDomandaDiPagamento != value)
                {
                    _IdIntegrazioneDomandaDiPagamento = value;
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
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
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
        /// Corrisponde al campo:ISTANZA_DOMANDA_PAGAMENTO
        /// Tipo sul db:XML
        /// </summary>
        public NullTypes.StringNT IstanzaDomandaPagamento
        {
            get { return _IstanzaDomandaPagamento; }
            set
            {
                if (IstanzaDomandaPagamento != value)
                {
                    _IstanzaDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INTEGRAZIONE_COMPLETA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT IntegrazioneCompleta
        {
            get { return _IntegrazioneCompleta; }
            set
            {
                if (IntegrazioneCompleta != value)
                {
                    _IntegrazioneCompleta = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE_INTEGRAZIONE_DOMANDA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT NoteIntegrazioneDomanda
        {
            get { return _NoteIntegrazioneDomanda; }
            set
            {
                if (NoteIntegrazioneDomanda != value)
                {
                    _NoteIntegrazioneDomanda = value;
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
        /// Corrisponde al campo:DATA_RICHIESTA_INTEGRAZIONE_DOMANDA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRichiestaIntegrazioneDomanda
        {
            get { return _DataRichiestaIntegrazioneDomanda; }
            set
            {
                if (DataRichiestaIntegrazioneDomanda != value)
                {
                    _DataRichiestaIntegrazioneDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_ISTRUTTORE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaIstruttore
        {
            get { return _SegnaturaIstruttore; }
            set
            {
                if (SegnaturaIstruttore != value)
                {
                    _SegnaturaIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_BENFICIARIO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfBenficiario
        {
            get { return _CfBenficiario; }
            set
            {
                if (CfBenficiario != value)
                {
                    _CfBenficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_BENEFICIARIO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaBeneficiario
        {
            get { return _SegnaturaBeneficiario; }
            set
            {
                if (SegnaturaBeneficiario != value)
                {
                    _SegnaturaBeneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CONCLUSIONE_INTEGRAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataConclusioneIntegrazione
        {
            get { return _DataConclusioneIntegrazione; }
            set
            {
                if (DataConclusioneIntegrazione != value)
                {
                    _DataConclusioneIntegrazione = value;
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
        /// Corrisponde al campo:DATA_INSERIMENTO_DOMANDA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInserimentoDomanda
        {
            get { return _DataInserimentoDomanda; }
            set
            {
                if (DataInserimentoDomanda != value)
                {
                    _DataInserimentoDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_OPERATORE_DOMANDA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfOperatoreDomanda
        {
            get { return _CfOperatoreDomanda; }
            set
            {
                if (CfOperatoreDomanda != value)
                {
                    _CfOperatoreDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA_DOMANDA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataModificaDomanda
        {
            get { return _DataModificaDomanda; }
            set
            {
                if (DataModificaDomanda != value)
                {
                    _DataModificaDomanda = value;
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
        /// Corrisponde al campo:CF_ISTRUTTORE_DOMANDA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfIstruttoreDomanda
        {
            get { return _CfIstruttoreDomanda; }
            set
            {
                if (CfIstruttoreDomanda != value)
                {
                    _CfIstruttoreDomanda = value;
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
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_DOMANDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamentoDomanda
        {
            get { return _IdDomandaPagamentoDomanda; }
            set
            {
                if (IdDomandaPagamentoDomanda != value)
                {
                    _IdDomandaPagamentoDomanda = value;
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
    /// Summary description for IntegrazioniPerDomandaDiPagamentoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class IntegrazioniPerDomandaDiPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private IntegrazioniPerDomandaDiPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((IntegrazioniPerDomandaDiPagamento)info.GetValue(i.ToString(), typeof(IntegrazioniPerDomandaDiPagamento)));
            }
        }

        //Costruttore
        public IntegrazioniPerDomandaDiPagamentoCollection()
        {
            this.ItemType = typeof(IntegrazioniPerDomandaDiPagamento);
        }

        //Costruttore con provider
        public IntegrazioniPerDomandaDiPagamentoCollection(IIntegrazioniPerDomandaDiPagamentoProvider providerObj)
        {
            this.ItemType = typeof(IntegrazioniPerDomandaDiPagamento);
            this.Provider = providerObj;
        }

        //Get e Set
        public new IntegrazioniPerDomandaDiPagamento this[int index]
        {
            get { return (IntegrazioniPerDomandaDiPagamento)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new IntegrazioniPerDomandaDiPagamentoCollection GetChanges()
        {
            return (IntegrazioniPerDomandaDiPagamentoCollection)base.GetChanges();
        }

        [NonSerialized]
        private IIntegrazioniPerDomandaDiPagamentoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IIntegrazioniPerDomandaDiPagamentoProvider Provider
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
        public int Add(IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            if (IntegrazioniPerDomandaDiPagamentoObj.Provider == null) IntegrazioniPerDomandaDiPagamentoObj.Provider = this.Provider;
            return base.Add(IntegrazioniPerDomandaDiPagamentoObj);
        }

        //AddCollection
        public void AddCollection(IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionObj)
        {
            foreach (IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj in IntegrazioniPerDomandaDiPagamentoCollectionObj)
                this.Add(IntegrazioniPerDomandaDiPagamentoObj);
        }

        //Insert
        public void Insert(int index, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            if (IntegrazioniPerDomandaDiPagamentoObj.Provider == null) IntegrazioniPerDomandaDiPagamentoObj.Provider = this.Provider;
            base.Insert(index, IntegrazioniPerDomandaDiPagamentoObj);
        }

        //CollectionGetById
        public IntegrazioniPerDomandaDiPagamento CollectionGetById(NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdIntegrazioneDomandaDiPagamento == IdIntegrazioneDomandaDiPagamentoValue))
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
        public IntegrazioniPerDomandaDiPagamentoCollection SubSelect(NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.BoolNT IntegrazioneCompletaEqualThis, NullTypes.StringNT NoteIntegrazioneDomandaEqualThis,
NullTypes.StringNT CfIstruttoreEqualThis, NullTypes.DatetimeNT DataRichiestaIntegrazioneDomandaEqualThis, NullTypes.StringNT SegnaturaIstruttoreEqualThis,
NullTypes.StringNT CfBenficiarioEqualThis, NullTypes.StringNT SegnaturaBeneficiarioEqualThis, NullTypes.DatetimeNT DataConclusioneIntegrazioneEqualThis)
        {
            IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionTemp = new IntegrazioniPerDomandaDiPagamentoCollection();
            foreach (IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoItem in this)
            {
                if (((IdIntegrazioneDomandaDiPagamentoEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.IdIntegrazioneDomandaDiPagamento != null) && (IntegrazioniPerDomandaDiPagamentoItem.IdIntegrazioneDomandaDiPagamento.Value == IdIntegrazioneDomandaDiPagamentoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.IdDomandaPagamento != null) && (IntegrazioniPerDomandaDiPagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.DataInserimento != null) && (IntegrazioniPerDomandaDiPagamentoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.DataModifica != null) && (IntegrazioniPerDomandaDiPagamentoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IntegrazioneCompletaEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.IntegrazioneCompleta != null) && (IntegrazioniPerDomandaDiPagamentoItem.IntegrazioneCompleta.Value == IntegrazioneCompletaEqualThis.Value))) && ((NoteIntegrazioneDomandaEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.NoteIntegrazioneDomanda != null) && (IntegrazioniPerDomandaDiPagamentoItem.NoteIntegrazioneDomanda.Value == NoteIntegrazioneDomandaEqualThis.Value))) &&
((CfIstruttoreEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.CfIstruttore != null) && (IntegrazioniPerDomandaDiPagamentoItem.CfIstruttore.Value == CfIstruttoreEqualThis.Value))) && ((DataRichiestaIntegrazioneDomandaEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.DataRichiestaIntegrazioneDomanda != null) && (IntegrazioniPerDomandaDiPagamentoItem.DataRichiestaIntegrazioneDomanda.Value == DataRichiestaIntegrazioneDomandaEqualThis.Value))) && ((SegnaturaIstruttoreEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.SegnaturaIstruttore != null) && (IntegrazioniPerDomandaDiPagamentoItem.SegnaturaIstruttore.Value == SegnaturaIstruttoreEqualThis.Value))) &&
((CfBenficiarioEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.CfBenficiario != null) && (IntegrazioniPerDomandaDiPagamentoItem.CfBenficiario.Value == CfBenficiarioEqualThis.Value))) && ((SegnaturaBeneficiarioEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.SegnaturaBeneficiario != null) && (IntegrazioniPerDomandaDiPagamentoItem.SegnaturaBeneficiario.Value == SegnaturaBeneficiarioEqualThis.Value))) && ((DataConclusioneIntegrazioneEqualThis == null) || ((IntegrazioniPerDomandaDiPagamentoItem.DataConclusioneIntegrazione != null) && (IntegrazioniPerDomandaDiPagamentoItem.DataConclusioneIntegrazione.Value == DataConclusioneIntegrazioneEqualThis.Value))))
                {
                    IntegrazioniPerDomandaDiPagamentoCollectionTemp.Add(IntegrazioniPerDomandaDiPagamentoItem);
                }
            }
            return IntegrazioniPerDomandaDiPagamentoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for IntegrazioniPerDomandaDiPagamentoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class IntegrazioniPerDomandaDiPagamentoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdIntegrazioneDomandaDiPagamento", IntegrazioniPerDomandaDiPagamentoObj.IdIntegrazioneDomandaDiPagamento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", IntegrazioniPerDomandaDiPagamentoObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", IntegrazioniPerDomandaDiPagamentoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", IntegrazioniPerDomandaDiPagamentoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IstanzaDomandaPagamento", IntegrazioniPerDomandaDiPagamentoObj.IstanzaDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IntegrazioneCompleta", IntegrazioniPerDomandaDiPagamentoObj.IntegrazioneCompleta);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteIntegrazioneDomanda", IntegrazioniPerDomandaDiPagamentoObj.NoteIntegrazioneDomanda);
            DbProvider.SetCmdParam(cmd, firstChar + "CfIstruttore", IntegrazioniPerDomandaDiPagamentoObj.CfIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRichiestaIntegrazioneDomanda", IntegrazioniPerDomandaDiPagamentoObj.DataRichiestaIntegrazioneDomanda);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaIstruttore", IntegrazioniPerDomandaDiPagamentoObj.SegnaturaIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "CfBenficiario", IntegrazioniPerDomandaDiPagamentoObj.CfBenficiario);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaBeneficiario", IntegrazioniPerDomandaDiPagamentoObj.SegnaturaBeneficiario);
            DbProvider.SetCmdParam(cmd, firstChar + "DataConclusioneIntegrazione", IntegrazioniPerDomandaDiPagamentoObj.DataConclusioneIntegrazione);
        }
        //Insert
        private static int Insert(DbProvider db, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoInsert", new string[] {"IdDomandaPagamento", "DataInserimento", 
"DataModifica", "IstanzaDomandaPagamento", "IntegrazioneCompleta", 
"NoteIntegrazioneDomanda", "CfIstruttore", "DataRichiestaIntegrazioneDomanda", 
"SegnaturaIstruttore", "CfBenficiario", "SegnaturaBeneficiario", 
"DataConclusioneIntegrazione", 









}, new string[] {"int", "DateTime", 
"DateTime", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"DateTime", 









}, "");
                CompileIUCmd(false, insertCmd, IntegrazioniPerDomandaDiPagamentoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    IntegrazioniPerDomandaDiPagamentoObj.IdIntegrazioneDomandaDiPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO"]);
                    IntegrazioniPerDomandaDiPagamentoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    IntegrazioniPerDomandaDiPagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    IntegrazioniPerDomandaDiPagamentoObj.IntegrazioneCompleta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTEGRAZIONE_COMPLETA"]);
                }
                IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
                IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoUpdate", new string[] {"IdIntegrazioneDomandaDiPagamento", "IdDomandaPagamento", "DataInserimento", 
"DataModifica", "IstanzaDomandaPagamento", "IntegrazioneCompleta", 
"NoteIntegrazioneDomanda", "CfIstruttore", "DataRichiestaIntegrazioneDomanda", 
"SegnaturaIstruttore", "CfBenficiario", "SegnaturaBeneficiario", 
"DataConclusioneIntegrazione", 









}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"DateTime", 









}, "");
                CompileIUCmd(true, updateCmd, IntegrazioniPerDomandaDiPagamentoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    IntegrazioniPerDomandaDiPagamentoObj.DataModifica = d;
                }
                IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
                IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            switch (IntegrazioniPerDomandaDiPagamentoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, IntegrazioniPerDomandaDiPagamentoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, IntegrazioniPerDomandaDiPagamentoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, IntegrazioniPerDomandaDiPagamentoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoUpdate", new string[] {"IdIntegrazioneDomandaDiPagamento", "IdDomandaPagamento", "DataInserimento", 
"DataModifica", "IstanzaDomandaPagamento", "IntegrazioneCompleta", 
"NoteIntegrazioneDomanda", "CfIstruttore", "DataRichiestaIntegrazioneDomanda", 
"SegnaturaIstruttore", "CfBenficiario", "SegnaturaBeneficiario", 
"DataConclusioneIntegrazione", 









}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"DateTime", 









}, "");
                IDbCommand insertCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoInsert", new string[] {"IdDomandaPagamento", "DataInserimento", 
"DataModifica", "IstanzaDomandaPagamento", "IntegrazioneCompleta", 
"NoteIntegrazioneDomanda", "CfIstruttore", "DataRichiestaIntegrazioneDomanda", 
"SegnaturaIstruttore", "CfBenficiario", "SegnaturaBeneficiario", 
"DataConclusioneIntegrazione", 









}, new string[] {"int", "DateTime", 
"DateTime", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"DateTime", 









}, "");
                IDbCommand deleteCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoDelete", new string[] { "IdIntegrazioneDomandaDiPagamento" }, new string[] { "int" }, "");
                for (int i = 0; i < IntegrazioniPerDomandaDiPagamentoCollectionObj.Count; i++)
                {
                    switch (IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, IntegrazioniPerDomandaDiPagamentoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IdIntegrazioneDomandaDiPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO"]);
                                    IntegrazioniPerDomandaDiPagamentoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    IntegrazioniPerDomandaDiPagamentoCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IntegrazioneCompleta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTEGRAZIONE_COMPLETA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, IntegrazioniPerDomandaDiPagamentoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    IntegrazioniPerDomandaDiPagamentoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamento", (SiarLibrary.NullTypes.IntNT)IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IdIntegrazioneDomandaDiPagamento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < IntegrazioniPerDomandaDiPagamentoCollectionObj.Count; i++)
                {
                    if ((IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsPersistent = true;
                    }
                    if ((IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj)
        {
            int returnValue = 0;
            if (IntegrazioniPerDomandaDiPagamentoObj.IsPersistent)
            {
                returnValue = Delete(db, IntegrazioniPerDomandaDiPagamentoObj.IdIntegrazioneDomandaDiPagamento);
            }
            IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
            IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdIntegrazioneDomandaDiPagamentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoDelete", new string[] { "IdIntegrazioneDomandaDiPagamento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamento", (SiarLibrary.NullTypes.IntNT)IdIntegrazioneDomandaDiPagamentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoDelete", new string[] { "IdIntegrazioneDomandaDiPagamento" }, new string[] { "int" }, "");
                for (int i = 0; i < IntegrazioniPerDomandaDiPagamentoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamento", IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IdIntegrazioneDomandaDiPagamento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < IntegrazioniPerDomandaDiPagamentoCollectionObj.Count; i++)
                {
                    if ((IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsDirty = false;
                        IntegrazioniPerDomandaDiPagamentoCollectionObj[i].IsPersistent = false;
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
        public static IntegrazioniPerDomandaDiPagamento GetById(DbProvider db, int IdIntegrazioneDomandaDiPagamentoValue)
        {
            IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj = null;
            IDbCommand readCmd = db.InitCmd("ZIntegrazioniPerDomandaDiPagamentoGetById", new string[] { "IdIntegrazioneDomandaDiPagamento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamento", (SiarLibrary.NullTypes.IntNT)IdIntegrazioneDomandaDiPagamentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                IntegrazioniPerDomandaDiPagamentoObj = GetFromDatareader(db);
                IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
                IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
            }
            db.Close();
            return IntegrazioniPerDomandaDiPagamentoObj;
        }

        //getFromDatareader
        public static IntegrazioniPerDomandaDiPagamento GetFromDatareader(DbProvider db)
        {
            IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj = new IntegrazioniPerDomandaDiPagamento();
            IntegrazioniPerDomandaDiPagamentoObj.IdIntegrazioneDomandaDiPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            IntegrazioniPerDomandaDiPagamentoObj.IstanzaDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_DOMANDA_PAGAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.IntegrazioneCompleta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTEGRAZIONE_COMPLETA"]);
            IntegrazioniPerDomandaDiPagamentoObj.NoteIntegrazioneDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_INTEGRAZIONE_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataRichiestaIntegrazioneDomanda = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_INTEGRAZIONE_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ISTRUTTORE"]);
            IntegrazioniPerDomandaDiPagamentoObj.CfBenficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_BENFICIARIO"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_BENEFICIARIO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataConclusioneIntegrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE_INTEGRAZIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            IntegrazioniPerDomandaDiPagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataInserimentoDomanda = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.CfOperatoreDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataModificaDomanda = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            IntegrazioniPerDomandaDiPagamentoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            IntegrazioniPerDomandaDiPagamentoObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataCertificazioneAntimafia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_ANTIMAFIA"]);
            IntegrazioniPerDomandaDiPagamentoObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaSecondaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.CfIstruttoreDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.ValutazioneIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_ISTRUTTORE"]);
            IntegrazioniPerDomandaDiPagamentoObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            IntegrazioniPerDomandaDiPagamentoObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
            IntegrazioniPerDomandaDiPagamentoObj.ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
            IntegrazioniPerDomandaDiPagamentoObj.IdVariazioneAccertata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIAZIONE_ACCERTATA"]);
            IntegrazioniPerDomandaDiPagamentoObj.PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
            IntegrazioniPerDomandaDiPagamentoObj.DataPredisposizioneAControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PREDISPOSIZIONE_A_CONTROLLO"]);
            IntegrazioniPerDomandaDiPagamentoObj.VisitaInsituEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_ESITO"]);
            IntegrazioniPerDomandaDiPagamentoObj.VisitaInsituNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_NOTE"]);
            IntegrazioniPerDomandaDiPagamentoObj.ControlloInlocoEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_ESITO"]);
            IntegrazioniPerDomandaDiPagamentoObj.ControlloInlocoNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_NOTE"]);
            IntegrazioniPerDomandaDiPagamentoObj.VerificaPagamentiEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_ESITO"]);
            IntegrazioniPerDomandaDiPagamentoObj.VerificaPagamentiMessaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_MESSAGGIO"]);
            IntegrazioniPerDomandaDiPagamentoObj.VerificaPagamentiData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VERIFICA_PAGAMENTI_DATA"]);
            IntegrazioniPerDomandaDiPagamentoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            IntegrazioniPerDomandaDiPagamentoObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            IntegrazioniPerDomandaDiPagamentoObj.IdDomandaPagamentoDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_DOMANDA"]);
            IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
            IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
            return IntegrazioniPerDomandaDiPagamentoObj;
        }

        //Find Select

        public static IntegrazioniPerDomandaDiPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis, SiarLibrary.NullTypes.StringNT NoteIntegrazioneDomandaEqualThis,
SiarLibrary.NullTypes.StringNT CfIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRichiestaIntegrazioneDomandaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaIstruttoreEqualThis,
SiarLibrary.NullTypes.StringNT CfBenficiarioEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaBeneficiarioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataConclusioneIntegrazioneEqualThis)
        {

            IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionObj = new IntegrazioniPerDomandaDiPagamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zintegrazioniperdomandadipagamentofindselect", new string[] {"IdIntegrazioneDomandaDiPagamentoequalthis", "IdDomandaPagamentoequalthis", "DataInserimentoequalthis", 
"DataModificaequalthis", "IntegrazioneCompletaequalthis", "NoteIntegrazioneDomandaequalthis", 
"CfIstruttoreequalthis", "DataRichiestaIntegrazioneDomandaequalthis", "SegnaturaIstruttoreequalthis", 
"CfBenficiarioequalthis", "SegnaturaBeneficiarioequalthis", "DataConclusioneIntegrazioneequalthis"}, new string[] {"int", "int", "DateTime", 
"DateTime", "bool", "string", 
"string", "DateTime", "string", 
"string", "string", "DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamentoequalthis", IdIntegrazioneDomandaDiPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NoteIntegrazioneDomandaequalthis", NoteIntegrazioneDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfIstruttoreequalthis", CfIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRichiestaIntegrazioneDomandaequalthis", DataRichiestaIntegrazioneDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaIstruttoreequalthis", SegnaturaIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfBenficiarioequalthis", CfBenficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaBeneficiarioequalthis", SegnaturaBeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataConclusioneIntegrazioneequalthis", DataConclusioneIntegrazioneEqualThis);
            IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                IntegrazioniPerDomandaDiPagamentoObj = GetFromDatareader(db);
                IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
                IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
                IntegrazioniPerDomandaDiPagamentoCollectionObj.Add(IntegrazioniPerDomandaDiPagamentoObj);
            }
            db.Close();
            return IntegrazioniPerDomandaDiPagamentoCollectionObj;
        }

        //Find Find

        public static IntegrazioniPerDomandaDiPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
        {

            IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionObj = new IntegrazioniPerDomandaDiPagamentoCollection();

            IDbCommand findCmd = db.InitCmd("Zintegrazioniperdomandadipagamentofindfind", new string[] {"IdIntegrazioneDomandaDiPagamentoequalthis", "IdDomandaPagamentoequalthis", "IntegrazioneCompletaequalthis", 
"IdProgettoequalthis"}, new string[] {"int", "int", "bool", 
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamentoequalthis", IdIntegrazioneDomandaDiPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                IntegrazioniPerDomandaDiPagamentoObj = GetFromDatareader(db);
                IntegrazioniPerDomandaDiPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                IntegrazioniPerDomandaDiPagamentoObj.IsDirty = false;
                IntegrazioniPerDomandaDiPagamentoObj.IsPersistent = true;
                IntegrazioniPerDomandaDiPagamentoCollectionObj.Add(IntegrazioniPerDomandaDiPagamentoObj);
            }
            db.Close();
            return IntegrazioniPerDomandaDiPagamentoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for IntegrazioniPerDomandaDiPagamentoCollectionProvider:IIntegrazioniPerDomandaDiPagamentoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class IntegrazioniPerDomandaDiPagamentoCollectionProvider : IIntegrazioniPerDomandaDiPagamentoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di IntegrazioniPerDomandaDiPagamento
        protected IntegrazioniPerDomandaDiPagamentoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new IntegrazioniPerDomandaDiPagamentoCollection(this);
        }

        //Costruttore 2: popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollectionProvider(IntNT IdintegrazionedomandadipagamentoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT IntegrazionecompletaEqualThis,
IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdintegrazionedomandadipagamentoEqualThis, IddomandapagamentoEqualThis, IntegrazionecompletaEqualThis,
IdprogettoEqualThis);
        }

        //Costruttore3: ha in input integrazioniperdomandadipagamentoCollectionObj - non popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollectionProvider(IntegrazioniPerDomandaDiPagamentoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new IntegrazioniPerDomandaDiPagamentoCollection(this);
        }

        //Get e Set
        public IntegrazioniPerDomandaDiPagamentoCollection CollectionObj
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
        public int SaveCollection(IntegrazioniPerDomandaDiPagamentoCollection collectionObj)
        {
            return IntegrazioniPerDomandaDiPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(IntegrazioniPerDomandaDiPagamento integrazioniperdomandadipagamentoObj)
        {
            return IntegrazioniPerDomandaDiPagamentoDAL.Save(_dbProviderObj, integrazioniperdomandadipagamentoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(IntegrazioniPerDomandaDiPagamentoCollection collectionObj)
        {
            return IntegrazioniPerDomandaDiPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(IntegrazioniPerDomandaDiPagamento integrazioniperdomandadipagamentoObj)
        {
            return IntegrazioniPerDomandaDiPagamentoDAL.Delete(_dbProviderObj, integrazioniperdomandadipagamentoObj);
        }

        //getById
        public IntegrazioniPerDomandaDiPagamento GetById(IntNT IdIntegrazioneDomandaDiPagamentoValue)
        {
            IntegrazioniPerDomandaDiPagamento IntegrazioniPerDomandaDiPagamentoTemp = IntegrazioniPerDomandaDiPagamentoDAL.GetById(_dbProviderObj, IdIntegrazioneDomandaDiPagamentoValue);
            if (IntegrazioniPerDomandaDiPagamentoTemp != null) IntegrazioniPerDomandaDiPagamentoTemp.Provider = this;
            return IntegrazioniPerDomandaDiPagamentoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollection Select(IntNT IdintegrazionedomandadipagamentoEqualThis, IntNT IddomandapagamentoEqualThis, DatetimeNT DatainserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, BoolNT IntegrazionecompletaEqualThis, StringNT NoteintegrazionedomandaEqualThis,
StringNT CfistruttoreEqualThis, DatetimeNT DatarichiestaintegrazionedomandaEqualThis, StringNT SegnaturaistruttoreEqualThis,
StringNT CfbenficiarioEqualThis, StringNT SegnaturabeneficiarioEqualThis, DatetimeNT DataconclusioneintegrazioneEqualThis)
        {
            IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionTemp = IntegrazioniPerDomandaDiPagamentoDAL.Select(_dbProviderObj, IdintegrazionedomandadipagamentoEqualThis, IddomandapagamentoEqualThis, DatainserimentoEqualThis,
DatamodificaEqualThis, IntegrazionecompletaEqualThis, NoteintegrazionedomandaEqualThis,
CfistruttoreEqualThis, DatarichiestaintegrazionedomandaEqualThis, SegnaturaistruttoreEqualThis,
CfbenficiarioEqualThis, SegnaturabeneficiarioEqualThis, DataconclusioneintegrazioneEqualThis);
            IntegrazioniPerDomandaDiPagamentoCollectionTemp.Provider = this;
            return IntegrazioniPerDomandaDiPagamentoCollectionTemp;
        }

        //Find: popola la collection
        public IntegrazioniPerDomandaDiPagamentoCollection Find(IntNT IdintegrazionedomandadipagamentoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT IntegrazionecompletaEqualThis,
IntNT IdprogettoEqualThis)
        {
            IntegrazioniPerDomandaDiPagamentoCollection IntegrazioniPerDomandaDiPagamentoCollectionTemp = IntegrazioniPerDomandaDiPagamentoDAL.Find(_dbProviderObj, IdintegrazionedomandadipagamentoEqualThis, IddomandapagamentoEqualThis, IntegrazionecompletaEqualThis,
IdprogettoEqualThis);
            IntegrazioniPerDomandaDiPagamentoCollectionTemp.Provider = this;
            return IntegrazioniPerDomandaDiPagamentoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO>
  <ViewName>VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO</ViewName>
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
      <ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO>Equal</ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <INTEGRAZIONE_COMPLETA>Equal</INTEGRAZIONE_COMPLETA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO>
*/
