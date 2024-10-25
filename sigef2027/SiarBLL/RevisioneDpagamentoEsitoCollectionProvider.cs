using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RevisioneDpagamentoEsito
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRevisioneDpagamentoEsitoProvider
	{
		int Save(RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj);
		int SaveCollection(RevisioneDpagamentoEsitoCollection collectionObj);
		int Delete(RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj);
		int DeleteCollection(RevisioneDpagamentoEsitoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RevisioneDpagamentoEsito
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RevisioneDpagamentoEsito: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdVldStep;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Note;
		private NullTypes.BoolNT _EscludiDaComunicazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.BoolNT _EsitoPositivo;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IRevisioneDpagamentoEsitoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevisioneDpagamentoEsitoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RevisioneDpagamentoEsito()
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
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VLD_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVldStep
		{
			get { return _IdVldStep; }
			set {
				if (IdVldStep != value)
				{
					_IdVldStep = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsito
		{
			get { return _CodEsito; }
			set {
				if (CodEsito != value)
				{
					_CodEsito = value;
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
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(5000)
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

		/// <summary>
		/// Corrisponde al campo:ESCLUDI_DA_COMUNICAZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT EscludiDaComunicazione
		{
			get { return _EscludiDaComunicazione; }
			set {
				if (EscludiDaComunicazione != value)
				{
					_EscludiDaComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivo
		{
			get { return _EsitoPositivo; }
			set {
				if (EsitoPositivo != value)
				{
					_EsitoPositivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Ordine
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
	/// Summary description for RevisioneDpagamentoEsitoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevisioneDpagamentoEsitoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RevisioneDpagamentoEsitoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RevisioneDpagamentoEsito) info.GetValue(i.ToString(),typeof(RevisioneDpagamentoEsito)));
			}
		}

		//Costruttore
		public RevisioneDpagamentoEsitoCollection()
		{
			this.ItemType = typeof(RevisioneDpagamentoEsito);
		}

		//Costruttore con provider
		public RevisioneDpagamentoEsitoCollection(IRevisioneDpagamentoEsitoProvider providerObj)
		{
			this.ItemType = typeof(RevisioneDpagamentoEsito);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RevisioneDpagamentoEsito this[int index]
		{
			get { return (RevisioneDpagamentoEsito)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RevisioneDpagamentoEsitoCollection GetChanges()
		{
			return (RevisioneDpagamentoEsitoCollection) base.GetChanges();
		}

		[NonSerialized] private IRevisioneDpagamentoEsitoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevisioneDpagamentoEsitoProvider Provider
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
		public int Add(RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			if (RevisioneDpagamentoEsitoObj.Provider == null) RevisioneDpagamentoEsitoObj.Provider = this.Provider;
			return base.Add(RevisioneDpagamentoEsitoObj);
		}

		//AddCollection
		public void AddCollection(RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionObj)
		{
			foreach (RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj in RevisioneDpagamentoEsitoCollectionObj)
				this.Add(RevisioneDpagamentoEsitoObj);
		}

		//Insert
		public void Insert(int index, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			if (RevisioneDpagamentoEsitoObj.Provider == null) RevisioneDpagamentoEsitoObj.Provider = this.Provider;
			base.Insert(index, RevisioneDpagamentoEsitoObj);
		}

		//CollectionGetById
		public RevisioneDpagamentoEsito CollectionGetById(NullTypes.IntNT IdValue)
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
		public RevisioneDpagamentoEsitoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdVldStepEqualThis, NullTypes.StringNT CodEsitoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.BoolNT EscludiDaComunicazioneEqualThis)
		{
			RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionTemp = new RevisioneDpagamentoEsitoCollection();
			foreach (RevisioneDpagamentoEsito RevisioneDpagamentoEsitoItem in this)
			{
				if (((IdEqualThis == null) || ((RevisioneDpagamentoEsitoItem.Id != null) && (RevisioneDpagamentoEsitoItem.Id.Value == IdEqualThis.Value))) && ((IdLottoEqualThis == null) || ((RevisioneDpagamentoEsitoItem.IdLotto != null) && (RevisioneDpagamentoEsitoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((RevisioneDpagamentoEsitoItem.IdDomandaPagamento != null) && (RevisioneDpagamentoEsitoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdVldStepEqualThis == null) || ((RevisioneDpagamentoEsitoItem.IdVldStep != null) && (RevisioneDpagamentoEsitoItem.IdVldStep.Value == IdVldStepEqualThis.Value))) && ((CodEsitoEqualThis == null) || ((RevisioneDpagamentoEsitoItem.CodEsito != null) && (RevisioneDpagamentoEsitoItem.CodEsito.Value == CodEsitoEqualThis.Value))) && ((DataEqualThis == null) || ((RevisioneDpagamentoEsitoItem.Data != null) && (RevisioneDpagamentoEsitoItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((RevisioneDpagamentoEsitoItem.Operatore != null) && (RevisioneDpagamentoEsitoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((NoteEqualThis == null) || ((RevisioneDpagamentoEsitoItem.Note != null) && (RevisioneDpagamentoEsitoItem.Note.Value == NoteEqualThis.Value))) && ((EscludiDaComunicazioneEqualThis == null) || ((RevisioneDpagamentoEsitoItem.EscludiDaComunicazione != null) && (RevisioneDpagamentoEsitoItem.EscludiDaComunicazione.Value == EscludiDaComunicazioneEqualThis.Value))))
				{
					RevisioneDpagamentoEsitoCollectionTemp.Add(RevisioneDpagamentoEsitoItem);
				}
			}
			return RevisioneDpagamentoEsitoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RevisioneDpagamentoEsitoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RevisioneDpagamentoEsitoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", RevisioneDpagamentoEsitoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", RevisioneDpagamentoEsitoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", RevisioneDpagamentoEsitoObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVldStep", RevisioneDpagamentoEsitoObj.IdVldStep);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", RevisioneDpagamentoEsitoObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", RevisioneDpagamentoEsitoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", RevisioneDpagamentoEsitoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", RevisioneDpagamentoEsitoObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "EscludiDaComunicazione", RevisioneDpagamentoEsitoObj.EscludiDaComunicazione);
		}
		//Insert
		private static int Insert(DbProvider db, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoInsert", new string[] {"IdLotto", "IdDomandaPagamento", 
"IdVldStep", "CodEsito", "Data", 
"Operatore", "Note", "EscludiDaComunicazione", 
}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"int", "string", "bool", 
},"");
				CompileIUCmd(false, insertCmd,RevisioneDpagamentoEsitoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RevisioneDpagamentoEsitoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				RevisioneDpagamentoEsitoObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
				}
				RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDpagamentoEsitoObj.IsDirty = false;
				RevisioneDpagamentoEsitoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoUpdate", new string[] {"Id", "IdLotto", "IdDomandaPagamento", 
"IdVldStep", "CodEsito", "Data", 
"Operatore", "Note", "EscludiDaComunicazione", 
}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"int", "string", "bool", 
},"");
				CompileIUCmd(true, updateCmd,RevisioneDpagamentoEsitoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDpagamentoEsitoObj.IsDirty = false;
				RevisioneDpagamentoEsitoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			switch (RevisioneDpagamentoEsitoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RevisioneDpagamentoEsitoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RevisioneDpagamentoEsitoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RevisioneDpagamentoEsitoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoUpdate", new string[] {"Id", "IdLotto", "IdDomandaPagamento", 
"IdVldStep", "CodEsito", "Data", 
"Operatore", "Note", "EscludiDaComunicazione", 
}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"int", "string", "bool", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoInsert", new string[] {"IdLotto", "IdDomandaPagamento", 
"IdVldStep", "CodEsito", "Data", 
"Operatore", "Note", "EscludiDaComunicazione", 
}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"int", "string", "bool", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < RevisioneDpagamentoEsitoCollectionObj.Count; i++)
				{
					switch (RevisioneDpagamentoEsitoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RevisioneDpagamentoEsitoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RevisioneDpagamentoEsitoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									RevisioneDpagamentoEsitoCollectionObj[i].EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RevisioneDpagamentoEsitoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RevisioneDpagamentoEsitoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)RevisioneDpagamentoEsitoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RevisioneDpagamentoEsitoCollectionObj.Count; i++)
				{
					if ((RevisioneDpagamentoEsitoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevisioneDpagamentoEsitoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevisioneDpagamentoEsitoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RevisioneDpagamentoEsitoCollectionObj[i].IsDirty = false;
						RevisioneDpagamentoEsitoCollectionObj[i].IsPersistent = true;
					}
					if ((RevisioneDpagamentoEsitoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RevisioneDpagamentoEsitoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevisioneDpagamentoEsitoCollectionObj[i].IsDirty = false;
						RevisioneDpagamentoEsitoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj)
		{
			int returnValue = 0;
			if (RevisioneDpagamentoEsitoObj.IsPersistent) 
			{
				returnValue = Delete(db, RevisioneDpagamentoEsitoObj.Id);
			}
			RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RevisioneDpagamentoEsitoObj.IsDirty = false;
			RevisioneDpagamentoEsitoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < RevisioneDpagamentoEsitoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", RevisioneDpagamentoEsitoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RevisioneDpagamentoEsitoCollectionObj.Count; i++)
				{
					if ((RevisioneDpagamentoEsitoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevisioneDpagamentoEsitoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevisioneDpagamentoEsitoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevisioneDpagamentoEsitoCollectionObj[i].IsDirty = false;
						RevisioneDpagamentoEsitoCollectionObj[i].IsPersistent = false;
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
		public static RevisioneDpagamentoEsito GetById(DbProvider db, int IdValue)
		{
			RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRevisioneDpagamentoEsitoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RevisioneDpagamentoEsitoObj = GetFromDatareader(db);
				RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDpagamentoEsitoObj.IsDirty = false;
				RevisioneDpagamentoEsitoObj.IsPersistent = true;
			}
			db.Close();
			return RevisioneDpagamentoEsitoObj;
		}

		//getFromDatareader
		public static RevisioneDpagamentoEsito GetFromDatareader(DbProvider db)
		{
			RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj = new RevisioneDpagamentoEsito();
			RevisioneDpagamentoEsitoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			RevisioneDpagamentoEsitoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			RevisioneDpagamentoEsitoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			RevisioneDpagamentoEsitoObj.IdVldStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VLD_STEP"]);
			RevisioneDpagamentoEsitoObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			RevisioneDpagamentoEsitoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			RevisioneDpagamentoEsitoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			RevisioneDpagamentoEsitoObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			RevisioneDpagamentoEsitoObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
			RevisioneDpagamentoEsitoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RevisioneDpagamentoEsitoObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			RevisioneDpagamentoEsitoObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
			RevisioneDpagamentoEsitoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["Ordine"]);
			RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RevisioneDpagamentoEsitoObj.IsDirty = false;
			RevisioneDpagamentoEsitoObj.IsPersistent = true;
			return RevisioneDpagamentoEsitoObj;
		}

		//Find Select

		public static RevisioneDpagamentoEsitoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdVldStepEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.BoolNT EscludiDaComunicazioneEqualThis)

		{

			RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionObj = new RevisioneDpagamentoEsitoCollection();

			IDbCommand findCmd = db.InitCmd("Zrevisionedpagamentoesitofindselect", new string[] {"Idequalthis", "IdLottoequalthis", "IdDomandaPagamentoequalthis", 
"IdVldStepequalthis", "CodEsitoequalthis", "Dataequalthis", 
"Operatoreequalthis", "Noteequalthis", "EscludiDaComunicazioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"int", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVldStepequalthis", IdVldStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EscludiDaComunicazioneequalthis", EscludiDaComunicazioneEqualThis);
			RevisioneDpagamentoEsito RevisioneDpagamentoEsitoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevisioneDpagamentoEsitoObj = GetFromDatareader(db);
				RevisioneDpagamentoEsitoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDpagamentoEsitoObj.IsDirty = false;
				RevisioneDpagamentoEsitoObj.IsPersistent = true;
				RevisioneDpagamentoEsitoCollectionObj.Add(RevisioneDpagamentoEsitoObj);
			}
			db.Close();
			return RevisioneDpagamentoEsitoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RevisioneDpagamentoEsitoCollectionProvider:IRevisioneDpagamentoEsitoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevisioneDpagamentoEsitoCollectionProvider : IRevisioneDpagamentoEsitoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RevisioneDpagamentoEsito
		protected RevisioneDpagamentoEsitoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RevisioneDpagamentoEsitoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RevisioneDpagamentoEsitoCollection(this);
		}

		//Costruttore3: ha in input revisionedpagamentoesitoCollectionObj - non popola la collection
		public RevisioneDpagamentoEsitoCollectionProvider(RevisioneDpagamentoEsitoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RevisioneDpagamentoEsitoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RevisioneDpagamentoEsitoCollection(this);
		}

		//Get e Set
		public RevisioneDpagamentoEsitoCollection CollectionObj
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
		public int SaveCollection(RevisioneDpagamentoEsitoCollection collectionObj)
		{
			return RevisioneDpagamentoEsitoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RevisioneDpagamentoEsito revisionedpagamentoesitoObj)
		{
			return RevisioneDpagamentoEsitoDAL.Save(_dbProviderObj, revisionedpagamentoesitoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RevisioneDpagamentoEsitoCollection collectionObj)
		{
			return RevisioneDpagamentoEsitoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RevisioneDpagamentoEsito revisionedpagamentoesitoObj)
		{
			return RevisioneDpagamentoEsitoDAL.Delete(_dbProviderObj, revisionedpagamentoesitoObj);
		}

		//getById
		public RevisioneDpagamentoEsito GetById(IntNT IdValue)
		{
			RevisioneDpagamentoEsito RevisioneDpagamentoEsitoTemp = RevisioneDpagamentoEsitoDAL.GetById(_dbProviderObj, IdValue);
			if (RevisioneDpagamentoEsitoTemp!=null) RevisioneDpagamentoEsitoTemp.Provider = this;
			return RevisioneDpagamentoEsitoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RevisioneDpagamentoEsitoCollection Select(IntNT IdEqualThis, IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdvldstepEqualThis, StringNT CodesitoEqualThis, DatetimeNT DataEqualThis, 
IntNT OperatoreEqualThis, StringNT NoteEqualThis, BoolNT EscludidacomunicazioneEqualThis)
		{
			RevisioneDpagamentoEsitoCollection RevisioneDpagamentoEsitoCollectionTemp = RevisioneDpagamentoEsitoDAL.Select(_dbProviderObj, IdEqualThis, IdlottoEqualThis, IddomandapagamentoEqualThis, 
IdvldstepEqualThis, CodesitoEqualThis, DataEqualThis, 
OperatoreEqualThis, NoteEqualThis, EscludidacomunicazioneEqualThis);
			RevisioneDpagamentoEsitoCollectionTemp.Provider = this;
			return RevisioneDpagamentoEsitoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REVISIONE_DPAGAMENTO_ESITO>
  <ViewName>vREVISIONE_DPAGAMENTO_ESITO</ViewName>
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
</REVISIONE_DPAGAMENTO_ESITO>
*/
