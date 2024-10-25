using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaBandoConfig
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaBandoConfigProvider
	{
		int Save(RnaBandoConfig RnaBandoConfigObj);
		int SaveCollection(RnaBandoConfigCollection collectionObj);
		int Delete(RnaBandoConfig RnaBandoConfigObj);
		int DeleteCollection(RnaBandoConfigCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaBandoConfig
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaBandoConfig: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaBandoConfig;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _CodBandoRna;
		private NullTypes.DatetimeNT _DataPrevistaConcessione;
		private NullTypes.StringNT _Cumulabilita;
		private NullTypes.IntNT _CodBandoRnaCollaudo;
		private NullTypes.IntNT _IdRnaEnte;
		[NonSerialized] private IRnaBandoConfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaBandoConfigProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaBandoConfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_BANDO_CONFIG
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaBandoConfig
		{
			get { return _IdRnaBandoConfig; }
			set {
				if (IdRnaBandoConfig != value)
				{
					_IdRnaBandoConfig = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:COD_BANDO_RNA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodBandoRna
		{
			get { return _CodBandoRna; }
			set {
				if (CodBandoRna != value)
				{
					_CodBandoRna = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PREVISTA_CONCESSIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPrevistaConcessione
		{
			get { return _DataPrevistaConcessione; }
			set {
				if (DataPrevistaConcessione != value)
				{
					_DataPrevistaConcessione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUMULABILITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Cumulabilita
		{
			get { return _Cumulabilita; }
			set {
				if (Cumulabilita != value)
				{
					_Cumulabilita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_BANDO_RNA_COLLAUDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodBandoRnaCollaudo
		{
			get { return _CodBandoRnaCollaudo; }
			set {
				if (CodBandoRnaCollaudo != value)
				{
					_CodBandoRnaCollaudo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RNA_ENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaEnte
		{
			get { return _IdRnaEnte; }
			set {
				if (IdRnaEnte != value)
				{
					_IdRnaEnte = value;
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
	/// Summary description for RnaBandoConfigCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaBandoConfigCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaBandoConfigCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaBandoConfig) info.GetValue(i.ToString(),typeof(RnaBandoConfig)));
			}
		}

		//Costruttore
		public RnaBandoConfigCollection()
		{
			this.ItemType = typeof(RnaBandoConfig);
		}

		//Costruttore con provider
		public RnaBandoConfigCollection(IRnaBandoConfigProvider providerObj)
		{
			this.ItemType = typeof(RnaBandoConfig);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaBandoConfig this[int index]
		{
			get { return (RnaBandoConfig)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaBandoConfigCollection GetChanges()
		{
			return (RnaBandoConfigCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaBandoConfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaBandoConfigProvider Provider
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
		public int Add(RnaBandoConfig RnaBandoConfigObj)
		{
			if (RnaBandoConfigObj.Provider == null) RnaBandoConfigObj.Provider = this.Provider;
			return base.Add(RnaBandoConfigObj);
		}

		//AddCollection
		public void AddCollection(RnaBandoConfigCollection RnaBandoConfigCollectionObj)
		{
			foreach (RnaBandoConfig RnaBandoConfigObj in RnaBandoConfigCollectionObj)
				this.Add(RnaBandoConfigObj);
		}

		//Insert
		public void Insert(int index, RnaBandoConfig RnaBandoConfigObj)
		{
			if (RnaBandoConfigObj.Provider == null) RnaBandoConfigObj.Provider = this.Provider;
			base.Insert(index, RnaBandoConfigObj);
		}

		//CollectionGetById
		public RnaBandoConfig CollectionGetById(NullTypes.IntNT IdRnaBandoConfigValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRnaBandoConfig == IdRnaBandoConfigValue))
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
		public RnaBandoConfigCollection SubSelect(NullTypes.IntNT IdRnaBandoConfigEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT CodBandoRnaEqualThis, 
NullTypes.DatetimeNT DataPrevistaConcessioneEqualThis, NullTypes.StringNT CumulabilitaEqualThis, NullTypes.IntNT CodBandoRnaCollaudoEqualThis, 
NullTypes.IntNT IdRnaEnteEqualThis)
		{
			RnaBandoConfigCollection RnaBandoConfigCollectionTemp = new RnaBandoConfigCollection();
			foreach (RnaBandoConfig RnaBandoConfigItem in this)
			{
				if (((IdRnaBandoConfigEqualThis == null) || ((RnaBandoConfigItem.IdRnaBandoConfig != null) && (RnaBandoConfigItem.IdRnaBandoConfig.Value == IdRnaBandoConfigEqualThis.Value))) && ((IdBandoEqualThis == null) || ((RnaBandoConfigItem.IdBando != null) && (RnaBandoConfigItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodBandoRnaEqualThis == null) || ((RnaBandoConfigItem.CodBandoRna != null) && (RnaBandoConfigItem.CodBandoRna.Value == CodBandoRnaEqualThis.Value))) && 
((DataPrevistaConcessioneEqualThis == null) || ((RnaBandoConfigItem.DataPrevistaConcessione != null) && (RnaBandoConfigItem.DataPrevistaConcessione.Value == DataPrevistaConcessioneEqualThis.Value))) && ((CumulabilitaEqualThis == null) || ((RnaBandoConfigItem.Cumulabilita != null) && (RnaBandoConfigItem.Cumulabilita.Value == CumulabilitaEqualThis.Value))) && ((CodBandoRnaCollaudoEqualThis == null) || ((RnaBandoConfigItem.CodBandoRnaCollaudo != null) && (RnaBandoConfigItem.CodBandoRnaCollaudo.Value == CodBandoRnaCollaudoEqualThis.Value))) && 
((IdRnaEnteEqualThis == null) || ((RnaBandoConfigItem.IdRnaEnte != null) && (RnaBandoConfigItem.IdRnaEnte.Value == IdRnaEnteEqualThis.Value))))
				{
					RnaBandoConfigCollectionTemp.Add(RnaBandoConfigItem);
				}
			}
			return RnaBandoConfigCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaBandoConfigDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaBandoConfigDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaBandoConfig RnaBandoConfigObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRnaBandoConfig", RnaBandoConfigObj.IdRnaBandoConfig);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", RnaBandoConfigObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodBandoRna", RnaBandoConfigObj.CodBandoRna);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPrevistaConcessione", RnaBandoConfigObj.DataPrevistaConcessione);
			DbProvider.SetCmdParam(cmd,firstChar + "Cumulabilita", RnaBandoConfigObj.Cumulabilita);
			DbProvider.SetCmdParam(cmd,firstChar + "CodBandoRnaCollaudo", RnaBandoConfigObj.CodBandoRnaCollaudo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRnaEnte", RnaBandoConfigObj.IdRnaEnte);
		}
		//Insert
		private static int Insert(DbProvider db, RnaBandoConfig RnaBandoConfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaBandoConfigInsert", new string[] {"IdBando", "CodBandoRna", 
"DataPrevistaConcessione", "Cumulabilita", "CodBandoRnaCollaudo", 
"IdRnaEnte"}, new string[] {"int", "int", 
"DateTime", "string", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,RnaBandoConfigObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaBandoConfigObj.IdRnaBandoConfig = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_BANDO_CONFIG"]);
				}
				RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaBandoConfigObj.IsDirty = false;
				RnaBandoConfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaBandoConfig RnaBandoConfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaBandoConfigUpdate", new string[] {"IdRnaBandoConfig", "IdBando", "CodBandoRna", 
"DataPrevistaConcessione", "Cumulabilita", "CodBandoRnaCollaudo", 
"IdRnaEnte"}, new string[] {"int", "int", "int", 
"DateTime", "string", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,RnaBandoConfigObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaBandoConfigObj.IsDirty = false;
				RnaBandoConfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaBandoConfig RnaBandoConfigObj)
		{
			switch (RnaBandoConfigObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaBandoConfigObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaBandoConfigObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaBandoConfigObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaBandoConfigCollection RnaBandoConfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaBandoConfigUpdate", new string[] {"IdRnaBandoConfig", "IdBando", "CodBandoRna", 
"DataPrevistaConcessione", "Cumulabilita", "CodBandoRnaCollaudo", 
"IdRnaEnte"}, new string[] {"int", "int", "int", 
"DateTime", "string", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaBandoConfigInsert", new string[] {"IdBando", "CodBandoRna", 
"DataPrevistaConcessione", "Cumulabilita", "CodBandoRnaCollaudo", 
"IdRnaEnte"}, new string[] {"int", "int", 
"DateTime", "string", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaBandoConfigDelete", new string[] {"IdRnaBandoConfig"}, new string[] {"int"},"");
				for (int i = 0; i < RnaBandoConfigCollectionObj.Count; i++)
				{
					switch (RnaBandoConfigCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaBandoConfigCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaBandoConfigCollectionObj[i].IdRnaBandoConfig = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_BANDO_CONFIG"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaBandoConfigCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaBandoConfigCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaBandoConfig", (SiarLibrary.NullTypes.IntNT)RnaBandoConfigCollectionObj[i].IdRnaBandoConfig);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaBandoConfigCollectionObj.Count; i++)
				{
					if ((RnaBandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaBandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaBandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaBandoConfigCollectionObj[i].IsDirty = false;
						RnaBandoConfigCollectionObj[i].IsPersistent = true;
					}
					if ((RnaBandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaBandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaBandoConfigCollectionObj[i].IsDirty = false;
						RnaBandoConfigCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaBandoConfig RnaBandoConfigObj)
		{
			int returnValue = 0;
			if (RnaBandoConfigObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaBandoConfigObj.IdRnaBandoConfig);
			}
			RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaBandoConfigObj.IsDirty = false;
			RnaBandoConfigObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRnaBandoConfigValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaBandoConfigDelete", new string[] {"IdRnaBandoConfig"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaBandoConfig", (SiarLibrary.NullTypes.IntNT)IdRnaBandoConfigValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaBandoConfigCollection RnaBandoConfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaBandoConfigDelete", new string[] {"IdRnaBandoConfig"}, new string[] {"int"},"");
				for (int i = 0; i < RnaBandoConfigCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaBandoConfig", RnaBandoConfigCollectionObj[i].IdRnaBandoConfig);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaBandoConfigCollectionObj.Count; i++)
				{
					if ((RnaBandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaBandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaBandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaBandoConfigCollectionObj[i].IsDirty = false;
						RnaBandoConfigCollectionObj[i].IsPersistent = false;
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
		public static RnaBandoConfig GetById(DbProvider db, int IdRnaBandoConfigValue)
		{
			RnaBandoConfig RnaBandoConfigObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaBandoConfigGetById", new string[] {"IdRnaBandoConfig"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRnaBandoConfig", (SiarLibrary.NullTypes.IntNT)IdRnaBandoConfigValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaBandoConfigObj = GetFromDatareader(db);
				RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaBandoConfigObj.IsDirty = false;
				RnaBandoConfigObj.IsPersistent = true;
			}
			db.Close();
			return RnaBandoConfigObj;
		}

		//getFromDatareader
		public static RnaBandoConfig GetFromDatareader(DbProvider db)
		{
			RnaBandoConfig RnaBandoConfigObj = new RnaBandoConfig();
			RnaBandoConfigObj.IdRnaBandoConfig = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_BANDO_CONFIG"]);
			RnaBandoConfigObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			RnaBandoConfigObj.CodBandoRna = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_BANDO_RNA"]);
			RnaBandoConfigObj.DataPrevistaConcessione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PREVISTA_CONCESSIONE"]);
			RnaBandoConfigObj.Cumulabilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUMULABILITA"]);
			RnaBandoConfigObj.CodBandoRnaCollaudo = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_BANDO_RNA_COLLAUDO"]);
			RnaBandoConfigObj.IdRnaEnte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_ENTE"]);
			RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaBandoConfigObj.IsDirty = false;
			RnaBandoConfigObj.IsPersistent = true;
			return RnaBandoConfigObj;
		}

		//Find Select

		public static RnaBandoConfigCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaBandoConfigEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT CodBandoRnaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataPrevistaConcessioneEqualThis, SiarLibrary.NullTypes.StringNT CumulabilitaEqualThis, SiarLibrary.NullTypes.IntNT CodBandoRnaCollaudoEqualThis, 
SiarLibrary.NullTypes.IntNT IdRnaEnteEqualThis)

		{

			RnaBandoConfigCollection RnaBandoConfigCollectionObj = new RnaBandoConfigCollection();

			IDbCommand findCmd = db.InitCmd("Zrnabandoconfigfindselect", new string[] {"IdRnaBandoConfigequalthis", "IdBandoequalthis", "CodBandoRnaequalthis", 
"DataPrevistaConcessioneequalthis", "Cumulabilitaequalthis", "CodBandoRnaCollaudoequalthis", 
"IdRnaEnteequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "string", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaBandoConfigequalthis", IdRnaBandoConfigEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodBandoRnaequalthis", CodBandoRnaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPrevistaConcessioneequalthis", DataPrevistaConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cumulabilitaequalthis", CumulabilitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodBandoRnaCollaudoequalthis", CodBandoRnaCollaudoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaEnteequalthis", IdRnaEnteEqualThis);
			RnaBandoConfig RnaBandoConfigObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaBandoConfigObj = GetFromDatareader(db);
				RnaBandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaBandoConfigObj.IsDirty = false;
				RnaBandoConfigObj.IsPersistent = true;
				RnaBandoConfigCollectionObj.Add(RnaBandoConfigObj);
			}
			db.Close();
			return RnaBandoConfigCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaBandoConfigCollectionProvider:IRnaBandoConfigProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaBandoConfigCollectionProvider : IRnaBandoConfigProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaBandoConfig
		protected RnaBandoConfigCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaBandoConfigCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaBandoConfigCollection(this);
		}

		//Costruttore3: ha in input rnabandoconfigCollectionObj - non popola la collection
		public RnaBandoConfigCollectionProvider(RnaBandoConfigCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaBandoConfigCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaBandoConfigCollection(this);
		}

		//Get e Set
		public RnaBandoConfigCollection CollectionObj
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
		public int SaveCollection(RnaBandoConfigCollection collectionObj)
		{
			return RnaBandoConfigDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaBandoConfig rnabandoconfigObj)
		{
			return RnaBandoConfigDAL.Save(_dbProviderObj, rnabandoconfigObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaBandoConfigCollection collectionObj)
		{
			return RnaBandoConfigDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaBandoConfig rnabandoconfigObj)
		{
			return RnaBandoConfigDAL.Delete(_dbProviderObj, rnabandoconfigObj);
		}

		//getById
		public RnaBandoConfig GetById(IntNT IdRnaBandoConfigValue)
		{
			RnaBandoConfig RnaBandoConfigTemp = RnaBandoConfigDAL.GetById(_dbProviderObj, IdRnaBandoConfigValue);
			if (RnaBandoConfigTemp!=null) RnaBandoConfigTemp.Provider = this;
			return RnaBandoConfigTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaBandoConfigCollection Select(IntNT IdrnabandoconfigEqualThis, IntNT IdbandoEqualThis, IntNT CodbandornaEqualThis, 
DatetimeNT DataprevistaconcessioneEqualThis, StringNT CumulabilitaEqualThis, IntNT CodbandornacollaudoEqualThis, 
IntNT IdrnaenteEqualThis)
		{
			RnaBandoConfigCollection RnaBandoConfigCollectionTemp = RnaBandoConfigDAL.Select(_dbProviderObj, IdrnabandoconfigEqualThis, IdbandoEqualThis, CodbandornaEqualThis, 
DataprevistaconcessioneEqualThis, CumulabilitaEqualThis, CodbandornacollaudoEqualThis, 
IdrnaenteEqualThis);
			RnaBandoConfigCollectionTemp.Provider = this;
			return RnaBandoConfigCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_BANDO_CONFIG>
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
</RNA_BANDO_CONFIG>
*/
