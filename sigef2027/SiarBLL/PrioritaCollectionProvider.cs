using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Priorita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaProvider
	{
		int Save(Priorita PrioritaObj);
		int SaveCollection(PrioritaCollection collectionObj);
		int Delete(Priorita PrioritaObj);
		int DeleteCollection(PrioritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Priorita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Priorita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodLivello;
		private NullTypes.BoolNT _PluriValore;
		private NullTypes.StringNT _Eval;
		private NullTypes.BoolNT _FlagManuale;
		private NullTypes.BoolNT _InputNumerico;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.BoolNT _PluriValoreSql;
		private NullTypes.StringNT _QueryPlurivalore;
		[NonSerialized] private IPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Priorita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Default:((0))
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
		/// Default:((0))
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
		/// Default:((0))
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
		/// Default:((0))
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
	/// Summary description for PrioritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Priorita) info.GetValue(i.ToString(),typeof(Priorita)));
			}
		}

		//Costruttore
		public PrioritaCollection()
		{
			this.ItemType = typeof(Priorita);
		}

		//Costruttore con provider
		public PrioritaCollection(IPrioritaProvider providerObj)
		{
			this.ItemType = typeof(Priorita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Priorita this[int index]
		{
			get { return (Priorita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaCollection GetChanges()
		{
			return (PrioritaCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaProvider Provider
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
		public int Add(Priorita PrioritaObj)
		{
			if (PrioritaObj.Provider == null) PrioritaObj.Provider = this.Provider;
			return base.Add(PrioritaObj);
		}

		//AddCollection
		public void AddCollection(PrioritaCollection PrioritaCollectionObj)
		{
			foreach (Priorita PrioritaObj in PrioritaCollectionObj)
				this.Add(PrioritaObj);
		}

		//Insert
		public void Insert(int index, Priorita PrioritaObj)
		{
			if (PrioritaObj.Provider == null) PrioritaObj.Provider = this.Provider;
			base.Insert(index, PrioritaObj);
		}

		//CollectionGetById
		public Priorita CollectionGetById(NullTypes.IntNT IdPrioritaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPriorita == IdPrioritaValue))
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
		public PrioritaCollection SubSelect(NullTypes.IntNT IdPrioritaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodLivelloEqualThis, 
NullTypes.BoolNT PluriValoreEqualThis, NullTypes.StringNT EvalEqualThis, NullTypes.BoolNT FlagManualeEqualThis, 
NullTypes.BoolNT InputNumericoEqualThis, NullTypes.StringNT MisuraEqualThis, NullTypes.BoolNT DatetimeEqualThis, 
NullTypes.BoolNT TestoSempliceEqualThis, NullTypes.BoolNT TestoAreaEqualThis, NullTypes.BoolNT PluriValoreSqlEqualThis, 
NullTypes.StringNT QueryPlurivaloreEqualThis)
		{
			PrioritaCollection PrioritaCollectionTemp = new PrioritaCollection();
			foreach (Priorita PrioritaItem in this)
			{
				if (((IdPrioritaEqualThis == null) || ((PrioritaItem.IdPriorita != null) && (PrioritaItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((PrioritaItem.Descrizione != null) && (PrioritaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodLivelloEqualThis == null) || ((PrioritaItem.CodLivello != null) && (PrioritaItem.CodLivello.Value == CodLivelloEqualThis.Value))) && 
((PluriValoreEqualThis == null) || ((PrioritaItem.PluriValore != null) && (PrioritaItem.PluriValore.Value == PluriValoreEqualThis.Value))) && ((EvalEqualThis == null) || ((PrioritaItem.Eval != null) && (PrioritaItem.Eval.Value == EvalEqualThis.Value))) && ((FlagManualeEqualThis == null) || ((PrioritaItem.FlagManuale != null) && (PrioritaItem.FlagManuale.Value == FlagManualeEqualThis.Value))) && 
((InputNumericoEqualThis == null) || ((PrioritaItem.InputNumerico != null) && (PrioritaItem.InputNumerico.Value == InputNumericoEqualThis.Value))) && ((MisuraEqualThis == null) || ((PrioritaItem.Misura != null) && (PrioritaItem.Misura.Value == MisuraEqualThis.Value))) && ((DatetimeEqualThis == null) || ((PrioritaItem.Datetime != null) && (PrioritaItem.Datetime.Value == DatetimeEqualThis.Value))) && 
((TestoSempliceEqualThis == null) || ((PrioritaItem.TestoSemplice != null) && (PrioritaItem.TestoSemplice.Value == TestoSempliceEqualThis.Value))) && ((TestoAreaEqualThis == null) || ((PrioritaItem.TestoArea != null) && (PrioritaItem.TestoArea.Value == TestoAreaEqualThis.Value))) && ((PluriValoreSqlEqualThis == null) || ((PrioritaItem.PluriValoreSql != null) && (PrioritaItem.PluriValoreSql.Value == PluriValoreSqlEqualThis.Value))) && 
((QueryPlurivaloreEqualThis == null) || ((PrioritaItem.QueryPlurivalore != null) && (PrioritaItem.QueryPlurivalore.Value == QueryPlurivaloreEqualThis.Value))))
				{
					PrioritaCollectionTemp.Add(PrioritaItem);
				}
			}
			return PrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PrioritaCollection FiltroManuale(NullTypes.BoolNT FlagManualeEqualThis)
		{
			PrioritaCollection PrioritaCollectionTemp = new PrioritaCollection();
			foreach (Priorita PrioritaItem in this)
			{
				if (((FlagManualeEqualThis == null) || ((PrioritaItem.FlagManuale != null) && (PrioritaItem.FlagManuale.Value == FlagManualeEqualThis.Value))))
				{
					PrioritaCollectionTemp.Add(PrioritaItem);
				}
			}
			return PrioritaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PrioritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Priorita PrioritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaObj.IdPriorita);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", PrioritaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodLivello", PrioritaObj.CodLivello);
			DbProvider.SetCmdParam(cmd,firstChar + "PluriValore", PrioritaObj.PluriValore);
			DbProvider.SetCmdParam(cmd,firstChar + "Eval", PrioritaObj.Eval);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagManuale", PrioritaObj.FlagManuale);
			DbProvider.SetCmdParam(cmd,firstChar + "InputNumerico", PrioritaObj.InputNumerico);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", PrioritaObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "Datetime", PrioritaObj.Datetime);
			DbProvider.SetCmdParam(cmd,firstChar + "TestoSemplice", PrioritaObj.TestoSemplice);
			DbProvider.SetCmdParam(cmd,firstChar + "TestoArea", PrioritaObj.TestoArea);
			DbProvider.SetCmdParam(cmd,firstChar + "PluriValoreSql", PrioritaObj.PluriValoreSql);
			DbProvider.SetCmdParam(cmd,firstChar + "QueryPlurivalore", PrioritaObj.QueryPlurivalore);
		}
		//Insert
		private static int Insert(DbProvider db, Priorita PrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaInsert", new string[] {"Descrizione", "CodLivello", 
"PluriValore", "Eval", "FlagManuale", 
"InputNumerico", "Misura", "Datetime", 
"TestoSemplice", "TestoArea", "PluriValoreSql", 
"QueryPlurivalore"}, new string[] {"string", "string", 
"bool", "string", "bool", 
"bool", "string", "bool", 
"bool", "bool", "bool", 
"string"},"");
				CompileIUCmd(false, insertCmd,PrioritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PrioritaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
				PrioritaObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
				PrioritaObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
				PrioritaObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
				PrioritaObj.PluriValoreSql = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE_SQL"]);
				}
				PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaObj.IsDirty = false;
				PrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Priorita PrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaUpdate", new string[] {"IdPriorita", "Descrizione", "CodLivello", 
"PluriValore", "Eval", "FlagManuale", 
"InputNumerico", "Misura", "Datetime", 
"TestoSemplice", "TestoArea", "PluriValoreSql", 
"QueryPlurivalore"}, new string[] {"int", "string", "string", 
"bool", "string", "bool", 
"bool", "string", "bool", 
"bool", "bool", "bool", 
"string"},"");
				CompileIUCmd(true, updateCmd,PrioritaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaObj.IsDirty = false;
				PrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Priorita PrioritaObj)
		{
			switch (PrioritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaCollection PrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaUpdate", new string[] {"IdPriorita", "Descrizione", "CodLivello", 
"PluriValore", "Eval", "FlagManuale", 
"InputNumerico", "Misura", "Datetime", 
"TestoSemplice", "TestoArea", "PluriValoreSql", 
"QueryPlurivalore"}, new string[] {"int", "string", "string", 
"bool", "string", "bool", 
"bool", "string", "bool", 
"bool", "bool", "bool", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaInsert", new string[] {"Descrizione", "CodLivello", 
"PluriValore", "Eval", "FlagManuale", 
"InputNumerico", "Misura", "Datetime", 
"TestoSemplice", "TestoArea", "PluriValoreSql", 
"QueryPlurivalore"}, new string[] {"string", "string", 
"bool", "string", "bool", 
"bool", "string", "bool", 
"bool", "bool", "bool", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaDelete", new string[] {"IdPriorita"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaCollectionObj.Count; i++)
				{
					switch (PrioritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PrioritaCollectionObj[i].IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
									PrioritaCollectionObj[i].Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
									PrioritaCollectionObj[i].TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
									PrioritaCollectionObj[i].TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
									PrioritaCollectionObj[i].PluriValoreSql = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE_SQL"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)PrioritaCollectionObj[i].IdPriorita);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaCollectionObj.Count; i++)
				{
					if ((PrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaCollectionObj[i].IsDirty = false;
						PrioritaCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaCollectionObj[i].IsDirty = false;
						PrioritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Priorita PrioritaObj)
		{
			int returnValue = 0;
			if (PrioritaObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaObj.IdPriorita);
			}
			PrioritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaObj.IsDirty = false;
			PrioritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrioritaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaDelete", new string[] {"IdPriorita"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaCollection PrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaDelete", new string[] {"IdPriorita"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", PrioritaCollectionObj[i].IdPriorita);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaCollectionObj.Count; i++)
				{
					if ((PrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaCollectionObj[i].IsDirty = false;
						PrioritaCollectionObj[i].IsPersistent = false;
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
		public static Priorita GetById(DbProvider db, int IdPrioritaValue)
		{
			Priorita PrioritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaGetById", new string[] {"IdPriorita"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaObj = GetFromDatareader(db);
				PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaObj.IsDirty = false;
				PrioritaObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaObj;
		}

		//getFromDatareader
		public static Priorita GetFromDatareader(DbProvider db)
		{
			Priorita PrioritaObj = new Priorita();
			PrioritaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PrioritaObj.CodLivello = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_LIVELLO"]);
			PrioritaObj.PluriValore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE"]);
			PrioritaObj.Eval = new SiarLibrary.NullTypes.StringNT(db.DataReader["EVAL"]);
			PrioritaObj.FlagManuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MANUALE"]);
			PrioritaObj.InputNumerico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INPUT_NUMERICO"]);
			PrioritaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			PrioritaObj.Datetime = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DATETIME"]);
			PrioritaObj.TestoSemplice = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_SEMPLICE"]);
			PrioritaObj.TestoArea = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TESTO_AREA"]);
			PrioritaObj.PluriValoreSql = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PLURI_VALORE_SQL"]);
			PrioritaObj.QueryPlurivalore = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_PLURIVALORE"]);
			PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaObj.IsDirty = false;
			PrioritaObj.IsPersistent = true;
			return PrioritaObj;
		}

		//Find Select

		public static PrioritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodLivelloEqualThis, 
SiarLibrary.NullTypes.BoolNT PluriValoreEqualThis, SiarLibrary.NullTypes.StringNT EvalEqualThis, SiarLibrary.NullTypes.BoolNT FlagManualeEqualThis, 
SiarLibrary.NullTypes.BoolNT InputNumericoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis, SiarLibrary.NullTypes.BoolNT DatetimeEqualThis, 
SiarLibrary.NullTypes.BoolNT TestoSempliceEqualThis, SiarLibrary.NullTypes.BoolNT TestoAreaEqualThis, SiarLibrary.NullTypes.BoolNT PluriValoreSqlEqualThis, 
SiarLibrary.NullTypes.StringNT QueryPlurivaloreEqualThis)

		{

			PrioritaCollection PrioritaCollectionObj = new PrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritafindselect", new string[] {"IdPrioritaequalthis", "Descrizioneequalthis", "CodLivelloequalthis", 
"PluriValoreequalthis", "Evalequalthis", "FlagManualeequalthis", 
"InputNumericoequalthis", "Misuraequalthis", "Datetimeequalthis", 
"TestoSempliceequalthis", "TestoAreaequalthis", "PluriValoreSqlequalthis", 
"QueryPlurivaloreequalthis"}, new string[] {"int", "string", "string", 
"bool", "string", "bool", 
"bool", "string", "bool", 
"bool", "bool", "bool", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodLivelloequalthis", CodLivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PluriValoreequalthis", PluriValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Evalequalthis", EvalEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagManualeequalthis", FlagManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InputNumericoequalthis", InputNumericoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datetimeequalthis", DatetimeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoSempliceequalthis", TestoSempliceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoAreaequalthis", TestoAreaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PluriValoreSqlequalthis", PluriValoreSqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QueryPlurivaloreequalthis", QueryPlurivaloreEqualThis);
			Priorita PrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaObj = GetFromDatareader(db);
				PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaObj.IsDirty = false;
				PrioritaObj.IsPersistent = true;
				PrioritaCollectionObj.Add(PrioritaObj);
			}
			db.Close();
			return PrioritaCollectionObj;
		}

		//Find Find

		public static PrioritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.StringNT CodLivelloEqualThis, SiarLibrary.NullTypes.BoolNT PluriValoreEqualThis, 
SiarLibrary.NullTypes.BoolNT DatetimeEqualThis, SiarLibrary.NullTypes.BoolNT TestoSempliceEqualThis, SiarLibrary.NullTypes.BoolNT TestoAreaEqualThis, 
SiarLibrary.NullTypes.BoolNT PluriValoreSqlEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.StringNT MisuraLikeThis)

		{

			PrioritaCollection PrioritaCollectionObj = new PrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritafindfind", new string[] {"IdPrioritaequalthis", "CodLivelloequalthis", "PluriValoreequalthis", 
"Datetimeequalthis", "TestoSempliceequalthis", "TestoAreaequalthis", 
"PluriValoreSqlequalthis", "Descrizionelikethis", "Misuralikethis"}, new string[] {"int", "string", "bool", 
"bool", "bool", "bool", 
"bool", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodLivelloequalthis", CodLivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PluriValoreequalthis", PluriValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datetimeequalthis", DatetimeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoSempliceequalthis", TestoSempliceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TestoAreaequalthis", TestoAreaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PluriValoreSqlequalthis", PluriValoreSqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuralikethis", MisuraLikeThis);
			Priorita PrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaObj = GetFromDatareader(db);
				PrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaObj.IsDirty = false;
				PrioritaObj.IsPersistent = true;
				PrioritaCollectionObj.Add(PrioritaObj);
			}
			db.Close();
			return PrioritaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaCollectionProvider:IPrioritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaCollectionProvider : IPrioritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Priorita
		protected PrioritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaCollectionProvider(IntNT IdprioritaEqualThis, StringNT CodlivelloEqualThis, BoolNT PlurivaloreEqualThis, 
BoolNT DatetimeEqualThis, BoolNT TestosempliceEqualThis, BoolNT TestoareaEqualThis, 
BoolNT PlurivaloresqlEqualThis, StringNT DescrizioneLikeThis, StringNT MisuraLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprioritaEqualThis, CodlivelloEqualThis, PlurivaloreEqualThis, 
DatetimeEqualThis, TestosempliceEqualThis, TestoareaEqualThis, 
PlurivaloresqlEqualThis, DescrizioneLikeThis, MisuraLikeThis);
		}

		//Costruttore3: ha in input prioritaCollectionObj - non popola la collection
		public PrioritaCollectionProvider(PrioritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaCollection(this);
		}

		//Get e Set
		public PrioritaCollection CollectionObj
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
		public int SaveCollection(PrioritaCollection collectionObj)
		{
			return PrioritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Priorita prioritaObj)
		{
			return PrioritaDAL.Save(_dbProviderObj, prioritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaCollection collectionObj)
		{
			return PrioritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Priorita prioritaObj)
		{
			return PrioritaDAL.Delete(_dbProviderObj, prioritaObj);
		}

		//getById
		public Priorita GetById(IntNT IdPrioritaValue)
		{
			Priorita PrioritaTemp = PrioritaDAL.GetById(_dbProviderObj, IdPrioritaValue);
			if (PrioritaTemp!=null) PrioritaTemp.Provider = this;
			return PrioritaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaCollection Select(IntNT IdprioritaEqualThis, StringNT DescrizioneEqualThis, StringNT CodlivelloEqualThis, 
BoolNT PlurivaloreEqualThis, StringNT EvalEqualThis, BoolNT FlagmanualeEqualThis, 
BoolNT InputnumericoEqualThis, StringNT MisuraEqualThis, BoolNT DatetimeEqualThis, 
BoolNT TestosempliceEqualThis, BoolNT TestoareaEqualThis, BoolNT PlurivaloresqlEqualThis, 
StringNT QueryplurivaloreEqualThis)
		{
			PrioritaCollection PrioritaCollectionTemp = PrioritaDAL.Select(_dbProviderObj, IdprioritaEqualThis, DescrizioneEqualThis, CodlivelloEqualThis, 
PlurivaloreEqualThis, EvalEqualThis, FlagmanualeEqualThis, 
InputnumericoEqualThis, MisuraEqualThis, DatetimeEqualThis, 
TestosempliceEqualThis, TestoareaEqualThis, PlurivaloresqlEqualThis, 
QueryplurivaloreEqualThis);
			PrioritaCollectionTemp.Provider = this;
			return PrioritaCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaCollection Find(IntNT IdprioritaEqualThis, StringNT CodlivelloEqualThis, BoolNT PlurivaloreEqualThis, 
BoolNT DatetimeEqualThis, BoolNT TestosempliceEqualThis, BoolNT TestoareaEqualThis, 
BoolNT PlurivaloresqlEqualThis, StringNT DescrizioneLikeThis, StringNT MisuraLikeThis)
		{
			PrioritaCollection PrioritaCollectionTemp = PrioritaDAL.Find(_dbProviderObj, IdprioritaEqualThis, CodlivelloEqualThis, PlurivaloreEqualThis, 
DatetimeEqualThis, TestosempliceEqualThis, TestoareaEqualThis, 
PlurivaloresqlEqualThis, DescrizioneLikeThis, MisuraLikeThis);
			PrioritaCollectionTemp.Provider = this;
			return PrioritaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA>
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
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <COD_LIVELLO>Equal</COD_LIVELLO>
      <PLURI_VALORE>Equal</PLURI_VALORE>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <PLURI_VALORE_SQL>Equal</PLURI_VALORE_SQL>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroManuale>
      <FLAG_MANUALE>Equal</FLAG_MANUALE>
    </FiltroManuale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PRIORITA>
*/
