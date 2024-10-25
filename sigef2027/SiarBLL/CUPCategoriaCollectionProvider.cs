using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

/* STORIA
 * Data: 2016-05-25; Stato: Creazione; Autore: 
*/

namespace SiarBLL
{

	/// <summary>
    /// Summary description for CUPCategoriaCollectionProvider:ICUPCategoriaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CUPCategoriaCollectionProvider : ICUPCategoriaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CUPCategoria
		protected CUPCategoriaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CUPCategoriaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CUPCategoriaCollection(this);
		}

		//Costruttore 2: popola la collection
        public CUPCategoriaCollectionProvider(StringNT IdsettoreproduttivoEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdsettoreproduttivoEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input CUPCategoriaCollectionObj - non popola la collection
		public CUPCategoriaCollectionProvider(CUPCategoriaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
        public CUPCategoriaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
            _CollectionObj = new CUPCategoriaCollection(this);
		}

		//Get e Set
        public CUPCategoriaCollection CollectionObj
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
        public int SaveCollection(CUPCategoriaCollection collectionObj)
		{
            return CUPCategoriaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
        public int Save(CUPCategoria CUPCategoriaObj)
		{
            return CUPCategoriaDAL.Save(_dbProviderObj, CUPCategoriaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
        public int DeleteCollection(CUPCategoriaCollection collectionObj)
		{
            return CUPCategoriaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
        public int Delete(CUPCategoria CUPCategoriaObj)
		{
            return CUPCategoriaDAL.Delete(_dbProviderObj, CUPCategoriaObj);
		}

		//getById
        public CUPCategoria GetById(StringNT IdCategoriaValue)
		{
            CUPCategoria CUPCategoriaTemp = CUPCategoriaDAL.GetById(_dbProviderObj, IdCategoriaValue);
            if (CUPCategoriaTemp != null) CUPCategoriaTemp.Provider = this;
            return CUPCategoriaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
        public CUPCategoriaCollection Select(StringNT IdCategoriaEqualThis, StringNT DescrizioneEqualThis)
		{
            CUPCategoriaCollection CUPCategoriaCollectionTemp = CUPCategoriaDAL.Select(_dbProviderObj, IdCategoriaEqualThis, DescrizioneEqualThis);
            CUPCategoriaCollectionTemp.Provider = this;
            return CUPCategoriaCollectionTemp;
		}

		//Find: popola la collection
        public CUPCategoriaCollection Find(StringNT IdCategoriaEqualThis, StringNT DescrizioneLikeThis)
		{
            CUPCategoriaCollection CUPCategoriaCollectionTemp = CUPCategoriaDAL.Find(_dbProviderObj, IdCategoriaEqualThis, DescrizioneLikeThis);
            CUPCategoriaCollectionTemp.Provider = this;
            return CUPCategoriaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CUP_CATEGORIE>
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
      <COD_CUP_CATEGORIE>Equal</COD_CUP_CATEGORIE>
      <Settore>Equal</Settore>
      <Sottosettore>Equal</Sottosettore>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE>
*/