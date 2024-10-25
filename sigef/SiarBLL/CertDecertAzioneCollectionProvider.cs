using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertDecertAzione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertDecertAzioneProvider
	{
		int Save(CertDecertAzione CertDecertAzioneObj);
		int SaveCollection(CertDecertAzioneCollection collectionObj);
		int Delete(CertDecertAzione CertDecertAzioneObj);
		int DeleteCollection(CertDecertAzioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertDecertAzione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertDecertAzione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCertDecertAzione;
		private NullTypes.IntNT _IdCertDecertificazione;
		private NullTypes.IntNT _IdAzioneDecertificazione;
		private NullTypes.StringNT _TipoAzioneDecertificazione;
		[NonSerialized] private ICertDecertAzioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertAzioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertDecertAzione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CERT_DECERT_AZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertDecertAzione
		{
			get { return _IdCertDecertAzione; }
			set {
				if (IdCertDecertAzione != value)
				{
					_IdCertDecertAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CERT_DECERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertDecertificazione
		{
			get { return _IdCertDecertificazione; }
			set {
				if (IdCertDecertificazione != value)
				{
					_IdCertDecertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AZIONE_DECERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAzioneDecertificazione
		{
			get { return _IdAzioneDecertificazione; }
			set {
				if (IdAzioneDecertificazione != value)
				{
					_IdAzioneDecertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_AZIONE_DECERTIFICAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoAzioneDecertificazione
		{
			get { return _TipoAzioneDecertificazione; }
			set {
				if (TipoAzioneDecertificazione != value)
				{
					_TipoAzioneDecertificazione = value;
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
	/// Summary description for CertDecertAzioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertAzioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertDecertAzioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertDecertAzione) info.GetValue(i.ToString(),typeof(CertDecertAzione)));
			}
		}

		//Costruttore
		public CertDecertAzioneCollection()
		{
			this.ItemType = typeof(CertDecertAzione);
		}

		//Costruttore con provider
		public CertDecertAzioneCollection(ICertDecertAzioneProvider providerObj)
		{
			this.ItemType = typeof(CertDecertAzione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertDecertAzione this[int index]
		{
			get { return (CertDecertAzione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertDecertAzioneCollection GetChanges()
		{
			return (CertDecertAzioneCollection) base.GetChanges();
		}

		[NonSerialized] private ICertDecertAzioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertDecertAzioneProvider Provider
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
		public int Add(CertDecertAzione CertDecertAzioneObj)
		{
			if (CertDecertAzioneObj.Provider == null) CertDecertAzioneObj.Provider = this.Provider;
			return base.Add(CertDecertAzioneObj);
		}

		//AddCollection
		public void AddCollection(CertDecertAzioneCollection CertDecertAzioneCollectionObj)
		{
			foreach (CertDecertAzione CertDecertAzioneObj in CertDecertAzioneCollectionObj)
				this.Add(CertDecertAzioneObj);
		}

		//Insert
		public void Insert(int index, CertDecertAzione CertDecertAzioneObj)
		{
			if (CertDecertAzioneObj.Provider == null) CertDecertAzioneObj.Provider = this.Provider;
			base.Insert(index, CertDecertAzioneObj);
		}

		//CollectionGetById
		public CertDecertAzione CollectionGetById(NullTypes.IntNT IdCertDecertAzioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCertDecertAzione == IdCertDecertAzioneValue))
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
		public CertDecertAzioneCollection SubSelect(NullTypes.IntNT IdCertDecertAzioneEqualThis, NullTypes.IntNT IdCertDecertificazioneEqualThis, NullTypes.IntNT IdAzioneDecertificazioneEqualThis, 
NullTypes.StringNT TipoAzioneDecertificazioneEqualThis)
		{
			CertDecertAzioneCollection CertDecertAzioneCollectionTemp = new CertDecertAzioneCollection();
			foreach (CertDecertAzione CertDecertAzioneItem in this)
			{
				if (((IdCertDecertAzioneEqualThis == null) || ((CertDecertAzioneItem.IdCertDecertAzione != null) && (CertDecertAzioneItem.IdCertDecertAzione.Value == IdCertDecertAzioneEqualThis.Value))) && ((IdCertDecertificazioneEqualThis == null) || ((CertDecertAzioneItem.IdCertDecertificazione != null) && (CertDecertAzioneItem.IdCertDecertificazione.Value == IdCertDecertificazioneEqualThis.Value))) && ((IdAzioneDecertificazioneEqualThis == null) || ((CertDecertAzioneItem.IdAzioneDecertificazione != null) && (CertDecertAzioneItem.IdAzioneDecertificazione.Value == IdAzioneDecertificazioneEqualThis.Value))) && 
((TipoAzioneDecertificazioneEqualThis == null) || ((CertDecertAzioneItem.TipoAzioneDecertificazione != null) && (CertDecertAzioneItem.TipoAzioneDecertificazione.Value == TipoAzioneDecertificazioneEqualThis.Value))))
				{
					CertDecertAzioneCollectionTemp.Add(CertDecertAzioneItem);
				}
			}
			return CertDecertAzioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertDecertAzioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertDecertAzioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertDecertAzione CertDecertAzioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCertDecertAzione", CertDecertAzioneObj.IdCertDecertAzione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertDecertificazione", CertDecertAzioneObj.IdCertDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAzioneDecertificazione", CertDecertAzioneObj.IdAzioneDecertificazione);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoAzioneDecertificazione", CertDecertAzioneObj.TipoAzioneDecertificazione);
		}
		//Insert
		private static int Insert(DbProvider db, CertDecertAzione CertDecertAzioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertAzioneInsert", new string[] {"IdCertDecertificazione", "IdAzioneDecertificazione", 
"TipoAzioneDecertificazione"}, new string[] {"int", "int", 
"string"},"");
				CompileIUCmd(false, insertCmd,CertDecertAzioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertDecertAzioneObj.IdCertDecertAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERT_AZIONE"]);
				}
				CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertAzioneObj.IsDirty = false;
				CertDecertAzioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertDecertAzione CertDecertAzioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertAzioneUpdate", new string[] {"IdCertDecertAzione", "IdCertDecertificazione", "IdAzioneDecertificazione", 
"TipoAzioneDecertificazione"}, new string[] {"int", "int", "int", 
"string"},"");
				CompileIUCmd(true, updateCmd,CertDecertAzioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertAzioneObj.IsDirty = false;
				CertDecertAzioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertDecertAzione CertDecertAzioneObj)
		{
			switch (CertDecertAzioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertDecertAzioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertDecertAzioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertDecertAzioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertDecertAzioneCollection CertDecertAzioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertDecertAzioneUpdate", new string[] {"IdCertDecertAzione", "IdCertDecertificazione", "IdAzioneDecertificazione", 
"TipoAzioneDecertificazione"}, new string[] {"int", "int", "int", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertDecertAzioneInsert", new string[] {"IdCertDecertificazione", "IdAzioneDecertificazione", 
"TipoAzioneDecertificazione"}, new string[] {"int", "int", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertAzioneDelete", new string[] {"IdCertDecertAzione"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertAzioneCollectionObj.Count; i++)
				{
					switch (CertDecertAzioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertDecertAzioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertDecertAzioneCollectionObj[i].IdCertDecertAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERT_AZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertDecertAzioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertDecertAzioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertAzione", (SiarLibrary.NullTypes.IntNT)CertDecertAzioneCollectionObj[i].IdCertDecertAzione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertDecertAzioneCollectionObj.Count; i++)
				{
					if ((CertDecertAzioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertAzioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertAzioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertDecertAzioneCollectionObj[i].IsDirty = false;
						CertDecertAzioneCollectionObj[i].IsPersistent = true;
					}
					if ((CertDecertAzioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertDecertAzioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertAzioneCollectionObj[i].IsDirty = false;
						CertDecertAzioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertDecertAzione CertDecertAzioneObj)
		{
			int returnValue = 0;
			if (CertDecertAzioneObj.IsPersistent) 
			{
				returnValue = Delete(db, CertDecertAzioneObj.IdCertDecertAzione);
			}
			CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertDecertAzioneObj.IsDirty = false;
			CertDecertAzioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCertDecertAzioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertAzioneDelete", new string[] {"IdCertDecertAzione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertAzione", (SiarLibrary.NullTypes.IntNT)IdCertDecertAzioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertDecertAzioneCollection CertDecertAzioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertDecertAzioneDelete", new string[] {"IdCertDecertAzione"}, new string[] {"int"},"");
				for (int i = 0; i < CertDecertAzioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertDecertAzione", CertDecertAzioneCollectionObj[i].IdCertDecertAzione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertDecertAzioneCollectionObj.Count; i++)
				{
					if ((CertDecertAzioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertDecertAzioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertDecertAzioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertDecertAzioneCollectionObj[i].IsDirty = false;
						CertDecertAzioneCollectionObj[i].IsPersistent = false;
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
		public static CertDecertAzione GetById(DbProvider db, int IdCertDecertAzioneValue)
		{
			CertDecertAzione CertDecertAzioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertDecertAzioneGetById", new string[] {"IdCertDecertAzione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCertDecertAzione", (SiarLibrary.NullTypes.IntNT)IdCertDecertAzioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertDecertAzioneObj = GetFromDatareader(db);
				CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertAzioneObj.IsDirty = false;
				CertDecertAzioneObj.IsPersistent = true;
			}
			db.Close();
			return CertDecertAzioneObj;
		}

		//getFromDatareader
		public static CertDecertAzione GetFromDatareader(DbProvider db)
		{
			CertDecertAzione CertDecertAzioneObj = new CertDecertAzione();
			CertDecertAzioneObj.IdCertDecertAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERT_AZIONE"]);
			CertDecertAzioneObj.IdCertDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERT_DECERTIFICAZIONE"]);
			CertDecertAzioneObj.IdAzioneDecertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AZIONE_DECERTIFICAZIONE"]);
			CertDecertAzioneObj.TipoAzioneDecertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_AZIONE_DECERTIFICAZIONE"]);
			CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertDecertAzioneObj.IsDirty = false;
			CertDecertAzioneObj.IsPersistent = true;
			return CertDecertAzioneObj;
		}

		//Find Select

		public static CertDecertAzioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertDecertAzioneEqualThis, SiarLibrary.NullTypes.IntNT IdCertDecertificazioneEqualThis, SiarLibrary.NullTypes.IntNT IdAzioneDecertificazioneEqualThis, 
SiarLibrary.NullTypes.StringNT TipoAzioneDecertificazioneEqualThis)

		{

			CertDecertAzioneCollection CertDecertAzioneCollectionObj = new CertDecertAzioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcertdecertazionefindselect", new string[] {"IdCertDecertAzioneequalthis", "IdCertDecertificazioneequalthis", "IdAzioneDecertificazioneequalthis", 
"TipoAzioneDecertificazioneequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertDecertAzioneequalthis", IdCertDecertAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertDecertificazioneequalthis", IdCertDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneDecertificazioneequalthis", IdAzioneDecertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoAzioneDecertificazioneequalthis", TipoAzioneDecertificazioneEqualThis);
			CertDecertAzione CertDecertAzioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertDecertAzioneObj = GetFromDatareader(db);
				CertDecertAzioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertDecertAzioneObj.IsDirty = false;
				CertDecertAzioneObj.IsPersistent = true;
				CertDecertAzioneCollectionObj.Add(CertDecertAzioneObj);
			}
			db.Close();
			return CertDecertAzioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertDecertAzioneCollectionProvider:ICertDecertAzioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertDecertAzioneCollectionProvider : ICertDecertAzioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertDecertAzione
		protected CertDecertAzioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertDecertAzioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertDecertAzioneCollection(this);
		}

		//Costruttore3: ha in input certdecertazioneCollectionObj - non popola la collection
		public CertDecertAzioneCollectionProvider(CertDecertAzioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertDecertAzioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertDecertAzioneCollection(this);
		}

		//Get e Set
		public CertDecertAzioneCollection CollectionObj
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
		public int SaveCollection(CertDecertAzioneCollection collectionObj)
		{
			return CertDecertAzioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertDecertAzione certdecertazioneObj)
		{
			return CertDecertAzioneDAL.Save(_dbProviderObj, certdecertazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertDecertAzioneCollection collectionObj)
		{
			return CertDecertAzioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertDecertAzione certdecertazioneObj)
		{
			return CertDecertAzioneDAL.Delete(_dbProviderObj, certdecertazioneObj);
		}

		//getById
		public CertDecertAzione GetById(IntNT IdCertDecertAzioneValue)
		{
			CertDecertAzione CertDecertAzioneTemp = CertDecertAzioneDAL.GetById(_dbProviderObj, IdCertDecertAzioneValue);
			if (CertDecertAzioneTemp!=null) CertDecertAzioneTemp.Provider = this;
			return CertDecertAzioneTemp;
		}

		//Select: popola la collection
		public CertDecertAzioneCollection Select(IntNT IdcertdecertazioneEqualThis, IntNT IdcertdecertificazioneEqualThis, IntNT IdazionedecertificazioneEqualThis, 
StringNT TipoazionedecertificazioneEqualThis)
		{
			CertDecertAzioneCollection CertDecertAzioneCollectionTemp = CertDecertAzioneDAL.Select(_dbProviderObj, IdcertdecertazioneEqualThis, IdcertdecertificazioneEqualThis, IdazionedecertificazioneEqualThis, 
TipoazionedecertificazioneEqualThis);
			CertDecertAzioneCollectionTemp.Provider = this;
			return CertDecertAzioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERT_DECERT_AZIONE>
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
</CERT_DECERT_AZIONE>
*/
