using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Progetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoProvider
	{
		int Save(Progetto ProgettoObj);
		int SaveCollection(ProgettoCollection collectionObj);
		int Delete(Progetto ProgettoObj);
		int DeleteCollection(ProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Progetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Progetto: BaseObject
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
		[NonSerialized] private IProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Progetto()
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
		/// Default:((0))
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
		/// Default:((0))
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
	/// Summary description for ProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Progetto) info.GetValue(i.ToString(),typeof(Progetto)));
			}
		}

		//Costruttore
		public ProgettoCollection()
		{
			this.ItemType = typeof(Progetto);
		}

		//Costruttore con provider
		public ProgettoCollection(IProgettoProvider providerObj)
		{
			this.ItemType = typeof(Progetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Progetto this[int index]
		{
			get { return (Progetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoCollection GetChanges()
		{
			return (ProgettoCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoProvider Provider
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
		public int Add(Progetto ProgettoObj)
		{
			if (ProgettoObj.Provider == null) ProgettoObj.Provider = this.Provider;
			return base.Add(ProgettoObj);
		}

		//AddCollection
		public void AddCollection(ProgettoCollection ProgettoCollectionObj)
		{
			foreach (Progetto ProgettoObj in ProgettoCollectionObj)
				this.Add(ProgettoObj);
		}

		//Insert
		public void Insert(int index, Progetto ProgettoObj)
		{
			if (ProgettoObj.Provider == null) ProgettoObj.Provider = this.Provider;
			base.Insert(index, ProgettoObj);
		}

		//CollectionGetById
		public Progetto CollectionGetById(NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgetto == IdProgettoValue))
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
		public ProgettoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodAgeaEqualThis, 
NullTypes.StringNT SegnaturaAllegatiEqualThis, NullTypes.IntNT IdProgIntegratoEqualThis, NullTypes.BoolNT FlagPreadesioneEqualThis, 
NullTypes.BoolNT FlagDefinitivoEqualThis, NullTypes.IntNT IdFascicoloEqualThis, NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
NullTypes.BoolNT SelezionataXRevisioneEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.BoolNT FirmaPredispostaEqualThis)
		{
			ProgettoCollection ProgettoCollectionTemp = new ProgettoCollection();
			foreach (Progetto ProgettoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((ProgettoItem.IdProgetto != null) && (ProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ProgettoItem.IdBando != null) && (ProgettoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodAgeaEqualThis == null) || ((ProgettoItem.CodAgea != null) && (ProgettoItem.CodAgea.Value == CodAgeaEqualThis.Value))) && 
((SegnaturaAllegatiEqualThis == null) || ((ProgettoItem.SegnaturaAllegati != null) && (ProgettoItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) && ((IdProgIntegratoEqualThis == null) || ((ProgettoItem.IdProgIntegrato != null) && (ProgettoItem.IdProgIntegrato.Value == IdProgIntegratoEqualThis.Value))) && ((FlagPreadesioneEqualThis == null) || ((ProgettoItem.FlagPreadesione != null) && (ProgettoItem.FlagPreadesione.Value == FlagPreadesioneEqualThis.Value))) && 
((FlagDefinitivoEqualThis == null) || ((ProgettoItem.FlagDefinitivo != null) && (ProgettoItem.FlagDefinitivo.Value == FlagDefinitivoEqualThis.Value))) && ((IdFascicoloEqualThis == null) || ((ProgettoItem.IdFascicolo != null) && (ProgettoItem.IdFascicolo.Value == IdFascicoloEqualThis.Value))) && ((ProvinciaDiPresentazioneEqualThis == null) || ((ProgettoItem.ProvinciaDiPresentazione != null) && (ProgettoItem.ProvinciaDiPresentazione.Value == ProvinciaDiPresentazioneEqualThis.Value))) && 
((SelezionataXRevisioneEqualThis == null) || ((ProgettoItem.SelezionataXRevisione != null) && (ProgettoItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ProgettoItem.IdImpresa != null) && (ProgettoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((ProgettoItem.IdStoricoUltimo != null) && (ProgettoItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((ProgettoItem.DataCreazione != null) && (ProgettoItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ProgettoItem.OperatoreCreazione != null) && (ProgettoItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((FirmaPredispostaEqualThis == null) || ((ProgettoItem.FirmaPredisposta != null) && (ProgettoItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))))
				{
					ProgettoCollectionTemp.Add(ProgettoItem);
				}
			}
			return ProgettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Progetto ProgettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoObj.IdProgetto);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", ProgettoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodAgea", ProgettoObj.CodAgea);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaAllegati", ProgettoObj.SegnaturaAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgIntegrato", ProgettoObj.IdProgIntegrato);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagPreadesione", ProgettoObj.FlagPreadesione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagDefinitivo", ProgettoObj.FlagDefinitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFascicolo", ProgettoObj.IdFascicolo);
			DbProvider.SetCmdParam(cmd,firstChar + "ProvinciaDiPresentazione", ProgettoObj.ProvinciaDiPresentazione);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXRevisione", ProgettoObj.SelezionataXRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ProgettoObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStoricoUltimo", ProgettoObj.IdStoricoUltimo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ProgettoObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ProgettoObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "FirmaPredisposta", ProgettoObj.FirmaPredisposta);
		}
		//Insert
		private static int Insert(DbProvider db, Progetto ProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoInsert", new string[] {"IdBando", "CodAgea", 
"SegnaturaAllegati", 




"IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", 

"FirmaPredisposta", }, new string[] {"int", "string", 
"string", 




"int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", 

"bool", },"");
				CompileIUCmd(false, insertCmd,ProgettoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
				ProgettoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
				ProgettoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
				}
				ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoObj.IsDirty = false;
				ProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Progetto ProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoUpdate", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", 




"IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", 

"FirmaPredisposta", }, new string[] {"int", "int", "string", 
"string", 




"int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", 

"bool", },"");
				CompileIUCmd(true, updateCmd,ProgettoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoObj.IsDirty = false;
				ProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Progetto ProgettoObj)
		{
			switch (ProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoCollection ProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoUpdate", new string[] {"IdProgetto", "IdBando", "CodAgea", 
"SegnaturaAllegati", 




"IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", 

"FirmaPredisposta", }, new string[] {"int", "int", "string", 
"string", 




"int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", 

"bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoInsert", new string[] {"IdBando", "CodAgea", 
"SegnaturaAllegati", 




"IdProgIntegrato", "FlagPreadesione", 
"FlagDefinitivo", "IdFascicolo", "ProvinciaDiPresentazione", 
"SelezionataXRevisione", "IdImpresa", "IdStoricoUltimo", 
"DataCreazione", "OperatoreCreazione", 

"FirmaPredisposta", }, new string[] {"int", "string", 
"string", 




"int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", 

"bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoDelete", new string[] {"IdProgetto"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoCollectionObj.Count; i++)
				{
					switch (ProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoCollectionObj[i].IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
									ProgettoCollectionObj[i].SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
									ProgettoCollectionObj[i].FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)ProgettoCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoCollectionObj.Count; i++)
				{
					if ((ProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoCollectionObj[i].IsDirty = false;
						ProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoCollectionObj[i].IsDirty = false;
						ProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Progetto ProgettoObj)
		{
			int returnValue = 0;
			if (ProgettoObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoObj.IdProgetto);
			}
			ProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoObj.IsDirty = false;
			ProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoDelete", new string[] {"IdProgetto"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoCollection ProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoDelete", new string[] {"IdProgetto"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", ProgettoCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoCollectionObj.Count; i++)
				{
					if ((ProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoCollectionObj[i].IsDirty = false;
						ProgettoCollectionObj[i].IsPersistent = false;
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
		public static Progetto GetById(DbProvider db, int IdProgettoValue)
		{
			Progetto ProgettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoGetById", new string[] {"IdProgetto"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoObj = GetFromDatareader(db);
				ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoObj.IsDirty = false;
				ProgettoObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoObj;
		}

		//getFromDatareader
		public static Progetto GetFromDatareader(DbProvider db)
		{
			Progetto ProgettoObj = new Progetto();
			ProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettoObj.CodAgea = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AGEA"]);
			ProgettoObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
			ProgettoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			ProgettoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoObj.Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
			ProgettoObj.Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
			ProgettoObj.Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
			ProgettoObj.DataRi = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RI"]);
			ProgettoObj.OperatoreRi = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_RI"]);
			ProgettoObj.SegnaturaRi = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RI"]);
			ProgettoObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			ProgettoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			ProgettoObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			ProgettoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			ProgettoObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			ProgettoObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
			ProgettoObj.FlagPreadesione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_PREADESIONE"]);
			ProgettoObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
			ProgettoObj.IdFascicolo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO"]);
			ProgettoObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
			ProgettoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			ProgettoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ProgettoObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
			ProgettoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ProgettoObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ProgettoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ProgettoObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			ProgettoObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			ProgettoObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProgettoObj.RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
			ProgettoObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
			ProgettoObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoObj.IsDirty = false;
			ProgettoObj.IsPersistent = true;
			return ProgettoObj;
		}

		//Find Select

		public static ProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodAgeaEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, SiarLibrary.NullTypes.BoolNT FlagPreadesioneEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis)

		{

			ProgettoCollection ProgettoCollectionObj = new ProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettofindselect", new string[] {"IdProgettoequalthis", "IdBandoequalthis", "CodAgeaequalthis", 
"SegnaturaAllegatiequalthis", "IdProgIntegratoequalthis", "FlagPreadesioneequalthis", 
"FlagDefinitivoequalthis", "IdFascicoloequalthis", "ProvinciaDiPresentazioneequalthis", 
"SelezionataXRevisioneequalthis", "IdImpresaequalthis", "IdStoricoUltimoequalthis", 
"DataCreazioneequalthis", "OperatoreCreazioneequalthis", "FirmaPredispostaequalthis"}, new string[] {"int", "int", "string", 
"string", "int", "bool", 
"bool", "int", "string", 
"bool", "int", "int", 
"DateTime", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAgeaequalthis", CodAgeaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
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
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
			Progetto ProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoObj = GetFromDatareader(db);
				ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoObj.IsDirty = false;
				ProgettoObj.IsPersistent = true;
				ProgettoCollectionObj.Add(ProgettoObj);
			}
			db.Close();
			return ProgettoCollectionObj;
		}

		//Find Find

		public static ProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.BoolNT FlagPreadesioneEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis)

		{

			ProgettoCollection ProgettoCollectionObj = new ProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettofindfind", new string[] {"IdBandoequalthis", "IdImpresaequalthis", "IdProgIntegratoequalthis", 
"CodStatoequalthis", "CodFaseequalthis", "FlagPreadesioneequalthis", 
"FlagDefinitivoequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgIntegratoequalthis", IdProgIntegratoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagPreadesioneequalthis", FlagPreadesioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagDefinitivoequalthis", FlagDefinitivoEqualThis);
			Progetto ProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoObj = GetFromDatareader(db);
				ProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoObj.IsDirty = false;
				ProgettoObj.IsPersistent = true;
				ProgettoCollectionObj.Add(ProgettoObj);
			}
			db.Close();
			return ProgettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoCollectionProvider:IProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoCollectionProvider : IProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Progetto
		protected ProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogintegratoEqualThis, 
StringNT CodstatoEqualThis, StringNT CodfaseEqualThis, BoolNT FlagpreadesioneEqualThis, 
BoolNT FlagdefinitivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdimpresaEqualThis, IdprogintegratoEqualThis, 
CodstatoEqualThis, CodfaseEqualThis, FlagpreadesioneEqualThis, 
FlagdefinitivoEqualThis);
		}

		//Costruttore3: ha in input progettoCollectionObj - non popola la collection
		public ProgettoCollectionProvider(ProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoCollection(this);
		}

		//Get e Set
		public ProgettoCollection CollectionObj
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
		public int SaveCollection(ProgettoCollection collectionObj)
		{
			return ProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Progetto progettoObj)
		{
			return ProgettoDAL.Save(_dbProviderObj, progettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoCollection collectionObj)
		{
			return ProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Progetto progettoObj)
		{
			return ProgettoDAL.Delete(_dbProviderObj, progettoObj);
		}

		//getById
		public Progetto GetById(IntNT IdProgettoValue)
		{
			Progetto ProgettoTemp = ProgettoDAL.GetById(_dbProviderObj, IdProgettoValue);
			if (ProgettoTemp!=null) ProgettoTemp.Provider = this;
			return ProgettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoCollection Select(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, StringNT CodageaEqualThis, 
StringNT SegnaturaallegatiEqualThis, IntNT IdprogintegratoEqualThis, BoolNT FlagpreadesioneEqualThis, 
BoolNT FlagdefinitivoEqualThis, IntNT IdfascicoloEqualThis, StringNT ProvinciadipresentazioneEqualThis, 
BoolNT SelezionataxrevisioneEqualThis, IntNT IdimpresaEqualThis, IntNT IdstoricoultimoEqualThis, 
DatetimeNT DatacreazioneEqualThis, IntNT OperatorecreazioneEqualThis, BoolNT FirmapredispostaEqualThis)
		{
			ProgettoCollection ProgettoCollectionTemp = ProgettoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis, CodageaEqualThis, 
SegnaturaallegatiEqualThis, IdprogintegratoEqualThis, FlagpreadesioneEqualThis, 
FlagdefinitivoEqualThis, IdfascicoloEqualThis, ProvinciadipresentazioneEqualThis, 
SelezionataxrevisioneEqualThis, IdimpresaEqualThis, IdstoricoultimoEqualThis, 
DatacreazioneEqualThis, OperatorecreazioneEqualThis, FirmapredispostaEqualThis);
			ProgettoCollectionTemp.Provider = this;
			return ProgettoCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoCollection Find(IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogintegratoEqualThis, 
StringNT CodstatoEqualThis, StringNT CodfaseEqualThis, BoolNT FlagpreadesioneEqualThis, 
BoolNT FlagdefinitivoEqualThis)
		{
			ProgettoCollection ProgettoCollectionTemp = ProgettoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdimpresaEqualThis, IdprogintegratoEqualThis, 
CodstatoEqualThis, CodfaseEqualThis, FlagpreadesioneEqualThis, 
FlagdefinitivoEqualThis);
			ProgettoCollectionTemp.Provider = this;
			return ProgettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO>
  <ViewName>vPROGETTO</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROG_INTEGRATO>Equal</ID_PROG_INTEGRATO>
      <COD_STATO>Equal</COD_STATO>
      <COD_FASE>Equal</COD_FASE>
      <FLAG_PREADESIONE>Equal</FLAG_PREADESIONE>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO>
*/
