using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BilancioCollectionProvider:IBilancioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioCollectionProvider : IBilancioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Bilancio
		protected BilancioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BilancioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BilancioCollection(this);
		}

		//Costruttore 2: popola la collection
		public BilancioCollectionProvider(IntNT IdbilancioEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DatabilancioEqualThis, 
IntNT AnnoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbilancioEqualThis, IdimpresaEqualThis, DatabilancioEqualThis, 
AnnoEqualThis);
		}

		//Costruttore3: ha in input bilancioCollectionObj - non popola la collection
		public BilancioCollectionProvider(BilancioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BilancioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BilancioCollection(this);
		}

		//Get e Set
		public BilancioCollection CollectionObj
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
		public int SaveCollection(BilancioCollection collectionObj)
		{
			return BilancioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Bilancio bilancioObj)
		{
			return BilancioDAL.Save(_dbProviderObj, bilancioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BilancioCollection collectionObj)
		{
			return BilancioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Bilancio bilancioObj)
		{
			return BilancioDAL.Delete(_dbProviderObj, bilancioObj);
		}

		//getById
		public Bilancio GetById(IntNT IdBilancioValue)
		{
			Bilancio BilancioTemp = BilancioDAL.GetById(_dbProviderObj, IdBilancioValue);
			if (BilancioTemp!=null) BilancioTemp.Provider = this;
			return BilancioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BilancioCollection Select(IntNT IdbilancioEqualThis, IntNT IdimpresaEqualThis, IntNT AnnoEqualThis, 
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
			BilancioCollection BilancioCollectionTemp = BilancioDAL.Select(_dbProviderObj, IdbilancioEqualThis, IdimpresaEqualThis, AnnoEqualThis, 
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
			BilancioCollectionTemp.Provider = this;
			return BilancioCollectionTemp;
		}

		//Find: popola la collection
		public BilancioCollection Find(IntNT IdbilancioEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DatabilancioEqualThis, 
IntNT AnnoEqualThis)
		{
			BilancioCollection BilancioCollectionTemp = BilancioDAL.Find(_dbProviderObj, IdbilancioEqualThis, IdimpresaEqualThis, DatabilancioEqualThis, 
AnnoEqualThis);
			BilancioCollectionTemp.Provider = this;
			return BilancioCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO>
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
      <ID_BILANCIO>Equal</ID_BILANCIO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO>
*/