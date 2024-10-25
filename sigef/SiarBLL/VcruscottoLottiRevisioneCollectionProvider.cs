using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoLottiRevisione
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VcruscottoLottiRevisione: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdLotto;
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _Provincia;
		private NullTypes.DatetimeNT _DataCreazione;
		private NullTypes.StringNT _CfOperatore;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _NumeroEstrazioni;
		private NullTypes.BoolNT _RevisioneConclusa;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.DatetimeNT _DataScadenza;


		//Costruttore
		public VcruscottoLottiRevisione()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_LOTTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdLotto
		{
			get { return _IdLotto; }
			set {
				if (IdLotto != value)
				{
					_IdLotto = value;
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
		/// Corrisponde al campo:CF_OPERATORE
		/// Tipo sul db:VARCHAR(16)
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

		/// <summary>
		/// Corrisponde al campo:NUMERO_ESTRAZIONI
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT NumeroEstrazioni
		{
			get { return _NumeroEstrazioni; }
			set {
				if (NumeroEstrazioni != value)
				{
					_NumeroEstrazioni = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:REVISIONE_CONCLUSA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RevisioneConclusa
		{
			get { return _RevisioneConclusa; }
			set {
				if (RevisioneConclusa != value)
				{
					_RevisioneConclusa = value;
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
		/// Corrisponde al campo:DATA_SCADENZA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataScadenza
		{
			get { return _DataScadenza; }
			set {
				if (DataScadenza != value)
				{
					_DataScadenza = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VcruscottoLottiRevisioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoLottiRevisioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VcruscottoLottiRevisioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VcruscottoLottiRevisione) info.GetValue(i.ToString(),typeof(VcruscottoLottiRevisione)));
			}
		}

		//Costruttore
		public VcruscottoLottiRevisioneCollection()
		{
			this.ItemType = typeof(VcruscottoLottiRevisione);
		}

		//Get e Set
		public new VcruscottoLottiRevisione this[int index]
		{
			get { return (VcruscottoLottiRevisione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VcruscottoLottiRevisioneCollection GetChanges()
		{
			return (VcruscottoLottiRevisioneCollection) base.GetChanges();
		}

		//Add
		public int Add(VcruscottoLottiRevisione VcruscottoLottiRevisioneObj)
		{
			return base.Add(VcruscottoLottiRevisioneObj);
		}

		//AddCollection
		public void AddCollection(VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionObj)
		{
			foreach (VcruscottoLottiRevisione VcruscottoLottiRevisioneObj in VcruscottoLottiRevisioneCollectionObj)
				this.Add(VcruscottoLottiRevisioneObj);
		}

		//Insert
		public void Insert(int index, VcruscottoLottiRevisione VcruscottoLottiRevisioneObj)
		{
			base.Insert(index, VcruscottoLottiRevisioneObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VcruscottoLottiRevisioneCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT ProvinciaEqualThis, 
NullTypes.DatetimeNT DataCreazioneEqualThis, NullTypes.StringNT CfOperatoreEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT NumeroEstrazioniEqualThis, NullTypes.BoolNT RevisioneConclusaEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.DatetimeNT DataScadenzaEqualThis)
		{
			VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionTemp = new VcruscottoLottiRevisioneCollection();
			foreach (VcruscottoLottiRevisione VcruscottoLottiRevisioneItem in this)
			{
				if (((IdLottoEqualThis == null) || ((VcruscottoLottiRevisioneItem.IdLotto != null) && (VcruscottoLottiRevisioneItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdBandoEqualThis == null) || ((VcruscottoLottiRevisioneItem.IdBando != null) && (VcruscottoLottiRevisioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((VcruscottoLottiRevisioneItem.Provincia != null) && (VcruscottoLottiRevisioneItem.Provincia.Value == ProvinciaEqualThis.Value))) && 
((DataCreazioneEqualThis == null) || ((VcruscottoLottiRevisioneItem.DataCreazione != null) && (VcruscottoLottiRevisioneItem.DataCreazione.Value == DataCreazioneEqualThis.Value))) && ((CfOperatoreEqualThis == null) || ((VcruscottoLottiRevisioneItem.CfOperatore != null) && (VcruscottoLottiRevisioneItem.CfOperatore.Value == CfOperatoreEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VcruscottoLottiRevisioneItem.DataModifica != null) && (VcruscottoLottiRevisioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((NumeroEstrazioniEqualThis == null) || ((VcruscottoLottiRevisioneItem.NumeroEstrazioni != null) && (VcruscottoLottiRevisioneItem.NumeroEstrazioni.Value == NumeroEstrazioniEqualThis.Value))) && ((RevisioneConclusaEqualThis == null) || ((VcruscottoLottiRevisioneItem.RevisioneConclusa != null) && (VcruscottoLottiRevisioneItem.RevisioneConclusa.Value == RevisioneConclusaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VcruscottoLottiRevisioneItem.Descrizione != null) && (VcruscottoLottiRevisioneItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((DataScadenzaEqualThis == null) || ((VcruscottoLottiRevisioneItem.DataScadenza != null) && (VcruscottoLottiRevisioneItem.DataScadenza.Value == DataScadenzaEqualThis.Value))))
				{
					VcruscottoLottiRevisioneCollectionTemp.Add(VcruscottoLottiRevisioneItem);
				}
			}
			return VcruscottoLottiRevisioneCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VcruscottoLottiRevisioneDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VcruscottoLottiRevisioneDAL
	{

		//Operazioni

		//getFromDatareader
		public static VcruscottoLottiRevisione GetFromDatareader(DbProvider db)
		{
			VcruscottoLottiRevisione VcruscottoLottiRevisioneObj = new VcruscottoLottiRevisione();
			VcruscottoLottiRevisioneObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
			VcruscottoLottiRevisioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VcruscottoLottiRevisioneObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
			VcruscottoLottiRevisioneObj.DataCreazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_CREAZIONE"]);
			VcruscottoLottiRevisioneObj.CfOperatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE"]);
			VcruscottoLottiRevisioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			VcruscottoLottiRevisioneObj.NumeroEstrazioni = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_ESTRAZIONI"]);
			VcruscottoLottiRevisioneObj.RevisioneConclusa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["REVISIONE_CONCLUSA"]);
			VcruscottoLottiRevisioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VcruscottoLottiRevisioneObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
			VcruscottoLottiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VcruscottoLottiRevisioneObj.IsDirty = false;
			VcruscottoLottiRevisioneObj.IsPersistent = true;
			return VcruscottoLottiRevisioneObj;
		}

		//Find Select

		public static VcruscottoLottiRevisioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataCreazioneEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, 
SiarLibrary.NullTypes.IntNT NumeroEstrazioniEqualThis, SiarLibrary.NullTypes.BoolNT RevisioneConclusaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis)

		{

			VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionObj = new VcruscottoLottiRevisioneCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottolottirevisionefindselect", new string[] {"IdLottoequalthis", "IdBandoequalthis", "Provinciaequalthis", 
"DataCreazioneequalthis", "CfOperatoreequalthis", "DataModificaequalthis", 
"NumeroEstrazioniequalthis", "RevisioneConclusaequalthis", "Descrizioneequalthis", 
"DataScadenzaequalthis"}, new string[] {"int", "int", "string", 
"DateTime", "string", "DateTime", 
"int", "bool", "string", 
"DateTime"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataCreazioneequalthis", DataCreazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "NumeroEstrazioniequalthis", NumeroEstrazioniEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RevisioneConclusaequalthis", RevisioneConclusaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
			VcruscottoLottiRevisione VcruscottoLottiRevisioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoLottiRevisioneObj = GetFromDatareader(db);
				VcruscottoLottiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoLottiRevisioneObj.IsDirty = false;
				VcruscottoLottiRevisioneObj.IsPersistent = true;
				VcruscottoLottiRevisioneCollectionObj.Add(VcruscottoLottiRevisioneObj);
			}
			db.Close();
			return VcruscottoLottiRevisioneCollectionObj;
		}

		//Find FindLotti

		public static VcruscottoLottiRevisioneCollection FindLotti(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CfOperatoreEqualThis)

		{

			VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionObj = new VcruscottoLottiRevisioneCollection();

			IDbCommand findCmd = db.InitCmd("Zvcruscottolottirevisionefindfindlotti", new string[] {"IdLottoequalthis", "IdBandoequalthis", "CfOperatoreequalthis"}, new string[] {"int", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfOperatoreequalthis", CfOperatoreEqualThis);
			VcruscottoLottiRevisione VcruscottoLottiRevisioneObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VcruscottoLottiRevisioneObj = GetFromDatareader(db);
				VcruscottoLottiRevisioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VcruscottoLottiRevisioneObj.IsDirty = false;
				VcruscottoLottiRevisioneObj.IsPersistent = true;
				VcruscottoLottiRevisioneCollectionObj.Add(VcruscottoLottiRevisioneObj);
			}
			db.Close();
			return VcruscottoLottiRevisioneCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VcruscottoLottiRevisioneCollectionProvider:IVcruscottoLottiRevisioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VcruscottoLottiRevisioneCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VcruscottoLottiRevisione
		protected VcruscottoLottiRevisioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VcruscottoLottiRevisioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VcruscottoLottiRevisioneCollection();
		}

		//Costruttore 2: popola la collection
		public VcruscottoLottiRevisioneCollectionProvider(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT CfoperatoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindLotti(IdlottoEqualThis, IdbandoEqualThis, CfoperatoreEqualThis);
		}

		//Costruttore3: ha in input vcruscottolottirevisioneCollectionObj - non popola la collection
		public VcruscottoLottiRevisioneCollectionProvider(VcruscottoLottiRevisioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VcruscottoLottiRevisioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VcruscottoLottiRevisioneCollection();
		}

		//Get e Set
		public VcruscottoLottiRevisioneCollection CollectionObj
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
		public VcruscottoLottiRevisioneCollection Select(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT ProvinciaEqualThis, 
DatetimeNT DatacreazioneEqualThis, StringNT CfoperatoreEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT NumeroestrazioniEqualThis, BoolNT RevisioneconclusaEqualThis, StringNT DescrizioneEqualThis, 
DatetimeNT DatascadenzaEqualThis)
		{
			VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionTemp = VcruscottoLottiRevisioneDAL.Select(_dbProviderObj, IdlottoEqualThis, IdbandoEqualThis, ProvinciaEqualThis, 
DatacreazioneEqualThis, CfoperatoreEqualThis, DatamodificaEqualThis, 
NumeroestrazioniEqualThis, RevisioneconclusaEqualThis, DescrizioneEqualThis, 
DatascadenzaEqualThis);
			return VcruscottoLottiRevisioneCollectionTemp;
		}

		//FindLotti: popola la collection
		public VcruscottoLottiRevisioneCollection FindLotti(IntNT IdlottoEqualThis, IntNT IdbandoEqualThis, StringNT CfoperatoreEqualThis)
		{
			VcruscottoLottiRevisioneCollection VcruscottoLottiRevisioneCollectionTemp = VcruscottoLottiRevisioneDAL.FindLotti(_dbProviderObj, IdlottoEqualThis, IdbandoEqualThis, CfoperatoreEqualThis);
			return VcruscottoLottiRevisioneCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vCRUSCOTTO_LOTTI_REVISIONE>
  <ViewName>vCRUSCOTTO_LOTTI_REVISIONE</ViewName>
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
    <FindLotti OrderBy="ORDER BY ">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_BANDO>Equal</ID_BANDO>
      <CF_OPERATORE>Equal</CF_OPERATORE>
    </FindLotti>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vCRUSCOTTO_LOTTI_REVISIONE>
*/
