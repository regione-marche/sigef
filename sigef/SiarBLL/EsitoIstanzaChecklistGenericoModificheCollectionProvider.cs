using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per EsitoIstanzaChecklistGenericoModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IEsitoIstanzaChecklistGenericoModificheProvider
	{
		int Save(EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj);
		int SaveCollection(EsitoIstanzaChecklistGenericoModificheCollection collectionObj);
		int Delete(EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj);
		int DeleteCollection(EsitoIstanzaChecklistGenericoModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for EsitoIstanzaChecklistGenericoModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class EsitoIstanzaChecklistGenericoModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdEsitoGenerico;
		private NullTypes.IntNT _IdVoceGenerica;
		private NullTypes.IntNT _IdIstanzaGenerica;
		private NullTypes.StringNT _CodEsito;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _CodEsitoRevisore;
		private NullTypes.DatetimeNT _DataRevisore;
		private NullTypes.StringNT _Revisore;
		private NullTypes.StringNT _NoteRevisore;
		private NullTypes.BoolNT _EscludiDaComunicazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _EsitoPositivo;
		private NullTypes.StringNT _DescrizioneEsitoRevisore;
		private NullTypes.BoolNT _EsitoPositivoRevisore;
		private NullTypes.StringNT _DescrizioneVoceGenerica;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.DecimalNT _Peso;
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.StringNT _DescrizioneChecklistGenerica;
		private NullTypes.StringNT _Valore;
		private NullTypes.BoolNT _ValEsitoNegativo;
		private NullTypes.StringNT _Misura;
		private NullTypes.IntNT _IdVoceXChecklistGenerica;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IEsitoIstanzaChecklistGenericoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IEsitoIstanzaChecklistGenericoModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public EsitoIstanzaChecklistGenericoModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ESITO_GENERICO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdEsitoGenerico
		{
			get { return _IdEsitoGenerico; }
			set {
				if (IdEsitoGenerico != value)
				{
					_IdEsitoGenerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VOCE_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVoceGenerica
		{
			get { return _IdVoceGenerica; }
			set {
				if (IdVoceGenerica != value)
				{
					_IdVoceGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ISTANZA_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstanzaGenerica
		{
			get { return _IdIstanzaGenerica; }
			set {
				if (IdIstanzaGenerica != value)
				{
					_IdIstanzaGenerica = value;
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
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:CHAR(16)
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:CHAR(16)
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(50)
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
		/// Corrisponde al campo:ESITO_POSITIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT EsitoPositivo
		{
			get { return _EsitoPositivo; }
			set {
				if (EsitoPositivo != value)
				{
					_EsitoPositivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ESITO_REVISORE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DescrizioneEsitoRevisore
		{
			get { return _DescrizioneEsitoRevisore; }
			set {
				if (DescrizioneEsitoRevisore != value)
				{
					_DescrizioneEsitoRevisore = value;
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
		/// Corrisponde al campo:DESCRIZIONE_VOCE_GENERICA
		/// Tipo sul db:VARCHAR(8000)
		/// </summary>
		public NullTypes.StringNT DescrizioneVoceGenerica
		{
			get { return _DescrizioneVoceGenerica; }
			set {
				if (DescrizioneVoceGenerica != value)
				{
					_DescrizioneVoceGenerica = value;
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
		/// Tipo sul db:VARCHAR(8000)
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
		/// Corrisponde al campo:PESO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Peso
		{
			get { return _Peso; }
			set {
				if (Peso != value)
				{
					_Peso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistGenerica
		{
			get { return _IdChecklistGenerica; }
			set {
				if (IdChecklistGenerica != value)
				{
					_IdChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_CHECKLIST_GENERICA
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneChecklistGenerica
		{
			get { return _DescrizioneChecklistGenerica; }
			set {
				if (DescrizioneChecklistGenerica != value)
				{
					_DescrizioneChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Valore
		{
			get { return _Valore; }
			set {
				if (Valore != value)
				{
					_Valore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_ESITO_NEGATIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ValEsitoNegativo
		{
			get { return _ValEsitoNegativo; }
			set {
				if (ValEsitoNegativo != value)
				{
					_ValEsitoNegativo = value;
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
		/// Corrisponde al campo:ID_VOCE_X_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVoceXChecklistGenerica
		{
			get { return _IdVoceXChecklistGenerica; }
			set {
				if (IdVoceXChecklistGenerica != value)
				{
					_IdVoceXChecklistGenerica = value;
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
	/// Summary description for EsitoIstanzaChecklistGenericoModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class EsitoIstanzaChecklistGenericoModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private EsitoIstanzaChecklistGenericoModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((EsitoIstanzaChecklistGenericoModifiche) info.GetValue(i.ToString(),typeof(EsitoIstanzaChecklistGenericoModifiche)));
			}
		}

		//Costruttore
		public EsitoIstanzaChecklistGenericoModificheCollection()
		{
			this.ItemType = typeof(EsitoIstanzaChecklistGenericoModifiche);
		}

		//Costruttore con provider
		public EsitoIstanzaChecklistGenericoModificheCollection(IEsitoIstanzaChecklistGenericoModificheProvider providerObj)
		{
			this.ItemType = typeof(EsitoIstanzaChecklistGenericoModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new EsitoIstanzaChecklistGenericoModifiche this[int index]
		{
			get { return (EsitoIstanzaChecklistGenericoModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new EsitoIstanzaChecklistGenericoModificheCollection GetChanges()
		{
			return (EsitoIstanzaChecklistGenericoModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IEsitoIstanzaChecklistGenericoModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IEsitoIstanzaChecklistGenericoModificheProvider Provider
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
		public int Add(EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			if (EsitoIstanzaChecklistGenericoModificheObj.Provider == null) EsitoIstanzaChecklistGenericoModificheObj.Provider = this.Provider;
			return base.Add(EsitoIstanzaChecklistGenericoModificheObj);
		}

		//AddCollection
		public void AddCollection(EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionObj)
		{
			foreach (EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj in EsitoIstanzaChecklistGenericoModificheCollectionObj)
				this.Add(EsitoIstanzaChecklistGenericoModificheObj);
		}

		//Insert
		public void Insert(int index, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			if (EsitoIstanzaChecklistGenericoModificheObj.Provider == null) EsitoIstanzaChecklistGenericoModificheObj.Provider = this.Provider;
			base.Insert(index, EsitoIstanzaChecklistGenericoModificheObj);
		}

		//CollectionGetById
		public EsitoIstanzaChecklistGenericoModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public EsitoIstanzaChecklistGenericoModificheCollection SubSelect(NullTypes.IntNT IdEsitoGenericoEqualThis, NullTypes.IntNT IdVoceGenericaEqualThis, NullTypes.IntNT IdIstanzaGenericaEqualThis, 
NullTypes.StringNT CodEsitoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.StringNT CodEsitoRevisoreEqualThis, 
NullTypes.DatetimeNT DataRevisoreEqualThis, NullTypes.StringNT RevisoreEqualThis, NullTypes.BoolNT EscludiDaComunicazioneEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT EsitoPositivoEqualThis, NullTypes.StringNT DescrizioneEsitoRevisoreEqualThis, 
NullTypes.BoolNT EsitoPositivoRevisoreEqualThis, NullTypes.StringNT DescrizioneVoceGenericaEqualThis, NullTypes.BoolNT AutomaticoEqualThis, 
NullTypes.StringNT QuerySqlEqualThis, NullTypes.StringNT QuerySqlPostEqualThis, NullTypes.StringNT CodeMethodEqualThis, 
NullTypes.StringNT UrlEqualThis, NullTypes.StringNT ValMinimoEqualThis, NullTypes.StringNT ValMassimoEqualThis, 
NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.DecimalNT PesoEqualThis, 
NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.StringNT DescrizioneChecklistGenericaEqualThis, NullTypes.StringNT ValoreEqualThis, 
NullTypes.BoolNT ValEsitoNegativoEqualThis, NullTypes.StringNT MisuraEqualThis, NullTypes.IntNT IdVoceXChecklistGenericaEqualThis, 
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionTemp = new EsitoIstanzaChecklistGenericoModificheCollection();
			foreach (EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheItem in this)
			{
				if (((IdEsitoGenericoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdEsitoGenerico != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdEsitoGenerico.Value == IdEsitoGenericoEqualThis.Value))) && ((IdVoceGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdVoceGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdVoceGenerica.Value == IdVoceGenericaEqualThis.Value))) && ((IdIstanzaGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdIstanzaGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdIstanzaGenerica.Value == IdIstanzaGenericaEqualThis.Value))) && 
((CodEsitoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.CodEsito != null) && (EsitoIstanzaChecklistGenericoModificheItem.CodEsito.Value == CodEsitoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DataInserimento != null) && (EsitoIstanzaChecklistGenericoModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.CfInserimento != null) && (EsitoIstanzaChecklistGenericoModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DataModifica != null) && (EsitoIstanzaChecklistGenericoModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.CfModifica != null) && (EsitoIstanzaChecklistGenericoModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((CodEsitoRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.CodEsitoRevisore != null) && (EsitoIstanzaChecklistGenericoModificheItem.CodEsitoRevisore.Value == CodEsitoRevisoreEqualThis.Value))) && 
((DataRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DataRevisore != null) && (EsitoIstanzaChecklistGenericoModificheItem.DataRevisore.Value == DataRevisoreEqualThis.Value))) && ((RevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Revisore != null) && (EsitoIstanzaChecklistGenericoModificheItem.Revisore.Value == RevisoreEqualThis.Value))) && ((EscludiDaComunicazioneEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.EscludiDaComunicazione != null) && (EsitoIstanzaChecklistGenericoModificheItem.EscludiDaComunicazione.Value == EscludiDaComunicazioneEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Descrizione != null) && (EsitoIstanzaChecklistGenericoModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((EsitoPositivoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.EsitoPositivo != null) && (EsitoIstanzaChecklistGenericoModificheItem.EsitoPositivo.Value == EsitoPositivoEqualThis.Value))) && ((DescrizioneEsitoRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DescrizioneEsitoRevisore != null) && (EsitoIstanzaChecklistGenericoModificheItem.DescrizioneEsitoRevisore.Value == DescrizioneEsitoRevisoreEqualThis.Value))) && 
((EsitoPositivoRevisoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.EsitoPositivoRevisore != null) && (EsitoIstanzaChecklistGenericoModificheItem.EsitoPositivoRevisore.Value == EsitoPositivoRevisoreEqualThis.Value))) && ((DescrizioneVoceGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DescrizioneVoceGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.DescrizioneVoceGenerica.Value == DescrizioneVoceGenericaEqualThis.Value))) && ((AutomaticoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Automatico != null) && (EsitoIstanzaChecklistGenericoModificheItem.Automatico.Value == AutomaticoEqualThis.Value))) && 
((QuerySqlEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.QuerySql != null) && (EsitoIstanzaChecklistGenericoModificheItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((QuerySqlPostEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.QuerySqlPost != null) && (EsitoIstanzaChecklistGenericoModificheItem.QuerySqlPost.Value == QuerySqlPostEqualThis.Value))) && ((CodeMethodEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.CodeMethod != null) && (EsitoIstanzaChecklistGenericoModificheItem.CodeMethod.Value == CodeMethodEqualThis.Value))) && 
((UrlEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Url != null) && (EsitoIstanzaChecklistGenericoModificheItem.Url.Value == UrlEqualThis.Value))) && ((ValMinimoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.ValMinimo != null) && (EsitoIstanzaChecklistGenericoModificheItem.ValMinimo.Value == ValMinimoEqualThis.Value))) && ((ValMassimoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.ValMassimo != null) && (EsitoIstanzaChecklistGenericoModificheItem.ValMassimo.Value == ValMassimoEqualThis.Value))) && 
((OrdineEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Ordine != null) && (EsitoIstanzaChecklistGenericoModificheItem.Ordine.Value == OrdineEqualThis.Value))) && ((ObbligatorioEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Obbligatorio != null) && (EsitoIstanzaChecklistGenericoModificheItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((PesoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Peso != null) && (EsitoIstanzaChecklistGenericoModificheItem.Peso.Value == PesoEqualThis.Value))) && 
((IdChecklistGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdChecklistGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((DescrizioneChecklistGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.DescrizioneChecklistGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.DescrizioneChecklistGenerica.Value == DescrizioneChecklistGenericaEqualThis.Value))) && ((ValoreEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Valore != null) && (EsitoIstanzaChecklistGenericoModificheItem.Valore.Value == ValoreEqualThis.Value))) && 
((ValEsitoNegativoEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.ValEsitoNegativo != null) && (EsitoIstanzaChecklistGenericoModificheItem.ValEsitoNegativo.Value == ValEsitoNegativoEqualThis.Value))) && ((MisuraEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Misura != null) && (EsitoIstanzaChecklistGenericoModificheItem.Misura.Value == MisuraEqualThis.Value))) && ((IdVoceXChecklistGenericaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdVoceXChecklistGenerica != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdVoceXChecklistGenerica.Value == IdVoceXChecklistGenericaEqualThis.Value))) && 
((IdEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.Id != null) && (EsitoIstanzaChecklistGenericoModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((EsitoIstanzaChecklistGenericoModificheItem.IdModifica != null) && (EsitoIstanzaChecklistGenericoModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					EsitoIstanzaChecklistGenericoModificheCollectionTemp.Add(EsitoIstanzaChecklistGenericoModificheItem);
				}
			}
			return EsitoIstanzaChecklistGenericoModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for EsitoIstanzaChecklistGenericoModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class EsitoIstanzaChecklistGenericoModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", EsitoIstanzaChecklistGenericoModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdEsitoGenerico", EsitoIstanzaChecklistGenericoModificheObj.IdEsitoGenerico);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVoceGenerica", EsitoIstanzaChecklistGenericoModificheObj.IdVoceGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIstanzaGenerica", EsitoIstanzaChecklistGenericoModificheObj.IdIstanzaGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsito", EsitoIstanzaChecklistGenericoModificheObj.CodEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", EsitoIstanzaChecklistGenericoModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", EsitoIstanzaChecklistGenericoModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", EsitoIstanzaChecklistGenericoModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", EsitoIstanzaChecklistGenericoModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", EsitoIstanzaChecklistGenericoModificheObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEsitoRevisore", EsitoIstanzaChecklistGenericoModificheObj.CodEsitoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRevisore", EsitoIstanzaChecklistGenericoModificheObj.DataRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "Revisore", EsitoIstanzaChecklistGenericoModificheObj.Revisore);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteRevisore", EsitoIstanzaChecklistGenericoModificheObj.NoteRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "EscludiDaComunicazione", EsitoIstanzaChecklistGenericoModificheObj.EscludiDaComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", EsitoIstanzaChecklistGenericoModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoPositivo", EsitoIstanzaChecklistGenericoModificheObj.EsitoPositivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneEsitoRevisore", EsitoIstanzaChecklistGenericoModificheObj.DescrizioneEsitoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "EsitoPositivoRevisore", EsitoIstanzaChecklistGenericoModificheObj.EsitoPositivoRevisore);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneVoceGenerica", EsitoIstanzaChecklistGenericoModificheObj.DescrizioneVoceGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "Automatico", EsitoIstanzaChecklistGenericoModificheObj.Automatico);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", EsitoIstanzaChecklistGenericoModificheObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySqlPost", EsitoIstanzaChecklistGenericoModificheObj.QuerySqlPost);
			DbProvider.SetCmdParam(cmd,firstChar + "CodeMethod", EsitoIstanzaChecklistGenericoModificheObj.CodeMethod);
			DbProvider.SetCmdParam(cmd,firstChar + "Url", EsitoIstanzaChecklistGenericoModificheObj.Url);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMinimo", EsitoIstanzaChecklistGenericoModificheObj.ValMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "ValMassimo", EsitoIstanzaChecklistGenericoModificheObj.ValMassimo);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", EsitoIstanzaChecklistGenericoModificheObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", EsitoIstanzaChecklistGenericoModificheObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", EsitoIstanzaChecklistGenericoModificheObj.Peso);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistGenerica", EsitoIstanzaChecklistGenericoModificheObj.IdChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneChecklistGenerica", EsitoIstanzaChecklistGenericoModificheObj.DescrizioneChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", EsitoIstanzaChecklistGenericoModificheObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValEsitoNegativo", EsitoIstanzaChecklistGenericoModificheObj.ValEsitoNegativo);
			DbProvider.SetCmdParam(cmd,firstChar + "Misura", EsitoIstanzaChecklistGenericoModificheObj.Misura);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVoceXChecklistGenerica", EsitoIstanzaChecklistGenericoModificheObj.IdVoceXChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", EsitoIstanzaChecklistGenericoModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheInsert", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", "Descrizione", 
"EsitoPositivo", "DescrizioneEsitoRevisore", "EsitoPositivoRevisore", 
"DescrizioneVoceGenerica", "Automatico", "QuerySql", 
"QuerySqlPost", "CodeMethod", "Url", 
"ValMinimo", "ValMassimo", "Ordine", 
"Obbligatorio", "Peso", "IdChecklistGenerica", 
"DescrizioneChecklistGenerica", "Valore", "ValEsitoNegativo", 
"Misura", "IdVoceXChecklistGenerica", 
"IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"bool", "string", "bool", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "int", 
"bool", "decimal", "int", 
"string", "string", "bool", 
"string", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,EsitoIstanzaChecklistGenericoModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				EsitoIstanzaChecklistGenericoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
				EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheUpdate", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", "Descrizione", 
"EsitoPositivo", "DescrizioneEsitoRevisore", "EsitoPositivoRevisore", 
"DescrizioneVoceGenerica", "Automatico", "QuerySql", 
"QuerySqlPost", "CodeMethod", "Url", 
"ValMinimo", "ValMassimo", "Ordine", 
"Obbligatorio", "Peso", "IdChecklistGenerica", 
"DescrizioneChecklistGenerica", "Valore", "ValEsitoNegativo", 
"Misura", "IdVoceXChecklistGenerica", "Id", 
"IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"bool", "string", "bool", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "int", 
"bool", "decimal", "int", 
"string", "string", "bool", 
"string", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,EsitoIstanzaChecklistGenericoModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					EsitoIstanzaChecklistGenericoModificheObj.DataModifica = d;
				}
				EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
				EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			switch (EsitoIstanzaChecklistGenericoModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, EsitoIstanzaChecklistGenericoModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, EsitoIstanzaChecklistGenericoModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,EsitoIstanzaChecklistGenericoModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheUpdate", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", "Descrizione", 
"EsitoPositivo", "DescrizioneEsitoRevisore", "EsitoPositivoRevisore", 
"DescrizioneVoceGenerica", "Automatico", "QuerySql", 
"QuerySqlPost", "CodeMethod", "Url", 
"ValMinimo", "ValMassimo", "Ordine", 
"Obbligatorio", "Peso", "IdChecklistGenerica", 
"DescrizioneChecklistGenerica", "Valore", "ValEsitoNegativo", 
"Misura", "IdVoceXChecklistGenerica", "Id", 
"IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"bool", "string", "bool", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "int", 
"bool", "decimal", "int", 
"string", "string", "bool", 
"string", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheInsert", new string[] {"IdEsitoGenerico", "IdVoceGenerica", "IdIstanzaGenerica", 
"CodEsito", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "Note", 
"CodEsitoRevisore", "DataRevisore", "Revisore", 
"NoteRevisore", "EscludiDaComunicazione", "Descrizione", 
"EsitoPositivo", "DescrizioneEsitoRevisore", "EsitoPositivoRevisore", 
"DescrizioneVoceGenerica", "Automatico", "QuerySql", 
"QuerySqlPost", "CodeMethod", "Url", 
"ValMinimo", "ValMassimo", "Ordine", 
"Obbligatorio", "Peso", "IdChecklistGenerica", 
"DescrizioneChecklistGenerica", "Valore", "ValEsitoNegativo", 
"Misura", "IdVoceXChecklistGenerica", 
"IdModifica"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"bool", "string", "bool", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "int", 
"bool", "decimal", "int", 
"string", "string", "bool", 
"string", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < EsitoIstanzaChecklistGenericoModificheCollectionObj.Count; i++)
				{
					switch (EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,EsitoIstanzaChecklistGenericoModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									EsitoIstanzaChecklistGenericoModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,EsitoIstanzaChecklistGenericoModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									EsitoIstanzaChecklistGenericoModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)EsitoIstanzaChecklistGenericoModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < EsitoIstanzaChecklistGenericoModificheCollectionObj.Count; i++)
				{
					if ((EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsDirty = false;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsPersistent = true;
					}
					if ((EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsDirty = false;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj)
		{
			int returnValue = 0;
			if (EsitoIstanzaChecklistGenericoModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, EsitoIstanzaChecklistGenericoModificheObj.Id);
			}
			EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
			EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < EsitoIstanzaChecklistGenericoModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", EsitoIstanzaChecklistGenericoModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < EsitoIstanzaChecklistGenericoModificheCollectionObj.Count; i++)
				{
					if ((EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsDirty = false;
						EsitoIstanzaChecklistGenericoModificheCollectionObj[i].IsPersistent = false;
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
		public static EsitoIstanzaChecklistGenericoModifiche GetById(DbProvider db, int IdValue)
		{
			EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZEsitoIstanzaChecklistGenericoModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				EsitoIstanzaChecklistGenericoModificheObj = GetFromDatareader(db);
				EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
				EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = true;
			}
			db.Close();
			return EsitoIstanzaChecklistGenericoModificheObj;
		}

		//getFromDatareader
		public static EsitoIstanzaChecklistGenericoModifiche GetFromDatareader(DbProvider db)
		{
			EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj = new EsitoIstanzaChecklistGenericoModifiche();
			EsitoIstanzaChecklistGenericoModificheObj.IdEsitoGenerico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESITO_GENERICO"]);
			EsitoIstanzaChecklistGenericoModificheObj.IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
			EsitoIstanzaChecklistGenericoModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			EsitoIstanzaChecklistGenericoModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			EsitoIstanzaChecklistGenericoModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			EsitoIstanzaChecklistGenericoModificheObj.CodEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO_REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.DataRevisore = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.Revisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.NoteRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.EscludiDaComunicazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESCLUDI_DA_COMUNICAZIONE"]);
			EsitoIstanzaChecklistGenericoModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			EsitoIstanzaChecklistGenericoModificheObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
			EsitoIstanzaChecklistGenericoModificheObj.DescrizioneEsitoRevisore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO_REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.EsitoPositivoRevisore = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO_REVISORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.DescrizioneVoceGenerica = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_VOCE_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			EsitoIstanzaChecklistGenericoModificheObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			EsitoIstanzaChecklistGenericoModificheObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			EsitoIstanzaChecklistGenericoModificheObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			EsitoIstanzaChecklistGenericoModificheObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			EsitoIstanzaChecklistGenericoModificheObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			EsitoIstanzaChecklistGenericoModificheObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			EsitoIstanzaChecklistGenericoModificheObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			EsitoIstanzaChecklistGenericoModificheObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			EsitoIstanzaChecklistGenericoModificheObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
			EsitoIstanzaChecklistGenericoModificheObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.DescrizioneChecklistGenerica = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_CHECKLIST_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.Valore = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALORE"]);
			EsitoIstanzaChecklistGenericoModificheObj.ValEsitoNegativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO"]);
			EsitoIstanzaChecklistGenericoModificheObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			EsitoIstanzaChecklistGenericoModificheObj.IdVoceXChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_X_CHECKLIST_GENERICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			EsitoIstanzaChecklistGenericoModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
			EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = true;
			return EsitoIstanzaChecklistGenericoModificheObj;
		}

		//Find Select

		public static EsitoIstanzaChecklistGenericoModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEsitoGenericoEqualThis, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, 
SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.StringNT CodEsitoRevisoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRevisoreEqualThis, SiarLibrary.NullTypes.StringNT RevisoreEqualThis, SiarLibrary.NullTypes.BoolNT EscludiDaComunicazioneEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT EsitoPositivoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEsitoRevisoreEqualThis, 
SiarLibrary.NullTypes.BoolNT EsitoPositivoRevisoreEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneVoceGenericaEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlPostEqualThis, SiarLibrary.NullTypes.StringNT CodeMethodEqualThis, 
SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, SiarLibrary.NullTypes.StringNT ValMassimoEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.DecimalNT PesoEqualThis, 
SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT ValoreEqualThis, 
SiarLibrary.NullTypes.BoolNT ValEsitoNegativoEqualThis, SiarLibrary.NullTypes.StringNT MisuraEqualThis, SiarLibrary.NullTypes.IntNT IdVoceXChecklistGenericaEqualThis, 
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionObj = new EsitoIstanzaChecklistGenericoModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zesitoistanzachecklistgenericomodifichefindselect", new string[] {"IdEsitoGenericoequalthis", "IdVoceGenericaequalthis", "IdIstanzaGenericaequalthis", 
"CodEsitoequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "CodEsitoRevisoreequalthis", 
"DataRevisoreequalthis", "Revisoreequalthis", "EscludiDaComunicazioneequalthis", 
"Descrizioneequalthis", "EsitoPositivoequalthis", "DescrizioneEsitoRevisoreequalthis", 
"EsitoPositivoRevisoreequalthis", "DescrizioneVoceGenericaequalthis", "Automaticoequalthis", 
"QuerySqlequalthis", "QuerySqlPostequalthis", "CodeMethodequalthis", 
"Urlequalthis", "ValMinimoequalthis", "ValMassimoequalthis", 
"Ordineequalthis", "Obbligatorioequalthis", "Pesoequalthis", 
"IdChecklistGenericaequalthis", "DescrizioneChecklistGenericaequalthis", "Valoreequalthis", 
"ValEsitoNegativoequalthis", "Misuraequalthis", "IdVoceXChecklistGenericaequalthis", 
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "bool", 
"string", "bool", "string", 
"bool", "string", "bool", 
"string", "string", "string", 
"string", "string", "string", 
"int", "bool", "decimal", 
"int", "string", "string", 
"bool", "string", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEsitoGenericoequalthis", IdEsitoGenericoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEsitoRevisoreequalthis", CodEsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRevisoreequalthis", DataRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Revisoreequalthis", RevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EscludiDaComunicazioneequalthis", EscludiDaComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoPositivoequalthis", EsitoPositivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoRevisoreequalthis", DescrizioneEsitoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "EsitoPositivoRevisoreequalthis", EsitoPositivoRevisoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneVoceGenericaequalthis", DescrizioneVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlPostequalthis", QuerySqlPostEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodeMethodequalthis", CodeMethodEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneChecklistGenericaequalthis", DescrizioneChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValEsitoNegativoequalthis", ValEsitoNegativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Misuraequalthis", MisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVoceXChecklistGenericaequalthis", IdVoceXChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				EsitoIstanzaChecklistGenericoModificheObj = GetFromDatareader(db);
				EsitoIstanzaChecklistGenericoModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				EsitoIstanzaChecklistGenericoModificheObj.IsDirty = false;
				EsitoIstanzaChecklistGenericoModificheObj.IsPersistent = true;
				EsitoIstanzaChecklistGenericoModificheCollectionObj.Add(EsitoIstanzaChecklistGenericoModificheObj);
			}
			db.Close();
			return EsitoIstanzaChecklistGenericoModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for EsitoIstanzaChecklistGenericoModificheCollectionProvider:IEsitoIstanzaChecklistGenericoModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class EsitoIstanzaChecklistGenericoModificheCollectionProvider : IEsitoIstanzaChecklistGenericoModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di EsitoIstanzaChecklistGenericoModifiche
		protected EsitoIstanzaChecklistGenericoModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public EsitoIstanzaChecklistGenericoModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new EsitoIstanzaChecklistGenericoModificheCollection(this);
		}

		//Costruttore3: ha in input esitoistanzachecklistgenericomodificheCollectionObj - non popola la collection
		public EsitoIstanzaChecklistGenericoModificheCollectionProvider(EsitoIstanzaChecklistGenericoModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public EsitoIstanzaChecklistGenericoModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new EsitoIstanzaChecklistGenericoModificheCollection(this);
		}

		//Get e Set
		public EsitoIstanzaChecklistGenericoModificheCollection CollectionObj
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
		public int SaveCollection(EsitoIstanzaChecklistGenericoModificheCollection collectionObj)
		{
			return EsitoIstanzaChecklistGenericoModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(EsitoIstanzaChecklistGenericoModifiche esitoistanzachecklistgenericomodificheObj)
		{
			return EsitoIstanzaChecklistGenericoModificheDAL.Save(_dbProviderObj, esitoistanzachecklistgenericomodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(EsitoIstanzaChecklistGenericoModificheCollection collectionObj)
		{
			return EsitoIstanzaChecklistGenericoModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(EsitoIstanzaChecklistGenericoModifiche esitoistanzachecklistgenericomodificheObj)
		{
			return EsitoIstanzaChecklistGenericoModificheDAL.Delete(_dbProviderObj, esitoistanzachecklistgenericomodificheObj);
		}

		//getById
		public EsitoIstanzaChecklistGenericoModifiche GetById(IntNT IdValue)
		{
			EsitoIstanzaChecklistGenericoModifiche EsitoIstanzaChecklistGenericoModificheTemp = EsitoIstanzaChecklistGenericoModificheDAL.GetById(_dbProviderObj, IdValue);
			if (EsitoIstanzaChecklistGenericoModificheTemp!=null) EsitoIstanzaChecklistGenericoModificheTemp.Provider = this;
			return EsitoIstanzaChecklistGenericoModificheTemp;
		}

		//Select: popola la collection
		public EsitoIstanzaChecklistGenericoModificheCollection Select(IntNT IdesitogenericoEqualThis, IntNT IdvocegenericaEqualThis, IntNT IdistanzagenericaEqualThis, 
StringNT CodesitoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, StringNT CodesitorevisoreEqualThis, 
DatetimeNT DatarevisoreEqualThis, StringNT RevisoreEqualThis, BoolNT EscludidacomunicazioneEqualThis, 
StringNT DescrizioneEqualThis, BoolNT EsitopositivoEqualThis, StringNT DescrizioneesitorevisoreEqualThis, 
BoolNT EsitopositivorevisoreEqualThis, StringNT DescrizionevocegenericaEqualThis, BoolNT AutomaticoEqualThis, 
StringNT QuerysqlEqualThis, StringNT QuerysqlpostEqualThis, StringNT CodemethodEqualThis, 
StringNT UrlEqualThis, StringNT ValminimoEqualThis, StringNT ValmassimoEqualThis, 
IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, DecimalNT PesoEqualThis, 
IntNT IdchecklistgenericaEqualThis, StringNT DescrizionechecklistgenericaEqualThis, StringNT ValoreEqualThis, 
BoolNT ValesitonegativoEqualThis, StringNT MisuraEqualThis, IntNT IdvocexchecklistgenericaEqualThis, 
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			EsitoIstanzaChecklistGenericoModificheCollection EsitoIstanzaChecklistGenericoModificheCollectionTemp = EsitoIstanzaChecklistGenericoModificheDAL.Select(_dbProviderObj, IdesitogenericoEqualThis, IdvocegenericaEqualThis, IdistanzagenericaEqualThis, 
CodesitoEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis, 
DatamodificaEqualThis, CfmodificaEqualThis, CodesitorevisoreEqualThis, 
DatarevisoreEqualThis, RevisoreEqualThis, EscludidacomunicazioneEqualThis, 
DescrizioneEqualThis, EsitopositivoEqualThis, DescrizioneesitorevisoreEqualThis, 
EsitopositivorevisoreEqualThis, DescrizionevocegenericaEqualThis, AutomaticoEqualThis, 
QuerysqlEqualThis, QuerysqlpostEqualThis, CodemethodEqualThis, 
UrlEqualThis, ValminimoEqualThis, ValmassimoEqualThis, 
OrdineEqualThis, ObbligatorioEqualThis, PesoEqualThis, 
IdchecklistgenericaEqualThis, DescrizionechecklistgenericaEqualThis, ValoreEqualThis, 
ValesitonegativoEqualThis, MisuraEqualThis, IdvocexchecklistgenericaEqualThis, 
IdEqualThis, IdmodificaEqualThis);
			EsitoIstanzaChecklistGenericoModificheCollectionTemp.Provider = this;
			return EsitoIstanzaChecklistGenericoModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ESITO_ISTANZA_CHECKLIST_GENERICO_MODIFICHE>
  <ViewName>
  </ViewName>
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
</ESITO_ISTANZA_CHECKLIST_GENERICO_MODIFICHE>
*/
