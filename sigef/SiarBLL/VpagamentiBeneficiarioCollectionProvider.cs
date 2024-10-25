using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VpagamentiBeneficiario
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VpagamentiBeneficiario: BaseObject
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


		//Costruttore
		public VpagamentiBeneficiario()
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
		/// Tipo sul db:DECIMAL(10,2)
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




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VpagamentiBeneficiarioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VpagamentiBeneficiarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VpagamentiBeneficiarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VpagamentiBeneficiario) info.GetValue(i.ToString(),typeof(VpagamentiBeneficiario)));
			}
		}

		//Costruttore
		public VpagamentiBeneficiarioCollection()
		{
			this.ItemType = typeof(VpagamentiBeneficiario);
		}

		//Get e Set
		public new VpagamentiBeneficiario this[int index]
		{
			get { return (VpagamentiBeneficiario)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VpagamentiBeneficiarioCollection GetChanges()
		{
			return (VpagamentiBeneficiarioCollection) base.GetChanges();
		}

		//Add
		public int Add(VpagamentiBeneficiario VpagamentiBeneficiarioObj)
		{
			return base.Add(VpagamentiBeneficiarioObj);
		}

		//AddCollection
		public void AddCollection(VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionObj)
		{
			foreach (VpagamentiBeneficiario VpagamentiBeneficiarioObj in VpagamentiBeneficiarioCollectionObj)
				this.Add(VpagamentiBeneficiarioObj);
		}

		//Insert
		public void Insert(int index, VpagamentiBeneficiario VpagamentiBeneficiarioObj)
		{
			base.Insert(index, VpagamentiBeneficiarioObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VpagamentiBeneficiarioCollection SubSelect(NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, NullTypes.IntNT IdPagamentoRichiestoEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, 
NullTypes.DecimalNT ImportoRichiestoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, 
NullTypes.DecimalNT QuotaContributoAmmessoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT NumeroEqualThis, 
NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT NumeroDoctrasportoEqualThis, 
NullTypes.DatetimeNT DataDoctrasportoEqualThis, NullTypes.DecimalNT ImponibileEqualThis, NullTypes.DecimalNT IvaEqualThis, 
NullTypes.DecimalNT AltriOneriEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CfFornitoreEqualThis, 
NullTypes.StringNT DescrizioneFornitoreEqualThis, NullTypes.StringNT TipoGiustificativoEqualThis, NullTypes.BoolNT SpesaTecnicaRichiestaEqualThis, 
NullTypes.BoolNT SpesaTecnicaAmmessaEqualThis, NullTypes.BoolNT IvaNonRecuperabileEqualThis, NullTypes.DecimalNT ImportoNonammNonrespEqualThis, 
NullTypes.DecimalNT ImportoAmmessoContrEqualThis, NullTypes.DecimalNT ImportoNonammContrNonrespEqualThis, NullTypes.BoolNT SpesaTecnicaAmmessaContrEqualThis, 
NullTypes.BoolNT CostituisceVarianteEqualThis, NullTypes.BoolNT LavoriInEconomiaEqualThis, NullTypes.StringNT CodRiduzioneEqualThis, 
NullTypes.IntNT MotivazioneRiduzioneEqualThis, NullTypes.StringNT CodRiduzioneContrEqualThis, NullTypes.IntNT MotivazioneRiduzioneContrEqualThis, 
NullTypes.IntNT IdFileEqualThis)
		{
			VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionTemp = new VpagamentiBeneficiarioCollection();
			foreach (VpagamentiBeneficiario VpagamentiBeneficiarioItem in this)
			{
				if (((IdPagamentoBeneficiarioEqualThis == null) || ((VpagamentiBeneficiarioItem.IdPagamentoBeneficiario != null) && (VpagamentiBeneficiarioItem.IdPagamentoBeneficiario.Value == IdPagamentoBeneficiarioEqualThis.Value))) && ((IdPagamentoRichiestoEqualThis == null) || ((VpagamentiBeneficiarioItem.IdPagamentoRichiesto != null) && (VpagamentiBeneficiarioItem.IdPagamentoRichiesto.Value == IdPagamentoRichiestoEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((VpagamentiBeneficiarioItem.IdGiustificativo != null) && (VpagamentiBeneficiarioItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && 
((ImportoRichiestoEqualThis == null) || ((VpagamentiBeneficiarioItem.ImportoRichiesto != null) && (VpagamentiBeneficiarioItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((VpagamentiBeneficiarioItem.ImportoAmmesso != null) && (VpagamentiBeneficiarioItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((VpagamentiBeneficiarioItem.ContributoAmmesso != null) && (VpagamentiBeneficiarioItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && 
((QuotaContributoAmmessoEqualThis == null) || ((VpagamentiBeneficiarioItem.QuotaContributoAmmesso != null) && (VpagamentiBeneficiarioItem.QuotaContributoAmmesso.Value == QuotaContributoAmmessoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VpagamentiBeneficiarioItem.IdProgetto != null) && (VpagamentiBeneficiarioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((NumeroEqualThis == null) || ((VpagamentiBeneficiarioItem.Numero != null) && (VpagamentiBeneficiarioItem.Numero.Value == NumeroEqualThis.Value))) && 
((CodTipoEqualThis == null) || ((VpagamentiBeneficiarioItem.CodTipo != null) && (VpagamentiBeneficiarioItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataEqualThis == null) || ((VpagamentiBeneficiarioItem.Data != null) && (VpagamentiBeneficiarioItem.Data.Value == DataEqualThis.Value))) && ((NumeroDoctrasportoEqualThis == null) || ((VpagamentiBeneficiarioItem.NumeroDoctrasporto != null) && (VpagamentiBeneficiarioItem.NumeroDoctrasporto.Value == NumeroDoctrasportoEqualThis.Value))) && 
((DataDoctrasportoEqualThis == null) || ((VpagamentiBeneficiarioItem.DataDoctrasporto != null) && (VpagamentiBeneficiarioItem.DataDoctrasporto.Value == DataDoctrasportoEqualThis.Value))) && ((ImponibileEqualThis == null) || ((VpagamentiBeneficiarioItem.Imponibile != null) && (VpagamentiBeneficiarioItem.Imponibile.Value == ImponibileEqualThis.Value))) && ((IvaEqualThis == null) || ((VpagamentiBeneficiarioItem.Iva != null) && (VpagamentiBeneficiarioItem.Iva.Value == IvaEqualThis.Value))) && 
((AltriOneriEqualThis == null) || ((VpagamentiBeneficiarioItem.AltriOneri != null) && (VpagamentiBeneficiarioItem.AltriOneri.Value == AltriOneriEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VpagamentiBeneficiarioItem.Descrizione != null) && (VpagamentiBeneficiarioItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CfFornitoreEqualThis == null) || ((VpagamentiBeneficiarioItem.CfFornitore != null) && (VpagamentiBeneficiarioItem.CfFornitore.Value == CfFornitoreEqualThis.Value))) && 
((DescrizioneFornitoreEqualThis == null) || ((VpagamentiBeneficiarioItem.DescrizioneFornitore != null) && (VpagamentiBeneficiarioItem.DescrizioneFornitore.Value == DescrizioneFornitoreEqualThis.Value))) && ((TipoGiustificativoEqualThis == null) || ((VpagamentiBeneficiarioItem.TipoGiustificativo != null) && (VpagamentiBeneficiarioItem.TipoGiustificativo.Value == TipoGiustificativoEqualThis.Value))) && ((SpesaTecnicaRichiestaEqualThis == null) || ((VpagamentiBeneficiarioItem.SpesaTecnicaRichiesta != null) && (VpagamentiBeneficiarioItem.SpesaTecnicaRichiesta.Value == SpesaTecnicaRichiestaEqualThis.Value))) && 
((SpesaTecnicaAmmessaEqualThis == null) || ((VpagamentiBeneficiarioItem.SpesaTecnicaAmmessa != null) && (VpagamentiBeneficiarioItem.SpesaTecnicaAmmessa.Value == SpesaTecnicaAmmessaEqualThis.Value))) && ((IvaNonRecuperabileEqualThis == null) || ((VpagamentiBeneficiarioItem.IvaNonRecuperabile != null) && (VpagamentiBeneficiarioItem.IvaNonRecuperabile.Value == IvaNonRecuperabileEqualThis.Value))) && ((ImportoNonammNonrespEqualThis == null) || ((VpagamentiBeneficiarioItem.ImportoNonammNonresp != null) && (VpagamentiBeneficiarioItem.ImportoNonammNonresp.Value == ImportoNonammNonrespEqualThis.Value))) && 
((ImportoAmmessoContrEqualThis == null) || ((VpagamentiBeneficiarioItem.ImportoAmmessoContr != null) && (VpagamentiBeneficiarioItem.ImportoAmmessoContr.Value == ImportoAmmessoContrEqualThis.Value))) && ((ImportoNonammContrNonrespEqualThis == null) || ((VpagamentiBeneficiarioItem.ImportoNonammContrNonresp != null) && (VpagamentiBeneficiarioItem.ImportoNonammContrNonresp.Value == ImportoNonammContrNonrespEqualThis.Value))) && ((SpesaTecnicaAmmessaContrEqualThis == null) || ((VpagamentiBeneficiarioItem.SpesaTecnicaAmmessaContr != null) && (VpagamentiBeneficiarioItem.SpesaTecnicaAmmessaContr.Value == SpesaTecnicaAmmessaContrEqualThis.Value))) && 
((CostituisceVarianteEqualThis == null) || ((VpagamentiBeneficiarioItem.CostituisceVariante != null) && (VpagamentiBeneficiarioItem.CostituisceVariante.Value == CostituisceVarianteEqualThis.Value))) && ((LavoriInEconomiaEqualThis == null) || ((VpagamentiBeneficiarioItem.LavoriInEconomia != null) && (VpagamentiBeneficiarioItem.LavoriInEconomia.Value == LavoriInEconomiaEqualThis.Value))) && ((CodRiduzioneEqualThis == null) || ((VpagamentiBeneficiarioItem.CodRiduzione != null) && (VpagamentiBeneficiarioItem.CodRiduzione.Value == CodRiduzioneEqualThis.Value))) && 
((MotivazioneRiduzioneEqualThis == null) || ((VpagamentiBeneficiarioItem.MotivazioneRiduzione != null) && (VpagamentiBeneficiarioItem.MotivazioneRiduzione.Value == MotivazioneRiduzioneEqualThis.Value))) && ((CodRiduzioneContrEqualThis == null) || ((VpagamentiBeneficiarioItem.CodRiduzioneContr != null) && (VpagamentiBeneficiarioItem.CodRiduzioneContr.Value == CodRiduzioneContrEqualThis.Value))) && ((MotivazioneRiduzioneContrEqualThis == null) || ((VpagamentiBeneficiarioItem.MotivazioneRiduzioneContr != null) && (VpagamentiBeneficiarioItem.MotivazioneRiduzioneContr.Value == MotivazioneRiduzioneContrEqualThis.Value))) && 
((IdFileEqualThis == null) || ((VpagamentiBeneficiarioItem.IdFile != null) && (VpagamentiBeneficiarioItem.IdFile.Value == IdFileEqualThis.Value))))
				{
					VpagamentiBeneficiarioCollectionTemp.Add(VpagamentiBeneficiarioItem);
				}
			}
			return VpagamentiBeneficiarioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VpagamentiBeneficiarioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VpagamentiBeneficiarioDAL
	{

		//Operazioni

		//getFromDatareader
		public static VpagamentiBeneficiario GetFromDatareader(DbProvider db)
		{
			VpagamentiBeneficiario VpagamentiBeneficiarioObj = new VpagamentiBeneficiario();
			VpagamentiBeneficiarioObj.IdPagamentoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_BENEFICIARIO"]);
			VpagamentiBeneficiarioObj.IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
			VpagamentiBeneficiarioObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			VpagamentiBeneficiarioObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
			VpagamentiBeneficiarioObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			VpagamentiBeneficiarioObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			VpagamentiBeneficiarioObj.QuotaContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_AMMESSO"]);
			VpagamentiBeneficiarioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VpagamentiBeneficiarioObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			VpagamentiBeneficiarioObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			VpagamentiBeneficiarioObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			VpagamentiBeneficiarioObj.NumeroDoctrasporto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO"]);
			VpagamentiBeneficiarioObj.DataDoctrasporto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DOCTRASPORTO"]);
			VpagamentiBeneficiarioObj.Imponibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE"]);
			VpagamentiBeneficiarioObj.Iva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA"]);
			VpagamentiBeneficiarioObj.AltriOneri = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ALTRI_ONERI"]);
			VpagamentiBeneficiarioObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VpagamentiBeneficiarioObj.CfFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE"]);
			VpagamentiBeneficiarioObj.DescrizioneFornitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE"]);
			VpagamentiBeneficiarioObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
			VpagamentiBeneficiarioObj.SpesaTecnicaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_RICHIESTA"]);
			VpagamentiBeneficiarioObj.SpesaTecnicaAmmessa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA"]);
			VpagamentiBeneficiarioObj.IvaNonRecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE"]);
			VpagamentiBeneficiarioObj.ImportoNonammNonresp = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_NONAMM_NONRESP"]);
			VpagamentiBeneficiarioObj.ImportoAmmessoContr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO_CONTR"]);
			VpagamentiBeneficiarioObj.ImportoNonammContrNonresp = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_NONAMM_CONTR_NONRESP"]);
			VpagamentiBeneficiarioObj.SpesaTecnicaAmmessaContr = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SPESA_TECNICA_AMMESSA_CONTR"]);
			VpagamentiBeneficiarioObj.CostituisceVariante = new SiarLibrary.NullTypes.BoolNT(db.DataReader["COSTITUISCE_VARIANTE"]);
			VpagamentiBeneficiarioObj.LavoriInEconomia = new SiarLibrary.NullTypes.BoolNT(db.DataReader["LAVORI_IN_ECONOMIA"]);
			VpagamentiBeneficiarioObj.CodRiduzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RIDUZIONE"]);
			VpagamentiBeneficiarioObj.MotivazioneRiduzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["MOTIVAZIONE_RIDUZIONE"]);
			VpagamentiBeneficiarioObj.CodRiduzioneContr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RIDUZIONE_CONTR"]);
			VpagamentiBeneficiarioObj.MotivazioneRiduzioneContr = new SiarLibrary.NullTypes.IntNT(db.DataReader["MOTIVAZIONE_RIDUZIONE_CONTR"]);
			VpagamentiBeneficiarioObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			VpagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VpagamentiBeneficiarioObj.IsDirty = false;
			VpagamentiBeneficiarioObj.IsPersistent = true;
			return VpagamentiBeneficiarioObj;
		}

		//Find Select

		public static VpagamentiBeneficiarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuotaContributoAmmessoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT NumeroDoctrasportoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataDoctrasportoEqualThis, SiarLibrary.NullTypes.DecimalNT ImponibileEqualThis, SiarLibrary.NullTypes.DecimalNT IvaEqualThis, 
SiarLibrary.NullTypes.DecimalNT AltriOneriEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CfFornitoreEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneFornitoreEqualThis, SiarLibrary.NullTypes.StringNT TipoGiustificativoEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaRichiestaEqualThis, 
SiarLibrary.NullTypes.BoolNT SpesaTecnicaAmmessaEqualThis, SiarLibrary.NullTypes.BoolNT IvaNonRecuperabileEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoNonammNonrespEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoAmmessoContrEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoNonammContrNonrespEqualThis, SiarLibrary.NullTypes.BoolNT SpesaTecnicaAmmessaContrEqualThis, 
SiarLibrary.NullTypes.BoolNT CostituisceVarianteEqualThis, SiarLibrary.NullTypes.BoolNT LavoriInEconomiaEqualThis, SiarLibrary.NullTypes.StringNT CodRiduzioneEqualThis, 
SiarLibrary.NullTypes.IntNT MotivazioneRiduzioneEqualThis, SiarLibrary.NullTypes.StringNT CodRiduzioneContrEqualThis, SiarLibrary.NullTypes.IntNT MotivazioneRiduzioneContrEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionObj = new VpagamentiBeneficiarioCollection();

			IDbCommand findCmd = db.InitCmd("Zvpagamentibeneficiariofindselect", new string[] {"IdPagamentoBeneficiarioequalthis", "IdPagamentoRichiestoequalthis", "IdGiustificativoequalthis", 
"ImportoRichiestoequalthis", "ImportoAmmessoequalthis", "ContributoAmmessoequalthis", 
"QuotaContributoAmmessoequalthis", "IdProgettoequalthis", "Numeroequalthis", 
"CodTipoequalthis", "Dataequalthis", "NumeroDoctrasportoequalthis", 
"DataDoctrasportoequalthis", "Imponibileequalthis", "Ivaequalthis", 
"AltriOneriequalthis", "Descrizioneequalthis", "CfFornitoreequalthis", 
"DescrizioneFornitoreequalthis", "TipoGiustificativoequalthis", "SpesaTecnicaRichiestaequalthis", 
"SpesaTecnicaAmmessaequalthis", "IvaNonRecuperabileequalthis", "ImportoNonammNonrespequalthis", 
"ImportoAmmessoContrequalthis", "ImportoNonammContrNonrespequalthis", "SpesaTecnicaAmmessaContrequalthis", 
"CostituisceVarianteequalthis", "LavoriInEconomiaequalthis", "CodRiduzioneequalthis", 
"MotivazioneRiduzioneequalthis", "CodRiduzioneContrequalthis", "MotivazioneRiduzioneContrequalthis", 
"IdFileequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"decimal", "int", "string", 
"string", "DateTime", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "string", "string", 
"string", "string", "bool", 
"bool", "bool", "decimal", 
"decimal", "decimal", "bool", 
"bool", "bool", "string", 
"int", "string", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaContributoAmmessoequalthis", QuotaContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroDoctrasportoequalthis", NumeroDoctrasportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataDoctrasportoequalthis", DataDoctrasportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Imponibileequalthis", ImponibileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ivaequalthis", IvaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AltriOneriequalthis", AltriOneriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfFornitoreequalthis", CfFornitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneFornitoreequalthis", DescrizioneFornitoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoGiustificativoequalthis", TipoGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaRichiestaequalthis", SpesaTecnicaRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaAmmessaequalthis", SpesaTecnicaAmmessaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IvaNonRecuperabileequalthis", IvaNonRecuperabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoNonammNonrespequalthis", ImportoNonammNonrespEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoContrequalthis", ImportoAmmessoContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoNonammContrNonrespequalthis", ImportoNonammContrNonrespEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaTecnicaAmmessaContrequalthis", SpesaTecnicaAmmessaContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CostituisceVarianteequalthis", CostituisceVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "LavoriInEconomiaequalthis", LavoriInEconomiaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRiduzioneequalthis", CodRiduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRiduzioneequalthis", MotivazioneRiduzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRiduzioneContrequalthis", CodRiduzioneContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRiduzioneContrequalthis", MotivazioneRiduzioneContrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			VpagamentiBeneficiario VpagamentiBeneficiarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VpagamentiBeneficiarioObj = GetFromDatareader(db);
				VpagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VpagamentiBeneficiarioObj.IsDirty = false;
				VpagamentiBeneficiarioObj.IsPersistent = true;
				VpagamentiBeneficiarioCollectionObj.Add(VpagamentiBeneficiarioObj);
			}
			db.Close();
			return VpagamentiBeneficiarioCollectionObj;
		}

		//Find Find

		public static VpagamentiBeneficiarioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionObj = new VpagamentiBeneficiarioCollection();

			IDbCommand findCmd = db.InitCmd("Zvpagamentibeneficiariofindfind", new string[] {"IdPagamentoBeneficiarioequalthis", "IdPagamentoRichiestoequalthis", "IdGiustificativoequalthis", 
"IdProgettoequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoBeneficiarioequalthis", IdPagamentoBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			VpagamentiBeneficiario VpagamentiBeneficiarioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VpagamentiBeneficiarioObj = GetFromDatareader(db);
				VpagamentiBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VpagamentiBeneficiarioObj.IsDirty = false;
				VpagamentiBeneficiarioObj.IsPersistent = true;
				VpagamentiBeneficiarioCollectionObj.Add(VpagamentiBeneficiarioObj);
			}
			db.Close();
			return VpagamentiBeneficiarioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VpagamentiBeneficiarioCollectionProvider:IVpagamentiBeneficiarioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VpagamentiBeneficiarioCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VpagamentiBeneficiario
		protected VpagamentiBeneficiarioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VpagamentiBeneficiarioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VpagamentiBeneficiarioCollection();
		}

		//Costruttore 2: popola la collection
		public VpagamentiBeneficiarioCollectionProvider(IntNT IdpagamentobeneficiarioEqualThis, IntNT IdpagamentorichiestoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpagamentobeneficiarioEqualThis, IdpagamentorichiestoEqualThis, IdgiustificativoEqualThis, 
IdprogettoEqualThis);
		}

		//Costruttore3: ha in input vpagamentibeneficiarioCollectionObj - non popola la collection
		public VpagamentiBeneficiarioCollectionProvider(VpagamentiBeneficiarioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VpagamentiBeneficiarioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VpagamentiBeneficiarioCollection();
		}

		//Get e Set
		public VpagamentiBeneficiarioCollection CollectionObj
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
		public VpagamentiBeneficiarioCollection Select(IntNT IdpagamentobeneficiarioEqualThis, IntNT IdpagamentorichiestoEqualThis, IntNT IdgiustificativoEqualThis, 
DecimalNT ImportorichiestoEqualThis, DecimalNT ImportoammessoEqualThis, DecimalNT ContributoammessoEqualThis, 
DecimalNT QuotacontributoammessoEqualThis, IntNT IdprogettoEqualThis, StringNT NumeroEqualThis, 
StringNT CodtipoEqualThis, DatetimeNT DataEqualThis, StringNT NumerodoctrasportoEqualThis, 
DatetimeNT DatadoctrasportoEqualThis, DecimalNT ImponibileEqualThis, DecimalNT IvaEqualThis, 
DecimalNT AltrioneriEqualThis, StringNT DescrizioneEqualThis, StringNT CffornitoreEqualThis, 
StringNT DescrizionefornitoreEqualThis, StringNT TipogiustificativoEqualThis, BoolNT SpesatecnicarichiestaEqualThis, 
BoolNT SpesatecnicaammessaEqualThis, BoolNT IvanonrecuperabileEqualThis, DecimalNT ImportononammnonrespEqualThis, 
DecimalNT ImportoammessocontrEqualThis, DecimalNT ImportononammcontrnonrespEqualThis, BoolNT SpesatecnicaammessacontrEqualThis, 
BoolNT CostituiscevarianteEqualThis, BoolNT LavoriineconomiaEqualThis, StringNT CodriduzioneEqualThis, 
IntNT MotivazioneriduzioneEqualThis, StringNT CodriduzionecontrEqualThis, IntNT MotivazioneriduzionecontrEqualThis, 
IntNT IdfileEqualThis)
		{
			VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionTemp = VpagamentiBeneficiarioDAL.Select(_dbProviderObj, IdpagamentobeneficiarioEqualThis, IdpagamentorichiestoEqualThis, IdgiustificativoEqualThis, 
ImportorichiestoEqualThis, ImportoammessoEqualThis, ContributoammessoEqualThis, 
QuotacontributoammessoEqualThis, IdprogettoEqualThis, NumeroEqualThis, 
CodtipoEqualThis, DataEqualThis, NumerodoctrasportoEqualThis, 
DatadoctrasportoEqualThis, ImponibileEqualThis, IvaEqualThis, 
AltrioneriEqualThis, DescrizioneEqualThis, CffornitoreEqualThis, 
DescrizionefornitoreEqualThis, TipogiustificativoEqualThis, SpesatecnicarichiestaEqualThis, 
SpesatecnicaammessaEqualThis, IvanonrecuperabileEqualThis, ImportononammnonrespEqualThis, 
ImportoammessocontrEqualThis, ImportononammcontrnonrespEqualThis, SpesatecnicaammessacontrEqualThis, 
CostituiscevarianteEqualThis, LavoriineconomiaEqualThis, CodriduzioneEqualThis, 
MotivazioneriduzioneEqualThis, CodriduzionecontrEqualThis, MotivazioneriduzionecontrEqualThis, 
IdfileEqualThis);
			return VpagamentiBeneficiarioCollectionTemp;
		}

		//Find: popola la collection
		public VpagamentiBeneficiarioCollection Find(IntNT IdpagamentobeneficiarioEqualThis, IntNT IdpagamentorichiestoEqualThis, IntNT IdgiustificativoEqualThis, 
IntNT IdprogettoEqualThis)
		{
			VpagamentiBeneficiarioCollection VpagamentiBeneficiarioCollectionTemp = VpagamentiBeneficiarioDAL.Find(_dbProviderObj, IdpagamentobeneficiarioEqualThis, IdpagamentorichiestoEqualThis, IdgiustificativoEqualThis, 
IdprogettoEqualThis);
			return VpagamentiBeneficiarioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPAGAMENTI_BENEFICIARIO>
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
    <Find OrderBy="ORDER BY ">
      <ID_PAGAMENTO_BENEFICIARIO>Equal</ID_PAGAMENTO_BENEFICIARIO>
      <ID_PAGAMENTO_RICHIESTO>Equal</ID_PAGAMENTO_RICHIESTO>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vPAGAMENTI_BENEFICIARIO>
*/
