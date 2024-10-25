using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoValutatori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoValutatoriProvider
	{
		int Save(ProgettoValutatori ProgettoValutatoriObj);
		int SaveCollection(ProgettoValutatoriCollection collectionObj);
		int Delete(ProgettoValutatori ProgettoValutatoriObj);
		int DeleteCollection(ProgettoValutatoriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoValutatori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoValutatori: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgettoValutazione;
		private NullTypes.IntNT _IdValutatore;
		private NullTypes.BoolNT _Presente;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IProgettoValutatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutatoriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoValutatori()
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
		/// Corrisponde al campo:ID_PROGETTO_VALUTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoValutazione
		{
			get { return _IdProgettoValutazione; }
			set {
				if (IdProgettoValutazione != value)
				{
					_IdProgettoValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VALUTATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValutatore
		{
			get { return _IdValutatore; }
			set {
				if (IdValutatore != value)
				{
					_IdValutatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRESENTE
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT Presente
		{
			get { return _Presente; }
			set {
				if (Presente != value)
				{
					_Presente = value;
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
	/// Summary description for ProgettoValutatoriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoValutatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoValutatori) info.GetValue(i.ToString(),typeof(ProgettoValutatori)));
			}
		}

		//Costruttore
		public ProgettoValutatoriCollection()
		{
			this.ItemType = typeof(ProgettoValutatori);
		}

		//Costruttore con provider
		public ProgettoValutatoriCollection(IProgettoValutatoriProvider providerObj)
		{
			this.ItemType = typeof(ProgettoValutatori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoValutatori this[int index]
		{
			get { return (ProgettoValutatori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoValutatoriCollection GetChanges()
		{
			return (ProgettoValutatoriCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoValutatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutatoriProvider Provider
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
		public int Add(ProgettoValutatori ProgettoValutatoriObj)
		{
			if (ProgettoValutatoriObj.Provider == null) ProgettoValutatoriObj.Provider = this.Provider;
			return base.Add(ProgettoValutatoriObj);
		}

		//AddCollection
		public void AddCollection(ProgettoValutatoriCollection ProgettoValutatoriCollectionObj)
		{
			foreach (ProgettoValutatori ProgettoValutatoriObj in ProgettoValutatoriCollectionObj)
				this.Add(ProgettoValutatoriObj);
		}

		//Insert
		public void Insert(int index, ProgettoValutatori ProgettoValutatoriObj)
		{
			if (ProgettoValutatoriObj.Provider == null) ProgettoValutatoriObj.Provider = this.Provider;
			base.Insert(index, ProgettoValutatoriObj);
		}

		//CollectionGetById
		public ProgettoValutatori CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoValutatoriCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoValutazioneEqualThis, NullTypes.IntNT IdValutatoreEqualThis, 
NullTypes.BoolNT PresenteEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			ProgettoValutatoriCollection ProgettoValutatoriCollectionTemp = new ProgettoValutatoriCollection();
			foreach (ProgettoValutatori ProgettoValutatoriItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoValutatoriItem.Id != null) && (ProgettoValutatoriItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoValutazioneEqualThis == null) || ((ProgettoValutatoriItem.IdProgettoValutazione != null) && (ProgettoValutatoriItem.IdProgettoValutazione.Value == IdProgettoValutazioneEqualThis.Value))) && ((IdValutatoreEqualThis == null) || ((ProgettoValutatoriItem.IdValutatore != null) && (ProgettoValutatoriItem.IdValutatore.Value == IdValutatoreEqualThis.Value))) && 
((PresenteEqualThis == null) || ((ProgettoValutatoriItem.Presente != null) && (ProgettoValutatoriItem.Presente.Value == PresenteEqualThis.Value))) && ((OrdineEqualThis == null) || ((ProgettoValutatoriItem.Ordine != null) && (ProgettoValutatoriItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					ProgettoValutatoriCollectionTemp.Add(ProgettoValutatoriItem);
				}
			}
			return ProgettoValutatoriCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoValutatoriCollection Filter(NullTypes.IntNT IdValutatoreEqualThis, NullTypes.BoolNT PresenteEqualThis)
		{
			ProgettoValutatoriCollection ProgettoValutatoriCollectionTemp = new ProgettoValutatoriCollection();
			foreach (ProgettoValutatori ProgettoValutatoriItem in this)
			{
				if (((IdValutatoreEqualThis == null) || ((ProgettoValutatoriItem.IdValutatore != null) && (ProgettoValutatoriItem.IdValutatore.Value == IdValutatoreEqualThis.Value))) && ((PresenteEqualThis == null) || ((ProgettoValutatoriItem.Presente != null) && (ProgettoValutatoriItem.Presente.Value == PresenteEqualThis.Value))))
				{
					ProgettoValutatoriCollectionTemp.Add(ProgettoValutatoriItem);
				}
			}
			return ProgettoValutatoriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoValutatoriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoValutatoriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoValutatori ProgettoValutatoriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoValutatoriObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoValutazione", ProgettoValutatoriObj.IdProgettoValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValutatore", ProgettoValutatoriObj.IdValutatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Presente", ProgettoValutatoriObj.Presente);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", ProgettoValutatoriObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoValutatori ProgettoValutatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutatoriInsert", new string[] {"IdProgettoValutazione", "IdValutatore", 
"Presente", "Ordine"}, new string[] {"int", "int", 
"bool", "int"},"");
				CompileIUCmd(false, insertCmd,ProgettoValutatoriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoValutatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ProgettoValutatoriObj.Presente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRESENTE"]);
				}
				ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutatoriObj.IsDirty = false;
				ProgettoValutatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoValutatori ProgettoValutatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutatoriUpdate", new string[] {"Id", "IdProgettoValutazione", "IdValutatore", 
"Presente", "Ordine"}, new string[] {"int", "int", "int", 
"bool", "int"},"");
				CompileIUCmd(true, updateCmd,ProgettoValutatoriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutatoriObj.IsDirty = false;
				ProgettoValutatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoValutatori ProgettoValutatoriObj)
		{
			switch (ProgettoValutatoriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoValutatoriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoValutatoriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoValutatoriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoValutatoriCollection ProgettoValutatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutatoriUpdate", new string[] {"Id", "IdProgettoValutazione", "IdValutatore", 
"Presente", "Ordine"}, new string[] {"int", "int", "int", 
"bool", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutatoriInsert", new string[] {"IdProgettoValutazione", "IdValutatore", 
"Presente", "Ordine"}, new string[] {"int", "int", 
"bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutatoriCollectionObj.Count; i++)
				{
					switch (ProgettoValutatoriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoValutatoriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoValutatoriCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ProgettoValutatoriCollectionObj[i].Presente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRESENTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoValutatoriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoValutatoriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoValutatoriCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutatoriCollectionObj.Count; i++)
				{
					if ((ProgettoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoValutatoriCollectionObj[i].IsDirty = false;
						ProgettoValutatoriCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutatoriCollectionObj[i].IsDirty = false;
						ProgettoValutatoriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoValutatori ProgettoValutatoriObj)
		{
			int returnValue = 0;
			if (ProgettoValutatoriObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoValutatoriObj.Id);
			}
			ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoValutatoriObj.IsDirty = false;
			ProgettoValutatoriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoValutatoriCollection ProgettoValutatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutatoriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoValutatoriCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutatoriCollectionObj.Count; i++)
				{
					if ((ProgettoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutatoriCollectionObj[i].IsDirty = false;
						ProgettoValutatoriCollectionObj[i].IsPersistent = false;
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
		public static ProgettoValutatori GetById(DbProvider db, int IdValue)
		{
			ProgettoValutatori ProgettoValutatoriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoValutatoriGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoValutatoriObj = GetFromDatareader(db);
				ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutatoriObj.IsDirty = false;
				ProgettoValutatoriObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoValutatoriObj;
		}

		//getFromDatareader
		public static ProgettoValutatori GetFromDatareader(DbProvider db)
		{
			ProgettoValutatori ProgettoValutatoriObj = new ProgettoValutatori();
			ProgettoValutatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoValutatoriObj.IdProgettoValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_VALUTAZIONE"]);
			ProgettoValutatoriObj.IdValutatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALUTATORE"]);
			ProgettoValutatoriObj.Presente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRESENTE"]);
			ProgettoValutatoriObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoValutatoriObj.IsDirty = false;
			ProgettoValutatoriObj.IsPersistent = true;
			return ProgettoValutatoriObj;
		}

		//Find Select

		public static ProgettoValutatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdValutatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT PresenteEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			ProgettoValutatoriCollection ProgettoValutatoriCollectionObj = new ProgettoValutatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutatorifindselect", new string[] {"Idequalthis", "IdProgettoValutazioneequalthis", "IdValutatoreequalthis", 
"Presenteequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoValutazioneequalthis", IdProgettoValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutatoreequalthis", IdValutatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Presenteequalthis", PresenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			ProgettoValutatori ProgettoValutatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutatoriObj = GetFromDatareader(db);
				ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutatoriObj.IsDirty = false;
				ProgettoValutatoriObj.IsPersistent = true;
				ProgettoValutatoriCollectionObj.Add(ProgettoValutatoriObj);
			}
			db.Close();
			return ProgettoValutatoriCollectionObj;
		}

		//Find Find

		public static ProgettoValutatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdValutatoreEqualThis)

		{

			ProgettoValutatoriCollection ProgettoValutatoriCollectionObj = new ProgettoValutatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutatorifindfind", new string[] {"IdProgettoValutazioneequalthis", "IdValutatoreequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoValutazioneequalthis", IdProgettoValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutatoreequalthis", IdValutatoreEqualThis);
			ProgettoValutatori ProgettoValutatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutatoriObj = GetFromDatareader(db);
				ProgettoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutatoriObj.IsDirty = false;
				ProgettoValutatoriObj.IsPersistent = true;
				ProgettoValutatoriCollectionObj.Add(ProgettoValutatoriObj);
			}
			db.Close();
			return ProgettoValutatoriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoValutatoriCollectionProvider:IProgettoValutatoriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutatoriCollectionProvider : IProgettoValutatoriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoValutatori
		protected ProgettoValutatoriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoValutatoriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoValutatoriCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoValutatoriCollectionProvider(IntNT IdprogettovalutazioneEqualThis, IntNT IdvalutatoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettovalutazioneEqualThis, IdvalutatoreEqualThis);
		}

		//Costruttore3: ha in input progettovalutatoriCollectionObj - non popola la collection
		public ProgettoValutatoriCollectionProvider(ProgettoValutatoriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoValutatoriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoValutatoriCollection(this);
		}

		//Get e Set
		public ProgettoValutatoriCollection CollectionObj
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
		public int SaveCollection(ProgettoValutatoriCollection collectionObj)
		{
			return ProgettoValutatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoValutatori progettovalutatoriObj)
		{
			return ProgettoValutatoriDAL.Save(_dbProviderObj, progettovalutatoriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoValutatoriCollection collectionObj)
		{
			return ProgettoValutatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoValutatori progettovalutatoriObj)
		{
			return ProgettoValutatoriDAL.Delete(_dbProviderObj, progettovalutatoriObj);
		}

		//getById
		public ProgettoValutatori GetById(IntNT IdValue)
		{
			ProgettoValutatori ProgettoValutatoriTemp = ProgettoValutatoriDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoValutatoriTemp!=null) ProgettoValutatoriTemp.Provider = this;
			return ProgettoValutatoriTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoValutatoriCollection Select(IntNT IdEqualThis, IntNT IdprogettovalutazioneEqualThis, IntNT IdvalutatoreEqualThis, 
BoolNT PresenteEqualThis, IntNT OrdineEqualThis)
		{
			ProgettoValutatoriCollection ProgettoValutatoriCollectionTemp = ProgettoValutatoriDAL.Select(_dbProviderObj, IdEqualThis, IdprogettovalutazioneEqualThis, IdvalutatoreEqualThis, 
PresenteEqualThis, OrdineEqualThis);
			ProgettoValutatoriCollectionTemp.Provider = this;
			return ProgettoValutatoriCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoValutatoriCollection Find(IntNT IdprogettovalutazioneEqualThis, IntNT IdvalutatoreEqualThis)
		{
			ProgettoValutatoriCollection ProgettoValutatoriCollectionTemp = ProgettoValutatoriDAL.Find(_dbProviderObj, IdprogettovalutazioneEqualThis, IdvalutatoreEqualThis);
			ProgettoValutatoriCollectionTemp.Provider = this;
			return ProgettoValutatoriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_VALUTATORI>
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
      <ID_PROGETTO_VALUTAZIONE>Equal</ID_PROGETTO_VALUTAZIONE>
      <ID_VALUTATORE>Equal</ID_VALUTATORE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_VALUTATORE>Equal</ID_VALUTATORE>
      <PRESENTE>Equal</PRESENTE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_VALUTATORI>
*/
