using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VricercaSpeseIrregolari
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VricercaSpeseIrregolari: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPagamentoBeneficiario;
		private NullTypes.IntNT _IdPagamentoRichiesto;
		private NullTypes.DecimalNT _ImportoRichiesto;
		private NullTypes.DecimalNT _ImportoAmmesso;
		private NullTypes.DecimalNT _ContributoAmmesso;
		private NullTypes.DecimalNT _QuotaContributoRichiesto;
		private NullTypes.IntNT _IdSpesa;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.StringNT _CodTipoSpesa;
		private NullTypes.StringNT _EstremiSpesa;
		private NullTypes.DatetimeNT _DataSpesa;
		private NullTypes.DecimalNT _ImportoSpesa;
		private NullTypes.DecimalNT _NettoSpesa;
		private NullTypes.StringNT _TipoSpesa;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _CodTipoDomanda;
		private NullTypes.StringNT _TipoDomanda;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _NumeroGiustificativo;
		private NullTypes.StringNT _CodTipoGiustificativo;
		private NullTypes.DatetimeNT _DataGiustificativo;
		private NullTypes.StringNT _NumeroDoctrasportoGiustificativo;
		private NullTypes.DecimalNT _ImponibileGiustificativo;
		private NullTypes.DecimalNT _IvaGiustificativo;
		private NullTypes.BoolNT _IvaNonRecuperabileGiustificativo;
		private NullTypes.StringNT _DescrizioneGiustificativo;
		private NullTypes.StringNT _CfFornitoreGiustificativo;
		private NullTypes.StringNT _DescrizioneFornitoreGiustificativo;
		private NullTypes.StringNT _TipoGiustificativo;
		private NullTypes.IntNT _IdLottoCertificazione;
		private NullTypes.StringNT _CodPsrCertificazione;
		private NullTypes.DatetimeNT _DataInizioLottoCertificazione;
		private NullTypes.DatetimeNT _DataFineLottoCertificazione;


		//Costruttore
		public VricercaSpeseIrregolari()
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
		/// Corrisponde al campo:ID_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSpesa
		{
			get { return _IdSpesa; }
			set {
				if (IdSpesa != value)
				{
					_IdSpesa = value;
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
		/// Corrisponde al campo:COD_TIPO_SPESA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoSpesa
		{
			get { return _CodTipoSpesa; }
			set {
				if (CodTipoSpesa != value)
				{
					_CodTipoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESTREMI_SPESA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT EstremiSpesa
		{
			get { return _EstremiSpesa; }
			set {
				if (EstremiSpesa != value)
				{
					_EstremiSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SPESA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataSpesa
		{
			get { return _DataSpesa; }
			set {
				if (DataSpesa != value)
				{
					_DataSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_SPESA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoSpesa
		{
			get { return _ImportoSpesa; }
			set {
				if (ImportoSpesa != value)
				{
					_ImportoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NETTO_SPESA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT NettoSpesa
		{
			get { return _NettoSpesa; }
			set {
				if (NettoSpesa != value)
				{
					_NettoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_SPESA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoSpesa
		{
			get { return _TipoSpesa; }
			set {
				if (TipoSpesa != value)
				{
					_TipoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
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
		/// Corrisponde al campo:COD_TIPO_DOMANDA
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoDomanda
		{
			get { return _CodTipoDomanda; }
			set {
				if (CodTipoDomanda != value)
				{
					_CodTipoDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_DOMANDA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoDomanda
		{
			get { return _TipoDomanda; }
			set {
				if (TipoDomanda != value)
				{
					_TipoDomanda = value;
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
		/// Corrisponde al campo:NUMERO_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroGiustificativo
		{
			get { return _NumeroGiustificativo; }
			set {
				if (NumeroGiustificativo != value)
				{
					_NumeroGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_GIUSTIFICATIVO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoGiustificativo
		{
			get { return _CodTipoGiustificativo; }
			set {
				if (CodTipoGiustificativo != value)
				{
					_CodTipoGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_GIUSTIFICATIVO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataGiustificativo
		{
			get { return _DataGiustificativo; }
			set {
				if (DataGiustificativo != value)
				{
					_DataGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_DOCTRASPORTO_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT NumeroDoctrasportoGiustificativo
		{
			get { return _NumeroDoctrasportoGiustificativo; }
			set {
				if (NumeroDoctrasportoGiustificativo != value)
				{
					_NumeroDoctrasportoGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPONIBILE_GIUSTIFICATIVO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ImponibileGiustificativo
		{
			get { return _ImponibileGiustificativo; }
			set {
				if (ImponibileGiustificativo != value)
				{
					_ImponibileGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IVA_GIUSTIFICATIVO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT IvaGiustificativo
		{
			get { return _IvaGiustificativo; }
			set {
				if (IvaGiustificativo != value)
				{
					_IvaGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IVA_NON_RECUPERABILE_GIUSTIFICATIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IvaNonRecuperabileGiustificativo
		{
			get { return _IvaNonRecuperabileGiustificativo; }
			set {
				if (IvaNonRecuperabileGiustificativo != value)
				{
					_IvaNonRecuperabileGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneGiustificativo
		{
			get { return _DescrizioneGiustificativo; }
			set {
				if (DescrizioneGiustificativo != value)
				{
					_DescrizioneGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_FORNITORE_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfFornitoreGiustificativo
		{
			get { return _CfFornitoreGiustificativo; }
			set {
				if (CfFornitoreGiustificativo != value)
				{
					_CfFornitoreGiustificativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FORNITORE_GIUSTIFICATIVO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneFornitoreGiustificativo
		{
			get { return _DescrizioneFornitoreGiustificativo; }
			set {
				if (DescrizioneFornitoreGiustificativo != value)
				{
					_DescrizioneFornitoreGiustificativo = value;
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
		/// Corrisponde al campo:ID_LOTTO_CERTIFICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLottoCertificazione
		{
			get { return _IdLottoCertificazione; }
			set {
				if (IdLottoCertificazione != value)
				{
					_IdLottoCertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PSR_CERTIFICAZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodPsrCertificazione
		{
			get { return _CodPsrCertificazione; }
			set {
				if (CodPsrCertificazione != value)
				{
					_CodPsrCertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_LOTTO_CERTIFICAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioLottoCertificazione
		{
			get { return _DataInizioLottoCertificazione; }
			set {
				if (DataInizioLottoCertificazione != value)
				{
					_DataInizioLottoCertificazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_LOTTO_CERTIFICAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineLottoCertificazione
		{
			get { return _DataFineLottoCertificazione; }
			set {
				if (DataFineLottoCertificazione != value)
				{
					_DataFineLottoCertificazione = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VricercaSpeseIrregolariCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VricercaSpeseIrregolariCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VricercaSpeseIrregolariCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VricercaSpeseIrregolari) info.GetValue(i.ToString(),typeof(VricercaSpeseIrregolari)));
			}
		}

		//Costruttore
		public VricercaSpeseIrregolariCollection()
		{
			this.ItemType = typeof(VricercaSpeseIrregolari);
		}

		//Get e Set
		public new VricercaSpeseIrregolari this[int index]
		{
			get { return (VricercaSpeseIrregolari)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VricercaSpeseIrregolariCollection GetChanges()
		{
			return (VricercaSpeseIrregolariCollection) base.GetChanges();
		}

		//Add
		public int Add(VricercaSpeseIrregolari VricercaSpeseIrregolariObj)
		{
			return base.Add(VricercaSpeseIrregolariObj);
		}

		//AddCollection
		public void AddCollection(VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionObj)
		{
			foreach (VricercaSpeseIrregolari VricercaSpeseIrregolariObj in VricercaSpeseIrregolariCollectionObj)
				this.Add(VricercaSpeseIrregolariObj);
		}

		//Insert
		public void Insert(int index, VricercaSpeseIrregolari VricercaSpeseIrregolariObj)
		{
			base.Insert(index, VricercaSpeseIrregolariObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VricercaSpeseIrregolariCollection SubSelect(NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, NullTypes.IntNT IdPagamentoRichiestoEqualThis, NullTypes.DecimalNT ImportoRichiestoEqualThis, 
NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, 
NullTypes.IntNT IdSpesaEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, NullTypes.StringNT CodTipoSpesaEqualThis, 
NullTypes.StringNT EstremiSpesaEqualThis, NullTypes.DatetimeNT DataSpesaEqualThis, NullTypes.DecimalNT ImportoSpesaEqualThis, 
NullTypes.DecimalNT NettoSpesaEqualThis, NullTypes.StringNT TipoSpesaEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.StringNT CodTipoDomandaEqualThis, NullTypes.StringNT TipoDomandaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.StringNT NumeroGiustificativoEqualThis, NullTypes.StringNT CodTipoGiustificativoEqualThis, NullTypes.DatetimeNT DataGiustificativoEqualThis, 
NullTypes.StringNT NumeroDoctrasportoGiustificativoEqualThis, NullTypes.DecimalNT ImponibileGiustificativoEqualThis, NullTypes.DecimalNT IvaGiustificativoEqualThis, 
NullTypes.BoolNT IvaNonRecuperabileGiustificativoEqualThis, NullTypes.StringNT DescrizioneGiustificativoEqualThis, NullTypes.StringNT CfFornitoreGiustificativoEqualThis, 
NullTypes.StringNT DescrizioneFornitoreGiustificativoEqualThis, NullTypes.StringNT TipoGiustificativoEqualThis, NullTypes.IntNT IdLottoCertificazioneEqualThis, 
NullTypes.StringNT CodPsrCertificazioneEqualThis, NullTypes.DatetimeNT DataInizioLottoCertificazioneEqualThis, NullTypes.DatetimeNT DataFineLottoCertificazioneEqualThis)
		{
			VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionTemp = new VricercaSpeseIrregolariCollection();
			foreach (VricercaSpeseIrregolari VricercaSpeseIrregolariItem in this)
			{
				if (((IdPagamentoBeneficiarioEqualThis == null) || ((VricercaSpeseIrregolariItem.IdPagamentoBeneficiario != null) && (VricercaSpeseIrregolariItem.IdPagamentoBeneficiario.Value == IdPagamentoBeneficiarioEqualThis.Value))) && ((IdPagamentoRichiestoEqualThis == null) || ((VricercaSpeseIrregolariItem.IdPagamentoRichiesto != null) && (VricercaSpeseIrregolariItem.IdPagamentoRichiesto.Value == IdPagamentoRichiestoEqualThis.Value))) && ((ImportoRichiestoEqualThis == null) || ((VricercaSpeseIrregolariItem.ImportoRichiesto != null) && (VricercaSpeseIrregolariItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) && 
((ImportoAmmessoEqualThis == null) || ((VricercaSpeseIrregolariItem.ImportoAmmesso != null) && (VricercaSpeseIrregolariItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((VricercaSpeseIrregolariItem.ContributoAmmesso != null) && (VricercaSpeseIrregolariItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && ((QuotaContributoRichiestoEqualThis == null) || ((VricercaSpeseIrregolariItem.QuotaContributoRichiesto != null) && (VricercaSpeseIrregolariItem.QuotaContributoRichiesto.Value == QuotaContributoRichiestoEqualThis.Value))) && 
((IdSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.IdSpesa != null) && (VricercaSpeseIrregolariItem.IdSpesa.Value == IdSpesaEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.IdGiustificativo != null) && (VricercaSpeseIrregolariItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && ((CodTipoSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.CodTipoSpesa != null) && (VricercaSpeseIrregolariItem.CodTipoSpesa.Value == CodTipoSpesaEqualThis.Value))) && 
((EstremiSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.EstremiSpesa != null) && (VricercaSpeseIrregolariItem.EstremiSpesa.Value == EstremiSpesaEqualThis.Value))) && ((DataSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.DataSpesa != null) && (VricercaSpeseIrregolariItem.DataSpesa.Value == DataSpesaEqualThis.Value))) && ((ImportoSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.ImportoSpesa != null) && (VricercaSpeseIrregolariItem.ImportoSpesa.Value == ImportoSpesaEqualThis.Value))) && 
((NettoSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.NettoSpesa != null) && (VricercaSpeseIrregolariItem.NettoSpesa.Value == NettoSpesaEqualThis.Value))) && ((TipoSpesaEqualThis == null) || ((VricercaSpeseIrregolariItem.TipoSpesa != null) && (VricercaSpeseIrregolariItem.TipoSpesa.Value == TipoSpesaEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VricercaSpeseIrregolariItem.IdDomandaPagamento != null) && (VricercaSpeseIrregolariItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((CodTipoDomandaEqualThis == null) || ((VricercaSpeseIrregolariItem.CodTipoDomanda != null) && (VricercaSpeseIrregolariItem.CodTipoDomanda.Value == CodTipoDomandaEqualThis.Value))) && ((TipoDomandaEqualThis == null) || ((VricercaSpeseIrregolariItem.TipoDomanda != null) && (VricercaSpeseIrregolariItem.TipoDomanda.Value == TipoDomandaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VricercaSpeseIrregolariItem.IdProgetto != null) && (VricercaSpeseIrregolariItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((NumeroGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.NumeroGiustificativo != null) && (VricercaSpeseIrregolariItem.NumeroGiustificativo.Value == NumeroGiustificativoEqualThis.Value))) && ((CodTipoGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.CodTipoGiustificativo != null) && (VricercaSpeseIrregolariItem.CodTipoGiustificativo.Value == CodTipoGiustificativoEqualThis.Value))) && ((DataGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.DataGiustificativo != null) && (VricercaSpeseIrregolariItem.DataGiustificativo.Value == DataGiustificativoEqualThis.Value))) && 
((NumeroDoctrasportoGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.NumeroDoctrasportoGiustificativo != null) && (VricercaSpeseIrregolariItem.NumeroDoctrasportoGiustificativo.Value == NumeroDoctrasportoGiustificativoEqualThis.Value))) && ((ImponibileGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.ImponibileGiustificativo != null) && (VricercaSpeseIrregolariItem.ImponibileGiustificativo.Value == ImponibileGiustificativoEqualThis.Value))) && ((IvaGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.IvaGiustificativo != null) && (VricercaSpeseIrregolariItem.IvaGiustificativo.Value == IvaGiustificativoEqualThis.Value))) && 
((IvaNonRecuperabileGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.IvaNonRecuperabileGiustificativo != null) && (VricercaSpeseIrregolariItem.IvaNonRecuperabileGiustificativo.Value == IvaNonRecuperabileGiustificativoEqualThis.Value))) && ((DescrizioneGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.DescrizioneGiustificativo != null) && (VricercaSpeseIrregolariItem.DescrizioneGiustificativo.Value == DescrizioneGiustificativoEqualThis.Value))) && ((CfFornitoreGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.CfFornitoreGiustificativo != null) && (VricercaSpeseIrregolariItem.CfFornitoreGiustificativo.Value == CfFornitoreGiustificativoEqualThis.Value))) && 
((DescrizioneFornitoreGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.DescrizioneFornitoreGiustificativo != null) && (VricercaSpeseIrregolariItem.DescrizioneFornitoreGiustificativo.Value == DescrizioneFornitoreGiustificativoEqualThis.Value))) && ((TipoGiustificativoEqualThis == null) || ((VricercaSpeseIrregolariItem.TipoGiustificativo != null) && (VricercaSpeseIrregolariItem.TipoGiustificativo.Value == TipoGiustificativoEqualThis.Value))) && ((IdLottoCertificazioneEqualThis == null) || ((VricercaSpeseIrregolariItem.IdLottoCertificazione != null) && (VricercaSpeseIrregolariItem.IdLottoCertificazione.Value == IdLottoCertificazioneEqualThis.Value))) && 
((CodPsrCertificazioneEqualThis == null) || ((VricercaSpeseIrregolariItem.CodPsrCertificazione != null) && (VricercaSpeseIrregolariItem.CodPsrCertificazione.Value == CodPsrCertificazioneEqualThis.Value))) && ((DataInizioLottoCertificazioneEqualThis == null) || ((VricercaSpeseIrregolariItem.DataInizioLottoCertificazione != null) && (VricercaSpeseIrregolariItem.DataInizioLottoCertificazione.Value == DataInizioLottoCertificazioneEqualThis.Value))) && ((DataFineLottoCertificazioneEqualThis == null) || ((VricercaSpeseIrregolariItem.DataFineLottoCertificazione != null) && (VricercaSpeseIrregolariItem.DataFineLottoCertificazione.Value == DataFineLottoCertificazioneEqualThis.Value))))
				{
					VricercaSpeseIrregolariCollectionTemp.Add(VricercaSpeseIrregolariItem);
				}
			}
			return VricercaSpeseIrregolariCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VricercaSpeseIrregolariDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VricercaSpeseIrregolariDAL
	{

		//Operazioni

		//getFromDatareader
		public static VricercaSpeseIrregolari GetFromDatareader(DbProvider db)
		{
			VricercaSpeseIrregolari VricercaSpeseIrregolariObj = new VricercaSpeseIrregolari();
			VricercaSpeseIrregolariObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
			VricercaSpeseIrregolariObj.IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
			VricercaSpeseIrregolariObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
			VricercaSpeseIrregolariObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			VricercaSpeseIrregolariObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			VricercaSpeseIrregolariObj.QuotaContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
			VricercaSpeseIrregolariObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
			VricercaSpeseIrregolariObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.CodTipoSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_SPESA"]);
			VricercaSpeseIrregolariObj.EstremiSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESTREMI_SPESA"]);
			VricercaSpeseIrregolariObj.DataSpesa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SPESA"]);
			VricercaSpeseIrregolariObj.ImportoSpesa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA"]);
			VricercaSpeseIrregolariObj.NettoSpesa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["NETTO_SPESA"]);
			VricercaSpeseIrregolariObj.TipoSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SPESA"]);
			VricercaSpeseIrregolariObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			VricercaSpeseIrregolariObj.CodTipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOMANDA"]);
			VricercaSpeseIrregolariObj.TipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA"]);
			VricercaSpeseIrregolariObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VricercaSpeseIrregolariObj.NumeroGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.CodTipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.DataGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.NumeroDoctrasportoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.ImponibileGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.IvaGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.IvaNonRecuperabileGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.DescrizioneGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.CfFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.DescrizioneFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
			VricercaSpeseIrregolariObj.IdLottoCertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_CERTIFICAZIONE"]);
			VricercaSpeseIrregolariObj.CodPsrCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR_CERTIFICAZIONE"]);
			VricercaSpeseIrregolariObj.DataInizioLottoCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_LOTTO_CERTIFICAZIONE"]);
			VricercaSpeseIrregolariObj.DataFineLottoCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_LOTTO_CERTIFICAZIONE"]);
			VricercaSpeseIrregolariObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VricercaSpeseIrregolariObj.IsDirty = false;
			VricercaSpeseIrregolariObj.IsPersistent = true;
			return VricercaSpeseIrregolariObj;
		}

		//Find Select

		public static VricercaSpeseIrregolariCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, 
SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoSpesaEqualThis, 
SiarLibrary.NullTypes.StringNT EstremiSpesaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataSpesaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoSpesaEqualThis, 
SiarLibrary.NullTypes.DecimalNT NettoSpesaEqualThis, SiarLibrary.NullTypes.StringNT TipoSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoDomandaEqualThis, SiarLibrary.NullTypes.StringNT TipoDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroGiustificativoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoGiustificativoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataGiustificativoEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroDoctrasportoGiustificativoEqualThis, SiarLibrary.NullTypes.DecimalNT ImponibileGiustificativoEqualThis, SiarLibrary.NullTypes.DecimalNT IvaGiustificativoEqualThis, 
SiarLibrary.NullTypes.BoolNT IvaNonRecuperabileGiustificativoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneGiustificativoEqualThis, SiarLibrary.NullTypes.StringNT CfFornitoreGiustificativoEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneFornitoreGiustificativoEqualThis, SiarLibrary.NullTypes.StringNT TipoGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoCertificazioneEqualThis, 
SiarLibrary.NullTypes.StringNT CodPsrCertificazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioLottoCertificazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineLottoCertificazioneEqualThis)

		{

			VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionObj = new VricercaSpeseIrregolariCollection();

			IDbCommand findCmd = db.InitCmd("Zvricercaspeseirregolarifindselect", new string[] {"IdPagamentoBeneficiarioequalthis", "IdPagamentoRichiestoequalthis", "ImportoRichiestoequalthis", 
"ImportoAmmessoequalthis", "ContributoAmmessoequalthis", "QuotaContributoRichiestoequalthis", 
"IdSpesaequalthis", "IdGiustificativoequalthis", "CodTipoSpesaequalthis", 
"EstremiSpesaequalthis", "DataSpesaequalthis", "ImportoSpesaequalthis", 
"NettoSpesaequalthis", "TipoSpesaequalthis", "IdDomandaPagamentoequalthis", 
"CodTipoDomandaequalthis", "TipoDomandaequalthis", "IdProgettoequalthis", 
"NumeroGiustificativoequalthis", "CodTipoGiustificativoequalthis", "DataGiustificativoequalthis", 
"NumeroDoctrasportoGiustificativoequalthis", "ImponibileGiustificativoequalthis", "IvaGiustificativoequalthis", 
"IvaNonRecuperabileGiustificativoequalthis", "DescrizioneGiustificativoequalthis", "CfFornitoreGiustificativoequalthis", 
"DescrizioneFornitoreGiustificativoequalthis", "TipoGiustificativoequalthis", "IdLottoCertificazioneequalthis", 
"CodPsrCertificazioneequalthis", "DataInizioLottoCertificazioneequalthis", "DataFineLottoCertificazioneequalthis"}, new string[] {"int", "int", "decimal", 
"decimal", "decimal", "decimal", 
"int", "int", "string", 
"string", "DateTime", "decimal", 
"decimal", "string", "int", 
"string", "string", "int", 
"string", "string", "DateTime", 
"string", "decimal", "decimal", 
"bool", "string", "string", 
"string", "string", "int", 
"string", "DateTime", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaContributoRichiestoequalthis", QuotaContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSpesaequalthis", CodTipoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EstremiSpesaequalthis", EstremiSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataSpesaequalthis", DataSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoSpesaequalthis", ImportoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NettoSpesaequalthis", NettoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoSpesaequalthis", TipoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoDomandaequalthis", CodTipoDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDomandaequalthis", TipoDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroGiustificativoequalthis", NumeroGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoGiustificativoequalthis", CodTipoGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataGiustificativoequalthis", DataGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroDoctrasportoGiustificativoequalthis", NumeroDoctrasportoGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImponibileGiustificativoequalthis", ImponibileGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IvaGiustificativoequalthis", IvaGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IvaNonRecuperabileGiustificativoequalthis", IvaNonRecuperabileGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneGiustificativoequalthis", DescrizioneGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfFornitoreGiustificativoequalthis", CfFornitoreGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneFornitoreGiustificativoequalthis", DescrizioneFornitoreGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoGiustificativoequalthis", TipoGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoCertificazioneequalthis", IdLottoCertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrCertificazioneequalthis", CodPsrCertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioLottoCertificazioneequalthis", DataInizioLottoCertificazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineLottoCertificazioneequalthis", DataFineLottoCertificazioneEqualThis);
			VricercaSpeseIrregolari VricercaSpeseIrregolariObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VricercaSpeseIrregolariObj = GetFromDatareader(db);
				VricercaSpeseIrregolariObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VricercaSpeseIrregolariObj.IsDirty = false;
				VricercaSpeseIrregolariObj.IsPersistent = true;
				VricercaSpeseIrregolariCollectionObj.Add(VricercaSpeseIrregolariObj);
			}
			db.Close();
			return VricercaSpeseIrregolariCollectionObj;
		}

		//Find FindSpeseProgetto

		public static VricercaSpeseIrregolariCollection FindSpeseProgetto(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis)

		{

			VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionObj = new VricercaSpeseIrregolariCollection();

			IDbCommand findCmd = db.InitCmd("Zvricercaspeseirregolarifindfindspeseprogetto", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdGiustificativoequalthis", 
"IdSpesaequalthis", "IdPagamentoRichiestoequalthis"}, new string[] {"int", "int", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			VricercaSpeseIrregolari VricercaSpeseIrregolariObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VricercaSpeseIrregolariObj = GetFromDatareader(db);
				VricercaSpeseIrregolariObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VricercaSpeseIrregolariObj.IsDirty = false;
				VricercaSpeseIrregolariObj.IsPersistent = true;
				VricercaSpeseIrregolariCollectionObj.Add(VricercaSpeseIrregolariObj);
			}
			db.Close();
			return VricercaSpeseIrregolariCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VricercaSpeseIrregolariCollectionProvider:IVricercaSpeseIrregolariProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VricercaSpeseIrregolariCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VricercaSpeseIrregolari
		protected VricercaSpeseIrregolariCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VricercaSpeseIrregolariCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VricercaSpeseIrregolariCollection();
		}

		//Costruttore 2: popola la collection
		public VricercaSpeseIrregolariCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdspesaEqualThis, IntNT IdpagamentorichiestoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindSpeseProgetto(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis, 
IdspesaEqualThis, IdpagamentorichiestoEqualThis);
		}

		//Costruttore3: ha in input vricercaspeseirregolariCollectionObj - non popola la collection
		public VricercaSpeseIrregolariCollectionProvider(VricercaSpeseIrregolariCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VricercaSpeseIrregolariCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VricercaSpeseIrregolariCollection();
		}

		//Get e Set
		public VricercaSpeseIrregolariCollection CollectionObj
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
		public VricercaSpeseIrregolariCollection Select(IntNT IdpagamentobeneficiarioEqualThis, IntNT IdpagamentorichiestoEqualThis, DecimalNT ImportorichiestoEqualThis, 
DecimalNT ImportoammessoEqualThis, DecimalNT ContributoammessoEqualThis, DecimalNT QuotacontributorichiestoEqualThis, 
IntNT IdspesaEqualThis, IntNT IdgiustificativoEqualThis, StringNT CodtipospesaEqualThis, 
StringNT EstremispesaEqualThis, DatetimeNT DataspesaEqualThis, DecimalNT ImportospesaEqualThis, 
DecimalNT NettospesaEqualThis, StringNT TipospesaEqualThis, IntNT IddomandapagamentoEqualThis, 
StringNT CodtipodomandaEqualThis, StringNT TipodomandaEqualThis, IntNT IdprogettoEqualThis, 
StringNT NumerogiustificativoEqualThis, StringNT CodtipogiustificativoEqualThis, DatetimeNT DatagiustificativoEqualThis, 
StringNT NumerodoctrasportogiustificativoEqualThis, DecimalNT ImponibilegiustificativoEqualThis, DecimalNT IvagiustificativoEqualThis, 
BoolNT IvanonrecuperabilegiustificativoEqualThis, StringNT DescrizionegiustificativoEqualThis, StringNT CffornitoregiustificativoEqualThis, 
StringNT DescrizionefornitoregiustificativoEqualThis, StringNT TipogiustificativoEqualThis, IntNT IdlottocertificazioneEqualThis, 
StringNT CodpsrcertificazioneEqualThis, DatetimeNT DatainiziolottocertificazioneEqualThis, DatetimeNT DatafinelottocertificazioneEqualThis)
		{
			VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionTemp = VricercaSpeseIrregolariDAL.Select(_dbProviderObj, IdpagamentobeneficiarioEqualThis, IdpagamentorichiestoEqualThis, ImportorichiestoEqualThis, 
ImportoammessoEqualThis, ContributoammessoEqualThis, QuotacontributorichiestoEqualThis, 
IdspesaEqualThis, IdgiustificativoEqualThis, CodtipospesaEqualThis, 
EstremispesaEqualThis, DataspesaEqualThis, ImportospesaEqualThis, 
NettospesaEqualThis, TipospesaEqualThis, IddomandapagamentoEqualThis, 
CodtipodomandaEqualThis, TipodomandaEqualThis, IdprogettoEqualThis, 
NumerogiustificativoEqualThis, CodtipogiustificativoEqualThis, DatagiustificativoEqualThis, 
NumerodoctrasportogiustificativoEqualThis, ImponibilegiustificativoEqualThis, IvagiustificativoEqualThis, 
IvanonrecuperabilegiustificativoEqualThis, DescrizionegiustificativoEqualThis, CffornitoregiustificativoEqualThis, 
DescrizionefornitoregiustificativoEqualThis, TipogiustificativoEqualThis, IdlottocertificazioneEqualThis, 
CodpsrcertificazioneEqualThis, DatainiziolottocertificazioneEqualThis, DatafinelottocertificazioneEqualThis);
			return VricercaSpeseIrregolariCollectionTemp;
		}

		//FindSpeseProgetto: popola la collection
		public VricercaSpeseIrregolariCollection FindSpeseProgetto(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdspesaEqualThis, IntNT IdpagamentorichiestoEqualThis)
		{
			VricercaSpeseIrregolariCollection VricercaSpeseIrregolariCollectionTemp = VricercaSpeseIrregolariDAL.FindSpeseProgetto(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdgiustificativoEqualThis, 
IdspesaEqualThis, IdpagamentorichiestoEqualThis);
			return VricercaSpeseIrregolariCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VRICERCA_SPESE_IRREGOLARI>
  <ViewName>VRICERCA_SPESE_IRREGOLARI</ViewName>
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
    <FindSpeseProgetto OrderBy="ORDER BY ID_DOMANDA_PAGAMENTO ASC, ID_GIUSTIFICATIVO ASC, ID_SPESA ASC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_SPESA>Equal</ID_SPESA>
      <ID_PAGAMENTO_RICHIESTO>Equal</ID_PAGAMENTO_RICHIESTO>
    </FindSpeseProgetto>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VRICERCA_SPESE_IRREGOLARI>
*/
