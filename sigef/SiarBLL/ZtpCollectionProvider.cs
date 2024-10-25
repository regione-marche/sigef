using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Ztp
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZtpProvider
	{
		int Save(Ztp ZtpObj);
		int SaveCollection(ZtpCollection collectionObj);
		int Delete(Ztp ZtpObj);
		int DeleteCollection(ZtpCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Ztp
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Ztp: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Programmazione;
		private NullTypes.StringNT _Psr;
		private NullTypes.IntNT _AnnoDa;
		private NullTypes.IntNT _AnnoA;
		[NonSerialized] private IZtpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZtpProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Ztp()
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
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:CHAR(2)
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
		/// Tipo sul db:VARCHAR(255)
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

		/// <summary>
		/// Corrisponde al campo:PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(140)
		/// </summary>
		public NullTypes.StringNT Programmazione
		{
			get { return _Programmazione; }
			set {
				if (Programmazione != value)
				{
					_Programmazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PSR
		/// Tipo sul db:VARCHAR(267)
		/// </summary>
		public NullTypes.StringNT Psr
		{
			get { return _Psr; }
			set {
				if (Psr != value)
				{
					_Psr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_DA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT AnnoDa
		{
			get { return _AnnoDa; }
			set {
				if (AnnoDa != value)
				{
					_AnnoDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_A
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT AnnoA
		{
			get { return _AnnoA; }
			set {
				if (AnnoA != value)
				{
					_AnnoA = value;
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
	/// Summary description for ZtpCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZtpCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZtpCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Ztp) info.GetValue(i.ToString(),typeof(Ztp)));
			}
		}

		//Costruttore
		public ZtpCollection()
		{
			this.ItemType = typeof(Ztp);
		}

		//Costruttore con provider
		public ZtpCollection(IZtpProvider providerObj)
		{
			this.ItemType = typeof(Ztp);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Ztp this[int index]
		{
			get { return (Ztp)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZtpCollection GetChanges()
		{
			return (ZtpCollection) base.GetChanges();
		}

		[NonSerialized] private IZtpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZtpProvider Provider
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
		public int Add(Ztp ZtpObj)
		{
			if (ZtpObj.Provider == null) ZtpObj.Provider = this.Provider;
			return base.Add(ZtpObj);
		}

		//AddCollection
		public void AddCollection(ZtpCollection ZtpCollectionObj)
		{
			foreach (Ztp ZtpObj in ZtpCollectionObj)
				this.Add(ZtpObj);
		}

		//Insert
		public void Insert(int index, Ztp ZtpObj)
		{
			if (ZtpObj.Provider == null) ZtpObj.Provider = this.Provider;
			base.Insert(index, ZtpObj);
		}

		//CollectionGetById
		public Ztp CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZtpCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			ZtpCollection ZtpCollectionTemp = new ZtpCollection();
			foreach (Ztp ZtpItem in this)
			{
				if (((IdEqualThis == null) || ((ZtpItem.Id != null) && (ZtpItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZtpItem.IdProgrammazione != null) && (ZtpItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((CodiceEqualThis == null) || ((ZtpItem.Codice != null) && (ZtpItem.Codice.Value == CodiceEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((ZtpItem.Descrizione != null) && (ZtpItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ZtpCollectionTemp.Add(ZtpItem);
				}
			}
			return ZtpCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZtpDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZtpDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Ztp ZtpObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZtpObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZtpObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ZtpObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZtpObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, Ztp ZtpObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZtpInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "string", 
"string", },"");
				CompileIUCmd(false, insertCmd,ZtpObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZtpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtpObj.IsDirty = false;
				ZtpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Ztp ZtpObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZtpUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "int", "string", 
"string", },"");
				CompileIUCmd(true, updateCmd,ZtpObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtpObj.IsDirty = false;
				ZtpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Ztp ZtpObj)
		{
			switch (ZtpObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZtpObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZtpObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZtpObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZtpCollection ZtpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZtpUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "int", "string", 
"string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZZtpInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "string", 
"string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZZtpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZtpCollectionObj.Count; i++)
				{
					switch (ZtpCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZtpCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZtpCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZtpCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZtpCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZtpCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZtpCollectionObj.Count; i++)
				{
					if ((ZtpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZtpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZtpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZtpCollectionObj[i].IsDirty = false;
						ZtpCollectionObj[i].IsPersistent = true;
					}
					if ((ZtpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZtpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZtpCollectionObj[i].IsDirty = false;
						ZtpCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Ztp ZtpObj)
		{
			int returnValue = 0;
			if (ZtpObj.IsPersistent) 
			{
				returnValue = Delete(db, ZtpObj.Id);
			}
			ZtpObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZtpObj.IsDirty = false;
			ZtpObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZtpDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZtpCollection ZtpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZtpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZtpCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZtpCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZtpCollectionObj.Count; i++)
				{
					if ((ZtpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZtpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZtpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZtpCollectionObj[i].IsDirty = false;
						ZtpCollectionObj[i].IsPersistent = false;
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
		public static Ztp GetById(DbProvider db, int IdValue)
		{
			Ztp ZtpObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZtpGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZtpObj = GetFromDatareader(db);
				ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtpObj.IsDirty = false;
				ZtpObj.IsPersistent = true;
			}
			db.Close();
			return ZtpObj;
		}

		//getFromDatareader
		public static Ztp GetFromDatareader(DbProvider db)
		{
			Ztp ZtpObj = new Ztp();
			ZtpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZtpObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZtpObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ZtpObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZtpObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
			ZtpObj.Psr = new SiarLibrary.NullTypes.StringNT(db.DataReader["PSR"]);
			ZtpObj.AnnoDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_DA"]);
			ZtpObj.AnnoA = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_A"]);
			ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZtpObj.IsDirty = false;
			ZtpObj.IsPersistent = true;
			return ZtpObj;
		}

		//Find Select

		public static ZtpCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ZtpCollection ZtpCollectionObj = new ZtpCollection();

			IDbCommand findCmd = db.InitCmd("Zztpfindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "Codiceequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			Ztp ZtpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZtpObj = GetFromDatareader(db);
				ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtpObj.IsDirty = false;
				ZtpObj.IsPersistent = true;
				ZtpCollectionObj.Add(ZtpObj);
			}
			db.Close();
			return ZtpCollectionObj;
		}

		//Find Find

		public static ZtpCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			ZtpCollection ZtpCollectionObj = new ZtpCollection();

			IDbCommand findCmd = db.InitCmd("Zztpfindfind", new string[] {"IdProgrammazioneequalthis", "Codiceequalthis", "Descrizionelikethis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			Ztp ZtpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZtpObj = GetFromDatareader(db);
				ZtpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZtpObj.IsDirty = false;
				ZtpObj.IsPersistent = true;
				ZtpCollectionObj.Add(ZtpObj);
			}
			db.Close();
			return ZtpCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZtpCollectionProvider:IZtpProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZtpCollectionProvider : IZtpProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Ztp
		protected ZtpCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZtpCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZtpCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZtpCollectionProvider(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogrammazioneEqualThis, CodiceEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input ztpCollectionObj - non popola la collection
		public ZtpCollectionProvider(ZtpCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZtpCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZtpCollection(this);
		}

		//Get e Set
		public ZtpCollection CollectionObj
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
		public int SaveCollection(ZtpCollection collectionObj)
		{
			return ZtpDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Ztp ztpObj)
		{
			return ZtpDAL.Save(_dbProviderObj, ztpObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZtpCollection collectionObj)
		{
			return ZtpDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Ztp ztpObj)
		{
			return ZtpDAL.Delete(_dbProviderObj, ztpObj);
		}

		//getById
		public Ztp GetById(IntNT IdValue)
		{
			Ztp ZtpTemp = ZtpDAL.GetById(_dbProviderObj, IdValue);
			if (ZtpTemp!=null) ZtpTemp.Provider = this;
			return ZtpTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZtpCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, 
StringNT DescrizioneEqualThis)
		{
			ZtpCollection ZtpCollectionTemp = ZtpDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, CodiceEqualThis, 
DescrizioneEqualThis);
			ZtpCollectionTemp.Provider = this;
			return ZtpCollectionTemp;
		}

		//Find: popola la collection
		public ZtpCollection Find(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneLikeThis)
		{
			ZtpCollection ZtpCollectionTemp = ZtpDAL.Find(_dbProviderObj, IdprogrammazioneEqualThis, CodiceEqualThis, DescrizioneLikeThis);
			ZtpCollectionTemp.Provider = this;
			return ZtpCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zTP>
  <ViewName>vzTP</ViewName>
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
    <Find OrderBy="ORDER BY ANNO_DA+ANNO_A DESC">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <CODICE>Equal</CODICE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zTP>
*/
