using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ControlliLocoLotto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliLocoLottoProvider
	{
		int Save(ControlliLocoLotto ControlliLocoLottoObj);
		int SaveCollection(ControlliLocoLottoCollection collectionObj);
		int Delete(ControlliLocoLotto ControlliLocoLottoObj);
		int DeleteCollection(ControlliLocoLottoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliLocoLotto
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ControlliLocoLotto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLotto;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Operatore;
		private NullTypes.IntNT _NumeroEstrazioni;
		private NullTypes.BoolNT _ControlloConcluso;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _DataEstrazione;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.IntNT _DomandeAssegnate;
		private NullTypes.IntNT _DomandeEstratte;
		private NullTypes.StringNT _Programmazione;
		[NonSerialized] private IControlliLocoLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliLocoLottoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliLocoLotto()
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
		/// Tipo sul db:VARCHAR(16)
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
	/// Summary description for ControlliLocoLottoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliLocoLottoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliLocoLottoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliLocoLotto) info.GetValue(i.ToString(),typeof(ControlliLocoLotto)));
			}
		}

		//Costruttore
		public ControlliLocoLottoCollection()
		{
			this.ItemType = typeof(ControlliLocoLotto);
		}

		//Costruttore con provider
		public ControlliLocoLottoCollection(IControlliLocoLottoProvider providerObj)
		{
			this.ItemType = typeof(ControlliLocoLotto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliLocoLotto this[int index]
		{
			get { return (ControlliLocoLotto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliLocoLottoCollection GetChanges()
		{
			return (ControlliLocoLottoCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliLocoLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliLocoLottoProvider Provider
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
		public int Add(ControlliLocoLotto ControlliLocoLottoObj)
		{
			if (ControlliLocoLottoObj.Provider == null) ControlliLocoLottoObj.Provider = this.Provider;
			return base.Add(ControlliLocoLottoObj);
		}

		//AddCollection
		public void AddCollection(ControlliLocoLottoCollection ControlliLocoLottoCollectionObj)
		{
			foreach (ControlliLocoLotto ControlliLocoLottoObj in ControlliLocoLottoCollectionObj)
				this.Add(ControlliLocoLottoObj);
		}

		//Insert
		public void Insert(int index, ControlliLocoLotto ControlliLocoLottoObj)
		{
			if (ControlliLocoLottoObj.Provider == null) ControlliLocoLottoObj.Provider = this.Provider;
			base.Insert(index, ControlliLocoLottoObj);
		}

		//CollectionGetById
		public ControlliLocoLotto CollectionGetById(NullTypes.IntNT IdLottoValue)
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
		public ControlliLocoLottoCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DataEstrazioneEqualThis, NullTypes.IntNT NumeroEstrazioniEqualThis, 
NullTypes.BoolNT ControlloConclusoEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis)
		{
			ControlliLocoLottoCollection ControlliLocoLottoCollectionTemp = new ControlliLocoLottoCollection();
			foreach (ControlliLocoLotto ControlliLocoLottoItem in this)
			{
				if (((IdLottoEqualThis == null) || ((ControlliLocoLottoItem.IdLotto != null) && (ControlliLocoLottoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((ControlliLocoLottoItem.DataCreazione != null) && (ControlliLocoLottoItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ControlliLocoLottoItem.DataModifica != null) && (ControlliLocoLottoItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((ControlliLocoLottoItem.Operatore != null) && (ControlliLocoLottoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataEstrazioneEqualThis == null) || ((ControlliLocoLottoItem.DataEstrazione != null) && (ControlliLocoLottoItem.DataEstrazione.Value == DataEstrazioneEqualThis.Value))) && ((NumeroEstrazioniEqualThis == null) || ((ControlliLocoLottoItem.NumeroEstrazioni != null) && (ControlliLocoLottoItem.NumeroEstrazioni.Value == NumeroEstrazioniEqualThis.Value))) && 
((ControlloConclusoEqualThis == null) || ((ControlliLocoLottoItem.ControlloConcluso != null) && (ControlliLocoLottoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ControlliLocoLottoItem.Segnatura != null) && (ControlliLocoLottoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ControlliLocoLottoItem.IdProgrammazione != null) && (ControlliLocoLottoItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))))
				{
					ControlliLocoLottoCollectionTemp.Add(ControlliLocoLottoItem);
				}
			}
			return ControlliLocoLottoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ControlliLocoLottoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ControlliLocoLottoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ControlliLocoLotto ControlliLocoLottoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", ControlliLocoLottoObj.IdLotto);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", ControlliLocoLottoObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ControlliLocoLottoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ControlliLocoLottoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroEstrazioni", ControlliLocoLottoObj.NumeroEstrazioni);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloConcluso", ControlliLocoLottoObj.ControlloConcluso);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ControlliLocoLottoObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "DataEstrazione", ControlliLocoLottoObj.DataEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ControlliLocoLottoObj.IdProgrammazione);
		}
		//Insert
		private static int Insert(DbProvider db, ControlliLocoLotto ControlliLocoLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZControlliLocoLottoInsert", new string[] {"DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"DateTime", "DateTime", 
"string", "int", "bool", 
"string", "DateTime", "int", 
},"");
				CompileIUCmd(false, insertCmd,ControlliLocoLottoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ControlliLocoLottoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
				ControlliLocoLottoObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
				ControlliLocoLottoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
				}
				ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliLocoLottoObj.IsDirty = false;
				ControlliLocoLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ControlliLocoLotto ControlliLocoLottoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliLocoLottoUpdate", new string[] {"IdLotto", "DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"int", "DateTime", "DateTime", 
"string", "int", "bool", 
"string", "DateTime", "int", 
},"");
				CompileIUCmd(true, updateCmd,ControlliLocoLottoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliLocoLottoObj.IsDirty = false;
				ControlliLocoLottoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ControlliLocoLotto ControlliLocoLottoObj)
		{
			switch (ControlliLocoLottoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ControlliLocoLottoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ControlliLocoLottoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ControlliLocoLottoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ControlliLocoLottoCollection ControlliLocoLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZControlliLocoLottoUpdate", new string[] {"IdLotto", "DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"int", "DateTime", "DateTime", 
"string", "int", "bool", 
"string", "DateTime", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZControlliLocoLottoInsert", new string[] {"DataCreazione", "DataModifica", 
"Operatore", "NumeroEstrazioni", "ControlloConcluso", 
"Segnatura", "DataEstrazione", "IdProgrammazione", 
}, new string[] {"DateTime", "DateTime", 
"string", "int", "bool", 
"string", "DateTime", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZControlliLocoLottoDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliLocoLottoCollectionObj.Count; i++)
				{
					switch (ControlliLocoLottoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ControlliLocoLottoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ControlliLocoLottoCollectionObj[i].IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
									ControlliLocoLottoCollectionObj[i].NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
									ControlliLocoLottoCollectionObj[i].ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ControlliLocoLottoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ControlliLocoLottoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)ControlliLocoLottoCollectionObj[i].IdLotto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ControlliLocoLottoCollectionObj.Count; i++)
				{
					if ((ControlliLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ControlliLocoLottoCollectionObj[i].IsDirty = false;
						ControlliLocoLottoCollectionObj[i].IsPersistent = true;
					}
					if ((ControlliLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ControlliLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliLocoLottoCollectionObj[i].IsDirty = false;
						ControlliLocoLottoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ControlliLocoLotto ControlliLocoLottoObj)
		{
			int returnValue = 0;
			if (ControlliLocoLottoObj.IsPersistent) 
			{
				returnValue = Delete(db, ControlliLocoLottoObj.IdLotto);
			}
			ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ControlliLocoLottoObj.IsDirty = false;
			ControlliLocoLottoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdLottoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliLocoLottoDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ControlliLocoLottoCollection ControlliLocoLottoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZControlliLocoLottoDelete", new string[] {"IdLotto"}, new string[] {"int"},"");
				for (int i = 0; i < ControlliLocoLottoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", ControlliLocoLottoCollectionObj[i].IdLotto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ControlliLocoLottoCollectionObj.Count; i++)
				{
					if ((ControlliLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ControlliLocoLottoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ControlliLocoLottoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ControlliLocoLottoCollectionObj[i].IsDirty = false;
						ControlliLocoLottoCollectionObj[i].IsPersistent = false;
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
		public static ControlliLocoLotto GetById(DbProvider db, int IdLottoValue)
		{
			ControlliLocoLotto ControlliLocoLottoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZControlliLocoLottoGetById", new string[] {"IdLotto"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ControlliLocoLottoObj = GetFromDatareader(db);
				ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliLocoLottoObj.IsDirty = false;
				ControlliLocoLottoObj.IsPersistent = true;
			}
			db.Close();
			return ControlliLocoLottoObj;
		}

		//getFromDatareader
		public static ControlliLocoLotto GetFromDatareader(DbProvider db)
		{
			ControlliLocoLotto ControlliLocoLottoObj = new ControlliLocoLotto();
			ControlliLocoLottoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			ControlliLocoLottoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			ControlliLocoLottoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ControlliLocoLottoObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			ControlliLocoLottoObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
			ControlliLocoLottoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
			ControlliLocoLottoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ControlliLocoLottoObj.DataEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESTRAZIONE"]);
			ControlliLocoLottoObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ControlliLocoLottoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ControlliLocoLottoObj.DomandeAssegnate = new SiarLibrary.NullTypes.IntNT(db.DataReader["DOMANDE_ASSEGNATE"]);
			ControlliLocoLottoObj.DomandeEstratte = new SiarLibrary.NullTypes.IntNT(db.DataReader["DOMANDE_ESTRATTE"]);
			ControlliLocoLottoObj.Programmazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGRAMMAZIONE"]);
			ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ControlliLocoLottoObj.IsDirty = false;
			ControlliLocoLottoObj.IsPersistent = true;
			return ControlliLocoLottoObj;
		}

		//Find Select

		public static ControlliLocoLottoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT NumeroEstrazioniEqualThis, 
SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis)

		{

			ControlliLocoLottoCollection ControlliLocoLottoCollectionObj = new ControlliLocoLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollilocolottofindselect", new string[] {"IdLottoequalthis", "DataCreazioneequalthis", "DataModificaequalthis", 
"Operatoreequalthis", "DataEstrazioneequalthis", "NumeroEstrazioniequalthis", 
"ControlloConclusoequalthis", "Segnaturaequalthis", "IdProgrammazioneequalthis"}, new string[] {"int", "DateTime", "DateTime", 
"string", "DateTime", "int", 
"bool", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEstrazioneequalthis", DataEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioniequalthis", NumeroEstrazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			ControlliLocoLotto ControlliLocoLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliLocoLottoObj = GetFromDatareader(db);
				ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliLocoLottoObj.IsDirty = false;
				ControlliLocoLottoObj.IsPersistent = true;
				ControlliLocoLottoCollectionObj.Add(ControlliLocoLottoObj);
			}
			db.Close();
			return ControlliLocoLottoCollectionObj;
		}

		//Find Find

		public static ControlliLocoLottoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis)

		{

			ControlliLocoLottoCollection ControlliLocoLottoCollectionObj = new ControlliLocoLottoCollection();

			IDbCommand findCmd = db.InitCmd("Zcontrollilocolottofindfind", new string[] {"IdLottoequalthis", "IdProgrammazioneequalthis", "ControlloConclusoequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			ControlliLocoLotto ControlliLocoLottoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ControlliLocoLottoObj = GetFromDatareader(db);
				ControlliLocoLottoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ControlliLocoLottoObj.IsDirty = false;
				ControlliLocoLottoObj.IsPersistent = true;
				ControlliLocoLottoCollectionObj.Add(ControlliLocoLottoObj);
			}
			db.Close();
			return ControlliLocoLottoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliLocoLottoCollectionProvider:IControlliLocoLottoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ControlliLocoLottoCollectionProvider : IControlliLocoLottoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliLocoLotto
		protected ControlliLocoLottoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliLocoLottoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliLocoLottoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliLocoLottoCollectionProvider(IntNT IdlottoEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT ControlloconclusoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IdprogrammazioneEqualThis, ControlloconclusoEqualThis);
		}

		//Costruttore3: ha in input controllilocolottoCollectionObj - non popola la collection
		public ControlliLocoLottoCollectionProvider(ControlliLocoLottoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliLocoLottoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliLocoLottoCollection(this);
		}

		//Get e Set
		public ControlliLocoLottoCollection CollectionObj
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
		public int SaveCollection(ControlliLocoLottoCollection collectionObj)
		{
			return ControlliLocoLottoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliLocoLotto controllilocolottoObj)
		{
			return ControlliLocoLottoDAL.Save(_dbProviderObj, controllilocolottoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliLocoLottoCollection collectionObj)
		{
			return ControlliLocoLottoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliLocoLotto controllilocolottoObj)
		{
			return ControlliLocoLottoDAL.Delete(_dbProviderObj, controllilocolottoObj);
		}

		//getById
		public ControlliLocoLotto GetById(IntNT IdLottoValue)
		{
			ControlliLocoLotto ControlliLocoLottoTemp = ControlliLocoLottoDAL.GetById(_dbProviderObj, IdLottoValue);
			if (ControlliLocoLottoTemp!=null) ControlliLocoLottoTemp.Provider = this;
			return ControlliLocoLottoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ControlliLocoLottoCollection Select(IntNT IdlottoEqualThis, DatetimeNT DatacreazioneEqualThis, DatetimeNT DatamodificaEqualThis, 
StringNT OperatoreEqualThis, DatetimeNT DataestrazioneEqualThis, IntNT NumeroestrazioniEqualThis, 
BoolNT ControlloconclusoEqualThis, StringNT SegnaturaEqualThis, IntNT IdprogrammazioneEqualThis)
		{
			ControlliLocoLottoCollection ControlliLocoLottoCollectionTemp = ControlliLocoLottoDAL.Select(_dbProviderObj, IdlottoEqualThis, DatacreazioneEqualThis, DatamodificaEqualThis, 
OperatoreEqualThis, DataestrazioneEqualThis, NumeroestrazioniEqualThis, 
ControlloconclusoEqualThis, SegnaturaEqualThis, IdprogrammazioneEqualThis);
			ControlliLocoLottoCollectionTemp.Provider = this;
			return ControlliLocoLottoCollectionTemp;
		}

		//Find: popola la collection
		public ControlliLocoLottoCollection Find(IntNT IdlottoEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT ControlloconclusoEqualThis)
		{
			ControlliLocoLottoCollection ControlliLocoLottoCollectionTemp = ControlliLocoLottoDAL.Find(_dbProviderObj, IdlottoEqualThis, IdprogrammazioneEqualThis, ControlloconclusoEqualThis);
			ControlliLocoLottoCollectionTemp.Provider = this;
			return ControlliLocoLottoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_LOCO_LOTTO>
  <ViewName>vCONTROLLI_LOCO_LOTTO</ViewName>
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
    <Find OrderBy="ORDER BY ID_LOTTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_LOCO_LOTTO>
*/
