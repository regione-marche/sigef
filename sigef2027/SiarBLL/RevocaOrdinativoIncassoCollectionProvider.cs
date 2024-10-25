using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RevocaOrdinativoIncasso
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRevocaOrdinativoIncassoProvider
	{
		int Save(RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj);
		int SaveCollection(RevocaOrdinativoIncassoCollection collectionObj);
		int Delete(RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj);
		int DeleteCollection(RevocaOrdinativoIncassoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RevocaOrdinativoIncasso
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RevocaOrdinativoIncasso: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdOrdinativoIncasso;
		private NullTypes.IntNT _IdRevoca;
		private NullTypes.StringNT _OrdinativoIncasso;
		private NullTypes.DatetimeNT _DataOrdinativo;
		private NullTypes.DecimalNT _ImportoOrdinativo;
		private NullTypes.DatetimeNT _DataInserimento;
		[NonSerialized] private IRevocaOrdinativoIncassoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevocaOrdinativoIncassoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RevocaOrdinativoIncasso()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ORDINATIVO_INCASSO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOrdinativoIncasso
		{
			get { return _IdOrdinativoIncasso; }
			set {
				if (IdOrdinativoIncasso != value)
				{
					_IdOrdinativoIncasso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_REVOCA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRevoca
		{
			get { return _IdRevoca; }
			set {
				if (IdRevoca != value)
				{
					_IdRevoca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINATIVO_INCASSO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT OrdinativoIncasso
		{
			get { return _OrdinativoIncasso; }
			set {
				if (OrdinativoIncasso != value)
				{
					_OrdinativoIncasso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ORDINATIVO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataOrdinativo
		{
			get { return _DataOrdinativo; }
			set {
				if (DataOrdinativo != value)
				{
					_DataOrdinativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_ORDINATIVO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoOrdinativo
		{
			get { return _ImportoOrdinativo; }
			set {
				if (ImportoOrdinativo != value)
				{
					_ImportoOrdinativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
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
	/// Summary description for RevocaOrdinativoIncassoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevocaOrdinativoIncassoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RevocaOrdinativoIncassoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RevocaOrdinativoIncasso) info.GetValue(i.ToString(),typeof(RevocaOrdinativoIncasso)));
			}
		}

		//Costruttore
		public RevocaOrdinativoIncassoCollection()
		{
			this.ItemType = typeof(RevocaOrdinativoIncasso);
		}

		//Costruttore con provider
		public RevocaOrdinativoIncassoCollection(IRevocaOrdinativoIncassoProvider providerObj)
		{
			this.ItemType = typeof(RevocaOrdinativoIncasso);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RevocaOrdinativoIncasso this[int index]
		{
			get { return (RevocaOrdinativoIncasso)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RevocaOrdinativoIncassoCollection GetChanges()
		{
			return (RevocaOrdinativoIncassoCollection) base.GetChanges();
		}

		[NonSerialized] private IRevocaOrdinativoIncassoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevocaOrdinativoIncassoProvider Provider
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
		public int Add(RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			if (RevocaOrdinativoIncassoObj.Provider == null) RevocaOrdinativoIncassoObj.Provider = this.Provider;
			return base.Add(RevocaOrdinativoIncassoObj);
		}

		//AddCollection
		public void AddCollection(RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionObj)
		{
			foreach (RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj in RevocaOrdinativoIncassoCollectionObj)
				this.Add(RevocaOrdinativoIncassoObj);
		}

		//Insert
		public void Insert(int index, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			if (RevocaOrdinativoIncassoObj.Provider == null) RevocaOrdinativoIncassoObj.Provider = this.Provider;
			base.Insert(index, RevocaOrdinativoIncassoObj);
		}

		//CollectionGetById
		public RevocaOrdinativoIncasso CollectionGetById(NullTypes.IntNT IdOrdinativoIncassoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdOrdinativoIncasso == IdOrdinativoIncassoValue))
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
		public RevocaOrdinativoIncassoCollection SubSelect(NullTypes.IntNT IdOrdinativoIncassoEqualThis, NullTypes.IntNT IdRevocaEqualThis, NullTypes.StringNT OrdinativoIncassoEqualThis, 
NullTypes.DatetimeNT DataOrdinativoEqualThis, NullTypes.DecimalNT ImportoOrdinativoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis)
		{
			RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionTemp = new RevocaOrdinativoIncassoCollection();
			foreach (RevocaOrdinativoIncasso RevocaOrdinativoIncassoItem in this)
			{
				if (((IdOrdinativoIncassoEqualThis == null) || ((RevocaOrdinativoIncassoItem.IdOrdinativoIncasso != null) && (RevocaOrdinativoIncassoItem.IdOrdinativoIncasso.Value == IdOrdinativoIncassoEqualThis.Value))) && ((IdRevocaEqualThis == null) || ((RevocaOrdinativoIncassoItem.IdRevoca != null) && (RevocaOrdinativoIncassoItem.IdRevoca.Value == IdRevocaEqualThis.Value))) && ((OrdinativoIncassoEqualThis == null) || ((RevocaOrdinativoIncassoItem.OrdinativoIncasso != null) && (RevocaOrdinativoIncassoItem.OrdinativoIncasso.Value == OrdinativoIncassoEqualThis.Value))) && 
((DataOrdinativoEqualThis == null) || ((RevocaOrdinativoIncassoItem.DataOrdinativo != null) && (RevocaOrdinativoIncassoItem.DataOrdinativo.Value == DataOrdinativoEqualThis.Value))) && ((ImportoOrdinativoEqualThis == null) || ((RevocaOrdinativoIncassoItem.ImportoOrdinativo != null) && (RevocaOrdinativoIncassoItem.ImportoOrdinativo.Value == ImportoOrdinativoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RevocaOrdinativoIncassoItem.DataInserimento != null) && (RevocaOrdinativoIncassoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))))
				{
					RevocaOrdinativoIncassoCollectionTemp.Add(RevocaOrdinativoIncassoItem);
				}
			}
			return RevocaOrdinativoIncassoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RevocaOrdinativoIncassoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RevocaOrdinativoIncassoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdOrdinativoIncasso", RevocaOrdinativoIncassoObj.IdOrdinativoIncasso);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRevoca", RevocaOrdinativoIncassoObj.IdRevoca);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdinativoIncasso", RevocaOrdinativoIncassoObj.OrdinativoIncasso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataOrdinativo", RevocaOrdinativoIncassoObj.DataOrdinativo);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoOrdinativo", RevocaOrdinativoIncassoObj.ImportoOrdinativo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RevocaOrdinativoIncassoObj.DataInserimento);
		}
		//Insert
		private static int Insert(DbProvider db, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRevocaOrdinativoIncassoInsert", new string[] {"IdRevoca", "OrdinativoIncasso", 
"DataOrdinativo", "ImportoOrdinativo", "DataInserimento"}, new string[] {"int", "string", 
"DateTime", "decimal", "DateTime"},"");
				CompileIUCmd(false, insertCmd,RevocaOrdinativoIncassoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RevocaOrdinativoIncassoObj.IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
				RevocaOrdinativoIncassoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				}
				RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaOrdinativoIncassoObj.IsDirty = false;
				RevocaOrdinativoIncassoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevocaOrdinativoIncassoUpdate", new string[] {"IdOrdinativoIncasso", "IdRevoca", "OrdinativoIncasso", 
"DataOrdinativo", "ImportoOrdinativo", "DataInserimento"}, new string[] {"int", "int", "string", 
"DateTime", "decimal", "DateTime"},"");
				CompileIUCmd(true, updateCmd,RevocaOrdinativoIncassoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaOrdinativoIncassoObj.IsDirty = false;
				RevocaOrdinativoIncassoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			switch (RevocaOrdinativoIncassoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RevocaOrdinativoIncassoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RevocaOrdinativoIncassoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RevocaOrdinativoIncassoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevocaOrdinativoIncassoUpdate", new string[] {"IdOrdinativoIncasso", "IdRevoca", "OrdinativoIncasso", 
"DataOrdinativo", "ImportoOrdinativo", "DataInserimento"}, new string[] {"int", "int", "string", 
"DateTime", "decimal", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRevocaOrdinativoIncassoInsert", new string[] {"IdRevoca", "OrdinativoIncasso", 
"DataOrdinativo", "ImportoOrdinativo", "DataInserimento"}, new string[] {"int", "string", 
"DateTime", "decimal", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRevocaOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				for (int i = 0; i < RevocaOrdinativoIncassoCollectionObj.Count; i++)
				{
					switch (RevocaOrdinativoIncassoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RevocaOrdinativoIncassoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RevocaOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
									RevocaOrdinativoIncassoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RevocaOrdinativoIncassoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RevocaOrdinativoIncassoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)RevocaOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RevocaOrdinativoIncassoCollectionObj.Count; i++)
				{
					if ((RevocaOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevocaOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevocaOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RevocaOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RevocaOrdinativoIncassoCollectionObj[i].IsPersistent = true;
					}
					if ((RevocaOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RevocaOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevocaOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RevocaOrdinativoIncassoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj)
		{
			int returnValue = 0;
			if (RevocaOrdinativoIncassoObj.IsPersistent) 
			{
				returnValue = Delete(db, RevocaOrdinativoIncassoObj.IdOrdinativoIncasso);
			}
			RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RevocaOrdinativoIncassoObj.IsDirty = false;
			RevocaOrdinativoIncassoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdOrdinativoIncassoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevocaOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)IdOrdinativoIncassoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevocaOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				for (int i = 0; i < RevocaOrdinativoIncassoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", RevocaOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RevocaOrdinativoIncassoCollectionObj.Count; i++)
				{
					if ((RevocaOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevocaOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevocaOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevocaOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RevocaOrdinativoIncassoCollectionObj[i].IsPersistent = false;
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
		public static RevocaOrdinativoIncasso GetById(DbProvider db, int IdOrdinativoIncassoValue)
		{
			RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRevocaOrdinativoIncassoGetById", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)IdOrdinativoIncassoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RevocaOrdinativoIncassoObj = GetFromDatareader(db);
				RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaOrdinativoIncassoObj.IsDirty = false;
				RevocaOrdinativoIncassoObj.IsPersistent = true;
			}
			db.Close();
			return RevocaOrdinativoIncassoObj;
		}

		//getFromDatareader
		public static RevocaOrdinativoIncasso GetFromDatareader(DbProvider db)
		{
			RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj = new RevocaOrdinativoIncasso();
			RevocaOrdinativoIncassoObj.IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
			RevocaOrdinativoIncassoObj.IdRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REVOCA"]);
			RevocaOrdinativoIncassoObj.OrdinativoIncasso = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORDINATIVO_INCASSO"]);
			RevocaOrdinativoIncassoObj.DataOrdinativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ORDINATIVO"]);
			RevocaOrdinativoIncassoObj.ImportoOrdinativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_ORDINATIVO"]);
			RevocaOrdinativoIncassoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RevocaOrdinativoIncassoObj.IsDirty = false;
			RevocaOrdinativoIncassoObj.IsPersistent = true;
			return RevocaOrdinativoIncassoObj;
		}

		//Find Select

		public static RevocaOrdinativoIncassoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdOrdinativoIncassoEqualThis, SiarLibrary.NullTypes.IntNT IdRevocaEqualThis, SiarLibrary.NullTypes.StringNT OrdinativoIncassoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataOrdinativoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoOrdinativoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis)

		{

			RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionObj = new RevocaOrdinativoIncassoCollection();

			IDbCommand findCmd = db.InitCmd("Zrevocaordinativoincassofindselect", new string[] {"IdOrdinativoIncassoequalthis", "IdRevocaequalthis", "OrdinativoIncassoequalthis", 
"DataOrdinativoequalthis", "ImportoOrdinativoequalthis", "DataInserimentoequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "decimal", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOrdinativoIncassoequalthis", IdOrdinativoIncassoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRevocaequalthis", IdRevocaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdinativoIncassoequalthis", OrdinativoIncassoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataOrdinativoequalthis", DataOrdinativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoOrdinativoequalthis", ImportoOrdinativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			RevocaOrdinativoIncasso RevocaOrdinativoIncassoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevocaOrdinativoIncassoObj = GetFromDatareader(db);
				RevocaOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevocaOrdinativoIncassoObj.IsDirty = false;
				RevocaOrdinativoIncassoObj.IsPersistent = true;
				RevocaOrdinativoIncassoCollectionObj.Add(RevocaOrdinativoIncassoObj);
			}
			db.Close();
			return RevocaOrdinativoIncassoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RevocaOrdinativoIncassoCollectionProvider:IRevocaOrdinativoIncassoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevocaOrdinativoIncassoCollectionProvider : IRevocaOrdinativoIncassoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RevocaOrdinativoIncasso
		protected RevocaOrdinativoIncassoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RevocaOrdinativoIncassoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RevocaOrdinativoIncassoCollection(this);
		}

		//Costruttore3: ha in input revocaordinativoincassoCollectionObj - non popola la collection
		public RevocaOrdinativoIncassoCollectionProvider(RevocaOrdinativoIncassoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RevocaOrdinativoIncassoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RevocaOrdinativoIncassoCollection(this);
		}

		//Get e Set
		public RevocaOrdinativoIncassoCollection CollectionObj
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
		public int SaveCollection(RevocaOrdinativoIncassoCollection collectionObj)
		{
			return RevocaOrdinativoIncassoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RevocaOrdinativoIncasso revocaordinativoincassoObj)
		{
			return RevocaOrdinativoIncassoDAL.Save(_dbProviderObj, revocaordinativoincassoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RevocaOrdinativoIncassoCollection collectionObj)
		{
			return RevocaOrdinativoIncassoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RevocaOrdinativoIncasso revocaordinativoincassoObj)
		{
			return RevocaOrdinativoIncassoDAL.Delete(_dbProviderObj, revocaordinativoincassoObj);
		}

		//getById
		public RevocaOrdinativoIncasso GetById(IntNT IdOrdinativoIncassoValue)
		{
			RevocaOrdinativoIncasso RevocaOrdinativoIncassoTemp = RevocaOrdinativoIncassoDAL.GetById(_dbProviderObj, IdOrdinativoIncassoValue);
			if (RevocaOrdinativoIncassoTemp!=null) RevocaOrdinativoIncassoTemp.Provider = this;
			return RevocaOrdinativoIncassoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RevocaOrdinativoIncassoCollection Select(IntNT IdordinativoincassoEqualThis, IntNT IdrevocaEqualThis, StringNT OrdinativoincassoEqualThis, 
DatetimeNT DataordinativoEqualThis, DecimalNT ImportoordinativoEqualThis, DatetimeNT DatainserimentoEqualThis)
		{
			RevocaOrdinativoIncassoCollection RevocaOrdinativoIncassoCollectionTemp = RevocaOrdinativoIncassoDAL.Select(_dbProviderObj, IdordinativoincassoEqualThis, IdrevocaEqualThis, OrdinativoincassoEqualThis, 
DataordinativoEqualThis, ImportoordinativoEqualThis, DatainserimentoEqualThis);
			RevocaOrdinativoIncassoCollectionTemp.Provider = this;
			return RevocaOrdinativoIncassoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REVOCA_ORDINATIVO_INCASSO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</REVOCA_ORDINATIVO_INCASSO>
*/
