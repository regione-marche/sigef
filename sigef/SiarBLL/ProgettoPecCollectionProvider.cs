using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoPec
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoPecProvider
	{
		int Save(ProgettoPec ProgettoPecObj);
		int SaveCollection(ProgettoPecCollection collectionObj);
		int Delete(ProgettoPec ProgettoPecObj);
		int DeleteCollection(ProgettoPecCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoPec
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoPec: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgettoPec;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Pec;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _OperatoreModifica;
		[NonSerialized] private IProgettoPecProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoPecProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoPec()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_PEC
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoPec
		{
			get { return _IdProgettoPec; }
			set {
				if (IdProgettoPec != value)
				{
					_IdProgettoPec = value;
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
		/// Corrisponde al campo:PEC
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Pec
		{
			get { return _Pec; }
			set {
				if (Pec != value)
				{
					_Pec = value;
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
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
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
	/// Summary description for ProgettoPecCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoPecCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoPecCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoPec) info.GetValue(i.ToString(),typeof(ProgettoPec)));
			}
		}

		//Costruttore
		public ProgettoPecCollection()
		{
			this.ItemType = typeof(ProgettoPec);
		}

		//Costruttore con provider
		public ProgettoPecCollection(IProgettoPecProvider providerObj)
		{
			this.ItemType = typeof(ProgettoPec);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoPec this[int index]
		{
			get { return (ProgettoPec)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoPecCollection GetChanges()
		{
			return (ProgettoPecCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoPecProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoPecProvider Provider
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
		public int Add(ProgettoPec ProgettoPecObj)
		{
			if (ProgettoPecObj.Provider == null) ProgettoPecObj.Provider = this.Provider;
			return base.Add(ProgettoPecObj);
		}

		//AddCollection
		public void AddCollection(ProgettoPecCollection ProgettoPecCollectionObj)
		{
			foreach (ProgettoPec ProgettoPecObj in ProgettoPecCollectionObj)
				this.Add(ProgettoPecObj);
		}

		//Insert
		public void Insert(int index, ProgettoPec ProgettoPecObj)
		{
			if (ProgettoPecObj.Provider == null) ProgettoPecObj.Provider = this.Provider;
			base.Insert(index, ProgettoPecObj);
		}

		//CollectionGetById
		public ProgettoPec CollectionGetById(NullTypes.IntNT IdProgettoPecValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgettoPec == IdProgettoPecValue))
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
		public ProgettoPecCollection SubSelect(NullTypes.IntNT IdProgettoPecEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT PecEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT OperatoreModificaEqualThis)
		{
			ProgettoPecCollection ProgettoPecCollectionTemp = new ProgettoPecCollection();
			foreach (ProgettoPec ProgettoPecItem in this)
			{
				if (((IdProgettoPecEqualThis == null) || ((ProgettoPecItem.IdProgettoPec != null) && (ProgettoPecItem.IdProgettoPec.Value == IdProgettoPecEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoPecItem.IdProgetto != null) && (ProgettoPecItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((PecEqualThis == null) || ((ProgettoPecItem.Pec != null) && (ProgettoPecItem.Pec.Value == PecEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((ProgettoPecItem.DataCreazione != null) && (ProgettoPecItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((ProgettoPecItem.OperatoreCreazione != null) && (ProgettoPecItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ProgettoPecItem.DataModifica != null) && (ProgettoPecItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((OperatoreModificaEqualThis == null) || ((ProgettoPecItem.OperatoreModifica != null) && (ProgettoPecItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))))
				{
					ProgettoPecCollectionTemp.Add(ProgettoPecItem);
				}
			}
			return ProgettoPecCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoPecDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoPecDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoPec ProgettoPecObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoPec", ProgettoPecObj.IdProgettoPec);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoPecObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Pec", ProgettoPecObj.Pec);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ProgettoPecObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", ProgettoPecObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ProgettoPecObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", ProgettoPecObj.OperatoreModifica);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoPec ProgettoPecObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoPecInsert", new string[] {"IdProgetto", "Pec", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreModifica"}, new string[] {"int", "string", 
"DateTime", "int", "DateTime", 
"int"},"");
				CompileIUCmd(false, insertCmd,ProgettoPecObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoPecObj.IdProgettoPec = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_PEC"]);
				}
				ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoPecObj.IsDirty = false;
				ProgettoPecObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoPec ProgettoPecObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoPecUpdate", new string[] {"IdProgettoPec", "IdProgetto", "Pec", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreModifica"}, new string[] {"int", "int", "string", 
"DateTime", "int", "DateTime", 
"int"},"");
				CompileIUCmd(true, updateCmd,ProgettoPecObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoPecObj.IsDirty = false;
				ProgettoPecObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoPec ProgettoPecObj)
		{
			switch (ProgettoPecObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoPecObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoPecObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoPecObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoPecCollection ProgettoPecCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoPecUpdate", new string[] {"IdProgettoPec", "IdProgetto", "Pec", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreModifica"}, new string[] {"int", "int", "string", 
"DateTime", "int", "DateTime", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoPecInsert", new string[] {"IdProgetto", "Pec", 
"DataCreazione", "OperatoreCreazione", "DataModifica", 
"OperatoreModifica"}, new string[] {"int", "string", 
"DateTime", "int", "DateTime", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoPecDelete", new string[] {"IdProgettoPec"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoPecCollectionObj.Count; i++)
				{
					switch (ProgettoPecCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoPecCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoPecCollectionObj[i].IdProgettoPec = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_PEC"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoPecCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoPecCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoPec", (SiarLibrary.NullTypes.IntNT)ProgettoPecCollectionObj[i].IdProgettoPec);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoPecCollectionObj.Count; i++)
				{
					if ((ProgettoPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoPecCollectionObj[i].IsDirty = false;
						ProgettoPecCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoPecCollectionObj[i].IsDirty = false;
						ProgettoPecCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoPec ProgettoPecObj)
		{
			int returnValue = 0;
			if (ProgettoPecObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoPecObj.IdProgettoPec);
			}
			ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoPecObj.IsDirty = false;
			ProgettoPecObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoPecValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoPecDelete", new string[] {"IdProgettoPec"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoPec", (SiarLibrary.NullTypes.IntNT)IdProgettoPecValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoPecCollection ProgettoPecCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoPecDelete", new string[] {"IdProgettoPec"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoPecCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoPec", ProgettoPecCollectionObj[i].IdProgettoPec);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoPecCollectionObj.Count; i++)
				{
					if ((ProgettoPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoPecCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoPecCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoPecCollectionObj[i].IsDirty = false;
						ProgettoPecCollectionObj[i].IsPersistent = false;
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
		public static ProgettoPec GetById(DbProvider db, int IdProgettoPecValue)
		{
			ProgettoPec ProgettoPecObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoPecGetById", new string[] {"IdProgettoPec"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgettoPec", (SiarLibrary.NullTypes.IntNT)IdProgettoPecValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoPecObj = GetFromDatareader(db);
				ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoPecObj.IsDirty = false;
				ProgettoPecObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoPecObj;
		}

		//getFromDatareader
		public static ProgettoPec GetFromDatareader(DbProvider db)
		{
			ProgettoPec ProgettoPecObj = new ProgettoPec();
			ProgettoPecObj.IdProgettoPec = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_PEC"]);
			ProgettoPecObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoPecObj.Pec = new SiarLibrary.NullTypes.StringNT(db.DataReader["PEC"]);
			ProgettoPecObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ProgettoPecObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ProgettoPecObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ProgettoPecObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoPecObj.IsDirty = false;
			ProgettoPecObj.IsPersistent = true;
			return ProgettoPecObj;
		}

		//Find Select

		public static ProgettoPecCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoPecEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT PecEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis)

		{

			ProgettoPecCollection ProgettoPecCollectionObj = new ProgettoPecCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettopecfindselect", new string[] {"IdProgettoPecequalthis", "IdProgettoequalthis", "Pecequalthis", 
"DataCreazioneequalthis", "OperatoreCreazioneequalthis", "DataModificaequalthis", 
"OperatoreModificaequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "int", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoPecequalthis", IdProgettoPecEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pecequalthis", PecEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			ProgettoPec ProgettoPecObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoPecObj = GetFromDatareader(db);
				ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoPecObj.IsDirty = false;
				ProgettoPecObj.IsPersistent = true;
				ProgettoPecCollectionObj.Add(ProgettoPecObj);
			}
			db.Close();
			return ProgettoPecCollectionObj;
		}

		//Find Find

		public static ProgettoPecCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoPecEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT PecEqualThis)

		{

			ProgettoPecCollection ProgettoPecCollectionObj = new ProgettoPecCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettopecfindfind", new string[] {"IdProgettoPecequalthis", "IdProgettoequalthis", "Pecequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoPecequalthis", IdProgettoPecEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pecequalthis", PecEqualThis);
			ProgettoPec ProgettoPecObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoPecObj = GetFromDatareader(db);
				ProgettoPecObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoPecObj.IsDirty = false;
				ProgettoPecObj.IsPersistent = true;
				ProgettoPecCollectionObj.Add(ProgettoPecObj);
			}
			db.Close();
			return ProgettoPecCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoPecCollectionProvider:IProgettoPecProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoPecCollectionProvider : IProgettoPecProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoPec
		protected ProgettoPecCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoPecCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoPecCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoPecCollectionProvider(IntNT IdprogettopecEqualThis, IntNT IdprogettoEqualThis, StringNT PecEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettopecEqualThis, IdprogettoEqualThis, PecEqualThis);
		}

		//Costruttore3: ha in input progettopecCollectionObj - non popola la collection
		public ProgettoPecCollectionProvider(ProgettoPecCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoPecCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoPecCollection(this);
		}

		//Get e Set
		public ProgettoPecCollection CollectionObj
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
		public int SaveCollection(ProgettoPecCollection collectionObj)
		{
			return ProgettoPecDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoPec progettopecObj)
		{
			return ProgettoPecDAL.Save(_dbProviderObj, progettopecObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoPecCollection collectionObj)
		{
			return ProgettoPecDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoPec progettopecObj)
		{
			return ProgettoPecDAL.Delete(_dbProviderObj, progettopecObj);
		}

		//getById
		public ProgettoPec GetById(IntNT IdProgettoPecValue)
		{
			ProgettoPec ProgettoPecTemp = ProgettoPecDAL.GetById(_dbProviderObj, IdProgettoPecValue);
			if (ProgettoPecTemp!=null) ProgettoPecTemp.Provider = this;
			return ProgettoPecTemp;
		}

		//Select: popola la collection
		public ProgettoPecCollection Select(IntNT IdprogettopecEqualThis, IntNT IdprogettoEqualThis, StringNT PecEqualThis, 
DatetimeNT DatacreazioneEqualThis, IntNT OperatorecreazioneEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT OperatoremodificaEqualThis)
		{
			ProgettoPecCollection ProgettoPecCollectionTemp = ProgettoPecDAL.Select(_dbProviderObj, IdprogettopecEqualThis, IdprogettoEqualThis, PecEqualThis, 
DatacreazioneEqualThis, OperatorecreazioneEqualThis, DatamodificaEqualThis, 
OperatoremodificaEqualThis);
			ProgettoPecCollectionTemp.Provider = this;
			return ProgettoPecCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoPecCollection Find(IntNT IdprogettopecEqualThis, IntNT IdprogettoEqualThis, StringNT PecEqualThis)
		{
			ProgettoPecCollection ProgettoPecCollectionTemp = ProgettoPecDAL.Find(_dbProviderObj, IdprogettopecEqualThis, IdprogettoEqualThis, PecEqualThis);
			ProgettoPecCollectionTemp.Provider = this;
			return ProgettoPecCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_PEC>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_PROGETTO_PEC>Equal</ID_PROGETTO_PEC>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <PEC>Equal</PEC>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_PEC>
*/
