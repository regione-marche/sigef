using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEsitoVisure
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaEsitoVisure: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _IdRichiesta;
		private NullTypes.StringNT _TipoVisura;
		private NullTypes.IntNT _CodiceEsito;
		private NullTypes.DatetimeNT _DataAggiornamento;
		private NullTypes.IntNT _CodiceStatoRichiesta;
		private NullTypes.StringNT _DescrizioneEsito;
		private NullTypes.StringNT _DescrizioneStatoRichiesta;


		//Costruttore
		public VrnaEsitoVisure()
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
		/// Corrisponde al campo:TIPO_VISURA
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT TipoVisura
		{
			get { return _TipoVisura; }
			set {
				if (TipoVisura != value)
				{
					_TipoVisura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_ESITO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceEsito
		{
			get { return _CodiceEsito; }
			set {
				if (CodiceEsito != value)
				{
					_CodiceEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_AGGIORNAMENTO
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataAggiornamento
		{
			get { return _DataAggiornamento; }
			set {
				if (DataAggiornamento != value)
				{
					_DataAggiornamento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODICE_STATO_RICHIESTA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodiceStatoRichiesta
		{
			get { return _CodiceStatoRichiesta; }
			set {
				if (CodiceStatoRichiesta != value)
				{
					_CodiceStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_ESITO
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneEsito
		{
			get { return _DescrizioneEsito; }
			set {
				if (DescrizioneEsito != value)
				{
					_DescrizioneEsito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_STATO_RICHIESTA
		/// Tipo sul db:NVARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneStatoRichiesta
		{
			get { return _DescrizioneStatoRichiesta; }
			set {
				if (DescrizioneStatoRichiesta != value)
				{
					_DescrizioneStatoRichiesta = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEsitoVisureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEsitoVisureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaEsitoVisureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaEsitoVisure) info.GetValue(i.ToString(),typeof(VrnaEsitoVisure)));
			}
		}

		//Costruttore
		public VrnaEsitoVisureCollection()
		{
			this.ItemType = typeof(VrnaEsitoVisure);
		}

		//Get e Set
		public new VrnaEsitoVisure this[int index]
		{
			get { return (VrnaEsitoVisure)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaEsitoVisureCollection GetChanges()
		{
			return (VrnaEsitoVisureCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaEsitoVisure VrnaEsitoVisureObj)
		{
			return base.Add(VrnaEsitoVisureObj);
		}

		//AddCollection
		public void AddCollection(VrnaEsitoVisureCollection VrnaEsitoVisureCollectionObj)
		{
			foreach (VrnaEsitoVisure VrnaEsitoVisureObj in VrnaEsitoVisureCollectionObj)
				this.Add(VrnaEsitoVisureObj);
		}

		//Insert
		public void Insert(int index, VrnaEsitoVisure VrnaEsitoVisureObj)
		{
			base.Insert(index, VrnaEsitoVisureObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaEsitoVisureCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.StringNT IdRichiestaEqualThis, NullTypes.StringNT TipoVisuraEqualThis, NullTypes.IntNT CodiceEsitoEqualThis, 
NullTypes.DatetimeNT DataAggiornamentoEqualThis, NullTypes.IntNT CodiceStatoRichiestaEqualThis, NullTypes.StringNT DescrizioneEsitoEqualThis, 
NullTypes.StringNT DescrizioneStatoRichiestaEqualThis)
		{
			VrnaEsitoVisureCollection VrnaEsitoVisureCollectionTemp = new VrnaEsitoVisureCollection();
			foreach (VrnaEsitoVisure VrnaEsitoVisureItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VrnaEsitoVisureItem.IdBando != null) && (VrnaEsitoVisureItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VrnaEsitoVisureItem.IdProgetto != null) && (VrnaEsitoVisureItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VrnaEsitoVisureItem.IdImpresa != null) && (VrnaEsitoVisureItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdRichiestaEqualThis == null) || ((VrnaEsitoVisureItem.IdRichiesta != null) && (VrnaEsitoVisureItem.IdRichiesta.Value == IdRichiestaEqualThis.Value))) && ((TipoVisuraEqualThis == null) || ((VrnaEsitoVisureItem.TipoVisura != null) && (VrnaEsitoVisureItem.TipoVisura.Value == TipoVisuraEqualThis.Value))) && ((CodiceEsitoEqualThis == null) || ((VrnaEsitoVisureItem.CodiceEsito != null) && (VrnaEsitoVisureItem.CodiceEsito.Value == CodiceEsitoEqualThis.Value))) && 
((DataAggiornamentoEqualThis == null) || ((VrnaEsitoVisureItem.DataAggiornamento != null) && (VrnaEsitoVisureItem.DataAggiornamento.Value == DataAggiornamentoEqualThis.Value))) && ((CodiceStatoRichiestaEqualThis == null) || ((VrnaEsitoVisureItem.CodiceStatoRichiesta != null) && (VrnaEsitoVisureItem.CodiceStatoRichiesta.Value == CodiceStatoRichiestaEqualThis.Value))) && ((DescrizioneEsitoEqualThis == null) || ((VrnaEsitoVisureItem.DescrizioneEsito != null) && (VrnaEsitoVisureItem.DescrizioneEsito.Value == DescrizioneEsitoEqualThis.Value))) && 
((DescrizioneStatoRichiestaEqualThis == null) || ((VrnaEsitoVisureItem.DescrizioneStatoRichiesta != null) && (VrnaEsitoVisureItem.DescrizioneStatoRichiesta.Value == DescrizioneStatoRichiestaEqualThis.Value))))
				{
					VrnaEsitoVisureCollectionTemp.Add(VrnaEsitoVisureItem);
				}
			}
			return VrnaEsitoVisureCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaEsitoVisureDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaEsitoVisureDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaEsitoVisure GetFromDatareader(DbProvider db)
		{
			VrnaEsitoVisure VrnaEsitoVisureObj = new VrnaEsitoVisure();
			VrnaEsitoVisureObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VrnaEsitoVisureObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VrnaEsitoVisureObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VrnaEsitoVisureObj.IdRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_RICHIESTA"]);
			VrnaEsitoVisureObj.TipoVisura = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VISURA"]);
			VrnaEsitoVisureObj.CodiceEsito = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_ESITO"]);
			VrnaEsitoVisureObj.DataAggiornamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AGGIORNAMENTO"]);
			VrnaEsitoVisureObj.CodiceStatoRichiesta = new SiarLibrary.NullTypes.IntNT(db.DataReader["CODICE_STATO_RICHIESTA"]);
			VrnaEsitoVisureObj.DescrizioneEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_ESITO"]);
			VrnaEsitoVisureObj.DescrizioneStatoRichiesta = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_STATO_RICHIESTA"]);
			VrnaEsitoVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaEsitoVisureObj.IsDirty = false;
			VrnaEsitoVisureObj.IsPersistent = true;
			return VrnaEsitoVisureObj;
		}

		//Find Select

		public static VrnaEsitoVisureCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT TipoVisuraEqualThis, SiarLibrary.NullTypes.IntNT CodiceEsitoEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataAggiornamentoEqualThis, SiarLibrary.NullTypes.IntNT CodiceStatoRichiestaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEsitoEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneStatoRichiestaEqualThis)

		{

			VrnaEsitoVisureCollection VrnaEsitoVisureCollectionObj = new VrnaEsitoVisureCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnaesitovisurefindselect", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdRichiestaequalthis", "TipoVisuraequalthis", "CodiceEsitoequalthis", 
"DataAggiornamentoequalthis", "CodiceStatoRichiestaequalthis", "DescrizioneEsitoequalthis", 
"DescrizioneStatoRichiestaequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "int", 
"DateTime", "int", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoVisuraequalthis", TipoVisuraEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceEsitoequalthis", CodiceEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataAggiornamentoequalthis", DataAggiornamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodiceStatoRichiestaequalthis", CodiceStatoRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneEsitoequalthis", DescrizioneEsitoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneStatoRichiestaequalthis", DescrizioneStatoRichiestaEqualThis);
			VrnaEsitoVisure VrnaEsitoVisureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaEsitoVisureObj = GetFromDatareader(db);
				VrnaEsitoVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaEsitoVisureObj.IsDirty = false;
				VrnaEsitoVisureObj.IsPersistent = true;
				VrnaEsitoVisureCollectionObj.Add(VrnaEsitoVisureObj);
			}
			db.Close();
			return VrnaEsitoVisureCollectionObj;
		}

		//Find Find

		public static VrnaEsitoVisureCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT IdRichiestaEqualThis, SiarLibrary.NullTypes.StringNT TipoVisuraEqualThis)

		{

			VrnaEsitoVisureCollection VrnaEsitoVisureCollectionObj = new VrnaEsitoVisureCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnaesitovisurefindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdImpresaequalthis", 
"IdRichiestaequalthis", "TipoVisuraequalthis"}, new string[] {"int", "int", "int", 
"string", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRichiestaequalthis", IdRichiestaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoVisuraequalthis", TipoVisuraEqualThis);
			VrnaEsitoVisure VrnaEsitoVisureObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaEsitoVisureObj = GetFromDatareader(db);
				VrnaEsitoVisureObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaEsitoVisureObj.IsDirty = false;
				VrnaEsitoVisureObj.IsPersistent = true;
				VrnaEsitoVisureCollectionObj.Add(VrnaEsitoVisureObj);
			}
			db.Close();
			return VrnaEsitoVisureCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaEsitoVisureCollectionProvider:IVrnaEsitoVisureProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEsitoVisureCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaEsitoVisure
		protected VrnaEsitoVisureCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaEsitoVisureCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaEsitoVisureCollection();
		}

		//Costruttore 2: popola la collection
		public VrnaEsitoVisureCollectionProvider(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis, TipovisuraEqualThis);
		}

		//Costruttore3: ha in input vrnaesitovisureCollectionObj - non popola la collection
		public VrnaEsitoVisureCollectionProvider(VrnaEsitoVisureCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaEsitoVisureCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaEsitoVisureCollection();
		}

		//Get e Set
		public VrnaEsitoVisureCollection CollectionObj
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
		public VrnaEsitoVisureCollection Select(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis, IntNT CodiceesitoEqualThis, 
DatetimeNT DataaggiornamentoEqualThis, IntNT CodicestatorichiestaEqualThis, StringNT DescrizioneesitoEqualThis, 
StringNT DescrizionestatorichiestaEqualThis)
		{
			VrnaEsitoVisureCollection VrnaEsitoVisureCollectionTemp = VrnaEsitoVisureDAL.Select(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis, TipovisuraEqualThis, CodiceesitoEqualThis, 
DataaggiornamentoEqualThis, CodicestatorichiestaEqualThis, DescrizioneesitoEqualThis, 
DescrizionestatorichiestaEqualThis);
			return VrnaEsitoVisureCollectionTemp;
		}

		//Find: popola la collection
		public VrnaEsitoVisureCollection Find(IntNT IdbandoEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis, 
StringNT IdrichiestaEqualThis, StringNT TipovisuraEqualThis)
		{
			VrnaEsitoVisureCollection VrnaEsitoVisureCollectionTemp = VrnaEsitoVisureDAL.Find(_dbProviderObj, IdbandoEqualThis, IdprogettoEqualThis, IdimpresaEqualThis, 
IdrichiestaEqualThis, TipovisuraEqualThis);
			return VrnaEsitoVisureCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_ESITO_VISURE>
  <ViewName>vRNA_ESITO_VISURE</ViewName>
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
      <TIPO_VISURA>Equal</TIPO_VISURA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</vRNA_ESITO_VISURE>
*/
