using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per SegnatureMultiple
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ISegnatureMultipleProvider
	{
		int Save(SegnatureMultiple SegnatureMultipleObj);
		int SaveCollection(SegnatureMultipleCollection collectionObj);
		int Delete(SegnatureMultiple SegnatureMultipleObj);
		int DeleteCollection(SegnatureMultipleCollection collectionObj);
	}
	/// <summary>
	/// Summary description for SegnatureMultiple
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class SegnatureMultiple : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdSegnaturaSecondaria;
		private NullTypes.StringNT _SegnaturaPrincipale;
		private NullTypes.StringNT _SegnaturaSecondaria;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Tipo;
		private NullTypes.IntNT _IdRiferimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _OperatoreModifica;
		[NonSerialized] private ISegnatureMultipleProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ISegnatureMultipleProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public SegnatureMultiple()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_SEGNATURA_SECONDARIA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSegnaturaSecondaria
		{
			get { return _IdSegnaturaSecondaria; }
			set
			{
				if (IdSegnaturaSecondaria != value)
				{
					_IdSegnaturaSecondaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_PRINCIPALE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaPrincipale
		{
			get { return _SegnaturaPrincipale; }
			set
			{
				if (SegnaturaPrincipale != value)
				{
					_SegnaturaPrincipale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_SECONDARIA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaSecondaria
		{
			get { return _SegnaturaSecondaria; }
			set
			{
				if (SegnaturaSecondaria != value)
				{
					_SegnaturaSecondaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set
			{
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set
			{
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RIFERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRiferimento
		{
			get { return _IdRiferimento; }
			set
			{
				if (IdRiferimento != value)
				{
					_IdRiferimento = value;
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
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreInserimento
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

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT OperatoreModifica
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
	/// Summary description for SegnatureMultipleCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SegnatureMultipleCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SegnatureMultipleCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((SegnatureMultiple)info.GetValue(i.ToString(), typeof(SegnatureMultiple)));
			}
		}

		//Costruttore
		public SegnatureMultipleCollection()
		{
			this.ItemType = typeof(SegnatureMultiple);
		}

		//Costruttore con provider
		public SegnatureMultipleCollection(ISegnatureMultipleProvider providerObj)
		{
			this.ItemType = typeof(SegnatureMultiple);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SegnatureMultiple this[int index]
		{
			get { return (SegnatureMultiple)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SegnatureMultipleCollection GetChanges()
		{
			return (SegnatureMultipleCollection)base.GetChanges();
		}

		[NonSerialized] private ISegnatureMultipleProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public ISegnatureMultipleProvider Provider
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
		public int Add(SegnatureMultiple SegnatureMultipleObj)
		{
			if (SegnatureMultipleObj.Provider == null) SegnatureMultipleObj.Provider = this.Provider;
			return base.Add(SegnatureMultipleObj);
		}

		//AddCollection
		public void AddCollection(SegnatureMultipleCollection SegnatureMultipleCollectionObj)
		{
			foreach (SegnatureMultiple SegnatureMultipleObj in SegnatureMultipleCollectionObj)
				this.Add(SegnatureMultipleObj);
		}

		//Insert
		public void Insert(int index, SegnatureMultiple SegnatureMultipleObj)
		{
			if (SegnatureMultipleObj.Provider == null) SegnatureMultipleObj.Provider = this.Provider;
			base.Insert(index, SegnatureMultipleObj);
		}

		//CollectionGetById
		public SegnatureMultiple CollectionGetById(NullTypes.IntNT IdSegnaturaSecondariaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdSegnaturaSecondaria == IdSegnaturaSecondariaValue))
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
		public SegnatureMultipleCollection SubSelect(NullTypes.IntNT IdSegnaturaSecondariaEqualThis, NullTypes.StringNT SegnaturaPrincipaleEqualThis, NullTypes.StringNT SegnaturaSecondariaEqualThis,
NullTypes.IntNT OrdineEqualThis, NullTypes.StringNT TipoEqualThis, NullTypes.IntNT IdRiferimentoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT OperatoreModificaEqualThis)
		{
			SegnatureMultipleCollection SegnatureMultipleCollectionTemp = new SegnatureMultipleCollection();
			foreach (SegnatureMultiple SegnatureMultipleItem in this)
			{
				if (((IdSegnaturaSecondariaEqualThis == null) || ((SegnatureMultipleItem.IdSegnaturaSecondaria != null) && (SegnatureMultipleItem.IdSegnaturaSecondaria.Value == IdSegnaturaSecondariaEqualThis.Value))) && ((SegnaturaPrincipaleEqualThis == null) || ((SegnatureMultipleItem.SegnaturaPrincipale != null) && (SegnatureMultipleItem.SegnaturaPrincipale.Value == SegnaturaPrincipaleEqualThis.Value))) && ((SegnaturaSecondariaEqualThis == null) || ((SegnatureMultipleItem.SegnaturaSecondaria != null) && (SegnatureMultipleItem.SegnaturaSecondaria.Value == SegnaturaSecondariaEqualThis.Value))) &&
((OrdineEqualThis == null) || ((SegnatureMultipleItem.Ordine != null) && (SegnatureMultipleItem.Ordine.Value == OrdineEqualThis.Value))) && ((TipoEqualThis == null) || ((SegnatureMultipleItem.Tipo != null) && (SegnatureMultipleItem.Tipo.Value == TipoEqualThis.Value))) && ((IdRiferimentoEqualThis == null) || ((SegnatureMultipleItem.IdRiferimento != null) && (SegnatureMultipleItem.IdRiferimento.Value == IdRiferimentoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((SegnatureMultipleItem.DataInserimento != null) && (SegnatureMultipleItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((SegnatureMultipleItem.OperatoreInserimento != null) && (SegnatureMultipleItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((SegnatureMultipleItem.DataModifica != null) && (SegnatureMultipleItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((OperatoreModificaEqualThis == null) || ((SegnatureMultipleItem.OperatoreModifica != null) && (SegnatureMultipleItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))))
				{
					SegnatureMultipleCollectionTemp.Add(SegnatureMultipleItem);
				}
			}
			return SegnatureMultipleCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for SegnatureMultipleDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class SegnatureMultipleDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, SegnatureMultiple SegnatureMultipleObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdSegnaturaSecondaria", SegnatureMultipleObj.IdSegnaturaSecondaria);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaPrincipale", SegnatureMultipleObj.SegnaturaPrincipale);
			DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaSecondaria", SegnatureMultipleObj.SegnaturaSecondaria);
			DbProvider.SetCmdParam(cmd, firstChar + "Ordine", SegnatureMultipleObj.Ordine);
			DbProvider.SetCmdParam(cmd, firstChar + "Tipo", SegnatureMultipleObj.Tipo);
			DbProvider.SetCmdParam(cmd, firstChar + "IdRiferimento", SegnatureMultipleObj.IdRiferimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", SegnatureMultipleObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", SegnatureMultipleObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", SegnatureMultipleObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", SegnatureMultipleObj.OperatoreModifica);
		}
		//Insert
		private static int Insert(DbProvider db, SegnatureMultiple SegnatureMultipleObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZSegnatureMultipleInsert", new string[] {"SegnaturaPrincipale", "SegnaturaSecondaria",
"Ordine", "Tipo", "IdRiferimento",
"DataInserimento", "OperatoreInserimento", "DataModifica",
"OperatoreModifica"}, new string[] {"string", "string",
"int", "string", "int",
"DateTime", "string", "DateTime",
"string"}, "");
				CompileIUCmd(false, insertCmd, SegnatureMultipleObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					SegnatureMultipleObj.IdSegnaturaSecondaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SEGNATURA_SECONDARIA"]);
				}
				SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SegnatureMultipleObj.IsDirty = false;
				SegnatureMultipleObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, SegnatureMultiple SegnatureMultipleObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZSegnatureMultipleUpdate", new string[] {"IdSegnaturaSecondaria", "SegnaturaPrincipale", "SegnaturaSecondaria",
"Ordine", "Tipo", "IdRiferimento",
"DataInserimento", "OperatoreInserimento", "DataModifica",
"OperatoreModifica"}, new string[] {"int", "string", "string",
"int", "string", "int",
"DateTime", "string", "DateTime",
"string"}, "");
				CompileIUCmd(true, updateCmd, SegnatureMultipleObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					SegnatureMultipleObj.DataModifica = d;
				}
				SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SegnatureMultipleObj.IsDirty = false;
				SegnatureMultipleObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, SegnatureMultiple SegnatureMultipleObj)
		{
			switch (SegnatureMultipleObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, SegnatureMultipleObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, SegnatureMultipleObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, SegnatureMultipleObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, SegnatureMultipleCollection SegnatureMultipleCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZSegnatureMultipleUpdate", new string[] {"IdSegnaturaSecondaria", "SegnaturaPrincipale", "SegnaturaSecondaria",
"Ordine", "Tipo", "IdRiferimento",
"DataInserimento", "OperatoreInserimento", "DataModifica",
"OperatoreModifica"}, new string[] {"int", "string", "string",
"int", "string", "int",
"DateTime", "string", "DateTime",
"string"}, "");
				IDbCommand insertCmd = db.InitCmd("ZSegnatureMultipleInsert", new string[] {"SegnaturaPrincipale", "SegnaturaSecondaria",
"Ordine", "Tipo", "IdRiferimento",
"DataInserimento", "OperatoreInserimento", "DataModifica",
"OperatoreModifica"}, new string[] {"string", "string",
"int", "string", "int",
"DateTime", "string", "DateTime",
"string"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZSegnatureMultipleDelete", new string[] { "IdSegnaturaSecondaria" }, new string[] { "int" }, "");
				for (int i = 0; i < SegnatureMultipleCollectionObj.Count; i++)
				{
					switch (SegnatureMultipleCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, SegnatureMultipleCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									SegnatureMultipleCollectionObj[i].IdSegnaturaSecondaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SEGNATURA_SECONDARIA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, SegnatureMultipleCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									SegnatureMultipleCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (SegnatureMultipleCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSegnaturaSecondaria", (SiarLibrary.NullTypes.IntNT)SegnatureMultipleCollectionObj[i].IdSegnaturaSecondaria);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < SegnatureMultipleCollectionObj.Count; i++)
				{
					if ((SegnatureMultipleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SegnatureMultipleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SegnatureMultipleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						SegnatureMultipleCollectionObj[i].IsDirty = false;
						SegnatureMultipleCollectionObj[i].IsPersistent = true;
					}
					if ((SegnatureMultipleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						SegnatureMultipleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SegnatureMultipleCollectionObj[i].IsDirty = false;
						SegnatureMultipleCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, SegnatureMultiple SegnatureMultipleObj)
		{
			int returnValue = 0;
			if (SegnatureMultipleObj.IsPersistent)
			{
				returnValue = Delete(db, SegnatureMultipleObj.IdSegnaturaSecondaria);
			}
			SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			SegnatureMultipleObj.IsDirty = false;
			SegnatureMultipleObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdSegnaturaSecondariaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZSegnatureMultipleDelete", new string[] { "IdSegnaturaSecondaria" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSegnaturaSecondaria", (SiarLibrary.NullTypes.IntNT)IdSegnaturaSecondariaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, SegnatureMultipleCollection SegnatureMultipleCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZSegnatureMultipleDelete", new string[] { "IdSegnaturaSecondaria" }, new string[] { "int" }, "");
				for (int i = 0; i < SegnatureMultipleCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdSegnaturaSecondaria", SegnatureMultipleCollectionObj[i].IdSegnaturaSecondaria);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < SegnatureMultipleCollectionObj.Count; i++)
				{
					if ((SegnatureMultipleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (SegnatureMultipleCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						SegnatureMultipleCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						SegnatureMultipleCollectionObj[i].IsDirty = false;
						SegnatureMultipleCollectionObj[i].IsPersistent = false;
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
		public static SegnatureMultiple GetById(DbProvider db, int IdSegnaturaSecondariaValue)
		{
			SegnatureMultiple SegnatureMultipleObj = null;
			IDbCommand readCmd = db.InitCmd("ZSegnatureMultipleGetById", new string[] { "IdSegnaturaSecondaria" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdSegnaturaSecondaria", (SiarLibrary.NullTypes.IntNT)IdSegnaturaSecondariaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				SegnatureMultipleObj = GetFromDatareader(db);
				SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SegnatureMultipleObj.IsDirty = false;
				SegnatureMultipleObj.IsPersistent = true;
			}
			db.Close();
			return SegnatureMultipleObj;
		}

		//getFromDatareader
		public static SegnatureMultiple GetFromDatareader(DbProvider db)
		{
			SegnatureMultiple SegnatureMultipleObj = new SegnatureMultiple();
			SegnatureMultipleObj.IdSegnaturaSecondaria = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SEGNATURA_SECONDARIA"]);
			SegnatureMultipleObj.SegnaturaPrincipale = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_PRINCIPALE"]);
			SegnatureMultipleObj.SegnaturaSecondaria = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDARIA"]);
			SegnatureMultipleObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			SegnatureMultipleObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			SegnatureMultipleObj.IdRiferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RIFERIMENTO"]);
			SegnatureMultipleObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			SegnatureMultipleObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			SegnatureMultipleObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			SegnatureMultipleObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
			SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			SegnatureMultipleObj.IsDirty = false;
			SegnatureMultipleObj.IsPersistent = true;
			return SegnatureMultipleObj;
		}

		//Find Select

		public static SegnatureMultipleCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdSegnaturaSecondariaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaPrincipaleEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondariaEqualThis,
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.IntNT IdRiferimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis)

		{

			SegnatureMultipleCollection SegnatureMultipleCollectionObj = new SegnatureMultipleCollection();

			IDbCommand findCmd = db.InitCmd("Zsegnaturemultiplefindselect", new string[] {"IdSegnaturaSecondariaequalthis", "SegnaturaPrincipaleequalthis", "SegnaturaSecondariaequalthis",
"Ordineequalthis", "Tipoequalthis", "IdRiferimentoequalthis",
"DataInserimentoequalthis", "OperatoreInserimentoequalthis", "DataModificaequalthis",
"OperatoreModificaequalthis"}, new string[] {"int", "string", "string",
"int", "string", "int",
"DateTime", "string", "DateTime",
"string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSegnaturaSecondariaequalthis", IdSegnaturaSecondariaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaPrincipaleequalthis", SegnaturaPrincipaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaSecondariaequalthis", SegnaturaSecondariaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRiferimentoequalthis", IdRiferimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			SegnatureMultiple SegnatureMultipleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SegnatureMultipleObj = GetFromDatareader(db);
				SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SegnatureMultipleObj.IsDirty = false;
				SegnatureMultipleObj.IsPersistent = true;
				SegnatureMultipleCollectionObj.Add(SegnatureMultipleObj);
			}
			db.Close();
			return SegnatureMultipleCollectionObj;
		}

		//Find FindPerSignaturaPrincipale

		public static SegnatureMultipleCollection FindPerSignaturaPrincipale(DbProvider db, SiarLibrary.NullTypes.StringNT SegnaturaPrincipaleEqualThis)

		{

			SegnatureMultipleCollection SegnatureMultipleCollectionObj = new SegnatureMultipleCollection();

			IDbCommand findCmd = db.InitCmd("Zsegnaturemultiplefindfindpersignaturaprincipale", new string[] { "SegnaturaPrincipaleequalthis" }, new string[] { "string" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaPrincipaleequalthis", SegnaturaPrincipaleEqualThis);
			SegnatureMultiple SegnatureMultipleObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				SegnatureMultipleObj = GetFromDatareader(db);
				SegnatureMultipleObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				SegnatureMultipleObj.IsDirty = false;
				SegnatureMultipleObj.IsPersistent = true;
				SegnatureMultipleCollectionObj.Add(SegnatureMultipleObj);
			}
			db.Close();
			return SegnatureMultipleCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for SegnatureMultipleCollectionProvider:ISegnatureMultipleProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class SegnatureMultipleCollectionProvider : ISegnatureMultipleProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di SegnatureMultiple
		protected SegnatureMultipleCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public SegnatureMultipleCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new SegnatureMultipleCollection(this);
		}

		//Costruttore 2: popola la collection
		public SegnatureMultipleCollectionProvider(StringNT SegnaturaprincipaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindPerSignaturaPrincipale(SegnaturaprincipaleEqualThis);
		}

		//Costruttore3: ha in input segnaturemultipleCollectionObj - non popola la collection
		public SegnatureMultipleCollectionProvider(SegnatureMultipleCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public SegnatureMultipleCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new SegnatureMultipleCollection(this);
		}

		//Get e Set
		public SegnatureMultipleCollection CollectionObj
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
		public int SaveCollection(SegnatureMultipleCollection collectionObj)
		{
			return SegnatureMultipleDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(SegnatureMultiple segnaturemultipleObj)
		{
			return SegnatureMultipleDAL.Save(_dbProviderObj, segnaturemultipleObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(SegnatureMultipleCollection collectionObj)
		{
			return SegnatureMultipleDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(SegnatureMultiple segnaturemultipleObj)
		{
			return SegnatureMultipleDAL.Delete(_dbProviderObj, segnaturemultipleObj);
		}

		//getById
		public SegnatureMultiple GetById(IntNT IdSegnaturaSecondariaValue)
		{
			SegnatureMultiple SegnatureMultipleTemp = SegnatureMultipleDAL.GetById(_dbProviderObj, IdSegnaturaSecondariaValue);
			if (SegnatureMultipleTemp != null) SegnatureMultipleTemp.Provider = this;
			return SegnatureMultipleTemp;
		}

		//Select: popola la collection
		public SegnatureMultipleCollection Select(IntNT IdsegnaturasecondariaEqualThis, StringNT SegnaturaprincipaleEqualThis, StringNT SegnaturasecondariaEqualThis,
IntNT OrdineEqualThis, StringNT TipoEqualThis, IntNT IdriferimentoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT OperatoreinserimentoEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT OperatoremodificaEqualThis)
		{
			SegnatureMultipleCollection SegnatureMultipleCollectionTemp = SegnatureMultipleDAL.Select(_dbProviderObj, IdsegnaturasecondariaEqualThis, SegnaturaprincipaleEqualThis, SegnaturasecondariaEqualThis,
OrdineEqualThis, TipoEqualThis, IdriferimentoEqualThis,
DatainserimentoEqualThis, OperatoreinserimentoEqualThis, DatamodificaEqualThis,
OperatoremodificaEqualThis);
			SegnatureMultipleCollectionTemp.Provider = this;
			return SegnatureMultipleCollectionTemp;
		}

		//FindPerSignaturaPrincipale: popola la collection
		public SegnatureMultipleCollection FindPerSignaturaPrincipale(StringNT SegnaturaprincipaleEqualThis)
		{
			SegnatureMultipleCollection SegnatureMultipleCollectionTemp = SegnatureMultipleDAL.FindPerSignaturaPrincipale(_dbProviderObj, SegnaturaprincipaleEqualThis);
			SegnatureMultipleCollectionTemp.Provider = this;
			return SegnatureMultipleCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<SEGNATURE_MULTIPLE>
  <ViewName>VSEGNATURE_MULTIPLE</ViewName>
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
    <FindPerSignaturaPrincipale OrderBy="ORDER BY ">
      <SEGNATURA_PRINCIPALE>Equal</SEGNATURA_PRINCIPALE>
    </FindPerSignaturaPrincipale>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SEGNATURE_MULTIPLE>
*/
