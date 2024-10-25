using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VldStep
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVldStepProvider
	{
		int Save(VldStep VldStepObj);
		int SaveCollection(VldStepCollection collectionObj);
		int Delete(VldStep VldStepObj);
		int DeleteCollection(VldStepCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VldStep
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VldStep: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IVldStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVldStepProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VldStep()
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set {
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set {
				if (CodeMethod != value)
				{
					_CodeMethod = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
		{
			get { return _ValMinimo; }
			set {
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
		{
			get { return _ValMassimo; }
			set {
				if (ValMassimo != value)
				{
					_ValMassimo = value;
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
	/// Summary description for VldStepCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VldStepCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VldStepCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VldStep) info.GetValue(i.ToString(),typeof(VldStep)));
			}
		}

		//Costruttore
		public VldStepCollection()
		{
			this.ItemType = typeof(VldStep);
		}

		//Costruttore con provider
		public VldStepCollection(IVldStepProvider providerObj)
		{
			this.ItemType = typeof(VldStep);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VldStep this[int index]
		{
			get { return (VldStep)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VldStepCollection GetChanges()
		{
			return (VldStepCollection) base.GetChanges();
		}

		[NonSerialized] private IVldStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVldStepProvider Provider
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
		public int Add(VldStep VldStepObj)
		{
			if (VldStepObj.Provider == null) VldStepObj.Provider = this.Provider;
			return base.Add(VldStepObj);
		}

		//AddCollection
		public void AddCollection(VldStepCollection VldStepCollectionObj)
		{
			foreach (VldStep VldStepObj in VldStepCollectionObj)
				this.Add(VldStepObj);
		}

		//Insert
		public void Insert(int index, VldStep VldStepObj)
		{
			if (VldStepObj.Provider == null) VldStepObj.Provider = this.Provider;
			base.Insert(index, VldStepObj);
		}

		//CollectionGetById
		public VldStep CollectionGetById(NullTypes.IntNT IdValue)
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
		public VldStepCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AutomaticoEqualThis, 
NullTypes.StringNT QuerySqlEqualThis, NullTypes.StringNT QuerySqlPostEqualThis, NullTypes.StringNT CodeMethodEqualThis, 
NullTypes.StringNT UrlEqualThis, NullTypes.StringNT ValMinimoEqualThis, NullTypes.StringNT ValMassimoEqualThis, 
NullTypes.StringNT MisuraEqualThis)
		{
			VldStepCollection VldStepCollectionTemp = new VldStepCollection();
			foreach (VldStep VldStepItem in this)
			{
				if (((IdEqualThis == null) || ((VldStepItem.Id != null) && (VldStepItem.Id.Value == IdEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VldStepItem.Descrizione != null) && (VldStepItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AutomaticoEqualThis == null) || ((VldStepItem.Automatico != null) && (VldStepItem.Automatico.Value == AutomaticoEqualThis.Value))) && 
((QuerySqlEqualThis == null) || ((VldStepItem.QuerySql != null) && (VldStepItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((QuerySqlPostEqualThis == null) || ((VldStepItem.QuerySqlPost != null) && (VldStepItem.QuerySqlPost.Value == QuerySqlPostEqualThis.Value))) && ((CodeMethodEqualThis == null) || ((VldStepItem.CodeMethod != null) && (VldStepItem.CodeMethod.Value == CodeMethodEqualThis.Value))) && 
((UrlEqualThis == null) || ((VldStepItem.Url != null) && (VldStepItem.Url.Value == UrlEqualThis.Value))) && ((ValMinimoEqualThis == null) || ((VldStepItem.ValMinimo != null) && (VldStepItem.ValMinimo.Value == ValMinimoEqualThis.Value))) && ((ValMassimoEqualThis == null) || ((VldStepItem.ValMassimo != null) && (VldStepItem.ValMassimo.Value == ValMassimoEqualThis.Value))) && 
((MisuraEqualThis == null) || ((VldStepItem.Misura != null) && (VldStepItem.Misura.Value == MisuraEqualThis.Value))))
				{
					VldStepCollectionTemp.Add(VldStepItem);
				}
			}
			return VldStepCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VldStepDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VldStepDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VldStep VldStepObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", VldStepObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", VldStepObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Automatico", VldStepObj.Automatico);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", VldStepObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySqlPost", VldStepObj.QuerySqlPost);
			DbProvider.SetCmdParam(cmd,firstChar + "CodeMethod", VldStepObj.CodeMethod);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", VldStepObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMinimo", VldStepObj.ValMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMassimo", VldStepObj.ValMassimo);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", VldStepObj.Misura);
		}
		//Insert
		private static int Insert(DbProvider db, VldStep VldStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVldStepInsert", new string[] {"Descrizione", "Automatico", 
"QuerySql", "QuerySqlPost", "CodeMethod", 
"Url", "ValMinimo", "ValMassimo", 
"Misura"}, new string[] {"string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,VldStepObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VldStepObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				VldStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldStepObj.IsDirty = false;
				VldStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VldStep VldStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVldStepUpdate", new string[] {"Id", "Descrizione", "Automatico", 
"QuerySql", "QuerySqlPost", "CodeMethod", 
"Url", "ValMinimo", "ValMassimo", 
"Misura"}, new string[] {"int", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,VldStepObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VldStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldStepObj.IsDirty = false;
				VldStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VldStep VldStepObj)
		{
			switch (VldStepObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VldStepObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VldStepObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VldStepObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VldStepCollection VldStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVldStepUpdate", new string[] {"Id", "Descrizione", "Automatico", 
"QuerySql", "QuerySqlPost", "CodeMethod", 
"Url", "ValMinimo", "ValMassimo", 
"Misura"}, new string[] {"int", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZVldStepInsert", new string[] {"Descrizione", "Automatico", 
"QuerySql", "QuerySqlPost", "CodeMethod", 
"Url", "ValMinimo", "ValMassimo", 
"Misura"}, new string[] {"string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVldStepDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < VldStepCollectionObj.Count; i++)
				{
					switch (VldStepCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VldStepCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VldStepCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VldStepCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VldStepCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)VldStepCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VldStepCollectionObj.Count; i++)
				{
					if ((VldStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VldStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VldStepCollectionObj[i].IsDirty = false;
						VldStepCollectionObj[i].IsPersistent = true;
					}
					if ((VldStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VldStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VldStepCollectionObj[i].IsDirty = false;
						VldStepCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VldStep VldStepObj)
		{
			int returnValue = 0;
			if (VldStepObj.IsPersistent) 
			{
				returnValue = Delete(db, VldStepObj.Id);
			}
			VldStepObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VldStepObj.IsDirty = false;
			VldStepObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVldStepDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VldStepCollection VldStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVldStepDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < VldStepCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", VldStepCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VldStepCollectionObj.Count; i++)
				{
					if ((VldStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VldStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VldStepCollectionObj[i].IsDirty = false;
						VldStepCollectionObj[i].IsPersistent = false;
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
		public static VldStep GetById(DbProvider db, int IdValue)
		{
			VldStep VldStepObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVldStepGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VldStepObj = GetFromDatareader(db);
				VldStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldStepObj.IsDirty = false;
				VldStepObj.IsPersistent = true;
			}
			db.Close();
			return VldStepObj;
		}

		//getFromDatareader
		public static VldStep GetFromDatareader(DbProvider db)
		{
			VldStep VldStepObj = new VldStep();
			VldStepObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			VldStepObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VldStepObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			VldStepObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			VldStepObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			VldStepObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			VldStepObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			VldStepObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			VldStepObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			VldStepObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			VldStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VldStepObj.IsDirty = false;
			VldStepObj.IsPersistent = true;
			return VldStepObj;
		}

		//Find Select

		public static VldStepCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlPostEqualThis, SiarLibrary.NullTypes.StringNT CodeMethodEqualThis, 
SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, SiarLibrary.NullTypes.StringNT ValMassimoEqualThis, 
SiarLibrary.NullTypes.StringNT MisuraEqualThis)

		{

			VldStepCollection VldStepCollectionObj = new VldStepCollection();

			IDbCommand findCmd = db.InitCmd("Zvldstepfindselect", new string[] {"Idequalthis", "Descrizioneequalthis", "Automaticoequalthis", 
"QuerySqlequalthis", "QuerySqlPostequalthis", "CodeMethodequalthis", 
"Urlequalthis", "ValMinimoequalthis", "ValMassimoequalthis", 
"Misuraequalthis"}, new string[] {"int", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlPostequalthis", QuerySqlPostEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodeMethodequalthis", CodeMethodEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			VldStep VldStepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VldStepObj = GetFromDatareader(db);
				VldStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldStepObj.IsDirty = false;
				VldStepObj.IsPersistent = true;
				VldStepCollectionObj.Add(VldStepObj);
			}
			db.Close();
			return VldStepCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VldStepCollectionProvider:IVldStepProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VldStepCollectionProvider : IVldStepProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VldStep
		protected VldStepCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VldStepCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VldStepCollection(this);
		}

		//Costruttore3: ha in input vldstepCollectionObj - non popola la collection
		public VldStepCollectionProvider(VldStepCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VldStepCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VldStepCollection(this);
		}

		//Get e Set
		public VldStepCollection CollectionObj
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
		public int SaveCollection(VldStepCollection collectionObj)
		{
			return VldStepDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VldStep vldstepObj)
		{
			return VldStepDAL.Save(_dbProviderObj, vldstepObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VldStepCollection collectionObj)
		{
			return VldStepDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VldStep vldstepObj)
		{
			return VldStepDAL.Delete(_dbProviderObj, vldstepObj);
		}

		//getById
		public VldStep GetById(IntNT IdValue)
		{
			VldStep VldStepTemp = VldStepDAL.GetById(_dbProviderObj, IdValue);
			if (VldStepTemp!=null) VldStepTemp.Provider = this;
			return VldStepTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VldStepCollection Select(IntNT IdEqualThis, StringNT DescrizioneEqualThis, BoolNT AutomaticoEqualThis, 
StringNT QuerysqlEqualThis, StringNT QuerysqlpostEqualThis, StringNT CodemethodEqualThis, 
StringNT UrlEqualThis, StringNT ValminimoEqualThis, StringNT ValmassimoEqualThis, 
StringNT MisuraEqualThis)
		{
			VldStepCollection VldStepCollectionTemp = VldStepDAL.Select(_dbProviderObj, IdEqualThis, DescrizioneEqualThis, AutomaticoEqualThis, 
QuerysqlEqualThis, QuerysqlpostEqualThis, CodemethodEqualThis, 
UrlEqualThis, ValminimoEqualThis, ValmassimoEqualThis, 
MisuraEqualThis);
			VldStepCollectionTemp.Provider = this;
			return VldStepCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VLD_STEP>
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
</VLD_STEP>
*/
