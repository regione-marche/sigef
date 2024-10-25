using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ChecklistGenericaModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IChecklistGenericaModificheProvider
	{
		int Save(ChecklistGenericaModifiche ChecklistGenericaModificheObj);
		int SaveCollection(ChecklistGenericaModificheCollection collectionObj);
		int Delete(ChecklistGenericaModifiche ChecklistGenericaModificheObj);
		int DeleteCollection(ChecklistGenericaModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ChecklistGenericaModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ChecklistGenericaModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.IntNT _IdTipo;
		private NullTypes.StringNT _IdFiltro;
		private NullTypes.StringNT _DescrizioneTipo;
		private NullTypes.BoolNT _ContieneVociTipo;
		private NullTypes.BoolNT _SchedaTipo;
		private NullTypes.StringNT _DescrizioneFiltro;
		private NullTypes.IntNT _OrdineFiltro;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IChecklistGenericaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IChecklistGenericaModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ChecklistGenericaModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_CHECKLIST_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistGenerica
		{
			get { return _IdChecklistGenerica; }
			set {
				if (IdChecklistGenerica != value)
				{
					_IdChecklistGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(-1)
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
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set {
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipo
		{
			get { return _IdTipo; }
			set {
				if (IdTipo != value)
				{
					_IdTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltro
		{
			get { return _IdFiltro; }
			set {
				if (IdFiltro != value)
				{
					_IdFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_TIPO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneTipo
		{
			get { return _DescrizioneTipo; }
			set {
				if (DescrizioneTipo != value)
				{
					_DescrizioneTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTIENE_VOCI_TIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT ContieneVociTipo
		{
			get { return _ContieneVociTipo; }
			set {
				if (ContieneVociTipo != value)
				{
					_ContieneVociTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SCHEDA_TIPO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SchedaTipo
		{
			get { return _SchedaTipo; }
			set {
				if (SchedaTipo != value)
				{
					_SchedaTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltro
		{
			get { return _DescrizioneFiltro; }
			set {
				if (DescrizioneFiltro != value)
				{
					_DescrizioneFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltro
		{
			get { return _OrdineFiltro; }
			set {
				if (OrdineFiltro != value)
				{
					_OrdineFiltro = value;
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
	/// Summary description for ChecklistGenericaModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ChecklistGenericaModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ChecklistGenericaModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ChecklistGenericaModifiche) info.GetValue(i.ToString(),typeof(ChecklistGenericaModifiche)));
			}
		}

		//Costruttore
		public ChecklistGenericaModificheCollection()
		{
			this.ItemType = typeof(ChecklistGenericaModifiche);
		}

		//Costruttore con provider
		public ChecklistGenericaModificheCollection(IChecklistGenericaModificheProvider providerObj)
		{
			this.ItemType = typeof(ChecklistGenericaModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ChecklistGenericaModifiche this[int index]
		{
			get { return (ChecklistGenericaModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ChecklistGenericaModificheCollection GetChanges()
		{
			return (ChecklistGenericaModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IChecklistGenericaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IChecklistGenericaModificheProvider Provider
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
		public int Add(ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			if (ChecklistGenericaModificheObj.Provider == null) ChecklistGenericaModificheObj.Provider = this.Provider;
			return base.Add(ChecklistGenericaModificheObj);
		}

		//AddCollection
		public void AddCollection(ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionObj)
		{
			foreach (ChecklistGenericaModifiche ChecklistGenericaModificheObj in ChecklistGenericaModificheCollectionObj)
				this.Add(ChecklistGenericaModificheObj);
		}

		//Insert
		public void Insert(int index, ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			if (ChecklistGenericaModificheObj.Provider == null) ChecklistGenericaModificheObj.Provider = this.Provider;
			base.Insert(index, ChecklistGenericaModificheObj);
		}

		//CollectionGetById
		public ChecklistGenericaModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public ChecklistGenericaModificheCollection SubSelect(NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagTemplateEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdTipoEqualThis, NullTypes.StringNT IdFiltroEqualThis, 
NullTypes.StringNT DescrizioneTipoEqualThis, NullTypes.BoolNT ContieneVociTipoEqualThis, NullTypes.BoolNT SchedaTipoEqualThis, 
NullTypes.StringNT DescrizioneFiltroEqualThis, NullTypes.IntNT OrdineFiltroEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdModificaEqualThis)
		{
			ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionTemp = new ChecklistGenericaModificheCollection();
			foreach (ChecklistGenericaModifiche ChecklistGenericaModificheItem in this)
			{
				if (((IdChecklistGenericaEqualThis == null) || ((ChecklistGenericaModificheItem.IdChecklistGenerica != null) && (ChecklistGenericaModificheItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ChecklistGenericaModificheItem.Descrizione != null) && (ChecklistGenericaModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagTemplateEqualThis == null) || ((ChecklistGenericaModificheItem.FlagTemplate != null) && (ChecklistGenericaModificheItem.FlagTemplate.Value == FlagTemplateEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((ChecklistGenericaModificheItem.DataInserimento != null) && (ChecklistGenericaModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((ChecklistGenericaModificheItem.CfInserimento != null) && (ChecklistGenericaModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ChecklistGenericaModificheItem.DataModifica != null) && (ChecklistGenericaModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((CfModificaEqualThis == null) || ((ChecklistGenericaModificheItem.CfModifica != null) && (ChecklistGenericaModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdTipoEqualThis == null) || ((ChecklistGenericaModificheItem.IdTipo != null) && (ChecklistGenericaModificheItem.IdTipo.Value == IdTipoEqualThis.Value))) && ((IdFiltroEqualThis == null) || ((ChecklistGenericaModificheItem.IdFiltro != null) && (ChecklistGenericaModificheItem.IdFiltro.Value == IdFiltroEqualThis.Value))) && 
((DescrizioneTipoEqualThis == null) || ((ChecklistGenericaModificheItem.DescrizioneTipo != null) && (ChecklistGenericaModificheItem.DescrizioneTipo.Value == DescrizioneTipoEqualThis.Value))) && ((ContieneVociTipoEqualThis == null) || ((ChecklistGenericaModificheItem.ContieneVociTipo != null) && (ChecklistGenericaModificheItem.ContieneVociTipo.Value == ContieneVociTipoEqualThis.Value))) && ((SchedaTipoEqualThis == null) || ((ChecklistGenericaModificheItem.SchedaTipo != null) && (ChecklistGenericaModificheItem.SchedaTipo.Value == SchedaTipoEqualThis.Value))) && 
((DescrizioneFiltroEqualThis == null) || ((ChecklistGenericaModificheItem.DescrizioneFiltro != null) && (ChecklistGenericaModificheItem.DescrizioneFiltro.Value == DescrizioneFiltroEqualThis.Value))) && ((OrdineFiltroEqualThis == null) || ((ChecklistGenericaModificheItem.OrdineFiltro != null) && (ChecklistGenericaModificheItem.OrdineFiltro.Value == OrdineFiltroEqualThis.Value))) && ((IdEqualThis == null) || ((ChecklistGenericaModificheItem.Id != null) && (ChecklistGenericaModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdModificaEqualThis == null) || ((ChecklistGenericaModificheItem.IdModifica != null) && (ChecklistGenericaModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					ChecklistGenericaModificheCollectionTemp.Add(ChecklistGenericaModificheItem);
				}
			}
			return ChecklistGenericaModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ChecklistGenericaModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ChecklistGenericaModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ChecklistGenericaModifiche ChecklistGenericaModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ChecklistGenericaModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistGenerica", ChecklistGenericaModificheObj.IdChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ChecklistGenericaModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplate", ChecklistGenericaModificheObj.FlagTemplate);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ChecklistGenericaModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", ChecklistGenericaModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ChecklistGenericaModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", ChecklistGenericaModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipo", ChecklistGenericaModificheObj.IdTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFiltro", ChecklistGenericaModificheObj.IdFiltro);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneTipo", ChecklistGenericaModificheObj.DescrizioneTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "ContieneVociTipo", ChecklistGenericaModificheObj.ContieneVociTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "SchedaTipo", ChecklistGenericaModificheObj.SchedaTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneFiltro", ChecklistGenericaModificheObj.DescrizioneFiltro);
			DbProvider.SetCmdParam(cmd,firstChar + "OrdineFiltro", ChecklistGenericaModificheObj.OrdineFiltro);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", ChecklistGenericaModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZChecklistGenericaModificheInsert", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", "IdTipo", "IdFiltro", 
"DescrizioneTipo", "ContieneVociTipo", "SchedaTipo", 
"DescrizioneFiltro", "OrdineFiltro", 
"IdModifica"}, new string[] {"int", "string", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"string", "bool", "bool", 
"string", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,ChecklistGenericaModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ChecklistGenericaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaModificheObj.IsDirty = false;
				ChecklistGenericaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZChecklistGenericaModificheUpdate", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", "IdTipo", "IdFiltro", 
"DescrizioneTipo", "ContieneVociTipo", "SchedaTipo", 
"DescrizioneFiltro", "OrdineFiltro", "Id", 
"IdModifica"}, new string[] {"int", "string", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"string", "bool", "bool", 
"string", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,ChecklistGenericaModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ChecklistGenericaModificheObj.DataModifica = d;
				}
				ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaModificheObj.IsDirty = false;
				ChecklistGenericaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			switch (ChecklistGenericaModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ChecklistGenericaModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ChecklistGenericaModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ChecklistGenericaModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZChecklistGenericaModificheUpdate", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", "IdTipo", "IdFiltro", 
"DescrizioneTipo", "ContieneVociTipo", "SchedaTipo", 
"DescrizioneFiltro", "OrdineFiltro", "Id", 
"IdModifica"}, new string[] {"int", "string", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"string", "bool", "bool", 
"string", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZChecklistGenericaModificheInsert", new string[] {"IdChecklistGenerica", "Descrizione", "FlagTemplate", 
"DataInserimento", "CfInserimento", "DataModifica", 
"CfModifica", "IdTipo", "IdFiltro", 
"DescrizioneTipo", "ContieneVociTipo", "SchedaTipo", 
"DescrizioneFiltro", "OrdineFiltro", 
"IdModifica"}, new string[] {"int", "string", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"string", "bool", "bool", 
"string", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ChecklistGenericaModificheCollectionObj.Count; i++)
				{
					switch (ChecklistGenericaModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ChecklistGenericaModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ChecklistGenericaModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ChecklistGenericaModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ChecklistGenericaModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ChecklistGenericaModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ChecklistGenericaModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ChecklistGenericaModificheCollectionObj.Count; i++)
				{
					if ((ChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						ChecklistGenericaModificheCollectionObj[i].IsPersistent = true;
					}
					if ((ChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						ChecklistGenericaModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ChecklistGenericaModifiche ChecklistGenericaModificheObj)
		{
			int returnValue = 0;
			if (ChecklistGenericaModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, ChecklistGenericaModificheObj.Id);
			}
			ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ChecklistGenericaModificheObj.IsDirty = false;
			ChecklistGenericaModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ChecklistGenericaModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ChecklistGenericaModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ChecklistGenericaModificheCollectionObj.Count; i++)
				{
					if ((ChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						ChecklistGenericaModificheCollectionObj[i].IsPersistent = false;
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
		public static ChecklistGenericaModifiche GetById(DbProvider db, int IdValue)
		{
			ChecklistGenericaModifiche ChecklistGenericaModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZChecklistGenericaModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ChecklistGenericaModificheObj = GetFromDatareader(db);
				ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaModificheObj.IsDirty = false;
				ChecklistGenericaModificheObj.IsPersistent = true;
			}
			db.Close();
			return ChecklistGenericaModificheObj;
		}

		//getFromDatareader
		public static ChecklistGenericaModifiche GetFromDatareader(DbProvider db)
		{
			ChecklistGenericaModifiche ChecklistGenericaModificheObj = new ChecklistGenericaModifiche();
			ChecklistGenericaModificheObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			ChecklistGenericaModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ChecklistGenericaModificheObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			ChecklistGenericaModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ChecklistGenericaModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			ChecklistGenericaModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ChecklistGenericaModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			ChecklistGenericaModificheObj.IdTipo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO"]);
			ChecklistGenericaModificheObj.IdFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO"]);
			ChecklistGenericaModificheObj.DescrizioneTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_TIPO"]);
			ChecklistGenericaModificheObj.ContieneVociTipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CONTIENE_VOCI_TIPO"]);
			ChecklistGenericaModificheObj.SchedaTipo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SCHEDA_TIPO"]);
			ChecklistGenericaModificheObj.DescrizioneFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO"]);
			ChecklistGenericaModificheObj.OrdineFiltro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO"]);
			ChecklistGenericaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ChecklistGenericaModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ChecklistGenericaModificheObj.IsDirty = false;
			ChecklistGenericaModificheObj.IsPersistent = true;
			return ChecklistGenericaModificheObj;
		}

		//Find Select

		public static ChecklistGenericaModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneTipoEqualThis, SiarLibrary.NullTypes.BoolNT ContieneVociTipoEqualThis, SiarLibrary.NullTypes.BoolNT SchedaTipoEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneFiltroEqualThis, SiarLibrary.NullTypes.IntNT OrdineFiltroEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionObj = new ChecklistGenericaModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zchecklistgenericamodifichefindselect", new string[] {"IdChecklistGenericaequalthis", "Descrizioneequalthis", "FlagTemplateequalthis", 
"DataInserimentoequalthis", "CfInserimentoequalthis", "DataModificaequalthis", 
"CfModificaequalthis", "IdTipoequalthis", "IdFiltroequalthis", 
"DescrizioneTipoequalthis", "ContieneVociTipoequalthis", "SchedaTipoequalthis", 
"DescrizioneFiltroequalthis", "OrdineFiltroequalthis", "Idequalthis", 
"IdModificaequalthis"}, new string[] {"int", "string", "bool", 
"DateTime", "string", "DateTime", 
"string", "int", "string", 
"string", "bool", "bool", 
"string", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoequalthis", IdTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneTipoequalthis", DescrizioneTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContieneVociTipoequalthis", ContieneVociTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SchedaTipoequalthis", SchedaTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneFiltroequalthis", DescrizioneFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFiltroequalthis", OrdineFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			ChecklistGenericaModifiche ChecklistGenericaModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ChecklistGenericaModificheObj = GetFromDatareader(db);
				ChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ChecklistGenericaModificheObj.IsDirty = false;
				ChecklistGenericaModificheObj.IsPersistent = true;
				ChecklistGenericaModificheCollectionObj.Add(ChecklistGenericaModificheObj);
			}
			db.Close();
			return ChecklistGenericaModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ChecklistGenericaModificheCollectionProvider:IChecklistGenericaModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ChecklistGenericaModificheCollectionProvider : IChecklistGenericaModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ChecklistGenericaModifiche
		protected ChecklistGenericaModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ChecklistGenericaModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ChecklistGenericaModificheCollection(this);
		}

		//Costruttore3: ha in input checklistgenericamodificheCollectionObj - non popola la collection
		public ChecklistGenericaModificheCollectionProvider(ChecklistGenericaModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ChecklistGenericaModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ChecklistGenericaModificheCollection(this);
		}

		//Get e Set
		public ChecklistGenericaModificheCollection CollectionObj
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
		public int SaveCollection(ChecklistGenericaModificheCollection collectionObj)
		{
			return ChecklistGenericaModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ChecklistGenericaModifiche checklistgenericamodificheObj)
		{
			return ChecklistGenericaModificheDAL.Save(_dbProviderObj, checklistgenericamodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ChecklistGenericaModificheCollection collectionObj)
		{
			return ChecklistGenericaModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ChecklistGenericaModifiche checklistgenericamodificheObj)
		{
			return ChecklistGenericaModificheDAL.Delete(_dbProviderObj, checklistgenericamodificheObj);
		}

		//getById
		public ChecklistGenericaModifiche GetById(IntNT IdValue)
		{
			ChecklistGenericaModifiche ChecklistGenericaModificheTemp = ChecklistGenericaModificheDAL.GetById(_dbProviderObj, IdValue);
			if (ChecklistGenericaModificheTemp!=null) ChecklistGenericaModificheTemp.Provider = this;
			return ChecklistGenericaModificheTemp;
		}

		//Select: popola la collection
		public ChecklistGenericaModificheCollection Select(IntNT IdchecklistgenericaEqualThis, StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis, 
DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, 
StringNT CfmodificaEqualThis, IntNT IdtipoEqualThis, StringNT IdfiltroEqualThis, 
StringNT DescrizionetipoEqualThis, BoolNT ContienevocitipoEqualThis, BoolNT SchedatipoEqualThis, 
StringNT DescrizionefiltroEqualThis, IntNT OrdinefiltroEqualThis, IntNT IdEqualThis, 
IntNT IdmodificaEqualThis)
		{
			ChecklistGenericaModificheCollection ChecklistGenericaModificheCollectionTemp = ChecklistGenericaModificheDAL.Select(_dbProviderObj, IdchecklistgenericaEqualThis, DescrizioneEqualThis, FlagtemplateEqualThis, 
DatainserimentoEqualThis, CfinserimentoEqualThis, DatamodificaEqualThis, 
CfmodificaEqualThis, IdtipoEqualThis, IdfiltroEqualThis, 
DescrizionetipoEqualThis, ContienevocitipoEqualThis, SchedatipoEqualThis, 
DescrizionefiltroEqualThis, OrdinefiltroEqualThis, IdEqualThis, 
IdmodificaEqualThis);
			ChecklistGenericaModificheCollectionTemp.Provider = this;
			return ChecklistGenericaModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECKLIST_GENERICA_MODIFICHE>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CHECKLIST_GENERICA_MODIFICHE>
*/
