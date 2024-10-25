using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RinunciaBeneficiario
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRinunciaBeneficiarioProvider
	{
		int Save(RinunciaBeneficiario RinunciaBeneficiarioObj);
		int SaveCollection(RinunciaBeneficiarioCollection collectionObj);
		int Delete(RinunciaBeneficiario RinunciaBeneficiarioObj);
		int DeleteCollection(RinunciaBeneficiarioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RinunciaBeneficiario
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RinunciaBeneficiario: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRinunciaBeneficiario;
		private NullTypes.IntNT _IdRinuncia;
		private NullTypes.IntNT _IdImpresa;
		[NonSerialized] private IRinunciaBeneficiarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaBeneficiarioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RinunciaBeneficiario()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RINUNCIA_BENEFICIARIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRinunciaBeneficiario
		{
			get { return _IdRinunciaBeneficiario; }
			set {
				if (IdRinunciaBeneficiario != value)
				{
					_IdRinunciaBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RINUNCIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRinuncia
		{
			get { return _IdRinuncia; }
			set {
				if (IdRinuncia != value)
				{
					_IdRinuncia = value;
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
	/// Summary description for RinunciaBeneficiarioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaBeneficiarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RinunciaBeneficiarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RinunciaBeneficiario) info.GetValue(i.ToString(),typeof(RinunciaBeneficiario)));
			}
		}

		//Costruttore
		public RinunciaBeneficiarioCollection()
		{
			this.ItemType = typeof(RinunciaBeneficiario);
		}

		//Costruttore con provider
		public RinunciaBeneficiarioCollection(IRinunciaBeneficiarioProvider providerObj)
		{
			this.ItemType = typeof(RinunciaBeneficiario);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RinunciaBeneficiario this[int index]
		{
			get { return (RinunciaBeneficiario)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RinunciaBeneficiarioCollection GetChanges()
		{
			return (RinunciaBeneficiarioCollection) base.GetChanges();
		}

		[NonSerialized] private IRinunciaBeneficiarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaBeneficiarioProvider Provider
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
		public int Add(RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			if (RinunciaBeneficiarioObj.Provider == null) RinunciaBeneficiarioObj.Provider = this.Provider;
			return base.Add(RinunciaBeneficiarioObj);
		}

		//AddCollection
		public void AddCollection(RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionObj)
		{
			foreach (RinunciaBeneficiario RinunciaBeneficiarioObj in RinunciaBeneficiarioCollectionObj)
				this.Add(RinunciaBeneficiarioObj);
		}

		//Insert
		public void Insert(int index, RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			if (RinunciaBeneficiarioObj.Provider == null) RinunciaBeneficiarioObj.Provider = this.Provider;
			base.Insert(index, RinunciaBeneficiarioObj);
		}

		//CollectionGetById
		public RinunciaBeneficiario CollectionGetById(NullTypes.IntNT IdRinunciaBeneficiarioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRinunciaBeneficiario == IdRinunciaBeneficiarioValue))
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
		public RinunciaBeneficiarioCollection SubSelect(NullTypes.IntNT IdRinunciaBeneficiarioEqualThis, NullTypes.IntNT IdRinunciaEqualThis, NullTypes.IntNT IdImpresaEqualThis)
		{
			RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionTemp = new RinunciaBeneficiarioCollection();
			foreach (RinunciaBeneficiario RinunciaBeneficiarioItem in this)
			{
				if (((IdRinunciaBeneficiarioEqualThis == null) || ((RinunciaBeneficiarioItem.IdRinunciaBeneficiario != null) && (RinunciaBeneficiarioItem.IdRinunciaBeneficiario.Value == IdRinunciaBeneficiarioEqualThis.Value))) && ((IdRinunciaEqualThis == null) || ((RinunciaBeneficiarioItem.IdRinuncia != null) && (RinunciaBeneficiarioItem.IdRinuncia.Value == IdRinunciaEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RinunciaBeneficiarioItem.IdImpresa != null) && (RinunciaBeneficiarioItem.IdImpresa.Value == IdImpresaEqualThis.Value))))
				{
					RinunciaBeneficiarioCollectionTemp.Add(RinunciaBeneficiarioItem);
				}
			}
			return RinunciaBeneficiarioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RinunciaBeneficiarioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RinunciaBeneficiarioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RinunciaBeneficiario RinunciaBeneficiarioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRinunciaBeneficiario", RinunciaBeneficiarioObj.IdRinunciaBeneficiario);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRinuncia", RinunciaBeneficiarioObj.IdRinuncia);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RinunciaBeneficiarioObj.IdImpresa);
		}
		//Insert
		private static int Insert(DbProvider db, RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaBeneficiarioInsert", new string[] {"IdRinuncia", "IdImpresa"}, new string[] {"int", "int"},"");
				CompileIUCmd(false, insertCmd,RinunciaBeneficiarioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RinunciaBeneficiarioObj.IdRinunciaBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_BENEFICIARIO"]);
				}
				RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaBeneficiarioObj.IsDirty = false;
				RinunciaBeneficiarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaBeneficiarioUpdate", new string[] {"IdRinunciaBeneficiario", "IdRinuncia", "IdImpresa"}, new string[] {"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,RinunciaBeneficiarioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaBeneficiarioObj.IsDirty = false;
				RinunciaBeneficiarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			switch (RinunciaBeneficiarioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RinunciaBeneficiarioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RinunciaBeneficiarioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RinunciaBeneficiarioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaBeneficiarioUpdate", new string[] {"IdRinunciaBeneficiario", "IdRinuncia", "IdImpresa"}, new string[] {"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaBeneficiarioInsert", new string[] {"IdRinuncia", "IdImpresa"}, new string[] {"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaBeneficiarioDelete", new string[] {"IdRinunciaBeneficiario"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaBeneficiarioCollectionObj.Count; i++)
				{
					switch (RinunciaBeneficiarioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RinunciaBeneficiarioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RinunciaBeneficiarioCollectionObj[i].IdRinunciaBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_BENEFICIARIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RinunciaBeneficiarioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RinunciaBeneficiarioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaBeneficiario", (SiarLibrary.NullTypes.IntNT)RinunciaBeneficiarioCollectionObj[i].IdRinunciaBeneficiario);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RinunciaBeneficiarioCollectionObj.Count; i++)
				{
					if ((RinunciaBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RinunciaBeneficiarioCollectionObj[i].IsDirty = false;
						RinunciaBeneficiarioCollectionObj[i].IsPersistent = true;
					}
					if ((RinunciaBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RinunciaBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaBeneficiarioCollectionObj[i].IsDirty = false;
						RinunciaBeneficiarioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RinunciaBeneficiario RinunciaBeneficiarioObj)
		{
			int returnValue = 0;
			if (RinunciaBeneficiarioObj.IsPersistent) 
			{
				returnValue = Delete(db, RinunciaBeneficiarioObj.IdRinunciaBeneficiario);
			}
			RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RinunciaBeneficiarioObj.IsDirty = false;
			RinunciaBeneficiarioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRinunciaBeneficiarioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaBeneficiarioDelete", new string[] {"IdRinunciaBeneficiario"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaBeneficiario", (SiarLibrary.NullTypes.IntNT)IdRinunciaBeneficiarioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaBeneficiarioDelete", new string[] {"IdRinunciaBeneficiario"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaBeneficiarioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaBeneficiario", RinunciaBeneficiarioCollectionObj[i].IdRinunciaBeneficiario);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RinunciaBeneficiarioCollectionObj.Count; i++)
				{
					if ((RinunciaBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaBeneficiarioCollectionObj[i].IsDirty = false;
						RinunciaBeneficiarioCollectionObj[i].IsPersistent = false;
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
		public static RinunciaBeneficiario GetById(DbProvider db, int IdRinunciaBeneficiarioValue)
		{
			RinunciaBeneficiario RinunciaBeneficiarioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRinunciaBeneficiarioGetById", new string[] {"IdRinunciaBeneficiario"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRinunciaBeneficiario", (SiarLibrary.NullTypes.IntNT)IdRinunciaBeneficiarioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RinunciaBeneficiarioObj = GetFromDatareader(db);
				RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaBeneficiarioObj.IsDirty = false;
				RinunciaBeneficiarioObj.IsPersistent = true;
			}
			db.Close();
			return RinunciaBeneficiarioObj;
		}

		//getFromDatareader
		public static RinunciaBeneficiario GetFromDatareader(DbProvider db)
		{
			RinunciaBeneficiario RinunciaBeneficiarioObj = new RinunciaBeneficiario();
			RinunciaBeneficiarioObj.IdRinunciaBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_BENEFICIARIO"]);
			RinunciaBeneficiarioObj.IdRinuncia = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA"]);
			RinunciaBeneficiarioObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RinunciaBeneficiarioObj.IsDirty = false;
			RinunciaBeneficiarioObj.IsPersistent = true;
			return RinunciaBeneficiarioObj;
		}

		//Find Select

		public static RinunciaBeneficiarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRinunciaBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdRinunciaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionObj = new RinunciaBeneficiarioCollection();

			IDbCommand findCmd = db.InitCmd("Zrinunciabeneficiariofindselect", new string[] {"IdRinunciaBeneficiarioequalthis", "IdRinunciaequalthis", "IdImpresaequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRinunciaBeneficiarioequalthis", IdRinunciaBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRinunciaequalthis", IdRinunciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			RinunciaBeneficiario RinunciaBeneficiarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RinunciaBeneficiarioObj = GetFromDatareader(db);
				RinunciaBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaBeneficiarioObj.IsDirty = false;
				RinunciaBeneficiarioObj.IsPersistent = true;
				RinunciaBeneficiarioCollectionObj.Add(RinunciaBeneficiarioObj);
			}
			db.Close();
			return RinunciaBeneficiarioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RinunciaBeneficiarioCollectionProvider:IRinunciaBeneficiarioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaBeneficiarioCollectionProvider : IRinunciaBeneficiarioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RinunciaBeneficiario
		protected RinunciaBeneficiarioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RinunciaBeneficiarioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RinunciaBeneficiarioCollection(this);
		}

		//Costruttore3: ha in input rinunciabeneficiarioCollectionObj - non popola la collection
		public RinunciaBeneficiarioCollectionProvider(RinunciaBeneficiarioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RinunciaBeneficiarioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RinunciaBeneficiarioCollection(this);
		}

		//Get e Set
		public RinunciaBeneficiarioCollection CollectionObj
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
		public int SaveCollection(RinunciaBeneficiarioCollection collectionObj)
		{
			return RinunciaBeneficiarioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RinunciaBeneficiario rinunciabeneficiarioObj)
		{
			return RinunciaBeneficiarioDAL.Save(_dbProviderObj, rinunciabeneficiarioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RinunciaBeneficiarioCollection collectionObj)
		{
			return RinunciaBeneficiarioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RinunciaBeneficiario rinunciabeneficiarioObj)
		{
			return RinunciaBeneficiarioDAL.Delete(_dbProviderObj, rinunciabeneficiarioObj);
		}

		//getById
		public RinunciaBeneficiario GetById(IntNT IdRinunciaBeneficiarioValue)
		{
			RinunciaBeneficiario RinunciaBeneficiarioTemp = RinunciaBeneficiarioDAL.GetById(_dbProviderObj, IdRinunciaBeneficiarioValue);
			if (RinunciaBeneficiarioTemp!=null) RinunciaBeneficiarioTemp.Provider = this;
			return RinunciaBeneficiarioTemp;
		}

		//Select: popola la collection
		public RinunciaBeneficiarioCollection Select(IntNT IdrinunciabeneficiarioEqualThis, IntNT IdrinunciaEqualThis, IntNT IdimpresaEqualThis)
		{
			RinunciaBeneficiarioCollection RinunciaBeneficiarioCollectionTemp = RinunciaBeneficiarioDAL.Select(_dbProviderObj, IdrinunciabeneficiarioEqualThis, IdrinunciaEqualThis, IdimpresaEqualThis);
			RinunciaBeneficiarioCollectionTemp.Provider = this;
			return RinunciaBeneficiarioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RINUNCIA_BENEFICIARIO>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</RINUNCIA_BENEFICIARIO>
*/
