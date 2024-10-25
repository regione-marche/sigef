using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per AssistenzaUtenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IAssistenzaUtentiProvider
	{
		int Save(AssistenzaUtenti AssistenzaUtentiObj);
		int SaveCollection(AssistenzaUtentiCollection collectionObj);
		int Delete(AssistenzaUtenti AssistenzaUtentiObj);
		int DeleteCollection(AssistenzaUtentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for AssistenzaUtenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class AssistenzaUtenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _CodTipoRichiesta;
		private NullTypes.StringNT _DescrizioneTipologia;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _Titolo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdUtenteInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.BoolNT _Gestita;
		private NullTypes.BoolNT _Risolta;
		private NullTypes.IntNT _IdOperatoreGestione;
		private NullTypes.StringNT _NominativoOperatoreGestione;
		private NullTypes.DatetimeNT _DataGestione;
		private NullTypes.DatetimeNT _DataRisoluzione;
		private NullTypes.StringNT _NoteHelpDesk;
		private NullTypes.StringNT _PassId;
		[NonSerialized] private IAssistenzaUtentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssistenzaUtentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public AssistenzaUtenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:COD_TIPO_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoRichiesta
		{
			get { return _CodTipoRichiesta; }
			set {
				if (CodTipoRichiesta != value)
				{
					_CodTipoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPOLOGIA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipologia
		{
			get { return _DescrizioneTipologia; }
			set {
				if (DescrizioneTipologia != value)
				{
					_DescrizioneTipologia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COGNOME
		/// Tipo sul db:NCHAR(10)
		/// </summary>
		public NullTypes.StringNT Cognome
		{
			get { return _Cognome; }
			set {
				if (Cognome != value)
				{
					_Cognome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME
		/// Tipo sul db:NCHAR(10)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Email
		{
			get { return _Email; }
			set {
				if (Email != value)
				{
					_Email = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:VARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Titolo
		{
			get { return _Titolo; }
			set {
				if (Titolo != value)
				{
					_Titolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
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
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
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

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtenteInserimento
		{
			get { return _IdUtenteInserimento; }
			set {
				if (IdUtenteInserimento != value)
				{
					_IdUtenteInserimento = value;
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
		/// Corrisponde al campo:GESTITA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Gestita
		{
			get { return _Gestita; }
			set {
				if (Gestita != value)
				{
					_Gestita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RISOLTA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Risolta
		{
			get { return _Risolta; }
			set {
				if (Risolta != value)
				{
					_Risolta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_GESTIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreGestione
		{
			get { return _IdOperatoreGestione; }
			set {
				if (IdOperatoreGestione != value)
				{
					_IdOperatoreGestione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_OPERATORE_GESTIONE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoOperatoreGestione
		{
			get { return _NominativoOperatoreGestione; }
			set {
				if (NominativoOperatoreGestione != value)
				{
					_NominativoOperatoreGestione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_GESTIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataGestione
		{
			get { return _DataGestione; }
			set {
				if (DataGestione != value)
				{
					_DataGestione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RISOLUZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRisoluzione
		{
			get { return _DataRisoluzione; }
			set {
				if (DataRisoluzione != value)
				{
					_DataRisoluzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE_HELP_DESK
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT NoteHelpDesk
		{
			get { return _NoteHelpDesk; }
			set {
				if (NoteHelpDesk != value)
				{
					_NoteHelpDesk = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PASS_ID
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT PassId
		{
			get { return _PassId; }
			set {
				if (PassId != value)
				{
					_PassId = value;
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
	/// Summary description for AssistenzaUtentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssistenzaUtentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private AssistenzaUtentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((AssistenzaUtenti) info.GetValue(i.ToString(),typeof(AssistenzaUtenti)));
			}
		}

		//Costruttore
		public AssistenzaUtentiCollection()
		{
			this.ItemType = typeof(AssistenzaUtenti);
		}

		//Costruttore con provider
		public AssistenzaUtentiCollection(IAssistenzaUtentiProvider providerObj)
		{
			this.ItemType = typeof(AssistenzaUtenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new AssistenzaUtenti this[int index]
		{
			get { return (AssistenzaUtenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new AssistenzaUtentiCollection GetChanges()
		{
			return (AssistenzaUtentiCollection) base.GetChanges();
		}

		[NonSerialized] private IAssistenzaUtentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IAssistenzaUtentiProvider Provider
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
		public int Add(AssistenzaUtenti AssistenzaUtentiObj)
		{
			if (AssistenzaUtentiObj.Provider == null) AssistenzaUtentiObj.Provider = this.Provider;
			return base.Add(AssistenzaUtentiObj);
		}

		//AddCollection
		public void AddCollection(AssistenzaUtentiCollection AssistenzaUtentiCollectionObj)
		{
			foreach (AssistenzaUtenti AssistenzaUtentiObj in AssistenzaUtentiCollectionObj)
				this.Add(AssistenzaUtentiObj);
		}

		//Insert
		public void Insert(int index, AssistenzaUtenti AssistenzaUtentiObj)
		{
			if (AssistenzaUtentiObj.Provider == null) AssistenzaUtentiObj.Provider = this.Provider;
			base.Insert(index, AssistenzaUtentiObj);
		}

		//CollectionGetById
		public AssistenzaUtenti CollectionGetById(NullTypes.IntNT IdValue)
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
		public AssistenzaUtentiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT CodTipoRichiestaEqualThis, NullTypes.StringNT CognomeEqualThis, 
NullTypes.StringNT NomeEqualThis, NullTypes.StringNT EmailEqualThis, NullTypes.StringNT TitoloEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.IntNT IdUtenteInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.BoolNT GestitaEqualThis, 
NullTypes.BoolNT RisoltaEqualThis, NullTypes.IntNT IdOperatoreGestioneEqualThis, NullTypes.DatetimeNT DataGestioneEqualThis, 
NullTypes.DatetimeNT DataRisoluzioneEqualThis, NullTypes.StringNT NoteHelpDeskEqualThis, NullTypes.StringNT PassIdEqualThis)
		{
			AssistenzaUtentiCollection AssistenzaUtentiCollectionTemp = new AssistenzaUtentiCollection();
			foreach (AssistenzaUtenti AssistenzaUtentiItem in this)
			{
				if (((IdEqualThis == null) || ((AssistenzaUtentiItem.Id != null) && (AssistenzaUtentiItem.Id.Value == IdEqualThis.Value))) && ((CodTipoRichiestaEqualThis == null) || ((AssistenzaUtentiItem.CodTipoRichiesta != null) && (AssistenzaUtentiItem.CodTipoRichiesta.Value == CodTipoRichiestaEqualThis.Value))) && ((CognomeEqualThis == null) || ((AssistenzaUtentiItem.Cognome != null) && (AssistenzaUtentiItem.Cognome.Value == CognomeEqualThis.Value))) && 
((NomeEqualThis == null) || ((AssistenzaUtentiItem.Nome != null) && (AssistenzaUtentiItem.Nome.Value == NomeEqualThis.Value))) && ((EmailEqualThis == null) || ((AssistenzaUtentiItem.Email != null) && (AssistenzaUtentiItem.Email.Value == EmailEqualThis.Value))) && ((TitoloEqualThis == null) || ((AssistenzaUtentiItem.Titolo != null) && (AssistenzaUtentiItem.Titolo.Value == TitoloEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((AssistenzaUtentiItem.Descrizione != null) && (AssistenzaUtentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((AssistenzaUtentiItem.IdProgetto != null) && (AssistenzaUtentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((AssistenzaUtentiItem.IdImpresa != null) && (AssistenzaUtentiItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdUtenteInserimentoEqualThis == null) || ((AssistenzaUtentiItem.IdUtenteInserimento != null) && (AssistenzaUtentiItem.IdUtenteInserimento.Value == IdUtenteInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((AssistenzaUtentiItem.DataInserimento != null) && (AssistenzaUtentiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((GestitaEqualThis == null) || ((AssistenzaUtentiItem.Gestita != null) && (AssistenzaUtentiItem.Gestita.Value == GestitaEqualThis.Value))) && 
((RisoltaEqualThis == null) || ((AssistenzaUtentiItem.Risolta != null) && (AssistenzaUtentiItem.Risolta.Value == RisoltaEqualThis.Value))) && ((IdOperatoreGestioneEqualThis == null) || ((AssistenzaUtentiItem.IdOperatoreGestione != null) && (AssistenzaUtentiItem.IdOperatoreGestione.Value == IdOperatoreGestioneEqualThis.Value))) && ((DataGestioneEqualThis == null) || ((AssistenzaUtentiItem.DataGestione != null) && (AssistenzaUtentiItem.DataGestione.Value == DataGestioneEqualThis.Value))) && 
((DataRisoluzioneEqualThis == null) || ((AssistenzaUtentiItem.DataRisoluzione != null) && (AssistenzaUtentiItem.DataRisoluzione.Value == DataRisoluzioneEqualThis.Value))) && ((NoteHelpDeskEqualThis == null) || ((AssistenzaUtentiItem.NoteHelpDesk != null) && (AssistenzaUtentiItem.NoteHelpDesk.Value == NoteHelpDeskEqualThis.Value))) && ((PassIdEqualThis == null) || ((AssistenzaUtentiItem.PassId != null) && (AssistenzaUtentiItem.PassId.Value == PassIdEqualThis.Value))))
				{
					AssistenzaUtentiCollectionTemp.Add(AssistenzaUtentiItem);
				}
			}
			return AssistenzaUtentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public AssistenzaUtentiCollection Filter(NullTypes.IntNT CodTipoRichiestaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.IntNT IdUtenteInserimentoEqualThis, NullTypes.BoolNT GestitaEqualThis, NullTypes.BoolNT RisoltaEqualThis, 
NullTypes.IntNT IdOperatoreGestioneEqualThis)
		{
			AssistenzaUtentiCollection AssistenzaUtentiCollectionTemp = new AssistenzaUtentiCollection();
			foreach (AssistenzaUtenti AssistenzaUtentiItem in this)
			{
				if (((CodTipoRichiestaEqualThis == null) || ((AssistenzaUtentiItem.CodTipoRichiesta != null) && (AssistenzaUtentiItem.CodTipoRichiesta.Value == CodTipoRichiestaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((AssistenzaUtentiItem.IdProgetto != null) && (AssistenzaUtentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((AssistenzaUtentiItem.IdImpresa != null) && (AssistenzaUtentiItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdUtenteInserimentoEqualThis == null) || ((AssistenzaUtentiItem.IdUtenteInserimento != null) && (AssistenzaUtentiItem.IdUtenteInserimento.Value == IdUtenteInserimentoEqualThis.Value))) && ((GestitaEqualThis == null) || ((AssistenzaUtentiItem.Gestita != null) && (AssistenzaUtentiItem.Gestita.Value == GestitaEqualThis.Value))) && ((RisoltaEqualThis == null) || ((AssistenzaUtentiItem.Risolta != null) && (AssistenzaUtentiItem.Risolta.Value == RisoltaEqualThis.Value))) && 
((IdOperatoreGestioneEqualThis == null) || ((AssistenzaUtentiItem.IdOperatoreGestione != null) && (AssistenzaUtentiItem.IdOperatoreGestione.Value == IdOperatoreGestioneEqualThis.Value))))
				{
					AssistenzaUtentiCollectionTemp.Add(AssistenzaUtentiItem);
				}
			}
			return AssistenzaUtentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for AssistenzaUtentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class AssistenzaUtentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, AssistenzaUtenti AssistenzaUtentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", AssistenzaUtentiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoRichiesta", AssistenzaUtentiObj.CodTipoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "Cognome", AssistenzaUtentiObj.Cognome);
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", AssistenzaUtentiObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Email", AssistenzaUtentiObj.Email);
			DbProvider.SetCmdParam(cmd,firstChar + "Titolo", AssistenzaUtentiObj.Titolo);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", AssistenzaUtentiObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", AssistenzaUtentiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", AssistenzaUtentiObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtenteInserimento", AssistenzaUtentiObj.IdUtenteInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", AssistenzaUtentiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Gestita", AssistenzaUtentiObj.Gestita);
			DbProvider.SetCmdParam(cmd,firstChar + "Risolta", AssistenzaUtentiObj.Risolta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreGestione", AssistenzaUtentiObj.IdOperatoreGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataGestione", AssistenzaUtentiObj.DataGestione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRisoluzione", AssistenzaUtentiObj.DataRisoluzione);
			DbProvider.SetCmdParam(cmd,firstChar + "NoteHelpDesk", AssistenzaUtentiObj.NoteHelpDesk);
			DbProvider.SetCmdParam(cmd,firstChar + "PassId", AssistenzaUtentiObj.PassId);
		}
		//Insert
		private static int Insert(DbProvider db, AssistenzaUtenti AssistenzaUtentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZAssistenzaUtentiInsert", new string[] {"CodTipoRichiesta", 
"Cognome", "Nome", "Email", 
"Titolo", "Descrizione", "IdProgetto", 
"IdImpresa", 
"IdUtenteInserimento", "DataInserimento", 
"Gestita", "Risolta", "IdOperatoreGestione", 
"DataGestione", "DataRisoluzione", 
"NoteHelpDesk", "PassId"}, new string[] {"int", 
"string", "string", "string", 
"string", "string", "int", 
"int", 
"int", "DateTime", 
"bool", "bool", "int", 
"DateTime", "DateTime", 
"string", "string"},"");
				CompileIUCmd(false, insertCmd,AssistenzaUtentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				AssistenzaUtentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiObj.IsDirty = false;
				AssistenzaUtentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, AssistenzaUtenti AssistenzaUtentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssistenzaUtentiUpdate", new string[] {"Id", "CodTipoRichiesta", 
"Cognome", "Nome", "Email", 
"Titolo", "Descrizione", "IdProgetto", 
"IdImpresa", 
"IdUtenteInserimento", "DataInserimento", 
"Gestita", "Risolta", "IdOperatoreGestione", 
"DataGestione", "DataRisoluzione", 
"NoteHelpDesk", "PassId"}, new string[] {"int", "int", 
"string", "string", "string", 
"string", "string", "int", 
"int", 
"int", "DateTime", 
"bool", "bool", "int", 
"DateTime", "DateTime", 
"string", "string"},"");
				CompileIUCmd(true, updateCmd,AssistenzaUtentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiObj.IsDirty = false;
				AssistenzaUtentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, AssistenzaUtenti AssistenzaUtentiObj)
		{
			switch (AssistenzaUtentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, AssistenzaUtentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, AssistenzaUtentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,AssistenzaUtentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, AssistenzaUtentiCollection AssistenzaUtentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZAssistenzaUtentiUpdate", new string[] {"Id", "CodTipoRichiesta", 
"Cognome", "Nome", "Email", 
"Titolo", "Descrizione", "IdProgetto", 
"IdImpresa", 
"IdUtenteInserimento", "DataInserimento", 
"Gestita", "Risolta", "IdOperatoreGestione", 
"DataGestione", "DataRisoluzione", 
"NoteHelpDesk", "PassId"}, new string[] {"int", "int", 
"string", "string", "string", 
"string", "string", "int", 
"int", 
"int", "DateTime", 
"bool", "bool", "int", 
"DateTime", "DateTime", 
"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZAssistenzaUtentiInsert", new string[] {"CodTipoRichiesta", 
"Cognome", "Nome", "Email", 
"Titolo", "Descrizione", "IdProgetto", 
"IdImpresa", 
"IdUtenteInserimento", "DataInserimento", 
"Gestita", "Risolta", "IdOperatoreGestione", 
"DataGestione", "DataRisoluzione", 
"NoteHelpDesk", "PassId"}, new string[] {"int", 
"string", "string", "string", 
"string", "string", "int", 
"int", 
"int", "DateTime", 
"bool", "bool", "int", 
"DateTime", "DateTime", 
"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AssistenzaUtentiCollectionObj.Count; i++)
				{
					switch (AssistenzaUtentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,AssistenzaUtentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									AssistenzaUtentiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,AssistenzaUtentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (AssistenzaUtentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)AssistenzaUtentiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < AssistenzaUtentiCollectionObj.Count; i++)
				{
					if ((AssistenzaUtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssistenzaUtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssistenzaUtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						AssistenzaUtentiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiCollectionObj[i].IsPersistent = true;
					}
					if ((AssistenzaUtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						AssistenzaUtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssistenzaUtentiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, AssistenzaUtenti AssistenzaUtentiObj)
		{
			int returnValue = 0;
			if (AssistenzaUtentiObj.IsPersistent) 
			{
				returnValue = Delete(db, AssistenzaUtentiObj.Id);
			}
			AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			AssistenzaUtentiObj.IsDirty = false;
			AssistenzaUtentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, AssistenzaUtentiCollection AssistenzaUtentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZAssistenzaUtentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < AssistenzaUtentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", AssistenzaUtentiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < AssistenzaUtentiCollectionObj.Count; i++)
				{
					if ((AssistenzaUtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (AssistenzaUtentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						AssistenzaUtentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						AssistenzaUtentiCollectionObj[i].IsDirty = false;
						AssistenzaUtentiCollectionObj[i].IsPersistent = false;
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
		public static AssistenzaUtenti GetById(DbProvider db, int IdValue)
		{
			AssistenzaUtenti AssistenzaUtentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZAssistenzaUtentiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				AssistenzaUtentiObj = GetFromDatareader(db);
				AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiObj.IsDirty = false;
				AssistenzaUtentiObj.IsPersistent = true;
			}
			db.Close();
			return AssistenzaUtentiObj;
		}

		//getFromDatareader
		public static AssistenzaUtenti GetFromDatareader(DbProvider db)
		{
			AssistenzaUtenti AssistenzaUtentiObj = new AssistenzaUtenti();
			AssistenzaUtentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			AssistenzaUtentiObj.CodTipoRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_RICHIESTA"]);
			AssistenzaUtentiObj.DescrizioneTipologia = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPOLOGIA"]);
			AssistenzaUtentiObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			AssistenzaUtentiObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			AssistenzaUtentiObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			AssistenzaUtentiObj.Titolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO"]);
			AssistenzaUtentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			AssistenzaUtentiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			AssistenzaUtentiObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			AssistenzaUtentiObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			AssistenzaUtentiObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			AssistenzaUtentiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			AssistenzaUtentiObj.IdUtenteInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_INSERIMENTO"]);
			AssistenzaUtentiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			AssistenzaUtentiObj.Gestita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["GESTITA"]);
			AssistenzaUtentiObj.Risolta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RISOLTA"]);
			AssistenzaUtentiObj.IdOperatoreGestione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_GESTIONE"]);
			AssistenzaUtentiObj.NominativoOperatoreGestione = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_GESTIONE"]);
			AssistenzaUtentiObj.DataGestione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_GESTIONE"]);
			AssistenzaUtentiObj.DataRisoluzione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RISOLUZIONE"]);
			AssistenzaUtentiObj.NoteHelpDesk = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_HELP_DESK"]);
			AssistenzaUtentiObj.PassId = new SiarLibrary.NullTypes.StringNT(db.DataReader["PASS_ID"]);
			AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			AssistenzaUtentiObj.IsDirty = false;
			AssistenzaUtentiObj.IsPersistent = true;
			return AssistenzaUtentiObj;
		}

		//Find Select

		public static AssistenzaUtentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT CodTipoRichiestaEqualThis, SiarLibrary.NullTypes.StringNT CognomeEqualThis, 
SiarLibrary.NullTypes.StringNT NomeEqualThis, SiarLibrary.NullTypes.StringNT EmailEqualThis, SiarLibrary.NullTypes.StringNT TitoloEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdUtenteInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.BoolNT GestitaEqualThis, 
SiarLibrary.NullTypes.BoolNT RisoltaEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreGestioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataGestioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRisoluzioneEqualThis, SiarLibrary.NullTypes.StringNT NoteHelpDeskEqualThis, SiarLibrary.NullTypes.StringNT PassIdEqualThis)

		{

			AssistenzaUtentiCollection AssistenzaUtentiCollectionObj = new AssistenzaUtentiCollection();

			IDbCommand findCmd = db.InitCmd("Zassistenzautentifindselect", new string[] {"Idequalthis", "CodTipoRichiestaequalthis", "Cognomeequalthis", 
"Nomeequalthis", "Emailequalthis", "Titoloequalthis", 
"Descrizioneequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdUtenteInserimentoequalthis", "DataInserimentoequalthis", "Gestitaequalthis", 
"Risoltaequalthis", "IdOperatoreGestioneequalthis", "DataGestioneequalthis", 
"DataRisoluzioneequalthis", "NoteHelpDeskequalthis", "PassIdequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string", "int", "int", 
"int", "DateTime", "bool", 
"bool", "int", "DateTime", 
"DateTime", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoRichiestaequalthis", CodTipoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cognomeequalthis", CognomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteInserimentoequalthis", IdUtenteInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gestitaequalthis", GestitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Risoltaequalthis", RisoltaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreGestioneequalthis", IdOperatoreGestioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataGestioneequalthis", DataGestioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRisoluzioneequalthis", DataRisoluzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NoteHelpDeskequalthis", NoteHelpDeskEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PassIdequalthis", PassIdEqualThis);
			AssistenzaUtenti AssistenzaUtentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssistenzaUtentiObj = GetFromDatareader(db);
				AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiObj.IsDirty = false;
				AssistenzaUtentiObj.IsPersistent = true;
				AssistenzaUtentiCollectionObj.Add(AssistenzaUtentiObj);
			}
			db.Close();
			return AssistenzaUtentiCollectionObj;
		}

		//Find Find

		public static AssistenzaUtentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT CodTipoRichiestaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdUtenteInserimentoEqualThis, SiarLibrary.NullTypes.BoolNT GestitaEqualThis, SiarLibrary.NullTypes.BoolNT RisoltaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreGestioneEqualThis, SiarLibrary.NullTypes.StringNT PassIdEqualThis)

		{

			AssistenzaUtentiCollection AssistenzaUtentiCollectionObj = new AssistenzaUtentiCollection();

			IDbCommand findCmd = db.InitCmd("Zassistenzautentifindfind", new string[] {"CodTipoRichiestaequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdUtenteInserimentoequalthis", "Gestitaequalthis", "Risoltaequalthis", 
"IdOperatoreGestioneequalthis", "PassIdequalthis"}, new string[] {"int", "int", "int", 
"int", "bool", "bool", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoRichiestaequalthis", CodTipoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteInserimentoequalthis", IdUtenteInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Gestitaequalthis", GestitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Risoltaequalthis", RisoltaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreGestioneequalthis", IdOperatoreGestioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PassIdequalthis", PassIdEqualThis);
			AssistenzaUtenti AssistenzaUtentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				AssistenzaUtentiObj = GetFromDatareader(db);
				AssistenzaUtentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				AssistenzaUtentiObj.IsDirty = false;
				AssistenzaUtentiObj.IsPersistent = true;
				AssistenzaUtentiCollectionObj.Add(AssistenzaUtentiObj);
			}
			db.Close();
			return AssistenzaUtentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for AssistenzaUtentiCollectionProvider:IAssistenzaUtentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class AssistenzaUtentiCollectionProvider : IAssistenzaUtentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di AssistenzaUtenti
		protected AssistenzaUtentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public AssistenzaUtentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new AssistenzaUtentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public AssistenzaUtentiCollectionProvider(IntNT CodtiporichiestaEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdutenteinserimentoEqualThis, BoolNT GestitaEqualThis, BoolNT RisoltaEqualThis, 
IntNT IdoperatoregestioneEqualThis, StringNT PassidEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodtiporichiestaEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdutenteinserimentoEqualThis, GestitaEqualThis, RisoltaEqualThis, 
IdoperatoregestioneEqualThis, PassidEqualThis);
		}

		//Costruttore3: ha in input assistenzautentiCollectionObj - non popola la collection
		public AssistenzaUtentiCollectionProvider(AssistenzaUtentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public AssistenzaUtentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new AssistenzaUtentiCollection(this);
		}

		//Get e Set
		public AssistenzaUtentiCollection CollectionObj
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
		public int SaveCollection(AssistenzaUtentiCollection collectionObj)
		{
			return AssistenzaUtentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(AssistenzaUtenti assistenzautentiObj)
		{
			return AssistenzaUtentiDAL.Save(_dbProviderObj, assistenzautentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(AssistenzaUtentiCollection collectionObj)
		{
			return AssistenzaUtentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(AssistenzaUtenti assistenzautentiObj)
		{
			return AssistenzaUtentiDAL.Delete(_dbProviderObj, assistenzautentiObj);
		}

		//getById
		public AssistenzaUtenti GetById(IntNT IdValue)
		{
			AssistenzaUtenti AssistenzaUtentiTemp = AssistenzaUtentiDAL.GetById(_dbProviderObj, IdValue);
			if (AssistenzaUtentiTemp!=null) AssistenzaUtentiTemp.Provider = this;
			return AssistenzaUtentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public AssistenzaUtentiCollection Select(IntNT IdEqualThis, IntNT CodtiporichiestaEqualThis, StringNT CognomeEqualThis, 
StringNT NomeEqualThis, StringNT EmailEqualThis, StringNT TitoloEqualThis, 
StringNT DescrizioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdutenteinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, BoolNT GestitaEqualThis, 
BoolNT RisoltaEqualThis, IntNT IdoperatoregestioneEqualThis, DatetimeNT DatagestioneEqualThis, 
DatetimeNT DatarisoluzioneEqualThis, StringNT NotehelpdeskEqualThis, StringNT PassidEqualThis)
		{
			AssistenzaUtentiCollection AssistenzaUtentiCollectionTemp = AssistenzaUtentiDAL.Select(_dbProviderObj, IdEqualThis, CodtiporichiestaEqualThis, CognomeEqualThis, 
NomeEqualThis, EmailEqualThis, TitoloEqualThis, 
DescrizioneEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdutenteinserimentoEqualThis, DatainserimentoEqualThis, GestitaEqualThis, 
RisoltaEqualThis, IdoperatoregestioneEqualThis, DatagestioneEqualThis, 
DatarisoluzioneEqualThis, NotehelpdeskEqualThis, PassidEqualThis);
			AssistenzaUtentiCollectionTemp.Provider = this;
			return AssistenzaUtentiCollectionTemp;
		}

		//Find: popola la collection
		public AssistenzaUtentiCollection Find(IntNT CodtiporichiestaEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdutenteinserimentoEqualThis, BoolNT GestitaEqualThis, BoolNT RisoltaEqualThis, 
IntNT IdoperatoregestioneEqualThis, StringNT PassidEqualThis)
		{
			AssistenzaUtentiCollection AssistenzaUtentiCollectionTemp = AssistenzaUtentiDAL.Find(_dbProviderObj, CodtiporichiestaEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdutenteinserimentoEqualThis, GestitaEqualThis, RisoltaEqualThis, 
IdoperatoregestioneEqualThis, PassidEqualThis);
			AssistenzaUtentiCollectionTemp.Provider = this;
			return AssistenzaUtentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ASSISTENZA_UTENTI>
  <ViewName>vASSISTENZA_UTENTI</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INSERIMENTO DESC">
      <COD_TIPO_RICHIESTA>Equal</COD_TIPO_RICHIESTA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_UTENTE_INSERIMENTO>Equal</ID_UTENTE_INSERIMENTO>
      <GESTITA>Equal</GESTITA>
      <RISOLTA>Equal</RISOLTA>
      <ID_OPERATORE_GESTIONE>Equal</ID_OPERATORE_GESTIONE>
      <PASS_ID>Equal</PASS_ID>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <COD_TIPO_RICHIESTA>Equal</COD_TIPO_RICHIESTA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_UTENTE_INSERIMENTO>Equal</ID_UTENTE_INSERIMENTO>
      <GESTITA>Equal</GESTITA>
      <RISOLTA>Equal</RISOLTA>
      <ID_OPERATORE_GESTIONE>Equal</ID_OPERATORE_GESTIONE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ASSISTENZA_UTENTI>
*/
