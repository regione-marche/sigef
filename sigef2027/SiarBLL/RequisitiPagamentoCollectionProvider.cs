using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for RequisitiPagamentoCollectionProvider:IRequisitiPagamentoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class RequisitiPagamentoCollectionProvider : IRequisitiPagamentoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di RequisitiPagamento
		protected RequisitiPagamentoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public RequisitiPagamentoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new RequisitiPagamentoCollection(this);
		}

		//Costruttore 2: popola la collection
		public RequisitiPagamentoCollectionProvider(IntNT IdrequisitoEqualThis, StringNT MisuraLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdrequisitoEqualThis, MisuraLikeThis);
		}

		//Costruttore3: ha in input requisitipagamentoCollectionObj - non popola la collection
		public RequisitiPagamentoCollectionProvider(RequisitiPagamentoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public RequisitiPagamentoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new RequisitiPagamentoCollection(this);
		}

		//Get e Set
		public RequisitiPagamentoCollection CollectionObj
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
		public int SaveCollection(RequisitiPagamentoCollection collectionObj)
		{
			return RequisitiPagamentoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(RequisitiPagamento requisitipagamentoObj)
		{
			return RequisitiPagamentoDAL.Save(_dbProviderObj, requisitipagamentoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(RequisitiPagamentoCollection collectionObj)
		{
			return RequisitiPagamentoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(RequisitiPagamento requisitipagamentoObj)
		{
			return RequisitiPagamentoDAL.Delete(_dbProviderObj, requisitipagamentoObj);
		}

		//getById
		public RequisitiPagamento GetById(IntNT IdRequisitoValue)
		{
			RequisitiPagamento RequisitiPagamentoTemp = RequisitiPagamentoDAL.GetById(_dbProviderObj, IdRequisitoValue);
			if (RequisitiPagamentoTemp!=null) RequisitiPagamentoTemp.Provider = this;
			return RequisitiPagamentoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public RequisitiPagamentoCollection Select(IntNT IdrequisitoEqualThis, StringNT DescrizioneEqualThis, BoolNT PlurivaloreEqualThis, 
BoolNT NumericoEqualThis, BoolNT DatetimeEqualThis, BoolNT TestosempliceEqualThis, 
BoolNT TestoareaEqualThis, StringNT UrlEqualThis, StringNT QueryevalEqualThis, 
StringNT QueryinsertEqualThis, StringNT MisuraEqualThis)
		{
			RequisitiPagamentoCollection RequisitiPagamentoCollectionTemp = RequisitiPagamentoDAL.Select(_dbProviderObj, IdrequisitoEqualThis, DescrizioneEqualThis, PlurivaloreEqualThis, 
NumericoEqualThis, DatetimeEqualThis, TestosempliceEqualThis, 
TestoareaEqualThis, UrlEqualThis, QueryevalEqualThis, 
QueryinsertEqualThis, MisuraEqualThis);
			RequisitiPagamentoCollectionTemp.Provider = this;
			return RequisitiPagamentoCollectionTemp;
		}

		//Find: popola la collection
		public RequisitiPagamentoCollection Find(IntNT IdrequisitoEqualThis, StringNT MisuraLikeThis)
		{
			RequisitiPagamentoCollection RequisitiPagamentoCollectionTemp = RequisitiPagamentoDAL.Find(_dbProviderObj, IdrequisitoEqualThis, MisuraLikeThis);
			RequisitiPagamentoCollectionTemp.Provider = this;
			return RequisitiPagamentoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO>
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
    <Find OrderBy="ORDER BY ">
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <PLURIVALORE>Equal</PLURIVALORE>
      <NUMERICO>Equal</NUMERICO>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <URL>IsNull</URL>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO>
*/