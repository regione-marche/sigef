using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidLiquidazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidLiquidazioniProvider
	{
		int Save(CovidLiquidazioni CovidLiquidazioniObj);
		int SaveCollection(CovidLiquidazioniCollection collectionObj);
		int Delete(CovidLiquidazioni CovidLiquidazioniObj);
		int DeleteCollection(CovidLiquidazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidLiquidazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidLiquidazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Capitolo;
		private NullTypes.StringNT _AnnoImp;
		private NullTypes.StringNT _AnnoSubimp;
		private NullTypes.StringNT _DescrizioneImpSubimp;
		private NullTypes.StringNT _SistemaOrigine;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.StringNT _DurcRegolare;
		private NullTypes.StringNT _CodiceCor;
		private NullTypes.StringNT _AnnoProposta;
		private NullTypes.StringNT _UnitaProponente;
		private NullTypes.StringNT _NumeroProposta;
		private NullTypes.StringNT _Transazione;
		private NullTypes.StringNT _CodiceRitenuta;
		private NullTypes.DecimalNT _ImponibileRitenuta;
		private NullTypes.DecimalNT _AliquotaRitenuta;
		private NullTypes.DecimalNT _ImportoRitenute;
		private NullTypes.StringNT _CausaleIrpef;
		private NullTypes.IntNT _Progressivo;
		private NullTypes.StringNT _ControlloEquitalia;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _Ufficio;
		private NullTypes.StringNT _Bollo;
		private NullTypes.DatetimeNT _DataInsert;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _DescrizioneInterventoSostitutivo;
		[NonSerialized] private ICovidLiquidazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidLiquidazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CovidLiquidazioni()
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
		/// Corrisponde al campo:CAPITOLO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Capitolo
		{
			get { return _Capitolo; }
			set {
				if (Capitolo != value)
				{
					_Capitolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_IMP
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoImp
		{
			get { return _AnnoImp; }
			set {
				if (AnnoImp != value)
				{
					_AnnoImp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_SUBIMP
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoSubimp
		{
			get { return _AnnoSubimp; }
			set {
				if (AnnoSubimp != value)
				{
					_AnnoSubimp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_IMP_SUBIMP
		/// Tipo sul db:VARCHAR(140)
		/// </summary>
		public NullTypes.StringNT DescrizioneImpSubimp
		{
			get { return _DescrizioneImpSubimp; }
			set {
				if (DescrizioneImpSubimp != value)
				{
					_DescrizioneImpSubimp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SISTEMA_ORIGINE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT SistemaOrigine
		{
			get { return _SistemaOrigine; }
			set {
				if (SistemaOrigine != value)
				{
					_SistemaOrigine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(20,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURC_REGOLARE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT DurcRegolare
		{
			get { return _DurcRegolare; }
			set {
				if (DurcRegolare != value)
				{
					_DurcRegolare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_COR
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodiceCor
		{
			get { return _CodiceCor; }
			set {
				if (CodiceCor != value)
				{
					_CodiceCor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_PROPOSTA
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoProposta
		{
			get { return _AnnoProposta; }
			set {
				if (AnnoProposta != value)
				{
					_AnnoProposta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UNITA_PROPONENTE
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT UnitaProponente
		{
			get { return _UnitaProponente; }
			set {
				if (UnitaProponente != value)
				{
					_UnitaProponente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROPOSTA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT NumeroProposta
		{
			get { return _NumeroProposta; }
			set {
				if (NumeroProposta != value)
				{
					_NumeroProposta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TRANSAZIONE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Transazione
		{
			get { return _Transazione; }
			set {
				if (Transazione != value)
				{
					_Transazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_RITENUTA
		/// Tipo sul db:VARCHAR(32)
		/// </summary>
		public NullTypes.StringNT CodiceRitenuta
		{
			get { return _CodiceRitenuta; }
			set {
				if (CodiceRitenuta != value)
				{
					_CodiceRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPONIBILE_RITENUTA
		/// Tipo sul db:DECIMAL(20,2)
		/// </summary>
		public NullTypes.DecimalNT ImponibileRitenuta
		{
			get { return _ImponibileRitenuta; }
			set {
				if (ImponibileRitenuta != value)
				{
					_ImponibileRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALIQUOTA_RITENUTA
		/// Tipo sul db:DECIMAL(20,2)
		/// </summary>
		public NullTypes.DecimalNT AliquotaRitenuta
		{
			get { return _AliquotaRitenuta; }
			set {
				if (AliquotaRitenuta != value)
				{
					_AliquotaRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RITENUTE
		/// Tipo sul db:DECIMAL(20,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRitenute
		{
			get { return _ImportoRitenute; }
			set {
				if (ImportoRitenute != value)
				{
					_ImportoRitenute = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAUSALE_IRPEF
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT CausaleIrpef
		{
			get { return _CausaleIrpef; }
			set {
				if (CausaleIrpef != value)
				{
					_CausaleIrpef = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGRESSIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Progressivo
		{
			get { return _Progressivo; }
			set {
				if (Progressivo != value)
				{
					_Progressivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTROLLO_EQUITALIA
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT ControlloEquitalia
		{
			get { return _ControlloEquitalia; }
			set {
				if (ControlloEquitalia != value)
				{
					_ControlloEquitalia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UFFICIO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Ufficio
		{
			get { return _Ufficio; }
			set {
				if (Ufficio != value)
				{
					_Ufficio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:BOLLO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Bollo
		{
			get { return _Bollo; }
			set {
				if (Bollo != value)
				{
					_Bollo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERT
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInsert
		{
			get { return _DataInsert; }
			set {
				if (DataInsert != value)
				{
					_DataInsert = value;
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
		/// Corrisponde al campo:DESCRIZIONE_INTERVENTO_SOSTITUTIVO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneInterventoSostitutivo
		{
			get { return _DescrizioneInterventoSostitutivo; }
			set {
				if (DescrizioneInterventoSostitutivo != value)
				{
					_DescrizioneInterventoSostitutivo = value;
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
	/// Summary description for CovidLiquidazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidLiquidazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CovidLiquidazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CovidLiquidazioni) info.GetValue(i.ToString(),typeof(CovidLiquidazioni)));
			}
		}

		//Costruttore
		public CovidLiquidazioniCollection()
		{
			this.ItemType = typeof(CovidLiquidazioni);
		}

		//Costruttore con provider
		public CovidLiquidazioniCollection(ICovidLiquidazioniProvider providerObj)
		{
			this.ItemType = typeof(CovidLiquidazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidLiquidazioni this[int index]
		{
			get { return (CovidLiquidazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidLiquidazioniCollection GetChanges()
		{
			return (CovidLiquidazioniCollection) base.GetChanges();
		}

		[NonSerialized] private ICovidLiquidazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidLiquidazioniProvider Provider
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
		public int Add(CovidLiquidazioni CovidLiquidazioniObj)
		{
			if (CovidLiquidazioniObj.Provider == null) CovidLiquidazioniObj.Provider = this.Provider;
			return base.Add(CovidLiquidazioniObj);
		}

		//AddCollection
		public void AddCollection(CovidLiquidazioniCollection CovidLiquidazioniCollectionObj)
		{
			foreach (CovidLiquidazioni CovidLiquidazioniObj in CovidLiquidazioniCollectionObj)
				this.Add(CovidLiquidazioniObj);
		}

		//Insert
		public void Insert(int index, CovidLiquidazioni CovidLiquidazioniObj)
		{
			if (CovidLiquidazioniObj.Provider == null) CovidLiquidazioniObj.Provider = this.Provider;
			base.Insert(index, CovidLiquidazioniObj);
		}

		//CollectionGetById
		public CovidLiquidazioni CollectionGetById(NullTypes.IntNT IdValue)
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
		public CovidLiquidazioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CapitoloEqualThis, NullTypes.StringNT AnnoImpEqualThis, 
NullTypes.StringNT AnnoSubimpEqualThis, NullTypes.StringNT DescrizioneImpSubimpEqualThis, NullTypes.StringNT SistemaOrigineEqualThis, 
NullTypes.IntNT IdDomandaEqualThis, NullTypes.DecimalNT ImportoEqualThis, NullTypes.StringNT DurcRegolareEqualThis, 
NullTypes.StringNT CodiceCorEqualThis, NullTypes.StringNT AnnoPropostaEqualThis, NullTypes.StringNT UnitaProponenteEqualThis, 
NullTypes.StringNT NumeroPropostaEqualThis, NullTypes.StringNT TransazioneEqualThis, NullTypes.StringNT CodiceRitenutaEqualThis, 
NullTypes.DecimalNT ImponibileRitenutaEqualThis, NullTypes.DecimalNT AliquotaRitenutaEqualThis, NullTypes.DecimalNT ImportoRitenuteEqualThis, 
NullTypes.StringNT CausaleIrpefEqualThis, NullTypes.IntNT ProgressivoEqualThis, NullTypes.StringNT ControlloEquitaliaEqualThis, 
NullTypes.StringNT NoteEqualThis, NullTypes.StringNT UfficioEqualThis, NullTypes.StringNT BolloEqualThis, 
NullTypes.DatetimeNT DataInsertEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneInterventoSostitutivoEqualThis)
		{
			CovidLiquidazioniCollection CovidLiquidazioniCollectionTemp = new CovidLiquidazioniCollection();
			foreach (CovidLiquidazioni CovidLiquidazioniItem in this)
			{
				if (((IdEqualThis == null) || ((CovidLiquidazioniItem.Id != null) && (CovidLiquidazioniItem.Id.Value == IdEqualThis.Value))) && ((CapitoloEqualThis == null) || ((CovidLiquidazioniItem.Capitolo != null) && (CovidLiquidazioniItem.Capitolo.Value == CapitoloEqualThis.Value))) && ((AnnoImpEqualThis == null) || ((CovidLiquidazioniItem.AnnoImp != null) && (CovidLiquidazioniItem.AnnoImp.Value == AnnoImpEqualThis.Value))) && 
((AnnoSubimpEqualThis == null) || ((CovidLiquidazioniItem.AnnoSubimp != null) && (CovidLiquidazioniItem.AnnoSubimp.Value == AnnoSubimpEqualThis.Value))) && ((DescrizioneImpSubimpEqualThis == null) || ((CovidLiquidazioniItem.DescrizioneImpSubimp != null) && (CovidLiquidazioniItem.DescrizioneImpSubimp.Value == DescrizioneImpSubimpEqualThis.Value))) && ((SistemaOrigineEqualThis == null) || ((CovidLiquidazioniItem.SistemaOrigine != null) && (CovidLiquidazioniItem.SistemaOrigine.Value == SistemaOrigineEqualThis.Value))) && 
((IdDomandaEqualThis == null) || ((CovidLiquidazioniItem.IdDomanda != null) && (CovidLiquidazioniItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((ImportoEqualThis == null) || ((CovidLiquidazioniItem.Importo != null) && (CovidLiquidazioniItem.Importo.Value == ImportoEqualThis.Value))) && ((DurcRegolareEqualThis == null) || ((CovidLiquidazioniItem.DurcRegolare != null) && (CovidLiquidazioniItem.DurcRegolare.Value == DurcRegolareEqualThis.Value))) && 
((CodiceCorEqualThis == null) || ((CovidLiquidazioniItem.CodiceCor != null) && (CovidLiquidazioniItem.CodiceCor.Value == CodiceCorEqualThis.Value))) && ((AnnoPropostaEqualThis == null) || ((CovidLiquidazioniItem.AnnoProposta != null) && (CovidLiquidazioniItem.AnnoProposta.Value == AnnoPropostaEqualThis.Value))) && ((UnitaProponenteEqualThis == null) || ((CovidLiquidazioniItem.UnitaProponente != null) && (CovidLiquidazioniItem.UnitaProponente.Value == UnitaProponenteEqualThis.Value))) && 
((NumeroPropostaEqualThis == null) || ((CovidLiquidazioniItem.NumeroProposta != null) && (CovidLiquidazioniItem.NumeroProposta.Value == NumeroPropostaEqualThis.Value))) && ((TransazioneEqualThis == null) || ((CovidLiquidazioniItem.Transazione != null) && (CovidLiquidazioniItem.Transazione.Value == TransazioneEqualThis.Value))) && ((CodiceRitenutaEqualThis == null) || ((CovidLiquidazioniItem.CodiceRitenuta != null) && (CovidLiquidazioniItem.CodiceRitenuta.Value == CodiceRitenutaEqualThis.Value))) && 
((ImponibileRitenutaEqualThis == null) || ((CovidLiquidazioniItem.ImponibileRitenuta != null) && (CovidLiquidazioniItem.ImponibileRitenuta.Value == ImponibileRitenutaEqualThis.Value))) && ((AliquotaRitenutaEqualThis == null) || ((CovidLiquidazioniItem.AliquotaRitenuta != null) && (CovidLiquidazioniItem.AliquotaRitenuta.Value == AliquotaRitenutaEqualThis.Value))) && ((ImportoRitenuteEqualThis == null) || ((CovidLiquidazioniItem.ImportoRitenute != null) && (CovidLiquidazioniItem.ImportoRitenute.Value == ImportoRitenuteEqualThis.Value))) && 
((CausaleIrpefEqualThis == null) || ((CovidLiquidazioniItem.CausaleIrpef != null) && (CovidLiquidazioniItem.CausaleIrpef.Value == CausaleIrpefEqualThis.Value))) && ((ProgressivoEqualThis == null) || ((CovidLiquidazioniItem.Progressivo != null) && (CovidLiquidazioniItem.Progressivo.Value == ProgressivoEqualThis.Value))) && ((ControlloEquitaliaEqualThis == null) || ((CovidLiquidazioniItem.ControlloEquitalia != null) && (CovidLiquidazioniItem.ControlloEquitalia.Value == ControlloEquitaliaEqualThis.Value))) && 
((NoteEqualThis == null) || ((CovidLiquidazioniItem.Note != null) && (CovidLiquidazioniItem.Note.Value == NoteEqualThis.Value))) && ((UfficioEqualThis == null) || ((CovidLiquidazioniItem.Ufficio != null) && (CovidLiquidazioniItem.Ufficio.Value == UfficioEqualThis.Value))) && ((BolloEqualThis == null) || ((CovidLiquidazioniItem.Bollo != null) && (CovidLiquidazioniItem.Bollo.Value == BolloEqualThis.Value))) && 
((DataInsertEqualThis == null) || ((CovidLiquidazioniItem.DataInsert != null) && (CovidLiquidazioniItem.DataInsert.Value == DataInsertEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CovidLiquidazioniItem.IdBando != null) && (CovidLiquidazioniItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneInterventoSostitutivoEqualThis == null) || ((CovidLiquidazioniItem.DescrizioneInterventoSostitutivo != null) && (CovidLiquidazioniItem.DescrizioneInterventoSostitutivo.Value == DescrizioneInterventoSostitutivoEqualThis.Value))))
				{
					CovidLiquidazioniCollectionTemp.Add(CovidLiquidazioniItem);
				}
			}
			return CovidLiquidazioniCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CovidLiquidazioniCollection Filter(NullTypes.IntNT ProgressivoEqualThis)
		{
			CovidLiquidazioniCollection CovidLiquidazioniCollectionTemp = new CovidLiquidazioniCollection();
			foreach (CovidLiquidazioni CovidLiquidazioniItem in this)
			{
				if (((ProgressivoEqualThis == null) || ((CovidLiquidazioniItem.Progressivo != null) && (CovidLiquidazioniItem.Progressivo.Value == ProgressivoEqualThis.Value))))
				{
					CovidLiquidazioniCollectionTemp.Add(CovidLiquidazioniItem);
				}
			}
			return CovidLiquidazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidLiquidazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidLiquidazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidLiquidazioni CovidLiquidazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CovidLiquidazioniObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Capitolo", CovidLiquidazioniObj.Capitolo);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoImp", CovidLiquidazioniObj.AnnoImp);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoSubimp", CovidLiquidazioniObj.AnnoSubimp);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneImpSubimp", CovidLiquidazioniObj.DescrizioneImpSubimp);
			DbProvider.SetCmdParam(cmd,firstChar + "SistemaOrigine", CovidLiquidazioniObj.SistemaOrigine);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", CovidLiquidazioniObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", CovidLiquidazioniObj.Importo);
			DbProvider.SetCmdParam(cmd,firstChar + "DurcRegolare", CovidLiquidazioniObj.DurcRegolare);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceCor", CovidLiquidazioniObj.CodiceCor);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoProposta", CovidLiquidazioniObj.AnnoProposta);
			DbProvider.SetCmdParam(cmd,firstChar + "UnitaProponente", CovidLiquidazioniObj.UnitaProponente);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProposta", CovidLiquidazioniObj.NumeroProposta);
			DbProvider.SetCmdParam(cmd,firstChar + "Transazione", CovidLiquidazioniObj.Transazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceRitenuta", CovidLiquidazioniObj.CodiceRitenuta);
			DbProvider.SetCmdParam(cmd,firstChar + "ImponibileRitenuta", CovidLiquidazioniObj.ImponibileRitenuta);
			DbProvider.SetCmdParam(cmd,firstChar + "AliquotaRitenuta", CovidLiquidazioniObj.AliquotaRitenuta);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoRitenute", CovidLiquidazioniObj.ImportoRitenute);
			DbProvider.SetCmdParam(cmd,firstChar + "CausaleIrpef", CovidLiquidazioniObj.CausaleIrpef);
			DbProvider.SetCmdParam(cmd,firstChar + "Progressivo", CovidLiquidazioniObj.Progressivo);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloEquitalia", CovidLiquidazioniObj.ControlloEquitalia);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", CovidLiquidazioniObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Ufficio", CovidLiquidazioniObj.Ufficio);
			DbProvider.SetCmdParam(cmd,firstChar + "Bollo", CovidLiquidazioniObj.Bollo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInsert", CovidLiquidazioniObj.DataInsert);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CovidLiquidazioniObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneInterventoSostitutivo", CovidLiquidazioniObj.DescrizioneInterventoSostitutivo);
		}
		//Insert
		private static int Insert(DbProvider db, CovidLiquidazioni CovidLiquidazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCovidLiquidazioniInsert", new string[] {"Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "SistemaOrigine", 
"IdDomanda", "Importo", "DurcRegolare", 
"CodiceCor", "AnnoProposta", "UnitaProponente", 
"NumeroProposta", "Transazione", "CodiceRitenuta", 
"ImponibileRitenuta", "AliquotaRitenuta", "ImportoRitenute", 
"CausaleIrpef", "Progressivo", "ControlloEquitalia", 
"Note", "Ufficio", "Bollo", 
"DataInsert", "IdBando", "DescrizioneInterventoSostitutivo"}, new string[] {"string", "string", 
"string", "string", "string", 
"int", "decimal", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"string", "int", "string", 
"string", "string", "string", 
"DateTime", "int", "string"},"");
				CompileIUCmd(false, insertCmd,CovidLiquidazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CovidLiquidazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidLiquidazioniObj.IsDirty = false;
				CovidLiquidazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidLiquidazioni CovidLiquidazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidLiquidazioniUpdate", new string[] {"Id", "Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "SistemaOrigine", 
"IdDomanda", "Importo", "DurcRegolare", 
"CodiceCor", "AnnoProposta", "UnitaProponente", 
"NumeroProposta", "Transazione", "CodiceRitenuta", 
"ImponibileRitenuta", "AliquotaRitenuta", "ImportoRitenute", 
"CausaleIrpef", "Progressivo", "ControlloEquitalia", 
"Note", "Ufficio", "Bollo", 
"DataInsert", "IdBando", "DescrizioneInterventoSostitutivo"}, new string[] {"int", "string", "string", 
"string", "string", "string", 
"int", "decimal", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"string", "int", "string", 
"string", "string", "string", 
"DateTime", "int", "string"},"");
				CompileIUCmd(true, updateCmd,CovidLiquidazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidLiquidazioniObj.IsDirty = false;
				CovidLiquidazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidLiquidazioni CovidLiquidazioniObj)
		{
			switch (CovidLiquidazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CovidLiquidazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CovidLiquidazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CovidLiquidazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidLiquidazioniCollection CovidLiquidazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidLiquidazioniUpdate", new string[] {"Id", "Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "SistemaOrigine", 
"IdDomanda", "Importo", "DurcRegolare", 
"CodiceCor", "AnnoProposta", "UnitaProponente", 
"NumeroProposta", "Transazione", "CodiceRitenuta", 
"ImponibileRitenuta", "AliquotaRitenuta", "ImportoRitenute", 
"CausaleIrpef", "Progressivo", "ControlloEquitalia", 
"Note", "Ufficio", "Bollo", 
"DataInsert", "IdBando", "DescrizioneInterventoSostitutivo"}, new string[] {"int", "string", "string", 
"string", "string", "string", 
"int", "decimal", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"string", "int", "string", 
"string", "string", "string", 
"DateTime", "int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCovidLiquidazioniInsert", new string[] {"Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "SistemaOrigine", 
"IdDomanda", "Importo", "DurcRegolare", 
"CodiceCor", "AnnoProposta", "UnitaProponente", 
"NumeroProposta", "Transazione", "CodiceRitenuta", 
"ImponibileRitenuta", "AliquotaRitenuta", "ImportoRitenute", 
"CausaleIrpef", "Progressivo", "ControlloEquitalia", 
"Note", "Ufficio", "Bollo", 
"DataInsert", "IdBando", "DescrizioneInterventoSostitutivo"}, new string[] {"string", "string", 
"string", "string", "string", 
"int", "decimal", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"string", "int", "string", 
"string", "string", "string", 
"DateTime", "int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCovidLiquidazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CovidLiquidazioniCollectionObj.Count; i++)
				{
					switch (CovidLiquidazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CovidLiquidazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidLiquidazioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CovidLiquidazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CovidLiquidazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CovidLiquidazioniCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidLiquidazioniCollectionObj.Count; i++)
				{
					if ((CovidLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidLiquidazioniCollectionObj[i].IsDirty = false;
						CovidLiquidazioniCollectionObj[i].IsPersistent = true;
					}
					if ((CovidLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidLiquidazioniCollectionObj[i].IsDirty = false;
						CovidLiquidazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CovidLiquidazioni CovidLiquidazioniObj)
		{
			int returnValue = 0;
			if (CovidLiquidazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, CovidLiquidazioniObj.Id);
			}
			CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidLiquidazioniObj.IsDirty = false;
			CovidLiquidazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidLiquidazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidLiquidazioniCollection CovidLiquidazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidLiquidazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CovidLiquidazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CovidLiquidazioniCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidLiquidazioniCollectionObj.Count; i++)
				{
					if ((CovidLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidLiquidazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidLiquidazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidLiquidazioniCollectionObj[i].IsDirty = false;
						CovidLiquidazioniCollectionObj[i].IsPersistent = false;
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
		public static CovidLiquidazioni GetById(DbProvider db, int IdValue)
		{
			CovidLiquidazioni CovidLiquidazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCovidLiquidazioniGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidLiquidazioniObj = GetFromDatareader(db);
				CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidLiquidazioniObj.IsDirty = false;
				CovidLiquidazioniObj.IsPersistent = true;
			}
			db.Close();
			return CovidLiquidazioniObj;
		}

		//getFromDatareader
		public static CovidLiquidazioni GetFromDatareader(DbProvider db)
		{
			CovidLiquidazioni CovidLiquidazioniObj = new CovidLiquidazioni();
			CovidLiquidazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CovidLiquidazioniObj.Capitolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAPITOLO"]);
			CovidLiquidazioniObj.AnnoImp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_IMP"]);
			CovidLiquidazioniObj.AnnoSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_SUBIMP"]);
			CovidLiquidazioniObj.DescrizioneImpSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_IMP_SUBIMP"]);
			CovidLiquidazioniObj.SistemaOrigine = new SiarLibrary.NullTypes.StringNT(db.DataReader["SISTEMA_ORIGINE"]);
			CovidLiquidazioniObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			CovidLiquidazioniObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			CovidLiquidazioniObj.DurcRegolare = new SiarLibrary.NullTypes.StringNT(db.DataReader["DURC_REGOLARE"]);
			CovidLiquidazioniObj.CodiceCor = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_COR"]);
			CovidLiquidazioniObj.AnnoProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_PROPOSTA"]);
			CovidLiquidazioniObj.UnitaProponente = new SiarLibrary.NullTypes.StringNT(db.DataReader["UNITA_PROPONENTE"]);
			CovidLiquidazioniObj.NumeroProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROPOSTA"]);
			CovidLiquidazioniObj.Transazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRANSAZIONE"]);
			CovidLiquidazioniObj.CodiceRitenuta = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_RITENUTA"]);
			CovidLiquidazioniObj.ImponibileRitenuta = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_RITENUTA"]);
			CovidLiquidazioniObj.AliquotaRitenuta = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALIQUOTA_RITENUTA"]);
			CovidLiquidazioniObj.ImportoRitenute = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RITENUTE"]);
			CovidLiquidazioniObj.CausaleIrpef = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAUSALE_IRPEF"]);
			CovidLiquidazioniObj.Progressivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGRESSIVO"]);
			CovidLiquidazioniObj.ControlloEquitalia = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_EQUITALIA"]);
			CovidLiquidazioniObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			CovidLiquidazioniObj.Ufficio = new SiarLibrary.NullTypes.StringNT(db.DataReader["UFFICIO"]);
			CovidLiquidazioniObj.Bollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["BOLLO"]);
			CovidLiquidazioniObj.DataInsert = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERT"]);
			CovidLiquidazioniObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CovidLiquidazioniObj.DescrizioneInterventoSostitutivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INTERVENTO_SOSTITUTIVO"]);
			CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidLiquidazioniObj.IsDirty = false;
			CovidLiquidazioniObj.IsPersistent = true;
			return CovidLiquidazioniObj;
		}

		//Find Select

		public static CovidLiquidazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CapitoloEqualThis, SiarLibrary.NullTypes.StringNT AnnoImpEqualThis, 
SiarLibrary.NullTypes.StringNT AnnoSubimpEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneImpSubimpEqualThis, SiarLibrary.NullTypes.StringNT SistemaOrigineEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.StringNT DurcRegolareEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceCorEqualThis, SiarLibrary.NullTypes.StringNT AnnoPropostaEqualThis, SiarLibrary.NullTypes.StringNT UnitaProponenteEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroPropostaEqualThis, SiarLibrary.NullTypes.StringNT TransazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceRitenutaEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImponibileRitenutaEqualThis, SiarLibrary.NullTypes.DecimalNT AliquotaRitenutaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRitenuteEqualThis, 
SiarLibrary.NullTypes.StringNT CausaleIrpefEqualThis, SiarLibrary.NullTypes.IntNT ProgressivoEqualThis, SiarLibrary.NullTypes.StringNT ControlloEquitaliaEqualThis, 
SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.StringNT UfficioEqualThis, SiarLibrary.NullTypes.StringNT BolloEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInsertEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneInterventoSostitutivoEqualThis)

		{

			CovidLiquidazioniCollection CovidLiquidazioniCollectionObj = new CovidLiquidazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidliquidazionifindselect", new string[] {"Idequalthis", "Capitoloequalthis", "AnnoImpequalthis", 
"AnnoSubimpequalthis", "DescrizioneImpSubimpequalthis", "SistemaOrigineequalthis", 
"IdDomandaequalthis", "Importoequalthis", "DurcRegolareequalthis", 
"CodiceCorequalthis", "AnnoPropostaequalthis", "UnitaProponenteequalthis", 
"NumeroPropostaequalthis", "Transazioneequalthis", "CodiceRitenutaequalthis", 
"ImponibileRitenutaequalthis", "AliquotaRitenutaequalthis", "ImportoRitenuteequalthis", 
"CausaleIrpefequalthis", "Progressivoequalthis", "ControlloEquitaliaequalthis", 
"Noteequalthis", "Ufficioequalthis", "Bolloequalthis", 
"DataInsertequalthis", "IdBandoequalthis", "DescrizioneInterventoSostitutivoequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "string", 
"int", "decimal", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"string", "int", "string", 
"string", "string", "string", 
"DateTime", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capitoloequalthis", CapitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoImpequalthis", AnnoImpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoSubimpequalthis", AnnoSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneImpSubimpequalthis", DescrizioneImpSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SistemaOrigineequalthis", SistemaOrigineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DurcRegolareequalthis", DurcRegolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceCorequalthis", CodiceCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoPropostaequalthis", AnnoPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UnitaProponenteequalthis", UnitaProponenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroPropostaequalthis", NumeroPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Transazioneequalthis", TransazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRitenutaequalthis", CodiceRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImponibileRitenutaequalthis", ImponibileRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AliquotaRitenutaequalthis", AliquotaRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRitenuteequalthis", ImportoRitenuteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CausaleIrpefequalthis", CausaleIrpefEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloEquitaliaequalthis", ControlloEquitaliaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ufficioequalthis", UfficioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Bolloequalthis", BolloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInsertequalthis", DataInsertEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneInterventoSostitutivoequalthis", DescrizioneInterventoSostitutivoEqualThis);
			CovidLiquidazioni CovidLiquidazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidLiquidazioniObj = GetFromDatareader(db);
				CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidLiquidazioniObj.IsDirty = false;
				CovidLiquidazioniObj.IsPersistent = true;
				CovidLiquidazioniCollectionObj.Add(CovidLiquidazioniObj);
			}
			db.Close();
			return CovidLiquidazioniCollectionObj;
		}

		//Find Find

		public static CovidLiquidazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT ProgressivoEqualThis)

		{

			CovidLiquidazioniCollection CovidLiquidazioniCollectionObj = new CovidLiquidazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidliquidazionifindfind", new string[] {"Progressivoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
			CovidLiquidazioni CovidLiquidazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidLiquidazioniObj = GetFromDatareader(db);
				CovidLiquidazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidLiquidazioniObj.IsDirty = false;
				CovidLiquidazioniObj.IsPersistent = true;
				CovidLiquidazioniCollectionObj.Add(CovidLiquidazioniObj);
			}
			db.Close();
			return CovidLiquidazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidLiquidazioniCollectionProvider:ICovidLiquidazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidLiquidazioniCollectionProvider : ICovidLiquidazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidLiquidazioni
		protected CovidLiquidazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidLiquidazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidLiquidazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidLiquidazioniCollectionProvider(IntNT ProgressivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(ProgressivoEqualThis);
		}

		//Costruttore3: ha in input covidliquidazioniCollectionObj - non popola la collection
		public CovidLiquidazioniCollectionProvider(CovidLiquidazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidLiquidazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidLiquidazioniCollection(this);
		}

		//Get e Set
		public CovidLiquidazioniCollection CollectionObj
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
		public int SaveCollection(CovidLiquidazioniCollection collectionObj)
		{
			return CovidLiquidazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidLiquidazioni covidliquidazioniObj)
		{
			return CovidLiquidazioniDAL.Save(_dbProviderObj, covidliquidazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidLiquidazioniCollection collectionObj)
		{
			return CovidLiquidazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidLiquidazioni covidliquidazioniObj)
		{
			return CovidLiquidazioniDAL.Delete(_dbProviderObj, covidliquidazioniObj);
		}

		//getById
		public CovidLiquidazioni GetById(IntNT IdValue)
		{
			CovidLiquidazioni CovidLiquidazioniTemp = CovidLiquidazioniDAL.GetById(_dbProviderObj, IdValue);
			if (CovidLiquidazioniTemp!=null) CovidLiquidazioniTemp.Provider = this;
			return CovidLiquidazioniTemp;
		}

		//Select: popola la collection
		public CovidLiquidazioniCollection Select(IntNT IdEqualThis, StringNT CapitoloEqualThis, StringNT AnnoimpEqualThis, 
StringNT AnnosubimpEqualThis, StringNT DescrizioneimpsubimpEqualThis, StringNT SistemaorigineEqualThis, 
IntNT IddomandaEqualThis, DecimalNT ImportoEqualThis, StringNT DurcregolareEqualThis, 
StringNT CodicecorEqualThis, StringNT AnnopropostaEqualThis, StringNT UnitaproponenteEqualThis, 
StringNT NumeropropostaEqualThis, StringNT TransazioneEqualThis, StringNT CodiceritenutaEqualThis, 
DecimalNT ImponibileritenutaEqualThis, DecimalNT AliquotaritenutaEqualThis, DecimalNT ImportoritenuteEqualThis, 
StringNT CausaleirpefEqualThis, IntNT ProgressivoEqualThis, StringNT ControlloequitaliaEqualThis, 
StringNT NoteEqualThis, StringNT UfficioEqualThis, StringNT BolloEqualThis, 
DatetimeNT DatainsertEqualThis, IntNT IdbandoEqualThis, StringNT DescrizioneinterventosostitutivoEqualThis)
		{
			CovidLiquidazioniCollection CovidLiquidazioniCollectionTemp = CovidLiquidazioniDAL.Select(_dbProviderObj, IdEqualThis, CapitoloEqualThis, AnnoimpEqualThis, 
AnnosubimpEqualThis, DescrizioneimpsubimpEqualThis, SistemaorigineEqualThis, 
IddomandaEqualThis, ImportoEqualThis, DurcregolareEqualThis, 
CodicecorEqualThis, AnnopropostaEqualThis, UnitaproponenteEqualThis, 
NumeropropostaEqualThis, TransazioneEqualThis, CodiceritenutaEqualThis, 
ImponibileritenutaEqualThis, AliquotaritenutaEqualThis, ImportoritenuteEqualThis, 
CausaleirpefEqualThis, ProgressivoEqualThis, ControlloequitaliaEqualThis, 
NoteEqualThis, UfficioEqualThis, BolloEqualThis, 
DatainsertEqualThis, IdbandoEqualThis, DescrizioneinterventosostitutivoEqualThis);
			CovidLiquidazioniCollectionTemp.Provider = this;
			return CovidLiquidazioniCollectionTemp;
		}

		//Find: popola la collection
		public CovidLiquidazioniCollection Find(IntNT ProgressivoEqualThis)
		{
			CovidLiquidazioniCollection CovidLiquidazioniCollectionTemp = CovidLiquidazioniDAL.Find(_dbProviderObj, ProgressivoEqualThis);
			CovidLiquidazioniCollectionTemp.Provider = this;
			return CovidLiquidazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_LIQUIDAZIONI>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <PROGRESSIVO>Equal</PROGRESSIVO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <PROGRESSIVO>Equal</PROGRESSIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COVID_LIQUIDAZIONI>
*/
