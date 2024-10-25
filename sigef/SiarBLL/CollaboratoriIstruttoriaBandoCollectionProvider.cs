using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CollaboratoriIstruttoriaBando
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICollaboratoriIstruttoriaBandoProvider
	{
		int Save(CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj);
		int SaveCollection(CollaboratoriIstruttoriaBandoCollection collectionObj);
		int Delete(CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj);
		int DeleteCollection(CollaboratoriIstruttoriaBandoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CollaboratoriIstruttoriaBando
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CollaboratoriIstruttoriaBando: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.IntNT _IdOperatoreInserimento;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		[NonSerialized] private ICollaboratoriIstruttoriaBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriIstruttoriaBandoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CollaboratoriIstruttoriaBando()
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
		/// Corrisponde al campo:ID_OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreInserimento
		{
			get { return _IdOperatoreInserimento; }
			set {
				if (IdOperatoreInserimento != value)
				{
					_IdOperatoreInserimento = value;
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
	/// Summary description for CollaboratoriIstruttoriaBandoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CollaboratoriIstruttoriaBandoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CollaboratoriIstruttoriaBandoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CollaboratoriIstruttoriaBando) info.GetValue(i.ToString(),typeof(CollaboratoriIstruttoriaBando)));
			}
		}

		//Costruttore
		public CollaboratoriIstruttoriaBandoCollection()
		{
			this.ItemType = typeof(CollaboratoriIstruttoriaBando);
		}

		//Costruttore con provider
		public CollaboratoriIstruttoriaBandoCollection(ICollaboratoriIstruttoriaBandoProvider providerObj)
		{
			this.ItemType = typeof(CollaboratoriIstruttoriaBando);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CollaboratoriIstruttoriaBando this[int index]
		{
			get { return (CollaboratoriIstruttoriaBando)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CollaboratoriIstruttoriaBandoCollection GetChanges()
		{
			return (CollaboratoriIstruttoriaBandoCollection) base.GetChanges();
		}

		[NonSerialized] private ICollaboratoriIstruttoriaBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICollaboratoriIstruttoriaBandoProvider Provider
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
		public int Add(CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			if (CollaboratoriIstruttoriaBandoObj.Provider == null) CollaboratoriIstruttoriaBandoObj.Provider = this.Provider;
			return base.Add(CollaboratoriIstruttoriaBandoObj);
		}

		//AddCollection
		public void AddCollection(CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionObj)
		{
			foreach (CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj in CollaboratoriIstruttoriaBandoCollectionObj)
				this.Add(CollaboratoriIstruttoriaBandoObj);
		}

		//Insert
		public void Insert(int index, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			if (CollaboratoriIstruttoriaBandoObj.Provider == null) CollaboratoriIstruttoriaBandoObj.Provider = this.Provider;
			base.Insert(index, CollaboratoriIstruttoriaBandoObj);
		}

		//CollectionGetById
		public CollaboratoriIstruttoriaBando CollectionGetById(NullTypes.IntNT IdValue)
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
		public CollaboratoriIstruttoriaBandoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdUtenteEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, 
NullTypes.IntNT IdOperatoreInserimentoEqualThis)
		{
			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionTemp = new CollaboratoriIstruttoriaBandoCollection();
			foreach (CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoItem in this)
			{
				if (((IdEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.Id != null) && (CollaboratoriIstruttoriaBandoItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.IdBando != null) && (CollaboratoriIstruttoriaBandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.IdUtente != null) && (CollaboratoriIstruttoriaBandoItem.IdUtente.Value == IdUtenteEqualThis.Value))) && 
((AttivoEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.Attivo != null) && (CollaboratoriIstruttoriaBandoItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.DataInizio != null) && (CollaboratoriIstruttoriaBandoItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.DataFine != null) && (CollaboratoriIstruttoriaBandoItem.DataFine.Value == DataFineEqualThis.Value))) && 
((IdOperatoreInserimentoEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.IdOperatoreInserimento != null) && (CollaboratoriIstruttoriaBandoItem.IdOperatoreInserimento.Value == IdOperatoreInserimentoEqualThis.Value))))
				{
					CollaboratoriIstruttoriaBandoCollectionTemp.Add(CollaboratoriIstruttoriaBandoItem);
				}
			}
			return CollaboratoriIstruttoriaBandoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CollaboratoriIstruttoriaBandoCollection Filter(NullTypes.IntNT IdBandoEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionTemp = new CollaboratoriIstruttoriaBandoCollection();
			foreach (CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.IdBando != null) && (CollaboratoriIstruttoriaBandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((AttivoEqualThis == null) || ((CollaboratoriIstruttoriaBandoItem.Attivo != null) && (CollaboratoriIstruttoriaBandoItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					CollaboratoriIstruttoriaBandoCollectionTemp.Add(CollaboratoriIstruttoriaBandoItem);
				}
			}
			return CollaboratoriIstruttoriaBandoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CollaboratoriIstruttoriaBandoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CollaboratoriIstruttoriaBandoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CollaboratoriIstruttoriaBandoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", CollaboratoriIstruttoriaBandoObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CollaboratoriIstruttoriaBandoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", CollaboratoriIstruttoriaBandoObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", CollaboratoriIstruttoriaBandoObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", CollaboratoriIstruttoriaBandoObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreInserimento", CollaboratoriIstruttoriaBandoObj.IdOperatoreInserimento);
		}
		//Insert
		private static int Insert(DbProvider db, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoInsert", new string[] {"IdUtente", "IdBando", 
"Attivo", "DataInizio", "DataFine", 
"IdOperatoreInserimento", }, new string[] {"int", "int", 
"bool", "DateTime", "DateTime", 
"int", },"");
				CompileIUCmd(false, insertCmd,CollaboratoriIstruttoriaBandoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CollaboratoriIstruttoriaBandoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriIstruttoriaBandoObj.IsDirty = false;
				CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoUpdate", new string[] {"IdUtente", "Id", "IdBando", 
"Attivo", "DataInizio", "DataFine", 
"IdOperatoreInserimento", }, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int", },"");
				CompileIUCmd(true, updateCmd,CollaboratoriIstruttoriaBandoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriIstruttoriaBandoObj.IsDirty = false;
				CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			switch (CollaboratoriIstruttoriaBandoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CollaboratoriIstruttoriaBandoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CollaboratoriIstruttoriaBandoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CollaboratoriIstruttoriaBandoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoUpdate", new string[] {"IdUtente", "Id", "IdBando", 
"Attivo", "DataInizio", "DataFine", 
"IdOperatoreInserimento", }, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoInsert", new string[] {"IdUtente", "IdBando", 
"Attivo", "DataInizio", "DataFine", 
"IdOperatoreInserimento", }, new string[] {"int", "int", 
"bool", "DateTime", "DateTime", 
"int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriIstruttoriaBandoCollectionObj.Count; i++)
				{
					switch (CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CollaboratoriIstruttoriaBandoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CollaboratoriIstruttoriaBandoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CollaboratoriIstruttoriaBandoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CollaboratoriIstruttoriaBandoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CollaboratoriIstruttoriaBandoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriIstruttoriaBandoCollectionObj.Count; i++)
				{
					if ((CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsDirty = false;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsPersistent = true;
					}
					if ((CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsDirty = false;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj)
		{
			int returnValue = 0;
			if (CollaboratoriIstruttoriaBandoObj.IsPersistent) 
			{
				returnValue = Delete(db, CollaboratoriIstruttoriaBandoObj.Id);
			}
			CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CollaboratoriIstruttoriaBandoObj.IsDirty = false;
			CollaboratoriIstruttoriaBandoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CollaboratoriIstruttoriaBandoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CollaboratoriIstruttoriaBandoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CollaboratoriIstruttoriaBandoCollectionObj.Count; i++)
				{
					if ((CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CollaboratoriIstruttoriaBandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsDirty = false;
						CollaboratoriIstruttoriaBandoCollectionObj[i].IsPersistent = false;
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
		public static CollaboratoriIstruttoriaBando GetById(DbProvider db, int IdValue)
		{
			CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCollaboratoriIstruttoriaBandoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CollaboratoriIstruttoriaBandoObj = GetFromDatareader(db);
				CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriIstruttoriaBandoObj.IsDirty = false;
				CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
			}
			db.Close();
			return CollaboratoriIstruttoriaBandoObj;
		}

		//getFromDatareader
		public static CollaboratoriIstruttoriaBando GetFromDatareader(DbProvider db)
		{
			CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj = new CollaboratoriIstruttoriaBando();
			CollaboratoriIstruttoriaBandoObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			CollaboratoriIstruttoriaBandoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CollaboratoriIstruttoriaBandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CollaboratoriIstruttoriaBandoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			CollaboratoriIstruttoriaBandoObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			CollaboratoriIstruttoriaBandoObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			CollaboratoriIstruttoriaBandoObj.IdOperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INSERIMENTO"]);
			CollaboratoriIstruttoriaBandoObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			CollaboratoriIstruttoriaBandoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			CollaboratoriIstruttoriaBandoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CollaboratoriIstruttoriaBandoObj.IsDirty = false;
			CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
			return CollaboratoriIstruttoriaBandoObj;
		}

		//Find Select

		public static CollaboratoriIstruttoriaBandoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreInserimentoEqualThis)

		{

			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionObj = new CollaboratoriIstruttoriaBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratoriistruttoriabandofindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdUtenteequalthis", 
"Attivoequalthis", "DataInizioequalthis", "DataFineequalthis", 
"IdOperatoreInserimentoequalthis"}, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreInserimentoequalthis", IdOperatoreInserimentoEqualThis);
			CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriIstruttoriaBandoObj = GetFromDatareader(db);
				CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriIstruttoriaBandoObj.IsDirty = false;
				CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
				CollaboratoriIstruttoriaBandoCollectionObj.Add(CollaboratoriIstruttoriaBandoObj);
			}
			db.Close();
			return CollaboratoriIstruttoriaBandoCollectionObj;
		}

		//Find Find

		public static CollaboratoriIstruttoriaBandoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionObj = new CollaboratoriIstruttoriaBandoCollection();

			IDbCommand findCmd = db.InitCmd("Zcollaboratoriistruttoriabandofindfind", new string[] {"IdBandoequalthis", "IdUtenteequalthis", "Attivoequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CollaboratoriIstruttoriaBandoObj = GetFromDatareader(db);
				CollaboratoriIstruttoriaBandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CollaboratoriIstruttoriaBandoObj.IsDirty = false;
				CollaboratoriIstruttoriaBandoObj.IsPersistent = true;
				CollaboratoriIstruttoriaBandoCollectionObj.Add(CollaboratoriIstruttoriaBandoObj);
			}
			db.Close();
			return CollaboratoriIstruttoriaBandoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CollaboratoriIstruttoriaBandoCollectionProvider:ICollaboratoriIstruttoriaBandoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CollaboratoriIstruttoriaBandoCollectionProvider : ICollaboratoriIstruttoriaBandoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CollaboratoriIstruttoriaBando
		protected CollaboratoriIstruttoriaBandoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CollaboratoriIstruttoriaBandoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CollaboratoriIstruttoriaBandoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CollaboratoriIstruttoriaBandoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdutenteEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input collaboratoriistruttoriabandoCollectionObj - non popola la collection
		public CollaboratoriIstruttoriaBandoCollectionProvider(CollaboratoriIstruttoriaBandoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CollaboratoriIstruttoriaBandoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CollaboratoriIstruttoriaBandoCollection(this);
		}

		//Get e Set
		public CollaboratoriIstruttoriaBandoCollection CollectionObj
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
		public int SaveCollection(CollaboratoriIstruttoriaBandoCollection collectionObj)
		{
			return CollaboratoriIstruttoriaBandoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CollaboratoriIstruttoriaBando collaboratoriistruttoriabandoObj)
		{
			return CollaboratoriIstruttoriaBandoDAL.Save(_dbProviderObj, collaboratoriistruttoriabandoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CollaboratoriIstruttoriaBandoCollection collectionObj)
		{
			return CollaboratoriIstruttoriaBandoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CollaboratoriIstruttoriaBando collaboratoriistruttoriabandoObj)
		{
			return CollaboratoriIstruttoriaBandoDAL.Delete(_dbProviderObj, collaboratoriistruttoriabandoObj);
		}

		//getById
		public CollaboratoriIstruttoriaBando GetById(IntNT IdValue)
		{
			CollaboratoriIstruttoriaBando CollaboratoriIstruttoriaBandoTemp = CollaboratoriIstruttoriaBandoDAL.GetById(_dbProviderObj, IdValue);
			if (CollaboratoriIstruttoriaBandoTemp!=null) CollaboratoriIstruttoriaBandoTemp.Provider = this;
			return CollaboratoriIstruttoriaBandoTemp;
		}

		//Select: popola la collection
		public CollaboratoriIstruttoriaBandoCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, 
IntNT IdoperatoreinserimentoEqualThis)
		{
			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionTemp = CollaboratoriIstruttoriaBandoDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdutenteEqualThis, 
AttivoEqualThis, DatainizioEqualThis, DatafineEqualThis, 
IdoperatoreinserimentoEqualThis);
			CollaboratoriIstruttoriaBandoCollectionTemp.Provider = this;
			return CollaboratoriIstruttoriaBandoCollectionTemp;
		}

		//Find: popola la collection
		public CollaboratoriIstruttoriaBandoCollection Find(IntNT IdbandoEqualThis, IntNT IdutenteEqualThis, BoolNT AttivoEqualThis)
		{
			CollaboratoriIstruttoriaBandoCollection CollaboratoriIstruttoriaBandoCollectionTemp = CollaboratoriIstruttoriaBandoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdutenteEqualThis, AttivoEqualThis);
			CollaboratoriIstruttoriaBandoCollectionTemp.Provider = this;
			return CollaboratoriIstruttoriaBandoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_ISTRUTTORIA_BANDO>
  <ViewName>vCOLLABORATORI_ISTRUTTORIA_BANDO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ATTIVO, ID">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_UTENTE>Equal</ID_UTENTE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
      <ATTIVO>Equal</ATTIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_ISTRUTTORIA_BANDO>
*/
