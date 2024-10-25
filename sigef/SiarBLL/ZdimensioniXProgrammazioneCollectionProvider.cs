using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZdimensioniXProgrammazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZdimensioniXProgrammazioneProvider
	{
		int Save(ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj);
		int SaveCollection(ZdimensioniXProgrammazioneCollection collectionObj);
		int Delete(ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj);
		int DeleteCollection(ZdimensioniXProgrammazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZdimensioniXProgrammazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZdimensioniXProgrammazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.IntNT _IdDimensione;
		private NullTypes.IntNT _IdDimXProgrammazione;
		private NullTypes.StringNT _CodDim;
		private NullTypes.StringNT _CodProgrammazione;
		private NullTypes.StringNT _DesProgrammazione;
		private NullTypes.StringNT _LivelloProgrammazione;
		private NullTypes.StringNT _CodDimensione;
		private NullTypes.StringNT _DesDimensione;
		private NullTypes.StringNT _Um;
		[NonSerialized] private IZdimensioniXProgrammazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniXProgrammazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZdimensioniXProgrammazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimensione
		{
			get { return _IdDimensione; }
			set {
				if (IdDimensione != value)
				{
					_IdDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIM_X_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimXProgrammazione
		{
			get { return _IdDimXProgrammazione; }
			set {
				if (IdDimXProgrammazione != value)
				{
					_IdDimXProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_DIM
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodDim
		{
			get { return _CodDim; }
			set {
				if (CodDim != value)
				{
					_CodDim = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodProgrammazione
		{
			get { return _CodProgrammazione; }
			set {
				if (CodProgrammazione != value)
				{
					_CodProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DES_PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DesProgrammazione
		{
			get { return _DesProgrammazione; }
			set {
				if (DesProgrammazione != value)
				{
					_DesProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO_PROGRAMMAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT LivelloProgrammazione
		{
			get { return _LivelloProgrammazione; }
			set {
				if (LivelloProgrammazione != value)
				{
					_LivelloProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_DIMENSIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodDimensione
		{
			get { return _CodDimensione; }
			set {
				if (CodDimensione != value)
				{
					_CodDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DES_DIMENSIONE
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT DesDimensione
		{
			get { return _DesDimensione; }
			set {
				if (DesDimensione != value)
				{
					_DesDimensione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UM
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Um
		{
			get { return _Um; }
			set {
				if (Um != value)
				{
					_Um = value;
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
	/// Summary description for ZdimensioniXProgrammazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniXProgrammazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZdimensioniXProgrammazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZdimensioniXProgrammazione) info.GetValue(i.ToString(),typeof(ZdimensioniXProgrammazione)));
			}
		}

		//Costruttore
		public ZdimensioniXProgrammazioneCollection()
		{
			this.ItemType = typeof(ZdimensioniXProgrammazione);
		}

		//Costruttore con provider
		public ZdimensioniXProgrammazioneCollection(IZdimensioniXProgrammazioneProvider providerObj)
		{
			this.ItemType = typeof(ZdimensioniXProgrammazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZdimensioniXProgrammazione this[int index]
		{
			get { return (ZdimensioniXProgrammazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZdimensioniXProgrammazioneCollection GetChanges()
		{
			return (ZdimensioniXProgrammazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IZdimensioniXProgrammazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniXProgrammazioneProvider Provider
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
		public int Add(ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			if (ZdimensioniXProgrammazioneObj.Provider == null) ZdimensioniXProgrammazioneObj.Provider = this.Provider;
			return base.Add(ZdimensioniXProgrammazioneObj);
		}

		//AddCollection
		public void AddCollection(ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionObj)
		{
			foreach (ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj in ZdimensioniXProgrammazioneCollectionObj)
				this.Add(ZdimensioniXProgrammazioneObj);
		}

		//Insert
		public void Insert(int index, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			if (ZdimensioniXProgrammazioneObj.Provider == null) ZdimensioniXProgrammazioneObj.Provider = this.Provider;
			base.Insert(index, ZdimensioniXProgrammazioneObj);
		}

		//CollectionGetById
		public ZdimensioniXProgrammazione CollectionGetById(NullTypes.IntNT IdDimXProgrammazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDimXProgrammazione == IdDimXProgrammazioneValue))
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
		public ZdimensioniXProgrammazioneCollection SubSelect(NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.IntNT IdDimensioneEqualThis, NullTypes.IntNT IdDimXProgrammazioneEqualThis)
		{
			ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionTemp = new ZdimensioniXProgrammazioneCollection();
			foreach (ZdimensioniXProgrammazione ZdimensioniXProgrammazioneItem in this)
			{
				if (((IdProgrammazioneEqualThis == null) || ((ZdimensioniXProgrammazioneItem.IdProgrammazione != null) && (ZdimensioniXProgrammazioneItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((IdDimensioneEqualThis == null) || ((ZdimensioniXProgrammazioneItem.IdDimensione != null) && (ZdimensioniXProgrammazioneItem.IdDimensione.Value == IdDimensioneEqualThis.Value))) && ((IdDimXProgrammazioneEqualThis == null) || ((ZdimensioniXProgrammazioneItem.IdDimXProgrammazione != null) && (ZdimensioniXProgrammazioneItem.IdDimXProgrammazione.Value == IdDimXProgrammazioneEqualThis.Value))))
				{
					ZdimensioniXProgrammazioneCollectionTemp.Add(ZdimensioniXProgrammazioneItem);
				}
			}
			return ZdimensioniXProgrammazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZdimensioniXProgrammazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZdimensioniXProgrammazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDimXProgrammazione", ZdimensioniXProgrammazioneObj.IdDimXProgrammazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZdimensioniXProgrammazioneObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDimensione", ZdimensioniXProgrammazioneObj.IdDimensione);
		}
		//Insert
		private static int Insert(DbProvider db, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniXProgrammazioneInsert", new string[] {"IdProgrammazione", "IdDimensione", 

}, new string[] {"int", "int", 

},"");
				CompileIUCmd(false, insertCmd,ZdimensioniXProgrammazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZdimensioniXProgrammazioneObj.IdDimXProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_X_PROGRAMMAZIONE"]);
				}
				ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniXProgrammazioneObj.IsDirty = false;
				ZdimensioniXProgrammazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniXProgrammazioneUpdate", new string[] {"IdProgrammazione", "IdDimensione", "IdDimXProgrammazione", 

}, new string[] {"int", "int", "int", 

},"");
				CompileIUCmd(true, updateCmd,ZdimensioniXProgrammazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniXProgrammazioneObj.IsDirty = false;
				ZdimensioniXProgrammazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			switch (ZdimensioniXProgrammazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZdimensioniXProgrammazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZdimensioniXProgrammazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZdimensioniXProgrammazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniXProgrammazioneUpdate", new string[] {"IdProgrammazione", "IdDimensione", "IdDimXProgrammazione", 

}, new string[] {"int", "int", "int", 

},"");
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniXProgrammazioneInsert", new string[] {"IdProgrammazione", "IdDimensione", 

}, new string[] {"int", "int", 

},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniXProgrammazioneDelete", new string[] {"IdDimXProgrammazione"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniXProgrammazioneCollectionObj.Count; i++)
				{
					switch (ZdimensioniXProgrammazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZdimensioniXProgrammazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZdimensioniXProgrammazioneCollectionObj[i].IdDimXProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_X_PROGRAMMAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZdimensioniXProgrammazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZdimensioniXProgrammazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDimXProgrammazione", (SiarLibrary.NullTypes.IntNT)ZdimensioniXProgrammazioneCollectionObj[i].IdDimXProgrammazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniXProgrammazioneCollectionObj.Count; i++)
				{
					if ((ZdimensioniXProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniXProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniXProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZdimensioniXProgrammazioneCollectionObj[i].IsDirty = false;
						ZdimensioniXProgrammazioneCollectionObj[i].IsPersistent = true;
					}
					if ((ZdimensioniXProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZdimensioniXProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniXProgrammazioneCollectionObj[i].IsDirty = false;
						ZdimensioniXProgrammazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj)
		{
			int returnValue = 0;
			if (ZdimensioniXProgrammazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, ZdimensioniXProgrammazioneObj.IdDimXProgrammazione);
			}
			ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZdimensioniXProgrammazioneObj.IsDirty = false;
			ZdimensioniXProgrammazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDimXProgrammazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniXProgrammazioneDelete", new string[] {"IdDimXProgrammazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDimXProgrammazione", (SiarLibrary.NullTypes.IntNT)IdDimXProgrammazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniXProgrammazioneDelete", new string[] {"IdDimXProgrammazione"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniXProgrammazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDimXProgrammazione", ZdimensioniXProgrammazioneCollectionObj[i].IdDimXProgrammazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniXProgrammazioneCollectionObj.Count; i++)
				{
					if ((ZdimensioniXProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniXProgrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniXProgrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniXProgrammazioneCollectionObj[i].IsDirty = false;
						ZdimensioniXProgrammazioneCollectionObj[i].IsPersistent = false;
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
		public static ZdimensioniXProgrammazione GetById(DbProvider db, int IdDimXProgrammazioneValue)
		{
			ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZdimensioniXProgrammazioneGetById", new string[] {"IdDimXProgrammazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDimXProgrammazione", (SiarLibrary.NullTypes.IntNT)IdDimXProgrammazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZdimensioniXProgrammazioneObj = GetFromDatareader(db);
				ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniXProgrammazioneObj.IsDirty = false;
				ZdimensioniXProgrammazioneObj.IsPersistent = true;
			}
			db.Close();
			return ZdimensioniXProgrammazioneObj;
		}

		//getFromDatareader
		public static ZdimensioniXProgrammazione GetFromDatareader(DbProvider db)
		{
			ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj = new ZdimensioniXProgrammazione();
			ZdimensioniXProgrammazioneObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZdimensioniXProgrammazioneObj.IdDimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIMENSIONE"]);
			ZdimensioniXProgrammazioneObj.IdDimXProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_X_PROGRAMMAZIONE"]);
			ZdimensioniXProgrammazioneObj.CodDim = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DIM"]);
			ZdimensioniXProgrammazioneObj.CodProgrammazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PROGRAMMAZIONE"]);
			ZdimensioniXProgrammazioneObj.DesProgrammazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DES_PROGRAMMAZIONE"]);
			ZdimensioniXProgrammazioneObj.LivelloProgrammazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["LIVELLO_PROGRAMMAZIONE"]);
			ZdimensioniXProgrammazioneObj.CodDimensione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DIMENSIONE"]);
			ZdimensioniXProgrammazioneObj.DesDimensione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DES_DIMENSIONE"]);
			ZdimensioniXProgrammazioneObj.Um = new SiarLibrary.NullTypes.StringNT(db.DataReader["UM"]);
			ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZdimensioniXProgrammazioneObj.IsDirty = false;
			ZdimensioniXProgrammazioneObj.IsPersistent = true;
			return ZdimensioniXProgrammazioneObj;
		}

		//Find Select

		public static ZdimensioniXProgrammazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDimensioneEqualThis, SiarLibrary.NullTypes.IntNT IdDimXProgrammazioneEqualThis)

		{

			ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionObj = new ZdimensioniXProgrammazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zzdimensionixprogrammazionefindselect", new string[] {"IdProgrammazioneequalthis", "IdDimensioneequalthis", "IdDimXProgrammazioneequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDimensioneequalthis", IdDimensioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDimXProgrammazioneequalthis", IdDimXProgrammazioneEqualThis);
			ZdimensioniXProgrammazione ZdimensioniXProgrammazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZdimensioniXProgrammazioneObj = GetFromDatareader(db);
				ZdimensioniXProgrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniXProgrammazioneObj.IsDirty = false;
				ZdimensioniXProgrammazioneObj.IsPersistent = true;
				ZdimensioniXProgrammazioneCollectionObj.Add(ZdimensioniXProgrammazioneObj);
			}
			db.Close();
			return ZdimensioniXProgrammazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZdimensioniXProgrammazioneCollectionProvider:IZdimensioniXProgrammazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniXProgrammazioneCollectionProvider : IZdimensioniXProgrammazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZdimensioniXProgrammazione
		protected ZdimensioniXProgrammazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZdimensioniXProgrammazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZdimensioniXProgrammazioneCollection(this);
		}

		//Costruttore3: ha in input zdimensionixprogrammazioneCollectionObj - non popola la collection
		public ZdimensioniXProgrammazioneCollectionProvider(ZdimensioniXProgrammazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZdimensioniXProgrammazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZdimensioniXProgrammazioneCollection(this);
		}

		//Get e Set
		public ZdimensioniXProgrammazioneCollection CollectionObj
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
		public int SaveCollection(ZdimensioniXProgrammazioneCollection collectionObj)
		{
			return ZdimensioniXProgrammazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZdimensioniXProgrammazione zdimensionixprogrammazioneObj)
		{
			return ZdimensioniXProgrammazioneDAL.Save(_dbProviderObj, zdimensionixprogrammazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZdimensioniXProgrammazioneCollection collectionObj)
		{
			return ZdimensioniXProgrammazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZdimensioniXProgrammazione zdimensionixprogrammazioneObj)
		{
			return ZdimensioniXProgrammazioneDAL.Delete(_dbProviderObj, zdimensionixprogrammazioneObj);
		}

		//getById
		public ZdimensioniXProgrammazione GetById(IntNT IdDimXProgrammazioneValue)
		{
			ZdimensioniXProgrammazione ZdimensioniXProgrammazioneTemp = ZdimensioniXProgrammazioneDAL.GetById(_dbProviderObj, IdDimXProgrammazioneValue);
			if (ZdimensioniXProgrammazioneTemp!=null) ZdimensioniXProgrammazioneTemp.Provider = this;
			return ZdimensioniXProgrammazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZdimensioniXProgrammazioneCollection Select(IntNT IdprogrammazioneEqualThis, IntNT IddimensioneEqualThis, IntNT IddimxprogrammazioneEqualThis)
		{
			ZdimensioniXProgrammazioneCollection ZdimensioniXProgrammazioneCollectionTemp = ZdimensioniXProgrammazioneDAL.Select(_dbProviderObj, IdprogrammazioneEqualThis, IddimensioneEqualThis, IddimxprogrammazioneEqualThis);
			ZdimensioniXProgrammazioneCollectionTemp.Provider = this;
			return ZdimensioniXProgrammazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zDIMENSIONI_X_PROGRAMMAZIONE>
  <ViewName>vzDIMENSIONI_X_PROGRAMMAZIONE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</zDIMENSIONI_X_PROGRAMMAZIONE>
*/
