using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspParametriXLotto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspParametriXLottoProvider
	{
		int Save(CertspParametriXLotto CertspParametriXLottoObj);
		int SaveCollection(CertspParametriXLottoCollection collectionObj);
		int Delete(CertspParametriXLotto CertspParametriXLottoObj);
		int DeleteCollection(CertspParametriXLottoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspParametriXLotto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspParametriXLotto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdParametro;
		private NullTypes.IntNT _PesoReale;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.IntNT _Peso;
		private NullTypes.BoolNT _Manuale;
		[NonSerialized] private ICertspParametriXLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriXLottoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspParametriXLotto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PARAMETRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdParametro
		{
			get { return _IdParametro; }
			set {
				if (IdParametro != value)
				{
					_IdParametro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PESO_REALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT PesoReale
		{
			get { return _PesoReale; }
			set {
				if (PesoReale != value)
				{
					_PesoReale = value;
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
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PESO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Peso
		{
			get { return _Peso; }
			set {
				if (Peso != value)
				{
					_Peso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Manuale
		{
			get { return _Manuale; }
			set {
				if (Manuale != value)
				{
					_Manuale = value;
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
	/// Summary description for CertspParametriXLottoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriXLottoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspParametriXLottoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspParametriXLotto) info.GetValue(i.ToString(),typeof(CertspParametriXLotto)));
			}
		}

		//Costruttore
		public CertspParametriXLottoCollection()
		{
			this.ItemType = typeof(CertspParametriXLotto);
		}

		//Costruttore con provider
		public CertspParametriXLottoCollection(ICertspParametriXLottoProvider providerObj)
		{
			this.ItemType = typeof(CertspParametriXLotto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspParametriXLotto this[int index]
		{
			get { return (CertspParametriXLotto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspParametriXLottoCollection GetChanges()
		{
			return (CertspParametriXLottoCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspParametriXLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriXLottoProvider Provider
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
		public int Add(CertspParametriXLotto CertspParametriXLottoObj)
		{
			if (CertspParametriXLottoObj.Provider == null) CertspParametriXLottoObj.Provider = this.Provider;
			return base.Add(CertspParametriXLottoObj);
		}

		//AddCollection
		public void AddCollection(CertspParametriXLottoCollection CertspParametriXLottoCollectionObj)
		{
			foreach (CertspParametriXLotto CertspParametriXLottoObj in CertspParametriXLottoCollectionObj)
				this.Add(CertspParametriXLottoObj);
		}

		//Insert
		public void Insert(int index, CertspParametriXLotto CertspParametriXLottoObj)
		{
			if (CertspParametriXLottoObj.Provider == null) CertspParametriXLottoObj.Provider = this.Provider;
			base.Insert(index, CertspParametriXLottoObj);
		}

		//CollectionGetById
		public CertspParametriXLotto CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CertspParametriXLottoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdParametroEqualThis, 
NullTypes.IntNT PesoRealeEqualThis)
		{
			CertspParametriXLottoCollection CertspParametriXLottoCollectionTemp = new CertspParametriXLottoCollection();
			foreach (CertspParametriXLotto CertspParametriXLottoItem in this)
			{
				if (((IdEqualThis == null) || ((CertspParametriXLottoItem.Id != null) && (CertspParametriXLottoItem.Id.Value == IdEqualThis.Value))) && ((IdLottoEqualThis == null) || ((CertspParametriXLottoItem.IdLotto != null) && (CertspParametriXLottoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdParametroEqualThis == null) || ((CertspParametriXLottoItem.IdParametro != null) && (CertspParametriXLottoItem.IdParametro.Value == IdParametroEqualThis.Value))) && 
((PesoRealeEqualThis == null) || ((CertspParametriXLottoItem.PesoReale != null) && (CertspParametriXLottoItem.PesoReale.Value == PesoRealeEqualThis.Value))))
				{
					CertspParametriXLottoCollectionTemp.Add(CertspParametriXLottoItem);
				}
			}
			return CertspParametriXLottoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspParametriXLottoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspParametriXLottoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspParametriXLotto CertspParametriXLottoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspParametriXLottoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", CertspParametriXLottoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdParametro", CertspParametriXLottoObj.IdParametro);
			DbProvider.SetCmdParam(cmd,firstChar + "PesoReale", CertspParametriXLottoObj.PesoReale);
		}
		//Insert
		private static int Insert(DbProvider db, CertspParametriXLotto CertspParametriXLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriXLottoInsert", new string[] {"IdLotto", "IdParametro", 
"PesoReale", }, new string[] {"int", "int", 
"int", },"");
				CompileIUCmd(false, insertCmd,CertspParametriXLottoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspParametriXLottoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXLottoObj.IsDirty = false;
				CertspParametriXLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspParametriXLotto CertspParametriXLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriXLottoUpdate", new string[] {"Id", "IdLotto", "IdParametro", 
"PesoReale", }, new string[] {"int", "int", "int", 
"int", },"");
				CompileIUCmd(true, updateCmd,CertspParametriXLottoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXLottoObj.IsDirty = false;
				CertspParametriXLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspParametriXLotto CertspParametriXLottoObj)
		{
			switch (CertspParametriXLottoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspParametriXLottoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspParametriXLottoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspParametriXLottoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspParametriXLottoCollection CertspParametriXLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriXLottoUpdate", new string[] {"Id", "IdLotto", "IdParametro", 
"PesoReale", }, new string[] {"int", "int", "int", 
"int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriXLottoInsert", new string[] {"IdLotto", "IdParametro", 
"PesoReale", }, new string[] {"int", "int", 
"int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriXLottoCollectionObj.Count; i++)
				{
					switch (CertspParametriXLottoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspParametriXLottoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspParametriXLottoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspParametriXLottoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspParametriXLottoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspParametriXLottoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspParametriXLottoCollectionObj.Count; i++)
				{
					if ((CertspParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspParametriXLottoCollectionObj[i].IsDirty = false;
						CertspParametriXLottoCollectionObj[i].IsPersistent = true;
					}
					if ((CertspParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriXLottoCollectionObj[i].IsDirty = false;
						CertspParametriXLottoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspParametriXLotto CertspParametriXLottoObj)
		{
			int returnValue = 0;
			if (CertspParametriXLottoObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspParametriXLottoObj.Id);
			}
			CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspParametriXLottoObj.IsDirty = false;
			CertspParametriXLottoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspParametriXLottoCollection CertspParametriXLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriXLottoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspParametriXLottoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspParametriXLottoCollectionObj.Count; i++)
				{
					if ((CertspParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriXLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriXLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriXLottoCollectionObj[i].IsDirty = false;
						CertspParametriXLottoCollectionObj[i].IsPersistent = false;
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
		public static CertspParametriXLotto GetById(DbProvider db, int IdValue)
		{
			CertspParametriXLotto CertspParametriXLottoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspParametriXLottoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspParametriXLottoObj = GetFromDatareader(db);
				CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXLottoObj.IsDirty = false;
				CertspParametriXLottoObj.IsPersistent = true;
			}
			db.Close();
			return CertspParametriXLottoObj;
		}

		//getFromDatareader
		public static CertspParametriXLotto GetFromDatareader(DbProvider db)
		{
			CertspParametriXLotto CertspParametriXLottoObj = new CertspParametriXLotto();
			CertspParametriXLottoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspParametriXLottoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			CertspParametriXLottoObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
			CertspParametriXLottoObj.PesoReale = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO_REALE"]);
			CertspParametriXLottoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CertspParametriXLottoObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			CertspParametriXLottoObj.Peso = new SiarLibrary.NullTypes.IntNT(db.DataReader["PESO"]);
			CertspParametriXLottoObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspParametriXLottoObj.IsDirty = false;
			CertspParametriXLottoObj.IsPersistent = true;
			return CertspParametriXLottoObj;
		}

		//Find Select

		public static CertspParametriXLottoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, 
SiarLibrary.NullTypes.IntNT PesoRealeEqualThis)

		{

			CertspParametriXLottoCollection CertspParametriXLottoCollectionObj = new CertspParametriXLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametrixlottofindselect", new string[] {"Idequalthis", "IdLottoequalthis", "IdParametroequalthis", 
"PesoRealeequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PesoRealeequalthis", PesoRealeEqualThis);
			CertspParametriXLotto CertspParametriXLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriXLottoObj = GetFromDatareader(db);
				CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXLottoObj.IsDirty = false;
				CertspParametriXLottoObj.IsPersistent = true;
				CertspParametriXLottoCollectionObj.Add(CertspParametriXLottoObj);
			}
			db.Close();
			return CertspParametriXLottoCollectionObj;
		}

		//Find Find

		public static CertspParametriXLottoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.BoolNT ManualeEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			CertspParametriXLottoCollection CertspParametriXLottoCollectionObj = new CertspParametriXLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametrixlottofindfind", new string[] {"IdLottoequalthis", "IdParametroequalthis", "Manualeequalthis", 
"Descrizionelikethis"}, new string[] {"int", "int", "bool", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			CertspParametriXLotto CertspParametriXLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriXLottoObj = GetFromDatareader(db);
				CertspParametriXLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXLottoObj.IsDirty = false;
				CertspParametriXLottoObj.IsPersistent = true;
				CertspParametriXLottoCollectionObj.Add(CertspParametriXLottoObj);
			}
			db.Close();
			return CertspParametriXLottoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspParametriXLottoCollectionProvider:ICertspParametriXLottoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriXLottoCollectionProvider : ICertspParametriXLottoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspParametriXLotto
		protected CertspParametriXLottoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspParametriXLottoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspParametriXLottoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertspParametriXLottoCollectionProvider(IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, 
StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IdparametroEqualThis, ManualeEqualThis, 
DescrizioneLikeThis);
		}

		//Costruttore3: ha in input certspparametrixlottoCollectionObj - non popola la collection
		public CertspParametriXLottoCollectionProvider(CertspParametriXLottoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspParametriXLottoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspParametriXLottoCollection(this);
		}

		//Get e Set
		public CertspParametriXLottoCollection CollectionObj
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
		public int SaveCollection(CertspParametriXLottoCollection collectionObj)
		{
			return CertspParametriXLottoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspParametriXLotto certspparametrixlottoObj)
		{
			return CertspParametriXLottoDAL.Save(_dbProviderObj, certspparametrixlottoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspParametriXLottoCollection collectionObj)
		{
			return CertspParametriXLottoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspParametriXLotto certspparametrixlottoObj)
		{
			return CertspParametriXLottoDAL.Delete(_dbProviderObj, certspparametrixlottoObj);
		}

		//getById
		public CertspParametriXLotto GetById(IntNT IdValue)
		{
			CertspParametriXLotto CertspParametriXLottoTemp = CertspParametriXLottoDAL.GetById(_dbProviderObj, IdValue);
			if (CertspParametriXLottoTemp!=null) CertspParametriXLottoTemp.Provider = this;
			return CertspParametriXLottoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspParametriXLottoCollection Select(IntNT IdEqualThis, IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, 
IntNT PesorealeEqualThis)
		{
			CertspParametriXLottoCollection CertspParametriXLottoCollectionTemp = CertspParametriXLottoDAL.Select(_dbProviderObj, IdEqualThis, IdlottoEqualThis, IdparametroEqualThis, 
PesorealeEqualThis);
			CertspParametriXLottoCollectionTemp.Provider = this;
			return CertspParametriXLottoCollectionTemp;
		}

		//Find: popola la collection
		public CertspParametriXLottoCollection Find(IntNT IdlottoEqualThis, IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, 
StringNT DescrizioneLikeThis)
		{
			CertspParametriXLottoCollection CertspParametriXLottoCollectionTemp = CertspParametriXLottoDAL.Find(_dbProviderObj, IdlottoEqualThis, IdparametroEqualThis, ManualeEqualThis, 
DescrizioneLikeThis);
			CertspParametriXLottoCollectionTemp.Provider = this;
			return CertspParametriXLottoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_PARAMETRI_X_LOTTO>
  <ViewName>vCERTSP_PARAMETRI_X_LOTTO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_PARAMETRI_X_LOTTO>
*/
