using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoRelazioneTecnica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoRelazioneTecnicaProvider
	{
		int Save(BandoRelazioneTecnica BandoRelazioneTecnicaObj);
		int SaveCollection(BandoRelazioneTecnicaCollection collectionObj);
		int Delete(BandoRelazioneTecnica BandoRelazioneTecnicaObj);
		int DeleteCollection(BandoRelazioneTecnicaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoRelazioneTecnica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoRelazioneTecnica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdParagrafo;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Titolo;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IBandoRelazioneTecnicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRelazioneTecnicaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoRelazioneTecnica()
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
		/// Default:((0))
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
	/// Summary description for BandoRelazioneTecnicaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoRelazioneTecnicaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoRelazioneTecnicaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoRelazioneTecnica) info.GetValue(i.ToString(),typeof(BandoRelazioneTecnica)));
			}
		}

		//Costruttore
		public BandoRelazioneTecnicaCollection()
		{
			this.ItemType = typeof(BandoRelazioneTecnica);
		}

		//Costruttore con provider
		public BandoRelazioneTecnicaCollection(IBandoRelazioneTecnicaProvider providerObj)
		{
			this.ItemType = typeof(BandoRelazioneTecnica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoRelazioneTecnica this[int index]
		{
			get { return (BandoRelazioneTecnica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoRelazioneTecnicaCollection GetChanges()
		{
			return (BandoRelazioneTecnicaCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoRelazioneTecnicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRelazioneTecnicaProvider Provider
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
		public int Add(BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			if (BandoRelazioneTecnicaObj.Provider == null) BandoRelazioneTecnicaObj.Provider = this.Provider;
			return base.Add(BandoRelazioneTecnicaObj);
		}

		//AddCollection
		public void AddCollection(BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionObj)
		{
			foreach (BandoRelazioneTecnica BandoRelazioneTecnicaObj in BandoRelazioneTecnicaCollectionObj)
				this.Add(BandoRelazioneTecnicaObj);
		}

		//Insert
		public void Insert(int index, BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			if (BandoRelazioneTecnicaObj.Provider == null) BandoRelazioneTecnicaObj.Provider = this.Provider;
			base.Insert(index, BandoRelazioneTecnicaObj);
		}

		//CollectionGetById
		public BandoRelazioneTecnica CollectionGetById(NullTypes.IntNT IdParagrafoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdParagrafo == IdParagrafoValue))
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
		public BandoRelazioneTecnicaCollection SubSelect(NullTypes.IntNT IdParagrafoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT TitoloEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionTemp = new BandoRelazioneTecnicaCollection();
			foreach (BandoRelazioneTecnica BandoRelazioneTecnicaItem in this)
			{
				if (((IdParagrafoEqualThis == null) || ((BandoRelazioneTecnicaItem.IdParagrafo != null) && (BandoRelazioneTecnicaItem.IdParagrafo.Value == IdParagrafoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoRelazioneTecnicaItem.IdBando != null) && (BandoRelazioneTecnicaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((BandoRelazioneTecnicaItem.Descrizione != null) && (BandoRelazioneTecnicaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((TitoloEqualThis == null) || ((BandoRelazioneTecnicaItem.Titolo != null) && (BandoRelazioneTecnicaItem.Titolo.Value == TitoloEqualThis.Value))) && ((OrdineEqualThis == null) || ((BandoRelazioneTecnicaItem.Ordine != null) && (BandoRelazioneTecnicaItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					BandoRelazioneTecnicaCollectionTemp.Add(BandoRelazioneTecnicaItem);
				}
			}
			return BandoRelazioneTecnicaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoRelazioneTecnicaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoRelazioneTecnicaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoRelazioneTecnica BandoRelazioneTecnicaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdParagrafo", BandoRelazioneTecnicaObj.IdParagrafo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoRelazioneTecnicaObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", BandoRelazioneTecnicaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Titolo", BandoRelazioneTecnicaObj.Titolo);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", BandoRelazioneTecnicaObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoRelazioneTecnicaInsert", new string[] {"IdBando", "Descrizione", 
"Titolo", "Ordine"}, new string[] {"int", "string", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,BandoRelazioneTecnicaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoRelazioneTecnicaObj.IdParagrafo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAGRAFO"]);
				BandoRelazioneTecnicaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
				}
				BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRelazioneTecnicaObj.IsDirty = false;
				BandoRelazioneTecnicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRelazioneTecnicaUpdate", new string[] {"IdParagrafo", "IdBando", "Descrizione", 
"Titolo", "Ordine"}, new string[] {"int", "int", "string", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,BandoRelazioneTecnicaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRelazioneTecnicaObj.IsDirty = false;
				BandoRelazioneTecnicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			switch (BandoRelazioneTecnicaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoRelazioneTecnicaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoRelazioneTecnicaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoRelazioneTecnicaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoRelazioneTecnicaUpdate", new string[] {"IdParagrafo", "IdBando", "Descrizione", 
"Titolo", "Ordine"}, new string[] {"int", "int", "string", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoRelazioneTecnicaInsert", new string[] {"IdBando", "Descrizione", 
"Titolo", "Ordine"}, new string[] {"int", "string", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRelazioneTecnicaDelete", new string[] {"IdParagrafo"}, new string[] {"int"},"");
				for (int i = 0; i < BandoRelazioneTecnicaCollectionObj.Count; i++)
				{
					switch (BandoRelazioneTecnicaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoRelazioneTecnicaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoRelazioneTecnicaCollectionObj[i].IdParagrafo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAGRAFO"]);
									BandoRelazioneTecnicaCollectionObj[i].Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoRelazioneTecnicaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoRelazioneTecnicaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)BandoRelazioneTecnicaCollectionObj[i].IdParagrafo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoRelazioneTecnicaCollectionObj.Count; i++)
				{
					if ((BandoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						BandoRelazioneTecnicaCollectionObj[i].IsPersistent = true;
					}
					if ((BandoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						BandoRelazioneTecnicaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoRelazioneTecnica BandoRelazioneTecnicaObj)
		{
			int returnValue = 0;
			if (BandoRelazioneTecnicaObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoRelazioneTecnicaObj.IdParagrafo);
			}
			BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoRelazioneTecnicaObj.IsDirty = false;
			BandoRelazioneTecnicaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdParagrafoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRelazioneTecnicaDelete", new string[] {"IdParagrafo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)IdParagrafoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoRelazioneTecnicaDelete", new string[] {"IdParagrafo"}, new string[] {"int"},"");
				for (int i = 0; i < BandoRelazioneTecnicaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdParagrafo", BandoRelazioneTecnicaCollectionObj[i].IdParagrafo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoRelazioneTecnicaCollectionObj.Count; i++)
				{
					if ((BandoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoRelazioneTecnicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoRelazioneTecnicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoRelazioneTecnicaCollectionObj[i].IsDirty = false;
						BandoRelazioneTecnicaCollectionObj[i].IsPersistent = false;
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
		public static BandoRelazioneTecnica GetById(DbProvider db, int IdParagrafoValue)
		{
			BandoRelazioneTecnica BandoRelazioneTecnicaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoRelazioneTecnicaGetById", new string[] {"IdParagrafo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdParagrafo", (SiarLibrary.NullTypes.IntNT)IdParagrafoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoRelazioneTecnicaObj = GetFromDatareader(db);
				BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRelazioneTecnicaObj.IsDirty = false;
				BandoRelazioneTecnicaObj.IsPersistent = true;
			}
			db.Close();
			return BandoRelazioneTecnicaObj;
		}

		//getFromDatareader
		public static BandoRelazioneTecnica GetFromDatareader(DbProvider db)
		{
			BandoRelazioneTecnica BandoRelazioneTecnicaObj = new BandoRelazioneTecnica();
			BandoRelazioneTecnicaObj.IdParagrafo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAGRAFO"]);
			BandoRelazioneTecnicaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoRelazioneTecnicaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoRelazioneTecnicaObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			BandoRelazioneTecnicaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoRelazioneTecnicaObj.IsDirty = false;
			BandoRelazioneTecnicaObj.IsPersistent = true;
			return BandoRelazioneTecnicaObj;
		}

		//Find Select

		public static BandoRelazioneTecnicaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdParagrafoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT TitoloEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionObj = new BandoRelazioneTecnicaCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorelazionetecnicafindselect", new string[] {"IdParagrafoequalthis", "IdBandoequalthis", "Descrizioneequalthis", 
"Titoloequalthis", "Ordineequalthis"}, new string[] {"int", "int", "string", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParagrafoequalthis", IdParagrafoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BandoRelazioneTecnica BandoRelazioneTecnicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRelazioneTecnicaObj = GetFromDatareader(db);
				BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRelazioneTecnicaObj.IsDirty = false;
				BandoRelazioneTecnicaObj.IsPersistent = true;
				BandoRelazioneTecnicaCollectionObj.Add(BandoRelazioneTecnicaObj);
			}
			db.Close();
			return BandoRelazioneTecnicaCollectionObj;
		}

		//Find Find

		public static BandoRelazioneTecnicaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionObj = new BandoRelazioneTecnicaCollection();

			IDbCommand findCmd = db.InitCmd("Zbandorelazionetecnicafindfind", new string[] {"IdBandoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			BandoRelazioneTecnica BandoRelazioneTecnicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoRelazioneTecnicaObj = GetFromDatareader(db);
				BandoRelazioneTecnicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoRelazioneTecnicaObj.IsDirty = false;
				BandoRelazioneTecnicaObj.IsPersistent = true;
				BandoRelazioneTecnicaCollectionObj.Add(BandoRelazioneTecnicaObj);
			}
			db.Close();
			return BandoRelazioneTecnicaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoRelazioneTecnicaCollectionProvider:IBandoRelazioneTecnicaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoRelazioneTecnicaCollectionProvider : IBandoRelazioneTecnicaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoRelazioneTecnica
		protected BandoRelazioneTecnicaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoRelazioneTecnicaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoRelazioneTecnicaCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoRelazioneTecnicaCollectionProvider(IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis);
		}

		//Costruttore3: ha in input bandorelazionetecnicaCollectionObj - non popola la collection
		public BandoRelazioneTecnicaCollectionProvider(BandoRelazioneTecnicaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoRelazioneTecnicaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoRelazioneTecnicaCollection(this);
		}

		//Get e Set
		public BandoRelazioneTecnicaCollection CollectionObj
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
		public int SaveCollection(BandoRelazioneTecnicaCollection collectionObj)
		{
			return BandoRelazioneTecnicaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoRelazioneTecnica bandorelazionetecnicaObj)
		{
			return BandoRelazioneTecnicaDAL.Save(_dbProviderObj, bandorelazionetecnicaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoRelazioneTecnicaCollection collectionObj)
		{
			return BandoRelazioneTecnicaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoRelazioneTecnica bandorelazionetecnicaObj)
		{
			return BandoRelazioneTecnicaDAL.Delete(_dbProviderObj, bandorelazionetecnicaObj);
		}

		//getById
		public BandoRelazioneTecnica GetById(IntNT IdParagrafoValue)
		{
			BandoRelazioneTecnica BandoRelazioneTecnicaTemp = BandoRelazioneTecnicaDAL.GetById(_dbProviderObj, IdParagrafoValue);
			if (BandoRelazioneTecnicaTemp!=null) BandoRelazioneTecnicaTemp.Provider = this;
			return BandoRelazioneTecnicaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoRelazioneTecnicaCollection Select(IntNT IdparagrafoEqualThis, IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, 
StringNT TitoloEqualThis, IntNT OrdineEqualThis)
		{
			BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionTemp = BandoRelazioneTecnicaDAL.Select(_dbProviderObj, IdparagrafoEqualThis, IdbandoEqualThis, DescrizioneEqualThis, 
TitoloEqualThis, OrdineEqualThis);
			BandoRelazioneTecnicaCollectionTemp.Provider = this;
			return BandoRelazioneTecnicaCollectionTemp;
		}

		//Find: popola la collection
		public BandoRelazioneTecnicaCollection Find(IntNT IdbandoEqualThis)
		{
			BandoRelazioneTecnicaCollection BandoRelazioneTecnicaCollectionTemp = BandoRelazioneTecnicaDAL.Find(_dbProviderObj, IdbandoEqualThis);
			BandoRelazioneTecnicaCollectionTemp.Provider = this;
			return BandoRelazioneTecnicaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_RELAZIONE_TECNICA>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_RELAZIONE_TECNICA>
*/
