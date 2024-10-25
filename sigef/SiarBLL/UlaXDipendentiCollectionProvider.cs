using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per UlaXDipendenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IUlaXDipendentiProvider
	{
		int Save(UlaXDipendenti UlaXDipendentiObj);
		int SaveCollection(UlaXDipendentiCollection collectionObj);
		int Delete(UlaXDipendenti UlaXDipendentiObj);
		int DeleteCollection(UlaXDipendentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for UlaXDipendenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class UlaXDipendenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdUla;
		private NullTypes.IntNT _IdDipendenti;
		[NonSerialized] private IUlaXDipendentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaXDipendentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public UlaXDipendenti()
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
		/// Corrisponde al campo:ID_ULA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUla
		{
			get { return _IdUla; }
			set {
				if (IdUla != value)
				{
					_IdUla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIPENDENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDipendenti
		{
			get { return _IdDipendenti; }
			set {
				if (IdDipendenti != value)
				{
					_IdDipendenti = value;
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
	/// Summary description for UlaXDipendentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaXDipendentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private UlaXDipendentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((UlaXDipendenti) info.GetValue(i.ToString(),typeof(UlaXDipendenti)));
			}
		}

		//Costruttore
		public UlaXDipendentiCollection()
		{
			this.ItemType = typeof(UlaXDipendenti);
		}

		//Costruttore con provider
		public UlaXDipendentiCollection(IUlaXDipendentiProvider providerObj)
		{
			this.ItemType = typeof(UlaXDipendenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new UlaXDipendenti this[int index]
		{
			get { return (UlaXDipendenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new UlaXDipendentiCollection GetChanges()
		{
			return (UlaXDipendentiCollection) base.GetChanges();
		}

		[NonSerialized] private IUlaXDipendentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaXDipendentiProvider Provider
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
		public int Add(UlaXDipendenti UlaXDipendentiObj)
		{
			if (UlaXDipendentiObj.Provider == null) UlaXDipendentiObj.Provider = this.Provider;
			return base.Add(UlaXDipendentiObj);
		}

		//AddCollection
		public void AddCollection(UlaXDipendentiCollection UlaXDipendentiCollectionObj)
		{
			foreach (UlaXDipendenti UlaXDipendentiObj in UlaXDipendentiCollectionObj)
				this.Add(UlaXDipendentiObj);
		}

		//Insert
		public void Insert(int index, UlaXDipendenti UlaXDipendentiObj)
		{
			if (UlaXDipendentiObj.Provider == null) UlaXDipendentiObj.Provider = this.Provider;
			base.Insert(index, UlaXDipendentiObj);
		}

		//CollectionGetById
		public UlaXDipendenti CollectionGetById(NullTypes.IntNT IdValue)
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
		public UlaXDipendentiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdUlaEqualThis, NullTypes.IntNT IdDipendentiEqualThis)
		{
			UlaXDipendentiCollection UlaXDipendentiCollectionTemp = new UlaXDipendentiCollection();
			foreach (UlaXDipendenti UlaXDipendentiItem in this)
			{
				if (((IdEqualThis == null) || ((UlaXDipendentiItem.Id != null) && (UlaXDipendentiItem.Id.Value == IdEqualThis.Value))) && ((IdUlaEqualThis == null) || ((UlaXDipendentiItem.IdUla != null) && (UlaXDipendentiItem.IdUla.Value == IdUlaEqualThis.Value))) && ((IdDipendentiEqualThis == null) || ((UlaXDipendentiItem.IdDipendenti != null) && (UlaXDipendentiItem.IdDipendenti.Value == IdDipendentiEqualThis.Value))))
				{
					UlaXDipendentiCollectionTemp.Add(UlaXDipendentiItem);
				}
			}
			return UlaXDipendentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public UlaXDipendentiCollection Filter(NullTypes.IntNT IdUlaEqualThis, NullTypes.IntNT IdDipendentiEqualThis)
		{
			UlaXDipendentiCollection UlaXDipendentiCollectionTemp = new UlaXDipendentiCollection();
			foreach (UlaXDipendenti UlaXDipendentiItem in this)
			{
				if (((IdUlaEqualThis == null) || ((UlaXDipendentiItem.IdUla != null) && (UlaXDipendentiItem.IdUla.Value == IdUlaEqualThis.Value))) && ((IdDipendentiEqualThis == null) || ((UlaXDipendentiItem.IdDipendenti != null) && (UlaXDipendentiItem.IdDipendenti.Value == IdDipendentiEqualThis.Value))))
				{
					UlaXDipendentiCollectionTemp.Add(UlaXDipendentiItem);
				}
			}
			return UlaXDipendentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for UlaXDipendentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class UlaXDipendentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, UlaXDipendenti UlaXDipendentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", UlaXDipendentiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdUla", UlaXDipendentiObj.IdUla);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDipendenti", UlaXDipendentiObj.IdDipendenti);
		}
		//Insert
		private static int Insert(DbProvider db, UlaXDipendenti UlaXDipendentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZUlaXDipendentiInsert", new string[] {"IdUla", "IdDipendenti"}, new string[] {"int", "int"},"");
				CompileIUCmd(false, insertCmd,UlaXDipendentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				UlaXDipendentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaXDipendentiObj.IsDirty = false;
				UlaXDipendentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, UlaXDipendenti UlaXDipendentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaXDipendentiUpdate", new string[] {"Id", "IdUla", "IdDipendenti"}, new string[] {"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,UlaXDipendentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaXDipendentiObj.IsDirty = false;
				UlaXDipendentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, UlaXDipendenti UlaXDipendentiObj)
		{
			switch (UlaXDipendentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, UlaXDipendentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, UlaXDipendentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,UlaXDipendentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, UlaXDipendentiCollection UlaXDipendentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaXDipendentiUpdate", new string[] {"Id", "IdUla", "IdDipendenti"}, new string[] {"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZUlaXDipendentiInsert", new string[] {"IdUla", "IdDipendenti"}, new string[] {"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZUlaXDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaXDipendentiCollectionObj.Count; i++)
				{
					switch (UlaXDipendentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,UlaXDipendentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									UlaXDipendentiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,UlaXDipendentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (UlaXDipendentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)UlaXDipendentiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < UlaXDipendentiCollectionObj.Count; i++)
				{
					if ((UlaXDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaXDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaXDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						UlaXDipendentiCollectionObj[i].IsDirty = false;
						UlaXDipendentiCollectionObj[i].IsPersistent = true;
					}
					if ((UlaXDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						UlaXDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaXDipendentiCollectionObj[i].IsDirty = false;
						UlaXDipendentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, UlaXDipendenti UlaXDipendentiObj)
		{
			int returnValue = 0;
			if (UlaXDipendentiObj.IsPersistent) 
			{
				returnValue = Delete(db, UlaXDipendentiObj.Id);
			}
			UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			UlaXDipendentiObj.IsDirty = false;
			UlaXDipendentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaXDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, UlaXDipendentiCollection UlaXDipendentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaXDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaXDipendentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", UlaXDipendentiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < UlaXDipendentiCollectionObj.Count; i++)
				{
					if ((UlaXDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaXDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaXDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaXDipendentiCollectionObj[i].IsDirty = false;
						UlaXDipendentiCollectionObj[i].IsPersistent = false;
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
		public static UlaXDipendenti GetById(DbProvider db, int IdValue)
		{
			UlaXDipendenti UlaXDipendentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZUlaXDipendentiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				UlaXDipendentiObj = GetFromDatareader(db);
				UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaXDipendentiObj.IsDirty = false;
				UlaXDipendentiObj.IsPersistent = true;
			}
			db.Close();
			return UlaXDipendentiObj;
		}

		//getFromDatareader
		public static UlaXDipendenti GetFromDatareader(DbProvider db)
		{
			UlaXDipendenti UlaXDipendentiObj = new UlaXDipendenti();
			UlaXDipendentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			UlaXDipendentiObj.IdUla = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ULA"]);
			UlaXDipendentiObj.IdDipendenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIPENDENTI"]);
			UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			UlaXDipendentiObj.IsDirty = false;
			UlaXDipendentiObj.IsPersistent = true;
			return UlaXDipendentiObj;
		}

		//Find Select

		public static UlaXDipendentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdUlaEqualThis, SiarLibrary.NullTypes.IntNT IdDipendentiEqualThis)

		{

			UlaXDipendentiCollection UlaXDipendentiCollectionObj = new UlaXDipendentiCollection();

			IDbCommand findCmd = db.InitCmd("Zulaxdipendentifindselect", new string[] {"Idequalthis", "IdUlaequalthis", "IdDipendentiequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUlaequalthis", IdUlaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDipendentiequalthis", IdDipendentiEqualThis);
			UlaXDipendenti UlaXDipendentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaXDipendentiObj = GetFromDatareader(db);
				UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaXDipendentiObj.IsDirty = false;
				UlaXDipendentiObj.IsPersistent = true;
				UlaXDipendentiCollectionObj.Add(UlaXDipendentiObj);
			}
			db.Close();
			return UlaXDipendentiCollectionObj;
		}

		//Find Find

		public static UlaXDipendentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdUlaEqualThis, SiarLibrary.NullTypes.IntNT IdDipendentiEqualThis)

		{

			UlaXDipendentiCollection UlaXDipendentiCollectionObj = new UlaXDipendentiCollection();

			IDbCommand findCmd = db.InitCmd("Zulaxdipendentifindfind", new string[] {"IdUlaequalthis", "IdDipendentiequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUlaequalthis", IdUlaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDipendentiequalthis", IdDipendentiEqualThis);
			UlaXDipendenti UlaXDipendentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaXDipendentiObj = GetFromDatareader(db);
				UlaXDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaXDipendentiObj.IsDirty = false;
				UlaXDipendentiObj.IsPersistent = true;
				UlaXDipendentiCollectionObj.Add(UlaXDipendentiObj);
			}
			db.Close();
			return UlaXDipendentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for UlaXDipendentiCollectionProvider:IUlaXDipendentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaXDipendentiCollectionProvider : IUlaXDipendentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di UlaXDipendenti
		protected UlaXDipendentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public UlaXDipendentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new UlaXDipendentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public UlaXDipendentiCollectionProvider(IntNT IdulaEqualThis, IntNT IddipendentiEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdulaEqualThis, IddipendentiEqualThis);
		}

		//Costruttore3: ha in input ulaxdipendentiCollectionObj - non popola la collection
		public UlaXDipendentiCollectionProvider(UlaXDipendentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public UlaXDipendentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new UlaXDipendentiCollection(this);
		}

		//Get e Set
		public UlaXDipendentiCollection CollectionObj
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
		public int SaveCollection(UlaXDipendentiCollection collectionObj)
		{
			return UlaXDipendentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(UlaXDipendenti ulaxdipendentiObj)
		{
			return UlaXDipendentiDAL.Save(_dbProviderObj, ulaxdipendentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(UlaXDipendentiCollection collectionObj)
		{
			return UlaXDipendentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(UlaXDipendenti ulaxdipendentiObj)
		{
			return UlaXDipendentiDAL.Delete(_dbProviderObj, ulaxdipendentiObj);
		}

		//getById
		public UlaXDipendenti GetById(IntNT IdValue)
		{
			UlaXDipendenti UlaXDipendentiTemp = UlaXDipendentiDAL.GetById(_dbProviderObj, IdValue);
			if (UlaXDipendentiTemp!=null) UlaXDipendentiTemp.Provider = this;
			return UlaXDipendentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public UlaXDipendentiCollection Select(IntNT IdEqualThis, IntNT IdulaEqualThis, IntNT IddipendentiEqualThis)
		{
			UlaXDipendentiCollection UlaXDipendentiCollectionTemp = UlaXDipendentiDAL.Select(_dbProviderObj, IdEqualThis, IdulaEqualThis, IddipendentiEqualThis);
			UlaXDipendentiCollectionTemp.Provider = this;
			return UlaXDipendentiCollectionTemp;
		}

		//Find: popola la collection
		public UlaXDipendentiCollection Find(IntNT IdulaEqualThis, IntNT IddipendentiEqualThis)
		{
			UlaXDipendentiCollection UlaXDipendentiCollectionTemp = UlaXDipendentiDAL.Find(_dbProviderObj, IdulaEqualThis, IddipendentiEqualThis);
			UlaXDipendentiCollectionTemp.Provider = this;
			return UlaXDipendentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ULA_X_DIPENDENTI>
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
      <ID_ULA>Equal</ID_ULA>
      <ID_DIPENDENTI>Equal</ID_DIPENDENTI>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_ULA>Equal</ID_ULA>
      <ID_DIPENDENTI>Equal</ID_DIPENDENTI>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ULA_X_DIPENDENTI>
*/
