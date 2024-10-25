using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per IterProgettoModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIterProgettoModificheProvider
	{
		int Save(IterProgettoModifiche IterProgettoModificheObj);
		int SaveCollection(IterProgettoModificheCollection collectionObj);
		int Delete(IterProgettoModifiche IterProgettoModificheObj);
		int DeleteCollection(IterProgettoModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IterProgettoModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class IterProgettoModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdStep;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _CodEsitoRevisore;
		private NullTypes.DatetimeNT _DataRevisore;
		private NullTypes.StringNT _Revisore;
		private NullTypes.StringNT _NoteRevisore;
		private NullTypes.StringNT _EsitoIstruttore;
		private NullTypes.BoolNT _EsitoPositivoIstruttore;
		private NullTypes.StringNT _EsitoRevisore;
		private NullTypes.BoolNT _EsitoPositivoRevisore;
		private NullTypes.IntNT _IdBando;
		private NullTypes.BoolNT _SelezionataXRevisione;
		private NullTypes.IntNT _IdCheckList;
		private NullTypes.StringNT _CodFase;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.StringNT _Step;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _EscludiDaComunicazione;
		private NullTypes.BoolNT _IncludiVerbaleVis;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IIterProgettoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIterProgettoModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public IterProgettoModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStep
		{
			get { return _IdStep; }
			set {
				if (IdStep != value)
				{
					_IdStep = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ESITO
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsito
		{
			get { return _CodEsito; }
			set {
				if (CodEsito != value)
				{
					_CodEsito = value;
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
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:NTEXT
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
		/// Corrisponde al campo:COD_ESITO_REVISORE
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodEsitoRevisore
		{
			get { return _CodEsitoRevisore; }
			set {
				if (CodEsitoRevisore != value)
				{
					_CodEsitoRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_REVISORE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRevisore
		{
			get { return _DataRevisore; }
			set {
				if (DataRevisore != value)
				{
					_DataRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REVISORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Revisore
		{
			get { return _Revisore; }
			set {
				if (Revisore != value)
				{
					_Revisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_REVISORE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT NoteRevisore
		{
			get { return _NoteRevisore; }
			set {
				if (NoteRevisore != value)
				{
					_NoteRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_ISTRUTTORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT EsitoIstruttore
		{
			get { return _EsitoIstruttore; }
			set {
				if (EsitoIstruttore != value)
				{
					_EsitoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO_ISTRUTTORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivoIstruttore
		{
			get { return _EsitoPositivoIstruttore; }
			set {
				if (EsitoPositivoIstruttore != value)
				{
					_EsitoPositivoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_REVISORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT EsitoRevisore
		{
			get { return _EsitoRevisore; }
			set {
				if (EsitoRevisore != value)
				{
					_EsitoRevisore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESITO_POSITIVO_REVISORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivoRevisore
		{
			get { return _EsitoPositivoRevisore; }
			set {
				if (EsitoPositivoRevisore != value)
				{
					_EsitoPositivoRevisore = value;
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
		/// Corrisponde al campo:SELEZIONATA_X_REVISIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SelezionataXRevisione
		{
			get { return _SelezionataXRevisione; }
			set {
				if (SelezionataXRevisione != value)
				{
					_SelezionataXRevisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECK_LIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCheckList
		{
			get { return _IdCheckList; }
			set {
				if (IdCheckList != value)
				{
					_IdCheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STEP
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT Step
		{
			get { return _Step; }
			set {
				if (Step != value)
				{
					_Step = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set {
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set {
				if (CodeMethod != value)
				{
					_CodeMethod = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
		{
			get { return _ValMinimo; }
			set {
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
		{
			get { return _ValMassimo; }
			set {
				if (ValMassimo != value)
				{
					_ValMassimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESCLUDI_DA_COMUNICAZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EscludiDaComunicazione
		{
			get { return _EscludiDaComunicazione; }
			set {
				if (EscludiDaComunicazione != value)
				{
					_EscludiDaComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INCLUDI_VERBALE_VIS
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IncludiVerbaleVis
		{
			get { return _IncludiVerbaleVis; }
			set {
				if (IncludiVerbaleVis != value)
				{
					_IncludiVerbaleVis = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set {
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
					SetDirtyFlag();
				}
			}
		}



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
	/// Summary description for IterProgettoModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IterProgettoModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IterProgettoModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((IterProgettoModifiche) info.GetValue(i.ToString(),typeof(IterProgettoModifiche)));
			}
		}

		//Costruttore
		public IterProgettoModificheCollection()
		{
			this.ItemType = typeof(IterProgettoModifiche);
		}

		//Costruttore con provider
		public IterProgettoModificheCollection(IIterProgettoModificheProvider providerObj)
		{
			this.ItemType = typeof(IterProgettoModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IterProgettoModifiche this[int index]
		{
			get { return (IterProgettoModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IterProgettoModificheCollection GetChanges()
		{
			return (IterProgettoModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IIterProgettoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIterProgettoModificheProvider Provider
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
		public int Add(IterProgettoModifiche IterProgettoModificheObj)
		{
			if (IterProgettoModificheObj.Provider == null) IterProgettoModificheObj.Provider = this.Provider;
			return base.Add(IterProgettoModificheObj);
		}

		//AddCollection
		public void AddCollection(IterProgettoModificheCollection IterProgettoModificheCollectionObj)
		{
			foreach (IterProgettoModifiche IterProgettoModificheObj in IterProgettoModificheCollectionObj)
				this.Add(IterProgettoModificheObj);
		}

		//Insert
		public void Insert(int index, IterProgettoModifiche IterProgettoModificheObj)
		{
			if (IterProgettoModificheObj.Provider == null) IterProgettoModificheObj.Provider = this.Provider;
			base.Insert(index, IterProgettoModificheObj);
		}

		//CollectionGetById
		public IterProgettoModifiche CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public IterProgettoModificheCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdStepEqualThis, NullTypes.StringNT CodEsitoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.StringNT CodEsitoRevisoreEqualThis, 
NullTypes.DatetimeNT DataRevisoreEqualThis, NullTypes.StringNT RevisoreEqualThis, NullTypes.StringNT EsitoIstruttoreEqualThis, 
NullTypes.BoolNT EsitoPositivoIstruttoreEqualThis, NullTypes.StringNT EsitoRevisoreEqualThis, NullTypes.BoolNT EsitoPositivoRevisoreEqualThis, 
NullTypes.IntNT IdBandoEqualThis, NullTypes.BoolNT SelezionataXRevisioneEqualThis, NullTypes.IntNT IdCheckListEqualThis, 
NullTypes.StringNT CodFaseEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT ObbligatorioEqualThis, 
NullTypes.StringNT StepEqualThis, NullTypes.BoolNT AutomaticoEqualThis, NullTypes.StringNT QuerySqlEqualThis, 
NullTypes.StringNT QuerySqlPostEqualThis, NullTypes.StringNT CodeMethodEqualThis, NullTypes.StringNT UrlEqualThis, 
NullTypes.StringNT ValMinimoEqualThis, NullTypes.StringNT ValMassimoEqualThis, NullTypes.StringNT MisuraEqualThis, 
NullTypes.BoolNT EscludiDaComunicazioneEqualThis, NullTypes.BoolNT IncludiVerbaleVisEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdModificaEqualThis)
		{
			IterProgettoModificheCollection IterProgettoModificheCollectionTemp = new IterProgettoModificheCollection();
			foreach (IterProgettoModifiche IterProgettoModificheItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((IterProgettoModificheItem.IdProgetto != null) && (IterProgettoModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdStepEqualThis == null) || ((IterProgettoModificheItem.IdStep != null) && (IterProgettoModificheItem.IdStep.Value == IdStepEqualThis.Value))) && ((CodEsitoEqualThis == null) || ((IterProgettoModificheItem.CodEsito != null) && (IterProgettoModificheItem.CodEsito.Value == CodEsitoEqualThis.Value))) && 
((DataEqualThis == null) || ((IterProgettoModificheItem.Data != null) && (IterProgettoModificheItem.Data.Value == DataEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((IterProgettoModificheItem.CfOperatore != null) && (IterProgettoModificheItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((CodEsitoRevisoreEqualThis == null) || ((IterProgettoModificheItem.CodEsitoRevisore != null) && (IterProgettoModificheItem.CodEsitoRevisore.Value == CodEsitoRevisoreEqualThis.Value))) && 
((DataRevisoreEqualThis == null) || ((IterProgettoModificheItem.DataRevisore != null) && (IterProgettoModificheItem.DataRevisore.Value == DataRevisoreEqualThis.Value))) && ((RevisoreEqualThis == null) || ((IterProgettoModificheItem.Revisore != null) && (IterProgettoModificheItem.Revisore.Value == RevisoreEqualThis.Value))) && ((EsitoIstruttoreEqualThis == null) || ((IterProgettoModificheItem.EsitoIstruttore != null) && (IterProgettoModificheItem.EsitoIstruttore.Value == EsitoIstruttoreEqualThis.Value))) && 
((EsitoPositivoIstruttoreEqualThis == null) || ((IterProgettoModificheItem.EsitoPositivoIstruttore != null) && (IterProgettoModificheItem.EsitoPositivoIstruttore.Value == EsitoPositivoIstruttoreEqualThis.Value))) && ((EsitoRevisoreEqualThis == null) || ((IterProgettoModificheItem.EsitoRevisore != null) && (IterProgettoModificheItem.EsitoRevisore.Value == EsitoRevisoreEqualThis.Value))) && ((EsitoPositivoRevisoreEqualThis == null) || ((IterProgettoModificheItem.EsitoPositivoRevisore != null) && (IterProgettoModificheItem.EsitoPositivoRevisore.Value == EsitoPositivoRevisoreEqualThis.Value))) && 
((IdBandoEqualThis == null) || ((IterProgettoModificheItem.IdBando != null) && (IterProgettoModificheItem.IdBando.Value == IdBandoEqualThis.Value))) && ((SelezionataXRevisioneEqualThis == null) || ((IterProgettoModificheItem.SelezionataXRevisione != null) && (IterProgettoModificheItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) && ((IdCheckListEqualThis == null) || ((IterProgettoModificheItem.IdCheckList != null) && (IterProgettoModificheItem.IdCheckList.Value == IdCheckListEqualThis.Value))) && 
((CodFaseEqualThis == null) || ((IterProgettoModificheItem.CodFase != null) && (IterProgettoModificheItem.CodFase.Value == CodFaseEqualThis.Value))) && ((OrdineEqualThis == null) || ((IterProgettoModificheItem.Ordine != null) && (IterProgettoModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((ObbligatorioEqualThis == null) || ((IterProgettoModificheItem.Obbligatorio != null) && (IterProgettoModificheItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && 
((StepEqualThis == null) || ((IterProgettoModificheItem.Step != null) && (IterProgettoModificheItem.Step.Value == StepEqualThis.Value))) && ((AutomaticoEqualThis == null) || ((IterProgettoModificheItem.Automatico != null) && (IterProgettoModificheItem.Automatico.Value == AutomaticoEqualThis.Value))) && ((QuerySqlEqualThis == null) || ((IterProgettoModificheItem.QuerySql != null) && (IterProgettoModificheItem.QuerySql.Value == QuerySqlEqualThis.Value))) && 
((QuerySqlPostEqualThis == null) || ((IterProgettoModificheItem.QuerySqlPost != null) && (IterProgettoModificheItem.QuerySqlPost.Value == QuerySqlPostEqualThis.Value))) && ((CodeMethodEqualThis == null) || ((IterProgettoModificheItem.CodeMethod != null) && (IterProgettoModificheItem.CodeMethod.Value == CodeMethodEqualThis.Value))) && ((UrlEqualThis == null) || ((IterProgettoModificheItem.Url != null) && (IterProgettoModificheItem.Url.Value == UrlEqualThis.Value))) && 
((ValMinimoEqualThis == null) || ((IterProgettoModificheItem.ValMinimo != null) && (IterProgettoModificheItem.ValMinimo.Value == ValMinimoEqualThis.Value))) && ((ValMassimoEqualThis == null) || ((IterProgettoModificheItem.ValMassimo != null) && (IterProgettoModificheItem.ValMassimo.Value == ValMassimoEqualThis.Value))) && ((MisuraEqualThis == null) || ((IterProgettoModificheItem.Misura != null) && (IterProgettoModificheItem.Misura.Value == MisuraEqualThis.Value))) && 
((EscludiDaComunicazioneEqualThis == null) || ((IterProgettoModificheItem.EscludiDaComunicazione != null) && (IterProgettoModificheItem.EscludiDaComunicazione.Value == EscludiDaComunicazioneEqualThis.Value))) && ((IncludiVerbaleVisEqualThis == null) || ((IterProgettoModificheItem.IncludiVerbaleVis != null) && (IterProgettoModificheItem.IncludiVerbaleVis.Value == IncludiVerbaleVisEqualThis.Value))) && ((IdEqualThis == null) || ((IterProgettoModificheItem.Id != null) && (IterProgettoModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdModificaEqualThis == null) || ((IterProgettoModificheItem.IdModifica != null) && (IterProgettoModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					IterProgettoModificheCollectionTemp.Add(IterProgettoModificheItem);
				}
			}
			return IterProgettoModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IterProgettoModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IterProgettoModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IterProgettoModifiche IterProgettoModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", IterProgettoModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", IterProgettoModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdStep", IterProgettoModificheObj.IdStep);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", IterProgettoModificheObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", IterProgettoModificheObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", IterProgettoModificheObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", IterProgettoModificheObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsitoRevisore", IterProgettoModificheObj.CodEsitoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRevisore", IterProgettoModificheObj.DataRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "Revisore", IterProgettoModificheObj.Revisore);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteRevisore", IterProgettoModificheObj.NoteRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoIstruttore", IterProgettoModificheObj.EsitoIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoPositivoIstruttore", IterProgettoModificheObj.EsitoPositivoIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoRevisore", IterProgettoModificheObj.EsitoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoPositivoRevisore", IterProgettoModificheObj.EsitoPositivoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", IterProgettoModificheObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "SelezionataXRevisione", IterProgettoModificheObj.SelezionataXRevisione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCheckList", IterProgettoModificheObj.IdCheckList);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", IterProgettoModificheObj.CodFase);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", IterProgettoModificheObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", IterProgettoModificheObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "Step", IterProgettoModificheObj.Step);
			DbProvider.SetCmdParam(cmd,firstChar + "Automatico", IterProgettoModificheObj.Automatico);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", IterProgettoModificheObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySqlPost", IterProgettoModificheObj.QuerySqlPost);
			DbProvider.SetCmdParam(cmd,firstChar + "CodeMethod", IterProgettoModificheObj.CodeMethod);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", IterProgettoModificheObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMinimo", IterProgettoModificheObj.ValMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMassimo", IterProgettoModificheObj.ValMassimo);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", IterProgettoModificheObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "EscludiDaComunicazione", IterProgettoModificheObj.EscludiDaComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IncludiVerbaleVis", IterProgettoModificheObj.IncludiVerbaleVis);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", IterProgettoModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, IterProgettoModifiche IterProgettoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIterProgettoModificheInsert", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EsitoIstruttore", "EsitoPositivoIstruttore", 
"EsitoRevisore", "EsitoPositivoRevisore", "IdBando", 
"SelezionataXRevisione", "IdCheckList", "CodFase", 
"Ordine", "Obbligatorio", "Step", 
"Automatico", "QuerySql", "QuerySqlPost", 
"CodeMethod", "Url", "ValMinimo", 
"ValMassimo", "Misura", "EscludiDaComunicazione", 
"IncludiVerbaleVis", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "string", "bool", 
"string", "bool", "int", 
"bool", "int", "string", 
"int", "bool", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "bool", 
"bool", "int"},"");
				CompileIUCmd(false, insertCmd,IterProgettoModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IterProgettoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoModificheObj.IsDirty = false;
				IterProgettoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IterProgettoModifiche IterProgettoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIterProgettoModificheUpdate", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EsitoIstruttore", "EsitoPositivoIstruttore", 
"EsitoRevisore", "EsitoPositivoRevisore", "IdBando", 
"SelezionataXRevisione", "IdCheckList", "CodFase", 
"Ordine", "Obbligatorio", "Step", 
"Automatico", "QuerySql", "QuerySqlPost", 
"CodeMethod", "Url", "ValMinimo", 
"ValMassimo", "Misura", "EscludiDaComunicazione", 
"IncludiVerbaleVis", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "string", "bool", 
"string", "bool", "int", 
"bool", "int", "string", 
"int", "bool", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "bool", 
"bool", "int", "int"},"");
				CompileIUCmd(true, updateCmd,IterProgettoModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoModificheObj.IsDirty = false;
				IterProgettoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IterProgettoModifiche IterProgettoModificheObj)
		{
			switch (IterProgettoModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IterProgettoModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IterProgettoModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IterProgettoModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IterProgettoModificheCollection IterProgettoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIterProgettoModificheUpdate", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EsitoIstruttore", "EsitoPositivoIstruttore", 
"EsitoRevisore", "EsitoPositivoRevisore", "IdBando", 
"SelezionataXRevisione", "IdCheckList", "CodFase", 
"Ordine", "Obbligatorio", "Step", 
"Automatico", "QuerySql", "QuerySqlPost", 
"CodeMethod", "Url", "ValMinimo", 
"ValMassimo", "Misura", "EscludiDaComunicazione", 
"IncludiVerbaleVis", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "string", "bool", 
"string", "bool", "int", 
"bool", "int", "string", 
"int", "bool", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "bool", 
"bool", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZIterProgettoModificheInsert", new string[] {"IdProgetto", "IdStep", "CodEsito", 
"Data", "CfOperatore", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EsitoIstruttore", "EsitoPositivoIstruttore", 
"EsitoRevisore", "EsitoPositivoRevisore", "IdBando", 
"SelezionataXRevisione", "IdCheckList", "CodFase", 
"Ordine", "Obbligatorio", "Step", 
"Automatico", "QuerySql", "QuerySqlPost", 
"CodeMethod", "Url", "ValMinimo", 
"ValMassimo", "Misura", "EscludiDaComunicazione", 
"IncludiVerbaleVis", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "string", "bool", 
"string", "bool", "int", 
"bool", "int", "string", 
"int", "bool", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"string", "string", "bool", 
"bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < IterProgettoModificheCollectionObj.Count; i++)
				{
					switch (IterProgettoModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IterProgettoModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IterProgettoModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IterProgettoModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IterProgettoModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IterProgettoModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IterProgettoModificheCollectionObj.Count; i++)
				{
					if ((IterProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IterProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IterProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IterProgettoModificheCollectionObj[i].IsDirty = false;
						IterProgettoModificheCollectionObj[i].IsPersistent = true;
					}
					if ((IterProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IterProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IterProgettoModificheCollectionObj[i].IsDirty = false;
						IterProgettoModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IterProgettoModifiche IterProgettoModificheObj)
		{
			int returnValue = 0;
			if (IterProgettoModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, IterProgettoModificheObj.Id);
			}
			IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IterProgettoModificheObj.IsDirty = false;
			IterProgettoModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IterProgettoModificheCollection IterProgettoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIterProgettoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < IterProgettoModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", IterProgettoModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IterProgettoModificheCollectionObj.Count; i++)
				{
					if ((IterProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IterProgettoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IterProgettoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IterProgettoModificheCollectionObj[i].IsDirty = false;
						IterProgettoModificheCollectionObj[i].IsPersistent = false;
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
		public static IterProgettoModifiche GetById(DbProvider db, int IdValue)
		{
			IterProgettoModifiche IterProgettoModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIterProgettoModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IterProgettoModificheObj = GetFromDatareader(db);
				IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoModificheObj.IsDirty = false;
				IterProgettoModificheObj.IsPersistent = true;
			}
			db.Close();
			return IterProgettoModificheObj;
		}

		//getFromDatareader
		public static IterProgettoModifiche GetFromDatareader(DbProvider db)
		{
			IterProgettoModifiche IterProgettoModificheObj = new IterProgettoModifiche();
			IterProgettoModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			IterProgettoModificheObj.IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
			IterProgettoModificheObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			IterProgettoModificheObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			IterProgettoModificheObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			IterProgettoModificheObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			IterProgettoModificheObj.CodEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_REVISORE"]);
			IterProgettoModificheObj.DataRevisore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REVISORE"]);
			IterProgettoModificheObj.Revisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["REVISORE"]);
			IterProgettoModificheObj.NoteRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_REVISORE"]);
			IterProgettoModificheObj.EsitoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_ISTRUTTORE"]);
			IterProgettoModificheObj.EsitoPositivoIstruttore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_ISTRUTTORE"]);
			IterProgettoModificheObj.EsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO_REVISORE"]);
			IterProgettoModificheObj.EsitoPositivoRevisore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_REVISORE"]);
			IterProgettoModificheObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			IterProgettoModificheObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			IterProgettoModificheObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
			IterProgettoModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			IterProgettoModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			IterProgettoModificheObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			IterProgettoModificheObj.Step = new SiarLibrary.NullTypes.StringNT(db.DataReader["STEP"]);
			IterProgettoModificheObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			IterProgettoModificheObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			IterProgettoModificheObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			IterProgettoModificheObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			IterProgettoModificheObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			IterProgettoModificheObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			IterProgettoModificheObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			IterProgettoModificheObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			IterProgettoModificheObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
			IterProgettoModificheObj.IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
			IterProgettoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			IterProgettoModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IterProgettoModificheObj.IsDirty = false;
			IterProgettoModificheObj.IsPersistent = true;
			return IterProgettoModificheObj;
		}

		//Find Select

		public static IterProgettoModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRevisoreEqualThis, SiarLibrary.NullTypes.StringNT RevisoreEqualThis, SiarLibrary.NullTypes.StringNT EsitoIstruttoreEqualThis, 
SiarLibrary.NullTypes.BoolNT EsitoPositivoIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT EsitoRevisoreEqualThis, SiarLibrary.NullTypes.BoolNT EsitoPositivoRevisoreEqualThis, 
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, 
SiarLibrary.NullTypes.StringNT StepEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlPostEqualThis, SiarLibrary.NullTypes.StringNT CodeMethodEqualThis, SiarLibrary.NullTypes.StringNT UrlEqualThis, 
SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, SiarLibrary.NullTypes.StringNT ValMassimoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis, 
SiarLibrary.NullTypes.BoolNT EscludiDaComunicazioneEqualThis, SiarLibrary.NullTypes.BoolNT IncludiVerbaleVisEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			IterProgettoModificheCollection IterProgettoModificheCollectionObj = new IterProgettoModificheCollection();

			IDbCommand findCmd = db.InitCmd("Ziterprogettomodifichefindselect", new string[] {"IdProgettoequalthis", "IdStepequalthis", "CodEsitoequalthis", 
"Dataequalthis", "CfOperatoreequalthis", "CodEsitoRevisoreequalthis", 
"DataRevisoreequalthis", "Revisoreequalthis", "EsitoIstruttoreequalthis", 
"EsitoPositivoIstruttoreequalthis", "EsitoRevisoreequalthis", "EsitoPositivoRevisoreequalthis", 
"IdBandoequalthis", "SelezionataXRevisioneequalthis", "IdCheckListequalthis", 
"CodFaseequalthis", "Ordineequalthis", "Obbligatorioequalthis", 
"Stepequalthis", "Automaticoequalthis", "QuerySqlequalthis", 
"QuerySqlPostequalthis", "CodeMethodequalthis", "Urlequalthis", 
"ValMinimoequalthis", "ValMassimoequalthis", "Misuraequalthis", 
"EscludiDaComunicazioneequalthis", "IncludiVerbaleVisequalthis", "Idequalthis", 
"IdModificaequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"bool", "string", "bool", 
"int", "bool", "int", 
"string", "int", "bool", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "string", 
"bool", "bool", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRevisoreequalthis", DataRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Revisoreequalthis", RevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoIstruttoreequalthis", EsitoIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoPositivoIstruttoreequalthis", EsitoPositivoIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoRevisoreequalthis", EsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoPositivoRevisoreequalthis", EsitoPositivoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Stepequalthis", StepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlPostequalthis", QuerySqlPostEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodeMethodequalthis", CodeMethodEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EscludiDaComunicazioneequalthis", EscludiDaComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IncludiVerbaleVisequalthis", IncludiVerbaleVisEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			IterProgettoModifiche IterProgettoModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IterProgettoModificheObj = GetFromDatareader(db);
				IterProgettoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IterProgettoModificheObj.IsDirty = false;
				IterProgettoModificheObj.IsPersistent = true;
				IterProgettoModificheCollectionObj.Add(IterProgettoModificheObj);
			}
			db.Close();
			return IterProgettoModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IterProgettoModificheCollectionProvider:IIterProgettoModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IterProgettoModificheCollectionProvider : IIterProgettoModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IterProgettoModifiche
		protected IterProgettoModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IterProgettoModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IterProgettoModificheCollection(this);
		}

		//Costruttore3: ha in input iterprogettomodificheCollectionObj - non popola la collection
		public IterProgettoModificheCollectionProvider(IterProgettoModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IterProgettoModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IterProgettoModificheCollection(this);
		}

		//Get e Set
		public IterProgettoModificheCollection CollectionObj
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
		public int SaveCollection(IterProgettoModificheCollection collectionObj)
		{
			return IterProgettoModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IterProgettoModifiche iterprogettomodificheObj)
		{
			return IterProgettoModificheDAL.Save(_dbProviderObj, iterprogettomodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IterProgettoModificheCollection collectionObj)
		{
			return IterProgettoModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IterProgettoModifiche iterprogettomodificheObj)
		{
			return IterProgettoModificheDAL.Delete(_dbProviderObj, iterprogettomodificheObj);
		}

		//getById
		public IterProgettoModifiche GetById(IntNT IdValue)
		{
			IterProgettoModifiche IterProgettoModificheTemp = IterProgettoModificheDAL.GetById(_dbProviderObj, IdValue);
			if (IterProgettoModificheTemp!=null) IterProgettoModificheTemp.Provider = this;
			return IterProgettoModificheTemp;
		}

		//Select: popola la collection
		public IterProgettoModificheCollection Select(IntNT IdprogettoEqualThis, IntNT IdstepEqualThis, StringNT CodesitoEqualThis, 
DatetimeNT DataEqualThis, StringNT CfoperatoreEqualThis, StringNT CodesitorevisoreEqualThis, 
DatetimeNT DatarevisoreEqualThis, StringNT RevisoreEqualThis, StringNT EsitoistruttoreEqualThis, 
BoolNT EsitopositivoistruttoreEqualThis, StringNT EsitorevisoreEqualThis, BoolNT EsitopositivorevisoreEqualThis, 
IntNT IdbandoEqualThis, BoolNT SelezionataxrevisioneEqualThis, IntNT IdchecklistEqualThis, 
StringNT CodfaseEqualThis, IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, 
StringNT StepEqualThis, BoolNT AutomaticoEqualThis, StringNT QuerysqlEqualThis, 
StringNT QuerysqlpostEqualThis, StringNT CodemethodEqualThis, StringNT UrlEqualThis, 
StringNT ValminimoEqualThis, StringNT ValmassimoEqualThis, StringNT MisuraEqualThis, 
BoolNT EscludidacomunicazioneEqualThis, BoolNT IncludiverbalevisEqualThis, IntNT IdEqualThis, 
IntNT IdmodificaEqualThis)
		{
			IterProgettoModificheCollection IterProgettoModificheCollectionTemp = IterProgettoModificheDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdstepEqualThis, CodesitoEqualThis, 
DataEqualThis, CfoperatoreEqualThis, CodesitorevisoreEqualThis, 
DatarevisoreEqualThis, RevisoreEqualThis, EsitoistruttoreEqualThis, 
EsitopositivoistruttoreEqualThis, EsitorevisoreEqualThis, EsitopositivorevisoreEqualThis, 
IdbandoEqualThis, SelezionataxrevisioneEqualThis, IdchecklistEqualThis, 
CodfaseEqualThis, OrdineEqualThis, ObbligatorioEqualThis, 
StepEqualThis, AutomaticoEqualThis, QuerysqlEqualThis, 
QuerysqlpostEqualThis, CodemethodEqualThis, UrlEqualThis, 
ValminimoEqualThis, ValmassimoEqualThis, MisuraEqualThis, 
EscludidacomunicazioneEqualThis, IncludiverbalevisEqualThis, IdEqualThis, 
IdmodificaEqualThis);
			IterProgettoModificheCollectionTemp.Provider = this;
			return IterProgettoModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ITER_PROGETTO_MODIFICHE>
  <ViewName>
  </ViewName>
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
</ITER_PROGETTO_MODIFICHE>
*/
