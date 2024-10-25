using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CaaStoricoSportello
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICaaStoricoSportelloProvider
	{
		int Save(CaaStoricoSportello CaaStoricoSportelloObj);
		int SaveCollection(CaaStoricoSportelloCollection collectionObj);
		int Delete(CaaStoricoSportello CaaStoricoSportelloObj);
		int DeleteCollection(CaaStoricoSportelloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CaaStoricoSportello
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CaaStoricoSportello: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _CodiceSportello;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.BoolNT _UfficioProvinciale;
		private NullTypes.BoolNT _UfficioRegionale;
		private NullTypes.StringNT _Indirizzo;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Telefono;
		private NullTypes.StringNT _Fax;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		[NonSerialized] private ICaaStoricoSportelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaStoricoSportelloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CaaStoricoSportello()
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
		/// Corrisponde al campo:CODICE_SPORTELLO
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodiceSportello
		{
			get { return _CodiceSportello; }
			set {
				if (CodiceSportello != value)
				{
					_CodiceSportello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(60)
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
		/// Corrisponde al campo:UFFICIO_PROVINCIALE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT UfficioProvinciale
		{
			get { return _UfficioProvinciale; }
			set {
				if (UfficioProvinciale != value)
				{
					_UfficioProvinciale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UFFICIO_REGIONALE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT UfficioRegionale
		{
			get { return _UfficioRegionale; }
			set {
				if (UfficioRegionale != value)
				{
					_UfficioRegionale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INDIRIZZO
		/// Tipo sul db:VARCHAR(150)
		/// </summary>
		public NullTypes.StringNT Indirizzo
		{
			get { return _Indirizzo; }
			set {
				if (Indirizzo != value)
				{
					_Indirizzo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TELEFONO
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT Telefono
		{
			get { return _Telefono; }
			set {
				if (Telefono != value)
				{
					_Telefono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FAX
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT Fax
		{
			get { return _Fax; }
			set {
				if (Fax != value)
				{
					_Fax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Email
		{
			get { return _Email; }
			set {
				if (Email != value)
				{
					_Email = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
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
	/// Summary description for CaaStoricoSportelloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaStoricoSportelloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CaaStoricoSportelloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CaaStoricoSportello) info.GetValue(i.ToString(),typeof(CaaStoricoSportello)));
			}
		}

		//Costruttore
		public CaaStoricoSportelloCollection()
		{
			this.ItemType = typeof(CaaStoricoSportello);
		}

		//Costruttore con provider
		public CaaStoricoSportelloCollection(ICaaStoricoSportelloProvider providerObj)
		{
			this.ItemType = typeof(CaaStoricoSportello);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CaaStoricoSportello this[int index]
		{
			get { return (CaaStoricoSportello)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CaaStoricoSportelloCollection GetChanges()
		{
			return (CaaStoricoSportelloCollection) base.GetChanges();
		}

		[NonSerialized] private ICaaStoricoSportelloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaStoricoSportelloProvider Provider
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
		public int Add(CaaStoricoSportello CaaStoricoSportelloObj)
		{
			if (CaaStoricoSportelloObj.Provider == null) CaaStoricoSportelloObj.Provider = this.Provider;
			return base.Add(CaaStoricoSportelloObj);
		}

		//AddCollection
		public void AddCollection(CaaStoricoSportelloCollection CaaStoricoSportelloCollectionObj)
		{
			foreach (CaaStoricoSportello CaaStoricoSportelloObj in CaaStoricoSportelloCollectionObj)
				this.Add(CaaStoricoSportelloObj);
		}

		//Insert
		public void Insert(int index, CaaStoricoSportello CaaStoricoSportelloObj)
		{
			if (CaaStoricoSportelloObj.Provider == null) CaaStoricoSportelloObj.Provider = this.Provider;
			base.Insert(index, CaaStoricoSportelloObj);
		}

		//CollectionGetById
		public CaaStoricoSportello CollectionGetById(NullTypes.IntNT IdValue)
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
		public CaaStoricoSportelloCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CodiceSportelloEqualThis, NullTypes.StringNT DenominazioneEqualThis, 
NullTypes.BoolNT UfficioProvincialeEqualThis, NullTypes.BoolNT UfficioRegionaleEqualThis, NullTypes.StringNT IndirizzoEqualThis, 
NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT TelefonoEqualThis, NullTypes.StringNT FaxEqualThis, 
NullTypes.StringNT EmailEqualThis, NullTypes.StringNT CodStatoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT OperatoreEqualThis)
		{
			CaaStoricoSportelloCollection CaaStoricoSportelloCollectionTemp = new CaaStoricoSportelloCollection();
			foreach (CaaStoricoSportello CaaStoricoSportelloItem in this)
			{
				if (((IdEqualThis == null) || ((CaaStoricoSportelloItem.Id != null) && (CaaStoricoSportelloItem.Id.Value == IdEqualThis.Value))) && ((CodiceSportelloEqualThis == null) || ((CaaStoricoSportelloItem.CodiceSportello != null) && (CaaStoricoSportelloItem.CodiceSportello.Value == CodiceSportelloEqualThis.Value))) && ((DenominazioneEqualThis == null) || ((CaaStoricoSportelloItem.Denominazione != null) && (CaaStoricoSportelloItem.Denominazione.Value == DenominazioneEqualThis.Value))) && 
((UfficioProvincialeEqualThis == null) || ((CaaStoricoSportelloItem.UfficioProvinciale != null) && (CaaStoricoSportelloItem.UfficioProvinciale.Value == UfficioProvincialeEqualThis.Value))) && ((UfficioRegionaleEqualThis == null) || ((CaaStoricoSportelloItem.UfficioRegionale != null) && (CaaStoricoSportelloItem.UfficioRegionale.Value == UfficioRegionaleEqualThis.Value))) && ((IndirizzoEqualThis == null) || ((CaaStoricoSportelloItem.Indirizzo != null) && (CaaStoricoSportelloItem.Indirizzo.Value == IndirizzoEqualThis.Value))) && 
((IdComuneEqualThis == null) || ((CaaStoricoSportelloItem.IdComune != null) && (CaaStoricoSportelloItem.IdComune.Value == IdComuneEqualThis.Value))) && ((TelefonoEqualThis == null) || ((CaaStoricoSportelloItem.Telefono != null) && (CaaStoricoSportelloItem.Telefono.Value == TelefonoEqualThis.Value))) && ((FaxEqualThis == null) || ((CaaStoricoSportelloItem.Fax != null) && (CaaStoricoSportelloItem.Fax.Value == FaxEqualThis.Value))) && 
((EmailEqualThis == null) || ((CaaStoricoSportelloItem.Email != null) && (CaaStoricoSportelloItem.Email.Value == EmailEqualThis.Value))) && ((CodStatoEqualThis == null) || ((CaaStoricoSportelloItem.CodStato != null) && (CaaStoricoSportelloItem.CodStato.Value == CodStatoEqualThis.Value))) && ((DataEqualThis == null) || ((CaaStoricoSportelloItem.Data != null) && (CaaStoricoSportelloItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CaaStoricoSportelloItem.Operatore != null) && (CaaStoricoSportelloItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					CaaStoricoSportelloCollectionTemp.Add(CaaStoricoSportelloItem);
				}
			}
			return CaaStoricoSportelloCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CaaStoricoSportelloDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CaaStoricoSportelloDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CaaStoricoSportello CaaStoricoSportelloObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CaaStoricoSportelloObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceSportello", CaaStoricoSportelloObj.CodiceSportello);
			DbProvider.SetCmdParam(cmd,firstChar + "Denominazione", CaaStoricoSportelloObj.Denominazione);
			DbProvider.SetCmdParam(cmd,firstChar + "UfficioProvinciale", CaaStoricoSportelloObj.UfficioProvinciale);
			DbProvider.SetCmdParam(cmd,firstChar + "UfficioRegionale", CaaStoricoSportelloObj.UfficioRegionale);
			DbProvider.SetCmdParam(cmd,firstChar + "Indirizzo", CaaStoricoSportelloObj.Indirizzo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", CaaStoricoSportelloObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "Telefono", CaaStoricoSportelloObj.Telefono);
			DbProvider.SetCmdParam(cmd,firstChar + "Fax", CaaStoricoSportelloObj.Fax);
			DbProvider.SetCmdParam(cmd,firstChar + "Email", CaaStoricoSportelloObj.Email);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStato", CaaStoricoSportelloObj.CodStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", CaaStoricoSportelloObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CaaStoricoSportelloObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, CaaStoricoSportello CaaStoricoSportelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCaaStoricoSportelloInsert", new string[] {"CodiceSportello", "Denominazione", 
"UfficioProvinciale", "UfficioRegionale", "Indirizzo", 
"IdComune", "Telefono", "Fax", 
"Email", "CodStato", "Data", 
"Operatore"}, new string[] {"string", "string", 
"bool", "bool", "string", 
"int", "string", "string", 
"string", "string", "DateTime", 
"int"},"");
				CompileIUCmd(false, insertCmd,CaaStoricoSportelloObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CaaStoricoSportelloObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				CaaStoricoSportelloObj.UfficioProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_PROVINCIALE"]);
				CaaStoricoSportelloObj.UfficioRegionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_REGIONALE"]);
				}
				CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoSportelloObj.IsDirty = false;
				CaaStoricoSportelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CaaStoricoSportello CaaStoricoSportelloObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaStoricoSportelloUpdate", new string[] {"Id", "CodiceSportello", "Denominazione", 
"UfficioProvinciale", "UfficioRegionale", "Indirizzo", 
"IdComune", "Telefono", "Fax", 
"Email", "CodStato", "Data", 
"Operatore"}, new string[] {"int", "string", "string", 
"bool", "bool", "string", 
"int", "string", "string", 
"string", "string", "DateTime", 
"int"},"");
				CompileIUCmd(true, updateCmd,CaaStoricoSportelloObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoSportelloObj.IsDirty = false;
				CaaStoricoSportelloObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CaaStoricoSportello CaaStoricoSportelloObj)
		{
			switch (CaaStoricoSportelloObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CaaStoricoSportelloObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CaaStoricoSportelloObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CaaStoricoSportelloObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CaaStoricoSportelloCollection CaaStoricoSportelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaStoricoSportelloUpdate", new string[] {"Id", "CodiceSportello", "Denominazione", 
"UfficioProvinciale", "UfficioRegionale", "Indirizzo", 
"IdComune", "Telefono", "Fax", 
"Email", "CodStato", "Data", 
"Operatore"}, new string[] {"int", "string", "string", 
"bool", "bool", "string", 
"int", "string", "string", 
"string", "string", "DateTime", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCaaStoricoSportelloInsert", new string[] {"CodiceSportello", "Denominazione", 
"UfficioProvinciale", "UfficioRegionale", "Indirizzo", 
"IdComune", "Telefono", "Fax", 
"Email", "CodStato", "Data", 
"Operatore"}, new string[] {"string", "string", 
"bool", "bool", "string", 
"int", "string", "string", 
"string", "string", "DateTime", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoSportelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaStoricoSportelloCollectionObj.Count; i++)
				{
					switch (CaaStoricoSportelloCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CaaStoricoSportelloCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CaaStoricoSportelloCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									CaaStoricoSportelloCollectionObj[i].UfficioProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_PROVINCIALE"]);
									CaaStoricoSportelloCollectionObj[i].UfficioRegionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_REGIONALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CaaStoricoSportelloCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CaaStoricoSportelloCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CaaStoricoSportelloCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CaaStoricoSportelloCollectionObj.Count; i++)
				{
					if ((CaaStoricoSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaStoricoSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaStoricoSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CaaStoricoSportelloCollectionObj[i].IsDirty = false;
						CaaStoricoSportelloCollectionObj[i].IsPersistent = true;
					}
					if ((CaaStoricoSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CaaStoricoSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaStoricoSportelloCollectionObj[i].IsDirty = false;
						CaaStoricoSportelloCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CaaStoricoSportello CaaStoricoSportelloObj)
		{
			int returnValue = 0;
			if (CaaStoricoSportelloObj.IsPersistent) 
			{
				returnValue = Delete(db, CaaStoricoSportelloObj.Id);
			}
			CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CaaStoricoSportelloObj.IsDirty = false;
			CaaStoricoSportelloObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoSportelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CaaStoricoSportelloCollection CaaStoricoSportelloCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoSportelloDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaStoricoSportelloCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CaaStoricoSportelloCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CaaStoricoSportelloCollectionObj.Count; i++)
				{
					if ((CaaStoricoSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaStoricoSportelloCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaStoricoSportelloCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaStoricoSportelloCollectionObj[i].IsDirty = false;
						CaaStoricoSportelloCollectionObj[i].IsPersistent = false;
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
		public static CaaStoricoSportello GetById(DbProvider db, int IdValue)
		{
			CaaStoricoSportello CaaStoricoSportelloObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCaaStoricoSportelloGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CaaStoricoSportelloObj = GetFromDatareader(db);
				CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoSportelloObj.IsDirty = false;
				CaaStoricoSportelloObj.IsPersistent = true;
			}
			db.Close();
			return CaaStoricoSportelloObj;
		}

		//getFromDatareader
		public static CaaStoricoSportello GetFromDatareader(DbProvider db)
		{
			CaaStoricoSportello CaaStoricoSportelloObj = new CaaStoricoSportello();
			CaaStoricoSportelloObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CaaStoricoSportelloObj.CodiceSportello = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_SPORTELLO"]);
			CaaStoricoSportelloObj.Denominazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE"]);
			CaaStoricoSportelloObj.UfficioProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_PROVINCIALE"]);
			CaaStoricoSportelloObj.UfficioRegionale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["UFFICIO_REGIONALE"]);
			CaaStoricoSportelloObj.Indirizzo = new SiarLibrary.NullTypes.StringNT(db.DataReader["INDIRIZZO"]);
			CaaStoricoSportelloObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			CaaStoricoSportelloObj.Telefono = new SiarLibrary.NullTypes.StringNT(db.DataReader["TELEFONO"]);
			CaaStoricoSportelloObj.Fax = new SiarLibrary.NullTypes.StringNT(db.DataReader["FAX"]);
			CaaStoricoSportelloObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			CaaStoricoSportelloObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			CaaStoricoSportelloObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CaaStoricoSportelloObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CaaStoricoSportelloObj.IsDirty = false;
			CaaStoricoSportelloObj.IsPersistent = true;
			return CaaStoricoSportelloObj;
		}

		//Find Select

		public static CaaStoricoSportelloCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CodiceSportelloEqualThis, SiarLibrary.NullTypes.StringNT DenominazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT UfficioProvincialeEqualThis, SiarLibrary.NullTypes.BoolNT UfficioRegionaleEqualThis, SiarLibrary.NullTypes.StringNT IndirizzoEqualThis, 
SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT TelefonoEqualThis, SiarLibrary.NullTypes.StringNT FaxEqualThis, 
SiarLibrary.NullTypes.StringNT EmailEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			CaaStoricoSportelloCollection CaaStoricoSportelloCollectionObj = new CaaStoricoSportelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcaastoricosportellofindselect", new string[] {"Idequalthis", "CodiceSportelloequalthis", "Denominazioneequalthis", 
"UfficioProvincialeequalthis", "UfficioRegionaleequalthis", "Indirizzoequalthis", 
"IdComuneequalthis", "Telefonoequalthis", "Faxequalthis", 
"Emailequalthis", "CodStatoequalthis", "Dataequalthis", 
"Operatoreequalthis"}, new string[] {"int", "string", "string", 
"bool", "bool", "string", 
"int", "string", "string", 
"string", "string", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSportelloequalthis", CodiceSportelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Denominazioneequalthis", DenominazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UfficioProvincialeequalthis", UfficioProvincialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UfficioRegionaleequalthis", UfficioRegionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Indirizzoequalthis", IndirizzoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Telefonoequalthis", TelefonoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Faxequalthis", FaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			CaaStoricoSportello CaaStoricoSportelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaStoricoSportelloObj = GetFromDatareader(db);
				CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoSportelloObj.IsDirty = false;
				CaaStoricoSportelloObj.IsPersistent = true;
				CaaStoricoSportelloCollectionObj.Add(CaaStoricoSportelloObj);
			}
			db.Close();
			return CaaStoricoSportelloCollectionObj;
		}

		//Find Find

		public static CaaStoricoSportelloCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceSportelloEqualThis, SiarLibrary.NullTypes.BoolNT UfficioProvincialeEqualThis, SiarLibrary.NullTypes.BoolNT UfficioRegionaleEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			CaaStoricoSportelloCollection CaaStoricoSportelloCollectionObj = new CaaStoricoSportelloCollection();

			IDbCommand findCmd = db.InitCmd("Zcaastoricosportellofindfind", new string[] {"CodiceSportelloequalthis", "UfficioProvincialeequalthis", "UfficioRegionaleequalthis", 
"CodStatoequalthis"}, new string[] {"string", "bool", "bool", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceSportelloequalthis", CodiceSportelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UfficioProvincialeequalthis", UfficioProvincialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UfficioRegionaleequalthis", UfficioRegionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			CaaStoricoSportello CaaStoricoSportelloObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaStoricoSportelloObj = GetFromDatareader(db);
				CaaStoricoSportelloObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoSportelloObj.IsDirty = false;
				CaaStoricoSportelloObj.IsPersistent = true;
				CaaStoricoSportelloCollectionObj.Add(CaaStoricoSportelloObj);
			}
			db.Close();
			return CaaStoricoSportelloCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CaaStoricoSportelloCollectionProvider:ICaaStoricoSportelloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaStoricoSportelloCollectionProvider : ICaaStoricoSportelloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CaaStoricoSportello
		protected CaaStoricoSportelloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CaaStoricoSportelloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CaaStoricoSportelloCollection(this);
		}

		//Costruttore 2: popola la collection
		public CaaStoricoSportelloCollectionProvider(StringNT CodicesportelloEqualThis, BoolNT UfficioprovincialeEqualThis, BoolNT UfficioregionaleEqualThis, 
StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodicesportelloEqualThis, UfficioprovincialeEqualThis, UfficioregionaleEqualThis, 
CodstatoEqualThis);
		}

		//Costruttore3: ha in input caastoricosportelloCollectionObj - non popola la collection
		public CaaStoricoSportelloCollectionProvider(CaaStoricoSportelloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CaaStoricoSportelloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CaaStoricoSportelloCollection(this);
		}

		//Get e Set
		public CaaStoricoSportelloCollection CollectionObj
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
		public int SaveCollection(CaaStoricoSportelloCollection collectionObj)
		{
			return CaaStoricoSportelloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CaaStoricoSportello caastoricosportelloObj)
		{
			return CaaStoricoSportelloDAL.Save(_dbProviderObj, caastoricosportelloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CaaStoricoSportelloCollection collectionObj)
		{
			return CaaStoricoSportelloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CaaStoricoSportello caastoricosportelloObj)
		{
			return CaaStoricoSportelloDAL.Delete(_dbProviderObj, caastoricosportelloObj);
		}

		//getById
		public CaaStoricoSportello GetById(IntNT IdValue)
		{
			CaaStoricoSportello CaaStoricoSportelloTemp = CaaStoricoSportelloDAL.GetById(_dbProviderObj, IdValue);
			if (CaaStoricoSportelloTemp!=null) CaaStoricoSportelloTemp.Provider = this;
			return CaaStoricoSportelloTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CaaStoricoSportelloCollection Select(IntNT IdEqualThis, StringNT CodicesportelloEqualThis, StringNT DenominazioneEqualThis, 
BoolNT UfficioprovincialeEqualThis, BoolNT UfficioregionaleEqualThis, StringNT IndirizzoEqualThis, 
IntNT IdcomuneEqualThis, StringNT TelefonoEqualThis, StringNT FaxEqualThis, 
StringNT EmailEqualThis, StringNT CodstatoEqualThis, DatetimeNT DataEqualThis, 
IntNT OperatoreEqualThis)
		{
			CaaStoricoSportelloCollection CaaStoricoSportelloCollectionTemp = CaaStoricoSportelloDAL.Select(_dbProviderObj, IdEqualThis, CodicesportelloEqualThis, DenominazioneEqualThis, 
UfficioprovincialeEqualThis, UfficioregionaleEqualThis, IndirizzoEqualThis, 
IdcomuneEqualThis, TelefonoEqualThis, FaxEqualThis, 
EmailEqualThis, CodstatoEqualThis, DataEqualThis, 
OperatoreEqualThis);
			CaaStoricoSportelloCollectionTemp.Provider = this;
			return CaaStoricoSportelloCollectionTemp;
		}

		//Find: popola la collection
		public CaaStoricoSportelloCollection Find(StringNT CodicesportelloEqualThis, BoolNT UfficioprovincialeEqualThis, BoolNT UfficioregionaleEqualThis, 
StringNT CodstatoEqualThis)
		{
			CaaStoricoSportelloCollection CaaStoricoSportelloCollectionTemp = CaaStoricoSportelloDAL.Find(_dbProviderObj, CodicesportelloEqualThis, UfficioprovincialeEqualThis, UfficioregionaleEqualThis, 
CodstatoEqualThis);
			CaaStoricoSportelloCollectionTemp.Provider = this;
			return CaaStoricoSportelloCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CAA_STORICO_SPORTELLO>
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
    <Find OrderBy="ORDER BY">
      <CODICE_SPORTELLO>Equal</CODICE_SPORTELLO>
      <UFFICIO_PROVINCIALE>Equal</UFFICIO_PROVINCIALE>
      <UFFICIO_REGIONALE>Equal</UFFICIO_REGIONALE>
      <COD_STATO>Equal</COD_STATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CAA_STORICO_SPORTELLO>
*/
