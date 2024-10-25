using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ImpresaSoci
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IImpresaSociProvider
	{
		int Save(ImpresaSoci ImpresaSociObj);
		int SaveCollection(ImpresaSociCollection collectionObj);
		int Delete(ImpresaSoci ImpresaSociObj);
		int DeleteCollection(ImpresaSociCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ImpresaSoci
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ImpresaSoci: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.IntNT _IdSocio;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _DataInizioValidita;
		private NullTypes.DatetimeNT _DataFineValidita;
		private NullTypes.IntNT _IdOperatoreInizio;
		private NullTypes.IntNT _IdOperatoreFine;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _FormaGiuridica;
		private NullTypes.StringNT _CodTipoSocio;
		private NullTypes.StringNT _TipoSocio;
		[NonSerialized] private IImpresaSociProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaSociProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ImpresaSoci()
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
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_SOCIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdSocio
		{
			get { return _IdSocio; }
			set {
				if (IdSocio != value)
				{
					_IdSocio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
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
		/// Corrisponde al campo:DATA_INIZIO_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataInizioValidita
		{
			get { return _DataInizioValidita; }
			set {
				if (DataInizioValidita != value)
				{
					_DataInizioValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_VALIDITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineValidita
		{
			get { return _DataFineValidita; }
			set {
				if (DataFineValidita != value)
				{
					_DataFineValidita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_INIZIO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreInizio
		{
			get { return _IdOperatoreInizio; }
			set {
				if (IdOperatoreInizio != value)
				{
					_IdOperatoreInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_OPERATORE_FINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdOperatoreFine
		{
			get { return _IdOperatoreFine; }
			set {
				if (IdOperatoreFine != value)
				{
					_IdOperatoreFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FORMA_GIURIDICA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT FormaGiuridica
		{
			get { return _FormaGiuridica; }
			set {
				if (FormaGiuridica != value)
				{
					_FormaGiuridica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_SOCIO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodTipoSocio
		{
			get { return _CodTipoSocio; }
			set {
				if (CodTipoSocio != value)
				{
					_CodTipoSocio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_SOCIO
		/// Tipo sul db:VARCHAR(15)
		/// </summary>
		public NullTypes.StringNT TipoSocio
		{
			get { return _TipoSocio; }
			set {
				if (TipoSocio != value)
				{
					_TipoSocio = value;
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
	/// Summary description for ImpresaSociCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaSociCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ImpresaSociCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ImpresaSoci) info.GetValue(i.ToString(),typeof(ImpresaSoci)));
			}
		}

		//Costruttore
		public ImpresaSociCollection()
		{
			this.ItemType = typeof(ImpresaSoci);
		}

		//Costruttore con provider
		public ImpresaSociCollection(IImpresaSociProvider providerObj)
		{
			this.ItemType = typeof(ImpresaSoci);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ImpresaSoci this[int index]
		{
			get { return (ImpresaSoci)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ImpresaSociCollection GetChanges()
		{
			return (ImpresaSociCollection) base.GetChanges();
		}

		[NonSerialized] private IImpresaSociProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IImpresaSociProvider Provider
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
		public int Add(ImpresaSoci ImpresaSociObj)
		{
			if (ImpresaSociObj.Provider == null) ImpresaSociObj.Provider = this.Provider;
			return base.Add(ImpresaSociObj);
		}

		//AddCollection
		public void AddCollection(ImpresaSociCollection ImpresaSociCollectionObj)
		{
			foreach (ImpresaSoci ImpresaSociObj in ImpresaSociCollectionObj)
				this.Add(ImpresaSociObj);
		}

		//Insert
		public void Insert(int index, ImpresaSoci ImpresaSociObj)
		{
			if (ImpresaSociObj.Provider == null) ImpresaSociObj.Provider = this.Provider;
			base.Insert(index, ImpresaSociObj);
		}

		//CollectionGetById
		public ImpresaSoci CollectionGetById(NullTypes.IntNT IdValue)
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
		public ImpresaSociCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdSocioEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.IntNT IdOperatoreInizioEqualThis, NullTypes.IntNT IdOperatoreFineEqualThis, NullTypes.StringNT CodTipoSocioEqualThis)
		{
			ImpresaSociCollection ImpresaSociCollectionTemp = new ImpresaSociCollection();
			foreach (ImpresaSoci ImpresaSociItem in this)
			{
				if (((IdEqualThis == null) || ((ImpresaSociItem.Id != null) && (ImpresaSociItem.Id.Value == IdEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ImpresaSociItem.IdImpresa != null) && (ImpresaSociItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdSocioEqualThis == null) || ((ImpresaSociItem.IdSocio != null) && (ImpresaSociItem.IdSocio.Value == IdSocioEqualThis.Value))) && 
((AttivoEqualThis == null) || ((ImpresaSociItem.Attivo != null) && (ImpresaSociItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((ImpresaSociItem.DataInizioValidita != null) && (ImpresaSociItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((ImpresaSociItem.DataFineValidita != null) && (ImpresaSociItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((IdOperatoreInizioEqualThis == null) || ((ImpresaSociItem.IdOperatoreInizio != null) && (ImpresaSociItem.IdOperatoreInizio.Value == IdOperatoreInizioEqualThis.Value))) && ((IdOperatoreFineEqualThis == null) || ((ImpresaSociItem.IdOperatoreFine != null) && (ImpresaSociItem.IdOperatoreFine.Value == IdOperatoreFineEqualThis.Value))) && ((CodTipoSocioEqualThis == null) || ((ImpresaSociItem.CodTipoSocio != null) && (ImpresaSociItem.CodTipoSocio.Value == CodTipoSocioEqualThis.Value))))
				{
					ImpresaSociCollectionTemp.Add(ImpresaSociItem);
				}
			}
			return ImpresaSociCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ImpresaSociDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ImpresaSociDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ImpresaSoci ImpresaSociObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ImpresaSociObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", ImpresaSociObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "IdSocio", ImpresaSociObj.IdSocio);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", ImpresaSociObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizioValidita", ImpresaSociObj.DataInizioValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFineValidita", ImpresaSociObj.DataFineValidita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreInizio", ImpresaSociObj.IdOperatoreInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "IdOperatoreFine", ImpresaSociObj.IdOperatoreFine);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoSocio", ImpresaSociObj.CodTipoSocio);
		}
		//Insert
		private static int Insert(DbProvider db, ImpresaSoci ImpresaSociObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZImpresaSociInsert", new string[] {"IdImpresa", "IdSocio", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", 

"CodTipoSocio"}, new string[] {"int", "int", 
"bool", "DateTime", "DateTime", 
"int", "int", 

"string"},"");
				CompileIUCmd(false, insertCmd,ImpresaSociObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ImpresaSociObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ImpresaSociObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaSociObj.IsDirty = false;
				ImpresaSociObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ImpresaSoci ImpresaSociObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaSociUpdate", new string[] {"Id", "IdImpresa", "IdSocio", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", 

"CodTipoSocio"}, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int", "int", 

"string"},"");
				CompileIUCmd(true, updateCmd,ImpresaSociObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaSociObj.IsDirty = false;
				ImpresaSociObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ImpresaSoci ImpresaSociObj)
		{
			switch (ImpresaSociObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ImpresaSociObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ImpresaSociObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ImpresaSociObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ImpresaSociCollection ImpresaSociCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZImpresaSociUpdate", new string[] {"Id", "IdImpresa", "IdSocio", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", 

"CodTipoSocio"}, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int", "int", 

"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZImpresaSociInsert", new string[] {"IdImpresa", "IdSocio", 
"Attivo", "DataInizioValidita", "DataFineValidita", 
"IdOperatoreInizio", "IdOperatoreFine", 

"CodTipoSocio"}, new string[] {"int", "int", 
"bool", "DateTime", "DateTime", 
"int", "int", 

"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaSociDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaSociCollectionObj.Count; i++)
				{
					switch (ImpresaSociCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ImpresaSociCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ImpresaSociCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ImpresaSociCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ImpresaSociCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ImpresaSociCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ImpresaSociCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ImpresaSociCollectionObj.Count; i++)
				{
					if ((ImpresaSociCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaSociCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaSociCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ImpresaSociCollectionObj[i].IsDirty = false;
						ImpresaSociCollectionObj[i].IsPersistent = true;
					}
					if ((ImpresaSociCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ImpresaSociCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaSociCollectionObj[i].IsDirty = false;
						ImpresaSociCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ImpresaSoci ImpresaSociObj)
		{
			int returnValue = 0;
			if (ImpresaSociObj.IsPersistent) 
			{
				returnValue = Delete(db, ImpresaSociObj.Id);
			}
			ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ImpresaSociObj.IsDirty = false;
			ImpresaSociObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaSociDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ImpresaSociCollection ImpresaSociCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZImpresaSociDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ImpresaSociCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ImpresaSociCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ImpresaSociCollectionObj.Count; i++)
				{
					if ((ImpresaSociCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ImpresaSociCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ImpresaSociCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ImpresaSociCollectionObj[i].IsDirty = false;
						ImpresaSociCollectionObj[i].IsPersistent = false;
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
		public static ImpresaSoci GetById(DbProvider db, int IdValue)
		{
			ImpresaSoci ImpresaSociObj = null;
			IDbCommand readCmd = db.InitCmd( "ZImpresaSociGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ImpresaSociObj = GetFromDatareader(db);
				ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaSociObj.IsDirty = false;
				ImpresaSociObj.IsPersistent = true;
			}
			db.Close();
			return ImpresaSociObj;
		}

		//getFromDatareader
		public static ImpresaSoci GetFromDatareader(DbProvider db)
		{
			ImpresaSoci ImpresaSociObj = new ImpresaSoci();
			ImpresaSociObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ImpresaSociObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			ImpresaSociObj.IdSocio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SOCIO"]);
			ImpresaSociObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			ImpresaSociObj.DataInizioValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_VALIDITA"]);
			ImpresaSociObj.DataFineValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_VALIDITA"]);
			ImpresaSociObj.IdOperatoreInizio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_INIZIO"]);
			ImpresaSociObj.IdOperatoreFine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_FINE"]);
			ImpresaSociObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			ImpresaSociObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			ImpresaSociObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			ImpresaSociObj.FormaGiuridica = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMA_GIURIDICA"]);
			ImpresaSociObj.CodTipoSocio = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_SOCIO"]);
			ImpresaSociObj.TipoSocio = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_SOCIO"]);
			ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ImpresaSociObj.IsDirty = false;
			ImpresaSociObj.IsPersistent = true;
			return ImpresaSociObj;
		}

		//Find Select

		public static ImpresaSociCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdSocioEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineValiditaEqualThis, 
SiarLibrary.NullTypes.IntNT IdOperatoreInizioEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreFineEqualThis, SiarLibrary.NullTypes.StringNT CodTipoSocioEqualThis)

		{

			ImpresaSociCollection ImpresaSociCollectionObj = new ImpresaSociCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresasocifindselect", new string[] {"Idequalthis", "IdImpresaequalthis", "IdSocioequalthis", 
"Attivoequalthis", "DataInizioValiditaequalthis", "DataFineValiditaequalthis", 
"IdOperatoreInizioequalthis", "IdOperatoreFineequalthis", "CodTipoSocioequalthis"}, new string[] {"int", "int", "int", 
"bool", "DateTime", "DateTime", 
"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdSocioequalthis", IdSocioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioValiditaequalthis", DataInizioValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineValiditaequalthis", DataFineValiditaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreInizioequalthis", IdOperatoreInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdOperatoreFineequalthis", IdOperatoreFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSocioequalthis", CodTipoSocioEqualThis);
			ImpresaSoci ImpresaSociObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaSociObj = GetFromDatareader(db);
				ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaSociObj.IsDirty = false;
				ImpresaSociObj.IsPersistent = true;
				ImpresaSociCollectionObj.Add(ImpresaSociObj);
			}
			db.Close();
			return ImpresaSociCollectionObj;
		}

		//Find Find

		public static ImpresaSociCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, 
SiarLibrary.NullTypes.StringNT RagioneSocialeLikeThis, SiarLibrary.NullTypes.StringNT CodTipoSocioEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			ImpresaSociCollection ImpresaSociCollectionObj = new ImpresaSociCollection();

			IDbCommand findCmd = db.InitCmd("Zimpresasocifindfind", new string[] {"IdImpresaequalthis", "Cuaaequalthis", "CodiceFiscaleequalthis", 
"RagioneSocialelikethis", "CodTipoSocioequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialelikethis", RagioneSocialeLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoSocioequalthis", CodTipoSocioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			ImpresaSoci ImpresaSociObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ImpresaSociObj = GetFromDatareader(db);
				ImpresaSociObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ImpresaSociObj.IsDirty = false;
				ImpresaSociObj.IsPersistent = true;
				ImpresaSociCollectionObj.Add(ImpresaSociObj);
			}
			db.Close();
			return ImpresaSociCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ImpresaSociCollectionProvider:IImpresaSociProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ImpresaSociCollectionProvider : IImpresaSociProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ImpresaSoci
		protected ImpresaSociCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ImpresaSociCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ImpresaSociCollection(this);
		}

		//Costruttore 2: popola la collection
		public ImpresaSociCollectionProvider(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, 
StringNT RagionesocialeLikeThis, StringNT CodtiposocioEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis, 
RagionesocialeLikeThis, CodtiposocioEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input impresasociCollectionObj - non popola la collection
		public ImpresaSociCollectionProvider(ImpresaSociCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ImpresaSociCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ImpresaSociCollection(this);
		}

		//Get e Set
		public ImpresaSociCollection CollectionObj
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
		public int SaveCollection(ImpresaSociCollection collectionObj)
		{
			return ImpresaSociDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ImpresaSoci impresasociObj)
		{
			return ImpresaSociDAL.Save(_dbProviderObj, impresasociObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ImpresaSociCollection collectionObj)
		{
			return ImpresaSociDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ImpresaSoci impresasociObj)
		{
			return ImpresaSociDAL.Delete(_dbProviderObj, impresasociObj);
		}

		//getById
		public ImpresaSoci GetById(IntNT IdValue)
		{
			ImpresaSoci ImpresaSociTemp = ImpresaSociDAL.GetById(_dbProviderObj, IdValue);
			if (ImpresaSociTemp!=null) ImpresaSociTemp.Provider = this;
			return ImpresaSociTemp;
		}

		//Select: popola la collection
		public ImpresaSociCollection Select(IntNT IdEqualThis, IntNT IdimpresaEqualThis, IntNT IdsocioEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, 
IntNT IdoperatoreinizioEqualThis, IntNT IdoperatorefineEqualThis, StringNT CodtiposocioEqualThis)
		{
			ImpresaSociCollection ImpresaSociCollectionTemp = ImpresaSociDAL.Select(_dbProviderObj, IdEqualThis, IdimpresaEqualThis, IdsocioEqualThis, 
AttivoEqualThis, DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, 
IdoperatoreinizioEqualThis, IdoperatorefineEqualThis, CodtiposocioEqualThis);
			ImpresaSociCollectionTemp.Provider = this;
			return ImpresaSociCollectionTemp;
		}

		//Find: popola la collection
		public ImpresaSociCollection Find(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, 
StringNT RagionesocialeLikeThis, StringNT CodtiposocioEqualThis, BoolNT AttivoEqualThis)
		{
			ImpresaSociCollection ImpresaSociCollectionTemp = ImpresaSociDAL.Find(_dbProviderObj, IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis, 
RagionesocialeLikeThis, CodtiposocioEqualThis, AttivoEqualThis);
			ImpresaSociCollectionTemp.Provider = this;
			return ImpresaSociCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<IMPRESA_SOCI>
  <ViewName>vIMPRESA_SOCI</ViewName>
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
    <Find OrderBy="ORDER BY ATTIVO DESC, RAGIONE_SOCIALE">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <COD_TIPO_SOCIO>Equal</COD_TIPO_SOCIO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</IMPRESA_SOCI>
*/
