using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PagamentiIrregolarita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPagamentiIrregolaritaProvider
	{
		int Save(PagamentiIrregolarita PagamentiIrregolaritaObj);
		int SaveCollection(PagamentiIrregolaritaCollection collectionObj);
		int Delete(PagamentiIrregolarita PagamentiIrregolaritaObj);
		int DeleteCollection(PagamentiIrregolaritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PagamentiIrregolarita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PagamentiIrregolarita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPagamentoIrregolare;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdIrregolarita;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdPagamentoBeneficiario;
		private NullTypes.DecimalNT _ImportoIrregolareAmmesso;
		private NullTypes.DecimalNT _ImportoIrregolareConcesso;
		[NonSerialized] private IPagamentiIrregolaritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiIrregolaritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PagamentiIrregolarita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PAGAMENTO_IRREGOLARE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPagamentoIrregolare
		{
			get { return _IdPagamentoIrregolare; }
			set {
				if (IdPagamentoIrregolare != value)
				{
					_IdPagamentoIrregolare = value;
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
		/// Corrisponde al campo:ID_IRREGOLARITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIrregolarita
		{
			get { return _IdIrregolarita; }
			set {
				if (IdIrregolarita != value)
				{
					_IdIrregolarita = value;
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
		/// Corrisponde al campo:IMPORTO_IRREGOLARE_AMMESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoIrregolareAmmesso
		{
			get { return _ImportoIrregolareAmmesso; }
			set {
				if (ImportoIrregolareAmmesso != value)
				{
					_ImportoIrregolareAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_IRREGOLARE_CONCESSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoIrregolareConcesso
		{
			get { return _ImportoIrregolareConcesso; }
			set {
				if (ImportoIrregolareConcesso != value)
				{
					_ImportoIrregolareConcesso = value;
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
	/// Summary description for PagamentiIrregolaritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiIrregolaritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PagamentiIrregolaritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PagamentiIrregolarita) info.GetValue(i.ToString(),typeof(PagamentiIrregolarita)));
			}
		}

		//Costruttore
		public PagamentiIrregolaritaCollection()
		{
			this.ItemType = typeof(PagamentiIrregolarita);
		}

		//Costruttore con provider
		public PagamentiIrregolaritaCollection(IPagamentiIrregolaritaProvider providerObj)
		{
			this.ItemType = typeof(PagamentiIrregolarita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PagamentiIrregolarita this[int index]
		{
			get { return (PagamentiIrregolarita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PagamentiIrregolaritaCollection GetChanges()
		{
			return (PagamentiIrregolaritaCollection) base.GetChanges();
		}

		[NonSerialized] private IPagamentiIrregolaritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiIrregolaritaProvider Provider
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
		public int Add(PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			if (PagamentiIrregolaritaObj.Provider == null) PagamentiIrregolaritaObj.Provider = this.Provider;
			return base.Add(PagamentiIrregolaritaObj);
		}

		//AddCollection
		public void AddCollection(PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionObj)
		{
			foreach (PagamentiIrregolarita PagamentiIrregolaritaObj in PagamentiIrregolaritaCollectionObj)
				this.Add(PagamentiIrregolaritaObj);
		}

		//Insert
		public void Insert(int index, PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			if (PagamentiIrregolaritaObj.Provider == null) PagamentiIrregolaritaObj.Provider = this.Provider;
			base.Insert(index, PagamentiIrregolaritaObj);
		}

		//CollectionGetById
		public PagamentiIrregolarita CollectionGetById(NullTypes.IntNT IdPagamentoIrregolareValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPagamentoIrregolare == IdPagamentoIrregolareValue))
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
		public PagamentiIrregolaritaCollection SubSelect(NullTypes.IntNT IdPagamentoIrregolareEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdIrregolaritaEqualThis, 
NullTypes.IntNT IdDomandaEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, NullTypes.DecimalNT ImportoIrregolareAmmessoEqualThis, 
NullTypes.DecimalNT ImportoIrregolareConcessoEqualThis)
		{
			PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionTemp = new PagamentiIrregolaritaCollection();
			foreach (PagamentiIrregolarita PagamentiIrregolaritaItem in this)
			{
				if (((IdPagamentoIrregolareEqualThis == null) || ((PagamentiIrregolaritaItem.IdPagamentoIrregolare != null) && (PagamentiIrregolaritaItem.IdPagamentoIrregolare.Value == IdPagamentoIrregolareEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((PagamentiIrregolaritaItem.CfInserimento != null) && (PagamentiIrregolaritaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((PagamentiIrregolaritaItem.DataInserimento != null) && (PagamentiIrregolaritaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((PagamentiIrregolaritaItem.CfModifica != null) && (PagamentiIrregolaritaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((PagamentiIrregolaritaItem.DataModifica != null) && (PagamentiIrregolaritaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdIrregolaritaEqualThis == null) || ((PagamentiIrregolaritaItem.IdIrregolarita != null) && (PagamentiIrregolaritaItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))) && 
((IdDomandaEqualThis == null) || ((PagamentiIrregolaritaItem.IdDomanda != null) && (PagamentiIrregolaritaItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PagamentiIrregolaritaItem.IdInvestimento != null) && (PagamentiIrregolaritaItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((PagamentiIrregolaritaItem.IdGiustificativo != null) && (PagamentiIrregolaritaItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((PagamentiIrregolaritaItem.IdProgetto != null) && (PagamentiIrregolaritaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdPagamentoBeneficiarioEqualThis == null) || ((PagamentiIrregolaritaItem.IdPagamentoBeneficiario != null) && (PagamentiIrregolaritaItem.IdPagamentoBeneficiario.Value == IdPagamentoBeneficiarioEqualThis.Value))) && ((ImportoIrregolareAmmessoEqualThis == null) || ((PagamentiIrregolaritaItem.ImportoIrregolareAmmesso != null) && (PagamentiIrregolaritaItem.ImportoIrregolareAmmesso.Value == ImportoIrregolareAmmessoEqualThis.Value))) && 
((ImportoIrregolareConcessoEqualThis == null) || ((PagamentiIrregolaritaItem.ImportoIrregolareConcesso != null) && (PagamentiIrregolaritaItem.ImportoIrregolareConcesso.Value == ImportoIrregolareConcessoEqualThis.Value))))
				{
					PagamentiIrregolaritaCollectionTemp.Add(PagamentiIrregolaritaItem);
				}
			}
			return PagamentiIrregolaritaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PagamentiIrregolaritaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PagamentiIrregolaritaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PagamentiIrregolarita PagamentiIrregolaritaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoIrregolare", PagamentiIrregolaritaObj.IdPagamentoIrregolare);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", PagamentiIrregolaritaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", PagamentiIrregolaritaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", PagamentiIrregolaritaObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", PagamentiIrregolaritaObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIrregolarita", PagamentiIrregolaritaObj.IdIrregolarita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomanda", PagamentiIrregolaritaObj.IdDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", PagamentiIrregolaritaObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdGiustificativo", PagamentiIrregolaritaObj.IdGiustificativo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PagamentiIrregolaritaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoBeneficiario", PagamentiIrregolaritaObj.IdPagamentoBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoIrregolareAmmesso", PagamentiIrregolaritaObj.ImportoIrregolareAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoIrregolareConcesso", PagamentiIrregolaritaObj.ImportoIrregolareConcesso);
		}
		//Insert
		private static int Insert(DbProvider db, PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiIrregolaritaInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoIrregolareAmmesso", 
"ImportoIrregolareConcesso"}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,PagamentiIrregolaritaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PagamentiIrregolaritaObj.IdPagamentoIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_IRREGOLARE"]);
				PagamentiIrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiIrregolaritaObj.IsDirty = false;
				PagamentiIrregolaritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiIrregolaritaUpdate", new string[] {"IdPagamentoIrregolare", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoIrregolareAmmesso", 
"ImportoIrregolareConcesso"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,PagamentiIrregolaritaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					PagamentiIrregolaritaObj.DataModifica = d;
				}
				PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiIrregolaritaObj.IsDirty = false;
				PagamentiIrregolaritaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			switch (PagamentiIrregolaritaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PagamentiIrregolaritaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PagamentiIrregolaritaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PagamentiIrregolaritaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiIrregolaritaUpdate", new string[] {"IdPagamentoIrregolare", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoIrregolareAmmesso", 
"ImportoIrregolareConcesso"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiIrregolaritaInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdDomanda", "IdInvestimento", "IdGiustificativo", 
"IdProgetto", "IdPagamentoBeneficiario", "ImportoIrregolareAmmesso", 
"ImportoIrregolareConcesso"}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiIrregolaritaDelete", new string[] {"IdPagamentoIrregolare"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiIrregolaritaCollectionObj.Count; i++)
				{
					switch (PagamentiIrregolaritaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PagamentiIrregolaritaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PagamentiIrregolaritaCollectionObj[i].IdPagamentoIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_IRREGOLARE"]);
									PagamentiIrregolaritaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PagamentiIrregolaritaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									PagamentiIrregolaritaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PagamentiIrregolaritaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoIrregolare", (SiarLibrary.NullTypes.IntNT)PagamentiIrregolaritaCollectionObj[i].IdPagamentoIrregolare);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PagamentiIrregolaritaCollectionObj.Count; i++)
				{
					if ((PagamentiIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PagamentiIrregolaritaCollectionObj[i].IsDirty = false;
						PagamentiIrregolaritaCollectionObj[i].IsPersistent = true;
					}
					if ((PagamentiIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PagamentiIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiIrregolaritaCollectionObj[i].IsDirty = false;
						PagamentiIrregolaritaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PagamentiIrregolarita PagamentiIrregolaritaObj)
		{
			int returnValue = 0;
			if (PagamentiIrregolaritaObj.IsPersistent) 
			{
				returnValue = Delete(db, PagamentiIrregolaritaObj.IdPagamentoIrregolare);
			}
			PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PagamentiIrregolaritaObj.IsDirty = false;
			PagamentiIrregolaritaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPagamentoIrregolareValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiIrregolaritaDelete", new string[] {"IdPagamentoIrregolare"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoIrregolare", (SiarLibrary.NullTypes.IntNT)IdPagamentoIrregolareValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiIrregolaritaDelete", new string[] {"IdPagamentoIrregolare"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiIrregolaritaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoIrregolare", PagamentiIrregolaritaCollectionObj[i].IdPagamentoIrregolare);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PagamentiIrregolaritaCollectionObj.Count; i++)
				{
					if ((PagamentiIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiIrregolaritaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiIrregolaritaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiIrregolaritaCollectionObj[i].IsDirty = false;
						PagamentiIrregolaritaCollectionObj[i].IsPersistent = false;
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
		public static PagamentiIrregolarita GetById(DbProvider db, int IdPagamentoIrregolareValue)
		{
			PagamentiIrregolarita PagamentiIrregolaritaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPagamentiIrregolaritaGetById", new string[] {"IdPagamentoIrregolare"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPagamentoIrregolare", (SiarLibrary.NullTypes.IntNT)IdPagamentoIrregolareValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PagamentiIrregolaritaObj = GetFromDatareader(db);
				PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiIrregolaritaObj.IsDirty = false;
				PagamentiIrregolaritaObj.IsPersistent = true;
			}
			db.Close();
			return PagamentiIrregolaritaObj;
		}

		//getFromDatareader
		public static PagamentiIrregolarita GetFromDatareader(DbProvider db)
		{
			PagamentiIrregolarita PagamentiIrregolaritaObj = new PagamentiIrregolarita();
			PagamentiIrregolaritaObj.IdPagamentoIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_IRREGOLARE"]);
			PagamentiIrregolaritaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			PagamentiIrregolaritaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			PagamentiIrregolaritaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			PagamentiIrregolaritaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			PagamentiIrregolaritaObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
			PagamentiIrregolaritaObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			PagamentiIrregolaritaObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			PagamentiIrregolaritaObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			PagamentiIrregolaritaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PagamentiIrregolaritaObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
			PagamentiIrregolaritaObj.ImportoIrregolareAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_AMMESSO"]);
			PagamentiIrregolaritaObj.ImportoIrregolareConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARE_CONCESSO"]);
			PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PagamentiIrregolaritaObj.IsDirty = false;
			PagamentiIrregolaritaObj.IsPersistent = true;
			return PagamentiIrregolaritaObj;
		}

		//Find Select

		public static PagamentiIrregolaritaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoIrregolareEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, 
SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolareAmmessoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoIrregolareConcessoEqualThis)

		{

			PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionObj = new PagamentiIrregolaritaCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentiirregolaritafindselect", new string[] {"IdPagamentoIrregolareequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdIrregolaritaequalthis", 
"IdDomandaequalthis", "IdInvestimentoequalthis", "IdGiustificativoequalthis", 
"IdProgettoequalthis", "IdPagamentoBeneficiarioequalthis", "ImportoIrregolareAmmessoequalthis", 
"ImportoIrregolareConcessoequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "int", "int", 
"int", "int", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoIrregolareequalthis", IdPagamentoIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoIrregolareAmmessoequalthis", ImportoIrregolareAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoIrregolareConcessoequalthis", ImportoIrregolareConcessoEqualThis);
			PagamentiIrregolarita PagamentiIrregolaritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiIrregolaritaObj = GetFromDatareader(db);
				PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiIrregolaritaObj.IsDirty = false;
				PagamentiIrregolaritaObj.IsPersistent = true;
				PagamentiIrregolaritaCollectionObj.Add(PagamentiIrregolaritaObj);
			}
			db.Close();
			return PagamentiIrregolaritaCollectionObj;
		}

		//Find Find

		public static PagamentiIrregolaritaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoIrregolareEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, 
SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis)

		{

			PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionObj = new PagamentiIrregolaritaCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentiirregolaritafindfind", new string[] {"IdPagamentoIrregolareequalthis", "IdIrregolaritaequalthis", "IdDomandaequalthis", 
"IdInvestimentoequalthis", "IdGiustificativoequalthis", "IdPagamentoBeneficiarioequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoIrregolareequalthis", IdPagamentoIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			PagamentiIrregolarita PagamentiIrregolaritaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiIrregolaritaObj = GetFromDatareader(db);
				PagamentiIrregolaritaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiIrregolaritaObj.IsDirty = false;
				PagamentiIrregolaritaObj.IsPersistent = true;
				PagamentiIrregolaritaCollectionObj.Add(PagamentiIrregolaritaObj);
			}
			db.Close();
			return PagamentiIrregolaritaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PagamentiIrregolaritaCollectionProvider:IPagamentiIrregolaritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiIrregolaritaCollectionProvider : IPagamentiIrregolaritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PagamentiIrregolarita
		protected PagamentiIrregolaritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PagamentiIrregolaritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PagamentiIrregolaritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public PagamentiIrregolaritaCollectionProvider(IntNT IdpagamentoirregolareEqualThis, IntNT IdirregolaritaEqualThis, IntNT IddomandaEqualThis, 
IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdpagamentobeneficiarioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpagamentoirregolareEqualThis, IdirregolaritaEqualThis, IddomandaEqualThis, 
IdinvestimentoEqualThis, IdgiustificativoEqualThis, IdpagamentobeneficiarioEqualThis);
		}

		//Costruttore3: ha in input pagamentiirregolaritaCollectionObj - non popola la collection
		public PagamentiIrregolaritaCollectionProvider(PagamentiIrregolaritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PagamentiIrregolaritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PagamentiIrregolaritaCollection(this);
		}

		//Get e Set
		public PagamentiIrregolaritaCollection CollectionObj
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
		public int SaveCollection(PagamentiIrregolaritaCollection collectionObj)
		{
			return PagamentiIrregolaritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PagamentiIrregolarita pagamentiirregolaritaObj)
		{
			return PagamentiIrregolaritaDAL.Save(_dbProviderObj, pagamentiirregolaritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PagamentiIrregolaritaCollection collectionObj)
		{
			return PagamentiIrregolaritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PagamentiIrregolarita pagamentiirregolaritaObj)
		{
			return PagamentiIrregolaritaDAL.Delete(_dbProviderObj, pagamentiirregolaritaObj);
		}

		//getById
		public PagamentiIrregolarita GetById(IntNT IdPagamentoIrregolareValue)
		{
			PagamentiIrregolarita PagamentiIrregolaritaTemp = PagamentiIrregolaritaDAL.GetById(_dbProviderObj, IdPagamentoIrregolareValue);
			if (PagamentiIrregolaritaTemp!=null) PagamentiIrregolaritaTemp.Provider = this;
			return PagamentiIrregolaritaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PagamentiIrregolaritaCollection Select(IntNT IdpagamentoirregolareEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdirregolaritaEqualThis, 
IntNT IddomandaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdprogettoEqualThis, IntNT IdpagamentobeneficiarioEqualThis, DecimalNT ImportoirregolareammessoEqualThis, 
DecimalNT ImportoirregolareconcessoEqualThis)
		{
			PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionTemp = PagamentiIrregolaritaDAL.Select(_dbProviderObj, IdpagamentoirregolareEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdirregolaritaEqualThis, 
IddomandaEqualThis, IdinvestimentoEqualThis, IdgiustificativoEqualThis, 
IdprogettoEqualThis, IdpagamentobeneficiarioEqualThis, ImportoirregolareammessoEqualThis, 
ImportoirregolareconcessoEqualThis);
			PagamentiIrregolaritaCollectionTemp.Provider = this;
			return PagamentiIrregolaritaCollectionTemp;
		}

		//Find: popola la collection
		public PagamentiIrregolaritaCollection Find(IntNT IdpagamentoirregolareEqualThis, IntNT IdirregolaritaEqualThis, IntNT IddomandaEqualThis, 
IntNT IdinvestimentoEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdpagamentobeneficiarioEqualThis)
		{
			PagamentiIrregolaritaCollection PagamentiIrregolaritaCollectionTemp = PagamentiIrregolaritaDAL.Find(_dbProviderObj, IdpagamentoirregolareEqualThis, IdirregolaritaEqualThis, IddomandaEqualThis, 
IdinvestimentoEqualThis, IdgiustificativoEqualThis, IdpagamentobeneficiarioEqualThis);
			PagamentiIrregolaritaCollectionTemp.Provider = this;
			return PagamentiIrregolaritaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGAMENTI_IRREGOLARITA>
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
      <ID_PAGAMENTO_IRREGOLARE>Equal</ID_PAGAMENTO_IRREGOLARE>
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
      <ID_DOMANDA>Equal</ID_DOMANDA>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_PAGAMENTO_BENEFICIARIO>Equal</ID_PAGAMENTO_BENEFICIARIO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PAGAMENTI_IRREGOLARITA>
*/
