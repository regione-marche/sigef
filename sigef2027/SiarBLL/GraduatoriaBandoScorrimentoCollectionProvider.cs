using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaBandoScorrimento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaBandoScorrimentoProvider
	{
		int Save(GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj);
		int SaveCollection(GraduatoriaBandoScorrimentoCollection collectionObj);
		int Delete(GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj);
		int DeleteCollection(GraduatoriaBandoScorrimentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaBandoScorrimento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class GraduatoriaBandoScorrimento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdGraduatoriaBandoScorrimento;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.BoolNT _ScorrimentoCompletato;
		private NullTypes.IntNT _Operatore;
		[NonSerialized] private IGraduatoriaBandoScorrimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaBandoScorrimentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaBandoScorrimento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_GRADUATORIA_BANDO_SCORRIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdGraduatoriaBandoScorrimento
		{
			get { return _IdGraduatoriaBandoScorrimento; }
			set {
				if (IdGraduatoriaBandoScorrimento != value)
				{
					_IdGraduatoriaBandoScorrimento = value;
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
		/// Corrisponde al campo:SCORRIMENTO_COMPLETATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ScorrimentoCompletato
		{
			get { return _ScorrimentoCompletato; }
			set {
				if (ScorrimentoCompletato != value)
				{
					_ScorrimentoCompletato = value;
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
	/// Summary description for GraduatoriaBandoScorrimentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaBandoScorrimentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaBandoScorrimentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaBandoScorrimento) info.GetValue(i.ToString(),typeof(GraduatoriaBandoScorrimento)));
			}
		}

		//Costruttore
		public GraduatoriaBandoScorrimentoCollection()
		{
			this.ItemType = typeof(GraduatoriaBandoScorrimento);
		}

		//Costruttore con provider
		public GraduatoriaBandoScorrimentoCollection(IGraduatoriaBandoScorrimentoProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaBandoScorrimento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaBandoScorrimento this[int index]
		{
			get { return (GraduatoriaBandoScorrimento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaBandoScorrimentoCollection GetChanges()
		{
			return (GraduatoriaBandoScorrimentoCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaBandoScorrimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaBandoScorrimentoProvider Provider
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
		public int Add(GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			if (GraduatoriaBandoScorrimentoObj.Provider == null) GraduatoriaBandoScorrimentoObj.Provider = this.Provider;
			return base.Add(GraduatoriaBandoScorrimentoObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionObj)
		{
			foreach (GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj in GraduatoriaBandoScorrimentoCollectionObj)
				this.Add(GraduatoriaBandoScorrimentoObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			if (GraduatoriaBandoScorrimentoObj.Provider == null) GraduatoriaBandoScorrimentoObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaBandoScorrimentoObj);
		}

		//CollectionGetById
		public GraduatoriaBandoScorrimento CollectionGetById(NullTypes.IntNT IdGraduatoriaBandoScorrimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdGraduatoriaBandoScorrimento == IdGraduatoriaBandoScorrimentoValue))
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
		public GraduatoriaBandoScorrimentoCollection SubSelect(NullTypes.IntNT IdGraduatoriaBandoScorrimentoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, 
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.BoolNT ScorrimentoCompletatoEqualThis, NullTypes.IntNT OperatoreEqualThis)
		{
			GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionTemp = new GraduatoriaBandoScorrimentoCollection();
			foreach (GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoItem in this)
			{
				if (((IdGraduatoriaBandoScorrimentoEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.IdGraduatoriaBandoScorrimento != null) && (GraduatoriaBandoScorrimentoItem.IdGraduatoriaBandoScorrimento.Value == IdGraduatoriaBandoScorrimentoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.IdBando != null) && (GraduatoriaBandoScorrimentoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.DataInizio != null) && (GraduatoriaBandoScorrimentoItem.DataInizio.Value == DataInizioEqualThis.Value))) && 
((DataFineEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.DataFine != null) && (GraduatoriaBandoScorrimentoItem.DataFine.Value == DataFineEqualThis.Value))) && ((ScorrimentoCompletatoEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.ScorrimentoCompletato != null) && (GraduatoriaBandoScorrimentoItem.ScorrimentoCompletato.Value == ScorrimentoCompletatoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((GraduatoriaBandoScorrimentoItem.Operatore != null) && (GraduatoriaBandoScorrimentoItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					GraduatoriaBandoScorrimentoCollectionTemp.Add(GraduatoriaBandoScorrimentoItem);
				}
			}
			return GraduatoriaBandoScorrimentoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaBandoScorrimentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class GraduatoriaBandoScorrimentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdGraduatoriaBandoScorrimento", GraduatoriaBandoScorrimentoObj.IdGraduatoriaBandoScorrimento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", GraduatoriaBandoScorrimentoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", GraduatoriaBandoScorrimentoObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", GraduatoriaBandoScorrimentoObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "ScorrimentoCompletato", GraduatoriaBandoScorrimentoObj.ScorrimentoCompletato);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", GraduatoriaBandoScorrimentoObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoInsert", new string[] {"IdBando", "DataInizio", 
"DataFine", "ScorrimentoCompletato", "Operatore"}, new string[] {"int", "DateTime", 
"DateTime", "bool", "int"},"");
				CompileIUCmd(false, insertCmd,GraduatoriaBandoScorrimentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				GraduatoriaBandoScorrimentoObj.IdGraduatoriaBandoScorrimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_BANDO_SCORRIMENTO"]);
				}
				GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaBandoScorrimentoObj.IsDirty = false;
				GraduatoriaBandoScorrimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoUpdate", new string[] {"IdGraduatoriaBandoScorrimento", "IdBando", "DataInizio", 
"DataFine", "ScorrimentoCompletato", "Operatore"}, new string[] {"int", "int", "DateTime", 
"DateTime", "bool", "int"},"");
				CompileIUCmd(true, updateCmd,GraduatoriaBandoScorrimentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaBandoScorrimentoObj.IsDirty = false;
				GraduatoriaBandoScorrimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			switch (GraduatoriaBandoScorrimentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaBandoScorrimentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaBandoScorrimentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaBandoScorrimentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoUpdate", new string[] {"IdGraduatoriaBandoScorrimento", "IdBando", "DataInizio", 
"DataFine", "ScorrimentoCompletato", "Operatore"}, new string[] {"int", "int", "DateTime", 
"DateTime", "bool", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoInsert", new string[] {"IdBando", "DataInizio", 
"DataFine", "ScorrimentoCompletato", "Operatore"}, new string[] {"int", "DateTime", 
"DateTime", "bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoDelete", new string[] {"IdGraduatoriaBandoScorrimento"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaBandoScorrimentoCollectionObj.Count; i++)
				{
					switch (GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaBandoScorrimentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									GraduatoriaBandoScorrimentoCollectionObj[i].IdGraduatoriaBandoScorrimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_BANDO_SCORRIMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaBandoScorrimentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaBandoScorrimentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaBandoScorrimento", (SiarLibrary.NullTypes.IntNT)GraduatoriaBandoScorrimentoCollectionObj[i].IdGraduatoriaBandoScorrimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaBandoScorrimentoCollectionObj.Count; i++)
				{
					if ((GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsDirty = false;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsDirty = false;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj)
		{
			int returnValue = 0;
			if (GraduatoriaBandoScorrimentoObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaBandoScorrimentoObj.IdGraduatoriaBandoScorrimento);
			}
			GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaBandoScorrimentoObj.IsDirty = false;
			GraduatoriaBandoScorrimentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdGraduatoriaBandoScorrimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoDelete", new string[] {"IdGraduatoriaBandoScorrimento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaBandoScorrimento", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaBandoScorrimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoDelete", new string[] {"IdGraduatoriaBandoScorrimento"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaBandoScorrimentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaBandoScorrimento", GraduatoriaBandoScorrimentoCollectionObj[i].IdGraduatoriaBandoScorrimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaBandoScorrimentoCollectionObj.Count; i++)
				{
					if ((GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaBandoScorrimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsDirty = false;
						GraduatoriaBandoScorrimentoCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaBandoScorrimento GetById(DbProvider db, int IdGraduatoriaBandoScorrimentoValue)
		{
			GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaBandoScorrimentoGetById", new string[] {"IdGraduatoriaBandoScorrimento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdGraduatoriaBandoScorrimento", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaBandoScorrimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaBandoScorrimentoObj = GetFromDatareader(db);
				GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaBandoScorrimentoObj.IsDirty = false;
				GraduatoriaBandoScorrimentoObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaBandoScorrimentoObj;
		}

		//getFromDatareader
		public static GraduatoriaBandoScorrimento GetFromDatareader(DbProvider db)
		{
			GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj = new GraduatoriaBandoScorrimento();
			GraduatoriaBandoScorrimentoObj.IdGraduatoriaBandoScorrimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_BANDO_SCORRIMENTO"]);
			GraduatoriaBandoScorrimentoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			GraduatoriaBandoScorrimentoObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			GraduatoriaBandoScorrimentoObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			GraduatoriaBandoScorrimentoObj.ScorrimentoCompletato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCORRIMENTO_COMPLETATO"]);
			GraduatoriaBandoScorrimentoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaBandoScorrimentoObj.IsDirty = false;
			GraduatoriaBandoScorrimentoObj.IsPersistent = true;
			return GraduatoriaBandoScorrimentoObj;
		}

		//Find Select

		public static GraduatoriaBandoScorrimentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaBandoScorrimentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.BoolNT ScorrimentoCompletatoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionObj = new GraduatoriaBandoScorrimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriabandoscorrimentofindselect", new string[] {"IdGraduatoriaBandoScorrimentoequalthis", "IdBandoequalthis", "DataInizioequalthis", 
"DataFineequalthis", "ScorrimentoCompletatoequalthis", "Operatoreequalthis"}, new string[] {"int", "int", "DateTime", 
"DateTime", "bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGraduatoriaBandoScorrimentoequalthis", IdGraduatoriaBandoScorrimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ScorrimentoCompletatoequalthis", ScorrimentoCompletatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaBandoScorrimentoObj = GetFromDatareader(db);
				GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaBandoScorrimentoObj.IsDirty = false;
				GraduatoriaBandoScorrimentoObj.IsPersistent = true;
				GraduatoriaBandoScorrimentoCollectionObj.Add(GraduatoriaBandoScorrimentoObj);
			}
			db.Close();
			return GraduatoriaBandoScorrimentoCollectionObj;
		}

		//Find Find

		public static GraduatoriaBandoScorrimentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT ScorrimentoCompletatoEqualThis)

		{

			GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionObj = new GraduatoriaBandoScorrimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriabandoscorrimentofindfind", new string[] {"IdBandoequalthis", "ScorrimentoCompletatoequalthis"}, new string[] {"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ScorrimentoCompletatoequalthis", ScorrimentoCompletatoEqualThis);
			GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaBandoScorrimentoObj = GetFromDatareader(db);
				GraduatoriaBandoScorrimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaBandoScorrimentoObj.IsDirty = false;
				GraduatoriaBandoScorrimentoObj.IsPersistent = true;
				GraduatoriaBandoScorrimentoCollectionObj.Add(GraduatoriaBandoScorrimentoObj);
			}
			db.Close();
			return GraduatoriaBandoScorrimentoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaBandoScorrimentoCollectionProvider:IGraduatoriaBandoScorrimentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaBandoScorrimentoCollectionProvider : IGraduatoriaBandoScorrimentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaBandoScorrimento
		protected GraduatoriaBandoScorrimentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaBandoScorrimentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaBandoScorrimentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaBandoScorrimentoCollectionProvider(IntNT IdbandoEqualThis, BoolNT ScorrimentocompletatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, ScorrimentocompletatoEqualThis);
		}

		//Costruttore3: ha in input graduatoriabandoscorrimentoCollectionObj - non popola la collection
		public GraduatoriaBandoScorrimentoCollectionProvider(GraduatoriaBandoScorrimentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaBandoScorrimentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaBandoScorrimentoCollection(this);
		}

		//Get e Set
		public GraduatoriaBandoScorrimentoCollection CollectionObj
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
		public int SaveCollection(GraduatoriaBandoScorrimentoCollection collectionObj)
		{
			return GraduatoriaBandoScorrimentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaBandoScorrimento graduatoriabandoscorrimentoObj)
		{
			return GraduatoriaBandoScorrimentoDAL.Save(_dbProviderObj, graduatoriabandoscorrimentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaBandoScorrimentoCollection collectionObj)
		{
			return GraduatoriaBandoScorrimentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaBandoScorrimento graduatoriabandoscorrimentoObj)
		{
			return GraduatoriaBandoScorrimentoDAL.Delete(_dbProviderObj, graduatoriabandoscorrimentoObj);
		}

		//getById
		public GraduatoriaBandoScorrimento GetById(IntNT IdGraduatoriaBandoScorrimentoValue)
		{
			GraduatoriaBandoScorrimento GraduatoriaBandoScorrimentoTemp = GraduatoriaBandoScorrimentoDAL.GetById(_dbProviderObj, IdGraduatoriaBandoScorrimentoValue);
			if (GraduatoriaBandoScorrimentoTemp!=null) GraduatoriaBandoScorrimentoTemp.Provider = this;
			return GraduatoriaBandoScorrimentoTemp;
		}

		//Select: popola la collection
		public GraduatoriaBandoScorrimentoCollection Select(IntNT IdgraduatoriabandoscorrimentoEqualThis, IntNT IdbandoEqualThis, DatetimeNT DatainizioEqualThis, 
DatetimeNT DatafineEqualThis, BoolNT ScorrimentocompletatoEqualThis, IntNT OperatoreEqualThis)
		{
			GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionTemp = GraduatoriaBandoScorrimentoDAL.Select(_dbProviderObj, IdgraduatoriabandoscorrimentoEqualThis, IdbandoEqualThis, DatainizioEqualThis, 
DatafineEqualThis, ScorrimentocompletatoEqualThis, OperatoreEqualThis);
			GraduatoriaBandoScorrimentoCollectionTemp.Provider = this;
			return GraduatoriaBandoScorrimentoCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaBandoScorrimentoCollection Find(IntNT IdbandoEqualThis, BoolNT ScorrimentocompletatoEqualThis)
		{
			GraduatoriaBandoScorrimentoCollection GraduatoriaBandoScorrimentoCollectionTemp = GraduatoriaBandoScorrimentoDAL.Find(_dbProviderObj, IdbandoEqualThis, ScorrimentocompletatoEqualThis);
			GraduatoriaBandoScorrimentoCollectionTemp.Provider = this;
			return GraduatoriaBandoScorrimentoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_BANDO_SCORRIMENTO>
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
      <ID_BANDO>Equal</ID_BANDO>
      <SCORRIMENTO_COMPLETATO>Equal</SCORRIMENTO_COMPLETATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_BANDO_SCORRIMENTO>
*/
