using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RecuperoBeneficiarioOrdinativoIncasso
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRecuperoBeneficiarioOrdinativoIncassoProvider
	{
		int Save(RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj);
		int SaveCollection(RecuperoBeneficiarioOrdinativoIncassoCollection collectionObj);
		int Delete(RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj);
		int DeleteCollection(RecuperoBeneficiarioOrdinativoIncassoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RecuperoBeneficiarioOrdinativoIncasso
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RecuperoBeneficiarioOrdinativoIncasso: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdOrdinativoIncasso;
		private NullTypes.IntNT _IdRecuperoBeneficiario;
		private NullTypes.IntNT _IdFileMandato;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _Quietanza;
		[NonSerialized] private IRecuperoBeneficiarioOrdinativoIncassoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRecuperoBeneficiarioOrdinativoIncassoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RecuperoBeneficiarioOrdinativoIncasso()
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
		/// Corrisponde al campo:ID_RECUPERO_BENEFICIARIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRecuperoBeneficiario
		{
			get { return _IdRecuperoBeneficiario; }
			set {
				if (IdRecuperoBeneficiario != value)
				{
					_IdRecuperoBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE_MANDATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFileMandato
		{
			get { return _IdFileMandato; }
			set {
				if (IdFileMandato != value)
				{
					_IdFileMandato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUIETANZA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT Quietanza
		{
			get { return _Quietanza; }
			set {
				if (Quietanza != value)
				{
					_Quietanza = value;
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
	/// Summary description for RecuperoBeneficiarioOrdinativoIncassoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RecuperoBeneficiarioOrdinativoIncassoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RecuperoBeneficiarioOrdinativoIncassoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RecuperoBeneficiarioOrdinativoIncasso) info.GetValue(i.ToString(),typeof(RecuperoBeneficiarioOrdinativoIncasso)));
			}
		}

		//Costruttore
		public RecuperoBeneficiarioOrdinativoIncassoCollection()
		{
			this.ItemType = typeof(RecuperoBeneficiarioOrdinativoIncasso);
		}

		//Costruttore con provider
		public RecuperoBeneficiarioOrdinativoIncassoCollection(IRecuperoBeneficiarioOrdinativoIncassoProvider providerObj)
		{
			this.ItemType = typeof(RecuperoBeneficiarioOrdinativoIncasso);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RecuperoBeneficiarioOrdinativoIncasso this[int index]
		{
			get { return (RecuperoBeneficiarioOrdinativoIncasso)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RecuperoBeneficiarioOrdinativoIncassoCollection GetChanges()
		{
			return (RecuperoBeneficiarioOrdinativoIncassoCollection) base.GetChanges();
		}

		[NonSerialized] private IRecuperoBeneficiarioOrdinativoIncassoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRecuperoBeneficiarioOrdinativoIncassoProvider Provider
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
		public int Add(RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			if (RecuperoBeneficiarioOrdinativoIncassoObj.Provider == null) RecuperoBeneficiarioOrdinativoIncassoObj.Provider = this.Provider;
			return base.Add(RecuperoBeneficiarioOrdinativoIncassoObj);
		}

		//AddCollection
		public void AddCollection(RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionObj)
		{
			foreach (RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj in RecuperoBeneficiarioOrdinativoIncassoCollectionObj)
				this.Add(RecuperoBeneficiarioOrdinativoIncassoObj);
		}

		//Insert
		public void Insert(int index, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			if (RecuperoBeneficiarioOrdinativoIncassoObj.Provider == null) RecuperoBeneficiarioOrdinativoIncassoObj.Provider = this.Provider;
			base.Insert(index, RecuperoBeneficiarioOrdinativoIncassoObj);
		}

		//CollectionGetById
		public RecuperoBeneficiarioOrdinativoIncasso CollectionGetById(NullTypes.IntNT IdOrdinativoIncassoValue)
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
		public RecuperoBeneficiarioOrdinativoIncassoCollection SubSelect(NullTypes.IntNT IdOrdinativoIncassoEqualThis, NullTypes.IntNT IdRecuperoBeneficiarioEqualThis, NullTypes.IntNT IdFileMandatoEqualThis, 
NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.DecimalNT ImportoEqualThis, 
NullTypes.DecimalNT QuietanzaEqualThis)
		{
			RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionTemp = new RecuperoBeneficiarioOrdinativoIncassoCollection();
			foreach (RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoItem in this)
			{
				if (((IdOrdinativoIncassoEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.IdOrdinativoIncasso != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.IdOrdinativoIncasso.Value == IdOrdinativoIncassoEqualThis.Value))) && ((IdRecuperoBeneficiarioEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.IdRecuperoBeneficiario != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.IdRecuperoBeneficiario.Value == IdRecuperoBeneficiarioEqualThis.Value))) && ((IdFileMandatoEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.IdFileMandato != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.IdFileMandato.Value == IdFileMandatoEqualThis.Value))) && 
((NumeroEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.Numero != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.Data != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.Data.Value == DataEqualThis.Value))) && ((ImportoEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.Importo != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.Importo.Value == ImportoEqualThis.Value))) && 
((QuietanzaEqualThis == null) || ((RecuperoBeneficiarioOrdinativoIncassoItem.Quietanza != null) && (RecuperoBeneficiarioOrdinativoIncassoItem.Quietanza.Value == QuietanzaEqualThis.Value))))
				{
					RecuperoBeneficiarioOrdinativoIncassoCollectionTemp.Add(RecuperoBeneficiarioOrdinativoIncassoItem);
				}
			}
			return RecuperoBeneficiarioOrdinativoIncassoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RecuperoBeneficiarioOrdinativoIncassoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RecuperoBeneficiarioOrdinativoIncassoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdOrdinativoIncasso", RecuperoBeneficiarioOrdinativoIncassoObj.IdOrdinativoIncasso);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRecuperoBeneficiario", RecuperoBeneficiarioOrdinativoIncassoObj.IdRecuperoBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFileMandato", RecuperoBeneficiarioOrdinativoIncassoObj.IdFileMandato);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", RecuperoBeneficiarioOrdinativoIncassoObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", RecuperoBeneficiarioOrdinativoIncassoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", RecuperoBeneficiarioOrdinativoIncassoObj.Importo);
			DbProvider.SetCmdParam(cmd,firstChar + "Quietanza", RecuperoBeneficiarioOrdinativoIncassoObj.Quietanza);
		}
		//Insert
		private static int Insert(DbProvider db, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoInsert", new string[] {"IdRecuperoBeneficiario", "IdFileMandato", 
"Numero", "Data", "Importo", 
"Quietanza"}, new string[] {"int", "int", 
"string", "DateTime", "decimal", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,RecuperoBeneficiarioOrdinativoIncassoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RecuperoBeneficiarioOrdinativoIncassoObj.IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
				}
				RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoUpdate", new string[] {"IdOrdinativoIncasso", "IdRecuperoBeneficiario", "IdFileMandato", 
"Numero", "Data", "Importo", 
"Quietanza"}, new string[] {"int", "int", "int", 
"string", "DateTime", "decimal", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,RecuperoBeneficiarioOrdinativoIncassoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			switch (RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RecuperoBeneficiarioOrdinativoIncassoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RecuperoBeneficiarioOrdinativoIncassoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RecuperoBeneficiarioOrdinativoIncassoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoUpdate", new string[] {"IdOrdinativoIncasso", "IdRecuperoBeneficiario", "IdFileMandato", 
"Numero", "Data", "Importo", 
"Quietanza"}, new string[] {"int", "int", "int", 
"string", "DateTime", "decimal", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoInsert", new string[] {"IdRecuperoBeneficiario", "IdFileMandato", 
"Numero", "Data", "Importo", 
"Quietanza"}, new string[] {"int", "int", 
"string", "DateTime", "decimal", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				for (int i = 0; i < RecuperoBeneficiarioOrdinativoIncassoCollectionObj.Count; i++)
				{
					switch (RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RecuperoBeneficiarioOrdinativoIncassoCollectionObj.Count; i++)
				{
					if ((RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsPersistent = true;
					}
					if ((RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj)
		{
			int returnValue = 0;
			if (RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent) 
			{
				returnValue = Delete(db, RecuperoBeneficiarioOrdinativoIncassoObj.IdOrdinativoIncasso);
			}
			RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
			RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdOrdinativoIncassoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)IdOrdinativoIncassoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoDelete", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
				for (int i = 0; i < RecuperoBeneficiarioOrdinativoIncassoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdOrdinativoIncasso", RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IdOrdinativoIncasso);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RecuperoBeneficiarioOrdinativoIncassoCollectionObj.Count; i++)
				{
					if ((RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsDirty = false;
						RecuperoBeneficiarioOrdinativoIncassoCollectionObj[i].IsPersistent = false;
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
		public static RecuperoBeneficiarioOrdinativoIncasso GetById(DbProvider db, int IdOrdinativoIncassoValue)
		{
			RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRecuperoBeneficiarioOrdinativoIncassoGetById", new string[] {"IdOrdinativoIncasso"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdOrdinativoIncasso", (SiarLibrary.NullTypes.IntNT)IdOrdinativoIncassoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RecuperoBeneficiarioOrdinativoIncassoObj = GetFromDatareader(db);
				RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = true;
			}
			db.Close();
			return RecuperoBeneficiarioOrdinativoIncassoObj;
		}

		//getFromDatareader
		public static RecuperoBeneficiarioOrdinativoIncasso GetFromDatareader(DbProvider db)
		{
			RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj = new RecuperoBeneficiarioOrdinativoIncasso();
			RecuperoBeneficiarioOrdinativoIncassoObj.IdOrdinativoIncasso = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ORDINATIVO_INCASSO"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.IdRecuperoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RECUPERO_BENEFICIARIO"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.IdFileMandato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_MANDATO"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.Quietanza = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUIETANZA"]);
			RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
			RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = true;
			return RecuperoBeneficiarioOrdinativoIncassoObj;
		}

		//Find Select

		public static RecuperoBeneficiarioOrdinativoIncassoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdOrdinativoIncassoEqualThis, SiarLibrary.NullTypes.IntNT IdRecuperoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdFileMandatoEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuietanzaEqualThis)

		{

			RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionObj = new RecuperoBeneficiarioOrdinativoIncassoCollection();

			IDbCommand findCmd = db.InitCmd("Zrecuperobeneficiarioordinativoincassofindselect", new string[] {"IdOrdinativoIncassoequalthis", "IdRecuperoBeneficiarioequalthis", "IdFileMandatoequalthis", 
"Numeroequalthis", "Dataequalthis", "Importoequalthis", 
"Quietanzaequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOrdinativoIncassoequalthis", IdOrdinativoIncassoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRecuperoBeneficiarioequalthis", IdRecuperoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileMandatoequalthis", IdFileMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quietanzaequalthis", QuietanzaEqualThis);
			RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RecuperoBeneficiarioOrdinativoIncassoObj = GetFromDatareader(db);
				RecuperoBeneficiarioOrdinativoIncassoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsDirty = false;
				RecuperoBeneficiarioOrdinativoIncassoObj.IsPersistent = true;
				RecuperoBeneficiarioOrdinativoIncassoCollectionObj.Add(RecuperoBeneficiarioOrdinativoIncassoObj);
			}
			db.Close();
			return RecuperoBeneficiarioOrdinativoIncassoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RecuperoBeneficiarioOrdinativoIncassoCollectionProvider:IRecuperoBeneficiarioOrdinativoIncassoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RecuperoBeneficiarioOrdinativoIncassoCollectionProvider : IRecuperoBeneficiarioOrdinativoIncassoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RecuperoBeneficiarioOrdinativoIncasso
		protected RecuperoBeneficiarioOrdinativoIncassoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RecuperoBeneficiarioOrdinativoIncassoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RecuperoBeneficiarioOrdinativoIncassoCollection(this);
		}

		//Costruttore3: ha in input recuperobeneficiarioordinativoincassoCollectionObj - non popola la collection
		public RecuperoBeneficiarioOrdinativoIncassoCollectionProvider(RecuperoBeneficiarioOrdinativoIncassoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RecuperoBeneficiarioOrdinativoIncassoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RecuperoBeneficiarioOrdinativoIncassoCollection(this);
		}

		//Get e Set
		public RecuperoBeneficiarioOrdinativoIncassoCollection CollectionObj
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
		public int SaveCollection(RecuperoBeneficiarioOrdinativoIncassoCollection collectionObj)
		{
			return RecuperoBeneficiarioOrdinativoIncassoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RecuperoBeneficiarioOrdinativoIncasso recuperobeneficiarioordinativoincassoObj)
		{
			return RecuperoBeneficiarioOrdinativoIncassoDAL.Save(_dbProviderObj, recuperobeneficiarioordinativoincassoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RecuperoBeneficiarioOrdinativoIncassoCollection collectionObj)
		{
			return RecuperoBeneficiarioOrdinativoIncassoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RecuperoBeneficiarioOrdinativoIncasso recuperobeneficiarioordinativoincassoObj)
		{
			return RecuperoBeneficiarioOrdinativoIncassoDAL.Delete(_dbProviderObj, recuperobeneficiarioordinativoincassoObj);
		}

		//getById
		public RecuperoBeneficiarioOrdinativoIncasso GetById(IntNT IdOrdinativoIncassoValue)
		{
			RecuperoBeneficiarioOrdinativoIncasso RecuperoBeneficiarioOrdinativoIncassoTemp = RecuperoBeneficiarioOrdinativoIncassoDAL.GetById(_dbProviderObj, IdOrdinativoIncassoValue);
			if (RecuperoBeneficiarioOrdinativoIncassoTemp!=null) RecuperoBeneficiarioOrdinativoIncassoTemp.Provider = this;
			return RecuperoBeneficiarioOrdinativoIncassoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RecuperoBeneficiarioOrdinativoIncassoCollection Select(IntNT IdordinativoincassoEqualThis, IntNT IdrecuperobeneficiarioEqualThis, IntNT IdfilemandatoEqualThis, 
StringNT NumeroEqualThis, DatetimeNT DataEqualThis, DecimalNT ImportoEqualThis, 
DecimalNT QuietanzaEqualThis)
		{
			RecuperoBeneficiarioOrdinativoIncassoCollection RecuperoBeneficiarioOrdinativoIncassoCollectionTemp = RecuperoBeneficiarioOrdinativoIncassoDAL.Select(_dbProviderObj, IdordinativoincassoEqualThis, IdrecuperobeneficiarioEqualThis, IdfilemandatoEqualThis, 
NumeroEqualThis, DataEqualThis, ImportoEqualThis, 
QuietanzaEqualThis);
			RecuperoBeneficiarioOrdinativoIncassoCollectionTemp.Provider = this;
			return RecuperoBeneficiarioOrdinativoIncassoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO>
*/
