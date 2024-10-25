using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CntrlocoDettaglio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICntrlocoDettaglioProvider
	{
		int Save(CntrlocoDettaglio CntrlocoDettaglioObj);
		int SaveCollection(CntrlocoDettaglioCollection collectionObj);
		int Delete(CntrlocoDettaglio CntrlocoDettaglioObj);
		int DeleteCollection(CntrlocoDettaglioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CntrlocoDettaglio
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CntrlocoDettaglio: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdlocoDettaglio;
		private NullTypes.IntNT _Idloco;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Asse;
		private NullTypes.BoolNT _Selezionata;
		private NullTypes.StringNT _Esito;
		private NullTypes.DatetimeNT _Dataesito;
		private NullTypes.DecimalNT _Costototale;
		private NullTypes.DecimalNT _Importoammesso;
		private NullTypes.DecimalNT _Importoconcesso;
		private NullTypes.IntNT _Nroperazionib;
		private NullTypes.StringNT _Beneficiario;
		private NullTypes.DecimalNT _Spesaammessa;
		private NullTypes.DecimalNT _Importocontributopubblico;
		private NullTypes.DecimalNT _SpesaammessaIncrementale;
		private NullTypes.DecimalNT _ImportocontributopubblicoIncrementale;
		private NullTypes.StringNT _Esclusione;
		private NullTypes.DecimalNT _Rischioir;
		private NullTypes.DecimalNT _Rischiocr;
		private NullTypes.StringNT _Rischiocomp;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _Datainserimento;
		private NullTypes.DatetimeNT _Datamodifica;
		private NullTypes.StringNT _Azione;
		private NullTypes.StringNT _Intervento;
		private NullTypes.StringNT _Codpsr;
		private NullTypes.DatetimeNT _Datafine;
		private NullTypes.BoolNT _Definitivo;
		private NullTypes.StringNT _CodiceCup;
		private NullTypes.StringNT _CupNaturaCodice;
		private NullTypes.StringNT _CupNaturaDescrizione;
		private NullTypes.StringNT _Titoloprogetto;
		private NullTypes.StringNT _Tipodomanda;
		[NonSerialized] private ICntrlocoDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICntrlocoDettaglioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CntrlocoDettaglio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:IdLoco_Dettaglio
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdlocoDettaglio
		{
			get { return _IdlocoDettaglio; }
			set {
				if (IdlocoDettaglio != value)
				{
					_IdlocoDettaglio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IdLoco
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Idloco
		{
			get { return _Idloco; }
			set {
				if (Idloco != value)
				{
					_Idloco = value;
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
		/// Corrisponde al campo:NrOperazioniB
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Nroperazionib
		{
			get { return _Nroperazionib; }
			set {
				if (Nroperazionib != value)
				{
					_Nroperazionib = value;
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
		/// Corrisponde al campo:Esclusione
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Esclusione
		{
			get { return _Esclusione; }
			set {
				if (Esclusione != value)
				{
					_Esclusione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RischioIR
		/// Tipo sul db:DECIMAL(6,2)
		/// </summary>
		public NullTypes.DecimalNT Rischioir
		{
			get { return _Rischioir; }
			set {
				if (Rischioir != value)
				{
					_Rischioir = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RischioCR
		/// Tipo sul db:DECIMAL(6,2)
		/// </summary>
		public NullTypes.DecimalNT Rischiocr
		{
			get { return _Rischiocr; }
			set {
				if (Rischiocr != value)
				{
					_Rischiocr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RischioComp
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Rischiocomp
		{
			get { return _Rischiocomp; }
			set {
				if (Rischiocomp != value)
				{
					_Rischiocomp = value;
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
		/// Corrisponde al campo:Codice_Cup
		/// Tipo sul db:VARCHAR(30)
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
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Titoloprogetto
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
	/// Summary description for CntrlocoDettaglioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CntrlocoDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CntrlocoDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CntrlocoDettaglio) info.GetValue(i.ToString(),typeof(CntrlocoDettaglio)));
			}
		}

		//Costruttore
		public CntrlocoDettaglioCollection()
		{
			this.ItemType = typeof(CntrlocoDettaglio);
		}

		//Costruttore con provider
		public CntrlocoDettaglioCollection(ICntrlocoDettaglioProvider providerObj)
		{
			this.ItemType = typeof(CntrlocoDettaglio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CntrlocoDettaglio this[int index]
		{
			get { return (CntrlocoDettaglio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CntrlocoDettaglioCollection GetChanges()
		{
			return (CntrlocoDettaglioCollection) base.GetChanges();
		}

		[NonSerialized] private ICntrlocoDettaglioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICntrlocoDettaglioProvider Provider
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
		public int Add(CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			if (CntrlocoDettaglioObj.Provider == null) CntrlocoDettaglioObj.Provider = this.Provider;
			return base.Add(CntrlocoDettaglioObj);
		}

		//AddCollection
		public void AddCollection(CntrlocoDettaglioCollection CntrlocoDettaglioCollectionObj)
		{
			foreach (CntrlocoDettaglio CntrlocoDettaglioObj in CntrlocoDettaglioCollectionObj)
				this.Add(CntrlocoDettaglioObj);
		}

		//Insert
		public void Insert(int index, CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			if (CntrlocoDettaglioObj.Provider == null) CntrlocoDettaglioObj.Provider = this.Provider;
			base.Insert(index, CntrlocoDettaglioObj);
		}

		//CollectionGetById
		public CntrlocoDettaglio CollectionGetById(NullTypes.IntNT IdlocoDettaglioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdlocoDettaglio == IdlocoDettaglioValue))
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
		public CntrlocoDettaglioCollection SubSelect(NullTypes.IntNT IdlocoDettaglioEqualThis, NullTypes.IntNT IdlocoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT AsseEqualThis, NullTypes.BoolNT SelezionataEqualThis, 
NullTypes.StringNT EsitoEqualThis, NullTypes.DatetimeNT DataesitoEqualThis, NullTypes.DecimalNT CostototaleEqualThis, 
NullTypes.DecimalNT ImportoammessoEqualThis, NullTypes.DecimalNT ImportoconcessoEqualThis, NullTypes.IntNT NroperazionibEqualThis, 
NullTypes.StringNT BeneficiarioEqualThis, NullTypes.DecimalNT SpesaammessaEqualThis, NullTypes.DecimalNT ImportocontributopubblicoEqualThis, 
NullTypes.DecimalNT SpesaammessaIncrementaleEqualThis, NullTypes.DecimalNT ImportocontributopubblicoIncrementaleEqualThis, NullTypes.StringNT EsclusioneEqualThis, 
NullTypes.DecimalNT RischioirEqualThis, NullTypes.DecimalNT RischiocrEqualThis, NullTypes.StringNT RischiocompEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DatainserimentoEqualThis, NullTypes.DatetimeNT DatamodificaEqualThis, 
NullTypes.StringNT AzioneEqualThis, NullTypes.StringNT InterventoEqualThis)
		{
			CntrlocoDettaglioCollection CntrlocoDettaglioCollectionTemp = new CntrlocoDettaglioCollection();
			foreach (CntrlocoDettaglio CntrlocoDettaglioItem in this)
			{
				if (((IdlocoDettaglioEqualThis == null) || ((CntrlocoDettaglioItem.IdlocoDettaglio != null) && (CntrlocoDettaglioItem.IdlocoDettaglio.Value == IdlocoDettaglioEqualThis.Value))) && ((IdlocoEqualThis == null) || ((CntrlocoDettaglioItem.Idloco != null) && (CntrlocoDettaglioItem.Idloco.Value == IdlocoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((CntrlocoDettaglioItem.IdDomandaPagamento != null) && (CntrlocoDettaglioItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((CntrlocoDettaglioItem.IdProgetto != null) && (CntrlocoDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((AsseEqualThis == null) || ((CntrlocoDettaglioItem.Asse != null) && (CntrlocoDettaglioItem.Asse.Value == AsseEqualThis.Value))) && ((SelezionataEqualThis == null) || ((CntrlocoDettaglioItem.Selezionata != null) && (CntrlocoDettaglioItem.Selezionata.Value == SelezionataEqualThis.Value))) && 
((EsitoEqualThis == null) || ((CntrlocoDettaglioItem.Esito != null) && (CntrlocoDettaglioItem.Esito.Value == EsitoEqualThis.Value))) && ((DataesitoEqualThis == null) || ((CntrlocoDettaglioItem.Dataesito != null) && (CntrlocoDettaglioItem.Dataesito.Value == DataesitoEqualThis.Value))) && ((CostototaleEqualThis == null) || ((CntrlocoDettaglioItem.Costototale != null) && (CntrlocoDettaglioItem.Costototale.Value == CostototaleEqualThis.Value))) && 
((ImportoammessoEqualThis == null) || ((CntrlocoDettaglioItem.Importoammesso != null) && (CntrlocoDettaglioItem.Importoammesso.Value == ImportoammessoEqualThis.Value))) && ((ImportoconcessoEqualThis == null) || ((CntrlocoDettaglioItem.Importoconcesso != null) && (CntrlocoDettaglioItem.Importoconcesso.Value == ImportoconcessoEqualThis.Value))) && ((NroperazionibEqualThis == null) || ((CntrlocoDettaglioItem.Nroperazionib != null) && (CntrlocoDettaglioItem.Nroperazionib.Value == NroperazionibEqualThis.Value))) && 
((BeneficiarioEqualThis == null) || ((CntrlocoDettaglioItem.Beneficiario != null) && (CntrlocoDettaglioItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SpesaammessaEqualThis == null) || ((CntrlocoDettaglioItem.Spesaammessa != null) && (CntrlocoDettaglioItem.Spesaammessa.Value == SpesaammessaEqualThis.Value))) && ((ImportocontributopubblicoEqualThis == null) || ((CntrlocoDettaglioItem.Importocontributopubblico != null) && (CntrlocoDettaglioItem.Importocontributopubblico.Value == ImportocontributopubblicoEqualThis.Value))) && 
((SpesaammessaIncrementaleEqualThis == null) || ((CntrlocoDettaglioItem.SpesaammessaIncrementale != null) && (CntrlocoDettaglioItem.SpesaammessaIncrementale.Value == SpesaammessaIncrementaleEqualThis.Value))) && ((ImportocontributopubblicoIncrementaleEqualThis == null) || ((CntrlocoDettaglioItem.ImportocontributopubblicoIncrementale != null) && (CntrlocoDettaglioItem.ImportocontributopubblicoIncrementale.Value == ImportocontributopubblicoIncrementaleEqualThis.Value))) && ((EsclusioneEqualThis == null) || ((CntrlocoDettaglioItem.Esclusione != null) && (CntrlocoDettaglioItem.Esclusione.Value == EsclusioneEqualThis.Value))) && 
((RischioirEqualThis == null) || ((CntrlocoDettaglioItem.Rischioir != null) && (CntrlocoDettaglioItem.Rischioir.Value == RischioirEqualThis.Value))) && ((RischiocrEqualThis == null) || ((CntrlocoDettaglioItem.Rischiocr != null) && (CntrlocoDettaglioItem.Rischiocr.Value == RischiocrEqualThis.Value))) && ((RischiocompEqualThis == null) || ((CntrlocoDettaglioItem.Rischiocomp != null) && (CntrlocoDettaglioItem.Rischiocomp.Value == RischiocompEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CntrlocoDettaglioItem.Operatore != null) && (CntrlocoDettaglioItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DatainserimentoEqualThis == null) || ((CntrlocoDettaglioItem.Datainserimento != null) && (CntrlocoDettaglioItem.Datainserimento.Value == DatainserimentoEqualThis.Value))) && ((DatamodificaEqualThis == null) || ((CntrlocoDettaglioItem.Datamodifica != null) && (CntrlocoDettaglioItem.Datamodifica.Value == DatamodificaEqualThis.Value))) && 
((AzioneEqualThis == null) || ((CntrlocoDettaglioItem.Azione != null) && (CntrlocoDettaglioItem.Azione.Value == AzioneEqualThis.Value))) && ((InterventoEqualThis == null) || ((CntrlocoDettaglioItem.Intervento != null) && (CntrlocoDettaglioItem.Intervento.Value == InterventoEqualThis.Value))))
				{
					CntrlocoDettaglioCollectionTemp.Add(CntrlocoDettaglioItem);
				}
			}
			return CntrlocoDettaglioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CntrlocoDettaglioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CntrlocoDettaglioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CntrlocoDettaglio CntrlocoDettaglioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdlocoDettaglio", CntrlocoDettaglioObj.IdlocoDettaglio);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Idloco", CntrlocoDettaglioObj.Idloco);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", CntrlocoDettaglioObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", CntrlocoDettaglioObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Asse", CntrlocoDettaglioObj.Asse);
			DbProvider.SetCmdParam(cmd,firstChar + "Selezionata", CntrlocoDettaglioObj.Selezionata);
			DbProvider.SetCmdParam(cmd,firstChar + "Esito", CntrlocoDettaglioObj.Esito);
			DbProvider.SetCmdParam(cmd,firstChar + "Dataesito", CntrlocoDettaglioObj.Dataesito);
			DbProvider.SetCmdParam(cmd,firstChar + "Costototale", CntrlocoDettaglioObj.Costototale);
			DbProvider.SetCmdParam(cmd,firstChar + "Importoammesso", CntrlocoDettaglioObj.Importoammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Importoconcesso", CntrlocoDettaglioObj.Importoconcesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Nroperazionib", CntrlocoDettaglioObj.Nroperazionib);
			DbProvider.SetCmdParam(cmd,firstChar + "Beneficiario", CntrlocoDettaglioObj.Beneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "Spesaammessa", CntrlocoDettaglioObj.Spesaammessa);
			DbProvider.SetCmdParam(cmd,firstChar + "Importocontributopubblico", CntrlocoDettaglioObj.Importocontributopubblico);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaammessaIncrementale", CntrlocoDettaglioObj.SpesaammessaIncrementale);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportocontributopubblicoIncrementale", CntrlocoDettaglioObj.ImportocontributopubblicoIncrementale);
			DbProvider.SetCmdParam(cmd,firstChar + "Esclusione", CntrlocoDettaglioObj.Esclusione);
			DbProvider.SetCmdParam(cmd,firstChar + "Rischioir", CntrlocoDettaglioObj.Rischioir);
			DbProvider.SetCmdParam(cmd,firstChar + "Rischiocr", CntrlocoDettaglioObj.Rischiocr);
			DbProvider.SetCmdParam(cmd,firstChar + "Rischiocomp", CntrlocoDettaglioObj.Rischiocomp);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CntrlocoDettaglioObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainserimento", CntrlocoDettaglioObj.Datainserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Datamodifica", CntrlocoDettaglioObj.Datamodifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Azione", CntrlocoDettaglioObj.Azione);
			DbProvider.SetCmdParam(cmd,firstChar + "Intervento", CntrlocoDettaglioObj.Intervento);
		}
		//Insert
		private static int Insert(DbProvider db, CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCntrlocoDettaglioInsert", new string[] {"Idloco", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "Costototale", 
"Importoammesso", "Importoconcesso", "Nroperazionib", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Esclusione", 
"Rischioir", "Rischiocr", "Rischiocomp", 
"Operatore", "Datainserimento", "Datamodifica", 
"Azione", "Intervento", 

}, new string[] {"int", "int", 
"int", "string", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"string", "string", 

},"");
				CompileIUCmd(false, insertCmd,CntrlocoDettaglioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CntrlocoDettaglioObj.IdlocoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco_Dettaglio"]);
				}
				CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CntrlocoDettaglioObj.IsDirty = false;
				CntrlocoDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCntrlocoDettaglioUpdate", new string[] {"IdlocoDettaglio", "Idloco", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "Costototale", 
"Importoammesso", "Importoconcesso", "Nroperazionib", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Esclusione", 
"Rischioir", "Rischiocr", "Rischiocomp", 
"Operatore", "Datainserimento", "Datamodifica", 
"Azione", "Intervento", 

}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"string", "string", 

},"");
				CompileIUCmd(true, updateCmd,CntrlocoDettaglioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CntrlocoDettaglioObj.IsDirty = false;
				CntrlocoDettaglioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			switch (CntrlocoDettaglioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CntrlocoDettaglioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CntrlocoDettaglioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CntrlocoDettaglioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CntrlocoDettaglioCollection CntrlocoDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCntrlocoDettaglioUpdate", new string[] {"IdlocoDettaglio", "Idloco", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "Costototale", 
"Importoammesso", "Importoconcesso", "Nroperazionib", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Esclusione", 
"Rischioir", "Rischiocr", "Rischiocomp", 
"Operatore", "Datainserimento", "Datamodifica", 
"Azione", "Intervento", 

}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"string", "string", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZCntrlocoDettaglioInsert", new string[] {"Idloco", "IdDomandaPagamento", 
"IdProgetto", "Asse", "Selezionata", 
"Esito", "Dataesito", "Costototale", 
"Importoammesso", "Importoconcesso", "Nroperazionib", 
"Beneficiario", "Spesaammessa", "Importocontributopubblico", 
"SpesaammessaIncrementale", "ImportocontributopubblicoIncrementale", "Esclusione", 
"Rischioir", "Rischiocr", "Rischiocomp", 
"Operatore", "Datainserimento", "Datamodifica", 
"Azione", "Intervento", 

}, new string[] {"int", "int", 
"int", "string", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"string", "string", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCntrlocoDettaglioDelete", new string[] {"IdlocoDettaglio"}, new string[] {"int"},"");
				for (int i = 0; i < CntrlocoDettaglioCollectionObj.Count; i++)
				{
					switch (CntrlocoDettaglioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CntrlocoDettaglioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CntrlocoDettaglioCollectionObj[i].IdlocoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco_Dettaglio"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CntrlocoDettaglioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CntrlocoDettaglioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdlocoDettaglio", (SiarLibrary.NullTypes.IntNT)CntrlocoDettaglioCollectionObj[i].IdlocoDettaglio);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CntrlocoDettaglioCollectionObj.Count; i++)
				{
					if ((CntrlocoDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CntrlocoDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CntrlocoDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CntrlocoDettaglioCollectionObj[i].IsDirty = false;
						CntrlocoDettaglioCollectionObj[i].IsPersistent = true;
					}
					if ((CntrlocoDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CntrlocoDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CntrlocoDettaglioCollectionObj[i].IsDirty = false;
						CntrlocoDettaglioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CntrlocoDettaglio CntrlocoDettaglioObj)
		{
			int returnValue = 0;
			if (CntrlocoDettaglioObj.IsPersistent) 
			{
				returnValue = Delete(db, CntrlocoDettaglioObj.IdlocoDettaglio);
			}
			CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CntrlocoDettaglioObj.IsDirty = false;
			CntrlocoDettaglioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdlocoDettaglioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCntrlocoDettaglioDelete", new string[] {"IdlocoDettaglio"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdlocoDettaglio", (SiarLibrary.NullTypes.IntNT)IdlocoDettaglioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CntrlocoDettaglioCollection CntrlocoDettaglioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCntrlocoDettaglioDelete", new string[] {"IdlocoDettaglio"}, new string[] {"int"},"");
				for (int i = 0; i < CntrlocoDettaglioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdlocoDettaglio", CntrlocoDettaglioCollectionObj[i].IdlocoDettaglio);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CntrlocoDettaglioCollectionObj.Count; i++)
				{
					if ((CntrlocoDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CntrlocoDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CntrlocoDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CntrlocoDettaglioCollectionObj[i].IsDirty = false;
						CntrlocoDettaglioCollectionObj[i].IsPersistent = false;
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
		public static CntrlocoDettaglio GetById(DbProvider db, int IdlocoDettaglioValue)
		{
			CntrlocoDettaglio CntrlocoDettaglioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCntrlocoDettaglioGetById", new string[] {"IdlocoDettaglio"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdlocoDettaglio", (SiarLibrary.NullTypes.IntNT)IdlocoDettaglioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CntrlocoDettaglioObj = GetFromDatareader(db);
				CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CntrlocoDettaglioObj.IsDirty = false;
				CntrlocoDettaglioObj.IsPersistent = true;
			}
			db.Close();
			return CntrlocoDettaglioObj;
		}

		//getFromDatareader
		public static CntrlocoDettaglio GetFromDatareader(DbProvider db)
		{
			CntrlocoDettaglio CntrlocoDettaglioObj = new CntrlocoDettaglio();
			CntrlocoDettaglioObj.IdlocoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco_Dettaglio"]);
			CntrlocoDettaglioObj.Idloco = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdLoco"]);
			CntrlocoDettaglioObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Domanda_Pagamento"]);
			CntrlocoDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_Progetto"]);
			CntrlocoDettaglioObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["Asse"]);
			CntrlocoDettaglioObj.Selezionata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Selezionata"]);
			CntrlocoDettaglioObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["Esito"]);
			CntrlocoDettaglioObj.Dataesito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataEsito"]);
			CntrlocoDettaglioObj.Costototale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CostoTotale"]);
			CntrlocoDettaglioObj.Importoammesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoAmmesso"]);
			CntrlocoDettaglioObj.Importoconcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoConcesso"]);
			CntrlocoDettaglioObj.Nroperazionib = new SiarLibrary.NullTypes.IntNT(db.DataReader["NrOperazioniB"]);
			CntrlocoDettaglioObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["Beneficiario"]);
			CntrlocoDettaglioObj.Spesaammessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa"]);
			CntrlocoDettaglioObj.Importocontributopubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico"]);
			CntrlocoDettaglioObj.SpesaammessaIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SpesaAmmessa_Incrementale"]);
			CntrlocoDettaglioObj.ImportocontributopubblicoIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ImportoContributoPubblico_Incrementale"]);
			CntrlocoDettaglioObj.Esclusione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Esclusione"]);
			CntrlocoDettaglioObj.Rischioir = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioIR"]);
			CntrlocoDettaglioObj.Rischiocr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RischioCR"]);
			CntrlocoDettaglioObj.Rischiocomp = new SiarLibrary.NullTypes.StringNT(db.DataReader["RischioComp"]);
			CntrlocoDettaglioObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Operatore"]);
			CntrlocoDettaglioObj.Datainserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInserimento"]);
			CntrlocoDettaglioObj.Datamodifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataModifica"]);
			CntrlocoDettaglioObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Azione"]);
			CntrlocoDettaglioObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["Intervento"]);
			CntrlocoDettaglioObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPsr"]);
			CntrlocoDettaglioObj.Datafine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataFine"]);
			CntrlocoDettaglioObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Definitivo"]);
			CntrlocoDettaglioObj.CodiceCup = new SiarLibrary.NullTypes.StringNT(db.DataReader["Codice_Cup"]);
			CntrlocoDettaglioObj.CupNaturaCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["Cup_Natura_Codice"]);
			CntrlocoDettaglioObj.CupNaturaDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Cup_Natura_Descrizione"]);
			CntrlocoDettaglioObj.Titoloprogetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TitoloProgetto"]);
			CntrlocoDettaglioObj.Tipodomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TipoDomanda"]);
			CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CntrlocoDettaglioObj.IsDirty = false;
			CntrlocoDettaglioObj.IsPersistent = true;
			return CntrlocoDettaglioObj;
		}

		//Find Select

		public static CntrlocoDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdlocoDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdlocoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataEqualThis, 
SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataesitoEqualThis, SiarLibrary.NullTypes.DecimalNT CostototaleEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoammessoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoconcessoEqualThis, SiarLibrary.NullTypes.IntNT NroperazionibEqualThis, 
SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaammessaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportocontributopubblicoEqualThis, 
SiarLibrary.NullTypes.DecimalNT SpesaammessaIncrementaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportocontributopubblicoIncrementaleEqualThis, SiarLibrary.NullTypes.StringNT EsclusioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT RischioirEqualThis, SiarLibrary.NullTypes.DecimalNT RischiocrEqualThis, SiarLibrary.NullTypes.StringNT RischiocompEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatamodificaEqualThis, 
SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.StringNT InterventoEqualThis)

		{

			CntrlocoDettaglioCollection CntrlocoDettaglioCollectionObj = new CntrlocoDettaglioCollection();

			IDbCommand findCmd = db.InitCmd("Zcntrlocodettagliofindselect", new string[] {"IdlocoDettaglioequalthis", "Idlocoequalthis", "IdDomandaPagamentoequalthis", 
"IdProgettoequalthis", "Asseequalthis", "Selezionataequalthis", 
"Esitoequalthis", "Dataesitoequalthis", "Costototaleequalthis", 
"Importoammessoequalthis", "Importoconcessoequalthis", "Nroperazionibequalthis", 
"Beneficiarioequalthis", "Spesaammessaequalthis", "Importocontributopubblicoequalthis", 
"SpesaammessaIncrementaleequalthis", "ImportocontributopubblicoIncrementaleequalthis", "Esclusioneequalthis", 
"Rischioirequalthis", "Rischiocrequalthis", "Rischiocompequalthis", 
"Operatoreequalthis", "Datainserimentoequalthis", "Datamodificaequalthis", 
"Azioneequalthis", "Interventoequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "string", 
"decimal", "decimal", "string", 
"string", "DateTime", "DateTime", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdlocoDettaglioequalthis", IdlocoDettaglioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idlocoequalthis", IdlocoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Selezionataequalthis", SelezionataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataesitoequalthis", DataesitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Costototaleequalthis", CostototaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoammessoequalthis", ImportoammessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoconcessoequalthis", ImportoconcessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nroperazionibequalthis", NroperazionibEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Spesaammessaequalthis", SpesaammessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importocontributopubblicoequalthis", ImportocontributopubblicoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaammessaIncrementaleequalthis", SpesaammessaIncrementaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportocontributopubblicoIncrementaleequalthis", ImportocontributopubblicoIncrementaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Esclusioneequalthis", EsclusioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rischioirequalthis", RischioirEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rischiocrequalthis", RischiocrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rischiocompequalthis", RischiocompEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datainserimentoequalthis", DatainserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datamodificaequalthis", DatamodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
			CntrlocoDettaglio CntrlocoDettaglioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CntrlocoDettaglioObj = GetFromDatareader(db);
				CntrlocoDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CntrlocoDettaglioObj.IsDirty = false;
				CntrlocoDettaglioObj.IsPersistent = true;
				CntrlocoDettaglioCollectionObj.Add(CntrlocoDettaglioObj);
			}
			db.Close();
			return CntrlocoDettaglioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CntrlocoDettaglioCollectionProvider:ICntrlocoDettaglioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CntrlocoDettaglioCollectionProvider : ICntrlocoDettaglioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CntrlocoDettaglio
		protected CntrlocoDettaglioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CntrlocoDettaglioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CntrlocoDettaglioCollection(this);
		}

		//Costruttore3: ha in input cntrlocodettaglioCollectionObj - non popola la collection
		public CntrlocoDettaglioCollectionProvider(CntrlocoDettaglioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CntrlocoDettaglioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CntrlocoDettaglioCollection(this);
		}

		//Get e Set
		public CntrlocoDettaglioCollection CollectionObj
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
		public int SaveCollection(CntrlocoDettaglioCollection collectionObj)
		{
			return CntrlocoDettaglioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CntrlocoDettaglio cntrlocodettaglioObj)
		{
			return CntrlocoDettaglioDAL.Save(_dbProviderObj, cntrlocodettaglioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CntrlocoDettaglioCollection collectionObj)
		{
			return CntrlocoDettaglioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CntrlocoDettaglio cntrlocodettaglioObj)
		{
			return CntrlocoDettaglioDAL.Delete(_dbProviderObj, cntrlocodettaglioObj);
		}

		//getById
		public CntrlocoDettaglio GetById(IntNT IdlocoDettaglioValue)
		{
			CntrlocoDettaglio CntrlocoDettaglioTemp = CntrlocoDettaglioDAL.GetById(_dbProviderObj, IdlocoDettaglioValue);
			if (CntrlocoDettaglioTemp!=null) CntrlocoDettaglioTemp.Provider = this;
			return CntrlocoDettaglioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CntrlocoDettaglioCollection Select(IntNT IdlocodettaglioEqualThis, IntNT IdlocoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdprogettoEqualThis, StringNT AsseEqualThis, BoolNT SelezionataEqualThis, 
StringNT EsitoEqualThis, DatetimeNT DataesitoEqualThis, DecimalNT CostototaleEqualThis, 
DecimalNT ImportoammessoEqualThis, DecimalNT ImportoconcessoEqualThis, IntNT NroperazionibEqualThis, 
StringNT BeneficiarioEqualThis, DecimalNT SpesaammessaEqualThis, DecimalNT ImportocontributopubblicoEqualThis, 
DecimalNT SpesaammessaincrementaleEqualThis, DecimalNT ImportocontributopubblicoincrementaleEqualThis, StringNT EsclusioneEqualThis, 
DecimalNT RischioirEqualThis, DecimalNT RischiocrEqualThis, StringNT RischiocompEqualThis, 
StringNT OperatoreEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, 
StringNT AzioneEqualThis, StringNT InterventoEqualThis)
		{
			CntrlocoDettaglioCollection CntrlocoDettaglioCollectionTemp = CntrlocoDettaglioDAL.Select(_dbProviderObj, IdlocodettaglioEqualThis, IdlocoEqualThis, IddomandapagamentoEqualThis, 
IdprogettoEqualThis, AsseEqualThis, SelezionataEqualThis, 
EsitoEqualThis, DataesitoEqualThis, CostototaleEqualThis, 
ImportoammessoEqualThis, ImportoconcessoEqualThis, NroperazionibEqualThis, 
BeneficiarioEqualThis, SpesaammessaEqualThis, ImportocontributopubblicoEqualThis, 
SpesaammessaincrementaleEqualThis, ImportocontributopubblicoincrementaleEqualThis, EsclusioneEqualThis, 
RischioirEqualThis, RischiocrEqualThis, RischiocompEqualThis, 
OperatoreEqualThis, DatainserimentoEqualThis, DatamodificaEqualThis, 
AzioneEqualThis, InterventoEqualThis);
			CntrlocoDettaglioCollectionTemp.Provider = this;
			return CntrlocoDettaglioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CntrLoco_Dettaglio>
  <ViewName>vCntrLoco_Dettaglio</ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CntrLoco_Dettaglio>
*/
