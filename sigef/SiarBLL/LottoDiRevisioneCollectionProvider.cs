using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per LottoDiRevisione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ILottoDiRevisioneProvider
	{
		int Save(LottoDiRevisione LottoDiRevisioneObj);
		int SaveCollection(LottoDiRevisioneCollection collectionObj);
		int Delete(LottoDiRevisione LottoDiRevisioneObj);
		int DeleteCollection(LottoDiRevisioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for LottoDiRevisione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class LottoDiRevisione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Provincia;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _NumeroEstrazioni;
		private NullTypes.BoolNT _RevisioneConclusa;
		private NullTypes.IntNT _NumeroDomandeAssegnate;
		private NullTypes.IntNT _NumeroDomandeEstratte;
		private NullTypes.StringNT _Operatore;
		[NonSerialized] private ILottoDiRevisioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ILottoDiRevisioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public LottoDiRevisione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_ESTRAZIONI
		/// Tipo sul db:INT
		/// Default:((0))
		/// </summary>
		public NullTypes.IntNT NumeroEstrazioni
		{
			get { return _NumeroEstrazioni; }
			set {
				if (NumeroEstrazioni != value)
				{
					_NumeroEstrazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REVISIONE_CONCLUSA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RevisioneConclusa
		{
			get { return _RevisioneConclusa; }
			set {
				if (RevisioneConclusa != value)
				{
					_RevisioneConclusa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_DOMANDE_ASSEGNATE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroDomandeAssegnate
		{
			get { return _NumeroDomandeAssegnate; }
			set {
				if (NumeroDomandeAssegnate != value)
				{
					_NumeroDomandeAssegnate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_DOMANDE_ESTRATTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroDomandeEstratte
		{
			get { return _NumeroDomandeEstratte; }
			set {
				if (NumeroDomandeEstratte != value)
				{
					_NumeroDomandeEstratte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Operatore
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
	/// Summary description for LottoDiRevisioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LottoDiRevisioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private LottoDiRevisioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((LottoDiRevisione) info.GetValue(i.ToString(),typeof(LottoDiRevisione)));
			}
		}

		//Costruttore
		public LottoDiRevisioneCollection()
		{
			this.ItemType = typeof(LottoDiRevisione);
		}

		//Costruttore con provider
		public LottoDiRevisioneCollection(ILottoDiRevisioneProvider providerObj)
		{
			this.ItemType = typeof(LottoDiRevisione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new LottoDiRevisione this[int index]
		{
			get { return (LottoDiRevisione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new LottoDiRevisioneCollection GetChanges()
		{
			return (LottoDiRevisioneCollection) base.GetChanges();
		}

		[NonSerialized] private ILottoDiRevisioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ILottoDiRevisioneProvider Provider
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
		public int Add(LottoDiRevisione LottoDiRevisioneObj)
		{
			if (LottoDiRevisioneObj.Provider == null) LottoDiRevisioneObj.Provider = this.Provider;
			return base.Add(LottoDiRevisioneObj);
		}

		//AddCollection
		public void AddCollection(LottoDiRevisioneCollection LottoDiRevisioneCollectionObj)
		{
			foreach (LottoDiRevisione LottoDiRevisioneObj in LottoDiRevisioneCollectionObj)
				this.Add(LottoDiRevisioneObj);
		}

		//Insert
		public void Insert(int index, LottoDiRevisione LottoDiRevisioneObj)
		{
			if (LottoDiRevisioneObj.Provider == null) LottoDiRevisioneObj.Provider = this.Provider;
			base.Insert(index, LottoDiRevisioneObj);
		}

		//CollectionGetById
		public LottoDiRevisione CollectionGetById(NullTypes.IntNT IdLottoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdLotto == IdLottoValue))
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
		public LottoDiRevisioneCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT ProvinciaEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT NumeroEstrazioniEqualThis, NullTypes.BoolNT RevisioneConclusaEqualThis)
		{
			LottoDiRevisioneCollection LottoDiRevisioneCollectionTemp = new LottoDiRevisioneCollection();
			foreach (LottoDiRevisione LottoDiRevisioneItem in this)
			{
				if (((IdLottoEqualThis == null) || ((LottoDiRevisioneItem.IdLotto != null) && (LottoDiRevisioneItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((LottoDiRevisioneItem.IdBando != null) && (LottoDiRevisioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((LottoDiRevisioneItem.Provincia != null) && (LottoDiRevisioneItem.Provincia.Value == ProvinciaEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((LottoDiRevisioneItem.DataCreazione != null) && (LottoDiRevisioneItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((LottoDiRevisioneItem.CfOperatore != null) && (LottoDiRevisioneItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((DataModificaEqualThis == null) || ((LottoDiRevisioneItem.DataModifica != null) && (LottoDiRevisioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((NumeroEstrazioniEqualThis == null) || ((LottoDiRevisioneItem.NumeroEstrazioni != null) && (LottoDiRevisioneItem.NumeroEstrazioni.Value == NumeroEstrazioniEqualThis.Value))) && ((RevisioneConclusaEqualThis == null) || ((LottoDiRevisioneItem.RevisioneConclusa != null) && (LottoDiRevisioneItem.RevisioneConclusa.Value == RevisioneConclusaEqualThis.Value))))
				{
					LottoDiRevisioneCollectionTemp.Add(LottoDiRevisioneItem);
				}
			}
			return LottoDiRevisioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for LottoDiRevisioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class LottoDiRevisioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, LottoDiRevisione LottoDiRevisioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", LottoDiRevisioneObj.IdLotto);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", LottoDiRevisioneObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", LottoDiRevisioneObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", LottoDiRevisioneObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", LottoDiRevisioneObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", LottoDiRevisioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroEstrazioni", LottoDiRevisioneObj.NumeroEstrazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "RevisioneConclusa", LottoDiRevisioneObj.RevisioneConclusa);
		}
		//Insert
		private static int Insert(DbProvider db, LottoDiRevisione LottoDiRevisioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZLottoDiRevisioneInsert", new string[] {"IdBando", "Provincia", 
"DataCreazione", "CfOperatore", "DataModifica", 
"NumeroEstrazioni", "RevisioneConclusa", }, new string[] {"int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool", },"");
				CompileIUCmd(false, insertCmd,LottoDiRevisioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				LottoDiRevisioneObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
				LottoDiRevisioneObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
				LottoDiRevisioneObj.RevisioneConclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE_CONCLUSA"]);
				}
				LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LottoDiRevisioneObj.IsDirty = false;
				LottoDiRevisioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, LottoDiRevisione LottoDiRevisioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZLottoDiRevisioneUpdate", new string[] {"IdLotto", "IdBando", "Provincia", 
"DataCreazione", "CfOperatore", "DataModifica", 
"NumeroEstrazioni", "RevisioneConclusa", }, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool", },"");
				CompileIUCmd(true, updateCmd,LottoDiRevisioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					LottoDiRevisioneObj.DataModifica = d;
				}
				LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LottoDiRevisioneObj.IsDirty = false;
				LottoDiRevisioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, LottoDiRevisione LottoDiRevisioneObj)
		{
			switch (LottoDiRevisioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, LottoDiRevisioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, LottoDiRevisioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,LottoDiRevisioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, LottoDiRevisioneCollection LottoDiRevisioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZLottoDiRevisioneUpdate", new string[] {"IdLotto", "IdBando", "Provincia", 
"DataCreazione", "CfOperatore", "DataModifica", 
"NumeroEstrazioni", "RevisioneConclusa", }, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZLottoDiRevisioneInsert", new string[] {"IdBando", "Provincia", 
"DataCreazione", "CfOperatore", "DataModifica", 
"NumeroEstrazioni", "RevisioneConclusa", }, new string[] {"int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZLottoDiRevisioneDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				for (int i = 0; i < LottoDiRevisioneCollectionObj.Count; i++)
				{
					switch (LottoDiRevisioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,LottoDiRevisioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									LottoDiRevisioneCollectionObj[i].IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
									LottoDiRevisioneCollectionObj[i].NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
									LottoDiRevisioneCollectionObj[i].RevisioneConclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE_CONCLUSA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,LottoDiRevisioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									LottoDiRevisioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (LottoDiRevisioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)LottoDiRevisioneCollectionObj[i].IdLotto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < LottoDiRevisioneCollectionObj.Count; i++)
				{
					if ((LottoDiRevisioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LottoDiRevisioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LottoDiRevisioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						LottoDiRevisioneCollectionObj[i].IsDirty = false;
						LottoDiRevisioneCollectionObj[i].IsPersistent = true;
					}
					if ((LottoDiRevisioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						LottoDiRevisioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LottoDiRevisioneCollectionObj[i].IsDirty = false;
						LottoDiRevisioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, LottoDiRevisione LottoDiRevisioneObj)
		{
			int returnValue = 0;
			if (LottoDiRevisioneObj.IsPersistent) 
			{
				returnValue = Delete(db, LottoDiRevisioneObj.IdLotto);
			}
			LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			LottoDiRevisioneObj.IsDirty = false;
			LottoDiRevisioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLottoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZLottoDiRevisioneDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, LottoDiRevisioneCollection LottoDiRevisioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZLottoDiRevisioneDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				for (int i = 0; i < LottoDiRevisioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", LottoDiRevisioneCollectionObj[i].IdLotto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < LottoDiRevisioneCollectionObj.Count; i++)
				{
					if ((LottoDiRevisioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (LottoDiRevisioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						LottoDiRevisioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						LottoDiRevisioneCollectionObj[i].IsDirty = false;
						LottoDiRevisioneCollectionObj[i].IsPersistent = false;
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
		public static LottoDiRevisione GetById(DbProvider db, int IdLottoValue)
		{
			LottoDiRevisione LottoDiRevisioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZLottoDiRevisioneGetById", new string[] {"IdLotto"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				LottoDiRevisioneObj = GetFromDatareader(db);
				LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LottoDiRevisioneObj.IsDirty = false;
				LottoDiRevisioneObj.IsPersistent = true;
			}
			db.Close();
			return LottoDiRevisioneObj;
		}

		//getFromDatareader
		public static LottoDiRevisione GetFromDatareader(DbProvider db)
		{
			LottoDiRevisione LottoDiRevisioneObj = new LottoDiRevisione();
			LottoDiRevisioneObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			LottoDiRevisioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			LottoDiRevisioneObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			LottoDiRevisioneObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			LottoDiRevisioneObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			LottoDiRevisioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			LottoDiRevisioneObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
			LottoDiRevisioneObj.RevisioneConclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE_CONCLUSA"]);
			LottoDiRevisioneObj.NumeroDomandeAssegnate = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_DOMANDE_ASSEGNATE"]);
			LottoDiRevisioneObj.NumeroDomandeEstratte = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_DOMANDE_ESTRATTE"]);
			LottoDiRevisioneObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			LottoDiRevisioneObj.IsDirty = false;
			LottoDiRevisioneObj.IsPersistent = true;
			return LottoDiRevisioneObj;
		}

		//Find Select

		public static LottoDiRevisioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT NumeroEstrazioniEqualThis, SiarLibrary.NullTypes.BoolNT RevisioneConclusaEqualThis)

		{

			LottoDiRevisioneCollection LottoDiRevisioneCollectionObj = new LottoDiRevisioneCollection();

			IDbCommand findCmd = db.InitCmd("Zlottodirevisionefindselect", new string[] {"IdLottoequalthis", "IdBandoequalthis", "Provinciaequalthis", 
"DataCreazioneequalthis", "CfOperatoreequalthis", "DataModificaequalthis", 
"NumeroEstrazioniequalthis", "RevisioneConclusaequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioniequalthis", NumeroEstrazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RevisioneConclusaequalthis", RevisioneConclusaEqualThis);
			LottoDiRevisione LottoDiRevisioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LottoDiRevisioneObj = GetFromDatareader(db);
				LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LottoDiRevisioneObj.IsDirty = false;
				LottoDiRevisioneObj.IsPersistent = true;
				LottoDiRevisioneCollectionObj.Add(LottoDiRevisioneObj);
			}
			db.Close();
			return LottoDiRevisioneCollectionObj;
		}

		//Find Find

		public static LottoDiRevisioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.IntNT NumeroEstrazioniEqualThis, SiarLibrary.NullTypes.BoolNT RevisioneConclusaEqualThis)

		{

			LottoDiRevisioneCollection LottoDiRevisioneCollectionObj = new LottoDiRevisioneCollection();

			IDbCommand findCmd = db.InitCmd("Zlottodirevisionefindfind", new string[] {"IdLottoequalthis", "IdBandoequalthis", "Provinciaequalthis", 
"NumeroEstrazioniequalthis", "RevisioneConclusaequalthis"}, new string[] {"int", "int", "string", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioniequalthis", NumeroEstrazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RevisioneConclusaequalthis", RevisioneConclusaEqualThis);
			LottoDiRevisione LottoDiRevisioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				LottoDiRevisioneObj = GetFromDatareader(db);
				LottoDiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				LottoDiRevisioneObj.IsDirty = false;
				LottoDiRevisioneObj.IsPersistent = true;
				LottoDiRevisioneCollectionObj.Add(LottoDiRevisioneObj);
			}
			db.Close();
			return LottoDiRevisioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for LottoDiRevisioneCollectionProvider:ILottoDiRevisioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class LottoDiRevisioneCollectionProvider : ILottoDiRevisioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LottoDiRevisione
		protected LottoDiRevisioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LottoDiRevisioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LottoDiRevisioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public LottoDiRevisioneCollectionProvider(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciaEqualThis, 
IntNT NumeroestrazioniEqualThis, BoolNT RevisioneconclusaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IdbandoEqualThis, ProvinciaEqualThis, 
NumeroestrazioniEqualThis, RevisioneconclusaEqualThis);
		}

		//Costruttore3: ha in input lottodirevisioneCollectionObj - non popola la collection
		public LottoDiRevisioneCollectionProvider(LottoDiRevisioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LottoDiRevisioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LottoDiRevisioneCollection(this);
		}

		//Get e Set
		public LottoDiRevisioneCollection CollectionObj
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
		public int SaveCollection(LottoDiRevisioneCollection collectionObj)
		{
			return LottoDiRevisioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LottoDiRevisione lottodirevisioneObj)
		{
			return LottoDiRevisioneDAL.Save(_dbProviderObj, lottodirevisioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LottoDiRevisioneCollection collectionObj)
		{
			return LottoDiRevisioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LottoDiRevisione lottodirevisioneObj)
		{
			return LottoDiRevisioneDAL.Delete(_dbProviderObj, lottodirevisioneObj);
		}

		//getById
		public LottoDiRevisione GetById(IntNT IdLottoValue)
		{
			LottoDiRevisione LottoDiRevisioneTemp = LottoDiRevisioneDAL.GetById(_dbProviderObj, IdLottoValue);
			if (LottoDiRevisioneTemp!=null) LottoDiRevisioneTemp.Provider = this;
			return LottoDiRevisioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public LottoDiRevisioneCollection Select(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciaEqualThis, 
DatetimeNT DatacreazioneEqualThis, StringNT CfoperatoreEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT NumeroestrazioniEqualThis, BoolNT RevisioneconclusaEqualThis)
		{
			LottoDiRevisioneCollection LottoDiRevisioneCollectionTemp = LottoDiRevisioneDAL.Select(_dbProviderObj, IdlottoEqualThis, IdbandoEqualThis, ProvinciaEqualThis, 
DatacreazioneEqualThis, CfoperatoreEqualThis, DatamodificaEqualThis, 
NumeroestrazioniEqualThis, RevisioneconclusaEqualThis);
			LottoDiRevisioneCollectionTemp.Provider = this;
			return LottoDiRevisioneCollectionTemp;
		}

		//Find: popola la collection
		public LottoDiRevisioneCollection Find(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciaEqualThis, 
IntNT NumeroestrazioniEqualThis, BoolNT RevisioneconclusaEqualThis)
		{
			LottoDiRevisioneCollection LottoDiRevisioneCollectionTemp = LottoDiRevisioneDAL.Find(_dbProviderObj, IdlottoEqualThis, IdbandoEqualThis, ProvinciaEqualThis, 
NumeroestrazioniEqualThis, RevisioneconclusaEqualThis);
			LottoDiRevisioneCollectionTemp.Provider = this;
			return LottoDiRevisioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOTTO_DI_REVISIONE>
  <ViewName>vLOTTO_DI_REVISIONE</ViewName>
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
    <Find OrderBy="ORDER BY ID_LOTTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_BANDO>Equal</ID_BANDO>
      <PROVINCIA>Equal</PROVINCIA>
      <NUMERO_ESTRAZIONI>Equal</NUMERO_ESTRAZIONI>
      <REVISIONE_CONCLUSA>Equal</REVISIONE_CONCLUSA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOTTO_DI_REVISIONE>
*/
