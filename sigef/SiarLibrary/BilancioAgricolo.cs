using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per BilancioAgricolo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBilancioAgricoloProvider
	{
		int Save(BilancioAgricolo BilancioAgricoloObj);
		int SaveCollection(BilancioAgricoloCollection collectionObj);
		int Delete(BilancioAgricolo BilancioAgricoloObj);
		int DeleteCollection(BilancioAgricoloCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BilancioAgricolo
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class BilancioAgricolo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBilancioAgricolo;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _Anno;
		private NullTypes.DatetimeNT _DataBilancio;
		private NullTypes.BoolNT _Previsionale;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.DecimalNT _PlvRicaviNetti;
		private NullTypes.DecimalNT _PlvRicaviAttivita;
		private NullTypes.DecimalNT _PlvRimanenzeFinali;
		private NullTypes.DecimalNT _PlvRimanenzeIniziali;
		private NullTypes.DecimalNT _VaCostiMatPrime;
		private NullTypes.DecimalNT _VaCostiAttConnesse;
		private NullTypes.DecimalNT _VaNoleggi;
		private NullTypes.DecimalNT _VaManutenzioni;
		private NullTypes.DecimalNT _VaSpeseGenerali;
		private NullTypes.DecimalNT _VaAffitti;
		private NullTypes.DecimalNT _VaAltriCosti;
		private NullTypes.DecimalNT _PnAmmMacchine;
		private NullTypes.DecimalNT _PnAmmFabbricati;
		private NullTypes.DecimalNT _PnAmmPiantagioni;
		private NullTypes.DecimalNT _RoSalari;
		private NullTypes.DecimalNT _RoOneri;
		private NullTypes.DecimalNT _RnPacRicavi;
		private NullTypes.DecimalNT _RnPacCosti;
		private NullTypes.DecimalNT _RnPacProventi;
		private NullTypes.DecimalNT _RnPacPerdite;
		private NullTypes.DecimalNT _RnPacInteressiAttivi;
		private NullTypes.DecimalNT _RnPacInteressiPassivi;
		private NullTypes.DecimalNT _RnPacImposte;
		private NullTypes.DecimalNT _RnPacContributiPac;
		private NullTypes.DecimalNT _MnlRedditiFam;
		private NullTypes.DecimalNT _MnlRimborso;
		private NullTypes.DecimalNT _MnlPrelievi;
		private NullTypes.DecimalNT _CfCfTerreni;
		private NullTypes.DecimalNT _CfCfImpianti;
		private NullTypes.DecimalNT _CfCfPiantagioni;
		private NullTypes.DecimalNT _CfCfMiglioramenti;
		private NullTypes.DecimalNT _CfCaMacchine;
		private NullTypes.DecimalNT _CfCaBestiame;
		private NullTypes.DecimalNT _CfIfPartecipazioni;
		private NullTypes.DecimalNT _CcDfRimanenze;
		private NullTypes.DecimalNT _CcDfAnticipazioni;
		private NullTypes.DecimalNT _CcLdCrediti;
		private NullTypes.DecimalNT _CcLiBanca;
		private NullTypes.DecimalNT _CcLiCassa;
		private NullTypes.DecimalNT _FfPcDebitiBreveTermine;
		private NullTypes.DecimalNT _FfPcFornitori;
		private NullTypes.DecimalNT _FfPcDebiti;
		private NullTypes.DecimalNT _FfPcMutui;
		private NullTypes.DecimalNT _FfMpCapitale;
		private NullTypes.DecimalNT _FfMpRiserve;
		private NullTypes.DecimalNT _FfMpUtile;
		[NonSerialized] private IBilancioAgricoloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioAgricoloProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BilancioAgricolo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BILANCIO_AGRICOLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBilancioAgricolo
		{
			get { return _IdBilancioAgricolo; }
			set {
				if (IdBilancioAgricolo != value)
				{
					_IdBilancioAgricolo = value;
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
		/// Corrisponde al campo:PLV_RICAVI_NETTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRicaviNetti
		{
			get { return _PlvRicaviNetti; }
			set {
				if (PlvRicaviNetti != value)
				{
					_PlvRicaviNetti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_RICAVI_ATTIVITA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRicaviAttivita
		{
			get { return _PlvRicaviAttivita; }
			set {
				if (PlvRicaviAttivita != value)
				{
					_PlvRicaviAttivita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_RIMANENZE_FINALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRimanenzeFinali
		{
			get { return _PlvRimanenzeFinali; }
			set {
				if (PlvRimanenzeFinali != value)
				{
					_PlvRimanenzeFinali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_RIMANENZE_INIZIALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRimanenzeIniziali
		{
			get { return _PlvRimanenzeIniziali; }
			set {
				if (PlvRimanenzeIniziali != value)
				{
					_PlvRimanenzeIniziali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_COSTI_MAT_PRIME
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaCostiMatPrime
		{
			get { return _VaCostiMatPrime; }
			set {
				if (VaCostiMatPrime != value)
				{
					_VaCostiMatPrime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_COSTI_ATT_CONNESSE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaCostiAttConnesse
		{
			get { return _VaCostiAttConnesse; }
			set {
				if (VaCostiAttConnesse != value)
				{
					_VaCostiAttConnesse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_NOLEGGI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaNoleggi
		{
			get { return _VaNoleggi; }
			set {
				if (VaNoleggi != value)
				{
					_VaNoleggi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_MANUTENZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaManutenzioni
		{
			get { return _VaManutenzioni; }
			set {
				if (VaManutenzioni != value)
				{
					_VaManutenzioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_SPESE_GENERALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaSpeseGenerali
		{
			get { return _VaSpeseGenerali; }
			set {
				if (VaSpeseGenerali != value)
				{
					_VaSpeseGenerali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_AFFITTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaAffitti
		{
			get { return _VaAffitti; }
			set {
				if (VaAffitti != value)
				{
					_VaAffitti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VA_ALTRI_COSTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT VaAltriCosti
		{
			get { return _VaAltriCosti; }
			set {
				if (VaAltriCosti != value)
				{
					_VaAltriCosti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PN_AMM_MACCHINE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PnAmmMacchine
		{
			get { return _PnAmmMacchine; }
			set {
				if (PnAmmMacchine != value)
				{
					_PnAmmMacchine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PN_AMM_FABBRICATI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PnAmmFabbricati
		{
			get { return _PnAmmFabbricati; }
			set {
				if (PnAmmFabbricati != value)
				{
					_PnAmmFabbricati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PN_AMM_PIANTAGIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PnAmmPiantagioni
		{
			get { return _PnAmmPiantagioni; }
			set {
				if (PnAmmPiantagioni != value)
				{
					_PnAmmPiantagioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RO_SALARI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RoSalari
		{
			get { return _RoSalari; }
			set {
				if (RoSalari != value)
				{
					_RoSalari = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RO_ONERI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RoOneri
		{
			get { return _RoOneri; }
			set {
				if (RoOneri != value)
				{
					_RoOneri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_RICAVI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacRicavi
		{
			get { return _RnPacRicavi; }
			set {
				if (RnPacRicavi != value)
				{
					_RnPacRicavi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_COSTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacCosti
		{
			get { return _RnPacCosti; }
			set {
				if (RnPacCosti != value)
				{
					_RnPacCosti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_PROVENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacProventi
		{
			get { return _RnPacProventi; }
			set {
				if (RnPacProventi != value)
				{
					_RnPacProventi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_PERDITE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacPerdite
		{
			get { return _RnPacPerdite; }
			set {
				if (RnPacPerdite != value)
				{
					_RnPacPerdite = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_INTERESSI_ATTIVI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacInteressiAttivi
		{
			get { return _RnPacInteressiAttivi; }
			set {
				if (RnPacInteressiAttivi != value)
				{
					_RnPacInteressiAttivi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_INTERESSI_PASSIVI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacInteressiPassivi
		{
			get { return _RnPacInteressiPassivi; }
			set {
				if (RnPacInteressiPassivi != value)
				{
					_RnPacInteressiPassivi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_IMPOSTE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacImposte
		{
			get { return _RnPacImposte; }
			set {
				if (RnPacImposte != value)
				{
					_RnPacImposte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_PAC_CONTRIBUTI_PAC
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnPacContributiPac
		{
			get { return _RnPacContributiPac; }
			set {
				if (RnPacContributiPac != value)
				{
					_RnPacContributiPac = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MNL_REDDITI_FAM
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT MnlRedditiFam
		{
			get { return _MnlRedditiFam; }
			set {
				if (MnlRedditiFam != value)
				{
					_MnlRedditiFam = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MNL_RIMBORSO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT MnlRimborso
		{
			get { return _MnlRimborso; }
			set {
				if (MnlRimborso != value)
				{
					_MnlRimborso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MNL_PRELIEVI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT MnlPrelievi
		{
			get { return _MnlPrelievi; }
			set {
				if (MnlPrelievi != value)
				{
					_MnlPrelievi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CF_TERRENI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCfTerreni
		{
			get { return _CfCfTerreni; }
			set {
				if (CfCfTerreni != value)
				{
					_CfCfTerreni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CF_IMPIANTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCfImpianti
		{
			get { return _CfCfImpianti; }
			set {
				if (CfCfImpianti != value)
				{
					_CfCfImpianti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CF_PIANTAGIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCfPiantagioni
		{
			get { return _CfCfPiantagioni; }
			set {
				if (CfCfPiantagioni != value)
				{
					_CfCfPiantagioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CF_MIGLIORAMENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCfMiglioramenti
		{
			get { return _CfCfMiglioramenti; }
			set {
				if (CfCfMiglioramenti != value)
				{
					_CfCfMiglioramenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CA_MACCHINE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCaMacchine
		{
			get { return _CfCaMacchine; }
			set {
				if (CfCaMacchine != value)
				{
					_CfCaMacchine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_CA_BESTIAME
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfCaBestiame
		{
			get { return _CfCaBestiame; }
			set {
				if (CfCaBestiame != value)
				{
					_CfCaBestiame = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_IF_PARTECIPAZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CfIfPartecipazioni
		{
			get { return _CfIfPartecipazioni; }
			set {
				if (CfIfPartecipazioni != value)
				{
					_CfIfPartecipazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CC_DF_RIMANENZE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CcDfRimanenze
		{
			get { return _CcDfRimanenze; }
			set {
				if (CcDfRimanenze != value)
				{
					_CcDfRimanenze = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CC_DF_ANTICIPAZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CcDfAnticipazioni
		{
			get { return _CcDfAnticipazioni; }
			set {
				if (CcDfAnticipazioni != value)
				{
					_CcDfAnticipazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CC_LD_CREDITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CcLdCrediti
		{
			get { return _CcLdCrediti; }
			set {
				if (CcLdCrediti != value)
				{
					_CcLdCrediti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CC_LI_BANCA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CcLiBanca
		{
			get { return _CcLiBanca; }
			set {
				if (CcLiBanca != value)
				{
					_CcLiBanca = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CC_LI_CASSA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CcLiCassa
		{
			get { return _CcLiCassa; }
			set {
				if (CcLiCassa != value)
				{
					_CcLiCassa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_PC_DEBITI_BREVE_TERMINE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfPcDebitiBreveTermine
		{
			get { return _FfPcDebitiBreveTermine; }
			set {
				if (FfPcDebitiBreveTermine != value)
				{
					_FfPcDebitiBreveTermine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_PC_FORNITORI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfPcFornitori
		{
			get { return _FfPcFornitori; }
			set {
				if (FfPcFornitori != value)
				{
					_FfPcFornitori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_PC_DEBITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfPcDebiti
		{
			get { return _FfPcDebiti; }
			set {
				if (FfPcDebiti != value)
				{
					_FfPcDebiti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_PC_MUTUI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfPcMutui
		{
			get { return _FfPcMutui; }
			set {
				if (FfPcMutui != value)
				{
					_FfPcMutui = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_MP_CAPITALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfMpCapitale
		{
			get { return _FfMpCapitale; }
			set {
				if (FfMpCapitale != value)
				{
					_FfMpCapitale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_MP_RISERVE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfMpRiserve
		{
			get { return _FfMpRiserve; }
			set {
				if (FfMpRiserve != value)
				{
					_FfMpRiserve = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FF_MP_UTILE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT FfMpUtile
		{
			get { return _FfMpUtile; }
			set {
				if (FfMpUtile != value)
				{
					_FfMpUtile = value;
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
<BILANCIO_AGRICOLO>
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
    <Find OrderBy="ORDER BY ">
      <ID_BILANCIO_AGRICOLO>Equal</ID_BILANCIO_AGRICOLO>
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
</BILANCIO_AGRICOLO>
*/