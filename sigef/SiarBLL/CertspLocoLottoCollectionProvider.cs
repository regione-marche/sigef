using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspLocoLotto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspLocoLottoProvider
	{
		int Save(CertspLocoLotto CertspLocoLottoObj);
		int SaveCollection(CertspLocoLottoCollection collectionObj);
		int Delete(CertspLocoLotto CertspLocoLottoObj);
		int DeleteCollection(CertspLocoLottoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspLocoLotto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspLocoLotto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Operatore;
		private NullTypes.IntNT _NumeroEstrazioni;
		private NullTypes.BoolNT _ControlloConcluso;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _DataEstrazione;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.IntNT _DomandeAssegnate;
		private NullTypes.IntNT _DomandeEstratte;
		private NullTypes.StringNT _Programmazione;
		[NonSerialized] private ICertspLocoLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspLocoLottoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspLocoLotto()
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
		/// Corrisponde al campo:CONTROLLO_CONCLUSO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT ControlloConcluso
		{
			get { return _ControlloConcluso; }
			set {
				if (ControlloConcluso != value)
				{
					_ControlloConcluso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataEstrazione
		{
			get { return _DataEstrazione; }
			set {
				if (DataEstrazione != value)
				{
					_DataEstrazione = value;
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
		/// Corrisponde al campo:DOMANDE_ASSEGNATE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DomandeAssegnate
		{
			get { return _DomandeAssegnate; }
			set {
				if (DomandeAssegnate != value)
				{
					_DomandeAssegnate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DOMANDE_ESTRATTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DomandeEstratte
		{
			get { return _DomandeEstratte; }
			set {
				if (DomandeEstratte != value)
				{
					_DomandeEstratte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(71)
		/// </summary>
		public NullTypes.StringNT Programmazione
		{
			get { return _Programmazione; }
			set {
				if (Programmazione != value)
				{
					_Programmazione = value;
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
	/// Summary description for CertspLocoLottoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspLocoLottoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspLocoLottoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspLocoLotto) info.GetValue(i.ToString(),typeof(CertspLocoLotto)));
			}
		}

		//Costruttore
		public CertspLocoLottoCollection()
		{
			this.ItemType = typeof(CertspLocoLotto);
		}

		//Costruttore con provider
		public CertspLocoLottoCollection(ICertspLocoLottoProvider providerObj)
		{
			this.ItemType = typeof(CertspLocoLotto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspLocoLotto this[int index]
		{
			get { return (CertspLocoLotto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspLocoLottoCollection GetChanges()
		{
			return (CertspLocoLottoCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspLocoLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspLocoLottoProvider Provider
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
		public int Add(CertspLocoLotto CertspLocoLottoObj)
		{
			if (CertspLocoLottoObj.Provider == null) CertspLocoLottoObj.Provider = this.Provider;
			return base.Add(CertspLocoLottoObj);
		}

		//AddCollection
		public void AddCollection(CertspLocoLottoCollection CertspLocoLottoCollectionObj)
		{
			foreach (CertspLocoLotto CertspLocoLottoObj in CertspLocoLottoCollectionObj)
				this.Add(CertspLocoLottoObj);
		}

		//Insert
		public void Insert(int index, CertspLocoLotto CertspLocoLottoObj)
		{
			if (CertspLocoLottoObj.Provider == null) CertspLocoLottoObj.Provider = this.Provider;
			base.Insert(index, CertspLocoLottoObj);
		}

		//CollectionGetById
		public CertspLocoLotto CollectionGetById(NullTypes.IntNT IdValue)
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
		public CertspLocoLottoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT OperatoreEqualThis, NullTypes.DatetimeNT DataEstrazioneEqualThis, NullTypes.IntNT NumeroEstrazioniEqualThis, 
NullTypes.BoolNT ControlloConclusoEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis)
		{
			CertspLocoLottoCollection CertspLocoLottoCollectionTemp = new CertspLocoLottoCollection();
			foreach (CertspLocoLotto CertspLocoLottoItem in this)
			{
				if (((IdEqualThis == null) || ((CertspLocoLottoItem.Id != null) && (CertspLocoLottoItem.Id.Value == IdEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((CertspLocoLottoItem.DataCreazione != null) && (CertspLocoLottoItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((DataModificaEqualThis == null) || ((CertspLocoLottoItem.DataModifica != null) && (CertspLocoLottoItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CertspLocoLottoItem.Operatore != null) && (CertspLocoLottoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataEstrazioneEqualThis == null) || ((CertspLocoLottoItem.DataEstrazione != null) && (CertspLocoLottoItem.DataEstrazione.Value == DataEstrazioneEqualThis.Value))) && ((NumeroEstrazioniEqualThis == null) || ((CertspLocoLottoItem.NumeroEstrazioni != null) && (CertspLocoLottoItem.NumeroEstrazioni.Value == NumeroEstrazioniEqualThis.Value))) && 
((ControlloConclusoEqualThis == null) || ((CertspLocoLottoItem.ControlloConcluso != null) && (CertspLocoLottoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((CertspLocoLottoItem.Segnatura != null) && (CertspLocoLottoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((CertspLocoLottoItem.IdProgrammazione != null) && (CertspLocoLottoItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))))
				{
					CertspLocoLottoCollectionTemp.Add(CertspLocoLottoItem);
				}
			}
			return CertspLocoLottoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspLocoLottoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspLocoLottoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspLocoLotto CertspLocoLottoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspLocoLottoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", CertspLocoLottoObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", CertspLocoLottoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspLocoLottoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroEstrazioni", CertspLocoLottoObj.NumeroEstrazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloConcluso", CertspLocoLottoObj.ControlloConcluso);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", CertspLocoLottoObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "DataEstrazione", CertspLocoLottoObj.DataEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", CertspLocoLottoObj.IdProgrammazione);
		}
		//Insert
		private static int Insert(DbProvider db, CertspLocoLotto CertspLocoLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspLocoLottoInsert", new string[] {"DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"DateTime", "DateTime", 
"int", "int", "bool", 
"string", "DateTime", "int", 
},"");
				CompileIUCmd(false, insertCmd,CertspLocoLottoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspLocoLottoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				CertspLocoLottoObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
				CertspLocoLottoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
				}
				CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspLocoLottoObj.IsDirty = false;
				CertspLocoLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspLocoLotto CertspLocoLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspLocoLottoUpdate", new string[] {"Id", "DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"int", "DateTime", "DateTime", 
"int", "int", "bool", 
"string", "DateTime", "int", 
},"");
				CompileIUCmd(true, updateCmd,CertspLocoLottoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspLocoLottoObj.IsDirty = false;
				CertspLocoLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspLocoLotto CertspLocoLottoObj)
		{
			switch (CertspLocoLottoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspLocoLottoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspLocoLottoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspLocoLottoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspLocoLottoCollection CertspLocoLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspLocoLottoUpdate", new string[] {"Id", "DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"int", "DateTime", "DateTime", 
"int", "int", "bool", 
"string", "DateTime", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspLocoLottoInsert", new string[] {"DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"DateTime", "DateTime", 
"int", "int", "bool", 
"string", "DateTime", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspLocoLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspLocoLottoCollectionObj.Count; i++)
				{
					switch (CertspLocoLottoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspLocoLottoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspLocoLottoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									CertspLocoLottoCollectionObj[i].NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
									CertspLocoLottoCollectionObj[i].ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspLocoLottoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspLocoLottoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspLocoLottoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspLocoLottoCollectionObj.Count; i++)
				{
					if ((CertspLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspLocoLottoCollectionObj[i].IsDirty = false;
						CertspLocoLottoCollectionObj[i].IsPersistent = true;
					}
					if ((CertspLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspLocoLottoCollectionObj[i].IsDirty = false;
						CertspLocoLottoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspLocoLotto CertspLocoLottoObj)
		{
			int returnValue = 0;
			if (CertspLocoLottoObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspLocoLottoObj.Id);
			}
			CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspLocoLottoObj.IsDirty = false;
			CertspLocoLottoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspLocoLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspLocoLottoCollection CertspLocoLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspLocoLottoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspLocoLottoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspLocoLottoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspLocoLottoCollectionObj.Count; i++)
				{
					if ((CertspLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspLocoLottoCollectionObj[i].IsDirty = false;
						CertspLocoLottoCollectionObj[i].IsPersistent = false;
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
		public static CertspLocoLotto GetById(DbProvider db, int IdValue)
		{
			CertspLocoLotto CertspLocoLottoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspLocoLottoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspLocoLottoObj = GetFromDatareader(db);
				CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspLocoLottoObj.IsDirty = false;
				CertspLocoLottoObj.IsPersistent = true;
			}
			db.Close();
			return CertspLocoLottoObj;
		}

		//getFromDatareader
		public static CertspLocoLotto GetFromDatareader(DbProvider db)
		{
			CertspLocoLotto CertspLocoLottoObj = new CertspLocoLotto();
			CertspLocoLottoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspLocoLottoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			CertspLocoLottoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CertspLocoLottoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CertspLocoLottoObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
			CertspLocoLottoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
			CertspLocoLottoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			CertspLocoLottoObj.DataEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESTRAZIONE"]);
			CertspLocoLottoObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			CertspLocoLottoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CertspLocoLottoObj.DomandeAssegnate = new SiarLibrary.NullTypes.IntNT(db.DataReader["DOMANDE_ASSEGNATE"]);
			CertspLocoLottoObj.DomandeEstratte = new SiarLibrary.NullTypes.IntNT(db.DataReader["DOMANDE_ESTRATTE"]);
			CertspLocoLottoObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
			CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspLocoLottoObj.IsDirty = false;
			CertspLocoLottoObj.IsPersistent = true;
			return CertspLocoLottoObj;
		}

		//Find Select

		public static CertspLocoLottoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT NumeroEstrazioniEqualThis, 
SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis)

		{

			CertspLocoLottoCollection CertspLocoLottoCollectionObj = new CertspLocoLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertsplocolottofindselect", new string[] {"Idequalthis", "DataCreazioneequalthis", "DataModificaequalthis", 
"Operatoreequalthis", "DataEstrazioneequalthis", "NumeroEstrazioniequalthis", 
"ControlloConclusoequalthis", "Segnaturaequalthis", "IdProgrammazioneequalthis"}, new string[] {"int", "DateTime", "DateTime", 
"int", "DateTime", "int", 
"bool", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEstrazioneequalthis", DataEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioniequalthis", NumeroEstrazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			CertspLocoLotto CertspLocoLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspLocoLottoObj = GetFromDatareader(db);
				CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspLocoLottoObj.IsDirty = false;
				CertspLocoLottoObj.IsPersistent = true;
				CertspLocoLottoCollectionObj.Add(CertspLocoLottoObj);
			}
			db.Close();
			return CertspLocoLottoCollectionObj;
		}

		//Find Find

		public static CertspLocoLottoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis)

		{

			CertspLocoLottoCollection CertspLocoLottoCollectionObj = new CertspLocoLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertsplocolottofindfind", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "ControlloConclusoequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			CertspLocoLotto CertspLocoLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspLocoLottoObj = GetFromDatareader(db);
				CertspLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspLocoLottoObj.IsDirty = false;
				CertspLocoLottoObj.IsPersistent = true;
				CertspLocoLottoCollectionObj.Add(CertspLocoLottoObj);
			}
			db.Close();
			return CertspLocoLottoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspLocoLottoCollectionProvider:ICertspLocoLottoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspLocoLottoCollectionProvider : ICertspLocoLottoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspLocoLotto
		protected CertspLocoLottoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspLocoLottoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspLocoLottoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertspLocoLottoCollectionProvider(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT ControlloconclusoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdEqualThis, IdprogrammazioneEqualThis, ControlloconclusoEqualThis);
		}

		//Costruttore3: ha in input certsplocolottoCollectionObj - non popola la collection
		public CertspLocoLottoCollectionProvider(CertspLocoLottoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspLocoLottoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspLocoLottoCollection(this);
		}

		//Get e Set
		public CertspLocoLottoCollection CollectionObj
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
		public int SaveCollection(CertspLocoLottoCollection collectionObj)
		{
			return CertspLocoLottoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspLocoLotto certsplocolottoObj)
		{
			return CertspLocoLottoDAL.Save(_dbProviderObj, certsplocolottoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspLocoLottoCollection collectionObj)
		{
			return CertspLocoLottoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspLocoLotto certsplocolottoObj)
		{
			return CertspLocoLottoDAL.Delete(_dbProviderObj, certsplocolottoObj);
		}

		//getById
		public CertspLocoLotto GetById(IntNT IdValue)
		{
			CertspLocoLotto CertspLocoLottoTemp = CertspLocoLottoDAL.GetById(_dbProviderObj, IdValue);
			if (CertspLocoLottoTemp!=null) CertspLocoLottoTemp.Provider = this;
			return CertspLocoLottoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspLocoLottoCollection Select(IntNT IdEqualThis, DatetimeNT DatacreazioneEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT OperatoreEqualThis, DatetimeNT DataestrazioneEqualThis, IntNT NumeroestrazioniEqualThis, 
BoolNT ControlloconclusoEqualThis, StringNT SegnaturaEqualThis, IntNT IdprogrammazioneEqualThis)
		{
			CertspLocoLottoCollection CertspLocoLottoCollectionTemp = CertspLocoLottoDAL.Select(_dbProviderObj, IdEqualThis, DatacreazioneEqualThis, DatamodificaEqualThis, 
OperatoreEqualThis, DataestrazioneEqualThis, NumeroestrazioniEqualThis, 
ControlloconclusoEqualThis, SegnaturaEqualThis, IdprogrammazioneEqualThis);
			CertspLocoLottoCollectionTemp.Provider = this;
			return CertspLocoLottoCollectionTemp;
		}

		//Find: popola la collection
		public CertspLocoLottoCollection Find(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT ControlloconclusoEqualThis)
		{
			CertspLocoLottoCollection CertspLocoLottoCollectionTemp = CertspLocoLottoDAL.Find(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, ControlloconclusoEqualThis);
			CertspLocoLottoCollectionTemp.Provider = this;
			return CertspLocoLottoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_LOCO_LOTTO>
  <ViewName>vCERTSP_LOCO_LOTTO</ViewName>
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
  <Finds>
    <Find OrderBy="ORDER BY ID DESC">
      <ID>Equal</ID>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_LOCO_LOTTO>
*/
