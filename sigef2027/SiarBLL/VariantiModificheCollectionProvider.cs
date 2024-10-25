using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VariantiModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVariantiModificheProvider
	{
		int Save(VariantiModifiche VariantiModificheObj);
		int SaveCollection(VariantiModificheCollection collectionObj);
		int Delete(VariantiModifiche VariantiModificheObj);
		int DeleteCollection(VariantiModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VariantiModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VariantiModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _SegnaturaAllegati;
		private NullTypes.StringNT _SegnaturaApprovazione;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.StringNT _Istruttore;
		private NullTypes.StringNT _NoteIstruttore;
		private NullTypes.StringNT _TipoVariante;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Ente;
		private NullTypes.DatetimeNT _DataApprovazione;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Annullata;
		private NullTypes.StringNT _SegnaturaAnnullamento;
		private NullTypes.StringNT _CfOperatoreAnnullamento;
		private NullTypes.DatetimeNT _DataAnnullamento;
		private NullTypes.StringNT _NominativoOperatoreAnnullamento;
		private NullTypes.StringNT _NominativoIstruttore;
		private NullTypes.StringNT _CuaaEntrante;
		private NullTypes.IntNT _IdFascicoloEntrante;
		private NullTypes.StringNT _CuaaUscente;
		private NullTypes.IntNT _IdFascicoloUscente;
		private NullTypes.StringNT _RagsocUscente;
		private NullTypes.IntNT _IdAttoApprovazione;
		private NullTypes.StringNT _AwDocnumber;
		private NullTypes.StringNT _CodDefinizione;
		private NullTypes.IntNT _AwDocnumberNuovo;
		private NullTypes.BoolNT _FirmaPredispostaRup;
		private NullTypes.BoolNT _FirmaPredisposta;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IVariantiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VariantiModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
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
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(2)
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
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
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
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ALLEGATI
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaAllegati
		{
			get { return _SegnaturaAllegati; }
			set {
				if (SegnaturaAllegati != value)
				{
					_SegnaturaAllegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_APPROVAZIONE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaApprovazione
		{
			get { return _SegnaturaApprovazione; }
			set {
				if (SegnaturaApprovazione != value)
				{
					_SegnaturaApprovazione = value;
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
		/// Corrisponde al campo:ISTRUTTORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Istruttore
		{
			get { return _Istruttore; }
			set {
				if (Istruttore != value)
				{
					_Istruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_ISTRUTTORE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT NoteIstruttore
		{
			get { return _NoteIstruttore; }
			set {
				if (NoteIstruttore != value)
				{
					_NoteIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_VARIANTE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoVariante
		{
			get { return _TipoVariante; }
			set {
				if (TipoVariante != value)
				{
					_TipoVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_APPROVAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataApprovazione
		{
			get { return _DataApprovazione; }
			set {
				if (DataApprovazione != value)
				{
					_DataApprovazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:SEGNATURA_ANNULLAMENTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaAnnullamento
		{
			get { return _SegnaturaAnnullamento; }
			set {
				if (SegnaturaAnnullamento != value)
				{
					_SegnaturaAnnullamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_OPERATORE_ANNULLAMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfOperatoreAnnullamento
		{
			get { return _CfOperatoreAnnullamento; }
			set {
				if (CfOperatoreAnnullamento != value)
				{
					_CfOperatoreAnnullamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ANNULLAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAnnullamento
		{
			get { return _DataAnnullamento; }
			set {
				if (DataAnnullamento != value)
				{
					_DataAnnullamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_OPERATORE_ANNULLAMENTO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoOperatoreAnnullamento
		{
			get { return _NominativoOperatoreAnnullamento; }
			set {
				if (NominativoOperatoreAnnullamento != value)
				{
					_NominativoOperatoreAnnullamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_ISTRUTTORE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoIstruttore
		{
			get { return _NominativoIstruttore; }
			set {
				if (NominativoIstruttore != value)
				{
					_NominativoIstruttore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_ENTRANTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaEntrante
		{
			get { return _CuaaEntrante; }
			set {
				if (CuaaEntrante != value)
				{
					_CuaaEntrante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FASCICOLO_ENTRANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFascicoloEntrante
		{
			get { return _IdFascicoloEntrante; }
			set {
				if (IdFascicoloEntrante != value)
				{
					_IdFascicoloEntrante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_USCENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaUscente
		{
			get { return _CuaaUscente; }
			set {
				if (CuaaUscente != value)
				{
					_CuaaUscente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FASCICOLO_USCENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFascicoloUscente
		{
			get { return _IdFascicoloUscente; }
			set {
				if (IdFascicoloUscente != value)
				{
					_IdFascicoloUscente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGSOC_USCENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagsocUscente
		{
			get { return _RagsocUscente; }
			set {
				if (RagsocUscente != value)
				{
					_RagsocUscente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATTO_APPROVAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAttoApprovazione
		{
			get { return _IdAttoApprovazione; }
			set {
				if (IdAttoApprovazione != value)
				{
					_IdAttoApprovazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AW_DOCNUMBER
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT AwDocnumber
		{
			get { return _AwDocnumber; }
			set {
				if (AwDocnumber != value)
				{
					_AwDocnumber = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_DEFINIZIONE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodDefinizione
		{
			get { return _CodDefinizione; }
			set {
				if (CodDefinizione != value)
				{
					_CodDefinizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AW_DOCNUMBER_NUOVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT AwDocnumberNuovo
		{
			get { return _AwDocnumberNuovo; }
			set {
				if (AwDocnumberNuovo != value)
				{
					_AwDocnumberNuovo = value;
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

		/// <summary>
		/// Corrisponde al campo:FIRMA_PREDISPOSTA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FirmaPredisposta
		{
			get { return _FirmaPredisposta; }
			set {
				if (FirmaPredisposta != value)
				{
					_FirmaPredisposta = value;
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
	/// Summary description for VariantiModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VariantiModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VariantiModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VariantiModifiche) info.GetValue(i.ToString(),typeof(VariantiModifiche)));
			}
		}

		//Costruttore
		public VariantiModificheCollection()
		{
			this.ItemType = typeof(VariantiModifiche);
		}

		//Costruttore con provider
		public VariantiModificheCollection(IVariantiModificheProvider providerObj)
		{
			this.ItemType = typeof(VariantiModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VariantiModifiche this[int index]
		{
			get { return (VariantiModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VariantiModificheCollection GetChanges()
		{
			return (VariantiModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IVariantiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiModificheProvider Provider
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
		public int Add(VariantiModifiche VariantiModificheObj)
		{
			if (VariantiModificheObj.Provider == null) VariantiModificheObj.Provider = this.Provider;
			return base.Add(VariantiModificheObj);
		}

		//AddCollection
		public void AddCollection(VariantiModificheCollection VariantiModificheCollectionObj)
		{
			foreach (VariantiModifiche VariantiModificheObj in VariantiModificheCollectionObj)
				this.Add(VariantiModificheObj);
		}

		//Insert
		public void Insert(int index, VariantiModifiche VariantiModificheObj)
		{
			if (VariantiModificheObj.Provider == null) VariantiModificheObj.Provider = this.Provider;
			base.Insert(index, VariantiModificheObj);
		}

		//CollectionGetById
		public VariantiModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public VariantiModificheCollection SubSelect(NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodTipoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT OperatoreEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT SegnaturaAllegatiEqualThis, 
NullTypes.StringNT SegnaturaApprovazioneEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.StringNT IstruttoreEqualThis, 
NullTypes.StringNT TipoVarianteEqualThis, NullTypes.StringNT NominativoEqualThis, NullTypes.StringNT ProfiloEqualThis, 
NullTypes.StringNT EnteEqualThis, NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.StringNT ProvinciaEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AnnullataEqualThis, NullTypes.StringNT SegnaturaAnnullamentoEqualThis, 
NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis, 
NullTypes.StringNT NominativoIstruttoreEqualThis, NullTypes.StringNT CuaaEntranteEqualThis, NullTypes.IntNT IdFascicoloEntranteEqualThis, 
NullTypes.StringNT CuaaUscenteEqualThis, NullTypes.IntNT IdFascicoloUscenteEqualThis, NullTypes.StringNT RagsocUscenteEqualThis, 
NullTypes.IntNT IdAttoApprovazioneEqualThis, NullTypes.StringNT AwDocnumberEqualThis, NullTypes.StringNT CodDefinizioneEqualThis, 
NullTypes.IntNT AwDocnumberNuovoEqualThis, NullTypes.BoolNT FirmaPredispostaRupEqualThis, NullTypes.BoolNT FirmaPredispostaEqualThis, 
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			VariantiModificheCollection VariantiModificheCollectionTemp = new VariantiModificheCollection();
			foreach (VariantiModifiche VariantiModificheItem in this)
			{
				if (((IdVarianteEqualThis == null) || ((VariantiModificheItem.IdVariante != null) && (VariantiModificheItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VariantiModificheItem.IdProgetto != null) && (VariantiModificheItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VariantiModificheItem.CodTipo != null) && (VariantiModificheItem.CodTipo.Value == CodTipoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((VariantiModificheItem.DataInserimento != null) && (VariantiModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CodEnteEqualThis == null) || ((VariantiModificheItem.CodEnte != null) && (VariantiModificheItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VariantiModificheItem.Operatore != null) && (VariantiModificheItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((VariantiModificheItem.DataModifica != null) && (VariantiModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VariantiModificheItem.Segnatura != null) && (VariantiModificheItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaAllegatiEqualThis == null) || ((VariantiModificheItem.SegnaturaAllegati != null) && (VariantiModificheItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) && 
((SegnaturaApprovazioneEqualThis == null) || ((VariantiModificheItem.SegnaturaApprovazione != null) && (VariantiModificheItem.SegnaturaApprovazione.Value == SegnaturaApprovazioneEqualThis.Value))) && ((ApprovataEqualThis == null) || ((VariantiModificheItem.Approvata != null) && (VariantiModificheItem.Approvata.Value == ApprovataEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VariantiModificheItem.Istruttore != null) && (VariantiModificheItem.Istruttore.Value == IstruttoreEqualThis.Value))) && 
((TipoVarianteEqualThis == null) || ((VariantiModificheItem.TipoVariante != null) && (VariantiModificheItem.TipoVariante.Value == TipoVarianteEqualThis.Value))) && ((NominativoEqualThis == null) || ((VariantiModificheItem.Nominativo != null) && (VariantiModificheItem.Nominativo.Value == NominativoEqualThis.Value))) && ((ProfiloEqualThis == null) || ((VariantiModificheItem.Profilo != null) && (VariantiModificheItem.Profilo.Value == ProfiloEqualThis.Value))) && 
((EnteEqualThis == null) || ((VariantiModificheItem.Ente != null) && (VariantiModificheItem.Ente.Value == EnteEqualThis.Value))) && ((DataApprovazioneEqualThis == null) || ((VariantiModificheItem.DataApprovazione != null) && (VariantiModificheItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((VariantiModificheItem.Provincia != null) && (VariantiModificheItem.Provincia.Value == ProvinciaEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((VariantiModificheItem.Descrizione != null) && (VariantiModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AnnullataEqualThis == null) || ((VariantiModificheItem.Annullata != null) && (VariantiModificheItem.Annullata.Value == AnnullataEqualThis.Value))) && ((SegnaturaAnnullamentoEqualThis == null) || ((VariantiModificheItem.SegnaturaAnnullamento != null) && (VariantiModificheItem.SegnaturaAnnullamento.Value == SegnaturaAnnullamentoEqualThis.Value))) && 
((CfOperatoreAnnullamentoEqualThis == null) || ((VariantiModificheItem.CfOperatoreAnnullamento != null) && (VariantiModificheItem.CfOperatoreAnnullamento.Value == CfOperatoreAnnullamentoEqualThis.Value))) && ((DataAnnullamentoEqualThis == null) || ((VariantiModificheItem.DataAnnullamento != null) && (VariantiModificheItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((NominativoOperatoreAnnullamentoEqualThis == null) || ((VariantiModificheItem.NominativoOperatoreAnnullamento != null) && (VariantiModificheItem.NominativoOperatoreAnnullamento.Value == NominativoOperatoreAnnullamentoEqualThis.Value))) && 
((NominativoIstruttoreEqualThis == null) || ((VariantiModificheItem.NominativoIstruttore != null) && (VariantiModificheItem.NominativoIstruttore.Value == NominativoIstruttoreEqualThis.Value))) && ((CuaaEntranteEqualThis == null) || ((VariantiModificheItem.CuaaEntrante != null) && (VariantiModificheItem.CuaaEntrante.Value == CuaaEntranteEqualThis.Value))) && ((IdFascicoloEntranteEqualThis == null) || ((VariantiModificheItem.IdFascicoloEntrante != null) && (VariantiModificheItem.IdFascicoloEntrante.Value == IdFascicoloEntranteEqualThis.Value))) && 
((CuaaUscenteEqualThis == null) || ((VariantiModificheItem.CuaaUscente != null) && (VariantiModificheItem.CuaaUscente.Value == CuaaUscenteEqualThis.Value))) && ((IdFascicoloUscenteEqualThis == null) || ((VariantiModificheItem.IdFascicoloUscente != null) && (VariantiModificheItem.IdFascicoloUscente.Value == IdFascicoloUscenteEqualThis.Value))) && ((RagsocUscenteEqualThis == null) || ((VariantiModificheItem.RagsocUscente != null) && (VariantiModificheItem.RagsocUscente.Value == RagsocUscenteEqualThis.Value))) && 
((IdAttoApprovazioneEqualThis == null) || ((VariantiModificheItem.IdAttoApprovazione != null) && (VariantiModificheItem.IdAttoApprovazione.Value == IdAttoApprovazioneEqualThis.Value))) && ((AwDocnumberEqualThis == null) || ((VariantiModificheItem.AwDocnumber != null) && (VariantiModificheItem.AwDocnumber.Value == AwDocnumberEqualThis.Value))) && ((CodDefinizioneEqualThis == null) || ((VariantiModificheItem.CodDefinizione != null) && (VariantiModificheItem.CodDefinizione.Value == CodDefinizioneEqualThis.Value))) && 
((AwDocnumberNuovoEqualThis == null) || ((VariantiModificheItem.AwDocnumberNuovo != null) && (VariantiModificheItem.AwDocnumberNuovo.Value == AwDocnumberNuovoEqualThis.Value))) && ((FirmaPredispostaRupEqualThis == null) || ((VariantiModificheItem.FirmaPredispostaRup != null) && (VariantiModificheItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))) && ((FirmaPredispostaEqualThis == null) || ((VariantiModificheItem.FirmaPredisposta != null) && (VariantiModificheItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))) && 
((IdEqualThis == null) || ((VariantiModificheItem.Id != null) && (VariantiModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((VariantiModificheItem.IdModifica != null) && (VariantiModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					VariantiModificheCollectionTemp.Add(VariantiModificheItem);
				}
			}
			return VariantiModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VariantiModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VariantiModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VariantiModifiche VariantiModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", VariantiModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", VariantiModificheObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", VariantiModificheObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", VariantiModificheObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", VariantiModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", VariantiModificheObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", VariantiModificheObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", VariantiModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", VariantiModificheObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaAllegati", VariantiModificheObj.SegnaturaAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaApprovazione", VariantiModificheObj.SegnaturaApprovazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", VariantiModificheObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruttore", VariantiModificheObj.Istruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteIstruttore", VariantiModificheObj.NoteIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoVariante", VariantiModificheObj.TipoVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "Nominativo", VariantiModificheObj.Nominativo);
			DbProvider.SetCmdParam(cmd,firstChar + "Profilo", VariantiModificheObj.Profilo);
			DbProvider.SetCmdParam(cmd,firstChar + "Ente", VariantiModificheObj.Ente);
			DbProvider.SetCmdParam(cmd,firstChar + "DataApprovazione", VariantiModificheObj.DataApprovazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", VariantiModificheObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", VariantiModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Annullata", VariantiModificheObj.Annullata);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaAnnullamento", VariantiModificheObj.SegnaturaAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatoreAnnullamento", VariantiModificheObj.CfOperatoreAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAnnullamento", VariantiModificheObj.DataAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "NominativoOperatoreAnnullamento", VariantiModificheObj.NominativoOperatoreAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "NominativoIstruttore", VariantiModificheObj.NominativoIstruttore);
			DbProvider.SetCmdParam(cmd,firstChar + "CuaaEntrante", VariantiModificheObj.CuaaEntrante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFascicoloEntrante", VariantiModificheObj.IdFascicoloEntrante);
			DbProvider.SetCmdParam(cmd,firstChar + "CuaaUscente", VariantiModificheObj.CuaaUscente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFascicoloUscente", VariantiModificheObj.IdFascicoloUscente);
			DbProvider.SetCmdParam(cmd,firstChar + "RagsocUscente", VariantiModificheObj.RagsocUscente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAttoApprovazione", VariantiModificheObj.IdAttoApprovazione);
			DbProvider.SetCmdParam(cmd,firstChar + "AwDocnumber", VariantiModificheObj.AwDocnumber);
			DbProvider.SetCmdParam(cmd,firstChar + "CodDefinizione", VariantiModificheObj.CodDefinizione);
			DbProvider.SetCmdParam(cmd,firstChar + "AwDocnumberNuovo", VariantiModificheObj.AwDocnumberNuovo);
			DbProvider.SetCmdParam(cmd,firstChar + "FirmaPredispostaRup", VariantiModificheObj.FirmaPredispostaRup);
			DbProvider.SetCmdParam(cmd,firstChar + "FirmaPredisposta", VariantiModificheObj.FirmaPredisposta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", VariantiModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, VariantiModifiche VariantiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVariantiModificheInsert", new string[] {"IdVariante", "IdProgetto", "CodTipo", 
"DataInserimento", "CodEnte", "Operatore", 
"DataModifica", "Segnatura", "SegnaturaAllegati", 
"SegnaturaApprovazione", "Approvata", "Istruttore", 
"NoteIstruttore", "TipoVariante", "Nominativo", 
"Profilo", "Ente", "DataApprovazione", 
"Provincia", "Descrizione", "Annullata", 
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento", 
"NominativoOperatoreAnnullamento", "NominativoIstruttore", "CuaaEntrante", 
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente", 
"RagsocUscente", "IdAttoApprovazione", "AwDocnumber", 
"CodDefinizione", "AwDocnumberNuovo", "FirmaPredispostaRup", 
"FirmaPredisposta", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"int", "string", "int", 
"string", "int", "string", 
"string", "int", "bool", 
"bool", "int"},"");
				CompileIUCmd(false, insertCmd,VariantiModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VariantiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiModificheObj.IsDirty = false;
				VariantiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VariantiModifiche VariantiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiModificheUpdate", new string[] {"IdVariante", "IdProgetto", "CodTipo", 
"DataInserimento", "CodEnte", "Operatore", 
"DataModifica", "Segnatura", "SegnaturaAllegati", 
"SegnaturaApprovazione", "Approvata", "Istruttore", 
"NoteIstruttore", "TipoVariante", "Nominativo", 
"Profilo", "Ente", "DataApprovazione", 
"Provincia", "Descrizione", "Annullata", 
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento", 
"NominativoOperatoreAnnullamento", "NominativoIstruttore", "CuaaEntrante", 
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente", 
"RagsocUscente", "IdAttoApprovazione", "AwDocnumber", 
"CodDefinizione", "AwDocnumberNuovo", "FirmaPredispostaRup", 
"FirmaPredisposta", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"int", "string", "int", 
"string", "int", "string", 
"string", "int", "bool", 
"bool", "int", "int"},"");
				CompileIUCmd(true, updateCmd,VariantiModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					VariantiModificheObj.DataModifica = d;
				}
				VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiModificheObj.IsDirty = false;
				VariantiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VariantiModifiche VariantiModificheObj)
		{
			switch (VariantiModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VariantiModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VariantiModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VariantiModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VariantiModificheCollection VariantiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVariantiModificheUpdate", new string[] {"IdVariante", "IdProgetto", "CodTipo", 
"DataInserimento", "CodEnte", "Operatore", 
"DataModifica", "Segnatura", "SegnaturaAllegati", 
"SegnaturaApprovazione", "Approvata", "Istruttore", 
"NoteIstruttore", "TipoVariante", "Nominativo", 
"Profilo", "Ente", "DataApprovazione", 
"Provincia", "Descrizione", "Annullata", 
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento", 
"NominativoOperatoreAnnullamento", "NominativoIstruttore", "CuaaEntrante", 
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente", 
"RagsocUscente", "IdAttoApprovazione", "AwDocnumber", 
"CodDefinizione", "AwDocnumberNuovo", "FirmaPredispostaRup", 
"FirmaPredisposta", "Id", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"int", "string", "int", 
"string", "int", "string", 
"string", "int", "bool", 
"bool", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZVariantiModificheInsert", new string[] {"IdVariante", "IdProgetto", "CodTipo", 
"DataInserimento", "CodEnte", "Operatore", 
"DataModifica", "Segnatura", "SegnaturaAllegati", 
"SegnaturaApprovazione", "Approvata", "Istruttore", 
"NoteIstruttore", "TipoVariante", "Nominativo", 
"Profilo", "Ente", "DataApprovazione", 
"Provincia", "Descrizione", "Annullata", 
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento", 
"NominativoOperatoreAnnullamento", "NominativoIstruttore", "CuaaEntrante", 
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente", 
"RagsocUscente", "IdAttoApprovazione", "AwDocnumber", 
"CodDefinizione", "AwDocnumberNuovo", "FirmaPredispostaRup", 
"FirmaPredisposta", "IdModifica"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "string", "DateTime", 
"string", "string", "bool", 
"string", "string", "DateTime", 
"string", "string", "string", 
"int", "string", "int", 
"string", "int", "string", 
"string", "int", "bool", 
"bool", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < VariantiModificheCollectionObj.Count; i++)
				{
					switch (VariantiModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VariantiModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VariantiModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VariantiModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									VariantiModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VariantiModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)VariantiModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VariantiModificheCollectionObj.Count; i++)
				{
					if ((VariantiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VariantiModificheCollectionObj[i].IsDirty = false;
						VariantiModificheCollectionObj[i].IsPersistent = true;
					}
					if ((VariantiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VariantiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiModificheCollectionObj[i].IsDirty = false;
						VariantiModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VariantiModifiche VariantiModificheObj)
		{
			int returnValue = 0;
			if (VariantiModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, VariantiModificheObj.Id);
			}
			VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VariantiModificheObj.IsDirty = false;
			VariantiModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VariantiModificheCollection VariantiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVariantiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < VariantiModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", VariantiModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VariantiModificheCollectionObj.Count; i++)
				{
					if ((VariantiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VariantiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VariantiModificheCollectionObj[i].IsDirty = false;
						VariantiModificheCollectionObj[i].IsPersistent = false;
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
		public static VariantiModifiche GetById(DbProvider db, int IdValue)
		{
			VariantiModifiche VariantiModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVariantiModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VariantiModificheObj = GetFromDatareader(db);
				VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiModificheObj.IsDirty = false;
				VariantiModificheObj.IsPersistent = true;
			}
			db.Close();
			return VariantiModificheObj;
		}

		//getFromDatareader
		public static VariantiModifiche GetFromDatareader(DbProvider db)
		{
			VariantiModifiche VariantiModificheObj = new VariantiModifiche();
			VariantiModificheObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			VariantiModificheObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VariantiModificheObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			VariantiModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			VariantiModificheObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			VariantiModificheObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			VariantiModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			VariantiModificheObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			VariantiModificheObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
			VariantiModificheObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
			VariantiModificheObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			VariantiModificheObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
			VariantiModificheObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
			VariantiModificheObj.TipoVariante = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VARIANTE"]);
			VariantiModificheObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			VariantiModificheObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			VariantiModificheObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			VariantiModificheObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
			VariantiModificheObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			VariantiModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VariantiModificheObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
			VariantiModificheObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
			VariantiModificheObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
			VariantiModificheObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
			VariantiModificheObj.NominativoOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_ANNULLAMENTO"]);
			VariantiModificheObj.NominativoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_ISTRUTTORE"]);
			VariantiModificheObj.CuaaEntrante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_ENTRANTE"]);
			VariantiModificheObj.IdFascicoloEntrante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_ENTRANTE"]);
			VariantiModificheObj.CuaaUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_USCENTE"]);
			VariantiModificheObj.IdFascicoloUscente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_USCENTE"]);
			VariantiModificheObj.RagsocUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGSOC_USCENTE"]);
			VariantiModificheObj.IdAttoApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_APPROVAZIONE"]);
			VariantiModificheObj.AwDocnumber = new SiarLibrary.NullTypes.StringNT(db.DataReader["AW_DOCNUMBER"]);
			VariantiModificheObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
			VariantiModificheObj.AwDocnumberNuovo = new SiarLibrary.NullTypes.IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]);
			VariantiModificheObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
			VariantiModificheObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
			VariantiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			VariantiModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VariantiModificheObj.IsDirty = false;
			VariantiModificheObj.IsPersistent = true;
			return VariantiModificheObj;
		}

		//Find Select

		public static VariantiModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, 
SiarLibrary.NullTypes.StringNT TipoVarianteEqualThis, SiarLibrary.NullTypes.StringNT NominativoEqualThis, SiarLibrary.NullTypes.StringNT ProfiloEqualThis, 
SiarLibrary.NullTypes.StringNT EnteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAnnullamentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis, 
SiarLibrary.NullTypes.StringNT NominativoIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT CuaaEntranteEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloEntranteEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaUscenteEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloUscenteEqualThis, SiarLibrary.NullTypes.StringNT RagsocUscenteEqualThis, 
SiarLibrary.NullTypes.IntNT IdAttoApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT AwDocnumberEqualThis, SiarLibrary.NullTypes.StringNT CodDefinizioneEqualThis, 
SiarLibrary.NullTypes.IntNT AwDocnumberNuovoEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis, 
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			VariantiModificheCollection VariantiModificheCollectionObj = new VariantiModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zvariantimodifichefindselect", new string[] {"IdVarianteequalthis", "IdProgettoequalthis", "CodTipoequalthis", 
"DataInserimentoequalthis", "CodEnteequalthis", "Operatoreequalthis", 
"DataModificaequalthis", "Segnaturaequalthis", "SegnaturaAllegatiequalthis", 
"SegnaturaApprovazioneequalthis", "Approvataequalthis", "Istruttoreequalthis", 
"TipoVarianteequalthis", "Nominativoequalthis", "Profiloequalthis", 
"Enteequalthis", "DataApprovazioneequalthis", "Provinciaequalthis", 
"Descrizioneequalthis", "Annullataequalthis", "SegnaturaAnnullamentoequalthis", 
"CfOperatoreAnnullamentoequalthis", "DataAnnullamentoequalthis", "NominativoOperatoreAnnullamentoequalthis", 
"NominativoIstruttoreequalthis", "CuaaEntranteequalthis", "IdFascicoloEntranteequalthis", 
"CuaaUscenteequalthis", "IdFascicoloUscenteequalthis", "RagsocUscenteequalthis", 
"IdAttoApprovazioneequalthis", "AwDocnumberequalthis", "CodDefinizioneequalthis", 
"AwDocnumberNuovoequalthis", "FirmaPredispostaRupequalthis", "FirmaPredispostaequalthis", 
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "string", 
"DateTime", "string", "string", 
"string", "bool", "string", 
"string", "string", "string", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"string", "DateTime", "string", 
"string", "string", "int", 
"string", "int", "string", 
"int", "string", "string", 
"int", "bool", "bool", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaApprovazioneequalthis", SegnaturaApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoVarianteequalthis", TipoVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nominativoequalthis", NominativoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Profiloequalthis", ProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Enteequalthis", EnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaAnnullamentoequalthis", SegnaturaAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreAnnullamentoequalthis", CfOperatoreAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NominativoOperatoreAnnullamentoequalthis", NominativoOperatoreAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NominativoIstruttoreequalthis", NominativoIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaEntranteequalthis", CuaaEntranteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFascicoloEntranteequalthis", IdFascicoloEntranteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaUscenteequalthis", CuaaUscenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFascicoloUscenteequalthis", IdFascicoloUscenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagsocUscenteequalthis", RagsocUscenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoApprovazioneequalthis", IdAttoApprovazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AwDocnumberequalthis", AwDocnumberEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodDefinizioneequalthis", CodDefinizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AwDocnumberNuovoequalthis", AwDocnumberNuovoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			VariantiModifiche VariantiModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VariantiModificheObj = GetFromDatareader(db);
				VariantiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VariantiModificheObj.IsDirty = false;
				VariantiModificheObj.IsPersistent = true;
				VariantiModificheCollectionObj.Add(VariantiModificheObj);
			}
			db.Close();
			return VariantiModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VariantiModificheCollectionProvider:IVariantiModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VariantiModificheCollectionProvider : IVariantiModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VariantiModifiche
		protected VariantiModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VariantiModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VariantiModificheCollection(this);
		}

		//Costruttore3: ha in input variantimodificheCollectionObj - non popola la collection
		public VariantiModificheCollectionProvider(VariantiModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VariantiModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VariantiModificheCollection(this);
		}

		//Get e Set
		public VariantiModificheCollection CollectionObj
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
		public int SaveCollection(VariantiModificheCollection collectionObj)
		{
			return VariantiModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VariantiModifiche variantimodificheObj)
		{
			return VariantiModificheDAL.Save(_dbProviderObj, variantimodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VariantiModificheCollection collectionObj)
		{
			return VariantiModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VariantiModifiche variantimodificheObj)
		{
			return VariantiModificheDAL.Delete(_dbProviderObj, variantimodificheObj);
		}

		//getById
		public VariantiModifiche GetById(IntNT IdValue)
		{
			VariantiModifiche VariantiModificheTemp = VariantiModificheDAL.GetById(_dbProviderObj, IdValue);
			if (VariantiModificheTemp!=null) VariantiModificheTemp.Provider = this;
			return VariantiModificheTemp;
		}

		//Select: popola la collection
		public VariantiModificheCollection Select(IntNT IdvarianteEqualThis, IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, 
DatetimeNT DatainserimentoEqualThis, StringNT CodenteEqualThis, StringNT OperatoreEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT SegnaturaEqualThis, StringNT SegnaturaallegatiEqualThis, 
StringNT SegnaturaapprovazioneEqualThis, BoolNT ApprovataEqualThis, StringNT IstruttoreEqualThis, 
StringNT TipovarianteEqualThis, StringNT NominativoEqualThis, StringNT ProfiloEqualThis, 
StringNT EnteEqualThis, DatetimeNT DataapprovazioneEqualThis, StringNT ProvinciaEqualThis, 
StringNT DescrizioneEqualThis, BoolNT AnnullataEqualThis, StringNT SegnaturaannullamentoEqualThis, 
StringNT CfoperatoreannullamentoEqualThis, DatetimeNT DataannullamentoEqualThis, StringNT NominativooperatoreannullamentoEqualThis, 
StringNT NominativoistruttoreEqualThis, StringNT CuaaentranteEqualThis, IntNT IdfascicoloentranteEqualThis, 
StringNT CuaauscenteEqualThis, IntNT IdfascicolouscenteEqualThis, StringNT RagsocuscenteEqualThis, 
IntNT IdattoapprovazioneEqualThis, StringNT AwdocnumberEqualThis, StringNT CoddefinizioneEqualThis, 
IntNT AwdocnumbernuovoEqualThis, BoolNT FirmapredispostarupEqualThis, BoolNT FirmapredispostaEqualThis, 
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			VariantiModificheCollection VariantiModificheCollectionTemp = VariantiModificheDAL.Select(_dbProviderObj, IdvarianteEqualThis, IdprogettoEqualThis, CodtipoEqualThis, 
DatainserimentoEqualThis, CodenteEqualThis, OperatoreEqualThis, 
DatamodificaEqualThis, SegnaturaEqualThis, SegnaturaallegatiEqualThis, 
SegnaturaapprovazioneEqualThis, ApprovataEqualThis, IstruttoreEqualThis, 
TipovarianteEqualThis, NominativoEqualThis, ProfiloEqualThis, 
EnteEqualThis, DataapprovazioneEqualThis, ProvinciaEqualThis, 
DescrizioneEqualThis, AnnullataEqualThis, SegnaturaannullamentoEqualThis, 
CfoperatoreannullamentoEqualThis, DataannullamentoEqualThis, NominativooperatoreannullamentoEqualThis, 
NominativoistruttoreEqualThis, CuaaentranteEqualThis, IdfascicoloentranteEqualThis, 
CuaauscenteEqualThis, IdfascicolouscenteEqualThis, RagsocuscenteEqualThis, 
IdattoapprovazioneEqualThis, AwdocnumberEqualThis, CoddefinizioneEqualThis, 
AwdocnumbernuovoEqualThis, FirmapredispostarupEqualThis, FirmapredispostaEqualThis, 
IdEqualThis, IdmodificaEqualThis);
			VariantiModificheCollectionTemp.Provider = this;
			return VariantiModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_MODIFICHE>
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
</VARIANTI_MODIFICHE>
*/
