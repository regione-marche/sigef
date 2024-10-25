using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per TeamSigef
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ITeamSigefProvider
	{
		int Save(TeamSigef TeamSigefObj);
		int SaveCollection(TeamSigefCollection collectionObj);
		int Delete(TeamSigef TeamSigefObj);
		int DeleteCollection(TeamSigefCollection collectionObj);
	}
	/// <summary>
	/// Summary description for TeamSigef
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class TeamSigef: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.StringNT _OperatoreInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _Email;
		private NullTypes.StringNT _Istanza;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private ITeamSigefProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITeamSigefProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public TeamSigef()
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
		/// Corrisponde al campo:OPERATORE_INSERIMENTO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OperatoreInserimento
		{
			get { return _OperatoreInserimento; }
			set {
				if (OperatoreInserimento != value)
				{
					_OperatoreInserimento = value;
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
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
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
		/// Corrisponde al campo:NOME
		/// Tipo sul db:VARCHAR(255)
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
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:EMAIL
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:ISTANZA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Istanza
		{
			get { return _Istanza; }
			set {
				if (Istanza != value)
				{
					_Istanza = value;
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
	/// Summary description for TeamSigefCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TeamSigefCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TeamSigefCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TeamSigef) info.GetValue(i.ToString(),typeof(TeamSigef)));
			}
		}

		//Costruttore
		public TeamSigefCollection()
		{
			this.ItemType = typeof(TeamSigef);
		}

		//Costruttore con provider
		public TeamSigefCollection(ITeamSigefProvider providerObj)
		{
			this.ItemType = typeof(TeamSigef);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TeamSigef this[int index]
		{
			get { return (TeamSigef)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TeamSigefCollection GetChanges()
		{
			return (TeamSigefCollection) base.GetChanges();
		}

		[NonSerialized] private ITeamSigefProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITeamSigefProvider Provider
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
		public int Add(TeamSigef TeamSigefObj)
		{
			if (TeamSigefObj.Provider == null) TeamSigefObj.Provider = this.Provider;
			return base.Add(TeamSigefObj);
		}

		//AddCollection
		public void AddCollection(TeamSigefCollection TeamSigefCollectionObj)
		{
			foreach (TeamSigef TeamSigefObj in TeamSigefCollectionObj)
				this.Add(TeamSigefObj);
		}

		//Insert
		public void Insert(int index, TeamSigef TeamSigefObj)
		{
			if (TeamSigefObj.Provider == null) TeamSigefObj.Provider = this.Provider;
			base.Insert(index, TeamSigefObj);
		}

		//CollectionGetById
		public TeamSigef CollectionGetById(NullTypes.IntNT IdValue)
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
		public TeamSigefCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT NomeEqualThis, 
NullTypes.StringNT CognomeEqualThis, NullTypes.StringNT EmailEqualThis, NullTypes.StringNT IstanzaEqualThis, 
NullTypes.BoolNT AttivoEqualThis)
		{
			TeamSigefCollection TeamSigefCollectionTemp = new TeamSigefCollection();
			foreach (TeamSigef TeamSigefItem in this)
			{
				if (((IdEqualThis == null) || ((TeamSigefItem.Id != null) && (TeamSigefItem.Id.Value == IdEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((TeamSigefItem.OperatoreInserimento != null) && (TeamSigefItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((TeamSigefItem.DataInserimento != null) && (TeamSigefItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((OperatoreModificaEqualThis == null) || ((TeamSigefItem.OperatoreModifica != null) && (TeamSigefItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((TeamSigefItem.DataModifica != null) && (TeamSigefItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((NomeEqualThis == null) || ((TeamSigefItem.Nome != null) && (TeamSigefItem.Nome.Value == NomeEqualThis.Value))) && 
((CognomeEqualThis == null) || ((TeamSigefItem.Cognome != null) && (TeamSigefItem.Cognome.Value == CognomeEqualThis.Value))) && ((EmailEqualThis == null) || ((TeamSigefItem.Email != null) && (TeamSigefItem.Email.Value == EmailEqualThis.Value))) && ((IstanzaEqualThis == null) || ((TeamSigefItem.Istanza != null) && (TeamSigefItem.Istanza.Value == IstanzaEqualThis.Value))) && 
((AttivoEqualThis == null) || ((TeamSigefItem.Attivo != null) && (TeamSigefItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					TeamSigefCollectionTemp.Add(TeamSigefItem);
				}
			}
			return TeamSigefCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for TeamSigefDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class TeamSigefDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, TeamSigef TeamSigefObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", TeamSigefObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreInserimento", TeamSigefObj.OperatoreInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", TeamSigefObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", TeamSigefObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", TeamSigefObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", TeamSigefObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Cognome", TeamSigefObj.Cognome);
			DbProvider.SetCmdParam(cmd,firstChar + "Email", TeamSigefObj.Email);
			DbProvider.SetCmdParam(cmd,firstChar + "Istanza", TeamSigefObj.Istanza);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", TeamSigefObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, TeamSigef TeamSigefObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZTeamSigefInsert", new string[] {"OperatoreInserimento", "DataInserimento", 
"OperatoreModifica", "DataModifica", "Nome", 
"Cognome", "Email", "Istanza", 
"Attivo"}, new string[] {"string", "DateTime", 
"string", "DateTime", "string", 
"string", "string", "string", 
"bool"},"");
				CompileIUCmd(false, insertCmd,TeamSigefObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				TeamSigefObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TeamSigefObj.IsDirty = false;
				TeamSigefObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, TeamSigef TeamSigefObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTeamSigefUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento", 
"OperatoreModifica", "DataModifica", "Nome", 
"Cognome", "Email", "Istanza", 
"Attivo"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "string", 
"string", "string", "string", 
"bool"},"");
				CompileIUCmd(true, updateCmd,TeamSigefObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					TeamSigefObj.DataModifica = d;
				}
				TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TeamSigefObj.IsDirty = false;
				TeamSigefObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, TeamSigef TeamSigefObj)
		{
			switch (TeamSigefObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, TeamSigefObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, TeamSigefObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,TeamSigefObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, TeamSigefCollection TeamSigefCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZTeamSigefUpdate", new string[] {"Id", "OperatoreInserimento", "DataInserimento", 
"OperatoreModifica", "DataModifica", "Nome", 
"Cognome", "Email", "Istanza", 
"Attivo"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "string", 
"string", "string", "string", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZTeamSigefInsert", new string[] {"OperatoreInserimento", "DataInserimento", 
"OperatoreModifica", "DataModifica", "Nome", 
"Cognome", "Email", "Istanza", 
"Attivo"}, new string[] {"string", "DateTime", 
"string", "DateTime", "string", 
"string", "string", "string", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZTeamSigefDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TeamSigefCollectionObj.Count; i++)
				{
					switch (TeamSigefCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,TeamSigefCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									TeamSigefCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,TeamSigefCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									TeamSigefCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (TeamSigefCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)TeamSigefCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < TeamSigefCollectionObj.Count; i++)
				{
					if ((TeamSigefCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TeamSigefCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TeamSigefCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						TeamSigefCollectionObj[i].IsDirty = false;
						TeamSigefCollectionObj[i].IsPersistent = true;
					}
					if ((TeamSigefCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						TeamSigefCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TeamSigefCollectionObj[i].IsDirty = false;
						TeamSigefCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, TeamSigef TeamSigefObj)
		{
			int returnValue = 0;
			if (TeamSigefObj.IsPersistent) 
			{
				returnValue = Delete(db, TeamSigefObj.Id);
			}
			TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			TeamSigefObj.IsDirty = false;
			TeamSigefObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTeamSigefDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, TeamSigefCollection TeamSigefCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZTeamSigefDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < TeamSigefCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", TeamSigefCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < TeamSigefCollectionObj.Count; i++)
				{
					if ((TeamSigefCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (TeamSigefCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						TeamSigefCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						TeamSigefCollectionObj[i].IsDirty = false;
						TeamSigefCollectionObj[i].IsPersistent = false;
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
		public static TeamSigef GetById(DbProvider db, int IdValue)
		{
			TeamSigef TeamSigefObj = null;
			IDbCommand readCmd = db.InitCmd( "ZTeamSigefGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				TeamSigefObj = GetFromDatareader(db);
				TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TeamSigefObj.IsDirty = false;
				TeamSigefObj.IsPersistent = true;
			}
			db.Close();
			return TeamSigefObj;
		}

		//getFromDatareader
		public static TeamSigef GetFromDatareader(DbProvider db)
		{
			TeamSigef TeamSigefObj = new TeamSigef();
			TeamSigefObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			TeamSigefObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
			TeamSigefObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			TeamSigefObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
			TeamSigefObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			TeamSigefObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			TeamSigefObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			TeamSigefObj.Email = new SiarLibrary.NullTypes.StringNT(db.DataReader["EMAIL"]);
			TeamSigefObj.Istanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTANZA"]);
			TeamSigefObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			TeamSigefObj.IsDirty = false;
			TeamSigefObj.IsPersistent = true;
			return TeamSigefObj;
		}

		//Find Select

		public static TeamSigefCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, 
SiarLibrary.NullTypes.StringNT CognomeEqualThis, SiarLibrary.NullTypes.StringNT EmailEqualThis, SiarLibrary.NullTypes.StringNT IstanzaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			TeamSigefCollection TeamSigefCollectionObj = new TeamSigefCollection();

			IDbCommand findCmd = db.InitCmd("Zteamsigeffindselect", new string[] {"Idequalthis", "OperatoreInserimentoequalthis", "DataInserimentoequalthis", 
"OperatoreModificaequalthis", "DataModificaequalthis", "Nomeequalthis", 
"Cognomeequalthis", "Emailequalthis", "Istanzaequalthis", 
"Attivoequalthis"}, new string[] {"int", "string", "DateTime", 
"string", "DateTime", "string", 
"string", "string", "string", 
"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cognomeequalthis", CognomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Emailequalthis", EmailEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istanzaequalthis", IstanzaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			TeamSigef TeamSigefObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TeamSigefObj = GetFromDatareader(db);
				TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TeamSigefObj.IsDirty = false;
				TeamSigefObj.IsPersistent = true;
				TeamSigefCollectionObj.Add(TeamSigefObj);
			}
			db.Close();
			return TeamSigefCollectionObj;
		}

		//Find FindAttivi

		public static TeamSigefCollection FindAttivi(DbProvider db, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			TeamSigefCollection TeamSigefCollectionObj = new TeamSigefCollection();

			IDbCommand findCmd = db.InitCmd("Zteamsigeffindfindattivi", new string[] {"Attivoequalthis"}, new string[] {"bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			TeamSigef TeamSigefObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				TeamSigefObj = GetFromDatareader(db);
				TeamSigefObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				TeamSigefObj.IsDirty = false;
				TeamSigefObj.IsPersistent = true;
				TeamSigefCollectionObj.Add(TeamSigefObj);
			}
			db.Close();
			return TeamSigefCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for TeamSigefCollectionProvider:ITeamSigefProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class TeamSigefCollectionProvider : ITeamSigefProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TeamSigef
		protected TeamSigefCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TeamSigefCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TeamSigefCollection(this);
		}

		//Costruttore 2: popola la collection
		public TeamSigefCollectionProvider(BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindAttivi(AttivoEqualThis);
		}

		//Costruttore3: ha in input teamsigefCollectionObj - non popola la collection
		public TeamSigefCollectionProvider(TeamSigefCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TeamSigefCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TeamSigefCollection(this);
		}

		//Get e Set
		public TeamSigefCollection CollectionObj
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
		public int SaveCollection(TeamSigefCollection collectionObj)
		{
			return TeamSigefDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TeamSigef teamsigefObj)
		{
			return TeamSigefDAL.Save(_dbProviderObj, teamsigefObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TeamSigefCollection collectionObj)
		{
			return TeamSigefDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TeamSigef teamsigefObj)
		{
			return TeamSigefDAL.Delete(_dbProviderObj, teamsigefObj);
		}

		//getById
		public TeamSigef GetById(IntNT IdValue)
		{
			TeamSigef TeamSigefTemp = TeamSigefDAL.GetById(_dbProviderObj, IdValue);
			if (TeamSigefTemp!=null) TeamSigefTemp.Provider = this;
			return TeamSigefTemp;
		}

		//Select: popola la collection
		public TeamSigefCollection Select(IntNT IdEqualThis, StringNT OperatoreinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, 
StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis, StringNT NomeEqualThis, 
StringNT CognomeEqualThis, StringNT EmailEqualThis, StringNT IstanzaEqualThis, 
BoolNT AttivoEqualThis)
		{
			TeamSigefCollection TeamSigefCollectionTemp = TeamSigefDAL.Select(_dbProviderObj, IdEqualThis, OperatoreinserimentoEqualThis, DatainserimentoEqualThis, 
OperatoremodificaEqualThis, DatamodificaEqualThis, NomeEqualThis, 
CognomeEqualThis, EmailEqualThis, IstanzaEqualThis, 
AttivoEqualThis);
			TeamSigefCollectionTemp.Provider = this;
			return TeamSigefCollectionTemp;
		}

		//FindAttivi: popola la collection
		public TeamSigefCollection FindAttivi(BoolNT AttivoEqualThis)
		{
			TeamSigefCollection TeamSigefCollectionTemp = TeamSigefDAL.FindAttivi(_dbProviderObj, AttivoEqualThis);
			TeamSigefCollectionTemp.Provider = this;
			return TeamSigefCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<TEAM_SIGEF>
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
    <FindAttivi OrderBy="ORDER BY ">
      <ATTIVO>Equal</ATTIVO>
    </FindAttivi>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TEAM_SIGEF>
*/
