using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TestataValidazioneModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITestataValidazioneModificheProvider
	{
		int Save(TestataValidazioneModifiche TestataValidazioneModificheObj);
		int SaveCollection(TestataValidazioneModificheCollection collectionObj);
		int Delete(TestataValidazioneModifiche TestataValidazioneModificheObj);
		int DeleteCollection(TestataValidazioneModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TestataValidazioneModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TestataValidazioneModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTestata;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _TipoDomandaPagamento;
		private NullTypes.StringNT _CodFase;
		private NullTypes.DatetimeNT _DataPresentazioneDomandaPagamento;
		private NullTypes.BoolNT _DomandaApprovata;
		private NullTypes.StringNT _SegnaturaApprovazioneDomanda;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfValidatore;
		private NullTypes.StringNT _NominativoValidatore;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.IntNT _NumeroEstrazione;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _SegnaturaRevisione;
		private NullTypes.StringNT _SegnaturaSecondaRevisione;
		private NullTypes.DatetimeNT _DataValidazione;
		private NullTypes.BoolNT _Autovalutazione;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataApprovazione;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _ProvinciaDiPresentazione;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private ITestataValidazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITestataValidazioneModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TestataValidazioneModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TESTATA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTestata
		{
			get { return _IdTestata; }
			set {
				if (IdTestata != value)
				{
					_IdTestata = value;
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
		/// Corrisponde al campo:SEGNATURA_APPROVAZIONE_DOMANDA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaApprovazioneDomanda
		{
			get { return _SegnaturaApprovazioneDomanda; }
			set {
				if (SegnaturaApprovazioneDomanda != value)
				{
					_SegnaturaApprovazioneDomanda = value;
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
		/// Corrisponde al campo:CF_VALIDATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfValidatore
		{
			get { return _CfValidatore; }
			set {
				if (CfValidatore != value)
				{
					_CfValidatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_VALIDATORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoValidatore
		{
			get { return _NominativoValidatore; }
			set {
				if (NominativoValidatore != value)
				{
					_NominativoValidatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SELEZIONATA_X_REVISIONE
		/// Tipo sul db:BIT
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
		/// Corrisponde al campo:AUTOVALUTAZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Autovalutazione
		{
			get { return _Autovalutazione; }
			set {
				if (Autovalutazione != value)
				{
					_Autovalutazione = value;
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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
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
	/// Summary description for TestataValidazioneModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TestataValidazioneModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TestataValidazioneModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TestataValidazioneModifiche) info.GetValue(i.ToString(),typeof(TestataValidazioneModifiche)));
			}
		}

		//Costruttore
		public TestataValidazioneModificheCollection()
		{
			this.ItemType = typeof(TestataValidazioneModifiche);
		}

		//Costruttore con provider
		public TestataValidazioneModificheCollection(ITestataValidazioneModificheProvider providerObj)
		{
			this.ItemType = typeof(TestataValidazioneModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TestataValidazioneModifiche this[int index]
		{
			get { return (TestataValidazioneModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TestataValidazioneModificheCollection GetChanges()
		{
			return (TestataValidazioneModificheCollection) base.GetChanges();
		}

		[NonSerialized] private ITestataValidazioneModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITestataValidazioneModificheProvider Provider
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
		public int Add(TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			if (TestataValidazioneModificheObj.Provider == null) TestataValidazioneModificheObj.Provider = this.Provider;
			return base.Add(TestataValidazioneModificheObj);
		}

		//AddCollection
		public void AddCollection(TestataValidazioneModificheCollection TestataValidazioneModificheCollectionObj)
		{
			foreach (TestataValidazioneModifiche TestataValidazioneModificheObj in TestataValidazioneModificheCollectionObj)
				this.Add(TestataValidazioneModificheObj);
		}

		//Insert
		public void Insert(int index, TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			if (TestataValidazioneModificheObj.Provider == null) TestataValidazioneModificheObj.Provider = this.Provider;
			base.Insert(index, TestataValidazioneModificheObj);
		}

		//CollectionGetById
		public TestataValidazioneModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public TestataValidazioneModificheCollection SubSelect(NullTypes.IntNT IdTestataEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT TipoDomandaPagamentoEqualThis, 
NullTypes.StringNT CodFaseEqualThis, NullTypes.DatetimeNT DataPresentazioneDomandaPagamentoEqualThis, NullTypes.BoolNT DomandaApprovataEqualThis, 
NullTypes.StringNT SegnaturaApprovazioneDomandaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdLottoEqualThis, 
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfModificaEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfValidatoreEqualThis, NullTypes.StringNT NominativoValidatoreEqualThis, 
NullTypes.BoolNT SelezionataXRevisioneEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.IntNT NumeroEstrazioneEqualThis, 
NullTypes.IntNT OrdineEqualThis, NullTypes.StringNT SegnaturaRevisioneEqualThis, NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, 
NullTypes.DatetimeNT DataValidazioneEqualThis, NullTypes.BoolNT AutovalutazioneEqualThis, NullTypes.StringNT CodTipoEqualThis, 
NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			TestataValidazioneModificheCollection TestataValidazioneModificheCollectionTemp = new TestataValidazioneModificheCollection();
			foreach (TestataValidazioneModifiche TestataValidazioneModificheItem in this)
			{
				if (((IdTestataEqualThis == null) || ((TestataValidazioneModificheItem.IdTestata != null) && (TestataValidazioneModificheItem.IdTestata.Value == IdTestataEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((TestataValidazioneModificheItem.IdDomandaPagamento != null) && (TestataValidazioneModificheItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((TipoDomandaPagamentoEqualThis == null) || ((TestataValidazioneModificheItem.TipoDomandaPagamento != null) && (TestataValidazioneModificheItem.TipoDomandaPagamento.Value == TipoDomandaPagamentoEqualThis.Value))) && 
((CodFaseEqualThis == null) || ((TestataValidazioneModificheItem.CodFase != null) && (TestataValidazioneModificheItem.CodFase.Value == CodFaseEqualThis.Value))) && ((DataPresentazioneDomandaPagamentoEqualThis == null) || ((TestataValidazioneModificheItem.DataPresentazioneDomandaPagamento != null) && (TestataValidazioneModificheItem.DataPresentazioneDomandaPagamento.Value == DataPresentazioneDomandaPagamentoEqualThis.Value))) && ((DomandaApprovataEqualThis == null) || ((TestataValidazioneModificheItem.DomandaApprovata != null) && (TestataValidazioneModificheItem.DomandaApprovata.Value == DomandaApprovataEqualThis.Value))) && 
((SegnaturaApprovazioneDomandaEqualThis == null) || ((TestataValidazioneModificheItem.SegnaturaApprovazioneDomanda != null) && (TestataValidazioneModificheItem.SegnaturaApprovazioneDomanda.Value == SegnaturaApprovazioneDomandaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((TestataValidazioneModificheItem.IdProgetto != null) && (TestataValidazioneModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdLottoEqualThis == null) || ((TestataValidazioneModificheItem.IdLotto != null) && (TestataValidazioneModificheItem.IdLotto.Value == IdLottoEqualThis.Value))) && 
((CfInserimentoEqualThis == null) || ((TestataValidazioneModificheItem.CfInserimento != null) && (TestataValidazioneModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TestataValidazioneModificheItem.DataInserimento != null) && (TestataValidazioneModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfModificaEqualThis == null) || ((TestataValidazioneModificheItem.CfModifica != null) && (TestataValidazioneModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((TestataValidazioneModificheItem.DataModifica != null) && (TestataValidazioneModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfValidatoreEqualThis == null) || ((TestataValidazioneModificheItem.CfValidatore != null) && (TestataValidazioneModificheItem.CfValidatore.Value == CfValidatoreEqualThis.Value))) && ((NominativoValidatoreEqualThis == null) || ((TestataValidazioneModificheItem.NominativoValidatore != null) && (TestataValidazioneModificheItem.NominativoValidatore.Value == NominativoValidatoreEqualThis.Value))) && 
((SelezionataXRevisioneEqualThis == null) || ((TestataValidazioneModificheItem.SelezionataXRevisione != null) && (TestataValidazioneModificheItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && ((ApprovataEqualThis == null) || ((TestataValidazioneModificheItem.Approvata != null) && (TestataValidazioneModificheItem.Approvata.Value == ApprovataEqualThis.Value))) && ((NumeroEstrazioneEqualThis == null) || ((TestataValidazioneModificheItem.NumeroEstrazione != null) && (TestataValidazioneModificheItem.NumeroEstrazione.Value == NumeroEstrazioneEqualThis.Value))) && 
((OrdineEqualThis == null) || ((TestataValidazioneModificheItem.Ordine != null) && (TestataValidazioneModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((SegnaturaRevisioneEqualThis == null) || ((TestataValidazioneModificheItem.SegnaturaRevisione != null) && (TestataValidazioneModificheItem.SegnaturaRevisione.Value == SegnaturaRevisioneEqualThis.Value))) && ((SegnaturaSecondaRevisioneEqualThis == null) || ((TestataValidazioneModificheItem.SegnaturaSecondaRevisione != null) && (TestataValidazioneModificheItem.SegnaturaSecondaRevisione.Value == SegnaturaSecondaRevisioneEqualThis.Value))) && 
((DataValidazioneEqualThis == null) || ((TestataValidazioneModificheItem.DataValidazione != null) && (TestataValidazioneModificheItem.DataValidazione.Value == DataValidazioneEqualThis.Value))) && ((AutovalutazioneEqualThis == null) || ((TestataValidazioneModificheItem.Autovalutazione != null) && (TestataValidazioneModificheItem.Autovalutazione.Value == AutovalutazioneEqualThis.Value))) && ((CodTipoEqualThis == null) || ((TestataValidazioneModificheItem.CodTipo != null) && (TestataValidazioneModificheItem.CodTipo.Value == CodTipoEqualThis.Value))) && 
((DataApprovazioneEqualThis == null) || ((TestataValidazioneModificheItem.DataApprovazione != null) && (TestataValidazioneModificheItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((IdBandoEqualThis == null) || ((TestataValidazioneModificheItem.IdBando != null) && (TestataValidazioneModificheItem.IdBando.Value == IdBandoEqualThis.Value))) && ((ProvinciaDiPresentazioneEqualThis == null) || ((TestataValidazioneModificheItem.ProvinciaDiPresentazione != null) && (TestataValidazioneModificheItem.ProvinciaDiPresentazione.Value == ProvinciaDiPresentazioneEqualThis.Value))) && 
((IdEqualThis == null) || ((TestataValidazioneModificheItem.Id != null) && (TestataValidazioneModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((TestataValidazioneModificheItem.IdModifica != null) && (TestataValidazioneModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					TestataValidazioneModificheCollectionTemp.Add(TestataValidazioneModificheItem);
				}
			}
			return TestataValidazioneModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TestataValidazioneModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TestataValidazioneModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TestataValidazioneModifiche TestataValidazioneModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", TestataValidazioneModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdTestata", TestataValidazioneModificheObj.IdTestata);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", TestataValidazioneModificheObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoDomandaPagamento", TestataValidazioneModificheObj.TipoDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", TestataValidazioneModificheObj.CodFase);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPresentazioneDomandaPagamento", TestataValidazioneModificheObj.DataPresentazioneDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "DomandaApprovata", TestataValidazioneModificheObj.DomandaApprovata);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaApprovazioneDomanda", TestataValidazioneModificheObj.SegnaturaApprovazioneDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", TestataValidazioneModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdLotto", TestataValidazioneModificheObj.IdLotto);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", TestataValidazioneModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", TestataValidazioneModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", TestataValidazioneModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", TestataValidazioneModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfValidatore", TestataValidazioneModificheObj.CfValidatore);
			DbProvider.SetCmdParam(cmd,firstChar + "NominativoValidatore", TestataValidazioneModificheObj.NominativoValidatore);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXRevisione", TestataValidazioneModificheObj.SelezionataXRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", TestataValidazioneModificheObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroEstrazione", TestataValidazioneModificheObj.NumeroEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", TestataValidazioneModificheObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaRevisione", TestataValidazioneModificheObj.SegnaturaRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaSecondaRevisione", TestataValidazioneModificheObj.SegnaturaSecondaRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValidazione", TestataValidazioneModificheObj.DataValidazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Autovalutazione", TestataValidazioneModificheObj.Autovalutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", TestataValidazioneModificheObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataApprovazione", TestataValidazioneModificheObj.DataApprovazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", TestataValidazioneModificheObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "ProvinciaDiPresentazione", TestataValidazioneModificheObj.ProvinciaDiPresentazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", TestataValidazioneModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTestataValidazioneModificheInsert", new string[] {"IdTestata", "IdDomandaPagamento", "TipoDomandaPagamento", 
"CodFase", "DataPresentazioneDomandaPagamento", "DomandaApprovata", 
"SegnaturaApprovazioneDomanda", "IdProgetto", "IdLotto", 
"CfInserimento", "DataInserimento", "CfModifica", 
"DataModifica", "CfValidatore", "NominativoValidatore", 
"SelezionataXRevisione", "Approvata", "NumeroEstrazione", 
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione", 
"DataValidazione", "Autovalutazione", "CodTipo", 
"DataApprovazione", "IdBando", "ProvinciaDiPresentazione", 
"IdModifica"}, new string[] {"int", "int", "string", 
"string", "DateTime", "bool", 
"string", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"bool", "bool", "int", 
"int", "string", "string", 
"DateTime", "bool", "string", 
"DateTime", "int", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,TestataValidazioneModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TestataValidazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneModificheObj.IsDirty = false;
				TestataValidazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTestataValidazioneModificheUpdate", new string[] {"IdTestata", "IdDomandaPagamento", "TipoDomandaPagamento", 
"CodFase", "DataPresentazioneDomandaPagamento", "DomandaApprovata", 
"SegnaturaApprovazioneDomanda", "IdProgetto", "IdLotto", 
"CfInserimento", "DataInserimento", "CfModifica", 
"DataModifica", "CfValidatore", "NominativoValidatore", 
"SelezionataXRevisione", "Approvata", "NumeroEstrazione", 
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione", 
"DataValidazione", "Autovalutazione", "CodTipo", 
"DataApprovazione", "IdBando", "ProvinciaDiPresentazione", 
"Id", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "DateTime", "bool", 
"string", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"bool", "bool", "int", 
"int", "string", "string", 
"DateTime", "bool", "string", 
"DateTime", "int", "string", 
"int", "int"},"");
				CompileIUCmd(true, updateCmd,TestataValidazioneModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					TestataValidazioneModificheObj.DataModifica = d;
				}
				TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneModificheObj.IsDirty = false;
				TestataValidazioneModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			switch (TestataValidazioneModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TestataValidazioneModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TestataValidazioneModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TestataValidazioneModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TestataValidazioneModificheCollection TestataValidazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTestataValidazioneModificheUpdate", new string[] {"IdTestata", "IdDomandaPagamento", "TipoDomandaPagamento", 
"CodFase", "DataPresentazioneDomandaPagamento", "DomandaApprovata", 
"SegnaturaApprovazioneDomanda", "IdProgetto", "IdLotto", 
"CfInserimento", "DataInserimento", "CfModifica", 
"DataModifica", "CfValidatore", "NominativoValidatore", 
"SelezionataXRevisione", "Approvata", "NumeroEstrazione", 
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione", 
"DataValidazione", "Autovalutazione", "CodTipo", 
"DataApprovazione", "IdBando", "ProvinciaDiPresentazione", 
"Id", "IdModifica"}, new string[] {"int", "int", "string", 
"string", "DateTime", "bool", 
"string", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"bool", "bool", "int", 
"int", "string", "string", 
"DateTime", "bool", "string", 
"DateTime", "int", "string", 
"int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTestataValidazioneModificheInsert", new string[] {"IdTestata", "IdDomandaPagamento", "TipoDomandaPagamento", 
"CodFase", "DataPresentazioneDomandaPagamento", "DomandaApprovata", 
"SegnaturaApprovazioneDomanda", "IdProgetto", "IdLotto", 
"CfInserimento", "DataInserimento", "CfModifica", 
"DataModifica", "CfValidatore", "NominativoValidatore", 
"SelezionataXRevisione", "Approvata", "NumeroEstrazione", 
"Ordine", "SegnaturaRevisione", "SegnaturaSecondaRevisione", 
"DataValidazione", "Autovalutazione", "CodTipo", 
"DataApprovazione", "IdBando", "ProvinciaDiPresentazione", 
"IdModifica"}, new string[] {"int", "int", "string", 
"string", "DateTime", "bool", 
"string", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"bool", "bool", "int", 
"int", "string", "string", 
"DateTime", "bool", "string", 
"DateTime", "int", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TestataValidazioneModificheCollectionObj.Count; i++)
				{
					switch (TestataValidazioneModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TestataValidazioneModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TestataValidazioneModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TestataValidazioneModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									TestataValidazioneModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TestataValidazioneModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)TestataValidazioneModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TestataValidazioneModificheCollectionObj.Count; i++)
				{
					if ((TestataValidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TestataValidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TestataValidazioneModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneModificheCollectionObj[i].IsPersistent = true;
					}
					if ((TestataValidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TestataValidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TestataValidazioneModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TestataValidazioneModifiche TestataValidazioneModificheObj)
		{
			int returnValue = 0;
			if (TestataValidazioneModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, TestataValidazioneModificheObj.Id);
			}
			TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TestataValidazioneModificheObj.IsDirty = false;
			TestataValidazioneModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TestataValidazioneModificheCollection TestataValidazioneModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTestataValidazioneModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TestataValidazioneModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", TestataValidazioneModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TestataValidazioneModificheCollectionObj.Count; i++)
				{
					if ((TestataValidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TestataValidazioneModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TestataValidazioneModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TestataValidazioneModificheCollectionObj[i].IsDirty = false;
						TestataValidazioneModificheCollectionObj[i].IsPersistent = false;
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
		public static TestataValidazioneModifiche GetById(DbProvider db, int IdValue)
		{
			TestataValidazioneModifiche TestataValidazioneModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTestataValidazioneModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TestataValidazioneModificheObj = GetFromDatareader(db);
				TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneModificheObj.IsDirty = false;
				TestataValidazioneModificheObj.IsPersistent = true;
			}
			db.Close();
			return TestataValidazioneModificheObj;
		}

		//getFromDatareader
		public static TestataValidazioneModifiche GetFromDatareader(DbProvider db)
		{
			TestataValidazioneModifiche TestataValidazioneModificheObj = new TestataValidazioneModifiche();
			TestataValidazioneModificheObj.IdTestata = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TESTATA"]);
			TestataValidazioneModificheObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			TestataValidazioneModificheObj.TipoDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA_PAGAMENTO"]);
			TestataValidazioneModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			TestataValidazioneModificheObj.DataPresentazioneDomandaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO"]);
			TestataValidazioneModificheObj.DomandaApprovata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DOMANDA_APPROVATA"]);
			TestataValidazioneModificheObj.SegnaturaApprovazioneDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE_DOMANDA"]);
			TestataValidazioneModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			TestataValidazioneModificheObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			TestataValidazioneModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			TestataValidazioneModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			TestataValidazioneModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			TestataValidazioneModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			TestataValidazioneModificheObj.CfValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_VALIDATORE"]);
			TestataValidazioneModificheObj.NominativoValidatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_VALIDATORE"]);
			TestataValidazioneModificheObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			TestataValidazioneModificheObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			TestataValidazioneModificheObj.NumeroEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONE"]);
			TestataValidazioneModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			TestataValidazioneModificheObj.SegnaturaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_REVISIONE"]);
			TestataValidazioneModificheObj.SegnaturaSecondaRevisione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_REVISIONE"]);
			TestataValidazioneModificheObj.DataValidazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALIDAZIONE"]);
			TestataValidazioneModificheObj.Autovalutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOVALUTAZIONE"]);
			TestataValidazioneModificheObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			TestataValidazioneModificheObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
			TestataValidazioneModificheObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			TestataValidazioneModificheObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
			TestataValidazioneModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			TestataValidazioneModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TestataValidazioneModificheObj.IsDirty = false;
			TestataValidazioneModificheObj.IsPersistent = true;
			return TestataValidazioneModificheObj;
		}

		//Find Select

		public static TestataValidazioneModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTestataEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT TipoDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPresentazioneDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT DomandaApprovataEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, 
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfValidatoreEqualThis, SiarLibrary.NullTypes.StringNT NominativoValidatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT NumeroEstrazioneEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRevisioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaRevisioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataValidazioneEqualThis, SiarLibrary.NullTypes.BoolNT AutovalutazioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			TestataValidazioneModificheCollection TestataValidazioneModificheCollectionObj = new TestataValidazioneModificheCollection();

			IDbCommand findCmd = db.InitCmd("Ztestatavalidazionemodifichefindselect", new string[] {"IdTestataequalthis", "IdDomandaPagamentoequalthis", "TipoDomandaPagamentoequalthis", 
"CodFaseequalthis", "DataPresentazioneDomandaPagamentoequalthis", "DomandaApprovataequalthis", 
"SegnaturaApprovazioneDomandaequalthis", "IdProgettoequalthis", "IdLottoequalthis", 
"CfInserimentoequalthis", "DataInserimentoequalthis", "CfModificaequalthis", 
"DataModificaequalthis", "CfValidatoreequalthis", "NominativoValidatoreequalthis", 
"SelezionataXRevisioneequalthis", "Approvataequalthis", "NumeroEstrazioneequalthis", 
"Ordineequalthis", "SegnaturaRevisioneequalthis", "SegnaturaSecondaRevisioneequalthis", 
"DataValidazioneequalthis", "Autovalutazioneequalthis", "CodTipoequalthis", 
"DataApprovazioneequalthis", "IdBandoequalthis", "ProvinciaDiPresentazioneequalthis", 
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "string", 
"string", "DateTime", "bool", 
"string", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"bool", "bool", "int", 
"int", "string", "string", 
"DateTime", "bool", "string", 
"DateTime", "int", "string", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTestataequalthis", IdTestataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDomandaPagamentoequalthis", TipoDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPresentazioneDomandaPagamentoequalthis", DataPresentazioneDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DomandaApprovataequalthis", DomandaApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaApprovazioneDomandaequalthis", SegnaturaApprovazioneDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfValidatoreequalthis", CfValidatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NominativoValidatoreequalthis", NominativoValidatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioneequalthis", NumeroEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRevisioneequalthis", SegnaturaRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaSecondaRevisioneequalthis", SegnaturaSecondaRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValidazioneequalthis", DataValidazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Autovalutazioneequalthis", AutovalutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaDiPresentazioneequalthis", ProvinciaDiPresentazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			TestataValidazioneModifiche TestataValidazioneModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TestataValidazioneModificheObj = GetFromDatareader(db);
				TestataValidazioneModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TestataValidazioneModificheObj.IsDirty = false;
				TestataValidazioneModificheObj.IsPersistent = true;
				TestataValidazioneModificheCollectionObj.Add(TestataValidazioneModificheObj);
			}
			db.Close();
			return TestataValidazioneModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TestataValidazioneModificheCollectionProvider:ITestataValidazioneModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TestataValidazioneModificheCollectionProvider : ITestataValidazioneModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TestataValidazioneModifiche
		protected TestataValidazioneModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TestataValidazioneModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TestataValidazioneModificheCollection(this);
		}

		//Costruttore3: ha in input testatavalidazionemodificheCollectionObj - non popola la collection
		public TestataValidazioneModificheCollectionProvider(TestataValidazioneModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TestataValidazioneModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TestataValidazioneModificheCollection(this);
		}

		//Get e Set
		public TestataValidazioneModificheCollection CollectionObj
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
		public int SaveCollection(TestataValidazioneModificheCollection collectionObj)
		{
			return TestataValidazioneModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TestataValidazioneModifiche testatavalidazionemodificheObj)
		{
			return TestataValidazioneModificheDAL.Save(_dbProviderObj, testatavalidazionemodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TestataValidazioneModificheCollection collectionObj)
		{
			return TestataValidazioneModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TestataValidazioneModifiche testatavalidazionemodificheObj)
		{
			return TestataValidazioneModificheDAL.Delete(_dbProviderObj, testatavalidazionemodificheObj);
		}

		//getById
		public TestataValidazioneModifiche GetById(IntNT IdValue)
		{
			TestataValidazioneModifiche TestataValidazioneModificheTemp = TestataValidazioneModificheDAL.GetById(_dbProviderObj, IdValue);
			if (TestataValidazioneModificheTemp!=null) TestataValidazioneModificheTemp.Provider = this;
			return TestataValidazioneModificheTemp;
		}

		//Select: popola la collection
		public TestataValidazioneModificheCollection Select(IntNT IdtestataEqualThis, IntNT IddomandapagamentoEqualThis, StringNT TipodomandapagamentoEqualThis, 
StringNT CodfaseEqualThis, DatetimeNT DatapresentazionedomandapagamentoEqualThis, BoolNT DomandaapprovataEqualThis, 
StringNT SegnaturaapprovazionedomandaEqualThis, IntNT IdprogettoEqualThis, IntNT IdlottoEqualThis, 
StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfmodificaEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfvalidatoreEqualThis, StringNT NominativovalidatoreEqualThis, 
BoolNT SelezionataxrevisioneEqualThis, BoolNT ApprovataEqualThis, IntNT NumeroestrazioneEqualThis, 
IntNT OrdineEqualThis, StringNT SegnaturarevisioneEqualThis, StringNT SegnaturasecondarevisioneEqualThis, 
DatetimeNT DatavalidazioneEqualThis, BoolNT AutovalutazioneEqualThis, StringNT CodtipoEqualThis, 
DatetimeNT DataapprovazioneEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciadipresentazioneEqualThis, 
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			TestataValidazioneModificheCollection TestataValidazioneModificheCollectionTemp = TestataValidazioneModificheDAL.Select(_dbProviderObj, IdtestataEqualThis, IddomandapagamentoEqualThis, TipodomandapagamentoEqualThis, 
CodfaseEqualThis, DatapresentazionedomandapagamentoEqualThis, DomandaapprovataEqualThis, 
SegnaturaapprovazionedomandaEqualThis, IdprogettoEqualThis, IdlottoEqualThis, 
CfinserimentoEqualThis, DatainserimentoEqualThis, CfmodificaEqualThis, 
DatamodificaEqualThis, CfvalidatoreEqualThis, NominativovalidatoreEqualThis, 
SelezionataxrevisioneEqualThis, ApprovataEqualThis, NumeroestrazioneEqualThis, 
OrdineEqualThis, SegnaturarevisioneEqualThis, SegnaturasecondarevisioneEqualThis, 
DatavalidazioneEqualThis, AutovalutazioneEqualThis, CodtipoEqualThis, 
DataapprovazioneEqualThis, IdbandoEqualThis, ProvinciadipresentazioneEqualThis, 
IdEqualThis, IdmodificaEqualThis);
			TestataValidazioneModificheCollectionTemp.Provider = this;
			return TestataValidazioneModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TESTATA_VALIDAZIONE_MODIFICHE>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</TESTATA_VALIDAZIONE_MODIFICHE>
*/
