using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per IstanzaChecklistGenericaModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IIstanzaChecklistGenericaModificheProvider
	{
		int Save(IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj);
		int SaveCollection(IstanzaChecklistGenericaModificheCollection collectionObj);
		int Delete(IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj);
		int DeleteCollection(IstanzaChecklistGenericaModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for IstanzaChecklistGenericaModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class IstanzaChecklistGenericaModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdIstanzaGenerica;
		private NullTypes.IntNT _IdChecklistGenerica;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _FlagTemplate;
		private NullTypes.StringNT _CodFase;
		private NullTypes.IntNT _IdChecklistPadre;
		private NullTypes.IntNT _IdSchedaXChecklist;
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
		[NonSerialized] private IIstanzaChecklistGenericaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIstanzaChecklistGenericaModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public IstanzaChecklistGenericaModifiche()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ISTANZA_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstanzaGenerica
		{
			get { return _IdIstanzaGenerica; }
			set {
				if (IdIstanzaGenerica != value)
				{
					_IdIstanzaGenerica = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:ID_CHECKLIST_PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdChecklistPadre
		{
			get { return _IdChecklistPadre; }
			set {
				if (IdChecklistPadre != value)
				{
					_IdChecklistPadre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SCHEDA_X_CHECKLIST
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSchedaXChecklist
		{
			get { return _IdSchedaXChecklist; }
			set {
				if (IdSchedaXChecklist != value)
				{
					_IdSchedaXChecklist = value;
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
	/// Summary description for IstanzaChecklistGenericaModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IstanzaChecklistGenericaModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IstanzaChecklistGenericaModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((IstanzaChecklistGenericaModifiche) info.GetValue(i.ToString(),typeof(IstanzaChecklistGenericaModifiche)));
			}
		}

		//Costruttore
		public IstanzaChecklistGenericaModificheCollection()
		{
			this.ItemType = typeof(IstanzaChecklistGenericaModifiche);
		}

		//Costruttore con provider
		public IstanzaChecklistGenericaModificheCollection(IIstanzaChecklistGenericaModificheProvider providerObj)
		{
			this.ItemType = typeof(IstanzaChecklistGenericaModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new IstanzaChecklistGenericaModifiche this[int index]
		{
			get { return (IstanzaChecklistGenericaModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IstanzaChecklistGenericaModificheCollection GetChanges()
		{
			return (IstanzaChecklistGenericaModificheCollection) base.GetChanges();
		}

		[NonSerialized] private IIstanzaChecklistGenericaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIstanzaChecklistGenericaModificheProvider Provider
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
		public int Add(IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			if (IstanzaChecklistGenericaModificheObj.Provider == null) IstanzaChecklistGenericaModificheObj.Provider = this.Provider;
			return base.Add(IstanzaChecklistGenericaModificheObj);
		}

		//AddCollection
		public void AddCollection(IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionObj)
		{
			foreach (IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj in IstanzaChecklistGenericaModificheCollectionObj)
				this.Add(IstanzaChecklistGenericaModificheObj);
		}

		//Insert
		public void Insert(int index, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			if (IstanzaChecklistGenericaModificheObj.Provider == null) IstanzaChecklistGenericaModificheObj.Provider = this.Provider;
			base.Insert(index, IstanzaChecklistGenericaModificheObj);
		}

		//CollectionGetById
		public IstanzaChecklistGenericaModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public IstanzaChecklistGenericaModificheCollection SubSelect(NullTypes.IntNT IdIstanzaGenericaEqualThis, NullTypes.IntNT IdChecklistGenericaEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, 
NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagTemplateEqualThis, NullTypes.StringNT CodFaseEqualThis, 
NullTypes.IntNT IdChecklistPadreEqualThis, NullTypes.IntNT IdSchedaXChecklistEqualThis, NullTypes.IntNT IdEqualThis, 
NullTypes.IntNT IdModificaEqualThis)
		{
			IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionTemp = new IstanzaChecklistGenericaModificheCollection();
			foreach (IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheItem in this)
			{
				if (((IdIstanzaGenericaEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.IdIstanzaGenerica != null) && (IstanzaChecklistGenericaModificheItem.IdIstanzaGenerica.Value == IdIstanzaGenericaEqualThis.Value))) && ((IdChecklistGenericaEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.IdChecklistGenerica != null) && (IstanzaChecklistGenericaModificheItem.IdChecklistGenerica.Value == IdChecklistGenericaEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.DataInserimento != null) && (IstanzaChecklistGenericaModificheItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((CfInserimentoEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.CfInserimento != null) && (IstanzaChecklistGenericaModificheItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.DataModifica != null) && (IstanzaChecklistGenericaModificheItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.CfModifica != null) && (IstanzaChecklistGenericaModificheItem.CfModifica.Value == CfModificaEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.Descrizione != null) && (IstanzaChecklistGenericaModificheItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagTemplateEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.FlagTemplate != null) && (IstanzaChecklistGenericaModificheItem.FlagTemplate.Value == FlagTemplateEqualThis.Value))) && ((CodFaseEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.CodFase != null) && (IstanzaChecklistGenericaModificheItem.CodFase.Value == CodFaseEqualThis.Value))) && 
((IdChecklistPadreEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.IdChecklistPadre != null) && (IstanzaChecklistGenericaModificheItem.IdChecklistPadre.Value == IdChecklistPadreEqualThis.Value))) && ((IdSchedaXChecklistEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.IdSchedaXChecklist != null) && (IstanzaChecklistGenericaModificheItem.IdSchedaXChecklist.Value == IdSchedaXChecklistEqualThis.Value))) && ((IdEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.Id != null) && (IstanzaChecklistGenericaModificheItem.Id.Value == IdEqualThis.Value))) && 
((IdModificaEqualThis == null) || ((IstanzaChecklistGenericaModificheItem.IdModifica != null) && (IstanzaChecklistGenericaModificheItem.IdModifica.Value == IdModificaEqualThis.Value))))
				{
					IstanzaChecklistGenericaModificheCollectionTemp.Add(IstanzaChecklistGenericaModificheItem);
				}
			}
			return IstanzaChecklistGenericaModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for IstanzaChecklistGenericaModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class IstanzaChecklistGenericaModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", IstanzaChecklistGenericaModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdIstanzaGenerica", IstanzaChecklistGenericaModificheObj.IdIstanzaGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistGenerica", IstanzaChecklistGenericaModificheObj.IdChecklistGenerica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", IstanzaChecklistGenericaModificheObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", IstanzaChecklistGenericaModificheObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", IstanzaChecklistGenericaModificheObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", IstanzaChecklistGenericaModificheObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", IstanzaChecklistGenericaModificheObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "FlagTemplate", IstanzaChecklistGenericaModificheObj.FlagTemplate);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFase", IstanzaChecklistGenericaModificheObj.CodFase);
			DbProvider.SetCmdParam(cmd,firstChar + "IdChecklistPadre", IstanzaChecklistGenericaModificheObj.IdChecklistPadre);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSchedaXChecklist", IstanzaChecklistGenericaModificheObj.IdSchedaXChecklist);
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", IstanzaChecklistGenericaModificheObj.IdModifica);
		}
		//Insert
		private static int Insert(DbProvider db, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheInsert", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento", 
"CfInserimento", "DataModifica", "CfModifica", 
"Descrizione", "FlagTemplate", "CodFase", 
"IdChecklistPadre", "IdSchedaXChecklist", 
"IdModifica"}, new string[] {"int", "int", "DateTime", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"int", "int", 
"int"},"");
				CompileIUCmd(false, insertCmd,IstanzaChecklistGenericaModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				IstanzaChecklistGenericaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IstanzaChecklistGenericaModificheObj.IsDirty = false;
				IstanzaChecklistGenericaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheUpdate", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento", 
"CfInserimento", "DataModifica", "CfModifica", 
"Descrizione", "FlagTemplate", "CodFase", 
"IdChecklistPadre", "IdSchedaXChecklist", "Id", 
"IdModifica"}, new string[] {"int", "int", "DateTime", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"int", "int", "int", 
"int"},"");
				CompileIUCmd(true, updateCmd,IstanzaChecklistGenericaModificheObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					IstanzaChecklistGenericaModificheObj.DataModifica = d;
				}
				IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IstanzaChecklistGenericaModificheObj.IsDirty = false;
				IstanzaChecklistGenericaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			switch (IstanzaChecklistGenericaModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, IstanzaChecklistGenericaModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, IstanzaChecklistGenericaModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,IstanzaChecklistGenericaModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheUpdate", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento", 
"CfInserimento", "DataModifica", "CfModifica", 
"Descrizione", "FlagTemplate", "CodFase", 
"IdChecklistPadre", "IdSchedaXChecklist", "Id", 
"IdModifica"}, new string[] {"int", "int", "DateTime", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"int", "int", "int", 
"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheInsert", new string[] {"IdIstanzaGenerica", "IdChecklistGenerica", "DataInserimento", 
"CfInserimento", "DataModifica", "CfModifica", 
"Descrizione", "FlagTemplate", "CodFase", 
"IdChecklistPadre", "IdSchedaXChecklist", 
"IdModifica"}, new string[] {"int", "int", "DateTime", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"int", "int", 
"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < IstanzaChecklistGenericaModificheCollectionObj.Count; i++)
				{
					switch (IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,IstanzaChecklistGenericaModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									IstanzaChecklistGenericaModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,IstanzaChecklistGenericaModificheCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									IstanzaChecklistGenericaModificheCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (IstanzaChecklistGenericaModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IstanzaChecklistGenericaModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < IstanzaChecklistGenericaModificheCollectionObj.Count; i++)
				{
					if ((IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsPersistent = true;
					}
					if ((IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj)
		{
			int returnValue = 0;
			if (IstanzaChecklistGenericaModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, IstanzaChecklistGenericaModificheObj.Id);
			}
			IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			IstanzaChecklistGenericaModificheObj.IsDirty = false;
			IstanzaChecklistGenericaModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < IstanzaChecklistGenericaModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", IstanzaChecklistGenericaModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < IstanzaChecklistGenericaModificheCollectionObj.Count; i++)
				{
					if ((IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						IstanzaChecklistGenericaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsDirty = false;
						IstanzaChecklistGenericaModificheCollectionObj[i].IsPersistent = false;
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
		public static IstanzaChecklistGenericaModifiche GetById(DbProvider db, int IdValue)
		{
			IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZIstanzaChecklistGenericaModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				IstanzaChecklistGenericaModificheObj = GetFromDatareader(db);
				IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IstanzaChecklistGenericaModificheObj.IsDirty = false;
				IstanzaChecklistGenericaModificheObj.IsPersistent = true;
			}
			db.Close();
			return IstanzaChecklistGenericaModificheObj;
		}

		//getFromDatareader
		public static IstanzaChecklistGenericaModifiche GetFromDatareader(DbProvider db)
		{
			IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj = new IstanzaChecklistGenericaModifiche();
			IstanzaChecklistGenericaModificheObj.IdIstanzaGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTANZA_GENERICA"]);
			IstanzaChecklistGenericaModificheObj.IdChecklistGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_GENERICA"]);
			IstanzaChecklistGenericaModificheObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			IstanzaChecklistGenericaModificheObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			IstanzaChecklistGenericaModificheObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			IstanzaChecklistGenericaModificheObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			IstanzaChecklistGenericaModificheObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			IstanzaChecklistGenericaModificheObj.FlagTemplate = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_TEMPLATE"]);
			IstanzaChecklistGenericaModificheObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			IstanzaChecklistGenericaModificheObj.IdChecklistPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CHECKLIST_PADRE"]);
			IstanzaChecklistGenericaModificheObj.IdSchedaXChecklist = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_X_CHECKLIST"]);
			IstanzaChecklistGenericaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			IstanzaChecklistGenericaModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			IstanzaChecklistGenericaModificheObj.IsDirty = false;
			IstanzaChecklistGenericaModificheObj.IsPersistent = true;
			return IstanzaChecklistGenericaModificheObj;
		}

		//Find Select

		public static IstanzaChecklistGenericaModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdIstanzaGenericaEqualThis, SiarLibrary.NullTypes.IntNT IdChecklistGenericaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagTemplateEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, 
SiarLibrary.NullTypes.IntNT IdChecklistPadreEqualThis, SiarLibrary.NullTypes.IntNT IdSchedaXChecklistEqualThis, SiarLibrary.NullTypes.IntNT IdEqualThis, 
SiarLibrary.NullTypes.IntNT IdModificaEqualThis)

		{

			IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionObj = new IstanzaChecklistGenericaModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zistanzachecklistgenericamodifichefindselect", new string[] {"IdIstanzaGenericaequalthis", "IdChecklistGenericaequalthis", "DataInserimentoequalthis", 
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis", 
"Descrizioneequalthis", "FlagTemplateequalthis", "CodFaseequalthis", 
"IdChecklistPadreequalthis", "IdSchedaXChecklistequalthis", "Idequalthis", 
"IdModificaequalthis"}, new string[] {"int", "int", "DateTime", 
"string", "DateTime", "string", 
"string", "bool", "string", 
"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstanzaGenericaequalthis", IdIstanzaGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistGenericaequalthis", IdChecklistGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FlagTemplateequalthis", FlagTemplateEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdChecklistPadreequalthis", IdChecklistPadreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSchedaXChecklistequalthis", IdSchedaXChecklistEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
			IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				IstanzaChecklistGenericaModificheObj = GetFromDatareader(db);
				IstanzaChecklistGenericaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				IstanzaChecklistGenericaModificheObj.IsDirty = false;
				IstanzaChecklistGenericaModificheObj.IsPersistent = true;
				IstanzaChecklistGenericaModificheCollectionObj.Add(IstanzaChecklistGenericaModificheObj);
			}
			db.Close();
			return IstanzaChecklistGenericaModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for IstanzaChecklistGenericaModificheCollectionProvider:IIstanzaChecklistGenericaModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class IstanzaChecklistGenericaModificheCollectionProvider : IIstanzaChecklistGenericaModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IstanzaChecklistGenericaModifiche
		protected IstanzaChecklistGenericaModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IstanzaChecklistGenericaModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IstanzaChecklistGenericaModificheCollection(this);
		}

		//Costruttore3: ha in input istanzachecklistgenericamodificheCollectionObj - non popola la collection
		public IstanzaChecklistGenericaModificheCollectionProvider(IstanzaChecklistGenericaModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IstanzaChecklistGenericaModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IstanzaChecklistGenericaModificheCollection(this);
		}

		//Get e Set
		public IstanzaChecklistGenericaModificheCollection CollectionObj
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
		public int SaveCollection(IstanzaChecklistGenericaModificheCollection collectionObj)
		{
			return IstanzaChecklistGenericaModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IstanzaChecklistGenericaModifiche istanzachecklistgenericamodificheObj)
		{
			return IstanzaChecklistGenericaModificheDAL.Save(_dbProviderObj, istanzachecklistgenericamodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IstanzaChecklistGenericaModificheCollection collectionObj)
		{
			return IstanzaChecklistGenericaModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IstanzaChecklistGenericaModifiche istanzachecklistgenericamodificheObj)
		{
			return IstanzaChecklistGenericaModificheDAL.Delete(_dbProviderObj, istanzachecklistgenericamodificheObj);
		}

		//getById
		public IstanzaChecklistGenericaModifiche GetById(IntNT IdValue)
		{
			IstanzaChecklistGenericaModifiche IstanzaChecklistGenericaModificheTemp = IstanzaChecklistGenericaModificheDAL.GetById(_dbProviderObj, IdValue);
			if (IstanzaChecklistGenericaModificheTemp!=null) IstanzaChecklistGenericaModificheTemp.Provider = this;
			return IstanzaChecklistGenericaModificheTemp;
		}

		//Select: popola la collection
		public IstanzaChecklistGenericaModificheCollection Select(IntNT IdistanzagenericaEqualThis, IntNT IdchecklistgenericaEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, 
StringNT DescrizioneEqualThis, BoolNT FlagtemplateEqualThis, StringNT CodfaseEqualThis, 
IntNT IdchecklistpadreEqualThis, IntNT IdschedaxchecklistEqualThis, IntNT IdEqualThis, 
IntNT IdmodificaEqualThis)
		{
			IstanzaChecklistGenericaModificheCollection IstanzaChecklistGenericaModificheCollectionTemp = IstanzaChecklistGenericaModificheDAL.Select(_dbProviderObj, IdistanzagenericaEqualThis, IdchecklistgenericaEqualThis, DatainserimentoEqualThis, 
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis, 
DescrizioneEqualThis, FlagtemplateEqualThis, CodfaseEqualThis, 
IdchecklistpadreEqualThis, IdschedaxchecklistEqualThis, IdEqualThis, 
IdmodificaEqualThis);
			IstanzaChecklistGenericaModificheCollectionTemp.Provider = this;
			return IstanzaChecklistGenericaModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ISTANZA_CHECKLIST_GENERICA_MODIFICHE>
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
</ISTANZA_CHECKLIST_GENERICA_MODIFICHE>
*/
