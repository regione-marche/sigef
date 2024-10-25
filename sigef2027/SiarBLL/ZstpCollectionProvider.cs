using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Zstp
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZstpProvider
	{
		int Save(Zstp ZstpObj);
		int SaveCollection(ZstpCollection collectionObj);
		int Delete(Zstp ZstpObj);
		int DeleteCollection(ZstpCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Zstp
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Zstp: BaseObject
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
		[NonSerialized] private IZstpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZstpProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Zstp()
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
	/// Summary description for ZstpCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZstpCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZstpCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Zstp) info.GetValue(i.ToString(),typeof(Zstp)));
			}
		}

		//Costruttore
		public ZstpCollection()
		{
			this.ItemType = typeof(Zstp);
		}

		//Costruttore con provider
		public ZstpCollection(IZstpProvider providerObj)
		{
			this.ItemType = typeof(Zstp);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Zstp this[int index]
		{
			get { return (Zstp)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZstpCollection GetChanges()
		{
			return (ZstpCollection) base.GetChanges();
		}

		[NonSerialized] private IZstpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZstpProvider Provider
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
		public int Add(Zstp ZstpObj)
		{
			if (ZstpObj.Provider == null) ZstpObj.Provider = this.Provider;
			return base.Add(ZstpObj);
		}

		//AddCollection
		public void AddCollection(ZstpCollection ZstpCollectionObj)
		{
			foreach (Zstp ZstpObj in ZstpCollectionObj)
				this.Add(ZstpObj);
		}

		//Insert
		public void Insert(int index, Zstp ZstpObj)
		{
			if (ZstpObj.Provider == null) ZstpObj.Provider = this.Provider;
			base.Insert(index, ZstpObj);
		}

		//CollectionGetById
		public Zstp CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZstpCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			ZstpCollection ZstpCollectionTemp = new ZstpCollection();
			foreach (Zstp ZstpItem in this)
			{
				if (((IdEqualThis == null) || ((ZstpItem.Id != null) && (ZstpItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZstpItem.IdProgrammazione != null) && (ZstpItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((CodiceEqualThis == null) || ((ZstpItem.Codice != null) && (ZstpItem.Codice.Value == CodiceEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((ZstpItem.Descrizione != null) && (ZstpItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ZstpCollectionTemp.Add(ZstpItem);
				}
			}
			return ZstpCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZstpDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZstpDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Zstp ZstpObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZstpObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZstpObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ZstpObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZstpObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, Zstp ZstpObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZstpInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "string", 
"string", },"");
				CompileIUCmd(false, insertCmd,ZstpObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZstpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZstpObj.IsDirty = false;
				ZstpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Zstp ZstpObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZstpUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "int", "string", 
"string", },"");
				CompileIUCmd(true, updateCmd,ZstpObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZstpObj.IsDirty = false;
				ZstpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Zstp ZstpObj)
		{
			switch (ZstpObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZstpObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZstpObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZstpObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZstpCollection ZstpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZstpUpdate", new string[] {"Id", "IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "int", "string", 
"string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZZstpInsert", new string[] {"IdProgrammazione", "Codice", 
"Descrizione", }, new string[] {"int", "string", 
"string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZZstpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZstpCollectionObj.Count; i++)
				{
					switch (ZstpCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZstpCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZstpCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZstpCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZstpCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZstpCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZstpCollectionObj.Count; i++)
				{
					if ((ZstpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZstpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZstpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZstpCollectionObj[i].IsDirty = false;
						ZstpCollectionObj[i].IsPersistent = true;
					}
					if ((ZstpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZstpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZstpCollectionObj[i].IsDirty = false;
						ZstpCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Zstp ZstpObj)
		{
			int returnValue = 0;
			if (ZstpObj.IsPersistent) 
			{
				returnValue = Delete(db, ZstpObj.Id);
			}
			ZstpObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZstpObj.IsDirty = false;
			ZstpObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZstpDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZstpCollection ZstpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZstpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZstpCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZstpCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZstpCollectionObj.Count; i++)
				{
					if ((ZstpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZstpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZstpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZstpCollectionObj[i].IsDirty = false;
						ZstpCollectionObj[i].IsPersistent = false;
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
		public static Zstp GetById(DbProvider db, int IdValue)
		{
			Zstp ZstpObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZstpGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZstpObj = GetFromDatareader(db);
				ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZstpObj.IsDirty = false;
				ZstpObj.IsPersistent = true;
			}
			db.Close();
			return ZstpObj;
		}

		//getFromDatareader
		public static Zstp GetFromDatareader(DbProvider db)
		{
			Zstp ZstpObj = new Zstp();
			ZstpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZstpObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZstpObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ZstpObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZstpObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
			ZstpObj.Psr = new SiarLibrary.NullTypes.StringNT(db.DataReader["PSR"]);
			ZstpObj.AnnoDa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_DA"]);
			ZstpObj.AnnoA = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO_A"]);
			ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZstpObj.IsDirty = false;
			ZstpObj.IsPersistent = true;
			return ZstpObj;
		}

		//Find Select

		public static ZstpCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ZstpCollection ZstpCollectionObj = new ZstpCollection();

			IDbCommand findCmd = db.InitCmd("Zzstpfindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "Codiceequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			Zstp ZstpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZstpObj = GetFromDatareader(db);
				ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZstpObj.IsDirty = false;
				ZstpObj.IsPersistent = true;
				ZstpCollectionObj.Add(ZstpObj);
			}
			db.Close();
			return ZstpCollectionObj;
		}

		//Find Find

		public static ZstpCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			ZstpCollection ZstpCollectionObj = new ZstpCollection();

			IDbCommand findCmd = db.InitCmd("Zzstpfindfind", new string[] {"IdProgrammazioneequalthis", "Codiceequalthis", "Descrizionelikethis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			Zstp ZstpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZstpObj = GetFromDatareader(db);
				ZstpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZstpObj.IsDirty = false;
				ZstpObj.IsPersistent = true;
				ZstpCollectionObj.Add(ZstpObj);
			}
			db.Close();
			return ZstpCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZstpCollectionProvider:IZstpProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZstpCollectionProvider : IZstpProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Zstp
		protected ZstpCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZstpCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZstpCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZstpCollectionProvider(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogrammazioneEqualThis, CodiceEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input zstpCollectionObj - non popola la collection
		public ZstpCollectionProvider(ZstpCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZstpCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZstpCollection(this);
		}

		//Get e Set
		public ZstpCollection CollectionObj
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
		public int SaveCollection(ZstpCollection collectionObj)
		{
			return ZstpDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Zstp zstpObj)
		{
			return ZstpDAL.Save(_dbProviderObj, zstpObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZstpCollection collectionObj)
		{
			return ZstpDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Zstp zstpObj)
		{
			return ZstpDAL.Delete(_dbProviderObj, zstpObj);
		}

		//getById
		public Zstp GetById(IntNT IdValue)
		{
			Zstp ZstpTemp = ZstpDAL.GetById(_dbProviderObj, IdValue);
			if (ZstpTemp!=null) ZstpTemp.Provider = this;
			return ZstpTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZstpCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, 
StringNT DescrizioneEqualThis)
		{
			ZstpCollection ZstpCollectionTemp = ZstpDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, CodiceEqualThis, 
DescrizioneEqualThis);
			ZstpCollectionTemp.Provider = this;
			return ZstpCollectionTemp;
		}

		//Find: popola la collection
		public ZstpCollection Find(IntNT IdprogrammazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneLikeThis)
		{
			ZstpCollection ZstpCollectionTemp = ZstpDAL.Find(_dbProviderObj, IdprogrammazioneEqualThis, CodiceEqualThis, DescrizioneLikeThis);
			ZstpCollectionTemp.Provider = this;
			return ZstpCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zSTP>
  <ViewName>vzSTP</ViewName>
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
</zSTP>
*/
