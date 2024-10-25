using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RevisioneDomandaPagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRevisioneDomandaPagamentoProvider
	{
		int Save(RevisioneDomandaPagamento RevisioneDomandaPagamentoObj);
		int SaveCollection(RevisioneDomandaPagamentoCollection collectionObj);
		int Delete(RevisioneDomandaPagamento RevisioneDomandaPagamentoObj);
		int DeleteCollection(RevisioneDomandaPagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RevisioneDomandaPagamento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RevisioneDomandaPagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _TipoDomandaPagamento;
		private NullTypes.StringNT _CodFase;
		private NullTypes.DatetimeNT _DataPresentazioneDomandaPagamento;
		private NullTypes.BoolNT _DomandaApprovata;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.IntNT _NumeroEstrazione;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _SegnaturaRevisione;
		private NullTypes.StringNT _SegnaturaSecondaRevisione;
		private NullTypes.DatetimeNT _DataValidazione;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataApprovazione;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _ProvinciaDiPresentazione;
		[NonSerialized] private IRevisioneDomandaPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevisioneDomandaPagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RevisioneDomandaPagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:TIPO_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoDomandaPagamento
		{
			get { return _TipoDomandaPagamento; }
			set {
				if (TipoDomandaPagamento != value)
				{
					_TipoDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPresentazioneDomandaPagamento
		{
			get { return _DataPresentazioneDomandaPagamento; }
			set {
				if (DataPresentazioneDomandaPagamento != value)
				{
					_DataPresentazioneDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DOMANDA_APPROVATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT DomandaApprovata
		{
			get { return _DomandaApprovata; }
			set {
				if (DomandaApprovata != value)
				{
					_DomandaApprovata = value;
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SELEZIONATA_X_REVISIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT SelezionataXRevisione
		{
			get { return _SelezionataXRevisione; }
			set {
				if (SelezionataXRevisione != value)
				{
					_SelezionataXRevisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:APPROVATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Approvata
		{
			get { return _Approvata; }
			set {
				if (Approvata != value)
				{
					_Approvata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_ESTRAZIONE
		/// Tipo sul db:INT
		/// Default:((0))
		/// </summary>
		public NullTypes.IntNT NumeroEstrazione
		{
			get { return _NumeroEstrazione; }
			set {
				if (NumeroEstrazione != value)
				{
					_NumeroEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
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

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_REVISIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaRevisione
		{
			get { return _SegnaturaRevisione; }
			set {
				if (SegnaturaRevisione != value)
				{
					_SegnaturaRevisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_SECONDA_REVISIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaSecondaRevisione
		{
			get { return _SegnaturaSecondaRevisione; }
			set {
				if (SegnaturaSecondaRevisione != value)
				{
					_SegnaturaSecondaRevisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALIDAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValidazione
		{
			get { return _DataValidazione; }
			set {
				if (DataValidazione != value)
				{
					_DataValidazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
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
		/// Corrisponde al campo:DATA_APPROVAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApprovazione
		{
			get { return _DataApprovazione; }
			set {
				if (DataApprovazione != value)
				{
					_DataApprovazione = value;
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
		/// Corrisponde al campo:PROVINCIA_DI_PRESENTAZIONE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT ProvinciaDiPresentazione
		{
			get { return _ProvinciaDiPresentazione; }
			set {
				if (ProvinciaDiPresentazione != value)
				{
					_ProvinciaDiPresentazione = value;
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
	/// Summary description for RevisioneDomandaPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevisioneDomandaPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RevisioneDomandaPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RevisioneDomandaPagamento) info.GetValue(i.ToString(),typeof(RevisioneDomandaPagamento)));
			}
		}

		//Costruttore
		public RevisioneDomandaPagamentoCollection()
		{
			this.ItemType = typeof(RevisioneDomandaPagamento);
		}

		//Costruttore con provider
		public RevisioneDomandaPagamentoCollection(IRevisioneDomandaPagamentoProvider providerObj)
		{
			this.ItemType = typeof(RevisioneDomandaPagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RevisioneDomandaPagamento this[int index]
		{
			get { return (RevisioneDomandaPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RevisioneDomandaPagamentoCollection GetChanges()
		{
			return (RevisioneDomandaPagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IRevisioneDomandaPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRevisioneDomandaPagamentoProvider Provider
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
		public int Add(RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			if (RevisioneDomandaPagamentoObj.Provider == null) RevisioneDomandaPagamentoObj.Provider = this.Provider;
			return base.Add(RevisioneDomandaPagamentoObj);
		}

		//AddCollection
		public void AddCollection(RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj)
		{
			foreach (RevisioneDomandaPagamento RevisioneDomandaPagamentoObj in RevisioneDomandaPagamentoCollectionObj)
				this.Add(RevisioneDomandaPagamentoObj);
		}

		//Insert
		public void Insert(int index, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			if (RevisioneDomandaPagamentoObj.Provider == null) RevisioneDomandaPagamentoObj.Provider = this.Provider;
			base.Insert(index, RevisioneDomandaPagamentoObj);
		}

		//CollectionGetById
		public RevisioneDomandaPagamento CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue, NullTypes.IntNT IdLottoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue) && (this[i].IdLotto == IdLottoValue))
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
		public RevisioneDomandaPagamentoCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.BoolNT SelezionataXRevisioneEqualThis, 
NullTypes.BoolNT ApprovataEqualThis, NullTypes.IntNT NumeroEstrazioneEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.StringNT SegnaturaRevisioneEqualThis, NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, NullTypes.DatetimeNT DataValidazioneEqualThis)
		{
			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionTemp = new RevisioneDomandaPagamentoCollection();
			foreach (RevisioneDomandaPagamento RevisioneDomandaPagamentoItem in this)
			{
				if (((IdLottoEqualThis == null) || ((RevisioneDomandaPagamentoItem.IdLotto != null) && (RevisioneDomandaPagamentoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((RevisioneDomandaPagamentoItem.IdDomandaPagamento != null) && (RevisioneDomandaPagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RevisioneDomandaPagamentoItem.DataInserimento != null) && (RevisioneDomandaPagamentoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((RevisioneDomandaPagamentoItem.DataModifica != null) && (RevisioneDomandaPagamentoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((RevisioneDomandaPagamentoItem.CfOperatore != null) && (RevisioneDomandaPagamentoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((SelezionataXRevisioneEqualThis == null) || ((RevisioneDomandaPagamentoItem.SelezionataXRevisione != null) && (RevisioneDomandaPagamentoItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && 
((ApprovataEqualThis == null) || ((RevisioneDomandaPagamentoItem.Approvata != null) && (RevisioneDomandaPagamentoItem.Approvata.Value == ApprovataEqualThis.Value))) && ((NumeroEstrazioneEqualThis == null) || ((RevisioneDomandaPagamentoItem.NumeroEstrazione != null) && (RevisioneDomandaPagamentoItem.NumeroEstrazione.Value == NumeroEstrazioneEqualThis.Value))) && ((OrdineEqualThis == null) || ((RevisioneDomandaPagamentoItem.Ordine != null) && (RevisioneDomandaPagamentoItem.Ordine.Value == OrdineEqualThis.Value))) && 
((SegnaturaRevisioneEqualThis == null) || ((RevisioneDomandaPagamentoItem.SegnaturaRevisione != null) && (RevisioneDomandaPagamentoItem.SegnaturaRevisione.Value == SegnaturaRevisioneEqualThis.Value))) && ((SegnaturaSecondaRevisioneEqualThis == null) || ((RevisioneDomandaPagamentoItem.SegnaturaSecondaRevisione != null) && (RevisioneDomandaPagamentoItem.SegnaturaSecondaRevisione.Value == SegnaturaSecondaRevisioneEqualThis.Value))) && ((DataValidazioneEqualThis == null) || ((RevisioneDomandaPagamentoItem.DataValidazione != null) && (RevisioneDomandaPagamentoItem.DataValidazione.Value == DataValidazioneEqualThis.Value))))
				{
					RevisioneDomandaPagamentoCollectionTemp.Add(RevisioneDomandaPagamentoItem);
				}
			}
			return RevisioneDomandaPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public RevisioneDomandaPagamentoCollection FiltroAssegnate(NullTypes.IntNT IdLottoEqualThis)
		{
			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionTemp = new RevisioneDomandaPagamentoCollection();
			foreach (RevisioneDomandaPagamento RevisioneDomandaPagamentoItem in this)
			{
				if (((IdLottoEqualThis == null) || ((RevisioneDomandaPagamentoItem.IdLotto != null) && (RevisioneDomandaPagamentoItem.IdLotto.Value == IdLottoEqualThis.Value))))
				{
					RevisioneDomandaPagamentoCollectionTemp.Add(RevisioneDomandaPagamentoItem);
				}
			}
			return RevisioneDomandaPagamentoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RevisioneDomandaPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RevisioneDomandaPagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", RevisioneDomandaPagamentoObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", RevisioneDomandaPagamentoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RevisioneDomandaPagamentoObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", RevisioneDomandaPagamentoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", RevisioneDomandaPagamentoObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXRevisione", RevisioneDomandaPagamentoObj.SelezionataXRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", RevisioneDomandaPagamentoObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroEstrazione", RevisioneDomandaPagamentoObj.NumeroEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", RevisioneDomandaPagamentoObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaRevisione", RevisioneDomandaPagamentoObj.SegnaturaRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaSecondaRevisione", RevisioneDomandaPagamentoObj.SegnaturaSecondaRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValidazione", RevisioneDomandaPagamentoObj.DataValidazione);
		}
		//Insert
		private static int Insert(DbProvider db, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRevisioneDomandaPagamentoInsert", new string[] {"IdDomandaPagamento", 

"IdLotto", "DataInserimento", "DataModifica", 
"CfOperatore", "SelezionataXRevisione", "Approvata", 
"NumeroEstrazione", "Ordine", "SegnaturaRevisione", 
"SegnaturaSecondaRevisione", "DataValidazione", }, new string[] {"int", 

"int", "DateTime", "DateTime", 
"string", "bool", "bool", 
"int", "int", "string", 
"string", "DateTime", },"");
				CompileIUCmd(false, insertCmd,RevisioneDomandaPagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RevisioneDomandaPagamentoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
				RevisioneDomandaPagamentoObj.NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
				}
				RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDomandaPagamentoObj.IsDirty = false;
				RevisioneDomandaPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevisioneDomandaPagamentoUpdate", new string[] {"IdDomandaPagamento", 

"IdLotto", "DataInserimento", "DataModifica", 
"CfOperatore", "SelezionataXRevisione", "Approvata", 
"NumeroEstrazione", "Ordine", "SegnaturaRevisione", 
"SegnaturaSecondaRevisione", "DataValidazione", }, new string[] {"int", 

"int", "DateTime", "DateTime", 
"string", "bool", "bool", 
"int", "int", "string", 
"string", "DateTime", },"");
				CompileIUCmd(true, updateCmd,RevisioneDomandaPagamentoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					RevisioneDomandaPagamentoObj.DataModifica = d;
				}
				RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDomandaPagamentoObj.IsDirty = false;
				RevisioneDomandaPagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			switch (RevisioneDomandaPagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RevisioneDomandaPagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RevisioneDomandaPagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RevisioneDomandaPagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRevisioneDomandaPagamentoUpdate", new string[] {"IdDomandaPagamento", 

"IdLotto", "DataInserimento", "DataModifica", 
"CfOperatore", "SelezionataXRevisione", "Approvata", 
"NumeroEstrazione", "Ordine", "SegnaturaRevisione", 
"SegnaturaSecondaRevisione", "DataValidazione", }, new string[] {"int", 

"int", "DateTime", "DateTime", 
"string", "bool", "bool", 
"int", "int", "string", 
"string", "DateTime", },"");
				IDbCommand insertCmd = db.InitCmd( "ZRevisioneDomandaPagamentoInsert", new string[] {"IdDomandaPagamento", 

"IdLotto", "DataInserimento", "DataModifica", 
"CfOperatore", "SelezionataXRevisione", "Approvata", 
"NumeroEstrazione", "Ordine", "SegnaturaRevisione", 
"SegnaturaSecondaRevisione", "DataValidazione", }, new string[] {"int", 

"int", "DateTime", "DateTime", 
"string", "bool", "bool", 
"int", "int", "string", 
"string", "DateTime", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDomandaPagamentoDelete", new string[] {"IdDomandaPagamento", "IdLotto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < RevisioneDomandaPagamentoCollectionObj.Count; i++)
				{
					switch (RevisioneDomandaPagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RevisioneDomandaPagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RevisioneDomandaPagamentoCollectionObj[i].SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
									RevisioneDomandaPagamentoCollectionObj[i].NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RevisioneDomandaPagamentoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									RevisioneDomandaPagamentoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RevisioneDomandaPagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)RevisioneDomandaPagamentoCollectionObj[i].IdDomandaPagamento);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)RevisioneDomandaPagamentoCollectionObj[i].IdLotto);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RevisioneDomandaPagamentoCollectionObj.Count; i++)
				{
					if ((RevisioneDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevisioneDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevisioneDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RevisioneDomandaPagamentoCollectionObj[i].IsDirty = false;
						RevisioneDomandaPagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((RevisioneDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RevisioneDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevisioneDomandaPagamentoCollectionObj[i].IsDirty = false;
						RevisioneDomandaPagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RevisioneDomandaPagamento RevisioneDomandaPagamentoObj)
		{
			int returnValue = 0;
			if (RevisioneDomandaPagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, RevisioneDomandaPagamentoObj.IdDomandaPagamento, RevisioneDomandaPagamentoObj.IdLotto);
			}
			RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RevisioneDomandaPagamentoObj.IsDirty = false;
			RevisioneDomandaPagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDomandaPagamentoValue, int IdLottoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDomandaPagamentoDelete", new string[] {"IdDomandaPagamento", "IdLotto"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRevisioneDomandaPagamentoDelete", new string[] {"IdDomandaPagamento", "IdLotto"}, new string[] {"int", "int"},"");
				for (int i = 0; i < RevisioneDomandaPagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDomandaPagamento", RevisioneDomandaPagamentoCollectionObj[i].IdDomandaPagamento);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdLotto", RevisioneDomandaPagamentoCollectionObj[i].IdLotto);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RevisioneDomandaPagamentoCollectionObj.Count; i++)
				{
					if ((RevisioneDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RevisioneDomandaPagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RevisioneDomandaPagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RevisioneDomandaPagamentoCollectionObj[i].IsDirty = false;
						RevisioneDomandaPagamentoCollectionObj[i].IsPersistent = false;
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
		public static RevisioneDomandaPagamento GetById(DbProvider db, int IdDomandaPagamentoValue, int IdLottoValue)
		{
			RevisioneDomandaPagamento RevisioneDomandaPagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRevisioneDomandaPagamentoGetById", new string[] {"IdDomandaPagamento", "IdLotto"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDomandaPagamento", (SiarLibrary.NullTypes.IntNT)IdDomandaPagamentoValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdLotto", (SiarLibrary.NullTypes.IntNT)IdLottoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RevisioneDomandaPagamentoObj = GetFromDatareader(db);
				RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDomandaPagamentoObj.IsDirty = false;
				RevisioneDomandaPagamentoObj.IsPersistent = true;
			}
			db.Close();
			return RevisioneDomandaPagamentoObj;
		}

		//getFromDatareader
		public static RevisioneDomandaPagamento GetFromDatareader(DbProvider db)
		{
			RevisioneDomandaPagamento RevisioneDomandaPagamentoObj = new RevisioneDomandaPagamento();
			RevisioneDomandaPagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			RevisioneDomandaPagamentoObj.TipoDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA_PAGAMENTO"]);
			RevisioneDomandaPagamentoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			RevisioneDomandaPagamentoObj.DataPresentazioneDomandaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO"]);
			RevisioneDomandaPagamentoObj.DomandaApprovata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA_APPROVATA"]);
			RevisioneDomandaPagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RevisioneDomandaPagamentoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			RevisioneDomandaPagamentoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RevisioneDomandaPagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			RevisioneDomandaPagamentoObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			RevisioneDomandaPagamentoObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			RevisioneDomandaPagamentoObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			RevisioneDomandaPagamentoObj.NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
			RevisioneDomandaPagamentoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			RevisioneDomandaPagamentoObj.SegnaturaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_REVISIONE"]);
			RevisioneDomandaPagamentoObj.SegnaturaSecondaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_REVISIONE"]);
			RevisioneDomandaPagamentoObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
			RevisioneDomandaPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			RevisioneDomandaPagamentoObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
			RevisioneDomandaPagamentoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			RevisioneDomandaPagamentoObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
			RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RevisioneDomandaPagamentoObj.IsDirty = false;
			RevisioneDomandaPagamentoObj.IsPersistent = true;
			return RevisioneDomandaPagamentoObj;
		}

		//Find Select

		public static RevisioneDomandaPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, 
SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT NumeroEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaRevisioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValidazioneEqualThis)

		{

			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj = new RevisioneDomandaPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zrevisionedomandapagamentofindselect", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "DataInserimentoequalthis", 
"DataModificaequalthis", "CfOperatoreequalthis", "SelezionataXRevisioneequalthis", 
"Approvataequalthis", "NumeroEstrazioneequalthis", "Ordineequalthis", 
"SegnaturaRevisioneequalthis", "SegnaturaSecondaRevisioneequalthis", "DataValidazioneequalthis"}, new string[] {"int", "int", "DateTime", 
"DateTime", "string", "bool", 
"bool", "int", "int", 
"string", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioneequalthis", NumeroEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRevisioneequalthis", SegnaturaRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaSecondaRevisioneequalthis", SegnaturaSecondaRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValidazioneequalthis", DataValidazioneEqualThis);
			RevisioneDomandaPagamento RevisioneDomandaPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevisioneDomandaPagamentoObj = GetFromDatareader(db);
				RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDomandaPagamentoObj.IsDirty = false;
				RevisioneDomandaPagamentoObj.IsPersistent = true;
				RevisioneDomandaPagamentoCollectionObj.Add(RevisioneDomandaPagamentoObj);
			}
			db.Close();
			return RevisioneDomandaPagamentoCollectionObj;
		}

		//Find Find

		public static RevisioneDomandaPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, 
SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis)

		{

			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionObj = new RevisioneDomandaPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zrevisionedomandapagamentofindfind", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "SelezionataXRevisioneequalthis", 
"Approvataequalthis", "IdBandoequalthis", "ProvinciaDiPresentazioneequalthis"}, new string[] {"int", "int", "bool", 
"bool", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaDiPresentazioneequalthis", ProvinciaDiPresentazioneEqualThis);
			RevisioneDomandaPagamento RevisioneDomandaPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RevisioneDomandaPagamentoObj = GetFromDatareader(db);
				RevisioneDomandaPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RevisioneDomandaPagamentoObj.IsDirty = false;
				RevisioneDomandaPagamentoObj.IsPersistent = true;
				RevisioneDomandaPagamentoCollectionObj.Add(RevisioneDomandaPagamentoObj);
			}
			db.Close();
			return RevisioneDomandaPagamentoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RevisioneDomandaPagamentoCollectionProvider:IRevisioneDomandaPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RevisioneDomandaPagamentoCollectionProvider : IRevisioneDomandaPagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RevisioneDomandaPagamento
		protected RevisioneDomandaPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RevisioneDomandaPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RevisioneDomandaPagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public RevisioneDomandaPagamentoCollectionProvider(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT SelezionataxrevisioneEqualThis, 
BoolNT ApprovataEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciadipresentazioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IddomandapagamentoEqualThis, SelezionataxrevisioneEqualThis, 
ApprovataEqualThis, IdbandoEqualThis, ProvinciadipresentazioneEqualThis);
		}

		//Costruttore3: ha in input revisionedomandapagamentoCollectionObj - non popola la collection
		public RevisioneDomandaPagamentoCollectionProvider(RevisioneDomandaPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RevisioneDomandaPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RevisioneDomandaPagamentoCollection(this);
		}

		//Get e Set
		public RevisioneDomandaPagamentoCollection CollectionObj
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
		public int SaveCollection(RevisioneDomandaPagamentoCollection collectionObj)
		{
			return RevisioneDomandaPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RevisioneDomandaPagamento revisionedomandapagamentoObj)
		{
			return RevisioneDomandaPagamentoDAL.Save(_dbProviderObj, revisionedomandapagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RevisioneDomandaPagamentoCollection collectionObj)
		{
			return RevisioneDomandaPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RevisioneDomandaPagamento revisionedomandapagamentoObj)
		{
			return RevisioneDomandaPagamentoDAL.Delete(_dbProviderObj, revisionedomandapagamentoObj);
		}

		//getById
		public RevisioneDomandaPagamento GetById(IntNT IdDomandaPagamentoValue, IntNT IdLottoValue)
		{
			RevisioneDomandaPagamento RevisioneDomandaPagamentoTemp = RevisioneDomandaPagamentoDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue, IdLottoValue);
			if (RevisioneDomandaPagamentoTemp!=null) RevisioneDomandaPagamentoTemp.Provider = this;
			return RevisioneDomandaPagamentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RevisioneDomandaPagamentoCollection Select(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfoperatoreEqualThis, BoolNT SelezionataxrevisioneEqualThis, 
BoolNT ApprovataEqualThis, IntNT NumeroestrazioneEqualThis, IntNT OrdineEqualThis, 
StringNT SegnaturarevisioneEqualThis, StringNT SegnaturasecondarevisioneEqualThis, DatetimeNT DatavalidazioneEqualThis)
		{
			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionTemp = RevisioneDomandaPagamentoDAL.Select(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, DatainserimentoEqualThis, 
DatamodificaEqualThis, CfoperatoreEqualThis, SelezionataxrevisioneEqualThis, 
ApprovataEqualThis, NumeroestrazioneEqualThis, OrdineEqualThis, 
SegnaturarevisioneEqualThis, SegnaturasecondarevisioneEqualThis, DatavalidazioneEqualThis);
			RevisioneDomandaPagamentoCollectionTemp.Provider = this;
			return RevisioneDomandaPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public RevisioneDomandaPagamentoCollection Find(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT SelezionataxrevisioneEqualThis, 
BoolNT ApprovataEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciadipresentazioneEqualThis)
		{
			RevisioneDomandaPagamentoCollection RevisioneDomandaPagamentoCollectionTemp = RevisioneDomandaPagamentoDAL.Find(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, SelezionataxrevisioneEqualThis, 
ApprovataEqualThis, IdbandoEqualThis, ProvinciadipresentazioneEqualThis);
			RevisioneDomandaPagamentoCollectionTemp.Provider = this;
			return RevisioneDomandaPagamentoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<REVISIONE_DOMANDA_PAGAMENTO>
  <ViewName>vREVISIONE_DOMANDA_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_REVISIONE DESC, NUMERO_ESTRAZIONE, ID_DOMANDA_PAGAMENTO">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
      <APPROVATA>Equal</APPROVATA>
      <ID_BANDO>Equal</ID_BANDO>
      <PROVINCIA_DI_PRESENTAZIONE>Equal</PROVINCIA_DI_PRESENTAZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroAssegnate>
      <ID_LOTTO>Equal</ID_LOTTO>
    </FiltroAssegnate>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REVISIONE_DOMANDA_PAGAMENTO>
*/
