using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per FascicoloPaleo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFascicoloPaleoProvider
	{
		int Save(FascicoloPaleo FascicoloPaleoObj);
		int SaveCollection(FascicoloPaleoCollection collectionObj);
		int Delete(FascicoloPaleo FascicoloPaleoObj);
		int DeleteCollection(FascicoloPaleoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FascicoloPaleo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class FascicoloPaleo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _Anno;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Fascicolo;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.StringNT _Note;
		[NonSerialized] private IFascicoloPaleoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFascicoloPaleoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FascicoloPaleo()
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
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:VARCHAR(30)
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
		/// Corrisponde al campo:FASCICOLO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT Fascicolo
		{
			get { return _Fascicolo; }
			set {
				if (Fascicolo != value)
				{
					_Fascicolo = value;
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
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
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
	/// Summary description for FascicoloPaleoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FascicoloPaleoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FascicoloPaleoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FascicoloPaleo) info.GetValue(i.ToString(),typeof(FascicoloPaleo)));
			}
		}

		//Costruttore
		public FascicoloPaleoCollection()
		{
			this.ItemType = typeof(FascicoloPaleo);
		}

		//Costruttore con provider
		public FascicoloPaleoCollection(IFascicoloPaleoProvider providerObj)
		{
			this.ItemType = typeof(FascicoloPaleo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FascicoloPaleo this[int index]
		{
			get { return (FascicoloPaleo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FascicoloPaleoCollection GetChanges()
		{
			return (FascicoloPaleoCollection) base.GetChanges();
		}

		[NonSerialized] private IFascicoloPaleoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFascicoloPaleoProvider Provider
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
		public int Add(FascicoloPaleo FascicoloPaleoObj)
		{
			if (FascicoloPaleoObj.Provider == null) FascicoloPaleoObj.Provider = this.Provider;
			return base.Add(FascicoloPaleoObj);
		}

		//AddCollection
		public void AddCollection(FascicoloPaleoCollection FascicoloPaleoCollectionObj)
		{
			foreach (FascicoloPaleo FascicoloPaleoObj in FascicoloPaleoCollectionObj)
				this.Add(FascicoloPaleoObj);
		}

		//Insert
		public void Insert(int index, FascicoloPaleo FascicoloPaleoObj)
		{
			if (FascicoloPaleoObj.Provider == null) FascicoloPaleoObj.Provider = this.Provider;
			base.Insert(index, FascicoloPaleoObj);
		}

		//CollectionGetById
		public FascicoloPaleo CollectionGetById(NullTypes.IntNT IdValue)
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
		public FascicoloPaleoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT AnnoEqualThis, NullTypes.StringNT CodTipoEqualThis, 
NullTypes.StringNT FascicoloEqualThis, NullTypes.StringNT ProvinciaEqualThis, NullTypes.StringNT CodEnteEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.StringNT NoteEqualThis)
		{
			FascicoloPaleoCollection FascicoloPaleoCollectionTemp = new FascicoloPaleoCollection();
			foreach (FascicoloPaleo FascicoloPaleoItem in this)
			{
				if (((IdEqualThis == null) || ((FascicoloPaleoItem.Id != null) && (FascicoloPaleoItem.Id.Value == IdEqualThis.Value))) && ((AnnoEqualThis == null) || ((FascicoloPaleoItem.Anno != null) && (FascicoloPaleoItem.Anno.Value == AnnoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((FascicoloPaleoItem.CodTipo != null) && (FascicoloPaleoItem.CodTipo.Value == CodTipoEqualThis.Value))) && 
((FascicoloEqualThis == null) || ((FascicoloPaleoItem.Fascicolo != null) && (FascicoloPaleoItem.Fascicolo.Value == FascicoloEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((FascicoloPaleoItem.Provincia != null) && (FascicoloPaleoItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((CodEnteEqualThis == null) || ((FascicoloPaleoItem.CodEnte != null) && (FascicoloPaleoItem.CodEnte.Value == CodEnteEqualThis.Value))) && 
((AttivoEqualThis == null) || ((FascicoloPaleoItem.Attivo != null) && (FascicoloPaleoItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((FascicoloPaleoItem.DataInizioValidita != null) && (FascicoloPaleoItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((FascicoloPaleoItem.DataFineValidita != null) && (FascicoloPaleoItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((NoteEqualThis == null) || ((FascicoloPaleoItem.Note != null) && (FascicoloPaleoItem.Note.Value == NoteEqualThis.Value))))
				{
					FascicoloPaleoCollectionTemp.Add(FascicoloPaleoItem);
				}
			}
			return FascicoloPaleoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FascicoloPaleoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class FascicoloPaleoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, FascicoloPaleo FascicoloPaleoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", FascicoloPaleoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", FascicoloPaleoObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", FascicoloPaleoObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Fascicolo", FascicoloPaleoObj.Fascicolo);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", FascicoloPaleoObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", FascicoloPaleoObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", FascicoloPaleoObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", FascicoloPaleoObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", FascicoloPaleoObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", FascicoloPaleoObj.Note);
		}
		//Insert
		private static int Insert(DbProvider db, FascicoloPaleo FascicoloPaleoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFascicoloPaleoInsert", new string[] {"Anno", "CodTipo", 
"Fascicolo", "Provincia", "CodEnte", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"Note"}, new string[] {"int", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				CompileIUCmd(false, insertCmd,FascicoloPaleoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FascicoloPaleoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				FascicoloPaleoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FascicoloPaleoObj.IsDirty = false;
				FascicoloPaleoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, FascicoloPaleo FascicoloPaleoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFascicoloPaleoUpdate", new string[] {"Id", "Anno", "CodTipo", 
"Fascicolo", "Provincia", "CodEnte", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"Note"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				CompileIUCmd(true, updateCmd,FascicoloPaleoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FascicoloPaleoObj.IsDirty = false;
				FascicoloPaleoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, FascicoloPaleo FascicoloPaleoObj)
		{
			switch (FascicoloPaleoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FascicoloPaleoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FascicoloPaleoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FascicoloPaleoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FascicoloPaleoCollection FascicoloPaleoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFascicoloPaleoUpdate", new string[] {"Id", "Anno", "CodTipo", 
"Fascicolo", "Provincia", "CodEnte", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"Note"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFascicoloPaleoInsert", new string[] {"Anno", "CodTipo", 
"Fascicolo", "Provincia", "CodEnte", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"Note"}, new string[] {"int", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFascicoloPaleoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < FascicoloPaleoCollectionObj.Count; i++)
				{
					switch (FascicoloPaleoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FascicoloPaleoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FascicoloPaleoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									FascicoloPaleoCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FascicoloPaleoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FascicoloPaleoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)FascicoloPaleoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FascicoloPaleoCollectionObj.Count; i++)
				{
					if ((FascicoloPaleoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FascicoloPaleoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FascicoloPaleoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FascicoloPaleoCollectionObj[i].IsDirty = false;
						FascicoloPaleoCollectionObj[i].IsPersistent = true;
					}
					if ((FascicoloPaleoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FascicoloPaleoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FascicoloPaleoCollectionObj[i].IsDirty = false;
						FascicoloPaleoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, FascicoloPaleo FascicoloPaleoObj)
		{
			int returnValue = 0;
			if (FascicoloPaleoObj.IsPersistent) 
			{
				returnValue = Delete(db, FascicoloPaleoObj.Id);
			}
			FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FascicoloPaleoObj.IsDirty = false;
			FascicoloPaleoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFascicoloPaleoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FascicoloPaleoCollection FascicoloPaleoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFascicoloPaleoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < FascicoloPaleoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", FascicoloPaleoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FascicoloPaleoCollectionObj.Count; i++)
				{
					if ((FascicoloPaleoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FascicoloPaleoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FascicoloPaleoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FascicoloPaleoCollectionObj[i].IsDirty = false;
						FascicoloPaleoCollectionObj[i].IsPersistent = false;
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
		public static FascicoloPaleo GetById(DbProvider db, int IdValue)
		{
			FascicoloPaleo FascicoloPaleoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFascicoloPaleoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FascicoloPaleoObj = GetFromDatareader(db);
				FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FascicoloPaleoObj.IsDirty = false;
				FascicoloPaleoObj.IsPersistent = true;
			}
			db.Close();
			return FascicoloPaleoObj;
		}

		//getFromDatareader
		public static FascicoloPaleo GetFromDatareader(DbProvider db)
		{
			FascicoloPaleo FascicoloPaleoObj = new FascicoloPaleo();
			FascicoloPaleoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			FascicoloPaleoObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			FascicoloPaleoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			FascicoloPaleoObj.Fascicolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASCICOLO"]);
			FascicoloPaleoObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			FascicoloPaleoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			FascicoloPaleoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			FascicoloPaleoObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			FascicoloPaleoObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			FascicoloPaleoObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FascicoloPaleoObj.IsDirty = false;
			FascicoloPaleoObj.IsPersistent = true;
			return FascicoloPaleoObj;
		}

		//Find Select

		public static FascicoloPaleoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, 
SiarLibrary.NullTypes.StringNT FascicoloEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.StringNT NoteEqualThis)

		{

			FascicoloPaleoCollection FascicoloPaleoCollectionObj = new FascicoloPaleoCollection();

			IDbCommand findCmd = db.InitCmd("Zfascicolopaleofindselect", new string[] {"Idequalthis", "Annoequalthis", "CodTipoequalthis", 
"Fascicoloequalthis", "Provinciaequalthis", "CodEnteequalthis", 
"Attivoequalthis", "DataInizioValiditaequalthis", "DataFineValiditaequalthis", 
"Noteequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"bool", "DateTime", "DateTime", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Fascicoloequalthis", FascicoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			FascicoloPaleo FascicoloPaleoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FascicoloPaleoObj = GetFromDatareader(db);
				FascicoloPaleoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FascicoloPaleoObj.IsDirty = false;
				FascicoloPaleoObj.IsPersistent = true;
				FascicoloPaleoCollectionObj.Add(FascicoloPaleoObj);
			}
			db.Close();
			return FascicoloPaleoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for FascicoloPaleoCollectionProvider:IFascicoloPaleoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FascicoloPaleoCollectionProvider : IFascicoloPaleoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FascicoloPaleo
		protected FascicoloPaleoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FascicoloPaleoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FascicoloPaleoCollection(this);
		}

		//Costruttore3: ha in input fascicolopaleoCollectionObj - non popola la collection
		public FascicoloPaleoCollectionProvider(FascicoloPaleoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FascicoloPaleoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FascicoloPaleoCollection(this);
		}

		//Get e Set
		public FascicoloPaleoCollection CollectionObj
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
		public int SaveCollection(FascicoloPaleoCollection collectionObj)
		{
			return FascicoloPaleoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FascicoloPaleo fascicolopaleoObj)
		{
			return FascicoloPaleoDAL.Save(_dbProviderObj, fascicolopaleoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FascicoloPaleoCollection collectionObj)
		{
			return FascicoloPaleoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FascicoloPaleo fascicolopaleoObj)
		{
			return FascicoloPaleoDAL.Delete(_dbProviderObj, fascicolopaleoObj);
		}

		//getById
		public FascicoloPaleo GetById(IntNT IdValue)
		{
			FascicoloPaleo FascicoloPaleoTemp = FascicoloPaleoDAL.GetById(_dbProviderObj, IdValue);
			if (FascicoloPaleoTemp!=null) FascicoloPaleoTemp.Provider = this;
			return FascicoloPaleoTemp;
		}

		//Select: popola la collection
		public FascicoloPaleoCollection Select(IntNT IdEqualThis, IntNT AnnoEqualThis, StringNT CodtipoEqualThis, 
StringNT FascicoloEqualThis, StringNT ProvinciaEqualThis, StringNT CodenteEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, 
StringNT NoteEqualThis)
		{
			FascicoloPaleoCollection FascicoloPaleoCollectionTemp = FascicoloPaleoDAL.Select(_dbProviderObj, IdEqualThis, AnnoEqualThis, CodtipoEqualThis, 
FascicoloEqualThis, ProvinciaEqualThis, CodenteEqualThis, 
AttivoEqualThis, DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, 
NoteEqualThis);
			FascicoloPaleoCollectionTemp.Provider = this;
			return FascicoloPaleoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FASCICOLO_PALEO>
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
</FASCICOLO_PALEO>
*/
