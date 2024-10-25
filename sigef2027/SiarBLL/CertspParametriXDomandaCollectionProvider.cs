using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspParametriXDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspParametriXDomandaProvider
	{
		int Save(CertspParametriXDomanda CertspParametriXDomandaObj);
		int SaveCollection(CertspParametriXDomandaCollection collectionObj);
		int Delete(CertspParametriXDomanda CertspParametriXDomandaObj);
		int DeleteCollection(CertspParametriXDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspParametriXDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspParametriXDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdCertspDomandaPagamento;
		private NullTypes.IntNT _IdParametro;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _Punteggio;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Manuale;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.IntNT _IdDomandaPagamento;
		[NonSerialized] private ICertspParametriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriXDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspParametriXDomanda()
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
		/// Corrisponde al campo:ID_CERTSP_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCertspDomandaPagamento
		{
			get { return _IdCertspDomandaPagamento; }
			set {
				if (IdCertspDomandaPagamento != value)
				{
					_IdCertspDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PARAMETRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdParametro
		{
			get { return _IdParametro; }
			set {
				if (IdParametro != value)
				{
					_IdParametro = value;
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
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
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
		/// Corrisponde al campo:MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Manuale
		{
			get { return _Manuale; }
			set {
				if (Manuale != value)
				{
					_Manuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
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
	/// Summary description for CertspParametriXDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriXDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspParametriXDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspParametriXDomanda) info.GetValue(i.ToString(),typeof(CertspParametriXDomanda)));
			}
		}

		//Costruttore
		public CertspParametriXDomandaCollection()
		{
			this.ItemType = typeof(CertspParametriXDomanda);
		}

		//Costruttore con provider
		public CertspParametriXDomandaCollection(ICertspParametriXDomandaProvider providerObj)
		{
			this.ItemType = typeof(CertspParametriXDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspParametriXDomanda this[int index]
		{
			get { return (CertspParametriXDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspParametriXDomandaCollection GetChanges()
		{
			return (CertspParametriXDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspParametriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspParametriXDomandaProvider Provider
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
		public int Add(CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			if (CertspParametriXDomandaObj.Provider == null) CertspParametriXDomandaObj.Provider = this.Provider;
			return base.Add(CertspParametriXDomandaObj);
		}

		//AddCollection
		public void AddCollection(CertspParametriXDomandaCollection CertspParametriXDomandaCollectionObj)
		{
			foreach (CertspParametriXDomanda CertspParametriXDomandaObj in CertspParametriXDomandaCollectionObj)
				this.Add(CertspParametriXDomandaObj);
		}

		//Insert
		public void Insert(int index, CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			if (CertspParametriXDomandaObj.Provider == null) CertspParametriXDomandaObj.Provider = this.Provider;
			base.Insert(index, CertspParametriXDomandaObj);
		}

		//CollectionGetById
		public CertspParametriXDomanda CollectionGetById(NullTypes.IntNT IdValue)
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
		public CertspParametriXDomandaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdCertspDomandaPagamentoEqualThis, NullTypes.IntNT IdParametroEqualThis, 
NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT PunteggioEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis, 
NullTypes.IntNT OperatoreEqualThis)
		{
			CertspParametriXDomandaCollection CertspParametriXDomandaCollectionTemp = new CertspParametriXDomandaCollection();
			foreach (CertspParametriXDomanda CertspParametriXDomandaItem in this)
			{
				if (((IdEqualThis == null) || ((CertspParametriXDomandaItem.Id != null) && (CertspParametriXDomandaItem.Id.Value == IdEqualThis.Value))) && ((IdCertspDomandaPagamentoEqualThis == null) || ((CertspParametriXDomandaItem.IdCertspDomandaPagamento != null) && (CertspParametriXDomandaItem.IdCertspDomandaPagamento.Value == IdCertspDomandaPagamentoEqualThis.Value))) && ((IdParametroEqualThis == null) || ((CertspParametriXDomandaItem.IdParametro != null) && (CertspParametriXDomandaItem.IdParametro.Value == IdParametroEqualThis.Value))) && 
((IdLottoEqualThis == null) || ((CertspParametriXDomandaItem.IdLotto != null) && (CertspParametriXDomandaItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((PunteggioEqualThis == null) || ((CertspParametriXDomandaItem.Punteggio != null) && (CertspParametriXDomandaItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((CertspParametriXDomandaItem.DataValutazione != null) && (CertspParametriXDomandaItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CertspParametriXDomandaItem.Operatore != null) && (CertspParametriXDomandaItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					CertspParametriXDomandaCollectionTemp.Add(CertspParametriXDomandaItem);
				}
			}
			return CertspParametriXDomandaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspParametriXDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspParametriXDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspParametriXDomanda CertspParametriXDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspParametriXDomandaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdCertspDomandaPagamento", CertspParametriXDomandaObj.IdCertspDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdParametro", CertspParametriXDomandaObj.IdParametro);
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", CertspParametriXDomandaObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "Punteggio", CertspParametriXDomandaObj.Punteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", CertspParametriXDomandaObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspParametriXDomandaObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriXDomandaInsert", new string[] {"IdCertspDomandaPagamento", "IdParametro", 
"IdLotto", "Punteggio", "DataValutazione", 
"Operatore", }, new string[] {"int", "int", 
"int", "int", "DateTime", 
"int", },"");
				CompileIUCmd(false, insertCmd,CertspParametriXDomandaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspParametriXDomandaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXDomandaObj.IsDirty = false;
				CertspParametriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriXDomandaUpdate", new string[] {"Id", "IdCertspDomandaPagamento", "IdParametro", 
"IdLotto", "Punteggio", "DataValutazione", 
"Operatore", }, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"int", },"");
				CompileIUCmd(true, updateCmd,CertspParametriXDomandaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXDomandaObj.IsDirty = false;
				CertspParametriXDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			switch (CertspParametriXDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspParametriXDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspParametriXDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspParametriXDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspParametriXDomandaCollection CertspParametriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspParametriXDomandaUpdate", new string[] {"Id", "IdCertspDomandaPagamento", "IdParametro", 
"IdLotto", "Punteggio", "DataValutazione", 
"Operatore", }, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspParametriXDomandaInsert", new string[] {"IdCertspDomandaPagamento", "IdParametro", 
"IdLotto", "Punteggio", "DataValutazione", 
"Operatore", }, new string[] {"int", "int", 
"int", "int", "DateTime", 
"int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXDomandaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriXDomandaCollectionObj.Count; i++)
				{
					switch (CertspParametriXDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspParametriXDomandaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspParametriXDomandaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspParametriXDomandaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspParametriXDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspParametriXDomandaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspParametriXDomandaCollectionObj.Count; i++)
				{
					if ((CertspParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspParametriXDomandaCollectionObj[i].IsDirty = false;
						CertspParametriXDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((CertspParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriXDomandaCollectionObj[i].IsDirty = false;
						CertspParametriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspParametriXDomanda CertspParametriXDomandaObj)
		{
			int returnValue = 0;
			if (CertspParametriXDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspParametriXDomandaObj.Id);
			}
			CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspParametriXDomandaObj.IsDirty = false;
			CertspParametriXDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXDomandaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspParametriXDomandaCollection CertspParametriXDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspParametriXDomandaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspParametriXDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspParametriXDomandaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspParametriXDomandaCollectionObj.Count; i++)
				{
					if ((CertspParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspParametriXDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspParametriXDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspParametriXDomandaCollectionObj[i].IsDirty = false;
						CertspParametriXDomandaCollectionObj[i].IsPersistent = false;
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
		public static CertspParametriXDomanda GetById(DbProvider db, int IdValue)
		{
			CertspParametriXDomanda CertspParametriXDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspParametriXDomandaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspParametriXDomandaObj = GetFromDatareader(db);
				CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXDomandaObj.IsDirty = false;
				CertspParametriXDomandaObj.IsPersistent = true;
			}
			db.Close();
			return CertspParametriXDomandaObj;
		}

		//getFromDatareader
		public static CertspParametriXDomanda GetFromDatareader(DbProvider db)
		{
			CertspParametriXDomanda CertspParametriXDomandaObj = new CertspParametriXDomanda();
			CertspParametriXDomandaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspParametriXDomandaObj.IdCertspDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CERTSP_DOMANDA_PAGAMENTO"]);
			CertspParametriXDomandaObj.IdParametro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PARAMETRO"]);
			CertspParametriXDomandaObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			CertspParametriXDomandaObj.Punteggio = new SiarLibrary.NullTypes.IntNT(db.DataReader["PUNTEGGIO"]);
			CertspParametriXDomandaObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			CertspParametriXDomandaObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CertspParametriXDomandaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CertspParametriXDomandaObj.Manuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MANUALE"]);
			CertspParametriXDomandaObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			CertspParametriXDomandaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspParametriXDomandaObj.IsDirty = false;
			CertspParametriXDomandaObj.IsPersistent = true;
			return CertspParametriXDomandaObj;
		}

		//Find Select

		public static CertspParametriXDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdCertspDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, 
SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT PunteggioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			CertspParametriXDomandaCollection CertspParametriXDomandaCollectionObj = new CertspParametriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametrixdomandafindselect", new string[] {"Idequalthis", "IdCertspDomandaPagamentoequalthis", "IdParametroequalthis", 
"IdLottoequalthis", "Punteggioequalthis", "DataValutazioneequalthis", 
"Operatoreequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCertspDomandaPagamentoequalthis", IdCertspDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			CertspParametriXDomanda CertspParametriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriXDomandaObj = GetFromDatareader(db);
				CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXDomandaObj.IsDirty = false;
				CertspParametriXDomandaObj.IsPersistent = true;
				CertspParametriXDomandaCollectionObj.Add(CertspParametriXDomandaObj);
			}
			db.Close();
			return CertspParametriXDomandaCollectionObj;
		}

		//Find Find

		public static CertspParametriXDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdParametroEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.BoolNT ManualeEqualThis)

		{

			CertspParametriXDomandaCollection CertspParametriXDomandaCollectionObj = new CertspParametriXDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspparametrixdomandafindfind", new string[] {"IdDomandaPagamentoequalthis", "IdParametroequalthis", "IdLottoequalthis", 
"Manualeequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdParametroequalthis", IdParametroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Manualeequalthis", ManualeEqualThis);
			CertspParametriXDomanda CertspParametriXDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspParametriXDomandaObj = GetFromDatareader(db);
				CertspParametriXDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspParametriXDomandaObj.IsDirty = false;
				CertspParametriXDomandaObj.IsPersistent = true;
				CertspParametriXDomandaCollectionObj.Add(CertspParametriXDomandaObj);
			}
			db.Close();
			return CertspParametriXDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspParametriXDomandaCollectionProvider:ICertspParametriXDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspParametriXDomandaCollectionProvider : ICertspParametriXDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspParametriXDomanda
		protected CertspParametriXDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspParametriXDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspParametriXDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertspParametriXDomandaCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdparametroEqualThis, IntNT IdlottoEqualThis, 
BoolNT ManualeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, IdparametroEqualThis, IdlottoEqualThis, 
ManualeEqualThis);
		}

		//Costruttore3: ha in input certspparametrixdomandaCollectionObj - non popola la collection
		public CertspParametriXDomandaCollectionProvider(CertspParametriXDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspParametriXDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspParametriXDomandaCollection(this);
		}

		//Get e Set
		public CertspParametriXDomandaCollection CollectionObj
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
		public int SaveCollection(CertspParametriXDomandaCollection collectionObj)
		{
			return CertspParametriXDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspParametriXDomanda certspparametrixdomandaObj)
		{
			return CertspParametriXDomandaDAL.Save(_dbProviderObj, certspparametrixdomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspParametriXDomandaCollection collectionObj)
		{
			return CertspParametriXDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspParametriXDomanda certspparametrixdomandaObj)
		{
			return CertspParametriXDomandaDAL.Delete(_dbProviderObj, certspparametrixdomandaObj);
		}

		//getById
		public CertspParametriXDomanda GetById(IntNT IdValue)
		{
			CertspParametriXDomanda CertspParametriXDomandaTemp = CertspParametriXDomandaDAL.GetById(_dbProviderObj, IdValue);
			if (CertspParametriXDomandaTemp!=null) CertspParametriXDomandaTemp.Provider = this;
			return CertspParametriXDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspParametriXDomandaCollection Select(IntNT IdEqualThis, IntNT IdcertspdomandapagamentoEqualThis, IntNT IdparametroEqualThis, 
IntNT IdlottoEqualThis, IntNT PunteggioEqualThis, DatetimeNT DatavalutazioneEqualThis, 
IntNT OperatoreEqualThis)
		{
			CertspParametriXDomandaCollection CertspParametriXDomandaCollectionTemp = CertspParametriXDomandaDAL.Select(_dbProviderObj, IdEqualThis, IdcertspdomandapagamentoEqualThis, IdparametroEqualThis, 
IdlottoEqualThis, PunteggioEqualThis, DatavalutazioneEqualThis, 
OperatoreEqualThis);
			CertspParametriXDomandaCollectionTemp.Provider = this;
			return CertspParametriXDomandaCollectionTemp;
		}

		//Find: popola la collection
		public CertspParametriXDomandaCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdparametroEqualThis, IntNT IdlottoEqualThis, 
BoolNT ManualeEqualThis)
		{
			CertspParametriXDomandaCollection CertspParametriXDomandaCollectionTemp = CertspParametriXDomandaDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdparametroEqualThis, IdlottoEqualThis, 
ManualeEqualThis);
			CertspParametriXDomandaCollectionTemp.Provider = this;
			return CertspParametriXDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_PARAMETRI_X_DOMANDA>
  <ViewName>vCERTSP_PARAMETRI_X_DOMANDA</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <MANUALE>Equal</MANUALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_PARAMETRI_X_DOMANDA>
*/
