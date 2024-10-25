using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettiErroreFirmaMassivaOperatoriFirma
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettiErroreFirmaMassivaOperatoriFirmaProvider
	{
		int Save(ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj);
		int SaveCollection(ProgettiErroreFirmaMassivaOperatoriFirmaCollection collectionObj);
		int Delete(ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj);
		int DeleteCollection(ProgettiErroreFirmaMassivaOperatoriFirmaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettiErroreFirmaMassivaOperatoriFirma
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettiErroreFirmaMassivaOperatoriFirma : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdProgettoValutazione;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.StringNT _Utente;
		private NullTypes.IntNT _Ordine;
		private NullTypes.IntNT _FirmaUtentePresente;
		[NonSerialized] private IProgettiErroreFirmaMassivaOperatoriFirmaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettiErroreFirmaMassivaOperatoriFirmaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public ProgettiErroreFirmaMassivaOperatoriFirma()
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
		/// Corrisponde al campo:ID_PROGETTO_VALUTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoValutazione
		{
			get { return _IdProgettoValutazione; }
			set
			{
				if (IdProgettoValutazione != value)
				{
					_IdProgettoValutazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set
			{
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set
			{
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UTENTE
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Utente
		{
			get { return _Utente; }
			set
			{
				if (Utente != value)
				{
					_Utente = value;
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
		/// Corrisponde al campo:FIRMA_UTENTE_PRESENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT FirmaUtentePresente
		{
			get { return _FirmaUtentePresente; }
			set
			{
				if (FirmaUtentePresente != value)
				{
					_FirmaUtentePresente = value;
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
	/// Summary description for ProgettiErroreFirmaMassivaOperatoriFirmaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettiErroreFirmaMassivaOperatoriFirmaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettiErroreFirmaMassivaOperatoriFirmaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((ProgettiErroreFirmaMassivaOperatoriFirma)info.GetValue(i.ToString(), typeof(ProgettiErroreFirmaMassivaOperatoriFirma)));
			}
		}

		//Costruttore
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection()
		{
			this.ItemType = typeof(ProgettiErroreFirmaMassivaOperatoriFirma);
		}

		//Costruttore con provider
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection(IProgettiErroreFirmaMassivaOperatoriFirmaProvider providerObj)
		{
			this.ItemType = typeof(ProgettiErroreFirmaMassivaOperatoriFirma);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettiErroreFirmaMassivaOperatoriFirma this[int index]
		{
			get { return (ProgettiErroreFirmaMassivaOperatoriFirma)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettiErroreFirmaMassivaOperatoriFirmaCollection GetChanges()
		{
			return (ProgettiErroreFirmaMassivaOperatoriFirmaCollection)base.GetChanges();
		}

		[NonSerialized] private IProgettiErroreFirmaMassivaOperatoriFirmaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IProgettiErroreFirmaMassivaOperatoriFirmaProvider Provider
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
		public int Add(ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			if (ProgettiErroreFirmaMassivaOperatoriFirmaObj.Provider == null) ProgettiErroreFirmaMassivaOperatoriFirmaObj.Provider = this.Provider;
			return base.Add(ProgettiErroreFirmaMassivaOperatoriFirmaObj);
		}

		//AddCollection
		public void AddCollection(ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj)
		{
			foreach (ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj in ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj)
				this.Add(ProgettiErroreFirmaMassivaOperatoriFirmaObj);
		}

		//Insert
		public void Insert(int index, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			if (ProgettiErroreFirmaMassivaOperatoriFirmaObj.Provider == null) ProgettiErroreFirmaMassivaOperatoriFirmaObj.Provider = this.Provider;
			base.Insert(index, ProgettiErroreFirmaMassivaOperatoriFirmaObj);
		}

		//CollectionGetById
		public ProgettiErroreFirmaMassivaOperatoriFirma CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdProgettoValutazioneEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.IntNT IdUtenteEqualThis,
NullTypes.StringNT UtenteEqualThis, NullTypes.IntNT OrdineEqualThis, NullTypes.IntNT FirmaUtentePresenteEqualThis)
		{
			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection();
			foreach (ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.Id != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdBando != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdProgetto != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdProgettoValutazioneEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdProgettoValutazione != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdProgettoValutazione.Value == IdProgettoValutazioneEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.Segnatura != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdUtente != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.IdUtente.Value == IdUtenteEqualThis.Value))) &&
((UtenteEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.Utente != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.Utente.Value == UtenteEqualThis.Value))) && ((OrdineEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.Ordine != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.Ordine.Value == OrdineEqualThis.Value))) && ((FirmaUtentePresenteEqualThis == null) || ((ProgettiErroreFirmaMassivaOperatoriFirmaItem.FirmaUtentePresente != null) && (ProgettiErroreFirmaMassivaOperatoriFirmaItem.FirmaUtentePresente.Value == FirmaUtentePresenteEqualThis.Value))))
				{
					ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp.Add(ProgettiErroreFirmaMassivaOperatoriFirmaItem);
				}
			}
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettiErroreFirmaMassivaOperatoriFirmaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettiErroreFirmaMassivaOperatoriFirmaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "Id", ProgettiErroreFirmaMassivaOperatoriFirmaObj.Id);
			DbProvider.SetCmdParam(cmd, firstChar + "IdBando", ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdBando);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd, firstChar + "IdProgettoValutazione", ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdProgettoValutazione);
			DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", ProgettiErroreFirmaMassivaOperatoriFirmaObj.Segnatura);
			DbProvider.SetCmdParam(cmd, firstChar + "IdUtente", ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdUtente);
			DbProvider.SetCmdParam(cmd, firstChar + "Utente", ProgettiErroreFirmaMassivaOperatoriFirmaObj.Utente);
			DbProvider.SetCmdParam(cmd, firstChar + "Ordine", ProgettiErroreFirmaMassivaOperatoriFirmaObj.Ordine);
			DbProvider.SetCmdParam(cmd, firstChar + "FirmaUtentePresente", ProgettiErroreFirmaMassivaOperatoriFirmaObj.FirmaUtentePresente);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaInsert", new string[] {"Id", "IdBando", "IdProgetto",
"IdProgettoValutazione", "Segnatura", "IdUtente",
"Utente", "Ordine", "FirmaUtentePresente"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "int", "int"}, "");
				CompileIUCmd(false, insertCmd, ProgettiErroreFirmaMassivaOperatoriFirmaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaUpdate", new string[] {"Id", "IdBando", "IdProgetto",
"IdProgettoValutazione", "Segnatura", "IdUtente",
"Utente", "Ordine", "FirmaUtentePresente"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "int", "int"}, "");
				CompileIUCmd(true, updateCmd, ProgettiErroreFirmaMassivaOperatoriFirmaObj, db.CommandFirstChar);
				i = db.Execute(updateCmd);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			switch (ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, ProgettiErroreFirmaMassivaOperatoriFirmaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, ProgettiErroreFirmaMassivaOperatoriFirmaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, ProgettiErroreFirmaMassivaOperatoriFirmaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaUpdate", new string[] {"Id", "IdBando", "IdProgetto",
"IdProgettoValutazione", "Segnatura", "IdUtente",
"Utente", "Ordine", "FirmaUtentePresente"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "int", "int"}, "");
				IDbCommand insertCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaInsert", new string[] {"Id", "IdBando", "IdProgetto",
"IdProgettoValutazione", "Segnatura", "IdUtente",
"Utente", "Ordine", "FirmaUtentePresente"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "int", "int"}, "");
				IDbCommand deleteCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Count; i++)
				{
					switch (ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Count; i++)
				{
					if ((ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsDirty = false;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsDirty = false;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj)
		{
			int returnValue = 0;
			if (ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent)
			{
				returnValue = Delete(db, ProgettiErroreFirmaMassivaOperatoriFirmaObj.Id);
			}
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaDelete", new string[] { "Id" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaDelete", new string[] { "Id" }, new string[] { "int" }, "");
				for (int i = 0; i < ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Count; i++)
				{
					if ((ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsDirty = false;
						ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj[i].IsPersistent = false;
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
		public static ProgettiErroreFirmaMassivaOperatoriFirma GetById(DbProvider db, int IdValue)
		{
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj = null;
			IDbCommand readCmd = db.InitCmd("ZProgettiErroreFirmaMassivaOperatoriFirmaGetById", new string[] { "Id" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettiErroreFirmaMassivaOperatoriFirmaObj = GetFromDatareader(db);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
			}
			db.Close();
			return ProgettiErroreFirmaMassivaOperatoriFirmaObj;
		}

		//getFromDatareader
		public static ProgettiErroreFirmaMassivaOperatoriFirma GetFromDatareader(DbProvider db)
		{
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj = new ProgettiErroreFirmaMassivaOperatoriFirma();
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdProgettoValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_VALUTAZIONE"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.Utente = new SiarLibrary.NullTypes.StringNT(db.DataReader["UTENTE"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.FirmaUtentePresente = new SiarLibrary.NullTypes.IntNT(db.DataReader["FIRMA_UTENTE_PRESENTE"]);
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
			ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
			return ProgettiErroreFirmaMassivaOperatoriFirmaObj;
		}

		//Find Select

		public static ProgettiErroreFirmaMassivaOperatoriFirmaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoValutazioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis,
SiarLibrary.NullTypes.StringNT UtenteEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.IntNT FirmaUtentePresenteEqualThis)

		{

			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettierrorefirmamassivaoperatorifirmafindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdProgettoequalthis",
"IdProgettoValutazioneequalthis", "Segnaturaequalthis", "IdUtenteequalthis",
"Utenteequalthis", "Ordineequalthis", "FirmaUtentePresenteequalthis"}, new string[] {"int", "int", "int",
"int", "string", "int",
"string", "int", "int"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoValutazioneequalthis", IdProgettoValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Utenteequalthis", UtenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaUtentePresenteequalthis", FirmaUtentePresenteEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettiErroreFirmaMassivaOperatoriFirmaObj = GetFromDatareader(db);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
				ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Add(ProgettiErroreFirmaMassivaOperatoriFirmaObj);
			}
			db.Close();
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj;
		}

		//Find FindProgettiUtente

		public static ProgettiErroreFirmaMassivaOperatoriFirmaCollection FindProgettiUtente(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT FirmaUtentePresenteEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

		{

			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettierrorefirmamassivaoperatorifirmafindfindprogettiutente", new string[] { "IdUtenteequalthis", "FirmaUtentePresenteequalthis", "IdProgettoequalthis" }, new string[] { "int", "int", "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaUtentePresenteequalthis", FirmaUtentePresenteEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettiErroreFirmaMassivaOperatoriFirmaObj = GetFromDatareader(db);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
				ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Add(ProgettiErroreFirmaMassivaOperatoriFirmaObj);
			}
			db.Close();
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj;
		}

		//Find FindFirmeValutazione

		public static ProgettiErroreFirmaMassivaOperatoriFirmaCollection FindFirmeValutazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoValutazioneEqualThis)

		{

			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettierrorefirmamassivaoperatorifirmafindfindfirmevalutazione", new string[] { "IdProgettoValutazioneequalthis" }, new string[] { "int" }, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoValutazioneequalthis", IdProgettoValutazioneEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettiErroreFirmaMassivaOperatoriFirmaObj = GetFromDatareader(db);
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsDirty = false;
				ProgettiErroreFirmaMassivaOperatoriFirmaObj.IsPersistent = true;
				ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj.Add(ProgettiErroreFirmaMassivaOperatoriFirmaObj);
			}
			db.Close();
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider:IProgettiErroreFirmaMassivaOperatoriFirmaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider : IProgettiErroreFirmaMassivaOperatoriFirmaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettiErroreFirmaMassivaOperatoriFirma
		protected ProgettiErroreFirmaMassivaOperatoriFirmaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider(IntNT IdutenteEqualThis, IntNT FirmautentepresenteEqualThis, IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindProgettiUtente(IdutenteEqualThis, FirmautentepresenteEqualThis, IdprogettoEqualThis);
		}

		//Costruttore3: ha in input progettierrorefirmamassivaoperatorifirmaCollectionObj - non popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider(ProgettiErroreFirmaMassivaOperatoriFirmaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettiErroreFirmaMassivaOperatoriFirmaCollection(this);
		}

		//Get e Set
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection CollectionObj
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
		public int SaveCollection(ProgettiErroreFirmaMassivaOperatoriFirmaCollection collectionObj)
		{
			return ProgettiErroreFirmaMassivaOperatoriFirmaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettiErroreFirmaMassivaOperatoriFirma progettierrorefirmamassivaoperatorifirmaObj)
		{
			return ProgettiErroreFirmaMassivaOperatoriFirmaDAL.Save(_dbProviderObj, progettierrorefirmamassivaoperatorifirmaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettiErroreFirmaMassivaOperatoriFirmaCollection collectionObj)
		{
			return ProgettiErroreFirmaMassivaOperatoriFirmaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettiErroreFirmaMassivaOperatoriFirma progettierrorefirmamassivaoperatorifirmaObj)
		{
			return ProgettiErroreFirmaMassivaOperatoriFirmaDAL.Delete(_dbProviderObj, progettierrorefirmamassivaoperatorifirmaObj);
		}

		//getById
		public ProgettiErroreFirmaMassivaOperatoriFirma GetById(IntNT IdValue)
		{
			ProgettiErroreFirmaMassivaOperatoriFirma ProgettiErroreFirmaMassivaOperatoriFirmaTemp = ProgettiErroreFirmaMassivaOperatoriFirmaDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettiErroreFirmaMassivaOperatoriFirmaTemp != null) ProgettiErroreFirmaMassivaOperatoriFirmaTemp.Provider = this;
			return ProgettiErroreFirmaMassivaOperatoriFirmaTemp;
		}

		//Select: popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis,
IntNT IdprogettovalutazioneEqualThis, StringNT SegnaturaEqualThis, IntNT IdutenteEqualThis,
StringNT UtenteEqualThis, IntNT OrdineEqualThis, IntNT FirmautentepresenteEqualThis)
		{
			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp = ProgettiErroreFirmaMassivaOperatoriFirmaDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdprogettoEqualThis,
IdprogettovalutazioneEqualThis, SegnaturaEqualThis, IdutenteEqualThis,
UtenteEqualThis, OrdineEqualThis, FirmautentepresenteEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp.Provider = this;
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp;
		}

		//FindProgettiUtente: popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection FindProgettiUtente(IntNT IdutenteEqualThis, IntNT FirmautentepresenteEqualThis, IntNT IdprogettoEqualThis)
		{
			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp = ProgettiErroreFirmaMassivaOperatoriFirmaDAL.FindProgettiUtente(_dbProviderObj, IdutenteEqualThis, FirmautentepresenteEqualThis, IdprogettoEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp.Provider = this;
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp;
		}

		//FindFirmeValutazione: popola la collection
		public ProgettiErroreFirmaMassivaOperatoriFirmaCollection FindFirmeValutazione(IntNT IdprogettovalutazioneEqualThis)
		{
			ProgettiErroreFirmaMassivaOperatoriFirmaCollection ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp = ProgettiErroreFirmaMassivaOperatoriFirmaDAL.FindFirmeValutazione(_dbProviderObj, IdprogettovalutazioneEqualThis);
			ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp.Provider = this;
			return ProgettiErroreFirmaMassivaOperatoriFirmaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTI_ERRORE_FIRMA_MASSIVA_OPERATORI_FIRMA>
  <ViewName>VPROGETTI_ERRORE_FIRMA_MASSIVA_OPERATORI_FIRMA</ViewName>
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
    <FindProgettiUtente OrderBy="ORDER BY ID_BANDO, ID_PROGETTO, ORDINE">
      <ID_UTENTE>Equal</ID_UTENTE>
      <FIRMA_UTENTE_PRESENTE>Equal</FIRMA_UTENTE_PRESENTE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </FindProgettiUtente>
    <FindFirmeValutazione OrderBy="ORDER BY ORDINE">
      <ID_PROGETTO_VALUTAZIONE>Equal</ID_PROGETTO_VALUTAZIONE>
    </FindFirmeValutazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTI_ERRORE_FIRMA_MASSIVA_OPERATORI_FIRMA>
*/
