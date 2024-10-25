using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for FatturatoAziendaCollectionProvider:IFatturatoAziendaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FatturatoAziendaCollectionProvider : IFatturatoAziendaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di FatturatoAzienda
		protected FatturatoAziendaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public FatturatoAziendaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new FatturatoAziendaCollection(this);
		}

		//Costruttore 2: popola la collection
		public FatturatoAziendaCollectionProvider(IntNT IdfatturatoEqualThis, IntNT IdimpresaEqualThis, IntNT AnnoEqualThis, 
DecimalNT AliquotaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdfatturatoEqualThis, IdimpresaEqualThis, AnnoEqualThis, 
AliquotaEqualThis);
		}

		//Costruttore3: ha in input fatturatoaziendaCollectionObj - non popola la collection
		public FatturatoAziendaCollectionProvider(FatturatoAziendaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public FatturatoAziendaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new FatturatoAziendaCollection(this);
		}

		//Get e Set
		public FatturatoAziendaCollection CollectionObj
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
		public int SaveCollection(FatturatoAziendaCollection collectionObj)
		{
			return FatturatoAziendaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(FatturatoAzienda fatturatoaziendaObj)
		{
			return FatturatoAziendaDAL.Save(_dbProviderObj, fatturatoaziendaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(FatturatoAziendaCollection collectionObj)
		{
			return FatturatoAziendaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(FatturatoAzienda fatturatoaziendaObj)
		{
			return FatturatoAziendaDAL.Delete(_dbProviderObj, fatturatoaziendaObj);
		}

		//getById
		public FatturatoAzienda GetById(IntNT IdFatturatoValue)
		{
			FatturatoAzienda FatturatoAziendaTemp = FatturatoAziendaDAL.GetById(_dbProviderObj, IdFatturatoValue);
			if (FatturatoAziendaTemp!=null) FatturatoAziendaTemp.Provider = this;
			return FatturatoAziendaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public FatturatoAziendaCollection Select(IntNT IdfatturatoEqualThis, IntNT IdimpresaEqualThis, DatetimeNT DatamodificaEqualThis, 
IntNT AnnoEqualThis, DecimalNT AliquotaEqualThis, DecimalNT ImportoEqualThis)
		{
			FatturatoAziendaCollection FatturatoAziendaCollectionTemp = FatturatoAziendaDAL.Select(_dbProviderObj, IdfatturatoEqualThis, IdimpresaEqualThis, DatamodificaEqualThis, 
AnnoEqualThis, AliquotaEqualThis, ImportoEqualThis);
			FatturatoAziendaCollectionTemp.Provider = this;
			return FatturatoAziendaCollectionTemp;
		}

		//Find: popola la collection
		public FatturatoAziendaCollection Find(IntNT IdfatturatoEqualThis, IntNT IdimpresaEqualThis, IntNT AnnoEqualThis, 
DecimalNT AliquotaEqualThis)
		{
			FatturatoAziendaCollection FatturatoAziendaCollectionTemp = FatturatoAziendaDAL.Find(_dbProviderObj, IdfatturatoEqualThis, IdimpresaEqualThis, AnnoEqualThis, 
AliquotaEqualThis);
			FatturatoAziendaCollectionTemp.Provider = this;
			return FatturatoAziendaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FATTURATO_AZIENDA>
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
      <ID_FATTURATO>Equal</ID_FATTURATO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ANNO>Equal</ANNO>
      <ALIQUOTA>Equal</ALIQUOTA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
    <FiltroAliquota>
      <ALIQUOTA>Equal</ALIQUOTA>
    </FiltroAliquota>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FATTURATO_AZIENDA>
*/