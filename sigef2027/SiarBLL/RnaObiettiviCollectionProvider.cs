using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RnaObiettivi
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRnaObiettiviProvider
	{
		int Save(RnaObiettivi RnaObiettiviObj);
		int SaveCollection(RnaObiettiviCollection collectionObj);
		int Delete(RnaObiettivi RnaObiettiviObj);
		int DeleteCollection(RnaObiettiviCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RnaObiettivi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RnaObiettivi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdObiettivo;
		private NullTypes.StringNT _CodiceRegolamento;
		private NullTypes.StringNT _Regolamento;
		private NullTypes.StringNT _CodObiettivo;
		private NullTypes.StringNT _MacroObiettivo;
		private NullTypes.StringNT _Obiettivo;
		[NonSerialized] private IRnaObiettiviProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaObiettiviProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RnaObiettivi()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_OBIETTIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdObiettivo
		{
			get { return _IdObiettivo; }
			set {
				if (IdObiettivo != value)
				{
					_IdObiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_REGOLAMENTO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodiceRegolamento
		{
			get { return _CodiceRegolamento; }
			set {
				if (CodiceRegolamento != value)
				{
					_CodiceRegolamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REGOLAMENTO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Regolamento
		{
			get { return _Regolamento; }
			set {
				if (Regolamento != value)
				{
					_Regolamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_OBIETTIVO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodObiettivo
		{
			get { return _CodObiettivo; }
			set {
				if (CodObiettivo != value)
				{
					_CodObiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MACRO_OBIETTIVO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT MacroObiettivo
		{
			get { return _MacroObiettivo; }
			set {
				if (MacroObiettivo != value)
				{
					_MacroObiettivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OBIETTIVO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Obiettivo
		{
			get { return _Obiettivo; }
			set {
				if (Obiettivo != value)
				{
					_Obiettivo = value;
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
	/// Summary description for RnaObiettiviCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaObiettiviCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RnaObiettiviCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RnaObiettivi) info.GetValue(i.ToString(),typeof(RnaObiettivi)));
			}
		}

		//Costruttore
		public RnaObiettiviCollection()
		{
			this.ItemType = typeof(RnaObiettivi);
		}

		//Costruttore con provider
		public RnaObiettiviCollection(IRnaObiettiviProvider providerObj)
		{
			this.ItemType = typeof(RnaObiettivi);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RnaObiettivi this[int index]
		{
			get { return (RnaObiettivi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RnaObiettiviCollection GetChanges()
		{
			return (RnaObiettiviCollection) base.GetChanges();
		}

		[NonSerialized] private IRnaObiettiviProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRnaObiettiviProvider Provider
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
		public int Add(RnaObiettivi RnaObiettiviObj)
		{
			if (RnaObiettiviObj.Provider == null) RnaObiettiviObj.Provider = this.Provider;
			return base.Add(RnaObiettiviObj);
		}

		//AddCollection
		public void AddCollection(RnaObiettiviCollection RnaObiettiviCollectionObj)
		{
			foreach (RnaObiettivi RnaObiettiviObj in RnaObiettiviCollectionObj)
				this.Add(RnaObiettiviObj);
		}

		//Insert
		public void Insert(int index, RnaObiettivi RnaObiettiviObj)
		{
			if (RnaObiettiviObj.Provider == null) RnaObiettiviObj.Provider = this.Provider;
			base.Insert(index, RnaObiettiviObj);
		}

		//CollectionGetById
		public RnaObiettivi CollectionGetById(NullTypes.IntNT IdObiettivoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdObiettivo == IdObiettivoValue))
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
		public RnaObiettiviCollection SubSelect(NullTypes.IntNT IdObiettivoEqualThis, NullTypes.StringNT CodiceRegolamentoEqualThis, NullTypes.StringNT RegolamentoEqualThis, 
NullTypes.StringNT CodObiettivoEqualThis, NullTypes.StringNT MacroObiettivoEqualThis, NullTypes.StringNT ObiettivoEqualThis)
		{
			RnaObiettiviCollection RnaObiettiviCollectionTemp = new RnaObiettiviCollection();
			foreach (RnaObiettivi RnaObiettiviItem in this)
			{
				if (((IdObiettivoEqualThis == null) || ((RnaObiettiviItem.IdObiettivo != null) && (RnaObiettiviItem.IdObiettivo.Value == IdObiettivoEqualThis.Value))) && ((CodiceRegolamentoEqualThis == null) || ((RnaObiettiviItem.CodiceRegolamento != null) && (RnaObiettiviItem.CodiceRegolamento.Value == CodiceRegolamentoEqualThis.Value))) && ((RegolamentoEqualThis == null) || ((RnaObiettiviItem.Regolamento != null) && (RnaObiettiviItem.Regolamento.Value == RegolamentoEqualThis.Value))) && 
((CodObiettivoEqualThis == null) || ((RnaObiettiviItem.CodObiettivo != null) && (RnaObiettiviItem.CodObiettivo.Value == CodObiettivoEqualThis.Value))) && ((MacroObiettivoEqualThis == null) || ((RnaObiettiviItem.MacroObiettivo != null) && (RnaObiettiviItem.MacroObiettivo.Value == MacroObiettivoEqualThis.Value))) && ((ObiettivoEqualThis == null) || ((RnaObiettiviItem.Obiettivo != null) && (RnaObiettiviItem.Obiettivo.Value == ObiettivoEqualThis.Value))))
				{
					RnaObiettiviCollectionTemp.Add(RnaObiettiviItem);
				}
			}
			return RnaObiettiviCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RnaObiettiviDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RnaObiettiviDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RnaObiettivi RnaObiettiviObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdObiettivo", RnaObiettiviObj.IdObiettivo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceRegolamento", RnaObiettiviObj.CodiceRegolamento);
			DbProvider.SetCmdParam(cmd,firstChar + "Regolamento", RnaObiettiviObj.Regolamento);
			DbProvider.SetCmdParam(cmd,firstChar + "CodObiettivo", RnaObiettiviObj.CodObiettivo);
			DbProvider.SetCmdParam(cmd,firstChar + "MacroObiettivo", RnaObiettiviObj.MacroObiettivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Obiettivo", RnaObiettiviObj.Obiettivo);
		}
		//Insert
		private static int Insert(DbProvider db, RnaObiettivi RnaObiettiviObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRnaObiettiviInsert", new string[] {"CodiceRegolamento", "Regolamento", 
"CodObiettivo", "MacroObiettivo", "Obiettivo"}, new string[] {"string", "string", 
"string", "string", "string"},"");
				CompileIUCmd(false, insertCmd,RnaObiettiviObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RnaObiettiviObj.IdObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO"]);
				}
				RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaObiettiviObj.IsDirty = false;
				RnaObiettiviObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RnaObiettivi RnaObiettiviObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaObiettiviUpdate", new string[] {"IdObiettivo", "CodiceRegolamento", "Regolamento", 
"CodObiettivo", "MacroObiettivo", "Obiettivo"}, new string[] {"int", "string", "string", 
"string", "string", "string"},"");
				CompileIUCmd(true, updateCmd,RnaObiettiviObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaObiettiviObj.IsDirty = false;
				RnaObiettiviObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RnaObiettivi RnaObiettiviObj)
		{
			switch (RnaObiettiviObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RnaObiettiviObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RnaObiettiviObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RnaObiettiviObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RnaObiettiviCollection RnaObiettiviCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRnaObiettiviUpdate", new string[] {"IdObiettivo", "CodiceRegolamento", "Regolamento", 
"CodObiettivo", "MacroObiettivo", "Obiettivo"}, new string[] {"int", "string", "string", 
"string", "string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZRnaObiettiviInsert", new string[] {"CodiceRegolamento", "Regolamento", 
"CodObiettivo", "MacroObiettivo", "Obiettivo"}, new string[] {"string", "string", 
"string", "string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRnaObiettiviDelete", new string[] {"IdObiettivo"}, new string[] {"int"},"");
				for (int i = 0; i < RnaObiettiviCollectionObj.Count; i++)
				{
					switch (RnaObiettiviCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RnaObiettiviCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RnaObiettiviCollectionObj[i].IdObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RnaObiettiviCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RnaObiettiviCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdObiettivo", (SiarLibrary.NullTypes.IntNT)RnaObiettiviCollectionObj[i].IdObiettivo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RnaObiettiviCollectionObj.Count; i++)
				{
					if ((RnaObiettiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaObiettiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaObiettiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RnaObiettiviCollectionObj[i].IsDirty = false;
						RnaObiettiviCollectionObj[i].IsPersistent = true;
					}
					if ((RnaObiettiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RnaObiettiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaObiettiviCollectionObj[i].IsDirty = false;
						RnaObiettiviCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RnaObiettivi RnaObiettiviObj)
		{
			int returnValue = 0;
			if (RnaObiettiviObj.IsPersistent) 
			{
				returnValue = Delete(db, RnaObiettiviObj.IdObiettivo);
			}
			RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RnaObiettiviObj.IsDirty = false;
			RnaObiettiviObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdObiettivoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaObiettiviDelete", new string[] {"IdObiettivo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdObiettivo", (SiarLibrary.NullTypes.IntNT)IdObiettivoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RnaObiettiviCollection RnaObiettiviCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRnaObiettiviDelete", new string[] {"IdObiettivo"}, new string[] {"int"},"");
				for (int i = 0; i < RnaObiettiviCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdObiettivo", RnaObiettiviCollectionObj[i].IdObiettivo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RnaObiettiviCollectionObj.Count; i++)
				{
					if ((RnaObiettiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RnaObiettiviCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RnaObiettiviCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RnaObiettiviCollectionObj[i].IsDirty = false;
						RnaObiettiviCollectionObj[i].IsPersistent = false;
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
		public static RnaObiettivi GetById(DbProvider db, int IdObiettivoValue)
		{
			RnaObiettivi RnaObiettiviObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRnaObiettiviGetById", new string[] {"IdObiettivo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdObiettivo", (SiarLibrary.NullTypes.IntNT)IdObiettivoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RnaObiettiviObj = GetFromDatareader(db);
				RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaObiettiviObj.IsDirty = false;
				RnaObiettiviObj.IsPersistent = true;
			}
			db.Close();
			return RnaObiettiviObj;
		}

		//getFromDatareader
		public static RnaObiettivi GetFromDatareader(DbProvider db)
		{
			RnaObiettivi RnaObiettiviObj = new RnaObiettivi();
			RnaObiettiviObj.IdObiettivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO"]);
			RnaObiettiviObj.CodiceRegolamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_REGOLAMENTO"]);
			RnaObiettiviObj.Regolamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGOLAMENTO"]);
			RnaObiettiviObj.CodObiettivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_OBIETTIVO"]);
			RnaObiettiviObj.MacroObiettivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["MACRO_OBIETTIVO"]);
			RnaObiettiviObj.Obiettivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OBIETTIVO"]);
			RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RnaObiettiviObj.IsDirty = false;
			RnaObiettiviObj.IsPersistent = true;
			return RnaObiettiviObj;
		}

		//Find Select

		public static RnaObiettiviCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdObiettivoEqualThis, SiarLibrary.NullTypes.StringNT CodiceRegolamentoEqualThis, SiarLibrary.NullTypes.StringNT RegolamentoEqualThis, 
SiarLibrary.NullTypes.StringNT CodObiettivoEqualThis, SiarLibrary.NullTypes.StringNT MacroObiettivoEqualThis, SiarLibrary.NullTypes.StringNT ObiettivoEqualThis)

		{

			RnaObiettiviCollection RnaObiettiviCollectionObj = new RnaObiettiviCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaobiettivifindselect", new string[] {"IdObiettivoequalthis", "CodiceRegolamentoequalthis", "Regolamentoequalthis", 
"CodObiettivoequalthis", "MacroObiettivoequalthis", "Obiettivoequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdObiettivoequalthis", IdObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRegolamentoequalthis", CodiceRegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Regolamentoequalthis", RegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodObiettivoequalthis", CodObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "MacroObiettivoequalthis", MacroObiettivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obiettivoequalthis", ObiettivoEqualThis);
			RnaObiettivi RnaObiettiviObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaObiettiviObj = GetFromDatareader(db);
				RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaObiettiviObj.IsDirty = false;
				RnaObiettiviObj.IsPersistent = true;
				RnaObiettiviCollectionObj.Add(RnaObiettiviObj);
			}
			db.Close();
			return RnaObiettiviCollectionObj;
		}

		//Find Find

		public static RnaObiettiviCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceRegolamentoEqualThis, SiarLibrary.NullTypes.IntNT IdObiettivoEqualThis)

		{

			RnaObiettiviCollection RnaObiettiviCollectionObj = new RnaObiettiviCollection();

			IDbCommand findCmd = db.InitCmd("Zrnaobiettivifindfind", new string[] {"CodiceRegolamentoequalthis", "IdObiettivoequalthis"}, new string[] {"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceRegolamentoequalthis", CodiceRegolamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdObiettivoequalthis", IdObiettivoEqualThis);
			RnaObiettivi RnaObiettiviObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RnaObiettiviObj = GetFromDatareader(db);
				RnaObiettiviObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RnaObiettiviObj.IsDirty = false;
				RnaObiettiviObj.IsPersistent = true;
				RnaObiettiviCollectionObj.Add(RnaObiettiviObj);
			}
			db.Close();
			return RnaObiettiviCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RnaObiettiviCollectionProvider:IRnaObiettiviProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RnaObiettiviCollectionProvider : IRnaObiettiviProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RnaObiettivi
		protected RnaObiettiviCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RnaObiettiviCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RnaObiettiviCollection(this);
		}

		//Costruttore 2: popola la collection
		public RnaObiettiviCollectionProvider(StringNT CodiceregolamentoEqualThis, IntNT IdobiettivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodiceregolamentoEqualThis, IdobiettivoEqualThis);
		}

		//Costruttore3: ha in input rnaobiettiviCollectionObj - non popola la collection
		public RnaObiettiviCollectionProvider(RnaObiettiviCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RnaObiettiviCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RnaObiettiviCollection(this);
		}

		//Get e Set
		public RnaObiettiviCollection CollectionObj
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
		public int SaveCollection(RnaObiettiviCollection collectionObj)
		{
			return RnaObiettiviDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RnaObiettivi rnaobiettiviObj)
		{
			return RnaObiettiviDAL.Save(_dbProviderObj, rnaobiettiviObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RnaObiettiviCollection collectionObj)
		{
			return RnaObiettiviDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RnaObiettivi rnaobiettiviObj)
		{
			return RnaObiettiviDAL.Delete(_dbProviderObj, rnaobiettiviObj);
		}

		//getById
		public RnaObiettivi GetById(IntNT IdObiettivoValue)
		{
			RnaObiettivi RnaObiettiviTemp = RnaObiettiviDAL.GetById(_dbProviderObj, IdObiettivoValue);
			if (RnaObiettiviTemp!=null) RnaObiettiviTemp.Provider = this;
			return RnaObiettiviTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RnaObiettiviCollection Select(IntNT IdobiettivoEqualThis, StringNT CodiceregolamentoEqualThis, StringNT RegolamentoEqualThis, 
StringNT CodobiettivoEqualThis, StringNT MacroobiettivoEqualThis, StringNT ObiettivoEqualThis)
		{
			RnaObiettiviCollection RnaObiettiviCollectionTemp = RnaObiettiviDAL.Select(_dbProviderObj, IdobiettivoEqualThis, CodiceregolamentoEqualThis, RegolamentoEqualThis, 
CodobiettivoEqualThis, MacroobiettivoEqualThis, ObiettivoEqualThis);
			RnaObiettiviCollectionTemp.Provider = this;
			return RnaObiettiviCollectionTemp;
		}

		//Find: popola la collection
		public RnaObiettiviCollection Find(StringNT CodiceregolamentoEqualThis, IntNT IdobiettivoEqualThis)
		{
			RnaObiettiviCollection RnaObiettiviCollectionTemp = RnaObiettiviDAL.Find(_dbProviderObj, CodiceregolamentoEqualThis, IdobiettivoEqualThis);
			RnaObiettiviCollectionTemp.Provider = this;
			return RnaObiettiviCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RNA_OBIETTIVI>
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
      <CODICE_REGOLAMENTO>Equal</CODICE_REGOLAMENTO>
      <ID_OBIETTIVO>Equal</ID_OBIETTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RNA_OBIETTIVI>
*/
