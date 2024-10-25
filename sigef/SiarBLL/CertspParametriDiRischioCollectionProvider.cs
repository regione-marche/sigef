using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspParametriDiRischio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspParametriDiRischioProvider
	{
		int Save(CertspParametriDiRischio CertspParametriDiRischioObj);
		int SaveCollection(CertspParametriDiRischioCollection collectionObj);
		int Delete(CertspParametriDiRischio CertspParametriDiRischioObj);
		int DeleteCollection(CertspParametriDiRischioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspParametriDiRischio
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspParametriDiRischio: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Manuale;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.IntNT _Peso;
		[NonSerialized] private ICertspParametriDiRischioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriDiRischioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspParametriDiRischio()
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
		/// Corrisponde al campo:MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Manuale
		{
			get { return _Manuale; }
			set {
				if (Manuale != value)
				{
					_Manuale = value;
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
		/// Corrisponde al campo:PESO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Peso
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
	/// Summary description for CertspParametriDiRischioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriDiRischioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspParametriDiRischioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspParametriDiRischio) info.GetValue(i.ToString(),typeof(CertspParametriDiRischio)));
			}
		}

		//Costruttore
		public CertspParametriDiRischioCollection()
		{
			this.ItemType = typeof(CertspParametriDiRischio);
		}

		//Costruttore con provider
		public CertspParametriDiRischioCollection(ICertspParametriDiRischioProvider providerObj)
		{
			this.ItemType = typeof(CertspParametriDiRischio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspParametriDiRischio this[int index]
		{
			get { return (CertspParametriDiRischio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspParametriDiRischioCollection GetChanges()
		{
			return (CertspParametriDiRischioCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspParametriDiRischioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriDiRischioProvider Provider
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
		public int Add(CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			if (CertspParametriDiRischioObj.Provider == null) CertspParametriDiRischioObj.Provider = this.Provider;
			return base.Add(CertspParametriDiRischioObj);
		}

		//AddCollection
		public void AddCollection(CertspParametriDiRischioCollection CertspParametriDiRischioCollectionObj)
		{
			foreach (CertspParametriDiRischio CertspParametriDiRischioObj in CertspParametriDiRischioCollectionObj)
				this.Add(CertspParametriDiRischioObj);
		}

		//Insert
		public void Insert(int index, CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			if (CertspParametriDiRischioObj.Provider == null) CertspParametriDiRischioObj.Provider = this.Provider;
			base.Insert(index, CertspParametriDiRischioObj);
		}

		//CollectionGetById
		public CertspParametriDiRischio CollectionGetById(NullTypes.IntNT IdValue)
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
		public CertspParametriDiRischioCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT ManualeEqualThis, 
NullTypes.StringNT QuerySqlEqualThis, NullTypes.IntNT PesoEqualThis)
		{
			CertspParametriDiRischioCollection CertspParametriDiRischioCollectionTemp = new CertspParametriDiRischioCollection();
			foreach (CertspParametriDiRischio CertspParametriDiRischioItem in this)
			{
				if (((IdEqualThis == null) || ((CertspParametriDiRischioItem.Id != null) && (CertspParametriDiRischioItem.Id.Value == IdEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((CertspParametriDiRischioItem.Descrizione != null) && (CertspParametriDiRischioItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ManualeEqualThis == null) || ((CertspParametriDiRischioItem.Manuale != null) && (CertspParametriDiRischioItem.Manuale.Value == ManualeEqualThis.Value))) && 
((QuerySqlEqualThis == null) || ((CertspParametriDiRischioItem.QuerySql != null) && (CertspParametriDiRischioItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((PesoEqualThis == null) || ((CertspParametriDiRischioItem.Peso != null) && (CertspParametriDiRischioItem.Peso.Value == PesoEqualThis.Value))))
				{
					CertspParametriDiRischioCollectionTemp.Add(CertspParametriDiRischioItem);
				}
			}
			return CertspParametriDiRischioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspParametriDiRischioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspParametriDiRischioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspParametriDiRischio CertspParametriDiRischioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspParametriDiRischioObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", CertspParametriDiRischioObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Manuale", CertspParametriDiRischioObj.Manuale);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", CertspParametriDiRischioObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", CertspParametriDiRischioObj.Peso);
		}
		//Insert
		private static int Insert(DbProvider db, CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriDiRischioInsert", new string[] {"Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"string", "bool", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,CertspParametriDiRischioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspParametriDiRischioObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriDiRischioObj.IsDirty = false;
				CertspParametriDiRischioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriDiRischioUpdate", new string[] {"Id", "Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"int", "string", "bool", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,CertspParametriDiRischioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriDiRischioObj.IsDirty = false;
				CertspParametriDiRischioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			switch (CertspParametriDiRischioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspParametriDiRischioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspParametriDiRischioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspParametriDiRischioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspParametriDiRischioCollection CertspParametriDiRischioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriDiRischioUpdate", new string[] {"Id", "Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"int", "string", "bool", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriDiRischioInsert", new string[] {"Descrizione", "Manuale", 
"QuerySql", "Peso"}, new string[] {"string", "bool", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriDiRischioDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriDiRischioCollectionObj.Count; i++)
				{
					switch (CertspParametriDiRischioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspParametriDiRischioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspParametriDiRischioCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspParametriDiRischioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspParametriDiRischioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspParametriDiRischioCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspParametriDiRischioCollectionObj.Count; i++)
				{
					if ((CertspParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspParametriDiRischioCollectionObj[i].IsDirty = false;
						CertspParametriDiRischioCollectionObj[i].IsPersistent = true;
					}
					if ((CertspParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriDiRischioCollectionObj[i].IsDirty = false;
						CertspParametriDiRischioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspParametriDiRischio CertspParametriDiRischioObj)
		{
			int returnValue = 0;
			if (CertspParametriDiRischioObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspParametriDiRischioObj.Id);
			}
			CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspParametriDiRischioObj.IsDirty = false;
			CertspParametriDiRischioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriDiRischioDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspParametriDiRischioCollection CertspParametriDiRischioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriDiRischioDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriDiRischioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspParametriDiRischioCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspParametriDiRischioCollectionObj.Count; i++)
				{
					if ((CertspParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriDiRischioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriDiRischioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriDiRischioCollectionObj[i].IsDirty = false;
						CertspParametriDiRischioCollectionObj[i].IsPersistent = false;
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
		public static CertspParametriDiRischio GetById(DbProvider db, int IdValue)
		{
			CertspParametriDiRischio CertspParametriDiRischioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspParametriDiRischioGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspParametriDiRischioObj = GetFromDatareader(db);
				CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriDiRischioObj.IsDirty = false;
				CertspParametriDiRischioObj.IsPersistent = true;
			}
			db.Close();
			return CertspParametriDiRischioObj;
		}

		//getFromDatareader
		public static CertspParametriDiRischio GetFromDatareader(DbProvider db)
		{
			CertspParametriDiRischio CertspParametriDiRischioObj = new CertspParametriDiRischio();
			CertspParametriDiRischioObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspParametriDiRischioObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CertspParametriDiRischioObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			CertspParametriDiRischioObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			CertspParametriDiRischioObj.Peso = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO"]);
			CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspParametriDiRischioObj.IsDirty = false;
			CertspParametriDiRischioObj.IsPersistent = true;
			return CertspParametriDiRischioObj;
		}

		//Find Select

		public static CertspParametriDiRischioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.IntNT PesoEqualThis)

		{

			CertspParametriDiRischioCollection CertspParametriDiRischioCollectionObj = new CertspParametriDiRischioCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametridirischiofindselect", new string[] {"Idequalthis", "Descrizioneequalthis", "Manualeequalthis", 
"QuerySqlequalthis", "Pesoequalthis"}, new string[] {"int", "string", "bool", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			CertspParametriDiRischio CertspParametriDiRischioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriDiRischioObj = GetFromDatareader(db);
				CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriDiRischioObj.IsDirty = false;
				CertspParametriDiRischioObj.IsPersistent = true;
				CertspParametriDiRischioCollectionObj.Add(CertspParametriDiRischioObj);
			}
			db.Close();
			return CertspParametriDiRischioCollectionObj;
		}

		//Find Find

		public static CertspParametriDiRischioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			CertspParametriDiRischioCollection CertspParametriDiRischioCollectionObj = new CertspParametriDiRischioCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametridirischiofindfind", new string[] {"Idequalthis", "Manualeequalthis", "Descrizionelikethis"}, new string[] {"int", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			CertspParametriDiRischio CertspParametriDiRischioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriDiRischioObj = GetFromDatareader(db);
				CertspParametriDiRischioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriDiRischioObj.IsDirty = false;
				CertspParametriDiRischioObj.IsPersistent = true;
				CertspParametriDiRischioCollectionObj.Add(CertspParametriDiRischioObj);
			}
			db.Close();
			return CertspParametriDiRischioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspParametriDiRischioCollectionProvider:ICertspParametriDiRischioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriDiRischioCollectionProvider : ICertspParametriDiRischioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspParametriDiRischio
		protected CertspParametriDiRischioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspParametriDiRischioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspParametriDiRischioCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertspParametriDiRischioCollectionProvider(IntNT IdEqualThis, BoolNT ManualeEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdEqualThis, ManualeEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input certspparametridirischioCollectionObj - non popola la collection
		public CertspParametriDiRischioCollectionProvider(CertspParametriDiRischioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspParametriDiRischioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspParametriDiRischioCollection(this);
		}

		//Get e Set
		public CertspParametriDiRischioCollection CollectionObj
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
		public int SaveCollection(CertspParametriDiRischioCollection collectionObj)
		{
			return CertspParametriDiRischioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspParametriDiRischio certspparametridirischioObj)
		{
			return CertspParametriDiRischioDAL.Save(_dbProviderObj, certspparametridirischioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspParametriDiRischioCollection collectionObj)
		{
			return CertspParametriDiRischioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspParametriDiRischio certspparametridirischioObj)
		{
			return CertspParametriDiRischioDAL.Delete(_dbProviderObj, certspparametridirischioObj);
		}

		//getById
		public CertspParametriDiRischio GetById(IntNT IdValue)
		{
			CertspParametriDiRischio CertspParametriDiRischioTemp = CertspParametriDiRischioDAL.GetById(_dbProviderObj, IdValue);
			if (CertspParametriDiRischioTemp!=null) CertspParametriDiRischioTemp.Provider = this;
			return CertspParametriDiRischioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspParametriDiRischioCollection Select(IntNT IdEqualThis, StringNT DescrizioneEqualThis, BoolNT ManualeEqualThis, 
StringNT QuerysqlEqualThis, IntNT PesoEqualThis)
		{
			CertspParametriDiRischioCollection CertspParametriDiRischioCollectionTemp = CertspParametriDiRischioDAL.Select(_dbProviderObj, IdEqualThis, DescrizioneEqualThis, ManualeEqualThis, 
QuerysqlEqualThis, PesoEqualThis);
			CertspParametriDiRischioCollectionTemp.Provider = this;
			return CertspParametriDiRischioCollectionTemp;
		}

		//Find: popola la collection
		public CertspParametriDiRischioCollection Find(IntNT IdEqualThis, BoolNT ManualeEqualThis, StringNT DescrizioneLikeThis)
		{
			CertspParametriDiRischioCollection CertspParametriDiRischioCollectionTemp = CertspParametriDiRischioDAL.Find(_dbProviderObj, IdEqualThis, ManualeEqualThis, DescrizioneLikeThis);
			CertspParametriDiRischioCollectionTemp.Provider = this;
			return CertspParametriDiRischioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_PARAMETRI_DI_RISCHIO>
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
      <ID>Equal</ID>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_PARAMETRI_DI_RISCHIO>
*/
