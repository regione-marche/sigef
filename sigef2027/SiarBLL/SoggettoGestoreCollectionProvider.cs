using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SoggettoGestore
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISoggettoGestoreProvider
	{
		int Save(SoggettoGestore SoggettoGestoreObj);
		int SaveCollection(SoggettoGestoreCollection collectionObj);
		int Delete(SoggettoGestore SoggettoGestoreObj);
		int DeleteCollection(SoggettoGestoreCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SoggettoGestore
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SoggettoGestore: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSoggettoGestore;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _DenominazioneSoggettoGestore;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		[NonSerialized] private ISoggettoGestoreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISoggettoGestoreProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SoggettoGestore()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SOGGETTO_GESTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSoggettoGestore
		{
			get { return _IdSoggettoGestore; }
			set {
				if (IdSoggettoGestore != value)
				{
					_IdSoggettoGestore = value;
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

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE_SOGGETTO_GESTORE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DenominazioneSoggettoGestore
		{
			get { return _DenominazioneSoggettoGestore; }
			set {
				if (DenominazioneSoggettoGestore != value)
				{
					_DenominazioneSoggettoGestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
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
	/// Summary description for SoggettoGestoreCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SoggettoGestoreCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SoggettoGestoreCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SoggettoGestore) info.GetValue(i.ToString(),typeof(SoggettoGestore)));
			}
		}

		//Costruttore
		public SoggettoGestoreCollection()
		{
			this.ItemType = typeof(SoggettoGestore);
		}

		//Costruttore con provider
		public SoggettoGestoreCollection(ISoggettoGestoreProvider providerObj)
		{
			this.ItemType = typeof(SoggettoGestore);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SoggettoGestore this[int index]
		{
			get { return (SoggettoGestore)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SoggettoGestoreCollection GetChanges()
		{
			return (SoggettoGestoreCollection) base.GetChanges();
		}

		[NonSerialized] private ISoggettoGestoreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISoggettoGestoreProvider Provider
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
		public int Add(SoggettoGestore SoggettoGestoreObj)
		{
			if (SoggettoGestoreObj.Provider == null) SoggettoGestoreObj.Provider = this.Provider;
			return base.Add(SoggettoGestoreObj);
		}

		//AddCollection
		public void AddCollection(SoggettoGestoreCollection SoggettoGestoreCollectionObj)
		{
			foreach (SoggettoGestore SoggettoGestoreObj in SoggettoGestoreCollectionObj)
				this.Add(SoggettoGestoreObj);
		}

		//Insert
		public void Insert(int index, SoggettoGestore SoggettoGestoreObj)
		{
			if (SoggettoGestoreObj.Provider == null) SoggettoGestoreObj.Provider = this.Provider;
			base.Insert(index, SoggettoGestoreObj);
		}

		//CollectionGetById
		public SoggettoGestore CollectionGetById(NullTypes.IntNT IdSoggettoGestoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSoggettoGestore == IdSoggettoGestoreValue))
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
		public SoggettoGestoreCollection SubSelect(NullTypes.IntNT IdSoggettoGestoreEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT DenominazioneSoggettoGestoreEqualThis)
		{
			SoggettoGestoreCollection SoggettoGestoreCollectionTemp = new SoggettoGestoreCollection();
			foreach (SoggettoGestore SoggettoGestoreItem in this)
			{
				if (((IdSoggettoGestoreEqualThis == null) || ((SoggettoGestoreItem.IdSoggettoGestore != null) && (SoggettoGestoreItem.IdSoggettoGestore.Value == IdSoggettoGestoreEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((SoggettoGestoreItem.IdImpresa != null) && (SoggettoGestoreItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((DenominazioneSoggettoGestoreEqualThis == null) || ((SoggettoGestoreItem.DenominazioneSoggettoGestore != null) && (SoggettoGestoreItem.DenominazioneSoggettoGestore.Value == DenominazioneSoggettoGestoreEqualThis.Value))))
				{
					SoggettoGestoreCollectionTemp.Add(SoggettoGestoreItem);
				}
			}
			return SoggettoGestoreCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SoggettoGestoreDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SoggettoGestoreDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SoggettoGestore SoggettoGestoreObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSoggettoGestore", SoggettoGestoreObj.IdSoggettoGestore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", SoggettoGestoreObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "DenominazioneSoggettoGestore", SoggettoGestoreObj.DenominazioneSoggettoGestore);
		}
		//Insert
		private static int Insert(DbProvider db, SoggettoGestore SoggettoGestoreObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSoggettoGestoreInsert", new string[] {"IdImpresa", "DenominazioneSoggettoGestore", }, new string[] {"int", "string", },"");
				CompileIUCmd(false, insertCmd,SoggettoGestoreObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SoggettoGestoreObj.IdSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOGGETTO_GESTORE"]);
				}
				SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SoggettoGestoreObj.IsDirty = false;
				SoggettoGestoreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SoggettoGestore SoggettoGestoreObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSoggettoGestoreUpdate", new string[] {"IdSoggettoGestore", "IdImpresa", "DenominazioneSoggettoGestore", }, new string[] {"int", "int", "string", },"");
				CompileIUCmd(true, updateCmd,SoggettoGestoreObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SoggettoGestoreObj.IsDirty = false;
				SoggettoGestoreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SoggettoGestore SoggettoGestoreObj)
		{
			switch (SoggettoGestoreObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SoggettoGestoreObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SoggettoGestoreObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SoggettoGestoreObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SoggettoGestoreCollection SoggettoGestoreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSoggettoGestoreUpdate", new string[] {"IdSoggettoGestore", "IdImpresa", "DenominazioneSoggettoGestore", }, new string[] {"int", "int", "string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZSoggettoGestoreInsert", new string[] {"IdImpresa", "DenominazioneSoggettoGestore", }, new string[] {"int", "string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZSoggettoGestoreDelete", new string[] {"IdSoggettoGestore"}, new string[] {"int"},"");
				for (int i = 0; i < SoggettoGestoreCollectionObj.Count; i++)
				{
					switch (SoggettoGestoreCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SoggettoGestoreCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SoggettoGestoreCollectionObj[i].IdSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOGGETTO_GESTORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SoggettoGestoreCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SoggettoGestoreCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSoggettoGestore", (SiarLibrary.NullTypes.IntNT)SoggettoGestoreCollectionObj[i].IdSoggettoGestore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SoggettoGestoreCollectionObj.Count; i++)
				{
					if ((SoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SoggettoGestoreCollectionObj[i].IsDirty = false;
						SoggettoGestoreCollectionObj[i].IsPersistent = true;
					}
					if ((SoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SoggettoGestoreCollectionObj[i].IsDirty = false;
						SoggettoGestoreCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SoggettoGestore SoggettoGestoreObj)
		{
			int returnValue = 0;
			if (SoggettoGestoreObj.IsPersistent) 
			{
				returnValue = Delete(db, SoggettoGestoreObj.IdSoggettoGestore);
			}
			SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SoggettoGestoreObj.IsDirty = false;
			SoggettoGestoreObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSoggettoGestoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSoggettoGestoreDelete", new string[] {"IdSoggettoGestore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSoggettoGestore", (SiarLibrary.NullTypes.IntNT)IdSoggettoGestoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SoggettoGestoreCollection SoggettoGestoreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSoggettoGestoreDelete", new string[] {"IdSoggettoGestore"}, new string[] {"int"},"");
				for (int i = 0; i < SoggettoGestoreCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSoggettoGestore", SoggettoGestoreCollectionObj[i].IdSoggettoGestore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SoggettoGestoreCollectionObj.Count; i++)
				{
					if ((SoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SoggettoGestoreCollectionObj[i].IsDirty = false;
						SoggettoGestoreCollectionObj[i].IsPersistent = false;
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
		public static SoggettoGestore GetById(DbProvider db, int IdSoggettoGestoreValue)
		{
			SoggettoGestore SoggettoGestoreObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSoggettoGestoreGetById", new string[] {"IdSoggettoGestore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSoggettoGestore", (SiarLibrary.NullTypes.IntNT)IdSoggettoGestoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SoggettoGestoreObj = GetFromDatareader(db);
				SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SoggettoGestoreObj.IsDirty = false;
				SoggettoGestoreObj.IsPersistent = true;
			}
			db.Close();
			return SoggettoGestoreObj;
		}

		//getFromDatareader
		public static SoggettoGestore GetFromDatareader(DbProvider db)
		{
			SoggettoGestore SoggettoGestoreObj = new SoggettoGestore();
			SoggettoGestoreObj.IdSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOGGETTO_GESTORE"]);
			SoggettoGestoreObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			SoggettoGestoreObj.DenominazioneSoggettoGestore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE_SOGGETTO_GESTORE"]);
			SoggettoGestoreObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			SoggettoGestoreObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			SoggettoGestoreObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SoggettoGestoreObj.IsDirty = false;
			SoggettoGestoreObj.IsPersistent = true;
			return SoggettoGestoreObj;
		}

		//Find Select

		public static SoggettoGestoreCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneSoggettoGestoreEqualThis)

		{

			SoggettoGestoreCollection SoggettoGestoreCollectionObj = new SoggettoGestoreCollection();

			IDbCommand findCmd = db.InitCmd("Zsoggettogestorefindselect", new string[] {"IdSoggettoGestoreequalthis", "IdImpresaequalthis", "DenominazioneSoggettoGestoreequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DenominazioneSoggettoGestoreequalthis", DenominazioneSoggettoGestoreEqualThis);
			SoggettoGestore SoggettoGestoreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SoggettoGestoreObj = GetFromDatareader(db);
				SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SoggettoGestoreObj.IsDirty = false;
				SoggettoGestoreObj.IsPersistent = true;
				SoggettoGestoreCollectionObj.Add(SoggettoGestoreObj);
			}
			db.Close();
			return SoggettoGestoreCollectionObj;
		}

		//Find FindSoggettoGestore

		public static SoggettoGestoreCollection FindSoggettoGestore(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis)

		{

			SoggettoGestoreCollection SoggettoGestoreCollectionObj = new SoggettoGestoreCollection();

			IDbCommand findCmd = db.InitCmd("Zsoggettogestorefindfindsoggettogestore", new string[] {"IdImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			SoggettoGestore SoggettoGestoreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SoggettoGestoreObj = GetFromDatareader(db);
				SoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SoggettoGestoreObj.IsDirty = false;
				SoggettoGestoreObj.IsPersistent = true;
				SoggettoGestoreCollectionObj.Add(SoggettoGestoreObj);
			}
			db.Close();
			return SoggettoGestoreCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SoggettoGestoreCollectionProvider:ISoggettoGestoreProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SoggettoGestoreCollectionProvider : ISoggettoGestoreProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SoggettoGestore
		protected SoggettoGestoreCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SoggettoGestoreCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SoggettoGestoreCollection(this);
		}

		//Costruttore 2: popola la collection
		public SoggettoGestoreCollectionProvider(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindSoggettoGestore(IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis);
		}

		//Costruttore3: ha in input soggettogestoreCollectionObj - non popola la collection
		public SoggettoGestoreCollectionProvider(SoggettoGestoreCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SoggettoGestoreCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SoggettoGestoreCollection(this);
		}

		//Get e Set
		public SoggettoGestoreCollection CollectionObj
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
		public int SaveCollection(SoggettoGestoreCollection collectionObj)
		{
			return SoggettoGestoreDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SoggettoGestore soggettogestoreObj)
		{
			return SoggettoGestoreDAL.Save(_dbProviderObj, soggettogestoreObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SoggettoGestoreCollection collectionObj)
		{
			return SoggettoGestoreDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SoggettoGestore soggettogestoreObj)
		{
			return SoggettoGestoreDAL.Delete(_dbProviderObj, soggettogestoreObj);
		}

		//getById
		public SoggettoGestore GetById(IntNT IdSoggettoGestoreValue)
		{
			SoggettoGestore SoggettoGestoreTemp = SoggettoGestoreDAL.GetById(_dbProviderObj, IdSoggettoGestoreValue);
			if (SoggettoGestoreTemp!=null) SoggettoGestoreTemp.Provider = this;
			return SoggettoGestoreTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SoggettoGestoreCollection Select(IntNT IdsoggettogestoreEqualThis, IntNT IdimpresaEqualThis, StringNT DenominazionesoggettogestoreEqualThis)
		{
			SoggettoGestoreCollection SoggettoGestoreCollectionTemp = SoggettoGestoreDAL.Select(_dbProviderObj, IdsoggettogestoreEqualThis, IdimpresaEqualThis, DenominazionesoggettogestoreEqualThis);
			SoggettoGestoreCollectionTemp.Provider = this;
			return SoggettoGestoreCollectionTemp;
		}

		//FindSoggettoGestore: popola la collection
		public SoggettoGestoreCollection FindSoggettoGestore(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis)
		{
			SoggettoGestoreCollection SoggettoGestoreCollectionTemp = SoggettoGestoreDAL.FindSoggettoGestore(_dbProviderObj, IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis);
			SoggettoGestoreCollectionTemp.Provider = this;
			return SoggettoGestoreCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SOGGETTO_GESTORE>
  <ViewName>VSOGGETTO_GESTORE</ViewName>
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
    <FindSoggettoGestore OrderBy="ORDER BY ">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
    </FindSoggettoGestore>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SOGGETTO_GESTORE>
*/
