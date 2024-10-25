using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for DichiarazioniXProgettoCollectionProvider:IDichiarazioniXProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DichiarazioniXProgettoCollectionProvider : IDichiarazioniXProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DichiarazioniXProgetto
		protected DichiarazioniXProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DichiarazioniXProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DichiarazioniXProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public DichiarazioniXProgettoCollectionProvider(IntNT IddichiarazioneEqualThis, IntNT IdprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddichiarazioneEqualThis, IdprogettoEqualThis);
		}

		//Costruttore3: ha in input dichiarazionixprogettoCollectionObj - non popola la collection
		public DichiarazioniXProgettoCollectionProvider(DichiarazioniXProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DichiarazioniXProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DichiarazioniXProgettoCollection(this);
		}

		//Get e Set
		public DichiarazioniXProgettoCollection CollectionObj
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
		public int SaveCollection(DichiarazioniXProgettoCollection collectionObj)
		{
			return DichiarazioniXProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DichiarazioniXProgetto dichiarazionixprogettoObj)
		{
			return DichiarazioniXProgettoDAL.Save(_dbProviderObj, dichiarazionixprogettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DichiarazioniXProgettoCollection collectionObj)
		{
			return DichiarazioniXProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DichiarazioniXProgetto dichiarazionixprogettoObj)
		{
			return DichiarazioniXProgettoDAL.Delete(_dbProviderObj, dichiarazionixprogettoObj);
		}

		//getById
		public DichiarazioniXProgetto GetById(IntNT IdDichiarazioneValue, IntNT IdProgettoValue)
		{
			DichiarazioniXProgetto DichiarazioniXProgettoTemp = DichiarazioniXProgettoDAL.GetById(_dbProviderObj, IdDichiarazioneValue, IdProgettoValue);
			if (DichiarazioniXProgettoTemp!=null) DichiarazioniXProgettoTemp.Provider = this;
			return DichiarazioniXProgettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DichiarazioniXProgettoCollection Select(IntNT IddichiarazioneEqualThis, IntNT IdprogettoEqualThis)
		{
			DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionTemp = DichiarazioniXProgettoDAL.Select(_dbProviderObj, IddichiarazioneEqualThis, IdprogettoEqualThis);
			DichiarazioniXProgettoCollectionTemp.Provider = this;
			return DichiarazioniXProgettoCollectionTemp;
		}

		//Find: popola la collection
		public DichiarazioniXProgettoCollection Find(IntNT IddichiarazioneEqualThis, IntNT IdprogettoEqualThis)
		{
			DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionTemp = DichiarazioniXProgettoDAL.Find(_dbProviderObj, IddichiarazioneEqualThis, IdprogettoEqualThis);
			DichiarazioniXProgettoCollectionTemp.Provider = this;
			return DichiarazioniXProgettoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DICHIARAZIONI_X_PROGETTO>
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
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DICHIARAZIONI_X_PROGETTO>
*/