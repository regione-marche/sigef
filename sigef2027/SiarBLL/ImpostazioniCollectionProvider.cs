using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Impostazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpostazioniProvider
	{
		int Save(Impostazioni ImpostazioniObj);
		int SaveCollection(ImpostazioniCollection collectionObj);
		int Delete(Impostazioni ImpostazioniObj);
		int DeleteCollection(ImpostazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Impostazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Impostazioni : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Chiave;
		private NullTypes.StringNT _Istanza;
		private NullTypes.BoolNT _ValoreBool;
		private NullTypes.IntNT _ValoreInt;
		private NullTypes.DecimalNT _ValoreDecimal;
		private NullTypes.StringNT _ValoreText;
		[NonSerialized] private IImpostazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IImpostazioniProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public Impostazioni()
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
		/// Corrisponde al campo:CHIAVE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Chiave
		{
			get { return _Chiave; }
			set
			{
				if (Chiave != value)
				{
					_Chiave = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Istanza
		{
			get { return _Istanza; }
			set
			{
				if (Istanza != value)
				{
					_Istanza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_BOOL
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ValoreBool
		{
			get { return _ValoreBool; }
			set
			{
				if (ValoreBool != value)
				{
					_ValoreBool = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_INT
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT ValoreInt
		{
			get { return _ValoreInt; }
			set
			{
				if (ValoreInt != value)
				{
					_ValoreInt = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_DECIMAL
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreDecimal
		{
			get { return _ValoreDecimal; }
			set
			{
				if (ValoreDecimal != value)
				{
					_ValoreDecimal = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_TEXT
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT ValoreText
		{
			get { return _ValoreText; }
			set
			{
				if (ValoreText != value)
				{
					_ValoreText = value;
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
	/// Summary description for ImpostazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpostazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ImpostazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((Impostazioni)info.GetValue(i.ToString(), typeof(Impostazioni)));
			}
		}

		//Costruttore
		public ImpostazioniCollection()
		{
			this.ItemType = typeof(Impostazioni);
		}

		//Costruttore con provider
		public ImpostazioniCollection(IImpostazioniProvider providerObj)
		{
			this.ItemType = typeof(Impostazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Impostazioni this[int index]
		{
			get { return (Impostazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ImpostazioniCollection GetChanges()
		{
			return (ImpostazioniCollection)base.GetChanges();
		}

		[NonSerialized] private IImpostazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IImpostazioniProvider Provider
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
		public int Add(Impostazioni ImpostazioniObj)
		{
			if (ImpostazioniObj.Provider == null) ImpostazioniObj.Provider = this.Provider;
			return base.Add(ImpostazioniObj);
		}

		//AddCollection
		public void AddCollection(ImpostazioniCollection ImpostazioniCollectionObj)
		{
			foreach (Impostazioni ImpostazioniObj in ImpostazioniCollectionObj)
				this.Add(ImpostazioniObj);
		}

		//Insert
		public void Insert(int index, Impostazioni ImpostazioniObj)
		{
			if (ImpostazioniObj.Provider == null) ImpostazioniObj.Provider = this.Provider;
			base.Insert(index, ImpostazioniObj);
		}

		//CollectionGetById
		public Impostazioni CollectionGetById(NullTypes.IntNT IdValue)
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
		public ImpostazioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT ChiaveEqualThis, NullTypes.StringNT IstanzaEqualThis,
NullTypes.BoolNT ValoreBoolEqualThis, NullTypes.IntNT ValoreIntEqualThis, NullTypes.DecimalNT ValoreDecimalEqualThis,
NullTypes.StringNT ValoreTextEqualThis)
		{
			ImpostazioniCollection ImpostazioniCollectionTemp = new ImpostazioniCollection();
			foreach (Impostazioni ImpostazioniItem in this)
			{
				if (((IdEqualThis == null) || ((ImpostazioniItem.Id != null) && (ImpostazioniItem.Id.Value == IdEqualThis.Value))) && ((ChiaveEqualThis == null) || ((ImpostazioniItem.Chiave != null) && (ImpostazioniItem.Chiave.Value == ChiaveEqualThis.Value))) && ((IstanzaEqualThis == null) || ((ImpostazioniItem.Istanza != null) && (ImpostazioniItem.Istanza.Value == IstanzaEqualThis.Value))) &&
((ValoreBoolEqualThis == null) || ((ImpostazioniItem.ValoreBool != null) && (ImpostazioniItem.ValoreBool.Value == ValoreBoolEqualThis.Value))) && ((ValoreIntEqualThis == null) || ((ImpostazioniItem.ValoreInt != null) && (ImpostazioniItem.ValoreInt.Value == ValoreIntEqualThis.Value))) && ((ValoreDecimalEqualThis == null) || ((ImpostazioniItem.ValoreDecimal != null) && (ImpostazioniItem.ValoreDecimal.Value == ValoreDecimalEqualThis.Value))) &&
((ValoreTextEqualThis == null) || ((ImpostazioniItem.ValoreText != null) && (ImpostazioniItem.ValoreText.Value == ValoreTextEqualThis.Value))))
				{
					ImpostazioniCollectionTemp.Add(ImpostazioniItem);
				}
			}
			return ImpostazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ImpostazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ImpostazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Impostazioni ImpostazioniObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "Id", ImpostazioniObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "Chiave", ImpostazioniObj.Chiave);
			DbProvider.SetCmdParam(cmd, firstChar + "Istanza", ImpostazioniObj.Istanza);
			DbProvider.SetCmdParam(cmd, firstChar + "ValoreBool", ImpostazioniObj.ValoreBool);
			DbProvider.SetCmdParam(cmd, firstChar + "ValoreInt", ImpostazioniObj.ValoreInt);
			DbProvider.SetCmdParam(cmd, firstChar + "ValoreDecimal", ImpostazioniObj.ValoreDecimal);
			DbProvider.SetCmdParam(cmd, firstChar + "ValoreText", ImpostazioniObj.ValoreText);
		}
		//Insert
		private static int Insert(DbProvider db, Impostazioni ImpostazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZImpostazioniInsert", new string[] {"Chiave", "Istanza",
"ValoreBool", "ValoreInt", "ValoreDecimal",
"ValoreText"}, new string[] {"string", "string",
"bool", "int", "decimal",
"string"}, "");
				CompileIUCmd(false, insertCmd, ImpostazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					ImpostazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpostazioniObj.IsDirty = false;
				ImpostazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Impostazioni ImpostazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZImpostazioniUpdate", new string[] {"Id", "Chiave", "Istanza",
"ValoreBool", "ValoreInt", "ValoreDecimal",
"ValoreText"}, new string[] {"int", "string", "string",
"bool", "int", "decimal",
"string"}, "");
				CompileIUCmd(true, updateCmd, ImpostazioniObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpostazioniObj.IsDirty = false;
				ImpostazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Impostazioni ImpostazioniObj)
		{
			switch (ImpostazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ImpostazioniObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ImpostazioniObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ImpostazioniObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ImpostazioniCollection ImpostazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZImpostazioniUpdate", new string[] {"Id", "Chiave", "Istanza",
"ValoreBool", "ValoreInt", "ValoreDecimal",
"ValoreText"}, new string[] {"int", "string", "string",
"bool", "int", "decimal",
"string"}, "");
				IDbCommand insertCmd = db.InitCmd("ZImpostazioniInsert", new string[] {"Chiave", "Istanza",
"ValoreBool", "ValoreInt", "ValoreDecimal",
"ValoreText"}, new string[] {"string", "string",
"bool", "int", "decimal",
"string"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZImpostazioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < ImpostazioniCollectionObj.Count; i++)
				{
					switch (ImpostazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ImpostazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ImpostazioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ImpostazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ImpostazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ImpostazioniCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ImpostazioniCollectionObj.Count; i++)
				{
					if ((ImpostazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpostazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpostazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ImpostazioniCollectionObj[i].IsDirty = false;
						ImpostazioniCollectionObj[i].IsPersistent = true;
					}
					if ((ImpostazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ImpostazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpostazioniCollectionObj[i].IsDirty = false;
						ImpostazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Impostazioni ImpostazioniObj)
		{
			int returnValue = 0;
			if (ImpostazioniObj.IsPersistent)
			{
				returnValue = Delete(db, ImpostazioniObj.Id);
			}
			ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ImpostazioniObj.IsDirty = false;
			ImpostazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZImpostazioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ImpostazioniCollection ImpostazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZImpostazioniDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < ImpostazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ImpostazioniCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ImpostazioniCollectionObj.Count; i++)
				{
					if ((ImpostazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpostazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpostazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpostazioniCollectionObj[i].IsDirty = false;
						ImpostazioniCollectionObj[i].IsPersistent = false;
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
		public static Impostazioni GetById(DbProvider db, int IdValue)
		{
			Impostazioni ImpostazioniObj = null;
			IDbCommand readCmd = db.InitCmd("ZImpostazioniGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ImpostazioniObj = GetFromDatareader(db);
				ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpostazioniObj.IsDirty = false;
				ImpostazioniObj.IsPersistent = true;
			}
			db.Close();
			return ImpostazioniObj;
		}

		//getFromDatareader
		public static Impostazioni GetFromDatareader(DbProvider db)
		{
			Impostazioni ImpostazioniObj = new Impostazioni();
			ImpostazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ImpostazioniObj.Chiave = new SiarLibrary.NullTypes.StringNT(db.DataReader["CHIAVE"]);
			ImpostazioniObj.Istanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA"]);
			ImpostazioniObj.ValoreBool = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VALORE_BOOL"]);
			ImpostazioniObj.ValoreInt = new SiarLibrary.NullTypes.IntNT(db.DataReader["VALORE_INT"]);
			ImpostazioniObj.ValoreDecimal = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_DECIMAL"]);
			ImpostazioniObj.ValoreText = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE_TEXT"]);
			ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ImpostazioniObj.IsDirty = false;
			ImpostazioniObj.IsPersistent = true;
			return ImpostazioniObj;
		}

		//Find Select

		public static ImpostazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT ChiaveEqualThis, SiarLibrary.NullTypes.StringNT IstanzaEqualThis,
SiarLibrary.NullTypes.BoolNT ValoreBoolEqualThis, SiarLibrary.NullTypes.IntNT ValoreIntEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreDecimalEqualThis,
SiarLibrary.NullTypes.StringNT ValoreTextEqualThis)

		{

			ImpostazioniCollection ImpostazioniCollectionObj = new ImpostazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zimpostazionifindselect", new string[] {"Idequalthis", "Chiaveequalthis", "Istanzaequalthis",
"ValoreBoolequalthis", "ValoreIntequalthis", "ValoreDecimalequalthis",
"ValoreTextequalthis"}, new string[] {"int", "string", "string",
"bool", "int", "decimal",
"string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Chiaveequalthis", ChiaveEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istanzaequalthis", IstanzaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreBoolequalthis", ValoreBoolEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreIntequalthis", ValoreIntEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreDecimalequalthis", ValoreDecimalEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValoreTextequalthis", ValoreTextEqualThis);
			Impostazioni ImpostazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpostazioniObj = GetFromDatareader(db);
				ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpostazioniObj.IsDirty = false;
				ImpostazioniObj.IsPersistent = true;
				ImpostazioniCollectionObj.Add(ImpostazioniObj);
			}
			db.Close();
			return ImpostazioniCollectionObj;
		}

		//Find FindChiave

		public static ImpostazioniCollection FindChiave(DbProvider db, SiarLibrary.NullTypes.StringNT ChiaveEqualThis)

		{

			ImpostazioniCollection ImpostazioniCollectionObj = new ImpostazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zimpostazionifindfindchiave", new string[] { "Chiaveequalthis" }, new string[] { "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Chiaveequalthis", ChiaveEqualThis);
			Impostazioni ImpostazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpostazioniObj = GetFromDatareader(db);
				ImpostazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpostazioniObj.IsDirty = false;
				ImpostazioniObj.IsPersistent = true;
				ImpostazioniCollectionObj.Add(ImpostazioniObj);
			}
			db.Close();
			return ImpostazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ImpostazioniCollectionProvider:IImpostazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpostazioniCollectionProvider : IImpostazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Impostazioni
		protected ImpostazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ImpostazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ImpostazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public ImpostazioniCollectionProvider(StringNT ChiaveEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindChiave(ChiaveEqualThis);
		}

		//Costruttore3: ha in input impostazioniCollectionObj - non popola la collection
		public ImpostazioniCollectionProvider(ImpostazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ImpostazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ImpostazioniCollection(this);
		}

		//Get e Set
		public ImpostazioniCollection CollectionObj
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
		public int SaveCollection(ImpostazioniCollection collectionObj)
		{
			return ImpostazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Impostazioni impostazioniObj)
		{
			return ImpostazioniDAL.Save(_dbProviderObj, impostazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ImpostazioniCollection collectionObj)
		{
			return ImpostazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Impostazioni impostazioniObj)
		{
			return ImpostazioniDAL.Delete(_dbProviderObj, impostazioniObj);
		}

		//getById
		public Impostazioni GetById(IntNT IdValue)
		{
			Impostazioni ImpostazioniTemp = ImpostazioniDAL.GetById(_dbProviderObj, IdValue);
			if (ImpostazioniTemp != null) ImpostazioniTemp.Provider = this;
			return ImpostazioniTemp;
		}

		//Select: popola la collection
		public ImpostazioniCollection Select(IntNT IdEqualThis, StringNT ChiaveEqualThis, StringNT IstanzaEqualThis,
BoolNT ValoreboolEqualThis, IntNT ValoreintEqualThis, DecimalNT ValoredecimalEqualThis,
StringNT ValoretextEqualThis)
		{
			ImpostazioniCollection ImpostazioniCollectionTemp = ImpostazioniDAL.Select(_dbProviderObj, IdEqualThis, ChiaveEqualThis, IstanzaEqualThis,
ValoreboolEqualThis, ValoreintEqualThis, ValoredecimalEqualThis,
ValoretextEqualThis);
			ImpostazioniCollectionTemp.Provider = this;
			return ImpostazioniCollectionTemp;
		}

		//FindChiave: popola la collection
		public ImpostazioniCollection FindChiave(StringNT ChiaveEqualThis)
		{
			ImpostazioniCollection ImpostazioniCollectionTemp = ImpostazioniDAL.FindChiave(_dbProviderObj, ChiaveEqualThis);
			ImpostazioniCollectionTemp.Provider = this;
			return ImpostazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPOSTAZIONI>
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
    <FindChiave OrderBy="ORDER BY ">
      <CHIAVE>Equal</CHIAVE>
    </FindChiave>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPOSTAZIONI>
*/
