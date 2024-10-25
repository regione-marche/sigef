using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcontrolliStabilita
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcontrolliStabilita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _Asse;
		private NullTypes.StringNT _Azione;
		private NullTypes.StringNT _Intervento;
		private NullTypes.StringNT _DescrizioneIntervento;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _CodiceFiscale;
		private NullTypes.DecimalNT _SpesaAmmessaRendicontata;
		private NullTypes.DecimalNT _ContributoAmmissibile;
		private NullTypes.DecimalNT _ImportoLiquidato;
		private NullTypes.DatetimeNT _DataDecreto;


		//Costruttore
		public VcontrolliStabilita()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(2000)
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
		/// Corrisponde al campo:ASSE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Asse
		{
			get { return _Asse; }
			set {
				if (Asse != value)
				{
					_Asse = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Azione
		{
			get { return _Azione; }
			set {
				if (Azione != value)
				{
					_Azione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INTERVENTO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Intervento
		{
			get { return _Intervento; }
			set {
				if (Intervento != value)
				{
					_Intervento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_INTERVENTO
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneIntervento
		{
			get { return _DescrizioneIntervento; }
			set {
				if (DescrizioneIntervento != value)
				{
					_DescrizioneIntervento = value;
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
		/// Corrisponde al campo:SPESA_AMMESSA_RENDICONTATA
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT SpesaAmmessaRendicontata
		{
			get { return _SpesaAmmessaRendicontata; }
			set {
				if (SpesaAmmessaRendicontata != value)
				{
					_SpesaAmmessaRendicontata = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CONTRIBUTO_AMMISSIBILE
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT ContributoAmmissibile
		{
			get { return _ContributoAmmissibile; }
			set {
				if (ContributoAmmissibile != value)
				{
					_ContributoAmmissibile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO_LIQUIDATO
		/// Tipo sul db:DECIMAL(38,2)
		/// </summary>
		public NullTypes.DecimalNT ImportoLiquidato
		{
			get { return _ImportoLiquidato; }
			set {
				if (ImportoLiquidato != value)
				{
					_ImportoLiquidato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_DECRETO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataDecreto
		{
			get { return _DataDecreto; }
			set {
				if (DataDecreto != value)
				{
					_DataDecreto = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcontrolliStabilitaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcontrolliStabilitaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcontrolliStabilitaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcontrolliStabilita) info.GetValue(i.ToString(),typeof(VcontrolliStabilita)));
			}
		}

		//Costruttore
		public VcontrolliStabilitaCollection()
		{
			this.ItemType = typeof(VcontrolliStabilita);
		}

		//Get e Set
		public new VcontrolliStabilita this[int index]
		{
			get { return (VcontrolliStabilita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcontrolliStabilitaCollection GetChanges()
		{
			return (VcontrolliStabilitaCollection) base.GetChanges();
		}

		//Add
		public int Add(VcontrolliStabilita VcontrolliStabilitaObj)
		{
			return base.Add(VcontrolliStabilitaObj);
		}

		//AddCollection
		public void AddCollection(VcontrolliStabilitaCollection VcontrolliStabilitaCollectionObj)
		{
			foreach (VcontrolliStabilita VcontrolliStabilitaObj in VcontrolliStabilitaCollectionObj)
				this.Add(VcontrolliStabilitaObj);
		}

		//Insert
		public void Insert(int index, VcontrolliStabilita VcontrolliStabilitaObj)
		{
			base.Insert(index, VcontrolliStabilitaObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcontrolliStabilitaCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT AsseEqualThis, NullTypes.StringNT AzioneEqualThis, NullTypes.StringNT InterventoEqualThis, 
NullTypes.StringNT DescrizioneInterventoEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, NullTypes.StringNT CodiceFiscaleEqualThis, 
NullTypes.DecimalNT SpesaAmmessaRendicontataEqualThis, NullTypes.DecimalNT ContributoAmmissibileEqualThis, NullTypes.DecimalNT ImportoLiquidatoEqualThis, 
NullTypes.DatetimeNT DataDecretoEqualThis)
		{
			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionTemp = new VcontrolliStabilitaCollection();
			foreach (VcontrolliStabilita VcontrolliStabilitaItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VcontrolliStabilitaItem.IdProgetto != null) && (VcontrolliStabilitaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((VcontrolliStabilitaItem.IdBando != null) && (VcontrolliStabilitaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VcontrolliStabilitaItem.Descrizione != null) && (VcontrolliStabilitaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((AsseEqualThis == null) || ((VcontrolliStabilitaItem.Asse != null) && (VcontrolliStabilitaItem.Asse.Value == AsseEqualThis.Value))) && ((AzioneEqualThis == null) || ((VcontrolliStabilitaItem.Azione != null) && (VcontrolliStabilitaItem.Azione.Value == AzioneEqualThis.Value))) && ((InterventoEqualThis == null) || ((VcontrolliStabilitaItem.Intervento != null) && (VcontrolliStabilitaItem.Intervento.Value == InterventoEqualThis.Value))) && 
((DescrizioneInterventoEqualThis == null) || ((VcontrolliStabilitaItem.DescrizioneIntervento != null) && (VcontrolliStabilitaItem.DescrizioneIntervento.Value == DescrizioneInterventoEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VcontrolliStabilitaItem.RagioneSociale != null) && (VcontrolliStabilitaItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && ((CodiceFiscaleEqualThis == null) || ((VcontrolliStabilitaItem.CodiceFiscale != null) && (VcontrolliStabilitaItem.CodiceFiscale.Value == CodiceFiscaleEqualThis.Value))) && 
((SpesaAmmessaRendicontataEqualThis == null) || ((VcontrolliStabilitaItem.SpesaAmmessaRendicontata != null) && (VcontrolliStabilitaItem.SpesaAmmessaRendicontata.Value == SpesaAmmessaRendicontataEqualThis.Value))) && ((ContributoAmmissibileEqualThis == null) || ((VcontrolliStabilitaItem.ContributoAmmissibile != null) && (VcontrolliStabilitaItem.ContributoAmmissibile.Value == ContributoAmmissibileEqualThis.Value))) && ((ImportoLiquidatoEqualThis == null) || ((VcontrolliStabilitaItem.ImportoLiquidato != null) && (VcontrolliStabilitaItem.ImportoLiquidato.Value == ImportoLiquidatoEqualThis.Value))) && 
((DataDecretoEqualThis == null) || ((VcontrolliStabilitaItem.DataDecreto != null) && (VcontrolliStabilitaItem.DataDecreto.Value == DataDecretoEqualThis.Value))))
				{
					VcontrolliStabilitaCollectionTemp.Add(VcontrolliStabilitaItem);
				}
			}
			return VcontrolliStabilitaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcontrolliStabilitaCollection Filter(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT AsseEqualThis, NullTypes.StringNT AzioneEqualThis, 
NullTypes.StringNT InterventoEqualThis)
		{
			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionTemp = new VcontrolliStabilitaCollection();
			foreach (VcontrolliStabilita VcontrolliStabilitaItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VcontrolliStabilitaItem.IdBando != null) && (VcontrolliStabilitaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((AsseEqualThis == null) || ((VcontrolliStabilitaItem.Asse != null) && (VcontrolliStabilitaItem.Asse.Value == AsseEqualThis.Value))) && ((AzioneEqualThis == null) || ((VcontrolliStabilitaItem.Azione != null) && (VcontrolliStabilitaItem.Azione.Value == AzioneEqualThis.Value))) && 
((InterventoEqualThis == null) || ((VcontrolliStabilitaItem.Intervento != null) && (VcontrolliStabilitaItem.Intervento.Value == InterventoEqualThis.Value))))
				{
					VcontrolliStabilitaCollectionTemp.Add(VcontrolliStabilitaItem);
				}
			}
			return VcontrolliStabilitaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcontrolliStabilitaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcontrolliStabilitaDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcontrolliStabilita GetFromDatareader(DbProvider db)
		{
			VcontrolliStabilita VcontrolliStabilitaObj = new VcontrolliStabilita();
			VcontrolliStabilitaObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VcontrolliStabilitaObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcontrolliStabilitaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VcontrolliStabilitaObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ASSE"]);
			VcontrolliStabilitaObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE"]);
			VcontrolliStabilitaObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["INTERVENTO"]);
			VcontrolliStabilitaObj.DescrizioneIntervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_INTERVENTO"]);
			VcontrolliStabilitaObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VcontrolliStabilitaObj.CodiceFiscale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_FISCALE"]);
			VcontrolliStabilitaObj.SpesaAmmessaRendicontata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_AMMESSA_RENDICONTATA"]);
			VcontrolliStabilitaObj.ContributoAmmissibile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMISSIBILE"]);
			VcontrolliStabilitaObj.ImportoLiquidato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_LIQUIDATO"]);
			VcontrolliStabilitaObj.DataDecreto = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DECRETO"]);
			VcontrolliStabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcontrolliStabilitaObj.IsDirty = false;
			VcontrolliStabilitaObj.IsPersistent = true;
			return VcontrolliStabilitaObj;
		}

		//Find Select

		public static VcontrolliStabilitaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.StringNT AsseEqualThis, SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.StringNT InterventoEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneInterventoEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis, 
SiarLibrary.NullTypes.DecimalNT SpesaAmmessaRendicontataEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmissibileEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoLiquidatoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataDecretoEqualThis)

		{

			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionObj = new VcontrolliStabilitaCollection();

			IDbCommand findCmd = db.InitCmd("Zvcontrollistabilitafindselect", new string[] {"IdProgettoequalthis", "IdBandoequalthis", "Descrizioneequalthis", 
"Asseequalthis", "Azioneequalthis", "Interventoequalthis", 
"DescrizioneInterventoequalthis", "RagioneSocialeequalthis", "CodiceFiscaleequalthis", 
"SpesaAmmessaRendicontataequalthis", "ContributoAmmissibileequalthis", "ImportoLiquidatoequalthis", 
"DataDecretoequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"string", "string", "string", 
"decimal", "decimal", "decimal", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneInterventoequalthis", DescrizioneInterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SpesaAmmessaRendicontataequalthis", SpesaAmmessaRendicontataEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ContributoAmmissibileequalthis", ContributoAmmissibileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ImportoLiquidatoequalthis", ImportoLiquidatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataDecretoequalthis", DataDecretoEqualThis);
			VcontrolliStabilita VcontrolliStabilitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcontrolliStabilitaObj = GetFromDatareader(db);
				VcontrolliStabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcontrolliStabilitaObj.IsDirty = false;
				VcontrolliStabilitaObj.IsPersistent = true;
				VcontrolliStabilitaCollectionObj.Add(VcontrolliStabilitaObj);
			}
			db.Close();
			return VcontrolliStabilitaCollectionObj;
		}

		//Find Find

		public static VcontrolliStabilitaCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis, 
SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.StringNT InterventoEqualThis, SiarLibrary.NullTypes.StringNT CodiceFiscaleEqualThis)

		{

			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionObj = new VcontrolliStabilitaCollection();

			IDbCommand findCmd = db.InitCmd("Zvcontrollistabilitafindfind", new string[] {"IdProgettoequalthis", "IdBandoequalthis", "Asseequalthis", 
"Azioneequalthis", "Interventoequalthis", "CodiceFiscaleequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceFiscaleequalthis", CodiceFiscaleEqualThis);
			VcontrolliStabilita VcontrolliStabilitaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcontrolliStabilitaObj = GetFromDatareader(db);
				VcontrolliStabilitaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcontrolliStabilitaObj.IsDirty = false;
				VcontrolliStabilitaObj.IsPersistent = true;
				VcontrolliStabilitaCollectionObj.Add(VcontrolliStabilitaObj);
			}
			db.Close();
			return VcontrolliStabilitaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcontrolliStabilitaCollectionProvider:IVcontrolliStabilitaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcontrolliStabilitaCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcontrolliStabilita
		protected VcontrolliStabilitaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcontrolliStabilitaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcontrolliStabilitaCollection();
		}

		//Costruttore 2: popola la collection
		public VcontrolliStabilitaCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, StringNT AsseEqualThis, 
StringNT AzioneEqualThis, StringNT InterventoEqualThis, StringNT CodicefiscaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdbandoEqualThis, AsseEqualThis, 
AzioneEqualThis, InterventoEqualThis, CodicefiscaleEqualThis);
		}

		//Costruttore3: ha in input vcontrollistabilitaCollectionObj - non popola la collection
		public VcontrolliStabilitaCollectionProvider(VcontrolliStabilitaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcontrolliStabilitaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcontrolliStabilitaCollection();
		}

		//Get e Set
		public VcontrolliStabilitaCollection CollectionObj
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
		public VcontrolliStabilitaCollection Select(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, StringNT DescrizioneEqualThis, 
StringNT AsseEqualThis, StringNT AzioneEqualThis, StringNT InterventoEqualThis, 
StringNT DescrizioneinterventoEqualThis, StringNT RagionesocialeEqualThis, StringNT CodicefiscaleEqualThis, 
DecimalNT SpesaammessarendicontataEqualThis, DecimalNT ContributoammissibileEqualThis, DecimalNT ImportoliquidatoEqualThis, 
DatetimeNT DatadecretoEqualThis)
		{
			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionTemp = VcontrolliStabilitaDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis, DescrizioneEqualThis, 
AsseEqualThis, AzioneEqualThis, InterventoEqualThis, 
DescrizioneinterventoEqualThis, RagionesocialeEqualThis, CodicefiscaleEqualThis, 
SpesaammessarendicontataEqualThis, ContributoammissibileEqualThis, ImportoliquidatoEqualThis, 
DatadecretoEqualThis);
			return VcontrolliStabilitaCollectionTemp;
		}

		//Find: popola la collection
		public VcontrolliStabilitaCollection Find(IntNT IdprogettoEqualThis, IntNT IdbandoEqualThis, StringNT AsseEqualThis, 
StringNT AzioneEqualThis, StringNT InterventoEqualThis, StringNT CodicefiscaleEqualThis)
		{
			VcontrolliStabilitaCollection VcontrolliStabilitaCollectionTemp = VcontrolliStabilitaDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdbandoEqualThis, AsseEqualThis, 
AzioneEqualThis, InterventoEqualThis, CodicefiscaleEqualThis);
			return VcontrolliStabilitaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vCONTROLLI_STABILITA>
  <ViewName>vCONTROLLI_STABILITA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_AGGIORNAMENTO</txtNomeCampoDataModifica>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ASSE>Equal</ASSE>
      <AZIONE>Equal</AZIONE>
      <INTERVENTO>Equal</INTERVENTO>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
      <ASSE>Equal</ASSE>
      <AZIONE>Equal</AZIONE>
      <INTERVENTO>Equal</INTERVENTO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vCONTROLLI_STABILITA>
*/
