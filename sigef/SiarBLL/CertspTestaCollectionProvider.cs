using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspTesta
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspTestaProvider
	{
		int Save(CertspTesta CertspTestaObj);
		int SaveCollection(CertspTestaCollection collectionObj);
		int Delete(CertspTesta CertspTestaObj);
		int DeleteCollection(CertspTestaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspTesta
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspTesta: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Idcertsp;
		private NullTypes.StringNT _Codpsr;
		private NullTypes.DatetimeNT _Datainizio;
		private NullTypes.DatetimeNT _Datafine;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _Note;
		private NullTypes.BoolNT _Definitivo;
		private NullTypes.StringNT _Tipo;
		private NullTypes.DatetimeNT _Datainserimento;
		private NullTypes.DatetimeNT _Datamodifica;
		private NullTypes.StringNT _Operatore;
		private NullTypes.DatetimeNT _Datasegnatura;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _SegnaturaCertificazione;
		[NonSerialized] private ICertspTestaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspTestaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspTesta()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:IdCertSp
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Idcertsp
		{
			get { return _Idcertsp; }
			set {
				if (Idcertsp != value)
				{
					_Idcertsp = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CodPsr
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Codpsr
		{
			get { return _Codpsr; }
			set {
				if (Codpsr != value)
				{
					_Codpsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataInizio
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datainizio
		{
			get { return _Datainizio; }
			set {
				if (Datainizio != value)
				{
					_Datainizio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataFine
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datafine
		{
			get { return _Datafine; }
			set {
				if (Datafine != value)
				{
					_Datafine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Id_File
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
		/// Corrisponde al campo:Note
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
		/// Corrisponde al campo:Definitivo
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitivo
		{
			get { return _Definitivo; }
			set {
				if (Definitivo != value)
				{
					_Definitivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Tipo
		/// Tipo sul db:CHAR(1)
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
		/// Corrisponde al campo:DataInserimento
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datainserimento
		{
			get { return _Datainserimento; }
			set {
				if (Datainserimento != value)
				{
					_Datainserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DataModifica
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datamodifica
		{
			get { return _Datamodifica; }
			set {
				if (Datamodifica != value)
				{
					_Datamodifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Operatore
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
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
		/// Corrisponde al campo:DataSegnatura
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Datasegnatura
		{
			get { return _Datasegnatura; }
			set {
				if (Datasegnatura != value)
				{
					_Datasegnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Segnatura
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:Segnatura_Certificazione
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT SegnaturaCertificazione
		{
			get { return _SegnaturaCertificazione; }
			set {
				if (SegnaturaCertificazione != value)
				{
					_SegnaturaCertificazione = value;
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
	/// Summary description for CertspTestaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspTestaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspTestaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspTesta) info.GetValue(i.ToString(),typeof(CertspTesta)));
			}
		}

		//Costruttore
		public CertspTestaCollection()
		{
			this.ItemType = typeof(CertspTesta);
		}

		//Costruttore con provider
		public CertspTestaCollection(ICertspTestaProvider providerObj)
		{
			this.ItemType = typeof(CertspTesta);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspTesta this[int index]
		{
			get { return (CertspTesta)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspTestaCollection GetChanges()
		{
			return (CertspTestaCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspTestaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspTestaProvider Provider
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
		public int Add(CertspTesta CertspTestaObj)
		{
			if (CertspTestaObj.Provider == null) CertspTestaObj.Provider = this.Provider;
			return base.Add(CertspTestaObj);
		}

		//AddCollection
		public void AddCollection(CertspTestaCollection CertspTestaCollectionObj)
		{
			foreach (CertspTesta CertspTestaObj in CertspTestaCollectionObj)
				this.Add(CertspTestaObj);
		}

		//Insert
		public void Insert(int index, CertspTesta CertspTestaObj)
		{
			if (CertspTestaObj.Provider == null) CertspTestaObj.Provider = this.Provider;
			base.Insert(index, CertspTestaObj);
		}

		//CollectionGetById
		public CertspTesta CollectionGetById(NullTypes.IntNT IdcertspValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Idcertsp == IdcertspValue))
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
		public CertspTestaCollection SubSelect(NullTypes.IntNT IdcertspEqualThis, NullTypes.StringNT CodpsrEqualThis, NullTypes.DatetimeNT DatainizioEqualThis, 
NullTypes.DatetimeNT DatafineEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT NoteEqualThis, 
NullTypes.BoolNT DefinitivoEqualThis, NullTypes.StringNT TipoEqualThis, NullTypes.DatetimeNT DatainserimentoEqualThis, 
NullTypes.DatetimeNT DatamodificaEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DatasegnaturaEqualThis, 
NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT SegnaturaCertificazioneEqualThis)
		{
			CertspTestaCollection CertspTestaCollectionTemp = new CertspTestaCollection();
			foreach (CertspTesta CertspTestaItem in this)
			{
				if (((IdcertspEqualThis == null) || ((CertspTestaItem.Idcertsp != null) && (CertspTestaItem.Idcertsp.Value == IdcertspEqualThis.Value))) && ((CodpsrEqualThis == null) || ((CertspTestaItem.Codpsr != null) && (CertspTestaItem.Codpsr.Value == CodpsrEqualThis.Value))) && ((DatainizioEqualThis == null) || ((CertspTestaItem.Datainizio != null) && (CertspTestaItem.Datainizio.Value == DatainizioEqualThis.Value))) && 
((DatafineEqualThis == null) || ((CertspTestaItem.Datafine != null) && (CertspTestaItem.Datafine.Value == DatafineEqualThis.Value))) && ((IdFileEqualThis == null) || ((CertspTestaItem.IdFile != null) && (CertspTestaItem.IdFile.Value == IdFileEqualThis.Value))) && ((NoteEqualThis == null) || ((CertspTestaItem.Note != null) && (CertspTestaItem.Note.Value == NoteEqualThis.Value))) && 
((DefinitivoEqualThis == null) || ((CertspTestaItem.Definitivo != null) && (CertspTestaItem.Definitivo.Value == DefinitivoEqualThis.Value))) && ((TipoEqualThis == null) || ((CertspTestaItem.Tipo != null) && (CertspTestaItem.Tipo.Value == TipoEqualThis.Value))) && ((DatainserimentoEqualThis == null) || ((CertspTestaItem.Datainserimento != null) && (CertspTestaItem.Datainserimento.Value == DatainserimentoEqualThis.Value))) && 
((DatamodificaEqualThis == null) || ((CertspTestaItem.Datamodifica != null) && (CertspTestaItem.Datamodifica.Value == DatamodificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CertspTestaItem.Operatore != null) && (CertspTestaItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DatasegnaturaEqualThis == null) || ((CertspTestaItem.Datasegnatura != null) && (CertspTestaItem.Datasegnatura.Value == DatasegnaturaEqualThis.Value))) && 
((SegnaturaEqualThis == null) || ((CertspTestaItem.Segnatura != null) && (CertspTestaItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaCertificazioneEqualThis == null) || ((CertspTestaItem.SegnaturaCertificazione != null) && (CertspTestaItem.SegnaturaCertificazione.Value == SegnaturaCertificazioneEqualThis.Value))))
				{
					CertspTestaCollectionTemp.Add(CertspTestaItem);
				}
			}
			return CertspTestaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspTestaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspTestaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspTesta CertspTestaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Idcertsp", CertspTestaObj.Idcertsp);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "Codpsr", CertspTestaObj.Codpsr);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainizio", CertspTestaObj.Datainizio);
			DbProvider.SetCmdParam(cmd,firstChar + "Datafine", CertspTestaObj.Datafine);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", CertspTestaObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", CertspTestaObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitivo", CertspTestaObj.Definitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Tipo", CertspTestaObj.Tipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainserimento", CertspTestaObj.Datainserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Datamodifica", CertspTestaObj.Datamodifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspTestaObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Datasegnatura", CertspTestaObj.Datasegnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", CertspTestaObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaCertificazione", CertspTestaObj.SegnaturaCertificazione);
		}
		//Insert
		private static int Insert(DbProvider db, CertspTesta CertspTestaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspTestaInsert", new string[] {"Codpsr", "Datainizio", 
"Datafine", "IdFile", "Note", 
"Definitivo", "Tipo", "Datainserimento", 
"Datamodifica", "Operatore", "Datasegnatura", 
"Segnatura", "SegnaturaCertificazione"}, new string[] {"string", "DateTime", 
"DateTime", "int", "string", 
"bool", "string", "DateTime", 
"DateTime", "string", "DateTime", 
"string", "string"},"");
				CompileIUCmd(false, insertCmd,CertspTestaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspTestaObj.Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
				}
				CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaObj.IsDirty = false;
				CertspTestaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspTesta CertspTestaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspTestaUpdate", new string[] {"Idcertsp", "Codpsr", "Datainizio", 
"Datafine", "IdFile", "Note", 
"Definitivo", "Tipo", "Datainserimento", 
"Datamodifica", "Operatore", "Datasegnatura", 
"Segnatura", "SegnaturaCertificazione"}, new string[] {"int", "string", "DateTime", 
"DateTime", "int", "string", 
"bool", "string", "DateTime", 
"DateTime", "string", "DateTime", 
"string", "string"},"");
				CompileIUCmd(true, updateCmd,CertspTestaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaObj.IsDirty = false;
				CertspTestaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspTesta CertspTestaObj)
		{
			switch (CertspTestaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspTestaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspTestaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspTestaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspTestaCollection CertspTestaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspTestaUpdate", new string[] {"Idcertsp", "Codpsr", "Datainizio", 
"Datafine", "IdFile", "Note", 
"Definitivo", "Tipo", "Datainserimento", 
"Datamodifica", "Operatore", "Datasegnatura", 
"Segnatura", "SegnaturaCertificazione"}, new string[] {"int", "string", "DateTime", 
"DateTime", "int", "string", 
"bool", "string", "DateTime", 
"DateTime", "string", "DateTime", 
"string", "string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspTestaInsert", new string[] {"Codpsr", "Datainizio", 
"Datafine", "IdFile", "Note", 
"Definitivo", "Tipo", "Datainserimento", 
"Datamodifica", "Operatore", "Datasegnatura", 
"Segnatura", "SegnaturaCertificazione"}, new string[] {"string", "DateTime", 
"DateTime", "int", "string", 
"bool", "string", "DateTime", 
"DateTime", "string", "DateTime", 
"string", "string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaDelete", new string[] {"Idcertsp"}, new string[] {"int"},"");
				for (int i = 0; i < CertspTestaCollectionObj.Count; i++)
				{
					switch (CertspTestaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspTestaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspTestaCollectionObj[i].Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspTestaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspTestaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Idcertsp", (SiarLibrary.NullTypes.IntNT)CertspTestaCollectionObj[i].Idcertsp);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspTestaCollectionObj.Count; i++)
				{
					if ((CertspTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspTestaCollectionObj[i].IsDirty = false;
						CertspTestaCollectionObj[i].IsPersistent = true;
					}
					if ((CertspTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspTestaCollectionObj[i].IsDirty = false;
						CertspTestaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspTesta CertspTestaObj)
		{
			int returnValue = 0;
			if (CertspTestaObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspTestaObj.Idcertsp);
			}
			CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspTestaObj.IsDirty = false;
			CertspTestaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdcertspValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaDelete", new string[] {"Idcertsp"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Idcertsp", (SiarLibrary.NullTypes.IntNT)IdcertspValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspTestaCollection CertspTestaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaDelete", new string[] {"Idcertsp"}, new string[] {"int"},"");
				for (int i = 0; i < CertspTestaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Idcertsp", CertspTestaCollectionObj[i].Idcertsp);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspTestaCollectionObj.Count; i++)
				{
					if ((CertspTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspTestaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspTestaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspTestaCollectionObj[i].IsDirty = false;
						CertspTestaCollectionObj[i].IsPersistent = false;
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
		public static CertspTesta GetById(DbProvider db, int IdcertspValue)
		{
			CertspTesta CertspTestaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspTestaGetById", new string[] {"Idcertsp"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Idcertsp", (SiarLibrary.NullTypes.IntNT)IdcertspValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspTestaObj = GetFromDatareader(db);
				CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaObj.IsDirty = false;
				CertspTestaObj.IsPersistent = true;
			}
			db.Close();
			return CertspTestaObj;
		}

		//getFromDatareader
		public static CertspTesta GetFromDatareader(DbProvider db)
		{
			CertspTesta CertspTestaObj = new CertspTesta();
			CertspTestaObj.Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
			CertspTestaObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPsr"]);
			CertspTestaObj.Datainizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInizio"]);
			CertspTestaObj.Datafine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataFine"]);
			CertspTestaObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_File"]);
			CertspTestaObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["Note"]);
			CertspTestaObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Definitivo"]);
			CertspTestaObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Tipo"]);
			CertspTestaObj.Datainserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInserimento"]);
			CertspTestaObj.Datamodifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataModifica"]);
			CertspTestaObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Operatore"]);
			CertspTestaObj.Datasegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataSegnatura"]);
			CertspTestaObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["Segnatura"]);
			CertspTestaObj.SegnaturaCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Segnatura_Certificazione"]);
			CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspTestaObj.IsDirty = false;
			CertspTestaObj.IsPersistent = true;
			return CertspTestaObj;
		}

		//Find Select

		public static CertspTestaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdcertspEqualThis, SiarLibrary.NullTypes.StringNT CodpsrEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainizioEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DatafineEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, 
SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DatamodificaEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DatasegnaturaEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaCertificazioneEqualThis)

		{

			CertspTestaCollection CertspTestaCollectionObj = new CertspTestaCollection();

			IDbCommand findCmd = db.InitCmd("Zcertsptestafindselect", new string[] {"Idcertspequalthis", "Codpsrequalthis", "Datainizioequalthis", 
"Datafineequalthis", "IdFileequalthis", "Noteequalthis", 
"Definitivoequalthis", "Tipoequalthis", "Datainserimentoequalthis", 
"Datamodificaequalthis", "Operatoreequalthis", "Datasegnaturaequalthis", 
"Segnaturaequalthis", "SegnaturaCertificazioneequalthis"}, new string[] {"int", "string", "DateTime", 
"DateTime", "int", "string", 
"bool", "string", "DateTime", 
"DateTime", "string", "DateTime", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idcertspequalthis", IdcertspEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Codpsrequalthis", CodpsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datainizioequalthis", DatainizioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datafineequalthis", DatafineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datainserimentoequalthis", DatainserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datamodificaequalthis", DatamodificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Datasegnaturaequalthis", DatasegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaCertificazioneequalthis", SegnaturaCertificazioneEqualThis);
			CertspTesta CertspTestaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspTestaObj = GetFromDatareader(db);
				CertspTestaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaObj.IsDirty = false;
				CertspTestaObj.IsPersistent = true;
				CertspTestaCollectionObj.Add(CertspTestaObj);
			}
			db.Close();
			return CertspTestaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspTestaCollectionProvider:ICertspTestaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspTestaCollectionProvider : ICertspTestaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspTesta
		protected CertspTestaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspTestaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspTestaCollection(this);
		}

		//Costruttore3: ha in input certsptestaCollectionObj - non popola la collection
		public CertspTestaCollectionProvider(CertspTestaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspTestaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspTestaCollection(this);
		}

		//Get e Set
		public CertspTestaCollection CollectionObj
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
		public int SaveCollection(CertspTestaCollection collectionObj)
		{
			return CertspTestaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspTesta certsptestaObj)
		{
			return CertspTestaDAL.Save(_dbProviderObj, certsptestaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspTestaCollection collectionObj)
		{
			return CertspTestaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspTesta certsptestaObj)
		{
			return CertspTestaDAL.Delete(_dbProviderObj, certsptestaObj);
		}

		//getById
		public CertspTesta GetById(IntNT IdcertspValue)
		{
			CertspTesta CertspTestaTemp = CertspTestaDAL.GetById(_dbProviderObj, IdcertspValue);
			if (CertspTestaTemp!=null) CertspTestaTemp.Provider = this;
			return CertspTestaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CertspTestaCollection Select(IntNT IdcertspEqualThis, StringNT CodpsrEqualThis, DatetimeNT DatainizioEqualThis, 
DatetimeNT DatafineEqualThis, IntNT IdfileEqualThis, StringNT NoteEqualThis, 
BoolNT DefinitivoEqualThis, StringNT TipoEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT OperatoreEqualThis, DatetimeNT DatasegnaturaEqualThis, 
StringNT SegnaturaEqualThis, StringNT SegnaturacertificazioneEqualThis)
		{
			CertspTestaCollection CertspTestaCollectionTemp = CertspTestaDAL.Select(_dbProviderObj, IdcertspEqualThis, CodpsrEqualThis, DatainizioEqualThis, 
DatafineEqualThis, IdfileEqualThis, NoteEqualThis, 
DefinitivoEqualThis, TipoEqualThis, DatainserimentoEqualThis, 
DatamodificaEqualThis, OperatoreEqualThis, DatasegnaturaEqualThis, 
SegnaturaEqualThis, SegnaturacertificazioneEqualThis);
			CertspTestaCollectionTemp.Provider = this;
			return CertspTestaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CertSp_Testa>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CertSp_Testa>
*/
