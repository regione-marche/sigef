using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BilancioAgricoloCollectionProvider:IBilancioAgricoloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioAgricoloCollectionProvider : IBilancioAgricoloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BilancioAgricolo
		protected BilancioAgricoloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BilancioAgricoloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BilancioAgricoloCollection(this);
		}

		//Costruttore 2: popola la collection
		public BilancioAgricoloCollectionProvider(IntNT IdbilancioagricoloEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbilancioagricoloEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis);
		}

		//Costruttore3: ha in input bilancioagricoloCollectionObj - non popola la collection
		public BilancioAgricoloCollectionProvider(BilancioAgricoloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BilancioAgricoloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BilancioAgricoloCollection(this);
		}

		//Get e Set
		public BilancioAgricoloCollection CollectionObj
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
		public int SaveCollection(BilancioAgricoloCollection collectionObj)
		{
			return BilancioAgricoloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BilancioAgricolo bilancioagricoloObj)
		{
			return BilancioAgricoloDAL.Save(_dbProviderObj, bilancioagricoloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BilancioAgricoloCollection collectionObj)
		{
			return BilancioAgricoloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BilancioAgricolo bilancioagricoloObj)
		{
			return BilancioAgricoloDAL.Delete(_dbProviderObj, bilancioagricoloObj);
		}

		//getById
		public BilancioAgricolo GetById(IntNT IdBilancioAgricoloValue)
		{
			BilancioAgricolo BilancioAgricoloTemp = BilancioAgricoloDAL.GetById(_dbProviderObj, IdBilancioAgricoloValue);
			if (BilancioAgricoloTemp!=null) BilancioAgricoloTemp.Provider = this;
			return BilancioAgricoloTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BilancioAgricoloCollection Select(IntNT IdbilancioagricoloEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis, 
DatetimeNT DatamodificaEqualThis, DecimalNT PlvricavinettiEqualThis, DecimalNT PlvricaviattivitaEqualThis, 
DecimalNT PlvrimanenzefinaliEqualThis, DecimalNT PlvrimanenzeinizialiEqualThis, DecimalNT VacostimatprimeEqualThis, 
DecimalNT VacostiattconnesseEqualThis, DecimalNT VanoleggiEqualThis, DecimalNT VamanutenzioniEqualThis, 
DecimalNT VaspesegeneraliEqualThis, DecimalNT VaaffittiEqualThis, DecimalNT VaaltricostiEqualThis, 
DecimalNT PnammmacchineEqualThis, DecimalNT PnammfabbricatiEqualThis, DecimalNT PnammpiantagioniEqualThis, 
DecimalNT RosalariEqualThis, DecimalNT RooneriEqualThis, DecimalNT RnpacricaviEqualThis, 
DecimalNT RnpaccostiEqualThis, DecimalNT RnpacproventiEqualThis, DecimalNT RnpacperditeEqualThis, 
DecimalNT RnpacinteressiattiviEqualThis, DecimalNT RnpacinteressipassiviEqualThis, DecimalNT RnpacimposteEqualThis, 
DecimalNT RnpaccontributipacEqualThis, DecimalNT MnlredditifamEqualThis, DecimalNT MnlrimborsoEqualThis, 
DecimalNT MnlprelieviEqualThis, DecimalNT CfcfterreniEqualThis, DecimalNT CfcfimpiantiEqualThis, 
DecimalNT CfcfpiantagioniEqualThis, DecimalNT CfcfmiglioramentiEqualThis, DecimalNT CfcamacchineEqualThis, 
DecimalNT CfcabestiameEqualThis, DecimalNT CfifpartecipazioniEqualThis, DecimalNT CcdfrimanenzeEqualThis, 
DecimalNT CcdfanticipazioniEqualThis, DecimalNT CcldcreditiEqualThis, DecimalNT CclibancaEqualThis, 
DecimalNT CclicassaEqualThis, DecimalNT FfpcdebitibrevetermineEqualThis, DecimalNT FfpcfornitoriEqualThis, 
DecimalNT FfpcdebitiEqualThis, DecimalNT FfpcmutuiEqualThis, DecimalNT FfmpcapitaleEqualThis, 
DecimalNT FfmpriserveEqualThis, DecimalNT FfmputileEqualThis)
		{
			BilancioAgricoloCollection BilancioAgricoloCollectionTemp = BilancioAgricoloDAL.Select(_dbProviderObj, IdbilancioagricoloEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis, 
DatamodificaEqualThis, PlvricavinettiEqualThis, PlvricaviattivitaEqualThis, 
PlvrimanenzefinaliEqualThis, PlvrimanenzeinizialiEqualThis, VacostimatprimeEqualThis, 
VacostiattconnesseEqualThis, VanoleggiEqualThis, VamanutenzioniEqualThis, 
VaspesegeneraliEqualThis, VaaffittiEqualThis, VaaltricostiEqualThis, 
PnammmacchineEqualThis, PnammfabbricatiEqualThis, PnammpiantagioniEqualThis, 
RosalariEqualThis, RooneriEqualThis, RnpacricaviEqualThis, 
RnpaccostiEqualThis, RnpacproventiEqualThis, RnpacperditeEqualThis, 
RnpacinteressiattiviEqualThis, RnpacinteressipassiviEqualThis, RnpacimposteEqualThis, 
RnpaccontributipacEqualThis, MnlredditifamEqualThis, MnlrimborsoEqualThis, 
MnlprelieviEqualThis, CfcfterreniEqualThis, CfcfimpiantiEqualThis, 
CfcfpiantagioniEqualThis, CfcfmiglioramentiEqualThis, CfcamacchineEqualThis, 
CfcabestiameEqualThis, CfifpartecipazioniEqualThis, CcdfrimanenzeEqualThis, 
CcdfanticipazioniEqualThis, CcldcreditiEqualThis, CclibancaEqualThis, 
CclicassaEqualThis, FfpcdebitibrevetermineEqualThis, FfpcfornitoriEqualThis, 
FfpcdebitiEqualThis, FfpcmutuiEqualThis, FfmpcapitaleEqualThis, 
FfmpriserveEqualThis, FfmputileEqualThis);
			BilancioAgricoloCollectionTemp.Provider = this;
			return BilancioAgricoloCollectionTemp;
		}

		//Find: popola la collection
		public BilancioAgricoloCollection Find(IntNT IdbilancioagricoloEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis)
		{
			BilancioAgricoloCollection BilancioAgricoloCollectionTemp = BilancioAgricoloDAL.Find(_dbProviderObj, IdbilancioagricoloEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis);
			BilancioAgricoloCollectionTemp.Provider = this;
			return BilancioAgricoloCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_AGRICOLO>
  <ViewName>
  </ViewName>
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
      <ID_BILANCIO_AGRICOLO>Equal</ID_BILANCIO_AGRICOLO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ANNO>Equal</ANNO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <PREVISIONALE>Equal</PREVISIONALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroPrevisionale>
      <PREVISIONALE>Equal</PREVISIONALE>
    </FiltroPrevisionale>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BILANCIO_AGRICOLO>
*/