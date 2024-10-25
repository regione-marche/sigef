using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BancheFiliali
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBancheFilialiProvider
	{
		int Save(BancheFiliali BancheFilialiObj);
		int SaveCollection(BancheFilialiCollection collectionObj);
		int Delete(BancheFiliali BancheFilialiObj);
		int DeleteCollection(BancheFilialiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BancheFiliali
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BancheFiliali: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Abi;
		private NullTypes.StringNT _Cab;
		private NullTypes.StringNT _Note;
		private NullTypes.StringNT _Indirizzo;
		private NullTypes.IntNT _IdComune;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Cap;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IBancheFilialiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBancheFilialiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BancheFiliali()
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
		/// Corrisponde al campo:ABI
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT Abi
		{
			get { return _Abi; }
			set {
				if (Abi != value)
				{
					_Abi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAB
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT Cab
		{
			get { return _Cab; }
			set {
				if (Cab != value)
				{
					_Cab = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:INDIRIZZO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Indirizzo
		{
			get { return _Indirizzo; }
			set {
				if (Indirizzo != value)
				{
					_Indirizzo = value;
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
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Comune
		{
			get { return _Comune; }
			set {
				if (Comune != value)
				{
					_Comune = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:CHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set {
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
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
	/// Summary description for BancheFilialiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BancheFilialiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BancheFilialiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BancheFiliali) info.GetValue(i.ToString(),typeof(BancheFiliali)));
			}
		}

		//Costruttore
		public BancheFilialiCollection()
		{
			this.ItemType = typeof(BancheFiliali);
		}

		//Costruttore con provider
		public BancheFilialiCollection(IBancheFilialiProvider providerObj)
		{
			this.ItemType = typeof(BancheFiliali);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BancheFiliali this[int index]
		{
			get { return (BancheFiliali)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BancheFilialiCollection GetChanges()
		{
			return (BancheFilialiCollection) base.GetChanges();
		}

		[NonSerialized] private IBancheFilialiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBancheFilialiProvider Provider
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
		public int Add(BancheFiliali BancheFilialiObj)
		{
			if (BancheFilialiObj.Provider == null) BancheFilialiObj.Provider = this.Provider;
			return base.Add(BancheFilialiObj);
		}

		//AddCollection
		public void AddCollection(BancheFilialiCollection BancheFilialiCollectionObj)
		{
			foreach (BancheFiliali BancheFilialiObj in BancheFilialiCollectionObj)
				this.Add(BancheFilialiObj);
		}

		//Insert
		public void Insert(int index, BancheFiliali BancheFilialiObj)
		{
			if (BancheFilialiObj.Provider == null) BancheFilialiObj.Provider = this.Provider;
			base.Insert(index, BancheFilialiObj);
		}

		//CollectionGetById
		public BancheFiliali CollectionGetById(NullTypes.IntNT IdValue)
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
		public BancheFilialiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT AbiEqualThis, NullTypes.StringNT CabEqualThis, 
NullTypes.StringNT NoteEqualThis, NullTypes.StringNT IndirizzoEqualThis, NullTypes.IntNT IdComuneEqualThis, 
NullTypes.StringNT ComuneEqualThis, NullTypes.StringNT ProvinciaEqualThis, NullTypes.StringNT CapEqualThis, 
NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			BancheFilialiCollection BancheFilialiCollectionTemp = new BancheFilialiCollection();
			foreach (BancheFiliali BancheFilialiItem in this)
			{
				if (((IdEqualThis == null) || ((BancheFilialiItem.Id != null) && (BancheFilialiItem.Id.Value == IdEqualThis.Value))) && ((AbiEqualThis == null) || ((BancheFilialiItem.Abi != null) && (BancheFilialiItem.Abi.Value == AbiEqualThis.Value))) && ((CabEqualThis == null) || ((BancheFilialiItem.Cab != null) && (BancheFilialiItem.Cab.Value == CabEqualThis.Value))) && 
((NoteEqualThis == null) || ((BancheFilialiItem.Note != null) && (BancheFilialiItem.Note.Value == NoteEqualThis.Value))) && ((IndirizzoEqualThis == null) || ((BancheFilialiItem.Indirizzo != null) && (BancheFilialiItem.Indirizzo.Value == IndirizzoEqualThis.Value))) && ((IdComuneEqualThis == null) || ((BancheFilialiItem.IdComune != null) && (BancheFilialiItem.IdComune.Value == IdComuneEqualThis.Value))) && 
((ComuneEqualThis == null) || ((BancheFilialiItem.Comune != null) && (BancheFilialiItem.Comune.Value == ComuneEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((BancheFilialiItem.Provincia != null) && (BancheFilialiItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((CapEqualThis == null) || ((BancheFilialiItem.Cap != null) && (BancheFilialiItem.Cap.Value == CapEqualThis.Value))) && 
((DataInizioValiditaEqualThis == null) || ((BancheFilialiItem.DataInizioValidita != null) && (BancheFilialiItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((BancheFilialiItem.DataFineValidita != null) && (BancheFilialiItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && ((AttivoEqualThis == null) || ((BancheFilialiItem.Attivo != null) && (BancheFilialiItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					BancheFilialiCollectionTemp.Add(BancheFilialiItem);
				}
			}
			return BancheFilialiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BancheFilialiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BancheFilialiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BancheFiliali BancheFilialiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", BancheFilialiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Abi", BancheFilialiObj.Abi);
			DbProvider.SetCmdParam(cmd,firstChar + "Cab", BancheFilialiObj.Cab);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", BancheFilialiObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Indirizzo", BancheFilialiObj.Indirizzo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComune", BancheFilialiObj.IdComune);
			DbProvider.SetCmdParam(cmd,firstChar + "Comune", BancheFilialiObj.Comune);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", BancheFilialiObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "Cap", BancheFilialiObj.Cap);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", BancheFilialiObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", BancheFilialiObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", BancheFilialiObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, BancheFiliali BancheFilialiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBancheFilialiInsert", new string[] {"Abi", "Cab", 
"Note", "Indirizzo", "IdComune", 
"Comune", "Provincia", "Cap", 
"DataInizioValidita", "DataFineValidita", "Attivo"}, new string[] {"string", "string", 
"string", "string", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "bool"},"");
				CompileIUCmd(false, insertCmd,BancheFilialiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BancheFilialiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				BancheFilialiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheFilialiObj.IsDirty = false;
				BancheFilialiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BancheFiliali BancheFilialiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBancheFilialiUpdate", new string[] {"Id", "Abi", "Cab", 
"Note", "Indirizzo", "IdComune", 
"Comune", "Provincia", "Cap", 
"DataInizioValidita", "DataFineValidita", "Attivo"}, new string[] {"int", "string", "string", 
"string", "string", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "bool"},"");
				CompileIUCmd(true, updateCmd,BancheFilialiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheFilialiObj.IsDirty = false;
				BancheFilialiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BancheFiliali BancheFilialiObj)
		{
			switch (BancheFilialiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BancheFilialiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BancheFilialiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BancheFilialiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BancheFilialiCollection BancheFilialiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBancheFilialiUpdate", new string[] {"Id", "Abi", "Cab", 
"Note", "Indirizzo", "IdComune", 
"Comune", "Provincia", "Cap", 
"DataInizioValidita", "DataFineValidita", "Attivo"}, new string[] {"int", "string", "string", 
"string", "string", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZBancheFilialiInsert", new string[] {"Abi", "Cab", 
"Note", "Indirizzo", "IdComune", 
"Comune", "Provincia", "Cap", 
"DataInizioValidita", "DataFineValidita", "Attivo"}, new string[] {"string", "string", 
"string", "string", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZBancheFilialiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BancheFilialiCollectionObj.Count; i++)
				{
					switch (BancheFilialiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BancheFilialiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BancheFilialiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									BancheFilialiCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BancheFilialiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BancheFilialiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)BancheFilialiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BancheFilialiCollectionObj.Count; i++)
				{
					if ((BancheFilialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BancheFilialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BancheFilialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BancheFilialiCollectionObj[i].IsDirty = false;
						BancheFilialiCollectionObj[i].IsPersistent = true;
					}
					if ((BancheFilialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BancheFilialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BancheFilialiCollectionObj[i].IsDirty = false;
						BancheFilialiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BancheFiliali BancheFilialiObj)
		{
			int returnValue = 0;
			if (BancheFilialiObj.IsPersistent) 
			{
				returnValue = Delete(db, BancheFilialiObj.Id);
			}
			BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BancheFilialiObj.IsDirty = false;
			BancheFilialiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBancheFilialiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BancheFilialiCollection BancheFilialiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBancheFilialiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < BancheFilialiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", BancheFilialiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BancheFilialiCollectionObj.Count; i++)
				{
					if ((BancheFilialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BancheFilialiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BancheFilialiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BancheFilialiCollectionObj[i].IsDirty = false;
						BancheFilialiCollectionObj[i].IsPersistent = false;
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
		public static BancheFiliali GetById(DbProvider db, int IdValue)
		{
			BancheFiliali BancheFilialiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBancheFilialiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BancheFilialiObj = GetFromDatareader(db);
				BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheFilialiObj.IsDirty = false;
				BancheFilialiObj.IsPersistent = true;
			}
			db.Close();
			return BancheFilialiObj;
		}

		//getFromDatareader
		public static BancheFiliali GetFromDatareader(DbProvider db)
		{
			BancheFiliali BancheFilialiObj = new BancheFiliali();
			BancheFilialiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			BancheFilialiObj.Abi = new SiarLibrary.NullTypes.StringNT(db.DataReader["ABI"]);
			BancheFilialiObj.Cab = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAB"]);
			BancheFilialiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			BancheFilialiObj.Indirizzo = new SiarLibrary.NullTypes.StringNT(db.DataReader["INDIRIZZO"]);
			BancheFilialiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
			BancheFilialiObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			BancheFilialiObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			BancheFilialiObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			BancheFilialiObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			BancheFilialiObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			BancheFilialiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BancheFilialiObj.IsDirty = false;
			BancheFilialiObj.IsPersistent = true;
			return BancheFilialiObj;
		}

		//Find Select

		public static BancheFilialiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT AbiEqualThis, SiarLibrary.NullTypes.StringNT CabEqualThis, 
SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.StringNT IndirizzoEqualThis, SiarLibrary.NullTypes.IntNT IdComuneEqualThis, 
SiarLibrary.NullTypes.StringNT ComuneEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			BancheFilialiCollection BancheFilialiCollectionObj = new BancheFilialiCollection();

			IDbCommand findCmd = db.InitCmd("Zbanchefilialifindselect", new string[] {"Idequalthis", "Abiequalthis", "Cabequalthis", 
"Noteequalthis", "Indirizzoequalthis", "IdComuneequalthis", 
"Comuneequalthis", "Provinciaequalthis", "Capequalthis", 
"DataInizioValiditaequalthis", "DataFineValiditaequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abiequalthis", AbiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cabequalthis", CabEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Indirizzoequalthis", IndirizzoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Comuneequalthis", ComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			BancheFiliali BancheFilialiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BancheFilialiObj = GetFromDatareader(db);
				BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheFilialiObj.IsDirty = false;
				BancheFilialiObj.IsPersistent = true;
				BancheFilialiCollectionObj.Add(BancheFilialiObj);
			}
			db.Close();
			return BancheFilialiCollectionObj;
		}

		//Find Find

		public static BancheFilialiCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT AbiEqualThis, SiarLibrary.NullTypes.StringNT CabLikeThis, SiarLibrary.NullTypes.StringNT NoteLikeThis, 
SiarLibrary.NullTypes.StringNT ProvinciaEqualThis)

		{

			BancheFilialiCollection BancheFilialiCollectionObj = new BancheFilialiCollection();

			IDbCommand findCmd = db.InitCmd("Zbanchefilialifindfind", new string[] {"Abiequalthis", "Cablikethis", "Notelikethis", 
"Provinciaequalthis"}, new string[] {"string", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abiequalthis", AbiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cablikethis", CabLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Notelikethis", NoteLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			BancheFiliali BancheFilialiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BancheFilialiObj = GetFromDatareader(db);
				BancheFilialiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BancheFilialiObj.IsDirty = false;
				BancheFilialiObj.IsPersistent = true;
				BancheFilialiCollectionObj.Add(BancheFilialiObj);
			}
			db.Close();
			return BancheFilialiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BancheFilialiCollectionProvider:IBancheFilialiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BancheFilialiCollectionProvider : IBancheFilialiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BancheFiliali
		protected BancheFilialiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BancheFilialiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BancheFilialiCollection(this);
		}

		//Costruttore 2: popola la collection
		public BancheFilialiCollectionProvider(StringNT AbiEqualThis, StringNT CabLikeThis, StringNT NoteLikeThis, 
StringNT ProvinciaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(AbiEqualThis, CabLikeThis, NoteLikeThis, 
ProvinciaEqualThis);
		}

		//Costruttore3: ha in input banchefilialiCollectionObj - non popola la collection
		public BancheFilialiCollectionProvider(BancheFilialiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BancheFilialiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BancheFilialiCollection(this);
		}

		//Get e Set
		public BancheFilialiCollection CollectionObj
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
		public int SaveCollection(BancheFilialiCollection collectionObj)
		{
			return BancheFilialiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BancheFiliali banchefilialiObj)
		{
			return BancheFilialiDAL.Save(_dbProviderObj, banchefilialiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BancheFilialiCollection collectionObj)
		{
			return BancheFilialiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BancheFiliali banchefilialiObj)
		{
			return BancheFilialiDAL.Delete(_dbProviderObj, banchefilialiObj);
		}

		//getById
		public BancheFiliali GetById(IntNT IdValue)
		{
			BancheFiliali BancheFilialiTemp = BancheFilialiDAL.GetById(_dbProviderObj, IdValue);
			if (BancheFilialiTemp!=null) BancheFilialiTemp.Provider = this;
			return BancheFilialiTemp;
		}

		//Select: popola la collection
		public BancheFilialiCollection Select(IntNT IdEqualThis, StringNT AbiEqualThis, StringNT CabEqualThis, 
StringNT NoteEqualThis, StringNT IndirizzoEqualThis, IntNT IdcomuneEqualThis, 
StringNT ComuneEqualThis, StringNT ProvinciaEqualThis, StringNT CapEqualThis, 
DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, BoolNT AttivoEqualThis)
		{
			BancheFilialiCollection BancheFilialiCollectionTemp = BancheFilialiDAL.Select(_dbProviderObj, IdEqualThis, AbiEqualThis, CabEqualThis, 
NoteEqualThis, IndirizzoEqualThis, IdcomuneEqualThis, 
ComuneEqualThis, ProvinciaEqualThis, CapEqualThis, 
DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, AttivoEqualThis);
			BancheFilialiCollectionTemp.Provider = this;
			return BancheFilialiCollectionTemp;
		}

		//Find: popola la collection
		public BancheFilialiCollection Find(StringNT AbiEqualThis, StringNT CabLikeThis, StringNT NoteLikeThis, 
StringNT ProvinciaEqualThis)
		{
			BancheFilialiCollection BancheFilialiCollectionTemp = BancheFilialiDAL.Find(_dbProviderObj, AbiEqualThis, CabLikeThis, NoteLikeThis, 
ProvinciaEqualThis);
			BancheFilialiCollectionTemp.Provider = this;
			return BancheFilialiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANCHE_FILIALI>
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
    <Find OrderBy="ORDER BY ID">
      <ABI>Equal</ABI>
      <CAB>Like</CAB>
      <NOTE>Like</NOTE>
      <PROVINCIA>Equal</PROVINCIA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANCHE_FILIALI>
*/
