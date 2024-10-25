using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoMassimali
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoMassimaliProvider
	{
		int Save(BandoMassimali BandoMassimaliObj);
		int SaveCollection(BandoMassimaliCollection collectionObj);
		int Delete(BandoMassimali BandoMassimaliObj);
		int DeleteCollection(BandoMassimaliCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoMassimali
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoMassimali: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.DecimalNT _Quota;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IBandoMassimaliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoMassimaliProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoMassimali()
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
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA
		/// Tipo sul db:DECIMAL(10,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT Quota
		{
			get { return _Quota; }
			set {
				if (Quota != value)
				{
					_Quota = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
	/// Summary description for BandoMassimaliCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoMassimaliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoMassimaliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoMassimali) info.GetValue(i.ToString(),typeof(BandoMassimali)));
			}
		}

		//Costruttore
		public BandoMassimaliCollection()
		{
			this.ItemType = typeof(BandoMassimali);
		}

		//Costruttore con provider
		public BandoMassimaliCollection(IBandoMassimaliProvider providerObj)
		{
			this.ItemType = typeof(BandoMassimali);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoMassimali this[int index]
		{
			get { return (BandoMassimali)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoMassimaliCollection GetChanges()
		{
			return (BandoMassimaliCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoMassimaliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoMassimaliProvider Provider
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
		public int Add(BandoMassimali BandoMassimaliObj)
		{
			if (BandoMassimaliObj.Provider == null) BandoMassimaliObj.Provider = this.Provider;
			return base.Add(BandoMassimaliObj);
		}

		//AddCollection
		public void AddCollection(BandoMassimaliCollection BandoMassimaliCollectionObj)
		{
			foreach (BandoMassimali BandoMassimaliObj in BandoMassimaliCollectionObj)
				this.Add(BandoMassimaliObj);
		}

		//Insert
		public void Insert(int index, BandoMassimali BandoMassimaliObj)
		{
			if (BandoMassimaliObj.Provider == null) BandoMassimaliObj.Provider = this.Provider;
			base.Insert(index, BandoMassimaliObj);
		}

		//CollectionGetById
		public BandoMassimali CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoMassimaliCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, 
NullTypes.DecimalNT QuotaEqualThis, NullTypes.DecimalNT ImportoEqualThis)
		{
			BandoMassimaliCollection BandoMassimaliCollectionTemp = new BandoMassimaliCollection();
			foreach (BandoMassimali BandoMassimaliItem in this)
			{
				if (((IdEqualThis == null) || ((BandoMassimaliItem.Id != null) && (BandoMassimaliItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoMassimaliItem.IdBando != null) && (BandoMassimaliItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((BandoMassimaliItem.IdProgrammazione != null) && (BandoMassimaliItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && 
((QuotaEqualThis == null) || ((BandoMassimaliItem.Quota != null) && (BandoMassimaliItem.Quota.Value == QuotaEqualThis.Value))) && ((ImportoEqualThis == null) || ((BandoMassimaliItem.Importo != null) && (BandoMassimaliItem.Importo.Value == ImportoEqualThis.Value))))
				{
					BandoMassimaliCollectionTemp.Add(BandoMassimaliItem);
				}
			}
			return BandoMassimaliCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoMassimaliDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoMassimaliDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoMassimali BandoMassimaliObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoMassimaliObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoMassimaliObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", BandoMassimaliObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Quota", BandoMassimaliObj.Quota);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", BandoMassimaliObj.Importo);
		}
		//Insert
		private static int Insert(DbProvider db, BandoMassimali BandoMassimaliObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoMassimaliInsert", new string[] {"IdBando", "IdProgrammazione", 
"Quota", "Importo", }, new string[] {"int", "int", 
"decimal", "decimal", },"");
				CompileIUCmd(false, insertCmd,BandoMassimaliObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoMassimaliObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoMassimaliObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
				BandoMassimaliObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
				}
				BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoMassimaliObj.IsDirty = false;
				BandoMassimaliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoMassimali BandoMassimaliObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoMassimaliUpdate", new string[] {"Id", "IdBando", "IdProgrammazione", 
"Quota", "Importo", }, new string[] {"int", "int", "int", 
"decimal", "decimal", },"");
				CompileIUCmd(true, updateCmd,BandoMassimaliObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoMassimaliObj.IsDirty = false;
				BandoMassimaliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoMassimali BandoMassimaliObj)
		{
			switch (BandoMassimaliObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoMassimaliObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoMassimaliObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoMassimaliObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoMassimaliCollection BandoMassimaliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoMassimaliUpdate", new string[] {"Id", "IdBando", "IdProgrammazione", 
"Quota", "Importo", }, new string[] {"int", "int", "int", 
"decimal", "decimal", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoMassimaliInsert", new string[] {"IdBando", "IdProgrammazione", 
"Quota", "Importo", }, new string[] {"int", "int", 
"decimal", "decimal", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoMassimaliDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoMassimaliCollectionObj.Count; i++)
				{
					switch (BandoMassimaliCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoMassimaliCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoMassimaliCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoMassimaliCollectionObj[i].Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
									BandoMassimaliCollectionObj[i].Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoMassimaliCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoMassimaliCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoMassimaliCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoMassimaliCollectionObj.Count; i++)
				{
					if ((BandoMassimaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoMassimaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoMassimaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoMassimaliCollectionObj[i].IsDirty = false;
						BandoMassimaliCollectionObj[i].IsPersistent = true;
					}
					if ((BandoMassimaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoMassimaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoMassimaliCollectionObj[i].IsDirty = false;
						BandoMassimaliCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoMassimali BandoMassimaliObj)
		{
			int returnValue = 0;
			if (BandoMassimaliObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoMassimaliObj.Id);
			}
			BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoMassimaliObj.IsDirty = false;
			BandoMassimaliObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoMassimaliDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoMassimaliCollection BandoMassimaliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoMassimaliDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoMassimaliCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoMassimaliCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoMassimaliCollectionObj.Count; i++)
				{
					if ((BandoMassimaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoMassimaliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoMassimaliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoMassimaliCollectionObj[i].IsDirty = false;
						BandoMassimaliCollectionObj[i].IsPersistent = false;
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
		public static BandoMassimali GetById(DbProvider db, int IdValue)
		{
			BandoMassimali BandoMassimaliObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoMassimaliGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoMassimaliObj = GetFromDatareader(db);
				BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoMassimaliObj.IsDirty = false;
				BandoMassimaliObj.IsPersistent = true;
			}
			db.Close();
			return BandoMassimaliObj;
		}

		//getFromDatareader
		public static BandoMassimali GetFromDatareader(DbProvider db)
		{
			BandoMassimali BandoMassimaliObj = new BandoMassimali();
			BandoMassimaliObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoMassimaliObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoMassimaliObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			BandoMassimaliObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
			BandoMassimaliObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			BandoMassimaliObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			BandoMassimaliObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoMassimaliObj.IsDirty = false;
			BandoMassimaliObj.IsPersistent = true;
			return BandoMassimaliObj;
		}

		//Find Select

		public static BandoMassimaliCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis)

		{

			BandoMassimaliCollection BandoMassimaliCollectionObj = new BandoMassimaliCollection();

			IDbCommand findCmd = db.InitCmd("Zbandomassimalifindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdProgrammazioneequalthis", 
"Quotaequalthis", "Importoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotaequalthis", QuotaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			BandoMassimali BandoMassimaliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoMassimaliObj = GetFromDatareader(db);
				BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoMassimaliObj.IsDirty = false;
				BandoMassimaliObj.IsPersistent = true;
				BandoMassimaliCollectionObj.Add(BandoMassimaliObj);
			}
			db.Close();
			return BandoMassimaliCollectionObj;
		}

		//Find Find

		public static BandoMassimaliCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis)

		{

			BandoMassimaliCollection BandoMassimaliCollectionObj = new BandoMassimaliCollection();

			IDbCommand findCmd = db.InitCmd("Zbandomassimalifindfind", new string[] {"IdBandoequalthis", "IdProgrammazioneequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			BandoMassimali BandoMassimaliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoMassimaliObj = GetFromDatareader(db);
				BandoMassimaliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoMassimaliObj.IsDirty = false;
				BandoMassimaliObj.IsPersistent = true;
				BandoMassimaliCollectionObj.Add(BandoMassimaliObj);
			}
			db.Close();
			return BandoMassimaliCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoMassimaliCollectionProvider:IBandoMassimaliProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoMassimaliCollectionProvider : IBandoMassimaliProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoMassimali
		protected BandoMassimaliCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoMassimaliCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoMassimaliCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoMassimaliCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogrammazioneEqualThis);
		}

		//Costruttore3: ha in input bandomassimaliCollectionObj - non popola la collection
		public BandoMassimaliCollectionProvider(BandoMassimaliCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoMassimaliCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoMassimaliCollection(this);
		}

		//Get e Set
		public BandoMassimaliCollection CollectionObj
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
		public int SaveCollection(BandoMassimaliCollection collectionObj)
		{
			return BandoMassimaliDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoMassimali bandomassimaliObj)
		{
			return BandoMassimaliDAL.Save(_dbProviderObj, bandomassimaliObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoMassimaliCollection collectionObj)
		{
			return BandoMassimaliDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoMassimali bandomassimaliObj)
		{
			return BandoMassimaliDAL.Delete(_dbProviderObj, bandomassimaliObj);
		}

		//getById
		public BandoMassimali GetById(IntNT IdValue)
		{
			BandoMassimali BandoMassimaliTemp = BandoMassimaliDAL.GetById(_dbProviderObj, IdValue);
			if (BandoMassimaliTemp!=null) BandoMassimaliTemp.Provider = this;
			return BandoMassimaliTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoMassimaliCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis, 
DecimalNT QuotaEqualThis, DecimalNT ImportoEqualThis)
		{
			BandoMassimaliCollection BandoMassimaliCollectionTemp = BandoMassimaliDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdprogrammazioneEqualThis, 
QuotaEqualThis, ImportoEqualThis);
			BandoMassimaliCollectionTemp.Provider = this;
			return BandoMassimaliCollectionTemp;
		}

		//Find: popola la collection
		public BandoMassimaliCollection Find(IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis)
		{
			BandoMassimaliCollection BandoMassimaliCollectionTemp = BandoMassimaliDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogrammazioneEqualThis);
			BandoMassimaliCollectionTemp.Provider = this;
			return BandoMassimaliCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_MASSIMALI>
  <ViewName>vBANDO_MASSIMALI</ViewName>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_MASSIMALI>
*/
