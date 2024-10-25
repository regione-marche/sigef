using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZprogFa
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZprogFaProvider
	{
		int Save(ZprogFa ZprogFaObj);
		int SaveCollection(ZprogFaCollection collectionObj);
		int Delete(ZprogFa ZprogFaObj);
		int DeleteCollection(ZprogFaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZprogFa
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZprogFa: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgrammazione;
		private NullTypes.StringNT _CodFa;
		private NullTypes.StringNT _TipoContributo;
		private NullTypes.DecimalNT _DotFinanziaria;
		private NullTypes.StringNT _CodPsr;
		private NullTypes.StringNT _FaDescrizione;
		private NullTypes.DecimalNT _FaDotFinanziaria;
		private NullTypes.BoolNT _Trasversale;
		private NullTypes.StringNT _ProgCodTipo;
		private NullTypes.StringNT _ProgCodice;
		private NullTypes.StringNT _ProgDescrizione;
		private NullTypes.IntNT _IdPadre;
		private NullTypes.StringNT _ProgTipo;
		private NullTypes.IntNT _Livello;
		private NullTypes.BoolNT _AttivazioneBandi;
		private NullTypes.BoolNT _AttivazioneFa;
		private NullTypes.BoolNT _AttivazioneObMisura;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _CfUtente;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		[NonSerialized] private IZprogFaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZprogFaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZprogFa()
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
		/// Corrisponde al campo:ID_PROGRAMMAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgrammazione
		{
			get { return _IdProgrammazione; }
			set {
				if (IdProgrammazione != value)
				{
					_IdProgrammazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FA
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodFa
		{
			get { return _CodFa; }
			set {
				if (CodFa != value)
				{
					_CodFa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_CONTRIBUTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT TipoContributo
		{
			get { return _TipoContributo; }
			set {
				if (TipoContributo != value)
				{
					_TipoContributo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DOT_FINANZIARIA
		/// Tipo sul db:DECIMAL(18,2)
		/// Default:((0))
		/// </summary>
		public NullTypes.DecimalNT DotFinanziaria
		{
			get { return _DotFinanziaria; }
			set {
				if (DotFinanziaria != value)
				{
					_DotFinanziaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_PSR
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodPsr
		{
			get { return _CodPsr; }
			set {
				if (CodPsr != value)
				{
					_CodPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FA_DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT FaDescrizione
		{
			get { return _FaDescrizione; }
			set {
				if (FaDescrizione != value)
				{
					_FaDescrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FA_DOT_FINANZIARIA
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT FaDotFinanziaria
		{
			get { return _FaDotFinanziaria; }
			set {
				if (FaDotFinanziaria != value)
				{
					_FaDotFinanziaria = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TRASVERSALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Trasversale
		{
			get { return _Trasversale; }
			set {
				if (Trasversale != value)
				{
					_Trasversale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROG_COD_TIPO
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT ProgCodTipo
		{
			get { return _ProgCodTipo; }
			set {
				if (ProgCodTipo != value)
				{
					_ProgCodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROG_CODICE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT ProgCodice
		{
			get { return _ProgCodice; }
			set {
				if (ProgCodice != value)
				{
					_ProgCodice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROG_DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT ProgDescrizione
		{
			get { return _ProgDescrizione; }
			set {
				if (ProgDescrizione != value)
				{
					_ProgDescrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPadre
		{
			get { return _IdPadre; }
			set {
				if (IdPadre != value)
				{
					_IdPadre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROG_TIPO
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT ProgTipo
		{
			get { return _ProgTipo; }
			set {
				if (ProgTipo != value)
				{
					_ProgTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Livello
		{
			get { return _Livello; }
			set {
				if (Livello != value)
				{
					_Livello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_BANDI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AttivazioneBandi
		{
			get { return _AttivazioneBandi; }
			set {
				if (AttivazioneBandi != value)
				{
					_AttivazioneBandi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_FA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AttivazioneFa
		{
			get { return _AttivazioneFa; }
			set {
				if (AttivazioneFa != value)
				{
					_AttivazioneFa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVAZIONE_OB_MISURA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AttivazioneObMisura
		{
			get { return _AttivazioneObMisura; }
			set {
				if (AttivazioneObMisura != value)
				{
					_AttivazioneObMisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// Default:((0))
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

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
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
		/// Corrisponde al campo:CF_UTENTE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfUtente
		{
			get { return _CfUtente; }
			set {
				if (CfUtente != value)
				{
					_CfUtente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NOMINATIVO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Nominativo
		{
			get { return _Nominativo; }
			set {
				if (Nominativo != value)
				{
					_Nominativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
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
	/// Summary description for ZprogFaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZprogFaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZprogFaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZprogFa) info.GetValue(i.ToString(),typeof(ZprogFa)));
			}
		}

		//Costruttore
		public ZprogFaCollection()
		{
			this.ItemType = typeof(ZprogFa);
		}

		//Costruttore con provider
		public ZprogFaCollection(IZprogFaProvider providerObj)
		{
			this.ItemType = typeof(ZprogFa);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZprogFa this[int index]
		{
			get { return (ZprogFa)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZprogFaCollection GetChanges()
		{
			return (ZprogFaCollection) base.GetChanges();
		}

		[NonSerialized] private IZprogFaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZprogFaProvider Provider
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
		public int Add(ZprogFa ZprogFaObj)
		{
			if (ZprogFaObj.Provider == null) ZprogFaObj.Provider = this.Provider;
			return base.Add(ZprogFaObj);
		}

		//AddCollection
		public void AddCollection(ZprogFaCollection ZprogFaCollectionObj)
		{
			foreach (ZprogFa ZprogFaObj in ZprogFaCollectionObj)
				this.Add(ZprogFaObj);
		}

		//Insert
		public void Insert(int index, ZprogFa ZprogFaObj)
		{
			if (ZprogFaObj.Provider == null) ZprogFaObj.Provider = this.Provider;
			base.Insert(index, ZprogFaObj);
		}

		//CollectionGetById
		public ZprogFa CollectionGetById(NullTypes.IntNT IdValue)
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
		public ZprogFaCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.StringNT CodFaEqualThis, 
NullTypes.StringNT TipoContributoEqualThis, NullTypes.DecimalNT DotFinanziariaEqualThis, NullTypes.BoolNT AttivoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis)
		{
			ZprogFaCollection ZprogFaCollectionTemp = new ZprogFaCollection();
			foreach (ZprogFa ZprogFaItem in this)
			{
				if (((IdEqualThis == null) || ((ZprogFaItem.Id != null) && (ZprogFaItem.Id.Value == IdEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((ZprogFaItem.IdProgrammazione != null) && (ZprogFaItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((CodFaEqualThis == null) || ((ZprogFaItem.CodFa != null) && (ZprogFaItem.CodFa.Value == CodFaEqualThis.Value))) && 
((TipoContributoEqualThis == null) || ((ZprogFaItem.TipoContributo != null) && (ZprogFaItem.TipoContributo.Value == TipoContributoEqualThis.Value))) && ((DotFinanziariaEqualThis == null) || ((ZprogFaItem.DotFinanziaria != null) && (ZprogFaItem.DotFinanziaria.Value == DotFinanziariaEqualThis.Value))) && ((AttivoEqualThis == null) || ((ZprogFaItem.Attivo != null) && (ZprogFaItem.Attivo.Value == AttivoEqualThis.Value))) && 
((DataEqualThis == null) || ((ZprogFaItem.Data != null) && (ZprogFaItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ZprogFaItem.Operatore != null) && (ZprogFaItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					ZprogFaCollectionTemp.Add(ZprogFaItem);
				}
			}
			return ZprogFaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZprogFaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZprogFaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZprogFa ZprogFaObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ZprogFaObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgrammazione", ZprogFaObj.IdProgrammazione);
			DbProvider.SetCmdParam(cmd,firstChar + "CodFa", ZprogFaObj.CodFa);
			DbProvider.SetCmdParam(cmd,firstChar + "TipoContributo", ZprogFaObj.TipoContributo);
			DbProvider.SetCmdParam(cmd,firstChar + "DotFinanziaria", ZprogFaObj.DotFinanziaria);
			DbProvider.SetCmdParam(cmd,firstChar + "Attivo", ZprogFaObj.Attivo);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ZprogFaObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ZprogFaObj.Operatore);
		}
		//Insert
		private static int Insert(DbProvider db, ZprogFa ZprogFaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZprogFaInsert", new string[] {"IdProgrammazione", "CodFa", 
"TipoContributo", "DotFinanziaria", 




"Attivo", "Data", "Operatore", }, new string[] {"int", "string", 
"string", "decimal", 




"bool", "DateTime", "int", },"");
				CompileIUCmd(false, insertCmd,ZprogFaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZprogFaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ZprogFaObj.DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
				ZprogFaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
				}
				ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogFaObj.IsDirty = false;
				ZprogFaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZprogFa ZprogFaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZprogFaUpdate", new string[] {"Id", "IdProgrammazione", "CodFa", 
"TipoContributo", "DotFinanziaria", 




"Attivo", "Data", "Operatore", }, new string[] {"int", "int", "string", 
"string", "decimal", 




"bool", "DateTime", "int", },"");
				CompileIUCmd(true, updateCmd,ZprogFaObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogFaObj.IsDirty = false;
				ZprogFaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZprogFa ZprogFaObj)
		{
			switch (ZprogFaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZprogFaObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZprogFaObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZprogFaObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZprogFaCollection ZprogFaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZprogFaUpdate", new string[] {"Id", "IdProgrammazione", "CodFa", 
"TipoContributo", "DotFinanziaria", 




"Attivo", "Data", "Operatore", }, new string[] {"int", "int", "string", 
"string", "decimal", 




"bool", "DateTime", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZZprogFaInsert", new string[] {"IdProgrammazione", "CodFa", 
"TipoContributo", "DotFinanziaria", 




"Attivo", "Data", "Operatore", }, new string[] {"int", "string", 
"string", "decimal", 




"bool", "DateTime", "int", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZZprogFaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZprogFaCollectionObj.Count; i++)
				{
					switch (ZprogFaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZprogFaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZprogFaCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ZprogFaCollectionObj[i].DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
									ZprogFaCollectionObj[i].Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZprogFaCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZprogFaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZprogFaCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZprogFaCollectionObj.Count; i++)
				{
					if ((ZprogFaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogFaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZprogFaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZprogFaCollectionObj[i].IsDirty = false;
						ZprogFaCollectionObj[i].IsPersistent = true;
					}
					if ((ZprogFaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZprogFaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZprogFaCollectionObj[i].IsDirty = false;
						ZprogFaCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZprogFa ZprogFaObj)
		{
			int returnValue = 0;
			if (ZprogFaObj.IsPersistent) 
			{
				returnValue = Delete(db, ZprogFaObj.Id);
			}
			ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZprogFaObj.IsDirty = false;
			ZprogFaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZprogFaDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZprogFaCollection ZprogFaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZprogFaDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ZprogFaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ZprogFaCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZprogFaCollectionObj.Count; i++)
				{
					if ((ZprogFaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogFaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZprogFaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZprogFaCollectionObj[i].IsDirty = false;
						ZprogFaCollectionObj[i].IsPersistent = false;
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
		public static ZprogFa GetById(DbProvider db, int IdValue)
		{
			ZprogFa ZprogFaObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZprogFaGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZprogFaObj = GetFromDatareader(db);
				ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogFaObj.IsDirty = false;
				ZprogFaObj.IsPersistent = true;
			}
			db.Close();
			return ZprogFaObj;
		}

		//getFromDatareader
		public static ZprogFa GetFromDatareader(DbProvider db)
		{
			ZprogFa ZprogFaObj = new ZprogFa();
			ZprogFaObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ZprogFaObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
			ZprogFaObj.CodFa = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FA"]);
			ZprogFaObj.TipoContributo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_CONTRIBUTO"]);
			ZprogFaObj.DotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DOT_FINANZIARIA"]);
			ZprogFaObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			ZprogFaObj.FaDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["FA_DESCRIZIONE"]);
			ZprogFaObj.FaDotFinanziaria = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FA_DOT_FINANZIARIA"]);
			ZprogFaObj.Trasversale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TRASVERSALE"]);
			ZprogFaObj.ProgCodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROG_COD_TIPO"]);
			ZprogFaObj.ProgCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROG_CODICE"]);
			ZprogFaObj.ProgDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROG_DESCRIZIONE"]);
			ZprogFaObj.IdPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PADRE"]);
			ZprogFaObj.ProgTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROG_TIPO"]);
			ZprogFaObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
			ZprogFaObj.AttivazioneBandi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_BANDI"]);
			ZprogFaObj.AttivazioneFa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FA"]);
			ZprogFaObj.AttivazioneObMisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_OB_MISURA"]);
			ZprogFaObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			ZprogFaObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ZprogFaObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ZprogFaObj.CfUtente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_UTENTE"]);
			ZprogFaObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ZprogFaObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZprogFaObj.IsDirty = false;
			ZprogFaObj.IsPersistent = true;
			return ZprogFaObj;
		}

		//Find Select

		public static ZprogFaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodFaEqualThis, 
SiarLibrary.NullTypes.StringNT TipoContributoEqualThis, SiarLibrary.NullTypes.DecimalNT DotFinanziariaEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis)

		{

			ZprogFaCollection ZprogFaCollectionObj = new ZprogFaCollection();

			IDbCommand findCmd = db.InitCmd("Zzprogfafindselect", new string[] {"Idequalthis", "IdProgrammazioneequalthis", "CodFaequalthis", 
"TipoContributoequalthis", "DotFinanziariaequalthis", "Attivoequalthis", 
"Dataequalthis", "Operatoreequalthis"}, new string[] {"int", "int", "string", 
"string", "decimal", "bool", 
"DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaequalthis", CodFaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoContributoequalthis", TipoContributoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DotFinanziariaequalthis", DotFinanziariaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			ZprogFa ZprogFaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZprogFaObj = GetFromDatareader(db);
				ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogFaObj.IsDirty = false;
				ZprogFaObj.IsPersistent = true;
				ZprogFaCollectionObj.Add(ZprogFaObj);
			}
			db.Close();
			return ZprogFaCollectionObj;
		}

		//Find Find

		public static ZprogFaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.StringNT CodFaEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, 
SiarLibrary.NullTypes.BoolNT TrasversaleEqualThis, SiarLibrary.NullTypes.StringNT ProgCodTipoEqualThis, SiarLibrary.NullTypes.StringNT ProgCodiceEqualThis, 
SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneBandiEqualThis, SiarLibrary.NullTypes.BoolNT AttivazioneFaEqualThis, 
SiarLibrary.NullTypes.BoolNT AttivazioneObMisuraEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis)

		{

			ZprogFaCollection ZprogFaCollectionObj = new ZprogFaCollection();

			IDbCommand findCmd = db.InitCmd("Zzprogfafindfind", new string[] {"IdProgrammazioneequalthis", "CodFaequalthis", "CodPsrequalthis", 
"Trasversaleequalthis", "ProgCodTipoequalthis", "ProgCodiceequalthis", 
"Livelloequalthis", "AttivazioneBandiequalthis", "AttivazioneFaequalthis", 
"AttivazioneObMisuraequalthis", "Attivoequalthis"}, new string[] {"int", "string", "string", 
"bool", "string", "string", 
"int", "bool", "bool", 
"bool", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaequalthis", CodFaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Trasversaleequalthis", TrasversaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProgCodTipoequalthis", ProgCodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProgCodiceequalthis", ProgCodiceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneBandiequalthis", AttivazioneBandiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneFaequalthis", AttivazioneFaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "AttivazioneObMisuraequalthis", AttivazioneObMisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			ZprogFa ZprogFaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZprogFaObj = GetFromDatareader(db);
				ZprogFaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZprogFaObj.IsDirty = false;
				ZprogFaObj.IsPersistent = true;
				ZprogFaCollectionObj.Add(ZprogFaObj);
			}
			db.Close();
			return ZprogFaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZprogFaCollectionProvider:IZprogFaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZprogFaCollectionProvider : IZprogFaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZprogFa
		protected ZprogFaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZprogFaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZprogFaCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZprogFaCollectionProvider(IntNT IdprogrammazioneEqualThis, StringNT CodfaEqualThis, StringNT CodpsrEqualThis, 
BoolNT TrasversaleEqualThis, StringNT ProgcodtipoEqualThis, StringNT ProgcodiceEqualThis, 
IntNT LivelloEqualThis, BoolNT AttivazionebandiEqualThis, BoolNT AttivazionefaEqualThis, 
BoolNT AttivazioneobmisuraEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogrammazioneEqualThis, CodfaEqualThis, CodpsrEqualThis, 
TrasversaleEqualThis, ProgcodtipoEqualThis, ProgcodiceEqualThis, 
LivelloEqualThis, AttivazionebandiEqualThis, AttivazionefaEqualThis, 
AttivazioneobmisuraEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input zprogfaCollectionObj - non popola la collection
		public ZprogFaCollectionProvider(ZprogFaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZprogFaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZprogFaCollection(this);
		}

		//Get e Set
		public ZprogFaCollection CollectionObj
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
		public int SaveCollection(ZprogFaCollection collectionObj)
		{
			return ZprogFaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZprogFa zprogfaObj)
		{
			return ZprogFaDAL.Save(_dbProviderObj, zprogfaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZprogFaCollection collectionObj)
		{
			return ZprogFaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZprogFa zprogfaObj)
		{
			return ZprogFaDAL.Delete(_dbProviderObj, zprogfaObj);
		}

		//getById
		public ZprogFa GetById(IntNT IdValue)
		{
			ZprogFa ZprogFaTemp = ZprogFaDAL.GetById(_dbProviderObj, IdValue);
			if (ZprogFaTemp!=null) ZprogFaTemp.Provider = this;
			return ZprogFaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZprogFaCollection Select(IntNT IdEqualThis, IntNT IdprogrammazioneEqualThis, StringNT CodfaEqualThis, 
StringNT TipocontributoEqualThis, DecimalNT DotfinanziariaEqualThis, BoolNT AttivoEqualThis, 
DatetimeNT DataEqualThis, IntNT OperatoreEqualThis)
		{
			ZprogFaCollection ZprogFaCollectionTemp = ZprogFaDAL.Select(_dbProviderObj, IdEqualThis, IdprogrammazioneEqualThis, CodfaEqualThis, 
TipocontributoEqualThis, DotfinanziariaEqualThis, AttivoEqualThis, 
DataEqualThis, OperatoreEqualThis);
			ZprogFaCollectionTemp.Provider = this;
			return ZprogFaCollectionTemp;
		}

		//Find: popola la collection
		public ZprogFaCollection Find(IntNT IdprogrammazioneEqualThis, StringNT CodfaEqualThis, StringNT CodpsrEqualThis, 
BoolNT TrasversaleEqualThis, StringNT ProgcodtipoEqualThis, StringNT ProgcodiceEqualThis, 
IntNT LivelloEqualThis, BoolNT AttivazionebandiEqualThis, BoolNT AttivazionefaEqualThis, 
BoolNT AttivazioneobmisuraEqualThis, BoolNT AttivoEqualThis)
		{
			ZprogFaCollection ZprogFaCollectionTemp = ZprogFaDAL.Find(_dbProviderObj, IdprogrammazioneEqualThis, CodfaEqualThis, CodpsrEqualThis, 
TrasversaleEqualThis, ProgcodtipoEqualThis, ProgcodiceEqualThis, 
LivelloEqualThis, AttivazionebandiEqualThis, AttivazionefaEqualThis, 
AttivazioneobmisuraEqualThis, AttivoEqualThis);
			ZprogFaCollectionTemp.Provider = this;
			return ZprogFaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPROG_FA>
  <ViewName>vzPROG_FA</ViewName>
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
    <Find OrderBy="ORDER BY PROG_CODICE, COD_FA">
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <COD_FA>Equal</COD_FA>
      <COD_PSR>Equal</COD_PSR>
      <TRASVERSALE>Equal</TRASVERSALE>
      <PROG_COD_TIPO>Equal</PROG_COD_TIPO>
      <PROG_CODICE>Equal</PROG_CODICE>
      <LIVELLO>Equal</LIVELLO>
      <ATTIVAZIONE_BANDI>Equal</ATTIVAZIONE_BANDI>
      <ATTIVAZIONE_FA>Equal</ATTIVAZIONE_FA>
      <ATTIVAZIONE_OB_MISURA>Equal</ATTIVAZIONE_OB_MISURA>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPROG_FA>
*/
