using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace SiarBLL
{

	/// <summary>
	/// Summary description for DatiMonitoraggioFESRCollectionProvider:IDatiMonitoraggioFESRProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DatiMonitoraggioFESRCollectionProvider : IDatiMonitoraggioFESRProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

        //Definizione della collection di DatiMonitoraggioFESR
		protected DatiMonitoraggioFESRCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DatiMonitoraggioFESRCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DatiMonitoraggioFESRCollection(this);
		}

		//Costruttore 2: popola la collection
        public DatiMonitoraggioFESRCollectionProvider(IntNT IdDatiMonitoraggioFESREqualThis, IntNT IdfascicoloEqualThis)
		{
			_dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdDatiMonitoraggioFESREqualThis, IdfascicoloEqualThis);
		}

        //Costruttore3: ha in input DatiMonitoraggioFESRCollectionObj - non popola la collection
        public DatiMonitoraggioFESRCollectionProvider(DatiMonitoraggioFESRCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DatiMonitoraggioFESRCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DatiMonitoraggioFESRCollection(this);
		}

		//Get e Set
		public DatiMonitoraggioFESRCollection CollectionObj
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
        public int SaveCollection(DatiMonitoraggioFESRCollection collectionObj)
		{
            return DatiMonitoraggioFESRDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
        public int Save(DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
            return DatiMonitoraggioFESRDAL.Save(_dbProviderObj, DatiMonitoraggioFESRObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
        public int DeleteCollection(DatiMonitoraggioFESRCollection collectionObj)
		{
            return DatiMonitoraggioFESRDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
        public int Delete(DatiMonitoraggioFESR manodoperaObj)
		{
            return DatiMonitoraggioFESRDAL.Delete(_dbProviderObj, manodoperaObj);
		}

		//getById
        public DatiMonitoraggioFESR GetById(IntNT IdDatiMonitoraggioFESRValue)
		{
            DatiMonitoraggioFESR ManodoperaTemp = DatiMonitoraggioFESRDAL.GetById(_dbProviderObj, IdDatiMonitoraggioFESRValue);
			if (ManodoperaTemp!=null) ManodoperaTemp.Provider = this;
			return ManodoperaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
        public DatiMonitoraggioFESRCollection Select(IntNT IdDatiMonitoraggioFESREqualThis, IntNT IdProgettoEqualThis)
		{
            DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionTemp = DatiMonitoraggioFESRDAL.Select(_dbProviderObj, IdDatiMonitoraggioFESREqualThis, IdProgettoEqualThis);
            DatiMonitoraggioFESRCollectionTemp.Provider = this;
            return DatiMonitoraggioFESRCollectionTemp;
		}

		//Find: popola la collection
        public DatiMonitoraggioFESRCollection Find(IntNT IdDatiMonitoraggioFESREqualThis, IntNT IdProgettoEqualThis)
		{
            DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionTemp = DatiMonitoraggioFESRDAL.Find(_dbProviderObj, IdDatiMonitoraggioFESREqualThis, IdProgettoEqualThis);
            DatiMonitoraggioFESRCollectionTemp.Provider = this;
            return DatiMonitoraggioFESRCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DATI_MONITORAGGIO_FESR>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
      <ID_DATI_MONIT>Equal</ID_DATI_MONIT>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DATI_MONITORAGGIO_FESR>
*/