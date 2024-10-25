using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TrasferimentiMandato
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITrasferimentiMandatoProvider
	{
		int Save(TrasferimentiMandato TrasferimentiMandatoObj);
		int SaveCollection(TrasferimentiMandatoCollection collectionObj);
		int Delete(TrasferimentiMandato TrasferimentiMandatoObj);
		int DeleteCollection(TrasferimentiMandatoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TrasferimentiMandato
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TrasferimentiMandato: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTrasferimentoMandato;
		private NullTypes.IntNT _IdTrasferimento;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.StringNT _MandatoNumero;
		private NullTypes.DatetimeNT _MandatoData;
		private NullTypes.DecimalNT _MandatoImporto;
		private NullTypes.IntNT _MandatoIdFile;
		private NullTypes.DatetimeNT _QuietanzaData;
		private NullTypes.DecimalNT _QuietanzaImporto;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private ITrasferimentiMandatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITrasferimentiMandatoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TrasferimentiMandato()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TRASFERIMENTO_MANDATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTrasferimentoMandato
		{
			get { return _IdTrasferimentoMandato; }
			set {
				if (IdTrasferimentoMandato != value)
				{
					_IdTrasferimentoMandato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TRASFERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTrasferimento
		{
			get { return _IdTrasferimento; }
			set {
				if (IdTrasferimento != value)
				{
					_IdTrasferimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CREAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreCreazione
		{
			get { return _OperatoreCreazione; }
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_NUMERO
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT MandatoNumero
		{
			get { return _MandatoNumero; }
			set {
				if (MandatoNumero != value)
				{
					_MandatoNumero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT MandatoData
		{
			get { return _MandatoData; }
			set {
				if (MandatoData != value)
				{
					_MandatoData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT MandatoImporto
		{
			get { return _MandatoImporto; }
			set {
				if (MandatoImporto != value)
				{
					_MandatoImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MANDATO_ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT MandatoIdFile
		{
			get { return _MandatoIdFile; }
			set {
				if (MandatoIdFile != value)
				{
					_MandatoIdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUIETANZA_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT QuietanzaData
		{
			get { return _QuietanzaData; }
			set {
				if (QuietanzaData != value)
				{
					_QuietanzaData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUIETANZA_IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT QuietanzaImporto
		{
			get { return _QuietanzaImporto; }
			set {
				if (QuietanzaImporto != value)
				{
					_QuietanzaImporto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
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
	/// Summary description for TrasferimentiMandatoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TrasferimentiMandatoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TrasferimentiMandatoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TrasferimentiMandato) info.GetValue(i.ToString(),typeof(TrasferimentiMandato)));
			}
		}

		//Costruttore
		public TrasferimentiMandatoCollection()
		{
			this.ItemType = typeof(TrasferimentiMandato);
		}

		//Costruttore con provider
		public TrasferimentiMandatoCollection(ITrasferimentiMandatoProvider providerObj)
		{
			this.ItemType = typeof(TrasferimentiMandato);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TrasferimentiMandato this[int index]
		{
			get { return (TrasferimentiMandato)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TrasferimentiMandatoCollection GetChanges()
		{
			return (TrasferimentiMandatoCollection) base.GetChanges();
		}

		[NonSerialized] private ITrasferimentiMandatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITrasferimentiMandatoProvider Provider
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
		public int Add(TrasferimentiMandato TrasferimentiMandatoObj)
		{
			if (TrasferimentiMandatoObj.Provider == null) TrasferimentiMandatoObj.Provider = this.Provider;
			return base.Add(TrasferimentiMandatoObj);
		}

		//AddCollection
		public void AddCollection(TrasferimentiMandatoCollection TrasferimentiMandatoCollectionObj)
		{
			foreach (TrasferimentiMandato TrasferimentiMandatoObj in TrasferimentiMandatoCollectionObj)
				this.Add(TrasferimentiMandatoObj);
		}

		//Insert
		public void Insert(int index, TrasferimentiMandato TrasferimentiMandatoObj)
		{
			if (TrasferimentiMandatoObj.Provider == null) TrasferimentiMandatoObj.Provider = this.Provider;
			base.Insert(index, TrasferimentiMandatoObj);
		}

		//CollectionGetById
		public TrasferimentiMandato CollectionGetById(NullTypes.IntNT IdTrasferimentoMandatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTrasferimentoMandato == IdTrasferimentoMandatoValue))
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
		public TrasferimentiMandatoCollection SubSelect(NullTypes.IntNT IdTrasferimentoMandatoEqualThis, NullTypes.IntNT IdTrasferimentoEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.StringNT MandatoNumeroEqualThis, NullTypes.DatetimeNT MandatoDataEqualThis, 
NullTypes.DecimalNT MandatoImportoEqualThis, NullTypes.IntNT MandatoIdFileEqualThis, NullTypes.DatetimeNT QuietanzaDataEqualThis, 
NullTypes.DecimalNT QuietanzaImportoEqualThis, NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis)
		{
			TrasferimentiMandatoCollection TrasferimentiMandatoCollectionTemp = new TrasferimentiMandatoCollection();
			foreach (TrasferimentiMandato TrasferimentiMandatoItem in this)
			{
				if (((IdTrasferimentoMandatoEqualThis == null) || ((TrasferimentiMandatoItem.IdTrasferimentoMandato != null) && (TrasferimentiMandatoItem.IdTrasferimentoMandato.Value == IdTrasferimentoMandatoEqualThis.Value))) && ((IdTrasferimentoEqualThis == null) || ((TrasferimentiMandatoItem.IdTrasferimento != null) && (TrasferimentiMandatoItem.IdTrasferimento.Value == IdTrasferimentoEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((TrasferimentiMandatoItem.OperatoreCreazione != null) && (TrasferimentiMandatoItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((TrasferimentiMandatoItem.DataCreazione != null) && (TrasferimentiMandatoItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((MandatoNumeroEqualThis == null) || ((TrasferimentiMandatoItem.MandatoNumero != null) && (TrasferimentiMandatoItem.MandatoNumero.Value == MandatoNumeroEqualThis.Value))) && ((MandatoDataEqualThis == null) || ((TrasferimentiMandatoItem.MandatoData != null) && (TrasferimentiMandatoItem.MandatoData.Value == MandatoDataEqualThis.Value))) && 
((MandatoImportoEqualThis == null) || ((TrasferimentiMandatoItem.MandatoImporto != null) && (TrasferimentiMandatoItem.MandatoImporto.Value == MandatoImportoEqualThis.Value))) && ((MandatoIdFileEqualThis == null) || ((TrasferimentiMandatoItem.MandatoIdFile != null) && (TrasferimentiMandatoItem.MandatoIdFile.Value == MandatoIdFileEqualThis.Value))) && ((QuietanzaDataEqualThis == null) || ((TrasferimentiMandatoItem.QuietanzaData != null) && (TrasferimentiMandatoItem.QuietanzaData.Value == QuietanzaDataEqualThis.Value))) && 
((QuietanzaImportoEqualThis == null) || ((TrasferimentiMandatoItem.QuietanzaImporto != null) && (TrasferimentiMandatoItem.QuietanzaImporto.Value == QuietanzaImportoEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((TrasferimentiMandatoItem.OperatoreModifica != null) && (TrasferimentiMandatoItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((TrasferimentiMandatoItem.DataModifica != null) && (TrasferimentiMandatoItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					TrasferimentiMandatoCollectionTemp.Add(TrasferimentiMandatoItem);
				}
			}
			return TrasferimentiMandatoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TrasferimentiMandatoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TrasferimentiMandatoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TrasferimentiMandato TrasferimentiMandatoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTrasferimentoMandato", TrasferimentiMandatoObj.IdTrasferimentoMandato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdTrasferimento", TrasferimentiMandatoObj.IdTrasferimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", TrasferimentiMandatoObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", TrasferimentiMandatoObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoNumero", TrasferimentiMandatoObj.MandatoNumero);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoData", TrasferimentiMandatoObj.MandatoData);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoImporto", TrasferimentiMandatoObj.MandatoImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "MandatoIdFile", TrasferimentiMandatoObj.MandatoIdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaData", TrasferimentiMandatoObj.QuietanzaData);
			DbProvider.SetCmdParam(cmd,firstChar + "QuietanzaImporto", TrasferimentiMandatoObj.QuietanzaImporto);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", TrasferimentiMandatoObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", TrasferimentiMandatoObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, TrasferimentiMandato TrasferimentiMandatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTrasferimentiMandatoInsert", new string[] {"IdTrasferimento", "OperatoreCreazione", 
"DataCreazione", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "OperatoreModifica", "DataModifica"}, new string[] {"int", "int", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "int", "DateTime"},"");
				CompileIUCmd(false, insertCmd,TrasferimentiMandatoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TrasferimentiMandatoObj.IdTrasferimentoMandato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_MANDATO"]);
				}
				TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TrasferimentiMandatoObj.IsDirty = false;
				TrasferimentiMandatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TrasferimentiMandato TrasferimentiMandatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTrasferimentiMandatoUpdate", new string[] {"IdTrasferimentoMandato", "IdTrasferimento", "OperatoreCreazione", 
"DataCreazione", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "int", "DateTime"},"");
				CompileIUCmd(true, updateCmd,TrasferimentiMandatoObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					TrasferimentiMandatoObj.DataModifica = d;
				}
				TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TrasferimentiMandatoObj.IsDirty = false;
				TrasferimentiMandatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TrasferimentiMandato TrasferimentiMandatoObj)
		{
			switch (TrasferimentiMandatoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TrasferimentiMandatoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TrasferimentiMandatoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TrasferimentiMandatoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TrasferimentiMandatoCollection TrasferimentiMandatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTrasferimentiMandatoUpdate", new string[] {"IdTrasferimentoMandato", "IdTrasferimento", "OperatoreCreazione", 
"DataCreazione", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "int", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTrasferimentiMandatoInsert", new string[] {"IdTrasferimento", "OperatoreCreazione", 
"DataCreazione", "MandatoNumero", "MandatoData", 
"MandatoImporto", "MandatoIdFile", "QuietanzaData", 
"QuietanzaImporto", "OperatoreModifica", "DataModifica"}, new string[] {"int", "int", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "int", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTrasferimentiMandatoDelete", new string[] {"IdTrasferimentoMandato"}, new string[] {"int"},"");
				for (int i = 0; i < TrasferimentiMandatoCollectionObj.Count; i++)
				{
					switch (TrasferimentiMandatoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TrasferimentiMandatoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TrasferimentiMandatoCollectionObj[i].IdTrasferimentoMandato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_MANDATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TrasferimentiMandatoCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									TrasferimentiMandatoCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TrasferimentiMandatoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTrasferimentoMandato", (SiarLibrary.NullTypes.IntNT)TrasferimentiMandatoCollectionObj[i].IdTrasferimentoMandato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TrasferimentiMandatoCollectionObj.Count; i++)
				{
					if ((TrasferimentiMandatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiMandatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TrasferimentiMandatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TrasferimentiMandatoCollectionObj[i].IsDirty = false;
						TrasferimentiMandatoCollectionObj[i].IsPersistent = true;
					}
					if ((TrasferimentiMandatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TrasferimentiMandatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TrasferimentiMandatoCollectionObj[i].IsDirty = false;
						TrasferimentiMandatoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TrasferimentiMandato TrasferimentiMandatoObj)
		{
			int returnValue = 0;
			if (TrasferimentiMandatoObj.IsPersistent) 
			{
				returnValue = Delete(db, TrasferimentiMandatoObj.IdTrasferimentoMandato);
			}
			TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TrasferimentiMandatoObj.IsDirty = false;
			TrasferimentiMandatoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTrasferimentoMandatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTrasferimentiMandatoDelete", new string[] {"IdTrasferimentoMandato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTrasferimentoMandato", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoMandatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TrasferimentiMandatoCollection TrasferimentiMandatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTrasferimentiMandatoDelete", new string[] {"IdTrasferimentoMandato"}, new string[] {"int"},"");
				for (int i = 0; i < TrasferimentiMandatoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTrasferimentoMandato", TrasferimentiMandatoCollectionObj[i].IdTrasferimentoMandato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TrasferimentiMandatoCollectionObj.Count; i++)
				{
					if ((TrasferimentiMandatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TrasferimentiMandatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TrasferimentiMandatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TrasferimentiMandatoCollectionObj[i].IsDirty = false;
						TrasferimentiMandatoCollectionObj[i].IsPersistent = false;
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
		public static TrasferimentiMandato GetById(DbProvider db, int IdTrasferimentoMandatoValue)
		{
			TrasferimentiMandato TrasferimentiMandatoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTrasferimentiMandatoGetById", new string[] {"IdTrasferimentoMandato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTrasferimentoMandato", (SiarLibrary.NullTypes.IntNT)IdTrasferimentoMandatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TrasferimentiMandatoObj = GetFromDatareader(db);
				TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TrasferimentiMandatoObj.IsDirty = false;
				TrasferimentiMandatoObj.IsPersistent = true;
			}
			db.Close();
			return TrasferimentiMandatoObj;
		}

		//getFromDatareader
		public static TrasferimentiMandato GetFromDatareader(DbProvider db)
		{
			TrasferimentiMandato TrasferimentiMandatoObj = new TrasferimentiMandato();
			TrasferimentiMandatoObj.IdTrasferimentoMandato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO_MANDATO"]);
			TrasferimentiMandatoObj.IdTrasferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TRASFERIMENTO"]);
			TrasferimentiMandatoObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			TrasferimentiMandatoObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			TrasferimentiMandatoObj.MandatoNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["MANDATO_NUMERO"]);
			TrasferimentiMandatoObj.MandatoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["MANDATO_DATA"]);
			TrasferimentiMandatoObj.MandatoImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["MANDATO_IMPORTO"]);
			TrasferimentiMandatoObj.MandatoIdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["MANDATO_ID_FILE"]);
			TrasferimentiMandatoObj.QuietanzaData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["QUIETANZA_DATA"]);
			TrasferimentiMandatoObj.QuietanzaImporto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUIETANZA_IMPORTO"]);
			TrasferimentiMandatoObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			TrasferimentiMandatoObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TrasferimentiMandatoObj.IsDirty = false;
			TrasferimentiMandatoObj.IsPersistent = true;
			return TrasferimentiMandatoObj;
		}

		//Find Select

		public static TrasferimentiMandatoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTrasferimentoMandatoEqualThis, SiarLibrary.NullTypes.IntNT IdTrasferimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.StringNT MandatoNumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT MandatoDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT MandatoImportoEqualThis, SiarLibrary.NullTypes.IntNT MandatoIdFileEqualThis, SiarLibrary.NullTypes.DatetimeNT QuietanzaDataEqualThis, 
SiarLibrary.NullTypes.DecimalNT QuietanzaImportoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			TrasferimentiMandatoCollection TrasferimentiMandatoCollectionObj = new TrasferimentiMandatoCollection();

			IDbCommand findCmd = db.InitCmd("Ztrasferimentimandatofindselect", new string[] {"IdTrasferimentoMandatoequalthis", "IdTrasferimentoequalthis", "OperatoreCreazioneequalthis", 
"DataCreazioneequalthis", "MandatoNumeroequalthis", "MandatoDataequalthis", 
"MandatoImportoequalthis", "MandatoIdFileequalthis", "QuietanzaDataequalthis", 
"QuietanzaImportoequalthis", "OperatoreModificaequalthis", "DataModificaequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "string", "DateTime", 
"decimal", "int", "DateTime", 
"decimal", "int", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTrasferimentoMandatoequalthis", IdTrasferimentoMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTrasferimentoequalthis", IdTrasferimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoNumeroequalthis", MandatoNumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoDataequalthis", MandatoDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoImportoequalthis", MandatoImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MandatoIdFileequalthis", MandatoIdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaDataequalthis", QuietanzaDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuietanzaImportoequalthis", QuietanzaImportoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			TrasferimentiMandato TrasferimentiMandatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TrasferimentiMandatoObj = GetFromDatareader(db);
				TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TrasferimentiMandatoObj.IsDirty = false;
				TrasferimentiMandatoObj.IsPersistent = true;
				TrasferimentiMandatoCollectionObj.Add(TrasferimentiMandatoObj);
			}
			db.Close();
			return TrasferimentiMandatoCollectionObj;
		}

		//Find Find

		public static TrasferimentiMandatoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdTrasferimentoMandatoEqualThis, SiarLibrary.NullTypes.IntNT IdTrasferimentoEqualThis)

		{

			TrasferimentiMandatoCollection TrasferimentiMandatoCollectionObj = new TrasferimentiMandatoCollection();

			IDbCommand findCmd = db.InitCmd("Ztrasferimentimandatofindfind", new string[] {"IdTrasferimentoMandatoequalthis", "IdTrasferimentoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTrasferimentoMandatoequalthis", IdTrasferimentoMandatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTrasferimentoequalthis", IdTrasferimentoEqualThis);
			TrasferimentiMandato TrasferimentiMandatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TrasferimentiMandatoObj = GetFromDatareader(db);
				TrasferimentiMandatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TrasferimentiMandatoObj.IsDirty = false;
				TrasferimentiMandatoObj.IsPersistent = true;
				TrasferimentiMandatoCollectionObj.Add(TrasferimentiMandatoObj);
			}
			db.Close();
			return TrasferimentiMandatoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TrasferimentiMandatoCollectionProvider:ITrasferimentiMandatoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TrasferimentiMandatoCollectionProvider : ITrasferimentiMandatoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TrasferimentiMandato
		protected TrasferimentiMandatoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TrasferimentiMandatoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TrasferimentiMandatoCollection(this);
		}

		//Costruttore 2: popola la collection
		public TrasferimentiMandatoCollectionProvider(IntNT IdtrasferimentomandatoEqualThis, IntNT IdtrasferimentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdtrasferimentomandatoEqualThis, IdtrasferimentoEqualThis);
		}

		//Costruttore3: ha in input trasferimentimandatoCollectionObj - non popola la collection
		public TrasferimentiMandatoCollectionProvider(TrasferimentiMandatoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TrasferimentiMandatoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TrasferimentiMandatoCollection(this);
		}

		//Get e Set
		public TrasferimentiMandatoCollection CollectionObj
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
		public int SaveCollection(TrasferimentiMandatoCollection collectionObj)
		{
			return TrasferimentiMandatoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TrasferimentiMandato trasferimentimandatoObj)
		{
			return TrasferimentiMandatoDAL.Save(_dbProviderObj, trasferimentimandatoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TrasferimentiMandatoCollection collectionObj)
		{
			return TrasferimentiMandatoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TrasferimentiMandato trasferimentimandatoObj)
		{
			return TrasferimentiMandatoDAL.Delete(_dbProviderObj, trasferimentimandatoObj);
		}

		//getById
		public TrasferimentiMandato GetById(IntNT IdTrasferimentoMandatoValue)
		{
			TrasferimentiMandato TrasferimentiMandatoTemp = TrasferimentiMandatoDAL.GetById(_dbProviderObj, IdTrasferimentoMandatoValue);
			if (TrasferimentiMandatoTemp!=null) TrasferimentiMandatoTemp.Provider = this;
			return TrasferimentiMandatoTemp;
		}

		//Select: popola la collection
		public TrasferimentiMandatoCollection Select(IntNT IdtrasferimentomandatoEqualThis, IntNT IdtrasferimentoEqualThis, IntNT OperatorecreazioneEqualThis, 
DatetimeNT DatacreazioneEqualThis, StringNT MandatonumeroEqualThis, DatetimeNT MandatodataEqualThis, 
DecimalNT MandatoimportoEqualThis, IntNT MandatoidfileEqualThis, DatetimeNT QuietanzadataEqualThis, 
DecimalNT QuietanzaimportoEqualThis, IntNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis)
		{
			TrasferimentiMandatoCollection TrasferimentiMandatoCollectionTemp = TrasferimentiMandatoDAL.Select(_dbProviderObj, IdtrasferimentomandatoEqualThis, IdtrasferimentoEqualThis, OperatorecreazioneEqualThis, 
DatacreazioneEqualThis, MandatonumeroEqualThis, MandatodataEqualThis, 
MandatoimportoEqualThis, MandatoidfileEqualThis, QuietanzadataEqualThis, 
QuietanzaimportoEqualThis, OperatoremodificaEqualThis, DatamodificaEqualThis);
			TrasferimentiMandatoCollectionTemp.Provider = this;
			return TrasferimentiMandatoCollectionTemp;
		}

		//Find: popola la collection
		public TrasferimentiMandatoCollection Find(IntNT IdtrasferimentomandatoEqualThis, IntNT IdtrasferimentoEqualThis)
		{
			TrasferimentiMandatoCollection TrasferimentiMandatoCollectionTemp = TrasferimentiMandatoDAL.Find(_dbProviderObj, IdtrasferimentomandatoEqualThis, IdtrasferimentoEqualThis);
			TrasferimentiMandatoCollectionTemp.Provider = this;
			return TrasferimentiMandatoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TRASFERIMENTI_MANDATO>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_TRASFERIMENTO_MANDATO>Equal</ID_TRASFERIMENTO_MANDATO>
      <ID_TRASFERIMENTO>Equal</ID_TRASFERIMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TRASFERIMENTI_MANDATO>
*/
