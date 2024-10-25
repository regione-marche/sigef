using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoIntegrazioneDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoIntegrazioneDomandaProvider
	{
		int Save(TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj);
		int SaveCollection(TipoIntegrazioneDomandaCollection collectionObj);
		int Delete(TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj);
		int DeleteCollection(TipoIntegrazioneDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoIntegrazioneDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoIntegrazioneDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ITipoIntegrazioneDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoIntegrazioneDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoIntegrazioneDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(200)
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
	/// Summary description for TipoIntegrazioneDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoIntegrazioneDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoIntegrazioneDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoIntegrazioneDomanda) info.GetValue(i.ToString(),typeof(TipoIntegrazioneDomanda)));
			}
		}

		//Costruttore
		public TipoIntegrazioneDomandaCollection()
		{
			this.ItemType = typeof(TipoIntegrazioneDomanda);
		}

		//Costruttore con provider
		public TipoIntegrazioneDomandaCollection(ITipoIntegrazioneDomandaProvider providerObj)
		{
			this.ItemType = typeof(TipoIntegrazioneDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoIntegrazioneDomanda this[int index]
		{
			get { return (TipoIntegrazioneDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoIntegrazioneDomandaCollection GetChanges()
		{
			return (TipoIntegrazioneDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoIntegrazioneDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoIntegrazioneDomandaProvider Provider
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
		public int Add(TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			if (TipoIntegrazioneDomandaObj.Provider == null) TipoIntegrazioneDomandaObj.Provider = this.Provider;
			return base.Add(TipoIntegrazioneDomandaObj);
		}

		//AddCollection
		public void AddCollection(TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionObj)
		{
			foreach (TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj in TipoIntegrazioneDomandaCollectionObj)
				this.Add(TipoIntegrazioneDomandaObj);
		}

		//Insert
		public void Insert(int index, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			if (TipoIntegrazioneDomandaObj.Provider == null) TipoIntegrazioneDomandaObj.Provider = this.Provider;
			base.Insert(index, TipoIntegrazioneDomandaObj);
		}

		//CollectionGetById
		public TipoIntegrazioneDomanda CollectionGetById(NullTypes.StringNT CodTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodTipo == CodTipoValue))
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
		public TipoIntegrazioneDomandaCollection SubSelect(NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionTemp = new TipoIntegrazioneDomandaCollection();
			foreach (TipoIntegrazioneDomanda TipoIntegrazioneDomandaItem in this)
			{
				if (((CodTipoEqualThis == null) || ((TipoIntegrazioneDomandaItem.CodTipo != null) && (TipoIntegrazioneDomandaItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoIntegrazioneDomandaItem.Descrizione != null) && (TipoIntegrazioneDomandaItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					TipoIntegrazioneDomandaCollectionTemp.Add(TipoIntegrazioneDomandaItem);
				}
			}
			return TipoIntegrazioneDomandaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoIntegrazioneDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoIntegrazioneDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", TipoIntegrazioneDomandaObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoIntegrazioneDomandaObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoIntegrazioneDomandaInsert", new string[] {"CodTipo", "Descrizione"}, new string[] {"string", "string"},"");
				CompileIUCmd(false, insertCmd,TipoIntegrazioneDomandaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoIntegrazioneDomandaObj.IsDirty = false;
				TipoIntegrazioneDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoIntegrazioneDomandaUpdate", new string[] {"CodTipo", "Descrizione"}, new string[] {"string", "string"},"");
				CompileIUCmd(true, updateCmd,TipoIntegrazioneDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoIntegrazioneDomandaObj.IsDirty = false;
				TipoIntegrazioneDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			switch (TipoIntegrazioneDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoIntegrazioneDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoIntegrazioneDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoIntegrazioneDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoIntegrazioneDomandaUpdate", new string[] {"CodTipo", "Descrizione"}, new string[] {"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoIntegrazioneDomandaInsert", new string[] {"CodTipo", "Descrizione"}, new string[] {"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoIntegrazioneDomandaDelete", new string[] {"CodTipo"}, new string[] {"string"},"");
				for (int i = 0; i < TipoIntegrazioneDomandaCollectionObj.Count; i++)
				{
					switch (TipoIntegrazioneDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoIntegrazioneDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoIntegrazioneDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoIntegrazioneDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)TipoIntegrazioneDomandaCollectionObj[i].CodTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoIntegrazioneDomandaCollectionObj.Count; i++)
				{
					if ((TipoIntegrazioneDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoIntegrazioneDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoIntegrazioneDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoIntegrazioneDomandaCollectionObj[i].IsDirty = false;
						TipoIntegrazioneDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((TipoIntegrazioneDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoIntegrazioneDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoIntegrazioneDomandaCollectionObj[i].IsDirty = false;
						TipoIntegrazioneDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj)
		{
			int returnValue = 0;
			if (TipoIntegrazioneDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoIntegrazioneDomandaObj.CodTipo);
			}
			TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoIntegrazioneDomandaObj.IsDirty = false;
			TipoIntegrazioneDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoIntegrazioneDomandaDelete", new string[] {"CodTipo"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoIntegrazioneDomandaDelete", new string[] {"CodTipo"}, new string[] {"string"},"");
				for (int i = 0; i < TipoIntegrazioneDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", TipoIntegrazioneDomandaCollectionObj[i].CodTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoIntegrazioneDomandaCollectionObj.Count; i++)
				{
					if ((TipoIntegrazioneDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoIntegrazioneDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoIntegrazioneDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoIntegrazioneDomandaCollectionObj[i].IsDirty = false;
						TipoIntegrazioneDomandaCollectionObj[i].IsPersistent = false;
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
		public static TipoIntegrazioneDomanda GetById(DbProvider db, string CodTipoValue)
		{
			TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoIntegrazioneDomandaGetById", new string[] {"CodTipo"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoIntegrazioneDomandaObj = GetFromDatareader(db);
				TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoIntegrazioneDomandaObj.IsDirty = false;
				TipoIntegrazioneDomandaObj.IsPersistent = true;
			}
			db.Close();
			return TipoIntegrazioneDomandaObj;
		}

		//getFromDatareader
		public static TipoIntegrazioneDomanda GetFromDatareader(DbProvider db)
		{
			TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj = new TipoIntegrazioneDomanda();
			TipoIntegrazioneDomandaObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			TipoIntegrazioneDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoIntegrazioneDomandaObj.IsDirty = false;
			TipoIntegrazioneDomandaObj.IsPersistent = true;
			return TipoIntegrazioneDomandaObj;
		}

		//Find Select

		public static TipoIntegrazioneDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionObj = new TipoIntegrazioneDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Ztipointegrazionedomandafindselect", new string[] {"CodTipoequalthis", "Descrizioneequalthis"}, new string[] {"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoIntegrazioneDomandaObj = GetFromDatareader(db);
				TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoIntegrazioneDomandaObj.IsDirty = false;
				TipoIntegrazioneDomandaObj.IsPersistent = true;
				TipoIntegrazioneDomandaCollectionObj.Add(TipoIntegrazioneDomandaObj);
			}
			db.Close();
			return TipoIntegrazioneDomandaCollectionObj;
		}

		//Find Find

		public static TipoIntegrazioneDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionObj = new TipoIntegrazioneDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Ztipointegrazionedomandafindfind", new string[] {"CodTipoequalthis", "Descrizioneequalthis"}, new string[] {"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			TipoIntegrazioneDomanda TipoIntegrazioneDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoIntegrazioneDomandaObj = GetFromDatareader(db);
				TipoIntegrazioneDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoIntegrazioneDomandaObj.IsDirty = false;
				TipoIntegrazioneDomandaObj.IsPersistent = true;
				TipoIntegrazioneDomandaCollectionObj.Add(TipoIntegrazioneDomandaObj);
			}
			db.Close();
			return TipoIntegrazioneDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoIntegrazioneDomandaCollectionProvider:ITipoIntegrazioneDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoIntegrazioneDomandaCollectionProvider : ITipoIntegrazioneDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoIntegrazioneDomanda
		protected TipoIntegrazioneDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoIntegrazioneDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoIntegrazioneDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoIntegrazioneDomandaCollectionProvider(StringNT CodtipoEqualThis, StringNT DescrizioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoEqualThis, DescrizioneEqualThis);
		}

		//Costruttore3: ha in input tipointegrazionedomandaCollectionObj - non popola la collection
		public TipoIntegrazioneDomandaCollectionProvider(TipoIntegrazioneDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoIntegrazioneDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoIntegrazioneDomandaCollection(this);
		}

		//Get e Set
		public TipoIntegrazioneDomandaCollection CollectionObj
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
		public int SaveCollection(TipoIntegrazioneDomandaCollection collectionObj)
		{
			return TipoIntegrazioneDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoIntegrazioneDomanda tipointegrazionedomandaObj)
		{
			return TipoIntegrazioneDomandaDAL.Save(_dbProviderObj, tipointegrazionedomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoIntegrazioneDomandaCollection collectionObj)
		{
			return TipoIntegrazioneDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoIntegrazioneDomanda tipointegrazionedomandaObj)
		{
			return TipoIntegrazioneDomandaDAL.Delete(_dbProviderObj, tipointegrazionedomandaObj);
		}

		//getById
		public TipoIntegrazioneDomanda GetById(StringNT CodTipoValue)
		{
			TipoIntegrazioneDomanda TipoIntegrazioneDomandaTemp = TipoIntegrazioneDomandaDAL.GetById(_dbProviderObj, CodTipoValue);
			if (TipoIntegrazioneDomandaTemp!=null) TipoIntegrazioneDomandaTemp.Provider = this;
			return TipoIntegrazioneDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoIntegrazioneDomandaCollection Select(StringNT CodtipoEqualThis, StringNT DescrizioneEqualThis)
		{
			TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionTemp = TipoIntegrazioneDomandaDAL.Select(_dbProviderObj, CodtipoEqualThis, DescrizioneEqualThis);
			TipoIntegrazioneDomandaCollectionTemp.Provider = this;
			return TipoIntegrazioneDomandaCollectionTemp;
		}

		//Find: popola la collection
		public TipoIntegrazioneDomandaCollection Find(StringNT CodtipoEqualThis, StringNT DescrizioneEqualThis)
		{
			TipoIntegrazioneDomandaCollection TipoIntegrazioneDomandaCollectionTemp = TipoIntegrazioneDomandaDAL.Find(_dbProviderObj, CodtipoEqualThis, DescrizioneEqualThis);
			TipoIntegrazioneDomandaCollectionTemp.Provider = this;
			return TipoIntegrazioneDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_INTEGRAZIONE_DOMANDA>
  <ViewName>VTIPO_INTEGRAZIONE_DOMANDA</ViewName>
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
      <COD_TIPO>Equal</COD_TIPO>
      <DESCRIZIONE>Equal</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_INTEGRAZIONE_DOMANDA>
*/
