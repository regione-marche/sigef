using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for FileDocumentoCollectionProvider:IFileDocumentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FileDocumentoCollectionProvider : IFileDocumentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FileDocumento
		protected FileDocumentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FileDocumentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FileDocumentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public FileDocumentoCollectionProvider(IntNT IddocumentoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddocumentoEqualThis);
		}

		//Costruttore3: ha in input filedocumentoCollectionObj - non popola la collection
		public FileDocumentoCollectionProvider(FileDocumentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FileDocumentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FileDocumentoCollection(this);
		}

		//Get e Set
		public FileDocumentoCollection CollectionObj
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
		public int SaveCollection(FileDocumentoCollection collectionObj)
		{
			return FileDocumentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FileDocumento filedocumentoObj)
		{
			return FileDocumentoDAL.Save(_dbProviderObj, filedocumentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FileDocumentoCollection collectionObj)
		{
			return FileDocumentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FileDocumento filedocumentoObj)
		{
			return FileDocumentoDAL.Delete(_dbProviderObj, filedocumentoObj);
		}

		//getById
		public FileDocumento GetById(IntNT IdFileValue)
		{
			FileDocumento FileDocumentoTemp = FileDocumentoDAL.GetById(_dbProviderObj, IdFileValue);
			if (FileDocumentoTemp!=null) FileDocumentoTemp.Provider = this;
			return FileDocumentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FileDocumentoCollection Select(IntNT IdfileEqualThis, IntNT IddocumentoEqualThis, StringNT NomeEqualThis, 
StringNT TipoEqualThis, IntNT SizefileEqualThis, StringNT DescrizioneEqualThis, 
IntNT IdarchiviofileEqualThis)
		{
			FileDocumentoCollection FileDocumentoCollectionTemp = FileDocumentoDAL.Select(_dbProviderObj, IdfileEqualThis, IddocumentoEqualThis, NomeEqualThis, 
TipoEqualThis, SizefileEqualThis, DescrizioneEqualThis, 
IdarchiviofileEqualThis);
			FileDocumentoCollectionTemp.Provider = this;
			return FileDocumentoCollectionTemp;
		}

		//Find: popola la collection
		public FileDocumentoCollection Find(IntNT IddocumentoEqualThis)
		{
			FileDocumentoCollection FileDocumentoCollectionTemp = FileDocumentoDAL.Find(_dbProviderObj, IddocumentoEqualThis);
			FileDocumentoCollectionTemp.Provider = this;
			return FileDocumentoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FILE_DOCUMENTO>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_DOCUMENTO>Equal</ID_DOCUMENTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FILE_DOCUMENTO>
*/