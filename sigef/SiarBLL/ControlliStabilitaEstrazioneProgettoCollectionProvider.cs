using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ControlliStabilitaEstrazioneProgetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliStabilitaEstrazioneProgettoProvider
	{
		int Save(ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj);
		int SaveCollection(ControlliStabilitaEstrazioneProgettoCollection collectionObj);
		int Delete(ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj);
		int DeleteCollection(ControlliStabilitaEstrazioneProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliStabilitaEstrazioneProgetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ControlliStabilitaEstrazioneProgetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdEstrazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataInserimento;
		[NonSerialized] private IControlliStabilitaEstrazioneProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliStabilitaEstrazioneProgettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliStabilitaEstrazioneProgetto()
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
		/// Corrisponde al campo:ID_ESTRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdEstrazione
		{
			get { return _IdEstrazione; }
			set {
				if (IdEstrazione != value)
				{
					_IdEstrazione = value;
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
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
	/// Summary description for ControlliStabilitaEstrazioneProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliStabilitaEstrazioneProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliStabilitaEstrazioneProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliStabilitaEstrazioneProgetto) info.GetValue(i.ToString(),typeof(ControlliStabilitaEstrazioneProgetto)));
			}
		}

		//Costruttore
		public ControlliStabilitaEstrazioneProgettoCollection()
		{
			this.ItemType = typeof(ControlliStabilitaEstrazioneProgetto);
		}

		//Costruttore con provider
		public ControlliStabilitaEstrazioneProgettoCollection(IControlliStabilitaEstrazioneProgettoProvider providerObj)
		{
			this.ItemType = typeof(ControlliStabilitaEstrazioneProgetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliStabilitaEstrazioneProgetto this[int index]
		{
			get { return (ControlliStabilitaEstrazioneProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliStabilitaEstrazioneProgettoCollection GetChanges()
		{
			return (ControlliStabilitaEstrazioneProgettoCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliStabilitaEstrazioneProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliStabilitaEstrazioneProgettoProvider Provider
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
		public int Add(ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			if (ControlliStabilitaEstrazioneProgettoObj.Provider == null) ControlliStabilitaEstrazioneProgettoObj.Provider = this.Provider;
			return base.Add(ControlliStabilitaEstrazioneProgettoObj);
		}

		//AddCollection
		public void AddCollection(ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionObj)
		{
			foreach (ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj in ControlliStabilitaEstrazioneProgettoCollectionObj)
				this.Add(ControlliStabilitaEstrazioneProgettoObj);
		}

		//Insert
		public void Insert(int index, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			if (ControlliStabilitaEstrazioneProgettoObj.Provider == null) ControlliStabilitaEstrazioneProgettoObj.Provider = this.Provider;
			base.Insert(index, ControlliStabilitaEstrazioneProgettoObj);
		}

		//CollectionGetById
		public ControlliStabilitaEstrazioneProgetto CollectionGetById(NullTypes.IntNT IdValue)
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
		public ControlliStabilitaEstrazioneProgettoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdEstrazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis)
		{
			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionTemp = new ControlliStabilitaEstrazioneProgettoCollection();
			foreach (ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoItem in this)
			{
				if (((IdEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.Id != null) && (ControlliStabilitaEstrazioneProgettoItem.Id.Value == IdEqualThis.Value))) && ((IdEstrazioneEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.IdEstrazione != null) && (ControlliStabilitaEstrazioneProgettoItem.IdEstrazione.Value == IdEstrazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.IdProgetto != null) && (ControlliStabilitaEstrazioneProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.DataInserimento != null) && (ControlliStabilitaEstrazioneProgettoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))))
				{
					ControlliStabilitaEstrazioneProgettoCollectionTemp.Add(ControlliStabilitaEstrazioneProgettoItem);
				}
			}
			return ControlliStabilitaEstrazioneProgettoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ControlliStabilitaEstrazioneProgettoCollection Filter(NullTypes.IntNT IdEstrazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis)
		{
			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionTemp = new ControlliStabilitaEstrazioneProgettoCollection();
			foreach (ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoItem in this)
			{
				if (((IdEstrazioneEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.IdEstrazione != null) && (ControlliStabilitaEstrazioneProgettoItem.IdEstrazione.Value == IdEstrazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ControlliStabilitaEstrazioneProgettoItem.IdProgetto != null) && (ControlliStabilitaEstrazioneProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
				{
					ControlliStabilitaEstrazioneProgettoCollectionTemp.Add(ControlliStabilitaEstrazioneProgettoItem);
				}
			}
			return ControlliStabilitaEstrazioneProgettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliStabilitaEstrazioneProgettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ControlliStabilitaEstrazioneProgettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ControlliStabilitaEstrazioneProgettoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdEstrazione", ControlliStabilitaEstrazioneProgettoObj.IdEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ControlliStabilitaEstrazioneProgettoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ControlliStabilitaEstrazioneProgettoObj.DataInserimento);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoInsert", new string[] {"IdEstrazione", "IdProgetto", 
"DataInserimento"}, new string[] {"int", "int", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,ControlliStabilitaEstrazioneProgettoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneProgettoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
				ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoUpdate", new string[] {"Id", "IdEstrazione", "IdProgetto", 
"DataInserimento"}, new string[] {"int", "int", "int", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,ControlliStabilitaEstrazioneProgettoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
				ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			switch (ControlliStabilitaEstrazioneProgettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliStabilitaEstrazioneProgettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliStabilitaEstrazioneProgettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliStabilitaEstrazioneProgettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoUpdate", new string[] {"Id", "IdEstrazione", "IdProgetto", 
"DataInserimento"}, new string[] {"int", "int", "int", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoInsert", new string[] {"IdEstrazione", "IdProgetto", 
"DataInserimento"}, new string[] {"int", "int", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliStabilitaEstrazioneProgettoCollectionObj.Count; i++)
				{
					switch (ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliStabilitaEstrazioneProgettoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliStabilitaEstrazioneProgettoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliStabilitaEstrazioneProgettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ControlliStabilitaEstrazioneProgettoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliStabilitaEstrazioneProgettoCollectionObj.Count; i++)
				{
					if ((ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj)
		{
			int returnValue = 0;
			if (ControlliStabilitaEstrazioneProgettoObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliStabilitaEstrazioneProgettoObj.Id);
			}
			ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
			ControlliStabilitaEstrazioneProgettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliStabilitaEstrazioneProgettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ControlliStabilitaEstrazioneProgettoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliStabilitaEstrazioneProgettoCollectionObj.Count; i++)
				{
					if ((ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsDirty = false;
						ControlliStabilitaEstrazioneProgettoCollectionObj[i].IsPersistent = false;
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
		public static ControlliStabilitaEstrazioneProgetto GetById(DbProvider db, int IdValue)
		{
			ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliStabilitaEstrazioneProgettoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneProgettoObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
				ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
			}
			db.Close();
			return ControlliStabilitaEstrazioneProgettoObj;
		}

		//getFromDatareader
		public static ControlliStabilitaEstrazioneProgetto GetFromDatareader(DbProvider db)
		{
			ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj = new ControlliStabilitaEstrazioneProgetto();
			ControlliStabilitaEstrazioneProgettoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ControlliStabilitaEstrazioneProgettoObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
			ControlliStabilitaEstrazioneProgettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ControlliStabilitaEstrazioneProgettoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
			ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
			return ControlliStabilitaEstrazioneProgettoObj;
		}

		//Find Select

		public static ControlliStabilitaEstrazioneProgettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis)

		{

			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionObj = new ControlliStabilitaEstrazioneProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollistabilitaestrazioneprogettofindselect", new string[] {"Idequalthis", "IdEstrazioneequalthis", "IdProgettoequalthis", 
"DataInserimentoequalthis"}, new string[] {"int", "int", "int", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneequalthis", IdEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneProgettoObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
				ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
				ControlliStabilitaEstrazioneProgettoCollectionObj.Add(ControlliStabilitaEstrazioneProgettoObj);
			}
			db.Close();
			return ControlliStabilitaEstrazioneProgettoCollectionObj;
		}

		//Find Find

		public static ControlliStabilitaEstrazioneProgettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionObj = new ControlliStabilitaEstrazioneProgettoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollistabilitaestrazioneprogettofindfind", new string[] {"IdEstrazioneequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneequalthis", IdEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliStabilitaEstrazioneProgettoObj = GetFromDatareader(db);
				ControlliStabilitaEstrazioneProgettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliStabilitaEstrazioneProgettoObj.IsDirty = false;
				ControlliStabilitaEstrazioneProgettoObj.IsPersistent = true;
				ControlliStabilitaEstrazioneProgettoCollectionObj.Add(ControlliStabilitaEstrazioneProgettoObj);
			}
			db.Close();
			return ControlliStabilitaEstrazioneProgettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliStabilitaEstrazioneProgettoCollectionProvider:IControlliStabilitaEstrazioneProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliStabilitaEstrazioneProgettoCollectionProvider : IControlliStabilitaEstrazioneProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliStabilitaEstrazioneProgetto
		protected ControlliStabilitaEstrazioneProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliStabilitaEstrazioneProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliStabilitaEstrazioneProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliStabilitaEstrazioneProgettoCollectionProvider(IntNT IdestrazioneEqualThis, IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdestrazioneEqualThis, IdprogettoEqualThis);
		}

		//Costruttore3: ha in input controllistabilitaestrazioneprogettoCollectionObj - non popola la collection
		public ControlliStabilitaEstrazioneProgettoCollectionProvider(ControlliStabilitaEstrazioneProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliStabilitaEstrazioneProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliStabilitaEstrazioneProgettoCollection(this);
		}

		//Get e Set
		public ControlliStabilitaEstrazioneProgettoCollection CollectionObj
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
		public int SaveCollection(ControlliStabilitaEstrazioneProgettoCollection collectionObj)
		{
			return ControlliStabilitaEstrazioneProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliStabilitaEstrazioneProgetto controllistabilitaestrazioneprogettoObj)
		{
			return ControlliStabilitaEstrazioneProgettoDAL.Save(_dbProviderObj, controllistabilitaestrazioneprogettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliStabilitaEstrazioneProgettoCollection collectionObj)
		{
			return ControlliStabilitaEstrazioneProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliStabilitaEstrazioneProgetto controllistabilitaestrazioneprogettoObj)
		{
			return ControlliStabilitaEstrazioneProgettoDAL.Delete(_dbProviderObj, controllistabilitaestrazioneprogettoObj);
		}

		//getById
		public ControlliStabilitaEstrazioneProgetto GetById(IntNT IdValue)
		{
			ControlliStabilitaEstrazioneProgetto ControlliStabilitaEstrazioneProgettoTemp = ControlliStabilitaEstrazioneProgettoDAL.GetById(_dbProviderObj, IdValue);
			if (ControlliStabilitaEstrazioneProgettoTemp!=null) ControlliStabilitaEstrazioneProgettoTemp.Provider = this;
			return ControlliStabilitaEstrazioneProgettoTemp;
		}

		//Select: popola la collection
		public ControlliStabilitaEstrazioneProgettoCollection Select(IntNT IdEqualThis, IntNT IdestrazioneEqualThis, IntNT IdprogettoEqualThis, 
DatetimeNT DatainserimentoEqualThis)
		{
			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionTemp = ControlliStabilitaEstrazioneProgettoDAL.Select(_dbProviderObj, IdEqualThis, IdestrazioneEqualThis, IdprogettoEqualThis, 
DatainserimentoEqualThis);
			ControlliStabilitaEstrazioneProgettoCollectionTemp.Provider = this;
			return ControlliStabilitaEstrazioneProgettoCollectionTemp;
		}

		//Find: popola la collection
		public ControlliStabilitaEstrazioneProgettoCollection Find(IntNT IdestrazioneEqualThis, IntNT IdprogettoEqualThis)
		{
			ControlliStabilitaEstrazioneProgettoCollection ControlliStabilitaEstrazioneProgettoCollectionTemp = ControlliStabilitaEstrazioneProgettoDAL.Find(_dbProviderObj, IdestrazioneEqualThis, IdprogettoEqualThis);
			ControlliStabilitaEstrazioneProgettoCollectionTemp.Provider = this;
			return ControlliStabilitaEstrazioneProgettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_STABILITA_ESTRAZIONE_PROGETTO>
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
      <ID_ESTRAZIONE>Equal</ID_ESTRAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_ESTRAZIONE>Equal</ID_ESTRAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_STABILITA_ESTRAZIONE_PROGETTO>
*/
