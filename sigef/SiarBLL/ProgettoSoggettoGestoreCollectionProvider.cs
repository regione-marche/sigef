using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoSoggettoGestore
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoSoggettoGestoreProvider
	{
		int Save(ProgettoSoggettoGestore ProgettoSoggettoGestoreObj);
		int SaveCollection(ProgettoSoggettoGestoreCollection collectionObj);
		int Delete(ProgettoSoggettoGestore ProgettoSoggettoGestoreObj);
		int DeleteCollection(ProgettoSoggettoGestoreCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoSoggettoGestore
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoSoggettoGestore : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgettoSoggettoGestore;
		private NullTypes.IntNT _IdSoggettoGestore;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _DenominazioneSoggettoGestore;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _Asse;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgettoRiferimento;
		private NullTypes.IntNT _OperatoreCreazione;
		[NonSerialized] private IProgettoSoggettoGestoreProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettoSoggettoGestoreProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public ProgettoSoggettoGestore()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO_SOGGETTO_GESTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoSoggettoGestore
		{
			get { return _IdProgettoSoggettoGestore; }
			set
			{
				if (IdProgettoSoggettoGestore != value)
				{
					_IdProgettoSoggettoGestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SOGGETTO_GESTORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSoggettoGestore
		{
			get { return _IdSoggettoGestore; }
			set
			{
				if (IdSoggettoGestore != value)
				{
					_IdSoggettoGestore = value;
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
		/// Corrisponde al campo:DENOMINAZIONE_SOGGETTO_GESTORE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DenominazioneSoggettoGestore
		{
			get { return _DenominazioneSoggettoGestore; }
			set
			{
				if (DenominazioneSoggettoGestore != value)
				{
					_DenominazioneSoggettoGestore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set
			{
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set
			{
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set
			{
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ASSE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Asse
		{
			get { return _Asse; }
			set
			{
				if (Asse != value)
				{
					_Asse = value;
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
		/// Corrisponde al campo:ID_PROGETTO_RIFERIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoRiferimento
		{
			get { return _IdProgettoRiferimento; }
			set
			{
				if (IdProgettoRiferimento != value)
				{
					_IdProgettoRiferimento = value;
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
			set
			{
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
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
	/// Summary description for ProgettoSoggettoGestoreCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoSoggettoGestoreCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoSoggettoGestoreCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((ProgettoSoggettoGestore)info.GetValue(i.ToString(), typeof(ProgettoSoggettoGestore)));
			}
		}

		//Costruttore
		public ProgettoSoggettoGestoreCollection()
		{
			this.ItemType = typeof(ProgettoSoggettoGestore);
		}

		//Costruttore con provider
		public ProgettoSoggettoGestoreCollection(IProgettoSoggettoGestoreProvider providerObj)
		{
			this.ItemType = typeof(ProgettoSoggettoGestore);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoSoggettoGestore this[int index]
		{
			get { return (ProgettoSoggettoGestore)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoSoggettoGestoreCollection GetChanges()
		{
			return (ProgettoSoggettoGestoreCollection)base.GetChanges();
		}

		[NonSerialized] private IProgettoSoggettoGestoreProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettoSoggettoGestoreProvider Provider
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
		public int Add(ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			if (ProgettoSoggettoGestoreObj.Provider == null) ProgettoSoggettoGestoreObj.Provider = this.Provider;
			return base.Add(ProgettoSoggettoGestoreObj);
		}

		//AddCollection
		public void AddCollection(ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj)
		{
			foreach (ProgettoSoggettoGestore ProgettoSoggettoGestoreObj in ProgettoSoggettoGestoreCollectionObj)
				this.Add(ProgettoSoggettoGestoreObj);
		}

		//Insert
		public void Insert(int index, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			if (ProgettoSoggettoGestoreObj.Provider == null) ProgettoSoggettoGestoreObj.Provider = this.Provider;
			base.Insert(index, ProgettoSoggettoGestoreObj);
		}

		//CollectionGetById
		public ProgettoSoggettoGestore CollectionGetById(NullTypes.IntNT IdProgettoSoggettoGestoreValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdProgettoSoggettoGestore == IdProgettoSoggettoGestoreValue))
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
		public ProgettoSoggettoGestoreCollection SubSelect(NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoRiferimentoEqualThis,
NullTypes.IntNT IdSoggettoGestoreEqualThis)
		{
			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionTemp = new ProgettoSoggettoGestoreCollection();
			foreach (ProgettoSoggettoGestore ProgettoSoggettoGestoreItem in this)
			{
				if (((IdProgettoSoggettoGestoreEqualThis == null) || ((ProgettoSoggettoGestoreItem.IdProgettoSoggettoGestore != null) && (ProgettoSoggettoGestoreItem.IdProgettoSoggettoGestore.Value == IdProgettoSoggettoGestoreEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ProgettoSoggettoGestoreItem.IdBando != null) && (ProgettoSoggettoGestoreItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoRiferimentoEqualThis == null) || ((ProgettoSoggettoGestoreItem.IdProgettoRiferimento != null) && (ProgettoSoggettoGestoreItem.IdProgettoRiferimento.Value == IdProgettoRiferimentoEqualThis.Value))) &&
((IdSoggettoGestoreEqualThis == null) || ((ProgettoSoggettoGestoreItem.IdSoggettoGestore != null) && (ProgettoSoggettoGestoreItem.IdSoggettoGestore.Value == IdSoggettoGestoreEqualThis.Value))))
				{
					ProgettoSoggettoGestoreCollectionTemp.Add(ProgettoSoggettoGestoreItem);
				}
			}
			return ProgettoSoggettoGestoreCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoSoggettoGestoreDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoSoggettoGestoreDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoSoggettoGestore", ProgettoSoggettoGestoreObj.IdProgettoSoggettoGestore);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "IdSoggettoGestore", ProgettoSoggettoGestoreObj.IdSoggettoGestore);
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", ProgettoSoggettoGestoreObj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoRiferimento", ProgettoSoggettoGestoreObj.IdProgettoRiferimento);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZProgettoSoggettoGestoreInsert", new string[] {"IdSoggettoGestore",

"IdBando",
"IdProgettoRiferimento"}, new string[] {"int",

"int",
"int"}, "");
				CompileIUCmd(false, insertCmd, ProgettoSoggettoGestoreObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					ProgettoSoggettoGestoreObj.IdProgettoSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_SOGGETTO_GESTORE"]);
				}
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettoSoggettoGestoreUpdate", new string[] {"IdProgettoSoggettoGestore", "IdSoggettoGestore",

"IdBando",
"IdProgettoRiferimento"}, new string[] {"int", "int",

"int",
"int"}, "");
				CompileIUCmd(true, updateCmd, ProgettoSoggettoGestoreObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			switch (ProgettoSoggettoGestoreObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ProgettoSoggettoGestoreObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ProgettoSoggettoGestoreObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettoSoggettoGestoreObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettoSoggettoGestoreUpdate", new string[] {"IdProgettoSoggettoGestore", "IdSoggettoGestore",

"IdBando",
"IdProgettoRiferimento"}, new string[] {"int", "int",

"int",
"int"}, "");
				IDbCommand insertCmd = db.InitCmd("ZProgettoSoggettoGestoreInsert", new string[] {"IdSoggettoGestore",

"IdBando",
"IdProgettoRiferimento"}, new string[] {"int",

"int",
"int"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZProgettoSoggettoGestoreDelete", new string[] { "IdProgettoSoggettoGestore" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettoSoggettoGestoreCollectionObj.Count; i++)
				{
					switch (ProgettoSoggettoGestoreCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ProgettoSoggettoGestoreCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoSoggettoGestoreCollectionObj[i].IdProgettoSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_SOGGETTO_GESTORE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ProgettoSoggettoGestoreCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ProgettoSoggettoGestoreCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoSoggettoGestore", (SiarLibrary.NullTypes.IntNT)ProgettoSoggettoGestoreCollectionObj[i].IdProgettoSoggettoGestore);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoSoggettoGestoreCollectionObj.Count; i++)
				{
					if ((ProgettoSoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoSoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoSoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoSoggettoGestoreCollectionObj[i].IsDirty = false;
						ProgettoSoggettoGestoreCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoSoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoSoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoSoggettoGestoreCollectionObj[i].IsDirty = false;
						ProgettoSoggettoGestoreCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoSoggettoGestore ProgettoSoggettoGestoreObj)
		{
			int returnValue = 0;
			if (ProgettoSoggettoGestoreObj.IsPersistent)
			{
				returnValue = Delete(db, ProgettoSoggettoGestoreObj.IdProgettoSoggettoGestore);
			}
			ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoSoggettoGestoreObj.IsDirty = false;
			ProgettoSoggettoGestoreObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProgettoSoggettoGestoreValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettoSoggettoGestoreDelete", new string[] { "IdProgettoSoggettoGestore" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoSoggettoGestore", (SiarLibrary.NullTypes.IntNT)IdProgettoSoggettoGestoreValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettoSoggettoGestoreDelete", new string[] { "IdProgettoSoggettoGestore" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettoSoggettoGestoreCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdProgettoSoggettoGestore", ProgettoSoggettoGestoreCollectionObj[i].IdProgettoSoggettoGestore);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoSoggettoGestoreCollectionObj.Count; i++)
				{
					if ((ProgettoSoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoSoggettoGestoreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoSoggettoGestoreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoSoggettoGestoreCollectionObj[i].IsDirty = false;
						ProgettoSoggettoGestoreCollectionObj[i].IsPersistent = false;
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
		public static ProgettoSoggettoGestore GetById(DbProvider db, int IdProgettoSoggettoGestoreValue)
		{
			ProgettoSoggettoGestore ProgettoSoggettoGestoreObj = null;
			IDbCommand readCmd = db.InitCmd("ZProgettoSoggettoGestoreGetById", new string[] { "IdProgettoSoggettoGestore" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdProgettoSoggettoGestore", (SiarLibrary.NullTypes.IntNT)IdProgettoSoggettoGestoreValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoSoggettoGestoreObj = GetFromDatareader(db);
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoSoggettoGestoreObj;
		}

		//getFromDatareader
		public static ProgettoSoggettoGestore GetFromDatareader(DbProvider db)
		{
			ProgettoSoggettoGestore ProgettoSoggettoGestoreObj = new ProgettoSoggettoGestore();
			ProgettoSoggettoGestoreObj.IdProgettoSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_SOGGETTO_GESTORE"]);
			ProgettoSoggettoGestoreObj.IdSoggettoGestore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOGGETTO_GESTORE"]);
			ProgettoSoggettoGestoreObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ProgettoSoggettoGestoreObj.DenominazioneSoggettoGestore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DENOMINAZIONE_SOGGETTO_GESTORE"]);
			ProgettoSoggettoGestoreObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			ProgettoSoggettoGestoreObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			ProgettoSoggettoGestoreObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			ProgettoSoggettoGestoreObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ASSE"]);
			ProgettoSoggettoGestoreObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettoSoggettoGestoreObj.IdProgettoRiferimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_RIFERIMENTO"]);
			ProgettoSoggettoGestoreObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoSoggettoGestoreObj.IsDirty = false;
			ProgettoSoggettoGestoreObj.IsPersistent = true;
			return ProgettoSoggettoGestoreObj;
		}

		//Find Select

		public static ProgettoSoggettoGestoreCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoSoggettoGestoreEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoRiferimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis)

		{

			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettosoggettogestorefindselect", new string[] {"IdProgettoSoggettoGestoreequalthis", "IdBandoequalthis", "IdProgettoRiferimentoequalthis",
"IdSoggettoGestoreequalthis"}, new string[] {"int", "int", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoSoggettoGestoreequalthis", IdProgettoSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoRiferimentoequalthis", IdProgettoRiferimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoSoggettoGestoreObj = GetFromDatareader(db);
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
				ProgettoSoggettoGestoreCollectionObj.Add(ProgettoSoggettoGestoreObj);
			}
			db.Close();
			return ProgettoSoggettoGestoreCollectionObj;
		}

		//Find FindProgettiSoggettoGestore

		public static ProgettoSoggettoGestoreCollection FindProgettiSoggettoGestore(DbProvider db, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis,
SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoRiferimentoEqualThis)

		{

			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettosoggettogestorefindfindprogettisoggettogestore", new string[] {"IdSoggettoGestoreequalthis", "IdImpresaequalthis", "Cuaaequalthis",
"CodiceFiscaleequalthis", "Asseequalthis", "IdBandoequalthis",
"IdProgettoRiferimentoequalthis"}, new string[] {"int", "int", "string",
"string", "string", "int",
"int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoRiferimentoequalthis", IdProgettoRiferimentoEqualThis);
			ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoSoggettoGestoreObj = GetFromDatareader(db);
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
				ProgettoSoggettoGestoreCollectionObj.Add(ProgettoSoggettoGestoreObj);
			}
			db.Close();
			return ProgettoSoggettoGestoreCollectionObj;
		}

		//Find FindOperatoreCreazioneSoggettoGestore

		public static ProgettoSoggettoGestoreCollection FindOperatoreCreazioneSoggettoGestore(DbProvider db, SiarLibrary.NullTypes.IntNT IdSoggettoGestoreEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoRiferimentoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis)

		{

			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionObj = new ProgettoSoggettoGestoreCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettosoggettogestorefindfindoperatorecreazionesoggettogestore", new string[] {"IdSoggettoGestoreequalthis", "Asseequalthis", "IdBandoequalthis",
"IdProgettoRiferimentoequalthis", "OperatoreCreazioneequalthis"}, new string[] {"int", "string", "int",
"int", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSoggettoGestoreequalthis", IdSoggettoGestoreEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoRiferimentoequalthis", IdProgettoRiferimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			ProgettoSoggettoGestore ProgettoSoggettoGestoreObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoSoggettoGestoreObj = GetFromDatareader(db);
				ProgettoSoggettoGestoreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoSoggettoGestoreObj.IsDirty = false;
				ProgettoSoggettoGestoreObj.IsPersistent = true;
				ProgettoSoggettoGestoreCollectionObj.Add(ProgettoSoggettoGestoreObj);
			}
			db.Close();
			return ProgettoSoggettoGestoreCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoSoggettoGestoreCollectionProvider:IProgettoSoggettoGestoreProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoSoggettoGestoreCollectionProvider : IProgettoSoggettoGestoreProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoSoggettoGestore
		protected ProgettoSoggettoGestoreCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoSoggettoGestoreCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoSoggettoGestoreCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoSoggettoGestoreCollectionProvider(IntNT IdsoggettogestoreEqualThis, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
StringNT CodicefiscaleEqualThis, StringNT AsseEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoriferimentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindProgettiSoggettoGestore(IdsoggettogestoreEqualThis, IdimpresaEqualThis, CuaaEqualThis,
CodicefiscaleEqualThis, AsseEqualThis, IdbandoEqualThis,
IdprogettoriferimentoEqualThis);
		}

		//Costruttore3: ha in input progettosoggettogestoreCollectionObj - non popola la collection
		public ProgettoSoggettoGestoreCollectionProvider(ProgettoSoggettoGestoreCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoSoggettoGestoreCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoSoggettoGestoreCollection(this);
		}

		//Get e Set
		public ProgettoSoggettoGestoreCollection CollectionObj
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
		public int SaveCollection(ProgettoSoggettoGestoreCollection collectionObj)
		{
			return ProgettoSoggettoGestoreDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoSoggettoGestore progettosoggettogestoreObj)
		{
			return ProgettoSoggettoGestoreDAL.Save(_dbProviderObj, progettosoggettogestoreObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoSoggettoGestoreCollection collectionObj)
		{
			return ProgettoSoggettoGestoreDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoSoggettoGestore progettosoggettogestoreObj)
		{
			return ProgettoSoggettoGestoreDAL.Delete(_dbProviderObj, progettosoggettogestoreObj);
		}

		//getById
		public ProgettoSoggettoGestore GetById(IntNT IdProgettoSoggettoGestoreValue)
		{
			ProgettoSoggettoGestore ProgettoSoggettoGestoreTemp = ProgettoSoggettoGestoreDAL.GetById(_dbProviderObj, IdProgettoSoggettoGestoreValue);
			if (ProgettoSoggettoGestoreTemp != null) ProgettoSoggettoGestoreTemp.Provider = this;
			return ProgettoSoggettoGestoreTemp;
		}

		//Select: popola la collection
		public ProgettoSoggettoGestoreCollection Select(IntNT IdprogettosoggettogestoreEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoriferimentoEqualThis,
IntNT IdsoggettogestoreEqualThis)
		{
			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionTemp = ProgettoSoggettoGestoreDAL.Select(_dbProviderObj, IdprogettosoggettogestoreEqualThis, IdbandoEqualThis, IdprogettoriferimentoEqualThis,
IdsoggettogestoreEqualThis);
			ProgettoSoggettoGestoreCollectionTemp.Provider = this;
			return ProgettoSoggettoGestoreCollectionTemp;
		}

		//FindProgettiSoggettoGestore: popola la collection
		public ProgettoSoggettoGestoreCollection FindProgettiSoggettoGestore(IntNT IdsoggettogestoreEqualThis, IntNT IdimpresaEqualThis, StringNT CuaaEqualThis,
StringNT CodicefiscaleEqualThis, StringNT AsseEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoriferimentoEqualThis)
		{
			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionTemp = ProgettoSoggettoGestoreDAL.FindProgettiSoggettoGestore(_dbProviderObj, IdsoggettogestoreEqualThis, IdimpresaEqualThis, CuaaEqualThis,
CodicefiscaleEqualThis, AsseEqualThis, IdbandoEqualThis,
IdprogettoriferimentoEqualThis);
			ProgettoSoggettoGestoreCollectionTemp.Provider = this;
			return ProgettoSoggettoGestoreCollectionTemp;
		}

		//FindOperatoreCreazioneSoggettoGestore: popola la collection
		public ProgettoSoggettoGestoreCollection FindOperatoreCreazioneSoggettoGestore(IntNT IdsoggettogestoreEqualThis, StringNT AsseEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoriferimentoEqualThis, IntNT OperatorecreazioneEqualThis)
		{
			ProgettoSoggettoGestoreCollection ProgettoSoggettoGestoreCollectionTemp = ProgettoSoggettoGestoreDAL.FindOperatoreCreazioneSoggettoGestore(_dbProviderObj, IdsoggettogestoreEqualThis, AsseEqualThis, IdbandoEqualThis,
IdprogettoriferimentoEqualThis, OperatorecreazioneEqualThis);
			ProgettoSoggettoGestoreCollectionTemp.Provider = this;
			return ProgettoSoggettoGestoreCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_SOGGETTO_GESTORE>
  <ViewName>VPROGETTO_SOGGETTO_GESTORE</ViewName>
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
    <FindProgettiSoggettoGestore OrderBy="ORDER BY ">
      <ID_SOGGETTO_GESTORE>Equal</ID_SOGGETTO_GESTORE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <ASSE>Equal</ASSE>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO_RIFERIMENTO>Equal</ID_PROGETTO_RIFERIMENTO>
    </FindProgettiSoggettoGestore>
    <FindOperatoreCreazioneSoggettoGestore OrderBy="ORDER BY ">
      <ID_SOGGETTO_GESTORE>Equal</ID_SOGGETTO_GESTORE>
      <ASSE>Equal</ASSE>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO_RIFERIMENTO>Equal</ID_PROGETTO_RIFERIMENTO>
      <OPERATORE_CREAZIONE>Equal</OPERATORE_CREAZIONE>
    </FindOperatoreCreazioneSoggettoGestore>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_SOGGETTO_GESTORE>
*/
