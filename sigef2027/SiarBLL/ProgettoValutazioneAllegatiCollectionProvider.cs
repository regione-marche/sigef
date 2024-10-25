using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoValutazioneAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoValutazioneAllegatiProvider
	{
		int Save(ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj);
		int SaveCollection(ProgettoValutazioneAllegatiCollection collectionObj);
		int Delete(ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj);
		int DeleteCollection(ProgettoValutazioneAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoValutazioneAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoValutazioneAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdValutazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IProgettoValutazioneAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutazioneAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoValutazioneAllegati()
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
		/// Corrisponde al campo:ID_VALUTAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValutazione
		{
			get { return _IdValutazione; }
			set {
				if (IdValutazione != value)
				{
					_IdValutazione = value;
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
	/// Summary description for ProgettoValutazioneAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutazioneAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoValutazioneAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoValutazioneAllegati) info.GetValue(i.ToString(),typeof(ProgettoValutazioneAllegati)));
			}
		}

		//Costruttore
		public ProgettoValutazioneAllegatiCollection()
		{
			this.ItemType = typeof(ProgettoValutazioneAllegati);
		}

		//Costruttore con provider
		public ProgettoValutazioneAllegatiCollection(IProgettoValutazioneAllegatiProvider providerObj)
		{
			this.ItemType = typeof(ProgettoValutazioneAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoValutazioneAllegati this[int index]
		{
			get { return (ProgettoValutazioneAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoValutazioneAllegatiCollection GetChanges()
		{
			return (ProgettoValutazioneAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoValutazioneAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoValutazioneAllegatiProvider Provider
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
		public int Add(ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			if (ProgettoValutazioneAllegatiObj.Provider == null) ProgettoValutazioneAllegatiObj.Provider = this.Provider;
			return base.Add(ProgettoValutazioneAllegatiObj);
		}

		//AddCollection
		public void AddCollection(ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionObj)
		{
			foreach (ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj in ProgettoValutazioneAllegatiCollectionObj)
				this.Add(ProgettoValutazioneAllegatiObj);
		}

		//Insert
		public void Insert(int index, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			if (ProgettoValutazioneAllegatiObj.Provider == null) ProgettoValutazioneAllegatiObj.Provider = this.Provider;
			base.Insert(index, ProgettoValutazioneAllegatiObj);
		}

		//CollectionGetById
		public ProgettoValutazioneAllegati CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoValutazioneAllegatiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdValutazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionTemp = new ProgettoValutazioneAllegatiCollection();
			foreach (ProgettoValutazioneAllegati ProgettoValutazioneAllegatiItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoValutazioneAllegatiItem.Id != null) && (ProgettoValutazioneAllegatiItem.Id.Value == IdEqualThis.Value))) && ((IdValutazioneEqualThis == null) || ((ProgettoValutazioneAllegatiItem.IdValutazione != null) && (ProgettoValutazioneAllegatiItem.IdValutazione.Value == IdValutazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoValutazioneAllegatiItem.IdProgetto != null) && (ProgettoValutazioneAllegatiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdFileEqualThis == null) || ((ProgettoValutazioneAllegatiItem.IdFile != null) && (ProgettoValutazioneAllegatiItem.IdFile.Value == IdFileEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ProgettoValutazioneAllegatiItem.Descrizione != null) && (ProgettoValutazioneAllegatiItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					ProgettoValutazioneAllegatiCollectionTemp.Add(ProgettoValutazioneAllegatiItem);
				}
			}
			return ProgettoValutazioneAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoValutazioneAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoValutazioneAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoValutazioneAllegatiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdValutazione", ProgettoValutazioneAllegatiObj.IdValutazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoValutazioneAllegatiObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ProgettoValutazioneAllegatiObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ProgettoValutazioneAllegatiObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutazioneAllegatiInsert", new string[] {"IdValutazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", 
"int", "string"},"");
				CompileIUCmd(false, insertCmd,ProgettoValutazioneAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoValutazioneAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneAllegatiObj.IsDirty = false;
				ProgettoValutazioneAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutazioneAllegatiUpdate", new string[] {"Id", "IdValutazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", "int", 
"int", "string"},"");
				CompileIUCmd(true, updateCmd,ProgettoValutazioneAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneAllegatiObj.IsDirty = false;
				ProgettoValutazioneAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			switch (ProgettoValutazioneAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoValutazioneAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoValutazioneAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoValutazioneAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoValutazioneAllegatiUpdate", new string[] {"Id", "IdValutazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", "int", 
"int", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoValutazioneAllegatiInsert", new string[] {"IdValutazione", "IdProgetto", 
"IdFile", "Descrizione"}, new string[] {"int", "int", 
"int", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutazioneAllegatiCollectionObj.Count; i++)
				{
					switch (ProgettoValutazioneAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoValutazioneAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoValutazioneAllegatiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoValutazioneAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoValutazioneAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoValutazioneAllegatiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutazioneAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoValutazioneAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutazioneAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutazioneAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoValutazioneAllegatiCollectionObj[i].IsDirty = false;
						ProgettoValutazioneAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoValutazioneAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoValutazioneAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutazioneAllegatiCollectionObj[i].IsDirty = false;
						ProgettoValutazioneAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj)
		{
			int returnValue = 0;
			if (ProgettoValutazioneAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoValutazioneAllegatiObj.Id);
			}
			ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoValutazioneAllegatiObj.IsDirty = false;
			ProgettoValutazioneAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoValutazioneAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoValutazioneAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoValutazioneAllegatiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoValutazioneAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoValutazioneAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoValutazioneAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoValutazioneAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoValutazioneAllegatiCollectionObj[i].IsDirty = false;
						ProgettoValutazioneAllegatiCollectionObj[i].IsPersistent = false;
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
		public static ProgettoValutazioneAllegati GetById(DbProvider db, int IdValue)
		{
			ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoValutazioneAllegatiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoValutazioneAllegatiObj = GetFromDatareader(db);
				ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneAllegatiObj.IsDirty = false;
				ProgettoValutazioneAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoValutazioneAllegatiObj;
		}

		//getFromDatareader
		public static ProgettoValutazioneAllegati GetFromDatareader(DbProvider db)
		{
			ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj = new ProgettoValutazioneAllegati();
			ProgettoValutazioneAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoValutazioneAllegatiObj.IdValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALUTAZIONE"]);
			ProgettoValutazioneAllegatiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoValutazioneAllegatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ProgettoValutazioneAllegatiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoValutazioneAllegatiObj.IsDirty = false;
			ProgettoValutazioneAllegatiObj.IsPersistent = true;
			return ProgettoValutazioneAllegatiObj;
		}

		//Find Select

		public static ProgettoValutazioneAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionObj = new ProgettoValutazioneAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutazioneallegatifindselect", new string[] {"Idequalthis", "IdValutazioneequalthis", "IdProgettoequalthis", 
"IdFileequalthis", "Descrizioneequalthis"}, new string[] {"int", "int", "int", 
"int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutazioneequalthis", IdValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutazioneAllegatiObj = GetFromDatareader(db);
				ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneAllegatiObj.IsDirty = false;
				ProgettoValutazioneAllegatiObj.IsPersistent = true;
				ProgettoValutazioneAllegatiCollectionObj.Add(ProgettoValutazioneAllegatiObj);
			}
			db.Close();
			return ProgettoValutazioneAllegatiCollectionObj;
		}

		//Find Find

		public static ProgettoValutazioneAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionObj = new ProgettoValutazioneAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettovalutazioneallegatifindfind", new string[] {"IdValutazioneequalthis", "IdProgettoequalthis", "IdFileequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValutazioneequalthis", IdValutazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			ProgettoValutazioneAllegati ProgettoValutazioneAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoValutazioneAllegatiObj = GetFromDatareader(db);
				ProgettoValutazioneAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoValutazioneAllegatiObj.IsDirty = false;
				ProgettoValutazioneAllegatiObj.IsPersistent = true;
				ProgettoValutazioneAllegatiCollectionObj.Add(ProgettoValutazioneAllegatiObj);
			}
			db.Close();
			return ProgettoValutazioneAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoValutazioneAllegatiCollectionProvider:IProgettoValutazioneAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoValutazioneAllegatiCollectionProvider : IProgettoValutazioneAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoValutazioneAllegati
		protected ProgettoValutazioneAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoValutazioneAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoValutazioneAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoValutazioneAllegatiCollectionProvider(IntNT IdvalutazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvalutazioneEqualThis, IdprogettoEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input progettovalutazioneallegatiCollectionObj - non popola la collection
		public ProgettoValutazioneAllegatiCollectionProvider(ProgettoValutazioneAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoValutazioneAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoValutazioneAllegatiCollection(this);
		}

		//Get e Set
		public ProgettoValutazioneAllegatiCollection CollectionObj
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
		public int SaveCollection(ProgettoValutazioneAllegatiCollection collectionObj)
		{
			return ProgettoValutazioneAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoValutazioneAllegati progettovalutazioneallegatiObj)
		{
			return ProgettoValutazioneAllegatiDAL.Save(_dbProviderObj, progettovalutazioneallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoValutazioneAllegatiCollection collectionObj)
		{
			return ProgettoValutazioneAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoValutazioneAllegati progettovalutazioneallegatiObj)
		{
			return ProgettoValutazioneAllegatiDAL.Delete(_dbProviderObj, progettovalutazioneallegatiObj);
		}

		//getById
		public ProgettoValutazioneAllegati GetById(IntNT IdValue)
		{
			ProgettoValutazioneAllegati ProgettoValutazioneAllegatiTemp = ProgettoValutazioneAllegatiDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoValutazioneAllegatiTemp!=null) ProgettoValutazioneAllegatiTemp.Provider = this;
			return ProgettoValutazioneAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoValutazioneAllegatiCollection Select(IntNT IdEqualThis, IntNT IdvalutazioneEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdfileEqualThis, StringNT DescrizioneEqualThis)
		{
			ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionTemp = ProgettoValutazioneAllegatiDAL.Select(_dbProviderObj, IdEqualThis, IdvalutazioneEqualThis, IdprogettoEqualThis, 
IdfileEqualThis, DescrizioneEqualThis);
			ProgettoValutazioneAllegatiCollectionTemp.Provider = this;
			return ProgettoValutazioneAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoValutazioneAllegatiCollection Find(IntNT IdvalutazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdfileEqualThis)
		{
			ProgettoValutazioneAllegatiCollection ProgettoValutazioneAllegatiCollectionTemp = ProgettoValutazioneAllegatiDAL.Find(_dbProviderObj, IdvalutazioneEqualThis, IdprogettoEqualThis, IdfileEqualThis);
			ProgettoValutazioneAllegatiCollectionTemp.Provider = this;
			return ProgettoValutazioneAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_VALUTAZIONE_ALLEGATI>
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
      <ID_VALUTAZIONE>Equal</ID_VALUTAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_VALUTAZIONE_ALLEGATI>
*/
