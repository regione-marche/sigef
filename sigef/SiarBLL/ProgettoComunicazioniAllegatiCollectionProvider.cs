using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoComunicazioniAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoComunicazioniAllegatiProvider
	{
		int Save(ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj);
		int SaveCollection(ProgettoComunicazioniAllegatiCollection collectionObj);
		int Delete(ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj);
		int DeleteCollection(ProgettoComunicazioniAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoComunicazioniAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoComunicazioniAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdComunicazione;
		private NullTypes.IntNT _IdProgettoAllegati;
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.IntNT _IdNote;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _DescrizioneBreve;
		private NullTypes.StringNT _Numero;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Ente;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _CodEnteEmettitore;
		private NullTypes.StringNT _Allegato;
		private NullTypes.StringNT _CodTipo;
		[NonSerialized] private IProgettoComunicazioniAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoComunicazioniAllegati()
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
		/// Corrisponde al campo:ID_PROGETTO_ALLEGATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgettoAllegati
		{
			get { return _IdProgettoAllegati; }
			set {
				if (IdProgettoAllegati != value)
				{
					_IdProgettoAllegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
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
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
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
			set {
				if (DescrizioneBreve != value)
				{
					_DescrizioneBreve = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(270)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
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
		/// Corrisponde al campo:ID_COMUNE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComune
		{
			get { return _IdComune; }
			set {
				if (IdComune != value)
				{
					_IdComune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE_EMETTITORE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnteEmettitore
		{
			get { return _CodEnteEmettitore; }
			set {
				if (CodEnteEmettitore != value)
				{
					_CodEnteEmettitore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ALLEGATO
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Allegato
		{
			get { return _Allegato; }
			set {
				if (Allegato != value)
				{
					_Allegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
	/// Summary description for ProgettoComunicazioniAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoComunicazioniAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoComunicazioniAllegati) info.GetValue(i.ToString(),typeof(ProgettoComunicazioniAllegati)));
			}
		}

		//Costruttore
		public ProgettoComunicazioniAllegatiCollection()
		{
			this.ItemType = typeof(ProgettoComunicazioniAllegati);
		}

		//Costruttore con provider
		public ProgettoComunicazioniAllegatiCollection(IProgettoComunicazioniAllegatiProvider providerObj)
		{
			this.ItemType = typeof(ProgettoComunicazioniAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoComunicazioniAllegati this[int index]
		{
			get { return (ProgettoComunicazioniAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoComunicazioniAllegatiCollection GetChanges()
		{
			return (ProgettoComunicazioniAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoComunicazioniAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioniAllegatiProvider Provider
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
		public int Add(ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			if (ProgettoComunicazioniAllegatiObj.Provider == null) ProgettoComunicazioniAllegatiObj.Provider = this.Provider;
			return base.Add(ProgettoComunicazioniAllegatiObj);
		}

		//AddCollection
		public void AddCollection(ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionObj)
		{
			foreach (ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj in ProgettoComunicazioniAllegatiCollectionObj)
				this.Add(ProgettoComunicazioniAllegatiObj);
		}

		//Insert
		public void Insert(int index, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			if (ProgettoComunicazioniAllegatiObj.Provider == null) ProgettoComunicazioniAllegatiObj.Provider = this.Provider;
			base.Insert(index, ProgettoComunicazioniAllegatiObj);
		}

		//CollectionGetById
		public ProgettoComunicazioniAllegati CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoComunicazioniAllegatiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdProgettoAllegatiEqualThis, 
NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdNoteEqualThis)
		{
			ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionTemp = new ProgettoComunicazioniAllegatiCollection();
			foreach (ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoComunicazioniAllegatiItem.Id != null) && (ProgettoComunicazioniAllegatiItem.Id.Value == IdEqualThis.Value))) && ((IdComunicazioneEqualThis == null) || ((ProgettoComunicazioniAllegatiItem.IdComunicazione != null) && (ProgettoComunicazioniAllegatiItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdProgettoAllegatiEqualThis == null) || ((ProgettoComunicazioniAllegatiItem.IdProgettoAllegati != null) && (ProgettoComunicazioniAllegatiItem.IdProgettoAllegati.Value == IdProgettoAllegatiEqualThis.Value))) && 
((IdAllegatoEqualThis == null) || ((ProgettoComunicazioniAllegatiItem.IdAllegato != null) && (ProgettoComunicazioniAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdNoteEqualThis == null) || ((ProgettoComunicazioniAllegatiItem.IdNote != null) && (ProgettoComunicazioniAllegatiItem.IdNote.Value == IdNoteEqualThis.Value))))
				{
					ProgettoComunicazioniAllegatiCollectionTemp.Add(ProgettoComunicazioniAllegatiItem);
				}
			}
			return ProgettoComunicazioniAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoComunicazioniAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoComunicazioniAllegatiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazione", ProgettoComunicazioniAllegatiObj.IdComunicazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgettoAllegati", ProgettoComunicazioniAllegatiObj.IdProgettoAllegati);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", ProgettoComunicazioniAllegatiObj.IdAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", ProgettoComunicazioniAllegatiObj.IdNote);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiInsert", new string[] {"IdComunicazione", "IdProgettoAllegati", 
"IdAllegato", "IdNote", 

}, new string[] {"int", "int", 
"int", "int", 

},"");
				CompileIUCmd(false, insertCmd,ProgettoComunicazioniAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoComunicazioniAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniAllegatiObj.IsDirty = false;
				ProgettoComunicazioniAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiUpdate", new string[] {"Id", "IdComunicazione", "IdProgettoAllegati", 
"IdAllegato", "IdNote", 

}, new string[] {"int", "int", "int", 
"int", "int", 

},"");
				CompileIUCmd(true, updateCmd,ProgettoComunicazioniAllegatiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniAllegatiObj.IsDirty = false;
				ProgettoComunicazioniAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			switch (ProgettoComunicazioniAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoComunicazioniAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoComunicazioniAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoComunicazioniAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiUpdate", new string[] {"Id", "IdComunicazione", "IdProgettoAllegati", 
"IdAllegato", "IdNote", 

}, new string[] {"int", "int", "int", 
"int", "int", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiInsert", new string[] {"IdComunicazione", "IdProgettoAllegati", 
"IdAllegato", "IdNote", 

}, new string[] {"int", "int", 
"int", "int", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniAllegatiCollectionObj.Count; i++)
				{
					switch (ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoComunicazioniAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoComunicazioniAllegatiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoComunicazioniAllegatiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoComunicazioniAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoComunicazioniAllegatiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj)
		{
			int returnValue = 0;
			if (ProgettoComunicazioniAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoComunicazioniAllegatiObj.Id);
			}
			ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoComunicazioniAllegatiObj.IsDirty = false;
			ProgettoComunicazioniAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioniAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoComunicazioniAllegatiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioniAllegatiCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioniAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsDirty = false;
						ProgettoComunicazioniAllegatiCollectionObj[i].IsPersistent = false;
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
		public static ProgettoComunicazioniAllegati GetById(DbProvider db, int IdValue)
		{
			ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoComunicazioniAllegatiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoComunicazioniAllegatiObj = GetFromDatareader(db);
				ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniAllegatiObj.IsDirty = false;
				ProgettoComunicazioniAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoComunicazioniAllegatiObj;
		}

		//getFromDatareader
		public static ProgettoComunicazioniAllegati GetFromDatareader(DbProvider db)
		{
			ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj = new ProgettoComunicazioniAllegati();
			ProgettoComunicazioniAllegatiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoComunicazioniAllegatiObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
			ProgettoComunicazioniAllegatiObj.IdProgettoAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_ALLEGATI"]);
			ProgettoComunicazioniAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			ProgettoComunicazioniAllegatiObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			ProgettoComunicazioniAllegatiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			ProgettoComunicazioniAllegatiObj.DescrizioneBreve = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BREVE"]);
			ProgettoComunicazioniAllegatiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			ProgettoComunicazioniAllegatiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoComunicazioniAllegatiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoComunicazioniAllegatiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoComunicazioniAllegatiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			ProgettoComunicazioniAllegatiObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
			ProgettoComunicazioniAllegatiObj.Allegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["ALLEGATO"]);
			ProgettoComunicazioniAllegatiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoComunicazioniAllegatiObj.IsDirty = false;
			ProgettoComunicazioniAllegatiObj.IsPersistent = true;
			return ProgettoComunicazioniAllegatiObj;
		}

		//Find Select

		public static ProgettoComunicazioniAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoAllegatiEqualThis, 
SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdNoteEqualThis)

		{

			ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionObj = new ProgettoComunicazioniAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazioniallegatifindselect", new string[] {"Idequalthis", "IdComunicazioneequalthis", "IdProgettoAllegatiequalthis", 
"IdAllegatoequalthis", "IdNoteequalthis"}, new string[] {"int", "int", "int", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoAllegatiequalthis", IdProgettoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniAllegatiObj = GetFromDatareader(db);
				ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniAllegatiObj.IsDirty = false;
				ProgettoComunicazioniAllegatiObj.IsPersistent = true;
				ProgettoComunicazioniAllegatiCollectionObj.Add(ProgettoComunicazioniAllegatiObj);
			}
			db.Close();
			return ProgettoComunicazioniAllegatiCollectionObj;
		}

		//Find Find

		public static ProgettoComunicazioniAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis)

		{

			ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionObj = new ProgettoComunicazioniAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazioniallegatifindfind", new string[] {"IdComunicazioneequalthis", "IdProgettoAllegatiequalthis", "IdAllegatoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoAllegatiequalthis", IdProgettoAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioniAllegatiObj = GetFromDatareader(db);
				ProgettoComunicazioniAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioniAllegatiObj.IsDirty = false;
				ProgettoComunicazioniAllegatiObj.IsPersistent = true;
				ProgettoComunicazioniAllegatiCollectionObj.Add(ProgettoComunicazioniAllegatiObj);
			}
			db.Close();
			return ProgettoComunicazioniAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioniAllegatiCollectionProvider:IProgettoComunicazioniAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioniAllegatiCollectionProvider : IProgettoComunicazioniAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoComunicazioniAllegati
		protected ProgettoComunicazioniAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoComunicazioniAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoComunicazioniAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoComunicazioniAllegatiCollectionProvider(IntNT IdcomunicazioneEqualThis, IntNT IdprogettoallegatiEqualThis, IntNT IdallegatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcomunicazioneEqualThis, IdprogettoallegatiEqualThis, IdallegatoEqualThis);
		}

		//Costruttore3: ha in input progettocomunicazioniallegatiCollectionObj - non popola la collection
		public ProgettoComunicazioniAllegatiCollectionProvider(ProgettoComunicazioniAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoComunicazioniAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoComunicazioniAllegatiCollection(this);
		}

		//Get e Set
		public ProgettoComunicazioniAllegatiCollection CollectionObj
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
		public int SaveCollection(ProgettoComunicazioniAllegatiCollection collectionObj)
		{
			return ProgettoComunicazioniAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoComunicazioniAllegati progettocomunicazioniallegatiObj)
		{
			return ProgettoComunicazioniAllegatiDAL.Save(_dbProviderObj, progettocomunicazioniallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoComunicazioniAllegatiCollection collectionObj)
		{
			return ProgettoComunicazioniAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoComunicazioniAllegati progettocomunicazioniallegatiObj)
		{
			return ProgettoComunicazioniAllegatiDAL.Delete(_dbProviderObj, progettocomunicazioniallegatiObj);
		}

		//getById
		public ProgettoComunicazioniAllegati GetById(IntNT IdValue)
		{
			ProgettoComunicazioniAllegati ProgettoComunicazioniAllegatiTemp = ProgettoComunicazioniAllegatiDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoComunicazioniAllegatiTemp!=null) ProgettoComunicazioniAllegatiTemp.Provider = this;
			return ProgettoComunicazioniAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoComunicazioniAllegatiCollection Select(IntNT IdEqualThis, IntNT IdcomunicazioneEqualThis, IntNT IdprogettoallegatiEqualThis, 
IntNT IdallegatoEqualThis, IntNT IdnoteEqualThis)
		{
			ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionTemp = ProgettoComunicazioniAllegatiDAL.Select(_dbProviderObj, IdEqualThis, IdcomunicazioneEqualThis, IdprogettoallegatiEqualThis, 
IdallegatoEqualThis, IdnoteEqualThis);
			ProgettoComunicazioniAllegatiCollectionTemp.Provider = this;
			return ProgettoComunicazioniAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoComunicazioniAllegatiCollection Find(IntNT IdcomunicazioneEqualThis, IntNT IdprogettoallegatiEqualThis, IntNT IdallegatoEqualThis)
		{
			ProgettoComunicazioniAllegatiCollection ProgettoComunicazioniAllegatiCollectionTemp = ProgettoComunicazioniAllegatiDAL.Find(_dbProviderObj, IdcomunicazioneEqualThis, IdprogettoallegatiEqualThis, IdallegatoEqualThis);
			ProgettoComunicazioniAllegatiCollectionTemp.Provider = this;
			return ProgettoComunicazioniAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_COMUNICAZIONI_ALLEGATI>
  <ViewName>vPROGETTO_COMUNICAZIONI_ALLEGATI</ViewName>
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
    <Find OrderBy="ORDER BY ID">
      <ID_COMUNICAZIONE>Equal</ID_COMUNICAZIONE>
      <ID_PROGETTO_ALLEGATI>Equal</ID_PROGETTO_ALLEGATI>
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONI_ALLEGATI>
*/
