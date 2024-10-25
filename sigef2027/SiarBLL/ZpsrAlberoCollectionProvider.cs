using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZpsrAlbero
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZpsrAlberoProvider
	{
		int Save(ZpsrAlbero ZpsrAlberoObj);
		int SaveCollection(ZpsrAlberoCollection collectionObj);
		int Delete(ZpsrAlbero ZpsrAlberoObj);
		int DeleteCollection(ZpsrAlberoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZpsrAlbero
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZpsrAlbero: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _CodPsr;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _Livello;
		private NullTypes.BoolNT _AttivazioneBandi;
		private NullTypes.BoolNT _AttivazioneFa;
		private NullTypes.BoolNT _AttivazioneObMisura;
		private NullTypes.BoolNT _AttivazioneInvestimenti;
		private NullTypes.BoolNT _AttivazioneFf;
		[NonSerialized] private IZpsrAlberoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZpsrAlberoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZpsrAlbero()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(30)
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(50)
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
		/// Corrisponde al campo:ATTIVAZIONE_BANDI
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AttivazioneBandi
		{
			get { return _AttivazioneBandi; }
			set {
				if (AttivazioneBandi != value)
				{
					_AttivazioneBandi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_FA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AttivazioneFa
		{
			get { return _AttivazioneFa; }
			set {
				if (AttivazioneFa != value)
				{
					_AttivazioneFa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_OB_MISURA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AttivazioneObMisura
		{
			get { return _AttivazioneObMisura; }
			set {
				if (AttivazioneObMisura != value)
				{
					_AttivazioneObMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_INVESTIMENTI
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AttivazioneInvestimenti
		{
			get { return _AttivazioneInvestimenti; }
			set {
				if (AttivazioneInvestimenti != value)
				{
					_AttivazioneInvestimenti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_FF
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AttivazioneFf
		{
			get { return _AttivazioneFf; }
			set {
				if (AttivazioneFf != value)
				{
					_AttivazioneFf = value;
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
	/// Summary description for ZpsrAlberoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZpsrAlberoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZpsrAlberoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZpsrAlbero) info.GetValue(i.ToString(),typeof(ZpsrAlbero)));
			}
		}

		//Costruttore
		public ZpsrAlberoCollection()
		{
			this.ItemType = typeof(ZpsrAlbero);
		}

		//Costruttore con provider
		public ZpsrAlberoCollection(IZpsrAlberoProvider providerObj)
		{
			this.ItemType = typeof(ZpsrAlbero);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZpsrAlbero this[int index]
		{
			get { return (ZpsrAlbero)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZpsrAlberoCollection GetChanges()
		{
			return (ZpsrAlberoCollection) base.GetChanges();
		}

		[NonSerialized] private IZpsrAlberoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZpsrAlberoProvider Provider
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
		public int Add(ZpsrAlbero ZpsrAlberoObj)
		{
			if (ZpsrAlberoObj.Provider == null) ZpsrAlberoObj.Provider = this.Provider;
			return base.Add(ZpsrAlberoObj);
		}

		//AddCollection
		public void AddCollection(ZpsrAlberoCollection ZpsrAlberoCollectionObj)
		{
			foreach (ZpsrAlbero ZpsrAlberoObj in ZpsrAlberoCollectionObj)
				this.Add(ZpsrAlberoObj);
		}

		//Insert
		public void Insert(int index, ZpsrAlbero ZpsrAlberoObj)
		{
			if (ZpsrAlberoObj.Provider == null) ZpsrAlberoObj.Provider = this.Provider;
			base.Insert(index, ZpsrAlberoObj);
		}

		//CollectionGetById
		public ZpsrAlbero CollectionGetById(NullTypes.StringNT CodiceValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Codice == CodiceValue))
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
		public ZpsrAlberoCollection SubSelect(NullTypes.StringNT CodiceEqualThis, NullTypes.StringNT CodPsrEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.IntNT LivelloEqualThis, NullTypes.BoolNT AttivazioneBandiEqualThis, NullTypes.BoolNT AttivazioneFaEqualThis, 
NullTypes.BoolNT AttivazioneObMisuraEqualThis, NullTypes.BoolNT AttivazioneInvestimentiEqualThis, NullTypes.BoolNT AttivazioneFfEqualThis)
		{
			ZpsrAlberoCollection ZpsrAlberoCollectionTemp = new ZpsrAlberoCollection();
			foreach (ZpsrAlbero ZpsrAlberoItem in this)
			{
				if (((CodiceEqualThis == null) || ((ZpsrAlberoItem.Codice != null) && (ZpsrAlberoItem.Codice.Value == CodiceEqualThis.Value))) && ((CodPsrEqualThis == null) || ((ZpsrAlberoItem.CodPsr != null) && (ZpsrAlberoItem.CodPsr.Value == CodPsrEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ZpsrAlberoItem.Descrizione != null) && (ZpsrAlberoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((LivelloEqualThis == null) || ((ZpsrAlberoItem.Livello != null) && (ZpsrAlberoItem.Livello.Value == LivelloEqualThis.Value))) && ((AttivazioneBandiEqualThis == null) || ((ZpsrAlberoItem.AttivazioneBandi != null) && (ZpsrAlberoItem.AttivazioneBandi.Value == AttivazioneBandiEqualThis.Value))) && ((AttivazioneFaEqualThis == null) || ((ZpsrAlberoItem.AttivazioneFa != null) && (ZpsrAlberoItem.AttivazioneFa.Value == AttivazioneFaEqualThis.Value))) && 
((AttivazioneObMisuraEqualThis == null) || ((ZpsrAlberoItem.AttivazioneObMisura != null) && (ZpsrAlberoItem.AttivazioneObMisura.Value == AttivazioneObMisuraEqualThis.Value))) && ((AttivazioneInvestimentiEqualThis == null) || ((ZpsrAlberoItem.AttivazioneInvestimenti != null) && (ZpsrAlberoItem.AttivazioneInvestimenti.Value == AttivazioneInvestimentiEqualThis.Value))) && ((AttivazioneFfEqualThis == null) || ((ZpsrAlberoItem.AttivazioneFf != null) && (ZpsrAlberoItem.AttivazioneFf.Value == AttivazioneFfEqualThis.Value))))
				{
					ZpsrAlberoCollectionTemp.Add(ZpsrAlberoItem);
				}
			}
			return ZpsrAlberoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZpsrAlberoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZpsrAlberoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZpsrAlbero ZpsrAlberoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", ZpsrAlberoObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "CodPsr", ZpsrAlberoObj.CodPsr);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ZpsrAlberoObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Livello", ZpsrAlberoObj.Livello);
			DbProvider.SetCmdParam(cmd,firstChar + "AttivazioneBandi", ZpsrAlberoObj.AttivazioneBandi);
			DbProvider.SetCmdParam(cmd,firstChar + "AttivazioneFa", ZpsrAlberoObj.AttivazioneFa);
			DbProvider.SetCmdParam(cmd,firstChar + "AttivazioneObMisura", ZpsrAlberoObj.AttivazioneObMisura);
			DbProvider.SetCmdParam(cmd,firstChar + "AttivazioneInvestimenti", ZpsrAlberoObj.AttivazioneInvestimenti);
			DbProvider.SetCmdParam(cmd,firstChar + "AttivazioneFf", ZpsrAlberoObj.AttivazioneFf);
		}
		//Insert
		private static int Insert(DbProvider db, ZpsrAlbero ZpsrAlberoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZpsrAlberoInsert", new string[] {"Codice", "CodPsr", "Descrizione", 
"Livello", "AttivazioneBandi", "AttivazioneFa", 
"AttivazioneObMisura", "AttivazioneInvestimenti", "AttivazioneFf"}, new string[] {"string", "string", "string", 
"int", "bool", "bool", 
"bool", "bool", "bool"},"");
				CompileIUCmd(false, insertCmd,ZpsrAlberoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZpsrAlberoObj.AttivazioneBandi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_BANDI"]);
				ZpsrAlberoObj.AttivazioneFa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FA"]);
				ZpsrAlberoObj.AttivazioneObMisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_OB_MISURA"]);
				ZpsrAlberoObj.AttivazioneInvestimenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_INVESTIMENTI"]);
				ZpsrAlberoObj.AttivazioneFf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FF"]);
				}
				ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZpsrAlberoObj.IsDirty = false;
				ZpsrAlberoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZpsrAlbero ZpsrAlberoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZpsrAlberoUpdate", new string[] {"Codice", "CodPsr", "Descrizione", 
"Livello", "AttivazioneBandi", "AttivazioneFa", 
"AttivazioneObMisura", "AttivazioneInvestimenti", "AttivazioneFf"}, new string[] {"string", "string", "string", 
"int", "bool", "bool", 
"bool", "bool", "bool"},"");
				CompileIUCmd(true, updateCmd,ZpsrAlberoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZpsrAlberoObj.IsDirty = false;
				ZpsrAlberoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZpsrAlbero ZpsrAlberoObj)
		{
			switch (ZpsrAlberoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZpsrAlberoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZpsrAlberoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZpsrAlberoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZpsrAlberoCollection ZpsrAlberoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZpsrAlberoUpdate", new string[] {"Codice", "CodPsr", "Descrizione", 
"Livello", "AttivazioneBandi", "AttivazioneFa", 
"AttivazioneObMisura", "AttivazioneInvestimenti", "AttivazioneFf"}, new string[] {"string", "string", "string", 
"int", "bool", "bool", 
"bool", "bool", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZZpsrAlberoInsert", new string[] {"Codice", "CodPsr", "Descrizione", 
"Livello", "AttivazioneBandi", "AttivazioneFa", 
"AttivazioneObMisura", "AttivazioneInvestimenti", "AttivazioneFf"}, new string[] {"string", "string", "string", 
"int", "bool", "bool", 
"bool", "bool", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZZpsrAlberoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < ZpsrAlberoCollectionObj.Count; i++)
				{
					switch (ZpsrAlberoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZpsrAlberoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZpsrAlberoCollectionObj[i].AttivazioneBandi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_BANDI"]);
									ZpsrAlberoCollectionObj[i].AttivazioneFa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FA"]);
									ZpsrAlberoCollectionObj[i].AttivazioneObMisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_OB_MISURA"]);
									ZpsrAlberoCollectionObj[i].AttivazioneInvestimenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_INVESTIMENTI"]);
									ZpsrAlberoCollectionObj[i].AttivazioneFf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FF"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZpsrAlberoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZpsrAlberoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)ZpsrAlberoCollectionObj[i].Codice);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZpsrAlberoCollectionObj.Count; i++)
				{
					if ((ZpsrAlberoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZpsrAlberoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZpsrAlberoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZpsrAlberoCollectionObj[i].IsDirty = false;
						ZpsrAlberoCollectionObj[i].IsPersistent = true;
					}
					if ((ZpsrAlberoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZpsrAlberoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZpsrAlberoCollectionObj[i].IsDirty = false;
						ZpsrAlberoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZpsrAlbero ZpsrAlberoObj)
		{
			int returnValue = 0;
			if (ZpsrAlberoObj.IsPersistent) 
			{
				returnValue = Delete(db, ZpsrAlberoObj.Codice);
			}
			ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZpsrAlberoObj.IsDirty = false;
			ZpsrAlberoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string CodiceValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZpsrAlberoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZpsrAlberoCollection ZpsrAlberoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZpsrAlberoDelete", new string[] {"Codice"}, new string[] {"string"},"");
				for (int i = 0; i < ZpsrAlberoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Codice", ZpsrAlberoCollectionObj[i].Codice);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZpsrAlberoCollectionObj.Count; i++)
				{
					if ((ZpsrAlberoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZpsrAlberoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZpsrAlberoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZpsrAlberoCollectionObj[i].IsDirty = false;
						ZpsrAlberoCollectionObj[i].IsPersistent = false;
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
		public static ZpsrAlbero GetById(DbProvider db, string CodiceValue)
		{
			ZpsrAlbero ZpsrAlberoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZpsrAlberoGetById", new string[] {"Codice"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Codice", (SiarLibrary.NullTypes.StringNT)CodiceValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZpsrAlberoObj = GetFromDatareader(db);
				ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZpsrAlberoObj.IsDirty = false;
				ZpsrAlberoObj.IsPersistent = true;
			}
			db.Close();
			return ZpsrAlberoObj;
		}

		//getFromDatareader
		public static ZpsrAlbero GetFromDatareader(DbProvider db)
		{
			ZpsrAlbero ZpsrAlberoObj = new ZpsrAlbero();
			ZpsrAlberoObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			ZpsrAlberoObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			ZpsrAlberoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ZpsrAlberoObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			ZpsrAlberoObj.AttivazioneBandi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_BANDI"]);
			ZpsrAlberoObj.AttivazioneFa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FA"]);
			ZpsrAlberoObj.AttivazioneObMisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_OB_MISURA"]);
			ZpsrAlberoObj.AttivazioneInvestimenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_INVESTIMENTI"]);
			ZpsrAlberoObj.AttivazioneFf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FF"]);
			ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZpsrAlberoObj.IsDirty = false;
			ZpsrAlberoObj.IsPersistent = true;
			return ZpsrAlberoObj;
		}

		//Find Select

		public static ZpsrAlberoCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneBandiEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneFaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivazioneObMisuraEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneInvestimentiEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneFfEqualThis)

		{

			ZpsrAlberoCollection ZpsrAlberoCollectionObj = new ZpsrAlberoCollection();

			IDbCommand findCmd = db.InitCmd("Zzpsralberofindselect", new string[] {"Codiceequalthis", "CodPsrequalthis", "Descrizioneequalthis", 
"Livelloequalthis", "AttivazioneBandiequalthis", "AttivazioneFaequalthis", 
"AttivazioneObMisuraequalthis", "AttivazioneInvestimentiequalthis", "AttivazioneFfequalthis"}, new string[] {"string", "string", "string", 
"int", "bool", "bool", 
"bool", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneBandiequalthis", AttivazioneBandiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneFaequalthis", AttivazioneFaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneObMisuraequalthis", AttivazioneObMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneInvestimentiequalthis", AttivazioneInvestimentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneFfequalthis", AttivazioneFfEqualThis);
			ZpsrAlbero ZpsrAlberoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZpsrAlberoObj = GetFromDatareader(db);
				ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZpsrAlberoObj.IsDirty = false;
				ZpsrAlberoObj.IsPersistent = true;
				ZpsrAlberoCollectionObj.Add(ZpsrAlberoObj);
			}
			db.Close();
			return ZpsrAlberoCollectionObj;
		}

		//Find Find

		public static ZpsrAlberoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivazioneBandiEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneFaEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneObMisuraEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivazioneInvestimentiEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneFfEqualThis)

		{

			ZpsrAlberoCollection ZpsrAlberoCollectionObj = new ZpsrAlberoCollection();

			IDbCommand findCmd = db.InitCmd("Zzpsralberofindfind", new string[] {"CodPsrequalthis", "Descrizionelikethis", "Livelloequalthis", 
"AttivazioneBandiequalthis", "AttivazioneFaequalthis", "AttivazioneObMisuraequalthis", 
"AttivazioneInvestimentiequalthis", "AttivazioneFfequalthis"}, new string[] {"string", "string", "int", 
"bool", "bool", "bool", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneBandiequalthis", AttivazioneBandiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneFaequalthis", AttivazioneFaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneObMisuraequalthis", AttivazioneObMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneInvestimentiequalthis", AttivazioneInvestimentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneFfequalthis", AttivazioneFfEqualThis);
			ZpsrAlbero ZpsrAlberoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZpsrAlberoObj = GetFromDatareader(db);
				ZpsrAlberoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZpsrAlberoObj.IsDirty = false;
				ZpsrAlberoObj.IsPersistent = true;
				ZpsrAlberoCollectionObj.Add(ZpsrAlberoObj);
			}
			db.Close();
			return ZpsrAlberoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZpsrAlberoCollectionProvider:IZpsrAlberoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZpsrAlberoCollectionProvider : IZpsrAlberoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZpsrAlbero
		protected ZpsrAlberoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZpsrAlberoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZpsrAlberoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZpsrAlberoCollectionProvider(StringNT CodpsrEqualThis, StringNT DescrizioneLikeThis, IntNT LivelloEqualThis, 
BoolNT AttivazionebandiEqualThis, BoolNT AttivazionefaEqualThis, BoolNT AttivazioneobmisuraEqualThis, 
BoolNT AttivazioneinvestimentiEqualThis, BoolNT AttivazioneffEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodpsrEqualThis, DescrizioneLikeThis, LivelloEqualThis, 
AttivazionebandiEqualThis, AttivazionefaEqualThis, AttivazioneobmisuraEqualThis, 
AttivazioneinvestimentiEqualThis, AttivazioneffEqualThis);
		}

		//Costruttore3: ha in input zpsralberoCollectionObj - non popola la collection
		public ZpsrAlberoCollectionProvider(ZpsrAlberoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZpsrAlberoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZpsrAlberoCollection(this);
		}

		//Get e Set
		public ZpsrAlberoCollection CollectionObj
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
		public int SaveCollection(ZpsrAlberoCollection collectionObj)
		{
			return ZpsrAlberoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZpsrAlbero zpsralberoObj)
		{
			return ZpsrAlberoDAL.Save(_dbProviderObj, zpsralberoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZpsrAlberoCollection collectionObj)
		{
			return ZpsrAlberoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZpsrAlbero zpsralberoObj)
		{
			return ZpsrAlberoDAL.Delete(_dbProviderObj, zpsralberoObj);
		}

		//getById
		public ZpsrAlbero GetById(StringNT CodiceValue)
		{
			ZpsrAlbero ZpsrAlberoTemp = ZpsrAlberoDAL.GetById(_dbProviderObj, CodiceValue);
			if (ZpsrAlberoTemp!=null) ZpsrAlberoTemp.Provider = this;
			return ZpsrAlberoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZpsrAlberoCollection Select(StringNT CodiceEqualThis, StringNT CodpsrEqualThis, StringNT DescrizioneEqualThis, 
IntNT LivelloEqualThis, BoolNT AttivazionebandiEqualThis, BoolNT AttivazionefaEqualThis, 
BoolNT AttivazioneobmisuraEqualThis, BoolNT AttivazioneinvestimentiEqualThis, BoolNT AttivazioneffEqualThis)
		{
			ZpsrAlberoCollection ZpsrAlberoCollectionTemp = ZpsrAlberoDAL.Select(_dbProviderObj, CodiceEqualThis, CodpsrEqualThis, DescrizioneEqualThis, 
LivelloEqualThis, AttivazionebandiEqualThis, AttivazionefaEqualThis, 
AttivazioneobmisuraEqualThis, AttivazioneinvestimentiEqualThis, AttivazioneffEqualThis);
			ZpsrAlberoCollectionTemp.Provider = this;
			return ZpsrAlberoCollectionTemp;
		}

		//Find: popola la collection
		public ZpsrAlberoCollection Find(StringNT CodpsrEqualThis, StringNT DescrizioneLikeThis, IntNT LivelloEqualThis, 
BoolNT AttivazionebandiEqualThis, BoolNT AttivazionefaEqualThis, BoolNT AttivazioneobmisuraEqualThis, 
BoolNT AttivazioneinvestimentiEqualThis, BoolNT AttivazioneffEqualThis)
		{
			ZpsrAlberoCollection ZpsrAlberoCollectionTemp = ZpsrAlberoDAL.Find(_dbProviderObj, CodpsrEqualThis, DescrizioneLikeThis, LivelloEqualThis, 
AttivazionebandiEqualThis, AttivazionefaEqualThis, AttivazioneobmisuraEqualThis, 
AttivazioneinvestimentiEqualThis, AttivazioneffEqualThis);
			ZpsrAlberoCollectionTemp.Provider = this;
			return ZpsrAlberoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPSR_ALBERO>
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
    <Find OrderBy="ORDER BY LIVELLO">
      <COD_PSR>Equal</COD_PSR>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <LIVELLO>Equal</LIVELLO>
      <ATTIVAZIONE_BANDI>Equal</ATTIVAZIONE_BANDI>
      <ATTIVAZIONE_FA>Equal</ATTIVAZIONE_FA>
      <ATTIVAZIONE_OB_MISURA>Equal</ATTIVAZIONE_OB_MISURA>
      <ATTIVAZIONE_INVESTIMENTI>Equal</ATTIVAZIONE_INVESTIMENTI>
      <ATTIVAZIONE_FF>Equal</ATTIVAZIONE_FF>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPSR_ALBERO>
*/
