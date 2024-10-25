using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per GraduatoriaProgettiStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IGraduatoriaProgettiStoricoProvider
	{
		int Save(GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj);
		int SaveCollection(GraduatoriaProgettiStoricoCollection collectionObj);
		int Delete(GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj);
		int DeleteCollection(GraduatoriaProgettiStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for GraduatoriaProgettiStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class GraduatoriaProgettiStorico: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdGraduatoriaProgettiStorico;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _DataAnnullamento;
		private NullTypes.StringNT _IstanzaGraduatoria;
		[NonSerialized] private IGraduatoriaProgettiStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiStoricoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public GraduatoriaProgettiStorico()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_GRADUATORIA_PROGETTI_STORICO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdGraduatoriaProgettiStorico
		{
			get { return _IdGraduatoriaProgettiStorico; }
			set {
				if (IdGraduatoriaProgettiStorico != value)
				{
					_IdGraduatoriaProgettiStorico = value;
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
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
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
		/// Corrisponde al campo:DATA_ANNULLAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAnnullamento
		{
			get { return _DataAnnullamento; }
			set {
				if (DataAnnullamento != value)
				{
					_DataAnnullamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTANZA_GRADUATORIA
		/// Tipo sul db:XML
		/// </summary>
		public NullTypes.StringNT IstanzaGraduatoria
		{
			get { return _IstanzaGraduatoria; }
			set {
				if (IstanzaGraduatoria != value)
				{
					_IstanzaGraduatoria = value;
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
	/// Summary description for GraduatoriaProgettiStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaProgettiStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaProgettiStorico) info.GetValue(i.ToString(),typeof(GraduatoriaProgettiStorico)));
			}
		}

		//Costruttore
		public GraduatoriaProgettiStoricoCollection()
		{
			this.ItemType = typeof(GraduatoriaProgettiStorico);
		}

		//Costruttore con provider
		public GraduatoriaProgettiStoricoCollection(IGraduatoriaProgettiStoricoProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaProgettiStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaProgettiStorico this[int index]
		{
			get { return (GraduatoriaProgettiStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaProgettiStoricoCollection GetChanges()
		{
			return (GraduatoriaProgettiStoricoCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaProgettiStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiStoricoProvider Provider
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
		public int Add(GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			if (GraduatoriaProgettiStoricoObj.Provider == null) GraduatoriaProgettiStoricoObj.Provider = this.Provider;
			return base.Add(GraduatoriaProgettiStoricoObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionObj)
		{
			foreach (GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj in GraduatoriaProgettiStoricoCollectionObj)
				this.Add(GraduatoriaProgettiStoricoObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			if (GraduatoriaProgettiStoricoObj.Provider == null) GraduatoriaProgettiStoricoObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaProgettiStoricoObj);
		}

		//CollectionGetById
		public GraduatoriaProgettiStorico CollectionGetById(NullTypes.IntNT IdGraduatoriaProgettiStoricoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdGraduatoriaProgettiStorico == IdGraduatoriaProgettiStoricoValue))
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
		public GraduatoriaProgettiStoricoCollection SubSelect(NullTypes.IntNT IdGraduatoriaProgettiStoricoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.DatetimeNT DataAnnullamentoEqualThis)
		{
			GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionTemp = new GraduatoriaProgettiStoricoCollection();
			foreach (GraduatoriaProgettiStorico GraduatoriaProgettiStoricoItem in this)
			{
				if (((IdGraduatoriaProgettiStoricoEqualThis == null) || ((GraduatoriaProgettiStoricoItem.IdGraduatoriaProgettiStorico != null) && (GraduatoriaProgettiStoricoItem.IdGraduatoriaProgettiStorico.Value == IdGraduatoriaProgettiStoricoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((GraduatoriaProgettiStoricoItem.IdBando != null) && (GraduatoriaProgettiStoricoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((GraduatoriaProgettiStoricoItem.Operatore != null) && (GraduatoriaProgettiStoricoItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((DataAnnullamentoEqualThis == null) || ((GraduatoriaProgettiStoricoItem.DataAnnullamento != null) && (GraduatoriaProgettiStoricoItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))))
				{
					GraduatoriaProgettiStoricoCollectionTemp.Add(GraduatoriaProgettiStoricoItem);
				}
			}
			return GraduatoriaProgettiStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class GraduatoriaProgettiStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdGraduatoriaProgettiStorico", GraduatoriaProgettiStoricoObj.IdGraduatoriaProgettiStorico);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", GraduatoriaProgettiStoricoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", GraduatoriaProgettiStoricoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "DataAnnullamento", GraduatoriaProgettiStoricoObj.DataAnnullamento);
			DbProvider.SetCmdParam(cmd,firstChar + "IstanzaGraduatoria", GraduatoriaProgettiStoricoObj.IstanzaGraduatoria);
		}
		//Insert
		private static int Insert(DbProvider db, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoInsert", new string[] {"IdBando", "Operatore", 
"DataAnnullamento", "IstanzaGraduatoria"}, new string[] {"int", "int", 
"DateTime", "string"},"");
				CompileIUCmd(false, insertCmd,GraduatoriaProgettiStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				GraduatoriaProgettiStoricoObj.IdGraduatoriaProgettiStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_STORICO"]);
				}
				GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiStoricoObj.IsDirty = false;
				GraduatoriaProgettiStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoUpdate", new string[] {"IdGraduatoriaProgettiStorico", "IdBando", "Operatore", 
"DataAnnullamento", "IstanzaGraduatoria"}, new string[] {"int", "int", "int", 
"DateTime", "string"},"");
				CompileIUCmd(true, updateCmd,GraduatoriaProgettiStoricoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiStoricoObj.IsDirty = false;
				GraduatoriaProgettiStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			switch (GraduatoriaProgettiStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, GraduatoriaProgettiStoricoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, GraduatoriaProgettiStoricoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,GraduatoriaProgettiStoricoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoUpdate", new string[] {"IdGraduatoriaProgettiStorico", "IdBando", "Operatore", 
"DataAnnullamento", "IstanzaGraduatoria"}, new string[] {"int", "int", "int", 
"DateTime", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoInsert", new string[] {"IdBando", "Operatore", 
"DataAnnullamento", "IstanzaGraduatoria"}, new string[] {"int", "int", 
"DateTime", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoDelete", new string[] {"IdGraduatoriaProgettiStorico"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaProgettiStoricoCollectionObj.Count; i++)
				{
					switch (GraduatoriaProgettiStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,GraduatoriaProgettiStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									GraduatoriaProgettiStoricoCollectionObj[i].IdGraduatoriaProgettiStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_STORICO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,GraduatoriaProgettiStoricoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (GraduatoriaProgettiStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStorico", (SiarLibrary.NullTypes.IntNT)GraduatoriaProgettiStoricoCollectionObj[i].IdGraduatoriaProgettiStorico);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiStoricoCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						GraduatoriaProgettiStoricoCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((GraduatoriaProgettiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						GraduatoriaProgettiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiStoricoCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj)
		{
			int returnValue = 0;
			if (GraduatoriaProgettiStoricoObj.IsPersistent) 
			{
				returnValue = Delete(db, GraduatoriaProgettiStoricoObj.IdGraduatoriaProgettiStorico);
			}
			GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			GraduatoriaProgettiStoricoObj.IsDirty = false;
			GraduatoriaProgettiStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdGraduatoriaProgettiStoricoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoDelete", new string[] {"IdGraduatoriaProgettiStorico"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStorico", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiStoricoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoDelete", new string[] {"IdGraduatoriaProgettiStorico"}, new string[] {"int"},"");
				for (int i = 0; i < GraduatoriaProgettiStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStorico", GraduatoriaProgettiStoricoCollectionObj[i].IdGraduatoriaProgettiStorico);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < GraduatoriaProgettiStoricoCollectionObj.Count; i++)
				{
					if ((GraduatoriaProgettiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (GraduatoriaProgettiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						GraduatoriaProgettiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						GraduatoriaProgettiStoricoCollectionObj[i].IsDirty = false;
						GraduatoriaProgettiStoricoCollectionObj[i].IsPersistent = false;
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
		public static GraduatoriaProgettiStorico GetById(DbProvider db, int IdGraduatoriaProgettiStoricoValue)
		{
			GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZGraduatoriaProgettiStoricoGetById", new string[] {"IdGraduatoriaProgettiStorico"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStorico", (SiarLibrary.NullTypes.IntNT)IdGraduatoriaProgettiStoricoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				GraduatoriaProgettiStoricoObj = GetFromDatareader(db);
				GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiStoricoObj.IsDirty = false;
				GraduatoriaProgettiStoricoObj.IsPersistent = true;
			}
			db.Close();
			return GraduatoriaProgettiStoricoObj;
		}

		//getFromDatareader
		public static GraduatoriaProgettiStorico GetFromDatareader(DbProvider db)
		{
			GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj = new GraduatoriaProgettiStorico();
			GraduatoriaProgettiStoricoObj.IdGraduatoriaProgettiStorico = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_GRADUATORIA_PROGETTI_STORICO"]);
			GraduatoriaProgettiStoricoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			GraduatoriaProgettiStoricoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			GraduatoriaProgettiStoricoObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
			GraduatoriaProgettiStoricoObj.IstanzaGraduatoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA_GRADUATORIA"]);
			GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			GraduatoriaProgettiStoricoObj.IsDirty = false;
			GraduatoriaProgettiStoricoObj.IsPersistent = true;
			return GraduatoriaProgettiStoricoObj;
		}

		//Find Select

		public static GraduatoriaProgettiStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaProgettiStoricoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis)

		{

			GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionObj = new GraduatoriaProgettiStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettistoricofindselect", new string[] {"IdGraduatoriaProgettiStoricoequalthis", "IdBandoequalthis", "Operatoreequalthis", 
"DataAnnullamentoequalthis"}, new string[] {"int", "int", "int", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStoricoequalthis", IdGraduatoriaProgettiStoricoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
			GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiStoricoObj = GetFromDatareader(db);
				GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiStoricoObj.IsDirty = false;
				GraduatoriaProgettiStoricoObj.IsPersistent = true;
				GraduatoriaProgettiStoricoCollectionObj.Add(GraduatoriaProgettiStoricoObj);
			}
			db.Close();
			return GraduatoriaProgettiStoricoCollectionObj;
		}

		//Find Find

		public static GraduatoriaProgettiStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdGraduatoriaProgettiStoricoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

		{

			GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionObj = new GraduatoriaProgettiStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zgraduatoriaprogettistoricofindfind", new string[] {"IdGraduatoriaProgettiStoricoequalthis", "IdBandoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdGraduatoriaProgettiStoricoequalthis", IdGraduatoriaProgettiStoricoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			GraduatoriaProgettiStorico GraduatoriaProgettiStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				GraduatoriaProgettiStoricoObj = GetFromDatareader(db);
				GraduatoriaProgettiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				GraduatoriaProgettiStoricoObj.IsDirty = false;
				GraduatoriaProgettiStoricoObj.IsPersistent = true;
				GraduatoriaProgettiStoricoCollectionObj.Add(GraduatoriaProgettiStoricoObj);
			}
			db.Close();
			return GraduatoriaProgettiStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiStoricoCollectionProvider:IGraduatoriaProgettiStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class GraduatoriaProgettiStoricoCollectionProvider : IGraduatoriaProgettiStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di GraduatoriaProgettiStorico
		protected GraduatoriaProgettiStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public GraduatoriaProgettiStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new GraduatoriaProgettiStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public GraduatoriaProgettiStoricoCollectionProvider(IntNT IdgraduatoriaprogettistoricoEqualThis, IntNT IdbandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdgraduatoriaprogettistoricoEqualThis, IdbandoEqualThis);
		}

		//Costruttore3: ha in input graduatoriaprogettistoricoCollectionObj - non popola la collection
		public GraduatoriaProgettiStoricoCollectionProvider(GraduatoriaProgettiStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public GraduatoriaProgettiStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new GraduatoriaProgettiStoricoCollection(this);
		}

		//Get e Set
		public GraduatoriaProgettiStoricoCollection CollectionObj
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
		public int SaveCollection(GraduatoriaProgettiStoricoCollection collectionObj)
		{
			return GraduatoriaProgettiStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(GraduatoriaProgettiStorico graduatoriaprogettistoricoObj)
		{
			return GraduatoriaProgettiStoricoDAL.Save(_dbProviderObj, graduatoriaprogettistoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(GraduatoriaProgettiStoricoCollection collectionObj)
		{
			return GraduatoriaProgettiStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(GraduatoriaProgettiStorico graduatoriaprogettistoricoObj)
		{
			return GraduatoriaProgettiStoricoDAL.Delete(_dbProviderObj, graduatoriaprogettistoricoObj);
		}

		//getById
		public GraduatoriaProgettiStorico GetById(IntNT IdGraduatoriaProgettiStoricoValue)
		{
			GraduatoriaProgettiStorico GraduatoriaProgettiStoricoTemp = GraduatoriaProgettiStoricoDAL.GetById(_dbProviderObj, IdGraduatoriaProgettiStoricoValue);
			if (GraduatoriaProgettiStoricoTemp!=null) GraduatoriaProgettiStoricoTemp.Provider = this;
			return GraduatoriaProgettiStoricoTemp;
		}

		//Select: popola la collection
		public GraduatoriaProgettiStoricoCollection Select(IntNT IdgraduatoriaprogettistoricoEqualThis, IntNT IdbandoEqualThis, IntNT OperatoreEqualThis, 
DatetimeNT DataannullamentoEqualThis)
		{
			GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionTemp = GraduatoriaProgettiStoricoDAL.Select(_dbProviderObj, IdgraduatoriaprogettistoricoEqualThis, IdbandoEqualThis, OperatoreEqualThis, 
DataannullamentoEqualThis);
			GraduatoriaProgettiStoricoCollectionTemp.Provider = this;
			return GraduatoriaProgettiStoricoCollectionTemp;
		}

		//Find: popola la collection
		public GraduatoriaProgettiStoricoCollection Find(IntNT IdgraduatoriaprogettistoricoEqualThis, IntNT IdbandoEqualThis)
		{
			GraduatoriaProgettiStoricoCollection GraduatoriaProgettiStoricoCollectionTemp = GraduatoriaProgettiStoricoDAL.Find(_dbProviderObj, IdgraduatoriaprogettistoricoEqualThis, IdbandoEqualThis);
			GraduatoriaProgettiStoricoCollectionTemp.Provider = this;
			return GraduatoriaProgettiStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_STORICO>
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
      <ID_GRADUATORIA_PROGETTI_STORICO>Equal</ID_GRADUATORIA_PROGETTI_STORICO>
      <ID_BANDO>Equal</ID_BANDO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_STORICO>
*/
