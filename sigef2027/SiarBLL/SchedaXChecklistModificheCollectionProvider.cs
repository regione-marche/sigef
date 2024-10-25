using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SchedaXChecklistModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISchedaXChecklistModificheProvider
	{
		int Save(SchedaXChecklistModifiche SchedaXChecklistModificheObj);
		int SaveCollection(SchedaXChecklistModificheCollection collectionObj);
		int Delete(SchedaXChecklistModifiche SchedaXChecklistModificheObj);
		int DeleteCollection(SchedaXChecklistModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SchedaXChecklistModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SchedaXChecklistModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSchedaXChecklist;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdChecklistPadre;
		private NullTypes.IntNT _IdChecklistFiglio;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.DecimalNT _Peso;
		private NullTypes.StringNT _DescrizioneChecklist;
		private NullTypes.BoolNT _FlagTemplateChecklist;
		private NullTypes.IntNT _IdTipoChecklist;
		private NullTypes.StringNT _DescrizioneTipoChecklist;
		private NullTypes.BoolNT _ContieneVociChecklist;
		private NullTypes.BoolNT _SchedaChecklist;
		private NullTypes.StringNT _IdFiltroChecklist;
		private NullTypes.StringNT _DescrizioneFiltroChecklist;
		private NullTypes.IntNT _OrdineFiltroChecklist;
		private NullTypes.IntNT _IdTipoScheda;
		private NullTypes.StringNT _DescrizioneTipoScheda;
		private NullTypes.BoolNT _ContieneVociScheda;
		private NullTypes.BoolNT _SchedaScheda;
		private NullTypes.StringNT _IdFiltroScheda;
		private NullTypes.StringNT _DescrizioneFiltroScheda;
		private NullTypes.IntNT _OrdineFiltroScheda;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private ISchedaXChecklistModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaXChecklistModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SchedaXChecklistModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SCHEDA_X_CHECKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSchedaXChecklist
		{
			get { return _IdSchedaXChecklist; }
			set {
				if (IdSchedaXChecklist != value)
				{
					_IdSchedaXChecklist = value;
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
		/// Corrisponde al campo:ID_CHECKLIST_PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistPadre
		{
			get { return _IdChecklistPadre; }
			set {
				if (IdChecklistPadre != value)
				{
					_IdChecklistPadre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECKLIST_FIGLIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistFiglio
		{
			get { return _IdChecklistFiglio; }
			set {
				if (IdChecklistFiglio != value)
				{
					_IdChecklistFiglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PESO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Peso
		{
			get { return _Peso; }
			set {
				if (Peso != value)
				{
					_Peso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneChecklist
		{
			get { return _DescrizioneChecklist; }
			set {
				if (DescrizioneChecklist != value)
				{
					_DescrizioneChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_TEMPLATE_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplateChecklist
		{
			get { return _FlagTemplateChecklist; }
			set {
				if (FlagTemplateChecklist != value)
				{
					_FlagTemplateChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_CHECKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoChecklist
		{
			get { return _IdTipoChecklist; }
			set {
				if (IdTipoChecklist != value)
				{
					_IdTipoChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipoChecklist
		{
			get { return _DescrizioneTipoChecklist; }
			set {
				if (DescrizioneTipoChecklist != value)
				{
					_DescrizioneTipoChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVociChecklist
		{
			get { return _ContieneVociChecklist; }
			set {
				if (ContieneVociChecklist != value)
				{
					_ContieneVociChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA_CHECKLIST
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SchedaChecklist
		{
			get { return _SchedaChecklist; }
			set {
				if (SchedaChecklist != value)
				{
					_SchedaChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO_CHECKLIST
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltroChecklist
		{
			get { return _IdFiltroChecklist; }
			set {
				if (IdFiltroChecklist != value)
				{
					_IdFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO_CHECKLIST
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltroChecklist
		{
			get { return _DescrizioneFiltroChecklist; }
			set {
				if (DescrizioneFiltroChecklist != value)
				{
					_DescrizioneFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO_CHECKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltroChecklist
		{
			get { return _OrdineFiltroChecklist; }
			set {
				if (OrdineFiltroChecklist != value)
				{
					_OrdineFiltroChecklist = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_SCHEDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoScheda
		{
			get { return _IdTipoScheda; }
			set {
				if (IdTipoScheda != value)
				{
					_IdTipoScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO_SCHEDA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipoScheda
		{
			get { return _DescrizioneTipoScheda; }
			set {
				if (DescrizioneTipoScheda != value)
				{
					_DescrizioneTipoScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI_SCHEDA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVociScheda
		{
			get { return _ContieneVociScheda; }
			set {
				if (ContieneVociScheda != value)
				{
					_ContieneVociScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA_SCHEDA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SchedaScheda
		{
			get { return _SchedaScheda; }
			set {
				if (SchedaScheda != value)
				{
					_SchedaScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO_SCHEDA
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltroScheda
		{
			get { return _IdFiltroScheda; }
			set {
				if (IdFiltroScheda != value)
				{
					_IdFiltroScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO_SCHEDA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltroScheda
		{
			get { return _DescrizioneFiltroScheda; }
			set {
				if (DescrizioneFiltroScheda != value)
				{
					_DescrizioneFiltroScheda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO_SCHEDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltroScheda
		{
			get { return _OrdineFiltroScheda; }
			set {
				if (OrdineFiltroScheda != value)
				{
					_OrdineFiltroScheda = value;
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
	/// Summary description for SchedaXChecklistModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SchedaXChecklistModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SchedaXChecklistModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SchedaXChecklistModifiche) info.GetValue(i.ToString(),typeof(SchedaXChecklistModifiche)));
			}
		}

		//Costruttore
		public SchedaXChecklistModificheCollection()
		{
			this.ItemType = typeof(SchedaXChecklistModifiche);
		}

		//Costruttore con provider
		public SchedaXChecklistModificheCollection(ISchedaXChecklistModificheProvider providerObj)
		{
			this.ItemType = typeof(SchedaXChecklistModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SchedaXChecklistModifiche this[int index]
		{
			get { return (SchedaXChecklistModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SchedaXChecklistModificheCollection GetChanges()
		{
			return (SchedaXChecklistModificheCollection) base.GetChanges();
		}

		[NonSerialized] private ISchedaXChecklistModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaXChecklistModificheProvider Provider
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
		public int Add(SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			if (SchedaXChecklistModificheObj.Provider == null) SchedaXChecklistModificheObj.Provider = this.Provider;
			return base.Add(SchedaXChecklistModificheObj);
		}

		//AddCollection
		public void AddCollection(SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionObj)
		{
			foreach (SchedaXChecklistModifiche SchedaXChecklistModificheObj in SchedaXChecklistModificheCollectionObj)
				this.Add(SchedaXChecklistModificheObj);
		}

		//Insert
		public void Insert(int index, SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			if (SchedaXChecklistModificheObj.Provider == null) SchedaXChecklistModificheObj.Provider = this.Provider;
			base.Insert(index, SchedaXChecklistModificheObj);
		}

		//CollectionGetById
		public SchedaXChecklistModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public SchedaXChecklistModificheCollection SubSelect(NullTypes.IntNT IdSchedaXChecklistEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdChecklistPadreEqualThis, 
NullTypes.IntNT IdChecklistFiglioEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT ObbligatorioEqualThis, 
NullTypes.DecimalNT PesoEqualThis, NullTypes.StringNT DescrizioneChecklistEqualThis, NullTypes.BoolNT FlagTemplateChecklistEqualThis, 
NullTypes.IntNT IdTipoChecklistEqualThis, NullTypes.StringNT DescrizioneTipoChecklistEqualThis, NullTypes.BoolNT ContieneVociChecklistEqualThis, 
NullTypes.BoolNT SchedaChecklistEqualThis, NullTypes.StringNT IdFiltroChecklistEqualThis, NullTypes.StringNT DescrizioneFiltroChecklistEqualThis, 
NullTypes.IntNT OrdineFiltroChecklistEqualThis, NullTypes.IntNT IdTipoSchedaEqualThis, NullTypes.StringNT DescrizioneTipoSchedaEqualThis, 
NullTypes.BoolNT ContieneVociSchedaEqualThis, NullTypes.BoolNT SchedaSchedaEqualThis, NullTypes.StringNT IdFiltroSchedaEqualThis, 
NullTypes.StringNT DescrizioneFiltroSchedaEqualThis, NullTypes.IntNT OrdineFiltroSchedaEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdModificaEqualThis)
		{
			SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionTemp = new SchedaXChecklistModificheCollection();
			foreach (SchedaXChecklistModifiche SchedaXChecklistModificheItem in this)
			{
				if (((IdSchedaXChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.IdSchedaXChecklist != null) && (SchedaXChecklistModificheItem.IdSchedaXChecklist.Value == IdSchedaXChecklistEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((SchedaXChecklistModificheItem.CfInserimento != null) && (SchedaXChecklistModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((SchedaXChecklistModificheItem.DataInserimento != null) && (SchedaXChecklistModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((SchedaXChecklistModificheItem.CfModifica != null) && (SchedaXChecklistModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((SchedaXChecklistModificheItem.DataModifica != null) && (SchedaXChecklistModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdChecklistPadreEqualThis == null) || ((SchedaXChecklistModificheItem.IdChecklistPadre != null) && (SchedaXChecklistModificheItem.IdChecklistPadre.Value == IdChecklistPadreEqualThis.Value))) && 
((IdChecklistFiglioEqualThis == null) || ((SchedaXChecklistModificheItem.IdChecklistFiglio != null) && (SchedaXChecklistModificheItem.IdChecklistFiglio.Value == IdChecklistFiglioEqualThis.Value))) && ((OrdineEqualThis == null) || ((SchedaXChecklistModificheItem.Ordine != null) && (SchedaXChecklistModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((ObbligatorioEqualThis == null) || ((SchedaXChecklistModificheItem.Obbligatorio != null) && (SchedaXChecklistModificheItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && 
((PesoEqualThis == null) || ((SchedaXChecklistModificheItem.Peso != null) && (SchedaXChecklistModificheItem.Peso.Value == PesoEqualThis.Value))) && ((DescrizioneChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.DescrizioneChecklist != null) && (SchedaXChecklistModificheItem.DescrizioneChecklist.Value == DescrizioneChecklistEqualThis.Value))) && ((FlagTemplateChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.FlagTemplateChecklist != null) && (SchedaXChecklistModificheItem.FlagTemplateChecklist.Value == FlagTemplateChecklistEqualThis.Value))) && 
((IdTipoChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.IdTipoChecklist != null) && (SchedaXChecklistModificheItem.IdTipoChecklist.Value == IdTipoChecklistEqualThis.Value))) && ((DescrizioneTipoChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.DescrizioneTipoChecklist != null) && (SchedaXChecklistModificheItem.DescrizioneTipoChecklist.Value == DescrizioneTipoChecklistEqualThis.Value))) && ((ContieneVociChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.ContieneVociChecklist != null) && (SchedaXChecklistModificheItem.ContieneVociChecklist.Value == ContieneVociChecklistEqualThis.Value))) && 
((SchedaChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.SchedaChecklist != null) && (SchedaXChecklistModificheItem.SchedaChecklist.Value == SchedaChecklistEqualThis.Value))) && ((IdFiltroChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.IdFiltroChecklist != null) && (SchedaXChecklistModificheItem.IdFiltroChecklist.Value == IdFiltroChecklistEqualThis.Value))) && ((DescrizioneFiltroChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.DescrizioneFiltroChecklist != null) && (SchedaXChecklistModificheItem.DescrizioneFiltroChecklist.Value == DescrizioneFiltroChecklistEqualThis.Value))) && 
((OrdineFiltroChecklistEqualThis == null) || ((SchedaXChecklistModificheItem.OrdineFiltroChecklist != null) && (SchedaXChecklistModificheItem.OrdineFiltroChecklist.Value == OrdineFiltroChecklistEqualThis.Value))) && ((IdTipoSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.IdTipoScheda != null) && (SchedaXChecklistModificheItem.IdTipoScheda.Value == IdTipoSchedaEqualThis.Value))) && ((DescrizioneTipoSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.DescrizioneTipoScheda != null) && (SchedaXChecklistModificheItem.DescrizioneTipoScheda.Value == DescrizioneTipoSchedaEqualThis.Value))) && 
((ContieneVociSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.ContieneVociScheda != null) && (SchedaXChecklistModificheItem.ContieneVociScheda.Value == ContieneVociSchedaEqualThis.Value))) && ((SchedaSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.SchedaScheda != null) && (SchedaXChecklistModificheItem.SchedaScheda.Value == SchedaSchedaEqualThis.Value))) && ((IdFiltroSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.IdFiltroScheda != null) && (SchedaXChecklistModificheItem.IdFiltroScheda.Value == IdFiltroSchedaEqualThis.Value))) && 
((DescrizioneFiltroSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.DescrizioneFiltroScheda != null) && (SchedaXChecklistModificheItem.DescrizioneFiltroScheda.Value == DescrizioneFiltroSchedaEqualThis.Value))) && ((OrdineFiltroSchedaEqualThis == null) || ((SchedaXChecklistModificheItem.OrdineFiltroScheda != null) && (SchedaXChecklistModificheItem.OrdineFiltroScheda.Value == OrdineFiltroSchedaEqualThis.Value))) && ((IdEqualThis == null) || ((SchedaXChecklistModificheItem.Id != null) && (SchedaXChecklistModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdModificaEqualThis == null) || ((SchedaXChecklistModificheItem.IdModifica != null) && (SchedaXChecklistModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					SchedaXChecklistModificheCollectionTemp.Add(SchedaXChecklistModificheItem);
				}
			}
			return SchedaXChecklistModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SchedaXChecklistModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SchedaXChecklistModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SchedaXChecklistModifiche SchedaXChecklistModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", SchedaXChecklistModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdSchedaXChecklist", SchedaXChecklistModificheObj.IdSchedaXChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", SchedaXChecklistModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", SchedaXChecklistModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", SchedaXChecklistModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", SchedaXChecklistModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistPadre", SchedaXChecklistModificheObj.IdChecklistPadre);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistFiglio", SchedaXChecklistModificheObj.IdChecklistFiglio);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", SchedaXChecklistModificheObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", SchedaXChecklistModificheObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", SchedaXChecklistModificheObj.Peso);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneChecklist", SchedaXChecklistModificheObj.DescrizioneChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplateChecklist", SchedaXChecklistModificheObj.FlagTemplateChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoChecklist", SchedaXChecklistModificheObj.IdTipoChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneTipoChecklist", SchedaXChecklistModificheObj.DescrizioneTipoChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "ContieneVociChecklist", SchedaXChecklistModificheObj.ContieneVociChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "SchedaChecklist", SchedaXChecklistModificheObj.SchedaChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiltroChecklist", SchedaXChecklistModificheObj.IdFiltroChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneFiltroChecklist", SchedaXChecklistModificheObj.DescrizioneFiltroChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineFiltroChecklist", SchedaXChecklistModificheObj.OrdineFiltroChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoScheda", SchedaXChecklistModificheObj.IdTipoScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneTipoScheda", SchedaXChecklistModificheObj.DescrizioneTipoScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "ContieneVociScheda", SchedaXChecklistModificheObj.ContieneVociScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "SchedaScheda", SchedaXChecklistModificheObj.SchedaScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiltroScheda", SchedaXChecklistModificheObj.IdFiltroScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneFiltroScheda", SchedaXChecklistModificheObj.DescrizioneFiltroScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineFiltroScheda", SchedaXChecklistModificheObj.OrdineFiltroScheda);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", SchedaXChecklistModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSchedaXChecklistModificheInsert", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdChecklistPadre", 
"IdChecklistFiglio", "Ordine", "Obbligatorio", 
"Peso", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdTipoChecklist", "DescrizioneTipoChecklist", "ContieneVociChecklist", 
"SchedaChecklist", "IdFiltroChecklist", "DescrizioneFiltroChecklist", 
"OrdineFiltroChecklist", "IdTipoScheda", "DescrizioneTipoScheda", 
"ContieneVociScheda", "SchedaScheda", "IdFiltroScheda", 
"DescrizioneFiltroScheda", "OrdineFiltroScheda", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "string", "bool", 
"int", "string", "bool", 
"bool", "string", "string", 
"int", "int", "string", 
"bool", "bool", "string", 
"string", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,SchedaXChecklistModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SchedaXChecklistModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXChecklistModificheObj.IsDirty = false;
				SchedaXChecklistModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaXChecklistModificheUpdate", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdChecklistPadre", 
"IdChecklistFiglio", "Ordine", "Obbligatorio", 
"Peso", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdTipoChecklist", "DescrizioneTipoChecklist", "ContieneVociChecklist", 
"SchedaChecklist", "IdFiltroChecklist", "DescrizioneFiltroChecklist", 
"OrdineFiltroChecklist", "IdTipoScheda", "DescrizioneTipoScheda", 
"ContieneVociScheda", "SchedaScheda", "IdFiltroScheda", 
"DescrizioneFiltroScheda", "OrdineFiltroScheda", "Id", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "string", "bool", 
"int", "string", "bool", 
"bool", "string", "string", 
"int", "int", "string", 
"bool", "bool", "string", 
"string", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,SchedaXChecklistModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					SchedaXChecklistModificheObj.DataModifica = d;
				}
				SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXChecklistModificheObj.IsDirty = false;
				SchedaXChecklistModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			switch (SchedaXChecklistModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SchedaXChecklistModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SchedaXChecklistModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SchedaXChecklistModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaXChecklistModificheUpdate", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdChecklistPadre", 
"IdChecklistFiglio", "Ordine", "Obbligatorio", 
"Peso", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdTipoChecklist", "DescrizioneTipoChecklist", "ContieneVociChecklist", 
"SchedaChecklist", "IdFiltroChecklist", "DescrizioneFiltroChecklist", 
"OrdineFiltroChecklist", "IdTipoScheda", "DescrizioneTipoScheda", 
"ContieneVociScheda", "SchedaScheda", "IdFiltroScheda", 
"DescrizioneFiltroScheda", "OrdineFiltroScheda", "Id", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "string", "bool", 
"int", "string", "bool", 
"bool", "string", "string", 
"int", "int", "string", 
"bool", "bool", "string", 
"string", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZSchedaXChecklistModificheInsert", new string[] {"IdSchedaXChecklist", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdChecklistPadre", 
"IdChecklistFiglio", "Ordine", "Obbligatorio", 
"Peso", "DescrizioneChecklist", "FlagTemplateChecklist", 
"IdTipoChecklist", "DescrizioneTipoChecklist", "ContieneVociChecklist", 
"SchedaChecklist", "IdFiltroChecklist", "DescrizioneFiltroChecklist", 
"OrdineFiltroChecklist", "IdTipoScheda", "DescrizioneTipoScheda", 
"ContieneVociScheda", "SchedaScheda", "IdFiltroScheda", 
"DescrizioneFiltroScheda", "OrdineFiltroScheda", 
"IdModifica"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "string", "bool", 
"int", "string", "bool", 
"bool", "string", "string", 
"int", "int", "string", 
"bool", "bool", "string", 
"string", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXChecklistModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < SchedaXChecklistModificheCollectionObj.Count; i++)
				{
					switch (SchedaXChecklistModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SchedaXChecklistModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SchedaXChecklistModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SchedaXChecklistModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									SchedaXChecklistModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SchedaXChecklistModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)SchedaXChecklistModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SchedaXChecklistModificheCollectionObj.Count; i++)
				{
					if ((SchedaXChecklistModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXChecklistModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaXChecklistModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SchedaXChecklistModificheCollectionObj[i].IsDirty = false;
						SchedaXChecklistModificheCollectionObj[i].IsPersistent = true;
					}
					if ((SchedaXChecklistModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SchedaXChecklistModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaXChecklistModificheCollectionObj[i].IsDirty = false;
						SchedaXChecklistModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SchedaXChecklistModifiche SchedaXChecklistModificheObj)
		{
			int returnValue = 0;
			if (SchedaXChecklistModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, SchedaXChecklistModificheObj.Id);
			}
			SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SchedaXChecklistModificheObj.IsDirty = false;
			SchedaXChecklistModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXChecklistModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXChecklistModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < SchedaXChecklistModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", SchedaXChecklistModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SchedaXChecklistModificheCollectionObj.Count; i++)
				{
					if ((SchedaXChecklistModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXChecklistModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaXChecklistModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaXChecklistModificheCollectionObj[i].IsDirty = false;
						SchedaXChecklistModificheCollectionObj[i].IsPersistent = false;
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
		public static SchedaXChecklistModifiche GetById(DbProvider db, int IdValue)
		{
			SchedaXChecklistModifiche SchedaXChecklistModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSchedaXChecklistModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SchedaXChecklistModificheObj = GetFromDatareader(db);
				SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXChecklistModificheObj.IsDirty = false;
				SchedaXChecklistModificheObj.IsPersistent = true;
			}
			db.Close();
			return SchedaXChecklistModificheObj;
		}

		//getFromDatareader
		public static SchedaXChecklistModifiche GetFromDatareader(DbProvider db)
		{
			SchedaXChecklistModifiche SchedaXChecklistModificheObj = new SchedaXChecklistModifiche();
			SchedaXChecklistModificheObj.IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
			SchedaXChecklistModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			SchedaXChecklistModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			SchedaXChecklistModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			SchedaXChecklistModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			SchedaXChecklistModificheObj.IdChecklistPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_PADRE"]);
			SchedaXChecklistModificheObj.IdChecklistFiglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_FIGLIO"]);
			SchedaXChecklistModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			SchedaXChecklistModificheObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			SchedaXChecklistModificheObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
			SchedaXChecklistModificheObj.DescrizioneChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST"]);
			SchedaXChecklistModificheObj.FlagTemplateChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE_CHECKLIST"]);
			SchedaXChecklistModificheObj.IdTipoChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CHECKLIST"]);
			SchedaXChecklistModificheObj.DescrizioneTipoChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_CHECKLIST"]);
			SchedaXChecklistModificheObj.ContieneVociChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_CHECKLIST"]);
			SchedaXChecklistModificheObj.SchedaChecklist = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_CHECKLIST"]);
			SchedaXChecklistModificheObj.IdFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_CHECKLIST"]);
			SchedaXChecklistModificheObj.DescrizioneFiltroChecklist = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_CHECKLIST"]);
			SchedaXChecklistModificheObj.OrdineFiltroChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_CHECKLIST"]);
			SchedaXChecklistModificheObj.IdTipoScheda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_SCHEDA"]);
			SchedaXChecklistModificheObj.DescrizioneTipoScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_SCHEDA"]);
			SchedaXChecklistModificheObj.ContieneVociScheda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_SCHEDA"]);
			SchedaXChecklistModificheObj.SchedaScheda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_SCHEDA"]);
			SchedaXChecklistModificheObj.IdFiltroScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO_SCHEDA"]);
			SchedaXChecklistModificheObj.DescrizioneFiltroScheda = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO_SCHEDA"]);
			SchedaXChecklistModificheObj.OrdineFiltroScheda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO_SCHEDA"]);
			SchedaXChecklistModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			SchedaXChecklistModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SchedaXChecklistModificheObj.IsDirty = false;
			SchedaXChecklistModificheObj.IsPersistent = true;
			return SchedaXChecklistModificheObj;
		}

		//Find Select

		public static SchedaXChecklistModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis, 
SiarLibrary.NullTypes.IntNT IdChecklistFiglioEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, 
SiarLibrary.NullTypes.DecimalNT PesoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneChecklistEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateChecklistEqualThis, 
SiarLibrary.NullTypes.IntNT IdTipoChecklistEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneTipoChecklistEqualThis, SiarLibrary.NullTypes.BoolNT ContieneVociChecklistEqualThis, 
SiarLibrary.NullTypes.BoolNT SchedaChecklistEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroChecklistEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneFiltroChecklistEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineFiltroChecklistEqualThis, SiarLibrary.NullTypes.IntNT IdTipoSchedaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneTipoSchedaEqualThis, 
SiarLibrary.NullTypes.BoolNT ContieneVociSchedaEqualThis, SiarLibrary.NullTypes.BoolNT SchedaSchedaEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroSchedaEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneFiltroSchedaEqualThis, SiarLibrary.NullTypes.IntNT OrdineFiltroSchedaEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionObj = new SchedaXChecklistModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zschedaxchecklistmodifichefindselect", new string[] {"IdSchedaXChecklistequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdChecklistPadreequalthis", 
"IdChecklistFiglioequalthis", "Ordineequalthis", "Obbligatorioequalthis", 
"Pesoequalthis", "DescrizioneChecklistequalthis", "FlagTemplateChecklistequalthis", 
"IdTipoChecklistequalthis", "DescrizioneTipoChecklistequalthis", "ContieneVociChecklistequalthis", 
"SchedaChecklistequalthis", "IdFiltroChecklistequalthis", "DescrizioneFiltroChecklistequalthis", 
"OrdineFiltroChecklistequalthis", "IdTipoSchedaequalthis", "DescrizioneTipoSchedaequalthis", 
"ContieneVociSchedaequalthis", "SchedaSchedaequalthis", "IdFiltroSchedaequalthis", 
"DescrizioneFiltroSchedaequalthis", "OrdineFiltroSchedaequalthis", "Idequalthis", 
"IdModificaequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "bool", 
"decimal", "string", "bool", 
"int", "string", "bool", 
"bool", "string", "string", 
"int", "int", "string", 
"bool", "bool", "string", 
"string", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistFiglioequalthis", IdChecklistFiglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneChecklistequalthis", DescrizioneChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateChecklistequalthis", FlagTemplateChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoChecklistequalthis", IdTipoChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneTipoChecklistequalthis", DescrizioneTipoChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContieneVociChecklistequalthis", ContieneVociChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SchedaChecklistequalthis", SchedaChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroChecklistequalthis", IdFiltroChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneFiltroChecklistequalthis", DescrizioneFiltroChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFiltroChecklistequalthis", OrdineFiltroChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoSchedaequalthis", IdTipoSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneTipoSchedaequalthis", DescrizioneTipoSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContieneVociSchedaequalthis", ContieneVociSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SchedaSchedaequalthis", SchedaSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroSchedaequalthis", IdFiltroSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneFiltroSchedaequalthis", DescrizioneFiltroSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFiltroSchedaequalthis", OrdineFiltroSchedaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			SchedaXChecklistModifiche SchedaXChecklistModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SchedaXChecklistModificheObj = GetFromDatareader(db);
				SchedaXChecklistModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXChecklistModificheObj.IsDirty = false;
				SchedaXChecklistModificheObj.IsPersistent = true;
				SchedaXChecklistModificheCollectionObj.Add(SchedaXChecklistModificheObj);
			}
			db.Close();
			return SchedaXChecklistModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SchedaXChecklistModificheCollectionProvider:ISchedaXChecklistModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SchedaXChecklistModificheCollectionProvider : ISchedaXChecklistModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SchedaXChecklistModifiche
		protected SchedaXChecklistModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SchedaXChecklistModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SchedaXChecklistModificheCollection(this);
		}

		//Costruttore3: ha in input schedaxchecklistmodificheCollectionObj - non popola la collection
		public SchedaXChecklistModificheCollectionProvider(SchedaXChecklistModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SchedaXChecklistModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SchedaXChecklistModificheCollection(this);
		}

		//Get e Set
		public SchedaXChecklistModificheCollection CollectionObj
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
		public int SaveCollection(SchedaXChecklistModificheCollection collectionObj)
		{
			return SchedaXChecklistModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SchedaXChecklistModifiche schedaxchecklistmodificheObj)
		{
			return SchedaXChecklistModificheDAL.Save(_dbProviderObj, schedaxchecklistmodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SchedaXChecklistModificheCollection collectionObj)
		{
			return SchedaXChecklistModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SchedaXChecklistModifiche schedaxchecklistmodificheObj)
		{
			return SchedaXChecklistModificheDAL.Delete(_dbProviderObj, schedaxchecklistmodificheObj);
		}

		//getById
		public SchedaXChecklistModifiche GetById(IntNT IdValue)
		{
			SchedaXChecklistModifiche SchedaXChecklistModificheTemp = SchedaXChecklistModificheDAL.GetById(_dbProviderObj, IdValue);
			if (SchedaXChecklistModificheTemp!=null) SchedaXChecklistModificheTemp.Provider = this;
			return SchedaXChecklistModificheTemp;
		}

		//Select: popola la collection
		public SchedaXChecklistModificheCollection Select(IntNT IdschedaxchecklistEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdchecklistpadreEqualThis, 
IntNT IdchecklistfiglioEqualThis, IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, 
DecimalNT PesoEqualThis, StringNT DescrizionechecklistEqualThis, BoolNT FlagtemplatechecklistEqualThis, 
IntNT IdtipochecklistEqualThis, StringNT DescrizionetipochecklistEqualThis, BoolNT ContienevocichecklistEqualThis, 
BoolNT SchedachecklistEqualThis, StringNT IdfiltrochecklistEqualThis, StringNT DescrizionefiltrochecklistEqualThis, 
IntNT OrdinefiltrochecklistEqualThis, IntNT IdtiposchedaEqualThis, StringNT DescrizionetiposchedaEqualThis, 
BoolNT ContienevocischedaEqualThis, BoolNT SchedaschedaEqualThis, StringNT IdfiltroschedaEqualThis, 
StringNT DescrizionefiltroschedaEqualThis, IntNT OrdinefiltroschedaEqualThis, IntNT IdEqualThis, 
IntNT IdmodificaEqualThis)
		{
			SchedaXChecklistModificheCollection SchedaXChecklistModificheCollectionTemp = SchedaXChecklistModificheDAL.Select(_dbProviderObj, IdschedaxchecklistEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdchecklistpadreEqualThis, 
IdchecklistfiglioEqualThis, OrdineEqualThis, ObbligatorioEqualThis, 
PesoEqualThis, DescrizionechecklistEqualThis, FlagtemplatechecklistEqualThis, 
IdtipochecklistEqualThis, DescrizionetipochecklistEqualThis, ContienevocichecklistEqualThis, 
SchedachecklistEqualThis, IdfiltrochecklistEqualThis, DescrizionefiltrochecklistEqualThis, 
OrdinefiltrochecklistEqualThis, IdtiposchedaEqualThis, DescrizionetiposchedaEqualThis, 
ContienevocischedaEqualThis, SchedaschedaEqualThis, IdfiltroschedaEqualThis, 
DescrizionefiltroschedaEqualThis, OrdinefiltroschedaEqualThis, IdEqualThis, 
IdmodificaEqualThis);
			SchedaXChecklistModificheCollectionTemp.Provider = this;
			return SchedaXChecklistModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCHEDA_X_CHECKLIST_MODIFICHE>
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
</SCHEDA_X_CHECKLIST_MODIFICHE>
*/
