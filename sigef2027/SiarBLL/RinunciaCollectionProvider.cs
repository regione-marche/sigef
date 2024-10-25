using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Rinuncia
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRinunciaProvider
	{
		int Save(Rinuncia RinunciaObj);
		int SaveCollection(RinunciaCollection collectionObj);
		int Delete(Rinuncia RinunciaObj);
		int DeleteCollection(RinunciaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Rinuncia
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Rinuncia: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRinuncia;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataRinuncia;
		private NullTypes.StringNT _TipoRinuncia;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private IRinunciaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Rinuncia()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RINUNCIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRinuncia
		{
			get { return _IdRinuncia; }
			set {
				if (IdRinuncia != value)
				{
					_IdRinuncia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RINUNCIA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRinuncia
		{
			get { return _DataRinuncia; }
			set {
				if (DataRinuncia != value)
				{
					_DataRinuncia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_RINUNCIA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoRinuncia
		{
			get { return _TipoRinuncia; }
			set {
				if (TipoRinuncia != value)
				{
					_TipoRinuncia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
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
	/// Summary description for RinunciaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RinunciaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Rinuncia) info.GetValue(i.ToString(),typeof(Rinuncia)));
			}
		}

		//Costruttore
		public RinunciaCollection()
		{
			this.ItemType = typeof(Rinuncia);
		}

		//Costruttore con provider
		public RinunciaCollection(IRinunciaProvider providerObj)
		{
			this.ItemType = typeof(Rinuncia);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Rinuncia this[int index]
		{
			get { return (Rinuncia)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RinunciaCollection GetChanges()
		{
			return (RinunciaCollection) base.GetChanges();
		}

		[NonSerialized] private IRinunciaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRinunciaProvider Provider
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
		public int Add(Rinuncia RinunciaObj)
		{
			if (RinunciaObj.Provider == null) RinunciaObj.Provider = this.Provider;
			return base.Add(RinunciaObj);
		}

		//AddCollection
		public void AddCollection(RinunciaCollection RinunciaCollectionObj)
		{
			foreach (Rinuncia RinunciaObj in RinunciaCollectionObj)
				this.Add(RinunciaObj);
		}

		//Insert
		public void Insert(int index, Rinuncia RinunciaObj)
		{
			if (RinunciaObj.Provider == null) RinunciaObj.Provider = this.Provider;
			base.Insert(index, RinunciaObj);
		}

		//CollectionGetById
		public Rinuncia CollectionGetById(NullTypes.IntNT IdRinunciaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRinuncia == IdRinunciaValue))
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
		public RinunciaCollection SubSelect(NullTypes.IntNT IdRinunciaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.DatetimeNT DataRinunciaEqualThis, 
NullTypes.StringNT TipoRinunciaEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.StringNT CfModificaEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			RinunciaCollection RinunciaCollectionTemp = new RinunciaCollection();
			foreach (Rinuncia RinunciaItem in this)
			{
				if (((IdRinunciaEqualThis == null) || ((RinunciaItem.IdRinuncia != null) && (RinunciaItem.IdRinuncia.Value == IdRinunciaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RinunciaItem.IdProgetto != null) && (RinunciaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((DataRinunciaEqualThis == null) || ((RinunciaItem.DataRinuncia != null) && (RinunciaItem.DataRinuncia.Value == DataRinunciaEqualThis.Value))) && 
((TipoRinunciaEqualThis == null) || ((RinunciaItem.TipoRinuncia != null) && (RinunciaItem.TipoRinuncia.Value == TipoRinunciaEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((RinunciaItem.CfInserimento != null) && (RinunciaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((CfModificaEqualThis == null) || ((RinunciaItem.CfModifica != null) && (RinunciaItem.CfModifica.Value == CfModificaEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((RinunciaItem.DataModifica != null) && (RinunciaItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					RinunciaCollectionTemp.Add(RinunciaItem);
				}
			}
			return RinunciaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RinunciaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RinunciaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Rinuncia RinunciaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRinuncia", RinunciaObj.IdRinuncia);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", RinunciaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRinuncia", RinunciaObj.DataRinuncia);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoRinuncia", RinunciaObj.TipoRinuncia);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", RinunciaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", RinunciaObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", RinunciaObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, Rinuncia RinunciaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaInsert", new string[] {"IdProgetto", "DataRinuncia", 
"TipoRinuncia", "CfInserimento", "CfModifica", 
"DataModifica"}, new string[] {"int", "DateTime", 
"string", "string", "string", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,RinunciaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RinunciaObj.IdRinuncia = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA"]);
				RinunciaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				RinunciaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaObj.IsDirty = false;
				RinunciaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Rinuncia RinunciaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaUpdate", new string[] {"IdRinuncia", "IdProgetto", "DataRinuncia", 
"TipoRinuncia", "CfInserimento", "CfModifica", 
"DataModifica"}, new string[] {"int", "int", "DateTime", 
"string", "string", "string", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,RinunciaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RinunciaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaObj.IsDirty = false;
				RinunciaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Rinuncia RinunciaObj)
		{
			switch (RinunciaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RinunciaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RinunciaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RinunciaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RinunciaCollection RinunciaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRinunciaUpdate", new string[] {"IdRinuncia", "IdProgetto", "DataRinuncia", 
"TipoRinuncia", "CfInserimento", "CfModifica", 
"DataModifica"}, new string[] {"int", "int", "DateTime", 
"string", "string", "string", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRinunciaInsert", new string[] {"IdProgetto", "DataRinuncia", 
"TipoRinuncia", "CfInserimento", "CfModifica", 
"DataModifica"}, new string[] {"int", "DateTime", 
"string", "string", "string", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaDelete", new string[] {"IdRinuncia"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaCollectionObj.Count; i++)
				{
					switch (RinunciaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RinunciaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RinunciaCollectionObj[i].IdRinuncia = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA"]);
									RinunciaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RinunciaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RinunciaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinuncia", (SiarLibrary.NullTypes.IntNT)RinunciaCollectionObj[i].IdRinuncia);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RinunciaCollectionObj.Count; i++)
				{
					if ((RinunciaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RinunciaCollectionObj[i].IsDirty = false;
						RinunciaCollectionObj[i].IsPersistent = true;
					}
					if ((RinunciaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RinunciaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaCollectionObj[i].IsDirty = false;
						RinunciaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Rinuncia RinunciaObj)
		{
			int returnValue = 0;
			if (RinunciaObj.IsPersistent) 
			{
				returnValue = Delete(db, RinunciaObj.IdRinuncia);
			}
			RinunciaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RinunciaObj.IsDirty = false;
			RinunciaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRinunciaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaDelete", new string[] {"IdRinuncia"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinuncia", (SiarLibrary.NullTypes.IntNT)IdRinunciaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RinunciaCollection RinunciaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRinunciaDelete", new string[] {"IdRinuncia"}, new string[] {"int"},"");
				for (int i = 0; i < RinunciaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRinuncia", RinunciaCollectionObj[i].IdRinuncia);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RinunciaCollectionObj.Count; i++)
				{
					if ((RinunciaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RinunciaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RinunciaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RinunciaCollectionObj[i].IsDirty = false;
						RinunciaCollectionObj[i].IsPersistent = false;
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
		public static Rinuncia GetById(DbProvider db, int IdRinunciaValue)
		{
			Rinuncia RinunciaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRinunciaGetById", new string[] {"IdRinuncia"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRinuncia", (SiarLibrary.NullTypes.IntNT)IdRinunciaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RinunciaObj = GetFromDatareader(db);
				RinunciaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaObj.IsDirty = false;
				RinunciaObj.IsPersistent = true;
			}
			db.Close();
			return RinunciaObj;
		}

		//getFromDatareader
		public static Rinuncia GetFromDatareader(DbProvider db)
		{
			Rinuncia RinunciaObj = new Rinuncia();
			RinunciaObj.IdRinuncia = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RINUNCIA"]);
			RinunciaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RinunciaObj.DataRinuncia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RINUNCIA"]);
			RinunciaObj.TipoRinuncia = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_RINUNCIA"]);
			RinunciaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			RinunciaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			RinunciaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			RinunciaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RinunciaObj.IsDirty = false;
			RinunciaObj.IsPersistent = true;
			return RinunciaObj;
		}

		//Find Select

		public static RinunciaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRinunciaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRinunciaEqualThis, 
SiarLibrary.NullTypes.StringNT TipoRinunciaEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			RinunciaCollection RinunciaCollectionObj = new RinunciaCollection();

			IDbCommand findCmd = db.InitCmd("Zrinunciafindselect", new string[] {"IdRinunciaequalthis", "IdProgettoequalthis", "DataRinunciaequalthis", 
"TipoRinunciaequalthis", "CfInserimentoequalthis", "CfModificaequalthis", 
"DataModificaequalthis"}, new string[] {"int", "int", "DateTime", 
"string", "string", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRinunciaequalthis", IdRinunciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRinunciaequalthis", DataRinunciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoRinunciaequalthis", TipoRinunciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			Rinuncia RinunciaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RinunciaObj = GetFromDatareader(db);
				RinunciaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RinunciaObj.IsDirty = false;
				RinunciaObj.IsPersistent = true;
				RinunciaCollectionObj.Add(RinunciaObj);
			}
			db.Close();
			return RinunciaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RinunciaCollectionProvider:IRinunciaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RinunciaCollectionProvider : IRinunciaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Rinuncia
		protected RinunciaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RinunciaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RinunciaCollection(this);
		}

		//Costruttore3: ha in input rinunciaCollectionObj - non popola la collection
		public RinunciaCollectionProvider(RinunciaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RinunciaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RinunciaCollection(this);
		}

		//Get e Set
		public RinunciaCollection CollectionObj
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
		public int SaveCollection(RinunciaCollection collectionObj)
		{
			return RinunciaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Rinuncia rinunciaObj)
		{
			return RinunciaDAL.Save(_dbProviderObj, rinunciaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RinunciaCollection collectionObj)
		{
			return RinunciaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Rinuncia rinunciaObj)
		{
			return RinunciaDAL.Delete(_dbProviderObj, rinunciaObj);
		}

		//getById
		public Rinuncia GetById(IntNT IdRinunciaValue)
		{
			Rinuncia RinunciaTemp = RinunciaDAL.GetById(_dbProviderObj, IdRinunciaValue);
			if (RinunciaTemp!=null) RinunciaTemp.Provider = this;
			return RinunciaTemp;
		}

		//Select: popola la collection
		public RinunciaCollection Select(IntNT IdrinunciaEqualThis, IntNT IdprogettoEqualThis, DatetimeNT DatarinunciaEqualThis, 
StringNT TiporinunciaEqualThis, StringNT CfinserimentoEqualThis, StringNT CfmodificaEqualThis, 
DatetimeNT DatamodificaEqualThis)
		{
			RinunciaCollection RinunciaCollectionTemp = RinunciaDAL.Select(_dbProviderObj, IdrinunciaEqualThis, IdprogettoEqualThis, DatarinunciaEqualThis, 
TiporinunciaEqualThis, CfinserimentoEqualThis, CfmodificaEqualThis, 
DatamodificaEqualThis);
			RinunciaCollectionTemp.Provider = this;
			return RinunciaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RINUNCIA>
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
</RINUNCIA>
*/
