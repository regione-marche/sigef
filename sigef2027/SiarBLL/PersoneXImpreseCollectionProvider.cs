using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PersoneXImprese
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPersoneXImpreseProvider
	{
		int Save(PersoneXImprese PersoneXImpreseObj);
		int SaveCollection(PersoneXImpreseCollection collectionObj);
		int Delete(PersoneXImprese PersoneXImpreseObj);
		int DeleteCollection(PersoneXImpreseCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PersoneXImprese
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PersoneXImprese: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPersona;
		private NullTypes.StringNT _Nome;
		private NullTypes.StringNT _Cognome;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _Sesso;
		private NullTypes.DatetimeNT _DataNascita;
		private NullTypes.IntNT _IdComuneNascita;
		private NullTypes.IntNT _IdCittadinanza;
		private NullTypes.IntNT _IdPersoneXImprese;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodRuolo;
		private NullTypes.DatetimeNT _DataInizio;
		private NullTypes.DatetimeNT _DataFine;
		private NullTypes.StringNT _Ruolo;
		private NullTypes.StringNT _Comune;
		private NullTypes.StringNT _Sigla;
		private NullTypes.StringNT _Cap;
		private NullTypes.StringNT _CodBelfiore;
		private NullTypes.BoolNT _Ammesso;
		private NullTypes.BoolNT _PotereDiFirma;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IPersoneXImpreseProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPersoneXImpreseProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PersoneXImprese()
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
		/// Corrisponde al campo:ID_PERSONE_X_IMPRESE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPersoneXImprese
		{
			get { return _IdPersoneXImprese; }
			set {
				if (IdPersoneXImprese != value)
				{
					_IdPersoneXImprese = value;
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
		/// Corrisponde al campo:COD_RUOLO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodRuolo
		{
			get { return _CodRuolo; }
			set {
				if (CodRuolo != value)
				{
					_CodRuolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INIZIO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInizio
		{
			get { return _DataInizio; }
			set {
				if (DataInizio != value)
				{
					_DataInizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFine
		{
			get { return _DataFine; }
			set {
				if (DataFine != value)
				{
					_DataFine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUOLO
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:SIGLA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Sigla
		{
			get { return _Sigla; }
			set {
				if (Sigla != value)
				{
					_Sigla = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CAP
		/// Tipo sul db:VARCHAR(5)
		/// </summary>
		public NullTypes.StringNT Cap
		{
			get { return _Cap; }
			set {
				if (Cap != value)
				{
					_Cap = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_BELFIORE
		/// Tipo sul db:CHAR(4)
		/// </summary>
		public NullTypes.StringNT CodBelfiore
		{
			get { return _CodBelfiore; }
			set {
				if (CodBelfiore != value)
				{
					_CodBelfiore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AMMESSO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Ammesso
		{
			get { return _Ammesso; }
			set {
				if (Ammesso != value)
				{
					_Ammesso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:POTERE_DI_FIRMA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PotereDiFirma
		{
			get { return _PotereDiFirma; }
			set {
				if (PotereDiFirma != value)
				{
					_PotereDiFirma = value;
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
	/// Summary description for PersoneXImpreseCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PersoneXImpreseCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PersoneXImpreseCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PersoneXImprese) info.GetValue(i.ToString(),typeof(PersoneXImprese)));
			}
		}

		//Costruttore
		public PersoneXImpreseCollection()
		{
			this.ItemType = typeof(PersoneXImprese);
		}

		//Costruttore con provider
		public PersoneXImpreseCollection(IPersoneXImpreseProvider providerObj)
		{
			this.ItemType = typeof(PersoneXImprese);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PersoneXImprese this[int index]
		{
			get { return (PersoneXImprese)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PersoneXImpreseCollection GetChanges()
		{
			return (PersoneXImpreseCollection) base.GetChanges();
		}

		[NonSerialized] private IPersoneXImpreseProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPersoneXImpreseProvider Provider
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
		public int Add(PersoneXImprese PersoneXImpreseObj)
		{
			if (PersoneXImpreseObj.Provider == null) PersoneXImpreseObj.Provider = this.Provider;
			return base.Add(PersoneXImpreseObj);
		}

		//AddCollection
		public void AddCollection(PersoneXImpreseCollection PersoneXImpreseCollectionObj)
		{
			foreach (PersoneXImprese PersoneXImpreseObj in PersoneXImpreseCollectionObj)
				this.Add(PersoneXImpreseObj);
		}

		//Insert
		public void Insert(int index, PersoneXImprese PersoneXImpreseObj)
		{
			if (PersoneXImpreseObj.Provider == null) PersoneXImpreseObj.Provider = this.Provider;
			base.Insert(index, PersoneXImpreseObj);
		}

		//CollectionGetById
		public PersoneXImprese CollectionGetById(NullTypes.IntNT IdPersoneXImpreseValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPersoneXImprese == IdPersoneXImpreseValue))
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
		public PersoneXImpreseCollection SubSelect(NullTypes.IntNT IdPersoneXImpreseEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdPersonaEqualThis, 
NullTypes.StringNT CodRuoloEqualThis, NullTypes.BoolNT AttivoEqualThis, NullTypes.DatetimeNT DataInizioEqualThis, 
NullTypes.DatetimeNT DataFineEqualThis, NullTypes.BoolNT AmmessoEqualThis)
		{
			PersoneXImpreseCollection PersoneXImpreseCollectionTemp = new PersoneXImpreseCollection();
			foreach (PersoneXImprese PersoneXImpreseItem in this)
			{
				if (((IdPersoneXImpreseEqualThis == null) || ((PersoneXImpreseItem.IdPersoneXImprese != null) && (PersoneXImpreseItem.IdPersoneXImprese.Value == IdPersoneXImpreseEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((PersoneXImpreseItem.IdImpresa != null) && (PersoneXImpreseItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdPersonaEqualThis == null) || ((PersoneXImpreseItem.IdPersona != null) && (PersoneXImpreseItem.IdPersona.Value == IdPersonaEqualThis.Value))) && 
((CodRuoloEqualThis == null) || ((PersoneXImpreseItem.CodRuolo != null) && (PersoneXImpreseItem.CodRuolo.Value == CodRuoloEqualThis.Value))) && ((AttivoEqualThis == null) || ((PersoneXImpreseItem.Attivo != null) && (PersoneXImpreseItem.Attivo.Value == AttivoEqualThis.Value))) && ((DataInizioEqualThis == null) || ((PersoneXImpreseItem.DataInizio != null) && (PersoneXImpreseItem.DataInizio.Value == DataInizioEqualThis.Value))) && 
((DataFineEqualThis == null) || ((PersoneXImpreseItem.DataFine != null) && (PersoneXImpreseItem.DataFine.Value == DataFineEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PersoneXImpreseItem.Ammesso != null) && (PersoneXImpreseItem.Ammesso.Value == AmmessoEqualThis.Value))))
				{
					PersoneXImpreseCollectionTemp.Add(PersoneXImpreseItem);
				}
			}
			return PersoneXImpreseCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PersoneXImpreseDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PersoneXImpreseDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PersoneXImprese PersoneXImpreseObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPersoneXImprese", PersoneXImpreseObj.IdPersoneXImprese);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdPersona", PersoneXImpreseObj.IdPersona);
			DbProvider.SetCmdParam(cmd,firstChar + "IdImpresa", PersoneXImpreseObj.IdImpresa);
			DbProvider.SetCmdParam(cmd,firstChar + "CodRuolo", PersoneXImpreseObj.CodRuolo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInizio", PersoneXImpreseObj.DataInizio);
			DbProvider.SetCmdParam(cmd,firstChar + "DataFine", PersoneXImpreseObj.DataFine);
			DbProvider.SetCmdParam(cmd,firstChar + "Ammesso", PersoneXImpreseObj.Ammesso);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", PersoneXImpreseObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, PersoneXImprese PersoneXImpreseObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPersoneXImpreseInsert", new string[] {"IdPersona", 


"IdImpresa", "CodRuolo", "DataInizio", 
"DataFine", 

"Ammesso", "Attivo"}, new string[] {"int", 


"int", "string", "DateTime", 
"DateTime", 

"bool", "bool"},"");
				CompileIUCmd(false, insertCmd,PersoneXImpreseObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PersoneXImpreseObj.IdPersoneXImprese = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONE_X_IMPRESE"]);
				PersoneXImpreseObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
				PersoneXImpreseObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
				PersoneXImpreseObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersoneXImpreseObj.IsDirty = false;
				PersoneXImpreseObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PersoneXImprese PersoneXImpreseObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPersoneXImpreseUpdate", new string[] {"IdPersona", 

"IdPersoneXImprese", 
"IdImpresa", "CodRuolo", "DataInizio", 
"DataFine", 

"Ammesso", "Attivo"}, new string[] {"int", 

"int", 
"int", "string", "DateTime", 
"DateTime", 

"bool", "bool"},"");
				CompileIUCmd(true, updateCmd,PersoneXImpreseObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersoneXImpreseObj.IsDirty = false;
				PersoneXImpreseObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PersoneXImprese PersoneXImpreseObj)
		{
			switch (PersoneXImpreseObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PersoneXImpreseObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PersoneXImpreseObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PersoneXImpreseObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PersoneXImpreseCollection PersoneXImpreseCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPersoneXImpreseUpdate", new string[] {"IdPersona", 

"IdPersoneXImprese", 
"IdImpresa", "CodRuolo", "DataInizio", 
"DataFine", 

"Ammesso", "Attivo"}, new string[] {"int", 

"int", 
"int", "string", "DateTime", 
"DateTime", 

"bool", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPersoneXImpreseInsert", new string[] {"IdPersona", 


"IdImpresa", "CodRuolo", "DataInizio", 
"DataFine", 

"Ammesso", "Attivo"}, new string[] {"int", 


"int", "string", "DateTime", 
"DateTime", 

"bool", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPersoneXImpreseDelete", new string[] {"IdPersoneXImprese"}, new string[] {"int"},"");
				for (int i = 0; i < PersoneXImpreseCollectionObj.Count; i++)
				{
					switch (PersoneXImpreseCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PersoneXImpreseCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PersoneXImpreseCollectionObj[i].IdPersoneXImprese = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONE_X_IMPRESE"]);
									PersoneXImpreseCollectionObj[i].DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
									PersoneXImpreseCollectionObj[i].Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
									PersoneXImpreseCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PersoneXImpreseCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PersoneXImpreseCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersoneXImprese", (SiarLibrary.NullTypes.IntNT)PersoneXImpreseCollectionObj[i].IdPersoneXImprese);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PersoneXImpreseCollectionObj.Count; i++)
				{
					if ((PersoneXImpreseCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PersoneXImpreseCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PersoneXImpreseCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PersoneXImpreseCollectionObj[i].IsDirty = false;
						PersoneXImpreseCollectionObj[i].IsPersistent = true;
					}
					if ((PersoneXImpreseCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PersoneXImpreseCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PersoneXImpreseCollectionObj[i].IsDirty = false;
						PersoneXImpreseCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PersoneXImprese PersoneXImpreseObj)
		{
			int returnValue = 0;
			if (PersoneXImpreseObj.IsPersistent) 
			{
				returnValue = Delete(db, PersoneXImpreseObj.IdPersoneXImprese);
			}
			PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PersoneXImpreseObj.IsDirty = false;
			PersoneXImpreseObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPersoneXImpreseValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPersoneXImpreseDelete", new string[] {"IdPersoneXImprese"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersoneXImprese", (SiarLibrary.NullTypes.IntNT)IdPersoneXImpreseValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PersoneXImpreseCollection PersoneXImpreseCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPersoneXImpreseDelete", new string[] {"IdPersoneXImprese"}, new string[] {"int"},"");
				for (int i = 0; i < PersoneXImpreseCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPersoneXImprese", PersoneXImpreseCollectionObj[i].IdPersoneXImprese);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PersoneXImpreseCollectionObj.Count; i++)
				{
					if ((PersoneXImpreseCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PersoneXImpreseCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PersoneXImpreseCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PersoneXImpreseCollectionObj[i].IsDirty = false;
						PersoneXImpreseCollectionObj[i].IsPersistent = false;
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
		public static PersoneXImprese GetById(DbProvider db, int IdPersoneXImpreseValue)
		{
			PersoneXImprese PersoneXImpreseObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPersoneXImpreseGetById", new string[] {"IdPersoneXImprese"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPersoneXImprese", (SiarLibrary.NullTypes.IntNT)IdPersoneXImpreseValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PersoneXImpreseObj = GetFromDatareader(db);
				PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersoneXImpreseObj.IsDirty = false;
				PersoneXImpreseObj.IsPersistent = true;
			}
			db.Close();
			return PersoneXImpreseObj;
		}

		//getFromDatareader
		public static PersoneXImprese GetFromDatareader(DbProvider db)
		{
			PersoneXImprese PersoneXImpreseObj = new PersoneXImprese();
			PersoneXImpreseObj.IdPersona = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONA"]);
			PersoneXImpreseObj.Nome = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME"]);
			PersoneXImpreseObj.Cognome = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME"]);
			PersoneXImpreseObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			PersoneXImpreseObj.Sesso = new SiarLibrary.NullTypes.StringNT(db.DataReader["SESSO"]);
			PersoneXImpreseObj.DataNascita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_NASCITA"]);
			PersoneXImpreseObj.IdComuneNascita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE_NASCITA"]);
			PersoneXImpreseObj.IdCittadinanza = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CITTADINANZA"]);
			PersoneXImpreseObj.IdPersoneXImprese = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PERSONE_X_IMPRESE"]);
			PersoneXImpreseObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			PersoneXImpreseObj.CodRuolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_RUOLO"]);
			PersoneXImpreseObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
			PersoneXImpreseObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
			PersoneXImpreseObj.Ruolo = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUOLO"]);
			PersoneXImpreseObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			PersoneXImpreseObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			PersoneXImpreseObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			PersoneXImpreseObj.CodBelfiore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_BELFIORE"]);
			PersoneXImpreseObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
			PersoneXImpreseObj.PotereDiFirma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["POTERE_DI_FIRMA"]);
			PersoneXImpreseObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PersoneXImpreseObj.IsDirty = false;
			PersoneXImpreseObj.IsPersistent = true;
			return PersoneXImpreseObj;
		}

		//Find Select

		public static PersoneXImpreseCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPersoneXImpreseEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, 
SiarLibrary.NullTypes.StringNT CodRuoloEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis)

		{

			PersoneXImpreseCollection PersoneXImpreseCollectionObj = new PersoneXImpreseCollection();

			IDbCommand findCmd = db.InitCmd("Zpersoneximpresefindselect", new string[] {"IdPersoneXImpreseequalthis", "IdImpresaequalthis", "IdPersonaequalthis", 
"CodRuoloequalthis", "Attivoequalthis", "DataInizioequalthis", 
"DataFineequalthis", "Ammessoequalthis"}, new string[] {"int", "int", "int", 
"string", "bool", "DateTime", 
"DateTime", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersoneXImpreseequalthis", IdPersoneXImpreseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloequalthis", CodRuoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInizioequalthis", DataInizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineequalthis", DataFineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
			PersoneXImprese PersoneXImpreseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PersoneXImpreseObj = GetFromDatareader(db);
				PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersoneXImpreseObj.IsDirty = false;
				PersoneXImpreseObj.IsPersistent = true;
				PersoneXImpreseCollectionObj.Add(PersoneXImpreseObj);
			}
			db.Close();
			return PersoneXImpreseCollectionObj;
		}

		//Find Find

		public static PersoneXImpreseCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPersonaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CodRuoloEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, SiarLibrary.NullTypes.BoolNT PotereDiFirmaEqualThis)

		{

			PersoneXImpreseCollection PersoneXImpreseCollectionObj = new PersoneXImpreseCollection();

			IDbCommand findCmd = db.InitCmd("Zpersoneximpresefindfind", new string[] {"IdPersonaequalthis", "CodiceFiscaleequalthis", "IdImpresaequalthis", 
"CodRuoloequalthis", "Attivoequalthis", "PotereDiFirmaequalthis"}, new string[] {"int", "string", "int", 
"string", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPersonaequalthis", IdPersonaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodRuoloequalthis", CodRuoloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PotereDiFirmaequalthis", PotereDiFirmaEqualThis);
			PersoneXImprese PersoneXImpreseObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PersoneXImpreseObj = GetFromDatareader(db);
				PersoneXImpreseObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PersoneXImpreseObj.IsDirty = false;
				PersoneXImpreseObj.IsPersistent = true;
				PersoneXImpreseCollectionObj.Add(PersoneXImpreseObj);
			}
			db.Close();
			return PersoneXImpreseCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PersoneXImpreseCollectionProvider:IPersoneXImpreseProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PersoneXImpreseCollectionProvider : IPersoneXImpreseProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PersoneXImprese
		protected PersoneXImpreseCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PersoneXImpreseCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PersoneXImpreseCollection(this);
		}

		//Costruttore 2: popola la collection
		public PersoneXImpreseCollectionProvider(IntNT IdpersonaEqualThis, StringNT CodicefiscaleEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodruoloEqualThis, BoolNT AttivoEqualThis, BoolNT PoteredifirmaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpersonaEqualThis, CodicefiscaleEqualThis, IdimpresaEqualThis, 
CodruoloEqualThis, AttivoEqualThis, PoteredifirmaEqualThis);
		}

		//Costruttore3: ha in input personeximpreseCollectionObj - non popola la collection
		public PersoneXImpreseCollectionProvider(PersoneXImpreseCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PersoneXImpreseCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PersoneXImpreseCollection(this);
		}

		//Get e Set
		public PersoneXImpreseCollection CollectionObj
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
		public int SaveCollection(PersoneXImpreseCollection collectionObj)
		{
			return PersoneXImpreseDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PersoneXImprese personeximpreseObj)
		{
			return PersoneXImpreseDAL.Save(_dbProviderObj, personeximpreseObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PersoneXImpreseCollection collectionObj)
		{
			return PersoneXImpreseDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PersoneXImprese personeximpreseObj)
		{
			return PersoneXImpreseDAL.Delete(_dbProviderObj, personeximpreseObj);
		}

		//getById
		public PersoneXImprese GetById(IntNT IdPersoneXImpreseValue)
		{
			PersoneXImprese PersoneXImpreseTemp = PersoneXImpreseDAL.GetById(_dbProviderObj, IdPersoneXImpreseValue);
			if (PersoneXImpreseTemp!=null) PersoneXImpreseTemp.Provider = this;
			return PersoneXImpreseTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PersoneXImpreseCollection Select(IntNT IdpersoneximpreseEqualThis, IntNT IdimpresaEqualThis, IntNT IdpersonaEqualThis, 
StringNT CodruoloEqualThis, BoolNT AttivoEqualThis, DatetimeNT DatainizioEqualThis, 
DatetimeNT DatafineEqualThis, BoolNT AmmessoEqualThis)
		{
			PersoneXImpreseCollection PersoneXImpreseCollectionTemp = PersoneXImpreseDAL.Select(_dbProviderObj, IdpersoneximpreseEqualThis, IdimpresaEqualThis, IdpersonaEqualThis, 
CodruoloEqualThis, AttivoEqualThis, DatainizioEqualThis, 
DatafineEqualThis, AmmessoEqualThis);
			PersoneXImpreseCollectionTemp.Provider = this;
			return PersoneXImpreseCollectionTemp;
		}

		//Find: popola la collection
		public PersoneXImpreseCollection Find(IntNT IdpersonaEqualThis, StringNT CodicefiscaleEqualThis, IntNT IdimpresaEqualThis, 
StringNT CodruoloEqualThis, BoolNT AttivoEqualThis, BoolNT PoteredifirmaEqualThis)
		{
			PersoneXImpreseCollection PersoneXImpreseCollectionTemp = PersoneXImpreseDAL.Find(_dbProviderObj, IdpersonaEqualThis, CodicefiscaleEqualThis, IdimpresaEqualThis, 
CodruoloEqualThis, AttivoEqualThis, PoteredifirmaEqualThis);
			PersoneXImpreseCollectionTemp.Provider = this;
			return PersoneXImpreseCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PERSONE_X_IMPRESE>
  <ViewName>vPERSONE_X_IMPRESE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO DESC">
      <ID_PERSONA>Equal</ID_PERSONA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_RUOLO>Equal</COD_RUOLO>
      <ATTIVO>Equal</ATTIVO>
      <POTERE_DI_FIRMA>Equal</POTERE_DI_FIRMA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PERSONE_X_IMPRESE>
*/
