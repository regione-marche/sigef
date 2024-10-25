using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for RequisitiPagamentoPlurivaloreCollectionProvider:IRequisitiPagamentoPlurivaloreProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class RequisitiPagamentoPlurivaloreCollectionProvider : IRequisitiPagamentoPlurivaloreProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RequisitiPagamentoPlurivalore
		protected RequisitiPagamentoPlurivaloreCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RequisitiPagamentoPlurivaloreCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RequisitiPagamentoPlurivaloreCollection(this);
		}

		//Costruttore 2: popola la collection
		public RequisitiPagamentoPlurivaloreCollectionProvider(IntNT IdvaloreEqualThis, IntNT IdrequisitoEqualThis, StringNT CodiceEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvaloreEqualThis, IdrequisitoEqualThis, CodiceEqualThis);
		}

		//Costruttore3: ha in input requisitipagamentoplurivaloreCollectionObj - non popola la collection
		public RequisitiPagamentoPlurivaloreCollectionProvider(RequisitiPagamentoPlurivaloreCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RequisitiPagamentoPlurivaloreCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RequisitiPagamentoPlurivaloreCollection(this);
		}

		//Get e Set
		public RequisitiPagamentoPlurivaloreCollection CollectionObj
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
		public int SaveCollection(RequisitiPagamentoPlurivaloreCollection collectionObj)
		{
			return RequisitiPagamentoPlurivaloreDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RequisitiPagamentoPlurivalore requisitipagamentoplurivaloreObj)
		{
			return RequisitiPagamentoPlurivaloreDAL.Save(_dbProviderObj, requisitipagamentoplurivaloreObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RequisitiPagamentoPlurivaloreCollection collectionObj)
		{
			return RequisitiPagamentoPlurivaloreDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RequisitiPagamentoPlurivalore requisitipagamentoplurivaloreObj)
		{
			return RequisitiPagamentoPlurivaloreDAL.Delete(_dbProviderObj, requisitipagamentoplurivaloreObj);
		}

		//getById
		public RequisitiPagamentoPlurivalore GetById(IntNT IdValoreValue)
		{
			RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreTemp = RequisitiPagamentoPlurivaloreDAL.GetById(_dbProviderObj, IdValoreValue);
			if (RequisitiPagamentoPlurivaloreTemp!=null) RequisitiPagamentoPlurivaloreTemp.Provider = this;
			return RequisitiPagamentoPlurivaloreTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RequisitiPagamentoPlurivaloreCollection Select(IntNT IdvaloreEqualThis, IntNT IdrequisitoEqualThis, StringNT CodiceEqualThis, 
StringNT DescrizioneEqualThis)
		{
			RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionTemp = RequisitiPagamentoPlurivaloreDAL.Select(_dbProviderObj, IdvaloreEqualThis, IdrequisitoEqualThis, CodiceEqualThis, 
DescrizioneEqualThis);
			RequisitiPagamentoPlurivaloreCollectionTemp.Provider = this;
			return RequisitiPagamentoPlurivaloreCollectionTemp;
		}

		//Find: popola la collection
		public RequisitiPagamentoPlurivaloreCollection Find(IntNT IdvaloreEqualThis, IntNT IdrequisitoEqualThis, StringNT CodiceEqualThis)
		{
			RequisitiPagamentoPlurivaloreCollection RequisitiPagamentoPlurivaloreCollectionTemp = RequisitiPagamentoPlurivaloreDAL.Find(_dbProviderObj, IdvaloreEqualThis, IdrequisitoEqualThis, CodiceEqualThis);
			RequisitiPagamentoPlurivaloreCollectionTemp.Provider = this;
			return RequisitiPagamentoPlurivaloreCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO_PLURIVALORE>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_VALORE>Equal</ID_VALORE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO_PLURIVALORE>
*/