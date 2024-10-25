using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per PianoDiSviluppoDomandaPagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPianoDiSviluppoDomandaPagamentoProvider
	{
		int Save(PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj);
		int SaveCollection(PianoDiSviluppoDomandaPagamentoCollection collectionObj);
		int Delete(PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj);
		int DeleteCollection(PianoDiSviluppoDomandaPagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PianoDiSviluppoDomandaPagamento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class PianoDiSviluppoDomandaPagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPiano;
		private NullTypes.IntNT _Anno;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DecimalNT _CostoInvestimento;
		private NullTypes.DecimalNT _MezziPropri;
		private NullTypes.DecimalNT _RisorseTerzi;
		private NullTypes.DecimalNT _ContributiPubblici;
		private NullTypes.DecimalNT _SpeseGestione;
		private NullTypes.DecimalNT _RimborsoDebito;
		private NullTypes.DecimalNT _EntrataGestione;
		private NullTypes.DecimalNT _AltreCoperture;
		[NonSerialized] private IPianoDiSviluppoDomandaPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPianoDiSviluppoDomandaPagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PianoDiSviluppoDomandaPagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PIANO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPiano
		{
			get { return _IdPiano; }
			set {
				if (IdPiano != value)
				{
					_IdPiano = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
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
		/// Corrisponde al campo:COSTO_INVESTIMENTO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT CostoInvestimento
		{
			get { return _CostoInvestimento; }
			set {
				if (CostoInvestimento != value)
				{
					_CostoInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MEZZI_PROPRI
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT MezziPropri
		{
			get { return _MezziPropri; }
			set {
				if (MezziPropri != value)
				{
					_MezziPropri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RISORSE_TERZI
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT RisorseTerzi
		{
			get { return _RisorseTerzi; }
			set {
				if (RisorseTerzi != value)
				{
					_RisorseTerzi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTI_PUBBLICI
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ContributiPubblici
		{
			get { return _ContributiPubblici; }
			set {
				if (ContributiPubblici != value)
				{
					_ContributiPubblici = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESE_GESTIONE
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT SpeseGestione
		{
			get { return _SpeseGestione; }
			set {
				if (SpeseGestione != value)
				{
					_SpeseGestione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIMBORSO_DEBITO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT RimborsoDebito
		{
			get { return _RimborsoDebito; }
			set {
				if (RimborsoDebito != value)
				{
					_RimborsoDebito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTRATA_GESTIONE
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT EntrataGestione
		{
			get { return _EntrataGestione; }
			set {
				if (EntrataGestione != value)
				{
					_EntrataGestione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALTRE_COPERTURE
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT AltreCoperture
		{
			get { return _AltreCoperture; }
			set {
				if (AltreCoperture != value)
				{
					_AltreCoperture = value;
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
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ANNO DESC">
      <ANNO>Equal</ANNO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
*/