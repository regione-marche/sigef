using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RichiestaProfilazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRichiestaProfilazioneProvider
	{
		int Save(RichiestaProfilazione RichiestaProfilazioneObj);
		int SaveCollection(RichiestaProfilazioneCollection collectionObj);
		int Delete(RichiestaProfilazione RichiestaProfilazioneObj);
		int DeleteCollection(RichiestaProfilazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RichiestaProfilazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RichiestaProfilazione : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRichiesta;
		private NullTypes.IntNT _Operatore;
		private NullTypes.BoolNT _Definitiva;
		private NullTypes.DatetimeNT _LasteditDatetim;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.DatetimeNT _DataApprovazione;
		private NullTypes.IntNT _OperatoreApprovazione;
		private NullTypes.StringNT _MotivazioneRifiuto;
		private NullTypes.DatetimeNT _DataArrivo;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _Pf;
		private NullTypes.StringNT _Servizio;
		private NullTypes.StringNT _Pec;
		private NullTypes.BoolNT _FondiFesr;
		private NullTypes.StringNT _Asse;
		private NullTypes.StringNT _Azione;
		private NullTypes.StringNT _ParereAdg;
		private NullTypes.BoolNT _Multiazione;
		private NullTypes.BoolNT _Perc10;
		private NullTypes.StringNT _Oggetto;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.StringNT _Rup;
		private NullTypes.StringNT _RupTelefono;
		private NullTypes.StringNT _RupEmail;
		private NullTypes.DatetimeNT _DataApertura;
		private NullTypes.StringNT _OraApertura;
		private NullTypes.DatetimeNT _DataChiusura;
		private NullTypes.StringNT _OraChiusura;
		private NullTypes.StringNT _Decreto;
		private NullTypes.StringNT _FascicoloPaleo;
		private NullTypes.BoolNT _Graduatoria;
		private NullTypes.BoolNT _Sportello;
		private NullTypes.BoolNT _StrumentiFinanziari;
		private NullTypes.BoolNT _FinanziabilitaParziale;
		private NullTypes.StringNT _TipoProcedura;
		private NullTypes.BoolNT _MarcaDaBollo;
		private NullTypes.StringNT _TipoAggregazione;
		private NullTypes.BoolNT _Capofila;
		private NullTypes.StringNT _TipoBenificiario;
		private NullTypes.StringNT _Ateco;
		private NullTypes.BoolNT _NumeroDomande;
		private NullTypes.BoolNT _DeMinimis;
		private NullTypes.BoolNT _ContributoUe;
		private NullTypes.StringNT _TipoPiano;
		private NullTypes.StringNT _DataAmmissibilita;
		private NullTypes.DecimalNT _CostoMin;
		private NullTypes.DecimalNT _CostoMax;
		private NullTypes.BoolNT _Comitato;
		private NullTypes.StringNT _PunteggioMin;
		private NullTypes.StringNT _Allegati;
		private NullTypes.StringNT _Dichiarazioni;
		private NullTypes.StringNT _DichiarazioniOpz;
		private NullTypes.BoolNT _CupBeni;
		private NullTypes.BoolNT _CupServizi;
		private NullTypes.BoolNT _CupLavPub;
		private NullTypes.BoolNT _CupContr;
		private NullTypes.BoolNT _CupProd;
		private NullTypes.BoolNT _CupCap;
		[NonSerialized] private IRichiestaProfilazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IRichiestaProfilazioneProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public RichiestaProfilazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiesta
		{
			get { return _IdRichiesta; }
			set
			{
				if (IdRichiesta != value)
				{
					_IdRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
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
		/// Corrisponde al campo:DEFINITIVA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitiva
		{
			get { return _Definitiva; }
			set
			{
				if (Definitiva != value)
				{
					_Definitiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LASTEDIT_DATETIM
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT LasteditDatetim
		{
			get { return _LasteditDatetim; }
			set
			{
				if (LasteditDatetim != value)
				{
					_LasteditDatetim = value;
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
		/// Corrisponde al campo:MOTIVAZIONE_RIFIUTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT MotivazioneRifiuto
		{
			get { return _MotivazioneRifiuto; }
			set
			{
				if (MotivazioneRifiuto != value)
				{
					_MotivazioneRifiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ARRIVO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataArrivo
		{
			get { return _DataArrivo; }
			set
			{
				if (DataArrivo != value)
				{
					_DataArrivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(250)
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
		/// Corrisponde al campo:PF
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Pf
		{
			get { return _Pf; }
			set
			{
				if (Pf != value)
				{
					_Pf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SERVIZIO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Servizio
		{
			get { return _Servizio; }
			set
			{
				if (Servizio != value)
				{
					_Servizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PEC
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Pec
		{
			get { return _Pec; }
			set
			{
				if (Pec != value)
				{
					_Pec = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FONDI_FESR
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FondiFesr
		{
			get { return _FondiFesr; }
			set
			{
				if (FondiFesr != value)
				{
					_FondiFesr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ASSE
		/// Tipo sul db:VARCHAR(250)
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
		/// Corrisponde al campo:AZIONE
		/// Tipo sul db:VARCHAR(250)
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
		/// Corrisponde al campo:PARERE_ADG
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT ParereAdg
		{
			get { return _ParereAdg; }
			set
			{
				if (ParereAdg != value)
				{
					_ParereAdg = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MULTIAZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Multiazione
		{
			get { return _Multiazione; }
			set
			{
				if (Multiazione != value)
				{
					_Multiazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERC10
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Perc10
		{
			get { return _Perc10; }
			set
			{
				if (Perc10 != value)
				{
					_Perc10 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OGGETTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Oggetto
		{
			get { return _Oggetto; }
			set
			{
				if (Oggetto != value)
				{
					_Oggetto = value;
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
		/// Corrisponde al campo:RUP
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Rup
		{
			get { return _Rup; }
			set
			{
				if (Rup != value)
				{
					_Rup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUP_TELEFONO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT RupTelefono
		{
			get { return _RupTelefono; }
			set
			{
				if (RupTelefono != value)
				{
					_RupTelefono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUP_EMAIL
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT RupEmail
		{
			get { return _RupEmail; }
			set
			{
				if (RupEmail != value)
				{
					_RupEmail = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_APERTURA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApertura
		{
			get { return _DataApertura; }
			set
			{
				if (DataApertura != value)
				{
					_DataApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORA_APERTURA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OraApertura
		{
			get { return _OraApertura; }
			set
			{
				if (OraApertura != value)
				{
					_OraApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CHIUSURA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataChiusura
		{
			get { return _DataChiusura; }
			set
			{
				if (DataChiusura != value)
				{
					_DataChiusura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORA_CHIUSURA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OraChiusura
		{
			get { return _OraChiusura; }
			set
			{
				if (OraChiusura != value)
				{
					_OraChiusura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DECRETO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Decreto
		{
			get { return _Decreto; }
			set
			{
				if (Decreto != value)
				{
					_Decreto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASCICOLO_PALEO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT FascicoloPaleo
		{
			get { return _FascicoloPaleo; }
			set
			{
				if (FascicoloPaleo != value)
				{
					_FascicoloPaleo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GRADUATORIA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Graduatoria
		{
			get { return _Graduatoria; }
			set
			{
				if (Graduatoria != value)
				{
					_Graduatoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPORTELLO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Sportello
		{
			get { return _Sportello; }
			set
			{
				if (Sportello != value)
				{
					_Sportello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STRUMENTI_FINANZIARI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT StrumentiFinanziari
		{
			get { return _StrumentiFinanziari; }
			set
			{
				if (StrumentiFinanziari != value)
				{
					_StrumentiFinanziari = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FINANZIABILITA_PARZIALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FinanziabilitaParziale
		{
			get { return _FinanziabilitaParziale; }
			set
			{
				if (FinanziabilitaParziale != value)
				{
					_FinanziabilitaParziale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_PROCEDURA
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT TipoProcedura
		{
			get { return _TipoProcedura; }
			set
			{
				if (TipoProcedura != value)
				{
					_TipoProcedura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MARCA_DA_BOLLO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MarcaDaBollo
		{
			get { return _MarcaDaBollo; }
			set
			{
				if (MarcaDaBollo != value)
				{
					_MarcaDaBollo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_AGGREGAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoAggregazione
		{
			get { return _TipoAggregazione; }
			set
			{
				if (TipoAggregazione != value)
				{
					_TipoAggregazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAPOFILA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Capofila
		{
			get { return _Capofila; }
			set
			{
				if (Capofila != value)
				{
					_Capofila = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_BENIFICIARIO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoBenificiario
		{
			get { return _TipoBenificiario; }
			set
			{
				if (TipoBenificiario != value)
				{
					_TipoBenificiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATECO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Ateco
		{
			get { return _Ateco; }
			set
			{
				if (Ateco != value)
				{
					_Ateco = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_DOMANDE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT NumeroDomande
		{
			get { return _NumeroDomande; }
			set
			{
				if (NumeroDomande != value)
				{
					_NumeroDomande = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DE_MINIMIS
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DeMinimis
		{
			get { return _DeMinimis; }
			set
			{
				if (DeMinimis != value)
				{
					_DeMinimis = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_UE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContributoUe
		{
			get { return _ContributoUe; }
			set
			{
				if (ContributoUe != value)
				{
					_ContributoUe = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_PIANO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TipoPiano
		{
			get { return _TipoPiano; }
			set
			{
				if (TipoPiano != value)
				{
					_TipoPiano = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_AMMISSIBILITA
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT DataAmmissibilita
		{
			get { return _DataAmmissibilita; }
			set
			{
				if (DataAmmissibilita != value)
				{
					_DataAmmissibilita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_MIN
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoMin
		{
			get { return _CostoMin; }
			set
			{
				if (CostoMin != value)
				{
					_CostoMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_MAX
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT CostoMax
		{
			get { return _CostoMax; }
			set
			{
				if (CostoMax != value)
				{
					_CostoMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMITATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Comitato
		{
			get { return _Comitato; }
			set
			{
				if (Comitato != value)
				{
					_Comitato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO_MIN
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT PunteggioMin
		{
			get { return _PunteggioMin; }
			set
			{
				if (PunteggioMin != value)
				{
					_PunteggioMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALLEGATI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Allegati
		{
			get { return _Allegati; }
			set
			{
				if (Allegati != value)
				{
					_Allegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DICHIARAZIONI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Dichiarazioni
		{
			get { return _Dichiarazioni; }
			set
			{
				if (Dichiarazioni != value)
				{
					_Dichiarazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DICHIARAZIONI_OPZ
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DichiarazioniOpz
		{
			get { return _DichiarazioniOpz; }
			set
			{
				if (DichiarazioniOpz != value)
				{
					_DichiarazioniOpz = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_BENI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupBeni
		{
			get { return _CupBeni; }
			set
			{
				if (CupBeni != value)
				{
					_CupBeni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_SERVIZI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupServizi
		{
			get { return _CupServizi; }
			set
			{
				if (CupServizi != value)
				{
					_CupServizi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_LAV_PUB
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupLavPub
		{
			get { return _CupLavPub; }
			set
			{
				if (CupLavPub != value)
				{
					_CupLavPub = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_CONTR
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupContr
		{
			get { return _CupContr; }
			set
			{
				if (CupContr != value)
				{
					_CupContr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_PROD
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupProd
		{
			get { return _CupProd; }
			set
			{
				if (CupProd != value)
				{
					_CupProd = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUP_CAP
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CupCap
		{
			get { return _CupCap; }
			set
			{
				if (CupCap != value)
				{
					_CupCap = value;
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
	/// Summary description for RichiestaProfilazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaProfilazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RichiestaProfilazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((RichiestaProfilazione)info.GetValue(i.ToString(), typeof(RichiestaProfilazione)));
			}
		}

		//Costruttore
		public RichiestaProfilazioneCollection()
		{
			this.ItemType = typeof(RichiestaProfilazione);
		}

		//Costruttore con provider
		public RichiestaProfilazioneCollection(IRichiestaProfilazioneProvider providerObj)
		{
			this.ItemType = typeof(RichiestaProfilazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RichiestaProfilazione this[int index]
		{
			get { return (RichiestaProfilazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RichiestaProfilazioneCollection GetChanges()
		{
			return (RichiestaProfilazioneCollection)base.GetChanges();
		}

		[NonSerialized] private IRichiestaProfilazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IRichiestaProfilazioneProvider Provider
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
		public int Add(RichiestaProfilazione RichiestaProfilazioneObj)
		{
			if (RichiestaProfilazioneObj.Provider == null) RichiestaProfilazioneObj.Provider = this.Provider;
			return base.Add(RichiestaProfilazioneObj);
		}

		//AddCollection
		public void AddCollection(RichiestaProfilazioneCollection RichiestaProfilazioneCollectionObj)
		{
			foreach (RichiestaProfilazione RichiestaProfilazioneObj in RichiestaProfilazioneCollectionObj)
				this.Add(RichiestaProfilazioneObj);
		}

		//Insert
		public void Insert(int index, RichiestaProfilazione RichiestaProfilazioneObj)
		{
			if (RichiestaProfilazioneObj.Provider == null) RichiestaProfilazioneObj.Provider = this.Provider;
			base.Insert(index, RichiestaProfilazioneObj);
		}

		//CollectionGetById
		public RichiestaProfilazione CollectionGetById(NullTypes.IntNT IdRichiestaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdRichiesta == IdRichiestaValue))
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
		public RichiestaProfilazioneCollection SubSelect(NullTypes.IntNT IdRichiestaEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.BoolNT DefinitivaEqualThis,
NullTypes.DatetimeNT LasteditDatetimEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.DatetimeNT DataApprovazioneEqualThis,
NullTypes.IntNT OperatoreApprovazioneEqualThis, NullTypes.StringNT MotivazioneRifiutoEqualThis, NullTypes.DatetimeNT DataArrivoEqualThis,
NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT PfEqualThis, NullTypes.StringNT ServizioEqualThis,
NullTypes.StringNT PecEqualThis, NullTypes.BoolNT FondiFesrEqualThis, NullTypes.StringNT AsseEqualThis,
NullTypes.StringNT AzioneEqualThis, NullTypes.StringNT ParereAdgEqualThis, NullTypes.BoolNT MultiazioneEqualThis,
NullTypes.BoolNT Perc10EqualThis, NullTypes.StringNT OggettoEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.StringNT RupEqualThis, NullTypes.StringNT RupTelefonoEqualThis, NullTypes.StringNT RupEmailEqualThis,
NullTypes.DatetimeNT DataAperturaEqualThis, NullTypes.StringNT OraAperturaEqualThis, NullTypes.DatetimeNT DataChiusuraEqualThis,
NullTypes.StringNT OraChiusuraEqualThis, NullTypes.StringNT DecretoEqualThis, NullTypes.StringNT FascicoloPaleoEqualThis,
NullTypes.BoolNT GraduatoriaEqualThis, NullTypes.BoolNT SportelloEqualThis, NullTypes.BoolNT StrumentiFinanziariEqualThis,
NullTypes.BoolNT FinanziabilitaParzialeEqualThis, NullTypes.StringNT TipoProceduraEqualThis, NullTypes.BoolNT MarcaDaBolloEqualThis,
NullTypes.StringNT TipoAggregazioneEqualThis, NullTypes.BoolNT CapofilaEqualThis, NullTypes.StringNT TipoBenificiarioEqualThis,
NullTypes.StringNT AtecoEqualThis, NullTypes.BoolNT NumeroDomandeEqualThis, NullTypes.BoolNT DeMinimisEqualThis,
NullTypes.BoolNT ContributoUeEqualThis, NullTypes.StringNT TipoPianoEqualThis, NullTypes.StringNT DataAmmissibilitaEqualThis,
NullTypes.DecimalNT CostoMinEqualThis, NullTypes.DecimalNT CostoMaxEqualThis, NullTypes.BoolNT ComitatoEqualThis,
NullTypes.StringNT PunteggioMinEqualThis, NullTypes.StringNT AllegatiEqualThis, NullTypes.StringNT DichiarazioniEqualThis,
NullTypes.StringNT DichiarazioniOpzEqualThis, NullTypes.BoolNT CupBeniEqualThis, NullTypes.BoolNT CupServiziEqualThis,
NullTypes.BoolNT CupLavPubEqualThis, NullTypes.BoolNT CupContrEqualThis, NullTypes.BoolNT CupProdEqualThis,
NullTypes.BoolNT CupCapEqualThis)
		{
			RichiestaProfilazioneCollection RichiestaProfilazioneCollectionTemp = new RichiestaProfilazioneCollection();
			foreach (RichiestaProfilazione RichiestaProfilazioneItem in this)
			{
				if (((IdRichiestaEqualThis == null) || ((RichiestaProfilazioneItem.IdRichiesta != null) && (RichiestaProfilazioneItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((RichiestaProfilazioneItem.Operatore != null) && (RichiestaProfilazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((RichiestaProfilazioneItem.Definitiva != null) && (RichiestaProfilazioneItem.Definitiva.Value == DefinitivaEqualThis.Value))) &&
((LasteditDatetimEqualThis == null) || ((RichiestaProfilazioneItem.LasteditDatetim != null) && (RichiestaProfilazioneItem.LasteditDatetim.Value == LasteditDatetimEqualThis.Value))) && ((ApprovataEqualThis == null) || ((RichiestaProfilazioneItem.Approvata != null) && (RichiestaProfilazioneItem.Approvata.Value == ApprovataEqualThis.Value))) && ((DataApprovazioneEqualThis == null) || ((RichiestaProfilazioneItem.DataApprovazione != null) && (RichiestaProfilazioneItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) &&
((OperatoreApprovazioneEqualThis == null) || ((RichiestaProfilazioneItem.OperatoreApprovazione != null) && (RichiestaProfilazioneItem.OperatoreApprovazione.Value == OperatoreApprovazioneEqualThis.Value))) && ((MotivazioneRifiutoEqualThis == null) || ((RichiestaProfilazioneItem.MotivazioneRifiuto != null) && (RichiestaProfilazioneItem.MotivazioneRifiuto.Value == MotivazioneRifiutoEqualThis.Value))) && ((DataArrivoEqualThis == null) || ((RichiestaProfilazioneItem.DataArrivo != null) && (RichiestaProfilazioneItem.DataArrivo.Value == DataArrivoEqualThis.Value))) &&
((SegnaturaEqualThis == null) || ((RichiestaProfilazioneItem.Segnatura != null) && (RichiestaProfilazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((PfEqualThis == null) || ((RichiestaProfilazioneItem.Pf != null) && (RichiestaProfilazioneItem.Pf.Value == PfEqualThis.Value))) && ((ServizioEqualThis == null) || ((RichiestaProfilazioneItem.Servizio != null) && (RichiestaProfilazioneItem.Servizio.Value == ServizioEqualThis.Value))) &&
((PecEqualThis == null) || ((RichiestaProfilazioneItem.Pec != null) && (RichiestaProfilazioneItem.Pec.Value == PecEqualThis.Value))) && ((FondiFesrEqualThis == null) || ((RichiestaProfilazioneItem.FondiFesr != null) && (RichiestaProfilazioneItem.FondiFesr.Value == FondiFesrEqualThis.Value))) && ((AsseEqualThis == null) || ((RichiestaProfilazioneItem.Asse != null) && (RichiestaProfilazioneItem.Asse.Value == AsseEqualThis.Value))) &&
((AzioneEqualThis == null) || ((RichiestaProfilazioneItem.Azione != null) && (RichiestaProfilazioneItem.Azione.Value == AzioneEqualThis.Value))) && ((ParereAdgEqualThis == null) || ((RichiestaProfilazioneItem.ParereAdg != null) && (RichiestaProfilazioneItem.ParereAdg.Value == ParereAdgEqualThis.Value))) && ((MultiazioneEqualThis == null) || ((RichiestaProfilazioneItem.Multiazione != null) && (RichiestaProfilazioneItem.Multiazione.Value == MultiazioneEqualThis.Value))) &&
((Perc10EqualThis == null) || ((RichiestaProfilazioneItem.Perc10 != null) && (RichiestaProfilazioneItem.Perc10.Value == Perc10EqualThis.Value))) && ((OggettoEqualThis == null) || ((RichiestaProfilazioneItem.Oggetto != null) && (RichiestaProfilazioneItem.Oggetto.Value == OggettoEqualThis.Value))) && ((ImportoEqualThis == null) || ((RichiestaProfilazioneItem.Importo != null) && (RichiestaProfilazioneItem.Importo.Value == ImportoEqualThis.Value))) &&
((RupEqualThis == null) || ((RichiestaProfilazioneItem.Rup != null) && (RichiestaProfilazioneItem.Rup.Value == RupEqualThis.Value))) && ((RupTelefonoEqualThis == null) || ((RichiestaProfilazioneItem.RupTelefono != null) && (RichiestaProfilazioneItem.RupTelefono.Value == RupTelefonoEqualThis.Value))) && ((RupEmailEqualThis == null) || ((RichiestaProfilazioneItem.RupEmail != null) && (RichiestaProfilazioneItem.RupEmail.Value == RupEmailEqualThis.Value))) &&
((DataAperturaEqualThis == null) || ((RichiestaProfilazioneItem.DataApertura != null) && (RichiestaProfilazioneItem.DataApertura.Value == DataAperturaEqualThis.Value))) && ((OraAperturaEqualThis == null) || ((RichiestaProfilazioneItem.OraApertura != null) && (RichiestaProfilazioneItem.OraApertura.Value == OraAperturaEqualThis.Value))) && ((DataChiusuraEqualThis == null) || ((RichiestaProfilazioneItem.DataChiusura != null) && (RichiestaProfilazioneItem.DataChiusura.Value == DataChiusuraEqualThis.Value))) &&
((OraChiusuraEqualThis == null) || ((RichiestaProfilazioneItem.OraChiusura != null) && (RichiestaProfilazioneItem.OraChiusura.Value == OraChiusuraEqualThis.Value))) && ((DecretoEqualThis == null) || ((RichiestaProfilazioneItem.Decreto != null) && (RichiestaProfilazioneItem.Decreto.Value == DecretoEqualThis.Value))) && ((FascicoloPaleoEqualThis == null) || ((RichiestaProfilazioneItem.FascicoloPaleo != null) && (RichiestaProfilazioneItem.FascicoloPaleo.Value == FascicoloPaleoEqualThis.Value))) &&
((GraduatoriaEqualThis == null) || ((RichiestaProfilazioneItem.Graduatoria != null) && (RichiestaProfilazioneItem.Graduatoria.Value == GraduatoriaEqualThis.Value))) && ((SportelloEqualThis == null) || ((RichiestaProfilazioneItem.Sportello != null) && (RichiestaProfilazioneItem.Sportello.Value == SportelloEqualThis.Value))) && ((StrumentiFinanziariEqualThis == null) || ((RichiestaProfilazioneItem.StrumentiFinanziari != null) && (RichiestaProfilazioneItem.StrumentiFinanziari.Value == StrumentiFinanziariEqualThis.Value))) &&
((FinanziabilitaParzialeEqualThis == null) || ((RichiestaProfilazioneItem.FinanziabilitaParziale != null) && (RichiestaProfilazioneItem.FinanziabilitaParziale.Value == FinanziabilitaParzialeEqualThis.Value))) && ((TipoProceduraEqualThis == null) || ((RichiestaProfilazioneItem.TipoProcedura != null) && (RichiestaProfilazioneItem.TipoProcedura.Value == TipoProceduraEqualThis.Value))) && ((MarcaDaBolloEqualThis == null) || ((RichiestaProfilazioneItem.MarcaDaBollo != null) && (RichiestaProfilazioneItem.MarcaDaBollo.Value == MarcaDaBolloEqualThis.Value))) &&
((TipoAggregazioneEqualThis == null) || ((RichiestaProfilazioneItem.TipoAggregazione != null) && (RichiestaProfilazioneItem.TipoAggregazione.Value == TipoAggregazioneEqualThis.Value))) && ((CapofilaEqualThis == null) || ((RichiestaProfilazioneItem.Capofila != null) && (RichiestaProfilazioneItem.Capofila.Value == CapofilaEqualThis.Value))) && ((TipoBenificiarioEqualThis == null) || ((RichiestaProfilazioneItem.TipoBenificiario != null) && (RichiestaProfilazioneItem.TipoBenificiario.Value == TipoBenificiarioEqualThis.Value))) &&
((AtecoEqualThis == null) || ((RichiestaProfilazioneItem.Ateco != null) && (RichiestaProfilazioneItem.Ateco.Value == AtecoEqualThis.Value))) && ((NumeroDomandeEqualThis == null) || ((RichiestaProfilazioneItem.NumeroDomande != null) && (RichiestaProfilazioneItem.NumeroDomande.Value == NumeroDomandeEqualThis.Value))) && ((DeMinimisEqualThis == null) || ((RichiestaProfilazioneItem.DeMinimis != null) && (RichiestaProfilazioneItem.DeMinimis.Value == DeMinimisEqualThis.Value))) &&
((ContributoUeEqualThis == null) || ((RichiestaProfilazioneItem.ContributoUe != null) && (RichiestaProfilazioneItem.ContributoUe.Value == ContributoUeEqualThis.Value))) && ((TipoPianoEqualThis == null) || ((RichiestaProfilazioneItem.TipoPiano != null) && (RichiestaProfilazioneItem.TipoPiano.Value == TipoPianoEqualThis.Value))) && ((DataAmmissibilitaEqualThis == null) || ((RichiestaProfilazioneItem.DataAmmissibilita != null) && (RichiestaProfilazioneItem.DataAmmissibilita.Value == DataAmmissibilitaEqualThis.Value))) &&
((CostoMinEqualThis == null) || ((RichiestaProfilazioneItem.CostoMin != null) && (RichiestaProfilazioneItem.CostoMin.Value == CostoMinEqualThis.Value))) && ((CostoMaxEqualThis == null) || ((RichiestaProfilazioneItem.CostoMax != null) && (RichiestaProfilazioneItem.CostoMax.Value == CostoMaxEqualThis.Value))) && ((ComitatoEqualThis == null) || ((RichiestaProfilazioneItem.Comitato != null) && (RichiestaProfilazioneItem.Comitato.Value == ComitatoEqualThis.Value))) &&
((PunteggioMinEqualThis == null) || ((RichiestaProfilazioneItem.PunteggioMin != null) && (RichiestaProfilazioneItem.PunteggioMin.Value == PunteggioMinEqualThis.Value))) && ((AllegatiEqualThis == null) || ((RichiestaProfilazioneItem.Allegati != null) && (RichiestaProfilazioneItem.Allegati.Value == AllegatiEqualThis.Value))) && ((DichiarazioniEqualThis == null) || ((RichiestaProfilazioneItem.Dichiarazioni != null) && (RichiestaProfilazioneItem.Dichiarazioni.Value == DichiarazioniEqualThis.Value))) &&
((DichiarazioniOpzEqualThis == null) || ((RichiestaProfilazioneItem.DichiarazioniOpz != null) && (RichiestaProfilazioneItem.DichiarazioniOpz.Value == DichiarazioniOpzEqualThis.Value))) && ((CupBeniEqualThis == null) || ((RichiestaProfilazioneItem.CupBeni != null) && (RichiestaProfilazioneItem.CupBeni.Value == CupBeniEqualThis.Value))) && ((CupServiziEqualThis == null) || ((RichiestaProfilazioneItem.CupServizi != null) && (RichiestaProfilazioneItem.CupServizi.Value == CupServiziEqualThis.Value))) &&
((CupLavPubEqualThis == null) || ((RichiestaProfilazioneItem.CupLavPub != null) && (RichiestaProfilazioneItem.CupLavPub.Value == CupLavPubEqualThis.Value))) && ((CupContrEqualThis == null) || ((RichiestaProfilazioneItem.CupContr != null) && (RichiestaProfilazioneItem.CupContr.Value == CupContrEqualThis.Value))) && ((CupProdEqualThis == null) || ((RichiestaProfilazioneItem.CupProd != null) && (RichiestaProfilazioneItem.CupProd.Value == CupProdEqualThis.Value))) &&
((CupCapEqualThis == null) || ((RichiestaProfilazioneItem.CupCap != null) && (RichiestaProfilazioneItem.CupCap.Value == CupCapEqualThis.Value))))
				{
					RichiestaProfilazioneCollectionTemp.Add(RichiestaProfilazioneItem);
				}
			}
			return RichiestaProfilazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RichiestaProfilazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RichiestaProfilazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RichiestaProfilazione RichiestaProfilazioneObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdRichiesta", RichiestaProfilazioneObj.IdRichiesta);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "Operatore", RichiestaProfilazioneObj.Operatore);
			DbProvider.SetCmdParam(cmd, firstChar + "Definitiva", RichiestaProfilazioneObj.Definitiva);
			DbProvider.SetCmdParam(cmd, firstChar + "LasteditDatetim", RichiestaProfilazioneObj.LasteditDatetim);
			DbProvider.SetCmdParam(cmd, firstChar + "Approvata", RichiestaProfilazioneObj.Approvata);
			DbProvider.SetCmdParam(cmd, firstChar + "DataApprovazione", RichiestaProfilazioneObj.DataApprovazione);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreApprovazione", RichiestaProfilazioneObj.OperatoreApprovazione);
			DbProvider.SetCmdParam(cmd, firstChar + "MotivazioneRifiuto", RichiestaProfilazioneObj.MotivazioneRifiuto);
			DbProvider.SetCmdParam(cmd, firstChar + "DataArrivo", RichiestaProfilazioneObj.DataArrivo);
			DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", RichiestaProfilazioneObj.Segnatura);
			DbProvider.SetCmdParam(cmd, firstChar + "Pf", RichiestaProfilazioneObj.Pf);
			DbProvider.SetCmdParam(cmd, firstChar + "Servizio", RichiestaProfilazioneObj.Servizio);
			DbProvider.SetCmdParam(cmd, firstChar + "Pec", RichiestaProfilazioneObj.Pec);
			DbProvider.SetCmdParam(cmd, firstChar + "FondiFesr", RichiestaProfilazioneObj.FondiFesr);
			DbProvider.SetCmdParam(cmd, firstChar + "Asse", RichiestaProfilazioneObj.Asse);
			DbProvider.SetCmdParam(cmd, firstChar + "Azione", RichiestaProfilazioneObj.Azione);
			DbProvider.SetCmdParam(cmd, firstChar + "ParereAdg", RichiestaProfilazioneObj.ParereAdg);
			DbProvider.SetCmdParam(cmd, firstChar + "Multiazione", RichiestaProfilazioneObj.Multiazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Perc10", RichiestaProfilazioneObj.Perc10);
			DbProvider.SetCmdParam(cmd, firstChar + "Oggetto", RichiestaProfilazioneObj.Oggetto);
			DbProvider.SetCmdParam(cmd, firstChar + "Importo", RichiestaProfilazioneObj.Importo);
			DbProvider.SetCmdParam(cmd, firstChar + "Rup", RichiestaProfilazioneObj.Rup);
			DbProvider.SetCmdParam(cmd, firstChar + "RupTelefono", RichiestaProfilazioneObj.RupTelefono);
			DbProvider.SetCmdParam(cmd, firstChar + "RupEmail", RichiestaProfilazioneObj.RupEmail);
			DbProvider.SetCmdParam(cmd, firstChar + "DataApertura", RichiestaProfilazioneObj.DataApertura);
			DbProvider.SetCmdParam(cmd, firstChar + "OraApertura", RichiestaProfilazioneObj.OraApertura);
			DbProvider.SetCmdParam(cmd, firstChar + "DataChiusura", RichiestaProfilazioneObj.DataChiusura);
			DbProvider.SetCmdParam(cmd, firstChar + "OraChiusura", RichiestaProfilazioneObj.OraChiusura);
			DbProvider.SetCmdParam(cmd, firstChar + "Decreto", RichiestaProfilazioneObj.Decreto);
			DbProvider.SetCmdParam(cmd, firstChar + "FascicoloPaleo", RichiestaProfilazioneObj.FascicoloPaleo);
			DbProvider.SetCmdParam(cmd, firstChar + "Graduatoria", RichiestaProfilazioneObj.Graduatoria);
			DbProvider.SetCmdParam(cmd, firstChar + "Sportello", RichiestaProfilazioneObj.Sportello);
			DbProvider.SetCmdParam(cmd, firstChar + "StrumentiFinanziari", RichiestaProfilazioneObj.StrumentiFinanziari);
			DbProvider.SetCmdParam(cmd, firstChar + "FinanziabilitaParziale", RichiestaProfilazioneObj.FinanziabilitaParziale);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoProcedura", RichiestaProfilazioneObj.TipoProcedura);
			DbProvider.SetCmdParam(cmd, firstChar + "MarcaDaBollo", RichiestaProfilazioneObj.MarcaDaBollo);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoAggregazione", RichiestaProfilazioneObj.TipoAggregazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Capofila", RichiestaProfilazioneObj.Capofila);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoBenificiario", RichiestaProfilazioneObj.TipoBenificiario);
			DbProvider.SetCmdParam(cmd, firstChar + "Ateco", RichiestaProfilazioneObj.Ateco);
			DbProvider.SetCmdParam(cmd, firstChar + "NumeroDomande", RichiestaProfilazioneObj.NumeroDomande);
			DbProvider.SetCmdParam(cmd, firstChar + "DeMinimis", RichiestaProfilazioneObj.DeMinimis);
			DbProvider.SetCmdParam(cmd, firstChar + "ContributoUe", RichiestaProfilazioneObj.ContributoUe);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoPiano", RichiestaProfilazioneObj.TipoPiano);
			DbProvider.SetCmdParam(cmd, firstChar + "DataAmmissibilita", RichiestaProfilazioneObj.DataAmmissibilita);
			DbProvider.SetCmdParam(cmd, firstChar + "CostoMin", RichiestaProfilazioneObj.CostoMin);
			DbProvider.SetCmdParam(cmd, firstChar + "CostoMax", RichiestaProfilazioneObj.CostoMax);
			DbProvider.SetCmdParam(cmd, firstChar + "Comitato", RichiestaProfilazioneObj.Comitato);
			DbProvider.SetCmdParam(cmd, firstChar + "PunteggioMin", RichiestaProfilazioneObj.PunteggioMin);
			DbProvider.SetCmdParam(cmd, firstChar + "Allegati", RichiestaProfilazioneObj.Allegati);
			DbProvider.SetCmdParam(cmd, firstChar + "Dichiarazioni", RichiestaProfilazioneObj.Dichiarazioni);
			DbProvider.SetCmdParam(cmd, firstChar + "DichiarazioniOpz", RichiestaProfilazioneObj.DichiarazioniOpz);
			DbProvider.SetCmdParam(cmd, firstChar + "CupBeni", RichiestaProfilazioneObj.CupBeni);
			DbProvider.SetCmdParam(cmd, firstChar + "CupServizi", RichiestaProfilazioneObj.CupServizi);
			DbProvider.SetCmdParam(cmd, firstChar + "CupLavPub", RichiestaProfilazioneObj.CupLavPub);
			DbProvider.SetCmdParam(cmd, firstChar + "CupContr", RichiestaProfilazioneObj.CupContr);
			DbProvider.SetCmdParam(cmd, firstChar + "CupProd", RichiestaProfilazioneObj.CupProd);
			DbProvider.SetCmdParam(cmd, firstChar + "CupCap", RichiestaProfilazioneObj.CupCap);
		}
		//Insert
		private static int Insert(DbProvider db, RichiestaProfilazione RichiestaProfilazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZRichiestaProfilazioneInsert", new string[] {"Operatore", "Definitiva",
"LasteditDatetim", "Approvata", "DataApprovazione",
"OperatoreApprovazione", "MotivazioneRifiuto", "DataArrivo",
"Segnatura", "Pf", "Servizio",
"Pec", "FondiFesr", "Asse",
"Azione", "ParereAdg", "Multiazione",
"Perc10", "Oggetto", "Importo",
"Rup", "RupTelefono", "RupEmail",
"DataApertura", "OraApertura", "DataChiusura",
"OraChiusura", "Decreto", "FascicoloPaleo",
"Graduatoria", "Sportello", "StrumentiFinanziari",
"FinanziabilitaParziale", "TipoProcedura", "MarcaDaBollo",
"TipoAggregazione", "Capofila", "TipoBenificiario",
"Ateco", "NumeroDomande", "DeMinimis",
"ContributoUe", "TipoPiano", "DataAmmissibilita",
"CostoMin", "CostoMax", "Comitato",
"PunteggioMin", "Allegati", "Dichiarazioni",
"DichiarazioniOpz", "CupBeni", "CupServizi",
"CupLavPub", "CupContr", "CupProd",
"CupCap"}, new string[] {"int", "bool",
"DateTime", "bool", "DateTime",
"int", "string", "DateTime",
"string", "string", "string",
"string", "bool", "string",
"string", "string", "bool",
"bool", "string", "decimal",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "string", "string",
"bool", "bool", "bool",
"bool", "string", "bool",
"string", "bool", "string",
"string", "bool", "bool",
"bool", "string", "string",
"decimal", "decimal", "bool",
"string", "string", "string",
"string", "bool", "bool",
"bool", "bool", "bool",
"bool"}, "");
				CompileIUCmd(false, insertCmd, RichiestaProfilazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					RichiestaProfilazioneObj.IdRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA"]);
				}
				RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaProfilazioneObj.IsDirty = false;
				RichiestaProfilazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RichiestaProfilazione RichiestaProfilazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZRichiestaProfilazioneUpdate", new string[] {"IdRichiesta", "Operatore", "Definitiva",
"LasteditDatetim", "Approvata", "DataApprovazione",
"OperatoreApprovazione", "MotivazioneRifiuto", "DataArrivo",
"Segnatura", "Pf", "Servizio",
"Pec", "FondiFesr", "Asse",
"Azione", "ParereAdg", "Multiazione",
"Perc10", "Oggetto", "Importo",
"Rup", "RupTelefono", "RupEmail",
"DataApertura", "OraApertura", "DataChiusura",
"OraChiusura", "Decreto", "FascicoloPaleo",
"Graduatoria", "Sportello", "StrumentiFinanziari",
"FinanziabilitaParziale", "TipoProcedura", "MarcaDaBollo",
"TipoAggregazione", "Capofila", "TipoBenificiario",
"Ateco", "NumeroDomande", "DeMinimis",
"ContributoUe", "TipoPiano", "DataAmmissibilita",
"CostoMin", "CostoMax", "Comitato",
"PunteggioMin", "Allegati", "Dichiarazioni",
"DichiarazioniOpz", "CupBeni", "CupServizi",
"CupLavPub", "CupContr", "CupProd",
"CupCap"}, new string[] {"int", "int", "bool",
"DateTime", "bool", "DateTime",
"int", "string", "DateTime",
"string", "string", "string",
"string", "bool", "string",
"string", "string", "bool",
"bool", "string", "decimal",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "string", "string",
"bool", "bool", "bool",
"bool", "string", "bool",
"string", "bool", "string",
"string", "bool", "bool",
"bool", "string", "string",
"decimal", "decimal", "bool",
"string", "string", "string",
"string", "bool", "bool",
"bool", "bool", "bool",
"bool"}, "");
				CompileIUCmd(true, updateCmd, RichiestaProfilazioneObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaProfilazioneObj.IsDirty = false;
				RichiestaProfilazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RichiestaProfilazione RichiestaProfilazioneObj)
		{
			switch (RichiestaProfilazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, RichiestaProfilazioneObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, RichiestaProfilazioneObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, RichiestaProfilazioneObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RichiestaProfilazioneCollection RichiestaProfilazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZRichiestaProfilazioneUpdate", new string[] {"IdRichiesta", "Operatore", "Definitiva",
"LasteditDatetim", "Approvata", "DataApprovazione",
"OperatoreApprovazione", "MotivazioneRifiuto", "DataArrivo",
"Segnatura", "Pf", "Servizio",
"Pec", "FondiFesr", "Asse",
"Azione", "ParereAdg", "Multiazione",
"Perc10", "Oggetto", "Importo",
"Rup", "RupTelefono", "RupEmail",
"DataApertura", "OraApertura", "DataChiusura",
"OraChiusura", "Decreto", "FascicoloPaleo",
"Graduatoria", "Sportello", "StrumentiFinanziari",
"FinanziabilitaParziale", "TipoProcedura", "MarcaDaBollo",
"TipoAggregazione", "Capofila", "TipoBenificiario",
"Ateco", "NumeroDomande", "DeMinimis",
"ContributoUe", "TipoPiano", "DataAmmissibilita",
"CostoMin", "CostoMax", "Comitato",
"PunteggioMin", "Allegati", "Dichiarazioni",
"DichiarazioniOpz", "CupBeni", "CupServizi",
"CupLavPub", "CupContr", "CupProd",
"CupCap"}, new string[] {"int", "int", "bool",
"DateTime", "bool", "DateTime",
"int", "string", "DateTime",
"string", "string", "string",
"string", "bool", "string",
"string", "string", "bool",
"bool", "string", "decimal",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "string", "string",
"bool", "bool", "bool",
"bool", "string", "bool",
"string", "bool", "string",
"string", "bool", "bool",
"bool", "string", "string",
"decimal", "decimal", "bool",
"string", "string", "string",
"string", "bool", "bool",
"bool", "bool", "bool",
"bool"}, "");
				IDbCommand insertCmd = db.InitCmd("ZRichiestaProfilazioneInsert", new string[] {"Operatore", "Definitiva",
"LasteditDatetim", "Approvata", "DataApprovazione",
"OperatoreApprovazione", "MotivazioneRifiuto", "DataArrivo",
"Segnatura", "Pf", "Servizio",
"Pec", "FondiFesr", "Asse",
"Azione", "ParereAdg", "Multiazione",
"Perc10", "Oggetto", "Importo",
"Rup", "RupTelefono", "RupEmail",
"DataApertura", "OraApertura", "DataChiusura",
"OraChiusura", "Decreto", "FascicoloPaleo",
"Graduatoria", "Sportello", "StrumentiFinanziari",
"FinanziabilitaParziale", "TipoProcedura", "MarcaDaBollo",
"TipoAggregazione", "Capofila", "TipoBenificiario",
"Ateco", "NumeroDomande", "DeMinimis",
"ContributoUe", "TipoPiano", "DataAmmissibilita",
"CostoMin", "CostoMax", "Comitato",
"PunteggioMin", "Allegati", "Dichiarazioni",
"DichiarazioniOpz", "CupBeni", "CupServizi",
"CupLavPub", "CupContr", "CupProd",
"CupCap"}, new string[] {"int", "bool",
"DateTime", "bool", "DateTime",
"int", "string", "DateTime",
"string", "string", "string",
"string", "bool", "string",
"string", "string", "bool",
"bool", "string", "decimal",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "string", "string",
"bool", "bool", "bool",
"bool", "string", "bool",
"string", "bool", "string",
"string", "bool", "bool",
"bool", "string", "string",
"decimal", "decimal", "bool",
"string", "string", "string",
"string", "bool", "bool",
"bool", "bool", "bool",
"bool"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZRichiestaProfilazioneDelete", new string[] { "IdRichiesta" }, new string[] { "int" }, "");
				for (int i = 0; i < RichiestaProfilazioneCollectionObj.Count; i++)
				{
					switch (RichiestaProfilazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, RichiestaProfilazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RichiestaProfilazioneCollectionObj[i].IdRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, RichiestaProfilazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (RichiestaProfilazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRichiesta", (SiarLibrary.NullTypes.IntNT)RichiestaProfilazioneCollectionObj[i].IdRichiesta);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RichiestaProfilazioneCollectionObj.Count; i++)
				{
					if ((RichiestaProfilazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaProfilazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaProfilazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RichiestaProfilazioneCollectionObj[i].IsDirty = false;
						RichiestaProfilazioneCollectionObj[i].IsPersistent = true;
					}
					if ((RichiestaProfilazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RichiestaProfilazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaProfilazioneCollectionObj[i].IsDirty = false;
						RichiestaProfilazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RichiestaProfilazione RichiestaProfilazioneObj)
		{
			int returnValue = 0;
			if (RichiestaProfilazioneObj.IsPersistent)
			{
				returnValue = Delete(db, RichiestaProfilazioneObj.IdRichiesta);
			}
			RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RichiestaProfilazioneObj.IsDirty = false;
			RichiestaProfilazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRichiestaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZRichiestaProfilazioneDelete", new string[] { "IdRichiesta" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRichiesta", (SiarLibrary.NullTypes.IntNT)IdRichiestaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RichiestaProfilazioneCollection RichiestaProfilazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZRichiestaProfilazioneDelete", new string[] { "IdRichiesta" }, new string[] { "int" }, "");
				for (int i = 0; i < RichiestaProfilazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRichiesta", RichiestaProfilazioneCollectionObj[i].IdRichiesta);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RichiestaProfilazioneCollectionObj.Count; i++)
				{
					if ((RichiestaProfilazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaProfilazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaProfilazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaProfilazioneCollectionObj[i].IsDirty = false;
						RichiestaProfilazioneCollectionObj[i].IsPersistent = false;
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
		public static RichiestaProfilazione GetById(DbProvider db, int IdRichiestaValue)
		{
			RichiestaProfilazione RichiestaProfilazioneObj = null;
			IDbCommand readCmd = db.InitCmd("ZRichiestaProfilazioneGetById", new string[] { "IdRichiesta" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdRichiesta", (SiarLibrary.NullTypes.IntNT)IdRichiestaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RichiestaProfilazioneObj = GetFromDatareader(db);
				RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaProfilazioneObj.IsDirty = false;
				RichiestaProfilazioneObj.IsPersistent = true;
			}
			db.Close();
			return RichiestaProfilazioneObj;
		}

		//getFromDatareader
		public static RichiestaProfilazione GetFromDatareader(DbProvider db)
		{
			RichiestaProfilazione RichiestaProfilazioneObj = new RichiestaProfilazione();
			RichiestaProfilazioneObj.IdRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA"]);
			RichiestaProfilazioneObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			RichiestaProfilazioneObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			RichiestaProfilazioneObj.LasteditDatetim = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["LASTEDIT_DATETIM"]);
			RichiestaProfilazioneObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			RichiestaProfilazioneObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
			RichiestaProfilazioneObj.OperatoreApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_APPROVAZIONE"]);
			RichiestaProfilazioneObj.MotivazioneRifiuto = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE_RIFIUTO"]);
			RichiestaProfilazioneObj.DataArrivo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ARRIVO"]);
			RichiestaProfilazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			RichiestaProfilazioneObj.Pf = new SiarLibrary.NullTypes.StringNT(db.DataReader["PF"]);
			RichiestaProfilazioneObj.Servizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SERVIZIO"]);
			RichiestaProfilazioneObj.Pec = new SiarLibrary.NullTypes.StringNT(db.DataReader["PEC"]);
			RichiestaProfilazioneObj.FondiFesr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FONDI_FESR"]);
			RichiestaProfilazioneObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ASSE"]);
			RichiestaProfilazioneObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE"]);
			RichiestaProfilazioneObj.ParereAdg = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARERE_ADG"]);
			RichiestaProfilazioneObj.Multiazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIAZIONE"]);
			RichiestaProfilazioneObj.Perc10 = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PERC10"]);
			RichiestaProfilazioneObj.Oggetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["OGGETTO"]);
			RichiestaProfilazioneObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			RichiestaProfilazioneObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
			RichiestaProfilazioneObj.RupTelefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP_TELEFONO"]);
			RichiestaProfilazioneObj.RupEmail = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP_EMAIL"]);
			RichiestaProfilazioneObj.DataApertura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA"]);
			RichiestaProfilazioneObj.OraApertura = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORA_APERTURA"]);
			RichiestaProfilazioneObj.DataChiusura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CHIUSURA"]);
			RichiestaProfilazioneObj.OraChiusura = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORA_CHIUSURA"]);
			RichiestaProfilazioneObj.Decreto = new SiarLibrary.NullTypes.StringNT(db.DataReader["DECRETO"]);
			RichiestaProfilazioneObj.FascicoloPaleo = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASCICOLO_PALEO"]);
			RichiestaProfilazioneObj.Graduatoria = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GRADUATORIA"]);
			RichiestaProfilazioneObj.Sportello = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPORTELLO"]);
			RichiestaProfilazioneObj.StrumentiFinanziari = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STRUMENTI_FINANZIARI"]);
			RichiestaProfilazioneObj.FinanziabilitaParziale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FINANZIABILITA_PARZIALE"]);
			RichiestaProfilazioneObj.TipoProcedura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_PROCEDURA"]);
			RichiestaProfilazioneObj.MarcaDaBollo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MARCA_DA_BOLLO"]);
			RichiestaProfilazioneObj.TipoAggregazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_AGGREGAZIONE"]);
			RichiestaProfilazioneObj.Capofila = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CAPOFILA"]);
			RichiestaProfilazioneObj.TipoBenificiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_BENIFICIARIO"]);
			RichiestaProfilazioneObj.Ateco = new SiarLibrary.NullTypes.StringNT(db.DataReader["ATECO"]);
			RichiestaProfilazioneObj.NumeroDomande = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NUMERO_DOMANDE"]);
			RichiestaProfilazioneObj.DeMinimis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DE_MINIMIS"]);
			RichiestaProfilazioneObj.ContributoUe = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTRIBUTO_UE"]);
			RichiestaProfilazioneObj.TipoPiano = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_PIANO"]);
			RichiestaProfilazioneObj.DataAmmissibilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["DATA_AMMISSIBILITA"]);
			RichiestaProfilazioneObj.CostoMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_MIN"]);
			RichiestaProfilazioneObj.CostoMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_MAX"]);
			RichiestaProfilazioneObj.Comitato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["COMITATO"]);
			RichiestaProfilazioneObj.PunteggioMin = new SiarLibrary.NullTypes.StringNT(db.DataReader["PUNTEGGIO_MIN"]);
			RichiestaProfilazioneObj.Allegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["ALLEGATI"]);
			RichiestaProfilazioneObj.Dichiarazioni = new SiarLibrary.NullTypes.StringNT(db.DataReader["DICHIARAZIONI"]);
			RichiestaProfilazioneObj.DichiarazioniOpz = new SiarLibrary.NullTypes.StringNT(db.DataReader["DICHIARAZIONI_OPZ"]);
			RichiestaProfilazioneObj.CupBeni = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_BENI"]);
			RichiestaProfilazioneObj.CupServizi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_SERVIZI"]);
			RichiestaProfilazioneObj.CupLavPub = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_LAV_PUB"]);
			RichiestaProfilazioneObj.CupContr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_CONTR"]);
			RichiestaProfilazioneObj.CupProd = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_PROD"]);
			RichiestaProfilazioneObj.CupCap = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CUP_CAP"]);
			RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RichiestaProfilazioneObj.IsDirty = false;
			RichiestaProfilazioneObj.IsPersistent = true;
			return RichiestaProfilazioneObj;
		}

		//Find Select

		public static RichiestaProfilazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis,
SiarLibrary.NullTypes.DatetimeNT LasteditDatetimEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT MotivazioneRifiutoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataArrivoEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT PfEqualThis, SiarLibrary.NullTypes.StringNT ServizioEqualThis,
SiarLibrary.NullTypes.StringNT PecEqualThis, SiarLibrary.NullTypes.BoolNT FondiFesrEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis,
SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.StringNT ParereAdgEqualThis, SiarLibrary.NullTypes.BoolNT MultiazioneEqualThis,
SiarLibrary.NullTypes.BoolNT Perc10EqualThis, SiarLibrary.NullTypes.StringNT OggettoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.StringNT RupEqualThis, SiarLibrary.NullTypes.StringNT RupTelefonoEqualThis, SiarLibrary.NullTypes.StringNT RupEmailEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAperturaEqualThis, SiarLibrary.NullTypes.StringNT OraAperturaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataChiusuraEqualThis,
SiarLibrary.NullTypes.StringNT OraChiusuraEqualThis, SiarLibrary.NullTypes.StringNT DecretoEqualThis, SiarLibrary.NullTypes.StringNT FascicoloPaleoEqualThis,
SiarLibrary.NullTypes.BoolNT GraduatoriaEqualThis, SiarLibrary.NullTypes.BoolNT SportelloEqualThis, SiarLibrary.NullTypes.BoolNT StrumentiFinanziariEqualThis,
SiarLibrary.NullTypes.BoolNT FinanziabilitaParzialeEqualThis, SiarLibrary.NullTypes.StringNT TipoProceduraEqualThis, SiarLibrary.NullTypes.BoolNT MarcaDaBolloEqualThis,
SiarLibrary.NullTypes.StringNT TipoAggregazioneEqualThis, SiarLibrary.NullTypes.BoolNT CapofilaEqualThis, SiarLibrary.NullTypes.StringNT TipoBenificiarioEqualThis,
SiarLibrary.NullTypes.StringNT AtecoEqualThis, SiarLibrary.NullTypes.BoolNT NumeroDomandeEqualThis, SiarLibrary.NullTypes.BoolNT DeMinimisEqualThis,
SiarLibrary.NullTypes.BoolNT ContributoUeEqualThis, SiarLibrary.NullTypes.StringNT TipoPianoEqualThis, SiarLibrary.NullTypes.StringNT DataAmmissibilitaEqualThis,
SiarLibrary.NullTypes.DecimalNT CostoMinEqualThis, SiarLibrary.NullTypes.DecimalNT CostoMaxEqualThis, SiarLibrary.NullTypes.BoolNT ComitatoEqualThis,
SiarLibrary.NullTypes.StringNT PunteggioMinEqualThis, SiarLibrary.NullTypes.StringNT AllegatiEqualThis, SiarLibrary.NullTypes.StringNT DichiarazioniEqualThis,
SiarLibrary.NullTypes.StringNT DichiarazioniOpzEqualThis, SiarLibrary.NullTypes.BoolNT CupBeniEqualThis, SiarLibrary.NullTypes.BoolNT CupServiziEqualThis,
SiarLibrary.NullTypes.BoolNT CupLavPubEqualThis, SiarLibrary.NullTypes.BoolNT CupContrEqualThis, SiarLibrary.NullTypes.BoolNT CupProdEqualThis,
SiarLibrary.NullTypes.BoolNT CupCapEqualThis)

		{

			RichiestaProfilazioneCollection RichiestaProfilazioneCollectionObj = new RichiestaProfilazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaprofilazionefindselect", new string[] {"IdRichiestaequalthis", "Operatoreequalthis", "Definitivaequalthis",
"LasteditDatetimequalthis", "Approvataequalthis", "DataApprovazioneequalthis",
"OperatoreApprovazioneequalthis", "MotivazioneRifiutoequalthis", "DataArrivoequalthis",
"Segnaturaequalthis", "Pfequalthis", "Servizioequalthis",
"Pecequalthis", "FondiFesrequalthis", "Asseequalthis",
"Azioneequalthis", "ParereAdgequalthis", "Multiazioneequalthis",
"Perc10equalthis", "Oggettoequalthis", "Importoequalthis",
"Rupequalthis", "RupTelefonoequalthis", "RupEmailequalthis",
"DataAperturaequalthis", "OraAperturaequalthis", "DataChiusuraequalthis",
"OraChiusuraequalthis", "Decretoequalthis", "FascicoloPaleoequalthis",
"Graduatoriaequalthis", "Sportelloequalthis", "StrumentiFinanziariequalthis",
"FinanziabilitaParzialeequalthis", "TipoProceduraequalthis", "MarcaDaBolloequalthis",
"TipoAggregazioneequalthis", "Capofilaequalthis", "TipoBenificiarioequalthis",
"Atecoequalthis", "NumeroDomandeequalthis", "DeMinimisequalthis",
"ContributoUeequalthis", "TipoPianoequalthis", "DataAmmissibilitaequalthis",
"CostoMinequalthis", "CostoMaxequalthis", "Comitatoequalthis",
"PunteggioMinequalthis", "Allegatiequalthis", "Dichiarazioniequalthis",
"DichiarazioniOpzequalthis", "CupBeniequalthis", "CupServiziequalthis",
"CupLavPubequalthis", "CupContrequalthis", "CupProdequalthis",
"CupCapequalthis"}, new string[] {"int", "int", "bool",
"DateTime", "bool", "DateTime",
"int", "string", "DateTime",
"string", "string", "string",
"string", "bool", "string",
"string", "string", "bool",
"bool", "string", "decimal",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "string", "string",
"bool", "bool", "bool",
"bool", "string", "bool",
"string", "bool", "string",
"string", "bool", "bool",
"bool", "string", "string",
"decimal", "decimal", "bool",
"string", "string", "string",
"string", "bool", "bool",
"bool", "bool", "bool",
"bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LasteditDatetimequalthis", LasteditDatetimEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreApprovazioneequalthis", OperatoreApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MotivazioneRifiutoequalthis", MotivazioneRifiutoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataArrivoequalthis", DataArrivoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pfequalthis", PfEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Servizioequalthis", ServizioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Pecequalthis", PecEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FondiFesrequalthis", FondiFesrEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ParereAdgequalthis", ParereAdgEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multiazioneequalthis", MultiazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Perc10equalthis", Perc10EqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Oggettoequalthis", OggettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RupTelefonoequalthis", RupTelefonoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RupEmailequalthis", RupEmailEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAperturaequalthis", DataAperturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OraAperturaequalthis", OraAperturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataChiusuraequalthis", DataChiusuraEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OraChiusuraequalthis", OraChiusuraEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Decretoequalthis", DecretoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FascicoloPaleoequalthis", FascicoloPaleoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Graduatoriaequalthis", GraduatoriaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Sportelloequalthis", SportelloEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StrumentiFinanziariequalthis", StrumentiFinanziariEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FinanziabilitaParzialeequalthis", FinanziabilitaParzialeEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoProceduraequalthis", TipoProceduraEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "MarcaDaBolloequalthis", MarcaDaBolloEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoAggregazioneequalthis", TipoAggregazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Capofilaequalthis", CapofilaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoBenificiarioequalthis", TipoBenificiarioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Atecoequalthis", AtecoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroDomandeequalthis", NumeroDomandeEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DeMinimisequalthis", DeMinimisEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoUeequalthis", ContributoUeEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoPianoequalthis", TipoPianoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAmmissibilitaequalthis", DataAmmissibilitaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CostoMinequalthis", CostoMinEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CostoMaxequalthis", CostoMaxEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Comitatoequalthis", ComitatoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PunteggioMinequalthis", PunteggioMinEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Allegatiequalthis", AllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dichiarazioniequalthis", DichiarazioniEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DichiarazioniOpzequalthis", DichiarazioniOpzEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupBeniequalthis", CupBeniEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupServiziequalthis", CupServiziEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupLavPubequalthis", CupLavPubEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupContrequalthis", CupContrEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupProdequalthis", CupProdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CupCapequalthis", CupCapEqualThis);
			RichiestaProfilazione RichiestaProfilazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaProfilazioneObj = GetFromDatareader(db);
				RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaProfilazioneObj.IsDirty = false;
				RichiestaProfilazioneObj.IsPersistent = true;
				RichiestaProfilazioneCollectionObj.Add(RichiestaProfilazioneObj);
			}
			db.Close();
			return RichiestaProfilazioneCollectionObj;
		}

		//Find Find

		public static RichiestaProfilazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis)

		{

			RichiestaProfilazioneCollection RichiestaProfilazioneCollectionObj = new RichiestaProfilazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaprofilazionefindfind", new string[] { "Operatoreequalthis", "Definitivaequalthis", "Approvataequalthis" }, new string[] { "int", "bool", "bool" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			RichiestaProfilazione RichiestaProfilazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaProfilazioneObj = GetFromDatareader(db);
				RichiestaProfilazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaProfilazioneObj.IsDirty = false;
				RichiestaProfilazioneObj.IsPersistent = true;
				RichiestaProfilazioneCollectionObj.Add(RichiestaProfilazioneObj);
			}
			db.Close();
			return RichiestaProfilazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RichiestaProfilazioneCollectionProvider:IRichiestaProfilazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaProfilazioneCollectionProvider : IRichiestaProfilazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RichiestaProfilazione
		protected RichiestaProfilazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RichiestaProfilazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RichiestaProfilazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public RichiestaProfilazioneCollectionProvider(IntNT OperatoreEqualThis, BoolNT DefinitivaEqualThis, BoolNT ApprovataEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(OperatoreEqualThis, DefinitivaEqualThis, ApprovataEqualThis);
		}

		//Costruttore3: ha in input richiestaprofilazioneCollectionObj - non popola la collection
		public RichiestaProfilazioneCollectionProvider(RichiestaProfilazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RichiestaProfilazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RichiestaProfilazioneCollection(this);
		}

		//Get e Set
		public RichiestaProfilazioneCollection CollectionObj
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
		public int SaveCollection(RichiestaProfilazioneCollection collectionObj)
		{
			return RichiestaProfilazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RichiestaProfilazione richiestaprofilazioneObj)
		{
			return RichiestaProfilazioneDAL.Save(_dbProviderObj, richiestaprofilazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RichiestaProfilazioneCollection collectionObj)
		{
			return RichiestaProfilazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RichiestaProfilazione richiestaprofilazioneObj)
		{
			return RichiestaProfilazioneDAL.Delete(_dbProviderObj, richiestaprofilazioneObj);
		}

		//getById
		public RichiestaProfilazione GetById(IntNT IdRichiestaValue)
		{
			RichiestaProfilazione RichiestaProfilazioneTemp = RichiestaProfilazioneDAL.GetById(_dbProviderObj, IdRichiestaValue);
			if (RichiestaProfilazioneTemp != null) RichiestaProfilazioneTemp.Provider = this;
			return RichiestaProfilazioneTemp;
		}

		//Select: popola la collection
		public RichiestaProfilazioneCollection Select(IntNT IdrichiestaEqualThis, IntNT OperatoreEqualThis, BoolNT DefinitivaEqualThis,
DatetimeNT LasteditdatetimEqualThis, BoolNT ApprovataEqualThis, DatetimeNT DataapprovazioneEqualThis,
IntNT OperatoreapprovazioneEqualThis, StringNT MotivazionerifiutoEqualThis, DatetimeNT DataarrivoEqualThis,
StringNT SegnaturaEqualThis, StringNT PfEqualThis, StringNT ServizioEqualThis,
StringNT PecEqualThis, BoolNT FondifesrEqualThis, StringNT AsseEqualThis,
StringNT AzioneEqualThis, StringNT ParereadgEqualThis, BoolNT MultiazioneEqualThis,
BoolNT Perc10EqualThis, StringNT OggettoEqualThis, DecimalNT ImportoEqualThis,
StringNT RupEqualThis, StringNT RuptelefonoEqualThis, StringNT RupemailEqualThis,
DatetimeNT DataaperturaEqualThis, StringNT OraaperturaEqualThis, DatetimeNT DatachiusuraEqualThis,
StringNT OrachiusuraEqualThis, StringNT DecretoEqualThis, StringNT FascicolopaleoEqualThis,
BoolNT GraduatoriaEqualThis, BoolNT SportelloEqualThis, BoolNT StrumentifinanziariEqualThis,
BoolNT FinanziabilitaparzialeEqualThis, StringNT TipoproceduraEqualThis, BoolNT MarcadabolloEqualThis,
StringNT TipoaggregazioneEqualThis, BoolNT CapofilaEqualThis, StringNT TipobenificiarioEqualThis,
StringNT AtecoEqualThis, BoolNT NumerodomandeEqualThis, BoolNT DeminimisEqualThis,
BoolNT ContributoueEqualThis, StringNT TipopianoEqualThis, StringNT DataammissibilitaEqualThis,
DecimalNT CostominEqualThis, DecimalNT CostomaxEqualThis, BoolNT ComitatoEqualThis,
StringNT PunteggiominEqualThis, StringNT AllegatiEqualThis, StringNT DichiarazioniEqualThis,
StringNT DichiarazioniopzEqualThis, BoolNT CupbeniEqualThis, BoolNT CupserviziEqualThis,
BoolNT CuplavpubEqualThis, BoolNT CupcontrEqualThis, BoolNT CupprodEqualThis,
BoolNT CupcapEqualThis)
		{
			RichiestaProfilazioneCollection RichiestaProfilazioneCollectionTemp = RichiestaProfilazioneDAL.Select(_dbProviderObj, IdrichiestaEqualThis, OperatoreEqualThis, DefinitivaEqualThis,
LasteditdatetimEqualThis, ApprovataEqualThis, DataapprovazioneEqualThis,
OperatoreapprovazioneEqualThis, MotivazionerifiutoEqualThis, DataarrivoEqualThis,
SegnaturaEqualThis, PfEqualThis, ServizioEqualThis,
PecEqualThis, FondifesrEqualThis, AsseEqualThis,
AzioneEqualThis, ParereadgEqualThis, MultiazioneEqualThis,
Perc10EqualThis, OggettoEqualThis, ImportoEqualThis,
RupEqualThis, RuptelefonoEqualThis, RupemailEqualThis,
DataaperturaEqualThis, OraaperturaEqualThis, DatachiusuraEqualThis,
OrachiusuraEqualThis, DecretoEqualThis, FascicolopaleoEqualThis,
GraduatoriaEqualThis, SportelloEqualThis, StrumentifinanziariEqualThis,
FinanziabilitaparzialeEqualThis, TipoproceduraEqualThis, MarcadabolloEqualThis,
TipoaggregazioneEqualThis, CapofilaEqualThis, TipobenificiarioEqualThis,
AtecoEqualThis, NumerodomandeEqualThis, DeminimisEqualThis,
ContributoueEqualThis, TipopianoEqualThis, DataammissibilitaEqualThis,
CostominEqualThis, CostomaxEqualThis, ComitatoEqualThis,
PunteggiominEqualThis, AllegatiEqualThis, DichiarazioniEqualThis,
DichiarazioniopzEqualThis, CupbeniEqualThis, CupserviziEqualThis,
CuplavpubEqualThis, CupcontrEqualThis, CupprodEqualThis,
CupcapEqualThis);
			RichiestaProfilazioneCollectionTemp.Provider = this;
			return RichiestaProfilazioneCollectionTemp;
		}

		//Find: popola la collection
		public RichiestaProfilazioneCollection Find(IntNT OperatoreEqualThis, BoolNT DefinitivaEqualThis, BoolNT ApprovataEqualThis)
		{
			RichiestaProfilazioneCollection RichiestaProfilazioneCollectionTemp = RichiestaProfilazioneDAL.Find(_dbProviderObj, OperatoreEqualThis, DefinitivaEqualThis, ApprovataEqualThis);
			RichiestaProfilazioneCollectionTemp.Provider = this;
			return RichiestaProfilazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICHIESTA_PROFILAZIONE>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY DATA_ARRIVO DESC">
      <OPERATORE>Equal</OPERATORE>
      <DEFINITIVA>Equal</DEFINITIVA>
      <APPROVATA>Equal</APPROVATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICHIESTA_PROFILAZIONE>
*/
