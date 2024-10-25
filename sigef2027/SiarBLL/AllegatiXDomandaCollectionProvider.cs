using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AllegatiXDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAllegatiXDomandaProvider
	{
		int Save(AllegatiXDomanda AllegatiXDomandaObj);
		int SaveCollection(AllegatiXDomandaCollection collectionObj);
		int Delete(AllegatiXDomanda AllegatiXDomandaObj);
		int DeleteCollection(AllegatiXDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AllegatiXDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AllegatiXDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _TipoAllegato;
		[NonSerialized] private IAllegatiXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiXDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AllegatiXDomanda()
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
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
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
		/// Corrisponde al campo:TIPO_ALLEGATO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT TipoAllegato
		{
			get { return _TipoAllegato; }
			set {
				if (TipoAllegato != value)
				{
					_TipoAllegato = value;
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
	/// Summary description for AllegatiXDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiXDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AllegatiXDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AllegatiXDomanda) info.GetValue(i.ToString(),typeof(AllegatiXDomanda)));
			}
		}

		//Costruttore
		public AllegatiXDomandaCollection()
		{
			this.ItemType = typeof(AllegatiXDomanda);
		}

		//Costruttore con provider
		public AllegatiXDomandaCollection(IAllegatiXDomandaProvider providerObj)
		{
			this.ItemType = typeof(AllegatiXDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AllegatiXDomanda this[int index]
		{
			get { return (AllegatiXDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AllegatiXDomandaCollection GetChanges()
		{
			return (AllegatiXDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IAllegatiXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAllegatiXDomandaProvider Provider
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
		public int Add(AllegatiXDomanda AllegatiXDomandaObj)
		{
			if (AllegatiXDomandaObj.Provider == null) AllegatiXDomandaObj.Provider = this.Provider;
			return base.Add(AllegatiXDomandaObj);
		}

		//AddCollection
		public void AddCollection(AllegatiXDomandaCollection AllegatiXDomandaCollectionObj)
		{
			foreach (AllegatiXDomanda AllegatiXDomandaObj in AllegatiXDomandaCollectionObj)
				this.Add(AllegatiXDomandaObj);
		}

		//Insert
		public void Insert(int index, AllegatiXDomanda AllegatiXDomandaObj)
		{
			if (AllegatiXDomandaObj.Provider == null) AllegatiXDomandaObj.Provider = this.Provider;
			base.Insert(index, AllegatiXDomandaObj);
		}

		//CollectionGetById
		public AllegatiXDomanda CollectionGetById(NullTypes.IntNT IdAllegatoValue, NullTypes.IntNT IdDomandaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAllegato == IdAllegatoValue) && (this[i].IdDomanda == IdDomandaValue))
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
		public AllegatiXDomandaCollection SubSelect(NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			AllegatiXDomandaCollection AllegatiXDomandaCollectionTemp = new AllegatiXDomandaCollection();
			foreach (AllegatiXDomanda AllegatiXDomandaItem in this)
			{
				if (((IdAllegatoEqualThis == null) || ((AllegatiXDomandaItem.IdAllegato != null) && (AllegatiXDomandaItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdDomandaEqualThis == null) || ((AllegatiXDomandaItem.IdDomanda != null) && (AllegatiXDomandaItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((OrdineEqualThis == null) || ((AllegatiXDomandaItem.Ordine != null) && (AllegatiXDomandaItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					AllegatiXDomandaCollectionTemp.Add(AllegatiXDomandaItem);
				}
			}
			return AllegatiXDomandaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AllegatiXDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AllegatiXDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AllegatiXDomanda AllegatiXDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", AllegatiXDomandaObj.IdAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", AllegatiXDomandaObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", AllegatiXDomandaObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, AllegatiXDomanda AllegatiXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiXDomandaInsert", new string[] {"IdAllegato", "IdDomanda", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(false, insertCmd,AllegatiXDomandaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiXDomandaObj.IsDirty = false;
				AllegatiXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AllegatiXDomanda AllegatiXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiXDomandaUpdate", new string[] {"IdAllegato", "IdDomanda", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				CompileIUCmd(true, updateCmd,AllegatiXDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiXDomandaObj.IsDirty = false;
				AllegatiXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AllegatiXDomanda AllegatiXDomandaObj)
		{
			switch (AllegatiXDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AllegatiXDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AllegatiXDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AllegatiXDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AllegatiXDomandaCollection AllegatiXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAllegatiXDomandaUpdate", new string[] {"IdAllegato", "IdDomanda", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZAllegatiXDomandaInsert", new string[] {"IdAllegato", "IdDomanda", "Ordine", 
}, new string[] {"int", "int", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiXDomandaDelete", new string[] {"IdAllegato", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < AllegatiXDomandaCollectionObj.Count; i++)
				{
					switch (AllegatiXDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AllegatiXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AllegatiXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AllegatiXDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)AllegatiXDomandaCollectionObj[i].IdAllegato);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)AllegatiXDomandaCollectionObj[i].IdDomanda);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AllegatiXDomandaCollectionObj.Count; i++)
				{
					if ((AllegatiXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AllegatiXDomandaCollectionObj[i].IsDirty = false;
						AllegatiXDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((AllegatiXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AllegatiXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiXDomandaCollectionObj[i].IsDirty = false;
						AllegatiXDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AllegatiXDomanda AllegatiXDomandaObj)
		{
			int returnValue = 0;
			if (AllegatiXDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, AllegatiXDomandaObj.IdAllegato, AllegatiXDomandaObj.IdDomanda);
			}
			AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AllegatiXDomandaObj.IsDirty = false;
			AllegatiXDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAllegatoValue, int IdDomandaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiXDomandaDelete", new string[] {"IdAllegato", "IdDomanda"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AllegatiXDomandaCollection AllegatiXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAllegatiXDomandaDelete", new string[] {"IdAllegato", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < AllegatiXDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAllegato", AllegatiXDomandaCollectionObj[i].IdAllegato);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", AllegatiXDomandaCollectionObj[i].IdDomanda);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AllegatiXDomandaCollectionObj.Count; i++)
				{
					if ((AllegatiXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AllegatiXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AllegatiXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AllegatiXDomandaCollectionObj[i].IsDirty = false;
						AllegatiXDomandaCollectionObj[i].IsPersistent = false;
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
		public static AllegatiXDomanda GetById(DbProvider db, int IdAllegatoValue, int IdDomandaValue)
		{
			AllegatiXDomanda AllegatiXDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAllegatiXDomandaGetById", new string[] {"IdAllegato", "IdDomanda"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AllegatiXDomandaObj = GetFromDatareader(db);
				AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiXDomandaObj.IsDirty = false;
				AllegatiXDomandaObj.IsPersistent = true;
			}
			db.Close();
			return AllegatiXDomandaObj;
		}

		//getFromDatareader
		public static AllegatiXDomanda GetFromDatareader(DbProvider db)
		{
			AllegatiXDomanda AllegatiXDomandaObj = new AllegatiXDomanda();
			AllegatiXDomandaObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			AllegatiXDomandaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			AllegatiXDomandaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			AllegatiXDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			AllegatiXDomandaObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			AllegatiXDomandaObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			AllegatiXDomandaObj.TipoAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ALLEGATO"]);
			AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AllegatiXDomandaObj.IsDirty = false;
			AllegatiXDomandaObj.IsPersistent = true;
			return AllegatiXDomandaObj;
		}

		//Find Select

		public static AllegatiXDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			AllegatiXDomandaCollection AllegatiXDomandaCollectionObj = new AllegatiXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatixdomandafindselect", new string[] {"IdAllegatoequalthis", "IdDomandaequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			AllegatiXDomanda AllegatiXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiXDomandaObj = GetFromDatareader(db);
				AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiXDomandaObj.IsDirty = false;
				AllegatiXDomandaObj.IsPersistent = true;
				AllegatiXDomandaCollectionObj.Add(AllegatiXDomandaObj);
			}
			db.Close();
			return AllegatiXDomandaCollectionObj;
		}

		//Find Find

		public static AllegatiXDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis)

		{

			AllegatiXDomandaCollection AllegatiXDomandaCollectionObj = new AllegatiXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zallegatixdomandafindfind", new string[] {"IdAllegatoequalthis", "IdDomandaequalthis", "CodTipoequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			AllegatiXDomanda AllegatiXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AllegatiXDomandaObj = GetFromDatareader(db);
				AllegatiXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AllegatiXDomandaObj.IsDirty = false;
				AllegatiXDomandaObj.IsPersistent = true;
				AllegatiXDomandaCollectionObj.Add(AllegatiXDomandaObj);
			}
			db.Close();
			return AllegatiXDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AllegatiXDomandaCollectionProvider:IAllegatiXDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AllegatiXDomandaCollectionProvider : IAllegatiXDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AllegatiXDomanda
		protected AllegatiXDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AllegatiXDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AllegatiXDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public AllegatiXDomandaCollectionProvider(IntNT IdallegatoEqualThis, IntNT IddomandaEqualThis, StringNT CodtipoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdallegatoEqualThis, IddomandaEqualThis, CodtipoEqualThis);
		}

		//Costruttore3: ha in input allegatixdomandaCollectionObj - non popola la collection
		public AllegatiXDomandaCollectionProvider(AllegatiXDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AllegatiXDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AllegatiXDomandaCollection(this);
		}

		//Get e Set
		public AllegatiXDomandaCollection CollectionObj
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
		public int SaveCollection(AllegatiXDomandaCollection collectionObj)
		{
			return AllegatiXDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AllegatiXDomanda allegatixdomandaObj)
		{
			return AllegatiXDomandaDAL.Save(_dbProviderObj, allegatixdomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AllegatiXDomandaCollection collectionObj)
		{
			return AllegatiXDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AllegatiXDomanda allegatixdomandaObj)
		{
			return AllegatiXDomandaDAL.Delete(_dbProviderObj, allegatixdomandaObj);
		}

		//getById
		public AllegatiXDomanda GetById(IntNT IdAllegatoValue, IntNT IdDomandaValue)
		{
			AllegatiXDomanda AllegatiXDomandaTemp = AllegatiXDomandaDAL.GetById(_dbProviderObj, IdAllegatoValue, IdDomandaValue);
			if (AllegatiXDomandaTemp!=null) AllegatiXDomandaTemp.Provider = this;
			return AllegatiXDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AllegatiXDomandaCollection Select(IntNT IdallegatoEqualThis, IntNT IddomandaEqualThis, IntNT OrdineEqualThis)
		{
			AllegatiXDomandaCollection AllegatiXDomandaCollectionTemp = AllegatiXDomandaDAL.Select(_dbProviderObj, IdallegatoEqualThis, IddomandaEqualThis, OrdineEqualThis);
			AllegatiXDomandaCollectionTemp.Provider = this;
			return AllegatiXDomandaCollectionTemp;
		}

		//Find: popola la collection
		public AllegatiXDomandaCollection Find(IntNT IdallegatoEqualThis, IntNT IddomandaEqualThis, StringNT CodtipoEqualThis)
		{
			AllegatiXDomandaCollection AllegatiXDomandaCollectionTemp = AllegatiXDomandaDAL.Find(_dbProviderObj, IdallegatoEqualThis, IddomandaEqualThis, CodtipoEqualThis);
			AllegatiXDomandaCollectionTemp.Provider = this;
			return AllegatiXDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ALLEGATI_X_DOMANDA>
  <ViewName>vALLEGATI_X_DOMANDA</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ALLEGATI_X_DOMANDA>
*/
