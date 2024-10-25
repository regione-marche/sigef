using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoValidatori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoValidatoriProvider
	{
		int Save(BandoValidatori BandoValidatoriObj);
		int SaveCollection(BandoValidatoriCollection collectionObj);
		int Delete(BandoValidatori BandoValidatoriObj);
		int DeleteCollection(BandoValidatoriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoValidatori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoValidatori: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.BoolNT _Responsabile;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.IntNT _OperatoreInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _OperatoreFine;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _CodEnte;
		[NonSerialized] private IBandoValidatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoValidatoriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoValidatori()
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
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RESPONSABILE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Responsabile
		{
			get { return _Responsabile; }
			set {
				if (Responsabile != value)
				{
					_Responsabile = value;
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
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}



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
	/// Summary description for BandoValidatoriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoValidatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoValidatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoValidatori) info.GetValue(i.ToString(),typeof(BandoValidatori)));
			}
		}

		//Costruttore
		public BandoValidatoriCollection()
		{
			this.ItemType = typeof(BandoValidatori);
		}

		//Costruttore con provider
		public BandoValidatoriCollection(IBandoValidatoriProvider providerObj)
		{
			this.ItemType = typeof(BandoValidatori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoValidatori this[int index]
		{
			get { return (BandoValidatori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoValidatoriCollection GetChanges()
		{
			return (BandoValidatoriCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoValidatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoValidatoriProvider Provider
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
		public int Add(BandoValidatori BandoValidatoriObj)
		{
			if (BandoValidatoriObj.Provider == null) BandoValidatoriObj.Provider = this.Provider;
			return base.Add(BandoValidatoriObj);
		}

		//AddCollection
		public void AddCollection(BandoValidatoriCollection BandoValidatoriCollectionObj)
		{
			foreach (BandoValidatori BandoValidatoriObj in BandoValidatoriCollectionObj)
				this.Add(BandoValidatoriObj);
		}

		//Insert
		public void Insert(int index, BandoValidatori BandoValidatoriObj)
		{
			if (BandoValidatoriObj.Provider == null) BandoValidatoriObj.Provider = this.Provider;
			base.Insert(index, BandoValidatoriObj);
		}

		//CollectionGetById
		public BandoValidatori CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoValidatoriCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdUtenteEqualThis, 
NullTypes.BoolNT ResponsabileEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, 
NullTypes.IntNT OperatoreInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OperatoreFineEqualThis)
		{
			BandoValidatoriCollection BandoValidatoriCollectionTemp = new BandoValidatoriCollection();
			foreach (BandoValidatori BandoValidatoriItem in this)
			{
				if (((IdEqualThis == null) || ((BandoValidatoriItem.Id != null) && (BandoValidatoriItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoValidatoriItem.IdBando != null) && (BandoValidatoriItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((BandoValidatoriItem.IdUtente != null) && (BandoValidatoriItem.IdUtente.Value == IdUtenteEqualThis.Value))) && 
((ResponsabileEqualThis == null) || ((BandoValidatoriItem.Responsabile != null) && (BandoValidatoriItem.Responsabile.Value == ResponsabileEqualThis.Value))) && ((AttivoEqualThis == null) || ((BandoValidatoriItem.Attivo != null) && (BandoValidatoriItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((BandoValidatoriItem.DataInizio != null) && (BandoValidatoriItem.DataInizio.Value == DataInizioEqualThis.Value))) && 
((OperatoreInizioEqualThis == null) || ((BandoValidatoriItem.OperatoreInizio != null) && (BandoValidatoriItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((BandoValidatoriItem.DataFine != null) && (BandoValidatoriItem.DataFine.Value == DataFineEqualThis.Value))) && ((OperatoreFineEqualThis == null) || ((BandoValidatoriItem.OperatoreFine != null) && (BandoValidatoriItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))))
				{
					BandoValidatoriCollectionTemp.Add(BandoValidatoriItem);
				}
			}
			return BandoValidatoriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoValidatoriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoValidatoriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoValidatori BandoValidatoriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoValidatoriObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoValidatoriObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", BandoValidatoriObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "Responsabile", BandoValidatoriObj.Responsabile);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BandoValidatoriObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", BandoValidatoriObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInizio", BandoValidatoriObj.OperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", BandoValidatoriObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreFine", BandoValidatoriObj.OperatoreFine);
		}
		//Insert
		private static int Insert(DbProvider db, BandoValidatori BandoValidatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoValidatoriInsert", new string[] {"IdBando", "IdUtente", 
"Responsabile", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", 
"bool", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				CompileIUCmd(false, insertCmd,BandoValidatoriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoValidatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoValidatoriObj.Responsabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RESPONSABILE"]);
				BandoValidatoriObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValidatoriObj.IsDirty = false;
				BandoValidatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoValidatori BandoValidatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoValidatoriUpdate", new string[] {"Id", "IdBando", "IdUtente", 
"Responsabile", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				CompileIUCmd(true, updateCmd,BandoValidatoriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValidatoriObj.IsDirty = false;
				BandoValidatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoValidatori BandoValidatoriObj)
		{
			switch (BandoValidatoriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoValidatoriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoValidatoriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoValidatoriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoValidatoriCollection BandoValidatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoValidatoriUpdate", new string[] {"Id", "IdBando", "IdUtente", 
"Responsabile", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoValidatoriInsert", new string[] {"IdBando", "IdUtente", 
"Responsabile", "Attivo", "DataInizio", 
"OperatoreInizio", "DataFine", "OperatoreFine", 
}, new string[] {"int", "int", 
"bool", "bool", "DateTime", 
"int", "DateTime", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValidatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoValidatoriCollectionObj.Count; i++)
				{
					switch (BandoValidatoriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoValidatoriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoValidatoriCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoValidatoriCollectionObj[i].Responsabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RESPONSABILE"]);
									BandoValidatoriCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoValidatoriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoValidatoriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoValidatoriCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoValidatoriCollectionObj.Count; i++)
				{
					if ((BandoValidatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoValidatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoValidatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoValidatoriCollectionObj[i].IsDirty = false;
						BandoValidatoriCollectionObj[i].IsPersistent = true;
					}
					if ((BandoValidatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoValidatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoValidatoriCollectionObj[i].IsDirty = false;
						BandoValidatoriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoValidatori BandoValidatoriObj)
		{
			int returnValue = 0;
			if (BandoValidatoriObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoValidatoriObj.Id);
			}
			BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoValidatoriObj.IsDirty = false;
			BandoValidatoriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValidatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoValidatoriCollection BandoValidatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValidatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoValidatoriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoValidatoriCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoValidatoriCollectionObj.Count; i++)
				{
					if ((BandoValidatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoValidatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoValidatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoValidatoriCollectionObj[i].IsDirty = false;
						BandoValidatoriCollectionObj[i].IsPersistent = false;
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
		public static BandoValidatori GetById(DbProvider db, int IdValue)
		{
			BandoValidatori BandoValidatoriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoValidatoriGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoValidatoriObj = GetFromDatareader(db);
				BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValidatoriObj.IsDirty = false;
				BandoValidatoriObj.IsPersistent = true;
			}
			db.Close();
			return BandoValidatoriObj;
		}

		//getFromDatareader
		public static BandoValidatori GetFromDatareader(DbProvider db)
		{
			BandoValidatori BandoValidatoriObj = new BandoValidatori();
			BandoValidatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoValidatoriObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoValidatoriObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			BandoValidatoriObj.Responsabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RESPONSABILE"]);
			BandoValidatoriObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoValidatoriObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			BandoValidatoriObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
			BandoValidatoriObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			BandoValidatoriObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
			BandoValidatoriObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			BandoValidatoriObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			BandoValidatoriObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			BandoValidatoriObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoValidatoriObj.IsDirty = false;
			BandoValidatoriObj.IsPersistent = true;
			return BandoValidatoriObj;
		}

		//Find Select

		public static BandoValidatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.BoolNT ResponsabileEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis)

		{

			BandoValidatoriCollection BandoValidatoriCollectionObj = new BandoValidatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zbandovalidatorifindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdUtenteequalthis", 
"Responsabileequalthis", "Attivoequalthis", "DataInizioequalthis", 
"OperatoreInizioequalthis", "DataFineequalthis", "OperatoreFineequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"int", "DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Responsabileequalthis", ResponsabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
			BandoValidatori BandoValidatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoValidatoriObj = GetFromDatareader(db);
				BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValidatoriObj.IsDirty = false;
				BandoValidatoriObj.IsPersistent = true;
				BandoValidatoriCollectionObj.Add(BandoValidatoriObj);
			}
			db.Close();
			return BandoValidatoriCollectionObj;
		}

		//Find Find

		public static BandoValidatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.BoolNT ResponsabileEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BandoValidatoriCollection BandoValidatoriCollectionObj = new BandoValidatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zbandovalidatorifindfind", new string[] {"IdBandoequalthis", "IdUtenteequalthis", "Responsabileequalthis", 
"Attivoequalthis"}, new string[] {"int", "int", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Responsabileequalthis", ResponsabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BandoValidatori BandoValidatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoValidatoriObj = GetFromDatareader(db);
				BandoValidatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValidatoriObj.IsDirty = false;
				BandoValidatoriObj.IsPersistent = true;
				BandoValidatoriCollectionObj.Add(BandoValidatoriObj);
			}
			db.Close();
			return BandoValidatoriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoValidatoriCollectionProvider:IBandoValidatoriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoValidatoriCollectionProvider : IBandoValidatoriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoValidatori
		protected BandoValidatoriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoValidatoriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoValidatoriCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoValidatoriCollectionProvider(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, BoolNT ResponsabileEqualThis, 
BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdutenteEqualThis, ResponsabileEqualThis, 
AttivoEqualThis);
		}

		//Costruttore3: ha in input bandovalidatoriCollectionObj - non popola la collection
		public BandoValidatoriCollectionProvider(BandoValidatoriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoValidatoriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoValidatoriCollection(this);
		}

		//Get e Set
		public BandoValidatoriCollection CollectionObj
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
		public int SaveCollection(BandoValidatoriCollection collectionObj)
		{
			return BandoValidatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoValidatori bandovalidatoriObj)
		{
			return BandoValidatoriDAL.Save(_dbProviderObj, bandovalidatoriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoValidatoriCollection collectionObj)
		{
			return BandoValidatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoValidatori bandovalidatoriObj)
		{
			return BandoValidatoriDAL.Delete(_dbProviderObj, bandovalidatoriObj);
		}

		//getById
		public BandoValidatori GetById(IntNT IdValue)
		{
			BandoValidatori BandoValidatoriTemp = BandoValidatoriDAL.GetById(_dbProviderObj, IdValue);
			if (BandoValidatoriTemp!=null) BandoValidatoriTemp.Provider = this;
			return BandoValidatoriTemp;
		}

		//Select: popola la collection
		public BandoValidatoriCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
BoolNT ResponsabileEqualThis, BoolNT AttivoEqualThis, DatetimeNT DatainizioEqualThis, 
IntNT OperatoreinizioEqualThis, DatetimeNT DatafineEqualThis, IntNT OperatorefineEqualThis)
		{
			BandoValidatoriCollection BandoValidatoriCollectionTemp = BandoValidatoriDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
ResponsabileEqualThis, AttivoEqualThis, DatainizioEqualThis, 
OperatoreinizioEqualThis, DatafineEqualThis, OperatorefineEqualThis);
			BandoValidatoriCollectionTemp.Provider = this;
			return BandoValidatoriCollectionTemp;
		}

		//Find: popola la collection
		public BandoValidatoriCollection Find(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, BoolNT ResponsabileEqualThis, 
BoolNT AttivoEqualThis)
		{
			BandoValidatoriCollection BandoValidatoriCollectionTemp = BandoValidatoriDAL.Find(_dbProviderObj, IdbandoEqualThis, IdutenteEqualThis, ResponsabileEqualThis, 
AttivoEqualThis);
			BandoValidatoriCollectionTemp.Provider = this;
			return BandoValidatoriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_VALIDATORI>
  <ViewName>vBANDO_VALIDATORI</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, RESPONSABILE DESC, DATA_INIZIO DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <RESPONSABILE>Equal</RESPONSABILE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_VALIDATORI>
*/
