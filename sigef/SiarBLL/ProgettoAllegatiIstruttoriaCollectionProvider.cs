using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoAllegatiIstruttoria
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoAllegatiIstruttoriaProvider
	{
		int Save(ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj);
		int SaveCollection(ProgettoAllegatiIstruttoriaCollection collectionObj);
		int Delete(ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj);
		int DeleteCollection(ProgettoAllegatiIstruttoriaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoAllegatiIstruttoria
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoAllegatiIstruttoria : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgettoAllegatiIstruttoria;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _DescrizioneBreve;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private IProgettoAllegatiIstruttoriaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettoAllegatiIstruttoriaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public ProgettoAllegatiIstruttoria()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_ALLEGATI_ISTRUTTORIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoAllegatiIstruttoria
		{
			get { return _IdProgettoAllegatiIstruttoria; }
			set
			{
				if (IdProgettoAllegatiIstruttoria != value)
				{
					_IdProgettoAllegatiIstruttoria = value;
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
			set
			{
				if (IdProgetto != value)
				{
					_IdProgetto = value;
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
		/// Corrisponde al campo:DESCRIZIONE_BREVE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT DescrizioneBreve
		{
			get { return _DescrizioneBreve; }
			set
			{
				if (DescrizioneBreve != value)
				{
					_DescrizioneBreve = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set
			{
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
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
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set
			{
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
			set
			{
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
	/// Summary description for ProgettoAllegatiIstruttoriaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAllegatiIstruttoriaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoAllegatiIstruttoriaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((ProgettoAllegatiIstruttoria)info.GetValue(i.ToString(), typeof(ProgettoAllegatiIstruttoria)));
			}
		}

		//Costruttore
		public ProgettoAllegatiIstruttoriaCollection()
		{
			this.ItemType = typeof(ProgettoAllegatiIstruttoria);
		}

		//Costruttore con provider
		public ProgettoAllegatiIstruttoriaCollection(IProgettoAllegatiIstruttoriaProvider providerObj)
		{
			this.ItemType = typeof(ProgettoAllegatiIstruttoria);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoAllegatiIstruttoria this[int index]
		{
			get { return (ProgettoAllegatiIstruttoria)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoAllegatiIstruttoriaCollection GetChanges()
		{
			return (ProgettoAllegatiIstruttoriaCollection)base.GetChanges();
		}

		[NonSerialized] private IProgettoAllegatiIstruttoriaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettoAllegatiIstruttoriaProvider Provider
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
		public int Add(ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			if (ProgettoAllegatiIstruttoriaObj.Provider == null) ProgettoAllegatiIstruttoriaObj.Provider = this.Provider;
			return base.Add(ProgettoAllegatiIstruttoriaObj);
		}

		//AddCollection
		public void AddCollection(ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionObj)
		{
			foreach (ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj in ProgettoAllegatiIstruttoriaCollectionObj)
				this.Add(ProgettoAllegatiIstruttoriaObj);
		}

		//Insert
		public void Insert(int index, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			if (ProgettoAllegatiIstruttoriaObj.Provider == null) ProgettoAllegatiIstruttoriaObj.Provider = this.Provider;
			base.Insert(index, ProgettoAllegatiIstruttoriaObj);
		}

		//CollectionGetById
		public ProgettoAllegatiIstruttoria CollectionGetById(NullTypes.IntNT IdProgettoAllegatiIstruttoriaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdProgettoAllegatiIstruttoria == IdProgettoAllegatiIstruttoriaValue))
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
		public ProgettoAllegatiIstruttoriaCollection SubSelect(NullTypes.IntNT IdProgettoAllegatiIstruttoriaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdFileEqualThis,
NullTypes.StringNT DescrizioneBreveEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.IntNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis)
		{
			ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionTemp = new ProgettoAllegatiIstruttoriaCollection();
			foreach (ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaItem in this)
			{
				if (((IdProgettoAllegatiIstruttoriaEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.IdProgettoAllegatiIstruttoria != null) && (ProgettoAllegatiIstruttoriaItem.IdProgettoAllegatiIstruttoria.Value == IdProgettoAllegatiIstruttoriaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.IdProgetto != null) && (ProgettoAllegatiIstruttoriaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdFileEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.IdFile != null) && (ProgettoAllegatiIstruttoriaItem.IdFile.Value == IdFileEqualThis.Value))) &&
((DescrizioneBreveEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.DescrizioneBreve != null) && (ProgettoAllegatiIstruttoriaItem.DescrizioneBreve.Value == DescrizioneBreveEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.OperatoreInserimento != null) && (ProgettoAllegatiIstruttoriaItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.DataInserimento != null) && (ProgettoAllegatiIstruttoriaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((OperatoreModificaEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.OperatoreModifica != null) && (ProgettoAllegatiIstruttoriaItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ProgettoAllegatiIstruttoriaItem.DataModifica != null) && (ProgettoAllegatiIstruttoriaItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					ProgettoAllegatiIstruttoriaCollectionTemp.Add(ProgettoAllegatiIstruttoriaItem);
				}
			}
			return ProgettoAllegatiIstruttoriaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoAllegatiIstruttoriaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoAllegatiIstruttoriaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoAllegatiIstruttoria", ProgettoAllegatiIstruttoriaObj.IdProgettoAllegatiIstruttoria);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ProgettoAllegatiIstruttoriaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFile", ProgettoAllegatiIstruttoriaObj.IdFile);
			DbProvider.SetCmdParam(cmd, firstChar + "DescrizioneBreve", ProgettoAllegatiIstruttoriaObj.DescrizioneBreve);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", ProgettoAllegatiIstruttoriaObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ProgettoAllegatiIstruttoriaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", ProgettoAllegatiIstruttoriaObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ProgettoAllegatiIstruttoriaObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaInsert", new string[] {"IdProgetto", "IdFile",
"DescrizioneBreve", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int",
"string", "int", "DateTime",
"int", "DateTime"}, "");
				CompileIUCmd(false, insertCmd, ProgettoAllegatiIstruttoriaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					ProgettoAllegatiIstruttoriaObj.IdProgettoAllegatiIstruttoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ALLEGATI_ISTRUTTORIA"]);
				}
				ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiIstruttoriaObj.IsDirty = false;
				ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaUpdate", new string[] {"IdProgettoAllegatiIstruttoria", "IdProgetto", "IdFile",
"DescrizioneBreve", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int",
"string", "int", "DateTime",
"int", "DateTime"}, "");
				CompileIUCmd(true, updateCmd, ProgettoAllegatiIstruttoriaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					ProgettoAllegatiIstruttoriaObj.DataModifica = d;
				}
				ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiIstruttoriaObj.IsDirty = false;
				ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			switch (ProgettoAllegatiIstruttoriaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ProgettoAllegatiIstruttoriaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ProgettoAllegatiIstruttoriaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettoAllegatiIstruttoriaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaUpdate", new string[] {"IdProgettoAllegatiIstruttoria", "IdProgetto", "IdFile",
"DescrizioneBreve", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int",
"string", "int", "DateTime",
"int", "DateTime"}, "");
				IDbCommand insertCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaInsert", new string[] {"IdProgetto", "IdFile",
"DescrizioneBreve", "OperatoreInserimento", "DataInserimento",
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int",
"string", "int", "DateTime",
"int", "DateTime"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaDelete", new string[] { "IdProgettoAllegatiIstruttoria" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettoAllegatiIstruttoriaCollectionObj.Count; i++)
				{
					switch (ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ProgettoAllegatiIstruttoriaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoAllegatiIstruttoriaCollectionObj[i].IdProgettoAllegatiIstruttoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ALLEGATI_ISTRUTTORIA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ProgettoAllegatiIstruttoriaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									ProgettoAllegatiIstruttoriaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ProgettoAllegatiIstruttoriaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoria", (SiarLibrary.NullTypes.IntNT)ProgettoAllegatiIstruttoriaCollectionObj[i].IdProgettoAllegatiIstruttoria);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoAllegatiIstruttoriaCollectionObj.Count; i++)
				{
					if ((ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsDirty = false;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsDirty = false;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj)
		{
			int returnValue = 0;
			if (ProgettoAllegatiIstruttoriaObj.IsPersistent)
			{
				returnValue = Delete(db, ProgettoAllegatiIstruttoriaObj.IdProgettoAllegatiIstruttoria);
			}
			ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoAllegatiIstruttoriaObj.IsDirty = false;
			ProgettoAllegatiIstruttoriaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoAllegatiIstruttoriaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaDelete", new string[] { "IdProgettoAllegatiIstruttoria" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoria", (SiarLibrary.NullTypes.IntNT)IdProgettoAllegatiIstruttoriaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaDelete", new string[] { "IdProgettoAllegatiIstruttoria" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettoAllegatiIstruttoriaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoria", ProgettoAllegatiIstruttoriaCollectionObj[i].IdProgettoAllegatiIstruttoria);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoAllegatiIstruttoriaCollectionObj.Count; i++)
				{
					if ((ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoAllegatiIstruttoriaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsDirty = false;
						ProgettoAllegatiIstruttoriaCollectionObj[i].IsPersistent = false;
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
		public static ProgettoAllegatiIstruttoria GetById(DbProvider db, int IdProgettoAllegatiIstruttoriaValue)
		{
			ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj = null;
			IDbCommand readCmd = db.InitCmd("ZProgettoAllegatiIstruttoriaGetById", new string[] { "IdProgettoAllegatiIstruttoria" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoria", (SiarLibrary.NullTypes.IntNT)IdProgettoAllegatiIstruttoriaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoAllegatiIstruttoriaObj = GetFromDatareader(db);
				ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiIstruttoriaObj.IsDirty = false;
				ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoAllegatiIstruttoriaObj;
		}

		//getFromDatareader
		public static ProgettoAllegatiIstruttoria GetFromDatareader(DbProvider db)
		{
			ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj = new ProgettoAllegatiIstruttoria();
			ProgettoAllegatiIstruttoriaObj.IdProgettoAllegatiIstruttoria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ALLEGATI_ISTRUTTORIA"]);
			ProgettoAllegatiIstruttoriaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoAllegatiIstruttoriaObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoAllegatiIstruttoriaObj.DescrizioneBreve = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BREVE"]);
			ProgettoAllegatiIstruttoriaObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			ProgettoAllegatiIstruttoriaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ProgettoAllegatiIstruttoriaObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			ProgettoAllegatiIstruttoriaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoAllegatiIstruttoriaObj.IsDirty = false;
			ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
			return ProgettoAllegatiIstruttoriaObj;
		}

		//Find Select

		public static ProgettoAllegatiIstruttoriaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoAllegatiIstruttoriaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneBreveEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionObj = new ProgettoAllegatiIstruttoriaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoallegatiistruttoriafindselect", new string[] {"IdProgettoAllegatiIstruttoriaequalthis", "IdProgettoequalthis", "IdFileequalthis",
"DescrizioneBreveequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis",
"OperatoreModificaequalthis", "DataModificaequalthis"}, new string[] {"int", "int", "int",
"string", "int", "DateTime",
"int", "DateTime"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoriaequalthis", IdProgettoAllegatiIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBreveequalthis", DescrizioneBreveEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAllegatiIstruttoriaObj = GetFromDatareader(db);
				ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiIstruttoriaObj.IsDirty = false;
				ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
				ProgettoAllegatiIstruttoriaCollectionObj.Add(ProgettoAllegatiIstruttoriaObj);
			}
			db.Close();
			return ProgettoAllegatiIstruttoriaCollectionObj;
		}

		//Find Find

		public static ProgettoAllegatiIstruttoriaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoAllegatiIstruttoriaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionObj = new ProgettoAllegatiIstruttoriaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettoallegatiistruttoriafindfind", new string[] { "IdProgettoAllegatiIstruttoriaequalthis", "IdProgettoequalthis", "IdFileequalthis" }, new string[] { "int", "int", "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoAllegatiIstruttoriaequalthis", IdProgettoAllegatiIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoAllegatiIstruttoriaObj = GetFromDatareader(db);
				ProgettoAllegatiIstruttoriaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoAllegatiIstruttoriaObj.IsDirty = false;
				ProgettoAllegatiIstruttoriaObj.IsPersistent = true;
				ProgettoAllegatiIstruttoriaCollectionObj.Add(ProgettoAllegatiIstruttoriaObj);
			}
			db.Close();
			return ProgettoAllegatiIstruttoriaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoAllegatiIstruttoriaCollectionProvider:IProgettoAllegatiIstruttoriaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoAllegatiIstruttoriaCollectionProvider : IProgettoAllegatiIstruttoriaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoAllegatiIstruttoria
		protected ProgettoAllegatiIstruttoriaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoAllegatiIstruttoriaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoAllegatiIstruttoriaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoAllegatiIstruttoriaCollectionProvider(IntNT IdprogettoallegatiistruttoriaEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoallegatiistruttoriaEqualThis, IdprogettoEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input progettoallegatiistruttoriaCollectionObj - non popola la collection
		public ProgettoAllegatiIstruttoriaCollectionProvider(ProgettoAllegatiIstruttoriaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoAllegatiIstruttoriaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoAllegatiIstruttoriaCollection(this);
		}

		//Get e Set
		public ProgettoAllegatiIstruttoriaCollection CollectionObj
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
		public int SaveCollection(ProgettoAllegatiIstruttoriaCollection collectionObj)
		{
			return ProgettoAllegatiIstruttoriaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoAllegatiIstruttoria progettoallegatiistruttoriaObj)
		{
			return ProgettoAllegatiIstruttoriaDAL.Save(_dbProviderObj, progettoallegatiistruttoriaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoAllegatiIstruttoriaCollection collectionObj)
		{
			return ProgettoAllegatiIstruttoriaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoAllegatiIstruttoria progettoallegatiistruttoriaObj)
		{
			return ProgettoAllegatiIstruttoriaDAL.Delete(_dbProviderObj, progettoallegatiistruttoriaObj);
		}

		//getById
		public ProgettoAllegatiIstruttoria GetById(IntNT IdProgettoAllegatiIstruttoriaValue)
		{
			ProgettoAllegatiIstruttoria ProgettoAllegatiIstruttoriaTemp = ProgettoAllegatiIstruttoriaDAL.GetById(_dbProviderObj, IdProgettoAllegatiIstruttoriaValue);
			if (ProgettoAllegatiIstruttoriaTemp != null) ProgettoAllegatiIstruttoriaTemp.Provider = this;
			return ProgettoAllegatiIstruttoriaTemp;
		}

		//Select: popola la collection
		public ProgettoAllegatiIstruttoriaCollection Select(IntNT IdprogettoallegatiistruttoriaEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis,
StringNT DescrizionebreveEqualThis, IntNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis,
IntNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis)
		{
			ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionTemp = ProgettoAllegatiIstruttoriaDAL.Select(_dbProviderObj, IdprogettoallegatiistruttoriaEqualThis, IdprogettoEqualThis, IdfileEqualThis,
DescrizionebreveEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis,
OperatoremodificaEqualThis, DatamodificaEqualThis);
			ProgettoAllegatiIstruttoriaCollectionTemp.Provider = this;
			return ProgettoAllegatiIstruttoriaCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoAllegatiIstruttoriaCollection Find(IntNT IdprogettoallegatiistruttoriaEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			ProgettoAllegatiIstruttoriaCollection ProgettoAllegatiIstruttoriaCollectionTemp = ProgettoAllegatiIstruttoriaDAL.Find(_dbProviderObj, IdprogettoallegatiistruttoriaEqualThis, IdprogettoEqualThis, IdfileEqualThis);
			ProgettoAllegatiIstruttoriaCollectionTemp.Provider = this;
			return ProgettoAllegatiIstruttoriaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_ALLEGATI_ISTRUTTORIA>
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
      <ID_PROGETTO_ALLEGATI_ISTRUTTORIA>Equal</ID_PROGETTO_ALLEGATI_ISTRUTTORIA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_ALLEGATI_ISTRUTTORIA>
*/
