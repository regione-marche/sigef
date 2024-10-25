using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ControlliDomandePagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IControlliDomandePagamentoProvider
	{
		int Save(ControlliDomandePagamento ControlliDomandePagamentoObj);
		int SaveCollection(ControlliDomandePagamentoCollection collectionObj);
		int Delete(ControlliDomandePagamento ControlliDomandePagamentoObj);
		int DeleteCollection(ControlliDomandePagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ControlliDomandePagamento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ControlliDomandePagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _OperatoreAssegnato;
		private NullTypes.BoolNT _SelezionataXControllo;
		private NullTypes.StringNT _TipoEstrazione;
		private NullTypes.BoolNT _ControlloConcluso;
		private NullTypes.DecimalNT _ValoreDiRischio;
		private NullTypes.DecimalNT _ContributoRichiesto;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _DataPresentazioneDomandaPagamento;
		private NullTypes.StringNT _ClasseDiRischio;
		private NullTypes.IntNT _OrdineClasseDiRischio;
		[NonSerialized] private IControlliDomandePagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliDomandePagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ControlliDomandePagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreAssegnato
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
		/// Default:((0))
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
		/// Corrisponde al campo:CONTROLLO_CONCLUSO
		/// Tipo sul db:BIT
		/// Default:((0))
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
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
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
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_DOMANDE_PAGAMENTO>
  <ViewName>vCONTROLLI_DOMANDE_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlli>
      <SELEZIONATA_X_CONTROLLO>Equal</SELEZIONATA_X_CONTROLLO>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlli>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_DOMANDE_PAGAMENTO>
*/