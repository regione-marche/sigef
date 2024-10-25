using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaPagamentoRequisitiCollectionProvider:IDomandaPagamentoRequisitiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DomandaPagamentoRequisitiCollectionProvider : IDomandaPagamentoRequisitiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaPagamentoRequisiti
		protected DomandaPagamentoRequisitiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaPagamentoRequisitiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaPagamentoRequisitiCollection(this);
		}

		//Costruttore 2: popola la collection
		public DomandaPagamentoRequisitiCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdrequisitoEqualThis, StringNT MisuraLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, IdrequisitoEqualThis, MisuraLikeThis);
		}

		//Costruttore3: ha in input domandapagamentorequisitiCollectionObj - non popola la collection
		public DomandaPagamentoRequisitiCollectionProvider(DomandaPagamentoRequisitiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaPagamentoRequisitiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaPagamentoRequisitiCollection(this);
		}

		//Get e Set
		public DomandaPagamentoRequisitiCollection CollectionObj
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
		public int SaveCollection(DomandaPagamentoRequisitiCollection collectionObj)
		{
			return DomandaPagamentoRequisitiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaPagamentoRequisiti domandapagamentorequisitiObj)
		{
			return DomandaPagamentoRequisitiDAL.Save(_dbProviderObj, domandapagamentorequisitiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaPagamentoRequisitiCollection collectionObj)
		{
			return DomandaPagamentoRequisitiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaPagamentoRequisiti domandapagamentorequisitiObj)
		{
			return DomandaPagamentoRequisitiDAL.Delete(_dbProviderObj, domandapagamentorequisitiObj);
		}

		//getById
		public DomandaPagamentoRequisiti GetById(IntNT IdDomandaPagamentoValue, IntNT IdRequisitoValue)
		{
			DomandaPagamentoRequisiti DomandaPagamentoRequisitiTemp = DomandaPagamentoRequisitiDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue, IdRequisitoValue);
			if (DomandaPagamentoRequisitiTemp!=null) DomandaPagamentoRequisitiTemp.Provider = this;
			return DomandaPagamentoRequisitiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DomandaPagamentoRequisitiCollection Select(IntNT IddomandapagamentoEqualThis, IntNT IdrequisitoEqualThis, IntNT IdvaloreEqualThis, 
DecimalNT ValnumericoEqualThis, DatetimeNT ValdataEqualThis, StringNT ValtestoEqualThis, 
StringNT EsitoEqualThis, DatetimeNT DataesitoEqualThis, BoolNT SelezionatoEqualThis)
		{
			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionTemp = DomandaPagamentoRequisitiDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, IdrequisitoEqualThis, IdvaloreEqualThis, 
ValnumericoEqualThis, ValdataEqualThis, ValtestoEqualThis, 
EsitoEqualThis, DataesitoEqualThis, SelezionatoEqualThis);
			DomandaPagamentoRequisitiCollectionTemp.Provider = this;
			return DomandaPagamentoRequisitiCollectionTemp;
		}

		//Find: popola la collection
		public DomandaPagamentoRequisitiCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdrequisitoEqualThis, StringNT MisuraLikeThis)
		{
			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionTemp = DomandaPagamentoRequisitiDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdrequisitoEqualThis, MisuraLikeThis);
			DomandaPagamentoRequisitiCollectionTemp.Provider = this;
			return DomandaPagamentoRequisitiCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_REQUISITI>
  <ViewName>vDOMANDA_REQUISITI_PAGAMENTO</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
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
</DOMANDA_PAGAMENTO_REQUISITI>
*/