using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZquerySql
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZquerySqlProvider
	{
		int Save(ZquerySql ZquerySqlObj);
		int SaveCollection(ZquerySqlCollection collectionObj);
		int Delete(ZquerySql ZquerySqlObj);
		int DeleteCollection(ZquerySqlCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZquerySql
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZquerySql: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Testo;
		[NonSerialized] private IZquerySqlProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZquerySqlProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZquerySql()
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
		/// Corrisponde al campo:NOME
		/// Tipo sul db:NVARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
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
	/// Summary description for ZquerySqlCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZquerySqlCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZquerySqlCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZquerySql) info.GetValue(i.ToString(),typeof(ZquerySql)));
			}
		}

		//Costruttore
		public ZquerySqlCollection()
		{
			this.ItemType = typeof(ZquerySql);
		}

		//Costruttore con provider
		public ZquerySqlCollection(IZquerySqlProvider providerObj)
		{
			this.ItemType = typeof(ZquerySql);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZquerySql this[int index]
		{
			get { return (ZquerySql)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZquerySqlCollection GetChanges()
		{
			return (ZquerySqlCollection) base.GetChanges();
		}

		[NonSerialized] private IZquerySqlProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZquerySqlProvider Provider
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
		public int Add(ZquerySql ZquerySqlObj)
		{
			if (ZquerySqlObj.Provider == null) ZquerySqlObj.Provider = this.Provider;
			return base.Add(ZquerySqlObj);
		}

		//AddCollection
		public void AddCollection(ZquerySqlCollection ZquerySqlCollectionObj)
		{
			foreach (ZquerySql ZquerySqlObj in ZquerySqlCollectionObj)
				this.Add(ZquerySqlObj);
		}

		//Insert
		public void Insert(int index, ZquerySql ZquerySqlObj)
		{
			if (ZquerySqlObj.Provider == null) ZquerySqlObj.Provider = this.Provider;
			base.Insert(index, ZquerySqlObj);
		}

		//CollectionGetById
		public ZquerySql CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZquerySqlCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT NomeEqualThis, NullTypes.StringNT TestoEqualThis)
		{
			ZquerySqlCollection ZquerySqlCollectionTemp = new ZquerySqlCollection();
			foreach (ZquerySql ZquerySqlItem in this)
			{
				if (((IdEqualThis == null) || ((ZquerySqlItem.Id != null) && (ZquerySqlItem.Id.Value == IdEqualThis.Value))) && ((NomeEqualThis == null) || ((ZquerySqlItem.Nome != null) && (ZquerySqlItem.Nome.Value == NomeEqualThis.Value))) && ((TestoEqualThis == null) || ((ZquerySqlItem.Testo != null) && (ZquerySqlItem.Testo.Value == TestoEqualThis.Value))))
				{
					ZquerySqlCollectionTemp.Add(ZquerySqlItem);
				}
			}
			return ZquerySqlCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZquerySqlDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZquerySqlDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZquerySql ZquerySqlObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZquerySqlObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", ZquerySqlObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", ZquerySqlObj.Testo);
		}
		//Insert
		private static int Insert(DbProvider db, ZquerySql ZquerySqlObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZquerySqlInsert", new string[] {"Nome", "Testo"}, new string[] {"string", "string"},"");
				CompileIUCmd(false, insertCmd,ZquerySqlObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZquerySqlObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZquerySqlObj.IsDirty = false;
				ZquerySqlObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZquerySql ZquerySqlObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZquerySqlUpdate", new string[] {"Id", "Nome", "Testo"}, new string[] {"int", "string", "string"},"");
				CompileIUCmd(true, updateCmd,ZquerySqlObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZquerySqlObj.IsDirty = false;
				ZquerySqlObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZquerySql ZquerySqlObj)
		{
			switch (ZquerySqlObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZquerySqlObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZquerySqlObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZquerySqlObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZquerySqlCollection ZquerySqlCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZquerySqlUpdate", new string[] {"Id", "Nome", "Testo"}, new string[] {"int", "string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZZquerySqlInsert", new string[] {"Nome", "Testo"}, new string[] {"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZquerySqlDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZquerySqlCollectionObj.Count; i++)
				{
					switch (ZquerySqlCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZquerySqlCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZquerySqlCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZquerySqlCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZquerySqlCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZquerySqlCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZquerySqlCollectionObj.Count; i++)
				{
					if ((ZquerySqlCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZquerySqlCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZquerySqlCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZquerySqlCollectionObj[i].IsDirty = false;
						ZquerySqlCollectionObj[i].IsPersistent = true;
					}
					if ((ZquerySqlCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZquerySqlCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZquerySqlCollectionObj[i].IsDirty = false;
						ZquerySqlCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZquerySql ZquerySqlObj)
		{
			int returnValue = 0;
			if (ZquerySqlObj.IsPersistent) 
			{
				returnValue = Delete(db, ZquerySqlObj.Id);
			}
			ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZquerySqlObj.IsDirty = false;
			ZquerySqlObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZquerySqlDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZquerySqlCollection ZquerySqlCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZquerySqlDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZquerySqlCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZquerySqlCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZquerySqlCollectionObj.Count; i++)
				{
					if ((ZquerySqlCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZquerySqlCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZquerySqlCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZquerySqlCollectionObj[i].IsDirty = false;
						ZquerySqlCollectionObj[i].IsPersistent = false;
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
		public static ZquerySql GetById(DbProvider db, int IdValue)
		{
			ZquerySql ZquerySqlObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZquerySqlGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZquerySqlObj = GetFromDatareader(db);
				ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZquerySqlObj.IsDirty = false;
				ZquerySqlObj.IsPersistent = true;
			}
			db.Close();
			return ZquerySqlObj;
		}

		//getFromDatareader
		public static ZquerySql GetFromDatareader(DbProvider db)
		{
			ZquerySql ZquerySqlObj = new ZquerySql();
			ZquerySqlObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZquerySqlObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			ZquerySqlObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZquerySqlObj.IsDirty = false;
			ZquerySqlObj.IsPersistent = true;
			return ZquerySqlObj;
		}

		//Find Select

		public static ZquerySqlCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, SiarLibrary.NullTypes.StringNT TestoEqualThis)

		{

			ZquerySqlCollection ZquerySqlCollectionObj = new ZquerySqlCollection();

			IDbCommand findCmd = db.InitCmd("Zzquerysqlfindselect", new string[] {"Idequalthis", "Nomeequalthis", "Testoequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			ZquerySql ZquerySqlObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZquerySqlObj = GetFromDatareader(db);
				ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZquerySqlObj.IsDirty = false;
				ZquerySqlObj.IsPersistent = true;
				ZquerySqlCollectionObj.Add(ZquerySqlObj);
			}
			db.Close();
			return ZquerySqlCollectionObj;
		}

		//Find Find

		public static ZquerySqlCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT NomeLikeThis)

		{

			ZquerySqlCollection ZquerySqlCollectionObj = new ZquerySqlCollection();

			IDbCommand findCmd = db.InitCmd("Zzquerysqlfindfind", new string[] {"Nomelikethis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomelikethis", NomeLikeThis);
			ZquerySql ZquerySqlObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZquerySqlObj = GetFromDatareader(db);
				ZquerySqlObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZquerySqlObj.IsDirty = false;
				ZquerySqlObj.IsPersistent = true;
				ZquerySqlCollectionObj.Add(ZquerySqlObj);
			}
			db.Close();
			return ZquerySqlCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZquerySqlCollectionProvider:IZquerySqlProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZquerySqlCollectionProvider : IZquerySqlProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZquerySql
		protected ZquerySqlCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZquerySqlCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZquerySqlCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZquerySqlCollectionProvider(StringNT NomeLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(NomeLikeThis);
		}

		//Costruttore3: ha in input zquerysqlCollectionObj - non popola la collection
		public ZquerySqlCollectionProvider(ZquerySqlCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZquerySqlCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZquerySqlCollection(this);
		}

		//Get e Set
		public ZquerySqlCollection CollectionObj
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
		public int SaveCollection(ZquerySqlCollection collectionObj)
		{
			return ZquerySqlDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZquerySql zquerysqlObj)
		{
			return ZquerySqlDAL.Save(_dbProviderObj, zquerysqlObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZquerySqlCollection collectionObj)
		{
			return ZquerySqlDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZquerySql zquerysqlObj)
		{
			return ZquerySqlDAL.Delete(_dbProviderObj, zquerysqlObj);
		}

		//getById
		public ZquerySql GetById(IntNT IdValue)
		{
			ZquerySql ZquerySqlTemp = ZquerySqlDAL.GetById(_dbProviderObj, IdValue);
			if (ZquerySqlTemp!=null) ZquerySqlTemp.Provider = this;
			return ZquerySqlTemp;
		}

		//Select: popola la collection
		public ZquerySqlCollection Select(IntNT IdEqualThis, StringNT NomeEqualThis, StringNT TestoEqualThis)
		{
			ZquerySqlCollection ZquerySqlCollectionTemp = ZquerySqlDAL.Select(_dbProviderObj, IdEqualThis, NomeEqualThis, TestoEqualThis);
			ZquerySqlCollectionTemp.Provider = this;
			return ZquerySqlCollectionTemp;
		}

		//Find: popola la collection
		public ZquerySqlCollection Find(StringNT NomeLikeThis)
		{
			ZquerySqlCollection ZquerySqlCollectionTemp = ZquerySqlDAL.Find(_dbProviderObj, NomeLikeThis);
			ZquerySqlCollectionTemp.Provider = this;
			return ZquerySqlCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zQUERY_SQL>
  <ViewName>
  </ViewName>
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
      <NOME>Like</NOME>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zQUERY_SQL>
*/
