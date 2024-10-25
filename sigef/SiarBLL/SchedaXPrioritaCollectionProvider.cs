using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SchedaXPriorita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISchedaXPrioritaProvider
	{
		int Save(SchedaXPriorita SchedaXPrioritaObj);
		int SaveCollection(SchedaXPrioritaCollection collectionObj);
		int Delete(SchedaXPriorita SchedaXPrioritaObj);
		int DeleteCollection(SchedaXPrioritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SchedaXPriorita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SchedaXPriorita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSchedaValutazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.StringNT _Priorita;
		private NullTypes.StringNT _CodLivello;
		private NullTypes.IntNT _Ordine;
		private NullTypes.DecimalNT _Peso;
		private NullTypes.DecimalNT _ValoreMax;
		private NullTypes.DecimalNT _ValoreMin;
		private NullTypes.DecimalNT _AiutoAddizionale;
		private NullTypes.BoolNT _Selezionabile;
		private NullTypes.BoolNT _PluriValore;
		private NullTypes.StringNT _Eval;
		private NullTypes.BoolNT _FlagManuale;
		private NullTypes.BoolNT _IsMax;
		private NullTypes.BoolNT _InputNumerico;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.BoolNT _PluriValoreSql;
		private NullTypes.StringNT _QueryPlurivalore;
		[NonSerialized] private ISchedaXPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaXPrioritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SchedaXPriorita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SCHEDA_VALUTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSchedaValutazione
		{
			get { return _IdSchedaValutazione; }
			set {
				if (IdSchedaValutazione != value)
				{
					_IdSchedaValutazione = value;
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
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_TEMPLATE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplate
		{
			get { return _FlagTemplate; }
			set {
				if (FlagTemplate != value)
				{
					_FlagTemplate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRIORITA
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Priorita
		{
			get { return _Priorita; }
			set {
				if (Priorita != value)
				{
					_Priorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_LIVELLO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodLivello
		{
			get { return _CodLivello; }
			set {
				if (CodLivello != value)
				{
					_CodLivello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// Default:((0))
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
		/// Corrisponde al campo:VALORE_MAX
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreMax
		{
			get { return _ValoreMax; }
			set {
				if (ValoreMax != value)
				{
					_ValoreMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_MIN
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreMin
		{
			get { return _ValoreMin; }
			set {
				if (ValoreMin != value)
				{
					_ValoreMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AIUTO_ADDIZIONALE
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT AiutoAddizionale
		{
			get { return _AiutoAddizionale; }
			set {
				if (AiutoAddizionale != value)
				{
					_AiutoAddizionale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SELEZIONABILE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Selezionabile
		{
			get { return _Selezionabile; }
			set {
				if (Selezionabile != value)
				{
					_Selezionabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLURI_VALORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PluriValore
		{
			get { return _PluriValore; }
			set {
				if (PluriValore != value)
				{
					_PluriValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EVAL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT Eval
		{
			get { return _Eval; }
			set {
				if (Eval != value)
				{
					_Eval = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagManuale
		{
			get { return _FlagManuale; }
			set {
				if (FlagManuale != value)
				{
					_FlagManuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IS_MAX
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IsMax
		{
			get { return _IsMax; }
			set {
				if (IsMax != value)
				{
					_IsMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INPUT_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InputNumerico
		{
			get { return _InputNumerico; }
			set {
				if (InputNumerico != value)
				{
					_InputNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATETIME
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Datetime
		{
			get { return _Datetime; }
			set {
				if (Datetime != value)
				{
					_Datetime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_SEMPLICE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoSemplice
		{
			get { return _TestoSemplice; }
			set {
				if (TestoSemplice != value)
				{
					_TestoSemplice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_AREA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoArea
		{
			get { return _TestoArea; }
			set {
				if (TestoArea != value)
				{
					_TestoArea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLURI_VALORE_SQL
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PluriValoreSql
		{
			get { return _PluriValoreSql; }
			set {
				if (PluriValoreSql != value)
				{
					_PluriValoreSql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_PLURIVALORE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT QueryPlurivalore
		{
			get { return _QueryPlurivalore; }
			set {
				if (QueryPlurivalore != value)
				{
					_QueryPlurivalore = value;
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
	/// Summary description for SchedaXPrioritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SchedaXPrioritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SchedaXPrioritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SchedaXPriorita) info.GetValue(i.ToString(),typeof(SchedaXPriorita)));
			}
		}

		//Costruttore
		public SchedaXPrioritaCollection()
		{
			this.ItemType = typeof(SchedaXPriorita);
		}

		//Costruttore con provider
		public SchedaXPrioritaCollection(ISchedaXPrioritaProvider providerObj)
		{
			this.ItemType = typeof(SchedaXPriorita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SchedaXPriorita this[int index]
		{
			get { return (SchedaXPriorita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SchedaXPrioritaCollection GetChanges()
		{
			return (SchedaXPrioritaCollection) base.GetChanges();
		}

		[NonSerialized] private ISchedaXPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaXPrioritaProvider Provider
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
		public int Add(SchedaXPriorita SchedaXPrioritaObj)
		{
			if (SchedaXPrioritaObj.Provider == null) SchedaXPrioritaObj.Provider = this.Provider;
			return base.Add(SchedaXPrioritaObj);
		}

		//AddCollection
		public void AddCollection(SchedaXPrioritaCollection SchedaXPrioritaCollectionObj)
		{
			foreach (SchedaXPriorita SchedaXPrioritaObj in SchedaXPrioritaCollectionObj)
				this.Add(SchedaXPrioritaObj);
		}

		//Insert
		public void Insert(int index, SchedaXPriorita SchedaXPrioritaObj)
		{
			if (SchedaXPrioritaObj.Provider == null) SchedaXPrioritaObj.Provider = this.Provider;
			base.Insert(index, SchedaXPrioritaObj);
		}

		//CollectionGetById
		public SchedaXPriorita CollectionGetById(NullTypes.IntNT IdSchedaValutazioneValue, NullTypes.IntNT IdPrioritaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSchedaValutazione == IdSchedaValutazioneValue) && (this[i].IdPriorita == IdPrioritaValue))
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
		public SchedaXPrioritaCollection SubSelect(NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.DecimalNT PesoEqualThis, NullTypes.DecimalNT AiutoAddizionaleEqualThis, NullTypes.BoolNT SelezionabileEqualThis, 
NullTypes.BoolNT IsMaxEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = new SchedaXPrioritaCollection();
			foreach (SchedaXPriorita SchedaXPrioritaItem in this)
			{
				if (((IdSchedaValutazioneEqualThis == null) || ((SchedaXPrioritaItem.IdSchedaValutazione != null) && (SchedaXPrioritaItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((IdPrioritaEqualThis == null) || ((SchedaXPrioritaItem.IdPriorita != null) && (SchedaXPrioritaItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((OrdineEqualThis == null) || ((SchedaXPrioritaItem.Ordine != null) && (SchedaXPrioritaItem.Ordine.Value == OrdineEqualThis.Value))) && 
((PesoEqualThis == null) || ((SchedaXPrioritaItem.Peso != null) && (SchedaXPrioritaItem.Peso.Value == PesoEqualThis.Value))) && ((AiutoAddizionaleEqualThis == null) || ((SchedaXPrioritaItem.AiutoAddizionale != null) && (SchedaXPrioritaItem.AiutoAddizionale.Value == AiutoAddizionaleEqualThis.Value))) && ((SelezionabileEqualThis == null) || ((SchedaXPrioritaItem.Selezionabile != null) && (SchedaXPrioritaItem.Selezionabile.Value == SelezionabileEqualThis.Value))) && 
((IsMaxEqualThis == null) || ((SchedaXPrioritaItem.IsMax != null) && (SchedaXPrioritaItem.IsMax.Value == IsMaxEqualThis.Value))))
				{
					SchedaXPrioritaCollectionTemp.Add(SchedaXPrioritaItem);
				}
			}
			return SchedaXPrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public SchedaXPrioritaCollection FiltroLivello(NullTypes.StringNT CodLivelloEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = new SchedaXPrioritaCollection();
			foreach (SchedaXPriorita SchedaXPrioritaItem in this)
			{
				if (((CodLivelloEqualThis == null) || ((SchedaXPrioritaItem.CodLivello != null) && (SchedaXPrioritaItem.CodLivello.Value == CodLivelloEqualThis.Value))))
				{
					SchedaXPrioritaCollectionTemp.Add(SchedaXPrioritaItem);
				}
			}
			return SchedaXPrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public SchedaXPrioritaCollection FiltroManuale(NullTypes.BoolNT FlagManualeEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = new SchedaXPrioritaCollection();
			foreach (SchedaXPriorita SchedaXPrioritaItem in this)
			{
				if (((FlagManualeEqualThis == null) || ((SchedaXPrioritaItem.FlagManuale != null) && (SchedaXPrioritaItem.FlagManuale.Value == FlagManualeEqualThis.Value))))
				{
					SchedaXPrioritaCollectionTemp.Add(SchedaXPrioritaItem);
				}
			}
			return SchedaXPrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public SchedaXPrioritaCollection FiltroSelezionabile(NullTypes.BoolNT SelezionabileEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = new SchedaXPrioritaCollection();
			foreach (SchedaXPriorita SchedaXPrioritaItem in this)
			{
				if (((SelezionabileEqualThis == null) || ((SchedaXPrioritaItem.Selezionabile != null) && (SchedaXPrioritaItem.Selezionabile.Value == SelezionabileEqualThis.Value))))
				{
					SchedaXPrioritaCollectionTemp.Add(SchedaXPrioritaItem);
				}
			}
			return SchedaXPrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public SchedaXPrioritaCollection FiltroMisura(NullTypes.StringNT MisuraLike)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = new SchedaXPrioritaCollection();
			foreach (SchedaXPriorita SchedaXPrioritaItem in this)
			{
				if (((MisuraLike == null) || ((SchedaXPrioritaItem.Misura !=null) &&(SchedaXPrioritaItem.Misura.Like(MisuraLike.Value)))))
				{
					SchedaXPrioritaCollectionTemp.Add(SchedaXPrioritaItem);
				}
			}
			return SchedaXPrioritaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SchedaXPrioritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SchedaXPrioritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SchedaXPriorita SchedaXPrioritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdSchedaValutazione", SchedaXPrioritaObj.IdSchedaValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", SchedaXPrioritaObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", SchedaXPrioritaObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", SchedaXPrioritaObj.Peso);
			DbProvider.SetCmdParam(cmd,firstChar + "AiutoAddizionale", SchedaXPrioritaObj.AiutoAddizionale);
			DbProvider.SetCmdParam(cmd,firstChar + "Selezionabile", SchedaXPrioritaObj.Selezionabile);
			DbProvider.SetCmdParam(cmd,firstChar + "IsMax", SchedaXPrioritaObj.IsMax);
		}
		//Insert
		private static int Insert(DbProvider db, SchedaXPriorita SchedaXPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSchedaXPrioritaInsert", new string[] {"IdSchedaValutazione", 
"IdPriorita", 
"Ordine", "Peso", 
"AiutoAddizionale", "Selezionabile", 

"IsMax", }, new string[] {"int", 
"int", 
"int", "decimal", 
"decimal", "bool", 

"bool", },"");
				CompileIUCmd(false, insertCmd,SchedaXPrioritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SchedaXPrioritaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
				}
				SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXPrioritaObj.IsDirty = false;
				SchedaXPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SchedaXPriorita SchedaXPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaXPrioritaUpdate", new string[] {"IdSchedaValutazione", 
"IdPriorita", 
"Ordine", "Peso", 
"AiutoAddizionale", "Selezionabile", 

"IsMax", }, new string[] {"int", 
"int", 
"int", "decimal", 
"decimal", "bool", 

"bool", },"");
				CompileIUCmd(true, updateCmd,SchedaXPrioritaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXPrioritaObj.IsDirty = false;
				SchedaXPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SchedaXPriorita SchedaXPrioritaObj)
		{
			switch (SchedaXPrioritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SchedaXPrioritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SchedaXPrioritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SchedaXPrioritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SchedaXPrioritaCollection SchedaXPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSchedaXPrioritaUpdate", new string[] {"IdSchedaValutazione", 
"IdPriorita", 
"Ordine", "Peso", 
"AiutoAddizionale", "Selezionabile", 

"IsMax", }, new string[] {"int", 
"int", 
"int", "decimal", 
"decimal", "bool", 

"bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZSchedaXPrioritaInsert", new string[] {"IdSchedaValutazione", 
"IdPriorita", 
"Ordine", "Peso", 
"AiutoAddizionale", "Selezionabile", 

"IsMax", }, new string[] {"int", 
"int", 
"int", "decimal", 
"decimal", "bool", 

"bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXPrioritaDelete", new string[] {"IdSchedaValutazione", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < SchedaXPrioritaCollectionObj.Count; i++)
				{
					switch (SchedaXPrioritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SchedaXPrioritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SchedaXPrioritaCollectionObj[i].Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SchedaXPrioritaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SchedaXPrioritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)SchedaXPrioritaCollectionObj[i].IdSchedaValutazione);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)SchedaXPrioritaCollectionObj[i].IdPriorita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SchedaXPrioritaCollectionObj.Count; i++)
				{
					if ((SchedaXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SchedaXPrioritaCollectionObj[i].IsDirty = false;
						SchedaXPrioritaCollectionObj[i].IsPersistent = true;
					}
					if ((SchedaXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SchedaXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaXPrioritaCollectionObj[i].IsDirty = false;
						SchedaXPrioritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SchedaXPriorita SchedaXPrioritaObj)
		{
			int returnValue = 0;
			if (SchedaXPrioritaObj.IsPersistent) 
			{
				returnValue = Delete(db, SchedaXPrioritaObj.IdSchedaValutazione, SchedaXPrioritaObj.IdPriorita);
			}
			SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SchedaXPrioritaObj.IsDirty = false;
			SchedaXPrioritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSchedaValutazioneValue, int IdPrioritaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXPrioritaDelete", new string[] {"IdSchedaValutazione", "IdPriorita"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SchedaXPrioritaCollection SchedaXPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSchedaXPrioritaDelete", new string[] {"IdSchedaValutazione", "IdPriorita"}, new string[] {"int", "int"},"");
				for (int i = 0; i < SchedaXPrioritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSchedaValutazione", SchedaXPrioritaCollectionObj[i].IdSchedaValutazione);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", SchedaXPrioritaCollectionObj[i].IdPriorita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SchedaXPrioritaCollectionObj.Count; i++)
				{
					if ((SchedaXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SchedaXPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SchedaXPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SchedaXPrioritaCollectionObj[i].IsDirty = false;
						SchedaXPrioritaCollectionObj[i].IsPersistent = false;
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
		public static SchedaXPriorita GetById(DbProvider db, int IdSchedaValutazioneValue, int IdPrioritaValue)
		{
			SchedaXPriorita SchedaXPrioritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSchedaXPrioritaGetById", new string[] {"IdSchedaValutazione", "IdPriorita"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSchedaValutazione", (SiarLibrary.NullTypes.IntNT)IdSchedaValutazioneValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SchedaXPrioritaObj = GetFromDatareader(db);
				SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXPrioritaObj.IsDirty = false;
				SchedaXPrioritaObj.IsPersistent = true;
			}
			db.Close();
			return SchedaXPrioritaObj;
		}

		//getFromDatareader
		public static SchedaXPriorita GetFromDatareader(DbProvider db)
		{
			SchedaXPriorita SchedaXPrioritaObj = new SchedaXPriorita();
			SchedaXPrioritaObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
			SchedaXPrioritaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SchedaXPrioritaObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			SchedaXPrioritaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			SchedaXPrioritaObj.Priorita = new SiarLibrary.NullTypes.StringNT(db.DataReader["PRIORITA"]);
			SchedaXPrioritaObj.CodLivello = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_LIVELLO"]);
			SchedaXPrioritaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			SchedaXPrioritaObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
			SchedaXPrioritaObj.ValoreMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_MAX"]);
			SchedaXPrioritaObj.ValoreMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_MIN"]);
			SchedaXPrioritaObj.AiutoAddizionale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AIUTO_ADDIZIONALE"]);
			SchedaXPrioritaObj.Selezionabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONABILE"]);
			SchedaXPrioritaObj.PluriValore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE"]);
			SchedaXPrioritaObj.Eval = new SiarLibrary.NullTypes.StringNT(db.DataReader["EVAL"]);
			SchedaXPrioritaObj.FlagManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MANUALE"]);
			SchedaXPrioritaObj.IsMax = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_MAX"]);
			SchedaXPrioritaObj.InputNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INPUT_NUMERICO"]);
			SchedaXPrioritaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			SchedaXPrioritaObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			SchedaXPrioritaObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			SchedaXPrioritaObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			SchedaXPrioritaObj.PluriValoreSql = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE_SQL"]);
			SchedaXPrioritaObj.QueryPlurivalore = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_PLURIVALORE"]);
			SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SchedaXPrioritaObj.IsDirty = false;
			SchedaXPrioritaObj.IsPersistent = true;
			return SchedaXPrioritaObj;
		}

		//Find Select

		public static SchedaXPrioritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.DecimalNT PesoEqualThis, SiarLibrary.NullTypes.DecimalNT AiutoAddizionaleEqualThis, SiarLibrary.NullTypes.BoolNT SelezionabileEqualThis, 
SiarLibrary.NullTypes.BoolNT IsMaxEqualThis)

		{

			SchedaXPrioritaCollection SchedaXPrioritaCollectionObj = new SchedaXPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zschedaxprioritafindselect", new string[] {"IdSchedaValutazioneequalthis", "IdPrioritaequalthis", "Ordineequalthis", 
"Pesoequalthis", "AiutoAddizionaleequalthis", "Selezionabileequalthis", 
"IsMaxequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AiutoAddizionaleequalthis", AiutoAddizionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Selezionabileequalthis", SelezionabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IsMaxequalthis", IsMaxEqualThis);
			SchedaXPriorita SchedaXPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SchedaXPrioritaObj = GetFromDatareader(db);
				SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXPrioritaObj.IsDirty = false;
				SchedaXPrioritaObj.IsPersistent = true;
				SchedaXPrioritaCollectionObj.Add(SchedaXPrioritaObj);
			}
			db.Close();
			return SchedaXPrioritaCollectionObj;
		}

		//Find Find

		public static SchedaXPrioritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, 
SiarLibrary.NullTypes.StringNT CodLivelloEqualThis, SiarLibrary.NullTypes.BoolNT FlagManualeEqualThis)

		{

			SchedaXPrioritaCollection SchedaXPrioritaCollectionObj = new SchedaXPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zschedaxprioritafindfind", new string[] {"IdSchedaValutazioneequalthis", "IdPrioritaequalthis", "FlagTemplateequalthis", 
"CodLivelloequalthis", "FlagManualeequalthis"}, new string[] {"int", "int", "bool", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodLivelloequalthis", CodLivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagManualeequalthis", FlagManualeEqualThis);
			SchedaXPriorita SchedaXPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SchedaXPrioritaObj = GetFromDatareader(db);
				SchedaXPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SchedaXPrioritaObj.IsDirty = false;
				SchedaXPrioritaObj.IsPersistent = true;
				SchedaXPrioritaCollectionObj.Add(SchedaXPrioritaObj);
			}
			db.Close();
			return SchedaXPrioritaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SchedaXPrioritaCollectionProvider:ISchedaXPrioritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SchedaXPrioritaCollectionProvider : ISchedaXPrioritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SchedaXPriorita
		protected SchedaXPrioritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SchedaXPrioritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SchedaXPrioritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public SchedaXPrioritaCollectionProvider(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, BoolNT FlagtemplateEqualThis, 
StringNT CodlivelloEqualThis, BoolNT FlagmanualeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdschedavalutazioneEqualThis, IdprioritaEqualThis, FlagtemplateEqualThis, 
CodlivelloEqualThis, FlagmanualeEqualThis);
		}

		//Costruttore3: ha in input schedaxprioritaCollectionObj - non popola la collection
		public SchedaXPrioritaCollectionProvider(SchedaXPrioritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SchedaXPrioritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SchedaXPrioritaCollection(this);
		}

		//Get e Set
		public SchedaXPrioritaCollection CollectionObj
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
		public int SaveCollection(SchedaXPrioritaCollection collectionObj)
		{
			return SchedaXPrioritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SchedaXPriorita schedaxprioritaObj)
		{
			return SchedaXPrioritaDAL.Save(_dbProviderObj, schedaxprioritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SchedaXPrioritaCollection collectionObj)
		{
			return SchedaXPrioritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SchedaXPriorita schedaxprioritaObj)
		{
			return SchedaXPrioritaDAL.Delete(_dbProviderObj, schedaxprioritaObj);
		}

		//getById
		public SchedaXPriorita GetById(IntNT IdSchedaValutazioneValue, IntNT IdPrioritaValue)
		{
			SchedaXPriorita SchedaXPrioritaTemp = SchedaXPrioritaDAL.GetById(_dbProviderObj, IdSchedaValutazioneValue, IdPrioritaValue);
			if (SchedaXPrioritaTemp!=null) SchedaXPrioritaTemp.Provider = this;
			return SchedaXPrioritaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SchedaXPrioritaCollection Select(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, IntNT OrdineEqualThis, 
DecimalNT PesoEqualThis, DecimalNT AiutoaddizionaleEqualThis, BoolNT SelezionabileEqualThis, 
BoolNT IsmaxEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = SchedaXPrioritaDAL.Select(_dbProviderObj, IdschedavalutazioneEqualThis, IdprioritaEqualThis, OrdineEqualThis, 
PesoEqualThis, AiutoaddizionaleEqualThis, SelezionabileEqualThis, 
IsmaxEqualThis);
			SchedaXPrioritaCollectionTemp.Provider = this;
			return SchedaXPrioritaCollectionTemp;
		}

		//Find: popola la collection
		public SchedaXPrioritaCollection Find(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, BoolNT FlagtemplateEqualThis, 
StringNT CodlivelloEqualThis, BoolNT FlagmanualeEqualThis)
		{
			SchedaXPrioritaCollection SchedaXPrioritaCollectionTemp = SchedaXPrioritaDAL.Find(_dbProviderObj, IdschedavalutazioneEqualThis, IdprioritaEqualThis, FlagtemplateEqualThis, 
CodlivelloEqualThis, FlagmanualeEqualThis);
			SchedaXPrioritaCollectionTemp.Provider = this;
			return SchedaXPrioritaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCHEDA_X_PRIORITA>
  <ViewName>vSCHEDA_X_PRIORITA</ViewName>
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
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <COD_LIVELLO>Equal</COD_LIVELLO>
      <FLAG_MANUALE>Equal</FLAG_MANUALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroLivello>
      <COD_LIVELLO>Equal</COD_LIVELLO>
    </FiltroLivello>
    <FiltroManuale>
      <FLAG_MANUALE>Equal</FLAG_MANUALE>
    </FiltroManuale>
    <FiltroSelezionabile>
      <SELEZIONABILE>Equal</SELEZIONABILE>
    </FiltroSelezionabile>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</SCHEDA_X_PRIORITA>
*/
