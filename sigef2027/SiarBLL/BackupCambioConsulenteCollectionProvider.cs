using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BackupCambioConsulente
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBackupCambioConsulenteProvider
	{
		int Save(BackupCambioConsulente BackupCambioConsulenteObj);
		int SaveCollection(BackupCambioConsulenteCollection collectionObj);
		int Delete(BackupCambioConsulente BackupCambioConsulenteObj);
		int DeleteCollection(BackupCambioConsulenteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BackupCambioConsulente
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BackupCambioConsulente: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.DatetimeNT _DataCambioOperatore;
		private NullTypes.StringNT _CfUtenteOriginale;
		private NullTypes.StringNT _CfNuovoUtente;
		private NullTypes.DatetimeNT _DataUtenteStoricoOriginaleNuovoUtente;
		[NonSerialized] private IBackupCambioConsulenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBackupCambioConsulenteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BackupCambioConsulente()
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
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CAMBIO_OPERATORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCambioOperatore
		{
			get { return _DataCambioOperatore; }
			set {
				if (DataCambioOperatore != value)
				{
					_DataCambioOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_UTENTE_ORIGINALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtenteOriginale
		{
			get { return _CfUtenteOriginale; }
			set {
				if (CfUtenteOriginale != value)
				{
					_CfUtenteOriginale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_NUOVO_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfNuovoUtente
		{
			get { return _CfNuovoUtente; }
			set {
				if (CfNuovoUtente != value)
				{
					_CfNuovoUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_UTENTE_STORICO_ORIGINALE_NUOVO_UTENTE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataUtenteStoricoOriginaleNuovoUtente
		{
			get { return _DataUtenteStoricoOriginaleNuovoUtente; }
			set {
				if (DataUtenteStoricoOriginaleNuovoUtente != value)
				{
					_DataUtenteStoricoOriginaleNuovoUtente = value;
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
	/// Summary description for BackupCambioConsulenteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BackupCambioConsulenteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BackupCambioConsulenteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BackupCambioConsulente) info.GetValue(i.ToString(),typeof(BackupCambioConsulente)));
			}
		}

		//Costruttore
		public BackupCambioConsulenteCollection()
		{
			this.ItemType = typeof(BackupCambioConsulente);
		}

		//Costruttore con provider
		public BackupCambioConsulenteCollection(IBackupCambioConsulenteProvider providerObj)
		{
			this.ItemType = typeof(BackupCambioConsulente);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BackupCambioConsulente this[int index]
		{
			get { return (BackupCambioConsulente)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BackupCambioConsulenteCollection GetChanges()
		{
			return (BackupCambioConsulenteCollection) base.GetChanges();
		}

		[NonSerialized] private IBackupCambioConsulenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBackupCambioConsulenteProvider Provider
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
		public int Add(BackupCambioConsulente BackupCambioConsulenteObj)
		{
			if (BackupCambioConsulenteObj.Provider == null) BackupCambioConsulenteObj.Provider = this.Provider;
			return base.Add(BackupCambioConsulenteObj);
		}

		//AddCollection
		public void AddCollection(BackupCambioConsulenteCollection BackupCambioConsulenteCollectionObj)
		{
			foreach (BackupCambioConsulente BackupCambioConsulenteObj in BackupCambioConsulenteCollectionObj)
				this.Add(BackupCambioConsulenteObj);
		}

		//Insert
		public void Insert(int index, BackupCambioConsulente BackupCambioConsulenteObj)
		{
			if (BackupCambioConsulenteObj.Provider == null) BackupCambioConsulenteObj.Provider = this.Provider;
			base.Insert(index, BackupCambioConsulenteObj);
		}

		//CollectionGetById
		public BackupCambioConsulente CollectionGetById(NullTypes.IntNT IdValue)
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
		public BackupCambioConsulenteCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdVarianteEqualThis, NullTypes.DatetimeNT DataCambioOperatoreEqualThis, NullTypes.StringNT CfUtenteOriginaleEqualThis, 
NullTypes.StringNT CfNuovoUtenteEqualThis, NullTypes.DatetimeNT DataUtenteStoricoOriginaleNuovoUtenteEqualThis)
		{
			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionTemp = new BackupCambioConsulenteCollection();
			foreach (BackupCambioConsulente BackupCambioConsulenteItem in this)
			{
				if (((IdEqualThis == null) || ((BackupCambioConsulenteItem.Id != null) && (BackupCambioConsulenteItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((BackupCambioConsulenteItem.IdProgetto != null) && (BackupCambioConsulenteItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((BackupCambioConsulenteItem.IdDomandaPagamento != null) && (BackupCambioConsulenteItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdVarianteEqualThis == null) || ((BackupCambioConsulenteItem.IdVariante != null) && (BackupCambioConsulenteItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((DataCambioOperatoreEqualThis == null) || ((BackupCambioConsulenteItem.DataCambioOperatore != null) && (BackupCambioConsulenteItem.DataCambioOperatore.Value == DataCambioOperatoreEqualThis.Value))) && ((CfUtenteOriginaleEqualThis == null) || ((BackupCambioConsulenteItem.CfUtenteOriginale != null) && (BackupCambioConsulenteItem.CfUtenteOriginale.Value == CfUtenteOriginaleEqualThis.Value))) && 
((CfNuovoUtenteEqualThis == null) || ((BackupCambioConsulenteItem.CfNuovoUtente != null) && (BackupCambioConsulenteItem.CfNuovoUtente.Value == CfNuovoUtenteEqualThis.Value))) && ((DataUtenteStoricoOriginaleNuovoUtenteEqualThis == null) || ((BackupCambioConsulenteItem.DataUtenteStoricoOriginaleNuovoUtente != null) && (BackupCambioConsulenteItem.DataUtenteStoricoOriginaleNuovoUtente.Value == DataUtenteStoricoOriginaleNuovoUtenteEqualThis.Value))))
				{
					BackupCambioConsulenteCollectionTemp.Add(BackupCambioConsulenteItem);
				}
			}
			return BackupCambioConsulenteCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BackupCambioConsulenteCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdVarianteEqualThis, 
NullTypes.StringNT CfUtenteOriginaleEqualThis, NullTypes.StringNT CfNuovoUtenteEqualThis)
		{
			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionTemp = new BackupCambioConsulenteCollection();
			foreach (BackupCambioConsulente BackupCambioConsulenteItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((BackupCambioConsulenteItem.IdProgetto != null) && (BackupCambioConsulenteItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((BackupCambioConsulenteItem.IdDomandaPagamento != null) && (BackupCambioConsulenteItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((BackupCambioConsulenteItem.IdVariante != null) && (BackupCambioConsulenteItem.IdVariante.Value == IdVarianteEqualThis.Value))) && 
((CfUtenteOriginaleEqualThis == null) || ((BackupCambioConsulenteItem.CfUtenteOriginale != null) && (BackupCambioConsulenteItem.CfUtenteOriginale.Value == CfUtenteOriginaleEqualThis.Value))) && ((CfNuovoUtenteEqualThis == null) || ((BackupCambioConsulenteItem.CfNuovoUtente != null) && (BackupCambioConsulenteItem.CfNuovoUtente.Value == CfNuovoUtenteEqualThis.Value))))
				{
					BackupCambioConsulenteCollectionTemp.Add(BackupCambioConsulenteItem);
				}
			}
			return BackupCambioConsulenteCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BackupCambioConsulenteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BackupCambioConsulenteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BackupCambioConsulente BackupCambioConsulenteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BackupCambioConsulenteObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", BackupCambioConsulenteObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", BackupCambioConsulenteObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", BackupCambioConsulenteObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCambioOperatore", BackupCambioConsulenteObj.DataCambioOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "CfUtenteOriginale", BackupCambioConsulenteObj.CfUtenteOriginale);
			DbProvider.SetCmdParam(cmd,firstChar + "CfNuovoUtente", BackupCambioConsulenteObj.CfNuovoUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "DataUtenteStoricoOriginaleNuovoUtente", BackupCambioConsulenteObj.DataUtenteStoricoOriginaleNuovoUtente);
		}
		//Insert
		private static int Insert(DbProvider db, BackupCambioConsulente BackupCambioConsulenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBackupCambioConsulenteInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "DataCambioOperatore", "CfUtenteOriginale", 
"CfNuovoUtente", "DataUtenteStoricoOriginaleNuovoUtente"}, new string[] {"int", "int", 
"int", "DateTime", "string", 
"string", "DateTime"},"");
				CompileIUCmd(false, insertCmd,BackupCambioConsulenteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BackupCambioConsulenteObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BackupCambioConsulenteObj.IsDirty = false;
				BackupCambioConsulenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BackupCambioConsulente BackupCambioConsulenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBackupCambioConsulenteUpdate", new string[] {"Id", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "DataCambioOperatore", "CfUtenteOriginale", 
"CfNuovoUtente", "DataUtenteStoricoOriginaleNuovoUtente"}, new string[] {"int", "int", "int", 
"int", "DateTime", "string", 
"string", "DateTime"},"");
				CompileIUCmd(true, updateCmd,BackupCambioConsulenteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BackupCambioConsulenteObj.IsDirty = false;
				BackupCambioConsulenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BackupCambioConsulente BackupCambioConsulenteObj)
		{
			switch (BackupCambioConsulenteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BackupCambioConsulenteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BackupCambioConsulenteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BackupCambioConsulenteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BackupCambioConsulenteCollection BackupCambioConsulenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBackupCambioConsulenteUpdate", new string[] {"Id", "IdProgetto", "IdDomandaPagamento", 
"IdVariante", "DataCambioOperatore", "CfUtenteOriginale", 
"CfNuovoUtente", "DataUtenteStoricoOriginaleNuovoUtente"}, new string[] {"int", "int", "int", 
"int", "DateTime", "string", 
"string", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBackupCambioConsulenteInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdVariante", "DataCambioOperatore", "CfUtenteOriginale", 
"CfNuovoUtente", "DataUtenteStoricoOriginaleNuovoUtente"}, new string[] {"int", "int", 
"int", "DateTime", "string", 
"string", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBackupCambioConsulenteDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BackupCambioConsulenteCollectionObj.Count; i++)
				{
					switch (BackupCambioConsulenteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BackupCambioConsulenteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BackupCambioConsulenteCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BackupCambioConsulenteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BackupCambioConsulenteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BackupCambioConsulenteCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BackupCambioConsulenteCollectionObj.Count; i++)
				{
					if ((BackupCambioConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BackupCambioConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BackupCambioConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BackupCambioConsulenteCollectionObj[i].IsDirty = false;
						BackupCambioConsulenteCollectionObj[i].IsPersistent = true;
					}
					if ((BackupCambioConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BackupCambioConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BackupCambioConsulenteCollectionObj[i].IsDirty = false;
						BackupCambioConsulenteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BackupCambioConsulente BackupCambioConsulenteObj)
		{
			int returnValue = 0;
			if (BackupCambioConsulenteObj.IsPersistent) 
			{
				returnValue = Delete(db, BackupCambioConsulenteObj.Id);
			}
			BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BackupCambioConsulenteObj.IsDirty = false;
			BackupCambioConsulenteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBackupCambioConsulenteDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BackupCambioConsulenteCollection BackupCambioConsulenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBackupCambioConsulenteDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BackupCambioConsulenteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BackupCambioConsulenteCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BackupCambioConsulenteCollectionObj.Count; i++)
				{
					if ((BackupCambioConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BackupCambioConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BackupCambioConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BackupCambioConsulenteCollectionObj[i].IsDirty = false;
						BackupCambioConsulenteCollectionObj[i].IsPersistent = false;
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
		public static BackupCambioConsulente GetById(DbProvider db, int IdValue)
		{
			BackupCambioConsulente BackupCambioConsulenteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBackupCambioConsulenteGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BackupCambioConsulenteObj = GetFromDatareader(db);
				BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BackupCambioConsulenteObj.IsDirty = false;
				BackupCambioConsulenteObj.IsPersistent = true;
			}
			db.Close();
			return BackupCambioConsulenteObj;
		}

		//getFromDatareader
		public static BackupCambioConsulente GetFromDatareader(DbProvider db)
		{
			BackupCambioConsulente BackupCambioConsulenteObj = new BackupCambioConsulente();
			BackupCambioConsulenteObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BackupCambioConsulenteObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			BackupCambioConsulenteObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			BackupCambioConsulenteObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			BackupCambioConsulenteObj.DataCambioOperatore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CAMBIO_OPERATORE"]);
			BackupCambioConsulenteObj.CfUtenteOriginale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_ORIGINALE"]);
			BackupCambioConsulenteObj.CfNuovoUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_NUOVO_UTENTE"]);
			BackupCambioConsulenteObj.DataUtenteStoricoOriginaleNuovoUtente = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_UTENTE_STORICO_ORIGINALE_NUOVO_UTENTE"]);
			BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BackupCambioConsulenteObj.IsDirty = false;
			BackupCambioConsulenteObj.IsPersistent = true;
			return BackupCambioConsulenteObj;
		}

		//Find Select

		public static BackupCambioConsulenteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCambioOperatoreEqualThis, SiarLibrary.NullTypes.StringNT CfUtenteOriginaleEqualThis, 
SiarLibrary.NullTypes.StringNT CfNuovoUtenteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataUtenteStoricoOriginaleNuovoUtenteEqualThis)

		{

			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionObj = new BackupCambioConsulenteCollection();

			IDbCommand findCmd = db.InitCmd("Zbackupcambioconsulentefindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdVarianteequalthis", "DataCambioOperatoreequalthis", "CfUtenteOriginaleequalthis", 
"CfNuovoUtenteequalthis", "DataUtenteStoricoOriginaleNuovoUtenteequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "string", 
"string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCambioOperatoreequalthis", DataCambioOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteOriginaleequalthis", CfUtenteOriginaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfNuovoUtenteequalthis", CfNuovoUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataUtenteStoricoOriginaleNuovoUtenteequalthis", DataUtenteStoricoOriginaleNuovoUtenteEqualThis);
			BackupCambioConsulente BackupCambioConsulenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BackupCambioConsulenteObj = GetFromDatareader(db);
				BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BackupCambioConsulenteObj.IsDirty = false;
				BackupCambioConsulenteObj.IsPersistent = true;
				BackupCambioConsulenteCollectionObj.Add(BackupCambioConsulenteObj);
			}
			db.Close();
			return BackupCambioConsulenteCollectionObj;
		}

		//Find Find

		public static BackupCambioConsulenteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, 
SiarLibrary.NullTypes.StringNT CfUtenteOriginaleEqualThis, SiarLibrary.NullTypes.StringNT CfNuovoUtenteEqualThis)

		{

			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionObj = new BackupCambioConsulenteCollection();

			IDbCommand findCmd = db.InitCmd("Zbackupcambioconsulentefindfind", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdVarianteequalthis", 
"CfUtenteOriginaleequalthis", "CfNuovoUtenteequalthis"}, new string[] {"int", "int", "int", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfUtenteOriginaleequalthis", CfUtenteOriginaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfNuovoUtenteequalthis", CfNuovoUtenteEqualThis);
			BackupCambioConsulente BackupCambioConsulenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BackupCambioConsulenteObj = GetFromDatareader(db);
				BackupCambioConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BackupCambioConsulenteObj.IsDirty = false;
				BackupCambioConsulenteObj.IsPersistent = true;
				BackupCambioConsulenteCollectionObj.Add(BackupCambioConsulenteObj);
			}
			db.Close();
			return BackupCambioConsulenteCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BackupCambioConsulenteCollectionProvider:IBackupCambioConsulenteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BackupCambioConsulenteCollectionProvider : IBackupCambioConsulenteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BackupCambioConsulente
		protected BackupCambioConsulenteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BackupCambioConsulenteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BackupCambioConsulenteCollection(this);
		}

		//Costruttore 2: popola la collection
		public BackupCambioConsulenteCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis, 
StringNT CfutenteoriginaleEqualThis, StringNT CfnuovoutenteEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis, 
CfutenteoriginaleEqualThis, CfnuovoutenteEqualThis);
		}

		//Costruttore3: ha in input backupcambioconsulenteCollectionObj - non popola la collection
		public BackupCambioConsulenteCollectionProvider(BackupCambioConsulenteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BackupCambioConsulenteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BackupCambioConsulenteCollection(this);
		}

		//Get e Set
		public BackupCambioConsulenteCollection CollectionObj
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
		public int SaveCollection(BackupCambioConsulenteCollection collectionObj)
		{
			return BackupCambioConsulenteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BackupCambioConsulente backupcambioconsulenteObj)
		{
			return BackupCambioConsulenteDAL.Save(_dbProviderObj, backupcambioconsulenteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BackupCambioConsulenteCollection collectionObj)
		{
			return BackupCambioConsulenteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BackupCambioConsulente backupcambioconsulenteObj)
		{
			return BackupCambioConsulenteDAL.Delete(_dbProviderObj, backupcambioconsulenteObj);
		}

		//getById
		public BackupCambioConsulente GetById(IntNT IdValue)
		{
			BackupCambioConsulente BackupCambioConsulenteTemp = BackupCambioConsulenteDAL.GetById(_dbProviderObj, IdValue);
			if (BackupCambioConsulenteTemp!=null) BackupCambioConsulenteTemp.Provider = this;
			return BackupCambioConsulenteTemp;
		}

		//Select: popola la collection
		public BackupCambioConsulenteCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvarianteEqualThis, DatetimeNT DatacambiooperatoreEqualThis, StringNT CfutenteoriginaleEqualThis, 
StringNT CfnuovoutenteEqualThis, DatetimeNT DatautentestoricooriginalenuovoutenteEqualThis)
		{
			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionTemp = BackupCambioConsulenteDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdvarianteEqualThis, DatacambiooperatoreEqualThis, CfutenteoriginaleEqualThis, 
CfnuovoutenteEqualThis, DatautentestoricooriginalenuovoutenteEqualThis);
			BackupCambioConsulenteCollectionTemp.Provider = this;
			return BackupCambioConsulenteCollectionTemp;
		}

		//Find: popola la collection
		public BackupCambioConsulenteCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdvarianteEqualThis, 
StringNT CfutenteoriginaleEqualThis, StringNT CfnuovoutenteEqualThis)
		{
			BackupCambioConsulenteCollection BackupCambioConsulenteCollectionTemp = BackupCambioConsulenteDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdvarianteEqualThis, 
CfutenteoriginaleEqualThis, CfnuovoutenteEqualThis);
			BackupCambioConsulenteCollectionTemp.Provider = this;
			return BackupCambioConsulenteCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BACKUP_CAMBIO_CONSULENTE>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <CF_UTENTE_ORIGINALE>Equal</CF_UTENTE_ORIGINALE>
      <CF_NUOVO_UTENTE>Equal</CF_NUOVO_UTENTE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <CF_UTENTE_ORIGINALE>Equal</CF_UTENTE_ORIGINALE>
      <CF_NUOVO_UTENTE>Equal</CF_NUOVO_UTENTE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BACKUP_CAMBIO_CONSULENTE>
*/
