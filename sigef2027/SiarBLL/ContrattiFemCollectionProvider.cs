using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ContrattiFem
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IContrattiFemProvider
	{
		int Save(ContrattiFem ContrattiFemObj);
		int SaveCollection(ContrattiFemCollection collectionObj);
		int Delete(ContrattiFem ContrattiFemObj);
		int DeleteCollection(ContrattiFemCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ContrattiFem
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ContrattiFem : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdContrattoFem;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataStipulaContratto;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _DataSegnatura;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.IntNT _OperatoreAggiornamento;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _Numero;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdProgettoRif;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.StringNT _TipologiaCredito;
		private NullTypes.StringNT _FinalitaOperazione;
		private NullTypes.DecimalNT _ImportoFinanziamento;
		private NullTypes.DecimalNT _ImportoGaranziaConfidi;
		private NullTypes.DecimalNT _ImportoGaranziaFondo;
		private NullTypes.StringNT _Regime;
		private NullTypes.DecimalNT _PerditaFondoEscussioneConfidi;
		private NullTypes.BoolNT _Confidi;
		private NullTypes.IntNT _IdSoggettoGestore;
		private NullTypes.IntNT _IdProgettoSoggettoGestore;
		private NullTypes.StringNT _CodicePratica;
		private NullTypes.DecimalNT _ImportoErogatoAlNettoDelleSpese;
		private NullTypes.StringNT _Gestore;
		private NullTypes.StringNT _LineaIntervento;
		private NullTypes.IntNT _DurataFinanziamentoErogato;
		private NullTypes.StringNT _Impresa;
		private NullTypes.StringNT _CodiceFiscaleImpresa;
		private NullTypes.StringNT _CuaaImpresa;
		private NullTypes.StringNT _NumeroGiustificativo;
		private NullTypes.StringNT _CodTipoGiustificativo;
		private NullTypes.StringNT _TipoGiustificativo;
		private NullTypes.DatetimeNT _DataGiustificativo;
		private NullTypes.StringNT _NumeroDoctrasportoGiustificativo;
		private NullTypes.DatetimeNT _DataDoctrasportoGiustificativo;
		private NullTypes.DecimalNT _ImponibileGiustificativo;
		private NullTypes.DecimalNT _IvaGiustificativo;
		private NullTypes.DecimalNT _AltriOneriGiustificativo;
		private NullTypes.StringNT _DescrizioneGiustificativo;
		private NullTypes.StringNT _CfFornitoreGiustificativo;
		private NullTypes.StringNT _DescrizioneFornitoreGiustificativo;
		private NullTypes.BoolNT _IvaNonRecuperabileGiustificativo;
		private NullTypes.IntNT _IdFileGiustificativo;
		private NullTypes.BoolNT _InIntegrazioneGiustificativo;
		private NullTypes.BoolNT _IdFileModificatoIntegrazioneGiustificativo;
		[NonSerialized] private IContrattiFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IContrattiFemProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public ContrattiFem()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(15,2)
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
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(-1)
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
		/// Corrisponde al campo:ID_PROGETTO_RIF
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoRif
		{
			get { return _IdProgettoRif; }
			set
			{
				if (IdProgettoRif != value)
				{
					_IdProgettoRif = value;
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
		/// Corrisponde al campo:TIPOLOGIA_CREDITO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TipologiaCredito
		{
			get { return _TipologiaCredito; }
			set
			{
				if (TipologiaCredito != value)
				{
					_TipologiaCredito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FINALITA_OPERAZIONE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT FinalitaOperazione
		{
			get { return _FinalitaOperazione; }
			set
			{
				if (FinalitaOperazione != value)
				{
					_FinalitaOperazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_FINANZIAMENTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoFinanziamento
		{
			get { return _ImportoFinanziamento; }
			set
			{
				if (ImportoFinanziamento != value)
				{
					_ImportoFinanziamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_GARANZIA_CONFIDI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoGaranziaConfidi
		{
			get { return _ImportoGaranziaConfidi; }
			set
			{
				if (ImportoGaranziaConfidi != value)
				{
					_ImportoGaranziaConfidi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_GARANZIA_FONDO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoGaranziaFondo
		{
			get { return _ImportoGaranziaFondo; }
			set
			{
				if (ImportoGaranziaFondo != value)
				{
					_ImportoGaranziaFondo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGIME
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Regime
		{
			get { return _Regime; }
			set
			{
				if (Regime != value)
				{
					_Regime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERDITA_FONDO_ESCUSSIONE_CONFIDI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PerditaFondoEscussioneConfidi
		{
			get { return _PerditaFondoEscussioneConfidi; }
			set
			{
				if (PerditaFondoEscussioneConfidi != value)
				{
					_PerditaFondoEscussioneConfidi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONFIDI
		/// Tipo sul db:BIT
		/// Default:((0))
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
		/// Corrisponde al campo:ID_SOGGETTO_GESTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSoggettoGestore
		{
			get { return _IdSoggettoGestore; }
			set
			{
				if (IdSoggettoGestore != value)
				{
					_IdSoggettoGestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_SOGGETTO_GESTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoSoggettoGestore
		{
			get { return _IdProgettoSoggettoGestore; }
			set
			{
				if (IdProgettoSoggettoGestore != value)
				{
					_IdProgettoSoggettoGestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_PRATICA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT CodicePratica
		{
			get { return _CodicePratica; }
			set
			{
				if (CodicePratica != value)
				{
					_CodicePratica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_EROGATO_AL_NETTO_DELLE_SPESE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoErogatoAlNettoDelleSpese
		{
			get { return _ImportoErogatoAlNettoDelleSpese; }
			set
			{
				if (ImportoErogatoAlNettoDelleSpese != value)
				{
					_ImportoErogatoAlNettoDelleSpese = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GESTORE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Gestore
		{
			get { return _Gestore; }
			set
			{
				if (Gestore != value)
				{
					_Gestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LINEA_INTERVENTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT LineaIntervento
		{
			get { return _LineaIntervento; }
			set
			{
				if (LineaIntervento != value)
				{
					_LineaIntervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURATA_FINANZIAMENTO_EROGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DurataFinanziamentoErogato
		{
			get { return _DurataFinanziamentoErogato; }
			set
			{
				if (DurataFinanziamentoErogato != value)
				{
					_DurataFinanziamentoErogato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPRESA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Impresa
		{
			get { return _Impresa; }
			set
			{
				if (Impresa != value)
				{
					_Impresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscaleImpresa
		{
			get { return _CodiceFiscaleImpresa; }
			set
			{
				if (CodiceFiscaleImpresa != value)
				{
					_CodiceFiscaleImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaImpresa
		{
			get { return _CuaaImpresa; }
			set
			{
				if (CuaaImpresa != value)
				{
					_CuaaImpresa = value;
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
		/// Tipo sul db:CHAR(3)
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
		/// Corrisponde al campo:NUMERO_DOCTRASPORTO_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroDoctrasportoGiustificativo
		{
			get { return _NumeroDoctrasportoGiustificativo; }
			set
			{
				if (NumeroDoctrasportoGiustificativo != value)
				{
					_NumeroDoctrasportoGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DOCTRASPORTO_GIUSTIFICATIVO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDoctrasportoGiustificativo
		{
			get { return _DataDoctrasportoGiustificativo; }
			set
			{
				if (DataDoctrasportoGiustificativo != value)
				{
					_DataDoctrasportoGiustificativo = value;
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
		/// Corrisponde al campo:ALTRI_ONERI_GIUSTIFICATIVO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT AltriOneriGiustificativo
		{
			get { return _AltriOneriGiustificativo; }
			set
			{
				if (AltriOneriGiustificativo != value)
				{
					_AltriOneriGiustificativo = value;
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
	/// Summary description for ContrattiFemCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ContrattiFemCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ContrattiFemCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((ContrattiFem)info.GetValue(i.ToString(), typeof(ContrattiFem)));
			}
		}

		//Costruttore
		public ContrattiFemCollection()
		{
			this.ItemType = typeof(ContrattiFem);
		}

		//Costruttore con provider
		public ContrattiFemCollection(IContrattiFemProvider providerObj)
		{
			this.ItemType = typeof(ContrattiFem);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ContrattiFem this[int index]
		{
			get { return (ContrattiFem)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ContrattiFemCollection GetChanges()
		{
			return (ContrattiFemCollection)base.GetChanges();
		}

		[NonSerialized] private IContrattiFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IContrattiFemProvider Provider
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
		public int Add(ContrattiFem ContrattiFemObj)
		{
			if (ContrattiFemObj.Provider == null) ContrattiFemObj.Provider = this.Provider;
			return base.Add(ContrattiFemObj);
		}

		//AddCollection
		public void AddCollection(ContrattiFemCollection ContrattiFemCollectionObj)
		{
			foreach (ContrattiFem ContrattiFemObj in ContrattiFemCollectionObj)
				this.Add(ContrattiFemObj);
		}

		//Insert
		public void Insert(int index, ContrattiFem ContrattiFemObj)
		{
			if (ContrattiFemObj.Provider == null) ContrattiFemObj.Provider = this.Provider;
			base.Insert(index, ContrattiFemObj);
		}

		//CollectionGetById
		public ContrattiFem CollectionGetById(NullTypes.IntNT IdContrattoFemValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdContrattoFem == IdContrattoFemValue))
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
		public ContrattiFemCollection SubSelect(NullTypes.IntNT IdContrattoFemEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.DatetimeNT DataStipulaContrattoEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.DatetimeNT DataSegnaturaEqualThis,
NullTypes.DecimalNT ImportoEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis,
NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.IntNT OperatoreAggiornamentoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.IntNT IdFileEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdProgettoRifEqualThis, NullTypes.IntNT IdGiustificativoEqualThis,
NullTypes.StringNT TipologiaCreditoEqualThis, NullTypes.StringNT FinalitaOperazioneEqualThis, NullTypes.DecimalNT ImportoFinanziamentoEqualThis,
NullTypes.DecimalNT ImportoGaranziaConfidiEqualThis, NullTypes.DecimalNT ImportoGaranziaFondoEqualThis, NullTypes.StringNT RegimeEqualThis,
NullTypes.DecimalNT PerditaFondoEscussioneConfidiEqualThis, NullTypes.BoolNT ConfidiEqualThis, NullTypes.IntNT IdSoggettoGestoreEqualThis,
NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis, NullTypes.StringNT CodicePraticaEqualThis, NullTypes.DecimalNT ImportoErogatoAlNettoDelleSpeseEqualThis,
NullTypes.StringNT GestoreEqualThis, NullTypes.StringNT LineaInterventoEqualThis, NullTypes.IntNT DurataFinanziamentoErogatoEqualThis)
		{
			ContrattiFemCollection ContrattiFemCollectionTemp = new ContrattiFemCollection();
			foreach (ContrattiFem ContrattiFemItem in this)
			{
				if (((IdContrattoFemEqualThis == null) || ((ContrattiFemItem.IdContrattoFem != null) && (ContrattiFemItem.IdContrattoFem.Value == IdContrattoFemEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ContrattiFemItem.IdBando != null) && (ContrattiFemItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ContrattiFemItem.IdProgetto != null) && (ContrattiFemItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((DataStipulaContrattoEqualThis == null) || ((ContrattiFemItem.DataStipulaContratto != null) && (ContrattiFemItem.DataStipulaContratto.Value == DataStipulaContrattoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ContrattiFemItem.Segnatura != null) && (ContrattiFemItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((DataSegnaturaEqualThis == null) || ((ContrattiFemItem.DataSegnatura != null) && (ContrattiFemItem.DataSegnatura.Value == DataSegnaturaEqualThis.Value))) &&
((ImportoEqualThis == null) || ((ContrattiFemItem.Importo != null) && (ContrattiFemItem.Importo.Value == ImportoEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ContrattiFemItem.DataCreazione != null) && (ContrattiFemItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((ContrattiFemItem.DataAggiornamento != null) && (ContrattiFemItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) &&
((OperatoreCreazioneEqualThis == null) || ((ContrattiFemItem.OperatoreCreazione != null) && (ContrattiFemItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((OperatoreAggiornamentoEqualThis == null) || ((ContrattiFemItem.OperatoreAggiornamento != null) && (ContrattiFemItem.OperatoreAggiornamento.Value == OperatoreAggiornamentoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ContrattiFemItem.IdImpresa != null) && (ContrattiFemItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((IdDomandaPagamentoEqualThis == null) || ((ContrattiFemItem.IdDomandaPagamento != null) && (ContrattiFemItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((NumeroEqualThis == null) || ((ContrattiFemItem.Numero != null) && (ContrattiFemItem.Numero.Value == NumeroEqualThis.Value))) && ((IdFileEqualThis == null) || ((ContrattiFemItem.IdFile != null) && (ContrattiFemItem.IdFile.Value == IdFileEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((ContrattiFemItem.Descrizione != null) && (ContrattiFemItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdProgettoRifEqualThis == null) || ((ContrattiFemItem.IdProgettoRif != null) && (ContrattiFemItem.IdProgettoRif.Value == IdProgettoRifEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((ContrattiFemItem.IdGiustificativo != null) && (ContrattiFemItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) &&
((TipologiaCreditoEqualThis == null) || ((ContrattiFemItem.TipologiaCredito != null) && (ContrattiFemItem.TipologiaCredito.Value == TipologiaCreditoEqualThis.Value))) && ((FinalitaOperazioneEqualThis == null) || ((ContrattiFemItem.FinalitaOperazione != null) && (ContrattiFemItem.FinalitaOperazione.Value == FinalitaOperazioneEqualThis.Value))) && ((ImportoFinanziamentoEqualThis == null) || ((ContrattiFemItem.ImportoFinanziamento != null) && (ContrattiFemItem.ImportoFinanziamento.Value == ImportoFinanziamentoEqualThis.Value))) &&
((ImportoGaranziaConfidiEqualThis == null) || ((ContrattiFemItem.ImportoGaranziaConfidi != null) && (ContrattiFemItem.ImportoGaranziaConfidi.Value == ImportoGaranziaConfidiEqualThis.Value))) && ((ImportoGaranziaFondoEqualThis == null) || ((ContrattiFemItem.ImportoGaranziaFondo != null) && (ContrattiFemItem.ImportoGaranziaFondo.Value == ImportoGaranziaFondoEqualThis.Value))) && ((RegimeEqualThis == null) || ((ContrattiFemItem.Regime != null) && (ContrattiFemItem.Regime.Value == RegimeEqualThis.Value))) &&
((PerditaFondoEscussioneConfidiEqualThis == null) || ((ContrattiFemItem.PerditaFondoEscussioneConfidi != null) && (ContrattiFemItem.PerditaFondoEscussioneConfidi.Value == PerditaFondoEscussioneConfidiEqualThis.Value))) && ((ConfidiEqualThis == null) || ((ContrattiFemItem.Confidi != null) && (ContrattiFemItem.Confidi.Value == ConfidiEqualThis.Value))) && ((IdSoggettoGestoreEqualThis == null) || ((ContrattiFemItem.IdSoggettoGestore != null) && (ContrattiFemItem.IdSoggettoGestore.Value == IdSoggettoGestoreEqualThis.Value))) &&
((IdProgettoSoggettoGestoreEqualThis == null) || ((ContrattiFemItem.IdProgettoSoggettoGestore != null) && (ContrattiFemItem.IdProgettoSoggettoGestore.Value == IdProgettoSoggettoGestoreEqualThis.Value))) && ((CodicePraticaEqualThis == null) || ((ContrattiFemItem.CodicePratica != null) && (ContrattiFemItem.CodicePratica.Value == CodicePraticaEqualThis.Value))) && ((ImportoErogatoAlNettoDelleSpeseEqualThis == null) || ((ContrattiFemItem.ImportoErogatoAlNettoDelleSpese != null) && (ContrattiFemItem.ImportoErogatoAlNettoDelleSpese.Value == ImportoErogatoAlNettoDelleSpeseEqualThis.Value))) &&
((GestoreEqualThis == null) || ((ContrattiFemItem.Gestore != null) && (ContrattiFemItem.Gestore.Value == GestoreEqualThis.Value))) && ((LineaInterventoEqualThis == null) || ((ContrattiFemItem.LineaIntervento != null) && (ContrattiFemItem.LineaIntervento.Value == LineaInterventoEqualThis.Value))) && ((DurataFinanziamentoErogatoEqualThis == null) || ((ContrattiFemItem.DurataFinanziamentoErogato != null) && (ContrattiFemItem.DurataFinanziamentoErogato.Value == DurataFinanziamentoErogatoEqualThis.Value))))
				{
					ContrattiFemCollectionTemp.Add(ContrattiFemItem);
				}
			}
			return ContrattiFemCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ContrattiFemDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ContrattiFemDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ContrattiFem ContrattiFemObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdContrattoFem", ContrattiFemObj.IdContrattoFem);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", ContrattiFemObj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ContrattiFemObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "DataStipulaContratto", ContrattiFemObj.DataStipulaContratto);
			DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", ContrattiFemObj.Segnatura);
			DbProvider.SetCmdParam(cmd, firstChar + "DataSegnatura", ContrattiFemObj.DataSegnatura);
			DbProvider.SetCmdParam(cmd, firstChar + "Importo", ContrattiFemObj.Importo);
			DbProvider.SetCmdParam(cmd, firstChar + "DataCreazione", ContrattiFemObj.DataCreazione);
			DbProvider.SetCmdParam(cmd, firstChar + "DataAggiornamento", ContrattiFemObj.DataAggiornamento);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreCreazione", ContrattiFemObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreAggiornamento", ContrattiFemObj.OperatoreAggiornamento);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", ContrattiFemObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", ContrattiFemObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd, firstChar + "Numero", ContrattiFemObj.Numero);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFile", ContrattiFemObj.IdFile);
			DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ContrattiFemObj.Descrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoRif", ContrattiFemObj.IdProgettoRif);
			DbProvider.SetCmdParam(cmd, firstChar + "IdGiustificativo", ContrattiFemObj.IdGiustificativo);
			DbProvider.SetCmdParam(cmd, firstChar + "TipologiaCredito", ContrattiFemObj.TipologiaCredito);
			DbProvider.SetCmdParam(cmd, firstChar + "FinalitaOperazione", ContrattiFemObj.FinalitaOperazione);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoFinanziamento", ContrattiFemObj.ImportoFinanziamento);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoGaranziaConfidi", ContrattiFemObj.ImportoGaranziaConfidi);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoGaranziaFondo", ContrattiFemObj.ImportoGaranziaFondo);
			DbProvider.SetCmdParam(cmd, firstChar + "Regime", ContrattiFemObj.Regime);
			DbProvider.SetCmdParam(cmd, firstChar + "PerditaFondoEscussioneConfidi", ContrattiFemObj.PerditaFondoEscussioneConfidi);
			DbProvider.SetCmdParam(cmd, firstChar + "Confidi", ContrattiFemObj.Confidi);
			DbProvider.SetCmdParam(cmd, firstChar + "IdSoggettoGestore", ContrattiFemObj.IdSoggettoGestore);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoSoggettoGestore", ContrattiFemObj.IdProgettoSoggettoGestore);
			DbProvider.SetCmdParam(cmd, firstChar + "CodicePratica", ContrattiFemObj.CodicePratica);
			DbProvider.SetCmdParam(cmd, firstChar + "ImportoErogatoAlNettoDelleSpese", ContrattiFemObj.ImportoErogatoAlNettoDelleSpese);
			DbProvider.SetCmdParam(cmd, firstChar + "Gestore", ContrattiFemObj.Gestore);
			DbProvider.SetCmdParam(cmd, firstChar + "LineaIntervento", ContrattiFemObj.LineaIntervento);
			DbProvider.SetCmdParam(cmd, firstChar + "DurataFinanziamentoErogato", ContrattiFemObj.DurataFinanziamentoErogato);
		}
		//Insert
		private static int Insert(DbProvider db, ContrattiFem ContrattiFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZContrattiFemInsert", new string[] {"IdBando", "IdProgetto",
"DataStipulaContratto", "Segnatura", "DataSegnatura",
"Importo", "DataCreazione", "DataAggiornamento",
"OperatoreCreazione", "OperatoreAggiornamento", "IdImpresa",
"IdDomandaPagamento", "Numero", "IdFile",
"Descrizione", "IdProgettoRif", "IdGiustificativo",
"TipologiaCredito", "FinalitaOperazione", "ImportoFinanziamento",
"ImportoGaranziaConfidi", "ImportoGaranziaFondo", "Regime",
"PerditaFondoEscussioneConfidi", "Confidi", "IdSoggettoGestore",
"IdProgettoSoggettoGestore", "CodicePratica", "ImportoErogatoAlNettoDelleSpese",
"Gestore", "LineaIntervento", "DurataFinanziamentoErogato",





}, new string[] {"int", "int",
"DateTime", "string", "DateTime",
"decimal", "DateTime", "DateTime",
"int", "int", "int",
"int", "string", "int",
"string", "int", "int",
"string", "string", "decimal",
"decimal", "decimal", "string",
"decimal", "bool", "int",
"int", "string", "decimal",
"string", "string", "int",





}, "");
				CompileIUCmd(false, insertCmd, ContrattiFemObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					ContrattiFemObj.IdContrattoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM"]);
					ContrattiFemObj.Confidi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFIDI"]);
				}
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ContrattiFem ContrattiFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZContrattiFemUpdate", new string[] {"IdContrattoFem", "IdBando", "IdProgetto",
"DataStipulaContratto", "Segnatura", "DataSegnatura",
"Importo", "DataCreazione", "DataAggiornamento",
"OperatoreCreazione", "OperatoreAggiornamento", "IdImpresa",
"IdDomandaPagamento", "Numero", "IdFile",
"Descrizione", "IdProgettoRif", "IdGiustificativo",
"TipologiaCredito", "FinalitaOperazione", "ImportoFinanziamento",
"ImportoGaranziaConfidi", "ImportoGaranziaFondo", "Regime",
"PerditaFondoEscussioneConfidi", "Confidi", "IdSoggettoGestore",
"IdProgettoSoggettoGestore", "CodicePratica", "ImportoErogatoAlNettoDelleSpese",
"Gestore", "LineaIntervento", "DurataFinanziamentoErogato",





}, new string[] {"int", "int", "int",
"DateTime", "string", "DateTime",
"decimal", "DateTime", "DateTime",
"int", "int", "int",
"int", "string", "int",
"string", "int", "int",
"string", "string", "decimal",
"decimal", "decimal", "string",
"decimal", "bool", "int",
"int", "string", "decimal",
"string", "string", "int",





}, "");
				CompileIUCmd(true, updateCmd, ContrattiFemObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ContrattiFem ContrattiFemObj)
		{
			switch (ContrattiFemObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ContrattiFemObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ContrattiFemObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ContrattiFemObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ContrattiFemCollection ContrattiFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZContrattiFemUpdate", new string[] {"IdContrattoFem", "IdBando", "IdProgetto",
"DataStipulaContratto", "Segnatura", "DataSegnatura",
"Importo", "DataCreazione", "DataAggiornamento",
"OperatoreCreazione", "OperatoreAggiornamento", "IdImpresa",
"IdDomandaPagamento", "Numero", "IdFile",
"Descrizione", "IdProgettoRif", "IdGiustificativo",
"TipologiaCredito", "FinalitaOperazione", "ImportoFinanziamento",
"ImportoGaranziaConfidi", "ImportoGaranziaFondo", "Regime",
"PerditaFondoEscussioneConfidi", "Confidi", "IdSoggettoGestore",
"IdProgettoSoggettoGestore", "CodicePratica", "ImportoErogatoAlNettoDelleSpese",
"Gestore", "LineaIntervento", "DurataFinanziamentoErogato",





}, new string[] {"int", "int", "int",
"DateTime", "string", "DateTime",
"decimal", "DateTime", "DateTime",
"int", "int", "int",
"int", "string", "int",
"string", "int", "int",
"string", "string", "decimal",
"decimal", "decimal", "string",
"decimal", "bool", "int",
"int", "string", "decimal",
"string", "string", "int",





}, "");
				IDbCommand insertCmd = db.InitCmd("ZContrattiFemInsert", new string[] {"IdBando", "IdProgetto",
"DataStipulaContratto", "Segnatura", "DataSegnatura",
"Importo", "DataCreazione", "DataAggiornamento",
"OperatoreCreazione", "OperatoreAggiornamento", "IdImpresa",
"IdDomandaPagamento", "Numero", "IdFile",
"Descrizione", "IdProgettoRif", "IdGiustificativo",
"TipologiaCredito", "FinalitaOperazione", "ImportoFinanziamento",
"ImportoGaranziaConfidi", "ImportoGaranziaFondo", "Regime",
"PerditaFondoEscussioneConfidi", "Confidi", "IdSoggettoGestore",
"IdProgettoSoggettoGestore", "CodicePratica", "ImportoErogatoAlNettoDelleSpese",
"Gestore", "LineaIntervento", "DurataFinanziamentoErogato",





}, new string[] {"int", "int",
"DateTime", "string", "DateTime",
"decimal", "DateTime", "DateTime",
"int", "int", "int",
"int", "string", "int",
"string", "int", "int",
"string", "string", "decimal",
"decimal", "decimal", "string",
"decimal", "bool", "int",
"int", "string", "decimal",
"string", "string", "int",





}, "");
				IDbCommand deleteCmd = db.InitCmd("ZContrattiFemDelete", new string[] { "IdContrattoFem" }, new string[] { "int" }, "");
				for (int i = 0; i < ContrattiFemCollectionObj.Count; i++)
				{
					switch (ContrattiFemCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ContrattiFemCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ContrattiFemCollectionObj[i].IdContrattoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM"]);
									ContrattiFemCollectionObj[i].Confidi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFIDI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ContrattiFemCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ContrattiFemCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFem", (SiarLibrary.NullTypes.IntNT)ContrattiFemCollectionObj[i].IdContrattoFem);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ContrattiFemCollectionObj.Count; i++)
				{
					if ((ContrattiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContrattiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ContrattiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ContrattiFemCollectionObj[i].IsDirty = false;
						ContrattiFemCollectionObj[i].IsPersistent = true;
					}
					if ((ContrattiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ContrattiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ContrattiFemCollectionObj[i].IsDirty = false;
						ContrattiFemCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ContrattiFem ContrattiFemObj)
		{
			int returnValue = 0;
			if (ContrattiFemObj.IsPersistent)
			{
				returnValue = Delete(db, ContrattiFemObj.IdContrattoFem);
			}
			ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ContrattiFemObj.IsDirty = false;
			ContrattiFemObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdContrattoFemValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZContrattiFemDelete", new string[] { "IdContrattoFem" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFem", (SiarLibrary.NullTypes.IntNT)IdContrattoFemValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ContrattiFemCollection ContrattiFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZContrattiFemDelete", new string[] { "IdContrattoFem" }, new string[] { "int" }, "");
				for (int i = 0; i < ContrattiFemCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdContrattoFem", ContrattiFemCollectionObj[i].IdContrattoFem);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ContrattiFemCollectionObj.Count; i++)
				{
					if ((ContrattiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ContrattiFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ContrattiFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ContrattiFemCollectionObj[i].IsDirty = false;
						ContrattiFemCollectionObj[i].IsPersistent = false;
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
		public static ContrattiFem GetById(DbProvider db, int IdContrattoFemValue)
		{
			ContrattiFem ContrattiFemObj = null;
			IDbCommand readCmd = db.InitCmd("ZContrattiFemGetById", new string[] { "IdContrattoFem" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdContrattoFem", (SiarLibrary.NullTypes.IntNT)IdContrattoFemValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ContrattiFemObj = GetFromDatareader(db);
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
			}
			db.Close();
			return ContrattiFemObj;
		}

		//getFromDatareader
		public static ContrattiFem GetFromDatareader(DbProvider db)
		{
			ContrattiFem ContrattiFemObj = new ContrattiFem();
			ContrattiFemObj.IdContrattoFem = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTRATTO_FEM"]);
			ContrattiFemObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ContrattiFemObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ContrattiFemObj.DataStipulaContratto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_STIPULA_CONTRATTO"]);
			ContrattiFemObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ContrattiFemObj.DataSegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SEGNATURA"]);
			ContrattiFemObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			ContrattiFemObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ContrattiFemObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			ContrattiFemObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ContrattiFemObj.OperatoreAggiornamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_AGGIORNAMENTO"]);
			ContrattiFemObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ContrattiFemObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ContrattiFemObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			ContrattiFemObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ContrattiFemObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ContrattiFemObj.IdProgettoRif = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_RIF"]);
			ContrattiFemObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			ContrattiFemObj.TipologiaCredito = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPOLOGIA_CREDITO"]);
			ContrattiFemObj.FinalitaOperazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["FINALITA_OPERAZIONE"]);
			ContrattiFemObj.ImportoFinanziamento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_FINANZIAMENTO"]);
			ContrattiFemObj.ImportoGaranziaConfidi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_GARANZIA_CONFIDI"]);
			ContrattiFemObj.ImportoGaranziaFondo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_GARANZIA_FONDO"]);
			ContrattiFemObj.Regime = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGIME"]);
			ContrattiFemObj.PerditaFondoEscussioneConfidi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERDITA_FONDO_ESCUSSIONE_CONFIDI"]);
			ContrattiFemObj.Confidi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFIDI"]);
			ContrattiFemObj.IdSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOGGETTO_GESTORE"]);
			ContrattiFemObj.IdProgettoSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_SOGGETTO_GESTORE"]);
			ContrattiFemObj.CodicePratica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_PRATICA"]);
			ContrattiFemObj.ImportoErogatoAlNettoDelleSpese = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_EROGATO_AL_NETTO_DELLE_SPESE"]);
			ContrattiFemObj.Gestore = new SiarLibrary.NullTypes.StringNT(db.DataReader["GESTORE"]);
			ContrattiFemObj.LineaIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINEA_INTERVENTO"]);
			ContrattiFemObj.DurataFinanziamentoErogato = new SiarLibrary.NullTypes.IntNT(db.DataReader["DURATA_FINANZIAMENTO_EROGATO"]);
			ContrattiFemObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
			ContrattiFemObj.CodiceFiscaleImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE_IMPRESA"]);
			ContrattiFemObj.CuaaImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA"]);
			ContrattiFemObj.NumeroGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_GIUSTIFICATIVO"]);
			ContrattiFemObj.CodTipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_GIUSTIFICATIVO"]);
			ContrattiFemObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
			ContrattiFemObj.DataGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GIUSTIFICATIVO"]);
			ContrattiFemObj.NumeroDoctrasportoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO_GIUSTIFICATIVO"]);
			ContrattiFemObj.DataDoctrasportoGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO_GIUSTIFICATIVO"]);
			ContrattiFemObj.ImponibileGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_GIUSTIFICATIVO"]);
			ContrattiFemObj.IvaGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA_GIUSTIFICATIVO"]);
			ContrattiFemObj.AltriOneriGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI_GIUSTIFICATIVO"]);
			ContrattiFemObj.DescrizioneGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_GIUSTIFICATIVO"]);
			ContrattiFemObj.CfFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE_GIUSTIFICATIVO"]);
			ContrattiFemObj.DescrizioneFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE_GIUSTIFICATIVO"]);
			ContrattiFemObj.IvaNonRecuperabileGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE_GIUSTIFICATIVO"]);
			ContrattiFemObj.IdFileGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_GIUSTIFICATIVO"]);
			ContrattiFemObj.InIntegrazioneGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE_GIUSTIFICATIVO"]);
			ContrattiFemObj.IdFileModificatoIntegrazioneGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO"]);
			ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ContrattiFemObj.IsDirty = false;
			ContrattiFemObj.IsPersistent = true;
			return ContrattiFemObj;
		}

		//Find Select

		public static ContrattiFemCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdContrattoFemEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataStipulaContrattoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSegnaturaEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreAggiornamentoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoRifEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis,
SiarLibrary.NullTypes.StringNT TipologiaCreditoEqualThis, SiarLibrary.NullTypes.StringNT FinalitaOperazioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoFinanziamentoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoGaranziaConfidiEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoGaranziaFondoEqualThis, SiarLibrary.NullTypes.StringNT RegimeEqualThis,
SiarLibrary.NullTypes.DecimalNT PerditaFondoEscussioneConfidiEqualThis, SiarLibrary.NullTypes.BoolNT ConfidiEqualThis, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis, SiarLibrary.NullTypes.StringNT CodicePraticaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoErogatoAlNettoDelleSpeseEqualThis,
SiarLibrary.NullTypes.StringNT GestoreEqualThis, SiarLibrary.NullTypes.StringNT LineaInterventoEqualThis, SiarLibrary.NullTypes.IntNT DurataFinanziamentoErogatoEqualThis)

		{

			ContrattiFemCollection ContrattiFemCollectionObj = new ContrattiFemCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrattifemfindselect", new string[] {"IdContrattoFemequalthis", "IdBandoequalthis", "IdProgettoequalthis",
"DataStipulaContrattoequalthis", "Segnaturaequalthis", "DataSegnaturaequalthis",
"Importoequalthis", "DataCreazioneequalthis", "DataAggiornamentoequalthis",
"OperatoreCreazioneequalthis", "OperatoreAggiornamentoequalthis", "IdImpresaequalthis",
"IdDomandaPagamentoequalthis", "Numeroequalthis", "IdFileequalthis",
"Descrizioneequalthis", "IdProgettoRifequalthis", "IdGiustificativoequalthis",
"TipologiaCreditoequalthis", "FinalitaOperazioneequalthis", "ImportoFinanziamentoequalthis",
"ImportoGaranziaConfidiequalthis", "ImportoGaranziaFondoequalthis", "Regimeequalthis",
"PerditaFondoEscussioneConfidiequalthis", "Confidiequalthis", "IdSoggettoGestoreequalthis",
"IdProgettoSoggettoGestoreequalthis", "CodicePraticaequalthis", "ImportoErogatoAlNettoDelleSpeseequalthis",
"Gestoreequalthis", "LineaInterventoequalthis", "DurataFinanziamentoErogatoequalthis"}, new string[] {"int", "int", "int",
"DateTime", "string", "DateTime",
"decimal", "DateTime", "DateTime",
"int", "int", "int",
"int", "string", "int",
"string", "int", "int",
"string", "string", "decimal",
"decimal", "decimal", "string",
"decimal", "bool", "int",
"int", "string", "decimal",
"string", "string", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContrattoFemequalthis", IdContrattoFemEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataStipulaContrattoequalthis", DataStipulaContrattoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSegnaturaequalthis", DataSegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreAggiornamentoequalthis", OperatoreAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoRifequalthis", IdProgettoRifEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipologiaCreditoequalthis", TipologiaCreditoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FinalitaOperazioneequalthis", FinalitaOperazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoFinanziamentoequalthis", ImportoFinanziamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoGaranziaConfidiequalthis", ImportoGaranziaConfidiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoGaranziaFondoequalthis", ImportoGaranziaFondoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Regimeequalthis", RegimeEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PerditaFondoEscussioneConfidiequalthis", PerditaFondoEscussioneConfidiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Confidiequalthis", ConfidiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoSoggettoGestoreequalthis", IdProgettoSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodicePraticaequalthis", CodicePraticaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoErogatoAlNettoDelleSpeseequalthis", ImportoErogatoAlNettoDelleSpeseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Gestoreequalthis", GestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LineaInterventoequalthis", LineaInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DurataFinanziamentoErogatoequalthis", DurataFinanziamentoErogatoEqualThis);
			ContrattiFem ContrattiFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ContrattiFemObj = GetFromDatareader(db);
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
				ContrattiFemCollectionObj.Add(ContrattiFemObj);
			}
			db.Close();
			return ContrattiFemCollectionObj;
		}

		//Find Find

		public static ContrattiFemCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT ConfidiEqualThis, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis)

		{

			ContrattiFemCollection ContrattiFemCollectionObj = new ContrattiFemCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrattifemfindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"IdDomandaPagamentoequalthis", "Confidiequalthis", "IdSoggettoGestoreequalthis",
"IdProgettoSoggettoGestoreequalthis"}, new string[] {"int", "int", "int",
"int", "bool", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Confidiequalthis", ConfidiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoSoggettoGestoreequalthis", IdProgettoSoggettoGestoreEqualThis);
			ContrattiFem ContrattiFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ContrattiFemObj = GetFromDatareader(db);
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
				ContrattiFemCollectionObj.Add(ContrattiFemObj);
			}
			db.Close();
			return ContrattiFemCollectionObj;
		}

		//Find FindConfidi

		public static ContrattiFemCollection FindConfidi(DbProvider db, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.BoolNT ConfidiEqualThis, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis)

		{

			ContrattiFemCollection ContrattiFemCollectionObj = new ContrattiFemCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrattifemfindfindconfidi", new string[] {"Numeroequalthis", "Confidiequalthis", "IdSoggettoGestoreequalthis",
"IdProgettoSoggettoGestoreequalthis"}, new string[] {"string", "bool", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Confidiequalthis", ConfidiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoSoggettoGestoreequalthis", IdProgettoSoggettoGestoreEqualThis);
			ContrattiFem ContrattiFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ContrattiFemObj = GetFromDatareader(db);
				ContrattiFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ContrattiFemObj.IsDirty = false;
				ContrattiFemObj.IsPersistent = true;
				ContrattiFemCollectionObj.Add(ContrattiFemObj);
			}
			db.Close();
			return ContrattiFemCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ContrattiFemCollectionProvider:IContrattiFemProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ContrattiFemCollectionProvider : IContrattiFemProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ContrattiFem
		protected ContrattiFemCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ContrattiFemCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ContrattiFemCollection(this);
		}

		//Costruttore 2: popola la collection
		public ContrattiFemCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IddomandapagamentoEqualThis, BoolNT ConfidiEqualThis, IntNT IdsoggettogestoreEqualThis,
IntNT IdprogettosoggettogestoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IddomandapagamentoEqualThis, ConfidiEqualThis, IdsoggettogestoreEqualThis,
IdprogettosoggettogestoreEqualThis);
		}

		//Costruttore3: ha in input contrattifemCollectionObj - non popola la collection
		public ContrattiFemCollectionProvider(ContrattiFemCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ContrattiFemCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ContrattiFemCollection(this);
		}

		//Get e Set
		public ContrattiFemCollection CollectionObj
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
		public int SaveCollection(ContrattiFemCollection collectionObj)
		{
			return ContrattiFemDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ContrattiFem contrattifemObj)
		{
			return ContrattiFemDAL.Save(_dbProviderObj, contrattifemObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ContrattiFemCollection collectionObj)
		{
			return ContrattiFemDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ContrattiFem contrattifemObj)
		{
			return ContrattiFemDAL.Delete(_dbProviderObj, contrattifemObj);
		}

		//getById
		public ContrattiFem GetById(IntNT IdContrattoFemValue)
		{
			ContrattiFem ContrattiFemTemp = ContrattiFemDAL.GetById(_dbProviderObj, IdContrattoFemValue);
			if (ContrattiFemTemp != null) ContrattiFemTemp.Provider = this;
			return ContrattiFemTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ContrattiFemCollection Select(IntNT IdcontrattofemEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
DatetimeNT DatastipulacontrattoEqualThis, StringNT SegnaturaEqualThis, DatetimeNT DatasegnaturaEqualThis,
DecimalNT ImportoEqualThis, DatetimeNT DatacreazioneEqualThis, DatetimeNT DataaggiornamentoEqualThis,
IntNT OperatorecreazioneEqualThis, IntNT OperatoreaggiornamentoEqualThis, IntNT IdimpresaEqualThis,
IntNT IddomandapagamentoEqualThis, StringNT NumeroEqualThis, IntNT IdfileEqualThis,
StringNT DescrizioneEqualThis, IntNT IdprogettorifEqualThis, IntNT IdgiustificativoEqualThis,
StringNT TipologiacreditoEqualThis, StringNT FinalitaoperazioneEqualThis, DecimalNT ImportofinanziamentoEqualThis,
DecimalNT ImportogaranziaconfidiEqualThis, DecimalNT ImportogaranziafondoEqualThis, StringNT RegimeEqualThis,
DecimalNT PerditafondoescussioneconfidiEqualThis, BoolNT ConfidiEqualThis, IntNT IdsoggettogestoreEqualThis,
IntNT IdprogettosoggettogestoreEqualThis, StringNT CodicepraticaEqualThis, DecimalNT ImportoerogatoalnettodellespeseEqualThis,
StringNT GestoreEqualThis, StringNT LineainterventoEqualThis, IntNT DuratafinanziamentoerogatoEqualThis)
		{
			ContrattiFemCollection ContrattiFemCollectionTemp = ContrattiFemDAL.Select(_dbProviderObj, IdcontrattofemEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
DatastipulacontrattoEqualThis, SegnaturaEqualThis, DatasegnaturaEqualThis,
ImportoEqualThis, DatacreazioneEqualThis, DataaggiornamentoEqualThis,
OperatorecreazioneEqualThis, OperatoreaggiornamentoEqualThis, IdimpresaEqualThis,
IddomandapagamentoEqualThis, NumeroEqualThis, IdfileEqualThis,
DescrizioneEqualThis, IdprogettorifEqualThis, IdgiustificativoEqualThis,
TipologiacreditoEqualThis, FinalitaoperazioneEqualThis, ImportofinanziamentoEqualThis,
ImportogaranziaconfidiEqualThis, ImportogaranziafondoEqualThis, RegimeEqualThis,
PerditafondoescussioneconfidiEqualThis, ConfidiEqualThis, IdsoggettogestoreEqualThis,
IdprogettosoggettogestoreEqualThis, CodicepraticaEqualThis, ImportoerogatoalnettodellespeseEqualThis,
GestoreEqualThis, LineainterventoEqualThis, DuratafinanziamentoerogatoEqualThis);
			ContrattiFemCollectionTemp.Provider = this;
			return ContrattiFemCollectionTemp;
		}

		//Find: popola la collection
		public ContrattiFemCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IddomandapagamentoEqualThis, BoolNT ConfidiEqualThis, IntNT IdsoggettogestoreEqualThis,
IntNT IdprogettosoggettogestoreEqualThis)
		{
			ContrattiFemCollection ContrattiFemCollectionTemp = ContrattiFemDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IddomandapagamentoEqualThis, ConfidiEqualThis, IdsoggettogestoreEqualThis,
IdprogettosoggettogestoreEqualThis);
			ContrattiFemCollectionTemp.Provider = this;
			return ContrattiFemCollectionTemp;
		}

		//FindConfidi: popola la collection
		public ContrattiFemCollection FindConfidi(StringNT NumeroEqualThis, BoolNT ConfidiEqualThis, IntNT IdsoggettogestoreEqualThis,
IntNT IdprogettosoggettogestoreEqualThis)
		{
			ContrattiFemCollection ContrattiFemCollectionTemp = ContrattiFemDAL.FindConfidi(_dbProviderObj, NumeroEqualThis, ConfidiEqualThis, IdsoggettogestoreEqualThis,
IdprogettosoggettogestoreEqualThis);
			ContrattiFemCollectionTemp.Provider = this;
			return ContrattiFemCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTRATTI_FEM>
  <ViewName>VCONTRATTI_FEM</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <CONFIDI>Equal</CONFIDI>
      <ID_SOGGETTO_GESTORE>Equal</ID_SOGGETTO_GESTORE>
      <ID_PROGETTO_SOGGETTO_GESTORE>Equal</ID_PROGETTO_SOGGETTO_GESTORE>
    </Find>
    <FindConfidi OrderBy="ORDER BY ">
      <NUMERO>Equal</NUMERO>
      <CONFIDI>Equal</CONFIDI>
      <ID_SOGGETTO_GESTORE>Equal</ID_SOGGETTO_GESTORE>
      <ID_PROGETTO_SOGGETTO_GESTORE>Equal</ID_PROGETTO_SOGGETTO_GESTORE>
    </FindConfidi>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTRATTI_FEM>
*/
