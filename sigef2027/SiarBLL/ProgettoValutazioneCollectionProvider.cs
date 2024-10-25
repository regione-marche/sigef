using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoValutazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoValutazioneProvider
	{
		int Save(ProgettoValutazione ProgettoValutazioneObj);
		int SaveCollection(ProgettoValutazioneCollection collectionObj);
		int Delete(ProgettoValutazione ProgettoValutazioneObj);
		int DeleteCollection(ProgettoValutazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoValutazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoValutazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _IdFile;
		private NullTypes.IntNT _OrdineFirma;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.IntNT _IdNote;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.BoolNT _Annullato;
		[NonSerialized] private IProgettoValutazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoValutazione()
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
			set {
				if (Id != value)
				{
					_Id = value;
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
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
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
			set {
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FIRMA
		/// Tipo sul db:INT
		/// Default:((0))
		/// </summary>
		public NullTypes.IntNT OrdineFirma
		{
			get { return _OrdineFirma; }
			set {
				if (OrdineFirma != value)
				{
					_OrdineFirma = value;
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
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_NOTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNote
		{
			get { return _IdNote; }
			set {
				if (IdNote != value)
				{
					_IdNote = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
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

		/// <summary>
		/// Corrisponde al campo:ANNULLATO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Annullato
		{
			get { return _Annullato; }
			set {
				if (Annullato != value)
				{
					_Annullato = value;
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
	/// Summary description for ProgettoValutazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoValutazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoValutazione) info.GetValue(i.ToString(),typeof(ProgettoValutazione)));
			}
		}

		//Costruttore
		public ProgettoValutazioneCollection()
		{
			this.ItemType = typeof(ProgettoValutazione);
		}

		//Costruttore con provider
		public ProgettoValutazioneCollection(IProgettoValutazioneProvider providerObj)
		{
			this.ItemType = typeof(ProgettoValutazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoValutazione this[int index]
		{
			get { return (ProgettoValutazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoValutazioneCollection GetChanges()
		{
			return (ProgettoValutazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoValutazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutazioneProvider Provider
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
		public int Add(ProgettoValutazione ProgettoValutazioneObj)
		{
			if (ProgettoValutazioneObj.Provider == null) ProgettoValutazioneObj.Provider = this.Provider;
			return base.Add(ProgettoValutazioneObj);
		}

		//AddCollection
		public void AddCollection(ProgettoValutazioneCollection ProgettoValutazioneCollectionObj)
		{
			foreach (ProgettoValutazione ProgettoValutazioneObj in ProgettoValutazioneCollectionObj)
				this.Add(ProgettoValutazioneObj);
		}

		//Insert
		public void Insert(int index, ProgettoValutazione ProgettoValutazioneObj)
		{
			if (ProgettoValutazioneObj.Provider == null) ProgettoValutazioneObj.Provider = this.Provider;
			base.Insert(index, ProgettoValutazioneObj);
		}

		//CollectionGetById
		public ProgettoValutazione CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
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
		public ProgettoValutazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdVarianteEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.IntNT OrdineFirmaEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.IntNT IdNoteEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.BoolNT AnnullatoEqualThis)
		{
			ProgettoValutazioneCollection ProgettoValutazioneCollectionTemp = new ProgettoValutazioneCollection();
			foreach (ProgettoValutazione ProgettoValutazioneItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoValutazioneItem.Id != null) && (ProgettoValutazioneItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoValutazioneItem.IdProgetto != null) && (ProgettoValutazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((ProgettoValutazioneItem.IdVariante != null) && (ProgettoValutazioneItem.IdVariante.Value == IdVarianteEqualThis.Value))) && 
((IdFileEqualThis == null) || ((ProgettoValutazioneItem.IdFile != null) && (ProgettoValutazioneItem.IdFile.Value == IdFileEqualThis.Value))) && ((OrdineFirmaEqualThis == null) || ((ProgettoValutazioneItem.OrdineFirma != null) && (ProgettoValutazioneItem.OrdineFirma.Value == OrdineFirmaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoValutazioneItem.Segnatura != null) && (ProgettoValutazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((IdNoteEqualThis == null) || ((ProgettoValutazioneItem.IdNote != null) && (ProgettoValutazioneItem.IdNote.Value == IdNoteEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoValutazioneItem.Operatore != null) && (ProgettoValutazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ProgettoValutazioneItem.DataModifica != null) && (ProgettoValutazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((AnnullatoEqualThis == null) || ((ProgettoValutazioneItem.Annullato != null) && (ProgettoValutazioneItem.Annullato.Value == AnnullatoEqualThis.Value))))
				{
					ProgettoValutazioneCollectionTemp.Add(ProgettoValutazioneItem);
				}
			}
			return ProgettoValutazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoValutazioneCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.BoolNT AnnullatoEqualThis)
		{
			ProgettoValutazioneCollection ProgettoValutazioneCollectionTemp = new ProgettoValutazioneCollection();
			foreach (ProgettoValutazione ProgettoValutazioneItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((ProgettoValutazioneItem.IdProgetto != null) && (ProgettoValutazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoValutazioneItem.Operatore != null) && (ProgettoValutazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && ((AnnullatoEqualThis == null) || ((ProgettoValutazioneItem.Annullato != null) && (ProgettoValutazioneItem.Annullato.Value == AnnullatoEqualThis.Value))))
				{
					ProgettoValutazioneCollectionTemp.Add(ProgettoValutazioneItem);
				}
			}
			return ProgettoValutazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoValutazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoValutazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoValutazione ProgettoValutazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoValutazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoValutazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVariante", ProgettoValutazioneObj.IdVariante);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoValutazioneObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineFirma", ProgettoValutazioneObj.OrdineFirma);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoValutazioneObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", ProgettoValutazioneObj.IdNote);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoValutazioneObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ProgettoValutazioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Annullato", ProgettoValutazioneObj.Annullato);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoValutazione ProgettoValutazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutazioneInsert", new string[] {"IdProgetto", "IdVariante", 
"IdFile", "OrdineFirma", "Segnatura", 
"IdNote", "Operatore", "DataModifica", 
"Annullato"}, new string[] {"int", "int", 
"int", "int", "string", 
"int", "int", "DateTime", 
"bool"},"");
				CompileIUCmd(false, insertCmd,ProgettoValutazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoValutazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ProgettoValutazioneObj.OrdineFirma = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FIRMA"]);
				ProgettoValutazioneObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
				}
				ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneObj.IsDirty = false;
				ProgettoValutazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoValutazione ProgettoValutazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutazioneUpdate", new string[] {"Id", "IdProgetto", "IdVariante", 
"IdFile", "OrdineFirma", "Segnatura", 
"IdNote", "Operatore", "DataModifica", 
"Annullato"}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"int", "int", "DateTime", 
"bool"},"");
				CompileIUCmd(true, updateCmd,ProgettoValutazioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ProgettoValutazioneObj.DataModifica = d;
				}
				ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneObj.IsDirty = false;
				ProgettoValutazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoValutazione ProgettoValutazioneObj)
		{
			switch (ProgettoValutazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoValutazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoValutazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoValutazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoValutazioneCollection ProgettoValutazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutazioneUpdate", new string[] {"Id", "IdProgetto", "IdVariante", 
"IdFile", "OrdineFirma", "Segnatura", 
"IdNote", "Operatore", "DataModifica", 
"Annullato"}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"int", "int", "DateTime", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutazioneInsert", new string[] {"IdProgetto", "IdVariante", 
"IdFile", "OrdineFirma", "Segnatura", 
"IdNote", "Operatore", "DataModifica", 
"Annullato"}, new string[] {"int", "int", 
"int", "int", "string", 
"int", "int", "DateTime", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutazioneCollectionObj.Count; i++)
				{
					switch (ProgettoValutazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoValutazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoValutazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ProgettoValutazioneCollectionObj[i].OrdineFirma = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FIRMA"]);
									ProgettoValutazioneCollectionObj[i].Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoValutazioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ProgettoValutazioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoValutazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoValutazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutazioneCollectionObj.Count; i++)
				{
					if ((ProgettoValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoValutazioneCollectionObj[i].IsDirty = false;
						ProgettoValutazioneCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutazioneCollectionObj[i].IsDirty = false;
						ProgettoValutazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoValutazione ProgettoValutazioneObj)
		{
			int returnValue = 0;
			if (ProgettoValutazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoValutazioneObj.Id);
			}
			ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoValutazioneObj.IsDirty = false;
			ProgettoValutazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoValutazioneCollection ProgettoValutazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoValutazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutazioneCollectionObj.Count; i++)
				{
					if ((ProgettoValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutazioneCollectionObj[i].IsDirty = false;
						ProgettoValutazioneCollectionObj[i].IsPersistent = false;
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
		public static ProgettoValutazione GetById(DbProvider db, int IdValue)
		{
			ProgettoValutazione ProgettoValutazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoValutazioneGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoValutazioneObj = GetFromDatareader(db);
				ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneObj.IsDirty = false;
				ProgettoValutazioneObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoValutazioneObj;
		}

		//getFromDatareader
		public static ProgettoValutazione GetFromDatareader(DbProvider db)
		{
			ProgettoValutazione ProgettoValutazioneObj = new ProgettoValutazione();
			ProgettoValutazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoValutazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoValutazioneObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
			ProgettoValutazioneObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoValutazioneObj.OrdineFirma = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FIRMA"]);
			ProgettoValutazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoValutazioneObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			ProgettoValutazioneObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoValutazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ProgettoValutazioneObj.Annullato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATO"]);
			ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoValutazioneObj.IsDirty = false;
			ProgettoValutazioneObj.IsPersistent = true;
			return ProgettoValutazioneObj;
		}

		//Find Select

		public static ProgettoValutazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.IntNT OrdineFirmaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.IntNT IdNoteEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.BoolNT AnnullatoEqualThis)

		{

			ProgettoValutazioneCollection ProgettoValutazioneCollectionObj = new ProgettoValutazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutazionefindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "IdVarianteequalthis", 
"IdFileequalthis", "OrdineFirmaequalthis", "Segnaturaequalthis", 
"IdNoteequalthis", "Operatoreequalthis", "DataModificaequalthis", 
"Annullatoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "string", 
"int", "int", "DateTime", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFirmaequalthis", OrdineFirmaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullatoequalthis", AnnullatoEqualThis);
			ProgettoValutazione ProgettoValutazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutazioneObj = GetFromDatareader(db);
				ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneObj.IsDirty = false;
				ProgettoValutazioneObj.IsPersistent = true;
				ProgettoValutazioneCollectionObj.Add(ProgettoValutazioneObj);
			}
			db.Close();
			return ProgettoValutazioneCollectionObj;
		}

		//Find Find

		public static ProgettoValutazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.BoolNT IdVarianteIsNull, 
SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.BoolNT AnnullatoEqualThis)

		{

			ProgettoValutazioneCollection ProgettoValutazioneCollectionObj = new ProgettoValutazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutazionefindfind", new string[] {"IdProgettoequalthis", "IdVarianteequalthis", "IdVarianteisnull", 
"Operatoreequalthis", "Annullatoequalthis"}, new string[] {"int", "int", "bool", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVarianteisnull", IdVarianteIsNull);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annullatoequalthis", AnnullatoEqualThis);
			ProgettoValutazione ProgettoValutazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutazioneObj = GetFromDatareader(db);
				ProgettoValutazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneObj.IsDirty = false;
				ProgettoValutazioneObj.IsPersistent = true;
				ProgettoValutazioneCollectionObj.Add(ProgettoValutazioneObj);
			}
			db.Close();
			return ProgettoValutazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoValutazioneCollectionProvider:IProgettoValutazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutazioneCollectionProvider : IProgettoValutazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoValutazione
		protected ProgettoValutazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoValutazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoValutazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoValutazioneCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdvarianteEqualThis, BoolNT IdvarianteIsNull, 
IntNT OperatoreEqualThis, BoolNT AnnullatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdvarianteEqualThis, IdvarianteIsNull, 
OperatoreEqualThis, AnnullatoEqualThis);
		}

		//Costruttore3: ha in input progettovalutazioneCollectionObj - non popola la collection
		public ProgettoValutazioneCollectionProvider(ProgettoValutazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoValutazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoValutazioneCollection(this);
		}

		//Get e Set
		public ProgettoValutazioneCollection CollectionObj
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
		public int SaveCollection(ProgettoValutazioneCollection collectionObj)
		{
			return ProgettoValutazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoValutazione progettovalutazioneObj)
		{
			return ProgettoValutazioneDAL.Save(_dbProviderObj, progettovalutazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoValutazioneCollection collectionObj)
		{
			return ProgettoValutazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoValutazione progettovalutazioneObj)
		{
			return ProgettoValutazioneDAL.Delete(_dbProviderObj, progettovalutazioneObj);
		}

		//getById
		public ProgettoValutazione GetById(IntNT IdValue)
		{
			ProgettoValutazione ProgettoValutazioneTemp = ProgettoValutazioneDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoValutazioneTemp!=null) ProgettoValutazioneTemp.Provider = this;
			return ProgettoValutazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoValutazioneCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, IntNT IdvarianteEqualThis, 
IntNT IdfileEqualThis, IntNT OrdinefirmaEqualThis, StringNT SegnaturaEqualThis, 
IntNT IdnoteEqualThis, IntNT OperatoreEqualThis, DatetimeNT DatamodificaEqualThis, 
BoolNT AnnullatoEqualThis)
		{
			ProgettoValutazioneCollection ProgettoValutazioneCollectionTemp = ProgettoValutazioneDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, IdvarianteEqualThis, 
IdfileEqualThis, OrdinefirmaEqualThis, SegnaturaEqualThis, 
IdnoteEqualThis, OperatoreEqualThis, DatamodificaEqualThis, 
AnnullatoEqualThis);
			ProgettoValutazioneCollectionTemp.Provider = this;
			return ProgettoValutazioneCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoValutazioneCollection Find(IntNT IdprogettoEqualThis, IntNT IdvarianteEqualThis, BoolNT IdvarianteIsNull, 
IntNT OperatoreEqualThis, BoolNT AnnullatoEqualThis)
		{
			ProgettoValutazioneCollection ProgettoValutazioneCollectionTemp = ProgettoValutazioneDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdvarianteEqualThis, IdvarianteIsNull, 
OperatoreEqualThis, AnnullatoEqualThis);
			ProgettoValutazioneCollectionTemp.Provider = this;
			return ProgettoValutazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_VALUTAZIONE>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_VARIANTE>IsNull</ID_VARIANTE>
      <OPERATORE>Equal</OPERATORE>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <ANNULLATO>Equal</ANNULLATO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_VALUTAZIONE>
*/
