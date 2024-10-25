using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspRecuperi
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspRecuperiProvider
	{
		int Save(CertspRecuperi CertspRecuperiObj);
		int SaveCollection(CertspRecuperiCollection collectionObj);
		int Delete(CertspRecuperi CertspRecuperiObj);
		int DeleteCollection(CertspRecuperiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspRecuperi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspRecuperi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRecupero;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.DecimalNT _Sostegno;
		private NullTypes.DecimalNT _SpeseAmm;
		private NullTypes.DatetimeNT _DataRicevRimb;
		private NullTypes.DecimalNT _RimbSostegno;
		private NullTypes.DecimalNT _RimbSpeseAmm;
		private NullTypes.DecimalNT _NonrSostegno;
		private NullTypes.DecimalNT _NonrSpeseAmm;
		[NonSerialized] private ICertspRecuperiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspRecuperiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspRecuperi()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:Id_Recupero
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRecupero
		{
			get { return _IdRecupero; }
			set {
				if (IdRecupero != value)
				{
					_IdRecupero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Progetto
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Atto
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

		/// <summary>
		/// Corrisponde al campo:Sostegno
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Sostegno
		{
			get { return _Sostegno; }
			set {
				if (Sostegno != value)
				{
					_Sostegno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Spese_Amm
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT SpeseAmm
		{
			get { return _SpeseAmm; }
			set {
				if (SpeseAmm != value)
				{
					_SpeseAmm = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Data_Ricev_Rimb
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRicevRimb
		{
			get { return _DataRicevRimb; }
			set {
				if (DataRicevRimb != value)
				{
					_DataRicevRimb = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Rimb_Sostegno
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT RimbSostegno
		{
			get { return _RimbSostegno; }
			set {
				if (RimbSostegno != value)
				{
					_RimbSostegno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Rimb_Spese_Amm
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT RimbSpeseAmm
		{
			get { return _RimbSpeseAmm; }
			set {
				if (RimbSpeseAmm != value)
				{
					_RimbSpeseAmm = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NonR_Sostegno
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT NonrSostegno
		{
			get { return _NonrSostegno; }
			set {
				if (NonrSostegno != value)
				{
					_NonrSostegno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NonR_Spese_Amm
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT NonrSpeseAmm
		{
			get { return _NonrSpeseAmm; }
			set {
				if (NonrSpeseAmm != value)
				{
					_NonrSpeseAmm = value;
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
	/// Summary description for CertspRecuperiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspRecuperiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspRecuperiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspRecuperi) info.GetValue(i.ToString(),typeof(CertspRecuperi)));
			}
		}

		//Costruttore
		public CertspRecuperiCollection()
		{
			this.ItemType = typeof(CertspRecuperi);
		}

		//Costruttore con provider
		public CertspRecuperiCollection(ICertspRecuperiProvider providerObj)
		{
			this.ItemType = typeof(CertspRecuperi);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspRecuperi this[int index]
		{
			get { return (CertspRecuperi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspRecuperiCollection GetChanges()
		{
			return (CertspRecuperiCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspRecuperiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspRecuperiProvider Provider
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
		public int Add(CertspRecuperi CertspRecuperiObj)
		{
			if (CertspRecuperiObj.Provider == null) CertspRecuperiObj.Provider = this.Provider;
			return base.Add(CertspRecuperiObj);
		}

		//AddCollection
		public void AddCollection(CertspRecuperiCollection CertspRecuperiCollectionObj)
		{
			foreach (CertspRecuperi CertspRecuperiObj in CertspRecuperiCollectionObj)
				this.Add(CertspRecuperiObj);
		}

		//Insert
		public void Insert(int index, CertspRecuperi CertspRecuperiObj)
		{
			if (CertspRecuperiObj.Provider == null) CertspRecuperiObj.Provider = this.Provider;
			base.Insert(index, CertspRecuperiObj);
		}

		//CollectionGetById
		public CertspRecuperi CollectionGetById(NullTypes.IntNT IdRecuperoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRecupero == IdRecuperoValue))
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
		public CertspRecuperiCollection SubSelect(NullTypes.IntNT IdRecuperoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdAttoEqualThis, 
NullTypes.DecimalNT SostegnoEqualThis, NullTypes.DecimalNT SpeseAmmEqualThis, NullTypes.DatetimeNT DataRicevRimbEqualThis, 
NullTypes.DecimalNT RimbSostegnoEqualThis, NullTypes.DecimalNT RimbSpeseAmmEqualThis, NullTypes.DecimalNT NonrSostegnoEqualThis, 
NullTypes.DecimalNT NonrSpeseAmmEqualThis)
		{
			CertspRecuperiCollection CertspRecuperiCollectionTemp = new CertspRecuperiCollection();
			foreach (CertspRecuperi CertspRecuperiItem in this)
			{
				if (((IdRecuperoEqualThis == null) || ((CertspRecuperiItem.IdRecupero != null) && (CertspRecuperiItem.IdRecupero.Value == IdRecuperoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CertspRecuperiItem.IdProgetto != null) && (CertspRecuperiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdAttoEqualThis == null) || ((CertspRecuperiItem.IdAtto != null) && (CertspRecuperiItem.IdAtto.Value == IdAttoEqualThis.Value))) && 
((SostegnoEqualThis == null) || ((CertspRecuperiItem.Sostegno != null) && (CertspRecuperiItem.Sostegno.Value == SostegnoEqualThis.Value))) && ((SpeseAmmEqualThis == null) || ((CertspRecuperiItem.SpeseAmm != null) && (CertspRecuperiItem.SpeseAmm.Value == SpeseAmmEqualThis.Value))) && ((DataRicevRimbEqualThis == null) || ((CertspRecuperiItem.DataRicevRimb != null) && (CertspRecuperiItem.DataRicevRimb.Value == DataRicevRimbEqualThis.Value))) && 
((RimbSostegnoEqualThis == null) || ((CertspRecuperiItem.RimbSostegno != null) && (CertspRecuperiItem.RimbSostegno.Value == RimbSostegnoEqualThis.Value))) && ((RimbSpeseAmmEqualThis == null) || ((CertspRecuperiItem.RimbSpeseAmm != null) && (CertspRecuperiItem.RimbSpeseAmm.Value == RimbSpeseAmmEqualThis.Value))) && ((NonrSostegnoEqualThis == null) || ((CertspRecuperiItem.NonrSostegno != null) && (CertspRecuperiItem.NonrSostegno.Value == NonrSostegnoEqualThis.Value))) && 
((NonrSpeseAmmEqualThis == null) || ((CertspRecuperiItem.NonrSpeseAmm != null) && (CertspRecuperiItem.NonrSpeseAmm.Value == NonrSpeseAmmEqualThis.Value))))
				{
					CertspRecuperiCollectionTemp.Add(CertspRecuperiItem);
				}
			}
			return CertspRecuperiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspRecuperiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspRecuperiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspRecuperi CertspRecuperiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRecupero", CertspRecuperiObj.IdRecupero);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CertspRecuperiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", CertspRecuperiObj.IdAtto);
			DbProvider.SetCmdParam(cmd,firstChar + "Sostegno", CertspRecuperiObj.Sostegno);
			DbProvider.SetCmdParam(cmd,firstChar + "SpeseAmm", CertspRecuperiObj.SpeseAmm);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRicevRimb", CertspRecuperiObj.DataRicevRimb);
			DbProvider.SetCmdParam(cmd,firstChar + "RimbSostegno", CertspRecuperiObj.RimbSostegno);
			DbProvider.SetCmdParam(cmd,firstChar + "RimbSpeseAmm", CertspRecuperiObj.RimbSpeseAmm);
			DbProvider.SetCmdParam(cmd,firstChar + "NonrSostegno", CertspRecuperiObj.NonrSostegno);
			DbProvider.SetCmdParam(cmd,firstChar + "NonrSpeseAmm", CertspRecuperiObj.NonrSpeseAmm);
		}
		//Insert
		private static int Insert(DbProvider db, CertspRecuperi CertspRecuperiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspRecuperiInsert", new string[] {"IdProgetto", "IdAtto", 
"Sostegno", "SpeseAmm", "DataRicevRimb", 
"RimbSostegno", "RimbSpeseAmm", "NonrSostegno", 
"NonrSpeseAmm"}, new string[] {"int", "int", 
"decimal", "decimal", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,CertspRecuperiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspRecuperiObj.IdRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Recupero"]);
				}
				CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspRecuperiObj.IsDirty = false;
				CertspRecuperiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspRecuperi CertspRecuperiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspRecuperiUpdate", new string[] {"IdRecupero", "IdProgetto", "IdAtto", 
"Sostegno", "SpeseAmm", "DataRicevRimb", 
"RimbSostegno", "RimbSpeseAmm", "NonrSostegno", 
"NonrSpeseAmm"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,CertspRecuperiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspRecuperiObj.IsDirty = false;
				CertspRecuperiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspRecuperi CertspRecuperiObj)
		{
			switch (CertspRecuperiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspRecuperiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspRecuperiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspRecuperiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspRecuperiCollection CertspRecuperiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspRecuperiUpdate", new string[] {"IdRecupero", "IdProgetto", "IdAtto", 
"Sostegno", "SpeseAmm", "DataRicevRimb", 
"RimbSostegno", "RimbSpeseAmm", "NonrSostegno", 
"NonrSpeseAmm"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspRecuperiInsert", new string[] {"IdProgetto", "IdAtto", 
"Sostegno", "SpeseAmm", "DataRicevRimb", 
"RimbSostegno", "RimbSpeseAmm", "NonrSostegno", 
"NonrSpeseAmm"}, new string[] {"int", "int", 
"decimal", "decimal", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspRecuperiDelete", new string[] {"IdRecupero"}, new string[] {"int"},"");
				for (int i = 0; i < CertspRecuperiCollectionObj.Count; i++)
				{
					switch (CertspRecuperiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspRecuperiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspRecuperiCollectionObj[i].IdRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Recupero"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspRecuperiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspRecuperiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRecupero", (SiarLibrary.NullTypes.IntNT)CertspRecuperiCollectionObj[i].IdRecupero);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspRecuperiCollectionObj.Count; i++)
				{
					if ((CertspRecuperiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspRecuperiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspRecuperiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspRecuperiCollectionObj[i].IsDirty = false;
						CertspRecuperiCollectionObj[i].IsPersistent = true;
					}
					if ((CertspRecuperiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspRecuperiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspRecuperiCollectionObj[i].IsDirty = false;
						CertspRecuperiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspRecuperi CertspRecuperiObj)
		{
			int returnValue = 0;
			if (CertspRecuperiObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspRecuperiObj.IdRecupero);
			}
			CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspRecuperiObj.IsDirty = false;
			CertspRecuperiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRecuperoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspRecuperiDelete", new string[] {"IdRecupero"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRecupero", (SiarLibrary.NullTypes.IntNT)IdRecuperoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspRecuperiCollection CertspRecuperiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspRecuperiDelete", new string[] {"IdRecupero"}, new string[] {"int"},"");
				for (int i = 0; i < CertspRecuperiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRecupero", CertspRecuperiCollectionObj[i].IdRecupero);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspRecuperiCollectionObj.Count; i++)
				{
					if ((CertspRecuperiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspRecuperiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspRecuperiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspRecuperiCollectionObj[i].IsDirty = false;
						CertspRecuperiCollectionObj[i].IsPersistent = false;
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
		public static CertspRecuperi GetById(DbProvider db, int IdRecuperoValue)
		{
			CertspRecuperi CertspRecuperiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspRecuperiGetById", new string[] {"IdRecupero"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRecupero", (SiarLibrary.NullTypes.IntNT)IdRecuperoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspRecuperiObj = GetFromDatareader(db);
				CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspRecuperiObj.IsDirty = false;
				CertspRecuperiObj.IsPersistent = true;
			}
			db.Close();
			return CertspRecuperiObj;
		}

		//getFromDatareader
		public static CertspRecuperi GetFromDatareader(DbProvider db)
		{
			CertspRecuperi CertspRecuperiObj = new CertspRecuperi();
			CertspRecuperiObj.IdRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Recupero"]);
			CertspRecuperiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
			CertspRecuperiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Atto"]);
			CertspRecuperiObj.Sostegno = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Sostegno"]);
			CertspRecuperiObj.SpeseAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Spese_Amm"]);
			CertspRecuperiObj.DataRicevRimb = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["Data_Ricev_Rimb"]);
			CertspRecuperiObj.RimbSostegno = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Rimb_Sostegno"]);
			CertspRecuperiObj.RimbSpeseAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["Rimb_Spese_Amm"]);
			CertspRecuperiObj.NonrSostegno = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["NonR_Sostegno"]);
			CertspRecuperiObj.NonrSpeseAmm = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["NonR_Spese_Amm"]);
			CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspRecuperiObj.IsDirty = false;
			CertspRecuperiObj.IsPersistent = true;
			return CertspRecuperiObj;
		}

		//Find Select

		public static CertspRecuperiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRecuperoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, 
SiarLibrary.NullTypes.DecimalNT SostegnoEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseAmmEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRicevRimbEqualThis, 
SiarLibrary.NullTypes.DecimalNT RimbSostegnoEqualThis, SiarLibrary.NullTypes.DecimalNT RimbSpeseAmmEqualThis, SiarLibrary.NullTypes.DecimalNT NonrSostegnoEqualThis, 
SiarLibrary.NullTypes.DecimalNT NonrSpeseAmmEqualThis)

		{

			CertspRecuperiCollection CertspRecuperiCollectionObj = new CertspRecuperiCollection();

			IDbCommand findCmd = db.InitCmd("Zcertsprecuperifindselect", new string[] {"IdRecuperoequalthis", "IdProgettoequalthis", "IdAttoequalthis", 
"Sostegnoequalthis", "SpeseAmmequalthis", "DataRicevRimbequalthis", 
"RimbSostegnoequalthis", "RimbSpeseAmmequalthis", "NonrSostegnoequalthis", 
"NonrSpeseAmmequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRecuperoequalthis", IdRecuperoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sostegnoequalthis", SostegnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpeseAmmequalthis", SpeseAmmEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRicevRimbequalthis", DataRicevRimbEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RimbSostegnoequalthis", RimbSostegnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RimbSpeseAmmequalthis", RimbSpeseAmmEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NonrSostegnoequalthis", NonrSostegnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NonrSpeseAmmequalthis", NonrSpeseAmmEqualThis);
			CertspRecuperi CertspRecuperiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspRecuperiObj = GetFromDatareader(db);
				CertspRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspRecuperiObj.IsDirty = false;
				CertspRecuperiObj.IsPersistent = true;
				CertspRecuperiCollectionObj.Add(CertspRecuperiObj);
			}
			db.Close();
			return CertspRecuperiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspRecuperiCollectionProvider:ICertspRecuperiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspRecuperiCollectionProvider : ICertspRecuperiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspRecuperi
		protected CertspRecuperiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspRecuperiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspRecuperiCollection(this);
		}

		//Costruttore3: ha in input certsprecuperiCollectionObj - non popola la collection
		public CertspRecuperiCollectionProvider(CertspRecuperiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspRecuperiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspRecuperiCollection(this);
		}

		//Get e Set
		public CertspRecuperiCollection CollectionObj
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
		public int SaveCollection(CertspRecuperiCollection collectionObj)
		{
			return CertspRecuperiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspRecuperi certsprecuperiObj)
		{
			return CertspRecuperiDAL.Save(_dbProviderObj, certsprecuperiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspRecuperiCollection collectionObj)
		{
			return CertspRecuperiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspRecuperi certsprecuperiObj)
		{
			return CertspRecuperiDAL.Delete(_dbProviderObj, certsprecuperiObj);
		}

		//getById
		public CertspRecuperi GetById(IntNT IdRecuperoValue)
		{
			CertspRecuperi CertspRecuperiTemp = CertspRecuperiDAL.GetById(_dbProviderObj, IdRecuperoValue);
			if (CertspRecuperiTemp!=null) CertspRecuperiTemp.Provider = this;
			return CertspRecuperiTemp;
		}

		//Select: popola la collection
		public CertspRecuperiCollection Select(IntNT IdrecuperoEqualThis, IntNT IdprogettoEqualThis, IntNT IdattoEqualThis, 
DecimalNT SostegnoEqualThis, DecimalNT SpeseammEqualThis, DatetimeNT DataricevrimbEqualThis, 
DecimalNT RimbsostegnoEqualThis, DecimalNT RimbspeseammEqualThis, DecimalNT NonrsostegnoEqualThis, 
DecimalNT NonrspeseammEqualThis)
		{
			CertspRecuperiCollection CertspRecuperiCollectionTemp = CertspRecuperiDAL.Select(_dbProviderObj, IdrecuperoEqualThis, IdprogettoEqualThis, IdattoEqualThis, 
SostegnoEqualThis, SpeseammEqualThis, DataricevrimbEqualThis, 
RimbsostegnoEqualThis, RimbspeseammEqualThis, NonrsostegnoEqualThis, 
NonrspeseammEqualThis);
			CertspRecuperiCollectionTemp.Provider = this;
			return CertspRecuperiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_RECUPERI>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_RECUPERI>
*/
