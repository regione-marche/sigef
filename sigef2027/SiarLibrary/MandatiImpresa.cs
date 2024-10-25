using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per MandatiImpresa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IMandatiImpresaProvider
	{
		int Save(MandatiImpresa MandatiImpresaObj);
		int SaveCollection(MandatiImpresaCollection collectionObj);
		int Delete(MandatiImpresa MandatiImpresaObj);
		int DeleteCollection(MandatiImpresaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for MandatiImpresa
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class MandatiImpresa: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdUtenteAbilitato;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _CodiceSportelloCaa;
		private NullTypes.StringNT _TipoMandato;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.IntNT _IdOperatoreInizio;
		private NullTypes.IntNT _IdOperatoreFine;
		private NullTypes.StringNT _SegnaturaMandato;
		private NullTypes.StringNT _SegnaturaRevoca;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.IntNT _AnnoCostituzione;
		private NullTypes.IntNT _IdStoricoUltimo;
		private NullTypes.IntNT _IdContoCorrenteUltimo;
		private NullTypes.IntNT _IdRapprlegaleUltimo;
		private NullTypes.IntNT _IdSedelegaleUltimo;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _CodFormaGiuridica;
		private NullTypes.IntNT _IdDimensione;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.StringNT _Ente;
		[NonSerialized] private IMandatiImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IMandatiImpresaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public MandatiImpresa()
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
		/// Corrisponde al campo:ID_UTENTE_ABILITATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtenteAbilitato
		{
			get { return _IdUtenteAbilitato; }
			set {
				if (IdUtenteAbilitato != value)
				{
					_IdUtenteAbilitato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_SPORTELLO_CAA
		/// Tipo sul db:CHAR(9)
		/// </summary>
		public NullTypes.StringNT CodiceSportelloCaa
		{
			get { return _CodiceSportelloCaa; }
			set {
				if (CodiceSportelloCaa != value)
				{
					_CodiceSportelloCaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_MANDATO
		/// Tipo sul db:CHAR(3)
		/// Default:((0))
		/// </summary>
		public NullTypes.StringNT TipoMandato
		{
			get { return _TipoMandato; }
			set {
				if (TipoMandato != value)
				{
					_TipoMandato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_INIZIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreInizio
		{
			get { return _IdOperatoreInizio; }
			set {
				if (IdOperatoreInizio != value)
				{
					_IdOperatoreInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_FINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreFine
		{
			get { return _IdOperatoreFine; }
			set {
				if (IdOperatoreFine != value)
				{
					_IdOperatoreFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_MANDATO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaMandato
		{
			get { return _SegnaturaMandato; }
			set {
				if (SegnaturaMandato != value)
				{
					_SegnaturaMandato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_REVOCA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaRevoca
		{
			get { return _SegnaturaRevoca; }
			set {
				if (SegnaturaRevoca != value)
				{
					_SegnaturaRevoca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_COSTITUZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT AnnoCostituzione
		{
			get { return _AnnoCostituzione; }
			set {
				if (AnnoCostituzione != value)
				{
					_AnnoCostituzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_STORICO_ULTIMO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStoricoUltimo
		{
			get { return _IdStoricoUltimo; }
			set {
				if (IdStoricoUltimo != value)
				{
					_IdStoricoUltimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CONTO_CORRENTE_ULTIMO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdContoCorrenteUltimo
		{
			get { return _IdContoCorrenteUltimo; }
			set {
				if (IdContoCorrenteUltimo != value)
				{
					_IdContoCorrenteUltimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RAPPRLEGALE_ULTIMO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRapprlegaleUltimo
		{
			get { return _IdRapprlegaleUltimo; }
			set {
				if (IdRapprlegaleUltimo != value)
				{
					_IdRapprlegaleUltimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SEDELEGALE_ULTIMO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSedelegaleUltimo
		{
			get { return _IdSedelegaleUltimo; }
			set {
				if (IdSedelegaleUltimo != value)
				{
					_IdSedelegaleUltimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodFormaGiuridica
		{
			get { return _CodFormaGiuridica; }
			set {
				if (CodFormaGiuridica != value)
				{
					_CodFormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimensione
		{
			get { return _IdDimensione; }
			set {
				if (IdDimensione != value)
				{
					_IdDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
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
<MANDATI_IMPRESA>
  <ViewName>vMANDATI_IMPRESA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, RAGIONE_SOCIALE">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <ID_UTENTE_ABILITATO>Equal</ID_UTENTE_ABILITATO>
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivoTipoMandato>
      <ATTIVO>Equal</ATTIVO>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
    </FiltroAttivoTipoMandato>
  </Filters>
  <externalFields />
  <AddedFkFields />
</MANDATI_IMPRESA>
*/