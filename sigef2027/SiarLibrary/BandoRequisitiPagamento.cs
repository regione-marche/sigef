using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per BandoRequisitiPagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoRequisitiPagamentoProvider
	{
		int Save(BandoRequisitiPagamento BandoRequisitiPagamentoObj);
		int SaveCollection(BandoRequisitiPagamentoCollection collectionObj);
		int Delete(BandoRequisitiPagamento BandoRequisitiPagamentoObj);
		int DeleteCollection(BandoRequisitiPagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoRequisitiPagamento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class BandoRequisitiPagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.BoolNT _RequisitoDiControllo;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _Fase;
		private NullTypes.IntNT _OrdineFase;
		private NullTypes.StringNT _Requisito;
		private NullTypes.BoolNT _Plurivalore;
		private NullTypes.BoolNT _Numerico;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _QueryEval;
		private NullTypes.StringNT _QueryInsert;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _RequisitoDiInserimento;
		[NonSerialized] private IBandoRequisitiPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRequisitiPagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoRequisitiPagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REQUISITO_DI_CONTROLLO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RequisitoDiControllo
		{
			get { return _RequisitoDiControllo; }
			set {
				if (RequisitoDiControllo != value)
				{
					_RequisitoDiControllo = value;
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
		/// Corrisponde al campo:FASE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Fase
		{
			get { return _Fase; }
			set {
				if (Fase != value)
				{
					_Fase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FASE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFase
		{
			get { return _OrdineFase; }
			set {
				if (OrdineFase != value)
				{
					_OrdineFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REQUISITO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Requisito
		{
			get { return _Requisito; }
			set {
				if (Requisito != value)
				{
					_Requisito = value;
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
		/// Corrisponde al campo:REQUISITO_DI_INSERIMENTO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RequisitoDiInserimento
		{
			get { return _RequisitoDiInserimento; }
			set {
				if (RequisitoDiInserimento != value)
				{
					_RequisitoDiInserimento = value;
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
<BANDO_REQUISITI_PAGAMENTO>
  <ViewName>vBANDO_REQUISITI_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, ORDINE_FASE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroDiControllo>
      <REQUISITO_DI_CONTROLLO>Equal</REQUISITO_DI_CONTROLLO>
    </FiltroDiControllo>
    <FiltroDiInserimento>
      <REQUISITO_DI_INSERIMENTO>Equal</REQUISITO_DI_INSERIMENTO>
    </FiltroDiInserimento>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_PAGAMENTO>
*/