using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RichiestaConsulente
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRichiestaConsulenteProvider
	{
		int Save(RichiestaConsulente RichiestaConsulenteObj);
		int SaveCollection(RichiestaConsulenteCollection collectionObj);
		int Delete(RichiestaConsulente RichiestaConsulenteObj);
		int DeleteCollection(RichiestaConsulenteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RichiestaConsulente
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RichiestaConsulente: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRichiestaConsulente;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.IntNT _IdConsulente;
		private NullTypes.StringNT _CfUtenteConsulente;
		private NullTypes.StringNT _NominativoConsulente;
		private NullTypes.DatetimeNT _DataInizioAbilitazione;
		private NullTypes.DatetimeNT _DataFineAbilitazione;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.BoolNT _Approvata;
		private NullTypes.BoolNT _Rifiutata;
		private NullTypes.StringNT _MotivazioneRifiuto;
		private NullTypes.BoolNT _Inviata;
		private NullTypes.BoolNT _Istruita;
		private NullTypes.StringNT _SegnaturaIstruttoria;
		private NullTypes.BoolNT _ProcuraSpeciale;
		[NonSerialized] private IRichiestaConsulenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RichiestaConsulente()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulente
		{
			get { return _IdRichiestaConsulente; }
			set {
				if (IdRichiestaConsulente != value)
				{
					_IdRichiestaConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtente
		{
			get { return _CfUtente; }
			set {
				if (CfUtente != value)
				{
					_CfUtente = value;
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
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CONSULENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdConsulente
		{
			get { return _IdConsulente; }
			set {
				if (IdConsulente != value)
				{
					_IdConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_UTENTE_CONSULENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtenteConsulente
		{
			get { return _CfUtenteConsulente; }
			set {
				if (CfUtenteConsulente != value)
				{
					_CfUtenteConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO_CONSULENTE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT NominativoConsulente
		{
			get { return _NominativoConsulente; }
			set {
				if (NominativoConsulente != value)
				{
					_NominativoConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_ABILITAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioAbilitazione
		{
			get { return _DataInizioAbilitazione; }
			set {
				if (DataInizioAbilitazione != value)
				{
					_DataInizioAbilitazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_ABILITAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineAbilitazione
		{
			get { return _DataFineAbilitazione; }
			set {
				if (DataFineAbilitazione != value)
				{
					_DataFineAbilitazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(200)
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
		/// Corrisponde al campo:RIFIUTATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Rifiutata
		{
			get { return _Rifiutata; }
			set {
				if (Rifiutata != value)
				{
					_Rifiutata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE_RIFIUTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT MotivazioneRifiuto
		{
			get { return _MotivazioneRifiuto; }
			set {
				if (MotivazioneRifiuto != value)
				{
					_MotivazioneRifiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INVIATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Inviata
		{
			get { return _Inviata; }
			set {
				if (Inviata != value)
				{
					_Inviata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUITA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Istruita
		{
			get { return _Istruita; }
			set {
				if (Istruita != value)
				{
					_Istruita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ISTRUTTORIA
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT SegnaturaIstruttoria
		{
			get { return _SegnaturaIstruttoria; }
			set {
				if (SegnaturaIstruttoria != value)
				{
					_SegnaturaIstruttoria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROCURA_SPECIALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ProcuraSpeciale
		{
			get { return _ProcuraSpeciale; }
			set {
				if (ProcuraSpeciale != value)
				{
					_ProcuraSpeciale = value;
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
	/// Summary description for RichiestaConsulenteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RichiestaConsulenteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RichiestaConsulente) info.GetValue(i.ToString(),typeof(RichiestaConsulente)));
			}
		}

		//Costruttore
		public RichiestaConsulenteCollection()
		{
			this.ItemType = typeof(RichiestaConsulente);
		}

		//Costruttore con provider
		public RichiestaConsulenteCollection(IRichiestaConsulenteProvider providerObj)
		{
			this.ItemType = typeof(RichiestaConsulente);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RichiestaConsulente this[int index]
		{
			get { return (RichiestaConsulente)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RichiestaConsulenteCollection GetChanges()
		{
			return (RichiestaConsulenteCollection) base.GetChanges();
		}

		[NonSerialized] private IRichiestaConsulenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProvider Provider
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
		public int Add(RichiestaConsulente RichiestaConsulenteObj)
		{
			if (RichiestaConsulenteObj.Provider == null) RichiestaConsulenteObj.Provider = this.Provider;
			return base.Add(RichiestaConsulenteObj);
		}

		//AddCollection
		public void AddCollection(RichiestaConsulenteCollection RichiestaConsulenteCollectionObj)
		{
			foreach (RichiestaConsulente RichiestaConsulenteObj in RichiestaConsulenteCollectionObj)
				this.Add(RichiestaConsulenteObj);
		}

		//Insert
		public void Insert(int index, RichiestaConsulente RichiestaConsulenteObj)
		{
			if (RichiestaConsulenteObj.Provider == null) RichiestaConsulenteObj.Provider = this.Provider;
			base.Insert(index, RichiestaConsulenteObj);
		}

		//CollectionGetById
		public RichiestaConsulente CollectionGetById(NullTypes.IntNT IdRichiestaConsulenteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRichiestaConsulente == IdRichiestaConsulenteValue))
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
		public RichiestaConsulenteCollection SubSelect(NullTypes.IntNT IdRichiestaConsulenteEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.IntNT IdConsulenteEqualThis, NullTypes.DatetimeNT DataInizioAbilitazioneEqualThis, NullTypes.DatetimeNT DataFineAbilitazioneEqualThis, 
NullTypes.StringNT SegnaturaEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.BoolNT InviataEqualThis, 
NullTypes.BoolNT IstruitaEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.BoolNT RifiutataEqualThis, 
NullTypes.StringNT MotivazioneRifiutoEqualThis, NullTypes.StringNT SegnaturaIstruttoriaEqualThis, NullTypes.BoolNT ProcuraSpecialeEqualThis)
		{
			RichiestaConsulenteCollection RichiestaConsulenteCollectionTemp = new RichiestaConsulenteCollection();
			foreach (RichiestaConsulente RichiestaConsulenteItem in this)
			{
				if (((IdRichiestaConsulenteEqualThis == null) || ((RichiestaConsulenteItem.IdRichiestaConsulente != null) && (RichiestaConsulenteItem.IdRichiestaConsulente.Value == IdRichiestaConsulenteEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((RichiestaConsulenteItem.IdUtente != null) && (RichiestaConsulenteItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RichiestaConsulenteItem.IdImpresa != null) && (RichiestaConsulenteItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdConsulenteEqualThis == null) || ((RichiestaConsulenteItem.IdConsulente != null) && (RichiestaConsulenteItem.IdConsulente.Value == IdConsulenteEqualThis.Value))) && ((DataInizioAbilitazioneEqualThis == null) || ((RichiestaConsulenteItem.DataInizioAbilitazione != null) && (RichiestaConsulenteItem.DataInizioAbilitazione.Value == DataInizioAbilitazioneEqualThis.Value))) && ((DataFineAbilitazioneEqualThis == null) || ((RichiestaConsulenteItem.DataFineAbilitazione != null) && (RichiestaConsulenteItem.DataFineAbilitazione.Value == DataFineAbilitazioneEqualThis.Value))) && 
((SegnaturaEqualThis == null) || ((RichiestaConsulenteItem.Segnatura != null) && (RichiestaConsulenteItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((DataEqualThis == null) || ((RichiestaConsulenteItem.Data != null) && (RichiestaConsulenteItem.Data.Value == DataEqualThis.Value))) && ((InviataEqualThis == null) || ((RichiestaConsulenteItem.Inviata != null) && (RichiestaConsulenteItem.Inviata.Value == InviataEqualThis.Value))) && 
((IstruitaEqualThis == null) || ((RichiestaConsulenteItem.Istruita != null) && (RichiestaConsulenteItem.Istruita.Value == IstruitaEqualThis.Value))) && ((ApprovataEqualThis == null) || ((RichiestaConsulenteItem.Approvata != null) && (RichiestaConsulenteItem.Approvata.Value == ApprovataEqualThis.Value))) && ((RifiutataEqualThis == null) || ((RichiestaConsulenteItem.Rifiutata != null) && (RichiestaConsulenteItem.Rifiutata.Value == RifiutataEqualThis.Value))) && 
((MotivazioneRifiutoEqualThis == null) || ((RichiestaConsulenteItem.MotivazioneRifiuto != null) && (RichiestaConsulenteItem.MotivazioneRifiuto.Value == MotivazioneRifiutoEqualThis.Value))) && ((SegnaturaIstruttoriaEqualThis == null) || ((RichiestaConsulenteItem.SegnaturaIstruttoria != null) && (RichiestaConsulenteItem.SegnaturaIstruttoria.Value == SegnaturaIstruttoriaEqualThis.Value))) && ((ProcuraSpecialeEqualThis == null) || ((RichiestaConsulenteItem.ProcuraSpeciale != null) && (RichiestaConsulenteItem.ProcuraSpeciale.Value == ProcuraSpecialeEqualThis.Value))))
				{
					RichiestaConsulenteCollectionTemp.Add(RichiestaConsulenteItem);
				}
			}
			return RichiestaConsulenteCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RichiestaConsulenteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RichiestaConsulente RichiestaConsulenteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulente", RichiestaConsulenteObj.IdRichiestaConsulente);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", RichiestaConsulenteObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RichiestaConsulenteObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdConsulente", RichiestaConsulenteObj.IdConsulente);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioAbilitazione", RichiestaConsulenteObj.DataInizioAbilitazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineAbilitazione", RichiestaConsulenteObj.DataFineAbilitazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", RichiestaConsulenteObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", RichiestaConsulenteObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Approvata", RichiestaConsulenteObj.Approvata);
			DbProvider.SetCmdParam(cmd,firstChar + "Rifiutata", RichiestaConsulenteObj.Rifiutata);
			DbProvider.SetCmdParam(cmd,firstChar + "MotivazioneRifiuto", RichiestaConsulenteObj.MotivazioneRifiuto);
			DbProvider.SetCmdParam(cmd,firstChar + "Inviata", RichiestaConsulenteObj.Inviata);
			DbProvider.SetCmdParam(cmd,firstChar + "Istruita", RichiestaConsulenteObj.Istruita);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaIstruttoria", RichiestaConsulenteObj.SegnaturaIstruttoria);
			DbProvider.SetCmdParam(cmd,firstChar + "ProcuraSpeciale", RichiestaConsulenteObj.ProcuraSpeciale);
		}
		//Insert
		private static int Insert(DbProvider db, RichiestaConsulente RichiestaConsulenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteInsert", new string[] {"IdUtente", 
"IdImpresa", 
"IdConsulente", 
"DataInizioAbilitazione", 
"DataFineAbilitazione", "Segnatura", "Data", 
"Approvata", "Rifiutata", "MotivazioneRifiuto", 
"Inviata", "Istruita", "SegnaturaIstruttoria", 
"ProcuraSpeciale"}, new string[] {"int", 
"int", 
"int", 
"DateTime", 
"DateTime", "string", "DateTime", 
"bool", "bool", "string", 
"bool", "bool", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,RichiestaConsulenteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RichiestaConsulenteObj.IdRichiestaConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE"]);
				}
				RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteObj.IsDirty = false;
				RichiestaConsulenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RichiestaConsulente RichiestaConsulenteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteUpdate", new string[] {"IdRichiestaConsulente", "IdUtente", 
"IdImpresa", 
"IdConsulente", 
"DataInizioAbilitazione", 
"DataFineAbilitazione", "Segnatura", "Data", 
"Approvata", "Rifiutata", "MotivazioneRifiuto", 
"Inviata", "Istruita", "SegnaturaIstruttoria", 
"ProcuraSpeciale"}, new string[] {"int", "int", 
"int", 
"int", 
"DateTime", 
"DateTime", "string", "DateTime", 
"bool", "bool", "string", 
"bool", "bool", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,RichiestaConsulenteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteObj.IsDirty = false;
				RichiestaConsulenteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RichiestaConsulente RichiestaConsulenteObj)
		{
			switch (RichiestaConsulenteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RichiestaConsulenteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RichiestaConsulenteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RichiestaConsulenteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RichiestaConsulenteCollection RichiestaConsulenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteUpdate", new string[] {"IdRichiestaConsulente", "IdUtente", 
"IdImpresa", 
"IdConsulente", 
"DataInizioAbilitazione", 
"DataFineAbilitazione", "Segnatura", "Data", 
"Approvata", "Rifiutata", "MotivazioneRifiuto", 
"Inviata", "Istruita", "SegnaturaIstruttoria", 
"ProcuraSpeciale"}, new string[] {"int", "int", 
"int", 
"int", 
"DateTime", 
"DateTime", "string", "DateTime", 
"bool", "bool", "string", 
"bool", "bool", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteInsert", new string[] {"IdUtente", 
"IdImpresa", 
"IdConsulente", 
"DataInizioAbilitazione", 
"DataFineAbilitazione", "Segnatura", "Data", 
"Approvata", "Rifiutata", "MotivazioneRifiuto", 
"Inviata", "Istruita", "SegnaturaIstruttoria", 
"ProcuraSpeciale"}, new string[] {"int", 
"int", 
"int", 
"DateTime", 
"DateTime", "string", "DateTime", 
"bool", "bool", "string", 
"bool", "bool", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteDelete", new string[] {"IdRichiestaConsulente"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteCollectionObj.Count; i++)
				{
					switch (RichiestaConsulenteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RichiestaConsulenteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RichiestaConsulenteCollectionObj[i].IdRichiestaConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RichiestaConsulenteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RichiestaConsulenteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulente", (SiarLibrary.NullTypes.IntNT)RichiestaConsulenteCollectionObj[i].IdRichiestaConsulente);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RichiestaConsulenteCollectionObj[i].IsDirty = false;
						RichiestaConsulenteCollectionObj[i].IsPersistent = true;
					}
					if ((RichiestaConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RichiestaConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteCollectionObj[i].IsDirty = false;
						RichiestaConsulenteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RichiestaConsulente RichiestaConsulenteObj)
		{
			int returnValue = 0;
			if (RichiestaConsulenteObj.IsPersistent) 
			{
				returnValue = Delete(db, RichiestaConsulenteObj.IdRichiestaConsulente);
			}
			RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RichiestaConsulenteObj.IsDirty = false;
			RichiestaConsulenteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRichiestaConsulenteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteDelete", new string[] {"IdRichiestaConsulente"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulente", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RichiestaConsulenteCollection RichiestaConsulenteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteDelete", new string[] {"IdRichiestaConsulente"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulente", RichiestaConsulenteCollectionObj[i].IdRichiestaConsulente);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteCollectionObj[i].IsDirty = false;
						RichiestaConsulenteCollectionObj[i].IsPersistent = false;
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
		public static RichiestaConsulente GetById(DbProvider db, int IdRichiestaConsulenteValue)
		{
			RichiestaConsulente RichiestaConsulenteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRichiestaConsulenteGetById", new string[] {"IdRichiestaConsulente"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRichiestaConsulente", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RichiestaConsulenteObj = GetFromDatareader(db);
				RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteObj.IsDirty = false;
				RichiestaConsulenteObj.IsPersistent = true;
			}
			db.Close();
			return RichiestaConsulenteObj;
		}

		//getFromDatareader
		public static RichiestaConsulente GetFromDatareader(DbProvider db)
		{
			RichiestaConsulente RichiestaConsulenteObj = new RichiestaConsulente();
			RichiestaConsulenteObj.IdRichiestaConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE"]);
			RichiestaConsulenteObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			RichiestaConsulenteObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			RichiestaConsulenteObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			RichiestaConsulenteObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RichiestaConsulenteObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			RichiestaConsulenteObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			RichiestaConsulenteObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			RichiestaConsulenteObj.IdConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONSULENTE"]);
			RichiestaConsulenteObj.CfUtenteConsulente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE_CONSULENTE"]);
			RichiestaConsulenteObj.NominativoConsulente = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_CONSULENTE"]);
			RichiestaConsulenteObj.DataInizioAbilitazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_ABILITAZIONE"]);
			RichiestaConsulenteObj.DataFineAbilitazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_ABILITAZIONE"]);
			RichiestaConsulenteObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			RichiestaConsulenteObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			RichiestaConsulenteObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
			RichiestaConsulenteObj.Rifiutata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIFIUTATA"]);
			RichiestaConsulenteObj.MotivazioneRifiuto = new SiarLibrary.NullTypes.StringNT(db.DataReader["MOTIVAZIONE_RIFIUTO"]);
			RichiestaConsulenteObj.Inviata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INVIATA"]);
			RichiestaConsulenteObj.Istruita = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ISTRUITA"]);
			RichiestaConsulenteObj.SegnaturaIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ISTRUTTORIA"]);
			RichiestaConsulenteObj.ProcuraSpeciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROCURA_SPECIALE"]);
			RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RichiestaConsulenteObj.IsDirty = false;
			RichiestaConsulenteObj.IsPersistent = true;
			return RichiestaConsulenteObj;
		}

		//Find Select

		public static RichiestaConsulenteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdConsulenteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioAbilitazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineAbilitazioneEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.BoolNT InviataEqualThis, 
SiarLibrary.NullTypes.BoolNT IstruitaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.BoolNT RifiutataEqualThis, 
SiarLibrary.NullTypes.StringNT MotivazioneRifiutoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaIstruttoriaEqualThis, SiarLibrary.NullTypes.BoolNT ProcuraSpecialeEqualThis)

		{

			RichiestaConsulenteCollection RichiestaConsulenteCollectionObj = new RichiestaConsulenteCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulentefindselect", new string[] {"IdRichiestaConsulenteequalthis", "IdUtenteequalthis", "IdImpresaequalthis", 
"IdConsulenteequalthis", "DataInizioAbilitazioneequalthis", "DataFineAbilitazioneequalthis", 
"Segnaturaequalthis", "Dataequalthis", "Inviataequalthis", 
"Istruitaequalthis", "Approvataequalthis", "Rifiutataequalthis", 
"MotivazioneRifiutoequalthis", "SegnaturaIstruttoriaequalthis", "ProcuraSpecialeequalthis"}, new string[] {"int", "int", "int", 
"int", "DateTime", "DateTime", 
"string", "DateTime", "bool", 
"bool", "bool", "bool", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteequalthis", IdRichiestaConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdConsulenteequalthis", IdConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioAbilitazioneequalthis", DataInizioAbilitazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineAbilitazioneequalthis", DataFineAbilitazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Inviataequalthis", InviataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruitaequalthis", IstruitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rifiutataequalthis", RifiutataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MotivazioneRifiutoequalthis", MotivazioneRifiutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaIstruttoriaequalthis", SegnaturaIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProcuraSpecialeequalthis", ProcuraSpecialeEqualThis);
			RichiestaConsulente RichiestaConsulenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteObj = GetFromDatareader(db);
				RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteObj.IsDirty = false;
				RichiestaConsulenteObj.IsPersistent = true;
				RichiestaConsulenteCollectionObj.Add(RichiestaConsulenteObj);
			}
			db.Close();
			return RichiestaConsulenteCollectionObj;
		}

		//Find Find

		public static RichiestaConsulenteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdConsulenteEqualThis, 
SiarLibrary.NullTypes.BoolNT InviataEqualThis, SiarLibrary.NullTypes.BoolNT IstruitaEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, 
SiarLibrary.NullTypes.BoolNT RifiutataEqualThis, SiarLibrary.NullTypes.BoolNT ProcuraSpecialeEqualThis)

		{

			RichiestaConsulenteCollection RichiestaConsulenteCollectionObj = new RichiestaConsulenteCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulentefindfind", new string[] {"IdUtenteequalthis", "IdImpresaequalthis", "IdConsulenteequalthis", 
"Inviataequalthis", "Istruitaequalthis", "Approvataequalthis", 
"Rifiutataequalthis", "ProcuraSpecialeequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool", "bool", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdConsulenteequalthis", IdConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Inviataequalthis", InviataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruitaequalthis", IstruitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rifiutataequalthis", RifiutataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProcuraSpecialeequalthis", ProcuraSpecialeEqualThis);
			RichiestaConsulente RichiestaConsulenteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteObj = GetFromDatareader(db);
				RichiestaConsulenteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteObj.IsDirty = false;
				RichiestaConsulenteObj.IsPersistent = true;
				RichiestaConsulenteCollectionObj.Add(RichiestaConsulenteObj);
			}
			db.Close();
			return RichiestaConsulenteCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteCollectionProvider:IRichiestaConsulenteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteCollectionProvider : IRichiestaConsulenteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RichiestaConsulente
		protected RichiestaConsulenteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RichiestaConsulenteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RichiestaConsulenteCollection(this);
		}

		//Costruttore 2: popola la collection
		public RichiestaConsulenteCollectionProvider(IntNT IdutenteEqualThis, IntNT IdimpresaEqualThis, IntNT IdconsulenteEqualThis, 
BoolNT InviataEqualThis, BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, 
BoolNT RifiutataEqualThis, BoolNT ProcuraspecialeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdutenteEqualThis, IdimpresaEqualThis, IdconsulenteEqualThis, 
InviataEqualThis, IstruitaEqualThis, ApprovataEqualThis, 
RifiutataEqualThis, ProcuraspecialeEqualThis);
		}

		//Costruttore3: ha in input richiestaconsulenteCollectionObj - non popola la collection
		public RichiestaConsulenteCollectionProvider(RichiestaConsulenteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RichiestaConsulenteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RichiestaConsulenteCollection(this);
		}

		//Get e Set
		public RichiestaConsulenteCollection CollectionObj
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
		public int SaveCollection(RichiestaConsulenteCollection collectionObj)
		{
			return RichiestaConsulenteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RichiestaConsulente richiestaconsulenteObj)
		{
			return RichiestaConsulenteDAL.Save(_dbProviderObj, richiestaconsulenteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RichiestaConsulenteCollection collectionObj)
		{
			return RichiestaConsulenteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RichiestaConsulente richiestaconsulenteObj)
		{
			return RichiestaConsulenteDAL.Delete(_dbProviderObj, richiestaconsulenteObj);
		}

		//getById
		public RichiestaConsulente GetById(IntNT IdRichiestaConsulenteValue)
		{
			RichiestaConsulente RichiestaConsulenteTemp = RichiestaConsulenteDAL.GetById(_dbProviderObj, IdRichiestaConsulenteValue);
			if (RichiestaConsulenteTemp!=null) RichiestaConsulenteTemp.Provider = this;
			return RichiestaConsulenteTemp;
		}

		//Select: popola la collection
		public RichiestaConsulenteCollection Select(IntNT IdrichiestaconsulenteEqualThis, IntNT IdutenteEqualThis, IntNT IdimpresaEqualThis, 
IntNT IdconsulenteEqualThis, DatetimeNT DatainizioabilitazioneEqualThis, DatetimeNT DatafineabilitazioneEqualThis, 
StringNT SegnaturaEqualThis, DatetimeNT DataEqualThis, BoolNT InviataEqualThis, 
BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, BoolNT RifiutataEqualThis, 
StringNT MotivazionerifiutoEqualThis, StringNT SegnaturaistruttoriaEqualThis, BoolNT ProcuraspecialeEqualThis)
		{
			RichiestaConsulenteCollection RichiestaConsulenteCollectionTemp = RichiestaConsulenteDAL.Select(_dbProviderObj, IdrichiestaconsulenteEqualThis, IdutenteEqualThis, IdimpresaEqualThis, 
IdconsulenteEqualThis, DatainizioabilitazioneEqualThis, DatafineabilitazioneEqualThis, 
SegnaturaEqualThis, DataEqualThis, InviataEqualThis, 
IstruitaEqualThis, ApprovataEqualThis, RifiutataEqualThis, 
MotivazionerifiutoEqualThis, SegnaturaistruttoriaEqualThis, ProcuraspecialeEqualThis);
			RichiestaConsulenteCollectionTemp.Provider = this;
			return RichiestaConsulenteCollectionTemp;
		}

		//Find: popola la collection
		public RichiestaConsulenteCollection Find(IntNT IdutenteEqualThis, IntNT IdimpresaEqualThis, IntNT IdconsulenteEqualThis, 
BoolNT InviataEqualThis, BoolNT IstruitaEqualThis, BoolNT ApprovataEqualThis, 
BoolNT RifiutataEqualThis, BoolNT ProcuraspecialeEqualThis)
		{
			RichiestaConsulenteCollection RichiestaConsulenteCollectionTemp = RichiestaConsulenteDAL.Find(_dbProviderObj, IdutenteEqualThis, IdimpresaEqualThis, IdconsulenteEqualThis, 
InviataEqualThis, IstruitaEqualThis, ApprovataEqualThis, 
RifiutataEqualThis, ProcuraspecialeEqualThis);
			RichiestaConsulenteCollectionTemp.Provider = this;
			return RichiestaConsulenteCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICHIESTA_CONSULENTE>
  <ViewName>vRICHIESTA_CONSULENTE</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_UTENTE>Equal</ID_UTENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_CONSULENTE>Equal</ID_CONSULENTE>
      <INVIATA>Equal</INVIATA>
      <ISTRUITA>Equal</ISTRUITA>
      <APPROVATA>Equal</APPROVATA>
      <RIFIUTATA>Equal</RIFIUTATA>
      <PROCURA_SPECIALE>Equal</PROCURA_SPECIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICHIESTA_CONSULENTE>
*/
