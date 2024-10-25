using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ProgettoStorico
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProgettoStoricoProvider
	{
		int Save(ProgettoStorico ProgettoStoricoObj);
		int SaveCollection(ProgettoStoricoCollection collectionObj);
		int Delete(ProgettoStorico ProgettoStoricoObj);
		int DeleteCollection(ProgettoStoricoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProgettoStorico
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ProgettoStorico: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _Id;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodStato;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.IntNT _Operatore;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.BoolNT _Revisione;
		private NullTypes.BoolNT _Riesame;
		private NullTypes.BoolNT _Ricorso;
		private NullTypes.BoolNT _RiaperturaProvinciale;
		private NullTypes.DatetimeNT _DataRi;
		private NullTypes.IntNT _OperatoreRi;
		private NullTypes.StringNT _SegnaturaRi;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _CodFase;
		private NullTypes.IntNT _OrdineStato;
		private NullTypes.StringNT _Fase;
		private NullTypes.IntNT _OrdineFase;
		private NullTypes.StringNT _Nominativo;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Provincia;
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _Profilo;
		private NullTypes.StringNT _Ente;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.IntNT _IdAtto;
		[NonSerialized] private IProgettoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoStoricoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProgettoStorico()
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
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
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
		/// Corrisponde al campo:REVISIONE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Revisione
		{
			get { return _Revisione; }
			set {
				if (Revisione != value)
				{
					_Revisione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIESAME
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Riesame
		{
			get { return _Riesame; }
			set {
				if (Riesame != value)
				{
					_Riesame = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RICORSO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Ricorso
		{
			get { return _Ricorso; }
			set {
				if (Ricorso != value)
				{
					_Ricorso = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIAPERTURA_PROVINCIALE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT RiaperturaProvinciale
		{
			get { return _RiaperturaProvinciale; }
			set {
				if (RiaperturaProvinciale != value)
				{
					_RiaperturaProvinciale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_RI
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataRi
		{
			get { return _DataRi; }
			set {
				if (DataRi != value)
				{
					_DataRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE_RI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OperatoreRi
		{
			get { return _OperatoreRi; }
			set {
				if (OperatoreRi != value)
				{
					_OperatoreRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_RI
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaRi
		{
			get { return _SegnaturaRi; }
			set {
				if (SegnaturaRi != value)
				{
					_SegnaturaRi = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_STATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineStato
		{
			get { return _OrdineStato; }
			set {
				if (OrdineStato != value)
				{
					_OrdineStato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Fase
		{
			get { return _Fase; }
			set {
				if (Fase != value)
				{
					_Fase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FASE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFase
		{
			get { return _OrdineFase; }
			set {
				if (OrdineFase != value)
				{
					_OrdineFase = value;
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

		/// <summary>
		/// Corrisponde al campo:PROVINCIA
		/// Tipo sul db:CHAR(2)
		/// </summary>
		public NullTypes.StringNT Provincia
		{
			get { return _Provincia; }
			set {
				if (Provincia != value)
				{
					_Provincia = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set {
				if (IdProfilo != value)
				{
					_IdProfilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PROFILO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Profilo
		{
			get { return _Profilo; }
			set {
				if (Profilo != value)
				{
					_Profilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ENTE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Ente
		{
			get { return _Ente; }
			set {
				if (Ente != value)
				{
					_Ente = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
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
	/// Summary description for ProgettoStoricoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoStoricoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoStoricoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoStorico) info.GetValue(i.ToString(),typeof(ProgettoStorico)));
			}
		}

		//Costruttore
		public ProgettoStoricoCollection()
		{
			this.ItemType = typeof(ProgettoStorico);
		}

		//Costruttore con provider
		public ProgettoStoricoCollection(IProgettoStoricoProvider providerObj)
		{
			this.ItemType = typeof(ProgettoStorico);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoStorico this[int index]
		{
			get { return (ProgettoStorico)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoStoricoCollection GetChanges()
		{
			return (ProgettoStoricoCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoStoricoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoStoricoProvider Provider
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
		public int Add(ProgettoStorico ProgettoStoricoObj)
		{
			if (ProgettoStoricoObj.Provider == null) ProgettoStoricoObj.Provider = this.Provider;
			return base.Add(ProgettoStoricoObj);
		}

		//AddCollection
		public void AddCollection(ProgettoStoricoCollection ProgettoStoricoCollectionObj)
		{
			foreach (ProgettoStorico ProgettoStoricoObj in ProgettoStoricoCollectionObj)
				this.Add(ProgettoStoricoObj);
		}

		//Insert
		public void Insert(int index, ProgettoStorico ProgettoStoricoObj)
		{
			if (ProgettoStoricoObj.Provider == null) ProgettoStoricoObj.Provider = this.Provider;
			base.Insert(index, ProgettoStoricoObj);
		}

		//CollectionGetById
		public ProgettoStorico CollectionGetById(NullTypes.IntNT IdValue)
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
		public ProgettoStoricoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.BoolNT RevisioneEqualThis, NullTypes.BoolNT RiesameEqualThis, NullTypes.BoolNT RicorsoEqualThis, 
NullTypes.DatetimeNT DataRiEqualThis, NullTypes.IntNT OperatoreRiEqualThis, NullTypes.StringNT SegnaturaRiEqualThis, 
NullTypes.BoolNT RiaperturaProvincialeEqualThis, NullTypes.IntNT IdAttoEqualThis)
		{
			ProgettoStoricoCollection ProgettoStoricoCollectionTemp = new ProgettoStoricoCollection();
			foreach (ProgettoStorico ProgettoStoricoItem in this)
			{
				if (((IdEqualThis == null) || ((ProgettoStoricoItem.Id != null) && (ProgettoStoricoItem.Id.Value == IdEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ProgettoStoricoItem.IdProgetto != null) && (ProgettoStoricoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((ProgettoStoricoItem.CodStato != null) && (ProgettoStoricoItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((DataEqualThis == null) || ((ProgettoStoricoItem.Data != null) && (ProgettoStoricoItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ProgettoStoricoItem.Operatore != null) && (ProgettoStoricoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoStoricoItem.Segnatura != null) && (ProgettoStoricoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((RevisioneEqualThis == null) || ((ProgettoStoricoItem.Revisione != null) && (ProgettoStoricoItem.Revisione.Value == RevisioneEqualThis.Value))) && ((RiesameEqualThis == null) || ((ProgettoStoricoItem.Riesame != null) && (ProgettoStoricoItem.Riesame.Value == RiesameEqualThis.Value))) && ((RicorsoEqualThis == null) || ((ProgettoStoricoItem.Ricorso != null) && (ProgettoStoricoItem.Ricorso.Value == RicorsoEqualThis.Value))) && 
((DataRiEqualThis == null) || ((ProgettoStoricoItem.DataRi != null) && (ProgettoStoricoItem.DataRi.Value == DataRiEqualThis.Value))) && ((OperatoreRiEqualThis == null) || ((ProgettoStoricoItem.OperatoreRi != null) && (ProgettoStoricoItem.OperatoreRi.Value == OperatoreRiEqualThis.Value))) && ((SegnaturaRiEqualThis == null) || ((ProgettoStoricoItem.SegnaturaRi != null) && (ProgettoStoricoItem.SegnaturaRi.Value == SegnaturaRiEqualThis.Value))) && 
((RiaperturaProvincialeEqualThis == null) || ((ProgettoStoricoItem.RiaperturaProvinciale != null) && (ProgettoStoricoItem.RiaperturaProvinciale.Value == RiaperturaProvincialeEqualThis.Value))) && ((IdAttoEqualThis == null) || ((ProgettoStoricoItem.IdAtto != null) && (ProgettoStoricoItem.IdAtto.Value == IdAttoEqualThis.Value))))
				{
					ProgettoStoricoCollectionTemp.Add(ProgettoStoricoItem);
				}
			}
			return ProgettoStoricoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoStoricoCollection FiltroRevisioneRiesameRicorso(NullTypes.BoolNT RevisioneEqualThis, NullTypes.BoolNT RiesameEqualThis, NullTypes.BoolNT RicorsoEqualThis)
		{
			ProgettoStoricoCollection ProgettoStoricoCollectionTemp = new ProgettoStoricoCollection();
			foreach (ProgettoStorico ProgettoStoricoItem in this)
			{
				if (((RevisioneEqualThis == null) || ((ProgettoStoricoItem.Revisione != null) && (ProgettoStoricoItem.Revisione.Value == RevisioneEqualThis.Value))) && ((RiesameEqualThis == null) || ((ProgettoStoricoItem.Riesame != null) && (ProgettoStoricoItem.Riesame.Value == RiesameEqualThis.Value))) && ((RicorsoEqualThis == null) || ((ProgettoStoricoItem.Ricorso != null) && (ProgettoStoricoItem.Ricorso.Value == RicorsoEqualThis.Value))))
				{
					ProgettoStoricoCollectionTemp.Add(ProgettoStoricoItem);
				}
			}
			return ProgettoStoricoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoStoricoCollection FiltroFase(NullTypes.StringNT CodFaseEqualThis)
		{
			ProgettoStoricoCollection ProgettoStoricoCollectionTemp = new ProgettoStoricoCollection();
			foreach (ProgettoStorico ProgettoStoricoItem in this)
			{
				if (((CodFaseEqualThis == null) || ((ProgettoStoricoItem.CodFase != null) && (ProgettoStoricoItem.CodFase.Value == CodFaseEqualThis.Value))))
				{
					ProgettoStoricoCollectionTemp.Add(ProgettoStoricoItem);
				}
			}
			return ProgettoStoricoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ProgettoStoricoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ProgettoStoricoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ProgettoStorico ProgettoStoricoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "Id", ProgettoStoricoObj.Id);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "IdProgetto", ProgettoStoricoObj.IdProgetto);
			DbProvider.SetCmdParam(cmd,firstChar + "CodStato", ProgettoStoricoObj.CodStato);
			DbProvider.SetCmdParam(cmd,firstChar + "Data", ProgettoStoricoObj.Data);
			DbProvider.SetCmdParam(cmd,firstChar + "Operatore", ProgettoStoricoObj.Operatore);
			DbProvider.SetCmdParam(cmd,firstChar + "Segnatura", ProgettoStoricoObj.Segnatura);
			DbProvider.SetCmdParam(cmd,firstChar + "Revisione", ProgettoStoricoObj.Revisione);
			DbProvider.SetCmdParam(cmd,firstChar + "Riesame", ProgettoStoricoObj.Riesame);
			DbProvider.SetCmdParam(cmd,firstChar + "Ricorso", ProgettoStoricoObj.Ricorso);
			DbProvider.SetCmdParam(cmd,firstChar + "RiaperturaProvinciale", ProgettoStoricoObj.RiaperturaProvinciale);
			DbProvider.SetCmdParam(cmd,firstChar + "DataRi", ProgettoStoricoObj.DataRi);
			DbProvider.SetCmdParam(cmd,firstChar + "OperatoreRi", ProgettoStoricoObj.OperatoreRi);
			DbProvider.SetCmdParam(cmd,firstChar + "SegnaturaRi", ProgettoStoricoObj.SegnaturaRi);
			DbProvider.SetCmdParam(cmd,firstChar + "IdAtto", ProgettoStoricoObj.IdAtto);
		}
		//Insert
		private static int Insert(DbProvider db, ProgettoStorico ProgettoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZProgettoStoricoInsert", new string[] {"IdProgetto", "CodStato", 
"Data", "Operatore", "Segnatura", 
"Revisione", "Riesame", "Ricorso", 
"RiaperturaProvinciale", "DataRi", "OperatoreRi", 
"SegnaturaRi", 



"IdAtto"}, new string[] {"int", "string", 
"DateTime", "int", "string", 
"bool", "bool", "bool", 
"bool", "DateTime", "int", 
"string", 



"int"},"");
				CompileIUCmd(false, insertCmd,ProgettoStoricoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ProgettoStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
				ProgettoStoricoObj.Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
				ProgettoStoricoObj.Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
				ProgettoStoricoObj.Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
				ProgettoStoricoObj.RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
				}
				ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoStoricoObj.IsDirty = false;
				ProgettoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ProgettoStorico ProgettoStoricoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoStoricoUpdate", new string[] {"Id", "IdProgetto", "CodStato", 
"Data", "Operatore", "Segnatura", 
"Revisione", "Riesame", "Ricorso", 
"RiaperturaProvinciale", "DataRi", "OperatoreRi", 
"SegnaturaRi", 



"IdAtto"}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"bool", "bool", "bool", 
"bool", "DateTime", "int", 
"string", 



"int"},"");
				CompileIUCmd(true, updateCmd,ProgettoStoricoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoStoricoObj.IsDirty = false;
				ProgettoStoricoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ProgettoStorico ProgettoStoricoObj)
		{
			switch (ProgettoStoricoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ProgettoStoricoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ProgettoStoricoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ProgettoStoricoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ProgettoStoricoCollection ProgettoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZProgettoStoricoUpdate", new string[] {"Id", "IdProgetto", "CodStato", 
"Data", "Operatore", "Segnatura", 
"Revisione", "Riesame", "Ricorso", 
"RiaperturaProvinciale", "DataRi", "OperatoreRi", 
"SegnaturaRi", 



"IdAtto"}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"bool", "bool", "bool", 
"bool", "DateTime", "int", 
"string", 



"int"},"");
				IDbCommand insertCmd = db.InitCmd( "ZProgettoStoricoInsert", new string[] {"IdProgetto", "CodStato", 
"Data", "Operatore", "Segnatura", 
"Revisione", "Riesame", "Ricorso", 
"RiaperturaProvinciale", "DataRi", "OperatoreRi", 
"SegnaturaRi", 



"IdAtto"}, new string[] {"int", "string", 
"DateTime", "int", "string", 
"bool", "bool", "bool", 
"bool", "DateTime", "int", 
"string", 



"int"},"");
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoStoricoCollectionObj.Count; i++)
				{
					switch (ProgettoStoricoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ProgettoStoricoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ProgettoStoricoCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
									ProgettoStoricoCollectionObj[i].Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
									ProgettoStoricoCollectionObj[i].Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
									ProgettoStoricoCollectionObj[i].Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
									ProgettoStoricoCollectionObj[i].RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ProgettoStoricoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ProgettoStoricoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ProgettoStoricoCollectionObj[i].Id);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ProgettoStoricoCollectionObj.Count; i++)
				{
					if ((ProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ProgettoStoricoCollectionObj[i].IsDirty = false;
						ProgettoStoricoCollectionObj[i].IsPersistent = true;
					}
					if ((ProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoStoricoCollectionObj[i].IsDirty = false;
						ProgettoStoricoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ProgettoStorico ProgettoStoricoObj)
		{
			int returnValue = 0;
			if (ProgettoStoricoObj.IsPersistent) 
			{
				returnValue = Delete(db, ProgettoStoricoObj.Id);
			}
			ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ProgettoStoricoObj.IsDirty = false;
			ProgettoStoricoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ProgettoStoricoCollection ProgettoStoricoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZProgettoStoricoDelete", new string[] {"Id"}, new string[] {"int"},"");
				for (int i = 0; i < ProgettoStoricoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "Id", ProgettoStoricoCollectionObj[i].Id);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ProgettoStoricoCollectionObj.Count; i++)
				{
					if ((ProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ProgettoStoricoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ProgettoStoricoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ProgettoStoricoCollectionObj[i].IsDirty = false;
						ProgettoStoricoCollectionObj[i].IsPersistent = false;
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
		public static ProgettoStorico GetById(DbProvider db, int IdValue)
		{
			ProgettoStorico ProgettoStoricoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZProgettoStoricoGetById", new string[] {"Id"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ProgettoStoricoObj = GetFromDatareader(db);
				ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoStoricoObj.IsDirty = false;
				ProgettoStoricoObj.IsPersistent = true;
			}
			db.Close();
			return ProgettoStoricoObj;
		}

		//getFromDatareader
		public static ProgettoStorico GetFromDatareader(DbProvider db)
		{
			ProgettoStorico ProgettoStoricoObj = new ProgettoStorico();
			ProgettoStoricoObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
			ProgettoStoricoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			ProgettoStoricoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			ProgettoStoricoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
			ProgettoStoricoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
			ProgettoStoricoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			ProgettoStoricoObj.Revisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE"]);
			ProgettoStoricoObj.Riesame = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIESAME"]);
			ProgettoStoricoObj.Ricorso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICORSO"]);
			ProgettoStoricoObj.RiaperturaProvinciale = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RIAPERTURA_PROVINCIALE"]);
			ProgettoStoricoObj.DataRi = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RI"]);
			ProgettoStoricoObj.OperatoreRi = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_RI"]);
			ProgettoStoricoObj.SegnaturaRi = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RI"]);
			ProgettoStoricoObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			ProgettoStoricoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			ProgettoStoricoObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			ProgettoStoricoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			ProgettoStoricoObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			ProgettoStoricoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
			ProgettoStoricoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			ProgettoStoricoObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			ProgettoStoricoObj.IdProfilo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROFILO"]);
			ProgettoStoricoObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
			ProgettoStoricoObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
			ProgettoStoricoObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			ProgettoStoricoObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
			ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ProgettoStoricoObj.IsDirty = false;
			ProgettoStoricoObj.IsPersistent = true;
			return ProgettoStoricoObj;
		}

		//Find Select

		public static ProgettoStoricoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, 
SiarLibrary.NullTypes.BoolNT RevisioneEqualThis, SiarLibrary.NullTypes.BoolNT RiesameEqualThis, SiarLibrary.NullTypes.BoolNT RicorsoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataRiEqualThis, SiarLibrary.NullTypes.IntNT OperatoreRiEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRiEqualThis, 
SiarLibrary.NullTypes.BoolNT RiaperturaProvincialeEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis)

		{

			ProgettoStoricoCollection ProgettoStoricoCollectionObj = new ProgettoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettostoricofindselect", new string[] {"Idequalthis", "IdProgettoequalthis", "CodStatoequalthis", 
"Dataequalthis", "Operatoreequalthis", "Segnaturaequalthis", 
"Revisioneequalthis", "Riesameequalthis", "Ricorsoequalthis", 
"DataRiequalthis", "OperatoreRiequalthis", "SegnaturaRiequalthis", 
"RiaperturaProvincialeequalthis", "IdAttoequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "int", "string", 
"bool", "bool", "bool", 
"DateTime", "int", "string", 
"bool", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Idequalthis", IdEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Dataequalthis", DataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Revisioneequalthis", RevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Riesameequalthis", RiesameEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ricorsoequalthis", RicorsoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataRiequalthis", DataRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreRiequalthis", OperatoreRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRiequalthis", SegnaturaRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RiaperturaProvincialeequalthis", RiaperturaProvincialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
			ProgettoStorico ProgettoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoStoricoObj = GetFromDatareader(db);
				ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoStoricoObj.IsDirty = false;
				ProgettoStoricoObj.IsPersistent = true;
				ProgettoStoricoCollectionObj.Add(ProgettoStoricoObj);
			}
			db.Close();
			return ProgettoStoricoCollectionObj;
		}

		//Find Find

		public static ProgettoStoricoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis)

		{

			ProgettoStoricoCollection ProgettoStoricoCollectionObj = new ProgettoStoricoCollection();

			IDbCommand findCmd = db.InitCmd("Zprogettostoricofindfind", new string[] {"IdProgettoequalthis", "CodStatoequalthis", "CodFaseequalthis"}, new string[] {"int", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			ProgettoStorico ProgettoStoricoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ProgettoStoricoObj = GetFromDatareader(db);
				ProgettoStoricoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ProgettoStoricoObj.IsDirty = false;
				ProgettoStoricoObj.IsPersistent = true;
				ProgettoStoricoCollectionObj.Add(ProgettoStoricoObj);
			}
			db.Close();
			return ProgettoStoricoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ProgettoStoricoCollectionProvider:IProgettoStoricoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ProgettoStoricoCollectionProvider : IProgettoStoricoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ProgettoStorico
		protected ProgettoStoricoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ProgettoStoricoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ProgettoStoricoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ProgettoStoricoCollectionProvider(IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, StringNT CodfaseEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, CodstatoEqualThis, CodfaseEqualThis);
		}

		//Costruttore3: ha in input progettostoricoCollectionObj - non popola la collection
		public ProgettoStoricoCollectionProvider(ProgettoStoricoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ProgettoStoricoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ProgettoStoricoCollection(this);
		}

		//Get e Set
		public ProgettoStoricoCollection CollectionObj
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
		public int SaveCollection(ProgettoStoricoCollection collectionObj)
		{
			return ProgettoStoricoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ProgettoStorico progettostoricoObj)
		{
			return ProgettoStoricoDAL.Save(_dbProviderObj, progettostoricoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ProgettoStoricoCollection collectionObj)
		{
			return ProgettoStoricoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ProgettoStorico progettostoricoObj)
		{
			return ProgettoStoricoDAL.Delete(_dbProviderObj, progettostoricoObj);
		}

		//getById
		public ProgettoStorico GetById(IntNT IdValue)
		{
			ProgettoStorico ProgettoStoricoTemp = ProgettoStoricoDAL.GetById(_dbProviderObj, IdValue);
			if (ProgettoStoricoTemp!=null) ProgettoStoricoTemp.Provider = this;
			return ProgettoStoricoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ProgettoStoricoCollection Select(IntNT IdEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, 
DatetimeNT DataEqualThis, IntNT OperatoreEqualThis, StringNT SegnaturaEqualThis, 
BoolNT RevisioneEqualThis, BoolNT RiesameEqualThis, BoolNT RicorsoEqualThis, 
DatetimeNT DatariEqualThis, IntNT OperatoreriEqualThis, StringNT SegnaturariEqualThis, 
BoolNT RiaperturaprovincialeEqualThis, IntNT IdattoEqualThis)
		{
			ProgettoStoricoCollection ProgettoStoricoCollectionTemp = ProgettoStoricoDAL.Select(_dbProviderObj, IdEqualThis, IdprogettoEqualThis, CodstatoEqualThis, 
DataEqualThis, OperatoreEqualThis, SegnaturaEqualThis, 
RevisioneEqualThis, RiesameEqualThis, RicorsoEqualThis, 
DatariEqualThis, OperatoreriEqualThis, SegnaturariEqualThis, 
RiaperturaprovincialeEqualThis, IdattoEqualThis);
			ProgettoStoricoCollectionTemp.Provider = this;
			return ProgettoStoricoCollectionTemp;
		}

		//Find: popola la collection
		public ProgettoStoricoCollection Find(IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, StringNT CodfaseEqualThis)
		{
			ProgettoStoricoCollection ProgettoStoricoCollectionTemp = ProgettoStoricoDAL.Find(_dbProviderObj, IdprogettoEqualThis, CodstatoEqualThis, CodfaseEqualThis);
			ProgettoStoricoCollectionTemp.Provider = this;
			return ProgettoStoricoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_STORICO>
  <ViewName>vPROGETTO_STORICO</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_STATO>Equal</COD_STATO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroRevisioneRiesameRicorso>
      <REVISIONE>Equal</REVISIONE>
      <RIESAME>Equal</RIESAME>
      <RICORSO>Equal</RICORSO>
    </FiltroRevisioneRiesameRicorso>
    <FiltroFase>
      <COD_FASE>Equal</COD_FASE>
    </FiltroFase>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_STORICO>
*/
