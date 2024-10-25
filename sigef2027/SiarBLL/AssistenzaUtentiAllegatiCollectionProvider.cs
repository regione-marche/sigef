using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AssistenzaUtentiAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAssistenzaUtentiAllegatiProvider
	{
		int Save(AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj);
		int SaveCollection(AssistenzaUtentiAllegatiCollection collectionObj);
		int Delete(AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj);
		int DeleteCollection(AssistenzaUtentiAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AssistenzaUtentiAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AssistenzaUtentiAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdAssistenza;
		[NonSerialized] private IAssistenzaUtentiAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssistenzaUtentiAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AssistenzaUtentiAllegati()
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
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ASSISTENZA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAssistenza
		{
			get { return _IdAssistenza; }
			set {
				if (IdAssistenza != value)
				{
					_IdAssistenza = value;
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
	/// Summary description for AssistenzaUtentiAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssistenzaUtentiAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AssistenzaUtentiAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AssistenzaUtentiAllegati) info.GetValue(i.ToString(),typeof(AssistenzaUtentiAllegati)));
			}
		}

		//Costruttore
		public AssistenzaUtentiAllegatiCollection()
		{
			this.ItemType = typeof(AssistenzaUtentiAllegati);
		}

		//Costruttore con provider
		public AssistenzaUtentiAllegatiCollection(IAssistenzaUtentiAllegatiProvider providerObj)
		{
			this.ItemType = typeof(AssistenzaUtentiAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AssistenzaUtentiAllegati this[int index]
		{
			get { return (AssistenzaUtentiAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AssistenzaUtentiAllegatiCollection GetChanges()
		{
			return (AssistenzaUtentiAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IAssistenzaUtentiAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssistenzaUtentiAllegatiProvider Provider
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
		public int Add(AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			if (AssistenzaUtentiAllegatiObj.Provider == null) AssistenzaUtentiAllegatiObj.Provider = this.Provider;
			return base.Add(AssistenzaUtentiAllegatiObj);
		}

		//AddCollection
		public void AddCollection(AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionObj)
		{
			foreach (AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj in AssistenzaUtentiAllegatiCollectionObj)
				this.Add(AssistenzaUtentiAllegatiObj);
		}

		//Insert
		public void Insert(int index, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			if (AssistenzaUtentiAllegatiObj.Provider == null) AssistenzaUtentiAllegatiObj.Provider = this.Provider;
			base.Insert(index, AssistenzaUtentiAllegatiObj);
		}

		//CollectionGetById
		public AssistenzaUtentiAllegati CollectionGetById(NullTypes.IntNT IdValue)
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
		public AssistenzaUtentiAllegatiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdAssistenzaEqualThis)
		{
			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionTemp = new AssistenzaUtentiAllegatiCollection();
			foreach (AssistenzaUtentiAllegati AssistenzaUtentiAllegatiItem in this)
			{
				if (((IdEqualThis == null) || ((AssistenzaUtentiAllegatiItem.Id != null) && (AssistenzaUtentiAllegatiItem.Id.Value == IdEqualThis.Value))) && ((IdAllegatoEqualThis == null) || ((AssistenzaUtentiAllegatiItem.IdAllegato != null) && (AssistenzaUtentiAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdAssistenzaEqualThis == null) || ((AssistenzaUtentiAllegatiItem.IdAssistenza != null) && (AssistenzaUtentiAllegatiItem.IdAssistenza.Value == IdAssistenzaEqualThis.Value))))
				{
					AssistenzaUtentiAllegatiCollectionTemp.Add(AssistenzaUtentiAllegatiItem);
				}
			}
			return AssistenzaUtentiAllegatiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public AssistenzaUtentiAllegatiCollection Filter(NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdAssistenzaEqualThis)
		{
			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionTemp = new AssistenzaUtentiAllegatiCollection();
			foreach (AssistenzaUtentiAllegati AssistenzaUtentiAllegatiItem in this)
			{
				if (((IdAllegatoEqualThis == null) || ((AssistenzaUtentiAllegatiItem.IdAllegato != null) && (AssistenzaUtentiAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdAssistenzaEqualThis == null) || ((AssistenzaUtentiAllegatiItem.IdAssistenza != null) && (AssistenzaUtentiAllegatiItem.IdAssistenza.Value == IdAssistenzaEqualThis.Value))))
				{
					AssistenzaUtentiAllegatiCollectionTemp.Add(AssistenzaUtentiAllegatiItem);
				}
			}
			return AssistenzaUtentiAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AssistenzaUtentiAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AssistenzaUtentiAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", AssistenzaUtentiAllegatiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", AssistenzaUtentiAllegatiObj.IdAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAssistenza", AssistenzaUtentiAllegatiObj.IdAssistenza);
		}
		//Insert
		private static int Insert(DbProvider db, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiInsert", new string[] {"IdAllegato", "IdAssistenza"}, new string[] {"int", "int"},"");
				CompileIUCmd(false, insertCmd,AssistenzaUtentiAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AssistenzaUtentiAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiAllegatiObj.IsDirty = false;
				AssistenzaUtentiAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiUpdate", new string[] {"Id", "IdAllegato", "IdAssistenza"}, new string[] {"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,AssistenzaUtentiAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiAllegatiObj.IsDirty = false;
				AssistenzaUtentiAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			switch (AssistenzaUtentiAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AssistenzaUtentiAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AssistenzaUtentiAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AssistenzaUtentiAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiUpdate", new string[] {"Id", "IdAllegato", "IdAssistenza"}, new string[] {"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiInsert", new string[] {"IdAllegato", "IdAssistenza"}, new string[] {"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AssistenzaUtentiAllegatiCollectionObj.Count; i++)
				{
					switch (AssistenzaUtentiAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AssistenzaUtentiAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AssistenzaUtentiAllegatiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AssistenzaUtentiAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AssistenzaUtentiAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)AssistenzaUtentiAllegatiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AssistenzaUtentiAllegatiCollectionObj.Count; i++)
				{
					if ((AssistenzaUtentiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssistenzaUtentiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssistenzaUtentiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AssistenzaUtentiAllegatiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((AssistenzaUtentiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AssistenzaUtentiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssistenzaUtentiAllegatiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj)
		{
			int returnValue = 0;
			if (AssistenzaUtentiAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, AssistenzaUtentiAllegatiObj.Id);
			}
			AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AssistenzaUtentiAllegatiObj.IsDirty = false;
			AssistenzaUtentiAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AssistenzaUtentiAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", AssistenzaUtentiAllegatiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AssistenzaUtentiAllegatiCollectionObj.Count; i++)
				{
					if ((AssistenzaUtentiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssistenzaUtentiAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssistenzaUtentiAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssistenzaUtentiAllegatiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiAllegatiCollectionObj[i].IsPersistent = false;
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
		public static AssistenzaUtentiAllegati GetById(DbProvider db, int IdValue)
		{
			AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAssistenzaUtentiAllegatiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AssistenzaUtentiAllegatiObj = GetFromDatareader(db);
				AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiAllegatiObj.IsDirty = false;
				AssistenzaUtentiAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return AssistenzaUtentiAllegatiObj;
		}

		//getFromDatareader
		public static AssistenzaUtentiAllegati GetFromDatareader(DbProvider db)
		{
			AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj = new AssistenzaUtentiAllegati();
			AssistenzaUtentiAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			AssistenzaUtentiAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			AssistenzaUtentiAllegatiObj.IdAssistenza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSISTENZA"]);
			AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AssistenzaUtentiAllegatiObj.IsDirty = false;
			AssistenzaUtentiAllegatiObj.IsPersistent = true;
			return AssistenzaUtentiAllegatiObj;
		}

		//Find Select

		public static AssistenzaUtentiAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdAssistenzaEqualThis)

		{

			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionObj = new AssistenzaUtentiAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zassistenzautentiallegatifindselect", new string[] {"Idequalthis", "IdAllegatoequalthis", "IdAssistenzaequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAssistenzaequalthis", IdAssistenzaEqualThis);
			AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssistenzaUtentiAllegatiObj = GetFromDatareader(db);
				AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiAllegatiObj.IsDirty = false;
				AssistenzaUtentiAllegatiObj.IsPersistent = true;
				AssistenzaUtentiAllegatiCollectionObj.Add(AssistenzaUtentiAllegatiObj);
			}
			db.Close();
			return AssistenzaUtentiAllegatiCollectionObj;
		}

		//Find Find

		public static AssistenzaUtentiAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdAssistenzaEqualThis)

		{

			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionObj = new AssistenzaUtentiAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zassistenzautentiallegatifindfind", new string[] {"IdAllegatoequalthis", "IdAssistenzaequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAssistenzaequalthis", IdAssistenzaEqualThis);
			AssistenzaUtentiAllegati AssistenzaUtentiAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssistenzaUtentiAllegatiObj = GetFromDatareader(db);
				AssistenzaUtentiAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiAllegatiObj.IsDirty = false;
				AssistenzaUtentiAllegatiObj.IsPersistent = true;
				AssistenzaUtentiAllegatiCollectionObj.Add(AssistenzaUtentiAllegatiObj);
			}
			db.Close();
			return AssistenzaUtentiAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AssistenzaUtentiAllegatiCollectionProvider:IAssistenzaUtentiAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssistenzaUtentiAllegatiCollectionProvider : IAssistenzaUtentiAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AssistenzaUtentiAllegati
		protected AssistenzaUtentiAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AssistenzaUtentiAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AssistenzaUtentiAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public AssistenzaUtentiAllegatiCollectionProvider(IntNT IdallegatoEqualThis, IntNT IdassistenzaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdallegatoEqualThis, IdassistenzaEqualThis);
		}

		//Costruttore3: ha in input assistenzautentiallegatiCollectionObj - non popola la collection
		public AssistenzaUtentiAllegatiCollectionProvider(AssistenzaUtentiAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AssistenzaUtentiAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AssistenzaUtentiAllegatiCollection(this);
		}

		//Get e Set
		public AssistenzaUtentiAllegatiCollection CollectionObj
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
		public int SaveCollection(AssistenzaUtentiAllegatiCollection collectionObj)
		{
			return AssistenzaUtentiAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AssistenzaUtentiAllegati assistenzautentiallegatiObj)
		{
			return AssistenzaUtentiAllegatiDAL.Save(_dbProviderObj, assistenzautentiallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AssistenzaUtentiAllegatiCollection collectionObj)
		{
			return AssistenzaUtentiAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AssistenzaUtentiAllegati assistenzautentiallegatiObj)
		{
			return AssistenzaUtentiAllegatiDAL.Delete(_dbProviderObj, assistenzautentiallegatiObj);
		}

		//getById
		public AssistenzaUtentiAllegati GetById(IntNT IdValue)
		{
			AssistenzaUtentiAllegati AssistenzaUtentiAllegatiTemp = AssistenzaUtentiAllegatiDAL.GetById(_dbProviderObj, IdValue);
			if (AssistenzaUtentiAllegatiTemp!=null) AssistenzaUtentiAllegatiTemp.Provider = this;
			return AssistenzaUtentiAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AssistenzaUtentiAllegatiCollection Select(IntNT IdEqualThis, IntNT IdallegatoEqualThis, IntNT IdassistenzaEqualThis)
		{
			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionTemp = AssistenzaUtentiAllegatiDAL.Select(_dbProviderObj, IdEqualThis, IdallegatoEqualThis, IdassistenzaEqualThis);
			AssistenzaUtentiAllegatiCollectionTemp.Provider = this;
			return AssistenzaUtentiAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public AssistenzaUtentiAllegatiCollection Find(IntNT IdallegatoEqualThis, IntNT IdassistenzaEqualThis)
		{
			AssistenzaUtentiAllegatiCollection AssistenzaUtentiAllegatiCollectionTemp = AssistenzaUtentiAllegatiDAL.Find(_dbProviderObj, IdallegatoEqualThis, IdassistenzaEqualThis);
			AssistenzaUtentiAllegatiCollectionTemp.Provider = this;
			return AssistenzaUtentiAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ASSISTENZA_UTENTI_ALLEGATI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
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
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
      <ID_ASSISTENZA>Equal</ID_ASSISTENZA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
      <ID_ASSISTENZA>Equal</ID_ASSISTENZA>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ASSISTENZA_UTENTI_ALLEGATI>
*/
