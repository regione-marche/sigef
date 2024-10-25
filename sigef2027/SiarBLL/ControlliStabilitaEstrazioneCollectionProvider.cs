using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ControlliStabilitaEstrazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliStabilitaEstrazioneProvider
	{
		int Save(ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj);
		int SaveCollection(ControlliStabilitaEstrazioneCollection collectionObj);
		int Delete(ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj);
		int DeleteCollection(ControlliStabilitaEstrazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliStabilitaEstrazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ControlliStabilitaEstrazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.DatetimeNT _DataApertura;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _Progetti;
		[NonSerialized] private IControlliStabilitaEstrazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliStabilitaEstrazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliStabilitaEstrazione()
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
		/// Corrisponde al campo:DATA_APERTURA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApertura
		{
			get { return _DataApertura; }
			set {
				if (DataApertura != value)
				{
					_DataApertura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGETTI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Progetti
		{
			get { return _Progetti; }
			set {
				if (Progetti != value)
				{
					_Progetti = value;
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
	/// Summary description for ControlliStabilitaEstrazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliStabilitaEstrazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliStabilitaEstrazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliStabilitaEstrazione) info.GetValue(i.ToString(),typeof(ControlliStabilitaEstrazione)));
			}
		}

		//Costruttore
		public ControlliStabilitaEstrazioneCollection()
		{
			this.ItemType = typeof(ControlliStabilitaEstrazione);
		}

		//Costruttore con provider
		public ControlliStabilitaEstrazioneCollection(IControlliStabilitaEstrazioneProvider providerObj)
		{
			this.ItemType = typeof(ControlliStabilitaEstrazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliStabilitaEstrazione this[int index]
		{
			get { return (ControlliStabilitaEstrazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliStabilitaEstrazioneCollection GetChanges()
		{
			return (ControlliStabilitaEstrazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliStabilitaEstrazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliStabilitaEstrazioneProvider Provider
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
		public int Add(ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			if (ControlliStabilitaEstrazioneObj.Provider == null) ControlliStabilitaEstrazioneObj.Provider = this.Provider;
			return base.Add(ControlliStabilitaEstrazioneObj);
		}

		//AddCollection
		public void AddCollection(ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionObj)
		{
			foreach (ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj in ControlliStabilitaEstrazioneCollectionObj)
				this.Add(ControlliStabilitaEstrazioneObj);
		}

		//Insert
		public void Insert(int index, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			if (ControlliStabilitaEstrazioneObj.Provider == null) ControlliStabilitaEstrazioneObj.Provider = this.Provider;
			base.Insert(index, ControlliStabilitaEstrazioneObj);
		}

		//CollectionGetById
		public ControlliStabilitaEstrazione CollectionGetById(NullTypes.IntNT IdValue)
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
		public ControlliStabilitaEstrazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.DatetimeNT DataAperturaEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT ProgettiEqualThis)
		{
			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionTemp = new ControlliStabilitaEstrazioneCollection();
			foreach (ControlliStabilitaEstrazione ControlliStabilitaEstrazioneItem in this)
			{
				if (((IdEqualThis == null) || ((ControlliStabilitaEstrazioneItem.Id != null) && (ControlliStabilitaEstrazioneItem.Id.Value == IdEqualThis.Value))) && ((DataAperturaEqualThis == null) || ((ControlliStabilitaEstrazioneItem.DataApertura != null) && (ControlliStabilitaEstrazioneItem.DataApertura.Value == DataAperturaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ControlliStabilitaEstrazioneItem.Operatore != null) && (ControlliStabilitaEstrazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((SegnaturaEqualThis == null) || ((ControlliStabilitaEstrazioneItem.Segnatura != null) && (ControlliStabilitaEstrazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((ProgettiEqualThis == null) || ((ControlliStabilitaEstrazioneItem.Progetti != null) && (ControlliStabilitaEstrazioneItem.Progetti.Value == ProgettiEqualThis.Value))))
				{
					ControlliStabilitaEstrazioneCollectionTemp.Add(ControlliStabilitaEstrazioneItem);
				}
			}
			return ControlliStabilitaEstrazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ControlliStabilitaEstrazioneCollection Filter(NullTypes.IntNT OperatoreEqualThis)
		{
			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionTemp = new ControlliStabilitaEstrazioneCollection();
			foreach (ControlliStabilitaEstrazione ControlliStabilitaEstrazioneItem in this)
			{
				if (((OperatoreEqualThis == null) || ((ControlliStabilitaEstrazioneItem.Operatore != null) && (ControlliStabilitaEstrazioneItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					ControlliStabilitaEstrazioneCollectionTemp.Add(ControlliStabilitaEstrazioneItem);
				}
			}
			return ControlliStabilitaEstrazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliStabilitaEstrazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ControlliStabilitaEstrazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ControlliStabilitaEstrazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataApertura", ControlliStabilitaEstrazioneObj.DataApertura);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ControlliStabilitaEstrazioneObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ControlliStabilitaEstrazioneObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Progetti", ControlliStabilitaEstrazioneObj.Progetti);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliStabilitaEstrazioneInsert", new string[] {"DataApertura", "Operatore", 
"Segnatura", "Progetti"}, new string[] {"DateTime", "int", 
"string", "string"},"");
				CompileIUCmd(false, insertCmd,ControlliStabilitaEstrazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneObj.IsDirty = false;
				ControlliStabilitaEstrazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliStabilitaEstrazioneUpdate", new string[] {"Id", "DataApertura", "Operatore", 
"Segnatura", "Progetti"}, new string[] {"int", "DateTime", "int", 
"string", "string"},"");
				CompileIUCmd(true, updateCmd,ControlliStabilitaEstrazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneObj.IsDirty = false;
				ControlliStabilitaEstrazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			switch (ControlliStabilitaEstrazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliStabilitaEstrazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliStabilitaEstrazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliStabilitaEstrazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliStabilitaEstrazioneUpdate", new string[] {"Id", "DataApertura", "Operatore", 
"Segnatura", "Progetti"}, new string[] {"int", "DateTime", "int", 
"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliStabilitaEstrazioneInsert", new string[] {"DataApertura", "Operatore", 
"Segnatura", "Progetti"}, new string[] {"DateTime", "int", 
"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliStabilitaEstrazioneCollectionObj.Count; i++)
				{
					switch (ControlliStabilitaEstrazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliStabilitaEstrazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliStabilitaEstrazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliStabilitaEstrazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliStabilitaEstrazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ControlliStabilitaEstrazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliStabilitaEstrazioneCollectionObj.Count; i++)
				{
					if ((ControlliStabilitaEstrazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliStabilitaEstrazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliStabilitaEstrazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliStabilitaEstrazioneCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliStabilitaEstrazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliStabilitaEstrazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliStabilitaEstrazioneCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj)
		{
			int returnValue = 0;
			if (ControlliStabilitaEstrazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliStabilitaEstrazioneObj.Id);
			}
			ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliStabilitaEstrazioneObj.IsDirty = false;
			ControlliStabilitaEstrazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliStabilitaEstrazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ControlliStabilitaEstrazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliStabilitaEstrazioneCollectionObj.Count; i++)
				{
					if ((ControlliStabilitaEstrazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliStabilitaEstrazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliStabilitaEstrazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliStabilitaEstrazioneCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneCollectionObj[i].IsPersistent = false;
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
		public static ControlliStabilitaEstrazione GetById(DbProvider db, int IdValue)
		{
			ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliStabilitaEstrazioneGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneObj.IsDirty = false;
				ControlliStabilitaEstrazioneObj.IsPersistent = true;
			}
			db.Close();
			return ControlliStabilitaEstrazioneObj;
		}

		//getFromDatareader
		public static ControlliStabilitaEstrazione GetFromDatareader(DbProvider db)
		{
			ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj = new ControlliStabilitaEstrazione();
			ControlliStabilitaEstrazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ControlliStabilitaEstrazioneObj.DataApertura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA"]);
			ControlliStabilitaEstrazioneObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ControlliStabilitaEstrazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ControlliStabilitaEstrazioneObj.Progetti = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGETTI"]);
			ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliStabilitaEstrazioneObj.IsDirty = false;
			ControlliStabilitaEstrazioneObj.IsPersistent = true;
			return ControlliStabilitaEstrazioneObj;
		}

		//Find Select

		public static ControlliStabilitaEstrazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAperturaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT ProgettiEqualThis)

		{

			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionObj = new ControlliStabilitaEstrazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollistabilitaestrazionefindselect", new string[] {"Idequalthis", "DataAperturaequalthis", "Operatoreequalthis", 
"Segnaturaequalthis", "Progettiequalthis"}, new string[] {"int", "DateTime", "int", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAperturaequalthis", DataAperturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progettiequalthis", ProgettiEqualThis);
			ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneObj.IsDirty = false;
				ControlliStabilitaEstrazioneObj.IsPersistent = true;
				ControlliStabilitaEstrazioneCollectionObj.Add(ControlliStabilitaEstrazioneObj);
			}
			db.Close();
			return ControlliStabilitaEstrazioneCollectionObj;
		}

		//Find Find

		public static ControlliStabilitaEstrazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionObj = new ControlliStabilitaEstrazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollistabilitaestrazionefindfind", new string[] {"Operatoreequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			ControlliStabilitaEstrazione ControlliStabilitaEstrazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneObj.IsDirty = false;
				ControlliStabilitaEstrazioneObj.IsPersistent = true;
				ControlliStabilitaEstrazioneCollectionObj.Add(ControlliStabilitaEstrazioneObj);
			}
			db.Close();
			return ControlliStabilitaEstrazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliStabilitaEstrazioneCollectionProvider:IControlliStabilitaEstrazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliStabilitaEstrazioneCollectionProvider : IControlliStabilitaEstrazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliStabilitaEstrazione
		protected ControlliStabilitaEstrazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliStabilitaEstrazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliStabilitaEstrazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliStabilitaEstrazioneCollectionProvider(IntNT OperatoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(OperatoreEqualThis);
		}

		//Costruttore3: ha in input controllistabilitaestrazioneCollectionObj - non popola la collection
		public ControlliStabilitaEstrazioneCollectionProvider(ControlliStabilitaEstrazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliStabilitaEstrazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliStabilitaEstrazioneCollection(this);
		}

		//Get e Set
		public ControlliStabilitaEstrazioneCollection CollectionObj
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
		public int SaveCollection(ControlliStabilitaEstrazioneCollection collectionObj)
		{
			return ControlliStabilitaEstrazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliStabilitaEstrazione controllistabilitaestrazioneObj)
		{
			return ControlliStabilitaEstrazioneDAL.Save(_dbProviderObj, controllistabilitaestrazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliStabilitaEstrazioneCollection collectionObj)
		{
			return ControlliStabilitaEstrazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliStabilitaEstrazione controllistabilitaestrazioneObj)
		{
			return ControlliStabilitaEstrazioneDAL.Delete(_dbProviderObj, controllistabilitaestrazioneObj);
		}

		//getById
		public ControlliStabilitaEstrazione GetById(IntNT IdValue)
		{
			ControlliStabilitaEstrazione ControlliStabilitaEstrazioneTemp = ControlliStabilitaEstrazioneDAL.GetById(_dbProviderObj, IdValue);
			if (ControlliStabilitaEstrazioneTemp!=null) ControlliStabilitaEstrazioneTemp.Provider = this;
			return ControlliStabilitaEstrazioneTemp;
		}

		//Select: popola la collection
		public ControlliStabilitaEstrazioneCollection Select(IntNT IdEqualThis, DatetimeNT DataaperturaEqualThis, IntNT OperatoreEqualThis, 
StringNT SegnaturaEqualThis, StringNT ProgettiEqualThis)
		{
			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionTemp = ControlliStabilitaEstrazioneDAL.Select(_dbProviderObj, IdEqualThis, DataaperturaEqualThis, OperatoreEqualThis, 
SegnaturaEqualThis, ProgettiEqualThis);
			ControlliStabilitaEstrazioneCollectionTemp.Provider = this;
			return ControlliStabilitaEstrazioneCollectionTemp;
		}

		//Find: popola la collection
		public ControlliStabilitaEstrazioneCollection Find(IntNT OperatoreEqualThis)
		{
			ControlliStabilitaEstrazioneCollection ControlliStabilitaEstrazioneCollectionTemp = ControlliStabilitaEstrazioneDAL.Find(_dbProviderObj, OperatoreEqualThis);
			ControlliStabilitaEstrazioneCollectionTemp.Provider = this;
			return ControlliStabilitaEstrazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_STABILITA_ESTRAZIONE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
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
      <OPERATORE>Equal</OPERATORE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <OPERATORE>Equal</OPERATORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_STABILITA_ESTRAZIONE>
*/
