using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BilancioIndustrialeCollectionProvider:IBilancioIndustrialeProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioIndustrialeCollectionProvider : IBilancioIndustrialeProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BilancioIndustriale
		protected BilancioIndustrialeCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BilancioIndustrialeCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BilancioIndustrialeCollection(this);
		}

		//Costruttore 2: popola la collection
		public BilancioIndustrialeCollectionProvider(IntNT IdbilancioindustrialeEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbilancioindustrialeEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis);
		}

		//Costruttore3: ha in input bilancioindustrialeCollectionObj - non popola la collection
		public BilancioIndustrialeCollectionProvider(BilancioIndustrialeCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BilancioIndustrialeCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BilancioIndustrialeCollection(this);
		}

		//Get e Set
		public BilancioIndustrialeCollection CollectionObj
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
		public int SaveCollection(BilancioIndustrialeCollection collectionObj)
		{
			return BilancioIndustrialeDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BilancioIndustriale bilancioindustrialeObj)
		{
			return BilancioIndustrialeDAL.Save(_dbProviderObj, bilancioindustrialeObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BilancioIndustrialeCollection collectionObj)
		{
			return BilancioIndustrialeDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BilancioIndustriale bilancioindustrialeObj)
		{
			return BilancioIndustrialeDAL.Delete(_dbProviderObj, bilancioindustrialeObj);
		}

		//getById
		public BilancioIndustriale GetById(IntNT IdBilancioIndustrialeValue)
		{
			BilancioIndustriale BilancioIndustrialeTemp = BilancioIndustrialeDAL.GetById(_dbProviderObj, IdBilancioIndustrialeValue);
			if (BilancioIndustrialeTemp!=null) BilancioIndustrialeTemp.Provider = this;
			return BilancioIndustrialeTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BilancioIndustrialeCollection Select(IntNT IdbilancioindustrialeEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis, 
DatetimeNT DatamodificaEqualThis, DecimalNT PlvricavivenditaEqualThis, DecimalNT PlvaltriricaviEqualThis, 
DecimalNT CpmaterieprimeEqualThis, DecimalNT CpserviziEqualThis, DecimalNT CpbeniterziEqualThis, 
DecimalNT CppersonaleEqualThis, DecimalNT CpammsvalutazioniEqualThis, DecimalNT CpvarrimanenzeEqualThis, 
DecimalNT CponeriEqualThis, DecimalNT PofaltriproventiEqualThis, DecimalNT PofinteressioneriEqualThis, 
DecimalNT RettvalattfinanziarieEqualThis, DecimalNT PosproventistraordEqualThis, DecimalNT PosoneristraordEqualThis, 
DecimalNT TotprimaimposteEqualThis, DecimalNT ImposteredditoEqualThis, DecimalNT TacreditisociEqualThis, 
DecimalNT TaimmimmaterialiEqualThis, DecimalNT TaimmobmaterialiEqualThis, DecimalNT TaimmpartecipazioniEqualThis, 
DecimalNT TaimmcreditiEqualThis, DecimalNT TaacrimanenzeEqualThis, DecimalNT TaaccrediticlientiEqualThis, 
DecimalNT TaaccreditialtriEqualThis, DecimalNT TaacdeppostaliEqualThis, DecimalNT TaacdispoliquideEqualThis, 
DecimalNT TarateiriscontiEqualThis, DecimalNT TppncapitaleEqualThis, DecimalNT TppnsovrapazioniEqualThis, 
DecimalNT TppnrisrivalutazioneEqualThis, DecimalNT TppnrislegaleEqualThis, DecimalNT TppnazioniproprieEqualThis, 
DecimalNT Tppnriserva904EqualThis, DecimalNT TppnriservestatutarieEqualThis, DecimalNT TppnaltreriserveEqualThis, 
DecimalNT TppnutiliprecedentiEqualThis, DecimalNT TppnutiliesercizioEqualThis, DecimalNT TpfondirischioneriEqualThis, 
DecimalNT TpfinerapportoEqualThis, DecimalNT TpdebitibancheEqualThis, DecimalNT TpdebitifinanziatoriEqualThis, 
DecimalNT TpdebitifornitoriEqualThis, DecimalNT TpdebitiistprevidEqualThis, DecimalNT TpaltridebitiEqualThis, 
DecimalNT TprateiriscontiEqualThis)
		{
			BilancioIndustrialeCollection BilancioIndustrialeCollectionTemp = BilancioIndustrialeDAL.Select(_dbProviderObj, IdbilancioindustrialeEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis, 
DatamodificaEqualThis, PlvricavivenditaEqualThis, PlvaltriricaviEqualThis, 
CpmaterieprimeEqualThis, CpserviziEqualThis, CpbeniterziEqualThis, 
CppersonaleEqualThis, CpammsvalutazioniEqualThis, CpvarrimanenzeEqualThis, 
CponeriEqualThis, PofaltriproventiEqualThis, PofinteressioneriEqualThis, 
RettvalattfinanziarieEqualThis, PosproventistraordEqualThis, PosoneristraordEqualThis, 
TotprimaimposteEqualThis, ImposteredditoEqualThis, TacreditisociEqualThis, 
TaimmimmaterialiEqualThis, TaimmobmaterialiEqualThis, TaimmpartecipazioniEqualThis, 
TaimmcreditiEqualThis, TaacrimanenzeEqualThis, TaaccrediticlientiEqualThis, 
TaaccreditialtriEqualThis, TaacdeppostaliEqualThis, TaacdispoliquideEqualThis, 
TarateiriscontiEqualThis, TppncapitaleEqualThis, TppnsovrapazioniEqualThis, 
TppnrisrivalutazioneEqualThis, TppnrislegaleEqualThis, TppnazioniproprieEqualThis, 
Tppnriserva904EqualThis, TppnriservestatutarieEqualThis, TppnaltreriserveEqualThis, 
TppnutiliprecedentiEqualThis, TppnutiliesercizioEqualThis, TpfondirischioneriEqualThis, 
TpfinerapportoEqualThis, TpdebitibancheEqualThis, TpdebitifinanziatoriEqualThis, 
TpdebitifornitoriEqualThis, TpdebitiistprevidEqualThis, TpaltridebitiEqualThis, 
TprateiriscontiEqualThis);
			BilancioIndustrialeCollectionTemp.Provider = this;
			return BilancioIndustrialeCollectionTemp;
		}

		//Find: popola la collection
		public BilancioIndustrialeCollection Find(IntNT IdbilancioindustrialeEqualThis, IntNT IdimpresaEqualThis, IntNT IdprogettoEqualThis, 
IntNT AnnoEqualThis, DatetimeNT DatabilancioEqualThis, BoolNT PrevisionaleEqualThis)
		{
			BilancioIndustrialeCollection BilancioIndustrialeCollectionTemp = BilancioIndustrialeDAL.Find(_dbProviderObj, IdbilancioindustrialeEqualThis, IdimpresaEqualThis, IdprogettoEqualThis, 
AnnoEqualThis, DatabilancioEqualThis, PrevisionaleEqualThis);
			BilancioIndustrialeCollectionTemp.Provider = this;
			return BilancioIndustrialeCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_INDUSTRIALE>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ID_BILANCIO_INDUSTRIALE>Equal</ID_BILANCIO_INDUSTRIALE>
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
</BILANCIO_INDUSTRIALE>
*/