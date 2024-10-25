using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VregistroRitiriRecuperi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VregistroRitiriRecuperi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdAsse;
		private NullTypes.StringNT _CodAsse;
		private NullTypes.IntNT _IdObiettivoSpecifico;
		private NullTypes.StringNT _CodObiettivoSpecifico;
		private NullTypes.IntNT _IdAzione;
		private NullTypes.StringNT _CodAzione;
		private NullTypes.IntNT _IdIntervento;
		private NullTypes.StringNT _CodIntervento;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdRitiro;
		private NullTypes.StringNT _TipoRitiro;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _BeneficiarioPiva;
		private NullTypes.StringNT _Beneficiario;
		private NullTypes.StringNT _SoggettoRilevatore;
		private NullTypes.StringNT _TipoDetrazione;
		private NullTypes.IntNT _IdLotto;
		private NullTypes.DatetimeNT _DataLotto;
		private NullTypes.StringNT _PeriodoContabile;
		private NullTypes.DecimalNT _ImportoTotale;
		private NullTypes.DecimalNT _Fesr;
		private NullTypes.DecimalNT _Stato;
		private NullTypes.DecimalNT _Regione;
		private NullTypes.IntNT _IdLottoSpesa;
		private NullTypes.DatetimeNT _DataLottoSpesa;
		private NullTypes.StringNT _PeriodoContabileSpesa;


		//Costruttore
		public VregistroRitiriRecuperi()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ASSE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAsse
		{
			get { return _IdAsse; }
			set {
				if (IdAsse != value)
				{
					_IdAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ASSE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodAsse
		{
			get { return _CodAsse; }
			set {
				if (CodAsse != value)
				{
					_CodAsse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OBIETTIVO_SPECIFICO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdObiettivoSpecifico
		{
			get { return _IdObiettivoSpecifico; }
			set {
				if (IdObiettivoSpecifico != value)
				{
					_IdObiettivoSpecifico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_OBIETTIVO_SPECIFICO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodObiettivoSpecifico
		{
			get { return _CodObiettivoSpecifico; }
			set {
				if (CodObiettivoSpecifico != value)
				{
					_CodObiettivoSpecifico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAzione
		{
			get { return _IdAzione; }
			set {
				if (IdAzione != value)
				{
					_IdAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_AZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodAzione
		{
			get { return _CodAzione; }
			set {
				if (CodAzione != value)
				{
					_CodAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INTERVENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntervento
		{
			get { return _IdIntervento; }
			set {
				if (IdIntervento != value)
				{
					_IdIntervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_INTERVENTO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodIntervento
		{
			get { return _CodIntervento; }
			set {
				if (CodIntervento != value)
				{
					_CodIntervento = value;
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
		/// Corrisponde al campo:ID_RITIRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRitiro
		{
			get { return _IdRitiro; }
			set {
				if (IdRitiro != value)
				{
					_IdRitiro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_RITIRO
		/// Tipo sul db:VARCHAR(12)
		/// </summary>
		public NullTypes.StringNT TipoRitiro
		{
			get { return _TipoRitiro; }
			set {
				if (TipoRitiro != value)
				{
					_TipoRitiro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(6)
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
		/// Corrisponde al campo:BENEFICIARIO_PIVA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT BeneficiarioPiva
		{
			get { return _BeneficiarioPiva; }
			set {
				if (BeneficiarioPiva != value)
				{
					_BeneficiarioPiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:BENEFICIARIO
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:SOGGETTO_RILEVATORE
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT SoggettoRilevatore
		{
			get { return _SoggettoRilevatore; }
			set {
				if (SoggettoRilevatore != value)
				{
					_SoggettoRilevatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_DETRAZIONE
		/// Tipo sul db:VARCHAR(14)
		/// </summary>
		public NullTypes.StringNT TipoDetrazione
		{
			get { return _TipoDetrazione; }
			set {
				if (TipoDetrazione != value)
				{
					_TipoDetrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_LOTTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataLotto
		{
			get { return _DataLotto; }
			set {
				if (DataLotto != value)
				{
					_DataLotto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERIODO_CONTABILE
		/// Tipo sul db:VARCHAR(23)
		/// </summary>
		public NullTypes.StringNT PeriodoContabile
		{
			get { return _PeriodoContabile; }
			set {
				if (PeriodoContabile != value)
				{
					_PeriodoContabile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_TOTALE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoTotale
		{
			get { return _ImportoTotale; }
			set {
				if (ImportoTotale != value)
				{
					_ImportoTotale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FESR
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Fesr
		{
			get { return _Fesr; }
			set {
				if (Fesr != value)
				{
					_Fesr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGIONE
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Regione
		{
			get { return _Regione; }
			set {
				if (Regione != value)
				{
					_Regione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_LOTTO_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLottoSpesa
		{
			get { return _IdLottoSpesa; }
			set {
				if (IdLottoSpesa != value)
				{
					_IdLottoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_LOTTO_SPESA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataLottoSpesa
		{
			get { return _DataLottoSpesa; }
			set {
				if (DataLottoSpesa != value)
				{
					_DataLottoSpesa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PERIODO_CONTABILE_SPESA
		/// Tipo sul db:VARCHAR(69)
		/// </summary>
		public NullTypes.StringNT PeriodoContabileSpesa
		{
			get { return _PeriodoContabileSpesa; }
			set {
				if (PeriodoContabileSpesa != value)
				{
					_PeriodoContabileSpesa = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VregistroRitiriRecuperiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VregistroRitiriRecuperiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VregistroRitiriRecuperiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VregistroRitiriRecuperi) info.GetValue(i.ToString(),typeof(VregistroRitiriRecuperi)));
			}
		}

		//Costruttore
		public VregistroRitiriRecuperiCollection()
		{
			this.ItemType = typeof(VregistroRitiriRecuperi);
		}

		//Get e Set
		public new VregistroRitiriRecuperi this[int index]
		{
			get { return (VregistroRitiriRecuperi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VregistroRitiriRecuperiCollection GetChanges()
		{
			return (VregistroRitiriRecuperiCollection) base.GetChanges();
		}

		//Add
		public int Add(VregistroRitiriRecuperi VregistroRitiriRecuperiObj)
		{
			return base.Add(VregistroRitiriRecuperiObj);
		}

		//AddCollection
		public void AddCollection(VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionObj)
		{
			foreach (VregistroRitiriRecuperi VregistroRitiriRecuperiObj in VregistroRitiriRecuperiCollectionObj)
				this.Add(VregistroRitiriRecuperiObj);
		}

		//Insert
		public void Insert(int index, VregistroRitiriRecuperi VregistroRitiriRecuperiObj)
		{
			base.Insert(index, VregistroRitiriRecuperiObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VregistroRitiriRecuperiCollection SubSelect(NullTypes.IntNT IdAsseEqualThis, NullTypes.StringNT CodAsseEqualThis, NullTypes.IntNT IdObiettivoSpecificoEqualThis, 
NullTypes.StringNT CodObiettivoSpecificoEqualThis, NullTypes.IntNT IdAzioneEqualThis, NullTypes.StringNT CodAzioneEqualThis, 
NullTypes.IntNT IdInterventoEqualThis, NullTypes.StringNT CodInterventoEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdRitiroEqualThis, NullTypes.StringNT TipoRitiroEqualThis, NullTypes.StringNT TipoEqualThis, 
NullTypes.StringNT BeneficiarioPivaEqualThis, NullTypes.StringNT BeneficiarioEqualThis, NullTypes.StringNT SoggettoRilevatoreEqualThis, 
NullTypes.StringNT TipoDetrazioneEqualThis, NullTypes.IntNT IdLottoEqualThis, NullTypes.DatetimeNT DataLottoEqualThis, 
NullTypes.StringNT PeriodoContabileEqualThis, NullTypes.DecimalNT ImportoTotaleEqualThis, NullTypes.DecimalNT FesrEqualThis, 
NullTypes.DecimalNT StatoEqualThis, NullTypes.DecimalNT RegioneEqualThis, NullTypes.IntNT IdLottoSpesaEqualThis, 
NullTypes.DatetimeNT DataLottoSpesaEqualThis, NullTypes.StringNT PeriodoContabileSpesaEqualThis)
		{
			VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionTemp = new VregistroRitiriRecuperiCollection();
			foreach (VregistroRitiriRecuperi VregistroRitiriRecuperiItem in this)
			{
				if (((IdAsseEqualThis == null) || ((VregistroRitiriRecuperiItem.IdAsse != null) && (VregistroRitiriRecuperiItem.IdAsse.Value == IdAsseEqualThis.Value))) && ((CodAsseEqualThis == null) || ((VregistroRitiriRecuperiItem.CodAsse != null) && (VregistroRitiriRecuperiItem.CodAsse.Value == CodAsseEqualThis.Value))) && ((IdObiettivoSpecificoEqualThis == null) || ((VregistroRitiriRecuperiItem.IdObiettivoSpecifico != null) && (VregistroRitiriRecuperiItem.IdObiettivoSpecifico.Value == IdObiettivoSpecificoEqualThis.Value))) && 
((CodObiettivoSpecificoEqualThis == null) || ((VregistroRitiriRecuperiItem.CodObiettivoSpecifico != null) && (VregistroRitiriRecuperiItem.CodObiettivoSpecifico.Value == CodObiettivoSpecificoEqualThis.Value))) && ((IdAzioneEqualThis == null) || ((VregistroRitiriRecuperiItem.IdAzione != null) && (VregistroRitiriRecuperiItem.IdAzione.Value == IdAzioneEqualThis.Value))) && ((CodAzioneEqualThis == null) || ((VregistroRitiriRecuperiItem.CodAzione != null) && (VregistroRitiriRecuperiItem.CodAzione.Value == CodAzioneEqualThis.Value))) && 
((IdInterventoEqualThis == null) || ((VregistroRitiriRecuperiItem.IdIntervento != null) && (VregistroRitiriRecuperiItem.IdIntervento.Value == IdInterventoEqualThis.Value))) && ((CodInterventoEqualThis == null) || ((VregistroRitiriRecuperiItem.CodIntervento != null) && (VregistroRitiriRecuperiItem.CodIntervento.Value == CodInterventoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VregistroRitiriRecuperiItem.IdProgetto != null) && (VregistroRitiriRecuperiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdRitiroEqualThis == null) || ((VregistroRitiriRecuperiItem.IdRitiro != null) && (VregistroRitiriRecuperiItem.IdRitiro.Value == IdRitiroEqualThis.Value))) && ((TipoRitiroEqualThis == null) || ((VregistroRitiriRecuperiItem.TipoRitiro != null) && (VregistroRitiriRecuperiItem.TipoRitiro.Value == TipoRitiroEqualThis.Value))) && ((TipoEqualThis == null) || ((VregistroRitiriRecuperiItem.Tipo != null) && (VregistroRitiriRecuperiItem.Tipo.Value == TipoEqualThis.Value))) && 
((BeneficiarioPivaEqualThis == null) || ((VregistroRitiriRecuperiItem.BeneficiarioPiva != null) && (VregistroRitiriRecuperiItem.BeneficiarioPiva.Value == BeneficiarioPivaEqualThis.Value))) && ((BeneficiarioEqualThis == null) || ((VregistroRitiriRecuperiItem.Beneficiario != null) && (VregistroRitiriRecuperiItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SoggettoRilevatoreEqualThis == null) || ((VregistroRitiriRecuperiItem.SoggettoRilevatore != null) && (VregistroRitiriRecuperiItem.SoggettoRilevatore.Value == SoggettoRilevatoreEqualThis.Value))) && 
((TipoDetrazioneEqualThis == null) || ((VregistroRitiriRecuperiItem.TipoDetrazione != null) && (VregistroRitiriRecuperiItem.TipoDetrazione.Value == TipoDetrazioneEqualThis.Value))) && ((IdLottoEqualThis == null) || ((VregistroRitiriRecuperiItem.IdLotto != null) && (VregistroRitiriRecuperiItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((DataLottoEqualThis == null) || ((VregistroRitiriRecuperiItem.DataLotto != null) && (VregistroRitiriRecuperiItem.DataLotto.Value == DataLottoEqualThis.Value))) && 
((PeriodoContabileEqualThis == null) || ((VregistroRitiriRecuperiItem.PeriodoContabile != null) && (VregistroRitiriRecuperiItem.PeriodoContabile.Value == PeriodoContabileEqualThis.Value))) && ((ImportoTotaleEqualThis == null) || ((VregistroRitiriRecuperiItem.ImportoTotale != null) && (VregistroRitiriRecuperiItem.ImportoTotale.Value == ImportoTotaleEqualThis.Value))) && ((FesrEqualThis == null) || ((VregistroRitiriRecuperiItem.Fesr != null) && (VregistroRitiriRecuperiItem.Fesr.Value == FesrEqualThis.Value))) && 
((StatoEqualThis == null) || ((VregistroRitiriRecuperiItem.Stato != null) && (VregistroRitiriRecuperiItem.Stato.Value == StatoEqualThis.Value))) && ((RegioneEqualThis == null) || ((VregistroRitiriRecuperiItem.Regione != null) && (VregistroRitiriRecuperiItem.Regione.Value == RegioneEqualThis.Value))) && ((IdLottoSpesaEqualThis == null) || ((VregistroRitiriRecuperiItem.IdLottoSpesa != null) && (VregistroRitiriRecuperiItem.IdLottoSpesa.Value == IdLottoSpesaEqualThis.Value))) && 
((DataLottoSpesaEqualThis == null) || ((VregistroRitiriRecuperiItem.DataLottoSpesa != null) && (VregistroRitiriRecuperiItem.DataLottoSpesa.Value == DataLottoSpesaEqualThis.Value))) && ((PeriodoContabileSpesaEqualThis == null) || ((VregistroRitiriRecuperiItem.PeriodoContabileSpesa != null) && (VregistroRitiriRecuperiItem.PeriodoContabileSpesa.Value == PeriodoContabileSpesaEqualThis.Value))))
				{
					VregistroRitiriRecuperiCollectionTemp.Add(VregistroRitiriRecuperiItem);
				}
			}
			return VregistroRitiriRecuperiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VregistroRitiriRecuperiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VregistroRitiriRecuperiDAL
	{

		//Operazioni

		//getFromDatareader
		public static VregistroRitiriRecuperi GetFromDatareader(DbProvider db)
		{
			VregistroRitiriRecuperi VregistroRitiriRecuperiObj = new VregistroRitiriRecuperi();
			VregistroRitiriRecuperiObj.IdAsse = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ASSE"]);
			VregistroRitiriRecuperiObj.CodAsse = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ASSE"]);
			VregistroRitiriRecuperiObj.IdObiettivoSpecifico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO_SPECIFICO"]);
			VregistroRitiriRecuperiObj.CodObiettivoSpecifico = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_OBIETTIVO_SPECIFICO"]);
			VregistroRitiriRecuperiObj.IdAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AZIONE"]);
			VregistroRitiriRecuperiObj.CodAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AZIONE"]);
			VregistroRitiriRecuperiObj.IdIntervento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTERVENTO"]);
			VregistroRitiriRecuperiObj.CodIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_INTERVENTO"]);
			VregistroRitiriRecuperiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VregistroRitiriRecuperiObj.IdRitiro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RITIRO"]);
			VregistroRitiriRecuperiObj.TipoRitiro = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_RITIRO"]);
			VregistroRitiriRecuperiObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			VregistroRitiriRecuperiObj.BeneficiarioPiva = new SiarLibrary.NullTypes.StringNT(db.DataReader["BENEFICIARIO_PIVA"]);
			VregistroRitiriRecuperiObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["BENEFICIARIO"]);
			VregistroRitiriRecuperiObj.SoggettoRilevatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SOGGETTO_RILEVATORE"]);
			VregistroRitiriRecuperiObj.TipoDetrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DETRAZIONE"]);
			VregistroRitiriRecuperiObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			VregistroRitiriRecuperiObj.DataLotto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_LOTTO"]);
			VregistroRitiriRecuperiObj.PeriodoContabile = new SiarLibrary.NullTypes.StringNT(db.DataReader["PERIODO_CONTABILE"]);
			VregistroRitiriRecuperiObj.ImportoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_TOTALE"]);
			VregistroRitiriRecuperiObj.Fesr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FESR"]);
			VregistroRitiriRecuperiObj.Stato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["STATO"]);
			VregistroRitiriRecuperiObj.Regione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["REGIONE"]);
			VregistroRitiriRecuperiObj.IdLottoSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_SPESA"]);
			VregistroRitiriRecuperiObj.DataLottoSpesa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_LOTTO_SPESA"]);
			VregistroRitiriRecuperiObj.PeriodoContabileSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["PERIODO_CONTABILE_SPESA"]);
			VregistroRitiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VregistroRitiriRecuperiObj.IsDirty = false;
			VregistroRitiriRecuperiObj.IsPersistent = true;
			return VregistroRitiriRecuperiObj;
		}

		//Find Select

		public static VregistroRitiriRecuperiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAsseEqualThis, SiarLibrary.NullTypes.StringNT CodAsseEqualThis, SiarLibrary.NullTypes.IntNT IdObiettivoSpecificoEqualThis, 
SiarLibrary.NullTypes.StringNT CodObiettivoSpecificoEqualThis, SiarLibrary.NullTypes.IntNT IdAzioneEqualThis, SiarLibrary.NullTypes.StringNT CodAzioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdInterventoEqualThis, SiarLibrary.NullTypes.StringNT CodInterventoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdRitiroEqualThis, SiarLibrary.NullTypes.StringNT TipoRitiroEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, 
SiarLibrary.NullTypes.StringNT BeneficiarioPivaEqualThis, SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.StringNT SoggettoRilevatoreEqualThis, 
SiarLibrary.NullTypes.StringNT TipoDetrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataLottoEqualThis, 
SiarLibrary.NullTypes.StringNT PeriodoContabileEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT FesrEqualThis, 
SiarLibrary.NullTypes.DecimalNT StatoEqualThis, SiarLibrary.NullTypes.DecimalNT RegioneEqualThis, SiarLibrary.NullTypes.IntNT IdLottoSpesaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataLottoSpesaEqualThis, SiarLibrary.NullTypes.StringNT PeriodoContabileSpesaEqualThis)

		{

			VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionObj = new VregistroRitiriRecuperiCollection();

			IDbCommand findCmd = db.InitCmd("Zvregistroritirirecuperifindselect", new string[] {"IdAsseequalthis", "CodAsseequalthis", "IdObiettivoSpecificoequalthis", 
"CodObiettivoSpecificoequalthis", "IdAzioneequalthis", "CodAzioneequalthis", 
"IdInterventoequalthis", "CodInterventoequalthis", "IdProgettoequalthis", 
"IdRitiroequalthis", "TipoRitiroequalthis", "Tipoequalthis", 
"BeneficiarioPivaequalthis", "Beneficiarioequalthis", "SoggettoRilevatoreequalthis", 
"TipoDetrazioneequalthis", "IdLottoequalthis", "DataLottoequalthis", 
"PeriodoContabileequalthis", "ImportoTotaleequalthis", "Fesrequalthis", 
"Statoequalthis", "Regioneequalthis", "IdLottoSpesaequalthis", 
"DataLottoSpesaequalthis", "PeriodoContabileSpesaequalthis"}, new string[] {"int", "string", "int", 
"string", "int", "string", 
"int", "string", "int", 
"int", "string", "string", 
"string", "string", "string", 
"string", "int", "DateTime", 
"string", "decimal", "decimal", 
"decimal", "decimal", "int", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAsseequalthis", IdAsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAsseequalthis", CodAsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdObiettivoSpecificoequalthis", IdObiettivoSpecificoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodObiettivoSpecificoequalthis", CodObiettivoSpecificoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneequalthis", IdAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAzioneequalthis", CodAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInterventoequalthis", IdInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodInterventoequalthis", CodInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRitiroequalthis", IdRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoRitiroequalthis", TipoRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "BeneficiarioPivaequalthis", BeneficiarioPivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SoggettoRilevatoreequalthis", SoggettoRilevatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDetrazioneequalthis", TipoDetrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataLottoequalthis", DataLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PeriodoContabileequalthis", PeriodoContabileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoTotaleequalthis", ImportoTotaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Fesrequalthis", FesrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Regioneequalthis", RegioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoSpesaequalthis", IdLottoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataLottoSpesaequalthis", DataLottoSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PeriodoContabileSpesaequalthis", PeriodoContabileSpesaEqualThis);
			VregistroRitiriRecuperi VregistroRitiriRecuperiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VregistroRitiriRecuperiObj = GetFromDatareader(db);
				VregistroRitiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VregistroRitiriRecuperiObj.IsDirty = false;
				VregistroRitiriRecuperiObj.IsPersistent = true;
				VregistroRitiriRecuperiCollectionObj.Add(VregistroRitiriRecuperiObj);
			}
			db.Close();
			return VregistroRitiriRecuperiCollectionObj;
		}

		//Find Find

		public static VregistroRitiriRecuperiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAzioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, 
SiarLibrary.NullTypes.StringNT TipoRitiroEqualThis, SiarLibrary.NullTypes.StringNT SoggettoRilevatoreEqualThis, SiarLibrary.NullTypes.StringNT TipoDetrazioneEqualThis, 
SiarLibrary.NullTypes.StringNT PeriodoContabileEqualThis)

		{

			VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionObj = new VregistroRitiriRecuperiCollection();

			IDbCommand findCmd = db.InitCmd("Zvregistroritirirecuperifindfind", new string[] {"IdAzioneequalthis", "IdProgettoequalthis", "Tipoequalthis", 
"TipoRitiroequalthis", "SoggettoRilevatoreequalthis", "TipoDetrazioneequalthis", 
"PeriodoContabileequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneequalthis", IdAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoRitiroequalthis", TipoRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SoggettoRilevatoreequalthis", SoggettoRilevatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoDetrazioneequalthis", TipoDetrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PeriodoContabileequalthis", PeriodoContabileEqualThis);
			VregistroRitiriRecuperi VregistroRitiriRecuperiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VregistroRitiriRecuperiObj = GetFromDatareader(db);
				VregistroRitiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VregistroRitiriRecuperiObj.IsDirty = false;
				VregistroRitiriRecuperiObj.IsPersistent = true;
				VregistroRitiriRecuperiCollectionObj.Add(VregistroRitiriRecuperiObj);
			}
			db.Close();
			return VregistroRitiriRecuperiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VregistroRitiriRecuperiCollectionProvider:IVregistroRitiriRecuperiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VregistroRitiriRecuperiCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VregistroRitiriRecuperi
		protected VregistroRitiriRecuperiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VregistroRitiriRecuperiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VregistroRitiriRecuperiCollection();
		}

		//Costruttore 2: popola la collection
		public VregistroRitiriRecuperiCollectionProvider(IntNT IdazioneEqualThis, IntNT IdprogettoEqualThis, StringNT TipoEqualThis, 
StringNT TiporitiroEqualThis, StringNT SoggettorilevatoreEqualThis, StringNT TipodetrazioneEqualThis, 
StringNT PeriodocontabileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdazioneEqualThis, IdprogettoEqualThis, TipoEqualThis, 
TiporitiroEqualThis, SoggettorilevatoreEqualThis, TipodetrazioneEqualThis, 
PeriodocontabileEqualThis);
		}

		//Costruttore3: ha in input vregistroritirirecuperiCollectionObj - non popola la collection
		public VregistroRitiriRecuperiCollectionProvider(VregistroRitiriRecuperiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VregistroRitiriRecuperiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VregistroRitiriRecuperiCollection();
		}

		//Get e Set
		public VregistroRitiriRecuperiCollection CollectionObj
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
		public VregistroRitiriRecuperiCollection Select(IntNT IdasseEqualThis, StringNT CodasseEqualThis, IntNT IdobiettivospecificoEqualThis, 
StringNT CodobiettivospecificoEqualThis, IntNT IdazioneEqualThis, StringNT CodazioneEqualThis, 
IntNT IdinterventoEqualThis, StringNT CodinterventoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdritiroEqualThis, StringNT TiporitiroEqualThis, StringNT TipoEqualThis, 
StringNT BeneficiariopivaEqualThis, StringNT BeneficiarioEqualThis, StringNT SoggettorilevatoreEqualThis, 
StringNT TipodetrazioneEqualThis, IntNT IdlottoEqualThis, DatetimeNT DatalottoEqualThis, 
StringNT PeriodocontabileEqualThis, DecimalNT ImportototaleEqualThis, DecimalNT FesrEqualThis, 
DecimalNT StatoEqualThis, DecimalNT RegioneEqualThis, IntNT IdlottospesaEqualThis, 
DatetimeNT DatalottospesaEqualThis, StringNT PeriodocontabilespesaEqualThis)
		{
			VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionTemp = VregistroRitiriRecuperiDAL.Select(_dbProviderObj, IdasseEqualThis, CodasseEqualThis, IdobiettivospecificoEqualThis, 
CodobiettivospecificoEqualThis, IdazioneEqualThis, CodazioneEqualThis, 
IdinterventoEqualThis, CodinterventoEqualThis, IdprogettoEqualThis, 
IdritiroEqualThis, TiporitiroEqualThis, TipoEqualThis, 
BeneficiariopivaEqualThis, BeneficiarioEqualThis, SoggettorilevatoreEqualThis, 
TipodetrazioneEqualThis, IdlottoEqualThis, DatalottoEqualThis, 
PeriodocontabileEqualThis, ImportototaleEqualThis, FesrEqualThis, 
StatoEqualThis, RegioneEqualThis, IdlottospesaEqualThis, 
DatalottospesaEqualThis, PeriodocontabilespesaEqualThis);
			return VregistroRitiriRecuperiCollectionTemp;
		}

		//Find: popola la collection
		public VregistroRitiriRecuperiCollection Find(IntNT IdazioneEqualThis, IntNT IdprogettoEqualThis, StringNT TipoEqualThis, 
StringNT TiporitiroEqualThis, StringNT SoggettorilevatoreEqualThis, StringNT TipodetrazioneEqualThis, 
StringNT PeriodocontabileEqualThis)
		{
			VregistroRitiriRecuperiCollection VregistroRitiriRecuperiCollectionTemp = VregistroRitiriRecuperiDAL.Find(_dbProviderObj, IdazioneEqualThis, IdprogettoEqualThis, TipoEqualThis, 
TiporitiroEqualThis, SoggettorilevatoreEqualThis, TipodetrazioneEqualThis, 
PeriodocontabileEqualThis);
			return VregistroRitiriRecuperiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vREGISTRO_RITIRI_RECUPERI>
  <ViewName>vREGISTRO_RITIRI_RECUPERI</ViewName>
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
  <Finds>
    <Find OrderBy="ORDER BY PERIODO_CONTABILE,DATA_LOTTO">
      <ID_AZIONE>Equal</ID_AZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <TIPO>Equal</TIPO>
      <TIPO_RITIRO>Equal</TIPO_RITIRO>
      <SOGGETTO_RILEVATORE>Equal</SOGGETTO_RILEVATORE>
      <TIPO_DETRAZIONE>Equal</TIPO_DETRAZIONE>
      <PERIODO_CONTABILE>Equal</PERIODO_CONTABILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vREGISTRO_RITIRI_RECUPERI>
*/
