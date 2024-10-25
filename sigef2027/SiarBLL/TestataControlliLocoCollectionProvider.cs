using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per TestataControlliLoco
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ITestataControlliLocoProvider
    {
        int Save(TestataControlliLoco TestataControlliLocoObj);
        int SaveCollection(TestataControlliLocoCollection collectionObj);
        int Delete(TestataControlliLoco TestataControlliLocoObj);
        int DeleteCollection(TestataControlliLocoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for TestataControlliLoco
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class TestataControlliLoco : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdTestata;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataSopralluogo;
        private NullTypes.StringNT _LuogoSopralluogo;
        private NullTypes.IntNT _IdIstanzaChecklistGenerica;
        private NullTypes.IntNT _IdChecklistGenerica;
        private NullTypes.IntNT _IdlocoDettaglio;
        private NullTypes.IntNT _Idloco;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Asse;
        private NullTypes.BoolNT _Selezionata;
        private NullTypes.StringNT _EsitoControllo;
        private NullTypes.DatetimeNT _DataesitoControllo;
        private NullTypes.DecimalNT _Costototale;
        private NullTypes.DecimalNT _Importoammesso;
        private NullTypes.DecimalNT _Importoconcesso;
        private NullTypes.IntNT _Nroperazionib;
        private NullTypes.StringNT _Beneficiario;
        private NullTypes.DecimalNT _Spesaammessa;
        private NullTypes.DecimalNT _Importocontributopubblico;
        private NullTypes.DecimalNT _ImportocontributopubblicoIncrementale;
        private NullTypes.DecimalNT _SpesaammessaIncrementale;
        private NullTypes.StringNT _Esclusione;
        private NullTypes.DecimalNT _Rischioir;
        private NullTypes.DecimalNT _Rischiocr;
        private NullTypes.StringNT _Rischiocomp;
        private NullTypes.StringNT _Azione;
        private NullTypes.StringNT _Intervento;
        private NullTypes.BoolNT _EsitoTestata;
        private NullTypes.IntNT _IdFileVerbale;
        private NullTypes.IntNT _IdFileAttestazione;
        private NullTypes.StringNT _TipoDomanda;
        private NullTypes.StringNT _SegnaturaTestata;
        private NullTypes.DatetimeNT _DataVerbale;
        private NullTypes.DatetimeNT _DataAttestazione;
        private NullTypes.DatetimeNT _DataSegnatura;
        private NullTypes.IntNT _IdUtenteCompilatore;
        private NullTypes.IntNT _IdUtenteValidatore;
        private NullTypes.IntNT _IdPersonaFisicaCompilatore;
        private NullTypes.IntNT _IdStoricoUltimoCompilatore;
        private NullTypes.StringNT _CfUtenteCompilatore;
        private NullTypes.StringNT _ProfiloCompilatore;
        private NullTypes.StringNT _EnteCompilatore;
        private NullTypes.StringNT _NominativoCompilatore;
        private NullTypes.IntNT _IdPersonaFisicaValidatore;
        private NullTypes.IntNT _IdStoricoUltimoValidatore;
        private NullTypes.StringNT _CfUtenteValidatore;
        private NullTypes.StringNT _ProfiloValidatore;
        private NullTypes.StringNT _EnteValidatore;
        private NullTypes.StringNT _NominativoValidatore;
        [NonSerialized]
        private ITestataControlliLocoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataControlliLocoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public TestataControlliLoco()
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
        /// Tipo sul db:VARCHAR(50)
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
        /// Tipo sul db:VARCHAR(50)
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
        /// Corrisponde al campo:DATA_SOPRALLUOGO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataSopralluogo
        {
            get { return _DataSopralluogo; }
            set
            {
                if (DataSopralluogo != value)
                {
                    _DataSopralluogo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LUOGO_SOPRALLUOGO
        /// Tipo sul db:VARCHAR(3000)
        /// </summary>
        public NullTypes.StringNT LuogoSopralluogo
        {
            get { return _LuogoSopralluogo; }
            set
            {
                if (LuogoSopralluogo != value)
                {
                    _LuogoSopralluogo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ISTANZA_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIstanzaChecklistGenerica
        {
            get { return _IdIstanzaChecklistGenerica; }
            set
            {
                if (IdIstanzaChecklistGenerica != value)
                {
                    _IdIstanzaChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CHECKLIST_GENERICA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdChecklistGenerica
        {
            get { return _IdChecklistGenerica; }
            set
            {
                if (IdChecklistGenerica != value)
                {
                    _IdChecklistGenerica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IDLOCO_DETTAGLIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdlocoDettaglio
        {
            get { return _IdlocoDettaglio; }
            set
            {
                if (IdlocoDettaglio != value)
                {
                    _IdlocoDettaglio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IdLoco
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Idloco
        {
            get { return _Idloco; }
            set
            {
                if (Idloco != value)
                {
                    _Idloco = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Id_Domanda_Pagamento
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
        /// Corrisponde al campo:Id_Progetto
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
        /// Corrisponde al campo:Asse
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Asse
        {
            get { return _Asse; }
            set
            {
                if (Asse != value)
                {
                    _Asse = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Selezionata
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Selezionata
        {
            get { return _Selezionata; }
            set
            {
                if (Selezionata != value)
                {
                    _Selezionata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO_CONTROLLO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT EsitoControllo
        {
            get { return _EsitoControllo; }
            set
            {
                if (EsitoControllo != value)
                {
                    _EsitoControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATAESITO_CONTROLLO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataesitoControllo
        {
            get { return _DataesitoControllo; }
            set
            {
                if (DataesitoControllo != value)
                {
                    _DataesitoControllo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CostoTotale
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Costototale
        {
            get { return _Costototale; }
            set
            {
                if (Costototale != value)
                {
                    _Costototale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ImportoAmmesso
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importoammesso
        {
            get { return _Importoammesso; }
            set
            {
                if (Importoammesso != value)
                {
                    _Importoammesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ImportoConcesso
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importoconcesso
        {
            get { return _Importoconcesso; }
            set
            {
                if (Importoconcesso != value)
                {
                    _Importoconcesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NrOperazioniB
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Nroperazionib
        {
            get { return _Nroperazionib; }
            set
            {
                if (Nroperazionib != value)
                {
                    _Nroperazionib = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Beneficiario
        /// Tipo sul db:VARCHAR(155)
        /// </summary>
        public NullTypes.StringNT Beneficiario
        {
            get { return _Beneficiario; }
            set
            {
                if (Beneficiario != value)
                {
                    _Beneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SpesaAmmessa
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Spesaammessa
        {
            get { return _Spesaammessa; }
            set
            {
                if (Spesaammessa != value)
                {
                    _Spesaammessa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ImportoContributoPubblico
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importocontributopubblico
        {
            get { return _Importocontributopubblico; }
            set
            {
                if (Importocontributopubblico != value)
                {
                    _Importocontributopubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ImportoContributoPubblico_Incrementale
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportocontributopubblicoIncrementale
        {
            get { return _ImportocontributopubblicoIncrementale; }
            set
            {
                if (ImportocontributopubblicoIncrementale != value)
                {
                    _ImportocontributopubblicoIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SpesaAmmessa_Incrementale
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaammessaIncrementale
        {
            get { return _SpesaammessaIncrementale; }
            set
            {
                if (SpesaammessaIncrementale != value)
                {
                    _SpesaammessaIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Esclusione
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Esclusione
        {
            get { return _Esclusione; }
            set
            {
                if (Esclusione != value)
                {
                    _Esclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RischioIR
        /// Tipo sul db:DECIMAL(6,2)
        /// </summary>
        public NullTypes.DecimalNT Rischioir
        {
            get { return _Rischioir; }
            set
            {
                if (Rischioir != value)
                {
                    _Rischioir = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RischioCR
        /// Tipo sul db:DECIMAL(6,2)
        /// </summary>
        public NullTypes.DecimalNT Rischiocr
        {
            get { return _Rischiocr; }
            set
            {
                if (Rischiocr != value)
                {
                    _Rischiocr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RischioComp
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Rischiocomp
        {
            get { return _Rischiocomp; }
            set
            {
                if (Rischiocomp != value)
                {
                    _Rischiocomp = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Azione
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Azione
        {
            get { return _Azione; }
            set
            {
                if (Azione != value)
                {
                    _Azione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:Intervento
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Intervento
        {
            get { return _Intervento; }
            set
            {
                if (Intervento != value)
                {
                    _Intervento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO_TESTATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT EsitoTestata
        {
            get { return _EsitoTestata; }
            set
            {
                if (EsitoTestata != value)
                {
                    _EsitoTestata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_VERBALE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFileVerbale
        {
            get { return _IdFileVerbale; }
            set
            {
                if (IdFileVerbale != value)
                {
                    _IdFileVerbale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE_ATTESTAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFileAttestazione
        {
            get { return _IdFileAttestazione; }
            set
            {
                if (IdFileAttestazione != value)
                {
                    _IdFileAttestazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_DOMANDA
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT TipoDomanda
        {
            get { return _TipoDomanda; }
            set
            {
                if (TipoDomanda != value)
                {
                    _TipoDomanda = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_TESTATA
        /// Tipo sul db:VARCHAR(1000)
        /// </summary>
        public NullTypes.StringNT SegnaturaTestata
        {
            get { return _SegnaturaTestata; }
            set
            {
                if (SegnaturaTestata != value)
                {
                    _SegnaturaTestata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VERBALE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataVerbale
        {
            get { return _DataVerbale; }
            set
            {
                if (DataVerbale != value)
                {
                    _DataVerbale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ATTESTAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAttestazione
        {
            get { return _DataAttestazione; }
            set
            {
                if (DataAttestazione != value)
                {
                    _DataAttestazione = value;
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
        /// Corrisponde al campo:ID_UTENTE_COMPILATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtenteCompilatore
        {
            get { return _IdUtenteCompilatore; }
            set
            {
                if (IdUtenteCompilatore != value)
                {
                    _IdUtenteCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_UTENTE_VALIDATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtenteValidatore
        {
            get { return _IdUtenteValidatore; }
            set
            {
                if (IdUtenteValidatore != value)
                {
                    _IdUtenteValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PERSONA_FISICA_COMPILATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPersonaFisicaCompilatore
        {
            get { return _IdPersonaFisicaCompilatore; }
            set
            {
                if (IdPersonaFisicaCompilatore != value)
                {
                    _IdPersonaFisicaCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_ULTIMO_COMPILATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoUltimoCompilatore
        {
            get { return _IdStoricoUltimoCompilatore; }
            set
            {
                if (IdStoricoUltimoCompilatore != value)
                {
                    _IdStoricoUltimoCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE_COMPILATORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtenteCompilatore
        {
            get { return _CfUtenteCompilatore; }
            set
            {
                if (CfUtenteCompilatore != value)
                {
                    _CfUtenteCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROFILO_COMPILATORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ProfiloCompilatore
        {
            get { return _ProfiloCompilatore; }
            set
            {
                if (ProfiloCompilatore != value)
                {
                    _ProfiloCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ENTE_COMPILATORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT EnteCompilatore
        {
            get { return _EnteCompilatore; }
            set
            {
                if (EnteCompilatore != value)
                {
                    _EnteCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_COMPILATORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoCompilatore
        {
            get { return _NominativoCompilatore; }
            set
            {
                if (NominativoCompilatore != value)
                {
                    _NominativoCompilatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PERSONA_FISICA_VALIDATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPersonaFisicaValidatore
        {
            get { return _IdPersonaFisicaValidatore; }
            set
            {
                if (IdPersonaFisicaValidatore != value)
                {
                    _IdPersonaFisicaValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_ULTIMO_VALIDATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoUltimoValidatore
        {
            get { return _IdStoricoUltimoValidatore; }
            set
            {
                if (IdStoricoUltimoValidatore != value)
                {
                    _IdStoricoUltimoValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_UTENTE_VALIDATORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfUtenteValidatore
        {
            get { return _CfUtenteValidatore; }
            set
            {
                if (CfUtenteValidatore != value)
                {
                    _CfUtenteValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROFILO_VALIDATORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT ProfiloValidatore
        {
            get { return _ProfiloValidatore; }
            set
            {
                if (ProfiloValidatore != value)
                {
                    _ProfiloValidatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ENTE_VALIDATORE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT EnteValidatore
        {
            get { return _EnteValidatore; }
            set
            {
                if (EnteValidatore != value)
                {
                    _EnteValidatore = value;
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
    /// Summary description for TestataControlliLocoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataControlliLocoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private TestataControlliLocoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((TestataControlliLoco)info.GetValue(i.ToString(), typeof(TestataControlliLoco)));
            }
        }

        //Costruttore
        public TestataControlliLocoCollection()
        {
            this.ItemType = typeof(TestataControlliLoco);
        }

        //Costruttore con provider
        public TestataControlliLocoCollection(ITestataControlliLocoProvider providerObj)
        {
            this.ItemType = typeof(TestataControlliLoco);
            this.Provider = providerObj;
        }

        //Get e Set
        public new TestataControlliLoco this[int index]
        {
            get { return (TestataControlliLoco)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new TestataControlliLocoCollection GetChanges()
        {
            return (TestataControlliLocoCollection)base.GetChanges();
        }

        [NonSerialized]
        private ITestataControlliLocoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ITestataControlliLocoProvider Provider
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
        public int Add(TestataControlliLoco TestataControlliLocoObj)
        {
            if (TestataControlliLocoObj.Provider == null) TestataControlliLocoObj.Provider = this.Provider;
            return base.Add(TestataControlliLocoObj);
        }

        //AddCollection
        public void AddCollection(TestataControlliLocoCollection TestataControlliLocoCollectionObj)
        {
            foreach (TestataControlliLoco TestataControlliLocoObj in TestataControlliLocoCollectionObj)
                this.Add(TestataControlliLocoObj);
        }

        //Insert
        public void Insert(int index, TestataControlliLoco TestataControlliLocoObj)
        {
            if (TestataControlliLocoObj.Provider == null) TestataControlliLocoObj.Provider = this.Provider;
            base.Insert(index, TestataControlliLocoObj);
        }

        //CollectionGetById
        public TestataControlliLoco CollectionGetById(NullTypes.IntNT IdTestataValue)
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
        public TestataControlliLocoCollection SubSelect(NullTypes.IntNT IdTestataEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataSopralluogoEqualThis,
NullTypes.StringNT LuogoSopralluogoEqualThis, NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, NullTypes.IntNT IdlocoDettaglioEqualThis,
NullTypes.BoolNT EsitoTestataEqualThis, NullTypes.IntNT IdFileVerbaleEqualThis, NullTypes.DatetimeNT DataVerbaleEqualThis,
NullTypes.IntNT IdFileAttestazioneEqualThis, NullTypes.DatetimeNT DataAttestazioneEqualThis, NullTypes.StringNT SegnaturaTestataEqualThis,
NullTypes.DatetimeNT DataSegnaturaEqualThis, NullTypes.IntNT IdUtenteCompilatoreEqualThis, NullTypes.IntNT IdUtenteValidatoreEqualThis)
        {
            TestataControlliLocoCollection TestataControlliLocoCollectionTemp = new TestataControlliLocoCollection();
            foreach (TestataControlliLoco TestataControlliLocoItem in this)
            {
                if (((IdTestataEqualThis == null) || ((TestataControlliLocoItem.IdTestata != null) && (TestataControlliLocoItem.IdTestata.Value == IdTestataEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TestataControlliLocoItem.DataInserimento != null) && (TestataControlliLocoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((TestataControlliLocoItem.CfInserimento != null) && (TestataControlliLocoItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((TestataControlliLocoItem.DataModifica != null) && (TestataControlliLocoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((TestataControlliLocoItem.CfModifica != null) && (TestataControlliLocoItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataSopralluogoEqualThis == null) || ((TestataControlliLocoItem.DataSopralluogo != null) && (TestataControlliLocoItem.DataSopralluogo.Value == DataSopralluogoEqualThis.Value))) &&
((LuogoSopralluogoEqualThis == null) || ((TestataControlliLocoItem.LuogoSopralluogo != null) && (TestataControlliLocoItem.LuogoSopralluogo.Value == LuogoSopralluogoEqualThis.Value))) && ((IdIstanzaChecklistGenericaEqualThis == null) || ((TestataControlliLocoItem.IdIstanzaChecklistGenerica != null) && (TestataControlliLocoItem.IdIstanzaChecklistGenerica.Value == IdIstanzaChecklistGenericaEqualThis.Value))) && ((IdlocoDettaglioEqualThis == null) || ((TestataControlliLocoItem.IdlocoDettaglio != null) && (TestataControlliLocoItem.IdlocoDettaglio.Value == IdlocoDettaglioEqualThis.Value))) &&
((EsitoTestataEqualThis == null) || ((TestataControlliLocoItem.EsitoTestata != null) && (TestataControlliLocoItem.EsitoTestata.Value == EsitoTestataEqualThis.Value))) && ((IdFileVerbaleEqualThis == null) || ((TestataControlliLocoItem.IdFileVerbale != null) && (TestataControlliLocoItem.IdFileVerbale.Value == IdFileVerbaleEqualThis.Value))) && ((DataVerbaleEqualThis == null) || ((TestataControlliLocoItem.DataVerbale != null) && (TestataControlliLocoItem.DataVerbale.Value == DataVerbaleEqualThis.Value))) &&
((IdFileAttestazioneEqualThis == null) || ((TestataControlliLocoItem.IdFileAttestazione != null) && (TestataControlliLocoItem.IdFileAttestazione.Value == IdFileAttestazioneEqualThis.Value))) && ((DataAttestazioneEqualThis == null) || ((TestataControlliLocoItem.DataAttestazione != null) && (TestataControlliLocoItem.DataAttestazione.Value == DataAttestazioneEqualThis.Value))) && ((SegnaturaTestataEqualThis == null) || ((TestataControlliLocoItem.SegnaturaTestata != null) && (TestataControlliLocoItem.SegnaturaTestata.Value == SegnaturaTestataEqualThis.Value))) &&
((DataSegnaturaEqualThis == null) || ((TestataControlliLocoItem.DataSegnatura != null) && (TestataControlliLocoItem.DataSegnatura.Value == DataSegnaturaEqualThis.Value))) && ((IdUtenteCompilatoreEqualThis == null) || ((TestataControlliLocoItem.IdUtenteCompilatore != null) && (TestataControlliLocoItem.IdUtenteCompilatore.Value == IdUtenteCompilatoreEqualThis.Value))) && ((IdUtenteValidatoreEqualThis == null) || ((TestataControlliLocoItem.IdUtenteValidatore != null) && (TestataControlliLocoItem.IdUtenteValidatore.Value == IdUtenteValidatoreEqualThis.Value))))
                {
                    TestataControlliLocoCollectionTemp.Add(TestataControlliLocoItem);
                }
            }
            return TestataControlliLocoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for TestataControlliLocoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class TestataControlliLocoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TestataControlliLoco TestataControlliLocoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdTestata", TestataControlliLocoObj.IdTestata);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", TestataControlliLocoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", TestataControlliLocoObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", TestataControlliLocoObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", TestataControlliLocoObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSopralluogo", TestataControlliLocoObj.DataSopralluogo);
            DbProvider.SetCmdParam(cmd, firstChar + "LuogoSopralluogo", TestataControlliLocoObj.LuogoSopralluogo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIstanzaChecklistGenerica", TestataControlliLocoObj.IdIstanzaChecklistGenerica);
            DbProvider.SetCmdParam(cmd, firstChar + "IdlocoDettaglio", TestataControlliLocoObj.IdlocoDettaglio);
            DbProvider.SetCmdParam(cmd, firstChar + "EsitoTestata", TestataControlliLocoObj.EsitoTestata);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFileVerbale", TestataControlliLocoObj.IdFileVerbale);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFileAttestazione", TestataControlliLocoObj.IdFileAttestazione);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaTestata", TestataControlliLocoObj.SegnaturaTestata);
            DbProvider.SetCmdParam(cmd, firstChar + "DataVerbale", TestataControlliLocoObj.DataVerbale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAttestazione", TestataControlliLocoObj.DataAttestazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSegnatura", TestataControlliLocoObj.DataSegnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "IdUtenteCompilatore", TestataControlliLocoObj.IdUtenteCompilatore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdUtenteValidatore", TestataControlliLocoObj.IdUtenteValidatore);
        }
        //Insert
        private static int Insert(DbProvider db, TestataControlliLoco TestataControlliLocoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZTestataControlliLocoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataSopralluogo", 
"LuogoSopralluogo", "IdIstanzaChecklistGenerica", 
"IdlocoDettaglio", 






"EsitoTestata", 
"IdFileVerbale", "IdFileAttestazione", 
"SegnaturaTestata", "DataVerbale", "DataAttestazione", 
"DataSegnatura", "IdUtenteCompilatore", "IdUtenteValidatore", 


}, new string[] {"DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"int", 






"bool", 
"int", "int", 
"string", "DateTime", "DateTime", 
"DateTime", "int", "int", 


}, "");
                CompileIUCmd(false, insertCmd, TestataControlliLocoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    TestataControlliLocoObj.IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
                    TestataControlliLocoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    TestataControlliLocoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    TestataControlliLocoObj.DataSopralluogo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOPRALLUOGO"]);
                }
                TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataControlliLocoObj.IsDirty = false;
                TestataControlliLocoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, TestataControlliLoco TestataControlliLocoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataControlliLocoUpdate", new string[] {"IdTestata", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataSopralluogo", 
"LuogoSopralluogo", "IdIstanzaChecklistGenerica", 
"IdlocoDettaglio", 






"EsitoTestata", 
"IdFileVerbale", "IdFileAttestazione", 
"SegnaturaTestata", "DataVerbale", "DataAttestazione", 
"DataSegnatura", "IdUtenteCompilatore", "IdUtenteValidatore", 


}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"int", 






"bool", 
"int", "int", 
"string", "DateTime", "DateTime", 
"DateTime", "int", "int", 


}, "");
                CompileIUCmd(true, updateCmd, TestataControlliLocoObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    TestataControlliLocoObj.DataModifica = d;
                }
                TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataControlliLocoObj.IsDirty = false;
                TestataControlliLocoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, TestataControlliLoco TestataControlliLocoObj)
        {
            switch (TestataControlliLocoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, TestataControlliLocoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, TestataControlliLocoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, TestataControlliLocoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, TestataControlliLocoCollection TestataControlliLocoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZTestataControlliLocoUpdate", new string[] {"IdTestata", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataSopralluogo", 
"LuogoSopralluogo", "IdIstanzaChecklistGenerica", 
"IdlocoDettaglio", 






"EsitoTestata", 
"IdFileVerbale", "IdFileAttestazione", 
"SegnaturaTestata", "DataVerbale", "DataAttestazione", 
"DataSegnatura", "IdUtenteCompilatore", "IdUtenteValidatore", 


}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"int", 






"bool", 
"int", "int", 
"string", "DateTime", "DateTime", 
"DateTime", "int", "int", 


}, "");
                IDbCommand insertCmd = db.InitCmd("ZTestataControlliLocoInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataSopralluogo", 
"LuogoSopralluogo", "IdIstanzaChecklistGenerica", 
"IdlocoDettaglio", 






"EsitoTestata", 
"IdFileVerbale", "IdFileAttestazione", 
"SegnaturaTestata", "DataVerbale", "DataAttestazione", 
"DataSegnatura", "IdUtenteCompilatore", "IdUtenteValidatore", 


}, new string[] {"DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", 
"int", 






"bool", 
"int", "int", 
"string", "DateTime", "DateTime", 
"DateTime", "int", "int", 


}, "");
                IDbCommand deleteCmd = db.InitCmd("ZTestataControlliLocoDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataControlliLocoCollectionObj.Count; i++)
                {
                    switch (TestataControlliLocoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, TestataControlliLocoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    TestataControlliLocoCollectionObj[i].IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
                                    TestataControlliLocoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    TestataControlliLocoCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    TestataControlliLocoCollectionObj[i].DataSopralluogo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOPRALLUOGO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, TestataControlliLocoCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    TestataControlliLocoCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (TestataControlliLocoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)TestataControlliLocoCollectionObj[i].IdTestata);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < TestataControlliLocoCollectionObj.Count; i++)
                {
                    if ((TestataControlliLocoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataControlliLocoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataControlliLocoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        TestataControlliLocoCollectionObj[i].IsDirty = false;
                        TestataControlliLocoCollectionObj[i].IsPersistent = true;
                    }
                    if ((TestataControlliLocoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        TestataControlliLocoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataControlliLocoCollectionObj[i].IsDirty = false;
                        TestataControlliLocoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, TestataControlliLoco TestataControlliLocoObj)
        {
            int returnValue = 0;
            if (TestataControlliLocoObj.IsPersistent)
            {
                returnValue = Delete(db, TestataControlliLocoObj.IdTestata);
            }
            TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            TestataControlliLocoObj.IsDirty = false;
            TestataControlliLocoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdTestataValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataControlliLocoDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)IdTestataValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, TestataControlliLocoCollection TestataControlliLocoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZTestataControlliLocoDelete", new string[] { "IdTestata" }, new string[] { "int" }, "");
                for (int i = 0; i < TestataControlliLocoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdTestata", TestataControlliLocoCollectionObj[i].IdTestata);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < TestataControlliLocoCollectionObj.Count; i++)
                {
                    if ((TestataControlliLocoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataControlliLocoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        TestataControlliLocoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        TestataControlliLocoCollectionObj[i].IsDirty = false;
                        TestataControlliLocoCollectionObj[i].IsPersistent = false;
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
        public static TestataControlliLoco GetById(DbProvider db, int IdTestataValue)
        {
            TestataControlliLoco TestataControlliLocoObj = null;
            IDbCommand readCmd = db.InitCmd("ZTestataControlliLocoGetById", new string[] { "IdTestata" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdTestata", (SiarLibrary.NullTypes.IntNT)IdTestataValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                TestataControlliLocoObj = GetFromDatareader(db);
                TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataControlliLocoObj.IsDirty = false;
                TestataControlliLocoObj.IsPersistent = true;
            }
            db.Close();
            return TestataControlliLocoObj;
        }

        //getFromDatareader
        public static TestataControlliLoco GetFromDatareader(DbProvider db)
        {
            TestataControlliLoco TestataControlliLocoObj = new TestataControlliLoco();
            TestataControlliLocoObj.IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
            TestataControlliLocoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            TestataControlliLocoObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            TestataControlliLocoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            TestataControlliLocoObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            TestataControlliLocoObj.DataSopralluogo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOPRALLUOGO"]);
            TestataControlliLocoObj.LuogoSopralluogo = new SiarLibrary.NullTypes.StringNT(db.DataReader["LUOGO_SOPRALLUOGO"]);
            TestataControlliLocoObj.IdIstanzaChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_CHECKLIST_GENERICA"]);
            TestataControlliLocoObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
            TestataControlliLocoObj.IdlocoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IDLOCO_DETTAGLIO"]);
            TestataControlliLocoObj.Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
            TestataControlliLocoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
            TestataControlliLocoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
            TestataControlliLocoObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["Asse"]);
            TestataControlliLocoObj.Selezionata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Selezionata"]);
            TestataControlliLocoObj.EsitoControllo = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_CONTROLLO"]);
            TestataControlliLocoObj.DataesitoControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATAESITO_CONTROLLO"]);
            TestataControlliLocoObj.Costototale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CostoTotale"]);
            TestataControlliLocoObj.Importoammesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoAmmesso"]);
            TestataControlliLocoObj.Importoconcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoConcesso"]);
            TestataControlliLocoObj.Nroperazionib = new SiarLibrary.NullTypes.IntNT(db.DataReader["NrOperazioniB"]);
            TestataControlliLocoObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["Beneficiario"]);
            TestataControlliLocoObj.Spesaammessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa"]);
            TestataControlliLocoObj.Importocontributopubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico"]);
            TestataControlliLocoObj.ImportocontributopubblicoIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico_Incrementale"]);
            TestataControlliLocoObj.SpesaammessaIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa_Incrementale"]);
            TestataControlliLocoObj.Esclusione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Esclusione"]);
            TestataControlliLocoObj.Rischioir = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioIR"]);
            TestataControlliLocoObj.Rischiocr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioCR"]);
            TestataControlliLocoObj.Rischiocomp = new SiarLibrary.NullTypes.StringNT(db.DataReader["RischioComp"]);
            TestataControlliLocoObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Azione"]);
            TestataControlliLocoObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["Intervento"]);
            TestataControlliLocoObj.EsitoTestata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_TESTATA"]);
            TestataControlliLocoObj.IdFileVerbale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_VERBALE"]);
            TestataControlliLocoObj.IdFileAttestazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_ATTESTAZIONE"]);
            TestataControlliLocoObj.TipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA"]);
            TestataControlliLocoObj.SegnaturaTestata = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_TESTATA"]);
            TestataControlliLocoObj.DataVerbale = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VERBALE"]);
            TestataControlliLocoObj.DataAttestazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTESTAZIONE"]);
            TestataControlliLocoObj.DataSegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNATURA"]);
            TestataControlliLocoObj.IdUtenteCompilatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_COMPILATORE"]);
            TestataControlliLocoObj.IdUtenteValidatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_VALIDATORE"]);
            TestataControlliLocoObj.IdPersonaFisicaCompilatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA_COMPILATORE"]);
            TestataControlliLocoObj.IdStoricoUltimoCompilatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO_COMPILATORE"]);
            TestataControlliLocoObj.CfUtenteCompilatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_COMPILATORE"]);
            TestataControlliLocoObj.ProfiloCompilatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO_COMPILATORE"]);
            TestataControlliLocoObj.EnteCompilatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE_COMPILATORE"]);
            TestataControlliLocoObj.NominativoCompilatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_COMPILATORE"]);
            TestataControlliLocoObj.IdPersonaFisicaValidatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA_FISICA_VALIDATORE"]);
            TestataControlliLocoObj.IdStoricoUltimoValidatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO_VALIDATORE"]);
            TestataControlliLocoObj.CfUtenteValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_VALIDATORE"]);
            TestataControlliLocoObj.ProfiloValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO_VALIDATORE"]);
            TestataControlliLocoObj.EnteValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE_VALIDATORE"]);
            TestataControlliLocoObj.NominativoValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_VALIDATORE"]);
            TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            TestataControlliLocoObj.IsDirty = false;
            TestataControlliLocoObj.IsPersistent = true;
            return TestataControlliLocoObj;
        }

        //Find Select

        public static TestataControlliLocoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSopralluogoEqualThis,
SiarLibrary.NullTypes.StringNT LuogoSopralluogoEqualThis, SiarLibrary.NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdlocoDettaglioEqualThis,
SiarLibrary.NullTypes.BoolNT EsitoTestataEqualThis, SiarLibrary.NullTypes.IntNT IdFileVerbaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataVerbaleEqualThis,
SiarLibrary.NullTypes.IntNT IdFileAttestazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAttestazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaTestataEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataSegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteCompilatoreEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteValidatoreEqualThis)
        {

            TestataControlliLocoCollection TestataControlliLocoCollectionObj = new TestataControlliLocoCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatacontrollilocofindselect", new string[] {"IdTestataequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "DataSopralluogoequalthis", 
"LuogoSopralluogoequalthis", "IdIstanzaChecklistGenericaequalthis", "IdlocoDettaglioequalthis", 
"EsitoTestataequalthis", "IdFileVerbaleequalthis", "DataVerbaleequalthis", 
"IdFileAttestazioneequalthis", "DataAttestazioneequalthis", "SegnaturaTestataequalthis", 
"DataSegnaturaequalthis", "IdUtenteCompilatoreequalthis", "IdUtenteValidatoreequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"string", "int", "int", 
"bool", "int", "DateTime", 
"int", "DateTime", "string", 
"DateTime", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataequalthis", IdTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSopralluogoequalthis", DataSopralluogoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LuogoSopralluogoequalthis", LuogoSopralluogoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaChecklistGenericaequalthis", IdIstanzaChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdlocoDettaglioequalthis", IdlocoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "EsitoTestataequalthis", EsitoTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileVerbaleequalthis", IdFileVerbaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataVerbaleequalthis", DataVerbaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileAttestazioneequalthis", IdFileAttestazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAttestazioneequalthis", DataAttestazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaTestataequalthis", SegnaturaTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSegnaturaequalthis", DataSegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteCompilatoreequalthis", IdUtenteCompilatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteValidatoreequalthis", IdUtenteValidatoreEqualThis);
            TestataControlliLoco TestataControlliLocoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataControlliLocoObj = GetFromDatareader(db);
                TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataControlliLocoObj.IsDirty = false;
                TestataControlliLocoObj.IsPersistent = true;
                TestataControlliLocoCollectionObj.Add(TestataControlliLocoObj);
            }
            db.Close();
            return TestataControlliLocoCollectionObj;
        }

        //Find Find

        public static TestataControlliLocoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataEqualThis, SiarLibrary.NullTypes.IntNT IdlocoEqualThis, SiarLibrary.NullTypes.IntNT IdlocoDettaglioEqualThis,
SiarLibrary.NullTypes.IntNT IdIstanzaChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)
        {

            TestataControlliLocoCollection TestataControlliLocoCollectionObj = new TestataControlliLocoCollection();

            IDbCommand findCmd = db.InitCmd("Ztestatacontrollilocofindfind", new string[] {"IdTestataequalthis", "Idlocoequalthis", "IdlocoDettaglioequalthis", 
"IdIstanzaChecklistGenericaequalthis", "IdChecklistGenericaequalthis", "IdDomandaPagamentoequalthis", 
"IdProgettoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTestataequalthis", IdTestataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idlocoequalthis", IdlocoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdlocoDettaglioequalthis", IdlocoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIstanzaChecklistGenericaequalthis", IdIstanzaChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            TestataControlliLoco TestataControlliLocoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                TestataControlliLocoObj = GetFromDatareader(db);
                TestataControlliLocoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                TestataControlliLocoObj.IsDirty = false;
                TestataControlliLocoObj.IsPersistent = true;
                TestataControlliLocoCollectionObj.Add(TestataControlliLocoObj);
            }
            db.Close();
            return TestataControlliLocoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for TestataControlliLocoCollectionProvider:ITestataControlliLocoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class TestataControlliLocoCollectionProvider : ITestataControlliLocoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di TestataControlliLoco
        protected TestataControlliLocoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public TestataControlliLocoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new TestataControlliLocoCollection(this);
        }

        //Costruttore 2: popola la collection
        public TestataControlliLocoCollectionProvider(IntNT IdtestataEqualThis, IntNT IdlocoEqualThis, IntNT IdlocodettaglioEqualThis,
IntNT IdistanzachecklistgenericaEqualThis, IntNT IdchecklistgenericaEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdtestataEqualThis, IdlocoEqualThis, IdlocodettaglioEqualThis,
IdistanzachecklistgenericaEqualThis, IdchecklistgenericaEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis);
        }

        //Costruttore3: ha in input testatacontrollilocoCollectionObj - non popola la collection
        public TestataControlliLocoCollectionProvider(TestataControlliLocoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public TestataControlliLocoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new TestataControlliLocoCollection(this);
        }

        //Get e Set
        public TestataControlliLocoCollection CollectionObj
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
        public int SaveCollection(TestataControlliLocoCollection collectionObj)
        {
            return TestataControlliLocoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(TestataControlliLoco testatacontrollilocoObj)
        {
            return TestataControlliLocoDAL.Save(_dbProviderObj, testatacontrollilocoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(TestataControlliLocoCollection collectionObj)
        {
            return TestataControlliLocoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(TestataControlliLoco testatacontrollilocoObj)
        {
            return TestataControlliLocoDAL.Delete(_dbProviderObj, testatacontrollilocoObj);
        }

        //getById
        public TestataControlliLoco GetById(IntNT IdTestataValue)
        {
            TestataControlliLoco TestataControlliLocoTemp = TestataControlliLocoDAL.GetById(_dbProviderObj, IdTestataValue);
            if (TestataControlliLocoTemp != null) TestataControlliLocoTemp.Provider = this;
            return TestataControlliLocoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public TestataControlliLocoCollection Select(IntNT IdtestataEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, DatetimeNT DatasopralluogoEqualThis,
StringNT LuogosopralluogoEqualThis, IntNT IdistanzachecklistgenericaEqualThis, IntNT IdlocodettaglioEqualThis,
BoolNT EsitotestataEqualThis, IntNT IdfileverbaleEqualThis, DatetimeNT DataverbaleEqualThis,
IntNT IdfileattestazioneEqualThis, DatetimeNT DataattestazioneEqualThis, StringNT SegnaturatestataEqualThis,
DatetimeNT DatasegnaturaEqualThis, IntNT IdutentecompilatoreEqualThis, IntNT IdutentevalidatoreEqualThis)
        {
            TestataControlliLocoCollection TestataControlliLocoCollectionTemp = TestataControlliLocoDAL.Select(_dbProviderObj, IdtestataEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis,
DatamodificaEqualThis, CfmodificaEqualThis, DatasopralluogoEqualThis,
LuogosopralluogoEqualThis, IdistanzachecklistgenericaEqualThis, IdlocodettaglioEqualThis,
EsitotestataEqualThis, IdfileverbaleEqualThis, DataverbaleEqualThis,
IdfileattestazioneEqualThis, DataattestazioneEqualThis, SegnaturatestataEqualThis,
DatasegnaturaEqualThis, IdutentecompilatoreEqualThis, IdutentevalidatoreEqualThis);
            TestataControlliLocoCollectionTemp.Provider = this;
            return TestataControlliLocoCollectionTemp;
        }

        //Find: popola la collection
        public TestataControlliLocoCollection Find(IntNT IdtestataEqualThis, IntNT IdlocoEqualThis, IntNT IdlocodettaglioEqualThis,
IntNT IdistanzachecklistgenericaEqualThis, IntNT IdchecklistgenericaEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis)
        {
            TestataControlliLocoCollection TestataControlliLocoCollectionTemp = TestataControlliLocoDAL.Find(_dbProviderObj, IdtestataEqualThis, IdlocoEqualThis, IdlocodettaglioEqualThis,
IdistanzachecklistgenericaEqualThis, IdchecklistgenericaEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis);
            TestataControlliLocoCollectionTemp.Provider = this;
            return TestataControlliLocoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TESTATA_CONTROLLI_LOCO>
  <ViewName>VTESTATA_CONTROLLI_LOCO</ViewName>
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
      <ID_TESTATA>Equal</ID_TESTATA>
      <IdLoco>Equal</IdLoco>
      <IDLOCO_DETTAGLIO>Equal</IDLOCO_DETTAGLIO>
      <ID_ISTANZA_CHECKLIST_GENERICA>Equal</ID_ISTANZA_CHECKLIST_GENERICA>
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <Id_Domanda_Pagamento>Equal</Id_Domanda_Pagamento>
      <Id_Progetto>Equal</Id_Progetto>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TESTATA_CONTROLLI_LOCO>
*/
