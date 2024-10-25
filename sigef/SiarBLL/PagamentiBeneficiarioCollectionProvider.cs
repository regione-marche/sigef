using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PagamentiBeneficiario
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPagamentiBeneficiarioProvider
	{
		int Save(PagamentiBeneficiario PagamentiBeneficiarioObj);
		int SaveCollection(PagamentiBeneficiarioCollection collectionObj);
		int Delete(PagamentiBeneficiario PagamentiBeneficiarioObj);
		int DeleteCollection(PagamentiBeneficiarioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PagamentiBeneficiario
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PagamentiBeneficiario: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPagamentoBeneficiario;
		private NullTypes.IntNT _IdPagamentoRichiesto;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.DecimalNT _ImportoRichiesto;
		private NullTypes.DecimalNT _ImportoAmmesso;
		private NullTypes.DecimalNT _ContributoAmmesso;
		private NullTypes.DecimalNT _QuotaContributoAmmesso;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _Numero;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _NumeroDoctrasporto;
		private NullTypes.DatetimeNT _DataDoctrasporto;
		private NullTypes.DecimalNT _Imponibile;
		private NullTypes.DecimalNT _Iva;
		private NullTypes.DecimalNT _AltriOneri;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CfFornitore;
		private NullTypes.StringNT _DescrizioneFornitore;
		private NullTypes.StringNT _TipoGiustificativo;
		private NullTypes.BoolNT _SpesaTecnicaRichiesta;
		private NullTypes.BoolNT _SpesaTecnicaAmmessa;
		private NullTypes.BoolNT _IvaNonRecuperabile;
		private NullTypes.DecimalNT _ImportoNonammNonresp;
		private NullTypes.DecimalNT _ImportoAmmessoContr;
		private NullTypes.DecimalNT _ImportoNonammContrNonresp;
		private NullTypes.BoolNT _SpesaTecnicaAmmessaContr;
		private NullTypes.BoolNT _CostituisceVariante;
		private NullTypes.BoolNT _LavoriInEconomia;
		private NullTypes.StringNT _CodRiduzione;
		private NullTypes.IntNT _MotivazioneRiduzione;
		private NullTypes.StringNT _CodRiduzioneContr;
		private NullTypes.IntNT _MotivazioneRiduzioneContr;
		private NullTypes.IntNT _IdFile;
		[NonSerialized] private IPagamentiBeneficiarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiBeneficiarioProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PagamentiBeneficiario()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PAGAMENTO_BENEFICIARIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPagamentoBeneficiario
		{
			get { return _IdPagamentoBeneficiario; }
			set {
				if (IdPagamentoBeneficiario != value)
				{
					_IdPagamentoBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PAGAMENTO_RICHIESTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPagamentoRichiesto
		{
			get { return _IdPagamentoRichiesto; }
			set {
				if (IdPagamentoRichiesto != value)
				{
					_IdPagamentoRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_GIUSTIFICATIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdGiustificativo
		{
			get { return _IdGiustificativo; }
			set {
				if (IdGiustificativo != value)
				{
					_IdGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RICHIESTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoRichiesto
		{
			get { return _ImportoRichiesto; }
			set {
				if (ImportoRichiesto != value)
				{
					_ImportoRichiesto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmesso
		{
			get { return _ImportoAmmesso; }
			set {
				if (ImportoAmmesso != value)
				{
					_ImportoAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMESSO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmesso
		{
			get { return _ContributoAmmesso; }
			set {
				if (ContributoAmmesso != value)
				{
					_ContributoAmmesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_CONTRIBUTO_AMMESSO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT QuotaContributoAmmesso
		{
			get { return _QuotaContributoAmmesso; }
			set {
				if (QuotaContributoAmmesso != value)
				{
					_QuotaContributoAmmesso = value;
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
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
		/// Corrisponde al campo:NUMERO_DOCTRASPORTO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroDoctrasporto
		{
			get { return _NumeroDoctrasporto; }
			set {
				if (NumeroDoctrasporto != value)
				{
					_NumeroDoctrasporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DOCTRASPORTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDoctrasporto
		{
			get { return _DataDoctrasporto; }
			set {
				if (DataDoctrasporto != value)
				{
					_DataDoctrasporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPONIBILE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Imponibile
		{
			get { return _Imponibile; }
			set {
				if (Imponibile != value)
				{
					_Imponibile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IVA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Iva
		{
			get { return _Iva; }
			set {
				if (Iva != value)
				{
					_Iva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALTRI_ONERI
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT AltriOneri
		{
			get { return _AltriOneri; }
			set {
				if (AltriOneri != value)
				{
					_AltriOneri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:CF_FORNITORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfFornitore
		{
			get { return _CfFornitore; }
			set {
				if (CfFornitore != value)
				{
					_CfFornitore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FORNITORE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneFornitore
		{
			get { return _DescrizioneFornitore; }
			set {
				if (DescrizioneFornitore != value)
				{
					_DescrizioneFornitore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoGiustificativo
		{
			get { return _TipoGiustificativo; }
			set {
				if (TipoGiustificativo != value)
				{
					_TipoGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESA_TECNICA_RICHIESTA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT SpesaTecnicaRichiesta
		{
			get { return _SpesaTecnicaRichiesta; }
			set {
				if (SpesaTecnicaRichiesta != value)
				{
					_SpesaTecnicaRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESA_TECNICA_AMMESSA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT SpesaTecnicaAmmessa
		{
			get { return _SpesaTecnicaAmmessa; }
			set {
				if (SpesaTecnicaAmmessa != value)
				{
					_SpesaTecnicaAmmessa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IVA_NON_RECUPERABILE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IvaNonRecuperabile
		{
			get { return _IvaNonRecuperabile; }
			set {
				if (IvaNonRecuperabile != value)
				{
					_IvaNonRecuperabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_NONAMM_NONRESP
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoNonammNonresp
		{
			get { return _ImportoNonammNonresp; }
			set {
				if (ImportoNonammNonresp != value)
				{
					_ImportoNonammNonresp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_AMMESSO_CONTR
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoAmmessoContr
		{
			get { return _ImportoAmmessoContr; }
			set {
				if (ImportoAmmessoContr != value)
				{
					_ImportoAmmessoContr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_NONAMM_CONTR_NONRESP
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoNonammContrNonresp
		{
			get { return _ImportoNonammContrNonresp; }
			set {
				if (ImportoNonammContrNonresp != value)
				{
					_ImportoNonammContrNonresp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SPESA_TECNICA_AMMESSA_CONTR
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT SpesaTecnicaAmmessaContr
		{
			get { return _SpesaTecnicaAmmessaContr; }
			set {
				if (SpesaTecnicaAmmessaContr != value)
				{
					_SpesaTecnicaAmmessaContr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COSTITUISCE_VARIANTE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT CostituisceVariante
		{
			get { return _CostituisceVariante; }
			set {
				if (CostituisceVariante != value)
				{
					_CostituisceVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LAVORI_IN_ECONOMIA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT LavoriInEconomia
		{
			get { return _LavoriInEconomia; }
			set {
				if (LavoriInEconomia != value)
				{
					_LavoriInEconomia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RIDUZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodRiduzione
		{
			get { return _CodRiduzione; }
			set {
				if (CodRiduzione != value)
				{
					_CodRiduzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE_RIDUZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT MotivazioneRiduzione
		{
			get { return _MotivazioneRiduzione; }
			set {
				if (MotivazioneRiduzione != value)
				{
					_MotivazioneRiduzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_RIDUZIONE_CONTR
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodRiduzioneContr
		{
			get { return _CodRiduzioneContr; }
			set {
				if (CodRiduzioneContr != value)
				{
					_CodRiduzioneContr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE_RIDUZIONE_CONTR
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT MotivazioneRiduzioneContr
		{
			get { return _MotivazioneRiduzioneContr; }
			set {
				if (MotivazioneRiduzioneContr != value)
				{
					_MotivazioneRiduzioneContr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE
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
	/// Summary description for PagamentiBeneficiarioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiBeneficiarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PagamentiBeneficiarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PagamentiBeneficiario) info.GetValue(i.ToString(),typeof(PagamentiBeneficiario)));
			}
		}

		//Costruttore
		public PagamentiBeneficiarioCollection()
		{
			this.ItemType = typeof(PagamentiBeneficiario);
		}

		//Costruttore con provider
		public PagamentiBeneficiarioCollection(IPagamentiBeneficiarioProvider providerObj)
		{
			this.ItemType = typeof(PagamentiBeneficiario);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PagamentiBeneficiario this[int index]
		{
			get { return (PagamentiBeneficiario)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PagamentiBeneficiarioCollection GetChanges()
		{
			return (PagamentiBeneficiarioCollection) base.GetChanges();
		}

		[NonSerialized] private IPagamentiBeneficiarioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPagamentiBeneficiarioProvider Provider
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
		public int Add(PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			if (PagamentiBeneficiarioObj.Provider == null) PagamentiBeneficiarioObj.Provider = this.Provider;
			return base.Add(PagamentiBeneficiarioObj);
		}

		//AddCollection
		public void AddCollection(PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionObj)
		{
			foreach (PagamentiBeneficiario PagamentiBeneficiarioObj in PagamentiBeneficiarioCollectionObj)
				this.Add(PagamentiBeneficiarioObj);
		}

		//Insert
		public void Insert(int index, PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			if (PagamentiBeneficiarioObj.Provider == null) PagamentiBeneficiarioObj.Provider = this.Provider;
			base.Insert(index, PagamentiBeneficiarioObj);
		}

		//CollectionGetById
		public PagamentiBeneficiario CollectionGetById(NullTypes.IntNT IdPagamentoBeneficiarioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPagamentoBeneficiario == IdPagamentoBeneficiarioValue))
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
		public PagamentiBeneficiarioCollection SubSelect(NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, NullTypes.IntNT IdPagamentoRichiestoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, 
NullTypes.DecimalNT ImportoRichiestoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, 
NullTypes.DecimalNT QuotaContributoAmmessoEqualThis, NullTypes.StringNT CodRiduzioneEqualThis, NullTypes.IntNT MotivazioneRiduzioneEqualThis, 
NullTypes.DecimalNT ImportoNonammNonrespEqualThis, NullTypes.DecimalNT ImportoAmmessoContrEqualThis, NullTypes.DecimalNT ImportoNonammContrNonrespEqualThis, 
NullTypes.BoolNT SpesaTecnicaRichiestaEqualThis, NullTypes.BoolNT SpesaTecnicaAmmessaEqualThis, NullTypes.BoolNT SpesaTecnicaAmmessaContrEqualThis, 
NullTypes.BoolNT CostituisceVarianteEqualThis, NullTypes.StringNT CodRiduzioneContrEqualThis, NullTypes.IntNT MotivazioneRiduzioneContrEqualThis)
		{
			PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionTemp = new PagamentiBeneficiarioCollection();
			foreach (PagamentiBeneficiario PagamentiBeneficiarioItem in this)
			{
				if (((IdPagamentoBeneficiarioEqualThis == null) || ((PagamentiBeneficiarioItem.IdPagamentoBeneficiario != null) && (PagamentiBeneficiarioItem.IdPagamentoBeneficiario.Value == IdPagamentoBeneficiarioEqualThis.Value))) && ((IdPagamentoRichiestoEqualThis == null) || ((PagamentiBeneficiarioItem.IdPagamentoRichiesto != null) && (PagamentiBeneficiarioItem.IdPagamentoRichiesto.Value == IdPagamentoRichiestoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((PagamentiBeneficiarioItem.IdGiustificativo != null) && (PagamentiBeneficiarioItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && 
((ImportoRichiestoEqualThis == null) || ((PagamentiBeneficiarioItem.ImportoRichiesto != null) && (PagamentiBeneficiarioItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((PagamentiBeneficiarioItem.ImportoAmmesso != null) && (PagamentiBeneficiarioItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((PagamentiBeneficiarioItem.ContributoAmmesso != null) && (PagamentiBeneficiarioItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && 
((QuotaContributoAmmessoEqualThis == null) || ((PagamentiBeneficiarioItem.QuotaContributoAmmesso != null) && (PagamentiBeneficiarioItem.QuotaContributoAmmesso.Value == QuotaContributoAmmessoEqualThis.Value))) && ((CodRiduzioneEqualThis == null) || ((PagamentiBeneficiarioItem.CodRiduzione != null) && (PagamentiBeneficiarioItem.CodRiduzione.Value == CodRiduzioneEqualThis.Value))) && ((MotivazioneRiduzioneEqualThis == null) || ((PagamentiBeneficiarioItem.MotivazioneRiduzione != null) && (PagamentiBeneficiarioItem.MotivazioneRiduzione.Value == MotivazioneRiduzioneEqualThis.Value))) && 
((ImportoNonammNonrespEqualThis == null) || ((PagamentiBeneficiarioItem.ImportoNonammNonresp != null) && (PagamentiBeneficiarioItem.ImportoNonammNonresp.Value == ImportoNonammNonrespEqualThis.Value))) && ((ImportoAmmessoContrEqualThis == null) || ((PagamentiBeneficiarioItem.ImportoAmmessoContr != null) && (PagamentiBeneficiarioItem.ImportoAmmessoContr.Value == ImportoAmmessoContrEqualThis.Value))) && ((ImportoNonammContrNonrespEqualThis == null) || ((PagamentiBeneficiarioItem.ImportoNonammContrNonresp != null) && (PagamentiBeneficiarioItem.ImportoNonammContrNonresp.Value == ImportoNonammContrNonrespEqualThis.Value))) && 
((SpesaTecnicaRichiestaEqualThis == null) || ((PagamentiBeneficiarioItem.SpesaTecnicaRichiesta != null) && (PagamentiBeneficiarioItem.SpesaTecnicaRichiesta.Value == SpesaTecnicaRichiestaEqualThis.Value))) && ((SpesaTecnicaAmmessaEqualThis == null) || ((PagamentiBeneficiarioItem.SpesaTecnicaAmmessa != null) && (PagamentiBeneficiarioItem.SpesaTecnicaAmmessa.Value == SpesaTecnicaAmmessaEqualThis.Value))) && ((SpesaTecnicaAmmessaContrEqualThis == null) || ((PagamentiBeneficiarioItem.SpesaTecnicaAmmessaContr != null) && (PagamentiBeneficiarioItem.SpesaTecnicaAmmessaContr.Value == SpesaTecnicaAmmessaContrEqualThis.Value))) && 
((CostituisceVarianteEqualThis == null) || ((PagamentiBeneficiarioItem.CostituisceVariante != null) && (PagamentiBeneficiarioItem.CostituisceVariante.Value == CostituisceVarianteEqualThis.Value))) && ((CodRiduzioneContrEqualThis == null) || ((PagamentiBeneficiarioItem.CodRiduzioneContr != null) && (PagamentiBeneficiarioItem.CodRiduzioneContr.Value == CodRiduzioneContrEqualThis.Value))) && ((MotivazioneRiduzioneContrEqualThis == null) || ((PagamentiBeneficiarioItem.MotivazioneRiduzioneContr != null) && (PagamentiBeneficiarioItem.MotivazioneRiduzioneContr.Value == MotivazioneRiduzioneContrEqualThis.Value))))
				{
					PagamentiBeneficiarioCollectionTemp.Add(PagamentiBeneficiarioItem);
				}
			}
			return PagamentiBeneficiarioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PagamentiBeneficiarioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PagamentiBeneficiarioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PagamentiBeneficiario PagamentiBeneficiarioObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoBeneficiario", PagamentiBeneficiarioObj.IdPagamentoBeneficiario);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPagamentoRichiesto", PagamentiBeneficiarioObj.IdPagamentoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdGiustificativo", PagamentiBeneficiarioObj.IdGiustificativo);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoRichiesto", PagamentiBeneficiarioObj.ImportoRichiesto);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoAmmesso", PagamentiBeneficiarioObj.ImportoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "ContributoAmmesso", PagamentiBeneficiarioObj.ContributoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaContributoAmmesso", PagamentiBeneficiarioObj.QuotaContributoAmmesso);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaTecnicaRichiesta", PagamentiBeneficiarioObj.SpesaTecnicaRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaTecnicaAmmessa", PagamentiBeneficiarioObj.SpesaTecnicaAmmessa);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoNonammNonresp", PagamentiBeneficiarioObj.ImportoNonammNonresp);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoAmmessoContr", PagamentiBeneficiarioObj.ImportoAmmessoContr);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoNonammContrNonresp", PagamentiBeneficiarioObj.ImportoNonammContrNonresp);
			DbProvider.SetCmdParam(cmd,firstChar + "SpesaTecnicaAmmessaContr", PagamentiBeneficiarioObj.SpesaTecnicaAmmessaContr);
			DbProvider.SetCmdParam(cmd,firstChar + "CostituisceVariante", PagamentiBeneficiarioObj.CostituisceVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRiduzione", PagamentiBeneficiarioObj.CodRiduzione);
			DbProvider.SetCmdParam(cmd,firstChar + "MotivazioneRiduzione", PagamentiBeneficiarioObj.MotivazioneRiduzione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRiduzioneContr", PagamentiBeneficiarioObj.CodRiduzioneContr);
			DbProvider.SetCmdParam(cmd,firstChar + "MotivazioneRiduzioneContr", PagamentiBeneficiarioObj.MotivazioneRiduzioneContr);
		}
		//Insert
		private static int Insert(DbProvider db, PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiBeneficiarioInsert", new string[] {"IdPagamentoRichiesto", "IdGiustificativo", 
"ImportoRichiesto", "ImportoAmmesso", "ContributoAmmesso", 
"QuotaContributoAmmesso", 



"SpesaTecnicaRichiesta", 
"SpesaTecnicaAmmessa", "ImportoNonammNonresp", 
"ImportoAmmessoContr", "ImportoNonammContrNonresp", "SpesaTecnicaAmmessaContr", 
"CostituisceVariante", "CodRiduzione", 
"MotivazioneRiduzione", "CodRiduzioneContr", "MotivazioneRiduzioneContr", }, new string[] {"int", "int", 
"decimal", "decimal", "decimal", 
"decimal", 



"bool", 
"bool", "decimal", 
"decimal", "decimal", "bool", 
"bool", "string", 
"int", "string", "int", },"");
				CompileIUCmd(false, insertCmd,PagamentiBeneficiarioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PagamentiBeneficiarioObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
				PagamentiBeneficiarioObj.SpesaTecnicaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_RICHIESTA"]);
				PagamentiBeneficiarioObj.SpesaTecnicaAmmessa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA"]);
				PagamentiBeneficiarioObj.SpesaTecnicaAmmessaContr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA_CONTR"]);
				PagamentiBeneficiarioObj.CostituisceVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["COSTITUISCE_VARIANTE"]);
				}
				PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiBeneficiarioObj.IsDirty = false;
				PagamentiBeneficiarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiBeneficiarioUpdate", new string[] {"IdPagamentoBeneficiario", "IdPagamentoRichiesto", "IdGiustificativo", 
"ImportoRichiesto", "ImportoAmmesso", "ContributoAmmesso", 
"QuotaContributoAmmesso", 



"SpesaTecnicaRichiesta", 
"SpesaTecnicaAmmessa", "ImportoNonammNonresp", 
"ImportoAmmessoContr", "ImportoNonammContrNonresp", "SpesaTecnicaAmmessaContr", 
"CostituisceVariante", "CodRiduzione", 
"MotivazioneRiduzione", "CodRiduzioneContr", "MotivazioneRiduzioneContr", }, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", 



"bool", 
"bool", "decimal", 
"decimal", "decimal", "bool", 
"bool", "string", 
"int", "string", "int", },"");
				CompileIUCmd(true, updateCmd,PagamentiBeneficiarioObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiBeneficiarioObj.IsDirty = false;
				PagamentiBeneficiarioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			switch (PagamentiBeneficiarioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PagamentiBeneficiarioObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PagamentiBeneficiarioObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PagamentiBeneficiarioObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPagamentiBeneficiarioUpdate", new string[] {"IdPagamentoBeneficiario", "IdPagamentoRichiesto", "IdGiustificativo", 
"ImportoRichiesto", "ImportoAmmesso", "ContributoAmmesso", 
"QuotaContributoAmmesso", 



"SpesaTecnicaRichiesta", 
"SpesaTecnicaAmmessa", "ImportoNonammNonresp", 
"ImportoAmmessoContr", "ImportoNonammContrNonresp", "SpesaTecnicaAmmessaContr", 
"CostituisceVariante", "CodRiduzione", 
"MotivazioneRiduzione", "CodRiduzioneContr", "MotivazioneRiduzioneContr", }, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", 



"bool", 
"bool", "decimal", 
"decimal", "decimal", "bool", 
"bool", "string", 
"int", "string", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZPagamentiBeneficiarioInsert", new string[] {"IdPagamentoRichiesto", "IdGiustificativo", 
"ImportoRichiesto", "ImportoAmmesso", "ContributoAmmesso", 
"QuotaContributoAmmesso", 



"SpesaTecnicaRichiesta", 
"SpesaTecnicaAmmessa", "ImportoNonammNonresp", 
"ImportoAmmessoContr", "ImportoNonammContrNonresp", "SpesaTecnicaAmmessaContr", 
"CostituisceVariante", "CodRiduzione", 
"MotivazioneRiduzione", "CodRiduzioneContr", "MotivazioneRiduzioneContr", }, new string[] {"int", "int", 
"decimal", "decimal", "decimal", 
"decimal", 



"bool", 
"bool", "decimal", 
"decimal", "decimal", "bool", 
"bool", "string", 
"int", "string", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiBeneficiarioDelete", new string[] {"IdPagamentoBeneficiario"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiBeneficiarioCollectionObj.Count; i++)
				{
					switch (PagamentiBeneficiarioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PagamentiBeneficiarioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PagamentiBeneficiarioCollectionObj[i].IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
									PagamentiBeneficiarioCollectionObj[i].SpesaTecnicaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_RICHIESTA"]);
									PagamentiBeneficiarioCollectionObj[i].SpesaTecnicaAmmessa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA"]);
									PagamentiBeneficiarioCollectionObj[i].SpesaTecnicaAmmessaContr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA_CONTR"]);
									PagamentiBeneficiarioCollectionObj[i].CostituisceVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["COSTITUISCE_VARIANTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PagamentiBeneficiarioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PagamentiBeneficiarioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoBeneficiario", (SiarLibrary.NullTypes.IntNT)PagamentiBeneficiarioCollectionObj[i].IdPagamentoBeneficiario);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PagamentiBeneficiarioCollectionObj.Count; i++)
				{
					if ((PagamentiBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PagamentiBeneficiarioCollectionObj[i].IsDirty = false;
						PagamentiBeneficiarioCollectionObj[i].IsPersistent = true;
					}
					if ((PagamentiBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PagamentiBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiBeneficiarioCollectionObj[i].IsDirty = false;
						PagamentiBeneficiarioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PagamentiBeneficiario PagamentiBeneficiarioObj)
		{
			int returnValue = 0;
			if (PagamentiBeneficiarioObj.IsPersistent) 
			{
				returnValue = Delete(db, PagamentiBeneficiarioObj.IdPagamentoBeneficiario);
			}
			PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PagamentiBeneficiarioObj.IsDirty = false;
			PagamentiBeneficiarioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPagamentoBeneficiarioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiBeneficiarioDelete", new string[] {"IdPagamentoBeneficiario"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoBeneficiario", (SiarLibrary.NullTypes.IntNT)IdPagamentoBeneficiarioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPagamentiBeneficiarioDelete", new string[] {"IdPagamentoBeneficiario"}, new string[] {"int"},"");
				for (int i = 0; i < PagamentiBeneficiarioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPagamentoBeneficiario", PagamentiBeneficiarioCollectionObj[i].IdPagamentoBeneficiario);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PagamentiBeneficiarioCollectionObj.Count; i++)
				{
					if ((PagamentiBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PagamentiBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PagamentiBeneficiarioCollectionObj[i].IsDirty = false;
						PagamentiBeneficiarioCollectionObj[i].IsPersistent = false;
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
		public static PagamentiBeneficiario GetById(DbProvider db, int IdPagamentoBeneficiarioValue)
		{
			PagamentiBeneficiario PagamentiBeneficiarioObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPagamentiBeneficiarioGetById", new string[] {"IdPagamentoBeneficiario"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPagamentoBeneficiario", (SiarLibrary.NullTypes.IntNT)IdPagamentoBeneficiarioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PagamentiBeneficiarioObj = GetFromDatareader(db);
				PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiBeneficiarioObj.IsDirty = false;
				PagamentiBeneficiarioObj.IsPersistent = true;
			}
			db.Close();
			return PagamentiBeneficiarioObj;
		}

		//getFromDatareader
		public static PagamentiBeneficiario GetFromDatareader(DbProvider db)
		{
			PagamentiBeneficiario PagamentiBeneficiarioObj = new PagamentiBeneficiario();
			PagamentiBeneficiarioObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
			PagamentiBeneficiarioObj.IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
			PagamentiBeneficiarioObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			PagamentiBeneficiarioObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
			PagamentiBeneficiarioObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			PagamentiBeneficiarioObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			PagamentiBeneficiarioObj.QuotaContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_AMMESSO"]);
			PagamentiBeneficiarioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PagamentiBeneficiarioObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			PagamentiBeneficiarioObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			PagamentiBeneficiarioObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			PagamentiBeneficiarioObj.NumeroDoctrasporto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO"]);
			PagamentiBeneficiarioObj.DataDoctrasporto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO"]);
			PagamentiBeneficiarioObj.Imponibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE"]);
			PagamentiBeneficiarioObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
			PagamentiBeneficiarioObj.AltriOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI"]);
			PagamentiBeneficiarioObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PagamentiBeneficiarioObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
			PagamentiBeneficiarioObj.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
			PagamentiBeneficiarioObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
			PagamentiBeneficiarioObj.SpesaTecnicaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_RICHIESTA"]);
			PagamentiBeneficiarioObj.SpesaTecnicaAmmessa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA"]);
			PagamentiBeneficiarioObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
			PagamentiBeneficiarioObj.ImportoNonammNonresp = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_NONAMM_NONRESP"]);
			PagamentiBeneficiarioObj.ImportoAmmessoContr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO_CONTR"]);
			PagamentiBeneficiarioObj.ImportoNonammContrNonresp = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_NONAMM_CONTR_NONRESP"]);
			PagamentiBeneficiarioObj.SpesaTecnicaAmmessaContr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA_CONTR"]);
			PagamentiBeneficiarioObj.CostituisceVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["COSTITUISCE_VARIANTE"]);
			PagamentiBeneficiarioObj.LavoriInEconomia = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LAVORI_IN_ECONOMIA"]);
			PagamentiBeneficiarioObj.CodRiduzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RIDUZIONE"]);
			PagamentiBeneficiarioObj.MotivazioneRiduzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["MOTIVAZIONE_RIDUZIONE"]);
			PagamentiBeneficiarioObj.CodRiduzioneContr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RIDUZIONE_CONTR"]);
			PagamentiBeneficiarioObj.MotivazioneRiduzioneContr = new SiarLibrary.NullTypes.IntNT(db.DataReader["MOTIVAZIONE_RIDUZIONE_CONTR"]);
			PagamentiBeneficiarioObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PagamentiBeneficiarioObj.IsDirty = false;
			PagamentiBeneficiarioObj.IsPersistent = true;
			return PagamentiBeneficiarioObj;
		}

		//Find Select

		public static PagamentiBeneficiarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaContributoAmmessoEqualThis, SiarLibrary.NullTypes.StringNT CodRiduzioneEqualThis, SiarLibrary.NullTypes.IntNT MotivazioneRiduzioneEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoNonammNonrespEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoContrEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoNonammContrNonrespEqualThis, 
SiarLibrary.NullTypes.BoolNT SpesaTecnicaRichiestaEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaAmmessaEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaAmmessaContrEqualThis, 
SiarLibrary.NullTypes.BoolNT CostituisceVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodRiduzioneContrEqualThis, SiarLibrary.NullTypes.IntNT MotivazioneRiduzioneContrEqualThis)

		{

			PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionObj = new PagamentiBeneficiarioCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentibeneficiariofindselect", new string[] {"IdPagamentoBeneficiarioequalthis", "IdPagamentoRichiestoequalthis", "IdGiustificativoequalthis", 
"ImportoRichiestoequalthis", "ImportoAmmessoequalthis", "ContributoAmmessoequalthis", 
"QuotaContributoAmmessoequalthis", "CodRiduzioneequalthis", "MotivazioneRiduzioneequalthis", 
"ImportoNonammNonrespequalthis", "ImportoAmmessoContrequalthis", "ImportoNonammContrNonrespequalthis", 
"SpesaTecnicaRichiestaequalthis", "SpesaTecnicaAmmessaequalthis", "SpesaTecnicaAmmessaContrequalthis", 
"CostituisceVarianteequalthis", "CodRiduzioneContrequalthis", "MotivazioneRiduzioneContrequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", "string", "int", 
"decimal", "decimal", "decimal", 
"bool", "bool", "bool", 
"bool", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaContributoAmmessoequalthis", QuotaContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRiduzioneequalthis", CodRiduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRiduzioneequalthis", MotivazioneRiduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoNonammNonrespequalthis", ImportoNonammNonrespEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoContrequalthis", ImportoAmmessoContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoNonammContrNonrespequalthis", ImportoNonammContrNonrespEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaRichiestaequalthis", SpesaTecnicaRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaAmmessaequalthis", SpesaTecnicaAmmessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaAmmessaContrequalthis", SpesaTecnicaAmmessaContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostituisceVarianteequalthis", CostituisceVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRiduzioneContrequalthis", CodRiduzioneContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRiduzioneContrequalthis", MotivazioneRiduzioneContrEqualThis);
			PagamentiBeneficiario PagamentiBeneficiarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiBeneficiarioObj = GetFromDatareader(db);
				PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiBeneficiarioObj.IsDirty = false;
				PagamentiBeneficiarioObj.IsPersistent = true;
				PagamentiBeneficiarioCollectionObj.Add(PagamentiBeneficiarioObj);
			}
			db.Close();
			return PagamentiBeneficiarioCollectionObj;
		}

		//Find Find

		public static PagamentiBeneficiarioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaRichiestaEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaAmmessaEqualThis)

		{

			PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionObj = new PagamentiBeneficiarioCollection();

			IDbCommand findCmd = db.InitCmd("Zpagamentibeneficiariofindfind", new string[] {"IdPagamentoRichiestoequalthis", "IdPagamentoBeneficiarioequalthis", "IdProgettoequalthis", 
"IdGiustificativoequalthis", "SpesaTecnicaRichiestaequalthis", "SpesaTecnicaAmmessaequalthis"}, new string[] {"int", "int", "int", 
"int", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaRichiestaequalthis", SpesaTecnicaRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaAmmessaequalthis", SpesaTecnicaAmmessaEqualThis);
			PagamentiBeneficiario PagamentiBeneficiarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PagamentiBeneficiarioObj = GetFromDatareader(db);
				PagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PagamentiBeneficiarioObj.IsDirty = false;
				PagamentiBeneficiarioObj.IsPersistent = true;
				PagamentiBeneficiarioCollectionObj.Add(PagamentiBeneficiarioObj);
			}
			db.Close();
			return PagamentiBeneficiarioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PagamentiBeneficiarioCollectionProvider:IPagamentiBeneficiarioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PagamentiBeneficiarioCollectionProvider : IPagamentiBeneficiarioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PagamentiBeneficiario
		protected PagamentiBeneficiarioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PagamentiBeneficiarioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PagamentiBeneficiarioCollection(this);
		}

		//Costruttore 2: popola la collection
		public PagamentiBeneficiarioCollectionProvider(IntNT IdpagamentorichiestoEqualThis, IntNT IdpagamentobeneficiarioEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdgiustificativoEqualThis, BoolNT SpesatecnicarichiestaEqualThis, BoolNT SpesatecnicaammessaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpagamentorichiestoEqualThis, IdpagamentobeneficiarioEqualThis, IdprogettoEqualThis, 
IdgiustificativoEqualThis, SpesatecnicarichiestaEqualThis, SpesatecnicaammessaEqualThis);
		}

		//Costruttore3: ha in input pagamentibeneficiarioCollectionObj - non popola la collection
		public PagamentiBeneficiarioCollectionProvider(PagamentiBeneficiarioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PagamentiBeneficiarioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PagamentiBeneficiarioCollection(this);
		}

		//Get e Set
		public PagamentiBeneficiarioCollection CollectionObj
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
		public int SaveCollection(PagamentiBeneficiarioCollection collectionObj)
		{
			return PagamentiBeneficiarioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PagamentiBeneficiario pagamentibeneficiarioObj)
		{
			return PagamentiBeneficiarioDAL.Save(_dbProviderObj, pagamentibeneficiarioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PagamentiBeneficiarioCollection collectionObj)
		{
			return PagamentiBeneficiarioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PagamentiBeneficiario pagamentibeneficiarioObj)
		{
			return PagamentiBeneficiarioDAL.Delete(_dbProviderObj, pagamentibeneficiarioObj);
		}

		//getById
		public PagamentiBeneficiario GetById(IntNT IdPagamentoBeneficiarioValue)
		{
			PagamentiBeneficiario PagamentiBeneficiarioTemp = PagamentiBeneficiarioDAL.GetById(_dbProviderObj, IdPagamentoBeneficiarioValue);
			if (PagamentiBeneficiarioTemp!=null) PagamentiBeneficiarioTemp.Provider = this;
			return PagamentiBeneficiarioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PagamentiBeneficiarioCollection Select(IntNT IdpagamentobeneficiarioEqualThis, IntNT IdpagamentorichiestoEqualThis, IntNT IdgiustificativoEqualThis, 
DecimalNT ImportorichiestoEqualThis, DecimalNT ImportoammessoEqualThis, DecimalNT ContributoammessoEqualThis, 
DecimalNT QuotacontributoammessoEqualThis, StringNT CodriduzioneEqualThis, IntNT MotivazioneriduzioneEqualThis, 
DecimalNT ImportononammnonrespEqualThis, DecimalNT ImportoammessocontrEqualThis, DecimalNT ImportononammcontrnonrespEqualThis, 
BoolNT SpesatecnicarichiestaEqualThis, BoolNT SpesatecnicaammessaEqualThis, BoolNT SpesatecnicaammessacontrEqualThis, 
BoolNT CostituiscevarianteEqualThis, StringNT CodriduzionecontrEqualThis, IntNT MotivazioneriduzionecontrEqualThis)
		{
			PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionTemp = PagamentiBeneficiarioDAL.Select(_dbProviderObj, IdpagamentobeneficiarioEqualThis, IdpagamentorichiestoEqualThis, IdgiustificativoEqualThis, 
ImportorichiestoEqualThis, ImportoammessoEqualThis, ContributoammessoEqualThis, 
QuotacontributoammessoEqualThis, CodriduzioneEqualThis, MotivazioneriduzioneEqualThis, 
ImportononammnonrespEqualThis, ImportoammessocontrEqualThis, ImportononammcontrnonrespEqualThis, 
SpesatecnicarichiestaEqualThis, SpesatecnicaammessaEqualThis, SpesatecnicaammessacontrEqualThis, 
CostituiscevarianteEqualThis, CodriduzionecontrEqualThis, MotivazioneriduzionecontrEqualThis);
			PagamentiBeneficiarioCollectionTemp.Provider = this;
			return PagamentiBeneficiarioCollectionTemp;
		}

		//Find: popola la collection
		public PagamentiBeneficiarioCollection Find(IntNT IdpagamentorichiestoEqualThis, IntNT IdpagamentobeneficiarioEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdgiustificativoEqualThis, BoolNT SpesatecnicarichiestaEqualThis, BoolNT SpesatecnicaammessaEqualThis)
		{
			PagamentiBeneficiarioCollection PagamentiBeneficiarioCollectionTemp = PagamentiBeneficiarioDAL.Find(_dbProviderObj, IdpagamentorichiestoEqualThis, IdpagamentobeneficiarioEqualThis, IdprogettoEqualThis, 
IdgiustificativoEqualThis, SpesatecnicarichiestaEqualThis, SpesatecnicaammessaEqualThis);
			PagamentiBeneficiarioCollectionTemp.Provider = this;
			return PagamentiBeneficiarioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGAMENTI_BENEFICIARIO>
  <ViewName>vPAGAMENTI_BENEFICIARIO</ViewName>
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
    <Find OrderBy="ORDER BY ID_PAGAMENTO_BENEFICIARIO">
      <ID_PAGAMENTO_RICHIESTO>Equal</ID_PAGAMENTO_RICHIESTO>
      <ID_PAGAMENTO_BENEFICIARIO>Equal</ID_PAGAMENTO_BENEFICIARIO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <SPESA_TECNICA_RICHIESTA>Equal</SPESA_TECNICA_RICHIESTA>
      <SPESA_TECNICA_AMMESSA>Equal</SPESA_TECNICA_AMMESSA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PAGAMENTI_BENEFICIARIO>
*/
