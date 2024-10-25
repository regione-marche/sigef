using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per Disposizione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IDisposizioneProvider
	{
		int Save(Disposizione DisposizioneObj);
		int SaveCollection(DisposizioneCollection collectionObj);
		int Delete(Disposizione DisposizioneObj);
		int DeleteCollection(DisposizioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for Disposizione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class Disposizione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdDisposizione;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.IntNT _IdTipoDisposizione;
		private NullTypes.StringNT _Numero;
		private NullTypes.IntNT _Anno;
		private NullTypes.StringNT _ArticoloParagrafo;
		private NullTypes.StringNT _DisposizioneNazionale;
		private NullTypes.IntNT _IdRegistroIrregolarita;
		private NullTypes.IntNT _IdIrregolarita;
		[NonSerialized] private IDisposizioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDisposizioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public Disposizione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_DISPOSIZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDisposizione
		{
			get { return _IdDisposizione; }
			set {
				if (IdDisposizione != value)
				{
					_IdDisposizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set {
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
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
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set {
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_DISPOSIZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoDisposizione
		{
			get { return _IdTipoDisposizione; }
			set {
				if (IdTipoDisposizione != value)
				{
					_IdTipoDisposizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Numero
		{
			get { return _Numero; }
			set {
				if (Numero != value)
				{
					_Numero = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ARTICOLO_PARAGRAFO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT ArticoloParagrafo
		{
			get { return _ArticoloParagrafo; }
			set {
				if (ArticoloParagrafo != value)
				{
					_ArticoloParagrafo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DISPOSIZIONE_NAZIONALE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DisposizioneNazionale
		{
			get { return _DisposizioneNazionale; }
			set {
				if (DisposizioneNazionale != value)
				{
					_DisposizioneNazionale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_REGISTRO_IRREGOLARITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRegistroIrregolarita
		{
			get { return _IdRegistroIrregolarita; }
			set {
				if (IdRegistroIrregolarita != value)
				{
					_IdRegistroIrregolarita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IRREGOLARITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIrregolarita
		{
			get { return _IdIrregolarita; }
			set {
				if (IdIrregolarita != value)
				{
					_IdIrregolarita = value;
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
	/// Summary description for DisposizioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DisposizioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DisposizioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Disposizione) info.GetValue(i.ToString(),typeof(Disposizione)));
			}
		}

		//Costruttore
		public DisposizioneCollection()
		{
			this.ItemType = typeof(Disposizione);
		}

		//Costruttore con provider
		public DisposizioneCollection(IDisposizioneProvider providerObj)
		{
			this.ItemType = typeof(Disposizione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Disposizione this[int index]
		{
			get { return (Disposizione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DisposizioneCollection GetChanges()
		{
			return (DisposizioneCollection) base.GetChanges();
		}

		[NonSerialized] private IDisposizioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDisposizioneProvider Provider
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
		public int Add(Disposizione DisposizioneObj)
		{
			if (DisposizioneObj.Provider == null) DisposizioneObj.Provider = this.Provider;
			return base.Add(DisposizioneObj);
		}

		//AddCollection
		public void AddCollection(DisposizioneCollection DisposizioneCollectionObj)
		{
			foreach (Disposizione DisposizioneObj in DisposizioneCollectionObj)
				this.Add(DisposizioneObj);
		}

		//Insert
		public void Insert(int index, Disposizione DisposizioneObj)
		{
			if (DisposizioneObj.Provider == null) DisposizioneObj.Provider = this.Provider;
			base.Insert(index, DisposizioneObj);
		}

		//CollectionGetById
		public Disposizione CollectionGetById(NullTypes.IntNT IdDisposizioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDisposizione == IdDisposizioneValue))
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
		public DisposizioneCollection SubSelect(NullTypes.IntNT IdDisposizioneEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.IntNT IdTipoDisposizioneEqualThis, 
NullTypes.StringNT NumeroEqualThis, NullTypes.IntNT AnnoEqualThis, NullTypes.StringNT ArticoloParagrafoEqualThis, 
NullTypes.StringNT DisposizioneNazionaleEqualThis, NullTypes.IntNT IdRegistroIrregolaritaEqualThis, NullTypes.IntNT IdIrregolaritaEqualThis)
		{
			DisposizioneCollection DisposizioneCollectionTemp = new DisposizioneCollection();
			foreach (Disposizione DisposizioneItem in this)
			{
				if (((IdDisposizioneEqualThis == null) || ((DisposizioneItem.IdDisposizione != null) && (DisposizioneItem.IdDisposizione.Value == IdDisposizioneEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((DisposizioneItem.DataInserimento != null) && (DisposizioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((DisposizioneItem.CfInserimento != null) && (DisposizioneItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((DisposizioneItem.DataModifica != null) && (DisposizioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((DisposizioneItem.CfModifica != null) && (DisposizioneItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((IdTipoDisposizioneEqualThis == null) || ((DisposizioneItem.IdTipoDisposizione != null) && (DisposizioneItem.IdTipoDisposizione.Value == IdTipoDisposizioneEqualThis.Value))) && 
((NumeroEqualThis == null) || ((DisposizioneItem.Numero != null) && (DisposizioneItem.Numero.Value == NumeroEqualThis.Value))) && ((AnnoEqualThis == null) || ((DisposizioneItem.Anno != null) && (DisposizioneItem.Anno.Value == AnnoEqualThis.Value))) && ((ArticoloParagrafoEqualThis == null) || ((DisposizioneItem.ArticoloParagrafo != null) && (DisposizioneItem.ArticoloParagrafo.Value == ArticoloParagrafoEqualThis.Value))) && 
((DisposizioneNazionaleEqualThis == null) || ((DisposizioneItem.DisposizioneNazionale != null) && (DisposizioneItem.DisposizioneNazionale.Value == DisposizioneNazionaleEqualThis.Value))) && ((IdRegistroIrregolaritaEqualThis == null) || ((DisposizioneItem.IdRegistroIrregolarita != null) && (DisposizioneItem.IdRegistroIrregolarita.Value == IdRegistroIrregolaritaEqualThis.Value))) && ((IdIrregolaritaEqualThis == null) || ((DisposizioneItem.IdIrregolarita != null) && (DisposizioneItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))))
				{
					DisposizioneCollectionTemp.Add(DisposizioneItem);
				}
			}
			return DisposizioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for DisposizioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class DisposizioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Disposizione DisposizioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdDisposizione", DisposizioneObj.IdDisposizione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", DisposizioneObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", DisposizioneObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", DisposizioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", DisposizioneObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoDisposizione", DisposizioneObj.IdTipoDisposizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Numero", DisposizioneObj.Numero);
			DbProvider.SetCmdParam(cmd,firstChar + "Anno", DisposizioneObj.Anno);
			DbProvider.SetCmdParam(cmd,firstChar + "ArticoloParagrafo", DisposizioneObj.ArticoloParagrafo);
			DbProvider.SetCmdParam(cmd,firstChar + "DisposizioneNazionale", DisposizioneObj.DisposizioneNazionale);
			DbProvider.SetCmdParam(cmd,firstChar + "IdRegistroIrregolarita", DisposizioneObj.IdRegistroIrregolarita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdIrregolarita", DisposizioneObj.IdIrregolarita);
		}
		//Insert
		private static int Insert(DbProvider db, Disposizione DisposizioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZDisposizioneInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdTipoDisposizione", 
"Numero", "Anno", "ArticoloParagrafo", 
"DisposizioneNazionale", "IdRegistroIrregolarita", "IdIrregolarita"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"string", "int", "string", 
"string", "int", "int"},"");
				CompileIUCmd(false, insertCmd,DisposizioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				DisposizioneObj.IdDisposizione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DISPOSIZIONE"]);
				DisposizioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				DisposizioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, Disposizione DisposizioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDisposizioneUpdate", new string[] {"IdDisposizione", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdTipoDisposizione", 
"Numero", "Anno", "ArticoloParagrafo", 
"DisposizioneNazionale", "IdRegistroIrregolarita", "IdIrregolarita"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"string", "int", "string", 
"string", "int", "int"},"");
				CompileIUCmd(true, updateCmd,DisposizioneObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					DisposizioneObj.DataModifica = d;
				}
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, Disposizione DisposizioneObj)
		{
			switch (DisposizioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, DisposizioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, DisposizioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,DisposizioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, DisposizioneCollection DisposizioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZDisposizioneUpdate", new string[] {"IdDisposizione", "DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdTipoDisposizione", 
"Numero", "Anno", "ArticoloParagrafo", 
"DisposizioneNazionale", "IdRegistroIrregolarita", "IdIrregolarita"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"string", "int", "string", 
"string", "int", "int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZDisposizioneInsert", new string[] {"DataInserimento", "CfInserimento", 
"DataModifica", "CfModifica", "IdTipoDisposizione", 
"Numero", "Anno", "ArticoloParagrafo", 
"DisposizioneNazionale", "IdRegistroIrregolarita", "IdIrregolarita"}, new string[] {"DateTime", "string", 
"DateTime", "string", "int", 
"string", "int", "string", 
"string", "int", "int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZDisposizioneDelete", new string[] {"IdDisposizione"}, new string[] {"int"},"");
				for (int i = 0; i < DisposizioneCollectionObj.Count; i++)
				{
					switch (DisposizioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,DisposizioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									DisposizioneCollectionObj[i].IdDisposizione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DISPOSIZIONE"]);
									DisposizioneCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									DisposizioneCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,DisposizioneCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									DisposizioneCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (DisposizioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDisposizione", (SiarLibrary.NullTypes.IntNT)DisposizioneCollectionObj[i].IdDisposizione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < DisposizioneCollectionObj.Count; i++)
				{
					if ((DisposizioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DisposizioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DisposizioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						DisposizioneCollectionObj[i].IsDirty = false;
						DisposizioneCollectionObj[i].IsPersistent = true;
					}
					if ((DisposizioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						DisposizioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DisposizioneCollectionObj[i].IsDirty = false;
						DisposizioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, Disposizione DisposizioneObj)
		{
			int returnValue = 0;
			if (DisposizioneObj.IsPersistent) 
			{
				returnValue = Delete(db, DisposizioneObj.IdDisposizione);
			}
			DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			DisposizioneObj.IsDirty = false;
			DisposizioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdDisposizioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDisposizioneDelete", new string[] {"IdDisposizione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDisposizione", (SiarLibrary.NullTypes.IntNT)IdDisposizioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, DisposizioneCollection DisposizioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZDisposizioneDelete", new string[] {"IdDisposizione"}, new string[] {"int"},"");
				for (int i = 0; i < DisposizioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdDisposizione", DisposizioneCollectionObj[i].IdDisposizione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < DisposizioneCollectionObj.Count; i++)
				{
					if ((DisposizioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DisposizioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						DisposizioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						DisposizioneCollectionObj[i].IsDirty = false;
						DisposizioneCollectionObj[i].IsPersistent = false;
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
		public static Disposizione GetById(DbProvider db, int IdDisposizioneValue)
		{
			Disposizione DisposizioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZDisposizioneGetById", new string[] {"IdDisposizione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdDisposizione", (SiarLibrary.NullTypes.IntNT)IdDisposizioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				DisposizioneObj = GetFromDatareader(db);
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
			}
			db.Close();
			return DisposizioneObj;
		}

		//getFromDatareader
		public static Disposizione GetFromDatareader(DbProvider db)
		{
			Disposizione DisposizioneObj = new Disposizione();
			DisposizioneObj.IdDisposizione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DISPOSIZIONE"]);
			DisposizioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			DisposizioneObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			DisposizioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			DisposizioneObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			DisposizioneObj.IdTipoDisposizione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_DISPOSIZIONE"]);
			DisposizioneObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
			DisposizioneObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			DisposizioneObj.ArticoloParagrafo = new SiarLibrary.NullTypes.StringNT(db.DataReader["ARTICOLO_PARAGRAFO"]);
			DisposizioneObj.DisposizioneNazionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["DISPOSIZIONE_NAZIONALE"]);
			DisposizioneObj.IdRegistroIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REGISTRO_IRREGOLARITA"]);
			DisposizioneObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
			DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			DisposizioneObj.IsDirty = false;
			DisposizioneObj.IsPersistent = true;
			return DisposizioneObj;
		}

		//Find Select

		public static DisposizioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDisposizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoDisposizioneEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.StringNT ArticoloParagrafoEqualThis, 
SiarLibrary.NullTypes.StringNT DisposizioneNazionaleEqualThis, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis)

		{

			DisposizioneCollection DisposizioneCollectionObj = new DisposizioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdisposizionefindselect", new string[] {"IdDisposizioneequalthis", "DataInserimentoequalthis", "CfInserimentoequalthis", 
"DataModificaequalthis", "CfModificaequalthis", "IdTipoDisposizioneequalthis", 
"Numeroequalthis", "Annoequalthis", "ArticoloParagrafoequalthis", 
"DisposizioneNazionaleequalthis", "IdRegistroIrregolaritaequalthis", "IdIrregolaritaequalthis"}, new string[] {"int", "DateTime", "string", 
"DateTime", "string", "int", 
"string", "int", "string", 
"string", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDisposizioneequalthis", IdDisposizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoDisposizioneequalthis", IdTipoDisposizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ArticoloParagrafoequalthis", ArticoloParagrafoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DisposizioneNazionaleequalthis", DisposizioneNazionaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			Disposizione DisposizioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DisposizioneObj = GetFromDatareader(db);
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
				DisposizioneCollectionObj.Add(DisposizioneObj);
			}
			db.Close();
			return DisposizioneCollectionObj;
		}

		//Find Find

		public static DisposizioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDisposizioneEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdTipoDisposizioneEqualThis, 
SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis, SiarLibrary.NullTypes.StringNT ArticoloParagrafoEqualThis)

		{

			DisposizioneCollection DisposizioneCollectionObj = new DisposizioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdisposizionefindfind", new string[] {"IdDisposizioneequalthis", "IdIrregolaritaequalthis", "IdTipoDisposizioneequalthis", 
"Numeroequalthis", "Annoequalthis", "ArticoloParagrafoequalthis"}, new string[] {"int", "int", "int", 
"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDisposizioneequalthis", IdDisposizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoDisposizioneequalthis", IdTipoDisposizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ArticoloParagrafoequalthis", ArticoloParagrafoEqualThis);
			Disposizione DisposizioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DisposizioneObj = GetFromDatareader(db);
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
				DisposizioneCollectionObj.Add(DisposizioneObj);
			}
			db.Close();
			return DisposizioneCollectionObj;
		}

		//Find GetDisposizioniIrregolaritaOld

		public static DisposizioneCollection GetDisposizioniIrregolaritaOld(DbProvider db, SiarLibrary.NullTypes.IntNT IdRegistroIrregolaritaEqualThis)

		{

			DisposizioneCollection DisposizioneCollectionObj = new DisposizioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdisposizionefindgetdisposizioniirregolaritaold", new string[] {"IdRegistroIrregolaritaequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRegistroIrregolaritaequalthis", IdRegistroIrregolaritaEqualThis);
			Disposizione DisposizioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DisposizioneObj = GetFromDatareader(db);
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
				DisposizioneCollectionObj.Add(DisposizioneObj);
			}
			db.Close();
			return DisposizioneCollectionObj;
		}

		//Find GetDisposizioniIrregolarita

		public static DisposizioneCollection GetDisposizioniIrregolarita(DbProvider db, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis)

		{

			DisposizioneCollection DisposizioneCollectionObj = new DisposizioneCollection();

			IDbCommand findCmd = db.InitCmd("Zdisposizionefindgetdisposizioniirregolarita", new string[] {"IdIrregolaritaequalthis"}, new string[] {"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
			Disposizione DisposizioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				DisposizioneObj = GetFromDatareader(db);
				DisposizioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				DisposizioneObj.IsDirty = false;
				DisposizioneObj.IsPersistent = true;
				DisposizioneCollectionObj.Add(DisposizioneObj);
			}
			db.Close();
			return DisposizioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for DisposizioneCollectionProvider:IDisposizioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class DisposizioneCollectionProvider : IDisposizioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Disposizione
		protected DisposizioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DisposizioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DisposizioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public DisposizioneCollectionProvider(IntNT IddisposizioneEqualThis, IntNT IdirregolaritaEqualThis, IntNT IdtipodisposizioneEqualThis, 
StringNT NumeroEqualThis, IntNT AnnoEqualThis, StringNT ArticoloparagrafoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddisposizioneEqualThis, IdirregolaritaEqualThis, IdtipodisposizioneEqualThis, 
NumeroEqualThis, AnnoEqualThis, ArticoloparagrafoEqualThis);
		}

		//Costruttore3: ha in input disposizioneCollectionObj - non popola la collection
		public DisposizioneCollectionProvider(DisposizioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DisposizioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DisposizioneCollection(this);
		}

		//Get e Set
		public DisposizioneCollection CollectionObj
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
		public int SaveCollection(DisposizioneCollection collectionObj)
		{
			return DisposizioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Disposizione disposizioneObj)
		{
			return DisposizioneDAL.Save(_dbProviderObj, disposizioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DisposizioneCollection collectionObj)
		{
			return DisposizioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Disposizione disposizioneObj)
		{
			return DisposizioneDAL.Delete(_dbProviderObj, disposizioneObj);
		}

		//getById
		public Disposizione GetById(IntNT IdDisposizioneValue)
		{
			Disposizione DisposizioneTemp = DisposizioneDAL.GetById(_dbProviderObj, IdDisposizioneValue);
			if (DisposizioneTemp!=null) DisposizioneTemp.Provider = this;
			return DisposizioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DisposizioneCollection Select(IntNT IddisposizioneEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis, IntNT IdtipodisposizioneEqualThis, 
StringNT NumeroEqualThis, IntNT AnnoEqualThis, StringNT ArticoloparagrafoEqualThis, 
StringNT DisposizionenazionaleEqualThis, IntNT IdregistroirregolaritaEqualThis, IntNT IdirregolaritaEqualThis)
		{
			DisposizioneCollection DisposizioneCollectionTemp = DisposizioneDAL.Select(_dbProviderObj, IddisposizioneEqualThis, DatainserimentoEqualThis, CfinserimentoEqualThis, 
DatamodificaEqualThis, CfmodificaEqualThis, IdtipodisposizioneEqualThis, 
NumeroEqualThis, AnnoEqualThis, ArticoloparagrafoEqualThis, 
DisposizionenazionaleEqualThis, IdregistroirregolaritaEqualThis, IdirregolaritaEqualThis);
			DisposizioneCollectionTemp.Provider = this;
			return DisposizioneCollectionTemp;
		}

		//Find: popola la collection
		public DisposizioneCollection Find(IntNT IddisposizioneEqualThis, IntNT IdirregolaritaEqualThis, IntNT IdtipodisposizioneEqualThis, 
StringNT NumeroEqualThis, IntNT AnnoEqualThis, StringNT ArticoloparagrafoEqualThis)
		{
			DisposizioneCollection DisposizioneCollectionTemp = DisposizioneDAL.Find(_dbProviderObj, IddisposizioneEqualThis, IdirregolaritaEqualThis, IdtipodisposizioneEqualThis, 
NumeroEqualThis, AnnoEqualThis, ArticoloparagrafoEqualThis);
			DisposizioneCollectionTemp.Provider = this;
			return DisposizioneCollectionTemp;
		}

		//GetDisposizioniIrregolaritaOld: popola la collection
		public DisposizioneCollection GetDisposizioniIrregolaritaOld(IntNT IdregistroirregolaritaEqualThis)
		{
			DisposizioneCollection DisposizioneCollectionTemp = DisposizioneDAL.GetDisposizioniIrregolaritaOld(_dbProviderObj, IdregistroirregolaritaEqualThis);
			DisposizioneCollectionTemp.Provider = this;
			return DisposizioneCollectionTemp;
		}

		//GetDisposizioniIrregolarita: popola la collection
		public DisposizioneCollection GetDisposizioniIrregolarita(IntNT IdirregolaritaEqualThis)
		{
			DisposizioneCollection DisposizioneCollectionTemp = DisposizioneDAL.GetDisposizioniIrregolarita(_dbProviderObj, IdirregolaritaEqualThis);
			DisposizioneCollectionTemp.Provider = this;
			return DisposizioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DISPOSIZIONE>
  <ViewName>VDISPOSIZIONE</ViewName>
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
      <ID_DISPOSIZIONE>Equal</ID_DISPOSIZIONE>
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
      <ID_TIPO_DISPOSIZIONE>Equal</ID_TIPO_DISPOSIZIONE>
      <NUMERO>Equal</NUMERO>
      <ANNO>Equal</ANNO>
      <ARTICOLO_PARAGRAFO>Equal</ARTICOLO_PARAGRAFO>
    </Find>
    <GetDisposizioniIrregolaritaOld OrderBy="ORDER BY ">
      <ID_REGISTRO_IRREGOLARITA>Equal</ID_REGISTRO_IRREGOLARITA>
    </GetDisposizioniIrregolaritaOld>
    <GetDisposizioniIrregolarita OrderBy="ORDER BY ">
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
    </GetDisposizioniIrregolarita>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DISPOSIZIONE>
*/
