using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaXInvestimentiModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaXInvestimentiModificheProvider
	{
		int Save(PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj);
		int SaveCollection(PrioritaXInvestimentiModificheCollection collectionObj);
		int Delete(PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj);
		int DeleteCollection(PrioritaXInvestimentiModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaXInvestimentiModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PrioritaXInvestimentiModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.IntNT _IdInvestimento;
		private NullTypes.IntNT _IdValore;
		private NullTypes.BoolNT _Scelto;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DecimalNT _ValorePunteggio;
		private NullTypes.DecimalNT _Valore;
		private NullTypes.DatetimeNT _ValData;
		private NullTypes.StringNT _ValTesto;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IPrioritaXInvestimentiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXInvestimentiModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaXInvestimentiModifiche()
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
		/// Corrisponde al campo:ID_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdInvestimento
		{
			get { return _IdInvestimento; }
			set {
				if (IdInvestimento != value)
				{
					_IdInvestimento = value;
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
		/// Corrisponde al campo:VALORE_PUNTEGGIO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT ValorePunteggio
		{
			get { return _ValorePunteggio; }
			set {
				if (ValorePunteggio != value)
				{
					_ValorePunteggio = value;
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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
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
	/// Summary description for PrioritaXInvestimentiModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXInvestimentiModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaXInvestimentiModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaXInvestimentiModifiche) info.GetValue(i.ToString(),typeof(PrioritaXInvestimentiModifiche)));
			}
		}

		//Costruttore
		public PrioritaXInvestimentiModificheCollection()
		{
			this.ItemType = typeof(PrioritaXInvestimentiModifiche);
		}

		//Costruttore con provider
		public PrioritaXInvestimentiModificheCollection(IPrioritaXInvestimentiModificheProvider providerObj)
		{
			this.ItemType = typeof(PrioritaXInvestimentiModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaXInvestimentiModifiche this[int index]
		{
			get { return (PrioritaXInvestimentiModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaXInvestimentiModificheCollection GetChanges()
		{
			return (PrioritaXInvestimentiModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaXInvestimentiModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXInvestimentiModificheProvider Provider
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
		public int Add(PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			if (PrioritaXInvestimentiModificheObj.Provider == null) PrioritaXInvestimentiModificheObj.Provider = this.Provider;
			return base.Add(PrioritaXInvestimentiModificheObj);
		}

		//AddCollection
		public void AddCollection(PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionObj)
		{
			foreach (PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj in PrioritaXInvestimentiModificheCollectionObj)
				this.Add(PrioritaXInvestimentiModificheObj);
		}

		//Insert
		public void Insert(int index, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			if (PrioritaXInvestimentiModificheObj.Provider == null) PrioritaXInvestimentiModificheObj.Provider = this.Provider;
			base.Insert(index, PrioritaXInvestimentiModificheObj);
		}

		//CollectionGetById
		public PrioritaXInvestimentiModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public PrioritaXInvestimentiModificheCollection SubSelect(NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdValoreEqualThis, 
NullTypes.BoolNT SceltoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.DecimalNT ValorePunteggioEqualThis, 
NullTypes.DecimalNT ValoreEqualThis, NullTypes.DatetimeNT ValDataEqualThis, NullTypes.StringNT ValTestoEqualThis, 
NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis)
		{
			PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionTemp = new PrioritaXInvestimentiModificheCollection();
			foreach (PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheItem in this)
			{
				if (((IdPrioritaEqualThis == null) || ((PrioritaXInvestimentiModificheItem.IdPriorita != null) && (PrioritaXInvestimentiModificheItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PrioritaXInvestimentiModificheItem.IdInvestimento != null) && (PrioritaXInvestimentiModificheItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdValoreEqualThis == null) || ((PrioritaXInvestimentiModificheItem.IdValore != null) && (PrioritaXInvestimentiModificheItem.IdValore.Value == IdValoreEqualThis.Value))) && 
((SceltoEqualThis == null) || ((PrioritaXInvestimentiModificheItem.Scelto != null) && (PrioritaXInvestimentiModificheItem.Scelto.Value == SceltoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((PrioritaXInvestimentiModificheItem.Descrizione != null) && (PrioritaXInvestimentiModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ValorePunteggioEqualThis == null) || ((PrioritaXInvestimentiModificheItem.ValorePunteggio != null) && (PrioritaXInvestimentiModificheItem.ValorePunteggio.Value == ValorePunteggioEqualThis.Value))) && 
((ValoreEqualThis == null) || ((PrioritaXInvestimentiModificheItem.Valore != null) && (PrioritaXInvestimentiModificheItem.Valore.Value == ValoreEqualThis.Value))) && ((ValDataEqualThis == null) || ((PrioritaXInvestimentiModificheItem.ValData != null) && (PrioritaXInvestimentiModificheItem.ValData.Value == ValDataEqualThis.Value))) && ((ValTestoEqualThis == null) || ((PrioritaXInvestimentiModificheItem.ValTesto != null) && (PrioritaXInvestimentiModificheItem.ValTesto.Value == ValTestoEqualThis.Value))) && 
((IdEqualThis == null) || ((PrioritaXInvestimentiModificheItem.Id != null) && (PrioritaXInvestimentiModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((PrioritaXInvestimentiModificheItem.IdModifica != null) && (PrioritaXInvestimentiModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					PrioritaXInvestimentiModificheCollectionTemp.Add(PrioritaXInvestimentiModificheItem);
				}
			}
			return PrioritaXInvestimentiModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaXInvestimentiModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PrioritaXInvestimentiModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", PrioritaXInvestimentiModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaXInvestimentiModificheObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", PrioritaXInvestimentiModificheObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValore", PrioritaXInvestimentiModificheObj.IdValore);
			DbProvider.SetCmdParam(cmd,firstChar + "Scelto", PrioritaXInvestimentiModificheObj.Scelto);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", PrioritaXInvestimentiModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "ValorePunteggio", PrioritaXInvestimentiModificheObj.ValorePunteggio);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", PrioritaXInvestimentiModificheObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValData", PrioritaXInvestimentiModificheObj.ValData);
			DbProvider.SetCmdParam(cmd,firstChar + "ValTesto", PrioritaXInvestimentiModificheObj.ValTesto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", PrioritaXInvestimentiModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheInsert", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", "Descrizione", "ValorePunteggio", 
"Valore", "ValData", "ValTesto", 
"IdModifica"}, new string[] {"int", "int", "int", 
"bool", "string", "decimal", 
"decimal", "DateTime", "string", 
"int"},"");
				CompileIUCmd(false, insertCmd,PrioritaXInvestimentiModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PrioritaXInvestimentiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiModificheObj.IsDirty = false;
				PrioritaXInvestimentiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheUpdate", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", "Descrizione", "ValorePunteggio", 
"Valore", "ValData", "ValTesto", 
"Id", "IdModifica"}, new string[] {"int", "int", "int", 
"bool", "string", "decimal", 
"decimal", "DateTime", "string", 
"int", "int"},"");
				CompileIUCmd(true, updateCmd,PrioritaXInvestimentiModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiModificheObj.IsDirty = false;
				PrioritaXInvestimentiModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			switch (PrioritaXInvestimentiModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaXInvestimentiModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaXInvestimentiModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaXInvestimentiModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheUpdate", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", "Descrizione", "ValorePunteggio", 
"Valore", "ValData", "ValTesto", 
"Id", "IdModifica"}, new string[] {"int", "int", "int", 
"bool", "string", "decimal", 
"decimal", "DateTime", "string", 
"int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheInsert", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", "Descrizione", "ValorePunteggio", 
"Valore", "ValData", "ValTesto", 
"IdModifica"}, new string[] {"int", "int", "int", 
"bool", "string", "decimal", 
"decimal", "DateTime", "string", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaXInvestimentiModificheCollectionObj.Count; i++)
				{
					switch (PrioritaXInvestimentiModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaXInvestimentiModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PrioritaXInvestimentiModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaXInvestimentiModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaXInvestimentiModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)PrioritaXInvestimentiModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaXInvestimentiModificheCollectionObj.Count; i++)
				{
					if ((PrioritaXInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaXInvestimentiModificheCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiModificheCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaXInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaXInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXInvestimentiModificheCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj)
		{
			int returnValue = 0;
			if (PrioritaXInvestimentiModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaXInvestimentiModificheObj.Id);
			}
			PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaXInvestimentiModificheObj.IsDirty = false;
			PrioritaXInvestimentiModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PrioritaXInvestimentiModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", PrioritaXInvestimentiModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaXInvestimentiModificheCollectionObj.Count; i++)
				{
					if ((PrioritaXInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXInvestimentiModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXInvestimentiModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXInvestimentiModificheCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiModificheCollectionObj[i].IsPersistent = false;
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
		public static PrioritaXInvestimentiModifiche GetById(DbProvider db, int IdValue)
		{
			PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaXInvestimentiModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaXInvestimentiModificheObj = GetFromDatareader(db);
				PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiModificheObj.IsDirty = false;
				PrioritaXInvestimentiModificheObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaXInvestimentiModificheObj;
		}

		//getFromDatareader
		public static PrioritaXInvestimentiModifiche GetFromDatareader(DbProvider db)
		{
			PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj = new PrioritaXInvestimentiModifiche();
			PrioritaXInvestimentiModificheObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaXInvestimentiModificheObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			PrioritaXInvestimentiModificheObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			PrioritaXInvestimentiModificheObj.Scelto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCELTO"]);
			PrioritaXInvestimentiModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PrioritaXInvestimentiModificheObj.ValorePunteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_PUNTEGGIO"]);
			PrioritaXInvestimentiModificheObj.Valore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE"]);
			PrioritaXInvestimentiModificheObj.ValData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VAL_DATA"]);
			PrioritaXInvestimentiModificheObj.ValTesto = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_TESTO"]);
			PrioritaXInvestimentiModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			PrioritaXInvestimentiModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaXInvestimentiModificheObj.IsDirty = false;
			PrioritaXInvestimentiModificheObj.IsPersistent = true;
			return PrioritaXInvestimentiModificheObj;
		}

		//Find Select

		public static PrioritaXInvestimentiModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, 
SiarLibrary.NullTypes.BoolNT SceltoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DecimalNT ValorePunteggioEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValoreEqualThis, SiarLibrary.NullTypes.DatetimeNT ValDataEqualThis, SiarLibrary.NullTypes.StringNT ValTestoEqualThis, 
SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionObj = new PrioritaXInvestimentiModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaxinvestimentimodifichefindselect", new string[] {"IdPrioritaequalthis", "IdInvestimentoequalthis", "IdValoreequalthis", 
"Sceltoequalthis", "Descrizioneequalthis", "ValorePunteggioequalthis", 
"Valoreequalthis", "ValDataequalthis", "ValTestoequalthis", 
"Idequalthis", "IdModificaequalthis"}, new string[] {"int", "int", "int", 
"bool", "string", "decimal", 
"decimal", "DateTime", "string", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sceltoequalthis", SceltoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValorePunteggioequalthis", ValorePunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValDataequalthis", ValDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValTestoequalthis", ValTestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXInvestimentiModificheObj = GetFromDatareader(db);
				PrioritaXInvestimentiModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiModificheObj.IsDirty = false;
				PrioritaXInvestimentiModificheObj.IsPersistent = true;
				PrioritaXInvestimentiModificheCollectionObj.Add(PrioritaXInvestimentiModificheObj);
			}
			db.Close();
			return PrioritaXInvestimentiModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaXInvestimentiModificheCollectionProvider:IPrioritaXInvestimentiModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXInvestimentiModificheCollectionProvider : IPrioritaXInvestimentiModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaXInvestimentiModifiche
		protected PrioritaXInvestimentiModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaXInvestimentiModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaXInvestimentiModificheCollection(this);
		}

		//Costruttore3: ha in input prioritaxinvestimentimodificheCollectionObj - non popola la collection
		public PrioritaXInvestimentiModificheCollectionProvider(PrioritaXInvestimentiModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaXInvestimentiModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaXInvestimentiModificheCollection(this);
		}

		//Get e Set
		public PrioritaXInvestimentiModificheCollection CollectionObj
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
		public int SaveCollection(PrioritaXInvestimentiModificheCollection collectionObj)
		{
			return PrioritaXInvestimentiModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaXInvestimentiModifiche prioritaxinvestimentimodificheObj)
		{
			return PrioritaXInvestimentiModificheDAL.Save(_dbProviderObj, prioritaxinvestimentimodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaXInvestimentiModificheCollection collectionObj)
		{
			return PrioritaXInvestimentiModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaXInvestimentiModifiche prioritaxinvestimentimodificheObj)
		{
			return PrioritaXInvestimentiModificheDAL.Delete(_dbProviderObj, prioritaxinvestimentimodificheObj);
		}

		//getById
		public PrioritaXInvestimentiModifiche GetById(IntNT IdValue)
		{
			PrioritaXInvestimentiModifiche PrioritaXInvestimentiModificheTemp = PrioritaXInvestimentiModificheDAL.GetById(_dbProviderObj, IdValue);
			if (PrioritaXInvestimentiModificheTemp!=null) PrioritaXInvestimentiModificheTemp.Provider = this;
			return PrioritaXInvestimentiModificheTemp;
		}

		//Select: popola la collection
		public PrioritaXInvestimentiModificheCollection Select(IntNT IdprioritaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdvaloreEqualThis, 
BoolNT SceltoEqualThis, StringNT DescrizioneEqualThis, DecimalNT ValorepunteggioEqualThis, 
DecimalNT ValoreEqualThis, DatetimeNT ValdataEqualThis, StringNT ValtestoEqualThis, 
IntNT IdEqualThis, IntNT IdmodificaEqualThis)
		{
			PrioritaXInvestimentiModificheCollection PrioritaXInvestimentiModificheCollectionTemp = PrioritaXInvestimentiModificheDAL.Select(_dbProviderObj, IdprioritaEqualThis, IdinvestimentoEqualThis, IdvaloreEqualThis, 
SceltoEqualThis, DescrizioneEqualThis, ValorepunteggioEqualThis, 
ValoreEqualThis, ValdataEqualThis, ValtestoEqualThis, 
IdEqualThis, IdmodificaEqualThis);
			PrioritaXInvestimentiModificheCollectionTemp.Provider = this;
			return PrioritaXInvestimentiModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_X_INVESTIMENTI_MODIFICHE>
  <ViewName>
  </ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_X_INVESTIMENTI_MODIFICHE>
*/
