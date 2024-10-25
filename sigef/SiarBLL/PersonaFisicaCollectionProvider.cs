using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PersonaFisica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPersonaFisicaProvider
	{
		int Save(PersonaFisica PersonaFisicaObj);
		int SaveCollection(PersonaFisicaCollection collectionObj);
		int Delete(PersonaFisica PersonaFisicaObj);
		int DeleteCollection(PersonaFisicaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PersonaFisica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PersonaFisica: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPersona;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _Sesso;
		private NullTypes.DatetimeNT _DataNascita;
		private NullTypes.IntNT _IdCittadinanza;
		private NullTypes.StringNT _Cittadinanza;
		private NullTypes.IntNT _IdComuneNascita;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Provincia;
		[NonSerialized] private IPersonaFisicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPersonaFisicaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PersonaFisica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PERSONA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPersona
		{
			get { return _IdPersona; }
			set {
				if (IdPersona != value)
				{
					_IdPersona = value;
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
		/// Corrisponde al campo:SESSO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Sesso
		{
			get { return _Sesso; }
			set {
				if (Sesso != value)
				{
					_Sesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_NASCITA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataNascita
		{
			get { return _DataNascita; }
			set {
				if (DataNascita != value)
				{
					_DataNascita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_CITTADINANZA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdCittadinanza
		{
			get { return _IdCittadinanza; }
			set {
				if (IdCittadinanza != value)
				{
					_IdCittadinanza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CITTADINANZA
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Cittadinanza
		{
			get { return _Cittadinanza; }
			set {
				if (Cittadinanza != value)
				{
					_Cittadinanza = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNE_NASCITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComuneNascita
		{
			get { return _IdComuneNascita; }
			set {
				if (IdComuneNascita != value)
				{
					_IdComuneNascita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMUNE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Comune
		{
			get { return _Comune; }
			set {
				if (Comune != value)
				{
					_Comune = value;
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
	/// Summary description for PersonaFisicaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PersonaFisicaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PersonaFisicaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PersonaFisica) info.GetValue(i.ToString(),typeof(PersonaFisica)));
			}
		}

		//Costruttore
		public PersonaFisicaCollection()
		{
			this.ItemType = typeof(PersonaFisica);
		}

		//Costruttore con provider
		public PersonaFisicaCollection(IPersonaFisicaProvider providerObj)
		{
			this.ItemType = typeof(PersonaFisica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PersonaFisica this[int index]
		{
			get { return (PersonaFisica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PersonaFisicaCollection GetChanges()
		{
			return (PersonaFisicaCollection) base.GetChanges();
		}

		[NonSerialized] private IPersonaFisicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPersonaFisicaProvider Provider
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
		public int Add(PersonaFisica PersonaFisicaObj)
		{
			if (PersonaFisicaObj.Provider == null) PersonaFisicaObj.Provider = this.Provider;
			return base.Add(PersonaFisicaObj);
		}

		//AddCollection
		public void AddCollection(PersonaFisicaCollection PersonaFisicaCollectionObj)
		{
			foreach (PersonaFisica PersonaFisicaObj in PersonaFisicaCollectionObj)
				this.Add(PersonaFisicaObj);
		}

		//Insert
		public void Insert(int index, PersonaFisica PersonaFisicaObj)
		{
			if (PersonaFisicaObj.Provider == null) PersonaFisicaObj.Provider = this.Provider;
			base.Insert(index, PersonaFisicaObj);
		}

		//CollectionGetById
		public PersonaFisica CollectionGetById(NullTypes.IntNT IdPersonaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPersona == IdPersonaValue))
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
		public PersonaFisicaCollection SubSelect(NullTypes.IntNT IdPersonaEqualThis, NullTypes.StringNT NomeEqualThis, NullTypes.StringNT CognomeEqualThis, 
NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT SessoEqualThis, NullTypes.DatetimeNT DataNascitaEqualThis, 
NullTypes.IntNT IdComuneNascitaEqualThis, NullTypes.IntNT IdCittadinanzaEqualThis)
		{
			PersonaFisicaCollection PersonaFisicaCollectionTemp = new PersonaFisicaCollection();
			foreach (PersonaFisica PersonaFisicaItem in this)
			{
				if (((IdPersonaEqualThis == null) || ((PersonaFisicaItem.IdPersona != null) && (PersonaFisicaItem.IdPersona.Value == IdPersonaEqualThis.Value))) && ((NomeEqualThis == null) || ((PersonaFisicaItem.Nome != null) && (PersonaFisicaItem.Nome.Value == NomeEqualThis.Value))) && ((CognomeEqualThis == null) || ((PersonaFisicaItem.Cognome != null) && (PersonaFisicaItem.Cognome.Value == CognomeEqualThis.Value))) && 
((CodiceFiscaleEqualThis == null) || ((PersonaFisicaItem.CodiceFiscale != null) && (PersonaFisicaItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((SessoEqualThis == null) || ((PersonaFisicaItem.Sesso != null) && (PersonaFisicaItem.Sesso.Value == SessoEqualThis.Value))) && ((DataNascitaEqualThis == null) || ((PersonaFisicaItem.DataNascita != null) && (PersonaFisicaItem.DataNascita.Value == DataNascitaEqualThis.Value))) && 
((IdComuneNascitaEqualThis == null) || ((PersonaFisicaItem.IdComuneNascita != null) && (PersonaFisicaItem.IdComuneNascita.Value == IdComuneNascitaEqualThis.Value))) && ((IdCittadinanzaEqualThis == null) || ((PersonaFisicaItem.IdCittadinanza != null) && (PersonaFisicaItem.IdCittadinanza.Value == IdCittadinanzaEqualThis.Value))))
				{
					PersonaFisicaCollectionTemp.Add(PersonaFisicaItem);
				}
			}
			return PersonaFisicaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PersonaFisicaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PersonaFisicaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PersonaFisica PersonaFisicaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPersona", PersonaFisicaObj.IdPersona);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Nome", PersonaFisicaObj.Nome);
			DbProvider.SetCmdParam(cmd,firstChar + "Cognome", PersonaFisicaObj.Cognome);
			DbProvider.SetCmdParam(cmd,firstChar + "CodiceFiscale", PersonaFisicaObj.CodiceFiscale);
			DbProvider.SetCmdParam(cmd,firstChar + "Sesso", PersonaFisicaObj.Sesso);
			DbProvider.SetCmdParam(cmd,firstChar + "DataNascita", PersonaFisicaObj.DataNascita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdCittadinanza", PersonaFisicaObj.IdCittadinanza);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComuneNascita", PersonaFisicaObj.IdComuneNascita);
		}
		//Insert
		private static int Insert(DbProvider db, PersonaFisica PersonaFisicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPersonaFisicaInsert", new string[] {"Nome", "Cognome", 
"CodiceFiscale", "Sesso", "DataNascita", 
"IdCittadinanza", "IdComuneNascita", }, new string[] {"string", "string", 
"string", "string", "DateTime", 
"int", "int", },"");
				CompileIUCmd(false, insertCmd,PersonaFisicaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PersonaFisicaObj.IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
				}
				PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersonaFisicaObj.IsDirty = false;
				PersonaFisicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PersonaFisica PersonaFisicaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPersonaFisicaUpdate", new string[] {"IdPersona", "Nome", "Cognome", 
"CodiceFiscale", "Sesso", "DataNascita", 
"IdCittadinanza", "IdComuneNascita", }, new string[] {"int", "string", "string", 
"string", "string", "DateTime", 
"int", "int", },"");
				CompileIUCmd(true, updateCmd,PersonaFisicaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersonaFisicaObj.IsDirty = false;
				PersonaFisicaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PersonaFisica PersonaFisicaObj)
		{
			switch (PersonaFisicaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PersonaFisicaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PersonaFisicaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PersonaFisicaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PersonaFisicaCollection PersonaFisicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPersonaFisicaUpdate", new string[] {"IdPersona", "Nome", "Cognome", 
"CodiceFiscale", "Sesso", "DataNascita", 
"IdCittadinanza", "IdComuneNascita", }, new string[] {"int", "string", "string", 
"string", "string", "DateTime", 
"int", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZPersonaFisicaInsert", new string[] {"Nome", "Cognome", 
"CodiceFiscale", "Sesso", "DataNascita", 
"IdCittadinanza", "IdComuneNascita", }, new string[] {"string", "string", 
"string", "string", "DateTime", 
"int", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZPersonaFisicaDelete", new string[] {"IdPersona"}, new string[] {"int"},"");
				for (int i = 0; i < PersonaFisicaCollectionObj.Count; i++)
				{
					switch (PersonaFisicaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PersonaFisicaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PersonaFisicaCollectionObj[i].IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PersonaFisicaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PersonaFisicaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersona", (SiarLibrary.NullTypes.IntNT)PersonaFisicaCollectionObj[i].IdPersona);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PersonaFisicaCollectionObj.Count; i++)
				{
					if ((PersonaFisicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PersonaFisicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PersonaFisicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PersonaFisicaCollectionObj[i].IsDirty = false;
						PersonaFisicaCollectionObj[i].IsPersistent = true;
					}
					if ((PersonaFisicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PersonaFisicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PersonaFisicaCollectionObj[i].IsDirty = false;
						PersonaFisicaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PersonaFisica PersonaFisicaObj)
		{
			int returnValue = 0;
			if (PersonaFisicaObj.IsPersistent) 
			{
				returnValue = Delete(db, PersonaFisicaObj.IdPersona);
			}
			PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PersonaFisicaObj.IsDirty = false;
			PersonaFisicaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPersonaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPersonaFisicaDelete", new string[] {"IdPersona"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersona", (SiarLibrary.NullTypes.IntNT)IdPersonaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PersonaFisicaCollection PersonaFisicaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPersonaFisicaDelete", new string[] {"IdPersona"}, new string[] {"int"},"");
				for (int i = 0; i < PersonaFisicaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersona", PersonaFisicaCollectionObj[i].IdPersona);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PersonaFisicaCollectionObj.Count; i++)
				{
					if ((PersonaFisicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PersonaFisicaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PersonaFisicaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PersonaFisicaCollectionObj[i].IsDirty = false;
						PersonaFisicaCollectionObj[i].IsPersistent = false;
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
		public static PersonaFisica GetById(DbProvider db, int IdPersonaValue)
		{
			PersonaFisica PersonaFisicaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPersonaFisicaGetById", new string[] {"IdPersona"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPersona", (SiarLibrary.NullTypes.IntNT)IdPersonaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PersonaFisicaObj = GetFromDatareader(db);
				PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersonaFisicaObj.IsDirty = false;
				PersonaFisicaObj.IsPersistent = true;
			}
			db.Close();
			return PersonaFisicaObj;
		}

		//getFromDatareader
		public static PersonaFisica GetFromDatareader(DbProvider db)
		{
			PersonaFisica PersonaFisicaObj = new PersonaFisica();
			PersonaFisicaObj.IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
			PersonaFisicaObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			PersonaFisicaObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			PersonaFisicaObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			PersonaFisicaObj.Sesso = new SiarLibrary.NullTypes.StringNT(db.DataReader["SESSO"]);
			PersonaFisicaObj.DataNascita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_NASCITA"]);
			PersonaFisicaObj.IdCittadinanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CITTADINANZA"]);
			PersonaFisicaObj.Cittadinanza = new SiarLibrary.NullTypes.StringNT(db.DataReader["CITTADINANZA"]);
			PersonaFisicaObj.IdComuneNascita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE_NASCITA"]);
			PersonaFisicaObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			PersonaFisicaObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PersonaFisicaObj.IsDirty = false;
			PersonaFisicaObj.IsPersistent = true;
			return PersonaFisicaObj;
		}

		//Find Select

		public static PersonaFisicaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, SiarLibrary.NullTypes.StringNT NomeEqualThis, SiarLibrary.NullTypes.StringNT CognomeEqualThis, 
SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT SessoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataNascitaEqualThis, 
SiarLibrary.NullTypes.IntNT IdComuneNascitaEqualThis, SiarLibrary.NullTypes.IntNT IdCittadinanzaEqualThis)

		{

			PersonaFisicaCollection PersonaFisicaCollectionObj = new PersonaFisicaCollection();

			IDbCommand findCmd = db.InitCmd("Zpersonafisicafindselect", new string[] {"IdPersonaequalthis", "Nomeequalthis", "Cognomeequalthis", 
"CodiceFiscaleequalthis", "Sessoequalthis", "DataNascitaequalthis", 
"IdComuneNascitaequalthis", "IdCittadinanzaequalthis"}, new string[] {"int", "string", "string", 
"string", "string", "DateTime", 
"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Nomeequalthis", NomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cognomeequalthis", CognomeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Sessoequalthis", SessoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataNascitaequalthis", DataNascitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComuneNascitaequalthis", IdComuneNascitaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdCittadinanzaequalthis", IdCittadinanzaEqualThis);
			PersonaFisica PersonaFisicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PersonaFisicaObj = GetFromDatareader(db);
				PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersonaFisicaObj.IsDirty = false;
				PersonaFisicaObj.IsPersistent = true;
				PersonaFisicaCollectionObj.Add(PersonaFisicaObj);
			}
			db.Close();
			return PersonaFisicaCollectionObj;
		}

		//Find Find

		public static PersonaFisicaCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis)

		{

			PersonaFisicaCollection PersonaFisicaCollectionObj = new PersonaFisicaCollection();

			IDbCommand findCmd = db.InitCmd("Zpersonafisicafindfind", new string[] {"CodiceFiscaleequalthis"}, new string[] {"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			PersonaFisica PersonaFisicaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PersonaFisicaObj = GetFromDatareader(db);
				PersonaFisicaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersonaFisicaObj.IsDirty = false;
				PersonaFisicaObj.IsPersistent = true;
				PersonaFisicaCollectionObj.Add(PersonaFisicaObj);
			}
			db.Close();
			return PersonaFisicaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PersonaFisicaCollectionProvider:IPersonaFisicaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PersonaFisicaCollectionProvider : IPersonaFisicaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PersonaFisica
		protected PersonaFisicaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PersonaFisicaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PersonaFisicaCollection(this);
		}

		//Costruttore 2: popola la collection
		public PersonaFisicaCollectionProvider(StringNT CodicefiscaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodicefiscaleEqualThis);
		}

		//Costruttore3: ha in input personafisicaCollectionObj - non popola la collection
		public PersonaFisicaCollectionProvider(PersonaFisicaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PersonaFisicaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PersonaFisicaCollection(this);
		}

		//Get e Set
		public PersonaFisicaCollection CollectionObj
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
		public int SaveCollection(PersonaFisicaCollection collectionObj)
		{
			return PersonaFisicaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PersonaFisica personafisicaObj)
		{
			return PersonaFisicaDAL.Save(_dbProviderObj, personafisicaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PersonaFisicaCollection collectionObj)
		{
			return PersonaFisicaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PersonaFisica personafisicaObj)
		{
			return PersonaFisicaDAL.Delete(_dbProviderObj, personafisicaObj);
		}

		//getById
		public PersonaFisica GetById(IntNT IdPersonaValue)
		{
			PersonaFisica PersonaFisicaTemp = PersonaFisicaDAL.GetById(_dbProviderObj, IdPersonaValue);
			if (PersonaFisicaTemp!=null) PersonaFisicaTemp.Provider = this;
			return PersonaFisicaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PersonaFisicaCollection Select(IntNT IdpersonaEqualThis, StringNT NomeEqualThis, StringNT CognomeEqualThis, 
StringNT CodicefiscaleEqualThis, StringNT SessoEqualThis, DatetimeNT DatanascitaEqualThis, 
IntNT IdcomunenascitaEqualThis, IntNT IdcittadinanzaEqualThis)
		{
			PersonaFisicaCollection PersonaFisicaCollectionTemp = PersonaFisicaDAL.Select(_dbProviderObj, IdpersonaEqualThis, NomeEqualThis, CognomeEqualThis, 
CodicefiscaleEqualThis, SessoEqualThis, DatanascitaEqualThis, 
IdcomunenascitaEqualThis, IdcittadinanzaEqualThis);
			PersonaFisicaCollectionTemp.Provider = this;
			return PersonaFisicaCollectionTemp;
		}

		//Find: popola la collection
		public PersonaFisicaCollection Find(StringNT CodicefiscaleEqualThis)
		{
			PersonaFisicaCollection PersonaFisicaCollectionTemp = PersonaFisicaDAL.Find(_dbProviderObj, CodicefiscaleEqualThis);
			PersonaFisicaCollectionTemp.Provider = this;
			return PersonaFisicaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PERSONA_FISICA>
  <ViewName>vPERSONA_FISICA</ViewName>
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
    <Find OrderBy="ORDER BY COGNOME, NOME">
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PERSONA_FISICA>
*/
