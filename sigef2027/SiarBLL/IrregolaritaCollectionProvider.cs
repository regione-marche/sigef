using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Irregolarita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIrregolaritaProvider
	{
		int Save(Irregolarita IrregolaritaObj);
		int SaveCollection(IrregolaritaCollection collectionObj);
		int Delete(Irregolarita IrregolaritaObj);
		int DeleteCollection(IrregolaritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Irregolarita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Irregolarita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdIrregolarita;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdTipoIrregolarita;
		private NullTypes.IntNT _IdControlloOrigine;
		private NullTypes.BoolNT _SospettoFrode;
		private NullTypes.DatetimeNT _DataCostatazioneAmministrativa;
		private NullTypes.BoolNT _ImportoIrregolareDaRecuperare;
		private NullTypes.BoolNT _SegnalazioneOlaf;
		private NullTypes.DatetimeNT _DataSegnalazioneOlaf;
		private NullTypes.StringNT _TrimestreSegnalazioneOlaf;
		private NullTypes.DatetimeNT _DataPrimaInformazione;
		private NullTypes.StringNT _FontePrimaInformazione;
		private NullTypes.IntNT _IdImpresaCommessaDa;
		private NullTypes.StringNT _NoteCommessaDa;
		private NullTypes.IntNT _IdCategoria;
		private NullTypes.IntNT _IdTipo;
		private NullTypes.IntNT _IdClassificazione;
		private NullTypes.StringNT _PraticheUtilizzate;
		private NullTypes.StringNT _NoteGiustificativi;
		private NullTypes.DecimalNT _ImportoSpesa;
		private NullTypes.DecimalNT _ContributoAmmesso;
		private NullTypes.DecimalNT _ContributoPubblico;
		private NullTypes.DecimalNT _ContributoAmmessoCertificato;
		private NullTypes.DecimalNT _ContributoPubblicoCertificato;
		private NullTypes.DecimalNT _ContributoPubblicoDaRecuperare;
		private NullTypes.StringNT _CommentiImpattiFinanziario;
		private NullTypes.BoolNT _ProcedimentoAmministrativo;
		private NullTypes.BoolNT _AzioneGiudiziaria;
		private NullTypes.BoolNT _AzionePenale;
		private NullTypes.IntNT _IdStatoFinanziario;
		private NullTypes.BoolNT _StabilitaOperazioni;
		private NullTypes.StringNT _NumeroProtocollo;
		private NullTypes.StringNT _NumeroOlaf;
		private NullTypes.DatetimeNT _DataSegnalazione;
		private NullTypes.DatetimeNT _DataSegnalazioneDa;
		private NullTypes.DatetimeNT _DataSegnalazioneA;
		private NullTypes.BoolNT _DaRecuperare;
		private NullTypes.BoolNT _Recuperato;
		private NullTypes.StringNT _AzioneCertificazione;
		private NullTypes.DecimalNT _ContributoRecuperareBeneficiario;
		private NullTypes.DecimalNT _ContributoAmmessoProgetto;
		private NullTypes.DatetimeNT _DataRegistrazioneAdc;
		private NullTypes.StringNT _TipoIrregolarita;
		private NullTypes.BoolNT _AttivoTipoIrregolarita;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodStatoProgetto;
		private NullTypes.StringNT _StatoProgetto;
		private NullTypes.StringNT _CodFaseProgetto;
		private NullTypes.StringNT _FaseProgetto;
		private NullTypes.IntNT _IdImpresaProgetto;
		private NullTypes.StringNT _CuaaImpresaIrregolarita;
		private NullTypes.StringNT _CodiceFiscaleImpresaIrregolarita;
		private NullTypes.StringNT _RagioneSocialeImpresaIrregolarita;
		private NullTypes.StringNT _DescrizioneCategoria;
		private NullTypes.StringNT _DescrizioneControlloOrigine;
		private NullTypes.StringNT _DescrizioneTipo;
		private NullTypes.StringNT _DescrizioneClassificazione;
		private NullTypes.StringNT _DescrizioneStatoFinanziario;
		[NonSerialized] private IIrregolaritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIrregolaritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Irregolarita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_IRREGOLARITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIrregolarita
		{
			get { return _IdIrregolarita; }
			set {
				if (IdIrregolarita != value)
				{
					_IdIrregolarita = value;
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
			set {
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
			set {
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
			set {
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
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
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
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
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
			set {
				if (IdTipoIrregolarita != value)
				{
					_IdTipoIrregolarita = value;
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
			set {
				if (IdControlloOrigine != value)
				{
					_IdControlloOrigine = value;
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
			set {
				if (SospettoFrode != value)
				{
					_SospettoFrode = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_COSTATAZIONE_AMMINISTRATIVA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataCostatazioneAmministrativa
		{
			get { return _DataCostatazioneAmministrativa; }
			set {
				if (DataCostatazioneAmministrativa != value)
				{
					_DataCostatazioneAmministrativa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_IRREGOLARE_DA_RECUPERARE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ImportoIrregolareDaRecuperare
		{
			get { return _ImportoIrregolareDaRecuperare; }
			set {
				if (ImportoIrregolareDaRecuperare != value)
				{
					_ImportoIrregolareDaRecuperare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNALAZIONE_OLAF
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SegnalazioneOlaf
		{
			get { return _SegnalazioneOlaf; }
			set {
				if (SegnalazioneOlaf != value)
				{
					_SegnalazioneOlaf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SEGNALAZIONE_OLAF
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSegnalazioneOlaf
		{
			get { return _DataSegnalazioneOlaf; }
			set {
				if (DataSegnalazioneOlaf != value)
				{
					_DataSegnalazioneOlaf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TRIMESTRE_SEGNALAZIONE_OLAF
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TrimestreSegnalazioneOlaf
		{
			get { return _TrimestreSegnalazioneOlaf; }
			set {
				if (TrimestreSegnalazioneOlaf != value)
				{
					_TrimestreSegnalazioneOlaf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PRIMA_INFORMAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPrimaInformazione
		{
			get { return _DataPrimaInformazione; }
			set {
				if (DataPrimaInformazione != value)
				{
					_DataPrimaInformazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FONTE_PRIMA_INFORMAZIONE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT FontePrimaInformazione
		{
			get { return _FontePrimaInformazione; }
			set {
				if (FontePrimaInformazione != value)
				{
					_FontePrimaInformazione = value;
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
			set {
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
			set {
				if (NoteCommessaDa != value)
				{
					_NoteCommessaDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CATEGORIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCategoria
		{
			get { return _IdCategoria; }
			set {
				if (IdCategoria != value)
				{
					_IdCategoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipo
		{
			get { return _IdTipo; }
			set {
				if (IdTipo != value)
				{
					_IdTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CLASSIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdClassificazione
		{
			get { return _IdClassificazione; }
			set {
				if (IdClassificazione != value)
				{
					_IdClassificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRATICHE_UTILIZZATE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT PraticheUtilizzate
		{
			get { return _PraticheUtilizzate; }
			set {
				if (PraticheUtilizzate != value)
				{
					_PraticheUtilizzate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_GIUSTIFICATIVI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT NoteGiustificativi
		{
			get { return _NoteGiustificativi; }
			set {
				if (NoteGiustificativi != value)
				{
					_NoteGiustificativi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_SPESA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoSpesa
		{
			get { return _ImportoSpesa; }
			set {
				if (ImportoSpesa != value)
				{
					_ImportoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmesso
		{
			get { return _ContributoAmmesso; }
			set {
				if (ContributoAmmesso != value)
				{
					_ContributoAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_PUBBLICO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoPubblico
		{
			get { return _ContributoPubblico; }
			set {
				if (ContributoPubblico != value)
				{
					_ContributoPubblico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO_CERTIFICATO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmessoCertificato
		{
			get { return _ContributoAmmessoCertificato; }
			set {
				if (ContributoAmmessoCertificato != value)
				{
					_ContributoAmmessoCertificato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_PUBBLICO_CERTIFICATO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoPubblicoCertificato
		{
			get { return _ContributoPubblicoCertificato; }
			set {
				if (ContributoPubblicoCertificato != value)
				{
					_ContributoPubblicoCertificato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_PUBBLICO_DA_RECUPERARE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoPubblicoDaRecuperare
		{
			get { return _ContributoPubblicoDaRecuperare; }
			set {
				if (ContributoPubblicoDaRecuperare != value)
				{
					_ContributoPubblicoDaRecuperare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMMENTI_IMPATTI_FINANZIARIO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT CommentiImpattiFinanziario
		{
			get { return _CommentiImpattiFinanziario; }
			set {
				if (CommentiImpattiFinanziario != value)
				{
					_CommentiImpattiFinanziario = value;
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
			set {
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
			set {
				if (AzioneGiudiziaria != value)
				{
					_AzioneGiudiziaria = value;
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
			set {
				if (AzionePenale != value)
				{
					_AzionePenale = value;
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
			set {
				if (IdStatoFinanziario != value)
				{
					_IdStatoFinanziario = value;
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
			set {
				if (StabilitaOperazioni != value)
				{
					_StabilitaOperazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT NumeroProtocollo
		{
			get { return _NumeroProtocollo; }
			set {
				if (NumeroProtocollo != value)
				{
					_NumeroProtocollo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_OLAF
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT NumeroOlaf
		{
			get { return _NumeroOlaf; }
			set {
				if (NumeroOlaf != value)
				{
					_NumeroOlaf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SEGNALAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSegnalazione
		{
			get { return _DataSegnalazione; }
			set {
				if (DataSegnalazione != value)
				{
					_DataSegnalazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SEGNALAZIONE_DA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSegnalazioneDa
		{
			get { return _DataSegnalazioneDa; }
			set {
				if (DataSegnalazioneDa != value)
				{
					_DataSegnalazioneDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SEGNALAZIONE_A
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSegnalazioneA
		{
			get { return _DataSegnalazioneA; }
			set {
				if (DataSegnalazioneA != value)
				{
					_DataSegnalazioneA = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DA_RECUPERARE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DaRecuperare
		{
			get { return _DaRecuperare; }
			set {
				if (DaRecuperare != value)
				{
					_DaRecuperare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RECUPERATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Recuperato
		{
			get { return _Recuperato; }
			set {
				if (Recuperato != value)
				{
					_Recuperato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AZIONE_CERTIFICAZIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT AzioneCertificazione
		{
			get { return _AzioneCertificazione; }
			set {
				if (AzioneCertificazione != value)
				{
					_AzioneCertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RECUPERARE_BENEFICIARIO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRecuperareBeneficiario
		{
			get { return _ContributoRecuperareBeneficiario; }
			set {
				if (ContributoRecuperareBeneficiario != value)
				{
					_ContributoRecuperareBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO_PROGETTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmessoProgetto
		{
			get { return _ContributoAmmessoProgetto; }
			set {
				if (ContributoAmmessoProgetto != value)
				{
					_ContributoAmmessoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_REGISTRAZIONE_ADC
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRegistrazioneAdc
		{
			get { return _DataRegistrazioneAdc; }
			set {
				if (DataRegistrazioneAdc != value)
				{
					_DataRegistrazioneAdc = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_IRREGOLARITA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TipoIrregolarita
		{
			get { return _TipoIrregolarita; }
			set {
				if (TipoIrregolarita != value)
				{
					_TipoIrregolarita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO_TIPO_IRREGOLARITA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AttivoTipoIrregolarita
		{
			get { return _AttivoTipoIrregolarita; }
			set {
				if (AttivoTipoIrregolarita != value)
				{
					_AttivoTipoIrregolarita = value;
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
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO_PROGETTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStatoProgetto
		{
			get { return _CodStatoProgetto; }
			set {
				if (CodStatoProgetto != value)
				{
					_CodStatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_PROGETTO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT StatoProgetto
		{
			get { return _StatoProgetto; }
			set {
				if (StatoProgetto != value)
				{
					_StatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE_PROGETTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFaseProgetto
		{
			get { return _CodFaseProgetto; }
			set {
				if (CodFaseProgetto != value)
				{
					_CodFaseProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE_PROGETTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT FaseProgetto
		{
			get { return _FaseProgetto; }
			set {
				if (FaseProgetto != value)
				{
					_FaseProgetto = value;
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
			set {
				if (IdImpresaProgetto != value)
				{
					_IdImpresaProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_IMPRESA_IRREGOLARITA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaImpresaIrregolarita
		{
			get { return _CuaaImpresaIrregolarita; }
			set {
				if (CuaaImpresaIrregolarita != value)
				{
					_CuaaImpresaIrregolarita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE_IMPRESA_IRREGOLARITA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscaleImpresaIrregolarita
		{
			get { return _CodiceFiscaleImpresaIrregolarita; }
			set {
				if (CodiceFiscaleImpresaIrregolarita != value)
				{
					_CodiceFiscaleImpresaIrregolarita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE_IMPRESA_IRREGOLARITA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSocialeImpresaIrregolarita
		{
			get { return _RagioneSocialeImpresaIrregolarita; }
			set {
				if (RagioneSocialeImpresaIrregolarita != value)
				{
					_RagioneSocialeImpresaIrregolarita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CATEGORIA
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT DescrizioneCategoria
		{
			get { return _DescrizioneCategoria; }
			set {
				if (DescrizioneCategoria != value)
				{
					_DescrizioneCategoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CONTROLLO_ORIGINE
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT DescrizioneControlloOrigine
		{
			get { return _DescrizioneControlloOrigine; }
			set {
				if (DescrizioneControlloOrigine != value)
				{
					_DescrizioneControlloOrigine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipo
		{
			get { return _DescrizioneTipo; }
			set {
				if (DescrizioneTipo != value)
				{
					_DescrizioneTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CLASSIFICAZIONE
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT DescrizioneClassificazione
		{
			get { return _DescrizioneClassificazione; }
			set {
				if (DescrizioneClassificazione != value)
				{
					_DescrizioneClassificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_STATO_FINANZIARIO
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT DescrizioneStatoFinanziario
		{
			get { return _DescrizioneStatoFinanziario; }
			set {
				if (DescrizioneStatoFinanziario != value)
				{
					_DescrizioneStatoFinanziario = value;
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
	/// Summary description for IrregolaritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IrregolaritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private IrregolaritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Irregolarita) info.GetValue(i.ToString(),typeof(Irregolarita)));
			}
		}

		//Costruttore
		public IrregolaritaCollection()
		{
			this.ItemType = typeof(Irregolarita);
		}

		//Costruttore con provider
		public IrregolaritaCollection(IIrregolaritaProvider providerObj)
		{
			this.ItemType = typeof(Irregolarita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Irregolarita this[int index]
		{
			get { return (Irregolarita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IrregolaritaCollection GetChanges()
		{
			return (IrregolaritaCollection) base.GetChanges();
		}

		[NonSerialized] private IIrregolaritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIrregolaritaProvider Provider
		{
			get {return _provider;}
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
		public int Add(Irregolarita IrregolaritaObj)
		{
			if (IrregolaritaObj.Provider == null) IrregolaritaObj.Provider = this.Provider;
			return base.Add(IrregolaritaObj);
		}

		//AddCollection
		public void AddCollection(IrregolaritaCollection IrregolaritaCollectionObj)
		{
			foreach (Irregolarita IrregolaritaObj in IrregolaritaCollectionObj)
				this.Add(IrregolaritaObj);
		}

		//Insert
		public void Insert(int index, Irregolarita IrregolaritaObj)
		{
			if (IrregolaritaObj.Provider == null) IrregolaritaObj.Provider = this.Provider;
			base.Insert(index, IrregolaritaObj);
		}

		//CollectionGetById
		public Irregolarita CollectionGetById(NullTypes.IntNT IdIrregolaritaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
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
		public IrregolaritaCollection SubSelect(NullTypes.IntNT IdIrregolaritaEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdTipoIrregolaritaEqualThis, NullTypes.IntNT IdControlloOrigineEqualThis, NullTypes.BoolNT SospettoFrodeEqualThis, 
NullTypes.DatetimeNT DataCostatazioneAmministrativaEqualThis, NullTypes.BoolNT ImportoIrregolareDaRecuperareEqualThis, NullTypes.BoolNT SegnalazioneOlafEqualThis, 
NullTypes.DatetimeNT DataSegnalazioneOlafEqualThis, NullTypes.StringNT TrimestreSegnalazioneOlafEqualThis, NullTypes.DatetimeNT DataPrimaInformazioneEqualThis, 
NullTypes.StringNT FontePrimaInformazioneEqualThis, NullTypes.IntNT IdImpresaCommessaDaEqualThis, NullTypes.StringNT NoteCommessaDaEqualThis, 
NullTypes.IntNT IdCategoriaEqualThis, NullTypes.IntNT IdTipoEqualThis, NullTypes.IntNT IdClassificazioneEqualThis, 
NullTypes.StringNT PraticheUtilizzateEqualThis, NullTypes.StringNT NoteGiustificativiEqualThis, NullTypes.DecimalNT ImportoSpesaEqualThis, 
NullTypes.DecimalNT ContributoAmmessoEqualThis, NullTypes.DecimalNT ContributoPubblicoEqualThis, NullTypes.DecimalNT ContributoAmmessoCertificatoEqualThis, 
NullTypes.DecimalNT ContributoPubblicoCertificatoEqualThis, NullTypes.DecimalNT ContributoPubblicoDaRecuperareEqualThis, NullTypes.StringNT CommentiImpattiFinanziarioEqualThis, 
NullTypes.BoolNT ProcedimentoAmministrativoEqualThis, NullTypes.BoolNT AzioneGiudiziariaEqualThis, NullTypes.BoolNT AzionePenaleEqualThis, 
NullTypes.IntNT IdStatoFinanziarioEqualThis, NullTypes.BoolNT StabilitaOperazioniEqualThis, NullTypes.StringNT NumeroProtocolloEqualThis, 
NullTypes.StringNT NumeroOlafEqualThis, NullTypes.DatetimeNT DataSegnalazioneEqualThis, NullTypes.DatetimeNT DataSegnalazioneDaEqualThis, 
NullTypes.DatetimeNT DataSegnalazioneAEqualThis, NullTypes.BoolNT DaRecuperareEqualThis, NullTypes.BoolNT RecuperatoEqualThis, 
NullTypes.StringNT AzioneCertificazioneEqualThis, NullTypes.DecimalNT ContributoRecuperareBeneficiarioEqualThis, NullTypes.DecimalNT ContributoAmmessoProgettoEqualThis, 
NullTypes.DatetimeNT DataRegistrazioneAdcEqualThis)
		{
			IrregolaritaCollection IrregolaritaCollectionTemp = new IrregolaritaCollection();
			foreach (Irregolarita IrregolaritaItem in this)
			{
				if (((IdIrregolaritaEqualThis == null) || ((IrregolaritaItem.IdIrregolarita != null) && (IrregolaritaItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((IrregolaritaItem.CfInserimento != null) && (IrregolaritaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((IrregolaritaItem.DataInserimento != null) && (IrregolaritaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((IrregolaritaItem.CfModifica != null) && (IrregolaritaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((IrregolaritaItem.DataModifica != null) && (IrregolaritaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((IrregolaritaItem.IdProgetto != null) && (IrregolaritaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdTipoIrregolaritaEqualThis == null) || ((IrregolaritaItem.IdTipoIrregolarita != null) && (IrregolaritaItem.IdTipoIrregolarita.Value == IdTipoIrregolaritaEqualThis.Value))) && ((IdControlloOrigineEqualThis == null) || ((IrregolaritaItem.IdControlloOrigine != null) && (IrregolaritaItem.IdControlloOrigine.Value == IdControlloOrigineEqualThis.Value))) && ((SospettoFrodeEqualThis == null) || ((IrregolaritaItem.SospettoFrode != null) && (IrregolaritaItem.SospettoFrode.Value == SospettoFrodeEqualThis.Value))) && 
((DataCostatazioneAmministrativaEqualThis == null) || ((IrregolaritaItem.DataCostatazioneAmministrativa != null) && (IrregolaritaItem.DataCostatazioneAmministrativa.Value == DataCostatazioneAmministrativaEqualThis.Value))) && ((ImportoIrregolareDaRecuperareEqualThis == null) || ((IrregolaritaItem.ImportoIrregolareDaRecuperare != null) && (IrregolaritaItem.ImportoIrregolareDaRecuperare.Value == ImportoIrregolareDaRecuperareEqualThis.Value))) && ((SegnalazioneOlafEqualThis == null) || ((IrregolaritaItem.SegnalazioneOlaf != null) && (IrregolaritaItem.SegnalazioneOlaf.Value == SegnalazioneOlafEqualThis.Value))) && 
((DataSegnalazioneOlafEqualThis == null) || ((IrregolaritaItem.DataSegnalazioneOlaf != null) && (IrregolaritaItem.DataSegnalazioneOlaf.Value == DataSegnalazioneOlafEqualThis.Value))) && ((TrimestreSegnalazioneOlafEqualThis == null) || ((IrregolaritaItem.TrimestreSegnalazioneOlaf != null) && (IrregolaritaItem.TrimestreSegnalazioneOlaf.Value == TrimestreSegnalazioneOlafEqualThis.Value))) && ((DataPrimaInformazioneEqualThis == null) || ((IrregolaritaItem.DataPrimaInformazione != null) && (IrregolaritaItem.DataPrimaInformazione.Value == DataPrimaInformazioneEqualThis.Value))) && 
((FontePrimaInformazioneEqualThis == null) || ((IrregolaritaItem.FontePrimaInformazione != null) && (IrregolaritaItem.FontePrimaInformazione.Value == FontePrimaInformazioneEqualThis.Value))) && ((IdImpresaCommessaDaEqualThis == null) || ((IrregolaritaItem.IdImpresaCommessaDa != null) && (IrregolaritaItem.IdImpresaCommessaDa.Value == IdImpresaCommessaDaEqualThis.Value))) && ((NoteCommessaDaEqualThis == null) || ((IrregolaritaItem.NoteCommessaDa != null) && (IrregolaritaItem.NoteCommessaDa.Value == NoteCommessaDaEqualThis.Value))) && 
((IdCategoriaEqualThis == null) || ((IrregolaritaItem.IdCategoria != null) && (IrregolaritaItem.IdCategoria.Value == IdCategoriaEqualThis.Value))) && ((IdTipoEqualThis == null) || ((IrregolaritaItem.IdTipo != null) && (IrregolaritaItem.IdTipo.Value == IdTipoEqualThis.Value))) && ((IdClassificazioneEqualThis == null) || ((IrregolaritaItem.IdClassificazione != null) && (IrregolaritaItem.IdClassificazione.Value == IdClassificazioneEqualThis.Value))) && 
((PraticheUtilizzateEqualThis == null) || ((IrregolaritaItem.PraticheUtilizzate != null) && (IrregolaritaItem.PraticheUtilizzate.Value == PraticheUtilizzateEqualThis.Value))) && ((NoteGiustificativiEqualThis == null) || ((IrregolaritaItem.NoteGiustificativi != null) && (IrregolaritaItem.NoteGiustificativi.Value == NoteGiustificativiEqualThis.Value))) && ((ImportoSpesaEqualThis == null) || ((IrregolaritaItem.ImportoSpesa != null) && (IrregolaritaItem.ImportoSpesa.Value == ImportoSpesaEqualThis.Value))) && 
((ContributoAmmessoEqualThis == null) || ((IrregolaritaItem.ContributoAmmesso != null) && (IrregolaritaItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && ((ContributoPubblicoEqualThis == null) || ((IrregolaritaItem.ContributoPubblico != null) && (IrregolaritaItem.ContributoPubblico.Value == ContributoPubblicoEqualThis.Value))) && ((ContributoAmmessoCertificatoEqualThis == null) || ((IrregolaritaItem.ContributoAmmessoCertificato != null) && (IrregolaritaItem.ContributoAmmessoCertificato.Value == ContributoAmmessoCertificatoEqualThis.Value))) && 
((ContributoPubblicoCertificatoEqualThis == null) || ((IrregolaritaItem.ContributoPubblicoCertificato != null) && (IrregolaritaItem.ContributoPubblicoCertificato.Value == ContributoPubblicoCertificatoEqualThis.Value))) && ((ContributoPubblicoDaRecuperareEqualThis == null) || ((IrregolaritaItem.ContributoPubblicoDaRecuperare != null) && (IrregolaritaItem.ContributoPubblicoDaRecuperare.Value == ContributoPubblicoDaRecuperareEqualThis.Value))) && ((CommentiImpattiFinanziarioEqualThis == null) || ((IrregolaritaItem.CommentiImpattiFinanziario != null) && (IrregolaritaItem.CommentiImpattiFinanziario.Value == CommentiImpattiFinanziarioEqualThis.Value))) && 
((ProcedimentoAmministrativoEqualThis == null) || ((IrregolaritaItem.ProcedimentoAmministrativo != null) && (IrregolaritaItem.ProcedimentoAmministrativo.Value == ProcedimentoAmministrativoEqualThis.Value))) && ((AzioneGiudiziariaEqualThis == null) || ((IrregolaritaItem.AzioneGiudiziaria != null) && (IrregolaritaItem.AzioneGiudiziaria.Value == AzioneGiudiziariaEqualThis.Value))) && ((AzionePenaleEqualThis == null) || ((IrregolaritaItem.AzionePenale != null) && (IrregolaritaItem.AzionePenale.Value == AzionePenaleEqualThis.Value))) && 
((IdStatoFinanziarioEqualThis == null) || ((IrregolaritaItem.IdStatoFinanziario != null) && (IrregolaritaItem.IdStatoFinanziario.Value == IdStatoFinanziarioEqualThis.Value))) && ((StabilitaOperazioniEqualThis == null) || ((IrregolaritaItem.StabilitaOperazioni != null) && (IrregolaritaItem.StabilitaOperazioni.Value == StabilitaOperazioniEqualThis.Value))) && ((NumeroProtocolloEqualThis == null) || ((IrregolaritaItem.NumeroProtocollo != null) && (IrregolaritaItem.NumeroProtocollo.Value == NumeroProtocolloEqualThis.Value))) && 
((NumeroOlafEqualThis == null) || ((IrregolaritaItem.NumeroOlaf != null) && (IrregolaritaItem.NumeroOlaf.Value == NumeroOlafEqualThis.Value))) && ((DataSegnalazioneEqualThis == null) || ((IrregolaritaItem.DataSegnalazione != null) && (IrregolaritaItem.DataSegnalazione.Value == DataSegnalazioneEqualThis.Value))) && ((DataSegnalazioneDaEqualThis == null) || ((IrregolaritaItem.DataSegnalazioneDa != null) && (IrregolaritaItem.DataSegnalazioneDa.Value == DataSegnalazioneDaEqualThis.Value))) && 
((DataSegnalazioneAEqualThis == null) || ((IrregolaritaItem.DataSegnalazioneA != null) && (IrregolaritaItem.DataSegnalazioneA.Value == DataSegnalazioneAEqualThis.Value))) && ((DaRecuperareEqualThis == null) || ((IrregolaritaItem.DaRecuperare != null) && (IrregolaritaItem.DaRecuperare.Value == DaRecuperareEqualThis.Value))) && ((RecuperatoEqualThis == null) || ((IrregolaritaItem.Recuperato != null) && (IrregolaritaItem.Recuperato.Value == RecuperatoEqualThis.Value))) && 
((AzioneCertificazioneEqualThis == null) || ((IrregolaritaItem.AzioneCertificazione != null) && (IrregolaritaItem.AzioneCertificazione.Value == AzioneCertificazioneEqualThis.Value))) && ((ContributoRecuperareBeneficiarioEqualThis == null) || ((IrregolaritaItem.ContributoRecuperareBeneficiario != null) && (IrregolaritaItem.ContributoRecuperareBeneficiario.Value == ContributoRecuperareBeneficiarioEqualThis.Value))) && ((ContributoAmmessoProgettoEqualThis == null) || ((IrregolaritaItem.ContributoAmmessoProgetto != null) && (IrregolaritaItem.ContributoAmmessoProgetto.Value == ContributoAmmessoProgettoEqualThis.Value))) && 
((DataRegistrazioneAdcEqualThis == null) || ((IrregolaritaItem.DataRegistrazioneAdc != null) && (IrregolaritaItem.DataRegistrazioneAdc.Value == DataRegistrazioneAdcEqualThis.Value))))
				{
					IrregolaritaCollectionTemp.Add(IrregolaritaItem);
				}
			}
			return IrregolaritaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IrregolaritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IrregolaritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Irregolarita IrregolaritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdIrregolarita", IrregolaritaObj.IdIrregolarita);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", IrregolaritaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", IrregolaritaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", IrregolaritaObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", IrregolaritaObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", IrregolaritaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoIrregolarita", IrregolaritaObj.IdTipoIrregolarita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdControlloOrigine", IrregolaritaObj.IdControlloOrigine);
			DbProvider.SetCmdParam(cmd,firstChar + "SospettoFrode", IrregolaritaObj.SospettoFrode);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCostatazioneAmministrativa", IrregolaritaObj.DataCostatazioneAmministrativa);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoIrregolareDaRecuperare", IrregolaritaObj.ImportoIrregolareDaRecuperare);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnalazioneOlaf", IrregolaritaObj.SegnalazioneOlaf);
			DbProvider.SetCmdParam(cmd,firstChar + "DataSegnalazioneOlaf", IrregolaritaObj.DataSegnalazioneOlaf);
			DbProvider.SetCmdParam(cmd,firstChar + "TrimestreSegnalazioneOlaf", IrregolaritaObj.TrimestreSegnalazioneOlaf);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPrimaInformazione", IrregolaritaObj.DataPrimaInformazione);
			DbProvider.SetCmdParam(cmd,firstChar + "FontePrimaInformazione", IrregolaritaObj.FontePrimaInformazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresaCommessaDa", IrregolaritaObj.IdImpresaCommessaDa);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteCommessaDa", IrregolaritaObj.NoteCommessaDa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCategoria", IrregolaritaObj.IdCategoria);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipo", IrregolaritaObj.IdTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdClassificazione", IrregolaritaObj.IdClassificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "PraticheUtilizzate", IrregolaritaObj.PraticheUtilizzate);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteGiustificativi", IrregolaritaObj.NoteGiustificativi);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoSpesa", IrregolaritaObj.ImportoSpesa);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmesso", IrregolaritaObj.ContributoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoPubblico", IrregolaritaObj.ContributoPubblico);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmessoCertificato", IrregolaritaObj.ContributoAmmessoCertificato);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoPubblicoCertificato", IrregolaritaObj.ContributoPubblicoCertificato);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoPubblicoDaRecuperare", IrregolaritaObj.ContributoPubblicoDaRecuperare);
			DbProvider.SetCmdParam(cmd,firstChar + "CommentiImpattiFinanziario", IrregolaritaObj.CommentiImpattiFinanziario);
			DbProvider.SetCmdParam(cmd,firstChar + "ProcedimentoAmministrativo", IrregolaritaObj.ProcedimentoAmministrativo);
			DbProvider.SetCmdParam(cmd,firstChar + "AzioneGiudiziaria", IrregolaritaObj.AzioneGiudiziaria);
			DbProvider.SetCmdParam(cmd,firstChar + "AzionePenale", IrregolaritaObj.AzionePenale);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStatoFinanziario", IrregolaritaObj.IdStatoFinanziario);
			DbProvider.SetCmdParam(cmd,firstChar + "StabilitaOperazioni", IrregolaritaObj.StabilitaOperazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProtocollo", IrregolaritaObj.NumeroProtocollo);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroOlaf", IrregolaritaObj.NumeroOlaf);
			DbProvider.SetCmdParam(cmd,firstChar + "DataSegnalazione", IrregolaritaObj.DataSegnalazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataSegnalazioneDa", IrregolaritaObj.DataSegnalazioneDa);
			DbProvider.SetCmdParam(cmd,firstChar + "DataSegnalazioneA", IrregolaritaObj.DataSegnalazioneA);
			DbProvider.SetCmdParam(cmd,firstChar + "DaRecuperare", IrregolaritaObj.DaRecuperare);
			DbProvider.SetCmdParam(cmd,firstChar + "Recuperato", IrregolaritaObj.Recuperato);
			DbProvider.SetCmdParam(cmd,firstChar + "AzioneCertificazione", IrregolaritaObj.AzioneCertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRecuperareBeneficiario", IrregolaritaObj.ContributoRecuperareBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmessoProgetto", IrregolaritaObj.ContributoAmmessoProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRegistrazioneAdc", IrregolaritaObj.DataRegistrazioneAdc);
		}
		//Insert
		private static int Insert(DbProvider db, Irregolarita IrregolaritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIrregolaritaInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdProgetto", 
"IdTipoIrregolarita", "IdControlloOrigine", "SospettoFrode", 
"DataCostatazioneAmministrativa", "ImportoIrregolareDaRecuperare", "SegnalazioneOlaf", 
"DataSegnalazioneOlaf", "TrimestreSegnalazioneOlaf", "DataPrimaInformazione", 
"FontePrimaInformazione", "IdImpresaCommessaDa", "NoteCommessaDa", 
"IdCategoria", "IdTipo", "IdClassificazione", 
"PraticheUtilizzate", "NoteGiustificativi", "ImportoSpesa", 
"ContributoAmmesso", "ContributoPubblico", "ContributoAmmessoCertificato", 
"ContributoPubblicoCertificato", "ContributoPubblicoDaRecuperare", "CommentiImpattiFinanziario", 
"ProcedimentoAmministrativo", "AzioneGiudiziaria", "AzionePenale", 
"IdStatoFinanziario", "StabilitaOperazioni", "NumeroProtocollo", 
"NumeroOlaf", "DataSegnalazione", "DataSegnalazioneDa", 
"DataSegnalazioneA", "DaRecuperare", "Recuperato", 
"AzioneCertificazione", "ContributoRecuperareBeneficiario", "ContributoAmmessoProgetto", 
"DataRegistrazioneAdc", 



}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"DateTime", "bool", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"int", "int", "int", 
"string", "string", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "string", 
"bool", "bool", "bool", 
"int", "bool", "string", 
"string", "DateTime", "DateTime", 
"DateTime", "bool", "bool", 
"string", "decimal", "decimal", 
"DateTime", 



},"");
				CompileIUCmd(false, insertCmd,IrregolaritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IrregolaritaObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
				IrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				IrregolaritaObj.DataCostatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_COSTATAZIONE_AMMINISTRATIVA"]);
				}
				IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IrregolaritaObj.IsDirty = false;
				IrregolaritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Irregolarita IrregolaritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIrregolaritaUpdate", new string[] {"IdIrregolarita", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdProgetto", 
"IdTipoIrregolarita", "IdControlloOrigine", "SospettoFrode", 
"DataCostatazioneAmministrativa", "ImportoIrregolareDaRecuperare", "SegnalazioneOlaf", 
"DataSegnalazioneOlaf", "TrimestreSegnalazioneOlaf", "DataPrimaInformazione", 
"FontePrimaInformazione", "IdImpresaCommessaDa", "NoteCommessaDa", 
"IdCategoria", "IdTipo", "IdClassificazione", 
"PraticheUtilizzate", "NoteGiustificativi", "ImportoSpesa", 
"ContributoAmmesso", "ContributoPubblico", "ContributoAmmessoCertificato", 
"ContributoPubblicoCertificato", "ContributoPubblicoDaRecuperare", "CommentiImpattiFinanziario", 
"ProcedimentoAmministrativo", "AzioneGiudiziaria", "AzionePenale", 
"IdStatoFinanziario", "StabilitaOperazioni", "NumeroProtocollo", 
"NumeroOlaf", "DataSegnalazione", "DataSegnalazioneDa", 
"DataSegnalazioneA", "DaRecuperare", "Recuperato", 
"AzioneCertificazione", "ContributoRecuperareBeneficiario", "ContributoAmmessoProgetto", 
"DataRegistrazioneAdc", 



}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"DateTime", "bool", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"int", "int", "int", 
"string", "string", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "string", 
"bool", "bool", "bool", 
"int", "bool", "string", 
"string", "DateTime", "DateTime", 
"DateTime", "bool", "bool", 
"string", "decimal", "decimal", 
"DateTime", 



},"");
				CompileIUCmd(true, updateCmd,IrregolaritaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					IrregolaritaObj.DataModifica = d;
				}
				IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IrregolaritaObj.IsDirty = false;
				IrregolaritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Irregolarita IrregolaritaObj)
		{
			switch (IrregolaritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IrregolaritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IrregolaritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IrregolaritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IrregolaritaCollection IrregolaritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIrregolaritaUpdate", new string[] {"IdIrregolarita", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdProgetto", 
"IdTipoIrregolarita", "IdControlloOrigine", "SospettoFrode", 
"DataCostatazioneAmministrativa", "ImportoIrregolareDaRecuperare", "SegnalazioneOlaf", 
"DataSegnalazioneOlaf", "TrimestreSegnalazioneOlaf", "DataPrimaInformazione", 
"FontePrimaInformazione", "IdImpresaCommessaDa", "NoteCommessaDa", 
"IdCategoria", "IdTipo", "IdClassificazione", 
"PraticheUtilizzate", "NoteGiustificativi", "ImportoSpesa", 
"ContributoAmmesso", "ContributoPubblico", "ContributoAmmessoCertificato", 
"ContributoPubblicoCertificato", "ContributoPubblicoDaRecuperare", "CommentiImpattiFinanziario", 
"ProcedimentoAmministrativo", "AzioneGiudiziaria", "AzionePenale", 
"IdStatoFinanziario", "StabilitaOperazioni", "NumeroProtocollo", 
"NumeroOlaf", "DataSegnalazione", "DataSegnalazioneDa", 
"DataSegnalazioneA", "DaRecuperare", "Recuperato", 
"AzioneCertificazione", "ContributoRecuperareBeneficiario", "ContributoAmmessoProgetto", 
"DataRegistrazioneAdc", 



}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"DateTime", "bool", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"int", "int", "int", 
"string", "string", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "string", 
"bool", "bool", "bool", 
"int", "bool", "string", 
"string", "DateTime", "DateTime", 
"DateTime", "bool", "bool", 
"string", "decimal", "decimal", 
"DateTime", 



},"");
				IDbCommand insertCmd = db.InitCmd( "ZIrregolaritaInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdProgetto", 
"IdTipoIrregolarita", "IdControlloOrigine", "SospettoFrode", 
"DataCostatazioneAmministrativa", "ImportoIrregolareDaRecuperare", "SegnalazioneOlaf", 
"DataSegnalazioneOlaf", "TrimestreSegnalazioneOlaf", "DataPrimaInformazione", 
"FontePrimaInformazione", "IdImpresaCommessaDa", "NoteCommessaDa", 
"IdCategoria", "IdTipo", "IdClassificazione", 
"PraticheUtilizzate", "NoteGiustificativi", "ImportoSpesa", 
"ContributoAmmesso", "ContributoPubblico", "ContributoAmmessoCertificato", 
"ContributoPubblicoCertificato", "ContributoPubblicoDaRecuperare", "CommentiImpattiFinanziario", 
"ProcedimentoAmministrativo", "AzioneGiudiziaria", "AzionePenale", 
"IdStatoFinanziario", "StabilitaOperazioni", "NumeroProtocollo", 
"NumeroOlaf", "DataSegnalazione", "DataSegnalazioneDa", 
"DataSegnalazioneA", "DaRecuperare", "Recuperato", 
"AzioneCertificazione", "ContributoRecuperareBeneficiario", "ContributoAmmessoProgetto", 
"DataRegistrazioneAdc", 



}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"DateTime", "bool", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"int", "int", "int", 
"string", "string", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "string", 
"bool", "bool", "bool", 
"int", "bool", "string", 
"string", "DateTime", "DateTime", 
"DateTime", "bool", "bool", 
"string", "decimal", "decimal", 
"DateTime", 



},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIrregolaritaDelete", new string[] {"IdIrregolarita"}, new string[] {"int"},"");
				for (int i = 0; i < IrregolaritaCollectionObj.Count; i++)
				{
					switch (IrregolaritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IrregolaritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IrregolaritaCollectionObj[i].IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
									IrregolaritaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									IrregolaritaCollectionObj[i].DataCostatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_COSTATAZIONE_AMMINISTRATIVA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IrregolaritaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									IrregolaritaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IrregolaritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)IrregolaritaCollectionObj[i].IdIrregolarita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IrregolaritaCollectionObj.Count; i++)
				{
					if ((IrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IrregolaritaCollectionObj[i].IsDirty = false;
						IrregolaritaCollectionObj[i].IsPersistent = true;
					}
					if ((IrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IrregolaritaCollectionObj[i].IsDirty = false;
						IrregolaritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Irregolarita IrregolaritaObj)
		{
			int returnValue = 0;
			if (IrregolaritaObj.IsPersistent) 
			{
				returnValue = Delete(db, IrregolaritaObj.IdIrregolarita);
			}
			IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IrregolaritaObj.IsDirty = false;
			IrregolaritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdIrregolaritaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIrregolaritaDelete", new string[] {"IdIrregolarita"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)IdIrregolaritaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IrregolaritaCollection IrregolaritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIrregolaritaDelete", new string[] {"IdIrregolarita"}, new string[] {"int"},"");
				for (int i = 0; i < IrregolaritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdIrregolarita", IrregolaritaCollectionObj[i].IdIrregolarita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IrregolaritaCollectionObj.Count; i++)
				{
					if ((IrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IrregolaritaCollectionObj[i].IsDirty = false;
						IrregolaritaCollectionObj[i].IsPersistent = false;
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
		public static Irregolarita GetById(DbProvider db, int IdIrregolaritaValue)
		{
			Irregolarita IrregolaritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIrregolaritaGetById", new string[] {"IdIrregolarita"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdIrregolarita", (SiarLibrary.NullTypes.IntNT)IdIrregolaritaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IrregolaritaObj = GetFromDatareader(db);
				IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IrregolaritaObj.IsDirty = false;
				IrregolaritaObj.IsPersistent = true;
			}
			db.Close();
			return IrregolaritaObj;
		}

		//getFromDatareader
		public static Irregolarita GetFromDatareader(DbProvider db)
		{
			Irregolarita IrregolaritaObj = new Irregolarita();
			IrregolaritaObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
			IrregolaritaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			IrregolaritaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			IrregolaritaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			IrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			IrregolaritaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			IrregolaritaObj.IdTipoIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_IRREGOLARITA"]);
			IrregolaritaObj.IdControlloOrigine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTROLLO_ORIGINE"]);
			IrregolaritaObj.SospettoFrode = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SOSPETTO_FRODE"]);
			IrregolaritaObj.DataCostatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_COSTATAZIONE_AMMINISTRATIVA"]);
			IrregolaritaObj.ImportoIrregolareDaRecuperare = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IMPORTO_IRREGOLARE_DA_RECUPERARE"]);
			IrregolaritaObj.SegnalazioneOlaf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SEGNALAZIONE_OLAF"]);
			IrregolaritaObj.DataSegnalazioneOlaf = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE_OLAF"]);
			IrregolaritaObj.TrimestreSegnalazioneOlaf = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRIMESTRE_SEGNALAZIONE_OLAF"]);
			IrregolaritaObj.DataPrimaInformazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRIMA_INFORMAZIONE"]);
			IrregolaritaObj.FontePrimaInformazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["FONTE_PRIMA_INFORMAZIONE"]);
			IrregolaritaObj.IdImpresaCommessaDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_COMMESSA_DA"]);
			IrregolaritaObj.NoteCommessaDa = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_COMMESSA_DA"]);
			IrregolaritaObj.IdCategoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CATEGORIA"]);
			IrregolaritaObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
			IrregolaritaObj.IdClassificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CLASSIFICAZIONE"]);
			IrregolaritaObj.PraticheUtilizzate = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRATICHE_UTILIZZATE"]);
			IrregolaritaObj.NoteGiustificativi = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_GIUSTIFICATIVI"]);
			IrregolaritaObj.ImportoSpesa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA"]);
			IrregolaritaObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			IrregolaritaObj.ContributoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PUBBLICO"]);
			IrregolaritaObj.ContributoAmmessoCertificato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_CERTIFICATO"]);
			IrregolaritaObj.ContributoPubblicoCertificato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PUBBLICO_CERTIFICATO"]);
			IrregolaritaObj.ContributoPubblicoDaRecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PUBBLICO_DA_RECUPERARE"]);
			IrregolaritaObj.CommentiImpattiFinanziario = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMMENTI_IMPATTI_FINANZIARIO"]);
			IrregolaritaObj.ProcedimentoAmministrativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROCEDIMENTO_AMMINISTRATIVO"]);
			IrregolaritaObj.AzioneGiudiziaria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AZIONE_GIUDIZIARIA"]);
			IrregolaritaObj.AzionePenale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AZIONE_PENALE"]);
			IrregolaritaObj.IdStatoFinanziario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STATO_FINANZIARIO"]);
			IrregolaritaObj.StabilitaOperazioni = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STABILITA_OPERAZIONI"]);
			IrregolaritaObj.NumeroProtocollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO"]);
			IrregolaritaObj.NumeroOlaf = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_OLAF"]);
			IrregolaritaObj.DataSegnalazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE"]);
			IrregolaritaObj.DataSegnalazioneDa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE_DA"]);
			IrregolaritaObj.DataSegnalazioneA = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNALAZIONE_A"]);
			IrregolaritaObj.DaRecuperare = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DA_RECUPERARE"]);
			IrregolaritaObj.Recuperato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERATO"]);
			IrregolaritaObj.AzioneCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE_CERTIFICAZIONE"]);
			IrregolaritaObj.ContributoRecuperareBeneficiario = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RECUPERARE_BENEFICIARIO"]);
			IrregolaritaObj.ContributoAmmessoProgetto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_PROGETTO"]);
			IrregolaritaObj.DataRegistrazioneAdc = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REGISTRAZIONE_ADC"]);
			IrregolaritaObj.TipoIrregolarita = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_IRREGOLARITA"]);
			IrregolaritaObj.AttivoTipoIrregolarita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO_TIPO_IRREGOLARITA"]);
			IrregolaritaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			IrregolaritaObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
			IrregolaritaObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
			IrregolaritaObj.CodFaseProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE_PROGETTO"]);
			IrregolaritaObj.FaseProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_PROGETTO"]);
			IrregolaritaObj.IdImpresaProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_PROGETTO"]);
			IrregolaritaObj.CuaaImpresaIrregolarita = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA_IRREGOLARITA"]);
			IrregolaritaObj.CodiceFiscaleImpresaIrregolarita = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE_IMPRESA_IRREGOLARITA"]);
			IrregolaritaObj.RagioneSocialeImpresaIrregolarita = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_IMPRESA_IRREGOLARITA"]);
			IrregolaritaObj.DescrizioneCategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CATEGORIA"]);
			IrregolaritaObj.DescrizioneControlloOrigine = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CONTROLLO_ORIGINE"]);
			IrregolaritaObj.DescrizioneTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO"]);
			IrregolaritaObj.DescrizioneClassificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CLASSIFICAZIONE"]);
			IrregolaritaObj.DescrizioneStatoFinanziario = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_STATO_FINANZIARIO"]);
			IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IrregolaritaObj.IsDirty = false;
			IrregolaritaObj.IsPersistent = true;
			return IrregolaritaObj;
		}

		//Find Select

		public static IrregolaritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdTipoIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdControlloOrigineEqualThis, SiarLibrary.NullTypes.BoolNT SospettoFrodeEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCostatazioneAmministrativaEqualThis, SiarLibrary.NullTypes.BoolNT ImportoIrregolareDaRecuperareEqualThis, SiarLibrary.NullTypes.BoolNT SegnalazioneOlafEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataSegnalazioneOlafEqualThis, SiarLibrary.NullTypes.StringNT TrimestreSegnalazioneOlafEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPrimaInformazioneEqualThis, 
SiarLibrary.NullTypes.StringNT FontePrimaInformazioneEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaCommessaDaEqualThis, SiarLibrary.NullTypes.StringNT NoteCommessaDaEqualThis, 
SiarLibrary.NullTypes.IntNT IdCategoriaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.IntNT IdClassificazioneEqualThis, 
SiarLibrary.NullTypes.StringNT PraticheUtilizzateEqualThis, SiarLibrary.NullTypes.StringNT NoteGiustificativiEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoCertificatoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoPubblicoCertificatoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoPubblicoDaRecuperareEqualThis, SiarLibrary.NullTypes.StringNT CommentiImpattiFinanziarioEqualThis, 
SiarLibrary.NullTypes.BoolNT ProcedimentoAmministrativoEqualThis, SiarLibrary.NullTypes.BoolNT AzioneGiudiziariaEqualThis, SiarLibrary.NullTypes.BoolNT AzionePenaleEqualThis, 
SiarLibrary.NullTypes.IntNT IdStatoFinanziarioEqualThis, SiarLibrary.NullTypes.BoolNT StabilitaOperazioniEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroOlafEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnalazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnalazioneDaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataSegnalazioneAEqualThis, SiarLibrary.NullTypes.BoolNT DaRecuperareEqualThis, SiarLibrary.NullTypes.BoolNT RecuperatoEqualThis, 
SiarLibrary.NullTypes.StringNT AzioneCertificazioneEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRecuperareBeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoProgettoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRegistrazioneAdcEqualThis)

		{

			IrregolaritaCollection IrregolaritaCollectionObj = new IrregolaritaCollection();

			IDbCommand findCmd = db.InitCmd("Zirregolaritafindselect", new string[] {"IdIrregolaritaequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdProgettoequalthis", 
"IdTipoIrregolaritaequalthis", "IdControlloOrigineequalthis", "SospettoFrodeequalthis", 
"DataCostatazioneAmministrativaequalthis", "ImportoIrregolareDaRecuperareequalthis", "SegnalazioneOlafequalthis", 
"DataSegnalazioneOlafequalthis", "TrimestreSegnalazioneOlafequalthis", "DataPrimaInformazioneequalthis", 
"FontePrimaInformazioneequalthis", "IdImpresaCommessaDaequalthis", "NoteCommessaDaequalthis", 
"IdCategoriaequalthis", "IdTipoequalthis", "IdClassificazioneequalthis", 
"PraticheUtilizzateequalthis", "NoteGiustificativiequalthis", "ImportoSpesaequalthis", 
"ContributoAmmessoequalthis", "ContributoPubblicoequalthis", "ContributoAmmessoCertificatoequalthis", 
"ContributoPubblicoCertificatoequalthis", "ContributoPubblicoDaRecuperareequalthis", "CommentiImpattiFinanziarioequalthis", 
"ProcedimentoAmministrativoequalthis", "AzioneGiudiziariaequalthis", "AzionePenaleequalthis", 
"IdStatoFinanziarioequalthis", "StabilitaOperazioniequalthis", "NumeroProtocolloequalthis", 
"NumeroOlafequalthis", "DataSegnalazioneequalthis", "DataSegnalazioneDaequalthis", 
"DataSegnalazioneAequalthis", "DaRecuperareequalthis", "Recuperatoequalthis", 
"AzioneCertificazioneequalthis", "ContributoRecuperareBeneficiarioequalthis", "ContributoAmmessoProgettoequalthis", 
"DataRegistrazioneAdcequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"DateTime", "bool", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"int", "int", "int", 
"string", "string", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "string", 
"bool", "bool", "bool", 
"int", "bool", "string", 
"string", "DateTime", "DateTime", 
"DateTime", "bool", "bool", 
"string", "decimal", "decimal", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoIrregolaritaequalthis", IdTipoIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdControlloOrigineequalthis", IdControlloOrigineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SospettoFrodeequalthis", SospettoFrodeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCostatazioneAmministrativaequalthis", DataCostatazioneAmministrativaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoIrregolareDaRecuperareequalthis", ImportoIrregolareDaRecuperareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnalazioneOlafequalthis", SegnalazioneOlafEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataSegnalazioneOlafequalthis", DataSegnalazioneOlafEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TrimestreSegnalazioneOlafequalthis", TrimestreSegnalazioneOlafEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPrimaInformazioneequalthis", DataPrimaInformazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FontePrimaInformazioneequalthis", FontePrimaInformazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaCommessaDaequalthis", IdImpresaCommessaDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteCommessaDaequalthis", NoteCommessaDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCategoriaequalthis", IdCategoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdClassificazioneequalthis", IdClassificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PraticheUtilizzateequalthis", PraticheUtilizzateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteGiustificativiequalthis", NoteGiustificativiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoSpesaequalthis", ImportoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoPubblicoequalthis", ContributoPubblicoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoCertificatoequalthis", ContributoAmmessoCertificatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoPubblicoCertificatoequalthis", ContributoPubblicoCertificatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoPubblicoDaRecuperareequalthis", ContributoPubblicoDaRecuperareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CommentiImpattiFinanziarioequalthis", CommentiImpattiFinanziarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProcedimentoAmministrativoequalthis", ProcedimentoAmministrativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AzioneGiudiziariaequalthis", AzioneGiudiziariaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AzionePenaleequalthis", AzionePenaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStatoFinanziarioequalthis", IdStatoFinanziarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StabilitaOperazioniequalthis", StabilitaOperazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloequalthis", NumeroProtocolloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroOlafequalthis", NumeroOlafEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataSegnalazioneequalthis", DataSegnalazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataSegnalazioneDaequalthis", DataSegnalazioneDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataSegnalazioneAequalthis", DataSegnalazioneAEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DaRecuperareequalthis", DaRecuperareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Recuperatoequalthis", RecuperatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AzioneCertificazioneequalthis", AzioneCertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRecuperareBeneficiarioequalthis", ContributoRecuperareBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoProgettoequalthis", ContributoAmmessoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRegistrazioneAdcequalthis", DataRegistrazioneAdcEqualThis);
			Irregolarita IrregolaritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IrregolaritaObj = GetFromDatareader(db);
				IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IrregolaritaObj.IsDirty = false;
				IrregolaritaObj.IsPersistent = true;
				IrregolaritaCollectionObj.Add(IrregolaritaObj);
			}
			db.Close();
			return IrregolaritaCollectionObj;
		}

		//Find Find

		public static IrregolaritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdTipoIrregolaritaEqualThis, SiarLibrary.NullTypes.BoolNT SegnalazioneOlafEqualThis)

		{

			IrregolaritaCollection IrregolaritaCollectionObj = new IrregolaritaCollection();

			IDbCommand findCmd = db.InitCmd("Zirregolaritafindfind", new string[] {"IdIrregolaritaequalthis", "IdBandoequalthis", "IdProgettoequalthis", 
"IdTipoIrregolaritaequalthis", "SegnalazioneOlafequalthis"}, new string[] {"int", "int", "int", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoIrregolaritaequalthis", IdTipoIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnalazioneOlafequalthis", SegnalazioneOlafEqualThis);
			Irregolarita IrregolaritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IrregolaritaObj = GetFromDatareader(db);
				IrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IrregolaritaObj.IsDirty = false;
				IrregolaritaObj.IsPersistent = true;
				IrregolaritaCollectionObj.Add(IrregolaritaObj);
			}
			db.Close();
			return IrregolaritaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IrregolaritaCollectionProvider:IIrregolaritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IrregolaritaCollectionProvider : IIrregolaritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Irregolarita
		protected IrregolaritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IrregolaritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IrregolaritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public IrregolaritaCollectionProvider(IntNT IdirregolaritaEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdtipoirregolaritaEqualThis, BoolNT SegnalazioneolafEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdirregolaritaEqualThis, IdbandoEqualThis, IdprogettoEqualThis, 
IdtipoirregolaritaEqualThis, SegnalazioneolafEqualThis);
		}

		//Costruttore3: ha in input irregolaritaCollectionObj - non popola la collection
		public IrregolaritaCollectionProvider(IrregolaritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IrregolaritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IrregolaritaCollection(this);
		}

		//Get e Set
		public IrregolaritaCollection CollectionObj
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
		public int SaveCollection(IrregolaritaCollection collectionObj)
		{
			return IrregolaritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Irregolarita irregolaritaObj)
		{
			return IrregolaritaDAL.Save(_dbProviderObj, irregolaritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IrregolaritaCollection collectionObj)
		{
			return IrregolaritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Irregolarita irregolaritaObj)
		{
			return IrregolaritaDAL.Delete(_dbProviderObj, irregolaritaObj);
		}

		//getById
		public Irregolarita GetById(IntNT IdIrregolaritaValue)
		{
			Irregolarita IrregolaritaTemp = IrregolaritaDAL.GetById(_dbProviderObj, IdIrregolaritaValue);
			if (IrregolaritaTemp!=null) IrregolaritaTemp.Provider = this;
			return IrregolaritaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public IrregolaritaCollection Select(IntNT IdirregolaritaEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdtipoirregolaritaEqualThis, IntNT IdcontrolloorigineEqualThis, BoolNT SospettofrodeEqualThis, 
DatetimeNT DatacostatazioneamministrativaEqualThis, BoolNT ImportoirregolaredarecuperareEqualThis, BoolNT SegnalazioneolafEqualThis, 
DatetimeNT DatasegnalazioneolafEqualThis, StringNT TrimestresegnalazioneolafEqualThis, DatetimeNT DataprimainformazioneEqualThis, 
StringNT FonteprimainformazioneEqualThis, IntNT IdimpresacommessadaEqualThis, StringNT NotecommessadaEqualThis, 
IntNT IdcategoriaEqualThis, IntNT IdtipoEqualThis, IntNT IdclassificazioneEqualThis, 
StringNT PraticheutilizzateEqualThis, StringNT NotegiustificativiEqualThis, DecimalNT ImportospesaEqualThis, 
DecimalNT ContributoammessoEqualThis, DecimalNT ContributopubblicoEqualThis, DecimalNT ContributoammessocertificatoEqualThis, 
DecimalNT ContributopubblicocertificatoEqualThis, DecimalNT ContributopubblicodarecuperareEqualThis, StringNT CommentiimpattifinanziarioEqualThis, 
BoolNT ProcedimentoamministrativoEqualThis, BoolNT AzionegiudiziariaEqualThis, BoolNT AzionepenaleEqualThis, 
IntNT IdstatofinanziarioEqualThis, BoolNT StabilitaoperazioniEqualThis, StringNT NumeroprotocolloEqualThis, 
StringNT NumeroolafEqualThis, DatetimeNT DatasegnalazioneEqualThis, DatetimeNT DatasegnalazionedaEqualThis, 
DatetimeNT DatasegnalazioneaEqualThis, BoolNT DarecuperareEqualThis, BoolNT RecuperatoEqualThis, 
StringNT AzionecertificazioneEqualThis, DecimalNT ContributorecuperarebeneficiarioEqualThis, DecimalNT ContributoammessoprogettoEqualThis, 
DatetimeNT DataregistrazioneadcEqualThis)
		{
			IrregolaritaCollection IrregolaritaCollectionTemp = IrregolaritaDAL.Select(_dbProviderObj, IdirregolaritaEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdprogettoEqualThis, 
IdtipoirregolaritaEqualThis, IdcontrolloorigineEqualThis, SospettofrodeEqualThis, 
DatacostatazioneamministrativaEqualThis, ImportoirregolaredarecuperareEqualThis, SegnalazioneolafEqualThis, 
DatasegnalazioneolafEqualThis, TrimestresegnalazioneolafEqualThis, DataprimainformazioneEqualThis, 
FonteprimainformazioneEqualThis, IdimpresacommessadaEqualThis, NotecommessadaEqualThis, 
IdcategoriaEqualThis, IdtipoEqualThis, IdclassificazioneEqualThis, 
PraticheutilizzateEqualThis, NotegiustificativiEqualThis, ImportospesaEqualThis, 
ContributoammessoEqualThis, ContributopubblicoEqualThis, ContributoammessocertificatoEqualThis, 
ContributopubblicocertificatoEqualThis, ContributopubblicodarecuperareEqualThis, CommentiimpattifinanziarioEqualThis, 
ProcedimentoamministrativoEqualThis, AzionegiudiziariaEqualThis, AzionepenaleEqualThis, 
IdstatofinanziarioEqualThis, StabilitaoperazioniEqualThis, NumeroprotocolloEqualThis, 
NumeroolafEqualThis, DatasegnalazioneEqualThis, DatasegnalazionedaEqualThis, 
DatasegnalazioneaEqualThis, DarecuperareEqualThis, RecuperatoEqualThis, 
AzionecertificazioneEqualThis, ContributorecuperarebeneficiarioEqualThis, ContributoammessoprogettoEqualThis, 
DataregistrazioneadcEqualThis);
			IrregolaritaCollectionTemp.Provider = this;
			return IrregolaritaCollectionTemp;
		}

		//Find: popola la collection
		public IrregolaritaCollection Find(IntNT IdirregolaritaEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdtipoirregolaritaEqualThis, BoolNT SegnalazioneolafEqualThis)
		{
			IrregolaritaCollection IrregolaritaCollectionTemp = IrregolaritaDAL.Find(_dbProviderObj, IdirregolaritaEqualThis, IdbandoEqualThis, IdprogettoEqualThis, 
IdtipoirregolaritaEqualThis, SegnalazioneolafEqualThis);
			IrregolaritaCollectionTemp.Provider = this;
			return IrregolaritaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IRREGOLARITA>
  <ViewName>VIRREGOLARITA</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_TIPO_IRREGOLARITA>Equal</ID_TIPO_IRREGOLARITA>
      <SEGNALAZIONE_OLAF>Equal</SEGNALAZIONE_OLAF>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IRREGOLARITA>
*/
