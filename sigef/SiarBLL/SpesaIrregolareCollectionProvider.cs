using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SpesaIrregolare
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISpesaIrregolareProvider
	{
		int Save(SpesaIrregolare SpesaIrregolareObj);
		int SaveCollection(SpesaIrregolareCollection collectionObj);
		int Delete(SpesaIrregolare SpesaIrregolareObj);
		int DeleteCollection(SpesaIrregolareCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SpesaIrregolare
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SpesaIrregolare: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSpesaIrregolare;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _IdIrregolarita;
		private NullTypes.IntNT _IdSpesa;
		private NullTypes.DecimalNT _ImportoIrregolare;
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
		[NonSerialized] private ISpesaIrregolareProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISpesaIrregolareProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public SpesaIrregolare()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SPESA_IRREGOLARE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSpesaIrregolare
		{
			get { return _IdSpesaIrregolare; }
			set {
				if (IdSpesaIrregolare != value)
				{
					_IdSpesaIrregolare = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IRREGOLARITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIrregolarita
		{
			get { return _IdIrregolarita; }
			set {
				if (IdIrregolarita != value)
				{
					_IdIrregolarita = value;
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
		/// Corrisponde al campo:IMPORTO_IRREGOLARE
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoIrregolare
		{
			get { return _ImportoIrregolare; }
			set {
				if (ImportoIrregolare != value)
				{
					_ImportoIrregolare = value;
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
	/// Summary description for SpesaIrregolareCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpesaIrregolareCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SpesaIrregolareCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SpesaIrregolare) info.GetValue(i.ToString(),typeof(SpesaIrregolare)));
			}
		}

		//Costruttore
		public SpesaIrregolareCollection()
		{
			this.ItemType = typeof(SpesaIrregolare);
		}

		//Costruttore con provider
		public SpesaIrregolareCollection(ISpesaIrregolareProvider providerObj)
		{
			this.ItemType = typeof(SpesaIrregolare);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SpesaIrregolare this[int index]
		{
			get { return (SpesaIrregolare)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SpesaIrregolareCollection GetChanges()
		{
			return (SpesaIrregolareCollection) base.GetChanges();
		}

		[NonSerialized] private ISpesaIrregolareProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISpesaIrregolareProvider Provider
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
		public int Add(SpesaIrregolare SpesaIrregolareObj)
		{
			if (SpesaIrregolareObj.Provider == null) SpesaIrregolareObj.Provider = this.Provider;
			return base.Add(SpesaIrregolareObj);
		}

		//AddCollection
		public void AddCollection(SpesaIrregolareCollection SpesaIrregolareCollectionObj)
		{
			foreach (SpesaIrregolare SpesaIrregolareObj in SpesaIrregolareCollectionObj)
				this.Add(SpesaIrregolareObj);
		}

		//Insert
		public void Insert(int index, SpesaIrregolare SpesaIrregolareObj)
		{
			if (SpesaIrregolareObj.Provider == null) SpesaIrregolareObj.Provider = this.Provider;
			base.Insert(index, SpesaIrregolareObj);
		}

		//CollectionGetById
		public SpesaIrregolare CollectionGetById(NullTypes.IntNT IdSpesaIrregolareValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSpesaIrregolare == IdSpesaIrregolareValue))
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
		public SpesaIrregolareCollection SubSelect(NullTypes.IntNT IdSpesaIrregolareEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT IdIrregolaritaEqualThis, 
NullTypes.IntNT IdSpesaEqualThis, NullTypes.DecimalNT ImportoIrregolareEqualThis)
		{
			SpesaIrregolareCollection SpesaIrregolareCollectionTemp = new SpesaIrregolareCollection();
			foreach (SpesaIrregolare SpesaIrregolareItem in this)
			{
				if (((IdSpesaIrregolareEqualThis == null) || ((SpesaIrregolareItem.IdSpesaIrregolare != null) && (SpesaIrregolareItem.IdSpesaIrregolare.Value == IdSpesaIrregolareEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((SpesaIrregolareItem.CfInserimento != null) && (SpesaIrregolareItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((SpesaIrregolareItem.DataInserimento != null) && (SpesaIrregolareItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((SpesaIrregolareItem.CfModifica != null) && (SpesaIrregolareItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((SpesaIrregolareItem.DataModifica != null) && (SpesaIrregolareItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((IdIrregolaritaEqualThis == null) || ((SpesaIrregolareItem.IdIrregolarita != null) && (SpesaIrregolareItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))) && 
((IdSpesaEqualThis == null) || ((SpesaIrregolareItem.IdSpesa != null) && (SpesaIrregolareItem.IdSpesa.Value == IdSpesaEqualThis.Value))) && ((ImportoIrregolareEqualThis == null) || ((SpesaIrregolareItem.ImportoIrregolare != null) && (SpesaIrregolareItem.ImportoIrregolare.Value == ImportoIrregolareEqualThis.Value))))
				{
					SpesaIrregolareCollectionTemp.Add(SpesaIrregolareItem);
				}
			}
			return SpesaIrregolareCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SpesaIrregolareDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SpesaIrregolareDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SpesaIrregolare SpesaIrregolareObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSpesaIrregolare", SpesaIrregolareObj.IdSpesaIrregolare);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", SpesaIrregolareObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", SpesaIrregolareObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", SpesaIrregolareObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", SpesaIrregolareObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIrregolarita", SpesaIrregolareObj.IdIrregolarita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSpesa", SpesaIrregolareObj.IdSpesa);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoIrregolare", SpesaIrregolareObj.ImportoIrregolare);
		}
		//Insert
		private static int Insert(DbProvider db, SpesaIrregolare SpesaIrregolareObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZSpesaIrregolareInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdSpesa", "ImportoIrregolare", 







}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "decimal", 







},"");
				CompileIUCmd(false, insertCmd,SpesaIrregolareObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				SpesaIrregolareObj.IdSpesaIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA_IRREGOLARE"]);
				SpesaIrregolareObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpesaIrregolareObj.IsDirty = false;
				SpesaIrregolareObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SpesaIrregolare SpesaIrregolareObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSpesaIrregolareUpdate", new string[] {"IdSpesaIrregolare", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdSpesa", "ImportoIrregolare", 







}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "decimal", 







},"");
				CompileIUCmd(true, updateCmd,SpesaIrregolareObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					SpesaIrregolareObj.DataModifica = d;
				}
				SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpesaIrregolareObj.IsDirty = false;
				SpesaIrregolareObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SpesaIrregolare SpesaIrregolareObj)
		{
			switch (SpesaIrregolareObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, SpesaIrregolareObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, SpesaIrregolareObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,SpesaIrregolareObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SpesaIrregolareCollection SpesaIrregolareCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZSpesaIrregolareUpdate", new string[] {"IdSpesaIrregolare", "CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdSpesa", "ImportoIrregolare", 







}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "decimal", 







},"");
				IDbCommand insertCmd = db.InitCmd( "ZSpesaIrregolareInsert", new string[] {"CfInserimento", "DataInserimento", 
"CfModifica", "DataModifica", "IdIrregolarita", 
"IdSpesa", "ImportoIrregolare", 







}, new string[] {"string", "DateTime", 
"string", "DateTime", "int", 
"int", "decimal", 







},"");
				IDbCommand deleteCmd = db.InitCmd( "ZSpesaIrregolareDelete", new string[] {"IdSpesaIrregolare"}, new string[] {"int"},"");
				for (int i = 0; i < SpesaIrregolareCollectionObj.Count; i++)
				{
					switch (SpesaIrregolareCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,SpesaIrregolareCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SpesaIrregolareCollectionObj[i].IdSpesaIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA_IRREGOLARE"]);
									SpesaIrregolareCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,SpesaIrregolareCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									SpesaIrregolareCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (SpesaIrregolareCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpesaIrregolare", (SiarLibrary.NullTypes.IntNT)SpesaIrregolareCollectionObj[i].IdSpesaIrregolare);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SpesaIrregolareCollectionObj.Count; i++)
				{
					if ((SpesaIrregolareCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpesaIrregolareCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpesaIrregolareCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SpesaIrregolareCollectionObj[i].IsDirty = false;
						SpesaIrregolareCollectionObj[i].IsPersistent = true;
					}
					if ((SpesaIrregolareCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SpesaIrregolareCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpesaIrregolareCollectionObj[i].IsDirty = false;
						SpesaIrregolareCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SpesaIrregolare SpesaIrregolareObj)
		{
			int returnValue = 0;
			if (SpesaIrregolareObj.IsPersistent) 
			{
				returnValue = Delete(db, SpesaIrregolareObj.IdSpesaIrregolare);
			}
			SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SpesaIrregolareObj.IsDirty = false;
			SpesaIrregolareObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSpesaIrregolareValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSpesaIrregolareDelete", new string[] {"IdSpesaIrregolare"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpesaIrregolare", (SiarLibrary.NullTypes.IntNT)IdSpesaIrregolareValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SpesaIrregolareCollection SpesaIrregolareCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZSpesaIrregolareDelete", new string[] {"IdSpesaIrregolare"}, new string[] {"int"},"");
				for (int i = 0; i < SpesaIrregolareCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSpesaIrregolare", SpesaIrregolareCollectionObj[i].IdSpesaIrregolare);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SpesaIrregolareCollectionObj.Count; i++)
				{
					if ((SpesaIrregolareCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpesaIrregolareCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpesaIrregolareCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpesaIrregolareCollectionObj[i].IsDirty = false;
						SpesaIrregolareCollectionObj[i].IsPersistent = false;
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
		public static SpesaIrregolare GetById(DbProvider db, int IdSpesaIrregolareValue)
		{
			SpesaIrregolare SpesaIrregolareObj = null;
			IDbCommand readCmd = db.InitCmd( "ZSpesaIrregolareGetById", new string[] {"IdSpesaIrregolare"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSpesaIrregolare", (SiarLibrary.NullTypes.IntNT)IdSpesaIrregolareValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SpesaIrregolareObj = GetFromDatareader(db);
				SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpesaIrregolareObj.IsDirty = false;
				SpesaIrregolareObj.IsPersistent = true;
			}
			db.Close();
			return SpesaIrregolareObj;
		}

		//getFromDatareader
		public static SpesaIrregolare GetFromDatareader(DbProvider db)
		{
			SpesaIrregolare SpesaIrregolareObj = new SpesaIrregolare();
			SpesaIrregolareObj.IdSpesaIrregolare = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA_IRREGOLARE"]);
			SpesaIrregolareObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			SpesaIrregolareObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			SpesaIrregolareObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			SpesaIrregolareObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			SpesaIrregolareObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
			SpesaIrregolareObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
			SpesaIrregolareObj.ImportoIrregolare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRREGOLARE"]);
			SpesaIrregolareObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.CodTipoSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_SPESA"]);
			SpesaIrregolareObj.EstremiSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESTREMI_SPESA"]);
			SpesaIrregolareObj.DataSpesa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SPESA"]);
			SpesaIrregolareObj.ImportoSpesa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_SPESA"]);
			SpesaIrregolareObj.NettoSpesa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["NETTO_SPESA"]);
			SpesaIrregolareObj.TipoSpesa = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SPESA"]);
			SpesaIrregolareObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			SpesaIrregolareObj.CodTipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOMANDA"]);
			SpesaIrregolareObj.TipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA"]);
			SpesaIrregolareObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			SpesaIrregolareObj.NumeroGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.CodTipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.DataGiustificativo = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.NumeroDoctrasportoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_DOCTRASPORTO_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.ImponibileGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPONIBILE_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.IvaGiustificativo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IVA_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.IvaNonRecuperabileGiustificativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IVA_NON_RECUPERABILE_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.DescrizioneGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.CfFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_FORNITORE_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.DescrizioneFornitoreGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FORNITORE_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.TipoGiustificativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_GIUSTIFICATIVO"]);
			SpesaIrregolareObj.IdLottoCertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_CERTIFICAZIONE"]);
			SpesaIrregolareObj.CodPsrCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR_CERTIFICAZIONE"]);
			SpesaIrregolareObj.DataInizioLottoCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_LOTTO_CERTIFICAZIONE"]);
			SpesaIrregolareObj.DataFineLottoCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_LOTTO_CERTIFICAZIONE"]);
			SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SpesaIrregolareObj.IsDirty = false;
			SpesaIrregolareObj.IsPersistent = true;
			return SpesaIrregolareObj;
		}

		//Find Select

		public static SpesaIrregolareCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpesaIrregolareEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, 
SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrregolareEqualThis)

		{

			SpesaIrregolareCollection SpesaIrregolareCollectionObj = new SpesaIrregolareCollection();

			IDbCommand findCmd = db.InitCmd("Zspesairregolarefindselect", new string[] {"IdSpesaIrregolareequalthis", "CfInserimentoequalthis", "DataInserimentoequalthis", 
"CfModificaequalthis", "DataModificaequalthis", "IdIrregolaritaequalthis", 
"IdSpesaequalthis", "ImportoIrregolareequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "int", 
"int", "decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaIrregolareequalthis", IdSpesaIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoIrregolareequalthis", ImportoIrregolareEqualThis);
			SpesaIrregolare SpesaIrregolareObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpesaIrregolareObj = GetFromDatareader(db);
				SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpesaIrregolareObj.IsDirty = false;
				SpesaIrregolareObj.IsPersistent = true;
				SpesaIrregolareCollectionObj.Add(SpesaIrregolareObj);
			}
			db.Close();
			return SpesaIrregolareCollectionObj;
		}

		//Find Find

		public static SpesaIrregolareCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpesaIrregolareEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, 
SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdLottoCertificazioneEqualThis)

		{

			SpesaIrregolareCollection SpesaIrregolareCollectionObj = new SpesaIrregolareCollection();

			IDbCommand findCmd = db.InitCmd("Zspesairregolarefindfind", new string[] {"IdSpesaIrregolareequalthis", "IdIrregolaritaequalthis", "IdSpesaequalthis", 
"IdGiustificativoequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis", 
"IdLottoCertificazioneequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaIrregolareequalthis", IdSpesaIrregolareEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoCertificazioneequalthis", IdLottoCertificazioneEqualThis);
			SpesaIrregolare SpesaIrregolareObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpesaIrregolareObj = GetFromDatareader(db);
				SpesaIrregolareObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpesaIrregolareObj.IsDirty = false;
				SpesaIrregolareObj.IsPersistent = true;
				SpesaIrregolareCollectionObj.Add(SpesaIrregolareObj);
			}
			db.Close();
			return SpesaIrregolareCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SpesaIrregolareCollectionProvider:ISpesaIrregolareProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpesaIrregolareCollectionProvider : ISpesaIrregolareProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SpesaIrregolare
		protected SpesaIrregolareCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SpesaIrregolareCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SpesaIrregolareCollection(this);
		}

		//Costruttore 2: popola la collection
		public SpesaIrregolareCollectionProvider(IntNT IdspesairregolareEqualThis, IntNT IdirregolaritaEqualThis, IntNT IdspesaEqualThis, 
IntNT IdgiustificativoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdlottocertificazioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdspesairregolareEqualThis, IdirregolaritaEqualThis, IdspesaEqualThis, 
IdgiustificativoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis, 
IdlottocertificazioneEqualThis);
		}

		//Costruttore3: ha in input spesairregolareCollectionObj - non popola la collection
		public SpesaIrregolareCollectionProvider(SpesaIrregolareCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SpesaIrregolareCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SpesaIrregolareCollection(this);
		}

		//Get e Set
		public SpesaIrregolareCollection CollectionObj
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
		public int SaveCollection(SpesaIrregolareCollection collectionObj)
		{
			return SpesaIrregolareDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SpesaIrregolare spesairregolareObj)
		{
			return SpesaIrregolareDAL.Save(_dbProviderObj, spesairregolareObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SpesaIrregolareCollection collectionObj)
		{
			return SpesaIrregolareDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SpesaIrregolare spesairregolareObj)
		{
			return SpesaIrregolareDAL.Delete(_dbProviderObj, spesairregolareObj);
		}

		//getById
		public SpesaIrregolare GetById(IntNT IdSpesaIrregolareValue)
		{
			SpesaIrregolare SpesaIrregolareTemp = SpesaIrregolareDAL.GetById(_dbProviderObj, IdSpesaIrregolareValue);
			if (SpesaIrregolareTemp!=null) SpesaIrregolareTemp.Provider = this;
			return SpesaIrregolareTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SpesaIrregolareCollection Select(IntNT IdspesairregolareEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis, IntNT IdirregolaritaEqualThis, 
IntNT IdspesaEqualThis, DecimalNT ImportoirregolareEqualThis)
		{
			SpesaIrregolareCollection SpesaIrregolareCollectionTemp = SpesaIrregolareDAL.Select(_dbProviderObj, IdspesairregolareEqualThis, CfinserimentoEqualThis, DatainserimentoEqualThis, 
CfmodificaEqualThis, DatamodificaEqualThis, IdirregolaritaEqualThis, 
IdspesaEqualThis, ImportoirregolareEqualThis);
			SpesaIrregolareCollectionTemp.Provider = this;
			return SpesaIrregolareCollectionTemp;
		}

		//Find: popola la collection
		public SpesaIrregolareCollection Find(IntNT IdspesairregolareEqualThis, IntNT IdirregolaritaEqualThis, IntNT IdspesaEqualThis, 
IntNT IdgiustificativoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdlottocertificazioneEqualThis)
		{
			SpesaIrregolareCollection SpesaIrregolareCollectionTemp = SpesaIrregolareDAL.Find(_dbProviderObj, IdspesairregolareEqualThis, IdirregolaritaEqualThis, IdspesaEqualThis, 
IdgiustificativoEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis, 
IdlottocertificazioneEqualThis);
			SpesaIrregolareCollectionTemp.Provider = this;
			return SpesaIrregolareCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SPESA_IRREGOLARE>
  <ViewName>VSPESA_IRREGOLARE</ViewName>
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
      <ID_SPESA_IRREGOLARE>Equal</ID_SPESA_IRREGOLARE>
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
      <ID_SPESA>Equal</ID_SPESA>
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_LOTTO_CERTIFICAZIONE>Equal</ID_LOTTO_CERTIFICAZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SPESA_IRREGOLARE>
*/
