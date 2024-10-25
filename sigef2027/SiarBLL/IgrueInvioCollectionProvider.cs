using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per IgrueInvio
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIgrueInvioProvider
	{
		int Save(IgrueInvio IgrueInvioObj);
		int SaveCollection(IgrueInvioCollection collectionObj);
		int Delete(IgrueInvio IgrueInvioObj);
		int DeleteCollection(IgrueInvioCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IgrueInvio
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class IgrueInvio : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdInvio;
		private NullTypes.StringNT _IdTicket;
		private NullTypes.DatetimeNT _DataInvio;
		private NullTypes.DatetimeNT _DataDa;
		private NullTypes.DatetimeNT _DataA;
		private byte[] _FileInvio;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.IntNT _CodiceEsito;
		private NullTypes.StringNT _DescrizioneEsito;
		private NullTypes.StringNT _DettaglioEsito;
		private NullTypes.DatetimeNT _TimestampEsito;
		private NullTypes.StringNT _TipoFile;
		private NullTypes.StringNT _CodiceFondo;
		private NullTypes.IntNT _IdIgrueLogErrori;
		private NullTypes.DatetimeNT _DataRichiesta;
		private byte[] _FileErrori;
		private NullTypes.StringNT _IstanzaErrori;
		private NullTypes.IntNT _IdOperatoreLog;
		private NullTypes.IntNT _CodiceEsitoLog;
		private NullTypes.StringNT _DescrizioneEsitoLog;
		private NullTypes.StringNT _DettaglioEsitoLog;
		private NullTypes.DatetimeNT _TimestampEsitoLog;
		private NullTypes.StringNT _TipoFileLog;
		private NullTypes.StringNT _CodiceFondoErrore;
		[NonSerialized] private IIgrueInvioProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IIgrueInvioProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public IgrueInvio()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_INVIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvio
		{
			get { return _IdInvio; }
			set
			{
				if (IdInvio != value)
				{
					_IdInvio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TICKET
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT IdTicket
		{
			get { return _IdTicket; }
			set
			{
				if (IdTicket != value)
				{
					_IdTicket = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INVIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInvio
		{
			get { return _DataInvio; }
			set
			{
				if (DataInvio != value)
				{
					_DataInvio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DA
		/// Tipo sul db:DATE
		/// </summary>
		public NullTypes.DatetimeNT DataDa
		{
			get { return _DataDa; }
			set
			{
				if (DataDa != value)
				{
					_DataDa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_A
		/// Tipo sul db:DATE
		/// </summary>
		public NullTypes.DatetimeNT DataA
		{
			get { return _DataA; }
			set
			{
				if (DataA != value)
				{
					_DataA = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FILE_INVIO
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] FileInvio
		{
			get { return _FileInvio; }
			set
			{
				if (FileInvio != value)
				{
					_FileInvio = value;
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
			set
			{
				if (IdOperatore != value)
				{
					_IdOperatore = value;
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
			set
			{
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
			set
			{
				if (DescrizioneEsito != value)
				{
					_DescrizioneEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DETTAGLIO_ESITO
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DettaglioEsito
		{
			get { return _DettaglioEsito; }
			set
			{
				if (DettaglioEsito != value)
				{
					_DettaglioEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIMESTAMP_ESITO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT TimestampEsito
		{
			get { return _TimestampEsito; }
			set
			{
				if (TimestampEsito != value)
				{
					_TimestampEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_FILE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT TipoFile
		{
			get { return _TipoFile; }
			set
			{
				if (TipoFile != value)
				{
					_TipoFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FONDO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodiceFondo
		{
			get { return _CodiceFondo; }
			set
			{
				if (CodiceFondo != value)
				{
					_CodiceFondo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IGRUE_LOG_ERRORI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIgrueLogErrori
		{
			get { return _IdIgrueLogErrori; }
			set
			{
				if (IdIgrueLogErrori != value)
				{
					_IdIgrueLogErrori = value;
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
			set
			{
				if (DataRichiesta != value)
				{
					_DataRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FILE_ERRORI
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] FileErrori
		{
			get { return _FileErrori; }
			set
			{
				if (FileErrori != value)
				{
					_FileErrori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_ERRORI
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaErrori
		{
			get { return _IstanzaErrori; }
			set
			{
				if (IstanzaErrori != value)
				{
					_IstanzaErrori = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_LOG
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreLog
		{
			get { return _IdOperatoreLog; }
			set
			{
				if (IdOperatoreLog != value)
				{
					_IdOperatoreLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_ESITO_LOG
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceEsitoLog
		{
			get { return _CodiceEsitoLog; }
			set
			{
				if (CodiceEsitoLog != value)
				{
					_CodiceEsitoLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ESITO_LOG
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneEsitoLog
		{
			get { return _DescrizioneEsitoLog; }
			set
			{
				if (DescrizioneEsitoLog != value)
				{
					_DescrizioneEsitoLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DETTAGLIO_ESITO_LOG
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DettaglioEsitoLog
		{
			get { return _DettaglioEsitoLog; }
			set
			{
				if (DettaglioEsitoLog != value)
				{
					_DettaglioEsitoLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIMESTAMP_ESITO_LOG
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT TimestampEsitoLog
		{
			get { return _TimestampEsitoLog; }
			set
			{
				if (TimestampEsitoLog != value)
				{
					_TimestampEsitoLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_FILE_LOG
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT TipoFileLog
		{
			get { return _TipoFileLog; }
			set
			{
				if (TipoFileLog != value)
				{
					_TipoFileLog = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FONDO_ERRORE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodiceFondoErrore
		{
			get { return _CodiceFondoErrore; }
			set
			{
				if (CodiceFondoErrore != value)
				{
					_CodiceFondoErrore = value;
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
	/// Summary description for IgrueInvioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IgrueInvioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count", this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				info.AddValue(i.ToString(), this[i]);
			}
		}
		private IgrueInvioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((IgrueInvio)info.GetValue(i.ToString(), typeof(IgrueInvio)));
			}
		}

		//Costruttore
		public IgrueInvioCollection()
		{
			this.ItemType = typeof(IgrueInvio);
		}

		//Costruttore con provider
		public IgrueInvioCollection(IIgrueInvioProvider providerObj)
		{
			this.ItemType = typeof(IgrueInvio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IgrueInvio this[int index]
		{
			get { return (IgrueInvio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IgrueInvioCollection GetChanges()
		{
			return (IgrueInvioCollection)base.GetChanges();
		}

		[NonSerialized] private IIgrueInvioProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IIgrueInvioProvider Provider
		{
			get { return _provider; }
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
		public int Add(IgrueInvio IgrueInvioObj)
		{
			if (IgrueInvioObj.Provider == null) IgrueInvioObj.Provider = this.Provider;
			return base.Add(IgrueInvioObj);
		}

		//AddCollection
		public void AddCollection(IgrueInvioCollection IgrueInvioCollectionObj)
		{
			foreach (IgrueInvio IgrueInvioObj in IgrueInvioCollectionObj)
				this.Add(IgrueInvioObj);
		}

		//Insert
		public void Insert(int index, IgrueInvio IgrueInvioObj)
		{
			if (IgrueInvioObj.Provider == null) IgrueInvioObj.Provider = this.Provider;
			base.Insert(index, IgrueInvioObj);
		}

		//CollectionGetById
		public IgrueInvio CollectionGetById(NullTypes.IntNT IdInvioValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdInvio == IdInvioValue))
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
		public IgrueInvioCollection SubSelect(NullTypes.IntNT IdInvioEqualThis, NullTypes.StringNT IdTicketEqualThis, NullTypes.DatetimeNT DataInvioEqualThis,
NullTypes.DatetimeNT DataDaEqualThis, NullTypes.DatetimeNT DataAEqualThis, NullTypes.IntNT IdOperatoreEqualThis,
NullTypes.IntNT CodiceEsitoEqualThis, NullTypes.StringNT DescrizioneEsitoEqualThis, NullTypes.StringNT DettaglioEsitoEqualThis,
NullTypes.DatetimeNT TimestampEsitoEqualThis, NullTypes.StringNT TipoFileEqualThis, NullTypes.StringNT CodiceFondoEqualThis)
		{
			IgrueInvioCollection IgrueInvioCollectionTemp = new IgrueInvioCollection();
			foreach (IgrueInvio IgrueInvioItem in this)
			{
				if (((IdInvioEqualThis == null) || ((IgrueInvioItem.IdInvio != null) && (IgrueInvioItem.IdInvio.Value == IdInvioEqualThis.Value))) && ((IdTicketEqualThis == null) || ((IgrueInvioItem.IdTicket != null) && (IgrueInvioItem.IdTicket.Value == IdTicketEqualThis.Value))) && ((DataInvioEqualThis == null) || ((IgrueInvioItem.DataInvio != null) && (IgrueInvioItem.DataInvio.Value == DataInvioEqualThis.Value))) &&
((DataDaEqualThis == null) || ((IgrueInvioItem.DataDa != null) && (IgrueInvioItem.DataDa.Value == DataDaEqualThis.Value))) && ((DataAEqualThis == null) || ((IgrueInvioItem.DataA != null) && (IgrueInvioItem.DataA.Value == DataAEqualThis.Value))) && ((IdOperatoreEqualThis == null) || ((IgrueInvioItem.IdOperatore != null) && (IgrueInvioItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) &&
((CodiceEsitoEqualThis == null) || ((IgrueInvioItem.CodiceEsito != null) && (IgrueInvioItem.CodiceEsito.Value == CodiceEsitoEqualThis.Value))) && ((DescrizioneEsitoEqualThis == null) || ((IgrueInvioItem.DescrizioneEsito != null) && (IgrueInvioItem.DescrizioneEsito.Value == DescrizioneEsitoEqualThis.Value))) && ((DettaglioEsitoEqualThis == null) || ((IgrueInvioItem.DettaglioEsito != null) && (IgrueInvioItem.DettaglioEsito.Value == DettaglioEsitoEqualThis.Value))) &&
((TimestampEsitoEqualThis == null) || ((IgrueInvioItem.TimestampEsito != null) && (IgrueInvioItem.TimestampEsito.Value == TimestampEsitoEqualThis.Value))) && ((TipoFileEqualThis == null) || ((IgrueInvioItem.TipoFile != null) && (IgrueInvioItem.TipoFile.Value == TipoFileEqualThis.Value))) && ((CodiceFondoEqualThis == null) || ((IgrueInvioItem.CodiceFondo != null) && (IgrueInvioItem.CodiceFondo.Value == CodiceFondoEqualThis.Value))))
				{
					IgrueInvioCollectionTemp.Add(IgrueInvioItem);
				}
			}
			return IgrueInvioCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IgrueInvioDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IgrueInvioDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IgrueInvio IgrueInvioObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdInvio", IgrueInvioObj.IdInvio);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdTicket", IgrueInvioObj.IdTicket);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInvio", IgrueInvioObj.DataInvio);
			DbProvider.SetCmdParam(cmd, firstChar + "DataDa", IgrueInvioObj.DataDa);
			DbProvider.SetCmdParam(cmd, firstChar + "DataA", IgrueInvioObj.DataA);
			DbProvider.SetCmdParam(cmd, firstChar + "FileInvio", IgrueInvioObj.FileInvio);
			DbProvider.SetCmdParam(cmd, firstChar + "IdOperatore", IgrueInvioObj.IdOperatore);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceEsito", IgrueInvioObj.CodiceEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "DescrizioneEsito", IgrueInvioObj.DescrizioneEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "DettaglioEsito", IgrueInvioObj.DettaglioEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "TimestampEsito", IgrueInvioObj.TimestampEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoFile", IgrueInvioObj.TipoFile);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceFondo", IgrueInvioObj.CodiceFondo);
		}
		//Insert
		private static int Insert(DbProvider db, IgrueInvio IgrueInvioObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZIgrueInvioInsert", new string[] {"IdTicket", "DataInvio",
"DataDa", "DataA", "FileInvio",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo",

}, new string[] {"string", "DateTime",
"dateNotSupportedError", "dateNotSupportedError", "byte[]",
"int", "int", "string",
"string", "DateTime", "string",
"string",

}, "");
				CompileIUCmd(false, insertCmd, IgrueInvioObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					IgrueInvioObj.IdInvio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVIO"]);
				}
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IgrueInvio IgrueInvioObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZIgrueInvioUpdate", new string[] {"IdInvio", "IdTicket", "DataInvio",
"DataDa", "DataA", "FileInvio",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo",

}, new string[] {"int", "string", "DateTime",
"dateNotSupportedError", "dateNotSupportedError", "byte[]",
"int", "int", "string",
"string", "DateTime", "string",
"string",

}, "");
				CompileIUCmd(true, updateCmd, IgrueInvioObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IgrueInvio IgrueInvioObj)
		{
			switch (IgrueInvioObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, IgrueInvioObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, IgrueInvioObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, IgrueInvioObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IgrueInvioCollection IgrueInvioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZIgrueInvioUpdate", new string[] {"IdInvio", "IdTicket", "DataInvio",
"DataDa", "DataA", "FileInvio",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo",

}, new string[] {"int", "string", "DateTime",
"dateNotSupportedError", "dateNotSupportedError", "byte[]",
"int", "int", "string",
"string", "DateTime", "string",
"string",

}, "");
				IDbCommand insertCmd = db.InitCmd("ZIgrueInvioInsert", new string[] {"IdTicket", "DataInvio",
"DataDa", "DataA", "FileInvio",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo",

}, new string[] {"string", "DateTime",
"dateNotSupportedError", "dateNotSupportedError", "byte[]",
"int", "int", "string",
"string", "DateTime", "string",
"string",

}, "");
				IDbCommand deleteCmd = db.InitCmd("ZIgrueInvioDelete", new string[] { "IdInvio" }, new string[] { "int" }, "");
				for (int i = 0; i < IgrueInvioCollectionObj.Count; i++)
				{
					switch (IgrueInvioCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, IgrueInvioCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IgrueInvioCollectionObj[i].IdInvio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, IgrueInvioCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (IgrueInvioCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvio", (SiarLibrary.NullTypes.IntNT)IgrueInvioCollectionObj[i].IdInvio);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IgrueInvioCollectionObj.Count; i++)
				{
					if ((IgrueInvioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IgrueInvioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IgrueInvioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IgrueInvioCollectionObj[i].IsDirty = false;
						IgrueInvioCollectionObj[i].IsPersistent = true;
					}
					if ((IgrueInvioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IgrueInvioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IgrueInvioCollectionObj[i].IsDirty = false;
						IgrueInvioCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IgrueInvio IgrueInvioObj)
		{
			int returnValue = 0;
			if (IgrueInvioObj.IsPersistent)
			{
				returnValue = Delete(db, IgrueInvioObj.IdInvio);
			}
			IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IgrueInvioObj.IsDirty = false;
			IgrueInvioObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdInvioValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZIgrueInvioDelete", new string[] { "IdInvio" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvio", (SiarLibrary.NullTypes.IntNT)IdInvioValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IgrueInvioCollection IgrueInvioCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZIgrueInvioDelete", new string[] { "IdInvio" }, new string[] { "int" }, "");
				for (int i = 0; i < IgrueInvioCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvio", IgrueInvioCollectionObj[i].IdInvio);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IgrueInvioCollectionObj.Count; i++)
				{
					if ((IgrueInvioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IgrueInvioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IgrueInvioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IgrueInvioCollectionObj[i].IsDirty = false;
						IgrueInvioCollectionObj[i].IsPersistent = false;
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
		public static IgrueInvio GetById(DbProvider db, int IdInvioValue)
		{
			IgrueInvio IgrueInvioObj = null;
			IDbCommand readCmd = db.InitCmd("ZIgrueInvioGetById", new string[] { "IdInvio" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdInvio", (SiarLibrary.NullTypes.IntNT)IdInvioValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IgrueInvioObj = GetFromDatareader(db);
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
			}
			db.Close();
			return IgrueInvioObj;
		}

		//getFromDatareader
		public static IgrueInvio GetFromDatareader(DbProvider db)
		{
			IgrueInvio IgrueInvioObj = new IgrueInvio();
			IgrueInvioObj.IdInvio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVIO"]);
			IgrueInvioObj.IdTicket = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_TICKET"]);
			IgrueInvioObj.DataInvio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INVIO"]);
			IgrueInvioObj.DataDa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DA"]);
			IgrueInvioObj.DataA = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_A"]);
			IgrueInvioObj.FileInvio = Convert.IsDBNull(db.DataReader["FILE_INVIO"]) ? null : (byte[])db.DataReader["FILE_INVIO"];
			IgrueInvioObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			IgrueInvioObj.CodiceEsito = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO"]);
			IgrueInvioObj.DescrizioneEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO"]);
			IgrueInvioObj.DettaglioEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_ESITO"]);
			IgrueInvioObj.TimestampEsito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["TIMESTAMP_ESITO"]);
			IgrueInvioObj.TipoFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_FILE"]);
			IgrueInvioObj.CodiceFondo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FONDO"]);
			IgrueInvioObj.IdIgrueLogErrori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IGRUE_LOG_ERRORI"]);
			IgrueInvioObj.DataRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA"]);
			IgrueInvioObj.FileErrori = Convert.IsDBNull(db.DataReader["FILE_ERRORI"]) ? null : (byte[])db.DataReader["FILE_ERRORI"];
			IgrueInvioObj.IstanzaErrori = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_ERRORI"]);
			IgrueInvioObj.IdOperatoreLog = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_LOG"]);
			IgrueInvioObj.CodiceEsitoLog = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO_LOG"]);
			IgrueInvioObj.DescrizioneEsitoLog = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO_LOG"]);
			IgrueInvioObj.DettaglioEsitoLog = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_ESITO_LOG"]);
			IgrueInvioObj.TimestampEsitoLog = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["TIMESTAMP_ESITO_LOG"]);
			IgrueInvioObj.TipoFileLog = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_FILE_LOG"]);
			IgrueInvioObj.CodiceFondoErrore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FONDO_ERRORE"]);
			IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IgrueInvioObj.IsDirty = false;
			IgrueInvioObj.IsPersistent = true;
			return IgrueInvioObj;
		}

		//Find Select

		public static IgrueInvioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvioEqualThis, SiarLibrary.NullTypes.StringNT IdTicketEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInvioEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataDaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis,
SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, SiarLibrary.NullTypes.StringNT DettaglioEsitoEqualThis,
SiarLibrary.NullTypes.DatetimeNT TimestampEsitoEqualThis, SiarLibrary.NullTypes.StringNT TipoFileEqualThis, SiarLibrary.NullTypes.StringNT CodiceFondoEqualThis)

		{

			IgrueInvioCollection IgrueInvioCollectionObj = new IgrueInvioCollection();

			IDbCommand findCmd = db.InitCmd("Zigrueinviofindselect", new string[] {"IdInvioequalthis", "IdTicketequalthis", "DataInvioequalthis",
"DataDaequalthis", "DataAequalthis", "IdOperatoreequalthis",
"CodiceEsitoequalthis", "DescrizioneEsitoequalthis", "DettaglioEsitoequalthis",
"TimestampEsitoequalthis", "TipoFileequalthis", "CodiceFondoequalthis"}, new string[] {"int", "string", "DateTime",
"dateNotSupportedError", "dateNotSupportedError", "int",
"int", "string", "string",
"DateTime", "string", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvioequalthis", IdInvioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInvioequalthis", DataInvioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDaequalthis", DataDaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAequalthis", DataAEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DettaglioEsitoequalthis", DettaglioEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TimestampEsitoequalthis", TimestampEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoFileequalthis", TipoFileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFondoequalthis", CodiceFondoEqualThis);
			IgrueInvio IgrueInvioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueInvioObj = GetFromDatareader(db);
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
				IgrueInvioCollectionObj.Add(IgrueInvioObj);
			}
			db.Close();
			return IgrueInvioCollectionObj;
		}

		//Find GetByIdInvio

		public static IgrueInvioCollection GetByIdInvio(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvioEqualThis)

		{

			IgrueInvioCollection IgrueInvioCollectionObj = new IgrueInvioCollection();

			IDbCommand findCmd = db.InitCmd("Zigrueinviofindgetbyidinvio", new string[] { "IdInvioequalthis" }, new string[] { "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvioequalthis", IdInvioEqualThis);
			IgrueInvio IgrueInvioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueInvioObj = GetFromDatareader(db);
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
				IgrueInvioCollectionObj.Add(IgrueInvioObj);
			}
			db.Close();
			return IgrueInvioCollectionObj;
		}

		//Find GetDataInvioDaA

		public static IgrueInvioCollection GetDataInvioDaA(DbProvider db, SiarLibrary.NullTypes.DatetimeNT DataInvioEqGreaterThanThis, SiarLibrary.NullTypes.DatetimeNT DataInvioEqLessThanThis, SiarLibrary.NullTypes.StringNT CodiceFondoEqualThis)

		{

			IgrueInvioCollection IgrueInvioCollectionObj = new IgrueInvioCollection();

			IDbCommand findCmd = db.InitCmd("Zigrueinviofindgetdatainviodaa", new string[] { "DataInvioeqgreaterthanthis", "DataInvioeqlessthanthis", "CodiceFondoequalthis" }, new string[] { "DateTime", "DateTime", "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInvioeqgreaterthanthis", DataInvioEqGreaterThanThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInvioeqlessthanthis", DataInvioEqLessThanThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFondoequalthis", CodiceFondoEqualThis);
			IgrueInvio IgrueInvioObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueInvioObj = GetFromDatareader(db);
				IgrueInvioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueInvioObj.IsDirty = false;
				IgrueInvioObj.IsPersistent = true;
				IgrueInvioCollectionObj.Add(IgrueInvioObj);
			}
			db.Close();
			return IgrueInvioCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IgrueInvioCollectionProvider:IIgrueInvioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IgrueInvioCollectionProvider : IIgrueInvioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IgrueInvio
		protected IgrueInvioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IgrueInvioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IgrueInvioCollection(this);
		}

		//Costruttore 2: popola la collection
		public IgrueInvioCollectionProvider(IntNT IdinvioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = GetByIdInvio(IdinvioEqualThis);
		}

		//Costruttore3: ha in input igrueinvioCollectionObj - non popola la collection
		public IgrueInvioCollectionProvider(IgrueInvioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IgrueInvioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IgrueInvioCollection(this);
		}

		//Get e Set
		public IgrueInvioCollection CollectionObj
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
		public int SaveCollection(IgrueInvioCollection collectionObj)
		{
			return IgrueInvioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IgrueInvio igrueinvioObj)
		{
			return IgrueInvioDAL.Save(_dbProviderObj, igrueinvioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IgrueInvioCollection collectionObj)
		{
			return IgrueInvioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IgrueInvio igrueinvioObj)
		{
			return IgrueInvioDAL.Delete(_dbProviderObj, igrueinvioObj);
		}

		//getById
		public IgrueInvio GetById(IntNT IdInvioValue)
		{
			IgrueInvio IgrueInvioTemp = IgrueInvioDAL.GetById(_dbProviderObj, IdInvioValue);
			if (IgrueInvioTemp != null) IgrueInvioTemp.Provider = this;
			return IgrueInvioTemp;
		}

		//Select: popola la collection
		public IgrueInvioCollection Select(IntNT IdinvioEqualThis, StringNT IdticketEqualThis, DatetimeNT DatainvioEqualThis,
DatetimeNT DatadaEqualThis, DatetimeNT DataaEqualThis, IntNT IdoperatoreEqualThis,
IntNT CodiceesitoEqualThis, StringNT DescrizioneesitoEqualThis, StringNT DettaglioesitoEqualThis,
DatetimeNT TimestampesitoEqualThis, StringNT TipofileEqualThis, StringNT CodicefondoEqualThis)
		{
			IgrueInvioCollection IgrueInvioCollectionTemp = IgrueInvioDAL.Select(_dbProviderObj, IdinvioEqualThis, IdticketEqualThis, DatainvioEqualThis,
DatadaEqualThis, DataaEqualThis, IdoperatoreEqualThis,
CodiceesitoEqualThis, DescrizioneesitoEqualThis, DettaglioesitoEqualThis,
TimestampesitoEqualThis, TipofileEqualThis, CodicefondoEqualThis);
			IgrueInvioCollectionTemp.Provider = this;
			return IgrueInvioCollectionTemp;
		}

		//GetByIdInvio: popola la collection
		public IgrueInvioCollection GetByIdInvio(IntNT IdinvioEqualThis)
		{
			IgrueInvioCollection IgrueInvioCollectionTemp = IgrueInvioDAL.GetByIdInvio(_dbProviderObj, IdinvioEqualThis);
			IgrueInvioCollectionTemp.Provider = this;
			return IgrueInvioCollectionTemp;
		}

		//GetDataInvioDaA: popola la collection
		public IgrueInvioCollection GetDataInvioDaA(DatetimeNT DatainvioEqGreaterThanThis, DatetimeNT DatainvioEqLessThanThis, StringNT CodicefondoEqualThis)
		{
			IgrueInvioCollection IgrueInvioCollectionTemp = IgrueInvioDAL.GetDataInvioDaA(_dbProviderObj, DatainvioEqGreaterThanThis, DatainvioEqLessThanThis, CodicefondoEqualThis);
			IgrueInvioCollectionTemp.Provider = this;
			return IgrueInvioCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IGRUE_INVIO>
  <ViewName>VIGRUE_INVIO</ViewName>
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
    <GetByIdInvio OrderBy="ORDER BY ">
      <ID_INVIO>Equal</ID_INVIO>
    </GetByIdInvio>
    <GetDataInvioDaA OrderBy="ORDER BY DATA_INVIO DESC">
      <DATA_INVIO>EqGreaterThan</DATA_INVIO>
      <DATA_INVIO>EqLessThan</DATA_INVIO>
      <CODICE_FONDO>Equal</CODICE_FONDO>
    </GetDataInvioDaA>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IGRUE_INVIO>
*/
