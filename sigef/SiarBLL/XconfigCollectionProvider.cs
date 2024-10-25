using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Xconfig
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IXconfigProvider
	{
		int Save(Xconfig XconfigObj);
		int SaveCollection(XconfigCollection collectionObj);
		int Delete(Xconfig XconfigObj);
		int DeleteCollection(XconfigCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Xconfig
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Xconfig: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _TipoConfigurazione;
		private NullTypes.StringNT _Login;
		private NullTypes.StringNT _Pwd;
		private NullTypes.StringNT _Dominio;
		private NullTypes.StringNT _IpInterno;
		private NullTypes.StringNT _DefaultDirectory;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _Ruolo;
		private NullTypes.StringNT _CodiceUo;
		private NullTypes.StringNT _WsBinding;
		private NullTypes.DatetimeNT _Data;
		[NonSerialized] private IXconfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IXconfigProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Xconfig()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:TIPO_CONFIGURAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoConfigurazione
		{
			get { return _TipoConfigurazione; }
			set {
				if (TipoConfigurazione != value)
				{
					_TipoConfigurazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LOGIN
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Login
		{
			get { return _Login; }
			set {
				if (Login != value)
				{
					_Login = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PWD
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Pwd
		{
			get { return _Pwd; }
			set {
				if (Pwd != value)
				{
					_Pwd = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DOMINIO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Dominio
		{
			get { return _Dominio; }
			set {
				if (Dominio != value)
				{
					_Dominio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IP_INTERNO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT IpInterno
		{
			get { return _IpInterno; }
			set {
				if (IpInterno != value)
				{
					_IpInterno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DEFAULT_DIRECTORY
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DefaultDirectory
		{
			get { return _DefaultDirectory; }
			set {
				if (DefaultDirectory != value)
				{
					_DefaultDirectory = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
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
		/// Corrisponde al campo:NOME
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Nome
		{
			get { return _Nome; }
			set {
				if (Nome != value)
				{
					_Nome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COGNOME
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Cognome
		{
			get { return _Cognome; }
			set {
				if (Cognome != value)
				{
					_Cognome = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Ruolo
		{
			get { return _Ruolo; }
			set {
				if (Ruolo != value)
				{
					_Ruolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_UO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT CodiceUo
		{
			get { return _CodiceUo; }
			set {
				if (CodiceUo != value)
				{
					_CodiceUo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:WS_BINDING
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT WsBinding
		{
			get { return _WsBinding; }
			set {
				if (WsBinding != value)
				{
					_WsBinding = value;
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
	/// Summary description for XconfigCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class XconfigCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private XconfigCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Xconfig) info.GetValue(i.ToString(),typeof(Xconfig)));
			}
		}

		//Costruttore
		public XconfigCollection()
		{
			this.ItemType = typeof(Xconfig);
		}

		//Costruttore con provider
		public XconfigCollection(IXconfigProvider providerObj)
		{
			this.ItemType = typeof(Xconfig);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Xconfig this[int index]
		{
			get { return (Xconfig)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new XconfigCollection GetChanges()
		{
			return (XconfigCollection) base.GetChanges();
		}

		[NonSerialized] private IXconfigProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IXconfigProvider Provider
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
		public int Add(Xconfig XconfigObj)
		{
			if (XconfigObj.Provider == null) XconfigObj.Provider = this.Provider;
			return base.Add(XconfigObj);
		}

		//AddCollection
		public void AddCollection(XconfigCollection XconfigCollectionObj)
		{
			foreach (Xconfig XconfigObj in XconfigCollectionObj)
				this.Add(XconfigObj);
		}

		//Insert
		public void Insert(int index, Xconfig XconfigObj)
		{
			if (XconfigObj.Provider == null) XconfigObj.Provider = this.Provider;
			base.Insert(index, XconfigObj);
		}

		//CollectionGetById
		public Xconfig CollectionGetById(NullTypes.StringNT TipoConfigurazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].TipoConfigurazione == TipoConfigurazioneValue))
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
		public XconfigCollection SubSelect(NullTypes.StringNT TipoConfigurazioneEqualThis, NullTypes.StringNT LoginEqualThis, NullTypes.StringNT PwdEqualThis, 
NullTypes.StringNT DominioEqualThis, NullTypes.StringNT IpInternoEqualThis, NullTypes.StringNT DefaultDirectoryEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.StringNT NomeEqualThis, NullTypes.StringNT CognomeEqualThis, 
NullTypes.StringNT RuoloEqualThis, NullTypes.StringNT CodiceUoEqualThis, NullTypes.StringNT WsBindingEqualThis, 
NullTypes.DatetimeNT DataEqualThis)
		{
			XconfigCollection XconfigCollectionTemp = new XconfigCollection();
			foreach (Xconfig XconfigItem in this)
			{
				if (((TipoConfigurazioneEqualThis == null) || ((XconfigItem.TipoConfigurazione != null) && (XconfigItem.TipoConfigurazione.Value == TipoConfigurazioneEqualThis.Value))) && ((LoginEqualThis == null) || ((XconfigItem.Login != null) && (XconfigItem.Login.Value == LoginEqualThis.Value))) && ((PwdEqualThis == null) || ((XconfigItem.Pwd != null) && (XconfigItem.Pwd.Value == PwdEqualThis.Value))) && 
((DominioEqualThis == null) || ((XconfigItem.Dominio != null) && (XconfigItem.Dominio.Value == DominioEqualThis.Value))) && ((IpInternoEqualThis == null) || ((XconfigItem.IpInterno != null) && (XconfigItem.IpInterno.Value == IpInternoEqualThis.Value))) && ((DefaultDirectoryEqualThis == null) || ((XconfigItem.DefaultDirectory != null) && (XconfigItem.DefaultDirectory.Value == DefaultDirectoryEqualThis.Value))) && 
((AttivoEqualThis == null) || ((XconfigItem.Attivo != null) && (XconfigItem.Attivo.Value == AttivoEqualThis.Value))) && ((NomeEqualThis == null) || ((XconfigItem.Nome != null) && (XconfigItem.Nome.Value == NomeEqualThis.Value))) && ((CognomeEqualThis == null) || ((XconfigItem.Cognome != null) && (XconfigItem.Cognome.Value == CognomeEqualThis.Value))) && 
((RuoloEqualThis == null) || ((XconfigItem.Ruolo != null) && (XconfigItem.Ruolo.Value == RuoloEqualThis.Value))) && ((CodiceUoEqualThis == null) || ((XconfigItem.CodiceUo != null) && (XconfigItem.CodiceUo.Value == CodiceUoEqualThis.Value))) && ((WsBindingEqualThis == null) || ((XconfigItem.WsBinding != null) && (XconfigItem.WsBinding.Value == WsBindingEqualThis.Value))) && 
((DataEqualThis == null) || ((XconfigItem.Data != null) && (XconfigItem.Data.Value == DataEqualThis.Value))))
				{
					XconfigCollectionTemp.Add(XconfigItem);
				}
			}
			return XconfigCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for XconfigDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class XconfigDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Xconfig XconfigObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "TipoConfigurazione", XconfigObj.TipoConfigurazione);
			DbProvider.SetCmdParam(cmd,firstChar + "Login", XconfigObj.Login);
			DbProvider.SetCmdParam(cmd,firstChar + "Pwd", XconfigObj.Pwd);
			DbProvider.SetCmdParam(cmd,firstChar + "Dominio", XconfigObj.Dominio);
			DbProvider.SetCmdParam(cmd,firstChar + "IpInterno", XconfigObj.IpInterno);
			DbProvider.SetCmdParam(cmd,firstChar + "DefaultDirectory", XconfigObj.DefaultDirectory);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", XconfigObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", XconfigObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Cognome", XconfigObj.Cognome);
			DbProvider.SetCmdParam(cmd,firstChar + "Ruolo", XconfigObj.Ruolo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceUo", XconfigObj.CodiceUo);
			DbProvider.SetCmdParam(cmd,firstChar + "WsBinding", XconfigObj.WsBinding);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", XconfigObj.Data);
		}
		//Insert
		private static int Insert(DbProvider db, Xconfig XconfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZXconfigInsert", new string[] {"TipoConfigurazione", "Login", "Pwd", 
"Dominio", "IpInterno", "DefaultDirectory", 
"Attivo", "Nome", "Cognome", 
"Ruolo", "CodiceUo", "WsBinding", 
"Data"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"DateTime"},"");
				CompileIUCmd(false, insertCmd,XconfigObj, db.CommandFirstChar);
				i = db.Execute(insertCmd);
				XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				XconfigObj.IsDirty = false;
				XconfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Xconfig XconfigObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZXconfigUpdate", new string[] {"TipoConfigurazione", "Login", "Pwd", 
"Dominio", "IpInterno", "DefaultDirectory", 
"Attivo", "Nome", "Cognome", 
"Ruolo", "CodiceUo", "WsBinding", 
"Data"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"DateTime"},"");
				CompileIUCmd(true, updateCmd,XconfigObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				XconfigObj.IsDirty = false;
				XconfigObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Xconfig XconfigObj)
		{
			switch (XconfigObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, XconfigObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, XconfigObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,XconfigObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, XconfigCollection XconfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZXconfigUpdate", new string[] {"TipoConfigurazione", "Login", "Pwd", 
"Dominio", "IpInterno", "DefaultDirectory", 
"Attivo", "Nome", "Cognome", 
"Ruolo", "CodiceUo", "WsBinding", 
"Data"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZXconfigInsert", new string[] {"TipoConfigurazione", "Login", "Pwd", 
"Dominio", "IpInterno", "DefaultDirectory", 
"Attivo", "Nome", "Cognome", 
"Ruolo", "CodiceUo", "WsBinding", 
"Data"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZXconfigDelete", new string[] {"TipoConfigurazione"}, new string[] {"string"},"");
				for (int i = 0; i < XconfigCollectionObj.Count; i++)
				{
					switch (XconfigCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,XconfigCollectionObj[i], db.CommandFirstChar);
								returnValue += db.Execute(insertCmd);
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,XconfigCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (XconfigCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "TipoConfigurazione", (SiarLibrary.NullTypes.StringNT)XconfigCollectionObj[i].TipoConfigurazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < XconfigCollectionObj.Count; i++)
				{
					if ((XconfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (XconfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						XconfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						XconfigCollectionObj[i].IsDirty = false;
						XconfigCollectionObj[i].IsPersistent = true;
					}
					if ((XconfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						XconfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						XconfigCollectionObj[i].IsDirty = false;
						XconfigCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Xconfig XconfigObj)
		{
			int returnValue = 0;
			if (XconfigObj.IsPersistent) 
			{
				returnValue = Delete(db, XconfigObj.TipoConfigurazione);
			}
			XconfigObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			XconfigObj.IsDirty = false;
			XconfigObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, string TipoConfigurazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZXconfigDelete", new string[] {"TipoConfigurazione"}, new string[] {"string"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "TipoConfigurazione", (SiarLibrary.NullTypes.StringNT)TipoConfigurazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, XconfigCollection XconfigCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZXconfigDelete", new string[] {"TipoConfigurazione"}, new string[] {"string"},"");
				for (int i = 0; i < XconfigCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "TipoConfigurazione", XconfigCollectionObj[i].TipoConfigurazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < XconfigCollectionObj.Count; i++)
				{
					if ((XconfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (XconfigCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						XconfigCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						XconfigCollectionObj[i].IsDirty = false;
						XconfigCollectionObj[i].IsPersistent = false;
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
		public static Xconfig GetById(DbProvider db, string TipoConfigurazioneValue)
		{
			Xconfig XconfigObj = null;
			IDbCommand readCmd = db.InitCmd( "ZXconfigGetById", new string[] {"TipoConfigurazione"}, new string[] {"string"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "TipoConfigurazione", (SiarLibrary.NullTypes.StringNT)TipoConfigurazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				XconfigObj = GetFromDatareader(db);
				XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				XconfigObj.IsDirty = false;
				XconfigObj.IsPersistent = true;
			}
			db.Close();
			return XconfigObj;
		}

		//getFromDatareader
		public static Xconfig GetFromDatareader(DbProvider db)
		{
			Xconfig XconfigObj = new Xconfig();
			XconfigObj.TipoConfigurazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_CONFIGURAZIONE"]);
			XconfigObj.Login = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOGIN"]);
			XconfigObj.Pwd = new SiarLibrary.NullTypes.StringNT(db.DataReader["PWD"]);
			XconfigObj.Dominio = new SiarLibrary.NullTypes.StringNT(db.DataReader["DOMINIO"]);
			XconfigObj.IpInterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["IP_INTERNO"]);
			XconfigObj.DefaultDirectory = new SiarLibrary.NullTypes.StringNT(db.DataReader["DEFAULT_DIRECTORY"]);
			XconfigObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			XconfigObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			XconfigObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			XconfigObj.Ruolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO"]);
			XconfigObj.CodiceUo = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_UO"]);
			XconfigObj.WsBinding = new SiarLibrary.NullTypes.StringNT(db.DataReader["WS_BINDING"]);
			XconfigObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			XconfigObj.IsDirty = false;
			XconfigObj.IsPersistent = true;
			return XconfigObj;
		}

		//Find Select

		public static XconfigCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT TipoConfigurazioneEqualThis, SiarLibrary.NullTypes.StringNT LoginEqualThis, SiarLibrary.NullTypes.StringNT PwdEqualThis, 
SiarLibrary.NullTypes.StringNT DominioEqualThis, SiarLibrary.NullTypes.StringNT IpInternoEqualThis, SiarLibrary.NullTypes.StringNT DefaultDirectoryEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, SiarLibrary.NullTypes.StringNT CognomeEqualThis, 
SiarLibrary.NullTypes.StringNT RuoloEqualThis, SiarLibrary.NullTypes.StringNT CodiceUoEqualThis, SiarLibrary.NullTypes.StringNT WsBindingEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis)

		{

			XconfigCollection XconfigCollectionObj = new XconfigCollection();

			IDbCommand findCmd = db.InitCmd("Zxconfigfindselect", new string[] {"TipoConfigurazioneequalthis", "Loginequalthis", "Pwdequalthis", 
"Dominioequalthis", "IpInternoequalthis", "DefaultDirectoryequalthis", 
"Attivoequalthis", "Nomeequalthis", "Cognomeequalthis", 
"Ruoloequalthis", "CodiceUoequalthis", "WsBindingequalthis", 
"Dataequalthis"}, new string[] {"string", "string", "string", 
"string", "string", "string", 
"bool", "string", "string", 
"string", "string", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoConfigurazioneequalthis", TipoConfigurazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Loginequalthis", LoginEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Pwdequalthis", PwdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dominioequalthis", DominioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IpInternoequalthis", IpInternoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DefaultDirectoryequalthis", DefaultDirectoryEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cognomeequalthis", CognomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ruoloequalthis", RuoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceUoequalthis", CodiceUoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "WsBindingequalthis", WsBindingEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			Xconfig XconfigObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				XconfigObj = GetFromDatareader(db);
				XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				XconfigObj.IsDirty = false;
				XconfigObj.IsPersistent = true;
				XconfigCollectionObj.Add(XconfigObj);
			}
			db.Close();
			return XconfigCollectionObj;
		}

		//Find Find

		public static XconfigCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT TipoConfigurazioneEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			XconfigCollection XconfigCollectionObj = new XconfigCollection();

			IDbCommand findCmd = db.InitCmd("Zxconfigfindfind", new string[] {"TipoConfigurazioneequalthis", "Attivoequalthis"}, new string[] {"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoConfigurazioneequalthis", TipoConfigurazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Xconfig XconfigObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				XconfigObj = GetFromDatareader(db);
				XconfigObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				XconfigObj.IsDirty = false;
				XconfigObj.IsPersistent = true;
				XconfigCollectionObj.Add(XconfigObj);
			}
			db.Close();
			return XconfigCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for XconfigCollectionProvider:IXconfigProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class XconfigCollectionProvider : IXconfigProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Xconfig
		protected XconfigCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public XconfigCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new XconfigCollection(this);
		}

		//Costruttore 2: popola la collection
		public XconfigCollectionProvider(StringNT TipoconfigurazioneEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(TipoconfigurazioneEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input xconfigCollectionObj - non popola la collection
		public XconfigCollectionProvider(XconfigCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public XconfigCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new XconfigCollection(this);
		}

		//Get e Set
		public XconfigCollection CollectionObj
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
		public int SaveCollection(XconfigCollection collectionObj)
		{
			return XconfigDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Xconfig xconfigObj)
		{
			return XconfigDAL.Save(_dbProviderObj, xconfigObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(XconfigCollection collectionObj)
		{
			return XconfigDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Xconfig xconfigObj)
		{
			return XconfigDAL.Delete(_dbProviderObj, xconfigObj);
		}

		//getById
		public Xconfig GetById(StringNT TipoConfigurazioneValue)
		{
			Xconfig XconfigTemp = XconfigDAL.GetById(_dbProviderObj, TipoConfigurazioneValue);
			if (XconfigTemp!=null) XconfigTemp.Provider = this;
			return XconfigTemp;
		}

		//Select: popola la collection
		public XconfigCollection Select(StringNT TipoconfigurazioneEqualThis, StringNT LoginEqualThis, StringNT PwdEqualThis, 
StringNT DominioEqualThis, StringNT IpinternoEqualThis, StringNT DefaultdirectoryEqualThis, 
BoolNT AttivoEqualThis, StringNT NomeEqualThis, StringNT CognomeEqualThis, 
StringNT RuoloEqualThis, StringNT CodiceuoEqualThis, StringNT WsbindingEqualThis, 
DatetimeNT DataEqualThis)
		{
			XconfigCollection XconfigCollectionTemp = XconfigDAL.Select(_dbProviderObj, TipoconfigurazioneEqualThis, LoginEqualThis, PwdEqualThis, 
DominioEqualThis, IpinternoEqualThis, DefaultdirectoryEqualThis, 
AttivoEqualThis, NomeEqualThis, CognomeEqualThis, 
RuoloEqualThis, CodiceuoEqualThis, WsbindingEqualThis, 
DataEqualThis);
			XconfigCollectionTemp.Provider = this;
			return XconfigCollectionTemp;
		}

		//Find: popola la collection
		public XconfigCollection Find(StringNT TipoconfigurazioneEqualThis, BoolNT AttivoEqualThis)
		{
			XconfigCollection XconfigCollectionTemp = XconfigDAL.Find(_dbProviderObj, TipoconfigurazioneEqualThis, AttivoEqualThis);
			XconfigCollectionTemp.Provider = this;
			return XconfigCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<XCONFIG>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <TIPO_CONFIGURAZIONE>Equal</TIPO_CONFIGURAZIONE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</XCONFIG>
*/
