using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for FilieraCollectionProvider:IFilieraProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FilieraCollectionProvider : IFilieraProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Filiera
		protected FilieraCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FilieraCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FilieraCollection(this);
		}

		//Costruttore3: ha in input filieraCollectionObj - non popola la collection
		public FilieraCollectionProvider(FilieraCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FilieraCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FilieraCollection(this);
		}

		//Get e Set
		public FilieraCollection CollectionObj
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
		public int SaveCollection(FilieraCollection collectionObj)
		{
			return FilieraDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Filiera filieraObj)
		{
			return FilieraDAL.Save(_dbProviderObj, filieraObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FilieraCollection collectionObj)
		{
			return FilieraDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Filiera filieraObj)
		{
			return FilieraDAL.Delete(_dbProviderObj, filieraObj);
		}

		//getById
		public Filiera GetById(IntNT IdFilieraValue)
		{
			Filiera FilieraTemp = FilieraDAL.GetById(_dbProviderObj, IdFilieraValue);
			if (FilieraTemp!=null) FilieraTemp.Provider = this;
			return FilieraTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FilieraCollection Select(IntNT IdfilieraEqualThis, StringNT CodtipofilieraEqualThis, StringNT DenominazioneEqualThis, 
IntNT NumcertificatoEqualThis, DatetimeNT DatacertificatoEqualThis, DatetimeNT DatainserimentoEqualThis, 
DatetimeNT DataultimamodificaEqualThis, StringNT OperatoreEqualThis)
		{
			FilieraCollection FilieraCollectionTemp = FilieraDAL.Select(_dbProviderObj, IdfilieraEqualThis, CodtipofilieraEqualThis, DenominazioneEqualThis, 
NumcertificatoEqualThis, DatacertificatoEqualThis, DatainserimentoEqualThis, 
DataultimamodificaEqualThis, OperatoreEqualThis);
			FilieraCollectionTemp.Provider = this;
			return FilieraCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILIERA>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILIERA>
*/