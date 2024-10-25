using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SpeseSostenuteFile
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISpeseSostenuteFileProvider
	{
		int Save(SpeseSostenuteFile SpeseSostenuteFileObj);
		int SaveCollection(SpeseSostenuteFileCollection collectionObj);
		int Delete(SpeseSostenuteFile SpeseSostenuteFileObj);
		int DeleteCollection(SpeseSostenuteFileCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SpeseSostenuteFile
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SpeseSostenuteFile : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdFileSpeseSostenute;
		private NullTypes.IntNT _IdSpesa;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.BoolNT _InIntegrazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompleto;
		[NonSerialized] private ISpeseSostenuteFileProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ISpeseSostenuteFileProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public SpeseSostenuteFile()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FILE_SPESE_SOSTENUTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFileSpeseSostenute
		{
			get { return _IdFileSpeseSostenute; }
			set
			{
				if (IdFileSpeseSostenute != value)
				{
					_IdFileSpeseSostenute = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SPESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSpesa
		{
			get { return _IdSpesa; }
			set
			{
				if (IdSpesa != value)
				{
					_IdSpesa = value;
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
			set
			{
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(25)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set
			{
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set
			{
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(25)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set
			{
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IN_INTEGRAZIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT InIntegrazione
		{
			get { return _InIntegrazione; }
			set
			{
				if (InIntegrazione != value)
				{
					_InIntegrazione = value;
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
			set
			{
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set
			{
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_FILE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NomeFile
		{
			get { return _NomeFile; }
			set
			{
				if (NomeFile != value)
				{
					_NomeFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_COMPLETO
		/// Tipo sul db:VARCHAR(510)
		/// </summary>
		public NullTypes.StringNT NomeCompleto
		{
			get { return _NomeCompleto; }
			set
			{
				if (NomeCompleto != value)
				{
					_NomeCompleto = value;
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
	/// Summary description for SpeseSostenuteFileCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpeseSostenuteFileCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SpeseSostenuteFileCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((SpeseSostenuteFile)info.GetValue(i.ToString(), typeof(SpeseSostenuteFile)));
			}
		}

		//Costruttore
		public SpeseSostenuteFileCollection()
		{
			this.ItemType = typeof(SpeseSostenuteFile);
		}

		//Costruttore con provider
		public SpeseSostenuteFileCollection(ISpeseSostenuteFileProvider providerObj)
		{
			this.ItemType = typeof(SpeseSostenuteFile);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SpeseSostenuteFile this[int index]
		{
			get { return (SpeseSostenuteFile)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SpeseSostenuteFileCollection GetChanges()
		{
			return (SpeseSostenuteFileCollection)base.GetChanges();
		}

		[NonSerialized] private ISpeseSostenuteFileProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ISpeseSostenuteFileProvider Provider
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
		public int Add(SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			if (SpeseSostenuteFileObj.Provider == null) SpeseSostenuteFileObj.Provider = this.Provider;
			return base.Add(SpeseSostenuteFileObj);
		}

		//AddCollection
		public void AddCollection(SpeseSostenuteFileCollection SpeseSostenuteFileCollectionObj)
		{
			foreach (SpeseSostenuteFile SpeseSostenuteFileObj in SpeseSostenuteFileCollectionObj)
				this.Add(SpeseSostenuteFileObj);
		}

		//Insert
		public void Insert(int index, SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			if (SpeseSostenuteFileObj.Provider == null) SpeseSostenuteFileObj.Provider = this.Provider;
			base.Insert(index, SpeseSostenuteFileObj);
		}

		//CollectionGetById
		public SpeseSostenuteFile CollectionGetById(NullTypes.IntNT IdFileSpeseSostenuteValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdFileSpeseSostenute == IdFileSpeseSostenuteValue))
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
		public SpeseSostenuteFileCollection SubSelect(NullTypes.IntNT IdFileSpeseSostenuteEqualThis, NullTypes.IntNT IdSpesaEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdFileEqualThis)
		{
			SpeseSostenuteFileCollection SpeseSostenuteFileCollectionTemp = new SpeseSostenuteFileCollection();
			foreach (SpeseSostenuteFile SpeseSostenuteFileItem in this)
			{
				if (((IdFileSpeseSostenuteEqualThis == null) || ((SpeseSostenuteFileItem.IdFileSpeseSostenute != null) && (SpeseSostenuteFileItem.IdFileSpeseSostenute.Value == IdFileSpeseSostenuteEqualThis.Value))) && ((IdSpesaEqualThis == null) || ((SpeseSostenuteFileItem.IdSpesa != null) && (SpeseSostenuteFileItem.IdSpesa.Value == IdSpesaEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((SpeseSostenuteFileItem.DataInserimento != null) && (SpeseSostenuteFileItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((SpeseSostenuteFileItem.CfInserimento != null) && (SpeseSostenuteFileItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((SpeseSostenuteFileItem.DataModifica != null) && (SpeseSostenuteFileItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((SpeseSostenuteFileItem.CfModifica != null) && (SpeseSostenuteFileItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((InIntegrazioneEqualThis == null) || ((SpeseSostenuteFileItem.InIntegrazione != null) && (SpeseSostenuteFileItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((SpeseSostenuteFileItem.Descrizione != null) && (SpeseSostenuteFileItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdFileEqualThis == null) || ((SpeseSostenuteFileItem.IdFile != null) && (SpeseSostenuteFileItem.IdFile.Value == IdFileEqualThis.Value))))
				{
					SpeseSostenuteFileCollectionTemp.Add(SpeseSostenuteFileItem);
				}
			}
			return SpeseSostenuteFileCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SpeseSostenuteFileDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SpeseSostenuteFileDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SpeseSostenuteFile SpeseSostenuteFileObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdFileSpeseSostenute", SpeseSostenuteFileObj.IdFileSpeseSostenute);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdSpesa", SpeseSostenuteFileObj.IdSpesa);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", SpeseSostenuteFileObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", SpeseSostenuteFileObj.CfInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", SpeseSostenuteFileObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", SpeseSostenuteFileObj.CfModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", SpeseSostenuteFileObj.InIntegrazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", SpeseSostenuteFileObj.Descrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFile", SpeseSostenuteFileObj.IdFile);
		}
		//Insert
		private static int Insert(DbProvider db, SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZSpeseSostenuteFileInsert", new string[] {"IdSpesa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"InIntegrazione", "Descrizione", "IdFile", }, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"bool", "string", "int", }, "");
				CompileIUCmd(false, insertCmd, SpeseSostenuteFileObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					SpeseSostenuteFileObj.IdFileSpeseSostenute = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_SPESE_SOSTENUTE"]);
					SpeseSostenuteFileObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
					SpeseSostenuteFileObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
					SpeseSostenuteFileObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
				}
				SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpeseSostenuteFileObj.IsDirty = false;
				SpeseSostenuteFileObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZSpeseSostenuteFileUpdate", new string[] {"IdFileSpeseSostenute", "IdSpesa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"InIntegrazione", "Descrizione", "IdFile", }, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"bool", "string", "int", }, "");
				CompileIUCmd(true, updateCmd, SpeseSostenuteFileObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					SpeseSostenuteFileObj.DataModifica = d;
				}
				SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpeseSostenuteFileObj.IsDirty = false;
				SpeseSostenuteFileObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			switch (SpeseSostenuteFileObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, SpeseSostenuteFileObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, SpeseSostenuteFileObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, SpeseSostenuteFileObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SpeseSostenuteFileCollection SpeseSostenuteFileCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZSpeseSostenuteFileUpdate", new string[] {"IdFileSpeseSostenute", "IdSpesa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"InIntegrazione", "Descrizione", "IdFile", }, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"bool", "string", "int", }, "");
				IDbCommand insertCmd = db.InitCmd("ZSpeseSostenuteFileInsert", new string[] {"IdSpesa", "DataInserimento",
"CfInserimento", "DataModifica", "CfModifica",
"InIntegrazione", "Descrizione", "IdFile", }, new string[] {"int", "DateTime",
"string", "DateTime", "string",
"bool", "string", "int", }, "");
				IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteFileDelete", new string[] { "IdFileSpeseSostenute" }, new string[] { "int" }, "");
				for (int i = 0; i < SpeseSostenuteFileCollectionObj.Count; i++)
				{
					switch (SpeseSostenuteFileCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, SpeseSostenuteFileCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SpeseSostenuteFileCollectionObj[i].IdFileSpeseSostenute = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_SPESE_SOSTENUTE"]);
									SpeseSostenuteFileCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									SpeseSostenuteFileCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									SpeseSostenuteFileCollectionObj[i].InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, SpeseSostenuteFileCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									SpeseSostenuteFileCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (SpeseSostenuteFileCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFileSpeseSostenute", (SiarLibrary.NullTypes.IntNT)SpeseSostenuteFileCollectionObj[i].IdFileSpeseSostenute);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SpeseSostenuteFileCollectionObj.Count; i++)
				{
					if ((SpeseSostenuteFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpeseSostenuteFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpeseSostenuteFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SpeseSostenuteFileCollectionObj[i].IsDirty = false;
						SpeseSostenuteFileCollectionObj[i].IsPersistent = true;
					}
					if ((SpeseSostenuteFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SpeseSostenuteFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpeseSostenuteFileCollectionObj[i].IsDirty = false;
						SpeseSostenuteFileCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SpeseSostenuteFile SpeseSostenuteFileObj)
		{
			int returnValue = 0;
			if (SpeseSostenuteFileObj.IsPersistent)
			{
				returnValue = Delete(db, SpeseSostenuteFileObj.IdFileSpeseSostenute);
			}
			SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SpeseSostenuteFileObj.IsDirty = false;
			SpeseSostenuteFileObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdFileSpeseSostenuteValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteFileDelete", new string[] { "IdFileSpeseSostenute" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFileSpeseSostenute", (SiarLibrary.NullTypes.IntNT)IdFileSpeseSostenuteValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SpeseSostenuteFileCollection SpeseSostenuteFileCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZSpeseSostenuteFileDelete", new string[] { "IdFileSpeseSostenute" }, new string[] { "int" }, "");
				for (int i = 0; i < SpeseSostenuteFileCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFileSpeseSostenute", SpeseSostenuteFileCollectionObj[i].IdFileSpeseSostenute);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SpeseSostenuteFileCollectionObj.Count; i++)
				{
					if ((SpeseSostenuteFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SpeseSostenuteFileCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SpeseSostenuteFileCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SpeseSostenuteFileCollectionObj[i].IsDirty = false;
						SpeseSostenuteFileCollectionObj[i].IsPersistent = false;
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
		public static SpeseSostenuteFile GetById(DbProvider db, int IdFileSpeseSostenuteValue)
		{
			SpeseSostenuteFile SpeseSostenuteFileObj = null;
			IDbCommand readCmd = db.InitCmd("ZSpeseSostenuteFileGetById", new string[] { "IdFileSpeseSostenute" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdFileSpeseSostenute", (SiarLibrary.NullTypes.IntNT)IdFileSpeseSostenuteValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SpeseSostenuteFileObj = GetFromDatareader(db);
				SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpeseSostenuteFileObj.IsDirty = false;
				SpeseSostenuteFileObj.IsPersistent = true;
			}
			db.Close();
			return SpeseSostenuteFileObj;
		}

		//getFromDatareader
		public static SpeseSostenuteFile GetFromDatareader(DbProvider db)
		{
			SpeseSostenuteFile SpeseSostenuteFileObj = new SpeseSostenuteFile();
			SpeseSostenuteFileObj.IdFileSpeseSostenute = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE_SPESE_SOSTENUTE"]);
			SpeseSostenuteFileObj.IdSpesa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPESA"]);
			SpeseSostenuteFileObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			SpeseSostenuteFileObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			SpeseSostenuteFileObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			SpeseSostenuteFileObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			SpeseSostenuteFileObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
			SpeseSostenuteFileObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			SpeseSostenuteFileObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			SpeseSostenuteFileObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			SpeseSostenuteFileObj.NomeCompleto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO"]);
			SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SpeseSostenuteFileObj.IsDirty = false;
			SpeseSostenuteFileObj.IsPersistent = true;
			return SpeseSostenuteFileObj;
		}

		//Find Select

		public static SpeseSostenuteFileCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFileSpeseSostenuteEqualThis, SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			SpeseSostenuteFileCollection SpeseSostenuteFileCollectionObj = new SpeseSostenuteFileCollection();

			IDbCommand findCmd = db.InitCmd("Zspesesostenutefilefindselect", new string[] {"IdFileSpeseSostenuteequalthis", "IdSpesaequalthis", "DataInserimentoequalthis",
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis",
"InIntegrazioneequalthis", "Descrizioneequalthis", "IdFileequalthis"}, new string[] {"int", "int", "DateTime",
"string", "DateTime", "string",
"bool", "string", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileSpeseSostenuteequalthis", IdFileSpeseSostenuteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			SpeseSostenuteFile SpeseSostenuteFileObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpeseSostenuteFileObj = GetFromDatareader(db);
				SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpeseSostenuteFileObj.IsDirty = false;
				SpeseSostenuteFileObj.IsPersistent = true;
				SpeseSostenuteFileCollectionObj.Add(SpeseSostenuteFileObj);
			}
			db.Close();
			return SpeseSostenuteFileCollectionObj;
		}

		//Find GetByIdSpesa

		public static SpeseSostenuteFileCollection GetByIdSpesa(DbProvider db, SiarLibrary.NullTypes.IntNT IdSpesaEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis)

		{

			SpeseSostenuteFileCollection SpeseSostenuteFileCollectionObj = new SpeseSostenuteFileCollection();

			IDbCommand findCmd = db.InitCmd("Zspesesostenutefilefindgetbyidspesa", new string[] { "IdSpesaequalthis", "InIntegrazioneequalthis" }, new string[] { "int", "bool" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSpesaequalthis", IdSpesaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
			SpeseSostenuteFile SpeseSostenuteFileObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SpeseSostenuteFileObj = GetFromDatareader(db);
				SpeseSostenuteFileObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SpeseSostenuteFileObj.IsDirty = false;
				SpeseSostenuteFileObj.IsPersistent = true;
				SpeseSostenuteFileCollectionObj.Add(SpeseSostenuteFileObj);
			}
			db.Close();
			return SpeseSostenuteFileCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SpeseSostenuteFileCollectionProvider:ISpeseSostenuteFileProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SpeseSostenuteFileCollectionProvider : ISpeseSostenuteFileProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SpeseSostenuteFile
		protected SpeseSostenuteFileCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SpeseSostenuteFileCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SpeseSostenuteFileCollection(this);
		}

		//Costruttore 2: popola la collection
		public SpeseSostenuteFileCollectionProvider(IntNT IdspesaEqualThis, BoolNT InintegrazioneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = GetByIdSpesa(IdspesaEqualThis, InintegrazioneEqualThis);
		}

		//Costruttore3: ha in input spesesostenutefileCollectionObj - non popola la collection
		public SpeseSostenuteFileCollectionProvider(SpeseSostenuteFileCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SpeseSostenuteFileCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SpeseSostenuteFileCollection(this);
		}

		//Get e Set
		public SpeseSostenuteFileCollection CollectionObj
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
		public int SaveCollection(SpeseSostenuteFileCollection collectionObj)
		{
			return SpeseSostenuteFileDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SpeseSostenuteFile spesesostenutefileObj)
		{
			return SpeseSostenuteFileDAL.Save(_dbProviderObj, spesesostenutefileObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SpeseSostenuteFileCollection collectionObj)
		{
			return SpeseSostenuteFileDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SpeseSostenuteFile spesesostenutefileObj)
		{
			return SpeseSostenuteFileDAL.Delete(_dbProviderObj, spesesostenutefileObj);
		}

		//getById
		public SpeseSostenuteFile GetById(IntNT IdFileSpeseSostenuteValue)
		{
			SpeseSostenuteFile SpeseSostenuteFileTemp = SpeseSostenuteFileDAL.GetById(_dbProviderObj, IdFileSpeseSostenuteValue);
			if (SpeseSostenuteFileTemp != null) SpeseSostenuteFileTemp.Provider = this;
			return SpeseSostenuteFileTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public SpeseSostenuteFileCollection Select(IntNT IdfilespesesostenuteEqualThis, IntNT IdspesaEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis,
BoolNT InintegrazioneEqualThis, StringNT DescrizioneEqualThis, IntNT IdfileEqualThis)
		{
			SpeseSostenuteFileCollection SpeseSostenuteFileCollectionTemp = SpeseSostenuteFileDAL.Select(_dbProviderObj, IdfilespesesostenuteEqualThis, IdspesaEqualThis, DatainserimentoEqualThis,
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis,
InintegrazioneEqualThis, DescrizioneEqualThis, IdfileEqualThis);
			SpeseSostenuteFileCollectionTemp.Provider = this;
			return SpeseSostenuteFileCollectionTemp;
		}

		//GetByIdSpesa: popola la collection
		public SpeseSostenuteFileCollection GetByIdSpesa(IntNT IdspesaEqualThis, BoolNT InintegrazioneEqualThis)
		{
			SpeseSostenuteFileCollection SpeseSostenuteFileCollectionTemp = SpeseSostenuteFileDAL.GetByIdSpesa(_dbProviderObj, IdspesaEqualThis, InintegrazioneEqualThis);
			SpeseSostenuteFileCollectionTemp.Provider = this;
			return SpeseSostenuteFileCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SPESE_SOSTENUTE_FILE>
  <ViewName>VSPESE_SOSTENUTE_FILE</ViewName>
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
    <GetByIdSpesa OrderBy="ORDER BY ">
      <ID_SPESA>Equal</ID_SPESA>
      <IN_INTEGRAZIONE>Equal</IN_INTEGRAZIONE>
    </GetByIdSpesa>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SPESE_SOSTENUTE_FILE>
*/
