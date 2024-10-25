using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertificazioneConti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertificazioneContiProvider
	{
		int Save(CertificazioneConti CertificazioneContiObj);
		int SaveCollection(CertificazioneContiCollection collectionObj);
		int Delete(CertificazioneConti CertificazioneContiObj);
		int DeleteCollection(CertificazioneContiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertificazioneConti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertificazioneConti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCertificazioneConti;
		private NullTypes.DatetimeNT _AnnoContabileDa;
		private NullTypes.DatetimeNT _AnnoContabileA;
		private NullTypes.DatetimeNT _DataPresentazioneConti;
		private NullTypes.StringNT _IstanzaCertificazioneConti;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.BoolNT _FlagDefinitivo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CodPsr;
		[NonSerialized] private ICertificazioneContiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertificazioneContiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertificazioneConti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CERTIFICAZIONE_CONTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertificazioneConti
		{
			get { return _IdCertificazioneConti; }
			set {
				if (IdCertificazioneConti != value)
				{
					_IdCertificazioneConti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_CONTABILE_DA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT AnnoContabileDa
		{
			get { return _AnnoContabileDa; }
			set {
				if (AnnoContabileDa != value)
				{
					_AnnoContabileDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_CONTABILE_A
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT AnnoContabileA
		{
			get { return _AnnoContabileA; }
			set {
				if (AnnoContabileA != value)
				{
					_AnnoContabileA = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PRESENTAZIONE_CONTI
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPresentazioneConti
		{
			get { return _DataPresentazioneConti; }
			set {
				if (DataPresentazioneConti != value)
				{
					_DataPresentazioneConti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_CERTIFICAZIONE_CONTI
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaCertificazioneConti
		{
			get { return _IstanzaCertificazioneConti; }
			set {
				if (IstanzaCertificazioneConti != value)
				{
					_IstanzaCertificazioneConti = value;
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
		/// Corrisponde al campo:FLAG_DEFINITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagDefinitivo
		{
			get { return _FlagDefinitivo; }
			set {
				if (FlagDefinitivo != value)
				{
					_FlagDefinitivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
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
		/// Corrisponde al campo:COD_PSR
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodPsr
		{
			get { return _CodPsr; }
			set {
				if (CodPsr != value)
				{
					_CodPsr = value;
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
	/// Summary description for CertificazioneContiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertificazioneContiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertificazioneContiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertificazioneConti) info.GetValue(i.ToString(),typeof(CertificazioneConti)));
			}
		}

		//Costruttore
		public CertificazioneContiCollection()
		{
			this.ItemType = typeof(CertificazioneConti);
		}

		//Costruttore con provider
		public CertificazioneContiCollection(ICertificazioneContiProvider providerObj)
		{
			this.ItemType = typeof(CertificazioneConti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertificazioneConti this[int index]
		{
			get { return (CertificazioneConti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertificazioneContiCollection GetChanges()
		{
			return (CertificazioneContiCollection) base.GetChanges();
		}

		[NonSerialized] private ICertificazioneContiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertificazioneContiProvider Provider
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
		public int Add(CertificazioneConti CertificazioneContiObj)
		{
			if (CertificazioneContiObj.Provider == null) CertificazioneContiObj.Provider = this.Provider;
			return base.Add(CertificazioneContiObj);
		}

		//AddCollection
		public void AddCollection(CertificazioneContiCollection CertificazioneContiCollectionObj)
		{
			foreach (CertificazioneConti CertificazioneContiObj in CertificazioneContiCollectionObj)
				this.Add(CertificazioneContiObj);
		}

		//Insert
		public void Insert(int index, CertificazioneConti CertificazioneContiObj)
		{
			if (CertificazioneContiObj.Provider == null) CertificazioneContiObj.Provider = this.Provider;
			base.Insert(index, CertificazioneContiObj);
		}

		//CollectionGetById
		public CertificazioneConti CollectionGetById(NullTypes.IntNT IdCertificazioneContiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCertificazioneConti == IdCertificazioneContiValue))
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
		public CertificazioneContiCollection SubSelect(NullTypes.IntNT IdCertificazioneContiEqualThis, NullTypes.DatetimeNT AnnoContabileDaEqualThis, NullTypes.DatetimeNT AnnoContabileAEqualThis, 
NullTypes.DatetimeNT DataPresentazioneContiEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.BoolNT FlagDefinitivoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CodPsrEqualThis)
		{
			CertificazioneContiCollection CertificazioneContiCollectionTemp = new CertificazioneContiCollection();
			foreach (CertificazioneConti CertificazioneContiItem in this)
			{
				if (((IdCertificazioneContiEqualThis == null) || ((CertificazioneContiItem.IdCertificazioneConti != null) && (CertificazioneContiItem.IdCertificazioneConti.Value == IdCertificazioneContiEqualThis.Value))) && ((AnnoContabileDaEqualThis == null) || ((CertificazioneContiItem.AnnoContabileDa != null) && (CertificazioneContiItem.AnnoContabileDa.Value == AnnoContabileDaEqualThis.Value))) && ((AnnoContabileAEqualThis == null) || ((CertificazioneContiItem.AnnoContabileA != null) && (CertificazioneContiItem.AnnoContabileA.Value == AnnoContabileAEqualThis.Value))) && 
((DataPresentazioneContiEqualThis == null) || ((CertificazioneContiItem.DataPresentazioneConti != null) && (CertificazioneContiItem.DataPresentazioneConti.Value == DataPresentazioneContiEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((CertificazioneContiItem.CfOperatore != null) && (CertificazioneContiItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((FlagDefinitivoEqualThis == null) || ((CertificazioneContiItem.FlagDefinitivo != null) && (CertificazioneContiItem.FlagDefinitivo.Value == FlagDefinitivoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((CertificazioneContiItem.DataInserimento != null) && (CertificazioneContiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((CertificazioneContiItem.DataModifica != null) && (CertificazioneContiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CodPsrEqualThis == null) || ((CertificazioneContiItem.CodPsr != null) && (CertificazioneContiItem.CodPsr.Value == CodPsrEqualThis.Value))))
				{
					CertificazioneContiCollectionTemp.Add(CertificazioneContiItem);
				}
			}
			return CertificazioneContiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertificazioneContiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertificazioneContiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertificazioneConti CertificazioneContiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneConti", CertificazioneContiObj.IdCertificazioneConti);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoContabileDa", CertificazioneContiObj.AnnoContabileDa);
			DbProvider.SetCmdParam(cmd,firstChar + "AnnoContabileA", CertificazioneContiObj.AnnoContabileA);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPresentazioneConti", CertificazioneContiObj.DataPresentazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaCertificazioneConti", CertificazioneContiObj.IstanzaCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", CertificazioneContiObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagDefinitivo", CertificazioneContiObj.FlagDefinitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", CertificazioneContiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", CertificazioneContiObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CodPsr", CertificazioneContiObj.CodPsr);
		}
		//Insert
		private static int Insert(DbProvider db, CertificazioneConti CertificazioneContiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertificazioneContiInsert", new string[] {"AnnoContabileDa", "AnnoContabileA", 
"DataPresentazioneConti", "IstanzaCertificazioneConti", "CfOperatore", 
"FlagDefinitivo", "DataInserimento", "DataModifica", 
"CodPsr"}, new string[] {"DateTime", "DateTime", 
"DateTime", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				CompileIUCmd(false, insertCmd,CertificazioneContiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertificazioneContiObj.IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
				CertificazioneContiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				}
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertificazioneConti CertificazioneContiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertificazioneContiUpdate", new string[] {"IdCertificazioneConti", "AnnoContabileDa", "AnnoContabileA", 
"DataPresentazioneConti", "IstanzaCertificazioneConti", "CfOperatore", 
"FlagDefinitivo", "DataInserimento", "DataModifica", 
"CodPsr"}, new string[] {"int", "DateTime", "DateTime", 
"DateTime", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				CompileIUCmd(true, updateCmd,CertificazioneContiObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					CertificazioneContiObj.DataModifica = d;
				}
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertificazioneConti CertificazioneContiObj)
		{
			switch (CertificazioneContiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertificazioneContiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertificazioneContiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertificazioneContiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertificazioneContiCollection CertificazioneContiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertificazioneContiUpdate", new string[] {"IdCertificazioneConti", "AnnoContabileDa", "AnnoContabileA", 
"DataPresentazioneConti", "IstanzaCertificazioneConti", "CfOperatore", 
"FlagDefinitivo", "DataInserimento", "DataModifica", 
"CodPsr"}, new string[] {"int", "DateTime", "DateTime", 
"DateTime", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertificazioneContiInsert", new string[] {"AnnoContabileDa", "AnnoContabileA", 
"DataPresentazioneConti", "IstanzaCertificazioneConti", "CfOperatore", 
"FlagDefinitivo", "DataInserimento", "DataModifica", 
"CodPsr"}, new string[] {"DateTime", "DateTime", 
"DateTime", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiDelete", new string[] {"IdCertificazioneConti"}, new string[] {"int"},"");
				for (int i = 0; i < CertificazioneContiCollectionObj.Count; i++)
				{
					switch (CertificazioneContiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertificazioneContiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertificazioneContiCollectionObj[i].IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
									CertificazioneContiCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertificazioneContiCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									CertificazioneContiCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertificazioneContiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneConti", (SiarLibrary.NullTypes.IntNT)CertificazioneContiCollectionObj[i].IdCertificazioneConti);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertificazioneContiCollectionObj.Count; i++)
				{
					if ((CertificazioneContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertificazioneContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertificazioneContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertificazioneContiCollectionObj[i].IsDirty = false;
						CertificazioneContiCollectionObj[i].IsPersistent = true;
					}
					if ((CertificazioneContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertificazioneContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertificazioneContiCollectionObj[i].IsDirty = false;
						CertificazioneContiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertificazioneConti CertificazioneContiObj)
		{
			int returnValue = 0;
			if (CertificazioneContiObj.IsPersistent) 
			{
				returnValue = Delete(db, CertificazioneContiObj.IdCertificazioneConti);
			}
			CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertificazioneContiObj.IsDirty = false;
			CertificazioneContiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCertificazioneContiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiDelete", new string[] {"IdCertificazioneConti"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneConti", (SiarLibrary.NullTypes.IntNT)IdCertificazioneContiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertificazioneContiCollection CertificazioneContiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiDelete", new string[] {"IdCertificazioneConti"}, new string[] {"int"},"");
				for (int i = 0; i < CertificazioneContiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneConti", CertificazioneContiCollectionObj[i].IdCertificazioneConti);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertificazioneContiCollectionObj.Count; i++)
				{
					if ((CertificazioneContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertificazioneContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertificazioneContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertificazioneContiCollectionObj[i].IsDirty = false;
						CertificazioneContiCollectionObj[i].IsPersistent = false;
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
		public static CertificazioneConti GetById(DbProvider db, int IdCertificazioneContiValue)
		{
			CertificazioneConti CertificazioneContiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertificazioneContiGetById", new string[] {"IdCertificazioneConti"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCertificazioneConti", (SiarLibrary.NullTypes.IntNT)IdCertificazioneContiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertificazioneContiObj = GetFromDatareader(db);
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
			}
			db.Close();
			return CertificazioneContiObj;
		}

		//getFromDatareader
		public static CertificazioneConti GetFromDatareader(DbProvider db)
		{
			CertificazioneConti CertificazioneContiObj = new CertificazioneConti();
			CertificazioneContiObj.IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
			CertificazioneContiObj.AnnoContabileDa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["ANNO_CONTABILE_DA"]);
			CertificazioneContiObj.AnnoContabileA = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["ANNO_CONTABILE_A"]);
			CertificazioneContiObj.DataPresentazioneConti = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_CONTI"]);
			CertificazioneContiObj.IstanzaCertificazioneConti = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_CERTIFICAZIONE_CONTI"]);
			CertificazioneContiObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			CertificazioneContiObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
			CertificazioneContiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CertificazioneContiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CertificazioneContiObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertificazioneContiObj.IsDirty = false;
			CertificazioneContiObj.IsPersistent = true;
			return CertificazioneContiObj;
		}

		//Find Select

		public static CertificazioneContiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, SiarLibrary.NullTypes.DatetimeNT AnnoContabileDaEqualThis, SiarLibrary.NullTypes.DatetimeNT AnnoContabileAEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataPresentazioneContiEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis)

		{

			CertificazioneContiCollection CertificazioneContiCollectionObj = new CertificazioneContiCollection();

			IDbCommand findCmd = db.InitCmd("Zcertificazionecontifindselect", new string[] {"IdCertificazioneContiequalthis", "AnnoContabileDaequalthis", "AnnoContabileAequalthis", 
"DataPresentazioneContiequalthis", "CfOperatoreequalthis", "FlagDefinitivoequalthis", 
"DataInserimentoequalthis", "DataModificaequalthis", "CodPsrequalthis"}, new string[] {"int", "DateTime", "DateTime", 
"DateTime", "string", "bool", 
"DateTime", "DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoContabileDaequalthis", AnnoContabileDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoContabileAequalthis", AnnoContabileAEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPresentazioneContiequalthis", DataPresentazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagDefinitivoequalthis", FlagDefinitivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			CertificazioneConti CertificazioneContiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertificazioneContiObj = GetFromDatareader(db);
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
				CertificazioneContiCollectionObj.Add(CertificazioneContiObj);
			}
			db.Close();
			return CertificazioneContiCollectionObj;
		}

		//Find FindCertificazioneConti

		public static CertificazioneContiCollection FindCertificazioneConti(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, SiarLibrary.NullTypes.DatetimeNT AnnoContabileDaEqualThis, SiarLibrary.NullTypes.DatetimeNT AnnoContabileAEqualThis, 
SiarLibrary.NullTypes.BoolNT FlagDefinitivoEqualThis)

		{

			CertificazioneContiCollection CertificazioneContiCollectionObj = new CertificazioneContiCollection();

			IDbCommand findCmd = db.InitCmd("Zcertificazionecontifindfindcertificazioneconti", new string[] {"IdCertificazioneContiequalthis", "AnnoContabileDaequalthis", "AnnoContabileAequalthis", 
"FlagDefinitivoequalthis"}, new string[] {"int", "DateTime", "DateTime", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoContabileDaequalthis", AnnoContabileDaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoContabileAequalthis", AnnoContabileAEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagDefinitivoequalthis", FlagDefinitivoEqualThis);
			CertificazioneConti CertificazioneContiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertificazioneContiObj = GetFromDatareader(db);
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
				CertificazioneContiCollectionObj.Add(CertificazioneContiObj);
			}
			db.Close();
			return CertificazioneContiCollectionObj;
		}

		//Find GetCertificazioneContiById

		public static CertificazioneContiCollection GetCertificazioneContiById(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis)

		{

			CertificazioneContiCollection CertificazioneContiCollectionObj = new CertificazioneContiCollection();

			IDbCommand findCmd = db.InitCmd("Zcertificazionecontifindgetcertificazionecontibyid", new string[] {"IdCertificazioneContiequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			CertificazioneConti CertificazioneContiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertificazioneContiObj = GetFromDatareader(db);
				CertificazioneContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiObj.IsDirty = false;
				CertificazioneContiObj.IsPersistent = true;
				CertificazioneContiCollectionObj.Add(CertificazioneContiObj);
			}
			db.Close();
			return CertificazioneContiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertificazioneContiCollectionProvider:ICertificazioneContiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertificazioneContiCollectionProvider : ICertificazioneContiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertificazioneConti
		protected CertificazioneContiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertificazioneContiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertificazioneContiCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertificazioneContiCollectionProvider(IntNT IdcertificazionecontiEqualThis, DatetimeNT AnnocontabiledaEqualThis, DatetimeNT AnnocontabileaEqualThis, 
BoolNT FlagdefinitivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindCertificazioneConti(IdcertificazionecontiEqualThis, AnnocontabiledaEqualThis, AnnocontabileaEqualThis, 
FlagdefinitivoEqualThis);
		}

		//Costruttore3: ha in input certificazionecontiCollectionObj - non popola la collection
		public CertificazioneContiCollectionProvider(CertificazioneContiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertificazioneContiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertificazioneContiCollection(this);
		}

		//Get e Set
		public CertificazioneContiCollection CollectionObj
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
		public int SaveCollection(CertificazioneContiCollection collectionObj)
		{
			return CertificazioneContiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertificazioneConti certificazionecontiObj)
		{
			return CertificazioneContiDAL.Save(_dbProviderObj, certificazionecontiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertificazioneContiCollection collectionObj)
		{
			return CertificazioneContiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertificazioneConti certificazionecontiObj)
		{
			return CertificazioneContiDAL.Delete(_dbProviderObj, certificazionecontiObj);
		}

		//getById
		public CertificazioneConti GetById(IntNT IdCertificazioneContiValue)
		{
			CertificazioneConti CertificazioneContiTemp = CertificazioneContiDAL.GetById(_dbProviderObj, IdCertificazioneContiValue);
			if (CertificazioneContiTemp!=null) CertificazioneContiTemp.Provider = this;
			return CertificazioneContiTemp;
		}

		//Select: popola la collection
		public CertificazioneContiCollection Select(IntNT IdcertificazionecontiEqualThis, DatetimeNT AnnocontabiledaEqualThis, DatetimeNT AnnocontabileaEqualThis, 
DatetimeNT DatapresentazionecontiEqualThis, StringNT CfoperatoreEqualThis, BoolNT FlagdefinitivoEqualThis, 
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CodpsrEqualThis)
		{
			CertificazioneContiCollection CertificazioneContiCollectionTemp = CertificazioneContiDAL.Select(_dbProviderObj, IdcertificazionecontiEqualThis, AnnocontabiledaEqualThis, AnnocontabileaEqualThis, 
DatapresentazionecontiEqualThis, CfoperatoreEqualThis, FlagdefinitivoEqualThis, 
DatainserimentoEqualThis, DatamodificaEqualThis, CodpsrEqualThis);
			CertificazioneContiCollectionTemp.Provider = this;
			return CertificazioneContiCollectionTemp;
		}

		//FindCertificazioneConti: popola la collection
		public CertificazioneContiCollection FindCertificazioneConti(IntNT IdcertificazionecontiEqualThis, DatetimeNT AnnocontabiledaEqualThis, DatetimeNT AnnocontabileaEqualThis, 
BoolNT FlagdefinitivoEqualThis)
		{
			CertificazioneContiCollection CertificazioneContiCollectionTemp = CertificazioneContiDAL.FindCertificazioneConti(_dbProviderObj, IdcertificazionecontiEqualThis, AnnocontabiledaEqualThis, AnnocontabileaEqualThis, 
FlagdefinitivoEqualThis);
			CertificazioneContiCollectionTemp.Provider = this;
			return CertificazioneContiCollectionTemp;
		}

		//GetCertificazioneContiById: popola la collection
		public CertificazioneContiCollection GetCertificazioneContiById(IntNT IdcertificazionecontiEqualThis)
		{
			CertificazioneContiCollection CertificazioneContiCollectionTemp = CertificazioneContiDAL.GetCertificazioneContiById(_dbProviderObj, IdcertificazionecontiEqualThis);
			CertificazioneContiCollectionTemp.Provider = this;
			return CertificazioneContiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTIFICAZIONE_CONTI>
  <ViewName>vCERTIFICAZIONE_CONTI</ViewName>
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
    <FindCertificazioneConti OrderBy="ORDER BY ">
      <ID_CERTIFICAZIONE_CONTI>Equal</ID_CERTIFICAZIONE_CONTI>
      <ANNO_CONTABILE_DA>Equal</ANNO_CONTABILE_DA>
      <ANNO_CONTABILE_A>Equal</ANNO_CONTABILE_A>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </FindCertificazioneConti>
    <GetCertificazioneContiById OrderBy="ORDER BY ">
      <ID_CERTIFICAZIONE_CONTI>Equal</ID_CERTIFICAZIONE_CONTI>
    </GetCertificazioneContiById>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTIFICAZIONE_CONTI>
*/
