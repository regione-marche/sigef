using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaStrumentiXComponenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaStrumentiXComponentiProvider
	{
		int Save(RnaStrumentiXComponenti RnaStrumentiXComponentiObj);
		int SaveCollection(RnaStrumentiXComponentiCollection collectionObj);
		int Delete(RnaStrumentiXComponenti RnaStrumentiXComponentiObj);
		int DeleteCollection(RnaStrumentiXComponentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaStrumentiXComponenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaStrumentiXComponenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdStrumentiXComponenti;
		private NullTypes.IntNT _IdComponentiXCodifica;
		private NullTypes.IntNT _CodTipoStrumentoAiuto;
		private NullTypes.DecimalNT _IntensitaStrumento;
		[NonSerialized] private IRnaStrumentiXComponentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaStrumentiXComponentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaStrumentiXComponenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_STRUMENTI_X_COMPONENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStrumentiXComponenti
		{
			get { return _IdStrumentiXComponenti; }
			set {
				if (IdStrumentiXComponenti != value)
				{
					_IdStrumentiXComponenti = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:COD_TIPO_STRUMENTO_AIUTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoStrumentoAiuto
		{
			get { return _CodTipoStrumentoAiuto; }
			set {
				if (CodTipoStrumentoAiuto != value)
				{
					_CodTipoStrumentoAiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTENSITA_STRUMENTO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT IntensitaStrumento
		{
			get { return _IntensitaStrumento; }
			set {
				if (IntensitaStrumento != value)
				{
					_IntensitaStrumento = value;
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
	/// Summary description for RnaStrumentiXComponentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaStrumentiXComponentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaStrumentiXComponentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaStrumentiXComponenti) info.GetValue(i.ToString(),typeof(RnaStrumentiXComponenti)));
			}
		}

		//Costruttore
		public RnaStrumentiXComponentiCollection()
		{
			this.ItemType = typeof(RnaStrumentiXComponenti);
		}

		//Costruttore con provider
		public RnaStrumentiXComponentiCollection(IRnaStrumentiXComponentiProvider providerObj)
		{
			this.ItemType = typeof(RnaStrumentiXComponenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaStrumentiXComponenti this[int index]
		{
			get { return (RnaStrumentiXComponenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaStrumentiXComponentiCollection GetChanges()
		{
			return (RnaStrumentiXComponentiCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaStrumentiXComponentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaStrumentiXComponentiProvider Provider
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
		public int Add(RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			if (RnaStrumentiXComponentiObj.Provider == null) RnaStrumentiXComponentiObj.Provider = this.Provider;
			return base.Add(RnaStrumentiXComponentiObj);
		}

		//AddCollection
		public void AddCollection(RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionObj)
		{
			foreach (RnaStrumentiXComponenti RnaStrumentiXComponentiObj in RnaStrumentiXComponentiCollectionObj)
				this.Add(RnaStrumentiXComponentiObj);
		}

		//Insert
		public void Insert(int index, RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			if (RnaStrumentiXComponentiObj.Provider == null) RnaStrumentiXComponentiObj.Provider = this.Provider;
			base.Insert(index, RnaStrumentiXComponentiObj);
		}

		//CollectionGetById
		public RnaStrumentiXComponenti CollectionGetById(NullTypes.IntNT IdStrumentiXComponentiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdStrumentiXComponenti == IdStrumentiXComponentiValue))
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
		public RnaStrumentiXComponentiCollection SubSelect(NullTypes.IntNT IdStrumentiXComponentiEqualThis, NullTypes.IntNT IdComponentiXCodificaEqualThis, NullTypes.IntNT CodTipoStrumentoAiutoEqualThis, 
NullTypes.DecimalNT IntensitaStrumentoEqualThis)
		{
			RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionTemp = new RnaStrumentiXComponentiCollection();
			foreach (RnaStrumentiXComponenti RnaStrumentiXComponentiItem in this)
			{
				if (((IdStrumentiXComponentiEqualThis == null) || ((RnaStrumentiXComponentiItem.IdStrumentiXComponenti != null) && (RnaStrumentiXComponentiItem.IdStrumentiXComponenti.Value == IdStrumentiXComponentiEqualThis.Value))) && ((IdComponentiXCodificaEqualThis == null) || ((RnaStrumentiXComponentiItem.IdComponentiXCodifica != null) && (RnaStrumentiXComponentiItem.IdComponentiXCodifica.Value == IdComponentiXCodificaEqualThis.Value))) && ((CodTipoStrumentoAiutoEqualThis == null) || ((RnaStrumentiXComponentiItem.CodTipoStrumentoAiuto != null) && (RnaStrumentiXComponentiItem.CodTipoStrumentoAiuto.Value == CodTipoStrumentoAiutoEqualThis.Value))) && 
((IntensitaStrumentoEqualThis == null) || ((RnaStrumentiXComponentiItem.IntensitaStrumento != null) && (RnaStrumentiXComponentiItem.IntensitaStrumento.Value == IntensitaStrumentoEqualThis.Value))))
				{
					RnaStrumentiXComponentiCollectionTemp.Add(RnaStrumentiXComponentiItem);
				}
			}
			return RnaStrumentiXComponentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaStrumentiXComponentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaStrumentiXComponentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaStrumentiXComponenti RnaStrumentiXComponentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdStrumentiXComponenti", RnaStrumentiXComponentiObj.IdStrumentiXComponenti);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdComponentiXCodifica", RnaStrumentiXComponentiObj.IdComponentiXCodifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoStrumentoAiuto", RnaStrumentiXComponentiObj.CodTipoStrumentoAiuto);
			DbProvider.SetCmdParam(cmd,firstChar + "IntensitaStrumento", RnaStrumentiXComponentiObj.IntensitaStrumento);
		}
		//Insert
		private static int Insert(DbProvider db, RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaStrumentiXComponentiInsert", new string[] {"IdComponentiXCodifica", "CodTipoStrumentoAiuto", 
"IntensitaStrumento"}, new string[] {"int", "int", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,RnaStrumentiXComponentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaStrumentiXComponentiObj.IdStrumentiXComponenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STRUMENTI_X_COMPONENTI"]);
				}
				RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaStrumentiXComponentiObj.IsDirty = false;
				RnaStrumentiXComponentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaStrumentiXComponentiUpdate", new string[] {"IdStrumentiXComponenti", "IdComponentiXCodifica", "CodTipoStrumentoAiuto", 
"IntensitaStrumento"}, new string[] {"int", "int", "int", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,RnaStrumentiXComponentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaStrumentiXComponentiObj.IsDirty = false;
				RnaStrumentiXComponentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			switch (RnaStrumentiXComponentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaStrumentiXComponentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaStrumentiXComponentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaStrumentiXComponentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaStrumentiXComponentiUpdate", new string[] {"IdStrumentiXComponenti", "IdComponentiXCodifica", "CodTipoStrumentoAiuto", 
"IntensitaStrumento"}, new string[] {"int", "int", "int", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaStrumentiXComponentiInsert", new string[] {"IdComponentiXCodifica", "CodTipoStrumentoAiuto", 
"IntensitaStrumento"}, new string[] {"int", "int", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaStrumentiXComponentiDelete", new string[] {"IdStrumentiXComponenti"}, new string[] {"int"},"");
				for (int i = 0; i < RnaStrumentiXComponentiCollectionObj.Count; i++)
				{
					switch (RnaStrumentiXComponentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaStrumentiXComponentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaStrumentiXComponentiCollectionObj[i].IdStrumentiXComponenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STRUMENTI_X_COMPONENTI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaStrumentiXComponentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaStrumentiXComponentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStrumentiXComponenti", (SiarLibrary.NullTypes.IntNT)RnaStrumentiXComponentiCollectionObj[i].IdStrumentiXComponenti);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaStrumentiXComponentiCollectionObj.Count; i++)
				{
					if ((RnaStrumentiXComponentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaStrumentiXComponentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaStrumentiXComponentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaStrumentiXComponentiCollectionObj[i].IsDirty = false;
						RnaStrumentiXComponentiCollectionObj[i].IsPersistent = true;
					}
					if ((RnaStrumentiXComponentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaStrumentiXComponentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaStrumentiXComponentiCollectionObj[i].IsDirty = false;
						RnaStrumentiXComponentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaStrumentiXComponenti RnaStrumentiXComponentiObj)
		{
			int returnValue = 0;
			if (RnaStrumentiXComponentiObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaStrumentiXComponentiObj.IdStrumentiXComponenti);
			}
			RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaStrumentiXComponentiObj.IsDirty = false;
			RnaStrumentiXComponentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdStrumentiXComponentiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaStrumentiXComponentiDelete", new string[] {"IdStrumentiXComponenti"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStrumentiXComponenti", (SiarLibrary.NullTypes.IntNT)IdStrumentiXComponentiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaStrumentiXComponentiDelete", new string[] {"IdStrumentiXComponenti"}, new string[] {"int"},"");
				for (int i = 0; i < RnaStrumentiXComponentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStrumentiXComponenti", RnaStrumentiXComponentiCollectionObj[i].IdStrumentiXComponenti);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaStrumentiXComponentiCollectionObj.Count; i++)
				{
					if ((RnaStrumentiXComponentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaStrumentiXComponentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaStrumentiXComponentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaStrumentiXComponentiCollectionObj[i].IsDirty = false;
						RnaStrumentiXComponentiCollectionObj[i].IsPersistent = false;
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
		public static RnaStrumentiXComponenti GetById(DbProvider db, int IdStrumentiXComponentiValue)
		{
			RnaStrumentiXComponenti RnaStrumentiXComponentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaStrumentiXComponentiGetById", new string[] {"IdStrumentiXComponenti"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdStrumentiXComponenti", (SiarLibrary.NullTypes.IntNT)IdStrumentiXComponentiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaStrumentiXComponentiObj = GetFromDatareader(db);
				RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaStrumentiXComponentiObj.IsDirty = false;
				RnaStrumentiXComponentiObj.IsPersistent = true;
			}
			db.Close();
			return RnaStrumentiXComponentiObj;
		}

		//getFromDatareader
		public static RnaStrumentiXComponenti GetFromDatareader(DbProvider db)
		{
			RnaStrumentiXComponenti RnaStrumentiXComponentiObj = new RnaStrumentiXComponenti();
			RnaStrumentiXComponentiObj.IdStrumentiXComponenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STRUMENTI_X_COMPONENTI"]);
			RnaStrumentiXComponentiObj.IdComponentiXCodifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMPONENTI_X_CODIFICA"]);
			RnaStrumentiXComponentiObj.CodTipoStrumentoAiuto = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_STRUMENTO_AIUTO"]);
			RnaStrumentiXComponentiObj.IntensitaStrumento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["INTENSITA_STRUMENTO"]);
			RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaStrumentiXComponentiObj.IsDirty = false;
			RnaStrumentiXComponentiObj.IsPersistent = true;
			return RnaStrumentiXComponentiObj;
		}

		//Find Select

		public static RnaStrumentiXComponentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdStrumentiXComponentiEqualThis, SiarLibrary.NullTypes.IntNT IdComponentiXCodificaEqualThis, SiarLibrary.NullTypes.IntNT CodTipoStrumentoAiutoEqualThis, 
SiarLibrary.NullTypes.DecimalNT IntensitaStrumentoEqualThis)

		{

			RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionObj = new RnaStrumentiXComponentiCollection();

			IDbCommand findCmd = db.InitCmd("Zrnastrumentixcomponentifindselect", new string[] {"IdStrumentiXComponentiequalthis", "IdComponentiXCodificaequalthis", "CodTipoStrumentoAiutoequalthis", 
"IntensitaStrumentoequalthis"}, new string[] {"int", "int", "int", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStrumentiXComponentiequalthis", IdStrumentiXComponentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComponentiXCodificaequalthis", IdComponentiXCodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoStrumentoAiutoequalthis", CodTipoStrumentoAiutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntensitaStrumentoequalthis", IntensitaStrumentoEqualThis);
			RnaStrumentiXComponenti RnaStrumentiXComponentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaStrumentiXComponentiObj = GetFromDatareader(db);
				RnaStrumentiXComponentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaStrumentiXComponentiObj.IsDirty = false;
				RnaStrumentiXComponentiObj.IsPersistent = true;
				RnaStrumentiXComponentiCollectionObj.Add(RnaStrumentiXComponentiObj);
			}
			db.Close();
			return RnaStrumentiXComponentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaStrumentiXComponentiCollectionProvider:IRnaStrumentiXComponentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaStrumentiXComponentiCollectionProvider : IRnaStrumentiXComponentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaStrumentiXComponenti
		protected RnaStrumentiXComponentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaStrumentiXComponentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaStrumentiXComponentiCollection(this);
		}

		//Costruttore3: ha in input rnastrumentixcomponentiCollectionObj - non popola la collection
		public RnaStrumentiXComponentiCollectionProvider(RnaStrumentiXComponentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaStrumentiXComponentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaStrumentiXComponentiCollection(this);
		}

		//Get e Set
		public RnaStrumentiXComponentiCollection CollectionObj
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
		public int SaveCollection(RnaStrumentiXComponentiCollection collectionObj)
		{
			return RnaStrumentiXComponentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaStrumentiXComponenti rnastrumentixcomponentiObj)
		{
			return RnaStrumentiXComponentiDAL.Save(_dbProviderObj, rnastrumentixcomponentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaStrumentiXComponentiCollection collectionObj)
		{
			return RnaStrumentiXComponentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaStrumentiXComponenti rnastrumentixcomponentiObj)
		{
			return RnaStrumentiXComponentiDAL.Delete(_dbProviderObj, rnastrumentixcomponentiObj);
		}

		//getById
		public RnaStrumentiXComponenti GetById(IntNT IdStrumentiXComponentiValue)
		{
			RnaStrumentiXComponenti RnaStrumentiXComponentiTemp = RnaStrumentiXComponentiDAL.GetById(_dbProviderObj, IdStrumentiXComponentiValue);
			if (RnaStrumentiXComponentiTemp!=null) RnaStrumentiXComponentiTemp.Provider = this;
			return RnaStrumentiXComponentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaStrumentiXComponentiCollection Select(IntNT IdstrumentixcomponentiEqualThis, IntNT IdcomponentixcodificaEqualThis, IntNT CodtipostrumentoaiutoEqualThis, 
DecimalNT IntensitastrumentoEqualThis)
		{
			RnaStrumentiXComponentiCollection RnaStrumentiXComponentiCollectionTemp = RnaStrumentiXComponentiDAL.Select(_dbProviderObj, IdstrumentixcomponentiEqualThis, IdcomponentixcodificaEqualThis, CodtipostrumentoaiutoEqualThis, 
IntensitastrumentoEqualThis);
			RnaStrumentiXComponentiCollectionTemp.Provider = this;
			return RnaStrumentiXComponentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_STRUMENTI_X_COMPONENTI>
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
</RNA_STRUMENTI_X_COMPONENTI>
*/
