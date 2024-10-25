using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoComunicazione
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoComunicazioneProvider
	{
		int Save(ProgettoComunicazione ProgettoComunicazioneObj);
		int SaveCollection(ProgettoComunicazioneCollection collectionObj);
		int Delete(ProgettoComunicazione ProgettoComunicazioneObj);
		int DeleteCollection(ProgettoComunicazioneCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoComunicazione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoComunicazione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdComunicazione;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdComunicazioneRef;
		private NullTypes.StringNT _Oggetto;
		private NullTypes.StringNT _Testo;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.BoolNT _SegnaturaEsterna;
		private NullTypes.BoolNT _InEntrata;
		private NullTypes.IntNT _IdNote;
		private NullTypes.StringNT _TestoNote;
		private NullTypes.BoolNT _PredispostaAllaFirma;
		[NonSerialized] private IProgettoComunicazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioneProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoComunicazione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_COMUNICAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComunicazione
		{
			get { return _IdComunicazione; }
			set {
				if (IdComunicazione != value)
				{
					_IdComunicazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_COMUNICAZIONE_REF
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdComunicazioneRef
		{
			get { return _IdComunicazioneRef; }
			set {
				if (IdComunicazioneRef != value)
				{
					_IdComunicazioneRef = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OGGETTO
		/// Tipo sul db:VARCHAR(250)
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
		/// Tipo sul db:CHAR(3)
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(250)
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
		/// Corrisponde al campo:SEGNATURA_ESTERNA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT SegnaturaEsterna
		{
			get { return _SegnaturaEsterna; }
			set {
				if (SegnaturaEsterna != value)
				{
					_SegnaturaEsterna = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IN_ENTRATA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InEntrata
		{
			get { return _InEntrata; }
			set {
				if (InEntrata != value)
				{
					_InEntrata = value;
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
		/// Corrisponde al campo:TESTO_NOTE
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT TestoNote
		{
			get { return _TestoNote; }
			set {
				if (TestoNote != value)
				{
					_TestoNote = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PREDISPOSTA_ALLA_FIRMA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PredispostaAllaFirma
		{
			get { return _PredispostaAllaFirma; }
			set {
				if (PredispostaAllaFirma != value)
				{
					_PredispostaAllaFirma = value;
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
	/// Summary description for ProgettoComunicazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoComunicazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoComunicazione) info.GetValue(i.ToString(),typeof(ProgettoComunicazione)));
			}
		}

		//Costruttore
		public ProgettoComunicazioneCollection()
		{
			this.ItemType = typeof(ProgettoComunicazione);
		}

		//Costruttore con provider
		public ProgettoComunicazioneCollection(IProgettoComunicazioneProvider providerObj)
		{
			this.ItemType = typeof(ProgettoComunicazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoComunicazione this[int index]
		{
			get { return (ProgettoComunicazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoComunicazioneCollection GetChanges()
		{
			return (ProgettoComunicazioneCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoComunicazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoComunicazioneProvider Provider
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
		public int Add(ProgettoComunicazione ProgettoComunicazioneObj)
		{
			if (ProgettoComunicazioneObj.Provider == null) ProgettoComunicazioneObj.Provider = this.Provider;
			return base.Add(ProgettoComunicazioneObj);
		}

		//AddCollection
		public void AddCollection(ProgettoComunicazioneCollection ProgettoComunicazioneCollectionObj)
		{
			foreach (ProgettoComunicazione ProgettoComunicazioneObj in ProgettoComunicazioneCollectionObj)
				this.Add(ProgettoComunicazioneObj);
		}

		//Insert
		public void Insert(int index, ProgettoComunicazione ProgettoComunicazioneObj)
		{
			if (ProgettoComunicazioneObj.Provider == null) ProgettoComunicazioneObj.Provider = this.Provider;
			base.Insert(index, ProgettoComunicazioneObj);
		}

		//CollectionGetById
		public ProgettoComunicazione CollectionGetById(NullTypes.IntNT IdComunicazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdComunicazione == IdComunicazioneValue))
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
		public ProgettoComunicazioneCollection SubSelect(NullTypes.IntNT IdComunicazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdComunicazioneRefEqualThis, 
NullTypes.StringNT OggettoEqualThis, NullTypes.StringNT TestoEqualThis, NullTypes.StringNT CodTipoEqualThis, 
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.BoolNT PredispostaAllaFirmaEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT SegnaturaEsternaEqualThis, 
NullTypes.BoolNT InEntrataEqualThis, NullTypes.IntNT IdNoteEqualThis)
		{
			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionTemp = new ProgettoComunicazioneCollection();
			foreach (ProgettoComunicazione ProgettoComunicazioneItem in this)
			{
				if (((IdComunicazioneEqualThis == null) || ((ProgettoComunicazioneItem.IdComunicazione != null) && (ProgettoComunicazioneItem.IdComunicazione.Value == IdComunicazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoComunicazioneItem.IdProgetto != null) && (ProgettoComunicazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdComunicazioneRefEqualThis == null) || ((ProgettoComunicazioneItem.IdComunicazioneRef != null) && (ProgettoComunicazioneItem.IdComunicazioneRef.Value == IdComunicazioneRefEqualThis.Value))) && 
((OggettoEqualThis == null) || ((ProgettoComunicazioneItem.Oggetto != null) && (ProgettoComunicazioneItem.Oggetto.Value == OggettoEqualThis.Value))) && ((TestoEqualThis == null) || ((ProgettoComunicazioneItem.Testo != null) && (ProgettoComunicazioneItem.Testo.Value == TestoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ProgettoComunicazioneItem.CodTipo != null) && (ProgettoComunicazioneItem.CodTipo.Value == CodTipoEqualThis.Value))) && 
((DataInserimentoEqualThis == null) || ((ProgettoComunicazioneItem.DataInserimento != null) && (ProgettoComunicazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((ProgettoComunicazioneItem.DataModifica != null) && (ProgettoComunicazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoComunicazioneItem.Operatore != null) && (ProgettoComunicazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((PredispostaAllaFirmaEqualThis == null) || ((ProgettoComunicazioneItem.PredispostaAllaFirma != null) && (ProgettoComunicazioneItem.PredispostaAllaFirma.Value == PredispostaAllaFirmaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoComunicazioneItem.Segnatura != null) && (ProgettoComunicazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaEsternaEqualThis == null) || ((ProgettoComunicazioneItem.SegnaturaEsterna != null) && (ProgettoComunicazioneItem.SegnaturaEsterna.Value == SegnaturaEsternaEqualThis.Value))) && 
((InEntrataEqualThis == null) || ((ProgettoComunicazioneItem.InEntrata != null) && (ProgettoComunicazioneItem.InEntrata.Value == InEntrataEqualThis.Value))) && ((IdNoteEqualThis == null) || ((ProgettoComunicazioneItem.IdNote != null) && (ProgettoComunicazioneItem.IdNote.Value == IdNoteEqualThis.Value))))
				{
					ProgettoComunicazioneCollectionTemp.Add(ProgettoComunicazioneItem);
				}
			}
			return ProgettoComunicazioneCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoComunicazioneCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT OperatoreEqualThis, 
NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT SegnaturaEsternaEqualThis, NullTypes.BoolNT InEntrataEqualThis)
		{
			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionTemp = new ProgettoComunicazioneCollection();
			foreach (ProgettoComunicazione ProgettoComunicazioneItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((ProgettoComunicazioneItem.IdProgetto != null) && (ProgettoComunicazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ProgettoComunicazioneItem.CodTipo != null) && (ProgettoComunicazioneItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoComunicazioneItem.Operatore != null) && (ProgettoComunicazioneItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((SegnaturaEqualThis == null) || ((ProgettoComunicazioneItem.Segnatura != null) && (ProgettoComunicazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((SegnaturaEsternaEqualThis == null) || ((ProgettoComunicazioneItem.SegnaturaEsterna != null) && (ProgettoComunicazioneItem.SegnaturaEsterna.Value == SegnaturaEsternaEqualThis.Value))) && ((InEntrataEqualThis == null) || ((ProgettoComunicazioneItem.InEntrata != null) && (ProgettoComunicazioneItem.InEntrata.Value == InEntrataEqualThis.Value))))
				{
					ProgettoComunicazioneCollectionTemp.Add(ProgettoComunicazioneItem);
				}
			}
			return ProgettoComunicazioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoComunicazioneDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoComunicazione ProgettoComunicazioneObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazione", ProgettoComunicazioneObj.IdComunicazione);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoComunicazioneObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdComunicazioneRef", ProgettoComunicazioneObj.IdComunicazioneRef);
			DbProvider.SetCmdParam(cmd,firstChar + "Oggetto", ProgettoComunicazioneObj.Oggetto);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", ProgettoComunicazioneObj.Testo);
			DbProvider.SetCmdParam(cmd,firstChar + "CodTipo", ProgettoComunicazioneObj.CodTipo);
			DbProvider.SetCmdParam(cmd,firstChar + "DataInserimento", ProgettoComunicazioneObj.DataInserimento);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", ProgettoComunicazioneObj.DataModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoComunicazioneObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoComunicazioneObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaEsterna", ProgettoComunicazioneObj.SegnaturaEsterna);
			DbProvider.SetCmdParam(cmd,firstChar + "InEntrata", ProgettoComunicazioneObj.InEntrata);
			DbProvider.SetCmdParam(cmd,firstChar + "IdNote", ProgettoComunicazioneObj.IdNote);
			DbProvider.SetCmdParam(cmd,firstChar + "PredispostaAllaFirma", ProgettoComunicazioneObj.PredispostaAllaFirma);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoComunicazione ProgettoComunicazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioneInsert", new string[] {"IdProgetto", "IdComunicazioneRef", 
"Oggetto", "Testo", "CodTipo", 
"DataInserimento", "DataModifica", 
"Operatore", "Segnatura", "SegnaturaEsterna", 
"InEntrata", "IdNote", 
"PredispostaAllaFirma"}, new string[] {"int", "int", 
"string", "string", "string", 
"DateTime", "DateTime", 
"int", "string", "bool", 
"bool", "int", 
"bool"},"");
				CompileIUCmd(false, insertCmd,ProgettoComunicazioneObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoComunicazioneObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
				ProgettoComunicazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
				ProgettoComunicazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
				}
				ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneObj.IsDirty = false;
				ProgettoComunicazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoComunicazione ProgettoComunicazioneObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioneUpdate", new string[] {"IdComunicazione", "IdProgetto", "IdComunicazioneRef", 
"Oggetto", "Testo", "CodTipo", 
"DataInserimento", "DataModifica", 
"Operatore", "Segnatura", "SegnaturaEsterna", 
"InEntrata", "IdNote", 
"PredispostaAllaFirma"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"DateTime", "DateTime", 
"int", "string", "bool", 
"bool", "int", 
"bool"},"");
				CompileIUCmd(true, updateCmd,ProgettoComunicazioneObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneObj.IsDirty = false;
				ProgettoComunicazioneObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoComunicazione ProgettoComunicazioneObj)
		{
			switch (ProgettoComunicazioneObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoComunicazioneObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoComunicazioneObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoComunicazioneObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoComunicazioneCollection ProgettoComunicazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoComunicazioneUpdate", new string[] {"IdComunicazione", "IdProgetto", "IdComunicazioneRef", 
"Oggetto", "Testo", "CodTipo", 
"DataInserimento", "DataModifica", 
"Operatore", "Segnatura", "SegnaturaEsterna", 
"InEntrata", "IdNote", 
"PredispostaAllaFirma"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"DateTime", "DateTime", 
"int", "string", "bool", 
"bool", "int", 
"bool"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoComunicazioneInsert", new string[] {"IdProgetto", "IdComunicazioneRef", 
"Oggetto", "Testo", "CodTipo", 
"DataInserimento", "DataModifica", 
"Operatore", "Segnatura", "SegnaturaEsterna", 
"InEntrata", "IdNote", 
"PredispostaAllaFirma"}, new string[] {"int", "int", 
"string", "string", "string", 
"DateTime", "DateTime", 
"int", "string", "bool", 
"bool", "int", 
"bool"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneDelete", new string[] {"IdComunicazione"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioneCollectionObj.Count; i++)
				{
					switch (ProgettoComunicazioneCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoComunicazioneCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoComunicazioneCollectionObj[i].IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
									ProgettoComunicazioneCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									ProgettoComunicazioneCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoComunicazioneCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoComunicazioneCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComunicazione", (SiarLibrary.NullTypes.IntNT)ProgettoComunicazioneCollectionObj[i].IdComunicazione);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioneCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoComunicazioneCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoComunicazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoComunicazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioneCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoComunicazione ProgettoComunicazioneObj)
		{
			int returnValue = 0;
			if (ProgettoComunicazioneObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoComunicazioneObj.IdComunicazione);
			}
			ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoComunicazioneObj.IsDirty = false;
			ProgettoComunicazioneObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdComunicazioneValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneDelete", new string[] {"IdComunicazione"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComunicazione", (SiarLibrary.NullTypes.IntNT)IdComunicazioneValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoComunicazioneCollection ProgettoComunicazioneCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoComunicazioneDelete", new string[] {"IdComunicazione"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoComunicazioneCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdComunicazione", ProgettoComunicazioneCollectionObj[i].IdComunicazione);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoComunicazioneCollectionObj.Count; i++)
				{
					if ((ProgettoComunicazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoComunicazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoComunicazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoComunicazioneCollectionObj[i].IsDirty = false;
						ProgettoComunicazioneCollectionObj[i].IsPersistent = false;
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
		public static ProgettoComunicazione GetById(DbProvider db, int IdComunicazioneValue)
		{
			ProgettoComunicazione ProgettoComunicazioneObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoComunicazioneGetById", new string[] {"IdComunicazione"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdComunicazione", (SiarLibrary.NullTypes.IntNT)IdComunicazioneValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoComunicazioneObj = GetFromDatareader(db);
				ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneObj.IsDirty = false;
				ProgettoComunicazioneObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoComunicazioneObj;
		}

		//getFromDatareader
		public static ProgettoComunicazione GetFromDatareader(DbProvider db)
		{
			ProgettoComunicazione ProgettoComunicazioneObj = new ProgettoComunicazione();
			ProgettoComunicazioneObj.IdComunicazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE"]);
			ProgettoComunicazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoComunicazioneObj.IdComunicazioneRef = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNICAZIONE_REF"]);
			ProgettoComunicazioneObj.Oggetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["OGGETTO"]);
			ProgettoComunicazioneObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			ProgettoComunicazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			ProgettoComunicazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			ProgettoComunicazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			ProgettoComunicazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			ProgettoComunicazioneObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoComunicazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoComunicazioneObj.SegnaturaEsterna = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SEGNATURA_ESTERNA"]);
			ProgettoComunicazioneObj.InEntrata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_ENTRATA"]);
			ProgettoComunicazioneObj.IdNote = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_NOTE"]);
			ProgettoComunicazioneObj.TestoNote = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO_NOTE"]);
			ProgettoComunicazioneObj.PredispostaAllaFirma = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PREDISPOSTA_ALLA_FIRMA"]);
			ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoComunicazioneObj.IsDirty = false;
			ProgettoComunicazioneObj.IsPersistent = true;
			return ProgettoComunicazioneObj;
		}

		//Find Select

		public static ProgettoComunicazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdComunicazioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdComunicazioneRefEqualThis, 
SiarLibrary.NullTypes.StringNT OggettoEqualThis, SiarLibrary.NullTypes.StringNT TestoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT PredispostaAllaFirmaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT SegnaturaEsternaEqualThis, 
SiarLibrary.NullTypes.BoolNT InEntrataEqualThis, SiarLibrary.NullTypes.IntNT IdNoteEqualThis)

		{

			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionObj = new ProgettoComunicazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionefindselect", new string[] {"IdComunicazioneequalthis", "IdProgettoequalthis", "IdComunicazioneRefequalthis", 
"Oggettoequalthis", "Testoequalthis", "CodTipoequalthis", 
"DataInserimentoequalthis", "DataModificaequalthis", "Operatoreequalthis", 
"PredispostaAllaFirmaequalthis", "Segnaturaequalthis", "SegnaturaEsternaequalthis", 
"InEntrataequalthis", "IdNoteequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"DateTime", "DateTime", "int", 
"bool", "string", "bool", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneequalthis", IdComunicazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdComunicazioneRefequalthis", IdComunicazioneRefEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Oggettoequalthis", OggettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PredispostaAllaFirmaequalthis", PredispostaAllaFirmaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaEsternaequalthis", SegnaturaEsternaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InEntrataequalthis", InEntrataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdNoteequalthis", IdNoteEqualThis);
			ProgettoComunicazione ProgettoComunicazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioneObj = GetFromDatareader(db);
				ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneObj.IsDirty = false;
				ProgettoComunicazioneObj.IsPersistent = true;
				ProgettoComunicazioneCollectionObj.Add(ProgettoComunicazioneObj);
			}
			db.Close();
			return ProgettoComunicazioneCollectionObj;
		}

		//Find Find

		public static ProgettoComunicazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.BoolNT SegnaturaEsternaEqualThis, SiarLibrary.NullTypes.BoolNT InEntrataEqualThis)

		{

			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionObj = new ProgettoComunicazioneCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettocomunicazionefindfind", new string[] {"IdProgettoequalthis", "CodTipoequalthis", "Operatoreequalthis", 
"Segnaturaequalthis", "SegnaturaEsternaequalthis", "InEntrataequalthis"}, new string[] {"int", "string", "int", 
"string", "bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaEsternaequalthis", SegnaturaEsternaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "InEntrataequalthis", InEntrataEqualThis);
			ProgettoComunicazione ProgettoComunicazioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoComunicazioneObj = GetFromDatareader(db);
				ProgettoComunicazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoComunicazioneObj.IsDirty = false;
				ProgettoComunicazioneObj.IsPersistent = true;
				ProgettoComunicazioneCollectionObj.Add(ProgettoComunicazioneObj);
			}
			db.Close();
			return ProgettoComunicazioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoComunicazioneCollectionProvider:IProgettoComunicazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoComunicazioneCollectionProvider : IProgettoComunicazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoComunicazione
		protected ProgettoComunicazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoComunicazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoComunicazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoComunicazioneCollectionProvider(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, IntNT OperatoreEqualThis, 
StringNT SegnaturaEqualThis, BoolNT SegnaturaesternaEqualThis, BoolNT InentrataEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, CodtipoEqualThis, OperatoreEqualThis, 
SegnaturaEqualThis, SegnaturaesternaEqualThis, InentrataEqualThis);
		}

		//Costruttore3: ha in input progettocomunicazioneCollectionObj - non popola la collection
		public ProgettoComunicazioneCollectionProvider(ProgettoComunicazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoComunicazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoComunicazioneCollection(this);
		}

		//Get e Set
		public ProgettoComunicazioneCollection CollectionObj
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
		public int SaveCollection(ProgettoComunicazioneCollection collectionObj)
		{
			return ProgettoComunicazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoComunicazione progettocomunicazioneObj)
		{
			return ProgettoComunicazioneDAL.Save(_dbProviderObj, progettocomunicazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoComunicazioneCollection collectionObj)
		{
			return ProgettoComunicazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoComunicazione progettocomunicazioneObj)
		{
			return ProgettoComunicazioneDAL.Delete(_dbProviderObj, progettocomunicazioneObj);
		}

		//getById
		public ProgettoComunicazione GetById(IntNT IdComunicazioneValue)
		{
			ProgettoComunicazione ProgettoComunicazioneTemp = ProgettoComunicazioneDAL.GetById(_dbProviderObj, IdComunicazioneValue);
			if (ProgettoComunicazioneTemp!=null) ProgettoComunicazioneTemp.Provider = this;
			return ProgettoComunicazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoComunicazioneCollection Select(IntNT IdcomunicazioneEqualThis, IntNT IdprogettoEqualThis, IntNT IdcomunicazionerefEqualThis, 
StringNT OggettoEqualThis, StringNT TestoEqualThis, StringNT CodtipoEqualThis, 
DatetimeNT DatainserimentoEqualThis, DatetimeNT DatamodificaEqualThis, IntNT OperatoreEqualThis, 
BoolNT PredispostaallafirmaEqualThis, StringNT SegnaturaEqualThis, BoolNT SegnaturaesternaEqualThis, 
BoolNT InentrataEqualThis, IntNT IdnoteEqualThis)
		{
			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionTemp = ProgettoComunicazioneDAL.Select(_dbProviderObj, IdcomunicazioneEqualThis, IdprogettoEqualThis, IdcomunicazionerefEqualThis, 
OggettoEqualThis, TestoEqualThis, CodtipoEqualThis, 
DatainserimentoEqualThis, DatamodificaEqualThis, OperatoreEqualThis, 
PredispostaallafirmaEqualThis, SegnaturaEqualThis, SegnaturaesternaEqualThis, 
InentrataEqualThis, IdnoteEqualThis);
			ProgettoComunicazioneCollectionTemp.Provider = this;
			return ProgettoComunicazioneCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoComunicazioneCollection Find(IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis, IntNT OperatoreEqualThis, 
StringNT SegnaturaEqualThis, BoolNT SegnaturaesternaEqualThis, BoolNT InentrataEqualThis)
		{
			ProgettoComunicazioneCollection ProgettoComunicazioneCollectionTemp = ProgettoComunicazioneDAL.Find(_dbProviderObj, IdprogettoEqualThis, CodtipoEqualThis, OperatoreEqualThis, 
SegnaturaEqualThis, SegnaturaesternaEqualThis, InentrataEqualThis);
			ProgettoComunicazioneCollectionTemp.Provider = this;
			return ProgettoComunicazioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_COMUNICAZIONE>
  <ViewName>vPROGETTO_COMUNICAZIONE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <SEGNATURA_ESTERNA>Equal</SEGNATURA_ESTERNA>
      <IN_ENTRATA>Equal</IN_ENTRATA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <SEGNATURA_ESTERNA>Equal</SEGNATURA_ESTERNA>
      <IN_ENTRATA>Equal</IN_ENTRATA>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_COMUNICAZIONE>
*/
