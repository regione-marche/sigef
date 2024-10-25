using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for EnteCollectionProvider:IEnteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class EnteCollectionProvider : IEnteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Ente
		protected EnteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public EnteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new EnteCollection(this);
		}

		//Costruttore 2: popola la collection
		public EnteCollectionProvider(StringNT CodenteEqualThis, StringNT CodtipoenteEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodenteEqualThis, CodtipoenteEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input enteCollectionObj - non popola la collection
		public EnteCollectionProvider(EnteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public EnteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new EnteCollection(this);
		}

		//Get e Set
		public EnteCollection CollectionObj
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
		public int SaveCollection(EnteCollection collectionObj)
		{
			return EnteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Ente enteObj)
		{
			return EnteDAL.Save(_dbProviderObj, enteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(EnteCollection collectionObj)
		{
			return EnteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Ente enteObj)
		{
			return EnteDAL.Delete(_dbProviderObj, enteObj);
		}

		//getById
		public Ente GetById(StringNT CodEnteValue)
		{
			Ente EnteTemp = EnteDAL.GetById(_dbProviderObj, CodEnteValue);
			if (EnteTemp!=null) EnteTemp.Provider = this;
			return EnteTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public EnteCollection Select(StringNT CodenteEqualThis, StringNT CodtipoenteEqualThis, StringNT DescrizioneEqualThis, 
StringNT CodsianEqualThis, BoolNT AttivoEqualThis)
		{
			EnteCollection EnteCollectionTemp = EnteDAL.Select(_dbProviderObj, CodenteEqualThis, CodtipoenteEqualThis, DescrizioneEqualThis, 
CodsianEqualThis, AttivoEqualThis);
			EnteCollectionTemp.Provider = this;
			return EnteCollectionTemp;
		}

		//Find: popola la collection
		public EnteCollection Find(StringNT CodenteEqualThis, StringNT CodtipoenteEqualThis, BoolNT AttivoEqualThis)
		{
			EnteCollection EnteCollectionTemp = EnteDAL.Find(_dbProviderObj, CodenteEqualThis, CodtipoenteEqualThis, AttivoEqualThis);
			EnteCollectionTemp.Provider = this;
			return EnteCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<ENTE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY COD_TIPO_ENTE, ATTIVO DESC, COD_ENTE">
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ENTE>
*/