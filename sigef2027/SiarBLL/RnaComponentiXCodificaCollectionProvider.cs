using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaComponentiXCodifica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaComponentiXCodificaProvider
	{
		int Save(RnaComponentiXCodifica RnaComponentiXCodificaObj);
		int SaveCollection(RnaComponentiXCodificaCollection collectionObj);
		int Delete(RnaComponentiXCodifica RnaComponentiXCodificaObj);
		int DeleteCollection(RnaComponentiXCodificaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaComponentiXCodifica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaComponentiXCodifica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdComponentiXCodifica;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _IdRnaProcedimentiERegolamenti;
		private NullTypes.IntNT _IdRnaObiettivo;
		[NonSerialized] private IRnaComponentiXCodificaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaComponentiXCodificaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaComponentiXCodifica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COMPONENTI_X_CODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComponentiXCodifica
		{
			get { return _IdComponentiXCodifica; }
			set {
				if (IdComponentiXCodifica != value)
				{
					_IdComponentiXCodifica = value;
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
		/// Corrisponde al campo:ID_RNA_PROCEDIMENTI_E_REGOLAMENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaProcedimentiERegolamenti
		{
			get { return _IdRnaProcedimentiERegolamenti; }
			set {
				if (IdRnaProcedimentiERegolamenti != value)
				{
					_IdRnaProcedimentiERegolamenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RNA_OBIETTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaObiettivo
		{
			get { return _IdRnaObiettivo; }
			set {
				if (IdRnaObiettivo != value)
				{
					_IdRnaObiettivo = value;
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
	/// Summary description for RnaComponentiXCodificaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaComponentiXCodificaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaComponentiXCodificaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaComponentiXCodifica) info.GetValue(i.ToString(),typeof(RnaComponentiXCodifica)));
			}
		}

		//Costruttore
		public RnaComponentiXCodificaCollection()
		{
			this.ItemType = typeof(RnaComponentiXCodifica);
		}

		//Costruttore con provider
		public RnaComponentiXCodificaCollection(IRnaComponentiXCodificaProvider providerObj)
		{
			this.ItemType = typeof(RnaComponentiXCodifica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaComponentiXCodifica this[int index]
		{
			get { return (RnaComponentiXCodifica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaComponentiXCodificaCollection GetChanges()
		{
			return (RnaComponentiXCodificaCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaComponentiXCodificaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaComponentiXCodificaProvider Provider
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
		public int Add(RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			if (RnaComponentiXCodificaObj.Provider == null) RnaComponentiXCodificaObj.Provider = this.Provider;
			return base.Add(RnaComponentiXCodificaObj);
		}

		//AddCollection
		public void AddCollection(RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionObj)
		{
			foreach (RnaComponentiXCodifica RnaComponentiXCodificaObj in RnaComponentiXCodificaCollectionObj)
				this.Add(RnaComponentiXCodificaObj);
		}

		//Insert
		public void Insert(int index, RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			if (RnaComponentiXCodificaObj.Provider == null) RnaComponentiXCodificaObj.Provider = this.Provider;
			base.Insert(index, RnaComponentiXCodificaObj);
		}

		//CollectionGetById
		public RnaComponentiXCodifica CollectionGetById(NullTypes.IntNT IdComponentiXCodificaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdComponentiXCodifica == IdComponentiXCodificaValue))
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
		public RnaComponentiXCodificaCollection SubSelect(NullTypes.IntNT IdComponentiXCodificaEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.IntNT IdRnaProcedimentiERegolamentiEqualThis, 
NullTypes.IntNT IdRnaObiettivoEqualThis)
		{
			RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionTemp = new RnaComponentiXCodificaCollection();
			foreach (RnaComponentiXCodifica RnaComponentiXCodificaItem in this)
			{
				if (((IdComponentiXCodificaEqualThis == null) || ((RnaComponentiXCodificaItem.IdComponentiXCodifica != null) && (RnaComponentiXCodificaItem.IdComponentiXCodifica.Value == IdComponentiXCodificaEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((RnaComponentiXCodificaItem.IdCodificaInvestimento != null) && (RnaComponentiXCodificaItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((IdRnaProcedimentiERegolamentiEqualThis == null) || ((RnaComponentiXCodificaItem.IdRnaProcedimentiERegolamenti != null) && (RnaComponentiXCodificaItem.IdRnaProcedimentiERegolamenti.Value == IdRnaProcedimentiERegolamentiEqualThis.Value))) && 
((IdRnaObiettivoEqualThis == null) || ((RnaComponentiXCodificaItem.IdRnaObiettivo != null) && (RnaComponentiXCodificaItem.IdRnaObiettivo.Value == IdRnaObiettivoEqualThis.Value))))
				{
					RnaComponentiXCodificaCollectionTemp.Add(RnaComponentiXCodificaItem);
				}
			}
			return RnaComponentiXCodificaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaComponentiXCodificaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaComponentiXCodificaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaComponentiXCodifica RnaComponentiXCodificaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdComponentiXCodifica", RnaComponentiXCodificaObj.IdComponentiXCodifica);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCodificaInvestimento", RnaComponentiXCodificaObj.IdCodificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRnaProcedimentiERegolamenti", RnaComponentiXCodificaObj.IdRnaProcedimentiERegolamenti);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRnaObiettivo", RnaComponentiXCodificaObj.IdRnaObiettivo);
		}
		//Insert
		private static int Insert(DbProvider db, RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaComponentiXCodificaInsert", new string[] {"IdCodificaInvestimento", "IdRnaProcedimentiERegolamenti", 
"IdRnaObiettivo"}, new string[] {"int", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,RnaComponentiXCodificaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaComponentiXCodificaObj.IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
				}
				RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaComponentiXCodificaObj.IsDirty = false;
				RnaComponentiXCodificaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaComponentiXCodificaUpdate", new string[] {"IdComponentiXCodifica", "IdCodificaInvestimento", "IdRnaProcedimentiERegolamenti", 
"IdRnaObiettivo"}, new string[] {"int", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,RnaComponentiXCodificaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaComponentiXCodificaObj.IsDirty = false;
				RnaComponentiXCodificaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			switch (RnaComponentiXCodificaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaComponentiXCodificaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaComponentiXCodificaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaComponentiXCodificaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaComponentiXCodificaUpdate", new string[] {"IdComponentiXCodifica", "IdCodificaInvestimento", "IdRnaProcedimentiERegolamenti", 
"IdRnaObiettivo"}, new string[] {"int", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaComponentiXCodificaInsert", new string[] {"IdCodificaInvestimento", "IdRnaProcedimentiERegolamenti", 
"IdRnaObiettivo"}, new string[] {"int", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaComponentiXCodificaDelete", new string[] {"IdComponentiXCodifica"}, new string[] {"int"},"");
				for (int i = 0; i < RnaComponentiXCodificaCollectionObj.Count; i++)
				{
					switch (RnaComponentiXCodificaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaComponentiXCodificaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaComponentiXCodificaCollectionObj[i].IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaComponentiXCodificaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaComponentiXCodificaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComponentiXCodifica", (SiarLibrary.NullTypes.IntNT)RnaComponentiXCodificaCollectionObj[i].IdComponentiXCodifica);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaComponentiXCodificaCollectionObj.Count; i++)
				{
					if ((RnaComponentiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaComponentiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaComponentiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaComponentiXCodificaCollectionObj[i].IsDirty = false;
						RnaComponentiXCodificaCollectionObj[i].IsPersistent = true;
					}
					if ((RnaComponentiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaComponentiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaComponentiXCodificaCollectionObj[i].IsDirty = false;
						RnaComponentiXCodificaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaComponentiXCodifica RnaComponentiXCodificaObj)
		{
			int returnValue = 0;
			if (RnaComponentiXCodificaObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaComponentiXCodificaObj.IdComponentiXCodifica);
			}
			RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaComponentiXCodificaObj.IsDirty = false;
			RnaComponentiXCodificaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdComponentiXCodificaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaComponentiXCodificaDelete", new string[] {"IdComponentiXCodifica"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComponentiXCodifica", (SiarLibrary.NullTypes.IntNT)IdComponentiXCodificaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaComponentiXCodificaDelete", new string[] {"IdComponentiXCodifica"}, new string[] {"int"},"");
				for (int i = 0; i < RnaComponentiXCodificaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComponentiXCodifica", RnaComponentiXCodificaCollectionObj[i].IdComponentiXCodifica);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaComponentiXCodificaCollectionObj.Count; i++)
				{
					if ((RnaComponentiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaComponentiXCodificaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaComponentiXCodificaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaComponentiXCodificaCollectionObj[i].IsDirty = false;
						RnaComponentiXCodificaCollectionObj[i].IsPersistent = false;
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
		public static RnaComponentiXCodifica GetById(DbProvider db, int IdComponentiXCodificaValue)
		{
			RnaComponentiXCodifica RnaComponentiXCodificaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaComponentiXCodificaGetById", new string[] {"IdComponentiXCodifica"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdComponentiXCodifica", (SiarLibrary.NullTypes.IntNT)IdComponentiXCodificaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaComponentiXCodificaObj = GetFromDatareader(db);
				RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaComponentiXCodificaObj.IsDirty = false;
				RnaComponentiXCodificaObj.IsPersistent = true;
			}
			db.Close();
			return RnaComponentiXCodificaObj;
		}

		//getFromDatareader
		public static RnaComponentiXCodifica GetFromDatareader(DbProvider db)
		{
			RnaComponentiXCodifica RnaComponentiXCodificaObj = new RnaComponentiXCodifica();
			RnaComponentiXCodificaObj.IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
			RnaComponentiXCodificaObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			RnaComponentiXCodificaObj.IdRnaProcedimentiERegolamenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_PROCEDIMENTI_E_REGOLAMENTI"]);
			RnaComponentiXCodificaObj.IdRnaObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_OBIETTIVO"]);
			RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaComponentiXCodificaObj.IsDirty = false;
			RnaComponentiXCodificaObj.IsPersistent = true;
			return RnaComponentiXCodificaObj;
		}

		//Find Select

		public static RnaComponentiXCodificaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdComponentiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdRnaProcedimentiERegolamentiEqualThis, 
SiarLibrary.NullTypes.IntNT IdRnaObiettivoEqualThis)

		{

			RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionObj = new RnaComponentiXCodificaCollection();

			IDbCommand findCmd = db.InitCmd("Zrnacomponentixcodificafindselect", new string[] {"IdComponentiXCodificaequalthis", "IdCodificaInvestimentoequalthis", "IdRnaProcedimentiERegolamentiequalthis", 
"IdRnaObiettivoequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComponentiXCodificaequalthis", IdComponentiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaProcedimentiERegolamentiequalthis", IdRnaProcedimentiERegolamentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaObiettivoequalthis", IdRnaObiettivoEqualThis);
			RnaComponentiXCodifica RnaComponentiXCodificaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaComponentiXCodificaObj = GetFromDatareader(db);
				RnaComponentiXCodificaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaComponentiXCodificaObj.IsDirty = false;
				RnaComponentiXCodificaObj.IsPersistent = true;
				RnaComponentiXCodificaCollectionObj.Add(RnaComponentiXCodificaObj);
			}
			db.Close();
			return RnaComponentiXCodificaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaComponentiXCodificaCollectionProvider:IRnaComponentiXCodificaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaComponentiXCodificaCollectionProvider : IRnaComponentiXCodificaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaComponentiXCodifica
		protected RnaComponentiXCodificaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaComponentiXCodificaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaComponentiXCodificaCollection(this);
		}

		//Costruttore3: ha in input rnacomponentixcodificaCollectionObj - non popola la collection
		public RnaComponentiXCodificaCollectionProvider(RnaComponentiXCodificaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaComponentiXCodificaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaComponentiXCodificaCollection(this);
		}

		//Get e Set
		public RnaComponentiXCodificaCollection CollectionObj
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
		public int SaveCollection(RnaComponentiXCodificaCollection collectionObj)
		{
			return RnaComponentiXCodificaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaComponentiXCodifica rnacomponentixcodificaObj)
		{
			return RnaComponentiXCodificaDAL.Save(_dbProviderObj, rnacomponentixcodificaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaComponentiXCodificaCollection collectionObj)
		{
			return RnaComponentiXCodificaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaComponentiXCodifica rnacomponentixcodificaObj)
		{
			return RnaComponentiXCodificaDAL.Delete(_dbProviderObj, rnacomponentixcodificaObj);
		}

		//getById
		public RnaComponentiXCodifica GetById(IntNT IdComponentiXCodificaValue)
		{
			RnaComponentiXCodifica RnaComponentiXCodificaTemp = RnaComponentiXCodificaDAL.GetById(_dbProviderObj, IdComponentiXCodificaValue);
			if (RnaComponentiXCodificaTemp!=null) RnaComponentiXCodificaTemp.Provider = this;
			return RnaComponentiXCodificaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaComponentiXCodificaCollection Select(IntNT IdcomponentixcodificaEqualThis, IntNT IdcodificainvestimentoEqualThis, IntNT IdrnaprocedimentieregolamentiEqualThis, 
IntNT IdrnaobiettivoEqualThis)
		{
			RnaComponentiXCodificaCollection RnaComponentiXCodificaCollectionTemp = RnaComponentiXCodificaDAL.Select(_dbProviderObj, IdcomponentixcodificaEqualThis, IdcodificainvestimentoEqualThis, IdrnaprocedimentieregolamentiEqualThis, 
IdrnaobiettivoEqualThis);
			RnaComponentiXCodificaCollectionTemp.Provider = this;
			return RnaComponentiXCodificaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_COMPONENTI_X_CODIFICA>
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
</RNA_COMPONENTI_X_CODIFICA>
*/
