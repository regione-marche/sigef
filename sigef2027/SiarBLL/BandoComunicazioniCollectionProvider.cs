using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoComunicazioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoComunicazioniProvider
	{
		int Save(BandoComunicazioni BandoComunicazioniObj);
		int SaveCollection(BandoComunicazioniCollection collectionObj);
		int Delete(BandoComunicazioni BandoComunicazioniObj);
		int DeleteCollection(BandoComunicazioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoComunicazioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoComunicazioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Testo;
		private NullTypes.StringNT _ModalitaAnticipo;
		private NullTypes.StringNT _ObblighiBeneficiario;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.DatetimeNT _Data;
		[NonSerialized] private IBandoComunicazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoComunicazioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoComunicazioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MODALITA_ANTICIPO
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT ModalitaAnticipo
		{
			get { return _ModalitaAnticipo; }
			set {
				if (ModalitaAnticipo != value)
				{
					_ModalitaAnticipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGHI_BENEFICIARIO
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT ObblighiBeneficiario
		{
			get { return _ObblighiBeneficiario; }
			set {
				if (ObblighiBeneficiario != value)
				{
					_ObblighiBeneficiario = value;
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
	/// Summary description for BandoComunicazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoComunicazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoComunicazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoComunicazioni) info.GetValue(i.ToString(),typeof(BandoComunicazioni)));
			}
		}

		//Costruttore
		public BandoComunicazioniCollection()
		{
			this.ItemType = typeof(BandoComunicazioni);
		}

		//Costruttore con provider
		public BandoComunicazioniCollection(IBandoComunicazioniProvider providerObj)
		{
			this.ItemType = typeof(BandoComunicazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoComunicazioni this[int index]
		{
			get { return (BandoComunicazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoComunicazioniCollection GetChanges()
		{
			return (BandoComunicazioniCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoComunicazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoComunicazioniProvider Provider
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
		public int Add(BandoComunicazioni BandoComunicazioniObj)
		{
			if (BandoComunicazioniObj.Provider == null) BandoComunicazioniObj.Provider = this.Provider;
			return base.Add(BandoComunicazioniObj);
		}

		//AddCollection
		public void AddCollection(BandoComunicazioniCollection BandoComunicazioniCollectionObj)
		{
			foreach (BandoComunicazioni BandoComunicazioniObj in BandoComunicazioniCollectionObj)
				this.Add(BandoComunicazioniObj);
		}

		//Insert
		public void Insert(int index, BandoComunicazioni BandoComunicazioniObj)
		{
			if (BandoComunicazioniObj.Provider == null) BandoComunicazioniObj.Provider = this.Provider;
			base.Insert(index, BandoComunicazioniObj);
		}

		//CollectionGetById
		public BandoComunicazioni CollectionGetById(NullTypes.StringNT CodTipoValue, NullTypes.IntNT IdBandoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodTipo == CodTipoValue) && (this[i].IdBando == IdBandoValue))
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
		public BandoComunicazioniCollection SubSelect(NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdAttoEqualThis, 
NullTypes.DatetimeNT DataEqualThis)
		{
			BandoComunicazioniCollection BandoComunicazioniCollectionTemp = new BandoComunicazioniCollection();
			foreach (BandoComunicazioni BandoComunicazioniItem in this)
			{
				if (((CodTipoEqualThis == null) || ((BandoComunicazioniItem.CodTipo != null) && (BandoComunicazioniItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoComunicazioniItem.IdBando != null) && (BandoComunicazioniItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdAttoEqualThis == null) || ((BandoComunicazioniItem.IdAtto != null) && (BandoComunicazioniItem.IdAtto.Value == IdAttoEqualThis.Value))) && 
((DataEqualThis == null) || ((BandoComunicazioniItem.Data != null) && (BandoComunicazioniItem.Data.Value == DataEqualThis.Value))))
				{
					BandoComunicazioniCollectionTemp.Add(BandoComunicazioniItem);
				}
			}
			return BandoComunicazioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoComunicazioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoComunicazioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoComunicazioni BandoComunicazioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", BandoComunicazioniObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoComunicazioniObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", BandoComunicazioniObj.Testo);
			DbProvider.SetCmdParam(cmd,firstChar + "ModalitaAnticipo", BandoComunicazioniObj.ModalitaAnticipo);
			DbProvider.SetCmdParam(cmd,firstChar + "ObblighiBeneficiario", BandoComunicazioniObj.ObblighiBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", BandoComunicazioniObj.IdAtto);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", BandoComunicazioniObj.Data);
		}
		//Insert
		private static int Insert(DbProvider db, BandoComunicazioni BandoComunicazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoComunicazioniInsert", new string[] {"CodTipo", "IdBando", "Testo", 
"ModalitaAnticipo", "ObblighiBeneficiario", "IdAtto", 
"Data"}, new string[] {"string", "int", "string", 
"string", "string", "int", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,BandoComunicazioniObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComunicazioniObj.IsDirty = false;
				BandoComunicazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoComunicazioni BandoComunicazioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoComunicazioniUpdate", new string[] {"CodTipo", "IdBando", "Testo", 
"ModalitaAnticipo", "ObblighiBeneficiario", "IdAtto", 
"Data"}, new string[] {"string", "int", "string", 
"string", "string", "int", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,BandoComunicazioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComunicazioniObj.IsDirty = false;
				BandoComunicazioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoComunicazioni BandoComunicazioniObj)
		{
			switch (BandoComunicazioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoComunicazioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoComunicazioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoComunicazioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoComunicazioniCollection BandoComunicazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoComunicazioniUpdate", new string[] {"CodTipo", "IdBando", "Testo", 
"ModalitaAnticipo", "ObblighiBeneficiario", "IdAtto", 
"Data"}, new string[] {"string", "int", "string", 
"string", "string", "int", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoComunicazioniInsert", new string[] {"CodTipo", "IdBando", "Testo", 
"ModalitaAnticipo", "ObblighiBeneficiario", "IdAtto", 
"Data"}, new string[] {"string", "int", "string", 
"string", "string", "int", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComunicazioniDelete", new string[] {"CodTipo", "IdBando"}, new string[] {"string", "int"},"");
				for (int i = 0; i < BandoComunicazioniCollectionObj.Count; i++)
				{
					switch (BandoComunicazioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoComunicazioniCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoComunicazioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoComunicazioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)BandoComunicazioniCollectionObj[i].CodTipo);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoComunicazioniCollectionObj[i].IdBando);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoComunicazioniCollectionObj.Count; i++)
				{
					if ((BandoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoComunicazioniCollectionObj[i].IsDirty = false;
						BandoComunicazioniCollectionObj[i].IsPersistent = true;
					}
					if ((BandoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoComunicazioniCollectionObj[i].IsDirty = false;
						BandoComunicazioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoComunicazioni BandoComunicazioniObj)
		{
			int returnValue = 0;
			if (BandoComunicazioniObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoComunicazioniObj.CodTipo, BandoComunicazioniObj.IdBando);
			}
			BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoComunicazioniObj.IsDirty = false;
			BandoComunicazioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodTipoValue, int IdBandoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComunicazioniDelete", new string[] {"CodTipo", "IdBando"}, new string[] {"string", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoComunicazioniCollection BandoComunicazioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoComunicazioniDelete", new string[] {"CodTipo", "IdBando"}, new string[] {"string", "int"},"");
				for (int i = 0; i < BandoComunicazioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodTipo", BandoComunicazioniCollectionObj[i].CodTipo);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdBando", BandoComunicazioniCollectionObj[i].IdBando);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoComunicazioniCollectionObj.Count; i++)
				{
					if ((BandoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoComunicazioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoComunicazioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoComunicazioniCollectionObj[i].IsDirty = false;
						BandoComunicazioniCollectionObj[i].IsPersistent = false;
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
		public static BandoComunicazioni GetById(DbProvider db, string CodTipoValue, int IdBandoValue)
		{
			BandoComunicazioni BandoComunicazioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoComunicazioniGetById", new string[] {"CodTipo", "IdBando"}, new string[] {"string", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodTipo", (SiarLibrary.NullTypes.StringNT)CodTipoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoComunicazioniObj = GetFromDatareader(db);
				BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComunicazioniObj.IsDirty = false;
				BandoComunicazioniObj.IsPersistent = true;
			}
			db.Close();
			return BandoComunicazioniObj;
		}

		//getFromDatareader
		public static BandoComunicazioni GetFromDatareader(DbProvider db)
		{
			BandoComunicazioni BandoComunicazioniObj = new BandoComunicazioni();
			BandoComunicazioniObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoComunicazioniObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoComunicazioniObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			BandoComunicazioniObj.ModalitaAnticipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["MODALITA_ANTICIPO"]);
			BandoComunicazioniObj.ObblighiBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["OBBLIGHI_BENEFICIARIO"]);
			BandoComunicazioniObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			BandoComunicazioniObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoComunicazioniObj.IsDirty = false;
			BandoComunicazioniObj.IsPersistent = true;
			return BandoComunicazioniObj;
		}

		//Find Select

		public static BandoComunicazioniCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis)

		{

			BandoComunicazioniCollection BandoComunicazioniCollectionObj = new BandoComunicazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandocomunicazionifindselect", new string[] {"CodTipoequalthis", "IdBandoequalthis", "IdAttoequalthis", 
"Dataequalthis"}, new string[] {"string", "int", "int", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			BandoComunicazioni BandoComunicazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoComunicazioniObj = GetFromDatareader(db);
				BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComunicazioniObj.IsDirty = false;
				BandoComunicazioniObj.IsPersistent = true;
				BandoComunicazioniCollectionObj.Add(BandoComunicazioniObj);
			}
			db.Close();
			return BandoComunicazioniCollectionObj;
		}

		//Find Find

		public static BandoComunicazioniCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			BandoComunicazioniCollection BandoComunicazioniCollectionObj = new BandoComunicazioniCollection();

			IDbCommand findCmd = db.InitCmd("Zbandocomunicazionifindfind", new string[] {"CodTipoequalthis", "IdBandoequalthis"}, new string[] {"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			BandoComunicazioni BandoComunicazioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoComunicazioniObj = GetFromDatareader(db);
				BandoComunicazioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoComunicazioniObj.IsDirty = false;
				BandoComunicazioniObj.IsPersistent = true;
				BandoComunicazioniCollectionObj.Add(BandoComunicazioniObj);
			}
			db.Close();
			return BandoComunicazioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoComunicazioniCollectionProvider:IBandoComunicazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoComunicazioniCollectionProvider : IBandoComunicazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoComunicazioni
		protected BandoComunicazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoComunicazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoComunicazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoComunicazioniCollectionProvider(StringNT CodtipoEqualThis, IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtipoEqualThis, IdbandoEqualThis);
		}

		//Costruttore3: ha in input bandocomunicazioniCollectionObj - non popola la collection
		public BandoComunicazioniCollectionProvider(BandoComunicazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoComunicazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoComunicazioniCollection(this);
		}

		//Get e Set
		public BandoComunicazioniCollection CollectionObj
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
		public int SaveCollection(BandoComunicazioniCollection collectionObj)
		{
			return BandoComunicazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoComunicazioni bandocomunicazioniObj)
		{
			return BandoComunicazioniDAL.Save(_dbProviderObj, bandocomunicazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoComunicazioniCollection collectionObj)
		{
			return BandoComunicazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoComunicazioni bandocomunicazioniObj)
		{
			return BandoComunicazioniDAL.Delete(_dbProviderObj, bandocomunicazioniObj);
		}

		//getById
		public BandoComunicazioni GetById(StringNT CodTipoValue, IntNT IdBandoValue)
		{
			BandoComunicazioni BandoComunicazioniTemp = BandoComunicazioniDAL.GetById(_dbProviderObj, CodTipoValue, IdBandoValue);
			if (BandoComunicazioniTemp!=null) BandoComunicazioniTemp.Provider = this;
			return BandoComunicazioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoComunicazioniCollection Select(StringNT CodtipoEqualThis, IntNT IdbandoEqualThis, IntNT IdattoEqualThis, 
DatetimeNT DataEqualThis)
		{
			BandoComunicazioniCollection BandoComunicazioniCollectionTemp = BandoComunicazioniDAL.Select(_dbProviderObj, CodtipoEqualThis, IdbandoEqualThis, IdattoEqualThis, 
DataEqualThis);
			BandoComunicazioniCollectionTemp.Provider = this;
			return BandoComunicazioniCollectionTemp;
		}

		//Find: popola la collection
		public BandoComunicazioniCollection Find(StringNT CodtipoEqualThis, IntNT IdbandoEqualThis)
		{
			BandoComunicazioniCollection BandoComunicazioniCollectionTemp = BandoComunicazioniDAL.Find(_dbProviderObj, CodtipoEqualThis, IdbandoEqualThis);
			BandoComunicazioniCollectionTemp.Provider = this;
			return BandoComunicazioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_COMUNICAZIONI>
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
    <Find OrderBy="ORDER BY ">
      <COD_TIPO>Equal</COD_TIPO>
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_COMUNICAZIONI>
*/
