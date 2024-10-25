using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ArchivioFile
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IArchivioFileProvider
	{
		int Save(ArchivioFile ArchivioFileObj);
		int SaveCollection(ArchivioFileCollection collectionObj);
		int Delete(ArchivioFile ArchivioFileObj);
		int DeleteCollection(ArchivioFileCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ArchivioFile
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ArchivioFile: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompleto;
		private byte[] _Contenuto;
		private NullTypes.IntNT _Dimensione;
		private NullTypes.StringNT _HashCode;
		[NonSerialized] private IArchivioFileProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IArchivioFileProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ArchivioFile()
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
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_FILE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NomeFile
		{
			get { return _NomeFile; }
			set {
				if (NomeFile != value)
				{
					_NomeFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_COMPLETO
		/// Tipo sul db:VARCHAR(510)
		/// </summary>
		public NullTypes.StringNT NomeCompleto
		{
			get { return _NomeCompleto; }
			set {
				if (NomeCompleto != value)
				{
					_NomeCompleto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTENUTO
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] Contenuto
		{
			get { return _Contenuto; }
			set {
				if (Contenuto != value)
				{
					_Contenuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Dimensione
		{
			get { return _Dimensione; }
			set {
				if (Dimensione != value)
				{
					_Dimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:HASH_CODE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT HashCode
		{
			get { return _HashCode; }
			set {
				if (HashCode != value)
				{
					_HashCode = value;
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
	/// Summary description for ArchivioFileCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ArchivioFileCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ArchivioFileCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ArchivioFile) info.GetValue(i.ToString(),typeof(ArchivioFile)));
			}
		}

		//Costruttore
		public ArchivioFileCollection()
		{
			this.ItemType = typeof(ArchivioFile);
		}

		//Costruttore con provider
		public ArchivioFileCollection(IArchivioFileProvider providerObj)
		{
			this.ItemType = typeof(ArchivioFile);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ArchivioFile this[int index]
		{
			get { return (ArchivioFile)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ArchivioFileCollection GetChanges()
		{
			return (ArchivioFileCollection) base.GetChanges();
		}

		[NonSerialized] private IArchivioFileProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IArchivioFileProvider Provider
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
		public int Add(ArchivioFile ArchivioFileObj)
		{
			if (ArchivioFileObj.Provider == null) ArchivioFileObj.Provider = this.Provider;
			return base.Add(ArchivioFileObj);
		}

		//AddCollection
		public void AddCollection(ArchivioFileCollection ArchivioFileCollectionObj)
		{
			foreach (ArchivioFile ArchivioFileObj in ArchivioFileCollectionObj)
				this.Add(ArchivioFileObj);
		}

		//Insert
		public void Insert(int index, ArchivioFile ArchivioFileObj)
		{
			if (ArchivioFileObj.Provider == null) ArchivioFileObj.Provider = this.Provider;
			base.Insert(index, ArchivioFileObj);
		}

		//CollectionGetById
		public ArchivioFile CollectionGetById(NullTypes.IntNT IdValue)
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
		public ArchivioFileCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT TipoEqualThis, NullTypes.StringNT NomeFileEqualThis, 
NullTypes.StringNT NomeCompletoEqualThis, NullTypes.IntNT DimensioneEqualThis, NullTypes.StringNT HashCodeEqualThis)
		{
			ArchivioFileCollection ArchivioFileCollectionTemp = new ArchivioFileCollection();
			foreach (ArchivioFile ArchivioFileItem in this)
			{
				if (((IdEqualThis == null) || ((ArchivioFileItem.Id != null) && (ArchivioFileItem.Id.Value == IdEqualThis.Value))) && ((TipoEqualThis == null) || ((ArchivioFileItem.Tipo != null) && (ArchivioFileItem.Tipo.Value == TipoEqualThis.Value))) && ((NomeFileEqualThis == null) || ((ArchivioFileItem.NomeFile != null) && (ArchivioFileItem.NomeFile.Value == NomeFileEqualThis.Value))) && 
((NomeCompletoEqualThis == null) || ((ArchivioFileItem.NomeCompleto != null) && (ArchivioFileItem.NomeCompleto.Value == NomeCompletoEqualThis.Value))) && ((DimensioneEqualThis == null) || ((ArchivioFileItem.Dimensione != null) && (ArchivioFileItem.Dimensione.Value == DimensioneEqualThis.Value))) && ((HashCodeEqualThis == null) || ((ArchivioFileItem.HashCode != null) && (ArchivioFileItem.HashCode.Value == HashCodeEqualThis.Value))))
				{
					ArchivioFileCollectionTemp.Add(ArchivioFileItem);
				}
			}
			return ArchivioFileCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ArchivioFileDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ArchivioFileDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ArchivioFile ArchivioFileObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ArchivioFileObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Tipo", ArchivioFileObj.Tipo);
			DbProvider.SetCmdParam(cmd,firstChar + "NomeFile", ArchivioFileObj.NomeFile);
			DbProvider.SetCmdParam(cmd,firstChar + "NomeCompleto", ArchivioFileObj.NomeCompleto);
			DbProvider.SetCmdParam(cmd,firstChar + "Contenuto", ArchivioFileObj.Contenuto);
			DbProvider.SetCmdParam(cmd,firstChar + "Dimensione", ArchivioFileObj.Dimensione);
			DbProvider.SetCmdParam(cmd,firstChar + "HashCode", ArchivioFileObj.HashCode);
		}
		//Insert
		private static int Insert(DbProvider db, ArchivioFile ArchivioFileObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZArchivioFileInsert", new string[] {"Tipo", "NomeFile", 
"NomeCompleto", "Contenuto", "Dimensione", 
"HashCode"}, new string[] {"string", "string", 
"string", "byte[]", "int", 
"string"},"");
				CompileIUCmd(false, insertCmd,ArchivioFileObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ArchivioFileObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ArchivioFileObj.IsDirty = false;
				ArchivioFileObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ArchivioFile ArchivioFileObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZArchivioFileUpdate", new string[] {"Id", "Tipo", "NomeFile", 
"NomeCompleto", "Contenuto", "Dimensione", 
"HashCode"}, new string[] {"int", "string", "string", 
"string", "byte[]", "int", 
"string"},"");
				CompileIUCmd(true, updateCmd,ArchivioFileObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ArchivioFileObj.IsDirty = false;
				ArchivioFileObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ArchivioFile ArchivioFileObj)
		{
			switch (ArchivioFileObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ArchivioFileObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ArchivioFileObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ArchivioFileObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ArchivioFileCollection ArchivioFileCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZArchivioFileUpdate", new string[] {"Id", "Tipo", "NomeFile", 
"NomeCompleto", "Contenuto", "Dimensione", 
"HashCode"}, new string[] {"int", "string", "string", 
"string", "byte[]", "int", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZArchivioFileInsert", new string[] {"Tipo", "NomeFile", 
"NomeCompleto", "Contenuto", "Dimensione", 
"HashCode"}, new string[] {"string", "string", 
"string", "byte[]", "int", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZArchivioFileDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ArchivioFileCollectionObj.Count; i++)
				{
					switch (ArchivioFileCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ArchivioFileCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ArchivioFileCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ArchivioFileCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ArchivioFileCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ArchivioFileCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ArchivioFileCollectionObj.Count; i++)
				{
					if ((ArchivioFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ArchivioFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ArchivioFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ArchivioFileCollectionObj[i].IsDirty = false;
						ArchivioFileCollectionObj[i].IsPersistent = true;
					}
					if ((ArchivioFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ArchivioFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ArchivioFileCollectionObj[i].IsDirty = false;
						ArchivioFileCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ArchivioFile ArchivioFileObj)
		{
			int returnValue = 0;
			if (ArchivioFileObj.IsPersistent) 
			{
				returnValue = Delete(db, ArchivioFileObj.Id);
			}
			ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ArchivioFileObj.IsDirty = false;
			ArchivioFileObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZArchivioFileDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ArchivioFileCollection ArchivioFileCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZArchivioFileDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ArchivioFileCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ArchivioFileCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ArchivioFileCollectionObj.Count; i++)
				{
					if ((ArchivioFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ArchivioFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ArchivioFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ArchivioFileCollectionObj[i].IsDirty = false;
						ArchivioFileCollectionObj[i].IsPersistent = false;
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
		public static ArchivioFile GetById(DbProvider db, int IdValue)
		{
			ArchivioFile ArchivioFileObj = null;
			IDbCommand readCmd = db.InitCmd( "ZArchivioFileGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ArchivioFileObj = GetFromDatareader(db);
				ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ArchivioFileObj.IsDirty = false;
				ArchivioFileObj.IsPersistent = true;
			}
			db.Close();
			return ArchivioFileObj;
		}

		//getFromDatareader
		public static ArchivioFile GetFromDatareader(DbProvider db)
		{
			ArchivioFile ArchivioFileObj = new ArchivioFile();
			ArchivioFileObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ArchivioFileObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			ArchivioFileObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			ArchivioFileObj.NomeCompleto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO"]);
			ArchivioFileObj.Contenuto =  Convert.IsDBNull(db.DataReader["CONTENUTO"]) ? null : (byte[])db.DataReader["CONTENUTO"];
			ArchivioFileObj.Dimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE"]);
			ArchivioFileObj.HashCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE"]);
			ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ArchivioFileObj.IsDirty = false;
			ArchivioFileObj.IsPersistent = true;
			return ArchivioFileObj;
		}

		//Find Select

		public static ArchivioFileCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.StringNT NomeFileEqualThis, 
SiarLibrary.NullTypes.StringNT NomeCompletoEqualThis, SiarLibrary.NullTypes.IntNT DimensioneEqualThis, SiarLibrary.NullTypes.StringNT HashCodeEqualThis)

		{

			ArchivioFileCollection ArchivioFileCollectionObj = new ArchivioFileCollection();

			IDbCommand findCmd = db.InitCmd("Zarchiviofilefindselect", new string[] {"Idequalthis", "Tipoequalthis", "NomeFileequalthis", 
"NomeCompletoequalthis", "Dimensioneequalthis", "HashCodeequalthis"}, new string[] {"int", "string", "string", 
"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NomeFileequalthis", NomeFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NomeCompletoequalthis", NomeCompletoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dimensioneequalthis", DimensioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "HashCodeequalthis", HashCodeEqualThis);
			ArchivioFile ArchivioFileObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ArchivioFileObj = GetFromDatareader(db);
				ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ArchivioFileObj.IsDirty = false;
				ArchivioFileObj.IsPersistent = true;
				ArchivioFileCollectionObj.Add(ArchivioFileObj);
			}
			db.Close();
			return ArchivioFileCollectionObj;
		}

		//Find Find

		public static ArchivioFileCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT TipoLikeThis, SiarLibrary.NullTypes.StringNT NomeFileLikeThis, SiarLibrary.NullTypes.StringNT HashCodeEqualThis)

		{

			ArchivioFileCollection ArchivioFileCollectionObj = new ArchivioFileCollection();

			IDbCommand findCmd = db.InitCmd("Zarchiviofilefindfind", new string[] {"Tipolikethis", "NomeFilelikethis", "HashCodeequalthis"}, new string[] {"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipolikethis", TipoLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NomeFilelikethis", NomeFileLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "HashCodeequalthis", HashCodeEqualThis);
			ArchivioFile ArchivioFileObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ArchivioFileObj = GetFromDatareader(db);
				ArchivioFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ArchivioFileObj.IsDirty = false;
				ArchivioFileObj.IsPersistent = true;
				ArchivioFileCollectionObj.Add(ArchivioFileObj);
			}
			db.Close();
			return ArchivioFileCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ArchivioFileCollectionProvider:IArchivioFileProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ArchivioFileCollectionProvider : IArchivioFileProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ArchivioFile
		protected ArchivioFileCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ArchivioFileCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ArchivioFileCollection(this);
		}

		//Costruttore 2: popola la collection
		public ArchivioFileCollectionProvider(StringNT TipoLikeThis, StringNT NomefileLikeThis, StringNT HashcodeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(TipoLikeThis, NomefileLikeThis, HashcodeEqualThis);
		}

		//Costruttore3: ha in input archiviofileCollectionObj - non popola la collection
		public ArchivioFileCollectionProvider(ArchivioFileCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ArchivioFileCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ArchivioFileCollection(this);
		}

		//Get e Set
		public ArchivioFileCollection CollectionObj
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
		public int SaveCollection(ArchivioFileCollection collectionObj)
		{
			return ArchivioFileDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ArchivioFile archiviofileObj)
		{
			return ArchivioFileDAL.Save(_dbProviderObj, archiviofileObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ArchivioFileCollection collectionObj)
		{
			return ArchivioFileDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ArchivioFile archiviofileObj)
		{
			return ArchivioFileDAL.Delete(_dbProviderObj, archiviofileObj);
		}

		//getById
		public ArchivioFile GetById(IntNT IdValue)
		{
			ArchivioFile ArchivioFileTemp = ArchivioFileDAL.GetById(_dbProviderObj, IdValue);
			if (ArchivioFileTemp!=null) ArchivioFileTemp.Provider = this;
			return ArchivioFileTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ArchivioFileCollection Select(IntNT IdEqualThis, StringNT TipoEqualThis, StringNT NomefileEqualThis, 
StringNT NomecompletoEqualThis, IntNT DimensioneEqualThis, StringNT HashcodeEqualThis)
		{
			ArchivioFileCollection ArchivioFileCollectionTemp = ArchivioFileDAL.Select(_dbProviderObj, IdEqualThis, TipoEqualThis, NomefileEqualThis, 
NomecompletoEqualThis, DimensioneEqualThis, HashcodeEqualThis);
			ArchivioFileCollectionTemp.Provider = this;
			return ArchivioFileCollectionTemp;
		}

		//Find: popola la collection
		public ArchivioFileCollection Find(StringNT TipoLikeThis, StringNT NomefileLikeThis, StringNT HashcodeEqualThis)
		{
			ArchivioFileCollection ArchivioFileCollectionTemp = ArchivioFileDAL.Find(_dbProviderObj, TipoLikeThis, NomefileLikeThis, HashcodeEqualThis);
			ArchivioFileCollectionTemp.Provider = this;
			return ArchivioFileCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ARCHIVIO_FILE>
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
    <Find OrderBy="ORDER BY ">
      <TIPO>Like</TIPO>
      <NOME_FILE>Like</NOME_FILE>
      <HASH_CODE>Equal</HASH_CODE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ARCHIVIO_FILE>
*/
