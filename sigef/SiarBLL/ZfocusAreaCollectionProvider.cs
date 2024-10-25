using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZfocusArea
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZfocusAreaProvider
	{
		int Save(ZfocusArea ZfocusAreaObj);
		int SaveCollection(ZfocusAreaCollection collectionObj);
		int Delete(ZfocusArea ZfocusAreaObj);
		int DeleteCollection(ZfocusAreaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZfocusArea
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZfocusArea: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _CodPsr;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DecimalNT _DotFinanziaria;
		private NullTypes.BoolNT _Trasversale;
		[NonSerialized] private IZfocusAreaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZfocusAreaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZfocusArea()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:COD_PSR
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodPsr
		{
			get { return _CodPsr; }
			set {
				if (CodPsr != value)
				{
					_CodPsr = value;
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

		/// <summary>
		/// Corrisponde al campo:DOT_FINANZIARIA
		/// Tipo sul db:DECIMAL(18,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT DotFinanziaria
		{
			get { return _DotFinanziaria; }
			set {
				if (DotFinanziaria != value)
				{
					_DotFinanziaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TRASVERSALE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Trasversale
		{
			get { return _Trasversale; }
			set {
				if (Trasversale != value)
				{
					_Trasversale = value;
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
	/// Summary description for ZfocusAreaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZfocusAreaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZfocusAreaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZfocusArea) info.GetValue(i.ToString(),typeof(ZfocusArea)));
			}
		}

		//Costruttore
		public ZfocusAreaCollection()
		{
			this.ItemType = typeof(ZfocusArea);
		}

		//Costruttore con provider
		public ZfocusAreaCollection(IZfocusAreaProvider providerObj)
		{
			this.ItemType = typeof(ZfocusArea);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZfocusArea this[int index]
		{
			get { return (ZfocusArea)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZfocusAreaCollection GetChanges()
		{
			return (ZfocusAreaCollection) base.GetChanges();
		}

		[NonSerialized] private IZfocusAreaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZfocusAreaProvider Provider
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
		public int Add(ZfocusArea ZfocusAreaObj)
		{
			if (ZfocusAreaObj.Provider == null) ZfocusAreaObj.Provider = this.Provider;
			return base.Add(ZfocusAreaObj);
		}

		//AddCollection
		public void AddCollection(ZfocusAreaCollection ZfocusAreaCollectionObj)
		{
			foreach (ZfocusArea ZfocusAreaObj in ZfocusAreaCollectionObj)
				this.Add(ZfocusAreaObj);
		}

		//Insert
		public void Insert(int index, ZfocusArea ZfocusAreaObj)
		{
			if (ZfocusAreaObj.Provider == null) ZfocusAreaObj.Provider = this.Provider;
			base.Insert(index, ZfocusAreaObj);
		}

		//CollectionGetById
		public ZfocusArea CollectionGetById(NullTypes.StringNT CodiceValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Codice == CodiceValue))
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
		public ZfocusAreaCollection SubSelect(NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT CodPsrEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.DecimalNT DotFinanziariaEqualThis, NullTypes.BoolNT TrasversaleEqualThis)
		{
			ZfocusAreaCollection ZfocusAreaCollectionTemp = new ZfocusAreaCollection();
			foreach (ZfocusArea ZfocusAreaItem in this)
			{
				if (((CodiceEqualThis == null) || ((ZfocusAreaItem.Codice != null) && (ZfocusAreaItem.Codice.Value == CodiceEqualThis.Value))) && ((CodPsrEqualThis == null) || ((ZfocusAreaItem.CodPsr != null) && (ZfocusAreaItem.CodPsr.Value == CodPsrEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ZfocusAreaItem.Descrizione != null) && (ZfocusAreaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((DotFinanziariaEqualThis == null) || ((ZfocusAreaItem.DotFinanziaria != null) && (ZfocusAreaItem.DotFinanziaria.Value == DotFinanziariaEqualThis.Value))) && ((TrasversaleEqualThis == null) || ((ZfocusAreaItem.Trasversale != null) && (ZfocusAreaItem.Trasversale.Value == TrasversaleEqualThis.Value))))
				{
					ZfocusAreaCollectionTemp.Add(ZfocusAreaItem);
				}
			}
			return ZfocusAreaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZfocusAreaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZfocusAreaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZfocusArea ZfocusAreaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ZfocusAreaObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "CodPsr", ZfocusAreaObj.CodPsr);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZfocusAreaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "DotFinanziaria", ZfocusAreaObj.DotFinanziaria);
			DbProvider.SetCmdParam(cmd,firstChar + "Trasversale", ZfocusAreaObj.Trasversale);
		}
		//Insert
		private static int Insert(DbProvider db, ZfocusArea ZfocusAreaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZfocusAreaInsert", new string[] {"Codice", "CodPsr", "Descrizione", 
"DotFinanziaria", "Trasversale"}, new string[] {"string", "string", "string", 
"decimal", "bool"},"");
				CompileIUCmd(false, insertCmd,ZfocusAreaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZfocusAreaObj.DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
				ZfocusAreaObj.Trasversale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TRASVERSALE"]);
				}
				ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZfocusAreaObj.IsDirty = false;
				ZfocusAreaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZfocusArea ZfocusAreaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZfocusAreaUpdate", new string[] {"Codice", "CodPsr", "Descrizione", 
"DotFinanziaria", "Trasversale"}, new string[] {"string", "string", "string", 
"decimal", "bool"},"");
				CompileIUCmd(true, updateCmd,ZfocusAreaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZfocusAreaObj.IsDirty = false;
				ZfocusAreaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZfocusArea ZfocusAreaObj)
		{
			switch (ZfocusAreaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZfocusAreaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZfocusAreaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZfocusAreaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZfocusAreaCollection ZfocusAreaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZfocusAreaUpdate", new string[] {"Codice", "CodPsr", "Descrizione", 
"DotFinanziaria", "Trasversale"}, new string[] {"string", "string", "string", 
"decimal", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZZfocusAreaInsert", new string[] {"Codice", "CodPsr", "Descrizione", 
"DotFinanziaria", "Trasversale"}, new string[] {"string", "string", "string", 
"decimal", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZfocusAreaDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < ZfocusAreaCollectionObj.Count; i++)
				{
					switch (ZfocusAreaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZfocusAreaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZfocusAreaCollectionObj[i].DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
									ZfocusAreaCollectionObj[i].Trasversale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TRASVERSALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZfocusAreaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZfocusAreaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)ZfocusAreaCollectionObj[i].Codice);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZfocusAreaCollectionObj.Count; i++)
				{
					if ((ZfocusAreaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZfocusAreaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZfocusAreaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZfocusAreaCollectionObj[i].IsDirty = false;
						ZfocusAreaCollectionObj[i].IsPersistent = true;
					}
					if ((ZfocusAreaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZfocusAreaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZfocusAreaCollectionObj[i].IsDirty = false;
						ZfocusAreaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZfocusArea ZfocusAreaObj)
		{
			int returnValue = 0;
			if (ZfocusAreaObj.IsPersistent) 
			{
				returnValue = Delete(db, ZfocusAreaObj.Codice);
			}
			ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZfocusAreaObj.IsDirty = false;
			ZfocusAreaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodiceValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZfocusAreaDelete", new string[] {"Codice"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZfocusAreaCollection ZfocusAreaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZfocusAreaDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < ZfocusAreaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", ZfocusAreaCollectionObj[i].Codice);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZfocusAreaCollectionObj.Count; i++)
				{
					if ((ZfocusAreaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZfocusAreaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZfocusAreaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZfocusAreaCollectionObj[i].IsDirty = false;
						ZfocusAreaCollectionObj[i].IsPersistent = false;
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
		public static ZfocusArea GetById(DbProvider db, string CodiceValue)
		{
			ZfocusArea ZfocusAreaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZfocusAreaGetById", new string[] {"Codice"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZfocusAreaObj = GetFromDatareader(db);
				ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZfocusAreaObj.IsDirty = false;
				ZfocusAreaObj.IsPersistent = true;
			}
			db.Close();
			return ZfocusAreaObj;
		}

		//getFromDatareader
		public static ZfocusArea GetFromDatareader(DbProvider db)
		{
			ZfocusArea ZfocusAreaObj = new ZfocusArea();
			ZfocusAreaObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ZfocusAreaObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			ZfocusAreaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZfocusAreaObj.DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
			ZfocusAreaObj.Trasversale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TRASVERSALE"]);
			ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZfocusAreaObj.IsDirty = false;
			ZfocusAreaObj.IsPersistent = true;
			return ZfocusAreaObj;
		}

		//Find Select

		public static ZfocusAreaCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT DotFinanziariaEqualThis, SiarLibrary.NullTypes.BoolNT TrasversaleEqualThis)

		{

			ZfocusAreaCollection ZfocusAreaCollectionObj = new ZfocusAreaCollection();

			IDbCommand findCmd = db.InitCmd("Zzfocusareafindselect", new string[] {"Codiceequalthis", "CodPsrequalthis", "Descrizioneequalthis", 
"DotFinanziariaequalthis", "Trasversaleequalthis"}, new string[] {"string", "string", "string", 
"decimal", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DotFinanziariaequalthis", DotFinanziariaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Trasversaleequalthis", TrasversaleEqualThis);
			ZfocusArea ZfocusAreaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZfocusAreaObj = GetFromDatareader(db);
				ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZfocusAreaObj.IsDirty = false;
				ZfocusAreaObj.IsPersistent = true;
				ZfocusAreaCollectionObj.Add(ZfocusAreaObj);
			}
			db.Close();
			return ZfocusAreaCollectionObj;
		}

		//Find Find

		public static ZfocusAreaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceLikeThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.BoolNT TrasversaleEqualThis)

		{

			ZfocusAreaCollection ZfocusAreaCollectionObj = new ZfocusAreaCollection();

			IDbCommand findCmd = db.InitCmd("Zzfocusareafindfind", new string[] {"Codicelikethis", "CodPsrequalthis", "Trasversaleequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codicelikethis", CodiceLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Trasversaleequalthis", TrasversaleEqualThis);
			ZfocusArea ZfocusAreaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZfocusAreaObj = GetFromDatareader(db);
				ZfocusAreaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZfocusAreaObj.IsDirty = false;
				ZfocusAreaObj.IsPersistent = true;
				ZfocusAreaCollectionObj.Add(ZfocusAreaObj);
			}
			db.Close();
			return ZfocusAreaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZfocusAreaCollectionProvider:IZfocusAreaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZfocusAreaCollectionProvider : IZfocusAreaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZfocusArea
		protected ZfocusAreaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZfocusAreaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZfocusAreaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZfocusAreaCollectionProvider(StringNT CodiceLikeThis, StringNT CodpsrEqualThis, BoolNT TrasversaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodiceLikeThis, CodpsrEqualThis, TrasversaleEqualThis);
		}

		//Costruttore3: ha in input zfocusareaCollectionObj - non popola la collection
		public ZfocusAreaCollectionProvider(ZfocusAreaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZfocusAreaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZfocusAreaCollection(this);
		}

		//Get e Set
		public ZfocusAreaCollection CollectionObj
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
		public int SaveCollection(ZfocusAreaCollection collectionObj)
		{
			return ZfocusAreaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZfocusArea zfocusareaObj)
		{
			return ZfocusAreaDAL.Save(_dbProviderObj, zfocusareaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZfocusAreaCollection collectionObj)
		{
			return ZfocusAreaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZfocusArea zfocusareaObj)
		{
			return ZfocusAreaDAL.Delete(_dbProviderObj, zfocusareaObj);
		}

		//getById
		public ZfocusArea GetById(StringNT CodiceValue)
		{
			ZfocusArea ZfocusAreaTemp = ZfocusAreaDAL.GetById(_dbProviderObj, CodiceValue);
			if (ZfocusAreaTemp!=null) ZfocusAreaTemp.Provider = this;
			return ZfocusAreaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZfocusAreaCollection Select(StringNT CodiceEqualThis, StringNT CodpsrEqualThis, StringNT DescrizioneEqualThis, 
DecimalNT DotfinanziariaEqualThis, BoolNT TrasversaleEqualThis)
		{
			ZfocusAreaCollection ZfocusAreaCollectionTemp = ZfocusAreaDAL.Select(_dbProviderObj, CodiceEqualThis, CodpsrEqualThis, DescrizioneEqualThis, 
DotfinanziariaEqualThis, TrasversaleEqualThis);
			ZfocusAreaCollectionTemp.Provider = this;
			return ZfocusAreaCollectionTemp;
		}

		//Find: popola la collection
		public ZfocusAreaCollection Find(StringNT CodiceLikeThis, StringNT CodpsrEqualThis, BoolNT TrasversaleEqualThis)
		{
			ZfocusAreaCollection ZfocusAreaCollectionTemp = ZfocusAreaDAL.Find(_dbProviderObj, CodiceLikeThis, CodpsrEqualThis, TrasversaleEqualThis);
			ZfocusAreaCollectionTemp.Provider = this;
			return ZfocusAreaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zFOCUS_AREA>
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
    <Find OrderBy="ORDER BY CODICE">
      <CODICE>Like</CODICE>
      <COD_PSR>Equal</COD_PSR>
      <TRASVERSALE>Equal</TRASVERSALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zFOCUS_AREA>
*/
