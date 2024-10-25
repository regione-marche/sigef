using System;
using System.ComponentModel;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VistruttoriaDomande
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VistruttoriaDomande: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgIntegrato;
		private NullTypes.StringNT _CodStato;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _PartitaIva;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _Istruttore;
		private NullTypes.StringNT _ProvinciaAssegnazione;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.StringNT _ProvinciaDiPresentazione;
		private NullTypes.IntNT _IdIstruttore;
		private NullTypes.StringNT _Via;
		private NullTypes.StringNT _SegnaturaRi;
		private NullTypes.StringNT _FiltroStatoIstruttoria;
		private NullTypes.IntNT _OrdineStato;
		private NullTypes.IntNT _IdImpresa;


		//Costruttore
		public VistruttoriaDomande()
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
		/// Corrisponde al campo:ID_PROG_INTEGRATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgIntegrato
		{
			get { return _IdProgIntegrato; }
			set {
				if (IdProgIntegrato != value)
				{
					_IdProgIntegrato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
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
		/// Corrisponde al campo:PARTITA_IVA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT PartitaIva
		{
			get { return _PartitaIva; }
			set {
				if (PartitaIva != value)
				{
					_PartitaIva = value;
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
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Comune
		{
			get { return _Comune; }
			set {
				if (Comune != value)
				{
					_Comune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SIGLA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Sigla
		{
			get { return _Sigla; }
			set {
				if (Sigla != value)
				{
					_Sigla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set {
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:PROVINCIA_ASSEGNAZIONE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT ProvinciaAssegnazione
		{
			get { return _ProvinciaAssegnazione; }
			set {
				if (ProvinciaAssegnazione != value)
				{
					_ProvinciaAssegnazione = value;
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
		/// Corrisponde al campo:ID_ISTRUTTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstruttore
		{
			get { return _IdIstruttore; }
			set {
				if (IdIstruttore != value)
				{
					_IdIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VIA
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Via
		{
			get { return _Via; }
			set {
				if (Via != value)
				{
					_Via = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_RI
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaRi
		{
			get { return _SegnaturaRi; }
			set {
				if (SegnaturaRi != value)
				{
					_SegnaturaRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FILTRO_STATO_ISTRUTTORIA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT FiltroStatoIstruttoria
		{
			get { return _FiltroStatoIstruttoria; }
			set {
				if (FiltroStatoIstruttoria != value)
				{
					_FiltroStatoIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_STATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineStato
		{
			get { return _OrdineStato; }
			set {
				if (OrdineStato != value)
				{
					_OrdineStato = value;
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




	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vISTRUTTORIA_DOMANDE>
  <ViewName>vISTRUTTORIA_DOMANDE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroIstruttoria>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </FiltroIstruttoria>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vISTRUTTORIA_DOMANDE>
*/