using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PrioritaXInvestimenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPrioritaXInvestimentiProvider
	{
		int Save(PrioritaXInvestimenti PrioritaXInvestimentiObj);
		int SaveCollection(PrioritaXInvestimentiCollection collectionObj);
		int Delete(PrioritaXInvestimenti PrioritaXInvestimentiObj);
		int DeleteCollection(PrioritaXInvestimentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PrioritaXInvestimenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PrioritaXInvestimenti: BaseObject
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
		[NonSerialized] private IPrioritaXInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXInvestimentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PrioritaXInvestimenti()
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
	/// Summary description for PrioritaXInvestimentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaXInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaXInvestimenti) info.GetValue(i.ToString(),typeof(PrioritaXInvestimenti)));
			}
		}

		//Costruttore
		public PrioritaXInvestimentiCollection()
		{
			this.ItemType = typeof(PrioritaXInvestimenti);
		}

		//Costruttore con provider
		public PrioritaXInvestimentiCollection(IPrioritaXInvestimentiProvider providerObj)
		{
			this.ItemType = typeof(PrioritaXInvestimenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaXInvestimenti this[int index]
		{
			get { return (PrioritaXInvestimenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaXInvestimentiCollection GetChanges()
		{
			return (PrioritaXInvestimentiCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaXInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaXInvestimentiProvider Provider
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
		public int Add(PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			if (PrioritaXInvestimentiObj.Provider == null) PrioritaXInvestimentiObj.Provider = this.Provider;
			return base.Add(PrioritaXInvestimentiObj);
		}

		//AddCollection
		public void AddCollection(PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionObj)
		{
			foreach (PrioritaXInvestimenti PrioritaXInvestimentiObj in PrioritaXInvestimentiCollectionObj)
				this.Add(PrioritaXInvestimentiObj);
		}

		//Insert
		public void Insert(int index, PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			if (PrioritaXInvestimentiObj.Provider == null) PrioritaXInvestimentiObj.Provider = this.Provider;
			base.Insert(index, PrioritaXInvestimentiObj);
		}

		//CollectionGetById
		public PrioritaXInvestimenti CollectionGetById(NullTypes.IntNT IdPrioritaValue, NullTypes.IntNT IdInvestimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPriorita == IdPrioritaValue) && (this[i].IdInvestimento == IdInvestimentoValue))
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
		public PrioritaXInvestimentiCollection SubSelect(NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdValoreEqualThis, 
NullTypes.BoolNT SceltoEqualThis, NullTypes.DecimalNT ValoreEqualThis, NullTypes.DatetimeNT ValDataEqualThis, 
NullTypes.StringNT ValTestoEqualThis)
		{
			PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionTemp = new PrioritaXInvestimentiCollection();
			foreach (PrioritaXInvestimenti PrioritaXInvestimentiItem in this)
			{
				if (((IdPrioritaEqualThis == null) || ((PrioritaXInvestimentiItem.IdPriorita != null) && (PrioritaXInvestimentiItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PrioritaXInvestimentiItem.IdInvestimento != null) && (PrioritaXInvestimentiItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdValoreEqualThis == null) || ((PrioritaXInvestimentiItem.IdValore != null) && (PrioritaXInvestimentiItem.IdValore.Value == IdValoreEqualThis.Value))) && 
((SceltoEqualThis == null) || ((PrioritaXInvestimentiItem.Scelto != null) && (PrioritaXInvestimentiItem.Scelto.Value == SceltoEqualThis.Value))) && ((ValoreEqualThis == null) || ((PrioritaXInvestimentiItem.Valore != null) && (PrioritaXInvestimentiItem.Valore.Value == ValoreEqualThis.Value))) && ((ValDataEqualThis == null) || ((PrioritaXInvestimentiItem.ValData != null) && (PrioritaXInvestimentiItem.ValData.Value == ValDataEqualThis.Value))) && 
((ValTestoEqualThis == null) || ((PrioritaXInvestimentiItem.ValTesto != null) && (PrioritaXInvestimentiItem.ValTesto.Value == ValTestoEqualThis.Value))))
				{
					PrioritaXInvestimentiCollectionTemp.Add(PrioritaXInvestimentiItem);
				}
			}
			return PrioritaXInvestimentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PrioritaXInvestimentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PrioritaXInvestimentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PrioritaXInvestimenti PrioritaXInvestimentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPriorita", PrioritaXInvestimentiObj.IdPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdInvestimento", PrioritaXInvestimentiObj.IdInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "IdValore", PrioritaXInvestimentiObj.IdValore);
			DbProvider.SetCmdParam(cmd,firstChar + "Scelto", PrioritaXInvestimentiObj.Scelto);
			DbProvider.SetCmdParam(cmd,firstChar + "Valore", PrioritaXInvestimentiObj.Valore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValData", PrioritaXInvestimentiObj.ValData);
			DbProvider.SetCmdParam(cmd,firstChar + "ValTesto", PrioritaXInvestimentiObj.ValTesto);
		}
		//Insert
		private static int Insert(DbProvider db, PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXInvestimentiInsert", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", 
"Valore", "ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"bool", 
"decimal", "DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,PrioritaXInvestimentiObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiObj.IsDirty = false;
				PrioritaXInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXInvestimentiUpdate", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", 
"Valore", "ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"bool", 
"decimal", "DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,PrioritaXInvestimentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiObj.IsDirty = false;
				PrioritaXInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			switch (PrioritaXInvestimentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PrioritaXInvestimentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PrioritaXInvestimentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PrioritaXInvestimentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPrioritaXInvestimentiUpdate", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", 
"Valore", "ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"bool", 
"decimal", "DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPrioritaXInvestimentiInsert", new string[] {"IdPriorita", "IdInvestimento", "IdValore", 
"Scelto", 
"Valore", "ValData", "ValTesto"}, new string[] {"int", "int", "int", 
"bool", 
"decimal", "DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiDelete", new string[] {"IdPriorita", "IdInvestimento"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXInvestimentiCollectionObj.Count; i++)
				{
					switch (PrioritaXInvestimentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PrioritaXInvestimentiCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PrioritaXInvestimentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PrioritaXInvestimentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)PrioritaXInvestimentiCollectionObj[i].IdPriorita);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)PrioritaXInvestimentiCollectionObj[i].IdInvestimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PrioritaXInvestimentiCollectionObj.Count; i++)
				{
					if ((PrioritaXInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PrioritaXInvestimentiCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiCollectionObj[i].IsPersistent = true;
					}
					if ((PrioritaXInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PrioritaXInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXInvestimentiCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PrioritaXInvestimenti PrioritaXInvestimentiObj)
		{
			int returnValue = 0;
			if (PrioritaXInvestimentiObj.IsPersistent) 
			{
				returnValue = Delete(db, PrioritaXInvestimentiObj.IdPriorita, PrioritaXInvestimentiObj.IdInvestimento);
			}
			PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PrioritaXInvestimentiObj.IsDirty = false;
			PrioritaXInvestimentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPrioritaValue, int IdInvestimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiDelete", new string[] {"IdPriorita", "IdInvestimento"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)IdInvestimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPrioritaXInvestimentiDelete", new string[] {"IdPriorita", "IdInvestimento"}, new string[] {"int", "int"},"");
				for (int i = 0; i < PrioritaXInvestimentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPriorita", PrioritaXInvestimentiCollectionObj[i].IdPriorita);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdInvestimento", PrioritaXInvestimentiCollectionObj[i].IdInvestimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PrioritaXInvestimentiCollectionObj.Count; i++)
				{
					if ((PrioritaXInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PrioritaXInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PrioritaXInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PrioritaXInvestimentiCollectionObj[i].IsDirty = false;
						PrioritaXInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static PrioritaXInvestimenti GetById(DbProvider db, int IdPrioritaValue, int IdInvestimentoValue)
		{
			PrioritaXInvestimenti PrioritaXInvestimentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPrioritaXInvestimentiGetById", new string[] {"IdPriorita", "IdInvestimento"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPriorita", (SiarLibrary.NullTypes.IntNT)IdPrioritaValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)IdInvestimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PrioritaXInvestimentiObj = GetFromDatareader(db);
				PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiObj.IsDirty = false;
				PrioritaXInvestimentiObj.IsPersistent = true;
			}
			db.Close();
			return PrioritaXInvestimentiObj;
		}

		//getFromDatareader
		public static PrioritaXInvestimenti GetFromDatareader(DbProvider db)
		{
			PrioritaXInvestimenti PrioritaXInvestimentiObj = new PrioritaXInvestimenti();
			PrioritaXInvestimentiObj.IdPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA"]);
			PrioritaXInvestimentiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
			PrioritaXInvestimentiObj.IdValore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VALORE"]);
			PrioritaXInvestimentiObj.Scelto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCELTO"]);
			PrioritaXInvestimentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PrioritaXInvestimentiObj.ValorePunteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_PUNTEGGIO"]);
			PrioritaXInvestimentiObj.Valore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE"]);
			PrioritaXInvestimentiObj.ValData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["VAL_DATA"]);
			PrioritaXInvestimentiObj.ValTesto = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_TESTO"]);
			PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PrioritaXInvestimentiObj.IsDirty = false;
			PrioritaXInvestimentiObj.IsPersistent = true;
			return PrioritaXInvestimentiObj;
		}

		//Find Select

		public static PrioritaXInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, 
SiarLibrary.NullTypes.BoolNT SceltoEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreEqualThis, SiarLibrary.NullTypes.DatetimeNT ValDataEqualThis, 
SiarLibrary.NullTypes.StringNT ValTestoEqualThis)

		{

			PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionObj = new PrioritaXInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaxinvestimentifindselect", new string[] {"IdPrioritaequalthis", "IdInvestimentoequalthis", "IdValoreequalthis", 
"Sceltoequalthis", "Valoreequalthis", "ValDataequalthis", 
"ValTestoequalthis"}, new string[] {"int", "int", "int", 
"bool", "decimal", "DateTime", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sceltoequalthis", SceltoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Valoreequalthis", ValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValDataequalthis", ValDataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValTestoequalthis", ValTestoEqualThis);
			PrioritaXInvestimenti PrioritaXInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXInvestimentiObj = GetFromDatareader(db);
				PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiObj.IsDirty = false;
				PrioritaXInvestimentiObj.IsPersistent = true;
				PrioritaXInvestimentiCollectionObj.Add(PrioritaXInvestimentiObj);
			}
			db.Close();
			return PrioritaXInvestimentiCollectionObj;
		}

		//Find Find

		public static PrioritaXInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdValoreEqualThis, 
SiarLibrary.NullTypes.BoolNT SceltoEqualThis)

		{

			PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionObj = new PrioritaXInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zprioritaxinvestimentifindfind", new string[] {"IdPrioritaequalthis", "IdInvestimentoequalthis", "IdValoreequalthis", 
"Sceltoequalthis"}, new string[] {"int", "int", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPrioritaequalthis", IdPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdValoreequalthis", IdValoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sceltoequalthis", SceltoEqualThis);
			PrioritaXInvestimenti PrioritaXInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PrioritaXInvestimentiObj = GetFromDatareader(db);
				PrioritaXInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PrioritaXInvestimentiObj.IsDirty = false;
				PrioritaXInvestimentiObj.IsPersistent = true;
				PrioritaXInvestimentiCollectionObj.Add(PrioritaXInvestimentiObj);
			}
			db.Close();
			return PrioritaXInvestimentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaXInvestimentiCollectionProvider:IPrioritaXInvestimentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PrioritaXInvestimentiCollectionProvider : IPrioritaXInvestimentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaXInvestimenti
		protected PrioritaXInvestimentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaXInvestimentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaXInvestimentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaXInvestimentiCollectionProvider(IntNT IdprioritaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdvaloreEqualThis, 
BoolNT SceltoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprioritaEqualThis, IdinvestimentoEqualThis, IdvaloreEqualThis, 
SceltoEqualThis);
		}

		//Costruttore3: ha in input prioritaxinvestimentiCollectionObj - non popola la collection
		public PrioritaXInvestimentiCollectionProvider(PrioritaXInvestimentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaXInvestimentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaXInvestimentiCollection(this);
		}

		//Get e Set
		public PrioritaXInvestimentiCollection CollectionObj
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
		public int SaveCollection(PrioritaXInvestimentiCollection collectionObj)
		{
			return PrioritaXInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaXInvestimenti prioritaxinvestimentiObj)
		{
			return PrioritaXInvestimentiDAL.Save(_dbProviderObj, prioritaxinvestimentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaXInvestimentiCollection collectionObj)
		{
			return PrioritaXInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaXInvestimenti prioritaxinvestimentiObj)
		{
			return PrioritaXInvestimentiDAL.Delete(_dbProviderObj, prioritaxinvestimentiObj);
		}

		//getById
		public PrioritaXInvestimenti GetById(IntNT IdPrioritaValue, IntNT IdInvestimentoValue)
		{
			PrioritaXInvestimenti PrioritaXInvestimentiTemp = PrioritaXInvestimentiDAL.GetById(_dbProviderObj, IdPrioritaValue, IdInvestimentoValue);
			if (PrioritaXInvestimentiTemp!=null) PrioritaXInvestimentiTemp.Provider = this;
			return PrioritaXInvestimentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaXInvestimentiCollection Select(IntNT IdprioritaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdvaloreEqualThis, 
BoolNT SceltoEqualThis, DecimalNT ValoreEqualThis, DatetimeNT ValdataEqualThis, 
StringNT ValtestoEqualThis)
		{
			PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionTemp = PrioritaXInvestimentiDAL.Select(_dbProviderObj, IdprioritaEqualThis, IdinvestimentoEqualThis, IdvaloreEqualThis, 
SceltoEqualThis, ValoreEqualThis, ValdataEqualThis, 
ValtestoEqualThis);
			PrioritaXInvestimentiCollectionTemp.Provider = this;
			return PrioritaXInvestimentiCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaXInvestimentiCollection Find(IntNT IdprioritaEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdvaloreEqualThis, 
BoolNT SceltoEqualThis)
		{
			PrioritaXInvestimentiCollection PrioritaXInvestimentiCollectionTemp = PrioritaXInvestimentiDAL.Find(_dbProviderObj, IdprioritaEqualThis, IdinvestimentoEqualThis, IdvaloreEqualThis, 
SceltoEqualThis);
			PrioritaXInvestimentiCollectionTemp.Provider = this;
			return PrioritaXInvestimentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_X_INVESTIMENTI>
  <ViewName>vPRIORITA_X_INVESTIMENTI</ViewName>
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
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_VALORE>Equal</ID_VALORE>
      <SCELTO>Equal</SCELTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_X_INVESTIMENTI>
*/
