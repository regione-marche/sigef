using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AccorpamentoInvestimenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAccorpamentoInvestimentiProvider
	{
		int Save(AccorpamentoInvestimenti AccorpamentoInvestimentiObj);
		int SaveCollection(AccorpamentoInvestimentiCollection collectionObj);
		int Delete(AccorpamentoInvestimenti AccorpamentoInvestimentiObj);
		int DeleteCollection(AccorpamentoInvestimentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AccorpamentoInvestimenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AccorpamentoInvestimenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAccorpamentoInvestimenti;
		private NullTypes.StringNT _CfCreazione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdInvestimentoX;
		private NullTypes.IntNT _IdInvestimentoY;
		private NullTypes.StringNT _IstanzaPianoInvestimenti;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataCreazione;
		[NonSerialized] private IAccorpamentoInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAccorpamentoInvestimentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AccorpamentoInvestimenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ACCORPAMENTO_INVESTIMENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAccorpamentoInvestimenti
		{
			get { return _IdAccorpamentoInvestimenti; }
			set {
				if (IdAccorpamentoInvestimenti != value)
				{
					_IdAccorpamentoInvestimenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CREAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CfCreazione
		{
			get { return _CfCreazione; }
			set {
				if (CfCreazione != value)
				{
					_CfCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
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
		/// Corrisponde al campo:ID_INVESTIMENTO_X
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimentoX
		{
			get { return _IdInvestimentoX; }
			set {
				if (IdInvestimentoX != value)
				{
					_IdInvestimentoX = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO_Y
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimentoY
		{
			get { return _IdInvestimentoY; }
			set {
				if (IdInvestimentoY != value)
				{
					_IdInvestimentoY = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_PIANO_INVESTIMENTI
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaPianoInvestimenti
		{
			get { return _IstanzaPianoInvestimenti; }
			set {
				if (IstanzaPianoInvestimenti != value)
				{
					_IstanzaPianoInvestimenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
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
	/// Summary description for AccorpamentoInvestimentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AccorpamentoInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AccorpamentoInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AccorpamentoInvestimenti) info.GetValue(i.ToString(),typeof(AccorpamentoInvestimenti)));
			}
		}

		//Costruttore
		public AccorpamentoInvestimentiCollection()
		{
			this.ItemType = typeof(AccorpamentoInvestimenti);
		}

		//Costruttore con provider
		public AccorpamentoInvestimentiCollection(IAccorpamentoInvestimentiProvider providerObj)
		{
			this.ItemType = typeof(AccorpamentoInvestimenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AccorpamentoInvestimenti this[int index]
		{
			get { return (AccorpamentoInvestimenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AccorpamentoInvestimentiCollection GetChanges()
		{
			return (AccorpamentoInvestimentiCollection) base.GetChanges();
		}

		[NonSerialized] private IAccorpamentoInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAccorpamentoInvestimentiProvider Provider
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
		public int Add(AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			if (AccorpamentoInvestimentiObj.Provider == null) AccorpamentoInvestimentiObj.Provider = this.Provider;
			return base.Add(AccorpamentoInvestimentiObj);
		}

		//AddCollection
		public void AddCollection(AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionObj)
		{
			foreach (AccorpamentoInvestimenti AccorpamentoInvestimentiObj in AccorpamentoInvestimentiCollectionObj)
				this.Add(AccorpamentoInvestimentiObj);
		}

		//Insert
		public void Insert(int index, AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			if (AccorpamentoInvestimentiObj.Provider == null) AccorpamentoInvestimentiObj.Provider = this.Provider;
			base.Insert(index, AccorpamentoInvestimentiObj);
		}

		//CollectionGetById
		public AccorpamentoInvestimenti CollectionGetById(NullTypes.IntNT IdAccorpamentoInvestimentiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdAccorpamentoInvestimenti == IdAccorpamentoInvestimentiValue))
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
		public AccorpamentoInvestimentiCollection SubSelect(NullTypes.IntNT IdAccorpamentoInvestimentiEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.StringNT CfCreazioneEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdInvestimentoXEqualThis, NullTypes.IntNT IdInvestimentoYEqualThis)
		{
			AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionTemp = new AccorpamentoInvestimentiCollection();
			foreach (AccorpamentoInvestimenti AccorpamentoInvestimentiItem in this)
			{
				if (((IdAccorpamentoInvestimentiEqualThis == null) || ((AccorpamentoInvestimentiItem.IdAccorpamentoInvestimenti != null) && (AccorpamentoInvestimentiItem.IdAccorpamentoInvestimenti.Value == IdAccorpamentoInvestimentiEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((AccorpamentoInvestimentiItem.DataCreazione != null) && (AccorpamentoInvestimentiItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((CfCreazioneEqualThis == null) || ((AccorpamentoInvestimentiItem.CfCreazione != null) && (AccorpamentoInvestimentiItem.CfCreazione.Value == CfCreazioneEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((AccorpamentoInvestimentiItem.DataModifica != null) && (AccorpamentoInvestimentiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((AccorpamentoInvestimentiItem.CfModifica != null) && (AccorpamentoInvestimentiItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((AccorpamentoInvestimentiItem.IdDomandaPagamento != null) && (AccorpamentoInvestimentiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdInvestimentoXEqualThis == null) || ((AccorpamentoInvestimentiItem.IdInvestimentoX != null) && (AccorpamentoInvestimentiItem.IdInvestimentoX.Value == IdInvestimentoXEqualThis.Value))) && ((IdInvestimentoYEqualThis == null) || ((AccorpamentoInvestimentiItem.IdInvestimentoY != null) && (AccorpamentoInvestimentiItem.IdInvestimentoY.Value == IdInvestimentoYEqualThis.Value))))
				{
					AccorpamentoInvestimentiCollectionTemp.Add(AccorpamentoInvestimentiItem);
				}
			}
			return AccorpamentoInvestimentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AccorpamentoInvestimentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AccorpamentoInvestimentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AccorpamentoInvestimenti AccorpamentoInvestimentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdAccorpamentoInvestimenti", AccorpamentoInvestimentiObj.IdAccorpamentoInvestimenti);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfCreazione", AccorpamentoInvestimentiObj.CfCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", AccorpamentoInvestimentiObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", AccorpamentoInvestimentiObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", AccorpamentoInvestimentiObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimentoX", AccorpamentoInvestimentiObj.IdInvestimentoX);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimentoY", AccorpamentoInvestimentiObj.IdInvestimentoY);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaPianoInvestimenti", AccorpamentoInvestimentiObj.IstanzaPianoInvestimenti);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", AccorpamentoInvestimentiObj.DataCreazione);
		}
		//Insert
		private static int Insert(DbProvider db, AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAccorpamentoInvestimentiInsert", new string[] {"CfCreazione", "DataModifica", 
"CfModifica", "IdDomandaPagamento", "IdInvestimentoX", 
"IdInvestimentoY", "IstanzaPianoInvestimenti", 
"DataCreazione"}, new string[] {"string", "DateTime", 
"string", "int", "int", 
"int", "string", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,AccorpamentoInvestimentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AccorpamentoInvestimentiObj.IdAccorpamentoInvestimenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ACCORPAMENTO_INVESTIMENTI"]);
				AccorpamentoInvestimentiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				AccorpamentoInvestimentiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
				}
				AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AccorpamentoInvestimentiObj.IsDirty = false;
				AccorpamentoInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAccorpamentoInvestimentiUpdate", new string[] {"IdAccorpamentoInvestimenti", "CfCreazione", "DataModifica", 
"CfModifica", "IdDomandaPagamento", "IdInvestimentoX", 
"IdInvestimentoY", "IstanzaPianoInvestimenti", 
"DataCreazione"}, new string[] {"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,AccorpamentoInvestimentiObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					AccorpamentoInvestimentiObj.DataModifica = d;
				}
				AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AccorpamentoInvestimentiObj.IsDirty = false;
				AccorpamentoInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			switch (AccorpamentoInvestimentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AccorpamentoInvestimentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AccorpamentoInvestimentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AccorpamentoInvestimentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAccorpamentoInvestimentiUpdate", new string[] {"IdAccorpamentoInvestimenti", "CfCreazione", "DataModifica", 
"CfModifica", "IdDomandaPagamento", "IdInvestimentoX", 
"IdInvestimentoY", "IstanzaPianoInvestimenti", 
"DataCreazione"}, new string[] {"int", "string", "DateTime", 
"string", "int", "int", 
"int", "string", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAccorpamentoInvestimentiInsert", new string[] {"CfCreazione", "DataModifica", 
"CfModifica", "IdDomandaPagamento", "IdInvestimentoX", 
"IdInvestimentoY", "IstanzaPianoInvestimenti", 
"DataCreazione"}, new string[] {"string", "DateTime", 
"string", "int", "int", 
"int", "string", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAccorpamentoInvestimentiDelete", new string[] {"IdAccorpamentoInvestimenti"}, new string[] {"int"},"");
				for (int i = 0; i < AccorpamentoInvestimentiCollectionObj.Count; i++)
				{
					switch (AccorpamentoInvestimentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AccorpamentoInvestimentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AccorpamentoInvestimentiCollectionObj[i].IdAccorpamentoInvestimenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ACCORPAMENTO_INVESTIMENTI"]);
									AccorpamentoInvestimentiCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									AccorpamentoInvestimentiCollectionObj[i].DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AccorpamentoInvestimentiCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									AccorpamentoInvestimentiCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AccorpamentoInvestimentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAccorpamentoInvestimenti", (SiarLibrary.NullTypes.IntNT)AccorpamentoInvestimentiCollectionObj[i].IdAccorpamentoInvestimenti);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AccorpamentoInvestimentiCollectionObj.Count; i++)
				{
					if ((AccorpamentoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AccorpamentoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AccorpamentoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AccorpamentoInvestimentiCollectionObj[i].IsDirty = false;
						AccorpamentoInvestimentiCollectionObj[i].IsPersistent = true;
					}
					if ((AccorpamentoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AccorpamentoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AccorpamentoInvestimentiCollectionObj[i].IsDirty = false;
						AccorpamentoInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AccorpamentoInvestimenti AccorpamentoInvestimentiObj)
		{
			int returnValue = 0;
			if (AccorpamentoInvestimentiObj.IsPersistent) 
			{
				returnValue = Delete(db, AccorpamentoInvestimentiObj.IdAccorpamentoInvestimenti);
			}
			AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AccorpamentoInvestimentiObj.IsDirty = false;
			AccorpamentoInvestimentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdAccorpamentoInvestimentiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAccorpamentoInvestimentiDelete", new string[] {"IdAccorpamentoInvestimenti"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAccorpamentoInvestimenti", (SiarLibrary.NullTypes.IntNT)IdAccorpamentoInvestimentiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAccorpamentoInvestimentiDelete", new string[] {"IdAccorpamentoInvestimenti"}, new string[] {"int"},"");
				for (int i = 0; i < AccorpamentoInvestimentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdAccorpamentoInvestimenti", AccorpamentoInvestimentiCollectionObj[i].IdAccorpamentoInvestimenti);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AccorpamentoInvestimentiCollectionObj.Count; i++)
				{
					if ((AccorpamentoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AccorpamentoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AccorpamentoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AccorpamentoInvestimentiCollectionObj[i].IsDirty = false;
						AccorpamentoInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static AccorpamentoInvestimenti GetById(DbProvider db, int IdAccorpamentoInvestimentiValue)
		{
			AccorpamentoInvestimenti AccorpamentoInvestimentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAccorpamentoInvestimentiGetById", new string[] {"IdAccorpamentoInvestimenti"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdAccorpamentoInvestimenti", (SiarLibrary.NullTypes.IntNT)IdAccorpamentoInvestimentiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AccorpamentoInvestimentiObj = GetFromDatareader(db);
				AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AccorpamentoInvestimentiObj.IsDirty = false;
				AccorpamentoInvestimentiObj.IsPersistent = true;
			}
			db.Close();
			return AccorpamentoInvestimentiObj;
		}

		//getFromDatareader
		public static AccorpamentoInvestimenti GetFromDatareader(DbProvider db)
		{
			AccorpamentoInvestimenti AccorpamentoInvestimentiObj = new AccorpamentoInvestimenti();
			AccorpamentoInvestimentiObj.IdAccorpamentoInvestimenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ACCORPAMENTO_INVESTIMENTI"]);
			AccorpamentoInvestimentiObj.CfCreazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_CREAZIONE"]);
			AccorpamentoInvestimentiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			AccorpamentoInvestimentiObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			AccorpamentoInvestimentiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			AccorpamentoInvestimentiObj.IdInvestimentoX = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_X"]);
			AccorpamentoInvestimentiObj.IdInvestimentoY = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_Y"]);
			AccorpamentoInvestimentiObj.IstanzaPianoInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_PIANO_INVESTIMENTI"]);
			AccorpamentoInvestimentiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			AccorpamentoInvestimentiObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AccorpamentoInvestimentiObj.IsDirty = false;
			AccorpamentoInvestimentiObj.IsPersistent = true;
			return AccorpamentoInvestimentiObj;
		}

		//Find Select

		public static AccorpamentoInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAccorpamentoInvestimentiEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.StringNT CfCreazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdInvestimentoXEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoYEqualThis)

		{

			AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionObj = new AccorpamentoInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zaccorpamentoinvestimentifindselect", new string[] {"IdAccorpamentoInvestimentiequalthis", "DataCreazioneequalthis", "CfCreazioneequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "IdDomandaPagamentoequalthis", 
"IdInvestimentoXequalthis", "IdInvestimentoYequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAccorpamentoInvestimentiequalthis", IdAccorpamentoInvestimentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfCreazioneequalthis", CfCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoXequalthis", IdInvestimentoXEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoYequalthis", IdInvestimentoYEqualThis);
			AccorpamentoInvestimenti AccorpamentoInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AccorpamentoInvestimentiObj = GetFromDatareader(db);
				AccorpamentoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AccorpamentoInvestimentiObj.IsDirty = false;
				AccorpamentoInvestimentiObj.IsPersistent = true;
				AccorpamentoInvestimentiCollectionObj.Add(AccorpamentoInvestimentiObj);
			}
			db.Close();
			return AccorpamentoInvestimentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AccorpamentoInvestimentiCollectionProvider:IAccorpamentoInvestimentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AccorpamentoInvestimentiCollectionProvider : IAccorpamentoInvestimentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AccorpamentoInvestimenti
		protected AccorpamentoInvestimentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AccorpamentoInvestimentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AccorpamentoInvestimentiCollection(this);
		}

		//Costruttore3: ha in input accorpamentoinvestimentiCollectionObj - non popola la collection
		public AccorpamentoInvestimentiCollectionProvider(AccorpamentoInvestimentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AccorpamentoInvestimentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AccorpamentoInvestimentiCollection(this);
		}

		//Get e Set
		public AccorpamentoInvestimentiCollection CollectionObj
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
		public int SaveCollection(AccorpamentoInvestimentiCollection collectionObj)
		{
			return AccorpamentoInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AccorpamentoInvestimenti accorpamentoinvestimentiObj)
		{
			return AccorpamentoInvestimentiDAL.Save(_dbProviderObj, accorpamentoinvestimentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AccorpamentoInvestimentiCollection collectionObj)
		{
			return AccorpamentoInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AccorpamentoInvestimenti accorpamentoinvestimentiObj)
		{
			return AccorpamentoInvestimentiDAL.Delete(_dbProviderObj, accorpamentoinvestimentiObj);
		}

		//getById
		public AccorpamentoInvestimenti GetById(IntNT IdAccorpamentoInvestimentiValue)
		{
			AccorpamentoInvestimenti AccorpamentoInvestimentiTemp = AccorpamentoInvestimentiDAL.GetById(_dbProviderObj, IdAccorpamentoInvestimentiValue);
			if (AccorpamentoInvestimentiTemp!=null) AccorpamentoInvestimentiTemp.Provider = this;
			return AccorpamentoInvestimentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AccorpamentoInvestimentiCollection Select(IntNT IdaccorpamentoinvestimentiEqualThis, DatetimeNT DatacreazioneEqualThis, StringNT CfcreazioneEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdinvestimentoxEqualThis, IntNT IdinvestimentoyEqualThis)
		{
			AccorpamentoInvestimentiCollection AccorpamentoInvestimentiCollectionTemp = AccorpamentoInvestimentiDAL.Select(_dbProviderObj, IdaccorpamentoinvestimentiEqualThis, DatacreazioneEqualThis, CfcreazioneEqualThis, 
DatamodificaEqualThis, CfmodificaEqualThis, IddomandapagamentoEqualThis, 
IdinvestimentoxEqualThis, IdinvestimentoyEqualThis);
			AccorpamentoInvestimentiCollectionTemp.Provider = this;
			return AccorpamentoInvestimentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ACCORPAMENTO_INVESTIMENTI>
  <ViewName>VACCORPAMENTO_INVESTIMENTI</ViewName>
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
</ACCORPAMENTO_INVESTIMENTI>
*/
