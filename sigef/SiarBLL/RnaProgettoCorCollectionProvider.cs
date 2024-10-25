using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaProgettoCor
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaProgettoCorProvider
	{
		int Save(RnaProgettoCor RnaProgettoCorObj);
		int SaveCollection(RnaProgettoCorCollection collectionObj);
		int Delete(RnaProgettoCor RnaProgettoCorObj);
		int DeleteCollection(RnaProgettoCorCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaProgettoCor
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaProgettoCor: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaProgettoCor;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _IdProgettoRna;
		private NullTypes.StringNT _IdRichiesta;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _IdFiscaleImpresa;
		private NullTypes.IntNT _IdOperatoreAssegnazioneCor;
		private NullTypes.StringNT _Cor;
		private NullTypes.StringNT _StatoConcessione;
		private NullTypes.DatetimeNT _DataAssegnazioneCor;
		private NullTypes.BoolNT _Confermato;
		private NullTypes.IntNT _IdOperatoreConfermaConcessione;
		private NullTypes.DatetimeNT _DataConfermaConcessione;
		private NullTypes.BoolNT _Annullato;
		private NullTypes.IntNT _IdOperatoreAnnullamento;
		private NullTypes.DatetimeNT _DataAnnullamento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		[NonSerialized] private IRnaProgettoCorProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaProgettoCorProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaProgettoCor()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_PROGETTO_COR
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaProgettoCor
		{
			get { return _IdRnaProgettoCor; }
			set {
				if (IdRnaProgettoCor != value)
				{
					_IdRnaProgettoCor = value;
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
		/// Corrisponde al campo:ID_PROGETTO_RNA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT IdProgettoRna
		{
			get { return _IdProgettoRna; }
			set {
				if (IdProgettoRna != value)
				{
					_IdProgettoRna = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT IdRichiesta
		{
			get { return _IdRichiesta; }
			set {
				if (IdRichiesta != value)
				{
					_IdRichiesta = value;
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
		/// Corrisponde al campo:ID_FISCALE_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT IdFiscaleImpresa
		{
			get { return _IdFiscaleImpresa; }
			set {
				if (IdFiscaleImpresa != value)
				{
					_IdFiscaleImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_ASSEGNAZIONE_COR
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreAssegnazioneCor
		{
			get { return _IdOperatoreAssegnazioneCor; }
			set {
				if (IdOperatoreAssegnazioneCor != value)
				{
					_IdOperatoreAssegnazioneCor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COR
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Cor
		{
			get { return _Cor; }
			set {
				if (Cor != value)
				{
					_Cor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_CONCESSIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT StatoConcessione
		{
			get { return _StatoConcessione; }
			set {
				if (StatoConcessione != value)
				{
					_StatoConcessione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ASSEGNAZIONE_COR
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAssegnazioneCor
		{
			get { return _DataAssegnazioneCor; }
			set {
				if (DataAssegnazioneCor != value)
				{
					_DataAssegnazioneCor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONFERMATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Confermato
		{
			get { return _Confermato; }
			set {
				if (Confermato != value)
				{
					_Confermato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_CONFERMA_CONCESSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreConfermaConcessione
		{
			get { return _IdOperatoreConfermaConcessione; }
			set {
				if (IdOperatoreConfermaConcessione != value)
				{
					_IdOperatoreConfermaConcessione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CONFERMA_CONCESSIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataConfermaConcessione
		{
			get { return _DataConfermaConcessione; }
			set {
				if (DataConfermaConcessione != value)
				{
					_DataConfermaConcessione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNULLATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Annullato
		{
			get { return _Annullato; }
			set {
				if (Annullato != value)
				{
					_Annullato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_ANNULLAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreAnnullamento
		{
			get { return _IdOperatoreAnnullamento; }
			set {
				if (IdOperatoreAnnullamento != value)
				{
					_IdOperatoreAnnullamento = value;
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
		/// Corrisponde al campo:DATA_AGGIORNAMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataAggiornamento
		{
			get { return _DataAggiornamento; }
			set {
				if (DataAggiornamento != value)
				{
					_DataAggiornamento = value;
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
	/// Summary description for RnaProgettoCorCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaProgettoCorCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaProgettoCorCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaProgettoCor) info.GetValue(i.ToString(),typeof(RnaProgettoCor)));
			}
		}

		//Costruttore
		public RnaProgettoCorCollection()
		{
			this.ItemType = typeof(RnaProgettoCor);
		}

		//Costruttore con provider
		public RnaProgettoCorCollection(IRnaProgettoCorProvider providerObj)
		{
			this.ItemType = typeof(RnaProgettoCor);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaProgettoCor this[int index]
		{
			get { return (RnaProgettoCor)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaProgettoCorCollection GetChanges()
		{
			return (RnaProgettoCorCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaProgettoCorProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaProgettoCorProvider Provider
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
		public int Add(RnaProgettoCor RnaProgettoCorObj)
		{
			if (RnaProgettoCorObj.Provider == null) RnaProgettoCorObj.Provider = this.Provider;
			return base.Add(RnaProgettoCorObj);
		}

		//AddCollection
		public void AddCollection(RnaProgettoCorCollection RnaProgettoCorCollectionObj)
		{
			foreach (RnaProgettoCor RnaProgettoCorObj in RnaProgettoCorCollectionObj)
				this.Add(RnaProgettoCorObj);
		}

		//Insert
		public void Insert(int index, RnaProgettoCor RnaProgettoCorObj)
		{
			if (RnaProgettoCorObj.Provider == null) RnaProgettoCorObj.Provider = this.Provider;
			base.Insert(index, RnaProgettoCorObj);
		}

		//CollectionGetById
		public RnaProgettoCor CollectionGetById(NullTypes.IntNT IdRnaProgettoCorValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRnaProgettoCor == IdRnaProgettoCorValue))
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
		public RnaProgettoCorCollection SubSelect(NullTypes.IntNT IdRnaProgettoCorEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT IdProgettoRnaEqualThis, 
NullTypes.StringNT IdRichiestaEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT IdFiscaleImpresaEqualThis, 
NullTypes.IntNT IdOperatoreAssegnazioneCorEqualThis, NullTypes.StringNT CorEqualThis, NullTypes.StringNT StatoConcessioneEqualThis, 
NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, NullTypes.BoolNT ConfermatoEqualThis, NullTypes.IntNT IdOperatoreConfermaConcessioneEqualThis, 
NullTypes.DatetimeNT DataConfermaConcessioneEqualThis, NullTypes.BoolNT AnnullatoEqualThis, NullTypes.IntNT IdOperatoreAnnullamentoEqualThis, 
NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis)
		{
			RnaProgettoCorCollection RnaProgettoCorCollectionTemp = new RnaProgettoCorCollection();
			foreach (RnaProgettoCor RnaProgettoCorItem in this)
			{
				if (((IdRnaProgettoCorEqualThis == null) || ((RnaProgettoCorItem.IdRnaProgettoCor != null) && (RnaProgettoCorItem.IdRnaProgettoCor.Value == IdRnaProgettoCorEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RnaProgettoCorItem.IdProgetto != null) && (RnaProgettoCorItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdProgettoRnaEqualThis == null) || ((RnaProgettoCorItem.IdProgettoRna != null) && (RnaProgettoCorItem.IdProgettoRna.Value == IdProgettoRnaEqualThis.Value))) && 
((IdRichiestaEqualThis == null) || ((RnaProgettoCorItem.IdRichiesta != null) && (RnaProgettoCorItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RnaProgettoCorItem.IdImpresa != null) && (RnaProgettoCorItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdFiscaleImpresaEqualThis == null) || ((RnaProgettoCorItem.IdFiscaleImpresa != null) && (RnaProgettoCorItem.IdFiscaleImpresa.Value == IdFiscaleImpresaEqualThis.Value))) && 
((IdOperatoreAssegnazioneCorEqualThis == null) || ((RnaProgettoCorItem.IdOperatoreAssegnazioneCor != null) && (RnaProgettoCorItem.IdOperatoreAssegnazioneCor.Value == IdOperatoreAssegnazioneCorEqualThis.Value))) && ((CorEqualThis == null) || ((RnaProgettoCorItem.Cor != null) && (RnaProgettoCorItem.Cor.Value == CorEqualThis.Value))) && ((StatoConcessioneEqualThis == null) || ((RnaProgettoCorItem.StatoConcessione != null) && (RnaProgettoCorItem.StatoConcessione.Value == StatoConcessioneEqualThis.Value))) && 
((DataAssegnazioneCorEqualThis == null) || ((RnaProgettoCorItem.DataAssegnazioneCor != null) && (RnaProgettoCorItem.DataAssegnazioneCor.Value == DataAssegnazioneCorEqualThis.Value))) && ((ConfermatoEqualThis == null) || ((RnaProgettoCorItem.Confermato != null) && (RnaProgettoCorItem.Confermato.Value == ConfermatoEqualThis.Value))) && ((IdOperatoreConfermaConcessioneEqualThis == null) || ((RnaProgettoCorItem.IdOperatoreConfermaConcessione != null) && (RnaProgettoCorItem.IdOperatoreConfermaConcessione.Value == IdOperatoreConfermaConcessioneEqualThis.Value))) && 
((DataConfermaConcessioneEqualThis == null) || ((RnaProgettoCorItem.DataConfermaConcessione != null) && (RnaProgettoCorItem.DataConfermaConcessione.Value == DataConfermaConcessioneEqualThis.Value))) && ((AnnullatoEqualThis == null) || ((RnaProgettoCorItem.Annullato != null) && (RnaProgettoCorItem.Annullato.Value == AnnullatoEqualThis.Value))) && ((IdOperatoreAnnullamentoEqualThis == null) || ((RnaProgettoCorItem.IdOperatoreAnnullamento != null) && (RnaProgettoCorItem.IdOperatoreAnnullamento.Value == IdOperatoreAnnullamentoEqualThis.Value))) && 
((DataAnnullamentoEqualThis == null) || ((RnaProgettoCorItem.DataAnnullamento != null) && (RnaProgettoCorItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RnaProgettoCorItem.DataInserimento != null) && (RnaProgettoCorItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((RnaProgettoCorItem.DataAggiornamento != null) && (RnaProgettoCorItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))))
				{
					RnaProgettoCorCollectionTemp.Add(RnaProgettoCorItem);
				}
			}
			return RnaProgettoCorCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaProgettoCorDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaProgettoCorDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaProgettoCor RnaProgettoCorObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRnaProgettoCor", RnaProgettoCorObj.IdRnaProgettoCor);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", RnaProgettoCorObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoRna", RnaProgettoCorObj.IdProgettoRna);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiesta", RnaProgettoCorObj.IdRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RnaProgettoCorObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiscaleImpresa", RnaProgettoCorObj.IdFiscaleImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreAssegnazioneCor", RnaProgettoCorObj.IdOperatoreAssegnazioneCor);
			DbProvider.SetCmdParam(cmd,firstChar + "Cor", RnaProgettoCorObj.Cor);
			DbProvider.SetCmdParam(cmd,firstChar + "StatoConcessione", RnaProgettoCorObj.StatoConcessione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAssegnazioneCor", RnaProgettoCorObj.DataAssegnazioneCor);
			DbProvider.SetCmdParam(cmd,firstChar + "Confermato", RnaProgettoCorObj.Confermato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreConfermaConcessione", RnaProgettoCorObj.IdOperatoreConfermaConcessione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataConfermaConcessione", RnaProgettoCorObj.DataConfermaConcessione);
			DbProvider.SetCmdParam(cmd,firstChar + "Annullato", RnaProgettoCorObj.Annullato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreAnnullamento", RnaProgettoCorObj.IdOperatoreAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAnnullamento", RnaProgettoCorObj.DataAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RnaProgettoCorObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", RnaProgettoCorObj.DataAggiornamento);
		}
		//Insert
		private static int Insert(DbProvider db, RnaProgettoCor RnaProgettoCorObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaProgettoCorInsert", new string[] {"IdProgetto", "IdProgettoRna", 
"IdRichiesta", "IdImpresa", "IdFiscaleImpresa", 
"IdOperatoreAssegnazioneCor", "Cor", "StatoConcessione", 
"DataAssegnazioneCor", "Confermato", "IdOperatoreConfermaConcessione", 
"DataConfermaConcessione", "Annullato", "IdOperatoreAnnullamento", 
"DataAnnullamento", "DataInserimento", "DataAggiornamento"}, new string[] {"int", "string", 
"string", "int", "string", 
"int", "string", "string", 
"DateTime", "bool", "int", 
"DateTime", "bool", "int", 
"DateTime", "DateTime", "DateTime"},"");
				CompileIUCmd(false, insertCmd,RnaProgettoCorObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaProgettoCorObj.IdRnaProgettoCor = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_PROGETTO_COR"]);
				RnaProgettoCorObj.Confermato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFERMATO"]);
				RnaProgettoCorObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
				RnaProgettoCorObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				RnaProgettoCorObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
				}
				RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProgettoCorObj.IsDirty = false;
				RnaProgettoCorObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaProgettoCor RnaProgettoCorObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaProgettoCorUpdate", new string[] {"IdRnaProgettoCor", "IdProgetto", "IdProgettoRna", 
"IdRichiesta", "IdImpresa", "IdFiscaleImpresa", 
"IdOperatoreAssegnazioneCor", "Cor", "StatoConcessione", 
"DataAssegnazioneCor", "Confermato", "IdOperatoreConfermaConcessione", 
"DataConfermaConcessione", "Annullato", "IdOperatoreAnnullamento", 
"DataAnnullamento", "DataInserimento", "DataAggiornamento"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int", "string", "string", 
"DateTime", "bool", "int", 
"DateTime", "bool", "int", 
"DateTime", "DateTime", "DateTime"},"");
				CompileIUCmd(true, updateCmd,RnaProgettoCorObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProgettoCorObj.IsDirty = false;
				RnaProgettoCorObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaProgettoCor RnaProgettoCorObj)
		{
			switch (RnaProgettoCorObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaProgettoCorObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaProgettoCorObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaProgettoCorObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaProgettoCorCollection RnaProgettoCorCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaProgettoCorUpdate", new string[] {"IdRnaProgettoCor", "IdProgetto", "IdProgettoRna", 
"IdRichiesta", "IdImpresa", "IdFiscaleImpresa", 
"IdOperatoreAssegnazioneCor", "Cor", "StatoConcessione", 
"DataAssegnazioneCor", "Confermato", "IdOperatoreConfermaConcessione", 
"DataConfermaConcessione", "Annullato", "IdOperatoreAnnullamento", 
"DataAnnullamento", "DataInserimento", "DataAggiornamento"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int", "string", "string", 
"DateTime", "bool", "int", 
"DateTime", "bool", "int", 
"DateTime", "DateTime", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaProgettoCorInsert", new string[] {"IdProgetto", "IdProgettoRna", 
"IdRichiesta", "IdImpresa", "IdFiscaleImpresa", 
"IdOperatoreAssegnazioneCor", "Cor", "StatoConcessione", 
"DataAssegnazioneCor", "Confermato", "IdOperatoreConfermaConcessione", 
"DataConfermaConcessione", "Annullato", "IdOperatoreAnnullamento", 
"DataAnnullamento", "DataInserimento", "DataAggiornamento"}, new string[] {"int", "string", 
"string", "int", "string", 
"int", "string", "string", 
"DateTime", "bool", "int", 
"DateTime", "bool", "int", 
"DateTime", "DateTime", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProgettoCorDelete", new string[] {"IdRnaProgettoCor"}, new string[] {"int"},"");
				for (int i = 0; i < RnaProgettoCorCollectionObj.Count; i++)
				{
					switch (RnaProgettoCorCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaProgettoCorCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaProgettoCorCollectionObj[i].IdRnaProgettoCor = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_PROGETTO_COR"]);
									RnaProgettoCorCollectionObj[i].Confermato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFERMATO"]);
									RnaProgettoCorCollectionObj[i].Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
									RnaProgettoCorCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									RnaProgettoCorCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaProgettoCorCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaProgettoCorCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaProgettoCor", (SiarLibrary.NullTypes.IntNT)RnaProgettoCorCollectionObj[i].IdRnaProgettoCor);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaProgettoCorCollectionObj.Count; i++)
				{
					if ((RnaProgettoCorCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaProgettoCorCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaProgettoCorCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaProgettoCorCollectionObj[i].IsDirty = false;
						RnaProgettoCorCollectionObj[i].IsPersistent = true;
					}
					if ((RnaProgettoCorCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaProgettoCorCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaProgettoCorCollectionObj[i].IsDirty = false;
						RnaProgettoCorCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaProgettoCor RnaProgettoCorObj)
		{
			int returnValue = 0;
			if (RnaProgettoCorObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaProgettoCorObj.IdRnaProgettoCor);
			}
			RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaProgettoCorObj.IsDirty = false;
			RnaProgettoCorObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRnaProgettoCorValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProgettoCorDelete", new string[] {"IdRnaProgettoCor"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaProgettoCor", (SiarLibrary.NullTypes.IntNT)IdRnaProgettoCorValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaProgettoCorCollection RnaProgettoCorCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaProgettoCorDelete", new string[] {"IdRnaProgettoCor"}, new string[] {"int"},"");
				for (int i = 0; i < RnaProgettoCorCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaProgettoCor", RnaProgettoCorCollectionObj[i].IdRnaProgettoCor);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaProgettoCorCollectionObj.Count; i++)
				{
					if ((RnaProgettoCorCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaProgettoCorCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaProgettoCorCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaProgettoCorCollectionObj[i].IsDirty = false;
						RnaProgettoCorCollectionObj[i].IsPersistent = false;
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
		public static RnaProgettoCor GetById(DbProvider db, int IdRnaProgettoCorValue)
		{
			RnaProgettoCor RnaProgettoCorObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaProgettoCorGetById", new string[] {"IdRnaProgettoCor"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRnaProgettoCor", (SiarLibrary.NullTypes.IntNT)IdRnaProgettoCorValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaProgettoCorObj = GetFromDatareader(db);
				RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProgettoCorObj.IsDirty = false;
				RnaProgettoCorObj.IsPersistent = true;
			}
			db.Close();
			return RnaProgettoCorObj;
		}

		//getFromDatareader
		public static RnaProgettoCor GetFromDatareader(DbProvider db)
		{
			RnaProgettoCor RnaProgettoCorObj = new RnaProgettoCor();
			RnaProgettoCorObj.IdRnaProgettoCor = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_PROGETTO_COR"]);
			RnaProgettoCorObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RnaProgettoCorObj.IdProgettoRna = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_PROGETTO_RNA"]);
			RnaProgettoCorObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			RnaProgettoCorObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RnaProgettoCorObj.IdFiscaleImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FISCALE_IMPRESA"]);
			RnaProgettoCorObj.IdOperatoreAssegnazioneCor = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_ASSEGNAZIONE_COR"]);
			RnaProgettoCorObj.Cor = new SiarLibrary.NullTypes.StringNT(db.DataReader["COR"]);
			RnaProgettoCorObj.StatoConcessione = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_CONCESSIONE"]);
			RnaProgettoCorObj.DataAssegnazioneCor = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ASSEGNAZIONE_COR"]);
			RnaProgettoCorObj.Confermato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONFERMATO"]);
			RnaProgettoCorObj.IdOperatoreConfermaConcessione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_CONFERMA_CONCESSIONE"]);
			RnaProgettoCorObj.DataConfermaConcessione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CONFERMA_CONCESSIONE"]);
			RnaProgettoCorObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
			RnaProgettoCorObj.IdOperatoreAnnullamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_ANNULLAMENTO"]);
			RnaProgettoCorObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
			RnaProgettoCorObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RnaProgettoCorObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaProgettoCorObj.IsDirty = false;
			RnaProgettoCorObj.IsPersistent = true;
			return RnaProgettoCorObj;
		}

		//Find Select

		public static RnaProgettoCorCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaProgettoCorEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT IdProgettoRnaEqualThis, 
SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT IdFiscaleImpresaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreAssegnazioneCorEqualThis, SiarLibrary.NullTypes.StringNT CorEqualThis, SiarLibrary.NullTypes.StringNT StatoConcessioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, SiarLibrary.NullTypes.BoolNT ConfermatoEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreConfermaConcessioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataConfermaConcessioneEqualThis, SiarLibrary.NullTypes.BoolNT AnnullatoEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreAnnullamentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis)

		{

			RnaProgettoCorCollection RnaProgettoCorCollectionObj = new RnaProgettoCorCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaprogettocorfindselect", new string[] {"IdRnaProgettoCorequalthis", "IdProgettoequalthis", "IdProgettoRnaequalthis", 
"IdRichiestaequalthis", "IdImpresaequalthis", "IdFiscaleImpresaequalthis", 
"IdOperatoreAssegnazioneCorequalthis", "Corequalthis", "StatoConcessioneequalthis", 
"DataAssegnazioneCorequalthis", "Confermatoequalthis", "IdOperatoreConfermaConcessioneequalthis", 
"DataConfermaConcessioneequalthis", "Annullatoequalthis", "IdOperatoreAnnullamentoequalthis", 
"DataAnnullamentoequalthis", "DataInserimentoequalthis", "DataAggiornamentoequalthis"}, new string[] {"int", "int", "string", 
"string", "int", "string", 
"int", "string", "string", 
"DateTime", "bool", "int", 
"DateTime", "bool", "int", 
"DateTime", "DateTime", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaProgettoCorequalthis", IdRnaProgettoCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoRnaequalthis", IdProgettoRnaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiscaleImpresaequalthis", IdFiscaleImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreAssegnazioneCorequalthis", IdOperatoreAssegnazioneCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Corequalthis", CorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoConcessioneequalthis", StatoConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAssegnazioneCorequalthis", DataAssegnazioneCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Confermatoequalthis", ConfermatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreConfermaConcessioneequalthis", IdOperatoreConfermaConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataConfermaConcessioneequalthis", DataConfermaConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullatoequalthis", AnnullatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreAnnullamentoequalthis", IdOperatoreAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			RnaProgettoCor RnaProgettoCorObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaProgettoCorObj = GetFromDatareader(db);
				RnaProgettoCorObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaProgettoCorObj.IsDirty = false;
				RnaProgettoCorObj.IsPersistent = true;
				RnaProgettoCorCollectionObj.Add(RnaProgettoCorObj);
			}
			db.Close();
			return RnaProgettoCorCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaProgettoCorCollectionProvider:IRnaProgettoCorProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaProgettoCorCollectionProvider : IRnaProgettoCorProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaProgettoCor
		protected RnaProgettoCorCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaProgettoCorCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaProgettoCorCollection(this);
		}

		//Costruttore3: ha in input rnaprogettocorCollectionObj - non popola la collection
		public RnaProgettoCorCollectionProvider(RnaProgettoCorCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaProgettoCorCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaProgettoCorCollection(this);
		}

		//Get e Set
		public RnaProgettoCorCollection CollectionObj
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
		public int SaveCollection(RnaProgettoCorCollection collectionObj)
		{
			return RnaProgettoCorDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaProgettoCor rnaprogettocorObj)
		{
			return RnaProgettoCorDAL.Save(_dbProviderObj, rnaprogettocorObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaProgettoCorCollection collectionObj)
		{
			return RnaProgettoCorDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaProgettoCor rnaprogettocorObj)
		{
			return RnaProgettoCorDAL.Delete(_dbProviderObj, rnaprogettocorObj);
		}

		//getById
		public RnaProgettoCor GetById(IntNT IdRnaProgettoCorValue)
		{
			RnaProgettoCor RnaProgettoCorTemp = RnaProgettoCorDAL.GetById(_dbProviderObj, IdRnaProgettoCorValue);
			if (RnaProgettoCorTemp!=null) RnaProgettoCorTemp.Provider = this;
			return RnaProgettoCorTemp;
		}

		//Select: popola la collection
		public RnaProgettoCorCollection Select(IntNT IdrnaprogettocorEqualThis, IntNT IdprogettoEqualThis, StringNT IdprogettornaEqualThis, 
StringNT IdrichiestaEqualThis, IntNT IdimpresaEqualThis, StringNT IdfiscaleimpresaEqualThis, 
IntNT IdoperatoreassegnazionecorEqualThis, StringNT CorEqualThis, StringNT StatoconcessioneEqualThis, 
DatetimeNT DataassegnazionecorEqualThis, BoolNT ConfermatoEqualThis, IntNT IdoperatoreconfermaconcessioneEqualThis, 
DatetimeNT DataconfermaconcessioneEqualThis, BoolNT AnnullatoEqualThis, IntNT IdoperatoreannullamentoEqualThis, 
DatetimeNT DataannullamentoEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis)
		{
			RnaProgettoCorCollection RnaProgettoCorCollectionTemp = RnaProgettoCorDAL.Select(_dbProviderObj, IdrnaprogettocorEqualThis, IdprogettoEqualThis, IdprogettornaEqualThis, 
IdrichiestaEqualThis, IdimpresaEqualThis, IdfiscaleimpresaEqualThis, 
IdoperatoreassegnazionecorEqualThis, CorEqualThis, StatoconcessioneEqualThis, 
DataassegnazionecorEqualThis, ConfermatoEqualThis, IdoperatoreconfermaconcessioneEqualThis, 
DataconfermaconcessioneEqualThis, AnnullatoEqualThis, IdoperatoreannullamentoEqualThis, 
DataannullamentoEqualThis, DatainserimentoEqualThis, DataaggiornamentoEqualThis);
			RnaProgettoCorCollectionTemp.Provider = this;
			return RnaProgettoCorCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_PROGETTO_COR>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
</RNA_PROGETTO_COR>
*/
