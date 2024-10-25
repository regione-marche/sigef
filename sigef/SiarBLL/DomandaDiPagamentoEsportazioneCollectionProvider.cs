using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DomandaDiPagamentoEsportazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaDiPagamentoEsportazioneProvider
	{
		int Save(DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj);
		int SaveCollection(DomandaDiPagamentoEsportazioneCollection collectionObj);
		int Delete(DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj);
		int DeleteCollection(DomandaDiPagamentoEsportazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaDiPagamentoEsportazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DomandaDiPagamentoEsportazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Barcode;
		private NullTypes.BoolNT _MisuraPrevalente;
		private NullTypes.DecimalNT _ImportoAmmissibile;
		private NullTypes.DecimalNT _ImportoSanzione;
		private NullTypes.DecimalNT _ImportoRecuperoAnticipo;
		private NullTypes.DecimalNT _ImportoAmmesso;
		private NullTypes.DecimalNT _ImportoLiquidato;
		private NullTypes.BoolNT _FlagLiquidato;
		private NullTypes.IntNT _IdDecreto;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _SegnaturaAllegati;
		private NullTypes.IntNT _IdFidejussione;
		private NullTypes.DatetimeNT _DataCertificazioneAntimafia;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.StringNT _SegnaturaApprovazione;
		private NullTypes.StringNT _SegnaturaSecondaApprovazione;
		private NullTypes.StringNT _CfIstruttore;
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
		[NonSerialized] private IDomandaDiPagamentoEsportazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaDiPagamentoEsportazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DomandaDiPagamentoEsportazione()
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
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
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
		/// Corrisponde al campo:BARCODE
		/// Tipo sul db:CHAR(11)
		/// </summary>
		public NullTypes.StringNT Barcode
		{
			get { return _Barcode; }
			set {
				if (Barcode != value)
				{
					_Barcode = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA_PREVALENTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MisuraPrevalente
		{
			get { return _MisuraPrevalente; }
			set {
				if (MisuraPrevalente != value)
				{
					_MisuraPrevalente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMISSIBILE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmissibile
		{
			get { return _ImportoAmmissibile; }
			set {
				if (ImportoAmmissibile != value)
				{
					_ImportoAmmissibile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_SANZIONE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoSanzione
		{
			get { return _ImportoSanzione; }
			set {
				if (ImportoSanzione != value)
				{
					_ImportoSanzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RECUPERO_ANTICIPO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRecuperoAnticipo
		{
			get { return _ImportoRecuperoAnticipo; }
			set {
				if (ImportoRecuperoAnticipo != value)
				{
					_ImportoRecuperoAnticipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmesso
		{
			get { return _ImportoAmmesso; }
			set {
				if (ImportoAmmesso != value)
				{
					_ImportoAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_LIQUIDATO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoLiquidato
		{
			get { return _ImportoLiquidato; }
			set {
				if (ImportoLiquidato != value)
				{
					_ImportoLiquidato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_LIQUIDATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagLiquidato
		{
			get { return _FlagLiquidato; }
			set {
				if (FlagLiquidato != value)
				{
					_FlagLiquidato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DECRETO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDecreto
		{
			get { return _IdDecreto; }
			set {
				if (IdDecreto != value)
				{
					_IdDecreto = value;
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
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
				if (SegnaturaSecondaApprovazione != value)
				{
					_SegnaturaSecondaApprovazione = value;
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
				if (InIntegrazione != value)
				{
					_InIntegrazione = value;
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
	/// Summary description for DomandaDiPagamentoEsportazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaDiPagamentoEsportazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DomandaDiPagamentoEsportazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DomandaDiPagamentoEsportazione) info.GetValue(i.ToString(),typeof(DomandaDiPagamentoEsportazione)));
			}
		}

		//Costruttore
		public DomandaDiPagamentoEsportazioneCollection()
		{
			this.ItemType = typeof(DomandaDiPagamentoEsportazione);
		}

		//Costruttore con provider
		public DomandaDiPagamentoEsportazioneCollection(IDomandaDiPagamentoEsportazioneProvider providerObj)
		{
			this.ItemType = typeof(DomandaDiPagamentoEsportazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaDiPagamentoEsportazione this[int index]
		{
			get { return (DomandaDiPagamentoEsportazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaDiPagamentoEsportazioneCollection GetChanges()
		{
			return (DomandaDiPagamentoEsportazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IDomandaDiPagamentoEsportazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaDiPagamentoEsportazioneProvider Provider
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
		public int Add(DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			if (DomandaDiPagamentoEsportazioneObj.Provider == null) DomandaDiPagamentoEsportazioneObj.Provider = this.Provider;
			return base.Add(DomandaDiPagamentoEsportazioneObj);
		}

		//AddCollection
		public void AddCollection(DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionObj)
		{
			foreach (DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj in DomandaDiPagamentoEsportazioneCollectionObj)
				this.Add(DomandaDiPagamentoEsportazioneObj);
		}

		//Insert
		public void Insert(int index, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			if (DomandaDiPagamentoEsportazioneObj.Provider == null) DomandaDiPagamentoEsportazioneObj.Provider = this.Provider;
			base.Insert(index, DomandaDiPagamentoEsportazioneObj);
		}

		//CollectionGetById
		public DomandaDiPagamentoEsportazione CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public DomandaDiPagamentoEsportazioneCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT BarcodeEqualThis, 
NullTypes.BoolNT MisuraPrevalenteEqualThis, NullTypes.DecimalNT ImportoAmmissibileEqualThis, NullTypes.DecimalNT ImportoSanzioneEqualThis, 
NullTypes.DecimalNT ImportoRecuperoAnticipoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ImportoLiquidatoEqualThis, 
NullTypes.BoolNT FlagLiquidatoEqualThis, NullTypes.IntNT IdDecretoEqualThis)
		{
			DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionTemp = new DomandaDiPagamentoEsportazioneCollection();
			foreach (DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneItem in this)
			{
				if (((IdDomandaPagamentoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.IdDomandaPagamento != null) && (DomandaDiPagamentoEsportazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.IdProgetto != null) && (DomandaDiPagamentoEsportazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((BarcodeEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.Barcode != null) && (DomandaDiPagamentoEsportazioneItem.Barcode.Value == BarcodeEqualThis.Value))) && 
((MisuraPrevalenteEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.MisuraPrevalente != null) && (DomandaDiPagamentoEsportazioneItem.MisuraPrevalente.Value == MisuraPrevalenteEqualThis.Value))) && ((ImportoAmmissibileEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.ImportoAmmissibile != null) && (DomandaDiPagamentoEsportazioneItem.ImportoAmmissibile.Value == ImportoAmmissibileEqualThis.Value))) && ((ImportoSanzioneEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.ImportoSanzione != null) && (DomandaDiPagamentoEsportazioneItem.ImportoSanzione.Value == ImportoSanzioneEqualThis.Value))) && 
((ImportoRecuperoAnticipoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.ImportoRecuperoAnticipo != null) && (DomandaDiPagamentoEsportazioneItem.ImportoRecuperoAnticipo.Value == ImportoRecuperoAnticipoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.ImportoAmmesso != null) && (DomandaDiPagamentoEsportazioneItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ImportoLiquidatoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.ImportoLiquidato != null) && (DomandaDiPagamentoEsportazioneItem.ImportoLiquidato.Value == ImportoLiquidatoEqualThis.Value))) && 
((FlagLiquidatoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.FlagLiquidato != null) && (DomandaDiPagamentoEsportazioneItem.FlagLiquidato.Value == FlagLiquidatoEqualThis.Value))) && ((IdDecretoEqualThis == null) || ((DomandaDiPagamentoEsportazioneItem.IdDecreto != null) && (DomandaDiPagamentoEsportazioneItem.IdDecreto.Value == IdDecretoEqualThis.Value))))
				{
					DomandaDiPagamentoEsportazioneCollectionTemp.Add(DomandaDiPagamentoEsportazioneItem);
				}
			}
			return DomandaDiPagamentoEsportazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaDiPagamentoEsportazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DomandaDiPagamentoEsportazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DomandaDiPagamentoEsportazioneObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", DomandaDiPagamentoEsportazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Barcode", DomandaDiPagamentoEsportazioneObj.Barcode);
			DbProvider.SetCmdParam(cmd,firstChar + "MisuraPrevalente", DomandaDiPagamentoEsportazioneObj.MisuraPrevalente);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoAmmissibile", DomandaDiPagamentoEsportazioneObj.ImportoAmmissibile);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoSanzione", DomandaDiPagamentoEsportazioneObj.ImportoSanzione);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoRecuperoAnticipo", DomandaDiPagamentoEsportazioneObj.ImportoRecuperoAnticipo);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoAmmesso", DomandaDiPagamentoEsportazioneObj.ImportoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoLiquidato", DomandaDiPagamentoEsportazioneObj.ImportoLiquidato);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagLiquidato", DomandaDiPagamentoEsportazioneObj.FlagLiquidato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecreto", DomandaDiPagamentoEsportazioneObj.IdDecreto);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", "Barcode", 
"MisuraPrevalente", "ImportoAmmissibile", "ImportoSanzione", 
"ImportoRecuperoAnticipo", "ImportoAmmesso", "ImportoLiquidato", 
"FlagLiquidato", "IdDecreto", 









}, new string[] {"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"bool", "int", 









},"");
				CompileIUCmd(false, insertCmd,DomandaDiPagamentoEsportazioneObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoEsportazioneObj.IsDirty = false;
				DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneUpdate", new string[] {"IdDomandaPagamento", "IdProgetto", "Barcode", 
"MisuraPrevalente", "ImportoAmmissibile", "ImportoSanzione", 
"ImportoRecuperoAnticipo", "ImportoAmmesso", "ImportoLiquidato", 
"FlagLiquidato", "IdDecreto", 









}, new string[] {"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"bool", "int", 









},"");
				CompileIUCmd(true, updateCmd,DomandaDiPagamentoEsportazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoEsportazioneObj.IsDirty = false;
				DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			switch (DomandaDiPagamentoEsportazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DomandaDiPagamentoEsportazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DomandaDiPagamentoEsportazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DomandaDiPagamentoEsportazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneUpdate", new string[] {"IdDomandaPagamento", "IdProgetto", "Barcode", 
"MisuraPrevalente", "ImportoAmmissibile", "ImportoSanzione", 
"ImportoRecuperoAnticipo", "ImportoAmmesso", "ImportoLiquidato", 
"FlagLiquidato", "IdDecreto", 









}, new string[] {"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"bool", "int", 









},"");
				IDbCommand insertCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", "Barcode", 
"MisuraPrevalente", "ImportoAmmissibile", "ImportoSanzione", 
"ImportoRecuperoAnticipo", "ImportoAmmesso", "ImportoLiquidato", 
"FlagLiquidato", "IdDecreto", 









}, new string[] {"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"bool", "int", 









},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneDelete", new string[] {"IdDomandaPagamento", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DomandaDiPagamentoEsportazioneCollectionObj.Count; i++)
				{
					switch (DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DomandaDiPagamentoEsportazioneCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DomandaDiPagamentoEsportazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DomandaDiPagamentoEsportazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)DomandaDiPagamentoEsportazioneCollectionObj[i].IdDomandaPagamento);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)DomandaDiPagamentoEsportazioneCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaDiPagamentoEsportazioneCollectionObj.Count; i++)
				{
					if ((DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj)
		{
			int returnValue = 0;
			if (DomandaDiPagamentoEsportazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, DomandaDiPagamentoEsportazioneObj.IdDomandaPagamento, DomandaDiPagamentoEsportazioneObj.IdProgetto);
			}
			DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaDiPagamentoEsportazioneObj.IsDirty = false;
			DomandaDiPagamentoEsportazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneDelete", new string[] {"IdDomandaPagamento", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneDelete", new string[] {"IdDomandaPagamento", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < DomandaDiPagamentoEsportazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", DomandaDiPagamentoEsportazioneCollectionObj[i].IdDomandaPagamento);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", DomandaDiPagamentoEsportazioneCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaDiPagamentoEsportazioneCollectionObj.Count; i++)
				{
					if ((DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaDiPagamentoEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsDirty = false;
						DomandaDiPagamentoEsportazioneCollectionObj[i].IsPersistent = false;
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
		public static DomandaDiPagamentoEsportazione GetById(DbProvider db, int IdDomandaPagamentoValue, int IdProgettoValue)
		{
			DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDomandaDiPagamentoEsportazioneGetById", new string[] {"IdDomandaPagamento", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaDiPagamentoEsportazioneObj = GetFromDatareader(db);
				DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoEsportazioneObj.IsDirty = false;
				DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
			}
			db.Close();
			return DomandaDiPagamentoEsportazioneObj;
		}

		//getFromDatareader
		public static DomandaDiPagamentoEsportazione GetFromDatareader(DbProvider db)
		{
			DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj = new DomandaDiPagamentoEsportazione();
			DomandaDiPagamentoEsportazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaDiPagamentoEsportazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DomandaDiPagamentoEsportazioneObj.Barcode = new SiarLibrary.NullTypes.StringNT(db.DataReader["BARCODE"]);
			DomandaDiPagamentoEsportazioneObj.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
			DomandaDiPagamentoEsportazioneObj.ImportoAmmissibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMISSIBILE"]);
			DomandaDiPagamentoEsportazioneObj.ImportoSanzione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SANZIONE"]);
			DomandaDiPagamentoEsportazioneObj.ImportoRecuperoAnticipo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERO_ANTICIPO"]);
			DomandaDiPagamentoEsportazioneObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			DomandaDiPagamentoEsportazioneObj.ImportoLiquidato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_LIQUIDATO"]);
			DomandaDiPagamentoEsportazioneObj.FlagLiquidato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_LIQUIDATO"]);
			DomandaDiPagamentoEsportazioneObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
			DomandaDiPagamentoEsportazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			DomandaDiPagamentoEsportazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			DomandaDiPagamentoEsportazioneObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			DomandaDiPagamentoEsportazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			DomandaDiPagamentoEsportazioneObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			DomandaDiPagamentoEsportazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			DomandaDiPagamentoEsportazioneObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
			DomandaDiPagamentoEsportazioneObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
			DomandaDiPagamentoEsportazioneObj.DataCertificazioneAntimafia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CERTIFICAZIONE_ANTIMAFIA"]);
			DomandaDiPagamentoEsportazioneObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			DomandaDiPagamentoEsportazioneObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
			DomandaDiPagamentoEsportazioneObj.SegnaturaSecondaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE"]);
			DomandaDiPagamentoEsportazioneObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
			DomandaDiPagamentoEsportazioneObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
			DomandaDiPagamentoEsportazioneObj.ValutazioneIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_ISTRUTTORE"]);
			DomandaDiPagamentoEsportazioneObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
			DomandaDiPagamentoEsportazioneObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
			DomandaDiPagamentoEsportazioneObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
			DomandaDiPagamentoEsportazioneObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
			DomandaDiPagamentoEsportazioneObj.ValiditaVersioneAdc = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALIDITA_VERSIONE_ADC"]);
			DomandaDiPagamentoEsportazioneObj.IdVariazioneAccertata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIAZIONE_ACCERTATA"]);
			DomandaDiPagamentoEsportazioneObj.PredispostaAControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_A_CONTROLLO"]);
			DomandaDiPagamentoEsportazioneObj.DataPredisposizioneAControllo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PREDISPOSIZIONE_A_CONTROLLO"]);
			DomandaDiPagamentoEsportazioneObj.VisitaInsituEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_ESITO"]);
			DomandaDiPagamentoEsportazioneObj.VisitaInsituNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["VISITA_INSITU_NOTE"]);
			DomandaDiPagamentoEsportazioneObj.ControlloInlocoEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_ESITO"]);
			DomandaDiPagamentoEsportazioneObj.ControlloInlocoNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_INLOCO_NOTE"]);
			DomandaDiPagamentoEsportazioneObj.VerificaPagamentiEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_ESITO"]);
			DomandaDiPagamentoEsportazioneObj.VerificaPagamentiMessaggio = new SiarLibrary.NullTypes.StringNT(db.DataReader["VERIFICA_PAGAMENTI_MESSAGGIO"]);
			DomandaDiPagamentoEsportazioneObj.VerificaPagamentiData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VERIFICA_PAGAMENTI_DATA"]);
			DomandaDiPagamentoEsportazioneObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
			DomandaDiPagamentoEsportazioneObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
			DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaDiPagamentoEsportazioneObj.IsDirty = false;
			DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
			return DomandaDiPagamentoEsportazioneObj;
		}

		//Find Select

		public static DomandaDiPagamentoEsportazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT BarcodeEqualThis, 
SiarLibrary.NullTypes.BoolNT MisuraPrevalenteEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmissibileEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSanzioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoRecuperoAnticipoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoLiquidatoEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagLiquidatoEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis)

		{

			DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionObj = new DomandaDiPagamentoEsportazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandadipagamentoesportazionefindselect", new string[] {"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "Barcodeequalthis", 
"MisuraPrevalenteequalthis", "ImportoAmmissibileequalthis", "ImportoSanzioneequalthis", 
"ImportoRecuperoAnticipoequalthis", "ImportoAmmessoequalthis", "ImportoLiquidatoequalthis", 
"FlagLiquidatoequalthis", "IdDecretoequalthis"}, new string[] {"int", "int", "string", 
"bool", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Barcodeequalthis", BarcodeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MisuraPrevalenteequalthis", MisuraPrevalenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmissibileequalthis", ImportoAmmissibileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoSanzioneequalthis", ImportoSanzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRecuperoAnticipoequalthis", ImportoRecuperoAnticipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoLiquidatoequalthis", ImportoLiquidatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagLiquidatoequalthis", FlagLiquidatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaDiPagamentoEsportazioneObj = GetFromDatareader(db);
				DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoEsportazioneObj.IsDirty = false;
				DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
				DomandaDiPagamentoEsportazioneCollectionObj.Add(DomandaDiPagamentoEsportazioneObj);
			}
			db.Close();
			return DomandaDiPagamentoEsportazioneCollectionObj;
		}

		//Find Find

		public static DomandaDiPagamentoEsportazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT BarcodeEqualThis)

		{

			DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionObj = new DomandaDiPagamentoEsportazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandadipagamentoesportazionefindfind", new string[] {"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "Barcodeequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Barcodeequalthis", BarcodeEqualThis);
			DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaDiPagamentoEsportazioneObj = GetFromDatareader(db);
				DomandaDiPagamentoEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaDiPagamentoEsportazioneObj.IsDirty = false;
				DomandaDiPagamentoEsportazioneObj.IsPersistent = true;
				DomandaDiPagamentoEsportazioneCollectionObj.Add(DomandaDiPagamentoEsportazioneObj);
			}
			db.Close();
			return DomandaDiPagamentoEsportazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaDiPagamentoEsportazioneCollectionProvider:IDomandaDiPagamentoEsportazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaDiPagamentoEsportazioneCollectionProvider : IDomandaDiPagamentoEsportazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaDiPagamentoEsportazione
		protected DomandaDiPagamentoEsportazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaDiPagamentoEsportazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaDiPagamentoEsportazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public DomandaDiPagamentoEsportazioneCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, StringNT BarcodeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, IdprogettoEqualThis, BarcodeEqualThis);
		}

		//Costruttore3: ha in input domandadipagamentoesportazioneCollectionObj - non popola la collection
		public DomandaDiPagamentoEsportazioneCollectionProvider(DomandaDiPagamentoEsportazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaDiPagamentoEsportazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaDiPagamentoEsportazioneCollection(this);
		}

		//Get e Set
		public DomandaDiPagamentoEsportazioneCollection CollectionObj
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
		public int SaveCollection(DomandaDiPagamentoEsportazioneCollection collectionObj)
		{
			return DomandaDiPagamentoEsportazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaDiPagamentoEsportazione domandadipagamentoesportazioneObj)
		{
			return DomandaDiPagamentoEsportazioneDAL.Save(_dbProviderObj, domandadipagamentoesportazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaDiPagamentoEsportazioneCollection collectionObj)
		{
			return DomandaDiPagamentoEsportazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaDiPagamentoEsportazione domandadipagamentoesportazioneObj)
		{
			return DomandaDiPagamentoEsportazioneDAL.Delete(_dbProviderObj, domandadipagamentoesportazioneObj);
		}

		//getById
		public DomandaDiPagamentoEsportazione GetById(IntNT IdDomandaPagamentoValue, IntNT IdProgettoValue)
		{
			DomandaDiPagamentoEsportazione DomandaDiPagamentoEsportazioneTemp = DomandaDiPagamentoEsportazioneDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue, IdProgettoValue);
			if (DomandaDiPagamentoEsportazioneTemp!=null) DomandaDiPagamentoEsportazioneTemp.Provider = this;
			return DomandaDiPagamentoEsportazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DomandaDiPagamentoEsportazioneCollection Select(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, StringNT BarcodeEqualThis, 
BoolNT MisuraprevalenteEqualThis, DecimalNT ImportoammissibileEqualThis, DecimalNT ImportosanzioneEqualThis, 
DecimalNT ImportorecuperoanticipoEqualThis, DecimalNT ImportoammessoEqualThis, DecimalNT ImportoliquidatoEqualThis, 
BoolNT FlagliquidatoEqualThis, IntNT IddecretoEqualThis)
		{
			DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionTemp = DomandaDiPagamentoEsportazioneDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis, BarcodeEqualThis, 
MisuraprevalenteEqualThis, ImportoammissibileEqualThis, ImportosanzioneEqualThis, 
ImportorecuperoanticipoEqualThis, ImportoammessoEqualThis, ImportoliquidatoEqualThis, 
FlagliquidatoEqualThis, IddecretoEqualThis);
			DomandaDiPagamentoEsportazioneCollectionTemp.Provider = this;
			return DomandaDiPagamentoEsportazioneCollectionTemp;
		}

		//Find: popola la collection
		public DomandaDiPagamentoEsportazioneCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, StringNT BarcodeEqualThis)
		{
			DomandaDiPagamentoEsportazioneCollection DomandaDiPagamentoEsportazioneCollectionTemp = DomandaDiPagamentoEsportazioneDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis, BarcodeEqualThis);
			DomandaDiPagamentoEsportazioneCollectionTemp.Provider = this;
			return DomandaDiPagamentoEsportazioneCollectionTemp;
		}


	}
}

/*
select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneInsert from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneInsert';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneInsert];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Barcode VARCHAR(255), 
	@MisuraPrevalente BIT, 
	@ImportoAmmissibile DECIMAL(18,2), 
	@ImportoSanzione DECIMAL(18,2), 
	@ImportoRecuperoAnticipo DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@ImportoLiquidato DECIMAL(18,2), 
	@FlagLiquidato BIT, 
	@IdDecreto INT
)
AS
	INSERT INTO DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		BARCODE, 
		MISURA_PREVALENTE, 
		IMPORTO_AMMISSIBILE, 
		IMPORTO_SANZIONE, 
		IMPORTO_RECUPERO_ANTICIPO, 
		IMPORTO_AMMESSO, 
		IMPORTO_LIQUIDATO, 
		FLAG_LIQUIDATO, 
		ID_DECRETO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Barcode, 
		@MisuraPrevalente, 
		@ImportoAmmissibile, 
		@ImportoSanzione, 
		@ImportoRecuperoAnticipo, 
		@ImportoAmmesso, 
		@ImportoLiquidato, 
		@FlagLiquidato, 
		@IdDecreto
	)

GO

declare @old_ZDomandaDiPagamentoEsportazioneInsert varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneInsert = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneInsert;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneInsert,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneInsert';
drop table ##old_ZDomandaDiPagamentoEsportazioneInsert
GO

select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneUpdate from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneUpdate';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneUpdate];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneUpdate]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Barcode VARCHAR(255), 
	@MisuraPrevalente BIT, 
	@ImportoAmmissibile DECIMAL(18,2), 
	@ImportoSanzione DECIMAL(18,2), 
	@ImportoRecuperoAnticipo DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@ImportoLiquidato DECIMAL(18,2), 
	@FlagLiquidato BIT, 
	@IdDecreto INT
)
AS
	UPDATE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	SET
		BARCODE = @Barcode, 
		MISURA_PREVALENTE = @MisuraPrevalente, 
		IMPORTO_AMMISSIBILE = @ImportoAmmissibile, 
		IMPORTO_SANZIONE = @ImportoSanzione, 
		IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipo, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		IMPORTO_LIQUIDATO = @ImportoLiquidato, 
		FLAG_LIQUIDATO = @FlagLiquidato, 
		ID_DECRETO = @IdDecreto
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)

GO

declare @old_ZDomandaDiPagamentoEsportazioneUpdate varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneUpdate = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneUpdate;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneUpdate,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneUpdate';
drop table ##old_ZDomandaDiPagamentoEsportazioneUpdate
GO

select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneDelete from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneDelete';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneDelete];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneDelete]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT
)
AS
	DELETE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)

GO

declare @old_ZDomandaDiPagamentoEsportazioneDelete varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneDelete = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneDelete;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneDelete,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneDelete';
drop table ##old_ZDomandaDiPagamentoEsportazioneDelete
GO

select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneGetById from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneGetById';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneGetById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneGetById];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneGetById]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT
)
AS
	SELECT *
	FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)

GO

declare @old_ZDomandaDiPagamentoEsportazioneGetById varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneGetById = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneGetById;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneGetById,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneGetById';
drop table ##old_ZDomandaDiPagamentoEsportazioneGetById
GO





select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneFindSelect from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneFindSelect';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneFindSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneFindSelect];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Barcodeequalthis VARCHAR(255), 
	@MisuraPrevalenteequalthis BIT, 
	@ImportoAmmissibileequalthis DECIMAL(18,2), 
	@ImportoSanzioneequalthis DECIMAL(18,2), 
	@ImportoRecuperoAnticipoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ImportoLiquidatoequalthis DECIMAL(18,2), 
	@FlagLiquidatoequalthis BIT, 
	@IdDecretoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE = @Barcodeequalthis)'; set @lensql=@lensql+len(@Barcodeequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)'; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	IF (@ImportoAmmissibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMISSIBILE = @ImportoAmmissibileequalthis)'; set @lensql=@lensql+len(@ImportoAmmissibileequalthis);end;
	IF (@ImportoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SANZIONE = @ImportoSanzioneequalthis)'; set @lensql=@lensql+len(@ImportoSanzioneequalthis);end;
	IF (@ImportoRecuperoAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperoAnticipoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ImportoLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_LIQUIDATO = @ImportoLiquidatoequalthis)'; set @lensql=@lensql+len(@ImportoLiquidatoequalthis);end;
	IF (@FlagLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_LIQUIDATO = @FlagLiquidatoequalthis)'; set @lensql=@lensql+len(@FlagLiquidatoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Barcodeequalthis VARCHAR(255), @MisuraPrevalenteequalthis BIT, @ImportoAmmissibileequalthis DECIMAL(18,2), @ImportoSanzioneequalthis DECIMAL(18,2), @ImportoRecuperoAnticipoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @ImportoLiquidatoequalthis DECIMAL(18,2), @FlagLiquidatoequalthis BIT, @IdDecretoequalthis INT',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Barcodeequalthis , @MisuraPrevalenteequalthis , @ImportoAmmissibileequalthis , @ImportoSanzioneequalthis , @ImportoRecuperoAnticipoequalthis , @ImportoAmmessoequalthis , @ImportoLiquidatoequalthis , @FlagLiquidatoequalthis , @IdDecretoequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE
		FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Barcodeequalthis IS NULL) OR BARCODE = @Barcodeequalthis) AND 
			((@MisuraPrevalenteequalthis IS NULL) OR MISURA_PREVALENTE = @MisuraPrevalenteequalthis) AND 
			((@ImportoAmmissibileequalthis IS NULL) OR IMPORTO_AMMISSIBILE = @ImportoAmmissibileequalthis) AND 
			((@ImportoSanzioneequalthis IS NULL) OR IMPORTO_SANZIONE = @ImportoSanzioneequalthis) AND 
			((@ImportoRecuperoAnticipoequalthis IS NULL) OR IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@ImportoLiquidatoequalthis IS NULL) OR IMPORTO_LIQUIDATO = @ImportoLiquidatoequalthis) AND 
			((@FlagLiquidatoequalthis IS NULL) OR FLAG_LIQUIDATO = @FlagLiquidatoequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis)
		

GO

declare @old_ZDomandaDiPagamentoEsportazioneFindSelect varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneFindSelect = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneFindSelect;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneFindSelect,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneFindSelect';
drop table ##old_ZDomandaDiPagamentoEsportazioneFindSelect
GO

select ROUTINE_DEFINITION into ##old_ZDomandaDiPagamentoEsportazioneFindFind from information_schema.routines where routine_name='ZDomandaDiPagamentoEsportazioneFindFind';
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZDomandaDiPagamentoEsportazioneFindFind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ZDomandaDiPagamentoEsportazioneFindFind];
GO
CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Barcodeequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE = @Barcodeequalthis)'; set @lensql=@lensql+len(@Barcodeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @Barcodeequalthis VARCHAR(255)',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @Barcodeequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, ID_PROGETTO, BARCODE, MISURA_PREVALENTE, IMPORTO_AMMISSIBILE, IMPORTO_SANZIONE, IMPORTO_RECUPERO_ANTICIPO, IMPORTO_AMMESSO, IMPORTO_LIQUIDATO, FLAG_LIQUIDATO, ID_DECRETO, COD_TIPO, DATA_INSERIMENTO, CF_OPERATORE, DATA_MODIFICA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE
		FROM VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Barcodeequalthis IS NULL) OR BARCODE = @Barcodeequalthis)
		

GO

declare @old_ZDomandaDiPagamentoEsportazioneFindFind varchar(8000);
select @old_ZDomandaDiPagamentoEsportazioneFindFind = ROUTINE_DEFINITION from ##old_ZDomandaDiPagamentoEsportazioneFindFind;
exec sp_addextendedproperty 'backup',@old_ZDomandaDiPagamentoEsportazioneFindFind,'user',dbo,'procedure','ZDomandaDiPagamentoEsportazioneFindFind';
drop table ##old_ZDomandaDiPagamentoEsportazioneFindFind
GO
*/

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO_ESPORTAZIONE>
  <ViewName>VDOMANDA_DI_PAGAMENTO_ESPORTAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <BARCODE>Equal</BARCODE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO_ESPORTAZIONE>
*/
