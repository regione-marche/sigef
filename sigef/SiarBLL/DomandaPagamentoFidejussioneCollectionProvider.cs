using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DomandaPagamentoFidejussione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaPagamentoFidejussioneProvider
	{
		int Save(DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj);
		int SaveCollection(DomandaPagamentoFidejussioneCollection collectionObj);
		int Delete(DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj);
		int DeleteCollection(DomandaPagamentoFidejussioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaPagamentoFidejussione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DomandaPagamentoFidejussione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamentoFidejussione;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _OperatoreIstruttore;
		private NullTypes.DatetimeNT _DataModificaIstruttore;
		[NonSerialized] private IDomandaPagamentoFidejussioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoFidejussioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DomandaPagamentoFidejussione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamentoFidejussione
		{
			get { return _IdDomandaPagamentoFidejussione; }
			set {
				if (IdDomandaPagamentoFidejussione != value)
				{
					_IdDomandaPagamentoFidejussione = value;
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
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CREAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreCreazione
		{
			get { return _OperatoreCreazione; }
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
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
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_ISTRUTTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreIstruttore
		{
			get { return _OperatoreIstruttore; }
			set {
				if (OperatoreIstruttore != value)
				{
					_OperatoreIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA_ISTRUTTORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModificaIstruttore
		{
			get { return _DataModificaIstruttore; }
			set {
				if (DataModificaIstruttore != value)
				{
					_DataModificaIstruttore = value;
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
	/// Summary description for DomandaPagamentoFidejussioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoFidejussioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DomandaPagamentoFidejussioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DomandaPagamentoFidejussione) info.GetValue(i.ToString(),typeof(DomandaPagamentoFidejussione)));
			}
		}

		//Costruttore
		public DomandaPagamentoFidejussioneCollection()
		{
			this.ItemType = typeof(DomandaPagamentoFidejussione);
		}

		//Costruttore con provider
		public DomandaPagamentoFidejussioneCollection(IDomandaPagamentoFidejussioneProvider providerObj)
		{
			this.ItemType = typeof(DomandaPagamentoFidejussione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaPagamentoFidejussione this[int index]
		{
			get { return (DomandaPagamentoFidejussione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaPagamentoFidejussioneCollection GetChanges()
		{
			return (DomandaPagamentoFidejussioneCollection) base.GetChanges();
		}

		[NonSerialized] private IDomandaPagamentoFidejussioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoFidejussioneProvider Provider
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
		public int Add(DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			if (DomandaPagamentoFidejussioneObj.Provider == null) DomandaPagamentoFidejussioneObj.Provider = this.Provider;
			return base.Add(DomandaPagamentoFidejussioneObj);
		}

		//AddCollection
		public void AddCollection(DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionObj)
		{
			foreach (DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj in DomandaPagamentoFidejussioneCollectionObj)
				this.Add(DomandaPagamentoFidejussioneObj);
		}

		//Insert
		public void Insert(int index, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			if (DomandaPagamentoFidejussioneObj.Provider == null) DomandaPagamentoFidejussioneObj.Provider = this.Provider;
			base.Insert(index, DomandaPagamentoFidejussioneObj);
		}

		//CollectionGetById
		public DomandaPagamentoFidejussione CollectionGetById(NullTypes.IntNT IdDomandaPagamentoFidejussioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamentoFidejussione == IdDomandaPagamentoFidejussioneValue))
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
		public DomandaPagamentoFidejussioneCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoFidejussioneEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT OperatoreIstruttoreEqualThis, NullTypes.DatetimeNT DataModificaIstruttoreEqualThis)
		{
			DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionTemp = new DomandaPagamentoFidejussioneCollection();
			foreach (DomandaPagamentoFidejussione DomandaPagamentoFidejussioneItem in this)
			{
				if (((IdDomandaPagamentoFidejussioneEqualThis == null) || ((DomandaPagamentoFidejussioneItem.IdDomandaPagamentoFidejussione != null) && (DomandaPagamentoFidejussioneItem.IdDomandaPagamentoFidejussione.Value == IdDomandaPagamentoFidejussioneEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoFidejussioneItem.IdDomandaPagamento != null) && (DomandaPagamentoFidejussioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DomandaPagamentoFidejussioneItem.IdProgetto != null) && (DomandaPagamentoFidejussioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((DomandaPagamentoFidejussioneItem.DataCreazione != null) && (DomandaPagamentoFidejussioneItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((DomandaPagamentoFidejussioneItem.OperatoreCreazione != null) && (DomandaPagamentoFidejussioneItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataModificaEqualThis == null) || ((DomandaPagamentoFidejussioneItem.DataModifica != null) && (DomandaPagamentoFidejussioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((OperatoreIstruttoreEqualThis == null) || ((DomandaPagamentoFidejussioneItem.OperatoreIstruttore != null) && (DomandaPagamentoFidejussioneItem.OperatoreIstruttore.Value == OperatoreIstruttoreEqualThis.Value))) && ((DataModificaIstruttoreEqualThis == null) || ((DomandaPagamentoFidejussioneItem.DataModificaIstruttore != null) && (DomandaPagamentoFidejussioneItem.DataModificaIstruttore.Value == DataModificaIstruttoreEqualThis.Value))))
				{
					DomandaPagamentoFidejussioneCollectionTemp.Add(DomandaPagamentoFidejussioneItem);
				}
			}
			return DomandaPagamentoFidejussioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DomandaPagamentoFidejussioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DomandaPagamentoFidejussioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamentoFidejussione", DomandaPagamentoFidejussioneObj.IdDomandaPagamentoFidejussione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DomandaPagamentoFidejussioneObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", DomandaPagamentoFidejussioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", DomandaPagamentoFidejussioneObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", DomandaPagamentoFidejussioneObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", DomandaPagamentoFidejussioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreIstruttore", DomandaPagamentoFidejussioneObj.OperatoreIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModificaIstruttore", DomandaPagamentoFidejussioneObj.DataModificaIstruttore);
		}
		//Insert
		private static int Insert(DbProvider db, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreIstruttore", "DataModificaIstruttore"}, new string[] {"int", "int", 
"DateTime", "int", "DateTime", 
"int", "DateTime"},"");
				CompileIUCmd(false, insertCmd,DomandaPagamentoFidejussioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneObj.IdDomandaPagamentoFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE"]);
				}
				DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneObj.IsDirty = false;
				DomandaPagamentoFidejussioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneUpdate", new string[] {"IdDomandaPagamentoFidejussione", "IdDomandaPagamento", "IdProgetto", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreIstruttore", "DataModificaIstruttore"}, new string[] {"int", "int", "int", 
"DateTime", "int", "DateTime", 
"int", "DateTime"},"");
				CompileIUCmd(true, updateCmd,DomandaPagamentoFidejussioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					DomandaPagamentoFidejussioneObj.DataModifica = d;
				}
				DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneObj.IsDirty = false;
				DomandaPagamentoFidejussioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			switch (DomandaPagamentoFidejussioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DomandaPagamentoFidejussioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DomandaPagamentoFidejussioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DomandaPagamentoFidejussioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneUpdate", new string[] {"IdDomandaPagamentoFidejussione", "IdDomandaPagamento", "IdProgetto", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreIstruttore", "DataModificaIstruttore"}, new string[] {"int", "int", "int", 
"DateTime", "int", "DateTime", 
"int", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreIstruttore", "DataModificaIstruttore"}, new string[] {"int", "int", 
"DateTime", "int", "DateTime", 
"int", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneDelete", new string[] {"IdDomandaPagamentoFidejussione"}, new string[] {"int"},"");
				for (int i = 0; i < DomandaPagamentoFidejussioneCollectionObj.Count; i++)
				{
					switch (DomandaPagamentoFidejussioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DomandaPagamentoFidejussioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DomandaPagamentoFidejussioneCollectionObj[i].IdDomandaPagamentoFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DomandaPagamentoFidejussioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									DomandaPagamentoFidejussioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DomandaPagamentoFidejussioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoFidejussione", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoFidejussioneCollectionObj[i].IdDomandaPagamentoFidejussione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoFidejussioneCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoFidejussioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoFidejussioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoFidejussioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DomandaPagamentoFidejussioneCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneCollectionObj[i].IsPersistent = true;
					}
					if ((DomandaPagamentoFidejussioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DomandaPagamentoFidejussioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoFidejussioneCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj)
		{
			int returnValue = 0;
			if (DomandaPagamentoFidejussioneObj.IsPersistent) 
			{
				returnValue = Delete(db, DomandaPagamentoFidejussioneObj.IdDomandaPagamentoFidejussione);
			}
			DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DomandaPagamentoFidejussioneObj.IsDirty = false;
			DomandaPagamentoFidejussioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoFidejussioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneDelete", new string[] {"IdDomandaPagamentoFidejussione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoFidejussione", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoFidejussioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneDelete", new string[] {"IdDomandaPagamentoFidejussione"}, new string[] {"int"},"");
				for (int i = 0; i < DomandaPagamentoFidejussioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamentoFidejussione", DomandaPagamentoFidejussioneCollectionObj[i].IdDomandaPagamentoFidejussione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DomandaPagamentoFidejussioneCollectionObj.Count; i++)
				{
					if ((DomandaPagamentoFidejussioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoFidejussioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DomandaPagamentoFidejussioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DomandaPagamentoFidejussioneCollectionObj[i].IsDirty = false;
						DomandaPagamentoFidejussioneCollectionObj[i].IsPersistent = false;
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
		public static DomandaPagamentoFidejussione GetById(DbProvider db, int IdDomandaPagamentoFidejussioneValue)
		{
			DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDomandaPagamentoFidejussioneGetById", new string[] {"IdDomandaPagamentoFidejussione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamentoFidejussione", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoFidejussioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneObj.IsDirty = false;
				DomandaPagamentoFidejussioneObj.IsPersistent = true;
			}
			db.Close();
			return DomandaPagamentoFidejussioneObj;
		}

		//getFromDatareader
		public static DomandaPagamentoFidejussione GetFromDatareader(DbProvider db)
		{
			DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj = new DomandaPagamentoFidejussione();
			DomandaPagamentoFidejussioneObj.IdDomandaPagamentoFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO_FIDEJUSSIONE"]);
			DomandaPagamentoFidejussioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DomandaPagamentoFidejussioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DomandaPagamentoFidejussioneObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			DomandaPagamentoFidejussioneObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			DomandaPagamentoFidejussioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			DomandaPagamentoFidejussioneObj.OperatoreIstruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_ISTRUTTORE"]);
			DomandaPagamentoFidejussioneObj.DataModificaIstruttore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA_ISTRUTTORE"]);
			DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DomandaPagamentoFidejussioneObj.IsDirty = false;
			DomandaPagamentoFidejussioneObj.IsPersistent = true;
			return DomandaPagamentoFidejussioneObj;
		}

		//Find Select

		public static DomandaPagamentoFidejussioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoFidejussioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaIstruttoreEqualThis)

		{

			DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionObj = new DomandaPagamentoFidejussioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentofidejussionefindselect", new string[] {"IdDomandaPagamentoFidejussioneequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis", 
"DataCreazioneequalthis", "OperatoreCreazioneequalthis", "DataModificaequalthis", 
"OperatoreIstruttoreequalthis", "DataModificaIstruttoreequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "int", "DateTime", 
"int", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoFidejussioneequalthis", IdDomandaPagamentoFidejussioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreIstruttoreequalthis", OperatoreIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaIstruttoreequalthis", DataModificaIstruttoreEqualThis);
			DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneObj.IsDirty = false;
				DomandaPagamentoFidejussioneObj.IsPersistent = true;
				DomandaPagamentoFidejussioneCollectionObj.Add(DomandaPagamentoFidejussioneObj);
			}
			db.Close();
			return DomandaPagamentoFidejussioneCollectionObj;
		}

		//Find Find

		public static DomandaPagamentoFidejussioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionObj = new DomandaPagamentoFidejussioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdomandapagamentofidejussionefindfind", new string[] {"IdDomandaPagamentoequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DomandaPagamentoFidejussione DomandaPagamentoFidejussioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DomandaPagamentoFidejussioneObj = GetFromDatareader(db);
				DomandaPagamentoFidejussioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DomandaPagamentoFidejussioneObj.IsDirty = false;
				DomandaPagamentoFidejussioneObj.IsPersistent = true;
				DomandaPagamentoFidejussioneCollectionObj.Add(DomandaPagamentoFidejussioneObj);
			}
			db.Close();
			return DomandaPagamentoFidejussioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaPagamentoFidejussioneCollectionProvider:IDomandaPagamentoFidejussioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DomandaPagamentoFidejussioneCollectionProvider : IDomandaPagamentoFidejussioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaPagamentoFidejussione
		protected DomandaPagamentoFidejussioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaPagamentoFidejussioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaPagamentoFidejussioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public DomandaPagamentoFidejussioneCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, IdprogettoEqualThis);
		}

		//Costruttore3: ha in input domandapagamentofidejussioneCollectionObj - non popola la collection
		public DomandaPagamentoFidejussioneCollectionProvider(DomandaPagamentoFidejussioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaPagamentoFidejussioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaPagamentoFidejussioneCollection(this);
		}

		//Get e Set
		public DomandaPagamentoFidejussioneCollection CollectionObj
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
		public int SaveCollection(DomandaPagamentoFidejussioneCollection collectionObj)
		{
			return DomandaPagamentoFidejussioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaPagamentoFidejussione domandapagamentofidejussioneObj)
		{
			return DomandaPagamentoFidejussioneDAL.Save(_dbProviderObj, domandapagamentofidejussioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaPagamentoFidejussioneCollection collectionObj)
		{
			return DomandaPagamentoFidejussioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaPagamentoFidejussione domandapagamentofidejussioneObj)
		{
			return DomandaPagamentoFidejussioneDAL.Delete(_dbProviderObj, domandapagamentofidejussioneObj);
		}

		//getById
		public DomandaPagamentoFidejussione GetById(IntNT IdDomandaPagamentoFidejussioneValue)
		{
			DomandaPagamentoFidejussione DomandaPagamentoFidejussioneTemp = DomandaPagamentoFidejussioneDAL.GetById(_dbProviderObj, IdDomandaPagamentoFidejussioneValue);
			if (DomandaPagamentoFidejussioneTemp!=null) DomandaPagamentoFidejussioneTemp.Provider = this;
			return DomandaPagamentoFidejussioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DomandaPagamentoFidejussioneCollection Select(IntNT IddomandapagamentofidejussioneEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, 
DatetimeNT DatacreazioneEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT OperatoreistruttoreEqualThis, DatetimeNT DatamodificaistruttoreEqualThis)
		{
			DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionTemp = DomandaPagamentoFidejussioneDAL.Select(_dbProviderObj, IddomandapagamentofidejussioneEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis, 
DatacreazioneEqualThis, OperatorecreazioneEqualThis, DatamodificaEqualThis, 
OperatoreistruttoreEqualThis, DatamodificaistruttoreEqualThis);
			DomandaPagamentoFidejussioneCollectionTemp.Provider = this;
			return DomandaPagamentoFidejussioneCollectionTemp;
		}

		//Find: popola la collection
		public DomandaPagamentoFidejussioneCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
		{
			DomandaPagamentoFidejussioneCollection DomandaPagamentoFidejussioneCollectionTemp = DomandaPagamentoFidejussioneDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis);
			DomandaPagamentoFidejussioneCollectionTemp.Provider = this;
			return DomandaPagamentoFidejussioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_FIDEJUSSIONE>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_FIDEJUSSIONE>
*/
