using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per LogAccessi
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILogAccessiProvider
	{
		int Save(LogAccessi LogAccessiObj);
		int SaveCollection(LogAccessiCollection collectionObj);
		int Delete(LogAccessi LogAccessiObj);
		int DeleteCollection(LogAccessiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LogAccessi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class LogAccessi : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _Istanza;
		private NullTypes.DatetimeNT _DataLogin;
		private NullTypes.DatetimeNT _DataLogout;
		private NullTypes.StringNT _TipoLogout;
		private NullTypes.StringNT _NominativoUtente;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _ProfiloUtente;
		private NullTypes.StringNT _ProfiloUtenteAccesso;
		[NonSerialized] private ILogAccessiProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILogAccessiProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public LogAccessi()
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
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set
			{
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set
			{
				if (IdProfilo != value)
				{
					_IdProfilo = value;
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
		/// Corrisponde al campo:DATA_LOGIN
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataLogin
		{
			get { return _DataLogin; }
			set
			{
				if (DataLogin != value)
				{
					_DataLogin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_LOGOUT
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataLogout
		{
			get { return _DataLogout; }
			set
			{
				if (DataLogout != value)
				{
					_DataLogout = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_LOGOUT
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TipoLogout
		{
			get { return _TipoLogout; }
			set
			{
				if (TipoLogout != value)
				{
					_TipoLogout = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_UTENTE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoUtente
		{
			get { return _NominativoUtente; }
			set
			{
				if (NominativoUtente != value)
				{
					_NominativoUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtente
		{
			get { return _CfUtente; }
			set
			{
				if (CfUtente != value)
				{
					_CfUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO_UTENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT ProfiloUtente
		{
			get { return _ProfiloUtente; }
			set
			{
				if (ProfiloUtente != value)
				{
					_ProfiloUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO_UTENTE_ACCESSO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT ProfiloUtenteAccesso
		{
			get { return _ProfiloUtenteAccesso; }
			set
			{
				if (ProfiloUtenteAccesso != value)
				{
					_ProfiloUtenteAccesso = value;
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
	/// Summary description for LogAccessiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LogAccessiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LogAccessiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((LogAccessi)info.GetValue(i.ToString(), typeof(LogAccessi)));
			}
		}

		//Costruttore
		public LogAccessiCollection()
		{
			this.ItemType = typeof(LogAccessi);
		}

		//Costruttore con provider
		public LogAccessiCollection(ILogAccessiProvider providerObj)
		{
			this.ItemType = typeof(LogAccessi);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LogAccessi this[int index]
		{
			get { return (LogAccessi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LogAccessiCollection GetChanges()
		{
			return (LogAccessiCollection)base.GetChanges();
		}

		[NonSerialized] private ILogAccessiProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILogAccessiProvider Provider
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
		public int Add(LogAccessi LogAccessiObj)
		{
			if (LogAccessiObj.Provider == null) LogAccessiObj.Provider = this.Provider;
			return base.Add(LogAccessiObj);
		}

		//AddCollection
		public void AddCollection(LogAccessiCollection LogAccessiCollectionObj)
		{
			foreach (LogAccessi LogAccessiObj in LogAccessiCollectionObj)
				this.Add(LogAccessiObj);
		}

		//Insert
		public void Insert(int index, LogAccessi LogAccessiObj)
		{
			if (LogAccessiObj.Provider == null) LogAccessiObj.Provider = this.Provider;
			base.Insert(index, LogAccessiObj);
		}

		//CollectionGetById
		public LogAccessi CollectionGetById(NullTypes.IntNT IdValue)
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
		public LogAccessiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.IntNT IdProfiloEqualThis,
NullTypes.StringNT IstanzaEqualThis, NullTypes.DatetimeNT DataLoginEqualThis, NullTypes.DatetimeNT DataLogoutEqualThis,
NullTypes.StringNT TipoLogoutEqualThis)
		{
			LogAccessiCollection LogAccessiCollectionTemp = new LogAccessiCollection();
			foreach (LogAccessi LogAccessiItem in this)
			{
				if (((IdEqualThis == null) || ((LogAccessiItem.Id != null) && (LogAccessiItem.Id.Value == IdEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((LogAccessiItem.IdUtente != null) && (LogAccessiItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((IdProfiloEqualThis == null) || ((LogAccessiItem.IdProfilo != null) && (LogAccessiItem.IdProfilo.Value == IdProfiloEqualThis.Value))) &&
((IstanzaEqualThis == null) || ((LogAccessiItem.Istanza != null) && (LogAccessiItem.Istanza.Value == IstanzaEqualThis.Value))) && ((DataLoginEqualThis == null) || ((LogAccessiItem.DataLogin != null) && (LogAccessiItem.DataLogin.Value == DataLoginEqualThis.Value))) && ((DataLogoutEqualThis == null) || ((LogAccessiItem.DataLogout != null) && (LogAccessiItem.DataLogout.Value == DataLogoutEqualThis.Value))) &&
((TipoLogoutEqualThis == null) || ((LogAccessiItem.TipoLogout != null) && (LogAccessiItem.TipoLogout.Value == TipoLogoutEqualThis.Value))))
				{
					LogAccessiCollectionTemp.Add(LogAccessiItem);
				}
			}
			return LogAccessiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LogAccessiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class LogAccessiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LogAccessi LogAccessiObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "Id", LogAccessiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdUtente", LogAccessiObj.IdUtente);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProfilo", LogAccessiObj.IdProfilo);
			DbProvider.SetCmdParam(cmd, firstChar + "Istanza", LogAccessiObj.Istanza);
			DbProvider.SetCmdParam(cmd, firstChar + "DataLogin", LogAccessiObj.DataLogin);
			DbProvider.SetCmdParam(cmd, firstChar + "DataLogout", LogAccessiObj.DataLogout);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoLogout", LogAccessiObj.TipoLogout);
		}
		//Insert
		private static int Insert(DbProvider db, LogAccessi LogAccessiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZLogAccessiInsert", new string[] {"IdUtente", "IdProfilo",
"Istanza", "DataLogin", "DataLogout",
"TipoLogout", }, new string[] {"int", "int",
"string", "DateTime", "DateTime",
"string", }, "");
				CompileIUCmd(false, insertCmd, LogAccessiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					LogAccessiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogAccessiObj.IsDirty = false;
				LogAccessiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LogAccessi LogAccessiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLogAccessiUpdate", new string[] {"Id", "IdUtente", "IdProfilo",
"Istanza", "DataLogin", "DataLogout",
"TipoLogout", }, new string[] {"int", "int", "int",
"string", "DateTime", "DateTime",
"string", }, "");
				CompileIUCmd(true, updateCmd, LogAccessiObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogAccessiObj.IsDirty = false;
				LogAccessiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LogAccessi LogAccessiObj)
		{
			switch (LogAccessiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, LogAccessiObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, LogAccessiObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, LogAccessiObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LogAccessiCollection LogAccessiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLogAccessiUpdate", new string[] {"Id", "IdUtente", "IdProfilo",
"Istanza", "DataLogin", "DataLogout",
"TipoLogout", }, new string[] {"int", "int", "int",
"string", "DateTime", "DateTime",
"string", }, "");
				IDbCommand insertCmd = db.InitCmd("ZLogAccessiInsert", new string[] {"IdUtente", "IdProfilo",
"Istanza", "DataLogin", "DataLogout",
"TipoLogout", }, new string[] {"int", "int",
"string", "DateTime", "DateTime",
"string", }, "");
				IDbCommand deleteCmd = db.InitCmd("ZLogAccessiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < LogAccessiCollectionObj.Count; i++)
				{
					switch (LogAccessiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, LogAccessiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LogAccessiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, LogAccessiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (LogAccessiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)LogAccessiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LogAccessiCollectionObj.Count; i++)
				{
					if ((LogAccessiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LogAccessiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LogAccessiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LogAccessiCollectionObj[i].IsDirty = false;
						LogAccessiCollectionObj[i].IsPersistent = true;
					}
					if ((LogAccessiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LogAccessiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LogAccessiCollectionObj[i].IsDirty = false;
						LogAccessiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LogAccessi LogAccessiObj)
		{
			int returnValue = 0;
			if (LogAccessiObj.IsPersistent)
			{
				returnValue = Delete(db, LogAccessiObj.Id);
			}
			LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LogAccessiObj.IsDirty = false;
			LogAccessiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLogAccessiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LogAccessiCollection LogAccessiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLogAccessiDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < LogAccessiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", LogAccessiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LogAccessiCollectionObj.Count; i++)
				{
					if ((LogAccessiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LogAccessiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LogAccessiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LogAccessiCollectionObj[i].IsDirty = false;
						LogAccessiCollectionObj[i].IsPersistent = false;
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
		public static LogAccessi GetById(DbProvider db, int IdValue)
		{
			LogAccessi LogAccessiObj = null;
			IDbCommand readCmd = db.InitCmd("ZLogAccessiGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LogAccessiObj = GetFromDatareader(db);
				LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogAccessiObj.IsDirty = false;
				LogAccessiObj.IsPersistent = true;
			}
			db.Close();
			return LogAccessiObj;
		}

		//getFromDatareader
		public static LogAccessi GetFromDatareader(DbProvider db)
		{
			LogAccessi LogAccessiObj = new LogAccessi();
			LogAccessiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			LogAccessiObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			LogAccessiObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			LogAccessiObj.Istanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA"]);
			LogAccessiObj.DataLogin = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_LOGIN"]);
			LogAccessiObj.DataLogout = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_LOGOUT"]);
			LogAccessiObj.TipoLogout = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_LOGOUT"]);
			LogAccessiObj.NominativoUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_UTENTE"]);
			LogAccessiObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			LogAccessiObj.ProfiloUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO_UTENTE"]);
			LogAccessiObj.ProfiloUtenteAccesso = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO_UTENTE_ACCESSO"]);
			LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LogAccessiObj.IsDirty = false;
			LogAccessiObj.IsPersistent = true;
			return LogAccessiObj;
		}

		//Find Select

		public static LogAccessiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis,
SiarLibrary.NullTypes.StringNT IstanzaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataLoginEqualThis, SiarLibrary.NullTypes.DatetimeNT DataLogoutEqualThis,
SiarLibrary.NullTypes.StringNT TipoLogoutEqualThis)

		{

			LogAccessiCollection LogAccessiCollectionObj = new LogAccessiCollection();

			IDbCommand findCmd = db.InitCmd("Zlogaccessifindselect", new string[] {"Idequalthis", "IdUtenteequalthis", "IdProfiloequalthis",
"Istanzaequalthis", "DataLoginequalthis", "DataLogoutequalthis",
"TipoLogoutequalthis"}, new string[] {"int", "int", "int",
"string", "DateTime", "DateTime",
"string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istanzaequalthis", IstanzaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataLoginequalthis", DataLoginEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataLogoutequalthis", DataLogoutEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoLogoutequalthis", TipoLogoutEqualThis);
			LogAccessi LogAccessiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LogAccessiObj = GetFromDatareader(db);
				LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogAccessiObj.IsDirty = false;
				LogAccessiObj.IsPersistent = true;
				LogAccessiCollectionObj.Add(LogAccessiObj);
			}
			db.Close();
			return LogAccessiCollectionObj;
		}

		//Find Find

		public static LogAccessiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataLoginEqualThis, SiarLibrary.NullTypes.DatetimeNT DataLogoutEqualThis)

		{

			LogAccessiCollection LogAccessiCollectionObj = new LogAccessiCollection();

			IDbCommand findCmd = db.InitCmd("Zlogaccessifindfind", new string[] { "IdUtenteequalthis", "DataLoginequalthis", "DataLogoutequalthis" }, new string[] { "int", "DateTime", "DateTime" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataLoginequalthis", DataLoginEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataLogoutequalthis", DataLogoutEqualThis);
			LogAccessi LogAccessiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LogAccessiObj = GetFromDatareader(db);
				LogAccessiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogAccessiObj.IsDirty = false;
				LogAccessiObj.IsPersistent = true;
				LogAccessiCollectionObj.Add(LogAccessiObj);
			}
			db.Close();
			return LogAccessiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for LogAccessiCollectionProvider:ILogAccessiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LogAccessiCollectionProvider : ILogAccessiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LogAccessi
		protected LogAccessiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LogAccessiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LogAccessiCollection(this);
		}

		//Costruttore 2: popola la collection
		public LogAccessiCollectionProvider(IntNT IdutenteEqualThis, DatetimeNT DataloginEqualThis, DatetimeNT DatalogoutEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdutenteEqualThis, DataloginEqualThis, DatalogoutEqualThis);
		}

		//Costruttore3: ha in input logaccessiCollectionObj - non popola la collection
		public LogAccessiCollectionProvider(LogAccessiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LogAccessiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LogAccessiCollection(this);
		}

		//Get e Set
		public LogAccessiCollection CollectionObj
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
		public int SaveCollection(LogAccessiCollection collectionObj)
		{
			return LogAccessiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LogAccessi logaccessiObj)
		{
			return LogAccessiDAL.Save(_dbProviderObj, logaccessiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LogAccessiCollection collectionObj)
		{
			return LogAccessiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LogAccessi logaccessiObj)
		{
			return LogAccessiDAL.Delete(_dbProviderObj, logaccessiObj);
		}

		//getById
		public LogAccessi GetById(IntNT IdValue)
		{
			LogAccessi LogAccessiTemp = LogAccessiDAL.GetById(_dbProviderObj, IdValue);
			if (LogAccessiTemp != null) LogAccessiTemp.Provider = this;
			return LogAccessiTemp;
		}

		//Select: popola la collection
		public LogAccessiCollection Select(IntNT IdEqualThis, IntNT IdutenteEqualThis, IntNT IdprofiloEqualThis,
StringNT IstanzaEqualThis, DatetimeNT DataloginEqualThis, DatetimeNT DatalogoutEqualThis,
StringNT TipologoutEqualThis)
		{
			LogAccessiCollection LogAccessiCollectionTemp = LogAccessiDAL.Select(_dbProviderObj, IdEqualThis, IdutenteEqualThis, IdprofiloEqualThis,
IstanzaEqualThis, DataloginEqualThis, DatalogoutEqualThis,
TipologoutEqualThis);
			LogAccessiCollectionTemp.Provider = this;
			return LogAccessiCollectionTemp;
		}

		//Find: popola la collection
		public LogAccessiCollection Find(IntNT IdutenteEqualThis, DatetimeNT DataloginEqualThis, DatetimeNT DatalogoutEqualThis)
		{
			LogAccessiCollection LogAccessiCollectionTemp = LogAccessiDAL.Find(_dbProviderObj, IdutenteEqualThis, DataloginEqualThis, DatalogoutEqualThis);
			LogAccessiCollectionTemp.Provider = this;
			return LogAccessiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOG_ACCESSI>
  <ViewName>VLOG_ACCESSI</ViewName>
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
      <ID_UTENTE>Equal</ID_UTENTE>
      <DATA_LOGIN>Equal</DATA_LOGIN>
      <DATA_LOGOUT>Equal</DATA_LOGOUT>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOG_ACCESSI>
*/
