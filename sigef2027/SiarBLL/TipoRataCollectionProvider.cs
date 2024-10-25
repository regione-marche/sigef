using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoRata
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoRataProvider
	{
		int Save(TipoRata TipoRataObj);
		int SaveCollection(TipoRataCollection collectionObj);
		int Delete(TipoRata TipoRataObj);
		int DeleteCollection(TipoRataCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoRata
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoRata: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTipoRata;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ITipoRataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoRataProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoRata()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TIPO_RATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoRata
		{
			get { return _IdTipoRata; }
			set {
				if (IdTipoRata != value)
				{
					_IdTipoRata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(80)
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
	/// Summary description for TipoRataCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoRataCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoRataCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoRata) info.GetValue(i.ToString(),typeof(TipoRata)));
			}
		}

		//Costruttore
		public TipoRataCollection()
		{
			this.ItemType = typeof(TipoRata);
		}

		//Costruttore con provider
		public TipoRataCollection(ITipoRataProvider providerObj)
		{
			this.ItemType = typeof(TipoRata);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoRata this[int index]
		{
			get { return (TipoRata)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoRataCollection GetChanges()
		{
			return (TipoRataCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoRataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoRataProvider Provider
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
		public int Add(TipoRata TipoRataObj)
		{
			if (TipoRataObj.Provider == null) TipoRataObj.Provider = this.Provider;
			return base.Add(TipoRataObj);
		}

		//AddCollection
		public void AddCollection(TipoRataCollection TipoRataCollectionObj)
		{
			foreach (TipoRata TipoRataObj in TipoRataCollectionObj)
				this.Add(TipoRataObj);
		}

		//Insert
		public void Insert(int index, TipoRata TipoRataObj)
		{
			if (TipoRataObj.Provider == null) TipoRataObj.Provider = this.Provider;
			base.Insert(index, TipoRataObj);
		}

		//CollectionGetById
		public TipoRata CollectionGetById(NullTypes.IntNT IdTipoRataValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTipoRata == IdTipoRataValue))
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
		public TipoRataCollection SubSelect(NullTypes.IntNT IdTipoRataEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			TipoRataCollection TipoRataCollectionTemp = new TipoRataCollection();
			foreach (TipoRata TipoRataItem in this)
			{
				if (((IdTipoRataEqualThis == null) || ((TipoRataItem.IdTipoRata != null) && (TipoRataItem.IdTipoRata.Value == IdTipoRataEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoRataItem.Descrizione != null) && (TipoRataItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					TipoRataCollectionTemp.Add(TipoRataItem);
				}
			}
			return TipoRataCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoRataDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoRataDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoRata TipoRataObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTipoRata", TipoRataObj.IdTipoRata);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoRataObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, TipoRata TipoRataObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoRataInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				CompileIUCmd(false, insertCmd,TipoRataObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TipoRataObj.IdTipoRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_RATA"]);
				}
				TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoRataObj.IsDirty = false;
				TipoRataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoRata TipoRataObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoRataUpdate", new string[] {"IdTipoRata", "Descrizione"}, new string[] {"int", "string"},"");
				CompileIUCmd(true, updateCmd,TipoRataObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoRataObj.IsDirty = false;
				TipoRataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoRata TipoRataObj)
		{
			switch (TipoRataObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoRataObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoRataObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoRataObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoRataCollection TipoRataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoRataUpdate", new string[] {"IdTipoRata", "Descrizione"}, new string[] {"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoRataInsert", new string[] {"Descrizione"}, new string[] {"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoRataDelete", new string[] {"IdTipoRata"}, new string[] {"int"},"");
				for (int i = 0; i < TipoRataCollectionObj.Count; i++)
				{
					switch (TipoRataCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoRataCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TipoRataCollectionObj[i].IdTipoRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_RATA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoRataCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoRataCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoRata", (SiarLibrary.NullTypes.IntNT)TipoRataCollectionObj[i].IdTipoRata);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoRataCollectionObj.Count; i++)
				{
					if ((TipoRataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoRataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoRataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoRataCollectionObj[i].IsDirty = false;
						TipoRataCollectionObj[i].IsPersistent = true;
					}
					if ((TipoRataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoRataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoRataCollectionObj[i].IsDirty = false;
						TipoRataCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoRata TipoRataObj)
		{
			int returnValue = 0;
			if (TipoRataObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoRataObj.IdTipoRata);
			}
			TipoRataObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoRataObj.IsDirty = false;
			TipoRataObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTipoRataValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoRataDelete", new string[] {"IdTipoRata"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoRata", (SiarLibrary.NullTypes.IntNT)IdTipoRataValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoRataCollection TipoRataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoRataDelete", new string[] {"IdTipoRata"}, new string[] {"int"},"");
				for (int i = 0; i < TipoRataCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoRata", TipoRataCollectionObj[i].IdTipoRata);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoRataCollectionObj.Count; i++)
				{
					if ((TipoRataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoRataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoRataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoRataCollectionObj[i].IsDirty = false;
						TipoRataCollectionObj[i].IsPersistent = false;
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
		public static TipoRata GetById(DbProvider db, int IdTipoRataValue)
		{
			TipoRata TipoRataObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoRataGetById", new string[] {"IdTipoRata"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTipoRata", (SiarLibrary.NullTypes.IntNT)IdTipoRataValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoRataObj = GetFromDatareader(db);
				TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoRataObj.IsDirty = false;
				TipoRataObj.IsPersistent = true;
			}
			db.Close();
			return TipoRataObj;
		}

		//getFromDatareader
		public static TipoRata GetFromDatareader(DbProvider db)
		{
			TipoRata TipoRataObj = new TipoRata();
			TipoRataObj.IdTipoRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_RATA"]);
			TipoRataObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoRataObj.IsDirty = false;
			TipoRataObj.IsPersistent = true;
			return TipoRataObj;
		}

		//Find Select

		public static TipoRataCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoRataEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			TipoRataCollection TipoRataCollectionObj = new TipoRataCollection();

			IDbCommand findCmd = db.InitCmd("Ztiporatafindselect", new string[] {"IdTipoRataequalthis", "Descrizioneequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoRataequalthis", IdTipoRataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			TipoRata TipoRataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoRataObj = GetFromDatareader(db);
				TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoRataObj.IsDirty = false;
				TipoRataObj.IsPersistent = true;
				TipoRataCollectionObj.Add(TipoRataObj);
			}
			db.Close();
			return TipoRataCollectionObj;
		}

		//Find Find

		public static TipoRataCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			TipoRataCollection TipoRataCollectionObj = new TipoRataCollection();

			IDbCommand findCmd = db.InitCmd("Ztiporatafindfind", new string[] {"Descrizionelikethis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			TipoRata TipoRataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoRataObj = GetFromDatareader(db);
				TipoRataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoRataObj.IsDirty = false;
				TipoRataObj.IsPersistent = true;
				TipoRataCollectionObj.Add(TipoRataObj);
			}
			db.Close();
			return TipoRataCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoRataCollectionProvider:ITipoRataProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoRataCollectionProvider : ITipoRataProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoRata
		protected TipoRataCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoRataCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoRataCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoRataCollectionProvider(StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(DescrizioneLikeThis);
		}

		//Costruttore3: ha in input tiporataCollectionObj - non popola la collection
		public TipoRataCollectionProvider(TipoRataCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoRataCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoRataCollection(this);
		}

		//Get e Set
		public TipoRataCollection CollectionObj
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
		public int SaveCollection(TipoRataCollection collectionObj)
		{
			return TipoRataDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoRata tiporataObj)
		{
			return TipoRataDAL.Save(_dbProviderObj, tiporataObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoRataCollection collectionObj)
		{
			return TipoRataDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoRata tiporataObj)
		{
			return TipoRataDAL.Delete(_dbProviderObj, tiporataObj);
		}

		//getById
		public TipoRata GetById(IntNT IdTipoRataValue)
		{
			TipoRata TipoRataTemp = TipoRataDAL.GetById(_dbProviderObj, IdTipoRataValue);
			if (TipoRataTemp!=null) TipoRataTemp.Provider = this;
			return TipoRataTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoRataCollection Select(IntNT IdtiporataEqualThis, StringNT DescrizioneEqualThis)
		{
			TipoRataCollection TipoRataCollectionTemp = TipoRataDAL.Select(_dbProviderObj, IdtiporataEqualThis, DescrizioneEqualThis);
			TipoRataCollectionTemp.Provider = this;
			return TipoRataCollectionTemp;
		}

		//Find: popola la collection
		public TipoRataCollection Find(StringNT DescrizioneLikeThis)
		{
			TipoRataCollection TipoRataCollectionTemp = TipoRataDAL.Find(_dbProviderObj, DescrizioneLikeThis);
			TipoRataCollectionTemp.Provider = this;
			return TipoRataCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_RATA>
  <ViewName>VTIPO_RATA</ViewName>
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
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_RATA>
*/
