using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for LocalizzazioneInvestimentoCollectionProvider:ILocalizzazioneInvestimentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class LocalizzazioneInvestimentoCollectionProvider : ILocalizzazioneInvestimentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di LocalizzazioneInvestimento
		protected LocalizzazioneInvestimentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public LocalizzazioneInvestimentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new LocalizzazioneInvestimentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public LocalizzazioneInvestimentoCollectionProvider(IntNT IdlocalizzazioneEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdcatastoEqualThis, 
IntNT IdcomuneEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdlocalizzazioneEqualThis, IdinvestimentoEqualThis, IdcatastoEqualThis, 
IdcomuneEqualThis);
		}

		//Costruttore3: ha in input localizzazioneinvestimentoCollectionObj - non popola la collection
		public LocalizzazioneInvestimentoCollectionProvider(LocalizzazioneInvestimentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public LocalizzazioneInvestimentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new LocalizzazioneInvestimentoCollection(this);
		}

		//Get e Set
		public LocalizzazioneInvestimentoCollection CollectionObj
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
		public int SaveCollection(LocalizzazioneInvestimentoCollection collectionObj)
		{
			return LocalizzazioneInvestimentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(LocalizzazioneInvestimento localizzazioneinvestimentoObj)
		{
			return LocalizzazioneInvestimentoDAL.Save(_dbProviderObj, localizzazioneinvestimentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(LocalizzazioneInvestimentoCollection collectionObj)
		{
			return LocalizzazioneInvestimentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(LocalizzazioneInvestimento localizzazioneinvestimentoObj)
		{
			return LocalizzazioneInvestimentoDAL.Delete(_dbProviderObj, localizzazioneinvestimentoObj);
		}

		//getById
		public LocalizzazioneInvestimento GetById(IntNT IdLocalizzazioneValue)
		{
			LocalizzazioneInvestimento LocalizzazioneInvestimentoTemp = LocalizzazioneInvestimentoDAL.GetById(_dbProviderObj, IdLocalizzazioneValue);
			if (LocalizzazioneInvestimentoTemp!=null) LocalizzazioneInvestimentoTemp.Provider = this;
			return LocalizzazioneInvestimentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public LocalizzazioneInvestimentoCollection Select(IntNT IdlocalizzazioneEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdcatastoEqualThis)
		{
			LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionTemp = LocalizzazioneInvestimentoDAL.Select(_dbProviderObj, IdlocalizzazioneEqualThis, IdinvestimentoEqualThis, IdcatastoEqualThis);
			LocalizzazioneInvestimentoCollectionTemp.Provider = this;
			return LocalizzazioneInvestimentoCollectionTemp;
		}

		//Find: popola la collection
		public LocalizzazioneInvestimentoCollection Find(IntNT IdlocalizzazioneEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdcatastoEqualThis, 
IntNT IdcomuneEqualThis)
		{
			LocalizzazioneInvestimentoCollection LocalizzazioneInvestimentoCollectionTemp = LocalizzazioneInvestimentoDAL.Find(_dbProviderObj, IdlocalizzazioneEqualThis, IdinvestimentoEqualThis, IdcatastoEqualThis, 
IdcomuneEqualThis);
			LocalizzazioneInvestimentoCollectionTemp.Provider = this;
			return LocalizzazioneInvestimentoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<LOCALIZZAZIONE_INVESTIMENTO>
  <ViewName>vLOCALIZZAZIONE_INVESTIMENTO</ViewName>
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
    <Find>
      <ID_LOCALIZZAZIONE>Equal</ID_LOCALIZZAZIONE>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_CATASTO>Equal</ID_CATASTO>
      <ID_COMUNE>Equal</ID_COMUNE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</LOCALIZZAZIONE_INVESTIMENTO>
*/