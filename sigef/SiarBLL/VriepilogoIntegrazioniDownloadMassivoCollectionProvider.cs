using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VriepilogoIntegrazioniDownloadMassivo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VriepilogoIntegrazioniDownloadMassivo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdDomandaPagamento;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.IntNT _IdIntegrazioneDomandaDiPagamento;
		private NullTypes.StringNT _SegnaturaBeneficiario;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.BoolNT _Eseguito;
		private NullTypes.IntNT _IdTicket;
		private NullTypes.DecimalNT _DimensioneFile;
		private NullTypes.DatetimeNT _DataFineEstrazione;


		//Costruttore
		public VriepilogoIntegrazioniDownloadMassivo()
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
		/// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDomandaPagamento
		{
			get { return _IdDomandaPagamento; }
			set {
				if (IdDomandaPagamento != value)
				{
					_IdDomandaPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(100)
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
		/// Corrisponde al campo:ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIntegrazioneDomandaDiPagamento
		{
			get { return _IdIntegrazioneDomandaDiPagamento; }
			set {
				if (IdIntegrazioneDomandaDiPagamento != value)
				{
					_IdIntegrazioneDomandaDiPagamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_BENEFICIARIO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaBeneficiario
		{
			get { return _SegnaturaBeneficiario; }
			set {
				if (SegnaturaBeneficiario != value)
				{
					_SegnaturaBeneficiario = value;
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
	/// Summary description for VriepilogoIntegrazioniDownloadMassivoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VriepilogoIntegrazioniDownloadMassivoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VriepilogoIntegrazioniDownloadMassivoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VriepilogoIntegrazioniDownloadMassivo) info.GetValue(i.ToString(),typeof(VriepilogoIntegrazioniDownloadMassivo)));
			}
		}

		//Costruttore
		public VriepilogoIntegrazioniDownloadMassivoCollection()
		{
			this.ItemType = typeof(VriepilogoIntegrazioniDownloadMassivo);
		}

		//Get e Set
		public new VriepilogoIntegrazioniDownloadMassivo this[int index]
		{
			get { return (VriepilogoIntegrazioniDownloadMassivo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VriepilogoIntegrazioniDownloadMassivoCollection GetChanges()
		{
			return (VriepilogoIntegrazioniDownloadMassivoCollection) base.GetChanges();
		}

		//Add
		public int Add(VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj)
		{
			return base.Add(VriepilogoIntegrazioniDownloadMassivoObj);
		}

		//AddCollection
		public void AddCollection(VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionObj)
		{
			foreach (VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj in VriepilogoIntegrazioniDownloadMassivoCollectionObj)
				this.Add(VriepilogoIntegrazioniDownloadMassivoObj);
		}

		//Insert
		public void Insert(int index, VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj)
		{
			base.Insert(index, VriepilogoIntegrazioniDownloadMassivoObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VriepilogoIntegrazioniDownloadMassivoCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, NullTypes.StringNT SegnaturaBeneficiarioEqualThis, NullTypes.StringNT CfOperatoreEqualThis, 
NullTypes.BoolNT EseguitoEqualThis, NullTypes.IntNT IdTicketEqualThis, NullTypes.DecimalNT DimensioneFileEqualThis, 
NullTypes.DatetimeNT DataFineEstrazioneEqualThis)
		{
			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionTemp = new VriepilogoIntegrazioniDownloadMassivoCollection();
			foreach (VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdProgetto != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdDomandaPagamento != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.Descrizione != null) && (VriepilogoIntegrazioniDownloadMassivoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((IdIntegrazioneDomandaDiPagamentoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdIntegrazioneDomandaDiPagamento != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdIntegrazioneDomandaDiPagamento.Value == IdIntegrazioneDomandaDiPagamentoEqualThis.Value))) && ((SegnaturaBeneficiarioEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.SegnaturaBeneficiario != null) && (VriepilogoIntegrazioniDownloadMassivoItem.SegnaturaBeneficiario.Value == SegnaturaBeneficiarioEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.CfOperatore != null) && (VriepilogoIntegrazioniDownloadMassivoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && 
((EseguitoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.Eseguito != null) && (VriepilogoIntegrazioniDownloadMassivoItem.Eseguito.Value == EseguitoEqualThis.Value))) && ((IdTicketEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdTicket != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdTicket.Value == IdTicketEqualThis.Value))) && ((DimensioneFileEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.DimensioneFile != null) && (VriepilogoIntegrazioniDownloadMassivoItem.DimensioneFile.Value == DimensioneFileEqualThis.Value))) && 
((DataFineEstrazioneEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.DataFineEstrazione != null) && (VriepilogoIntegrazioniDownloadMassivoItem.DataFineEstrazione.Value == DataFineEstrazioneEqualThis.Value))))
				{
					VriepilogoIntegrazioniDownloadMassivoCollectionTemp.Add(VriepilogoIntegrazioniDownloadMassivoItem);
				}
			}
			return VriepilogoIntegrazioniDownloadMassivoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VriepilogoIntegrazioniDownloadMassivoCollection Filter(NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT CfOperatoreEqualThis, 
NullTypes.BoolNT EseguitoEqualThis)
		{
			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionTemp = new VriepilogoIntegrazioniDownloadMassivoCollection();
			foreach (VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdProgetto != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.IdDomandaPagamento != null) && (VriepilogoIntegrazioniDownloadMassivoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.CfOperatore != null) && (VriepilogoIntegrazioniDownloadMassivoItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && 
((EseguitoEqualThis == null) || ((VriepilogoIntegrazioniDownloadMassivoItem.Eseguito != null) && (VriepilogoIntegrazioniDownloadMassivoItem.Eseguito.Value == EseguitoEqualThis.Value))))
				{
					VriepilogoIntegrazioniDownloadMassivoCollectionTemp.Add(VriepilogoIntegrazioniDownloadMassivoItem);
				}
			}
			return VriepilogoIntegrazioniDownloadMassivoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VriepilogoIntegrazioniDownloadMassivoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VriepilogoIntegrazioniDownloadMassivoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VriepilogoIntegrazioniDownloadMassivo GetFromDatareader(DbProvider db)
		{
			VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj = new VriepilogoIntegrazioniDownloadMassivo();
			VriepilogoIntegrazioniDownloadMassivoObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VriepilogoIntegrazioniDownloadMassivoObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
			VriepilogoIntegrazioniDownloadMassivoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VriepilogoIntegrazioniDownloadMassivoObj.IdIntegrazioneDomandaDiPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO"]);
			VriepilogoIntegrazioniDownloadMassivoObj.SegnaturaBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_BENEFICIARIO"]);
			VriepilogoIntegrazioniDownloadMassivoObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			VriepilogoIntegrazioniDownloadMassivoObj.Eseguito = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESEGUITO"]);
			VriepilogoIntegrazioniDownloadMassivoObj.IdTicket = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_TICKET"]);
			VriepilogoIntegrazioniDownloadMassivoObj.DimensioneFile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["DIMENSIONE_FILE"]);
			VriepilogoIntegrazioniDownloadMassivoObj.DataFineEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_ESTRAZIONE"]);
			VriepilogoIntegrazioniDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VriepilogoIntegrazioniDownloadMassivoObj.IsDirty = false;
			VriepilogoIntegrazioniDownloadMassivoObj.IsPersistent = true;
			return VriepilogoIntegrazioniDownloadMassivoObj;
		}

		//Find Select

		public static VriepilogoIntegrazioniDownloadMassivoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaBeneficiarioEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, 
SiarLibrary.NullTypes.BoolNT EseguitoEqualThis, SiarLibrary.NullTypes.IntNT IdTicketEqualThis, SiarLibrary.NullTypes.DecimalNT DimensioneFileEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFineEstrazioneEqualThis)

		{

			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionObj = new VriepilogoIntegrazioniDownloadMassivoCollection();

			IDbCommand findCmd = db.InitCmd("Zvriepilogointegrazionidownloadmassivofindselect", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "Descrizioneequalthis", 
"IdIntegrazioneDomandaDiPagamentoequalthis", "SegnaturaBeneficiarioequalthis", "CfOperatoreequalthis", 
"Eseguitoequalthis", "IdTicketequalthis", "DimensioneFileequalthis", 
"DataFineEstrazioneequalthis"}, new string[] {"int", "int", "string", 
"int", "string", "string", 
"bool", "int", "decimal", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamentoequalthis", IdIntegrazioneDomandaDiPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaBeneficiarioequalthis", SegnaturaBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eseguitoequalthis", EseguitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DimensioneFileequalthis", DimensioneFileEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFineEstrazioneequalthis", DataFineEstrazioneEqualThis);
			VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VriepilogoIntegrazioniDownloadMassivoObj = GetFromDatareader(db);
				VriepilogoIntegrazioniDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VriepilogoIntegrazioniDownloadMassivoObj.IsDirty = false;
				VriepilogoIntegrazioniDownloadMassivoObj.IsPersistent = true;
				VriepilogoIntegrazioniDownloadMassivoCollectionObj.Add(VriepilogoIntegrazioniDownloadMassivoObj);
			}
			db.Close();
			return VriepilogoIntegrazioniDownloadMassivoCollectionObj;
		}

		//Find Find

		public static VriepilogoIntegrazioniDownloadMassivoCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdIntegrazioneDomandaDiPagamentoEqualThis, 
SiarLibrary.NullTypes.StringNT SegnaturaBeneficiarioEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.BoolNT EseguitoEqualThis, 
SiarLibrary.NullTypes.IntNT IdTicketEqualThis)

		{

			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionObj = new VriepilogoIntegrazioniDownloadMassivoCollection();

			IDbCommand findCmd = db.InitCmd("Zvriepilogointegrazionidownloadmassivofindfind", new string[] {"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdIntegrazioneDomandaDiPagamentoequalthis", 
"SegnaturaBeneficiarioequalthis", "CfOperatoreequalthis", "Eseguitoequalthis", 
"IdTicketequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "bool", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIntegrazioneDomandaDiPagamentoequalthis", IdIntegrazioneDomandaDiPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaBeneficiarioequalthis", SegnaturaBeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Eseguitoequalthis", EseguitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdTicketequalthis", IdTicketEqualThis);
			VriepilogoIntegrazioniDownloadMassivo VriepilogoIntegrazioniDownloadMassivoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VriepilogoIntegrazioniDownloadMassivoObj = GetFromDatareader(db);
				VriepilogoIntegrazioniDownloadMassivoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VriepilogoIntegrazioniDownloadMassivoObj.IsDirty = false;
				VriepilogoIntegrazioniDownloadMassivoObj.IsPersistent = true;
				VriepilogoIntegrazioniDownloadMassivoCollectionObj.Add(VriepilogoIntegrazioniDownloadMassivoObj);
			}
			db.Close();
			return VriepilogoIntegrazioniDownloadMassivoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VriepilogoIntegrazioniDownloadMassivoCollectionProvider:IVriepilogoIntegrazioniDownloadMassivoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VriepilogoIntegrazioniDownloadMassivoCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VriepilogoIntegrazioniDownloadMassivo
		protected VriepilogoIntegrazioniDownloadMassivoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VriepilogoIntegrazioniDownloadMassivoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VriepilogoIntegrazioniDownloadMassivoCollection();
		}

		//Costruttore 2: popola la collection
		public VriepilogoIntegrazioniDownloadMassivoCollectionProvider(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdintegrazionedomandadipagamentoEqualThis, 
StringNT SegnaturabeneficiarioEqualThis, StringNT CfoperatoreEqualThis, BoolNT EseguitoEqualThis, 
IntNT IdticketEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IddomandapagamentoEqualThis, IdintegrazionedomandadipagamentoEqualThis, 
SegnaturabeneficiarioEqualThis, CfoperatoreEqualThis, EseguitoEqualThis, 
IdticketEqualThis);
		}

		//Costruttore3: ha in input vriepilogointegrazionidownloadmassivoCollectionObj - non popola la collection
		public VriepilogoIntegrazioniDownloadMassivoCollectionProvider(VriepilogoIntegrazioniDownloadMassivoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VriepilogoIntegrazioniDownloadMassivoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VriepilogoIntegrazioniDownloadMassivoCollection();
		}

		//Get e Set
		public VriepilogoIntegrazioniDownloadMassivoCollection CollectionObj
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
		public VriepilogoIntegrazioniDownloadMassivoCollection Select(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT DescrizioneEqualThis, 
IntNT IdintegrazionedomandadipagamentoEqualThis, StringNT SegnaturabeneficiarioEqualThis, StringNT CfoperatoreEqualThis, 
BoolNT EseguitoEqualThis, IntNT IdticketEqualThis, DecimalNT DimensionefileEqualThis, 
DatetimeNT DatafineestrazioneEqualThis)
		{
			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionTemp = VriepilogoIntegrazioniDownloadMassivoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, DescrizioneEqualThis, 
IdintegrazionedomandadipagamentoEqualThis, SegnaturabeneficiarioEqualThis, CfoperatoreEqualThis, 
EseguitoEqualThis, IdticketEqualThis, DimensionefileEqualThis, 
DatafineestrazioneEqualThis);
			return VriepilogoIntegrazioniDownloadMassivoCollectionTemp;
		}

		//Find: popola la collection
		public VriepilogoIntegrazioniDownloadMassivoCollection Find(IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdintegrazionedomandadipagamentoEqualThis, 
StringNT SegnaturabeneficiarioEqualThis, StringNT CfoperatoreEqualThis, BoolNT EseguitoEqualThis, 
IntNT IdticketEqualThis)
		{
			VriepilogoIntegrazioniDownloadMassivoCollection VriepilogoIntegrazioniDownloadMassivoCollectionTemp = VriepilogoIntegrazioniDownloadMassivoDAL.Find(_dbProviderObj, IdprogettoEqualThis, IddomandapagamentoEqualThis, IdintegrazionedomandadipagamentoEqualThis, 
SegnaturabeneficiarioEqualThis, CfoperatoreEqualThis, EseguitoEqualThis, 
IdticketEqualThis);
			return VriepilogoIntegrazioniDownloadMassivoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRIEPILOGO_INTEGRAZIONI_DOWNLOAD_MASSIVO>
  <ViewName>vRIEPILOGO_INTEGRAZIONI_DOWNLOAD_MASSIVO</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO>Equal</ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO>
      <SEGNATURA_BENEFICIARIO>Equal</SEGNATURA_BENEFICIARIO>
      <CF_OPERATORE>Equal</CF_OPERATORE>
      <ESEGUITO>Equal</ESEGUITO>
      <ID_TICKET>Equal</ID_TICKET>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <CF_OPERATORE>Equal</CF_OPERATORE>
      <ESEGUITO>Equal</ESEGUITO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vRIEPILOGO_INTEGRAZIONI_DOWNLOAD_MASSIVO>
*/
