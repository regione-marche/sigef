using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for CatalogoDichiarazioniCollectionProvider:ICatalogoDichiarazioniProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CatalogoDichiarazioniCollectionProvider : ICatalogoDichiarazioniProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CatalogoDichiarazioni
		protected CatalogoDichiarazioniCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CatalogoDichiarazioniCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CatalogoDichiarazioniCollection(this);
		}

		//Costruttore 2: popola la collection
		public CatalogoDichiarazioniCollectionProvider(IntNT IddichiarazioneEqualThis, StringNT MisuraLikeThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddichiarazioneEqualThis, MisuraLikeThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input catalogodichiarazioniCollectionObj - non popola la collection
		public CatalogoDichiarazioniCollectionProvider(CatalogoDichiarazioniCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CatalogoDichiarazioniCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CatalogoDichiarazioniCollection(this);
		}

		//Get e Set
		public CatalogoDichiarazioniCollection CollectionObj
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
		public int SaveCollection(CatalogoDichiarazioniCollection collectionObj)
		{
			return CatalogoDichiarazioniDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CatalogoDichiarazioni catalogodichiarazioniObj)
		{
			return CatalogoDichiarazioniDAL.Save(_dbProviderObj, catalogodichiarazioniObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CatalogoDichiarazioniCollection collectionObj)
		{
			return CatalogoDichiarazioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CatalogoDichiarazioni catalogodichiarazioniObj)
		{
			return CatalogoDichiarazioniDAL.Delete(_dbProviderObj, catalogodichiarazioniObj);
		}

		//getById
		public CatalogoDichiarazioni GetById(IntNT IdDichiarazioneValue)
		{
			CatalogoDichiarazioni CatalogoDichiarazioniTemp = CatalogoDichiarazioniDAL.GetById(_dbProviderObj, IdDichiarazioneValue);
			if (CatalogoDichiarazioniTemp!=null) CatalogoDichiarazioniTemp.Provider = this;
			return CatalogoDichiarazioniTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CatalogoDichiarazioniCollection Select(IntNT IddichiarazioneEqualThis, StringNT DescrizioneEqualThis, StringNT MisuraEqualThis)
		{
			CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionTemp = CatalogoDichiarazioniDAL.Select(_dbProviderObj, IddichiarazioneEqualThis, DescrizioneEqualThis, MisuraEqualThis);
			CatalogoDichiarazioniCollectionTemp.Provider = this;
			return CatalogoDichiarazioniCollectionTemp;
		}

		//Find: popola la collection
		public CatalogoDichiarazioniCollection Find(IntNT IddichiarazioneEqualThis, StringNT MisuraLikeThis, StringNT DescrizioneLikeThis)
		{
			CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionTemp = CatalogoDichiarazioniDAL.Find(_dbProviderObj, IddichiarazioneEqualThis, MisuraLikeThis, DescrizioneLikeThis);
			CatalogoDichiarazioniCollectionTemp.Provider = this;
			return CatalogoDichiarazioniCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CATALOGO_DICHIARAZIONI>
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
    <Find OrderBy="ORDER BY ID_DICHIARAZIONE">
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <MISURA>Like</MISURA>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CATALOGO_DICHIARAZIONI>
*/