using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoIntegrazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoIntegrazioniProvider
	{
		int Save(BandoIntegrazioni BandoIntegrazioniObj);
		int SaveCollection(BandoIntegrazioniCollection collectionObj);
		int Delete(BandoIntegrazioni BandoIntegrazioniObj);
		int DeleteCollection(BandoIntegrazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoIntegrazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoIntegrazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _DataScadenza;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.DecimalNT _ImportoDiMisura;
		private NullTypes.DecimalNT _QuotaRiserva;
		private NullTypes.IntNT _IdAtto;
		[NonSerialized] private IBandoIntegrazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoIntegrazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoIntegrazioni()
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
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SCADENZA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenza
		{
			get { return _DataScadenza; }
			set {
				if (DataScadenza != value)
				{
					_DataScadenza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
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
		/// Corrisponde al campo:IMPORTO_DI_MISURA
		/// Tipo sul db:DECIMAL(18,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT ImportoDiMisura
		{
			get { return _ImportoDiMisura; }
			set {
				if (ImportoDiMisura != value)
				{
					_ImportoDiMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_RISERVA
		/// Tipo sul db:DECIMAL(10,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT QuotaRiserva
		{
			get { return _QuotaRiserva; }
			set {
				if (QuotaRiserva != value)
				{
					_QuotaRiserva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAtto
		{
			get { return _IdAtto; }
			set {
				if (IdAtto != value)
				{
					_IdAtto = value;
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
	/// Summary description for BandoIntegrazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoIntegrazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoIntegrazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoIntegrazioni) info.GetValue(i.ToString(),typeof(BandoIntegrazioni)));
			}
		}

		//Costruttore
		public BandoIntegrazioniCollection()
		{
			this.ItemType = typeof(BandoIntegrazioni);
		}

		//Costruttore con provider
		public BandoIntegrazioniCollection(IBandoIntegrazioniProvider providerObj)
		{
			this.ItemType = typeof(BandoIntegrazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoIntegrazioni this[int index]
		{
			get { return (BandoIntegrazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoIntegrazioniCollection GetChanges()
		{
			return (BandoIntegrazioniCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoIntegrazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoIntegrazioniProvider Provider
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
		public int Add(BandoIntegrazioni BandoIntegrazioniObj)
		{
			if (BandoIntegrazioniObj.Provider == null) BandoIntegrazioniObj.Provider = this.Provider;
			return base.Add(BandoIntegrazioniObj);
		}

		//AddCollection
		public void AddCollection(BandoIntegrazioniCollection BandoIntegrazioniCollectionObj)
		{
			foreach (BandoIntegrazioni BandoIntegrazioniObj in BandoIntegrazioniCollectionObj)
				this.Add(BandoIntegrazioniObj);
		}

		//Insert
		public void Insert(int index, BandoIntegrazioni BandoIntegrazioniObj)
		{
			if (BandoIntegrazioniObj.Provider == null) BandoIntegrazioniObj.Provider = this.Provider;
			base.Insert(index, BandoIntegrazioniObj);
		}

		//CollectionGetById
		public BandoIntegrazioni CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoIntegrazioniCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT OperatoreEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis, NullTypes.DecimalNT ImportoEqualThis, 
NullTypes.DecimalNT ImportoDiMisuraEqualThis, NullTypes.DecimalNT QuotaRiservaEqualThis, NullTypes.IntNT IdAttoEqualThis)
		{
			BandoIntegrazioniCollection BandoIntegrazioniCollectionTemp = new BandoIntegrazioniCollection();
			foreach (BandoIntegrazioni BandoIntegrazioniItem in this)
			{
				if (((IdEqualThis == null) || ((BandoIntegrazioniItem.Id != null) && (BandoIntegrazioniItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoIntegrazioniItem.IdBando != null) && (BandoIntegrazioniItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DataEqualThis == null) || ((BandoIntegrazioniItem.Data != null) && (BandoIntegrazioniItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((BandoIntegrazioniItem.Operatore != null) && (BandoIntegrazioniItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((BandoIntegrazioniItem.DataScadenza != null) && (BandoIntegrazioniItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) && ((ImportoEqualThis == null) || ((BandoIntegrazioniItem.Importo != null) && (BandoIntegrazioniItem.Importo.Value == ImportoEqualThis.Value))) && 
((ImportoDiMisuraEqualThis == null) || ((BandoIntegrazioniItem.ImportoDiMisura != null) && (BandoIntegrazioniItem.ImportoDiMisura.Value == ImportoDiMisuraEqualThis.Value))) && ((QuotaRiservaEqualThis == null) || ((BandoIntegrazioniItem.QuotaRiserva != null) && (BandoIntegrazioniItem.QuotaRiserva.Value == QuotaRiservaEqualThis.Value))) && ((IdAttoEqualThis == null) || ((BandoIntegrazioniItem.IdAtto != null) && (BandoIntegrazioniItem.IdAtto.Value == IdAttoEqualThis.Value))))
				{
					BandoIntegrazioniCollectionTemp.Add(BandoIntegrazioniItem);
				}
			}
			return BandoIntegrazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoIntegrazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoIntegrazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoIntegrazioni BandoIntegrazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoIntegrazioniObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoIntegrazioniObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", BandoIntegrazioniObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", BandoIntegrazioniObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataScadenza", BandoIntegrazioniObj.DataScadenza);
			DbProvider.SetCmdParam(cmd,firstChar + "Importo", BandoIntegrazioniObj.Importo);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoDiMisura", BandoIntegrazioniObj.ImportoDiMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaRiserva", BandoIntegrazioniObj.QuotaRiserva);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", BandoIntegrazioniObj.IdAtto);
		}
		//Insert
		private static int Insert(DbProvider db, BandoIntegrazioni BandoIntegrazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoIntegrazioniInsert", new string[] {"IdBando", "Data", 
"Operatore", "DataScadenza", "Importo", 
"ImportoDiMisura", "QuotaRiserva", "IdAtto"}, new string[] {"int", "DateTime", 
"int", "DateTime", "decimal", 
"decimal", "decimal", "int"},"");
				CompileIUCmd(false, insertCmd,BandoIntegrazioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoIntegrazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoIntegrazioniObj.ImportoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DI_MISURA"]);
				BandoIntegrazioniObj.QuotaRiserva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_RISERVA"]);
				}
				BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoIntegrazioniObj.IsDirty = false;
				BandoIntegrazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoIntegrazioni BandoIntegrazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoIntegrazioniUpdate", new string[] {"Id", "IdBando", "Data", 
"Operatore", "DataScadenza", "Importo", 
"ImportoDiMisura", "QuotaRiserva", "IdAtto"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "decimal", 
"decimal", "decimal", "int"},"");
				CompileIUCmd(true, updateCmd,BandoIntegrazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoIntegrazioniObj.IsDirty = false;
				BandoIntegrazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoIntegrazioni BandoIntegrazioniObj)
		{
			switch (BandoIntegrazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoIntegrazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoIntegrazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoIntegrazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoIntegrazioniCollection BandoIntegrazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoIntegrazioniUpdate", new string[] {"Id", "IdBando", "Data", 
"Operatore", "DataScadenza", "Importo", 
"ImportoDiMisura", "QuotaRiserva", "IdAtto"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "decimal", 
"decimal", "decimal", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoIntegrazioniInsert", new string[] {"IdBando", "Data", 
"Operatore", "DataScadenza", "Importo", 
"ImportoDiMisura", "QuotaRiserva", "IdAtto"}, new string[] {"int", "DateTime", 
"int", "DateTime", "decimal", 
"decimal", "decimal", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoIntegrazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoIntegrazioniCollectionObj.Count; i++)
				{
					switch (BandoIntegrazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoIntegrazioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoIntegrazioniCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoIntegrazioniCollectionObj[i].ImportoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DI_MISURA"]);
									BandoIntegrazioniCollectionObj[i].QuotaRiserva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_RISERVA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoIntegrazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoIntegrazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoIntegrazioniCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoIntegrazioniCollectionObj.Count; i++)
				{
					if ((BandoIntegrazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoIntegrazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoIntegrazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoIntegrazioniCollectionObj[i].IsDirty = false;
						BandoIntegrazioniCollectionObj[i].IsPersistent = true;
					}
					if ((BandoIntegrazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoIntegrazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoIntegrazioniCollectionObj[i].IsDirty = false;
						BandoIntegrazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoIntegrazioni BandoIntegrazioniObj)
		{
			int returnValue = 0;
			if (BandoIntegrazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoIntegrazioniObj.Id);
			}
			BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoIntegrazioniObj.IsDirty = false;
			BandoIntegrazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoIntegrazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoIntegrazioniCollection BandoIntegrazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoIntegrazioniDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoIntegrazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoIntegrazioniCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoIntegrazioniCollectionObj.Count; i++)
				{
					if ((BandoIntegrazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoIntegrazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoIntegrazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoIntegrazioniCollectionObj[i].IsDirty = false;
						BandoIntegrazioniCollectionObj[i].IsPersistent = false;
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
		public static BandoIntegrazioni GetById(DbProvider db, int IdValue)
		{
			BandoIntegrazioni BandoIntegrazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoIntegrazioniGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoIntegrazioniObj = GetFromDatareader(db);
				BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoIntegrazioniObj.IsDirty = false;
				BandoIntegrazioniObj.IsPersistent = true;
			}
			db.Close();
			return BandoIntegrazioniObj;
		}

		//getFromDatareader
		public static BandoIntegrazioni GetFromDatareader(DbProvider db)
		{
			BandoIntegrazioni BandoIntegrazioniObj = new BandoIntegrazioni();
			BandoIntegrazioniObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoIntegrazioniObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoIntegrazioniObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			BandoIntegrazioniObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			BandoIntegrazioniObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
			BandoIntegrazioniObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			BandoIntegrazioniObj.ImportoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DI_MISURA"]);
			BandoIntegrazioniObj.QuotaRiserva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_RISERVA"]);
			BandoIntegrazioniObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoIntegrazioniObj.IsDirty = false;
			BandoIntegrazioniObj.IsPersistent = true;
			return BandoIntegrazioniObj;
		}

		//Find Select

		public static BandoIntegrazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoDiMisuraEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaRiservaEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis)

		{

			BandoIntegrazioniCollection BandoIntegrazioniCollectionObj = new BandoIntegrazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandointegrazionifindselect", new string[] {"Idequalthis", "IdBandoequalthis", "Dataequalthis", 
"Operatoreequalthis", "DataScadenzaequalthis", "Importoequalthis", 
"ImportoDiMisuraequalthis", "QuotaRiservaequalthis", "IdAttoequalthis"}, new string[] {"int", "int", "DateTime", 
"int", "DateTime", "decimal", 
"decimal", "decimal", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoDiMisuraequalthis", ImportoDiMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaRiservaequalthis", QuotaRiservaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			BandoIntegrazioni BandoIntegrazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoIntegrazioniObj = GetFromDatareader(db);
				BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoIntegrazioniObj.IsDirty = false;
				BandoIntegrazioniObj.IsPersistent = true;
				BandoIntegrazioniCollectionObj.Add(BandoIntegrazioniObj);
			}
			db.Close();
			return BandoIntegrazioniCollectionObj;
		}

		//Find Find

		public static BandoIntegrazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			BandoIntegrazioniCollection BandoIntegrazioniCollectionObj = new BandoIntegrazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandointegrazionifindfind", new string[] {"IdBandoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			BandoIntegrazioni BandoIntegrazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoIntegrazioniObj = GetFromDatareader(db);
				BandoIntegrazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoIntegrazioniObj.IsDirty = false;
				BandoIntegrazioniObj.IsPersistent = true;
				BandoIntegrazioniCollectionObj.Add(BandoIntegrazioniObj);
			}
			db.Close();
			return BandoIntegrazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoIntegrazioniCollectionProvider:IBandoIntegrazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoIntegrazioniCollectionProvider : IBandoIntegrazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoIntegrazioni
		protected BandoIntegrazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoIntegrazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoIntegrazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoIntegrazioniCollectionProvider(IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis);
		}

		//Costruttore3: ha in input bandointegrazioniCollectionObj - non popola la collection
		public BandoIntegrazioniCollectionProvider(BandoIntegrazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoIntegrazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoIntegrazioniCollection(this);
		}

		//Get e Set
		public BandoIntegrazioniCollection CollectionObj
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
		public int SaveCollection(BandoIntegrazioniCollection collectionObj)
		{
			return BandoIntegrazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoIntegrazioni bandointegrazioniObj)
		{
			return BandoIntegrazioniDAL.Save(_dbProviderObj, bandointegrazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoIntegrazioniCollection collectionObj)
		{
			return BandoIntegrazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoIntegrazioni bandointegrazioniObj)
		{
			return BandoIntegrazioniDAL.Delete(_dbProviderObj, bandointegrazioniObj);
		}

		//getById
		public BandoIntegrazioni GetById(IntNT IdValue)
		{
			BandoIntegrazioni BandoIntegrazioniTemp = BandoIntegrazioniDAL.GetById(_dbProviderObj, IdValue);
			if (BandoIntegrazioniTemp!=null) BandoIntegrazioniTemp.Provider = this;
			return BandoIntegrazioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoIntegrazioniCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, DatetimeNT DataEqualThis, 
IntNT OperatoreEqualThis, DatetimeNT DatascadenzaEqualThis, DecimalNT ImportoEqualThis, 
DecimalNT ImportodimisuraEqualThis, DecimalNT QuotariservaEqualThis, IntNT IdattoEqualThis)
		{
			BandoIntegrazioniCollection BandoIntegrazioniCollectionTemp = BandoIntegrazioniDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, DataEqualThis, 
OperatoreEqualThis, DatascadenzaEqualThis, ImportoEqualThis, 
ImportodimisuraEqualThis, QuotariservaEqualThis, IdattoEqualThis);
			BandoIntegrazioniCollectionTemp.Provider = this;
			return BandoIntegrazioniCollectionTemp;
		}

		//Find: popola la collection
		public BandoIntegrazioniCollection Find(IntNT IdbandoEqualThis)
		{
			BandoIntegrazioniCollection BandoIntegrazioniCollectionTemp = BandoIntegrazioniDAL.Find(_dbProviderObj, IdbandoEqualThis);
			BandoIntegrazioniCollectionTemp.Provider = this;
			return BandoIntegrazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_INTEGRAZIONI>
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
    <Find OrderBy="ORDER BY DATA DESC, ID DESC">
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_INTEGRAZIONI>
*/
