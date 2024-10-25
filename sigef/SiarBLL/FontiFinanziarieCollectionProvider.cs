using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per FontiFinanziarie
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFontiFinanziarieProvider
	{
		int Save(FontiFinanziarie FontiFinanziarieObj);
		int SaveCollection(FontiFinanziarieCollection collectionObj);
		int Delete(FontiFinanziarie FontiFinanziarieObj);
		int DeleteCollection(FontiFinanziarieCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FontiFinanziarie
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class FontiFinanziarie: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdFonte;
		private NullTypes.DecimalNT _Percentuale;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IFontiFinanziarieProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFontiFinanziarieProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FontiFinanziarie()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FONTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFonte
		{
			get { return _IdFonte; }
			set {
				if (IdFonte != value)
				{
					_IdFonte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERCENTUALE
		/// Tipo sul db:DECIMAL(10,3)
		/// </summary>
		public NullTypes.DecimalNT Percentuale
		{
			get { return _Percentuale; }
			set {
				if (Percentuale != value)
				{
					_Percentuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
	/// Summary description for FontiFinanziarieCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FontiFinanziarieCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FontiFinanziarieCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FontiFinanziarie) info.GetValue(i.ToString(),typeof(FontiFinanziarie)));
			}
		}

		//Costruttore
		public FontiFinanziarieCollection()
		{
			this.ItemType = typeof(FontiFinanziarie);
		}

		//Costruttore con provider
		public FontiFinanziarieCollection(IFontiFinanziarieProvider providerObj)
		{
			this.ItemType = typeof(FontiFinanziarie);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FontiFinanziarie this[int index]
		{
			get { return (FontiFinanziarie)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FontiFinanziarieCollection GetChanges()
		{
			return (FontiFinanziarieCollection) base.GetChanges();
		}

		[NonSerialized] private IFontiFinanziarieProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFontiFinanziarieProvider Provider
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
		public int Add(FontiFinanziarie FontiFinanziarieObj)
		{
			if (FontiFinanziarieObj.Provider == null) FontiFinanziarieObj.Provider = this.Provider;
			return base.Add(FontiFinanziarieObj);
		}

		//AddCollection
		public void AddCollection(FontiFinanziarieCollection FontiFinanziarieCollectionObj)
		{
			foreach (FontiFinanziarie FontiFinanziarieObj in FontiFinanziarieCollectionObj)
				this.Add(FontiFinanziarieObj);
		}

		//Insert
		public void Insert(int index, FontiFinanziarie FontiFinanziarieObj)
		{
			if (FontiFinanziarieObj.Provider == null) FontiFinanziarieObj.Provider = this.Provider;
			base.Insert(index, FontiFinanziarieObj);
		}

		//CollectionGetById
		public FontiFinanziarie CollectionGetById(NullTypes.IntNT IdFonteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdFonte == IdFonteValue))
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
		public FontiFinanziarieCollection SubSelect(NullTypes.IntNT IdFonteEqualThis, NullTypes.DecimalNT PercentualeEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			FontiFinanziarieCollection FontiFinanziarieCollectionTemp = new FontiFinanziarieCollection();
			foreach (FontiFinanziarie FontiFinanziarieItem in this)
			{
				if (((IdFonteEqualThis == null) || ((FontiFinanziarieItem.IdFonte != null) && (FontiFinanziarieItem.IdFonte.Value == IdFonteEqualThis.Value))) && ((PercentualeEqualThis == null) || ((FontiFinanziarieItem.Percentuale != null) && (FontiFinanziarieItem.Percentuale.Value == PercentualeEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((FontiFinanziarieItem.Descrizione != null) && (FontiFinanziarieItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					FontiFinanziarieCollectionTemp.Add(FontiFinanziarieItem);
				}
			}
			return FontiFinanziarieCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FontiFinanziarieDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class FontiFinanziarieDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FontiFinanziarie FontiFinanziarieObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdFonte", FontiFinanziarieObj.IdFonte);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Percentuale", FontiFinanziarieObj.Percentuale);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", FontiFinanziarieObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, FontiFinanziarie FontiFinanziarieObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFontiFinanziarieInsert", new string[] {"Percentuale", "Descrizione"}, new string[] {"decimal", "string"},"");
				CompileIUCmd(false, insertCmd,FontiFinanziarieObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FontiFinanziarieObj.IdFonte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FONTE"]);
				}
				FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FontiFinanziarieObj.IsDirty = false;
				FontiFinanziarieObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FontiFinanziarie FontiFinanziarieObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFontiFinanziarieUpdate", new string[] {"IdFonte", "Percentuale", "Descrizione"}, new string[] {"int", "decimal", "string"},"");
				CompileIUCmd(true, updateCmd,FontiFinanziarieObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FontiFinanziarieObj.IsDirty = false;
				FontiFinanziarieObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FontiFinanziarie FontiFinanziarieObj)
		{
			switch (FontiFinanziarieObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FontiFinanziarieObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FontiFinanziarieObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FontiFinanziarieObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FontiFinanziarieCollection FontiFinanziarieCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFontiFinanziarieUpdate", new string[] {"IdFonte", "Percentuale", "Descrizione"}, new string[] {"int", "decimal", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFontiFinanziarieInsert", new string[] {"Percentuale", "Descrizione"}, new string[] {"decimal", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFontiFinanziarieDelete", new string[] {"IdFonte"}, new string[] {"int"},"");
				for (int i = 0; i < FontiFinanziarieCollectionObj.Count; i++)
				{
					switch (FontiFinanziarieCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FontiFinanziarieCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FontiFinanziarieCollectionObj[i].IdFonte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FONTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FontiFinanziarieCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FontiFinanziarieCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFonte", (SiarLibrary.NullTypes.IntNT)FontiFinanziarieCollectionObj[i].IdFonte);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FontiFinanziarieCollectionObj.Count; i++)
				{
					if ((FontiFinanziarieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FontiFinanziarieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FontiFinanziarieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FontiFinanziarieCollectionObj[i].IsDirty = false;
						FontiFinanziarieCollectionObj[i].IsPersistent = true;
					}
					if ((FontiFinanziarieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FontiFinanziarieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FontiFinanziarieCollectionObj[i].IsDirty = false;
						FontiFinanziarieCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FontiFinanziarie FontiFinanziarieObj)
		{
			int returnValue = 0;
			if (FontiFinanziarieObj.IsPersistent) 
			{
				returnValue = Delete(db, FontiFinanziarieObj.IdFonte);
			}
			FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FontiFinanziarieObj.IsDirty = false;
			FontiFinanziarieObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdFonteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFontiFinanziarieDelete", new string[] {"IdFonte"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFonte", (SiarLibrary.NullTypes.IntNT)IdFonteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FontiFinanziarieCollection FontiFinanziarieCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFontiFinanziarieDelete", new string[] {"IdFonte"}, new string[] {"int"},"");
				for (int i = 0; i < FontiFinanziarieCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdFonte", FontiFinanziarieCollectionObj[i].IdFonte);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FontiFinanziarieCollectionObj.Count; i++)
				{
					if ((FontiFinanziarieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FontiFinanziarieCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FontiFinanziarieCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FontiFinanziarieCollectionObj[i].IsDirty = false;
						FontiFinanziarieCollectionObj[i].IsPersistent = false;
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
		public static FontiFinanziarie GetById(DbProvider db, int IdFonteValue)
		{
			FontiFinanziarie FontiFinanziarieObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFontiFinanziarieGetById", new string[] {"IdFonte"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdFonte", (SiarLibrary.NullTypes.IntNT)IdFonteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FontiFinanziarieObj = GetFromDatareader(db);
				FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FontiFinanziarieObj.IsDirty = false;
				FontiFinanziarieObj.IsPersistent = true;
			}
			db.Close();
			return FontiFinanziarieObj;
		}

		//getFromDatareader
		public static FontiFinanziarie GetFromDatareader(DbProvider db)
		{
			FontiFinanziarie FontiFinanziarieObj = new FontiFinanziarie();
			FontiFinanziarieObj.IdFonte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FONTE"]);
			FontiFinanziarieObj.Percentuale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE"]);
			FontiFinanziarieObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FontiFinanziarieObj.IsDirty = false;
			FontiFinanziarieObj.IsPersistent = true;
			return FontiFinanziarieObj;
		}

		//Find Select

		public static FontiFinanziarieCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFonteEqualThis, SiarLibrary.NullTypes.DecimalNT PercentualeEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			FontiFinanziarieCollection FontiFinanziarieCollectionObj = new FontiFinanziarieCollection();

			IDbCommand findCmd = db.InitCmd("Zfontifinanziariefindselect", new string[] {"IdFonteequalthis", "Percentualeequalthis", "Descrizioneequalthis"}, new string[] {"int", "decimal", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFonteequalthis", IdFonteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Percentualeequalthis", PercentualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			FontiFinanziarie FontiFinanziarieObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FontiFinanziarieObj = GetFromDatareader(db);
				FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FontiFinanziarieObj.IsDirty = false;
				FontiFinanziarieObj.IsPersistent = true;
				FontiFinanziarieCollectionObj.Add(FontiFinanziarieObj);
			}
			db.Close();
			return FontiFinanziarieCollectionObj;
		}

		//Find Find

		public static FontiFinanziarieCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			FontiFinanziarieCollection FontiFinanziarieCollectionObj = new FontiFinanziarieCollection();

			IDbCommand findCmd = db.InitCmd("Zfontifinanziariefindfind", new string[] {"Descrizionelikethis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			FontiFinanziarie FontiFinanziarieObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FontiFinanziarieObj = GetFromDatareader(db);
				FontiFinanziarieObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FontiFinanziarieObj.IsDirty = false;
				FontiFinanziarieObj.IsPersistent = true;
				FontiFinanziarieCollectionObj.Add(FontiFinanziarieObj);
			}
			db.Close();
			return FontiFinanziarieCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for FontiFinanziarieCollectionProvider:IFontiFinanziarieProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FontiFinanziarieCollectionProvider : IFontiFinanziarieProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FontiFinanziarie
		protected FontiFinanziarieCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FontiFinanziarieCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FontiFinanziarieCollection(this);
		}

		//Costruttore 2: popola la collection
		public FontiFinanziarieCollectionProvider(StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(DescrizioneLikeThis);
		}

		//Costruttore3: ha in input fontifinanziarieCollectionObj - non popola la collection
		public FontiFinanziarieCollectionProvider(FontiFinanziarieCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FontiFinanziarieCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FontiFinanziarieCollection(this);
		}

		//Get e Set
		public FontiFinanziarieCollection CollectionObj
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
		public int SaveCollection(FontiFinanziarieCollection collectionObj)
		{
			return FontiFinanziarieDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FontiFinanziarie fontifinanziarieObj)
		{
			return FontiFinanziarieDAL.Save(_dbProviderObj, fontifinanziarieObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FontiFinanziarieCollection collectionObj)
		{
			return FontiFinanziarieDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FontiFinanziarie fontifinanziarieObj)
		{
			return FontiFinanziarieDAL.Delete(_dbProviderObj, fontifinanziarieObj);
		}

		//getById
		public FontiFinanziarie GetById(IntNT IdFonteValue)
		{
			FontiFinanziarie FontiFinanziarieTemp = FontiFinanziarieDAL.GetById(_dbProviderObj, IdFonteValue);
			if (FontiFinanziarieTemp!=null) FontiFinanziarieTemp.Provider = this;
			return FontiFinanziarieTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FontiFinanziarieCollection Select(IntNT IdfonteEqualThis, DecimalNT PercentualeEqualThis, StringNT DescrizioneEqualThis)
		{
			FontiFinanziarieCollection FontiFinanziarieCollectionTemp = FontiFinanziarieDAL.Select(_dbProviderObj, IdfonteEqualThis, PercentualeEqualThis, DescrizioneEqualThis);
			FontiFinanziarieCollectionTemp.Provider = this;
			return FontiFinanziarieCollectionTemp;
		}

		//Find: popola la collection
		public FontiFinanziarieCollection Find(StringNT DescrizioneLikeThis)
		{
			FontiFinanziarieCollection FontiFinanziarieCollectionTemp = FontiFinanziarieDAL.Find(_dbProviderObj, DescrizioneLikeThis);
			FontiFinanziarieCollectionTemp.Provider = this;
			return FontiFinanziarieCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FONTI_FINANZIARIE>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FONTI_FINANZIARIE>
*/
