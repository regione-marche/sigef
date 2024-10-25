using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per UtentiStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IUtentiStoricoProvider
	{
		int Save(UtentiStorico UtentiStoricoObj);
		int SaveCollection(UtentiStoricoCollection collectionObj);
		int Delete(UtentiStorico UtentiStoricoObj);
		int DeleteCollection(UtentiStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for UtentiStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class UtentiStorico: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdUtente;
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.StringNT _Email;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _OperatoreNominativo;
		[NonSerialized] private IUtentiStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUtentiStoricoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public UtentiStorico()
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
		/// Corrisponde al campo:ID_UTENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdUtente
		{
			get { return _IdUtente; }
			set {
				if (IdUtente != value)
				{
					_IdUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set {
				if (IdProfilo != value)
				{
					_IdProfilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Email
		{
			get { return _Email; }
			set {
				if (Email != value)
				{
					_Email = value;
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
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT OperatoreNominativo
		{
			get { return _OperatoreNominativo; }
			set {
				if (OperatoreNominativo != value)
				{
					_OperatoreNominativo = value;
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
	/// Summary description for UtentiStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UtentiStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private UtentiStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((UtentiStorico) info.GetValue(i.ToString(),typeof(UtentiStorico)));
			}
		}

		//Costruttore
		public UtentiStoricoCollection()
		{
			this.ItemType = typeof(UtentiStorico);
		}

		//Costruttore con provider
		public UtentiStoricoCollection(IUtentiStoricoProvider providerObj)
		{
			this.ItemType = typeof(UtentiStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new UtentiStorico this[int index]
		{
			get { return (UtentiStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new UtentiStoricoCollection GetChanges()
		{
			return (UtentiStoricoCollection) base.GetChanges();
		}

		[NonSerialized] private IUtentiStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IUtentiStoricoProvider Provider
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
		public int Add(UtentiStorico UtentiStoricoObj)
		{
			if (UtentiStoricoObj.Provider == null) UtentiStoricoObj.Provider = this.Provider;
			return base.Add(UtentiStoricoObj);
		}

		//AddCollection
		public void AddCollection(UtentiStoricoCollection UtentiStoricoCollectionObj)
		{
			foreach (UtentiStorico UtentiStoricoObj in UtentiStoricoCollectionObj)
				this.Add(UtentiStoricoObj);
		}

		//Insert
		public void Insert(int index, UtentiStorico UtentiStoricoObj)
		{
			if (UtentiStoricoObj.Provider == null) UtentiStoricoObj.Provider = this.Provider;
			base.Insert(index, UtentiStoricoObj);
		}

		//CollectionGetById
		public UtentiStorico CollectionGetById(NullTypes.IntNT IdValue)
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
		public UtentiStoricoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdUtenteEqualThis, NullTypes.IntNT IdProfiloEqualThis, 
NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT ProvinciaEqualThis, NullTypes.StringNT EmailEqualThis, 
NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis)
		{
			UtentiStoricoCollection UtentiStoricoCollectionTemp = new UtentiStoricoCollection();
			foreach (UtentiStorico UtentiStoricoItem in this)
			{
				if (((IdEqualThis == null) || ((UtentiStoricoItem.Id != null) && (UtentiStoricoItem.Id.Value == IdEqualThis.Value))) && ((IdUtenteEqualThis == null) || ((UtentiStoricoItem.IdUtente != null) && (UtentiStoricoItem.IdUtente.Value == IdUtenteEqualThis.Value))) && ((IdProfiloEqualThis == null) || ((UtentiStoricoItem.IdProfilo != null) && (UtentiStoricoItem.IdProfilo.Value == IdProfiloEqualThis.Value))) && 
((CodEnteEqualThis == null) || ((UtentiStoricoItem.CodEnte != null) && (UtentiStoricoItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((UtentiStoricoItem.Provincia != null) && (UtentiStoricoItem.Provincia.Value == ProvinciaEqualThis.Value))) && ((EmailEqualThis == null) || ((UtentiStoricoItem.Email != null) && (UtentiStoricoItem.Email.Value == EmailEqualThis.Value))) && 
((AttivoEqualThis == null) || ((UtentiStoricoItem.Attivo != null) && (UtentiStoricoItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataEqualThis == null) || ((UtentiStoricoItem.Data != null) && (UtentiStoricoItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((UtentiStoricoItem.Operatore != null) && (UtentiStoricoItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					UtentiStoricoCollectionTemp.Add(UtentiStoricoItem);
				}
			}
			return UtentiStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for UtentiStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class UtentiStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, UtentiStorico UtentiStoricoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", UtentiStoricoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdUtente", UtentiStoricoObj.IdUtente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdProfilo", UtentiStoricoObj.IdProfilo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodEnte", UtentiStoricoObj.CodEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Provincia", UtentiStoricoObj.Provincia);
			DbProvider.SetCmdParam(cmd,firstChar + "Email", UtentiStoricoObj.Email);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", UtentiStoricoObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", UtentiStoricoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", UtentiStoricoObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, UtentiStorico UtentiStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZUtentiStoricoInsert", new string[] {"IdUtente", "IdProfilo", 
"CodEnte", "Provincia", "Email", 
"Attivo", "Data", "Operatore", 
}, new string[] {"int", "int", 
"string", "string", "string", 
"bool", "DateTime", "int", 
},"");
				CompileIUCmd(false, insertCmd,UtentiStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				UtentiStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				UtentiStoricoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiStoricoObj.IsDirty = false;
				UtentiStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, UtentiStorico UtentiStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUtentiStoricoUpdate", new string[] {"Id", "IdUtente", "IdProfilo", 
"CodEnte", "Provincia", "Email", 
"Attivo", "Data", "Operatore", 
}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "int", 
},"");
				CompileIUCmd(true, updateCmd,UtentiStoricoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiStoricoObj.IsDirty = false;
				UtentiStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, UtentiStorico UtentiStoricoObj)
		{
			switch (UtentiStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, UtentiStoricoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, UtentiStoricoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,UtentiStoricoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, UtentiStoricoCollection UtentiStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZUtentiStoricoUpdate", new string[] {"Id", "IdUtente", "IdProfilo", 
"CodEnte", "Provincia", "Email", 
"Attivo", "Data", "Operatore", 
}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "int", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZUtentiStoricoInsert", new string[] {"IdUtente", "IdProfilo", 
"CodEnte", "Provincia", "Email", 
"Attivo", "Data", "Operatore", 
}, new string[] {"int", "int", 
"string", "string", "string", 
"bool", "DateTime", "int", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UtentiStoricoCollectionObj.Count; i++)
				{
					switch (UtentiStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,UtentiStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									UtentiStoricoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									UtentiStoricoCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,UtentiStoricoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (UtentiStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)UtentiStoricoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < UtentiStoricoCollectionObj.Count; i++)
				{
					if ((UtentiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UtentiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UtentiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						UtentiStoricoCollectionObj[i].IsDirty = false;
						UtentiStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((UtentiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						UtentiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UtentiStoricoCollectionObj[i].IsDirty = false;
						UtentiStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, UtentiStorico UtentiStoricoObj)
		{
			int returnValue = 0;
			if (UtentiStoricoObj.IsPersistent) 
			{
				returnValue = Delete(db, UtentiStoricoObj.Id);
			}
			UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			UtentiStoricoObj.IsDirty = false;
			UtentiStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, UtentiStoricoCollection UtentiStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZUtentiStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < UtentiStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", UtentiStoricoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < UtentiStoricoCollectionObj.Count; i++)
				{
					if ((UtentiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (UtentiStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						UtentiStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						UtentiStoricoCollectionObj[i].IsDirty = false;
						UtentiStoricoCollectionObj[i].IsPersistent = false;
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
		public static UtentiStorico GetById(DbProvider db, int IdValue)
		{
			UtentiStorico UtentiStoricoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZUtentiStoricoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				UtentiStoricoObj = GetFromDatareader(db);
				UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiStoricoObj.IsDirty = false;
				UtentiStoricoObj.IsPersistent = true;
			}
			db.Close();
			return UtentiStoricoObj;
		}

		//getFromDatareader
		public static UtentiStorico GetFromDatareader(DbProvider db)
		{
			UtentiStorico UtentiStoricoObj = new UtentiStorico();
			UtentiStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			UtentiStoricoObj.IdUtente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE"]);
			UtentiStoricoObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			UtentiStoricoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			UtentiStoricoObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			UtentiStoricoObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			UtentiStoricoObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			UtentiStoricoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			UtentiStoricoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			UtentiStoricoObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			UtentiStoricoObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			UtentiStoricoObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			UtentiStoricoObj.OperatoreNominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_NOMINATIVO"]);
			UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			UtentiStoricoObj.IsDirty = false;
			UtentiStoricoObj.IsPersistent = true;
			return UtentiStoricoObj;
		}

		//Find Select

		public static UtentiStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, 
SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, SiarLibrary.NullTypes.StringNT EmailEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			UtentiStoricoCollection UtentiStoricoCollectionObj = new UtentiStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zutentistoricofindselect", new string[] {"Idequalthis", "IdUtenteequalthis", "IdProfiloequalthis", 
"CodEnteequalthis", "Provinciaequalthis", "Emailequalthis", 
"Attivoequalthis", "Dataequalthis", "Operatoreequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"bool", "DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			UtentiStorico UtentiStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UtentiStoricoObj = GetFromDatareader(db);
				UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiStoricoObj.IsDirty = false;
				UtentiStoricoObj.IsPersistent = true;
				UtentiStoricoCollectionObj.Add(UtentiStoricoObj);
			}
			db.Close();
			return UtentiStoricoCollectionObj;
		}

		//Find Find

		public static UtentiStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			UtentiStoricoCollection UtentiStoricoCollectionObj = new UtentiStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zutentistoricofindfind", new string[] {"IdUtenteequalthis", "CodEnteequalthis", "IdProfiloequalthis", 
"Attivoequalthis"}, new string[] {"int", "string", "int", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdUtenteequalthis", IdUtenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			UtentiStorico UtentiStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				UtentiStoricoObj = GetFromDatareader(db);
				UtentiStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				UtentiStoricoObj.IsDirty = false;
				UtentiStoricoObj.IsPersistent = true;
				UtentiStoricoCollectionObj.Add(UtentiStoricoObj);
			}
			db.Close();
			return UtentiStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for UtentiStoricoCollectionProvider:IUtentiStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class UtentiStoricoCollectionProvider : IUtentiStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di UtentiStorico
		protected UtentiStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public UtentiStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new UtentiStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public UtentiStoricoCollectionProvider(IntNT IdutenteEqualThis, StringNT CodenteEqualThis, IntNT IdprofiloEqualThis, 
BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdutenteEqualThis, CodenteEqualThis, IdprofiloEqualThis, 
AttivoEqualThis);
		}

		//Costruttore3: ha in input utentistoricoCollectionObj - non popola la collection
		public UtentiStoricoCollectionProvider(UtentiStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public UtentiStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new UtentiStoricoCollection(this);
		}

		//Get e Set
		public UtentiStoricoCollection CollectionObj
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
		public int SaveCollection(UtentiStoricoCollection collectionObj)
		{
			return UtentiStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(UtentiStorico utentistoricoObj)
		{
			return UtentiStoricoDAL.Save(_dbProviderObj, utentistoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(UtentiStoricoCollection collectionObj)
		{
			return UtentiStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(UtentiStorico utentistoricoObj)
		{
			return UtentiStoricoDAL.Delete(_dbProviderObj, utentistoricoObj);
		}

		//getById
		public UtentiStorico GetById(IntNT IdValue)
		{
			UtentiStorico UtentiStoricoTemp = UtentiStoricoDAL.GetById(_dbProviderObj, IdValue);
			if (UtentiStoricoTemp!=null) UtentiStoricoTemp.Provider = this;
			return UtentiStoricoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public UtentiStoricoCollection Select(IntNT IdEqualThis, IntNT IdutenteEqualThis, IntNT IdprofiloEqualThis, 
StringNT CodenteEqualThis, StringNT ProvinciaEqualThis, StringNT EmailEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DataEqualThis, IntNT OperatoreEqualThis)
		{
			UtentiStoricoCollection UtentiStoricoCollectionTemp = UtentiStoricoDAL.Select(_dbProviderObj, IdEqualThis, IdutenteEqualThis, IdprofiloEqualThis, 
CodenteEqualThis, ProvinciaEqualThis, EmailEqualThis, 
AttivoEqualThis, DataEqualThis, OperatoreEqualThis);
			UtentiStoricoCollectionTemp.Provider = this;
			return UtentiStoricoCollectionTemp;
		}

		//Find: popola la collection
		public UtentiStoricoCollection Find(IntNT IdutenteEqualThis, StringNT CodenteEqualThis, IntNT IdprofiloEqualThis, 
BoolNT AttivoEqualThis)
		{
			UtentiStoricoCollection UtentiStoricoCollectionTemp = UtentiStoricoDAL.Find(_dbProviderObj, IdutenteEqualThis, CodenteEqualThis, IdprofiloEqualThis, 
AttivoEqualThis);
			UtentiStoricoCollectionTemp.Provider = this;
			return UtentiStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<UTENTI_STORICO>
  <ViewName>vUTENTI_STORICO</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_UTENTE>Equal</ID_UTENTE>
      <COD_ENTE>Equal</COD_ENTE>
      <ID_PROFILO>Equal</ID_PROFILO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</UTENTI_STORICO>
*/
