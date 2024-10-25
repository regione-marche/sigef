using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Rata
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRataProvider
	{
		int Save(Rata RataObj);
		int SaveCollection(RataCollection collectionObj);
		int Delete(Rata RataObj);
		int DeleteCollection(RataCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Rata
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Rata: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRata;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataRata;
		private NullTypes.DatetimeNT _DataScadenza;
		private NullTypes.DatetimeNT _DataPagamento;
		private NullTypes.DecimalNT _ImportoRata;
		private NullTypes.BoolNT _Pagata;
		private NullTypes.IntNT _IdRegistroRecupero;
		private NullTypes.IntNT _IdTipoRata;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IRataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRataProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Rata()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRata
		{
			get { return _IdRata; }
			set {
				if (IdRata != value)
				{
					_IdRata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
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
		/// Tipo sul db:VARCHAR(16)
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
		/// Corrisponde al campo:DATA_RATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRata
		{
			get { return _DataRata; }
			set {
				if (DataRata != value)
				{
					_DataRata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SCADENZA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenza
		{
			get { return _DataScadenza; }
			set {
				if (DataScadenza != value)
				{
					_DataScadenza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PAGAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPagamento
		{
			get { return _DataPagamento; }
			set {
				if (DataPagamento != value)
				{
					_DataPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RATA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRata
		{
			get { return _ImportoRata; }
			set {
				if (ImportoRata != value)
				{
					_ImportoRata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PAGATA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Pagata
		{
			get { return _Pagata; }
			set {
				if (Pagata != value)
				{
					_Pagata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_REGISTRO_RECUPERO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRegistroRecupero
		{
			get { return _IdRegistroRecupero; }
			set {
				if (IdRegistroRecupero != value)
				{
					_IdRegistroRecupero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_RATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoRata
		{
			get { return _IdTipoRata; }
			set {
				if (IdTipoRata != value)
				{
					_IdTipoRata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(80)
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
	/// Summary description for RataCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RataCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RataCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Rata) info.GetValue(i.ToString(),typeof(Rata)));
			}
		}

		//Costruttore
		public RataCollection()
		{
			this.ItemType = typeof(Rata);
		}

		//Costruttore con provider
		public RataCollection(IRataProvider providerObj)
		{
			this.ItemType = typeof(Rata);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Rata this[int index]
		{
			get { return (Rata)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RataCollection GetChanges()
		{
			return (RataCollection) base.GetChanges();
		}

		[NonSerialized] private IRataProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRataProvider Provider
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
		public int Add(Rata RataObj)
		{
			if (RataObj.Provider == null) RataObj.Provider = this.Provider;
			return base.Add(RataObj);
		}

		//AddCollection
		public void AddCollection(RataCollection RataCollectionObj)
		{
			foreach (Rata RataObj in RataCollectionObj)
				this.Add(RataObj);
		}

		//Insert
		public void Insert(int index, Rata RataObj)
		{
			if (RataObj.Provider == null) RataObj.Provider = this.Provider;
			base.Insert(index, RataObj);
		}

		//CollectionGetById
		public Rata CollectionGetById(NullTypes.IntNT IdRataValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRata == IdRataValue))
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
		public RataCollection SubSelect(NullTypes.IntNT IdRataEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdTipoRataEqualThis, 
NullTypes.DatetimeNT DataRataEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis, NullTypes.DatetimeNT DataPagamentoEqualThis, 
NullTypes.DecimalNT ImportoRataEqualThis, NullTypes.BoolNT PagataEqualThis, NullTypes.IntNT IdRegistroRecuperoEqualThis)
		{
			RataCollection RataCollectionTemp = new RataCollection();
			foreach (Rata RataItem in this)
			{
				if (((IdRataEqualThis == null) || ((RataItem.IdRata != null) && (RataItem.IdRata.Value == IdRataEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RataItem.DataInserimento != null) && (RataItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((RataItem.CfInserimento != null) && (RataItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((RataItem.DataModifica != null) && (RataItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((RataItem.CfModifica != null) && (RataItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdTipoRataEqualThis == null) || ((RataItem.IdTipoRata != null) && (RataItem.IdTipoRata.Value == IdTipoRataEqualThis.Value))) && 
((DataRataEqualThis == null) || ((RataItem.DataRata != null) && (RataItem.DataRata.Value == DataRataEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((RataItem.DataScadenza != null) && (RataItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) && ((DataPagamentoEqualThis == null) || ((RataItem.DataPagamento != null) && (RataItem.DataPagamento.Value == DataPagamentoEqualThis.Value))) && 
((ImportoRataEqualThis == null) || ((RataItem.ImportoRata != null) && (RataItem.ImportoRata.Value == ImportoRataEqualThis.Value))) && ((PagataEqualThis == null) || ((RataItem.Pagata != null) && (RataItem.Pagata.Value == PagataEqualThis.Value))) && ((IdRegistroRecuperoEqualThis == null) || ((RataItem.IdRegistroRecupero != null) && (RataItem.IdRegistroRecupero.Value == IdRegistroRecuperoEqualThis.Value))))
				{
					RataCollectionTemp.Add(RataItem);
				}
			}
			return RataCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RataDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RataDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Rata RataObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRata", RataObj.IdRata);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RataObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", RataObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", RataObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", RataObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRata", RataObj.DataRata);
			DbProvider.SetCmdParam(cmd,firstChar + "DataScadenza", RataObj.DataScadenza);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPagamento", RataObj.DataPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoRata", RataObj.ImportoRata);
			DbProvider.SetCmdParam(cmd,firstChar + "Pagata", RataObj.Pagata);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRegistroRecupero", RataObj.IdRegistroRecupero);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoRata", RataObj.IdTipoRata);
		}
		//Insert
		private static int Insert(DbProvider db, Rata RataObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRataInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataRata", 
"DataScadenza", "DataPagamento", "ImportoRata", 
"Pagata", "IdRegistroRecupero", "IdTipoRata", }, new string[] {"DateTime", "string", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "decimal", 
"bool", "int", "int", },"");
				CompileIUCmd(false, insertCmd,RataObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RataObj.IdRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RATA"]);
				RataObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				RataObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				RataObj.Pagata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PAGATA"]);
				}
				RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RataObj.IsDirty = false;
				RataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Rata RataObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRataUpdate", new string[] {"IdRata", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataRata", 
"DataScadenza", "DataPagamento", "ImportoRata", 
"Pagata", "IdRegistroRecupero", "IdTipoRata", }, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "decimal", 
"bool", "int", "int", },"");
				CompileIUCmd(true, updateCmd,RataObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					RataObj.DataModifica = d;
				}
				RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RataObj.IsDirty = false;
				RataObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Rata RataObj)
		{
			switch (RataObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RataObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RataObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RataObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RataCollection RataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRataUpdate", new string[] {"IdRata", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataRata", 
"DataScadenza", "DataPagamento", "ImportoRata", 
"Pagata", "IdRegistroRecupero", "IdTipoRata", }, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "decimal", 
"bool", "int", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZRataInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "DataRata", 
"DataScadenza", "DataPagamento", "ImportoRata", 
"Pagata", "IdRegistroRecupero", "IdTipoRata", }, new string[] {"DateTime", "string", 
"DateTime", "string", "DateTime", 
"DateTime", "DateTime", "decimal", 
"bool", "int", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZRataDelete", new string[] {"IdRata"}, new string[] {"int"},"");
				for (int i = 0; i < RataCollectionObj.Count; i++)
				{
					switch (RataCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RataCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RataCollectionObj[i].IdRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RATA"]);
									RataCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									RataCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									RataCollectionObj[i].Pagata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PAGATA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RataCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									RataCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RataCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRata", (SiarLibrary.NullTypes.IntNT)RataCollectionObj[i].IdRata);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RataCollectionObj.Count; i++)
				{
					if ((RataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RataCollectionObj[i].IsDirty = false;
						RataCollectionObj[i].IsPersistent = true;
					}
					if ((RataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RataCollectionObj[i].IsDirty = false;
						RataCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Rata RataObj)
		{
			int returnValue = 0;
			if (RataObj.IsPersistent) 
			{
				returnValue = Delete(db, RataObj.IdRata);
			}
			RataObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RataObj.IsDirty = false;
			RataObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRataValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRataDelete", new string[] {"IdRata"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRata", (SiarLibrary.NullTypes.IntNT)IdRataValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RataCollection RataCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRataDelete", new string[] {"IdRata"}, new string[] {"int"},"");
				for (int i = 0; i < RataCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRata", RataCollectionObj[i].IdRata);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RataCollectionObj.Count; i++)
				{
					if ((RataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RataCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RataCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RataCollectionObj[i].IsDirty = false;
						RataCollectionObj[i].IsPersistent = false;
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
		public static Rata GetById(DbProvider db, int IdRataValue)
		{
			Rata RataObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRataGetById", new string[] {"IdRata"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRata", (SiarLibrary.NullTypes.IntNT)IdRataValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RataObj = GetFromDatareader(db);
				RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RataObj.IsDirty = false;
				RataObj.IsPersistent = true;
			}
			db.Close();
			return RataObj;
		}

		//getFromDatareader
		public static Rata GetFromDatareader(DbProvider db)
		{
			Rata RataObj = new Rata();
			RataObj.IdRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RATA"]);
			RataObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RataObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			RataObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			RataObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			RataObj.DataRata = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RATA"]);
			RataObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
			RataObj.DataPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PAGAMENTO"]);
			RataObj.ImportoRata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RATA"]);
			RataObj.Pagata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PAGATA"]);
			RataObj.IdRegistroRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_RECUPERO"]);
			RataObj.IdTipoRata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_RATA"]);
			RataObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RataObj.IsDirty = false;
			RataObj.IsPersistent = true;
			return RataObj;
		}

		//Find Select

		public static RataCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoRataEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPagamentoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoRataEqualThis, SiarLibrary.NullTypes.BoolNT PagataEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroRecuperoEqualThis)

		{

			RataCollection RataCollectionObj = new RataCollection();

			IDbCommand findCmd = db.InitCmd("Zratafindselect", new string[] {"IdRataequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "IdTipoRataequalthis", 
"DataRataequalthis", "DataScadenzaequalthis", "DataPagamentoequalthis", 
"ImportoRataequalthis", "Pagataequalthis", "IdRegistroRecuperoequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"DateTime", "DateTime", "DateTime", 
"decimal", "bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRataequalthis", IdRataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoRataequalthis", IdTipoRataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRataequalthis", DataRataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPagamentoequalthis", DataPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRataequalthis", ImportoRataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pagataequalthis", PagataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRegistroRecuperoequalthis", IdRegistroRecuperoEqualThis);
			Rata RataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RataObj = GetFromDatareader(db);
				RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RataObj.IsDirty = false;
				RataObj.IsPersistent = true;
				RataCollectionObj.Add(RataObj);
			}
			db.Close();
			return RataCollectionObj;
		}

		//Find GetRateByIdRegistroRecupero

		public static RataCollection GetRateByIdRegistroRecupero(DbProvider db, SiarLibrary.NullTypes.IntNT IdRegistroRecuperoEqualThis, SiarLibrary.NullTypes.BoolNT PagataEqualThis)

		{

			RataCollection RataCollectionObj = new RataCollection();

			IDbCommand findCmd = db.InitCmd("Zratafindgetratebyidregistrorecupero", new string[] {"IdRegistroRecuperoequalthis", "Pagataequalthis"}, new string[] {"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRegistroRecuperoequalthis", IdRegistroRecuperoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pagataequalthis", PagataEqualThis);
			Rata RataObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RataObj = GetFromDatareader(db);
				RataObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RataObj.IsDirty = false;
				RataObj.IsPersistent = true;
				RataCollectionObj.Add(RataObj);
			}
			db.Close();
			return RataCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RataCollectionProvider:IRataProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RataCollectionProvider : IRataProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Rata
		protected RataCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RataCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RataCollection(this);
		}

		//Costruttore 2: popola la collection
		public RataCollectionProvider(IntNT IdregistrorecuperoEqualThis, BoolNT PagataEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = GetRateByIdRegistroRecupero(IdregistrorecuperoEqualThis, PagataEqualThis);
		}

		//Costruttore3: ha in input rataCollectionObj - non popola la collection
		public RataCollectionProvider(RataCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RataCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RataCollection(this);
		}

		//Get e Set
		public RataCollection CollectionObj
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
		public int SaveCollection(RataCollection collectionObj)
		{
			return RataDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Rata rataObj)
		{
			return RataDAL.Save(_dbProviderObj, rataObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RataCollection collectionObj)
		{
			return RataDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Rata rataObj)
		{
			return RataDAL.Delete(_dbProviderObj, rataObj);
		}

		//getById
		public Rata GetById(IntNT IdRataValue)
		{
			Rata RataTemp = RataDAL.GetById(_dbProviderObj, IdRataValue);
			if (RataTemp!=null) RataTemp.Provider = this;
			return RataTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RataCollection Select(IntNT IdrataEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdtiporataEqualThis, 
DatetimeNT DatarataEqualThis, DatetimeNT DatascadenzaEqualThis, DatetimeNT DatapagamentoEqualThis, 
DecimalNT ImportorataEqualThis, BoolNT PagataEqualThis, IntNT IdregistrorecuperoEqualThis)
		{
			RataCollection RataCollectionTemp = RataDAL.Select(_dbProviderObj, IdrataEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis, 
DatamodificaEqualThis, CfmodificaEqualThis, IdtiporataEqualThis, 
DatarataEqualThis, DatascadenzaEqualThis, DatapagamentoEqualThis, 
ImportorataEqualThis, PagataEqualThis, IdregistrorecuperoEqualThis);
			RataCollectionTemp.Provider = this;
			return RataCollectionTemp;
		}

		//GetRateByIdRegistroRecupero: popola la collection
		public RataCollection GetRateByIdRegistroRecupero(IntNT IdregistrorecuperoEqualThis, BoolNT PagataEqualThis)
		{
			RataCollection RataCollectionTemp = RataDAL.GetRateByIdRegistroRecupero(_dbProviderObj, IdregistrorecuperoEqualThis, PagataEqualThis);
			RataCollectionTemp.Provider = this;
			return RataCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RATA>
  <ViewName>VRATA</ViewName>
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
    <GetRateByIdRegistroRecupero OrderBy="ORDER BY ">
      <ID_REGISTRO_RECUPERO>Equal</ID_REGISTRO_RECUPERO>
      <PAGATA>Equal</PAGATA>
    </GetRateByIdRegistroRecupero>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RATA>
*/
