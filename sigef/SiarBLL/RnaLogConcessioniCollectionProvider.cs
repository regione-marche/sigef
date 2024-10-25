using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaLogConcessioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaLogConcessioniProvider
	{
		int Save(RnaLogConcessioni RnaLogConcessioniObj);
		int SaveCollection(RnaLogConcessioniCollection collectionObj);
		int Delete(RnaLogConcessioni RnaLogConcessioniObj);
		int DeleteCollection(RnaLogConcessioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaLogConcessioni
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaLogConcessioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaLogConcessione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _IdProgettoRna;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _IdFiscaleImpresa;
		private NullTypes.StringNT _IdRichiesta;
		private NullTypes.DatetimeNT _DataRichiesta;
		private NullTypes.IntNT _IdOperatoreRegAiuto;
		private NullTypes.StringNT _IstanzaRichiesta;
		private NullTypes.StringNT _IstanzaRisposta;
		private NullTypes.StringNT _Cor;
		private NullTypes.IntNT _CodiceEsito;
		private NullTypes.StringNT _DescrizioneEsito;
		private NullTypes.IntNT _CodiceEsitoStatoRichiesta;
		private NullTypes.StringNT _DescrizioneEsitoStatoRichiesta;
		private NullTypes.IntNT _IdOperatoreStatoRichiesta;
		private NullTypes.DatetimeNT _DataStatoRichiesta;
		private NullTypes.StringNT _Errore;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		[NonSerialized] private IRnaLogConcessioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaLogConcessioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaLogConcessioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_LOG_CONCESSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaLogConcessione
		{
			get { return _IdRnaLogConcessione; }
			set {
				if (IdRnaLogConcessione != value)
				{
					_IdRnaLogConcessione = value;
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
		/// Corrisponde al campo:DATA_RICHIESTA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRichiesta
		{
			get { return _DataRichiesta; }
			set {
				if (DataRichiesta != value)
				{
					_DataRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_REG_AIUTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreRegAiuto
		{
			get { return _IdOperatoreRegAiuto; }
			set {
				if (IdOperatoreRegAiuto != value)
				{
					_IdOperatoreRegAiuto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_RICHIESTA
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaRichiesta
		{
			get { return _IstanzaRichiesta; }
			set {
				if (IstanzaRichiesta != value)
				{
					_IstanzaRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_RISPOSTA
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaRisposta
		{
			get { return _IstanzaRisposta; }
			set {
				if (IstanzaRisposta != value)
				{
					_IstanzaRisposta = value;
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
		/// Corrisponde al campo:CODICE_ESITO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceEsito
		{
			get { return _CodiceEsito; }
			set {
				if (CodiceEsito != value)
				{
					_CodiceEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ESITO
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneEsito
		{
			get { return _DescrizioneEsito; }
			set {
				if (DescrizioneEsito != value)
				{
					_DescrizioneEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_ESITO_STATO_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceEsitoStatoRichiesta
		{
			get { return _CodiceEsitoStatoRichiesta; }
			set {
				if (CodiceEsitoStatoRichiesta != value)
				{
					_CodiceEsitoStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ESITO_STATO_RICHIESTA
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneEsitoStatoRichiesta
		{
			get { return _DescrizioneEsitoStatoRichiesta; }
			set {
				if (DescrizioneEsitoStatoRichiesta != value)
				{
					_DescrizioneEsitoStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_STATO_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreStatoRichiesta
		{
			get { return _IdOperatoreStatoRichiesta; }
			set {
				if (IdOperatoreStatoRichiesta != value)
				{
					_IdOperatoreStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_STATO_RICHIESTA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataStatoRichiesta
		{
			get { return _DataStatoRichiesta; }
			set {
				if (DataStatoRichiesta != value)
				{
					_DataStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ERRORE
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Errore
		{
			get { return _Errore; }
			set {
				if (Errore != value)
				{
					_Errore = value;
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
	/// Summary description for RnaLogConcessioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaLogConcessioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaLogConcessioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaLogConcessioni) info.GetValue(i.ToString(),typeof(RnaLogConcessioni)));
			}
		}

		//Costruttore
		public RnaLogConcessioniCollection()
		{
			this.ItemType = typeof(RnaLogConcessioni);
		}

		//Costruttore con provider
		public RnaLogConcessioniCollection(IRnaLogConcessioniProvider providerObj)
		{
			this.ItemType = typeof(RnaLogConcessioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaLogConcessioni this[int index]
		{
			get { return (RnaLogConcessioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaLogConcessioniCollection GetChanges()
		{
			return (RnaLogConcessioniCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaLogConcessioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaLogConcessioniProvider Provider
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
		public int Add(RnaLogConcessioni RnaLogConcessioniObj)
		{
			if (RnaLogConcessioniObj.Provider == null) RnaLogConcessioniObj.Provider = this.Provider;
			return base.Add(RnaLogConcessioniObj);
		}

		//AddCollection
		public void AddCollection(RnaLogConcessioniCollection RnaLogConcessioniCollectionObj)
		{
			foreach (RnaLogConcessioni RnaLogConcessioniObj in RnaLogConcessioniCollectionObj)
				this.Add(RnaLogConcessioniObj);
		}

		//Insert
		public void Insert(int index, RnaLogConcessioni RnaLogConcessioniObj)
		{
			if (RnaLogConcessioniObj.Provider == null) RnaLogConcessioniObj.Provider = this.Provider;
			base.Insert(index, RnaLogConcessioniObj);
		}

		//CollectionGetById
		public RnaLogConcessioni CollectionGetById(NullTypes.IntNT IdRnaLogConcessioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRnaLogConcessione == IdRnaLogConcessioneValue))
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
		public RnaLogConcessioniCollection SubSelect(NullTypes.IntNT IdRnaLogConcessioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT IdProgettoRnaEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT IdFiscaleImpresaEqualThis, NullTypes.StringNT IdRichiestaEqualThis, 
NullTypes.DatetimeNT DataRichiestaEqualThis, NullTypes.IntNT IdOperatoreRegAiutoEqualThis, NullTypes.StringNT CorEqualThis, 
NullTypes.IntNT CodiceEsitoEqualThis, NullTypes.StringNT DescrizioneEsitoEqualThis, NullTypes.IntNT CodiceEsitoStatoRichiestaEqualThis, 
NullTypes.StringNT DescrizioneEsitoStatoRichiestaEqualThis, NullTypes.IntNT IdOperatoreStatoRichiestaEqualThis, NullTypes.DatetimeNT DataStatoRichiestaEqualThis, 
NullTypes.StringNT ErroreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis)
		{
			RnaLogConcessioniCollection RnaLogConcessioniCollectionTemp = new RnaLogConcessioniCollection();
			foreach (RnaLogConcessioni RnaLogConcessioniItem in this)
			{
				if (((IdRnaLogConcessioneEqualThis == null) || ((RnaLogConcessioniItem.IdRnaLogConcessione != null) && (RnaLogConcessioniItem.IdRnaLogConcessione.Value == IdRnaLogConcessioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RnaLogConcessioniItem.IdProgetto != null) && (RnaLogConcessioniItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdProgettoRnaEqualThis == null) || ((RnaLogConcessioniItem.IdProgettoRna != null) && (RnaLogConcessioniItem.IdProgettoRna.Value == IdProgettoRnaEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((RnaLogConcessioniItem.IdImpresa != null) && (RnaLogConcessioniItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdFiscaleImpresaEqualThis == null) || ((RnaLogConcessioniItem.IdFiscaleImpresa != null) && (RnaLogConcessioniItem.IdFiscaleImpresa.Value == IdFiscaleImpresaEqualThis.Value))) && ((IdRichiestaEqualThis == null) || ((RnaLogConcessioniItem.IdRichiesta != null) && (RnaLogConcessioniItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && 
((DataRichiestaEqualThis == null) || ((RnaLogConcessioniItem.DataRichiesta != null) && (RnaLogConcessioniItem.DataRichiesta.Value == DataRichiestaEqualThis.Value))) && ((IdOperatoreRegAiutoEqualThis == null) || ((RnaLogConcessioniItem.IdOperatoreRegAiuto != null) && (RnaLogConcessioniItem.IdOperatoreRegAiuto.Value == IdOperatoreRegAiutoEqualThis.Value))) && ((CorEqualThis == null) || ((RnaLogConcessioniItem.Cor != null) && (RnaLogConcessioniItem.Cor.Value == CorEqualThis.Value))) && 
((CodiceEsitoEqualThis == null) || ((RnaLogConcessioniItem.CodiceEsito != null) && (RnaLogConcessioniItem.CodiceEsito.Value == CodiceEsitoEqualThis.Value))) && ((DescrizioneEsitoEqualThis == null) || ((RnaLogConcessioniItem.DescrizioneEsito != null) && (RnaLogConcessioniItem.DescrizioneEsito.Value == DescrizioneEsitoEqualThis.Value))) && ((CodiceEsitoStatoRichiestaEqualThis == null) || ((RnaLogConcessioniItem.CodiceEsitoStatoRichiesta != null) && (RnaLogConcessioniItem.CodiceEsitoStatoRichiesta.Value == CodiceEsitoStatoRichiestaEqualThis.Value))) && 
((DescrizioneEsitoStatoRichiestaEqualThis == null) || ((RnaLogConcessioniItem.DescrizioneEsitoStatoRichiesta != null) && (RnaLogConcessioniItem.DescrizioneEsitoStatoRichiesta.Value == DescrizioneEsitoStatoRichiestaEqualThis.Value))) && ((IdOperatoreStatoRichiestaEqualThis == null) || ((RnaLogConcessioniItem.IdOperatoreStatoRichiesta != null) && (RnaLogConcessioniItem.IdOperatoreStatoRichiesta.Value == IdOperatoreStatoRichiestaEqualThis.Value))) && ((DataStatoRichiestaEqualThis == null) || ((RnaLogConcessioniItem.DataStatoRichiesta != null) && (RnaLogConcessioniItem.DataStatoRichiesta.Value == DataStatoRichiestaEqualThis.Value))) && 
((ErroreEqualThis == null) || ((RnaLogConcessioniItem.Errore != null) && (RnaLogConcessioniItem.Errore.Value == ErroreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RnaLogConcessioniItem.DataInserimento != null) && (RnaLogConcessioniItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((RnaLogConcessioniItem.DataAggiornamento != null) && (RnaLogConcessioniItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))))
				{
					RnaLogConcessioniCollectionTemp.Add(RnaLogConcessioniItem);
				}
			}
			return RnaLogConcessioniCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaLogConcessioniDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaLogConcessioniDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaLogConcessioni RnaLogConcessioniObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRnaLogConcessione", RnaLogConcessioniObj.IdRnaLogConcessione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", RnaLogConcessioniObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoRna", RnaLogConcessioniObj.IdProgettoRna);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RnaLogConcessioniObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiscaleImpresa", RnaLogConcessioniObj.IdFiscaleImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiesta", RnaLogConcessioniObj.IdRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRichiesta", RnaLogConcessioniObj.DataRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreRegAiuto", RnaLogConcessioniObj.IdOperatoreRegAiuto);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaRichiesta", RnaLogConcessioniObj.IstanzaRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaRisposta", RnaLogConcessioniObj.IstanzaRisposta);
			DbProvider.SetCmdParam(cmd,firstChar + "Cor", RnaLogConcessioniObj.Cor);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceEsito", RnaLogConcessioniObj.CodiceEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneEsito", RnaLogConcessioniObj.DescrizioneEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceEsitoStatoRichiesta", RnaLogConcessioniObj.CodiceEsitoStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneEsitoStatoRichiesta", RnaLogConcessioniObj.DescrizioneEsitoStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreStatoRichiesta", RnaLogConcessioniObj.IdOperatoreStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DataStatoRichiesta", RnaLogConcessioniObj.DataStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "Errore", RnaLogConcessioniObj.Errore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RnaLogConcessioniObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", RnaLogConcessioniObj.DataAggiornamento);
		}
		//Insert
		private static int Insert(DbProvider db, RnaLogConcessioni RnaLogConcessioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaLogConcessioniInsert", new string[] {"IdProgetto", "IdProgettoRna", 
"IdImpresa", "IdFiscaleImpresa", "IdRichiesta", 
"DataRichiesta", "IdOperatoreRegAiuto", "IstanzaRichiesta", 
"IstanzaRisposta", "Cor", "CodiceEsito", 
"DescrizioneEsito", "CodiceEsitoStatoRichiesta", "DescrizioneEsitoStatoRichiesta", 
"IdOperatoreStatoRichiesta", "DataStatoRichiesta", "Errore", 
"DataInserimento", "DataAggiornamento"}, new string[] {"int", "string", 
"int", "string", "string", 
"DateTime", "int", "string", 
"string", "string", "int", 
"string", "int", "string", 
"int", "DateTime", "string", 
"DateTime", "DateTime"},"");
				CompileIUCmd(false, insertCmd,RnaLogConcessioniObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaLogConcessioniObj.IdRnaLogConcessione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_CONCESSIONE"]);
				RnaLogConcessioniObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				RnaLogConcessioniObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
				}
				RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogConcessioniObj.IsDirty = false;
				RnaLogConcessioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaLogConcessioni RnaLogConcessioniObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaLogConcessioniUpdate", new string[] {"IdRnaLogConcessione", "IdProgetto", "IdProgettoRna", 
"IdImpresa", "IdFiscaleImpresa", "IdRichiesta", 
"DataRichiesta", "IdOperatoreRegAiuto", "IstanzaRichiesta", 
"IstanzaRisposta", "Cor", "CodiceEsito", 
"DescrizioneEsito", "CodiceEsitoStatoRichiesta", "DescrizioneEsitoStatoRichiesta", 
"IdOperatoreStatoRichiesta", "DataStatoRichiesta", "Errore", 
"DataInserimento", "DataAggiornamento"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"DateTime", "int", "string", 
"string", "string", "int", 
"string", "int", "string", 
"int", "DateTime", "string", 
"DateTime", "DateTime"},"");
				CompileIUCmd(true, updateCmd,RnaLogConcessioniObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogConcessioniObj.IsDirty = false;
				RnaLogConcessioniObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaLogConcessioni RnaLogConcessioniObj)
		{
			switch (RnaLogConcessioniObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaLogConcessioniObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaLogConcessioniObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaLogConcessioniObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaLogConcessioniCollection RnaLogConcessioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaLogConcessioniUpdate", new string[] {"IdRnaLogConcessione", "IdProgetto", "IdProgettoRna", 
"IdImpresa", "IdFiscaleImpresa", "IdRichiesta", 
"DataRichiesta", "IdOperatoreRegAiuto", "IstanzaRichiesta", 
"IstanzaRisposta", "Cor", "CodiceEsito", 
"DescrizioneEsito", "CodiceEsitoStatoRichiesta", "DescrizioneEsitoStatoRichiesta", 
"IdOperatoreStatoRichiesta", "DataStatoRichiesta", "Errore", 
"DataInserimento", "DataAggiornamento"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"DateTime", "int", "string", 
"string", "string", "int", 
"string", "int", "string", 
"int", "DateTime", "string", 
"DateTime", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaLogConcessioniInsert", new string[] {"IdProgetto", "IdProgettoRna", 
"IdImpresa", "IdFiscaleImpresa", "IdRichiesta", 
"DataRichiesta", "IdOperatoreRegAiuto", "IstanzaRichiesta", 
"IstanzaRisposta", "Cor", "CodiceEsito", 
"DescrizioneEsito", "CodiceEsitoStatoRichiesta", "DescrizioneEsitoStatoRichiesta", 
"IdOperatoreStatoRichiesta", "DataStatoRichiesta", "Errore", 
"DataInserimento", "DataAggiornamento"}, new string[] {"int", "string", 
"int", "string", "string", 
"DateTime", "int", "string", 
"string", "string", "int", 
"string", "int", "string", 
"int", "DateTime", "string", 
"DateTime", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogConcessioniDelete", new string[] {"IdRnaLogConcessione"}, new string[] {"int"},"");
				for (int i = 0; i < RnaLogConcessioniCollectionObj.Count; i++)
				{
					switch (RnaLogConcessioniCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaLogConcessioniCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaLogConcessioniCollectionObj[i].IdRnaLogConcessione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_CONCESSIONE"]);
									RnaLogConcessioniCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									RnaLogConcessioniCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaLogConcessioniCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaLogConcessioniCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogConcessione", (SiarLibrary.NullTypes.IntNT)RnaLogConcessioniCollectionObj[i].IdRnaLogConcessione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaLogConcessioniCollectionObj.Count; i++)
				{
					if ((RnaLogConcessioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaLogConcessioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaLogConcessioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaLogConcessioniCollectionObj[i].IsDirty = false;
						RnaLogConcessioniCollectionObj[i].IsPersistent = true;
					}
					if ((RnaLogConcessioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaLogConcessioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaLogConcessioniCollectionObj[i].IsDirty = false;
						RnaLogConcessioniCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaLogConcessioni RnaLogConcessioniObj)
		{
			int returnValue = 0;
			if (RnaLogConcessioniObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaLogConcessioniObj.IdRnaLogConcessione);
			}
			RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaLogConcessioniObj.IsDirty = false;
			RnaLogConcessioniObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRnaLogConcessioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogConcessioniDelete", new string[] {"IdRnaLogConcessione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogConcessione", (SiarLibrary.NullTypes.IntNT)IdRnaLogConcessioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaLogConcessioniCollection RnaLogConcessioniCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogConcessioniDelete", new string[] {"IdRnaLogConcessione"}, new string[] {"int"},"");
				for (int i = 0; i < RnaLogConcessioniCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogConcessione", RnaLogConcessioniCollectionObj[i].IdRnaLogConcessione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaLogConcessioniCollectionObj.Count; i++)
				{
					if ((RnaLogConcessioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaLogConcessioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaLogConcessioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaLogConcessioniCollectionObj[i].IsDirty = false;
						RnaLogConcessioniCollectionObj[i].IsPersistent = false;
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
		public static RnaLogConcessioni GetById(DbProvider db, int IdRnaLogConcessioneValue)
		{
			RnaLogConcessioni RnaLogConcessioniObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaLogConcessioniGetById", new string[] {"IdRnaLogConcessione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRnaLogConcessione", (SiarLibrary.NullTypes.IntNT)IdRnaLogConcessioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaLogConcessioniObj = GetFromDatareader(db);
				RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogConcessioniObj.IsDirty = false;
				RnaLogConcessioniObj.IsPersistent = true;
			}
			db.Close();
			return RnaLogConcessioniObj;
		}

		//getFromDatareader
		public static RnaLogConcessioni GetFromDatareader(DbProvider db)
		{
			RnaLogConcessioni RnaLogConcessioniObj = new RnaLogConcessioni();
			RnaLogConcessioniObj.IdRnaLogConcessione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_CONCESSIONE"]);
			RnaLogConcessioniObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RnaLogConcessioniObj.IdProgettoRna = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_PROGETTO_RNA"]);
			RnaLogConcessioniObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RnaLogConcessioniObj.IdFiscaleImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FISCALE_IMPRESA"]);
			RnaLogConcessioniObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			RnaLogConcessioniObj.DataRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA"]);
			RnaLogConcessioniObj.IdOperatoreRegAiuto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_REG_AIUTO"]);
			RnaLogConcessioniObj.IstanzaRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_RICHIESTA"]);
			RnaLogConcessioniObj.IstanzaRisposta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_RISPOSTA"]);
			RnaLogConcessioniObj.Cor = new SiarLibrary.NullTypes.StringNT(db.DataReader["COR"]);
			RnaLogConcessioniObj.CodiceEsito = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO"]);
			RnaLogConcessioniObj.DescrizioneEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO"]);
			RnaLogConcessioniObj.CodiceEsitoStatoRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO_STATO_RICHIESTA"]);
			RnaLogConcessioniObj.DescrizioneEsitoStatoRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO_STATO_RICHIESTA"]);
			RnaLogConcessioniObj.IdOperatoreStatoRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_STATO_RICHIESTA"]);
			RnaLogConcessioniObj.DataStatoRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_STATO_RICHIESTA"]);
			RnaLogConcessioniObj.Errore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ERRORE"]);
			RnaLogConcessioniObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RnaLogConcessioniObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaLogConcessioniObj.IsDirty = false;
			RnaLogConcessioniObj.IsPersistent = true;
			return RnaLogConcessioniObj;
		}

		//Find Select

		public static RnaLogConcessioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaLogConcessioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT IdProgettoRnaEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT IdFiscaleImpresaEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRichiestaEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreRegAiutoEqualThis, SiarLibrary.NullTypes.StringNT CorEqualThis, 
SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, SiarLibrary.NullTypes.IntNT CodiceEsitoStatoRichiestaEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEsitoStatoRichiestaEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreStatoRichiestaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataStatoRichiestaEqualThis, 
SiarLibrary.NullTypes.StringNT ErroreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis)

		{

			RnaLogConcessioniCollection RnaLogConcessioniCollectionObj = new RnaLogConcessioniCollection();

			IDbCommand findCmd = db.InitCmd("Zrnalogconcessionifindselect", new string[] {"IdRnaLogConcessioneequalthis", "IdProgettoequalthis", "IdProgettoRnaequalthis", 
"IdImpresaequalthis", "IdFiscaleImpresaequalthis", "IdRichiestaequalthis", 
"DataRichiestaequalthis", "IdOperatoreRegAiutoequalthis", "Corequalthis", 
"CodiceEsitoequalthis", "DescrizioneEsitoequalthis", "CodiceEsitoStatoRichiestaequalthis", 
"DescrizioneEsitoStatoRichiestaequalthis", "IdOperatoreStatoRichiestaequalthis", "DataStatoRichiestaequalthis", 
"Erroreequalthis", "DataInserimentoequalthis", "DataAggiornamentoequalthis"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"DateTime", "int", "string", 
"int", "string", "int", 
"string", "int", "DateTime", 
"string", "DateTime", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaLogConcessioneequalthis", IdRnaLogConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoRnaequalthis", IdProgettoRnaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiscaleImpresaequalthis", IdFiscaleImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRichiestaequalthis", DataRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreRegAiutoequalthis", IdOperatoreRegAiutoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Corequalthis", CorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceEsitoStatoRichiestaequalthis", CodiceEsitoStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoStatoRichiestaequalthis", DescrizioneEsitoStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreStatoRichiestaequalthis", IdOperatoreStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataStatoRichiestaequalthis", DataStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Erroreequalthis", ErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			RnaLogConcessioni RnaLogConcessioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaLogConcessioniObj = GetFromDatareader(db);
				RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogConcessioniObj.IsDirty = false;
				RnaLogConcessioniObj.IsPersistent = true;
				RnaLogConcessioniCollectionObj.Add(RnaLogConcessioniObj);
			}
			db.Close();
			return RnaLogConcessioniCollectionObj;
		}

		//Find Find

		public static RnaLogConcessioniCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaLogConcessioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT IdProgettoRnaEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis)

		{

			RnaLogConcessioniCollection RnaLogConcessioniCollectionObj = new RnaLogConcessioniCollection();

			IDbCommand findCmd = db.InitCmd("Zrnalogconcessionifindfind", new string[] {"IdRnaLogConcessioneequalthis", "IdProgettoequalthis", "IdProgettoRnaequalthis", 
"IdImpresaequalthis", "IdRichiestaequalthis"}, new string[] {"int", "int", "string", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaLogConcessioneequalthis", IdRnaLogConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoRnaequalthis", IdProgettoRnaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			RnaLogConcessioni RnaLogConcessioniObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaLogConcessioniObj = GetFromDatareader(db);
				RnaLogConcessioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogConcessioniObj.IsDirty = false;
				RnaLogConcessioniObj.IsPersistent = true;
				RnaLogConcessioniCollectionObj.Add(RnaLogConcessioniObj);
			}
			db.Close();
			return RnaLogConcessioniCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaLogConcessioniCollectionProvider:IRnaLogConcessioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaLogConcessioniCollectionProvider : IRnaLogConcessioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaLogConcessioni
		protected RnaLogConcessioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaLogConcessioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaLogConcessioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public RnaLogConcessioniCollectionProvider(IntNT IdrnalogconcessioneEqualThis, IntNT IdprogettoEqualThis, StringNT IdprogettornaEqualThis, 
IntNT IdimpresaEqualThis, StringNT IdrichiestaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrnalogconcessioneEqualThis, IdprogettoEqualThis, IdprogettornaEqualThis, 
IdimpresaEqualThis, IdrichiestaEqualThis);
		}

		//Costruttore3: ha in input rnalogconcessioniCollectionObj - non popola la collection
		public RnaLogConcessioniCollectionProvider(RnaLogConcessioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaLogConcessioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaLogConcessioniCollection(this);
		}

		//Get e Set
		public RnaLogConcessioniCollection CollectionObj
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
		public int SaveCollection(RnaLogConcessioniCollection collectionObj)
		{
			return RnaLogConcessioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaLogConcessioni rnalogconcessioniObj)
		{
			return RnaLogConcessioniDAL.Save(_dbProviderObj, rnalogconcessioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaLogConcessioniCollection collectionObj)
		{
			return RnaLogConcessioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaLogConcessioni rnalogconcessioniObj)
		{
			return RnaLogConcessioniDAL.Delete(_dbProviderObj, rnalogconcessioniObj);
		}

		//getById
		public RnaLogConcessioni GetById(IntNT IdRnaLogConcessioneValue)
		{
			RnaLogConcessioni RnaLogConcessioniTemp = RnaLogConcessioniDAL.GetById(_dbProviderObj, IdRnaLogConcessioneValue);
			if (RnaLogConcessioniTemp!=null) RnaLogConcessioniTemp.Provider = this;
			return RnaLogConcessioniTemp;
		}

		//Select: popola la collection
		public RnaLogConcessioniCollection Select(IntNT IdrnalogconcessioneEqualThis, IntNT IdprogettoEqualThis, StringNT IdprogettornaEqualThis, 
IntNT IdimpresaEqualThis, StringNT IdfiscaleimpresaEqualThis, StringNT IdrichiestaEqualThis, 
DatetimeNT DatarichiestaEqualThis, IntNT IdoperatoreregaiutoEqualThis, StringNT CorEqualThis, 
IntNT CodiceesitoEqualThis, StringNT DescrizioneesitoEqualThis, IntNT CodiceesitostatorichiestaEqualThis, 
StringNT DescrizioneesitostatorichiestaEqualThis, IntNT IdoperatorestatorichiestaEqualThis, DatetimeNT DatastatorichiestaEqualThis, 
StringNT ErroreEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis)
		{
			RnaLogConcessioniCollection RnaLogConcessioniCollectionTemp = RnaLogConcessioniDAL.Select(_dbProviderObj, IdrnalogconcessioneEqualThis, IdprogettoEqualThis, IdprogettornaEqualThis, 
IdimpresaEqualThis, IdfiscaleimpresaEqualThis, IdrichiestaEqualThis, 
DatarichiestaEqualThis, IdoperatoreregaiutoEqualThis, CorEqualThis, 
CodiceesitoEqualThis, DescrizioneesitoEqualThis, CodiceesitostatorichiestaEqualThis, 
DescrizioneesitostatorichiestaEqualThis, IdoperatorestatorichiestaEqualThis, DatastatorichiestaEqualThis, 
ErroreEqualThis, DatainserimentoEqualThis, DataaggiornamentoEqualThis);
			RnaLogConcessioniCollectionTemp.Provider = this;
			return RnaLogConcessioniCollectionTemp;
		}

		//Find: popola la collection
		public RnaLogConcessioniCollection Find(IntNT IdrnalogconcessioneEqualThis, IntNT IdprogettoEqualThis, StringNT IdprogettornaEqualThis, 
IntNT IdimpresaEqualThis, StringNT IdrichiestaEqualThis)
		{
			RnaLogConcessioniCollection RnaLogConcessioniCollectionTemp = RnaLogConcessioniDAL.Find(_dbProviderObj, IdrnalogconcessioneEqualThis, IdprogettoEqualThis, IdprogettornaEqualThis, 
IdimpresaEqualThis, IdrichiestaEqualThis);
			RnaLogConcessioniCollectionTemp.Provider = this;
			return RnaLogConcessioniCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_LOG_CONCESSIONI>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_RNA_LOG_CONCESSIONE>Equal</ID_RNA_LOG_CONCESSIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROGETTO_RNA>Equal</ID_PROGETTO_RNA>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_RICHIESTA>Equal</ID_RICHIESTA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_LOG_CONCESSIONI>
*/
