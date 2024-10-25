using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CaaStoricoOperatori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICaaStoricoOperatoriProvider
	{
		int Save(CaaStoricoOperatori CaaStoricoOperatoriObj);
		int SaveCollection(CaaStoricoOperatoriCollection collectionObj);
		int Delete(CaaStoricoOperatori CaaStoricoOperatoriObj);
		int DeleteCollection(CaaStoricoOperatoriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CaaStoricoOperatori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CaaStoricoOperatori: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.BoolNT _MandatoPsr;
		private NullTypes.BoolNT _MandatoUma;
		private NullTypes.BoolNT _Responsabile;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		[NonSerialized] private ICaaStoricoOperatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaStoricoOperatoriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CaaStoricoOperatori()
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
		/// Corrisponde al campo:ID_OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatore
		{
			get { return _IdOperatore; }
			set {
				if (IdOperatore != value)
				{
					_IdOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_PSR
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MandatoPsr
		{
			get { return _MandatoPsr; }
			set {
				if (MandatoPsr != value)
				{
					_MandatoPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_UMA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT MandatoUma
		{
			get { return _MandatoUma; }
			set {
				if (MandatoUma != value)
				{
					_MandatoUma = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RESPONSABILE
		/// Tipo sul db:BIT
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
	/// Summary description for CaaStoricoOperatoriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaStoricoOperatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CaaStoricoOperatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CaaStoricoOperatori) info.GetValue(i.ToString(),typeof(CaaStoricoOperatori)));
			}
		}

		//Costruttore
		public CaaStoricoOperatoriCollection()
		{
			this.ItemType = typeof(CaaStoricoOperatori);
		}

		//Costruttore con provider
		public CaaStoricoOperatoriCollection(ICaaStoricoOperatoriProvider providerObj)
		{
			this.ItemType = typeof(CaaStoricoOperatori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CaaStoricoOperatori this[int index]
		{
			get { return (CaaStoricoOperatori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CaaStoricoOperatoriCollection GetChanges()
		{
			return (CaaStoricoOperatoriCollection) base.GetChanges();
		}

		[NonSerialized] private ICaaStoricoOperatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICaaStoricoOperatoriProvider Provider
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
		public int Add(CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			if (CaaStoricoOperatoriObj.Provider == null) CaaStoricoOperatoriObj.Provider = this.Provider;
			return base.Add(CaaStoricoOperatoriObj);
		}

		//AddCollection
		public void AddCollection(CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionObj)
		{
			foreach (CaaStoricoOperatori CaaStoricoOperatoriObj in CaaStoricoOperatoriCollectionObj)
				this.Add(CaaStoricoOperatoriObj);
		}

		//Insert
		public void Insert(int index, CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			if (CaaStoricoOperatoriObj.Provider == null) CaaStoricoOperatoriObj.Provider = this.Provider;
			base.Insert(index, CaaStoricoOperatoriObj);
		}

		//CollectionGetById
		public CaaStoricoOperatori CollectionGetById(NullTypes.IntNT IdValue)
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
		public CaaStoricoOperatoriCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdOperatoreEqualThis, NullTypes.BoolNT MandatoPsrEqualThis, 
NullTypes.BoolNT MandatoUmaEqualThis, NullTypes.BoolNT ResponsabileEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis)
		{
			CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionTemp = new CaaStoricoOperatoriCollection();
			foreach (CaaStoricoOperatori CaaStoricoOperatoriItem in this)
			{
				if (((IdEqualThis == null) || ((CaaStoricoOperatoriItem.Id != null) && (CaaStoricoOperatoriItem.Id.Value == IdEqualThis.Value))) && ((IdOperatoreEqualThis == null) || ((CaaStoricoOperatoriItem.IdOperatore != null) && (CaaStoricoOperatoriItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) && ((MandatoPsrEqualThis == null) || ((CaaStoricoOperatoriItem.MandatoPsr != null) && (CaaStoricoOperatoriItem.MandatoPsr.Value == MandatoPsrEqualThis.Value))) && 
((MandatoUmaEqualThis == null) || ((CaaStoricoOperatoriItem.MandatoUma != null) && (CaaStoricoOperatoriItem.MandatoUma.Value == MandatoUmaEqualThis.Value))) && ((ResponsabileEqualThis == null) || ((CaaStoricoOperatoriItem.Responsabile != null) && (CaaStoricoOperatoriItem.Responsabile.Value == ResponsabileEqualThis.Value))) && ((CodStatoEqualThis == null) || ((CaaStoricoOperatoriItem.CodStato != null) && (CaaStoricoOperatoriItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((DataEqualThis == null) || ((CaaStoricoOperatoriItem.Data != null) && (CaaStoricoOperatoriItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CaaStoricoOperatoriItem.Operatore != null) && (CaaStoricoOperatoriItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					CaaStoricoOperatoriCollectionTemp.Add(CaaStoricoOperatoriItem);
				}
			}
			return CaaStoricoOperatoriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CaaStoricoOperatoriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CaaStoricoOperatoriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CaaStoricoOperatori CaaStoricoOperatoriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CaaStoricoOperatoriObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatore", CaaStoricoOperatoriObj.IdOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoPsr", CaaStoricoOperatoriObj.MandatoPsr);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoUma", CaaStoricoOperatoriObj.MandatoUma);
			DbProvider.SetCmdParam(cmd,firstChar + "Responsabile", CaaStoricoOperatoriObj.Responsabile);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStato", CaaStoricoOperatoriObj.CodStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", CaaStoricoOperatoriObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CaaStoricoOperatoriObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCaaStoricoOperatoriInsert", new string[] {"IdOperatore", "MandatoPsr", 
"MandatoUma", "Responsabile", "CodStato", 
"Data", "Operatore"}, new string[] {"int", "bool", 
"bool", "bool", "string", 
"DateTime", "int"},"");
				CompileIUCmd(false, insertCmd,CaaStoricoOperatoriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CaaStoricoOperatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoOperatoriObj.IsDirty = false;
				CaaStoricoOperatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaStoricoOperatoriUpdate", new string[] {"Id", "IdOperatore", "MandatoPsr", 
"MandatoUma", "Responsabile", "CodStato", 
"Data", "Operatore"}, new string[] {"int", "int", "bool", 
"bool", "bool", "string", 
"DateTime", "int"},"");
				CompileIUCmd(true, updateCmd,CaaStoricoOperatoriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoOperatoriObj.IsDirty = false;
				CaaStoricoOperatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			switch (CaaStoricoOperatoriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CaaStoricoOperatoriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CaaStoricoOperatoriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CaaStoricoOperatoriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCaaStoricoOperatoriUpdate", new string[] {"Id", "IdOperatore", "MandatoPsr", 
"MandatoUma", "Responsabile", "CodStato", 
"Data", "Operatore"}, new string[] {"int", "int", "bool", 
"bool", "bool", "string", 
"DateTime", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCaaStoricoOperatoriInsert", new string[] {"IdOperatore", "MandatoPsr", 
"MandatoUma", "Responsabile", "CodStato", 
"Data", "Operatore"}, new string[] {"int", "bool", 
"bool", "bool", "string", 
"DateTime", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaStoricoOperatoriCollectionObj.Count; i++)
				{
					switch (CaaStoricoOperatoriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CaaStoricoOperatoriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CaaStoricoOperatoriCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CaaStoricoOperatoriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CaaStoricoOperatoriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CaaStoricoOperatoriCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CaaStoricoOperatoriCollectionObj.Count; i++)
				{
					if ((CaaStoricoOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaStoricoOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaStoricoOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CaaStoricoOperatoriCollectionObj[i].IsDirty = false;
						CaaStoricoOperatoriCollectionObj[i].IsPersistent = true;
					}
					if ((CaaStoricoOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CaaStoricoOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaStoricoOperatoriCollectionObj[i].IsDirty = false;
						CaaStoricoOperatoriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CaaStoricoOperatori CaaStoricoOperatoriObj)
		{
			int returnValue = 0;
			if (CaaStoricoOperatoriObj.IsPersistent) 
			{
				returnValue = Delete(db, CaaStoricoOperatoriObj.Id);
			}
			CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CaaStoricoOperatoriObj.IsDirty = false;
			CaaStoricoOperatoriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCaaStoricoOperatoriDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CaaStoricoOperatoriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CaaStoricoOperatoriCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CaaStoricoOperatoriCollectionObj.Count; i++)
				{
					if ((CaaStoricoOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CaaStoricoOperatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CaaStoricoOperatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CaaStoricoOperatoriCollectionObj[i].IsDirty = false;
						CaaStoricoOperatoriCollectionObj[i].IsPersistent = false;
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
		public static CaaStoricoOperatori GetById(DbProvider db, int IdValue)
		{
			CaaStoricoOperatori CaaStoricoOperatoriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCaaStoricoOperatoriGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CaaStoricoOperatoriObj = GetFromDatareader(db);
				CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoOperatoriObj.IsDirty = false;
				CaaStoricoOperatoriObj.IsPersistent = true;
			}
			db.Close();
			return CaaStoricoOperatoriObj;
		}

		//getFromDatareader
		public static CaaStoricoOperatori GetFromDatareader(DbProvider db)
		{
			CaaStoricoOperatori CaaStoricoOperatoriObj = new CaaStoricoOperatori();
			CaaStoricoOperatoriObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CaaStoricoOperatoriObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			CaaStoricoOperatoriObj.MandatoPsr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANDATO_PSR"]);
			CaaStoricoOperatoriObj.MandatoUma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANDATO_UMA"]);
			CaaStoricoOperatoriObj.Responsabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RESPONSABILE"]);
			CaaStoricoOperatoriObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			CaaStoricoOperatoriObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			CaaStoricoOperatoriObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CaaStoricoOperatoriObj.IsDirty = false;
			CaaStoricoOperatoriObj.IsPersistent = true;
			return CaaStoricoOperatoriObj;
		}

		//Find Select

		public static CaaStoricoOperatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT MandatoPsrEqualThis, 
SiarLibrary.NullTypes.BoolNT MandatoUmaEqualThis, SiarLibrary.NullTypes.BoolNT ResponsabileEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionObj = new CaaStoricoOperatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zcaastoricooperatorifindselect", new string[] {"Idequalthis", "IdOperatoreequalthis", "MandatoPsrequalthis", 
"MandatoUmaequalthis", "Responsabileequalthis", "CodStatoequalthis", 
"Dataequalthis", "Operatoreequalthis"}, new string[] {"int", "int", "bool", 
"bool", "bool", "string", 
"DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoPsrequalthis", MandatoPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoUmaequalthis", MandatoUmaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Responsabileequalthis", ResponsabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			CaaStoricoOperatori CaaStoricoOperatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaStoricoOperatoriObj = GetFromDatareader(db);
				CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoOperatoriObj.IsDirty = false;
				CaaStoricoOperatoriObj.IsPersistent = true;
				CaaStoricoOperatoriCollectionObj.Add(CaaStoricoOperatoriObj);
			}
			db.Close();
			return CaaStoricoOperatoriCollectionObj;
		}

		//Find Find

		public static CaaStoricoOperatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT ResponsabileEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionObj = new CaaStoricoOperatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zcaastoricooperatorifindfind", new string[] {"IdOperatoreequalthis", "Responsabileequalthis", "CodStatoequalthis"}, new string[] {"int", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Responsabileequalthis", ResponsabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			CaaStoricoOperatori CaaStoricoOperatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CaaStoricoOperatoriObj = GetFromDatareader(db);
				CaaStoricoOperatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CaaStoricoOperatoriObj.IsDirty = false;
				CaaStoricoOperatoriObj.IsPersistent = true;
				CaaStoricoOperatoriCollectionObj.Add(CaaStoricoOperatoriObj);
			}
			db.Close();
			return CaaStoricoOperatoriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CaaStoricoOperatoriCollectionProvider:ICaaStoricoOperatoriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CaaStoricoOperatoriCollectionProvider : ICaaStoricoOperatoriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CaaStoricoOperatori
		protected CaaStoricoOperatoriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CaaStoricoOperatoriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CaaStoricoOperatoriCollection(this);
		}

		//Costruttore 2: popola la collection
		public CaaStoricoOperatoriCollectionProvider(IntNT IdoperatoreEqualThis, BoolNT ResponsabileEqualThis, StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdoperatoreEqualThis, ResponsabileEqualThis, CodstatoEqualThis);
		}

		//Costruttore3: ha in input caastoricooperatoriCollectionObj - non popola la collection
		public CaaStoricoOperatoriCollectionProvider(CaaStoricoOperatoriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CaaStoricoOperatoriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CaaStoricoOperatoriCollection(this);
		}

		//Get e Set
		public CaaStoricoOperatoriCollection CollectionObj
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
		public int SaveCollection(CaaStoricoOperatoriCollection collectionObj)
		{
			return CaaStoricoOperatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CaaStoricoOperatori caastoricooperatoriObj)
		{
			return CaaStoricoOperatoriDAL.Save(_dbProviderObj, caastoricooperatoriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CaaStoricoOperatoriCollection collectionObj)
		{
			return CaaStoricoOperatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CaaStoricoOperatori caastoricooperatoriObj)
		{
			return CaaStoricoOperatoriDAL.Delete(_dbProviderObj, caastoricooperatoriObj);
		}

		//getById
		public CaaStoricoOperatori GetById(IntNT IdValue)
		{
			CaaStoricoOperatori CaaStoricoOperatoriTemp = CaaStoricoOperatoriDAL.GetById(_dbProviderObj, IdValue);
			if (CaaStoricoOperatoriTemp!=null) CaaStoricoOperatoriTemp.Provider = this;
			return CaaStoricoOperatoriTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CaaStoricoOperatoriCollection Select(IntNT IdEqualThis, IntNT IdoperatoreEqualThis, BoolNT MandatopsrEqualThis, 
BoolNT MandatoumaEqualThis, BoolNT ResponsabileEqualThis, StringNT CodstatoEqualThis, 
DatetimeNT DataEqualThis, IntNT OperatoreEqualThis)
		{
			CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionTemp = CaaStoricoOperatoriDAL.Select(_dbProviderObj, IdEqualThis, IdoperatoreEqualThis, MandatopsrEqualThis, 
MandatoumaEqualThis, ResponsabileEqualThis, CodstatoEqualThis, 
DataEqualThis, OperatoreEqualThis);
			CaaStoricoOperatoriCollectionTemp.Provider = this;
			return CaaStoricoOperatoriCollectionTemp;
		}

		//Find: popola la collection
		public CaaStoricoOperatoriCollection Find(IntNT IdoperatoreEqualThis, BoolNT ResponsabileEqualThis, StringNT CodstatoEqualThis)
		{
			CaaStoricoOperatoriCollection CaaStoricoOperatoriCollectionTemp = CaaStoricoOperatoriDAL.Find(_dbProviderObj, IdoperatoreEqualThis, ResponsabileEqualThis, CodstatoEqualThis);
			CaaStoricoOperatoriCollectionTemp.Provider = this;
			return CaaStoricoOperatoriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CAA_STORICO_OPERATORI>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_OPERATORE>Equal</ID_OPERATORE>
      <RESPONSABILE>Equal</RESPONSABILE>
      <COD_STATO>Equal</COD_STATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CAA_STORICO_OPERATORI>
*/
