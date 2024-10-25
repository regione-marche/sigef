using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ComunicazioniMassive
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IComunicazioniMassiveProvider
	{
		int Save(ComunicazioniMassive ComunicazioniMassiveObj);
		int SaveCollection(ComunicazioniMassiveCollection collectionObj);
		int Delete(ComunicazioniMassive ComunicazioniMassiveObj);
		int DeleteCollection(ComunicazioniMassiveCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ComunicazioniMassive
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ComunicazioniMassive: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Oggetto;
		private NullTypes.StringNT _Testo;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.IntNT _IdNote;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _DescrizioneAllegato;
		private NullTypes.StringNT _Progetti;
		[NonSerialized] private IComunicazioniMassiveProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IComunicazioniMassiveProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ComunicazioniMassive()
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
		/// Corrisponde al campo:OGGETTO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Oggetto
		{
			get { return _Oggetto; }
			set {
				if (Oggetto != value)
				{
					_Oggetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Testo
		{
			get { return _Testo; }
			set {
				if (Testo != value)
				{
					_Testo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:VARCHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
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
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Operatore
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
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:ID_NOTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdNote
		{
			get { return _IdNote; }
			set {
				if (IdNote != value)
				{
					_IdNote = value;
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
		/// Corrisponde al campo:DESCRIZIONE_ALLEGATO
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT DescrizioneAllegato
		{
			get { return _DescrizioneAllegato; }
			set {
				if (DescrizioneAllegato != value)
				{
					_DescrizioneAllegato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROGETTI
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Progetti
		{
			get { return _Progetti; }
			set {
				if (Progetti != value)
				{
					_Progetti = value;
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
	/// Summary description for ComunicazioniMassiveCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ComunicazioniMassiveCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ComunicazioniMassiveCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ComunicazioniMassive) info.GetValue(i.ToString(),typeof(ComunicazioniMassive)));
			}
		}

		//Costruttore
		public ComunicazioniMassiveCollection()
		{
			this.ItemType = typeof(ComunicazioniMassive);
		}

		//Costruttore con provider
		public ComunicazioniMassiveCollection(IComunicazioniMassiveProvider providerObj)
		{
			this.ItemType = typeof(ComunicazioniMassive);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ComunicazioniMassive this[int index]
		{
			get { return (ComunicazioniMassive)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ComunicazioniMassiveCollection GetChanges()
		{
			return (ComunicazioniMassiveCollection) base.GetChanges();
		}

		[NonSerialized] private IComunicazioniMassiveProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IComunicazioniMassiveProvider Provider
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
		public int Add(ComunicazioniMassive ComunicazioniMassiveObj)
		{
			if (ComunicazioniMassiveObj.Provider == null) ComunicazioniMassiveObj.Provider = this.Provider;
			return base.Add(ComunicazioniMassiveObj);
		}

		//AddCollection
		public void AddCollection(ComunicazioniMassiveCollection ComunicazioniMassiveCollectionObj)
		{
			foreach (ComunicazioniMassive ComunicazioniMassiveObj in ComunicazioniMassiveCollectionObj)
				this.Add(ComunicazioniMassiveObj);
		}

		//Insert
		public void Insert(int index, ComunicazioniMassive ComunicazioniMassiveObj)
		{
			if (ComunicazioniMassiveObj.Provider == null) ComunicazioniMassiveObj.Provider = this.Provider;
			base.Insert(index, ComunicazioniMassiveObj);
		}

		//CollectionGetById
		public ComunicazioniMassive CollectionGetById(NullTypes.IntNT IdValue)
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
		public ComunicazioniMassiveCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT OggettoEqualThis, 
NullTypes.StringNT TestoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.IntNT IdNoteEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT DescrizioneAllegatoEqualThis, 
NullTypes.StringNT ProgettiEqualThis)
		{
			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionTemp = new ComunicazioniMassiveCollection();
			foreach (ComunicazioniMassive ComunicazioniMassiveItem in this)
			{
				if (((IdEqualThis == null) || ((ComunicazioniMassiveItem.Id != null) && (ComunicazioniMassiveItem.Id.Value == IdEqualThis.Value))) && ((IdBandoEqualThis == null) || ((ComunicazioniMassiveItem.IdBando != null) && (ComunicazioniMassiveItem.IdBando.Value == IdBandoEqualThis.Value))) && ((OggettoEqualThis == null) || ((ComunicazioniMassiveItem.Oggetto != null) && (ComunicazioniMassiveItem.Oggetto.Value == OggettoEqualThis.Value))) && 
((TestoEqualThis == null) || ((ComunicazioniMassiveItem.Testo != null) && (ComunicazioniMassiveItem.Testo.Value == TestoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ComunicazioniMassiveItem.CodTipo != null) && (ComunicazioniMassiveItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ComunicazioniMassiveItem.DataInserimento != null) && (ComunicazioniMassiveItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((ComunicazioniMassiveItem.DataModifica != null) && (ComunicazioniMassiveItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ComunicazioniMassiveItem.Operatore != null) && (ComunicazioniMassiveItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ComunicazioniMassiveItem.Segnatura != null) && (ComunicazioniMassiveItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((IdNoteEqualThis == null) || ((ComunicazioniMassiveItem.IdNote != null) && (ComunicazioniMassiveItem.IdNote.Value == IdNoteEqualThis.Value))) && ((IdFileEqualThis == null) || ((ComunicazioniMassiveItem.IdFile != null) && (ComunicazioniMassiveItem.IdFile.Value == IdFileEqualThis.Value))) && ((DescrizioneAllegatoEqualThis == null) || ((ComunicazioniMassiveItem.DescrizioneAllegato != null) && (ComunicazioniMassiveItem.DescrizioneAllegato.Value == DescrizioneAllegatoEqualThis.Value))) && 
((ProgettiEqualThis == null) || ((ComunicazioniMassiveItem.Progetti != null) && (ComunicazioniMassiveItem.Progetti.Value == ProgettiEqualThis.Value))))
				{
					ComunicazioniMassiveCollectionTemp.Add(ComunicazioniMassiveItem);
				}
			}
			return ComunicazioniMassiveCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ComunicazioniMassiveCollection Filter(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT OperatoreEqualThis)
		{
			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionTemp = new ComunicazioniMassiveCollection();
			foreach (ComunicazioniMassive ComunicazioniMassiveItem in this)
			{
				if (((IdBandoEqualThis == null) || ((ComunicazioniMassiveItem.IdBando != null) && (ComunicazioniMassiveItem.IdBando.Value == IdBandoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ComunicazioniMassiveItem.Operatore != null) && (ComunicazioniMassiveItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					ComunicazioniMassiveCollectionTemp.Add(ComunicazioniMassiveItem);
				}
			}
			return ComunicazioniMassiveCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ComunicazioniMassiveDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ComunicazioniMassiveDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ComunicazioniMassive ComunicazioniMassiveObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ComunicazioniMassiveObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdBando", ComunicazioniMassiveObj.IdBando);
			DbProvider.SetCmdParam(cmd,firstChar + "Oggetto", ComunicazioniMassiveObj.Oggetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", ComunicazioniMassiveObj.Testo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", ComunicazioniMassiveObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ComunicazioniMassiveObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ComunicazioniMassiveObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ComunicazioniMassiveObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ComunicazioniMassiveObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", ComunicazioniMassiveObj.IdNote);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", ComunicazioniMassiveObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "DescrizioneAllegato", ComunicazioniMassiveObj.DescrizioneAllegato);
			DbProvider.SetCmdParam(cmd,firstChar + "Progetti", ComunicazioniMassiveObj.Progetti);
		}
		//Insert
		private static int Insert(DbProvider db, ComunicazioniMassive ComunicazioniMassiveObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZComunicazioniMassiveInsert", new string[] {"IdBando", "Oggetto", 
"Testo", "CodTipo", "DataInserimento", 
"DataModifica", "Operatore", "Segnatura", 
"IdNote", "IdFile", "DescrizioneAllegato", 
"Progetti"}, new string[] {"int", "string", 
"string", "string", "DateTime", 
"DateTime", "int", "string", 
"int", "int", "string", 
"string"},"");
				CompileIUCmd(false, insertCmd,ComunicazioniMassiveObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ComunicazioniMassiveObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				}
				ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComunicazioniMassiveObj.IsDirty = false;
				ComunicazioniMassiveObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ComunicazioniMassive ComunicazioniMassiveObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZComunicazioniMassiveUpdate", new string[] {"Id", "IdBando", "Oggetto", 
"Testo", "CodTipo", "DataInserimento", 
"DataModifica", "Operatore", "Segnatura", 
"IdNote", "IdFile", "DescrizioneAllegato", 
"Progetti"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"DateTime", "int", "string", 
"int", "int", "string", 
"string"},"");
				CompileIUCmd(true, updateCmd,ComunicazioniMassiveObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					ComunicazioniMassiveObj.DataModifica = d;
				}
				ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComunicazioniMassiveObj.IsDirty = false;
				ComunicazioniMassiveObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ComunicazioniMassive ComunicazioniMassiveObj)
		{
			switch (ComunicazioniMassiveObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ComunicazioniMassiveObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ComunicazioniMassiveObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ComunicazioniMassiveObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ComunicazioniMassiveCollection ComunicazioniMassiveCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZComunicazioniMassiveUpdate", new string[] {"Id", "IdBando", "Oggetto", 
"Testo", "CodTipo", "DataInserimento", 
"DataModifica", "Operatore", "Segnatura", 
"IdNote", "IdFile", "DescrizioneAllegato", 
"Progetti"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"DateTime", "int", "string", 
"int", "int", "string", 
"string"},"");
				IDbCommand insertCmd = db.InitCmd( "ZComunicazioniMassiveInsert", new string[] {"IdBando", "Oggetto", 
"Testo", "CodTipo", "DataInserimento", 
"DataModifica", "Operatore", "Segnatura", 
"IdNote", "IdFile", "DescrizioneAllegato", 
"Progetti"}, new string[] {"int", "string", 
"string", "string", "DateTime", 
"DateTime", "int", "string", 
"int", "int", "string", 
"string"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZComunicazioniMassiveDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ComunicazioniMassiveCollectionObj.Count; i++)
				{
					switch (ComunicazioniMassiveCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ComunicazioniMassiveCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ComunicazioniMassiveCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ComunicazioniMassiveCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									ComunicazioniMassiveCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ComunicazioniMassiveCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ComunicazioniMassiveCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ComunicazioniMassiveCollectionObj.Count; i++)
				{
					if ((ComunicazioniMassiveCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ComunicazioniMassiveCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ComunicazioniMassiveCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ComunicazioniMassiveCollectionObj[i].IsDirty = false;
						ComunicazioniMassiveCollectionObj[i].IsPersistent = true;
					}
					if ((ComunicazioniMassiveCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ComunicazioniMassiveCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ComunicazioniMassiveCollectionObj[i].IsDirty = false;
						ComunicazioniMassiveCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ComunicazioniMassive ComunicazioniMassiveObj)
		{
			int returnValue = 0;
			if (ComunicazioniMassiveObj.IsPersistent) 
			{
				returnValue = Delete(db, ComunicazioniMassiveObj.Id);
			}
			ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ComunicazioniMassiveObj.IsDirty = false;
			ComunicazioniMassiveObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZComunicazioniMassiveDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ComunicazioniMassiveCollection ComunicazioniMassiveCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZComunicazioniMassiveDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ComunicazioniMassiveCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ComunicazioniMassiveCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ComunicazioniMassiveCollectionObj.Count; i++)
				{
					if ((ComunicazioniMassiveCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ComunicazioniMassiveCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ComunicazioniMassiveCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ComunicazioniMassiveCollectionObj[i].IsDirty = false;
						ComunicazioniMassiveCollectionObj[i].IsPersistent = false;
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
		public static ComunicazioniMassive GetById(DbProvider db, int IdValue)
		{
			ComunicazioniMassive ComunicazioniMassiveObj = null;
			IDbCommand readCmd = db.InitCmd( "ZComunicazioniMassiveGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ComunicazioniMassiveObj = GetFromDatareader(db);
				ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComunicazioniMassiveObj.IsDirty = false;
				ComunicazioniMassiveObj.IsPersistent = true;
			}
			db.Close();
			return ComunicazioniMassiveObj;
		}

		//getFromDatareader
		public static ComunicazioniMassive GetFromDatareader(DbProvider db)
		{
			ComunicazioniMassive ComunicazioniMassiveObj = new ComunicazioniMassive();
			ComunicazioniMassiveObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ComunicazioniMassiveObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			ComunicazioniMassiveObj.Oggetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["OGGETTO"]);
			ComunicazioniMassiveObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			ComunicazioniMassiveObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ComunicazioniMassiveObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ComunicazioniMassiveObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ComunicazioniMassiveObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ComunicazioniMassiveObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ComunicazioniMassiveObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			ComunicazioniMassiveObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			ComunicazioniMassiveObj.DescrizioneAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ALLEGATO"]);
			ComunicazioniMassiveObj.Progetti = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROGETTI"]);
			ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ComunicazioniMassiveObj.IsDirty = false;
			ComunicazioniMassiveObj.IsPersistent = true;
			return ComunicazioniMassiveObj;
		}

		//Find Select

		public static ComunicazioniMassiveCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT OggettoEqualThis, 
SiarLibrary.NullTypes.StringNT TestoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.IntNT IdNoteEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneAllegatoEqualThis, 
SiarLibrary.NullTypes.StringNT ProgettiEqualThis)

		{

			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionObj = new ComunicazioniMassiveCollection();

			IDbCommand findCmd = db.InitCmd("Zcomunicazionimassivefindselect", new string[] {"Idequalthis", "IdBandoequalthis", "Oggettoequalthis", 
"Testoequalthis", "CodTipoequalthis", "DataInserimentoequalthis", 
"DataModificaequalthis", "Operatoreequalthis", "Segnaturaequalthis", 
"IdNoteequalthis", "IdFileequalthis", "DescrizioneAllegatoequalthis", 
"Progettiequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "DateTime", 
"DateTime", "int", "string", 
"int", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Oggettoequalthis", OggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneAllegatoequalthis", DescrizioneAllegatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Progettiequalthis", ProgettiEqualThis);
			ComunicazioniMassive ComunicazioniMassiveObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ComunicazioniMassiveObj = GetFromDatareader(db);
				ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComunicazioniMassiveObj.IsDirty = false;
				ComunicazioniMassiveObj.IsPersistent = true;
				ComunicazioniMassiveCollectionObj.Add(ComunicazioniMassiveObj);
			}
			db.Close();
			return ComunicazioniMassiveCollectionObj;
		}

		//Find Find

		public static ComunicazioniMassiveCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionObj = new ComunicazioniMassiveCollection();

			IDbCommand findCmd = db.InitCmd("Zcomunicazionimassivefindfind", new string[] {"IdBandoequalthis", "Operatoreequalthis"}, new string[] {"int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			ComunicazioniMassive ComunicazioniMassiveObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ComunicazioniMassiveObj = GetFromDatareader(db);
				ComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ComunicazioniMassiveObj.IsDirty = false;
				ComunicazioniMassiveObj.IsPersistent = true;
				ComunicazioniMassiveCollectionObj.Add(ComunicazioniMassiveObj);
			}
			db.Close();
			return ComunicazioniMassiveCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ComunicazioniMassiveCollectionProvider:IComunicazioniMassiveProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ComunicazioniMassiveCollectionProvider : IComunicazioniMassiveProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ComunicazioniMassive
		protected ComunicazioniMassiveCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ComunicazioniMassiveCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ComunicazioniMassiveCollection(this);
		}

		//Costruttore 2: popola la collection
		public ComunicazioniMassiveCollectionProvider(IntNT IdbandoEqualThis, IntNT OperatoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, OperatoreEqualThis);
		}

		//Costruttore3: ha in input comunicazionimassiveCollectionObj - non popola la collection
		public ComunicazioniMassiveCollectionProvider(ComunicazioniMassiveCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ComunicazioniMassiveCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ComunicazioniMassiveCollection(this);
		}

		//Get e Set
		public ComunicazioniMassiveCollection CollectionObj
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
		public int SaveCollection(ComunicazioniMassiveCollection collectionObj)
		{
			return ComunicazioniMassiveDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ComunicazioniMassive comunicazionimassiveObj)
		{
			return ComunicazioniMassiveDAL.Save(_dbProviderObj, comunicazionimassiveObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ComunicazioniMassiveCollection collectionObj)
		{
			return ComunicazioniMassiveDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ComunicazioniMassive comunicazionimassiveObj)
		{
			return ComunicazioniMassiveDAL.Delete(_dbProviderObj, comunicazionimassiveObj);
		}

		//getById
		public ComunicazioniMassive GetById(IntNT IdValue)
		{
			ComunicazioniMassive ComunicazioniMassiveTemp = ComunicazioniMassiveDAL.GetById(_dbProviderObj, IdValue);
			if (ComunicazioniMassiveTemp!=null) ComunicazioniMassiveTemp.Provider = this;
			return ComunicazioniMassiveTemp;
		}

		//Select: popola la collection
		public ComunicazioniMassiveCollection Select(IntNT IdEqualThis, IntNT IdbandoEqualThis, StringNT OggettoEqualThis, 
StringNT TestoEqualThis, StringNT CodtipoEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis, IntNT OperatoreEqualThis, StringNT SegnaturaEqualThis, 
IntNT IdnoteEqualThis, IntNT IdfileEqualThis, StringNT DescrizioneallegatoEqualThis, 
StringNT ProgettiEqualThis)
		{
			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionTemp = ComunicazioniMassiveDAL.Select(_dbProviderObj, IdEqualThis, IdbandoEqualThis, OggettoEqualThis, 
TestoEqualThis, CodtipoEqualThis, DatainserimentoEqualThis, 
DatamodificaEqualThis, OperatoreEqualThis, SegnaturaEqualThis, 
IdnoteEqualThis, IdfileEqualThis, DescrizioneallegatoEqualThis, 
ProgettiEqualThis);
			ComunicazioniMassiveCollectionTemp.Provider = this;
			return ComunicazioniMassiveCollectionTemp;
		}

		//Find: popola la collection
		public ComunicazioniMassiveCollection Find(IntNT IdbandoEqualThis, IntNT OperatoreEqualThis)
		{
			ComunicazioniMassiveCollection ComunicazioniMassiveCollectionTemp = ComunicazioniMassiveDAL.Find(_dbProviderObj, IdbandoEqualThis, OperatoreEqualThis);
			ComunicazioniMassiveCollectionTemp.Provider = this;
			return ComunicazioniMassiveCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<COMUNICAZIONI_MASSIVE>
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
    <Find OrderBy="ORDER BY ID_BANDO">
      <ID_BANDO>Equal</ID_BANDO>
      <OPERATORE>Equal</OPERATORE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
      <OPERATORE>Equal</OPERATORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</COMUNICAZIONI_MASSIVE>
*/
