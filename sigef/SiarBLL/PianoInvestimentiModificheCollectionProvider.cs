using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PianoInvestimentiModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPianoInvestimentiModificheProvider
	{
		int Save(PianoInvestimentiModifiche PianoInvestimentiModificheObj);
		int SaveCollection(PianoInvestimentiModificheCollection collectionObj);
		int Delete(PianoInvestimentiModifiche PianoInvestimentiModificheObj);
		int DeleteCollection(PianoInvestimentiModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PianoInvestimentiModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PianoInvestimentiModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataVariazione;
		private NullTypes.StringNT _OperatoreVariazione;
		private NullTypes.StringNT _CodStp;
		private NullTypes.IntNT _IdUnitaMisura;
		private NullTypes.DecimalNT _Quantita;
		private NullTypes.DecimalNT _CostoInvestimento;
		private NullTypes.DecimalNT _SpeseGenerali;
		private NullTypes.DecimalNT _ContributoRichiesto;
		private NullTypes.DecimalNT _QuotaContributoRichiesto;
		private NullTypes.IntNT _IdSettoreProduttivo;
		private NullTypes.IntNT _IdPrioritaSettoriale;
		private NullTypes.IntNT _IdObiettivoMisura;
		private NullTypes.BoolNT _Ammesso;
		private NullTypes.StringNT _Istruttore;
		private NullTypes.IntNT _IdInvestimentoOriginale;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _IdDettaglioInvestimento;
		private NullTypes.IntNT _IdSpecificaInvestimento;
		private NullTypes.StringNT _CodTp;
		private NullTypes.StringNT _CodificaInvestimento;
		private NullTypes.DecimalNT _AiutoMinimo;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _CodSpecifica;
		private NullTypes.StringNT _SpecificaInvestimenti;
		private NullTypes.StringNT _DettaglioInvestimenti;
		private NullTypes.BoolNT _Mobile;
		private NullTypes.DecimalNT _QuotaSpeseGenerali;
		private NullTypes.StringNT _SettoreProduttivo;
		private NullTypes.IntNT _CodTipoInvestimento;
		private NullTypes.BoolNT _RichiediParticella;
		private NullTypes.StringNT _ValutazioneInvestimento;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.StringNT _CodVariazione;
		private NullTypes.DecimalNT _TassoAbbuono;
		private NullTypes.StringNT _Misura;
		private NullTypes.IntNT _IdMisura;
		private NullTypes.BoolNT _NonCofinanziato;
		private NullTypes.BoolNT _IsMax;
		private NullTypes.DecimalNT _ContributoAltreFonti;
		private NullTypes.DecimalNT _QuotaContributoAltreFonti;
		private NullTypes.IntNT _IdImpresaAggregazione;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IPianoInvestimentiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPianoInvestimentiModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PianoInvestimentiModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
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
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:DATA_VARIAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataVariazione
		{
			get { return _DataVariazione; }
			set {
				if (DataVariazione != value)
				{
					_DataVariazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_VARIAZIONE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreVariazione
		{
			get { return _OperatoreVariazione; }
			set {
				if (OperatoreVariazione != value)
				{
					_OperatoreVariazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STP
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodStp
		{
			get { return _CodStp; }
			set {
				if (CodStp != value)
				{
					_CodStp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UNITA_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUnitaMisura
		{
			get { return _IdUnitaMisura; }
			set {
				if (IdUnitaMisura != value)
				{
					_IdUnitaMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUANTITA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Quantita
		{
			get { return _Quantita; }
			set {
				if (Quantita != value)
				{
					_Quantita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_INVESTIMENTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT CostoInvestimento
		{
			get { return _CostoInvestimento; }
			set {
				if (CostoInvestimento != value)
				{
					_CostoInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESE_GENERALI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT SpeseGenerali
		{
			get { return _SpeseGenerali; }
			set {
				if (SpeseGenerali != value)
				{
					_SpeseGenerali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_RICHIESTO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoRichiesto
		{
			get { return _ContributoRichiesto; }
			set {
				if (ContributoRichiesto != value)
				{
					_ContributoRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_CONTRIBUTO_RICHIESTO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT QuotaContributoRichiesto
		{
			get { return _QuotaContributoRichiesto; }
			set {
				if (QuotaContributoRichiesto != value)
				{
					_QuotaContributoRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SETTORE_PRODUTTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSettoreProduttivo
		{
			get { return _IdSettoreProduttivo; }
			set {
				if (IdSettoreProduttivo != value)
				{
					_IdSettoreProduttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA_SETTORIALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPrioritaSettoriale
		{
			get { return _IdPrioritaSettoriale; }
			set {
				if (IdPrioritaSettoriale != value)
				{
					_IdPrioritaSettoriale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OBIETTIVO_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdObiettivoMisura
		{
			get { return _IdObiettivoMisura; }
			set {
				if (IdObiettivoMisura != value)
				{
					_IdObiettivoMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMESSO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Ammesso
		{
			get { return _Ammesso; }
			set {
				if (Ammesso != value)
				{
					_Ammesso = value;
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
		/// Corrisponde al campo:ID_INVESTIMENTO_ORIGINALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimentoOriginale
		{
			get { return _IdInvestimentoOriginale; }
			set {
				if (IdInvestimentoOriginale != value)
				{
					_IdInvestimentoOriginale = value;
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
		/// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCodificaInvestimento
		{
			get { return _IdCodificaInvestimento; }
			set {
				if (IdCodificaInvestimento != value)
				{
					_IdCodificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DETTAGLIO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDettaglioInvestimento
		{
			get { return _IdDettaglioInvestimento; }
			set {
				if (IdDettaglioInvestimento != value)
				{
					_IdDettaglioInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SPECIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSpecificaInvestimento
		{
			get { return _IdSpecificaInvestimento; }
			set {
				if (IdSpecificaInvestimento != value)
				{
					_IdSpecificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TP
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodTp
		{
			get { return _CodTp; }
			set {
				if (CodTp != value)
				{
					_CodTp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODIFICA_INVESTIMENTO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT CodificaInvestimento
		{
			get { return _CodificaInvestimento; }
			set {
				if (CodificaInvestimento != value)
				{
					_CodificaInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AIUTO_MINIMO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT AiutoMinimo
		{
			get { return _AiutoMinimo; }
			set {
				if (AiutoMinimo != value)
				{
					_AiutoMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:CHAR(20)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_SPECIFICA
		/// Tipo sul db:CHAR(20)
		/// </summary>
		public NullTypes.StringNT CodSpecifica
		{
			get { return _CodSpecifica; }
			set {
				if (CodSpecifica != value)
				{
					_CodSpecifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPECIFICA_INVESTIMENTI
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT SpecificaInvestimenti
		{
			get { return _SpecificaInvestimenti; }
			set {
				if (SpecificaInvestimenti != value)
				{
					_SpecificaInvestimenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DETTAGLIO_INVESTIMENTI
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DettaglioInvestimenti
		{
			get { return _DettaglioInvestimenti; }
			set {
				if (DettaglioInvestimenti != value)
				{
					_DettaglioInvestimenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOBILE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Mobile
		{
			get { return _Mobile; }
			set {
				if (Mobile != value)
				{
					_Mobile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_SPESE_GENERALI
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuotaSpeseGenerali
		{
			get { return _QuotaSpeseGenerali; }
			set {
				if (QuotaSpeseGenerali != value)
				{
					_QuotaSpeseGenerali = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SETTORE_PRODUTTIVO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT SettoreProduttivo
		{
			get { return _SettoreProduttivo; }
			set {
				if (SettoreProduttivo != value)
				{
					_SettoreProduttivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoInvestimento
		{
			get { return _CodTipoInvestimento; }
			set {
				if (CodTipoInvestimento != value)
				{
					_CodTipoInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICHIEDI_PARTICELLA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RichiediParticella
		{
			get { return _RichiediParticella; }
			set {
				if (RichiediParticella != value)
				{
					_RichiediParticella = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALUTAZIONE_INVESTIMENTO
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT ValutazioneInvestimento
		{
			get { return _ValutazioneInvestimento; }
			set {
				if (ValutazioneInvestimento != value)
				{
					_ValutazioneInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:COD_VARIAZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodVariazione
		{
			get { return _CodVariazione; }
			set {
				if (CodVariazione != value)
				{
					_CodVariazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TASSO_ABBUONO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT TassoAbbuono
		{
			get { return _TassoAbbuono; }
			set {
				if (TassoAbbuono != value)
				{
					_TassoAbbuono = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(71)
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
		/// Corrisponde al campo:ID_MISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdMisura
		{
			get { return _IdMisura; }
			set {
				if (IdMisura != value)
				{
					_IdMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NON_COFINANZIATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT NonCofinanziato
		{
			get { return _NonCofinanziato; }
			set {
				if (NonCofinanziato != value)
				{
					_NonCofinanziato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IS_MAX
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IsMax
		{
			get { return _IsMax; }
			set {
				if (IsMax != value)
				{
					_IsMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_ALTRE_FONTI
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAltreFonti
		{
			get { return _ContributoAltreFonti; }
			set {
				if (ContributoAltreFonti != value)
				{
					_ContributoAltreFonti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_CONTRIBUTO_ALTRE_FONTI
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT QuotaContributoAltreFonti
		{
			get { return _QuotaContributoAltreFonti; }
			set {
				if (QuotaContributoAltreFonti != value)
				{
					_QuotaContributoAltreFonti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA_AGGREGAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresaAggregazione
		{
			get { return _IdImpresaAggregazione; }
			set {
				if (IdImpresaAggregazione != value)
				{
					_IdImpresaAggregazione = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
					SetDirtyFlag();
				}
			}
		}



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

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PianoInvestimentiModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PianoInvestimentiModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private PianoInvestimentiModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PianoInvestimentiModifiche) info.GetValue(i.ToString(),typeof(PianoInvestimentiModifiche)));
			}
		}

		//Costruttore
		public PianoInvestimentiModificheCollection()
		{
			this.ItemType = typeof(PianoInvestimentiModifiche);
		}

		//Costruttore con provider
		public PianoInvestimentiModificheCollection(IPianoInvestimentiModificheProvider providerObj)
		{
			this.ItemType = typeof(PianoInvestimentiModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PianoInvestimentiModifiche this[int index]
		{
			get { return (PianoInvestimentiModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PianoInvestimentiModificheCollection GetChanges()
		{
			return (PianoInvestimentiModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IPianoInvestimentiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPianoInvestimentiModificheProvider Provider
		{
			get {return _provider;}
			set 
			{ 
				_provider = value;
				for (int i = 0; i < this.Count; i++)
				{
					this[i].Provider = value;
				}
			} 
		}

		public int SaveCollection()
		{
			return _provider.SaveCollection(this);
		}
		public int DeleteCollection()
		{
			return _provider.DeleteCollection(this);
		}
		//Add
		public int Add(PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			if (PianoInvestimentiModificheObj.Provider == null) PianoInvestimentiModificheObj.Provider = this.Provider;
			return base.Add(PianoInvestimentiModificheObj);
		}

		//AddCollection
		public void AddCollection(PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionObj)
		{
			foreach (PianoInvestimentiModifiche PianoInvestimentiModificheObj in PianoInvestimentiModificheCollectionObj)
				this.Add(PianoInvestimentiModificheObj);
		}

		//Insert
		public void Insert(int index, PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			if (PianoInvestimentiModificheObj.Provider == null) PianoInvestimentiModificheObj.Provider = this.Provider;
			base.Insert(index, PianoInvestimentiModificheObj);
		}

		//CollectionGetById
		public PianoInvestimentiModifiche CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PianoInvestimentiModificheCollection SubSelect(NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.DatetimeNT DataVariazioneEqualThis, NullTypes.StringNT OperatoreVariazioneEqualThis, 
NullTypes.StringNT CodStpEqualThis, NullTypes.IntNT IdUnitaMisuraEqualThis, NullTypes.DecimalNT QuantitaEqualThis, 
NullTypes.DecimalNT CostoInvestimentoEqualThis, NullTypes.DecimalNT SpeseGeneraliEqualThis, NullTypes.DecimalNT ContributoRichiestoEqualThis, 
NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, NullTypes.IntNT IdSettoreProduttivoEqualThis, NullTypes.IntNT IdPrioritaSettorialeEqualThis, 
NullTypes.IntNT IdObiettivoMisuraEqualThis, NullTypes.BoolNT AmmessoEqualThis, NullTypes.StringNT IstruttoreEqualThis, 
NullTypes.IntNT IdInvestimentoOriginaleEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis, 
NullTypes.IntNT IdDettaglioInvestimentoEqualThis, NullTypes.IntNT IdSpecificaInvestimentoEqualThis, NullTypes.StringNT CodTpEqualThis, 
NullTypes.StringNT CodificaInvestimentoEqualThis, NullTypes.DecimalNT AiutoMinimoEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.StringNT CodSpecificaEqualThis, NullTypes.StringNT SpecificaInvestimentiEqualThis, NullTypes.StringNT DettaglioInvestimentiEqualThis, 
NullTypes.BoolNT MobileEqualThis, NullTypes.DecimalNT QuotaSpeseGeneraliEqualThis, NullTypes.StringNT SettoreProduttivoEqualThis, 
NullTypes.IntNT CodTipoInvestimentoEqualThis, NullTypes.BoolNT RichiediParticellaEqualThis, NullTypes.IntNT IdVarianteEqualThis, 
NullTypes.StringNT CodVariazioneEqualThis, NullTypes.DecimalNT TassoAbbuonoEqualThis, NullTypes.StringNT MisuraEqualThis, 
NullTypes.IntNT IdMisuraEqualThis, NullTypes.BoolNT NonCofinanziatoEqualThis, NullTypes.BoolNT IsMaxEqualThis, 
NullTypes.DecimalNT ContributoAltreFontiEqualThis, NullTypes.DecimalNT QuotaContributoAltreFontiEqualThis, NullTypes.IntNT IdImpresaAggregazioneEqualThis, 
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionTemp = new PianoInvestimentiModificheCollection();
			foreach (PianoInvestimentiModifiche PianoInvestimentiModificheItem in this)
			{
				if (((IdInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.IdInvestimento != null) && (PianoInvestimentiModificheItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((PianoInvestimentiModificheItem.IdProgetto != null) && (PianoInvestimentiModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((PianoInvestimentiModificheItem.IdProgrammazione != null) && (PianoInvestimentiModificheItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((PianoInvestimentiModificheItem.Descrizione != null) && (PianoInvestimentiModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((DataVariazioneEqualThis == null) || ((PianoInvestimentiModificheItem.DataVariazione != null) && (PianoInvestimentiModificheItem.DataVariazione.Value == DataVariazioneEqualThis.Value))) && ((OperatoreVariazioneEqualThis == null) || ((PianoInvestimentiModificheItem.OperatoreVariazione != null) && (PianoInvestimentiModificheItem.OperatoreVariazione.Value == OperatoreVariazioneEqualThis.Value))) && 
((CodStpEqualThis == null) || ((PianoInvestimentiModificheItem.CodStp != null) && (PianoInvestimentiModificheItem.CodStp.Value == CodStpEqualThis.Value))) && ((IdUnitaMisuraEqualThis == null) || ((PianoInvestimentiModificheItem.IdUnitaMisura != null) && (PianoInvestimentiModificheItem.IdUnitaMisura.Value == IdUnitaMisuraEqualThis.Value))) && ((QuantitaEqualThis == null) || ((PianoInvestimentiModificheItem.Quantita != null) && (PianoInvestimentiModificheItem.Quantita.Value == QuantitaEqualThis.Value))) && 
((CostoInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.CostoInvestimento != null) && (PianoInvestimentiModificheItem.CostoInvestimento.Value == CostoInvestimentoEqualThis.Value))) && ((SpeseGeneraliEqualThis == null) || ((PianoInvestimentiModificheItem.SpeseGenerali != null) && (PianoInvestimentiModificheItem.SpeseGenerali.Value == SpeseGeneraliEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((PianoInvestimentiModificheItem.ContributoRichiesto != null) && (PianoInvestimentiModificheItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && 
((QuotaContributoRichiestoEqualThis == null) || ((PianoInvestimentiModificheItem.QuotaContributoRichiesto != null) && (PianoInvestimentiModificheItem.QuotaContributoRichiesto.Value == QuotaContributoRichiestoEqualThis.Value))) && ((IdSettoreProduttivoEqualThis == null) || ((PianoInvestimentiModificheItem.IdSettoreProduttivo != null) && (PianoInvestimentiModificheItem.IdSettoreProduttivo.Value == IdSettoreProduttivoEqualThis.Value))) && ((IdPrioritaSettorialeEqualThis == null) || ((PianoInvestimentiModificheItem.IdPrioritaSettoriale != null) && (PianoInvestimentiModificheItem.IdPrioritaSettoriale.Value == IdPrioritaSettorialeEqualThis.Value))) && 
((IdObiettivoMisuraEqualThis == null) || ((PianoInvestimentiModificheItem.IdObiettivoMisura != null) && (PianoInvestimentiModificheItem.IdObiettivoMisura.Value == IdObiettivoMisuraEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PianoInvestimentiModificheItem.Ammesso != null) && (PianoInvestimentiModificheItem.Ammesso.Value == AmmessoEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((PianoInvestimentiModificheItem.Istruttore != null) && (PianoInvestimentiModificheItem.Istruttore.Value == IstruttoreEqualThis.Value))) && 
((IdInvestimentoOriginaleEqualThis == null) || ((PianoInvestimentiModificheItem.IdInvestimentoOriginale != null) && (PianoInvestimentiModificheItem.IdInvestimentoOriginale.Value == IdInvestimentoOriginaleEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((PianoInvestimentiModificheItem.DataValutazione != null) && (PianoInvestimentiModificheItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.IdCodificaInvestimento != null) && (PianoInvestimentiModificheItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && 
((IdDettaglioInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.IdDettaglioInvestimento != null) && (PianoInvestimentiModificheItem.IdDettaglioInvestimento.Value == IdDettaglioInvestimentoEqualThis.Value))) && ((IdSpecificaInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.IdSpecificaInvestimento != null) && (PianoInvestimentiModificheItem.IdSpecificaInvestimento.Value == IdSpecificaInvestimentoEqualThis.Value))) && ((CodTpEqualThis == null) || ((PianoInvestimentiModificheItem.CodTp != null) && (PianoInvestimentiModificheItem.CodTp.Value == CodTpEqualThis.Value))) && 
((CodificaInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.CodificaInvestimento != null) && (PianoInvestimentiModificheItem.CodificaInvestimento.Value == CodificaInvestimentoEqualThis.Value))) && ((AiutoMinimoEqualThis == null) || ((PianoInvestimentiModificheItem.AiutoMinimo != null) && (PianoInvestimentiModificheItem.AiutoMinimo.Value == AiutoMinimoEqualThis.Value))) && ((CodiceEqualThis == null) || ((PianoInvestimentiModificheItem.Codice != null) && (PianoInvestimentiModificheItem.Codice.Value == CodiceEqualThis.Value))) && 
((CodSpecificaEqualThis == null) || ((PianoInvestimentiModificheItem.CodSpecifica != null) && (PianoInvestimentiModificheItem.CodSpecifica.Value == CodSpecificaEqualThis.Value))) && ((SpecificaInvestimentiEqualThis == null) || ((PianoInvestimentiModificheItem.SpecificaInvestimenti != null) && (PianoInvestimentiModificheItem.SpecificaInvestimenti.Value == SpecificaInvestimentiEqualThis.Value))) && ((DettaglioInvestimentiEqualThis == null) || ((PianoInvestimentiModificheItem.DettaglioInvestimenti != null) && (PianoInvestimentiModificheItem.DettaglioInvestimenti.Value == DettaglioInvestimentiEqualThis.Value))) && 
((MobileEqualThis == null) || ((PianoInvestimentiModificheItem.Mobile != null) && (PianoInvestimentiModificheItem.Mobile.Value == MobileEqualThis.Value))) && ((QuotaSpeseGeneraliEqualThis == null) || ((PianoInvestimentiModificheItem.QuotaSpeseGenerali != null) && (PianoInvestimentiModificheItem.QuotaSpeseGenerali.Value == QuotaSpeseGeneraliEqualThis.Value))) && ((SettoreProduttivoEqualThis == null) || ((PianoInvestimentiModificheItem.SettoreProduttivo != null) && (PianoInvestimentiModificheItem.SettoreProduttivo.Value == SettoreProduttivoEqualThis.Value))) && 
((CodTipoInvestimentoEqualThis == null) || ((PianoInvestimentiModificheItem.CodTipoInvestimento != null) && (PianoInvestimentiModificheItem.CodTipoInvestimento.Value == CodTipoInvestimentoEqualThis.Value))) && ((RichiediParticellaEqualThis == null) || ((PianoInvestimentiModificheItem.RichiediParticella != null) && (PianoInvestimentiModificheItem.RichiediParticella.Value == RichiediParticellaEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((PianoInvestimentiModificheItem.IdVariante != null) && (PianoInvestimentiModificheItem.IdVariante.Value == IdVarianteEqualThis.Value))) && 
((CodVariazioneEqualThis == null) || ((PianoInvestimentiModificheItem.CodVariazione != null) && (PianoInvestimentiModificheItem.CodVariazione.Value == CodVariazioneEqualThis.Value))) && ((TassoAbbuonoEqualThis == null) || ((PianoInvestimentiModificheItem.TassoAbbuono != null) && (PianoInvestimentiModificheItem.TassoAbbuono.Value == TassoAbbuonoEqualThis.Value))) && ((MisuraEqualThis == null) || ((PianoInvestimentiModificheItem.Misura != null) && (PianoInvestimentiModificheItem.Misura.Value == MisuraEqualThis.Value))) && 
((IdMisuraEqualThis == null) || ((PianoInvestimentiModificheItem.IdMisura != null) && (PianoInvestimentiModificheItem.IdMisura.Value == IdMisuraEqualThis.Value))) && ((NonCofinanziatoEqualThis == null) || ((PianoInvestimentiModificheItem.NonCofinanziato != null) && (PianoInvestimentiModificheItem.NonCofinanziato.Value == NonCofinanziatoEqualThis.Value))) && ((IsMaxEqualThis == null) || ((PianoInvestimentiModificheItem.IsMax != null) && (PianoInvestimentiModificheItem.IsMax.Value == IsMaxEqualThis.Value))) && 
((ContributoAltreFontiEqualThis == null) || ((PianoInvestimentiModificheItem.ContributoAltreFonti != null) && (PianoInvestimentiModificheItem.ContributoAltreFonti.Value == ContributoAltreFontiEqualThis.Value))) && ((QuotaContributoAltreFontiEqualThis == null) || ((PianoInvestimentiModificheItem.QuotaContributoAltreFonti != null) && (PianoInvestimentiModificheItem.QuotaContributoAltreFonti.Value == QuotaContributoAltreFontiEqualThis.Value))) && ((IdImpresaAggregazioneEqualThis == null) || ((PianoInvestimentiModificheItem.IdImpresaAggregazione != null) && (PianoInvestimentiModificheItem.IdImpresaAggregazione.Value == IdImpresaAggregazioneEqualThis.Value))) && 
((IdEqualThis == null) || ((PianoInvestimentiModificheItem.Id != null) && (PianoInvestimentiModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((PianoInvestimentiModificheItem.IdModifica != null) && (PianoInvestimentiModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					PianoInvestimentiModificheCollectionTemp.Add(PianoInvestimentiModificheItem);
				}
			}
			return PianoInvestimentiModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PianoInvestimentiModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PianoInvestimentiModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PianoInvestimentiModifiche PianoInvestimentiModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", PianoInvestimentiModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", PianoInvestimentiModificheObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PianoInvestimentiModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", PianoInvestimentiModificheObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", PianoInvestimentiModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataVariazione", PianoInvestimentiModificheObj.DataVariazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreVariazione", PianoInvestimentiModificheObj.OperatoreVariazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStp", PianoInvestimentiModificheObj.CodStp);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUnitaMisura", PianoInvestimentiModificheObj.IdUnitaMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "Quantita", PianoInvestimentiModificheObj.Quantita);
			DbProvider.SetCmdParam(cmd,firstChar + "CostoInvestimento", PianoInvestimentiModificheObj.CostoInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "SpeseGenerali", PianoInvestimentiModificheObj.SpeseGenerali);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoRichiesto", PianoInvestimentiModificheObj.ContributoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaContributoRichiesto", PianoInvestimentiModificheObj.QuotaContributoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSettoreProduttivo", PianoInvestimentiModificheObj.IdSettoreProduttivo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPrioritaSettoriale", PianoInvestimentiModificheObj.IdPrioritaSettoriale);
			DbProvider.SetCmdParam(cmd,firstChar + "IdObiettivoMisura", PianoInvestimentiModificheObj.IdObiettivoMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammesso", PianoInvestimentiModificheObj.Ammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruttore", PianoInvestimentiModificheObj.Istruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimentoOriginale", PianoInvestimentiModificheObj.IdInvestimentoOriginale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataValutazione", PianoInvestimentiModificheObj.DataValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCodificaInvestimento", PianoInvestimentiModificheObj.IdCodificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDettaglioInvestimento", PianoInvestimentiModificheObj.IdDettaglioInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSpecificaInvestimento", PianoInvestimentiModificheObj.IdSpecificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTp", PianoInvestimentiModificheObj.CodTp);
			DbProvider.SetCmdParam(cmd,firstChar + "CodificaInvestimento", PianoInvestimentiModificheObj.CodificaInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "AiutoMinimo", PianoInvestimentiModificheObj.AiutoMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", PianoInvestimentiModificheObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "CodSpecifica", PianoInvestimentiModificheObj.CodSpecifica);
			DbProvider.SetCmdParam(cmd,firstChar + "SpecificaInvestimenti", PianoInvestimentiModificheObj.SpecificaInvestimenti);
			DbProvider.SetCmdParam(cmd,firstChar + "DettaglioInvestimenti", PianoInvestimentiModificheObj.DettaglioInvestimenti);
			DbProvider.SetCmdParam(cmd,firstChar + "Mobile", PianoInvestimentiModificheObj.Mobile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaSpeseGenerali", PianoInvestimentiModificheObj.QuotaSpeseGenerali);
			DbProvider.SetCmdParam(cmd,firstChar + "SettoreProduttivo", PianoInvestimentiModificheObj.SettoreProduttivo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoInvestimento", PianoInvestimentiModificheObj.CodTipoInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "RichiediParticella", PianoInvestimentiModificheObj.RichiediParticella);
			DbProvider.SetCmdParam(cmd,firstChar + "ValutazioneInvestimento", PianoInvestimentiModificheObj.ValutazioneInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", PianoInvestimentiModificheObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodVariazione", PianoInvestimentiModificheObj.CodVariazione);
			DbProvider.SetCmdParam(cmd,firstChar + "TassoAbbuono", PianoInvestimentiModificheObj.TassoAbbuono);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", PianoInvestimentiModificheObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "IdMisura", PianoInvestimentiModificheObj.IdMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "NonCofinanziato", PianoInvestimentiModificheObj.NonCofinanziato);
			DbProvider.SetCmdParam(cmd,firstChar + "IsMax", PianoInvestimentiModificheObj.IsMax);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAltreFonti", PianoInvestimentiModificheObj.ContributoAltreFonti);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaContributoAltreFonti", PianoInvestimentiModificheObj.QuotaContributoAltreFonti);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresaAggregazione", PianoInvestimentiModificheObj.IdImpresaAggregazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", PianoInvestimentiModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPianoInvestimentiModificheInsert", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione", 
"Descrizione", "DataVariazione", "OperatoreVariazione", 
"CodStp", "IdUnitaMisura", "Quantita", 
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto", 
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale", 
"IdObiettivoMisura", "Ammesso", "Istruttore", 
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento", 
"IdDettaglioInvestimento", "IdSpecificaInvestimento", "CodTp", 
"CodificaInvestimento", "AiutoMinimo", "Codice", 
"CodSpecifica", "SpecificaInvestimenti", "DettaglioInvestimenti", 
"Mobile", "QuotaSpeseGenerali", "SettoreProduttivo", 
"CodTipoInvestimento", "RichiediParticella", "ValutazioneInvestimento", 
"IdVariante", "CodVariazione", "TassoAbbuono", 
"Misura", "IdMisura", "NonCofinanziato", 
"IsMax", "ContributoAltreFonti", "QuotaContributoAltreFonti", 
"IdImpresaAggregazione", "IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"string", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "int", "int", 
"int", "bool", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"string", "decimal", "string", 
"string", "string", "string", 
"bool", "decimal", "string", 
"int", "bool", "string", 
"int", "string", "decimal", 
"string", "int", "bool", 
"bool", "decimal", "decimal", 
"int", "int"},"");
				CompileIUCmd(false, insertCmd,PianoInvestimentiModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PianoInvestimentiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoInvestimentiModificheObj.IsDirty = false;
				PianoInvestimentiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoInvestimentiModificheUpdate", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione", 
"Descrizione", "DataVariazione", "OperatoreVariazione", 
"CodStp", "IdUnitaMisura", "Quantita", 
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto", 
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale", 
"IdObiettivoMisura", "Ammesso", "Istruttore", 
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento", 
"IdDettaglioInvestimento", "IdSpecificaInvestimento", "CodTp", 
"CodificaInvestimento", "AiutoMinimo", "Codice", 
"CodSpecifica", "SpecificaInvestimenti", "DettaglioInvestimenti", 
"Mobile", "QuotaSpeseGenerali", "SettoreProduttivo", 
"CodTipoInvestimento", "RichiediParticella", "ValutazioneInvestimento", 
"IdVariante", "CodVariazione", "TassoAbbuono", 
"Misura", "IdMisura", "NonCofinanziato", 
"IsMax", "ContributoAltreFonti", "QuotaContributoAltreFonti", 
"IdImpresaAggregazione", "Id", "IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"string", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "int", "int", 
"int", "bool", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"string", "decimal", "string", 
"string", "string", "string", 
"bool", "decimal", "string", 
"int", "bool", "string", 
"int", "string", "decimal", 
"string", "int", "bool", 
"bool", "decimal", "decimal", 
"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,PianoInvestimentiModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoInvestimentiModificheObj.IsDirty = false;
				PianoInvestimentiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			switch (PianoInvestimentiModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PianoInvestimentiModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PianoInvestimentiModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PianoInvestimentiModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPianoInvestimentiModificheUpdate", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione", 
"Descrizione", "DataVariazione", "OperatoreVariazione", 
"CodStp", "IdUnitaMisura", "Quantita", 
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto", 
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale", 
"IdObiettivoMisura", "Ammesso", "Istruttore", 
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento", 
"IdDettaglioInvestimento", "IdSpecificaInvestimento", "CodTp", 
"CodificaInvestimento", "AiutoMinimo", "Codice", 
"CodSpecifica", "SpecificaInvestimenti", "DettaglioInvestimenti", 
"Mobile", "QuotaSpeseGenerali", "SettoreProduttivo", 
"CodTipoInvestimento", "RichiediParticella", "ValutazioneInvestimento", 
"IdVariante", "CodVariazione", "TassoAbbuono", 
"Misura", "IdMisura", "NonCofinanziato", 
"IsMax", "ContributoAltreFonti", "QuotaContributoAltreFonti", 
"IdImpresaAggregazione", "Id", "IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"string", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "int", "int", 
"int", "bool", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"string", "decimal", "string", 
"string", "string", "string", 
"bool", "decimal", "string", 
"int", "bool", "string", 
"int", "string", "decimal", 
"string", "int", "bool", 
"bool", "decimal", "decimal", 
"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPianoInvestimentiModificheInsert", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione", 
"Descrizione", "DataVariazione", "OperatoreVariazione", 
"CodStp", "IdUnitaMisura", "Quantita", 
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto", 
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale", 
"IdObiettivoMisura", "Ammesso", "Istruttore", 
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento", 
"IdDettaglioInvestimento", "IdSpecificaInvestimento", "CodTp", 
"CodificaInvestimento", "AiutoMinimo", "Codice", 
"CodSpecifica", "SpecificaInvestimenti", "DettaglioInvestimenti", 
"Mobile", "QuotaSpeseGenerali", "SettoreProduttivo", 
"CodTipoInvestimento", "RichiediParticella", "ValutazioneInvestimento", 
"IdVariante", "CodVariazione", "TassoAbbuono", 
"Misura", "IdMisura", "NonCofinanziato", 
"IsMax", "ContributoAltreFonti", "QuotaContributoAltreFonti", 
"IdImpresaAggregazione", "IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"string", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "int", "int", 
"int", "bool", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"string", "decimal", "string", 
"string", "string", "string", 
"bool", "decimal", "string", 
"int", "bool", "string", 
"int", "string", "decimal", 
"string", "int", "bool", 
"bool", "decimal", "decimal", 
"int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPianoInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PianoInvestimentiModificheCollectionObj.Count; i++)
				{
					switch (PianoInvestimentiModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PianoInvestimentiModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PianoInvestimentiModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PianoInvestimentiModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PianoInvestimentiModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)PianoInvestimentiModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PianoInvestimentiModificheCollectionObj.Count; i++)
				{
					if ((PianoInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PianoInvestimentiModificheCollectionObj[i].IsDirty = false;
						PianoInvestimentiModificheCollectionObj[i].IsPersistent = true;
					}
					if ((PianoInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PianoInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoInvestimentiModificheCollectionObj[i].IsDirty = false;
						PianoInvestimentiModificheCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, PianoInvestimentiModifiche PianoInvestimentiModificheObj)
		{
			int returnValue = 0;
			if (PianoInvestimentiModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, PianoInvestimentiModificheObj.Id);
			}
			PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PianoInvestimentiModificheObj.IsDirty = false;
			PianoInvestimentiModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPianoInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PianoInvestimentiModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", PianoInvestimentiModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PianoInvestimentiModificheCollectionObj.Count; i++)
				{
					if ((PianoInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PianoInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PianoInvestimentiModificheCollectionObj[i].IsDirty = false;
						PianoInvestimentiModificheCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch 
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static PianoInvestimentiModifiche GetById(DbProvider db, int IdValue)
		{
			PianoInvestimentiModifiche PianoInvestimentiModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPianoInvestimentiModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PianoInvestimentiModificheObj = GetFromDatareader(db);
				PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoInvestimentiModificheObj.IsDirty = false;
				PianoInvestimentiModificheObj.IsPersistent = true;
			}
			db.Close();
			return PianoInvestimentiModificheObj;
		}

		//getFromDatareader
		public static PianoInvestimentiModifiche GetFromDatareader(DbProvider db)
		{
			PianoInvestimentiModifiche PianoInvestimentiModificheObj = new PianoInvestimentiModifiche();
			PianoInvestimentiModificheObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PianoInvestimentiModificheObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			PianoInvestimentiModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PianoInvestimentiModificheObj.DataVariazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VARIAZIONE"]);
			PianoInvestimentiModificheObj.OperatoreVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_VARIAZIONE"]);
			PianoInvestimentiModificheObj.CodStp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STP"]);
			PianoInvestimentiModificheObj.IdUnitaMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UNITA_MISURA"]);
			PianoInvestimentiModificheObj.Quantita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA"]);
			PianoInvestimentiModificheObj.CostoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.SpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_GENERALI"]);
			PianoInvestimentiModificheObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
			PianoInvestimentiModificheObj.QuotaContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
			PianoInvestimentiModificheObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
			PianoInvestimentiModificheObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
			PianoInvestimentiModificheObj.IdObiettivoMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO_MISURA"]);
			PianoInvestimentiModificheObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
			PianoInvestimentiModificheObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
			PianoInvestimentiModificheObj.IdInvestimentoOriginale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_ORIGINALE"]);
			PianoInvestimentiModificheObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
			PianoInvestimentiModificheObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.CodTp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TP"]);
			PianoInvestimentiModificheObj.CodificaInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODIFICA_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.AiutoMinimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AIUTO_MINIMO"]);
			PianoInvestimentiModificheObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			PianoInvestimentiModificheObj.CodSpecifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SPECIFICA"]);
			PianoInvestimentiModificheObj.SpecificaInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["SPECIFICA_INVESTIMENTI"]);
			PianoInvestimentiModificheObj.DettaglioInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_INVESTIMENTI"]);
			PianoInvestimentiModificheObj.Mobile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MOBILE"]);
			PianoInvestimentiModificheObj.QuotaSpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_SPESE_GENERALI"]);
			PianoInvestimentiModificheObj.SettoreProduttivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE_PRODUTTIVO"]);
			PianoInvestimentiModificheObj.CodTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.RichiediParticella = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICHIEDI_PARTICELLA"]);
			PianoInvestimentiModificheObj.ValutazioneInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_INVESTIMENTO"]);
			PianoInvestimentiModificheObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			PianoInvestimentiModificheObj.CodVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_VARIAZIONE"]);
			PianoInvestimentiModificheObj.TassoAbbuono = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TASSO_ABBUONO"]);
			PianoInvestimentiModificheObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			PianoInvestimentiModificheObj.IdMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MISURA"]);
			PianoInvestimentiModificheObj.NonCofinanziato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COFINANZIATO"]);
			PianoInvestimentiModificheObj.IsMax = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_MAX"]);
			PianoInvestimentiModificheObj.ContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_ALTRE_FONTI"]);
			PianoInvestimentiModificheObj.QuotaContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_ALTRE_FONTI"]);
			PianoInvestimentiModificheObj.IdImpresaAggregazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_AGGREGAZIONE"]);
			PianoInvestimentiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			PianoInvestimentiModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PianoInvestimentiModificheObj.IsDirty = false;
			PianoInvestimentiModificheObj.IsPersistent = true;
			return PianoInvestimentiModificheObj;
		}

		//Find Select

		public static PianoInvestimentiModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataVariazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreVariazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodStpEqualThis, SiarLibrary.NullTypes.IntNT IdUnitaMisuraEqualThis, SiarLibrary.NullTypes.DecimalNT QuantitaEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoInvestimentoEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseGeneraliEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis, SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis, 
SiarLibrary.NullTypes.IntNT IdObiettivoMisuraEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, 
SiarLibrary.NullTypes.IntNT IdInvestimentoOriginaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdSpecificaInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodTpEqualThis, 
SiarLibrary.NullTypes.StringNT CodificaInvestimentoEqualThis, SiarLibrary.NullTypes.DecimalNT AiutoMinimoEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.StringNT CodSpecificaEqualThis, SiarLibrary.NullTypes.StringNT SpecificaInvestimentiEqualThis, SiarLibrary.NullTypes.StringNT DettaglioInvestimentiEqualThis, 
SiarLibrary.NullTypes.BoolNT MobileEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaSpeseGeneraliEqualThis, SiarLibrary.NullTypes.StringNT SettoreProduttivoEqualThis, 
SiarLibrary.NullTypes.IntNT CodTipoInvestimentoEqualThis, SiarLibrary.NullTypes.BoolNT RichiediParticellaEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, 
SiarLibrary.NullTypes.StringNT CodVariazioneEqualThis, SiarLibrary.NullTypes.DecimalNT TassoAbbuonoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis, 
SiarLibrary.NullTypes.IntNT IdMisuraEqualThis, SiarLibrary.NullTypes.BoolNT NonCofinanziatoEqualThis, SiarLibrary.NullTypes.BoolNT IsMaxEqualThis, 
SiarLibrary.NullTypes.DecimalNT ContributoAltreFontiEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaContributoAltreFontiEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaAggregazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionObj = new PianoInvestimentiModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zpianoinvestimentimodifichefindselect", new string[] {"IdInvestimentoequalthis", "IdProgettoequalthis", "IdProgrammazioneequalthis", 
"Descrizioneequalthis", "DataVariazioneequalthis", "OperatoreVariazioneequalthis", 
"CodStpequalthis", "IdUnitaMisuraequalthis", "Quantitaequalthis", 
"CostoInvestimentoequalthis", "SpeseGeneraliequalthis", "ContributoRichiestoequalthis", 
"QuotaContributoRichiestoequalthis", "IdSettoreProduttivoequalthis", "IdPrioritaSettorialeequalthis", 
"IdObiettivoMisuraequalthis", "Ammessoequalthis", "Istruttoreequalthis", 
"IdInvestimentoOriginaleequalthis", "DataValutazioneequalthis", "IdCodificaInvestimentoequalthis", 
"IdDettaglioInvestimentoequalthis", "IdSpecificaInvestimentoequalthis", "CodTpequalthis", 
"CodificaInvestimentoequalthis", "AiutoMinimoequalthis", "Codiceequalthis", 
"CodSpecificaequalthis", "SpecificaInvestimentiequalthis", "DettaglioInvestimentiequalthis", 
"Mobileequalthis", "QuotaSpeseGeneraliequalthis", "SettoreProduttivoequalthis", 
"CodTipoInvestimentoequalthis", "RichiediParticellaequalthis", "IdVarianteequalthis", 
"CodVariazioneequalthis", "TassoAbbuonoequalthis", "Misuraequalthis", 
"IdMisuraequalthis", "NonCofinanziatoequalthis", "IsMaxequalthis", 
"ContributoAltreFontiequalthis", "QuotaContributoAltreFontiequalthis", "IdImpresaAggregazioneequalthis", 
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"string", "int", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "int", "int", 
"int", "bool", "string", 
"int", "DateTime", "int", 
"int", "int", "string", 
"string", "decimal", "string", 
"string", "string", "string", 
"bool", "decimal", "string", 
"int", "bool", "int", 
"string", "decimal", "string", 
"int", "bool", "bool", 
"decimal", "decimal", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataVariazioneequalthis", DataVariazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreVariazioneequalthis", OperatoreVariazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStpequalthis", CodStpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUnitaMisuraequalthis", IdUnitaMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quantitaequalthis", QuantitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoInvestimentoequalthis", CostoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpeseGeneraliequalthis", SpeseGeneraliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaContributoRichiestoequalthis", QuotaContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdObiettivoMisuraequalthis", IdObiettivoMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoOriginaleequalthis", IdInvestimentoOriginaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpecificaInvestimentoequalthis", IdSpecificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTpequalthis", CodTpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodificaInvestimentoequalthis", CodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AiutoMinimoequalthis", AiutoMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodSpecificaequalthis", CodSpecificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpecificaInvestimentiequalthis", SpecificaInvestimentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DettaglioInvestimentiequalthis", DettaglioInvestimentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Mobileequalthis", MobileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaSpeseGeneraliequalthis", QuotaSpeseGeneraliEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SettoreProduttivoequalthis", SettoreProduttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoInvestimentoequalthis", CodTipoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RichiediParticellaequalthis", RichiediParticellaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodVariazioneequalthis", CodVariazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TassoAbbuonoequalthis", TassoAbbuonoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdMisuraequalthis", IdMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NonCofinanziatoequalthis", NonCofinanziatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IsMaxequalthis", IsMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAltreFontiequalthis", ContributoAltreFontiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaContributoAltreFontiequalthis", QuotaContributoAltreFontiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaAggregazioneequalthis", IdImpresaAggregazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			PianoInvestimentiModifiche PianoInvestimentiModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PianoInvestimentiModificheObj = GetFromDatareader(db);
				PianoInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PianoInvestimentiModificheObj.IsDirty = false;
				PianoInvestimentiModificheObj.IsPersistent = true;
				PianoInvestimentiModificheCollectionObj.Add(PianoInvestimentiModificheObj);
			}
			db.Close();
			return PianoInvestimentiModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PianoInvestimentiModificheCollectionProvider:IPianoInvestimentiModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PianoInvestimentiModificheCollectionProvider : IPianoInvestimentiModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PianoInvestimentiModifiche
		protected PianoInvestimentiModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PianoInvestimentiModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PianoInvestimentiModificheCollection(this);
		}

		//Costruttore3: ha in input pianoinvestimentimodificheCollectionObj - non popola la collection
		public PianoInvestimentiModificheCollectionProvider(PianoInvestimentiModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PianoInvestimentiModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PianoInvestimentiModificheCollection(this);
		}

		//Get e Set
		public PianoInvestimentiModificheCollection CollectionObj
		{
			get
			{
				return _CollectionObj;
			}
			set
			{
				_CollectionObj = value;
			}
		}

		public DbProvider DbProviderObj
		{
			get
			{
				return _dbProviderObj;
			}
			set
			{
				_dbProviderObj = value;
			}
		}

		//Operazioni

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(PianoInvestimentiModificheCollection collectionObj)
		{
			return PianoInvestimentiModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PianoInvestimentiModifiche pianoinvestimentimodificheObj)
		{
			return PianoInvestimentiModificheDAL.Save(_dbProviderObj, pianoinvestimentimodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PianoInvestimentiModificheCollection collectionObj)
		{
			return PianoInvestimentiModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PianoInvestimentiModifiche pianoinvestimentimodificheObj)
		{
			return PianoInvestimentiModificheDAL.Delete(_dbProviderObj, pianoinvestimentimodificheObj);
		}

		//getById
		public PianoInvestimentiModifiche GetById(IntNT IdValue)
		{
			PianoInvestimentiModifiche PianoInvestimentiModificheTemp = PianoInvestimentiModificheDAL.GetById(_dbProviderObj, IdValue);
			if (PianoInvestimentiModificheTemp!=null) PianoInvestimentiModificheTemp.Provider = this;
			return PianoInvestimentiModificheTemp;
		}

		//Select: popola la collection
		public PianoInvestimentiModificheCollection Select(IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogrammazioneEqualThis, 
StringNT DescrizioneEqualThis, DatetimeNT DatavariazioneEqualThis, StringNT OperatorevariazioneEqualThis, 
StringNT CodstpEqualThis, IntNT IdunitamisuraEqualThis, DecimalNT QuantitaEqualThis, 
DecimalNT CostoinvestimentoEqualThis, DecimalNT SpesegeneraliEqualThis, DecimalNT ContributorichiestoEqualThis, 
DecimalNT QuotacontributorichiestoEqualThis, IntNT IdsettoreproduttivoEqualThis, IntNT IdprioritasettorialeEqualThis, 
IntNT IdobiettivomisuraEqualThis, BoolNT AmmessoEqualThis, StringNT IstruttoreEqualThis, 
IntNT IdinvestimentooriginaleEqualThis, DatetimeNT DatavalutazioneEqualThis, IntNT IdcodificainvestimentoEqualThis, 
IntNT IddettaglioinvestimentoEqualThis, IntNT IdspecificainvestimentoEqualThis, StringNT CodtpEqualThis, 
StringNT CodificainvestimentoEqualThis, DecimalNT AiutominimoEqualThis, StringNT CodiceEqualThis, 
StringNT CodspecificaEqualThis, StringNT SpecificainvestimentiEqualThis, StringNT DettaglioinvestimentiEqualThis, 
BoolNT MobileEqualThis, DecimalNT QuotaspesegeneraliEqualThis, StringNT SettoreproduttivoEqualThis, 
IntNT CodtipoinvestimentoEqualThis, BoolNT RichiediparticellaEqualThis, IntNT IdvarianteEqualThis, 
StringNT CodvariazioneEqualThis, DecimalNT TassoabbuonoEqualThis, StringNT MisuraEqualThis, 
IntNT IdmisuraEqualThis, BoolNT NoncofinanziatoEqualThis, BoolNT IsmaxEqualThis, 
DecimalNT ContributoaltrefontiEqualThis, DecimalNT QuotacontributoaltrefontiEqualThis, IntNT IdimpresaaggregazioneEqualThis, 
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			PianoInvestimentiModificheCollection PianoInvestimentiModificheCollectionTemp = PianoInvestimentiModificheDAL.Select(_dbProviderObj, IdinvestimentoEqualThis, IdprogettoEqualThis, IdprogrammazioneEqualThis, 
DescrizioneEqualThis, DatavariazioneEqualThis, OperatorevariazioneEqualThis, 
CodstpEqualThis, IdunitamisuraEqualThis, QuantitaEqualThis, 
CostoinvestimentoEqualThis, SpesegeneraliEqualThis, ContributorichiestoEqualThis, 
QuotacontributorichiestoEqualThis, IdsettoreproduttivoEqualThis, IdprioritasettorialeEqualThis, 
IdobiettivomisuraEqualThis, AmmessoEqualThis, IstruttoreEqualThis, 
IdinvestimentooriginaleEqualThis, DatavalutazioneEqualThis, IdcodificainvestimentoEqualThis, 
IddettaglioinvestimentoEqualThis, IdspecificainvestimentoEqualThis, CodtpEqualThis, 
CodificainvestimentoEqualThis, AiutominimoEqualThis, CodiceEqualThis, 
CodspecificaEqualThis, SpecificainvestimentiEqualThis, DettaglioinvestimentiEqualThis, 
MobileEqualThis, QuotaspesegeneraliEqualThis, SettoreproduttivoEqualThis, 
CodtipoinvestimentoEqualThis, RichiediparticellaEqualThis, IdvarianteEqualThis, 
CodvariazioneEqualThis, TassoabbuonoEqualThis, MisuraEqualThis, 
IdmisuraEqualThis, NoncofinanziatoEqualThis, IsmaxEqualThis, 
ContributoaltrefontiEqualThis, QuotacontributoaltrefontiEqualThis, IdimpresaaggregazioneEqualThis, 
IdEqualThis, IdmodificaEqualThis);
			PianoInvestimentiModificheCollectionTemp.Provider = this;
			return PianoInvestimentiModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_INVESTIMENTI_MODIFICHE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</PIANO_INVESTIMENTI_MODIFICHE>
*/
