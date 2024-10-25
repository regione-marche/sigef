using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per VariantiEsitiRequisiti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVariantiEsitiRequisitiProvider
	{
		int Save(VariantiEsitiRequisiti VariantiEsitiRequisitiObj);
		int SaveCollection(VariantiEsitiRequisitiCollection collectionObj);
		int Delete(VariantiEsitiRequisiti VariantiEsitiRequisitiObj);
		int DeleteCollection(VariantiEsitiRequisitiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VariantiEsitiRequisiti
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VariantiEsitiRequisiti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.StringNT _CodEsitoIstruttore;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _Istruttore;
		private NullTypes.StringNT _Note;
		private NullTypes.BoolNT _EscludiDaComunicazione;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _QueryEval;
		private NullTypes.StringNT _QueryInsert;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _Misura;
		private NullTypes.StringNT _Esito;
		private NullTypes.BoolNT _EsitoPositivo;
		private NullTypes.StringNT _EsitoIstruttore;
		private NullTypes.BoolNT _EsitoPositivoIstruttore;
		[NonSerialized] private IVariantiEsitiRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiEsitiRequisitiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VariantiEsitiRequisiti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
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
		/// Corrisponde al campo:COD_ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsito
		{
			get { return _CodEsito; }
			set {
				if (CodEsito != value)
				{
					_CodEsito = value;
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
		/// Corrisponde al campo:COD_ESITO_ISTRUTTORE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsitoIstruttore
		{
			get { return _CodEsitoIstruttore; }
			set {
				if (CodEsitoIstruttore != value)
				{
					_CodEsitoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Istruttore
		{
			get { return _Istruttore; }
			set {
				if (Istruttore != value)
				{
					_Istruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESCLUDI_DA_COMUNICAZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT EscludiDaComunicazione
		{
			get { return _EscludiDaComunicazione; }
			set {
				if (EscludiDaComunicazione != value)
				{
					_EscludiDaComunicazione = value;
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
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
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
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
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

		/// <summary>
		/// Corrisponde al campo:ESITO
		/// Tipo sul db:VARCHAR(50)
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
		/// Corrisponde al campo:ESITO_POSITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivo
		{
			get { return _EsitoPositivo; }
			set {
				if (EsitoPositivo != value)
				{
					_EsitoPositivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_ISTRUTTORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT EsitoIstruttore
		{
			get { return _EsitoIstruttore; }
			set {
				if (EsitoIstruttore != value)
				{
					_EsitoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO_ISTRUTTORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivoIstruttore
		{
			get { return _EsitoPositivoIstruttore; }
			set {
				if (EsitoPositivoIstruttore != value)
				{
					_EsitoPositivoIstruttore = value;
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
<VARIANTI_ESITI_REQUISITI>
  <ViewName>vVARIANTI_ESITI_REQUISITI</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO>Equal</ESITO_POSITIVO>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
    </FiltroEsitoPositivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_ESITI_REQUISITI>
*/