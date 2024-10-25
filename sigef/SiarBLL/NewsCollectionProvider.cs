using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for NewsCollectionProvider:INewsProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class NewsCollectionProvider : INewsProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di News
		protected NewsCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public NewsCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new NewsCollection(this);
		}

		//Costruttore 2: popola la collection
		public NewsCollectionProvider(StringNT TitoloLikeThis, StringNT TestoLikeThis, BoolNT InterruzionesistemaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(TitoloLikeThis, TestoLikeThis, InterruzionesistemaEqualThis);
		}

		//Costruttore3: ha in input newsCollectionObj - non popola la collection
		public NewsCollectionProvider(NewsCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public NewsCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new NewsCollection(this);
		}

		//Get e Set
		public NewsCollection CollectionObj
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
		public int SaveCollection(NewsCollection collectionObj)
		{
			return NewsDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(News newsObj)
		{
			return NewsDAL.Save(_dbProviderObj, newsObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(NewsCollection collectionObj)
		{
			return NewsDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(News newsObj)
		{
			return NewsDAL.Delete(_dbProviderObj, newsObj);
		}

		//getById
		public News GetById(IntNT IdNewsValue)
		{
			News NewsTemp = NewsDAL.GetById(_dbProviderObj, IdNewsValue);
			if (NewsTemp!=null) NewsTemp.Provider = this;
			return NewsTemp;
		}

		//Select: popola la collection
		public NewsCollection Select(IntNT IdnewsEqualThis, StringNT TitoloEqualThis, StringNT TestoEqualThis, 
StringNT UrlEqualThis, DatetimeNT DataEqualThis, StringNT OperatoreEqualThis, 
BoolNT InterruzionesistemaEqualThis, DatetimeNT DatainizioEqualThis, DatetimeNT DatafineEqualThis)
		{
			NewsCollection NewsCollectionTemp = NewsDAL.Select(_dbProviderObj, IdnewsEqualThis, TitoloEqualThis, TestoEqualThis, 
UrlEqualThis, DataEqualThis, OperatoreEqualThis, 
InterruzionesistemaEqualThis, DatainizioEqualThis, DatafineEqualThis);
			NewsCollectionTemp.Provider = this;
			return NewsCollectionTemp;
		}

		//Find: popola la collection
		public NewsCollection Find(StringNT TitoloLikeThis, StringNT TestoLikeThis, BoolNT InterruzionesistemaEqualThis)
		{
			NewsCollection NewsCollectionTemp = NewsDAL.Find(_dbProviderObj, TitoloLikeThis, TestoLikeThis, InterruzionesistemaEqualThis);
			NewsCollectionTemp.Provider = this;
			return NewsCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<NEWS>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <TITOLO>Like</TITOLO>
      <TESTO>Like</TESTO>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
    </Find>
  </Finds>
  <Filters>
    <FiltroInterruzioneDiSistema>
      <INTERRUZIONE_SISTEMA>Equal</INTERRUZIONE_SISTEMA>
      <DATA_INIZIO>EqLessThan</DATA_INIZIO>
      <DATA_FINE>EqGreaterThan</DATA_FINE>
    </FiltroInterruzioneDiSistema>
  </Filters>
  <externalFields />
  <AddedFkFields />
</NEWS>
*/