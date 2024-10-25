using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per IterProgetto
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIterProgettoProvider
	{
		int Save(IterProgetto IterProgettoObj);
		int SaveCollection(IterProgettoCollection collectionObj);
		int Delete(IterProgetto IterProgettoObj);
		int DeleteCollection(IterProgettoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IterProgetto
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class IterProgetto: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdStep;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _CodEsitoRevisore;
		private NullTypes.DatetimeNT _DataRevisore;
		private NullTypes.StringNT _Revisore;
		private NullTypes.StringNT _NoteRevisore;
		private NullTypes.StringNT _EsitoIstruttore;
		private NullTypes.BoolNT _EsitoPositivoIstruttore;
		private NullTypes.StringNT _EsitoRevisore;
		private NullTypes.BoolNT _EsitoPositivoRevisore;
		private NullTypes.IntNT _IdBando;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.IntNT _IdCheckList;
		private NullTypes.StringNT _CodFase;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.StringNT _Step;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IIterProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIterProgettoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public IterProgetto()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStep
		{
			get { return _IdStep; }
			set {
				if (IdStep != value)
				{
					_IdStep = value;
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
		/// Corrisponde al campo:COD_ESITO_REVISORE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsitoRevisore
		{
			get { return _CodEsitoRevisore; }
			set {
				if (CodEsitoRevisore != value)
				{
					_CodEsitoRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_REVISORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRevisore
		{
			get { return _DataRevisore; }
			set {
				if (DataRevisore != value)
				{
					_DataRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REVISORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Revisore
		{
			get { return _Revisore; }
			set {
				if (Revisore != value)
				{
					_Revisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_REVISORE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT NoteRevisore
		{
			get { return _NoteRevisore; }
			set {
				if (NoteRevisore != value)
				{
					_NoteRevisore = value;
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

		/// <summary>
		/// Corrisponde al campo:ESITO_REVISORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT EsitoRevisore
		{
			get { return _EsitoRevisore; }
			set {
				if (EsitoRevisore != value)
				{
					_EsitoRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO_REVISORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivoRevisore
		{
			get { return _EsitoPositivoRevisore; }
			set {
				if (EsitoPositivoRevisore != value)
				{
					_EsitoPositivoRevisore = value;
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
		/// Corrisponde al campo:ID_CHECK_LIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCheckList
		{
			get { return _IdCheckList; }
			set {
				if (IdCheckList != value)
				{
					_IdCheckList = value;
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
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
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
		/// Corrisponde al campo:STEP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Step
		{
			get { return _Step; }
			set {
				if (Step != value)
				{
					_Step = value;
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
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set {
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set {
				if (CodeMethod != value)
				{
					_CodeMethod = value;
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
		/// Tipo sul db:VARCHAR(20)
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
<ITER_PROGETTO>
  <ViewName>vITER_PROGETTO</ViewName>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_STEP>Equal</ID_STEP>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
      <ID_BANDO>Equal</ID_BANDO>
      <COD_FASE>Equal</COD_FASE>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsito>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
    </FiltroEsito>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
      <ESITO_POSITIVO_REVISORE>Equal</ESITO_POSITIVO_REVISORE>
    </FiltroEsitoPositivo>
    <FiltroNonInRevisione>
      <COD_ESITO_REVISORE>IsNull</COD_ESITO_REVISORE>
    </FiltroNonInRevisione>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ITER_PROGETTO>
*/