using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per PistaControlloFem
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IPistaControlloFemProvider
	{
		int Save(PistaControlloFem PistaControlloFemObj);
		int SaveCollection(PistaControlloFemCollection collectionObj);
		int Delete(PistaControlloFem PistaControlloFemObj);
		int DeleteCollection(PistaControlloFemCollection collectionObj);
	}
	/// <summary>
	/// Summary description for PistaControlloFem
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class PistaControlloFem: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdPistaControllo;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdTipoPistaControllo;
		private NullTypes.StringNT _DescrizioneLiv2;
		private NullTypes.IntNT _LivelloLiv2;
		private NullTypes.IntNT _OrdineTipoPistaLiv2;
		private NullTypes.StringNT _DescrizioneLiv1;
		private NullTypes.IntNT _LivelloLiv1;
		private NullTypes.IntNT _OrdineTipoPistaLiv1;
		private NullTypes.IntNT _IdTipoPistaControlloVoce;
		private NullTypes.StringNT _DescrizioneVoce;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _Ordine;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Testo;
		private NullTypes.StringNT _Link;
		private NullTypes.IntNT _IdAtto;
		private NullTypes.IntNT _IdFile;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.IntNT _OperatoreModifica;
		private NullTypes.DatetimeNT _DataModifica;
		[NonSerialized] private IPistaControlloFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPistaControlloFemProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public PistaControlloFem()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PISTA_CONTROLLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPistaControllo
		{
			get { return _IdPistaControllo; }
			set {
				if (IdPistaControllo != value)
				{
					_IdPistaControllo = value;
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
		/// Corrisponde al campo:ID_TIPO_PISTA_CONTROLLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoPistaControllo
		{
			get { return _IdTipoPistaControllo; }
			set {
				if (IdTipoPistaControllo != value)
				{
					_IdTipoPistaControllo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_LIV2
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneLiv2
		{
			get { return _DescrizioneLiv2; }
			set {
				if (DescrizioneLiv2 != value)
				{
					_DescrizioneLiv2 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO_LIV2
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT LivelloLiv2
		{
			get { return _LivelloLiv2; }
			set {
				if (LivelloLiv2 != value)
				{
					_LivelloLiv2 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_TIPO_PISTA_LIV2
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineTipoPistaLiv2
		{
			get { return _OrdineTipoPistaLiv2; }
			set {
				if (OrdineTipoPistaLiv2 != value)
				{
					_OrdineTipoPistaLiv2 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_LIV1
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneLiv1
		{
			get { return _DescrizioneLiv1; }
			set {
				if (DescrizioneLiv1 != value)
				{
					_DescrizioneLiv1 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO_LIV1
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT LivelloLiv1
		{
			get { return _LivelloLiv1; }
			set {
				if (LivelloLiv1 != value)
				{
					_LivelloLiv1 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_TIPO_PISTA_LIV1
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineTipoPistaLiv1
		{
			get { return _OrdineTipoPistaLiv1; }
			set {
				if (OrdineTipoPistaLiv1 != value)
				{
					_OrdineTipoPistaLiv1 = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TIPO_PISTA_CONTROLLO_VOCE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTipoPistaControlloVoce
		{
			get { return _IdTipoPistaControlloVoce; }
			set {
				if (IdTipoPistaControlloVoce != value)
				{
					_IdTipoPistaControlloVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_VOCE
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT DescrizioneVoce
		{
			get { return _DescrizioneVoce; }
			set {
				if (DescrizioneVoce != value)
				{
					_DescrizioneVoce = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
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
		/// Corrisponde al campo:TESTO
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:LINK
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT Link
		{
			get { return _Link; }
			set {
				if (Link != value)
				{
					_Link = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ATTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAtto
		{
			get { return _IdAtto; }
			set {
				if (IdAtto != value)
				{
					_IdAtto = value;
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
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set {
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_CREAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreCreazione
		{
			get { return _OperatoreCreazione; }
			set {
				if (OperatoreCreazione != value)
				{
					_OperatoreCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_CREAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCreazione
		{
			get { return _DataCreazione; }
			set {
				if (DataCreazione != value)
				{
					_DataCreazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_MODIFICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreModifica
		{
			get { return _OperatoreModifica; }
			set {
				if (OperatoreModifica != value)
				{
					_OperatoreModifica = value;
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
	/// Summary description for PistaControlloFemCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PistaControlloFemCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PistaControlloFemCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PistaControlloFem) info.GetValue(i.ToString(),typeof(PistaControlloFem)));
			}
		}

		//Costruttore
		public PistaControlloFemCollection()
		{
			this.ItemType = typeof(PistaControlloFem);
		}

		//Costruttore con provider
		public PistaControlloFemCollection(IPistaControlloFemProvider providerObj)
		{
			this.ItemType = typeof(PistaControlloFem);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PistaControlloFem this[int index]
		{
			get { return (PistaControlloFem)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PistaControlloFemCollection GetChanges()
		{
			return (PistaControlloFemCollection) base.GetChanges();
		}

		[NonSerialized] private IPistaControlloFemProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPistaControlloFemProvider Provider
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
		public int Add(PistaControlloFem PistaControlloFemObj)
		{
			if (PistaControlloFemObj.Provider == null) PistaControlloFemObj.Provider = this.Provider;
			return base.Add(PistaControlloFemObj);
		}

		//AddCollection
		public void AddCollection(PistaControlloFemCollection PistaControlloFemCollectionObj)
		{
			foreach (PistaControlloFem PistaControlloFemObj in PistaControlloFemCollectionObj)
				this.Add(PistaControlloFemObj);
		}

		//Insert
		public void Insert(int index, PistaControlloFem PistaControlloFemObj)
		{
			if (PistaControlloFemObj.Provider == null) PistaControlloFemObj.Provider = this.Provider;
			base.Insert(index, PistaControlloFemObj);
		}

		//CollectionGetById
		public PistaControlloFem CollectionGetById(NullTypes.IntNT IdPistaControlloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPistaControllo == IdPistaControlloValue))
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
		public PistaControlloFemCollection SubSelect(NullTypes.IntNT IdPistaControlloEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdTipoPistaControlloEqualThis, 
NullTypes.IntNT IdTipoPistaControlloVoceEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT TestoEqualThis, NullTypes.StringNT LinkEqualThis, 
NullTypes.IntNT IdAttoEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT QuerySqlEqualThis, 
NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.IntNT OperatoreModificaEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			PistaControlloFemCollection PistaControlloFemCollectionTemp = new PistaControlloFemCollection();
			foreach (PistaControlloFem PistaControlloFemItem in this)
			{
				if (((IdPistaControlloEqualThis == null) || ((PistaControlloFemItem.IdPistaControllo != null) && (PistaControlloFemItem.IdPistaControllo.Value == IdPistaControlloEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((PistaControlloFemItem.IdProgetto != null) && (PistaControlloFemItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdTipoPistaControlloEqualThis == null) || ((PistaControlloFemItem.IdTipoPistaControllo != null) && (PistaControlloFemItem.IdTipoPistaControllo.Value == IdTipoPistaControlloEqualThis.Value))) && 
((IdTipoPistaControlloVoceEqualThis == null) || ((PistaControlloFemItem.IdTipoPistaControlloVoce != null) && (PistaControlloFemItem.IdTipoPistaControlloVoce.Value == IdTipoPistaControlloVoceEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((PistaControlloFemItem.Descrizione != null) && (PistaControlloFemItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((OrdineEqualThis == null) || ((PistaControlloFemItem.Ordine != null) && (PistaControlloFemItem.Ordine.Value == OrdineEqualThis.Value))) && 
((DataEqualThis == null) || ((PistaControlloFemItem.Data != null) && (PistaControlloFemItem.Data.Value == DataEqualThis.Value))) && ((TestoEqualThis == null) || ((PistaControlloFemItem.Testo != null) && (PistaControlloFemItem.Testo.Value == TestoEqualThis.Value))) && ((LinkEqualThis == null) || ((PistaControlloFemItem.Link != null) && (PistaControlloFemItem.Link.Value == LinkEqualThis.Value))) && 
((IdAttoEqualThis == null) || ((PistaControlloFemItem.IdAtto != null) && (PistaControlloFemItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((IdFileEqualThis == null) || ((PistaControlloFemItem.IdFile != null) && (PistaControlloFemItem.IdFile.Value == IdFileEqualThis.Value))) && ((QuerySqlEqualThis == null) || ((PistaControlloFemItem.QuerySql != null) && (PistaControlloFemItem.QuerySql.Value == QuerySqlEqualThis.Value))) && 
((OperatoreCreazioneEqualThis == null) || ((PistaControlloFemItem.OperatoreCreazione != null) && (PistaControlloFemItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((DataCreazioneEqualThis == null) || ((PistaControlloFemItem.DataCreazione != null) && (PistaControlloFemItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((PistaControlloFemItem.OperatoreModifica != null) && (PistaControlloFemItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((PistaControlloFemItem.DataModifica != null) && (PistaControlloFemItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					PistaControlloFemCollectionTemp.Add(PistaControlloFemItem);
				}
			}
			return PistaControlloFemCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for PistaControlloFemDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class PistaControlloFemDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PistaControlloFem PistaControlloFemObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdPistaControllo", PistaControlloFemObj.IdPistaControllo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", PistaControlloFemObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoPistaControllo", PistaControlloFemObj.IdTipoPistaControllo);
			DbProvider.SetCmdParam(cmd,firstChar + "IdTipoPistaControlloVoce", PistaControlloFemObj.IdTipoPistaControlloVoce);
			DbProvider.SetCmdParam(cmd,firstChar + "Descrizione", PistaControlloFemObj.Descrizione);
			DbProvider.SetCmdParam(cmd,firstChar + "Ordine", PistaControlloFemObj.Ordine);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", PistaControlloFemObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Testo", PistaControlloFemObj.Testo);
			DbProvider.SetCmdParam(cmd,firstChar + "Link", PistaControlloFemObj.Link);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", PistaControlloFemObj.IdAtto);
			DbProvider.SetCmdParam(cmd,firstChar + "IdFile", PistaControlloFemObj.IdFile);
			DbProvider.SetCmdParam(cmd,firstChar + "QuerySql", PistaControlloFemObj.QuerySql);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreCreazione", PistaControlloFemObj.OperatoreCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataCreazione", PistaControlloFemObj.DataCreazione);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreModifica", PistaControlloFemObj.OperatoreModifica);
			DbProvider.SetCmdParam(cmd,firstChar + "DataModifica", PistaControlloFemObj.DataModifica);
		}
		//Insert
		private static int Insert(DbProvider db, PistaControlloFem PistaControlloFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZPistaControlloFemInsert", new string[] {"IdProgetto", "IdTipoPistaControllo", 


"IdTipoPistaControlloVoce", "Descrizione", 
"Ordine", "Data", "Testo", 
"Link", "IdAtto", "IdFile", 
"QuerySql", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", 


"int", "string", 
"int", "DateTime", "string", 
"string", "int", "int", 
"string", "int", "DateTime", 
"int", "DateTime"},"");
				CompileIUCmd(false, insertCmd,PistaControlloFemObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				PistaControlloFemObj.IdPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PISTA_CONTROLLO"]);
				}
				PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PistaControlloFemObj.IsDirty = false;
				PistaControlloFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, PistaControlloFem PistaControlloFemObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPistaControlloFemUpdate", new string[] {"IdPistaControllo", "IdProgetto", "IdTipoPistaControllo", 


"IdTipoPistaControlloVoce", "Descrizione", 
"Ordine", "Data", "Testo", 
"Link", "IdAtto", "IdFile", 
"QuerySql", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int", 


"int", "string", 
"int", "DateTime", "string", 
"string", "int", "int", 
"string", "int", "DateTime", 
"int", "DateTime"},"");
				CompileIUCmd(true, updateCmd,PistaControlloFemObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d!=null)
				{
					i = 1;
					PistaControlloFemObj.DataModifica = d;
				}
				PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PistaControlloFemObj.IsDirty = false;
				PistaControlloFemObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, PistaControlloFem PistaControlloFemObj)
		{
			switch (PistaControlloFemObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, PistaControlloFemObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, PistaControlloFemObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,PistaControlloFemObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, PistaControlloFemCollection PistaControlloFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZPistaControlloFemUpdate", new string[] {"IdPistaControllo", "IdProgetto", "IdTipoPistaControllo", 


"IdTipoPistaControlloVoce", "Descrizione", 
"Ordine", "Data", "Testo", 
"Link", "IdAtto", "IdFile", 
"QuerySql", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", "int", 


"int", "string", 
"int", "DateTime", "string", 
"string", "int", "int", 
"string", "int", "DateTime", 
"int", "DateTime"},"");
				IDbCommand insertCmd = db.InitCmd( "ZPistaControlloFemInsert", new string[] {"IdProgetto", "IdTipoPistaControllo", 


"IdTipoPistaControlloVoce", "Descrizione", 
"Ordine", "Data", "Testo", 
"Link", "IdAtto", "IdFile", 
"QuerySql", "OperatoreCreazione", "DataCreazione", 
"OperatoreModifica", "DataModifica"}, new string[] {"int", "int", 


"int", "string", 
"int", "DateTime", "string", 
"string", "int", "int", 
"string", "int", "DateTime", 
"int", "DateTime"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZPistaControlloFemDelete", new string[] {"IdPistaControllo"}, new string[] {"int"},"");
				for (int i = 0; i < PistaControlloFemCollectionObj.Count; i++)
				{
					switch (PistaControlloFemCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,PistaControlloFemCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									PistaControlloFemCollectionObj[i].IdPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PISTA_CONTROLLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,PistaControlloFemCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d!=null)
								{
									returnValue++;
									PistaControlloFemCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (PistaControlloFemCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPistaControllo", (SiarLibrary.NullTypes.IntNT)PistaControlloFemCollectionObj[i].IdPistaControllo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < PistaControlloFemCollectionObj.Count; i++)
				{
					if ((PistaControlloFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PistaControlloFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PistaControlloFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						PistaControlloFemCollectionObj[i].IsDirty = false;
						PistaControlloFemCollectionObj[i].IsPersistent = true;
					}
					if ((PistaControlloFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						PistaControlloFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PistaControlloFemCollectionObj[i].IsDirty = false;
						PistaControlloFemCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, PistaControlloFem PistaControlloFemObj)
		{
			int returnValue = 0;
			if (PistaControlloFemObj.IsPersistent) 
			{
				returnValue = Delete(db, PistaControlloFemObj.IdPistaControllo);
			}
			PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			PistaControlloFemObj.IsDirty = false;
			PistaControlloFemObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdPistaControlloValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPistaControlloFemDelete", new string[] {"IdPistaControllo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPistaControllo", (SiarLibrary.NullTypes.IntNT)IdPistaControlloValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, PistaControlloFemCollection PistaControlloFemCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZPistaControlloFemDelete", new string[] {"IdPistaControllo"}, new string[] {"int"},"");
				for (int i = 0; i < PistaControlloFemCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdPistaControllo", PistaControlloFemCollectionObj[i].IdPistaControllo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < PistaControlloFemCollectionObj.Count; i++)
				{
					if ((PistaControlloFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PistaControlloFemCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						PistaControlloFemCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						PistaControlloFemCollectionObj[i].IsDirty = false;
						PistaControlloFemCollectionObj[i].IsPersistent = false;
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
		public static PistaControlloFem GetById(DbProvider db, int IdPistaControlloValue)
		{
			PistaControlloFem PistaControlloFemObj = null;
			IDbCommand readCmd = db.InitCmd( "ZPistaControlloFemGetById", new string[] {"IdPistaControllo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdPistaControllo", (SiarLibrary.NullTypes.IntNT)IdPistaControlloValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				PistaControlloFemObj = GetFromDatareader(db);
				PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PistaControlloFemObj.IsDirty = false;
				PistaControlloFemObj.IsPersistent = true;
			}
			db.Close();
			return PistaControlloFemObj;
		}

		//getFromDatareader
		public static PistaControlloFem GetFromDatareader(DbProvider db)
		{
			PistaControlloFem PistaControlloFemObj = new PistaControlloFem();
			PistaControlloFemObj.IdPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PISTA_CONTROLLO"]);
			PistaControlloFemObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			PistaControlloFemObj.IdTipoPistaControllo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PISTA_CONTROLLO"]);
			PistaControlloFemObj.DescrizioneLiv2 = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_LIV2"]);
			PistaControlloFemObj.LivelloLiv2 = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO_LIV2"]);
			PistaControlloFemObj.OrdineTipoPistaLiv2 = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_TIPO_PISTA_LIV2"]);
			PistaControlloFemObj.DescrizioneLiv1 = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_LIV1"]);
			PistaControlloFemObj.LivelloLiv1 = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO_LIV1"]);
			PistaControlloFemObj.OrdineTipoPistaLiv1 = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_TIPO_PISTA_LIV1"]);
			PistaControlloFemObj.IdTipoPistaControlloVoce = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TIPO_PISTA_CONTROLLO_VOCE"]);
			PistaControlloFemObj.DescrizioneVoce = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_VOCE"]);
			PistaControlloFemObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			PistaControlloFemObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			PistaControlloFemObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			PistaControlloFemObj.Testo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TESTO"]);
			PistaControlloFemObj.Link = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK"]);
			PistaControlloFemObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			PistaControlloFemObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
			PistaControlloFemObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			PistaControlloFemObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			PistaControlloFemObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			PistaControlloFemObj.OperatoreModifica = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_MODIFICA"]);
			PistaControlloFemObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			PistaControlloFemObj.IsDirty = false;
			PistaControlloFemObj.IsPersistent = true;
			return PistaControlloFemObj;
		}

		//Find Select

		public static PistaControlloFemCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPistaControlloEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdTipoPistaControlloEqualThis, 
SiarLibrary.NullTypes.IntNT IdTipoPistaControlloVoceEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.StringNT TestoEqualThis, SiarLibrary.NullTypes.StringNT LinkEqualThis, 
SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, 
SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.IntNT OperatoreModificaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis)

		{

			PistaControlloFemCollection PistaControlloFemCollectionObj = new PistaControlloFemCollection();

			IDbCommand findCmd = db.InitCmd("Zpistacontrollofemfindselect", new string[] {"IdPistaControlloequalthis", "IdProgettoequalthis", "IdTipoPistaControlloequalthis", 
"IdTipoPistaControlloVoceequalthis", "Descrizioneequalthis", "Ordineequalthis", 
"Dataequalthis", "Testoequalthis", "Linkequalthis", 
"IdAttoequalthis", "IdFileequalthis", "QuerySqlequalthis", 
"OperatoreCreazioneequalthis", "DataCreazioneequalthis", "OperatoreModificaequalthis", 
"DataModificaequalthis"}, new string[] {"int", "int", "int", 
"int", "string", "int", 
"DateTime", "string", "string", 
"int", "int", "string", 
"int", "DateTime", "int", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPistaControlloequalthis", IdPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloequalthis", IdTipoPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloVoceequalthis", IdTipoPistaControlloVoceEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Testoequalthis", TestoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Linkequalthis", LinkEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			PistaControlloFem PistaControlloFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PistaControlloFemObj = GetFromDatareader(db);
				PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PistaControlloFemObj.IsDirty = false;
				PistaControlloFemObj.IsPersistent = true;
				PistaControlloFemCollectionObj.Add(PistaControlloFemObj);
			}
			db.Close();
			return PistaControlloFemCollectionObj;
		}

		//Find Find

		public static PistaControlloFemCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPistaControlloEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdTipoPistaControlloEqualThis, 
SiarLibrary.NullTypes.IntNT IdTipoPistaControlloVoceEqualThis)

		{

			PistaControlloFemCollection PistaControlloFemCollectionObj = new PistaControlloFemCollection();

			IDbCommand findCmd = db.InitCmd("Zpistacontrollofemfindfind", new string[] {"IdPistaControlloequalthis", "IdProgettoequalthis", "IdTipoPistaControlloequalthis", 
"IdTipoPistaControlloVoceequalthis"}, new string[] {"int", "int", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdPistaControlloequalthis", IdPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloequalthis", IdTipoPistaControlloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTipoPistaControlloVoceequalthis", IdTipoPistaControlloVoceEqualThis);
			PistaControlloFem PistaControlloFemObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				PistaControlloFemObj = GetFromDatareader(db);
				PistaControlloFemObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				PistaControlloFemObj.IsDirty = false;
				PistaControlloFemObj.IsPersistent = true;
				PistaControlloFemCollectionObj.Add(PistaControlloFemObj);
			}
			db.Close();
			return PistaControlloFemCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for PistaControlloFemCollectionProvider:IPistaControlloFemProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class PistaControlloFemCollectionProvider : IPistaControlloFemProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PistaControlloFem
		protected PistaControlloFemCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PistaControlloFemCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PistaControlloFemCollection(this);
		}

		//Costruttore 2: popola la collection
		public PistaControlloFemCollectionProvider(IntNT IdpistacontrolloEqualThis, IntNT IdprogettoEqualThis, IntNT IdtipopistacontrolloEqualThis, 
IntNT IdtipopistacontrollovoceEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpistacontrolloEqualThis, IdprogettoEqualThis, IdtipopistacontrolloEqualThis, 
IdtipopistacontrollovoceEqualThis);
		}

		//Costruttore3: ha in input pistacontrollofemCollectionObj - non popola la collection
		public PistaControlloFemCollectionProvider(PistaControlloFemCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PistaControlloFemCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PistaControlloFemCollection(this);
		}

		//Get e Set
		public PistaControlloFemCollection CollectionObj
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
		public int SaveCollection(PistaControlloFemCollection collectionObj)
		{
			return PistaControlloFemDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PistaControlloFem pistacontrollofemObj)
		{
			return PistaControlloFemDAL.Save(_dbProviderObj, pistacontrollofemObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PistaControlloFemCollection collectionObj)
		{
			return PistaControlloFemDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PistaControlloFem pistacontrollofemObj)
		{
			return PistaControlloFemDAL.Delete(_dbProviderObj, pistacontrollofemObj);
		}

		//getById
		public PistaControlloFem GetById(IntNT IdPistaControlloValue)
		{
			PistaControlloFem PistaControlloFemTemp = PistaControlloFemDAL.GetById(_dbProviderObj, IdPistaControlloValue);
			if (PistaControlloFemTemp!=null) PistaControlloFemTemp.Provider = this;
			return PistaControlloFemTemp;
		}

		//Select: popola la collection
		public PistaControlloFemCollection Select(IntNT IdpistacontrolloEqualThis, IntNT IdprogettoEqualThis, IntNT IdtipopistacontrolloEqualThis, 
IntNT IdtipopistacontrollovoceEqualThis, StringNT DescrizioneEqualThis, IntNT OrdineEqualThis, 
DatetimeNT DataEqualThis, StringNT TestoEqualThis, StringNT LinkEqualThis, 
IntNT IdattoEqualThis, IntNT IdfileEqualThis, StringNT QuerysqlEqualThis, 
IntNT OperatorecreazioneEqualThis, DatetimeNT DatacreazioneEqualThis, IntNT OperatoremodificaEqualThis, 
DatetimeNT DatamodificaEqualThis)
		{
			PistaControlloFemCollection PistaControlloFemCollectionTemp = PistaControlloFemDAL.Select(_dbProviderObj, IdpistacontrolloEqualThis, IdprogettoEqualThis, IdtipopistacontrolloEqualThis, 
IdtipopistacontrollovoceEqualThis, DescrizioneEqualThis, OrdineEqualThis, 
DataEqualThis, TestoEqualThis, LinkEqualThis, 
IdattoEqualThis, IdfileEqualThis, QuerysqlEqualThis, 
OperatorecreazioneEqualThis, DatacreazioneEqualThis, OperatoremodificaEqualThis, 
DatamodificaEqualThis);
			PistaControlloFemCollectionTemp.Provider = this;
			return PistaControlloFemCollectionTemp;
		}

		//Find: popola la collection
		public PistaControlloFemCollection Find(IntNT IdpistacontrolloEqualThis, IntNT IdprogettoEqualThis, IntNT IdtipopistacontrolloEqualThis, 
IntNT IdtipopistacontrollovoceEqualThis)
		{
			PistaControlloFemCollection PistaControlloFemCollectionTemp = PistaControlloFemDAL.Find(_dbProviderObj, IdpistacontrolloEqualThis, IdprogettoEqualThis, IdtipopistacontrolloEqualThis, 
IdtipopistacontrollovoceEqualThis);
			PistaControlloFemCollectionTemp.Provider = this;
			return PistaControlloFemCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PISTA_CONTROLLO_FEM>
  <ViewName>vPISTA_CONTROLLO_FEM</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE_TIPO_PISTA_LIV1,ORDINE_TIPO_PISTA_LIV2,ORDINE">
      <ID_PISTA_CONTROLLO>Equal</ID_PISTA_CONTROLLO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_TIPO_PISTA_CONTROLLO>Equal</ID_TIPO_PISTA_CONTROLLO>
      <ID_TIPO_PISTA_CONTROLLO_VOCE>Equal</ID_TIPO_PISTA_CONTROLLO_VOCE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PISTA_CONTROLLO_FEM>
*/
