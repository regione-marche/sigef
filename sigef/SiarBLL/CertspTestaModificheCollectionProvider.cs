using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per CertspTestaModifiche
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface ICertspTestaModificheProvider
	{
		int Save(CertspTestaModifiche CertspTestaModificheObj);
		int SaveCollection(CertspTestaModificheCollection collectionObj);
		int Delete(CertspTestaModifiche CertspTestaModificheObj);
		int DeleteCollection(CertspTestaModificheCollection collectionObj);
	}
	/// <summary>
	/// Summary description for CertspTestaModifiche
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class CertspTestaModifiche: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdModifica;
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
		[NonSerialized] private ICertspTestaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspTestaModificheProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public CertspTestaModifiche()
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
		/// Corrisponde al campo:ID_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdModifica
		{
			get { return _IdModifica; }
			set {
				if (IdModifica != value)
				{
					_IdModifica = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Tipo sul db:VARCHAR(100)
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
	/// Summary description for CertspTestaModificheCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspTestaModificheCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CertspTestaModificheCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CertspTestaModifiche) info.GetValue(i.ToString(),typeof(CertspTestaModifiche)));
			}
		}

		//Costruttore
		public CertspTestaModificheCollection()
		{
			this.ItemType = typeof(CertspTestaModifiche);
		}

		//Costruttore con provider
		public CertspTestaModificheCollection(ICertspTestaModificheProvider providerObj)
		{
			this.ItemType = typeof(CertspTestaModifiche);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CertspTestaModifiche this[int index]
		{
			get { return (CertspTestaModifiche)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CertspTestaModificheCollection GetChanges()
		{
			return (CertspTestaModificheCollection) base.GetChanges();
		}

		[NonSerialized] private ICertspTestaModificheProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICertspTestaModificheProvider Provider
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
		public int Add(CertspTestaModifiche CertspTestaModificheObj)
		{
			if (CertspTestaModificheObj.Provider == null) CertspTestaModificheObj.Provider = this.Provider;
			return base.Add(CertspTestaModificheObj);
		}

		//AddCollection
		public void AddCollection(CertspTestaModificheCollection CertspTestaModificheCollectionObj)
		{
			foreach (CertspTestaModifiche CertspTestaModificheObj in CertspTestaModificheCollectionObj)
				this.Add(CertspTestaModificheObj);
		}

		//Insert
		public void Insert(int index, CertspTestaModifiche CertspTestaModificheObj)
		{
			if (CertspTestaModificheObj.Provider == null) CertspTestaModificheObj.Provider = this.Provider;
			base.Insert(index, CertspTestaModificheObj);
		}

		//CollectionGetById
		public CertspTestaModifiche CollectionGetById(NullTypes.IntNT IdValue)
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
		public CertspTestaModificheCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdModificaEqualThis, NullTypes.IntNT IdcertspEqualThis, 
NullTypes.StringNT CodpsrEqualThis, NullTypes.DatetimeNT DatainizioEqualThis, NullTypes.DatetimeNT DatafineEqualThis, 
NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.BoolNT DefinitivoEqualThis, 
NullTypes.StringNT TipoEqualThis, NullTypes.DatetimeNT DatainserimentoEqualThis, NullTypes.DatetimeNT DatamodificaEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.DatetimeNT DatasegnaturaEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.StringNT SegnaturaCertificazioneEqualThis)
		{
			CertspTestaModificheCollection CertspTestaModificheCollectionTemp = new CertspTestaModificheCollection();
			foreach (CertspTestaModifiche CertspTestaModificheItem in this)
			{
				if (((IdEqualThis == null) || ((CertspTestaModificheItem.Id != null) && (CertspTestaModificheItem.Id.Value == IdEqualThis.Value))) && ((IdModificaEqualThis == null) || ((CertspTestaModificheItem.IdModifica != null) && (CertspTestaModificheItem.IdModifica.Value == IdModificaEqualThis.Value))) && ((IdcertspEqualThis == null) || ((CertspTestaModificheItem.Idcertsp != null) && (CertspTestaModificheItem.Idcertsp.Value == IdcertspEqualThis.Value))) && 
((CodpsrEqualThis == null) || ((CertspTestaModificheItem.Codpsr != null) && (CertspTestaModificheItem.Codpsr.Value == CodpsrEqualThis.Value))) && ((DatainizioEqualThis == null) || ((CertspTestaModificheItem.Datainizio != null) && (CertspTestaModificheItem.Datainizio.Value == DatainizioEqualThis.Value))) && ((DatafineEqualThis == null) || ((CertspTestaModificheItem.Datafine != null) && (CertspTestaModificheItem.Datafine.Value == DatafineEqualThis.Value))) && 
((IdFileEqualThis == null) || ((CertspTestaModificheItem.IdFile != null) && (CertspTestaModificheItem.IdFile.Value == IdFileEqualThis.Value))) && ((NoteEqualThis == null) || ((CertspTestaModificheItem.Note != null) && (CertspTestaModificheItem.Note.Value == NoteEqualThis.Value))) && ((DefinitivoEqualThis == null) || ((CertspTestaModificheItem.Definitivo != null) && (CertspTestaModificheItem.Definitivo.Value == DefinitivoEqualThis.Value))) && 
((TipoEqualThis == null) || ((CertspTestaModificheItem.Tipo != null) && (CertspTestaModificheItem.Tipo.Value == TipoEqualThis.Value))) && ((DatainserimentoEqualThis == null) || ((CertspTestaModificheItem.Datainserimento != null) && (CertspTestaModificheItem.Datainserimento.Value == DatainserimentoEqualThis.Value))) && ((DatamodificaEqualThis == null) || ((CertspTestaModificheItem.Datamodifica != null) && (CertspTestaModificheItem.Datamodifica.Value == DatamodificaEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((CertspTestaModificheItem.Operatore != null) && (CertspTestaModificheItem.Operatore.Value == OperatoreEqualThis.Value))) && ((DatasegnaturaEqualThis == null) || ((CertspTestaModificheItem.Datasegnatura != null) && (CertspTestaModificheItem.Datasegnatura.Value == DatasegnaturaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((CertspTestaModificheItem.Segnatura != null) && (CertspTestaModificheItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((SegnaturaCertificazioneEqualThis == null) || ((CertspTestaModificheItem.SegnaturaCertificazione != null) && (CertspTestaModificheItem.SegnaturaCertificazione.Value == SegnaturaCertificazioneEqualThis.Value))))
				{
					CertspTestaModificheCollectionTemp.Add(CertspTestaModificheItem);
				}
			}
			return CertspTestaModificheCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for CertspTestaModificheDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class CertspTestaModificheDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspTestaModifiche CertspTestaModificheObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", CertspTestaModificheObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdModifica", CertspTestaModificheObj.IdModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Idcertsp", CertspTestaModificheObj.Idcertsp);
			DbProvider.SetCmdParam(cmd,firstChar + "Codpsr", CertspTestaModificheObj.Codpsr);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainizio", CertspTestaModificheObj.Datainizio);
			DbProvider.SetCmdParam(cmd,firstChar + "Datafine", CertspTestaModificheObj.Datafine);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", CertspTestaModificheObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "Note", CertspTestaModificheObj.Note);
			DbProvider.SetCmdParam(cmd,firstChar + "Definitivo", CertspTestaModificheObj.Definitivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Tipo", CertspTestaModificheObj.Tipo);
			DbProvider.SetCmdParam(cmd,firstChar + "Datainserimento", CertspTestaModificheObj.Datainserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "Datamodifica", CertspTestaModificheObj.Datamodifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", CertspTestaModificheObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Datasegnatura", CertspTestaModificheObj.Datasegnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", CertspTestaModificheObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaCertificazione", CertspTestaModificheObj.SegnaturaCertificazione);
		}
		//Insert
		private static int Insert(DbProvider db, CertspTestaModifiche CertspTestaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZCertspTestaModificheInsert", new string[] {"IdModifica", "Idcertsp", 
"Codpsr", "Datainizio", "Datafine", 
"IdFile", "Note", "Definitivo", 
"Tipo", "Datainserimento", "Datamodifica", 
"Operatore", "Datasegnatura", "Segnatura", 
"SegnaturaCertificazione"}, new string[] {"int", "int", 
"string", "DateTime", "DateTime", 
"int", "string", "bool", 
"string", "DateTime", "DateTime", 
"string", "DateTime", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,CertspTestaModificheObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				CertspTestaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaModificheObj.IsDirty = false;
				CertspTestaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, CertspTestaModifiche CertspTestaModificheObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspTestaModificheUpdate", new string[] {"Id", "IdModifica", "Idcertsp", 
"Codpsr", "Datainizio", "Datafine", 
"IdFile", "Note", "Definitivo", 
"Tipo", "Datainserimento", "Datamodifica", 
"Operatore", "Datasegnatura", "Segnatura", 
"SegnaturaCertificazione"}, new string[] {"int", "int", "int", 
"string", "DateTime", "DateTime", 
"int", "string", "bool", 
"string", "DateTime", "DateTime", 
"string", "DateTime", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,CertspTestaModificheObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaModificheObj.IsDirty = false;
				CertspTestaModificheObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, CertspTestaModifiche CertspTestaModificheObj)
		{
			switch (CertspTestaModificheObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, CertspTestaModificheObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, CertspTestaModificheObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,CertspTestaModificheObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, CertspTestaModificheCollection CertspTestaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZCertspTestaModificheUpdate", new string[] {"Id", "IdModifica", "Idcertsp", 
"Codpsr", "Datainizio", "Datafine", 
"IdFile", "Note", "Definitivo", 
"Tipo", "Datainserimento", "Datamodifica", 
"Operatore", "Datasegnatura", "Segnatura", 
"SegnaturaCertificazione"}, new string[] {"int", "int", "int", 
"string", "DateTime", "DateTime", 
"int", "string", "bool", 
"string", "DateTime", "DateTime", 
"string", "DateTime", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZCertspTestaModificheInsert", new string[] {"IdModifica", "Idcertsp", 
"Codpsr", "Datainizio", "Datafine", 
"IdFile", "Note", "Definitivo", 
"Tipo", "Datainserimento", "Datamodifica", 
"Operatore", "Datasegnatura", "Segnatura", 
"SegnaturaCertificazione"}, new string[] {"int", "int", 
"string", "DateTime", "DateTime", 
"int", "string", "bool", 
"string", "DateTime", "DateTime", 
"string", "DateTime", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspTestaModificheCollectionObj.Count; i++)
				{
					switch (CertspTestaModificheCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,CertspTestaModificheCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									CertspTestaModificheCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,CertspTestaModificheCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (CertspTestaModificheCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)CertspTestaModificheCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < CertspTestaModificheCollectionObj.Count; i++)
				{
					if ((CertspTestaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspTestaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspTestaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						CertspTestaModificheCollectionObj[i].IsDirty = false;
						CertspTestaModificheCollectionObj[i].IsPersistent = true;
					}
					if ((CertspTestaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						CertspTestaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspTestaModificheCollectionObj[i].IsDirty = false;
						CertspTestaModificheCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, CertspTestaModifiche CertspTestaModificheObj)
		{
			int returnValue = 0;
			if (CertspTestaModificheObj.IsPersistent) 
			{
				returnValue = Delete(db, CertspTestaModificheObj.Id);
			}
			CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			CertspTestaModificheObj.IsDirty = false;
			CertspTestaModificheObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, CertspTestaModificheCollection CertspTestaModificheCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZCertspTestaModificheDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < CertspTestaModificheCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", CertspTestaModificheCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < CertspTestaModificheCollectionObj.Count; i++)
				{
					if ((CertspTestaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspTestaModificheCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						CertspTestaModificheCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						CertspTestaModificheCollectionObj[i].IsDirty = false;
						CertspTestaModificheCollectionObj[i].IsPersistent = false;
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
		public static CertspTestaModifiche GetById(DbProvider db, int IdValue)
		{
			CertspTestaModifiche CertspTestaModificheObj = null;
			IDbCommand readCmd = db.InitCmd( "ZCertspTestaModificheGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				CertspTestaModificheObj = GetFromDatareader(db);
				CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaModificheObj.IsDirty = false;
				CertspTestaModificheObj.IsPersistent = true;
			}
			db.Close();
			return CertspTestaModificheObj;
		}

		//getFromDatareader
		public static CertspTestaModifiche GetFromDatareader(DbProvider db)
		{
			CertspTestaModifiche CertspTestaModificheObj = new CertspTestaModifiche();
			CertspTestaModificheObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			CertspTestaModificheObj.IdModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODIFICA"]);
			CertspTestaModificheObj.Idcertsp = new SiarLibrary.NullTypes.IntNT(db.DataReader["IdCertSp"]);
			CertspTestaModificheObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPsr"]);
			CertspTestaModificheObj.Datainizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInizio"]);
			CertspTestaModificheObj.Datafine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataFine"]);
			CertspTestaModificheObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["Id_File"]);
			CertspTestaModificheObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["Note"]);
			CertspTestaModificheObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["Definitivo"]);
			CertspTestaModificheObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["Tipo"]);
			CertspTestaModificheObj.Datainserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataInserimento"]);
			CertspTestaModificheObj.Datamodifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataModifica"]);
			CertspTestaModificheObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["Operatore"]);
			CertspTestaModificheObj.Datasegnatura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DataSegnatura"]);
			CertspTestaModificheObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["Segnatura"]);
			CertspTestaModificheObj.SegnaturaCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["Segnatura_Certificazione"]);
			CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			CertspTestaModificheObj.IsDirty = false;
			CertspTestaModificheObj.IsPersistent = true;
			return CertspTestaModificheObj;
		}

		//Find Select

		public static CertspTestaModificheCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdModificaEqualThis, SiarLibrary.NullTypes.IntNT IdcertspEqualThis, 
SiarLibrary.NullTypes.StringNT CodpsrEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainizioEqualThis, SiarLibrary.NullTypes.DatetimeNT DatafineEqualThis, 
SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis, 
SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatainserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DatamodificaEqualThis, 
SiarLibrary.NullTypes.StringNT OperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DatasegnaturaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaCertificazioneEqualThis)

		{

			CertspTestaModificheCollection CertspTestaModificheCollectionObj = new CertspTestaModificheCollection();

			IDbCommand findCmd = db.InitCmd("Zcertsptestamodifichefindselect", new string[] {"Idequalthis", "IdModificaequalthis", "Idcertspequalthis", 
"Codpsrequalthis", "Datainizioequalthis", "Datafineequalthis", 
"IdFileequalthis", "Noteequalthis", "Definitivoequalthis", 
"Tipoequalthis", "Datainserimentoequalthis", "Datamodificaequalthis", 
"Operatoreequalthis", "Datasegnaturaequalthis", "Segnaturaequalthis", 
"SegnaturaCertificazioneequalthis"}, new string[] {"int", "int", "int", 
"string", "DateTime", "DateTime", 
"int", "string", "bool", 
"string", "DateTime", "DateTime", 
"string", "DateTime", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdModificaequalthis", IdModificaEqualThis);
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
			CertspTestaModifiche CertspTestaModificheObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				CertspTestaModificheObj = GetFromDatareader(db);
				CertspTestaModificheObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				CertspTestaModificheObj.IsDirty = false;
				CertspTestaModificheObj.IsPersistent = true;
				CertspTestaModificheCollectionObj.Add(CertspTestaModificheObj);
			}
			db.Close();
			return CertspTestaModificheCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for CertspTestaModificheCollectionProvider:ICertspTestaModificheProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class CertspTestaModificheCollectionProvider : ICertspTestaModificheProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CertspTestaModifiche
		protected CertspTestaModificheCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CertspTestaModificheCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CertspTestaModificheCollection(this);
		}

		//Costruttore3: ha in input certsptestamodificheCollectionObj - non popola la collection
		public CertspTestaModificheCollectionProvider(CertspTestaModificheCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CertspTestaModificheCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CertspTestaModificheCollection(this);
		}

		//Get e Set
		public CertspTestaModificheCollection CollectionObj
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
		public int SaveCollection(CertspTestaModificheCollection collectionObj)
		{
			return CertspTestaModificheDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CertspTestaModifiche certsptestamodificheObj)
		{
			return CertspTestaModificheDAL.Save(_dbProviderObj, certsptestamodificheObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CertspTestaModificheCollection collectionObj)
		{
			return CertspTestaModificheDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CertspTestaModifiche certsptestamodificheObj)
		{
			return CertspTestaModificheDAL.Delete(_dbProviderObj, certsptestamodificheObj);
		}

		//getById
		public CertspTestaModifiche GetById(IntNT IdValue)
		{
			CertspTestaModifiche CertspTestaModificheTemp = CertspTestaModificheDAL.GetById(_dbProviderObj, IdValue);
			if (CertspTestaModificheTemp!=null) CertspTestaModificheTemp.Provider = this;
			return CertspTestaModificheTemp;
		}

		//Select: popola la collection
		public CertspTestaModificheCollection Select(IntNT IdEqualThis, IntNT IdmodificaEqualThis, IntNT IdcertspEqualThis, 
StringNT CodpsrEqualThis, DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis, 
IntNT IdfileEqualThis, StringNT NoteEqualThis, BoolNT DefinitivoEqualThis, 
StringNT TipoEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, 
StringNT OperatoreEqualThis, DatetimeNT DatasegnaturaEqualThis, StringNT SegnaturaEqualThis, 
StringNT SegnaturacertificazioneEqualThis)
		{
			CertspTestaModificheCollection CertspTestaModificheCollectionTemp = CertspTestaModificheDAL.Select(_dbProviderObj, IdEqualThis, IdmodificaEqualThis, IdcertspEqualThis, 
CodpsrEqualThis, DatainizioEqualThis, DatafineEqualThis, 
IdfileEqualThis, NoteEqualThis, DefinitivoEqualThis, 
TipoEqualThis, DatainserimentoEqualThis, DatamodificaEqualThis, 
OperatoreEqualThis, DatasegnaturaEqualThis, SegnaturaEqualThis, 
SegnaturacertificazioneEqualThis);
			CertspTestaModificheCollectionTemp.Provider = this;
			return CertspTestaModificheCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CertSp_Testa_MODIFICHE>
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
</CertSp_Testa_MODIFICHE>
*/
