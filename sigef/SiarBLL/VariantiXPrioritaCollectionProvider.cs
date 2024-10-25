using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for VariantiXPrioritaCollectionProvider:IVariantiXPrioritaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VariantiXPrioritaCollectionProvider : IVariantiXPrioritaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VariantiXPriorita
		protected VariantiXPrioritaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VariantiXPrioritaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VariantiXPrioritaCollection(this);
		}

		//Costruttore 2: popola la collection
		public VariantiXPrioritaCollectionProvider(IntNT IdvarianteEqualThis, IntNT IdprioritaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdvarianteEqualThis, IdprioritaEqualThis);
		}

		//Costruttore3: ha in input variantixprioritaCollectionObj - non popola la collection
		public VariantiXPrioritaCollectionProvider(VariantiXPrioritaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VariantiXPrioritaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VariantiXPrioritaCollection(this);
		}

		//Get e Set
		public VariantiXPrioritaCollection CollectionObj
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
		public int SaveCollection(VariantiXPrioritaCollection collectionObj)
		{
			return VariantiXPrioritaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VariantiXPriorita variantixprioritaObj)
		{
			return VariantiXPrioritaDAL.Save(_dbProviderObj, variantixprioritaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VariantiXPrioritaCollection collectionObj)
		{
			return VariantiXPrioritaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VariantiXPriorita variantixprioritaObj)
		{
			return VariantiXPrioritaDAL.Delete(_dbProviderObj, variantixprioritaObj);
		}

		//getById
		public VariantiXPriorita GetById(IntNT IdVarianteValue, IntNT IdPrioritaValue)
		{
			VariantiXPriorita VariantiXPrioritaTemp = VariantiXPrioritaDAL.GetById(_dbProviderObj, IdVarianteValue, IdPrioritaValue);
			if (VariantiXPrioritaTemp!=null) VariantiXPrioritaTemp.Provider = this;
			return VariantiXPrioritaTemp;
		}

		//Select: popola la collection
		public VariantiXPrioritaCollection Select(IntNT IdvarianteEqualThis, IntNT IdprioritaEqualThis, IntNT IdprogettoEqualThis, 
DecimalNT PunteggioEqualThis, DatetimeNT DatavalutazioneEqualThis, StringNT OperatoreEqualThis, 
BoolNT FlagdefinitivoEqualThis)
		{
			VariantiXPrioritaCollection VariantiXPrioritaCollectionTemp = VariantiXPrioritaDAL.Select(_dbProviderObj, IdvarianteEqualThis, IdprioritaEqualThis, IdprogettoEqualThis, 
PunteggioEqualThis, DatavalutazioneEqualThis, OperatoreEqualThis, 
FlagdefinitivoEqualThis);
			VariantiXPrioritaCollectionTemp.Provider = this;
			return VariantiXPrioritaCollectionTemp;
		}

		//Find: popola la collection
		public VariantiXPrioritaCollection Find(IntNT IdvarianteEqualThis, IntNT IdprioritaEqualThis)
		{
			VariantiXPrioritaCollection VariantiXPrioritaCollectionTemp = VariantiXPrioritaDAL.Find(_dbProviderObj, IdvarianteEqualThis, IdprioritaEqualThis);
			VariantiXPrioritaCollectionTemp.Provider = this;
			return VariantiXPrioritaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_X_PRIORITA>
  <ViewName>vVARIANTI_X_PRIORITA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDefinitivo>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </FiltroDefinitivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_X_PRIORITA>
*/