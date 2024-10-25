using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneCollectionProvider:ICorrettivaRendicontazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CorrettivaRendicontazioneCollectionProvider : ICorrettivaRendicontazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CorrettivaRendicontazione
		protected CorrettivaRendicontazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CorrettivaRendicontazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CorrettivaRendicontazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public CorrettivaRendicontazioneCollectionProvider(IntNT IddomandapagamentoEqualThis, BoolNT AnnullataEqualThis, BoolNT ConclusaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IddomandapagamentoEqualThis, AnnullataEqualThis, ConclusaEqualThis);
		}

		//Costruttore3: ha in input correttivarendicontazioneCollectionObj - non popola la collection
		public CorrettivaRendicontazioneCollectionProvider(CorrettivaRendicontazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CorrettivaRendicontazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CorrettivaRendicontazioneCollection(this);
		}

		//Get e Set
		public CorrettivaRendicontazioneCollection CollectionObj
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
		public int SaveCollection(CorrettivaRendicontazioneCollection collectionObj)
		{
			return CorrettivaRendicontazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CorrettivaRendicontazione correttivarendicontazioneObj)
		{
			return CorrettivaRendicontazioneDAL.Save(_dbProviderObj, correttivarendicontazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CorrettivaRendicontazioneCollection collectionObj)
		{
			return CorrettivaRendicontazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CorrettivaRendicontazione correttivarendicontazioneObj)
		{
			return CorrettivaRendicontazioneDAL.Delete(_dbProviderObj, correttivarendicontazioneObj);
		}

		//getById
		public CorrettivaRendicontazione GetById(IntNT IdValue)
		{
			CorrettivaRendicontazione CorrettivaRendicontazioneTemp = CorrettivaRendicontazioneDAL.GetById(_dbProviderObj, IdValue);
			if (CorrettivaRendicontazioneTemp!=null) CorrettivaRendicontazioneTemp.Provider = this;
			return CorrettivaRendicontazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CorrettivaRendicontazioneCollection Select(IntNT IdEqualThis, IntNT IddomandapagamentoEqualThis, BoolNT ConclusaEqualThis, 
BoolNT AnnullataEqualThis, IntNT IdutenteEqualThis, DatetimeNT DataEqualThis, 
IntNT IdnoteEqualThis)
		{
			CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionTemp = CorrettivaRendicontazioneDAL.Select(_dbProviderObj, IdEqualThis, IddomandapagamentoEqualThis, ConclusaEqualThis, 
AnnullataEqualThis, IdutenteEqualThis, DataEqualThis, 
IdnoteEqualThis);
			CorrettivaRendicontazioneCollectionTemp.Provider = this;
			return CorrettivaRendicontazioneCollectionTemp;
		}

		//Find: popola la collection
		public CorrettivaRendicontazioneCollection Find(IntNT IddomandapagamentoEqualThis, BoolNT AnnullataEqualThis, BoolNT ConclusaEqualThis)
		{
			CorrettivaRendicontazioneCollection CorrettivaRendicontazioneCollectionTemp = CorrettivaRendicontazioneDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, AnnullataEqualThis, ConclusaEqualThis);
			CorrettivaRendicontazioneCollectionTemp.Provider = this;
			return CorrettivaRendicontazioneCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CORRETTIVA_RENDICONTAZIONE>
  <ViewName>vCORRETTIVA_RENDICONTAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY ID">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ANNULLATA>Equal</ANNULLATA>
      <CONCLUSA>Equal</CONCLUSA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE>
*/