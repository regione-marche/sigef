using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspDomandePagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspDomandePagamentoProvider
	{
		int Save(CertspDomandePagamento CertspDomandePagamentoObj);
		int SaveCollection(CertspDomandePagamentoCollection collectionObj);
		int Delete(CertspDomandePagamento CertspDomandePagamentoObj);
		int DeleteCollection(CertspDomandePagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspDomandePagamento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspDomandePagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _OperatoreAssegnato;
		private NullTypes.BoolNT _SelezionataXControllo;
		private NullTypes.StringNT _TipoEstrazione;
		private NullTypes.DecimalNT _ValoreDiRischio;
		private NullTypes.StringNT _ClasseDiRischio;
		private NullTypes.IntNT _OrdineClasseDiRischio;
		private NullTypes.DecimalNT _ContributoRichiesto;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Operatore;
		private NullTypes.BoolNT _ControlloConcluso;
		private NullTypes.BoolNT _OggettoDiControllo;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DatetimeNT _DataPresentazioneDomandaPagamento;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Expr1;
		[NonSerialized] private ICertspDomandePagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspDomandePagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspDomandePagamento()
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
		/// Corrisponde al campo:OPERATORE_ASSEGNATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreAssegnato
		{
			get { return _OperatoreAssegnato; }
			set {
				if (OperatoreAssegnato != value)
				{
					_OperatoreAssegnato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SELEZIONATA_X_CONTROLLO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SelezionataXControllo
		{
			get { return _SelezionataXControllo; }
			set {
				if (SelezionataXControllo != value)
				{
					_SelezionataXControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_ESTRAZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT TipoEstrazione
		{
			get { return _TipoEstrazione; }
			set {
				if (TipoEstrazione != value)
				{
					_TipoEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_DI_RISCHIO
		/// Tipo sul db:DECIMAL(10,4)
		/// </summary>
		public NullTypes.DecimalNT ValoreDiRischio
		{
			get { return _ValoreDiRischio; }
			set {
				if (ValoreDiRischio != value)
				{
					_ValoreDiRischio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CLASSE_DI_RISCHIO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT ClasseDiRischio
		{
			get { return _ClasseDiRischio; }
			set {
				if (ClasseDiRischio != value)
				{
					_ClasseDiRischio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_CLASSE_DI_RISCHIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineClasseDiRischio
		{
			get { return _OrdineClasseDiRischio; }
			set {
				if (OrdineClasseDiRischio != value)
				{
					_OrdineClasseDiRischio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RICHIESTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRichiesto
		{
			get { return _ContributoRichiesto; }
			set {
				if (ContributoRichiesto != value)
				{
					_ContributoRichiesto = value;
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
		/// Corrisponde al campo:CONTROLLO_CONCLUSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ControlloConcluso
		{
			get { return _ControlloConcluso; }
			set {
				if (ControlloConcluso != value)
				{
					_ControlloConcluso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OGGETTO_DI_CONTROLLO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT OggettoDiControllo
		{
			get { return _OggettoDiControllo; }
			set {
				if (OggettoDiControllo != value)
				{
					_OggettoDiControllo = value;
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:Expr1
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Expr1
		{
			get { return _Expr1; }
			set {
				if (Expr1 != value)
				{
					_Expr1 = value;
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
	/// Summary description for CertspDomandePagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspDomandePagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspDomandePagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspDomandePagamento) info.GetValue(i.ToString(),typeof(CertspDomandePagamento)));
			}
		}

		//Costruttore
		public CertspDomandePagamentoCollection()
		{
			this.ItemType = typeof(CertspDomandePagamento);
		}

		//Costruttore con provider
		public CertspDomandePagamentoCollection(ICertspDomandePagamentoProvider providerObj)
		{
			this.ItemType = typeof(CertspDomandePagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspDomandePagamento this[int index]
		{
			get { return (CertspDomandePagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspDomandePagamentoCollection GetChanges()
		{
			return (CertspDomandePagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspDomandePagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspDomandePagamentoProvider Provider
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
		public int Add(CertspDomandePagamento CertspDomandePagamentoObj)
		{
			if (CertspDomandePagamentoObj.Provider == null) CertspDomandePagamentoObj.Provider = this.Provider;
			return base.Add(CertspDomandePagamentoObj);
		}

		//AddCollection
		public void AddCollection(CertspDomandePagamentoCollection CertspDomandePagamentoCollectionObj)
		{
			foreach (CertspDomandePagamento CertspDomandePagamentoObj in CertspDomandePagamentoCollectionObj)
				this.Add(CertspDomandePagamentoObj);
		}

		//Insert
		public void Insert(int index, CertspDomandePagamento CertspDomandePagamentoObj)
		{
			if (CertspDomandePagamentoObj.Provider == null) CertspDomandePagamentoObj.Provider = this.Provider;
			base.Insert(index, CertspDomandePagamentoObj);
		}

		//CollectionGetById
		public CertspDomandePagamento CollectionGetById(NullTypes.IntNT IdValue)
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
		public CertspDomandePagamentoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT OperatoreAssegnatoEqualThis, NullTypes.BoolNT SelezionataXControlloEqualThis, NullTypes.StringNT TipoEstrazioneEqualThis, 
NullTypes.DecimalNT ValoreDiRischioEqualThis, NullTypes.StringNT ClasseDiRischioEqualThis, NullTypes.IntNT OrdineClasseDiRischioEqualThis, 
NullTypes.DecimalNT ContributoRichiestoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.BoolNT ControlloConclusoEqualThis, NullTypes.BoolNT OggettoDiControlloEqualThis)
		{
			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionTemp = new CertspDomandePagamentoCollection();
			foreach (CertspDomandePagamento CertspDomandePagamentoItem in this)
			{
				if (((IdEqualThis == null) || ((CertspDomandePagamentoItem.Id != null) && (CertspDomandePagamentoItem.Id.Value == IdEqualThis.Value))) && ((IdLottoEqualThis == null) || ((CertspDomandePagamentoItem.IdLotto != null) && (CertspDomandePagamentoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CertspDomandePagamentoItem.IdDomandaPagamento != null) && (CertspDomandePagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((OperatoreAssegnatoEqualThis == null) || ((CertspDomandePagamentoItem.OperatoreAssegnato != null) && (CertspDomandePagamentoItem.OperatoreAssegnato.Value == OperatoreAssegnatoEqualThis.Value))) && ((SelezionataXControlloEqualThis == null) || ((CertspDomandePagamentoItem.SelezionataXControllo != null) && (CertspDomandePagamentoItem.SelezionataXControllo.Value == SelezionataXControlloEqualThis.Value))) && ((TipoEstrazioneEqualThis == null) || ((CertspDomandePagamentoItem.TipoEstrazione != null) && (CertspDomandePagamentoItem.TipoEstrazione.Value == TipoEstrazioneEqualThis.Value))) && 
((ValoreDiRischioEqualThis == null) || ((CertspDomandePagamentoItem.ValoreDiRischio != null) && (CertspDomandePagamentoItem.ValoreDiRischio.Value == ValoreDiRischioEqualThis.Value))) && ((ClasseDiRischioEqualThis == null) || ((CertspDomandePagamentoItem.ClasseDiRischio != null) && (CertspDomandePagamentoItem.ClasseDiRischio.Value == ClasseDiRischioEqualThis.Value))) && ((OrdineClasseDiRischioEqualThis == null) || ((CertspDomandePagamentoItem.OrdineClasseDiRischio != null) && (CertspDomandePagamentoItem.OrdineClasseDiRischio.Value == OrdineClasseDiRischioEqualThis.Value))) && 
((ContributoRichiestoEqualThis == null) || ((CertspDomandePagamentoItem.ContributoRichiesto != null) && (CertspDomandePagamentoItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((CertspDomandePagamentoItem.DataModifica != null) && (CertspDomandePagamentoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CertspDomandePagamentoItem.Operatore != null) && (CertspDomandePagamentoItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((ControlloConclusoEqualThis == null) || ((CertspDomandePagamentoItem.ControlloConcluso != null) && (CertspDomandePagamentoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))) && ((OggettoDiControlloEqualThis == null) || ((CertspDomandePagamentoItem.OggettoDiControllo != null) && (CertspDomandePagamentoItem.OggettoDiControllo.Value == OggettoDiControlloEqualThis.Value))))
				{
					CertspDomandePagamentoCollectionTemp.Add(CertspDomandePagamentoItem);
				}
			}
			return CertspDomandePagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CertspDomandePagamentoCollection FiltroTipo(NullTypes.StringNT CodTipoEqualThis)
		{
			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionTemp = new CertspDomandePagamentoCollection();
			foreach (CertspDomandePagamento CertspDomandePagamentoItem in this)
			{
				if (((CodTipoEqualThis == null) || ((CertspDomandePagamentoItem.CodTipo != null) && (CertspDomandePagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))))
				{
					CertspDomandePagamentoCollectionTemp.Add(CertspDomandePagamentoItem);
				}
			}
			return CertspDomandePagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CertspDomandePagamentoCollection FiltroControlli(NullTypes.BoolNT SelezionataXControlloEqualThis, NullTypes.BoolNT ControlloConclusoEqualThis)
		{
			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionTemp = new CertspDomandePagamentoCollection();
			foreach (CertspDomandePagamento CertspDomandePagamentoItem in this)
			{
				if (((SelezionataXControlloEqualThis == null) || ((CertspDomandePagamentoItem.SelezionataXControllo != null) && (CertspDomandePagamentoItem.SelezionataXControllo.Value == SelezionataXControlloEqualThis.Value))) && ((ControlloConclusoEqualThis == null) || ((CertspDomandePagamentoItem.ControlloConcluso != null) && (CertspDomandePagamentoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))))
				{
					CertspDomandePagamentoCollectionTemp.Add(CertspDomandePagamentoItem);
				}
			}
			return CertspDomandePagamentoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspDomandePagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspDomandePagamentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspDomandePagamento CertspDomandePagamentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspDomandePagamentoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", CertspDomandePagamentoObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CertspDomandePagamentoObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreAssegnato", CertspDomandePagamentoObj.OperatoreAssegnato);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXControllo", CertspDomandePagamentoObj.SelezionataXControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoEstrazione", CertspDomandePagamentoObj.TipoEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreDiRischio", CertspDomandePagamentoObj.ValoreDiRischio);
			DbProvider.SetCmdParam(cmd,firstChar + "ClasseDiRischio", CertspDomandePagamentoObj.ClasseDiRischio);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineClasseDiRischio", CertspDomandePagamentoObj.OrdineClasseDiRischio);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRichiesto", CertspDomandePagamentoObj.ContributoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", CertspDomandePagamentoObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspDomandePagamentoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "ControlloConcluso", CertspDomandePagamentoObj.ControlloConcluso);
			DbProvider.SetCmdParam(cmd,firstChar + "OggettoDiControllo", CertspDomandePagamentoObj.OggettoDiControllo);
		}
		//Insert
		private static int Insert(DbProvider db, CertspDomandePagamento CertspDomandePagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspDomandePagamentoInsert", new string[] {"IdLotto", "IdDomandaPagamento", 
"OperatoreAssegnato", "SelezionataXControllo", "TipoEstrazione", 
"ValoreDiRischio", "ClasseDiRischio", "OrdineClasseDiRischio", 
"ContributoRichiesto", "DataModifica", "Operatore", 
"ControlloConcluso", "OggettoDiControllo", 
}, new string[] {"int", "int", 
"int", "bool", "string", 
"decimal", "string", "int", 
"decimal", "DateTime", "int", 
"bool", "bool", 
},"");
				CompileIUCmd(false, insertCmd,CertspDomandePagamentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspDomandePagamentoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDomandePagamentoObj.IsDirty = false;
				CertspDomandePagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspDomandePagamento CertspDomandePagamentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspDomandePagamentoUpdate", new string[] {"Id", "IdLotto", "IdDomandaPagamento", 
"OperatoreAssegnato", "SelezionataXControllo", "TipoEstrazione", 
"ValoreDiRischio", "ClasseDiRischio", "OrdineClasseDiRischio", 
"ContributoRichiesto", "DataModifica", "Operatore", 
"ControlloConcluso", "OggettoDiControllo", 
}, new string[] {"int", "int", "int", 
"int", "bool", "string", 
"decimal", "string", "int", 
"decimal", "DateTime", "int", 
"bool", "bool", 
},"");
				CompileIUCmd(true, updateCmd,CertspDomandePagamentoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					CertspDomandePagamentoObj.DataModifica = d;
				}
				CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDomandePagamentoObj.IsDirty = false;
				CertspDomandePagamentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspDomandePagamento CertspDomandePagamentoObj)
		{
			switch (CertspDomandePagamentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspDomandePagamentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspDomandePagamentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspDomandePagamentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspDomandePagamentoCollection CertspDomandePagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspDomandePagamentoUpdate", new string[] {"Id", "IdLotto", "IdDomandaPagamento", 
"OperatoreAssegnato", "SelezionataXControllo", "TipoEstrazione", 
"ValoreDiRischio", "ClasseDiRischio", "OrdineClasseDiRischio", 
"ContributoRichiesto", "DataModifica", "Operatore", 
"ControlloConcluso", "OggettoDiControllo", 
}, new string[] {"int", "int", "int", 
"int", "bool", "string", 
"decimal", "string", "int", 
"decimal", "DateTime", "int", 
"bool", "bool", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspDomandePagamentoInsert", new string[] {"IdLotto", "IdDomandaPagamento", 
"OperatoreAssegnato", "SelezionataXControllo", "TipoEstrazione", 
"ValoreDiRischio", "ClasseDiRischio", "OrdineClasseDiRischio", 
"ContributoRichiesto", "DataModifica", "Operatore", 
"ControlloConcluso", "OggettoDiControllo", 
}, new string[] {"int", "int", 
"int", "bool", "string", 
"decimal", "string", "int", 
"decimal", "DateTime", "int", 
"bool", "bool", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDomandePagamentoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspDomandePagamentoCollectionObj.Count; i++)
				{
					switch (CertspDomandePagamentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspDomandePagamentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspDomandePagamentoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspDomandePagamentoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									CertspDomandePagamentoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspDomandePagamentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspDomandePagamentoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspDomandePagamentoCollectionObj.Count; i++)
				{
					if ((CertspDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspDomandePagamentoCollectionObj[i].IsDirty = false;
						CertspDomandePagamentoCollectionObj[i].IsPersistent = true;
					}
					if ((CertspDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspDomandePagamentoCollectionObj[i].IsDirty = false;
						CertspDomandePagamentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspDomandePagamento CertspDomandePagamentoObj)
		{
			int returnValue = 0;
			if (CertspDomandePagamentoObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspDomandePagamentoObj.Id);
			}
			CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspDomandePagamentoObj.IsDirty = false;
			CertspDomandePagamentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDomandePagamentoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspDomandePagamentoCollection CertspDomandePagamentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDomandePagamentoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspDomandePagamentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspDomandePagamentoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspDomandePagamentoCollectionObj.Count; i++)
				{
					if ((CertspDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDomandePagamentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspDomandePagamentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspDomandePagamentoCollectionObj[i].IsDirty = false;
						CertspDomandePagamentoCollectionObj[i].IsPersistent = false;
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
		public static CertspDomandePagamento GetById(DbProvider db, int IdValue)
		{
			CertspDomandePagamento CertspDomandePagamentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspDomandePagamentoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspDomandePagamentoObj = GetFromDatareader(db);
				CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDomandePagamentoObj.IsDirty = false;
				CertspDomandePagamentoObj.IsPersistent = true;
			}
			db.Close();
			return CertspDomandePagamentoObj;
		}

		//getFromDatareader
		public static CertspDomandePagamento GetFromDatareader(DbProvider db)
		{
			CertspDomandePagamento CertspDomandePagamentoObj = new CertspDomandePagamento();
			CertspDomandePagamentoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspDomandePagamentoObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			CertspDomandePagamentoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			CertspDomandePagamentoObj.OperatoreAssegnato = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_ASSEGNATO"]);
			CertspDomandePagamentoObj.SelezionataXControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_CONTROLLO"]);
			CertspDomandePagamentoObj.TipoEstrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ESTRAZIONE"]);
			CertspDomandePagamentoObj.ValoreDiRischio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_DI_RISCHIO"]);
			CertspDomandePagamentoObj.ClasseDiRischio = new SiarLibrary.NullTypes.StringNT(db.DataReader["CLASSE_DI_RISCHIO"]);
			CertspDomandePagamentoObj.OrdineClasseDiRischio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_CLASSE_DI_RISCHIO"]);
			CertspDomandePagamentoObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
			CertspDomandePagamentoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CertspDomandePagamentoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			CertspDomandePagamentoObj.ControlloConcluso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTROLLO_CONCLUSO"]);
			CertspDomandePagamentoObj.OggettoDiControllo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OGGETTO_DI_CONTROLLO"]);
			CertspDomandePagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			CertspDomandePagamentoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CertspDomandePagamentoObj.DataPresentazioneDomandaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO"]);
			CertspDomandePagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CertspDomandePagamentoObj.Expr1 = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Expr1"]);
			CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspDomandePagamentoObj.IsDirty = false;
			CertspDomandePagamentoObj.IsPersistent = true;
			return CertspDomandePagamentoObj;
		}

		//Find Select

		public static CertspDomandePagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreAssegnatoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXControlloEqualThis, SiarLibrary.NullTypes.StringNT TipoEstrazioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValoreDiRischioEqualThis, SiarLibrary.NullTypes.StringNT ClasseDiRischioEqualThis, SiarLibrary.NullTypes.IntNT OrdineClasseDiRischioEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT ControlloConclusoEqualThis, SiarLibrary.NullTypes.BoolNT OggettoDiControlloEqualThis)

		{

			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionObj = new CertspDomandePagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspdomandepagamentofindselect", new string[] {"Idequalthis", "IdLottoequalthis", "IdDomandaPagamentoequalthis", 
"OperatoreAssegnatoequalthis", "SelezionataXControlloequalthis", "TipoEstrazioneequalthis", 
"ValoreDiRischioequalthis", "ClasseDiRischioequalthis", "OrdineClasseDiRischioequalthis", 
"ContributoRichiestoequalthis", "DataModificaequalthis", "Operatoreequalthis", 
"ControlloConclusoequalthis", "OggettoDiControlloequalthis"}, new string[] {"int", "int", "int", 
"int", "bool", "string", 
"decimal", "string", "int", 
"decimal", "DateTime", "int", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreAssegnatoequalthis", OperatoreAssegnatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXControlloequalthis", SelezionataXControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoEstrazioneequalthis", TipoEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreDiRischioequalthis", ValoreDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ClasseDiRischioequalthis", ClasseDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineClasseDiRischioequalthis", OrdineClasseDiRischioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloConclusoequalthis", ControlloConclusoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OggettoDiControlloequalthis", OggettoDiControlloEqualThis);
			CertspDomandePagamento CertspDomandePagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspDomandePagamentoObj = GetFromDatareader(db);
				CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDomandePagamentoObj.IsDirty = false;
				CertspDomandePagamentoObj.IsPersistent = true;
				CertspDomandePagamentoCollectionObj.Add(CertspDomandePagamentoObj);
			}
			db.Close();
			return CertspDomandePagamentoCollectionObj;
		}

		//Find Find

		public static CertspDomandePagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionObj = new CertspDomandePagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspdomandepagamentofindfind", new string[] {"IdLottoequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			CertspDomandePagamento CertspDomandePagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspDomandePagamentoObj = GetFromDatareader(db);
				CertspDomandePagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDomandePagamentoObj.IsDirty = false;
				CertspDomandePagamentoObj.IsPersistent = true;
				CertspDomandePagamentoCollectionObj.Add(CertspDomandePagamentoObj);
			}
			db.Close();
			return CertspDomandePagamentoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspDomandePagamentoCollectionProvider:ICertspDomandePagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspDomandePagamentoCollectionProvider : ICertspDomandePagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspDomandePagamento
		protected CertspDomandePagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspDomandePagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspDomandePagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CertspDomandePagamentoCollectionProvider(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlottoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis);
		}

		//Costruttore3: ha in input certspdomandepagamentoCollectionObj - non popola la collection
		public CertspDomandePagamentoCollectionProvider(CertspDomandePagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspDomandePagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspDomandePagamentoCollection(this);
		}

		//Get e Set
		public CertspDomandePagamentoCollection CollectionObj
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
		public int SaveCollection(CertspDomandePagamentoCollection collectionObj)
		{
			return CertspDomandePagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspDomandePagamento certspdomandepagamentoObj)
		{
			return CertspDomandePagamentoDAL.Save(_dbProviderObj, certspdomandepagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspDomandePagamentoCollection collectionObj)
		{
			return CertspDomandePagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspDomandePagamento certspdomandepagamentoObj)
		{
			return CertspDomandePagamentoDAL.Delete(_dbProviderObj, certspdomandepagamentoObj);
		}

		//getById
		public CertspDomandePagamento GetById(IntNT IdValue)
		{
			CertspDomandePagamento CertspDomandePagamentoTemp = CertspDomandePagamentoDAL.GetById(_dbProviderObj, IdValue);
			if (CertspDomandePagamentoTemp!=null) CertspDomandePagamentoTemp.Provider = this;
			return CertspDomandePagamentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspDomandePagamentoCollection Select(IntNT IdEqualThis, IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT OperatoreassegnatoEqualThis, BoolNT SelezionataxcontrolloEqualThis, StringNT TipoestrazioneEqualThis, 
DecimalNT ValoredirischioEqualThis, StringNT ClassedirischioEqualThis, IntNT OrdineclassedirischioEqualThis, 
DecimalNT ContributorichiestoEqualThis, DatetimeNT DatamodificaEqualThis, IntNT OperatoreEqualThis, 
BoolNT ControlloconclusoEqualThis, BoolNT OggettodicontrolloEqualThis)
		{
			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionTemp = CertspDomandePagamentoDAL.Select(_dbProviderObj, IdEqualThis, IdlottoEqualThis, IddomandapagamentoEqualThis, 
OperatoreassegnatoEqualThis, SelezionataxcontrolloEqualThis, TipoestrazioneEqualThis, 
ValoredirischioEqualThis, ClassedirischioEqualThis, OrdineclassedirischioEqualThis, 
ContributorichiestoEqualThis, DatamodificaEqualThis, OperatoreEqualThis, 
ControlloconclusoEqualThis, OggettodicontrolloEqualThis);
			CertspDomandePagamentoCollectionTemp.Provider = this;
			return CertspDomandePagamentoCollectionTemp;
		}

		//Find: popola la collection
		public CertspDomandePagamentoCollection Find(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis)
		{
			CertspDomandePagamentoCollection CertspDomandePagamentoCollectionTemp = CertspDomandePagamentoDAL.Find(_dbProviderObj, IdlottoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis);
			CertspDomandePagamentoCollectionTemp.Provider = this;
			return CertspDomandePagamentoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_DOMANDE_PAGAMENTO>
  <ViewName>vCERTSP_DOMANDE_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE ">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
    </FiltroTipo>
    <FiltroControlli>
      <SELEZIONATA_X_CONTROLLO>Equal</SELEZIONATA_X_CONTROLLO>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlli>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CERTSP_DOMANDE_PAGAMENTO>
*/
