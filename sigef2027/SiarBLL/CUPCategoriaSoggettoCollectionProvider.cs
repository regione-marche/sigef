using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

/* STORIA
 * Data: 2016-05-27; Stato: Creazione; Autore: 
*/

namespace SiarBLL
{

	/// <summary>
    /// Summary description for CUPCategoriaSoggettoCollectionProvider:ICUPCategoriaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CUPCategoriaSoggettoCollectionProvider : ICUPCategoriaSoggettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CUPCategoriaSoggetto
		protected CUPCategoriaSoggettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CUPCategoriaSoggettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CUPCategoriaSoggettoCollection(this);
		}

		//Costruttore 2: popola la collection
        public CUPCategoriaSoggettoCollectionProvider(StringNT IdsettoreproduttivoEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdsettoreproduttivoEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input CUPCategoriaSoggettoCollectionObj - non popola la collection
		public CUPCategoriaSoggettoCollectionProvider(CUPCategoriaSoggettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
        public CUPCategoriaSoggettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
            _CollectionObj = new CUPCategoriaSoggettoCollection(this);
		}

		//Get e Set
        public CUPCategoriaSoggettoCollection CollectionObj
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
        public int SaveCollection(CUPCategoriaSoggettoCollection collectionObj)
		{
            return CUPCategoriaSoggettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
        public int Save(CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
            return CUPCategoriaSoggettoDAL.Save(_dbProviderObj, CUPCategoriaSoggettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
        public int DeleteCollection(CUPCategoriaSoggettoCollection collectionObj)
		{
            return CUPCategoriaSoggettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
        public int Delete(CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
            return CUPCategoriaSoggettoDAL.Delete(_dbProviderObj, CUPCategoriaSoggettoObj);
		}

		//getById
        public CUPCategoriaSoggetto GetById(StringNT IdCategoriaSoggValue)
		{
            CUPCategoriaSoggetto CUPCategoriaSoggettoTemp = CUPCategoriaSoggettoDAL.GetById(_dbProviderObj, IdCategoriaSoggValue);
            if (CUPCategoriaSoggettoTemp != null) CUPCategoriaSoggettoTemp.Provider = this;
            return CUPCategoriaSoggettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
        public CUPCategoriaSoggettoCollection Select(StringNT IdCategoriaEqualThis, StringNT DescrizioneEqualThis)
		{
            CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionTemp = CUPCategoriaSoggettoDAL.Select(_dbProviderObj, IdCategoriaEqualThis, DescrizioneEqualThis);
            CUPCategoriaSoggettoCollectionTemp.Provider = this;
            return CUPCategoriaSoggettoCollectionTemp;
		}

		//Find: popola la collection
        public CUPCategoriaSoggettoCollection Find(StringNT IdCategoriaEqualThis, StringNT DescrizioneLikeThis)
		{
            CUPCategoriaSoggettoCollection CUPCategoriaSoggettoCollectionTemp = CUPCategoriaSoggettoDAL.Find(_dbProviderObj, IdCategoriaEqualThis, DescrizioneLikeThis);
            CUPCategoriaSoggettoCollectionTemp.Provider = this;
            return CUPCategoriaSoggettoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CUP_CATEGORIE_SOGGETTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <COD_CUP_CATEGORIE_SOGGETTI>Equal</COD_CUP_CATEGORIE_SOGGETTI>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE_SOGGETTI>
*/