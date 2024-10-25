using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RinunciaProtocollo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRinunciaProtocolloProvider
	{
		int Save(RinunciaProtocollo RinunciaProtocolloObj);
		int SaveCollection(RinunciaProtocolloCollection collectionObj);
		int Delete(RinunciaProtocollo RinunciaProtocolloObj);
		int DeleteCollection(RinunciaProtocolloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RinunciaProtocollo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RinunciaProtocollo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRinunciaProtocollo;
		private NullTypes.IntNT _IdRinuncia;
		private NullTypes.StringNT _Protocollo;
		[NonSerialized] private IRinunciaProtocolloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaProtocolloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RinunciaProtocollo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RINUNCIA_PROTOCOLLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRinunciaProtocollo
		{
			get { return _IdRinunciaProtocollo; }
			set {
				if (IdRinunciaProtocollo != value)
				{
					_IdRinunciaProtocollo = value;
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
		/// Corrisponde al campo:PROTOCOLLO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Protocollo
		{
			get { return _Protocollo; }
			set {
				if (Protocollo != value)
				{
					_Protocollo = value;
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
	/// Summary description for RinunciaProtocolloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaProtocolloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RinunciaProtocolloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RinunciaProtocollo) info.GetValue(i.ToString(),typeof(RinunciaProtocollo)));
			}
		}

		//Costruttore
		public RinunciaProtocolloCollection()
		{
			this.ItemType = typeof(RinunciaProtocollo);
		}

		//Costruttore con provider
		public RinunciaProtocolloCollection(IRinunciaProtocolloProvider providerObj)
		{
			this.ItemType = typeof(RinunciaProtocollo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RinunciaProtocollo this[int index]
		{
			get { return (RinunciaProtocollo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RinunciaProtocolloCollection GetChanges()
		{
			return (RinunciaProtocolloCollection) base.GetChanges();
		}

		[NonSerialized] private IRinunciaProtocolloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaProtocolloProvider Provider
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
		public int Add(RinunciaProtocollo RinunciaProtocolloObj)
		{
			if (RinunciaProtocolloObj.Provider == null) RinunciaProtocolloObj.Provider = this.Provider;
			return base.Add(RinunciaProtocolloObj);
		}

		//AddCollection
		public void AddCollection(RinunciaProtocolloCollection RinunciaProtocolloCollectionObj)
		{
			foreach (RinunciaProtocollo RinunciaProtocolloObj in RinunciaProtocolloCollectionObj)
				this.Add(RinunciaProtocolloObj);
		}

		//Insert
		public void Insert(int index, RinunciaProtocollo RinunciaProtocolloObj)
		{
			if (RinunciaProtocolloObj.Provider == null) RinunciaProtocolloObj.Provider = this.Provider;
			base.Insert(index, RinunciaProtocolloObj);
		}

		//CollectionGetById
		public RinunciaProtocollo CollectionGetById(NullTypes.IntNT IdRinunciaProtocolloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRinunciaProtocollo == IdRinunciaProtocolloValue))
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
		public RinunciaProtocolloCollection SubSelect(NullTypes.IntNT IdRinunciaProtocolloEqualThis, NullTypes.IntNT IdRinunciaEqualThis, NullTypes.StringNT ProtocolloEqualThis)
		{
			RinunciaProtocolloCollection RinunciaProtocolloCollectionTemp = new RinunciaProtocolloCollection();
			foreach (RinunciaProtocollo RinunciaProtocolloItem in this)
			{
				if (((IdRinunciaProtocolloEqualThis == null) || ((RinunciaProtocolloItem.IdRinunciaProtocollo != null) && (RinunciaProtocolloItem.IdRinunciaProtocollo.Value == IdRinunciaProtocolloEqualThis.Value))) && ((IdRinunciaEqualThis == null) || ((RinunciaProtocolloItem.IdRinuncia != null) && (RinunciaProtocolloItem.IdRinuncia.Value == IdRinunciaEqualThis.Value))) && ((ProtocolloEqualThis == null) || ((RinunciaProtocolloItem.Protocollo != null) && (RinunciaProtocolloItem.Protocollo.Value == ProtocolloEqualThis.Value))))
				{
					RinunciaProtocolloCollectionTemp.Add(RinunciaProtocolloItem);
				}
			}
			return RinunciaProtocolloCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RinunciaProtocolloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RinunciaProtocolloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RinunciaProtocollo RinunciaProtocolloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRinunciaProtocollo", RinunciaProtocolloObj.IdRinunciaProtocollo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRinuncia", RinunciaProtocolloObj.IdRinuncia);
			DbProvider.SetCmdParam(cmd,firstChar + "Protocollo", RinunciaProtocolloObj.Protocollo);
		}
		//Insert
		private static int Insert(DbProvider db, RinunciaProtocollo RinunciaProtocolloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaProtocolloInsert", new string[] {"IdRinuncia", "Protocollo"}, new string[] {"int", "string"},"");
				CompileIUCmd(false, insertCmd,RinunciaProtocolloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RinunciaProtocolloObj.IdRinunciaProtocollo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_PROTOCOLLO"]);
				}
				RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaProtocolloObj.IsDirty = false;
				RinunciaProtocolloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RinunciaProtocollo RinunciaProtocolloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaProtocolloUpdate", new string[] {"IdRinunciaProtocollo", "IdRinuncia", "Protocollo"}, new string[] {"int", "int", "string"},"");
				CompileIUCmd(true, updateCmd,RinunciaProtocolloObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaProtocolloObj.IsDirty = false;
				RinunciaProtocolloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RinunciaProtocollo RinunciaProtocolloObj)
		{
			switch (RinunciaProtocolloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RinunciaProtocolloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RinunciaProtocolloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RinunciaProtocolloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RinunciaProtocolloCollection RinunciaProtocolloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaProtocolloUpdate", new string[] {"IdRinunciaProtocollo", "IdRinuncia", "Protocollo"}, new string[] {"int", "int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaProtocolloInsert", new string[] {"IdRinuncia", "Protocollo"}, new string[] {"int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaProtocolloDelete", new string[] {"IdRinunciaProtocollo"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaProtocolloCollectionObj.Count; i++)
				{
					switch (RinunciaProtocolloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RinunciaProtocolloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RinunciaProtocolloCollectionObj[i].IdRinunciaProtocollo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_PROTOCOLLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RinunciaProtocolloCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RinunciaProtocolloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaProtocollo", (SiarLibrary.NullTypes.IntNT)RinunciaProtocolloCollectionObj[i].IdRinunciaProtocollo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RinunciaProtocolloCollectionObj.Count; i++)
				{
					if ((RinunciaProtocolloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaProtocolloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaProtocolloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RinunciaProtocolloCollectionObj[i].IsDirty = false;
						RinunciaProtocolloCollectionObj[i].IsPersistent = true;
					}
					if ((RinunciaProtocolloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RinunciaProtocolloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaProtocolloCollectionObj[i].IsDirty = false;
						RinunciaProtocolloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RinunciaProtocollo RinunciaProtocolloObj)
		{
			int returnValue = 0;
			if (RinunciaProtocolloObj.IsPersistent) 
			{
				returnValue = Delete(db, RinunciaProtocolloObj.IdRinunciaProtocollo);
			}
			RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RinunciaProtocolloObj.IsDirty = false;
			RinunciaProtocolloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRinunciaProtocolloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaProtocolloDelete", new string[] {"IdRinunciaProtocollo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaProtocollo", (SiarLibrary.NullTypes.IntNT)IdRinunciaProtocolloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RinunciaProtocolloCollection RinunciaProtocolloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaProtocolloDelete", new string[] {"IdRinunciaProtocollo"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaProtocolloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinunciaProtocollo", RinunciaProtocolloCollectionObj[i].IdRinunciaProtocollo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RinunciaProtocolloCollectionObj.Count; i++)
				{
					if ((RinunciaProtocolloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaProtocolloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaProtocolloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaProtocolloCollectionObj[i].IsDirty = false;
						RinunciaProtocolloCollectionObj[i].IsPersistent = false;
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
		public static RinunciaProtocollo GetById(DbProvider db, int IdRinunciaProtocolloValue)
		{
			RinunciaProtocollo RinunciaProtocolloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRinunciaProtocolloGetById", new string[] {"IdRinunciaProtocollo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRinunciaProtocollo", (SiarLibrary.NullTypes.IntNT)IdRinunciaProtocolloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RinunciaProtocolloObj = GetFromDatareader(db);
				RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaProtocolloObj.IsDirty = false;
				RinunciaProtocolloObj.IsPersistent = true;
			}
			db.Close();
			return RinunciaProtocolloObj;
		}

		//getFromDatareader
		public static RinunciaProtocollo GetFromDatareader(DbProvider db)
		{
			RinunciaProtocollo RinunciaProtocolloObj = new RinunciaProtocollo();
			RinunciaProtocolloObj.IdRinunciaProtocollo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA_PROTOCOLLO"]);
			RinunciaProtocolloObj.IdRinuncia = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA"]);
			RinunciaProtocolloObj.Protocollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROTOCOLLO"]);
			RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RinunciaProtocolloObj.IsDirty = false;
			RinunciaProtocolloObj.IsPersistent = true;
			return RinunciaProtocolloObj;
		}

		//Find Select

		public static RinunciaProtocolloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRinunciaProtocolloEqualThis, SiarLibrary.NullTypes.IntNT IdRinunciaEqualThis, SiarLibrary.NullTypes.StringNT ProtocolloEqualThis)

		{

			RinunciaProtocolloCollection RinunciaProtocolloCollectionObj = new RinunciaProtocolloCollection();

			IDbCommand findCmd = db.InitCmd("Zrinunciaprotocollofindselect", new string[] {"IdRinunciaProtocolloequalthis", "IdRinunciaequalthis", "Protocolloequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRinunciaProtocolloequalthis", IdRinunciaProtocolloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRinunciaequalthis", IdRinunciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocolloequalthis", ProtocolloEqualThis);
			RinunciaProtocollo RinunciaProtocolloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RinunciaProtocolloObj = GetFromDatareader(db);
				RinunciaProtocolloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaProtocolloObj.IsDirty = false;
				RinunciaProtocolloObj.IsPersistent = true;
				RinunciaProtocolloCollectionObj.Add(RinunciaProtocolloObj);
			}
			db.Close();
			return RinunciaProtocolloCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RinunciaProtocolloCollectionProvider:IRinunciaProtocolloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaProtocolloCollectionProvider : IRinunciaProtocolloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RinunciaProtocollo
		protected RinunciaProtocolloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RinunciaProtocolloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RinunciaProtocolloCollection(this);
		}

		//Costruttore3: ha in input rinunciaprotocolloCollectionObj - non popola la collection
		public RinunciaProtocolloCollectionProvider(RinunciaProtocolloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RinunciaProtocolloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RinunciaProtocolloCollection(this);
		}

		//Get e Set
		public RinunciaProtocolloCollection CollectionObj
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
		public int SaveCollection(RinunciaProtocolloCollection collectionObj)
		{
			return RinunciaProtocolloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RinunciaProtocollo rinunciaprotocolloObj)
		{
			return RinunciaProtocolloDAL.Save(_dbProviderObj, rinunciaprotocolloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RinunciaProtocolloCollection collectionObj)
		{
			return RinunciaProtocolloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RinunciaProtocollo rinunciaprotocolloObj)
		{
			return RinunciaProtocolloDAL.Delete(_dbProviderObj, rinunciaprotocolloObj);
		}

		//getById
		public RinunciaProtocollo GetById(IntNT IdRinunciaProtocolloValue)
		{
			RinunciaProtocollo RinunciaProtocolloTemp = RinunciaProtocolloDAL.GetById(_dbProviderObj, IdRinunciaProtocolloValue);
			if (RinunciaProtocolloTemp!=null) RinunciaProtocolloTemp.Provider = this;
			return RinunciaProtocolloTemp;
		}

		//Select: popola la collection
		public RinunciaProtocolloCollection Select(IntNT IdrinunciaprotocolloEqualThis, IntNT IdrinunciaEqualThis, StringNT ProtocolloEqualThis)
		{
			RinunciaProtocolloCollection RinunciaProtocolloCollectionTemp = RinunciaProtocolloDAL.Select(_dbProviderObj, IdrinunciaprotocolloEqualThis, IdrinunciaEqualThis, ProtocolloEqualThis);
			RinunciaProtocolloCollectionTemp.Provider = this;
			return RinunciaProtocolloCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RINUNCIA_PROTOCOLLO>
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
</RINUNCIA_PROTOCOLLO>
*/
