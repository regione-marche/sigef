using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Funzionalita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFunzionalitaProvider
	{
		int Save(Funzionalita FunzionalitaObj);
		int SaveCollection(FunzionalitaCollection collectionObj);
		int Delete(Funzionalita FunzionalitaObj);
		int DeleteCollection(FunzionalitaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Funzionalita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Funzionalita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _CodFunzione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagMenu;
		private NullTypes.StringNT _DescMenu;
		private NullTypes.IntNT _Livello;
		private NullTypes.IntNT _Padre;
		private NullTypes.StringNT _Link;
		private NullTypes.IntNT _Ordine;
		[NonSerialized] private IFunzionalitaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFunzionalitaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Funzionalita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_FUNZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodFunzione
		{
			get { return _CodFunzione; }
			set {
				if (CodFunzione != value)
				{
					_CodFunzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:FLAG_MENU
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagMenu
		{
			get { return _FlagMenu; }
			set {
				if (FlagMenu != value)
				{
					_FlagMenu = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESC_MENU
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DescMenu
		{
			get { return _DescMenu; }
			set {
				if (DescMenu != value)
				{
					_DescMenu = value;
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

		/// <summary>
		/// Corrisponde al campo:PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Padre
		{
			get { return _Padre; }
			set {
				if (Padre != value)
				{
					_Padre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LINK
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Link
		{
			get { return _Link; }
			set {
				if (Link != value)
				{
					_Link = value;
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
			set {
				if (Ordine != value)
				{
					_Ordine = value;
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
	/// Summary description for FunzionalitaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FunzionalitaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FunzionalitaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Funzionalita) info.GetValue(i.ToString(),typeof(Funzionalita)));
			}
		}

		//Costruttore
		public FunzionalitaCollection()
		{
			this.ItemType = typeof(Funzionalita);
		}

		//Costruttore con provider
		public FunzionalitaCollection(IFunzionalitaProvider providerObj)
		{
			this.ItemType = typeof(Funzionalita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Funzionalita this[int index]
		{
			get { return (Funzionalita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FunzionalitaCollection GetChanges()
		{
			return (FunzionalitaCollection) base.GetChanges();
		}

		[NonSerialized] private IFunzionalitaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFunzionalitaProvider Provider
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
		public int Add(Funzionalita FunzionalitaObj)
		{
			if (FunzionalitaObj.Provider == null) FunzionalitaObj.Provider = this.Provider;
			return base.Add(FunzionalitaObj);
		}

		//AddCollection
		public void AddCollection(FunzionalitaCollection FunzionalitaCollectionObj)
		{
			foreach (Funzionalita FunzionalitaObj in FunzionalitaCollectionObj)
				this.Add(FunzionalitaObj);
		}

		//Insert
		public void Insert(int index, Funzionalita FunzionalitaObj)
		{
			if (FunzionalitaObj.Provider == null) FunzionalitaObj.Provider = this.Provider;
			base.Insert(index, FunzionalitaObj);
		}

		//CollectionGetById
		public Funzionalita CollectionGetById(NullTypes.IntNT CodFunzioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodFunzione == CodFunzioneValue))
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
		public FunzionalitaCollection SubSelect(NullTypes.IntNT CodFunzioneEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagMenuEqualThis, 
NullTypes.StringNT DescMenuEqualThis, NullTypes.IntNT LivelloEqualThis, NullTypes.IntNT PadreEqualThis, 
NullTypes.StringNT LinkEqualThis, NullTypes.IntNT OrdineEqualThis)
		{
			FunzionalitaCollection FunzionalitaCollectionTemp = new FunzionalitaCollection();
			foreach (Funzionalita FunzionalitaItem in this)
			{
				if (((CodFunzioneEqualThis == null) || ((FunzionalitaItem.CodFunzione != null) && (FunzionalitaItem.CodFunzione.Value == CodFunzioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((FunzionalitaItem.Descrizione != null) && (FunzionalitaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagMenuEqualThis == null) || ((FunzionalitaItem.FlagMenu != null) && (FunzionalitaItem.FlagMenu.Value == FlagMenuEqualThis.Value))) && 
((DescMenuEqualThis == null) || ((FunzionalitaItem.DescMenu != null) && (FunzionalitaItem.DescMenu.Value == DescMenuEqualThis.Value))) && ((LivelloEqualThis == null) || ((FunzionalitaItem.Livello != null) && (FunzionalitaItem.Livello.Value == LivelloEqualThis.Value))) && ((PadreEqualThis == null) || ((FunzionalitaItem.Padre != null) && (FunzionalitaItem.Padre.Value == PadreEqualThis.Value))) && 
((LinkEqualThis == null) || ((FunzionalitaItem.Link != null) && (FunzionalitaItem.Link.Value == LinkEqualThis.Value))) && ((OrdineEqualThis == null) || ((FunzionalitaItem.Ordine != null) && (FunzionalitaItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					FunzionalitaCollectionTemp.Add(FunzionalitaItem);
				}
			}
			return FunzionalitaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for FunzionalitaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class FunzionalitaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Funzionalita FunzionalitaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "CodFunzione", FunzionalitaObj.CodFunzione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", FunzionalitaObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagMenu", FunzionalitaObj.FlagMenu);
			DbProvider.SetCmdParam(cmd,firstChar + "DescMenu", FunzionalitaObj.DescMenu);
			DbProvider.SetCmdParam(cmd,firstChar + "Livello", FunzionalitaObj.Livello);
			DbProvider.SetCmdParam(cmd,firstChar + "Padre", FunzionalitaObj.Padre);
			DbProvider.SetCmdParam(cmd,firstChar + "Link", FunzionalitaObj.Link);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", FunzionalitaObj.Ordine);
		}
		//Insert
		private static int Insert(DbProvider db, Funzionalita FunzionalitaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZFunzionalitaInsert", new string[] {"Descrizione", "FlagMenu", 
"DescMenu", "Livello", "Padre", 
"Link", "Ordine"}, new string[] {"string", "bool", 
"string", "int", "int", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,FunzionalitaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				FunzionalitaObj.CodFunzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_FUNZIONE"]);
				}
				FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FunzionalitaObj.IsDirty = false;
				FunzionalitaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Funzionalita FunzionalitaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFunzionalitaUpdate", new string[] {"CodFunzione", "Descrizione", "FlagMenu", 
"DescMenu", "Livello", "Padre", 
"Link", "Ordine"}, new string[] {"int", "string", "bool", 
"string", "int", "int", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,FunzionalitaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FunzionalitaObj.IsDirty = false;
				FunzionalitaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Funzionalita FunzionalitaObj)
		{
			switch (FunzionalitaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, FunzionalitaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, FunzionalitaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,FunzionalitaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, FunzionalitaCollection FunzionalitaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZFunzionalitaUpdate", new string[] {"CodFunzione", "Descrizione", "FlagMenu", 
"DescMenu", "Livello", "Padre", 
"Link", "Ordine"}, new string[] {"int", "string", "bool", 
"string", "int", "int", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZFunzionalitaInsert", new string[] {"Descrizione", "FlagMenu", 
"DescMenu", "Livello", "Padre", 
"Link", "Ordine"}, new string[] {"string", "bool", 
"string", "int", "int", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZFunzionalitaDelete", new string[] {"CodFunzione"}, new string[] {"int"},"");
				for (int i = 0; i < FunzionalitaCollectionObj.Count; i++)
				{
					switch (FunzionalitaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,FunzionalitaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									FunzionalitaCollectionObj[i].CodFunzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_FUNZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,FunzionalitaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (FunzionalitaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)FunzionalitaCollectionObj[i].CodFunzione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < FunzionalitaCollectionObj.Count; i++)
				{
					if ((FunzionalitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FunzionalitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FunzionalitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						FunzionalitaCollectionObj[i].IsDirty = false;
						FunzionalitaCollectionObj[i].IsPersistent = true;
					}
					if ((FunzionalitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						FunzionalitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FunzionalitaCollectionObj[i].IsDirty = false;
						FunzionalitaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Funzionalita FunzionalitaObj)
		{
			int returnValue = 0;
			if (FunzionalitaObj.IsPersistent) 
			{
				returnValue = Delete(db, FunzionalitaObj.CodFunzione);
			}
			FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			FunzionalitaObj.IsDirty = false;
			FunzionalitaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int CodFunzioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFunzionalitaDelete", new string[] {"CodFunzione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)CodFunzioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, FunzionalitaCollection FunzionalitaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZFunzionalitaDelete", new string[] {"CodFunzione"}, new string[] {"int"},"");
				for (int i = 0; i < FunzionalitaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "CodFunzione", FunzionalitaCollectionObj[i].CodFunzione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < FunzionalitaCollectionObj.Count; i++)
				{
					if ((FunzionalitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FunzionalitaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						FunzionalitaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						FunzionalitaCollectionObj[i].IsDirty = false;
						FunzionalitaCollectionObj[i].IsPersistent = false;
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
		public static Funzionalita GetById(DbProvider db, int CodFunzioneValue)
		{
			Funzionalita FunzionalitaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZFunzionalitaGetById", new string[] {"CodFunzione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "CodFunzione", (SiarLibrary.NullTypes.IntNT)CodFunzioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				FunzionalitaObj = GetFromDatareader(db);
				FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FunzionalitaObj.IsDirty = false;
				FunzionalitaObj.IsPersistent = true;
			}
			db.Close();
			return FunzionalitaObj;
		}

		//getFromDatareader
		public static Funzionalita GetFromDatareader(DbProvider db)
		{
			Funzionalita FunzionalitaObj = new Funzionalita();
			FunzionalitaObj.CodFunzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_FUNZIONE"]);
			FunzionalitaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			FunzionalitaObj.FlagMenu = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_MENU"]);
			FunzionalitaObj.DescMenu = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESC_MENU"]);
			FunzionalitaObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			FunzionalitaObj.Padre = new SiarLibrary.NullTypes.IntNT(db.DataReader["PADRE"]);
			FunzionalitaObj.Link = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK"]);
			FunzionalitaObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			FunzionalitaObj.IsDirty = false;
			FunzionalitaObj.IsPersistent = true;
			return FunzionalitaObj;
		}

		//Find Select

		public static FunzionalitaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT CodFunzioneEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagMenuEqualThis, 
SiarLibrary.NullTypes.StringNT DescMenuEqualThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.IntNT PadreEqualThis, 
SiarLibrary.NullTypes.StringNT LinkEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis)

		{

			FunzionalitaCollection FunzionalitaCollectionObj = new FunzionalitaCollection();

			IDbCommand findCmd = db.InitCmd("Zfunzionalitafindselect", new string[] {"CodFunzioneequalthis", "Descrizioneequalthis", "FlagMenuequalthis", 
"DescMenuequalthis", "Livelloequalthis", "Padreequalthis", 
"Linkequalthis", "Ordineequalthis"}, new string[] {"int", "string", "bool", 
"string", "int", "int", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFunzioneequalthis", CodFunzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagMenuequalthis", FlagMenuEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescMenuequalthis", DescMenuEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Padreequalthis", PadreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Linkequalthis", LinkEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			Funzionalita FunzionalitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FunzionalitaObj = GetFromDatareader(db);
				FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FunzionalitaObj.IsDirty = false;
				FunzionalitaObj.IsPersistent = true;
				FunzionalitaCollectionObj.Add(FunzionalitaObj);
			}
			db.Close();
			return FunzionalitaCollectionObj;
		}

		//Find Find

		public static FunzionalitaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT CodFunzioneEqualThis, SiarLibrary.NullTypes.StringNT DescMenuEqualThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, 
SiarLibrary.NullTypes.IntNT PadreEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT FlagMenuEqualThis)

		{

			FunzionalitaCollection FunzionalitaCollectionObj = new FunzionalitaCollection();

			IDbCommand findCmd = db.InitCmd("Zfunzionalitafindfind", new string[] {"CodFunzioneequalthis", "DescMenuequalthis", "Livelloequalthis", 
"Padreequalthis", "Ordineequalthis", "FlagMenuequalthis"}, new string[] {"int", "string", "int", 
"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFunzioneequalthis", CodFunzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescMenuequalthis", DescMenuEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Padreequalthis", PadreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagMenuequalthis", FlagMenuEqualThis);
			Funzionalita FunzionalitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				FunzionalitaObj = GetFromDatareader(db);
				FunzionalitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				FunzionalitaObj.IsDirty = false;
				FunzionalitaObj.IsPersistent = true;
				FunzionalitaCollectionObj.Add(FunzionalitaObj);
			}
			db.Close();
			return FunzionalitaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for FunzionalitaCollectionProvider:IFunzionalitaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class FunzionalitaCollectionProvider : IFunzionalitaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Funzionalita
		protected FunzionalitaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FunzionalitaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FunzionalitaCollection(this);
		}

		//Costruttore 2: popola la collection
		public FunzionalitaCollectionProvider(IntNT CodfunzioneEqualThis, StringNT DescmenuEqualThis, IntNT LivelloEqualThis, 
IntNT PadreEqualThis, IntNT OrdineEqualThis, BoolNT FlagmenuEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodfunzioneEqualThis, DescmenuEqualThis, LivelloEqualThis, 
PadreEqualThis, OrdineEqualThis, FlagmenuEqualThis);
		}

		//Costruttore3: ha in input funzionalitaCollectionObj - non popola la collection
		public FunzionalitaCollectionProvider(FunzionalitaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FunzionalitaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FunzionalitaCollection(this);
		}

		//Get e Set
		public FunzionalitaCollection CollectionObj
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
		public int SaveCollection(FunzionalitaCollection collectionObj)
		{
			return FunzionalitaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Funzionalita funzionalitaObj)
		{
			return FunzionalitaDAL.Save(_dbProviderObj, funzionalitaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FunzionalitaCollection collectionObj)
		{
			return FunzionalitaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Funzionalita funzionalitaObj)
		{
			return FunzionalitaDAL.Delete(_dbProviderObj, funzionalitaObj);
		}

		//getById
		public Funzionalita GetById(IntNT CodFunzioneValue)
		{
			Funzionalita FunzionalitaTemp = FunzionalitaDAL.GetById(_dbProviderObj, CodFunzioneValue);
			if (FunzionalitaTemp!=null) FunzionalitaTemp.Provider = this;
			return FunzionalitaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FunzionalitaCollection Select(IntNT CodfunzioneEqualThis, StringNT DescrizioneEqualThis, BoolNT FlagmenuEqualThis, 
StringNT DescmenuEqualThis, IntNT LivelloEqualThis, IntNT PadreEqualThis, 
StringNT LinkEqualThis, IntNT OrdineEqualThis)
		{
			FunzionalitaCollection FunzionalitaCollectionTemp = FunzionalitaDAL.Select(_dbProviderObj, CodfunzioneEqualThis, DescrizioneEqualThis, FlagmenuEqualThis, 
DescmenuEqualThis, LivelloEqualThis, PadreEqualThis, 
LinkEqualThis, OrdineEqualThis);
			FunzionalitaCollectionTemp.Provider = this;
			return FunzionalitaCollectionTemp;
		}

		//Find: popola la collection
		public FunzionalitaCollection Find(IntNT CodfunzioneEqualThis, StringNT DescmenuEqualThis, IntNT LivelloEqualThis, 
IntNT PadreEqualThis, IntNT OrdineEqualThis, BoolNT FlagmenuEqualThis)
		{
			FunzionalitaCollection FunzionalitaCollectionTemp = FunzionalitaDAL.Find(_dbProviderObj, CodfunzioneEqualThis, DescmenuEqualThis, LivelloEqualThis, 
PadreEqualThis, OrdineEqualThis, FlagmenuEqualThis);
			FunzionalitaCollectionTemp.Provider = this;
			return FunzionalitaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FUNZIONALITA>
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
      <COD_FUNZIONE>Equal</COD_FUNZIONE>
      <DESC_MENU>Equal</DESC_MENU>
      <LIVELLO>Equal</LIVELLO>
      <PADRE>Equal</PADRE>
      <ORDINE>Equal</ORDINE>
      <FLAG_MENU>Equal</FLAG_MENU>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FUNZIONALITA>
*/
