using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CodificaInvestimento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICodificaInvestimentoProvider
	{
		int Save(CodificaInvestimento CodificaInvestimentoObj);
		int SaveCollection(CodificaInvestimentoCollection collectionObj);
		int Delete(CodificaInvestimento CodificaInvestimentoObj);
		int DeleteCollection(CodificaInvestimentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CodificaInvestimento
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CodificaInvestimento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdCodificaInvestimento;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _CodTp;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DecimalNT _AiutoMinimo;
		private NullTypes.StringNT _Codice;
		private NullTypes.BoolNT _IsMax;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.DecimalNT _AiutoMinimoAltrefonti;
		private NullTypes.StringNT _QuerySqlAltrefonti;
		private NullTypes.IntNT _IdIntervento;
		[NonSerialized] private ICodificaInvestimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICodificaInvestimentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CodificaInvestimento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCodificaInvestimento
		{
			get { return _IdCodificaInvestimento; }
			set {
				if (IdCodificaInvestimento != value)
				{
					_IdCodificaInvestimento = value;
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
		/// Corrisponde al campo:COD_TP
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT CodTp
		{
			get { return _CodTp; }
			set {
				if (CodTp != value)
				{
					_CodTp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:AIUTO_MINIMO
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT AiutoMinimo
		{
			get { return _AiutoMinimo; }
			set {
				if (AiutoMinimo != value)
				{
					_AiutoMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:CHAR(6)
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
		/// Corrisponde al campo:IS_MAX
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT IsMax
		{
			get { return _IsMax; }
			set {
				if (IsMax != value)
				{
					_IsMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AIUTO_MINIMO_ALTREFONTI
		/// Tipo sul db:DECIMAL(15,12)
		/// </summary>
		public NullTypes.DecimalNT AiutoMinimoAltrefonti
		{
			get { return _AiutoMinimoAltrefonti; }
			set {
				if (AiutoMinimoAltrefonti != value)
				{
					_AiutoMinimoAltrefonti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_ALTREFONTI
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QuerySqlAltrefonti
		{
			get { return _QuerySqlAltrefonti; }
			set {
				if (QuerySqlAltrefonti != value)
				{
					_QuerySqlAltrefonti = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_INTERVENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntervento
		{
			get { return _IdIntervento; }
			set {
				if (IdIntervento != value)
				{
					_IdIntervento = value;
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
	/// Summary description for CodificaInvestimentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CodificaInvestimentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CodificaInvestimentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CodificaInvestimento) info.GetValue(i.ToString(),typeof(CodificaInvestimento)));
			}
		}

		//Costruttore
		public CodificaInvestimentoCollection()
		{
			this.ItemType = typeof(CodificaInvestimento);
		}

		//Costruttore con provider
		public CodificaInvestimentoCollection(ICodificaInvestimentoProvider providerObj)
		{
			this.ItemType = typeof(CodificaInvestimento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CodificaInvestimento this[int index]
		{
			get { return (CodificaInvestimento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CodificaInvestimentoCollection GetChanges()
		{
			return (CodificaInvestimentoCollection) base.GetChanges();
		}

		[NonSerialized] private ICodificaInvestimentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICodificaInvestimentoProvider Provider
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
		public int Add(CodificaInvestimento CodificaInvestimentoObj)
		{
			if (CodificaInvestimentoObj.Provider == null) CodificaInvestimentoObj.Provider = this.Provider;
			return base.Add(CodificaInvestimentoObj);
		}

		//AddCollection
		public void AddCollection(CodificaInvestimentoCollection CodificaInvestimentoCollectionObj)
		{
			foreach (CodificaInvestimento CodificaInvestimentoObj in CodificaInvestimentoCollectionObj)
				this.Add(CodificaInvestimentoObj);
		}

		//Insert
		public void Insert(int index, CodificaInvestimento CodificaInvestimentoObj)
		{
			if (CodificaInvestimentoObj.Provider == null) CodificaInvestimentoObj.Provider = this.Provider;
			base.Insert(index, CodificaInvestimentoObj);
		}

		//CollectionGetById
		public CodificaInvestimento CollectionGetById(NullTypes.IntNT IdCodificaInvestimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCodificaInvestimento == IdCodificaInvestimentoValue))
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
		public CodificaInvestimentoCollection SubSelect(NullTypes.IntNT IdCodificaInvestimentoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTpEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.DecimalNT AiutoMinimoEqualThis, NullTypes.StringNT CodiceEqualThis, 
NullTypes.BoolNT IsMaxEqualThis, NullTypes.StringNT QuerySqlEqualThis, NullTypes.DecimalNT AiutoMinimoAltrefontiEqualThis, 
NullTypes.StringNT QuerySqlAltrefontiEqualThis, NullTypes.IntNT IdInterventoEqualThis)
		{
			CodificaInvestimentoCollection CodificaInvestimentoCollectionTemp = new CodificaInvestimentoCollection();
			foreach (CodificaInvestimento CodificaInvestimentoItem in this)
			{
				if (((IdCodificaInvestimentoEqualThis == null) || ((CodificaInvestimentoItem.IdCodificaInvestimento != null) && (CodificaInvestimentoItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((CodificaInvestimentoItem.IdBando != null) && (CodificaInvestimentoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTpEqualThis == null) || ((CodificaInvestimentoItem.CodTp != null) && (CodificaInvestimentoItem.CodTp.Value == CodTpEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((CodificaInvestimentoItem.Descrizione != null) && (CodificaInvestimentoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AiutoMinimoEqualThis == null) || ((CodificaInvestimentoItem.AiutoMinimo != null) && (CodificaInvestimentoItem.AiutoMinimo.Value == AiutoMinimoEqualThis.Value))) && ((CodiceEqualThis == null) || ((CodificaInvestimentoItem.Codice != null) && (CodificaInvestimentoItem.Codice.Value == CodiceEqualThis.Value))) && 
((IsMaxEqualThis == null) || ((CodificaInvestimentoItem.IsMax != null) && (CodificaInvestimentoItem.IsMax.Value == IsMaxEqualThis.Value))) && ((QuerySqlEqualThis == null) || ((CodificaInvestimentoItem.QuerySql != null) && (CodificaInvestimentoItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((AiutoMinimoAltrefontiEqualThis == null) || ((CodificaInvestimentoItem.AiutoMinimoAltrefonti != null) && (CodificaInvestimentoItem.AiutoMinimoAltrefonti.Value == AiutoMinimoAltrefontiEqualThis.Value))) && 
((QuerySqlAltrefontiEqualThis == null) || ((CodificaInvestimentoItem.QuerySqlAltrefonti != null) && (CodificaInvestimentoItem.QuerySqlAltrefonti.Value == QuerySqlAltrefontiEqualThis.Value))) && ((IdInterventoEqualThis == null) || ((CodificaInvestimentoItem.IdIntervento != null) && (CodificaInvestimentoItem.IdIntervento.Value == IdInterventoEqualThis.Value))))
				{
					CodificaInvestimentoCollectionTemp.Add(CodificaInvestimentoItem);
				}
			}
			return CodificaInvestimentoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CodificaInvestimentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CodificaInvestimentoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CodificaInvestimento CodificaInvestimentoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdCodificaInvestimento", CodificaInvestimentoObj.IdCodificaInvestimento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", CodificaInvestimentoObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTp", CodificaInvestimentoObj.CodTp);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", CodificaInvestimentoObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "AiutoMinimo", CodificaInvestimentoObj.AiutoMinimo);
			DbProvider.SetCmdParam(cmd,firstChar + "Codice", CodificaInvestimentoObj.Codice);
			DbProvider.SetCmdParam(cmd,firstChar + "IsMax", CodificaInvestimentoObj.IsMax);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", CodificaInvestimentoObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "AiutoMinimoAltrefonti", CodificaInvestimentoObj.AiutoMinimoAltrefonti);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySqlAltrefonti", CodificaInvestimentoObj.QuerySqlAltrefonti);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIntervento", CodificaInvestimentoObj.IdIntervento);
		}
		//Insert
		private static int Insert(DbProvider db, CodificaInvestimento CodificaInvestimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCodificaInvestimentoInsert", new string[] {"IdBando", "CodTp", 
"Descrizione", "AiutoMinimo", "Codice", 
"IsMax", "QuerySql", "AiutoMinimoAltrefonti", 
"QuerySqlAltrefonti", "IdIntervento"}, new string[] {"int", "string", 
"string", "decimal", "string", 
"bool", "string", "decimal", 
"string", "int"},"");
				CompileIUCmd(false, insertCmd,CodificaInvestimentoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CodificaInvestimentoObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
				}
				CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CodificaInvestimentoObj.IsDirty = false;
				CodificaInvestimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CodificaInvestimento CodificaInvestimentoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCodificaInvestimentoUpdate", new string[] {"IdCodificaInvestimento", "IdBando", "CodTp", 
"Descrizione", "AiutoMinimo", "Codice", 
"IsMax", "QuerySql", "AiutoMinimoAltrefonti", 
"QuerySqlAltrefonti", "IdIntervento"}, new string[] {"int", "int", "string", 
"string", "decimal", "string", 
"bool", "string", "decimal", 
"string", "int"},"");
				CompileIUCmd(true, updateCmd,CodificaInvestimentoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CodificaInvestimentoObj.IsDirty = false;
				CodificaInvestimentoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CodificaInvestimento CodificaInvestimentoObj)
		{
			switch (CodificaInvestimentoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CodificaInvestimentoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CodificaInvestimentoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CodificaInvestimentoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CodificaInvestimentoCollection CodificaInvestimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCodificaInvestimentoUpdate", new string[] {"IdCodificaInvestimento", "IdBando", "CodTp", 
"Descrizione", "AiutoMinimo", "Codice", 
"IsMax", "QuerySql", "AiutoMinimoAltrefonti", 
"QuerySqlAltrefonti", "IdIntervento"}, new string[] {"int", "int", "string", 
"string", "decimal", "string", 
"bool", "string", "decimal", 
"string", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCodificaInvestimentoInsert", new string[] {"IdBando", "CodTp", 
"Descrizione", "AiutoMinimo", "Codice", 
"IsMax", "QuerySql", "AiutoMinimoAltrefonti", 
"QuerySqlAltrefonti", "IdIntervento"}, new string[] {"int", "string", 
"string", "decimal", "string", 
"bool", "string", "decimal", 
"string", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCodificaInvestimentoDelete", new string[] {"IdCodificaInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < CodificaInvestimentoCollectionObj.Count; i++)
				{
					switch (CodificaInvestimentoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CodificaInvestimentoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CodificaInvestimentoCollectionObj[i].IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CodificaInvestimentoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CodificaInvestimentoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCodificaInvestimento", (SiarLibrary.NullTypes.IntNT)CodificaInvestimentoCollectionObj[i].IdCodificaInvestimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CodificaInvestimentoCollectionObj.Count; i++)
				{
					if ((CodificaInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CodificaInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CodificaInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CodificaInvestimentoCollectionObj[i].IsDirty = false;
						CodificaInvestimentoCollectionObj[i].IsPersistent = true;
					}
					if ((CodificaInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CodificaInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CodificaInvestimentoCollectionObj[i].IsDirty = false;
						CodificaInvestimentoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CodificaInvestimento CodificaInvestimentoObj)
		{
			int returnValue = 0;
			if (CodificaInvestimentoObj.IsPersistent) 
			{
				returnValue = Delete(db, CodificaInvestimentoObj.IdCodificaInvestimento);
			}
			CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CodificaInvestimentoObj.IsDirty = false;
			CodificaInvestimentoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdCodificaInvestimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCodificaInvestimentoDelete", new string[] {"IdCodificaInvestimento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCodificaInvestimento", (SiarLibrary.NullTypes.IntNT)IdCodificaInvestimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CodificaInvestimentoCollection CodificaInvestimentoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCodificaInvestimentoDelete", new string[] {"IdCodificaInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < CodificaInvestimentoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCodificaInvestimento", CodificaInvestimentoCollectionObj[i].IdCodificaInvestimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CodificaInvestimentoCollectionObj.Count; i++)
				{
					if ((CodificaInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CodificaInvestimentoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CodificaInvestimentoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CodificaInvestimentoCollectionObj[i].IsDirty = false;
						CodificaInvestimentoCollectionObj[i].IsPersistent = false;
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
		public static CodificaInvestimento GetById(DbProvider db, int IdCodificaInvestimentoValue)
		{
			CodificaInvestimento CodificaInvestimentoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCodificaInvestimentoGetById", new string[] {"IdCodificaInvestimento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCodificaInvestimento", (SiarLibrary.NullTypes.IntNT)IdCodificaInvestimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CodificaInvestimentoObj = GetFromDatareader(db);
				CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CodificaInvestimentoObj.IsDirty = false;
				CodificaInvestimentoObj.IsPersistent = true;
			}
			db.Close();
			return CodificaInvestimentoObj;
		}

		//getFromDatareader
		public static CodificaInvestimento GetFromDatareader(DbProvider db)
		{
			CodificaInvestimento CodificaInvestimentoObj = new CodificaInvestimento();
			CodificaInvestimentoObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
			CodificaInvestimentoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			CodificaInvestimentoObj.CodTp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TP"]);
			CodificaInvestimentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			CodificaInvestimentoObj.AiutoMinimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AIUTO_MINIMO"]);
			CodificaInvestimentoObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
			CodificaInvestimentoObj.IsMax = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_MAX"]);
			CodificaInvestimentoObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			CodificaInvestimentoObj.AiutoMinimoAltrefonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AIUTO_MINIMO_ALTREFONTI"]);
			CodificaInvestimentoObj.QuerySqlAltrefonti = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_ALTREFONTI"]);
			CodificaInvestimentoObj.IdIntervento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTERVENTO"]);
			CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CodificaInvestimentoObj.IsDirty = false;
			CodificaInvestimentoObj.IsPersistent = true;
			return CodificaInvestimentoObj;
		}

		//Find Select

		public static CodificaInvestimentoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodTpEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DecimalNT AiutoMinimoEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis, 
SiarLibrary.NullTypes.BoolNT IsMaxEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.DecimalNT AiutoMinimoAltrefontiEqualThis, 
SiarLibrary.NullTypes.StringNT QuerySqlAltrefontiEqualThis, SiarLibrary.NullTypes.IntNT IdInterventoEqualThis)

		{

			CodificaInvestimentoCollection CodificaInvestimentoCollectionObj = new CodificaInvestimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcodificainvestimentofindselect", new string[] {"IdCodificaInvestimentoequalthis", "IdBandoequalthis", "CodTpequalthis", 
"Descrizioneequalthis", "AiutoMinimoequalthis", "Codiceequalthis", 
"IsMaxequalthis", "QuerySqlequalthis", "AiutoMinimoAltrefontiequalthis", 
"QuerySqlAltrefontiequalthis", "IdInterventoequalthis"}, new string[] {"int", "int", "string", 
"string", "decimal", "string", 
"bool", "string", "decimal", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTpequalthis", CodTpEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AiutoMinimoequalthis", AiutoMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IsMaxequalthis", IsMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AiutoMinimoAltrefontiequalthis", AiutoMinimoAltrefontiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlAltrefontiequalthis", QuerySqlAltrefontiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInterventoequalthis", IdInterventoEqualThis);
			CodificaInvestimento CodificaInvestimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CodificaInvestimentoObj = GetFromDatareader(db);
				CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CodificaInvestimentoObj.IsDirty = false;
				CodificaInvestimentoObj.IsPersistent = true;
				CodificaInvestimentoCollectionObj.Add(CodificaInvestimentoObj);
			}
			db.Close();
			return CodificaInvestimentoCollectionObj;
		}

		//Find Find

		public static CodificaInvestimentoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdInterventoEqualThis)

		{

			CodificaInvestimentoCollection CodificaInvestimentoCollectionObj = new CodificaInvestimentoCollection();

			IDbCommand findCmd = db.InitCmd("Zcodificainvestimentofindfind", new string[] {"IdBandoequalthis", "IdInterventoequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdInterventoequalthis", IdInterventoEqualThis);
			CodificaInvestimento CodificaInvestimentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CodificaInvestimentoObj = GetFromDatareader(db);
				CodificaInvestimentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CodificaInvestimentoObj.IsDirty = false;
				CodificaInvestimentoObj.IsPersistent = true;
				CodificaInvestimentoCollectionObj.Add(CodificaInvestimentoObj);
			}
			db.Close();
			return CodificaInvestimentoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CodificaInvestimentoCollectionProvider:ICodificaInvestimentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CodificaInvestimentoCollectionProvider : ICodificaInvestimentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CodificaInvestimento
		protected CodificaInvestimentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CodificaInvestimentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CodificaInvestimentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public CodificaInvestimentoCollectionProvider(IntNT IdbandoEqualThis, IntNT IdinterventoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdinterventoEqualThis);
		}

		//Costruttore3: ha in input codificainvestimentoCollectionObj - non popola la collection
		public CodificaInvestimentoCollectionProvider(CodificaInvestimentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CodificaInvestimentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CodificaInvestimentoCollection(this);
		}

		//Get e Set
		public CodificaInvestimentoCollection CollectionObj
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
		public int SaveCollection(CodificaInvestimentoCollection collectionObj)
		{
			return CodificaInvestimentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CodificaInvestimento codificainvestimentoObj)
		{
			return CodificaInvestimentoDAL.Save(_dbProviderObj, codificainvestimentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CodificaInvestimentoCollection collectionObj)
		{
			return CodificaInvestimentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CodificaInvestimento codificainvestimentoObj)
		{
			return CodificaInvestimentoDAL.Delete(_dbProviderObj, codificainvestimentoObj);
		}

		//getById
		public CodificaInvestimento GetById(IntNT IdCodificaInvestimentoValue)
		{
			CodificaInvestimento CodificaInvestimentoTemp = CodificaInvestimentoDAL.GetById(_dbProviderObj, IdCodificaInvestimentoValue);
			if (CodificaInvestimentoTemp!=null) CodificaInvestimentoTemp.Provider = this;
			return CodificaInvestimentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CodificaInvestimentoCollection Select(IntNT IdcodificainvestimentoEqualThis, IntNT IdbandoEqualThis, StringNT CodtpEqualThis, 
StringNT DescrizioneEqualThis, DecimalNT AiutominimoEqualThis, StringNT CodiceEqualThis, 
BoolNT IsmaxEqualThis, StringNT QuerysqlEqualThis, DecimalNT AiutominimoaltrefontiEqualThis, 
StringNT QuerysqlaltrefontiEqualThis, IntNT IdinterventoEqualThis)
		{
			CodificaInvestimentoCollection CodificaInvestimentoCollectionTemp = CodificaInvestimentoDAL.Select(_dbProviderObj, IdcodificainvestimentoEqualThis, IdbandoEqualThis, CodtpEqualThis, 
DescrizioneEqualThis, AiutominimoEqualThis, CodiceEqualThis, 
IsmaxEqualThis, QuerysqlEqualThis, AiutominimoaltrefontiEqualThis, 
QuerysqlaltrefontiEqualThis, IdinterventoEqualThis);
			CodificaInvestimentoCollectionTemp.Provider = this;
			return CodificaInvestimentoCollectionTemp;
		}

		//Find: popola la collection
		public CodificaInvestimentoCollection Find(IntNT IdbandoEqualThis, IntNT IdinterventoEqualThis)
		{
			CodificaInvestimentoCollection CodificaInvestimentoCollectionTemp = CodificaInvestimentoDAL.Find(_dbProviderObj, IdbandoEqualThis, IdinterventoEqualThis);
			CodificaInvestimentoCollectionTemp.Provider = this;
			return CodificaInvestimentoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CODIFICA_INVESTIMENTO>
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
  <Finds>
    <Find OrderBy="ORDER BY ID_CODIFICA_INVESTIMENTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_INTERVENTO>Equal</ID_INTERVENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CODIFICA_INVESTIMENTO>
*/
