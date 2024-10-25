using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BusinessPlan
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBusinessPlanProvider
	{
		int Save(BusinessPlan BusinessPlanObj);
		int SaveCollection(BusinessPlanCollection collectionObj);
		int Delete(BusinessPlan BusinessPlanObj);
		int DeleteCollection(BusinessPlanCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BusinessPlan
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BusinessPlan: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdQuadro;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Quadro;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _Titolo;
		private NullTypes.IntNT _OrdineQuadri;
		private NullTypes.BoolNT _Domanda;
		[NonSerialized] private IBusinessPlanProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBusinessPlanProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BusinessPlan()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_QUADRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdQuadro
		{
			get { return _IdQuadro; }
			set {
				if (IdQuadro != value)
				{
					_IdQuadro = value;
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
		/// Corrisponde al campo:QUADRO
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Quadro
		{
			get { return _Quadro; }
			set {
				if (Quadro != value)
				{
					_Quadro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Titolo
		{
			get { return _Titolo; }
			set {
				if (Titolo != value)
				{
					_Titolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_QUADRI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineQuadri
		{
			get { return _OrdineQuadri; }
			set {
				if (OrdineQuadri != value)
				{
					_OrdineQuadri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DOMANDA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Domanda
		{
			get { return _Domanda; }
			set {
				if (Domanda != value)
				{
					_Domanda = value;
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
	/// Summary description for BusinessPlanCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BusinessPlanCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BusinessPlanCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BusinessPlan) info.GetValue(i.ToString(),typeof(BusinessPlan)));
			}
		}

		//Costruttore
		public BusinessPlanCollection()
		{
			this.ItemType = typeof(BusinessPlan);
		}

		//Costruttore con provider
		public BusinessPlanCollection(IBusinessPlanProvider providerObj)
		{
			this.ItemType = typeof(BusinessPlan);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BusinessPlan this[int index]
		{
			get { return (BusinessPlan)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BusinessPlanCollection GetChanges()
		{
			return (BusinessPlanCollection) base.GetChanges();
		}

		[NonSerialized] private IBusinessPlanProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBusinessPlanProvider Provider
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
		public int Add(BusinessPlan BusinessPlanObj)
		{
			if (BusinessPlanObj.Provider == null) BusinessPlanObj.Provider = this.Provider;
			return base.Add(BusinessPlanObj);
		}

		//AddCollection
		public void AddCollection(BusinessPlanCollection BusinessPlanCollectionObj)
		{
			foreach (BusinessPlan BusinessPlanObj in BusinessPlanCollectionObj)
				this.Add(BusinessPlanObj);
		}

		//Insert
		public void Insert(int index, BusinessPlan BusinessPlanObj)
		{
			if (BusinessPlanObj.Provider == null) BusinessPlanObj.Provider = this.Provider;
			base.Insert(index, BusinessPlanObj);
		}

		//CollectionGetById
		public BusinessPlan CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.IntNT IdQuadroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdQuadro == IdQuadroValue))
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
		public BusinessPlanCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdQuadroEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			BusinessPlanCollection BusinessPlanCollectionTemp = new BusinessPlanCollection();
			foreach (BusinessPlan BusinessPlanItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BusinessPlanItem.IdBando != null) && (BusinessPlanItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdQuadroEqualThis == null) || ((BusinessPlanItem.IdQuadro != null) && (BusinessPlanItem.IdQuadro.Value == IdQuadroEqualThis.Value))) && ((OrdineEqualThis == null) || ((BusinessPlanItem.Ordine != null) && (BusinessPlanItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					BusinessPlanCollectionTemp.Add(BusinessPlanItem);
				}
			}
			return BusinessPlanCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BusinessPlanDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BusinessPlanDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BusinessPlan BusinessPlanObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BusinessPlanObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdQuadro", BusinessPlanObj.IdQuadro);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", BusinessPlanObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, BusinessPlan BusinessPlanObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBusinessPlanInsert", new string[] {"IdBando", "IdQuadro", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(false, insertCmd,BusinessPlanObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BusinessPlanObj.IsDirty = false;
				BusinessPlanObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BusinessPlan BusinessPlanObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBusinessPlanUpdate", new string[] {"IdBando", "IdQuadro", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(true, updateCmd,BusinessPlanObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BusinessPlanObj.IsDirty = false;
				BusinessPlanObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BusinessPlan BusinessPlanObj)
		{
			switch (BusinessPlanObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BusinessPlanObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BusinessPlanObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BusinessPlanObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BusinessPlanCollection BusinessPlanCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBusinessPlanUpdate", new string[] {"IdBando", "IdQuadro", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBusinessPlanInsert", new string[] {"IdBando", "IdQuadro", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBusinessPlanDelete", new string[] {"IdBando", "IdQuadro"}, new string[] {"int", "int"},"");
				for (int i = 0; i < BusinessPlanCollectionObj.Count; i++)
				{
					switch (BusinessPlanCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BusinessPlanCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BusinessPlanCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BusinessPlanCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BusinessPlanCollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)BusinessPlanCollectionObj[i].IdQuadro);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BusinessPlanCollectionObj.Count; i++)
				{
					if ((BusinessPlanCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BusinessPlanCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BusinessPlanCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BusinessPlanCollectionObj[i].IsDirty = false;
						BusinessPlanCollectionObj[i].IsPersistent = true;
					}
					if ((BusinessPlanCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BusinessPlanCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BusinessPlanCollectionObj[i].IsDirty = false;
						BusinessPlanCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BusinessPlan BusinessPlanObj)
		{
			int returnValue = 0;
			if (BusinessPlanObj.IsPersistent) 
			{
				returnValue = Delete(db, BusinessPlanObj.IdBando, BusinessPlanObj.IdQuadro);
			}
			BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BusinessPlanObj.IsDirty = false;
			BusinessPlanObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, int IdQuadroValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBusinessPlanDelete", new string[] {"IdBando", "IdQuadro"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BusinessPlanCollection BusinessPlanCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBusinessPlanDelete", new string[] {"IdBando", "IdQuadro"}, new string[] {"int", "int"},"");
				for (int i = 0; i < BusinessPlanCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BusinessPlanCollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", BusinessPlanCollectionObj[i].IdQuadro);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BusinessPlanCollectionObj.Count; i++)
				{
					if ((BusinessPlanCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BusinessPlanCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BusinessPlanCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BusinessPlanCollectionObj[i].IsDirty = false;
						BusinessPlanCollectionObj[i].IsPersistent = false;
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
		public static BusinessPlan GetById(DbProvider db, int IdBandoValue, int IdQuadroValue)
		{
			BusinessPlan BusinessPlanObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBusinessPlanGetById", new string[] {"IdBando", "IdQuadro"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BusinessPlanObj = GetFromDatareader(db);
				BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BusinessPlanObj.IsDirty = false;
				BusinessPlanObj.IsPersistent = true;
			}
			db.Close();
			return BusinessPlanObj;
		}

		//getFromDatareader
		public static BusinessPlan GetFromDatareader(DbProvider db)
		{
			BusinessPlan BusinessPlanObj = new BusinessPlan();
			BusinessPlanObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BusinessPlanObj.IdQuadro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_QUADRO"]);
			BusinessPlanObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BusinessPlanObj.Quadro = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUADRO"]);
			BusinessPlanObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			BusinessPlanObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			BusinessPlanObj.OrdineQuadri = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_QUADRI"]);
			BusinessPlanObj.Domanda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA"]);
			BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BusinessPlanObj.IsDirty = false;
			BusinessPlanObj.IsPersistent = true;
			return BusinessPlanObj;
		}

		//Find Select

		public static BusinessPlanCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdQuadroEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BusinessPlanCollection BusinessPlanCollectionObj = new BusinessPlanCollection();

			IDbCommand findCmd = db.InitCmd("Zbusinessplanfindselect", new string[] {"IdBandoequalthis", "IdQuadroequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdQuadroequalthis", IdQuadroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BusinessPlan BusinessPlanObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BusinessPlanObj = GetFromDatareader(db);
				BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BusinessPlanObj.IsDirty = false;
				BusinessPlanObj.IsPersistent = true;
				BusinessPlanCollectionObj.Add(BusinessPlanObj);
			}
			db.Close();
			return BusinessPlanCollectionObj;
		}

		//Find Find

		public static BusinessPlanCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			BusinessPlanCollection BusinessPlanCollectionObj = new BusinessPlanCollection();

			IDbCommand findCmd = db.InitCmd("Zbusinessplanfindfind", new string[] {"IdBandoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			BusinessPlan BusinessPlanObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BusinessPlanObj = GetFromDatareader(db);
				BusinessPlanObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BusinessPlanObj.IsDirty = false;
				BusinessPlanObj.IsPersistent = true;
				BusinessPlanCollectionObj.Add(BusinessPlanObj);
			}
			db.Close();
			return BusinessPlanCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BusinessPlanCollectionProvider:IBusinessPlanProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BusinessPlanCollectionProvider : IBusinessPlanProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BusinessPlan
		protected BusinessPlanCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BusinessPlanCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BusinessPlanCollection(this);
		}

		//Costruttore 2: popola la collection
		public BusinessPlanCollectionProvider(IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis);
		}

		//Costruttore3: ha in input businessplanCollectionObj - non popola la collection
		public BusinessPlanCollectionProvider(BusinessPlanCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BusinessPlanCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BusinessPlanCollection(this);
		}

		//Get e Set
		public BusinessPlanCollection CollectionObj
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
		public int SaveCollection(BusinessPlanCollection collectionObj)
		{
			return BusinessPlanDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BusinessPlan businessplanObj)
		{
			return BusinessPlanDAL.Save(_dbProviderObj, businessplanObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BusinessPlanCollection collectionObj)
		{
			return BusinessPlanDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BusinessPlan businessplanObj)
		{
			return BusinessPlanDAL.Delete(_dbProviderObj, businessplanObj);
		}

		//getById
		public BusinessPlan GetById(IntNT IdBandoValue, IntNT IdQuadroValue)
		{
			BusinessPlan BusinessPlanTemp = BusinessPlanDAL.GetById(_dbProviderObj, IdBandoValue, IdQuadroValue);
			if (BusinessPlanTemp!=null) BusinessPlanTemp.Provider = this;
			return BusinessPlanTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BusinessPlanCollection Select(IntNT IdbandoEqualThis, IntNT IdquadroEqualThis, IntNT OrdineEqualThis)
		{
			BusinessPlanCollection BusinessPlanCollectionTemp = BusinessPlanDAL.Select(_dbProviderObj, IdbandoEqualThis, IdquadroEqualThis, OrdineEqualThis);
			BusinessPlanCollectionTemp.Provider = this;
			return BusinessPlanCollectionTemp;
		}

		//Find: popola la collection
		public BusinessPlanCollection Find(IntNT IdbandoEqualThis)
		{
			BusinessPlanCollection BusinessPlanCollectionTemp = BusinessPlanDAL.Find(_dbProviderObj, IdbandoEqualThis);
			BusinessPlanCollectionTemp.Provider = this;
			return BusinessPlanCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BUSINESS_PLAN>
  <ViewName>vBUSINESS_PLAN</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, ORDINE_QUADRI">
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BUSINESS_PLAN>
*/
