using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoComunicazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoComunicazioniProvider
	{
		int Save(ProgettoComunicazioni ProgettoComunicazioniObj);
		int SaveCollection(ProgettoComunicazioniCollection collectionObj);
		int Delete(ProgettoComunicazioni ProgettoComunicazioniObj);
		int DeleteCollection(ProgettoComunicazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoComunicazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoComunicazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.IntNT _Operatore;
		private NullTypes.IntNT _IdNote;
		private NullTypes.IntNT _Istruttore;
		private NullTypes.StringNT _Esito;
		private NullTypes.IntNT _IdDecreto;
		private NullTypes.IntNT _IdComunicazioneRiferimento;
		private NullTypes.StringNT _Direzione;
		private NullTypes.StringNT _TipoSegnatura;
		private NullTypes.IntNT _GiorniPrevisti;
		private NullTypes.BoolNT _FlagDomandaAiuto;
		private NullTypes.BoolNT _FlagDomandaPagamento;
		private NullTypes.BoolNT _FlagVariante;
		private NullTypes.StringNT _NominativoOperatore;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.StringNT _CfIstruttore;
		private NullTypes.StringNT _NominativoIstruttore;
		private NullTypes.IntNT _NumAtto;
		private NullTypes.DatetimeNT _DataAtto;
		private NullTypes.StringNT _DescrizioneAtto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.BoolNT _PredispostaAllaFirma;
		private NullTypes.DatetimeNT _DataIstruttoria;
		private NullTypes.StringNT _SegnaturaIstruttoria;
		private NullTypes.IntNT _IdNoteIstruttoria;
		private NullTypes.StringNT _CodEnteEmettitore;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _CodTipoEnte;
		[NonSerialized] private IProgettoComunicazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoComunicazioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
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
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
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
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
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
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_NOTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNote
		{
			get { return _IdNote; }
			set {
				if (IdNote != value)
				{
					_IdNote = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Istruttore
		{
			get { return _Istruttore; }
			set {
				if (Istruttore != value)
				{
					_Istruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Esito
		{
			get { return _Esito; }
			set {
				if (Esito != value)
				{
					_Esito = value;
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
		/// Corrisponde al campo:ID_COMUNICAZIONE_RIFERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComunicazioneRiferimento
		{
			get { return _IdComunicazioneRiferimento; }
			set {
				if (IdComunicazioneRiferimento != value)
				{
					_IdComunicazioneRiferimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIREZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Direzione
		{
			get { return _Direzione; }
			set {
				if (Direzione != value)
				{
					_Direzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_SEGNATURA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT TipoSegnatura
		{
			get { return _TipoSegnatura; }
			set {
				if (TipoSegnatura != value)
				{
					_TipoSegnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:GIORNI_PREVISTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT GiorniPrevisti
		{
			get { return _GiorniPrevisti; }
			set {
				if (GiorniPrevisti != value)
				{
					_GiorniPrevisti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_DOMANDA_AIUTO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagDomandaAiuto
		{
			get { return _FlagDomandaAiuto; }
			set {
				if (FlagDomandaAiuto != value)
				{
					_FlagDomandaAiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_DOMANDA_PAGAMENTO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagDomandaPagamento
		{
			get { return _FlagDomandaPagamento; }
			set {
				if (FlagDomandaPagamento != value)
				{
					_FlagDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_VARIANTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagVariante
		{
			get { return _FlagVariante; }
			set {
				if (FlagVariante != value)
				{
					_FlagVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_OPERATORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoOperatore
		{
			get { return _NominativoOperatore; }
			set {
				if (NominativoOperatore != value)
				{
					_NominativoOperatore = value;
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
		/// Corrisponde al campo:NOMINATIVO_ISTRUTTORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoIstruttore
		{
			get { return _NominativoIstruttore; }
			set {
				if (NominativoIstruttore != value)
				{
					_NominativoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUM_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumAtto
		{
			get { return _NumAtto; }
			set {
				if (NumAtto != value)
				{
					_NumAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ATTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAtto
		{
			get { return _DataAtto; }
			set {
				if (DataAtto != value)
				{
					_DataAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ATTO
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT DescrizioneAtto
		{
			get { return _DescrizioneAtto; }
			set {
				if (DescrizioneAtto != value)
				{
					_DescrizioneAtto = value;
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
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREDISPOSTA_ALLA_FIRMA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT PredispostaAllaFirma
		{
			get { return _PredispostaAllaFirma; }
			set {
				if (PredispostaAllaFirma != value)
				{
					_PredispostaAllaFirma = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ISTRUTTORIA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataIstruttoria
		{
			get { return _DataIstruttoria; }
			set {
				if (DataIstruttoria != value)
				{
					_DataIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ISTRUTTORIA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaIstruttoria
		{
			get { return _SegnaturaIstruttoria; }
			set {
				if (SegnaturaIstruttoria != value)
				{
					_SegnaturaIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_NOTE_ISTRUTTORIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNoteIstruttoria
		{
			get { return _IdNoteIstruttoria; }
			set {
				if (IdNoteIstruttoria != value)
				{
					_IdNoteIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE_EMETTITORE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteEmettitore
		{
			get { return _CodEnteEmettitore; }
			set {
				if (CodEnteEmettitore != value)
				{
					_CodEnteEmettitore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(270)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
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
	/// Summary description for ProgettoComunicazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoComunicazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoComunicazioni) info.GetValue(i.ToString(),typeof(ProgettoComunicazioni)));
			}
		}

		//Costruttore
		public ProgettoComunicazioniCollection()
		{
			this.ItemType = typeof(ProgettoComunicazioni);
		}

		//Costruttore con provider
		public ProgettoComunicazioniCollection(IProgettoComunicazioniProvider providerObj)
		{
			this.ItemType = typeof(ProgettoComunicazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoComunicazioni this[int index]
		{
			get { return (ProgettoComunicazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoComunicazioniCollection GetChanges()
		{
			return (ProgettoComunicazioniCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoComunicazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniProvider Provider
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
		public int Add(ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			if (ProgettoComunicazioniObj.Provider == null) ProgettoComunicazioniObj.Provider = this.Provider;
			return base.Add(ProgettoComunicazioniObj);
		}

		//AddCollection
		public void AddCollection(ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj)
		{
			foreach (ProgettoComunicazioni ProgettoComunicazioniObj in ProgettoComunicazioniCollectionObj)
				this.Add(ProgettoComunicazioniObj);
		}

		//Insert
		public void Insert(int index, ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			if (ProgettoComunicazioniObj.Provider == null) ProgettoComunicazioniObj.Provider = this.Provider;
			base.Insert(index, ProgettoComunicazioniObj);
		}

		//CollectionGetById
		public ProgettoComunicazioni CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
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
		public ProgettoComunicazioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.StringNT CodEnteEmettitoreEqualThis, NullTypes.IntNT IdComuneEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.BoolNT PredispostaAllaFirmaEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.IntNT IdNoteEqualThis, 
NullTypes.IntNT IstruttoreEqualThis, NullTypes.DatetimeNT DataIstruttoriaEqualThis, NullTypes.StringNT SegnaturaIstruttoriaEqualThis, 
NullTypes.IntNT IdNoteIstruttoriaEqualThis, NullTypes.StringNT EsitoEqualThis, NullTypes.IntNT IdDecretoEqualThis, 
NullTypes.IntNT IdComunicazioneRiferimentoEqualThis, NullTypes.StringNT DirezioneEqualThis)
		{
			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionTemp = new ProgettoComunicazioniCollection();
			foreach (ProgettoComunicazioni ProgettoComunicazioniItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoComunicazioniItem.Id != null) && (ProgettoComunicazioniItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoComunicazioniItem.IdProgetto != null) && (ProgettoComunicazioniItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((ProgettoComunicazioniItem.IdDomandaPagamento != null) && (ProgettoComunicazioniItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdVarianteEqualThis == null) || ((ProgettoComunicazioniItem.IdVariante != null) && (ProgettoComunicazioniItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ProgettoComunicazioniItem.CodTipo != null) && (ProgettoComunicazioniItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoComunicazioniItem.Data != null) && (ProgettoComunicazioniItem.Data.Value == DataEqualThis.Value))) && 
((CodEnteEmettitoreEqualThis == null) || ((ProgettoComunicazioniItem.CodEnteEmettitore != null) && (ProgettoComunicazioniItem.CodEnteEmettitore.Value == CodEnteEmettitoreEqualThis.Value))) && ((IdComuneEqualThis == null) || ((ProgettoComunicazioniItem.IdComune != null) && (ProgettoComunicazioniItem.IdComune.Value == IdComuneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoComunicazioniItem.Operatore != null) && (ProgettoComunicazioniItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((PredispostaAllaFirmaEqualThis == null) || ((ProgettoComunicazioniItem.PredispostaAllaFirma != null) && (ProgettoComunicazioniItem.PredispostaAllaFirma.Value == PredispostaAllaFirmaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoComunicazioniItem.Segnatura != null) && (ProgettoComunicazioniItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((IdNoteEqualThis == null) || ((ProgettoComunicazioniItem.IdNote != null) && (ProgettoComunicazioniItem.IdNote.Value == IdNoteEqualThis.Value))) && 
((IstruttoreEqualThis == null) || ((ProgettoComunicazioniItem.Istruttore != null) && (ProgettoComunicazioniItem.Istruttore.Value == IstruttoreEqualThis.Value))) && ((DataIstruttoriaEqualThis == null) || ((ProgettoComunicazioniItem.DataIstruttoria != null) && (ProgettoComunicazioniItem.DataIstruttoria.Value == DataIstruttoriaEqualThis.Value))) && ((SegnaturaIstruttoriaEqualThis == null) || ((ProgettoComunicazioniItem.SegnaturaIstruttoria != null) && (ProgettoComunicazioniItem.SegnaturaIstruttoria.Value == SegnaturaIstruttoriaEqualThis.Value))) && 
((IdNoteIstruttoriaEqualThis == null) || ((ProgettoComunicazioniItem.IdNoteIstruttoria != null) && (ProgettoComunicazioniItem.IdNoteIstruttoria.Value == IdNoteIstruttoriaEqualThis.Value))) && ((EsitoEqualThis == null) || ((ProgettoComunicazioniItem.Esito != null) && (ProgettoComunicazioniItem.Esito.Value == EsitoEqualThis.Value))) && ((IdDecretoEqualThis == null) || ((ProgettoComunicazioniItem.IdDecreto != null) && (ProgettoComunicazioniItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && 
((IdComunicazioneRiferimentoEqualThis == null) || ((ProgettoComunicazioniItem.IdComunicazioneRiferimento != null) && (ProgettoComunicazioniItem.IdComunicazioneRiferimento.Value == IdComunicazioneRiferimentoEqualThis.Value))) && ((DirezioneEqualThis == null) || ((ProgettoComunicazioniItem.Direzione != null) && (ProgettoComunicazioniItem.Direzione.Value == DirezioneEqualThis.Value))))
				{
					ProgettoComunicazioniCollectionTemp.Add(ProgettoComunicazioniItem);
				}
			}
			return ProgettoComunicazioniCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoComunicazioniCollection FiltroComunicazioniDomandaAiuto(NullTypes.BoolNT IdDomandaPagamentoIsNull, NullTypes.BoolNT IdVarianteIsNull)
		{
			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionTemp = new ProgettoComunicazioniCollection();
			foreach (ProgettoComunicazioni ProgettoComunicazioniItem in this)
			{
				if (((IdDomandaPagamentoIsNull == null) || ((ProgettoComunicazioniItem.IdDomandaPagamento == null) ==  IdDomandaPagamentoIsNull.Value)) && ((IdVarianteIsNull == null) || ((ProgettoComunicazioniItem.IdVariante == null) ==  IdVarianteIsNull.Value)))
				{
					ProgettoComunicazioniCollectionTemp.Add(ProgettoComunicazioniItem);
				}
			}
			return ProgettoComunicazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoComunicazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoComunicazioni ProgettoComunicazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoComunicazioniObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoComunicazioniObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", ProgettoComunicazioniObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", ProgettoComunicazioniObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", ProgettoComunicazioniObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoComunicazioniObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoComunicazioniObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoComunicazioniObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", ProgettoComunicazioniObj.IdNote);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruttore", ProgettoComunicazioniObj.Istruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", ProgettoComunicazioniObj.Esito);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDecreto", ProgettoComunicazioniObj.IdDecreto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazioneRiferimento", ProgettoComunicazioniObj.IdComunicazioneRiferimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Direzione", ProgettoComunicazioniObj.Direzione);
			DbProvider.SetCmdParam(cmd,firstChar + "PredispostaAllaFirma", ProgettoComunicazioniObj.PredispostaAllaFirma);
			DbProvider.SetCmdParam(cmd,firstChar + "DataIstruttoria", ProgettoComunicazioniObj.DataIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaIstruttoria", ProgettoComunicazioniObj.SegnaturaIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNoteIstruttoria", ProgettoComunicazioniObj.IdNoteIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnteEmettitore", ProgettoComunicazioniObj.CodEnteEmettitore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", ProgettoComunicazioniObj.IdComune);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "CodTipo", "Data", 
"Segnatura", "Operatore", "IdNote", 
"Istruttore", "Esito", "IdDecreto", 
"IdComunicazioneRiferimento", "Direzione", 





"PredispostaAllaFirma", "DataIstruttoria", "SegnaturaIstruttoria", 
"IdNoteIstruttoria", "CodEnteEmettitore", "IdComune", }, new string[] {"int", "int", 
"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", "int", 
"int", "string", 





"bool", "DateTime", "string", 
"int", "string", "int", },"");
				CompileIUCmd(false, insertCmd,ProgettoComunicazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoComunicazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ProgettoComunicazioniObj.PredispostaAllaFirma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_ALLA_FIRMA"]);
				}
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniUpdate", new string[] {"Id", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "CodTipo", "Data", 
"Segnatura", "Operatore", "IdNote", 
"Istruttore", "Esito", "IdDecreto", 
"IdComunicazioneRiferimento", "Direzione", 





"PredispostaAllaFirma", "DataIstruttoria", "SegnaturaIstruttoria", 
"IdNoteIstruttoria", "CodEnteEmettitore", "IdComune", }, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", "int", 
"int", "string", 





"bool", "DateTime", "string", 
"int", "string", "int", },"");
				CompileIUCmd(true, updateCmd,ProgettoComunicazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			switch (ProgettoComunicazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoComunicazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoComunicazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoComunicazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniUpdate", new string[] {"Id", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "CodTipo", "Data", 
"Segnatura", "Operatore", "IdNote", 
"Istruttore", "Esito", "IdDecreto", 
"IdComunicazioneRiferimento", "Direzione", 





"PredispostaAllaFirma", "DataIstruttoria", "SegnaturaIstruttoria", 
"IdNoteIstruttoria", "CodEnteEmettitore", "IdComune", }, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", "int", 
"int", "string", 





"bool", "DateTime", "string", 
"int", "string", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "CodTipo", "Data", 
"Segnatura", "Operatore", "IdNote", 
"Istruttore", "Esito", "IdDecreto", 
"IdComunicazioneRiferimento", "Direzione", 





"PredispostaAllaFirma", "DataIstruttoria", "SegnaturaIstruttoria", 
"IdNoteIstruttoria", "CodEnteEmettitore", "IdComune", }, new string[] {"int", "int", 
"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", "int", 
"int", "string", 





"bool", "DateTime", "string", 
"int", "string", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniCollectionObj.Count; i++)
				{
					switch (ProgettoComunicazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoComunicazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoComunicazioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ProgettoComunicazioniCollectionObj[i].PredispostaAllaFirma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_ALLA_FIRMA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoComunicazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoComunicazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoComunicazioniCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoComunicazioniCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoComunicazioni ProgettoComunicazioniObj)
		{
			int returnValue = 0;
			if (ProgettoComunicazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoComunicazioniObj.Id);
			}
			ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoComunicazioniObj.IsDirty = false;
			ProgettoComunicazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoComunicazioniCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniCollectionObj[i].IsPersistent = false;
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
		public static ProgettoComunicazioni GetById(DbProvider db, int IdValue)
		{
			ProgettoComunicazioni ProgettoComunicazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoComunicazioniGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoComunicazioniObj = GetFromDatareader(db);
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoComunicazioniObj;
		}

		//getFromDatareader
		public static ProgettoComunicazioni GetFromDatareader(DbProvider db)
		{
			ProgettoComunicazioni ProgettoComunicazioniObj = new ProgettoComunicazioni();
			ProgettoComunicazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoComunicazioniObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoComunicazioniObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			ProgettoComunicazioniObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			ProgettoComunicazioniObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ProgettoComunicazioniObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoComunicazioniObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoComunicazioniObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoComunicazioniObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			ProgettoComunicazioniObj.Istruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ISTRUTTORE"]);
			ProgettoComunicazioniObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			ProgettoComunicazioniObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
			ProgettoComunicazioniObj.IdComunicazioneRiferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE_RIFERIMENTO"]);
			ProgettoComunicazioniObj.Direzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DIREZIONE"]);
			ProgettoComunicazioniObj.TipoSegnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SEGNATURA"]);
			ProgettoComunicazioniObj.GiorniPrevisti = new SiarLibrary.NullTypes.IntNT(db.DataReader["GIORNI_PREVISTI"]);
			ProgettoComunicazioniObj.FlagDomandaAiuto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DOMANDA_AIUTO"]);
			ProgettoComunicazioniObj.FlagDomandaPagamento = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DOMANDA_PAGAMENTO"]);
			ProgettoComunicazioniObj.FlagVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_VARIANTE"]);
			ProgettoComunicazioniObj.NominativoOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE"]);
			ProgettoComunicazioniObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			ProgettoComunicazioniObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
			ProgettoComunicazioniObj.NominativoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_ISTRUTTORE"]);
			ProgettoComunicazioniObj.NumAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUM_ATTO"]);
			ProgettoComunicazioniObj.DataAtto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO"]);
			ProgettoComunicazioniObj.DescrizioneAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ATTO"]);
			ProgettoComunicazioniObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettoComunicazioniObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			ProgettoComunicazioniObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			ProgettoComunicazioniObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			ProgettoComunicazioniObj.PredispostaAllaFirma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_ALLA_FIRMA"]);
			ProgettoComunicazioniObj.DataIstruttoria = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ISTRUTTORIA"]);
			ProgettoComunicazioniObj.SegnaturaIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ISTRUTTORIA"]);
			ProgettoComunicazioniObj.IdNoteIstruttoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE_ISTRUTTORIA"]);
			ProgettoComunicazioniObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
			ProgettoComunicazioniObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ProgettoComunicazioniObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoComunicazioniObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoComunicazioniObj.IsDirty = false;
			ProgettoComunicazioniObj.IsPersistent = true;
			return ProgettoComunicazioniObj;
		}

		//Find Select

		public static ProgettoComunicazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteEmettitoreEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT PredispostaAllaFirmaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdNoteEqualThis, 
SiarLibrary.NullTypes.IntNT IstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataIstruttoriaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaIstruttoriaEqualThis, 
SiarLibrary.NullTypes.IntNT IdNoteIstruttoriaEqualThis, SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, 
SiarLibrary.NullTypes.IntNT IdComunicazioneRiferimentoEqualThis, SiarLibrary.NullTypes.StringNT DirezioneEqualThis)

		{

			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj = new ProgettoComunicazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionifindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdVarianteequalthis", "CodTipoequalthis", "Dataequalthis", 
"CodEnteEmettitoreequalthis", "IdComuneequalthis", "Operatoreequalthis", 
"PredispostaAllaFirmaequalthis", "Segnaturaequalthis", "IdNoteequalthis", 
"Istruttoreequalthis", "DataIstruttoriaequalthis", "SegnaturaIstruttoriaequalthis", 
"IdNoteIstruttoriaequalthis", "Esitoequalthis", "IdDecretoequalthis", 
"IdComunicazioneRiferimentoequalthis", "Direzioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"string", "int", "int", 
"bool", "string", "int", 
"int", "DateTime", "string", 
"int", "string", "int", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteEmettitoreequalthis", CodEnteEmettitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PredispostaAllaFirmaequalthis", PredispostaAllaFirmaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataIstruttoriaequalthis", DataIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaIstruttoriaequalthis", SegnaturaIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteIstruttoriaequalthis", IdNoteIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneRiferimentoequalthis", IdComunicazioneRiferimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Direzioneequalthis", DirezioneEqualThis);
			ProgettoComunicazioni ProgettoComunicazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniObj = GetFromDatareader(db);
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
				ProgettoComunicazioniCollectionObj.Add(ProgettoComunicazioniObj);
			}
			db.Close();
			return ProgettoComunicazioniCollectionObj;
		}

		//Find Find

		public static ProgettoComunicazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT DirezioneEqualThis)

		{

			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj = new ProgettoComunicazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionifindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdVarianteequalthis", "CodTipoequalthis", "Direzioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Direzioneequalthis", DirezioneEqualThis);
			ProgettoComunicazioni ProgettoComunicazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniObj = GetFromDatareader(db);
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
				ProgettoComunicazioniCollectionObj.Add(ProgettoComunicazioniObj);
			}
			db.Close();
			return ProgettoComunicazioniCollectionObj;
		}

		//Find FindComunicazioneRiferimento

		public static ProgettoComunicazioniCollection FindComunicazioneRiferimento(DbProvider db, SiarLibrary.NullTypes.IntNT IdComunicazioneRiferimentoEqualThis)

		{

			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionObj = new ProgettoComunicazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionifindfindcomunicazioneriferimento", new string[] {"IdComunicazioneRiferimentoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneRiferimentoequalthis", IdComunicazioneRiferimentoEqualThis);
			ProgettoComunicazioni ProgettoComunicazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniObj = GetFromDatareader(db);
				ProgettoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniObj.IsDirty = false;
				ProgettoComunicazioniObj.IsPersistent = true;
				ProgettoComunicazioniCollectionObj.Add(ProgettoComunicazioniObj);
			}
			db.Close();
			return ProgettoComunicazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniCollectionProvider:IProgettoComunicazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniCollectionProvider : IProgettoComunicazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoComunicazioni
		protected ProgettoComunicazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoComunicazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoComunicazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoComunicazioniCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, StringNT DirezioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdvarianteEqualThis, CodtipoEqualThis, DirezioneEqualThis);
		}

		//Costruttore3: ha in input progettocomunicazioniCollectionObj - non popola la collection
		public ProgettoComunicazioniCollectionProvider(ProgettoComunicazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoComunicazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoComunicazioniCollection(this);
		}

		//Get e Set
		public ProgettoComunicazioniCollection CollectionObj
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
		public int SaveCollection(ProgettoComunicazioniCollection collectionObj)
		{
			return ProgettoComunicazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoComunicazioni progettocomunicazioniObj)
		{
			return ProgettoComunicazioniDAL.Save(_dbProviderObj, progettocomunicazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoComunicazioniCollection collectionObj)
		{
			return ProgettoComunicazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoComunicazioni progettocomunicazioniObj)
		{
			return ProgettoComunicazioniDAL.Delete(_dbProviderObj, progettocomunicazioniObj);
		}

		//getById
		public ProgettoComunicazioni GetById(IntNT IdValue)
		{
			ProgettoComunicazioni ProgettoComunicazioniTemp = ProgettoComunicazioniDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoComunicazioniTemp!=null) ProgettoComunicazioniTemp.Provider = this;
			return ProgettoComunicazioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoComunicazioniCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, DatetimeNT DataEqualThis, 
StringNT CodenteemettitoreEqualThis, IntNT IdcomuneEqualThis, IntNT OperatoreEqualThis, 
BoolNT PredispostaallafirmaEqualThis, StringNT SegnaturaEqualThis, IntNT IdnoteEqualThis, 
IntNT IstruttoreEqualThis, DatetimeNT DataistruttoriaEqualThis, StringNT SegnaturaistruttoriaEqualThis, 
IntNT IdnoteistruttoriaEqualThis, StringNT EsitoEqualThis, IntNT IddecretoEqualThis, 
IntNT IdcomunicazioneriferimentoEqualThis, StringNT DirezioneEqualThis)
		{
			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionTemp = ProgettoComunicazioniDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdvarianteEqualThis, CodtipoEqualThis, DataEqualThis, 
CodenteemettitoreEqualThis, IdcomuneEqualThis, OperatoreEqualThis, 
PredispostaallafirmaEqualThis, SegnaturaEqualThis, IdnoteEqualThis, 
IstruttoreEqualThis, DataistruttoriaEqualThis, SegnaturaistruttoriaEqualThis, 
IdnoteistruttoriaEqualThis, EsitoEqualThis, IddecretoEqualThis, 
IdcomunicazioneriferimentoEqualThis, DirezioneEqualThis);
			ProgettoComunicazioniCollectionTemp.Provider = this;
			return ProgettoComunicazioniCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoComunicazioniCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis, StringNT DirezioneEqualThis)
		{
			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionTemp = ProgettoComunicazioniDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdvarianteEqualThis, CodtipoEqualThis, DirezioneEqualThis);
			ProgettoComunicazioniCollectionTemp.Provider = this;
			return ProgettoComunicazioniCollectionTemp;
		}

		//FindComunicazioneRiferimento: popola la collection
		public ProgettoComunicazioniCollection FindComunicazioneRiferimento(IntNT IdcomunicazioneriferimentoEqualThis)
		{
			ProgettoComunicazioniCollection ProgettoComunicazioniCollectionTemp = ProgettoComunicazioniDAL.FindComunicazioneRiferimento(_dbProviderObj, IdcomunicazioneriferimentoEqualThis);
			ProgettoComunicazioniCollectionTemp.Provider = this;
			return ProgettoComunicazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_COMUNICAZIONI>
  <ViewName>vPROGETTO_COMUNICAZIONI</ViewName>
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
    <Find OrderBy="ORDER BY ID DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO>Equal</COD_TIPO>
      <DIREZIONE>Equal</DIREZIONE>
    </Find>
    <FindComunicazioneRiferimento OrderBy="ORDER BY ">
      <ID_COMUNICAZIONE_RIFERIMENTO>Equal</ID_COMUNICAZIONE_RIFERIMENTO>
    </FindComunicazioneRiferimento>
  </Finds>
  <Filters>
    <FiltroComunicazioniDomandaAiuto>
      <ID_DOMANDA_PAGAMENTO>IsNull</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>IsNull</ID_VARIANTE>
    </FiltroComunicazioniDomandaAiuto>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONI>
*/
