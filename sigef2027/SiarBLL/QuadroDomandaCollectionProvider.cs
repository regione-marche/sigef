using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for QuadroDomandaCollectionProvider:IQuadroDomandaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class QuadroDomandaCollectionProvider : IQuadroDomandaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di QuadroDomanda
		protected QuadroDomandaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public QuadroDomandaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new QuadroDomandaCollection(this);
		}

		//Costruttore 2: popola la collection
		public QuadroDomandaCollectionProvider(IntNT IdquadroEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdquadroEqualThis);
		}

		//Costruttore3: ha in input quadrodomandaCollectionObj - non popola la collection
		public QuadroDomandaCollectionProvider(QuadroDomandaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public QuadroDomandaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new QuadroDomandaCollection(this);
		}

		//Get e Set
		public QuadroDomandaCollection CollectionObj
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
		public int SaveCollection(QuadroDomandaCollection collectionObj)
		{
			return QuadroDomandaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(QuadroDomanda quadrodomandaObj)
		{
			return QuadroDomandaDAL.Save(_dbProviderObj, quadrodomandaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(QuadroDomandaCollection collectionObj)
		{
			return QuadroDomandaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(QuadroDomanda quadrodomandaObj)
		{
			return QuadroDomandaDAL.Delete(_dbProviderObj, quadrodomandaObj);
		}

		//getById
		public QuadroDomanda GetById(IntNT IdQuadroValue)
		{
			QuadroDomanda QuadroDomandaTemp = QuadroDomandaDAL.GetById(_dbProviderObj, IdQuadroValue);
			if (QuadroDomandaTemp!=null) QuadroDomandaTemp.Provider = this;
			return QuadroDomandaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Find: popola la collection
		public QuadroDomandaCollection Find(IntNT IdquadroEqualThis)
		{
			QuadroDomandaCollection QuadroDomandaCollectionTemp = QuadroDomandaDAL.Find(_dbProviderObj, IdquadroEqualThis);
			QuadroDomandaCollectionTemp.Provider = this;
			return QuadroDomandaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<QUADRO_DOMANDA>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_QUADRO>Equal</ID_QUADRO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</QUADRO_DOMANDA>
*/