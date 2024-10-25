using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Ula
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IUlaProvider
	{
		int Save(Ula UlaObj);
		int SaveCollection(UlaCollection collectionObj);
		int Delete(Ula UlaObj);
		int DeleteCollection(UlaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Ula
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Ula: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _Anno;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DecimalNT _TotaleUla;
		[NonSerialized] private IUlaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Ula()
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
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOTALE_ULA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT TotaleUla
		{
			get { return _TotaleUla; }
			set {
				if (TotaleUla != value)
				{
					_TotaleUla = value;
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
	/// Summary description for UlaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private UlaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Ula) info.GetValue(i.ToString(),typeof(Ula)));
			}
		}

		//Costruttore
		public UlaCollection()
		{
			this.ItemType = typeof(Ula);
		}

		//Costruttore con provider
		public UlaCollection(IUlaProvider providerObj)
		{
			this.ItemType = typeof(Ula);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Ula this[int index]
		{
			get { return (Ula)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new UlaCollection GetChanges()
		{
			return (UlaCollection) base.GetChanges();
		}

		[NonSerialized] private IUlaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaProvider Provider
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
		public int Add(Ula UlaObj)
		{
			if (UlaObj.Provider == null) UlaObj.Provider = this.Provider;
			return base.Add(UlaObj);
		}

		//AddCollection
		public void AddCollection(UlaCollection UlaCollectionObj)
		{
			foreach (Ula UlaObj in UlaCollectionObj)
				this.Add(UlaObj);
		}

		//Insert
		public void Insert(int index, Ula UlaObj)
		{
			if (UlaObj.Provider == null) UlaObj.Provider = this.Provider;
			base.Insert(index, UlaObj);
		}

		//CollectionGetById
		public Ula CollectionGetById(NullTypes.IntNT IdValue)
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
		public UlaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT AnnoEqualThis, 
NullTypes.IntNT OperatoreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DecimalNT TotaleUlaEqualThis)
		{
			UlaCollection UlaCollectionTemp = new UlaCollection();
			foreach (Ula UlaItem in this)
			{
				if (((IdEqualThis == null) || ((UlaItem.Id != null) && (UlaItem.Id.Value == IdEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((UlaItem.IdImpresa != null) && (UlaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((AnnoEqualThis == null) || ((UlaItem.Anno != null) && (UlaItem.Anno.Value == AnnoEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((UlaItem.Operatore != null) && (UlaItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((UlaItem.DataInserimento != null) && (UlaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((TotaleUlaEqualThis == null) || ((UlaItem.TotaleUla != null) && (UlaItem.TotaleUla.Value == TotaleUlaEqualThis.Value))))
				{
					UlaCollectionTemp.Add(UlaItem);
				}
			}
			return UlaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public UlaCollection Filter(NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT AnnoEqualThis)
		{
			UlaCollection UlaCollectionTemp = new UlaCollection();
			foreach (Ula UlaItem in this)
			{
				if (((IdImpresaEqualThis == null) || ((UlaItem.IdImpresa != null) && (UlaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((AnnoEqualThis == null) || ((UlaItem.Anno != null) && (UlaItem.Anno.Value == AnnoEqualThis.Value))))
				{
					UlaCollectionTemp.Add(UlaItem);
				}
			}
			return UlaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for UlaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class UlaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Ula UlaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", UlaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", UlaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", UlaObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", UlaObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", UlaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "TotaleUla", UlaObj.TotaleUla);
		}
		//Insert
		private static int Insert(DbProvider db, Ula UlaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZUlaInsert", new string[] {"IdImpresa", "Anno", 
"Operatore", "DataInserimento", "TotaleUla"}, new string[] {"int", "int", 
"int", "DateTime", "decimal"},"");
				CompileIUCmd(false, insertCmd,UlaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				UlaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaObj.IsDirty = false;
				UlaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Ula UlaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaUpdate", new string[] {"Id", "IdImpresa", "Anno", 
"Operatore", "DataInserimento", "TotaleUla"}, new string[] {"int", "int", "int", 
"int", "DateTime", "decimal"},"");
				CompileIUCmd(true, updateCmd,UlaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaObj.IsDirty = false;
				UlaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Ula UlaObj)
		{
			switch (UlaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, UlaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, UlaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,UlaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, UlaCollection UlaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaUpdate", new string[] {"Id", "IdImpresa", "Anno", 
"Operatore", "DataInserimento", "TotaleUla"}, new string[] {"int", "int", "int", 
"int", "DateTime", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZUlaInsert", new string[] {"IdImpresa", "Anno", 
"Operatore", "DataInserimento", "TotaleUla"}, new string[] {"int", "int", 
"int", "DateTime", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaCollectionObj.Count; i++)
				{
					switch (UlaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,UlaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									UlaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,UlaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (UlaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)UlaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < UlaCollectionObj.Count; i++)
				{
					if ((UlaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						UlaCollectionObj[i].IsDirty = false;
						UlaCollectionObj[i].IsPersistent = true;
					}
					if ((UlaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						UlaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaCollectionObj[i].IsDirty = false;
						UlaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Ula UlaObj)
		{
			int returnValue = 0;
			if (UlaObj.IsPersistent) 
			{
				returnValue = Delete(db, UlaObj.Id);
			}
			UlaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			UlaObj.IsDirty = false;
			UlaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, UlaCollection UlaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", UlaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < UlaCollectionObj.Count; i++)
				{
					if ((UlaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaCollectionObj[i].IsDirty = false;
						UlaCollectionObj[i].IsPersistent = false;
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
		public static Ula GetById(DbProvider db, int IdValue)
		{
			Ula UlaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZUlaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				UlaObj = GetFromDatareader(db);
				UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaObj.IsDirty = false;
				UlaObj.IsPersistent = true;
			}
			db.Close();
			return UlaObj;
		}

		//getFromDatareader
		public static Ula GetFromDatareader(DbProvider db)
		{
			Ula UlaObj = new Ula();
			UlaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			UlaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			UlaObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			UlaObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			UlaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			UlaObj.TotaleUla = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_ULA"]);
			UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			UlaObj.IsDirty = false;
			UlaObj.IsPersistent = true;
			return UlaObj;
		}

		//Find Select

		public static UlaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DecimalNT TotaleUlaEqualThis)

		{

			UlaCollection UlaCollectionObj = new UlaCollection();

			IDbCommand findCmd = db.InitCmd("Zulafindselect", new string[] {"Idequalthis", "IdImpresaequalthis", "Annoequalthis", 
"Operatoreequalthis", "DataInserimentoequalthis", "TotaleUlaequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotaleUlaequalthis", TotaleUlaEqualThis);
			Ula UlaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaObj = GetFromDatareader(db);
				UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaObj.IsDirty = false;
				UlaObj.IsPersistent = true;
				UlaCollectionObj.Add(UlaObj);
			}
			db.Close();
			return UlaCollectionObj;
		}

		//Find Find

		public static UlaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis)

		{

			UlaCollection UlaCollectionObj = new UlaCollection();

			IDbCommand findCmd = db.InitCmd("Zulafindfind", new string[] {"IdImpresaequalthis", "Annoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			Ula UlaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaObj = GetFromDatareader(db);
				UlaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaObj.IsDirty = false;
				UlaObj.IsPersistent = true;
				UlaCollectionObj.Add(UlaObj);
			}
			db.Close();
			return UlaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for UlaCollectionProvider:IUlaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaCollectionProvider : IUlaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Ula
		protected UlaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public UlaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new UlaCollection(this);
		}

		//Costruttore 2: popola la collection
		public UlaCollectionProvider(IntNT IdimpresaEqualThis, IntNT AnnoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis, AnnoEqualThis);
		}

		//Costruttore3: ha in input ulaCollectionObj - non popola la collection
		public UlaCollectionProvider(UlaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public UlaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new UlaCollection(this);
		}

		//Get e Set
		public UlaCollection CollectionObj
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
		public int SaveCollection(UlaCollection collectionObj)
		{
			return UlaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Ula ulaObj)
		{
			return UlaDAL.Save(_dbProviderObj, ulaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(UlaCollection collectionObj)
		{
			return UlaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Ula ulaObj)
		{
			return UlaDAL.Delete(_dbProviderObj, ulaObj);
		}

		//getById
		public Ula GetById(IntNT IdValue)
		{
			Ula UlaTemp = UlaDAL.GetById(_dbProviderObj, IdValue);
			if (UlaTemp!=null) UlaTemp.Provider = this;
			return UlaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public UlaCollection Select(IntNT IdEqualThis, IntNT IdimpresaEqualThis, IntNT AnnoEqualThis, 
IntNT OperatoreEqualThis, DatetimeNT DatainserimentoEqualThis, DecimalNT TotaleulaEqualThis)
		{
			UlaCollection UlaCollectionTemp = UlaDAL.Select(_dbProviderObj, IdEqualThis, IdimpresaEqualThis, AnnoEqualThis, 
OperatoreEqualThis, DatainserimentoEqualThis, TotaleulaEqualThis);
			UlaCollectionTemp.Provider = this;
			return UlaCollectionTemp;
		}

		//Find: popola la collection
		public UlaCollection Find(IntNT IdimpresaEqualThis, IntNT AnnoEqualThis)
		{
			UlaCollection UlaCollectionTemp = UlaDAL.Find(_dbProviderObj, IdimpresaEqualThis, AnnoEqualThis);
			UlaCollectionTemp.Provider = this;
			return UlaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ULA>
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
    <Find OrderBy="ORDER BY ID_IMPRESA, ANNO">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ANNO>Equal</ANNO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ULA>
*/
