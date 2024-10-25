using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidCapitoliBandi
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidCapitoliBandiProvider
	{
		int Save(CovidCapitoliBandi CovidCapitoliBandiObj);
		int SaveCollection(CovidCapitoliBandiCollection collectionObj);
		int Delete(CovidCapitoliBandi CovidCapitoliBandiObj);
		int DeleteCollection(CovidCapitoliBandiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidCapitoliBandi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidCapitoliBandi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCovidCapitoliBando;
		private NullTypes.StringNT _Capitolo;
		private NullTypes.StringNT _AnnoImp;
		private NullTypes.StringNT _AnnoSubimp;
		private NullTypes.StringNT _DescrizioneImpSubimp;
		private NullTypes.DecimalNT _RimodulazioneContributo;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _PercentualeImporto;
		private NullTypes.StringNT _AnnoProposta;
		private NullTypes.StringNT _UnitaProponente;
		private NullTypes.StringNT _NumeroProposta;
		private NullTypes.StringNT _Transazione;
		private NullTypes.StringNT _CodiceRitenuta;
		private NullTypes.DecimalNT _AliquotaRitenuta;
		private NullTypes.StringNT _CausaleIrpef;
		private NullTypes.StringNT _ControlloEquitalia;
		private NullTypes.StringNT _Note;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.BoolNT _Confermata;
		[NonSerialized] private ICovidCapitoliBandiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidCapitoliBandiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CovidCapitoliBandi()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COVID_CAPITOLI_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCovidCapitoliBando
		{
			get { return _IdCovidCapitoliBando; }
			set {
				if (IdCovidCapitoliBando != value)
				{
					_IdCovidCapitoliBando = value;
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
		/// Corrisponde al campo:RIMODULAZIONE_CONTRIBUTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT RimodulazioneContributo
		{
			get { return _RimodulazioneContributo; }
			set {
				if (RimodulazioneContributo != value)
				{
					_RimodulazioneContributo = value;
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
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERCENTUALE_IMPORTO
		/// Tipo sul db:DECIMAL(18,4)
		/// </summary>
		public NullTypes.DecimalNT PercentualeImporto
		{
			get { return _PercentualeImporto; }
			set {
				if (PercentualeImporto != value)
				{
					_PercentualeImporto = value;
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:DATA_AGGIORNAMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataAggiornamento
		{
			get { return _DataAggiornamento; }
			set {
				if (DataAggiornamento != value)
				{
					_DataAggiornamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatore
		{
			get { return _IdOperatore; }
			set {
				if (IdOperatore != value)
				{
					_IdOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONFERMATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Confermata
		{
			get { return _Confermata; }
			set {
				if (Confermata != value)
				{
					_Confermata = value;
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
	/// Summary description for CovidCapitoliBandiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidCapitoliBandiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CovidCapitoliBandiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CovidCapitoliBandi) info.GetValue(i.ToString(),typeof(CovidCapitoliBandi)));
			}
		}

		//Costruttore
		public CovidCapitoliBandiCollection()
		{
			this.ItemType = typeof(CovidCapitoliBandi);
		}

		//Costruttore con provider
		public CovidCapitoliBandiCollection(ICovidCapitoliBandiProvider providerObj)
		{
			this.ItemType = typeof(CovidCapitoliBandi);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidCapitoliBandi this[int index]
		{
			get { return (CovidCapitoliBandi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidCapitoliBandiCollection GetChanges()
		{
			return (CovidCapitoliBandiCollection) base.GetChanges();
		}

		[NonSerialized] private ICovidCapitoliBandiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidCapitoliBandiProvider Provider
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
		public int Add(CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			if (CovidCapitoliBandiObj.Provider == null) CovidCapitoliBandiObj.Provider = this.Provider;
			return base.Add(CovidCapitoliBandiObj);
		}

		//AddCollection
		public void AddCollection(CovidCapitoliBandiCollection CovidCapitoliBandiCollectionObj)
		{
			foreach (CovidCapitoliBandi CovidCapitoliBandiObj in CovidCapitoliBandiCollectionObj)
				this.Add(CovidCapitoliBandiObj);
		}

		//Insert
		public void Insert(int index, CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			if (CovidCapitoliBandiObj.Provider == null) CovidCapitoliBandiObj.Provider = this.Provider;
			base.Insert(index, CovidCapitoliBandiObj);
		}

		//CollectionGetById
		public CovidCapitoliBandi CollectionGetById(NullTypes.IntNT IdCovidCapitoliBandoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCovidCapitoliBando == IdCovidCapitoliBandoValue))
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
		public CovidCapitoliBandiCollection SubSelect(NullTypes.IntNT IdCovidCapitoliBandoEqualThis, NullTypes.StringNT CapitoloEqualThis, NullTypes.StringNT AnnoImpEqualThis, 
NullTypes.StringNT AnnoSubimpEqualThis, NullTypes.StringNT DescrizioneImpSubimpEqualThis, NullTypes.DecimalNT RimodulazioneContributoEqualThis, 
NullTypes.DecimalNT ImportoEqualThis, NullTypes.DecimalNT PercentualeImportoEqualThis, NullTypes.StringNT AnnoPropostaEqualThis, 
NullTypes.StringNT UnitaProponenteEqualThis, NullTypes.StringNT NumeroPropostaEqualThis, NullTypes.StringNT TransazioneEqualThis, 
NullTypes.StringNT CodiceRitenutaEqualThis, NullTypes.DecimalNT AliquotaRitenutaEqualThis, NullTypes.StringNT CausaleIrpefEqualThis, 
NullTypes.StringNT ControlloEquitaliaEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.IntNT IdBandoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis, NullTypes.IntNT IdOperatoreEqualThis, 
NullTypes.BoolNT ConfermataEqualThis)
		{
			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionTemp = new CovidCapitoliBandiCollection();
			foreach (CovidCapitoliBandi CovidCapitoliBandiItem in this)
			{
				if (((IdCovidCapitoliBandoEqualThis == null) || ((CovidCapitoliBandiItem.IdCovidCapitoliBando != null) && (CovidCapitoliBandiItem.IdCovidCapitoliBando.Value == IdCovidCapitoliBandoEqualThis.Value))) && ((CapitoloEqualThis == null) || ((CovidCapitoliBandiItem.Capitolo != null) && (CovidCapitoliBandiItem.Capitolo.Value == CapitoloEqualThis.Value))) && ((AnnoImpEqualThis == null) || ((CovidCapitoliBandiItem.AnnoImp != null) && (CovidCapitoliBandiItem.AnnoImp.Value == AnnoImpEqualThis.Value))) && 
((AnnoSubimpEqualThis == null) || ((CovidCapitoliBandiItem.AnnoSubimp != null) && (CovidCapitoliBandiItem.AnnoSubimp.Value == AnnoSubimpEqualThis.Value))) && ((DescrizioneImpSubimpEqualThis == null) || ((CovidCapitoliBandiItem.DescrizioneImpSubimp != null) && (CovidCapitoliBandiItem.DescrizioneImpSubimp.Value == DescrizioneImpSubimpEqualThis.Value))) && ((RimodulazioneContributoEqualThis == null) || ((CovidCapitoliBandiItem.RimodulazioneContributo != null) && (CovidCapitoliBandiItem.RimodulazioneContributo.Value == RimodulazioneContributoEqualThis.Value))) && 
((ImportoEqualThis == null) || ((CovidCapitoliBandiItem.Importo != null) && (CovidCapitoliBandiItem.Importo.Value == ImportoEqualThis.Value))) && ((PercentualeImportoEqualThis == null) || ((CovidCapitoliBandiItem.PercentualeImporto != null) && (CovidCapitoliBandiItem.PercentualeImporto.Value == PercentualeImportoEqualThis.Value))) && ((AnnoPropostaEqualThis == null) || ((CovidCapitoliBandiItem.AnnoProposta != null) && (CovidCapitoliBandiItem.AnnoProposta.Value == AnnoPropostaEqualThis.Value))) && 
((UnitaProponenteEqualThis == null) || ((CovidCapitoliBandiItem.UnitaProponente != null) && (CovidCapitoliBandiItem.UnitaProponente.Value == UnitaProponenteEqualThis.Value))) && ((NumeroPropostaEqualThis == null) || ((CovidCapitoliBandiItem.NumeroProposta != null) && (CovidCapitoliBandiItem.NumeroProposta.Value == NumeroPropostaEqualThis.Value))) && ((TransazioneEqualThis == null) || ((CovidCapitoliBandiItem.Transazione != null) && (CovidCapitoliBandiItem.Transazione.Value == TransazioneEqualThis.Value))) && 
((CodiceRitenutaEqualThis == null) || ((CovidCapitoliBandiItem.CodiceRitenuta != null) && (CovidCapitoliBandiItem.CodiceRitenuta.Value == CodiceRitenutaEqualThis.Value))) && ((AliquotaRitenutaEqualThis == null) || ((CovidCapitoliBandiItem.AliquotaRitenuta != null) && (CovidCapitoliBandiItem.AliquotaRitenuta.Value == AliquotaRitenutaEqualThis.Value))) && ((CausaleIrpefEqualThis == null) || ((CovidCapitoliBandiItem.CausaleIrpef != null) && (CovidCapitoliBandiItem.CausaleIrpef.Value == CausaleIrpefEqualThis.Value))) && 
((ControlloEquitaliaEqualThis == null) || ((CovidCapitoliBandiItem.ControlloEquitalia != null) && (CovidCapitoliBandiItem.ControlloEquitalia.Value == ControlloEquitaliaEqualThis.Value))) && ((NoteEqualThis == null) || ((CovidCapitoliBandiItem.Note != null) && (CovidCapitoliBandiItem.Note.Value == NoteEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CovidCapitoliBandiItem.IdBando != null) && (CovidCapitoliBandiItem.IdBando.Value == IdBandoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((CovidCapitoliBandiItem.DataInserimento != null) && (CovidCapitoliBandiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((CovidCapitoliBandiItem.DataAggiornamento != null) && (CovidCapitoliBandiItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && ((IdOperatoreEqualThis == null) || ((CovidCapitoliBandiItem.IdOperatore != null) && (CovidCapitoliBandiItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) && 
((ConfermataEqualThis == null) || ((CovidCapitoliBandiItem.Confermata != null) && (CovidCapitoliBandiItem.Confermata.Value == ConfermataEqualThis.Value))))
				{
					CovidCapitoliBandiCollectionTemp.Add(CovidCapitoliBandiItem);
				}
			}
			return CovidCapitoliBandiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CovidCapitoliBandiCollection Filter(NullTypes.StringNT CapitoloEqualThis, NullTypes.StringNT AnnoImpEqualThis, NullTypes.StringNT AnnoSubimpEqualThis, 
NullTypes.StringNT AnnoPropostaEqualThis, NullTypes.StringNT UnitaProponenteEqualThis, NullTypes.StringNT CodiceRitenutaEqualThis, 
NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdOperatoreEqualThis)
		{
			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionTemp = new CovidCapitoliBandiCollection();
			foreach (CovidCapitoliBandi CovidCapitoliBandiItem in this)
			{
				if (((CapitoloEqualThis == null) || ((CovidCapitoliBandiItem.Capitolo != null) && (CovidCapitoliBandiItem.Capitolo.Value == CapitoloEqualThis.Value))) && ((AnnoImpEqualThis == null) || ((CovidCapitoliBandiItem.AnnoImp != null) && (CovidCapitoliBandiItem.AnnoImp.Value == AnnoImpEqualThis.Value))) && ((AnnoSubimpEqualThis == null) || ((CovidCapitoliBandiItem.AnnoSubimp != null) && (CovidCapitoliBandiItem.AnnoSubimp.Value == AnnoSubimpEqualThis.Value))) && 
((AnnoPropostaEqualThis == null) || ((CovidCapitoliBandiItem.AnnoProposta != null) && (CovidCapitoliBandiItem.AnnoProposta.Value == AnnoPropostaEqualThis.Value))) && ((UnitaProponenteEqualThis == null) || ((CovidCapitoliBandiItem.UnitaProponente != null) && (CovidCapitoliBandiItem.UnitaProponente.Value == UnitaProponenteEqualThis.Value))) && ((CodiceRitenutaEqualThis == null) || ((CovidCapitoliBandiItem.CodiceRitenuta != null) && (CovidCapitoliBandiItem.CodiceRitenuta.Value == CodiceRitenutaEqualThis.Value))) && 
((IdBandoEqualThis == null) || ((CovidCapitoliBandiItem.IdBando != null) && (CovidCapitoliBandiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdOperatoreEqualThis == null) || ((CovidCapitoliBandiItem.IdOperatore != null) && (CovidCapitoliBandiItem.IdOperatore.Value == IdOperatoreEqualThis.Value))))
				{
					CovidCapitoliBandiCollectionTemp.Add(CovidCapitoliBandiItem);
				}
			}
			return CovidCapitoliBandiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidCapitoliBandiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidCapitoliBandiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidCapitoliBandi CovidCapitoliBandiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCovidCapitoliBando", CovidCapitoliBandiObj.IdCovidCapitoliBando);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Capitolo", CovidCapitoliBandiObj.Capitolo);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoImp", CovidCapitoliBandiObj.AnnoImp);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoSubimp", CovidCapitoliBandiObj.AnnoSubimp);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneImpSubimp", CovidCapitoliBandiObj.DescrizioneImpSubimp);
			DbProvider.SetCmdParam(cmd,firstChar + "RimodulazioneContributo", CovidCapitoliBandiObj.RimodulazioneContributo);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", CovidCapitoliBandiObj.Importo);
			DbProvider.SetCmdParam(cmd,firstChar + "PercentualeImporto", CovidCapitoliBandiObj.PercentualeImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoProposta", CovidCapitoliBandiObj.AnnoProposta);
			DbProvider.SetCmdParam(cmd,firstChar + "UnitaProponente", CovidCapitoliBandiObj.UnitaProponente);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroProposta", CovidCapitoliBandiObj.NumeroProposta);
			DbProvider.SetCmdParam(cmd,firstChar + "Transazione", CovidCapitoliBandiObj.Transazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceRitenuta", CovidCapitoliBandiObj.CodiceRitenuta);
			DbProvider.SetCmdParam(cmd,firstChar + "AliquotaRitenuta", CovidCapitoliBandiObj.AliquotaRitenuta);
			DbProvider.SetCmdParam(cmd,firstChar + "CausaleIrpef", CovidCapitoliBandiObj.CausaleIrpef);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloEquitalia", CovidCapitoliBandiObj.ControlloEquitalia);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", CovidCapitoliBandiObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CovidCapitoliBandiObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", CovidCapitoliBandiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", CovidCapitoliBandiObj.DataAggiornamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatore", CovidCapitoliBandiObj.IdOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Confermata", CovidCapitoliBandiObj.Confermata);
		}
		//Insert
		private static int Insert(DbProvider db, CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCovidCapitoliBandiInsert", new string[] {"Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "RimodulazioneContributo", 
"Importo", "PercentualeImporto", "AnnoProposta", 
"UnitaProponente", "NumeroProposta", "Transazione", 
"CodiceRitenuta", "AliquotaRitenuta", "CausaleIrpef", 
"ControlloEquitalia", "Note", "IdBando", 
"DataInserimento", "DataAggiornamento", "IdOperatore", 
"Confermata"}, new string[] {"string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"string", "string", "string", 
"string", "decimal", "string", 
"string", "string", "int", 
"DateTime", "DateTime", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,CovidCapitoliBandiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CovidCapitoliBandiObj.IdCovidCapitoliBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COVID_CAPITOLI_BANDO"]);
				CovidCapitoliBandiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				CovidCapitoliBandiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
				}
				CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidCapitoliBandiObj.IsDirty = false;
				CovidCapitoliBandiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidCapitoliBandiUpdate", new string[] {"IdCovidCapitoliBando", "Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "RimodulazioneContributo", 
"Importo", "PercentualeImporto", "AnnoProposta", 
"UnitaProponente", "NumeroProposta", "Transazione", 
"CodiceRitenuta", "AliquotaRitenuta", "CausaleIrpef", 
"ControlloEquitalia", "Note", "IdBando", 
"DataInserimento", "DataAggiornamento", "IdOperatore", 
"Confermata"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"string", "string", "string", 
"string", "decimal", "string", 
"string", "string", "int", 
"DateTime", "DateTime", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,CovidCapitoliBandiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidCapitoliBandiObj.IsDirty = false;
				CovidCapitoliBandiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			switch (CovidCapitoliBandiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CovidCapitoliBandiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CovidCapitoliBandiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CovidCapitoliBandiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidCapitoliBandiCollection CovidCapitoliBandiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidCapitoliBandiUpdate", new string[] {"IdCovidCapitoliBando", "Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "RimodulazioneContributo", 
"Importo", "PercentualeImporto", "AnnoProposta", 
"UnitaProponente", "NumeroProposta", "Transazione", 
"CodiceRitenuta", "AliquotaRitenuta", "CausaleIrpef", 
"ControlloEquitalia", "Note", "IdBando", 
"DataInserimento", "DataAggiornamento", "IdOperatore", 
"Confermata"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"string", "string", "string", 
"string", "decimal", "string", 
"string", "string", "int", 
"DateTime", "DateTime", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCovidCapitoliBandiInsert", new string[] {"Capitolo", "AnnoImp", 
"AnnoSubimp", "DescrizioneImpSubimp", "RimodulazioneContributo", 
"Importo", "PercentualeImporto", "AnnoProposta", 
"UnitaProponente", "NumeroProposta", "Transazione", 
"CodiceRitenuta", "AliquotaRitenuta", "CausaleIrpef", 
"ControlloEquitalia", "Note", "IdBando", 
"DataInserimento", "DataAggiornamento", "IdOperatore", 
"Confermata"}, new string[] {"string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"string", "string", "string", 
"string", "decimal", "string", 
"string", "string", "int", 
"DateTime", "DateTime", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCovidCapitoliBandiDelete", new string[] {"IdCovidCapitoliBando"}, new string[] {"int"},"");
				for (int i = 0; i < CovidCapitoliBandiCollectionObj.Count; i++)
				{
					switch (CovidCapitoliBandiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CovidCapitoliBandiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidCapitoliBandiCollectionObj[i].IdCovidCapitoliBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COVID_CAPITOLI_BANDO"]);
									CovidCapitoliBandiCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									CovidCapitoliBandiCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CovidCapitoliBandiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CovidCapitoliBandiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCovidCapitoliBando", (SiarLibrary.NullTypes.IntNT)CovidCapitoliBandiCollectionObj[i].IdCovidCapitoliBando);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidCapitoliBandiCollectionObj.Count; i++)
				{
					if ((CovidCapitoliBandiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidCapitoliBandiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidCapitoliBandiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidCapitoliBandiCollectionObj[i].IsDirty = false;
						CovidCapitoliBandiCollectionObj[i].IsPersistent = true;
					}
					if ((CovidCapitoliBandiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidCapitoliBandiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidCapitoliBandiCollectionObj[i].IsDirty = false;
						CovidCapitoliBandiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CovidCapitoliBandi CovidCapitoliBandiObj)
		{
			int returnValue = 0;
			if (CovidCapitoliBandiObj.IsPersistent) 
			{
				returnValue = Delete(db, CovidCapitoliBandiObj.IdCovidCapitoliBando);
			}
			CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidCapitoliBandiObj.IsDirty = false;
			CovidCapitoliBandiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCovidCapitoliBandoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidCapitoliBandiDelete", new string[] {"IdCovidCapitoliBando"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCovidCapitoliBando", (SiarLibrary.NullTypes.IntNT)IdCovidCapitoliBandoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidCapitoliBandiCollection CovidCapitoliBandiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidCapitoliBandiDelete", new string[] {"IdCovidCapitoliBando"}, new string[] {"int"},"");
				for (int i = 0; i < CovidCapitoliBandiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCovidCapitoliBando", CovidCapitoliBandiCollectionObj[i].IdCovidCapitoliBando);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidCapitoliBandiCollectionObj.Count; i++)
				{
					if ((CovidCapitoliBandiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidCapitoliBandiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidCapitoliBandiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidCapitoliBandiCollectionObj[i].IsDirty = false;
						CovidCapitoliBandiCollectionObj[i].IsPersistent = false;
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
		public static CovidCapitoliBandi GetById(DbProvider db, int IdCovidCapitoliBandoValue)
		{
			CovidCapitoliBandi CovidCapitoliBandiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCovidCapitoliBandiGetById", new string[] {"IdCovidCapitoliBando"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCovidCapitoliBando", (SiarLibrary.NullTypes.IntNT)IdCovidCapitoliBandoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidCapitoliBandiObj = GetFromDatareader(db);
				CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidCapitoliBandiObj.IsDirty = false;
				CovidCapitoliBandiObj.IsPersistent = true;
			}
			db.Close();
			return CovidCapitoliBandiObj;
		}

		//getFromDatareader
		public static CovidCapitoliBandi GetFromDatareader(DbProvider db)
		{
			CovidCapitoliBandi CovidCapitoliBandiObj = new CovidCapitoliBandi();
			CovidCapitoliBandiObj.IdCovidCapitoliBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COVID_CAPITOLI_BANDO"]);
			CovidCapitoliBandiObj.Capitolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAPITOLO"]);
			CovidCapitoliBandiObj.AnnoImp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_IMP"]);
			CovidCapitoliBandiObj.AnnoSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_SUBIMP"]);
			CovidCapitoliBandiObj.DescrizioneImpSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_IMP_SUBIMP"]);
			CovidCapitoliBandiObj.RimodulazioneContributo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RIMODULAZIONE_CONTRIBUTO"]);
			CovidCapitoliBandiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			CovidCapitoliBandiObj.PercentualeImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE_IMPORTO"]);
			CovidCapitoliBandiObj.AnnoProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_PROPOSTA"]);
			CovidCapitoliBandiObj.UnitaProponente = new SiarLibrary.NullTypes.StringNT(db.DataReader["UNITA_PROPONENTE"]);
			CovidCapitoliBandiObj.NumeroProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROPOSTA"]);
			CovidCapitoliBandiObj.Transazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRANSAZIONE"]);
			CovidCapitoliBandiObj.CodiceRitenuta = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_RITENUTA"]);
			CovidCapitoliBandiObj.AliquotaRitenuta = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALIQUOTA_RITENUTA"]);
			CovidCapitoliBandiObj.CausaleIrpef = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAUSALE_IRPEF"]);
			CovidCapitoliBandiObj.ControlloEquitalia = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_EQUITALIA"]);
			CovidCapitoliBandiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			CovidCapitoliBandiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CovidCapitoliBandiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CovidCapitoliBandiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			CovidCapitoliBandiObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			CovidCapitoliBandiObj.Confermata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFERMATA"]);
			CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidCapitoliBandiObj.IsDirty = false;
			CovidCapitoliBandiObj.IsPersistent = true;
			return CovidCapitoliBandiObj;
		}

		//Find Select

		public static CovidCapitoliBandiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCovidCapitoliBandoEqualThis, SiarLibrary.NullTypes.StringNT CapitoloEqualThis, SiarLibrary.NullTypes.StringNT AnnoImpEqualThis, 
SiarLibrary.NullTypes.StringNT AnnoSubimpEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneImpSubimpEqualThis, SiarLibrary.NullTypes.DecimalNT RimodulazioneContributoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DecimalNT PercentualeImportoEqualThis, SiarLibrary.NullTypes.StringNT AnnoPropostaEqualThis, 
SiarLibrary.NullTypes.StringNT UnitaProponenteEqualThis, SiarLibrary.NullTypes.StringNT NumeroPropostaEqualThis, SiarLibrary.NullTypes.StringNT TransazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceRitenutaEqualThis, SiarLibrary.NullTypes.DecimalNT AliquotaRitenutaEqualThis, SiarLibrary.NullTypes.StringNT CausaleIrpefEqualThis, 
SiarLibrary.NullTypes.StringNT ControlloEquitaliaEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT ConfermataEqualThis)

		{

			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionObj = new CovidCapitoliBandiCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidcapitolibandifindselect", new string[] {"IdCovidCapitoliBandoequalthis", "Capitoloequalthis", "AnnoImpequalthis", 
"AnnoSubimpequalthis", "DescrizioneImpSubimpequalthis", "RimodulazioneContributoequalthis", 
"Importoequalthis", "PercentualeImportoequalthis", "AnnoPropostaequalthis", 
"UnitaProponenteequalthis", "NumeroPropostaequalthis", "Transazioneequalthis", 
"CodiceRitenutaequalthis", "AliquotaRitenutaequalthis", "CausaleIrpefequalthis", 
"ControlloEquitaliaequalthis", "Noteequalthis", "IdBandoequalthis", 
"DataInserimentoequalthis", "DataAggiornamentoequalthis", "IdOperatoreequalthis", 
"Confermataequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"string", "string", "string", 
"string", "decimal", "string", 
"string", "string", "int", 
"DateTime", "DateTime", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCovidCapitoliBandoequalthis", IdCovidCapitoliBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capitoloequalthis", CapitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoImpequalthis", AnnoImpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoSubimpequalthis", AnnoSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneImpSubimpequalthis", DescrizioneImpSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RimodulazioneContributoequalthis", RimodulazioneContributoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercentualeImportoequalthis", PercentualeImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoPropostaequalthis", AnnoPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UnitaProponenteequalthis", UnitaProponenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroPropostaequalthis", NumeroPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Transazioneequalthis", TransazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRitenutaequalthis", CodiceRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AliquotaRitenutaequalthis", AliquotaRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CausaleIrpefequalthis", CausaleIrpefEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloEquitaliaequalthis", ControlloEquitaliaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Confermataequalthis", ConfermataEqualThis);
			CovidCapitoliBandi CovidCapitoliBandiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidCapitoliBandiObj = GetFromDatareader(db);
				CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidCapitoliBandiObj.IsDirty = false;
				CovidCapitoliBandiObj.IsPersistent = true;
				CovidCapitoliBandiCollectionObj.Add(CovidCapitoliBandiObj);
			}
			db.Close();
			return CovidCapitoliBandiCollectionObj;
		}

		//Find Find

		public static CovidCapitoliBandiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CapitoloEqualThis, SiarLibrary.NullTypes.StringNT AnnoImpEqualThis, SiarLibrary.NullTypes.StringNT AnnoSubimpEqualThis, 
SiarLibrary.NullTypes.StringNT AnnoPropostaEqualThis, SiarLibrary.NullTypes.StringNT UnitaProponenteEqualThis, SiarLibrary.NullTypes.StringNT CodiceRitenutaEqualThis, 
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT ConfermataEqualThis)

		{

			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionObj = new CovidCapitoliBandiCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidcapitolibandifindfind", new string[] {"Capitoloequalthis", "AnnoImpequalthis", "AnnoSubimpequalthis", 
"AnnoPropostaequalthis", "UnitaProponenteequalthis", "CodiceRitenutaequalthis", 
"IdBandoequalthis", "IdOperatoreequalthis", "Confermataequalthis"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capitoloequalthis", CapitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoImpequalthis", AnnoImpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoSubimpequalthis", AnnoSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoPropostaequalthis", AnnoPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UnitaProponenteequalthis", UnitaProponenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRitenutaequalthis", CodiceRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Confermataequalthis", ConfermataEqualThis);
			CovidCapitoliBandi CovidCapitoliBandiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidCapitoliBandiObj = GetFromDatareader(db);
				CovidCapitoliBandiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidCapitoliBandiObj.IsDirty = false;
				CovidCapitoliBandiObj.IsPersistent = true;
				CovidCapitoliBandiCollectionObj.Add(CovidCapitoliBandiObj);
			}
			db.Close();
			return CovidCapitoliBandiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidCapitoliBandiCollectionProvider:ICovidCapitoliBandiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidCapitoliBandiCollectionProvider : ICovidCapitoliBandiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidCapitoliBandi
		protected CovidCapitoliBandiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidCapitoliBandiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidCapitoliBandiCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidCapitoliBandiCollectionProvider(StringNT CapitoloEqualThis, StringNT AnnoimpEqualThis, StringNT AnnosubimpEqualThis, 
StringNT AnnopropostaEqualThis, StringNT UnitaproponenteEqualThis, StringNT CodiceritenutaEqualThis, 
IntNT IdbandoEqualThis, IntNT IdoperatoreEqualThis, BoolNT ConfermataEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CapitoloEqualThis, AnnoimpEqualThis, AnnosubimpEqualThis, 
AnnopropostaEqualThis, UnitaproponenteEqualThis, CodiceritenutaEqualThis, 
IdbandoEqualThis, IdoperatoreEqualThis, ConfermataEqualThis);
		}

		//Costruttore3: ha in input covidcapitolibandiCollectionObj - non popola la collection
		public CovidCapitoliBandiCollectionProvider(CovidCapitoliBandiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidCapitoliBandiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidCapitoliBandiCollection(this);
		}

		//Get e Set
		public CovidCapitoliBandiCollection CollectionObj
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
		public int SaveCollection(CovidCapitoliBandiCollection collectionObj)
		{
			return CovidCapitoliBandiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidCapitoliBandi covidcapitolibandiObj)
		{
			return CovidCapitoliBandiDAL.Save(_dbProviderObj, covidcapitolibandiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidCapitoliBandiCollection collectionObj)
		{
			return CovidCapitoliBandiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidCapitoliBandi covidcapitolibandiObj)
		{
			return CovidCapitoliBandiDAL.Delete(_dbProviderObj, covidcapitolibandiObj);
		}

		//getById
		public CovidCapitoliBandi GetById(IntNT IdCovidCapitoliBandoValue)
		{
			CovidCapitoliBandi CovidCapitoliBandiTemp = CovidCapitoliBandiDAL.GetById(_dbProviderObj, IdCovidCapitoliBandoValue);
			if (CovidCapitoliBandiTemp!=null) CovidCapitoliBandiTemp.Provider = this;
			return CovidCapitoliBandiTemp;
		}

		//Select: popola la collection
		public CovidCapitoliBandiCollection Select(IntNT IdcovidcapitolibandoEqualThis, StringNT CapitoloEqualThis, StringNT AnnoimpEqualThis, 
StringNT AnnosubimpEqualThis, StringNT DescrizioneimpsubimpEqualThis, DecimalNT RimodulazionecontributoEqualThis, 
DecimalNT ImportoEqualThis, DecimalNT PercentualeimportoEqualThis, StringNT AnnopropostaEqualThis, 
StringNT UnitaproponenteEqualThis, StringNT NumeropropostaEqualThis, StringNT TransazioneEqualThis, 
StringNT CodiceritenutaEqualThis, DecimalNT AliquotaritenutaEqualThis, StringNT CausaleirpefEqualThis, 
StringNT ControlloequitaliaEqualThis, StringNT NoteEqualThis, IntNT IdbandoEqualThis, 
DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis, IntNT IdoperatoreEqualThis, 
BoolNT ConfermataEqualThis)
		{
			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionTemp = CovidCapitoliBandiDAL.Select(_dbProviderObj, IdcovidcapitolibandoEqualThis, CapitoloEqualThis, AnnoimpEqualThis, 
AnnosubimpEqualThis, DescrizioneimpsubimpEqualThis, RimodulazionecontributoEqualThis, 
ImportoEqualThis, PercentualeimportoEqualThis, AnnopropostaEqualThis, 
UnitaproponenteEqualThis, NumeropropostaEqualThis, TransazioneEqualThis, 
CodiceritenutaEqualThis, AliquotaritenutaEqualThis, CausaleirpefEqualThis, 
ControlloequitaliaEqualThis, NoteEqualThis, IdbandoEqualThis, 
DatainserimentoEqualThis, DataaggiornamentoEqualThis, IdoperatoreEqualThis, 
ConfermataEqualThis);
			CovidCapitoliBandiCollectionTemp.Provider = this;
			return CovidCapitoliBandiCollectionTemp;
		}

		//Find: popola la collection
		public CovidCapitoliBandiCollection Find(StringNT CapitoloEqualThis, StringNT AnnoimpEqualThis, StringNT AnnosubimpEqualThis, 
StringNT AnnopropostaEqualThis, StringNT UnitaproponenteEqualThis, StringNT CodiceritenutaEqualThis, 
IntNT IdbandoEqualThis, IntNT IdoperatoreEqualThis, BoolNT ConfermataEqualThis)
		{
			CovidCapitoliBandiCollection CovidCapitoliBandiCollectionTemp = CovidCapitoliBandiDAL.Find(_dbProviderObj, CapitoloEqualThis, AnnoimpEqualThis, AnnosubimpEqualThis, 
AnnopropostaEqualThis, UnitaproponenteEqualThis, CodiceritenutaEqualThis, 
IdbandoEqualThis, IdoperatoreEqualThis, ConfermataEqualThis);
			CovidCapitoliBandiCollectionTemp.Provider = this;
			return CovidCapitoliBandiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_CAPITOLI_BANDI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
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
      <CAPITOLO>Equal</CAPITOLO>
      <ANNO_IMP>Equal</ANNO_IMP>
      <ANNO_SUBIMP>Equal</ANNO_SUBIMP>
      <ANNO_PROPOSTA>Equal</ANNO_PROPOSTA>
      <UNITA_PROPONENTE>Equal</UNITA_PROPONENTE>
      <CODICE_RITENUTA>Equal</CODICE_RITENUTA>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_OPERATORE>Equal</ID_OPERATORE>
      <CONFERMATA>Equal</CONFERMATA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <CAPITOLO>Equal</CAPITOLO>
      <ANNO_IMP>Equal</ANNO_IMP>
      <ANNO_SUBIMP>Equal</ANNO_SUBIMP>
      <ANNO_PROPOSTA>Equal</ANNO_PROPOSTA>
      <UNITA_PROPONENTE>Equal</UNITA_PROPONENTE>
      <CODICE_RITENUTA>Equal</CODICE_RITENUTA>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_OPERATORE>Equal</ID_OPERATORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COVID_CAPITOLI_BANDI>
*/
