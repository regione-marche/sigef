using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PageHelp
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPageHelpProvider
	{
		int Save(PageHelp PageHelpObj);
		int SaveCollection(PageHelpCollection collectionObj);
		int Delete(PageHelp PageHelpObj);
		int DeleteCollection(PageHelpCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PageHelp
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PageHelp: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _Page;
		private NullTypes.StringNT _Parametri;
		private NullTypes.IntNT _IdDoc;
		private NullTypes.IntNT _IdPdf;
		private NullTypes.IntNT _Operatore;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.IntNT _Dimensione;
		[NonSerialized] private IPageHelpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPageHelpProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PageHelp()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:PAGE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Page
		{
			get { return _Page; }
			set {
				if (Page != value)
				{
					_Page = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PARAMETRI
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Parametri
		{
			get { return _Parametri; }
			set {
				if (Parametri != value)
				{
					_Parametri = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DOC
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDoc
		{
			get { return _IdDoc; }
			set {
				if (IdDoc != value)
				{
					_IdDoc = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PDF
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPdf
		{
			get { return _IdPdf; }
			set {
				if (IdPdf != value)
				{
					_IdPdf = value;
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
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((1))
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOME_FILE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT NomeFile
		{
			get { return _NomeFile; }
			set {
				if (NomeFile != value)
				{
					_NomeFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Dimensione
		{
			get { return _Dimensione; }
			set {
				if (Dimensione != value)
				{
					_Dimensione = value;
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
	/// Summary description for PageHelpCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PageHelpCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PageHelpCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PageHelp) info.GetValue(i.ToString(),typeof(PageHelp)));
			}
		}

		//Costruttore
		public PageHelpCollection()
		{
			this.ItemType = typeof(PageHelp);
		}

		//Costruttore con provider
		public PageHelpCollection(IPageHelpProvider providerObj)
		{
			this.ItemType = typeof(PageHelp);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PageHelp this[int index]
		{
			get { return (PageHelp)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PageHelpCollection GetChanges()
		{
			return (PageHelpCollection) base.GetChanges();
		}

		[NonSerialized] private IPageHelpProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPageHelpProvider Provider
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
		public int Add(PageHelp PageHelpObj)
		{
			if (PageHelpObj.Provider == null) PageHelpObj.Provider = this.Provider;
			return base.Add(PageHelpObj);
		}

		//AddCollection
		public void AddCollection(PageHelpCollection PageHelpCollectionObj)
		{
			foreach (PageHelp PageHelpObj in PageHelpCollectionObj)
				this.Add(PageHelpObj);
		}

		//Insert
		public void Insert(int index, PageHelp PageHelpObj)
		{
			if (PageHelpObj.Provider == null) PageHelpObj.Provider = this.Provider;
			base.Insert(index, PageHelpObj);
		}

		//CollectionGetById
		public PageHelp CollectionGetById(NullTypes.IntNT IdValue)
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
		public PageHelpCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT PageEqualThis, NullTypes.StringNT ParametriEqualThis, 
NullTypes.IntNT IdDocEqualThis, NullTypes.IntNT IdPdfEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			PageHelpCollection PageHelpCollectionTemp = new PageHelpCollection();
			foreach (PageHelp PageHelpItem in this)
			{
				if (((IdEqualThis == null) || ((PageHelpItem.Id != null) && (PageHelpItem.Id.Value == IdEqualThis.Value))) && ((PageEqualThis == null) || ((PageHelpItem.Page != null) && (PageHelpItem.Page.Value == PageEqualThis.Value))) && ((ParametriEqualThis == null) || ((PageHelpItem.Parametri != null) && (PageHelpItem.Parametri.Value == ParametriEqualThis.Value))) && 
((IdDocEqualThis == null) || ((PageHelpItem.IdDoc != null) && (PageHelpItem.IdDoc.Value == IdDocEqualThis.Value))) && ((IdPdfEqualThis == null) || ((PageHelpItem.IdPdf != null) && (PageHelpItem.IdPdf.Value == IdPdfEqualThis.Value))) && ((OperatoreEqualThis == null) || ((PageHelpItem.Operatore != null) && (PageHelpItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((DataEqualThis == null) || ((PageHelpItem.Data != null) && (PageHelpItem.Data.Value == DataEqualThis.Value))) && ((AttivoEqualThis == null) || ((PageHelpItem.Attivo != null) && (PageHelpItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					PageHelpCollectionTemp.Add(PageHelpItem);
				}
			}
			return PageHelpCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PageHelpDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PageHelpDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PageHelp PageHelpObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", PageHelpObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Page", PageHelpObj.Page);
			DbProvider.SetCmdParam(cmd,firstChar + "Parametri", PageHelpObj.Parametri);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDoc", PageHelpObj.IdDoc);
			DbProvider.SetCmdParam(cmd,firstChar + "IdPdf", PageHelpObj.IdPdf);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", PageHelpObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", PageHelpObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", PageHelpObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, PageHelp PageHelpObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPageHelpInsert", new string[] {"Page", "Parametri", 
"IdDoc", "IdPdf", "Operatore", 
"Data", "Attivo", }, new string[] {"string", "string", 
"int", "int", "int", 
"DateTime", "bool", },"");
				CompileIUCmd(false, insertCmd,PageHelpObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PageHelpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				PageHelpObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PageHelpObj.IsDirty = false;
				PageHelpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PageHelp PageHelpObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPageHelpUpdate", new string[] {"Id", "Page", "Parametri", 
"IdDoc", "IdPdf", "Operatore", 
"Data", "Attivo", }, new string[] {"int", "string", "string", 
"int", "int", "int", 
"DateTime", "bool", },"");
				CompileIUCmd(true, updateCmd,PageHelpObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PageHelpObj.IsDirty = false;
				PageHelpObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PageHelp PageHelpObj)
		{
			switch (PageHelpObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PageHelpObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PageHelpObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PageHelpObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PageHelpCollection PageHelpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPageHelpUpdate", new string[] {"Id", "Page", "Parametri", 
"IdDoc", "IdPdf", "Operatore", 
"Data", "Attivo", }, new string[] {"int", "string", "string", 
"int", "int", "int", 
"DateTime", "bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZPageHelpInsert", new string[] {"Page", "Parametri", 
"IdDoc", "IdPdf", "Operatore", 
"Data", "Attivo", }, new string[] {"string", "string", 
"int", "int", "int", 
"DateTime", "bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZPageHelpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PageHelpCollectionObj.Count; i++)
				{
					switch (PageHelpCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PageHelpCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PageHelpCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									PageHelpCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PageHelpCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PageHelpCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)PageHelpCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PageHelpCollectionObj.Count; i++)
				{
					if ((PageHelpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PageHelpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PageHelpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PageHelpCollectionObj[i].IsDirty = false;
						PageHelpCollectionObj[i].IsPersistent = true;
					}
					if ((PageHelpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PageHelpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PageHelpCollectionObj[i].IsDirty = false;
						PageHelpCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PageHelp PageHelpObj)
		{
			int returnValue = 0;
			if (PageHelpObj.IsPersistent) 
			{
				returnValue = Delete(db, PageHelpObj.Id);
			}
			PageHelpObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PageHelpObj.IsDirty = false;
			PageHelpObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPageHelpDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PageHelpCollection PageHelpCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPageHelpDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < PageHelpCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", PageHelpCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PageHelpCollectionObj.Count; i++)
				{
					if ((PageHelpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PageHelpCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PageHelpCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PageHelpCollectionObj[i].IsDirty = false;
						PageHelpCollectionObj[i].IsPersistent = false;
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
		public static PageHelp GetById(DbProvider db, int IdValue)
		{
			PageHelp PageHelpObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPageHelpGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PageHelpObj = GetFromDatareader(db);
				PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PageHelpObj.IsDirty = false;
				PageHelpObj.IsPersistent = true;
			}
			db.Close();
			return PageHelpObj;
		}

		//getFromDatareader
		public static PageHelp GetFromDatareader(DbProvider db)
		{
			PageHelp PageHelpObj = new PageHelp();
			PageHelpObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			PageHelpObj.Page = new SiarLibrary.NullTypes.StringNT(db.DataReader["PAGE"]);
			PageHelpObj.Parametri = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARAMETRI"]);
			PageHelpObj.IdDoc = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOC"]);
			PageHelpObj.IdPdf = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PDF"]);
			PageHelpObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			PageHelpObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			PageHelpObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			PageHelpObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			PageHelpObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			PageHelpObj.Dimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE"]);
			PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PageHelpObj.IsDirty = false;
			PageHelpObj.IsPersistent = true;
			return PageHelpObj;
		}

		//Find Select

		public static PageHelpCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT PageEqualThis, SiarLibrary.NullTypes.StringNT ParametriEqualThis, 
SiarLibrary.NullTypes.IntNT IdDocEqualThis, SiarLibrary.NullTypes.IntNT IdPdfEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			PageHelpCollection PageHelpCollectionObj = new PageHelpCollection();

			IDbCommand findCmd = db.InitCmd("Zpagehelpfindselect", new string[] {"Idequalthis", "Pageequalthis", "Parametriequalthis", 
"IdDocequalthis", "IdPdfequalthis", "Operatoreequalthis", 
"Dataequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"int", "int", "int", 
"DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pageequalthis", PageEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Parametriequalthis", ParametriEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDocequalthis", IdDocEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPdfequalthis", IdPdfEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			PageHelp PageHelpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PageHelpObj = GetFromDatareader(db);
				PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PageHelpObj.IsDirty = false;
				PageHelpObj.IsPersistent = true;
				PageHelpCollectionObj.Add(PageHelpObj);
			}
			db.Close();
			return PageHelpCollectionObj;
		}

		//Find Find

		public static PageHelpCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT PageEqualThis, SiarLibrary.NullTypes.StringNT ParametriLikeThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			PageHelpCollection PageHelpCollectionObj = new PageHelpCollection();

			IDbCommand findCmd = db.InitCmd("Zpagehelpfindfind", new string[] {"Pageequalthis", "Parametrilikethis", "Attivoequalthis"}, new string[] {"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pageequalthis", PageEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Parametrilikethis", ParametriLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			PageHelp PageHelpObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PageHelpObj = GetFromDatareader(db);
				PageHelpObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PageHelpObj.IsDirty = false;
				PageHelpObj.IsPersistent = true;
				PageHelpCollectionObj.Add(PageHelpObj);
			}
			db.Close();
			return PageHelpCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PageHelpCollectionProvider:IPageHelpProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PageHelpCollectionProvider : IPageHelpProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PageHelp
		protected PageHelpCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PageHelpCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PageHelpCollection(this);
		}

		//Costruttore 2: popola la collection
		public PageHelpCollectionProvider(StringNT PageEqualThis, StringNT ParametriLikeThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(PageEqualThis, ParametriLikeThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input pagehelpCollectionObj - non popola la collection
		public PageHelpCollectionProvider(PageHelpCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PageHelpCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PageHelpCollection(this);
		}

		//Get e Set
		public PageHelpCollection CollectionObj
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
		public int SaveCollection(PageHelpCollection collectionObj)
		{
			return PageHelpDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PageHelp pagehelpObj)
		{
			return PageHelpDAL.Save(_dbProviderObj, pagehelpObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PageHelpCollection collectionObj)
		{
			return PageHelpDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PageHelp pagehelpObj)
		{
			return PageHelpDAL.Delete(_dbProviderObj, pagehelpObj);
		}

		//getById
		public PageHelp GetById(IntNT IdValue)
		{
			PageHelp PageHelpTemp = PageHelpDAL.GetById(_dbProviderObj, IdValue);
			if (PageHelpTemp!=null) PageHelpTemp.Provider = this;
			return PageHelpTemp;
		}

		//Select: popola la collection
		public PageHelpCollection Select(IntNT IdEqualThis, StringNT PageEqualThis, StringNT ParametriEqualThis, 
IntNT IddocEqualThis, IntNT IdpdfEqualThis, IntNT OperatoreEqualThis, 
DatetimeNT DataEqualThis, BoolNT AttivoEqualThis)
		{
			PageHelpCollection PageHelpCollectionTemp = PageHelpDAL.Select(_dbProviderObj, IdEqualThis, PageEqualThis, ParametriEqualThis, 
IddocEqualThis, IdpdfEqualThis, OperatoreEqualThis, 
DataEqualThis, AttivoEqualThis);
			PageHelpCollectionTemp.Provider = this;
			return PageHelpCollectionTemp;
		}

		//Find: popola la collection
		public PageHelpCollection Find(StringNT PageEqualThis, StringNT ParametriLikeThis, BoolNT AttivoEqualThis)
		{
			PageHelpCollection PageHelpCollectionTemp = PageHelpDAL.Find(_dbProviderObj, PageEqualThis, ParametriLikeThis, AttivoEqualThis);
			PageHelpCollectionTemp.Provider = this;
			return PageHelpCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGE_HELP>
  <ViewName>vPAGE_HELP</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, DATA DESC">
      <PAGE>Equal</PAGE>
      <PARAMETRI>Like</PARAMETRI>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PAGE_HELP>
*/
