using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaLogVisure
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaLogVisureProvider
	{
		int Save(RnaLogVisure RnaLogVisureObj);
		int SaveCollection(RnaLogVisureCollection collectionObj);
		int Delete(RnaLogVisure RnaLogVisureObj);
		int DeleteCollection(RnaLogVisureCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaLogVisure
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaLogVisure: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaLogVisura;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _IdFiscaleImpresa;
		private NullTypes.StringNT _IdRichiesta;
		private NullTypes.StringNT _TipoVisura;
		private NullTypes.IntNT _CodiceEsito;
		private NullTypes.StringNT _DescrizioneEsito;
		private NullTypes.DatetimeNT _DataRichiesta;
		private NullTypes.IntNT _CodiceStatoRichiesta;
		private NullTypes.StringNT _DescrizioneStatoRichiesta;
		private NullTypes.DatetimeNT _DataStatoRichiesta;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.IntNT _IdArchivioFile;
		[NonSerialized] private IRnaLogVisureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaLogVisureProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaLogVisure()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_LOG_VISURA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaLogVisura
		{
			get { return _IdRnaLogVisura; }
			set {
				if (IdRnaLogVisura != value)
				{
					_IdRnaLogVisura = value;
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
		/// Corrisponde al campo:TIPO_VISURA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoVisura
		{
			get { return _TipoVisura; }
			set {
				if (TipoVisura != value)
				{
					_TipoVisura = value;
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
		/// Corrisponde al campo:CODICE_STATO_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceStatoRichiesta
		{
			get { return _CodiceStatoRichiesta; }
			set {
				if (CodiceStatoRichiesta != value)
				{
					_CodiceStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_STATO_RICHIESTA
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneStatoRichiesta
		{
			get { return _DescrizioneStatoRichiesta; }
			set {
				if (DescrizioneStatoRichiesta != value)
				{
					_DescrizioneStatoRichiesta = value;
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
		/// Corrisponde al campo:ID_OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatore
		{
			get { return _IdOperatore; }
			set {
				if (IdOperatore != value)
				{
					_IdOperatore = value;
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
		/// Corrisponde al campo:ID_ARCHIVIO_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdArchivioFile
		{
			get { return _IdArchivioFile; }
			set {
				if (IdArchivioFile != value)
				{
					_IdArchivioFile = value;
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
	/// Summary description for RnaLogVisureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaLogVisureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaLogVisureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaLogVisure) info.GetValue(i.ToString(),typeof(RnaLogVisure)));
			}
		}

		//Costruttore
		public RnaLogVisureCollection()
		{
			this.ItemType = typeof(RnaLogVisure);
		}

		//Costruttore con provider
		public RnaLogVisureCollection(IRnaLogVisureProvider providerObj)
		{
			this.ItemType = typeof(RnaLogVisure);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaLogVisure this[int index]
		{
			get { return (RnaLogVisure)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaLogVisureCollection GetChanges()
		{
			return (RnaLogVisureCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaLogVisureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaLogVisureProvider Provider
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
		public int Add(RnaLogVisure RnaLogVisureObj)
		{
			if (RnaLogVisureObj.Provider == null) RnaLogVisureObj.Provider = this.Provider;
			return base.Add(RnaLogVisureObj);
		}

		//AddCollection
		public void AddCollection(RnaLogVisureCollection RnaLogVisureCollectionObj)
		{
			foreach (RnaLogVisure RnaLogVisureObj in RnaLogVisureCollectionObj)
				this.Add(RnaLogVisureObj);
		}

		//Insert
		public void Insert(int index, RnaLogVisure RnaLogVisureObj)
		{
			if (RnaLogVisureObj.Provider == null) RnaLogVisureObj.Provider = this.Provider;
			base.Insert(index, RnaLogVisureObj);
		}

		//CollectionGetById
		public RnaLogVisure CollectionGetById(NullTypes.IntNT IdRnaLogVisuraValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRnaLogVisura == IdRnaLogVisuraValue))
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
		public RnaLogVisureCollection SubSelect(NullTypes.IntNT IdRnaLogVisuraEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.StringNT IdFiscaleImpresaEqualThis, NullTypes.StringNT IdRichiestaEqualThis, NullTypes.StringNT TipoVisuraEqualThis, 
NullTypes.IntNT CodiceEsitoEqualThis, NullTypes.StringNT DescrizioneEsitoEqualThis, NullTypes.DatetimeNT DataRichiestaEqualThis, 
NullTypes.IntNT CodiceStatoRichiestaEqualThis, NullTypes.StringNT DescrizioneStatoRichiestaEqualThis, NullTypes.DatetimeNT DataStatoRichiestaEqualThis, 
NullTypes.IntNT IdOperatoreEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAggiornamentoEqualThis, 
NullTypes.IntNT IdArchivioFileEqualThis)
		{
			RnaLogVisureCollection RnaLogVisureCollectionTemp = new RnaLogVisureCollection();
			foreach (RnaLogVisure RnaLogVisureItem in this)
			{
				if (((IdRnaLogVisuraEqualThis == null) || ((RnaLogVisureItem.IdRnaLogVisura != null) && (RnaLogVisureItem.IdRnaLogVisura.Value == IdRnaLogVisuraEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RnaLogVisureItem.IdProgetto != null) && (RnaLogVisureItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RnaLogVisureItem.IdImpresa != null) && (RnaLogVisureItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdFiscaleImpresaEqualThis == null) || ((RnaLogVisureItem.IdFiscaleImpresa != null) && (RnaLogVisureItem.IdFiscaleImpresa.Value == IdFiscaleImpresaEqualThis.Value))) && ((IdRichiestaEqualThis == null) || ((RnaLogVisureItem.IdRichiesta != null) && (RnaLogVisureItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((TipoVisuraEqualThis == null) || ((RnaLogVisureItem.TipoVisura != null) && (RnaLogVisureItem.TipoVisura.Value == TipoVisuraEqualThis.Value))) && 
((CodiceEsitoEqualThis == null) || ((RnaLogVisureItem.CodiceEsito != null) && (RnaLogVisureItem.CodiceEsito.Value == CodiceEsitoEqualThis.Value))) && ((DescrizioneEsitoEqualThis == null) || ((RnaLogVisureItem.DescrizioneEsito != null) && (RnaLogVisureItem.DescrizioneEsito.Value == DescrizioneEsitoEqualThis.Value))) && ((DataRichiestaEqualThis == null) || ((RnaLogVisureItem.DataRichiesta != null) && (RnaLogVisureItem.DataRichiesta.Value == DataRichiestaEqualThis.Value))) && 
((CodiceStatoRichiestaEqualThis == null) || ((RnaLogVisureItem.CodiceStatoRichiesta != null) && (RnaLogVisureItem.CodiceStatoRichiesta.Value == CodiceStatoRichiestaEqualThis.Value))) && ((DescrizioneStatoRichiestaEqualThis == null) || ((RnaLogVisureItem.DescrizioneStatoRichiesta != null) && (RnaLogVisureItem.DescrizioneStatoRichiesta.Value == DescrizioneStatoRichiestaEqualThis.Value))) && ((DataStatoRichiestaEqualThis == null) || ((RnaLogVisureItem.DataStatoRichiesta != null) && (RnaLogVisureItem.DataStatoRichiesta.Value == DataStatoRichiestaEqualThis.Value))) && 
((IdOperatoreEqualThis == null) || ((RnaLogVisureItem.IdOperatore != null) && (RnaLogVisureItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((RnaLogVisureItem.DataInserimento != null) && (RnaLogVisureItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAggiornamentoEqualThis == null) || ((RnaLogVisureItem.DataAggiornamento != null) && (RnaLogVisureItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && 
((IdArchivioFileEqualThis == null) || ((RnaLogVisureItem.IdArchivioFile != null) && (RnaLogVisureItem.IdArchivioFile.Value == IdArchivioFileEqualThis.Value))))
				{
					RnaLogVisureCollectionTemp.Add(RnaLogVisureItem);
				}
			}
			return RnaLogVisureCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaLogVisureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaLogVisureDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaLogVisure RnaLogVisureObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRnaLogVisura", RnaLogVisureObj.IdRnaLogVisura);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", RnaLogVisureObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", RnaLogVisureObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiscaleImpresa", RnaLogVisureObj.IdFiscaleImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiesta", RnaLogVisureObj.IdRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoVisura", RnaLogVisureObj.TipoVisura);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceEsito", RnaLogVisureObj.CodiceEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneEsito", RnaLogVisureObj.DescrizioneEsito);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRichiesta", RnaLogVisureObj.DataRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceStatoRichiesta", RnaLogVisureObj.CodiceStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneStatoRichiesta", RnaLogVisureObj.DescrizioneStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "DataStatoRichiesta", RnaLogVisureObj.DataStatoRichiesta);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatore", RnaLogVisureObj.IdOperatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", RnaLogVisureObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAggiornamento", RnaLogVisureObj.DataAggiornamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdArchivioFile", RnaLogVisureObj.IdArchivioFile);
		}
		//Insert
		private static int Insert(DbProvider db, RnaLogVisure RnaLogVisureObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaLogVisureInsert", new string[] {"IdProgetto", "IdImpresa", 
"IdFiscaleImpresa", "IdRichiesta", "TipoVisura", 
"CodiceEsito", "DescrizioneEsito", "DataRichiesta", 
"CodiceStatoRichiesta", "DescrizioneStatoRichiesta", "DataStatoRichiesta", 
"IdOperatore", "DataInserimento", "DataAggiornamento", 
"IdArchivioFile"}, new string[] {"int", "int", 
"string", "string", "string", 
"int", "string", "DateTime", 
"int", "string", "DateTime", 
"int", "DateTime", "DateTime", 
"int"},"");
				CompileIUCmd(false, insertCmd,RnaLogVisureObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaLogVisureObj.IdRnaLogVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_VISURA"]);
				RnaLogVisureObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				RnaLogVisureObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
				}
				RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogVisureObj.IsDirty = false;
				RnaLogVisureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaLogVisure RnaLogVisureObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaLogVisureUpdate", new string[] {"IdRnaLogVisura", "IdProgetto", "IdImpresa", 
"IdFiscaleImpresa", "IdRichiesta", "TipoVisura", 
"CodiceEsito", "DescrizioneEsito", "DataRichiesta", 
"CodiceStatoRichiesta", "DescrizioneStatoRichiesta", "DataStatoRichiesta", 
"IdOperatore", "DataInserimento", "DataAggiornamento", 
"IdArchivioFile"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"int", "string", "DateTime", 
"int", "string", "DateTime", 
"int", "DateTime", "DateTime", 
"int"},"");
				CompileIUCmd(true, updateCmd,RnaLogVisureObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogVisureObj.IsDirty = false;
				RnaLogVisureObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaLogVisure RnaLogVisureObj)
		{
			switch (RnaLogVisureObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaLogVisureObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaLogVisureObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaLogVisureObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaLogVisureCollection RnaLogVisureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaLogVisureUpdate", new string[] {"IdRnaLogVisura", "IdProgetto", "IdImpresa", 
"IdFiscaleImpresa", "IdRichiesta", "TipoVisura", 
"CodiceEsito", "DescrizioneEsito", "DataRichiesta", 
"CodiceStatoRichiesta", "DescrizioneStatoRichiesta", "DataStatoRichiesta", 
"IdOperatore", "DataInserimento", "DataAggiornamento", 
"IdArchivioFile"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"int", "string", "DateTime", 
"int", "string", "DateTime", 
"int", "DateTime", "DateTime", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaLogVisureInsert", new string[] {"IdProgetto", "IdImpresa", 
"IdFiscaleImpresa", "IdRichiesta", "TipoVisura", 
"CodiceEsito", "DescrizioneEsito", "DataRichiesta", 
"CodiceStatoRichiesta", "DescrizioneStatoRichiesta", "DataStatoRichiesta", 
"IdOperatore", "DataInserimento", "DataAggiornamento", 
"IdArchivioFile"}, new string[] {"int", "int", 
"string", "string", "string", 
"int", "string", "DateTime", 
"int", "string", "DateTime", 
"int", "DateTime", "DateTime", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogVisureDelete", new string[] {"IdRnaLogVisura"}, new string[] {"int"},"");
				for (int i = 0; i < RnaLogVisureCollectionObj.Count; i++)
				{
					switch (RnaLogVisureCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaLogVisureCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaLogVisureCollectionObj[i].IdRnaLogVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_VISURA"]);
									RnaLogVisureCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									RnaLogVisureCollectionObj[i].DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaLogVisureCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaLogVisureCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogVisura", (SiarLibrary.NullTypes.IntNT)RnaLogVisureCollectionObj[i].IdRnaLogVisura);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaLogVisureCollectionObj.Count; i++)
				{
					if ((RnaLogVisureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaLogVisureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaLogVisureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaLogVisureCollectionObj[i].IsDirty = false;
						RnaLogVisureCollectionObj[i].IsPersistent = true;
					}
					if ((RnaLogVisureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaLogVisureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaLogVisureCollectionObj[i].IsDirty = false;
						RnaLogVisureCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaLogVisure RnaLogVisureObj)
		{
			int returnValue = 0;
			if (RnaLogVisureObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaLogVisureObj.IdRnaLogVisura);
			}
			RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaLogVisureObj.IsDirty = false;
			RnaLogVisureObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRnaLogVisuraValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogVisureDelete", new string[] {"IdRnaLogVisura"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogVisura", (SiarLibrary.NullTypes.IntNT)IdRnaLogVisuraValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaLogVisureCollection RnaLogVisureCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaLogVisureDelete", new string[] {"IdRnaLogVisura"}, new string[] {"int"},"");
				for (int i = 0; i < RnaLogVisureCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRnaLogVisura", RnaLogVisureCollectionObj[i].IdRnaLogVisura);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaLogVisureCollectionObj.Count; i++)
				{
					if ((RnaLogVisureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaLogVisureCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaLogVisureCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaLogVisureCollectionObj[i].IsDirty = false;
						RnaLogVisureCollectionObj[i].IsPersistent = false;
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
		public static RnaLogVisure GetById(DbProvider db, int IdRnaLogVisuraValue)
		{
			RnaLogVisure RnaLogVisureObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaLogVisureGetById", new string[] {"IdRnaLogVisura"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRnaLogVisura", (SiarLibrary.NullTypes.IntNT)IdRnaLogVisuraValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaLogVisureObj = GetFromDatareader(db);
				RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogVisureObj.IsDirty = false;
				RnaLogVisureObj.IsPersistent = true;
			}
			db.Close();
			return RnaLogVisureObj;
		}

		//getFromDatareader
		public static RnaLogVisure GetFromDatareader(DbProvider db)
		{
			RnaLogVisure RnaLogVisureObj = new RnaLogVisure();
			RnaLogVisureObj.IdRnaLogVisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_LOG_VISURA"]);
			RnaLogVisureObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			RnaLogVisureObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			RnaLogVisureObj.IdFiscaleImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FISCALE_IMPRESA"]);
			RnaLogVisureObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			RnaLogVisureObj.TipoVisura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VISURA"]);
			RnaLogVisureObj.CodiceEsito = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO"]);
			RnaLogVisureObj.DescrizioneEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO"]);
			RnaLogVisureObj.DataRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA"]);
			RnaLogVisureObj.CodiceStatoRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_STATO_RICHIESTA"]);
			RnaLogVisureObj.DescrizioneStatoRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_STATO_RICHIESTA"]);
			RnaLogVisureObj.DataStatoRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_STATO_RICHIESTA"]);
			RnaLogVisureObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			RnaLogVisureObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			RnaLogVisureObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			RnaLogVisureObj.IdArchivioFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ARCHIVIO_FILE"]);
			RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaLogVisureObj.IsDirty = false;
			RnaLogVisureObj.IsPersistent = true;
			return RnaLogVisureObj;
		}

		//Find Select

		public static RnaLogVisureCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaLogVisuraEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT IdFiscaleImpresaEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT TipoVisuraEqualThis, 
SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRichiestaEqualThis, 
SiarLibrary.NullTypes.IntNT CodiceStatoRichiestaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneStatoRichiestaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataStatoRichiestaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, 
SiarLibrary.NullTypes.IntNT IdArchivioFileEqualThis)

		{

			RnaLogVisureCollection RnaLogVisureCollectionObj = new RnaLogVisureCollection();

			IDbCommand findCmd = db.InitCmd("Zrnalogvisurefindselect", new string[] {"IdRnaLogVisuraequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdFiscaleImpresaequalthis", "IdRichiestaequalthis", "TipoVisuraequalthis", 
"CodiceEsitoequalthis", "DescrizioneEsitoequalthis", "DataRichiestaequalthis", 
"CodiceStatoRichiestaequalthis", "DescrizioneStatoRichiestaequalthis", "DataStatoRichiestaequalthis", 
"IdOperatoreequalthis", "DataInserimentoequalthis", "DataAggiornamentoequalthis", 
"IdArchivioFileequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"int", "string", "DateTime", 
"int", "string", "DateTime", 
"int", "DateTime", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaLogVisuraequalthis", IdRnaLogVisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiscaleImpresaequalthis", IdFiscaleImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoVisuraequalthis", TipoVisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRichiestaequalthis", DataRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceStatoRichiestaequalthis", CodiceStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneStatoRichiestaequalthis", DescrizioneStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataStatoRichiestaequalthis", DataStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdArchivioFileequalthis", IdArchivioFileEqualThis);
			RnaLogVisure RnaLogVisureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaLogVisureObj = GetFromDatareader(db);
				RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogVisureObj.IsDirty = false;
				RnaLogVisureObj.IsPersistent = true;
				RnaLogVisureCollectionObj.Add(RnaLogVisureObj);
			}
			db.Close();
			return RnaLogVisureCollectionObj;
		}

		//Find Find

		public static RnaLogVisureCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaLogVisuraEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT TipoVisuraEqualThis, SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneStatoRichiestaEqualThis, SiarLibrary.NullTypes.IntNT CodiceStatoRichiestaEqualThis)

		{

			RnaLogVisureCollection RnaLogVisureCollectionObj = new RnaLogVisureCollection();

			IDbCommand findCmd = db.InitCmd("Zrnalogvisurefindfind", new string[] {"IdRnaLogVisuraequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdRichiestaequalthis", "TipoVisuraequalthis", "CodiceEsitoequalthis", 
"DescrizioneEsitoequalthis", "DescrizioneStatoRichiestaequalthis", "CodiceStatoRichiestaequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "int", 
"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaLogVisuraequalthis", IdRnaLogVisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoVisuraequalthis", TipoVisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneStatoRichiestaequalthis", DescrizioneStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceStatoRichiestaequalthis", CodiceStatoRichiestaEqualThis);
			RnaLogVisure RnaLogVisureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaLogVisureObj = GetFromDatareader(db);
				RnaLogVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaLogVisureObj.IsDirty = false;
				RnaLogVisureObj.IsPersistent = true;
				RnaLogVisureCollectionObj.Add(RnaLogVisureObj);
			}
			db.Close();
			return RnaLogVisureCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaLogVisureCollectionProvider:IRnaLogVisureProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaLogVisureCollectionProvider : IRnaLogVisureProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaLogVisure
		protected RnaLogVisureCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaLogVisureCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaLogVisureCollection(this);
		}

		//Costruttore 2: popola la collection
		public RnaLogVisureCollectionProvider(IntNT IdrnalogvisuraEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis, IntNT CodiceesitoEqualThis, 
StringNT DescrizioneesitoEqualThis, StringNT DescrizionestatorichiestaEqualThis, IntNT CodicestatorichiestaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrnalogvisuraEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis, TipovisuraEqualThis, CodiceesitoEqualThis, 
DescrizioneesitoEqualThis, DescrizionestatorichiestaEqualThis, CodicestatorichiestaEqualThis);
		}

		//Costruttore3: ha in input rnalogvisureCollectionObj - non popola la collection
		public RnaLogVisureCollectionProvider(RnaLogVisureCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaLogVisureCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaLogVisureCollection(this);
		}

		//Get e Set
		public RnaLogVisureCollection CollectionObj
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
		public int SaveCollection(RnaLogVisureCollection collectionObj)
		{
			return RnaLogVisureDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaLogVisure rnalogvisureObj)
		{
			return RnaLogVisureDAL.Save(_dbProviderObj, rnalogvisureObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaLogVisureCollection collectionObj)
		{
			return RnaLogVisureDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaLogVisure rnalogvisureObj)
		{
			return RnaLogVisureDAL.Delete(_dbProviderObj, rnalogvisureObj);
		}

		//getById
		public RnaLogVisure GetById(IntNT IdRnaLogVisuraValue)
		{
			RnaLogVisure RnaLogVisureTemp = RnaLogVisureDAL.GetById(_dbProviderObj, IdRnaLogVisuraValue);
			if (RnaLogVisureTemp!=null) RnaLogVisureTemp.Provider = this;
			return RnaLogVisureTemp;
		}

		//Select: popola la collection
		public RnaLogVisureCollection Select(IntNT IdrnalogvisuraEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdfiscaleimpresaEqualThis, StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis, 
IntNT CodiceesitoEqualThis, StringNT DescrizioneesitoEqualThis, DatetimeNT DatarichiestaEqualThis, 
IntNT CodicestatorichiestaEqualThis, StringNT DescrizionestatorichiestaEqualThis, DatetimeNT DatastatorichiestaEqualThis, 
IntNT IdoperatoreEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaggiornamentoEqualThis, 
IntNT IdarchiviofileEqualThis)
		{
			RnaLogVisureCollection RnaLogVisureCollectionTemp = RnaLogVisureDAL.Select(_dbProviderObj, IdrnalogvisuraEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdfiscaleimpresaEqualThis, IdrichiestaEqualThis, TipovisuraEqualThis, 
CodiceesitoEqualThis, DescrizioneesitoEqualThis, DatarichiestaEqualThis, 
CodicestatorichiestaEqualThis, DescrizionestatorichiestaEqualThis, DatastatorichiestaEqualThis, 
IdoperatoreEqualThis, DatainserimentoEqualThis, DataaggiornamentoEqualThis, 
IdarchiviofileEqualThis);
			RnaLogVisureCollectionTemp.Provider = this;
			return RnaLogVisureCollectionTemp;
		}

		//Find: popola la collection
		public RnaLogVisureCollection Find(IntNT IdrnalogvisuraEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis, IntNT CodiceesitoEqualThis, 
StringNT DescrizioneesitoEqualThis, StringNT DescrizionestatorichiestaEqualThis, IntNT CodicestatorichiestaEqualThis)
		{
			RnaLogVisureCollection RnaLogVisureCollectionTemp = RnaLogVisureDAL.Find(_dbProviderObj, IdrnalogvisuraEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis, TipovisuraEqualThis, CodiceesitoEqualThis, 
DescrizioneesitoEqualThis, DescrizionestatorichiestaEqualThis, CodicestatorichiestaEqualThis);
			RnaLogVisureCollectionTemp.Provider = this;
			return RnaLogVisureCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_LOG_VISURE>
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
      <ID_RNA_LOG_VISURA>Equal</ID_RNA_LOG_VISURA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_RICHIESTA>Equal</ID_RICHIESTA>
      <TIPO_VISURA>Equal</TIPO_VISURA>
      <CODICE_ESITO>Equal</CODICE_ESITO>
      <DESCRIZIONE_ESITO>Equal</DESCRIZIONE_ESITO>
      <DESCRIZIONE_STATO_RICHIESTA>Equal</DESCRIZIONE_STATO_RICHIESTA>
      <CODICE_STATO_RICHIESTA>Equal</CODICE_STATO_RICHIESTA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_LOG_VISURE>
*/
