using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaCostiXCodifica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaCostiXCodificaProvider
	{
		int Save(RnaCostiXCodifica RnaCostiXCodificaObj);
		int SaveCollection(RnaCostiXCodificaCollection collectionObj);
		int Delete(RnaCostiXCodifica RnaCostiXCodificaObj);
		int DeleteCollection(RnaCostiXCodificaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaCostiXCodifica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaCostiXCodifica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCostiXCodifica;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _CodTipoSpesa;
		[NonSerialized] private IRnaCostiXCodificaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaCostiXCodificaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaCostiXCodifica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COSTI_X_CODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCostiXCodifica
		{
			get { return _IdCostiXCodifica; }
			set {
				if (IdCostiXCodifica != value)
				{
					_IdCostiXCodifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCodificaInvestimento
		{
			get { return _IdCodificaInvestimento; }
			set {
				if (IdCodificaInvestimento != value)
				{
					_IdCodificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoSpesa
		{
			get { return _CodTipoSpesa; }
			set {
				if (CodTipoSpesa != value)
				{
					_CodTipoSpesa = value;
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
	/// Summary description for RnaCostiXCodificaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaCostiXCodificaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaCostiXCodificaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaCostiXCodifica) info.GetValue(i.ToString(),typeof(RnaCostiXCodifica)));
			}
		}

		//Costruttore
		public RnaCostiXCodificaCollection()
		{
			this.ItemType = typeof(RnaCostiXCodifica);
		}

		//Costruttore con provider
		public RnaCostiXCodificaCollection(IRnaCostiXCodificaProvider providerObj)
		{
			this.ItemType = typeof(RnaCostiXCodifica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaCostiXCodifica this[int index]
		{
			get { return (RnaCostiXCodifica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaCostiXCodificaCollection GetChanges()
		{
			return (RnaCostiXCodificaCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaCostiXCodificaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaCostiXCodificaProvider Provider
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
		public int Add(RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			if (RnaCostiXCodificaObj.Provider == null) RnaCostiXCodificaObj.Provider = this.Provider;
			return base.Add(RnaCostiXCodificaObj);
		}

		//AddCollection
		public void AddCollection(RnaCostiXCodificaCollection RnaCostiXCodificaCollectionObj)
		{
			foreach (RnaCostiXCodifica RnaCostiXCodificaObj in RnaCostiXCodificaCollectionObj)
				this.Add(RnaCostiXCodificaObj);
		}

		//Insert
		public void Insert(int index, RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			if (RnaCostiXCodificaObj.Provider == null) RnaCostiXCodificaObj.Provider = this.Provider;
			base.Insert(index, RnaCostiXCodificaObj);
		}

		//CollectionGetById
		public RnaCostiXCodifica CollectionGetById(NullTypes.IntNT IdCostiXCodificaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCostiXCodifica == IdCostiXCodificaValue))
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
		public RnaCostiXCodificaCollection SubSelect(NullTypes.IntNT IdCostiXCodificaEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.IntNT CodTipoSpesaEqualThis)
		{
			RnaCostiXCodificaCollection RnaCostiXCodificaCollectionTemp = new RnaCostiXCodificaCollection();
			foreach (RnaCostiXCodifica RnaCostiXCodificaItem in this)
			{
				if (((IdCostiXCodificaEqualThis == null) || ((RnaCostiXCodificaItem.IdCostiXCodifica != null) && (RnaCostiXCodificaItem.IdCostiXCodifica.Value == IdCostiXCodificaEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((RnaCostiXCodificaItem.IdCodificaInvestimento != null) && (RnaCostiXCodificaItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((CodTipoSpesaEqualThis == null) || ((RnaCostiXCodificaItem.CodTipoSpesa != null) && (RnaCostiXCodificaItem.CodTipoSpesa.Value == CodTipoSpesaEqualThis.Value))))
				{
					RnaCostiXCodificaCollectionTemp.Add(RnaCostiXCodificaItem);
				}
			}
			return RnaCostiXCodificaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaCostiXCodificaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaCostiXCodificaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaCostiXCodifica RnaCostiXCodificaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCostiXCodifica", RnaCostiXCodificaObj.IdCostiXCodifica);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCodificaInvestimento", RnaCostiXCodificaObj.IdCodificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoSpesa", RnaCostiXCodificaObj.CodTipoSpesa);
		}
		//Insert
		private static int Insert(DbProvider db, RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaCostiXCodificaInsert", new string[] {"IdCodificaInvestimento", "CodTipoSpesa"}, new string[] {"int", "int"},"");
				CompileIUCmd(false, insertCmd,RnaCostiXCodificaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaCostiXCodificaObj.IdCostiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COSTI_X_CODIFICA"]);
				}
				RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaCostiXCodificaObj.IsDirty = false;
				RnaCostiXCodificaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaCostiXCodificaUpdate", new string[] {"IdCostiXCodifica", "IdCodificaInvestimento", "CodTipoSpesa"}, new string[] {"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,RnaCostiXCodificaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaCostiXCodificaObj.IsDirty = false;
				RnaCostiXCodificaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			switch (RnaCostiXCodificaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaCostiXCodificaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaCostiXCodificaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaCostiXCodificaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaCostiXCodificaCollection RnaCostiXCodificaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaCostiXCodificaUpdate", new string[] {"IdCostiXCodifica", "IdCodificaInvestimento", "CodTipoSpesa"}, new string[] {"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaCostiXCodificaInsert", new string[] {"IdCodificaInvestimento", "CodTipoSpesa"}, new string[] {"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaCostiXCodificaDelete", new string[] {"IdCostiXCodifica"}, new string[] {"int"},"");
				for (int i = 0; i < RnaCostiXCodificaCollectionObj.Count; i++)
				{
					switch (RnaCostiXCodificaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaCostiXCodificaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaCostiXCodificaCollectionObj[i].IdCostiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COSTI_X_CODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaCostiXCodificaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaCostiXCodificaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCostiXCodifica", (SiarLibrary.NullTypes.IntNT)RnaCostiXCodificaCollectionObj[i].IdCostiXCodifica);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaCostiXCodificaCollectionObj.Count; i++)
				{
					if ((RnaCostiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaCostiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaCostiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaCostiXCodificaCollectionObj[i].IsDirty = false;
						RnaCostiXCodificaCollectionObj[i].IsPersistent = true;
					}
					if ((RnaCostiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaCostiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaCostiXCodificaCollectionObj[i].IsDirty = false;
						RnaCostiXCodificaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaCostiXCodifica RnaCostiXCodificaObj)
		{
			int returnValue = 0;
			if (RnaCostiXCodificaObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaCostiXCodificaObj.IdCostiXCodifica);
			}
			RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaCostiXCodificaObj.IsDirty = false;
			RnaCostiXCodificaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCostiXCodificaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaCostiXCodificaDelete", new string[] {"IdCostiXCodifica"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCostiXCodifica", (SiarLibrary.NullTypes.IntNT)IdCostiXCodificaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaCostiXCodificaCollection RnaCostiXCodificaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaCostiXCodificaDelete", new string[] {"IdCostiXCodifica"}, new string[] {"int"},"");
				for (int i = 0; i < RnaCostiXCodificaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCostiXCodifica", RnaCostiXCodificaCollectionObj[i].IdCostiXCodifica);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaCostiXCodificaCollectionObj.Count; i++)
				{
					if ((RnaCostiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaCostiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaCostiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaCostiXCodificaCollectionObj[i].IsDirty = false;
						RnaCostiXCodificaCollectionObj[i].IsPersistent = false;
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
		public static RnaCostiXCodifica GetById(DbProvider db, int IdCostiXCodificaValue)
		{
			RnaCostiXCodifica RnaCostiXCodificaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaCostiXCodificaGetById", new string[] {"IdCostiXCodifica"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCostiXCodifica", (SiarLibrary.NullTypes.IntNT)IdCostiXCodificaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaCostiXCodificaObj = GetFromDatareader(db);
				RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaCostiXCodificaObj.IsDirty = false;
				RnaCostiXCodificaObj.IsPersistent = true;
			}
			db.Close();
			return RnaCostiXCodificaObj;
		}

		//getFromDatareader
		public static RnaCostiXCodifica GetFromDatareader(DbProvider db)
		{
			RnaCostiXCodifica RnaCostiXCodificaObj = new RnaCostiXCodifica();
			RnaCostiXCodificaObj.IdCostiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COSTI_X_CODIFICA"]);
			RnaCostiXCodificaObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			RnaCostiXCodificaObj.CodTipoSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_SPESA"]);
			RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaCostiXCodificaObj.IsDirty = false;
			RnaCostiXCodificaObj.IsPersistent = true;
			return RnaCostiXCodificaObj;
		}

		//Find Select

		public static RnaCostiXCodificaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCostiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT CodTipoSpesaEqualThis)

		{

			RnaCostiXCodificaCollection RnaCostiXCodificaCollectionObj = new RnaCostiXCodificaCollection();

			IDbCommand findCmd = db.InitCmd("Zrnacostixcodificafindselect", new string[] {"IdCostiXCodificaequalthis", "IdCodificaInvestimentoequalthis", "CodTipoSpesaequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCostiXCodificaequalthis", IdCostiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSpesaequalthis", CodTipoSpesaEqualThis);
			RnaCostiXCodifica RnaCostiXCodificaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaCostiXCodificaObj = GetFromDatareader(db);
				RnaCostiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaCostiXCodificaObj.IsDirty = false;
				RnaCostiXCodificaObj.IsPersistent = true;
				RnaCostiXCodificaCollectionObj.Add(RnaCostiXCodificaObj);
			}
			db.Close();
			return RnaCostiXCodificaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaCostiXCodificaCollectionProvider:IRnaCostiXCodificaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaCostiXCodificaCollectionProvider : IRnaCostiXCodificaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaCostiXCodifica
		protected RnaCostiXCodificaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaCostiXCodificaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaCostiXCodificaCollection(this);
		}

		//Costruttore3: ha in input rnacostixcodificaCollectionObj - non popola la collection
		public RnaCostiXCodificaCollectionProvider(RnaCostiXCodificaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaCostiXCodificaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaCostiXCodificaCollection(this);
		}

		//Get e Set
		public RnaCostiXCodificaCollection CollectionObj
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
		public int SaveCollection(RnaCostiXCodificaCollection collectionObj)
		{
			return RnaCostiXCodificaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaCostiXCodifica rnacostixcodificaObj)
		{
			return RnaCostiXCodificaDAL.Save(_dbProviderObj, rnacostixcodificaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaCostiXCodificaCollection collectionObj)
		{
			return RnaCostiXCodificaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaCostiXCodifica rnacostixcodificaObj)
		{
			return RnaCostiXCodificaDAL.Delete(_dbProviderObj, rnacostixcodificaObj);
		}

		//getById
		public RnaCostiXCodifica GetById(IntNT IdCostiXCodificaValue)
		{
			RnaCostiXCodifica RnaCostiXCodificaTemp = RnaCostiXCodificaDAL.GetById(_dbProviderObj, IdCostiXCodificaValue);
			if (RnaCostiXCodificaTemp!=null) RnaCostiXCodificaTemp.Provider = this;
			return RnaCostiXCodificaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaCostiXCodificaCollection Select(IntNT IdcostixcodificaEqualThis, IntNT IdcodificainvestimentoEqualThis, IntNT CodtipospesaEqualThis)
		{
			RnaCostiXCodificaCollection RnaCostiXCodificaCollectionTemp = RnaCostiXCodificaDAL.Select(_dbProviderObj, IdcostixcodificaEqualThis, IdcodificainvestimentoEqualThis, CodtipospesaEqualThis);
			RnaCostiXCodificaCollectionTemp.Provider = this;
			return RnaCostiXCodificaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_COSTI_X_CODIFICA>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_COSTI_X_CODIFICA>
*/
