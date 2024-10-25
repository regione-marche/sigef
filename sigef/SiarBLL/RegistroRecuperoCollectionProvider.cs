using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per RegistroRecupero
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IRegistroRecuperoProvider
    {
        int Save(RegistroRecupero RegistroRecuperoObj);
        int SaveCollection(RegistroRecuperoCollection collectionObj);
        int Delete(RegistroRecupero RegistroRecuperoObj);
        int DeleteCollection(RegistroRecuperoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for RegistroRecupero
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class RegistroRecupero : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdRegistroRecupero;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.IntNT _IdRegistroIrregolarita;
        private NullTypes.DatetimeNT _DataAvvio;
        private NullTypes.DatetimeNT _DataProbabileConclusione;
        private NullTypes.DecimalNT _ImportoDaRecuperareUe;
        private NullTypes.DecimalNT _ImportoDaRecuperareNazionale;
        private NullTypes.DecimalNT _ImportoDaRecuperarePubblico;
        private NullTypes.DecimalNT _ImportoDetrattoUe;
        private NullTypes.DecimalNT _ImportoDetrattoNazionale;
        private NullTypes.DecimalNT _ImportoDetrattoPubblico;
        private NullTypes.DecimalNT _ImportoRecuperatoUe;
        private NullTypes.DecimalNT _ImportoRecuperatoPubblico;
        private NullTypes.DecimalNT _ImportoRecuperatoNazionale;
        private NullTypes.DecimalNT _SaldoDaRecuperareUe;
        private NullTypes.DecimalNT _SaldoDaRecuperareNazionale;
        private NullTypes.DecimalNT _SaldoDaRecuperarePubblico;
        private NullTypes.DecimalNT _ImportoVersatoUe;
        private NullTypes.DecimalNT _ImportoRitenutoStato;
        private NullTypes.DatetimeNT _DataConclusione;
        private NullTypes.IntNT _IdProcedureAvviate;
        private NullTypes.IntNT _IdTipoProcedureAvviate;
        private NullTypes.DatetimeNT _DataAvvioProcedure;
        private NullTypes.DatetimeNT _DataProbabileConclusioneProcedure;
        private NullTypes.IntNT _IdTipoRecupero;
        private NullTypes.IntNT _IdOrigineRecupero;
        private NullTypes.IntNT _IdStoricoRecuperoPrecedente;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdBando;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _CodAgea;
        private NullTypes.StringNT _SegnaturaAllegati;
        private NullTypes.IntNT _IdProgIntegrato;
        private NullTypes.BoolNT _FlagPreadesione;
        private NullTypes.BoolNT _FlagDefinitivo;
        private NullTypes.IntNT _IdFascicolo;
        private NullTypes.StringNT _ProvinciaDiPresentazione;
        private NullTypes.BoolNT _SelezionataXRevisione;
        private NullTypes.IntNT _IdStoricoUltimo;
        private NullTypes.DatetimeNT _DataCreazione;
        private NullTypes.IntNT _OperatoreCreazione;
        private NullTypes.BoolNT _FirmaPredisposta;
        private NullTypes.BoolNT _Storico;
        private NullTypes.DecimalNT _ImportoInteressiLegali;
        private NullTypes.DecimalNT _ImportoInteressiMora;
        private NullTypes.DecimalNT _ImportoGestionePratica;
        private NullTypes.DatetimeNT _DataRegistrazioneRitiro;
        private NullTypes.DatetimeNT _DataCertificazioneRecupero;
        private NullTypes.DatetimeNT _DataCertificazioneRitiro;
        private NullTypes.BoolNT _GestioneRate;
        private NullTypes.IntNT _NumeroRate;
        private NullTypes.DatetimeNT _DataInizioRate;
        private NullTypes.DecimalNT _ImportoRata;
        private NullTypes.IntNT _IntervalloRateMesi;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.StringNT _Programmazione;
        private NullTypes.DecimalNT _ImportoDaRecuperarePrivato;
        private NullTypes.DecimalNT _ImportoDaRecuperareTotale;
        private NullTypes.DecimalNT _ImportoDetrattoPrivato;
        private NullTypes.DecimalNT _ImportoRecuperatoPrivato;
        private NullTypes.DecimalNT _ImportoRecuperatoTotale;
        private NullTypes.DecimalNT _SaldoDaRecuperarePrivato;
        private NullTypes.DecimalNT _SaldoDaRecuperareTotale;
        private NullTypes.StringNT _SoggettoRevocaFinanziamento;
        private NullTypes.IntNT _IdAttoRecupero;
        private NullTypes.IntNT _IdAttoRitiro;
        private NullTypes.IntNT _IdAttoNonRecuperabilita;
        private NullTypes.BoolNT _Recuperabile;
        private NullTypes.DecimalNT _ImportoDetrattoTotale;
        private NullTypes.DatetimeNT _DataCertificazioneNonRecuperabilita;
        private NullTypes.DatetimeNT _DataRegistrazioneNonRecuperabilita;
        private NullTypes.StringNT _CodAsse;
        private NullTypes.StringNT _DescAzione;
        private NullTypes.DatetimeNT _DataSegnatura;
        private NullTypes.StringNT _Segnatura;
        [NonSerialized]
        private IRegistroRecuperoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroRecuperoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public RegistroRecupero()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_REGISTRO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRegistroRecupero
        {
            get { return _IdRegistroRecupero; }
            set
            {
                if (IdRegistroRecupero != value)
                {
                    _IdRegistroRecupero = value;
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
        /// Corrisponde al campo:ID_REGISTRO_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRegistroIrregolarita
        {
            get { return _IdRegistroIrregolarita; }
            set
            {
                if (IdRegistroIrregolarita != value)
                {
                    _IdRegistroIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_AVVIO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAvvio
        {
            get { return _DataAvvio; }
            set
            {
                if (DataAvvio != value)
                {
                    _DataAvvio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PROBABILE_CONCLUSIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataProbabileConclusione
        {
            get { return _DataProbabileConclusione; }
            set
            {
                if (DataProbabileConclusione != value)
                {
                    _DataProbabileConclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DA_RECUPERARE_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDaRecuperareUe
        {
            get { return _ImportoDaRecuperareUe; }
            set
            {
                if (ImportoDaRecuperareUe != value)
                {
                    _ImportoDaRecuperareUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DA_RECUPERARE_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDaRecuperareNazionale
        {
            get { return _ImportoDaRecuperareNazionale; }
            set
            {
                if (ImportoDaRecuperareNazionale != value)
                {
                    _ImportoDaRecuperareNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DA_RECUPERARE_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDaRecuperarePubblico
        {
            get { return _ImportoDaRecuperarePubblico; }
            set
            {
                if (ImportoDaRecuperarePubblico != value)
                {
                    _ImportoDaRecuperarePubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DETRATTO_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDetrattoUe
        {
            get { return _ImportoDetrattoUe; }
            set
            {
                if (ImportoDetrattoUe != value)
                {
                    _ImportoDetrattoUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DETRATTO_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDetrattoNazionale
        {
            get { return _ImportoDetrattoNazionale; }
            set
            {
                if (ImportoDetrattoNazionale != value)
                {
                    _ImportoDetrattoNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DETRATTO_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDetrattoPubblico
        {
            get { return _ImportoDetrattoPubblico; }
            set
            {
                if (ImportoDetrattoPubblico != value)
                {
                    _ImportoDetrattoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperatoUe
        {
            get { return _ImportoRecuperatoUe; }
            set
            {
                if (ImportoRecuperatoUe != value)
                {
                    _ImportoRecuperatoUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperatoPubblico
        {
            get { return _ImportoRecuperatoPubblico; }
            set
            {
                if (ImportoRecuperatoPubblico != value)
                {
                    _ImportoRecuperatoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperatoNazionale
        {
            get { return _ImportoRecuperatoNazionale; }
            set
            {
                if (ImportoRecuperatoNazionale != value)
                {
                    _ImportoRecuperatoNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SALDO_DA_RECUPERARE_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SaldoDaRecuperareUe
        {
            get { return _SaldoDaRecuperareUe; }
            set
            {
                if (SaldoDaRecuperareUe != value)
                {
                    _SaldoDaRecuperareUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SALDO_DA_RECUPERARE_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SaldoDaRecuperareNazionale
        {
            get { return _SaldoDaRecuperareNazionale; }
            set
            {
                if (SaldoDaRecuperareNazionale != value)
                {
                    _SaldoDaRecuperareNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SALDO_DA_RECUPERARE_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SaldoDaRecuperarePubblico
        {
            get { return _SaldoDaRecuperarePubblico; }
            set
            {
                if (SaldoDaRecuperarePubblico != value)
                {
                    _SaldoDaRecuperarePubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_VERSATO_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoVersatoUe
        {
            get { return _ImportoVersatoUe; }
            set
            {
                if (ImportoVersatoUe != value)
                {
                    _ImportoVersatoUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RITENUTO_STATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRitenutoStato
        {
            get { return _ImportoRitenutoStato; }
            set
            {
                if (ImportoRitenutoStato != value)
                {
                    _ImportoRitenutoStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CONCLUSIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataConclusione
        {
            get { return _DataConclusione; }
            set
            {
                if (DataConclusione != value)
                {
                    _DataConclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROCEDURE_AVVIATE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProcedureAvviate
        {
            get { return _IdProcedureAvviate; }
            set
            {
                if (IdProcedureAvviate != value)
                {
                    _IdProcedureAvviate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_PROCEDURE_AVVIATE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoProcedureAvviate
        {
            get { return _IdTipoProcedureAvviate; }
            set
            {
                if (IdTipoProcedureAvviate != value)
                {
                    _IdTipoProcedureAvviate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_AVVIO_PROCEDURE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAvvioProcedure
        {
            get { return _DataAvvioProcedure; }
            set
            {
                if (DataAvvioProcedure != value)
                {
                    _DataAvvioProcedure = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PROBABILE_CONCLUSIONE_PROCEDURE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataProbabileConclusioneProcedure
        {
            get { return _DataProbabileConclusioneProcedure; }
            set
            {
                if (DataProbabileConclusioneProcedure != value)
                {
                    _DataProbabileConclusioneProcedure = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoRecupero
        {
            get { return _IdTipoRecupero; }
            set
            {
                if (IdTipoRecupero != value)
                {
                    _IdTipoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ORIGINE_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdOrigineRecupero
        {
            get { return _IdOrigineRecupero; }
            set
            {
                if (IdOrigineRecupero != value)
                {
                    _IdOrigineRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_RECUPERO_PRECEDENTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoRecuperoPrecedente
        {
            get { return _IdStoricoRecuperoPrecedente; }
            set
            {
                if (IdStoricoRecuperoPrecedente != value)
                {
                    _IdStoricoRecuperoPrecedente = value;
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
        /// Corrisponde al campo:COD_AGEA
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT CodAgea
        {
            get { return _CodAgea; }
            set
            {
                if (CodAgea != value)
                {
                    _CodAgea = value;
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
        /// Corrisponde al campo:ID_PROG_INTEGRATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgIntegrato
        {
            get { return _IdProgIntegrato; }
            set
            {
                if (IdProgIntegrato != value)
                {
                    _IdProgIntegrato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG_PREADESIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FlagPreadesione
        {
            get { return _FlagPreadesione; }
            set
            {
                if (FlagPreadesione != value)
                {
                    _FlagPreadesione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG_DEFINITIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FlagDefinitivo
        {
            get { return _FlagDefinitivo; }
            set
            {
                if (FlagDefinitivo != value)
                {
                    _FlagDefinitivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FASCICOLO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFascicolo
        {
            get { return _IdFascicolo; }
            set
            {
                if (IdFascicolo != value)
                {
                    _IdFascicolo = value;
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

        /// <summary>
        /// Corrisponde al campo:SELEZIONATA_X_REVISIONE
        /// Tipo sul db:BIT
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
        /// Corrisponde al campo:ID_STORICO_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoUltimo
        {
            get { return _IdStoricoUltimo; }
            set
            {
                if (IdStoricoUltimo != value)
                {
                    _IdStoricoUltimo = value;
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
        /// Corrisponde al campo:STORICO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Storico
        {
            get { return _Storico; }
            set
            {
                if (Storico != value)
                {
                    _Storico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_INTERESSI_LEGALI
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoInteressiLegali
        {
            get { return _ImportoInteressiLegali; }
            set
            {
                if (ImportoInteressiLegali != value)
                {
                    _ImportoInteressiLegali = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_INTERESSI_MORA
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoInteressiMora
        {
            get { return _ImportoInteressiMora; }
            set
            {
                if (ImportoInteressiMora != value)
                {
                    _ImportoInteressiMora = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_GESTIONE_PRATICA
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoGestionePratica
        {
            get { return _ImportoGestionePratica; }
            set
            {
                if (ImportoGestionePratica != value)
                {
                    _ImportoGestionePratica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_REGISTRAZIONE_RITIRO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRegistrazioneRitiro
        {
            get { return _DataRegistrazioneRitiro; }
            set
            {
                if (DataRegistrazioneRitiro != value)
                {
                    _DataRegistrazioneRitiro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CERTIFICAZIONE_RECUPERO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCertificazioneRecupero
        {
            get { return _DataCertificazioneRecupero; }
            set
            {
                if (DataCertificazioneRecupero != value)
                {
                    _DataCertificazioneRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CERTIFICAZIONE_RITIRO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCertificazioneRitiro
        {
            get { return _DataCertificazioneRitiro; }
            set
            {
                if (DataCertificazioneRitiro != value)
                {
                    _DataCertificazioneRitiro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:GESTIONE_RATE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT GestioneRate
        {
            get { return _GestioneRate; }
            set
            {
                if (GestioneRate != value)
                {
                    _GestioneRate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_RATE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumeroRate
        {
            get { return _NumeroRate; }
            set
            {
                if (NumeroRate != value)
                {
                    _NumeroRate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_RATE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioRate
        {
            get { return _DataInizioRate; }
            set
            {
                if (DataInizioRate != value)
                {
                    _DataInizioRate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RATA
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRata
        {
            get { return _ImportoRata; }
            set
            {
                if (ImportoRata != value)
                {
                    _ImportoRata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INTERVALLO_RATE_MESI
        /// Tipo sul db:INT
        /// Default:((1))
        /// </summary>
        public NullTypes.IntNT IntervalloRateMesi
        {
            get { return _IntervalloRateMesi; }
            set
            {
                if (IntervalloRateMesi != value)
                {
                    _IntervalloRateMesi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGRAMMAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazione
        {
            get { return _IdProgrammazione; }
            set
            {
                if (IdProgrammazione != value)
                {
                    _IdProgrammazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROGRAMMAZIONE
        /// Tipo sul db:VARCHAR(2030)
        /// </summary>
        public NullTypes.StringNT Programmazione
        {
            get { return _Programmazione; }
            set
            {
                if (Programmazione != value)
                {
                    _Programmazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DA_RECUPERARE_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDaRecuperarePrivato
        {
            get { return _ImportoDaRecuperarePrivato; }
            set
            {
                if (ImportoDaRecuperarePrivato != value)
                {
                    _ImportoDaRecuperarePrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DA_RECUPERARE_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDaRecuperareTotale
        {
            get { return _ImportoDaRecuperareTotale; }
            set
            {
                if (ImportoDaRecuperareTotale != value)
                {
                    _ImportoDaRecuperareTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DETRATTO_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDetrattoPrivato
        {
            get { return _ImportoDetrattoPrivato; }
            set
            {
                if (ImportoDetrattoPrivato != value)
                {
                    _ImportoDetrattoPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperatoPrivato
        {
            get { return _ImportoRecuperatoPrivato; }
            set
            {
                if (ImportoRecuperatoPrivato != value)
                {
                    _ImportoRecuperatoPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperatoTotale
        {
            get { return _ImportoRecuperatoTotale; }
            set
            {
                if (ImportoRecuperatoTotale != value)
                {
                    _ImportoRecuperatoTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SALDO_DA_RECUPERARE_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SaldoDaRecuperarePrivato
        {
            get { return _SaldoDaRecuperarePrivato; }
            set
            {
                if (SaldoDaRecuperarePrivato != value)
                {
                    _SaldoDaRecuperarePrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SALDO_DA_RECUPERARE_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SaldoDaRecuperareTotale
        {
            get { return _SaldoDaRecuperareTotale; }
            set
            {
                if (SaldoDaRecuperareTotale != value)
                {
                    _SaldoDaRecuperareTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SOGGETTO_REVOCA_FINANZIAMENTO
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT SoggettoRevocaFinanziamento
        {
            get { return _SoggettoRevocaFinanziamento; }
            set
            {
                if (SoggettoRevocaFinanziamento != value)
                {
                    _SoggettoRevocaFinanziamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoRecupero
        {
            get { return _IdAttoRecupero; }
            set
            {
                if (IdAttoRecupero != value)
                {
                    _IdAttoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_RITIRO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoRitiro
        {
            get { return _IdAttoRitiro; }
            set
            {
                if (IdAttoRitiro != value)
                {
                    _IdAttoRitiro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_NON_RECUPERABILITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoNonRecuperabilita
        {
            get { return _IdAttoNonRecuperabilita; }
            set
            {
                if (IdAttoNonRecuperabilita != value)
                {
                    _IdAttoNonRecuperabilita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RECUPERABILE
        /// Tipo sul db:BIT
        /// Default:((1))
        /// </summary>
        public NullTypes.BoolNT Recuperabile
        {
            get { return _Recuperabile; }
            set
            {
                if (Recuperabile != value)
                {
                    _Recuperabile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DETRATTO_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDetrattoTotale
        {
            get { return _ImportoDetrattoTotale; }
            set
            {
                if (ImportoDetrattoTotale != value)
                {
                    _ImportoDetrattoTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CERTIFICAZIONE_NON_RECUPERABILITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCertificazioneNonRecuperabilita
        {
            get { return _DataCertificazioneNonRecuperabilita; }
            set
            {
                if (DataCertificazioneNonRecuperabilita != value)
                {
                    _DataCertificazioneNonRecuperabilita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_REGISTRAZIONE_NON_RECUPERABILITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRegistrazioneNonRecuperabilita
        {
            get { return _DataRegistrazioneNonRecuperabilita; }
            set
            {
                if (DataRegistrazioneNonRecuperabilita != value)
                {
                    _DataRegistrazioneNonRecuperabilita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ASSE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT CodAsse
        {
            get { return _CodAsse; }
            set
            {
                if (CodAsse != value)
                {
                    _CodAsse = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESC_AZIONE
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT DescAzione
        {
            get { return _DescAzione; }
            set
            {
                if (DescAzione != value)
                {
                    _DescAzione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SEGNATURA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataSegnatura
        {
            get { return _DataSegnatura; }
            set
            {
                if (DataSegnatura != value)
                {
                    _DataSegnatura = value;
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
    /// Summary description for RegistroRecuperoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroRecuperoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private RegistroRecuperoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((RegistroRecupero)info.GetValue(i.ToString(), typeof(RegistroRecupero)));
            }
        }

        //Costruttore
        public RegistroRecuperoCollection()
        {
            this.ItemType = typeof(RegistroRecupero);
        }

        //Costruttore con provider
        public RegistroRecuperoCollection(IRegistroRecuperoProvider providerObj)
        {
            this.ItemType = typeof(RegistroRecupero);
            this.Provider = providerObj;
        }

        //Get e Set
        public new RegistroRecupero this[int index]
        {
            get { return (RegistroRecupero)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new RegistroRecuperoCollection GetChanges()
        {
            return (RegistroRecuperoCollection)base.GetChanges();
        }

        [NonSerialized]
        private IRegistroRecuperoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroRecuperoProvider Provider
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
        public int Add(RegistroRecupero RegistroRecuperoObj)
        {
            if (RegistroRecuperoObj.Provider == null) RegistroRecuperoObj.Provider = this.Provider;
            return base.Add(RegistroRecuperoObj);
        }

        //AddCollection
        public void AddCollection(RegistroRecuperoCollection RegistroRecuperoCollectionObj)
        {
            foreach (RegistroRecupero RegistroRecuperoObj in RegistroRecuperoCollectionObj)
                this.Add(RegistroRecuperoObj);
        }

        //Insert
        public void Insert(int index, RegistroRecupero RegistroRecuperoObj)
        {
            if (RegistroRecuperoObj.Provider == null) RegistroRecuperoObj.Provider = this.Provider;
            base.Insert(index, RegistroRecuperoObj);
        }

        //CollectionGetById
        public RegistroRecupero CollectionGetById(NullTypes.IntNT IdRegistroRecuperoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdRegistroRecupero == IdRegistroRecuperoValue))
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
        public RegistroRecuperoCollection SubSelect(NullTypes.IntNT IdRegistroRecuperoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdRegistroIrregolaritaEqualThis,
NullTypes.DatetimeNT DataAvvioEqualThis, NullTypes.DatetimeNT DataProbabileConclusioneEqualThis, NullTypes.DecimalNT ImportoDaRecuperareUeEqualThis,
NullTypes.DecimalNT ImportoDaRecuperareNazionaleEqualThis, NullTypes.DecimalNT ImportoDaRecuperarePubblicoEqualThis, NullTypes.DecimalNT ImportoDaRecuperarePrivatoEqualThis,
NullTypes.DecimalNT ImportoDaRecuperareTotaleEqualThis, NullTypes.DecimalNT ImportoDetrattoUeEqualThis, NullTypes.DecimalNT ImportoDetrattoNazionaleEqualThis,
NullTypes.DecimalNT ImportoDetrattoPubblicoEqualThis, NullTypes.DecimalNT ImportoDetrattoPrivatoEqualThis, NullTypes.DecimalNT ImportoDetrattoTotaleEqualThis,
NullTypes.DecimalNT ImportoRecuperatoUeEqualThis, NullTypes.DecimalNT ImportoRecuperatoNazionaleEqualThis, NullTypes.DecimalNT ImportoRecuperatoPubblicoEqualThis,
NullTypes.DecimalNT ImportoRecuperatoPrivatoEqualThis, NullTypes.DecimalNT ImportoRecuperatoTotaleEqualThis, NullTypes.DecimalNT SaldoDaRecuperareUeEqualThis,
NullTypes.DecimalNT SaldoDaRecuperareNazionaleEqualThis, NullTypes.DecimalNT SaldoDaRecuperarePubblicoEqualThis, NullTypes.DecimalNT SaldoDaRecuperarePrivatoEqualThis,
NullTypes.DecimalNT SaldoDaRecuperareTotaleEqualThis, NullTypes.DecimalNT ImportoVersatoUeEqualThis, NullTypes.DecimalNT ImportoRitenutoStatoEqualThis,
NullTypes.DecimalNT ImportoInteressiMoraEqualThis, NullTypes.DecimalNT ImportoInteressiLegaliEqualThis, NullTypes.DecimalNT ImportoGestionePraticaEqualThis,
NullTypes.DatetimeNT DataConclusioneEqualThis, NullTypes.IntNT IdProcedureAvviateEqualThis, NullTypes.IntNT IdTipoProcedureAvviateEqualThis,
NullTypes.DatetimeNT DataAvvioProcedureEqualThis, NullTypes.DatetimeNT DataProbabileConclusioneProcedureEqualThis, NullTypes.IntNT IdTipoRecuperoEqualThis,
NullTypes.IntNT IdOrigineRecuperoEqualThis, NullTypes.IntNT IdStoricoRecuperoPrecedenteEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.BoolNT StoricoEqualThis, NullTypes.DatetimeNT DataRegistrazioneRitiroEqualThis, NullTypes.DatetimeNT DataCertificazioneRecuperoEqualThis,
NullTypes.DatetimeNT DataCertificazioneRitiroEqualThis, NullTypes.DatetimeNT DataCertificazioneNonRecuperabilitaEqualThis, NullTypes.BoolNT GestioneRateEqualThis,
NullTypes.IntNT NumeroRateEqualThis, NullTypes.IntNT IntervalloRateMesiEqualThis, NullTypes.DatetimeNT DataInizioRateEqualThis,
NullTypes.DecimalNT ImportoRataEqualThis, NullTypes.StringNT SoggettoRevocaFinanziamentoEqualThis, NullTypes.IntNT IdAttoRecuperoEqualThis,
NullTypes.IntNT IdAttoRitiroEqualThis, NullTypes.IntNT IdAttoNonRecuperabilitaEqualThis, NullTypes.BoolNT RecuperabileEqualThis,
NullTypes.DatetimeNT DataRegistrazioneNonRecuperabilitaEqualThis, NullTypes.DatetimeNT DataSegnaturaEqualThis, NullTypes.StringNT SegnaturaEqualThis)
        {
            RegistroRecuperoCollection RegistroRecuperoCollectionTemp = new RegistroRecuperoCollection();
            foreach (RegistroRecupero RegistroRecuperoItem in this)
            {
                if (((IdRegistroRecuperoEqualThis == null) || ((RegistroRecuperoItem.IdRegistroRecupero != null) && (RegistroRecuperoItem.IdRegistroRecupero.Value == IdRegistroRecuperoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RegistroRecuperoItem.DataInserimento != null) && (RegistroRecuperoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((RegistroRecuperoItem.CfInserimento != null) && (RegistroRecuperoItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((RegistroRecuperoItem.DataModifica != null) && (RegistroRecuperoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((RegistroRecuperoItem.CfModifica != null) && (RegistroRecuperoItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdRegistroIrregolaritaEqualThis == null) || ((RegistroRecuperoItem.IdRegistroIrregolarita != null) && (RegistroRecuperoItem.IdRegistroIrregolarita.Value == IdRegistroIrregolaritaEqualThis.Value))) &&
((DataAvvioEqualThis == null) || ((RegistroRecuperoItem.DataAvvio != null) && (RegistroRecuperoItem.DataAvvio.Value == DataAvvioEqualThis.Value))) && ((DataProbabileConclusioneEqualThis == null) || ((RegistroRecuperoItem.DataProbabileConclusione != null) && (RegistroRecuperoItem.DataProbabileConclusione.Value == DataProbabileConclusioneEqualThis.Value))) && ((ImportoDaRecuperareUeEqualThis == null) || ((RegistroRecuperoItem.ImportoDaRecuperareUe != null) && (RegistroRecuperoItem.ImportoDaRecuperareUe.Value == ImportoDaRecuperareUeEqualThis.Value))) &&
((ImportoDaRecuperareNazionaleEqualThis == null) || ((RegistroRecuperoItem.ImportoDaRecuperareNazionale != null) && (RegistroRecuperoItem.ImportoDaRecuperareNazionale.Value == ImportoDaRecuperareNazionaleEqualThis.Value))) && ((ImportoDaRecuperarePubblicoEqualThis == null) || ((RegistroRecuperoItem.ImportoDaRecuperarePubblico != null) && (RegistroRecuperoItem.ImportoDaRecuperarePubblico.Value == ImportoDaRecuperarePubblicoEqualThis.Value))) && ((ImportoDaRecuperarePrivatoEqualThis == null) || ((RegistroRecuperoItem.ImportoDaRecuperarePrivato != null) && (RegistroRecuperoItem.ImportoDaRecuperarePrivato.Value == ImportoDaRecuperarePrivatoEqualThis.Value))) &&
((ImportoDaRecuperareTotaleEqualThis == null) || ((RegistroRecuperoItem.ImportoDaRecuperareTotale != null) && (RegistroRecuperoItem.ImportoDaRecuperareTotale.Value == ImportoDaRecuperareTotaleEqualThis.Value))) && ((ImportoDetrattoUeEqualThis == null) || ((RegistroRecuperoItem.ImportoDetrattoUe != null) && (RegistroRecuperoItem.ImportoDetrattoUe.Value == ImportoDetrattoUeEqualThis.Value))) && ((ImportoDetrattoNazionaleEqualThis == null) || ((RegistroRecuperoItem.ImportoDetrattoNazionale != null) && (RegistroRecuperoItem.ImportoDetrattoNazionale.Value == ImportoDetrattoNazionaleEqualThis.Value))) &&
((ImportoDetrattoPubblicoEqualThis == null) || ((RegistroRecuperoItem.ImportoDetrattoPubblico != null) && (RegistroRecuperoItem.ImportoDetrattoPubblico.Value == ImportoDetrattoPubblicoEqualThis.Value))) && ((ImportoDetrattoPrivatoEqualThis == null) || ((RegistroRecuperoItem.ImportoDetrattoPrivato != null) && (RegistroRecuperoItem.ImportoDetrattoPrivato.Value == ImportoDetrattoPrivatoEqualThis.Value))) && ((ImportoDetrattoTotaleEqualThis == null) || ((RegistroRecuperoItem.ImportoDetrattoTotale != null) && (RegistroRecuperoItem.ImportoDetrattoTotale.Value == ImportoDetrattoTotaleEqualThis.Value))) &&
((ImportoRecuperatoUeEqualThis == null) || ((RegistroRecuperoItem.ImportoRecuperatoUe != null) && (RegistroRecuperoItem.ImportoRecuperatoUe.Value == ImportoRecuperatoUeEqualThis.Value))) && ((ImportoRecuperatoNazionaleEqualThis == null) || ((RegistroRecuperoItem.ImportoRecuperatoNazionale != null) && (RegistroRecuperoItem.ImportoRecuperatoNazionale.Value == ImportoRecuperatoNazionaleEqualThis.Value))) && ((ImportoRecuperatoPubblicoEqualThis == null) || ((RegistroRecuperoItem.ImportoRecuperatoPubblico != null) && (RegistroRecuperoItem.ImportoRecuperatoPubblico.Value == ImportoRecuperatoPubblicoEqualThis.Value))) &&
((ImportoRecuperatoPrivatoEqualThis == null) || ((RegistroRecuperoItem.ImportoRecuperatoPrivato != null) && (RegistroRecuperoItem.ImportoRecuperatoPrivato.Value == ImportoRecuperatoPrivatoEqualThis.Value))) && ((ImportoRecuperatoTotaleEqualThis == null) || ((RegistroRecuperoItem.ImportoRecuperatoTotale != null) && (RegistroRecuperoItem.ImportoRecuperatoTotale.Value == ImportoRecuperatoTotaleEqualThis.Value))) && ((SaldoDaRecuperareUeEqualThis == null) || ((RegistroRecuperoItem.SaldoDaRecuperareUe != null) && (RegistroRecuperoItem.SaldoDaRecuperareUe.Value == SaldoDaRecuperareUeEqualThis.Value))) &&
((SaldoDaRecuperareNazionaleEqualThis == null) || ((RegistroRecuperoItem.SaldoDaRecuperareNazionale != null) && (RegistroRecuperoItem.SaldoDaRecuperareNazionale.Value == SaldoDaRecuperareNazionaleEqualThis.Value))) && ((SaldoDaRecuperarePubblicoEqualThis == null) || ((RegistroRecuperoItem.SaldoDaRecuperarePubblico != null) && (RegistroRecuperoItem.SaldoDaRecuperarePubblico.Value == SaldoDaRecuperarePubblicoEqualThis.Value))) && ((SaldoDaRecuperarePrivatoEqualThis == null) || ((RegistroRecuperoItem.SaldoDaRecuperarePrivato != null) && (RegistroRecuperoItem.SaldoDaRecuperarePrivato.Value == SaldoDaRecuperarePrivatoEqualThis.Value))) &&
((SaldoDaRecuperareTotaleEqualThis == null) || ((RegistroRecuperoItem.SaldoDaRecuperareTotale != null) && (RegistroRecuperoItem.SaldoDaRecuperareTotale.Value == SaldoDaRecuperareTotaleEqualThis.Value))) && ((ImportoVersatoUeEqualThis == null) || ((RegistroRecuperoItem.ImportoVersatoUe != null) && (RegistroRecuperoItem.ImportoVersatoUe.Value == ImportoVersatoUeEqualThis.Value))) && ((ImportoRitenutoStatoEqualThis == null) || ((RegistroRecuperoItem.ImportoRitenutoStato != null) && (RegistroRecuperoItem.ImportoRitenutoStato.Value == ImportoRitenutoStatoEqualThis.Value))) &&
((ImportoInteressiMoraEqualThis == null) || ((RegistroRecuperoItem.ImportoInteressiMora != null) && (RegistroRecuperoItem.ImportoInteressiMora.Value == ImportoInteressiMoraEqualThis.Value))) && ((ImportoInteressiLegaliEqualThis == null) || ((RegistroRecuperoItem.ImportoInteressiLegali != null) && (RegistroRecuperoItem.ImportoInteressiLegali.Value == ImportoInteressiLegaliEqualThis.Value))) && ((ImportoGestionePraticaEqualThis == null) || ((RegistroRecuperoItem.ImportoGestionePratica != null) && (RegistroRecuperoItem.ImportoGestionePratica.Value == ImportoGestionePraticaEqualThis.Value))) &&
((DataConclusioneEqualThis == null) || ((RegistroRecuperoItem.DataConclusione != null) && (RegistroRecuperoItem.DataConclusione.Value == DataConclusioneEqualThis.Value))) && ((IdProcedureAvviateEqualThis == null) || ((RegistroRecuperoItem.IdProcedureAvviate != null) && (RegistroRecuperoItem.IdProcedureAvviate.Value == IdProcedureAvviateEqualThis.Value))) && ((IdTipoProcedureAvviateEqualThis == null) || ((RegistroRecuperoItem.IdTipoProcedureAvviate != null) && (RegistroRecuperoItem.IdTipoProcedureAvviate.Value == IdTipoProcedureAvviateEqualThis.Value))) &&
((DataAvvioProcedureEqualThis == null) || ((RegistroRecuperoItem.DataAvvioProcedure != null) && (RegistroRecuperoItem.DataAvvioProcedure.Value == DataAvvioProcedureEqualThis.Value))) && ((DataProbabileConclusioneProcedureEqualThis == null) || ((RegistroRecuperoItem.DataProbabileConclusioneProcedure != null) && (RegistroRecuperoItem.DataProbabileConclusioneProcedure.Value == DataProbabileConclusioneProcedureEqualThis.Value))) && ((IdTipoRecuperoEqualThis == null) || ((RegistroRecuperoItem.IdTipoRecupero != null) && (RegistroRecuperoItem.IdTipoRecupero.Value == IdTipoRecuperoEqualThis.Value))) &&
((IdOrigineRecuperoEqualThis == null) || ((RegistroRecuperoItem.IdOrigineRecupero != null) && (RegistroRecuperoItem.IdOrigineRecupero.Value == IdOrigineRecuperoEqualThis.Value))) && ((IdStoricoRecuperoPrecedenteEqualThis == null) || ((RegistroRecuperoItem.IdStoricoRecuperoPrecedente != null) && (RegistroRecuperoItem.IdStoricoRecuperoPrecedente.Value == IdStoricoRecuperoPrecedenteEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RegistroRecuperoItem.IdProgetto != null) && (RegistroRecuperoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((StoricoEqualThis == null) || ((RegistroRecuperoItem.Storico != null) && (RegistroRecuperoItem.Storico.Value == StoricoEqualThis.Value))) && ((DataRegistrazioneRitiroEqualThis == null) || ((RegistroRecuperoItem.DataRegistrazioneRitiro != null) && (RegistroRecuperoItem.DataRegistrazioneRitiro.Value == DataRegistrazioneRitiroEqualThis.Value))) && ((DataCertificazioneRecuperoEqualThis == null) || ((RegistroRecuperoItem.DataCertificazioneRecupero != null) && (RegistroRecuperoItem.DataCertificazioneRecupero.Value == DataCertificazioneRecuperoEqualThis.Value))) &&
((DataCertificazioneRitiroEqualThis == null) || ((RegistroRecuperoItem.DataCertificazioneRitiro != null) && (RegistroRecuperoItem.DataCertificazioneRitiro.Value == DataCertificazioneRitiroEqualThis.Value))) && ((DataCertificazioneNonRecuperabilitaEqualThis == null) || ((RegistroRecuperoItem.DataCertificazioneNonRecuperabilita != null) && (RegistroRecuperoItem.DataCertificazioneNonRecuperabilita.Value == DataCertificazioneNonRecuperabilitaEqualThis.Value))) && ((GestioneRateEqualThis == null) || ((RegistroRecuperoItem.GestioneRate != null) && (RegistroRecuperoItem.GestioneRate.Value == GestioneRateEqualThis.Value))) &&
((NumeroRateEqualThis == null) || ((RegistroRecuperoItem.NumeroRate != null) && (RegistroRecuperoItem.NumeroRate.Value == NumeroRateEqualThis.Value))) && ((IntervalloRateMesiEqualThis == null) || ((RegistroRecuperoItem.IntervalloRateMesi != null) && (RegistroRecuperoItem.IntervalloRateMesi.Value == IntervalloRateMesiEqualThis.Value))) && ((DataInizioRateEqualThis == null) || ((RegistroRecuperoItem.DataInizioRate != null) && (RegistroRecuperoItem.DataInizioRate.Value == DataInizioRateEqualThis.Value))) &&
((ImportoRataEqualThis == null) || ((RegistroRecuperoItem.ImportoRata != null) && (RegistroRecuperoItem.ImportoRata.Value == ImportoRataEqualThis.Value))) && ((SoggettoRevocaFinanziamentoEqualThis == null) || ((RegistroRecuperoItem.SoggettoRevocaFinanziamento != null) && (RegistroRecuperoItem.SoggettoRevocaFinanziamento.Value == SoggettoRevocaFinanziamentoEqualThis.Value))) && ((IdAttoRecuperoEqualThis == null) || ((RegistroRecuperoItem.IdAttoRecupero != null) && (RegistroRecuperoItem.IdAttoRecupero.Value == IdAttoRecuperoEqualThis.Value))) &&
((IdAttoRitiroEqualThis == null) || ((RegistroRecuperoItem.IdAttoRitiro != null) && (RegistroRecuperoItem.IdAttoRitiro.Value == IdAttoRitiroEqualThis.Value))) && ((IdAttoNonRecuperabilitaEqualThis == null) || ((RegistroRecuperoItem.IdAttoNonRecuperabilita != null) && (RegistroRecuperoItem.IdAttoNonRecuperabilita.Value == IdAttoNonRecuperabilitaEqualThis.Value))) && ((RecuperabileEqualThis == null) || ((RegistroRecuperoItem.Recuperabile != null) && (RegistroRecuperoItem.Recuperabile.Value == RecuperabileEqualThis.Value))) &&
((DataRegistrazioneNonRecuperabilitaEqualThis == null) || ((RegistroRecuperoItem.DataRegistrazioneNonRecuperabilita != null) && (RegistroRecuperoItem.DataRegistrazioneNonRecuperabilita.Value == DataRegistrazioneNonRecuperabilitaEqualThis.Value))) && ((DataSegnaturaEqualThis == null) || ((RegistroRecuperoItem.DataSegnatura != null) && (RegistroRecuperoItem.DataSegnatura.Value == DataSegnaturaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((RegistroRecuperoItem.Segnatura != null) && (RegistroRecuperoItem.Segnatura.Value == SegnaturaEqualThis.Value))))
                {
                    RegistroRecuperoCollectionTemp.Add(RegistroRecuperoItem);
                }
            }
            return RegistroRecuperoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for RegistroRecuperoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class RegistroRecuperoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RegistroRecupero RegistroRecuperoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdRegistroRecupero", RegistroRecuperoObj.IdRegistroRecupero);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", RegistroRecuperoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", RegistroRecuperoObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", RegistroRecuperoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", RegistroRecuperoObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRegistroIrregolarita", RegistroRecuperoObj.IdRegistroIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAvvio", RegistroRecuperoObj.DataAvvio);
            DbProvider.SetCmdParam(cmd, firstChar + "DataProbabileConclusione", RegistroRecuperoObj.DataProbabileConclusione);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareUe", RegistroRecuperoObj.ImportoDaRecuperareUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareNazionale", RegistroRecuperoObj.ImportoDaRecuperareNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperarePubblico", RegistroRecuperoObj.ImportoDaRecuperarePubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDetrattoUe", RegistroRecuperoObj.ImportoDetrattoUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDetrattoNazionale", RegistroRecuperoObj.ImportoDetrattoNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDetrattoPubblico", RegistroRecuperoObj.ImportoDetrattoPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperatoUe", RegistroRecuperoObj.ImportoRecuperatoUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperatoPubblico", RegistroRecuperoObj.ImportoRecuperatoPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperatoNazionale", RegistroRecuperoObj.ImportoRecuperatoNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "SaldoDaRecuperareUe", RegistroRecuperoObj.SaldoDaRecuperareUe);
            DbProvider.SetCmdParam(cmd, firstChar + "SaldoDaRecuperareNazionale", RegistroRecuperoObj.SaldoDaRecuperareNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "SaldoDaRecuperarePubblico", RegistroRecuperoObj.SaldoDaRecuperarePubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoVersatoUe", RegistroRecuperoObj.ImportoVersatoUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRitenutoStato", RegistroRecuperoObj.ImportoRitenutoStato);
            DbProvider.SetCmdParam(cmd, firstChar + "DataConclusione", RegistroRecuperoObj.DataConclusione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProcedureAvviate", RegistroRecuperoObj.IdProcedureAvviate);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoProcedureAvviate", RegistroRecuperoObj.IdTipoProcedureAvviate);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAvvioProcedure", RegistroRecuperoObj.DataAvvioProcedure);
            DbProvider.SetCmdParam(cmd, firstChar + "DataProbabileConclusioneProcedure", RegistroRecuperoObj.DataProbabileConclusioneProcedure);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoRecupero", RegistroRecuperoObj.IdTipoRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "IdOrigineRecupero", RegistroRecuperoObj.IdOrigineRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStoricoRecuperoPrecedente", RegistroRecuperoObj.IdStoricoRecuperoPrecedente);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", RegistroRecuperoObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "Storico", RegistroRecuperoObj.Storico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoInteressiLegali", RegistroRecuperoObj.ImportoInteressiLegali);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoInteressiMora", RegistroRecuperoObj.ImportoInteressiMora);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoGestionePratica", RegistroRecuperoObj.ImportoGestionePratica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRegistrazioneRitiro", RegistroRecuperoObj.DataRegistrazioneRitiro);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCertificazioneRecupero", RegistroRecuperoObj.DataCertificazioneRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCertificazioneRitiro", RegistroRecuperoObj.DataCertificazioneRitiro);
            DbProvider.SetCmdParam(cmd, firstChar + "GestioneRate", RegistroRecuperoObj.GestioneRate);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroRate", RegistroRecuperoObj.NumeroRate);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizioRate", RegistroRecuperoObj.DataInizioRate);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRata", RegistroRecuperoObj.ImportoRata);
            DbProvider.SetCmdParam(cmd, firstChar + "IntervalloRateMesi", RegistroRecuperoObj.IntervalloRateMesi);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperarePrivato", RegistroRecuperoObj.ImportoDaRecuperarePrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareTotale", RegistroRecuperoObj.ImportoDaRecuperareTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDetrattoPrivato", RegistroRecuperoObj.ImportoDetrattoPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperatoPrivato", RegistroRecuperoObj.ImportoRecuperatoPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperatoTotale", RegistroRecuperoObj.ImportoRecuperatoTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "SaldoDaRecuperarePrivato", RegistroRecuperoObj.SaldoDaRecuperarePrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "SaldoDaRecuperareTotale", RegistroRecuperoObj.SaldoDaRecuperareTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "SoggettoRevocaFinanziamento", RegistroRecuperoObj.SoggettoRevocaFinanziamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoRecupero", RegistroRecuperoObj.IdAttoRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoRitiro", RegistroRecuperoObj.IdAttoRitiro);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoNonRecuperabilita", RegistroRecuperoObj.IdAttoNonRecuperabilita);
            DbProvider.SetCmdParam(cmd, firstChar + "Recuperabile", RegistroRecuperoObj.Recuperabile);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDetrattoTotale", RegistroRecuperoObj.ImportoDetrattoTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCertificazioneNonRecuperabilita", RegistroRecuperoObj.DataCertificazioneNonRecuperabilita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRegistrazioneNonRecuperabilita", RegistroRecuperoObj.DataRegistrazioneNonRecuperabilita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSegnatura", RegistroRecuperoObj.DataSegnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", RegistroRecuperoObj.Segnatura);
        }
        //Insert
        private static int Insert(DbProvider db, RegistroRecupero RegistroRecuperoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZRegistroRecuperoInsert", new string[] {"DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdRegistroIrregolarita",
"DataAvvio", "DataProbabileConclusione", "ImportoDaRecuperareUe",
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDetrattoUe",
"ImportoDetrattoNazionale", "ImportoDetrattoPubblico", "ImportoRecuperatoUe",
"ImportoRecuperatoPubblico", "ImportoRecuperatoNazionale", "SaldoDaRecuperareUe",
"SaldoDaRecuperareNazionale", "SaldoDaRecuperarePubblico", "ImportoVersatoUe",
"ImportoRitenutoStato", "DataConclusione", "IdProcedureAvviate",
"IdTipoProcedureAvviate", "DataAvvioProcedure", "DataProbabileConclusioneProcedure",
"IdTipoRecupero", "IdOrigineRecupero", "IdStoricoRecuperoPrecedente",
"IdProgetto",




"Storico", "ImportoInteressiLegali", "ImportoInteressiMora",
"ImportoGestionePratica", "DataRegistrazioneRitiro", "DataCertificazioneRecupero",
"DataCertificazioneRitiro", "GestioneRate", "NumeroRate",
"DataInizioRate", "ImportoRata", "IntervalloRateMesi",
"ImportoDaRecuperarePrivato",
"ImportoDaRecuperareTotale", "ImportoDetrattoPrivato", "ImportoRecuperatoPrivato",
"ImportoRecuperatoTotale", "SaldoDaRecuperarePrivato", "SaldoDaRecuperareTotale",
"SoggettoRevocaFinanziamento", "IdAttoRecupero", "IdAttoRitiro",
"IdAttoNonRecuperabilita", "Recuperabile", "ImportoDetrattoTotale",
"DataCertificazioneNonRecuperabilita", "DataRegistrazioneNonRecuperabilita",
"DataSegnatura", "Segnatura"}, new string[] {"DateTime", "string",
"DateTime", "string", "int",
"DateTime", "DateTime", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "DateTime", "int",
"int", "DateTime", "DateTime",
"int", "int", "int",
"int",




"bool", "decimal", "decimal",
"decimal", "DateTime", "DateTime",
"DateTime", "bool", "int",
"DateTime", "decimal", "int",
"decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"string", "int", "int",
"int", "bool", "decimal",
"DateTime", "DateTime",
"DateTime", "string"}, "");
                CompileIUCmd(false, insertCmd, RegistroRecuperoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    RegistroRecuperoObj.IdRegistroRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_RECUPERO"]);
                    RegistroRecuperoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    RegistroRecuperoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    RegistroRecuperoObj.Storico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STORICO"]);
                    RegistroRecuperoObj.GestioneRate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GESTIONE_RATE"]);
                    RegistroRecuperoObj.IntervalloRateMesi = new SiarLibrary.NullTypes.IntNT(db.DataReader["INTERVALLO_RATE_MESI"]);
                    RegistroRecuperoObj.Recuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERABILE"]);
                }
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, RegistroRecupero RegistroRecuperoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroRecuperoUpdate", new string[] {"IdRegistroRecupero", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdRegistroIrregolarita",
"DataAvvio", "DataProbabileConclusione", "ImportoDaRecuperareUe",
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDetrattoUe",
"ImportoDetrattoNazionale", "ImportoDetrattoPubblico", "ImportoRecuperatoUe",
"ImportoRecuperatoPubblico", "ImportoRecuperatoNazionale", "SaldoDaRecuperareUe",
"SaldoDaRecuperareNazionale", "SaldoDaRecuperarePubblico", "ImportoVersatoUe",
"ImportoRitenutoStato", "DataConclusione", "IdProcedureAvviate",
"IdTipoProcedureAvviate", "DataAvvioProcedure", "DataProbabileConclusioneProcedure",
"IdTipoRecupero", "IdOrigineRecupero", "IdStoricoRecuperoPrecedente",
"IdProgetto",




"Storico", "ImportoInteressiLegali", "ImportoInteressiMora",
"ImportoGestionePratica", "DataRegistrazioneRitiro", "DataCertificazioneRecupero",
"DataCertificazioneRitiro", "GestioneRate", "NumeroRate",
"DataInizioRate", "ImportoRata", "IntervalloRateMesi",
"ImportoDaRecuperarePrivato",
"ImportoDaRecuperareTotale", "ImportoDetrattoPrivato", "ImportoRecuperatoPrivato",
"ImportoRecuperatoTotale", "SaldoDaRecuperarePrivato", "SaldoDaRecuperareTotale",
"SoggettoRevocaFinanziamento", "IdAttoRecupero", "IdAttoRitiro",
"IdAttoNonRecuperabilita", "Recuperabile", "ImportoDetrattoTotale",
"DataCertificazioneNonRecuperabilita", "DataRegistrazioneNonRecuperabilita",
"DataSegnatura", "Segnatura"}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"DateTime", "DateTime", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "DateTime", "int",
"int", "DateTime", "DateTime",
"int", "int", "int",
"int",




"bool", "decimal", "decimal",
"decimal", "DateTime", "DateTime",
"DateTime", "bool", "int",
"DateTime", "decimal", "int",
"decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"string", "int", "int",
"int", "bool", "decimal",
"DateTime", "DateTime",
"DateTime", "string"}, "");
                CompileIUCmd(true, updateCmd, RegistroRecuperoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    RegistroRecuperoObj.DataModifica = d;
                }
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, RegistroRecupero RegistroRecuperoObj)
        {
            switch (RegistroRecuperoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, RegistroRecuperoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, RegistroRecuperoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, RegistroRecuperoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, RegistroRecuperoCollection RegistroRecuperoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroRecuperoUpdate", new string[] {"IdRegistroRecupero", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdRegistroIrregolarita",
"DataAvvio", "DataProbabileConclusione", "ImportoDaRecuperareUe",
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDetrattoUe",
"ImportoDetrattoNazionale", "ImportoDetrattoPubblico", "ImportoRecuperatoUe",
"ImportoRecuperatoPubblico", "ImportoRecuperatoNazionale", "SaldoDaRecuperareUe",
"SaldoDaRecuperareNazionale", "SaldoDaRecuperarePubblico", "ImportoVersatoUe",
"ImportoRitenutoStato", "DataConclusione", "IdProcedureAvviate",
"IdTipoProcedureAvviate", "DataAvvioProcedure", "DataProbabileConclusioneProcedure",
"IdTipoRecupero", "IdOrigineRecupero", "IdStoricoRecuperoPrecedente",
"IdProgetto",




"Storico", "ImportoInteressiLegali", "ImportoInteressiMora",
"ImportoGestionePratica", "DataRegistrazioneRitiro", "DataCertificazioneRecupero",
"DataCertificazioneRitiro", "GestioneRate", "NumeroRate",
"DataInizioRate", "ImportoRata", "IntervalloRateMesi",
"ImportoDaRecuperarePrivato",
"ImportoDaRecuperareTotale", "ImportoDetrattoPrivato", "ImportoRecuperatoPrivato",
"ImportoRecuperatoTotale", "SaldoDaRecuperarePrivato", "SaldoDaRecuperareTotale",
"SoggettoRevocaFinanziamento", "IdAttoRecupero", "IdAttoRitiro",
"IdAttoNonRecuperabilita", "Recuperabile", "ImportoDetrattoTotale",
"DataCertificazioneNonRecuperabilita", "DataRegistrazioneNonRecuperabilita",
"DataSegnatura", "Segnatura"}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"DateTime", "DateTime", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "DateTime", "int",
"int", "DateTime", "DateTime",
"int", "int", "int",
"int",




"bool", "decimal", "decimal",
"decimal", "DateTime", "DateTime",
"DateTime", "bool", "int",
"DateTime", "decimal", "int",
"decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"string", "int", "int",
"int", "bool", "decimal",
"DateTime", "DateTime",
"DateTime", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZRegistroRecuperoInsert", new string[] {"DataInserimento", "CfInserimento",
"DataModifica", "CfModifica", "IdRegistroIrregolarita",
"DataAvvio", "DataProbabileConclusione", "ImportoDaRecuperareUe",
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDetrattoUe",
"ImportoDetrattoNazionale", "ImportoDetrattoPubblico", "ImportoRecuperatoUe",
"ImportoRecuperatoPubblico", "ImportoRecuperatoNazionale", "SaldoDaRecuperareUe",
"SaldoDaRecuperareNazionale", "SaldoDaRecuperarePubblico", "ImportoVersatoUe",
"ImportoRitenutoStato", "DataConclusione", "IdProcedureAvviate",
"IdTipoProcedureAvviate", "DataAvvioProcedure", "DataProbabileConclusioneProcedure",
"IdTipoRecupero", "IdOrigineRecupero", "IdStoricoRecuperoPrecedente",
"IdProgetto",




"Storico", "ImportoInteressiLegali", "ImportoInteressiMora",
"ImportoGestionePratica", "DataRegistrazioneRitiro", "DataCertificazioneRecupero",
"DataCertificazioneRitiro", "GestioneRate", "NumeroRate",
"DataInizioRate", "ImportoRata", "IntervalloRateMesi",
"ImportoDaRecuperarePrivato",
"ImportoDaRecuperareTotale", "ImportoDetrattoPrivato", "ImportoRecuperatoPrivato",
"ImportoRecuperatoTotale", "SaldoDaRecuperarePrivato", "SaldoDaRecuperareTotale",
"SoggettoRevocaFinanziamento", "IdAttoRecupero", "IdAttoRitiro",
"IdAttoNonRecuperabilita", "Recuperabile", "ImportoDetrattoTotale",
"DataCertificazioneNonRecuperabilita", "DataRegistrazioneNonRecuperabilita",
"DataSegnatura", "Segnatura"}, new string[] {"DateTime", "string",
"DateTime", "string", "int",
"DateTime", "DateTime", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "DateTime", "int",
"int", "DateTime", "DateTime",
"int", "int", "int",
"int",




"bool", "decimal", "decimal",
"decimal", "DateTime", "DateTime",
"DateTime", "bool", "int",
"DateTime", "decimal", "int",
"decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"string", "int", "int",
"int", "bool", "decimal",
"DateTime", "DateTime",
"DateTime", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZRegistroRecuperoDelete", new string[] { "IdRegistroRecupero" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroRecuperoCollectionObj.Count; i++)
                {
                    switch (RegistroRecuperoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, RegistroRecuperoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    RegistroRecuperoCollectionObj[i].IdRegistroRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_RECUPERO"]);
                                    RegistroRecuperoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    RegistroRecuperoCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    RegistroRecuperoCollectionObj[i].Storico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STORICO"]);
                                    RegistroRecuperoCollectionObj[i].GestioneRate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GESTIONE_RATE"]);
                                    RegistroRecuperoCollectionObj[i].IntervalloRateMesi = new SiarLibrary.NullTypes.IntNT(db.DataReader["INTERVALLO_RATE_MESI"]);
                                    RegistroRecuperoCollectionObj[i].Recuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERABILE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, RegistroRecuperoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    RegistroRecuperoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (RegistroRecuperoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRegistroRecupero", (SiarLibrary.NullTypes.IntNT)RegistroRecuperoCollectionObj[i].IdRegistroRecupero);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < RegistroRecuperoCollectionObj.Count; i++)
                {
                    if ((RegistroRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        RegistroRecuperoCollectionObj[i].IsDirty = false;
                        RegistroRecuperoCollectionObj[i].IsPersistent = true;
                    }
                    if ((RegistroRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        RegistroRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroRecuperoCollectionObj[i].IsDirty = false;
                        RegistroRecuperoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, RegistroRecupero RegistroRecuperoObj)
        {
            int returnValue = 0;
            if (RegistroRecuperoObj.IsPersistent)
            {
                returnValue = Delete(db, RegistroRecuperoObj.IdRegistroRecupero);
            }
            RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            RegistroRecuperoObj.IsDirty = false;
            RegistroRecuperoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdRegistroRecuperoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroRecuperoDelete", new string[] { "IdRegistroRecupero" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRegistroRecupero", (SiarLibrary.NullTypes.IntNT)IdRegistroRecuperoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, RegistroRecuperoCollection RegistroRecuperoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroRecuperoDelete", new string[] { "IdRegistroRecupero" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroRecuperoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRegistroRecupero", RegistroRecuperoCollectionObj[i].IdRegistroRecupero);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < RegistroRecuperoCollectionObj.Count; i++)
                {
                    if ((RegistroRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroRecuperoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroRecuperoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroRecuperoCollectionObj[i].IsDirty = false;
                        RegistroRecuperoCollectionObj[i].IsPersistent = false;
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
        public static RegistroRecupero GetById(DbProvider db, int IdRegistroRecuperoValue)
        {
            RegistroRecupero RegistroRecuperoObj = null;
            IDbCommand readCmd = db.InitCmd("ZRegistroRecuperoGetById", new string[] { "IdRegistroRecupero" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdRegistroRecupero", (SiarLibrary.NullTypes.IntNT)IdRegistroRecuperoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                RegistroRecuperoObj = GetFromDatareader(db);
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
            }
            db.Close();
            return RegistroRecuperoObj;
        }

        //getFromDatareader
        public static RegistroRecupero GetFromDatareader(DbProvider db)
        {
            RegistroRecupero RegistroRecuperoObj = new RegistroRecupero();
            RegistroRecuperoObj.IdRegistroRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_RECUPERO"]);
            RegistroRecuperoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            RegistroRecuperoObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            RegistroRecuperoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            RegistroRecuperoObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            RegistroRecuperoObj.IdRegistroIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_IRREGOLARITA"]);
            RegistroRecuperoObj.DataAvvio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AVVIO"]);
            RegistroRecuperoObj.DataProbabileConclusione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PROBABILE_CONCLUSIONE"]);
            RegistroRecuperoObj.ImportoDaRecuperareUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_UE"]);
            RegistroRecuperoObj.ImportoDaRecuperareNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_NAZIONALE"]);
            RegistroRecuperoObj.ImportoDaRecuperarePubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_PUBBLICO"]);
            RegistroRecuperoObj.ImportoDetrattoUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DETRATTO_UE"]);
            RegistroRecuperoObj.ImportoDetrattoNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DETRATTO_NAZIONALE"]);
            RegistroRecuperoObj.ImportoDetrattoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DETRATTO_PUBBLICO"]);
            RegistroRecuperoObj.ImportoRecuperatoUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO_UE"]);
            RegistroRecuperoObj.ImportoRecuperatoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO_PUBBLICO"]);
            RegistroRecuperoObj.ImportoRecuperatoNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO_NAZIONALE"]);
            RegistroRecuperoObj.SaldoDaRecuperareUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SALDO_DA_RECUPERARE_UE"]);
            RegistroRecuperoObj.SaldoDaRecuperareNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SALDO_DA_RECUPERARE_NAZIONALE"]);
            RegistroRecuperoObj.SaldoDaRecuperarePubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SALDO_DA_RECUPERARE_PUBBLICO"]);
            RegistroRecuperoObj.ImportoVersatoUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_VERSATO_UE"]);
            RegistroRecuperoObj.ImportoRitenutoStato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RITENUTO_STATO"]);
            RegistroRecuperoObj.DataConclusione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE"]);
            RegistroRecuperoObj.IdProcedureAvviate = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROCEDURE_AVVIATE"]);
            RegistroRecuperoObj.IdTipoProcedureAvviate = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PROCEDURE_AVVIATE"]);
            RegistroRecuperoObj.DataAvvioProcedure = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AVVIO_PROCEDURE"]);
            RegistroRecuperoObj.DataProbabileConclusioneProcedure = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PROBABILE_CONCLUSIONE_PROCEDURE"]);
            RegistroRecuperoObj.IdTipoRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_RECUPERO"]);
            RegistroRecuperoObj.IdOrigineRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORIGINE_RECUPERO"]);
            RegistroRecuperoObj.IdStoricoRecuperoPrecedente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_RECUPERO_PRECEDENTE"]);
            RegistroRecuperoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            RegistroRecuperoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            RegistroRecuperoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            RegistroRecuperoObj.CodAgea = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AGEA"]);
            RegistroRecuperoObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            RegistroRecuperoObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
            RegistroRecuperoObj.FlagPreadesione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PREADESIONE"]);
            RegistroRecuperoObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
            RegistroRecuperoObj.IdFascicolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO"]);
            RegistroRecuperoObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
            RegistroRecuperoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
            RegistroRecuperoObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
            RegistroRecuperoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            RegistroRecuperoObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
            RegistroRecuperoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            RegistroRecuperoObj.Storico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STORICO"]);
            RegistroRecuperoObj.ImportoInteressiLegali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_INTERESSI_LEGALI"]);
            RegistroRecuperoObj.ImportoInteressiMora = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_INTERESSI_MORA"]);
            RegistroRecuperoObj.ImportoGestionePratica = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_GESTIONE_PRATICA"]);
            RegistroRecuperoObj.DataRegistrazioneRitiro = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REGISTRAZIONE_RITIRO"]);
            RegistroRecuperoObj.DataCertificazioneRecupero = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_RECUPERO"]);
            RegistroRecuperoObj.DataCertificazioneRitiro = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_RITIRO"]);
            RegistroRecuperoObj.GestioneRate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GESTIONE_RATE"]);
            RegistroRecuperoObj.NumeroRate = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_RATE"]);
            RegistroRecuperoObj.DataInizioRate = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_RATE"]);
            RegistroRecuperoObj.ImportoRata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RATA"]);
            RegistroRecuperoObj.IntervalloRateMesi = new SiarLibrary.NullTypes.IntNT(db.DataReader["INTERVALLO_RATE_MESI"]);
            RegistroRecuperoObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            RegistroRecuperoObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
            RegistroRecuperoObj.ImportoDaRecuperarePrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_PRIVATO"]);
            RegistroRecuperoObj.ImportoDaRecuperareTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_TOTALE"]);
            RegistroRecuperoObj.ImportoDetrattoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DETRATTO_PRIVATO"]);
            RegistroRecuperoObj.ImportoRecuperatoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO_PRIVATO"]);
            RegistroRecuperoObj.ImportoRecuperatoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO_TOTALE"]);
            RegistroRecuperoObj.SaldoDaRecuperarePrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SALDO_DA_RECUPERARE_PRIVATO"]);
            RegistroRecuperoObj.SaldoDaRecuperareTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SALDO_DA_RECUPERARE_TOTALE"]);
            RegistroRecuperoObj.SoggettoRevocaFinanziamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SOGGETTO_REVOCA_FINANZIAMENTO"]);
            RegistroRecuperoObj.IdAttoRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_RECUPERO"]);
            RegistroRecuperoObj.IdAttoRitiro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_RITIRO"]);
            RegistroRecuperoObj.IdAttoNonRecuperabilita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_NON_RECUPERABILITA"]);
            RegistroRecuperoObj.Recuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERABILE"]);
            RegistroRecuperoObj.ImportoDetrattoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DETRATTO_TOTALE"]);
            RegistroRecuperoObj.DataCertificazioneNonRecuperabilita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_NON_RECUPERABILITA"]);
            RegistroRecuperoObj.DataRegistrazioneNonRecuperabilita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REGISTRAZIONE_NON_RECUPERABILITA"]);
            RegistroRecuperoObj.CodAsse = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ASSE"]);
            RegistroRecuperoObj.DescAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESC_AZIONE"]);
            RegistroRecuperoObj.DataSegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNATURA"]);
            RegistroRecuperoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            RegistroRecuperoObj.IsDirty = false;
            RegistroRecuperoObj.IsPersistent = true;
            return RegistroRecuperoObj;
        }

        //Find Select

        public static RegistroRecuperoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRegistroRecuperoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAvvioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataProbabileConclusioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareUeEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperarePubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperarePrivatoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDetrattoUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDetrattoNazionaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDetrattoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDetrattoPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDetrattoTotaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoPubblicoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT SaldoDaRecuperareUeEqualThis,
SiarLibrary.NullTypes.DecimalNT SaldoDaRecuperareNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT SaldoDaRecuperarePubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT SaldoDaRecuperarePrivatoEqualThis,
SiarLibrary.NullTypes.DecimalNT SaldoDaRecuperareTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoVersatoUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRitenutoStatoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoInteressiMoraEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoInteressiLegaliEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoGestionePraticaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataConclusioneEqualThis, SiarLibrary.NullTypes.IntNT IdProcedureAvviateEqualThis, SiarLibrary.NullTypes.IntNT IdTipoProcedureAvviateEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAvvioProcedureEqualThis, SiarLibrary.NullTypes.DatetimeNT DataProbabileConclusioneProcedureEqualThis, SiarLibrary.NullTypes.IntNT IdTipoRecuperoEqualThis,
SiarLibrary.NullTypes.IntNT IdOrigineRecuperoEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoRecuperoPrecedenteEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.BoolNT StoricoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRegistrazioneRitiroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificazioneRecuperoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataCertificazioneRitiroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCertificazioneNonRecuperabilitaEqualThis, SiarLibrary.NullTypes.BoolNT GestioneRateEqualThis,
SiarLibrary.NullTypes.IntNT NumeroRateEqualThis, SiarLibrary.NullTypes.IntNT IntervalloRateMesiEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioRateEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoRataEqualThis, SiarLibrary.NullTypes.StringNT SoggettoRevocaFinanziamentoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoRecuperoEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoRitiroEqualThis, SiarLibrary.NullTypes.IntNT IdAttoNonRecuperabilitaEqualThis, SiarLibrary.NullTypes.BoolNT RecuperabileEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataRegistrazioneNonRecuperabilitaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis)
        {

            RegistroRecuperoCollection RegistroRecuperoCollectionObj = new RegistroRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zregistrorecuperofindselect", new string[] {"IdRegistroRecuperoequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis",
"DataModificaequalthis", "CfModificaequalthis", "IdRegistroIrregolaritaequalthis",
"DataAvvioequalthis", "DataProbabileConclusioneequalthis", "ImportoDaRecuperareUeequalthis",
"ImportoDaRecuperareNazionaleequalthis", "ImportoDaRecuperarePubblicoequalthis", "ImportoDaRecuperarePrivatoequalthis",
"ImportoDaRecuperareTotaleequalthis", "ImportoDetrattoUeequalthis", "ImportoDetrattoNazionaleequalthis",
"ImportoDetrattoPubblicoequalthis", "ImportoDetrattoPrivatoequalthis", "ImportoDetrattoTotaleequalthis",
"ImportoRecuperatoUeequalthis", "ImportoRecuperatoNazionaleequalthis", "ImportoRecuperatoPubblicoequalthis",
"ImportoRecuperatoPrivatoequalthis", "ImportoRecuperatoTotaleequalthis", "SaldoDaRecuperareUeequalthis",
"SaldoDaRecuperareNazionaleequalthis", "SaldoDaRecuperarePubblicoequalthis", "SaldoDaRecuperarePrivatoequalthis",
"SaldoDaRecuperareTotaleequalthis", "ImportoVersatoUeequalthis", "ImportoRitenutoStatoequalthis",
"ImportoInteressiMoraequalthis", "ImportoInteressiLegaliequalthis", "ImportoGestionePraticaequalthis",
"DataConclusioneequalthis", "IdProcedureAvviateequalthis", "IdTipoProcedureAvviateequalthis",
"DataAvvioProcedureequalthis", "DataProbabileConclusioneProcedureequalthis", "IdTipoRecuperoequalthis",
"IdOrigineRecuperoequalthis", "IdStoricoRecuperoPrecedenteequalthis", "IdProgettoequalthis",
"Storicoequalthis", "DataRegistrazioneRitiroequalthis", "DataCertificazioneRecuperoequalthis",
"DataCertificazioneRitiroequalthis", "DataCertificazioneNonRecuperabilitaequalthis", "GestioneRateequalthis",
"NumeroRateequalthis", "IntervalloRateMesiequalthis", "DataInizioRateequalthis",
"ImportoRataequalthis", "SoggettoRevocaFinanziamentoequalthis", "IdAttoRecuperoequalthis",
"IdAttoRitiroequalthis", "IdAttoNonRecuperabilitaequalthis", "Recuperabileequalthis",
"DataRegistrazioneNonRecuperabilitaequalthis", "DataSegnaturaequalthis", "Segnaturaequalthis"}, new string[] {"int", "DateTime", "string",
"DateTime", "string", "int",
"DateTime", "DateTime", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"DateTime", "int", "int",
"DateTime", "DateTime", "int",
"int", "int", "int",
"bool", "DateTime", "DateTime",
"DateTime", "DateTime", "bool",
"int", "int", "DateTime",
"decimal", "string", "int",
"int", "int", "bool",
"DateTime", "DateTime", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroRecuperoequalthis", IdRegistroRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAvvioequalthis", DataAvvioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataProbabileConclusioneequalthis", DataProbabileConclusioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareUeequalthis", ImportoDaRecuperareUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareNazionaleequalthis", ImportoDaRecuperareNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperarePubblicoequalthis", ImportoDaRecuperarePubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperarePrivatoequalthis", ImportoDaRecuperarePrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareTotaleequalthis", ImportoDaRecuperareTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDetrattoUeequalthis", ImportoDetrattoUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDetrattoNazionaleequalthis", ImportoDetrattoNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDetrattoPubblicoequalthis", ImportoDetrattoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDetrattoPrivatoequalthis", ImportoDetrattoPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDetrattoTotaleequalthis", ImportoDetrattoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoUeequalthis", ImportoRecuperatoUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoNazionaleequalthis", ImportoRecuperatoNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoPubblicoequalthis", ImportoRecuperatoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoPrivatoequalthis", ImportoRecuperatoPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoTotaleequalthis", ImportoRecuperatoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SaldoDaRecuperareUeequalthis", SaldoDaRecuperareUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SaldoDaRecuperareNazionaleequalthis", SaldoDaRecuperareNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SaldoDaRecuperarePubblicoequalthis", SaldoDaRecuperarePubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SaldoDaRecuperarePrivatoequalthis", SaldoDaRecuperarePrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SaldoDaRecuperareTotaleequalthis", SaldoDaRecuperareTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoVersatoUeequalthis", ImportoVersatoUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRitenutoStatoequalthis", ImportoRitenutoStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoInteressiMoraequalthis", ImportoInteressiMoraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoInteressiLegaliequalthis", ImportoInteressiLegaliEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoGestionePraticaequalthis", ImportoGestionePraticaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataConclusioneequalthis", DataConclusioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProcedureAvviateequalthis", IdProcedureAvviateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoProcedureAvviateequalthis", IdTipoProcedureAvviateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAvvioProcedureequalthis", DataAvvioProcedureEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataProbabileConclusioneProcedureequalthis", DataProbabileConclusioneProcedureEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoRecuperoequalthis", IdTipoRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdOrigineRecuperoequalthis", IdOrigineRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStoricoRecuperoPrecedenteequalthis", IdStoricoRecuperoPrecedenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Storicoequalthis", StoricoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRegistrazioneRitiroequalthis", DataRegistrazioneRitiroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCertificazioneRecuperoequalthis", DataCertificazioneRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCertificazioneRitiroequalthis", DataCertificazioneRitiroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCertificazioneNonRecuperabilitaequalthis", DataCertificazioneNonRecuperabilitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "GestioneRateequalthis", GestioneRateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRateequalthis", NumeroRateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IntervalloRateMesiequalthis", IntervalloRateMesiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioRateequalthis", DataInizioRateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRataequalthis", ImportoRataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SoggettoRevocaFinanziamentoequalthis", SoggettoRevocaFinanziamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoRecuperoequalthis", IdAttoRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoRitiroequalthis", IdAttoRitiroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoNonRecuperabilitaequalthis", IdAttoNonRecuperabilitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Recuperabileequalthis", RecuperabileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRegistrazioneNonRecuperabilitaequalthis", DataRegistrazioneNonRecuperabilitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSegnaturaequalthis", DataSegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            RegistroRecupero RegistroRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroRecuperoObj = GetFromDatareader(db);
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
                RegistroRecuperoCollectionObj.Add(RegistroRecuperoObj);
            }
            db.Close();
            return RegistroRecuperoCollectionObj;
        }

        //Find GetByRegistroIrregolarita

        public static RegistroRecuperoCollection GetByRegistroIrregolarita(DbProvider db, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis, SiarLibrary.NullTypes.BoolNT StoricoEqualThis)
        {

            RegistroRecuperoCollection RegistroRecuperoCollectionObj = new RegistroRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zregistrorecuperofindgetbyregistroirregolarita", new string[] { "IdRegistroIrregolaritaequalthis", "Storicoequalthis" }, new string[] { "int", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Storicoequalthis", StoricoEqualThis);
            RegistroRecupero RegistroRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroRecuperoObj = GetFromDatareader(db);
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
                RegistroRecuperoCollectionObj.Add(RegistroRecuperoObj);
            }
            db.Close();
            return RegistroRecuperoCollectionObj;
        }

        //Find GetByIdProgetto

        public static RegistroRecuperoCollection GetByIdProgetto(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.BoolNT StoricoEqualThis)
        {

            RegistroRecuperoCollection RegistroRecuperoCollectionObj = new RegistroRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zregistrorecuperofindgetbyidprogetto", new string[] { "IdProgettoequalthis", "Storicoequalthis" }, new string[] { "int", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Storicoequalthis", StoricoEqualThis);
            RegistroRecupero RegistroRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroRecuperoObj = GetFromDatareader(db);
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
                RegistroRecuperoCollectionObj.Add(RegistroRecuperoObj);
            }
            db.Close();
            return RegistroRecuperoCollectionObj;
        }

        //Find GetCollectionReport

        public static RegistroRecuperoCollection GetCollectionReport(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAvvioEqGreaterThanThis,
SiarLibrary.NullTypes.DatetimeNT DataAvvioEqLessThanThis, SiarLibrary.NullTypes.IntNT IdTipoRecuperoEqualThis, SiarLibrary.NullTypes.BoolNT RecuperabileEqualThis,
SiarLibrary.NullTypes.BoolNT StoricoEqualThis)
        {

            RegistroRecuperoCollection RegistroRecuperoCollectionObj = new RegistroRecuperoCollection();

            IDbCommand findCmd = db.InitCmd("Zregistrorecuperofindgetcollectionreport", new string[] {"IdProgrammazioneequalthis", "IdProgettoequalthis", "DataAvvioeqgreaterthanthis",
"DataAvvioeqlessthanthis", "IdTipoRecuperoequalthis", "Recuperabileequalthis",
"Storicoequalthis"}, new string[] {"int", "int", "DateTime",
"DateTime", "int", "bool",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAvvioeqgreaterthanthis", DataAvvioEqGreaterThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAvvioeqlessthanthis", DataAvvioEqLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoRecuperoequalthis", IdTipoRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Recuperabileequalthis", RecuperabileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Storicoequalthis", StoricoEqualThis);
            RegistroRecupero RegistroRecuperoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroRecuperoObj = GetFromDatareader(db);
                RegistroRecuperoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroRecuperoObj.IsDirty = false;
                RegistroRecuperoObj.IsPersistent = true;
                RegistroRecuperoCollectionObj.Add(RegistroRecuperoObj);
            }
            db.Close();
            return RegistroRecuperoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for RegistroRecuperoCollectionProvider:IRegistroRecuperoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroRecuperoCollectionProvider : IRegistroRecuperoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di RegistroRecupero
        protected RegistroRecuperoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public RegistroRecuperoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new RegistroRecuperoCollection(this);
        }

        //Costruttore 2: popola la collection
        public RegistroRecuperoCollectionProvider(IntNT IdregistroirregolaritaEqualThis, BoolNT StoricoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = GetByRegistroIrregolarita(IdregistroirregolaritaEqualThis, StoricoEqualThis);
        }

        //Costruttore3: ha in input registrorecuperoCollectionObj - non popola la collection
        public RegistroRecuperoCollectionProvider(RegistroRecuperoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public RegistroRecuperoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new RegistroRecuperoCollection(this);
        }

        //Get e Set
        public RegistroRecuperoCollection CollectionObj
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
        public int SaveCollection(RegistroRecuperoCollection collectionObj)
        {
            return RegistroRecuperoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(RegistroRecupero registrorecuperoObj)
        {
            return RegistroRecuperoDAL.Save(_dbProviderObj, registrorecuperoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(RegistroRecuperoCollection collectionObj)
        {
            return RegistroRecuperoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(RegistroRecupero registrorecuperoObj)
        {
            return RegistroRecuperoDAL.Delete(_dbProviderObj, registrorecuperoObj);
        }

        //getById
        public RegistroRecupero GetById(IntNT IdRegistroRecuperoValue)
        {
            RegistroRecupero RegistroRecuperoTemp = RegistroRecuperoDAL.GetById(_dbProviderObj, IdRegistroRecuperoValue);
            if (RegistroRecuperoTemp != null) RegistroRecuperoTemp.Provider = this;
            return RegistroRecuperoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public RegistroRecuperoCollection Select(IntNT IdregistrorecuperoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdregistroirregolaritaEqualThis,
DatetimeNT DataavvioEqualThis, DatetimeNT DataprobabileconclusioneEqualThis, DecimalNT ImportodarecuperareueEqualThis,
DecimalNT ImportodarecuperarenazionaleEqualThis, DecimalNT ImportodarecuperarepubblicoEqualThis, DecimalNT ImportodarecuperareprivatoEqualThis,
DecimalNT ImportodarecuperaretotaleEqualThis, DecimalNT ImportodetrattoueEqualThis, DecimalNT ImportodetrattonazionaleEqualThis,
DecimalNT ImportodetrattopubblicoEqualThis, DecimalNT ImportodetrattoprivatoEqualThis, DecimalNT ImportodetrattototaleEqualThis,
DecimalNT ImportorecuperatoueEqualThis, DecimalNT ImportorecuperatonazionaleEqualThis, DecimalNT ImportorecuperatopubblicoEqualThis,
DecimalNT ImportorecuperatoprivatoEqualThis, DecimalNT ImportorecuperatototaleEqualThis, DecimalNT SaldodarecuperareueEqualThis,
DecimalNT SaldodarecuperarenazionaleEqualThis, DecimalNT SaldodarecuperarepubblicoEqualThis, DecimalNT SaldodarecuperareprivatoEqualThis,
DecimalNT SaldodarecuperaretotaleEqualThis, DecimalNT ImportoversatoueEqualThis, DecimalNT ImportoritenutostatoEqualThis,
DecimalNT ImportointeressimoraEqualThis, DecimalNT ImportointeressilegaliEqualThis, DecimalNT ImportogestionepraticaEqualThis,
DatetimeNT DataconclusioneEqualThis, IntNT IdprocedureavviateEqualThis, IntNT IdtipoprocedureavviateEqualThis,
DatetimeNT DataavvioprocedureEqualThis, DatetimeNT DataprobabileconclusioneprocedureEqualThis, IntNT IdtiporecuperoEqualThis,
IntNT IdoriginerecuperoEqualThis, IntNT IdstoricorecuperoprecedenteEqualThis, IntNT IdprogettoEqualThis,
BoolNT StoricoEqualThis, DatetimeNT DataregistrazioneritiroEqualThis, DatetimeNT DatacertificazionerecuperoEqualThis,
DatetimeNT DatacertificazioneritiroEqualThis, DatetimeNT DatacertificazionenonrecuperabilitaEqualThis, BoolNT GestionerateEqualThis,
IntNT NumerorateEqualThis, IntNT IntervalloratemesiEqualThis, DatetimeNT DatainiziorateEqualThis,
DecimalNT ImportorataEqualThis, StringNT SoggettorevocafinanziamentoEqualThis, IntNT IdattorecuperoEqualThis,
IntNT IdattoritiroEqualThis, IntNT IdattononrecuperabilitaEqualThis, BoolNT RecuperabileEqualThis,
DatetimeNT DataregistrazionenonrecuperabilitaEqualThis, DatetimeNT DatasegnaturaEqualThis, StringNT SegnaturaEqualThis)
        {
            RegistroRecuperoCollection RegistroRecuperoCollectionTemp = RegistroRecuperoDAL.Select(_dbProviderObj, IdregistrorecuperoEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis,
DatamodificaEqualThis, CfmodificaEqualThis, IdregistroirregolaritaEqualThis,
DataavvioEqualThis, DataprobabileconclusioneEqualThis, ImportodarecuperareueEqualThis,
ImportodarecuperarenazionaleEqualThis, ImportodarecuperarepubblicoEqualThis, ImportodarecuperareprivatoEqualThis,
ImportodarecuperaretotaleEqualThis, ImportodetrattoueEqualThis, ImportodetrattonazionaleEqualThis,
ImportodetrattopubblicoEqualThis, ImportodetrattoprivatoEqualThis, ImportodetrattototaleEqualThis,
ImportorecuperatoueEqualThis, ImportorecuperatonazionaleEqualThis, ImportorecuperatopubblicoEqualThis,
ImportorecuperatoprivatoEqualThis, ImportorecuperatototaleEqualThis, SaldodarecuperareueEqualThis,
SaldodarecuperarenazionaleEqualThis, SaldodarecuperarepubblicoEqualThis, SaldodarecuperareprivatoEqualThis,
SaldodarecuperaretotaleEqualThis, ImportoversatoueEqualThis, ImportoritenutostatoEqualThis,
ImportointeressimoraEqualThis, ImportointeressilegaliEqualThis, ImportogestionepraticaEqualThis,
DataconclusioneEqualThis, IdprocedureavviateEqualThis, IdtipoprocedureavviateEqualThis,
DataavvioprocedureEqualThis, DataprobabileconclusioneprocedureEqualThis, IdtiporecuperoEqualThis,
IdoriginerecuperoEqualThis, IdstoricorecuperoprecedenteEqualThis, IdprogettoEqualThis,
StoricoEqualThis, DataregistrazioneritiroEqualThis, DatacertificazionerecuperoEqualThis,
DatacertificazioneritiroEqualThis, DatacertificazionenonrecuperabilitaEqualThis, GestionerateEqualThis,
NumerorateEqualThis, IntervalloratemesiEqualThis, DatainiziorateEqualThis,
ImportorataEqualThis, SoggettorevocafinanziamentoEqualThis, IdattorecuperoEqualThis,
IdattoritiroEqualThis, IdattononrecuperabilitaEqualThis, RecuperabileEqualThis,
DataregistrazionenonrecuperabilitaEqualThis, DatasegnaturaEqualThis, SegnaturaEqualThis);
            RegistroRecuperoCollectionTemp.Provider = this;
            return RegistroRecuperoCollectionTemp;
        }

        //GetByRegistroIrregolarita: popola la collection
        public RegistroRecuperoCollection GetByRegistroIrregolarita(IntNT IdregistroirregolaritaEqualThis, BoolNT StoricoEqualThis)
        {
            RegistroRecuperoCollection RegistroRecuperoCollectionTemp = RegistroRecuperoDAL.GetByRegistroIrregolarita(_dbProviderObj, IdregistroirregolaritaEqualThis, StoricoEqualThis);
            RegistroRecuperoCollectionTemp.Provider = this;
            return RegistroRecuperoCollectionTemp;
        }

        //GetByIdProgetto: popola la collection
        public RegistroRecuperoCollection GetByIdProgetto(IntNT IdprogettoEqualThis, BoolNT StoricoEqualThis)
        {
            RegistroRecuperoCollection RegistroRecuperoCollectionTemp = RegistroRecuperoDAL.GetByIdProgetto(_dbProviderObj, IdprogettoEqualThis, StoricoEqualThis);
            RegistroRecuperoCollectionTemp.Provider = this;
            return RegistroRecuperoCollectionTemp;
        }

        //GetCollectionReport: popola la collection
        public RegistroRecuperoCollection GetCollectionReport(IntNT IdprogrammazioneEqualThis, IntNT IdprogettoEqualThis, DatetimeNT DataavvioEqGreaterThanThis,
DatetimeNT DataavvioEqLessThanThis, IntNT IdtiporecuperoEqualThis, BoolNT RecuperabileEqualThis,
BoolNT StoricoEqualThis)
        {
            RegistroRecuperoCollection RegistroRecuperoCollectionTemp = RegistroRecuperoDAL.GetCollectionReport(_dbProviderObj, IdprogrammazioneEqualThis, IdprogettoEqualThis, DataavvioEqGreaterThanThis,
DataavvioEqLessThanThis, IdtiporecuperoEqualThis, RecuperabileEqualThis,
StoricoEqualThis);
            RegistroRecuperoCollectionTemp.Provider = this;
            return RegistroRecuperoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REGISTRO_RECUPERO>
  <ViewName>VREGISTRO_RECUPERO</ViewName>
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
    <GetByRegistroIrregolarita OrderBy="ORDER BY ">
      <ID_REGISTRO_IRREGOLARITA>Equal</ID_REGISTRO_IRREGOLARITA>
      <STORICO>Equal</STORICO>
    </GetByRegistroIrregolarita>
    <GetByIdProgetto OrderBy="ORDER BY ">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <STORICO>Equal</STORICO>
    </GetByIdProgetto>
    <GetCollectionReport OrderBy="ORDER BY ">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <DATA_AVVIO>EqGreaterThan</DATA_AVVIO>
      <DATA_AVVIO>EqLessThan</DATA_AVVIO>
      <ID_TIPO_RECUPERO>Equal</ID_TIPO_RECUPERO>
      <RECUPERABILE>Equal</RECUPERABILE>
      <STORICO>Equal</STORICO>
    </GetCollectionReport>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REGISTRO_RECUPERO>
*/
