using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per LogTelegram
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILogTelegramProvider
	{
		int Save(LogTelegram LogTelegramObj);
		int SaveCollection(LogTelegramCollection collectionObj);
		int Delete(LogTelegram LogTelegramObj);
		int DeleteCollection(LogTelegramCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LogTelegram
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class LogTelegram : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLogTelegram;
		private NullTypes.StringNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserirmento;
		private NullTypes.StringNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _TokenBot;
		private NullTypes.StringNT _IdChat;
		private NullTypes.BoolNT _CanaleSigef;
		private NullTypes.StringNT _Esito;
		private NullTypes.StringNT _DettaglioEsito;
		private NullTypes.IntNT _IdMessage;
		private NullTypes.StringNT _TipoChiamata;
		private NullTypes.StringNT _Parametri;
		[NonSerialized] private ILogTelegramProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILogTelegramProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public LogTelegram()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_LOG_TELEGRAM
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLogTelegram
		{
			get { return _IdLogTelegram; }
			set
			{
				if (IdLogTelegram != value)
				{
					_IdLogTelegram = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set
			{
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIRMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserirmento
		{
			get { return _DataInserirmento; }
			set
			{
				if (DataInserirmento != value)
				{
					_DataInserirmento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set
			{
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set
			{
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOKEN_BOT
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TokenBot
		{
			get { return _TokenBot; }
			set
			{
				if (TokenBot != value)
				{
					_TokenBot = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHAT
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT IdChat
		{
			get { return _IdChat; }
			set
			{
				if (IdChat != value)
				{
					_IdChat = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CANALE_SIGEF
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CanaleSigef
		{
			get { return _CanaleSigef; }
			set
			{
				if (CanaleSigef != value)
				{
					_CanaleSigef = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Esito
		{
			get { return _Esito; }
			set
			{
				if (Esito != value)
				{
					_Esito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DETTAGLIO_ESITO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DettaglioEsito
		{
			get { return _DettaglioEsito; }
			set
			{
				if (DettaglioEsito != value)
				{
					_DettaglioEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_MESSAGE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdMessage
		{
			get { return _IdMessage; }
			set
			{
				if (IdMessage != value)
				{
					_IdMessage = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_CHIAMATA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TipoChiamata
		{
			get { return _TipoChiamata; }
			set
			{
				if (TipoChiamata != value)
				{
					_TipoChiamata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PARAMETRI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Parametri
		{
			get { return _Parametri; }
			set
			{
				if (Parametri != value)
				{
					_Parametri = value;
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
	/// Summary description for LogTelegramCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LogTelegramCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LogTelegramCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((LogTelegram)info.GetValue(i.ToString(), typeof(LogTelegram)));
			}
		}

		//Costruttore
		public LogTelegramCollection()
		{
			this.ItemType = typeof(LogTelegram);
		}

		//Costruttore con provider
		public LogTelegramCollection(ILogTelegramProvider providerObj)
		{
			this.ItemType = typeof(LogTelegram);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LogTelegram this[int index]
		{
			get { return (LogTelegram)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LogTelegramCollection GetChanges()
		{
			return (LogTelegramCollection)base.GetChanges();
		}

		[NonSerialized] private ILogTelegramProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ILogTelegramProvider Provider
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
		public int Add(LogTelegram LogTelegramObj)
		{
			if (LogTelegramObj.Provider == null) LogTelegramObj.Provider = this.Provider;
			return base.Add(LogTelegramObj);
		}

		//AddCollection
		public void AddCollection(LogTelegramCollection LogTelegramCollectionObj)
		{
			foreach (LogTelegram LogTelegramObj in LogTelegramCollectionObj)
				this.Add(LogTelegramObj);
		}

		//Insert
		public void Insert(int index, LogTelegram LogTelegramObj)
		{
			if (LogTelegramObj.Provider == null) LogTelegramObj.Provider = this.Provider;
			base.Insert(index, LogTelegramObj);
		}

		//CollectionGetById
		public LogTelegram CollectionGetById(NullTypes.IntNT IdLogTelegramValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdLogTelegram == IdLogTelegramValue))
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
		public LogTelegramCollection SubSelect(NullTypes.IntNT IdLogTelegramEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserirmentoEqualThis,
NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT TokenBotEqualThis,
NullTypes.StringNT IdChatEqualThis, NullTypes.BoolNT CanaleSigefEqualThis, NullTypes.StringNT EsitoEqualThis,
NullTypes.StringNT DettaglioEsitoEqualThis, NullTypes.IntNT IdMessageEqualThis, NullTypes.StringNT TipoChiamataEqualThis,
NullTypes.StringNT ParametriEqualThis)
		{
			LogTelegramCollection LogTelegramCollectionTemp = new LogTelegramCollection();
			foreach (LogTelegram LogTelegramItem in this)
			{
				if (((IdLogTelegramEqualThis == null) || ((LogTelegramItem.IdLogTelegram != null) && (LogTelegramItem.IdLogTelegram.Value == IdLogTelegramEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((LogTelegramItem.OperatoreInserimento != null) && (LogTelegramItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserirmentoEqualThis == null) || ((LogTelegramItem.DataInserirmento != null) && (LogTelegramItem.DataInserirmento.Value == DataInserirmentoEqualThis.Value))) &&
((OperatoreModificaEqualThis == null) || ((LogTelegramItem.OperatoreModifica != null) && (LogTelegramItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((LogTelegramItem.DataModifica != null) && (LogTelegramItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((TokenBotEqualThis == null) || ((LogTelegramItem.TokenBot != null) && (LogTelegramItem.TokenBot.Value == TokenBotEqualThis.Value))) &&
((IdChatEqualThis == null) || ((LogTelegramItem.IdChat != null) && (LogTelegramItem.IdChat.Value == IdChatEqualThis.Value))) && ((CanaleSigefEqualThis == null) || ((LogTelegramItem.CanaleSigef != null) && (LogTelegramItem.CanaleSigef.Value == CanaleSigefEqualThis.Value))) && ((EsitoEqualThis == null) || ((LogTelegramItem.Esito != null) && (LogTelegramItem.Esito.Value == EsitoEqualThis.Value))) &&
((DettaglioEsitoEqualThis == null) || ((LogTelegramItem.DettaglioEsito != null) && (LogTelegramItem.DettaglioEsito.Value == DettaglioEsitoEqualThis.Value))) && ((IdMessageEqualThis == null) || ((LogTelegramItem.IdMessage != null) && (LogTelegramItem.IdMessage.Value == IdMessageEqualThis.Value))) && ((TipoChiamataEqualThis == null) || ((LogTelegramItem.TipoChiamata != null) && (LogTelegramItem.TipoChiamata.Value == TipoChiamataEqualThis.Value))) &&
((ParametriEqualThis == null) || ((LogTelegramItem.Parametri != null) && (LogTelegramItem.Parametri.Value == ParametriEqualThis.Value))))
				{
					LogTelegramCollectionTemp.Add(LogTelegramItem);
				}
			}
			return LogTelegramCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LogTelegramDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class LogTelegramDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LogTelegram LogTelegramObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdLogTelegram", LogTelegramObj.IdLogTelegram);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", LogTelegramObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserirmento", LogTelegramObj.DataInserirmento);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", LogTelegramObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", LogTelegramObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "TokenBot", LogTelegramObj.TokenBot);
			DbProvider.SetCmdParam(cmd, firstChar + "IdChat", LogTelegramObj.IdChat);
			DbProvider.SetCmdParam(cmd, firstChar + "CanaleSigef", LogTelegramObj.CanaleSigef);
			DbProvider.SetCmdParam(cmd, firstChar + "Esito", LogTelegramObj.Esito);
			DbProvider.SetCmdParam(cmd, firstChar + "DettaglioEsito", LogTelegramObj.DettaglioEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "IdMessage", LogTelegramObj.IdMessage);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoChiamata", LogTelegramObj.TipoChiamata);
			DbProvider.SetCmdParam(cmd, firstChar + "Parametri", LogTelegramObj.Parametri);
		}
		//Insert
		private static int Insert(DbProvider db, LogTelegram LogTelegramObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZLogTelegramInsert", new string[] {"OperatoreInserimento", "DataInserirmento",
"OperatoreModifica", "DataModifica", "TokenBot",
"IdChat", "CanaleSigef", "Esito",
"DettaglioEsito", "IdMessage", "TipoChiamata",
"Parametri"}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "int", "string",
"string"}, "");
				CompileIUCmd(false, insertCmd, LogTelegramObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					LogTelegramObj.IdLogTelegram = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOG_TELEGRAM"]);
				}
				LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogTelegramObj.IsDirty = false;
				LogTelegramObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LogTelegram LogTelegramObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLogTelegramUpdate", new string[] {"IdLogTelegram", "OperatoreInserimento", "DataInserirmento",
"OperatoreModifica", "DataModifica", "TokenBot",
"IdChat", "CanaleSigef", "Esito",
"DettaglioEsito", "IdMessage", "TipoChiamata",
"Parametri"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "int", "string",
"string"}, "");
				CompileIUCmd(true, updateCmd, LogTelegramObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					LogTelegramObj.DataModifica = d;
				}
				LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogTelegramObj.IsDirty = false;
				LogTelegramObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LogTelegram LogTelegramObj)
		{
			switch (LogTelegramObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, LogTelegramObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, LogTelegramObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, LogTelegramObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LogTelegramCollection LogTelegramCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZLogTelegramUpdate", new string[] {"IdLogTelegram", "OperatoreInserimento", "DataInserirmento",
"OperatoreModifica", "DataModifica", "TokenBot",
"IdChat", "CanaleSigef", "Esito",
"DettaglioEsito", "IdMessage", "TipoChiamata",
"Parametri"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "int", "string",
"string"}, "");
				IDbCommand insertCmd = db.InitCmd("ZLogTelegramInsert", new string[] {"OperatoreInserimento", "DataInserirmento",
"OperatoreModifica", "DataModifica", "TokenBot",
"IdChat", "CanaleSigef", "Esito",
"DettaglioEsito", "IdMessage", "TipoChiamata",
"Parametri"}, new string[] {"string", "DateTime",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "int", "string",
"string"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZLogTelegramDelete", new string[] { "IdLogTelegram" }, new string[] { "int" }, "");
				for (int i = 0; i < LogTelegramCollectionObj.Count; i++)
				{
					switch (LogTelegramCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, LogTelegramCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LogTelegramCollectionObj[i].IdLogTelegram = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOG_TELEGRAM"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, LogTelegramCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									LogTelegramCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (LogTelegramCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLogTelegram", (SiarLibrary.NullTypes.IntNT)LogTelegramCollectionObj[i].IdLogTelegram);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LogTelegramCollectionObj.Count; i++)
				{
					if ((LogTelegramCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LogTelegramCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LogTelegramCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LogTelegramCollectionObj[i].IsDirty = false;
						LogTelegramCollectionObj[i].IsPersistent = true;
					}
					if ((LogTelegramCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LogTelegramCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LogTelegramCollectionObj[i].IsDirty = false;
						LogTelegramCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LogTelegram LogTelegramObj)
		{
			int returnValue = 0;
			if (LogTelegramObj.IsPersistent)
			{
				returnValue = Delete(db, LogTelegramObj.IdLogTelegram);
			}
			LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LogTelegramObj.IsDirty = false;
			LogTelegramObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLogTelegramValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLogTelegramDelete", new string[] { "IdLogTelegram" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLogTelegram", (SiarLibrary.NullTypes.IntNT)IdLogTelegramValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LogTelegramCollection LogTelegramCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZLogTelegramDelete", new string[] { "IdLogTelegram" }, new string[] { "int" }, "");
				for (int i = 0; i < LogTelegramCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLogTelegram", LogTelegramCollectionObj[i].IdLogTelegram);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LogTelegramCollectionObj.Count; i++)
				{
					if ((LogTelegramCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LogTelegramCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LogTelegramCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LogTelegramCollectionObj[i].IsDirty = false;
						LogTelegramCollectionObj[i].IsPersistent = false;
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
		public static LogTelegram GetById(DbProvider db, int IdLogTelegramValue)
		{
			LogTelegram LogTelegramObj = null;
			IDbCommand readCmd = db.InitCmd("ZLogTelegramGetById", new string[] { "IdLogTelegram" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdLogTelegram", (SiarLibrary.NullTypes.IntNT)IdLogTelegramValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LogTelegramObj = GetFromDatareader(db);
				LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogTelegramObj.IsDirty = false;
				LogTelegramObj.IsPersistent = true;
			}
			db.Close();
			return LogTelegramObj;
		}

		//getFromDatareader
		public static LogTelegram GetFromDatareader(DbProvider db)
		{
			LogTelegram LogTelegramObj = new LogTelegram();
			LogTelegramObj.IdLogTelegram = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOG_TELEGRAM"]);
			LogTelegramObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			LogTelegramObj.DataInserirmento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIRMENTO"]);
			LogTelegramObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
			LogTelegramObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			LogTelegramObj.TokenBot = new SiarLibrary.NullTypes.StringNT(db.DataReader["TOKEN_BOT"]);
			LogTelegramObj.IdChat = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_CHAT"]);
			LogTelegramObj.CanaleSigef = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CANALE_SIGEF"]);
			LogTelegramObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
			LogTelegramObj.DettaglioEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_ESITO"]);
			LogTelegramObj.IdMessage = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MESSAGE"]);
			LogTelegramObj.TipoChiamata = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_CHIAMATA"]);
			LogTelegramObj.Parametri = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARAMETRI"]);
			LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LogTelegramObj.IsDirty = false;
			LogTelegramObj.IsPersistent = true;
			return LogTelegramObj;
		}

		//Find Select

		public static LogTelegramCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLogTelegramEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserirmentoEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT TokenBotEqualThis,
SiarLibrary.NullTypes.StringNT IdChatEqualThis, SiarLibrary.NullTypes.BoolNT CanaleSigefEqualThis, SiarLibrary.NullTypes.StringNT EsitoEqualThis,
SiarLibrary.NullTypes.StringNT DettaglioEsitoEqualThis, SiarLibrary.NullTypes.IntNT IdMessageEqualThis, SiarLibrary.NullTypes.StringNT TipoChiamataEqualThis,
SiarLibrary.NullTypes.StringNT ParametriEqualThis)

		{

			LogTelegramCollection LogTelegramCollectionObj = new LogTelegramCollection();

			IDbCommand findCmd = db.InitCmd("Zlogtelegramfindselect", new string[] {"IdLogTelegramequalthis", "OperatoreInserimentoequalthis", "DataInserirmentoequalthis",
"OperatoreModificaequalthis", "DataModificaequalthis", "TokenBotequalthis",
"IdChatequalthis", "CanaleSigefequalthis", "Esitoequalthis",
"DettaglioEsitoequalthis", "IdMessageequalthis", "TipoChiamataequalthis",
"Parametriequalthis"}, new string[] {"int", "string", "DateTime",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "int", "string",
"string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLogTelegramequalthis", IdLogTelegramEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserirmentoequalthis", DataInserirmentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TokenBotequalthis", TokenBotEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChatequalthis", IdChatEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CanaleSigefequalthis", CanaleSigefEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DettaglioEsitoequalthis", DettaglioEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdMessageequalthis", IdMessageEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoChiamataequalthis", TipoChiamataEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Parametriequalthis", ParametriEqualThis);
			LogTelegram LogTelegramObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LogTelegramObj = GetFromDatareader(db);
				LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogTelegramObj.IsDirty = false;
				LogTelegramObj.IsPersistent = true;
				LogTelegramCollectionObj.Add(LogTelegramObj);
			}
			db.Close();
			return LogTelegramCollectionObj;
		}

		//Find Find

		public static LogTelegramCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLogTelegramEqualThis, SiarLibrary.NullTypes.StringNT TokenBotEqualThis, SiarLibrary.NullTypes.StringNT IdChatEqualThis,
SiarLibrary.NullTypes.BoolNT CanaleSigefEqualThis, SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.IntNT IdMessageEqualThis)

		{

			LogTelegramCollection LogTelegramCollectionObj = new LogTelegramCollection();

			IDbCommand findCmd = db.InitCmd("Zlogtelegramfindfind", new string[] {"IdLogTelegramequalthis", "TokenBotequalthis", "IdChatequalthis",
"CanaleSigefequalthis", "Esitoequalthis", "IdMessageequalthis"}, new string[] {"int", "string", "string",
"bool", "string", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLogTelegramequalthis", IdLogTelegramEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TokenBotequalthis", TokenBotEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChatequalthis", IdChatEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CanaleSigefequalthis", CanaleSigefEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdMessageequalthis", IdMessageEqualThis);
			LogTelegram LogTelegramObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LogTelegramObj = GetFromDatareader(db);
				LogTelegramObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LogTelegramObj.IsDirty = false;
				LogTelegramObj.IsPersistent = true;
				LogTelegramCollectionObj.Add(LogTelegramObj);
			}
			db.Close();
			return LogTelegramCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for LogTelegramCollectionProvider:ILogTelegramProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LogTelegramCollectionProvider : ILogTelegramProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LogTelegram
		protected LogTelegramCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LogTelegramCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LogTelegramCollection(this);
		}

		//Costruttore 2: popola la collection
		public LogTelegramCollectionProvider(IntNT IdlogtelegramEqualThis, StringNT TokenbotEqualThis, StringNT IdchatEqualThis,
BoolNT CanalesigefEqualThis, StringNT EsitoEqualThis, IntNT IdmessageEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlogtelegramEqualThis, TokenbotEqualThis, IdchatEqualThis,
CanalesigefEqualThis, EsitoEqualThis, IdmessageEqualThis);
		}

		//Costruttore3: ha in input logtelegramCollectionObj - non popola la collection
		public LogTelegramCollectionProvider(LogTelegramCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LogTelegramCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LogTelegramCollection(this);
		}

		//Get e Set
		public LogTelegramCollection CollectionObj
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
		public int SaveCollection(LogTelegramCollection collectionObj)
		{
			return LogTelegramDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LogTelegram logtelegramObj)
		{
			return LogTelegramDAL.Save(_dbProviderObj, logtelegramObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LogTelegramCollection collectionObj)
		{
			return LogTelegramDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LogTelegram logtelegramObj)
		{
			return LogTelegramDAL.Delete(_dbProviderObj, logtelegramObj);
		}

		//getById
		public LogTelegram GetById(IntNT IdLogTelegramValue)
		{
			LogTelegram LogTelegramTemp = LogTelegramDAL.GetById(_dbProviderObj, IdLogTelegramValue);
			if (LogTelegramTemp != null) LogTelegramTemp.Provider = this;
			return LogTelegramTemp;
		}

		//Select: popola la collection
		public LogTelegramCollection Select(IntNT IdlogtelegramEqualThis, StringNT OperatoreinserimentoEqualThis, DatetimeNT DatainserirmentoEqualThis,
StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, StringNT TokenbotEqualThis,
StringNT IdchatEqualThis, BoolNT CanalesigefEqualThis, StringNT EsitoEqualThis,
StringNT DettaglioesitoEqualThis, IntNT IdmessageEqualThis, StringNT TipochiamataEqualThis,
StringNT ParametriEqualThis)
		{
			LogTelegramCollection LogTelegramCollectionTemp = LogTelegramDAL.Select(_dbProviderObj, IdlogtelegramEqualThis, OperatoreinserimentoEqualThis, DatainserirmentoEqualThis,
OperatoremodificaEqualThis, DatamodificaEqualThis, TokenbotEqualThis,
IdchatEqualThis, CanalesigefEqualThis, EsitoEqualThis,
DettaglioesitoEqualThis, IdmessageEqualThis, TipochiamataEqualThis,
ParametriEqualThis);
			LogTelegramCollectionTemp.Provider = this;
			return LogTelegramCollectionTemp;
		}

		//Find: popola la collection
		public LogTelegramCollection Find(IntNT IdlogtelegramEqualThis, StringNT TokenbotEqualThis, StringNT IdchatEqualThis,
BoolNT CanalesigefEqualThis, StringNT EsitoEqualThis, IntNT IdmessageEqualThis)
		{
			LogTelegramCollection LogTelegramCollectionTemp = LogTelegramDAL.Find(_dbProviderObj, IdlogtelegramEqualThis, TokenbotEqualThis, IdchatEqualThis,
CanalesigefEqualThis, EsitoEqualThis, IdmessageEqualThis);
			LogTelegramCollectionTemp.Provider = this;
			return LogTelegramCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOG_TELEGRAM>
  <ViewName>VLOG_TELEGRAM</ViewName>
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
      <ID_LOG_TELEGRAM>Equal</ID_LOG_TELEGRAM>
      <TOKEN_BOT>Equal</TOKEN_BOT>
      <ID_CHAT>Equal</ID_CHAT>
      <CANALE_SIGEF>Equal</CANALE_SIGEF>
      <ESITO>Equal</ESITO>
      <ID_MESSAGE>Equal</ID_MESSAGE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOG_TELEGRAM>
*/
