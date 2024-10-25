using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per DownloadMassivoRichieste
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDownloadMassivoRichiesteProvider
	{
		int Save(DownloadMassivoRichieste DownloadMassivoRichiesteObj);
		int SaveCollection(DownloadMassivoRichiesteCollection collectionObj);
		int Delete(DownloadMassivoRichieste DownloadMassivoRichiesteObj);
		int DeleteCollection(DownloadMassivoRichiesteCollection collectionObj);
	}
	/// <summary>
	/// Summary description for DownloadMassivoRichieste
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class DownloadMassivoRichieste: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTicket;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.IntNT _IdIntegrazione;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.DatetimeNT _DataInizioEstrazione;
		private NullTypes.DatetimeNT _DataFineEstrazione;
		private NullTypes.BoolNT _Eseguito;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.BoolNT _Eliminato;
		private NullTypes.DecimalNT _DimensioneFile;
		[NonSerialized] private IDownloadMassivoRichiesteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDownloadMassivoRichiesteProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public DownloadMassivoRichieste()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TICKET
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTicket
		{
			get { return _IdTicket; }
			set {
				if (IdTicket != value)
				{
					_IdTicket = value;
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
		/// Corrisponde al campo:ID_INTEGRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntegrazione
		{
			get { return _IdIntegrazione; }
			set {
				if (IdIntegrazione != value)
				{
					_IdIntegrazione = value;
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

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioEstrazione
		{
			get { return _DataInizioEstrazione; }
			set {
				if (DataInizioEstrazione != value)
				{
					_DataInizioEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineEstrazione
		{
			get { return _DataFineEstrazione; }
			set {
				if (DataFineEstrazione != value)
				{
					_DataFineEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESEGUITO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Eseguito
		{
			get { return _Eseguito; }
			set {
				if (Eseguito != value)
				{
					_Eseguito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(30)
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
		/// Corrisponde al campo:ELIMINATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Eliminato
		{
			get { return _Eliminato; }
			set {
				if (Eliminato != value)
				{
					_Eliminato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_FILE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT DimensioneFile
		{
			get { return _DimensioneFile; }
			set {
				if (DimensioneFile != value)
				{
					_DimensioneFile = value;
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
	/// Summary description for DownloadMassivoRichiesteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DownloadMassivoRichiesteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DownloadMassivoRichiesteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DownloadMassivoRichieste) info.GetValue(i.ToString(),typeof(DownloadMassivoRichieste)));
			}
		}

		//Costruttore
		public DownloadMassivoRichiesteCollection()
		{
			this.ItemType = typeof(DownloadMassivoRichieste);
		}

		//Costruttore con provider
		public DownloadMassivoRichiesteCollection(IDownloadMassivoRichiesteProvider providerObj)
		{
			this.ItemType = typeof(DownloadMassivoRichieste);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DownloadMassivoRichieste this[int index]
		{
			get { return (DownloadMassivoRichieste)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DownloadMassivoRichiesteCollection GetChanges()
		{
			return (DownloadMassivoRichiesteCollection) base.GetChanges();
		}

		[NonSerialized] private IDownloadMassivoRichiesteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDownloadMassivoRichiesteProvider Provider
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
		public int Add(DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			if (DownloadMassivoRichiesteObj.Provider == null) DownloadMassivoRichiesteObj.Provider = this.Provider;
			return base.Add(DownloadMassivoRichiesteObj);
		}

		//AddCollection
		public void AddCollection(DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionObj)
		{
			foreach (DownloadMassivoRichieste DownloadMassivoRichiesteObj in DownloadMassivoRichiesteCollectionObj)
				this.Add(DownloadMassivoRichiesteObj);
		}

		//Insert
		public void Insert(int index, DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			if (DownloadMassivoRichiesteObj.Provider == null) DownloadMassivoRichiesteObj.Provider = this.Provider;
			base.Insert(index, DownloadMassivoRichiesteObj);
		}

		//CollectionGetById
		public DownloadMassivoRichieste CollectionGetById(NullTypes.IntNT IdTicketValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTicket == IdTicketValue))
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
		public DownloadMassivoRichiesteCollection SubSelect(NullTypes.IntNT IdTicketEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdIntegrazioneEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataAggiornamentoEqualThis, NullTypes.DatetimeNT DataInizioEstrazioneEqualThis, NullTypes.DatetimeNT DataFineEstrazioneEqualThis, 
NullTypes.BoolNT EseguitoEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.BoolNT EliminatoEqualThis, 
NullTypes.DecimalNT DimensioneFileEqualThis)
		{
			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionTemp = new DownloadMassivoRichiesteCollection();
			foreach (DownloadMassivoRichieste DownloadMassivoRichiesteItem in this)
			{
				if (((IdTicketEqualThis == null) || ((DownloadMassivoRichiesteItem.IdTicket != null) && (DownloadMassivoRichiesteItem.IdTicket.Value == IdTicketEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DownloadMassivoRichiesteItem.IdProgetto != null) && (DownloadMassivoRichiesteItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DownloadMassivoRichiesteItem.IdDomandaPagamento != null) && (DownloadMassivoRichiesteItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdIntegrazioneEqualThis == null) || ((DownloadMassivoRichiesteItem.IdIntegrazione != null) && (DownloadMassivoRichiesteItem.IdIntegrazione.Value == IdIntegrazioneEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((DownloadMassivoRichiesteItem.Segnatura != null) && (DownloadMassivoRichiesteItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((DownloadMassivoRichiesteItem.DataInserimento != null) && (DownloadMassivoRichiesteItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataAggiornamentoEqualThis == null) || ((DownloadMassivoRichiesteItem.DataAggiornamento != null) && (DownloadMassivoRichiesteItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && ((DataInizioEstrazioneEqualThis == null) || ((DownloadMassivoRichiesteItem.DataInizioEstrazione != null) && (DownloadMassivoRichiesteItem.DataInizioEstrazione.Value == DataInizioEstrazioneEqualThis.Value))) && ((DataFineEstrazioneEqualThis == null) || ((DownloadMassivoRichiesteItem.DataFineEstrazione != null) && (DownloadMassivoRichiesteItem.DataFineEstrazione.Value == DataFineEstrazioneEqualThis.Value))) && 
((EseguitoEqualThis == null) || ((DownloadMassivoRichiesteItem.Eseguito != null) && (DownloadMassivoRichiesteItem.Eseguito.Value == EseguitoEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((DownloadMassivoRichiesteItem.CfOperatore != null) && (DownloadMassivoRichiesteItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((EliminatoEqualThis == null) || ((DownloadMassivoRichiesteItem.Eliminato != null) && (DownloadMassivoRichiesteItem.Eliminato.Value == EliminatoEqualThis.Value))) && 
((DimensioneFileEqualThis == null) || ((DownloadMassivoRichiesteItem.DimensioneFile != null) && (DownloadMassivoRichiesteItem.DimensioneFile.Value == DimensioneFileEqualThis.Value))))
				{
					DownloadMassivoRichiesteCollectionTemp.Add(DownloadMassivoRichiesteItem);
				}
			}
			return DownloadMassivoRichiesteCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public DownloadMassivoRichiesteCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdIntegrazioneEqualThis, 
NullTypes.StringNT CfOperatoreEqualThis)
		{
			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionTemp = new DownloadMassivoRichiesteCollection();
			foreach (DownloadMassivoRichieste DownloadMassivoRichiesteItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((DownloadMassivoRichiesteItem.IdProgetto != null) && (DownloadMassivoRichiesteItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DownloadMassivoRichiesteItem.IdDomandaPagamento != null) && (DownloadMassivoRichiesteItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdIntegrazioneEqualThis == null) || ((DownloadMassivoRichiesteItem.IdIntegrazione != null) && (DownloadMassivoRichiesteItem.IdIntegrazione.Value == IdIntegrazioneEqualThis.Value))) && 
((CfOperatoreEqualThis == null) || ((DownloadMassivoRichiesteItem.CfOperatore != null) && (DownloadMassivoRichiesteItem.CfOperatore.Value == CfOperatoreEqualThis.Value))))
				{
					DownloadMassivoRichiesteCollectionTemp.Add(DownloadMassivoRichiesteItem);
				}
			}
			return DownloadMassivoRichiesteCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DownloadMassivoRichiesteDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DownloadMassivoRichiesteDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DownloadMassivoRichieste DownloadMassivoRichiesteObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTicket", DownloadMassivoRichiesteObj.IdTicket);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", DownloadMassivoRichiesteObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDomandaPagamento", DownloadMassivoRichiesteObj.IdDomandaPagamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIntegrazione", DownloadMassivoRichiesteObj.IdIntegrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", DownloadMassivoRichiesteObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", DownloadMassivoRichiesteObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", DownloadMassivoRichiesteObj.DataAggiornamento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioEstrazione", DownloadMassivoRichiesteObj.DataInizioEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineEstrazione", DownloadMassivoRichiesteObj.DataFineEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Eseguito", DownloadMassivoRichiesteObj.Eseguito);
			DbProvider.SetCmdParam(cmd,firstChar + "CfOperatore", DownloadMassivoRichiesteObj.CfOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Eliminato", DownloadMassivoRichiesteObj.Eliminato);
			DbProvider.SetCmdParam(cmd,firstChar + "DimensioneFile", DownloadMassivoRichiesteObj.DimensioneFile);
		}
		//Insert
		private static int Insert(DbProvider db, DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDownloadMassivoRichiesteInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdIntegrazione", "Segnatura", "DataInserimento", 
"DataAggiornamento", "DataInizioEstrazione", "DataFineEstrazione", 
"Eseguito", "CfOperatore", "Eliminato", 
"DimensioneFile"}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"bool", "string", "bool", 
"decimal"},"");
				CompileIUCmd(false, insertCmd,DownloadMassivoRichiesteObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DownloadMassivoRichiesteObj.IdTicket = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TICKET"]);
				DownloadMassivoRichiesteObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				DownloadMassivoRichiesteObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
				DownloadMassivoRichiesteObj.Eseguito = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESEGUITO"]);
				DownloadMassivoRichiesteObj.Eliminato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ELIMINATO"]);
				}
				DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DownloadMassivoRichiesteObj.IsDirty = false;
				DownloadMassivoRichiesteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDownloadMassivoRichiesteUpdate", new string[] {"IdTicket", "IdProgetto", "IdDomandaPagamento", 
"IdIntegrazione", "Segnatura", "DataInserimento", 
"DataAggiornamento", "DataInizioEstrazione", "DataFineEstrazione", 
"Eseguito", "CfOperatore", "Eliminato", 
"DimensioneFile"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"bool", "string", "bool", 
"decimal"},"");
				CompileIUCmd(true, updateCmd,DownloadMassivoRichiesteObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DownloadMassivoRichiesteObj.IsDirty = false;
				DownloadMassivoRichiesteObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			switch (DownloadMassivoRichiesteObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DownloadMassivoRichiesteObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DownloadMassivoRichiesteObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DownloadMassivoRichiesteObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDownloadMassivoRichiesteUpdate", new string[] {"IdTicket", "IdProgetto", "IdDomandaPagamento", 
"IdIntegrazione", "Segnatura", "DataInserimento", 
"DataAggiornamento", "DataInizioEstrazione", "DataFineEstrazione", 
"Eseguito", "CfOperatore", "Eliminato", 
"DimensioneFile"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"bool", "string", "bool", 
"decimal"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDownloadMassivoRichiesteInsert", new string[] {"IdProgetto", "IdDomandaPagamento", 
"IdIntegrazione", "Segnatura", "DataInserimento", 
"DataAggiornamento", "DataInizioEstrazione", "DataFineEstrazione", 
"Eseguito", "CfOperatore", "Eliminato", 
"DimensioneFile"}, new string[] {"int", "int", 
"int", "string", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"bool", "string", "bool", 
"decimal"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDownloadMassivoRichiesteDelete", new string[] {"IdTicket"}, new string[] {"int"},"");
				for (int i = 0; i < DownloadMassivoRichiesteCollectionObj.Count; i++)
				{
					switch (DownloadMassivoRichiesteCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DownloadMassivoRichiesteCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DownloadMassivoRichiesteCollectionObj[i].IdTicket = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TICKET"]);
									DownloadMassivoRichiesteCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									DownloadMassivoRichiesteCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
									DownloadMassivoRichiesteCollectionObj[i].Eseguito = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESEGUITO"]);
									DownloadMassivoRichiesteCollectionObj[i].Eliminato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ELIMINATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DownloadMassivoRichiesteCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DownloadMassivoRichiesteCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTicket", (SiarLibrary.NullTypes.IntNT)DownloadMassivoRichiesteCollectionObj[i].IdTicket);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DownloadMassivoRichiesteCollectionObj.Count; i++)
				{
					if ((DownloadMassivoRichiesteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DownloadMassivoRichiesteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DownloadMassivoRichiesteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DownloadMassivoRichiesteCollectionObj[i].IsDirty = false;
						DownloadMassivoRichiesteCollectionObj[i].IsPersistent = true;
					}
					if ((DownloadMassivoRichiesteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DownloadMassivoRichiesteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DownloadMassivoRichiesteCollectionObj[i].IsDirty = false;
						DownloadMassivoRichiesteCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, DownloadMassivoRichieste DownloadMassivoRichiesteObj)
		{
			int returnValue = 0;
			if (DownloadMassivoRichiesteObj.IsPersistent) 
			{
				returnValue = Delete(db, DownloadMassivoRichiesteObj.IdTicket);
			}
			DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DownloadMassivoRichiesteObj.IsDirty = false;
			DownloadMassivoRichiesteObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTicketValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDownloadMassivoRichiesteDelete", new string[] {"IdTicket"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTicket", (SiarLibrary.NullTypes.IntNT)IdTicketValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDownloadMassivoRichiesteDelete", new string[] {"IdTicket"}, new string[] {"int"},"");
				for (int i = 0; i < DownloadMassivoRichiesteCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTicket", DownloadMassivoRichiesteCollectionObj[i].IdTicket);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DownloadMassivoRichiesteCollectionObj.Count; i++)
				{
					if ((DownloadMassivoRichiesteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DownloadMassivoRichiesteCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DownloadMassivoRichiesteCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DownloadMassivoRichiesteCollectionObj[i].IsDirty = false;
						DownloadMassivoRichiesteCollectionObj[i].IsPersistent = false;
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
		public static DownloadMassivoRichieste GetById(DbProvider db, int IdTicketValue)
		{
			DownloadMassivoRichieste DownloadMassivoRichiesteObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDownloadMassivoRichiesteGetById", new string[] {"IdTicket"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTicket", (SiarLibrary.NullTypes.IntNT)IdTicketValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DownloadMassivoRichiesteObj = GetFromDatareader(db);
				DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DownloadMassivoRichiesteObj.IsDirty = false;
				DownloadMassivoRichiesteObj.IsPersistent = true;
			}
			db.Close();
			return DownloadMassivoRichiesteObj;
		}

		//getFromDatareader
		public static DownloadMassivoRichieste GetFromDatareader(DbProvider db)
		{
			DownloadMassivoRichieste DownloadMassivoRichiesteObj = new DownloadMassivoRichieste();
			DownloadMassivoRichiesteObj.IdTicket = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TICKET"]);
			DownloadMassivoRichiesteObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			DownloadMassivoRichiesteObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			DownloadMassivoRichiesteObj.IdIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE"]);
			DownloadMassivoRichiesteObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			DownloadMassivoRichiesteObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			DownloadMassivoRichiesteObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			DownloadMassivoRichiesteObj.DataInizioEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_ESTRAZIONE"]);
			DownloadMassivoRichiesteObj.DataFineEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_ESTRAZIONE"]);
			DownloadMassivoRichiesteObj.Eseguito = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESEGUITO"]);
			DownloadMassivoRichiesteObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			DownloadMassivoRichiesteObj.Eliminato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ELIMINATO"]);
			DownloadMassivoRichiesteObj.DimensioneFile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DIMENSIONE_FILE"]);
			DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DownloadMassivoRichiesteObj.IsDirty = false;
			DownloadMassivoRichiesteObj.IsPersistent = true;
			return DownloadMassivoRichiesteObj;
		}

		//Find Select

		public static DownloadMassivoRichiesteCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTicketEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdIntegrazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEstrazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEstrazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT EseguitoEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT EliminatoEqualThis, 
SiarLibrary.NullTypes.DecimalNT DimensioneFileEqualThis)

		{

			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionObj = new DownloadMassivoRichiesteCollection();

			IDbCommand findCmd = db.InitCmd("Zdownloadmassivorichiestefindselect", new string[] {"IdTicketequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis", 
"IdIntegrazioneequalthis", "Segnaturaequalthis", "DataInserimentoequalthis", 
"DataAggiornamentoequalthis", "DataInizioEstrazioneequalthis", "DataFineEstrazioneequalthis", 
"Eseguitoequalthis", "CfOperatoreequalthis", "Eliminatoequalthis", 
"DimensioneFileequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "DateTime", 
"DateTime", "DateTime", "DateTime", 
"bool", "string", "bool", 
"decimal"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneequalthis", IdIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioEstrazioneequalthis", DataInizioEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineEstrazioneequalthis", DataFineEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eseguitoequalthis", EseguitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eliminatoequalthis", EliminatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DimensioneFileequalthis", DimensioneFileEqualThis);
			DownloadMassivoRichieste DownloadMassivoRichiesteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DownloadMassivoRichiesteObj = GetFromDatareader(db);
				DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DownloadMassivoRichiesteObj.IsDirty = false;
				DownloadMassivoRichiesteObj.IsPersistent = true;
				DownloadMassivoRichiesteCollectionObj.Add(DownloadMassivoRichiesteObj);
			}
			db.Close();
			return DownloadMassivoRichiesteCollectionObj;
		}

		//Find Find

		public static DownloadMassivoRichiesteCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdIntegrazioneEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT EseguitoEqualThis, 
SiarLibrary.NullTypes.BoolNT EliminatoEqualThis)

		{

			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionObj = new DownloadMassivoRichiesteCollection();

			IDbCommand findCmd = db.InitCmd("Zdownloadmassivorichiestefindfind", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdIntegrazioneequalthis", 
"Segnaturaequalthis", "CfOperatoreequalthis", "Eseguitoequalthis", 
"Eliminatoequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "bool", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneequalthis", IdIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eseguitoequalthis", EseguitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eliminatoequalthis", EliminatoEqualThis);
			DownloadMassivoRichieste DownloadMassivoRichiesteObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DownloadMassivoRichiesteObj = GetFromDatareader(db);
				DownloadMassivoRichiesteObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DownloadMassivoRichiesteObj.IsDirty = false;
				DownloadMassivoRichiesteObj.IsPersistent = true;
				DownloadMassivoRichiesteCollectionObj.Add(DownloadMassivoRichiesteObj);
			}
			db.Close();
			return DownloadMassivoRichiesteCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DownloadMassivoRichiesteCollectionProvider:IDownloadMassivoRichiesteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DownloadMassivoRichiesteCollectionProvider : IDownloadMassivoRichiesteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DownloadMassivoRichieste
		protected DownloadMassivoRichiesteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DownloadMassivoRichiesteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DownloadMassivoRichiesteCollection(this);
		}

		//Costruttore 2: popola la collection
		public DownloadMassivoRichiesteCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdintegrazioneEqualThis, 
StringNT SegnaturaEqualThis, StringNT CfoperatoreEqualThis, BoolNT EseguitoEqualThis, 
BoolNT EliminatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdintegrazioneEqualThis, 
SegnaturaEqualThis, CfoperatoreEqualThis, EseguitoEqualThis, 
EliminatoEqualThis);
		}

		//Costruttore3: ha in input downloadmassivorichiesteCollectionObj - non popola la collection
		public DownloadMassivoRichiesteCollectionProvider(DownloadMassivoRichiesteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DownloadMassivoRichiesteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DownloadMassivoRichiesteCollection(this);
		}

		//Get e Set
		public DownloadMassivoRichiesteCollection CollectionObj
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
		public int SaveCollection(DownloadMassivoRichiesteCollection collectionObj)
		{
			return DownloadMassivoRichiesteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DownloadMassivoRichieste downloadmassivorichiesteObj)
		{
			return DownloadMassivoRichiesteDAL.Save(_dbProviderObj, downloadmassivorichiesteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DownloadMassivoRichiesteCollection collectionObj)
		{
			return DownloadMassivoRichiesteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DownloadMassivoRichieste downloadmassivorichiesteObj)
		{
			return DownloadMassivoRichiesteDAL.Delete(_dbProviderObj, downloadmassivorichiesteObj);
		}

		//getById
		public DownloadMassivoRichieste GetById(IntNT IdTicketValue)
		{
			DownloadMassivoRichieste DownloadMassivoRichiesteTemp = DownloadMassivoRichiesteDAL.GetById(_dbProviderObj, IdTicketValue);
			if (DownloadMassivoRichiesteTemp!=null) DownloadMassivoRichiesteTemp.Provider = this;
			return DownloadMassivoRichiesteTemp;
		}

		//Select: popola la collection
		public DownloadMassivoRichiesteCollection Select(IntNT IdticketEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, 
IntNT IdintegrazioneEqualThis, StringNT SegnaturaEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DataaggiornamentoEqualThis, DatetimeNT DatainizioestrazioneEqualThis, DatetimeNT DatafineestrazioneEqualThis, 
BoolNT EseguitoEqualThis, StringNT CfoperatoreEqualThis, BoolNT EliminatoEqualThis, 
DecimalNT DimensionefileEqualThis)
		{
			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionTemp = DownloadMassivoRichiesteDAL.Select(_dbProviderObj, IdticketEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis, 
IdintegrazioneEqualThis, SegnaturaEqualThis, DatainserimentoEqualThis, 
DataaggiornamentoEqualThis, DatainizioestrazioneEqualThis, DatafineestrazioneEqualThis, 
EseguitoEqualThis, CfoperatoreEqualThis, EliminatoEqualThis, 
DimensionefileEqualThis);
			DownloadMassivoRichiesteCollectionTemp.Provider = this;
			return DownloadMassivoRichiesteCollectionTemp;
		}

		//Find: popola la collection
		public DownloadMassivoRichiesteCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdintegrazioneEqualThis, 
StringNT SegnaturaEqualThis, StringNT CfoperatoreEqualThis, BoolNT EseguitoEqualThis, 
BoolNT EliminatoEqualThis)
		{
			DownloadMassivoRichiesteCollection DownloadMassivoRichiesteCollectionTemp = DownloadMassivoRichiesteDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdintegrazioneEqualThis, 
SegnaturaEqualThis, CfoperatoreEqualThis, EseguitoEqualThis, 
EliminatoEqualThis);
			DownloadMassivoRichiesteCollectionTemp.Provider = this;
			return DownloadMassivoRichiesteCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOWNLOAD_MASSIVO_RICHIESTE>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_INTEGRAZIONE>Equal</ID_INTEGRAZIONE>
      <SEGNATURA>Equal</SEGNATURA>
      <CF_OPERATORE>Equal</CF_OPERATORE>
      <ESEGUITO>Equal</ESEGUITO>
      <ELIMINATO>Equal</ELIMINATO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_INTEGRAZIONE>Equal</ID_INTEGRAZIONE>
      <CF_OPERATORE>Equal</CF_OPERATORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOWNLOAD_MASSIVO_RICHIESTE>
*/
