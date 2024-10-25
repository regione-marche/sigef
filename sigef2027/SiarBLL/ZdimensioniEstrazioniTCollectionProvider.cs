using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZdimensioniEstrazioniT
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZdimensioniEstrazioniTProvider
	{
		int Save(ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj);
		int SaveCollection(ZdimensioniEstrazioniTCollection collectionObj);
		int Delete(ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj);
		int DeleteCollection(ZdimensioniEstrazioniTCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZdimensioniEstrazioniT
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZdimensioniEstrazioniT: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdEstrazione;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.StringNT _CodPsr;
		private NullTypes.BoolNT _Bloccato;
		private NullTypes.StringNT _TipoIndicatori;
		private NullTypes.IntNT _Anno;
		[NonSerialized] private IZdimensioniEstrazioniTProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniEstrazioniTProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZdimensioniEstrazioniT()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ESTRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdEstrazione
		{
			get { return _IdEstrazione; }
			set {
				if (IdEstrazione != value)
				{
					_IdEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
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
		/// Corrisponde al campo:BLOCCATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Bloccato
		{
			get { return _Bloccato; }
			set {
				if (Bloccato != value)
				{
					_Bloccato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_INDICATORI
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT TipoIndicatori
		{
			get { return _TipoIndicatori; }
			set {
				if (TipoIndicatori != value)
				{
					_TipoIndicatori = value;
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
	/// Summary description for ZdimensioniEstrazioniTCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniEstrazioniTCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZdimensioniEstrazioniTCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZdimensioniEstrazioniT) info.GetValue(i.ToString(),typeof(ZdimensioniEstrazioniT)));
			}
		}

		//Costruttore
		public ZdimensioniEstrazioniTCollection()
		{
			this.ItemType = typeof(ZdimensioniEstrazioniT);
		}

		//Costruttore con provider
		public ZdimensioniEstrazioniTCollection(IZdimensioniEstrazioniTProvider providerObj)
		{
			this.ItemType = typeof(ZdimensioniEstrazioniT);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZdimensioniEstrazioniT this[int index]
		{
			get { return (ZdimensioniEstrazioniT)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZdimensioniEstrazioniTCollection GetChanges()
		{
			return (ZdimensioniEstrazioniTCollection) base.GetChanges();
		}

		[NonSerialized] private IZdimensioniEstrazioniTProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniEstrazioniTProvider Provider
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
		public int Add(ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			if (ZdimensioniEstrazioniTObj.Provider == null) ZdimensioniEstrazioniTObj.Provider = this.Provider;
			return base.Add(ZdimensioniEstrazioniTObj);
		}

		//AddCollection
		public void AddCollection(ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionObj)
		{
			foreach (ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj in ZdimensioniEstrazioniTCollectionObj)
				this.Add(ZdimensioniEstrazioniTObj);
		}

		//Insert
		public void Insert(int index, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			if (ZdimensioniEstrazioniTObj.Provider == null) ZdimensioniEstrazioniTObj.Provider = this.Provider;
			base.Insert(index, ZdimensioniEstrazioniTObj);
		}

		//CollectionGetById
		public ZdimensioniEstrazioniT CollectionGetById(NullTypes.IntNT IdEstrazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdEstrazione == IdEstrazioneValue))
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
		public ZdimensioniEstrazioniTCollection SubSelect(NullTypes.IntNT IdEstrazioneEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, NullTypes.DatetimeNT DataFineEqualThis, 
NullTypes.StringNT CodPsrEqualThis, NullTypes.BoolNT BloccatoEqualThis, NullTypes.StringNT TipoIndicatoriEqualThis)
		{
			ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionTemp = new ZdimensioniEstrazioniTCollection();
			foreach (ZdimensioniEstrazioniT ZdimensioniEstrazioniTItem in this)
			{
				if (((IdEstrazioneEqualThis == null) || ((ZdimensioniEstrazioniTItem.IdEstrazione != null) && (ZdimensioniEstrazioniTItem.IdEstrazione.Value == IdEstrazioneEqualThis.Value))) && ((DataInizioEqualThis == null) || ((ZdimensioniEstrazioniTItem.DataInizio != null) && (ZdimensioniEstrazioniTItem.DataInizio.Value == DataInizioEqualThis.Value))) && ((DataFineEqualThis == null) || ((ZdimensioniEstrazioniTItem.DataFine != null) && (ZdimensioniEstrazioniTItem.DataFine.Value == DataFineEqualThis.Value))) && 
((CodPsrEqualThis == null) || ((ZdimensioniEstrazioniTItem.CodPsr != null) && (ZdimensioniEstrazioniTItem.CodPsr.Value == CodPsrEqualThis.Value))) && ((BloccatoEqualThis == null) || ((ZdimensioniEstrazioniTItem.Bloccato != null) && (ZdimensioniEstrazioniTItem.Bloccato.Value == BloccatoEqualThis.Value))) && ((TipoIndicatoriEqualThis == null) || ((ZdimensioniEstrazioniTItem.TipoIndicatori != null) && (ZdimensioniEstrazioniTItem.TipoIndicatori.Value == TipoIndicatoriEqualThis.Value))))
				{
					ZdimensioniEstrazioniTCollectionTemp.Add(ZdimensioniEstrazioniTItem);
				}
			}
			return ZdimensioniEstrazioniTCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZdimensioniEstrazioniTDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZdimensioniEstrazioniTDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdEstrazione", ZdimensioniEstrazioniTObj.IdEstrazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", ZdimensioniEstrazioniTObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", ZdimensioniEstrazioniTObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "CodPsr", ZdimensioniEstrazioniTObj.CodPsr);
			DbProvider.SetCmdParam(cmd,firstChar + "Bloccato", ZdimensioniEstrazioniTObj.Bloccato);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoIndicatori", ZdimensioniEstrazioniTObj.TipoIndicatori);
		}
		//Insert
		private static int Insert(DbProvider db, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniEstrazioniTInsert", new string[] {"DataInizio", "DataFine", 
"CodPsr", "Bloccato", "TipoIndicatori", }, new string[] {"DateTime", "DateTime", 
"string", "bool", "string", },"");
				CompileIUCmd(false, insertCmd,ZdimensioniEstrazioniTObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZdimensioniEstrazioniTObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
				}
				ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniTObj.IsDirty = false;
				ZdimensioniEstrazioniTObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniEstrazioniTUpdate", new string[] {"IdEstrazione", "DataInizio", "DataFine", 
"CodPsr", "Bloccato", "TipoIndicatori", }, new string[] {"int", "DateTime", "DateTime", 
"string", "bool", "string", },"");
				CompileIUCmd(true, updateCmd,ZdimensioniEstrazioniTObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniTObj.IsDirty = false;
				ZdimensioniEstrazioniTObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			switch (ZdimensioniEstrazioniTObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZdimensioniEstrazioniTObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZdimensioniEstrazioniTObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZdimensioniEstrazioniTObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniEstrazioniTUpdate", new string[] {"IdEstrazione", "DataInizio", "DataFine", 
"CodPsr", "Bloccato", "TipoIndicatori", }, new string[] {"int", "DateTime", "DateTime", 
"string", "bool", "string", },"");
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniEstrazioniTInsert", new string[] {"DataInizio", "DataFine", 
"CodPsr", "Bloccato", "TipoIndicatori", }, new string[] {"DateTime", "DateTime", 
"string", "bool", "string", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniTDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniEstrazioniTCollectionObj.Count; i++)
				{
					switch (ZdimensioniEstrazioniTCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZdimensioniEstrazioniTCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZdimensioniEstrazioniTCollectionObj[i].IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZdimensioniEstrazioniTCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZdimensioniEstrazioniTCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)ZdimensioniEstrazioniTCollectionObj[i].IdEstrazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniEstrazioniTCollectionObj.Count; i++)
				{
					if ((ZdimensioniEstrazioniTCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniTCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniEstrazioniTCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZdimensioniEstrazioniTCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniTCollectionObj[i].IsPersistent = true;
					}
					if ((ZdimensioniEstrazioniTCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZdimensioniEstrazioniTCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniEstrazioniTCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniTCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj)
		{
			int returnValue = 0;
			if (ZdimensioniEstrazioniTObj.IsPersistent) 
			{
				returnValue = Delete(db, ZdimensioniEstrazioniTObj.IdEstrazione);
			}
			ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZdimensioniEstrazioniTObj.IsDirty = false;
			ZdimensioniEstrazioniTObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdEstrazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniTDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)IdEstrazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniTDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniEstrazioniTCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", ZdimensioniEstrazioniTCollectionObj[i].IdEstrazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniEstrazioniTCollectionObj.Count; i++)
				{
					if ((ZdimensioniEstrazioniTCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniTCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniEstrazioniTCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniEstrazioniTCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniTCollectionObj[i].IsPersistent = false;
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
		public static ZdimensioniEstrazioniT GetById(DbProvider db, int IdEstrazioneValue)
		{
			ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZdimensioniEstrazioniTGetById", new string[] {"IdEstrazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)IdEstrazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZdimensioniEstrazioniTObj = GetFromDatareader(db);
				ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniTObj.IsDirty = false;
				ZdimensioniEstrazioniTObj.IsPersistent = true;
			}
			db.Close();
			return ZdimensioniEstrazioniTObj;
		}

		//getFromDatareader
		public static ZdimensioniEstrazioniT GetFromDatareader(DbProvider db)
		{
			ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj = new ZdimensioniEstrazioniT();
			ZdimensioniEstrazioniTObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
			ZdimensioniEstrazioniTObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			ZdimensioniEstrazioniTObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			ZdimensioniEstrazioniTObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			ZdimensioniEstrazioniTObj.Bloccato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["BLOCCATO"]);
			ZdimensioniEstrazioniTObj.TipoIndicatori = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_INDICATORI"]);
			ZdimensioniEstrazioniTObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZdimensioniEstrazioniTObj.IsDirty = false;
			ZdimensioniEstrazioniTObj.IsPersistent = true;
			return ZdimensioniEstrazioniTObj;
		}

		//Find Select

		public static ZdimensioniEstrazioniTCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEstrazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, 
SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.BoolNT BloccatoEqualThis, SiarLibrary.NullTypes.StringNT TipoIndicatoriEqualThis)

		{

			ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionObj = new ZdimensioniEstrazioniTCollection();

			IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazionitfindselect", new string[] {"IdEstrazioneequalthis", "DataInizioequalthis", "DataFineequalthis", 
"CodPsrequalthis", "Bloccatoequalthis", "TipoIndicatoriequalthis"}, new string[] {"int", "DateTime", "DateTime", 
"string", "bool", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneequalthis", IdEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Bloccatoequalthis", BloccatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoIndicatoriequalthis", TipoIndicatoriEqualThis);
			ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZdimensioniEstrazioniTObj = GetFromDatareader(db);
				ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniTObj.IsDirty = false;
				ZdimensioniEstrazioniTObj.IsPersistent = true;
				ZdimensioniEstrazioniTCollectionObj.Add(ZdimensioniEstrazioniTObj);
			}
			db.Close();
			return ZdimensioniEstrazioniTCollectionObj;
		}

		//Find Find

		public static ZdimensioniEstrazioniTCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.StringNT TipoIndicatoriEqualThis)

		{

			ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionObj = new ZdimensioniEstrazioniTCollection();

			IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazionitfindfind", new string[] {"CodPsrequalthis", "Annoequalthis", "TipoIndicatoriequalthis"}, new string[] {"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoIndicatoriequalthis", TipoIndicatoriEqualThis);
			ZdimensioniEstrazioniT ZdimensioniEstrazioniTObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZdimensioniEstrazioniTObj = GetFromDatareader(db);
				ZdimensioniEstrazioniTObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniTObj.IsDirty = false;
				ZdimensioniEstrazioniTObj.IsPersistent = true;
				ZdimensioniEstrazioniTCollectionObj.Add(ZdimensioniEstrazioniTObj);
			}
			db.Close();
			return ZdimensioniEstrazioniTCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZdimensioniEstrazioniTCollectionProvider:IZdimensioniEstrazioniTProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniEstrazioniTCollectionProvider : IZdimensioniEstrazioniTProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZdimensioniEstrazioniT
		protected ZdimensioniEstrazioniTCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZdimensioniEstrazioniTCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZdimensioniEstrazioniTCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZdimensioniEstrazioniTCollectionProvider(StringNT CodpsrEqualThis, IntNT AnnoEqualThis, StringNT TipoindicatoriEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodpsrEqualThis, AnnoEqualThis, TipoindicatoriEqualThis);
		}

		//Costruttore3: ha in input zdimensioniestrazionitCollectionObj - non popola la collection
		public ZdimensioniEstrazioniTCollectionProvider(ZdimensioniEstrazioniTCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZdimensioniEstrazioniTCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZdimensioniEstrazioniTCollection(this);
		}

		//Get e Set
		public ZdimensioniEstrazioniTCollection CollectionObj
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
		public int SaveCollection(ZdimensioniEstrazioniTCollection collectionObj)
		{
			return ZdimensioniEstrazioniTDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZdimensioniEstrazioniT zdimensioniestrazionitObj)
		{
			return ZdimensioniEstrazioniTDAL.Save(_dbProviderObj, zdimensioniestrazionitObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZdimensioniEstrazioniTCollection collectionObj)
		{
			return ZdimensioniEstrazioniTDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZdimensioniEstrazioniT zdimensioniestrazionitObj)
		{
			return ZdimensioniEstrazioniTDAL.Delete(_dbProviderObj, zdimensioniestrazionitObj);
		}

		//getById
		public ZdimensioniEstrazioniT GetById(IntNT IdEstrazioneValue)
		{
			ZdimensioniEstrazioniT ZdimensioniEstrazioniTTemp = ZdimensioniEstrazioniTDAL.GetById(_dbProviderObj, IdEstrazioneValue);
			if (ZdimensioniEstrazioniTTemp!=null) ZdimensioniEstrazioniTTemp.Provider = this;
			return ZdimensioniEstrazioniTTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZdimensioniEstrazioniTCollection Select(IntNT IdestrazioneEqualThis, DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, 
StringNT CodpsrEqualThis, BoolNT BloccatoEqualThis, StringNT TipoindicatoriEqualThis)
		{
			ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionTemp = ZdimensioniEstrazioniTDAL.Select(_dbProviderObj, IdestrazioneEqualThis, DatainizioEqualThis, DatafineEqualThis, 
CodpsrEqualThis, BloccatoEqualThis, TipoindicatoriEqualThis);
			ZdimensioniEstrazioniTCollectionTemp.Provider = this;
			return ZdimensioniEstrazioniTCollectionTemp;
		}

		//Find: popola la collection
		public ZdimensioniEstrazioniTCollection Find(StringNT CodpsrEqualThis, IntNT AnnoEqualThis, StringNT TipoindicatoriEqualThis)
		{
			ZdimensioniEstrazioniTCollection ZdimensioniEstrazioniTCollectionTemp = ZdimensioniEstrazioniTDAL.Find(_dbProviderObj, CodpsrEqualThis, AnnoEqualThis, TipoindicatoriEqualThis);
			ZdimensioniEstrazioniTCollectionTemp.Provider = this;
			return ZdimensioniEstrazioniTCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zDIMENSIONI_ESTRAZIONI_T>
  <ViewName>vzDIMENSIONI_ESTRAZIONI_T</ViewName>
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
  <Finds>
    <Find OrderBy="ORDER BY ">
      <COD_PSR>Equal</COD_PSR>
      <ANNO>Equal</ANNO>
      <TIPO_INDICATORI>Equal</TIPO_INDICATORI>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zDIMENSIONI_ESTRAZIONI_T>
*/
