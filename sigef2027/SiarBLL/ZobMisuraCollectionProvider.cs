using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZobMisura
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZobMisuraProvider
	{
		int Save(ZobMisura ZobMisuraObj);
		int SaveCollection(ZobMisuraCollection collectionObj);
		int Delete(ZobMisura ZobMisuraObj);
		int DeleteCollection(ZobMisuraCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZobMisura
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZobMisura: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IZobMisuraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZobMisuraProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZobMisura()
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
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
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
	/// Summary description for ZobMisuraCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZobMisuraCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZobMisuraCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZobMisura) info.GetValue(i.ToString(),typeof(ZobMisura)));
			}
		}

		//Costruttore
		public ZobMisuraCollection()
		{
			this.ItemType = typeof(ZobMisura);
		}

		//Costruttore con provider
		public ZobMisuraCollection(IZobMisuraProvider providerObj)
		{
			this.ItemType = typeof(ZobMisura);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZobMisura this[int index]
		{
			get { return (ZobMisura)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZobMisuraCollection GetChanges()
		{
			return (ZobMisuraCollection) base.GetChanges();
		}

		[NonSerialized] private IZobMisuraProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZobMisuraProvider Provider
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
		public int Add(ZobMisura ZobMisuraObj)
		{
			if (ZobMisuraObj.Provider == null) ZobMisuraObj.Provider = this.Provider;
			return base.Add(ZobMisuraObj);
		}

		//AddCollection
		public void AddCollection(ZobMisuraCollection ZobMisuraCollectionObj)
		{
			foreach (ZobMisura ZobMisuraObj in ZobMisuraCollectionObj)
				this.Add(ZobMisuraObj);
		}

		//Insert
		public void Insert(int index, ZobMisura ZobMisuraObj)
		{
			if (ZobMisuraObj.Provider == null) ZobMisuraObj.Provider = this.Provider;
			base.Insert(index, ZobMisuraObj);
		}

		//CollectionGetById
		public ZobMisura CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZobMisuraCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			ZobMisuraCollection ZobMisuraCollectionTemp = new ZobMisuraCollection();
			foreach (ZobMisura ZobMisuraItem in this)
			{
				if (((IdEqualThis == null) || ((ZobMisuraItem.Id != null) && (ZobMisuraItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZobMisuraItem.IdProgrammazione != null) && (ZobMisuraItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((CodiceEqualThis == null) || ((ZobMisuraItem.Codice != null) && (ZobMisuraItem.Codice.Value == CodiceEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((ZobMisuraItem.Descrizione != null) && (ZobMisuraItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ZobMisuraCollectionTemp.Add(ZobMisuraItem);
				}
			}
			return ZobMisuraCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZobMisuraDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZobMisuraDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZobMisura ZobMisuraObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZobMisuraObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZobMisuraObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ZobMisuraObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZobMisuraObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, ZobMisura ZobMisuraObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZobMisuraInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,ZobMisuraObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZobMisuraObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZobMisuraObj.IsDirty = false;
				ZobMisuraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZobMisura ZobMisuraObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZobMisuraUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,ZobMisuraObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZobMisuraObj.IsDirty = false;
				ZobMisuraObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZobMisura ZobMisuraObj)
		{
			switch (ZobMisuraObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZobMisuraObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZobMisuraObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZobMisuraObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZobMisuraCollection ZobMisuraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZobMisuraUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZZobMisuraInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZobMisuraDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZobMisuraCollectionObj.Count; i++)
				{
					switch (ZobMisuraCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZobMisuraCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZobMisuraCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZobMisuraCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZobMisuraCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZobMisuraCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZobMisuraCollectionObj.Count; i++)
				{
					if ((ZobMisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZobMisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZobMisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZobMisuraCollectionObj[i].IsDirty = false;
						ZobMisuraCollectionObj[i].IsPersistent = true;
					}
					if ((ZobMisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZobMisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZobMisuraCollectionObj[i].IsDirty = false;
						ZobMisuraCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZobMisura ZobMisuraObj)
		{
			int returnValue = 0;
			if (ZobMisuraObj.IsPersistent) 
			{
				returnValue = Delete(db, ZobMisuraObj.Id);
			}
			ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZobMisuraObj.IsDirty = false;
			ZobMisuraObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZobMisuraDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZobMisuraCollection ZobMisuraCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZobMisuraDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZobMisuraCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZobMisuraCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZobMisuraCollectionObj.Count; i++)
				{
					if ((ZobMisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZobMisuraCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZobMisuraCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZobMisuraCollectionObj[i].IsDirty = false;
						ZobMisuraCollectionObj[i].IsPersistent = false;
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
		public static ZobMisura GetById(DbProvider db, int IdValue)
		{
			ZobMisura ZobMisuraObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZobMisuraGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZobMisuraObj = GetFromDatareader(db);
				ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZobMisuraObj.IsDirty = false;
				ZobMisuraObj.IsPersistent = true;
			}
			db.Close();
			return ZobMisuraObj;
		}

		//getFromDatareader
		public static ZobMisura GetFromDatareader(DbProvider db)
		{
			ZobMisura ZobMisuraObj = new ZobMisura();
			ZobMisuraObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZobMisuraObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZobMisuraObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ZobMisuraObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZobMisuraObj.IsDirty = false;
			ZobMisuraObj.IsPersistent = true;
			return ZobMisuraObj;
		}

		//Find Select

		public static ZobMisuraCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ZobMisuraCollection ZobMisuraCollectionObj = new ZobMisuraCollection();

			IDbCommand findCmd = db.InitCmd("Zzobmisurafindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "Codiceequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			ZobMisura ZobMisuraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZobMisuraObj = GetFromDatareader(db);
				ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZobMisuraObj.IsDirty = false;
				ZobMisuraObj.IsPersistent = true;
				ZobMisuraCollectionObj.Add(ZobMisuraObj);
			}
			db.Close();
			return ZobMisuraCollectionObj;
		}

		//Find Find

		public static ZobMisuraCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis)

		{

			ZobMisuraCollection ZobMisuraCollectionObj = new ZobMisuraCollection();

			IDbCommand findCmd = db.InitCmd("Zzobmisurafindfind", new string[] {"IdProgrammazioneequalthis", "Codiceequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			ZobMisura ZobMisuraObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZobMisuraObj = GetFromDatareader(db);
				ZobMisuraObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZobMisuraObj.IsDirty = false;
				ZobMisuraObj.IsPersistent = true;
				ZobMisuraCollectionObj.Add(ZobMisuraObj);
			}
			db.Close();
			return ZobMisuraCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZobMisuraCollectionProvider:IZobMisuraProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZobMisuraCollectionProvider : IZobMisuraProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZobMisura
		protected ZobMisuraCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZobMisuraCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZobMisuraCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZobMisuraCollectionProvider(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogrammazioneEqualThis, CodiceEqualThis);
		}

		//Costruttore3: ha in input zobmisuraCollectionObj - non popola la collection
		public ZobMisuraCollectionProvider(ZobMisuraCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZobMisuraCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZobMisuraCollection(this);
		}

		//Get e Set
		public ZobMisuraCollection CollectionObj
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
		public int SaveCollection(ZobMisuraCollection collectionObj)
		{
			return ZobMisuraDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZobMisura zobmisuraObj)
		{
			return ZobMisuraDAL.Save(_dbProviderObj, zobmisuraObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZobMisuraCollection collectionObj)
		{
			return ZobMisuraDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZobMisura zobmisuraObj)
		{
			return ZobMisuraDAL.Delete(_dbProviderObj, zobmisuraObj);
		}

		//getById
		public ZobMisura GetById(IntNT IdValue)
		{
			ZobMisura ZobMisuraTemp = ZobMisuraDAL.GetById(_dbProviderObj, IdValue);
			if (ZobMisuraTemp!=null) ZobMisuraTemp.Provider = this;
			return ZobMisuraTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZobMisuraCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, 
StringNT DescrizioneEqualThis)
		{
			ZobMisuraCollection ZobMisuraCollectionTemp = ZobMisuraDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, CodiceEqualThis, 
DescrizioneEqualThis);
			ZobMisuraCollectionTemp.Provider = this;
			return ZobMisuraCollectionTemp;
		}

		//Find: popola la collection
		public ZobMisuraCollection Find(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis)
		{
			ZobMisuraCollection ZobMisuraCollectionTemp = ZobMisuraDAL.Find(_dbProviderObj, IdprogrammazioneEqualThis, CodiceEqualThis);
			ZobMisuraCollectionTemp.Provider = this;
			return ZobMisuraCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zOB_MISURA>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zOB_MISURA>
*/
