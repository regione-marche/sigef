using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RichiestaConsulenteAllegato
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRichiestaConsulenteAllegatoProvider
	{
		int Save(RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj);
		int SaveCollection(RichiestaConsulenteAllegatoCollection collectionObj);
		int Delete(RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj);
		int DeleteCollection(RichiestaConsulenteAllegatoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RichiestaConsulenteAllegato
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RichiestaConsulenteAllegato: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRichiestaConsulenteAllegato;
		private NullTypes.IntNT _IdRichiestaConsulente;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompleto;
		private byte[] _Contenuto;
		private NullTypes.IntNT _Dimensione;
		private NullTypes.StringNT _HashCode;
		[NonSerialized] private IRichiestaConsulenteAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteAllegatoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RichiestaConsulenteAllegato()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulenteAllegato
		{
			get { return _IdRichiestaConsulenteAllegato; }
			set {
				if (IdRichiestaConsulenteAllegato != value)
				{
					_IdRichiestaConsulenteAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulente
		{
			get { return _IdRichiestaConsulente; }
			set {
				if (IdRichiestaConsulente != value)
				{
					_IdRichiestaConsulente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFile
		{
			get { return _IdFile; }
			set {
				if (IdFile != value)
				{
					_IdFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:NOME_COMPLETO
		/// Tipo sul db:VARCHAR(510)
		/// </summary>
		public NullTypes.StringNT NomeCompleto
		{
			get { return _NomeCompleto; }
			set {
				if (NomeCompleto != value)
				{
					_NomeCompleto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTENUTO
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] Contenuto
		{
			get { return _Contenuto; }
			set {
				if (Contenuto != value)
				{
					_Contenuto = value;
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

		/// <summary>
		/// Corrisponde al campo:HASH_CODE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT HashCode
		{
			get { return _HashCode; }
			set {
				if (HashCode != value)
				{
					_HashCode = value;
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
	/// Summary description for RichiestaConsulenteAllegatoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteAllegatoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RichiestaConsulenteAllegatoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RichiestaConsulenteAllegato) info.GetValue(i.ToString(),typeof(RichiestaConsulenteAllegato)));
			}
		}

		//Costruttore
		public RichiestaConsulenteAllegatoCollection()
		{
			this.ItemType = typeof(RichiestaConsulenteAllegato);
		}

		//Costruttore con provider
		public RichiestaConsulenteAllegatoCollection(IRichiestaConsulenteAllegatoProvider providerObj)
		{
			this.ItemType = typeof(RichiestaConsulenteAllegato);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RichiestaConsulenteAllegato this[int index]
		{
			get { return (RichiestaConsulenteAllegato)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RichiestaConsulenteAllegatoCollection GetChanges()
		{
			return (RichiestaConsulenteAllegatoCollection) base.GetChanges();
		}

		[NonSerialized] private IRichiestaConsulenteAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteAllegatoProvider Provider
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
		public int Add(RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			if (RichiestaConsulenteAllegatoObj.Provider == null) RichiestaConsulenteAllegatoObj.Provider = this.Provider;
			return base.Add(RichiestaConsulenteAllegatoObj);
		}

		//AddCollection
		public void AddCollection(RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionObj)
		{
			foreach (RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj in RichiestaConsulenteAllegatoCollectionObj)
				this.Add(RichiestaConsulenteAllegatoObj);
		}

		//Insert
		public void Insert(int index, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			if (RichiestaConsulenteAllegatoObj.Provider == null) RichiestaConsulenteAllegatoObj.Provider = this.Provider;
			base.Insert(index, RichiestaConsulenteAllegatoObj);
		}

		//CollectionGetById
		public RichiestaConsulenteAllegato CollectionGetById(NullTypes.IntNT IdRichiestaConsulenteAllegatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRichiestaConsulenteAllegato == IdRichiestaConsulenteAllegatoValue))
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
		public RichiestaConsulenteAllegatoCollection SubSelect(NullTypes.IntNT IdRichiestaConsulenteAllegatoEqualThis, NullTypes.IntNT IdRichiestaConsulenteEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionTemp = new RichiestaConsulenteAllegatoCollection();
			foreach (RichiestaConsulenteAllegato RichiestaConsulenteAllegatoItem in this)
			{
				if (((IdRichiestaConsulenteAllegatoEqualThis == null) || ((RichiestaConsulenteAllegatoItem.IdRichiestaConsulenteAllegato != null) && (RichiestaConsulenteAllegatoItem.IdRichiestaConsulenteAllegato.Value == IdRichiestaConsulenteAllegatoEqualThis.Value))) && ((IdRichiestaConsulenteEqualThis == null) || ((RichiestaConsulenteAllegatoItem.IdRichiestaConsulente != null) && (RichiestaConsulenteAllegatoItem.IdRichiestaConsulente.Value == IdRichiestaConsulenteEqualThis.Value))) && ((IdFileEqualThis == null) || ((RichiestaConsulenteAllegatoItem.IdFile != null) && (RichiestaConsulenteAllegatoItem.IdFile.Value == IdFileEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((RichiestaConsulenteAllegatoItem.Descrizione != null) && (RichiestaConsulenteAllegatoItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					RichiestaConsulenteAllegatoCollectionTemp.Add(RichiestaConsulenteAllegatoItem);
				}
			}
			return RichiestaConsulenteAllegatoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteAllegatoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RichiestaConsulenteAllegatoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulenteAllegato", RichiestaConsulenteAllegatoObj.IdRichiestaConsulenteAllegato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulente", RichiestaConsulenteAllegatoObj.IdRichiestaConsulente);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", RichiestaConsulenteAllegatoObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", RichiestaConsulenteAllegatoObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoInsert", new string[] {"IdRichiestaConsulente", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", 
"string", 
},"");
				CompileIUCmd(false, insertCmd,RichiestaConsulenteAllegatoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RichiestaConsulenteAllegatoObj.IdRichiestaConsulenteAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_ALLEGATO"]);
				}
				RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteAllegatoObj.IsDirty = false;
				RichiestaConsulenteAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoUpdate", new string[] {"IdRichiestaConsulenteAllegato", "IdRichiestaConsulente", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", "int", 
"string", 
},"");
				CompileIUCmd(true, updateCmd,RichiestaConsulenteAllegatoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteAllegatoObj.IsDirty = false;
				RichiestaConsulenteAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			switch (RichiestaConsulenteAllegatoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RichiestaConsulenteAllegatoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RichiestaConsulenteAllegatoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RichiestaConsulenteAllegatoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoUpdate", new string[] {"IdRichiestaConsulenteAllegato", "IdRichiestaConsulente", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", "int", 
"string", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoInsert", new string[] {"IdRichiestaConsulente", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", 
"string", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoDelete", new string[] {"IdRichiestaConsulenteAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteAllegatoCollectionObj.Count; i++)
				{
					switch (RichiestaConsulenteAllegatoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RichiestaConsulenteAllegatoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RichiestaConsulenteAllegatoCollectionObj[i].IdRichiestaConsulenteAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_ALLEGATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RichiestaConsulenteAllegatoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RichiestaConsulenteAllegatoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegato", (SiarLibrary.NullTypes.IntNT)RichiestaConsulenteAllegatoCollectionObj[i].IdRichiestaConsulenteAllegato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteAllegatoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RichiestaConsulenteAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteAllegatoCollectionObj[i].IsPersistent = true;
					}
					if ((RichiestaConsulenteAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RichiestaConsulenteAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteAllegatoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj)
		{
			int returnValue = 0;
			if (RichiestaConsulenteAllegatoObj.IsPersistent) 
			{
				returnValue = Delete(db, RichiestaConsulenteAllegatoObj.IdRichiestaConsulenteAllegato);
			}
			RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RichiestaConsulenteAllegatoObj.IsDirty = false;
			RichiestaConsulenteAllegatoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRichiestaConsulenteAllegatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoDelete", new string[] {"IdRichiestaConsulenteAllegato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegato", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteAllegatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoDelete", new string[] {"IdRichiestaConsulenteAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteAllegatoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegato", RichiestaConsulenteAllegatoCollectionObj[i].IdRichiestaConsulenteAllegato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteAllegatoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteAllegatoCollectionObj[i].IsPersistent = false;
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
		public static RichiestaConsulenteAllegato GetById(DbProvider db, int IdRichiestaConsulenteAllegatoValue)
		{
			RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRichiestaConsulenteAllegatoGetById", new string[] {"IdRichiestaConsulenteAllegato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegato", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteAllegatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RichiestaConsulenteAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteAllegatoObj.IsDirty = false;
				RichiestaConsulenteAllegatoObj.IsPersistent = true;
			}
			db.Close();
			return RichiestaConsulenteAllegatoObj;
		}

		//getFromDatareader
		public static RichiestaConsulenteAllegato GetFromDatareader(DbProvider db)
		{
			RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj = new RichiestaConsulenteAllegato();
			RichiestaConsulenteAllegatoObj.IdRichiestaConsulenteAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_ALLEGATO"]);
			RichiestaConsulenteAllegatoObj.IdRichiestaConsulente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE"]);
			RichiestaConsulenteAllegatoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			RichiestaConsulenteAllegatoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RichiestaConsulenteAllegatoObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			RichiestaConsulenteAllegatoObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			RichiestaConsulenteAllegatoObj.NomeCompleto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO"]);
			RichiestaConsulenteAllegatoObj.Contenuto =  Convert.IsDBNull(db.DataReader["CONTENUTO"]) ? null : (byte[])db.DataReader["CONTENUTO"];
			RichiestaConsulenteAllegatoObj.Dimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE"]);
			RichiestaConsulenteAllegatoObj.HashCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE"]);
			RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RichiestaConsulenteAllegatoObj.IsDirty = false;
			RichiestaConsulenteAllegatoObj.IsPersistent = true;
			return RichiestaConsulenteAllegatoObj;
		}

		//Find Select

		public static RichiestaConsulenteAllegatoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionObj = new RichiestaConsulenteAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteallegatofindselect", new string[] {"IdRichiestaConsulenteAllegatoequalthis", "IdRichiestaConsulenteequalthis", "IdFileequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegatoequalthis", IdRichiestaConsulenteAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteequalthis", IdRichiestaConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteAllegatoObj.IsDirty = false;
				RichiestaConsulenteAllegatoObj.IsPersistent = true;
				RichiestaConsulenteAllegatoCollectionObj.Add(RichiestaConsulenteAllegatoObj);
			}
			db.Close();
			return RichiestaConsulenteAllegatoCollectionObj;
		}

		//Find Find

		public static RichiestaConsulenteAllegatoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionObj = new RichiestaConsulenteAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteallegatofindfind", new string[] {"IdRichiestaConsulenteAllegatoequalthis", "IdRichiestaConsulenteequalthis", "IdFileequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteAllegatoequalthis", IdRichiestaConsulenteAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteequalthis", IdRichiestaConsulenteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			RichiestaConsulenteAllegato RichiestaConsulenteAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteAllegatoObj.IsDirty = false;
				RichiestaConsulenteAllegatoObj.IsPersistent = true;
				RichiestaConsulenteAllegatoCollectionObj.Add(RichiestaConsulenteAllegatoObj);
			}
			db.Close();
			return RichiestaConsulenteAllegatoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteAllegatoCollectionProvider:IRichiestaConsulenteAllegatoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteAllegatoCollectionProvider : IRichiestaConsulenteAllegatoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RichiestaConsulenteAllegato
		protected RichiestaConsulenteAllegatoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RichiestaConsulenteAllegatoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RichiestaConsulenteAllegatoCollection(this);
		}

		//Costruttore 2: popola la collection
		public RichiestaConsulenteAllegatoCollectionProvider(IntNT IdrichiestaconsulenteallegatoEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrichiestaconsulenteallegatoEqualThis, IdrichiestaconsulenteEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input richiestaconsulenteallegatoCollectionObj - non popola la collection
		public RichiestaConsulenteAllegatoCollectionProvider(RichiestaConsulenteAllegatoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RichiestaConsulenteAllegatoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RichiestaConsulenteAllegatoCollection(this);
		}

		//Get e Set
		public RichiestaConsulenteAllegatoCollection CollectionObj
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
		public int SaveCollection(RichiestaConsulenteAllegatoCollection collectionObj)
		{
			return RichiestaConsulenteAllegatoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RichiestaConsulenteAllegato richiestaconsulenteallegatoObj)
		{
			return RichiestaConsulenteAllegatoDAL.Save(_dbProviderObj, richiestaconsulenteallegatoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RichiestaConsulenteAllegatoCollection collectionObj)
		{
			return RichiestaConsulenteAllegatoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RichiestaConsulenteAllegato richiestaconsulenteallegatoObj)
		{
			return RichiestaConsulenteAllegatoDAL.Delete(_dbProviderObj, richiestaconsulenteallegatoObj);
		}

		//getById
		public RichiestaConsulenteAllegato GetById(IntNT IdRichiestaConsulenteAllegatoValue)
		{
			RichiestaConsulenteAllegato RichiestaConsulenteAllegatoTemp = RichiestaConsulenteAllegatoDAL.GetById(_dbProviderObj, IdRichiestaConsulenteAllegatoValue);
			if (RichiestaConsulenteAllegatoTemp!=null) RichiestaConsulenteAllegatoTemp.Provider = this;
			return RichiestaConsulenteAllegatoTemp;
		}

		//Select: popola la collection
		public RichiestaConsulenteAllegatoCollection Select(IntNT IdrichiestaconsulenteallegatoEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdfileEqualThis, 
StringNT DescrizioneEqualThis)
		{
			RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionTemp = RichiestaConsulenteAllegatoDAL.Select(_dbProviderObj, IdrichiestaconsulenteallegatoEqualThis, IdrichiestaconsulenteEqualThis, IdfileEqualThis, 
DescrizioneEqualThis);
			RichiestaConsulenteAllegatoCollectionTemp.Provider = this;
			return RichiestaConsulenteAllegatoCollectionTemp;
		}

		//Find: popola la collection
		public RichiestaConsulenteAllegatoCollection Find(IntNT IdrichiestaconsulenteallegatoEqualThis, IntNT IdrichiestaconsulenteEqualThis, IntNT IdfileEqualThis)
		{
			RichiestaConsulenteAllegatoCollection RichiestaConsulenteAllegatoCollectionTemp = RichiestaConsulenteAllegatoDAL.Find(_dbProviderObj, IdrichiestaconsulenteallegatoEqualThis, IdrichiestaconsulenteEqualThis, IdfileEqualThis);
			RichiestaConsulenteAllegatoCollectionTemp.Provider = this;
			return RichiestaConsulenteAllegatoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICHIESTA_CONSULENTE_ALLEGATO>
  <ViewName>vRICHIESTA_CONSULENTE_ALLEGATO</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_RICHIESTA_CONSULENTE_ALLEGATO>Equal</ID_RICHIESTA_CONSULENTE_ALLEGATO>
      <ID_RICHIESTA_CONSULENTE>Equal</ID_RICHIESTA_CONSULENTE>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICHIESTA_CONSULENTE_ALLEGATO>
*/
