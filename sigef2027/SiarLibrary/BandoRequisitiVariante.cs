using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per BandoRequisitiVariante
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoRequisitiVarianteProvider
	{
		int Save(BandoRequisitiVariante BandoRequisitiVarianteObj);
		int SaveCollection(BandoRequisitiVarianteCollection collectionObj);
		int Delete(BandoRequisitiVariante BandoRequisitiVarianteObj);
		int DeleteCollection(BandoRequisitiVarianteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoRequisitiVariante
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class BandoRequisitiVariante: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.BoolNT _RequisitoDiPresentazione;
		private NullTypes.BoolNT _RequisitoDiIstruttoria;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _QueryEval;
		private NullTypes.StringNT _QueryInsert;
		private NullTypes.DecimalNT _ValMinimo;
		private NullTypes.DecimalNT _ValMassimo;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IBandoRequisitiVarianteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRequisitiVarianteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoRequisitiVariante()
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
		/// Tipo sul db:CHAR(2)
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
		/// Corrisponde al campo:REQUISITO_DI_PRESENTAZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RequisitoDiPresentazione
		{
			get { return _RequisitoDiPresentazione; }
			set {
				if (RequisitoDiPresentazione != value)
				{
					_RequisitoDiPresentazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REQUISITO_DI_ISTRUTTORIA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RequisitoDiIstruttoria
		{
			get { return _RequisitoDiIstruttoria; }
			set {
				if (RequisitoDiIstruttoria != value)
				{
					_RequisitoDiIstruttoria = value;
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
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
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
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValMinimo
		{
			get { return _ValMinimo; }
			set {
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValMassimo
		{
			get { return _ValMassimo; }
			set {
				if (ValMassimo != value)
				{
					_ValMassimo = value;
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
<BANDO_REQUISITI_VARIANTE>
  <ViewName>vBANDO_REQUISITI_VARIANTE</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProcedura>
      <REQUISITO_DI_PRESENTAZIONE>Equal</REQUISITO_DI_PRESENTAZIONE>
      <REQUISITO_DI_ISTRUTTORIA>Equal</REQUISITO_DI_ISTRUTTORIA>
    </FiltroProcedura>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_VARIANTE>
*/