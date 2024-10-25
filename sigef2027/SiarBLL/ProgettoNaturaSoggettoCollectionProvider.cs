using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoNaturaSoggetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoNaturaSoggettoProvider
	{
		int Save(ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj);
		int SaveCollection(ProgettoNaturaSoggettoCollection collectionObj);
		int Delete(ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj);
		int DeleteCollection(ProgettoNaturaSoggettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoNaturaSoggetto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoNaturaSoggetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgettoNaturaSoggetto;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _TipoNaturaSoggetto;
		private NullTypes.IntNT _IdAggregazione;
		[NonSerialized] private IProgettoNaturaSoggettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoNaturaSoggettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoNaturaSoggetto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_NATURA_SOGGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoNaturaSoggetto
		{
			get { return _IdProgettoNaturaSoggetto; }
			set {
				if (IdProgettoNaturaSoggetto != value)
				{
					_IdProgettoNaturaSoggetto = value;
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
		/// Corrisponde al campo:TIPO_NATURA_SOGGETTO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoNaturaSoggetto
		{
			get { return _TipoNaturaSoggetto; }
			set {
				if (TipoNaturaSoggetto != value)
				{
					_TipoNaturaSoggetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AGGREGAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAggregazione
		{
			get { return _IdAggregazione; }
			set {
				if (IdAggregazione != value)
				{
					_IdAggregazione = value;
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
	/// Summary description for ProgettoNaturaSoggettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoNaturaSoggettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoNaturaSoggettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoNaturaSoggetto) info.GetValue(i.ToString(),typeof(ProgettoNaturaSoggetto)));
			}
		}

		//Costruttore
		public ProgettoNaturaSoggettoCollection()
		{
			this.ItemType = typeof(ProgettoNaturaSoggetto);
		}

		//Costruttore con provider
		public ProgettoNaturaSoggettoCollection(IProgettoNaturaSoggettoProvider providerObj)
		{
			this.ItemType = typeof(ProgettoNaturaSoggetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoNaturaSoggetto this[int index]
		{
			get { return (ProgettoNaturaSoggetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoNaturaSoggettoCollection GetChanges()
		{
			return (ProgettoNaturaSoggettoCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoNaturaSoggettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoNaturaSoggettoProvider Provider
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
		public int Add(ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			if (ProgettoNaturaSoggettoObj.Provider == null) ProgettoNaturaSoggettoObj.Provider = this.Provider;
			return base.Add(ProgettoNaturaSoggettoObj);
		}

		//AddCollection
		public void AddCollection(ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionObj)
		{
			foreach (ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj in ProgettoNaturaSoggettoCollectionObj)
				this.Add(ProgettoNaturaSoggettoObj);
		}

		//Insert
		public void Insert(int index, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			if (ProgettoNaturaSoggettoObj.Provider == null) ProgettoNaturaSoggettoObj.Provider = this.Provider;
			base.Insert(index, ProgettoNaturaSoggettoObj);
		}

		//CollectionGetById
		public ProgettoNaturaSoggetto CollectionGetById(NullTypes.IntNT IdProgettoNaturaSoggettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgettoNaturaSoggetto == IdProgettoNaturaSoggettoValue))
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
		public ProgettoNaturaSoggettoCollection SubSelect(NullTypes.IntNT IdProgettoNaturaSoggettoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT TipoNaturaSoggettoEqualThis, 
NullTypes.IntNT IdAggregazioneEqualThis)
		{
			ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionTemp = new ProgettoNaturaSoggettoCollection();
			foreach (ProgettoNaturaSoggetto ProgettoNaturaSoggettoItem in this)
			{
				if (((IdProgettoNaturaSoggettoEqualThis == null) || ((ProgettoNaturaSoggettoItem.IdProgettoNaturaSoggetto != null) && (ProgettoNaturaSoggettoItem.IdProgettoNaturaSoggetto.Value == IdProgettoNaturaSoggettoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoNaturaSoggettoItem.IdProgetto != null) && (ProgettoNaturaSoggettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((TipoNaturaSoggettoEqualThis == null) || ((ProgettoNaturaSoggettoItem.TipoNaturaSoggetto != null) && (ProgettoNaturaSoggettoItem.TipoNaturaSoggetto.Value == TipoNaturaSoggettoEqualThis.Value))) && 
((IdAggregazioneEqualThis == null) || ((ProgettoNaturaSoggettoItem.IdAggregazione != null) && (ProgettoNaturaSoggettoItem.IdAggregazione.Value == IdAggregazioneEqualThis.Value))))
				{
					ProgettoNaturaSoggettoCollectionTemp.Add(ProgettoNaturaSoggettoItem);
				}
			}
			return ProgettoNaturaSoggettoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoNaturaSoggettoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoNaturaSoggettoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoNaturaSoggetto", ProgettoNaturaSoggettoObj.IdProgettoNaturaSoggetto);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoNaturaSoggettoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoNaturaSoggetto", ProgettoNaturaSoggettoObj.TipoNaturaSoggetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAggregazione", ProgettoNaturaSoggettoObj.IdAggregazione);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoNaturaSoggettoInsert", new string[] {"IdProgetto", "TipoNaturaSoggetto", 
"IdAggregazione"}, new string[] {"int", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,ProgettoNaturaSoggettoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoNaturaSoggettoObj.IdProgettoNaturaSoggetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_NATURA_SOGGETTO"]);
				}
				ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoNaturaSoggettoObj.IsDirty = false;
				ProgettoNaturaSoggettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoNaturaSoggettoUpdate", new string[] {"IdProgettoNaturaSoggetto", "IdProgetto", "TipoNaturaSoggetto", 
"IdAggregazione"}, new string[] {"int", "int", "string", 
"int"},"");
				CompileIUCmd(true, updateCmd,ProgettoNaturaSoggettoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoNaturaSoggettoObj.IsDirty = false;
				ProgettoNaturaSoggettoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			switch (ProgettoNaturaSoggettoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoNaturaSoggettoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoNaturaSoggettoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoNaturaSoggettoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoNaturaSoggettoUpdate", new string[] {"IdProgettoNaturaSoggetto", "IdProgetto", "TipoNaturaSoggetto", 
"IdAggregazione"}, new string[] {"int", "int", "string", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoNaturaSoggettoInsert", new string[] {"IdProgetto", "TipoNaturaSoggetto", 
"IdAggregazione"}, new string[] {"int", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoNaturaSoggettoDelete", new string[] {"IdProgettoNaturaSoggetto"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoNaturaSoggettoCollectionObj.Count; i++)
				{
					switch (ProgettoNaturaSoggettoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoNaturaSoggettoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoNaturaSoggettoCollectionObj[i].IdProgettoNaturaSoggetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_NATURA_SOGGETTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoNaturaSoggettoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoNaturaSoggettoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoNaturaSoggetto", (SiarLibrary.NullTypes.IntNT)ProgettoNaturaSoggettoCollectionObj[i].IdProgettoNaturaSoggetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoNaturaSoggettoCollectionObj.Count; i++)
				{
					if ((ProgettoNaturaSoggettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoNaturaSoggettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoNaturaSoggettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoNaturaSoggettoCollectionObj[i].IsDirty = false;
						ProgettoNaturaSoggettoCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoNaturaSoggettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoNaturaSoggettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoNaturaSoggettoCollectionObj[i].IsDirty = false;
						ProgettoNaturaSoggettoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj)
		{
			int returnValue = 0;
			if (ProgettoNaturaSoggettoObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoNaturaSoggettoObj.IdProgettoNaturaSoggetto);
			}
			ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoNaturaSoggettoObj.IsDirty = false;
			ProgettoNaturaSoggettoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoNaturaSoggettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoNaturaSoggettoDelete", new string[] {"IdProgettoNaturaSoggetto"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoNaturaSoggetto", (SiarLibrary.NullTypes.IntNT)IdProgettoNaturaSoggettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoNaturaSoggettoDelete", new string[] {"IdProgettoNaturaSoggetto"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoNaturaSoggettoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgettoNaturaSoggetto", ProgettoNaturaSoggettoCollectionObj[i].IdProgettoNaturaSoggetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoNaturaSoggettoCollectionObj.Count; i++)
				{
					if ((ProgettoNaturaSoggettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoNaturaSoggettoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoNaturaSoggettoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoNaturaSoggettoCollectionObj[i].IsDirty = false;
						ProgettoNaturaSoggettoCollectionObj[i].IsPersistent = false;
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
		public static ProgettoNaturaSoggetto GetById(DbProvider db, int IdProgettoNaturaSoggettoValue)
		{
			ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoNaturaSoggettoGetById", new string[] {"IdProgettoNaturaSoggetto"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgettoNaturaSoggetto", (SiarLibrary.NullTypes.IntNT)IdProgettoNaturaSoggettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoNaturaSoggettoObj = GetFromDatareader(db);
				ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoNaturaSoggettoObj.IsDirty = false;
				ProgettoNaturaSoggettoObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoNaturaSoggettoObj;
		}

		//getFromDatareader
		public static ProgettoNaturaSoggetto GetFromDatareader(DbProvider db)
		{
			ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj = new ProgettoNaturaSoggetto();
			ProgettoNaturaSoggettoObj.IdProgettoNaturaSoggetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_NATURA_SOGGETTO"]);
			ProgettoNaturaSoggettoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoNaturaSoggettoObj.TipoNaturaSoggetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_NATURA_SOGGETTO"]);
			ProgettoNaturaSoggettoObj.IdAggregazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AGGREGAZIONE"]);
			ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoNaturaSoggettoObj.IsDirty = false;
			ProgettoNaturaSoggettoObj.IsPersistent = true;
			return ProgettoNaturaSoggettoObj;
		}

		//Find Select

		public static ProgettoNaturaSoggettoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoNaturaSoggettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT TipoNaturaSoggettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdAggregazioneEqualThis)

		{

			ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionObj = new ProgettoNaturaSoggettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettonaturasoggettofindselect", new string[] {"IdProgettoNaturaSoggettoequalthis", "IdProgettoequalthis", "TipoNaturaSoggettoequalthis", 
"IdAggregazioneequalthis"}, new string[] {"int", "int", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoNaturaSoggettoequalthis", IdProgettoNaturaSoggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoNaturaSoggettoequalthis", TipoNaturaSoggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAggregazioneequalthis", IdAggregazioneEqualThis);
			ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoNaturaSoggettoObj = GetFromDatareader(db);
				ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoNaturaSoggettoObj.IsDirty = false;
				ProgettoNaturaSoggettoObj.IsPersistent = true;
				ProgettoNaturaSoggettoCollectionObj.Add(ProgettoNaturaSoggettoObj);
			}
			db.Close();
			return ProgettoNaturaSoggettoCollectionObj;
		}

		//Find Find

		public static ProgettoNaturaSoggettoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT TipoNaturaSoggettoEqualThis, SiarLibrary.NullTypes.IntNT IdAggregazioneEqualThis)

		{

			ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionObj = new ProgettoNaturaSoggettoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettonaturasoggettofindfind", new string[] {"IdProgettoequalthis", "TipoNaturaSoggettoequalthis", "IdAggregazioneequalthis"}, new string[] {"int", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoNaturaSoggettoequalthis", TipoNaturaSoggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAggregazioneequalthis", IdAggregazioneEqualThis);
			ProgettoNaturaSoggetto ProgettoNaturaSoggettoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoNaturaSoggettoObj = GetFromDatareader(db);
				ProgettoNaturaSoggettoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoNaturaSoggettoObj.IsDirty = false;
				ProgettoNaturaSoggettoObj.IsPersistent = true;
				ProgettoNaturaSoggettoCollectionObj.Add(ProgettoNaturaSoggettoObj);
			}
			db.Close();
			return ProgettoNaturaSoggettoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoNaturaSoggettoCollectionProvider:IProgettoNaturaSoggettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoNaturaSoggettoCollectionProvider : IProgettoNaturaSoggettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoNaturaSoggetto
		protected ProgettoNaturaSoggettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoNaturaSoggettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoNaturaSoggettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoNaturaSoggettoCollectionProvider(IntNT IdprogettoEqualThis, StringNT TiponaturasoggettoEqualThis, IntNT IdaggregazioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, TiponaturasoggettoEqualThis, IdaggregazioneEqualThis);
		}

		//Costruttore3: ha in input progettonaturasoggettoCollectionObj - non popola la collection
		public ProgettoNaturaSoggettoCollectionProvider(ProgettoNaturaSoggettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoNaturaSoggettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoNaturaSoggettoCollection(this);
		}

		//Get e Set
		public ProgettoNaturaSoggettoCollection CollectionObj
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
		public int SaveCollection(ProgettoNaturaSoggettoCollection collectionObj)
		{
			return ProgettoNaturaSoggettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoNaturaSoggetto progettonaturasoggettoObj)
		{
			return ProgettoNaturaSoggettoDAL.Save(_dbProviderObj, progettonaturasoggettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoNaturaSoggettoCollection collectionObj)
		{
			return ProgettoNaturaSoggettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoNaturaSoggetto progettonaturasoggettoObj)
		{
			return ProgettoNaturaSoggettoDAL.Delete(_dbProviderObj, progettonaturasoggettoObj);
		}

		//getById
		public ProgettoNaturaSoggetto GetById(IntNT IdProgettoNaturaSoggettoValue)
		{
			ProgettoNaturaSoggetto ProgettoNaturaSoggettoTemp = ProgettoNaturaSoggettoDAL.GetById(_dbProviderObj, IdProgettoNaturaSoggettoValue);
			if (ProgettoNaturaSoggettoTemp!=null) ProgettoNaturaSoggettoTemp.Provider = this;
			return ProgettoNaturaSoggettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoNaturaSoggettoCollection Select(IntNT IdprogettonaturasoggettoEqualThis, IntNT IdprogettoEqualThis, StringNT TiponaturasoggettoEqualThis, 
IntNT IdaggregazioneEqualThis)
		{
			ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionTemp = ProgettoNaturaSoggettoDAL.Select(_dbProviderObj, IdprogettonaturasoggettoEqualThis, IdprogettoEqualThis, TiponaturasoggettoEqualThis, 
IdaggregazioneEqualThis);
			ProgettoNaturaSoggettoCollectionTemp.Provider = this;
			return ProgettoNaturaSoggettoCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoNaturaSoggettoCollection Find(IntNT IdprogettoEqualThis, StringNT TiponaturasoggettoEqualThis, IntNT IdaggregazioneEqualThis)
		{
			ProgettoNaturaSoggettoCollection ProgettoNaturaSoggettoCollectionTemp = ProgettoNaturaSoggettoDAL.Find(_dbProviderObj, IdprogettoEqualThis, TiponaturasoggettoEqualThis, IdaggregazioneEqualThis);
			ProgettoNaturaSoggettoCollectionTemp.Provider = this;
			return ProgettoNaturaSoggettoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_NATURA_SOGGETTO>
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
      <TIPO_NATURA_SOGGETTO>Equal</TIPO_NATURA_SOGGETTO>
      <ID_AGGREGAZIONE>Equal</ID_AGGREGAZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_NATURA_SOGGETTO>
*/
