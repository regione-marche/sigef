using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per UlaDipendenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IUlaDipendentiProvider
	{
		int Save(UlaDipendenti UlaDipendentiObj);
		int SaveCollection(UlaDipendentiCollection collectionObj);
		int Delete(UlaDipendenti UlaDipendentiObj);
		int DeleteCollection(UlaDipendentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for UlaDipendenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class UlaDipendenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _Anno;
		private NullTypes.IntNT _IdTipoContratto;
		private NullTypes.IntNT _Ore;
		private NullTypes.IntNT _OreCcnl;
		private NullTypes.IntNT _NumeroDipendenti;
		private NullTypes.DecimalNT _Ula;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _DataInserimento;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IUlaDipendentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaDipendentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public UlaDipendenti()
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
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_CONTRATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoContratto
		{
			get { return _IdTipoContratto; }
			set {
				if (IdTipoContratto != value)
				{
					_IdTipoContratto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ore
		{
			get { return _Ore; }
			set {
				if (Ore != value)
				{
					_Ore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORE_CCNL
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OreCcnl
		{
			get { return _OreCcnl; }
			set {
				if (OreCcnl != value)
				{
					_OreCcnl = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_DIPENDENTI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroDipendenti
		{
			get { return _NumeroDipendenti; }
			set {
				if (NumeroDipendenti != value)
				{
					_NumeroDipendenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ULA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Ula
		{
			get { return _Ula; }
			set {
				if (Ula != value)
				{
					_Ula = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:NCHAR(10)
		/// </summary>
		public NullTypes.StringNT Operatore
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:NCHAR(10)
		/// </summary>
		public NullTypes.StringNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
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
	/// Summary description for UlaDipendentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaDipendentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private UlaDipendentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((UlaDipendenti) info.GetValue(i.ToString(),typeof(UlaDipendenti)));
			}
		}

		//Costruttore
		public UlaDipendentiCollection()
		{
			this.ItemType = typeof(UlaDipendenti);
		}

		//Costruttore con provider
		public UlaDipendentiCollection(IUlaDipendentiProvider providerObj)
		{
			this.ItemType = typeof(UlaDipendenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new UlaDipendenti this[int index]
		{
			get { return (UlaDipendenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new UlaDipendentiCollection GetChanges()
		{
			return (UlaDipendentiCollection) base.GetChanges();
		}

		[NonSerialized] private IUlaDipendentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUlaDipendentiProvider Provider
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
		public int Add(UlaDipendenti UlaDipendentiObj)
		{
			if (UlaDipendentiObj.Provider == null) UlaDipendentiObj.Provider = this.Provider;
			return base.Add(UlaDipendentiObj);
		}

		//AddCollection
		public void AddCollection(UlaDipendentiCollection UlaDipendentiCollectionObj)
		{
			foreach (UlaDipendenti UlaDipendentiObj in UlaDipendentiCollectionObj)
				this.Add(UlaDipendentiObj);
		}

		//Insert
		public void Insert(int index, UlaDipendenti UlaDipendentiObj)
		{
			if (UlaDipendentiObj.Provider == null) UlaDipendentiObj.Provider = this.Provider;
			base.Insert(index, UlaDipendentiObj);
		}

		//CollectionGetById
		public UlaDipendenti CollectionGetById(NullTypes.IntNT IdValue)
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
		public UlaDipendentiCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT AnnoEqualThis, NullTypes.IntNT IdTipoContrattoEqualThis, 
NullTypes.IntNT OreEqualThis, NullTypes.IntNT OreCcnlEqualThis, NullTypes.IntNT NumeroDipendentiEqualThis, 
NullTypes.DecimalNT UlaEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.StringNT DataInserimentoEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			UlaDipendentiCollection UlaDipendentiCollectionTemp = new UlaDipendentiCollection();
			foreach (UlaDipendenti UlaDipendentiItem in this)
			{
				if (((IdEqualThis == null) || ((UlaDipendentiItem.Id != null) && (UlaDipendentiItem.Id.Value == IdEqualThis.Value))) && ((AnnoEqualThis == null) || ((UlaDipendentiItem.Anno != null) && (UlaDipendentiItem.Anno.Value == AnnoEqualThis.Value))) && ((IdTipoContrattoEqualThis == null) || ((UlaDipendentiItem.IdTipoContratto != null) && (UlaDipendentiItem.IdTipoContratto.Value == IdTipoContrattoEqualThis.Value))) && 
((OreEqualThis == null) || ((UlaDipendentiItem.Ore != null) && (UlaDipendentiItem.Ore.Value == OreEqualThis.Value))) && ((OreCcnlEqualThis == null) || ((UlaDipendentiItem.OreCcnl != null) && (UlaDipendentiItem.OreCcnl.Value == OreCcnlEqualThis.Value))) && ((NumeroDipendentiEqualThis == null) || ((UlaDipendentiItem.NumeroDipendenti != null) && (UlaDipendentiItem.NumeroDipendenti.Value == NumeroDipendentiEqualThis.Value))) && 
((UlaEqualThis == null) || ((UlaDipendentiItem.Ula != null) && (UlaDipendentiItem.Ula.Value == UlaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((UlaDipendentiItem.Operatore != null) && (UlaDipendentiItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((UlaDipendentiItem.DataInserimento != null) && (UlaDipendentiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((AttivoEqualThis == null) || ((UlaDipendentiItem.Attivo != null) && (UlaDipendentiItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					UlaDipendentiCollectionTemp.Add(UlaDipendentiItem);
				}
			}
			return UlaDipendentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public UlaDipendentiCollection Filter(NullTypes.IntNT OreEqualThis)
		{
			UlaDipendentiCollection UlaDipendentiCollectionTemp = new UlaDipendentiCollection();
			foreach (UlaDipendenti UlaDipendentiItem in this)
			{
				if (((OreEqualThis == null) || ((UlaDipendentiItem.Ore != null) && (UlaDipendentiItem.Ore.Value == OreEqualThis.Value))))
				{
					UlaDipendentiCollectionTemp.Add(UlaDipendentiItem);
				}
			}
			return UlaDipendentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for UlaDipendentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class UlaDipendentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, UlaDipendenti UlaDipendentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", UlaDipendentiObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", UlaDipendentiObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoContratto", UlaDipendentiObj.IdTipoContratto);
			DbProvider.SetCmdParam(cmd,firstChar + "Ore", UlaDipendentiObj.Ore);
			DbProvider.SetCmdParam(cmd,firstChar + "OreCcnl", UlaDipendentiObj.OreCcnl);
			DbProvider.SetCmdParam(cmd,firstChar + "NumeroDipendenti", UlaDipendentiObj.NumeroDipendenti);
			DbProvider.SetCmdParam(cmd,firstChar + "Ula", UlaDipendentiObj.Ula);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", UlaDipendentiObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", UlaDipendentiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", UlaDipendentiObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, UlaDipendenti UlaDipendentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZUlaDipendentiInsert", new string[] {"Anno", "IdTipoContratto", 
"Ore", "OreCcnl", "NumeroDipendenti", 
"Ula", "Operatore", "DataInserimento", 
"Attivo"}, new string[] {"int", "int", 
"int", "int", "int", 
"decimal", "string", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,UlaDipendentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				UlaDipendentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaDipendentiObj.IsDirty = false;
				UlaDipendentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, UlaDipendenti UlaDipendentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaDipendentiUpdate", new string[] {"Id", "Anno", "IdTipoContratto", 
"Ore", "OreCcnl", "NumeroDipendenti", 
"Ula", "Operatore", "DataInserimento", 
"Attivo"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"decimal", "string", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,UlaDipendentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaDipendentiObj.IsDirty = false;
				UlaDipendentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, UlaDipendenti UlaDipendentiObj)
		{
			switch (UlaDipendentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, UlaDipendentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, UlaDipendentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,UlaDipendentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, UlaDipendentiCollection UlaDipendentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUlaDipendentiUpdate", new string[] {"Id", "Anno", "IdTipoContratto", 
"Ore", "OreCcnl", "NumeroDipendenti", 
"Ula", "Operatore", "DataInserimento", 
"Attivo"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"decimal", "string", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZUlaDipendentiInsert", new string[] {"Anno", "IdTipoContratto", 
"Ore", "OreCcnl", "NumeroDipendenti", 
"Ula", "Operatore", "DataInserimento", 
"Attivo"}, new string[] {"int", "int", 
"int", "int", "int", 
"decimal", "string", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaDipendentiCollectionObj.Count; i++)
				{
					switch (UlaDipendentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,UlaDipendentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									UlaDipendentiCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,UlaDipendentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (UlaDipendentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)UlaDipendentiCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < UlaDipendentiCollectionObj.Count; i++)
				{
					if ((UlaDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						UlaDipendentiCollectionObj[i].IsDirty = false;
						UlaDipendentiCollectionObj[i].IsPersistent = true;
					}
					if ((UlaDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						UlaDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaDipendentiCollectionObj[i].IsDirty = false;
						UlaDipendentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, UlaDipendenti UlaDipendentiObj)
		{
			int returnValue = 0;
			if (UlaDipendentiObj.IsPersistent) 
			{
				returnValue = Delete(db, UlaDipendentiObj.Id);
			}
			UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			UlaDipendentiObj.IsDirty = false;
			UlaDipendentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, UlaDipendentiCollection UlaDipendentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUlaDipendentiDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UlaDipendentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", UlaDipendentiCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < UlaDipendentiCollectionObj.Count; i++)
				{
					if ((UlaDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UlaDipendentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UlaDipendentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UlaDipendentiCollectionObj[i].IsDirty = false;
						UlaDipendentiCollectionObj[i].IsPersistent = false;
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
		public static UlaDipendenti GetById(DbProvider db, int IdValue)
		{
			UlaDipendenti UlaDipendentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZUlaDipendentiGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				UlaDipendentiObj = GetFromDatareader(db);
				UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaDipendentiObj.IsDirty = false;
				UlaDipendentiObj.IsPersistent = true;
			}
			db.Close();
			return UlaDipendentiObj;
		}

		//getFromDatareader
		public static UlaDipendenti GetFromDatareader(DbProvider db)
		{
			UlaDipendenti UlaDipendentiObj = new UlaDipendenti();
			UlaDipendentiObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			UlaDipendentiObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			UlaDipendentiObj.IdTipoContratto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_CONTRATTO"]);
			UlaDipendentiObj.Ore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORE"]);
			UlaDipendentiObj.OreCcnl = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORE_CCNL"]);
			UlaDipendentiObj.NumeroDipendenti = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_DIPENDENTI"]);
			UlaDipendentiObj.Ula = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["ULA"]);
			UlaDipendentiObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
			UlaDipendentiObj.DataInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DATA_INSERIMENTO"]);
			UlaDipendentiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			UlaDipendentiObj.IsDirty = false;
			UlaDipendentiObj.IsPersistent = true;
			return UlaDipendentiObj;
		}

		//Find Select

		public static UlaDipendentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.IntNT IdTipoContrattoEqualThis, 
SiarLibrary.NullTypes.IntNT OreEqualThis, SiarLibrary.NullTypes.IntNT OreCcnlEqualThis, SiarLibrary.NullTypes.IntNT NumeroDipendentiEqualThis, 
SiarLibrary.NullTypes.DecimalNT UlaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			UlaDipendentiCollection UlaDipendentiCollectionObj = new UlaDipendentiCollection();

			IDbCommand findCmd = db.InitCmd("Zuladipendentifindselect", new string[] {"Idequalthis", "Annoequalthis", "IdTipoContrattoequalthis", 
"Oreequalthis", "OreCcnlequalthis", "NumeroDipendentiequalthis", 
"Ulaequalthis", "Operatoreequalthis", "DataInserimentoequalthis", 
"Attivoequalthis"}, new string[] {"int", "int", "int", 
"int", "int", "int", 
"decimal", "string", "string", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoContrattoequalthis", IdTipoContrattoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Oreequalthis", OreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OreCcnlequalthis", OreCcnlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroDipendentiequalthis", NumeroDipendentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ulaequalthis", UlaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			UlaDipendenti UlaDipendentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaDipendentiObj = GetFromDatareader(db);
				UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaDipendentiObj.IsDirty = false;
				UlaDipendentiObj.IsPersistent = true;
				UlaDipendentiCollectionObj.Add(UlaDipendentiObj);
			}
			db.Close();
			return UlaDipendentiCollectionObj;
		}

		//Find Find

		public static UlaDipendentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			UlaDipendentiCollection UlaDipendentiCollectionObj = new UlaDipendentiCollection();

			IDbCommand findCmd = db.InitCmd("Zuladipendentifindfind", new string[] {"Annoequalthis", "Attivoequalthis"}, new string[] {"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			UlaDipendenti UlaDipendentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UlaDipendentiObj = GetFromDatareader(db);
				UlaDipendentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UlaDipendentiObj.IsDirty = false;
				UlaDipendentiObj.IsPersistent = true;
				UlaDipendentiCollectionObj.Add(UlaDipendentiObj);
			}
			db.Close();
			return UlaDipendentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for UlaDipendentiCollectionProvider:IUlaDipendentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UlaDipendentiCollectionProvider : IUlaDipendentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di UlaDipendenti
		protected UlaDipendentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public UlaDipendentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new UlaDipendentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public UlaDipendentiCollectionProvider(IntNT AnnoEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(AnnoEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input uladipendentiCollectionObj - non popola la collection
		public UlaDipendentiCollectionProvider(UlaDipendentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public UlaDipendentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new UlaDipendentiCollection(this);
		}

		//Get e Set
		public UlaDipendentiCollection CollectionObj
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
		public int SaveCollection(UlaDipendentiCollection collectionObj)
		{
			return UlaDipendentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(UlaDipendenti uladipendentiObj)
		{
			return UlaDipendentiDAL.Save(_dbProviderObj, uladipendentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(UlaDipendentiCollection collectionObj)
		{
			return UlaDipendentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(UlaDipendenti uladipendentiObj)
		{
			return UlaDipendentiDAL.Delete(_dbProviderObj, uladipendentiObj);
		}

		//getById
		public UlaDipendenti GetById(IntNT IdValue)
		{
			UlaDipendenti UlaDipendentiTemp = UlaDipendentiDAL.GetById(_dbProviderObj, IdValue);
			if (UlaDipendentiTemp!=null) UlaDipendentiTemp.Provider = this;
			return UlaDipendentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public UlaDipendentiCollection Select(IntNT IdEqualThis, IntNT AnnoEqualThis, IntNT IdtipocontrattoEqualThis, 
IntNT OreEqualThis, IntNT OreccnlEqualThis, IntNT NumerodipendentiEqualThis, 
DecimalNT UlaEqualThis, StringNT OperatoreEqualThis, StringNT DatainserimentoEqualThis, 
BoolNT AttivoEqualThis)
		{
			UlaDipendentiCollection UlaDipendentiCollectionTemp = UlaDipendentiDAL.Select(_dbProviderObj, IdEqualThis, AnnoEqualThis, IdtipocontrattoEqualThis, 
OreEqualThis, OreccnlEqualThis, NumerodipendentiEqualThis, 
UlaEqualThis, OperatoreEqualThis, DatainserimentoEqualThis, 
AttivoEqualThis);
			UlaDipendentiCollectionTemp.Provider = this;
			return UlaDipendentiCollectionTemp;
		}

		//Find: popola la collection
		public UlaDipendentiCollection Find(IntNT AnnoEqualThis, BoolNT AttivoEqualThis)
		{
			UlaDipendentiCollection UlaDipendentiCollectionTemp = UlaDipendentiDAL.Find(_dbProviderObj, AnnoEqualThis, AttivoEqualThis);
			UlaDipendentiCollectionTemp.Provider = this;
			return UlaDipendentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ULA_DIPENDENTI>
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
    <Find OrderBy="ORDER BY ANNO">
      <ANNO>Equal</ANNO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ORE>Equal</ORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ULA_DIPENDENTI>
*/
