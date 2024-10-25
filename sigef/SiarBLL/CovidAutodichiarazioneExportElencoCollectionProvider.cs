using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CovidAutodichiarazioneExportElenco
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICovidAutodichiarazioneExportElencoProvider
	{
		int Save(CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj);
		int SaveCollection(CovidAutodichiarazioneExportElencoCollection collectionObj);
		int Delete(CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj);
		int DeleteCollection(CovidAutodichiarazioneExportElencoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CovidAutodichiarazioneExportElenco
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CovidAutodichiarazioneExportElenco: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdEstrazione;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _DescrizioneBando;
		private NullTypes.BoolNT _ImpresaIndividuale;
		private NullTypes.DatetimeNT _DataEstrazione;
		private NullTypes.IntNT _Progressivo;
		private NullTypes.IntNT _IdFile;
		[NonSerialized] private ICovidAutodichiarazioneExportElencoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidAutodichiarazioneExportElencoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CovidAutodichiarazioneExportElenco()
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
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_BANDO
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT DescrizioneBando
		{
			get { return _DescrizioneBando; }
			set {
				if (DescrizioneBando != value)
				{
					_DescrizioneBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPRESA_INDIVIDUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ImpresaIndividuale
		{
			get { return _ImpresaIndividuale; }
			set {
				if (ImpresaIndividuale != value)
				{
					_ImpresaIndividuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataEstrazione
		{
			get { return _DataEstrazione; }
			set {
				if (DataEstrazione != value)
				{
					_DataEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGRESSIVO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Progressivo
		{
			get { return _Progressivo; }
			set {
				if (Progressivo != value)
				{
					_Progressivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set {
				if (IdFile != value)
				{
					_IdFile = value;
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
	/// Summary description for CovidAutodichiarazioneExportElencoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneExportElencoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CovidAutodichiarazioneExportElencoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CovidAutodichiarazioneExportElenco) info.GetValue(i.ToString(),typeof(CovidAutodichiarazioneExportElenco)));
			}
		}

		//Costruttore
		public CovidAutodichiarazioneExportElencoCollection()
		{
			this.ItemType = typeof(CovidAutodichiarazioneExportElenco);
		}

		//Costruttore con provider
		public CovidAutodichiarazioneExportElencoCollection(ICovidAutodichiarazioneExportElencoProvider providerObj)
		{
			this.ItemType = typeof(CovidAutodichiarazioneExportElenco);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CovidAutodichiarazioneExportElenco this[int index]
		{
			get { return (CovidAutodichiarazioneExportElenco)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CovidAutodichiarazioneExportElencoCollection GetChanges()
		{
			return (CovidAutodichiarazioneExportElencoCollection) base.GetChanges();
		}

		[NonSerialized] private ICovidAutodichiarazioneExportElencoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICovidAutodichiarazioneExportElencoProvider Provider
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
		public int Add(CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			if (CovidAutodichiarazioneExportElencoObj.Provider == null) CovidAutodichiarazioneExportElencoObj.Provider = this.Provider;
			return base.Add(CovidAutodichiarazioneExportElencoObj);
		}

		//AddCollection
		public void AddCollection(CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionObj)
		{
			foreach (CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj in CovidAutodichiarazioneExportElencoCollectionObj)
				this.Add(CovidAutodichiarazioneExportElencoObj);
		}

		//Insert
		public void Insert(int index, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			if (CovidAutodichiarazioneExportElencoObj.Provider == null) CovidAutodichiarazioneExportElencoObj.Provider = this.Provider;
			base.Insert(index, CovidAutodichiarazioneExportElencoObj);
		}

		//CollectionGetById
		public CovidAutodichiarazioneExportElenco CollectionGetById(NullTypes.IntNT IdEstrazioneValue)
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
		public CovidAutodichiarazioneExportElencoCollection SubSelect(NullTypes.IntNT IdEstrazioneEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, 
NullTypes.BoolNT ImpresaIndividualeEqualThis, NullTypes.DatetimeNT DataEstrazioneEqualThis, NullTypes.IntNT ProgressivoEqualThis, 
NullTypes.IntNT IdFileEqualThis)
		{
			CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionTemp = new CovidAutodichiarazioneExportElencoCollection();
			foreach (CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoItem in this)
			{
				if (((IdEstrazioneEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.IdEstrazione != null) && (CovidAutodichiarazioneExportElencoItem.IdEstrazione.Value == IdEstrazioneEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.IdBando != null) && (CovidAutodichiarazioneExportElencoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.DescrizioneBando != null) && (CovidAutodichiarazioneExportElencoItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && 
((ImpresaIndividualeEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.ImpresaIndividuale != null) && (CovidAutodichiarazioneExportElencoItem.ImpresaIndividuale.Value == ImpresaIndividualeEqualThis.Value))) && ((DataEstrazioneEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.DataEstrazione != null) && (CovidAutodichiarazioneExportElencoItem.DataEstrazione.Value == DataEstrazioneEqualThis.Value))) && ((ProgressivoEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.Progressivo != null) && (CovidAutodichiarazioneExportElencoItem.Progressivo.Value == ProgressivoEqualThis.Value))) && 
((IdFileEqualThis == null) || ((CovidAutodichiarazioneExportElencoItem.IdFile != null) && (CovidAutodichiarazioneExportElencoItem.IdFile.Value == IdFileEqualThis.Value))))
				{
					CovidAutodichiarazioneExportElencoCollectionTemp.Add(CovidAutodichiarazioneExportElencoItem);
				}
			}
			return CovidAutodichiarazioneExportElencoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneExportElencoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CovidAutodichiarazioneExportElencoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdEstrazione", CovidAutodichiarazioneExportElencoObj.IdEstrazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CovidAutodichiarazioneExportElencoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneBando", CovidAutodichiarazioneExportElencoObj.DescrizioneBando);
			DbProvider.SetCmdParam(cmd,firstChar + "ImpresaIndividuale", CovidAutodichiarazioneExportElencoObj.ImpresaIndividuale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataEstrazione", CovidAutodichiarazioneExportElencoObj.DataEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Progressivo", CovidAutodichiarazioneExportElencoObj.Progressivo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", CovidAutodichiarazioneExportElencoObj.IdFile);
		}
		//Insert
		private static int Insert(DbProvider db, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoInsert", new string[] {"IdBando", "DescrizioneBando", 
"ImpresaIndividuale", "DataEstrazione", "Progressivo", 
"IdFile"}, new string[] {"int", "string", 
"bool", "DateTime", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,CovidAutodichiarazioneExportElencoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CovidAutodichiarazioneExportElencoObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
				}
				CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneExportElencoObj.IsDirty = false;
				CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoUpdate", new string[] {"IdEstrazione", "IdBando", "DescrizioneBando", 
"ImpresaIndividuale", "DataEstrazione", "Progressivo", 
"IdFile"}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,CovidAutodichiarazioneExportElencoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneExportElencoObj.IsDirty = false;
				CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			switch (CovidAutodichiarazioneExportElencoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CovidAutodichiarazioneExportElencoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CovidAutodichiarazioneExportElencoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CovidAutodichiarazioneExportElencoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoUpdate", new string[] {"IdEstrazione", "IdBando", "DescrizioneBando", 
"ImpresaIndividuale", "DataEstrazione", "Progressivo", 
"IdFile"}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoInsert", new string[] {"IdBando", "DescrizioneBando", 
"ImpresaIndividuale", "DataEstrazione", "Progressivo", 
"IdFile"}, new string[] {"int", "string", 
"bool", "DateTime", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				for (int i = 0; i < CovidAutodichiarazioneExportElencoCollectionObj.Count; i++)
				{
					switch (CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CovidAutodichiarazioneExportElencoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CovidAutodichiarazioneExportElencoCollectionObj[i].IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CovidAutodichiarazioneExportElencoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CovidAutodichiarazioneExportElencoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)CovidAutodichiarazioneExportElencoCollectionObj[i].IdEstrazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneExportElencoCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsPersistent = true;
					}
					if ((CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj)
		{
			int returnValue = 0;
			if (CovidAutodichiarazioneExportElencoObj.IsPersistent) 
			{
				returnValue = Delete(db, CovidAutodichiarazioneExportElencoObj.IdEstrazione);
			}
			CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CovidAutodichiarazioneExportElencoObj.IsDirty = false;
			CovidAutodichiarazioneExportElencoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdEstrazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)IdEstrazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoDelete", new string[] {"IdEstrazione"}, new string[] {"int"},"");
				for (int i = 0; i < CovidAutodichiarazioneExportElencoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazione", CovidAutodichiarazioneExportElencoCollectionObj[i].IdEstrazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CovidAutodichiarazioneExportElencoCollectionObj.Count; i++)
				{
					if ((CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CovidAutodichiarazioneExportElencoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsDirty = false;
						CovidAutodichiarazioneExportElencoCollectionObj[i].IsPersistent = false;
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
		public static CovidAutodichiarazioneExportElenco GetById(DbProvider db, int IdEstrazioneValue)
		{
			CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCovidAutodichiarazioneExportElencoGetById", new string[] {"IdEstrazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdEstrazione", (SiarLibrary.NullTypes.IntNT)IdEstrazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CovidAutodichiarazioneExportElencoObj = GetFromDatareader(db);
				CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneExportElencoObj.IsDirty = false;
				CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
			}
			db.Close();
			return CovidAutodichiarazioneExportElencoObj;
		}

		//getFromDatareader
		public static CovidAutodichiarazioneExportElenco GetFromDatareader(DbProvider db)
		{
			CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj = new CovidAutodichiarazioneExportElenco();
			CovidAutodichiarazioneExportElencoObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
			CovidAutodichiarazioneExportElencoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CovidAutodichiarazioneExportElencoObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
			CovidAutodichiarazioneExportElencoObj.ImpresaIndividuale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IMPRESA_INDIVIDUALE"]);
			CovidAutodichiarazioneExportElencoObj.DataEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESTRAZIONE"]);
			CovidAutodichiarazioneExportElencoObj.Progressivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["PROGRESSIVO"]);
			CovidAutodichiarazioneExportElencoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CovidAutodichiarazioneExportElencoObj.IsDirty = false;
			CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
			return CovidAutodichiarazioneExportElencoObj;
		}

		//Find Select

		public static CovidAutodichiarazioneExportElencoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, 
SiarLibrary.NullTypes.BoolNT ImpresaIndividualeEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEstrazioneEqualThis, SiarLibrary.NullTypes.IntNT ProgressivoEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionObj = new CovidAutodichiarazioneExportElencoCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazioneexportelencofindselect", new string[] {"IdEstrazioneequalthis", "IdBandoequalthis", "DescrizioneBandoequalthis", 
"ImpresaIndividualeequalthis", "DataEstrazioneequalthis", "Progressivoequalthis", 
"IdFileequalthis"}, new string[] {"int", "int", "string", 
"bool", "DateTime", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneequalthis", IdEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImpresaIndividualeequalthis", ImpresaIndividualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEstrazioneequalthis", DataEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneExportElencoObj = GetFromDatareader(db);
				CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneExportElencoObj.IsDirty = false;
				CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
				CovidAutodichiarazioneExportElencoCollectionObj.Add(CovidAutodichiarazioneExportElencoObj);
			}
			db.Close();
			return CovidAutodichiarazioneExportElencoCollectionObj;
		}

		//Find Find

		public static CovidAutodichiarazioneExportElencoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.BoolNT ImpresaIndividualeEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEstrazioneEqualThis, 
SiarLibrary.NullTypes.IntNT ProgressivoEqualThis)

		{

			CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionObj = new CovidAutodichiarazioneExportElencoCollection();

			IDbCommand findCmd = db.InitCmd("Zcovidautodichiarazioneexportelencofindfind", new string[] {"IdBandoequalthis", "ImpresaIndividualeequalthis", "DataEstrazioneequalthis", 
"Progressivoequalthis"}, new string[] {"int", "bool", "DateTime", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImpresaIndividualeequalthis", ImpresaIndividualeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEstrazioneequalthis", DataEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progressivoequalthis", ProgressivoEqualThis);
			CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CovidAutodichiarazioneExportElencoObj = GetFromDatareader(db);
				CovidAutodichiarazioneExportElencoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CovidAutodichiarazioneExportElencoObj.IsDirty = false;
				CovidAutodichiarazioneExportElencoObj.IsPersistent = true;
				CovidAutodichiarazioneExportElencoCollectionObj.Add(CovidAutodichiarazioneExportElencoObj);
			}
			db.Close();
			return CovidAutodichiarazioneExportElencoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CovidAutodichiarazioneExportElencoCollectionProvider:ICovidAutodichiarazioneExportElencoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CovidAutodichiarazioneExportElencoCollectionProvider : ICovidAutodichiarazioneExportElencoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CovidAutodichiarazioneExportElenco
		protected CovidAutodichiarazioneExportElencoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CovidAutodichiarazioneExportElencoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CovidAutodichiarazioneExportElencoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CovidAutodichiarazioneExportElencoCollectionProvider(IntNT IdbandoEqualThis, BoolNT ImpresaindividualeEqualThis, DatetimeNT DataestrazioneEqualThis, 
IntNT ProgressivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, ImpresaindividualeEqualThis, DataestrazioneEqualThis, 
ProgressivoEqualThis);
		}

		//Costruttore3: ha in input covidautodichiarazioneexportelencoCollectionObj - non popola la collection
		public CovidAutodichiarazioneExportElencoCollectionProvider(CovidAutodichiarazioneExportElencoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CovidAutodichiarazioneExportElencoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CovidAutodichiarazioneExportElencoCollection(this);
		}

		//Get e Set
		public CovidAutodichiarazioneExportElencoCollection CollectionObj
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
		public int SaveCollection(CovidAutodichiarazioneExportElencoCollection collectionObj)
		{
			return CovidAutodichiarazioneExportElencoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CovidAutodichiarazioneExportElenco covidautodichiarazioneexportelencoObj)
		{
			return CovidAutodichiarazioneExportElencoDAL.Save(_dbProviderObj, covidautodichiarazioneexportelencoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CovidAutodichiarazioneExportElencoCollection collectionObj)
		{
			return CovidAutodichiarazioneExportElencoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CovidAutodichiarazioneExportElenco covidautodichiarazioneexportelencoObj)
		{
			return CovidAutodichiarazioneExportElencoDAL.Delete(_dbProviderObj, covidautodichiarazioneexportelencoObj);
		}

		//getById
		public CovidAutodichiarazioneExportElenco GetById(IntNT IdEstrazioneValue)
		{
			CovidAutodichiarazioneExportElenco CovidAutodichiarazioneExportElencoTemp = CovidAutodichiarazioneExportElencoDAL.GetById(_dbProviderObj, IdEstrazioneValue);
			if (CovidAutodichiarazioneExportElencoTemp!=null) CovidAutodichiarazioneExportElencoTemp.Provider = this;
			return CovidAutodichiarazioneExportElencoTemp;
		}

		//Select: popola la collection
		public CovidAutodichiarazioneExportElencoCollection Select(IntNT IdestrazioneEqualThis, IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, 
BoolNT ImpresaindividualeEqualThis, DatetimeNT DataestrazioneEqualThis, IntNT ProgressivoEqualThis, 
IntNT IdfileEqualThis)
		{
			CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionTemp = CovidAutodichiarazioneExportElencoDAL.Select(_dbProviderObj, IdestrazioneEqualThis, IdbandoEqualThis, DescrizionebandoEqualThis, 
ImpresaindividualeEqualThis, DataestrazioneEqualThis, ProgressivoEqualThis, 
IdfileEqualThis);
			CovidAutodichiarazioneExportElencoCollectionTemp.Provider = this;
			return CovidAutodichiarazioneExportElencoCollectionTemp;
		}

		//Find: popola la collection
		public CovidAutodichiarazioneExportElencoCollection Find(IntNT IdbandoEqualThis, BoolNT ImpresaindividualeEqualThis, DatetimeNT DataestrazioneEqualThis, 
IntNT ProgressivoEqualThis)
		{
			CovidAutodichiarazioneExportElencoCollection CovidAutodichiarazioneExportElencoCollectionTemp = CovidAutodichiarazioneExportElencoDAL.Find(_dbProviderObj, IdbandoEqualThis, ImpresaindividualeEqualThis, DataestrazioneEqualThis, 
ProgressivoEqualThis);
			CovidAutodichiarazioneExportElencoCollectionTemp.Provider = this;
			return CovidAutodichiarazioneExportElencoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COVID_AUTODICHIARAZIONE_EXPORT_ELENCO>
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
    <Find OrderBy="ORDER BY DATA_ESTRAZIONE DESC">
      <ID_BANDO>Equal</ID_BANDO>
      <IMPRESA_INDIVIDUALE>Equal</IMPRESA_INDIVIDUALE>
      <DATA_ESTRAZIONE>Equal</DATA_ESTRAZIONE>
      <PROGRESSIVO>Equal</PROGRESSIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COVID_AUTODICHIARAZIONE_EXPORT_ELENCO>
*/
