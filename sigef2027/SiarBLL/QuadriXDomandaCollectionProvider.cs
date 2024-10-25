using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per QuadriXDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IQuadriXDomandaProvider
	{
		int Save(QuadriXDomanda QuadriXDomandaObj);
		int SaveCollection(QuadriXDomandaCollection collectionObj);
		int Delete(QuadriXDomanda QuadriXDomandaObj);
		int DeleteCollection(QuadriXDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for QuadriXDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class QuadriXDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdQuadro;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _MetodoReport;
		[NonSerialized] private IQuadriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IQuadriXDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public QuadriXDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_QUADRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdQuadro
		{
			get { return _IdQuadro; }
			set {
				if (IdQuadro != value)
				{
					_IdQuadro = value;
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
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:METODO_REPORT
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT MetodoReport
		{
			get { return _MetodoReport; }
			set {
				if (MetodoReport != value)
				{
					_MetodoReport = value;
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
	/// Summary description for QuadriXDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class QuadriXDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private QuadriXDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((QuadriXDomanda) info.GetValue(i.ToString(),typeof(QuadriXDomanda)));
			}
		}

		//Costruttore
		public QuadriXDomandaCollection()
		{
			this.ItemType = typeof(QuadriXDomanda);
		}

		//Costruttore con provider
		public QuadriXDomandaCollection(IQuadriXDomandaProvider providerObj)
		{
			this.ItemType = typeof(QuadriXDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new QuadriXDomanda this[int index]
		{
			get { return (QuadriXDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new QuadriXDomandaCollection GetChanges()
		{
			return (QuadriXDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IQuadriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IQuadriXDomandaProvider Provider
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
		public int Add(QuadriXDomanda QuadriXDomandaObj)
		{
			if (QuadriXDomandaObj.Provider == null) QuadriXDomandaObj.Provider = this.Provider;
			return base.Add(QuadriXDomandaObj);
		}

		//AddCollection
		public void AddCollection(QuadriXDomandaCollection QuadriXDomandaCollectionObj)
		{
			foreach (QuadriXDomanda QuadriXDomandaObj in QuadriXDomandaCollectionObj)
				this.Add(QuadriXDomandaObj);
		}

		//Insert
		public void Insert(int index, QuadriXDomanda QuadriXDomandaObj)
		{
			if (QuadriXDomandaObj.Provider == null) QuadriXDomandaObj.Provider = this.Provider;
			base.Insert(index, QuadriXDomandaObj);
		}

		//CollectionGetById
		public QuadriXDomanda CollectionGetById(NullTypes.IntNT IdQuadroValue, NullTypes.IntNT IdDomandaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdQuadro == IdQuadroValue) && (this[i].IdDomanda == IdDomandaValue))
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
		public QuadriXDomandaCollection SubSelect(NullTypes.IntNT IdQuadroEqualThis, NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			QuadriXDomandaCollection QuadriXDomandaCollectionTemp = new QuadriXDomandaCollection();
			foreach (QuadriXDomanda QuadriXDomandaItem in this)
			{
				if (((IdQuadroEqualThis == null) || ((QuadriXDomandaItem.IdQuadro != null) && (QuadriXDomandaItem.IdQuadro.Value == IdQuadroEqualThis.Value))) && ((IdDomandaEqualThis == null) || ((QuadriXDomandaItem.IdDomanda != null) && (QuadriXDomandaItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((OrdineEqualThis == null) || ((QuadriXDomandaItem.Ordine != null) && (QuadriXDomandaItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					QuadriXDomandaCollectionTemp.Add(QuadriXDomandaItem);
				}
			}
			return QuadriXDomandaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for QuadriXDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class QuadriXDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, QuadriXDomanda QuadriXDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdQuadro", QuadriXDomandaObj.IdQuadro);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", QuadriXDomandaObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", QuadriXDomandaObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, QuadriXDomanda QuadriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZQuadriXDomandaInsert", new string[] {"IdQuadro", "IdDomanda", "Ordine", }, new string[] {"int", "int", "int", },"");
				CompileIUCmd(false, insertCmd,QuadriXDomandaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadriXDomandaObj.IsDirty = false;
				QuadriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, QuadriXDomanda QuadriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZQuadriXDomandaUpdate", new string[] {"IdQuadro", "IdDomanda", "Ordine", }, new string[] {"int", "int", "int", },"");
				CompileIUCmd(true, updateCmd,QuadriXDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadriXDomandaObj.IsDirty = false;
				QuadriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, QuadriXDomanda QuadriXDomandaObj)
		{
			switch (QuadriXDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, QuadriXDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, QuadriXDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,QuadriXDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, QuadriXDomandaCollection QuadriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZQuadriXDomandaUpdate", new string[] {"IdQuadro", "IdDomanda", "Ordine", }, new string[] {"int", "int", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZQuadriXDomandaInsert", new string[] {"IdQuadro", "IdDomanda", "Ordine", }, new string[] {"int", "int", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZQuadriXDomandaDelete", new string[] {"IdQuadro", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < QuadriXDomandaCollectionObj.Count; i++)
				{
					switch (QuadriXDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,QuadriXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,QuadriXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (QuadriXDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)QuadriXDomandaCollectionObj[i].IdQuadro);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)QuadriXDomandaCollectionObj[i].IdDomanda);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < QuadriXDomandaCollectionObj.Count; i++)
				{
					if ((QuadriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (QuadriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						QuadriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						QuadriXDomandaCollectionObj[i].IsDirty = false;
						QuadriXDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((QuadriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						QuadriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						QuadriXDomandaCollectionObj[i].IsDirty = false;
						QuadriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, QuadriXDomanda QuadriXDomandaObj)
		{
			int returnValue = 0;
			if (QuadriXDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, QuadriXDomandaObj.IdQuadro, QuadriXDomandaObj.IdDomanda);
			}
			QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			QuadriXDomandaObj.IsDirty = false;
			QuadriXDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdQuadroValue, int IdDomandaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZQuadriXDomandaDelete", new string[] {"IdQuadro", "IdDomanda"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, QuadriXDomandaCollection QuadriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZQuadriXDomandaDelete", new string[] {"IdQuadro", "IdDomanda"}, new string[] {"int", "int"},"");
				for (int i = 0; i < QuadriXDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdQuadro", QuadriXDomandaCollectionObj[i].IdQuadro);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomanda", QuadriXDomandaCollectionObj[i].IdDomanda);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < QuadriXDomandaCollectionObj.Count; i++)
				{
					if ((QuadriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (QuadriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						QuadriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						QuadriXDomandaCollectionObj[i].IsDirty = false;
						QuadriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static QuadriXDomanda GetById(DbProvider db, int IdQuadroValue, int IdDomandaValue)
		{
			QuadriXDomanda QuadriXDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZQuadriXDomandaGetById", new string[] {"IdQuadro", "IdDomanda"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdQuadro", (SiarLibrary.NullTypes.IntNT)IdQuadroValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomanda", (SiarLibrary.NullTypes.IntNT)IdDomandaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				QuadriXDomandaObj = GetFromDatareader(db);
				QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadriXDomandaObj.IsDirty = false;
				QuadriXDomandaObj.IsPersistent = true;
			}
			db.Close();
			return QuadriXDomandaObj;
		}

		//getFromDatareader
		public static QuadriXDomanda GetFromDatareader(DbProvider db)
		{
			QuadriXDomanda QuadriXDomandaObj = new QuadriXDomanda();
			QuadriXDomandaObj.IdQuadro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_QUADRO"]);
			QuadriXDomandaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			QuadriXDomandaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			QuadriXDomandaObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			QuadriXDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			QuadriXDomandaObj.MetodoReport = new SiarLibrary.NullTypes.StringNT(db.DataReader["METODO_REPORT"]);
			QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			QuadriXDomandaObj.IsDirty = false;
			QuadriXDomandaObj.IsPersistent = true;
			return QuadriXDomandaObj;
		}

		//Find Select

		public static QuadriXDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdQuadroEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			QuadriXDomandaCollection QuadriXDomandaCollectionObj = new QuadriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zquadrixdomandafindselect", new string[] {"IdQuadroequalthis", "IdDomandaequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdQuadroequalthis", IdQuadroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			QuadriXDomanda QuadriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				QuadriXDomandaObj = GetFromDatareader(db);
				QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadriXDomandaObj.IsDirty = false;
				QuadriXDomandaObj.IsPersistent = true;
				QuadriXDomandaCollectionObj.Add(QuadriXDomandaObj);
			}
			db.Close();
			return QuadriXDomandaCollectionObj;
		}

		//Find Find

		public static QuadriXDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdQuadroEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			QuadriXDomandaCollection QuadriXDomandaCollectionObj = new QuadriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zquadrixdomandafindfind", new string[] {"IdQuadroequalthis", "IdDomandaequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdQuadroequalthis", IdQuadroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			QuadriXDomanda QuadriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				QuadriXDomandaObj = GetFromDatareader(db);
				QuadriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				QuadriXDomandaObj.IsDirty = false;
				QuadriXDomandaObj.IsPersistent = true;
				QuadriXDomandaCollectionObj.Add(QuadriXDomandaObj);
			}
			db.Close();
			return QuadriXDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for QuadriXDomandaCollectionProvider:IQuadriXDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class QuadriXDomandaCollectionProvider : IQuadriXDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di QuadriXDomanda
		protected QuadriXDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public QuadriXDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new QuadriXDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public QuadriXDomandaCollectionProvider(IntNT IdquadroEqualThis, IntNT IddomandaEqualThis, IntNT OrdineEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdquadroEqualThis, IddomandaEqualThis, OrdineEqualThis);
		}

		//Costruttore3: ha in input quadrixdomandaCollectionObj - non popola la collection
		public QuadriXDomandaCollectionProvider(QuadriXDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public QuadriXDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new QuadriXDomandaCollection(this);
		}

		//Get e Set
		public QuadriXDomandaCollection CollectionObj
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
		public int SaveCollection(QuadriXDomandaCollection collectionObj)
		{
			return QuadriXDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(QuadriXDomanda quadrixdomandaObj)
		{
			return QuadriXDomandaDAL.Save(_dbProviderObj, quadrixdomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(QuadriXDomandaCollection collectionObj)
		{
			return QuadriXDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(QuadriXDomanda quadrixdomandaObj)
		{
			return QuadriXDomandaDAL.Delete(_dbProviderObj, quadrixdomandaObj);
		}

		//getById
		public QuadriXDomanda GetById(IntNT IdQuadroValue, IntNT IdDomandaValue)
		{
			QuadriXDomanda QuadriXDomandaTemp = QuadriXDomandaDAL.GetById(_dbProviderObj, IdQuadroValue, IdDomandaValue);
			if (QuadriXDomandaTemp!=null) QuadriXDomandaTemp.Provider = this;
			return QuadriXDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public QuadriXDomandaCollection Select(IntNT IdquadroEqualThis, IntNT IddomandaEqualThis, IntNT OrdineEqualThis)
		{
			QuadriXDomandaCollection QuadriXDomandaCollectionTemp = QuadriXDomandaDAL.Select(_dbProviderObj, IdquadroEqualThis, IddomandaEqualThis, OrdineEqualThis);
			QuadriXDomandaCollectionTemp.Provider = this;
			return QuadriXDomandaCollectionTemp;
		}

		//Find: popola la collection
		public QuadriXDomandaCollection Find(IntNT IdquadroEqualThis, IntNT IddomandaEqualThis, IntNT OrdineEqualThis)
		{
			QuadriXDomandaCollection QuadriXDomandaCollectionTemp = QuadriXDomandaDAL.Find(_dbProviderObj, IdquadroEqualThis, IddomandaEqualThis, OrdineEqualThis);
			QuadriXDomandaCollectionTemp.Provider = this;
			return QuadriXDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<QUADRI_X_DOMANDA>
  <ViewName>vQUADRIDOMANDA</ViewName>
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
      <ID_QUADRO>Equal</ID_QUADRO>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ORDINE>Equal</ORDINE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</QUADRI_X_DOMANDA>
*/
