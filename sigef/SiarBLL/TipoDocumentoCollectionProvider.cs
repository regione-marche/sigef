using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoDocumento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoDocumentoProvider
	{
		int Save(TipoDocumento TipoDocumentoObj);
		int SaveCollection(TipoDocumentoCollection collectionObj);
		int Delete(TipoDocumento TipoDocumentoObj);
		int DeleteCollection(TipoDocumentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoDocumento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoDocumento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Formato;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private ITipoDocumentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoDocumentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoDocumento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(10)
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
		/// Corrisponde al campo:FORMATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Formato
		{
			get { return _Formato; }
			set {
				if (Formato != value)
				{
					_Formato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(250)
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
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((1))
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
	/// Summary description for TipoDocumentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoDocumentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoDocumentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoDocumento) info.GetValue(i.ToString(),typeof(TipoDocumento)));
			}
		}

		//Costruttore
		public TipoDocumentoCollection()
		{
			this.ItemType = typeof(TipoDocumento);
		}

		//Costruttore con provider
		public TipoDocumentoCollection(ITipoDocumentoProvider providerObj)
		{
			this.ItemType = typeof(TipoDocumento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoDocumento this[int index]
		{
			get { return (TipoDocumento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoDocumentoCollection GetChanges()
		{
			return (TipoDocumentoCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoDocumentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoDocumentoProvider Provider
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
		public int Add(TipoDocumento TipoDocumentoObj)
		{
			if (TipoDocumentoObj.Provider == null) TipoDocumentoObj.Provider = this.Provider;
			return base.Add(TipoDocumentoObj);
		}

		//AddCollection
		public void AddCollection(TipoDocumentoCollection TipoDocumentoCollectionObj)
		{
			foreach (TipoDocumento TipoDocumentoObj in TipoDocumentoCollectionObj)
				this.Add(TipoDocumentoObj);
		}

		//Insert
		public void Insert(int index, TipoDocumento TipoDocumentoObj)
		{
			if (TipoDocumentoObj.Provider == null) TipoDocumentoObj.Provider = this.Provider;
			base.Insert(index, TipoDocumentoObj);
		}

		//CollectionGetById
		public TipoDocumento CollectionGetById(NullTypes.StringNT CodiceValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Codice == CodiceValue))
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
		public TipoDocumentoCollection SubSelect(NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT FormatoEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			TipoDocumentoCollection TipoDocumentoCollectionTemp = new TipoDocumentoCollection();
			foreach (TipoDocumento TipoDocumentoItem in this)
			{
				if (((CodiceEqualThis == null) || ((TipoDocumentoItem.Codice != null) && (TipoDocumentoItem.Codice.Value == CodiceEqualThis.Value))) && ((FormatoEqualThis == null) || ((TipoDocumentoItem.Formato != null) && (TipoDocumentoItem.Formato.Value == FormatoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoDocumentoItem.Descrizione != null) && (TipoDocumentoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((AttivoEqualThis == null) || ((TipoDocumentoItem.Attivo != null) && (TipoDocumentoItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					TipoDocumentoCollectionTemp.Add(TipoDocumentoItem);
				}
			}
			return TipoDocumentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public TipoDocumentoCollection FiltroAttivo(NullTypes.BoolNT AttivoEqualThis)
		{
			TipoDocumentoCollection TipoDocumentoCollectionTemp = new TipoDocumentoCollection();
			foreach (TipoDocumento TipoDocumentoItem in this)
			{
				if (((AttivoEqualThis == null) || ((TipoDocumentoItem.Attivo != null) && (TipoDocumentoItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					TipoDocumentoCollectionTemp.Add(TipoDocumentoItem);
				}
			}
			return TipoDocumentoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoDocumentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoDocumentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoDocumento TipoDocumentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", TipoDocumentoObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Formato", TipoDocumentoObj.Formato);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoDocumentoObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", TipoDocumentoObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, TipoDocumento TipoDocumentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoDocumentoInsert", new string[] {"Codice", "Formato", "Descrizione", 
"Attivo"}, new string[] {"string", "string", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,TipoDocumentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TipoDocumentoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoDocumentoObj.IsDirty = false;
				TipoDocumentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoDocumento TipoDocumentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoDocumentoUpdate", new string[] {"Codice", "Formato", "Descrizione", 
"Attivo"}, new string[] {"string", "string", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,TipoDocumentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoDocumentoObj.IsDirty = false;
				TipoDocumentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoDocumento TipoDocumentoObj)
		{
			switch (TipoDocumentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoDocumentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoDocumentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoDocumentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoDocumentoCollection TipoDocumentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoDocumentoUpdate", new string[] {"Codice", "Formato", "Descrizione", 
"Attivo"}, new string[] {"string", "string", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoDocumentoInsert", new string[] {"Codice", "Formato", "Descrizione", 
"Attivo"}, new string[] {"string", "string", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoDocumentoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < TipoDocumentoCollectionObj.Count; i++)
				{
					switch (TipoDocumentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoDocumentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TipoDocumentoCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoDocumentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoDocumentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)TipoDocumentoCollectionObj[i].Codice);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoDocumentoCollectionObj.Count; i++)
				{
					if ((TipoDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoDocumentoCollectionObj[i].IsDirty = false;
						TipoDocumentoCollectionObj[i].IsPersistent = true;
					}
					if ((TipoDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoDocumentoCollectionObj[i].IsDirty = false;
						TipoDocumentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoDocumento TipoDocumentoObj)
		{
			int returnValue = 0;
			if (TipoDocumentoObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoDocumentoObj.Codice);
			}
			TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoDocumentoObj.IsDirty = false;
			TipoDocumentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodiceValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoDocumentoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoDocumentoCollection TipoDocumentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoDocumentoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < TipoDocumentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", TipoDocumentoCollectionObj[i].Codice);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoDocumentoCollectionObj.Count; i++)
				{
					if ((TipoDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoDocumentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoDocumentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoDocumentoCollectionObj[i].IsDirty = false;
						TipoDocumentoCollectionObj[i].IsPersistent = false;
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
		public static TipoDocumento GetById(DbProvider db, string CodiceValue)
		{
			TipoDocumento TipoDocumentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoDocumentoGetById", new string[] {"Codice"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoDocumentoObj = GetFromDatareader(db);
				TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoDocumentoObj.IsDirty = false;
				TipoDocumentoObj.IsPersistent = true;
			}
			db.Close();
			return TipoDocumentoObj;
		}

		//getFromDatareader
		public static TipoDocumento GetFromDatareader(DbProvider db)
		{
			TipoDocumento TipoDocumentoObj = new TipoDocumento();
			TipoDocumentoObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			TipoDocumentoObj.Formato = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMATO"]);
			TipoDocumentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoDocumentoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoDocumentoObj.IsDirty = false;
			TipoDocumentoObj.IsPersistent = true;
			return TipoDocumentoObj;
		}

		//Find Select

		public static TipoDocumentoCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT FormatoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			TipoDocumentoCollection TipoDocumentoCollectionObj = new TipoDocumentoCollection();

			IDbCommand findCmd = db.InitCmd("Ztipodocumentofindselect", new string[] {"Codiceequalthis", "Formatoequalthis", "Descrizioneequalthis", 
"Attivoequalthis"}, new string[] {"string", "string", "string", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Formatoequalthis", FormatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			TipoDocumento TipoDocumentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoDocumentoObj = GetFromDatareader(db);
				TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoDocumentoObj.IsDirty = false;
				TipoDocumentoObj.IsPersistent = true;
				TipoDocumentoCollectionObj.Add(TipoDocumentoObj);
			}
			db.Close();
			return TipoDocumentoCollectionObj;
		}

		//Find Find

		public static TipoDocumentoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT FormatoEqualThis)

		{

			TipoDocumentoCollection TipoDocumentoCollectionObj = new TipoDocumentoCollection();

			IDbCommand findCmd = db.InitCmd("Ztipodocumentofindfind", new string[] {"Codiceequalthis", "Formatoequalthis"}, new string[] {"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Formatoequalthis", FormatoEqualThis);
			TipoDocumento TipoDocumentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoDocumentoObj = GetFromDatareader(db);
				TipoDocumentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoDocumentoObj.IsDirty = false;
				TipoDocumentoObj.IsPersistent = true;
				TipoDocumentoCollectionObj.Add(TipoDocumentoObj);
			}
			db.Close();
			return TipoDocumentoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoDocumentoCollectionProvider:ITipoDocumentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoDocumentoCollectionProvider : ITipoDocumentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoDocumento
		protected TipoDocumentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoDocumentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoDocumentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoDocumentoCollectionProvider(StringNT CodiceEqualThis, StringNT FormatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodiceEqualThis, FormatoEqualThis);
		}

		//Costruttore3: ha in input tipodocumentoCollectionObj - non popola la collection
		public TipoDocumentoCollectionProvider(TipoDocumentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoDocumentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoDocumentoCollection(this);
		}

		//Get e Set
		public TipoDocumentoCollection CollectionObj
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
		public int SaveCollection(TipoDocumentoCollection collectionObj)
		{
			return TipoDocumentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoDocumento tipodocumentoObj)
		{
			return TipoDocumentoDAL.Save(_dbProviderObj, tipodocumentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoDocumentoCollection collectionObj)
		{
			return TipoDocumentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoDocumento tipodocumentoObj)
		{
			return TipoDocumentoDAL.Delete(_dbProviderObj, tipodocumentoObj);
		}

		//getById
		public TipoDocumento GetById(StringNT CodiceValue)
		{
			TipoDocumento TipoDocumentoTemp = TipoDocumentoDAL.GetById(_dbProviderObj, CodiceValue);
			if (TipoDocumentoTemp!=null) TipoDocumentoTemp.Provider = this;
			return TipoDocumentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoDocumentoCollection Select(StringNT CodiceEqualThis, StringNT FormatoEqualThis, StringNT DescrizioneEqualThis, 
BoolNT AttivoEqualThis)
		{
			TipoDocumentoCollection TipoDocumentoCollectionTemp = TipoDocumentoDAL.Select(_dbProviderObj, CodiceEqualThis, FormatoEqualThis, DescrizioneEqualThis, 
AttivoEqualThis);
			TipoDocumentoCollectionTemp.Provider = this;
			return TipoDocumentoCollectionTemp;
		}

		//Find: popola la collection
		public TipoDocumentoCollection Find(StringNT CodiceEqualThis, StringNT FormatoEqualThis)
		{
			TipoDocumentoCollection TipoDocumentoCollectionTemp = TipoDocumentoDAL.Find(_dbProviderObj, CodiceEqualThis, FormatoEqualThis);
			TipoDocumentoCollectionTemp.Provider = this;
			return TipoDocumentoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_DOCUMENTO>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <CODICE>Equal</CODICE>
      <FORMATO>Equal</FORMATO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivo>
      <ATTIVO>Equal</ATTIVO>
    </FiltroAttivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TIPO_DOCUMENTO>
*/
