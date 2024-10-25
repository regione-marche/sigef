using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneCollaudo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaCovidEsitoConcessioneCollaudo: BaseObject
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
		public VrnaCovidEsitoConcessioneCollaudo()
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
	/// Summary description for VrnaCovidEsitoConcessioneCollaudoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCovidEsitoConcessioneCollaudoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaCovidEsitoConcessioneCollaudoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaCovidEsitoConcessioneCollaudo) info.GetValue(i.ToString(),typeof(VrnaCovidEsitoConcessioneCollaudo)));
			}
		}

		//Costruttore
		public VrnaCovidEsitoConcessioneCollaudoCollection()
		{
			this.ItemType = typeof(VrnaCovidEsitoConcessioneCollaudo);
		}

		//Get e Set
		public new VrnaCovidEsitoConcessioneCollaudo this[int index]
		{
			get { return (VrnaCovidEsitoConcessioneCollaudo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaCovidEsitoConcessioneCollaudoCollection GetChanges()
		{
			return (VrnaCovidEsitoConcessioneCollaudoCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoObj)
		{
			return base.Add(VrnaCovidEsitoConcessioneCollaudoObj);
		}

		//AddCollection
		public void AddCollection(VrnaCovidEsitoConcessioneCollaudoCollection VrnaCovidEsitoConcessioneCollaudoCollectionObj)
		{
			foreach (VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoObj in VrnaCovidEsitoConcessioneCollaudoCollectionObj)
				this.Add(VrnaCovidEsitoConcessioneCollaudoObj);
		}

		//Insert
		public void Insert(int index, VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoObj)
		{
			base.Insert(index, VrnaCovidEsitoConcessioneCollaudoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaCovidEsitoConcessioneCollaudoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodStatoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, 
NullTypes.StringNT StatoConcessioneEqualThis, NullTypes.StringNT IdRichiestaEqualThis, NullTypes.StringNT CorEqualThis, 
NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, NullTypes.DecimalNT PunteggioEqualThis, NullTypes.IntNT OrdineEqualThis, 
NullTypes.StringNT FinanziabilitaEqualThis, NullTypes.BoolNT DefinitivaEqualThis, NullTypes.BoolNT ProduzioneEqualThis)
		{
			VrnaCovidEsitoConcessioneCollaudoCollection VrnaCovidEsitoConcessioneCollaudoCollectionTemp = new VrnaCovidEsitoConcessioneCollaudoCollection();
			foreach (VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.IdBando != null) && (VrnaCovidEsitoConcessioneCollaudoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.IdProgetto != null) && (VrnaCovidEsitoConcessioneCollaudoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodStatoEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.CodStato != null) && (VrnaCovidEsitoConcessioneCollaudoItem.CodStato.Value == CodStatoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.IdImpresa != null) && (VrnaCovidEsitoConcessioneCollaudoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.CodiceFiscale != null) && (VrnaCovidEsitoConcessioneCollaudoItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.RagioneSociale != null) && (VrnaCovidEsitoConcessioneCollaudoItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && 
((StatoConcessioneEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.StatoConcessione != null) && (VrnaCovidEsitoConcessioneCollaudoItem.StatoConcessione.Value == StatoConcessioneEqualThis.Value))) && ((IdRichiestaEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.IdRichiesta != null) && (VrnaCovidEsitoConcessioneCollaudoItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((CorEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Cor != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Cor.Value == CorEqualThis.Value))) && 
((DataAssegnazioneCorEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.DataAssegnazioneCor != null) && (VrnaCovidEsitoConcessioneCollaudoItem.DataAssegnazioneCor.Value == DataAssegnazioneCorEqualThis.Value))) && ((PunteggioEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Punteggio != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((OrdineEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Ordine != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Ordine.Value == OrdineEqualThis.Value))) && 
((FinanziabilitaEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Finanziabilita != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Finanziabilita.Value == FinanziabilitaEqualThis.Value))) && ((DefinitivaEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Definitiva != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Definitiva.Value == DefinitivaEqualThis.Value))) && ((ProduzioneEqualThis == null) || ((VrnaCovidEsitoConcessioneCollaudoItem.Produzione != null) && (VrnaCovidEsitoConcessioneCollaudoItem.Produzione.Value == ProduzioneEqualThis.Value))))
				{
					VrnaCovidEsitoConcessioneCollaudoCollectionTemp.Add(VrnaCovidEsitoConcessioneCollaudoItem);
				}
			}
			return VrnaCovidEsitoConcessioneCollaudoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneCollaudoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaCovidEsitoConcessioneCollaudoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaCovidEsitoConcessioneCollaudo GetFromDatareader(DbProvider db)
		{
			VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoObj = new VrnaCovidEsitoConcessioneCollaudo();
			VrnaCovidEsitoConcessioneCollaudoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VrnaCovidEsitoConcessioneCollaudoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VrnaCovidEsitoConcessioneCollaudoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VrnaCovidEsitoConcessioneCollaudoObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VrnaCovidEsitoConcessioneCollaudoObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VrnaCovidEsitoConcessioneCollaudoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VrnaCovidEsitoConcessioneCollaudoObj.StatoConcessione = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_CONCESSIONE"]);
			VrnaCovidEsitoConcessioneCollaudoObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Cor = new SiarLibrary.NullTypes.StringNT(db.DataReader["COR"]);
			VrnaCovidEsitoConcessioneCollaudoObj.DataAssegnazioneCor = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ASSEGNAZIONE_COR"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Punteggio = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["PUNTEGGIO"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Finanziabilita = new SiarLibrary.NullTypes.StringNT(db.DataReader["FINANZIABILITA"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Definitiva = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVA"]);
			VrnaCovidEsitoConcessioneCollaudoObj.Produzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PRODUZIONE"]);
			VrnaCovidEsitoConcessioneCollaudoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaCovidEsitoConcessioneCollaudoObj.IsDirty = false;
			VrnaCovidEsitoConcessioneCollaudoObj.IsPersistent = true;
			return VrnaCovidEsitoConcessioneCollaudoObj;
		}

		//Find Select

		public static VrnaCovidEsitoConcessioneCollaudoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, 
SiarLibrary.NullTypes.StringNT StatoConcessioneEqualThis, SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT CorEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAssegnazioneCorEqualThis, SiarLibrary.NullTypes.DecimalNT PunteggioEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.StringNT FinanziabilitaEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivaEqualThis, SiarLibrary.NullTypes.BoolNT ProduzioneEqualThis)

		{

			VrnaCovidEsitoConcessioneCollaudoCollection VrnaCovidEsitoConcessioneCollaudoCollectionObj = new VrnaCovidEsitoConcessioneCollaudoCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnacovidesitoconcessionecollaudofindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "CodStatoequalthis", 
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
			VrnaCovidEsitoConcessioneCollaudo VrnaCovidEsitoConcessioneCollaudoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaCovidEsitoConcessioneCollaudoObj = GetFromDatareader(db);
				VrnaCovidEsitoConcessioneCollaudoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaCovidEsitoConcessioneCollaudoObj.IsDirty = false;
				VrnaCovidEsitoConcessioneCollaudoObj.IsPersistent = true;
				VrnaCovidEsitoConcessioneCollaudoCollectionObj.Add(VrnaCovidEsitoConcessioneCollaudoObj);
			}
			db.Close();
			return VrnaCovidEsitoConcessioneCollaudoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaCovidEsitoConcessioneCollaudoCollectionProvider:IVrnaCovidEsitoConcessioneCollaudoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaCovidEsitoConcessioneCollaudoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaCovidEsitoConcessioneCollaudo
		protected VrnaCovidEsitoConcessioneCollaudoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaCovidEsitoConcessioneCollaudoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaCovidEsitoConcessioneCollaudoCollection();
		}

		//Costruttore3: ha in input vrnacovidesitoconcessionecollaudoCollectionObj - non popola la collection
		public VrnaCovidEsitoConcessioneCollaudoCollectionProvider(VrnaCovidEsitoConcessioneCollaudoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaCovidEsitoConcessioneCollaudoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaCovidEsitoConcessioneCollaudoCollection();
		}

		//Get e Set
		public VrnaCovidEsitoConcessioneCollaudoCollection CollectionObj
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
		public VrnaCovidEsitoConcessioneCollaudoCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, StringNT CodstatoEqualThis, 
