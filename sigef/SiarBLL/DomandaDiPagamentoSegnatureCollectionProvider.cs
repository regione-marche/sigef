using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for DomandaDiPagamentoSegnatureCollectionProvider:IDomandaDiPagamentoSegnatureProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DomandaDiPagamentoSegnatureCollectionProvider : IDomandaDiPagamentoSegnatureProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di DomandaDiPagamentoSegnature
		protected DomandaDiPagamentoSegnatureCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DomandaDiPagamentoSegnatureCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DomandaDiPagamentoSegnatureCollection(this);
		}

		//Costruttore 2: popola la collection
		public DomandaDiPagamentoSegnatureCollectionProvider(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, BoolNT RiapridomandaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, CodtipoEqualThis, RiapridomandaEqualThis);
		}

		//Costruttore3: ha in input domandadipagamentosegnatureCollectionObj - non popola la collection
		public DomandaDiPagamentoSegnatureCollectionProvider(DomandaDiPagamentoSegnatureCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DomandaDiPagamentoSegnatureCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DomandaDiPagamentoSegnatureCollection(this);
		}

		//Get e Set
		public DomandaDiPagamentoSegnatureCollection CollectionObj
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
		public int SaveCollection(DomandaDiPagamentoSegnatureCollection collectionObj)
		{
			return DomandaDiPagamentoSegnatureDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(DomandaDiPagamentoSegnature domandadipagamentosegnatureObj)
		{
			return DomandaDiPagamentoSegnatureDAL.Save(_dbProviderObj, domandadipagamentosegnatureObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DomandaDiPagamentoSegnatureCollection collectionObj)
		{
			return DomandaDiPagamentoSegnatureDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(DomandaDiPagamentoSegnature domandadipagamentosegnatureObj)
		{
			return DomandaDiPagamentoSegnatureDAL.Delete(_dbProviderObj, domandadipagamentosegnatureObj);
		}

		//getById
		public DomandaDiPagamentoSegnature GetById(IntNT IdDomandaPagamentoValue, StringNT CodTipoValue)
		{
			DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureTemp = DomandaDiPagamentoSegnatureDAL.GetById(_dbProviderObj, IdDomandaPagamentoValue, CodTipoValue);
			if (DomandaDiPagamentoSegnatureTemp!=null) DomandaDiPagamentoSegnatureTemp.Provider = this;
			return DomandaDiPagamentoSegnatureTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DomandaDiPagamentoSegnatureCollection Select(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, DatetimeNT DataEqualThis, 
StringNT OperatoreEqualThis, StringNT SegnaturaEqualThis, BoolNT RiapridomandaEqualThis)
		{
			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionTemp = DomandaDiPagamentoSegnatureDAL.Select(_dbProviderObj, IddomandapagamentoEqualThis, CodtipoEqualThis, DataEqualThis, 
OperatoreEqualThis, SegnaturaEqualThis, RiapridomandaEqualThis);
			DomandaDiPagamentoSegnatureCollectionTemp.Provider = this;
			return DomandaDiPagamentoSegnatureCollectionTemp;
		}

		//Find: popola la collection
		public DomandaDiPagamentoSegnatureCollection Find(IntNT IddomandapagamentoEqualThis, StringNT CodtipoEqualThis, BoolNT RiapridomandaEqualThis)
		{
			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionTemp = DomandaDiPagamentoSegnatureDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, CodtipoEqualThis, RiapridomandaEqualThis);
			DomandaDiPagamentoSegnatureCollectionTemp.Provider = this;
			return DomandaDiPagamentoSegnatureCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO_SEGNATURE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO_SEGNATURE>
*/