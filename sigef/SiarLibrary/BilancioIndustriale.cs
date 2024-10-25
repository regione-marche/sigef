using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per BilancioIndustriale
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBilancioIndustrialeProvider
	{
		int Save(BilancioIndustriale BilancioIndustrialeObj);
		int SaveCollection(BilancioIndustrialeCollection collectionObj);
		int Delete(BilancioIndustriale BilancioIndustrialeObj);
		int DeleteCollection(BilancioIndustrialeCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BilancioIndustriale
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class BilancioIndustriale: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBilancioIndustriale;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _Anno;
		private NullTypes.DatetimeNT _DataBilancio;
		private NullTypes.BoolNT _Previsionale;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.DecimalNT _PlvRicaviVendita;
		private NullTypes.DecimalNT _PlvAltriRicavi;
		private NullTypes.DecimalNT _CpMateriePrime;
		private NullTypes.DecimalNT _CpServizi;
		private NullTypes.DecimalNT _CpBeniTerzi;
		private NullTypes.DecimalNT _CpPersonale;
		private NullTypes.DecimalNT _CpAmmSvalutazioni;
		private NullTypes.DecimalNT _CpVarRimanenze;
		private NullTypes.DecimalNT _CpOneri;
		private NullTypes.DecimalNT _PofAltriProventi;
		private NullTypes.DecimalNT _PofInteressiOneri;
		private NullTypes.DecimalNT _RettValAttFinanziarie;
		private NullTypes.DecimalNT _PosProventiStraord;
		private NullTypes.DecimalNT _PosOneriStraord;
		private NullTypes.DecimalNT _TotPrimaImposte;
		private NullTypes.DecimalNT _ImposteReddito;
		private NullTypes.DecimalNT _TaCreditiSoci;
		private NullTypes.DecimalNT _TaImmImmateriali;
		private NullTypes.DecimalNT _TaImmobMateriali;
		private NullTypes.DecimalNT _TaImmPartecipazioni;
		private NullTypes.DecimalNT _TaImmCrediti;
		private NullTypes.DecimalNT _TaAcRimanenze;
		private NullTypes.DecimalNT _TaAcCreditiClienti;
		private NullTypes.DecimalNT _TaAcCreditiAltri;
		private NullTypes.DecimalNT _TaAcDepPostali;
		private NullTypes.DecimalNT _TaAcDispoLiquide;
		private NullTypes.DecimalNT _TaRateiRisconti;
		private NullTypes.DecimalNT _TpPnCapitale;
		private NullTypes.DecimalNT _TpPnSovrapAzioni;
		private NullTypes.DecimalNT _TpPnRisRivalutazione;
		private NullTypes.DecimalNT _TpPnRisLegale;
		private NullTypes.DecimalNT _TpPnAzioniProprie;
		private NullTypes.DecimalNT _TpPnRiserva904;
		private NullTypes.DecimalNT _TpPnRiserveStatutarie;
		private NullTypes.DecimalNT _TpPnAltreRiserve;
		private NullTypes.DecimalNT _TpPnUtiliPrecedenti;
		private NullTypes.DecimalNT _TpPnUtiliEsercizio;
		private NullTypes.DecimalNT _TpFondiRischiOneri;
		private NullTypes.DecimalNT _TpFineRapporto;
		private NullTypes.DecimalNT _TpDebitiBanche;
		private NullTypes.DecimalNT _TpDebitiFinanziatori;
		private NullTypes.DecimalNT _TpDebitiFornitori;
		private NullTypes.DecimalNT _TpDebitiIstPrevid;
		private NullTypes.DecimalNT _TpAltriDebiti;
		private NullTypes.DecimalNT _TpRateiRisconti;
        private NullTypes.StringNT  _NotaIntegrativa;
		[NonSerialized] private IBilancioIndustrialeProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioIndustrialeProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BilancioIndustriale()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BILANCIO_INDUSTRIALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBilancioIndustriale
		{
			get { return _IdBilancioIndustriale; }
			set {
				if (IdBilancioIndustriale != value)
				{
					_IdBilancioIndustriale = value;
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
		/// Corrisponde al campo:DATA_BILANCIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataBilancio
		{
			get { return _DataBilancio; }
			set {
				if (DataBilancio != value)
				{
					_DataBilancio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREVISIONALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Previsionale
		{
			get { return _Previsionale; }
			set {
				if (Previsionale != value)
				{
					_Previsionale = value;
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
		/// Corrisponde al campo:PLV_RICAVI_VENDITA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRicaviVendita
		{
			get { return _PlvRicaviVendita; }
			set {
				if (PlvRicaviVendita != value)
				{
					_PlvRicaviVendita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_ALTRI_RICAVI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvAltriRicavi
		{
			get { return _PlvAltriRicavi; }
			set {
				if (PlvAltriRicavi != value)
				{
					_PlvAltriRicavi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_MATERIE_PRIME
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpMateriePrime
		{
			get { return _CpMateriePrime; }
			set {
				if (CpMateriePrime != value)
				{
					_CpMateriePrime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_SERVIZI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpServizi
		{
			get { return _CpServizi; }
			set {
				if (CpServizi != value)
				{
					_CpServizi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_BENI_TERZI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpBeniTerzi
		{
			get { return _CpBeniTerzi; }
			set {
				if (CpBeniTerzi != value)
				{
					_CpBeniTerzi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_PERSONALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpPersonale
		{
			get { return _CpPersonale; }
			set {
				if (CpPersonale != value)
				{
					_CpPersonale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_AMM_SVALUTAZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpAmmSvalutazioni
		{
			get { return _CpAmmSvalutazioni; }
			set {
				if (CpAmmSvalutazioni != value)
				{
					_CpAmmSvalutazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_VAR_RIMANENZE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpVarRimanenze
		{
			get { return _CpVarRimanenze; }
			set {
				if (CpVarRimanenze != value)
				{
					_CpVarRimanenze = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CP_ONERI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CpOneri
		{
			get { return _CpOneri; }
			set {
				if (CpOneri != value)
				{
					_CpOneri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:POF_ALTRI_PROVENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PofAltriProventi
		{
			get { return _PofAltriProventi; }
			set {
				if (PofAltriProventi != value)
				{
					_PofAltriProventi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:POF_INTERESSI_ONERI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PofInteressiOneri
		{
			get { return _PofInteressiOneri; }
			set {
				if (PofInteressiOneri != value)
				{
					_PofInteressiOneri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RETT_VAL_ATT_FINANZIARIE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RettValAttFinanziarie
		{
			get { return _RettValAttFinanziarie; }
			set {
				if (RettValAttFinanziarie != value)
				{
					_RettValAttFinanziarie = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:POS_PROVENTI_STRAORD
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PosProventiStraord
		{
			get { return _PosProventiStraord; }
			set {
				if (PosProventiStraord != value)
				{
					_PosProventiStraord = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:POS_ONERI_STRAORD
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PosOneriStraord
		{
			get { return _PosOneriStraord; }
			set {
				if (PosOneriStraord != value)
				{
					_PosOneriStraord = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOT_PRIMA_IMPOSTE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TotPrimaImposte
		{
			get { return _TotPrimaImposte; }
			set {
				if (TotPrimaImposte != value)
				{
					_TotPrimaImposte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPOSTE_REDDITO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImposteReddito
		{
			get { return _ImposteReddito; }
			set {
				if (ImposteReddito != value)
				{
					_ImposteReddito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_CREDITI_SOCI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaCreditiSoci
		{
			get { return _TaCreditiSoci; }
			set {
				if (TaCreditiSoci != value)
				{
					_TaCreditiSoci = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_IMM_IMMATERIALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaImmImmateriali
		{
			get { return _TaImmImmateriali; }
			set {
				if (TaImmImmateriali != value)
				{
					_TaImmImmateriali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_IMMOB_MATERIALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaImmobMateriali
		{
			get { return _TaImmobMateriali; }
			set {
				if (TaImmobMateriali != value)
				{
					_TaImmobMateriali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_IMM_PARTECIPAZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaImmPartecipazioni
		{
			get { return _TaImmPartecipazioni; }
			set {
				if (TaImmPartecipazioni != value)
				{
					_TaImmPartecipazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_IMM_CREDITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaImmCrediti
		{
			get { return _TaImmCrediti; }
			set {
				if (TaImmCrediti != value)
				{
					_TaImmCrediti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_AC_RIMANENZE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAcRimanenze
		{
			get { return _TaAcRimanenze; }
			set {
				if (TaAcRimanenze != value)
				{
					_TaAcRimanenze = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_AC_CREDITI_CLIENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAcCreditiClienti
		{
			get { return _TaAcCreditiClienti; }
			set {
				if (TaAcCreditiClienti != value)
				{
					_TaAcCreditiClienti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_AC_CREDITI_ALTRI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAcCreditiAltri
		{
			get { return _TaAcCreditiAltri; }
			set {
				if (TaAcCreditiAltri != value)
				{
					_TaAcCreditiAltri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_AC_DEP_POSTALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAcDepPostali
		{
			get { return _TaAcDepPostali; }
			set {
				if (TaAcDepPostali != value)
				{
					_TaAcDepPostali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_AC_DISPO_LIQUIDE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAcDispoLiquide
		{
			get { return _TaAcDispoLiquide; }
			set {
				if (TaAcDispoLiquide != value)
				{
					_TaAcDispoLiquide = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_RATEI_RISCONTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaRateiRisconti
		{
			get { return _TaRateiRisconti; }
			set {
				if (TaRateiRisconti != value)
				{
					_TaRateiRisconti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_CAPITALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnCapitale
		{
			get { return _TpPnCapitale; }
			set {
				if (TpPnCapitale != value)
				{
					_TpPnCapitale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_SOVRAP_AZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnSovrapAzioni
		{
			get { return _TpPnSovrapAzioni; }
			set {
				if (TpPnSovrapAzioni != value)
				{
					_TpPnSovrapAzioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_RIS_RIVALUTAZIONE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnRisRivalutazione
		{
			get { return _TpPnRisRivalutazione; }
			set {
				if (TpPnRisRivalutazione != value)
				{
					_TpPnRisRivalutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_RIS_LEGALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnRisLegale
		{
			get { return _TpPnRisLegale; }
			set {
				if (TpPnRisLegale != value)
				{
					_TpPnRisLegale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_AZIONI_PROPRIE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnAzioniProprie
		{
			get { return _TpPnAzioniProprie; }
			set {
				if (TpPnAzioniProprie != value)
				{
					_TpPnAzioniProprie = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_RISERVA_904
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnRiserva904
		{
			get { return _TpPnRiserva904; }
			set {
				if (TpPnRiserva904 != value)
				{
					_TpPnRiserva904 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_RISERVE_STATUTARIE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnRiserveStatutarie
		{
			get { return _TpPnRiserveStatutarie; }
			set {
				if (TpPnRiserveStatutarie != value)
				{
					_TpPnRiserveStatutarie = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_ALTRE_RISERVE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnAltreRiserve
		{
			get { return _TpPnAltreRiserve; }
			set {
				if (TpPnAltreRiserve != value)
				{
					_TpPnAltreRiserve = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_UTILI_PRECEDENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnUtiliPrecedenti
		{
			get { return _TpPnUtiliPrecedenti; }
			set {
				if (TpPnUtiliPrecedenti != value)
				{
					_TpPnUtiliPrecedenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PN_UTILI_ESERCIZIO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPnUtiliEsercizio
		{
			get { return _TpPnUtiliEsercizio; }
			set {
				if (TpPnUtiliEsercizio != value)
				{
					_TpPnUtiliEsercizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_FONDI_RISCHI_ONERI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpFondiRischiOneri
		{
			get { return _TpFondiRischiOneri; }
			set {
				if (TpFondiRischiOneri != value)
				{
					_TpFondiRischiOneri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_FINE_RAPPORTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpFineRapporto
		{
			get { return _TpFineRapporto; }
			set {
				if (TpFineRapporto != value)
				{
					_TpFineRapporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_DEBITI_BANCHE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpDebitiBanche
		{
			get { return _TpDebitiBanche; }
			set {
				if (TpDebitiBanche != value)
				{
					_TpDebitiBanche = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_DEBITI_FINANZIATORI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpDebitiFinanziatori
		{
			get { return _TpDebitiFinanziatori; }
			set {
				if (TpDebitiFinanziatori != value)
				{
					_TpDebitiFinanziatori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_DEBITI_FORNITORI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpDebitiFornitori
		{
			get { return _TpDebitiFornitori; }
			set {
				if (TpDebitiFornitori != value)
				{
					_TpDebitiFornitori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_DEBITI_IST_PREVID
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpDebitiIstPrevid
		{
			get { return _TpDebitiIstPrevid; }
			set {
				if (TpDebitiIstPrevid != value)
				{
					_TpDebitiIstPrevid = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_ALTRI_DEBITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpAltriDebiti
		{
			get { return _TpAltriDebiti; }
			set {
				if (TpAltriDebiti != value)
				{
					_TpAltriDebiti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_RATEI_RISCONTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpRateiRisconti
		{
			get { return _TpRateiRisconti; }
			set {
				if (TpRateiRisconti != value)
				{
					_TpRateiRisconti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_RATEI_RISCONTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
        public NullTypes.StringNT NotaIntegrativa
		{
            get { return _NotaIntegrativa; }
			set {
                if (NotaIntegrativa != value)
				{
                    _NotaIntegrativa = value;
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
<BILANCIO_INDUSTRIALE>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ID_BILANCIO_INDUSTRIALE>Equal</ID_BILANCIO_INDUSTRIALE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ANNO>Equal</ANNO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <PREVISIONALE>Equal</PREVISIONALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroPrevisionale>
      <PREVISIONALE>Equal</PREVISIONALE>
    </FiltroPrevisionale>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BILANCIO_INDUSTRIALE>
*/