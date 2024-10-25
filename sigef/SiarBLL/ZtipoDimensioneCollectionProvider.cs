using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZtipoDimensione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZtipoDimensioneProvider
	{
		int Save(ZtipoDimensione ZtipoDimensioneObj);
		int SaveCollection(ZtipoDimensioneCollection collectionObj);
		int Delete(ZtipoDimensione ZtipoDimensioneObj);
		int DeleteCollection(ZtipoDimensioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZtipoDimensione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZtipoDimensione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodDim;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IZtipoDimensioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZtipoDimensioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZtipoDimensione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_DIM
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodDim
		{
			get { return _CodDim; }
			set {
				if (CodDim != value)
				{
					_CodDim = value;
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
	/// Summary description for ZtipoDimensioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZtipoDimensioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZtipoDimensioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZtipoDimensione) info.GetValue(i.ToString(),typeof(ZtipoDimensione)));
			}
		}

		//Costruttore
		public ZtipoDimensioneCollection()
		{
			this.ItemType = typeof(ZtipoDimensione);
		}

		//Costruttore con provider
		public ZtipoDimensioneCollection(IZtipoDimensioneProvider providerObj)
		{
			this.ItemType = typeof(ZtipoDimensione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZtipoDimensione this[int index]
		{
			get { return (ZtipoDimensione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZtipoDimensioneCollection GetChanges()
		{
			return (ZtipoDimensioneCollection) base.GetChanges();
		}

		[NonSerialized] private IZtipoDimensioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZtipoDimensioneProvider Provider
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
		public int Add(ZtipoDimensione ZtipoDimensioneObj)
		{
			if (ZtipoDimensioneObj.Provider == null) ZtipoDimensioneObj.Provider = this.Provider;
			return base.Add(ZtipoDimensioneObj);
		}

		//AddCollection
		public void AddCollection(ZtipoDimensioneCollection ZtipoDimensioneCollectionObj)
		{
			foreach (ZtipoDimensione ZtipoDimensioneObj in ZtipoDimensioneCollectionObj)
				this.Add(ZtipoDimensioneObj);
		}

		//Insert
		public void Insert(int index, ZtipoDimensione ZtipoDimensioneObj)
		{
			if (ZtipoDimensioneObj.Provider == null) ZtipoDimensioneObj.Provider = this.Provider;
			base.Insert(index, ZtipoDimensioneObj);
		}

		//CollectionGetById
		public ZtipoDimensione CollectionGetById(NullTypes.StringNT CodDimValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodDim == CodDimValue))
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
		public ZtipoDimensioneCollection SubSelect(NullTypes.StringNT CodDimEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			ZtipoDimensioneCollection ZtipoDimensioneCollectionTemp = new ZtipoDimensioneCollection();
			foreach (ZtipoDimensione ZtipoDimensioneItem in this)
			{
				if (((CodDimEqualThis == null) || ((ZtipoDimensioneItem.CodDim != null) && (ZtipoDimensioneItem.CodDim.Value == CodDimEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ZtipoDimensioneItem.Descrizione != null) && (ZtipoDimensioneItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((OrdineEqualThis == null) || ((ZtipoDimensioneItem.Ordine != null) && (ZtipoDimensioneItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					ZtipoDimensioneCollectionTemp.Add(ZtipoDimensioneItem);
				}
			}
			return ZtipoDimensioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZtipoDimensioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZtipoDimensioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZtipoDimensione ZtipoDimensioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodDim", ZtipoDimensioneObj.CodDim);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZtipoDimensioneObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", ZtipoDimensioneObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, ZtipoDimensione ZtipoDimensioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZtipoDimensioneInsert", new string[] {"CodDim", "Descrizione", "Ordine"}, new string[] {"string", "string", "int"},"");
				CompileIUCmd(false, insertCmd,ZtipoDimensioneObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtipoDimensioneObj.IsDirty = false;
				ZtipoDimensioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZtipoDimensione ZtipoDimensioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZtipoDimensioneUpdate", new string[] {"CodDim", "Descrizione", "Ordine"}, new string[] {"string", "string", "int"},"");
				CompileIUCmd(true, updateCmd,ZtipoDimensioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtipoDimensioneObj.IsDirty = false;
				ZtipoDimensioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZtipoDimensione ZtipoDimensioneObj)
		{
			switch (ZtipoDimensioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZtipoDimensioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZtipoDimensioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZtipoDimensioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZtipoDimensioneCollection ZtipoDimensioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZtipoDimensioneUpdate", new string[] {"CodDim", "Descrizione", "Ordine"}, new string[] {"string", "string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZZtipoDimensioneInsert", new string[] {"CodDim", "Descrizione", "Ordine"}, new string[] {"string", "string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZtipoDimensioneDelete", new string[] {"CodDim"}, new string[] {"string"},"");
				for (int i = 0; i < ZtipoDimensioneCollectionObj.Count; i++)
				{
					switch (ZtipoDimensioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZtipoDimensioneCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZtipoDimensioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZtipoDimensioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodDim", (SiarLibrary.NullTypes.StringNT)ZtipoDimensioneCollectionObj[i].CodDim);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZtipoDimensioneCollectionObj.Count; i++)
				{
					if ((ZtipoDimensioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZtipoDimensioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZtipoDimensioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZtipoDimensioneCollectionObj[i].IsDirty = false;
						ZtipoDimensioneCollectionObj[i].IsPersistent = true;
					}
					if ((ZtipoDimensioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZtipoDimensioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZtipoDimensioneCollectionObj[i].IsDirty = false;
						ZtipoDimensioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZtipoDimensione ZtipoDimensioneObj)
		{
			int returnValue = 0;
			if (ZtipoDimensioneObj.IsPersistent) 
			{
				returnValue = Delete(db, ZtipoDimensioneObj.CodDim);
			}
			ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZtipoDimensioneObj.IsDirty = false;
			ZtipoDimensioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodDimValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZtipoDimensioneDelete", new string[] {"CodDim"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodDim", (SiarLibrary.NullTypes.StringNT)CodDimValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZtipoDimensioneCollection ZtipoDimensioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZtipoDimensioneDelete", new string[] {"CodDim"}, new string[] {"string"},"");
				for (int i = 0; i < ZtipoDimensioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodDim", ZtipoDimensioneCollectionObj[i].CodDim);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZtipoDimensioneCollectionObj.Count; i++)
				{
					if ((ZtipoDimensioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZtipoDimensioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZtipoDimensioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZtipoDimensioneCollectionObj[i].IsDirty = false;
						ZtipoDimensioneCollectionObj[i].IsPersistent = false;
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
		public static ZtipoDimensione GetById(DbProvider db, string CodDimValue)
		{
			ZtipoDimensione ZtipoDimensioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZtipoDimensioneGetById", new string[] {"CodDim"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodDim", (SiarLibrary.NullTypes.StringNT)CodDimValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZtipoDimensioneObj = GetFromDatareader(db);
				ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtipoDimensioneObj.IsDirty = false;
				ZtipoDimensioneObj.IsPersistent = true;
			}
			db.Close();
			return ZtipoDimensioneObj;
		}

		//getFromDatareader
		public static ZtipoDimensione GetFromDatareader(DbProvider db)
		{
			ZtipoDimensione ZtipoDimensioneObj = new ZtipoDimensione();
			ZtipoDimensioneObj.CodDim = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DIM"]);
			ZtipoDimensioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZtipoDimensioneObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZtipoDimensioneObj.IsDirty = false;
			ZtipoDimensioneObj.IsPersistent = true;
			return ZtipoDimensioneObj;
		}

		//Find Select

		public static ZtipoDimensioneCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodDimEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			ZtipoDimensioneCollection ZtipoDimensioneCollectionObj = new ZtipoDimensioneCollection();

			IDbCommand findCmd = db.InitCmd("Zztipodimensionefindselect", new string[] {"CodDimequalthis", "Descrizioneequalthis", "Ordineequalthis"}, new string[] {"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodDimequalthis", CodDimEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			ZtipoDimensione ZtipoDimensioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZtipoDimensioneObj = GetFromDatareader(db);
				ZtipoDimensioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtipoDimensioneObj.IsDirty = false;
				ZtipoDimensioneObj.IsPersistent = true;
				ZtipoDimensioneCollectionObj.Add(ZtipoDimensioneObj);
			}
			db.Close();
			return ZtipoDimensioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZtipoDimensioneCollectionProvider:IZtipoDimensioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZtipoDimensioneCollectionProvider : IZtipoDimensioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZtipoDimensione
		protected ZtipoDimensioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZtipoDimensioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZtipoDimensioneCollection(this);
		}

		//Costruttore3: ha in input ztipodimensioneCollectionObj - non popola la collection
		public ZtipoDimensioneCollectionProvider(ZtipoDimensioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZtipoDimensioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZtipoDimensioneCollection(this);
		}

		//Get e Set
		public ZtipoDimensioneCollection CollectionObj
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
		public int SaveCollection(ZtipoDimensioneCollection collectionObj)
		{
			return ZtipoDimensioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZtipoDimensione ztipodimensioneObj)
		{
			return ZtipoDimensioneDAL.Save(_dbProviderObj, ztipodimensioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZtipoDimensioneCollection collectionObj)
		{
			return ZtipoDimensioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZtipoDimensione ztipodimensioneObj)
		{
			return ZtipoDimensioneDAL.Delete(_dbProviderObj, ztipodimensioneObj);
		}

		//getById
		public ZtipoDimensione GetById(StringNT CodDimValue)
		{
			ZtipoDimensione ZtipoDimensioneTemp = ZtipoDimensioneDAL.GetById(_dbProviderObj, CodDimValue);
			if (ZtipoDimensioneTemp!=null) ZtipoDimensioneTemp.Provider = this;
			return ZtipoDimensioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZtipoDimensioneCollection Select(StringNT CoddimEqualThis, StringNT DescrizioneEqualThis, IntNT OrdineEqualThis)
		{
			ZtipoDimensioneCollection ZtipoDimensioneCollectionTemp = ZtipoDimensioneDAL.Select(_dbProviderObj, CoddimEqualThis, DescrizioneEqualThis, OrdineEqualThis);
			ZtipoDimensioneCollectionTemp.Provider = this;
			return ZtipoDimensioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zTIPO_DIMENSIONE>
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
</zTIPO_DIMENSIONE>
*/
