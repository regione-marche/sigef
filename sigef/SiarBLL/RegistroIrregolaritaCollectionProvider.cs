using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per RegistroIrregolarita
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IRegistroIrregolaritaProvider
    {
        int Save(RegistroIrregolarita RegistroIrregolaritaObj);
        int SaveCollection(RegistroIrregolaritaCollection collectionObj);
        int Delete(RegistroIrregolarita RegistroIrregolaritaObj);
        int DeleteCollection(RegistroIrregolaritaCollection collectionObj);
    }
    /// <summary>
    /// Summary description for RegistroIrregolarita
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class RegistroIrregolarita : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.BoolNT _SegnalazioneOlaf;
        private NullTypes.DatetimeNT _DataSegnalazione;
        private NullTypes.StringNT _TrimestreSegnalazione;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdIrregolarita;
        private NullTypes.StringNT _NumeroRiferimentoOlaf;
        private NullTypes.BoolNT _SospettoFrode;
        private NullTypes.DecimalNT _ImportoIrregolareCertificato;
        private NullTypes.DecimalNT _ImportoIrregolareDaRecuperare;
        private NullTypes.IntNT _Anno;
        private NullTypes.StringNT _PeriodoProgrammazione;
        private NullTypes.StringNT _NumeroRiferimentoNazionale;
        private NullTypes.BoolNT _AzionePenale;
        private NullTypes.DatetimeNT _DataCreazioneIdentificazione;
        private NullTypes.StringNT _TrimestreIdentificazione;
        private NullTypes.BoolNT _ProcedimentoAmministrativo;
        private NullTypes.BoolNT _AzioneGiudiziaria;
        private NullTypes.DatetimeNT _DataPrimaInformazioneSospetto;
        private NullTypes.StringNT _FontePrimaInformazioneSospetto;
        private NullTypes.DatetimeNT _DataIrregolarita;
        private NullTypes.DatetimeNT _DataIrregolaritaDa;
        private NullTypes.DatetimeNT _DataIrregolaritaA;
        private NullTypes.StringNT _CommessaA;
        private NullTypes.IntNT _IdCategoriaIrregolarita;
        private NullTypes.IntNT _IdTipoIrregolarita;
        private NullTypes.StringNT _ModusOperandi;
        private NullTypes.StringNT _DichiarazioneOperatore;
        private NullTypes.StringNT _AccertamentiAmministratore;
        private NullTypes.IntNT _IdClassificazioneIrregolarita;
        private NullTypes.DatetimeNT _DataPrimoAttoConstatazioneAmministrativo;
        private NullTypes.IntNT _IdMotivoEsecuzioneControllo;
        private NullTypes.IntNT _IdTipoControllo;
        private NullTypes.IntNT _IdControlloPrimaDopoPagamento;
        private NullTypes.StringNT _AutoritaControllo;
        private NullTypes.BoolNT _IndagineOlaf;
        private NullTypes.DecimalNT _ImportoSpesaUe;
        private NullTypes.DecimalNT _ImportoSpesaNazionale;
        private NullTypes.DecimalNT _ImportoSpesaPubblico;
        private NullTypes.DecimalNT _ImportoSpesaPrivato;
        private NullTypes.DecimalNT _ImportoSpesaTotale;
        private NullTypes.DecimalNT _ImportoIrregolaritaUe;
        private NullTypes.DecimalNT _ImportoIrregolaritaNazionale;
        private NullTypes.DecimalNT _ImportoIrregolaritaPubblico;
        private NullTypes.DecimalNT _ImportoIrregolaritaPrivato;
        private NullTypes.DecimalNT _ImportoIrregolaritaTotale;
        private NullTypes.DecimalNT _ImportoIrregolaritaNonPagatoUe;
        private NullTypes.DecimalNT _ImportoIrregolaritaNonPagatoNazionale;
        private NullTypes.DecimalNT _ImportoIrregolaritaNonPagatoPubblico;
        private NullTypes.DecimalNT _ImportoIrregolaritaNonPagatoPrivato;
        private NullTypes.DecimalNT _ImportoIrregolaritaNonPagatoTotale;
        private NullTypes.DecimalNT _ImportoIrregolaritaPagatoUe;
        private NullTypes.DecimalNT _ImportoIrregolaritaPagatoNazionale;
        private NullTypes.DecimalNT _ImportoIrregolaritaPagatoPubblico;
        private NullTypes.DecimalNT _ImportoIrregolaritaPagatoPrivato;
        private NullTypes.DecimalNT _ImportoIrregolaritaPagatoTotale;
        private NullTypes.DecimalNT _ImportoDaRecuperareUe;
        private NullTypes.DecimalNT _ImportoDaRecuperareNazionale;
        private NullTypes.DecimalNT _ImportoDaRecuperarePubblico;
        private NullTypes.DecimalNT _ImportoDaRecuperarePrivato;
        private NullTypes.DecimalNT _ImportoDaRecuperareTotale;
        private NullTypes.BoolNT _SpesaDecertificata;
        private NullTypes.StringNT _CommentiImpattoFinanziario;
        private NullTypes.IntNT _IdBando;
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
        private NullTypes.IntNT _IdFondo;
        private NullTypes.IntNT _IdControlloOrigine;
        private NullTypes.IntNT _IdStatoFinanziario;
        private NullTypes.StringNT _DescrizioneControlloEsterno;
        private NullTypes.IntNT _IdImpresaCommessaDa;
        private NullTypes.StringNT _NoteCommessaDa;
        private NullTypes.BoolNT _StabilitaOperazioni;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdImpresaProgetto;
        [NonSerialized]
        private IRegistroIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroIrregolaritaProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public RegistroIrregolarita()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:SEGNALAZIONE_OLAF
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SegnalazioneOlaf
        {
            get { return _SegnalazioneOlaf; }
            set
            {
                if (SegnalazioneOlaf != value)
                {
                    _SegnalazioneOlaf = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SEGNALAZIONE
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataSegnalazione
        {
            get { return _DataSegnalazione; }
            set
            {
                if (DataSegnalazione != value)
                {
                    _DataSegnalazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TRIMESTRE_SEGNALAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TrimestreSegnalazione
        {
            get { return _TrimestreSegnalazione; }
            set
            {
                if (TrimestreSegnalazione != value)
                {
                    _TrimestreSegnalazione = value;
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
        /// Corrisponde al campo:ID_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIrregolarita
        {
            get { return _IdIrregolarita; }
            set
            {
                if (IdIrregolarita != value)
                {
                    _IdIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_RIFERIMENTO_OLAF
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT NumeroRiferimentoOlaf
        {
            get { return _NumeroRiferimentoOlaf; }
            set
            {
                if (NumeroRiferimentoOlaf != value)
                {
                    _NumeroRiferimentoOlaf = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SOSPETTO_FRODE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SospettoFrode
        {
            get { return _SospettoFrode; }
            set
            {
                if (SospettoFrode != value)
                {
                    _SospettoFrode = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARE_CERTIFICATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolareCertificato
        {
            get { return _ImportoIrregolareCertificato; }
            set
            {
                if (ImportoIrregolareCertificato != value)
                {
                    _ImportoIrregolareCertificato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARE_DA_RECUPERARE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolareDaRecuperare
        {
            get { return _ImportoIrregolareDaRecuperare; }
            set
            {
                if (ImportoIrregolareDaRecuperare != value)
                {
                    _ImportoIrregolareDaRecuperare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ANNO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Anno
        {
            get { return _Anno; }
            set
            {
                if (Anno != value)
                {
                    _Anno = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PERIODO_PROGRAMMAZIONE
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT PeriodoProgrammazione
        {
            get { return _PeriodoProgrammazione; }
            set
            {
                if (PeriodoProgrammazione != value)
                {
                    _PeriodoProgrammazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_RIFERIMENTO_NAZIONALE
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT NumeroRiferimentoNazionale
        {
            get { return _NumeroRiferimentoNazionale; }
            set
            {
                if (NumeroRiferimentoNazionale != value)
                {
                    _NumeroRiferimentoNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AZIONE_PENALE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AzionePenale
        {
            get { return _AzionePenale; }
            set
            {
                if (AzionePenale != value)
                {
                    _AzionePenale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_CREAZIONE_IDENTIFICAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataCreazioneIdentificazione
        {
            get { return _DataCreazioneIdentificazione; }
            set
            {
                if (DataCreazioneIdentificazione != value)
                {
                    _DataCreazioneIdentificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TRIMESTRE_IDENTIFICAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT TrimestreIdentificazione
        {
            get { return _TrimestreIdentificazione; }
            set
            {
                if (TrimestreIdentificazione != value)
                {
                    _TrimestreIdentificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROCEDIMENTO_AMMINISTRATIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT ProcedimentoAmministrativo
        {
            get { return _ProcedimentoAmministrativo; }
            set
            {
                if (ProcedimentoAmministrativo != value)
                {
                    _ProcedimentoAmministrativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AZIONE_GIUDIZIARIA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AzioneGiudiziaria
        {
            get { return _AzioneGiudiziaria; }
            set
            {
                if (AzioneGiudiziaria != value)
                {
                    _AzioneGiudiziaria = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PRIMA_INFORMAZIONE_SOSPETTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPrimaInformazioneSospetto
        {
            get { return _DataPrimaInformazioneSospetto; }
            set
            {
                if (DataPrimaInformazioneSospetto != value)
                {
                    _DataPrimaInformazioneSospetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FONTE_PRIMA_INFORMAZIONE_SOSPETTO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT FontePrimaInformazioneSospetto
        {
            get { return _FontePrimaInformazioneSospetto; }
            set
            {
                if (FontePrimaInformazioneSospetto != value)
                {
                    _FontePrimaInformazioneSospetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_IRREGOLARITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataIrregolarita
        {
            get { return _DataIrregolarita; }
            set
            {
                if (DataIrregolarita != value)
                {
                    _DataIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_IRREGOLARITA_DA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataIrregolaritaDa
        {
            get { return _DataIrregolaritaDa; }
            set
            {
                if (DataIrregolaritaDa != value)
                {
                    _DataIrregolaritaDa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_IRREGOLARITA_A
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataIrregolaritaA
        {
            get { return _DataIrregolaritaA; }
            set
            {
                if (DataIrregolaritaA != value)
                {
                    _DataIrregolaritaA = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COMMESSA_A
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT CommessaA
        {
            get { return _CommessaA; }
            set
            {
                if (CommessaA != value)
                {
                    _CommessaA = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CATEGORIA_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdCategoriaIrregolarita
        {
            get { return _IdCategoriaIrregolarita; }
            set
            {
                if (IdCategoriaIrregolarita != value)
                {
                    _IdCategoriaIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoIrregolarita
        {
            get { return _IdTipoIrregolarita; }
            set
            {
                if (IdTipoIrregolarita != value)
                {
                    _IdTipoIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MODUS_OPERANDI
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT ModusOperandi
        {
            get { return _ModusOperandi; }
            set
            {
                if (ModusOperandi != value)
                {
                    _ModusOperandi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DICHIARAZIONE_OPERATORE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DichiarazioneOperatore
        {
            get { return _DichiarazioneOperatore; }
            set
            {
                if (DichiarazioneOperatore != value)
                {
                    _DichiarazioneOperatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ACCERTAMENTI_AMMINISTRATORE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT AccertamentiAmministratore
        {
            get { return _AccertamentiAmministratore; }
            set
            {
                if (AccertamentiAmministratore != value)
                {
                    _AccertamentiAmministratore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CLASSIFICAZIONE_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdClassificazioneIrregolarita
        {
            get { return _IdClassificazioneIrregolarita; }
            set
            {
                if (IdClassificazioneIrregolarita != value)
                {
                    _IdClassificazioneIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPrimoAttoConstatazioneAmministrativo
        {
            get { return _DataPrimoAttoConstatazioneAmministrativo; }
            set
            {
                if (DataPrimoAttoConstatazioneAmministrativo != value)
                {
                    _DataPrimoAttoConstatazioneAmministrativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_MOTIVO_ESECUZIONE_CONTROLLO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdMotivoEsecuzioneControllo
        {
            get { return _IdMotivoEsecuzioneControllo; }
            set
            {
                if (IdMotivoEsecuzioneControllo != value)
                {
                    _IdMotivoEsecuzioneControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_TIPO_CONTROLLO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdTipoControllo
        {
            get { return _IdTipoControllo; }
            set
            {
                if (IdTipoControllo != value)
                {
                    _IdTipoControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdControlloPrimaDopoPagamento
        {
            get { return _IdControlloPrimaDopoPagamento; }
            set
            {
                if (IdControlloPrimaDopoPagamento != value)
                {
                    _IdControlloPrimaDopoPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AUTORITA_CONTROLLO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT AutoritaControllo
        {
            get { return _AutoritaControllo; }
            set
            {
                if (AutoritaControllo != value)
                {
                    _AutoritaControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INDAGINE_OLAF
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IndagineOlaf
        {
            get { return _IndagineOlaf; }
            set
            {
                if (IndagineOlaf != value)
                {
                    _IndagineOlaf = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SPESA_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSpesaUe
        {
            get { return _ImportoSpesaUe; }
            set
            {
                if (ImportoSpesaUe != value)
                {
                    _ImportoSpesaUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SPESA_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSpesaNazionale
        {
            get { return _ImportoSpesaNazionale; }
            set
            {
                if (ImportoSpesaNazionale != value)
                {
                    _ImportoSpesaNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SPESA_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSpesaPubblico
        {
            get { return _ImportoSpesaPubblico; }
            set
            {
                if (ImportoSpesaPubblico != value)
                {
                    _ImportoSpesaPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SPESA_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSpesaPrivato
        {
            get { return _ImportoSpesaPrivato; }
            set
            {
                if (ImportoSpesaPrivato != value)
                {
                    _ImportoSpesaPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_SPESA_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoSpesaTotale
        {
            get { return _ImportoSpesaTotale; }
            set
            {
                if (ImportoSpesaTotale != value)
                {
                    _ImportoSpesaTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaUe
        {
            get { return _ImportoIrregolaritaUe; }
            set
            {
                if (ImportoIrregolaritaUe != value)
                {
                    _ImportoIrregolaritaUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNazionale
        {
            get { return _ImportoIrregolaritaNazionale; }
            set
            {
                if (ImportoIrregolaritaNazionale != value)
                {
                    _ImportoIrregolaritaNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPubblico
        {
            get { return _ImportoIrregolaritaPubblico; }
            set
            {
                if (ImportoIrregolaritaPubblico != value)
                {
                    _ImportoIrregolaritaPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPrivato
        {
            get { return _ImportoIrregolaritaPrivato; }
            set
            {
                if (ImportoIrregolaritaPrivato != value)
                {
                    _ImportoIrregolaritaPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaTotale
        {
            get { return _ImportoIrregolaritaTotale; }
            set
            {
                if (ImportoIrregolaritaTotale != value)
                {
                    _ImportoIrregolaritaTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NON_PAGATO_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNonPagatoUe
        {
            get { return _ImportoIrregolaritaNonPagatoUe; }
            set
            {
                if (ImportoIrregolaritaNonPagatoUe != value)
                {
                    _ImportoIrregolaritaNonPagatoUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNonPagatoNazionale
        {
            get { return _ImportoIrregolaritaNonPagatoNazionale; }
            set
            {
                if (ImportoIrregolaritaNonPagatoNazionale != value)
                {
                    _ImportoIrregolaritaNonPagatoNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPubblico
        {
            get { return _ImportoIrregolaritaNonPagatoPubblico; }
            set
            {
                if (ImportoIrregolaritaNonPagatoPubblico != value)
                {
                    _ImportoIrregolaritaNonPagatoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPrivato
        {
            get { return _ImportoIrregolaritaNonPagatoPrivato; }
            set
            {
                if (ImportoIrregolaritaNonPagatoPrivato != value)
                {
                    _ImportoIrregolaritaNonPagatoPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaNonPagatoTotale
        {
            get { return _ImportoIrregolaritaNonPagatoTotale; }
            set
            {
                if (ImportoIrregolaritaNonPagatoTotale != value)
                {
                    _ImportoIrregolaritaNonPagatoTotale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PAGATO_UE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPagatoUe
        {
            get { return _ImportoIrregolaritaPagatoUe; }
            set
            {
                if (ImportoIrregolaritaPagatoUe != value)
                {
                    _ImportoIrregolaritaPagatoUe = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPagatoNazionale
        {
            get { return _ImportoIrregolaritaPagatoNazionale; }
            set
            {
                if (ImportoIrregolaritaPagatoNazionale != value)
                {
                    _ImportoIrregolaritaPagatoNazionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPagatoPubblico
        {
            get { return _ImportoIrregolaritaPagatoPubblico; }
            set
            {
                if (ImportoIrregolaritaPagatoPubblico != value)
                {
                    _ImportoIrregolaritaPagatoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PAGATO_PRIVATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPagatoPrivato
        {
            get { return _ImportoIrregolaritaPagatoPrivato; }
            set
            {
                if (ImportoIrregolaritaPagatoPrivato != value)
                {
                    _ImportoIrregolaritaPagatoPrivato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRREGOLARITA_PAGATO_TOTALE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrregolaritaPagatoTotale
        {
            get { return _ImportoIrregolaritaPagatoTotale; }
            set
            {
                if (ImportoIrregolaritaPagatoTotale != value)
                {
                    _ImportoIrregolaritaPagatoTotale = value;
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
        /// Corrisponde al campo:SPESA_DECERTIFICATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SpesaDecertificata
        {
            get { return _SpesaDecertificata; }
            set
            {
                if (SpesaDecertificata != value)
                {
                    _SpesaDecertificata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COMMENTI_IMPATTO_FINANZIARIO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT CommentiImpattoFinanziario
        {
            get { return _CommentiImpattoFinanziario; }
            set
            {
                if (CommentiImpattoFinanziario != value)
                {
                    _CommentiImpattoFinanziario = value;
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
        /// Corrisponde al campo:ID_FONDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFondo
        {
            get { return _IdFondo; }
            set
            {
                if (IdFondo != value)
                {
                    _IdFondo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CONTROLLO_ORIGINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdControlloOrigine
        {
            get { return _IdControlloOrigine; }
            set
            {
                if (IdControlloOrigine != value)
                {
                    _IdControlloOrigine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STATO_FINANZIARIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStatoFinanziario
        {
            get { return _IdStatoFinanziario; }
            set
            {
                if (IdStatoFinanziario != value)
                {
                    _IdStatoFinanziario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE_CONTROLLO_ESTERNO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT DescrizioneControlloEsterno
        {
            get { return _DescrizioneControlloEsterno; }
            set
            {
                if (DescrizioneControlloEsterno != value)
                {
                    _DescrizioneControlloEsterno = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA_COMMESSA_DA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaCommessaDa
        {
            get { return _IdImpresaCommessaDa; }
            set
            {
                if (IdImpresaCommessaDa != value)
                {
                    _IdImpresaCommessaDa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE_COMMESSA_DA
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT NoteCommessaDa
        {
            get { return _NoteCommessaDa; }
            set
            {
                if (NoteCommessaDa != value)
                {
                    _NoteCommessaDa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STABILITA_OPERAZIONI
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT StabilitaOperazioni
        {
            get { return _StabilitaOperazioni; }
            set
            {
                if (StabilitaOperazioni != value)
                {
                    _StabilitaOperazioni = value;
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
        /// Corrisponde al campo:ID_IMPRESA_PROGETTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaProgetto
        {
            get { return _IdImpresaProgetto; }
            set
            {
                if (IdImpresaProgetto != value)
                {
                    _IdImpresaProgetto = value;
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
    /// Summary description for RegistroIrregolaritaCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroIrregolaritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private RegistroIrregolaritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((RegistroIrregolarita)info.GetValue(i.ToString(), typeof(RegistroIrregolarita)));
            }
        }

        //Costruttore
        public RegistroIrregolaritaCollection()
        {
            this.ItemType = typeof(RegistroIrregolarita);
        }

        //Costruttore con provider
        public RegistroIrregolaritaCollection(IRegistroIrregolaritaProvider providerObj)
        {
            this.ItemType = typeof(RegistroIrregolarita);
            this.Provider = providerObj;
        }

        //Get e Set
        public new RegistroIrregolarita this[int index]
        {
            get { return (RegistroIrregolarita)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new RegistroIrregolaritaCollection GetChanges()
        {
            return (RegistroIrregolaritaCollection)base.GetChanges();
        }

        [NonSerialized]
        private IRegistroIrregolaritaProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRegistroIrregolaritaProvider Provider
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
        public int Add(RegistroIrregolarita RegistroIrregolaritaObj)
        {
            if (RegistroIrregolaritaObj.Provider == null) RegistroIrregolaritaObj.Provider = this.Provider;
            return base.Add(RegistroIrregolaritaObj);
        }

        //AddCollection
        public void AddCollection(RegistroIrregolaritaCollection RegistroIrregolaritaCollectionObj)
        {
            foreach (RegistroIrregolarita RegistroIrregolaritaObj in RegistroIrregolaritaCollectionObj)
                this.Add(RegistroIrregolaritaObj);
        }

        //Insert
        public void Insert(int index, RegistroIrregolarita RegistroIrregolaritaObj)
        {
            if (RegistroIrregolaritaObj.Provider == null) RegistroIrregolaritaObj.Provider = this.Provider;
            base.Insert(index, RegistroIrregolaritaObj);
        }

        //CollectionGetById
        public RegistroIrregolarita CollectionGetById(NullTypes.IntNT IdIrregolaritaValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdIrregolarita == IdIrregolaritaValue))
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
        public RegistroIrregolaritaCollection SubSelect(NullTypes.IntNT IdIrregolaritaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdControlloOrigineEqualThis, NullTypes.StringNT DescrizioneControlloEsternoEqualThis,
NullTypes.BoolNT SegnalazioneOlafEqualThis, NullTypes.DatetimeNT DataSegnalazioneEqualThis, NullTypes.StringNT TrimestreSegnalazioneEqualThis,
NullTypes.StringNT NumeroRiferimentoOlafEqualThis, NullTypes.BoolNT SospettoFrodeEqualThis, NullTypes.DecimalNT ImportoIrregolareCertificatoEqualThis,
NullTypes.DecimalNT ImportoIrregolareDaRecuperareEqualThis, NullTypes.IntNT IdFondoEqualThis, NullTypes.IntNT AnnoEqualThis,
NullTypes.StringNT PeriodoProgrammazioneEqualThis, NullTypes.StringNT NumeroRiferimentoNazionaleEqualThis, NullTypes.DatetimeNT DataCreazioneIdentificazioneEqualThis,
NullTypes.StringNT TrimestreIdentificazioneEqualThis, NullTypes.BoolNT ProcedimentoAmministrativoEqualThis, NullTypes.BoolNT AzioneGiudiziariaEqualThis,
NullTypes.BoolNT AzionePenaleEqualThis, NullTypes.IntNT IdStatoFinanziarioEqualThis, NullTypes.DatetimeNT DataPrimaInformazioneSospettoEqualThis,
NullTypes.StringNT FontePrimaInformazioneSospettoEqualThis, NullTypes.DatetimeNT DataIrregolaritaEqualThis, NullTypes.DatetimeNT DataIrregolaritaDaEqualThis,
NullTypes.DatetimeNT DataIrregolaritaAEqualThis, NullTypes.IntNT IdImpresaCommessaDaEqualThis, NullTypes.StringNT NoteCommessaDaEqualThis,
NullTypes.StringNT CommessaAEqualThis, NullTypes.IntNT IdCategoriaIrregolaritaEqualThis, NullTypes.IntNT IdTipoIrregolaritaEqualThis,
NullTypes.StringNT ModusOperandiEqualThis, NullTypes.StringNT DichiarazioneOperatoreEqualThis, NullTypes.StringNT AccertamentiAmministratoreEqualThis,
NullTypes.IntNT IdClassificazioneIrregolaritaEqualThis, NullTypes.DatetimeNT DataPrimoAttoConstatazioneAmministrativoEqualThis, NullTypes.IntNT IdMotivoEsecuzioneControlloEqualThis,
NullTypes.IntNT IdTipoControlloEqualThis, NullTypes.IntNT IdControlloPrimaDopoPagamentoEqualThis, NullTypes.StringNT AutoritaControlloEqualThis,
NullTypes.BoolNT IndagineOlafEqualThis, NullTypes.DecimalNT ImportoSpesaUeEqualThis, NullTypes.DecimalNT ImportoSpesaNazionaleEqualThis,
NullTypes.DecimalNT ImportoSpesaPubblicoEqualThis, NullTypes.DecimalNT ImportoSpesaPrivatoEqualThis, NullTypes.DecimalNT ImportoSpesaTotaleEqualThis,
NullTypes.DecimalNT ImportoIrregolaritaUeEqualThis, NullTypes.DecimalNT ImportoIrregolaritaNazionaleEqualThis, NullTypes.DecimalNT ImportoIrregolaritaPubblicoEqualThis,
NullTypes.DecimalNT ImportoIrregolaritaPrivatoEqualThis, NullTypes.DecimalNT ImportoIrregolaritaTotaleEqualThis, NullTypes.DecimalNT ImportoIrregolaritaNonPagatoUeEqualThis,
NullTypes.DecimalNT ImportoIrregolaritaNonPagatoNazionaleEqualThis, NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPubblicoEqualThis, NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPrivatoEqualThis,
NullTypes.DecimalNT ImportoIrregolaritaNonPagatoTotaleEqualThis, NullTypes.DecimalNT ImportoIrregolaritaPagatoUeEqualThis, NullTypes.DecimalNT ImportoIrregolaritaPagatoNazionaleEqualThis,
NullTypes.DecimalNT ImportoIrregolaritaPagatoPubblicoEqualThis, NullTypes.DecimalNT ImportoIrregolaritaPagatoPrivatoEqualThis, NullTypes.DecimalNT ImportoIrregolaritaPagatoTotaleEqualThis,
NullTypes.DecimalNT ImportoDaRecuperareUeEqualThis, NullTypes.DecimalNT ImportoDaRecuperareNazionaleEqualThis, NullTypes.DecimalNT ImportoDaRecuperarePubblicoEqualThis,
NullTypes.DecimalNT ImportoDaRecuperarePrivatoEqualThis, NullTypes.DecimalNT ImportoDaRecuperareTotaleEqualThis, NullTypes.BoolNT SpesaDecertificataEqualThis,
NullTypes.StringNT CommentiImpattoFinanziarioEqualThis, NullTypes.BoolNT StabilitaOperazioniEqualThis)
        {
            RegistroIrregolaritaCollection RegistroIrregolaritaCollectionTemp = new RegistroIrregolaritaCollection();
            foreach (RegistroIrregolarita RegistroIrregolaritaItem in this)
            {
                if (((IdIrregolaritaEqualThis == null) || ((RegistroIrregolaritaItem.IdIrregolarita != null) && (RegistroIrregolaritaItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RegistroIrregolaritaItem.IdProgetto != null) && (RegistroIrregolaritaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((RegistroIrregolaritaItem.IdDomandaPagamento != null) && (RegistroIrregolaritaItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((RegistroIrregolaritaItem.CfInserimento != null) && (RegistroIrregolaritaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RegistroIrregolaritaItem.DataInserimento != null) && (RegistroIrregolaritaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfModificaEqualThis == null) || ((RegistroIrregolaritaItem.CfModifica != null) && (RegistroIrregolaritaItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((RegistroIrregolaritaItem.DataModifica != null) && (RegistroIrregolaritaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdControlloOrigineEqualThis == null) || ((RegistroIrregolaritaItem.IdControlloOrigine != null) && (RegistroIrregolaritaItem.IdControlloOrigine.Value == IdControlloOrigineEqualThis.Value))) && ((DescrizioneControlloEsternoEqualThis == null) || ((RegistroIrregolaritaItem.DescrizioneControlloEsterno != null) && (RegistroIrregolaritaItem.DescrizioneControlloEsterno.Value == DescrizioneControlloEsternoEqualThis.Value))) &&
((SegnalazioneOlafEqualThis == null) || ((RegistroIrregolaritaItem.SegnalazioneOlaf != null) && (RegistroIrregolaritaItem.SegnalazioneOlaf.Value == SegnalazioneOlafEqualThis.Value))) && ((DataSegnalazioneEqualThis == null) || ((RegistroIrregolaritaItem.DataSegnalazione != null) && (RegistroIrregolaritaItem.DataSegnalazione.Value == DataSegnalazioneEqualThis.Value))) && ((TrimestreSegnalazioneEqualThis == null) || ((RegistroIrregolaritaItem.TrimestreSegnalazione != null) && (RegistroIrregolaritaItem.TrimestreSegnalazione.Value == TrimestreSegnalazioneEqualThis.Value))) &&
((NumeroRiferimentoOlafEqualThis == null) || ((RegistroIrregolaritaItem.NumeroRiferimentoOlaf != null) && (RegistroIrregolaritaItem.NumeroRiferimentoOlaf.Value == NumeroRiferimentoOlafEqualThis.Value))) && ((SospettoFrodeEqualThis == null) || ((RegistroIrregolaritaItem.SospettoFrode != null) && (RegistroIrregolaritaItem.SospettoFrode.Value == SospettoFrodeEqualThis.Value))) && ((ImportoIrregolareCertificatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolareCertificato != null) && (RegistroIrregolaritaItem.ImportoIrregolareCertificato.Value == ImportoIrregolareCertificatoEqualThis.Value))) &&
((ImportoIrregolareDaRecuperareEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolareDaRecuperare != null) && (RegistroIrregolaritaItem.ImportoIrregolareDaRecuperare.Value == ImportoIrregolareDaRecuperareEqualThis.Value))) && ((IdFondoEqualThis == null) || ((RegistroIrregolaritaItem.IdFondo != null) && (RegistroIrregolaritaItem.IdFondo.Value == IdFondoEqualThis.Value))) && ((AnnoEqualThis == null) || ((RegistroIrregolaritaItem.Anno != null) && (RegistroIrregolaritaItem.Anno.Value == AnnoEqualThis.Value))) &&
((PeriodoProgrammazioneEqualThis == null) || ((RegistroIrregolaritaItem.PeriodoProgrammazione != null) && (RegistroIrregolaritaItem.PeriodoProgrammazione.Value == PeriodoProgrammazioneEqualThis.Value))) && ((NumeroRiferimentoNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.NumeroRiferimentoNazionale != null) && (RegistroIrregolaritaItem.NumeroRiferimentoNazionale.Value == NumeroRiferimentoNazionaleEqualThis.Value))) && ((DataCreazioneIdentificazioneEqualThis == null) || ((RegistroIrregolaritaItem.DataCreazioneIdentificazione != null) && (RegistroIrregolaritaItem.DataCreazioneIdentificazione.Value == DataCreazioneIdentificazioneEqualThis.Value))) &&
((TrimestreIdentificazioneEqualThis == null) || ((RegistroIrregolaritaItem.TrimestreIdentificazione != null) && (RegistroIrregolaritaItem.TrimestreIdentificazione.Value == TrimestreIdentificazioneEqualThis.Value))) && ((ProcedimentoAmministrativoEqualThis == null) || ((RegistroIrregolaritaItem.ProcedimentoAmministrativo != null) && (RegistroIrregolaritaItem.ProcedimentoAmministrativo.Value == ProcedimentoAmministrativoEqualThis.Value))) && ((AzioneGiudiziariaEqualThis == null) || ((RegistroIrregolaritaItem.AzioneGiudiziaria != null) && (RegistroIrregolaritaItem.AzioneGiudiziaria.Value == AzioneGiudiziariaEqualThis.Value))) &&
((AzionePenaleEqualThis == null) || ((RegistroIrregolaritaItem.AzionePenale != null) && (RegistroIrregolaritaItem.AzionePenale.Value == AzionePenaleEqualThis.Value))) && ((IdStatoFinanziarioEqualThis == null) || ((RegistroIrregolaritaItem.IdStatoFinanziario != null) && (RegistroIrregolaritaItem.IdStatoFinanziario.Value == IdStatoFinanziarioEqualThis.Value))) && ((DataPrimaInformazioneSospettoEqualThis == null) || ((RegistroIrregolaritaItem.DataPrimaInformazioneSospetto != null) && (RegistroIrregolaritaItem.DataPrimaInformazioneSospetto.Value == DataPrimaInformazioneSospettoEqualThis.Value))) &&
((FontePrimaInformazioneSospettoEqualThis == null) || ((RegistroIrregolaritaItem.FontePrimaInformazioneSospetto != null) && (RegistroIrregolaritaItem.FontePrimaInformazioneSospetto.Value == FontePrimaInformazioneSospettoEqualThis.Value))) && ((DataIrregolaritaEqualThis == null) || ((RegistroIrregolaritaItem.DataIrregolarita != null) && (RegistroIrregolaritaItem.DataIrregolarita.Value == DataIrregolaritaEqualThis.Value))) && ((DataIrregolaritaDaEqualThis == null) || ((RegistroIrregolaritaItem.DataIrregolaritaDa != null) && (RegistroIrregolaritaItem.DataIrregolaritaDa.Value == DataIrregolaritaDaEqualThis.Value))) &&
((DataIrregolaritaAEqualThis == null) || ((RegistroIrregolaritaItem.DataIrregolaritaA != null) && (RegistroIrregolaritaItem.DataIrregolaritaA.Value == DataIrregolaritaAEqualThis.Value))) && ((IdImpresaCommessaDaEqualThis == null) || ((RegistroIrregolaritaItem.IdImpresaCommessaDa != null) && (RegistroIrregolaritaItem.IdImpresaCommessaDa.Value == IdImpresaCommessaDaEqualThis.Value))) && ((NoteCommessaDaEqualThis == null) || ((RegistroIrregolaritaItem.NoteCommessaDa != null) && (RegistroIrregolaritaItem.NoteCommessaDa.Value == NoteCommessaDaEqualThis.Value))) &&
((CommessaAEqualThis == null) || ((RegistroIrregolaritaItem.CommessaA != null) && (RegistroIrregolaritaItem.CommessaA.Value == CommessaAEqualThis.Value))) && ((IdCategoriaIrregolaritaEqualThis == null) || ((RegistroIrregolaritaItem.IdCategoriaIrregolarita != null) && (RegistroIrregolaritaItem.IdCategoriaIrregolarita.Value == IdCategoriaIrregolaritaEqualThis.Value))) && ((IdTipoIrregolaritaEqualThis == null) || ((RegistroIrregolaritaItem.IdTipoIrregolarita != null) && (RegistroIrregolaritaItem.IdTipoIrregolarita.Value == IdTipoIrregolaritaEqualThis.Value))) &&
((ModusOperandiEqualThis == null) || ((RegistroIrregolaritaItem.ModusOperandi != null) && (RegistroIrregolaritaItem.ModusOperandi.Value == ModusOperandiEqualThis.Value))) && ((DichiarazioneOperatoreEqualThis == null) || ((RegistroIrregolaritaItem.DichiarazioneOperatore != null) && (RegistroIrregolaritaItem.DichiarazioneOperatore.Value == DichiarazioneOperatoreEqualThis.Value))) && ((AccertamentiAmministratoreEqualThis == null) || ((RegistroIrregolaritaItem.AccertamentiAmministratore != null) && (RegistroIrregolaritaItem.AccertamentiAmministratore.Value == AccertamentiAmministratoreEqualThis.Value))) &&
((IdClassificazioneIrregolaritaEqualThis == null) || ((RegistroIrregolaritaItem.IdClassificazioneIrregolarita != null) && (RegistroIrregolaritaItem.IdClassificazioneIrregolarita.Value == IdClassificazioneIrregolaritaEqualThis.Value))) && ((DataPrimoAttoConstatazioneAmministrativoEqualThis == null) || ((RegistroIrregolaritaItem.DataPrimoAttoConstatazioneAmministrativo != null) && (RegistroIrregolaritaItem.DataPrimoAttoConstatazioneAmministrativo.Value == DataPrimoAttoConstatazioneAmministrativoEqualThis.Value))) && ((IdMotivoEsecuzioneControlloEqualThis == null) || ((RegistroIrregolaritaItem.IdMotivoEsecuzioneControllo != null) && (RegistroIrregolaritaItem.IdMotivoEsecuzioneControllo.Value == IdMotivoEsecuzioneControlloEqualThis.Value))) &&
((IdTipoControlloEqualThis == null) || ((RegistroIrregolaritaItem.IdTipoControllo != null) && (RegistroIrregolaritaItem.IdTipoControllo.Value == IdTipoControlloEqualThis.Value))) && ((IdControlloPrimaDopoPagamentoEqualThis == null) || ((RegistroIrregolaritaItem.IdControlloPrimaDopoPagamento != null) && (RegistroIrregolaritaItem.IdControlloPrimaDopoPagamento.Value == IdControlloPrimaDopoPagamentoEqualThis.Value))) && ((AutoritaControlloEqualThis == null) || ((RegistroIrregolaritaItem.AutoritaControllo != null) && (RegistroIrregolaritaItem.AutoritaControllo.Value == AutoritaControlloEqualThis.Value))) &&
((IndagineOlafEqualThis == null) || ((RegistroIrregolaritaItem.IndagineOlaf != null) && (RegistroIrregolaritaItem.IndagineOlaf.Value == IndagineOlafEqualThis.Value))) && ((ImportoSpesaUeEqualThis == null) || ((RegistroIrregolaritaItem.ImportoSpesaUe != null) && (RegistroIrregolaritaItem.ImportoSpesaUe.Value == ImportoSpesaUeEqualThis.Value))) && ((ImportoSpesaNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoSpesaNazionale != null) && (RegistroIrregolaritaItem.ImportoSpesaNazionale.Value == ImportoSpesaNazionaleEqualThis.Value))) &&
((ImportoSpesaPubblicoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoSpesaPubblico != null) && (RegistroIrregolaritaItem.ImportoSpesaPubblico.Value == ImportoSpesaPubblicoEqualThis.Value))) && ((ImportoSpesaPrivatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoSpesaPrivato != null) && (RegistroIrregolaritaItem.ImportoSpesaPrivato.Value == ImportoSpesaPrivatoEqualThis.Value))) && ((ImportoSpesaTotaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoSpesaTotale != null) && (RegistroIrregolaritaItem.ImportoSpesaTotale.Value == ImportoSpesaTotaleEqualThis.Value))) &&
((ImportoIrregolaritaUeEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaUe != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaUe.Value == ImportoIrregolaritaUeEqualThis.Value))) && ((ImportoIrregolaritaNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNazionale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNazionale.Value == ImportoIrregolaritaNazionaleEqualThis.Value))) && ((ImportoIrregolaritaPubblicoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPubblico != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPubblico.Value == ImportoIrregolaritaPubblicoEqualThis.Value))) &&
((ImportoIrregolaritaPrivatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPrivato != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPrivato.Value == ImportoIrregolaritaPrivatoEqualThis.Value))) && ((ImportoIrregolaritaTotaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaTotale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaTotale.Value == ImportoIrregolaritaTotaleEqualThis.Value))) && ((ImportoIrregolaritaNonPagatoUeEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoUe != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoUe.Value == ImportoIrregolaritaNonPagatoUeEqualThis.Value))) &&
((ImportoIrregolaritaNonPagatoNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoNazionale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoNazionale.Value == ImportoIrregolaritaNonPagatoNazionaleEqualThis.Value))) && ((ImportoIrregolaritaNonPagatoPubblicoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoPubblico != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoPubblico.Value == ImportoIrregolaritaNonPagatoPubblicoEqualThis.Value))) && ((ImportoIrregolaritaNonPagatoPrivatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoPrivato != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoPrivato.Value == ImportoIrregolaritaNonPagatoPrivatoEqualThis.Value))) &&
((ImportoIrregolaritaNonPagatoTotaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoTotale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaNonPagatoTotale.Value == ImportoIrregolaritaNonPagatoTotaleEqualThis.Value))) && ((ImportoIrregolaritaPagatoUeEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPagatoUe != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPagatoUe.Value == ImportoIrregolaritaPagatoUeEqualThis.Value))) && ((ImportoIrregolaritaPagatoNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPagatoNazionale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPagatoNazionale.Value == ImportoIrregolaritaPagatoNazionaleEqualThis.Value))) &&
((ImportoIrregolaritaPagatoPubblicoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPagatoPubblico != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPagatoPubblico.Value == ImportoIrregolaritaPagatoPubblicoEqualThis.Value))) && ((ImportoIrregolaritaPagatoPrivatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPagatoPrivato != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPagatoPrivato.Value == ImportoIrregolaritaPagatoPrivatoEqualThis.Value))) && ((ImportoIrregolaritaPagatoTotaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoIrregolaritaPagatoTotale != null) && (RegistroIrregolaritaItem.ImportoIrregolaritaPagatoTotale.Value == ImportoIrregolaritaPagatoTotaleEqualThis.Value))) &&
((ImportoDaRecuperareUeEqualThis == null) || ((RegistroIrregolaritaItem.ImportoDaRecuperareUe != null) && (RegistroIrregolaritaItem.ImportoDaRecuperareUe.Value == ImportoDaRecuperareUeEqualThis.Value))) && ((ImportoDaRecuperareNazionaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoDaRecuperareNazionale != null) && (RegistroIrregolaritaItem.ImportoDaRecuperareNazionale.Value == ImportoDaRecuperareNazionaleEqualThis.Value))) && ((ImportoDaRecuperarePubblicoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoDaRecuperarePubblico != null) && (RegistroIrregolaritaItem.ImportoDaRecuperarePubblico.Value == ImportoDaRecuperarePubblicoEqualThis.Value))) &&
((ImportoDaRecuperarePrivatoEqualThis == null) || ((RegistroIrregolaritaItem.ImportoDaRecuperarePrivato != null) && (RegistroIrregolaritaItem.ImportoDaRecuperarePrivato.Value == ImportoDaRecuperarePrivatoEqualThis.Value))) && ((ImportoDaRecuperareTotaleEqualThis == null) || ((RegistroIrregolaritaItem.ImportoDaRecuperareTotale != null) && (RegistroIrregolaritaItem.ImportoDaRecuperareTotale.Value == ImportoDaRecuperareTotaleEqualThis.Value))) && ((SpesaDecertificataEqualThis == null) || ((RegistroIrregolaritaItem.SpesaDecertificata != null) && (RegistroIrregolaritaItem.SpesaDecertificata.Value == SpesaDecertificataEqualThis.Value))) &&
((CommentiImpattoFinanziarioEqualThis == null) || ((RegistroIrregolaritaItem.CommentiImpattoFinanziario != null) && (RegistroIrregolaritaItem.CommentiImpattoFinanziario.Value == CommentiImpattoFinanziarioEqualThis.Value))) && ((StabilitaOperazioniEqualThis == null) || ((RegistroIrregolaritaItem.StabilitaOperazioni != null) && (RegistroIrregolaritaItem.StabilitaOperazioni.Value == StabilitaOperazioniEqualThis.Value))))
                {
                    RegistroIrregolaritaCollectionTemp.Add(RegistroIrregolaritaItem);
                }
            }
            return RegistroIrregolaritaCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for RegistroIrregolaritaDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class RegistroIrregolaritaDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RegistroIrregolarita RegistroIrregolaritaObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdIrregolarita", RegistroIrregolaritaObj.IdIrregolarita);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "SegnalazioneOlaf", RegistroIrregolaritaObj.SegnalazioneOlaf);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSegnalazione", RegistroIrregolaritaObj.DataSegnalazione);
            DbProvider.SetCmdParam(cmd, firstChar + "TrimestreSegnalazione", RegistroIrregolaritaObj.TrimestreSegnalazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", RegistroIrregolaritaObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", RegistroIrregolaritaObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", RegistroIrregolaritaObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", RegistroIrregolaritaObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", RegistroIrregolaritaObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroRiferimentoOlaf", RegistroIrregolaritaObj.NumeroRiferimentoOlaf);
            DbProvider.SetCmdParam(cmd, firstChar + "SospettoFrode", RegistroIrregolaritaObj.SospettoFrode);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolareCertificato", RegistroIrregolaritaObj.ImportoIrregolareCertificato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolareDaRecuperare", RegistroIrregolaritaObj.ImportoIrregolareDaRecuperare);
            DbProvider.SetCmdParam(cmd, firstChar + "Anno", RegistroIrregolaritaObj.Anno);
            DbProvider.SetCmdParam(cmd, firstChar + "PeriodoProgrammazione", RegistroIrregolaritaObj.PeriodoProgrammazione);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroRiferimentoNazionale", RegistroIrregolaritaObj.NumeroRiferimentoNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "AzionePenale", RegistroIrregolaritaObj.AzionePenale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataCreazioneIdentificazione", RegistroIrregolaritaObj.DataCreazioneIdentificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "TrimestreIdentificazione", RegistroIrregolaritaObj.TrimestreIdentificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "ProcedimentoAmministrativo", RegistroIrregolaritaObj.ProcedimentoAmministrativo);
            DbProvider.SetCmdParam(cmd, firstChar + "AzioneGiudiziaria", RegistroIrregolaritaObj.AzioneGiudiziaria);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPrimaInformazioneSospetto", RegistroIrregolaritaObj.DataPrimaInformazioneSospetto);
            DbProvider.SetCmdParam(cmd, firstChar + "FontePrimaInformazioneSospetto", RegistroIrregolaritaObj.FontePrimaInformazioneSospetto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataIrregolarita", RegistroIrregolaritaObj.DataIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataIrregolaritaDa", RegistroIrregolaritaObj.DataIrregolaritaDa);
            DbProvider.SetCmdParam(cmd, firstChar + "DataIrregolaritaA", RegistroIrregolaritaObj.DataIrregolaritaA);
            DbProvider.SetCmdParam(cmd, firstChar + "CommessaA", RegistroIrregolaritaObj.CommessaA);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCategoriaIrregolarita", RegistroIrregolaritaObj.IdCategoriaIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoIrregolarita", RegistroIrregolaritaObj.IdTipoIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "ModusOperandi", RegistroIrregolaritaObj.ModusOperandi);
            DbProvider.SetCmdParam(cmd, firstChar + "DichiarazioneOperatore", RegistroIrregolaritaObj.DichiarazioneOperatore);
            DbProvider.SetCmdParam(cmd, firstChar + "AccertamentiAmministratore", RegistroIrregolaritaObj.AccertamentiAmministratore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdClassificazioneIrregolarita", RegistroIrregolaritaObj.IdClassificazioneIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPrimoAttoConstatazioneAmministrativo", RegistroIrregolaritaObj.DataPrimoAttoConstatazioneAmministrativo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdMotivoEsecuzioneControllo", RegistroIrregolaritaObj.IdMotivoEsecuzioneControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdTipoControllo", RegistroIrregolaritaObj.IdTipoControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdControlloPrimaDopoPagamento", RegistroIrregolaritaObj.IdControlloPrimaDopoPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "AutoritaControllo", RegistroIrregolaritaObj.AutoritaControllo);
            DbProvider.SetCmdParam(cmd, firstChar + "IndagineOlaf", RegistroIrregolaritaObj.IndagineOlaf);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSpesaUe", RegistroIrregolaritaObj.ImportoSpesaUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSpesaNazionale", RegistroIrregolaritaObj.ImportoSpesaNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSpesaPubblico", RegistroIrregolaritaObj.ImportoSpesaPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSpesaPrivato", RegistroIrregolaritaObj.ImportoSpesaPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoSpesaTotale", RegistroIrregolaritaObj.ImportoSpesaTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaUe", RegistroIrregolaritaObj.ImportoIrregolaritaUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNazionale", RegistroIrregolaritaObj.ImportoIrregolaritaNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPubblico", RegistroIrregolaritaObj.ImportoIrregolaritaPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPrivato", RegistroIrregolaritaObj.ImportoIrregolaritaPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaTotale", RegistroIrregolaritaObj.ImportoIrregolaritaTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNonPagatoUe", RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNonPagatoNazionale", RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNonPagatoPubblico", RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNonPagatoPrivato", RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaNonPagatoTotale", RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPagatoUe", RegistroIrregolaritaObj.ImportoIrregolaritaPagatoUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPagatoNazionale", RegistroIrregolaritaObj.ImportoIrregolaritaPagatoNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPagatoPubblico", RegistroIrregolaritaObj.ImportoIrregolaritaPagatoPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPagatoPrivato", RegistroIrregolaritaObj.ImportoIrregolaritaPagatoPrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrregolaritaPagatoTotale", RegistroIrregolaritaObj.ImportoIrregolaritaPagatoTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareUe", RegistroIrregolaritaObj.ImportoDaRecuperareUe);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareNazionale", RegistroIrregolaritaObj.ImportoDaRecuperareNazionale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperarePubblico", RegistroIrregolaritaObj.ImportoDaRecuperarePubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperarePrivato", RegistroIrregolaritaObj.ImportoDaRecuperarePrivato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDaRecuperareTotale", RegistroIrregolaritaObj.ImportoDaRecuperareTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "SpesaDecertificata", RegistroIrregolaritaObj.SpesaDecertificata);
            DbProvider.SetCmdParam(cmd, firstChar + "CommentiImpattoFinanziario", RegistroIrregolaritaObj.CommentiImpattoFinanziario);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFondo", RegistroIrregolaritaObj.IdFondo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdControlloOrigine", RegistroIrregolaritaObj.IdControlloOrigine);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStatoFinanziario", RegistroIrregolaritaObj.IdStatoFinanziario);
            DbProvider.SetCmdParam(cmd, firstChar + "DescrizioneControlloEsterno", RegistroIrregolaritaObj.DescrizioneControlloEsterno);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresaCommessaDa", RegistroIrregolaritaObj.IdImpresaCommessaDa);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteCommessaDa", RegistroIrregolaritaObj.NoteCommessaDa);
            DbProvider.SetCmdParam(cmd, firstChar + "StabilitaOperazioni", RegistroIrregolaritaObj.StabilitaOperazioni);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", RegistroIrregolaritaObj.IdDomandaPagamento);
        }
        //Insert
        private static int Insert(DbProvider db, RegistroIrregolarita RegistroIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZRegistroIrregolaritaInsert", new string[] {"SegnalazioneOlaf", "DataSegnalazione", "TrimestreSegnalazione", 
"DataModifica", "CfModifica", "DataInserimento", 
"CfInserimento", "IdProgetto", 
"NumeroRiferimentoOlaf", "SospettoFrode", "ImportoIrregolareCertificato", 
"ImportoIrregolareDaRecuperare", "Anno", "PeriodoProgrammazione", 
"NumeroRiferimentoNazionale", "AzionePenale", "DataCreazioneIdentificazione", 
"TrimestreIdentificazione", "ProcedimentoAmministrativo", "AzioneGiudiziaria", 
"DataPrimaInformazioneSospetto", "FontePrimaInformazioneSospetto", "DataIrregolarita", 
"DataIrregolaritaDa", "DataIrregolaritaA", "CommessaA", 
"IdCategoriaIrregolarita", "IdTipoIrregolarita", "ModusOperandi", 
"DichiarazioneOperatore", "AccertamentiAmministratore", "IdClassificazioneIrregolarita", 
"DataPrimoAttoConstatazioneAmministrativo", "IdMotivoEsecuzioneControllo", "IdTipoControllo", 
"IdControlloPrimaDopoPagamento", "AutoritaControllo", "IndagineOlaf", 
"ImportoSpesaUe", "ImportoSpesaNazionale", "ImportoSpesaPubblico", 
"ImportoSpesaPrivato", "ImportoSpesaTotale", "ImportoIrregolaritaUe", 
"ImportoIrregolaritaNazionale", "ImportoIrregolaritaPubblico", "ImportoIrregolaritaPrivato", 
"ImportoIrregolaritaTotale", "ImportoIrregolaritaNonPagatoUe", "ImportoIrregolaritaNonPagatoNazionale", 
"ImportoIrregolaritaNonPagatoPubblico", "ImportoIrregolaritaNonPagatoPrivato", "ImportoIrregolaritaNonPagatoTotale", 
"ImportoIrregolaritaPagatoUe", "ImportoIrregolaritaPagatoNazionale", "ImportoIrregolaritaPagatoPubblico", 
"ImportoIrregolaritaPagatoPrivato", "ImportoIrregolaritaPagatoTotale", "ImportoDaRecuperareUe", 
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDaRecuperarePrivato", 
"ImportoDaRecuperareTotale", "SpesaDecertificata", "CommentiImpattoFinanziario", 




"IdFondo", "IdControlloOrigine", 
"IdStatoFinanziario", "DescrizioneControlloEsterno", "IdImpresaCommessaDa", 
"NoteCommessaDa", "StabilitaOperazioni", "IdDomandaPagamento", }, new string[] {"bool", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"string", "bool", "decimal", 
"decimal", "int", "string", 
"string", "bool", "DateTime", 
"string", "bool", "bool", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "string", 
"int", "int", "string", 
"string", "string", "int", 
"DateTime", "int", "int", 
"int", "string", "bool", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "bool", "string", 




"int", "int", 
"int", "string", "int", 
"string", "bool", "int", }, "");
                CompileIUCmd(false, insertCmd, RegistroIrregolaritaObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    RegistroIrregolaritaObj.DataSegnalazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE"]);
                    RegistroIrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    RegistroIrregolaritaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    RegistroIrregolaritaObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
                }
                RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroIrregolaritaObj.IsDirty = false;
                RegistroIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, RegistroIrregolarita RegistroIrregolaritaObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroIrregolaritaUpdate", new string[] {"SegnalazioneOlaf", "DataSegnalazione", "TrimestreSegnalazione", 
"DataModifica", "CfModifica", "DataInserimento", 
"CfInserimento", "IdProgetto", "IdIrregolarita", 
"NumeroRiferimentoOlaf", "SospettoFrode", "ImportoIrregolareCertificato", 
"ImportoIrregolareDaRecuperare", "Anno", "PeriodoProgrammazione", 
"NumeroRiferimentoNazionale", "AzionePenale", "DataCreazioneIdentificazione", 
"TrimestreIdentificazione", "ProcedimentoAmministrativo", "AzioneGiudiziaria", 
"DataPrimaInformazioneSospetto", "FontePrimaInformazioneSospetto", "DataIrregolarita", 
"DataIrregolaritaDa", "DataIrregolaritaA", "CommessaA", 
"IdCategoriaIrregolarita", "IdTipoIrregolarita", "ModusOperandi", 
"DichiarazioneOperatore", "AccertamentiAmministratore", "IdClassificazioneIrregolarita", 
"DataPrimoAttoConstatazioneAmministrativo", "IdMotivoEsecuzioneControllo", "IdTipoControllo", 
"IdControlloPrimaDopoPagamento", "AutoritaControllo", "IndagineOlaf", 
"ImportoSpesaUe", "ImportoSpesaNazionale", "ImportoSpesaPubblico", 
"ImportoSpesaPrivato", "ImportoSpesaTotale", "ImportoIrregolaritaUe", 
"ImportoIrregolaritaNazionale", "ImportoIrregolaritaPubblico", "ImportoIrregolaritaPrivato", 
"ImportoIrregolaritaTotale", "ImportoIrregolaritaNonPagatoUe", "ImportoIrregolaritaNonPagatoNazionale", 
"ImportoIrregolaritaNonPagatoPubblico", "ImportoIrregolaritaNonPagatoPrivato", "ImportoIrregolaritaNonPagatoTotale", 
"ImportoIrregolaritaPagatoUe", "ImportoIrregolaritaPagatoNazionale", "ImportoIrregolaritaPagatoPubblico", 
"ImportoIrregolaritaPagatoPrivato", "ImportoIrregolaritaPagatoTotale", "ImportoDaRecuperareUe", 
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDaRecuperarePrivato", 
"ImportoDaRecuperareTotale", "SpesaDecertificata", "CommentiImpattoFinanziario", 




"IdFondo", "IdControlloOrigine", 
"IdStatoFinanziario", "DescrizioneControlloEsterno", "IdImpresaCommessaDa", 
"NoteCommessaDa", "StabilitaOperazioni", "IdDomandaPagamento", }, new string[] {"bool", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", "int", 
"string", "bool", "decimal", 
"decimal", "int", "string", 
"string", "bool", "DateTime", 
"string", "bool", "bool", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "string", 
"int", "int", "string", 
"string", "string", "int", 
"DateTime", "int", "int", 
"int", "string", "bool", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "bool", "string", 




"int", "int", 
"int", "string", "int", 
"string", "bool", "int", }, "");
                CompileIUCmd(true, updateCmd, RegistroIrregolaritaObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    RegistroIrregolaritaObj.DataModifica = d;
                }
                RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroIrregolaritaObj.IsDirty = false;
                RegistroIrregolaritaObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, RegistroIrregolarita RegistroIrregolaritaObj)
        {
            switch (RegistroIrregolaritaObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, RegistroIrregolaritaObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, RegistroIrregolaritaObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, RegistroIrregolaritaObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, RegistroIrregolaritaCollection RegistroIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRegistroIrregolaritaUpdate", new string[] {"SegnalazioneOlaf", "DataSegnalazione", "TrimestreSegnalazione", 
"DataModifica", "CfModifica", "DataInserimento", 
"CfInserimento", "IdProgetto", "IdIrregolarita", 
"NumeroRiferimentoOlaf", "SospettoFrode", "ImportoIrregolareCertificato", 
"ImportoIrregolareDaRecuperare", "Anno", "PeriodoProgrammazione", 
"NumeroRiferimentoNazionale", "AzionePenale", "DataCreazioneIdentificazione", 
"TrimestreIdentificazione", "ProcedimentoAmministrativo", "AzioneGiudiziaria", 
"DataPrimaInformazioneSospetto", "FontePrimaInformazioneSospetto", "DataIrregolarita", 
"DataIrregolaritaDa", "DataIrregolaritaA", "CommessaA", 
"IdCategoriaIrregolarita", "IdTipoIrregolarita", "ModusOperandi", 
"DichiarazioneOperatore", "AccertamentiAmministratore", "IdClassificazioneIrregolarita", 
"DataPrimoAttoConstatazioneAmministrativo", "IdMotivoEsecuzioneControllo", "IdTipoControllo", 
"IdControlloPrimaDopoPagamento", "AutoritaControllo", "IndagineOlaf", 
"ImportoSpesaUe", "ImportoSpesaNazionale", "ImportoSpesaPubblico", 
"ImportoSpesaPrivato", "ImportoSpesaTotale", "ImportoIrregolaritaUe", 
"ImportoIrregolaritaNazionale", "ImportoIrregolaritaPubblico", "ImportoIrregolaritaPrivato", 
"ImportoIrregolaritaTotale", "ImportoIrregolaritaNonPagatoUe", "ImportoIrregolaritaNonPagatoNazionale", 
"ImportoIrregolaritaNonPagatoPubblico", "ImportoIrregolaritaNonPagatoPrivato", "ImportoIrregolaritaNonPagatoTotale", 
"ImportoIrregolaritaPagatoUe", "ImportoIrregolaritaPagatoNazionale", "ImportoIrregolaritaPagatoPubblico", 
"ImportoIrregolaritaPagatoPrivato", "ImportoIrregolaritaPagatoTotale", "ImportoDaRecuperareUe", 
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDaRecuperarePrivato", 
"ImportoDaRecuperareTotale", "SpesaDecertificata", "CommentiImpattoFinanziario", 




"IdFondo", "IdControlloOrigine", 
"IdStatoFinanziario", "DescrizioneControlloEsterno", "IdImpresaCommessaDa", 
"NoteCommessaDa", "StabilitaOperazioni", "IdDomandaPagamento", }, new string[] {"bool", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", "int", 
"string", "bool", "decimal", 
"decimal", "int", "string", 
"string", "bool", "DateTime", 
"string", "bool", "bool", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "string", 
"int", "int", "string", 
"string", "string", "int", 
"DateTime", "int", "int", 
"int", "string", "bool", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "bool", "string", 




"int", "int", 
"int", "string", "int", 
"string", "bool", "int", }, "");
                IDbCommand insertCmd = db.InitCmd("ZRegistroIrregolaritaInsert", new string[] {"SegnalazioneOlaf", "DataSegnalazione", "TrimestreSegnalazione", 
"DataModifica", "CfModifica", "DataInserimento", 
"CfInserimento", "IdProgetto", 
"NumeroRiferimentoOlaf", "SospettoFrode", "ImportoIrregolareCertificato", 
"ImportoIrregolareDaRecuperare", "Anno", "PeriodoProgrammazione", 
"NumeroRiferimentoNazionale", "AzionePenale", "DataCreazioneIdentificazione", 
"TrimestreIdentificazione", "ProcedimentoAmministrativo", "AzioneGiudiziaria", 
"DataPrimaInformazioneSospetto", "FontePrimaInformazioneSospetto", "DataIrregolarita", 
"DataIrregolaritaDa", "DataIrregolaritaA", "CommessaA", 
"IdCategoriaIrregolarita", "IdTipoIrregolarita", "ModusOperandi", 
"DichiarazioneOperatore", "AccertamentiAmministratore", "IdClassificazioneIrregolarita", 
"DataPrimoAttoConstatazioneAmministrativo", "IdMotivoEsecuzioneControllo", "IdTipoControllo", 
"IdControlloPrimaDopoPagamento", "AutoritaControllo", "IndagineOlaf", 
"ImportoSpesaUe", "ImportoSpesaNazionale", "ImportoSpesaPubblico", 
"ImportoSpesaPrivato", "ImportoSpesaTotale", "ImportoIrregolaritaUe", 
"ImportoIrregolaritaNazionale", "ImportoIrregolaritaPubblico", "ImportoIrregolaritaPrivato", 
"ImportoIrregolaritaTotale", "ImportoIrregolaritaNonPagatoUe", "ImportoIrregolaritaNonPagatoNazionale", 
"ImportoIrregolaritaNonPagatoPubblico", "ImportoIrregolaritaNonPagatoPrivato", "ImportoIrregolaritaNonPagatoTotale", 
"ImportoIrregolaritaPagatoUe", "ImportoIrregolaritaPagatoNazionale", "ImportoIrregolaritaPagatoPubblico", 
"ImportoIrregolaritaPagatoPrivato", "ImportoIrregolaritaPagatoTotale", "ImportoDaRecuperareUe", 
"ImportoDaRecuperareNazionale", "ImportoDaRecuperarePubblico", "ImportoDaRecuperarePrivato", 
"ImportoDaRecuperareTotale", "SpesaDecertificata", "CommentiImpattoFinanziario", 




"IdFondo", "IdControlloOrigine", 
"IdStatoFinanziario", "DescrizioneControlloEsterno", "IdImpresaCommessaDa", 
"NoteCommessaDa", "StabilitaOperazioni", "IdDomandaPagamento", }, new string[] {"bool", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"string", "bool", "decimal", 
"decimal", "int", "string", 
"string", "bool", "DateTime", 
"string", "bool", "bool", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "string", 
"int", "int", "string", 
"string", "string", "int", 
"DateTime", "int", "int", 
"int", "string", "bool", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "bool", "string", 




"int", "int", 
"int", "string", "int", 
"string", "bool", "int", }, "");
                IDbCommand deleteCmd = db.InitCmd("ZRegistroIrregolaritaDelete", new string[] { "IdIrregolarita" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroIrregolaritaCollectionObj.Count; i++)
                {
                    switch (RegistroIrregolaritaCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, RegistroIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    RegistroIrregolaritaCollectionObj[i].DataSegnalazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE"]);
                                    RegistroIrregolaritaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    RegistroIrregolaritaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    RegistroIrregolaritaCollectionObj[i].IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, RegistroIrregolaritaCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    RegistroIrregolaritaCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (RegistroIrregolaritaCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)RegistroIrregolaritaCollectionObj[i].IdIrregolarita);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < RegistroIrregolaritaCollectionObj.Count; i++)
                {
                    if ((RegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        RegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        RegistroIrregolaritaCollectionObj[i].IsPersistent = true;
                    }
                    if ((RegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        RegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        RegistroIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, RegistroIrregolarita RegistroIrregolaritaObj)
        {
            int returnValue = 0;
            if (RegistroIrregolaritaObj.IsPersistent)
            {
                returnValue = Delete(db, RegistroIrregolaritaObj.IdIrregolarita);
            }
            RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            RegistroIrregolaritaObj.IsDirty = false;
            RegistroIrregolaritaObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdIrregolaritaValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroIrregolaritaDelete", new string[] { "IdIrregolarita" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)IdIrregolaritaValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, RegistroIrregolaritaCollection RegistroIrregolaritaCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRegistroIrregolaritaDelete", new string[] { "IdIrregolarita" }, new string[] { "int" }, "");
                for (int i = 0; i < RegistroIrregolaritaCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIrregolarita", RegistroIrregolaritaCollectionObj[i].IdIrregolarita);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < RegistroIrregolaritaCollectionObj.Count; i++)
                {
                    if ((RegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RegistroIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RegistroIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RegistroIrregolaritaCollectionObj[i].IsDirty = false;
                        RegistroIrregolaritaCollectionObj[i].IsPersistent = false;
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
        public static RegistroIrregolarita GetById(DbProvider db, int IdIrregolaritaValue)
        {
            RegistroIrregolarita RegistroIrregolaritaObj = null;
            IDbCommand readCmd = db.InitCmd("ZRegistroIrregolaritaGetById", new string[] { "IdIrregolarita" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)IdIrregolaritaValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                RegistroIrregolaritaObj = GetFromDatareader(db);
                RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroIrregolaritaObj.IsDirty = false;
                RegistroIrregolaritaObj.IsPersistent = true;
            }
            db.Close();
            return RegistroIrregolaritaObj;
        }

        //getFromDatareader
        public static RegistroIrregolarita GetFromDatareader(DbProvider db)
        {
            RegistroIrregolarita RegistroIrregolaritaObj = new RegistroIrregolarita();
            RegistroIrregolaritaObj.SegnalazioneOlaf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SEGNALAZIONE_OLAF"]);
            RegistroIrregolaritaObj.DataSegnalazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE"]);
            RegistroIrregolaritaObj.TrimestreSegnalazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRIMESTRE_SEGNALAZIONE"]);
            RegistroIrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            RegistroIrregolaritaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            RegistroIrregolaritaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            RegistroIrregolaritaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            RegistroIrregolaritaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            RegistroIrregolaritaObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
            RegistroIrregolaritaObj.NumeroRiferimentoOlaf = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_RIFERIMENTO_OLAF"]);
            RegistroIrregolaritaObj.SospettoFrode = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SOSPETTO_FRODE"]);
            RegistroIrregolaritaObj.ImportoIrregolareCertificato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_CERTIFICATO"]);
            RegistroIrregolaritaObj.ImportoIrregolareDaRecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_DA_RECUPERARE"]);
            RegistroIrregolaritaObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
            RegistroIrregolaritaObj.PeriodoProgrammazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PERIODO_PROGRAMMAZIONE"]);
            RegistroIrregolaritaObj.NumeroRiferimentoNazionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_RIFERIMENTO_NAZIONALE"]);
            RegistroIrregolaritaObj.AzionePenale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AZIONE_PENALE"]);
            RegistroIrregolaritaObj.DataCreazioneIdentificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE_IDENTIFICAZIONE"]);
            RegistroIrregolaritaObj.TrimestreIdentificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRIMESTRE_IDENTIFICAZIONE"]);
            RegistroIrregolaritaObj.ProcedimentoAmministrativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROCEDIMENTO_AMMINISTRATIVO"]);
            RegistroIrregolaritaObj.AzioneGiudiziaria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AZIONE_GIUDIZIARIA"]);
            RegistroIrregolaritaObj.DataPrimaInformazioneSospetto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRIMA_INFORMAZIONE_SOSPETTO"]);
            RegistroIrregolaritaObj.FontePrimaInformazioneSospetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["FONTE_PRIMA_INFORMAZIONE_SOSPETTO"]);
            RegistroIrregolaritaObj.DataIrregolarita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_IRREGOLARITA"]);
            RegistroIrregolaritaObj.DataIrregolaritaDa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_IRREGOLARITA_DA"]);
            RegistroIrregolaritaObj.DataIrregolaritaA = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_IRREGOLARITA_A"]);
            RegistroIrregolaritaObj.CommessaA = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMMESSA_A"]);
            RegistroIrregolaritaObj.IdCategoriaIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CATEGORIA_IRREGOLARITA"]);
            RegistroIrregolaritaObj.IdTipoIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_IRREGOLARITA"]);
            RegistroIrregolaritaObj.ModusOperandi = new SiarLibrary.NullTypes.StringNT(db.DataReader["MODUS_OPERANDI"]);
            RegistroIrregolaritaObj.DichiarazioneOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DICHIARAZIONE_OPERATORE"]);
            RegistroIrregolaritaObj.AccertamentiAmministratore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ACCERTAMENTI_AMMINISTRATORE"]);
            RegistroIrregolaritaObj.IdClassificazioneIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CLASSIFICAZIONE_IRREGOLARITA"]);
            RegistroIrregolaritaObj.DataPrimoAttoConstatazioneAmministrativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO"]);
            RegistroIrregolaritaObj.IdMotivoEsecuzioneControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MOTIVO_ESECUZIONE_CONTROLLO"]);
            RegistroIrregolaritaObj.IdTipoControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CONTROLLO"]);
            RegistroIrregolaritaObj.IdControlloPrimaDopoPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO"]);
            RegistroIrregolaritaObj.AutoritaControllo = new SiarLibrary.NullTypes.StringNT(db.DataReader["AUTORITA_CONTROLLO"]);
            RegistroIrregolaritaObj.IndagineOlaf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INDAGINE_OLAF"]);
            RegistroIrregolaritaObj.ImportoSpesaUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA_UE"]);
            RegistroIrregolaritaObj.ImportoSpesaNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA_NAZIONALE"]);
            RegistroIrregolaritaObj.ImportoSpesaPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA_PUBBLICO"]);
            RegistroIrregolaritaObj.ImportoSpesaPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA_PRIVATO"]);
            RegistroIrregolaritaObj.ImportoSpesaTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA_TOTALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_UE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NAZIONALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PUBBLICO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PRIVATO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_TOTALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NON_PAGATO_UE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaNonPagatoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPagatoUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PAGATO_UE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPagatoNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPagatoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPagatoPrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PAGATO_PRIVATO"]);
            RegistroIrregolaritaObj.ImportoIrregolaritaPagatoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARITA_PAGATO_TOTALE"]);
            RegistroIrregolaritaObj.ImportoDaRecuperareUe = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_UE"]);
            RegistroIrregolaritaObj.ImportoDaRecuperareNazionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_NAZIONALE"]);
            RegistroIrregolaritaObj.ImportoDaRecuperarePubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_PUBBLICO"]);
            RegistroIrregolaritaObj.ImportoDaRecuperarePrivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_PRIVATO"]);
            RegistroIrregolaritaObj.ImportoDaRecuperareTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DA_RECUPERARE_TOTALE"]);
            RegistroIrregolaritaObj.SpesaDecertificata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_DECERTIFICATA"]);
            RegistroIrregolaritaObj.CommentiImpattoFinanziario = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMMENTI_IMPATTO_FINANZIARIO"]);
            RegistroIrregolaritaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            RegistroIrregolaritaObj.CodAgea = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AGEA"]);
            RegistroIrregolaritaObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            RegistroIrregolaritaObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
            RegistroIrregolaritaObj.FlagPreadesione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PREADESIONE"]);
            RegistroIrregolaritaObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
            RegistroIrregolaritaObj.IdFascicolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO"]);
            RegistroIrregolaritaObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
            RegistroIrregolaritaObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
            RegistroIrregolaritaObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
            RegistroIrregolaritaObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
            RegistroIrregolaritaObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
            RegistroIrregolaritaObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            RegistroIrregolaritaObj.IdFondo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FONDO"]);
            RegistroIrregolaritaObj.IdControlloOrigine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTROLLO_ORIGINE"]);
            RegistroIrregolaritaObj.IdStatoFinanziario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STATO_FINANZIARIO"]);
            RegistroIrregolaritaObj.DescrizioneControlloEsterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CONTROLLO_ESTERNO"]);
            RegistroIrregolaritaObj.IdImpresaCommessaDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_COMMESSA_DA"]);
            RegistroIrregolaritaObj.NoteCommessaDa = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_COMMESSA_DA"]);
            RegistroIrregolaritaObj.StabilitaOperazioni = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STABILITA_OPERAZIONI"]);
            RegistroIrregolaritaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            RegistroIrregolaritaObj.IdImpresaProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_PROGETTO"]);
            RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            RegistroIrregolaritaObj.IsDirty = false;
            RegistroIrregolaritaObj.IsPersistent = true;
            return RegistroIrregolaritaObj;
        }

        //Find Select

        public static RegistroIrregolaritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdControlloOrigineEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneControlloEsternoEqualThis,
SiarLibrary.NullTypes.BoolNT SegnalazioneOlafEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnalazioneEqualThis, SiarLibrary.NullTypes.StringNT TrimestreSegnalazioneEqualThis,
SiarLibrary.NullTypes.StringNT NumeroRiferimentoOlafEqualThis, SiarLibrary.NullTypes.BoolNT SospettoFrodeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolareCertificatoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolareDaRecuperareEqualThis, SiarLibrary.NullTypes.IntNT IdFondoEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis,
SiarLibrary.NullTypes.StringNT PeriodoProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT NumeroRiferimentoNazionaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneIdentificazioneEqualThis,
SiarLibrary.NullTypes.StringNT TrimestreIdentificazioneEqualThis, SiarLibrary.NullTypes.BoolNT ProcedimentoAmministrativoEqualThis, SiarLibrary.NullTypes.BoolNT AzioneGiudiziariaEqualThis,
SiarLibrary.NullTypes.BoolNT AzionePenaleEqualThis, SiarLibrary.NullTypes.IntNT IdStatoFinanziarioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPrimaInformazioneSospettoEqualThis,
SiarLibrary.NullTypes.StringNT FontePrimaInformazioneSospettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataIrregolaritaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataIrregolaritaDaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataIrregolaritaAEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaCommessaDaEqualThis, SiarLibrary.NullTypes.StringNT NoteCommessaDaEqualThis,
SiarLibrary.NullTypes.StringNT CommessaAEqualThis, SiarLibrary.NullTypes.IntNT IdCategoriaIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoIrregolaritaEqualThis,
SiarLibrary.NullTypes.StringNT ModusOperandiEqualThis, SiarLibrary.NullTypes.StringNT DichiarazioneOperatoreEqualThis, SiarLibrary.NullTypes.StringNT AccertamentiAmministratoreEqualThis,
SiarLibrary.NullTypes.IntNT IdClassificazioneIrregolaritaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPrimoAttoConstatazioneAmministrativoEqualThis, SiarLibrary.NullTypes.IntNT IdMotivoEsecuzioneControlloEqualThis,
SiarLibrary.NullTypes.IntNT IdTipoControlloEqualThis, SiarLibrary.NullTypes.IntNT IdControlloPrimaDopoPagamentoEqualThis, SiarLibrary.NullTypes.StringNT AutoritaControlloEqualThis,
SiarLibrary.NullTypes.BoolNT IndagineOlafEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaNazionaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoSpesaPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaTotaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPubblicoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNonPagatoUeEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNonPagatoNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNonPagatoPrivatoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaNonPagatoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPagatoUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPagatoNazionaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPagatoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPagatoPrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolaritaPagatoTotaleEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareUeEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareNazionaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperarePubblicoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperarePrivatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDaRecuperareTotaleEqualThis, SiarLibrary.NullTypes.BoolNT SpesaDecertificataEqualThis,
SiarLibrary.NullTypes.StringNT CommentiImpattoFinanziarioEqualThis, SiarLibrary.NullTypes.BoolNT StabilitaOperazioniEqualThis)
        {

            RegistroIrregolaritaCollection RegistroIrregolaritaCollectionObj = new RegistroIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Zregistroirregolaritafindselect", new string[] {"IdIrregolaritaequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"CfInserimentoequalthis", "DataInserimentoequalthis", "CfModificaequalthis", 
"DataModificaequalthis", "IdControlloOrigineequalthis", "DescrizioneControlloEsternoequalthis", 
"SegnalazioneOlafequalthis", "DataSegnalazioneequalthis", "TrimestreSegnalazioneequalthis", 
"NumeroRiferimentoOlafequalthis", "SospettoFrodeequalthis", "ImportoIrregolareCertificatoequalthis", 
"ImportoIrregolareDaRecuperareequalthis", "IdFondoequalthis", "Annoequalthis", 
"PeriodoProgrammazioneequalthis", "NumeroRiferimentoNazionaleequalthis", "DataCreazioneIdentificazioneequalthis", 
"TrimestreIdentificazioneequalthis", "ProcedimentoAmministrativoequalthis", "AzioneGiudiziariaequalthis", 
"AzionePenaleequalthis", "IdStatoFinanziarioequalthis", "DataPrimaInformazioneSospettoequalthis", 
"FontePrimaInformazioneSospettoequalthis", "DataIrregolaritaequalthis", "DataIrregolaritaDaequalthis", 
"DataIrregolaritaAequalthis", "IdImpresaCommessaDaequalthis", "NoteCommessaDaequalthis", 
"CommessaAequalthis", "IdCategoriaIrregolaritaequalthis", "IdTipoIrregolaritaequalthis", 
"ModusOperandiequalthis", "DichiarazioneOperatoreequalthis", "AccertamentiAmministratoreequalthis", 
"IdClassificazioneIrregolaritaequalthis", "DataPrimoAttoConstatazioneAmministrativoequalthis", "IdMotivoEsecuzioneControlloequalthis", 
"IdTipoControlloequalthis", "IdControlloPrimaDopoPagamentoequalthis", "AutoritaControlloequalthis", 
"IndagineOlafequalthis", "ImportoSpesaUeequalthis", "ImportoSpesaNazionaleequalthis", 
"ImportoSpesaPubblicoequalthis", "ImportoSpesaPrivatoequalthis", "ImportoSpesaTotaleequalthis", 
"ImportoIrregolaritaUeequalthis", "ImportoIrregolaritaNazionaleequalthis", "ImportoIrregolaritaPubblicoequalthis", 
"ImportoIrregolaritaPrivatoequalthis", "ImportoIrregolaritaTotaleequalthis", "ImportoIrregolaritaNonPagatoUeequalthis", 
"ImportoIrregolaritaNonPagatoNazionaleequalthis", "ImportoIrregolaritaNonPagatoPubblicoequalthis", "ImportoIrregolaritaNonPagatoPrivatoequalthis", 
"ImportoIrregolaritaNonPagatoTotaleequalthis", "ImportoIrregolaritaPagatoUeequalthis", "ImportoIrregolaritaPagatoNazionaleequalthis", 
"ImportoIrregolaritaPagatoPubblicoequalthis", "ImportoIrregolaritaPagatoPrivatoequalthis", "ImportoIrregolaritaPagatoTotaleequalthis", 
"ImportoDaRecuperareUeequalthis", "ImportoDaRecuperareNazionaleequalthis", "ImportoDaRecuperarePubblicoequalthis", 
"ImportoDaRecuperarePrivatoequalthis", "ImportoDaRecuperareTotaleequalthis", "SpesaDecertificataequalthis", 
"CommentiImpattoFinanziarioequalthis", "StabilitaOperazioniequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "int", "string", 
"bool", "DateTime", "string", 
"string", "bool", "decimal", 
"decimal", "int", "int", 
"string", "string", "DateTime", 
"string", "bool", "bool", 
"bool", "int", "DateTime", 
"string", "DateTime", "DateTime", 
"DateTime", "int", "string", 
"string", "int", "int", 
"string", "string", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "bool", 
"string", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdControlloOrigineequalthis", IdControlloOrigineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneControlloEsternoequalthis", DescrizioneControlloEsternoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnalazioneOlafequalthis", SegnalazioneOlafEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSegnalazioneequalthis", DataSegnalazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TrimestreSegnalazioneequalthis", TrimestreSegnalazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRiferimentoOlafequalthis", NumeroRiferimentoOlafEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SospettoFrodeequalthis", SospettoFrodeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolareCertificatoequalthis", ImportoIrregolareCertificatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolareDaRecuperareequalthis", ImportoIrregolareDaRecuperareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFondoequalthis", IdFondoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PeriodoProgrammazioneequalthis", PeriodoProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRiferimentoNazionaleequalthis", NumeroRiferimentoNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneIdentificazioneequalthis", DataCreazioneIdentificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TrimestreIdentificazioneequalthis", TrimestreIdentificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProcedimentoAmministrativoequalthis", ProcedimentoAmministrativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AzioneGiudiziariaequalthis", AzioneGiudiziariaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AzionePenaleequalthis", AzionePenaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStatoFinanziarioequalthis", IdStatoFinanziarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPrimaInformazioneSospettoequalthis", DataPrimaInformazioneSospettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FontePrimaInformazioneSospettoequalthis", FontePrimaInformazioneSospettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIrregolaritaequalthis", DataIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIrregolaritaDaequalthis", DataIrregolaritaDaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataIrregolaritaAequalthis", DataIrregolaritaAEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaCommessaDaequalthis", IdImpresaCommessaDaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NoteCommessaDaequalthis", NoteCommessaDaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CommessaAequalthis", CommessaAEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCategoriaIrregolaritaequalthis", IdCategoriaIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoIrregolaritaequalthis", IdTipoIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ModusOperandiequalthis", ModusOperandiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DichiarazioneOperatoreequalthis", DichiarazioneOperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AccertamentiAmministratoreequalthis", AccertamentiAmministratoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdClassificazioneIrregolaritaequalthis", IdClassificazioneIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPrimoAttoConstatazioneAmministrativoequalthis", DataPrimoAttoConstatazioneAmministrativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdMotivoEsecuzioneControlloequalthis", IdMotivoEsecuzioneControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoControlloequalthis", IdTipoControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdControlloPrimaDopoPagamentoequalthis", IdControlloPrimaDopoPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AutoritaControlloequalthis", AutoritaControlloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IndagineOlafequalthis", IndagineOlafEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSpesaUeequalthis", ImportoSpesaUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSpesaNazionaleequalthis", ImportoSpesaNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSpesaPubblicoequalthis", ImportoSpesaPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSpesaPrivatoequalthis", ImportoSpesaPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoSpesaTotaleequalthis", ImportoSpesaTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaUeequalthis", ImportoIrregolaritaUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNazionaleequalthis", ImportoIrregolaritaNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPubblicoequalthis", ImportoIrregolaritaPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPrivatoequalthis", ImportoIrregolaritaPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaTotaleequalthis", ImportoIrregolaritaTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNonPagatoUeequalthis", ImportoIrregolaritaNonPagatoUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNonPagatoNazionaleequalthis", ImportoIrregolaritaNonPagatoNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNonPagatoPubblicoequalthis", ImportoIrregolaritaNonPagatoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNonPagatoPrivatoequalthis", ImportoIrregolaritaNonPagatoPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaNonPagatoTotaleequalthis", ImportoIrregolaritaNonPagatoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPagatoUeequalthis", ImportoIrregolaritaPagatoUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPagatoNazionaleequalthis", ImportoIrregolaritaPagatoNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPagatoPubblicoequalthis", ImportoIrregolaritaPagatoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPagatoPrivatoequalthis", ImportoIrregolaritaPagatoPrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrregolaritaPagatoTotaleequalthis", ImportoIrregolaritaPagatoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareUeequalthis", ImportoDaRecuperareUeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareNazionaleequalthis", ImportoDaRecuperareNazionaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperarePubblicoequalthis", ImportoDaRecuperarePubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperarePrivatoequalthis", ImportoDaRecuperarePrivatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDaRecuperareTotaleequalthis", ImportoDaRecuperareTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaDecertificataequalthis", SpesaDecertificataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CommentiImpattoFinanziarioequalthis", CommentiImpattoFinanziarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StabilitaOperazioniequalthis", StabilitaOperazioniEqualThis);
            RegistroIrregolarita RegistroIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroIrregolaritaObj = GetFromDatareader(db);
                RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroIrregolaritaObj.IsDirty = false;
                RegistroIrregolaritaObj.IsPersistent = true;
                RegistroIrregolaritaCollectionObj.Add(RegistroIrregolaritaObj);
            }
            db.Close();
            return RegistroIrregolaritaCollectionObj;
        }

        //Find Find

        public static RegistroIrregolaritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis)
        {

            RegistroIrregolaritaCollection RegistroIrregolaritaCollectionObj = new RegistroIrregolaritaCollection();

            IDbCommand findCmd = db.InitCmd("Zregistroirregolaritafindfind", new string[] { "IdIrregolaritaequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis" }, new string[] { "int", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            RegistroIrregolarita RegistroIrregolaritaObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RegistroIrregolaritaObj = GetFromDatareader(db);
                RegistroIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RegistroIrregolaritaObj.IsDirty = false;
                RegistroIrregolaritaObj.IsPersistent = true;
                RegistroIrregolaritaCollectionObj.Add(RegistroIrregolaritaObj);
            }
            db.Close();
            return RegistroIrregolaritaCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for RegistroIrregolaritaCollectionProvider:IRegistroIrregolaritaProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RegistroIrregolaritaCollectionProvider : IRegistroIrregolaritaProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di RegistroIrregolarita
        protected RegistroIrregolaritaCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public RegistroIrregolaritaCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new RegistroIrregolaritaCollection(this);
        }

        //Costruttore 2: popola la collection
        public RegistroIrregolaritaCollectionProvider(IntNT IdirregolaritaEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdirregolaritaEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis);
        }

        //Costruttore3: ha in input registroirregolaritaCollectionObj - non popola la collection
        public RegistroIrregolaritaCollectionProvider(RegistroIrregolaritaCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public RegistroIrregolaritaCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new RegistroIrregolaritaCollection(this);
        }

        //Get e Set
        public RegistroIrregolaritaCollection CollectionObj
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
        public int SaveCollection(RegistroIrregolaritaCollection collectionObj)
        {
            return RegistroIrregolaritaDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(RegistroIrregolarita registroirregolaritaObj)
        {
            return RegistroIrregolaritaDAL.Save(_dbProviderObj, registroirregolaritaObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(RegistroIrregolaritaCollection collectionObj)
        {
            return RegistroIrregolaritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(RegistroIrregolarita registroirregolaritaObj)
        {
            return RegistroIrregolaritaDAL.Delete(_dbProviderObj, registroirregolaritaObj);
        }

        //getById
        public RegistroIrregolarita GetById(IntNT IdIrregolaritaValue)
        {
            RegistroIrregolarita RegistroIrregolaritaTemp = RegistroIrregolaritaDAL.GetById(_dbProviderObj, IdIrregolaritaValue);
            if (RegistroIrregolaritaTemp != null) RegistroIrregolaritaTemp.Provider = this;
            return RegistroIrregolaritaTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public RegistroIrregolaritaCollection Select(IntNT IdirregolaritaEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfmodificaEqualThis,
DatetimeNT DatamodificaEqualThis, IntNT IdcontrolloorigineEqualThis, StringNT DescrizionecontrolloesternoEqualThis,
BoolNT SegnalazioneolafEqualThis, DatetimeNT DatasegnalazioneEqualThis, StringNT TrimestresegnalazioneEqualThis,
StringNT NumeroriferimentoolafEqualThis, BoolNT SospettofrodeEqualThis, DecimalNT ImportoirregolarecertificatoEqualThis,
DecimalNT ImportoirregolaredarecuperareEqualThis, IntNT IdfondoEqualThis, IntNT AnnoEqualThis,
StringNT PeriodoprogrammazioneEqualThis, StringNT NumeroriferimentonazionaleEqualThis, DatetimeNT DatacreazioneidentificazioneEqualThis,
StringNT TrimestreidentificazioneEqualThis, BoolNT ProcedimentoamministrativoEqualThis, BoolNT AzionegiudiziariaEqualThis,
BoolNT AzionepenaleEqualThis, IntNT IdstatofinanziarioEqualThis, DatetimeNT DataprimainformazionesospettoEqualThis,
StringNT FonteprimainformazionesospettoEqualThis, DatetimeNT DatairregolaritaEqualThis, DatetimeNT DatairregolaritadaEqualThis,
DatetimeNT DatairregolaritaaEqualThis, IntNT IdimpresacommessadaEqualThis, StringNT NotecommessadaEqualThis,
StringNT CommessaaEqualThis, IntNT IdcategoriairregolaritaEqualThis, IntNT IdtipoirregolaritaEqualThis,
StringNT ModusoperandiEqualThis, StringNT DichiarazioneoperatoreEqualThis, StringNT AccertamentiamministratoreEqualThis,
IntNT IdclassificazioneirregolaritaEqualThis, DatetimeNT DataprimoattoconstatazioneamministrativoEqualThis, IntNT IdmotivoesecuzionecontrolloEqualThis,
IntNT IdtipocontrolloEqualThis, IntNT IdcontrolloprimadopopagamentoEqualThis, StringNT AutoritacontrolloEqualThis,
BoolNT IndagineolafEqualThis, DecimalNT ImportospesaueEqualThis, DecimalNT ImportospesanazionaleEqualThis,
DecimalNT ImportospesapubblicoEqualThis, DecimalNT ImportospesaprivatoEqualThis, DecimalNT ImportospesatotaleEqualThis,
DecimalNT ImportoirregolaritaueEqualThis, DecimalNT ImportoirregolaritanazionaleEqualThis, DecimalNT ImportoirregolaritapubblicoEqualThis,
DecimalNT ImportoirregolaritaprivatoEqualThis, DecimalNT ImportoirregolaritatotaleEqualThis, DecimalNT ImportoirregolaritanonpagatoueEqualThis,
DecimalNT ImportoirregolaritanonpagatonazionaleEqualThis, DecimalNT ImportoirregolaritanonpagatopubblicoEqualThis, DecimalNT ImportoirregolaritanonpagatoprivatoEqualThis,
DecimalNT ImportoirregolaritanonpagatototaleEqualThis, DecimalNT ImportoirregolaritapagatoueEqualThis, DecimalNT ImportoirregolaritapagatonazionaleEqualThis,
DecimalNT ImportoirregolaritapagatopubblicoEqualThis, DecimalNT ImportoirregolaritapagatoprivatoEqualThis, DecimalNT ImportoirregolaritapagatototaleEqualThis,
DecimalNT ImportodarecuperareueEqualThis, DecimalNT ImportodarecuperarenazionaleEqualThis, DecimalNT ImportodarecuperarepubblicoEqualThis,
DecimalNT ImportodarecuperareprivatoEqualThis, DecimalNT ImportodarecuperaretotaleEqualThis, BoolNT SpesadecertificataEqualThis,
StringNT CommentiimpattofinanziarioEqualThis, BoolNT StabilitaoperazioniEqualThis)
        {
            RegistroIrregolaritaCollection RegistroIrregolaritaCollectionTemp = RegistroIrregolaritaDAL.Select(_dbProviderObj, IdirregolaritaEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis,
CfinserimentoEqualThis, DatainserimentoEqualThis, CfmodificaEqualThis,
DatamodificaEqualThis, IdcontrolloorigineEqualThis, DescrizionecontrolloesternoEqualThis,
SegnalazioneolafEqualThis, DatasegnalazioneEqualThis, TrimestresegnalazioneEqualThis,
NumeroriferimentoolafEqualThis, SospettofrodeEqualThis, ImportoirregolarecertificatoEqualThis,
ImportoirregolaredarecuperareEqualThis, IdfondoEqualThis, AnnoEqualThis,
PeriodoprogrammazioneEqualThis, NumeroriferimentonazionaleEqualThis, DatacreazioneidentificazioneEqualThis,
TrimestreidentificazioneEqualThis, ProcedimentoamministrativoEqualThis, AzionegiudiziariaEqualThis,
AzionepenaleEqualThis, IdstatofinanziarioEqualThis, DataprimainformazionesospettoEqualThis,
FonteprimainformazionesospettoEqualThis, DatairregolaritaEqualThis, DatairregolaritadaEqualThis,
DatairregolaritaaEqualThis, IdimpresacommessadaEqualThis, NotecommessadaEqualThis,
CommessaaEqualThis, IdcategoriairregolaritaEqualThis, IdtipoirregolaritaEqualThis,
ModusoperandiEqualThis, DichiarazioneoperatoreEqualThis, AccertamentiamministratoreEqualThis,
IdclassificazioneirregolaritaEqualThis, DataprimoattoconstatazioneamministrativoEqualThis, IdmotivoesecuzionecontrolloEqualThis,
IdtipocontrolloEqualThis, IdcontrolloprimadopopagamentoEqualThis, AutoritacontrolloEqualThis,
IndagineolafEqualThis, ImportospesaueEqualThis, ImportospesanazionaleEqualThis,
ImportospesapubblicoEqualThis, ImportospesaprivatoEqualThis, ImportospesatotaleEqualThis,
ImportoirregolaritaueEqualThis, ImportoirregolaritanazionaleEqualThis, ImportoirregolaritapubblicoEqualThis,
ImportoirregolaritaprivatoEqualThis, ImportoirregolaritatotaleEqualThis, ImportoirregolaritanonpagatoueEqualThis,
ImportoirregolaritanonpagatonazionaleEqualThis, ImportoirregolaritanonpagatopubblicoEqualThis, ImportoirregolaritanonpagatoprivatoEqualThis,
ImportoirregolaritanonpagatototaleEqualThis, ImportoirregolaritapagatoueEqualThis, ImportoirregolaritapagatonazionaleEqualThis,
ImportoirregolaritapagatopubblicoEqualThis, ImportoirregolaritapagatoprivatoEqualThis, ImportoirregolaritapagatototaleEqualThis,
ImportodarecuperareueEqualThis, ImportodarecuperarenazionaleEqualThis, ImportodarecuperarepubblicoEqualThis,
ImportodarecuperareprivatoEqualThis, ImportodarecuperaretotaleEqualThis, SpesadecertificataEqualThis,
CommentiimpattofinanziarioEqualThis, StabilitaoperazioniEqualThis);
            RegistroIrregolaritaCollectionTemp.Provider = this;
            return RegistroIrregolaritaCollectionTemp;
        }

        //Find: popola la collection
        public RegistroIrregolaritaCollection Find(IntNT IdirregolaritaEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis)
        {
            RegistroIrregolaritaCollection RegistroIrregolaritaCollectionTemp = RegistroIrregolaritaDAL.Find(_dbProviderObj, IdirregolaritaEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis);
            RegistroIrregolaritaCollectionTemp.Provider = this;
            return RegistroIrregolaritaCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REGISTRO_IRREGOLARITA>
  <ViewName>VREGISTRO_IRREGOLARITA</ViewName>
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
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REGISTRO_IRREGOLARITA>
*/
