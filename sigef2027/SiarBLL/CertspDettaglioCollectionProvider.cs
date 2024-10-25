using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspDettaglio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspDettaglioProvider
	{
		int Save(CertspDettaglio CertspDettaglioObj);
		int SaveCollection(CertspDettaglioCollection collectionObj);
		int Delete(CertspDettaglio CertspDettaglioObj);
		int DeleteCollection(CertspDettaglioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspDettaglio
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspDettaglio: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdcertspDettaglio;
		private NullTypes.IntNT _Idcertsp;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Asse;
		private NullTypes.BoolNT _Selezionata;
		private NullTypes.StringNT _Esito;
		private NullTypes.DatetimeNT _Dataesito;
		private NullTypes.IntNT _IdFile;
		private NullTypes.DecimalNT _Costototale;
		private NullTypes.DecimalNT _Importoammesso;
		private NullTypes.DecimalNT _Importoconcesso;
		private NullTypes.StringNT _Beneficiario;
		private NullTypes.DecimalNT _Spesaammessa;
		private NullTypes.DecimalNT _Importocontributopubblico;
		private NullTypes.DecimalNT _SpesaammessaIncrementale;
		private NullTypes.DecimalNT _ImportocontributopubblicoIncrementale;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _Datainserimento;
		private NullTypes.DatetimeNT _Datamodifica;
		private NullTypes.DecimalNT _Quotaue;
		private NullTypes.DecimalNT _Quotastato;
		private NullTypes.DecimalNT _Quotaregione;
		private NullTypes.DecimalNT _Quotaprivato;
		private NullTypes.StringNT _Codpsr;
		private NullTypes.DatetimeNT _Datafine;
		private NullTypes.BoolNT _Definitivo;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _CodiceCup;
		private NullTypes.StringNT _CupNaturaCodice;
		private NullTypes.StringNT _CupNaturaDescrizione;
		private NullTypes.IntNT _Titoloprogetto;
		private NullTypes.StringNT _Tipodomanda;
		private NullTypes.StringNT _ObiettivoSpecifico;
		private NullTypes.StringNT _Azione;
		private NullTypes.StringNT _Intervento;
		private NullTypes.IntNT _IdBando;
		[NonSerialized] private ICertspDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspDettaglioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspDettaglio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:IdCertSp_Dettaglio
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdcertspDettaglio
		{
			get { return _IdcertspDettaglio; }
			set {
				if (IdcertspDettaglio != value)
				{
					_IdcertspDettaglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IdCertSp
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Idcertsp
		{
			get { return _Idcertsp; }
			set {
				if (Idcertsp != value)
				{
					_Idcertsp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Domanda_Pagamento
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Progetto
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
		/// Corrisponde al campo:Asse
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Asse
		{
			get { return _Asse; }
			set {
				if (Asse != value)
				{
					_Asse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Selezionata
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Selezionata
		{
			get { return _Selezionata; }
			set {
				if (Selezionata != value)
				{
					_Selezionata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Esito
		/// Tipo sul db:CHAR(1)
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
		/// Corrisponde al campo:DataEsito
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Dataesito
		{
			get { return _Dataesito; }
			set {
				if (Dataesito != value)
				{
					_Dataesito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_File
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set {
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CostoTotale
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Costototale
		{
			get { return _Costototale; }
			set {
				if (Costototale != value)
				{
					_Costototale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ImportoAmmesso
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importoammesso
		{
			get { return _Importoammesso; }
			set {
				if (Importoammesso != value)
				{
					_Importoammesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ImportoConcesso
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importoconcesso
		{
			get { return _Importoconcesso; }
			set {
				if (Importoconcesso != value)
				{
					_Importoconcesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Beneficiario
		/// Tipo sul db:VARCHAR(155)
		/// </summary>
		public NullTypes.StringNT Beneficiario
		{
			get { return _Beneficiario; }
			set {
				if (Beneficiario != value)
				{
					_Beneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SpesaAmmessa
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Spesaammessa
		{
			get { return _Spesaammessa; }
			set {
				if (Spesaammessa != value)
				{
					_Spesaammessa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ImportoContributoPubblico
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importocontributopubblico
		{
			get { return _Importocontributopubblico; }
			set {
				if (Importocontributopubblico != value)
				{
					_Importocontributopubblico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SpesaAmmessa_Incrementale
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT SpesaammessaIncrementale
		{
			get { return _SpesaammessaIncrementale; }
			set {
				if (SpesaammessaIncrementale != value)
				{
					_SpesaammessaIncrementale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ImportoContributoPubblico_Incrementale
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportocontributopubblicoIncrementale
		{
			get { return _ImportocontributopubblicoIncrementale; }
			set {
				if (ImportocontributopubblicoIncrementale != value)
				{
					_ImportocontributopubblicoIncrementale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Note
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:Operatore
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataInserimento
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datainserimento
		{
			get { return _Datainserimento; }
			set {
				if (Datainserimento != value)
				{
					_Datainserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataModifica
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datamodifica
		{
			get { return _Datamodifica; }
			set {
				if (Datamodifica != value)
				{
					_Datamodifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QuotaUe
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Quotaue
		{
			get { return _Quotaue; }
			set {
				if (Quotaue != value)
				{
					_Quotaue = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QuotaStato
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Quotastato
		{
			get { return _Quotastato; }
			set {
				if (Quotastato != value)
				{
					_Quotastato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QuotaRegione
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Quotaregione
		{
			get { return _Quotaregione; }
			set {
				if (Quotaregione != value)
				{
					_Quotaregione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QuotaPrivato
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Quotaprivato
		{
			get { return _Quotaprivato; }
			set {
				if (Quotaprivato != value)
				{
					_Quotaprivato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CodPsr
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Codpsr
		{
			get { return _Codpsr; }
			set {
				if (Codpsr != value)
				{
					_Codpsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataFine
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datafine
		{
			get { return _Datafine; }
			set {
				if (Datafine != value)
				{
					_Datafine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Definitivo
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitivo
		{
			get { return _Definitivo; }
			set {
				if (Definitivo != value)
				{
					_Definitivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Tipo
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Codice_Cup
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodiceCup
		{
			get { return _CodiceCup; }
			set {
				if (CodiceCup != value)
				{
					_CodiceCup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Cup_Natura_Codice
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CupNaturaCodice
		{
			get { return _CupNaturaCodice; }
			set {
				if (CupNaturaCodice != value)
				{
					_CupNaturaCodice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Cup_Natura_Descrizione
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT CupNaturaDescrizione
		{
			get { return _CupNaturaDescrizione; }
			set {
				if (CupNaturaDescrizione != value)
				{
					_CupNaturaDescrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TitoloProgetto
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Titoloprogetto
		{
			get { return _Titoloprogetto; }
			set {
				if (Titoloprogetto != value)
				{
					_Titoloprogetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TipoDomanda
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT Tipodomanda
		{
			get { return _Tipodomanda; }
			set {
				if (Tipodomanda != value)
				{
					_Tipodomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Obiettivo_Specifico
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ObiettivoSpecifico
		{
			get { return _ObiettivoSpecifico; }
			set {
				if (ObiettivoSpecifico != value)
				{
					_ObiettivoSpecifico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Azione
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Azione
		{
			get { return _Azione; }
			set {
				if (Azione != value)
				{
					_Azione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Intervento
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Intervento
		{
			get { return _Intervento; }
			set {
				if (Intervento != value)
				{
					_Intervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_Bando
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

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CertspDettaglioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspDettaglio) info.GetValue(i.ToString(),typeof(CertspDettaglio)));
			}
		}

		//Costruttore
		public CertspDettaglioCollection()
		{
			this.ItemType = typeof(CertspDettaglio);
		}

		//Costruttore con provider
		public CertspDettaglioCollection(ICertspDettaglioProvider providerObj)
		{
			this.ItemType = typeof(CertspDettaglio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspDettaglio this[int index]
		{
			get { return (CertspDettaglio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspDettaglioCollection GetChanges()
		{
			return (CertspDettaglioCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspDettaglioProvider Provider
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
		public int Add(CertspDettaglio CertspDettaglioObj)
		{
			if (CertspDettaglioObj.Provider == null) CertspDettaglioObj.Provider = this.Provider;
			return base.Add(CertspDettaglioObj);
		}

		//AddCollection
		public void AddCollection(CertspDettaglioCollection CertspDettaglioCollectionObj)
		{
			foreach (CertspDettaglio CertspDettaglioObj in CertspDettaglioCollectionObj)
				this.Add(CertspDettaglioObj);
		}

		//Insert
		public void Insert(int index, CertspDettaglio CertspDettaglioObj)
		{
			if (CertspDettaglioObj.Provider == null) CertspDettaglioObj.Provider = this.Provider;
			base.Insert(index, CertspDettaglioObj);
		}

		//CollectionGetById
		public CertspDettaglio CollectionGetById(NullTypes.IntNT IdcertspDettaglioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdcertspDettaglio == IdcertspDettaglioValue))
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
		public CertspDettaglioCollection SubSelect(NullTypes.IntNT IdcertspDettaglioEqualThis, NullTypes.IntNT IdcertspEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT AsseEqualThis, NullTypes.BoolNT SelezionataEqualThis, 
NullTypes.StringNT EsitoEqualThis, NullTypes.DatetimeNT DataesitoEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.DecimalNT CostototaleEqualThis, NullTypes.DecimalNT ImportoammessoEqualThis, NullTypes.DecimalNT ImportoconcessoEqualThis, 
NullTypes.StringNT BeneficiarioEqualThis, NullTypes.DecimalNT SpesaammessaEqualThis, NullTypes.DecimalNT ImportocontributopubblicoEqualThis, 
NullTypes.DecimalNT SpesaammessaIncrementaleEqualThis, NullTypes.DecimalNT ImportocontributopubblicoIncrementaleEqualThis, NullTypes.StringNT NoteEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DatainserimentoEqualThis, NullTypes.DatetimeNT DatamodificaEqualThis, 
NullTypes.DecimalNT QuotaueEqualThis, NullTypes.DecimalNT QuotastatoEqualThis, NullTypes.DecimalNT QuotaregioneEqualThis, 
NullTypes.DecimalNT QuotaprivatoEqualThis)
		{
			CertspDettaglioCollection CertspDettaglioCollectionTemp = new CertspDettaglioCollection();
			foreach (CertspDettaglio CertspDettaglioItem in this)
			{
				if (((IdcertspDettaglioEqualThis == null) || ((CertspDettaglioItem.IdcertspDettaglio != null) && (CertspDettaglioItem.IdcertspDettaglio.Value == IdcertspDettaglioEqualThis.Value))) && ((IdcertspEqualThis == null) || ((CertspDettaglioItem.Idcertsp != null) && (CertspDettaglioItem.Idcertsp.Value == IdcertspEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CertspDettaglioItem.IdDomandaPagamento != null) && (CertspDettaglioItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((CertspDettaglioItem.IdProgetto != null) && (CertspDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((AsseEqualThis == null) || ((CertspDettaglioItem.Asse != null) && (CertspDettaglioItem.Asse.Value == AsseEqualThis.Value))) && ((SelezionataEqualThis == null) || ((CertspDettaglioItem.Selezionata != null) && (CertspDettaglioItem.Selezionata.Value == SelezionataEqualThis.Value))) && 
((EsitoEqualThis == null) || ((CertspDettaglioItem.Esito != null) && (CertspDettaglioItem.Esito.Value == EsitoEqualThis.Value))) && ((DataesitoEqualThis == null) || ((CertspDettaglioItem.Dataesito != null) && (CertspDettaglioItem.Dataesito.Value == DataesitoEqualThis.Value))) && ((IdFileEqualThis == null) || ((CertspDettaglioItem.IdFile != null) && (CertspDettaglioItem.IdFile.Value == IdFileEqualThis.Value))) && 
((CostototaleEqualThis == null) || ((CertspDettaglioItem.Costototale != null) && (CertspDettaglioItem.Costototale.Value == CostototaleEqualThis.Value))) && ((ImportoammessoEqualThis == null) || ((CertspDettaglioItem.Importoammesso != null) && (CertspDettaglioItem.Importoammesso.Value == ImportoammessoEqualThis.Value))) && ((ImportoconcessoEqualThis == null) || ((CertspDettaglioItem.Importoconcesso != null) && (CertspDettaglioItem.Importoconcesso.Value == ImportoconcessoEqualThis.Value))) && 
((BeneficiarioEqualThis == null) || ((CertspDettaglioItem.Beneficiario != null) && (CertspDettaglioItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SpesaammessaEqualThis == null) || ((CertspDettaglioItem.Spesaammessa != null) && (CertspDettaglioItem.Spesaammessa.Value == SpesaammessaEqualThis.Value))) && ((ImportocontributopubblicoEqualThis == null) || ((CertspDettaglioItem.Importocontributopubblico != null) && (CertspDettaglioItem.Importocontributopubblico.Value == ImportocontributopubblicoEqualThis.Value))) && 
((SpesaammessaIncrementaleEqualThis == null) || ((CertspDettaglioItem.SpesaammessaIncrementale != null) && (CertspDettaglioItem.SpesaammessaIncrementale.Value == SpesaammessaIncrementaleEqualThis.Value))) && ((ImportocontributopubblicoIncrementaleEqualThis == null) || ((CertspDettaglioItem.ImportocontributopubblicoIncrementale != null) && (CertspDettaglioItem.ImportocontributopubblicoIncrementale.Value == ImportocontributopubblicoIncrementaleEqualThis.Value))) && ((NoteEqualThis == null) || ((CertspDettaglioItem.Note != null) && (CertspDettaglioItem.Note.Value == NoteEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CertspDettaglioItem.Operatore != null) && (CertspDettaglioItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DatainserimentoEqualThis == null) || ((CertspDettaglioItem.Datainserimento != null) && (CertspDettaglioItem.Datainserimento.Value == DatainserimentoEqualThis.Value))) && ((DatamodificaEqualThis == null) || ((CertspDettaglioItem.Datamodifica != null) && (CertspDettaglioItem.Datamodifica.Value == DatamodificaEqualThis.Value))) && 
((QuotaueEqualThis == null) || ((CertspDettaglioItem.Quotaue != null) && (CertspDettaglioItem.Quotaue.Value == QuotaueEqualThis.Value))) && ((QuotastatoEqualThis == null) || ((CertspDettaglioItem.Quotastato != null) && (CertspDettaglioItem.Quotastato.Value == QuotastatoEqualThis.Value))) && ((QuotaregioneEqualThis == null) || ((CertspDettaglioItem.Quotaregione != null) && (CertspDettaglioItem.Quotaregione.Value == QuotaregioneEqualThis.Value))) && 
((QuotaprivatoEqualThis == null) || ((CertspDettaglioItem.Quotaprivato != null) && (CertspDettaglioItem.Quotaprivato.Value == QuotaprivatoEqualThis.Value))))
				{
					CertspDettaglioCollectionTemp.Add(CertspDettaglioItem);
				}
			}
			return CertspDettaglioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspDettaglioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspDettaglioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspDettaglio CertspDettaglioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdcertspDettaglio", CertspDettaglioObj.IdcertspDettaglio);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Idcertsp", CertspDettaglioObj.Idcertsp);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CertspDettaglioObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CertspDettaglioObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Asse", CertspDettaglioObj.Asse);
			DbProvider.SetCmdParam(cmd,firstChar + "Selezionata", CertspDettaglioObj.Selezionata);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", CertspDettaglioObj.Esito);
			DbProvider.SetCmdParam(cmd,firstChar + "Dataesito", CertspDettaglioObj.Dataesito);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", CertspDettaglioObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Costototale", CertspDettaglioObj.Costototale);
			DbProvider.SetCmdParam(cmd,firstChar + "Importoammesso", CertspDettaglioObj.Importoammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Importoconcesso", CertspDettaglioObj.Importoconcesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Beneficiario", CertspDettaglioObj.Beneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "Spesaammessa", CertspDettaglioObj.Spesaammessa);
			DbProvider.SetCmdParam(cmd,firstChar + "Importocontributopubblico", CertspDettaglioObj.Importocontributopubblico);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaammessaIncrementale", CertspDettaglioObj.SpesaammessaIncrementale);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportocontributopubblicoIncrementale", CertspDettaglioObj.ImportocontributopubblicoIncrementale);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", CertspDettaglioObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspDettaglioObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainserimento", CertspDettaglioObj.Datainserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Datamodifica", CertspDettaglioObj.Datamodifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Quotaue", CertspDettaglioObj.Quotaue);
			DbProvider.SetCmdParam(cmd,firstChar + "Quotastato", CertspDettaglioObj.Quotastato);
			DbProvider.SetCmdParam(cmd,firstChar + "Quotaregione", CertspDettaglioObj.Quotaregione);
			DbProvider.SetCmdParam(cmd,firstChar + "Quotaprivato", CertspDettaglioObj.Quotaprivato);
		}
		//Insert
		private static int Insert(DbProvider db, CertspDettaglio CertspDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspDettaglioInsert", new string[] {"Idcertsp", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "IdFile", 
"Costototale", "Importoammesso", "Importoconcesso", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Note", 
"Operatore", "Datainserimento", "Datamodifica", 
"Quotaue", "Quotastato", "Quotaregione", 
"Quotaprivato", 


}, new string[] {"int", "int", 
"int", "string", "bool", 
"string", "DateTime", "int", 
"decimal", "decimal", "decimal", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", 


},"");
				CompileIUCmd(false, insertCmd,CertspDettaglioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspDettaglioObj.IdcertspDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp_Dettaglio"]);
				}
				CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDettaglioObj.IsDirty = false;
				CertspDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspDettaglio CertspDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspDettaglioUpdate", new string[] {"IdcertspDettaglio", "Idcertsp", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "IdFile", 
"Costototale", "Importoammesso", "Importoconcesso", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Note", 
"Operatore", "Datainserimento", "Datamodifica", 
"Quotaue", "Quotastato", "Quotaregione", 
"Quotaprivato", 


}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "int", 
"decimal", "decimal", "decimal", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", 


},"");
				CompileIUCmd(true, updateCmd,CertspDettaglioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDettaglioObj.IsDirty = false;
				CertspDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspDettaglio CertspDettaglioObj)
		{
			switch (CertspDettaglioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspDettaglioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspDettaglioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspDettaglioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspDettaglioCollection CertspDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspDettaglioUpdate", new string[] {"IdcertspDettaglio", "Idcertsp", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "IdFile", 
"Costototale", "Importoammesso", "Importoconcesso", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Note", 
"Operatore", "Datainserimento", "Datamodifica", 
"Quotaue", "Quotastato", "Quotaregione", 
"Quotaprivato", 


}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "int", 
"decimal", "decimal", "decimal", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", 


},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspDettaglioInsert", new string[] {"Idcertsp", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "IdFile", 
"Costototale", "Importoammesso", "Importoconcesso", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Note", 
"Operatore", "Datainserimento", "Datamodifica", 
"Quotaue", "Quotastato", "Quotaregione", 
"Quotaprivato", 


}, new string[] {"int", "int", 
"int", "string", "bool", 
"string", "DateTime", "int", 
"decimal", "decimal", "decimal", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal", 


},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDettaglioDelete", new string[] {"IdcertspDettaglio"}, new string[] {"int"},"");
				for (int i = 0; i < CertspDettaglioCollectionObj.Count; i++)
				{
					switch (CertspDettaglioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspDettaglioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspDettaglioCollectionObj[i].IdcertspDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp_Dettaglio"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspDettaglioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspDettaglioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdcertspDettaglio", (SiarLibrary.NullTypes.IntNT)CertspDettaglioCollectionObj[i].IdcertspDettaglio);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspDettaglioCollectionObj.Count; i++)
				{
					if ((CertspDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspDettaglioCollectionObj[i].IsDirty = false;
						CertspDettaglioCollectionObj[i].IsPersistent = true;
					}
					if ((CertspDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspDettaglioCollectionObj[i].IsDirty = false;
						CertspDettaglioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspDettaglio CertspDettaglioObj)
		{
			int returnValue = 0;
			if (CertspDettaglioObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspDettaglioObj.IdcertspDettaglio);
			}
			CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspDettaglioObj.IsDirty = false;
			CertspDettaglioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdcertspDettaglioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDettaglioDelete", new string[] {"IdcertspDettaglio"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdcertspDettaglio", (SiarLibrary.NullTypes.IntNT)IdcertspDettaglioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspDettaglioCollection CertspDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspDettaglioDelete", new string[] {"IdcertspDettaglio"}, new string[] {"int"},"");
				for (int i = 0; i < CertspDettaglioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdcertspDettaglio", CertspDettaglioCollectionObj[i].IdcertspDettaglio);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspDettaglioCollectionObj.Count; i++)
				{
					if ((CertspDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspDettaglioCollectionObj[i].IsDirty = false;
						CertspDettaglioCollectionObj[i].IsPersistent = false;
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
		public static CertspDettaglio GetById(DbProvider db, int IdcertspDettaglioValue)
		{
			CertspDettaglio CertspDettaglioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspDettaglioGetById", new string[] {"IdcertspDettaglio"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdcertspDettaglio", (SiarLibrary.NullTypes.IntNT)IdcertspDettaglioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspDettaglioObj = GetFromDatareader(db);
				CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDettaglioObj.IsDirty = false;
				CertspDettaglioObj.IsPersistent = true;
			}
			db.Close();
			return CertspDettaglioObj;
		}

		//getFromDatareader
		public static CertspDettaglio GetFromDatareader(DbProvider db)
		{
			CertspDettaglio CertspDettaglioObj = new CertspDettaglio();
			CertspDettaglioObj.IdcertspDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp_Dettaglio"]);
			CertspDettaglioObj.Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
			CertspDettaglioObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
			CertspDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
			CertspDettaglioObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["Asse"]);
			CertspDettaglioObj.Selezionata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Selezionata"]);
			CertspDettaglioObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["Esito"]);
			CertspDettaglioObj.Dataesito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataEsito"]);
			CertspDettaglioObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_File"]);
			CertspDettaglioObj.Costototale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CostoTotale"]);
			CertspDettaglioObj.Importoammesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoAmmesso"]);
			CertspDettaglioObj.Importoconcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoConcesso"]);
			CertspDettaglioObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["Beneficiario"]);
			CertspDettaglioObj.Spesaammessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa"]);
			CertspDettaglioObj.Importocontributopubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico"]);
			CertspDettaglioObj.SpesaammessaIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa_Incrementale"]);
			CertspDettaglioObj.ImportocontributopubblicoIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico_Incrementale"]);
			CertspDettaglioObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["Note"]);
			CertspDettaglioObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Operatore"]);
			CertspDettaglioObj.Datainserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInserimento"]);
			CertspDettaglioObj.Datamodifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataModifica"]);
			CertspDettaglioObj.Quotaue = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QuotaUe"]);
			CertspDettaglioObj.Quotastato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QuotaStato"]);
			CertspDettaglioObj.Quotaregione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QuotaRegione"]);
			CertspDettaglioObj.Quotaprivato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QuotaPrivato"]);
			CertspDettaglioObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPsr"]);
			CertspDettaglioObj.Datafine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataFine"]);
			CertspDettaglioObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Definitivo"]);
			CertspDettaglioObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Tipo"]);
			CertspDettaglioObj.CodiceCup = new SiarLibrary.NullTypes.StringNT(db.DataReader["Codice_Cup"]);
			CertspDettaglioObj.CupNaturaCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["Cup_Natura_Codice"]);
			CertspDettaglioObj.CupNaturaDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Cup_Natura_Descrizione"]);
			CertspDettaglioObj.Titoloprogetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["TitoloProgetto"]);
			CertspDettaglioObj.Tipodomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TipoDomanda"]);
			CertspDettaglioObj.ObiettivoSpecifico = new SiarLibrary.NullTypes.StringNT(db.DataReader["Obiettivo_Specifico"]);
			CertspDettaglioObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Azione"]);
			CertspDettaglioObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["Intervento"]);
			CertspDettaglioObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Bando"]);
			CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspDettaglioObj.IsDirty = false;
			CertspDettaglioObj.IsPersistent = true;
			return CertspDettaglioObj;
		}

		//Find Select

		public static CertspDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdcertspDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdcertspEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataEqualThis, 
SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataesitoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostototaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoammessoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoconcessoEqualThis, 
SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaammessaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportocontributopubblicoEqualThis, 
SiarLibrary.NullTypes.DecimalNT SpesaammessaIncrementaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportocontributopubblicoIncrementaleEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatamodificaEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaueEqualThis, SiarLibrary.NullTypes.DecimalNT QuotastatoEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaregioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaprivatoEqualThis)

		{

			CertspDettaglioCollection CertspDettaglioCollectionObj = new CertspDettaglioCollection();

			IDbCommand findCmd = db.InitCmd("Zcertspdettagliofindselect", new string[] {"IdcertspDettaglioequalthis", "Idcertspequalthis", "IdDomandaPagamentoequalthis", 
"IdProgettoequalthis", "Asseequalthis", "Selezionataequalthis", 
"Esitoequalthis", "Dataesitoequalthis", "IdFileequalthis", 
"Costototaleequalthis", "Importoammessoequalthis", "Importoconcessoequalthis", 
"Beneficiarioequalthis", "Spesaammessaequalthis", "Importocontributopubblicoequalthis", 
"SpesaammessaIncrementaleequalthis", "ImportocontributopubblicoIncrementaleequalthis", "Noteequalthis", 
"Operatoreequalthis", "Datainserimentoequalthis", "Datamodificaequalthis", 
"Quotaueequalthis", "Quotastatoequalthis", "Quotaregioneequalthis", 
"Quotaprivatoequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "int", 
"decimal", "decimal", "decimal", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"decimal", "decimal", "decimal", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdcertspDettaglioequalthis", IdcertspDettaglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idcertspequalthis", IdcertspEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Selezionataequalthis", SelezionataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataesitoequalthis", DataesitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Costototaleequalthis", CostototaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoammessoequalthis", ImportoammessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoconcessoequalthis", ImportoconcessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Spesaammessaequalthis", SpesaammessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importocontributopubblicoequalthis", ImportocontributopubblicoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaammessaIncrementaleequalthis", SpesaammessaIncrementaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportocontributopubblicoIncrementaleequalthis", ImportocontributopubblicoIncrementaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datainserimentoequalthis", DatainserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datamodificaequalthis", DatamodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotaueequalthis", QuotaueEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotastatoequalthis", QuotastatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotaregioneequalthis", QuotaregioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Quotaprivatoequalthis", QuotaprivatoEqualThis);
			CertspDettaglio CertspDettaglioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspDettaglioObj = GetFromDatareader(db);
				CertspDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspDettaglioObj.IsDirty = false;
				CertspDettaglioObj.IsPersistent = true;
				CertspDettaglioCollectionObj.Add(CertspDettaglioObj);
			}
			db.Close();
			return CertspDettaglioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspDettaglioCollectionProvider:ICertspDettaglioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspDettaglioCollectionProvider : ICertspDettaglioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspDettaglio
		protected CertspDettaglioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspDettaglioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspDettaglioCollection(this);
		}

		//Costruttore3: ha in input certspdettaglioCollectionObj - non popola la collection
		public CertspDettaglioCollectionProvider(CertspDettaglioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspDettaglioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspDettaglioCollection(this);
		}

		//Get e Set
		public CertspDettaglioCollection CollectionObj
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
		public int SaveCollection(CertspDettaglioCollection collectionObj)
		{
			return CertspDettaglioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspDettaglio certspdettaglioObj)
		{
			return CertspDettaglioDAL.Save(_dbProviderObj, certspdettaglioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspDettaglioCollection collectionObj)
		{
			return CertspDettaglioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspDettaglio certspdettaglioObj)
		{
			return CertspDettaglioDAL.Delete(_dbProviderObj, certspdettaglioObj);
		}

		//getById
		public CertspDettaglio GetById(IntNT IdcertspDettaglioValue)
		{
			CertspDettaglio CertspDettaglioTemp = CertspDettaglioDAL.GetById(_dbProviderObj, IdcertspDettaglioValue);
			if (CertspDettaglioTemp!=null) CertspDettaglioTemp.Provider = this;
			return CertspDettaglioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspDettaglioCollection Select(IntNT IdcertspdettaglioEqualThis, IntNT IdcertspEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdprogettoEqualThis, StringNT AsseEqualThis, BoolNT SelezionataEqualThis, 
StringNT EsitoEqualThis, DatetimeNT DataesitoEqualThis, IntNT IdfileEqualThis, 
DecimalNT CostototaleEqualThis, DecimalNT ImportoammessoEqualThis, DecimalNT ImportoconcessoEqualThis, 
StringNT BeneficiarioEqualThis, DecimalNT SpesaammessaEqualThis, DecimalNT ImportocontributopubblicoEqualThis, 
DecimalNT SpesaammessaincrementaleEqualThis, DecimalNT ImportocontributopubblicoincrementaleEqualThis, StringNT NoteEqualThis, 
StringNT OperatoreEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, 
DecimalNT QuotaueEqualThis, DecimalNT QuotastatoEqualThis, DecimalNT QuotaregioneEqualThis, 
DecimalNT QuotaprivatoEqualThis)
		{
			CertspDettaglioCollection CertspDettaglioCollectionTemp = CertspDettaglioDAL.Select(_dbProviderObj, IdcertspdettaglioEqualThis, IdcertspEqualThis, IddomandapagamentoEqualThis, 
IdprogettoEqualThis, AsseEqualThis, SelezionataEqualThis, 
EsitoEqualThis, DataesitoEqualThis, IdfileEqualThis, 
CostototaleEqualThis, ImportoammessoEqualThis, ImportoconcessoEqualThis, 
BeneficiarioEqualThis, SpesaammessaEqualThis, ImportocontributopubblicoEqualThis, 
SpesaammessaincrementaleEqualThis, ImportocontributopubblicoincrementaleEqualThis, NoteEqualThis, 
OperatoreEqualThis, DatainserimentoEqualThis, DatamodificaEqualThis, 
QuotaueEqualThis, QuotastatoEqualThis, QuotaregioneEqualThis, 
QuotaprivatoEqualThis);
			CertspDettaglioCollectionTemp.Provider = this;
			return CertspDettaglioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CertSp_Dettaglio>
  <ViewName>vCertSp_Dettaglio</ViewName>
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
</CertSp_Dettaglio>
*/
