using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BilancioPrevisionaleCollectionProvider:IBilancioPrevisionaleProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioPrevisionaleCollectionProvider : IBilancioPrevisionaleProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BilancioPrevisionale
		protected BilancioPrevisionaleCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BilancioPrevisionaleCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BilancioPrevisionaleCollection(this);
		}

		//Costruttore 2: popola la collection
		public BilancioPrevisionaleCollectionProvider(IntNT IdprevisionaleEqualThis, IntNT IdprogettoEqualThis, DatetimeNT DatabilancioEqualThis, 
IntNT AnnoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprevisionaleEqualThis, IdprogettoEqualThis, DatabilancioEqualThis, 
AnnoEqualThis);
		}

		//Costruttore3: ha in input bilancioprevisionaleCollectionObj - non popola la collection
		public BilancioPrevisionaleCollectionProvider(BilancioPrevisionaleCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BilancioPrevisionaleCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BilancioPrevisionaleCollection(this);
		}

		//Get e Set
		public BilancioPrevisionaleCollection CollectionObj
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
		public int SaveCollection(BilancioPrevisionaleCollection collectionObj)
		{
			return BilancioPrevisionaleDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BilancioPrevisionale bilancioprevisionaleObj)
		{
			return BilancioPrevisionaleDAL.Save(_dbProviderObj, bilancioprevisionaleObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BilancioPrevisionaleCollection collectionObj)
		{
			return BilancioPrevisionaleDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BilancioPrevisionale bilancioprevisionaleObj)
		{
			return BilancioPrevisionaleDAL.Delete(_dbProviderObj, bilancioprevisionaleObj);
		}

		//getById
		public BilancioPrevisionale GetById(IntNT IdPrevisionaleValue)
		{
			BilancioPrevisionale BilancioPrevisionaleTemp = BilancioPrevisionaleDAL.GetById(_dbProviderObj, IdPrevisionaleValue);
			if (BilancioPrevisionaleTemp!=null) BilancioPrevisionaleTemp.Provider = this;
			return BilancioPrevisionaleTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BilancioPrevisionaleCollection Select(IntNT IdprevisionaleEqualThis, IntNT IdprogettoEqualThis, IntNT AnnoEqualThis, 
DatetimeNT DatabilancioEqualThis, DecimalNT PlvricavinettivenditaEqualThis, DecimalNT PlvaltriricaviEqualThis, 
DecimalNT PlvvarrimanenzeEqualThis, DecimalNT PlvvarlavoroEqualThis, DecimalNT PlvincrementiEqualThis, 
DecimalNT RocostiproduzioneEqualThis, DecimalNT RpiproventiEqualThis, DecimalNT RpirettificheEqualThis, 
DecimalNT RpiproventistraordinariEqualThis, DecimalNT RnimposteEqualThis, DecimalNT TacreditiEqualThis, 
DecimalNT TaimmobilizzazioniEqualThis, DecimalNT TaattivocircolanteEqualThis, DecimalNT TarateiEqualThis, 
DecimalNT TppatrimonioEqualThis, DecimalNT TpfondiEqualThis, DecimalNT TpltmutuiordinariEqualThis, 
DecimalNT TpltmutuiagevolatiEqualThis, DecimalNT TpltprestitiEqualThis, DecimalNT TpltdebitifornitoriEqualThis, 
DecimalNT TpltdebitibancheEqualThis, DecimalNT TpltaltrescadenzeEqualThis, DecimalNT TpdebitifornitoriEqualThis, 
DecimalNT TpdebitibancheEqualThis, DecimalNT TpprestitisociEqualThis, DecimalNT TpprestitiEqualThis, 
DecimalNT TpaltridebitiEqualThis, DecimalNT TprateiEqualThis)
		{
			BilancioPrevisionaleCollection BilancioPrevisionaleCollectionTemp = BilancioPrevisionaleDAL.Select(_dbProviderObj, IdprevisionaleEqualThis, IdprogettoEqualThis, AnnoEqualThis, 
DatabilancioEqualThis, PlvricavinettivenditaEqualThis, PlvaltriricaviEqualThis, 
PlvvarrimanenzeEqualThis, PlvvarlavoroEqualThis, PlvincrementiEqualThis, 
RocostiproduzioneEqualThis, RpiproventiEqualThis, RpirettificheEqualThis, 
RpiproventistraordinariEqualThis, RnimposteEqualThis, TacreditiEqualThis, 
TaimmobilizzazioniEqualThis, TaattivocircolanteEqualThis, TarateiEqualThis, 
TppatrimonioEqualThis, TpfondiEqualThis, TpltmutuiordinariEqualThis, 
TpltmutuiagevolatiEqualThis, TpltprestitiEqualThis, TpltdebitifornitoriEqualThis, 
TpltdebitibancheEqualThis, TpltaltrescadenzeEqualThis, TpdebitifornitoriEqualThis, 
TpdebitibancheEqualThis, TpprestitisociEqualThis, TpprestitiEqualThis, 
TpaltridebitiEqualThis, TprateiEqualThis);
			BilancioPrevisionaleCollectionTemp.Provider = this;
			return BilancioPrevisionaleCollectionTemp;
		}

		//Find: popola la collection
		public BilancioPrevisionaleCollection Find(IntNT IdprevisionaleEqualThis, IntNT IdprogettoEqualThis, DatetimeNT DatabilancioEqualThis, 
IntNT AnnoEqualThis)
		{
			BilancioPrevisionaleCollection BilancioPrevisionaleCollectionTemp = BilancioPrevisionaleDAL.Find(_dbProviderObj, IdprevisionaleEqualThis, IdprogettoEqualThis, DatabilancioEqualThis, 
AnnoEqualThis);
			BilancioPrevisionaleCollectionTemp.Provider = this;
			return BilancioPrevisionaleCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_PREVISIONALE>
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
      <ID_PREVISIONALE>Equal</ID_PREVISIONALE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO_PREVISIONALE>
*/