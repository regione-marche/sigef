using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for FormaGiuridicaCollectionProvider:IFormaGiuridicaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FormaGiuridicaCollectionProvider : IFormaGiuridicaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FormaGiuridica
		protected FormaGiuridicaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FormaGiuridicaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FormaGiuridicaCollection(this);
		}

		//Costruttore 2: popola la collection
		public FormaGiuridicaCollectionProvider(StringNT CodistatEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodistatEqualThis);
		}

		//Costruttore3: ha in input formagiuridicaCollectionObj - non popola la collection
		public FormaGiuridicaCollectionProvider(FormaGiuridicaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FormaGiuridicaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FormaGiuridicaCollection(this);
		}

		//Get e Set
		public FormaGiuridicaCollection CollectionObj
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
		public int SaveCollection(FormaGiuridicaCollection collectionObj)
		{
			return FormaGiuridicaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FormaGiuridica formagiuridicaObj)
		{
			return FormaGiuridicaDAL.Save(_dbProviderObj, formagiuridicaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FormaGiuridicaCollection collectionObj)
		{
			return FormaGiuridicaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FormaGiuridica formagiuridicaObj)
		{
			return FormaGiuridicaDAL.Delete(_dbProviderObj, formagiuridicaObj);
		}

		//getById
		public FormaGiuridica GetById(StringNT CodIstatValue)
		{
			FormaGiuridica FormaGiuridicaTemp = FormaGiuridicaDAL.GetById(_dbProviderObj, CodIstatValue);
			if (FormaGiuridicaTemp!=null) FormaGiuridicaTemp.Provider = this;
			return FormaGiuridicaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FormaGiuridicaCollection Select(StringNT CodistatEqualThis, StringNT DescrizioneEqualThis, BoolNT FogliaEqualThis)
		{
			FormaGiuridicaCollection FormaGiuridicaCollectionTemp = FormaGiuridicaDAL.Select(_dbProviderObj, CodistatEqualThis, DescrizioneEqualThis, FogliaEqualThis);
			FormaGiuridicaCollectionTemp.Provider = this;
			return FormaGiuridicaCollectionTemp;
		}

		//Find: popola la collection
		public FormaGiuridicaCollection Find(StringNT CodistatEqualThis)
		{
			FormaGiuridicaCollection FormaGiuridicaCollectionTemp = FormaGiuridicaDAL.Find(_dbProviderObj, CodistatEqualThis);
			FormaGiuridicaCollectionTemp.Provider = this;
			return FormaGiuridicaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FORMA_GIURIDICA>
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
      <COD_ISTAT>Equal</COD_ISTAT>
    </Find>
  </Finds>
  <Filters>
    <FiltroFoglia>
      <FOGLIA>Equal</FOGLIA>
    </FiltroFoglia>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FORMA_GIURIDICA>
*/