IntNT IdimpresaEqualThis, StringNT CodicefiscaleEqualThis, StringNT RagionesocialeEqualThis, 
StringNT StatoconcessioneEqualThis, StringNT IdrichiestaEqualThis, StringNT CorEqualThis, 
DatetimeNT DataassegnazionecorEqualThis, DecimalNT PunteggioEqualThis, IntNT OrdineEqualThis, 
StringNT FinanziabilitaEqualThis, BoolNT DefinitivaEqualThis, BoolNT ProduzioneEqualThis)
		{
			VrnaCovidEsitoConcessioneCollaudoCollection VrnaCovidEsitoConcessioneCollaudoCollectionTemp = VrnaCovidEsitoConcessioneCollaudoDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, CodstatoEqualThis, 
IdimpresaEqualThis, CodicefiscaleEqualThis, RagionesocialeEqualThis, 
StatoconcessioneEqualThis, IdrichiestaEqualThis, CorEqualThis, 
DataassegnazionecorEqualThis, PunteggioEqualThis, OrdineEqualThis, 
FinanziabilitaEqualThis, DefinitivaEqualThis, ProduzioneEqualThis);
			return VrnaCovidEsitoConcessioneCollaudoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_COVID_ESITO_CONCESSIONE_COLLAUDO>
  <ViewName>vRNA_COVID_ESITO_CONCESSIONE_COLLAUDO</ViewName>
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
</vRNA_COVID_ESITO_CONCESSIONE_COLLAUDO>
*/
