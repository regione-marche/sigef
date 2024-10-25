using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoPistaControllo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoPistaControlloProvider
	{
		int Save(TipoPistaControllo TipoPistaControlloObj);
		int SaveCollection(TipoPistaControlloCollection collectionObj);
		int Delete(TipoPistaControllo TipoPistaControlloObj);
		int DeleteCollection(TipoPistaControlloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoPistaControllo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoPistaControllo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTipoPistaControllo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _Livello;
		private NullTypes.IntNT _Ordine;
		private NullTypes.IntNT _IdPadre;
		[NonSerialized] private ITipoPistaControlloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoPistaControlloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoPistaControllo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TIPO_PISTA_CONTROLLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoPistaControllo
		{
			get { return _IdTipoPistaControllo; }
			set {
				if (IdTipoPistaControllo != value)
				{
					_IdTipoPistaControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:LIVELLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Livello
		{
			get { return _Livello; }
			set {
				if (Livello != value)
				{
					_Livello = value;
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

		/// <summary>
		/// Corrisponde al campo:ID_PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPadre
		{
			get { return _IdPadre; }
			set {
				if (IdPadre != value)
				{
					_IdPadre = value;
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
	/// Summary description for TipoPistaControlloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoPistaControlloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoPistaControlloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoPistaControllo) info.GetValue(i.ToString(),typeof(TipoPistaControllo)));
			}
		}

		//Costruttore
		public TipoPistaControlloCollection()
		{
			this.ItemType = typeof(TipoPistaControllo);
		}

		//Costruttore con provider
		public TipoPistaControlloCollection(ITipoPistaControlloProvider providerObj)
		{
			this.ItemType = typeof(TipoPistaControllo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoPistaControllo this[int index]
		{
			get { return (TipoPistaControllo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoPistaControlloCollection GetChanges()
		{
			return (TipoPistaControlloCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoPistaControlloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoPistaControlloProvider Provider
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
		public int Add(TipoPistaControllo TipoPistaControlloObj)
		{
			if (TipoPistaControlloObj.Provider == null) TipoPistaControlloObj.Provider = this.Provider;
			return base.Add(TipoPistaControlloObj);
		}

		//AddCollection
		public void AddCollection(TipoPistaControlloCollection TipoPistaControlloCollectionObj)
		{
			foreach (TipoPistaControllo TipoPistaControlloObj in TipoPistaControlloCollectionObj)
				this.Add(TipoPistaControlloObj);
		}

		//Insert
		public void Insert(int index, TipoPistaControllo TipoPistaControlloObj)
		{
			if (TipoPistaControlloObj.Provider == null) TipoPistaControlloObj.Provider = this.Provider;
			base.Insert(index, TipoPistaControlloObj);
		}

		//CollectionGetById
		public TipoPistaControllo CollectionGetById(NullTypes.IntNT IdTipoPistaControlloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTipoPistaControllo == IdTipoPistaControlloValue))
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
		public TipoPistaControlloCollection SubSelect(NullTypes.IntNT IdTipoPistaControlloEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT LivelloEqualThis, 
NullTypes.IntNT OrdineEqualThis, NullTypes.IntNT IdPadreEqualThis)
		{
			TipoPistaControlloCollection TipoPistaControlloCollectionTemp = new TipoPistaControlloCollection();
			foreach (TipoPistaControllo TipoPistaControlloItem in this)
			{
				if (((IdTipoPistaControlloEqualThis == null) || ((TipoPistaControlloItem.IdTipoPistaControllo != null) && (TipoPistaControlloItem.IdTipoPistaControllo.Value == IdTipoPistaControlloEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoPistaControlloItem.Descrizione != null) && (TipoPistaControlloItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((LivelloEqualThis == null) || ((TipoPistaControlloItem.Livello != null) && (TipoPistaControlloItem.Livello.Value == LivelloEqualThis.Value))) && 
((OrdineEqualThis == null) || ((TipoPistaControlloItem.Ordine != null) && (TipoPistaControlloItem.Ordine.Value == OrdineEqualThis.Value))) && ((IdPadreEqualThis == null) || ((TipoPistaControlloItem.IdPadre != null) && (TipoPistaControlloItem.IdPadre.Value == IdPadreEqualThis.Value))))
				{
					TipoPistaControlloCollectionTemp.Add(TipoPistaControlloItem);
				}
			}
			return TipoPistaControlloCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoPistaControlloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoPistaControlloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoPistaControllo TipoPistaControlloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTipoPistaControllo", TipoPistaControlloObj.IdTipoPistaControllo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoPistaControlloObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Livello", TipoPistaControlloObj.Livello);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", TipoPistaControlloObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPadre", TipoPistaControlloObj.IdPadre);
		}
		//Insert
		private static int Insert(DbProvider db, TipoPistaControllo TipoPistaControlloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoPistaControlloInsert", new string[] {"Descrizione", "Livello", 
"Ordine", "IdPadre"}, new string[] {"string", "int", 
"int", "int"},"");
				CompileIUCmd(false, insertCmd,TipoPistaControlloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TipoPistaControlloObj.IdTipoPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PISTA_CONTROLLO"]);
				}
				TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoPistaControlloObj.IsDirty = false;
				TipoPistaControlloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoPistaControllo TipoPistaControlloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoPistaControlloUpdate", new string[] {"IdTipoPistaControllo", "Descrizione", "Livello", 
"Ordine", "IdPadre"}, new string[] {"int", "string", "int", 
"int", "int"},"");
				CompileIUCmd(true, updateCmd,TipoPistaControlloObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoPistaControlloObj.IsDirty = false;
				TipoPistaControlloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoPistaControllo TipoPistaControlloObj)
		{
			switch (TipoPistaControlloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoPistaControlloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoPistaControlloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoPistaControlloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoPistaControlloCollection TipoPistaControlloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoPistaControlloUpdate", new string[] {"IdTipoPistaControllo", "Descrizione", "Livello", 
"Ordine", "IdPadre"}, new string[] {"int", "string", "int", 
"int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoPistaControlloInsert", new string[] {"Descrizione", "Livello", 
"Ordine", "IdPadre"}, new string[] {"string", "int", 
"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoPistaControlloDelete", new string[] {"IdTipoPistaControllo"}, new string[] {"int"},"");
				for (int i = 0; i < TipoPistaControlloCollectionObj.Count; i++)
				{
					switch (TipoPistaControlloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoPistaControlloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TipoPistaControlloCollectionObj[i].IdTipoPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PISTA_CONTROLLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoPistaControlloCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoPistaControlloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoPistaControllo", (SiarLibrary.NullTypes.IntNT)TipoPistaControlloCollectionObj[i].IdTipoPistaControllo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoPistaControlloCollectionObj.Count; i++)
				{
					if ((TipoPistaControlloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoPistaControlloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoPistaControlloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoPistaControlloCollectionObj[i].IsDirty = false;
						TipoPistaControlloCollectionObj[i].IsPersistent = true;
					}
					if ((TipoPistaControlloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoPistaControlloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoPistaControlloCollectionObj[i].IsDirty = false;
						TipoPistaControlloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoPistaControllo TipoPistaControlloObj)
		{
			int returnValue = 0;
			if (TipoPistaControlloObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoPistaControlloObj.IdTipoPistaControllo);
			}
			TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoPistaControlloObj.IsDirty = false;
			TipoPistaControlloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTipoPistaControlloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoPistaControlloDelete", new string[] {"IdTipoPistaControllo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoPistaControllo", (SiarLibrary.NullTypes.IntNT)IdTipoPistaControlloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoPistaControlloCollection TipoPistaControlloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoPistaControlloDelete", new string[] {"IdTipoPistaControllo"}, new string[] {"int"},"");
				for (int i = 0; i < TipoPistaControlloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoPistaControllo", TipoPistaControlloCollectionObj[i].IdTipoPistaControllo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoPistaControlloCollectionObj.Count; i++)
				{
					if ((TipoPistaControlloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoPistaControlloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoPistaControlloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoPistaControlloCollectionObj[i].IsDirty = false;
						TipoPistaControlloCollectionObj[i].IsPersistent = false;
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
		public static TipoPistaControllo GetById(DbProvider db, int IdTipoPistaControlloValue)
		{
			TipoPistaControllo TipoPistaControlloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoPistaControlloGetById", new string[] {"IdTipoPistaControllo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTipoPistaControllo", (SiarLibrary.NullTypes.IntNT)IdTipoPistaControlloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoPistaControlloObj = GetFromDatareader(db);
				TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoPistaControlloObj.IsDirty = false;
				TipoPistaControlloObj.IsPersistent = true;
			}
			db.Close();
			return TipoPistaControlloObj;
		}

		//getFromDatareader
		public static TipoPistaControllo GetFromDatareader(DbProvider db)
		{
			TipoPistaControllo TipoPistaControlloObj = new TipoPistaControllo();
			TipoPistaControlloObj.IdTipoPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PISTA_CONTROLLO"]);
			TipoPistaControlloObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoPistaControlloObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			TipoPistaControlloObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			TipoPistaControlloObj.IdPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PADRE"]);
			TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoPistaControlloObj.IsDirty = false;
			TipoPistaControlloObj.IsPersistent = true;
			return TipoPistaControlloObj;
		}

		//Find Select

		public static TipoPistaControlloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoPistaControlloEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.IntNT IdPadreEqualThis)

		{

			TipoPistaControlloCollection TipoPistaControlloCollectionObj = new TipoPistaControlloCollection();

			IDbCommand findCmd = db.InitCmd("Ztipopistacontrollofindselect", new string[] {"IdTipoPistaControlloequalthis", "Descrizioneequalthis", "Livelloequalthis", 
"Ordineequalthis", "IdPadreequalthis"}, new string[] {"int", "string", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloequalthis", IdTipoPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPadreequalthis", IdPadreEqualThis);
			TipoPistaControllo TipoPistaControlloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoPistaControlloObj = GetFromDatareader(db);
				TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoPistaControlloObj.IsDirty = false;
				TipoPistaControlloObj.IsPersistent = true;
				TipoPistaControlloCollectionObj.Add(TipoPistaControlloObj);
			}
			db.Close();
			return TipoPistaControlloCollectionObj;
		}

		//Find Find

		public static TipoPistaControlloCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoPistaControlloEqualThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.IntNT IdPadreEqualThis)

		{

			TipoPistaControlloCollection TipoPistaControlloCollectionObj = new TipoPistaControlloCollection();

			IDbCommand findCmd = db.InitCmd("Ztipopistacontrollofindfind", new string[] {"IdTipoPistaControlloequalthis", "Livelloequalthis", "IdPadreequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloequalthis", IdTipoPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPadreequalthis", IdPadreEqualThis);
			TipoPistaControllo TipoPistaControlloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoPistaControlloObj = GetFromDatareader(db);
				TipoPistaControlloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoPistaControlloObj.IsDirty = false;
				TipoPistaControlloObj.IsPersistent = true;
				TipoPistaControlloCollectionObj.Add(TipoPistaControlloObj);
			}
			db.Close();
			return TipoPistaControlloCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoPistaControlloCollectionProvider:ITipoPistaControlloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoPistaControlloCollectionProvider : ITipoPistaControlloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoPistaControllo
		protected TipoPistaControlloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoPistaControlloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoPistaControlloCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoPistaControlloCollectionProvider(IntNT IdtipopistacontrolloEqualThis, IntNT LivelloEqualThis, IntNT IdpadreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdtipopistacontrolloEqualThis, LivelloEqualThis, IdpadreEqualThis);
		}

		//Costruttore3: ha in input tipopistacontrolloCollectionObj - non popola la collection
		public TipoPistaControlloCollectionProvider(TipoPistaControlloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoPistaControlloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoPistaControlloCollection(this);
		}

		//Get e Set
		public TipoPistaControlloCollection CollectionObj
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
		public int SaveCollection(TipoPistaControlloCollection collectionObj)
		{
			return TipoPistaControlloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoPistaControllo tipopistacontrolloObj)
		{
			return TipoPistaControlloDAL.Save(_dbProviderObj, tipopistacontrolloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoPistaControlloCollection collectionObj)
		{
			return TipoPistaControlloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoPistaControllo tipopistacontrolloObj)
		{
			return TipoPistaControlloDAL.Delete(_dbProviderObj, tipopistacontrolloObj);
		}

		//getById
		public TipoPistaControllo GetById(IntNT IdTipoPistaControlloValue)
		{
			TipoPistaControllo TipoPistaControlloTemp = TipoPistaControlloDAL.GetById(_dbProviderObj, IdTipoPistaControlloValue);
			if (TipoPistaControlloTemp!=null) TipoPistaControlloTemp.Provider = this;
			return TipoPistaControlloTemp;
		}

		//Select: popola la collection
		public TipoPistaControlloCollection Select(IntNT IdtipopistacontrolloEqualThis, StringNT DescrizioneEqualThis, IntNT LivelloEqualThis, 
IntNT OrdineEqualThis, IntNT IdpadreEqualThis)
		{
			TipoPistaControlloCollection TipoPistaControlloCollectionTemp = TipoPistaControlloDAL.Select(_dbProviderObj, IdtipopistacontrolloEqualThis, DescrizioneEqualThis, LivelloEqualThis, 
OrdineEqualThis, IdpadreEqualThis);
			TipoPistaControlloCollectionTemp.Provider = this;
			return TipoPistaControlloCollectionTemp;
		}

		//Find: popola la collection
		public TipoPistaControlloCollection Find(IntNT IdtipopistacontrolloEqualThis, IntNT LivelloEqualThis, IntNT IdpadreEqualThis)
		{
			TipoPistaControlloCollection TipoPistaControlloCollectionTemp = TipoPistaControlloDAL.Find(_dbProviderObj, IdtipopistacontrolloEqualThis, LivelloEqualThis, IdpadreEqualThis);
			TipoPistaControlloCollectionTemp.Provider = this;
			return TipoPistaControlloCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_PISTA_CONTROLLO>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_TIPO_PISTA_CONTROLLO>Equal</ID_TIPO_PISTA_CONTROLLO>
      <LIVELLO>Equal</LIVELLO>
      <ID_PADRE>Equal</ID_PADRE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_PISTA_CONTROLLO>
*/
