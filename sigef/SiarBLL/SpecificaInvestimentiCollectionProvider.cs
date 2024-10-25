using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SpecificaInvestimenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISpecificaInvestimentiProvider
	{
		int Save(SpecificaInvestimenti SpecificaInvestimentiObj);
		int SaveCollection(SpecificaInvestimentiCollection collectionObj);
		int Delete(SpecificaInvestimenti SpecificaInvestimentiObj);
		int DeleteCollection(SpecificaInvestimentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SpecificaInvestimenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SpecificaInvestimenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSpecificaInvestimento;
		private NullTypes.IntNT _IdDettaglioInvestimento;
		private NullTypes.StringNT _CodSpecifica;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private ISpecificaInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISpecificaInvestimentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SpecificaInvestimenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SPECIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSpecificaInvestimento
		{
			get { return _IdSpecificaInvestimento; }
			set {
				if (IdSpecificaInvestimento != value)
				{
					_IdSpecificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DETTAGLIO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDettaglioInvestimento
		{
			get { return _IdDettaglioInvestimento; }
			set {
				if (IdDettaglioInvestimento != value)
				{
					_IdDettaglioInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_SPECIFICA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodSpecifica
		{
			get { return _CodSpecifica; }
			set {
				if (CodSpecifica != value)
				{
					_CodSpecifica = value;
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
	/// Summary description for SpecificaInvestimentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpecificaInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SpecificaInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SpecificaInvestimenti) info.GetValue(i.ToString(),typeof(SpecificaInvestimenti)));
			}
		}

		//Costruttore
		public SpecificaInvestimentiCollection()
		{
			this.ItemType = typeof(SpecificaInvestimenti);
		}

		//Costruttore con provider
		public SpecificaInvestimentiCollection(ISpecificaInvestimentiProvider providerObj)
		{
			this.ItemType = typeof(SpecificaInvestimenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SpecificaInvestimenti this[int index]
		{
			get { return (SpecificaInvestimenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SpecificaInvestimentiCollection GetChanges()
		{
			return (SpecificaInvestimentiCollection) base.GetChanges();
		}

		[NonSerialized] private ISpecificaInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISpecificaInvestimentiProvider Provider
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
		public int Add(SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			if (SpecificaInvestimentiObj.Provider == null) SpecificaInvestimentiObj.Provider = this.Provider;
			return base.Add(SpecificaInvestimentiObj);
		}

		//AddCollection
		public void AddCollection(SpecificaInvestimentiCollection SpecificaInvestimentiCollectionObj)
		{
			foreach (SpecificaInvestimenti SpecificaInvestimentiObj in SpecificaInvestimentiCollectionObj)
				this.Add(SpecificaInvestimentiObj);
		}

		//Insert
		public void Insert(int index, SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			if (SpecificaInvestimentiObj.Provider == null) SpecificaInvestimentiObj.Provider = this.Provider;
			base.Insert(index, SpecificaInvestimentiObj);
		}

		//CollectionGetById
		public SpecificaInvestimenti CollectionGetById(NullTypes.IntNT IdSpecificaInvestimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSpecificaInvestimento == IdSpecificaInvestimentoValue))
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
		public SpecificaInvestimentiCollection SubSelect(NullTypes.IntNT IdSpecificaInvestimentoEqualThis, NullTypes.IntNT IdDettaglioInvestimentoEqualThis, NullTypes.StringNT CodSpecificaEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			SpecificaInvestimentiCollection SpecificaInvestimentiCollectionTemp = new SpecificaInvestimentiCollection();
			foreach (SpecificaInvestimenti SpecificaInvestimentiItem in this)
			{
				if (((IdSpecificaInvestimentoEqualThis == null) || ((SpecificaInvestimentiItem.IdSpecificaInvestimento != null) && (SpecificaInvestimentiItem.IdSpecificaInvestimento.Value == IdSpecificaInvestimentoEqualThis.Value))) && ((IdDettaglioInvestimentoEqualThis == null) || ((SpecificaInvestimentiItem.IdDettaglioInvestimento != null) && (SpecificaInvestimentiItem.IdDettaglioInvestimento.Value == IdDettaglioInvestimentoEqualThis.Value))) && ((CodSpecificaEqualThis == null) || ((SpecificaInvestimentiItem.CodSpecifica != null) && (SpecificaInvestimentiItem.CodSpecifica.Value == CodSpecificaEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((SpecificaInvestimentiItem.Descrizione != null) && (SpecificaInvestimentiItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					SpecificaInvestimentiCollectionTemp.Add(SpecificaInvestimentiItem);
				}
			}
			return SpecificaInvestimentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SpecificaInvestimentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SpecificaInvestimentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SpecificaInvestimenti SpecificaInvestimentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSpecificaInvestimento", SpecificaInvestimentiObj.IdSpecificaInvestimento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDettaglioInvestimento", SpecificaInvestimentiObj.IdDettaglioInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodSpecifica", SpecificaInvestimentiObj.CodSpecifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", SpecificaInvestimentiObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSpecificaInvestimentiInsert", new string[] {"IdDettaglioInvestimento", "CodSpecifica", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,SpecificaInvestimentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SpecificaInvestimentiObj.IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
				}
				SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpecificaInvestimentiObj.IsDirty = false;
				SpecificaInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSpecificaInvestimentiUpdate", new string[] {"IdSpecificaInvestimento", "IdDettaglioInvestimento", "CodSpecifica", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,SpecificaInvestimentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpecificaInvestimentiObj.IsDirty = false;
				SpecificaInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			switch (SpecificaInvestimentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SpecificaInvestimentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SpecificaInvestimentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SpecificaInvestimentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SpecificaInvestimentiCollection SpecificaInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSpecificaInvestimentiUpdate", new string[] {"IdSpecificaInvestimento", "IdDettaglioInvestimento", "CodSpecifica", 
"Descrizione"}, new string[] {"int", "int", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZSpecificaInvestimentiInsert", new string[] {"IdDettaglioInvestimento", "CodSpecifica", 
"Descrizione"}, new string[] {"int", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSpecificaInvestimentiDelete", new string[] {"IdSpecificaInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < SpecificaInvestimentiCollectionObj.Count; i++)
				{
					switch (SpecificaInvestimentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SpecificaInvestimentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SpecificaInvestimentiCollectionObj[i].IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SpecificaInvestimentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SpecificaInvestimentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpecificaInvestimento", (SiarLibrary.NullTypes.IntNT)SpecificaInvestimentiCollectionObj[i].IdSpecificaInvestimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SpecificaInvestimentiCollectionObj.Count; i++)
				{
					if ((SpecificaInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpecificaInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpecificaInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SpecificaInvestimentiCollectionObj[i].IsDirty = false;
						SpecificaInvestimentiCollectionObj[i].IsPersistent = true;
					}
					if ((SpecificaInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SpecificaInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpecificaInvestimentiCollectionObj[i].IsDirty = false;
						SpecificaInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SpecificaInvestimenti SpecificaInvestimentiObj)
		{
			int returnValue = 0;
			if (SpecificaInvestimentiObj.IsPersistent) 
			{
				returnValue = Delete(db, SpecificaInvestimentiObj.IdSpecificaInvestimento);
			}
			SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SpecificaInvestimentiObj.IsDirty = false;
			SpecificaInvestimentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSpecificaInvestimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSpecificaInvestimentiDelete", new string[] {"IdSpecificaInvestimento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpecificaInvestimento", (SiarLibrary.NullTypes.IntNT)IdSpecificaInvestimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SpecificaInvestimentiCollection SpecificaInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSpecificaInvestimentiDelete", new string[] {"IdSpecificaInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < SpecificaInvestimentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpecificaInvestimento", SpecificaInvestimentiCollectionObj[i].IdSpecificaInvestimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SpecificaInvestimentiCollectionObj.Count; i++)
				{
					if ((SpecificaInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpecificaInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpecificaInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpecificaInvestimentiCollectionObj[i].IsDirty = false;
						SpecificaInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static SpecificaInvestimenti GetById(DbProvider db, int IdSpecificaInvestimentoValue)
		{
			SpecificaInvestimenti SpecificaInvestimentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSpecificaInvestimentiGetById", new string[] {"IdSpecificaInvestimento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSpecificaInvestimento", (SiarLibrary.NullTypes.IntNT)IdSpecificaInvestimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SpecificaInvestimentiObj = GetFromDatareader(db);
				SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpecificaInvestimentiObj.IsDirty = false;
				SpecificaInvestimentiObj.IsPersistent = true;
			}
			db.Close();
			return SpecificaInvestimentiObj;
		}

		//getFromDatareader
		public static SpecificaInvestimenti GetFromDatareader(DbProvider db)
		{
			SpecificaInvestimenti SpecificaInvestimentiObj = new SpecificaInvestimenti();
			SpecificaInvestimentiObj.IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
			SpecificaInvestimentiObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
			SpecificaInvestimentiObj.CodSpecifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SPECIFICA"]);
			SpecificaInvestimentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SpecificaInvestimentiObj.IsDirty = false;
			SpecificaInvestimentiObj.IsPersistent = true;
			return SpecificaInvestimentiObj;
		}

		//Find Select

		public static SpecificaInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpecificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodSpecificaEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			SpecificaInvestimentiCollection SpecificaInvestimentiCollectionObj = new SpecificaInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zspecificainvestimentifindselect", new string[] {"IdSpecificaInvestimentoequalthis", "IdDettaglioInvestimentoequalthis", "CodSpecificaequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpecificaInvestimentoequalthis", IdSpecificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodSpecificaequalthis", CodSpecificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			SpecificaInvestimenti SpecificaInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpecificaInvestimentiObj = GetFromDatareader(db);
				SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpecificaInvestimentiObj.IsDirty = false;
				SpecificaInvestimentiObj.IsPersistent = true;
				SpecificaInvestimentiCollectionObj.Add(SpecificaInvestimentiObj);
			}
			db.Close();
			return SpecificaInvestimentiCollectionObj;
		}

		//Find Find

		public static SpecificaInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodSpecificaEqualThis)

		{

			SpecificaInvestimentiCollection SpecificaInvestimentiCollectionObj = new SpecificaInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zspecificainvestimentifindfind", new string[] {"IdDettaglioInvestimentoequalthis", "CodSpecificaequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodSpecificaequalthis", CodSpecificaEqualThis);
			SpecificaInvestimenti SpecificaInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpecificaInvestimentiObj = GetFromDatareader(db);
				SpecificaInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpecificaInvestimentiObj.IsDirty = false;
				SpecificaInvestimentiObj.IsPersistent = true;
				SpecificaInvestimentiCollectionObj.Add(SpecificaInvestimentiObj);
			}
			db.Close();
			return SpecificaInvestimentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SpecificaInvestimentiCollectionProvider:ISpecificaInvestimentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpecificaInvestimentiCollectionProvider : ISpecificaInvestimentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SpecificaInvestimenti
		protected SpecificaInvestimentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SpecificaInvestimentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SpecificaInvestimentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public SpecificaInvestimentiCollectionProvider(IntNT IddettaglioinvestimentoEqualThis, StringNT CodspecificaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddettaglioinvestimentoEqualThis, CodspecificaEqualThis);
		}

		//Costruttore3: ha in input specificainvestimentiCollectionObj - non popola la collection
		public SpecificaInvestimentiCollectionProvider(SpecificaInvestimentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SpecificaInvestimentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SpecificaInvestimentiCollection(this);
		}

		//Get e Set
		public SpecificaInvestimentiCollection CollectionObj
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
		public int SaveCollection(SpecificaInvestimentiCollection collectionObj)
		{
			return SpecificaInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SpecificaInvestimenti specificainvestimentiObj)
		{
			return SpecificaInvestimentiDAL.Save(_dbProviderObj, specificainvestimentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SpecificaInvestimentiCollection collectionObj)
		{
			return SpecificaInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SpecificaInvestimenti specificainvestimentiObj)
		{
			return SpecificaInvestimentiDAL.Delete(_dbProviderObj, specificainvestimentiObj);
		}

		//getById
		public SpecificaInvestimenti GetById(IntNT IdSpecificaInvestimentoValue)
		{
			SpecificaInvestimenti SpecificaInvestimentiTemp = SpecificaInvestimentiDAL.GetById(_dbProviderObj, IdSpecificaInvestimentoValue);
			if (SpecificaInvestimentiTemp!=null) SpecificaInvestimentiTemp.Provider = this;
			return SpecificaInvestimentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SpecificaInvestimentiCollection Select(IntNT IdspecificainvestimentoEqualThis, IntNT IddettaglioinvestimentoEqualThis, StringNT CodspecificaEqualThis, 
StringNT DescrizioneEqualThis)
		{
			SpecificaInvestimentiCollection SpecificaInvestimentiCollectionTemp = SpecificaInvestimentiDAL.Select(_dbProviderObj, IdspecificainvestimentoEqualThis, IddettaglioinvestimentoEqualThis, CodspecificaEqualThis, 
DescrizioneEqualThis);
			SpecificaInvestimentiCollectionTemp.Provider = this;
			return SpecificaInvestimentiCollectionTemp;
		}

		//Find: popola la collection
		public SpecificaInvestimentiCollection Find(IntNT IddettaglioinvestimentoEqualThis, StringNT CodspecificaEqualThis)
		{
			SpecificaInvestimentiCollection SpecificaInvestimentiCollectionTemp = SpecificaInvestimentiDAL.Find(_dbProviderObj, IddettaglioinvestimentoEqualThis, CodspecificaEqualThis);
			SpecificaInvestimentiCollectionTemp.Provider = this;
			return SpecificaInvestimentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SPECIFICA_INVESTIMENTI>
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
    <Find OrderBy="ORDER BY ID_DETTAGLIO_INVESTIMENTO">
      <ID_DETTAGLIO_INVESTIMENTO>Equal</ID_DETTAGLIO_INVESTIMENTO>
      <COD_SPECIFICA>Equal</COD_SPECIFICA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SPECIFICA_INVESTIMENTI>
*/
