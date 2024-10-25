using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per DomandaDiPagamentoSegnature
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaDiPagamentoSegnatureProvider
	{
		int Save(DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj);
		int SaveCollection(DomandaDiPagamentoSegnatureCollection collectionObj);
		int Delete(DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj);
		int DeleteCollection(DomandaDiPagamentoSegnatureCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaDiPagamentoSegnature
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class DomandaDiPagamentoSegnature: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _Motivazione;
		private NullTypes.BoolNT _RiapriDomanda;
		[NonSerialized] private IDomandaDiPagamentoSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaDiPagamentoSegnatureProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DomandaDiPagamentoSegnature()
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
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:CHAR(16)
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
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Motivazione
		{
			get { return _Motivazione; }
			set {
				if (Motivazione != value)
				{
					_Motivazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIAPRI_DOMANDA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RiapriDomanda
		{
			get { return _RiapriDomanda; }
			set {
				if (RiapriDomanda != value)
				{
					_RiapriDomanda = value;
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
<DOMANDA_DI_PAGAMENTO_SEGNATURE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO_SEGNATURE>
*/