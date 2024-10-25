using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per RichiestaConsulenteProcuraAllegato
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRichiestaConsulenteProcuraAllegatoProvider
	{
		int Save(RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj);
		int SaveCollection(RichiestaConsulenteProcuraAllegatoCollection collectionObj);
		int Delete(RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj);
		int DeleteCollection(RichiestaConsulenteProcuraAllegatoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraAllegato
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class RichiestaConsulenteProcuraAllegato: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRichiestaConsulenteProcuraAllegato;
		private NullTypes.IntNT _IdRichiestaConsulenteProcuraXBando;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompleto;
		private byte[] _Contenuto;
		private NullTypes.IntNT _Dimensione;
		private NullTypes.StringNT _HashCode;
		[NonSerialized] private IRichiestaConsulenteProcuraAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProcuraAllegatoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RichiestaConsulenteProcuraAllegato()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE_PROCURA_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulenteProcuraAllegato
		{
			get { return _IdRichiestaConsulenteProcuraAllegato; }
			set {
				if (IdRichiestaConsulenteProcuraAllegato != value)
				{
					_IdRichiestaConsulenteProcuraAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA_CONSULENTE_PROCURA_X_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRichiestaConsulenteProcuraXBando
		{
			get { return _IdRichiestaConsulenteProcuraXBando; }
			set {
				if (IdRichiestaConsulenteProcuraXBando != value)
				{
					_IdRichiestaConsulenteProcuraXBando = value;
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
	/// Summary description for RichiestaConsulenteProcuraAllegatoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteProcuraAllegatoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RichiestaConsulenteProcuraAllegatoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RichiestaConsulenteProcuraAllegato) info.GetValue(i.ToString(),typeof(RichiestaConsulenteProcuraAllegato)));
			}
		}

		//Costruttore
		public RichiestaConsulenteProcuraAllegatoCollection()
		{
			this.ItemType = typeof(RichiestaConsulenteProcuraAllegato);
		}

		//Costruttore con provider
		public RichiestaConsulenteProcuraAllegatoCollection(IRichiestaConsulenteProcuraAllegatoProvider providerObj)
		{
			this.ItemType = typeof(RichiestaConsulenteProcuraAllegato);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RichiestaConsulenteProcuraAllegato this[int index]
		{
			get { return (RichiestaConsulenteProcuraAllegato)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RichiestaConsulenteProcuraAllegatoCollection GetChanges()
		{
			return (RichiestaConsulenteProcuraAllegatoCollection) base.GetChanges();
		}

		[NonSerialized] private IRichiestaConsulenteProcuraAllegatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRichiestaConsulenteProcuraAllegatoProvider Provider
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
		public int Add(RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			if (RichiestaConsulenteProcuraAllegatoObj.Provider == null) RichiestaConsulenteProcuraAllegatoObj.Provider = this.Provider;
			return base.Add(RichiestaConsulenteProcuraAllegatoObj);
		}

		//AddCollection
		public void AddCollection(RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionObj)
		{
			foreach (RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj in RichiestaConsulenteProcuraAllegatoCollectionObj)
				this.Add(RichiestaConsulenteProcuraAllegatoObj);
		}

		//Insert
		public void Insert(int index, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			if (RichiestaConsulenteProcuraAllegatoObj.Provider == null) RichiestaConsulenteProcuraAllegatoObj.Provider = this.Provider;
			base.Insert(index, RichiestaConsulenteProcuraAllegatoObj);
		}

		//CollectionGetById
		public RichiestaConsulenteProcuraAllegato CollectionGetById(NullTypes.IntNT IdRichiestaConsulenteProcuraAllegatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRichiestaConsulenteProcuraAllegato == IdRichiestaConsulenteProcuraAllegatoValue))
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
		public RichiestaConsulenteProcuraAllegatoCollection SubSelect(NullTypes.IntNT IdRichiestaConsulenteProcuraAllegatoEqualThis, NullTypes.IntNT IdRichiestaConsulenteProcuraXBandoEqualThis, NullTypes.IntNT IdFileEqualThis, 
NullTypes.StringNT DescrizioneEqualThis)
		{
			RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionTemp = new RichiestaConsulenteProcuraAllegatoCollection();
			foreach (RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoItem in this)
			{
				if (((IdRichiestaConsulenteProcuraAllegatoEqualThis == null) || ((RichiestaConsulenteProcuraAllegatoItem.IdRichiestaConsulenteProcuraAllegato != null) && (RichiestaConsulenteProcuraAllegatoItem.IdRichiestaConsulenteProcuraAllegato.Value == IdRichiestaConsulenteProcuraAllegatoEqualThis.Value))) && ((IdRichiestaConsulenteProcuraXBandoEqualThis == null) || ((RichiestaConsulenteProcuraAllegatoItem.IdRichiestaConsulenteProcuraXBando != null) && (RichiestaConsulenteProcuraAllegatoItem.IdRichiestaConsulenteProcuraXBando.Value == IdRichiestaConsulenteProcuraXBandoEqualThis.Value))) && ((IdFileEqualThis == null) || ((RichiestaConsulenteProcuraAllegatoItem.IdFile != null) && (RichiestaConsulenteProcuraAllegatoItem.IdFile.Value == IdFileEqualThis.Value))) && 
((DescrizioneEqualThis == null) || ((RichiestaConsulenteProcuraAllegatoItem.Descrizione != null) && (RichiestaConsulenteProcuraAllegatoItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					RichiestaConsulenteProcuraAllegatoCollectionTemp.Add(RichiestaConsulenteProcuraAllegatoItem);
				}
			}
			return RichiestaConsulenteProcuraAllegatoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraAllegatoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class RichiestaConsulenteProcuraAllegatoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulenteProcuraAllegato", RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraAllegato);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdRichiestaConsulenteProcuraXBando", RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraXBando);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", RichiestaConsulenteProcuraAllegatoObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", RichiestaConsulenteProcuraAllegatoObj.Descrizione);
		}
		//Insert
		private static int Insert(DbProvider db, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoInsert", new string[] {"IdRichiestaConsulenteProcuraXBando", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", 
"string", 
},"");
				CompileIUCmd(false, insertCmd,RichiestaConsulenteProcuraAllegatoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_PROCURA_ALLEGATO"]);
				}
				RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
				RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoUpdate", new string[] {"IdRichiestaConsulenteProcuraAllegato", "IdRichiestaConsulenteProcuraXBando", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", "int", 
"string", 
},"");
				CompileIUCmd(true, updateCmd,RichiestaConsulenteProcuraAllegatoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
				RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			switch (RichiestaConsulenteProcuraAllegatoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, RichiestaConsulenteProcuraAllegatoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, RichiestaConsulenteProcuraAllegatoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,RichiestaConsulenteProcuraAllegatoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoUpdate", new string[] {"IdRichiestaConsulenteProcuraAllegato", "IdRichiestaConsulenteProcuraXBando", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", "int", 
"string", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoInsert", new string[] {"IdRichiestaConsulenteProcuraXBando", "IdFile", 
"Descrizione", 
}, new string[] {"int", "int", 
"string", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoDelete", new string[] {"IdRichiestaConsulenteProcuraAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteProcuraAllegatoCollectionObj.Count; i++)
				{
					switch (RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,RichiestaConsulenteProcuraAllegatoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									RichiestaConsulenteProcuraAllegatoCollectionObj[i].IdRichiestaConsulenteProcuraAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_PROCURA_ALLEGATO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,RichiestaConsulenteProcuraAllegatoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraAllegato", (SiarLibrary.NullTypes.IntNT)RichiestaConsulenteProcuraAllegatoCollectionObj[i].IdRichiestaConsulenteProcuraAllegato);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteProcuraAllegatoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsPersistent = true;
					}
					if ((RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj)
		{
			int returnValue = 0;
			if (RichiestaConsulenteProcuraAllegatoObj.IsPersistent) 
			{
				returnValue = Delete(db, RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraAllegato);
			}
			RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
			RichiestaConsulenteProcuraAllegatoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdRichiestaConsulenteProcuraAllegatoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoDelete", new string[] {"IdRichiestaConsulenteProcuraAllegato"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraAllegato", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteProcuraAllegatoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoDelete", new string[] {"IdRichiestaConsulenteProcuraAllegato"}, new string[] {"int"},"");
				for (int i = 0; i < RichiestaConsulenteProcuraAllegatoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraAllegato", RichiestaConsulenteProcuraAllegatoCollectionObj[i].IdRichiestaConsulenteProcuraAllegato);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < RichiestaConsulenteProcuraAllegatoCollectionObj.Count; i++)
				{
					if ((RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsDirty = false;
						RichiestaConsulenteProcuraAllegatoCollectionObj[i].IsPersistent = false;
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
		public static RichiestaConsulenteProcuraAllegato GetById(DbProvider db, int IdRichiestaConsulenteProcuraAllegatoValue)
		{
			RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZRichiestaConsulenteProcuraAllegatoGetById", new string[] {"IdRichiestaConsulenteProcuraAllegato"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraAllegato", (SiarLibrary.NullTypes.IntNT)IdRichiestaConsulenteProcuraAllegatoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
				RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
			}
			db.Close();
			return RichiestaConsulenteProcuraAllegatoObj;
		}

		//getFromDatareader
		public static RichiestaConsulenteProcuraAllegato GetFromDatareader(DbProvider db)
		{
			RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj = new RichiestaConsulenteProcuraAllegato();
			RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_PROCURA_ALLEGATO"]);
			RichiestaConsulenteProcuraAllegatoObj.IdRichiestaConsulenteProcuraXBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RICHIESTA_CONSULENTE_PROCURA_X_BANDO"]);
			RichiestaConsulenteProcuraAllegatoObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			RichiestaConsulenteProcuraAllegatoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			RichiestaConsulenteProcuraAllegatoObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			RichiestaConsulenteProcuraAllegatoObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			RichiestaConsulenteProcuraAllegatoObj.NomeCompleto = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO"]);
			RichiestaConsulenteProcuraAllegatoObj.Contenuto =  Convert.IsDBNull(db.DataReader["CONTENUTO"]) ? null : (byte[])db.DataReader["CONTENUTO"];
			RichiestaConsulenteProcuraAllegatoObj.Dimensione = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE"]);
			RichiestaConsulenteProcuraAllegatoObj.HashCode = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE"]);
			RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
			RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
			return RichiestaConsulenteProcuraAllegatoObj;
		}

		//Find Select

		public static RichiestaConsulenteProcuraAllegatoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteProcuraAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteProcuraXBandoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis)

		{

			RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionObj = new RichiestaConsulenteProcuraAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteprocuraallegatofindselect", new string[] {"IdRichiestaConsulenteProcuraAllegatoequalthis", "IdRichiestaConsulenteProcuraXBandoequalthis", "IdFileequalthis", 
"Descrizioneequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraAllegatoequalthis", IdRichiestaConsulenteProcuraAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraXBandoequalthis", IdRichiestaConsulenteProcuraXBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
				RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
				RichiestaConsulenteProcuraAllegatoCollectionObj.Add(RichiestaConsulenteProcuraAllegatoObj);
			}
			db.Close();
			return RichiestaConsulenteProcuraAllegatoCollectionObj;
		}

		//Find Find

		public static RichiestaConsulenteProcuraAllegatoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRichiestaConsulenteProcuraXBandoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis)

		{

			RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionObj = new RichiestaConsulenteProcuraAllegatoCollection();

			IDbCommand findCmd = db.InitCmd("Zrichiestaconsulenteprocuraallegatofindfind", new string[] {"IdRichiestaConsulenteProcuraXBandoequalthis", "IdFileequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaConsulenteProcuraXBandoequalthis", IdRichiestaConsulenteProcuraXBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				RichiestaConsulenteProcuraAllegatoObj = GetFromDatareader(db);
				RichiestaConsulenteProcuraAllegatoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				RichiestaConsulenteProcuraAllegatoObj.IsDirty = false;
				RichiestaConsulenteProcuraAllegatoObj.IsPersistent = true;
				RichiestaConsulenteProcuraAllegatoCollectionObj.Add(RichiestaConsulenteProcuraAllegatoObj);
			}
			db.Close();
			return RichiestaConsulenteProcuraAllegatoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for RichiestaConsulenteProcuraAllegatoCollectionProvider:IRichiestaConsulenteProcuraAllegatoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class RichiestaConsulenteProcuraAllegatoCollectionProvider : IRichiestaConsulenteProcuraAllegatoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RichiestaConsulenteProcuraAllegato
		protected RichiestaConsulenteProcuraAllegatoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RichiestaConsulenteProcuraAllegatoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RichiestaConsulenteProcuraAllegatoCollection(this);
		}

		//Costruttore 2: popola la collection
		public RichiestaConsulenteProcuraAllegatoCollectionProvider(IntNT IdrichiestaconsulenteprocuraxbandoEqualThis, IntNT IdfileEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrichiestaconsulenteprocuraxbandoEqualThis, IdfileEqualThis);
		}

		//Costruttore3: ha in input richiestaconsulenteprocuraallegatoCollectionObj - non popola la collection
		public RichiestaConsulenteProcuraAllegatoCollectionProvider(RichiestaConsulenteProcuraAllegatoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RichiestaConsulenteProcuraAllegatoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RichiestaConsulenteProcuraAllegatoCollection(this);
		}

		//Get e Set
		public RichiestaConsulenteProcuraAllegatoCollection CollectionObj
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
		public int SaveCollection(RichiestaConsulenteProcuraAllegatoCollection collectionObj)
		{
			return RichiestaConsulenteProcuraAllegatoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RichiestaConsulenteProcuraAllegato richiestaconsulenteprocuraallegatoObj)
		{
			return RichiestaConsulenteProcuraAllegatoDAL.Save(_dbProviderObj, richiestaconsulenteprocuraallegatoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RichiestaConsulenteProcuraAllegatoCollection collectionObj)
		{
			return RichiestaConsulenteProcuraAllegatoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RichiestaConsulenteProcuraAllegato richiestaconsulenteprocuraallegatoObj)
		{
			return RichiestaConsulenteProcuraAllegatoDAL.Delete(_dbProviderObj, richiestaconsulenteprocuraallegatoObj);
		}

		//getById
		public RichiestaConsulenteProcuraAllegato GetById(IntNT IdRichiestaConsulenteProcuraAllegatoValue)
		{
			RichiestaConsulenteProcuraAllegato RichiestaConsulenteProcuraAllegatoTemp = RichiestaConsulenteProcuraAllegatoDAL.GetById(_dbProviderObj, IdRichiestaConsulenteProcuraAllegatoValue);
			if (RichiestaConsulenteProcuraAllegatoTemp!=null) RichiestaConsulenteProcuraAllegatoTemp.Provider = this;
			return RichiestaConsulenteProcuraAllegatoTemp;
		}

		//Select: popola la collection
		public RichiestaConsulenteProcuraAllegatoCollection Select(IntNT IdrichiestaconsulenteprocuraallegatoEqualThis, IntNT IdrichiestaconsulenteprocuraxbandoEqualThis, IntNT IdfileEqualThis, 
StringNT DescrizioneEqualThis)
		{
			RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionTemp = RichiestaConsulenteProcuraAllegatoDAL.Select(_dbProviderObj, IdrichiestaconsulenteprocuraallegatoEqualThis, IdrichiestaconsulenteprocuraxbandoEqualThis, IdfileEqualThis, 
DescrizioneEqualThis);
			RichiestaConsulenteProcuraAllegatoCollectionTemp.Provider = this;
			return RichiestaConsulenteProcuraAllegatoCollectionTemp;
		}

		//Find: popola la collection
		public RichiestaConsulenteProcuraAllegatoCollection Find(IntNT IdrichiestaconsulenteprocuraxbandoEqualThis, IntNT IdfileEqualThis)
		{
			RichiestaConsulenteProcuraAllegatoCollection RichiestaConsulenteProcuraAllegatoCollectionTemp = RichiestaConsulenteProcuraAllegatoDAL.Find(_dbProviderObj, IdrichiestaconsulenteprocuraxbandoEqualThis, IdfileEqualThis);
			RichiestaConsulenteProcuraAllegatoCollectionTemp.Provider = this;
			return RichiestaConsulenteProcuraAllegatoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RICHIESTA_CONSULENTE_PROCURA_ALLEGATO>
  <ViewName>vRICHIESTA_CONSULENTE_PROCURA_ALLEGATO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
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
      <ID_RICHIESTA_CONSULENTE_PROCURA_X_BANDO>Equal</ID_RICHIESTA_CONSULENTE_PROCURA_X_BANDO>
      <ID_FILE>Equal</ID_FILE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RICHIESTA_CONSULENTE_PROCURA_ALLEGATO>
*/
