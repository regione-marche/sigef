using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoProgrammazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoProgrammazioneProvider
	{
		int Save(BandoProgrammazione BandoProgrammazioneObj);
		int SaveCollection(BandoProgrammazioneCollection collectionObj);
		int Delete(BandoProgrammazione BandoProgrammazioneObj);
		int DeleteCollection(BandoProgrammazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoProgrammazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoProgrammazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.BoolNT _MisuraPrevalente;
		private NullTypes.IntNT _IdDisposizioniAttuative;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdPadre;
		private NullTypes.StringNT _CodPsr;
		private NullTypes.StringNT _Tipo;
		private NullTypes.IntNT _Livello;
		[NonSerialized] private IBandoProgrammazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoProgrammazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoProgrammazione()
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
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA_PREVALENTE
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT MisuraPrevalente
		{
			get { return _MisuraPrevalente; }
			set {
				if (MisuraPrevalente != value)
				{
					_MisuraPrevalente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DISPOSIZIONI_ATTUATIVE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDisposizioniAttuative
		{
			get { return _IdDisposizioniAttuative; }
			set {
				if (IdDisposizioniAttuative != value)
				{
					_IdDisposizioniAttuative = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:VARCHAR(30)
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

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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

		/// <summary>
		/// Corrisponde al campo:ID_PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPadre
		{
			get { return _IdPadre; }
			set {
				if (IdPadre != value)
				{
					_IdPadre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PSR
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodPsr
		{
			get { return _CodPsr; }
			set {
				if (CodPsr != value)
				{
					_CodPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Livello
		{
			get { return _Livello; }
			set {
				if (Livello != value)
				{
					_Livello = value;
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
	/// Summary description for BandoProgrammazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoProgrammazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoProgrammazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoProgrammazione) info.GetValue(i.ToString(),typeof(BandoProgrammazione)));
			}
		}

		//Costruttore
		public BandoProgrammazioneCollection()
		{
			this.ItemType = typeof(BandoProgrammazione);
		}

		//Costruttore con provider
		public BandoProgrammazioneCollection(IBandoProgrammazioneProvider providerObj)
		{
			this.ItemType = typeof(BandoProgrammazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoProgrammazione this[int index]
		{
			get { return (BandoProgrammazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoProgrammazioneCollection GetChanges()
		{
			return (BandoProgrammazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoProgrammazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoProgrammazioneProvider Provider
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
		public int Add(BandoProgrammazione BandoProgrammazioneObj)
		{
			if (BandoProgrammazioneObj.Provider == null) BandoProgrammazioneObj.Provider = this.Provider;
			return base.Add(BandoProgrammazioneObj);
		}

		//AddCollection
		public void AddCollection(BandoProgrammazioneCollection BandoProgrammazioneCollectionObj)
		{
			foreach (BandoProgrammazione BandoProgrammazioneObj in BandoProgrammazioneCollectionObj)
				this.Add(BandoProgrammazioneObj);
		}

		//Insert
		public void Insert(int index, BandoProgrammazione BandoProgrammazioneObj)
		{
			if (BandoProgrammazioneObj.Provider == null) BandoProgrammazioneObj.Provider = this.Provider;
			base.Insert(index, BandoProgrammazioneObj);
		}

		//CollectionGetById
		public BandoProgrammazione CollectionGetById(NullTypes.IntNT IdValue)
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
		public BandoProgrammazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, 
NullTypes.BoolNT MisuraPrevalenteEqualThis, NullTypes.IntNT IdDisposizioniAttuativeEqualThis)
		{
			BandoProgrammazioneCollection BandoProgrammazioneCollectionTemp = new BandoProgrammazioneCollection();
			foreach (BandoProgrammazione BandoProgrammazioneItem in this)
			{
				if (((IdEqualThis == null) || ((BandoProgrammazioneItem.Id != null) && (BandoProgrammazioneItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoProgrammazioneItem.IdBando != null) && (BandoProgrammazioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((BandoProgrammazioneItem.IdProgrammazione != null) && (BandoProgrammazioneItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && 
((MisuraPrevalenteEqualThis == null) || ((BandoProgrammazioneItem.MisuraPrevalente != null) && (BandoProgrammazioneItem.MisuraPrevalente.Value == MisuraPrevalenteEqualThis.Value))) && ((IdDisposizioniAttuativeEqualThis == null) || ((BandoProgrammazioneItem.IdDisposizioniAttuative != null) && (BandoProgrammazioneItem.IdDisposizioniAttuative.Value == IdDisposizioniAttuativeEqualThis.Value))))
				{
					BandoProgrammazioneCollectionTemp.Add(BandoProgrammazioneItem);
				}
			}
			return BandoProgrammazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoProgrammazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoProgrammazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoProgrammazione BandoProgrammazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BandoProgrammazioneObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoProgrammazioneObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", BandoProgrammazioneObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "MisuraPrevalente", BandoProgrammazioneObj.MisuraPrevalente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDisposizioniAttuative", BandoProgrammazioneObj.IdDisposizioniAttuative);
		}
		//Insert
		private static int Insert(DbProvider db, BandoProgrammazione BandoProgrammazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoProgrammazioneInsert", new string[] {"IdBando", "IdProgrammazione", 
"MisuraPrevalente", "IdDisposizioniAttuative", 
}, new string[] {"int", "int", 
"bool", "int", 
},"");
				CompileIUCmd(false, insertCmd,BandoProgrammazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoProgrammazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BandoProgrammazioneObj.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
				}
				BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoProgrammazioneObj.IsDirty = false;
				BandoProgrammazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoProgrammazione BandoProgrammazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoProgrammazioneUpdate", new string[] {"Id", "IdBando", "IdProgrammazione", 
"MisuraPrevalente", "IdDisposizioniAttuative", 
}, new string[] {"int", "int", "int", 
"bool", "int", 
},"");
				CompileIUCmd(true, updateCmd,BandoProgrammazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoProgrammazioneObj.IsDirty = false;
				BandoProgrammazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoProgrammazione BandoProgrammazioneObj)
		{
			switch (BandoProgrammazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoProgrammazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoProgrammazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoProgrammazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoProgrammazioneCollection BandoProgrammazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoProgrammazioneUpdate", new string[] {"Id", "IdBando", "IdProgrammazione", 
"MisuraPrevalente", "IdDisposizioniAttuative", 
}, new string[] {"int", "int", "int", 
"bool", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoProgrammazioneInsert", new string[] {"IdBando", "IdProgrammazione", 
"MisuraPrevalente", "IdDisposizioniAttuative", 
}, new string[] {"int", "int", 
"bool", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoProgrammazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoProgrammazioneCollectionObj.Count; i++)
				{
					switch (BandoProgrammazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoProgrammazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoProgrammazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BandoProgrammazioneCollectionObj[i].MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoProgrammazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoProgrammazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BandoProgrammazioneCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoProgrammazioneCollectionObj.Count; i++)
				{
					if ((BandoProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoProgrammazioneCollectionObj[i].IsDirty = false;
						BandoProgrammazioneCollectionObj[i].IsPersistent = true;
					}
					if ((BandoProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoProgrammazioneCollectionObj[i].IsDirty = false;
						BandoProgrammazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoProgrammazione BandoProgrammazioneObj)
		{
			int returnValue = 0;
			if (BandoProgrammazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoProgrammazioneObj.Id);
			}
			BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoProgrammazioneObj.IsDirty = false;
			BandoProgrammazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoProgrammazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoProgrammazioneCollection BandoProgrammazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoProgrammazioneDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BandoProgrammazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BandoProgrammazioneCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoProgrammazioneCollectionObj.Count; i++)
				{
					if ((BandoProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoProgrammazioneCollectionObj[i].IsDirty = false;
						BandoProgrammazioneCollectionObj[i].IsPersistent = false;
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
		public static BandoProgrammazione GetById(DbProvider db, int IdValue)
		{
			BandoProgrammazione BandoProgrammazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoProgrammazioneGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoProgrammazioneObj = GetFromDatareader(db);
				BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoProgrammazioneObj.IsDirty = false;
				BandoProgrammazioneObj.IsPersistent = true;
			}
			db.Close();
			return BandoProgrammazioneObj;
		}

		//getFromDatareader
		public static BandoProgrammazione GetFromDatareader(DbProvider db)
		{
			BandoProgrammazione BandoProgrammazioneObj = new BandoProgrammazione();
			BandoProgrammazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BandoProgrammazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoProgrammazioneObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			BandoProgrammazioneObj.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
			BandoProgrammazioneObj.IdDisposizioniAttuative = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DISPOSIZIONI_ATTUATIVE"]);
			BandoProgrammazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			BandoProgrammazioneObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			BandoProgrammazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoProgrammazioneObj.IdPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PADRE"]);
			BandoProgrammazioneObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			BandoProgrammazioneObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			BandoProgrammazioneObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoProgrammazioneObj.IsDirty = false;
			BandoProgrammazioneObj.IsPersistent = true;
			return BandoProgrammazioneObj;
		}

		//Find Select

		public static BandoProgrammazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, 
SiarLibrary.NullTypes.BoolNT MisuraPrevalenteEqualThis, SiarLibrary.NullTypes.IntNT IdDisposizioniAttuativeEqualThis)

		{

			BandoProgrammazioneCollection BandoProgrammazioneCollectionObj = new BandoProgrammazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoprogrammazionefindselect", new string[] {"Idequalthis", "IdBandoequalthis", "IdProgrammazioneequalthis", 
"MisuraPrevalenteequalthis", "IdDisposizioniAttuativeequalthis"}, new string[] {"int", "int", "int", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MisuraPrevalenteequalthis", MisuraPrevalenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDisposizioniAttuativeequalthis", IdDisposizioniAttuativeEqualThis);
			BandoProgrammazione BandoProgrammazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoProgrammazioneObj = GetFromDatareader(db);
				BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoProgrammazioneObj.IsDirty = false;
				BandoProgrammazioneObj.IsPersistent = true;
				BandoProgrammazioneCollectionObj.Add(BandoProgrammazioneObj);
			}
			db.Close();
			return BandoProgrammazioneCollectionObj;
		}

		//Find Find

		public static BandoProgrammazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT MisuraPrevalenteEqualThis, 
SiarLibrary.NullTypes.IntNT IdDisposizioniAttuativeEqualThis)

		{

			BandoProgrammazioneCollection BandoProgrammazioneCollectionObj = new BandoProgrammazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zbandoprogrammazionefindfind", new string[] {"IdBandoequalthis", "IdProgrammazioneequalthis", "MisuraPrevalenteequalthis", 
"IdDisposizioniAttuativeequalthis"}, new string[] {"int", "int", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MisuraPrevalenteequalthis", MisuraPrevalenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDisposizioniAttuativeequalthis", IdDisposizioniAttuativeEqualThis);
			BandoProgrammazione BandoProgrammazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoProgrammazioneObj = GetFromDatareader(db);
				BandoProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoProgrammazioneObj.IsDirty = false;
				BandoProgrammazioneObj.IsPersistent = true;
				BandoProgrammazioneCollectionObj.Add(BandoProgrammazioneObj);
			}
			db.Close();
			return BandoProgrammazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoProgrammazioneCollectionProvider:IBandoProgrammazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoProgrammazioneCollectionProvider : IBandoProgrammazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoProgrammazione
		protected BandoProgrammazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoProgrammazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoProgrammazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoProgrammazioneCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT MisuraprevalenteEqualThis, 
IntNT IddisposizioniattuativeEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogrammazioneEqualThis, MisuraprevalenteEqualThis, 
IddisposizioniattuativeEqualThis);
		}

		//Costruttore3: ha in input bandoprogrammazioneCollectionObj - non popola la collection
		public BandoProgrammazioneCollectionProvider(BandoProgrammazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoProgrammazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoProgrammazioneCollection(this);
		}

		//Get e Set
		public BandoProgrammazioneCollection CollectionObj
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
		public int SaveCollection(BandoProgrammazioneCollection collectionObj)
		{
			return BandoProgrammazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoProgrammazione bandoprogrammazioneObj)
		{
			return BandoProgrammazioneDAL.Save(_dbProviderObj, bandoprogrammazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoProgrammazioneCollection collectionObj)
		{
			return BandoProgrammazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoProgrammazione bandoprogrammazioneObj)
		{
			return BandoProgrammazioneDAL.Delete(_dbProviderObj, bandoprogrammazioneObj);
		}

		//getById
		public BandoProgrammazione GetById(IntNT IdValue)
		{
			BandoProgrammazione BandoProgrammazioneTemp = BandoProgrammazioneDAL.GetById(_dbProviderObj, IdValue);
			if (BandoProgrammazioneTemp!=null) BandoProgrammazioneTemp.Provider = this;
			return BandoProgrammazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoProgrammazioneCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis, 
BoolNT MisuraprevalenteEqualThis, IntNT IddisposizioniattuativeEqualThis)
		{
			BandoProgrammazioneCollection BandoProgrammazioneCollectionTemp = BandoProgrammazioneDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, IdprogrammazioneEqualThis, 
MisuraprevalenteEqualThis, IddisposizioniattuativeEqualThis);
			BandoProgrammazioneCollectionTemp.Provider = this;
			return BandoProgrammazioneCollectionTemp;
		}

		//Find: popola la collection
		public BandoProgrammazioneCollection Find(IntNT IdbandoEqualThis, IntNT IdprogrammazioneEqualThis, BoolNT MisuraprevalenteEqualThis, 
IntNT IddisposizioniattuativeEqualThis)
		{
			BandoProgrammazioneCollection BandoProgrammazioneCollectionTemp = BandoProgrammazioneDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogrammazioneEqualThis, MisuraprevalenteEqualThis, 
IddisposizioniattuativeEqualThis);
			BandoProgrammazioneCollectionTemp.Provider = this;
			return BandoProgrammazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_PROGRAMMAZIONE>
  <ViewName>vBANDO_PROGRAMMAZIONE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY MISURA_PREVALENTE DESC, CODICE">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <MISURA_PREVALENTE>Equal</MISURA_PREVALENTE>
      <ID_DISPOSIZIONI_ATTUATIVE>Equal</ID_DISPOSIZIONI_ATTUATIVE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_PROGRAMMAZIONE>
*/
