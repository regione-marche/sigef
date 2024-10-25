using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per IntegrazioneSingolaDiDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIntegrazioneSingolaDiDomandaProvider
	{
		int Save(IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj);
		int SaveCollection(IntegrazioneSingolaDiDomandaCollection collectionObj);
		int Delete(IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj);
		int DeleteCollection(IntegrazioneSingolaDiDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IntegrazioneSingolaDiDomanda
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class IntegrazioneSingolaDiDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSingolaIntegrazione;
		private NullTypes.IntNT _IdIntegrazioneDomanda;
		private NullTypes.StringNT _CodTipoIntegrazione;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfIstruttoreSingolaIntegrazione;
		private NullTypes.StringNT _NoteIntegrazioneIstruttore;
		private NullTypes.DatetimeNT _DataRichiestaIntegrazioneIstruttore;
		private NullTypes.DatetimeNT _DataConclusioneIstruttore;
		private NullTypes.BoolNT _SingolaIntegrazioneCompletataIstruttore;
		private NullTypes.StringNT _CfBeneficiarioSingolaIntegrazione;
		private NullTypes.StringNT _NoteIntegrazioneBeneficiario;
		private NullTypes.DatetimeNT _DataRilascioIntegrazioneBeneficiario;
		private NullTypes.DatetimeNT _DataConclusioneBeneficiario;
		private NullTypes.BoolNT _SingolaIntegrazioneCompletataBeneficiario;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.DatetimeNT _DataInserimentoIntegrazione;
		private NullTypes.DatetimeNT _DataModificaIntegrazione;
		private NullTypes.BoolNT _IntegrazioneCompleta;
		private NullTypes.StringNT _NoteIntegrazioneDomanda;
		private NullTypes.StringNT _CfIstruttore;
		private NullTypes.DatetimeNT _DataRichiestaIntegrazioneDomanda;
		private NullTypes.StringNT _SegnaturaIstruttore;
		private NullTypes.StringNT _CfBenficiario;
		private NullTypes.StringNT _SegnaturaBeneficiario;
		private NullTypes.DatetimeNT _DataConclusioneIntegrazione;
		private NullTypes.StringNT _DescrizioneTipoIntegrazione;
		private NullTypes.IntNT _IdSpesa;
		private NullTypes.IntNT _IdGiustificativo;
		private NullTypes.IntNT _IdAllegato;
		[NonSerialized] private IIntegrazioneSingolaDiDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIntegrazioneSingolaDiDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public IntegrazioneSingolaDiDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SINGOLA_INTEGRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSingolaIntegrazione
		{
			get { return _IdSingolaIntegrazione; }
			set {
				if (IdSingolaIntegrazione != value)
				{
					_IdSingolaIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INTEGRAZIONE_DOMANDA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntegrazioneDomanda
		{
			get { return _IdIntegrazioneDomanda; }
			set {
				if (IdIntegrazioneDomanda != value)
				{
					_IdIntegrazioneDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_INTEGRAZIONE
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipoIntegrazione
		{
			get { return _CodTipoIntegrazione; }
			set {
				if (CodTipoIntegrazione != value)
				{
					_CodTipoIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfIstruttoreSingolaIntegrazione
		{
			get { return _CfIstruttoreSingolaIntegrazione; }
			set {
				if (CfIstruttoreSingolaIntegrazione != value)
				{
					_CfIstruttoreSingolaIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_INTEGRAZIONE_ISTRUTTORE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT NoteIntegrazioneIstruttore
		{
			get { return _NoteIntegrazioneIstruttore; }
			set {
				if (NoteIntegrazioneIstruttore != value)
				{
					_NoteIntegrazioneIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRichiestaIntegrazioneIstruttore
		{
			get { return _DataRichiestaIntegrazioneIstruttore; }
			set {
				if (DataRichiestaIntegrazioneIstruttore != value)
				{
					_DataRichiestaIntegrazioneIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONCLUSIONE_ISTRUTTORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataConclusioneIstruttore
		{
			get { return _DataConclusioneIstruttore; }
			set {
				if (DataConclusioneIstruttore != value)
				{
					_DataConclusioneIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttore
		{
			get { return _SingolaIntegrazioneCompletataIstruttore; }
			set {
				if (SingolaIntegrazioneCompletataIstruttore != value)
				{
					_SingolaIntegrazioneCompletataIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfBeneficiarioSingolaIntegrazione
		{
			get { return _CfBeneficiarioSingolaIntegrazione; }
			set {
				if (CfBeneficiarioSingolaIntegrazione != value)
				{
					_CfBeneficiarioSingolaIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_INTEGRAZIONE_BENEFICIARIO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT NoteIntegrazioneBeneficiario
		{
			get { return _NoteIntegrazioneBeneficiario; }
			set {
				if (NoteIntegrazioneBeneficiario != value)
				{
					_NoteIntegrazioneBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRilascioIntegrazioneBeneficiario
		{
			get { return _DataRilascioIntegrazioneBeneficiario; }
			set {
				if (DataRilascioIntegrazioneBeneficiario != value)
				{
					_DataRilascioIntegrazioneBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONCLUSIONE_BENEFICIARIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataConclusioneBeneficiario
		{
			get { return _DataConclusioneBeneficiario; }
			set {
				if (DataConclusioneBeneficiario != value)
				{
					_DataConclusioneBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiario
		{
			get { return _SingolaIntegrazioneCompletataBeneficiario; }
			set {
				if (SingolaIntegrazioneCompletataBeneficiario != value)
				{
					_SingolaIntegrazioneCompletataBeneficiario = value;
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
		/// Corrisponde al campo:DATA_INSERIMENTO_INTEGRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimentoIntegrazione
		{
			get { return _DataInserimentoIntegrazione; }
			set {
				if (DataInserimentoIntegrazione != value)
				{
					_DataInserimentoIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA_INTEGRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModificaIntegrazione
		{
			get { return _DataModificaIntegrazione; }
			set {
				if (DataModificaIntegrazione != value)
				{
					_DataModificaIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTEGRAZIONE_COMPLETA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IntegrazioneCompleta
		{
			get { return _IntegrazioneCompleta; }
			set {
				if (IntegrazioneCompleta != value)
				{
					_IntegrazioneCompleta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_INTEGRAZIONE_DOMANDA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT NoteIntegrazioneDomanda
		{
			get { return _NoteIntegrazioneDomanda; }
			set {
				if (NoteIntegrazioneDomanda != value)
				{
					_NoteIntegrazioneDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_ISTRUTTORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfIstruttore
		{
			get { return _CfIstruttore; }
			set {
				if (CfIstruttore != value)
				{
					_CfIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RICHIESTA_INTEGRAZIONE_DOMANDA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRichiestaIntegrazioneDomanda
		{
			get { return _DataRichiestaIntegrazioneDomanda; }
			set {
				if (DataRichiestaIntegrazioneDomanda != value)
				{
					_DataRichiestaIntegrazioneDomanda = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ISTRUTTORE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaIstruttore
		{
			get { return _SegnaturaIstruttore; }
			set {
				if (SegnaturaIstruttore != value)
				{
					_SegnaturaIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_BENFICIARIO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfBenficiario
		{
			get { return _CfBenficiario; }
			set {
				if (CfBenficiario != value)
				{
					_CfBenficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_BENEFICIARIO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaBeneficiario
		{
			get { return _SegnaturaBeneficiario; }
			set {
				if (SegnaturaBeneficiario != value)
				{
					_SegnaturaBeneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONCLUSIONE_INTEGRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataConclusioneIntegrazione
		{
			get { return _DataConclusioneIntegrazione; }
			set {
				if (DataConclusioneIntegrazione != value)
				{
					_DataConclusioneIntegrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO_INTEGRAZIONE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipoIntegrazione
		{
			get { return _DescrizioneTipoIntegrazione; }
			set {
				if (DescrizioneTipoIntegrazione != value)
				{
					_DescrizioneTipoIntegrazione = value;
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
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
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
	/// Summary description for IntegrazioneSingolaDiDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IntegrazioneSingolaDiDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IntegrazioneSingolaDiDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((IntegrazioneSingolaDiDomanda) info.GetValue(i.ToString(),typeof(IntegrazioneSingolaDiDomanda)));
			}
		}

		//Costruttore
		public IntegrazioneSingolaDiDomandaCollection()
		{
			this.ItemType = typeof(IntegrazioneSingolaDiDomanda);
		}

		//Costruttore con provider
		public IntegrazioneSingolaDiDomandaCollection(IIntegrazioneSingolaDiDomandaProvider providerObj)
		{
			this.ItemType = typeof(IntegrazioneSingolaDiDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IntegrazioneSingolaDiDomanda this[int index]
		{
			get { return (IntegrazioneSingolaDiDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IntegrazioneSingolaDiDomandaCollection GetChanges()
		{
			return (IntegrazioneSingolaDiDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IIntegrazioneSingolaDiDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIntegrazioneSingolaDiDomandaProvider Provider
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
		public int Add(IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			if (IntegrazioneSingolaDiDomandaObj.Provider == null) IntegrazioneSingolaDiDomandaObj.Provider = this.Provider;
			return base.Add(IntegrazioneSingolaDiDomandaObj);
		}

		//AddCollection
		public void AddCollection(IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj)
		{
			foreach (IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj in IntegrazioneSingolaDiDomandaCollectionObj)
				this.Add(IntegrazioneSingolaDiDomandaObj);
		}

		//Insert
		public void Insert(int index, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			if (IntegrazioneSingolaDiDomandaObj.Provider == null) IntegrazioneSingolaDiDomandaObj.Provider = this.Provider;
			base.Insert(index, IntegrazioneSingolaDiDomandaObj);
		}

		//CollectionGetById
		public IntegrazioneSingolaDiDomanda CollectionGetById(NullTypes.IntNT IdSingolaIntegrazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSingolaIntegrazione == IdSingolaIntegrazioneValue))
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
		public IntegrazioneSingolaDiDomandaCollection SubSelect(NullTypes.IntNT IdSingolaIntegrazioneEqualThis, NullTypes.IntNT IdIntegrazioneDomandaEqualThis, NullTypes.StringNT CodTipoIntegrazioneEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfIstruttoreSingolaIntegrazioneEqualThis, 
NullTypes.StringNT NoteIntegrazioneIstruttoreEqualThis, NullTypes.DatetimeNT DataRichiestaIntegrazioneIstruttoreEqualThis, NullTypes.DatetimeNT DataConclusioneIstruttoreEqualThis, 
NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, NullTypes.StringNT CfBeneficiarioSingolaIntegrazioneEqualThis, NullTypes.StringNT NoteIntegrazioneBeneficiarioEqualThis, 
NullTypes.DatetimeNT DataRilascioIntegrazioneBeneficiarioEqualThis, NullTypes.DatetimeNT DataConclusioneBeneficiarioEqualThis, NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, 
NullTypes.IntNT IdSpesaEqualThis, NullTypes.IntNT IdGiustificativoEqualThis, NullTypes.IntNT IdAllegatoEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = new IntegrazioneSingolaDiDomandaCollection();
			foreach (IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaItem in this)
			{
				if (((IdSingolaIntegrazioneEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.IdSingolaIntegrazione != null) && (IntegrazioneSingolaDiDomandaItem.IdSingolaIntegrazione.Value == IdSingolaIntegrazioneEqualThis.Value))) && ((IdIntegrazioneDomandaEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.IdIntegrazioneDomanda != null) && (IntegrazioneSingolaDiDomandaItem.IdIntegrazioneDomanda.Value == IdIntegrazioneDomandaEqualThis.Value))) && ((CodTipoIntegrazioneEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.CodTipoIntegrazione != null) && (IntegrazioneSingolaDiDomandaItem.CodTipoIntegrazione.Value == CodTipoIntegrazioneEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataInserimento != null) && (IntegrazioneSingolaDiDomandaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataModifica != null) && (IntegrazioneSingolaDiDomandaItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfIstruttoreSingolaIntegrazioneEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.CfIstruttoreSingolaIntegrazione != null) && (IntegrazioneSingolaDiDomandaItem.CfIstruttoreSingolaIntegrazione.Value == CfIstruttoreSingolaIntegrazioneEqualThis.Value))) && 
((NoteIntegrazioneIstruttoreEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.NoteIntegrazioneIstruttore != null) && (IntegrazioneSingolaDiDomandaItem.NoteIntegrazioneIstruttore.Value == NoteIntegrazioneIstruttoreEqualThis.Value))) && ((DataRichiestaIntegrazioneIstruttoreEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataRichiestaIntegrazioneIstruttore != null) && (IntegrazioneSingolaDiDomandaItem.DataRichiestaIntegrazioneIstruttore.Value == DataRichiestaIntegrazioneIstruttoreEqualThis.Value))) && ((DataConclusioneIstruttoreEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataConclusioneIstruttore != null) && (IntegrazioneSingolaDiDomandaItem.DataConclusioneIstruttore.Value == DataConclusioneIstruttoreEqualThis.Value))) && 
((SingolaIntegrazioneCompletataIstruttoreEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.SingolaIntegrazioneCompletataIstruttore != null) && (IntegrazioneSingolaDiDomandaItem.SingolaIntegrazioneCompletataIstruttore.Value == SingolaIntegrazioneCompletataIstruttoreEqualThis.Value))) && ((CfBeneficiarioSingolaIntegrazioneEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.CfBeneficiarioSingolaIntegrazione != null) && (IntegrazioneSingolaDiDomandaItem.CfBeneficiarioSingolaIntegrazione.Value == CfBeneficiarioSingolaIntegrazioneEqualThis.Value))) && ((NoteIntegrazioneBeneficiarioEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.NoteIntegrazioneBeneficiario != null) && (IntegrazioneSingolaDiDomandaItem.NoteIntegrazioneBeneficiario.Value == NoteIntegrazioneBeneficiarioEqualThis.Value))) && 
((DataRilascioIntegrazioneBeneficiarioEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataRilascioIntegrazioneBeneficiario != null) && (IntegrazioneSingolaDiDomandaItem.DataRilascioIntegrazioneBeneficiario.Value == DataRilascioIntegrazioneBeneficiarioEqualThis.Value))) && ((DataConclusioneBeneficiarioEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.DataConclusioneBeneficiario != null) && (IntegrazioneSingolaDiDomandaItem.DataConclusioneBeneficiario.Value == DataConclusioneBeneficiarioEqualThis.Value))) && ((SingolaIntegrazioneCompletataBeneficiarioEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.SingolaIntegrazioneCompletataBeneficiario != null) && (IntegrazioneSingolaDiDomandaItem.SingolaIntegrazioneCompletataBeneficiario.Value == SingolaIntegrazioneCompletataBeneficiarioEqualThis.Value))) && 
((IdSpesaEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.IdSpesa != null) && (IntegrazioneSingolaDiDomandaItem.IdSpesa.Value == IdSpesaEqualThis.Value))) && ((IdGiustificativoEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.IdGiustificativo != null) && (IntegrazioneSingolaDiDomandaItem.IdGiustificativo.Value == IdGiustificativoEqualThis.Value))) && ((IdAllegatoEqualThis == null) || ((IntegrazioneSingolaDiDomandaItem.IdAllegato != null) && (IntegrazioneSingolaDiDomandaItem.IdAllegato.Value == IdAllegatoEqualThis.Value))))
				{
					IntegrazioneSingolaDiDomandaCollectionTemp.Add(IntegrazioneSingolaDiDomandaItem);
				}
			}
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IntegrazioneSingolaDiDomandaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IntegrazioneSingolaDiDomandaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdSingolaIntegrazione", IntegrazioneSingolaDiDomandaObj.IdSingolaIntegrazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdIntegrazioneDomanda", IntegrazioneSingolaDiDomandaObj.IdIntegrazioneDomanda);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoIntegrazione", IntegrazioneSingolaDiDomandaObj.CodTipoIntegrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", IntegrazioneSingolaDiDomandaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", IntegrazioneSingolaDiDomandaObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfIstruttoreSingolaIntegrazione", IntegrazioneSingolaDiDomandaObj.CfIstruttoreSingolaIntegrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteIntegrazioneIstruttore", IntegrazioneSingolaDiDomandaObj.NoteIntegrazioneIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRichiestaIntegrazioneIstruttore", IntegrazioneSingolaDiDomandaObj.DataRichiestaIntegrazioneIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataConclusioneIstruttore", IntegrazioneSingolaDiDomandaObj.DataConclusioneIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "SingolaIntegrazioneCompletataIstruttore", IntegrazioneSingolaDiDomandaObj.SingolaIntegrazioneCompletataIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "CfBeneficiarioSingolaIntegrazione", IntegrazioneSingolaDiDomandaObj.CfBeneficiarioSingolaIntegrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteIntegrazioneBeneficiario", IntegrazioneSingolaDiDomandaObj.NoteIntegrazioneBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRilascioIntegrazioneBeneficiario", IntegrazioneSingolaDiDomandaObj.DataRilascioIntegrazioneBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "DataConclusioneBeneficiario", IntegrazioneSingolaDiDomandaObj.DataConclusioneBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "SingolaIntegrazioneCompletataBeneficiario", IntegrazioneSingolaDiDomandaObj.SingolaIntegrazioneCompletataBeneficiario);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSpesa", IntegrazioneSingolaDiDomandaObj.IdSpesa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdGiustificativo", IntegrazioneSingolaDiDomandaObj.IdGiustificativo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", IntegrazioneSingolaDiDomandaObj.IdAllegato);
		}
		//Insert
		private static int Insert(DbProvider db, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaInsert", new string[] {"IdIntegrazioneDomanda", "CodTipoIntegrazione", 
"DataInserimento", "DataModifica", "CfIstruttoreSingolaIntegrazione", 
"NoteIntegrazioneIstruttore", "DataRichiestaIntegrazioneIstruttore", "DataConclusioneIstruttore", 
"SingolaIntegrazioneCompletataIstruttore", "CfBeneficiarioSingolaIntegrazione", "NoteIntegrazioneBeneficiario", 
"DataRilascioIntegrazioneBeneficiario", "DataConclusioneBeneficiario", "SingolaIntegrazioneCompletataBeneficiario", 




"IdSpesa", "IdGiustificativo", "IdAllegato"}, new string[] {"int", "string", 
"DateTime", "DateTime", "string", 
"string", "DateTime", "DateTime", 
"bool", "string", "string", 
"DateTime", "DateTime", "bool", 




"int", "int", "int"},"");
				CompileIUCmd(false, insertCmd,IntegrazioneSingolaDiDomandaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj.IdSingolaIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SINGOLA_INTEGRAZIONE"]);
				IntegrazioneSingolaDiDomandaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				IntegrazioneSingolaDiDomandaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				IntegrazioneSingolaDiDomandaObj.SingolaIntegrazioneCompletataIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE"]);
				}
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaUpdate", new string[] {"IdSingolaIntegrazione", "IdIntegrazioneDomanda", "CodTipoIntegrazione", 
"DataInserimento", "DataModifica", "CfIstruttoreSingolaIntegrazione", 
"NoteIntegrazioneIstruttore", "DataRichiestaIntegrazioneIstruttore", "DataConclusioneIstruttore", 
"SingolaIntegrazioneCompletataIstruttore", "CfBeneficiarioSingolaIntegrazione", "NoteIntegrazioneBeneficiario", 
"DataRilascioIntegrazioneBeneficiario", "DataConclusioneBeneficiario", "SingolaIntegrazioneCompletataBeneficiario", 




"IdSpesa", "IdGiustificativo", "IdAllegato"}, new string[] {"int", "int", "string", 
"DateTime", "DateTime", "string", 
"string", "DateTime", "DateTime", 
"bool", "string", "string", 
"DateTime", "DateTime", "bool", 




"int", "int", "int"},"");
				CompileIUCmd(true, updateCmd,IntegrazioneSingolaDiDomandaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					IntegrazioneSingolaDiDomandaObj.DataModifica = d;
				}
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			switch (IntegrazioneSingolaDiDomandaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IntegrazioneSingolaDiDomandaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IntegrazioneSingolaDiDomandaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IntegrazioneSingolaDiDomandaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaUpdate", new string[] {"IdSingolaIntegrazione", "IdIntegrazioneDomanda", "CodTipoIntegrazione", 
"DataInserimento", "DataModifica", "CfIstruttoreSingolaIntegrazione", 
"NoteIntegrazioneIstruttore", "DataRichiestaIntegrazioneIstruttore", "DataConclusioneIstruttore", 
"SingolaIntegrazioneCompletataIstruttore", "CfBeneficiarioSingolaIntegrazione", "NoteIntegrazioneBeneficiario", 
"DataRilascioIntegrazioneBeneficiario", "DataConclusioneBeneficiario", "SingolaIntegrazioneCompletataBeneficiario", 




"IdSpesa", "IdGiustificativo", "IdAllegato"}, new string[] {"int", "int", "string", 
"DateTime", "DateTime", "string", 
"string", "DateTime", "DateTime", 
"bool", "string", "string", 
"DateTime", "DateTime", "bool", 




"int", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaInsert", new string[] {"IdIntegrazioneDomanda", "CodTipoIntegrazione", 
"DataInserimento", "DataModifica", "CfIstruttoreSingolaIntegrazione", 
"NoteIntegrazioneIstruttore", "DataRichiestaIntegrazioneIstruttore", "DataConclusioneIstruttore", 
"SingolaIntegrazioneCompletataIstruttore", "CfBeneficiarioSingolaIntegrazione", "NoteIntegrazioneBeneficiario", 
"DataRilascioIntegrazioneBeneficiario", "DataConclusioneBeneficiario", "SingolaIntegrazioneCompletataBeneficiario", 




"IdSpesa", "IdGiustificativo", "IdAllegato"}, new string[] {"int", "string", 
"DateTime", "DateTime", "string", 
"string", "DateTime", "DateTime", 
"bool", "string", "string", 
"DateTime", "DateTime", "bool", 




"int", "int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaDelete", new string[] {"IdSingolaIntegrazione"}, new string[] {"int"},"");
				for (int i = 0; i < IntegrazioneSingolaDiDomandaCollectionObj.Count; i++)
				{
					switch (IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IntegrazioneSingolaDiDomandaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IntegrazioneSingolaDiDomandaCollectionObj[i].IdSingolaIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SINGOLA_INTEGRAZIONE"]);
									IntegrazioneSingolaDiDomandaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									IntegrazioneSingolaDiDomandaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									IntegrazioneSingolaDiDomandaCollectionObj[i].SingolaIntegrazioneCompletataIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IntegrazioneSingolaDiDomandaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									IntegrazioneSingolaDiDomandaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IntegrazioneSingolaDiDomandaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSingolaIntegrazione", (SiarLibrary.NullTypes.IntNT)IntegrazioneSingolaDiDomandaCollectionObj[i].IdSingolaIntegrazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IntegrazioneSingolaDiDomandaCollectionObj.Count; i++)
				{
					if ((IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsDirty = false;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsPersistent = true;
					}
					if ((IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsDirty = false;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj)
		{
			int returnValue = 0;
			if (IntegrazioneSingolaDiDomandaObj.IsPersistent) 
			{
				returnValue = Delete(db, IntegrazioneSingolaDiDomandaObj.IdSingolaIntegrazione);
			}
			IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IntegrazioneSingolaDiDomandaObj.IsDirty = false;
			IntegrazioneSingolaDiDomandaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSingolaIntegrazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaDelete", new string[] {"IdSingolaIntegrazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSingolaIntegrazione", (SiarLibrary.NullTypes.IntNT)IdSingolaIntegrazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaDelete", new string[] {"IdSingolaIntegrazione"}, new string[] {"int"},"");
				for (int i = 0; i < IntegrazioneSingolaDiDomandaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdSingolaIntegrazione", IntegrazioneSingolaDiDomandaCollectionObj[i].IdSingolaIntegrazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IntegrazioneSingolaDiDomandaCollectionObj.Count; i++)
				{
					if ((IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IntegrazioneSingolaDiDomandaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsDirty = false;
						IntegrazioneSingolaDiDomandaCollectionObj[i].IsPersistent = false;
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
		public static IntegrazioneSingolaDiDomanda GetById(DbProvider db, int IdSingolaIntegrazioneValue)
		{
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIntegrazioneSingolaDiDomandaGetById", new string[] {"IdSingolaIntegrazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdSingolaIntegrazione", (SiarLibrary.NullTypes.IntNT)IdSingolaIntegrazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaObj;
		}

		//getFromDatareader
		public static IntegrazioneSingolaDiDomanda GetFromDatareader(DbProvider db)
		{
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj = new IntegrazioneSingolaDiDomanda();
			IntegrazioneSingolaDiDomandaObj.IdSingolaIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SINGOLA_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.IdIntegrazioneDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_DOMANDA"]);
			IntegrazioneSingolaDiDomandaObj.CodTipoIntegrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			IntegrazioneSingolaDiDomandaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			IntegrazioneSingolaDiDomandaObj.CfIstruttoreSingolaIntegrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.NoteIntegrazioneIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_INTEGRAZIONE_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.DataRichiestaIntegrazioneIstruttore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.DataConclusioneIstruttore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.SingolaIntegrazioneCompletataIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.CfBeneficiarioSingolaIntegrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.NoteIntegrazioneBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_INTEGRAZIONE_BENEFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.DataRilascioIntegrazioneBeneficiario = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.DataConclusioneBeneficiario = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE_BENEFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.SingolaIntegrazioneCompletataBeneficiario = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			IntegrazioneSingolaDiDomandaObj.DataInserimentoIntegrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.DataModificaIntegrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.IntegrazioneCompleta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTEGRAZIONE_COMPLETA"]);
			IntegrazioneSingolaDiDomandaObj.NoteIntegrazioneDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_INTEGRAZIONE_DOMANDA"]);
			IntegrazioneSingolaDiDomandaObj.CfIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.DataRichiestaIntegrazioneDomanda = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_INTEGRAZIONE_DOMANDA"]);
			IntegrazioneSingolaDiDomandaObj.SegnaturaIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ISTRUTTORE"]);
			IntegrazioneSingolaDiDomandaObj.CfBenficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_BENFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.SegnaturaBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_BENEFICIARIO"]);
			IntegrazioneSingolaDiDomandaObj.DataConclusioneIntegrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONCLUSIONE_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.DescrizioneTipoIntegrazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO_INTEGRAZIONE"]);
			IntegrazioneSingolaDiDomandaObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
			IntegrazioneSingolaDiDomandaObj.IdGiustificativo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GIUSTIFICATIVO"]);
			IntegrazioneSingolaDiDomandaObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IntegrazioneSingolaDiDomandaObj.IsDirty = false;
			IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
			return IntegrazioneSingolaDiDomandaObj;
		}

		//Find Select

		public static IntegrazioneSingolaDiDomandaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSingolaIntegrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoIntegrazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfIstruttoreSingolaIntegrazioneEqualThis, 
SiarLibrary.NullTypes.StringNT NoteIntegrazioneIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRichiestaIntegrazioneIstruttoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataConclusioneIstruttoreEqualThis, 
SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT CfBeneficiarioSingolaIntegrazioneEqualThis, SiarLibrary.NullTypes.StringNT NoteIntegrazioneBeneficiarioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRilascioIntegrazioneBeneficiarioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataConclusioneBeneficiarioEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, 
SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis)

		{

			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj = new IntegrazioneSingolaDiDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zintegrazionesingoladidomandafindselect", new string[] {"IdSingolaIntegrazioneequalthis", "IdIntegrazioneDomandaequalthis", "CodTipoIntegrazioneequalthis", 
"DataInserimentoequalthis", "DataModificaequalthis", "CfIstruttoreSingolaIntegrazioneequalthis", 
"NoteIntegrazioneIstruttoreequalthis", "DataRichiestaIntegrazioneIstruttoreequalthis", "DataConclusioneIstruttoreequalthis", 
"SingolaIntegrazioneCompletataIstruttoreequalthis", "CfBeneficiarioSingolaIntegrazioneequalthis", "NoteIntegrazioneBeneficiarioequalthis", 
"DataRilascioIntegrazioneBeneficiarioequalthis", "DataConclusioneBeneficiarioequalthis", "SingolaIntegrazioneCompletataBeneficiarioequalthis", 
"IdSpesaequalthis", "IdGiustificativoequalthis", "IdAllegatoequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "DateTime", "string", 
"string", "DateTime", "DateTime", 
"bool", "string", "string", 
"DateTime", "DateTime", "bool", 
"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSingolaIntegrazioneequalthis", IdSingolaIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneDomandaequalthis", IdIntegrazioneDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoIntegrazioneequalthis", CodTipoIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfIstruttoreSingolaIntegrazioneequalthis", CfIstruttoreSingolaIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteIntegrazioneIstruttoreequalthis", NoteIntegrazioneIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRichiestaIntegrazioneIstruttoreequalthis", DataRichiestaIntegrazioneIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataConclusioneIstruttoreequalthis", DataConclusioneIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataIstruttoreequalthis", SingolaIntegrazioneCompletataIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfBeneficiarioSingolaIntegrazioneequalthis", CfBeneficiarioSingolaIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteIntegrazioneBeneficiarioequalthis", NoteIntegrazioneBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRilascioIntegrazioneBeneficiarioequalthis", DataRilascioIntegrazioneBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataConclusioneBeneficiarioequalthis", DataConclusioneBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataBeneficiarioequalthis", SingolaIntegrazioneCompletataBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
				IntegrazioneSingolaDiDomandaCollectionObj.Add(IntegrazioneSingolaDiDomandaObj);
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaCollectionObj;
		}

		//Find Find

		public static IntegrazioneSingolaDiDomandaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdSingolaIntegrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoIntegrazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis)

		{

			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj = new IntegrazioneSingolaDiDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zintegrazionesingoladidomandafindfind", new string[] {"IdSingolaIntegrazioneequalthis", "IdIntegrazioneDomandaequalthis", "CodTipoIntegrazioneequalthis", 
"SingolaIntegrazioneCompletataIstruttoreequalthis", "SingolaIntegrazioneCompletataBeneficiarioequalthis", "IntegrazioneCompletaequalthis"}, new string[] {"int", "int", "string", 
"bool", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSingolaIntegrazioneequalthis", IdSingolaIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneDomandaequalthis", IdIntegrazioneDomandaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoIntegrazioneequalthis", CodTipoIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataIstruttoreequalthis", SingolaIntegrazioneCompletataIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataBeneficiarioequalthis", SingolaIntegrazioneCompletataBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
				IntegrazioneSingolaDiDomandaCollectionObj.Add(IntegrazioneSingolaDiDomandaObj);
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaCollectionObj;
		}

		//Find GetByIdSpesa

		public static IntegrazioneSingolaDiDomandaCollection GetByIdSpesa(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, 
SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis)

		{

			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj = new IntegrazioneSingolaDiDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zintegrazionesingoladidomandafindgetbyidspesa", new string[] {"IdSpesaequalthis", "SingolaIntegrazioneCompletataIstruttoreequalthis", "SingolaIntegrazioneCompletataBeneficiarioequalthis", 
"IntegrazioneCompletaequalthis"}, new string[] {"int", "bool", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataIstruttoreequalthis", SingolaIntegrazioneCompletataIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataBeneficiarioequalthis", SingolaIntegrazioneCompletataBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
				IntegrazioneSingolaDiDomandaCollectionObj.Add(IntegrazioneSingolaDiDomandaObj);
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaCollectionObj;
		}

		//Find GetByIdGiustificativo

		public static IntegrazioneSingolaDiDomandaCollection GetByIdGiustificativo(DbProvider db, SiarLibrary.NullTypes.IntNT IdGiustificativoEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, 
SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis)

		{

			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj = new IntegrazioneSingolaDiDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zintegrazionesingoladidomandafindgetbyidgiustificativo", new string[] {"IdGiustificativoequalthis", "SingolaIntegrazioneCompletataIstruttoreequalthis", "SingolaIntegrazioneCompletataBeneficiarioequalthis", 
"IntegrazioneCompletaequalthis"}, new string[] {"int", "bool", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGiustificativoequalthis", IdGiustificativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataIstruttoreequalthis", SingolaIntegrazioneCompletataIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataBeneficiarioequalthis", SingolaIntegrazioneCompletataBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
				IntegrazioneSingolaDiDomandaCollectionObj.Add(IntegrazioneSingolaDiDomandaObj);
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaCollectionObj;
		}

		//Find GetByIdAllegato

		public static IntegrazioneSingolaDiDomandaCollection GetByIdAllegato(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataIstruttoreEqualThis, SiarLibrary.NullTypes.BoolNT SingolaIntegrazioneCompletataBeneficiarioEqualThis, 
SiarLibrary.NullTypes.BoolNT IntegrazioneCompletaEqualThis)

		{

			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionObj = new IntegrazioneSingolaDiDomandaCollection();

			IDbCommand findCmd = db.InitCmd("Zintegrazionesingoladidomandafindgetbyidallegato", new string[] {"IdAllegatoequalthis", "SingolaIntegrazioneCompletataIstruttoreequalthis", "SingolaIntegrazioneCompletataBeneficiarioequalthis", 
"IntegrazioneCompletaequalthis"}, new string[] {"int", "bool", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataIstruttoreequalthis", SingolaIntegrazioneCompletataIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SingolaIntegrazioneCompletataBeneficiarioequalthis", SingolaIntegrazioneCompletataBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IntegrazioneCompletaequalthis", IntegrazioneCompletaEqualThis);
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IntegrazioneSingolaDiDomandaObj = GetFromDatareader(db);
				IntegrazioneSingolaDiDomandaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IntegrazioneSingolaDiDomandaObj.IsDirty = false;
				IntegrazioneSingolaDiDomandaObj.IsPersistent = true;
				IntegrazioneSingolaDiDomandaCollectionObj.Add(IntegrazioneSingolaDiDomandaObj);
			}
			db.Close();
			return IntegrazioneSingolaDiDomandaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IntegrazioneSingolaDiDomandaCollectionProvider:IIntegrazioneSingolaDiDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IntegrazioneSingolaDiDomandaCollectionProvider : IIntegrazioneSingolaDiDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IntegrazioneSingolaDiDomanda
		protected IntegrazioneSingolaDiDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IntegrazioneSingolaDiDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IntegrazioneSingolaDiDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public IntegrazioneSingolaDiDomandaCollectionProvider(IntNT IdsingolaintegrazioneEqualThis, IntNT IdintegrazionedomandaEqualThis, StringNT CodtipointegrazioneEqualThis, 
BoolNT SingolaintegrazionecompletataistruttoreEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, BoolNT IntegrazionecompletaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdsingolaintegrazioneEqualThis, IdintegrazionedomandaEqualThis, CodtipointegrazioneEqualThis, 
SingolaintegrazionecompletataistruttoreEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, IntegrazionecompletaEqualThis);
		}

		//Costruttore3: ha in input integrazionesingoladidomandaCollectionObj - non popola la collection
		public IntegrazioneSingolaDiDomandaCollectionProvider(IntegrazioneSingolaDiDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IntegrazioneSingolaDiDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IntegrazioneSingolaDiDomandaCollection(this);
		}

		//Get e Set
		public IntegrazioneSingolaDiDomandaCollection CollectionObj
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
		public int SaveCollection(IntegrazioneSingolaDiDomandaCollection collectionObj)
		{
			return IntegrazioneSingolaDiDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IntegrazioneSingolaDiDomanda integrazionesingoladidomandaObj)
		{
			return IntegrazioneSingolaDiDomandaDAL.Save(_dbProviderObj, integrazionesingoladidomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IntegrazioneSingolaDiDomandaCollection collectionObj)
		{
			return IntegrazioneSingolaDiDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IntegrazioneSingolaDiDomanda integrazionesingoladidomandaObj)
		{
			return IntegrazioneSingolaDiDomandaDAL.Delete(_dbProviderObj, integrazionesingoladidomandaObj);
		}

		//getById
		public IntegrazioneSingolaDiDomanda GetById(IntNT IdSingolaIntegrazioneValue)
		{
			IntegrazioneSingolaDiDomanda IntegrazioneSingolaDiDomandaTemp = IntegrazioneSingolaDiDomandaDAL.GetById(_dbProviderObj, IdSingolaIntegrazioneValue);
			if (IntegrazioneSingolaDiDomandaTemp!=null) IntegrazioneSingolaDiDomandaTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public IntegrazioneSingolaDiDomandaCollection Select(IntNT IdsingolaintegrazioneEqualThis, IntNT IdintegrazionedomandaEqualThis, StringNT CodtipointegrazioneEqualThis, 
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfistruttoresingolaintegrazioneEqualThis, 
StringNT NoteintegrazioneistruttoreEqualThis, DatetimeNT DatarichiestaintegrazioneistruttoreEqualThis, DatetimeNT DataconclusioneistruttoreEqualThis, 
BoolNT SingolaintegrazionecompletataistruttoreEqualThis, StringNT CfbeneficiariosingolaintegrazioneEqualThis, StringNT NoteintegrazionebeneficiarioEqualThis, 
DatetimeNT DatarilasciointegrazionebeneficiarioEqualThis, DatetimeNT DataconclusionebeneficiarioEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, 
IntNT IdspesaEqualThis, IntNT IdgiustificativoEqualThis, IntNT IdallegatoEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = IntegrazioneSingolaDiDomandaDAL.Select(_dbProviderObj, IdsingolaintegrazioneEqualThis, IdintegrazionedomandaEqualThis, CodtipointegrazioneEqualThis, 
DatainserimentoEqualThis, DatamodificaEqualThis, CfistruttoresingolaintegrazioneEqualThis, 
NoteintegrazioneistruttoreEqualThis, DatarichiestaintegrazioneistruttoreEqualThis, DataconclusioneistruttoreEqualThis, 
SingolaintegrazionecompletataistruttoreEqualThis, CfbeneficiariosingolaintegrazioneEqualThis, NoteintegrazionebeneficiarioEqualThis, 
DatarilasciointegrazionebeneficiarioEqualThis, DataconclusionebeneficiarioEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, 
IdspesaEqualThis, IdgiustificativoEqualThis, IdallegatoEqualThis);
			IntegrazioneSingolaDiDomandaCollectionTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}

		//Find: popola la collection
		public IntegrazioneSingolaDiDomandaCollection Find(IntNT IdsingolaintegrazioneEqualThis, IntNT IdintegrazionedomandaEqualThis, StringNT CodtipointegrazioneEqualThis, 
BoolNT SingolaintegrazionecompletataistruttoreEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, BoolNT IntegrazionecompletaEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = IntegrazioneSingolaDiDomandaDAL.Find(_dbProviderObj, IdsingolaintegrazioneEqualThis, IdintegrazionedomandaEqualThis, CodtipointegrazioneEqualThis, 
SingolaintegrazionecompletataistruttoreEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, IntegrazionecompletaEqualThis);
			IntegrazioneSingolaDiDomandaCollectionTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}

		//GetByIdSpesa: popola la collection
		public IntegrazioneSingolaDiDomandaCollection GetByIdSpesa(IntNT IdspesaEqualThis, BoolNT SingolaintegrazionecompletataistruttoreEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, 
BoolNT IntegrazionecompletaEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = IntegrazioneSingolaDiDomandaDAL.GetByIdSpesa(_dbProviderObj, IdspesaEqualThis, SingolaintegrazionecompletataistruttoreEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, 
IntegrazionecompletaEqualThis);
			IntegrazioneSingolaDiDomandaCollectionTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}

		//GetByIdGiustificativo: popola la collection
		public IntegrazioneSingolaDiDomandaCollection GetByIdGiustificativo(IntNT IdgiustificativoEqualThis, BoolNT SingolaintegrazionecompletataistruttoreEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, 
BoolNT IntegrazionecompletaEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = IntegrazioneSingolaDiDomandaDAL.GetByIdGiustificativo(_dbProviderObj, IdgiustificativoEqualThis, SingolaintegrazionecompletataistruttoreEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, 
IntegrazionecompletaEqualThis);
			IntegrazioneSingolaDiDomandaCollectionTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}

		//GetByIdAllegato: popola la collection
		public IntegrazioneSingolaDiDomandaCollection GetByIdAllegato(IntNT IdallegatoEqualThis, BoolNT SingolaintegrazionecompletataistruttoreEqualThis, BoolNT SingolaintegrazionecompletatabeneficiarioEqualThis, 
BoolNT IntegrazionecompletaEqualThis)
		{
			IntegrazioneSingolaDiDomandaCollection IntegrazioneSingolaDiDomandaCollectionTemp = IntegrazioneSingolaDiDomandaDAL.GetByIdAllegato(_dbProviderObj, IdallegatoEqualThis, SingolaintegrazionecompletataistruttoreEqualThis, SingolaintegrazionecompletatabeneficiarioEqualThis, 
IntegrazionecompletaEqualThis);
			IntegrazioneSingolaDiDomandaCollectionTemp.Provider = this;
			return IntegrazioneSingolaDiDomandaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<INTEGRAZIONE_SINGOLA_DI_DOMANDA>
  <ViewName>VINTEGRAZIONE_SINGOLA_DI_DOMANDA</ViewName>
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
      <ID_SINGOLA_INTEGRAZIONE>Equal</ID_SINGOLA_INTEGRAZIONE>
      <ID_INTEGRAZIONE_DOMANDA>Equal</ID_INTEGRAZIONE_DOMANDA>
      <COD_TIPO_INTEGRAZIONE>Equal</COD_TIPO_INTEGRAZIONE>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>
      <INTEGRAZIONE_COMPLETA>Equal</INTEGRAZIONE_COMPLETA>
    </Find>
    <GetByIdSpesa OrderBy="ORDER BY ">
      <ID_SPESA>Equal</ID_SPESA>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>
      <INTEGRAZIONE_COMPLETA>Equal</INTEGRAZIONE_COMPLETA>
    </GetByIdSpesa>
    <GetByIdGiustificativo OrderBy="ORDER BY ">
      <ID_GIUSTIFICATIVO>Equal</ID_GIUSTIFICATIVO>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>
      <INTEGRAZIONE_COMPLETA>Equal</INTEGRAZIONE_COMPLETA>
    </GetByIdGiustificativo>
    <GetByIdAllegato OrderBy="ORDER BY ">
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE>
      <SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>Equal</SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO>
      <INTEGRAZIONE_COMPLETA>Equal</INTEGRAZIONE_COMPLETA>
    </GetByIdAllegato>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INTEGRAZIONE_SINGOLA_DI_DOMANDA>
*/
