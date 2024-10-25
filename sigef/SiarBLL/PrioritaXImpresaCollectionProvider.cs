using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaXImpresa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaXImpresaProvider
	{
		int Save(PrioritaXImpresa PrioritaXImpresaObj);
		int SaveCollection(PrioritaXImpresaCollection collectionObj);
		int Delete(PrioritaXImpresa PrioritaXImpresaObj);
		int DeleteCollection(PrioritaXImpresaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaXImpresa
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PrioritaXImpresa: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdValore;
		private NullTypes.BoolNT _Scelto;
		private NullTypes.DecimalNT _Valore;
		private NullTypes.DatetimeNT _ValData;
		private NullTypes.StringNT _ValTesto;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IPrioritaXImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXImpresaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaXImpresa()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
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
		/// Corrisponde al campo:ID_VALORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValore
		{
			get { return _IdValore; }
			set {
				if (IdValore != value)
				{
					_IdValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCELTO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Scelto
		{
			get { return _Scelto; }
			set {
				if (Scelto != value)
				{
					_Scelto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Valore
		{
			get { return _Valore; }
			set {
				if (Valore != value)
				{
					_Valore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT ValData
		{
			get { return _ValData; }
			set {
				if (ValData != value)
				{
					_ValData = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_TESTO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT ValTesto
		{
			get { return _ValTesto; }
			set {
				if (ValTesto != value)
				{
					_ValTesto = value;
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
	/// Summary description for PrioritaXImpresaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXImpresaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaXImpresaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaXImpresa) info.GetValue(i.ToString(),typeof(PrioritaXImpresa)));
			}
		}

		//Costruttore
		public PrioritaXImpresaCollection()
		{
			this.ItemType = typeof(PrioritaXImpresa);
		}

		//Costruttore con provider
		public PrioritaXImpresaCollection(IPrioritaXImpresaProvider providerObj)
		{
			this.ItemType = typeof(PrioritaXImpresa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaXImpresa this[int index]
		{
			get { return (PrioritaXImpresa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaXImpresaCollection GetChanges()
		{
			return (PrioritaXImpresaCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaXImpresaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXImpresaProvider Provider
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
		public int Add(PrioritaXImpresa PrioritaXImpresaObj)
		{
			if (PrioritaXImpresaObj.Provider == null) PrioritaXImpresaObj.Provider = this.Provider;
			return base.Add(PrioritaXImpresaObj);
		}

		//AddCollection
		public void AddCollection(PrioritaXImpresaCollection PrioritaXImpresaCollectionObj)
		{
			foreach (PrioritaXImpresa PrioritaXImpresaObj in PrioritaXImpresaCollectionObj)
				this.Add(PrioritaXImpresaObj);
		}

		//Insert
		public void Insert(int index, PrioritaXImpresa PrioritaXImpresaObj)
		{
			if (PrioritaXImpresaObj.Provider == null) PrioritaXImpresaObj.Provider = this.Provider;
			base.Insert(index, PrioritaXImpresaObj);
		}

		//CollectionGetById
		public PrioritaXImpresa CollectionGetById(NullTypes.IntNT IdPrioritaValue, NullTypes.IntNT IdImpresaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPriorita == IdPrioritaValue) && (this[i].IdImpresa == IdImpresaValue))
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
		public PrioritaXImpresaCollection SubSelect(NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT IdValoreEqualThis, NullTypes.BoolNT SceltoEqualThis, NullTypes.DecimalNT ValoreEqualThis, 
NullTypes.DatetimeNT ValDataEqualThis, NullTypes.StringNT ValTestoEqualThis)
		{
			PrioritaXImpresaCollection PrioritaXImpresaCollectionTemp = new PrioritaXImpresaCollection();
			foreach (PrioritaXImpresa PrioritaXImpresaItem in this)
			{
				if (((IdPrioritaEqualThis == null) || ((PrioritaXImpresaItem.IdPriorita != null) && (PrioritaXImpresaItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((PrioritaXImpresaItem.IdImpresa != null) && (PrioritaXImpresaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((PrioritaXImpresaItem.IdProgetto != null) && (PrioritaXImpresaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((IdValoreEqualThis == null) || ((PrioritaXImpresaItem.IdValore != null) && (PrioritaXImpresaItem.IdValore.Value == IdValoreEqualThis.Value))) && ((SceltoEqualThis == null) || ((PrioritaXImpresaItem.Scelto != null) && (PrioritaXImpresaItem.Scelto.Value == SceltoEqualThis.Value))) && ((ValoreEqualThis == null) || ((PrioritaXImpresaItem.Valore != null) && (PrioritaXImpresaItem.Valore.Value == ValoreEqualThis.Value))) && 
((ValDataEqualThis == null) || ((PrioritaXImpresaItem.ValData != null) && (PrioritaXImpresaItem.ValData.Value == ValDataEqualThis.Value))) && ((ValTestoEqualThis == null) || ((PrioritaXImpresaItem.ValTesto != null) && (PrioritaXImpresaItem.ValTesto.Value == ValTestoEqualThis.Value))))
				{
					PrioritaXImpresaCollectionTemp.Add(PrioritaXImpresaItem);
				}
			}
			return PrioritaXImpresaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaXImpresaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PrioritaXImpresaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaXImpresa PrioritaXImpresaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaXImpresaObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", PrioritaXImpresaObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PrioritaXImpresaObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValore", PrioritaXImpresaObj.IdValore);
			DbProvider.SetCmdParam(cmd,firstChar + "Scelto", PrioritaXImpresaObj.Scelto);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", PrioritaXImpresaObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValData", PrioritaXImpresaObj.ValData);
			DbProvider.SetCmdParam(cmd,firstChar + "ValTesto", PrioritaXImpresaObj.ValTesto);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaXImpresa PrioritaXImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXImpresaInsert", new string[] {"IdPriorita", "IdImpresa", "IdProgetto", 
"IdValore", "Scelto", "Valore", 
"ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"int", "bool", "decimal", 
"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,PrioritaXImpresaObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXImpresaObj.IsDirty = false;
				PrioritaXImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaXImpresa PrioritaXImpresaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXImpresaUpdate", new string[] {"IdPriorita", "IdImpresa", "IdProgetto", 
"IdValore", "Scelto", "Valore", 
"ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"int", "bool", "decimal", 
"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,PrioritaXImpresaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXImpresaObj.IsDirty = false;
				PrioritaXImpresaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaXImpresa PrioritaXImpresaObj)
		{
			switch (PrioritaXImpresaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaXImpresaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaXImpresaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaXImpresaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaXImpresaCollection PrioritaXImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXImpresaUpdate", new string[] {"IdPriorita", "IdImpresa", "IdProgetto", 
"IdValore", "Scelto", "Valore", 
"ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"int", "bool", "decimal", 
"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXImpresaInsert", new string[] {"IdPriorita", "IdImpresa", "IdProgetto", 
"IdValore", "Scelto", "Valore", 
"ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"int", "bool", "decimal", 
"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXImpresaDelete", new string[] {"IdPriorita", "IdImpresa"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXImpresaCollectionObj.Count; i++)
				{
					switch (PrioritaXImpresaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaXImpresaCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaXImpresaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaXImpresaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)PrioritaXImpresaCollectionObj[i].IdPriorita);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)PrioritaXImpresaCollectionObj[i].IdImpresa);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaXImpresaCollectionObj.Count; i++)
				{
					if ((PrioritaXImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaXImpresaCollectionObj[i].IsDirty = false;
						PrioritaXImpresaCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaXImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaXImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXImpresaCollectionObj[i].IsDirty = false;
						PrioritaXImpresaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaXImpresa PrioritaXImpresaObj)
		{
			int returnValue = 0;
			if (PrioritaXImpresaObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaXImpresaObj.IdPriorita, PrioritaXImpresaObj.IdImpresa);
			}
			PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaXImpresaObj.IsDirty = false;
			PrioritaXImpresaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrioritaValue, int IdImpresaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXImpresaDelete", new string[] {"IdPriorita", "IdImpresa"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)IdImpresaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaXImpresaCollection PrioritaXImpresaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXImpresaDelete", new string[] {"IdPriorita", "IdImpresa"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXImpresaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", PrioritaXImpresaCollectionObj[i].IdPriorita);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdImpresa", PrioritaXImpresaCollectionObj[i].IdImpresa);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaXImpresaCollectionObj.Count; i++)
				{
					if ((PrioritaXImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXImpresaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXImpresaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXImpresaCollectionObj[i].IsDirty = false;
						PrioritaXImpresaCollectionObj[i].IsPersistent = false;
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
		public static PrioritaXImpresa GetById(DbProvider db, int IdPrioritaValue, int IdImpresaValue)
		{
			PrioritaXImpresa PrioritaXImpresaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaXImpresaGetById", new string[] {"IdPriorita", "IdImpresa"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdImpresa", (SiarLibrary.NullTypes.IntNT)IdImpresaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaXImpresaObj = GetFromDatareader(db);
				PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXImpresaObj.IsDirty = false;
				PrioritaXImpresaObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaXImpresaObj;
		}

		//getFromDatareader
		public static PrioritaXImpresa GetFromDatareader(DbProvider db)
		{
			PrioritaXImpresa PrioritaXImpresaObj = new PrioritaXImpresa();
			PrioritaXImpresaObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaXImpresaObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			PrioritaXImpresaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PrioritaXImpresaObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			PrioritaXImpresaObj.Scelto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCELTO"]);
			PrioritaXImpresaObj.Valore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE"]);
			PrioritaXImpresaObj.ValData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VAL_DATA"]);
			PrioritaXImpresaObj.ValTesto = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_TESTO"]);
			PrioritaXImpresaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaXImpresaObj.IsDirty = false;
			PrioritaXImpresaObj.IsPersistent = true;
			return PrioritaXImpresaObj;
		}

		//Find Select

		public static PrioritaXImpresaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.BoolNT SceltoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT ValDataEqualThis, SiarLibrary.NullTypes.StringNT ValTestoEqualThis)

		{

			PrioritaXImpresaCollection PrioritaXImpresaCollectionObj = new PrioritaXImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaximpresafindselect", new string[] {"IdPrioritaequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"IdValoreequalthis", "Sceltoequalthis", "Valoreequalthis", 
"ValDataequalthis", "ValTestoequalthis"}, new string[] {"int", "int", "int", 
"int", "bool", "decimal", 
"DateTime", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sceltoequalthis", SceltoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValDataequalthis", ValDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValTestoequalthis", ValTestoEqualThis);
			PrioritaXImpresa PrioritaXImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXImpresaObj = GetFromDatareader(db);
				PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXImpresaObj.IsDirty = false;
				PrioritaXImpresaObj.IsPersistent = true;
				PrioritaXImpresaCollectionObj.Add(PrioritaXImpresaObj);
			}
			db.Close();
			return PrioritaXImpresaCollectionObj;
		}

		//Find Find

		public static PrioritaXImpresaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdValoreEqualThis, SiarLibrary.NullTypes.BoolNT SceltoEqualThis)

		{

			PrioritaXImpresaCollection PrioritaXImpresaCollectionObj = new PrioritaXImpresaCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaximpresafindfind", new string[] {"IdPrioritaequalthis", "IdImpresaequalthis", "IdProgettoequalthis", 
"IdValoreequalthis", "Sceltoequalthis"}, new string[] {"int", "int", "int", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sceltoequalthis", SceltoEqualThis);
			PrioritaXImpresa PrioritaXImpresaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXImpresaObj = GetFromDatareader(db);
				PrioritaXImpresaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXImpresaObj.IsDirty = false;
				PrioritaXImpresaObj.IsPersistent = true;
				PrioritaXImpresaCollectionObj.Add(PrioritaXImpresaObj);
			}
			db.Close();
			return PrioritaXImpresaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaXImpresaCollectionProvider:IPrioritaXImpresaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXImpresaCollectionProvider : IPrioritaXImpresaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaXImpresa
		protected PrioritaXImpresaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaXImpresaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaXImpresaCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaXImpresaCollectionProvider(IntNT IdprioritaEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdvaloreEqualThis, BoolNT SceltoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprioritaEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
IdvaloreEqualThis, SceltoEqualThis);
		}

		//Costruttore3: ha in input prioritaximpresaCollectionObj - non popola la collection
		public PrioritaXImpresaCollectionProvider(PrioritaXImpresaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaXImpresaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaXImpresaCollection(this);
		}

		//Get e Set
		public PrioritaXImpresaCollection CollectionObj
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
		public int SaveCollection(PrioritaXImpresaCollection collectionObj)
		{
			return PrioritaXImpresaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaXImpresa prioritaximpresaObj)
		{
			return PrioritaXImpresaDAL.Save(_dbProviderObj, prioritaximpresaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaXImpresaCollection collectionObj)
		{
			return PrioritaXImpresaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaXImpresa prioritaximpresaObj)
		{
			return PrioritaXImpresaDAL.Delete(_dbProviderObj, prioritaximpresaObj);
		}

		//getById
		public PrioritaXImpresa GetById(IntNT IdPrioritaValue, IntNT IdImpresaValue)
		{
			PrioritaXImpresa PrioritaXImpresaTemp = PrioritaXImpresaDAL.GetById(_dbProviderObj, IdPrioritaValue, IdImpresaValue);
			if (PrioritaXImpresaTemp!=null) PrioritaXImpresaTemp.Provider = this;
			return PrioritaXImpresaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaXImpresaCollection Select(IntNT IdprioritaEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdvaloreEqualThis, BoolNT SceltoEqualThis, DecimalNT ValoreEqualThis, 
DatetimeNT ValdataEqualThis, StringNT ValtestoEqualThis)
		{
			PrioritaXImpresaCollection PrioritaXImpresaCollectionTemp = PrioritaXImpresaDAL.Select(_dbProviderObj, IdprioritaEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
IdvaloreEqualThis, SceltoEqualThis, ValoreEqualThis, 
ValdataEqualThis, ValtestoEqualThis);
			PrioritaXImpresaCollectionTemp.Provider = this;
			return PrioritaXImpresaCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaXImpresaCollection Find(IntNT IdprioritaEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT IdvaloreEqualThis, BoolNT SceltoEqualThis)
		{
			PrioritaXImpresaCollection PrioritaXImpresaCollectionTemp = PrioritaXImpresaDAL.Find(_dbProviderObj, IdprioritaEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
IdvaloreEqualThis, SceltoEqualThis);
			PrioritaXImpresaCollectionTemp.Provider = this;
			return PrioritaXImpresaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_X_IMPRESA>
  <ViewName>vPRIORITA_X_IMPRESA</ViewName>
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
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_VALORE>Equal</ID_VALORE>
      <SCELTO>Equal</SCELTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_X_IMPRESA>
*/
