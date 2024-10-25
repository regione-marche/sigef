using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per BandoTipoInvestimenti
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IBandoTipoInvestimentiProvider
	{
		int Save(BandoTipoInvestimenti BandoTipoInvestimentiObj);
		int SaveCollection(BandoTipoInvestimentiCollection collectionObj);
		int Delete(BandoTipoInvestimenti BandoTipoInvestimentiObj);
		int DeleteCollection(BandoTipoInvestimentiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for BandoTipoInvestimenti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class BandoTipoInvestimenti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdTipoInvestimento;
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _CodTipoInvestimento;
		private NullTypes.DecimalNT _ImportoMax;
		private NullTypes.DecimalNT _ImportoMin;
		private NullTypes.DecimalNT _QuotaMax;
		private NullTypes.StringNT _Note;
		private NullTypes.BoolNT _Premio;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _Text;
		[NonSerialized] private IBandoTipoInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoTipoInvestimentiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public BandoTipoInvestimenti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_TIPO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoInvestimento
		{
			get { return _IdTipoInvestimento; }
			set {
				if (IdTipoInvestimento != value)
				{
					_IdTipoInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_INVESTIMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodTipoInvestimento
		{
			get { return _CodTipoInvestimento; }
			set {
				if (CodTipoInvestimento != value)
				{
					_CodTipoInvestimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_MAX
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoMax
		{
			get { return _ImportoMax; }
			set {
				if (ImportoMax != value)
				{
					_ImportoMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_MIN
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoMin
		{
			get { return _ImportoMin; }
			set {
				if (ImportoMin != value)
				{
					_ImportoMin = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUOTA_MAX
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT QuotaMax
		{
			get { return _QuotaMax; }
			set {
				if (QuotaMax != value)
				{
					_QuotaMax = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOTE
		/// Tipo sul db:VARCHAR(500)
		/// </summary>
		public NullTypes.StringNT Note
		{
			get { return _Note; }
			set {
				if (Note != value)
				{
					_Note = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREMIO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Premio
		{
			get { return _Premio; }
			set {
				if (Premio != value)
				{
					_Premio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TEXT
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Text
		{
			get { return _Text; }
			set {
				if (Text != value)
				{
					_Text = value;
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
	/// Summary description for BandoTipoInvestimentiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoTipoInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoTipoInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoTipoInvestimenti) info.GetValue(i.ToString(),typeof(BandoTipoInvestimenti)));
			}
		}

		//Costruttore
		public BandoTipoInvestimentiCollection()
		{
			this.ItemType = typeof(BandoTipoInvestimenti);
		}

		//Costruttore con provider
		public BandoTipoInvestimentiCollection(IBandoTipoInvestimentiProvider providerObj)
		{
			this.ItemType = typeof(BandoTipoInvestimenti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoTipoInvestimenti this[int index]
		{
			get { return (BandoTipoInvestimenti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoTipoInvestimentiCollection GetChanges()
		{
			return (BandoTipoInvestimentiCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoTipoInvestimentiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoTipoInvestimentiProvider Provider
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
		public int Add(BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			if (BandoTipoInvestimentiObj.Provider == null) BandoTipoInvestimentiObj.Provider = this.Provider;
			return base.Add(BandoTipoInvestimentiObj);
		}

		//AddCollection
		public void AddCollection(BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionObj)
		{
			foreach (BandoTipoInvestimenti BandoTipoInvestimentiObj in BandoTipoInvestimentiCollectionObj)
				this.Add(BandoTipoInvestimentiObj);
		}

		//Insert
		public void Insert(int index, BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			if (BandoTipoInvestimentiObj.Provider == null) BandoTipoInvestimentiObj.Provider = this.Provider;
			base.Insert(index, BandoTipoInvestimentiObj);
		}

		//CollectionGetById
		public BandoTipoInvestimenti CollectionGetById(NullTypes.IntNT IdTipoInvestimentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdTipoInvestimento == IdTipoInvestimentoValue))
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
		public BandoTipoInvestimentiCollection SubSelect(NullTypes.IntNT IdTipoInvestimentoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT CodTipoInvestimentoEqualThis, 
NullTypes.DecimalNT ImportoMaxEqualThis, NullTypes.DecimalNT ImportoMinEqualThis, NullTypes.DecimalNT QuotaMaxEqualThis, 
NullTypes.StringNT NoteEqualThis, NullTypes.BoolNT PremioEqualThis)
		{
			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionTemp = new BandoTipoInvestimentiCollection();
			foreach (BandoTipoInvestimenti BandoTipoInvestimentiItem in this)
			{
				if (((IdTipoInvestimentoEqualThis == null) || ((BandoTipoInvestimentiItem.IdTipoInvestimento != null) && (BandoTipoInvestimentiItem.IdTipoInvestimento.Value == IdTipoInvestimentoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((BandoTipoInvestimentiItem.IdBando != null) && (BandoTipoInvestimentiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoInvestimentoEqualThis == null) || ((BandoTipoInvestimentiItem.CodTipoInvestimento != null) && (BandoTipoInvestimentiItem.CodTipoInvestimento.Value == CodTipoInvestimentoEqualThis.Value))) && 
((ImportoMaxEqualThis == null) || ((BandoTipoInvestimentiItem.ImportoMax != null) && (BandoTipoInvestimentiItem.ImportoMax.Value == ImportoMaxEqualThis.Value))) && ((ImportoMinEqualThis == null) || ((BandoTipoInvestimentiItem.ImportoMin != null) && (BandoTipoInvestimentiItem.ImportoMin.Value == ImportoMinEqualThis.Value))) && ((QuotaMaxEqualThis == null) || ((BandoTipoInvestimentiItem.QuotaMax != null) && (BandoTipoInvestimentiItem.QuotaMax.Value == QuotaMaxEqualThis.Value))) && 
((NoteEqualThis == null) || ((BandoTipoInvestimentiItem.Note != null) && (BandoTipoInvestimentiItem.Note.Value == NoteEqualThis.Value))) && ((PremioEqualThis == null) || ((BandoTipoInvestimentiItem.Premio != null) && (BandoTipoInvestimentiItem.Premio.Value == PremioEqualThis.Value))))
				{
					BandoTipoInvestimentiCollectionTemp.Add(BandoTipoInvestimentiItem);
				}
			}
			return BandoTipoInvestimentiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoTipoInvestimentiCollection FiltroCodiceTipo(NullTypes.IntNT CodTipoInvestimentoEqualThis)
		{
			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionTemp = new BandoTipoInvestimentiCollection();
			foreach (BandoTipoInvestimenti BandoTipoInvestimentiItem in this)
			{
				if (((CodTipoInvestimentoEqualThis == null) || ((BandoTipoInvestimentiItem.CodTipoInvestimento != null) && (BandoTipoInvestimentiItem.CodTipoInvestimento.Value == CodTipoInvestimentoEqualThis.Value))))
				{
					BandoTipoInvestimentiCollectionTemp.Add(BandoTipoInvestimentiItem);
				}
			}
			return BandoTipoInvestimentiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for BandoTipoInvestimentiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class BandoTipoInvestimentiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, BandoTipoInvestimenti BandoTipoInvestimentiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdTipoInvestimento", BandoTipoInvestimentiObj.IdTipoInvestimento);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", BandoTipoInvestimentiObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipoInvestimento", BandoTipoInvestimentiObj.CodTipoInvestimento);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoMax", BandoTipoInvestimentiObj.ImportoMax);
			DbProvider.SetCmdParam(cmd,firstChar + "ImportoMin", BandoTipoInvestimentiObj.ImportoMin);
			DbProvider.SetCmdParam(cmd,firstChar + "QuotaMax", BandoTipoInvestimentiObj.QuotaMax);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", BandoTipoInvestimentiObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Premio", BandoTipoInvestimentiObj.Premio);
		}
		//Insert
		private static int Insert(DbProvider db, BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoInvestimentiInsert", new string[] {"IdBando", "CodTipoInvestimento", 
"ImportoMax", "ImportoMin", "QuotaMax", 
"Note", "Premio", }, new string[] {"int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", },"");
				CompileIUCmd(false, insertCmd,BandoTipoInvestimentiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				BandoTipoInvestimentiObj.IdTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_INVESTIMENTO"]);
				BandoTipoInvestimentiObj.Premio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREMIO"]);
				}
				BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoInvestimentiObj.IsDirty = false;
				BandoTipoInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoInvestimentiUpdate", new string[] {"IdTipoInvestimento", "IdBando", "CodTipoInvestimento", 
"ImportoMax", "ImportoMin", "QuotaMax", 
"Note", "Premio", }, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", },"");
				CompileIUCmd(true, updateCmd,BandoTipoInvestimentiObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoInvestimentiObj.IsDirty = false;
				BandoTipoInvestimentiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			switch (BandoTipoInvestimentiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, BandoTipoInvestimentiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, BandoTipoInvestimentiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,BandoTipoInvestimentiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZBandoTipoInvestimentiUpdate", new string[] {"IdTipoInvestimento", "IdBando", "CodTipoInvestimento", 
"ImportoMax", "ImportoMin", "QuotaMax", 
"Note", "Premio", }, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", },"");
				IDbCommand insertCmd = db.InitCmd( "ZBandoTipoInvestimentiInsert", new string[] {"IdBando", "CodTipoInvestimento", 
"ImportoMax", "ImportoMin", "QuotaMax", 
"Note", "Premio", }, new string[] {"int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoInvestimentiDelete", new string[] {"IdTipoInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < BandoTipoInvestimentiCollectionObj.Count; i++)
				{
					switch (BandoTipoInvestimentiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,BandoTipoInvestimentiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									BandoTipoInvestimentiCollectionObj[i].IdTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_INVESTIMENTO"]);
									BandoTipoInvestimentiCollectionObj[i].Premio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREMIO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,BandoTipoInvestimentiCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (BandoTipoInvestimentiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoInvestimento", (SiarLibrary.NullTypes.IntNT)BandoTipoInvestimentiCollectionObj[i].IdTipoInvestimento);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < BandoTipoInvestimentiCollectionObj.Count; i++)
				{
					if ((BandoTipoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						BandoTipoInvestimentiCollectionObj[i].IsDirty = false;
						BandoTipoInvestimentiCollectionObj[i].IsPersistent = true;
					}
					if ((BandoTipoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						BandoTipoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoInvestimentiCollectionObj[i].IsDirty = false;
						BandoTipoInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, BandoTipoInvestimenti BandoTipoInvestimentiObj)
		{
			int returnValue = 0;
			if (BandoTipoInvestimentiObj.IsPersistent) 
			{
				returnValue = Delete(db, BandoTipoInvestimentiObj.IdTipoInvestimento);
			}
			BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			BandoTipoInvestimentiObj.IsDirty = false;
			BandoTipoInvestimentiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdTipoInvestimentoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoInvestimentiDelete", new string[] {"IdTipoInvestimento"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoInvestimento", (SiarLibrary.NullTypes.IntNT)IdTipoInvestimentoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZBandoTipoInvestimentiDelete", new string[] {"IdTipoInvestimento"}, new string[] {"int"},"");
				for (int i = 0; i < BandoTipoInvestimentiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdTipoInvestimento", BandoTipoInvestimentiCollectionObj[i].IdTipoInvestimento);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < BandoTipoInvestimentiCollectionObj.Count; i++)
				{
					if ((BandoTipoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoTipoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						BandoTipoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						BandoTipoInvestimentiCollectionObj[i].IsDirty = false;
						BandoTipoInvestimentiCollectionObj[i].IsPersistent = false;
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
		public static BandoTipoInvestimenti GetById(DbProvider db, int IdTipoInvestimentoValue)
		{
			BandoTipoInvestimenti BandoTipoInvestimentiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZBandoTipoInvestimentiGetById", new string[] {"IdTipoInvestimento"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdTipoInvestimento", (SiarLibrary.NullTypes.IntNT)IdTipoInvestimentoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				BandoTipoInvestimentiObj = GetFromDatareader(db);
				BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoInvestimentiObj.IsDirty = false;
				BandoTipoInvestimentiObj.IsPersistent = true;
			}
			db.Close();
			return BandoTipoInvestimentiObj;
		}

		//getFromDatareader
		public static BandoTipoInvestimenti GetFromDatareader(DbProvider db)
		{
			BandoTipoInvestimenti BandoTipoInvestimentiObj = new BandoTipoInvestimenti();
			BandoTipoInvestimentiObj.IdTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_INVESTIMENTO"]);
			BandoTipoInvestimentiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			BandoTipoInvestimentiObj.CodTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
			BandoTipoInvestimentiObj.ImportoMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_MAX"]);
			BandoTipoInvestimentiObj.ImportoMin = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_MIN"]);
			BandoTipoInvestimentiObj.QuotaMax = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_MAX"]);
			BandoTipoInvestimentiObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
			BandoTipoInvestimentiObj.Premio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREMIO"]);
			BandoTipoInvestimentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			BandoTipoInvestimentiObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			BandoTipoInvestimentiObj.Text = new SiarLibrary.NullTypes.StringNT(db.DataReader["TEXT"]);
			BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			BandoTipoInvestimentiObj.IsDirty = false;
			BandoTipoInvestimentiObj.IsPersistent = true;
			return BandoTipoInvestimentiObj;
		}

		//Find Select

		public static BandoTipoInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdTipoInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT CodTipoInvestimentoEqualThis, 
SiarLibrary.NullTypes.DecimalNT ImportoMaxEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoMinEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaMaxEqualThis, 
SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.BoolNT PremioEqualThis)

		{

			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionObj = new BandoTipoInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipoinvestimentifindselect", new string[] {"IdTipoInvestimentoequalthis", "IdBandoequalthis", "CodTipoInvestimentoequalthis", 
"ImportoMaxequalthis", "ImportoMinequalthis", "QuotaMaxequalthis", 
"Noteequalthis", "Premioequalthis"}, new string[] {"int", "int", "int", 
"decimal", "decimal", "decimal", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoInvestimentoequalthis", IdTipoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoInvestimentoequalthis", CodTipoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoMaxequalthis", ImportoMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoMinequalthis", ImportoMinEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuotaMaxequalthis", QuotaMaxEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Premioequalthis", PremioEqualThis);
			BandoTipoInvestimenti BandoTipoInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoInvestimentiObj = GetFromDatareader(db);
				BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoInvestimentiObj.IsDirty = false;
				BandoTipoInvestimentiObj.IsPersistent = true;
				BandoTipoInvestimentiCollectionObj.Add(BandoTipoInvestimentiObj);
			}
			db.Close();
			return BandoTipoInvestimentiCollectionObj;
		}

		//Find Find

		public static BandoTipoInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT CodTipoInvestimentoEqualThis, SiarLibrary.NullTypes.BoolNT PremioEqualThis)

		{

			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionObj = new BandoTipoInvestimentiCollection();

			IDbCommand findCmd = db.InitCmd("Zbandotipoinvestimentifindfind", new string[] {"IdBandoequalthis", "CodTipoInvestimentoequalthis", "Premioequalthis"}, new string[] {"int", "int", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoInvestimentoequalthis", CodTipoInvestimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Premioequalthis", PremioEqualThis);
			BandoTipoInvestimenti BandoTipoInvestimentiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				BandoTipoInvestimentiObj = GetFromDatareader(db);
				BandoTipoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				BandoTipoInvestimentiObj.IsDirty = false;
				BandoTipoInvestimentiObj.IsPersistent = true;
				BandoTipoInvestimentiCollectionObj.Add(BandoTipoInvestimentiObj);
			}
			db.Close();
			return BandoTipoInvestimentiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoTipoInvestimentiCollectionProvider:IBandoTipoInvestimentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class BandoTipoInvestimentiCollectionProvider : IBandoTipoInvestimentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoTipoInvestimenti
		protected BandoTipoInvestimentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoTipoInvestimentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoTipoInvestimentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoTipoInvestimentiCollectionProvider(IntNT IdbandoEqualThis, IntNT CodtipoinvestimentoEqualThis, BoolNT PremioEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoinvestimentoEqualThis, PremioEqualThis);
		}

		//Costruttore3: ha in input bandotipoinvestimentiCollectionObj - non popola la collection
		public BandoTipoInvestimentiCollectionProvider(BandoTipoInvestimentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoTipoInvestimentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoTipoInvestimentiCollection(this);
		}

		//Get e Set
		public BandoTipoInvestimentiCollection CollectionObj
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
		public int SaveCollection(BandoTipoInvestimentiCollection collectionObj)
		{
			return BandoTipoInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoTipoInvestimenti bandotipoinvestimentiObj)
		{
			return BandoTipoInvestimentiDAL.Save(_dbProviderObj, bandotipoinvestimentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoTipoInvestimentiCollection collectionObj)
		{
			return BandoTipoInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoTipoInvestimenti bandotipoinvestimentiObj)
		{
			return BandoTipoInvestimentiDAL.Delete(_dbProviderObj, bandotipoinvestimentiObj);
		}

		//getById
		public BandoTipoInvestimenti GetById(IntNT IdTipoInvestimentoValue)
		{
			BandoTipoInvestimenti BandoTipoInvestimentiTemp = BandoTipoInvestimentiDAL.GetById(_dbProviderObj, IdTipoInvestimentoValue);
			if (BandoTipoInvestimentiTemp!=null) BandoTipoInvestimentiTemp.Provider = this;
			return BandoTipoInvestimentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoTipoInvestimentiCollection Select(IntNT IdtipoinvestimentoEqualThis, IntNT IdbandoEqualThis, IntNT CodtipoinvestimentoEqualThis, 
DecimalNT ImportomaxEqualThis, DecimalNT ImportominEqualThis, DecimalNT QuotamaxEqualThis, 
StringNT NoteEqualThis, BoolNT PremioEqualThis)
		{
			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionTemp = BandoTipoInvestimentiDAL.Select(_dbProviderObj, IdtipoinvestimentoEqualThis, IdbandoEqualThis, CodtipoinvestimentoEqualThis, 
ImportomaxEqualThis, ImportominEqualThis, QuotamaxEqualThis, 
NoteEqualThis, PremioEqualThis);
			BandoTipoInvestimentiCollectionTemp.Provider = this;
			return BandoTipoInvestimentiCollectionTemp;
		}

		//Find: popola la collection
		public BandoTipoInvestimentiCollection Find(IntNT IdbandoEqualThis, IntNT CodtipoinvestimentoEqualThis, BoolNT PremioEqualThis)
		{
			BandoTipoInvestimentiCollection BandoTipoInvestimentiCollectionTemp = BandoTipoInvestimentiDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoinvestimentoEqualThis, PremioEqualThis);
			BandoTipoInvestimentiCollectionTemp.Provider = this;
			return BandoTipoInvestimentiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_INVESTIMENTI>
  <ViewName>vBANDO_TIPO_INVESTIMENTI</ViewName>
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
    <Find OrderBy="ORDER BY ID_TIPO_INVESTIMENTO">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO_INVESTIMENTO>Equal</COD_TIPO_INVESTIMENTO>
      <PREMIO>Equal</PREMIO>
    </Find>
  </Finds>
  <Filters>
    <FiltroCodiceTipo>
      <COD_TIPO_INVESTIMENTO>Equal</COD_TIPO_INVESTIMENTO>
    </FiltroCodiceTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_INVESTIMENTI>
*/
