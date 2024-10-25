using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEsitoConcessione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaEsitoConcessione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodStato;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _StatoConcessione;
		private NullTypes.StringNT _IdRichiesta;
		private NullTypes.StringNT _Cor;
		private NullTypes.DatetimeNT _DataAssegnazioneCor;
		private NullTypes.DecimalNT _Punteggio;
		private NullTypes.IntNT _Ordine;
		private NullTypes.StringNT _Finanziabilita;


		//Costruttore
		public VrnaEsitoConcessione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_FISCALE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CodiceFiscale
		{
			get { return _CodiceFiscale; }
			set {
				if (CodiceFiscale != value)
				{
					_CodiceFiscale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RAGIONE_SOCIALE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT RagioneSociale
		{
			get { return _RagioneSociale; }
			set {
				if (RagioneSociale != value)
				{
					_RagioneSociale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_CONCESSIONE
		/// Tipo sul db:VARCHAR(17)
		/// </summary>
		public NullTypes.StringNT StatoConcessione
		{
			get { return _StatoConcessione; }
			set {
				if (StatoConcessione != value)
				{
					_StatoConcessione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RICHIESTA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT IdRichiesta
		{
			get { return _IdRichiesta; }
			set {
				if (IdRichiesta != value)
				{
					_IdRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COR
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Cor
		{
			get { return _Cor; }
			set {
				if (Cor != value)
				{
					_Cor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ASSEGNAZIONE_COR
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAssegnazioneCor
		{
			get { return _DataAssegnazioneCor; }
			set {
				if (DataAssegnazioneCor != value)
				{
					_DataAssegnazioneCor = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:DECIMAL(10,6)
		/// </summary>
		public NullTypes.DecimalNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
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
		/// Corrisponde al campo:FINANZIABILITA
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT Finanziabilita
		{
			get { return _Finanziabilita; }
			set {
				if (Finanziabilita != value)
				{
					_Finanziabilita = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEsitoConcessioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEsitoConcessioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaEsitoConcessioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaEsitoConcessione) info.GetValue(i.ToString(),typeof(VrnaEsitoConcessione)));
			}
		}

		//Costruttore
		public VrnaEsitoConcessioneCollection()
		{
			this.ItemType = typeof(VrnaEsitoConcessione);
		}

		//Get e Set
		public new VrnaEsitoConcessione this[int index]
		{
			get { return (VrnaEsitoConcessione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaEsitoConcessioneCollection GetChanges()
		{
			return (VrnaEsitoConcessioneCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaEsitoConcessione VrnaEsitoConcessioneObj)
		{
			return base.Add(VrnaEsitoConcessioneObj);
		}

		//AddCollection
		public void AddCollection(VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionObj)
		{
			foreach (VrnaEsitoConcessione VrnaEsitoConcessioneObj in VrnaEsitoConcessioneCollectionObj)
				this.Add(VrnaEsitoConcessioneObj);
		}

		//Insert
		public void Insert(int index, VrnaEsitoConcessione VrnaEsitoConcessioneObj)
		{
			base.Insert(index, VrnaEsitoConcessioneObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaEsitoConcessioneCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, 
NullTypes.StringNT StatoConcessioneEqualThis, NullTypes.StringNT IdRichiestaEqualThis, NullTypes.StringNT CorEqualThis, 
NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, NullTypes.DecimalNT PunteggioEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.StringNT FinanziabilitaEqualThis)
		{
			VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionTemp = new VrnaEsitoConcessioneCollection();
			foreach (VrnaEsitoConcessione VrnaEsitoConcessioneItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VrnaEsitoConcessioneItem.IdBando != null) && (VrnaEsitoConcessioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VrnaEsitoConcessioneItem.IdProgetto != null) && (VrnaEsitoConcessioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((VrnaEsitoConcessioneItem.CodStato != null) && (VrnaEsitoConcessioneItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VrnaEsitoConcessioneItem.IdImpresa != null) && (VrnaEsitoConcessioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((VrnaEsitoConcessioneItem.CodiceFiscale != null) && (VrnaEsitoConcessioneItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VrnaEsitoConcessioneItem.RagioneSociale != null) && (VrnaEsitoConcessioneItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && 
((StatoConcessioneEqualThis == null) || ((VrnaEsitoConcessioneItem.StatoConcessione != null) && (VrnaEsitoConcessioneItem.StatoConcessione.Value == StatoConcessioneEqualThis.Value))) && ((IdRichiestaEqualThis == null) || ((VrnaEsitoConcessioneItem.IdRichiesta != null) && (VrnaEsitoConcessioneItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((CorEqualThis == null) || ((VrnaEsitoConcessioneItem.Cor != null) && (VrnaEsitoConcessioneItem.Cor.Value == CorEqualThis.Value))) && 
((DataAssegnazioneCorEqualThis == null) || ((VrnaEsitoConcessioneItem.DataAssegnazioneCor != null) && (VrnaEsitoConcessioneItem.DataAssegnazioneCor.Value == DataAssegnazioneCorEqualThis.Value))) && ((PunteggioEqualThis == null) || ((VrnaEsitoConcessioneItem.Punteggio != null) && (VrnaEsitoConcessioneItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((OrdineEqualThis == null) || ((VrnaEsitoConcessioneItem.Ordine != null) && (VrnaEsitoConcessioneItem.Ordine.Value == OrdineEqualThis.Value))) && 
((FinanziabilitaEqualThis == null) || ((VrnaEsitoConcessioneItem.Finanziabilita != null) && (VrnaEsitoConcessioneItem.Finanziabilita.Value == FinanziabilitaEqualThis.Value))))
				{
					VrnaEsitoConcessioneCollectionTemp.Add(VrnaEsitoConcessioneItem);
				}
			}
			return VrnaEsitoConcessioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaEsitoConcessioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaEsitoConcessioneDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaEsitoConcessione GetFromDatareader(DbProvider db)
		{
			VrnaEsitoConcessione VrnaEsitoConcessioneObj = new VrnaEsitoConcessione();
			VrnaEsitoConcessioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VrnaEsitoConcessioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VrnaEsitoConcessioneObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VrnaEsitoConcessioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VrnaEsitoConcessioneObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VrnaEsitoConcessioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VrnaEsitoConcessioneObj.StatoConcessione = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_CONCESSIONE"]);
			VrnaEsitoConcessioneObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			VrnaEsitoConcessioneObj.Cor = new SiarLibrary.NullTypes.StringNT(db.DataReader["COR"]);
			VrnaEsitoConcessioneObj.DataAssegnazioneCor = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ASSEGNAZIONE_COR"]);
			VrnaEsitoConcessioneObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			VrnaEsitoConcessioneObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			VrnaEsitoConcessioneObj.Finanziabilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["FINANZIABILITA"]);
			VrnaEsitoConcessioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaEsitoConcessioneObj.IsDirty = false;
			VrnaEsitoConcessioneObj.IsPersistent = true;
			return VrnaEsitoConcessioneObj;
		}

		//Find Select

		public static VrnaEsitoConcessioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, 
SiarLibrary.NullTypes.StringNT StatoConcessioneEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT CorEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.StringNT FinanziabilitaEqualThis)

		{

			VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionObj = new VrnaEsitoConcessioneCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnaesitoconcessionefindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "CodStatoequalthis", 
"IdImpresaequalthis", "CodiceFiscaleequalthis", "RagioneSocialeequalthis", 
"StatoConcessioneequalthis", "IdRichiestaequalthis", "Corequalthis", 
"DataAssegnazioneCorequalthis", "Punteggioequalthis", "Ordineequalthis", 
"Finanziabilitaequalthis"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"string", "string", "string", 
"DateTime", "decimal", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoConcessioneequalthis", StatoConcessioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Corequalthis", CorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAssegnazioneCorequalthis", DataAssegnazioneCorEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Punteggioequalthis", PunteggioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Finanziabilitaequalthis", FinanziabilitaEqualThis);
			VrnaEsitoConcessione VrnaEsitoConcessioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaEsitoConcessioneObj = GetFromDatareader(db);
				VrnaEsitoConcessioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaEsitoConcessioneObj.IsDirty = false;
				VrnaEsitoConcessioneObj.IsPersistent = true;
				VrnaEsitoConcessioneCollectionObj.Add(VrnaEsitoConcessioneObj);
			}
			db.Close();
			return VrnaEsitoConcessioneCollectionObj;
		}

		//Find Find

		public static VrnaEsitoConcessioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis)

		{

			VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionObj = new VrnaEsitoConcessioneCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnaesitoconcessionefindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdRichiestaequalthis"}, new string[] {"int", "int", "int", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			VrnaEsitoConcessione VrnaEsitoConcessioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaEsitoConcessioneObj = GetFromDatareader(db);
				VrnaEsitoConcessioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaEsitoConcessioneObj.IsDirty = false;
				VrnaEsitoConcessioneObj.IsPersistent = true;
				VrnaEsitoConcessioneCollectionObj.Add(VrnaEsitoConcessioneObj);
			}
			db.Close();
			return VrnaEsitoConcessioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaEsitoConcessioneCollectionProvider:IVrnaEsitoConcessioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEsitoConcessioneCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaEsitoConcessione
		protected VrnaEsitoConcessioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaEsitoConcessioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaEsitoConcessioneCollection();
		}

		//Costruttore 2: popola la collection
		public VrnaEsitoConcessioneCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis);
		}

		//Costruttore3: ha in input vrnaesitoconcessioneCollectionObj - non popola la collection
		public VrnaEsitoConcessioneCollectionProvider(VrnaEsitoConcessioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaEsitoConcessioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaEsitoConcessioneCollection();
		}

		//Get e Set
		public VrnaEsitoConcessioneCollection CollectionObj
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

		//Select: popola la collection
		public VrnaEsitoConcessioneCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeEqualThis, 
StringNT StatoconcessioneEqualThis, StringNT IdrichiestaEqualThis, StringNT CorEqualThis, 
DatetimeNT DataassegnazionecorEqualThis, DecimalNT PunteggioEqualThis, IntNT OrdineEqualThis, 
StringNT FinanziabilitaEqualThis)
		{
			VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionTemp = VrnaEsitoConcessioneDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, CodstatoEqualThis, 
IdimpresaEqualThis, CodicefiscaleEqualThis, RagionesocialeEqualThis, 
StatoconcessioneEqualThis, IdrichiestaEqualThis, CorEqualThis, 
DataassegnazionecorEqualThis, PunteggioEqualThis, OrdineEqualThis, 
FinanziabilitaEqualThis);
			return VrnaEsitoConcessioneCollectionTemp;
		}

		//Find: popola la collection
		public VrnaEsitoConcessioneCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis)
		{
			VrnaEsitoConcessioneCollection VrnaEsitoConcessioneCollectionTemp = VrnaEsitoConcessioneDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis);
			return VrnaEsitoConcessioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_ESITO_CONCESSIONE>
  <ViewName>vRNA_ESITO_CONCESSIONE</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_RICHIESTA>Equal</ID_RICHIESTA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vRNA_ESITO_CONCESSIONE>
*/
