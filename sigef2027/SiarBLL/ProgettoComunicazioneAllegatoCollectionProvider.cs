using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoComunicazioneAllegato
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoComunicazioneAllegatoProvider
	{
		int Save(ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj);
		int SaveCollection(ProgettoComunicazioneAllegatoCollection collectionObj);
		int Delete(ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj);
		int DeleteCollection(ProgettoComunicazioneAllegatoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoComunicazioneAllegato
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoComunicazioneAllegato: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdComunicazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IProgettoComunicazioneAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioneAllegatoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoComunicazioneAllegato()
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
		/// Corrisponde al campo:ID_COMUNICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComunicazione
		{
			get { return _IdComunicazione; }
			set {
				if (IdComunicazione != value)
				{
					_IdComunicazione = value;
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
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
	/// Summary description for ProgettoComunicazioneAllegatoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioneAllegatoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoComunicazioneAllegatoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoComunicazioneAllegato) info.GetValue(i.ToString(),typeof(ProgettoComunicazioneAllegato)));
			}
		}

		//Costruttore
		public ProgettoComunicazioneAllegatoCollection()
		{
			this.ItemType = typeof(ProgettoComunicazioneAllegato);
		}

		//Costruttore con provider
		public ProgettoComunicazioneAllegatoCollection(IProgettoComunicazioneAllegatoProvider providerObj)
		{
			this.ItemType = typeof(ProgettoComunicazioneAllegato);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoComunicazioneAllegato this[int index]
		{
			get { return (ProgettoComunicazioneAllegato)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoComunicazioneAllegatoCollection GetChanges()
		{
			return (ProgettoComunicazioneAllegatoCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoComunicazioneAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioneAllegatoProvider Provider
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
		public int Add(ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			if (ProgettoComunicazioneAllegatoObj.Provider == null) ProgettoComunicazioneAllegatoObj.Provider = this.Provider;
			return base.Add(ProgettoComunicazioneAllegatoObj);
		}

		//AddCollection
		public void AddCollection(ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionObj)
		{
			foreach (ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj in ProgettoComunicazioneAllegatoCollectionObj)
				this.Add(ProgettoComunicazioneAllegatoObj);
		}

		//Insert
		public void Insert(int index, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			if (ProgettoComunicazioneAllegatoObj.Provider == null) ProgettoComunicazioneAllegatoObj.Provider = this.Provider;
			base.Insert(index, ProgettoComunicazioneAllegatoObj);
		}

		//CollectionGetById
		public ProgettoComunicazioneAllegato CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoComunicazioneAllegatoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionTemp = new ProgettoComunicazioneAllegatoCollection();
			foreach (ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.Id != null) && (ProgettoComunicazioneAllegatoItem.Id.Value == IdEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.IdComunicazione != null) && (ProgettoComunicazioneAllegatoItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.IdProgetto != null) && (ProgettoComunicazioneAllegatoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdFileEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.IdFile != null) && (ProgettoComunicazioneAllegatoItem.IdFile.Value == IdFileEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.Descrizione != null) && (ProgettoComunicazioneAllegatoItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ProgettoComunicazioneAllegatoCollectionTemp.Add(ProgettoComunicazioneAllegatoItem);
				}
			}
			return ProgettoComunicazioneAllegatoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoComunicazioneAllegatoCollection Filter(NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis)
		{
			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionTemp = new ProgettoComunicazioneAllegatoCollection();
			foreach (ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoItem in this)
			{
				if (((IdComunicazioneEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.IdComunicazione != null) && (ProgettoComunicazioneAllegatoItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoComunicazioneAllegatoItem.IdProgetto != null) && (ProgettoComunicazioneAllegatoItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
				{
					ProgettoComunicazioneAllegatoCollectionTemp.Add(ProgettoComunicazioneAllegatoItem);
				}
			}
			return ProgettoComunicazioneAllegatoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioneAllegatoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoComunicazioneAllegatoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoComunicazioneAllegatoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazione", ProgettoComunicazioneAllegatoObj.IdComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoComunicazioneAllegatoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoComunicazioneAllegatoObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ProgettoComunicazioneAllegatoObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoInsert", new string[] {"IdComunicazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", 
"int", "string"},"");
				CompileIUCmd(false, insertCmd,ProgettoComunicazioneAllegatoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoComunicazioneAllegatoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneAllegatoObj.IsDirty = false;
				ProgettoComunicazioneAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoUpdate", new string[] {"Id", "IdComunicazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", "int", 
"int", "string"},"");
				CompileIUCmd(true, updateCmd,ProgettoComunicazioneAllegatoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneAllegatoObj.IsDirty = false;
				ProgettoComunicazioneAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			switch (ProgettoComunicazioneAllegatoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoComunicazioneAllegatoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoComunicazioneAllegatoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoComunicazioneAllegatoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoUpdate", new string[] {"Id", "IdComunicazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", "int", 
"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoInsert", new string[] {"IdComunicazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", 
"int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioneAllegatoCollectionObj.Count; i++)
				{
					switch (ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoComunicazioneAllegatoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoComunicazioneAllegatoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoComunicazioneAllegatoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoComunicazioneAllegatoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoComunicazioneAllegatoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioneAllegatoCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj)
		{
			int returnValue = 0;
			if (ProgettoComunicazioneAllegatoObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoComunicazioneAllegatoObj.Id);
			}
			ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoComunicazioneAllegatoObj.IsDirty = false;
			ProgettoComunicazioneAllegatoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioneAllegatoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoComunicazioneAllegatoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioneAllegatoCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioneAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneAllegatoCollectionObj[i].IsPersistent = false;
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
		public static ProgettoComunicazioneAllegato GetById(DbProvider db, int IdValue)
		{
			ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoComunicazioneAllegatoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoComunicazioneAllegatoObj = GetFromDatareader(db);
				ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneAllegatoObj.IsDirty = false;
				ProgettoComunicazioneAllegatoObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoComunicazioneAllegatoObj;
		}

		//getFromDatareader
		public static ProgettoComunicazioneAllegato GetFromDatareader(DbProvider db)
		{
			ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj = new ProgettoComunicazioneAllegato();
			ProgettoComunicazioneAllegatoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoComunicazioneAllegatoObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
			ProgettoComunicazioneAllegatoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoComunicazioneAllegatoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoComunicazioneAllegatoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoComunicazioneAllegatoObj.IsDirty = false;
			ProgettoComunicazioneAllegatoObj.IsPersistent = true;
			return ProgettoComunicazioneAllegatoObj;
		}

		//Find Select

		public static ProgettoComunicazioneAllegatoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionObj = new ProgettoComunicazioneAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazioneallegatofindselect", new string[] {"Idequalthis", "IdComunicazioneequalthis", "IdProgettoequalthis", 
"IdFileequalthis", "Descrizioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioneAllegatoObj = GetFromDatareader(db);
				ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneAllegatoObj.IsDirty = false;
				ProgettoComunicazioneAllegatoObj.IsPersistent = true;
				ProgettoComunicazioneAllegatoCollectionObj.Add(ProgettoComunicazioneAllegatoObj);
			}
			db.Close();
			return ProgettoComunicazioneAllegatoCollectionObj;
		}

		//Find Find

		public static ProgettoComunicazioneAllegatoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionObj = new ProgettoComunicazioneAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazioneallegatofindfind", new string[] {"IdComunicazioneequalthis", "IdProgettoequalthis", "IdFileequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioneAllegatoObj = GetFromDatareader(db);
				ProgettoComunicazioneAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneAllegatoObj.IsDirty = false;
				ProgettoComunicazioneAllegatoObj.IsPersistent = true;
				ProgettoComunicazioneAllegatoCollectionObj.Add(ProgettoComunicazioneAllegatoObj);
			}
			db.Close();
			return ProgettoComunicazioneAllegatoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioneAllegatoCollectionProvider:IProgettoComunicazioneAllegatoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioneAllegatoCollectionProvider : IProgettoComunicazioneAllegatoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoComunicazioneAllegato
		protected ProgettoComunicazioneAllegatoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoComunicazioneAllegatoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoComunicazioneAllegatoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoComunicazioneAllegatoCollectionProvider(IntNT IdcomunicazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcomunicazioneEqualThis, IdprogettoEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input progettocomunicazioneallegatoCollectionObj - non popola la collection
		public ProgettoComunicazioneAllegatoCollectionProvider(ProgettoComunicazioneAllegatoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoComunicazioneAllegatoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoComunicazioneAllegatoCollection(this);
		}

		//Get e Set
		public ProgettoComunicazioneAllegatoCollection CollectionObj
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
		public int SaveCollection(ProgettoComunicazioneAllegatoCollection collectionObj)
		{
			return ProgettoComunicazioneAllegatoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoComunicazioneAllegato progettocomunicazioneallegatoObj)
		{
			return ProgettoComunicazioneAllegatoDAL.Save(_dbProviderObj, progettocomunicazioneallegatoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoComunicazioneAllegatoCollection collectionObj)
		{
			return ProgettoComunicazioneAllegatoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoComunicazioneAllegato progettocomunicazioneallegatoObj)
		{
			return ProgettoComunicazioneAllegatoDAL.Delete(_dbProviderObj, progettocomunicazioneallegatoObj);
		}

		//getById
		public ProgettoComunicazioneAllegato GetById(IntNT IdValue)
		{
			ProgettoComunicazioneAllegato ProgettoComunicazioneAllegatoTemp = ProgettoComunicazioneAllegatoDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoComunicazioneAllegatoTemp!=null) ProgettoComunicazioneAllegatoTemp.Provider = this;
			return ProgettoComunicazioneAllegatoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoComunicazioneAllegatoCollection Select(IntNT IdEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdfileEqualThis, StringNT DescrizioneEqualThis)
		{
			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionTemp = ProgettoComunicazioneAllegatoDAL.Select(_dbProviderObj, IdEqualThis, IdcomunicazioneEqualThis, IdprogettoEqualThis, 
IdfileEqualThis, DescrizioneEqualThis);
			ProgettoComunicazioneAllegatoCollectionTemp.Provider = this;
			return ProgettoComunicazioneAllegatoCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoComunicazioneAllegatoCollection Find(IntNT IdcomunicazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			ProgettoComunicazioneAllegatoCollection ProgettoComunicazioneAllegatoCollectionTemp = ProgettoComunicazioneAllegatoDAL.Find(_dbProviderObj, IdcomunicazioneEqualThis, IdprogettoEqualThis, IdfileEqualThis);
			ProgettoComunicazioneAllegatoCollectionTemp.Provider = this;
			return ProgettoComunicazioneAllegatoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_COMUNICAZIONE_ALLEGATO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONE_ALLEGATO>
*/
