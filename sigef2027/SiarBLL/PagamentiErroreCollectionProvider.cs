using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PagamentiErrore
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPagamentiErroreProvider
	{
		int Save(PagamentiErrore PagamentiErroreObj);
		int SaveCollection(PagamentiErroreCollection collectionObj);
		int Delete(PagamentiErrore PagamentiErroreObj);
		int DeleteCollection(PagamentiErroreCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PagamentiErrore
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PagamentiErrore: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPagamentoErrore;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdErrore;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdPagamentoBeneficiario;
		private NullTypes.DecimalNT _ImportoErroreAmmesso;
		private NullTypes.DecimalNT _ImportoErroreConcesso;
		[NonSerialized] private IPagamentiErroreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiErroreProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PagamentiErrore()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PAGAMENTO_ERRORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPagamentoErrore
		{
			get { return _IdPagamentoErrore; }
			set {
				if (IdPagamentoErrore != value)
				{
					_IdPagamentoErrore = value;
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:ID_ERRORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErrore
		{
			get { return _IdErrore; }
			set {
				if (IdErrore != value)
				{
					_IdErrore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_GIUSTIFICATIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdGiustificativo
		{
			get { return _IdGiustificativo; }
			set {
				if (IdGiustificativo != value)
				{
					_IdGiustificativo = value;
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
		/// Corrisponde al campo:ID_PAGAMENTO_BENEFICIARIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPagamentoBeneficiario
		{
			get { return _IdPagamentoBeneficiario; }
			set {
				if (IdPagamentoBeneficiario != value)
				{
					_IdPagamentoBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_ERRORE_AMMESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoErroreAmmesso
		{
			get { return _ImportoErroreAmmesso; }
			set {
				if (ImportoErroreAmmesso != value)
				{
					_ImportoErroreAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_ERRORE_CONCESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoErroreConcesso
		{
			get { return _ImportoErroreConcesso; }
			set {
				if (ImportoErroreConcesso != value)
				{
					_ImportoErroreConcesso = value;
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
	/// Summary description for PagamentiErroreCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiErroreCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PagamentiErroreCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PagamentiErrore) info.GetValue(i.ToString(),typeof(PagamentiErrore)));
			}
		}

		//Costruttore
		public PagamentiErroreCollection()
		{
			this.ItemType = typeof(PagamentiErrore);
		}

		//Costruttore con provider
		public PagamentiErroreCollection(IPagamentiErroreProvider providerObj)
		{
			this.ItemType = typeof(PagamentiErrore);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PagamentiErrore this[int index]
		{
			get { return (PagamentiErrore)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PagamentiErroreCollection GetChanges()
		{
			return (PagamentiErroreCollection) base.GetChanges();
		}

		[NonSerialized] private IPagamentiErroreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiErroreProvider Provider
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
		public int Add(PagamentiErrore PagamentiErroreObj)
		{
			if (PagamentiErroreObj.Provider == null) PagamentiErroreObj.Provider = this.Provider;
			return base.Add(PagamentiErroreObj);
		}

		//AddCollection
		public void AddCollection(PagamentiErroreCollection PagamentiErroreCollectionObj)
		{
			foreach (PagamentiErrore PagamentiErroreObj in PagamentiErroreCollectionObj)
				this.Add(PagamentiErroreObj);
		}

		//Insert
		public void Insert(int index, PagamentiErrore PagamentiErroreObj)
		{
			if (PagamentiErroreObj.Provider == null) PagamentiErroreObj.Provider = this.Provider;
			base.Insert(index, PagamentiErroreObj);
		}

		//CollectionGetById
		public PagamentiErrore CollectionGetById(NullTypes.IntNT IdPagamentoErroreValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPagamentoErrore == IdPagamentoErroreValue))
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
		public PagamentiErroreCollection SubSelect(NullTypes.IntNT IdPagamentoErroreEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdErroreEqualThis, 
NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, NullTypes.DecimalNT ImportoErroreAmmessoEqualThis, 
NullTypes.DecimalNT ImportoErroreConcessoEqualThis)
		{
			PagamentiErroreCollection PagamentiErroreCollectionTemp = new PagamentiErroreCollection();
			foreach (PagamentiErrore PagamentiErroreItem in this)
			{
				if (((IdPagamentoErroreEqualThis == null) || ((PagamentiErroreItem.IdPagamentoErrore != null) && (PagamentiErroreItem.IdPagamentoErrore.Value == IdPagamentoErroreEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((PagamentiErroreItem.CfInserimento != null) && (PagamentiErroreItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((PagamentiErroreItem.DataInserimento != null) && (PagamentiErroreItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((PagamentiErroreItem.CfModifica != null) && (PagamentiErroreItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((PagamentiErroreItem.DataModifica != null) && (PagamentiErroreItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdErroreEqualThis == null) || ((PagamentiErroreItem.IdErrore != null) && (PagamentiErroreItem.IdErrore.Value == IdErroreEqualThis.Value))) && 
((IdDomandaEqualThis == null) || ((PagamentiErroreItem.IdDomanda != null) && (PagamentiErroreItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PagamentiErroreItem.IdInvestimento != null) && (PagamentiErroreItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((PagamentiErroreItem.IdGiustificativo != null) && (PagamentiErroreItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((PagamentiErroreItem.IdProgetto != null) && (PagamentiErroreItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdPagamentoBeneficiarioEqualThis == null) || ((PagamentiErroreItem.IdPagamentoBeneficiario != null) && (PagamentiErroreItem.IdPagamentoBeneficiario.Value == IdPagamentoBeneficiarioEqualThis.Value))) && ((ImportoErroreAmmessoEqualThis == null) || ((PagamentiErroreItem.ImportoErroreAmmesso != null) && (PagamentiErroreItem.ImportoErroreAmmesso.Value == ImportoErroreAmmessoEqualThis.Value))) && 
((ImportoErroreConcessoEqualThis == null) || ((PagamentiErroreItem.ImportoErroreConcesso != null) && (PagamentiErroreItem.ImportoErroreConcesso.Value == ImportoErroreConcessoEqualThis.Value))))
				{
					PagamentiErroreCollectionTemp.Add(PagamentiErroreItem);
				}
			}
			return PagamentiErroreCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PagamentiErroreDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PagamentiErroreDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PagamentiErrore PagamentiErroreObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoErrore", PagamentiErroreObj.IdPagamentoErrore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", PagamentiErroreObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", PagamentiErroreObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", PagamentiErroreObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", PagamentiErroreObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdErrore", PagamentiErroreObj.IdErrore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", PagamentiErroreObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", PagamentiErroreObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdGiustificativo", PagamentiErroreObj.IdGiustificativo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PagamentiErroreObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoBeneficiario", PagamentiErroreObj.IdPagamentoBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoErroreAmmesso", PagamentiErroreObj.ImportoErroreAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoErroreConcesso", PagamentiErroreObj.ImportoErroreConcesso);
		}
		//Insert
		private static int Insert(DbProvider db, PagamentiErrore PagamentiErroreObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiErroreInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdErrore", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoErroreAmmesso", 
"ImportoErroreConcesso"}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,PagamentiErroreObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PagamentiErroreObj.IdPagamentoErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_ERRORE"]);
				PagamentiErroreObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiErroreObj.IsDirty = false;
				PagamentiErroreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PagamentiErrore PagamentiErroreObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiErroreUpdate", new string[] {"IdPagamentoErrore", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdErrore", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoErroreAmmesso", 
"ImportoErroreConcesso"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,PagamentiErroreObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					PagamentiErroreObj.DataModifica = d;
				}
				PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiErroreObj.IsDirty = false;
				PagamentiErroreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PagamentiErrore PagamentiErroreObj)
		{
			switch (PagamentiErroreObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PagamentiErroreObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PagamentiErroreObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PagamentiErroreObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PagamentiErroreCollection PagamentiErroreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiErroreUpdate", new string[] {"IdPagamentoErrore", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdErrore", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoErroreAmmesso", 
"ImportoErroreConcesso"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiErroreInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdErrore", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoErroreAmmesso", 
"ImportoErroreConcesso"}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiErroreDelete", new string[] {"IdPagamentoErrore"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiErroreCollectionObj.Count; i++)
				{
					switch (PagamentiErroreCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PagamentiErroreCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PagamentiErroreCollectionObj[i].IdPagamentoErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_ERRORE"]);
									PagamentiErroreCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PagamentiErroreCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									PagamentiErroreCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PagamentiErroreCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoErrore", (SiarLibrary.NullTypes.IntNT)PagamentiErroreCollectionObj[i].IdPagamentoErrore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PagamentiErroreCollectionObj.Count; i++)
				{
					if ((PagamentiErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PagamentiErroreCollectionObj[i].IsDirty = false;
						PagamentiErroreCollectionObj[i].IsPersistent = true;
					}
					if ((PagamentiErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PagamentiErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiErroreCollectionObj[i].IsDirty = false;
						PagamentiErroreCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PagamentiErrore PagamentiErroreObj)
		{
			int returnValue = 0;
			if (PagamentiErroreObj.IsPersistent) 
			{
				returnValue = Delete(db, PagamentiErroreObj.IdPagamentoErrore);
			}
			PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PagamentiErroreObj.IsDirty = false;
			PagamentiErroreObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPagamentoErroreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiErroreDelete", new string[] {"IdPagamentoErrore"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoErrore", (SiarLibrary.NullTypes.IntNT)IdPagamentoErroreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PagamentiErroreCollection PagamentiErroreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiErroreDelete", new string[] {"IdPagamentoErrore"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiErroreCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoErrore", PagamentiErroreCollectionObj[i].IdPagamentoErrore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PagamentiErroreCollectionObj.Count; i++)
				{
					if ((PagamentiErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiErroreCollectionObj[i].IsDirty = false;
						PagamentiErroreCollectionObj[i].IsPersistent = false;
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
		public static PagamentiErrore GetById(DbProvider db, int IdPagamentoErroreValue)
		{
			PagamentiErrore PagamentiErroreObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPagamentiErroreGetById", new string[] {"IdPagamentoErrore"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPagamentoErrore", (SiarLibrary.NullTypes.IntNT)IdPagamentoErroreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PagamentiErroreObj = GetFromDatareader(db);
				PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiErroreObj.IsDirty = false;
				PagamentiErroreObj.IsPersistent = true;
			}
			db.Close();
			return PagamentiErroreObj;
		}

		//getFromDatareader
		public static PagamentiErrore GetFromDatareader(DbProvider db)
		{
			PagamentiErrore PagamentiErroreObj = new PagamentiErrore();
			PagamentiErroreObj.IdPagamentoErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_ERRORE"]);
			PagamentiErroreObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			PagamentiErroreObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			PagamentiErroreObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			PagamentiErroreObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			PagamentiErroreObj.IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
			PagamentiErroreObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			PagamentiErroreObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			PagamentiErroreObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			PagamentiErroreObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PagamentiErroreObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
			PagamentiErroreObj.ImportoErroreAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_ERRORE_AMMESSO"]);
			PagamentiErroreObj.ImportoErroreConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_ERRORE_CONCESSO"]);
			PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PagamentiErroreObj.IsDirty = false;
			PagamentiErroreObj.IsPersistent = true;
			return PagamentiErroreObj;
		}

		//Find Select

		public static PagamentiErroreCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoErroreEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoErroreAmmessoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoErroreConcessoEqualThis)

		{

			PagamentiErroreCollection PagamentiErroreCollectionObj = new PagamentiErroreCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentierrorefindselect", new string[] {"IdPagamentoErroreequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdErroreequalthis", 
"IdDomandaequalthis", "IdInvestimentoequalthis", "IdGiustificativoequalthis", 
"IdProgettoequalthis", "IdPagamentoBeneficiarioequalthis", "ImportoErroreAmmessoequalthis", 
"ImportoErroreConcessoequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoErroreequalthis", IdPagamentoErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoErroreAmmessoequalthis", ImportoErroreAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoErroreConcessoequalthis", ImportoErroreConcessoEqualThis);
			PagamentiErrore PagamentiErroreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiErroreObj = GetFromDatareader(db);
				PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiErroreObj.IsDirty = false;
				PagamentiErroreObj.IsPersistent = true;
				PagamentiErroreCollectionObj.Add(PagamentiErroreObj);
			}
			db.Close();
			return PagamentiErroreCollectionObj;
		}

		//Find Find

		public static PagamentiErroreCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoErroreEqualThis, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, 
SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis)

		{

			PagamentiErroreCollection PagamentiErroreCollectionObj = new PagamentiErroreCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentierrorefindfind", new string[] {"IdPagamentoErroreequalthis", "IdErroreequalthis", "IdDomandaequalthis", 
"IdInvestimentoequalthis", "IdGiustificativoequalthis", "IdPagamentoBeneficiarioequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoErroreequalthis", IdPagamentoErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			PagamentiErrore PagamentiErroreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiErroreObj = GetFromDatareader(db);
				PagamentiErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiErroreObj.IsDirty = false;
				PagamentiErroreObj.IsPersistent = true;
				PagamentiErroreCollectionObj.Add(PagamentiErroreObj);
			}
			db.Close();
			return PagamentiErroreCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PagamentiErroreCollectionProvider:IPagamentiErroreProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiErroreCollectionProvider : IPagamentiErroreProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PagamentiErrore
		protected PagamentiErroreCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PagamentiErroreCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PagamentiErroreCollection(this);
		}

		//Costruttore 2: popola la collection
		public PagamentiErroreCollectionProvider(IntNT IdpagamentoerroreEqualThis, IntNT IderroreEqualThis, IntNT IddomandaEqualThis, 
IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdpagamentobeneficiarioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpagamentoerroreEqualThis, IderroreEqualThis, IddomandaEqualThis, 
IdinvestimentoEqualThis, IdgiustificativoEqualThis, IdpagamentobeneficiarioEqualThis);
		}

		//Costruttore3: ha in input pagamentierroreCollectionObj - non popola la collection
		public PagamentiErroreCollectionProvider(PagamentiErroreCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PagamentiErroreCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PagamentiErroreCollection(this);
		}

		//Get e Set
		public PagamentiErroreCollection CollectionObj
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
		public int SaveCollection(PagamentiErroreCollection collectionObj)
		{
			return PagamentiErroreDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PagamentiErrore pagamentierroreObj)
		{
			return PagamentiErroreDAL.Save(_dbProviderObj, pagamentierroreObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PagamentiErroreCollection collectionObj)
		{
			return PagamentiErroreDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PagamentiErrore pagamentierroreObj)
		{
			return PagamentiErroreDAL.Delete(_dbProviderObj, pagamentierroreObj);
		}

		//getById
		public PagamentiErrore GetById(IntNT IdPagamentoErroreValue)
		{
			PagamentiErrore PagamentiErroreTemp = PagamentiErroreDAL.GetById(_dbProviderObj, IdPagamentoErroreValue);
			if (PagamentiErroreTemp!=null) PagamentiErroreTemp.Provider = this;
			return PagamentiErroreTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PagamentiErroreCollection Select(IntNT IdpagamentoerroreEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IderroreEqualThis, 
IntNT IddomandaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IdpagamentobeneficiarioEqualThis, DecimalNT ImportoerroreammessoEqualThis, 
DecimalNT ImportoerroreconcessoEqualThis)
		{
			PagamentiErroreCollection PagamentiErroreCollectionTemp = PagamentiErroreDAL.Select(_dbProviderObj, IdpagamentoerroreEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IderroreEqualThis, 
IddomandaEqualThis, IdinvestimentoEqualThis, IdgiustificativoEqualThis, 
IdprogettoEqualThis, IdpagamentobeneficiarioEqualThis, ImportoerroreammessoEqualThis, 
ImportoerroreconcessoEqualThis);
			PagamentiErroreCollectionTemp.Provider = this;
			return PagamentiErroreCollectionTemp;
		}

		//Find: popola la collection
		public PagamentiErroreCollection Find(IntNT IdpagamentoerroreEqualThis, IntNT IderroreEqualThis, IntNT IddomandaEqualThis, 
IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdpagamentobeneficiarioEqualThis)
		{
			PagamentiErroreCollection PagamentiErroreCollectionTemp = PagamentiErroreDAL.Find(_dbProviderObj, IdpagamentoerroreEqualThis, IderroreEqualThis, IddomandaEqualThis, 
IdinvestimentoEqualThis, IdgiustificativoEqualThis, IdpagamentobeneficiarioEqualThis);
			PagamentiErroreCollectionTemp.Provider = this;
			return PagamentiErroreCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGAMENTI_ERRORE>
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
      <ID_PAGAMENTO_ERRORE>Equal</ID_PAGAMENTO_ERRORE>
      <ID_ERRORE>Equal</ID_ERRORE>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_PAGAMENTO_BENEFICIARIO>Equal</ID_PAGAMENTO_BENEFICIARIO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PAGAMENTI_ERRORE>
*/
