using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZprogrammazioneFonti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZprogrammazioneFontiProvider
	{
		int Save(ZprogrammazioneFonti ZprogrammazioneFontiObj);
		int SaveCollection(ZprogrammazioneFontiCollection collectionObj);
		int Delete(ZprogrammazioneFonti ZprogrammazioneFontiObj);
		int DeleteCollection(ZprogrammazioneFontiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZprogrammazioneFonti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZprogrammazioneFonti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.IntNT _IdFonte;
		private NullTypes.DecimalNT _Percentuale;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.IntNT _OperatoreInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _OperatoreFine;
		private NullTypes.BoolNT _Attiva;
		private NullTypes.DecimalNT _PercentualeFonte;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _NominativoInizio;
		private NullTypes.StringNT _NominativoFine;
		[NonSerialized] private IZprogrammazioneFontiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZprogrammazioneFontiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZprogrammazioneFonti()
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
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Tipo sul db:DECIMAL(10,2)
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
		/// Corrisponde al campo:ATTIVA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Attiva
		{
			get { return _Attiva; }
			set {
				if (Attiva != value)
				{
					_Attiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERCENTUALE_FONTE
		/// Tipo sul db:DECIMAL(10,3)
		/// </summary>
		public NullTypes.DecimalNT PercentualeFonte
		{
			get { return _PercentualeFonte; }
			set {
				if (PercentualeFonte != value)
				{
					_PercentualeFonte = value;
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
		/// Corrisponde al campo:NOMINATIVO_INIZIO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoInizio
		{
			get { return _NominativoInizio; }
			set {
				if (NominativoInizio != value)
				{
					_NominativoInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_FINE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoFine
		{
			get { return _NominativoFine; }
			set {
				if (NominativoFine != value)
				{
					_NominativoFine = value;
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
	/// Summary description for ZprogrammazioneFontiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZprogrammazioneFontiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZprogrammazioneFontiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZprogrammazioneFonti) info.GetValue(i.ToString(),typeof(ZprogrammazioneFonti)));
			}
		}

		//Costruttore
		public ZprogrammazioneFontiCollection()
		{
			this.ItemType = typeof(ZprogrammazioneFonti);
		}

		//Costruttore con provider
		public ZprogrammazioneFontiCollection(IZprogrammazioneFontiProvider providerObj)
		{
			this.ItemType = typeof(ZprogrammazioneFonti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZprogrammazioneFonti this[int index]
		{
			get { return (ZprogrammazioneFonti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZprogrammazioneFontiCollection GetChanges()
		{
			return (ZprogrammazioneFontiCollection) base.GetChanges();
		}

		[NonSerialized] private IZprogrammazioneFontiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZprogrammazioneFontiProvider Provider
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
		public int Add(ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			if (ZprogrammazioneFontiObj.Provider == null) ZprogrammazioneFontiObj.Provider = this.Provider;
			return base.Add(ZprogrammazioneFontiObj);
		}

		//AddCollection
		public void AddCollection(ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionObj)
		{
			foreach (ZprogrammazioneFonti ZprogrammazioneFontiObj in ZprogrammazioneFontiCollectionObj)
				this.Add(ZprogrammazioneFontiObj);
		}

		//Insert
		public void Insert(int index, ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			if (ZprogrammazioneFontiObj.Provider == null) ZprogrammazioneFontiObj.Provider = this.Provider;
			base.Insert(index, ZprogrammazioneFontiObj);
		}

		//CollectionGetById
		public ZprogrammazioneFonti CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZprogrammazioneFontiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.IntNT IdFonteEqualThis, 
NullTypes.DecimalNT PercentualeEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.IntNT OperatoreInizioEqualThis, 
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OperatoreFineEqualThis, NullTypes.BoolNT AttivaEqualThis)
		{
			ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionTemp = new ZprogrammazioneFontiCollection();
			foreach (ZprogrammazioneFonti ZprogrammazioneFontiItem in this)
			{
				if (((IdEqualThis == null) || ((ZprogrammazioneFontiItem.Id != null) && (ZprogrammazioneFontiItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZprogrammazioneFontiItem.IdProgrammazione != null) && (ZprogrammazioneFontiItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((IdFonteEqualThis == null) || ((ZprogrammazioneFontiItem.IdFonte != null) && (ZprogrammazioneFontiItem.IdFonte.Value == IdFonteEqualThis.Value))) && 
((PercentualeEqualThis == null) || ((ZprogrammazioneFontiItem.Percentuale != null) && (ZprogrammazioneFontiItem.Percentuale.Value == PercentualeEqualThis.Value))) && ((DataInizioEqualThis == null) || ((ZprogrammazioneFontiItem.DataInizio != null) && (ZprogrammazioneFontiItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((OperatoreInizioEqualThis == null) || ((ZprogrammazioneFontiItem.OperatoreInizio != null) && (ZprogrammazioneFontiItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) && 
((DataFineEqualThis == null) || ((ZprogrammazioneFontiItem.DataFine != null) && (ZprogrammazioneFontiItem.DataFine.Value == DataFineEqualThis.Value))) && ((OperatoreFineEqualThis == null) || ((ZprogrammazioneFontiItem.OperatoreFine != null) && (ZprogrammazioneFontiItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))) && ((AttivaEqualThis == null) || ((ZprogrammazioneFontiItem.Attiva != null) && (ZprogrammazioneFontiItem.Attiva.Value == AttivaEqualThis.Value))))
				{
					ZprogrammazioneFontiCollectionTemp.Add(ZprogrammazioneFontiItem);
				}
			}
			return ZprogrammazioneFontiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZprogrammazioneFontiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZprogrammazioneFontiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZprogrammazioneFonti ZprogrammazioneFontiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZprogrammazioneFontiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZprogrammazioneFontiObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFonte", ZprogrammazioneFontiObj.IdFonte);
			DbProvider.SetCmdParam(cmd,firstChar + "Percentuale", ZprogrammazioneFontiObj.Percentuale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", ZprogrammazioneFontiObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInizio", ZprogrammazioneFontiObj.OperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", ZprogrammazioneFontiObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreFine", ZprogrammazioneFontiObj.OperatoreFine);
			DbProvider.SetCmdParam(cmd,firstChar + "Attiva", ZprogrammazioneFontiObj.Attiva);
		}
		//Insert
		private static int Insert(DbProvider db, ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZprogrammazioneFontiInsert", new string[] {"IdProgrammazione", "IdFonte", 
"Percentuale", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Attiva", 
}, new string[] {"int", "int", 
"decimal", "DateTime", "int", 
"DateTime", "int", "bool", 
},"");
				CompileIUCmd(false, insertCmd,ZprogrammazioneFontiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZprogrammazioneFontiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ZprogrammazioneFontiObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
				}
				ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogrammazioneFontiObj.IsDirty = false;
				ZprogrammazioneFontiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZprogrammazioneFontiUpdate", new string[] {"Id", "IdProgrammazione", "IdFonte", 
"Percentuale", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Attiva", 
}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "int", 
"DateTime", "int", "bool", 
},"");
				CompileIUCmd(true, updateCmd,ZprogrammazioneFontiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogrammazioneFontiObj.IsDirty = false;
				ZprogrammazioneFontiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			switch (ZprogrammazioneFontiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZprogrammazioneFontiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZprogrammazioneFontiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZprogrammazioneFontiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZprogrammazioneFontiUpdate", new string[] {"Id", "IdProgrammazione", "IdFonte", 
"Percentuale", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Attiva", 
}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "int", 
"DateTime", "int", "bool", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZZprogrammazioneFontiInsert", new string[] {"IdProgrammazione", "IdFonte", 
"Percentuale", "DataInizio", "OperatoreInizio", 
"DataFine", "OperatoreFine", "Attiva", 
}, new string[] {"int", "int", 
"decimal", "DateTime", "int", 
"DateTime", "int", "bool", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZprogrammazioneFontiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZprogrammazioneFontiCollectionObj.Count; i++)
				{
					switch (ZprogrammazioneFontiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZprogrammazioneFontiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZprogrammazioneFontiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ZprogrammazioneFontiCollectionObj[i].Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZprogrammazioneFontiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZprogrammazioneFontiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZprogrammazioneFontiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZprogrammazioneFontiCollectionObj.Count; i++)
				{
					if ((ZprogrammazioneFontiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneFontiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZprogrammazioneFontiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZprogrammazioneFontiCollectionObj[i].IsDirty = false;
						ZprogrammazioneFontiCollectionObj[i].IsPersistent = true;
					}
					if ((ZprogrammazioneFontiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZprogrammazioneFontiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZprogrammazioneFontiCollectionObj[i].IsDirty = false;
						ZprogrammazioneFontiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZprogrammazioneFonti ZprogrammazioneFontiObj)
		{
			int returnValue = 0;
			if (ZprogrammazioneFontiObj.IsPersistent) 
			{
				returnValue = Delete(db, ZprogrammazioneFontiObj.Id);
			}
			ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZprogrammazioneFontiObj.IsDirty = false;
			ZprogrammazioneFontiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZprogrammazioneFontiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZprogrammazioneFontiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZprogrammazioneFontiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZprogrammazioneFontiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZprogrammazioneFontiCollectionObj.Count; i++)
				{
					if ((ZprogrammazioneFontiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneFontiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZprogrammazioneFontiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZprogrammazioneFontiCollectionObj[i].IsDirty = false;
						ZprogrammazioneFontiCollectionObj[i].IsPersistent = false;
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
		public static ZprogrammazioneFonti GetById(DbProvider db, int IdValue)
		{
			ZprogrammazioneFonti ZprogrammazioneFontiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZprogrammazioneFontiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZprogrammazioneFontiObj = GetFromDatareader(db);
				ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogrammazioneFontiObj.IsDirty = false;
				ZprogrammazioneFontiObj.IsPersistent = true;
			}
			db.Close();
			return ZprogrammazioneFontiObj;
		}

		//getFromDatareader
		public static ZprogrammazioneFonti GetFromDatareader(DbProvider db)
		{
			ZprogrammazioneFonti ZprogrammazioneFontiObj = new ZprogrammazioneFonti();
			ZprogrammazioneFontiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZprogrammazioneFontiObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZprogrammazioneFontiObj.IdFonte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FONTE"]);
			ZprogrammazioneFontiObj.Percentuale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE"]);
			ZprogrammazioneFontiObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			ZprogrammazioneFontiObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
			ZprogrammazioneFontiObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			ZprogrammazioneFontiObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
			ZprogrammazioneFontiObj.Attiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVA"]);
			ZprogrammazioneFontiObj.PercentualeFonte = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE_FONTE"]);
			ZprogrammazioneFontiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZprogrammazioneFontiObj.NominativoInizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_INIZIO"]);
			ZprogrammazioneFontiObj.NominativoFine = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_FINE"]);
			ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZprogrammazioneFontiObj.IsDirty = false;
			ZprogrammazioneFontiObj.IsPersistent = true;
			return ZprogrammazioneFontiObj;
		}

		//Find Select

		public static ZprogrammazioneFontiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.IntNT IdFonteEqualThis, 
SiarLibrary.NullTypes.DecimalNT PercentualeEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis, SiarLibrary.NullTypes.BoolNT AttivaEqualThis)

		{

			ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionObj = new ZprogrammazioneFontiCollection();

			IDbCommand findCmd = db.InitCmd("Zzprogrammazionefontifindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "IdFonteequalthis", 
"Percentualeequalthis", "DataInizioequalthis", "OperatoreInizioequalthis", 
"DataFineequalthis", "OperatoreFineequalthis", "Attivaequalthis"}, new string[] {"int", "int", "int", 
"decimal", "DateTime", "int", 
"DateTime", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFonteequalthis", IdFonteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Percentualeequalthis", PercentualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivaequalthis", AttivaEqualThis);
			ZprogrammazioneFonti ZprogrammazioneFontiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZprogrammazioneFontiObj = GetFromDatareader(db);
				ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogrammazioneFontiObj.IsDirty = false;
				ZprogrammazioneFontiObj.IsPersistent = true;
				ZprogrammazioneFontiCollectionObj.Add(ZprogrammazioneFontiObj);
			}
			db.Close();
			return ZprogrammazioneFontiCollectionObj;
		}

		//Find Find

		public static ZprogrammazioneFontiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.IntNT IdFonteEqualThis)

		{

			ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionObj = new ZprogrammazioneFontiCollection();

			IDbCommand findCmd = db.InitCmd("Zzprogrammazionefontifindfind", new string[] {"IdProgrammazioneequalthis", "IdFonteequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFonteequalthis", IdFonteEqualThis);
			ZprogrammazioneFonti ZprogrammazioneFontiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZprogrammazioneFontiObj = GetFromDatareader(db);
				ZprogrammazioneFontiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogrammazioneFontiObj.IsDirty = false;
				ZprogrammazioneFontiObj.IsPersistent = true;
				ZprogrammazioneFontiCollectionObj.Add(ZprogrammazioneFontiObj);
			}
			db.Close();
			return ZprogrammazioneFontiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZprogrammazioneFontiCollectionProvider:IZprogrammazioneFontiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZprogrammazioneFontiCollectionProvider : IZprogrammazioneFontiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZprogrammazioneFonti
		protected ZprogrammazioneFontiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZprogrammazioneFontiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZprogrammazioneFontiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZprogrammazioneFontiCollectionProvider(IntNT IdprogrammazioneEqualThis, IntNT IdfonteEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogrammazioneEqualThis, IdfonteEqualThis);
		}

		//Costruttore3: ha in input zprogrammazionefontiCollectionObj - non popola la collection
		public ZprogrammazioneFontiCollectionProvider(ZprogrammazioneFontiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZprogrammazioneFontiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZprogrammazioneFontiCollection(this);
		}

		//Get e Set
		public ZprogrammazioneFontiCollection CollectionObj
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
		public int SaveCollection(ZprogrammazioneFontiCollection collectionObj)
		{
			return ZprogrammazioneFontiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZprogrammazioneFonti zprogrammazionefontiObj)
		{
			return ZprogrammazioneFontiDAL.Save(_dbProviderObj, zprogrammazionefontiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZprogrammazioneFontiCollection collectionObj)
		{
			return ZprogrammazioneFontiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZprogrammazioneFonti zprogrammazionefontiObj)
		{
			return ZprogrammazioneFontiDAL.Delete(_dbProviderObj, zprogrammazionefontiObj);
		}

		//getById
		public ZprogrammazioneFonti GetById(IntNT IdValue)
		{
			ZprogrammazioneFonti ZprogrammazioneFontiTemp = ZprogrammazioneFontiDAL.GetById(_dbProviderObj, IdValue);
			if (ZprogrammazioneFontiTemp!=null) ZprogrammazioneFontiTemp.Provider = this;
			return ZprogrammazioneFontiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZprogrammazioneFontiCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, IntNT IdfonteEqualThis, 
DecimalNT PercentualeEqualThis, DatetimeNT DatainizioEqualThis, IntNT OperatoreinizioEqualThis, 
DatetimeNT DatafineEqualThis, IntNT OperatorefineEqualThis, BoolNT AttivaEqualThis)
		{
			ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionTemp = ZprogrammazioneFontiDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, IdfonteEqualThis, 
PercentualeEqualThis, DatainizioEqualThis, OperatoreinizioEqualThis, 
DatafineEqualThis, OperatorefineEqualThis, AttivaEqualThis);
			ZprogrammazioneFontiCollectionTemp.Provider = this;
			return ZprogrammazioneFontiCollectionTemp;
		}

		//Find: popola la collection
		public ZprogrammazioneFontiCollection Find(IntNT IdprogrammazioneEqualThis, IntNT IdfonteEqualThis)
		{
			ZprogrammazioneFontiCollection ZprogrammazioneFontiCollectionTemp = ZprogrammazioneFontiDAL.Find(_dbProviderObj, IdprogrammazioneEqualThis, IdfonteEqualThis);
			ZprogrammazioneFontiCollectionTemp.Provider = this;
			return ZprogrammazioneFontiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPROGRAMMAZIONE_FONTI>
  <ViewName>vzPROGRAMMAZIONE_FONTI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <ID_FONTE>Equal</ID_FONTE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPROGRAMMAZIONE_FONTI>
*/
