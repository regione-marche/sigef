using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BancheIstituti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBancheIstitutiProvider
	{
		int Save(BancheIstituti BancheIstitutiObj);
		int SaveCollection(BancheIstitutiCollection collectionObj);
		int Delete(BancheIstituti BancheIstitutiObj);
		int DeleteCollection(BancheIstitutiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BancheIstituti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BancheIstituti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Abi;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IBancheIstitutiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBancheIstitutiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BancheIstituti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ABI
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT Abi
		{
			get { return _Abi; }
			set {
				if (Abi != value)
				{
					_Abi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
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
	/// Summary description for BancheIstitutiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BancheIstitutiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BancheIstitutiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BancheIstituti) info.GetValue(i.ToString(),typeof(BancheIstituti)));
			}
		}

		//Costruttore
		public BancheIstitutiCollection()
		{
			this.ItemType = typeof(BancheIstituti);
		}

		//Costruttore con provider
		public BancheIstitutiCollection(IBancheIstitutiProvider providerObj)
		{
			this.ItemType = typeof(BancheIstituti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BancheIstituti this[int index]
		{
			get { return (BancheIstituti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BancheIstitutiCollection GetChanges()
		{
			return (BancheIstitutiCollection) base.GetChanges();
		}

		[NonSerialized] private IBancheIstitutiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBancheIstitutiProvider Provider
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
		public int Add(BancheIstituti BancheIstitutiObj)
		{
			if (BancheIstitutiObj.Provider == null) BancheIstitutiObj.Provider = this.Provider;
			return base.Add(BancheIstitutiObj);
		}

		//AddCollection
		public void AddCollection(BancheIstitutiCollection BancheIstitutiCollectionObj)
		{
			foreach (BancheIstituti BancheIstitutiObj in BancheIstitutiCollectionObj)
				this.Add(BancheIstitutiObj);
		}

		//Insert
		public void Insert(int index, BancheIstituti BancheIstitutiObj)
		{
			if (BancheIstitutiObj.Provider == null) BancheIstitutiObj.Provider = this.Provider;
			base.Insert(index, BancheIstitutiObj);
		}

		//CollectionGetById
		public BancheIstituti CollectionGetById(NullTypes.StringNT AbiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Abi == AbiValue))
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
		public BancheIstitutiCollection SubSelect(NullTypes.StringNT AbiEqualThis, NullTypes.StringNT DenominazioneEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			BancheIstitutiCollection BancheIstitutiCollectionTemp = new BancheIstitutiCollection();
			foreach (BancheIstituti BancheIstitutiItem in this)
			{
				if (((AbiEqualThis == null) || ((BancheIstitutiItem.Abi != null) && (BancheIstitutiItem.Abi.Value == AbiEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((BancheIstitutiItem.Denominazione != null) && (BancheIstitutiItem.Denominazione.Value == DenominazioneEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((BancheIstitutiItem.DataInizioValidita != null) && (BancheIstitutiItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && 
((DataFineValiditaEqualThis == null) || ((BancheIstitutiItem.DataFineValidita != null) && (BancheIstitutiItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((AttivoEqualThis == null) || ((BancheIstitutiItem.Attivo != null) && (BancheIstitutiItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					BancheIstitutiCollectionTemp.Add(BancheIstitutiItem);
				}
			}
			return BancheIstitutiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BancheIstitutiCollection Filter(NullTypes.BoolNT AttivoEqualThis)
		{
			BancheIstitutiCollection BancheIstitutiCollectionTemp = new BancheIstitutiCollection();
			foreach (BancheIstituti BancheIstitutiItem in this)
			{
				if (((AttivoEqualThis == null) || ((BancheIstitutiItem.Attivo != null) && (BancheIstitutiItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					BancheIstitutiCollectionTemp.Add(BancheIstitutiItem);
				}
			}
			return BancheIstitutiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BancheIstitutiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BancheIstitutiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BancheIstituti BancheIstitutiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Abi", BancheIstitutiObj.Abi);
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", BancheIstitutiObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", BancheIstitutiObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", BancheIstitutiObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BancheIstitutiObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, BancheIstituti BancheIstitutiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBancheIstitutiInsert", new string[] {"Abi", "Denominazione", "DataInizioValidita", 
"DataFineValidita", "Attivo"}, new string[] {"string", "string", "DateTime", 
"DateTime", "bool"},"");
				CompileIUCmd(false, insertCmd,BancheIstitutiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BancheIstitutiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheIstitutiObj.IsDirty = false;
				BancheIstitutiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BancheIstituti BancheIstitutiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBancheIstitutiUpdate", new string[] {"Abi", "Denominazione", "DataInizioValidita", 
"DataFineValidita", "Attivo"}, new string[] {"string", "string", "DateTime", 
"DateTime", "bool"},"");
				CompileIUCmd(true, updateCmd,BancheIstitutiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheIstitutiObj.IsDirty = false;
				BancheIstitutiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BancheIstituti BancheIstitutiObj)
		{
			switch (BancheIstitutiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BancheIstitutiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BancheIstitutiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BancheIstitutiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BancheIstitutiCollection BancheIstitutiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBancheIstitutiUpdate", new string[] {"Abi", "Denominazione", "DataInizioValidita", 
"DataFineValidita", "Attivo"}, new string[] {"string", "string", "DateTime", 
"DateTime", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBancheIstitutiInsert", new string[] {"Abi", "Denominazione", "DataInizioValidita", 
"DataFineValidita", "Attivo"}, new string[] {"string", "string", "DateTime", 
"DateTime", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBancheIstitutiDelete", new string[] {"Abi"}, new string[] {"string"},"");
				for (int i = 0; i < BancheIstitutiCollectionObj.Count; i++)
				{
					switch (BancheIstitutiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BancheIstitutiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BancheIstitutiCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BancheIstitutiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BancheIstitutiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Abi", (SiarLibrary.NullTypes.StringNT)BancheIstitutiCollectionObj[i].Abi);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BancheIstitutiCollectionObj.Count; i++)
				{
					if ((BancheIstitutiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BancheIstitutiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BancheIstitutiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BancheIstitutiCollectionObj[i].IsDirty = false;
						BancheIstitutiCollectionObj[i].IsPersistent = true;
					}
					if ((BancheIstitutiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BancheIstitutiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BancheIstitutiCollectionObj[i].IsDirty = false;
						BancheIstitutiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BancheIstituti BancheIstitutiObj)
		{
			int returnValue = 0;
			if (BancheIstitutiObj.IsPersistent) 
			{
				returnValue = Delete(db, BancheIstitutiObj.Abi);
			}
			BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BancheIstitutiObj.IsDirty = false;
			BancheIstitutiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string AbiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBancheIstitutiDelete", new string[] {"Abi"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Abi", (SiarLibrary.NullTypes.StringNT)AbiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BancheIstitutiCollection BancheIstitutiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBancheIstitutiDelete", new string[] {"Abi"}, new string[] {"string"},"");
				for (int i = 0; i < BancheIstitutiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Abi", BancheIstitutiCollectionObj[i].Abi);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BancheIstitutiCollectionObj.Count; i++)
				{
					if ((BancheIstitutiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BancheIstitutiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BancheIstitutiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BancheIstitutiCollectionObj[i].IsDirty = false;
						BancheIstitutiCollectionObj[i].IsPersistent = false;
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
		public static BancheIstituti GetById(DbProvider db, string AbiValue)
		{
			BancheIstituti BancheIstitutiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBancheIstitutiGetById", new string[] {"Abi"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Abi", (SiarLibrary.NullTypes.StringNT)AbiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BancheIstitutiObj = GetFromDatareader(db);
				BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheIstitutiObj.IsDirty = false;
				BancheIstitutiObj.IsPersistent = true;
			}
			db.Close();
			return BancheIstitutiObj;
		}

		//getFromDatareader
		public static BancheIstituti GetFromDatareader(DbProvider db)
		{
			BancheIstituti BancheIstitutiObj = new BancheIstituti();
			BancheIstitutiObj.Abi = new SiarLibrary.NullTypes.StringNT(db.DataReader["ABI"]);
			BancheIstitutiObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			BancheIstitutiObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			BancheIstitutiObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			BancheIstitutiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BancheIstitutiObj.IsDirty = false;
			BancheIstitutiObj.IsPersistent = true;
			return BancheIstitutiObj;
		}

		//Find Select

		public static BancheIstitutiCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT AbiEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BancheIstitutiCollection BancheIstitutiCollectionObj = new BancheIstitutiCollection();

			IDbCommand findCmd = db.InitCmd("Zbancheistitutifindselect", new string[] {"Abiequalthis", "Denominazioneequalthis", "DataInizioValiditaequalthis", 
"DataFineValiditaequalthis", "Attivoequalthis"}, new string[] {"string", "string", "DateTime", 
"DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abiequalthis", AbiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BancheIstituti BancheIstitutiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BancheIstitutiObj = GetFromDatareader(db);
				BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheIstitutiObj.IsDirty = false;
				BancheIstitutiObj.IsPersistent = true;
				BancheIstitutiCollectionObj.Add(BancheIstitutiObj);
			}
			db.Close();
			return BancheIstitutiCollectionObj;
		}

		//Find Find

		public static BancheIstitutiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT AbiEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneLikeThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BancheIstitutiCollection BancheIstitutiCollectionObj = new BancheIstitutiCollection();

			IDbCommand findCmd = db.InitCmd("Zbancheistitutifindfind", new string[] {"Abiequalthis", "Denominazionelikethis", "Attivoequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abiequalthis", AbiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazionelikethis", DenominazioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BancheIstituti BancheIstitutiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BancheIstitutiObj = GetFromDatareader(db);
				BancheIstitutiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheIstitutiObj.IsDirty = false;
				BancheIstitutiObj.IsPersistent = true;
				BancheIstitutiCollectionObj.Add(BancheIstitutiObj);
			}
			db.Close();
			return BancheIstitutiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BancheIstitutiCollectionProvider:IBancheIstitutiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BancheIstitutiCollectionProvider : IBancheIstitutiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BancheIstituti
		protected BancheIstitutiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BancheIstitutiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BancheIstitutiCollection(this);
		}

		//Costruttore 2: popola la collection
		public BancheIstitutiCollectionProvider(StringNT AbiEqualThis, StringNT DenominazioneLikeThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(AbiEqualThis, DenominazioneLikeThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input bancheistitutiCollectionObj - non popola la collection
		public BancheIstitutiCollectionProvider(BancheIstitutiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BancheIstitutiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BancheIstitutiCollection(this);
		}

		//Get e Set
		public BancheIstitutiCollection CollectionObj
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
		public int SaveCollection(BancheIstitutiCollection collectionObj)
		{
			return BancheIstitutiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BancheIstituti bancheistitutiObj)
		{
			return BancheIstitutiDAL.Save(_dbProviderObj, bancheistitutiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BancheIstitutiCollection collectionObj)
		{
			return BancheIstitutiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BancheIstituti bancheistitutiObj)
		{
			return BancheIstitutiDAL.Delete(_dbProviderObj, bancheistitutiObj);
		}

		//getById
		public BancheIstituti GetById(StringNT AbiValue)
		{
			BancheIstituti BancheIstitutiTemp = BancheIstitutiDAL.GetById(_dbProviderObj, AbiValue);
			if (BancheIstitutiTemp!=null) BancheIstitutiTemp.Provider = this;
			return BancheIstitutiTemp;
		}

		//Select: popola la collection
		public BancheIstitutiCollection Select(StringNT AbiEqualThis, StringNT DenominazioneEqualThis, DatetimeNT DatainiziovaliditaEqualThis, 
DatetimeNT DatafinevaliditaEqualThis, BoolNT AttivoEqualThis)
		{
			BancheIstitutiCollection BancheIstitutiCollectionTemp = BancheIstitutiDAL.Select(_dbProviderObj, AbiEqualThis, DenominazioneEqualThis, DatainiziovaliditaEqualThis, 
DatafinevaliditaEqualThis, AttivoEqualThis);
			BancheIstitutiCollectionTemp.Provider = this;
			return BancheIstitutiCollectionTemp;
		}

		//Find: popola la collection
		public BancheIstitutiCollection Find(StringNT AbiEqualThis, StringNT DenominazioneLikeThis, BoolNT AttivoEqualThis)
		{
			BancheIstitutiCollection BancheIstitutiCollectionTemp = BancheIstitutiDAL.Find(_dbProviderObj, AbiEqualThis, DenominazioneLikeThis, AttivoEqualThis);
			BancheIstitutiCollectionTemp.Provider = this;
			return BancheIstitutiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANCHE_ISTITUTI>
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
    <Find OrderBy="ORDER BY ABI">
      <ABI>Equal</ABI>
      <DENOMINAZIONE>Like</DENOMINAZIONE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ATTIVO>Equal</ATTIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANCHE_ISTITUTI>
*/
