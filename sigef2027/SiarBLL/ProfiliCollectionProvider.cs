using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Profili
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProfiliProvider
	{
		int Save(Profili ProfiliObj);
		int SaveCollection(ProfiliCollection collectionObj);
		int Delete(Profili ProfiliObj);
		int DeleteCollection(ProfiliCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Profili
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Profili: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.IntNT _Ordine;
		private NullTypes.BoolNT _AbilitaInserimentoUtenti;
		private NullTypes.BoolNT _Attivo;
		[NonSerialized] private IProfiliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProfiliProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Profili()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:ABILITA_INSERIMENTO_UTENTI
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT AbilitaInserimentoUtenti
		{
			get { return _AbilitaInserimentoUtenti; }
			set {
				if (AbilitaInserimentoUtenti != value)
				{
					_AbilitaInserimentoUtenti = value;
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
	/// Summary description for ProfiliCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProfiliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProfiliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Profili) info.GetValue(i.ToString(),typeof(Profili)));
			}
		}

		//Costruttore
		public ProfiliCollection()
		{
			this.ItemType = typeof(Profili);
		}

		//Costruttore con provider
		public ProfiliCollection(IProfiliProvider providerObj)
		{
			this.ItemType = typeof(Profili);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Profili this[int index]
		{
			get { return (Profili)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProfiliCollection GetChanges()
		{
			return (ProfiliCollection) base.GetChanges();
		}

		[NonSerialized] private IProfiliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProfiliProvider Provider
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
		public int Add(Profili ProfiliObj)
		{
			if (ProfiliObj.Provider == null) ProfiliObj.Provider = this.Provider;
			return base.Add(ProfiliObj);
		}

		//AddCollection
		public void AddCollection(ProfiliCollection ProfiliCollectionObj)
		{
			foreach (Profili ProfiliObj in ProfiliCollectionObj)
				this.Add(ProfiliObj);
		}

		//Insert
		public void Insert(int index, Profili ProfiliObj)
		{
			if (ProfiliObj.Provider == null) ProfiliObj.Provider = this.Provider;
			base.Insert(index, ProfiliObj);
		}

		//CollectionGetById
		public Profili CollectionGetById(NullTypes.IntNT IdProfiloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProfilo == IdProfiloValue))
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
		public ProfiliCollection SubSelect(NullTypes.IntNT IdProfiloEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT CodTipoEnteEqualThis, 
NullTypes.IntNT OrdineEqualThis, NullTypes.BoolNT AbilitaInserimentoUtentiEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			ProfiliCollection ProfiliCollectionTemp = new ProfiliCollection();
			foreach (Profili ProfiliItem in this)
			{
				if (((IdProfiloEqualThis == null) || ((ProfiliItem.IdProfilo != null) && (ProfiliItem.IdProfilo.Value == IdProfiloEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ProfiliItem.Descrizione != null) && (ProfiliItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((CodTipoEnteEqualThis == null) || ((ProfiliItem.CodTipoEnte != null) && (ProfiliItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) && 
((OrdineEqualThis == null) || ((ProfiliItem.Ordine != null) && (ProfiliItem.Ordine.Value == OrdineEqualThis.Value))) && ((AbilitaInserimentoUtentiEqualThis == null) || ((ProfiliItem.AbilitaInserimentoUtenti != null) && (ProfiliItem.AbilitaInserimentoUtenti.Value == AbilitaInserimentoUtentiEqualThis.Value))) && ((AttivoEqualThis == null) || ((ProfiliItem.Attivo != null) && (ProfiliItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					ProfiliCollectionTemp.Add(ProfiliItem);
				}
			}
			return ProfiliCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProfiliDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProfiliDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Profili ProfiliObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdProfilo", ProfiliObj.IdProfilo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", ProfiliObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoEnte", ProfiliObj.CodTipoEnte);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", ProfiliObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "AbilitaInserimentoUtenti", ProfiliObj.AbilitaInserimentoUtenti);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", ProfiliObj.Attivo);
		}
		//Insert
		private static int Insert(DbProvider db, Profili ProfiliObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProfiliInsert", new string[] {"Descrizione", "CodTipoEnte", 
"Ordine", "AbilitaInserimentoUtenti", "Attivo"}, new string[] {"string", "string", 
"int", "bool", "bool"},"");
				CompileIUCmd(false, insertCmd,ProfiliObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProfiliObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
				ProfiliObj.AbilitaInserimentoUtenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_INSERIMENTO_UTENTI"]);
				ProfiliObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiliObj.IsDirty = false;
				ProfiliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Profili ProfiliObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProfiliUpdate", new string[] {"IdProfilo", "Descrizione", "CodTipoEnte", 
"Ordine", "AbilitaInserimentoUtenti", "Attivo"}, new string[] {"int", "string", "string", 
"int", "bool", "bool"},"");
				CompileIUCmd(true, updateCmd,ProfiliObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiliObj.IsDirty = false;
				ProfiliObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Profili ProfiliObj)
		{
			switch (ProfiliObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProfiliObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProfiliObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProfiliObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProfiliCollection ProfiliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProfiliUpdate", new string[] {"IdProfilo", "Descrizione", "CodTipoEnte", 
"Ordine", "AbilitaInserimentoUtenti", "Attivo"}, new string[] {"int", "string", "string", 
"int", "bool", "bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProfiliInsert", new string[] {"Descrizione", "CodTipoEnte", 
"Ordine", "AbilitaInserimentoUtenti", "Attivo"}, new string[] {"string", "string", 
"int", "bool", "bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProfiliDelete", new string[] {"IdProfilo"}, new string[] {"int"},"");
				for (int i = 0; i < ProfiliCollectionObj.Count; i++)
				{
					switch (ProfiliCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProfiliCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProfiliCollectionObj[i].IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
									ProfiliCollectionObj[i].AbilitaInserimentoUtenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_INSERIMENTO_UTENTI"]);
									ProfiliCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProfiliCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProfiliCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)ProfiliCollectionObj[i].IdProfilo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProfiliCollectionObj.Count; i++)
				{
					if ((ProfiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProfiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProfiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProfiliCollectionObj[i].IsDirty = false;
						ProfiliCollectionObj[i].IsPersistent = true;
					}
					if ((ProfiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProfiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProfiliCollectionObj[i].IsDirty = false;
						ProfiliCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Profili ProfiliObj)
		{
			int returnValue = 0;
			if (ProfiliObj.IsPersistent) 
			{
				returnValue = Delete(db, ProfiliObj.IdProfilo);
			}
			ProfiliObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProfiliObj.IsDirty = false;
			ProfiliObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdProfiloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProfiliDelete", new string[] {"IdProfilo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)IdProfiloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProfiliCollection ProfiliCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProfiliDelete", new string[] {"IdProfilo"}, new string[] {"int"},"");
				for (int i = 0; i < ProfiliCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdProfilo", ProfiliCollectionObj[i].IdProfilo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProfiliCollectionObj.Count; i++)
				{
					if ((ProfiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProfiliCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProfiliCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProfiliCollectionObj[i].IsDirty = false;
						ProfiliCollectionObj[i].IsPersistent = false;
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
		public static Profili GetById(DbProvider db, int IdProfiloValue)
		{
			Profili ProfiliObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProfiliGetById", new string[] {"IdProfilo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdProfilo", (SiarLibrary.NullTypes.IntNT)IdProfiloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProfiliObj = GetFromDatareader(db);
				ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiliObj.IsDirty = false;
				ProfiliObj.IsPersistent = true;
			}
			db.Close();
			return ProfiliObj;
		}

		//getFromDatareader
		public static Profili GetFromDatareader(DbProvider db)
		{
			Profili ProfiliObj = new Profili();
			ProfiliObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			ProfiliObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProfiliObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProfiliObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			ProfiliObj.AbilitaInserimentoUtenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_INSERIMENTO_UTENTI"]);
			ProfiliObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProfiliObj.IsDirty = false;
			ProfiliObj.IsPersistent = true;
			return ProfiliObj;
		}

		//Find Select

		public static ProfiliCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT AbilitaInserimentoUtentiEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			ProfiliCollection ProfiliCollectionObj = new ProfiliCollection();

			IDbCommand findCmd = db.InitCmd("Zprofilifindselect", new string[] {"IdProfiloequalthis", "Descrizioneequalthis", "CodTipoEnteequalthis", 
"Ordineequalthis", "AbilitaInserimentoUtentiequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"int", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AbilitaInserimentoUtentiequalthis", AbilitaInserimentoUtentiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Profili ProfiliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProfiliObj = GetFromDatareader(db);
				ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiliObj.IsDirty = false;
				ProfiliObj.IsPersistent = true;
				ProfiliCollectionObj.Add(ProfiliObj);
			}
			db.Close();
			return ProfiliCollectionObj;
		}

		//Find Find

		public static ProfiliCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProfiloEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			ProfiliCollection ProfiliCollectionObj = new ProfiliCollection();

			IDbCommand findCmd = db.InitCmd("Zprofilifindfind", new string[] {"IdProfiloequalthis", "Descrizioneequalthis", "CodTipoEnteequalthis", 
"Ordineequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProfiloequalthis", IdProfiloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			Profili ProfiliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProfiliObj = GetFromDatareader(db);
				ProfiliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProfiliObj.IsDirty = false;
				ProfiliObj.IsPersistent = true;
				ProfiliCollectionObj.Add(ProfiliObj);
			}
			db.Close();
			return ProfiliCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProfiliCollectionProvider:IProfiliProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProfiliCollectionProvider : IProfiliProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Profili
		protected ProfiliCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProfiliCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProfiliCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProfiliCollectionProvider(IntNT IdprofiloEqualThis, StringNT DescrizioneEqualThis, StringNT CodtipoenteEqualThis, 
IntNT OrdineEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprofiloEqualThis, DescrizioneEqualThis, CodtipoenteEqualThis, 
OrdineEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input profiliCollectionObj - non popola la collection
		public ProfiliCollectionProvider(ProfiliCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProfiliCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProfiliCollection(this);
		}

		//Get e Set
		public ProfiliCollection CollectionObj
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
		public int SaveCollection(ProfiliCollection collectionObj)
		{
			return ProfiliDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Profili profiliObj)
		{
			return ProfiliDAL.Save(_dbProviderObj, profiliObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProfiliCollection collectionObj)
		{
			return ProfiliDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Profili profiliObj)
		{
			return ProfiliDAL.Delete(_dbProviderObj, profiliObj);
		}

		//getById
		public Profili GetById(IntNT IdProfiloValue)
		{
			Profili ProfiliTemp = ProfiliDAL.GetById(_dbProviderObj, IdProfiloValue);
			if (ProfiliTemp!=null) ProfiliTemp.Provider = this;
			return ProfiliTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProfiliCollection Select(IntNT IdprofiloEqualThis, StringNT DescrizioneEqualThis, StringNT CodtipoenteEqualThis, 
IntNT OrdineEqualThis, BoolNT AbilitainserimentoutentiEqualThis, BoolNT AttivoEqualThis)
		{
			ProfiliCollection ProfiliCollectionTemp = ProfiliDAL.Select(_dbProviderObj, IdprofiloEqualThis, DescrizioneEqualThis, CodtipoenteEqualThis, 
OrdineEqualThis, AbilitainserimentoutentiEqualThis, AttivoEqualThis);
			ProfiliCollectionTemp.Provider = this;
			return ProfiliCollectionTemp;
		}

		//Find: popola la collection
		public ProfiliCollection Find(IntNT IdprofiloEqualThis, StringNT DescrizioneEqualThis, StringNT CodtipoenteEqualThis, 
IntNT OrdineEqualThis, BoolNT AttivoEqualThis)
		{
			ProfiliCollection ProfiliCollectionTemp = ProfiliDAL.Find(_dbProviderObj, IdprofiloEqualThis, DescrizioneEqualThis, CodtipoenteEqualThis, 
OrdineEqualThis, AttivoEqualThis);
			ProfiliCollectionTemp.Provider = this;
			return ProfiliCollectionTemp;
		}

        public ProfiliCollection FindByCodEnte(string cod_ente)
        {
            ProfiliCollection profili = new ProfiliCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (string.IsNullOrEmpty(cod_ente))
                cmd.CommandText = "SELECT ID_PROFILO,DESCRIZIONE,COD_TIPO_ENTE,ORDINE,ABILITA_INSERIMENTO_UTENTI,ATTIVO FROM PROFILI WHERE COD_TIPO_ENTE IS NULL AND ATTIVO=1";
            else
            {
                cmd.CommandText = "SELECT DISTINCT ID_PROFILO,P.DESCRIZIONE,P.COD_TIPO_ENTE,ORDINE,ABILITA_INSERIMENTO_UTENTI,P.ATTIVO FROM PROFILI P INNER JOIN ENTE E ON P.COD_TIPO_ENTE=E.COD_TIPO_ENTE WHERE E.COD_ENTE=@COD_ENTE AND P.ATTIVO=1";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE", cod_ente));
            }
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) profili.Add(SiarDAL.ProfiliDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return profili;
        }

    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROFILI>
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
    <Find OrderBy="ORDER BY COD_TIPO_ENTE,ORDINE,DESCRIZIONE">
      <ID_PROFILO>Equal</ID_PROFILO>
      <DESCRIZIONE>Equal</DESCRIZIONE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <ORDINE>Equal</ORDINE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PROFILI>
*/
