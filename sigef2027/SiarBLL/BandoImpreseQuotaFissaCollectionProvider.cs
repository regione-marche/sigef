using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoImpreseQuotaFissa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoImpreseQuotaFissaProvider
	{
		int Save(BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj);
		int SaveCollection(BandoImpreseQuotaFissaCollection collectionObj);
		int Delete(BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj);
		int DeleteCollection(BandoImpreseQuotaFissaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoImpreseQuotaFissa
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoImpreseQuotaFissa: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.DecimalNT _Quota;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Nominativo;
		[NonSerialized] private IBandoImpreseQuotaFissaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoImpreseQuotaFissaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoImpreseQuotaFissa()
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
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Quota
		{
			get { return _Quota; }
			set {
				if (Quota != value)
				{
					_Quota = value;
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
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
	/// Summary description for BandoImpreseQuotaFissaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoImpreseQuotaFissaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoImpreseQuotaFissaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoImpreseQuotaFissa) info.GetValue(i.ToString(),typeof(BandoImpreseQuotaFissa)));
			}
		}

		//Costruttore
		public BandoImpreseQuotaFissaCollection()
		{
			this.ItemType = typeof(BandoImpreseQuotaFissa);
		}

		//Costruttore con provider
		public BandoImpreseQuotaFissaCollection(IBandoImpreseQuotaFissaProvider providerObj)
		{
			this.ItemType = typeof(BandoImpreseQuotaFissa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoImpreseQuotaFissa this[int index]
		{
			get { return (BandoImpreseQuotaFissa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoImpreseQuotaFissaCollection GetChanges()
		{
			return (BandoImpreseQuotaFissaCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoImpreseQuotaFissaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoImpreseQuotaFissaProvider Provider
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
		public int Add(BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			if (BandoImpreseQuotaFissaObj.Provider == null) BandoImpreseQuotaFissaObj.Provider = this.Provider;
			return base.Add(BandoImpreseQuotaFissaObj);
		}

		//AddCollection
		public void AddCollection(BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionObj)
		{
			foreach (BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj in BandoImpreseQuotaFissaCollectionObj)
				this.Add(BandoImpreseQuotaFissaObj);
		}

		//Insert
		public void Insert(int index, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			if (BandoImpreseQuotaFissaObj.Provider == null) BandoImpreseQuotaFissaObj.Provider = this.Provider;
			base.Insert(index, BandoImpreseQuotaFissaObj);
		}

		//CollectionGetById
		public BandoImpreseQuotaFissa CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoImpreseQuotaFissaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.DecimalNT QuotaEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionTemp = new BandoImpreseQuotaFissaCollection();
			foreach (BandoImpreseQuotaFissa BandoImpreseQuotaFissaItem in this)
			{
				if (((IdEqualThis == null) || ((BandoImpreseQuotaFissaItem.Id != null) && (BandoImpreseQuotaFissaItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoImpreseQuotaFissaItem.IdBando != null) && (BandoImpreseQuotaFissaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((BandoImpreseQuotaFissaItem.IdImpresa != null) && (BandoImpreseQuotaFissaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((QuotaEqualThis == null) || ((BandoImpreseQuotaFissaItem.Quota != null) && (BandoImpreseQuotaFissaItem.Quota.Value == QuotaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((BandoImpreseQuotaFissaItem.Operatore != null) && (BandoImpreseQuotaFissaItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((BandoImpreseQuotaFissaItem.DataInserimento != null) && (BandoImpreseQuotaFissaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((BandoImpreseQuotaFissaItem.DataModifica != null) && (BandoImpreseQuotaFissaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((AttivoEqualThis == null) || ((BandoImpreseQuotaFissaItem.Attivo != null) && (BandoImpreseQuotaFissaItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					BandoImpreseQuotaFissaCollectionTemp.Add(BandoImpreseQuotaFissaItem);
				}
			}
			return BandoImpreseQuotaFissaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoImpreseQuotaFissaCollection Filter(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionTemp = new BandoImpreseQuotaFissaCollection();
			foreach (BandoImpreseQuotaFissa BandoImpreseQuotaFissaItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoImpreseQuotaFissaItem.IdBando != null) && (BandoImpreseQuotaFissaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((BandoImpreseQuotaFissaItem.IdImpresa != null) && (BandoImpreseQuotaFissaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((BandoImpreseQuotaFissaItem.Operatore != null) && (BandoImpreseQuotaFissaItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((AttivoEqualThis == null) || ((BandoImpreseQuotaFissaItem.Attivo != null) && (BandoImpreseQuotaFissaItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					BandoImpreseQuotaFissaCollectionTemp.Add(BandoImpreseQuotaFissaItem);
				}
			}
			return BandoImpreseQuotaFissaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoImpreseQuotaFissaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoImpreseQuotaFissaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoImpreseQuotaFissaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoImpreseQuotaFissaObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", BandoImpreseQuotaFissaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "Quota", BandoImpreseQuotaFissaObj.Quota);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", BandoImpreseQuotaFissaObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", BandoImpreseQuotaFissaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", BandoImpreseQuotaFissaObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BandoImpreseQuotaFissaObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoImpreseQuotaFissaInsert", new string[] {"IdBando", "IdImpresa", 
"Quota", "Operatore", "DataInserimento", 
"DataModifica", "Attivo", }, new string[] {"int", "int", 
"decimal", "int", "DateTime", 
"DateTime", "bool", },"");
				CompileIUCmd(false, insertCmd,BandoImpreseQuotaFissaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoImpreseQuotaFissaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoImpreseQuotaFissaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				BandoImpreseQuotaFissaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoImpreseQuotaFissaObj.IsDirty = false;
				BandoImpreseQuotaFissaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoImpreseQuotaFissaUpdate", new string[] {"Id", "IdBando", "IdImpresa", 
"Quota", "Operatore", "DataInserimento", 
"DataModifica", "Attivo", }, new string[] {"int", "int", "int", 
"decimal", "int", "DateTime", 
"DateTime", "bool", },"");
				CompileIUCmd(true, updateCmd,BandoImpreseQuotaFissaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					BandoImpreseQuotaFissaObj.DataModifica = d;
				}
				BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoImpreseQuotaFissaObj.IsDirty = false;
				BandoImpreseQuotaFissaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			switch (BandoImpreseQuotaFissaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoImpreseQuotaFissaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoImpreseQuotaFissaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoImpreseQuotaFissaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoImpreseQuotaFissaUpdate", new string[] {"Id", "IdBando", "IdImpresa", 
"Quota", "Operatore", "DataInserimento", 
"DataModifica", "Attivo", }, new string[] {"int", "int", "int", 
"decimal", "int", "DateTime", 
"DateTime", "bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoImpreseQuotaFissaInsert", new string[] {"IdBando", "IdImpresa", 
"Quota", "Operatore", "DataInserimento", 
"DataModifica", "Attivo", }, new string[] {"int", "int", 
"decimal", "int", "DateTime", 
"DateTime", "bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoImpreseQuotaFissaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoImpreseQuotaFissaCollectionObj.Count; i++)
				{
					switch (BandoImpreseQuotaFissaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoImpreseQuotaFissaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoImpreseQuotaFissaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoImpreseQuotaFissaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									BandoImpreseQuotaFissaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoImpreseQuotaFissaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									BandoImpreseQuotaFissaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoImpreseQuotaFissaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoImpreseQuotaFissaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoImpreseQuotaFissaCollectionObj.Count; i++)
				{
					if ((BandoImpreseQuotaFissaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoImpreseQuotaFissaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoImpreseQuotaFissaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoImpreseQuotaFissaCollectionObj[i].IsDirty = false;
						BandoImpreseQuotaFissaCollectionObj[i].IsPersistent = true;
					}
					if ((BandoImpreseQuotaFissaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoImpreseQuotaFissaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoImpreseQuotaFissaCollectionObj[i].IsDirty = false;
						BandoImpreseQuotaFissaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj)
		{
			int returnValue = 0;
			if (BandoImpreseQuotaFissaObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoImpreseQuotaFissaObj.Id);
			}
			BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoImpreseQuotaFissaObj.IsDirty = false;
			BandoImpreseQuotaFissaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoImpreseQuotaFissaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoImpreseQuotaFissaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoImpreseQuotaFissaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoImpreseQuotaFissaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoImpreseQuotaFissaCollectionObj.Count; i++)
				{
					if ((BandoImpreseQuotaFissaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoImpreseQuotaFissaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoImpreseQuotaFissaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoImpreseQuotaFissaCollectionObj[i].IsDirty = false;
						BandoImpreseQuotaFissaCollectionObj[i].IsPersistent = false;
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
		public static BandoImpreseQuotaFissa GetById(DbProvider db, int IdValue)
		{
			BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoImpreseQuotaFissaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoImpreseQuotaFissaObj = GetFromDatareader(db);
				BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoImpreseQuotaFissaObj.IsDirty = false;
				BandoImpreseQuotaFissaObj.IsPersistent = true;
			}
			db.Close();
			return BandoImpreseQuotaFissaObj;
		}

		//getFromDatareader
		public static BandoImpreseQuotaFissa GetFromDatareader(DbProvider db)
		{
			BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj = new BandoImpreseQuotaFissa();
			BandoImpreseQuotaFissaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoImpreseQuotaFissaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoImpreseQuotaFissaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			BandoImpreseQuotaFissaObj.Quota = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA"]);
			BandoImpreseQuotaFissaObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			BandoImpreseQuotaFissaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			BandoImpreseQuotaFissaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			BandoImpreseQuotaFissaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BandoImpreseQuotaFissaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoImpreseQuotaFissaObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			BandoImpreseQuotaFissaObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoImpreseQuotaFissaObj.IsDirty = false;
			BandoImpreseQuotaFissaObj.IsPersistent = true;
			return BandoImpreseQuotaFissaObj;
		}

		//Find Select

		public static BandoImpreseQuotaFissaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionObj = new BandoImpreseQuotaFissaCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoimpresequotafissafindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdImpresaequalthis", 
"Quotaequalthis", "Operatoreequalthis", "DataInserimentoequalthis", 
"DataModificaequalthis", "Attivoequalthis"}, new string[] {"int", "int", "int", 
"decimal", "int", "DateTime", 
"DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotaequalthis", QuotaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoImpreseQuotaFissaObj = GetFromDatareader(db);
				BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoImpreseQuotaFissaObj.IsDirty = false;
				BandoImpreseQuotaFissaObj.IsPersistent = true;
				BandoImpreseQuotaFissaCollectionObj.Add(BandoImpreseQuotaFissaObj);
			}
			db.Close();
			return BandoImpreseQuotaFissaCollectionObj;
		}

		//Find Find

		public static BandoImpreseQuotaFissaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionObj = new BandoImpreseQuotaFissaCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoimpresequotafissafindfind", new string[] {"IdBandoequalthis", "IdImpresaequalthis", "Operatoreequalthis", 
"Attivoequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BandoImpreseQuotaFissa BandoImpreseQuotaFissaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoImpreseQuotaFissaObj = GetFromDatareader(db);
				BandoImpreseQuotaFissaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoImpreseQuotaFissaObj.IsDirty = false;
				BandoImpreseQuotaFissaObj.IsPersistent = true;
				BandoImpreseQuotaFissaCollectionObj.Add(BandoImpreseQuotaFissaObj);
			}
			db.Close();
			return BandoImpreseQuotaFissaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoImpreseQuotaFissaCollectionProvider:IBandoImpreseQuotaFissaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoImpreseQuotaFissaCollectionProvider : IBandoImpreseQuotaFissaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoImpreseQuotaFissa
		protected BandoImpreseQuotaFissaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoImpreseQuotaFissaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoImpreseQuotaFissaCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoImpreseQuotaFissaCollectionProvider(IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, IntNT OperatoreEqualThis, 
BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdimpresaEqualThis, OperatoreEqualThis, 
AttivoEqualThis);
		}

		//Costruttore3: ha in input bandoimpresequotafissaCollectionObj - non popola la collection
		public BandoImpreseQuotaFissaCollectionProvider(BandoImpreseQuotaFissaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoImpreseQuotaFissaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoImpreseQuotaFissaCollection(this);
		}

		//Get e Set
		public BandoImpreseQuotaFissaCollection CollectionObj
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
		public int SaveCollection(BandoImpreseQuotaFissaCollection collectionObj)
		{
			return BandoImpreseQuotaFissaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoImpreseQuotaFissa bandoimpresequotafissaObj)
		{
			return BandoImpreseQuotaFissaDAL.Save(_dbProviderObj, bandoimpresequotafissaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoImpreseQuotaFissaCollection collectionObj)
		{
			return BandoImpreseQuotaFissaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoImpreseQuotaFissa bandoimpresequotafissaObj)
		{
			return BandoImpreseQuotaFissaDAL.Delete(_dbProviderObj, bandoimpresequotafissaObj);
		}

		//getById
		public BandoImpreseQuotaFissa GetById(IntNT IdValue)
		{
			BandoImpreseQuotaFissa BandoImpreseQuotaFissaTemp = BandoImpreseQuotaFissaDAL.GetById(_dbProviderObj, IdValue);
			if (BandoImpreseQuotaFissaTemp!=null) BandoImpreseQuotaFissaTemp.Provider = this;
			return BandoImpreseQuotaFissaTemp;
		}

		//Select: popola la collection
		public BandoImpreseQuotaFissaCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, 
DecimalNT QuotaEqualThis, IntNT OperatoreEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, BoolNT AttivoEqualThis)
		{
			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionTemp = BandoImpreseQuotaFissaDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdimpresaEqualThis, 
QuotaEqualThis, OperatoreEqualThis, DatainserimentoEqualThis, 
DatamodificaEqualThis, AttivoEqualThis);
			BandoImpreseQuotaFissaCollectionTemp.Provider = this;
			return BandoImpreseQuotaFissaCollectionTemp;
		}

		//Find: popola la collection
		public BandoImpreseQuotaFissaCollection Find(IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, IntNT OperatoreEqualThis, 
BoolNT AttivoEqualThis)
		{
			BandoImpreseQuotaFissaCollection BandoImpreseQuotaFissaCollectionTemp = BandoImpreseQuotaFissaDAL.Find(_dbProviderObj, IdbandoEqualThis, IdimpresaEqualThis, OperatoreEqualThis, 
AttivoEqualThis);
			BandoImpreseQuotaFissaCollectionTemp.Provider = this;
			return BandoImpreseQuotaFissaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_IMPRESE_QUOTA_FISSA>
  <ViewName>vBANDO_IMPRESE_QUOTA_FISSA</ViewName>
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
    <Find OrderBy="ORDER BY ID_BANDO, ID_IMPRESA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <OPERATORE>Equal</OPERATORE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <OPERATORE>Equal</OPERATORE>
      <ATTIVO>Equal</ATTIVO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_IMPRESE_QUOTA_FISSA>
*/
