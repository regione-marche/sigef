using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidProgettoAutodichiarazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidProgettoAutodichiarazioneProvider
	{
		int Save(CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj);
		int SaveCollection(CovidProgettoAutodichiarazioneCollection collectionObj);
		int Delete(CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj);
		int DeleteCollection(CovidProgettoAutodichiarazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidProgettoAutodichiarazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidProgettoAutodichiarazione : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdAutodichiarazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private ICovidProgettoAutodichiarazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidProgettoAutodichiarazioneProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public CovidProgettoAutodichiarazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Id
		{
			get { return _Id; }
			set
			{
				if (Id != value)
				{
					_Id = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AUTODICHIARAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAutodichiarazione
		{
			get { return _IdAutodichiarazione; }
			set
			{
				if (IdAutodichiarazione != value)
				{
					_IdAutodichiarazione = value;
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
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set
			{
				if (IdBando != value)
				{
					_IdBando = value;
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
			set
			{
				if (IdImpresa != value)
				{
					_IdImpresa = value;
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
	/// Summary description for CovidProgettoAutodichiarazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidProgettoAutodichiarazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CovidProgettoAutodichiarazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((CovidProgettoAutodichiarazione)info.GetValue(i.ToString(), typeof(CovidProgettoAutodichiarazione)));
			}
		}

		//Costruttore
		public CovidProgettoAutodichiarazioneCollection()
		{
			this.ItemType = typeof(CovidProgettoAutodichiarazione);
		}

		//Costruttore con provider
		public CovidProgettoAutodichiarazioneCollection(ICovidProgettoAutodichiarazioneProvider providerObj)
		{
			this.ItemType = typeof(CovidProgettoAutodichiarazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidProgettoAutodichiarazione this[int index]
		{
			get { return (CovidProgettoAutodichiarazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidProgettoAutodichiarazioneCollection GetChanges()
		{
			return (CovidProgettoAutodichiarazioneCollection)base.GetChanges();
		}

		[NonSerialized] private ICovidProgettoAutodichiarazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ICovidProgettoAutodichiarazioneProvider Provider
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
		public int Add(CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			if (CovidProgettoAutodichiarazioneObj.Provider == null) CovidProgettoAutodichiarazioneObj.Provider = this.Provider;
			return base.Add(CovidProgettoAutodichiarazioneObj);
		}

		//AddCollection
		public void AddCollection(CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionObj)
		{
			foreach (CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj in CovidProgettoAutodichiarazioneCollectionObj)
				this.Add(CovidProgettoAutodichiarazioneObj);
		}

		//Insert
		public void Insert(int index, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			if (CovidProgettoAutodichiarazioneObj.Provider == null) CovidProgettoAutodichiarazioneObj.Provider = this.Provider;
			base.Insert(index, CovidProgettoAutodichiarazioneObj);
		}

		//CollectionGetById
		public CovidProgettoAutodichiarazione CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public CovidProgettoAutodichiarazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdAutodichiarazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis)
		{
			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionTemp = new CovidProgettoAutodichiarazioneCollection();
			foreach (CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneItem in this)
			{
				if (((IdEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.Id != null) && (CovidProgettoAutodichiarazioneItem.Id.Value == IdEqualThis.Value))) && ((IdAutodichiarazioneEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdAutodichiarazione != null) && (CovidProgettoAutodichiarazioneItem.IdAutodichiarazione.Value == IdAutodichiarazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdProgetto != null) && (CovidProgettoAutodichiarazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdBandoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdBando != null) && (CovidProgettoAutodichiarazioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdImpresa != null) && (CovidProgettoAutodichiarazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.OperatoreInserimento != null) && (CovidProgettoAutodichiarazioneItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.DataInserimento != null) && (CovidProgettoAutodichiarazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.DataModifica != null) && (CovidProgettoAutodichiarazioneItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					CovidProgettoAutodichiarazioneCollectionTemp.Add(CovidProgettoAutodichiarazioneItem);
				}
			}
			return CovidProgettoAutodichiarazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CovidProgettoAutodichiarazioneCollection Filter(NullTypes.IntNT IdAutodichiarazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis,
NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionTemp = new CovidProgettoAutodichiarazioneCollection();
			foreach (CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneItem in this)
			{
				if (((IdAutodichiarazioneEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdAutodichiarazione != null) && (CovidProgettoAutodichiarazioneItem.IdAutodichiarazione.Value == IdAutodichiarazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdProgetto != null) && (CovidProgettoAutodichiarazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdBando != null) && (CovidProgettoAutodichiarazioneItem.IdBando.Value == IdBandoEqualThis.Value))) &&
((IdImpresaEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.IdImpresa != null) && (CovidProgettoAutodichiarazioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.OperatoreInserimento != null) && (CovidProgettoAutodichiarazioneItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.DataInserimento != null) && (CovidProgettoAutodichiarazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((CovidProgettoAutodichiarazioneItem.DataModifica != null) && (CovidProgettoAutodichiarazioneItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					CovidProgettoAutodichiarazioneCollectionTemp.Add(CovidProgettoAutodichiarazioneItem);
				}
			}
			return CovidProgettoAutodichiarazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidProgettoAutodichiarazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidProgettoAutodichiarazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "Id", CovidProgettoAutodichiarazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdAutodichiarazione", CovidProgettoAutodichiarazioneObj.IdAutodichiarazione);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", CovidProgettoAutodichiarazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", CovidProgettoAutodichiarazioneObj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", CovidProgettoAutodichiarazioneObj.IdImpresa);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", CovidProgettoAutodichiarazioneObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", CovidProgettoAutodichiarazioneObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", CovidProgettoAutodichiarazioneObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneInsert", new string[] {"IdAutodichiarazione", "IdProgetto",
"IdBando", "IdImpresa", "OperatoreInserimento",
"DataInserimento", "DataModifica"}, new string[] {"int", "int",
"int", "int", "int",
"DateTime", "DateTime"}, "");
				CompileIUCmd(false, insertCmd, CovidProgettoAutodichiarazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					CovidProgettoAutodichiarazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidProgettoAutodichiarazioneObj.IsDirty = false;
				CovidProgettoAutodichiarazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneUpdate", new string[] {"Id", "IdAutodichiarazione", "IdProgetto",
"IdBando", "IdImpresa", "OperatoreInserimento",
"DataInserimento", "DataModifica"}, new string[] {"int", "int", "int",
"int", "int", "int",
"DateTime", "DateTime"}, "");
				CompileIUCmd(true, updateCmd, CovidProgettoAutodichiarazioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					CovidProgettoAutodichiarazioneObj.DataModifica = d;
				}
				CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidProgettoAutodichiarazioneObj.IsDirty = false;
				CovidProgettoAutodichiarazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			switch (CovidProgettoAutodichiarazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, CovidProgettoAutodichiarazioneObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, CovidProgettoAutodichiarazioneObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, CovidProgettoAutodichiarazioneObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneUpdate", new string[] {"Id", "IdAutodichiarazione", "IdProgetto",
"IdBando", "IdImpresa", "OperatoreInserimento",
"DataInserimento", "DataModifica"}, new string[] {"int", "int", "int",
"int", "int", "int",
"DateTime", "DateTime"}, "");
				IDbCommand insertCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneInsert", new string[] {"IdAutodichiarazione", "IdProgetto",
"IdBando", "IdImpresa", "OperatoreInserimento",
"DataInserimento", "DataModifica"}, new string[] {"int", "int",
"int", "int", "int",
"DateTime", "DateTime"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidProgettoAutodichiarazioneCollectionObj.Count; i++)
				{
					switch (CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, CovidProgettoAutodichiarazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidProgettoAutodichiarazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, CovidProgettoAutodichiarazioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									CovidProgettoAutodichiarazioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (CovidProgettoAutodichiarazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CovidProgettoAutodichiarazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidProgettoAutodichiarazioneCollectionObj.Count; i++)
				{
					if ((CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsPersistent = true;
					}
					if ((CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj)
		{
			int returnValue = 0;
			if (CovidProgettoAutodichiarazioneObj.IsPersistent)
			{
				returnValue = Delete(db, CovidProgettoAutodichiarazioneObj.Id);
			}
			CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidProgettoAutodichiarazioneObj.IsDirty = false;
			CovidProgettoAutodichiarazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < CovidProgettoAutodichiarazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", CovidProgettoAutodichiarazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidProgettoAutodichiarazioneCollectionObj.Count; i++)
				{
					if ((CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidProgettoAutodichiarazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsDirty = false;
						CovidProgettoAutodichiarazioneCollectionObj[i].IsPersistent = false;
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
		public static CovidProgettoAutodichiarazione GetById(DbProvider db, int IdValue)
		{
			CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj = null;
			IDbCommand readCmd = db.InitCmd("ZCovidProgettoAutodichiarazioneGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidProgettoAutodichiarazioneObj = GetFromDatareader(db);
				CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidProgettoAutodichiarazioneObj.IsDirty = false;
				CovidProgettoAutodichiarazioneObj.IsPersistent = true;
			}
			db.Close();
			return CovidProgettoAutodichiarazioneObj;
		}

		//getFromDatareader
		public static CovidProgettoAutodichiarazione GetFromDatareader(DbProvider db)
		{
			CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj = new CovidProgettoAutodichiarazione();
			CovidProgettoAutodichiarazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CovidProgettoAutodichiarazioneObj.IdAutodichiarazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AUTODICHIARAZIONE"]);
			CovidProgettoAutodichiarazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			CovidProgettoAutodichiarazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CovidProgettoAutodichiarazioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			CovidProgettoAutodichiarazioneObj.OperatoreInserimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			CovidProgettoAutodichiarazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			CovidProgettoAutodichiarazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidProgettoAutodichiarazioneObj.IsDirty = false;
			CovidProgettoAutodichiarazioneObj.IsPersistent = true;
			return CovidProgettoAutodichiarazioneObj;
		}

		//Find Select

		public static CovidProgettoAutodichiarazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdAutodichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionObj = new CovidProgettoAutodichiarazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidprogettoautodichiarazionefindselect", new string[] {"Idequalthis", "IdAutodichiarazioneequalthis", "IdProgettoequalthis",
"IdBandoequalthis", "IdImpresaequalthis", "OperatoreInserimentoequalthis",
"DataInserimentoequalthis", "DataModificaequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int",
"DateTime", "DateTime"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAutodichiarazioneequalthis", IdAutodichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidProgettoAutodichiarazioneObj = GetFromDatareader(db);
				CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidProgettoAutodichiarazioneObj.IsDirty = false;
				CovidProgettoAutodichiarazioneObj.IsPersistent = true;
				CovidProgettoAutodichiarazioneCollectionObj.Add(CovidProgettoAutodichiarazioneObj);
			}
			db.Close();
			return CovidProgettoAutodichiarazioneCollectionObj;
		}

		//Find Find

		public static CovidProgettoAutodichiarazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdAutodichiarazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreInserimentoEqualThis)

		{

			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionObj = new CovidProgettoAutodichiarazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidprogettoautodichiarazionefindfind", new string[] {"IdAutodichiarazioneequalthis", "IdProgettoequalthis", "IdBandoequalthis",
"IdImpresaequalthis", "OperatoreInserimentoequalthis"}, new string[] {"int", "int", "int",
"int", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAutodichiarazioneequalthis", IdAutodichiarazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidProgettoAutodichiarazioneObj = GetFromDatareader(db);
				CovidProgettoAutodichiarazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidProgettoAutodichiarazioneObj.IsDirty = false;
				CovidProgettoAutodichiarazioneObj.IsPersistent = true;
				CovidProgettoAutodichiarazioneCollectionObj.Add(CovidProgettoAutodichiarazioneObj);
			}
			db.Close();
			return CovidProgettoAutodichiarazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidProgettoAutodichiarazioneCollectionProvider:ICovidProgettoAutodichiarazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidProgettoAutodichiarazioneCollectionProvider : ICovidProgettoAutodichiarazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidProgettoAutodichiarazione
		protected CovidProgettoAutodichiarazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidProgettoAutodichiarazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidProgettoAutodichiarazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidProgettoAutodichiarazioneCollectionProvider(IntNT IdautodichiarazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis,
IntNT IdimpresaEqualThis, IntNT OperatoreinserimentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdautodichiarazioneEqualThis, IdprogettoEqualThis, IdbandoEqualThis,
IdimpresaEqualThis, OperatoreinserimentoEqualThis);
		}

		//Costruttore3: ha in input covidprogettoautodichiarazioneCollectionObj - non popola la collection
		public CovidProgettoAutodichiarazioneCollectionProvider(CovidProgettoAutodichiarazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidProgettoAutodichiarazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidProgettoAutodichiarazioneCollection(this);
		}

		//Get e Set
		public CovidProgettoAutodichiarazioneCollection CollectionObj
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
		public int SaveCollection(CovidProgettoAutodichiarazioneCollection collectionObj)
		{
			return CovidProgettoAutodichiarazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidProgettoAutodichiarazione covidprogettoautodichiarazioneObj)
		{
			return CovidProgettoAutodichiarazioneDAL.Save(_dbProviderObj, covidprogettoautodichiarazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidProgettoAutodichiarazioneCollection collectionObj)
		{
			return CovidProgettoAutodichiarazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidProgettoAutodichiarazione covidprogettoautodichiarazioneObj)
		{
			return CovidProgettoAutodichiarazioneDAL.Delete(_dbProviderObj, covidprogettoautodichiarazioneObj);
		}

		//getById
		public CovidProgettoAutodichiarazione GetById(IntNT IdValue)
		{
			CovidProgettoAutodichiarazione CovidProgettoAutodichiarazioneTemp = CovidProgettoAutodichiarazioneDAL.GetById(_dbProviderObj, IdValue);
			if (CovidProgettoAutodichiarazioneTemp != null) CovidProgettoAutodichiarazioneTemp.Provider = this;
			return CovidProgettoAutodichiarazioneTemp;
		}

		//Select: popola la collection
		public CovidProgettoAutodichiarazioneCollection Select(IntNT IdEqualThis, IntNT IdautodichiarazioneEqualThis, IntNT IdprogettoEqualThis,
IntNT IdbandoEqualThis, IntNT IdimpresaEqualThis, IntNT OperatoreinserimentoEqualThis,
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis)
		{
			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionTemp = CovidProgettoAutodichiarazioneDAL.Select(_dbProviderObj, IdEqualThis, IdautodichiarazioneEqualThis, IdprogettoEqualThis,
IdbandoEqualThis, IdimpresaEqualThis, OperatoreinserimentoEqualThis,
DatainserimentoEqualThis, DatamodificaEqualThis);
			CovidProgettoAutodichiarazioneCollectionTemp.Provider = this;
			return CovidProgettoAutodichiarazioneCollectionTemp;
		}

		//Find: popola la collection
		public CovidProgettoAutodichiarazioneCollection Find(IntNT IdautodichiarazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis,
IntNT IdimpresaEqualThis, IntNT OperatoreinserimentoEqualThis)
		{
			CovidProgettoAutodichiarazioneCollection CovidProgettoAutodichiarazioneCollectionTemp = CovidProgettoAutodichiarazioneDAL.Find(_dbProviderObj, IdautodichiarazioneEqualThis, IdprogettoEqualThis, IdbandoEqualThis,
IdimpresaEqualThis, OperatoreinserimentoEqualThis);
			CovidProgettoAutodichiarazioneCollectionTemp.Provider = this;
			return CovidProgettoAutodichiarazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_PROGETTO_AUTODICHIARAZIONE>
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
      <ID_AUTODICHIARAZIONE>Equal</ID_AUTODICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <OPERATORE_INSERIMENTO>Equal</OPERATORE_INSERIMENTO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_AUTODICHIARAZIONE>Equal</ID_AUTODICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <OPERATORE_INSERIMENTO>Equal</OPERATORE_INSERIMENTO>
      <DATA_INSERIMENTO>Equal</DATA_INSERIMENTO>
      <DATA_MODIFICA>Equal</DATA_MODIFICA>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COVID_PROGETTO_AUTODICHIARAZIONE>
*/
