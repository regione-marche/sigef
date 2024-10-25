using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoRelazioneTecnica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoRelazioneTecnicaProvider
	{
		int Save(ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj);
		int SaveCollection(ProgettoRelazioneTecnicaCollection collectionObj);
		int Delete(ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj);
		int DeleteCollection(ProgettoRelazioneTecnicaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoRelazioneTecnica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoRelazioneTecnica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdParagrafo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Testo;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Titolo;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IProgettoRelazioneTecnicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoRelazioneTecnicaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoRelazioneTecnica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PARAGRAFO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdParagrafo
		{
			get { return _IdParagrafo; }
			set {
				if (IdParagrafo != value)
				{
					_IdParagrafo = value;
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
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Titolo
		{
			get { return _Titolo; }
			set {
				if (Titolo != value)
				{
					_Titolo = value;
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
	/// Summary description for ProgettoRelazioneTecnicaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoRelazioneTecnicaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoRelazioneTecnicaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoRelazioneTecnica) info.GetValue(i.ToString(),typeof(ProgettoRelazioneTecnica)));
			}
		}

		//Costruttore
		public ProgettoRelazioneTecnicaCollection()
		{
			this.ItemType = typeof(ProgettoRelazioneTecnica);
		}

		//Costruttore con provider
		public ProgettoRelazioneTecnicaCollection(IProgettoRelazioneTecnicaProvider providerObj)
		{
			this.ItemType = typeof(ProgettoRelazioneTecnica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoRelazioneTecnica this[int index]
		{
			get { return (ProgettoRelazioneTecnica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoRelazioneTecnicaCollection GetChanges()
		{
			return (ProgettoRelazioneTecnicaCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoRelazioneTecnicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoRelazioneTecnicaProvider Provider
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
		public int Add(ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			if (ProgettoRelazioneTecnicaObj.Provider == null) ProgettoRelazioneTecnicaObj.Provider = this.Provider;
			return base.Add(ProgettoRelazioneTecnicaObj);
		}

		//AddCollection
		public void AddCollection(ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionObj)
		{
			foreach (ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj in ProgettoRelazioneTecnicaCollectionObj)
				this.Add(ProgettoRelazioneTecnicaObj);
		}

		//Insert
		public void Insert(int index, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			if (ProgettoRelazioneTecnicaObj.Provider == null) ProgettoRelazioneTecnicaObj.Provider = this.Provider;
			base.Insert(index, ProgettoRelazioneTecnicaObj);
		}

		//CollectionGetById
		public ProgettoRelazioneTecnica CollectionGetById(NullTypes.IntNT IdParagrafoValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdParagrafo == IdParagrafoValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public ProgettoRelazioneTecnicaCollection SubSelect(NullTypes.IntNT IdParagrafoEqualThis, NullTypes.IntNT IdProgettoEqualThis)
		{
			ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionTemp = new ProgettoRelazioneTecnicaCollection();
			foreach (ProgettoRelazioneTecnica ProgettoRelazioneTecnicaItem in this)
			{
				if (((IdParagrafoEqualThis == null) || ((ProgettoRelazioneTecnicaItem.IdParagrafo != null) && (ProgettoRelazioneTecnicaItem.IdParagrafo.Value == IdParagrafoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoRelazioneTecnicaItem.IdProgetto != null) && (ProgettoRelazioneTecnicaItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
				{
					ProgettoRelazioneTecnicaCollectionTemp.Add(ProgettoRelazioneTecnicaItem);
				}
			}
			return ProgettoRelazioneTecnicaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoRelazioneTecnicaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoRelazioneTecnicaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdParagrafo", ProgettoRelazioneTecnicaObj.IdParagrafo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoRelazioneTecnicaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", ProgettoRelazioneTecnicaObj.Testo);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoRelazioneTecnicaInsert", new string[] {"IdParagrafo", "IdProgetto", "Testo", 
}, new string[] {"int", "int", "string", 
},"");
				CompileIUCmd(false, insertCmd,ProgettoRelazioneTecnicaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoRelazioneTecnicaObj.IsDirty = false;
				ProgettoRelazioneTecnicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoRelazioneTecnicaUpdate", new string[] {"IdParagrafo", "IdProgetto", "Testo", 
}, new string[] {"int", "int", "string", 
},"");
				CompileIUCmd(true, updateCmd,ProgettoRelazioneTecnicaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoRelazioneTecnicaObj.IsDirty = false;
				ProgettoRelazioneTecnicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			switch (ProgettoRelazioneTecnicaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoRelazioneTecnicaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoRelazioneTecnicaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoRelazioneTecnicaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoRelazioneTecnicaUpdate", new string[] {"IdParagrafo", "IdProgetto", "Testo", 
}, new string[] {"int", "int", "string", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoRelazioneTecnicaInsert", new string[] {"IdParagrafo", "IdProgetto", "Testo", 
}, new string[] {"int", "int", "string", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoRelazioneTecnicaDelete", new string[] {"IdParagrafo", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ProgettoRelazioneTecnicaCollectionObj.Count; i++)
				{
					switch (ProgettoRelazioneTecnicaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoRelazioneTecnicaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoRelazioneTecnicaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoRelazioneTecnicaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)ProgettoRelazioneTecnicaCollectionObj[i].IdParagrafo);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)ProgettoRelazioneTecnicaCollectionObj[i].IdProgetto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoRelazioneTecnicaCollectionObj.Count; i++)
				{
					if ((ProgettoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						ProgettoRelazioneTecnicaCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						ProgettoRelazioneTecnicaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj)
		{
			int returnValue = 0;
			if (ProgettoRelazioneTecnicaObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoRelazioneTecnicaObj.IdParagrafo, ProgettoRelazioneTecnicaObj.IdProgetto);
			}
			ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoRelazioneTecnicaObj.IsDirty = false;
			ProgettoRelazioneTecnicaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdParagrafoValue, int IdProgettoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoRelazioneTecnicaDelete", new string[] {"IdParagrafo", "IdProgetto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)IdParagrafoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoRelazioneTecnicaDelete", new string[] {"IdParagrafo", "IdProgetto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < ProgettoRelazioneTecnicaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", ProgettoRelazioneTecnicaCollectionObj[i].IdParagrafo);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProgetto", ProgettoRelazioneTecnicaCollectionObj[i].IdProgetto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoRelazioneTecnicaCollectionObj.Count; i++)
				{
					if ((ProgettoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						ProgettoRelazioneTecnicaCollectionObj[i].IsPersistent = false;
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
		public static ProgettoRelazioneTecnica GetById(DbProvider db, int IdParagrafoValue, int IdProgettoValue)
		{
			ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoRelazioneTecnicaGetById", new string[] {"IdParagrafo", "IdProgetto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)IdParagrafoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProgetto", (SiarLibrary.NullTypes.IntNT)IdProgettoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoRelazioneTecnicaObj = GetFromDatareader(db);
				ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoRelazioneTecnicaObj.IsDirty = false;
				ProgettoRelazioneTecnicaObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoRelazioneTecnicaObj;
		}

		//getFromDatareader
		public static ProgettoRelazioneTecnica GetFromDatareader(DbProvider db)
		{
			ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj = new ProgettoRelazioneTecnica();
			ProgettoRelazioneTecnicaObj.IdParagrafo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAGRAFO"]);
			ProgettoRelazioneTecnicaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoRelazioneTecnicaObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			ProgettoRelazioneTecnicaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettoRelazioneTecnicaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoRelazioneTecnicaObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			ProgettoRelazioneTecnicaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoRelazioneTecnicaObj.IsDirty = false;
			ProgettoRelazioneTecnicaObj.IsPersistent = true;
			return ProgettoRelazioneTecnicaObj;
		}

		//Find Select

		public static ProgettoRelazioneTecnicaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdParagrafoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionObj = new ProgettoRelazioneTecnicaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettorelazionetecnicafindselect", new string[] {"IdParagrafoequalthis", "IdProgettoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParagrafoequalthis", IdParagrafoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoRelazioneTecnicaObj = GetFromDatareader(db);
				ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoRelazioneTecnicaObj.IsDirty = false;
				ProgettoRelazioneTecnicaObj.IsPersistent = true;
				ProgettoRelazioneTecnicaCollectionObj.Add(ProgettoRelazioneTecnicaObj);
			}
			db.Close();
			return ProgettoRelazioneTecnicaCollectionObj;
		}

		//Find Find

		public static ProgettoRelazioneTecnicaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionObj = new ProgettoRelazioneTecnicaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettorelazionetecnicafindfind", new string[] {"IdProgettoequalthis", "IdBandoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			ProgettoRelazioneTecnica ProgettoRelazioneTecnicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoRelazioneTecnicaObj = GetFromDatareader(db);
				ProgettoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoRelazioneTecnicaObj.IsDirty = false;
				ProgettoRelazioneTecnicaObj.IsPersistent = true;
				ProgettoRelazioneTecnicaCollectionObj.Add(ProgettoRelazioneTecnicaObj);
			}
			db.Close();
			return ProgettoRelazioneTecnicaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoRelazioneTecnicaCollectionProvider:IProgettoRelazioneTecnicaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoRelazioneTecnicaCollectionProvider : IProgettoRelazioneTecnicaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoRelazioneTecnica
		protected ProgettoRelazioneTecnicaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoRelazioneTecnicaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoRelazioneTecnicaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoRelazioneTecnicaCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdbandoEqualThis);
		}

		//Costruttore3: ha in input progettorelazionetecnicaCollectionObj - non popola la collection
		public ProgettoRelazioneTecnicaCollectionProvider(ProgettoRelazioneTecnicaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoRelazioneTecnicaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoRelazioneTecnicaCollection(this);
		}

		//Get e Set
		public ProgettoRelazioneTecnicaCollection CollectionObj
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
		public int SaveCollection(ProgettoRelazioneTecnicaCollection collectionObj)
		{
			return ProgettoRelazioneTecnicaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoRelazioneTecnica progettorelazionetecnicaObj)
		{
			return ProgettoRelazioneTecnicaDAL.Save(_dbProviderObj, progettorelazionetecnicaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoRelazioneTecnicaCollection collectionObj)
		{
			return ProgettoRelazioneTecnicaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoRelazioneTecnica progettorelazionetecnicaObj)
		{
			return ProgettoRelazioneTecnicaDAL.Delete(_dbProviderObj, progettorelazionetecnicaObj);
		}

		//getById
		public ProgettoRelazioneTecnica GetById(IntNT IdParagrafoValue, IntNT IdProgettoValue)
		{
			ProgettoRelazioneTecnica ProgettoRelazioneTecnicaTemp = ProgettoRelazioneTecnicaDAL.GetById(_dbProviderObj, IdParagrafoValue, IdProgettoValue);
			if (ProgettoRelazioneTecnicaTemp!=null) ProgettoRelazioneTecnicaTemp.Provider = this;
			return ProgettoRelazioneTecnicaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoRelazioneTecnicaCollection Select(IntNT IdparagrafoEqualThis, IntNT IdprogettoEqualThis)
		{
			ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionTemp = ProgettoRelazioneTecnicaDAL.Select(_dbProviderObj, IdparagrafoEqualThis, IdprogettoEqualThis);
			ProgettoRelazioneTecnicaCollectionTemp.Provider = this;
			return ProgettoRelazioneTecnicaCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoRelazioneTecnicaCollection Find(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis)
		{
			ProgettoRelazioneTecnicaCollection ProgettoRelazioneTecnicaCollectionTemp = ProgettoRelazioneTecnicaDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis);
			ProgettoRelazioneTecnicaCollectionTemp.Provider = this;
			return ProgettoRelazioneTecnicaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_RELAZIONE_TECNICA>
  <ViewName>vPROGETTO_RELAZIONE_TECNICA</ViewName>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_RELAZIONE_TECNICA>
*/
