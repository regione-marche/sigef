using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per DomandaPagamentoRequisiti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDomandaPagamentoRequisitiProvider
	{
		int Save(DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj);
		int SaveCollection(DomandaPagamentoRequisitiCollection collectionObj);
		int Delete(DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj);
		int DeleteCollection(DomandaPagamentoRequisitiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DomandaPagamentoRequisiti
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class DomandaPagamentoRequisiti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.IntNT _IdValore;
		private NullTypes.DecimalNT _ValNumerico;
		private NullTypes.DatetimeNT _ValData;
		private NullTypes.StringNT _ValTesto;
		private NullTypes.StringNT _Esito;
		private NullTypes.DatetimeNT _DataEsito;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Plurivalore;
		private NullTypes.BoolNT _Numerico;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _QueryEval;
		private NullTypes.StringNT _QueryInsert;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _CodiceValore;
		private NullTypes.StringNT _DescrizioneValore;
		private NullTypes.BoolNT _Selezionato;
		[NonSerialized] private IDomandaPagamentoRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoRequisitiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DomandaPagamentoRequisiti()
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
		/// Corrisponde al campo:ID_REQUISITO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRequisito
		{
			get { return _IdRequisito; }
			set {
				if (IdRequisito != value)
				{
					_IdRequisito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VALORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValore
		{
			get { return _IdValore; }
			set {
				if (IdValore != value)
				{
					_IdValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_NUMERICO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValNumerico
		{
			get { return _ValNumerico; }
			set {
				if (ValNumerico != value)
				{
					_ValNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT ValData
		{
			get { return _ValData; }
			set {
				if (ValData != value)
				{
					_ValData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_TESTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT ValTesto
		{
			get { return _ValTesto; }
			set {
				if (ValTesto != value)
				{
					_ValTesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Esito
		{
			get { return _Esito; }
			set {
				if (Esito != value)
				{
					_Esito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ESITO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataEsito
		{
			get { return _DataEsito; }
			set {
				if (DataEsito != value)
				{
					_DataEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:PLURIVALORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Plurivalore
		{
			get { return _Plurivalore; }
			set {
				if (Plurivalore != value)
				{
					_Plurivalore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Numerico
		{
			get { return _Numerico; }
			set {
				if (Numerico != value)
				{
					_Numerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATETIME
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Datetime
		{
			get { return _Datetime; }
			set {
				if (Datetime != value)
				{
					_Datetime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_SEMPLICE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoSemplice
		{
			get { return _TestoSemplice; }
			set {
				if (TestoSemplice != value)
				{
					_TestoSemplice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_AREA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT TestoArea
		{
			get { return _TestoArea; }
			set {
				if (TestoArea != value)
				{
					_TestoArea = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_EVAL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QueryEval
		{
			get { return _QueryEval; }
			set {
				if (QueryEval != value)
				{
					_QueryEval = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_INSERT
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QueryInsert
		{
			get { return _QueryInsert; }
			set {
				if (QueryInsert != value)
				{
					_QueryInsert = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_VALORE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodiceValore
		{
			get { return _CodiceValore; }
			set {
				if (CodiceValore != value)
				{
					_CodiceValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_VALORE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneValore
		{
			get { return _DescrizioneValore; }
			set {
				if (DescrizioneValore != value)
				{
					_DescrizioneValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SELEZIONATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Selezionato
		{
			get { return _Selezionato; }
			set {
				if (Selezionato != value)
				{
					_Selezionato = value;
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
<DOMANDA_PAGAMENTO_REQUISITI>
  <ViewName>vDOMANDA_REQUISITI_PAGAMENTO</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <PLURIVALORE>Equal</PLURIVALORE>
      <NUMERICO>Equal</NUMERICO>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <URL>IsNull</URL>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_REQUISITI>
*/