using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CheckListXStep
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICheckListXStepProvider
	{
		int Save(CheckListXStep CheckListXStepObj);
		int SaveCollection(CheckListXStepCollection collectionObj);
		int Delete(CheckListXStep CheckListXStepObj);
		int DeleteCollection(CheckListXStepCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CheckListXStep
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CheckListXStep: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdStep;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _Obbligatorio;
		private NullTypes.DecimalNT _Peso;
		private NullTypes.StringNT _Step;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _CheckList;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.IntNT _IdCheckList;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _FaseProcedurale;
		private NullTypes.IntNT _OrdineFaseProcedurale;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _IncludiVerbaleVis;
		[NonSerialized] private ICheckListXStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICheckListXStepProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CheckListXStep()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_STEP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdStep
		{
			get { return _IdStep; }
			set {
				if (IdStep != value)
				{
					_IdStep = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
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
		/// Corrisponde al campo:PESO
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Peso
		{
			get { return _Peso; }
			set {
				if (Peso != value)
				{
					_Peso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STEP
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Step
		{
			get { return _Step; }
			set {
				if (Step != value)
				{
					_Step = value;
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
		/// Corrisponde al campo:CHECK_LIST
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT CheckList
		{
			get { return _CheckList; }
			set {
				if (CheckList != value)
				{
					_CheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_TEMPLATE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagTemplate
		{
			get { return _FlagTemplate; }
			set {
				if (FlagTemplate != value)
				{
					_FlagTemplate = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CHECK_LIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCheckList
		{
			get { return _IdCheckList; }
			set {
				if (IdCheckList != value)
				{
					_IdCheckList = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set {
				if (CodeMethod != value)
				{
					_CodeMethod = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
		{
			get { return _ValMassimo; }
			set {
				if (ValMassimo != value)
				{
					_ValMassimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
		{
			get { return _ValMinimo; }
			set {
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set {
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE_PROCEDURALE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT FaseProcedurale
		{
			get { return _FaseProcedurale; }
			set {
				if (FaseProcedurale != value)
				{
					_FaseProcedurale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FASE_PROCEDURALE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFaseProcedurale
		{
			get { return _OrdineFaseProcedurale; }
			set {
				if (OrdineFaseProcedurale != value)
				{
					_OrdineFaseProcedurale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
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
	/// Summary description for CheckListXStepCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CheckListXStepCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CheckListXStepCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CheckListXStep) info.GetValue(i.ToString(),typeof(CheckListXStep)));
			}
		}

		//Costruttore
		public CheckListXStepCollection()
		{
			this.ItemType = typeof(CheckListXStep);
		}

		//Costruttore con provider
		public CheckListXStepCollection(ICheckListXStepProvider providerObj)
		{
			this.ItemType = typeof(CheckListXStep);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CheckListXStep this[int index]
		{
			get { return (CheckListXStep)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CheckListXStepCollection GetChanges()
		{
			return (CheckListXStepCollection) base.GetChanges();
		}

		[NonSerialized] private ICheckListXStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICheckListXStepProvider Provider
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
		public int Add(CheckListXStep CheckListXStepObj)
		{
			if (CheckListXStepObj.Provider == null) CheckListXStepObj.Provider = this.Provider;
			return base.Add(CheckListXStepObj);
		}

		//AddCollection
		public void AddCollection(CheckListXStepCollection CheckListXStepCollectionObj)
		{
			foreach (CheckListXStep CheckListXStepObj in CheckListXStepCollectionObj)
				this.Add(CheckListXStepObj);
		}

		//Insert
		public void Insert(int index, CheckListXStep CheckListXStepObj)
		{
			if (CheckListXStepObj.Provider == null) CheckListXStepObj.Provider = this.Provider;
			base.Insert(index, CheckListXStepObj);
		}

		//CollectionGetById
		public CheckListXStep CollectionGetById(NullTypes.IntNT IdStepValue, NullTypes.IntNT IdCheckListValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdStep == IdStepValue) && (this[i].IdCheckList == IdCheckListValue))
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
		public CheckListXStepCollection SubSelect(NullTypes.IntNT IdCheckListEqualThis, NullTypes.IntNT IdStepEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.DecimalNT PesoEqualThis, NullTypes.BoolNT IncludiVerbaleVisEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = new CheckListXStepCollection();
			foreach (CheckListXStep CheckListXStepItem in this)
			{
				if (((IdCheckListEqualThis == null) || ((CheckListXStepItem.IdCheckList != null) && (CheckListXStepItem.IdCheckList.Value == IdCheckListEqualThis.Value))) && ((IdStepEqualThis == null) || ((CheckListXStepItem.IdStep != null) && (CheckListXStepItem.IdStep.Value == IdStepEqualThis.Value))) && ((OrdineEqualThis == null) || ((CheckListXStepItem.Ordine != null) && (CheckListXStepItem.Ordine.Value == OrdineEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((CheckListXStepItem.Obbligatorio != null) && (CheckListXStepItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((PesoEqualThis == null) || ((CheckListXStepItem.Peso != null) && (CheckListXStepItem.Peso.Value == PesoEqualThis.Value))) && ((IncludiVerbaleVisEqualThis == null) || ((CheckListXStepItem.IncludiVerbaleVis != null) && (CheckListXStepItem.IncludiVerbaleVis.Value == IncludiVerbaleVisEqualThis.Value))))
				{
					CheckListXStepCollectionTemp.Add(CheckListXStepItem);
				}
			}
			return CheckListXStepCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CheckListXStepCollection FiltroObbligatorio(NullTypes.BoolNT ObbligatorioEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = new CheckListXStepCollection();
			foreach (CheckListXStep CheckListXStepItem in this)
			{
				if (((ObbligatorioEqualThis == null) || ((CheckListXStepItem.Obbligatorio != null) && (CheckListXStepItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					CheckListXStepCollectionTemp.Add(CheckListXStepItem);
				}
			}
			return CheckListXStepCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CheckListXStepCollection FiltroAutomatico(NullTypes.BoolNT AutomaticoEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = new CheckListXStepCollection();
			foreach (CheckListXStep CheckListXStepItem in this)
			{
				if (((AutomaticoEqualThis == null) || ((CheckListXStepItem.Automatico != null) && (CheckListXStepItem.Automatico.Value == AutomaticoEqualThis.Value))))
				{
					CheckListXStepCollectionTemp.Add(CheckListXStepItem);
				}
			}
			return CheckListXStepCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CheckListXStepCollection FiltroMisura(NullTypes.StringNT MisuraLike)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = new CheckListXStepCollection();
			foreach (CheckListXStep CheckListXStepItem in this)
			{
				if (((MisuraLike == null) || ((CheckListXStepItem.Misura !=null) &&(CheckListXStepItem.Misura.Like(MisuraLike.Value)))))
				{
					CheckListXStepCollectionTemp.Add(CheckListXStepItem);
				}
			}
			return CheckListXStepCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public CheckListXStepCollection FiltroVerbale(NullTypes.BoolNT IncludiVerbaleVisEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = new CheckListXStepCollection();
			foreach (CheckListXStep CheckListXStepItem in this)
			{
				if (((IncludiVerbaleVisEqualThis == null) || ((CheckListXStepItem.IncludiVerbaleVis != null) && (CheckListXStepItem.IncludiVerbaleVis.Value == IncludiVerbaleVisEqualThis.Value))))
				{
					CheckListXStepCollectionTemp.Add(CheckListXStepItem);
				}
			}
			return CheckListXStepCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CheckListXStepDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CheckListXStepDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CheckListXStep CheckListXStepObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdStep", CheckListXStepObj.IdStep);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", CheckListXStepObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Obbligatorio", CheckListXStepObj.Obbligatorio);
			DbProvider.SetCmdParam(cmd,firstChar + "Peso", CheckListXStepObj.Peso);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCheckList", CheckListXStepObj.IdCheckList);
			DbProvider.SetCmdParam(cmd,firstChar + "IncludiVerbaleVis", CheckListXStepObj.IncludiVerbaleVis);
		}
		//Insert
		private static int Insert(DbProvider db, CheckListXStep CheckListXStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCheckListXStepInsert", new string[] {"IdStep", "Ordine", "Obbligatorio", 
"Peso", 

"IdCheckList", 


"IncludiVerbaleVis"}, new string[] {"int", "int", "bool", 
"decimal", 

"int", 


"bool"},"");
				CompileIUCmd(false, insertCmd,CheckListXStepObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CheckListXStepObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
				CheckListXStepObj.IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
				}
				CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListXStepObj.IsDirty = false;
				CheckListXStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CheckListXStep CheckListXStepObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCheckListXStepUpdate", new string[] {"IdStep", "Ordine", "Obbligatorio", 
"Peso", 

"IdCheckList", 


"IncludiVerbaleVis"}, new string[] {"int", "int", "bool", 
"decimal", 

"int", 


"bool"},"");
				CompileIUCmd(true, updateCmd,CheckListXStepObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListXStepObj.IsDirty = false;
				CheckListXStepObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CheckListXStep CheckListXStepObj)
		{
			switch (CheckListXStepObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CheckListXStepObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CheckListXStepObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CheckListXStepObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CheckListXStepCollection CheckListXStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCheckListXStepUpdate", new string[] {"IdStep", "Ordine", "Obbligatorio", 
"Peso", 

"IdCheckList", 


"IncludiVerbaleVis"}, new string[] {"int", "int", "bool", 
"decimal", 

"int", 


"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCheckListXStepInsert", new string[] {"IdStep", "Ordine", "Obbligatorio", 
"Peso", 

"IdCheckList", 


"IncludiVerbaleVis"}, new string[] {"int", "int", "bool", 
"decimal", 

"int", 


"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListXStepDelete", new string[] {"IdStep", "IdCheckList"}, new string[] {"int", "int"},"");
				for (int i = 0; i < CheckListXStepCollectionObj.Count; i++)
				{
					switch (CheckListXStepCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CheckListXStepCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CheckListXStepCollectionObj[i].Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
									CheckListXStepCollectionObj[i].IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CheckListXStepCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CheckListXStepCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)CheckListXStepCollectionObj[i].IdStep);
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)CheckListXStepCollectionObj[i].IdCheckList);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CheckListXStepCollectionObj.Count; i++)
				{
					if ((CheckListXStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CheckListXStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CheckListXStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CheckListXStepCollectionObj[i].IsDirty = false;
						CheckListXStepCollectionObj[i].IsPersistent = true;
					}
					if ((CheckListXStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CheckListXStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CheckListXStepCollectionObj[i].IsDirty = false;
						CheckListXStepCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CheckListXStep CheckListXStepObj)
		{
			int returnValue = 0;
			if (CheckListXStepObj.IsPersistent) 
			{
				returnValue = Delete(db, CheckListXStepObj.IdStep, CheckListXStepObj.IdCheckList);
			}
			CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CheckListXStepObj.IsDirty = false;
			CheckListXStepObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdStepValue, int IdCheckListValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListXStepDelete", new string[] {"IdStep", "IdCheckList"}, new string[] {"int", "int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CheckListXStepCollection CheckListXStepCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCheckListXStepDelete", new string[] {"IdStep", "IdCheckList"}, new string[] {"int", "int"},"");
				for (int i = 0; i < CheckListXStepCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdStep", CheckListXStepCollectionObj[i].IdStep);
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdCheckList", CheckListXStepCollectionObj[i].IdCheckList);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CheckListXStepCollectionObj.Count; i++)
				{
					if ((CheckListXStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CheckListXStepCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CheckListXStepCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CheckListXStepCollectionObj[i].IsDirty = false;
						CheckListXStepCollectionObj[i].IsPersistent = false;
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
		public static CheckListXStep GetById(DbProvider db, int IdStepValue, int IdCheckListValue)
		{
			CheckListXStep CheckListXStepObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCheckListXStepGetById", new string[] {"IdStep", "IdCheckList"}, new string[] {"int", "int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdStep", (SiarLibrary.NullTypes.IntNT)IdStepValue);
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdCheckList", (SiarLibrary.NullTypes.IntNT)IdCheckListValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CheckListXStepObj = GetFromDatareader(db);
				CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListXStepObj.IsDirty = false;
				CheckListXStepObj.IsPersistent = true;
			}
			db.Close();
			return CheckListXStepObj;
		}

		//getFromDatareader
		public static CheckListXStep GetFromDatareader(DbProvider db)
		{
			CheckListXStep CheckListXStepObj = new CheckListXStep();
			CheckListXStepObj.IdStep = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STEP"]);
			CheckListXStepObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			CheckListXStepObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			CheckListXStepObj.Peso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PESO"]);
			CheckListXStepObj.Step = new SiarLibrary.NullTypes.StringNT(db.DataReader["STEP"]);
			CheckListXStepObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			CheckListXStepObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			CheckListXStepObj.CheckList = new SiarLibrary.NullTypes.StringNT(db.DataReader["CHECK_LIST"]);
			CheckListXStepObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			CheckListXStepObj.IdCheckList = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECK_LIST"]);
			CheckListXStepObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			CheckListXStepObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			CheckListXStepObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			CheckListXStepObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			CheckListXStepObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			CheckListXStepObj.FaseProcedurale = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_PROCEDURALE"]);
			CheckListXStepObj.OrdineFaseProcedurale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE_PROCEDURALE"]);
			CheckListXStepObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			CheckListXStepObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
			CheckListXStepObj.IncludiVerbaleVis = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INCLUDI_VERBALE_VIS"]);
			CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CheckListXStepObj.IsDirty = false;
			CheckListXStepObj.IsPersistent = true;
			return CheckListXStepObj;
		}

		//Find Select

		public static CheckListXStepCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.DecimalNT PesoEqualThis, SiarLibrary.NullTypes.BoolNT IncludiVerbaleVisEqualThis)

		{

			CheckListXStepCollection CheckListXStepCollectionObj = new CheckListXStepCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistxstepfindselect", new string[] {"IdCheckListequalthis", "IdStepequalthis", "Ordineequalthis", 
"Obbligatorioequalthis", "Pesoequalthis", "IncludiVerbaleVisequalthis"}, new string[] {"int", "int", "int", 
"bool", "decimal", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pesoequalthis", PesoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IncludiVerbaleVisequalthis", IncludiVerbaleVisEqualThis);
			CheckListXStep CheckListXStepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CheckListXStepObj = GetFromDatareader(db);
				CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListXStepObj.IsDirty = false;
				CheckListXStepObj.IsPersistent = true;
				CheckListXStepCollectionObj.Add(CheckListXStepObj);
			}
			db.Close();
			return CheckListXStepCollectionObj;
		}

		//Find Find

		public static CheckListXStepCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdCheckListEqualThis, SiarLibrary.NullTypes.IntNT IdStepEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, 
SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			CheckListXStepCollection CheckListXStepCollectionObj = new CheckListXStepCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistxstepfindfind", new string[] {"IdCheckListequalthis", "IdStepequalthis", "FlagTemplateequalthis", 
"Ordineequalthis", "Obbligatorioequalthis", "Automaticoequalthis", 
"CodFaseequalthis"}, new string[] {"int", "int", "bool", 
"int", "bool", "bool", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCheckListequalthis", IdCheckListEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdStepequalthis", IdStepEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			CheckListXStep CheckListXStepObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CheckListXStepObj = GetFromDatareader(db);
				CheckListXStepObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CheckListXStepObj.IsDirty = false;
				CheckListXStepObj.IsPersistent = true;
				CheckListXStepCollectionObj.Add(CheckListXStepObj);
			}
			db.Close();
			return CheckListXStepCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CheckListXStepCollectionProvider:ICheckListXStepProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CheckListXStepCollectionProvider : ICheckListXStepProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CheckListXStep
		protected CheckListXStepCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CheckListXStepCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CheckListXStepCollection(this);
		}

		//Costruttore 2: popola la collection
		public CheckListXStepCollectionProvider(IntNT IdchecklistEqualThis, IntNT IdstepEqualThis, BoolNT FlagtemplateEqualThis, 
IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, BoolNT AutomaticoEqualThis, 
StringNT CodfaseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdchecklistEqualThis, IdstepEqualThis, FlagtemplateEqualThis, 
OrdineEqualThis, ObbligatorioEqualThis, AutomaticoEqualThis, 
CodfaseEqualThis);
		}

		//Costruttore3: ha in input checklistxstepCollectionObj - non popola la collection
		public CheckListXStepCollectionProvider(CheckListXStepCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CheckListXStepCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CheckListXStepCollection(this);
		}

		//Get e Set
		public CheckListXStepCollection CollectionObj
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
		public int SaveCollection(CheckListXStepCollection collectionObj)
		{
			return CheckListXStepDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CheckListXStep checklistxstepObj)
		{
			return CheckListXStepDAL.Save(_dbProviderObj, checklistxstepObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CheckListXStepCollection collectionObj)
		{
			return CheckListXStepDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CheckListXStep checklistxstepObj)
		{
			return CheckListXStepDAL.Delete(_dbProviderObj, checklistxstepObj);
		}

		//getById
		public CheckListXStep GetById(IntNT IdStepValue, IntNT IdCheckListValue)
		{
			CheckListXStep CheckListXStepTemp = CheckListXStepDAL.GetById(_dbProviderObj, IdStepValue, IdCheckListValue);
			if (CheckListXStepTemp!=null) CheckListXStepTemp.Provider = this;
			return CheckListXStepTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CheckListXStepCollection Select(IntNT IdchecklistEqualThis, IntNT IdstepEqualThis, IntNT OrdineEqualThis, 
BoolNT ObbligatorioEqualThis, DecimalNT PesoEqualThis, BoolNT IncludiverbalevisEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = CheckListXStepDAL.Select(_dbProviderObj, IdchecklistEqualThis, IdstepEqualThis, OrdineEqualThis, 
ObbligatorioEqualThis, PesoEqualThis, IncludiverbalevisEqualThis);
			CheckListXStepCollectionTemp.Provider = this;
			return CheckListXStepCollectionTemp;
		}

		//Find: popola la collection
		public CheckListXStepCollection Find(IntNT IdchecklistEqualThis, IntNT IdstepEqualThis, BoolNT FlagtemplateEqualThis, 
IntNT OrdineEqualThis, BoolNT ObbligatorioEqualThis, BoolNT AutomaticoEqualThis, 
StringNT CodfaseEqualThis)
		{
			CheckListXStepCollection CheckListXStepCollectionTemp = CheckListXStepDAL.Find(_dbProviderObj, IdchecklistEqualThis, IdstepEqualThis, FlagtemplateEqualThis, 
OrdineEqualThis, ObbligatorioEqualThis, AutomaticoEqualThis, 
CodfaseEqualThis);
			CheckListXStepCollectionTemp.Provider = this;
			return CheckListXStepCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECK_LIST_X_STEP>
  <ViewName>vCHECKLIST</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
      <ID_STEP>Equal</ID_STEP>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <ORDINE>Equal</ORDINE>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
      <AUTOMATICO>Equal</AUTOMATICO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
    <FiltroVerbale>
      <INCLUDI_VERBALE_VIS>Equal</INCLUDI_VERBALE_VIS>
    </FiltroVerbale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CHECK_LIST_X_STEP>
*/
