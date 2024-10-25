using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcovidConcessioneProgetti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcovidConcessioneProgetti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Capitolo;
		private NullTypes.StringNT _AnnoImp;
		private NullTypes.StringNT _AnnoSubimp;
		private NullTypes.StringNT _DescrizioneImpSubimp;
		private NullTypes.StringNT _Sistemaorigine;
		private NullTypes.IntNT _IdDomanda;
		private NullTypes.DecimalNT _Importo;
		private NullTypes.StringNT _DurcRegolare;
		private NullTypes.StringNT _CodiceCor;
		private NullTypes.StringNT _AnnoProposta;
		private NullTypes.StringNT _UnitaProponente;
		private NullTypes.StringNT _NumeroProposta;
		private NullTypes.StringNT _Transazione;
		private NullTypes.StringNT _CodiceRitenuta;
		private NullTypes.DecimalNT _ImponibileRitenuta;
		private NullTypes.DecimalNT _AliquotaRitenuta;
		private NullTypes.DecimalNT _ImportoRitenute;
		private NullTypes.StringNT _CausaleIrpef;
		private NullTypes.IntNT _Progressivo;
		private NullTypes.StringNT _ControlloEquitalia;
		private NullTypes.StringNT _Note;
		private NullTypes.IntNT _IdBando;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.BoolNT _Confermata;
		private NullTypes.DecimalNT _PercentualeImporto;
		private NullTypes.DecimalNT _CostoProgetto;
		private NullTypes.StringNT _DescrizioneInterventoSostitutivo;


		//Costruttore
		public VcovidConcessioneProgetti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:CAPITOLO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Capitolo
		{
			get { return _Capitolo; }
			set {
				if (Capitolo != value)
				{
					_Capitolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_IMP
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoImp
		{
			get { return _AnnoImp; }
			set {
				if (AnnoImp != value)
				{
					_AnnoImp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_SUBIMP
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoSubimp
		{
			get { return _AnnoSubimp; }
			set {
				if (AnnoSubimp != value)
				{
					_AnnoSubimp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_IMP_SUBIMP
		/// Tipo sul db:VARCHAR(140)
		/// </summary>
		public NullTypes.StringNT DescrizioneImpSubimp
		{
			get { return _DescrizioneImpSubimp; }
			set {
				if (DescrizioneImpSubimp != value)
				{
					_DescrizioneImpSubimp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SistemaOrigine
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Sistemaorigine
		{
			get { return _Sistemaorigine; }
			set {
				if (Sistemaorigine != value)
				{
					_Sistemaorigine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomanda
		{
			get { return _IdDomanda; }
			set {
				if (IdDomanda != value)
				{
					_IdDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DURC_REGOLARE
		/// Tipo sul db:VARCHAR(8)
		/// </summary>
		public NullTypes.StringNT DurcRegolare
		{
			get { return _DurcRegolare; }
			set {
				if (DurcRegolare != value)
				{
					_DurcRegolare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_COR
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodiceCor
		{
			get { return _CodiceCor; }
			set {
				if (CodiceCor != value)
				{
					_CodiceCor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO_PROPOSTA
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT AnnoProposta
		{
			get { return _AnnoProposta; }
			set {
				if (AnnoProposta != value)
				{
					_AnnoProposta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UNITA_PROPONENTE
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT UnitaProponente
		{
			get { return _UnitaProponente; }
			set {
				if (UnitaProponente != value)
				{
					_UnitaProponente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROPOSTA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT NumeroProposta
		{
			get { return _NumeroProposta; }
			set {
				if (NumeroProposta != value)
				{
					_NumeroProposta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TRANSAZIONE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Transazione
		{
			get { return _Transazione; }
			set {
				if (Transazione != value)
				{
					_Transazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_RITENUTA
		/// Tipo sul db:VARCHAR(32)
		/// </summary>
		public NullTypes.StringNT CodiceRitenuta
		{
			get { return _CodiceRitenuta; }
			set {
				if (CodiceRitenuta != value)
				{
					_CodiceRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPONIBILE_RITENUTA
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT ImponibileRitenuta
		{
			get { return _ImponibileRitenuta; }
			set {
				if (ImponibileRitenuta != value)
				{
					_ImponibileRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALIQUOTA_RITENUTA
		/// Tipo sul db:DECIMAL(20,2)
		/// </summary>
		public NullTypes.DecimalNT AliquotaRitenuta
		{
			get { return _AliquotaRitenuta; }
			set {
				if (AliquotaRitenuta != value)
				{
					_AliquotaRitenuta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RITENUTE
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT ImportoRitenute
		{
			get { return _ImportoRitenute; }
			set {
				if (ImportoRitenute != value)
				{
					_ImportoRitenute = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAUSALE_IRPEF
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT CausaleIrpef
		{
			get { return _CausaleIrpef; }
			set {
				if (CausaleIrpef != value)
				{
					_CausaleIrpef = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGRESSIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Progressivo
		{
			get { return _Progressivo; }
			set {
				if (Progressivo != value)
				{
					_Progressivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTROLLO_EQUITALIA
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT ControlloEquitalia
		{
			get { return _ControlloEquitalia; }
			set {
				if (ControlloEquitalia != value)
				{
					_ControlloEquitalia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_AGGIORNAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAggiornamento
		{
			get { return _DataAggiornamento; }
			set {
				if (DataAggiornamento != value)
				{
					_DataAggiornamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatore
		{
			get { return _IdOperatore; }
			set {
				if (IdOperatore != value)
				{
					_IdOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONFERMATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Confermata
		{
			get { return _Confermata; }
			set {
				if (Confermata != value)
				{
					_Confermata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERCENTUALE_IMPORTO
		/// Tipo sul db:DECIMAL(18,4)
		/// </summary>
		public NullTypes.DecimalNT PercentualeImporto
		{
			get { return _PercentualeImporto; }
			set {
				if (PercentualeImporto != value)
				{
					_PercentualeImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTO_PROGETTO
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT CostoProgetto
		{
			get { return _CostoProgetto; }
			set {
				if (CostoProgetto != value)
				{
					_CostoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_INTERVENTO_SOSTITUTIVO
		/// Tipo sul db:VARCHAR(4)
		/// </summary>
		public NullTypes.StringNT DescrizioneInterventoSostitutivo
		{
			get { return _DescrizioneInterventoSostitutivo; }
			set {
				if (DescrizioneInterventoSostitutivo != value)
				{
					_DescrizioneInterventoSostitutivo = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcovidConcessioneProgettiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcovidConcessioneProgettiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcovidConcessioneProgettiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcovidConcessioneProgetti) info.GetValue(i.ToString(),typeof(VcovidConcessioneProgetti)));
			}
		}

		//Costruttore
		public VcovidConcessioneProgettiCollection()
		{
			this.ItemType = typeof(VcovidConcessioneProgetti);
		}

		//Get e Set
		public new VcovidConcessioneProgetti this[int index]
		{
			get { return (VcovidConcessioneProgetti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcovidConcessioneProgettiCollection GetChanges()
		{
			return (VcovidConcessioneProgettiCollection) base.GetChanges();
		}

		//Add
		public int Add(VcovidConcessioneProgetti VcovidConcessioneProgettiObj)
		{
			return base.Add(VcovidConcessioneProgettiObj);
		}

		//AddCollection
		public void AddCollection(VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionObj)
		{
			foreach (VcovidConcessioneProgetti VcovidConcessioneProgettiObj in VcovidConcessioneProgettiCollectionObj)
				this.Add(VcovidConcessioneProgettiObj);
		}

		//Insert
		public void Insert(int index, VcovidConcessioneProgetti VcovidConcessioneProgettiObj)
		{
			base.Insert(index, VcovidConcessioneProgettiObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcovidConcessioneProgettiCollection SubSelect(NullTypes.StringNT CapitoloEqualThis, NullTypes.StringNT AnnoImpEqualThis, NullTypes.StringNT AnnoSubimpEqualThis, 
NullTypes.StringNT DescrizioneImpSubimpEqualThis, NullTypes.StringNT SistemaorigineEqualThis, NullTypes.IntNT IdDomandaEqualThis, 
NullTypes.DecimalNT ImportoEqualThis, NullTypes.StringNT DurcRegolareEqualThis, NullTypes.StringNT CodiceCorEqualThis, 
NullTypes.StringNT AnnoPropostaEqualThis, NullTypes.StringNT UnitaProponenteEqualThis, NullTypes.StringNT NumeroPropostaEqualThis, 
NullTypes.StringNT TransazioneEqualThis, NullTypes.StringNT CodiceRitenutaEqualThis, NullTypes.DecimalNT ImponibileRitenutaEqualThis, 
NullTypes.DecimalNT AliquotaRitenutaEqualThis, NullTypes.DecimalNT ImportoRitenuteEqualThis, NullTypes.StringNT CausaleIrpefEqualThis, 
NullTypes.IntNT ProgressivoEqualThis, NullTypes.StringNT ControlloEquitaliaEqualThis, NullTypes.StringNT NoteEqualThis, 
NullTypes.IntNT IdBandoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis, 
NullTypes.IntNT IdOperatoreEqualThis, NullTypes.BoolNT ConfermataEqualThis, NullTypes.DecimalNT PercentualeImportoEqualThis, 
NullTypes.DecimalNT CostoProgettoEqualThis, NullTypes.StringNT DescrizioneInterventoSostitutivoEqualThis)
		{
			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionTemp = new VcovidConcessioneProgettiCollection();
			foreach (VcovidConcessioneProgetti VcovidConcessioneProgettiItem in this)
			{
				if (((CapitoloEqualThis == null) || ((VcovidConcessioneProgettiItem.Capitolo != null) && (VcovidConcessioneProgettiItem.Capitolo.Value == CapitoloEqualThis.Value))) && ((AnnoImpEqualThis == null) || ((VcovidConcessioneProgettiItem.AnnoImp != null) && (VcovidConcessioneProgettiItem.AnnoImp.Value == AnnoImpEqualThis.Value))) && ((AnnoSubimpEqualThis == null) || ((VcovidConcessioneProgettiItem.AnnoSubimp != null) && (VcovidConcessioneProgettiItem.AnnoSubimp.Value == AnnoSubimpEqualThis.Value))) && 
((DescrizioneImpSubimpEqualThis == null) || ((VcovidConcessioneProgettiItem.DescrizioneImpSubimp != null) && (VcovidConcessioneProgettiItem.DescrizioneImpSubimp.Value == DescrizioneImpSubimpEqualThis.Value))) && ((SistemaorigineEqualThis == null) || ((VcovidConcessioneProgettiItem.Sistemaorigine != null) && (VcovidConcessioneProgettiItem.Sistemaorigine.Value == SistemaorigineEqualThis.Value))) && ((IdDomandaEqualThis == null) || ((VcovidConcessioneProgettiItem.IdDomanda != null) && (VcovidConcessioneProgettiItem.IdDomanda.Value == IdDomandaEqualThis.Value))) && 
((ImportoEqualThis == null) || ((VcovidConcessioneProgettiItem.Importo != null) && (VcovidConcessioneProgettiItem.Importo.Value == ImportoEqualThis.Value))) && ((DurcRegolareEqualThis == null) || ((VcovidConcessioneProgettiItem.DurcRegolare != null) && (VcovidConcessioneProgettiItem.DurcRegolare.Value == DurcRegolareEqualThis.Value))) && ((CodiceCorEqualThis == null) || ((VcovidConcessioneProgettiItem.CodiceCor != null) && (VcovidConcessioneProgettiItem.CodiceCor.Value == CodiceCorEqualThis.Value))) && 
((AnnoPropostaEqualThis == null) || ((VcovidConcessioneProgettiItem.AnnoProposta != null) && (VcovidConcessioneProgettiItem.AnnoProposta.Value == AnnoPropostaEqualThis.Value))) && ((UnitaProponenteEqualThis == null) || ((VcovidConcessioneProgettiItem.UnitaProponente != null) && (VcovidConcessioneProgettiItem.UnitaProponente.Value == UnitaProponenteEqualThis.Value))) && ((NumeroPropostaEqualThis == null) || ((VcovidConcessioneProgettiItem.NumeroProposta != null) && (VcovidConcessioneProgettiItem.NumeroProposta.Value == NumeroPropostaEqualThis.Value))) && 
((TransazioneEqualThis == null) || ((VcovidConcessioneProgettiItem.Transazione != null) && (VcovidConcessioneProgettiItem.Transazione.Value == TransazioneEqualThis.Value))) && ((CodiceRitenutaEqualThis == null) || ((VcovidConcessioneProgettiItem.CodiceRitenuta != null) && (VcovidConcessioneProgettiItem.CodiceRitenuta.Value == CodiceRitenutaEqualThis.Value))) && ((ImponibileRitenutaEqualThis == null) || ((VcovidConcessioneProgettiItem.ImponibileRitenuta != null) && (VcovidConcessioneProgettiItem.ImponibileRitenuta.Value == ImponibileRitenutaEqualThis.Value))) && 
((AliquotaRitenutaEqualThis == null) || ((VcovidConcessioneProgettiItem.AliquotaRitenuta != null) && (VcovidConcessioneProgettiItem.AliquotaRitenuta.Value == AliquotaRitenutaEqualThis.Value))) && ((ImportoRitenuteEqualThis == null) || ((VcovidConcessioneProgettiItem.ImportoRitenute != null) && (VcovidConcessioneProgettiItem.ImportoRitenute.Value == ImportoRitenuteEqualThis.Value))) && ((CausaleIrpefEqualThis == null) || ((VcovidConcessioneProgettiItem.CausaleIrpef != null) && (VcovidConcessioneProgettiItem.CausaleIrpef.Value == CausaleIrpefEqualThis.Value))) && 
((ProgressivoEqualThis == null) || ((VcovidConcessioneProgettiItem.Progressivo != null) && (VcovidConcessioneProgettiItem.Progressivo.Value == ProgressivoEqualThis.Value))) && ((ControlloEquitaliaEqualThis == null) || ((VcovidConcessioneProgettiItem.ControlloEquitalia != null) && (VcovidConcessioneProgettiItem.ControlloEquitalia.Value == ControlloEquitaliaEqualThis.Value))) && ((NoteEqualThis == null) || ((VcovidConcessioneProgettiItem.Note != null) && (VcovidConcessioneProgettiItem.Note.Value == NoteEqualThis.Value))) && 
((IdBandoEqualThis == null) || ((VcovidConcessioneProgettiItem.IdBando != null) && (VcovidConcessioneProgettiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((VcovidConcessioneProgettiItem.DataInserimento != null) && (VcovidConcessioneProgettiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((VcovidConcessioneProgettiItem.DataAggiornamento != null) && (VcovidConcessioneProgettiItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && 
((IdOperatoreEqualThis == null) || ((VcovidConcessioneProgettiItem.IdOperatore != null) && (VcovidConcessioneProgettiItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) && ((ConfermataEqualThis == null) || ((VcovidConcessioneProgettiItem.Confermata != null) && (VcovidConcessioneProgettiItem.Confermata.Value == ConfermataEqualThis.Value))) && ((PercentualeImportoEqualThis == null) || ((VcovidConcessioneProgettiItem.PercentualeImporto != null) && (VcovidConcessioneProgettiItem.PercentualeImporto.Value == PercentualeImportoEqualThis.Value))) && 
((CostoProgettoEqualThis == null) || ((VcovidConcessioneProgettiItem.CostoProgetto != null) && (VcovidConcessioneProgettiItem.CostoProgetto.Value == CostoProgettoEqualThis.Value))) && ((DescrizioneInterventoSostitutivoEqualThis == null) || ((VcovidConcessioneProgettiItem.DescrizioneInterventoSostitutivo != null) && (VcovidConcessioneProgettiItem.DescrizioneInterventoSostitutivo.Value == DescrizioneInterventoSostitutivoEqualThis.Value))))
				{
					VcovidConcessioneProgettiCollectionTemp.Add(VcovidConcessioneProgettiItem);
				}
			}
			return VcovidConcessioneProgettiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcovidConcessioneProgettiCollection Filter(NullTypes.IntNT IdBandoEqualThis)
		{
			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionTemp = new VcovidConcessioneProgettiCollection();
			foreach (VcovidConcessioneProgetti VcovidConcessioneProgettiItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VcovidConcessioneProgettiItem.IdBando != null) && (VcovidConcessioneProgettiItem.IdBando.Value == IdBandoEqualThis.Value))))
				{
					VcovidConcessioneProgettiCollectionTemp.Add(VcovidConcessioneProgettiItem);
				}
			}
			return VcovidConcessioneProgettiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcovidConcessioneProgettiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcovidConcessioneProgettiDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcovidConcessioneProgetti GetFromDatareader(DbProvider db)
		{
			VcovidConcessioneProgetti VcovidConcessioneProgettiObj = new VcovidConcessioneProgetti();
			VcovidConcessioneProgettiObj.Capitolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAPITOLO"]);
			VcovidConcessioneProgettiObj.AnnoImp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_IMP"]);
			VcovidConcessioneProgettiObj.AnnoSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_SUBIMP"]);
			VcovidConcessioneProgettiObj.DescrizioneImpSubimp = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_IMP_SUBIMP"]);
			VcovidConcessioneProgettiObj.Sistemaorigine = new SiarLibrary.NullTypes.StringNT(db.DataReader["SistemaOrigine"]);
			VcovidConcessioneProgettiObj.IdDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA"]);
			VcovidConcessioneProgettiObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
			VcovidConcessioneProgettiObj.DurcRegolare = new SiarLibrary.NullTypes.StringNT(db.DataReader["DURC_REGOLARE"]);
			VcovidConcessioneProgettiObj.CodiceCor = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_COR"]);
			VcovidConcessioneProgettiObj.AnnoProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ANNO_PROPOSTA"]);
			VcovidConcessioneProgettiObj.UnitaProponente = new SiarLibrary.NullTypes.StringNT(db.DataReader["UNITA_PROPONENTE"]);
			VcovidConcessioneProgettiObj.NumeroProposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROPOSTA"]);
			VcovidConcessioneProgettiObj.Transazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TRANSAZIONE"]);
			VcovidConcessioneProgettiObj.CodiceRitenuta = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_RITENUTA"]);
			VcovidConcessioneProgettiObj.ImponibileRitenuta = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_RITENUTA"]);
			VcovidConcessioneProgettiObj.AliquotaRitenuta = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALIQUOTA_RITENUTA"]);
			VcovidConcessioneProgettiObj.ImportoRitenute = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RITENUTE"]);
			VcovidConcessioneProgettiObj.CausaleIrpef = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAUSALE_IRPEF"]);
			VcovidConcessioneProgettiObj.Progressivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGRESSIVO"]);
			VcovidConcessioneProgettiObj.ControlloEquitalia = new SiarLibrary.NullTypes.StringNT(db.DataReader["CONTROLLO_EQUITALIA"]);
			VcovidConcessioneProgettiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			VcovidConcessioneProgettiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcovidConcessioneProgettiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			VcovidConcessioneProgettiObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			VcovidConcessioneProgettiObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			VcovidConcessioneProgettiObj.Confermata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFERMATA"]);
			VcovidConcessioneProgettiObj.PercentualeImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PERCENTUALE_IMPORTO"]);
			VcovidConcessioneProgettiObj.CostoProgetto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_PROGETTO"]);
			VcovidConcessioneProgettiObj.DescrizioneInterventoSostitutivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INTERVENTO_SOSTITUTIVO"]);
			VcovidConcessioneProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcovidConcessioneProgettiObj.IsDirty = false;
			VcovidConcessioneProgettiObj.IsPersistent = true;
			return VcovidConcessioneProgettiObj;
		}

		//Find Select

		public static VcovidConcessioneProgettiCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CapitoloEqualThis, SiarLibrary.NullTypes.StringNT AnnoImpEqualThis, SiarLibrary.NullTypes.StringNT AnnoSubimpEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneImpSubimpEqualThis, SiarLibrary.NullTypes.StringNT SistemaorigineEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.StringNT DurcRegolareEqualThis, SiarLibrary.NullTypes.StringNT CodiceCorEqualThis, 
SiarLibrary.NullTypes.StringNT AnnoPropostaEqualThis, SiarLibrary.NullTypes.StringNT UnitaProponenteEqualThis, SiarLibrary.NullTypes.StringNT NumeroPropostaEqualThis, 
SiarLibrary.NullTypes.StringNT TransazioneEqualThis, SiarLibrary.NullTypes.StringNT CodiceRitenutaEqualThis, SiarLibrary.NullTypes.DecimalNT ImponibileRitenutaEqualThis, 
SiarLibrary.NullTypes.DecimalNT AliquotaRitenutaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRitenuteEqualThis, SiarLibrary.NullTypes.StringNT CausaleIrpefEqualThis, 
SiarLibrary.NullTypes.IntNT ProgressivoEqualThis, SiarLibrary.NullTypes.StringNT ControlloEquitaliaEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, 
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT ConfermataEqualThis, SiarLibrary.NullTypes.DecimalNT PercentualeImportoEqualThis, 
SiarLibrary.NullTypes.DecimalNT CostoProgettoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneInterventoSostitutivoEqualThis)

		{

			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionObj = new VcovidConcessioneProgettiCollection();

			IDbCommand findCmd = db.InitCmd("Zvcovidconcessioneprogettifindselect", new string[] {"Capitoloequalthis", "AnnoImpequalthis", "AnnoSubimpequalthis", 
"DescrizioneImpSubimpequalthis", "Sistemaorigineequalthis", "IdDomandaequalthis", 
"Importoequalthis", "DurcRegolareequalthis", "CodiceCorequalthis", 
"AnnoPropostaequalthis", "UnitaProponenteequalthis", "NumeroPropostaequalthis", 
"Transazioneequalthis", "CodiceRitenutaequalthis", "ImponibileRitenutaequalthis", 
"AliquotaRitenutaequalthis", "ImportoRitenuteequalthis", "CausaleIrpefequalthis", 
"Progressivoequalthis", "ControlloEquitaliaequalthis", "Noteequalthis", 
"IdBandoequalthis", "DataInserimentoequalthis", "DataAggiornamentoequalthis", 
"IdOperatoreequalthis", "Confermataequalthis", "PercentualeImportoequalthis", 
"CostoProgettoequalthis", "DescrizioneInterventoSostitutivoequalthis"}, new string[] {"string", "string", "string", 
"string", "string", "int", 
"decimal", "string", "string", 
"string", "string", "string", 
"string", "string", "decimal", 
"decimal", "decimal", "string", 
"int", "string", "string", 
"int", "DateTime", "DateTime", 
"int", "bool", "decimal", 
"decimal", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capitoloequalthis", CapitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoImpequalthis", AnnoImpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoSubimpequalthis", AnnoSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneImpSubimpequalthis", DescrizioneImpSubimpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sistemaorigineequalthis", SistemaorigineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaequalthis", IdDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DurcRegolareequalthis", DurcRegolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceCorequalthis", CodiceCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AnnoPropostaequalthis", AnnoPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "UnitaProponenteequalthis", UnitaProponenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroPropostaequalthis", NumeroPropostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Transazioneequalthis", TransazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRitenutaequalthis", CodiceRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImponibileRitenutaequalthis", ImponibileRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AliquotaRitenutaequalthis", AliquotaRitenutaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRitenuteequalthis", ImportoRitenuteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CausaleIrpefequalthis", CausaleIrpefEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ControlloEquitaliaequalthis", ControlloEquitaliaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Confermataequalthis", ConfermataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PercentualeImportoequalthis", PercentualeImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostoProgettoequalthis", CostoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneInterventoSostitutivoequalthis", DescrizioneInterventoSostitutivoEqualThis);
			VcovidConcessioneProgetti VcovidConcessioneProgettiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcovidConcessioneProgettiObj = GetFromDatareader(db);
				VcovidConcessioneProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcovidConcessioneProgettiObj.IsDirty = false;
				VcovidConcessioneProgettiObj.IsPersistent = true;
				VcovidConcessioneProgettiCollectionObj.Add(VcovidConcessioneProgettiObj);
			}
			db.Close();
			return VcovidConcessioneProgettiCollectionObj;
		}

		//Find Find

		public static VcovidConcessioneProgettiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionObj = new VcovidConcessioneProgettiCollection();

			IDbCommand findCmd = db.InitCmd("Zvcovidconcessioneprogettifindfind", new string[] {"IdBandoequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			VcovidConcessioneProgetti VcovidConcessioneProgettiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcovidConcessioneProgettiObj = GetFromDatareader(db);
				VcovidConcessioneProgettiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcovidConcessioneProgettiObj.IsDirty = false;
				VcovidConcessioneProgettiObj.IsPersistent = true;
				VcovidConcessioneProgettiCollectionObj.Add(VcovidConcessioneProgettiObj);
			}
			db.Close();
			return VcovidConcessioneProgettiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcovidConcessioneProgettiCollectionProvider:IVcovidConcessioneProgettiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcovidConcessioneProgettiCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcovidConcessioneProgetti
		protected VcovidConcessioneProgettiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcovidConcessioneProgettiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcovidConcessioneProgettiCollection();
		}

		//Costruttore 2: popola la collection
		public VcovidConcessioneProgettiCollectionProvider(IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis);
		}

		//Costruttore3: ha in input vcovidconcessioneprogettiCollectionObj - non popola la collection
		public VcovidConcessioneProgettiCollectionProvider(VcovidConcessioneProgettiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcovidConcessioneProgettiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcovidConcessioneProgettiCollection();
		}

		//Get e Set
		public VcovidConcessioneProgettiCollection CollectionObj
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

		//Select: popola la collection
		public VcovidConcessioneProgettiCollection Select(StringNT CapitoloEqualThis, StringNT AnnoimpEqualThis, StringNT AnnosubimpEqualThis, 
StringNT DescrizioneimpsubimpEqualThis, StringNT SistemaorigineEqualThis, IntNT IddomandaEqualThis, 
DecimalNT ImportoEqualThis, StringNT DurcregolareEqualThis, StringNT CodicecorEqualThis, 
StringNT AnnopropostaEqualThis, StringNT UnitaproponenteEqualThis, StringNT NumeropropostaEqualThis, 
StringNT TransazioneEqualThis, StringNT CodiceritenutaEqualThis, DecimalNT ImponibileritenutaEqualThis, 
DecimalNT AliquotaritenutaEqualThis, DecimalNT ImportoritenuteEqualThis, StringNT CausaleirpefEqualThis, 
IntNT ProgressivoEqualThis, StringNT ControlloequitaliaEqualThis, StringNT NoteEqualThis, 
IntNT IdbandoEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis, 
IntNT IdoperatoreEqualThis, BoolNT ConfermataEqualThis, DecimalNT PercentualeimportoEqualThis, 
DecimalNT CostoprogettoEqualThis, StringNT DescrizioneinterventosostitutivoEqualThis)
		{
			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionTemp = VcovidConcessioneProgettiDAL.Select(_dbProviderObj, CapitoloEqualThis, AnnoimpEqualThis, AnnosubimpEqualThis, 
DescrizioneimpsubimpEqualThis, SistemaorigineEqualThis, IddomandaEqualThis, 
ImportoEqualThis, DurcregolareEqualThis, CodicecorEqualThis, 
AnnopropostaEqualThis, UnitaproponenteEqualThis, NumeropropostaEqualThis, 
TransazioneEqualThis, CodiceritenutaEqualThis, ImponibileritenutaEqualThis, 
AliquotaritenutaEqualThis, ImportoritenuteEqualThis, CausaleirpefEqualThis, 
ProgressivoEqualThis, ControlloequitaliaEqualThis, NoteEqualThis, 
IdbandoEqualThis, DatainserimentoEqualThis, DataaggiornamentoEqualThis, 
IdoperatoreEqualThis, ConfermataEqualThis, PercentualeimportoEqualThis, 
CostoprogettoEqualThis, DescrizioneinterventosostitutivoEqualThis);
			return VcovidConcessioneProgettiCollectionTemp;
		}

		//Find: popola la collection
		public VcovidConcessioneProgettiCollection Find(IntNT IdbandoEqualThis)
		{
			VcovidConcessioneProgettiCollection VcovidConcessioneProgettiCollectionTemp = VcovidConcessioneProgettiDAL.Find(_dbProviderObj, IdbandoEqualThis);
			return VcovidConcessioneProgettiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vCOVID_CONCESSIONE_PROGETTI>
  <ViewName>vCOVID_CONCESSIONE_PROGETTI</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vCOVID_CONCESSIONE_PROGETTI>
*/
