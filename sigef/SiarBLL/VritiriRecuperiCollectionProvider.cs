using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VritiriRecuperi
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VritiriRecuperi: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodAzione;
		private NullTypes.StringNT _DescAzione;
		private NullTypes.IntNT _IdRitiro;
		private NullTypes.StringNT _TipoRitiro;
		private NullTypes.StringNT _Tipo;
		private NullTypes.StringNT _Beneficiario;
		private NullTypes.StringNT _SoggettoOrigine;
		private NullTypes.StringNT _NumeroProtocollo;
		private NullTypes.DatetimeNT _DataCostatazioneAmministrativa;
		private NullTypes.DecimalNT _Fesr;
		private NullTypes.DecimalNT _Stato;
		private NullTypes.DecimalNT _Regione;
		private NullTypes.DecimalNT _TotalePubblico;
		private NullTypes.IntNT _Privati;
		private NullTypes.IntNT _IdAzione;


		//Costruttore
		public VritiriRecuperi()
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
		/// Corrisponde al campo:COD_AZIONE
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodAzione
		{
			get { return _CodAzione; }
			set {
				if (CodAzione != value)
				{
					_CodAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESC_AZIONE
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescAzione
		{
			get { return _DescAzione; }
			set {
				if (DescAzione != value)
				{
					_DescAzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RITIRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRitiro
		{
			get { return _IdRitiro; }
			set {
				if (IdRitiro != value)
				{
					_IdRitiro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO_RITIRO
		/// Tipo sul db:VARCHAR(12)
		/// </summary>
		public NullTypes.StringNT TipoRitiro
		{
			get { return _TipoRitiro; }
			set {
				if (TipoRitiro != value)
				{
					_TipoRitiro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TIPO
		/// Tipo sul db:VARCHAR(6)
		/// </summary>
		public NullTypes.StringNT Tipo
		{
			get { return _Tipo; }
			set {
				if (Tipo != value)
				{
					_Tipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:BENEFICIARIO
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Beneficiario
		{
			get { return _Beneficiario; }
			set {
				if (Beneficiario != value)
				{
					_Beneficiario = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SOGGETTO_ORIGINE
		/// Tipo sul db:NVARCHAR(4000)
		/// </summary>
		public NullTypes.StringNT SoggettoOrigine
		{
			get { return _SoggettoOrigine; }
			set {
				if (SoggettoOrigine != value)
				{
					_SoggettoOrigine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERO_PROTOCOLLO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT NumeroProtocollo
		{
			get { return _NumeroProtocollo; }
			set {
				if (NumeroProtocollo != value)
				{
					_NumeroProtocollo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_COSTATAZIONE_AMMINISTRATIVA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataCostatazioneAmministrativa
		{
			get { return _DataCostatazioneAmministrativa; }
			set {
				if (DataCostatazioneAmministrativa != value)
				{
					_DataCostatazioneAmministrativa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FESR
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Fesr
		{
			get { return _Fesr; }
			set {
				if (Fesr != value)
				{
					_Fesr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Stato
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
		/// Corrisponde al campo:REGIONE
		/// Tipo sul db:NUMERIC
		/// </summary>
		public NullTypes.DecimalNT Regione
		{
			get { return _Regione; }
			set {
				if (Regione != value)
				{
					_Regione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TOTALE_PUBBLICO
		/// Tipo sul db:DECIMAL(15,2)
		/// </summary>
		public NullTypes.DecimalNT TotalePubblico
		{
			get { return _TotalePubblico; }
			set {
				if (TotalePubblico != value)
				{
					_TotalePubblico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PRIVATI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Privati
		{
			get { return _Privati; }
			set {
				if (Privati != value)
				{
					_Privati = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_AZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdAzione
		{
			get { return _IdAzione; }
			set {
				if (IdAzione != value)
				{
					_IdAzione = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VritiriRecuperiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VritiriRecuperiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VritiriRecuperiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VritiriRecuperi) info.GetValue(i.ToString(),typeof(VritiriRecuperi)));
			}
		}

		//Costruttore
		public VritiriRecuperiCollection()
		{
			this.ItemType = typeof(VritiriRecuperi);
		}

		//Get e Set
		public new VritiriRecuperi this[int index]
		{
			get { return (VritiriRecuperi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VritiriRecuperiCollection GetChanges()
		{
			return (VritiriRecuperiCollection) base.GetChanges();
		}

		//Add
		public int Add(VritiriRecuperi VritiriRecuperiObj)
		{
			return base.Add(VritiriRecuperiObj);
		}

		//AddCollection
		public void AddCollection(VritiriRecuperiCollection VritiriRecuperiCollectionObj)
		{
			foreach (VritiriRecuperi VritiriRecuperiObj in VritiriRecuperiCollectionObj)
				this.Add(VritiriRecuperiObj);
		}

		//Insert
		public void Insert(int index, VritiriRecuperi VritiriRecuperiObj)
		{
			base.Insert(index, VritiriRecuperiObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VritiriRecuperiCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodAzioneEqualThis, NullTypes.StringNT DescAzioneEqualThis, 
NullTypes.IntNT IdRitiroEqualThis, NullTypes.StringNT TipoRitiroEqualThis, NullTypes.StringNT TipoEqualThis, 
NullTypes.StringNT BeneficiarioEqualThis, NullTypes.StringNT SoggettoOrigineEqualThis, NullTypes.StringNT NumeroProtocolloEqualThis, 
NullTypes.DatetimeNT DataCostatazioneAmministrativaEqualThis, NullTypes.DecimalNT FesrEqualThis, NullTypes.DecimalNT StatoEqualThis, 
NullTypes.DecimalNT RegioneEqualThis, NullTypes.DecimalNT TotalePubblicoEqualThis, NullTypes.IntNT PrivatiEqualThis, 
NullTypes.IntNT IdAzioneEqualThis)
		{
			VritiriRecuperiCollection VritiriRecuperiCollectionTemp = new VritiriRecuperiCollection();
			foreach (VritiriRecuperi VritiriRecuperiItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((VritiriRecuperiItem.IdProgetto != null) && (VritiriRecuperiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodAzioneEqualThis == null) || ((VritiriRecuperiItem.CodAzione != null) && (VritiriRecuperiItem.CodAzione.Value == CodAzioneEqualThis.Value))) && ((DescAzioneEqualThis == null) || ((VritiriRecuperiItem.DescAzione != null) && (VritiriRecuperiItem.DescAzione.Value == DescAzioneEqualThis.Value))) && 
((IdRitiroEqualThis == null) || ((VritiriRecuperiItem.IdRitiro != null) && (VritiriRecuperiItem.IdRitiro.Value == IdRitiroEqualThis.Value))) && ((TipoRitiroEqualThis == null) || ((VritiriRecuperiItem.TipoRitiro != null) && (VritiriRecuperiItem.TipoRitiro.Value == TipoRitiroEqualThis.Value))) && ((TipoEqualThis == null) || ((VritiriRecuperiItem.Tipo != null) && (VritiriRecuperiItem.Tipo.Value == TipoEqualThis.Value))) && 
((BeneficiarioEqualThis == null) || ((VritiriRecuperiItem.Beneficiario != null) && (VritiriRecuperiItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SoggettoOrigineEqualThis == null) || ((VritiriRecuperiItem.SoggettoOrigine != null) && (VritiriRecuperiItem.SoggettoOrigine.Value == SoggettoOrigineEqualThis.Value))) && ((NumeroProtocolloEqualThis == null) || ((VritiriRecuperiItem.NumeroProtocollo != null) && (VritiriRecuperiItem.NumeroProtocollo.Value == NumeroProtocolloEqualThis.Value))) && 
((DataCostatazioneAmministrativaEqualThis == null) || ((VritiriRecuperiItem.DataCostatazioneAmministrativa != null) && (VritiriRecuperiItem.DataCostatazioneAmministrativa.Value == DataCostatazioneAmministrativaEqualThis.Value))) && ((FesrEqualThis == null) || ((VritiriRecuperiItem.Fesr != null) && (VritiriRecuperiItem.Fesr.Value == FesrEqualThis.Value))) && ((StatoEqualThis == null) || ((VritiriRecuperiItem.Stato != null) && (VritiriRecuperiItem.Stato.Value == StatoEqualThis.Value))) && 
((RegioneEqualThis == null) || ((VritiriRecuperiItem.Regione != null) && (VritiriRecuperiItem.Regione.Value == RegioneEqualThis.Value))) && ((TotalePubblicoEqualThis == null) || ((VritiriRecuperiItem.TotalePubblico != null) && (VritiriRecuperiItem.TotalePubblico.Value == TotalePubblicoEqualThis.Value))) && ((PrivatiEqualThis == null) || ((VritiriRecuperiItem.Privati != null) && (VritiriRecuperiItem.Privati.Value == PrivatiEqualThis.Value))) && 
((IdAzioneEqualThis == null) || ((VritiriRecuperiItem.IdAzione != null) && (VritiriRecuperiItem.IdAzione.Value == IdAzioneEqualThis.Value))))
				{
					VritiriRecuperiCollectionTemp.Add(VritiriRecuperiItem);
				}
			}
			return VritiriRecuperiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VritiriRecuperiCollection Filter(NullTypes.IntNT IdRitiroEqualThis)
		{
			VritiriRecuperiCollection VritiriRecuperiCollectionTemp = new VritiriRecuperiCollection();
			foreach (VritiriRecuperi VritiriRecuperiItem in this)
			{
				if (((IdRitiroEqualThis == null) || ((VritiriRecuperiItem.IdRitiro != null) && (VritiriRecuperiItem.IdRitiro.Value == IdRitiroEqualThis.Value))))
				{
					VritiriRecuperiCollectionTemp.Add(VritiriRecuperiItem);
				}
			}
			return VritiriRecuperiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VritiriRecuperiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VritiriRecuperiDAL
	{

		//Operazioni

		//getFromDatareader
		public static VritiriRecuperi GetFromDatareader(DbProvider db)
		{
			VritiriRecuperi VritiriRecuperiObj = new VritiriRecuperi();
			VritiriRecuperiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VritiriRecuperiObj.CodAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_AZIONE"]);
			VritiriRecuperiObj.DescAzione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESC_AZIONE"]);
			VritiriRecuperiObj.IdRitiro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RITIRO"]);
			VritiriRecuperiObj.TipoRitiro = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_RITIRO"]);
			VritiriRecuperiObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
			VritiriRecuperiObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["BENEFICIARIO"]);
			VritiriRecuperiObj.SoggettoOrigine = new SiarLibrary.NullTypes.StringNT(db.DataReader["SOGGETTO_ORIGINE"]);
			VritiriRecuperiObj.NumeroProtocollo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_PROTOCOLLO"]);
			VritiriRecuperiObj.DataCostatazioneAmministrativa = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_COSTATAZIONE_AMMINISTRATIVA"]);
			VritiriRecuperiObj.Fesr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["FESR"]);
			VritiriRecuperiObj.Stato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["STATO"]);
			VritiriRecuperiObj.Regione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["REGIONE"]);
			VritiriRecuperiObj.TotalePubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_PUBBLICO"]);
			VritiriRecuperiObj.Privati = new SiarLibrary.NullTypes.IntNT(db.DataReader["PRIVATI"]);
			VritiriRecuperiObj.IdAzione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_AZIONE"]);
			VritiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VritiriRecuperiObj.IsDirty = false;
			VritiriRecuperiObj.IsPersistent = true;
			return VritiriRecuperiObj;
		}

		//Find Select

		public static VritiriRecuperiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodAzioneEqualThis, SiarLibrary.NullTypes.StringNT DescAzioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdRitiroEqualThis, SiarLibrary.NullTypes.StringNT TipoRitiroEqualThis, SiarLibrary.NullTypes.StringNT TipoEqualThis, 
SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.StringNT SoggettoOrigineEqualThis, SiarLibrary.NullTypes.StringNT NumeroProtocolloEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCostatazioneAmministrativaEqualThis, SiarLibrary.NullTypes.DecimalNT FesrEqualThis, SiarLibrary.NullTypes.DecimalNT StatoEqualThis, 
SiarLibrary.NullTypes.DecimalNT RegioneEqualThis, SiarLibrary.NullTypes.DecimalNT TotalePubblicoEqualThis, SiarLibrary.NullTypes.IntNT PrivatiEqualThis, 
SiarLibrary.NullTypes.IntNT IdAzioneEqualThis)

		{

			VritiriRecuperiCollection VritiriRecuperiCollectionObj = new VritiriRecuperiCollection();

			IDbCommand findCmd = db.InitCmd("Zvritirirecuperifindselect", new string[] {"IdProgettoequalthis", "CodAzioneequalthis", "DescAzioneequalthis", 
"IdRitiroequalthis", "TipoRitiroequalthis", "Tipoequalthis", 
"Beneficiarioequalthis", "SoggettoOrigineequalthis", "NumeroProtocolloequalthis", 
"DataCostatazioneAmministrativaequalthis", "Fesrequalthis", "Statoequalthis", 
"Regioneequalthis", "TotalePubblicoequalthis", "Privatiequalthis", 
"IdAzioneequalthis"}, new string[] {"int", "string", "string", 
"int", "string", "string", 
"string", "string", "string", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "int", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodAzioneequalthis", CodAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescAzioneequalthis", DescAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRitiroequalthis", IdRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoRitiroequalthis", TipoRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SoggettoOrigineequalthis", SoggettoOrigineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroProtocolloequalthis", NumeroProtocolloEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCostatazioneAmministrativaequalthis", DataCostatazioneAmministrativaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Fesrequalthis", FesrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Regioneequalthis", RegioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TotalePubblicoequalthis", TotalePubblicoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Privatiequalthis", PrivatiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneequalthis", IdAzioneEqualThis);
			VritiriRecuperi VritiriRecuperiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VritiriRecuperiObj = GetFromDatareader(db);
				VritiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VritiriRecuperiObj.IsDirty = false;
				VritiriRecuperiObj.IsPersistent = true;
				VritiriRecuperiCollectionObj.Add(VritiriRecuperiObj);
			}
			db.Close();
			return VritiriRecuperiCollectionObj;
		}

		//Find Find

		public static VritiriRecuperiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdRitiroEqualThis, SiarLibrary.NullTypes.StringNT TipoRitiroEqualThis, 
SiarLibrary.NullTypes.StringNT TipoEqualThis, SiarLibrary.NullTypes.IntNT IdAzioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataCostatazioneAmministrativaEqGreaterThanThis, 
SiarLibrary.NullTypes.DatetimeNT DataCostatazioneAmministrativaEqLessThanThis)

		{

			VritiriRecuperiCollection VritiriRecuperiCollectionObj = new VritiriRecuperiCollection();

			IDbCommand findCmd = db.InitCmd("Zvritirirecuperifindfind", new string[] {"IdProgettoequalthis", "IdRitiroequalthis", "TipoRitiroequalthis", 
"Tipoequalthis", "IdAzioneequalthis", "DataCostatazioneAmministrativaeqgreaterthanthis", 
"DataCostatazioneAmministrativaeqlessthanthis"}, new string[] {"int", "int", "string", 
"string", "int", "DateTime", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRitiroequalthis", IdRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoRitiroequalthis", TipoRitiroEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Tipoequalthis", TipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdAzioneequalthis", IdAzioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCostatazioneAmministrativaeqgreaterthanthis", DataCostatazioneAmministrativaEqGreaterThanThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCostatazioneAmministrativaeqlessthanthis", DataCostatazioneAmministrativaEqLessThanThis);
			VritiriRecuperi VritiriRecuperiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VritiriRecuperiObj = GetFromDatareader(db);
				VritiriRecuperiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VritiriRecuperiObj.IsDirty = false;
				VritiriRecuperiObj.IsPersistent = true;
				VritiriRecuperiCollectionObj.Add(VritiriRecuperiObj);
			}
			db.Close();
			return VritiriRecuperiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VritiriRecuperiCollectionProvider:IVritiriRecuperiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VritiriRecuperiCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VritiriRecuperi
		protected VritiriRecuperiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VritiriRecuperiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VritiriRecuperiCollection();
		}

		//Costruttore 2: popola la collection
		public VritiriRecuperiCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdritiroEqualThis, StringNT TiporitiroEqualThis, 
StringNT TipoEqualThis, IntNT IdazioneEqualThis, DatetimeNT DatacostatazioneamministrativaEqGreaterThanThis, 
DatetimeNT DatacostatazioneamministrativaEqLessThanThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdritiroEqualThis, TiporitiroEqualThis, 
TipoEqualThis, IdazioneEqualThis, DatacostatazioneamministrativaEqGreaterThanThis, 
DatacostatazioneamministrativaEqLessThanThis);
		}

		//Costruttore3: ha in input vritirirecuperiCollectionObj - non popola la collection
		public VritiriRecuperiCollectionProvider(VritiriRecuperiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VritiriRecuperiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VritiriRecuperiCollection();
		}

		//Get e Set
		public VritiriRecuperiCollection CollectionObj
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
		public VritiriRecuperiCollection Select(IntNT IdprogettoEqualThis, StringNT CodazioneEqualThis, StringNT DescazioneEqualThis, 
IntNT IdritiroEqualThis, StringNT TiporitiroEqualThis, StringNT TipoEqualThis, 
StringNT BeneficiarioEqualThis, StringNT SoggettoorigineEqualThis, StringNT NumeroprotocolloEqualThis, 
DatetimeNT DatacostatazioneamministrativaEqualThis, DecimalNT FesrEqualThis, DecimalNT StatoEqualThis, 
DecimalNT RegioneEqualThis, DecimalNT TotalepubblicoEqualThis, IntNT PrivatiEqualThis, 
IntNT IdazioneEqualThis)
		{
			VritiriRecuperiCollection VritiriRecuperiCollectionTemp = VritiriRecuperiDAL.Select(_dbProviderObj, IdprogettoEqualThis, CodazioneEqualThis, DescazioneEqualThis, 
IdritiroEqualThis, TiporitiroEqualThis, TipoEqualThis, 
BeneficiarioEqualThis, SoggettoorigineEqualThis, NumeroprotocolloEqualThis, 
DatacostatazioneamministrativaEqualThis, FesrEqualThis, StatoEqualThis, 
RegioneEqualThis, TotalepubblicoEqualThis, PrivatiEqualThis, 
IdazioneEqualThis);
			return VritiriRecuperiCollectionTemp;
		}

		//Find: popola la collection
		public VritiriRecuperiCollection Find(IntNT IdprogettoEqualThis, IntNT IdritiroEqualThis, StringNT TiporitiroEqualThis, 
StringNT TipoEqualThis, IntNT IdazioneEqualThis, DatetimeNT DatacostatazioneamministrativaEqGreaterThanThis, 
DatetimeNT DatacostatazioneamministrativaEqLessThanThis)
		{
			VritiriRecuperiCollection VritiriRecuperiCollectionTemp = VritiriRecuperiDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdritiroEqualThis, TiporitiroEqualThis, 
TipoEqualThis, IdazioneEqualThis, DatacostatazioneamministrativaEqGreaterThanThis, 
DatacostatazioneamministrativaEqLessThanThis);
			return VritiriRecuperiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRITIRI_RECUPERI>
  <ViewName>vRITIRI_RECUPERI</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_RITIRO>Equal</ID_RITIRO>
      <TIPO_RITIRO>Equal</TIPO_RITIRO>
      <TIPO>Equal</TIPO>
      <ID_AZIONE>Equal</ID_AZIONE>
      <DATA_COSTATAZIONE_AMMINISTRATIVA>EqGreaterThan</DATA_COSTATAZIONE_AMMINISTRATIVA>
      <DATA_COSTATAZIONE_AMMINISTRATIVA>EqLessThan</DATA_COSTATAZIONE_AMMINISTRATIVA>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_RITIRO>Equal</ID_RITIRO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vRITIRI_RECUPERI>
*/
