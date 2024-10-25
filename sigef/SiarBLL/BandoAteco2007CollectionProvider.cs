using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoAteco2007
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoAteco2007Provider
	{
		int Save(BandoAteco2007 BandoAteco2007Obj);
		int SaveCollection(BandoAteco2007Collection collectionObj);
		int Delete(BandoAteco2007 BandoAteco2007Obj);
		int DeleteCollection(BandoAteco2007Collection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoAteco2007
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoAteco2007 : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _IdAteco2007;
		private NullTypes.StringNT _Sezione;
		private NullTypes.StringNT _Divisione;
		private NullTypes.StringNT _Gruppo;
		private NullTypes.StringNT _Classe;
		private NullTypes.StringNT _Categoria;
		private NullTypes.StringNT _Sottocategoria;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Eliminato;
		[NonSerialized] private IBandoAteco2007Provider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IBandoAteco2007Provider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public BandoAteco2007()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set
			{
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATECO2007
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT IdAteco2007
		{
			get { return _IdAteco2007; }
			set
			{
				if (IdAteco2007 != value)
				{
					_IdAteco2007 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Sezione
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Sezione
		{
			get { return _Sezione; }
			set
			{
				if (Sezione != value)
				{
					_Sezione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Divisione
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Divisione
		{
			get { return _Divisione; }
			set
			{
				if (Divisione != value)
				{
					_Divisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Gruppo
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Gruppo
		{
			get { return _Gruppo; }
			set
			{
				if (Gruppo != value)
				{
					_Gruppo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Classe
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Classe
		{
			get { return _Classe; }
			set
			{
				if (Classe != value)
				{
					_Classe = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Categoria
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Categoria
		{
			get { return _Categoria; }
			set
			{
				if (Categoria != value)
				{
					_Categoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Sottocategoria
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT Sottocategoria
		{
			get { return _Sottocategoria; }
			set
			{
				if (Sottocategoria != value)
				{
					_Sottocategoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Descrizione
		/// Tipo sul db:NVARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set
			{
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ELIMINATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Eliminato
		{
			get { return _Eliminato; }
			set
			{
				if (Eliminato != value)
				{
					_Eliminato = value;
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
	/// Summary description for BandoAteco2007Collection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoAteco2007Collection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoAteco2007Collection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((BandoAteco2007)info.GetValue(i.ToString(), typeof(BandoAteco2007)));
			}
		}

		//Costruttore
		public BandoAteco2007Collection()
		{
			this.ItemType = typeof(BandoAteco2007);
		}

		//Costruttore con provider
		public BandoAteco2007Collection(IBandoAteco2007Provider providerObj)
		{
			this.ItemType = typeof(BandoAteco2007);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoAteco2007 this[int index]
		{
			get { return (BandoAteco2007)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoAteco2007Collection GetChanges()
		{
			return (BandoAteco2007Collection)base.GetChanges();
		}

		[NonSerialized] private IBandoAteco2007Provider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IBandoAteco2007Provider Provider
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
		public int Add(BandoAteco2007 BandoAteco2007Obj)
		{
			if (BandoAteco2007Obj.Provider == null) BandoAteco2007Obj.Provider = this.Provider;
			return base.Add(BandoAteco2007Obj);
		}

		//AddCollection
		public void AddCollection(BandoAteco2007Collection BandoAteco2007CollectionObj)
		{
			foreach (BandoAteco2007 BandoAteco2007Obj in BandoAteco2007CollectionObj)
				this.Add(BandoAteco2007Obj);
		}

		//Insert
		public void Insert(int index, BandoAteco2007 BandoAteco2007Obj)
		{
			if (BandoAteco2007Obj.Provider == null) BandoAteco2007Obj.Provider = this.Provider;
			base.Insert(index, BandoAteco2007Obj);
		}

		//CollectionGetById
		public BandoAteco2007 CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.StringNT IdAteco2007Value)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdAteco2007 == IdAteco2007Value))
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
		public BandoAteco2007Collection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT IdAteco2007EqualThis)
		{
			BandoAteco2007Collection BandoAteco2007CollectionTemp = new BandoAteco2007Collection();
			foreach (BandoAteco2007 BandoAteco2007Item in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoAteco2007Item.IdBando != null) && (BandoAteco2007Item.IdBando.Value == IdBandoEqualThis.Value))) && ((IdAteco2007EqualThis == null) || ((BandoAteco2007Item.IdAteco2007 != null) && (BandoAteco2007Item.IdAteco2007.Value == IdAteco2007EqualThis.Value))))
				{
					BandoAteco2007CollectionTemp.Add(BandoAteco2007Item);
				}
			}
			return BandoAteco2007CollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoAteco2007DAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoAteco2007DAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoAteco2007 BandoAteco2007Obj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", BandoAteco2007Obj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdAteco2007", BandoAteco2007Obj.IdAteco2007);
		}
		//Insert
		private static int Insert(DbProvider db, BandoAteco2007 BandoAteco2007Obj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZBandoAteco2007Insert", new string[] {"IdBando", "IdAteco2007",

}, new string[] {"int", "string",

}, "");
				CompileIUCmd(false, insertCmd, BandoAteco2007Obj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoAteco2007Obj.IsDirty = false;
				BandoAteco2007Obj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoAteco2007 BandoAteco2007Obj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZBandoAteco2007Update", new string[] {"IdBando", "IdAteco2007",

}, new string[] {"int", "string",

}, "");
				CompileIUCmd(true, updateCmd, BandoAteco2007Obj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoAteco2007Obj.IsDirty = false;
				BandoAteco2007Obj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoAteco2007 BandoAteco2007Obj)
		{
			switch (BandoAteco2007Obj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, BandoAteco2007Obj);
				case BaseObject.ObjectStateType.Changed: return Update(db, BandoAteco2007Obj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, BandoAteco2007Obj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoAteco2007Collection BandoAteco2007CollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZBandoAteco2007Update", new string[] {"IdBando", "IdAteco2007",

}, new string[] {"int", "string",

}, "");
				IDbCommand insertCmd = db.InitCmd("ZBandoAteco2007Insert", new string[] {"IdBando", "IdAteco2007",

}, new string[] {"int", "string",

}, "");
				IDbCommand deleteCmd = db.InitCmd("ZBandoAteco2007Delete", new string[] { "IdBando", "IdAteco2007" }, new string[] { "int", "string" }, "");
				for (int i = 0; i < BandoAteco2007CollectionObj.Count; i++)
				{
					switch (BandoAteco2007CollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, BandoAteco2007CollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, BandoAteco2007CollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (BandoAteco2007CollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoAteco2007CollectionObj[i].IdBando);
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAteco2007", (SiarLibrary.NullTypes.StringNT)BandoAteco2007CollectionObj[i].IdAteco2007);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoAteco2007CollectionObj.Count; i++)
				{
					if ((BandoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoAteco2007CollectionObj[i].IsDirty = false;
						BandoAteco2007CollectionObj[i].IsPersistent = true;
					}
					if ((BandoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoAteco2007CollectionObj[i].IsDirty = false;
						BandoAteco2007CollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoAteco2007 BandoAteco2007Obj)
		{
			int returnValue = 0;
			if (BandoAteco2007Obj.IsPersistent)
			{
				returnValue = Delete(db, BandoAteco2007Obj.IdBando, BandoAteco2007Obj.IdAteco2007);
			}
			BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoAteco2007Obj.IsDirty = false;
			BandoAteco2007Obj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdBandoValue, string IdAteco2007Value)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZBandoAteco2007Delete", new string[] { "IdBando", "IdAteco2007" }, new string[] { "int", "string" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAteco2007", (SiarLibrary.NullTypes.StringNT)IdAteco2007Value);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoAteco2007Collection BandoAteco2007CollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZBandoAteco2007Delete", new string[] { "IdBando", "IdAteco2007" }, new string[] { "int", "string" }, "");
				for (int i = 0; i < BandoAteco2007CollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", BandoAteco2007CollectionObj[i].IdBando);
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAteco2007", BandoAteco2007CollectionObj[i].IdAteco2007);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoAteco2007CollectionObj.Count; i++)
				{
					if ((BandoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoAteco2007CollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoAteco2007CollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoAteco2007CollectionObj[i].IsDirty = false;
						BandoAteco2007CollectionObj[i].IsPersistent = false;
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
		public static BandoAteco2007 GetById(DbProvider db, int IdBandoValue, string IdAteco2007Value)
		{
			BandoAteco2007 BandoAteco2007Obj = null;
			IDbCommand readCmd = db.InitCmd("ZBandoAteco2007GetById", new string[] { "IdBando", "IdAteco2007" }, new string[] { "int", "string" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdAteco2007", (SiarLibrary.NullTypes.StringNT)IdAteco2007Value);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoAteco2007Obj = GetFromDatareader(db);
				BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoAteco2007Obj.IsDirty = false;
				BandoAteco2007Obj.IsPersistent = true;
			}
			db.Close();
			return BandoAteco2007Obj;
		}

		//getFromDatareader
		public static BandoAteco2007 GetFromDatareader(DbProvider db)
		{
			BandoAteco2007 BandoAteco2007Obj = new BandoAteco2007();
			BandoAteco2007Obj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoAteco2007Obj.IdAteco2007 = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_ATECO2007"]);
			BandoAteco2007Obj.Sezione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sezione"]);
			BandoAteco2007Obj.Divisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Divisione"]);
			BandoAteco2007Obj.Gruppo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Gruppo"]);
			BandoAteco2007Obj.Classe = new SiarLibrary.NullTypes.StringNT(db.DataReader["Classe"]);
			BandoAteco2007Obj.Categoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Categoria"]);
			BandoAteco2007Obj.Sottocategoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["Sottocategoria"]);
			BandoAteco2007Obj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Descrizione"]);
			BandoAteco2007Obj.Eliminato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ELIMINATO"]);
			BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoAteco2007Obj.IsDirty = false;
			BandoAteco2007Obj.IsPersistent = true;
			return BandoAteco2007Obj;
		}

		//Find Select

		public static BandoAteco2007Collection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT IdAteco2007EqualThis)

		{

			BandoAteco2007Collection BandoAteco2007CollectionObj = new BandoAteco2007Collection();

			IDbCommand findCmd = db.InitCmd("Zbandoateco2007findselect", new string[] { "IdBandoequalthis", "IdAteco2007equalthis" }, new string[] { "int", "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAteco2007equalthis", IdAteco2007EqualThis);
			BandoAteco2007 BandoAteco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoAteco2007Obj = GetFromDatareader(db);
				BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoAteco2007Obj.IsDirty = false;
				BandoAteco2007Obj.IsPersistent = true;
				BandoAteco2007CollectionObj.Add(BandoAteco2007Obj);
			}
			db.Close();
			return BandoAteco2007CollectionObj;
		}

		//Find Find

		public static BandoAteco2007Collection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT IdAteco2007EqualThis)

		{

			BandoAteco2007Collection BandoAteco2007CollectionObj = new BandoAteco2007Collection();

			IDbCommand findCmd = db.InitCmd("Zbandoateco2007findfind", new string[] { "IdBandoequalthis", "IdAteco2007equalthis" }, new string[] { "int", "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAteco2007equalthis", IdAteco2007EqualThis);
			BandoAteco2007 BandoAteco2007Obj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoAteco2007Obj = GetFromDatareader(db);
				BandoAteco2007Obj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoAteco2007Obj.IsDirty = false;
				BandoAteco2007Obj.IsPersistent = true;
				BandoAteco2007CollectionObj.Add(BandoAteco2007Obj);
			}
			db.Close();
			return BandoAteco2007CollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoAteco2007CollectionProvider:IBandoAteco2007Provider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoAteco2007CollectionProvider : IBandoAteco2007Provider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoAteco2007
		protected BandoAteco2007Collection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoAteco2007CollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoAteco2007Collection(this);
		}

		//Costruttore 2: popola la collection
		public BandoAteco2007CollectionProvider(IntNT IdbandoEqualThis, StringNT Idateco2007EqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, Idateco2007EqualThis);
		}

		//Costruttore3: ha in input bandoateco2007CollectionObj - non popola la collection
		public BandoAteco2007CollectionProvider(BandoAteco2007Collection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoAteco2007CollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoAteco2007Collection(this);
		}

		//Get e Set
		public BandoAteco2007Collection CollectionObj
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
		public int SaveCollection(BandoAteco2007Collection collectionObj)
		{
			return BandoAteco2007DAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoAteco2007 bandoateco2007Obj)
		{
			return BandoAteco2007DAL.Save(_dbProviderObj, bandoateco2007Obj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoAteco2007Collection collectionObj)
		{
			return BandoAteco2007DAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoAteco2007 bandoateco2007Obj)
		{
			return BandoAteco2007DAL.Delete(_dbProviderObj, bandoateco2007Obj);
		}

		//getById
		public BandoAteco2007 GetById(IntNT IdBandoValue, StringNT IdAteco2007Value)
		{
			BandoAteco2007 BandoAteco2007Temp = BandoAteco2007DAL.GetById(_dbProviderObj, IdBandoValue, IdAteco2007Value);
			if (BandoAteco2007Temp != null) BandoAteco2007Temp.Provider = this;
			return BandoAteco2007Temp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoAteco2007Collection Select(IntNT IdbandoEqualThis, StringNT Idateco2007EqualThis)
		{
			BandoAteco2007Collection BandoAteco2007CollectionTemp = BandoAteco2007DAL.Select(_dbProviderObj, IdbandoEqualThis, Idateco2007EqualThis);
			BandoAteco2007CollectionTemp.Provider = this;
			return BandoAteco2007CollectionTemp;
		}

		//Find: popola la collection
		public BandoAteco2007Collection Find(IntNT IdbandoEqualThis, StringNT Idateco2007EqualThis)
		{
			BandoAteco2007Collection BandoAteco2007CollectionTemp = BandoAteco2007DAL.Find(_dbProviderObj, IdbandoEqualThis, Idateco2007EqualThis);
			BandoAteco2007CollectionTemp.Provider = this;
			return BandoAteco2007CollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_ATECO2007>
  <ViewName>vBANDO_ATECO2007</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_ATECO2007>Equal</ID_ATECO2007>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_ATECO2007>
*/
