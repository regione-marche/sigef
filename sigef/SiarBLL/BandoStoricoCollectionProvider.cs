using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoStoricoProvider
	{
		int Save(BandoStorico BandoStoricoObj);
		int SaveCollection(BandoStoricoCollection collectionObj);
		int Delete(BandoStorico BandoStoricoObj);
		int DeleteCollection(BandoStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoStorico: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.StringNT _Stato;
		private NullTypes.IntNT _OrdineStato;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.IntNT _NumeroAtto;
		private NullTypes.DatetimeNT _DataAtto;
		[NonSerialized] private IBandoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoStoricoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoStorico()
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
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_STATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineStato
		{
			get { return _OrdineStato; }
			set {
				if (OrdineStato != value)
				{
					_OrdineStato = value;
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
		/// Corrisponde al campo:NUMERO_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroAtto
		{
			get { return _NumeroAtto; }
			set {
				if (NumeroAtto != value)
				{
					_NumeroAtto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ATTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAtto
		{
			get { return _DataAtto; }
			set {
				if (DataAtto != value)
				{
					_DataAtto = value;
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
	/// Summary description for BandoStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoStorico) info.GetValue(i.ToString(),typeof(BandoStorico)));
			}
		}

		//Costruttore
		public BandoStoricoCollection()
		{
			this.ItemType = typeof(BandoStorico);
		}

		//Costruttore con provider
		public BandoStoricoCollection(IBandoStoricoProvider providerObj)
		{
			this.ItemType = typeof(BandoStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoStorico this[int index]
		{
			get { return (BandoStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoStoricoCollection GetChanges()
		{
			return (BandoStoricoCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoStoricoProvider Provider
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
		public int Add(BandoStorico BandoStoricoObj)
		{
			if (BandoStoricoObj.Provider == null) BandoStoricoObj.Provider = this.Provider;
			return base.Add(BandoStoricoObj);
		}

		//AddCollection
		public void AddCollection(BandoStoricoCollection BandoStoricoCollectionObj)
		{
			foreach (BandoStorico BandoStoricoObj in BandoStoricoCollectionObj)
				this.Add(BandoStoricoObj);
		}

		//Insert
		public void Insert(int index, BandoStorico BandoStoricoObj)
		{
			if (BandoStoricoObj.Provider == null) BandoStoricoObj.Provider = this.Provider;
			base.Insert(index, BandoStoricoObj);
		}

		//CollectionGetById
		public BandoStorico CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoStoricoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.IntNT IdAttoEqualThis)
		{
			BandoStoricoCollection BandoStoricoCollectionTemp = new BandoStoricoCollection();
			foreach (BandoStorico BandoStoricoItem in this)
			{
				if (((IdEqualThis == null) || ((BandoStoricoItem.Id != null) && (BandoStoricoItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoStoricoItem.IdBando != null) && (BandoStoricoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((BandoStoricoItem.CodStato != null) && (BandoStoricoItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((DataEqualThis == null) || ((BandoStoricoItem.Data != null) && (BandoStoricoItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((BandoStoricoItem.Operatore != null) && (BandoStoricoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((BandoStoricoItem.Segnatura != null) && (BandoStoricoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((IdAttoEqualThis == null) || ((BandoStoricoItem.IdAtto != null) && (BandoStoricoItem.IdAtto.Value == IdAttoEqualThis.Value))))
				{
					BandoStoricoCollectionTemp.Add(BandoStoricoItem);
				}
			}
			return BandoStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoStorico BandoStoricoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoStoricoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoStoricoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStato", BandoStoricoObj.CodStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", BandoStoricoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", BandoStoricoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", BandoStoricoObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", BandoStoricoObj.IdAtto);
		}
		//Insert
		private static int Insert(DbProvider db, BandoStorico BandoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoStoricoInsert", new string[] {"IdBando", "CodStato", 
"Data", "Operatore", "Segnatura", 
"IdAtto", 
}, new string[] {"int", "string", 
"DateTime", "int", "string", 
"int", 
},"");
				CompileIUCmd(false, insertCmd,BandoStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoStoricoObj.IsDirty = false;
				BandoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoStorico BandoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoStoricoUpdate", new string[] {"Id", "IdBando", "CodStato", 
"Data", "Operatore", "Segnatura", 
"IdAtto", 
}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"int", 
},"");
				CompileIUCmd(true, updateCmd,BandoStoricoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoStoricoObj.IsDirty = false;
				BandoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoStorico BandoStoricoObj)
		{
			switch (BandoStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoStoricoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoStoricoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoStoricoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoStoricoCollection BandoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoStoricoUpdate", new string[] {"Id", "IdBando", "CodStato", 
"Data", "Operatore", "Segnatura", 
"IdAtto", 
}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoStoricoInsert", new string[] {"IdBando", "CodStato", 
"Data", "Operatore", "Segnatura", 
"IdAtto", 
}, new string[] {"int", "string", 
"DateTime", "int", "string", 
"int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoStoricoCollectionObj.Count; i++)
				{
					switch (BandoStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoStoricoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoStoricoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoStoricoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoStoricoCollectionObj.Count; i++)
				{
					if ((BandoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoStoricoCollectionObj[i].IsDirty = false;
						BandoStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((BandoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoStoricoCollectionObj[i].IsDirty = false;
						BandoStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoStorico BandoStoricoObj)
		{
			int returnValue = 0;
			if (BandoStoricoObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoStoricoObj.Id);
			}
			BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoStoricoObj.IsDirty = false;
			BandoStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoStoricoCollection BandoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoStoricoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoStoricoCollectionObj.Count; i++)
				{
					if ((BandoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoStoricoCollectionObj[i].IsDirty = false;
						BandoStoricoCollectionObj[i].IsPersistent = false;
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
		public static BandoStorico GetById(DbProvider db, int IdValue)
		{
			BandoStorico BandoStoricoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoStoricoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoStoricoObj = GetFromDatareader(db);
				BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoStoricoObj.IsDirty = false;
				BandoStoricoObj.IsPersistent = true;
			}
			db.Close();
			return BandoStoricoObj;
		}

		//getFromDatareader
		public static BandoStorico GetFromDatareader(DbProvider db)
		{
			BandoStorico BandoStoricoObj = new BandoStorico();
			BandoStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoStoricoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoStoricoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			BandoStoricoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			BandoStoricoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			BandoStoricoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			BandoStoricoObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			BandoStoricoObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			BandoStoricoObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			BandoStoricoObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			BandoStoricoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			BandoStoricoObj.NumeroAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ATTO"]);
			BandoStoricoObj.DataAtto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO"]);
			BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoStoricoObj.IsDirty = false;
			BandoStoricoObj.IsPersistent = true;
			return BandoStoricoObj;
		}

		//Find Select

		public static BandoStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.IntNT IdAttoEqualThis)

		{

			BandoStoricoCollection BandoStoricoCollectionObj = new BandoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandostoricofindselect", new string[] {"Idequalthis", "IdBandoequalthis", "CodStatoequalthis", 
"Dataequalthis", "Operatoreequalthis", "Segnaturaequalthis", 
"IdAttoequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			BandoStorico BandoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoStoricoObj = GetFromDatareader(db);
				BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoStoricoObj.IsDirty = false;
				BandoStoricoObj.IsPersistent = true;
				BandoStoricoCollectionObj.Add(BandoStoricoObj);
			}
			db.Close();
			return BandoStoricoCollectionObj;
		}

		//Find Find

		public static BandoStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis)

		{

			BandoStoricoCollection BandoStoricoCollectionObj = new BandoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zbandostoricofindfind", new string[] {"IdBandoequalthis", "CodStatoequalthis"}, new string[] {"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			BandoStorico BandoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoStoricoObj = GetFromDatareader(db);
				BandoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoStoricoObj.IsDirty = false;
				BandoStoricoObj.IsPersistent = true;
				BandoStoricoCollectionObj.Add(BandoStoricoObj);
			}
			db.Close();
			return BandoStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoStoricoCollectionProvider:IBandoStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoStoricoCollectionProvider : IBandoStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoStorico
		protected BandoStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoStoricoCollectionProvider(IntNT IdbandoEqualThis, StringNT CodstatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodstatoEqualThis);
		}

		//Costruttore3: ha in input bandostoricoCollectionObj - non popola la collection
		public BandoStoricoCollectionProvider(BandoStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoStoricoCollection(this);
		}

		//Get e Set
		public BandoStoricoCollection CollectionObj
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
		public int SaveCollection(BandoStoricoCollection collectionObj)
		{
			return BandoStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoStorico bandostoricoObj)
		{
			return BandoStoricoDAL.Save(_dbProviderObj, bandostoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoStoricoCollection collectionObj)
		{
			return BandoStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoStorico bandostoricoObj)
		{
			return BandoStoricoDAL.Delete(_dbProviderObj, bandostoricoObj);
		}

		//getById
		public BandoStorico GetById(IntNT IdValue)
		{
			BandoStorico BandoStoricoTemp = BandoStoricoDAL.GetById(_dbProviderObj, IdValue);
			if (BandoStoricoTemp!=null) BandoStoricoTemp.Provider = this;
			return BandoStoricoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoStoricoCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, StringNT CodstatoEqualThis, 
DatetimeNT DataEqualThis, IntNT OperatoreEqualThis, StringNT SegnaturaEqualThis, 
IntNT IdattoEqualThis)
		{
			BandoStoricoCollection BandoStoricoCollectionTemp = BandoStoricoDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, CodstatoEqualThis, 
DataEqualThis, OperatoreEqualThis, SegnaturaEqualThis, 
IdattoEqualThis);
			BandoStoricoCollectionTemp.Provider = this;
			return BandoStoricoCollectionTemp;
		}

		//Find: popola la collection
		public BandoStoricoCollection Find(IntNT IdbandoEqualThis, StringNT CodstatoEqualThis)
		{
			BandoStoricoCollection BandoStoricoCollectionTemp = BandoStoricoDAL.Find(_dbProviderObj, IdbandoEqualThis, CodstatoEqualThis);
			BandoStoricoCollectionTemp.Provider = this;
			return BandoStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_STORICO>
  <ViewName>vBANDO_STORICO</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_STATO>Equal</COD_STATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_STORICO>
*/
