using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertificazioneContiCalcolata
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertificazioneContiCalcolataProvider
	{
		int Save(CertificazioneContiCalcolata CertificazioneContiCalcolataObj);
		int SaveCollection(CertificazioneContiCalcolataCollection collectionObj);
		int Delete(CertificazioneContiCalcolata CertificazioneContiCalcolataObj);
		int DeleteCollection(CertificazioneContiCalcolataCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertificazioneContiCalcolata
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertificazioneContiCalcolata: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCertificazioneContiCalcolata;
		private NullTypes.IntNT _IdCertificazioneConti;
		private NullTypes.StringNT _CfOperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfOperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _IstanzaCertificazioneConti;
		private NullTypes.StringNT _HashCodeIstanzaCertificazioneConti;
		private NullTypes.StringNT _IstanzaCertificazioneContiCalcolata;
		private NullTypes.StringNT _HashCodeIstanzaCertificazioneContiCalcolata;
		private NullTypes.BoolNT _Differenti;
		private NullTypes.DatetimeNT _AnnoContabileA;
		private NullTypes.DatetimeNT _AnnoContabileDa;
		private NullTypes.DatetimeNT _DataPresentazioneConti;
		private NullTypes.BoolNT _FlagDefinitivo;
		private NullTypes.StringNT _CodPsr;
		[NonSerialized] private ICertificazioneContiCalcolataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertificazioneContiCalcolataProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertificazioneContiCalcolata()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CERTIFICAZIONE_CONTI_CALCOLATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertificazioneContiCalcolata
		{
			get { return _IdCertificazioneContiCalcolata; }
			set {
				if (IdCertificazioneContiCalcolata != value)
				{
					_IdCertificazioneContiCalcolata = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:CF_OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatoreInserimento
		{
			get { return _CfOperatoreInserimento; }
			set {
				if (CfOperatoreInserimento != value)
				{
					_CfOperatoreInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:CF_OPERATORE_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatoreModifica
		{
			get { return _CfOperatoreModifica; }
			set {
				if (CfOperatoreModifica != value)
				{
					_CfOperatoreModifica = value;
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
		/// Corrisponde al campo:HASH_CODE_ISTANZA_CERTIFICAZIONE_CONTI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT HashCodeIstanzaCertificazioneConti
		{
			get { return _HashCodeIstanzaCertificazioneConti; }
			set {
				if (HashCodeIstanzaCertificazioneConti != value)
				{
					_HashCodeIstanzaCertificazioneConti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_CERTIFICAZIONE_CONTI_CALCOLATA
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaCertificazioneContiCalcolata
		{
			get { return _IstanzaCertificazioneContiCalcolata; }
			set {
				if (IstanzaCertificazioneContiCalcolata != value)
				{
					_IstanzaCertificazioneContiCalcolata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:HASH_CODE_ISTANZA_CERTIFICAZIONE_CONTI_CALCOLATA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT HashCodeIstanzaCertificazioneContiCalcolata
		{
			get { return _HashCodeIstanzaCertificazioneContiCalcolata; }
			set {
				if (HashCodeIstanzaCertificazioneContiCalcolata != value)
				{
					_HashCodeIstanzaCertificazioneContiCalcolata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIFFERENTI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Differenti
		{
			get { return _Differenti; }
			set {
				if (Differenti != value)
				{
					_Differenti = value;
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
	/// Summary description for CertificazioneContiCalcolataCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertificazioneContiCalcolataCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertificazioneContiCalcolataCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertificazioneContiCalcolata) info.GetValue(i.ToString(),typeof(CertificazioneContiCalcolata)));
			}
		}

		//Costruttore
		public CertificazioneContiCalcolataCollection()
		{
			this.ItemType = typeof(CertificazioneContiCalcolata);
		}

		//Costruttore con provider
		public CertificazioneContiCalcolataCollection(ICertificazioneContiCalcolataProvider providerObj)
		{
			this.ItemType = typeof(CertificazioneContiCalcolata);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertificazioneContiCalcolata this[int index]
		{
			get { return (CertificazioneContiCalcolata)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertificazioneContiCalcolataCollection GetChanges()
		{
			return (CertificazioneContiCalcolataCollection) base.GetChanges();
		}

		[NonSerialized] private ICertificazioneContiCalcolataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertificazioneContiCalcolataProvider Provider
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
		public int Add(CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			if (CertificazioneContiCalcolataObj.Provider == null) CertificazioneContiCalcolataObj.Provider = this.Provider;
			return base.Add(CertificazioneContiCalcolataObj);
		}

		//AddCollection
		public void AddCollection(CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionObj)
		{
			foreach (CertificazioneContiCalcolata CertificazioneContiCalcolataObj in CertificazioneContiCalcolataCollectionObj)
				this.Add(CertificazioneContiCalcolataObj);
		}

		//Insert
		public void Insert(int index, CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			if (CertificazioneContiCalcolataObj.Provider == null) CertificazioneContiCalcolataObj.Provider = this.Provider;
			base.Insert(index, CertificazioneContiCalcolataObj);
		}

		//CollectionGetById
		public CertificazioneContiCalcolata CollectionGetById(NullTypes.IntNT IdCertificazioneContiCalcolataValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCertificazioneContiCalcolata == IdCertificazioneContiCalcolataValue))
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
		public CertificazioneContiCalcolataCollection SubSelect(NullTypes.IntNT IdCertificazioneContiCalcolataEqualThis, NullTypes.IntNT IdCertificazioneContiEqualThis, NullTypes.StringNT CfOperatoreInserimentoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfOperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.StringNT HashCodeIstanzaCertificazioneContiEqualThis, NullTypes.StringNT HashCodeIstanzaCertificazioneContiCalcolataEqualThis, NullTypes.BoolNT DifferentiEqualThis)
		{
			CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionTemp = new CertificazioneContiCalcolataCollection();
			foreach (CertificazioneContiCalcolata CertificazioneContiCalcolataItem in this)
			{
				if (((IdCertificazioneContiCalcolataEqualThis == null) || ((CertificazioneContiCalcolataItem.IdCertificazioneContiCalcolata != null) && (CertificazioneContiCalcolataItem.IdCertificazioneContiCalcolata.Value == IdCertificazioneContiCalcolataEqualThis.Value))) && ((IdCertificazioneContiEqualThis == null) || ((CertificazioneContiCalcolataItem.IdCertificazioneConti != null) && (CertificazioneContiCalcolataItem.IdCertificazioneConti.Value == IdCertificazioneContiEqualThis.Value))) && ((CfOperatoreInserimentoEqualThis == null) || ((CertificazioneContiCalcolataItem.CfOperatoreInserimento != null) && (CertificazioneContiCalcolataItem.CfOperatoreInserimento.Value == CfOperatoreInserimentoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((CertificazioneContiCalcolataItem.DataInserimento != null) && (CertificazioneContiCalcolataItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfOperatoreModificaEqualThis == null) || ((CertificazioneContiCalcolataItem.CfOperatoreModifica != null) && (CertificazioneContiCalcolataItem.CfOperatoreModifica.Value == CfOperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((CertificazioneContiCalcolataItem.DataModifica != null) && (CertificazioneContiCalcolataItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((HashCodeIstanzaCertificazioneContiEqualThis == null) || ((CertificazioneContiCalcolataItem.HashCodeIstanzaCertificazioneConti != null) && (CertificazioneContiCalcolataItem.HashCodeIstanzaCertificazioneConti.Value == HashCodeIstanzaCertificazioneContiEqualThis.Value))) && ((HashCodeIstanzaCertificazioneContiCalcolataEqualThis == null) || ((CertificazioneContiCalcolataItem.HashCodeIstanzaCertificazioneContiCalcolata != null) && (CertificazioneContiCalcolataItem.HashCodeIstanzaCertificazioneContiCalcolata.Value == HashCodeIstanzaCertificazioneContiCalcolataEqualThis.Value))) && ((DifferentiEqualThis == null) || ((CertificazioneContiCalcolataItem.Differenti != null) && (CertificazioneContiCalcolataItem.Differenti.Value == DifferentiEqualThis.Value))))
				{
					CertificazioneContiCalcolataCollectionTemp.Add(CertificazioneContiCalcolataItem);
				}
			}
			return CertificazioneContiCalcolataCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertificazioneContiCalcolataDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertificazioneContiCalcolataDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertificazioneContiCalcolata CertificazioneContiCalcolataObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneContiCalcolata", CertificazioneContiCalcolataObj.IdCertificazioneContiCalcolata);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertificazioneConti", CertificazioneContiCalcolataObj.IdCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatoreInserimento", CertificazioneContiCalcolataObj.CfOperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", CertificazioneContiCalcolataObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatoreModifica", CertificazioneContiCalcolataObj.CfOperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", CertificazioneContiCalcolataObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaCertificazioneConti", CertificazioneContiCalcolataObj.IstanzaCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "HashCodeIstanzaCertificazioneConti", CertificazioneContiCalcolataObj.HashCodeIstanzaCertificazioneConti);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaCertificazioneContiCalcolata", CertificazioneContiCalcolataObj.IstanzaCertificazioneContiCalcolata);
			DbProvider.SetCmdParam(cmd,firstChar + "HashCodeIstanzaCertificazioneContiCalcolata", CertificazioneContiCalcolataObj.HashCodeIstanzaCertificazioneContiCalcolata);
			DbProvider.SetCmdParam(cmd,firstChar + "Differenti", CertificazioneContiCalcolataObj.Differenti);
		}
		//Insert
		private static int Insert(DbProvider db, CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertificazioneContiCalcolataInsert", new string[] {"IdCertificazioneConti", "CfOperatoreInserimento", 
"DataInserimento", "CfOperatoreModifica", "DataModifica", 
"IstanzaCertificazioneConti", "HashCodeIstanzaCertificazioneConti", "IstanzaCertificazioneContiCalcolata", 
"HashCodeIstanzaCertificazioneContiCalcolata", "Differenti", 
}, new string[] {"int", "string", 
"DateTime", "string", "DateTime", 
"string", "string", "string", 
"string", "bool", 
},"");
				CompileIUCmd(false, insertCmd,CertificazioneContiCalcolataObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertificazioneContiCalcolataObj.IdCertificazioneContiCalcolata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI_CALCOLATA"]);
				}
				CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiCalcolataObj.IsDirty = false;
				CertificazioneContiCalcolataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertificazioneContiCalcolataUpdate", new string[] {"IdCertificazioneContiCalcolata", "IdCertificazioneConti", "CfOperatoreInserimento", 
"DataInserimento", "CfOperatoreModifica", "DataModifica", 
"IstanzaCertificazioneConti", "HashCodeIstanzaCertificazioneConti", "IstanzaCertificazioneContiCalcolata", 
"HashCodeIstanzaCertificazioneContiCalcolata", "Differenti", 
}, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"string", "string", "string", 
"string", "bool", 
},"");
				CompileIUCmd(true, updateCmd,CertificazioneContiCalcolataObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					CertificazioneContiCalcolataObj.DataModifica = d;
				}
				CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiCalcolataObj.IsDirty = false;
				CertificazioneContiCalcolataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			switch (CertificazioneContiCalcolataObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertificazioneContiCalcolataObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertificazioneContiCalcolataObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertificazioneContiCalcolataObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertificazioneContiCalcolataUpdate", new string[] {"IdCertificazioneContiCalcolata", "IdCertificazioneConti", "CfOperatoreInserimento", 
"DataInserimento", "CfOperatoreModifica", "DataModifica", 
"IstanzaCertificazioneConti", "HashCodeIstanzaCertificazioneConti", "IstanzaCertificazioneContiCalcolata", 
"HashCodeIstanzaCertificazioneContiCalcolata", "Differenti", 
}, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"string", "string", "string", 
"string", "bool", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertificazioneContiCalcolataInsert", new string[] {"IdCertificazioneConti", "CfOperatoreInserimento", 
"DataInserimento", "CfOperatoreModifica", "DataModifica", 
"IstanzaCertificazioneConti", "HashCodeIstanzaCertificazioneConti", "IstanzaCertificazioneContiCalcolata", 
"HashCodeIstanzaCertificazioneContiCalcolata", "Differenti", 
}, new string[] {"int", "string", 
"DateTime", "string", "DateTime", 
"string", "string", "string", 
"string", "bool", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiCalcolataDelete", new string[] {"IdCertificazioneContiCalcolata"}, new string[] {"int"},"");
				for (int i = 0; i < CertificazioneContiCalcolataCollectionObj.Count; i++)
				{
					switch (CertificazioneContiCalcolataCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertificazioneContiCalcolataCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertificazioneContiCalcolataCollectionObj[i].IdCertificazioneContiCalcolata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI_CALCOLATA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertificazioneContiCalcolataCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									CertificazioneContiCalcolataCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertificazioneContiCalcolataCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolata", (SiarLibrary.NullTypes.IntNT)CertificazioneContiCalcolataCollectionObj[i].IdCertificazioneContiCalcolata);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertificazioneContiCalcolataCollectionObj.Count; i++)
				{
					if ((CertificazioneContiCalcolataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertificazioneContiCalcolataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertificazioneContiCalcolataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertificazioneContiCalcolataCollectionObj[i].IsDirty = false;
						CertificazioneContiCalcolataCollectionObj[i].IsPersistent = true;
					}
					if ((CertificazioneContiCalcolataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertificazioneContiCalcolataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertificazioneContiCalcolataCollectionObj[i].IsDirty = false;
						CertificazioneContiCalcolataCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertificazioneContiCalcolata CertificazioneContiCalcolataObj)
		{
			int returnValue = 0;
			if (CertificazioneContiCalcolataObj.IsPersistent) 
			{
				returnValue = Delete(db, CertificazioneContiCalcolataObj.IdCertificazioneContiCalcolata);
			}
			CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertificazioneContiCalcolataObj.IsDirty = false;
			CertificazioneContiCalcolataObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCertificazioneContiCalcolataValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiCalcolataDelete", new string[] {"IdCertificazioneContiCalcolata"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolata", (SiarLibrary.NullTypes.IntNT)IdCertificazioneContiCalcolataValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertificazioneContiCalcolataDelete", new string[] {"IdCertificazioneContiCalcolata"}, new string[] {"int"},"");
				for (int i = 0; i < CertificazioneContiCalcolataCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolata", CertificazioneContiCalcolataCollectionObj[i].IdCertificazioneContiCalcolata);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertificazioneContiCalcolataCollectionObj.Count; i++)
				{
					if ((CertificazioneContiCalcolataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertificazioneContiCalcolataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertificazioneContiCalcolataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertificazioneContiCalcolataCollectionObj[i].IsDirty = false;
						CertificazioneContiCalcolataCollectionObj[i].IsPersistent = false;
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
		public static CertificazioneContiCalcolata GetById(DbProvider db, int IdCertificazioneContiCalcolataValue)
		{
			CertificazioneContiCalcolata CertificazioneContiCalcolataObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertificazioneContiCalcolataGetById", new string[] {"IdCertificazioneContiCalcolata"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolata", (SiarLibrary.NullTypes.IntNT)IdCertificazioneContiCalcolataValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertificazioneContiCalcolataObj = GetFromDatareader(db);
				CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiCalcolataObj.IsDirty = false;
				CertificazioneContiCalcolataObj.IsPersistent = true;
			}
			db.Close();
			return CertificazioneContiCalcolataObj;
		}

		//getFromDatareader
		public static CertificazioneContiCalcolata GetFromDatareader(DbProvider db)
		{
			CertificazioneContiCalcolata CertificazioneContiCalcolataObj = new CertificazioneContiCalcolata();
			CertificazioneContiCalcolataObj.IdCertificazioneContiCalcolata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI_CALCOLATA"]);
			CertificazioneContiCalcolataObj.IdCertificazioneConti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTIFICAZIONE_CONTI"]);
			CertificazioneContiCalcolataObj.CfOperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_INSERIMENTO"]);
			CertificazioneContiCalcolataObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CertificazioneContiCalcolataObj.CfOperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_MODIFICA"]);
			CertificazioneContiCalcolataObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CertificazioneContiCalcolataObj.IstanzaCertificazioneConti = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_CERTIFICAZIONE_CONTI"]);
			CertificazioneContiCalcolataObj.HashCodeIstanzaCertificazioneConti = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE_ISTANZA_CERTIFICAZIONE_CONTI"]);
			CertificazioneContiCalcolataObj.IstanzaCertificazioneContiCalcolata = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_CERTIFICAZIONE_CONTI_CALCOLATA"]);
			CertificazioneContiCalcolataObj.HashCodeIstanzaCertificazioneContiCalcolata = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE_ISTANZA_CERTIFICAZIONE_CONTI_CALCOLATA"]);
			CertificazioneContiCalcolataObj.Differenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DIFFERENTI"]);
			CertificazioneContiCalcolataObj.AnnoContabileA = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["ANNO_CONTABILE_A"]);
			CertificazioneContiCalcolataObj.AnnoContabileDa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["ANNO_CONTABILE_DA"]);
			CertificazioneContiCalcolataObj.DataPresentazioneConti = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_CONTI"]);
			CertificazioneContiCalcolataObj.FlagDefinitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_DEFINITIVO"]);
			CertificazioneContiCalcolataObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertificazioneContiCalcolataObj.IsDirty = false;
			CertificazioneContiCalcolataObj.IsPersistent = true;
			return CertificazioneContiCalcolataObj;
		}

		//Find Select

		public static CertificazioneContiCalcolataCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertificazioneContiCalcolataEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.StringNT HashCodeIstanzaCertificazioneContiEqualThis, SiarLibrary.NullTypes.StringNT HashCodeIstanzaCertificazioneContiCalcolataEqualThis, SiarLibrary.NullTypes.BoolNT DifferentiEqualThis)

		{

			CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionObj = new CertificazioneContiCalcolataCollection();

			IDbCommand findCmd = db.InitCmd("Zcertificazioneconticalcolatafindselect", new string[] {"IdCertificazioneContiCalcolataequalthis", "IdCertificazioneContiequalthis", "CfOperatoreInserimentoequalthis", 
"DataInserimentoequalthis", "CfOperatoreModificaequalthis", "DataModificaequalthis", 
"HashCodeIstanzaCertificazioneContiequalthis", "HashCodeIstanzaCertificazioneContiCalcolataequalthis", "Differentiequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolataequalthis", IdCertificazioneContiCalcolataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreInserimentoequalthis", CfOperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreModificaequalthis", CfOperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "HashCodeIstanzaCertificazioneContiequalthis", HashCodeIstanzaCertificazioneContiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "HashCodeIstanzaCertificazioneContiCalcolataequalthis", HashCodeIstanzaCertificazioneContiCalcolataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Differentiequalthis", DifferentiEqualThis);
			CertificazioneContiCalcolata CertificazioneContiCalcolataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertificazioneContiCalcolataObj = GetFromDatareader(db);
				CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiCalcolataObj.IsDirty = false;
				CertificazioneContiCalcolataObj.IsPersistent = true;
				CertificazioneContiCalcolataCollectionObj.Add(CertificazioneContiCalcolataObj);
			}
			db.Close();
			return CertificazioneContiCalcolataCollectionObj;
		}

		//Find FindByIdCertificazioneConti

		public static CertificazioneContiCalcolataCollection FindByIdCertificazioneConti(DbProvider db, SiarLibrary.NullTypes.IntNT IdCertificazioneContiCalcolataEqualThis, SiarLibrary.NullTypes.IntNT IdCertificazioneContiEqualThis)

		{

			CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionObj = new CertificazioneContiCalcolataCollection();

			IDbCommand findCmd = db.InitCmd("Zcertificazioneconticalcolatafindfindbyidcertificazioneconti", new string[] {"IdCertificazioneContiCalcolataequalthis", "IdCertificazioneContiequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiCalcolataequalthis", IdCertificazioneContiCalcolataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertificazioneContiequalthis", IdCertificazioneContiEqualThis);
			CertificazioneContiCalcolata CertificazioneContiCalcolataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertificazioneContiCalcolataObj = GetFromDatareader(db);
				CertificazioneContiCalcolataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertificazioneContiCalcolataObj.IsDirty = false;
				CertificazioneContiCalcolataObj.IsPersistent = true;
				CertificazioneContiCalcolataCollectionObj.Add(CertificazioneContiCalcolataObj);
			}
			db.Close();
			return CertificazioneContiCalcolataCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertificazioneContiCalcolataCollectionProvider:ICertificazioneContiCalcolataProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertificazioneContiCalcolataCollectionProvider : ICertificazioneContiCalcolataProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertificazioneContiCalcolata
		protected CertificazioneContiCalcolataCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertificazioneContiCalcolataCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertificazioneContiCalcolataCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertificazioneContiCalcolataCollectionProvider(IntNT IdcertificazioneconticalcolataEqualThis, IntNT IdcertificazionecontiEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindByIdCertificazioneConti(IdcertificazioneconticalcolataEqualThis, IdcertificazionecontiEqualThis);
		}

		//Costruttore3: ha in input certificazioneconticalcolataCollectionObj - non popola la collection
		public CertificazioneContiCalcolataCollectionProvider(CertificazioneContiCalcolataCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertificazioneContiCalcolataCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertificazioneContiCalcolataCollection(this);
		}

		//Get e Set
		public CertificazioneContiCalcolataCollection CollectionObj
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
		public int SaveCollection(CertificazioneContiCalcolataCollection collectionObj)
		{
			return CertificazioneContiCalcolataDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertificazioneContiCalcolata certificazioneconticalcolataObj)
		{
			return CertificazioneContiCalcolataDAL.Save(_dbProviderObj, certificazioneconticalcolataObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertificazioneContiCalcolataCollection collectionObj)
		{
			return CertificazioneContiCalcolataDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertificazioneContiCalcolata certificazioneconticalcolataObj)
		{
			return CertificazioneContiCalcolataDAL.Delete(_dbProviderObj, certificazioneconticalcolataObj);
		}

		//getById
		public CertificazioneContiCalcolata GetById(IntNT IdCertificazioneContiCalcolataValue)
		{
			CertificazioneContiCalcolata CertificazioneContiCalcolataTemp = CertificazioneContiCalcolataDAL.GetById(_dbProviderObj, IdCertificazioneContiCalcolataValue);
			if (CertificazioneContiCalcolataTemp!=null) CertificazioneContiCalcolataTemp.Provider = this;
			return CertificazioneContiCalcolataTemp;
		}

		//Select: popola la collection
		public CertificazioneContiCalcolataCollection Select(IntNT IdcertificazioneconticalcolataEqualThis, IntNT IdcertificazionecontiEqualThis, StringNT CfoperatoreinserimentoEqualThis, 
DatetimeNT DatainserimentoEqualThis, StringNT CfoperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, 
StringNT HashcodeistanzacertificazionecontiEqualThis, StringNT HashcodeistanzacertificazioneconticalcolataEqualThis, BoolNT DifferentiEqualThis)
		{
			CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionTemp = CertificazioneContiCalcolataDAL.Select(_dbProviderObj, IdcertificazioneconticalcolataEqualThis, IdcertificazionecontiEqualThis, CfoperatoreinserimentoEqualThis, 
DatainserimentoEqualThis, CfoperatoremodificaEqualThis, DatamodificaEqualThis, 
HashcodeistanzacertificazionecontiEqualThis, HashcodeistanzacertificazioneconticalcolataEqualThis, DifferentiEqualThis);
			CertificazioneContiCalcolataCollectionTemp.Provider = this;
			return CertificazioneContiCalcolataCollectionTemp;
		}

		//FindByIdCertificazioneConti: popola la collection
		public CertificazioneContiCalcolataCollection FindByIdCertificazioneConti(IntNT IdcertificazioneconticalcolataEqualThis, IntNT IdcertificazionecontiEqualThis)
		{
			CertificazioneContiCalcolataCollection CertificazioneContiCalcolataCollectionTemp = CertificazioneContiCalcolataDAL.FindByIdCertificazioneConti(_dbProviderObj, IdcertificazioneconticalcolataEqualThis, IdcertificazionecontiEqualThis);
			CertificazioneContiCalcolataCollectionTemp.Provider = this;
			return CertificazioneContiCalcolataCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTIFICAZIONE_CONTI_CALCOLATA>
  <ViewName>VCERTIFICAZIONE_CONTI_CALCOLATA</ViewName>
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
    <FindByIdCertificazioneConti OrderBy="ORDER BY ">
      <ID_CERTIFICAZIONE_CONTI_CALCOLATA>Equal</ID_CERTIFICAZIONE_CONTI_CALCOLATA>
      <ID_CERTIFICAZIONE_CONTI>Equal</ID_CERTIFICAZIONE_CONTI>
    </FindByIdCertificazioneConti>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTIFICAZIONE_CONTI_CALCOLATA>
*/
