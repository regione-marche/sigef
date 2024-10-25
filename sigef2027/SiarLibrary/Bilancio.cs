using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per Bilancio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBilancioProvider
	{
		int Save(Bilancio BilancioObj);
		int SaveCollection(BilancioCollection collectionObj);
		int Delete(Bilancio BilancioObj);
		int DeleteCollection(BilancioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Bilancio
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class Bilancio: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBilancio;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _Anno;
		private NullTypes.DatetimeNT _DataBilancio;
		private NullTypes.DecimalNT _PlvRicaviNettiVendita;
		private NullTypes.DecimalNT _PlvAltriRicavi;
		private NullTypes.DecimalNT _PlvVarRimanenze;
		private NullTypes.DecimalNT _PlvVarLavoro;
		private NullTypes.DecimalNT _PlvIncrementi;
		private NullTypes.DecimalNT _RoCostiProduzione;
		private NullTypes.DecimalNT _RpiProventi;
		private NullTypes.DecimalNT _RpiRettifiche;
		private NullTypes.DecimalNT _RpiProventiStraordinari;
		private NullTypes.DecimalNT _RnImposte;
		private NullTypes.DecimalNT _TaCrediti;
		private NullTypes.DecimalNT _TaImmobilizzazioni;
		private NullTypes.DecimalNT _TaAttivoCircolante;
		private NullTypes.DecimalNT _TaRatei;
		private NullTypes.DecimalNT _TpPatrimonio;
		private NullTypes.DecimalNT _TpFondi;
		private NullTypes.DecimalNT _TpLtMutuiOrdinari;
		private NullTypes.DecimalNT _TpLtMutuiAgevolati;
		private NullTypes.DecimalNT _TpLtPrestiti;
		private NullTypes.DecimalNT _TpLtDebitiFornitori;
		private NullTypes.DecimalNT _TpLtDebitiBanche;
		private NullTypes.DecimalNT _TpLtAltreScadenze;
		private NullTypes.DecimalNT _TpDebitiFornitori;
		private NullTypes.DecimalNT _TpDebitiBanche;
		private NullTypes.DecimalNT _TpPrestitiSoci;
		private NullTypes.DecimalNT _TpPrestiti;
		private NullTypes.DecimalNT _TpAltriDebiti;
		private NullTypes.DecimalNT _TpRatei;
		[NonSerialized] private IBilancioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Bilancio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BILANCIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBilancio
		{
			get { return _IdBilancio; }
			set {
				if (IdBilancio != value)
				{
					_IdBilancio = value;
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
		/// Corrisponde al campo:PLV_RICAVI_NETTI_VENDITA
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvRicaviNettiVendita
		{
			get { return _PlvRicaviNettiVendita; }
			set {
				if (PlvRicaviNettiVendita != value)
				{
					_PlvRicaviNettiVendita = value;
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
		/// Corrisponde al campo:PLV_VAR_RIMANENZE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvVarRimanenze
		{
			get { return _PlvVarRimanenze; }
			set {
				if (PlvVarRimanenze != value)
				{
					_PlvVarRimanenze = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_VAR_LAVORO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvVarLavoro
		{
			get { return _PlvVarLavoro; }
			set {
				if (PlvVarLavoro != value)
				{
					_PlvVarLavoro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLV_INCREMENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT PlvIncrementi
		{
			get { return _PlvIncrementi; }
			set {
				if (PlvIncrementi != value)
				{
					_PlvIncrementi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RO_COSTI_PRODUZIONE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RoCostiProduzione
		{
			get { return _RoCostiProduzione; }
			set {
				if (RoCostiProduzione != value)
				{
					_RoCostiProduzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RPI_PROVENTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RpiProventi
		{
			get { return _RpiProventi; }
			set {
				if (RpiProventi != value)
				{
					_RpiProventi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RPI_RETTIFICHE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RpiRettifiche
		{
			get { return _RpiRettifiche; }
			set {
				if (RpiRettifiche != value)
				{
					_RpiRettifiche = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RPI_PROVENTI_STRAORDINARI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RpiProventiStraordinari
		{
			get { return _RpiProventiStraordinari; }
			set {
				if (RpiProventiStraordinari != value)
				{
					_RpiProventiStraordinari = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RN_IMPOSTE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT RnImposte
		{
			get { return _RnImposte; }
			set {
				if (RnImposte != value)
				{
					_RnImposte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_CREDITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaCrediti
		{
			get { return _TaCrediti; }
			set {
				if (TaCrediti != value)
				{
					_TaCrediti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_IMMOBILIZZAZIONI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaImmobilizzazioni
		{
			get { return _TaImmobilizzazioni; }
			set {
				if (TaImmobilizzazioni != value)
				{
					_TaImmobilizzazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_ATTIVO_CIRCOLANTE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaAttivoCircolante
		{
			get { return _TaAttivoCircolante; }
			set {
				if (TaAttivoCircolante != value)
				{
					_TaAttivoCircolante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TA_RATEI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TaRatei
		{
			get { return _TaRatei; }
			set {
				if (TaRatei != value)
				{
					_TaRatei = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PATRIMONIO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPatrimonio
		{
			get { return _TpPatrimonio; }
			set {
				if (TpPatrimonio != value)
				{
					_TpPatrimonio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_FONDI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpFondi
		{
			get { return _TpFondi; }
			set {
				if (TpFondi != value)
				{
					_TpFondi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_MUTUI_ORDINARI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtMutuiOrdinari
		{
			get { return _TpLtMutuiOrdinari; }
			set {
				if (TpLtMutuiOrdinari != value)
				{
					_TpLtMutuiOrdinari = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_MUTUI_AGEVOLATI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtMutuiAgevolati
		{
			get { return _TpLtMutuiAgevolati; }
			set {
				if (TpLtMutuiAgevolati != value)
				{
					_TpLtMutuiAgevolati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_PRESTITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtPrestiti
		{
			get { return _TpLtPrestiti; }
			set {
				if (TpLtPrestiti != value)
				{
					_TpLtPrestiti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_DEBITI_FORNITORI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtDebitiFornitori
		{
			get { return _TpLtDebitiFornitori; }
			set {
				if (TpLtDebitiFornitori != value)
				{
					_TpLtDebitiFornitori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_DEBITI_BANCHE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtDebitiBanche
		{
			get { return _TpLtDebitiBanche; }
			set {
				if (TpLtDebitiBanche != value)
				{
					_TpLtDebitiBanche = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_LT_ALTRE_SCADENZE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpLtAltreScadenze
		{
			get { return _TpLtAltreScadenze; }
			set {
				if (TpLtAltreScadenze != value)
				{
					_TpLtAltreScadenze = value;
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
		/// Corrisponde al campo:TP_PRESTITI_SOCI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPrestitiSoci
		{
			get { return _TpPrestitiSoci; }
			set {
				if (TpPrestitiSoci != value)
				{
					_TpPrestitiSoci = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TP_PRESTITI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpPrestiti
		{
			get { return _TpPrestiti; }
			set {
				if (TpPrestiti != value)
				{
					_TpPrestiti = value;
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
		/// Corrisponde al campo:TP_RATEI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TpRatei
		{
			get { return _TpRatei; }
			set {
				if (TpRatei != value)
				{
					_TpRatei = value;
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
<BILANCIO>
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
      <ID_BILANCIO>Equal</ID_BILANCIO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO>
*/