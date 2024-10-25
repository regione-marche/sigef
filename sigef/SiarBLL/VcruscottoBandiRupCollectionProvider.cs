using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoBandiRup
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcruscottoBandiRup: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _DescrizioneBando;
		private NullTypes.StringNT _CodEnteBando;
		private NullTypes.StringNT _EnteBando;
		private NullTypes.IntNT _IdRup;
		private NullTypes.StringNT _Rup;
		private NullTypes.StringNT _CfRup;
		private NullTypes.DatetimeNT _DataAperturaBando;
		private NullTypes.DatetimeNT _DataScadenzaBando;
		private NullTypes.StringNT _CodStatoBando;
		private NullTypes.StringNT _StatoBando;
		private NullTypes.StringNT _SegnaturaBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodStatoProgetto;
		private NullTypes.StringNT _StatoProgetto;
		private NullTypes.StringNT _SegnaturaProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Impresa;
		private NullTypes.StringNT _CfImpresa;
		private NullTypes.StringNT _CuaaImpresa;
		private NullTypes.IntNT _IdIstruttoreProgetto;
		private NullTypes.StringNT _IstruttoreProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _SegnaturaDomandaPagamento;
		private NullTypes.StringNT _SegnaturaSecondaApprovazioneDomandaPagamento;
		private NullTypes.StringNT _CodFaseDomandaPagamento;
		private NullTypes.StringNT _FaseDomandaPagamento;
		private NullTypes.BoolNT _Annullata;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.IntNT _IdIstruttoreDomandaPagamento;
		private NullTypes.StringNT _IstruttoreDomandaPagamento;
		private NullTypes.DecimalNT _ImportoRichiesto;
		private NullTypes.DecimalNT _ContributoRichiesto;
		private NullTypes.DecimalNT _ImportoAmmesso;
		private NullTypes.DecimalNT _ContributoAmmesso;
		private NullTypes.BoolNT _InIntegrazione;
		private NullTypes.BoolNT _FirmaPredispostaRup;


		//Costruttore
		public VcruscottoBandiRup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:DESCRIZIONE_BANDO
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneBando
		{
			get { return _DescrizioneBando; }
			set {
				if (DescrizioneBando != value)
				{
					_DescrizioneBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE_BANDO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteBando
		{
			get { return _CodEnteBando; }
			set {
				if (CodEnteBando != value)
				{
					_CodEnteBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE_BANDO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT EnteBando
		{
			get { return _EnteBando; }
			set {
				if (EnteBando != value)
				{
					_EnteBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RUP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRup
		{
			get { return _IdRup; }
			set {
				if (IdRup != value)
				{
					_IdRup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUP
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Rup
		{
			get { return _Rup; }
			set {
				if (Rup != value)
				{
					_Rup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_RUP
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfRup
		{
			get { return _CfRup; }
			set {
				if (CfRup != value)
				{
					_CfRup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_APERTURA_BANDO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAperturaBando
		{
			get { return _DataAperturaBando; }
			set {
				if (DataAperturaBando != value)
				{
					_DataAperturaBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_SCADENZA_BANDO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenzaBando
		{
			get { return _DataScadenzaBando; }
			set {
				if (DataScadenzaBando != value)
				{
					_DataScadenzaBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO_BANDO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStatoBando
		{
			get { return _CodStatoBando; }
			set {
				if (CodStatoBando != value)
				{
					_CodStatoBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_BANDO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT StatoBando
		{
			get { return _StatoBando; }
			set {
				if (StatoBando != value)
				{
					_StatoBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_BANDO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaBando
		{
			get { return _SegnaturaBando; }
			set {
				if (SegnaturaBando != value)
				{
					_SegnaturaBando = value;
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
		/// Corrisponde al campo:COD_STATO_PROGETTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStatoProgetto
		{
			get { return _CodStatoProgetto; }
			set {
				if (CodStatoProgetto != value)
				{
					_CodStatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_PROGETTO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT StatoProgetto
		{
			get { return _StatoProgetto; }
			set {
				if (StatoProgetto != value)
				{
					_StatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_PROGETTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaProgetto
		{
			get { return _SegnaturaProgetto; }
			set {
				if (SegnaturaProgetto != value)
				{
					_SegnaturaProgetto = value;
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
		/// Corrisponde al campo:IMPRESA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Impresa
		{
			get { return _Impresa; }
			set {
				if (Impresa != value)
				{
					_Impresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfImpresa
		{
			get { return _CfImpresa; }
			set {
				if (CfImpresa != value)
				{
					_CfImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaImpresa
		{
			get { return _CuaaImpresa; }
			set {
				if (CuaaImpresa != value)
				{
					_CuaaImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ISTRUTTORE_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstruttoreProgetto
		{
			get { return _IdIstruttoreProgetto; }
			set {
				if (IdIstruttoreProgetto != value)
				{
					_IdIstruttoreProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE_PROGETTO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT IstruttoreProgetto
		{
			get { return _IstruttoreProgetto; }
			set {
				if (IstruttoreProgetto != value)
				{
					_IstruttoreProgetto = value;
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
		/// Corrisponde al campo:SEGNATURA_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaDomandaPagamento
		{
			get { return _SegnaturaDomandaPagamento; }
			set {
				if (SegnaturaDomandaPagamento != value)
				{
					_SegnaturaDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaSecondaApprovazioneDomandaPagamento
		{
			get { return _SegnaturaSecondaApprovazioneDomandaPagamento; }
			set {
				if (SegnaturaSecondaApprovazioneDomandaPagamento != value)
				{
					_SegnaturaSecondaApprovazioneDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE_DOMANDA_PAGAMENTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFaseDomandaPagamento
		{
			get { return _CodFaseDomandaPagamento; }
			set {
				if (CodFaseDomandaPagamento != value)
				{
					_CodFaseDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT FaseDomandaPagamento
		{
			get { return _FaseDomandaPagamento; }
			set {
				if (FaseDomandaPagamento != value)
				{
					_FaseDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNULLATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Annullata
		{
			get { return _Annullata; }
			set {
				if (Annullata != value)
				{
					_Annullata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:APPROVATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Approvata
		{
			get { return _Approvata; }
			set {
				if (Approvata != value)
				{
					_Approvata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ISTRUTTORE_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstruttoreDomandaPagamento
		{
			get { return _IdIstruttoreDomandaPagamento; }
			set {
				if (IdIstruttoreDomandaPagamento != value)
				{
					_IdIstruttoreDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE_DOMANDA_PAGAMENTO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT IstruttoreDomandaPagamento
		{
			get { return _IstruttoreDomandaPagamento; }
			set {
				if (IstruttoreDomandaPagamento != value)
				{
					_IstruttoreDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_RICHIESTO
		/// Tipo sul db:DECIMAL(38,2)
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
		/// Corrisponde al campo:CONTRIBUTO_RICHIESTO
		/// Tipo sul db:DECIMAL(38,2)
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
		/// Corrisponde al campo:IMPORTO_AMMESSO
		/// Tipo sul db:DECIMAL(38,2)
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
		/// Tipo sul db:DECIMAL(38,2)
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
		/// Corrisponde al campo:IN_INTEGRAZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InIntegrazione
		{
			get { return _InIntegrazione; }
			set {
				if (InIntegrazione != value)
				{
					_InIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FIRMA_PREDISPOSTA_RUP
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FirmaPredispostaRup
		{
			get { return _FirmaPredispostaRup; }
			set {
				if (FirmaPredispostaRup != value)
				{
					_FirmaPredispostaRup = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoBandiRupCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoBandiRupCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcruscottoBandiRupCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcruscottoBandiRup) info.GetValue(i.ToString(),typeof(VcruscottoBandiRup)));
			}
		}

		//Costruttore
		public VcruscottoBandiRupCollection()
		{
			this.ItemType = typeof(VcruscottoBandiRup);
		}

		//Get e Set
		public new VcruscottoBandiRup this[int index]
		{
			get { return (VcruscottoBandiRup)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcruscottoBandiRupCollection GetChanges()
		{
			return (VcruscottoBandiRupCollection) base.GetChanges();
		}

		//Add
		public int Add(VcruscottoBandiRup VcruscottoBandiRupObj)
		{
			return base.Add(VcruscottoBandiRupObj);
		}

		//AddCollection
		public void AddCollection(VcruscottoBandiRupCollection VcruscottoBandiRupCollectionObj)
		{
			foreach (VcruscottoBandiRup VcruscottoBandiRupObj in VcruscottoBandiRupCollectionObj)
				this.Add(VcruscottoBandiRupObj);
		}

		//Insert
		public void Insert(int index, VcruscottoBandiRup VcruscottoBandiRupObj)
		{
			base.Insert(index, VcruscottoBandiRupObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcruscottoBandiRupCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.StringNT CodEnteBandoEqualThis, 
NullTypes.StringNT EnteBandoEqualThis, NullTypes.IntNT IdRupEqualThis, NullTypes.StringNT RupEqualThis, 
NullTypes.StringNT CfRupEqualThis, NullTypes.DatetimeNT DataAperturaBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis, 
NullTypes.StringNT CodStatoBandoEqualThis, NullTypes.StringNT StatoBandoEqualThis, NullTypes.StringNT SegnaturaBandoEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis, 
NullTypes.StringNT SegnaturaProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT ImpresaEqualThis, 
NullTypes.StringNT CfImpresaEqualThis, NullTypes.StringNT CuaaImpresaEqualThis, NullTypes.IntNT IdIstruttoreProgettoEqualThis, 
NullTypes.StringNT IstruttoreProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT SegnaturaDomandaPagamentoEqualThis, 
NullTypes.StringNT SegnaturaSecondaApprovazioneDomandaPagamentoEqualThis, NullTypes.StringNT CodFaseDomandaPagamentoEqualThis, NullTypes.StringNT FaseDomandaPagamentoEqualThis, 
NullTypes.BoolNT AnnullataEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.IntNT IdIstruttoreDomandaPagamentoEqualThis, 
NullTypes.StringNT IstruttoreDomandaPagamentoEqualThis, NullTypes.DecimalNT ImportoRichiestoEqualThis, NullTypes.DecimalNT ContributoRichiestoEqualThis, 
NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis, 
NullTypes.BoolNT FirmaPredispostaRupEqualThis)
		{
			VcruscottoBandiRupCollection VcruscottoBandiRupCollectionTemp = new VcruscottoBandiRupCollection();
			foreach (VcruscottoBandiRup VcruscottoBandiRupItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VcruscottoBandiRupItem.IdBando != null) && (VcruscottoBandiRupItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoBandiRupItem.DescrizioneBando != null) && (VcruscottoBandiRupItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((CodEnteBandoEqualThis == null) || ((VcruscottoBandiRupItem.CodEnteBando != null) && (VcruscottoBandiRupItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) && 
((EnteBandoEqualThis == null) || ((VcruscottoBandiRupItem.EnteBando != null) && (VcruscottoBandiRupItem.EnteBando.Value == EnteBandoEqualThis.Value))) && ((IdRupEqualThis == null) || ((VcruscottoBandiRupItem.IdRup != null) && (VcruscottoBandiRupItem.IdRup.Value == IdRupEqualThis.Value))) && ((RupEqualThis == null) || ((VcruscottoBandiRupItem.Rup != null) && (VcruscottoBandiRupItem.Rup.Value == RupEqualThis.Value))) && 
((CfRupEqualThis == null) || ((VcruscottoBandiRupItem.CfRup != null) && (VcruscottoBandiRupItem.CfRup.Value == CfRupEqualThis.Value))) && ((DataAperturaBandoEqualThis == null) || ((VcruscottoBandiRupItem.DataAperturaBando != null) && (VcruscottoBandiRupItem.DataAperturaBando.Value == DataAperturaBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoBandiRupItem.DataScadenzaBando != null) && (VcruscottoBandiRupItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) && 
((CodStatoBandoEqualThis == null) || ((VcruscottoBandiRupItem.CodStatoBando != null) && (VcruscottoBandiRupItem.CodStatoBando.Value == CodStatoBandoEqualThis.Value))) && ((StatoBandoEqualThis == null) || ((VcruscottoBandiRupItem.StatoBando != null) && (VcruscottoBandiRupItem.StatoBando.Value == StatoBandoEqualThis.Value))) && ((SegnaturaBandoEqualThis == null) || ((VcruscottoBandiRupItem.SegnaturaBando != null) && (VcruscottoBandiRupItem.SegnaturaBando.Value == SegnaturaBandoEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((VcruscottoBandiRupItem.IdProgetto != null) && (VcruscottoBandiRupItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoProgettoEqualThis == null) || ((VcruscottoBandiRupItem.CodStatoProgetto != null) && (VcruscottoBandiRupItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VcruscottoBandiRupItem.StatoProgetto != null) && (VcruscottoBandiRupItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) && 
((SegnaturaProgettoEqualThis == null) || ((VcruscottoBandiRupItem.SegnaturaProgetto != null) && (VcruscottoBandiRupItem.SegnaturaProgetto.Value == SegnaturaProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoBandiRupItem.IdImpresa != null) && (VcruscottoBandiRupItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((ImpresaEqualThis == null) || ((VcruscottoBandiRupItem.Impresa != null) && (VcruscottoBandiRupItem.Impresa.Value == ImpresaEqualThis.Value))) && 
((CfImpresaEqualThis == null) || ((VcruscottoBandiRupItem.CfImpresa != null) && (VcruscottoBandiRupItem.CfImpresa.Value == CfImpresaEqualThis.Value))) && ((CuaaImpresaEqualThis == null) || ((VcruscottoBandiRupItem.CuaaImpresa != null) && (VcruscottoBandiRupItem.CuaaImpresa.Value == CuaaImpresaEqualThis.Value))) && ((IdIstruttoreProgettoEqualThis == null) || ((VcruscottoBandiRupItem.IdIstruttoreProgetto != null) && (VcruscottoBandiRupItem.IdIstruttoreProgetto.Value == IdIstruttoreProgettoEqualThis.Value))) && 
((IstruttoreProgettoEqualThis == null) || ((VcruscottoBandiRupItem.IstruttoreProgetto != null) && (VcruscottoBandiRupItem.IstruttoreProgetto.Value == IstruttoreProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.IdDomandaPagamento != null) && (VcruscottoBandiRupItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((SegnaturaDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.SegnaturaDomandaPagamento != null) && (VcruscottoBandiRupItem.SegnaturaDomandaPagamento.Value == SegnaturaDomandaPagamentoEqualThis.Value))) && 
((SegnaturaSecondaApprovazioneDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.SegnaturaSecondaApprovazioneDomandaPagamento != null) && (VcruscottoBandiRupItem.SegnaturaSecondaApprovazioneDomandaPagamento.Value == SegnaturaSecondaApprovazioneDomandaPagamentoEqualThis.Value))) && ((CodFaseDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.CodFaseDomandaPagamento != null) && (VcruscottoBandiRupItem.CodFaseDomandaPagamento.Value == CodFaseDomandaPagamentoEqualThis.Value))) && ((FaseDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.FaseDomandaPagamento != null) && (VcruscottoBandiRupItem.FaseDomandaPagamento.Value == FaseDomandaPagamentoEqualThis.Value))) && 
((AnnullataEqualThis == null) || ((VcruscottoBandiRupItem.Annullata != null) && (VcruscottoBandiRupItem.Annullata.Value == AnnullataEqualThis.Value))) && ((ApprovataEqualThis == null) || ((VcruscottoBandiRupItem.Approvata != null) && (VcruscottoBandiRupItem.Approvata.Value == ApprovataEqualThis.Value))) && ((IdIstruttoreDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.IdIstruttoreDomandaPagamento != null) && (VcruscottoBandiRupItem.IdIstruttoreDomandaPagamento.Value == IdIstruttoreDomandaPagamentoEqualThis.Value))) && 
((IstruttoreDomandaPagamentoEqualThis == null) || ((VcruscottoBandiRupItem.IstruttoreDomandaPagamento != null) && (VcruscottoBandiRupItem.IstruttoreDomandaPagamento.Value == IstruttoreDomandaPagamentoEqualThis.Value))) && ((ImportoRichiestoEqualThis == null) || ((VcruscottoBandiRupItem.ImportoRichiesto != null) && (VcruscottoBandiRupItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((VcruscottoBandiRupItem.ContributoRichiesto != null) && (VcruscottoBandiRupItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && 
((ImportoAmmessoEqualThis == null) || ((VcruscottoBandiRupItem.ImportoAmmesso != null) && (VcruscottoBandiRupItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((VcruscottoBandiRupItem.ContributoAmmesso != null) && (VcruscottoBandiRupItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((VcruscottoBandiRupItem.InIntegrazione != null) && (VcruscottoBandiRupItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && 
((FirmaPredispostaRupEqualThis == null) || ((VcruscottoBandiRupItem.FirmaPredispostaRup != null) && (VcruscottoBandiRupItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))))
				{
					VcruscottoBandiRupCollectionTemp.Add(VcruscottoBandiRupItem);
				}
			}
			return VcruscottoBandiRupCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcruscottoBandiRupDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcruscottoBandiRupDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcruscottoBandiRup GetFromDatareader(DbProvider db)
		{
			VcruscottoBandiRup VcruscottoBandiRupObj = new VcruscottoBandiRup();
			VcruscottoBandiRupObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcruscottoBandiRupObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
			VcruscottoBandiRupObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
			VcruscottoBandiRupObj.EnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE_BANDO"]);
			VcruscottoBandiRupObj.IdRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RUP"]);
			VcruscottoBandiRupObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
			VcruscottoBandiRupObj.CfRup = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RUP"]);
			VcruscottoBandiRupObj.DataAperturaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA_BANDO"]);
			VcruscottoBandiRupObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
			VcruscottoBandiRupObj.CodStatoBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_BANDO"]);
			VcruscottoBandiRupObj.StatoBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_BANDO"]);
			VcruscottoBandiRupObj.SegnaturaBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_BANDO"]);
			VcruscottoBandiRupObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VcruscottoBandiRupObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
			VcruscottoBandiRupObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
			VcruscottoBandiRupObj.SegnaturaProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_PROGETTO"]);
			VcruscottoBandiRupObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VcruscottoBandiRupObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
			VcruscottoBandiRupObj.CfImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_IMPRESA"]);
			VcruscottoBandiRupObj.CuaaImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA"]);
			VcruscottoBandiRupObj.IdIstruttoreProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTRUTTORE_PROGETTO"]);
			VcruscottoBandiRupObj.IstruttoreProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE_PROGETTO"]);
			VcruscottoBandiRupObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.SegnaturaDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.SegnaturaSecondaApprovazioneDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.CodFaseDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.FaseDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
			VcruscottoBandiRupObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			VcruscottoBandiRupObj.IdIstruttoreDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTRUTTORE_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.IstruttoreDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE_DOMANDA_PAGAMENTO"]);
			VcruscottoBandiRupObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
			VcruscottoBandiRupObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
			VcruscottoBandiRupObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
			VcruscottoBandiRupObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
			VcruscottoBandiRupObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
			VcruscottoBandiRupObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
			VcruscottoBandiRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcruscottoBandiRupObj.IsDirty = false;
			VcruscottoBandiRupObj.IsPersistent = true;
			return VcruscottoBandiRupObj;
		}

		//Find Select

		public static VcruscottoBandiRupCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, 
SiarLibrary.NullTypes.StringNT EnteBandoEqualThis, SiarLibrary.NullTypes.IntNT IdRupEqualThis, SiarLibrary.NullTypes.StringNT RupEqualThis, 
SiarLibrary.NullTypes.StringNT CfRupEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAperturaBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoBandoEqualThis, SiarLibrary.NullTypes.StringNT StatoBandoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaBandoEqualThis, 
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT ImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CfImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis, 
SiarLibrary.NullTypes.StringNT IstruttoreProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaSecondaApprovazioneDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT FaseDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.StringNT IstruttoreDomandaPagamentoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis)

		{

			VcruscottoBandiRupCollection VcruscottoBandiRupCollectionObj = new VcruscottoBandiRupCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottobandirupfindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "CodEnteBandoequalthis", 
"EnteBandoequalthis", "IdRupequalthis", "Rupequalthis", 
"CfRupequalthis", "DataAperturaBandoequalthis", "DataScadenzaBandoequalthis", 
"CodStatoBandoequalthis", "StatoBandoequalthis", "SegnaturaBandoequalthis", 
"IdProgettoequalthis", "CodStatoProgettoequalthis", "StatoProgettoequalthis", 
"SegnaturaProgettoequalthis", "IdImpresaequalthis", "Impresaequalthis", 
"CfImpresaequalthis", "CuaaImpresaequalthis", "IdIstruttoreProgettoequalthis", 
"IstruttoreProgettoequalthis", "IdDomandaPagamentoequalthis", "SegnaturaDomandaPagamentoequalthis", 
"SegnaturaSecondaApprovazioneDomandaPagamentoequalthis", "CodFaseDomandaPagamentoequalthis", "FaseDomandaPagamentoequalthis", 
"Annullataequalthis", "Approvataequalthis", "IdIstruttoreDomandaPagamentoequalthis", 
"IstruttoreDomandaPagamentoequalthis", "ImportoRichiestoequalthis", "ContributoRichiestoequalthis", 
"ImportoAmmessoequalthis", "ContributoAmmessoequalthis", "InIntegrazioneequalthis", 
"FirmaPredispostaRupequalthis"}, new string[] {"int", "string", "string", 
"string", "int", "string", 
"string", "DateTime", "DateTime", 
"string", "string", "string", 
"int", "string", "string", 
"string", "int", "string", 
"string", "string", "int", 
"string", "int", "string", 
"string", "string", "string", 
"bool", "bool", "int", 
"string", "decimal", "decimal", 
"decimal", "decimal", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EnteBandoequalthis", EnteBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rupequalthis", RupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfRupequalthis", CfRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAperturaBandoequalthis", DataAperturaBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoBandoequalthis", CodStatoBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoBandoequalthis", StatoBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaBandoequalthis", SegnaturaBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaProgettoequalthis", SegnaturaProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfImpresaequalthis", CfImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaImpresaequalthis", CuaaImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IstruttoreProgettoequalthis", IstruttoreProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaDomandaPagamentoequalthis", SegnaturaDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaSecondaApprovazioneDomandaPagamentoequalthis", SegnaturaSecondaApprovazioneDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseDomandaPagamentoequalthis", CodFaseDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FaseDomandaPagamentoequalthis", FaseDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreDomandaPagamentoequalthis", IdIstruttoreDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IstruttoreDomandaPagamentoequalthis", IstruttoreDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
			VcruscottoBandiRup VcruscottoBandiRupObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoBandiRupObj = GetFromDatareader(db);
				VcruscottoBandiRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoBandiRupObj.IsDirty = false;
				VcruscottoBandiRupObj.IsPersistent = true;
				VcruscottoBandiRupCollectionObj.Add(VcruscottoBandiRupObj);
			}
			db.Close();
			return VcruscottoBandiRupCollectionObj;
		}

		//Find Find

		public static VcruscottoBandiRupCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRupEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreDomandaPagamentoEqualThis)

		{

			VcruscottoBandiRupCollection VcruscottoBandiRupCollectionObj = new VcruscottoBandiRupCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottobandirupfindfind", new string[] {"IdRupequalthis", "IdIstruttoreProgettoequalthis", "IdIstruttoreDomandaPagamentoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreDomandaPagamentoequalthis", IdIstruttoreDomandaPagamentoEqualThis);
			VcruscottoBandiRup VcruscottoBandiRupObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoBandiRupObj = GetFromDatareader(db);
				VcruscottoBandiRupObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoBandiRupObj.IsDirty = false;
				VcruscottoBandiRupObj.IsPersistent = true;
				VcruscottoBandiRupCollectionObj.Add(VcruscottoBandiRupObj);
			}
			db.Close();
			return VcruscottoBandiRupCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcruscottoBandiRupCollectionProvider:IVcruscottoBandiRupProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoBandiRupCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcruscottoBandiRup
		protected VcruscottoBandiRupCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcruscottoBandiRupCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcruscottoBandiRupCollection();
		}

		//Costruttore 2: popola la collection
		public VcruscottoBandiRupCollectionProvider(IntNT IdrupEqualThis, IntNT IdistruttoreprogettoEqualThis, IntNT IdistruttoredomandapagamentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrupEqualThis, IdistruttoreprogettoEqualThis, IdistruttoredomandapagamentoEqualThis);
		}

		//Costruttore3: ha in input vcruscottobandirupCollectionObj - non popola la collection
		public VcruscottoBandiRupCollectionProvider(VcruscottoBandiRupCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcruscottoBandiRupCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcruscottoBandiRupCollection();
		}

		//Get e Set
		public VcruscottoBandiRupCollection CollectionObj
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
		public VcruscottoBandiRupCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, StringNT CodentebandoEqualThis, 
StringNT EntebandoEqualThis, IntNT IdrupEqualThis, StringNT RupEqualThis, 
StringNT CfrupEqualThis, DatetimeNT DataaperturabandoEqualThis, DatetimeNT DatascadenzabandoEqualThis, 
StringNT CodstatobandoEqualThis, StringNT StatobandoEqualThis, StringNT SegnaturabandoEqualThis, 
IntNT IdprogettoEqualThis, StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, 
StringNT SegnaturaprogettoEqualThis, IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis, 
StringNT CfimpresaEqualThis, StringNT CuaaimpresaEqualThis, IntNT IdistruttoreprogettoEqualThis, 
StringNT IstruttoreprogettoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT SegnaturadomandapagamentoEqualThis, 
StringNT SegnaturasecondaapprovazionedomandapagamentoEqualThis, StringNT CodfasedomandapagamentoEqualThis, StringNT FasedomandapagamentoEqualThis, 
BoolNT AnnullataEqualThis, BoolNT ApprovataEqualThis, IntNT IdistruttoredomandapagamentoEqualThis, 
StringNT IstruttoredomandapagamentoEqualThis, DecimalNT ImportorichiestoEqualThis, DecimalNT ContributorichiestoEqualThis, 
DecimalNT ImportoammessoEqualThis, DecimalNT ContributoammessoEqualThis, BoolNT InintegrazioneEqualThis, 
BoolNT FirmapredispostarupEqualThis)
		{
			VcruscottoBandiRupCollection VcruscottoBandiRupCollectionTemp = VcruscottoBandiRupDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, CodentebandoEqualThis, 
EntebandoEqualThis, IdrupEqualThis, RupEqualThis, 
CfrupEqualThis, DataaperturabandoEqualThis, DatascadenzabandoEqualThis, 
CodstatobandoEqualThis, StatobandoEqualThis, SegnaturabandoEqualThis, 
IdprogettoEqualThis, CodstatoprogettoEqualThis, StatoprogettoEqualThis, 
SegnaturaprogettoEqualThis, IdimpresaEqualThis, ImpresaEqualThis, 
CfimpresaEqualThis, CuaaimpresaEqualThis, IdistruttoreprogettoEqualThis, 
IstruttoreprogettoEqualThis, IddomandapagamentoEqualThis, SegnaturadomandapagamentoEqualThis, 
SegnaturasecondaapprovazionedomandapagamentoEqualThis, CodfasedomandapagamentoEqualThis, FasedomandapagamentoEqualThis, 
AnnullataEqualThis, ApprovataEqualThis, IdistruttoredomandapagamentoEqualThis, 
IstruttoredomandapagamentoEqualThis, ImportorichiestoEqualThis, ContributorichiestoEqualThis, 
ImportoammessoEqualThis, ContributoammessoEqualThis, InintegrazioneEqualThis, 
FirmapredispostarupEqualThis);
			return VcruscottoBandiRupCollectionTemp;
		}

		//Find: popola la collection
		public VcruscottoBandiRupCollection Find(IntNT IdrupEqualThis, IntNT IdistruttoreprogettoEqualThis, IntNT IdistruttoredomandapagamentoEqualThis)
		{
			VcruscottoBandiRupCollection VcruscottoBandiRupCollectionTemp = VcruscottoBandiRupDAL.Find(_dbProviderObj, IdrupEqualThis, IdistruttoreprogettoEqualThis, IdistruttoredomandapagamentoEqualThis);
			return VcruscottoBandiRupCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_BANDI_RUP>
  <ViewName>VCRUSCOTTO_BANDI_RUP</ViewName>
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
      <ID_RUP>Equal</ID_RUP>
      <ID_ISTRUTTORE_PROGETTO>Equal</ID_ISTRUTTORE_PROGETTO>
      <ID_ISTRUTTORE_DOMANDA_PAGAMENTO>Equal</ID_ISTRUTTORE_DOMANDA_PAGAMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_BANDI_RUP>
*/
