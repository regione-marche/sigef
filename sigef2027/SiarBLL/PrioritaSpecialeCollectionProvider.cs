using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaSpecialeCollectionProvider:IPrioritaSpecialeProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PrioritaSpecialeCollectionProvider : IPrioritaSpecialeProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaSpeciale
		protected PrioritaSpecialeCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaSpecialeCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaSpecialeCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaSpecialeCollectionProvider(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, IntNT IdprioritaselezionataEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdschedavalutazioneEqualThis, IdprioritaEqualThis, IdprioritaselezionataEqualThis);
		}

		//Costruttore3: ha in input prioritaspecialeCollectionObj - non popola la collection
		public PrioritaSpecialeCollectionProvider(PrioritaSpecialeCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaSpecialeCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaSpecialeCollection(this);
		}

		//Get e Set
		public PrioritaSpecialeCollection CollectionObj
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
		public int SaveCollection(PrioritaSpecialeCollection collectionObj)
		{
			return PrioritaSpecialeDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaSpeciale prioritaspecialeObj)
		{
			return PrioritaSpecialeDAL.Save(_dbProviderObj, prioritaspecialeObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaSpecialeCollection collectionObj)
		{
			return PrioritaSpecialeDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaSpeciale prioritaspecialeObj)
		{
			return PrioritaSpecialeDAL.Delete(_dbProviderObj, prioritaspecialeObj);
		}

		//getById
		public PrioritaSpeciale GetById(IntNT IdSchedaValutazioneValue, IntNT IdPrioritaValue, IntNT IdPrioritaSelezionataValue)
		{
			PrioritaSpeciale PrioritaSpecialeTemp = PrioritaSpecialeDAL.GetById(_dbProviderObj, IdSchedaValutazioneValue, IdPrioritaValue, IdPrioritaSelezionataValue);
			if (PrioritaSpecialeTemp!=null) PrioritaSpecialeTemp.Provider = this;
			return PrioritaSpecialeTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaSpecialeCollection Select(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, IntNT IdprioritaselezionataEqualThis, 
BoolNT IsmaxEqualThis)
		{
			PrioritaSpecialeCollection PrioritaSpecialeCollectionTemp = PrioritaSpecialeDAL.Select(_dbProviderObj, IdschedavalutazioneEqualThis, IdprioritaEqualThis, IdprioritaselezionataEqualThis, 
IsmaxEqualThis);
			PrioritaSpecialeCollectionTemp.Provider = this;
			return PrioritaSpecialeCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaSpecialeCollection Find(IntNT IdschedavalutazioneEqualThis, IntNT IdprioritaEqualThis, IntNT IdprioritaselezionataEqualThis)
		{
			PrioritaSpecialeCollection PrioritaSpecialeCollectionTemp = PrioritaSpecialeDAL.Find(_dbProviderObj, IdschedavalutazioneEqualThis, IdprioritaEqualThis, IdprioritaselezionataEqualThis);
			PrioritaSpecialeCollectionTemp.Provider = this;
			return PrioritaSpecialeCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SPECIALE>
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
    <Find>
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_PRIORITA_SELEZIONATA>Equal</ID_PRIORITA_SELEZIONATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SPECIALE>
*/