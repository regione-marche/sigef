using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoResponsabili
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoResponsabiliProvider
	{
		int Save(BandoResponsabili BandoResponsabiliObj);
		int SaveCollection(BandoResponsabiliCollection collectionObj);
		int Delete(BandoResponsabili BandoResponsabiliObj);
		int DeleteCollection(BandoResponsabiliCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoResponsabili
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoResponsabili: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.StringNT _Provincia;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _DenominazioneProvincia;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _Profilo;
		[NonSerialized] private IBandoResponsabiliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoResponsabiliProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoResponsabili()
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
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
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
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
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

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE_PROVINCIA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT DenominazioneProvincia
		{
			get { return _DenominazioneProvincia; }
			set {
				if (DenominazioneProvincia != value)
				{
					_DenominazioneProvincia = value;
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
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
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
	/// Summary description for BandoResponsabiliCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoResponsabiliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoResponsabiliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoResponsabili) info.GetValue(i.ToString(),typeof(BandoResponsabili)));
			}
		}

		//Costruttore
		public BandoResponsabiliCollection()
		{
			this.ItemType = typeof(BandoResponsabili);
		}

		//Costruttore con provider
		public BandoResponsabiliCollection(IBandoResponsabiliProvider providerObj)
		{
			this.ItemType = typeof(BandoResponsabili);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoResponsabili this[int index]
		{
			get { return (BandoResponsabili)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoResponsabiliCollection GetChanges()
		{
			return (BandoResponsabiliCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoResponsabiliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoResponsabiliProvider Provider
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
		public int Add(BandoResponsabili BandoResponsabiliObj)
		{
			if (BandoResponsabiliObj.Provider == null) BandoResponsabiliObj.Provider = this.Provider;
			return base.Add(BandoResponsabiliObj);
		}

		//AddCollection
		public void AddCollection(BandoResponsabiliCollection BandoResponsabiliCollectionObj)
		{
			foreach (BandoResponsabili BandoResponsabiliObj in BandoResponsabiliCollectionObj)
				this.Add(BandoResponsabiliObj);
		}

		//Insert
		public void Insert(int index, BandoResponsabili BandoResponsabiliObj)
		{
			if (BandoResponsabiliObj.Provider == null) BandoResponsabiliObj.Provider = this.Provider;
			base.Insert(index, BandoResponsabiliObj);
		}

		//CollectionGetById
		public BandoResponsabili CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoResponsabiliCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdUtenteEqualThis, 
NullTypes.StringNT ProvinciaEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT OperatoreEqualThis)
		{
			BandoResponsabiliCollection BandoResponsabiliCollectionTemp = new BandoResponsabiliCollection();
			foreach (BandoResponsabili BandoResponsabiliItem in this)
			{
				if (((IdEqualThis == null) || ((BandoResponsabiliItem.Id != null) && (BandoResponsabiliItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoResponsabiliItem.IdBando != null) && (BandoResponsabiliItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((BandoResponsabiliItem.IdUtente != null) && (BandoResponsabiliItem.IdUtente.Value == IdUtenteEqualThis.Value))) && 
((ProvinciaEqualThis == null) || ((BandoResponsabiliItem.Provincia != null) && (BandoResponsabiliItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((AttivoEqualThis == null) || ((BandoResponsabiliItem.Attivo != null) && (BandoResponsabiliItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataEqualThis == null) || ((BandoResponsabiliItem.Data != null) && (BandoResponsabiliItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((BandoResponsabiliItem.Operatore != null) && (BandoResponsabiliItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					BandoResponsabiliCollectionTemp.Add(BandoResponsabiliItem);
				}
			}
			return BandoResponsabiliCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoResponsabiliCollection FiltroProvincia(NullTypes.StringNT ProvinciaEqualThis, NullTypes.BoolNT ProvinciaIsNull)
		{
			BandoResponsabiliCollection BandoResponsabiliCollectionTemp = new BandoResponsabiliCollection();
			foreach (BandoResponsabili BandoResponsabiliItem in this)
			{
				if (((ProvinciaEqualThis == null) || ((BandoResponsabiliItem.Provincia != null) && (BandoResponsabiliItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((ProvinciaIsNull == null) || ((BandoResponsabiliItem.Provincia == null) ==  ProvinciaIsNull.Value)))
				{
					BandoResponsabiliCollectionTemp.Add(BandoResponsabiliItem);
				}
			}
			return BandoResponsabiliCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoResponsabiliDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoResponsabiliDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoResponsabili BandoResponsabiliObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoResponsabiliObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoResponsabiliObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", BandoResponsabiliObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", BandoResponsabiliObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BandoResponsabiliObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", BandoResponsabiliObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", BandoResponsabiliObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, BandoResponsabili BandoResponsabiliObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoResponsabiliInsert", new string[] {"IdBando", "IdUtente", 
"Provincia", "Attivo", "Data", 
"Operatore", }, new string[] {"int", "int", 
"string", "bool", "DateTime", 
"int", },"");
				CompileIUCmd(false, insertCmd,BandoResponsabiliObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoResponsabiliObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoResponsabiliObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoResponsabiliObj.IsDirty = false;
				BandoResponsabiliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoResponsabili BandoResponsabiliObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoResponsabiliUpdate", new string[] {"Id", "IdBando", "IdUtente", 
"Provincia", "Attivo", "Data", 
"Operatore", }, new string[] {"int", "int", "int", 
"string", "bool", "DateTime", 
"int", },"");
				CompileIUCmd(true, updateCmd,BandoResponsabiliObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoResponsabiliObj.IsDirty = false;
				BandoResponsabiliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoResponsabili BandoResponsabiliObj)
		{
			switch (BandoResponsabiliObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoResponsabiliObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoResponsabiliObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoResponsabiliObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoResponsabiliCollection BandoResponsabiliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoResponsabiliUpdate", new string[] {"Id", "IdBando", "IdUtente", 
"Provincia", "Attivo", "Data", 
"Operatore", }, new string[] {"int", "int", "int", 
"string", "bool", "DateTime", 
"int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoResponsabiliInsert", new string[] {"IdBando", "IdUtente", 
"Provincia", "Attivo", "Data", 
"Operatore", }, new string[] {"int", "int", 
"string", "bool", "DateTime", 
"int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoResponsabiliDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoResponsabiliCollectionObj.Count; i++)
				{
					switch (BandoResponsabiliCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoResponsabiliCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoResponsabiliCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoResponsabiliCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoResponsabiliCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoResponsabiliCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoResponsabiliCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoResponsabiliCollectionObj.Count; i++)
				{
					if ((BandoResponsabiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoResponsabiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoResponsabiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoResponsabiliCollectionObj[i].IsDirty = false;
						BandoResponsabiliCollectionObj[i].IsPersistent = true;
					}
					if ((BandoResponsabiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoResponsabiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoResponsabiliCollectionObj[i].IsDirty = false;
						BandoResponsabiliCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoResponsabili BandoResponsabiliObj)
		{
			int returnValue = 0;
			if (BandoResponsabiliObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoResponsabiliObj.Id);
			}
			BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoResponsabiliObj.IsDirty = false;
			BandoResponsabiliObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoResponsabiliDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoResponsabiliCollection BandoResponsabiliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoResponsabiliDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoResponsabiliCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoResponsabiliCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoResponsabiliCollectionObj.Count; i++)
				{
					if ((BandoResponsabiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoResponsabiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoResponsabiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoResponsabiliCollectionObj[i].IsDirty = false;
						BandoResponsabiliCollectionObj[i].IsPersistent = false;
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
		public static BandoResponsabili GetById(DbProvider db, int IdValue)
		{
			BandoResponsabili BandoResponsabiliObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoResponsabiliGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoResponsabiliObj = GetFromDatareader(db);
				BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoResponsabiliObj.IsDirty = false;
				BandoResponsabiliObj.IsPersistent = true;
			}
			db.Close();
			return BandoResponsabiliObj;
		}

		//getFromDatareader
		public static BandoResponsabili GetFromDatareader(DbProvider db)
		{
			BandoResponsabili BandoResponsabiliObj = new BandoResponsabili();
			BandoResponsabiliObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoResponsabiliObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoResponsabiliObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			BandoResponsabiliObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			BandoResponsabiliObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoResponsabiliObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			BandoResponsabiliObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			BandoResponsabiliObj.DenominazioneProvincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE_PROVINCIA"]);
			BandoResponsabiliObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			BandoResponsabiliObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			BandoResponsabiliObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			BandoResponsabiliObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoResponsabiliObj.IsDirty = false;
			BandoResponsabiliObj.IsPersistent = true;
			return BandoResponsabiliObj;
		}

		//Find Select

		public static BandoResponsabiliCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			BandoResponsabiliCollection BandoResponsabiliCollectionObj = new BandoResponsabiliCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoresponsabilifindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdUtenteequalthis", 
"Provinciaequalthis", "Attivoequalthis", "Dataequalthis", 
"Operatoreequalthis"}, new string[] {"int", "int", "int", 
"string", "bool", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			BandoResponsabili BandoResponsabiliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoResponsabiliObj = GetFromDatareader(db);
				BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoResponsabiliObj.IsDirty = false;
				BandoResponsabiliObj.IsPersistent = true;
				BandoResponsabiliCollectionObj.Add(BandoResponsabiliObj);
			}
			db.Close();
			return BandoResponsabiliCollectionObj;
		}

		//Find Find

		public static BandoResponsabiliCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.BoolNT ProvinciaIsNull, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BandoResponsabiliCollection BandoResponsabiliCollectionObj = new BandoResponsabiliCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoresponsabilifindfind", new string[] {"IdBandoequalthis", "IdUtenteequalthis", "Provinciaequalthis", 
"Provinciaisnull", "Attivoequalthis"}, new string[] {"int", "int", "string", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaisnull", ProvinciaIsNull);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BandoResponsabili BandoResponsabiliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoResponsabiliObj = GetFromDatareader(db);
				BandoResponsabiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoResponsabiliObj.IsDirty = false;
				BandoResponsabiliObj.IsPersistent = true;
				BandoResponsabiliCollectionObj.Add(BandoResponsabiliObj);
			}
			db.Close();
			return BandoResponsabiliCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoResponsabiliCollectionProvider:IBandoResponsabiliProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoResponsabiliCollectionProvider : IBandoResponsabiliProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoResponsabili
		protected BandoResponsabiliCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoResponsabiliCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoResponsabiliCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoResponsabiliCollectionProvider(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, StringNT ProvinciaEqualThis, 
BoolNT ProvinciaIsNull, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdutenteEqualThis, ProvinciaEqualThis, 
ProvinciaIsNull, AttivoEqualThis);
		}

		//Costruttore3: ha in input bandoresponsabiliCollectionObj - non popola la collection
		public BandoResponsabiliCollectionProvider(BandoResponsabiliCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoResponsabiliCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoResponsabiliCollection(this);
		}

		//Get e Set
		public BandoResponsabiliCollection CollectionObj
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
		public int SaveCollection(BandoResponsabiliCollection collectionObj)
		{
			return BandoResponsabiliDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoResponsabili bandoresponsabiliObj)
		{
			return BandoResponsabiliDAL.Save(_dbProviderObj, bandoresponsabiliObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoResponsabiliCollection collectionObj)
		{
			return BandoResponsabiliDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoResponsabili bandoresponsabiliObj)
		{
			return BandoResponsabiliDAL.Delete(_dbProviderObj, bandoresponsabiliObj);
		}

		//getById
		public BandoResponsabili GetById(IntNT IdValue)
		{
			BandoResponsabili BandoResponsabiliTemp = BandoResponsabiliDAL.GetById(_dbProviderObj, IdValue);
			if (BandoResponsabiliTemp!=null) BandoResponsabiliTemp.Provider = this;
			return BandoResponsabiliTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoResponsabiliCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
StringNT ProvinciaEqualThis, BoolNT AttivoEqualThis, DatetimeNT DataEqualThis, 
IntNT OperatoreEqualThis)
		{
			BandoResponsabiliCollection BandoResponsabiliCollectionTemp = BandoResponsabiliDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
ProvinciaEqualThis, AttivoEqualThis, DataEqualThis, 
OperatoreEqualThis);
			BandoResponsabiliCollectionTemp.Provider = this;
			return BandoResponsabiliCollectionTemp;
		}

		//Find: popola la collection
		public BandoResponsabiliCollection Find(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, StringNT ProvinciaEqualThis, 
BoolNT ProvinciaIsNull, BoolNT AttivoEqualThis)
		{
			BandoResponsabiliCollection BandoResponsabiliCollectionTemp = BandoResponsabiliDAL.Find(_dbProviderObj, IdbandoEqualThis, IdutenteEqualThis, ProvinciaEqualThis, 
ProvinciaIsNull, AttivoEqualThis);
			BandoResponsabiliCollectionTemp.Provider = this;
			return BandoResponsabiliCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_RESPONSABILI>
  <ViewName>vBANDO_RESPONSABILI</ViewName>
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
    <Find OrderBy="ORDER BY PROVINCIA, NOMINATIVO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <PROVINCIA>Equal</PROVINCIA>
      <PROVINCIA>IsNull</PROVINCIA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProvincia>
      <PROVINCIA>Equal</PROVINCIA>
      <PROVINCIA>IsNull</PROVINCIA>
    </FiltroProvincia>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_RESPONSABILI>
*/
