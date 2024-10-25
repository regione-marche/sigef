using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidAutodichiarazioneRequisiti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidAutodichiarazioneRequisitiProvider
	{
		int Save(CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj);
		int SaveCollection(CovidAutodichiarazioneRequisitiCollection collectionObj);
		int Delete(CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj);
		int DeleteCollection(CovidAutodichiarazioneRequisitiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidAutodichiarazioneRequisiti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidAutodichiarazioneRequisiti : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdAutocertificazione;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Valore;
		[NonSerialized] private ICovidAutodichiarazioneRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidAutodichiarazioneRequisitiProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public CovidAutodichiarazioneRequisiti()
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
			set
			{
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AUTOCERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAutocertificazione
		{
			get { return _IdAutocertificazione; }
			set
			{
				if (IdAutocertificazione != value)
				{
					_IdAutocertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set
			{
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set
			{
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Valore
		{
			get { return _Valore; }
			set
			{
				if (Valore != value)
				{
					_Valore = value;
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
	/// Summary description for CovidAutodichiarazioneRequisitiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneRequisitiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count", this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				info.AddValue(i.ToString(), this[i]);
			}
		}
		private CovidAutodichiarazioneRequisitiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((CovidAutodichiarazioneRequisiti)info.GetValue(i.ToString(), typeof(CovidAutodichiarazioneRequisiti)));
			}
		}

		//Costruttore
		public CovidAutodichiarazioneRequisitiCollection()
		{
			this.ItemType = typeof(CovidAutodichiarazioneRequisiti);
		}

		//Costruttore con provider
		public CovidAutodichiarazioneRequisitiCollection(ICovidAutodichiarazioneRequisitiProvider providerObj)
		{
			this.ItemType = typeof(CovidAutodichiarazioneRequisiti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidAutodichiarazioneRequisiti this[int index]
		{
			get { return (CovidAutodichiarazioneRequisiti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidAutodichiarazioneRequisitiCollection GetChanges()
		{
			return (CovidAutodichiarazioneRequisitiCollection)base.GetChanges();
		}

		[NonSerialized] private ICovidAutodichiarazioneRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidAutodichiarazioneRequisitiProvider Provider
		{
			get { return _provider; }
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
		public int Add(CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			if (CovidAutodichiarazioneRequisitiObj.Provider == null) CovidAutodichiarazioneRequisitiObj.Provider = this.Provider;
			return base.Add(CovidAutodichiarazioneRequisitiObj);
		}

		//AddCollection
		public void AddCollection(CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionObj)
		{
			foreach (CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj in CovidAutodichiarazioneRequisitiCollectionObj)
				this.Add(CovidAutodichiarazioneRequisitiObj);
		}

		//Insert
		public void Insert(int index, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			if (CovidAutodichiarazioneRequisitiObj.Provider == null) CovidAutodichiarazioneRequisitiObj.Provider = this.Provider;
			base.Insert(index, CovidAutodichiarazioneRequisitiObj);
		}

		//CollectionGetById
		public CovidAutodichiarazioneRequisiti CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
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
		public CovidAutodichiarazioneRequisitiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdAutocertificazioneEqualThis, NullTypes.StringNT CodiceEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT ValoreEqualThis)
		{
			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionTemp = new CovidAutodichiarazioneRequisitiCollection();
			foreach (CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiItem in this)
			{
				if (((IdEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Id != null) && (CovidAutodichiarazioneRequisitiItem.Id.Value == IdEqualThis.Value))) && ((IdAutocertificazioneEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.IdAutocertificazione != null) && (CovidAutodichiarazioneRequisitiItem.IdAutocertificazione.Value == IdAutocertificazioneEqualThis.Value))) && ((CodiceEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Codice != null) && (CovidAutodichiarazioneRequisitiItem.Codice.Value == CodiceEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Descrizione != null) && (CovidAutodichiarazioneRequisitiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ValoreEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Valore != null) && (CovidAutodichiarazioneRequisitiItem.Valore.Value == ValoreEqualThis.Value))))
				{
					CovidAutodichiarazioneRequisitiCollectionTemp.Add(CovidAutodichiarazioneRequisitiItem);
				}
			}
			return CovidAutodichiarazioneRequisitiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CovidAutodichiarazioneRequisitiCollection Filter(NullTypes.IntNT IdAutocertificazioneEqualThis, NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionTemp = new CovidAutodichiarazioneRequisitiCollection();
			foreach (CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiItem in this)
			{
				if (((IdAutocertificazioneEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.IdAutocertificazione != null) && (CovidAutodichiarazioneRequisitiItem.IdAutocertificazione.Value == IdAutocertificazioneEqualThis.Value))) && ((CodiceEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Codice != null) && (CovidAutodichiarazioneRequisitiItem.Codice.Value == CodiceEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((CovidAutodichiarazioneRequisitiItem.Descrizione != null) && (CovidAutodichiarazioneRequisitiItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					CovidAutodichiarazioneRequisitiCollectionTemp.Add(CovidAutodichiarazioneRequisitiItem);
				}
			}
			return CovidAutodichiarazioneRequisitiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneRequisitiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidAutodichiarazioneRequisitiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "Id", CovidAutodichiarazioneRequisitiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdAutocertificazione", CovidAutodichiarazioneRequisitiObj.IdAutocertificazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Codice", CovidAutodichiarazioneRequisitiObj.Codice);
			DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", CovidAutodichiarazioneRequisitiObj.Descrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "Valore", CovidAutodichiarazioneRequisitiObj.Valore);
		}
		//Insert
		private static int Insert(DbProvider db, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiInsert", new string[] {"IdAutocertificazione", "Codice",
"Descrizione", "Valore"}, new string[] {"int", "string",
"string", "string"}, "");
				CompileIUCmd(false, insertCmd, CovidAutodichiarazioneRequisitiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					CovidAutodichiarazioneRequisitiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneRequisitiObj.IsDirty = false;
				CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiUpdate", new string[] {"Id", "IdAutocertificazione", "Codice",
"Descrizione", "Valore"}, new string[] {"int", "int", "string",
"string", "string"}, "");
				CompileIUCmd(true, updateCmd, CovidAutodichiarazioneRequisitiObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneRequisitiObj.IsDirty = false;
				CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			switch (CovidAutodichiarazioneRequisitiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, CovidAutodichiarazioneRequisitiObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, CovidAutodichiarazioneRequisitiObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, CovidAutodichiarazioneRequisitiObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiUpdate", new string[] {"Id", "IdAutocertificazione", "Codice",
"Descrizione", "Valore"}, new string[] {"int", "int", "string",
"string", "string"}, "");
				IDbCommand insertCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiInsert", new string[] {"IdAutocertificazione", "Codice",
"Descrizione", "Valore"}, new string[] {"int", "string",
"string", "string"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidAutodichiarazioneRequisitiCollectionObj.Count; i++)
				{
					switch (CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, CovidAutodichiarazioneRequisitiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidAutodichiarazioneRequisitiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, CovidAutodichiarazioneRequisitiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (CovidAutodichiarazioneRequisitiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CovidAutodichiarazioneRequisitiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneRequisitiCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsPersistent = true;
					}
					if ((CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj)
		{
			int returnValue = 0;
			if (CovidAutodichiarazioneRequisitiObj.IsPersistent)
			{
				returnValue = Delete(db, CovidAutodichiarazioneRequisitiObj.Id);
			}
			CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidAutodichiarazioneRequisitiObj.IsDirty = false;
			CovidAutodichiarazioneRequisitiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidAutodichiarazioneRequisitiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", CovidAutodichiarazioneRequisitiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneRequisitiCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneRequisitiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneRequisitiCollectionObj[i].IsPersistent = false;
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
		public static CovidAutodichiarazioneRequisiti GetById(DbProvider db, int IdValue)
		{
			CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj = null;
			IDbCommand readCmd = db.InitCmd("ZCovidAutodichiarazioneRequisitiGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidAutodichiarazioneRequisitiObj = GetFromDatareader(db);
				CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneRequisitiObj.IsDirty = false;
				CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
			}
			db.Close();
			return CovidAutodichiarazioneRequisitiObj;
		}

		//getFromDatareader
		public static CovidAutodichiarazioneRequisiti GetFromDatareader(DbProvider db)
		{
			CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj = new CovidAutodichiarazioneRequisiti();
			CovidAutodichiarazioneRequisitiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CovidAutodichiarazioneRequisitiObj.IdAutocertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AUTOCERTIFICAZIONE"]);
			CovidAutodichiarazioneRequisitiObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			CovidAutodichiarazioneRequisitiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CovidAutodichiarazioneRequisitiObj.Valore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE"]);
			CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidAutodichiarazioneRequisitiObj.IsDirty = false;
			CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
			return CovidAutodichiarazioneRequisitiObj;
		}

		//Find Select

		public static CovidAutodichiarazioneRequisitiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdAutocertificazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT ValoreEqualThis)

		{

			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionObj = new CovidAutodichiarazioneRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazionerequisitifindselect", new string[] {"Idequalthis", "IdAutocertificazioneequalthis", "Codiceequalthis",
"Descrizioneequalthis", "Valoreequalthis"}, new string[] {"int", "int", "string",
"string", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAutocertificazioneequalthis", IdAutocertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneRequisitiObj = GetFromDatareader(db);
				CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneRequisitiObj.IsDirty = false;
				CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
				CovidAutodichiarazioneRequisitiCollectionObj.Add(CovidAutodichiarazioneRequisitiObj);
			}
			db.Close();
			return CovidAutodichiarazioneRequisitiCollectionObj;
		}

		//Find Find

		public static CovidAutodichiarazioneRequisitiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAutocertificazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionObj = new CovidAutodichiarazioneRequisitiCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazionerequisitifindfind", new string[] { "IdAutocertificazioneequalthis", "Codiceequalthis", "Descrizioneequalthis" }, new string[] { "int", "string", "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAutocertificazioneequalthis", IdAutocertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneRequisitiObj = GetFromDatareader(db);
				CovidAutodichiarazioneRequisitiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneRequisitiObj.IsDirty = false;
				CovidAutodichiarazioneRequisitiObj.IsPersistent = true;
				CovidAutodichiarazioneRequisitiCollectionObj.Add(CovidAutodichiarazioneRequisitiObj);
			}
			db.Close();
			return CovidAutodichiarazioneRequisitiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneRequisitiCollectionProvider:ICovidAutodichiarazioneRequisitiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneRequisitiCollectionProvider : ICovidAutodichiarazioneRequisitiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidAutodichiarazioneRequisiti
		protected CovidAutodichiarazioneRequisitiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidAutodichiarazioneRequisitiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidAutodichiarazioneRequisitiCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidAutodichiarazioneRequisitiCollectionProvider(IntNT IdautocertificazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdautocertificazioneEqualThis, CodiceEqualThis, DescrizioneEqualThis);
		}

		//Costruttore3: ha in input covidautodichiarazionerequisitiCollectionObj - non popola la collection
		public CovidAutodichiarazioneRequisitiCollectionProvider(CovidAutodichiarazioneRequisitiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidAutodichiarazioneRequisitiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidAutodichiarazioneRequisitiCollection(this);
		}

		//Get e Set
		public CovidAutodichiarazioneRequisitiCollection CollectionObj
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
		public int SaveCollection(CovidAutodichiarazioneRequisitiCollection collectionObj)
		{
			return CovidAutodichiarazioneRequisitiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidAutodichiarazioneRequisiti covidautodichiarazionerequisitiObj)
		{
			return CovidAutodichiarazioneRequisitiDAL.Save(_dbProviderObj, covidautodichiarazionerequisitiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidAutodichiarazioneRequisitiCollection collectionObj)
		{
			return CovidAutodichiarazioneRequisitiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidAutodichiarazioneRequisiti covidautodichiarazionerequisitiObj)
		{
			return CovidAutodichiarazioneRequisitiDAL.Delete(_dbProviderObj, covidautodichiarazionerequisitiObj);
		}

		//getById
		public CovidAutodichiarazioneRequisiti GetById(IntNT IdValue)
		{
			CovidAutodichiarazioneRequisiti CovidAutodichiarazioneRequisitiTemp = CovidAutodichiarazioneRequisitiDAL.GetById(_dbProviderObj, IdValue);
			if (CovidAutodichiarazioneRequisitiTemp != null) CovidAutodichiarazioneRequisitiTemp.Provider = this;
			return CovidAutodichiarazioneRequisitiTemp;
		}

		//Select: popola la collection
		public CovidAutodichiarazioneRequisitiCollection Select(IntNT IdEqualThis, IntNT IdautocertificazioneEqualThis, StringNT CodiceEqualThis,
StringNT DescrizioneEqualThis, StringNT ValoreEqualThis)
		{
			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionTemp = CovidAutodichiarazioneRequisitiDAL.Select(_dbProviderObj, IdEqualThis, IdautocertificazioneEqualThis, CodiceEqualThis,
DescrizioneEqualThis, ValoreEqualThis);
			CovidAutodichiarazioneRequisitiCollectionTemp.Provider = this;
			return CovidAutodichiarazioneRequisitiCollectionTemp;
		}

		//Find: popola la collection
		public CovidAutodichiarazioneRequisitiCollection Find(IntNT IdautocertificazioneEqualThis, StringNT CodiceEqualThis, StringNT DescrizioneEqualThis)
		{
			CovidAutodichiarazioneRequisitiCollection CovidAutodichiarazioneRequisitiCollectionTemp = CovidAutodichiarazioneRequisitiDAL.Find(_dbProviderObj, IdautocertificazioneEqualThis, CodiceEqualThis, DescrizioneEqualThis);
			CovidAutodichiarazioneRequisitiCollectionTemp.Provider = this;
			return CovidAutodichiarazioneRequisitiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_AUTODICHIARAZIONE_REQUISITI>
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
      <ID_AUTOCERTIFICAZIONE>Equal</ID_AUTOCERTIFICAZIONE>
      <CODICE>Equal</CODICE>
      <DESCRIZIONE>Equal</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_AUTOCERTIFICAZIONE>Equal</ID_AUTOCERTIFICAZIONE>
      <CODICE>Equal</CODICE>
      <DESCRIZIONE>Equal</DESCRIZIONE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COVID_AUTODICHIARAZIONE_REQUISITI>
*/
