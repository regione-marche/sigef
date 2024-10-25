using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoModificheProvider
	{
		int Save(ProgettoModifiche ProgettoModificheObj);
		int SaveCollection(ProgettoModificheCollection collectionObj);
		int Delete(ProgettoModifiche ProgettoModificheObj);
		int DeleteCollection(ProgettoModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodAgea;
		private NullTypes.StringNT _SegnaturaAllegati;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.BoolNT _Revisione;
		private NullTypes.BoolNT _Riesame;
		private NullTypes.BoolNT _Ricorso;
		private NullTypes.DatetimeNT _DataRi;
		private NullTypes.IntNT _OperatoreRi;
		private NullTypes.StringNT _SegnaturaRi;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _CodFase;
		private NullTypes.IntNT _OrdineStato;
		private NullTypes.StringNT _Fase;
		private NullTypes.IntNT _OrdineFase;
		private NullTypes.IntNT _IdProgIntegrato;
		private NullTypes.BoolNT _FlagPreadesione;
		private NullTypes.BoolNT _FlagDefinitivo;
		private NullTypes.IntNT _IdFascicolo;
		private NullTypes.StringNT _ProvinciaDiPresentazione;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdStoricoUltimo;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.BoolNT _RiaperturaProvinciale;
		private NullTypes.BoolNT _FirmaPredisposta;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IProgettoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:COD_AGEA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodAgea
		{
			get { return _CodAgea; }
			set {
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
			set {
				if (SegnaturaAllegati != value)
				{
					_SegnaturaAllegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
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
		/// Corrisponde al campo:REVISIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Revisione
		{
			get { return _Revisione; }
			set {
				if (Revisione != value)
				{
					_Revisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIESAME
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Riesame
		{
			get { return _Riesame; }
			set {
				if (Riesame != value)
				{
					_Riesame = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICORSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Ricorso
		{
			get { return _Ricorso; }
			set {
				if (Ricorso != value)
				{
					_Ricorso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RI
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRi
		{
			get { return _DataRi; }
			set {
				if (DataRi != value)
				{
					_DataRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_RI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreRi
		{
			get { return _OperatoreRi; }
			set {
				if (OperatoreRi != value)
				{
					_OperatoreRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_RI
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaRi
		{
			get { return _SegnaturaRi; }
			set {
				if (SegnaturaRi != value)
				{
					_SegnaturaRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
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
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_STATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineStato
		{
			get { return _OrdineStato; }
			set {
				if (OrdineStato != value)
				{
					_OrdineStato = value;
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
			set {
				if (Fase != value)
				{
					_Fase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FASE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFase
		{
			get { return _OrdineFase; }
			set {
				if (OrdineFase != value)
				{
					_OrdineFase = value;
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
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
			set {
				if (SelezionataXRevisione != value)
				{
					_SelezionataXRevisione = value;
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
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
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
			set {
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
			set {
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
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
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

		/// <summary>
		/// Corrisponde al campo:RIAPERTURA_PROVINCIALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RiaperturaProvinciale
		{
			get { return _RiaperturaProvinciale; }
			set {
				if (RiaperturaProvinciale != value)
				{
					_RiaperturaProvinciale = value;
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
		/// Corrisponde al campo:ID_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAtto
		{
			get { return _IdAtto; }
			set {
				if (IdAtto != value)
				{
					_IdAtto = value;
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
			set {
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
			set {
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
	/// Summary description for ProgettoModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoModifiche) info.GetValue(i.ToString(),typeof(ProgettoModifiche)));
			}
		}

		//Costruttore
		public ProgettoModificheCollection()
		{
			this.ItemType = typeof(ProgettoModifiche);
		}

		//Costruttore con provider
		public ProgettoModificheCollection(IProgettoModificheProvider providerObj)
		{
			this.ItemType = typeof(ProgettoModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoModifiche this[int index]
		{
			get { return (ProgettoModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoModificheCollection GetChanges()
		{
			return (ProgettoModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoModificheProvider Provider
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
		public int Add(ProgettoModifiche ProgettoModificheObj)
		{
			if (ProgettoModificheObj.Provider == null) ProgettoModificheObj.Provider = this.Provider;
			return base.Add(ProgettoModificheObj);
		}

		//AddCollection
		public void AddCollection(ProgettoModificheCollection ProgettoModificheCollectionObj)
		{
			foreach (ProgettoModifiche ProgettoModificheObj in ProgettoModificheCollectionObj)
				this.Add(ProgettoModificheObj);
		}

		//Insert
		public void Insert(int index, ProgettoModifiche ProgettoModificheObj)
		{
			if (ProgettoModificheObj.Provider == null) ProgettoModificheObj.Provider = this.Provider;
			base.Insert(index, ProgettoModificheObj);
		}

		//CollectionGetById
		public ProgettoModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoModificheCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodAgeaEqualThis, 
NullTypes.StringNT SegnaturaAllegatiEqualThis, NullTypes.StringNT CodStatoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT RevisioneEqualThis, 
NullTypes.BoolNT RiesameEqualThis, NullTypes.BoolNT RicorsoEqualThis, NullTypes.DatetimeNT DataRiEqualThis, 
NullTypes.IntNT OperatoreRiEqualThis, NullTypes.StringNT SegnaturaRiEqualThis, NullTypes.StringNT StatoEqualThis, 
NullTypes.StringNT CodFaseEqualThis, NullTypes.IntNT OrdineStatoEqualThis, NullTypes.StringNT FaseEqualThis, 
NullTypes.IntNT OrdineFaseEqualThis, NullTypes.IntNT IdProgIntegratoEqualThis, NullTypes.BoolNT FlagPreadesioneEqualThis, 
NullTypes.BoolNT FlagDefinitivoEqualThis, NullTypes.IntNT IdFascicoloEqualThis, NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
NullTypes.BoolNT SelezionataXRevisioneEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.StringNT NominativoEqualThis, 
NullTypes.StringNT EnteEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT ProvinciaEqualThis, 
NullTypes.StringNT CodTipoEnteEqualThis, NullTypes.BoolNT RiaperturaProvincialeEqualThis, NullTypes.BoolNT FirmaPredispostaEqualThis, 
NullTypes.IntNT IdAttoEqualThis, NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			ProgettoModificheCollection ProgettoModificheCollectionTemp = new ProgettoModificheCollection();
			foreach (ProgettoModifiche ProgettoModificheItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((ProgettoModificheItem.IdProgetto != null) && (ProgettoModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ProgettoModificheItem.IdBando != null) && (ProgettoModificheItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodAgeaEqualThis == null) || ((ProgettoModificheItem.CodAgea != null) && (ProgettoModificheItem.CodAgea.Value == CodAgeaEqualThis.Value))) && 
((SegnaturaAllegatiEqualThis == null) || ((ProgettoModificheItem.SegnaturaAllegati != null) && (ProgettoModificheItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) && ((CodStatoEqualThis == null) || ((ProgettoModificheItem.CodStato != null) && (ProgettoModificheItem.CodStato.Value == CodStatoEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoModificheItem.Data != null) && (ProgettoModificheItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((ProgettoModificheItem.Operatore != null) && (ProgettoModificheItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoModificheItem.Segnatura != null) && (ProgettoModificheItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((RevisioneEqualThis == null) || ((ProgettoModificheItem.Revisione != null) && (ProgettoModificheItem.Revisione.Value == RevisioneEqualThis.Value))) && 
((RiesameEqualThis == null) || ((ProgettoModificheItem.Riesame != null) && (ProgettoModificheItem.Riesame.Value == RiesameEqualThis.Value))) && ((RicorsoEqualThis == null) || ((ProgettoModificheItem.Ricorso != null) && (ProgettoModificheItem.Ricorso.Value == RicorsoEqualThis.Value))) && ((DataRiEqualThis == null) || ((ProgettoModificheItem.DataRi != null) && (ProgettoModificheItem.DataRi.Value == DataRiEqualThis.Value))) && 
((OperatoreRiEqualThis == null) || ((ProgettoModificheItem.OperatoreRi != null) && (ProgettoModificheItem.OperatoreRi.Value == OperatoreRiEqualThis.Value))) && ((SegnaturaRiEqualThis == null) || ((ProgettoModificheItem.SegnaturaRi != null) && (ProgettoModificheItem.SegnaturaRi.Value == SegnaturaRiEqualThis.Value))) && ((StatoEqualThis == null) || ((ProgettoModificheItem.Stato != null) && (ProgettoModificheItem.Stato.Value == StatoEqualThis.Value))) && 
((CodFaseEqualThis == null) || ((ProgettoModificheItem.CodFase != null) && (ProgettoModificheItem.CodFase.Value == CodFaseEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((ProgettoModificheItem.OrdineStato != null) && (ProgettoModificheItem.OrdineStato.Value == OrdineStatoEqualThis.Value))) && ((FaseEqualThis == null) || ((ProgettoModificheItem.Fase != null) && (ProgettoModificheItem.Fase.Value == FaseEqualThis.Value))) && 
((OrdineFaseEqualThis == null) || ((ProgettoModificheItem.OrdineFase != null) && (ProgettoModificheItem.OrdineFase.Value == OrdineFaseEqualThis.Value))) && ((IdProgIntegratoEqualThis == null) || ((ProgettoModificheItem.IdProgIntegrato != null) && (ProgettoModificheItem.IdProgIntegrato.Value == IdProgIntegratoEqualThis.Value))) && ((FlagPreadesioneEqualThis == null) || ((ProgettoModificheItem.FlagPreadesione != null) && (ProgettoModificheItem.FlagPreadesione.Value == FlagPreadesioneEqualThis.Value))) && 
((FlagDefinitivoEqualThis == null) || ((ProgettoModificheItem.FlagDefinitivo != null) && (ProgettoModificheItem.FlagDefinitivo.Value == FlagDefinitivoEqualThis.Value))) && ((IdFascicoloEqualThis == null) || ((ProgettoModificheItem.IdFascicolo != null) && (ProgettoModificheItem.IdFascicolo.Value == IdFascicoloEqualThis.Value))) && ((ProvinciaDiPresentazioneEqualThis == null) || ((ProgettoModificheItem.ProvinciaDiPresentazione != null) && (ProgettoModificheItem.ProvinciaDiPresentazione.Value == ProvinciaDiPresentazioneEqualThis.Value))) && 
((SelezionataXRevisioneEqualThis == null) || ((ProgettoModificheItem.SelezionataXRevisione != null) && (ProgettoModificheItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ProgettoModificheItem.IdImpresa != null) && (ProgettoModificheItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((ProgettoModificheItem.IdStoricoUltimo != null) && (ProgettoModificheItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((ProgettoModificheItem.DataCreazione != null) && (ProgettoModificheItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ProgettoModificheItem.OperatoreCreazione != null) && (ProgettoModificheItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((NominativoEqualThis == null) || ((ProgettoModificheItem.Nominativo != null) && (ProgettoModificheItem.Nominativo.Value == NominativoEqualThis.Value))) && 
((EnteEqualThis == null) || ((ProgettoModificheItem.Ente != null) && (ProgettoModificheItem.Ente.Value == EnteEqualThis.Value))) && ((CodEnteEqualThis == null) || ((ProgettoModificheItem.CodEnte != null) && (ProgettoModificheItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((ProgettoModificheItem.Provincia != null) && (ProgettoModificheItem.Provincia.Value == ProvinciaEqualThis.Value))) && 
((CodTipoEnteEqualThis == null) || ((ProgettoModificheItem.CodTipoEnte != null) && (ProgettoModificheItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) && ((RiaperturaProvincialeEqualThis == null) || ((ProgettoModificheItem.RiaperturaProvinciale != null) && (ProgettoModificheItem.RiaperturaProvinciale.Value == RiaperturaProvincialeEqualThis.Value))) && ((FirmaPredispostaEqualThis == null) || ((ProgettoModificheItem.FirmaPredisposta != null) && (ProgettoModificheItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))) && 
((IdAttoEqualThis == null) || ((ProgettoModificheItem.IdAtto != null) && (ProgettoModificheItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((IdEqualThis == null) || ((ProgettoModificheItem.Id != null) && (ProgettoModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((ProgettoModificheItem.IdModifica != null) && (ProgettoModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					ProgettoModificheCollectionTemp.Add(ProgettoModificheItem);
				}
			}
			return ProgettoModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoModifiche ProgettoModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", ProgettoModificheObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodAgea", ProgettoModificheObj.CodAgea);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaAllegati", ProgettoModificheObj.SegnaturaAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStato", ProgettoModificheObj.CodStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoModificheObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoModificheObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoModificheObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Revisione", ProgettoModificheObj.Revisione);
			DbProvider.SetCmdParam(cmd,firstChar + "Riesame", ProgettoModificheObj.Riesame);
			DbProvider.SetCmdParam(cmd,firstChar + "Ricorso", ProgettoModificheObj.Ricorso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRi", ProgettoModificheObj.DataRi);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreRi", ProgettoModificheObj.OperatoreRi);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaRi", ProgettoModificheObj.SegnaturaRi);
			DbProvider.SetCmdParam(cmd,firstChar + "Stato", ProgettoModificheObj.Stato);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", ProgettoModificheObj.CodFase);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineStato", ProgettoModificheObj.OrdineStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Fase", ProgettoModificheObj.Fase);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineFase", ProgettoModificheObj.OrdineFase);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgIntegrato", ProgettoModificheObj.IdProgIntegrato);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagPreadesione", ProgettoModificheObj.FlagPreadesione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagDefinitivo", ProgettoModificheObj.FlagDefinitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFascicolo", ProgettoModificheObj.IdFascicolo);
			DbProvider.SetCmdParam(cmd,firstChar + "ProvinciaDiPresentazione", ProgettoModificheObj.ProvinciaDiPresentazione);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXRevisione", ProgettoModificheObj.SelezionataXRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ProgettoModificheObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoUltimo", ProgettoModificheObj.IdStoricoUltimo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ProgettoModificheObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ProgettoModificheObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Nominativo", ProgettoModificheObj.Nominativo);
			DbProvider.SetCmdParam(cmd,firstChar + "Ente", ProgettoModificheObj.Ente);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", ProgettoModificheObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", ProgettoModificheObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoEnte", ProgettoModificheObj.CodTipoEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "RiaperturaProvinciale", ProgettoModificheObj.RiaperturaProvinciale);
			DbProvider.SetCmdParam(cmd,firstChar + "FirmaPredisposta", ProgettoModificheObj.FirmaPredisposta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", ProgettoModificheObj.IdAtto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", ProgettoModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoModifiche ProgettoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoModificheInsert", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", "CodStato", "Data", 
"Operatore", "Segnatura", "Revisione", 
"Riesame", "Ricorso", "DataRi", 
"OperatoreRi", "SegnaturaRi", "Stato", 
"CodFase", "OrdineStato", "Fase", 
"OrdineFase", "IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", "Nominativo", 
"Ente", "CodEnte", "Provincia", 
"CodTipoEnte", "RiaperturaProvinciale", "FirmaPredisposta", 
"IdAtto", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"int", "string", "bool", 
"bool", "bool", "DateTime", 
"int", "string", "string", 
"string", "int", "string", 
"int", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "string", 
"string", "string", "string", 
"string", "bool", "bool", 
"int", "int"},"");
				CompileIUCmd(false, insertCmd,ProgettoModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoModificheObj.IsDirty = false;
				ProgettoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoModifiche ProgettoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoModificheUpdate", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", "CodStato", "Data", 
"Operatore", "Segnatura", "Revisione", 
"Riesame", "Ricorso", "DataRi", 
"OperatoreRi", "SegnaturaRi", "Stato", 
"CodFase", "OrdineStato", "Fase", 
"OrdineFase", "IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", "Nominativo", 
"Ente", "CodEnte", "Provincia", 
"CodTipoEnte", "RiaperturaProvinciale", "FirmaPredisposta", 
"IdAtto", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"int", "string", "bool", 
"bool", "bool", "DateTime", 
"int", "string", "string", 
"string", "int", "string", 
"int", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "string", 
"string", "string", "string", 
"string", "bool", "bool", 
"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,ProgettoModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoModificheObj.IsDirty = false;
				ProgettoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoModifiche ProgettoModificheObj)
		{
			switch (ProgettoModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoModificheCollection ProgettoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoModificheUpdate", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", "CodStato", "Data", 
"Operatore", "Segnatura", "Revisione", 
"Riesame", "Ricorso", "DataRi", 
"OperatoreRi", "SegnaturaRi", "Stato", 
"CodFase", "OrdineStato", "Fase", 
"OrdineFase", "IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", "Nominativo", 
"Ente", "CodEnte", "Provincia", 
"CodTipoEnte", "RiaperturaProvinciale", "FirmaPredisposta", 
"IdAtto", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"int", "string", "bool", 
"bool", "bool", "DateTime", 
"int", "string", "string", 
"string", "int", "string", 
"int", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "string", 
"string", "string", "string", 
"string", "bool", "bool", 
"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoModificheInsert", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", "CodStato", "Data", 
"Operatore", "Segnatura", "Revisione", 
"Riesame", "Ricorso", "DataRi", 
"OperatoreRi", "SegnaturaRi", "Stato", 
"CodFase", "OrdineStato", "Fase", 
"OrdineFase", "IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", "Nominativo", 
"Ente", "CodEnte", "Provincia", 
"CodTipoEnte", "RiaperturaProvinciale", "FirmaPredisposta", 
"IdAtto", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"int", "string", "bool", 
"bool", "bool", "DateTime", 
"int", "string", "string", 
"string", "int", "string", 
"int", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "string", 
"string", "string", "string", 
"string", "bool", "bool", 
"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoModificheCollectionObj.Count; i++)
				{
					switch (ProgettoModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoModificheCollectionObj.Count; i++)
				{
					if ((ProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoModificheCollectionObj[i].IsDirty = false;
						ProgettoModificheCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoModificheCollectionObj[i].IsDirty = false;
						ProgettoModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoModifiche ProgettoModificheObj)
		{
			int returnValue = 0;
			if (ProgettoModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoModificheObj.Id);
			}
			ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoModificheObj.IsDirty = false;
			ProgettoModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoModificheCollection ProgettoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoModificheCollectionObj.Count; i++)
				{
					if ((ProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoModificheCollectionObj[i].IsDirty = false;
						ProgettoModificheCollectionObj[i].IsPersistent = false;
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
		public static ProgettoModifiche GetById(DbProvider db, int IdValue)
		{
			ProgettoModifiche ProgettoModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoModificheObj = GetFromDatareader(db);
				ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoModificheObj.IsDirty = false;
				ProgettoModificheObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoModificheObj;
		}

		//getFromDatareader
		public static ProgettoModifiche GetFromDatareader(DbProvider db)
		{
			ProgettoModifiche ProgettoModificheObj = new ProgettoModifiche();
			ProgettoModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoModificheObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettoModificheObj.CodAgea = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AGEA"]);
			ProgettoModificheObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
			ProgettoModificheObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			ProgettoModificheObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoModificheObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoModificheObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoModificheObj.Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
			ProgettoModificheObj.Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
			ProgettoModificheObj.Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
			ProgettoModificheObj.DataRi = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RI"]);
			ProgettoModificheObj.OperatoreRi = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_RI"]);
			ProgettoModificheObj.SegnaturaRi = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RI"]);
			ProgettoModificheObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			ProgettoModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			ProgettoModificheObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			ProgettoModificheObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			ProgettoModificheObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			ProgettoModificheObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
			ProgettoModificheObj.FlagPreadesione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PREADESIONE"]);
			ProgettoModificheObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
			ProgettoModificheObj.IdFascicolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO"]);
			ProgettoModificheObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
			ProgettoModificheObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			ProgettoModificheObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ProgettoModificheObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			ProgettoModificheObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ProgettoModificheObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ProgettoModificheObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ProgettoModificheObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoModificheObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			ProgettoModificheObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			ProgettoModificheObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProgettoModificheObj.RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
			ProgettoModificheObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
			ProgettoModificheObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			ProgettoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoModificheObj.IsDirty = false;
			ProgettoModificheObj.IsPersistent = true;
			return ProgettoModificheObj;
		}

		//Find Select

		public static ProgettoModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodAgeaEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT RevisioneEqualThis, 
SiarLibrary.NullTypes.BoolNT RiesameEqualThis, SiarLibrary.NullTypes.BoolNT RicorsoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRiEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreRiEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRiEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqualThis, SiarLibrary.NullTypes.StringNT FaseEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineFaseEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, SiarLibrary.NullTypes.BoolNT FlagPreadesioneEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.StringNT NominativoEqualThis, 
SiarLibrary.NullTypes.StringNT EnteEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.BoolNT RiaperturaProvincialeEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis, 
SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			ProgettoModificheCollection ProgettoModificheCollectionObj = new ProgettoModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettomodifichefindselect", new string[] {"IdProgettoequalthis", "IdBandoequalthis", "CodAgeaequalthis", 
"SegnaturaAllegatiequalthis", "CodStatoequalthis", "Dataequalthis", 
"Operatoreequalthis", "Segnaturaequalthis", "Revisioneequalthis", 
"Riesameequalthis", "Ricorsoequalthis", "DataRiequalthis", 
"OperatoreRiequalthis", "SegnaturaRiequalthis", "Statoequalthis", 
"CodFaseequalthis", "OrdineStatoequalthis", "Faseequalthis", 
"OrdineFaseequalthis", "IdProgIntegratoequalthis", "FlagPreadesioneequalthis", 
"FlagDefinitivoequalthis", "IdFascicoloequalthis", "ProvinciaDiPresentazioneequalthis", 
"SelezionataXRevisioneequalthis", "IdImpresaequalthis", "IdStoricoUltimoequalthis", 
"DataCreazioneequalthis", "OperatoreCreazioneequalthis", "Nominativoequalthis", 
"Enteequalthis", "CodEnteequalthis", "Provinciaequalthis", 
"CodTipoEnteequalthis", "RiaperturaProvincialeequalthis", "FirmaPredispostaequalthis", 
"IdAttoequalthis", "Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"int", "string", "bool", 
"bool", "bool", "DateTime", 
"int", "string", "string", 
"string", "int", "string", 
"int", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "string", 
"string", "string", "string", 
"string", "bool", "bool", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAgeaequalthis", CodAgeaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Revisioneequalthis", RevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Riesameequalthis", RiesameEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ricorsoequalthis", RicorsoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRiequalthis", DataRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreRiequalthis", OperatoreRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRiequalthis", SegnaturaRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineStatoequalthis", OrdineStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Faseequalthis", FaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFaseequalthis", OrdineFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgIntegratoequalthis", IdProgIntegratoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagPreadesioneequalthis", FlagPreadesioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagDefinitivoequalthis", FlagDefinitivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFascicoloequalthis", IdFascicoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaDiPresentazioneequalthis", ProvinciaDiPresentazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nominativoequalthis", NominativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Enteequalthis", EnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiaperturaProvincialeequalthis", RiaperturaProvincialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			ProgettoModifiche ProgettoModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoModificheObj = GetFromDatareader(db);
				ProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoModificheObj.IsDirty = false;
				ProgettoModificheObj.IsPersistent = true;
				ProgettoModificheCollectionObj.Add(ProgettoModificheObj);
			}
			db.Close();
			return ProgettoModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoModificheCollectionProvider:IProgettoModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoModificheCollectionProvider : IProgettoModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoModifiche
		protected ProgettoModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoModificheCollection(this);
		}

		//Costruttore3: ha in input progettomodificheCollectionObj - non popola la collection
		public ProgettoModificheCollectionProvider(ProgettoModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoModificheCollection(this);
		}

		//Get e Set
		public ProgettoModificheCollection CollectionObj
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
		public int SaveCollection(ProgettoModificheCollection collectionObj)
		{
			return ProgettoModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoModifiche progettomodificheObj)
		{
			return ProgettoModificheDAL.Save(_dbProviderObj, progettomodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoModificheCollection collectionObj)
		{
			return ProgettoModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoModifiche progettomodificheObj)
		{
			return ProgettoModificheDAL.Delete(_dbProviderObj, progettomodificheObj);
		}

		//getById
		public ProgettoModifiche GetById(IntNT IdValue)
		{
			ProgettoModifiche ProgettoModificheTemp = ProgettoModificheDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoModificheTemp!=null) ProgettoModificheTemp.Provider = this;
			return ProgettoModificheTemp;
		}

		//Select: popola la collection
		public ProgettoModificheCollection Select(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, StringNT CodageaEqualThis, 
StringNT SegnaturaallegatiEqualThis, StringNT CodstatoEqualThis, DatetimeNT DataEqualThis, 
IntNT OperatoreEqualThis, StringNT SegnaturaEqualThis, BoolNT RevisioneEqualThis, 
BoolNT RiesameEqualThis, BoolNT RicorsoEqualThis, DatetimeNT DatariEqualThis, 
IntNT OperatoreriEqualThis, StringNT SegnaturariEqualThis, StringNT StatoEqualThis, 
StringNT CodfaseEqualThis, IntNT OrdinestatoEqualThis, StringNT FaseEqualThis, 
IntNT OrdinefaseEqualThis, IntNT IdprogintegratoEqualThis, BoolNT FlagpreadesioneEqualThis, 
BoolNT FlagdefinitivoEqualThis, IntNT IdfascicoloEqualThis, StringNT ProvinciadipresentazioneEqualThis, 
BoolNT SelezionataxrevisioneEqualThis, IntNT IdimpresaEqualThis, IntNT IdstoricoultimoEqualThis, 
DatetimeNT DatacreazioneEqualThis, IntNT OperatorecreazioneEqualThis, StringNT NominativoEqualThis, 
StringNT EnteEqualThis, StringNT CodenteEqualThis, StringNT ProvinciaEqualThis, 
StringNT CodtipoenteEqualThis, BoolNT RiaperturaprovincialeEqualThis, BoolNT FirmapredispostaEqualThis, 
IntNT IdattoEqualThis, IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			ProgettoModificheCollection ProgettoModificheCollectionTemp = ProgettoModificheDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis, CodageaEqualThis, 
SegnaturaallegatiEqualThis, CodstatoEqualThis, DataEqualThis, 
OperatoreEqualThis, SegnaturaEqualThis, RevisioneEqualThis, 
RiesameEqualThis, RicorsoEqualThis, DatariEqualThis, 
OperatoreriEqualThis, SegnaturariEqualThis, StatoEqualThis, 
CodfaseEqualThis, OrdinestatoEqualThis, FaseEqualThis, 
OrdinefaseEqualThis, IdprogintegratoEqualThis, FlagpreadesioneEqualThis, 
FlagdefinitivoEqualThis, IdfascicoloEqualThis, ProvinciadipresentazioneEqualThis, 
SelezionataxrevisioneEqualThis, IdimpresaEqualThis, IdstoricoultimoEqualThis, 
DatacreazioneEqualThis, OperatorecreazioneEqualThis, NominativoEqualThis, 
EnteEqualThis, CodenteEqualThis, ProvinciaEqualThis, 
CodtipoenteEqualThis, RiaperturaprovincialeEqualThis, FirmapredispostaEqualThis, 
IdattoEqualThis, IdEqualThis, IdmodificaEqualThis);
			ProgettoModificheCollectionTemp.Provider = this;
			return ProgettoModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_MODIFICHE>
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
</PROGETTO_MODIFICHE>
*/
