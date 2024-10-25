using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ChecklistGenerica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IChecklistGenericaProvider
	{
		int Save(ChecklistGenerica ChecklistGenericaObj);
		int SaveCollection(ChecklistGenericaCollection collectionObj);
		int Delete(ChecklistGenerica ChecklistGenericaObj);
		int DeleteCollection(ChecklistGenericaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ChecklistGenerica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ChecklistGenerica : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.IntNT _IdTipo;
		private NullTypes.StringNT _IdFiltro;
		private NullTypes.StringNT _DescrizioneTipo;
		private NullTypes.BoolNT _ContieneVociTipo;
		private NullTypes.BoolNT _SchedaTipo;
		private NullTypes.StringNT _DescrizioneFiltro;
		private NullTypes.IntNT _OrdineFiltro;
		[NonSerialized] private IChecklistGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IChecklistGenericaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public ChecklistGenerica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistGenerica
		{
			get { return _IdChecklistGenerica; }
			set
			{
				if (IdChecklistGenerica != value)
				{
					_IdChecklistGenerica = value;
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
		/// Corrisponde al campo:FLAG_TEMPLATE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplate
		{
			get { return _FlagTemplate; }
			set
			{
				if (FlagTemplate != value)
				{
					_FlagTemplate = value;
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
		/// Tipo sul db:CHAR(16)
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
		/// Tipo sul db:CHAR(16)
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
		/// Corrisponde al campo:ID_TIPO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipo
		{
			get { return _IdTipo; }
			set
			{
				if (IdTipo != value)
				{
					_IdTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltro
		{
			get { return _IdFiltro; }
			set
			{
				if (IdFiltro != value)
				{
					_IdFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipo
		{
			get { return _DescrizioneTipo; }
			set
			{
				if (DescrizioneTipo != value)
				{
					_DescrizioneTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI_TIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVociTipo
		{
			get { return _ContieneVociTipo; }
			set
			{
				if (ContieneVociTipo != value)
				{
					_ContieneVociTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA_TIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SchedaTipo
		{
			get { return _SchedaTipo; }
			set
			{
				if (SchedaTipo != value)
				{
					_SchedaTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltro
		{
			get { return _DescrizioneFiltro; }
			set
			{
				if (DescrizioneFiltro != value)
				{
					_DescrizioneFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltro
		{
			get { return _OrdineFiltro; }
			set
			{
				if (OrdineFiltro != value)
				{
					_OrdineFiltro = value;
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
	/// Summary description for ChecklistGenericaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ChecklistGenericaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ChecklistGenericaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((ChecklistGenerica)info.GetValue(i.ToString(), typeof(ChecklistGenerica)));
			}
		}

		//Costruttore
		public ChecklistGenericaCollection()
		{
			this.ItemType = typeof(ChecklistGenerica);
		}

		//Costruttore con provider
		public ChecklistGenericaCollection(IChecklistGenericaProvider providerObj)
		{
			this.ItemType = typeof(ChecklistGenerica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ChecklistGenerica this[int index]
		{
			get { return (ChecklistGenerica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ChecklistGenericaCollection GetChanges()
		{
			return (ChecklistGenericaCollection)base.GetChanges();
		}

		[NonSerialized] private IChecklistGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IChecklistGenericaProvider Provider
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
		public int Add(ChecklistGenerica ChecklistGenericaObj)
		{
			if (ChecklistGenericaObj.Provider == null) ChecklistGenericaObj.Provider = this.Provider;
			return base.Add(ChecklistGenericaObj);
		}

		//AddCollection
		public void AddCollection(ChecklistGenericaCollection ChecklistGenericaCollectionObj)
		{
			foreach (ChecklistGenerica ChecklistGenericaObj in ChecklistGenericaCollectionObj)
				this.Add(ChecklistGenericaObj);
		}

		//Insert
		public void Insert(int index, ChecklistGenerica ChecklistGenericaObj)
		{
			if (ChecklistGenericaObj.Provider == null) ChecklistGenericaObj.Provider = this.Provider;
			base.Insert(index, ChecklistGenericaObj);
		}

		//CollectionGetById
		public ChecklistGenerica CollectionGetById(NullTypes.IntNT IdChecklistGenericaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdChecklistGenerica == IdChecklistGenericaValue))
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
		public ChecklistGenericaCollection SubSelect(NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagTemplateEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdTipoEqualThis, NullTypes.StringNT IdFiltroEqualThis)
		{
			ChecklistGenericaCollection ChecklistGenericaCollectionTemp = new ChecklistGenericaCollection();
			foreach (ChecklistGenerica ChecklistGenericaItem in this)
			{
				if (((IdChecklistGenericaEqualThis == null) || ((ChecklistGenericaItem.IdChecklistGenerica != null) && (ChecklistGenericaItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ChecklistGenericaItem.Descrizione != null) && (ChecklistGenericaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagTemplateEqualThis == null) || ((ChecklistGenericaItem.FlagTemplate != null) && (ChecklistGenericaItem.FlagTemplate.Value == FlagTemplateEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((ChecklistGenericaItem.DataInserimento != null) && (ChecklistGenericaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((ChecklistGenericaItem.CfInserimento != null) && (ChecklistGenericaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ChecklistGenericaItem.DataModifica != null) && (ChecklistGenericaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((ChecklistGenericaItem.CfModifica != null) && (ChecklistGenericaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdTipoEqualThis == null) || ((ChecklistGenericaItem.IdTipo != null) && (ChecklistGenericaItem.IdTipo.Value == IdTipoEqualThis.Value))) && ((IdFiltroEqualThis == null) || ((ChecklistGenericaItem.IdFiltro != null) && (ChecklistGenericaItem.IdFiltro.Value == IdFiltroEqualThis.Value))))
				{
					ChecklistGenericaCollectionTemp.Add(ChecklistGenericaItem);
				}
			}
			return ChecklistGenericaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ChecklistGenericaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ChecklistGenericaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ChecklistGenerica ChecklistGenericaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdChecklistGenerica", ChecklistGenericaObj.IdChecklistGenerica);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ChecklistGenericaObj.Descrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "FlagTemplate", ChecklistGenericaObj.FlagTemplate);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ChecklistGenericaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", ChecklistGenericaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ChecklistGenericaObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", ChecklistGenericaObj.CfModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "IdTipo", ChecklistGenericaObj.IdTipo);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFiltro", ChecklistGenericaObj.IdFiltro);
		}
		//Insert
		private static int Insert(DbProvider db, ChecklistGenerica ChecklistGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZChecklistGenericaInsert", new string[] {"Descrizione", "FlagTemplate",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "IdTipo", "IdFiltro",
}, new string[] {"string", "bool",
"DateTime", "string", "DateTime",
"string", "int", "string",
}, "");
				CompileIUCmd(false, insertCmd, ChecklistGenericaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					ChecklistGenericaObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
					ChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
					ChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ChecklistGenerica ChecklistGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZChecklistGenericaUpdate", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "IdTipo", "IdFiltro",
}, new string[] {"int", "string", "bool",
"DateTime", "string", "DateTime",
"string", "int", "string",
}, "");
				CompileIUCmd(true, updateCmd, ChecklistGenericaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					ChecklistGenericaObj.DataModifica = d;
				}
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ChecklistGenerica ChecklistGenericaObj)
		{
			switch (ChecklistGenericaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ChecklistGenericaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ChecklistGenericaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ChecklistGenericaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ChecklistGenericaCollection ChecklistGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZChecklistGenericaUpdate", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "IdTipo", "IdFiltro",
}, new string[] {"int", "string", "bool",
"DateTime", "string", "DateTime",
"string", "int", "string",
}, "");
				IDbCommand insertCmd = db.InitCmd("ZChecklistGenericaInsert", new string[] {"Descrizione", "FlagTemplate",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "IdTipo", "IdFiltro",
}, new string[] {"string", "bool",
"DateTime", "string", "DateTime",
"string", "int", "string",
}, "");
				IDbCommand deleteCmd = db.InitCmd("ZChecklistGenericaDelete", new string[] { "IdChecklistGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < ChecklistGenericaCollectionObj.Count; i++)
				{
					switch (ChecklistGenericaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ChecklistGenericaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ChecklistGenericaCollectionObj[i].IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
									ChecklistGenericaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									ChecklistGenericaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ChecklistGenericaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									ChecklistGenericaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ChecklistGenericaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdChecklistGenerica", (SiarLibrary.NullTypes.IntNT)ChecklistGenericaCollectionObj[i].IdChecklistGenerica);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ChecklistGenericaCollectionObj.Count; i++)
				{
					if ((ChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ChecklistGenericaCollectionObj[i].IsDirty = false;
						ChecklistGenericaCollectionObj[i].IsPersistent = true;
					}
					if ((ChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ChecklistGenericaCollectionObj[i].IsDirty = false;
						ChecklistGenericaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ChecklistGenerica ChecklistGenericaObj)
		{
			int returnValue = 0;
			if (ChecklistGenericaObj.IsPersistent)
			{
				returnValue = Delete(db, ChecklistGenericaObj.IdChecklistGenerica);
			}
			ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ChecklistGenericaObj.IsDirty = false;
			ChecklistGenericaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdChecklistGenericaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZChecklistGenericaDelete", new string[] { "IdChecklistGenerica" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdChecklistGenerica", (SiarLibrary.NullTypes.IntNT)IdChecklistGenericaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ChecklistGenericaCollection ChecklistGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZChecklistGenericaDelete", new string[] { "IdChecklistGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < ChecklistGenericaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdChecklistGenerica", ChecklistGenericaCollectionObj[i].IdChecklistGenerica);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ChecklistGenericaCollectionObj.Count; i++)
				{
					if ((ChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ChecklistGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ChecklistGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ChecklistGenericaCollectionObj[i].IsDirty = false;
						ChecklistGenericaCollectionObj[i].IsPersistent = false;
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
		public static ChecklistGenerica GetById(DbProvider db, int IdChecklistGenericaValue)
		{
			ChecklistGenerica ChecklistGenericaObj = null;
			IDbCommand readCmd = db.InitCmd("ZChecklistGenericaGetById", new string[] { "IdChecklistGenerica" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdChecklistGenerica", (SiarLibrary.NullTypes.IntNT)IdChecklistGenericaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ChecklistGenericaObj = GetFromDatareader(db);
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
			}
			db.Close();
			return ChecklistGenericaObj;
		}

		//getFromDatareader
		public static ChecklistGenerica GetFromDatareader(DbProvider db)
		{
			ChecklistGenerica ChecklistGenericaObj = new ChecklistGenerica();
			ChecklistGenericaObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			ChecklistGenericaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ChecklistGenericaObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			ChecklistGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ChecklistGenericaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			ChecklistGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ChecklistGenericaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			ChecklistGenericaObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
			ChecklistGenericaObj.IdFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO"]);
			ChecklistGenericaObj.DescrizioneTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO"]);
			ChecklistGenericaObj.ContieneVociTipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_TIPO"]);
			ChecklistGenericaObj.SchedaTipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_TIPO"]);
			ChecklistGenericaObj.DescrizioneFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO"]);
			ChecklistGenericaObj.OrdineFiltro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO"]);
			ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ChecklistGenericaObj.IsDirty = false;
			ChecklistGenericaObj.IsPersistent = true;
			return ChecklistGenericaObj;
		}

		//Find Select

		public static ChecklistGenericaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis)

		{

			ChecklistGenericaCollection ChecklistGenericaCollectionObj = new ChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistgenericafindselect", new string[] {"IdChecklistGenericaequalthis", "Descrizioneequalthis", "FlagTemplateequalthis",
"DataInserimentoequalthis", "CfInserimentoequalthis", "DataModificaequalthis",
"CfModificaequalthis", "IdTipoequalthis", "IdFiltroequalthis"}, new string[] {"int", "string", "bool",
"DateTime", "string", "DateTime",
"string", "int", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			ChecklistGenerica ChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ChecklistGenericaObj = GetFromDatareader(db);
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
				ChecklistGenericaCollectionObj.Add(ChecklistGenericaObj);
			}
			db.Close();
			return ChecklistGenericaCollectionObj;
		}

		//Find Find

		public static ChecklistGenericaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis)

		{

			ChecklistGenericaCollection ChecklistGenericaCollectionObj = new ChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistgenericafindfind", new string[] { "Descrizionelikethis", "FlagTemplateequalthis" }, new string[] { "string", "bool" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			ChecklistGenerica ChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ChecklistGenericaObj = GetFromDatareader(db);
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
				ChecklistGenericaCollectionObj.Add(ChecklistGenericaObj);
			}
			db.Close();
			return ChecklistGenericaCollectionObj;
		}

		//Find FindChecklist

		public static ChecklistGenericaCollection FindChecklist(DbProvider db, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, SiarLibrary.NullTypes.IntNT IdTipoEqualThis,
SiarLibrary.NullTypes.StringNT IdFiltroEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneTipoEqualThis, SiarLibrary.NullTypes.BoolNT ContieneVociTipoEqualThis,
SiarLibrary.NullTypes.BoolNT SchedaTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneFiltroEqualThis, SiarLibrary.NullTypes.IntNT OrdineFiltroEqualThis)

		{

			ChecklistGenericaCollection ChecklistGenericaCollectionObj = new ChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistgenericafindfindchecklist", new string[] {"Descrizioneequalthis", "FlagTemplateequalthis", "IdTipoequalthis",
"IdFiltroequalthis", "DescrizioneTipoequalthis", "ContieneVociTipoequalthis",
"SchedaTipoequalthis", "DescrizioneFiltroequalthis", "OrdineFiltroequalthis"}, new string[] {"string", "bool", "int",
"string", "string", "bool",
"bool", "string", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneTipoequalthis", DescrizioneTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContieneVociTipoequalthis", ContieneVociTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SchedaTipoequalthis", SchedaTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneFiltroequalthis", DescrizioneFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineFiltroequalthis", OrdineFiltroEqualThis);
			ChecklistGenerica ChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ChecklistGenericaObj = GetFromDatareader(db);
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
				ChecklistGenericaCollectionObj.Add(ChecklistGenericaObj);
			}
			db.Close();
			return ChecklistGenericaCollectionObj;
		}

		//Find RicercaChecklist

		public static ChecklistGenericaCollection RicercaChecklist(DbProvider db, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneTipoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis,
SiarLibrary.NullTypes.StringNT DescrizioneFiltroEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis)

		{

			ChecklistGenericaCollection ChecklistGenericaCollectionObj = new ChecklistGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistgenericafindricercachecklist", new string[] {"IdChecklistGenericaequalthis", "DescrizioneTipoequalthis", "Descrizionelikethis",
"DescrizioneFiltroequalthis", "FlagTemplateequalthis"}, new string[] {"int", "string", "string",
"string", "bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneTipoequalthis", DescrizioneTipoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneFiltroequalthis", DescrizioneFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			ChecklistGenerica ChecklistGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ChecklistGenericaObj = GetFromDatareader(db);
				ChecklistGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaObj.IsDirty = false;
				ChecklistGenericaObj.IsPersistent = true;
				ChecklistGenericaCollectionObj.Add(ChecklistGenericaObj);
			}
			db.Close();
			return ChecklistGenericaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ChecklistGenericaCollectionProvider:IChecklistGenericaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ChecklistGenericaCollectionProvider : IChecklistGenericaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ChecklistGenerica
		protected ChecklistGenericaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ChecklistGenericaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ChecklistGenericaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ChecklistGenericaCollectionProvider(StringNT DescrizioneLikeThis, BoolNT FlagtemplateEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(DescrizioneLikeThis, FlagtemplateEqualThis);
		}

		//Costruttore3: ha in input checklistgenericaCollectionObj - non popola la collection
		public ChecklistGenericaCollectionProvider(ChecklistGenericaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ChecklistGenericaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ChecklistGenericaCollection(this);
		}

		//Get e Set
		public ChecklistGenericaCollection CollectionObj
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
		public int SaveCollection(ChecklistGenericaCollection collectionObj)
		{
			return ChecklistGenericaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ChecklistGenerica checklistgenericaObj)
		{
			return ChecklistGenericaDAL.Save(_dbProviderObj, checklistgenericaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ChecklistGenericaCollection collectionObj)
		{
			return ChecklistGenericaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ChecklistGenerica checklistgenericaObj)
		{
			return ChecklistGenericaDAL.Delete(_dbProviderObj, checklistgenericaObj);
		}

		//getById
		public ChecklistGenerica GetById(IntNT IdChecklistGenericaValue)
		{
			ChecklistGenerica ChecklistGenericaTemp = ChecklistGenericaDAL.GetById(_dbProviderObj, IdChecklistGenericaValue);
			if (ChecklistGenericaTemp != null) ChecklistGenericaTemp.Provider = this;
			return ChecklistGenericaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ChecklistGenericaCollection Select(IntNT IdchecklistgenericaEqualThis, StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT CfmodificaEqualThis, IntNT IdtipoEqualThis, StringNT IdfiltroEqualThis)
		{
			ChecklistGenericaCollection ChecklistGenericaCollectionTemp = ChecklistGenericaDAL.Select(_dbProviderObj, IdchecklistgenericaEqualThis, DescrizioneEqualThis, FlagtemplateEqualThis,
DatainserimentoEqualThis, CfinserimentoEqualThis, DatamodificaEqualThis,
CfmodificaEqualThis, IdtipoEqualThis, IdfiltroEqualThis);
			ChecklistGenericaCollectionTemp.Provider = this;
			return ChecklistGenericaCollectionTemp;
		}

		//Find: popola la collection
		public ChecklistGenericaCollection Find(StringNT DescrizioneLikeThis, BoolNT FlagtemplateEqualThis)
		{
			ChecklistGenericaCollection ChecklistGenericaCollectionTemp = ChecklistGenericaDAL.Find(_dbProviderObj, DescrizioneLikeThis, FlagtemplateEqualThis);
			ChecklistGenericaCollectionTemp.Provider = this;
			return ChecklistGenericaCollectionTemp;
		}

		//FindChecklist: popola la collection
		public ChecklistGenericaCollection FindChecklist(StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis, IntNT IdtipoEqualThis,
StringNT IdfiltroEqualThis, StringNT DescrizionetipoEqualThis, BoolNT ContienevocitipoEqualThis,
BoolNT SchedatipoEqualThis, StringNT DescrizionefiltroEqualThis, IntNT OrdinefiltroEqualThis)
		{
			ChecklistGenericaCollection ChecklistGenericaCollectionTemp = ChecklistGenericaDAL.FindChecklist(_dbProviderObj, DescrizioneEqualThis, FlagtemplateEqualThis, IdtipoEqualThis,
IdfiltroEqualThis, DescrizionetipoEqualThis, ContienevocitipoEqualThis,
SchedatipoEqualThis, DescrizionefiltroEqualThis, OrdinefiltroEqualThis);
			ChecklistGenericaCollectionTemp.Provider = this;
			return ChecklistGenericaCollectionTemp;
		}

		//RicercaChecklist: popola la collection
		public ChecklistGenericaCollection RicercaChecklist(IntNT IdchecklistgenericaEqualThis, StringNT DescrizionetipoEqualThis, StringNT DescrizioneLikeThis,
StringNT DescrizionefiltroEqualThis, BoolNT FlagtemplateEqualThis)
		{
			ChecklistGenericaCollection ChecklistGenericaCollectionTemp = ChecklistGenericaDAL.RicercaChecklist(_dbProviderObj, IdchecklistgenericaEqualThis, DescrizionetipoEqualThis, DescrizioneLikeThis,
DescrizionefiltroEqualThis, FlagtemplateEqualThis);
			ChecklistGenericaCollectionTemp.Provider = this;
			return ChecklistGenericaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECKLIST_GENERICA>
  <ViewName>VCHECKLIST_GENERICA</ViewName>
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
      <DESCRIZIONE>Like</DESCRIZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
    </Find>
    <FindChecklist OrderBy="ORDER BY ">
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <ID_TIPO>Equal</ID_TIPO>
      <ID_FILTRO>Equal</ID_FILTRO>
      <DESCRIZIONE_TIPO>Equal</DESCRIZIONE_TIPO>
      <CONTIENE_VOCI_TIPO>Equal</CONTIENE_VOCI_TIPO>
      <SCHEDA_TIPO>Equal</SCHEDA_TIPO>
      <DESCRIZIONE_FILTRO>Equal</DESCRIZIONE_FILTRO>
      <ORDINE_FILTRO>Equal</ORDINE_FILTRO>
    </FindChecklist>
    <RicercaChecklist OrderBy="ORDER BY ">
      <ID_CHECKLIST_GENERICA>Equal</ID_CHECKLIST_GENERICA>
      <DESCRIZIONE_TIPO>Equal</DESCRIZIONE_TIPO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <DESCRIZIONE_FILTRO>Equal</DESCRIZIONE_FILTRO>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
    </RicercaChecklist>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CHECKLIST_GENERICA>
*/
