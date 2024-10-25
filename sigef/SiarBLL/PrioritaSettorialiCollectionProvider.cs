using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PrioritaSettorialiCollectionProvider:IPrioritaSettorialiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PrioritaSettorialiCollectionProvider : IPrioritaSettorialiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PrioritaSettoriali
		protected PrioritaSettorialiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PrioritaSettorialiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PrioritaSettorialiCollection(this);
		}

		//Costruttore 2: popola la collection
		public PrioritaSettorialiCollectionProvider(IntNT IdprioritasettorialeEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprioritasettorialeEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input prioritasettorialiCollectionObj - non popola la collection
		public PrioritaSettorialiCollectionProvider(PrioritaSettorialiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PrioritaSettorialiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PrioritaSettorialiCollection(this);
		}

		//Get e Set
		public PrioritaSettorialiCollection CollectionObj
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
		public int SaveCollection(PrioritaSettorialiCollection collectionObj)
		{
			return PrioritaSettorialiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PrioritaSettoriali prioritasettorialiObj)
		{
			return PrioritaSettorialiDAL.Save(_dbProviderObj, prioritasettorialiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PrioritaSettorialiCollection collectionObj)
		{
			return PrioritaSettorialiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PrioritaSettoriali prioritasettorialiObj)
		{
			return PrioritaSettorialiDAL.Delete(_dbProviderObj, prioritasettorialiObj);
		}

		//getById
		public PrioritaSettoriali GetById(IntNT IdPrioritaSettorialeValue)
		{
			PrioritaSettoriali PrioritaSettorialiTemp = PrioritaSettorialiDAL.GetById(_dbProviderObj, IdPrioritaSettorialeValue);
			if (PrioritaSettorialiTemp!=null) PrioritaSettorialiTemp.Provider = this;
			return PrioritaSettorialiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PrioritaSettorialiCollection Select(IntNT IdprioritasettorialeEqualThis, StringNT DescrizioneEqualThis)
		{
			PrioritaSettorialiCollection PrioritaSettorialiCollectionTemp = PrioritaSettorialiDAL.Select(_dbProviderObj, IdprioritasettorialeEqualThis, DescrizioneEqualThis);
			PrioritaSettorialiCollectionTemp.Provider = this;
			return PrioritaSettorialiCollectionTemp;
		}

		//Find: popola la collection
		public PrioritaSettorialiCollection Find(IntNT IdprioritasettorialeEqualThis, StringNT DescrizioneLikeThis)
		{
			PrioritaSettorialiCollection PrioritaSettorialiCollectionTemp = PrioritaSettorialiDAL.Find(_dbProviderObj, IdprioritasettorialeEqualThis, DescrizioneLikeThis);
			PrioritaSettorialiCollectionTemp.Provider = this;
			return PrioritaSettorialiCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SETTORIALI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_PRIORITA_SETTORIALE>Equal</ID_PRIORITA_SETTORIALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SETTORIALI>
*/