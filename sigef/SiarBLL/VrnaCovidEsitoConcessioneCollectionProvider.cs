using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaCovidEsitoConcessione: BaseObject
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
		private NullTypes.BoolNT _Definitiva;
		private NullTypes.BoolNT _Produzione;


		//Costruttore
		public VrnaCovidEsitoConcessione()
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

		/// <summary>
		/// Corrisponde al campo:DEFINITIVA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Definitiva
		{
			get { return _Definitiva; }
			set {
				if (Definitiva != value)
				{
					_Definitiva = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRODUZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Produzione
		{
			get { return _Produzione; }
			set {
				if (Produzione != value)
				{
					_Produzione = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCovidEsitoConcessioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaCovidEsitoConcessioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaCovidEsitoConcessione) info.GetValue(i.ToString(),typeof(VrnaCovidEsitoConcessione)));
			}
		}

		//Costruttore
		public VrnaCovidEsitoConcessioneCollection()
		{
			this.ItemType = typeof(VrnaCovidEsitoConcessione);
		}

		//Get e Set
		public new VrnaCovidEsitoConcessione this[int index]
		{
			get { return (VrnaCovidEsitoConcessione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaCovidEsitoConcessioneCollection GetChanges()
		{
			return (VrnaCovidEsitoConcessioneCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneObj)
		{
			return base.Add(VrnaCovidEsitoConcessioneObj);
		}

		//AddCollection
		public void AddCollection(VrnaCovidEsitoConcessioneCollection VrnaCovidEsitoConcessioneCollectionObj)
		{
			foreach (VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneObj in VrnaCovidEsitoConcessioneCollectionObj)
				this.Add(VrnaCovidEsitoConcessioneObj);
		}

		//Insert
		public void Insert(int index, VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneObj)
		{
			base.Insert(index, VrnaCovidEsitoConcessioneObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaCovidEsitoConcessioneCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, 
NullTypes.StringNT StatoConcessioneEqualThis, NullTypes.StringNT IdRichiestaEqualThis, NullTypes.StringNT CorEqualThis, 
NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, NullTypes.DecimalNT PunteggioEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.StringNT FinanziabilitaEqualThis, NullTypes.BoolNT DefinitivaEqualThis, NullTypes.BoolNT ProduzioneEqualThis)
		{
			VrnaCovidEsitoConcessioneCollection VrnaCovidEsitoConcessioneCollectionTemp = new VrnaCovidEsitoConcessioneCollection();
			foreach (VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.IdBando != null) && (VrnaCovidEsitoConcessioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.IdProgetto != null) && (VrnaCovidEsitoConcessioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.CodStato != null) && (VrnaCovidEsitoConcessioneItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.IdImpresa != null) && (VrnaCovidEsitoConcessioneItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.CodiceFiscale != null) && (VrnaCovidEsitoConcessioneItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.RagioneSociale != null) && (VrnaCovidEsitoConcessioneItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && 
((StatoConcessioneEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.StatoConcessione != null) && (VrnaCovidEsitoConcessioneItem.StatoConcessione.Value == StatoConcessioneEqualThis.Value))) && ((IdRichiestaEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.IdRichiesta != null) && (VrnaCovidEsitoConcessioneItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((CorEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Cor != null) && (VrnaCovidEsitoConcessioneItem.Cor.Value == CorEqualThis.Value))) && 
((DataAssegnazioneCorEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.DataAssegnazioneCor != null) && (VrnaCovidEsitoConcessioneItem.DataAssegnazioneCor.Value == DataAssegnazioneCorEqualThis.Value))) && ((PunteggioEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Punteggio != null) && (VrnaCovidEsitoConcessioneItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((OrdineEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Ordine != null) && (VrnaCovidEsitoConcessioneItem.Ordine.Value == OrdineEqualThis.Value))) && 
((FinanziabilitaEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Finanziabilita != null) && (VrnaCovidEsitoConcessioneItem.Finanziabilita.Value == FinanziabilitaEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Definitiva != null) && (VrnaCovidEsitoConcessioneItem.Definitiva.Value == DefinitivaEqualThis.Value))) && ((ProduzioneEqualThis == null) || ((VrnaCovidEsitoConcessioneItem.Produzione != null) && (VrnaCovidEsitoConcessioneItem.Produzione.Value == ProduzioneEqualThis.Value))))
				{
					VrnaCovidEsitoConcessioneCollectionTemp.Add(VrnaCovidEsitoConcessioneItem);
				}
			}
			return VrnaCovidEsitoConcessioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaCovidEsitoConcessioneDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaCovidEsitoConcessione GetFromDatareader(DbProvider db)
		{
			VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneObj = new VrnaCovidEsitoConcessione();
			VrnaCovidEsitoConcessioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VrnaCovidEsitoConcessioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VrnaCovidEsitoConcessioneObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VrnaCovidEsitoConcessioneObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VrnaCovidEsitoConcessioneObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VrnaCovidEsitoConcessioneObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VrnaCovidEsitoConcessioneObj.StatoConcessione = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_CONCESSIONE"]);
			VrnaCovidEsitoConcessioneObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			VrnaCovidEsitoConcessioneObj.Cor = new SiarLibrary.NullTypes.StringNT(db.DataReader["COR"]);
			VrnaCovidEsitoConcessioneObj.DataAssegnazioneCor = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ASSEGNAZIONE_COR"]);
			VrnaCovidEsitoConcessioneObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			VrnaCovidEsitoConcessioneObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			VrnaCovidEsitoConcessioneObj.Finanziabilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["FINANZIABILITA"]);
			VrnaCovidEsitoConcessioneObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			VrnaCovidEsitoConcessioneObj.Produzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRODUZIONE"]);
			VrnaCovidEsitoConcessioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaCovidEsitoConcessioneObj.IsDirty = false;
			VrnaCovidEsitoConcessioneObj.IsPersistent = true;
			return VrnaCovidEsitoConcessioneObj;
		}

		//Find Select

		public static VrnaCovidEsitoConcessioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, 
SiarLibrary.NullTypes.StringNT StatoConcessioneEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT CorEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.StringNT FinanziabilitaEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, SiarLibrary.NullTypes.BoolNT ProduzioneEqualThis)

		{

			VrnaCovidEsitoConcessioneCollection VrnaCovidEsitoConcessioneCollectionObj = new VrnaCovidEsitoConcessioneCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnacovidesitoconcessionefindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "CodStatoequalthis", 
"IdImpresaequalthis", "CodiceFiscaleequalthis", "RagioneSocialeequalthis", 
"StatoConcessioneequalthis", "IdRichiestaequalthis", "Corequalthis", 
"DataAssegnazioneCorequalthis", "Punteggioequalthis", "Ordineequalthis", 
"Finanziabilitaequalthis", "Definitivaequalthis", "Produzioneequalthis"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"string", "string", "string", 
"DateTime", "decimal", "int", 
"string", "bool", "bool"},"");

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
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Definitivaequalthis", DefinitivaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Produzioneequalthis", ProduzioneEqualThis);
			VrnaCovidEsitoConcessione VrnaCovidEsitoConcessioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaCovidEsitoConcessioneObj = GetFromDatareader(db);
				VrnaCovidEsitoConcessioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaCovidEsitoConcessioneObj.IsDirty = false;
				VrnaCovidEsitoConcessioneObj.IsPersistent = true;
				VrnaCovidEsitoConcessioneCollectionObj.Add(VrnaCovidEsitoConcessioneObj);
			}
			db.Close();
			return VrnaCovidEsitoConcessioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneCollectionProvider:IVrnaCovidEsitoConcessioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCovidEsitoConcessioneCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaCovidEsitoConcessione
		protected VrnaCovidEsitoConcessioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaCovidEsitoConcessioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaCovidEsitoConcessioneCollection();
		}

		//Costruttore3: ha in input vrnacovidesitoconcessioneCollectionObj - non popola la collection
		public VrnaCovidEsitoConcessioneCollectionProvider(VrnaCovidEsitoConcessioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaCovidEsitoConcessioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaCovidEsitoConcessioneCollection();
		}

		//Get e Set
		public VrnaCovidEsitoConcessioneCollection CollectionObj
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
		public VrnaCovidEsitoConcessioneCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeEqualThis, 
StringNT StatoconcessioneEqualThis, StringNT IdrichiestaEqualThis, StringNT CorEqualThis, 
DatetimeNT DataassegnazionecorEqualThis, DecimalNT PunteggioEqualThis, IntNT OrdineEqualThis, 
StringNT FinanziabilitaEqualThis, BoolNT DefinitivaEqualThis, BoolNT ProduzioneEqualThis)
		{
			VrnaCovidEsitoConcessioneCollection VrnaCovidEsitoConcessioneCollectionTemp = VrnaCovidEsitoConcessioneDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, CodstatoEqualThis, 
IdimpresaEqualThis, CodicefiscaleEqualThis, RagionesocialeEqualThis, 
StatoconcessioneEqualThis, IdrichiestaEqualThis, CorEqualThis, 
DataassegnazionecorEqualThis, PunteggioEqualThis, OrdineEqualThis, 
FinanziabilitaEqualThis, DefinitivaEqualThis, ProduzioneEqualThis);
			return VrnaCovidEsitoConcessioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_COVID_ESITO_CONCESSIONE>
  <ViewName>vRNA_COVID_ESITO_CONCESSIONE</ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</vRNA_COVID_ESITO_CONCESSIONE>
*/
