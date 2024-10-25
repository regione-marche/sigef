using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ErroreAllegati
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IErroreAllegatiProvider
	{
		int Save(ErroreAllegati ErroreAllegatiObj);
		int SaveCollection(ErroreAllegatiCollection collectionObj);
		int Delete(ErroreAllegati ErroreAllegatiObj);
		int DeleteCollection(ErroreAllegatiCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ErroreAllegati
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ErroreAllegati: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdErroreAllegati;
		private NullTypes.IntNT _IdErrore;
		private NullTypes.BoolNT _Protocollato;
		private NullTypes.StringNT _SegnaturaAllegato;
		private NullTypes.IntNT _IdAllegato;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _TipoFile;
		private NullTypes.StringNT _NomeFile;
		private NullTypes.StringNT _NomeCompletoFile;
		private byte[] _ContenutoFile;
		private NullTypes.IntNT _DimensioneFile;
		private NullTypes.StringNT _HashCodeFile;
		[NonSerialized] private IErroreAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErroreAllegatiProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ErroreAllegati()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_ERRORE_ALLEGATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErroreAllegati
		{
			get { return _IdErroreAllegati; }
			set {
				if (IdErroreAllegati != value)
				{
					_IdErroreAllegati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ERRORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdErrore
		{
			get { return _IdErrore; }
			set {
				if (IdErrore != value)
				{
					_IdErrore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROTOCOLLATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Protocollato
		{
			get { return _Protocollato; }
			set {
				if (Protocollato != value)
				{
					_Protocollato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_ALLEGATO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaAllegato
		{
			get { return _SegnaturaAllegato; }
			set {
				if (SegnaturaAllegato != value)
				{
					_SegnaturaAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ALLEGATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAllegato
		{
			get { return _IdAllegato; }
			set {
				if (IdAllegato != value)
				{
					_IdAllegato = value;
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
		/// Corrisponde al campo:TIPO_FILE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT TipoFile
		{
			get { return _TipoFile; }
			set {
				if (TipoFile != value)
				{
					_TipoFile = value;
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
		/// Corrisponde al campo:NOME_COMPLETO_FILE
		/// Tipo sul db:VARCHAR(510)
		/// </summary>
		public NullTypes.StringNT NomeCompletoFile
		{
			get { return _NomeCompletoFile; }
			set {
				if (NomeCompletoFile != value)
				{
					_NomeCompletoFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTENUTO_FILE
		/// Tipo sul db:VARBINARY
		/// </summary>
		public byte[] ContenutoFile
		{
			get { return _ContenutoFile; }
			set {
				if (ContenutoFile != value)
				{
					_ContenutoFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_FILE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT DimensioneFile
		{
			get { return _DimensioneFile; }
			set {
				if (DimensioneFile != value)
				{
					_DimensioneFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:HASH_CODE_FILE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT HashCodeFile
		{
			get { return _HashCodeFile; }
			set {
				if (HashCodeFile != value)
				{
					_HashCodeFile = value;
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
	/// Summary description for ErroreAllegatiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErroreAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ErroreAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ErroreAllegati) info.GetValue(i.ToString(),typeof(ErroreAllegati)));
			}
		}

		//Costruttore
		public ErroreAllegatiCollection()
		{
			this.ItemType = typeof(ErroreAllegati);
		}

		//Costruttore con provider
		public ErroreAllegatiCollection(IErroreAllegatiProvider providerObj)
		{
			this.ItemType = typeof(ErroreAllegati);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ErroreAllegati this[int index]
		{
			get { return (ErroreAllegati)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ErroreAllegatiCollection GetChanges()
		{
			return (ErroreAllegatiCollection) base.GetChanges();
		}

		[NonSerialized] private IErroreAllegatiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IErroreAllegatiProvider Provider
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
		public int Add(ErroreAllegati ErroreAllegatiObj)
		{
			if (ErroreAllegatiObj.Provider == null) ErroreAllegatiObj.Provider = this.Provider;
			return base.Add(ErroreAllegatiObj);
		}

		//AddCollection
		public void AddCollection(ErroreAllegatiCollection ErroreAllegatiCollectionObj)
		{
			foreach (ErroreAllegati ErroreAllegatiObj in ErroreAllegatiCollectionObj)
				this.Add(ErroreAllegatiObj);
		}

		//Insert
		public void Insert(int index, ErroreAllegati ErroreAllegatiObj)
		{
			if (ErroreAllegatiObj.Provider == null) ErroreAllegatiObj.Provider = this.Provider;
			base.Insert(index, ErroreAllegatiObj);
		}

		//CollectionGetById
		public ErroreAllegati CollectionGetById(NullTypes.IntNT IdErroreAllegatiValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdErroreAllegati == IdErroreAllegatiValue))
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
		public ErroreAllegatiCollection SubSelect(NullTypes.IntNT IdErroreAllegatiEqualThis, NullTypes.IntNT IdErroreEqualThis, NullTypes.BoolNT ProtocollatoEqualThis, 
NullTypes.StringNT SegnaturaAllegatoEqualThis, NullTypes.IntNT IdAllegatoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis)
		{
			ErroreAllegatiCollection ErroreAllegatiCollectionTemp = new ErroreAllegatiCollection();
			foreach (ErroreAllegati ErroreAllegatiItem in this)
			{
				if (((IdErroreAllegatiEqualThis == null) || ((ErroreAllegatiItem.IdErroreAllegati != null) && (ErroreAllegatiItem.IdErroreAllegati.Value == IdErroreAllegatiEqualThis.Value))) && ((IdErroreEqualThis == null) || ((ErroreAllegatiItem.IdErrore != null) && (ErroreAllegatiItem.IdErrore.Value == IdErroreEqualThis.Value))) && ((ProtocollatoEqualThis == null) || ((ErroreAllegatiItem.Protocollato != null) && (ErroreAllegatiItem.Protocollato.Value == ProtocollatoEqualThis.Value))) && 
((SegnaturaAllegatoEqualThis == null) || ((ErroreAllegatiItem.SegnaturaAllegato != null) && (ErroreAllegatiItem.SegnaturaAllegato.Value == SegnaturaAllegatoEqualThis.Value))) && ((IdAllegatoEqualThis == null) || ((ErroreAllegatiItem.IdAllegato != null) && (ErroreAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((ErroreAllegatiItem.CfInserimento != null) && (ErroreAllegatiItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((ErroreAllegatiItem.DataInserimento != null) && (ErroreAllegatiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfModificaEqualThis == null) || ((ErroreAllegatiItem.CfModifica != null) && (ErroreAllegatiItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ErroreAllegatiItem.DataModifica != null) && (ErroreAllegatiItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					ErroreAllegatiCollectionTemp.Add(ErroreAllegatiItem);
				}
			}
			return ErroreAllegatiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ErroreAllegatiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ErroreAllegatiDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ErroreAllegati ErroreAllegatiObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdErroreAllegati", ErroreAllegatiObj.IdErroreAllegati);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdErrore", ErroreAllegatiObj.IdErrore);
			DbProvider.SetCmdParam(cmd,firstChar + "Protocollato", ErroreAllegatiObj.Protocollato);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaAllegato", ErroreAllegatiObj.SegnaturaAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAllegato", ErroreAllegatiObj.IdAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "CfInserimento", ErroreAllegatiObj.CfInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ErroreAllegatiObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "CfModifica", ErroreAllegatiObj.CfModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ErroreAllegatiObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, ErroreAllegati ErroreAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZErroreAllegatiInsert", new string[] {"IdErrore", "Protocollato", 
"SegnaturaAllegato", "IdAllegato", "CfInserimento", 
"DataInserimento", "CfModifica", "DataModifica", 
}, new string[] {"int", "bool", 
"string", "int", "string", 
"DateTime", "string", "DateTime", 
},"");
				CompileIUCmd(false, insertCmd,ErroreAllegatiObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ErroreAllegatiObj.IdErroreAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE_ALLEGATI"]);
				ErroreAllegatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErroreAllegatiObj.IsDirty = false;
				ErroreAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ErroreAllegati ErroreAllegatiObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErroreAllegatiUpdate", new string[] {"IdErroreAllegati", "IdErrore", "Protocollato", 
"SegnaturaAllegato", "IdAllegato", "CfInserimento", 
"DataInserimento", "CfModifica", "DataModifica", 
}, new string[] {"int", "int", "bool", 
"string", "int", "string", 
"DateTime", "string", "DateTime", 
},"");
				CompileIUCmd(true, updateCmd,ErroreAllegatiObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ErroreAllegatiObj.DataModifica = d;
				}
				ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErroreAllegatiObj.IsDirty = false;
				ErroreAllegatiObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ErroreAllegati ErroreAllegatiObj)
		{
			switch (ErroreAllegatiObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ErroreAllegatiObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ErroreAllegatiObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ErroreAllegatiObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ErroreAllegatiCollection ErroreAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZErroreAllegatiUpdate", new string[] {"IdErroreAllegati", "IdErrore", "Protocollato", 
"SegnaturaAllegato", "IdAllegato", "CfInserimento", 
"DataInserimento", "CfModifica", "DataModifica", 
}, new string[] {"int", "int", "bool", 
"string", "int", "string", 
"DateTime", "string", "DateTime", 
},"");
				IDbCommand insertCmd = db.InitCmd( "ZErroreAllegatiInsert", new string[] {"IdErrore", "Protocollato", 
"SegnaturaAllegato", "IdAllegato", "CfInserimento", 
"DataInserimento", "CfModifica", "DataModifica", 
}, new string[] {"int", "bool", 
"string", "int", "string", 
"DateTime", "string", "DateTime", 
},"");
				IDbCommand deleteCmd = db.InitCmd( "ZErroreAllegatiDelete", new string[] {"IdErroreAllegati"}, new string[] {"int"},"");
				for (int i = 0; i < ErroreAllegatiCollectionObj.Count; i++)
				{
					switch (ErroreAllegatiCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ErroreAllegatiCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ErroreAllegatiCollectionObj[i].IdErroreAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE_ALLEGATI"]);
									ErroreAllegatiCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ErroreAllegatiCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ErroreAllegatiCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ErroreAllegatiCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErroreAllegati", (SiarLibrary.NullTypes.IntNT)ErroreAllegatiCollectionObj[i].IdErroreAllegati);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ErroreAllegatiCollectionObj.Count; i++)
				{
					if ((ErroreAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroreAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErroreAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ErroreAllegatiCollectionObj[i].IsDirty = false;
						ErroreAllegatiCollectionObj[i].IsPersistent = true;
					}
					if ((ErroreAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ErroreAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErroreAllegatiCollectionObj[i].IsDirty = false;
						ErroreAllegatiCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ErroreAllegati ErroreAllegatiObj)
		{
			int returnValue = 0;
			if (ErroreAllegatiObj.IsPersistent) 
			{
				returnValue = Delete(db, ErroreAllegatiObj.IdErroreAllegati);
			}
			ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ErroreAllegatiObj.IsDirty = false;
			ErroreAllegatiObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdErroreAllegatiValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErroreAllegatiDelete", new string[] {"IdErroreAllegati"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErroreAllegati", (SiarLibrary.NullTypes.IntNT)IdErroreAllegatiValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ErroreAllegatiCollection ErroreAllegatiCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZErroreAllegatiDelete", new string[] {"IdErroreAllegati"}, new string[] {"int"},"");
				for (int i = 0; i < ErroreAllegatiCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdErroreAllegati", ErroreAllegatiCollectionObj[i].IdErroreAllegati);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ErroreAllegatiCollectionObj.Count; i++)
				{
					if ((ErroreAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroreAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ErroreAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ErroreAllegatiCollectionObj[i].IsDirty = false;
						ErroreAllegatiCollectionObj[i].IsPersistent = false;
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
		public static ErroreAllegati GetById(DbProvider db, int IdErroreAllegatiValue)
		{
			ErroreAllegati ErroreAllegatiObj = null;
			IDbCommand readCmd = db.InitCmd( "ZErroreAllegatiGetById", new string[] {"IdErroreAllegati"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdErroreAllegati", (SiarLibrary.NullTypes.IntNT)IdErroreAllegatiValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ErroreAllegatiObj = GetFromDatareader(db);
				ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErroreAllegatiObj.IsDirty = false;
				ErroreAllegatiObj.IsPersistent = true;
			}
			db.Close();
			return ErroreAllegatiObj;
		}

		//getFromDatareader
		public static ErroreAllegati GetFromDatareader(DbProvider db)
		{
			ErroreAllegati ErroreAllegatiObj = new ErroreAllegati();
			ErroreAllegatiObj.IdErroreAllegati = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE_ALLEGATI"]);
			ErroreAllegatiObj.IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
			ErroreAllegatiObj.Protocollato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROTOCOLLATO"]);
			ErroreAllegatiObj.SegnaturaAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATO"]);
			ErroreAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
			ErroreAllegatiObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			ErroreAllegatiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ErroreAllegatiObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			ErroreAllegatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ErroreAllegatiObj.TipoFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_FILE"]);
			ErroreAllegatiObj.NomeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_FILE"]);
			ErroreAllegatiObj.NomeCompletoFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_COMPLETO_FILE"]);
			ErroreAllegatiObj.ContenutoFile =  Convert.IsDBNull(db.DataReader["CONTENUTO_FILE"]) ? null : (byte[])db.DataReader["CONTENUTO_FILE"];
			ErroreAllegatiObj.DimensioneFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_FILE"]);
			ErroreAllegatiObj.HashCodeFile = new SiarLibrary.NullTypes.StringNT(db.DataReader["HASH_CODE_FILE"]);
			ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ErroreAllegatiObj.IsDirty = false;
			ErroreAllegatiObj.IsPersistent = true;
			return ErroreAllegatiObj;
		}

		//Find Select

		public static ErroreAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdErroreAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.BoolNT ProtocollatoEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			ErroreAllegatiCollection ErroreAllegatiCollectionObj = new ErroreAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zerroreallegatifindselect", new string[] {"IdErroreAllegatiequalthis", "IdErroreequalthis", "Protocollatoequalthis", 
"SegnaturaAllegatoequalthis", "IdAllegatoequalthis", "CfInserimentoequalthis", 
"DataInserimentoequalthis", "CfModificaequalthis", "DataModificaequalthis"}, new string[] {"int", "int", "bool", 
"string", "int", "string", 
"DateTime", "string", "DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreAllegatiequalthis", IdErroreAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocollatoequalthis", ProtocollatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaAllegatoequalthis", SegnaturaAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			ErroreAllegati ErroreAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErroreAllegatiObj = GetFromDatareader(db);
				ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErroreAllegatiObj.IsDirty = false;
				ErroreAllegatiObj.IsPersistent = true;
				ErroreAllegatiCollectionObj.Add(ErroreAllegatiObj);
			}
			db.Close();
			return ErroreAllegatiCollectionObj;
		}

		//Find Find

		public static ErroreAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdErroreAllegatiEqualThis, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.BoolNT ProtocollatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis)

		{

			ErroreAllegatiCollection ErroreAllegatiCollectionObj = new ErroreAllegatiCollection();

			IDbCommand findCmd = db.InitCmd("Zerroreallegatifindfind", new string[] {"IdErroreAllegatiequalthis", "IdErroreequalthis", "Protocollatoequalthis", 
"IdAllegatoequalthis"}, new string[] {"int", "int", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreAllegatiequalthis", IdErroreAllegatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Protocollatoequalthis", ProtocollatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
			ErroreAllegati ErroreAllegatiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ErroreAllegatiObj = GetFromDatareader(db);
				ErroreAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ErroreAllegatiObj.IsDirty = false;
				ErroreAllegatiObj.IsPersistent = true;
				ErroreAllegatiCollectionObj.Add(ErroreAllegatiObj);
			}
			db.Close();
			return ErroreAllegatiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ErroreAllegatiCollectionProvider:IErroreAllegatiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ErroreAllegatiCollectionProvider : IErroreAllegatiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ErroreAllegati
		protected ErroreAllegatiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ErroreAllegatiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ErroreAllegatiCollection(this);
		}

		//Costruttore 2: popola la collection
		public ErroreAllegatiCollectionProvider(IntNT IderroreallegatiEqualThis, IntNT IderroreEqualThis, BoolNT ProtocollatoEqualThis, 
IntNT IdallegatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IderroreallegatiEqualThis, IderroreEqualThis, ProtocollatoEqualThis, 
IdallegatoEqualThis);
		}

		//Costruttore3: ha in input erroreallegatiCollectionObj - non popola la collection
		public ErroreAllegatiCollectionProvider(ErroreAllegatiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ErroreAllegatiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ErroreAllegatiCollection(this);
		}

		//Get e Set
		public ErroreAllegatiCollection CollectionObj
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
		public int SaveCollection(ErroreAllegatiCollection collectionObj)
		{
			return ErroreAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ErroreAllegati erroreallegatiObj)
		{
			return ErroreAllegatiDAL.Save(_dbProviderObj, erroreallegatiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ErroreAllegatiCollection collectionObj)
		{
			return ErroreAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ErroreAllegati erroreallegatiObj)
		{
			return ErroreAllegatiDAL.Delete(_dbProviderObj, erroreallegatiObj);
		}

		//getById
		public ErroreAllegati GetById(IntNT IdErroreAllegatiValue)
		{
			ErroreAllegati ErroreAllegatiTemp = ErroreAllegatiDAL.GetById(_dbProviderObj, IdErroreAllegatiValue);
			if (ErroreAllegatiTemp!=null) ErroreAllegatiTemp.Provider = this;
			return ErroreAllegatiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ErroreAllegatiCollection Select(IntNT IderroreallegatiEqualThis, IntNT IderroreEqualThis, BoolNT ProtocollatoEqualThis, 
StringNT SegnaturaallegatoEqualThis, IntNT IdallegatoEqualThis, StringNT CfinserimentoEqualThis, 
DatetimeNT DatainserimentoEqualThis, StringNT CfmodificaEqualThis, DatetimeNT DatamodificaEqualThis)
		{
			ErroreAllegatiCollection ErroreAllegatiCollectionTemp = ErroreAllegatiDAL.Select(_dbProviderObj, IderroreallegatiEqualThis, IderroreEqualThis, ProtocollatoEqualThis, 
SegnaturaallegatoEqualThis, IdallegatoEqualThis, CfinserimentoEqualThis, 
DatainserimentoEqualThis, CfmodificaEqualThis, DatamodificaEqualThis);
			ErroreAllegatiCollectionTemp.Provider = this;
			return ErroreAllegatiCollectionTemp;
		}

		//Find: popola la collection
		public ErroreAllegatiCollection Find(IntNT IderroreallegatiEqualThis, IntNT IderroreEqualThis, BoolNT ProtocollatoEqualThis, 
IntNT IdallegatoEqualThis)
		{
			ErroreAllegatiCollection ErroreAllegatiCollectionTemp = ErroreAllegatiDAL.Find(_dbProviderObj, IderroreallegatiEqualThis, IderroreEqualThis, ProtocollatoEqualThis, 
IdallegatoEqualThis);
			ErroreAllegatiCollectionTemp.Provider = this;
			return ErroreAllegatiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ERRORE_ALLEGATI>
  <ViewName>VERRORE_ALLEGATI</ViewName>
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
      <ID_ERRORE_ALLEGATI>Equal</ID_ERRORE_ALLEGATI>
      <ID_ERRORE>Equal</ID_ERRORE>
      <PROTOCOLLATO>Equal</PROTOCOLLATO>
      <ID_ALLEGATO>Equal</ID_ALLEGATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ERRORE_ALLEGATI>
*/
