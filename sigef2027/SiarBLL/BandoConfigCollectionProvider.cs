using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoConfig
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoConfigProvider
	{
		int Save(BandoConfig BandoConfigObj);
		int SaveCollection(BandoConfigCollection collectionObj);
		int Delete(BandoConfig BandoConfigObj);
		int DeleteCollection(BandoConfigCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoConfig
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoConfig: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Valore;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.IntNT _OperatoreInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _OperatoreFine;
		private NullTypes.StringNT _CodMacrotipo;
		private NullTypes.StringNT _Formato;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _TipoAttivo;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _ValoreDescrizione;
		[NonSerialized] private IBandoConfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoConfigProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoConfig()
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
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Valore
		{
			get { return _Valore; }
			set {
				if (Valore != value)
				{
					_Valore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INIZIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInizio
		{
			get { return _OperatoreInizio; }
			set {
				if (OperatoreInizio != value)
				{
					_OperatoreInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_FINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreFine
		{
			get { return _OperatoreFine; }
			set {
				if (OperatoreFine != value)
				{
					_OperatoreFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_MACROTIPO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodMacrotipo
		{
			get { return _CodMacrotipo; }
			set {
				if (CodMacrotipo != value)
				{
					_CodMacrotipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMATO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Formato
		{
			get { return _Formato; }
			set {
				if (Formato != value)
				{
					_Formato = value;
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
		/// Corrisponde al campo:TIPO_ATTIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TipoAttivo
		{
			get { return _TipoAttivo; }
			set {
				if (TipoAttivo != value)
				{
					_TipoAttivo = value;
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
		/// Corrisponde al campo:VALORE_DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT ValoreDescrizione
		{
			get { return _ValoreDescrizione; }
			set {
				if (ValoreDescrizione != value)
				{
					_ValoreDescrizione = value;
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
	/// Summary description for BandoConfigCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoConfigCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoConfigCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoConfig) info.GetValue(i.ToString(),typeof(BandoConfig)));
			}
		}

		//Costruttore
		public BandoConfigCollection()
		{
			this.ItemType = typeof(BandoConfig);
		}

		//Costruttore con provider
		public BandoConfigCollection(IBandoConfigProvider providerObj)
		{
			this.ItemType = typeof(BandoConfig);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoConfig this[int index]
		{
			get { return (BandoConfig)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoConfigCollection GetChanges()
		{
			return (BandoConfigCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoConfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoConfigProvider Provider
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
		public int Add(BandoConfig BandoConfigObj)
		{
			if (BandoConfigObj.Provider == null) BandoConfigObj.Provider = this.Provider;
			return base.Add(BandoConfigObj);
		}

		//AddCollection
		public void AddCollection(BandoConfigCollection BandoConfigCollectionObj)
		{
			foreach (BandoConfig BandoConfigObj in BandoConfigCollectionObj)
				this.Add(BandoConfigObj);
		}

		//Insert
		public void Insert(int index, BandoConfig BandoConfigObj)
		{
			if (BandoConfigObj.Provider == null) BandoConfigObj.Provider = this.Provider;
			base.Insert(index, BandoConfigObj);
		}

		//CollectionGetById
		public BandoConfig CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoConfigCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTipoEqualThis, 
NullTypes.StringNT ValoreEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, 
NullTypes.IntNT OperatoreInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OperatoreFineEqualThis)
		{
			BandoConfigCollection BandoConfigCollectionTemp = new BandoConfigCollection();
			foreach (BandoConfig BandoConfigItem in this)
			{
				if (((IdEqualThis == null) || ((BandoConfigItem.Id != null) && (BandoConfigItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoConfigItem.IdBando != null) && (BandoConfigItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((BandoConfigItem.CodTipo != null) && (BandoConfigItem.CodTipo.Value == CodTipoEqualThis.Value))) && 
((ValoreEqualThis == null) || ((BandoConfigItem.Valore != null) && (BandoConfigItem.Valore.Value == ValoreEqualThis.Value))) && ((AttivoEqualThis == null) || ((BandoConfigItem.Attivo != null) && (BandoConfigItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((BandoConfigItem.DataInizio != null) && (BandoConfigItem.DataInizio.Value == DataInizioEqualThis.Value))) && 
((OperatoreInizioEqualThis == null) || ((BandoConfigItem.OperatoreInizio != null) && (BandoConfigItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((BandoConfigItem.DataFine != null) && (BandoConfigItem.DataFine.Value == DataFineEqualThis.Value))) && ((OperatoreFineEqualThis == null) || ((BandoConfigItem.OperatoreFine != null) && (BandoConfigItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))))
				{
					BandoConfigCollectionTemp.Add(BandoConfigItem);
				}
			}
			return BandoConfigCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoConfigDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoConfigDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoConfig BandoConfigObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoConfigObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoConfigObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoConfigObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", BandoConfigObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BandoConfigObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", BandoConfigObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInizio", BandoConfigObj.OperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", BandoConfigObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreFine", BandoConfigObj.OperatoreFine);
		}
		//Insert
		private static int Insert(DbProvider db, BandoConfig BandoConfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoConfigInsert", new string[] {"IdBando", "CodTipo", 
"Valore", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "string", 
"string", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				CompileIUCmd(false, insertCmd,BandoConfigObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoConfigObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoConfigObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoConfigObj.IsDirty = false;
				BandoConfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoConfig BandoConfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoConfigUpdate", new string[] {"Id", "IdBando", "CodTipo", 
"Valore", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", "string", 
"string", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				CompileIUCmd(true, updateCmd,BandoConfigObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoConfigObj.IsDirty = false;
				BandoConfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoConfig BandoConfigObj)
		{
			switch (BandoConfigObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoConfigObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoConfigObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoConfigObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoConfigCollection BandoConfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoConfigUpdate", new string[] {"Id", "IdBando", "CodTipo", 
"Valore", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", "string", 
"string", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoConfigInsert", new string[] {"IdBando", "CodTipo", 
"Valore", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "string", 
"string", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoConfigDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoConfigCollectionObj.Count; i++)
				{
					switch (BandoConfigCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoConfigCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoConfigCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoConfigCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoConfigCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoConfigCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoConfigCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoConfigCollectionObj.Count; i++)
				{
					if ((BandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoConfigCollectionObj[i].IsDirty = false;
						BandoConfigCollectionObj[i].IsPersistent = true;
					}
					if ((BandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoConfigCollectionObj[i].IsDirty = false;
						BandoConfigCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoConfig BandoConfigObj)
		{
			int returnValue = 0;
			if (BandoConfigObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoConfigObj.Id);
			}
			BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoConfigObj.IsDirty = false;
			BandoConfigObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoConfigDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoConfigCollection BandoConfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoConfigDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoConfigCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoConfigCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoConfigCollectionObj.Count; i++)
				{
					if ((BandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoConfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoConfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoConfigCollectionObj[i].IsDirty = false;
						BandoConfigCollectionObj[i].IsPersistent = false;
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
		public static BandoConfig GetById(DbProvider db, int IdValue)
		{
			BandoConfig BandoConfigObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoConfigGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoConfigObj = GetFromDatareader(db);
				BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoConfigObj.IsDirty = false;
				BandoConfigObj.IsPersistent = true;
			}
			db.Close();
			return BandoConfigObj;
		}

		//getFromDatareader
		public static BandoConfig GetFromDatareader(DbProvider db)
		{
			BandoConfig BandoConfigObj = new BandoConfig();
			BandoConfigObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoConfigObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoConfigObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoConfigObj.Valore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE"]);
			BandoConfigObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoConfigObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			BandoConfigObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
			BandoConfigObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			BandoConfigObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
			BandoConfigObj.CodMacrotipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_MACROTIPO"]);
			BandoConfigObj.Formato = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMATO"]);
			BandoConfigObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoConfigObj.TipoAttivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TIPO_ATTIVO"]);
			BandoConfigObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoConfigObj.ValoreDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE_DESCRIZIONE"]);
			BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoConfigObj.IsDirty = false;
			BandoConfigObj.IsPersistent = true;
			return BandoConfigObj;
		}

		//Find Select

		public static BandoConfigCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, 
SiarLibrary.NullTypes.StringNT ValoreEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis)

		{

			BandoConfigCollection BandoConfigCollectionObj = new BandoConfigCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoconfigfindselect", new string[] {"Idequalthis", "IdBandoequalthis", "CodTipoequalthis", 
"Valoreequalthis", "Attivoequalthis", "DataInizioequalthis", 
"OperatoreInizioequalthis", "DataFineequalthis", "OperatoreFineequalthis"}, new string[] {"int", "int", "string", 
"string", "bool", "DateTime", 
"int", "DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
			BandoConfig BandoConfigObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoConfigObj = GetFromDatareader(db);
				BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoConfigObj.IsDirty = false;
				BandoConfigObj.IsPersistent = true;
				BandoConfigCollectionObj.Add(BandoConfigObj);
			}
			db.Close();
			return BandoConfigCollectionObj;
		}

		//Find Find

		public static BandoConfigCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodMacrotipoLikeThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.BoolNT TipoAttivoEqualThis)

		{

			BandoConfigCollection BandoConfigCollectionObj = new BandoConfigCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoconfigfindfind", new string[] {"IdBandoequalthis", "CodTipoequalthis", "CodMacrotipolikethis", 
"Attivoequalthis", "TipoAttivoequalthis"}, new string[] {"int", "string", "string", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodMacrotipolikethis", CodMacrotipoLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoAttivoequalthis", TipoAttivoEqualThis);
			BandoConfig BandoConfigObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoConfigObj = GetFromDatareader(db);
				BandoConfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoConfigObj.IsDirty = false;
				BandoConfigObj.IsPersistent = true;
				BandoConfigCollectionObj.Add(BandoConfigObj);
			}
			db.Close();
			return BandoConfigCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoConfigCollectionProvider:IBandoConfigProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoConfigCollectionProvider : IBandoConfigProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoConfig
		protected BandoConfigCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoConfigCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoConfigCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoConfigCollectionProvider(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, StringNT CodmacrotipoLikeThis, 
BoolNT AttivoEqualThis, BoolNT TipoattivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoEqualThis, CodmacrotipoLikeThis, 
AttivoEqualThis, TipoattivoEqualThis);
		}

		//Costruttore3: ha in input bandoconfigCollectionObj - non popola la collection
		public BandoConfigCollectionProvider(BandoConfigCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoConfigCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoConfigCollection(this);
		}

		//Get e Set
		public BandoConfigCollection CollectionObj
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
		public int SaveCollection(BandoConfigCollection collectionObj)
		{
			return BandoConfigDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoConfig bandoconfigObj)
		{
			return BandoConfigDAL.Save(_dbProviderObj, bandoconfigObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoConfigCollection collectionObj)
		{
			return BandoConfigDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoConfig bandoconfigObj)
		{
			return BandoConfigDAL.Delete(_dbProviderObj, bandoconfigObj);
		}

		//getById
		public BandoConfig GetById(IntNT IdValue)
		{
			BandoConfig BandoConfigTemp = BandoConfigDAL.GetById(_dbProviderObj, IdValue);
			if (BandoConfigTemp!=null) BandoConfigTemp.Provider = this;
			return BandoConfigTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoConfigCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, 
StringNT ValoreEqualThis, BoolNT AttivoEqualThis, DatetimeNT DatainizioEqualThis, 
IntNT OperatoreinizioEqualThis, DatetimeNT DatafineEqualThis, IntNT OperatorefineEqualThis)
		{
			BandoConfigCollection BandoConfigCollectionTemp = BandoConfigDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, CodtipoEqualThis, 
ValoreEqualThis, AttivoEqualThis, DatainizioEqualThis, 
OperatoreinizioEqualThis, DatafineEqualThis, OperatorefineEqualThis);
			BandoConfigCollectionTemp.Provider = this;
			return BandoConfigCollectionTemp;
		}

		//Find: popola la collection
		public BandoConfigCollection Find(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, StringNT CodmacrotipoLikeThis, 
BoolNT AttivoEqualThis, BoolNT TipoattivoEqualThis)
		{
			BandoConfigCollection BandoConfigCollectionTemp = BandoConfigDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, CodmacrotipoLikeThis, 
AttivoEqualThis, TipoattivoEqualThis);
			BandoConfigCollectionTemp.Provider = this;
			return BandoConfigCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_CONFIG>
  <ViewName>vBANDO_CONFIG</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, DATA_INIZIO DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <COD_MACROTIPO>Like</COD_MACROTIPO>
      <ATTIVO>Equal</ATTIVO>
      <TIPO_ATTIVO>Equal</TIPO_ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_CONFIG>
*/
