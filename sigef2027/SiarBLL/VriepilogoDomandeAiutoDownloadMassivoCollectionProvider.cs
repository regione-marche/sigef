using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VriepilogoDomandeAiutoDownloadMassivo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VriepilogoDomandeAiutoDownloadMassivo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _OperatoreCreazione;
		private NullTypes.StringNT _RagioneSociale;
		private NullTypes.StringNT _Cuaa;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.BoolNT _Eseguito;
		private NullTypes.IntNT _IdTicket;
		private NullTypes.DecimalNT _DimensioneFile;
		private NullTypes.DatetimeNT _DataFineEstrazione;


		//Costruttore
		public VriepilogoDomandeAiutoDownloadMassivo()
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
		/// Corrisponde al campo:CUAA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Cuaa
		{
			get { return _Cuaa; }
			set {
				if (Cuaa != value)
				{
					_Cuaa = value;
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
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CfOperatore
		{
			get { return _CfOperatore; }
			set {
				if (CfOperatore != value)
				{
					_CfOperatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ESEGUITO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Eseguito
		{
			get { return _Eseguito; }
			set {
				if (Eseguito != value)
				{
					_Eseguito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_TICKET
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdTicket
		{
			get { return _IdTicket; }
			set {
				if (IdTicket != value)
				{
					_IdTicket = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DIMENSIONE_FILE
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT DimensioneFile
		{
			get { return _DimensioneFile; }
			set {
				if (DimensioneFile != value)
				{
					_DimensioneFile = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_FINE_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataFineEstrazione
		{
			get { return _DataFineEstrazione; }
			set {
				if (DataFineEstrazione != value)
				{
					_DataFineEstrazione = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VriepilogoDomandeAiutoDownloadMassivoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VriepilogoDomandeAiutoDownloadMassivoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VriepilogoDomandeAiutoDownloadMassivoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VriepilogoDomandeAiutoDownloadMassivo) info.GetValue(i.ToString(),typeof(VriepilogoDomandeAiutoDownloadMassivo)));
			}
		}

		//Costruttore
		public VriepilogoDomandeAiutoDownloadMassivoCollection()
		{
			this.ItemType = typeof(VriepilogoDomandeAiutoDownloadMassivo);
		}

		//Get e Set
		public new VriepilogoDomandeAiutoDownloadMassivo this[int index]
		{
			get { return (VriepilogoDomandeAiutoDownloadMassivo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VriepilogoDomandeAiutoDownloadMassivoCollection GetChanges()
		{
			return (VriepilogoDomandeAiutoDownloadMassivoCollection) base.GetChanges();
		}

		//Add
		public int Add(VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj)
		{
			return base.Add(VriepilogoDomandeAiutoDownloadMassivoObj);
		}

		//AddCollection
		public void AddCollection(VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionObj)
		{
			foreach (VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj in VriepilogoDomandeAiutoDownloadMassivoCollectionObj)
				this.Add(VriepilogoDomandeAiutoDownloadMassivoObj);
		}

		//Insert
		public void Insert(int index, VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj)
		{
			base.Insert(index, VriepilogoDomandeAiutoDownloadMassivoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VriepilogoDomandeAiutoDownloadMassivoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.StringNT RagioneSocialeEqualThis, 
NullTypes.StringNT CuaaEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.StringNT CfOperatoreEqualThis, 
NullTypes.BoolNT EseguitoEqualThis, NullTypes.IntNT IdTicketEqualThis, NullTypes.DecimalNT DimensioneFileEqualThis, 
NullTypes.DatetimeNT DataFineEstrazioneEqualThis)
		{
			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionTemp = new VriepilogoDomandeAiutoDownloadMassivoCollection();
			foreach (VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.IdProgetto != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((OperatoreCreazioneEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.OperatoreCreazione != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((RagioneSocialeEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.RagioneSociale != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.RagioneSociale.Value == RagioneSocialeEqualThis.Value))) && 
((CuaaEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.Cuaa != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.Cuaa.Value == CuaaEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.Segnatura != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.CfOperatore != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && 
((EseguitoEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.Eseguito != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.Eseguito.Value == EseguitoEqualThis.Value))) && ((IdTicketEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.IdTicket != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.IdTicket.Value == IdTicketEqualThis.Value))) && ((DimensioneFileEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.DimensioneFile != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.DimensioneFile.Value == DimensioneFileEqualThis.Value))) && 
((DataFineEstrazioneEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.DataFineEstrazione != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.DataFineEstrazione.Value == DataFineEstrazioneEqualThis.Value))))
				{
					VriepilogoDomandeAiutoDownloadMassivoCollectionTemp.Add(VriepilogoDomandeAiutoDownloadMassivoItem);
				}
			}
			return VriepilogoDomandeAiutoDownloadMassivoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VriepilogoDomandeAiutoDownloadMassivoCollection Filter(NullTypes.IntNT OperatoreCreazioneEqualThis, NullTypes.StringNT CfOperatoreEqualThis)
		{
			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionTemp = new VriepilogoDomandeAiutoDownloadMassivoCollection();
			foreach (VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoItem in this)
			{
				if (((OperatoreCreazioneEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.OperatoreCreazione != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.OperatoreCreazione.Value == OperatoreCreazioneEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VriepilogoDomandeAiutoDownloadMassivoItem.CfOperatore != null) && (VriepilogoDomandeAiutoDownloadMassivoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))))
				{
					VriepilogoDomandeAiutoDownloadMassivoCollectionTemp.Add(VriepilogoDomandeAiutoDownloadMassivoItem);
				}
			}
			return VriepilogoDomandeAiutoDownloadMassivoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VriepilogoDomandeAiutoDownloadMassivoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VriepilogoDomandeAiutoDownloadMassivoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VriepilogoDomandeAiutoDownloadMassivo GetFromDatareader(DbProvider db)
		{
			VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj = new VriepilogoDomandeAiutoDownloadMassivo();
			VriepilogoDomandeAiutoDownloadMassivoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.OperatoreCreazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE_CREAZIONE"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.Eseguito = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESEGUITO"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.IdTicket = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TICKET"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.DimensioneFile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DIMENSIONE_FILE"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.DataFineEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_ESTRAZIONE"]);
			VriepilogoDomandeAiutoDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VriepilogoDomandeAiutoDownloadMassivoObj.IsDirty = false;
			VriepilogoDomandeAiutoDownloadMassivoObj.IsPersistent = true;
			return VriepilogoDomandeAiutoDownloadMassivoObj;
		}

		//Find Select

		public static VriepilogoDomandeAiutoDownloadMassivoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT EseguitoEqualThis, SiarLibrary.NullTypes.IntNT IdTicketEqualThis, SiarLibrary.NullTypes.DecimalNT DimensioneFileEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEstrazioneEqualThis)

		{

			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionObj = new VriepilogoDomandeAiutoDownloadMassivoCollection();

			IDbCommand findCmd = db.InitCmd("Zvriepilogodomandeaiutodownloadmassivofindselect", new string[] {"IdProgettoequalthis", "OperatoreCreazioneequalthis", "RagioneSocialeequalthis", 
"Cuaaequalthis", "Segnaturaequalthis", "CfOperatoreequalthis", 
"Eseguitoequalthis", "IdTicketequalthis", "DimensioneFileequalthis", 
"DataFineEstrazioneequalthis"}, new string[] {"int", "int", "string", 
"string", "string", "string", 
"bool", "int", "decimal", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eseguitoequalthis", EseguitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DimensioneFileequalthis", DimensioneFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineEstrazioneequalthis", DataFineEstrazioneEqualThis);
			VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VriepilogoDomandeAiutoDownloadMassivoObj = GetFromDatareader(db);
				VriepilogoDomandeAiutoDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VriepilogoDomandeAiutoDownloadMassivoObj.IsDirty = false;
				VriepilogoDomandeAiutoDownloadMassivoObj.IsPersistent = true;
				VriepilogoDomandeAiutoDownloadMassivoCollectionObj.Add(VriepilogoDomandeAiutoDownloadMassivoObj);
			}
			db.Close();
			return VriepilogoDomandeAiutoDownloadMassivoCollectionObj;
		}

		//Find Find

		public static VriepilogoDomandeAiutoDownloadMassivoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT OperatoreCreazioneEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.IntNT IdTicketEqualThis)

		{

			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionObj = new VriepilogoDomandeAiutoDownloadMassivoCollection();

			IDbCommand findCmd = db.InitCmd("Zvriepilogodomandeaiutodownloadmassivofindfind", new string[] {"IdProgettoequalthis", "OperatoreCreazioneequalthis", "Cuaaequalthis", 
"CfOperatoreequalthis", "IdTicketequalthis"}, new string[] {"int", "int", "string", 
"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OperatoreCreazioneequalthis", OperatoreCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			VriepilogoDomandeAiutoDownloadMassivo VriepilogoDomandeAiutoDownloadMassivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VriepilogoDomandeAiutoDownloadMassivoObj = GetFromDatareader(db);
				VriepilogoDomandeAiutoDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VriepilogoDomandeAiutoDownloadMassivoObj.IsDirty = false;
				VriepilogoDomandeAiutoDownloadMassivoObj.IsPersistent = true;
				VriepilogoDomandeAiutoDownloadMassivoCollectionObj.Add(VriepilogoDomandeAiutoDownloadMassivoObj);
			}
			db.Close();
			return VriepilogoDomandeAiutoDownloadMassivoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VriepilogoDomandeAiutoDownloadMassivoCollectionProvider:IVriepilogoDomandeAiutoDownloadMassivoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VriepilogoDomandeAiutoDownloadMassivoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VriepilogoDomandeAiutoDownloadMassivo
		protected VriepilogoDomandeAiutoDownloadMassivoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VriepilogoDomandeAiutoDownloadMassivoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VriepilogoDomandeAiutoDownloadMassivoCollection();
		}

		//Costruttore 2: popola la collection
		public VriepilogoDomandeAiutoDownloadMassivoCollectionProvider(IntNT IdprogettoEqualThis, IntNT OperatorecreazioneEqualThis, StringNT CuaaEqualThis, 
StringNT CfoperatoreEqualThis, IntNT IdticketEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, OperatorecreazioneEqualThis, CuaaEqualThis, 
CfoperatoreEqualThis, IdticketEqualThis);
		}

		//Costruttore3: ha in input vriepilogodomandeaiutodownloadmassivoCollectionObj - non popola la collection
		public VriepilogoDomandeAiutoDownloadMassivoCollectionProvider(VriepilogoDomandeAiutoDownloadMassivoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VriepilogoDomandeAiutoDownloadMassivoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VriepilogoDomandeAiutoDownloadMassivoCollection();
		}

		//Get e Set
		public VriepilogoDomandeAiutoDownloadMassivoCollection CollectionObj
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
		public VriepilogoDomandeAiutoDownloadMassivoCollection Select(IntNT IdprogettoEqualThis, IntNT OperatorecreazioneEqualThis, StringNT RagionesocialeEqualThis, 
StringNT CuaaEqualThis, StringNT SegnaturaEqualThis, StringNT CfoperatoreEqualThis, 
BoolNT EseguitoEqualThis, IntNT IdticketEqualThis, DecimalNT DimensionefileEqualThis, 
DatetimeNT DatafineestrazioneEqualThis)
		{
			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionTemp = VriepilogoDomandeAiutoDownloadMassivoDAL.Select(_dbProviderObj, IdprogettoEqualThis, OperatorecreazioneEqualThis, RagionesocialeEqualThis, 
CuaaEqualThis, SegnaturaEqualThis, CfoperatoreEqualThis, 
EseguitoEqualThis, IdticketEqualThis, DimensionefileEqualThis, 
DatafineestrazioneEqualThis);
			return VriepilogoDomandeAiutoDownloadMassivoCollectionTemp;
		}

		//Find: popola la collection
		public VriepilogoDomandeAiutoDownloadMassivoCollection Find(IntNT IdprogettoEqualThis, IntNT OperatorecreazioneEqualThis, StringNT CuaaEqualThis, 
StringNT CfoperatoreEqualThis, IntNT IdticketEqualThis)
		{
			VriepilogoDomandeAiutoDownloadMassivoCollection VriepilogoDomandeAiutoDownloadMassivoCollectionTemp = VriepilogoDomandeAiutoDownloadMassivoDAL.Find(_dbProviderObj, IdprogettoEqualThis, OperatorecreazioneEqualThis, CuaaEqualThis, 
CfoperatoreEqualThis, IdticketEqualThis);
			return VriepilogoDomandeAiutoDownloadMassivoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRIEPILOGO_DOMANDE_AIUTO_DOWNLOAD_MASSIVO>
  <ViewName>vRIEPILOGO_DOMANDE_AIUTO_DOWNLOAD_MASSIVO</ViewName>
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
      <OPERATORE_CREAZIONE>Equal</OPERATORE_CREAZIONE>
      <CUAA>Equal</CUAA>
      <CF_OPERATORE>Equal</CF_OPERATORE>
      <ID_TICKET>Equal</ID_TICKET>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <OPERATORE_CREAZIONE>Equal</OPERATORE_CREAZIONE>
      <CF_OPERATORE>Equal</CF_OPERATORE>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vRIEPILOGO_DOMANDE_AIUTO_DOWNLOAD_MASSIVO>
*/
