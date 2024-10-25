using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoValutatori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoValutatoriProvider
	{
		int Save(BandoValutatori BandoValutatoriObj);
		int SaveCollection(BandoValutatoriCollection collectionObj);
		int Delete(BandoValutatori BandoValutatoriObj);
		int DeleteCollection(BandoValutatoriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoValutatori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoValutatori: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _IdValutatore;
		private NullTypes.IntNT _IdBando;
		private NullTypes.BoolNT _Presidente;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		[NonSerialized] private IBandoValutatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoValutatoriProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoValutatori()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_VALUTATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValutatore
		{
			get { return _IdValutatore; }
			set {
				if (IdValutatore != value)
				{
					_IdValutatore = value;
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
		/// Corrisponde al campo:PRESIDENTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Presidente
		{
			get { return _Presidente; }
			set {
				if (Presidente != value)
				{
					_Presidente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
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
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
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
	/// Summary description for BandoValutatoriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoValutatoriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoValutatoriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoValutatori) info.GetValue(i.ToString(),typeof(BandoValutatori)));
			}
		}

		//Costruttore
		public BandoValutatoriCollection()
		{
			this.ItemType = typeof(BandoValutatori);
		}

		//Costruttore con provider
		public BandoValutatoriCollection(IBandoValutatoriProvider providerObj)
		{
			this.ItemType = typeof(BandoValutatori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoValutatori this[int index]
		{
			get { return (BandoValutatori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoValutatoriCollection GetChanges()
		{
			return (BandoValutatoriCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoValutatoriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoValutatoriProvider Provider
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
		public int Add(BandoValutatori BandoValutatoriObj)
		{
			if (BandoValutatoriObj.Provider == null) BandoValutatoriObj.Provider = this.Provider;
			return base.Add(BandoValutatoriObj);
		}

		//AddCollection
		public void AddCollection(BandoValutatoriCollection BandoValutatoriCollectionObj)
		{
			foreach (BandoValutatori BandoValutatoriObj in BandoValutatoriCollectionObj)
				this.Add(BandoValutatoriObj);
		}

		//Insert
		public void Insert(int index, BandoValutatori BandoValutatoriObj)
		{
			if (BandoValutatoriObj.Provider == null) BandoValutatoriObj.Provider = this.Provider;
			base.Insert(index, BandoValutatoriObj);
		}

		//CollectionGetById
		public BandoValutatori CollectionGetById(NullTypes.IntNT IdValutatoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdValutatore == IdValutatoreValue))
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
		public BandoValutatoriCollection SubSelect(NullTypes.IntNT IdValutatoreEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdUtenteEqualThis, 
NullTypes.BoolNT PresidenteEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, 
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			BandoValutatoriCollection BandoValutatoriCollectionTemp = new BandoValutatoriCollection();
			foreach (BandoValutatori BandoValutatoriItem in this)
			{
				if (((IdValutatoreEqualThis == null) || ((BandoValutatoriItem.IdValutatore != null) && (BandoValutatoriItem.IdValutatore.Value == IdValutatoreEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoValutatoriItem.IdBando != null) && (BandoValutatoriItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((BandoValutatoriItem.IdUtente != null) && (BandoValutatoriItem.IdUtente.Value == IdUtenteEqualThis.Value))) && 
((PresidenteEqualThis == null) || ((BandoValutatoriItem.Presidente != null) && (BandoValutatoriItem.Presidente.Value == PresidenteEqualThis.Value))) && ((AttivoEqualThis == null) || ((BandoValutatoriItem.Attivo != null) && (BandoValutatoriItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((BandoValutatoriItem.DataInizio != null) && (BandoValutatoriItem.DataInizio.Value == DataInizioEqualThis.Value))) && 
((DataFineEqualThis == null) || ((BandoValutatoriItem.DataFine != null) && (BandoValutatoriItem.DataFine.Value == DataFineEqualThis.Value))) && ((OrdineEqualThis == null) || ((BandoValutatoriItem.Ordine != null) && (BandoValutatoriItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					BandoValutatoriCollectionTemp.Add(BandoValutatoriItem);
				}
			}
			return BandoValutatoriCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoValutatoriCollection Filter(NullTypes.IntNT IdUtenteEqualThis, NullTypes.IntNT IdValutatoreEqualThis, NullTypes.IntNT IdBandoEqualThis)
		{
			BandoValutatoriCollection BandoValutatoriCollectionTemp = new BandoValutatoriCollection();
			foreach (BandoValutatori BandoValutatoriItem in this)
			{
				if (((IdUtenteEqualThis == null) || ((BandoValutatoriItem.IdUtente != null) && (BandoValutatoriItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((IdValutatoreEqualThis == null) || ((BandoValutatoriItem.IdValutatore != null) && (BandoValutatoriItem.IdValutatore.Value == IdValutatoreEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoValutatoriItem.IdBando != null) && (BandoValutatoriItem.IdBando.Value == IdBandoEqualThis.Value))))
				{
					BandoValutatoriCollectionTemp.Add(BandoValutatoriItem);
				}
			}
			return BandoValutatoriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoValutatoriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoValutatoriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoValutatori BandoValutatoriObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdValutatore", BandoValutatoriObj.IdValutatore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", BandoValutatoriObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoValutatoriObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Presidente", BandoValutatoriObj.Presidente);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BandoValutatoriObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", BandoValutatoriObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", BandoValutatoriObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", BandoValutatoriObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, BandoValutatori BandoValutatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoValutatoriInsert", new string[] {"IdUtente", "IdBando", 
"Presidente", "Attivo", "DataInizio", 
"DataFine", "Ordine", }, new string[] {"int", "int", 
"bool", "bool", "DateTime", 
"DateTime", "int", },"");
				CompileIUCmd(false, insertCmd,BandoValutatoriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoValutatoriObj.IdValutatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALUTATORE"]);
				}
				BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValutatoriObj.IsDirty = false;
				BandoValutatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoValutatori BandoValutatoriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoValutatoriUpdate", new string[] {"IdUtente", "IdValutatore", "IdBando", 
"Presidente", "Attivo", "DataInizio", 
"DataFine", "Ordine", }, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"DateTime", "int", },"");
				CompileIUCmd(true, updateCmd,BandoValutatoriObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValutatoriObj.IsDirty = false;
				BandoValutatoriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoValutatori BandoValutatoriObj)
		{
			switch (BandoValutatoriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoValutatoriObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoValutatoriObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoValutatoriObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoValutatoriCollection BandoValutatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoValutatoriUpdate", new string[] {"IdUtente", "IdValutatore", "IdBando", 
"Presidente", "Attivo", "DataInizio", 
"DataFine", "Ordine", }, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"DateTime", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoValutatoriInsert", new string[] {"IdUtente", "IdBando", 
"Presidente", "Attivo", "DataInizio", 
"DataFine", "Ordine", }, new string[] {"int", "int", 
"bool", "bool", "DateTime", 
"DateTime", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValutatoriDelete", new string[] {"IdValutatore"}, new string[] {"int"},"");
				for (int i = 0; i < BandoValutatoriCollectionObj.Count; i++)
				{
					switch (BandoValutatoriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoValutatoriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoValutatoriCollectionObj[i].IdValutatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALUTATORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoValutatoriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoValutatoriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValutatore", (SiarLibrary.NullTypes.IntNT)BandoValutatoriCollectionObj[i].IdValutatore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoValutatoriCollectionObj.Count; i++)
				{
					if ((BandoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoValutatoriCollectionObj[i].IsDirty = false;
						BandoValutatoriCollectionObj[i].IsPersistent = true;
					}
					if ((BandoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoValutatoriCollectionObj[i].IsDirty = false;
						BandoValutatoriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoValutatori BandoValutatoriObj)
		{
			int returnValue = 0;
			if (BandoValutatoriObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoValutatoriObj.IdValutatore);
			}
			BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoValutatoriObj.IsDirty = false;
			BandoValutatoriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValutatoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValutatoriDelete", new string[] {"IdValutatore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValutatore", (SiarLibrary.NullTypes.IntNT)IdValutatoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoValutatoriCollection BandoValutatoriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoValutatoriDelete", new string[] {"IdValutatore"}, new string[] {"int"},"");
				for (int i = 0; i < BandoValutatoriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdValutatore", BandoValutatoriCollectionObj[i].IdValutatore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoValutatoriCollectionObj.Count; i++)
				{
					if ((BandoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoValutatoriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoValutatoriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoValutatoriCollectionObj[i].IsDirty = false;
						BandoValutatoriCollectionObj[i].IsPersistent = false;
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
		public static BandoValutatori GetById(DbProvider db, int IdValutatoreValue)
		{
			BandoValutatori BandoValutatoriObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoValutatoriGetById", new string[] {"IdValutatore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdValutatore", (SiarLibrary.NullTypes.IntNT)IdValutatoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoValutatoriObj = GetFromDatareader(db);
				BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValutatoriObj.IsDirty = false;
				BandoValutatoriObj.IsPersistent = true;
			}
			db.Close();
			return BandoValutatoriObj;
		}

		//getFromDatareader
		public static BandoValutatori GetFromDatareader(DbProvider db)
		{
			BandoValutatori BandoValutatoriObj = new BandoValutatori();
			BandoValutatoriObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			BandoValutatoriObj.IdValutatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALUTATORE"]);
			BandoValutatoriObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoValutatoriObj.Presidente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRESIDENTE"]);
			BandoValutatoriObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoValutatoriObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			BandoValutatoriObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			BandoValutatoriObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			BandoValutatoriObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			BandoValutatoriObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			BandoValutatoriObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoValutatoriObj.IsDirty = false;
			BandoValutatoriObj.IsPersistent = true;
			return BandoValutatoriObj;
		}

		//Find Select

		public static BandoValutatoriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdValutatoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.BoolNT PresidenteEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BandoValutatoriCollection BandoValutatoriCollectionObj = new BandoValutatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zbandovalutatorifindselect", new string[] {"IdValutatoreequalthis", "IdBandoequalthis", "IdUtenteequalthis", 
"Presidenteequalthis", "Attivoequalthis", "DataInizioequalthis", 
"DataFineequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool", "DateTime", 
"DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutatoreequalthis", IdValutatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Presidenteequalthis", PresidenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BandoValutatori BandoValutatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoValutatoriObj = GetFromDatareader(db);
				BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValutatoriObj.IsDirty = false;
				BandoValutatoriObj.IsPersistent = true;
				BandoValutatoriCollectionObj.Add(BandoValutatoriObj);
			}
			db.Close();
			return BandoValutatoriCollectionObj;
		}

		//Find Find

		public static BandoValutatoriCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdValutatoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			BandoValutatoriCollection BandoValutatoriCollectionObj = new BandoValutatoriCollection();

			IDbCommand findCmd = db.InitCmd("Zbandovalutatorifindfind", new string[] {"IdValutatoreequalthis", "IdBandoequalthis", "IdUtenteequalthis", 
"Attivoequalthis", "Ordineequalthis"}, new string[] {"int", "int", "int", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutatoreequalthis", IdValutatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			BandoValutatori BandoValutatoriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoValutatoriObj = GetFromDatareader(db);
				BandoValutatoriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoValutatoriObj.IsDirty = false;
				BandoValutatoriObj.IsPersistent = true;
				BandoValutatoriCollectionObj.Add(BandoValutatoriObj);
			}
			db.Close();
			return BandoValutatoriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoValutatoriCollectionProvider:IBandoValutatoriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoValutatoriCollectionProvider : IBandoValutatoriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoValutatori
		protected BandoValutatoriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoValutatoriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoValutatoriCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoValutatoriCollectionProvider(IntNT IdvalutatoreEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
BoolNT AttivoEqualThis, IntNT OrdineEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvalutatoreEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
AttivoEqualThis, OrdineEqualThis);
		}

		//Costruttore3: ha in input bandovalutatoriCollectionObj - non popola la collection
		public BandoValutatoriCollectionProvider(BandoValutatoriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoValutatoriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoValutatoriCollection(this);
		}

		//Get e Set
		public BandoValutatoriCollection CollectionObj
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
		public int SaveCollection(BandoValutatoriCollection collectionObj)
		{
			return BandoValutatoriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoValutatori bandovalutatoriObj)
		{
			return BandoValutatoriDAL.Save(_dbProviderObj, bandovalutatoriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoValutatoriCollection collectionObj)
		{
			return BandoValutatoriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoValutatori bandovalutatoriObj)
		{
			return BandoValutatoriDAL.Delete(_dbProviderObj, bandovalutatoriObj);
		}

		//getById
		public BandoValutatori GetById(IntNT IdValutatoreValue)
		{
			BandoValutatori BandoValutatoriTemp = BandoValutatoriDAL.GetById(_dbProviderObj, IdValutatoreValue);
			if (BandoValutatoriTemp!=null) BandoValutatoriTemp.Provider = this;
			return BandoValutatoriTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoValutatoriCollection Select(IntNT IdvalutatoreEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
BoolNT PresidenteEqualThis, BoolNT AttivoEqualThis, DatetimeNT DatainizioEqualThis, 
DatetimeNT DatafineEqualThis, IntNT OrdineEqualThis)
		{
			BandoValutatoriCollection BandoValutatoriCollectionTemp = BandoValutatoriDAL.Select(_dbProviderObj, IdvalutatoreEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
PresidenteEqualThis, AttivoEqualThis, DatainizioEqualThis, 
DatafineEqualThis, OrdineEqualThis);
			BandoValutatoriCollectionTemp.Provider = this;
			return BandoValutatoriCollectionTemp;
		}

		//Find: popola la collection
		public BandoValutatoriCollection Find(IntNT IdvalutatoreEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
BoolNT AttivoEqualThis, IntNT OrdineEqualThis)
		{
			BandoValutatoriCollection BandoValutatoriCollectionTemp = BandoValutatoriDAL.Find(_dbProviderObj, IdvalutatoreEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
AttivoEqualThis, OrdineEqualThis);
			BandoValutatoriCollectionTemp.Provider = this;
			return BandoValutatoriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_VALUTATORI>
  <ViewName>vBANDO_VALUTATORI</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, ORDINE">
      <ID_VALUTATORE>Equal</ID_VALUTATORE>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <ATTIVO>Equal</ATTIVO>
      <ORDINE>Equal</ORDINE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_UTENTE>Equal</ID_UTENTE>
      <ID_VALUTATORE>Equal</ID_VALUTATORE>
      <ID_BANDO>Equal</ID_BANDO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_VALUTATORI>
*/
