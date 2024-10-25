using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Aggregazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAggregazioneProvider
	{
		int Save(Aggregazione AggregazioneObj);
		int SaveCollection(AggregazioneCollection collectionObj);
		int Delete(Aggregazione AggregazioneObj);
		int DeleteCollection(AggregazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Aggregazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Aggregazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _CodTipoAggregazione;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _OperatoreInizio;
		private NullTypes.IntNT _OperatoreFine;
		private NullTypes.StringNT _DescrizioneTipoAggregazione;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.BoolNT _ImpresaAggregazioneAttiva;
		[NonSerialized] private IAggregazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAggregazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Aggregazione()
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
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_AGGREGAZIONE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoAggregazione
		{
			get { return _CodTipoAggregazione; }
			set {
				if (CodTipoAggregazione != value)
				{
					_CodTipoAggregazione = value;
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
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
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
		/// Corrisponde al campo:DESCRIZIONE_TIPO_AGGREGAZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipoAggregazione
		{
			get { return _DescrizioneTipoAggregazione; }
			set {
				if (DescrizioneTipoAggregazione != value)
				{
					_DescrizioneTipoAggregazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPRESA_AGGREGAZIONE_ATTIVA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ImpresaAggregazioneAttiva
		{
			get { return _ImpresaAggregazioneAttiva; }
			set {
				if (ImpresaAggregazioneAttiva != value)
				{
					_ImpresaAggregazioneAttiva = value;
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
	/// Summary description for AggregazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AggregazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AggregazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Aggregazione) info.GetValue(i.ToString(),typeof(Aggregazione)));
			}
		}

		//Costruttore
		public AggregazioneCollection()
		{
			this.ItemType = typeof(Aggregazione);
		}

		//Costruttore con provider
		public AggregazioneCollection(IAggregazioneProvider providerObj)
		{
			this.ItemType = typeof(Aggregazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Aggregazione this[int index]
		{
			get { return (Aggregazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AggregazioneCollection GetChanges()
		{
			return (AggregazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IAggregazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAggregazioneProvider Provider
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
		public int Add(Aggregazione AggregazioneObj)
		{
			if (AggregazioneObj.Provider == null) AggregazioneObj.Provider = this.Provider;
			return base.Add(AggregazioneObj);
		}

		//AddCollection
		public void AddCollection(AggregazioneCollection AggregazioneCollectionObj)
		{
			foreach (Aggregazione AggregazioneObj in AggregazioneCollectionObj)
				this.Add(AggregazioneObj);
		}

		//Insert
		public void Insert(int index, Aggregazione AggregazioneObj)
		{
			if (AggregazioneObj.Provider == null) AggregazioneObj.Provider = this.Provider;
			base.Insert(index, AggregazioneObj);
		}

		//CollectionGetById
		public Aggregazione CollectionGetById(NullTypes.IntNT IdValue)
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
		public AggregazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT DenominazioneEqualThis, NullTypes.StringNT CodTipoAggregazioneEqualThis, 
NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.IntNT OperatoreInizioEqualThis, NullTypes.BoolNT AttivoEqualThis, 
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OperatoreFineEqualThis)
		{
			AggregazioneCollection AggregazioneCollectionTemp = new AggregazioneCollection();
			foreach (Aggregazione AggregazioneItem in this)
			{
				if (((IdEqualThis == null) || ((AggregazioneItem.Id != null) && (AggregazioneItem.Id.Value == IdEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((AggregazioneItem.Denominazione != null) && (AggregazioneItem.Denominazione.Value == DenominazioneEqualThis.Value))) && ((CodTipoAggregazioneEqualThis == null) || ((AggregazioneItem.CodTipoAggregazione != null) && (AggregazioneItem.CodTipoAggregazione.Value == CodTipoAggregazioneEqualThis.Value))) && 
((DataInizioEqualThis == null) || ((AggregazioneItem.DataInizio != null) && (AggregazioneItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((OperatoreInizioEqualThis == null) || ((AggregazioneItem.OperatoreInizio != null) && (AggregazioneItem.OperatoreInizio.Value == OperatoreInizioEqualThis.Value))) && ((AttivoEqualThis == null) || ((AggregazioneItem.Attivo != null) && (AggregazioneItem.Attivo.Value == AttivoEqualThis.Value))) && 
((DataFineEqualThis == null) || ((AggregazioneItem.DataFine != null) && (AggregazioneItem.DataFine.Value == DataFineEqualThis.Value))) && ((OperatoreFineEqualThis == null) || ((AggregazioneItem.OperatoreFine != null) && (AggregazioneItem.OperatoreFine.Value == OperatoreFineEqualThis.Value))))
				{
					AggregazioneCollectionTemp.Add(AggregazioneItem);
				}
			}
			return AggregazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public AggregazioneCollection Filter(NullTypes.StringNT CodTipoAggregazioneEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			AggregazioneCollection AggregazioneCollectionTemp = new AggregazioneCollection();
			foreach (Aggregazione AggregazioneItem in this)
			{
				if (((CodTipoAggregazioneEqualThis == null) || ((AggregazioneItem.CodTipoAggregazione != null) && (AggregazioneItem.CodTipoAggregazione.Value == CodTipoAggregazioneEqualThis.Value))) && ((AttivoEqualThis == null) || ((AggregazioneItem.Attivo != null) && (AggregazioneItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					AggregazioneCollectionTemp.Add(AggregazioneItem);
				}
			}
			return AggregazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AggregazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AggregazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Aggregazione AggregazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", AggregazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", AggregazioneObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoAggregazione", AggregazioneObj.CodTipoAggregazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", AggregazioneObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", AggregazioneObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", AggregazioneObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInizio", AggregazioneObj.OperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreFine", AggregazioneObj.OperatoreFine);
		}
		//Insert
		private static int Insert(DbProvider db, Aggregazione AggregazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAggregazioneInsert", new string[] {"Denominazione", "CodTipoAggregazione", 
"DataInizio", "Attivo", "DataFine", 
"OperatoreInizio", "OperatoreFine", }, new string[] {"string", "string", 
"DateTime", "bool", "DateTime", 
"int", "int", },"");
				CompileIUCmd(false, insertCmd,AggregazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AggregazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AggregazioneObj.IsDirty = false;
				AggregazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Aggregazione AggregazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAggregazioneUpdate", new string[] {"Id", "Denominazione", "CodTipoAggregazione", 
"DataInizio", "Attivo", "DataFine", 
"OperatoreInizio", "OperatoreFine", }, new string[] {"int", "string", "string", 
"DateTime", "bool", "DateTime", 
"int", "int", },"");
				CompileIUCmd(true, updateCmd,AggregazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AggregazioneObj.IsDirty = false;
				AggregazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Aggregazione AggregazioneObj)
		{
			switch (AggregazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AggregazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AggregazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AggregazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AggregazioneCollection AggregazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAggregazioneUpdate", new string[] {"Id", "Denominazione", "CodTipoAggregazione", 
"DataInizio", "Attivo", "DataFine", 
"OperatoreInizio", "OperatoreFine", }, new string[] {"int", "string", "string", 
"DateTime", "bool", "DateTime", 
"int", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZAggregazioneInsert", new string[] {"Denominazione", "CodTipoAggregazione", 
"DataInizio", "Attivo", "DataFine", 
"OperatoreInizio", "OperatoreFine", }, new string[] {"string", "string", 
"DateTime", "bool", "DateTime", 
"int", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZAggregazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AggregazioneCollectionObj.Count; i++)
				{
					switch (AggregazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AggregazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AggregazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AggregazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AggregazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)AggregazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AggregazioneCollectionObj.Count; i++)
				{
					if ((AggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AggregazioneCollectionObj[i].IsDirty = false;
						AggregazioneCollectionObj[i].IsPersistent = true;
					}
					if ((AggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AggregazioneCollectionObj[i].IsDirty = false;
						AggregazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Aggregazione AggregazioneObj)
		{
			int returnValue = 0;
			if (AggregazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, AggregazioneObj.Id);
			}
			AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AggregazioneObj.IsDirty = false;
			AggregazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAggregazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AggregazioneCollection AggregazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAggregazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AggregazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", AggregazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AggregazioneCollectionObj.Count; i++)
				{
					if ((AggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AggregazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AggregazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AggregazioneCollectionObj[i].IsDirty = false;
						AggregazioneCollectionObj[i].IsPersistent = false;
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
		public static Aggregazione GetById(DbProvider db, int IdValue)
		{
			Aggregazione AggregazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAggregazioneGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AggregazioneObj = GetFromDatareader(db);
				AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AggregazioneObj.IsDirty = false;
				AggregazioneObj.IsPersistent = true;
			}
			db.Close();
			return AggregazioneObj;
		}

		//getFromDatareader
		public static Aggregazione GetFromDatareader(DbProvider db)
		{
			Aggregazione AggregazioneObj = new Aggregazione();
			AggregazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			AggregazioneObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			AggregazioneObj.CodTipoAggregazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_AGGREGAZIONE"]);
			AggregazioneObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			AggregazioneObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			AggregazioneObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			AggregazioneObj.OperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INIZIO"]);
			AggregazioneObj.OperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_FINE"]);
			AggregazioneObj.DescrizioneTipoAggregazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_AGGREGAZIONE"]);
			AggregazioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			AggregazioneObj.ImpresaAggregazioneAttiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IMPRESA_AGGREGAZIONE_ATTIVA"]);
			AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AggregazioneObj.IsDirty = false;
			AggregazioneObj.IsPersistent = true;
			return AggregazioneObj;
		}

		//Find Select

		public static AggregazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoAggregazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInizioEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OperatoreFineEqualThis)

		{

			AggregazioneCollection AggregazioneCollectionObj = new AggregazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zaggregazionefindselect", new string[] {"Idequalthis", "Denominazioneequalthis", "CodTipoAggregazioneequalthis", 
"DataInizioequalthis", "OperatoreInizioequalthis", "Attivoequalthis", 
"DataFineequalthis", "OperatoreFineequalthis"}, new string[] {"int", "string", "string", 
"DateTime", "int", "bool", 
"DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoAggregazioneequalthis", CodTipoAggregazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInizioequalthis", OperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreFineequalthis", OperatoreFineEqualThis);
			Aggregazione AggregazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AggregazioneObj = GetFromDatareader(db);
				AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AggregazioneObj.IsDirty = false;
				AggregazioneObj.IsPersistent = true;
				AggregazioneCollectionObj.Add(AggregazioneObj);
			}
			db.Close();
			return AggregazioneCollectionObj;
		}

		//Find Find

		public static AggregazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoAggregazioneEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.BoolNT ImpresaAggregazioneAttivaEqualThis)

		{

			AggregazioneCollection AggregazioneCollectionObj = new AggregazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zaggregazionefindfind", new string[] {"CodTipoAggregazioneequalthis", "Attivoequalthis", "IdImpresaequalthis", 
"ImpresaAggregazioneAttivaequalthis"}, new string[] {"string", "bool", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoAggregazioneequalthis", CodTipoAggregazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImpresaAggregazioneAttivaequalthis", ImpresaAggregazioneAttivaEqualThis);
			Aggregazione AggregazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AggregazioneObj = GetFromDatareader(db);
				AggregazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AggregazioneObj.IsDirty = false;
				AggregazioneObj.IsPersistent = true;
				AggregazioneCollectionObj.Add(AggregazioneObj);
			}
			db.Close();
			return AggregazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AggregazioneCollectionProvider:IAggregazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AggregazioneCollectionProvider : IAggregazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Aggregazione
		protected AggregazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AggregazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AggregazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public AggregazioneCollectionProvider(StringNT CodtipoaggregazioneEqualThis, BoolNT AttivoEqualThis, IntNT IdimpresaEqualThis, 
BoolNT ImpresaaggregazioneattivaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoaggregazioneEqualThis, AttivoEqualThis, IdimpresaEqualThis, 
ImpresaaggregazioneattivaEqualThis);
		}

		//Costruttore3: ha in input aggregazioneCollectionObj - non popola la collection
		public AggregazioneCollectionProvider(AggregazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AggregazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AggregazioneCollection(this);
		}

		//Get e Set
		public AggregazioneCollection CollectionObj
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
		public int SaveCollection(AggregazioneCollection collectionObj)
		{
			return AggregazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Aggregazione aggregazioneObj)
		{
			return AggregazioneDAL.Save(_dbProviderObj, aggregazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AggregazioneCollection collectionObj)
		{
			return AggregazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Aggregazione aggregazioneObj)
		{
			return AggregazioneDAL.Delete(_dbProviderObj, aggregazioneObj);
		}

		//getById
		public Aggregazione GetById(IntNT IdValue)
		{
			Aggregazione AggregazioneTemp = AggregazioneDAL.GetById(_dbProviderObj, IdValue);
			if (AggregazioneTemp!=null) AggregazioneTemp.Provider = this;
			return AggregazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AggregazioneCollection Select(IntNT IdEqualThis, StringNT DenominazioneEqualThis, StringNT CodtipoaggregazioneEqualThis, 
DatetimeNT DatainizioEqualThis, IntNT OperatoreinizioEqualThis, BoolNT AttivoEqualThis, 
DatetimeNT DatafineEqualThis, IntNT OperatorefineEqualThis)
		{
			AggregazioneCollection AggregazioneCollectionTemp = AggregazioneDAL.Select(_dbProviderObj, IdEqualThis, DenominazioneEqualThis, CodtipoaggregazioneEqualThis, 
DatainizioEqualThis, OperatoreinizioEqualThis, AttivoEqualThis, 
DatafineEqualThis, OperatorefineEqualThis);
			AggregazioneCollectionTemp.Provider = this;
			return AggregazioneCollectionTemp;
		}

		//Find: popola la collection
		public AggregazioneCollection Find(StringNT CodtipoaggregazioneEqualThis, BoolNT AttivoEqualThis, IntNT IdimpresaEqualThis, 
BoolNT ImpresaaggregazioneattivaEqualThis)
		{
			AggregazioneCollection AggregazioneCollectionTemp = AggregazioneDAL.Find(_dbProviderObj, CodtipoaggregazioneEqualThis, AttivoEqualThis, IdimpresaEqualThis, 
ImpresaaggregazioneattivaEqualThis);
			AggregazioneCollectionTemp.Provider = this;
			return AggregazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<AGGREGAZIONE>
  <ViewName>vAGGREGAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, DATA_INIZIO DESC">
      <COD_TIPO_AGGREGAZIONE>Equal</COD_TIPO_AGGREGAZIONE>
      <ATTIVO>Equal</ATTIVO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <IMPRESA_AGGREGAZIONE_ATTIVA>Equal</IMPRESA_AGGREGAZIONE_ATTIVA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <COD_TIPO_AGGREGAZIONE>Equal</COD_TIPO_AGGREGAZIONE>
      <ATTIVO>Equal</ATTIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</AGGREGAZIONE>
*/
