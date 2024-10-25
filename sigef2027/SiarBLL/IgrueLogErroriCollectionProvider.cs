using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per IgrueLogErrori
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIgrueLogErroriProvider
	{
		int Save(IgrueLogErrori IgrueLogErroriObj);
		int SaveCollection(IgrueLogErroriCollection collectionObj);
		int Delete(IgrueLogErrori IgrueLogErroriObj);
		int DeleteCollection(IgrueLogErroriCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IgrueLogErrori
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class IgrueLogErrori : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdIgrueLogErrori;
		private NullTypes.IntNT _IdInvio;
		private NullTypes.StringNT _IdTicket;
		private NullTypes.DatetimeNT _DataRichiesta;
		private byte[] _FileErrori;
		private NullTypes.StringNT _IstanzaErrori;
		private NullTypes.IntNT _IdOperatore;
		private NullTypes.IntNT _CodiceEsito;
		private NullTypes.StringNT _DescrizioneEsito;
		private NullTypes.StringNT _DettaglioEsito;
		private NullTypes.DatetimeNT _TimestampEsito;
		private NullTypes.StringNT _TipoFile;
		private NullTypes.StringNT _CodiceFondo;
		[NonSerialized] private IIgrueLogErroriProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IIgrueLogErroriProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public IgrueLogErrori()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
	/// Summary description for IgrueLogErroriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IgrueLogErroriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IgrueLogErroriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((IgrueLogErrori)info.GetValue(i.ToString(), typeof(IgrueLogErrori)));
			}
		}

		//Costruttore
		public IgrueLogErroriCollection()
		{
			this.ItemType = typeof(IgrueLogErrori);
		}

		//Costruttore con provider
		public IgrueLogErroriCollection(IIgrueLogErroriProvider providerObj)
		{
			this.ItemType = typeof(IgrueLogErrori);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IgrueLogErrori this[int index]
		{
			get { return (IgrueLogErrori)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IgrueLogErroriCollection GetChanges()
		{
			return (IgrueLogErroriCollection)base.GetChanges();
		}

		[NonSerialized] private IIgrueLogErroriProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IIgrueLogErroriProvider Provider
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
		public int Add(IgrueLogErrori IgrueLogErroriObj)
		{
			if (IgrueLogErroriObj.Provider == null) IgrueLogErroriObj.Provider = this.Provider;
			return base.Add(IgrueLogErroriObj);
		}

		//AddCollection
		public void AddCollection(IgrueLogErroriCollection IgrueLogErroriCollectionObj)
		{
			foreach (IgrueLogErrori IgrueLogErroriObj in IgrueLogErroriCollectionObj)
				this.Add(IgrueLogErroriObj);
		}

		//Insert
		public void Insert(int index, IgrueLogErrori IgrueLogErroriObj)
		{
			if (IgrueLogErroriObj.Provider == null) IgrueLogErroriObj.Provider = this.Provider;
			base.Insert(index, IgrueLogErroriObj);
		}

		//CollectionGetById
		public IgrueLogErrori CollectionGetById(NullTypes.IntNT IdIgrueLogErroriValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdIgrueLogErrori == IdIgrueLogErroriValue))
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
		public IgrueLogErroriCollection SubSelect(NullTypes.IntNT IdIgrueLogErroriEqualThis, NullTypes.IntNT IdInvioEqualThis, NullTypes.StringNT IdTicketEqualThis,
NullTypes.DatetimeNT DataRichiestaEqualThis, NullTypes.IntNT IdOperatoreEqualThis, NullTypes.IntNT CodiceEsitoEqualThis,
NullTypes.StringNT DescrizioneEsitoEqualThis, NullTypes.StringNT DettaglioEsitoEqualThis, NullTypes.DatetimeNT TimestampEsitoEqualThis,
NullTypes.StringNT TipoFileEqualThis, NullTypes.StringNT CodiceFondoEqualThis)
		{
			IgrueLogErroriCollection IgrueLogErroriCollectionTemp = new IgrueLogErroriCollection();
			foreach (IgrueLogErrori IgrueLogErroriItem in this)
			{
				if (((IdIgrueLogErroriEqualThis == null) || ((IgrueLogErroriItem.IdIgrueLogErrori != null) && (IgrueLogErroriItem.IdIgrueLogErrori.Value == IdIgrueLogErroriEqualThis.Value))) && ((IdInvioEqualThis == null) || ((IgrueLogErroriItem.IdInvio != null) && (IgrueLogErroriItem.IdInvio.Value == IdInvioEqualThis.Value))) && ((IdTicketEqualThis == null) || ((IgrueLogErroriItem.IdTicket != null) && (IgrueLogErroriItem.IdTicket.Value == IdTicketEqualThis.Value))) &&
((DataRichiestaEqualThis == null) || ((IgrueLogErroriItem.DataRichiesta != null) && (IgrueLogErroriItem.DataRichiesta.Value == DataRichiestaEqualThis.Value))) && ((IdOperatoreEqualThis == null) || ((IgrueLogErroriItem.IdOperatore != null) && (IgrueLogErroriItem.IdOperatore.Value == IdOperatoreEqualThis.Value))) && ((CodiceEsitoEqualThis == null) || ((IgrueLogErroriItem.CodiceEsito != null) && (IgrueLogErroriItem.CodiceEsito.Value == CodiceEsitoEqualThis.Value))) &&
((DescrizioneEsitoEqualThis == null) || ((IgrueLogErroriItem.DescrizioneEsito != null) && (IgrueLogErroriItem.DescrizioneEsito.Value == DescrizioneEsitoEqualThis.Value))) && ((DettaglioEsitoEqualThis == null) || ((IgrueLogErroriItem.DettaglioEsito != null) && (IgrueLogErroriItem.DettaglioEsito.Value == DettaglioEsitoEqualThis.Value))) && ((TimestampEsitoEqualThis == null) || ((IgrueLogErroriItem.TimestampEsito != null) && (IgrueLogErroriItem.TimestampEsito.Value == TimestampEsitoEqualThis.Value))) &&
((TipoFileEqualThis == null) || ((IgrueLogErroriItem.TipoFile != null) && (IgrueLogErroriItem.TipoFile.Value == TipoFileEqualThis.Value))) && ((CodiceFondoEqualThis == null) || ((IgrueLogErroriItem.CodiceFondo != null) && (IgrueLogErroriItem.CodiceFondo.Value == CodiceFondoEqualThis.Value))))
				{
					IgrueLogErroriCollectionTemp.Add(IgrueLogErroriItem);
				}
			}
			return IgrueLogErroriCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IgrueLogErroriDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IgrueLogErroriDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IgrueLogErrori IgrueLogErroriObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdIgrueLogErrori", IgrueLogErroriObj.IdIgrueLogErrori);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdInvio", IgrueLogErroriObj.IdInvio);
			DbProvider.SetCmdParam(cmd, firstChar + "IdTicket", IgrueLogErroriObj.IdTicket);
			DbProvider.SetCmdParam(cmd, firstChar + "DataRichiesta", IgrueLogErroriObj.DataRichiesta);
			DbProvider.SetCmdParam(cmd, firstChar + "FileErrori", IgrueLogErroriObj.FileErrori);
			DbProvider.SetCmdParam(cmd, firstChar + "IstanzaErrori", IgrueLogErroriObj.IstanzaErrori);
			DbProvider.SetCmdParam(cmd, firstChar + "IdOperatore", IgrueLogErroriObj.IdOperatore);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceEsito", IgrueLogErroriObj.CodiceEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "DescrizioneEsito", IgrueLogErroriObj.DescrizioneEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "DettaglioEsito", IgrueLogErroriObj.DettaglioEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "TimestampEsito", IgrueLogErroriObj.TimestampEsito);
			DbProvider.SetCmdParam(cmd, firstChar + "TipoFile", IgrueLogErroriObj.TipoFile);
			DbProvider.SetCmdParam(cmd, firstChar + "CodiceFondo", IgrueLogErroriObj.CodiceFondo);
		}
		//Insert
		private static int Insert(DbProvider db, IgrueLogErrori IgrueLogErroriObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZIgrueLogErroriInsert", new string[] {"IdInvio", "IdTicket",
"DataRichiesta", "FileErrori", "IstanzaErrori",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo"}, new string[] {"int", "string",
"DateTime", "byte[]", "string",
"int", "int", "string",
"string", "DateTime", "string",
"string"}, "");
				CompileIUCmd(false, insertCmd, IgrueLogErroriObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					IgrueLogErroriObj.IdIgrueLogErrori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IGRUE_LOG_ERRORI"]);
				}
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IgrueLogErrori IgrueLogErroriObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZIgrueLogErroriUpdate", new string[] {"IdIgrueLogErrori", "IdInvio", "IdTicket",
"DataRichiesta", "FileErrori", "IstanzaErrori",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo"}, new string[] {"int", "int", "string",
"DateTime", "byte[]", "string",
"int", "int", "string",
"string", "DateTime", "string",
"string"}, "");
				CompileIUCmd(true, updateCmd, IgrueLogErroriObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IgrueLogErrori IgrueLogErroriObj)
		{
			switch (IgrueLogErroriObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, IgrueLogErroriObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, IgrueLogErroriObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, IgrueLogErroriObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IgrueLogErroriCollection IgrueLogErroriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZIgrueLogErroriUpdate", new string[] {"IdIgrueLogErrori", "IdInvio", "IdTicket",
"DataRichiesta", "FileErrori", "IstanzaErrori",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo"}, new string[] {"int", "int", "string",
"DateTime", "byte[]", "string",
"int", "int", "string",
"string", "DateTime", "string",
"string"}, "");
				IDbCommand insertCmd = db.InitCmd("ZIgrueLogErroriInsert", new string[] {"IdInvio", "IdTicket",
"DataRichiesta", "FileErrori", "IstanzaErrori",
"IdOperatore", "CodiceEsito", "DescrizioneEsito",
"DettaglioEsito", "TimestampEsito", "TipoFile",
"CodiceFondo"}, new string[] {"int", "string",
"DateTime", "byte[]", "string",
"int", "int", "string",
"string", "DateTime", "string",
"string"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZIgrueLogErroriDelete", new string[] { "IdIgrueLogErrori" }, new string[] { "int" }, "");
				for (int i = 0; i < IgrueLogErroriCollectionObj.Count; i++)
				{
					switch (IgrueLogErroriCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, IgrueLogErroriCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IgrueLogErroriCollectionObj[i].IdIgrueLogErrori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IGRUE_LOG_ERRORI"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, IgrueLogErroriCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (IgrueLogErroriCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIgrueLogErrori", (SiarLibrary.NullTypes.IntNT)IgrueLogErroriCollectionObj[i].IdIgrueLogErrori);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IgrueLogErroriCollectionObj.Count; i++)
				{
					if ((IgrueLogErroriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IgrueLogErroriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IgrueLogErroriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IgrueLogErroriCollectionObj[i].IsDirty = false;
						IgrueLogErroriCollectionObj[i].IsPersistent = true;
					}
					if ((IgrueLogErroriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IgrueLogErroriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IgrueLogErroriCollectionObj[i].IsDirty = false;
						IgrueLogErroriCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IgrueLogErrori IgrueLogErroriObj)
		{
			int returnValue = 0;
			if (IgrueLogErroriObj.IsPersistent)
			{
				returnValue = Delete(db, IgrueLogErroriObj.IdIgrueLogErrori);
			}
			IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IgrueLogErroriObj.IsDirty = false;
			IgrueLogErroriObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdIgrueLogErroriValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZIgrueLogErroriDelete", new string[] { "IdIgrueLogErrori" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIgrueLogErrori", (SiarLibrary.NullTypes.IntNT)IdIgrueLogErroriValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IgrueLogErroriCollection IgrueLogErroriCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZIgrueLogErroriDelete", new string[] { "IdIgrueLogErrori" }, new string[] { "int" }, "");
				for (int i = 0; i < IgrueLogErroriCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdIgrueLogErrori", IgrueLogErroriCollectionObj[i].IdIgrueLogErrori);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IgrueLogErroriCollectionObj.Count; i++)
				{
					if ((IgrueLogErroriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IgrueLogErroriCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IgrueLogErroriCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IgrueLogErroriCollectionObj[i].IsDirty = false;
						IgrueLogErroriCollectionObj[i].IsPersistent = false;
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
		public static IgrueLogErrori GetById(DbProvider db, int IdIgrueLogErroriValue)
		{
			IgrueLogErrori IgrueLogErroriObj = null;
			IDbCommand readCmd = db.InitCmd("ZIgrueLogErroriGetById", new string[] { "IdIgrueLogErrori" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdIgrueLogErrori", (SiarLibrary.NullTypes.IntNT)IdIgrueLogErroriValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IgrueLogErroriObj = GetFromDatareader(db);
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
			}
			db.Close();
			return IgrueLogErroriObj;
		}

		//getFromDatareader
		public static IgrueLogErrori GetFromDatareader(DbProvider db)
		{
			IgrueLogErrori IgrueLogErroriObj = new IgrueLogErrori();
			IgrueLogErroriObj.IdIgrueLogErrori = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IGRUE_LOG_ERRORI"]);
			IgrueLogErroriObj.IdInvio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVIO"]);
			IgrueLogErroriObj.IdTicket = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_TICKET"]);
			IgrueLogErroriObj.DataRichiesta = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA"]);
			IgrueLogErroriObj.FileErrori = Convert.IsDBNull(db.DataReader["FILE_ERRORI"]) ? null : (byte[])db.DataReader["FILE_ERRORI"];
			IgrueLogErroriObj.IstanzaErrori = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_ERRORI"]);
			IgrueLogErroriObj.IdOperatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE"]);
			IgrueLogErroriObj.CodiceEsito = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO"]);
			IgrueLogErroriObj.DescrizioneEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO"]);
			IgrueLogErroriObj.DettaglioEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_ESITO"]);
			IgrueLogErroriObj.TimestampEsito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["TIMESTAMP_ESITO"]);
			IgrueLogErroriObj.TipoFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_FILE"]);
			IgrueLogErroriObj.CodiceFondo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FONDO"]);
			IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IgrueLogErroriObj.IsDirty = false;
			IgrueLogErroriObj.IsPersistent = true;
			return IgrueLogErroriObj;
		}

		//Find Select

		public static IgrueLogErroriCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIgrueLogErroriEqualThis, SiarLibrary.NullTypes.IntNT IdInvioEqualThis, SiarLibrary.NullTypes.StringNT IdTicketEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataRichiestaEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreEqualThis, SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, SiarLibrary.NullTypes.StringNT DettaglioEsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT TimestampEsitoEqualThis,
SiarLibrary.NullTypes.StringNT TipoFileEqualThis, SiarLibrary.NullTypes.StringNT CodiceFondoEqualThis)

		{

			IgrueLogErroriCollection IgrueLogErroriCollectionObj = new IgrueLogErroriCollection();

			IDbCommand findCmd = db.InitCmd("Zigruelogerrorifindselect", new string[] {"IdIgrueLogErroriequalthis", "IdInvioequalthis", "IdTicketequalthis",
"DataRichiestaequalthis", "IdOperatoreequalthis", "CodiceEsitoequalthis",
"DescrizioneEsitoequalthis", "DettaglioEsitoequalthis", "TimestampEsitoequalthis",
"TipoFileequalthis", "CodiceFondoequalthis"}, new string[] {"int", "int", "string",
"DateTime", "int", "int",
"string", "string", "DateTime",
"string", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIgrueLogErroriequalthis", IdIgrueLogErroriEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvioequalthis", IdInvioEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRichiestaequalthis", DataRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdOperatoreequalthis", IdOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DettaglioEsitoequalthis", DettaglioEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TimestampEsitoequalthis", TimestampEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoFileequalthis", TipoFileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFondoequalthis", CodiceFondoEqualThis);
			IgrueLogErrori IgrueLogErroriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueLogErroriObj = GetFromDatareader(db);
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
				IgrueLogErroriCollectionObj.Add(IgrueLogErroriObj);
			}
			db.Close();
			return IgrueLogErroriCollectionObj;
		}

		//Find GetByIdInvio

		public static IgrueLogErroriCollection GetByIdInvio(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvioEqualThis)

		{

			IgrueLogErroriCollection IgrueLogErroriCollectionObj = new IgrueLogErroriCollection();

			IDbCommand findCmd = db.InitCmd("Zigruelogerrorifindgetbyidinvio", new string[] { "IdInvioequalthis" }, new string[] { "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvioequalthis", IdInvioEqualThis);
			IgrueLogErrori IgrueLogErroriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueLogErroriObj = GetFromDatareader(db);
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
				IgrueLogErroriCollectionObj.Add(IgrueLogErroriObj);
			}
			db.Close();
			return IgrueLogErroriCollectionObj;
		}

		//Find GetByIdTicket

		public static IgrueLogErroriCollection GetByIdTicket(DbProvider db, SiarLibrary.NullTypes.StringNT IdTicketEqualThis)

		{

			IgrueLogErroriCollection IgrueLogErroriCollectionObj = new IgrueLogErroriCollection();

			IDbCommand findCmd = db.InitCmd("Zigruelogerrorifindgetbyidticket", new string[] { "IdTicketequalthis" }, new string[] { "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			IgrueLogErrori IgrueLogErroriObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IgrueLogErroriObj = GetFromDatareader(db);
				IgrueLogErroriObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IgrueLogErroriObj.IsDirty = false;
				IgrueLogErroriObj.IsPersistent = true;
				IgrueLogErroriCollectionObj.Add(IgrueLogErroriObj);
			}
			db.Close();
			return IgrueLogErroriCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IgrueLogErroriCollectionProvider:IIgrueLogErroriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IgrueLogErroriCollectionProvider : IIgrueLogErroriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IgrueLogErrori
		protected IgrueLogErroriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IgrueLogErroriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IgrueLogErroriCollection(this);
		}

		//Costruttore 2: popola la collection
		public IgrueLogErroriCollectionProvider(IntNT IdinvioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = GetByIdInvio(IdinvioEqualThis);
		}

		//Costruttore3: ha in input igruelogerroriCollectionObj - non popola la collection
		public IgrueLogErroriCollectionProvider(IgrueLogErroriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IgrueLogErroriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IgrueLogErroriCollection(this);
		}

		//Get e Set
		public IgrueLogErroriCollection CollectionObj
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
		public int SaveCollection(IgrueLogErroriCollection collectionObj)
		{
			return IgrueLogErroriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IgrueLogErrori igruelogerroriObj)
		{
			return IgrueLogErroriDAL.Save(_dbProviderObj, igruelogerroriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IgrueLogErroriCollection collectionObj)
		{
			return IgrueLogErroriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IgrueLogErrori igruelogerroriObj)
		{
			return IgrueLogErroriDAL.Delete(_dbProviderObj, igruelogerroriObj);
		}

		//getById
		public IgrueLogErrori GetById(IntNT IdIgrueLogErroriValue)
		{
			IgrueLogErrori IgrueLogErroriTemp = IgrueLogErroriDAL.GetById(_dbProviderObj, IdIgrueLogErroriValue);
			if (IgrueLogErroriTemp != null) IgrueLogErroriTemp.Provider = this;
			return IgrueLogErroriTemp;
		}

		//Select: popola la collection
		public IgrueLogErroriCollection Select(IntNT IdigruelogerroriEqualThis, IntNT IdinvioEqualThis, StringNT IdticketEqualThis,
DatetimeNT DatarichiestaEqualThis, IntNT IdoperatoreEqualThis, IntNT CodiceesitoEqualThis,
StringNT DescrizioneesitoEqualThis, StringNT DettaglioesitoEqualThis, DatetimeNT TimestampesitoEqualThis,
StringNT TipofileEqualThis, StringNT CodicefondoEqualThis)
		{
			IgrueLogErroriCollection IgrueLogErroriCollectionTemp = IgrueLogErroriDAL.Select(_dbProviderObj, IdigruelogerroriEqualThis, IdinvioEqualThis, IdticketEqualThis,
DatarichiestaEqualThis, IdoperatoreEqualThis, CodiceesitoEqualThis,
DescrizioneesitoEqualThis, DettaglioesitoEqualThis, TimestampesitoEqualThis,
TipofileEqualThis, CodicefondoEqualThis);
			IgrueLogErroriCollectionTemp.Provider = this;
			return IgrueLogErroriCollectionTemp;
		}

		//GetByIdInvio: popola la collection
		public IgrueLogErroriCollection GetByIdInvio(IntNT IdinvioEqualThis)
		{
			IgrueLogErroriCollection IgrueLogErroriCollectionTemp = IgrueLogErroriDAL.GetByIdInvio(_dbProviderObj, IdinvioEqualThis);
			IgrueLogErroriCollectionTemp.Provider = this;
			return IgrueLogErroriCollectionTemp;
		}

		//GetByIdTicket: popola la collection
		public IgrueLogErroriCollection GetByIdTicket(StringNT IdticketEqualThis)
		{
			IgrueLogErroriCollection IgrueLogErroriCollectionTemp = IgrueLogErroriDAL.GetByIdTicket(_dbProviderObj, IdticketEqualThis);
			IgrueLogErroriCollectionTemp.Provider = this;
			return IgrueLogErroriCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IGRUE_LOG_ERRORI>
  <ViewName>VIGRUE_LOG_ERRORI</ViewName>
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
    <GetByIdTicket OrderBy="ORDER BY ">
      <ID_TICKET>Equal</ID_TICKET>
    </GetByIdTicket>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IGRUE_LOG_ERRORI>
*/
