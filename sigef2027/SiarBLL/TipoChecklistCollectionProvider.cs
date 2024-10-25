using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TipoChecklist
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITipoChecklistProvider
	{
		int Save(TipoChecklist TipoChecklistObj);
		int SaveCollection(TipoChecklistCollection collectionObj);
		int Delete(TipoChecklist TipoChecklistObj);
		int DeleteCollection(TipoChecklistCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TipoChecklist
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TipoChecklist: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTipo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _ContieneVoci;
		private NullTypes.BoolNT _Scheda;
		[NonSerialized] private ITipoChecklistProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoChecklistProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TipoChecklist()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TIPO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipo
		{
			get { return _IdTipo; }
			set {
				if (IdTipo != value)
				{
					_IdTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVoci
		{
			get { return _ContieneVoci; }
			set {
				if (ContieneVoci != value)
				{
					_ContieneVoci = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Scheda
		{
			get { return _Scheda; }
			set {
				if (Scheda != value)
				{
					_Scheda = value;
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
	/// Summary description for TipoChecklistCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoChecklistCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoChecklistCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoChecklist) info.GetValue(i.ToString(),typeof(TipoChecklist)));
			}
		}

		//Costruttore
		public TipoChecklistCollection()
		{
			this.ItemType = typeof(TipoChecklist);
		}

		//Costruttore con provider
		public TipoChecklistCollection(ITipoChecklistProvider providerObj)
		{
			this.ItemType = typeof(TipoChecklist);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoChecklist this[int index]
		{
			get { return (TipoChecklist)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoChecklistCollection GetChanges()
		{
			return (TipoChecklistCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoChecklistProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoChecklistProvider Provider
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
		public int Add(TipoChecklist TipoChecklistObj)
		{
			if (TipoChecklistObj.Provider == null) TipoChecklistObj.Provider = this.Provider;
			return base.Add(TipoChecklistObj);
		}

		//AddCollection
		public void AddCollection(TipoChecklistCollection TipoChecklistCollectionObj)
		{
			foreach (TipoChecklist TipoChecklistObj in TipoChecklistCollectionObj)
				this.Add(TipoChecklistObj);
		}

		//Insert
		public void Insert(int index, TipoChecklist TipoChecklistObj)
		{
			if (TipoChecklistObj.Provider == null) TipoChecklistObj.Provider = this.Provider;
			base.Insert(index, TipoChecklistObj);
		}

		//CollectionGetById
		public TipoChecklist CollectionGetById(NullTypes.IntNT IdTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTipo == IdTipoValue))
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
		public TipoChecklistCollection SubSelect(NullTypes.IntNT IdTipoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT ContieneVociEqualThis, 
NullTypes.BoolNT SchedaEqualThis)
		{
			TipoChecklistCollection TipoChecklistCollectionTemp = new TipoChecklistCollection();
			foreach (TipoChecklist TipoChecklistItem in this)
			{
				if (((IdTipoEqualThis == null) || ((TipoChecklistItem.IdTipo != null) && (TipoChecklistItem.IdTipo.Value == IdTipoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoChecklistItem.Descrizione != null) && (TipoChecklistItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ContieneVociEqualThis == null) || ((TipoChecklistItem.ContieneVoci != null) && (TipoChecklistItem.ContieneVoci.Value == ContieneVociEqualThis.Value))) && 
((SchedaEqualThis == null) || ((TipoChecklistItem.Scheda != null) && (TipoChecklistItem.Scheda.Value == SchedaEqualThis.Value))))
				{
					TipoChecklistCollectionTemp.Add(TipoChecklistItem);
				}
			}
			return TipoChecklistCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TipoChecklistDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TipoChecklistDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TipoChecklist TipoChecklistObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTipo", TipoChecklistObj.IdTipo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", TipoChecklistObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "ContieneVoci", TipoChecklistObj.ContieneVoci);
			DbProvider.SetCmdParam(cmd,firstChar + "Scheda", TipoChecklistObj.Scheda);
		}
		//Insert
		private static int Insert(DbProvider db, TipoChecklist TipoChecklistObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTipoChecklistInsert", new string[] {"Descrizione", "ContieneVoci", 
"Scheda"}, new string[] {"string", "bool", 
"bool"},"");
				CompileIUCmd(false, insertCmd,TipoChecklistObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TipoChecklistObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
				}
				TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoChecklistObj.IsDirty = false;
				TipoChecklistObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TipoChecklist TipoChecklistObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoChecklistUpdate", new string[] {"IdTipo", "Descrizione", "ContieneVoci", 
"Scheda"}, new string[] {"int", "string", "bool", 
"bool"},"");
				CompileIUCmd(true, updateCmd,TipoChecklistObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoChecklistObj.IsDirty = false;
				TipoChecklistObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TipoChecklist TipoChecklistObj)
		{
			switch (TipoChecklistObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TipoChecklistObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TipoChecklistObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TipoChecklistObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TipoChecklistCollection TipoChecklistCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTipoChecklistUpdate", new string[] {"IdTipo", "Descrizione", "ContieneVoci", 
"Scheda"}, new string[] {"int", "string", "bool", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTipoChecklistInsert", new string[] {"Descrizione", "ContieneVoci", 
"Scheda"}, new string[] {"string", "bool", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTipoChecklistDelete", new string[] {"IdTipo"}, new string[] {"int"},"");
				for (int i = 0; i < TipoChecklistCollectionObj.Count; i++)
				{
					switch (TipoChecklistCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TipoChecklistCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TipoChecklistCollectionObj[i].IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TipoChecklistCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TipoChecklistCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)TipoChecklistCollectionObj[i].IdTipo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TipoChecklistCollectionObj.Count; i++)
				{
					if ((TipoChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TipoChecklistCollectionObj[i].IsDirty = false;
						TipoChecklistCollectionObj[i].IsPersistent = true;
					}
					if ((TipoChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TipoChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoChecklistCollectionObj[i].IsDirty = false;
						TipoChecklistCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TipoChecklist TipoChecklistObj)
		{
			int returnValue = 0;
			if (TipoChecklistObj.IsPersistent) 
			{
				returnValue = Delete(db, TipoChecklistObj.IdTipo);
			}
			TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TipoChecklistObj.IsDirty = false;
			TipoChecklistObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTipoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoChecklistDelete", new string[] {"IdTipo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)IdTipoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TipoChecklistCollection TipoChecklistCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTipoChecklistDelete", new string[] {"IdTipo"}, new string[] {"int"},"");
				for (int i = 0; i < TipoChecklistCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipo", TipoChecklistCollectionObj[i].IdTipo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TipoChecklistCollectionObj.Count; i++)
				{
					if ((TipoChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TipoChecklistCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TipoChecklistCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TipoChecklistCollectionObj[i].IsDirty = false;
						TipoChecklistCollectionObj[i].IsPersistent = false;
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
		public static TipoChecklist GetById(DbProvider db, int IdTipoValue)
		{
			TipoChecklist TipoChecklistObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTipoChecklistGetById", new string[] {"IdTipo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTipo", (SiarLibrary.NullTypes.IntNT)IdTipoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TipoChecklistObj = GetFromDatareader(db);
				TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoChecklistObj.IsDirty = false;
				TipoChecklistObj.IsPersistent = true;
			}
			db.Close();
			return TipoChecklistObj;
		}

		//getFromDatareader
		public static TipoChecklist GetFromDatareader(DbProvider db)
		{
			TipoChecklist TipoChecklistObj = new TipoChecklist();
			TipoChecklistObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
			TipoChecklistObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			TipoChecklistObj.ContieneVoci = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI"]);
			TipoChecklistObj.Scheda = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA"]);
			TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TipoChecklistObj.IsDirty = false;
			TipoChecklistObj.IsPersistent = true;
			return TipoChecklistObj;
		}

		//Find Select

		public static TipoChecklistCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT ContieneVociEqualThis, 
SiarLibrary.NullTypes.BoolNT SchedaEqualThis)

		{

			TipoChecklistCollection TipoChecklistCollectionObj = new TipoChecklistCollection();

			IDbCommand findCmd = db.InitCmd("Ztipochecklistfindselect", new string[] {"IdTipoequalthis", "Descrizioneequalthis", "ContieneVociequalthis", 
"Schedaequalthis"}, new string[] {"int", "string", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContieneVociequalthis", ContieneVociEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Schedaequalthis", SchedaEqualThis);
			TipoChecklist TipoChecklistObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoChecklistObj = GetFromDatareader(db);
				TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoChecklistObj.IsDirty = false;
				TipoChecklistObj.IsPersistent = true;
				TipoChecklistCollectionObj.Add(TipoChecklistObj);
			}
			db.Close();
			return TipoChecklistCollectionObj;
		}

		//Find FindTipo

		public static TipoChecklistCollection FindTipo(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT ContieneVociEqualThis, 
SiarLibrary.NullTypes.BoolNT SchedaEqualThis)

		{

			TipoChecklistCollection TipoChecklistCollectionObj = new TipoChecklistCollection();

			IDbCommand findCmd = db.InitCmd("Ztipochecklistfindfindtipo", new string[] {"IdTipoequalthis", "Descrizioneequalthis", "ContieneVociequalthis", 
"Schedaequalthis"}, new string[] {"int", "string", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContieneVociequalthis", ContieneVociEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Schedaequalthis", SchedaEqualThis);
			TipoChecklist TipoChecklistObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TipoChecklistObj = GetFromDatareader(db);
				TipoChecklistObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TipoChecklistObj.IsDirty = false;
				TipoChecklistObj.IsPersistent = true;
				TipoChecklistCollectionObj.Add(TipoChecklistObj);
			}
			db.Close();
			return TipoChecklistCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoChecklistCollectionProvider:ITipoChecklistProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TipoChecklistCollectionProvider : ITipoChecklistProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoChecklist
		protected TipoChecklistCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoChecklistCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoChecklistCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoChecklistCollectionProvider(IntNT IdtipoEqualThis, StringNT DescrizioneEqualThis, BoolNT ContienevociEqualThis, 
BoolNT SchedaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindTipo(IdtipoEqualThis, DescrizioneEqualThis, ContienevociEqualThis, 
SchedaEqualThis);
		}

		//Costruttore3: ha in input tipochecklistCollectionObj - non popola la collection
		public TipoChecklistCollectionProvider(TipoChecklistCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoChecklistCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoChecklistCollection(this);
		}

		//Get e Set
		public TipoChecklistCollection CollectionObj
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
		public int SaveCollection(TipoChecklistCollection collectionObj)
		{
			return TipoChecklistDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoChecklist tipochecklistObj)
		{
			return TipoChecklistDAL.Save(_dbProviderObj, tipochecklistObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoChecklistCollection collectionObj)
		{
			return TipoChecklistDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoChecklist tipochecklistObj)
		{
			return TipoChecklistDAL.Delete(_dbProviderObj, tipochecklistObj);
		}

		//getById
		public TipoChecklist GetById(IntNT IdTipoValue)
		{
			TipoChecklist TipoChecklistTemp = TipoChecklistDAL.GetById(_dbProviderObj, IdTipoValue);
			if (TipoChecklistTemp!=null) TipoChecklistTemp.Provider = this;
			return TipoChecklistTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoChecklistCollection Select(IntNT IdtipoEqualThis, StringNT DescrizioneEqualThis, BoolNT ContienevociEqualThis, 
BoolNT SchedaEqualThis)
		{
			TipoChecklistCollection TipoChecklistCollectionTemp = TipoChecklistDAL.Select(_dbProviderObj, IdtipoEqualThis, DescrizioneEqualThis, ContienevociEqualThis, 
SchedaEqualThis);
			TipoChecklistCollectionTemp.Provider = this;
			return TipoChecklistCollectionTemp;
		}

		//FindTipo: popola la collection
		public TipoChecklistCollection FindTipo(IntNT IdtipoEqualThis, StringNT DescrizioneEqualThis, BoolNT ContienevociEqualThis, 
BoolNT SchedaEqualThis)
		{
			TipoChecklistCollection TipoChecklistCollectionTemp = TipoChecklistDAL.FindTipo(_dbProviderObj, IdtipoEqualThis, DescrizioneEqualThis, ContienevociEqualThis, 
SchedaEqualThis);
			TipoChecklistCollectionTemp.Provider = this;
			return TipoChecklistCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CHECKLIST>
  <ViewName>VTIPO_CHECKLIST</ViewName>
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
    <FindTipo OrderBy="ORDER BY ">
      <ID_TIPO>Equal</ID_TIPO>
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <CONTIENE_VOCI>Equal</CONTIENE_VOCI>
      <SCHEDA>Equal</SCHEDA>
    </FindTipo>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CHECKLIST>
*/
