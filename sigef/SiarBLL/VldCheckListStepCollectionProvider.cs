using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VldCheckListStep
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVldCheckListStepProvider
	{
		int Save(VldCheckListStep VldCheckListStepObj);
		int SaveCollection(VldCheckListStepCollection collectionObj);
		int Delete(VldCheckListStep VldCheckListStepObj);
		int DeleteCollection(VldCheckListStepCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VldCheckListStep
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VldCheckListStep: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVldCheckList;
		private NullTypes.IntNT _IdVldStep;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.BoolNT _IncludiVerbaleVis;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Automatico;
		[NonSerialized] private IVldCheckListStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVldCheckListStepProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VldCheckListStep()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VLD_CHECK_LIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVldCheckList
		{
			get { return _IdVldCheckList; }
			set {
				if (IdVldCheckList != value)
				{
					_IdVldCheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_VLD_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVldStep
		{
			get { return _IdVldStep; }
			set {
				if (IdVldStep != value)
				{
					_IdVldStep = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Ordine
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

		/// <summary>
		/// Corrisponde al campo:OBBLIGATORIO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Obbligatorio
		{
			get { return _Obbligatorio; }
			set {
				if (Obbligatorio != value)
				{
					_Obbligatorio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INCLUDI_VERBALE_VIS
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT IncludiVerbaleVis
		{
			get { return _IncludiVerbaleVis; }
			set {
				if (IncludiVerbaleVis != value)
				{
					_IncludiVerbaleVis = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set {
				if (Automatico != value)
				{
					_Automatico = value;
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
	/// Summary description for VldCheckListStepCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VldCheckListStepCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VldCheckListStepCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VldCheckListStep) info.GetValue(i.ToString(),typeof(VldCheckListStep)));
			}
		}

		//Costruttore
		public VldCheckListStepCollection()
		{
			this.ItemType = typeof(VldCheckListStep);
		}

		//Costruttore con provider
		public VldCheckListStepCollection(IVldCheckListStepProvider providerObj)
		{
			this.ItemType = typeof(VldCheckListStep);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VldCheckListStep this[int index]
		{
			get { return (VldCheckListStep)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VldCheckListStepCollection GetChanges()
		{
			return (VldCheckListStepCollection) base.GetChanges();
		}

		[NonSerialized] private IVldCheckListStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVldCheckListStepProvider Provider
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
		public int Add(VldCheckListStep VldCheckListStepObj)
		{
			if (VldCheckListStepObj.Provider == null) VldCheckListStepObj.Provider = this.Provider;
			return base.Add(VldCheckListStepObj);
		}

		//AddCollection
		public void AddCollection(VldCheckListStepCollection VldCheckListStepCollectionObj)
		{
			foreach (VldCheckListStep VldCheckListStepObj in VldCheckListStepCollectionObj)
				this.Add(VldCheckListStepObj);
		}

		//Insert
		public void Insert(int index, VldCheckListStep VldCheckListStepObj)
		{
			if (VldCheckListStepObj.Provider == null) VldCheckListStepObj.Provider = this.Provider;
			base.Insert(index, VldCheckListStepObj);
		}

		//CollectionGetById
		public VldCheckListStep CollectionGetById(NullTypes.IntNT IdVldCheckListValue, NullTypes.IntNT IdVldStepValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdVldCheckList == IdVldCheckListValue) && (this[i].IdVldStep == IdVldStepValue))
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
		public VldCheckListStepCollection SubSelect(NullTypes.IntNT IdVldCheckListEqualThis, NullTypes.IntNT IdVldStepEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.BoolNT IncludiVerbaleVisEqualThis)
		{
			VldCheckListStepCollection VldCheckListStepCollectionTemp = new VldCheckListStepCollection();
			foreach (VldCheckListStep VldCheckListStepItem in this)
			{
				if (((IdVldCheckListEqualThis == null) || ((VldCheckListStepItem.IdVldCheckList != null) && (VldCheckListStepItem.IdVldCheckList.Value == IdVldCheckListEqualThis.Value))) && ((IdVldStepEqualThis == null) || ((VldCheckListStepItem.IdVldStep != null) && (VldCheckListStepItem.IdVldStep.Value == IdVldStepEqualThis.Value))) && ((OrdineEqualThis == null) || ((VldCheckListStepItem.Ordine != null) && (VldCheckListStepItem.Ordine.Value == OrdineEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((VldCheckListStepItem.Obbligatorio != null) && (VldCheckListStepItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((IncludiVerbaleVisEqualThis == null) || ((VldCheckListStepItem.IncludiVerbaleVis != null) && (VldCheckListStepItem.IncludiVerbaleVis.Value == IncludiVerbaleVisEqualThis.Value))))
				{
					VldCheckListStepCollectionTemp.Add(VldCheckListStepItem);
				}
			}
			return VldCheckListStepCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VldCheckListStepDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VldCheckListStepDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VldCheckListStep VldCheckListStepObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdVldCheckList", VldCheckListStepObj.IdVldCheckList);
			DbProvider.SetCmdParam(cmd,firstChar + "IdVldStep", VldCheckListStepObj.IdVldStep);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", VldCheckListStepObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "IncludiVerbaleVis", VldCheckListStepObj.IncludiVerbaleVis);
		}
		//Insert
		private static int Insert(DbProvider db, VldCheckListStep VldCheckListStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZVldCheckListStepInsert", new string[] {"IdVldCheckList", "IdVldStep", 
"Obbligatorio", "IncludiVerbaleVis", }, new string[] {"int", "int", 
"bool", "bool", },"");
				CompileIUCmd(false, insertCmd,VldCheckListStepObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				VldCheckListStepObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
				VldCheckListStepObj.IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
				}
				VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldCheckListStepObj.IsDirty = false;
				VldCheckListStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VldCheckListStep VldCheckListStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVldCheckListStepUpdate", new string[] {"IdVldCheckList", "IdVldStep", 
"Obbligatorio", "IncludiVerbaleVis", }, new string[] {"int", "int", 
"bool", "bool", },"");
				CompileIUCmd(true, updateCmd,VldCheckListStepObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldCheckListStepObj.IsDirty = false;
				VldCheckListStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VldCheckListStep VldCheckListStepObj)
		{
			switch (VldCheckListStepObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, VldCheckListStepObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, VldCheckListStepObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,VldCheckListStepObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VldCheckListStepCollection VldCheckListStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZVldCheckListStepUpdate", new string[] {"IdVldCheckList", "IdVldStep", 
"Obbligatorio", "IncludiVerbaleVis", }, new string[] {"int", "int", 
"bool", "bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZVldCheckListStepInsert", new string[] {"IdVldCheckList", "IdVldStep", 
"Obbligatorio", "IncludiVerbaleVis", }, new string[] {"int", "int", 
"bool", "bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZVldCheckListStepDelete", new string[] {"IdVldCheckList", "IdVldStep"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VldCheckListStepCollectionObj.Count; i++)
				{
					switch (VldCheckListStepCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,VldCheckListStepCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VldCheckListStepCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
									VldCheckListStepCollectionObj[i].IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,VldCheckListStepCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (VldCheckListStepCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldCheckList", (SiarLibrary.NullTypes.IntNT)VldCheckListStepCollectionObj[i].IdVldCheckList);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldStep", (SiarLibrary.NullTypes.IntNT)VldCheckListStepCollectionObj[i].IdVldStep);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VldCheckListStepCollectionObj.Count; i++)
				{
					if ((VldCheckListStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldCheckListStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VldCheckListStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VldCheckListStepCollectionObj[i].IsDirty = false;
						VldCheckListStepCollectionObj[i].IsPersistent = true;
					}
					if ((VldCheckListStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VldCheckListStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VldCheckListStepCollectionObj[i].IsDirty = false;
						VldCheckListStepCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, VldCheckListStep VldCheckListStepObj)
		{
			int returnValue = 0;
			if (VldCheckListStepObj.IsPersistent) 
			{
				returnValue = Delete(db, VldCheckListStepObj.IdVldCheckList, VldCheckListStepObj.IdVldStep);
			}
			VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VldCheckListStepObj.IsDirty = false;
			VldCheckListStepObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVldCheckListValue, int IdVldStepValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVldCheckListStepDelete", new string[] {"IdVldCheckList", "IdVldStep"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldCheckList", (SiarLibrary.NullTypes.IntNT)IdVldCheckListValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldStep", (SiarLibrary.NullTypes.IntNT)IdVldStepValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VldCheckListStepCollection VldCheckListStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZVldCheckListStepDelete", new string[] {"IdVldCheckList", "IdVldStep"}, new string[] {"int", "int"},"");
				for (int i = 0; i < VldCheckListStepCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldCheckList", VldCheckListStepCollectionObj[i].IdVldCheckList);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdVldStep", VldCheckListStepCollectionObj[i].IdVldStep);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VldCheckListStepCollectionObj.Count; i++)
				{
					if ((VldCheckListStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VldCheckListStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VldCheckListStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VldCheckListStepCollectionObj[i].IsDirty = false;
						VldCheckListStepCollectionObj[i].IsPersistent = false;
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
		public static VldCheckListStep GetById(DbProvider db, int IdVldCheckListValue, int IdVldStepValue)
		{
			VldCheckListStep VldCheckListStepObj = null;
			IDbCommand readCmd = db.InitCmd( "ZVldCheckListStepGetById", new string[] {"IdVldCheckList", "IdVldStep"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVldCheckList", (SiarLibrary.NullTypes.IntNT)IdVldCheckListValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdVldStep", (SiarLibrary.NullTypes.IntNT)IdVldStepValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VldCheckListStepObj = GetFromDatareader(db);
				VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldCheckListStepObj.IsDirty = false;
				VldCheckListStepObj.IsPersistent = true;
			}
			db.Close();
			return VldCheckListStepObj;
		}

		//getFromDatareader
		public static VldCheckListStep GetFromDatareader(DbProvider db)
		{
			VldCheckListStep VldCheckListStepObj = new VldCheckListStep();
			VldCheckListStepObj.IdVldCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VLD_CHECK_LIST"]);
			VldCheckListStepObj.IdVldStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VLD_STEP"]);
			VldCheckListStepObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["Ordine"]);
			VldCheckListStepObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			VldCheckListStepObj.IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
			VldCheckListStepObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VldCheckListStepObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VldCheckListStepObj.IsDirty = false;
			VldCheckListStepObj.IsPersistent = true;
			return VldCheckListStepObj;
		}

		//Find Select

		public static VldCheckListStepCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVldCheckListEqualThis, SiarLibrary.NullTypes.IntNT IdVldStepEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.BoolNT IncludiVerbaleVisEqualThis)

		{

			VldCheckListStepCollection VldCheckListStepCollectionObj = new VldCheckListStepCollection();

			IDbCommand findCmd = db.InitCmd("Zvldcheckliststepfindselect", new string[] {"IdVldCheckListequalthis", "IdVldStepequalthis", "Ordineequalthis", 
"Obbligatorioequalthis", "IncludiVerbaleVisequalthis"}, new string[] {"int", "int", "int", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVldCheckListequalthis", IdVldCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdVldStepequalthis", IdVldStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IncludiVerbaleVisequalthis", IncludiVerbaleVisEqualThis);
			VldCheckListStep VldCheckListStepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VldCheckListStepObj = GetFromDatareader(db);
				VldCheckListStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VldCheckListStepObj.IsDirty = false;
				VldCheckListStepObj.IsPersistent = true;
				VldCheckListStepCollectionObj.Add(VldCheckListStepObj);
			}
			db.Close();
			return VldCheckListStepCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VldCheckListStepCollectionProvider:IVldCheckListStepProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VldCheckListStepCollectionProvider : IVldCheckListStepProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VldCheckListStep
		protected VldCheckListStepCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VldCheckListStepCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VldCheckListStepCollection(this);
		}

		//Costruttore3: ha in input vldcheckliststepCollectionObj - non popola la collection
		public VldCheckListStepCollectionProvider(VldCheckListStepCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VldCheckListStepCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VldCheckListStepCollection(this);
		}

		//Get e Set
		public VldCheckListStepCollection CollectionObj
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
		public int SaveCollection(VldCheckListStepCollection collectionObj)
		{
			return VldCheckListStepDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VldCheckListStep vldcheckliststepObj)
		{
			return VldCheckListStepDAL.Save(_dbProviderObj, vldcheckliststepObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VldCheckListStepCollection collectionObj)
		{
			return VldCheckListStepDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VldCheckListStep vldcheckliststepObj)
		{
			return VldCheckListStepDAL.Delete(_dbProviderObj, vldcheckliststepObj);
		}

		//getById
		public VldCheckListStep GetById(IntNT IdVldCheckListValue, IntNT IdVldStepValue)
		{
			VldCheckListStep VldCheckListStepTemp = VldCheckListStepDAL.GetById(_dbProviderObj, IdVldCheckListValue, IdVldStepValue);
			if (VldCheckListStepTemp!=null) VldCheckListStepTemp.Provider = this;
			return VldCheckListStepTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VldCheckListStepCollection Select(IntNT IdvldchecklistEqualThis, IntNT IdvldstepEqualThis, IntNT OrdineEqualThis, 
BoolNT ObbligatorioEqualThis, BoolNT IncludiverbalevisEqualThis)
		{
			VldCheckListStepCollection VldCheckListStepCollectionTemp = VldCheckListStepDAL.Select(_dbProviderObj, IdvldchecklistEqualThis, IdvldstepEqualThis, OrdineEqualThis, 
ObbligatorioEqualThis, IncludiverbalevisEqualThis);
			VldCheckListStepCollectionTemp.Provider = this;
			return VldCheckListStepCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VLD_CHECK_LIST_STEP>
  <ViewName>vVLD_CHECK_LIST_STEP</ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</VLD_CHECK_LIST_STEP>
*/
