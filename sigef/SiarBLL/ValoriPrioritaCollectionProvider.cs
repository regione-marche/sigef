using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ValoriPriorita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IValoriPrioritaProvider
	{
		int Save(ValoriPriorita ValoriPrioritaObj);
		int SaveCollection(ValoriPrioritaCollection collectionObj);
		int Delete(ValoriPriorita ValoriPrioritaObj);
		int DeleteCollection(ValoriPrioritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ValoriPriorita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ValoriPriorita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdValore;
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Codice;
		private NullTypes.DecimalNT _Punteggio;
		[NonSerialized] private IValoriPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IValoriPrioritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ValoriPriorita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VALORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValore
		{
			get { return _IdValore; }
			set {
				if (IdValore != value)
				{
					_IdValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
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
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
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
	/// Summary description for ValoriPrioritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ValoriPrioritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ValoriPrioritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ValoriPriorita) info.GetValue(i.ToString(),typeof(ValoriPriorita)));
			}
		}

		//Costruttore
		public ValoriPrioritaCollection()
		{
			this.ItemType = typeof(ValoriPriorita);
		}

		//Costruttore con provider
		public ValoriPrioritaCollection(IValoriPrioritaProvider providerObj)
		{
			this.ItemType = typeof(ValoriPriorita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ValoriPriorita this[int index]
		{
			get { return (ValoriPriorita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ValoriPrioritaCollection GetChanges()
		{
			return (ValoriPrioritaCollection) base.GetChanges();
		}

		[NonSerialized] private IValoriPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IValoriPrioritaProvider Provider
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
		public int Add(ValoriPriorita ValoriPrioritaObj)
		{
			if (ValoriPrioritaObj.Provider == null) ValoriPrioritaObj.Provider = this.Provider;
			return base.Add(ValoriPrioritaObj);
		}

		//AddCollection
		public void AddCollection(ValoriPrioritaCollection ValoriPrioritaCollectionObj)
		{
			foreach (ValoriPriorita ValoriPrioritaObj in ValoriPrioritaCollectionObj)
				this.Add(ValoriPrioritaObj);
		}

		//Insert
		public void Insert(int index, ValoriPriorita ValoriPrioritaObj)
		{
			if (ValoriPrioritaObj.Provider == null) ValoriPrioritaObj.Provider = this.Provider;
			base.Insert(index, ValoriPrioritaObj);
		}

		//CollectionGetById
		public ValoriPriorita CollectionGetById(NullTypes.IntNT IdValoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdValore == IdValoreValue))
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
		public ValoriPrioritaCollection SubSelect(NullTypes.IntNT IdValoreEqualThis, NullTypes.IntNT IdPrioritaEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT CodiceEqualThis, NullTypes.DecimalNT PunteggioEqualThis)
		{
			ValoriPrioritaCollection ValoriPrioritaCollectionTemp = new ValoriPrioritaCollection();
			foreach (ValoriPriorita ValoriPrioritaItem in this)
			{
				if (((IdValoreEqualThis == null) || ((ValoriPrioritaItem.IdValore != null) && (ValoriPrioritaItem.IdValore.Value == IdValoreEqualThis.Value))) && ((IdPrioritaEqualThis == null) || ((ValoriPrioritaItem.IdPriorita != null) && (ValoriPrioritaItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ValoriPrioritaItem.Descrizione != null) && (ValoriPrioritaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((CodiceEqualThis == null) || ((ValoriPrioritaItem.Codice != null) && (ValoriPrioritaItem.Codice.Value == CodiceEqualThis.Value))) && ((PunteggioEqualThis == null) || ((ValoriPrioritaItem.Punteggio != null) && (ValoriPrioritaItem.Punteggio.Value == PunteggioEqualThis.Value))))
				{
					ValoriPrioritaCollectionTemp.Add(ValoriPrioritaItem);
				}
			}
			return ValoriPrioritaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ValoriPrioritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ValoriPrioritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ValoriPriorita ValoriPrioritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdValore", ValoriPrioritaObj.IdValore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", ValoriPrioritaObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ValoriPrioritaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ValoriPrioritaObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", ValoriPrioritaObj.Punteggio);
		}
		//Insert
		private static int Insert(DbProvider db, ValoriPriorita ValoriPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZValoriPrioritaInsert", new string[] {"IdPriorita", "Descrizione", 
"Codice", "Punteggio"}, new string[] {"int", "string", 
"string", "decimal"},"");
				CompileIUCmd(false, insertCmd,ValoriPrioritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ValoriPrioritaObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
				}
				ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ValoriPrioritaObj.IsDirty = false;
				ValoriPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ValoriPriorita ValoriPrioritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZValoriPrioritaUpdate", new string[] {"IdValore", "IdPriorita", "Descrizione", 
"Codice", "Punteggio"}, new string[] {"int", "int", "string", 
"string", "decimal"},"");
				CompileIUCmd(true, updateCmd,ValoriPrioritaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ValoriPrioritaObj.IsDirty = false;
				ValoriPrioritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ValoriPriorita ValoriPrioritaObj)
		{
			switch (ValoriPrioritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ValoriPrioritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ValoriPrioritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ValoriPrioritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ValoriPrioritaCollection ValoriPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZValoriPrioritaUpdate", new string[] {"IdValore", "IdPriorita", "Descrizione", 
"Codice", "Punteggio"}, new string[] {"int", "int", "string", 
"string", "decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZValoriPrioritaInsert", new string[] {"IdPriorita", "Descrizione", 
"Codice", "Punteggio"}, new string[] {"int", "string", 
"string", "decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZValoriPrioritaDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				for (int i = 0; i < ValoriPrioritaCollectionObj.Count; i++)
				{
					switch (ValoriPrioritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ValoriPrioritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ValoriPrioritaCollectionObj[i].IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ValoriPrioritaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ValoriPrioritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)ValoriPrioritaCollectionObj[i].IdValore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ValoriPrioritaCollectionObj.Count; i++)
				{
					if ((ValoriPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ValoriPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ValoriPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ValoriPrioritaCollectionObj[i].IsDirty = false;
						ValoriPrioritaCollectionObj[i].IsPersistent = true;
					}
					if ((ValoriPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ValoriPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ValoriPrioritaCollectionObj[i].IsDirty = false;
						ValoriPrioritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ValoriPriorita ValoriPrioritaObj)
		{
			int returnValue = 0;
			if (ValoriPrioritaObj.IsPersistent) 
			{
				returnValue = Delete(db, ValoriPrioritaObj.IdValore);
			}
			ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ValoriPrioritaObj.IsDirty = false;
			ValoriPrioritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZValoriPrioritaDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)IdValoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ValoriPrioritaCollection ValoriPrioritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZValoriPrioritaDelete", new string[] {"IdValore"}, new string[] {"int"},"");
				for (int i = 0; i < ValoriPrioritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValore", ValoriPrioritaCollectionObj[i].IdValore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ValoriPrioritaCollectionObj.Count; i++)
				{
					if ((ValoriPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ValoriPrioritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ValoriPrioritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ValoriPrioritaCollectionObj[i].IsDirty = false;
						ValoriPrioritaCollectionObj[i].IsPersistent = false;
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
		public static ValoriPriorita GetById(DbProvider db, int IdValoreValue)
		{
			ValoriPriorita ValoriPrioritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZValoriPrioritaGetById", new string[] {"IdValore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdValore", (SiarLibrary.NullTypes.IntNT)IdValoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ValoriPrioritaObj = GetFromDatareader(db);
				ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ValoriPrioritaObj.IsDirty = false;
				ValoriPrioritaObj.IsPersistent = true;
			}
			db.Close();
			return ValoriPrioritaObj;
		}

		//getFromDatareader
		public static ValoriPriorita GetFromDatareader(DbProvider db)
		{
			ValoriPriorita ValoriPrioritaObj = new ValoriPriorita();
			ValoriPrioritaObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			ValoriPrioritaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			ValoriPrioritaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ValoriPrioritaObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ValoriPrioritaObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ValoriPrioritaObj.IsDirty = false;
			ValoriPrioritaObj.IsPersistent = true;
			return ValoriPrioritaObj;
		}

		//Find Select

		public static ValoriPrioritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis)

		{

			ValoriPrioritaCollection ValoriPrioritaCollectionObj = new ValoriPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zvaloriprioritafindselect", new string[] {"IdValoreequalthis", "IdPrioritaequalthis", "Descrizioneequalthis", 
"Codiceequalthis", "Punteggioequalthis"}, new string[] {"int", "int", "string", 
"string", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			ValoriPriorita ValoriPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ValoriPrioritaObj = GetFromDatareader(db);
				ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ValoriPrioritaObj.IsDirty = false;
				ValoriPrioritaObj.IsPersistent = true;
				ValoriPrioritaCollectionObj.Add(ValoriPrioritaObj);
			}
			db.Close();
			return ValoriPrioritaCollectionObj;
		}

		//Find Find

		public static ValoriPrioritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis)

		{

			ValoriPrioritaCollection ValoriPrioritaCollectionObj = new ValoriPrioritaCollection();

			IDbCommand findCmd = db.InitCmd("Zvaloriprioritafindfind", new string[] {"IdValoreequalthis", "IdPrioritaequalthis", "Codiceequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			ValoriPriorita ValoriPrioritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ValoriPrioritaObj = GetFromDatareader(db);
				ValoriPrioritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ValoriPrioritaObj.IsDirty = false;
				ValoriPrioritaObj.IsPersistent = true;
				ValoriPrioritaCollectionObj.Add(ValoriPrioritaObj);
			}
			db.Close();
			return ValoriPrioritaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ValoriPrioritaCollectionProvider:IValoriPrioritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ValoriPrioritaCollectionProvider : IValoriPrioritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ValoriPriorita
		protected ValoriPrioritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ValoriPrioritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ValoriPrioritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ValoriPrioritaCollectionProvider(IntNT IdvaloreEqualThis, IntNT IdprioritaEqualThis, StringNT CodiceEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvaloreEqualThis, IdprioritaEqualThis, CodiceEqualThis);
		}

		//Costruttore3: ha in input valoriprioritaCollectionObj - non popola la collection
		public ValoriPrioritaCollectionProvider(ValoriPrioritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ValoriPrioritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ValoriPrioritaCollection(this);
		}

		//Get e Set
		public ValoriPrioritaCollection CollectionObj
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
		public int SaveCollection(ValoriPrioritaCollection collectionObj)
		{
			return ValoriPrioritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ValoriPriorita valoriprioritaObj)
		{
			return ValoriPrioritaDAL.Save(_dbProviderObj, valoriprioritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ValoriPrioritaCollection collectionObj)
		{
			return ValoriPrioritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ValoriPriorita valoriprioritaObj)
		{
			return ValoriPrioritaDAL.Delete(_dbProviderObj, valoriprioritaObj);
		}

		//getById
		public ValoriPriorita GetById(IntNT IdValoreValue)
		{
			ValoriPriorita ValoriPrioritaTemp = ValoriPrioritaDAL.GetById(_dbProviderObj, IdValoreValue);
			if (ValoriPrioritaTemp!=null) ValoriPrioritaTemp.Provider = this;
			return ValoriPrioritaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ValoriPrioritaCollection Select(IntNT IdvaloreEqualThis, IntNT IdprioritaEqualThis, StringNT DescrizioneEqualThis, 
StringNT CodiceEqualThis, DecimalNT PunteggioEqualThis)
		{
			ValoriPrioritaCollection ValoriPrioritaCollectionTemp = ValoriPrioritaDAL.Select(_dbProviderObj, IdvaloreEqualThis, IdprioritaEqualThis, DescrizioneEqualThis, 
CodiceEqualThis, PunteggioEqualThis);
			ValoriPrioritaCollectionTemp.Provider = this;
			return ValoriPrioritaCollectionTemp;
		}

		//Find: popola la collection
		public ValoriPrioritaCollection Find(IntNT IdvaloreEqualThis, IntNT IdprioritaEqualThis, StringNT CodiceEqualThis)
		{
			ValoriPrioritaCollection ValoriPrioritaCollectionTemp = ValoriPrioritaDAL.Find(_dbProviderObj, IdvaloreEqualThis, IdprioritaEqualThis, CodiceEqualThis);
			ValoriPrioritaCollectionTemp.Provider = this;
			return ValoriPrioritaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VALORI_PRIORITA>
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
      <ID_VALORE>Equal</ID_VALORE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VALORI_PRIORITA>
*/
