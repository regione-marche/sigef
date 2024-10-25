using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaEnti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaEntiProvider
	{
		int Save(RnaEnti RnaEntiObj);
		int SaveCollection(RnaEntiCollection collectionObj);
		int Delete(RnaEnti RnaEntiObj);
		int DeleteCollection(RnaEntiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaEnti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaEnti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaEnte;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Username;
		private NullTypes.StringNT _PasswordCrypted;
		private NullTypes.BoolNT _Abilitato;
		private NullTypes.BoolNT _CredenzialiProduzione;
		private NullTypes.StringNT _CodEnteAccount;
		private NullTypes.StringNT _DescrizioneAccount;
		private NullTypes.DatetimeNT _DataPassword;
		[NonSerialized] private IRnaEntiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaEntiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaEnti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_ENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaEnte
		{
			get { return _IdRnaEnte; }
			set {
				if (IdRnaEnte != value)
				{
					_IdRnaEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:USERNAME
		/// Tipo sul db:NVARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Username
		{
			get { return _Username; }
			set {
				if (Username != value)
				{
					_Username = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PASSWORD_CRYPTED
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT PasswordCrypted
		{
			get { return _PasswordCrypted; }
			set {
				if (PasswordCrypted != value)
				{
					_PasswordCrypted = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ABILITATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Abilitato
		{
			get { return _Abilitato; }
			set {
				if (Abilitato != value)
				{
					_Abilitato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CREDENZIALI_PRODUZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT CredenzialiProduzione
		{
			get { return _CredenzialiProduzione; }
			set {
				if (CredenzialiProduzione != value)
				{
					_CredenzialiProduzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE_ACCOUNT
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteAccount
		{
			get { return _CodEnteAccount; }
			set {
				if (CodEnteAccount != value)
				{
					_CodEnteAccount = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ACCOUNT
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneAccount
		{
			get { return _DescrizioneAccount; }
			set {
				if (DescrizioneAccount != value)
				{
					_DescrizioneAccount = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PASSWORD
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPassword
		{
			get { return _DataPassword; }
			set {
				if (DataPassword != value)
				{
					_DataPassword = value;
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
	/// Summary description for RnaEntiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaEntiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaEntiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaEnti) info.GetValue(i.ToString(),typeof(RnaEnti)));
			}
		}

		//Costruttore
		public RnaEntiCollection()
		{
			this.ItemType = typeof(RnaEnti);
		}

		//Costruttore con provider
		public RnaEntiCollection(IRnaEntiProvider providerObj)
		{
			this.ItemType = typeof(RnaEnti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaEnti this[int index]
		{
			get { return (RnaEnti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaEntiCollection GetChanges()
		{
			return (RnaEntiCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaEntiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaEntiProvider Provider
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
		public int Add(RnaEnti RnaEntiObj)
		{
			if (RnaEntiObj.Provider == null) RnaEntiObj.Provider = this.Provider;
			return base.Add(RnaEntiObj);
		}

		//AddCollection
		public void AddCollection(RnaEntiCollection RnaEntiCollectionObj)
		{
			foreach (RnaEnti RnaEntiObj in RnaEntiCollectionObj)
				this.Add(RnaEntiObj);
		}

		//Insert
		public void Insert(int index, RnaEnti RnaEntiObj)
		{
			if (RnaEntiObj.Provider == null) RnaEntiObj.Provider = this.Provider;
			base.Insert(index, RnaEntiObj);
		}

		//CollectionGetById
		public RnaEnti CollectionGetById(NullTypes.IntNT IdRnaEnteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRnaEnte == IdRnaEnteValue))
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
		public RnaEntiCollection SubSelect(NullTypes.IntNT IdRnaEnteEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT UsernameEqualThis, 
NullTypes.StringNT PasswordCryptedEqualThis, NullTypes.BoolNT AbilitatoEqualThis, NullTypes.BoolNT CredenzialiProduzioneEqualThis, 
NullTypes.StringNT CodEnteAccountEqualThis, NullTypes.StringNT DescrizioneAccountEqualThis, NullTypes.DatetimeNT DataPasswordEqualThis)
		{
			RnaEntiCollection RnaEntiCollectionTemp = new RnaEntiCollection();
			foreach (RnaEnti RnaEntiItem in this)
			{
				if (((IdRnaEnteEqualThis == null) || ((RnaEntiItem.IdRnaEnte != null) && (RnaEntiItem.IdRnaEnte.Value == IdRnaEnteEqualThis.Value))) && ((CodEnteEqualThis == null) || ((RnaEntiItem.CodEnte != null) && (RnaEntiItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((UsernameEqualThis == null) || ((RnaEntiItem.Username != null) && (RnaEntiItem.Username.Value == UsernameEqualThis.Value))) && 
((PasswordCryptedEqualThis == null) || ((RnaEntiItem.PasswordCrypted != null) && (RnaEntiItem.PasswordCrypted.Value == PasswordCryptedEqualThis.Value))) && ((AbilitatoEqualThis == null) || ((RnaEntiItem.Abilitato != null) && (RnaEntiItem.Abilitato.Value == AbilitatoEqualThis.Value))) && ((CredenzialiProduzioneEqualThis == null) || ((RnaEntiItem.CredenzialiProduzione != null) && (RnaEntiItem.CredenzialiProduzione.Value == CredenzialiProduzioneEqualThis.Value))) && 
((CodEnteAccountEqualThis == null) || ((RnaEntiItem.CodEnteAccount != null) && (RnaEntiItem.CodEnteAccount.Value == CodEnteAccountEqualThis.Value))) && ((DescrizioneAccountEqualThis == null) || ((RnaEntiItem.DescrizioneAccount != null) && (RnaEntiItem.DescrizioneAccount.Value == DescrizioneAccountEqualThis.Value))) && ((DataPasswordEqualThis == null) || ((RnaEntiItem.DataPassword != null) && (RnaEntiItem.DataPassword.Value == DataPasswordEqualThis.Value))))
				{
					RnaEntiCollectionTemp.Add(RnaEntiItem);
				}
			}
			return RnaEntiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaEntiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaEntiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaEnti RnaEntiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRnaEnte", RnaEntiObj.IdRnaEnte);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", RnaEntiObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Username", RnaEntiObj.Username);
			DbProvider.SetCmdParam(cmd,firstChar + "PasswordCrypted", RnaEntiObj.PasswordCrypted);
			DbProvider.SetCmdParam(cmd,firstChar + "Abilitato", RnaEntiObj.Abilitato);
			DbProvider.SetCmdParam(cmd,firstChar + "CredenzialiProduzione", RnaEntiObj.CredenzialiProduzione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnteAccount", RnaEntiObj.CodEnteAccount);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneAccount", RnaEntiObj.DescrizioneAccount);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPassword", RnaEntiObj.DataPassword);
		}
		//Insert
		private static int Insert(DbProvider db, RnaEnti RnaEntiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaEntiInsert", new string[] {"CodEnte", "Username", 
"PasswordCrypted", "Abilitato", "CredenzialiProduzione", 
"CodEnteAccount", "DescrizioneAccount", "DataPassword"}, new string[] {"string", "string", 
"string", "bool", "bool", 
"string", "string", "DateTime"},"");
				CompileIUCmd(false, insertCmd,RnaEntiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaEntiObj.IdRnaEnte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_ENTE"]);
				RnaEntiObj.Abilitato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITATO"]);
				RnaEntiObj.CredenzialiProduzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CREDENZIALI_PRODUZIONE"]);
				}
				RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaEntiObj.IsDirty = false;
				RnaEntiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaEnti RnaEntiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaEntiUpdate", new string[] {"IdRnaEnte", "CodEnte", "Username", 
"PasswordCrypted", "Abilitato", "CredenzialiProduzione", 
"CodEnteAccount", "DescrizioneAccount", "DataPassword"}, new string[] {"int", "string", "string", 
"string", "bool", "bool", 
"string", "string", "DateTime"},"");
				CompileIUCmd(true, updateCmd,RnaEntiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaEntiObj.IsDirty = false;
				RnaEntiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaEnti RnaEntiObj)
		{
			switch (RnaEntiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaEntiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaEntiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaEntiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaEntiCollection RnaEntiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaEntiUpdate", new string[] {"IdRnaEnte", "CodEnte", "Username", 
"PasswordCrypted", "Abilitato", "CredenzialiProduzione", 
"CodEnteAccount", "DescrizioneAccount", "DataPassword"}, new string[] {"int", "string", "string", 
"string", "bool", "bool", 
"string", "string", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaEntiInsert", new string[] {"CodEnte", "Username", 
"PasswordCrypted", "Abilitato", "CredenzialiProduzione", 
"CodEnteAccount", "DescrizioneAccount", "DataPassword"}, new string[] {"string", "string", 
"string", "bool", "bool", 
"string", "string", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaEntiDelete", new string[] {"IdRnaEnte"}, new string[] {"int"},"");
				for (int i = 0; i < RnaEntiCollectionObj.Count; i++)
				{
					switch (RnaEntiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaEntiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaEntiCollectionObj[i].IdRnaEnte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_ENTE"]);
									RnaEntiCollectionObj[i].Abilitato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITATO"]);
									RnaEntiCollectionObj[i].CredenzialiProduzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CREDENZIALI_PRODUZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaEntiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaEntiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaEnte", (SiarLibrary.NullTypes.IntNT)RnaEntiCollectionObj[i].IdRnaEnte);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaEntiCollectionObj.Count; i++)
				{
					if ((RnaEntiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaEntiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaEntiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaEntiCollectionObj[i].IsDirty = false;
						RnaEntiCollectionObj[i].IsPersistent = true;
					}
					if ((RnaEntiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaEntiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaEntiCollectionObj[i].IsDirty = false;
						RnaEntiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaEnti RnaEntiObj)
		{
			int returnValue = 0;
			if (RnaEntiObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaEntiObj.IdRnaEnte);
			}
			RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaEntiObj.IsDirty = false;
			RnaEntiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRnaEnteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaEntiDelete", new string[] {"IdRnaEnte"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaEnte", (SiarLibrary.NullTypes.IntNT)IdRnaEnteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaEntiCollection RnaEntiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaEntiDelete", new string[] {"IdRnaEnte"}, new string[] {"int"},"");
				for (int i = 0; i < RnaEntiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaEnte", RnaEntiCollectionObj[i].IdRnaEnte);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaEntiCollectionObj.Count; i++)
				{
					if ((RnaEntiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaEntiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaEntiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaEntiCollectionObj[i].IsDirty = false;
						RnaEntiCollectionObj[i].IsPersistent = false;
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
		public static RnaEnti GetById(DbProvider db, int IdRnaEnteValue)
		{
			RnaEnti RnaEntiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaEntiGetById", new string[] {"IdRnaEnte"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRnaEnte", (SiarLibrary.NullTypes.IntNT)IdRnaEnteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaEntiObj = GetFromDatareader(db);
				RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaEntiObj.IsDirty = false;
				RnaEntiObj.IsPersistent = true;
			}
			db.Close();
			return RnaEntiObj;
		}

		//getFromDatareader
		public static RnaEnti GetFromDatareader(DbProvider db)
		{
			RnaEnti RnaEntiObj = new RnaEnti();
			RnaEntiObj.IdRnaEnte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_ENTE"]);
			RnaEntiObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			RnaEntiObj.Username = new SiarLibrary.NullTypes.StringNT(db.DataReader["USERNAME"]);
			RnaEntiObj.PasswordCrypted = new SiarLibrary.NullTypes.StringNT(db.DataReader["PASSWORD_CRYPTED"]);
			RnaEntiObj.Abilitato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITATO"]);
			RnaEntiObj.CredenzialiProduzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CREDENZIALI_PRODUZIONE"]);
			RnaEntiObj.CodEnteAccount = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_ACCOUNT"]);
			RnaEntiObj.DescrizioneAccount = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ACCOUNT"]);
			RnaEntiObj.DataPassword = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PASSWORD"]);
			RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaEntiObj.IsDirty = false;
			RnaEntiObj.IsPersistent = true;
			return RnaEntiObj;
		}

		//Find Select

		public static RnaEntiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaEnteEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT UsernameEqualThis, 
SiarLibrary.NullTypes.StringNT PasswordCryptedEqualThis, SiarLibrary.NullTypes.BoolNT AbilitatoEqualThis, SiarLibrary.NullTypes.BoolNT CredenzialiProduzioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteAccountEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneAccountEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPasswordEqualThis)

		{

			RnaEntiCollection RnaEntiCollectionObj = new RnaEntiCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaentifindselect", new string[] {"IdRnaEnteequalthis", "CodEnteequalthis", "Usernameequalthis", 
"PasswordCryptedequalthis", "Abilitatoequalthis", "CredenzialiProduzioneequalthis", 
"CodEnteAccountequalthis", "DescrizioneAccountequalthis", "DataPasswordequalthis"}, new string[] {"int", "string", "string", 
"string", "bool", "bool", 
"string", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaEnteequalthis", IdRnaEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Usernameequalthis", UsernameEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PasswordCryptedequalthis", PasswordCryptedEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abilitatoequalthis", AbilitatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CredenzialiProduzioneequalthis", CredenzialiProduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteAccountequalthis", CodEnteAccountEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneAccountequalthis", DescrizioneAccountEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPasswordequalthis", DataPasswordEqualThis);
			RnaEnti RnaEntiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaEntiObj = GetFromDatareader(db);
				RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaEntiObj.IsDirty = false;
				RnaEntiObj.IsPersistent = true;
				RnaEntiCollectionObj.Add(RnaEntiObj);
			}
			db.Close();
			return RnaEntiCollectionObj;
		}

		//Find FindCodEnte

		public static RnaEntiCollection FindCodEnte(DbProvider db, SiarLibrary.NullTypes.StringNT CodEnteEqualThis)

		{

			RnaEntiCollection RnaEntiCollectionObj = new RnaEntiCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaentifindfindcodente", new string[] {"CodEnteequalthis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			RnaEnti RnaEntiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaEntiObj = GetFromDatareader(db);
				RnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaEntiObj.IsDirty = false;
				RnaEntiObj.IsPersistent = true;
				RnaEntiCollectionObj.Add(RnaEntiObj);
			}
			db.Close();
			return RnaEntiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaEntiCollectionProvider:IRnaEntiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaEntiCollectionProvider : IRnaEntiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaEnti
		protected RnaEntiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaEntiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaEntiCollection(this);
		}

		//Costruttore 2: popola la collection
		public RnaEntiCollectionProvider(StringNT CodenteEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindCodEnte(CodenteEqualThis);
		}

		//Costruttore3: ha in input rnaentiCollectionObj - non popola la collection
		public RnaEntiCollectionProvider(RnaEntiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaEntiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaEntiCollection(this);
		}

		//Get e Set
		public RnaEntiCollection CollectionObj
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
		public int SaveCollection(RnaEntiCollection collectionObj)
		{
			return RnaEntiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaEnti rnaentiObj)
		{
			return RnaEntiDAL.Save(_dbProviderObj, rnaentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaEntiCollection collectionObj)
		{
			return RnaEntiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaEnti rnaentiObj)
		{
			return RnaEntiDAL.Delete(_dbProviderObj, rnaentiObj);
		}

		//getById
		public RnaEnti GetById(IntNT IdRnaEnteValue)
		{
			RnaEnti RnaEntiTemp = RnaEntiDAL.GetById(_dbProviderObj, IdRnaEnteValue);
			if (RnaEntiTemp!=null) RnaEntiTemp.Provider = this;
			return RnaEntiTemp;
		}

		//Select: popola la collection
		public RnaEntiCollection Select(IntNT IdrnaenteEqualThis, StringNT CodenteEqualThis, StringNT UsernameEqualThis, 
StringNT PasswordcryptedEqualThis, BoolNT AbilitatoEqualThis, BoolNT CredenzialiproduzioneEqualThis, 
StringNT CodenteaccountEqualThis, StringNT DescrizioneaccountEqualThis, DatetimeNT DatapasswordEqualThis)
		{
			RnaEntiCollection RnaEntiCollectionTemp = RnaEntiDAL.Select(_dbProviderObj, IdrnaenteEqualThis, CodenteEqualThis, UsernameEqualThis, 
PasswordcryptedEqualThis, AbilitatoEqualThis, CredenzialiproduzioneEqualThis, 
CodenteaccountEqualThis, DescrizioneaccountEqualThis, DatapasswordEqualThis);
			RnaEntiCollectionTemp.Provider = this;
			return RnaEntiCollectionTemp;
		}

		//FindCodEnte: popola la collection
		public RnaEntiCollection FindCodEnte(StringNT CodenteEqualThis)
		{
			RnaEntiCollection RnaEntiCollectionTemp = RnaEntiDAL.FindCodEnte(_dbProviderObj, CodenteEqualThis);
			RnaEntiCollectionTemp.Provider = this;
			return RnaEntiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_ENTI>
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
    <FindCodEnte OrderBy="ORDER BY ">
      <COD_ENTE>Equal</COD_ENTE>
    </FindCodEnte>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_ENTI>
*/
