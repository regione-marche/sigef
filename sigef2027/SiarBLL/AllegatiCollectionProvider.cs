using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Allegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAllegatiProvider
	{
		int Save(Allegati AllegatiObj);
		int SaveCollection(AllegatiCollection collectionObj);
		int Delete(Allegati AllegatiObj);
		int DeleteCollection(AllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Allegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Allegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _CodTipoEnteEmettitore;
		[NonSerialized] private IAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Allegati()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE_EMETTITORE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodTipoEnteEmettitore
		{
			get { return _CodTipoEnteEmettitore; }
			set {
				if (CodTipoEnteEmettitore != value)
				{
					_CodTipoEnteEmettitore = value;
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
	/// Summary description for AllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Allegati) info.GetValue(i.ToString(),typeof(Allegati)));
			}
		}

		//Costruttore
		public AllegatiCollection()
		{
			this.ItemType = typeof(Allegati);
		}

		//Costruttore con provider
		public AllegatiCollection(IAllegatiProvider providerObj)
		{
			this.ItemType = typeof(Allegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Allegati this[int index]
		{
			get { return (Allegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AllegatiCollection GetChanges()
		{
			return (AllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiProvider Provider
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
		public int Add(Allegati AllegatiObj)
		{
			if (AllegatiObj.Provider == null) AllegatiObj.Provider = this.Provider;
			return base.Add(AllegatiObj);
		}

		//AddCollection
		public void AddCollection(AllegatiCollection AllegatiCollectionObj)
		{
			foreach (Allegati AllegatiObj in AllegatiCollectionObj)
				this.Add(AllegatiObj);
		}

		//Insert
		public void Insert(int index, Allegati AllegatiObj)
		{
			if (AllegatiObj.Provider == null) AllegatiObj.Provider = this.Provider;
			base.Insert(index, AllegatiObj);
		}

		//CollectionGetById
		public Allegati CollectionGetById(NullTypes.IntNT IdAllegatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAllegato == IdAllegatoValue))
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
		public AllegatiCollection SubSelect(NullTypes.IntNT IdAllegatoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT MisuraEqualThis, 
NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT CodTipoEnteEmettitoreEqualThis)
		{
			AllegatiCollection AllegatiCollectionTemp = new AllegatiCollection();
			foreach (Allegati AllegatiItem in this)
			{
				if (((IdAllegatoEqualThis == null) || ((AllegatiItem.IdAllegato != null) && (AllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((AllegatiItem.Descrizione != null) && (AllegatiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((MisuraEqualThis == null) || ((AllegatiItem.Misura != null) && (AllegatiItem.Misura.Value == MisuraEqualThis.Value))) && 
((CodTipoEqualThis == null) || ((AllegatiItem.CodTipo != null) && (AllegatiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((CodTipoEnteEmettitoreEqualThis == null) || ((AllegatiItem.CodTipoEnteEmettitore != null) && (AllegatiItem.CodTipoEnteEmettitore.Value == CodTipoEnteEmettitoreEqualThis.Value))))
				{
					AllegatiCollectionTemp.Add(AllegatiItem);
				}
			}
			return AllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Allegati AllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", AllegatiObj.IdAllegato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", AllegatiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", AllegatiObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", AllegatiObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoEnteEmettitore", AllegatiObj.CodTipoEnteEmettitore);
		}
		//Insert
		private static int Insert(DbProvider db, Allegati AllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiInsert", new string[] {"Descrizione", "Misura", 
"CodTipo", "CodTipoEnteEmettitore"}, new string[] {"string", "string", 
"string", "string"},"");
				CompileIUCmd(false, insertCmd,AllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
				}
				AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiObj.IsDirty = false;
				AllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Allegati AllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiUpdate", new string[] {"IdAllegato", "Descrizione", "Misura", 
"CodTipo", "CodTipoEnteEmettitore"}, new string[] {"int", "string", "string", 
"string", "string"},"");
				CompileIUCmd(true, updateCmd,AllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiObj.IsDirty = false;
				AllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Allegati AllegatiObj)
		{
			switch (AllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AllegatiCollection AllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiUpdate", new string[] {"IdAllegato", "Descrizione", "Misura", 
"CodTipo", "CodTipoEnteEmettitore"}, new string[] {"int", "string", "string", 
"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiInsert", new string[] {"Descrizione", "Misura", 
"CodTipo", "CodTipoEnteEmettitore"}, new string[] {"string", "string", 
"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < AllegatiCollectionObj.Count; i++)
				{
					switch (AllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AllegatiCollectionObj[i].IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)AllegatiCollectionObj[i].IdAllegato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AllegatiCollectionObj.Count; i++)
				{
					if ((AllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AllegatiCollectionObj[i].IsDirty = false;
						AllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((AllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiCollectionObj[i].IsDirty = false;
						AllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Allegati AllegatiObj)
		{
			int returnValue = 0;
			if (AllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, AllegatiObj.IdAllegato);
			}
			AllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AllegatiObj.IsDirty = false;
			AllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAllegatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AllegatiCollection AllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiDelete", new string[] {"IdAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < AllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", AllegatiCollectionObj[i].IdAllegato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AllegatiCollectionObj.Count; i++)
				{
					if ((AllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiCollectionObj[i].IsDirty = false;
						AllegatiCollectionObj[i].IsPersistent = false;
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
		public static Allegati GetById(DbProvider db, int IdAllegatoValue)
		{
			Allegati AllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAllegatiGetById", new string[] {"IdAllegato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AllegatiObj = GetFromDatareader(db);
				AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiObj.IsDirty = false;
				AllegatiObj.IsPersistent = true;
			}
			db.Close();
			return AllegatiObj;
		}

		//getFromDatareader
		public static Allegati GetFromDatareader(DbProvider db)
		{
			Allegati AllegatiObj = new Allegati();
			AllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			AllegatiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			AllegatiObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			AllegatiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			AllegatiObj.CodTipoEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE_EMETTITORE"]);
			AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AllegatiObj.IsDirty = false;
			AllegatiObj.IsPersistent = true;
			return AllegatiObj;
		}

		//Find Select

		public static AllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEmettitoreEqualThis)

		{

			AllegatiCollection AllegatiCollectionObj = new AllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatifindselect", new string[] {"IdAllegatoequalthis", "Descrizioneequalthis", "Misuraequalthis", 
"CodTipoequalthis", "CodTipoEnteEmettitoreequalthis"}, new string[] {"int", "string", "string", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteEmettitoreequalthis", CodTipoEnteEmettitoreEqualThis);
			Allegati AllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiObj = GetFromDatareader(db);
				AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiObj.IsDirty = false;
				AllegatiObj.IsPersistent = true;
				AllegatiCollectionObj.Add(AllegatiObj);
			}
			db.Close();
			return AllegatiCollectionObj;
		}

		//Find Find

		public static AllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.StringNT MisuraLikeThis)

		{

			AllegatiCollection AllegatiCollectionObj = new AllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatifindfind", new string[] {"CodTipoequalthis", "Descrizionelikethis", "Misuralikethis"}, new string[] {"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuralikethis", MisuraLikeThis);
			Allegati AllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiObj = GetFromDatareader(db);
				AllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiObj.IsDirty = false;
				AllegatiObj.IsPersistent = true;
				AllegatiCollectionObj.Add(AllegatiObj);
			}
			db.Close();
			return AllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AllegatiCollectionProvider:IAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiCollectionProvider : IAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Allegati
		protected AllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public AllegatiCollectionProvider(StringNT CodtipoEqualThis, StringNT DescrizioneLikeThis, StringNT MisuraLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoEqualThis, DescrizioneLikeThis, MisuraLikeThis);
		}

		//Costruttore3: ha in input allegatiCollectionObj - non popola la collection
		public AllegatiCollectionProvider(AllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AllegatiCollection(this);
		}

		//Get e Set
		public AllegatiCollection CollectionObj
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
		public int SaveCollection(AllegatiCollection collectionObj)
		{
			return AllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Allegati allegatiObj)
		{
			return AllegatiDAL.Save(_dbProviderObj, allegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AllegatiCollection collectionObj)
		{
			return AllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Allegati allegatiObj)
		{
			return AllegatiDAL.Delete(_dbProviderObj, allegatiObj);
		}

		//getById
		public Allegati GetById(IntNT IdAllegatoValue)
		{
			Allegati AllegatiTemp = AllegatiDAL.GetById(_dbProviderObj, IdAllegatoValue);
			if (AllegatiTemp!=null) AllegatiTemp.Provider = this;
			return AllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AllegatiCollection Select(IntNT IdallegatoEqualThis, StringNT DescrizioneEqualThis, StringNT MisuraEqualThis, 
StringNT CodtipoEqualThis, StringNT CodtipoenteemettitoreEqualThis)
		{
			AllegatiCollection AllegatiCollectionTemp = AllegatiDAL.Select(_dbProviderObj, IdallegatoEqualThis, DescrizioneEqualThis, MisuraEqualThis, 
CodtipoEqualThis, CodtipoenteemettitoreEqualThis);
			AllegatiCollectionTemp.Provider = this;
			return AllegatiCollectionTemp;
		}

		//Find: popola la collection
		public AllegatiCollection Find(StringNT CodtipoEqualThis, StringNT DescrizioneLikeThis, StringNT MisuraLikeThis)
		{
			AllegatiCollection AllegatiCollectionTemp = AllegatiDAL.Find(_dbProviderObj, CodtipoEqualThis, DescrizioneLikeThis, MisuraLikeThis);
			AllegatiCollectionTemp.Provider = this;
			return AllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ALLEGATI>
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
    <Find OrderBy="ORDER BY MISURA">
      <COD_TIPO>Equal</COD_TIPO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ALLEGATI>
*/
